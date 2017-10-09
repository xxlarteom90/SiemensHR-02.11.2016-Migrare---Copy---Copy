/*
 * Autor:     Manuel Neagoe
 * Data:      01.03.2013
 * Descriere: Este generata fisa fiscala pentru un anumit an
 */

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///	Este generata declatatia pentru sanatate Anexa3a.
	/// </summary>
	public class rapoarte_FiseFiscaleXml : SiemensHR.InterfataSalarii.Classes.BaseModule
	{


		#region Variabile
		private int lunaID;
		private int angajatorID;
		private int casaDeAsigurariID;
		private int an;
		private int tipDeclaratie;
		private int totBaza;
		private int totImp;
		#endregion


		#region Constrante
		// Numele cheii din web.config care contine calea catre serverul cu rapoartele.
		private const string STRING_URL = "rapoarteServerUrl";

		protected System.Web.UI.WebControls.TextBox textBoxAn;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqFieldValAn;
		protected System.Web.UI.WebControls.RangeValidator rangeValAn;
		protected System.Web.UI.WebControls.DropDownList drpCaseDeAsig;
		protected System.Web.UI.WebControls.DropDownList drpTipDeclaratie;
		protected System.Web.UI.WebControls.Label labelError;
		protected System.Web.UI.WebControls.Button btnGenereaza;
		protected System.Web.UI.WebControls.HyperLink hyperLinkDeclaratie;
		protected System.Web.UI.WebControls.ValidationSummary sumarValidare;
		private const string importLogFolder = "importFolder";
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			lunaID = this.GetCurrentMonth();
			angajatorID = this.GetAngajator();


			if (!IsPostBack)
			{
				hyperLinkDeclaratie.Visible = false;
			}
		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			try
			{
				DataSet dsCaseDeAsig = new DataSet(); 
				Salaries.Business.AdminAngajator angajator = new Salaries.Business.AdminAngajator();
				angajator.AngajatorId = this.GetAngajator();

				Salaries.Business.Luni luna = new Salaries.Business.Luni( this.GetAngajator() );
				Salaries.Data.LunaData lunaCurenta = luna.GetLunaActiva();
				textBoxAn.Text = (lunaCurenta.Data.Year - 1 ).ToString();

				if (!IsPostBack)
				{
					// Lista caselor de asigurari ale unui angajator.
					dsCaseDeAsig = angajator.GetCaseDeAsigurari();
					drpCaseDeAsig.DataSource = dsCaseDeAsig;
					drpCaseDeAsig.DataTextField = "Denumire";
					drpCaseDeAsig.DataValueField = "CasaDeAsigurariID";
					drpCaseDeAsig.DataBind();

					
				}

//				this.raportFisaFiscala.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);
//				// Sunt setati parametrii raportului.
//				// ID-ul angajatorului pentru care se genereaza declaratia.
//				this.raportFisaFiscala.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
//				// Id-ul lunii pentru care se genereaza declaratia.
//				this.raportFisaFiscala.SetQueryParameter("An",textBoxAn.Text);
//				// Punctul de lucru.
//				this.raportFisaFiscala.SetQueryParameter("CasaDeAsigurariID",drpCaseDeAsig.SelectedItem.Value);
	
			}
			catch ( Exception )
			{
				labelError.Text = "Pentru a putea genera raportul trebuie sa fie disponibile toate datele necesare!";
			}
		}
		#endregion

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBoxAn.TextChanged += new System.EventHandler(this.textBoxAn_TextChanged);
			this.drpCaseDeAsig.SelectedIndexChanged += new System.EventHandler(this.drpCaseDeAsig_SelectedIndexChanged);
			this.drpTipDeclaratie.SelectedIndexChanged += new System.EventHandler(this.drpTipDeclaratie_SelectedIndexChanged);
			this.btnGenereaza.Click += new System.EventHandler(this.btnGenereaza_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Generare
		/// <summary>
		/// Genereaza raportul
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGenereaza_Click(object sender, System.EventArgs e)
		{

			an = Convert.ToInt32(textBoxAn.Text);
			casaDeAsigurariID = Convert.ToInt32(drpCaseDeAsig.SelectedValue.ToString());
			tipDeclaratie = Convert.ToInt32(drpTipDeclaratie.SelectedValue.ToString());


			string path = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(importLogFolder) + "\\FisaFiscala.xml";
			XmlTextReader reader = new XmlTextReader(path);
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(reader);

			Salaries.Business.Salariu sal = new Salaries.Business.Salariu();

			#region declaratie205

			//duc datasetul cu reprezentantii legali - pentru declarant 
			Salaries.Business.AdminAngajator adminAng = new Salaries.Business.AdminAngajator();
			adminAng.AngajatorId = angajatorID;
			DataSet ds = adminAng.GetReprezLegali();
			string numeDeclarant = "", prenumeDeclarant = "", functieDeclarant = "";
			foreach(DataRow dr in ds.Tables[0].Rows)
			{
				// Numele si prenumele declarantului 
				if (dr["NumeFunctie"].ToString().Equals("Contabil sef"))
				{
					numeDeclarant = dr["NumeReprez"].ToString();
					prenumeDeclarant = dr["PrenumeReprez"].ToString();
					functieDeclarant = dr["NumeFunctie"].ToString();
				}
			}
			
			DataSet dsAngajator = adminAng.GetAngajatorInfoFiseFiscale(angajatorID);
			DataTable dtAngajator = dsAngajator.Tables[0];

			//completez atributele nodului;
			XmlNode nodeDeclaratie = xmlDoc.GetElementsByTagName("declaratie205")[0];
			nodeDeclaratie.Attributes["luna"].Value = "12";
			nodeDeclaratie.Attributes["an"].Value = textBoxAn.Text.ToString();
			nodeDeclaratie.Attributes["d_rec"].Value = drpTipDeclaratie.SelectedValue.ToString();
			nodeDeclaratie.Attributes["nume_declar"].Value = numeDeclarant;
			nodeDeclaratie.Attributes["prenume_declar"].Value = prenumeDeclarant;
			nodeDeclaratie.Attributes["functie_declar"].Value = functieDeclarant;
			nodeDeclaratie.Attributes["cui"].Value = dtAngajator.Rows[0]["CUI_CNP"].ToString();
			nodeDeclaratie.Attributes["den"].Value = dtAngajator.Rows[0]["Denumire"].ToString();
			nodeDeclaratie.Attributes["adresa"].Value = dtAngajator.Rows[0]["Adresa"].ToString();
			nodeDeclaratie.Attributes["telefon"].Value = dtAngajator.Rows[0]["Telefon"].ToString();
			nodeDeclaratie.Attributes["fax"].Value = dtAngajator.Rows[0]["Fax"].ToString();
			nodeDeclaratie.Attributes["mail"].Value = dtAngajator.Rows[0]["Email"].ToString();
			

			#endregion

			#region beneficiar

			Salaries.Business.Declaratii decl = new Salaries.Business.Declaratii(lunaID, angajatorID);
			DataSet dsFiseFiscale = decl.GetDateFiseFiscale(an, casaDeAsigurariID);
			int nrAngajati = dsFiseFiscale.Tables[0].Rows.Count;
			DataTable dtFiseFiscale = dsFiseFiscale.Tables[0];

			XmlNode nodeBenef = xmlDoc.GetElementsByTagName("benef")[0];
			XmlNode parent = nodeBenef.ParentNode;
			foreach(DataRow dr in dsFiseFiscale.Tables[0].Rows)
			{
				XmlNode nodeBeneficiar = nodeBenef.CloneNode(true);

				nodeBeneficiar.Attributes["id_inreg"].Value = dr["AngajatId"].ToString();
				nodeBeneficiar.Attributes["tip_venit1"].Value = "07";
				nodeBeneficiar.Attributes["den1"].Value = dr["DENUMIRE"].ToString();
				nodeBeneficiar.Attributes["cif1"].Value = dr["COD"].ToString();
				nodeBeneficiar.Attributes["tip_salAB"].Value = "1";
				nodeBeneficiar.Attributes["tip_plata"].Value = "2";
				nodeBeneficiar.Attributes["tip_functie"].Value = dr["TIP"].ToString();
				nodeBeneficiar.Attributes["vbrut"].Value = dr["VBRUT_13"].ToString();
				nodeBeneficiar.Attributes["dedu_pers"].Value = dr["DEDU_13"].ToString();
				nodeBeneficiar.Attributes["dedu_alte"].Value = dr["ALTDED_13"].ToString();
				nodeBeneficiar.Attributes["baza1"].Value = dr["VENIT_13"].ToString();
				nodeBeneficiar.Attributes["imp1"].Value = dr["IMPOZIT_13"].ToString();
				parent.InsertAfter(nodeBeneficiar, nodeBenef);

				totBaza = totBaza + Convert.ToInt32(dtFiseFiscale.Rows[0]["VENIT_13"].ToString());
				totImp = totImp + Convert.ToInt32(dtFiseFiscale.Rows[0]["IMPOZIT_13"].ToString());
			}
			parent.RemoveChild(nodeBenef);
		
		

			#endregion

			#region sect_II
			XmlNode node = xmlDoc.GetElementsByTagName("sect_II")[0];
			node.Attributes["tip_venit"].Value = "07";
			node.Attributes["nrben"].Value = nrAngajati.ToString();
			node.Attributes["Tcastig"].Value = "0";
			node.Attributes["Tpierd"].Value = "0";
			node.Attributes["Tbaza"].Value = totBaza.ToString();
			node.Attributes["Timp"].Value = totImp.ToString();

			int totalPlata = nrAngajati + totBaza + totImp;
			nodeDeclaratie.Attributes["totalPlata_A"].Value = totalPlata.ToString();


			#endregion

			path = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(importLogFolder) + "\\FisaFiscalaOut.xml";
						
			//path = "C:\\Inetpub\\wwwroot\\hr\\InterfataSalarii\\Templates\\DecUnicaOut.xml";
			xmlDoc.Save(path);

			path = this.Page.Request.Url.AbsoluteUri;
			path = path.Substring(0, path.LastIndexOf("/"));
			hyperLinkDeclaratie.NavigateUrl = path + "/Templates/FisaFiscalaOut.xml";
			hyperLinkDeclaratie.Visible = true;
		}
		#endregion

		#region controls
		private void textBoxAn_TextChanged(object sender, System.EventArgs e)
		{
			an = Convert.ToInt32(textBoxAn.Text.ToString());			
		}

		private void drpCaseDeAsig_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			casaDeAsigurariID = Convert.ToInt32(drpCaseDeAsig.SelectedValue.ToString());
		}

		private void drpTipDeclaratie_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			tipDeclaratie = Convert.ToInt32(drpTipDeclaratie.SelectedValue.ToString());
		}
		#endregion
	}
}
