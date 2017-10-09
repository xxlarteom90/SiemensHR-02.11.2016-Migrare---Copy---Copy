//Autor: Cristina Raluca Muntean
//Descriere: este generata adeverinta pentru medicul de familie

//	Modificat:	Lungu Andreea
//	Data:		21.08.2008
//	Descriere:	Datele reprezentantilor legali (manager general, director economic, manager hr) 
//              sunt aduse din baza de date la page_load si nu pot fi modificate decat de la angajator.

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

using Salaries.Data;
using SiemensHR.Classes;
using SiemensHR.utils;

namespace SiemensHR.Comunicari
{
	/// <summary>
	///		Summary description for adeverintaMedicDeFamilie.
	/// </summary>
	public class adeverintaMedicDeFamilie : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Table Table2;
		protected System.Web.UI.WebControls.TextBox txtDataInregistrarii;
		protected System.Web.UI.WebControls.Label lblDataInteg;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldDataInreg;
		protected System.Web.UI.WebControls.TextBox txtNrCom;
		protected System.Web.UI.WebControls.Label lblNrCom;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldNrComunicare;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldNrComRegExp;
		protected System.Web.UI.WebControls.Label lblCmpObl;
		protected System.Web.UI.WebControls.Button btnGenerati;

		protected Salaries.Configuration.ModuleSettings settings;
		//angajat
		public Salaries.Business.Angajat objAngajat;
		protected System.Web.UI.WebControls.DropDownList drpInspectorResurseUmane;
		protected System.Web.UI.WebControls.Label lblEroare;
		protected System.Web.UI.WebControls.ValidationSummary sumarValidare;
		protected System.Web.UI.WebControls.TextBox txtManagerGeneral;
		protected System.Web.UI.WebControls.TextBox txtDirectorEconomic;
		//string in care sunt memorate datele necesare generarii comunicarii care nu au fost completate
		protected string dateNecesare="";
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			Salaries.Business.Luni luni;
			Salaries.Data.LunaData lunaData;

			if (objAngajat.IsLichidat)
			{
				btnGenerati.Enabled = false;
				drpInspectorResurseUmane.Enabled = false;
				
				lblEroare.Text = "Angajatul selectat este lichidat!";
			}
			
			// Este aflata luna activa
			luni = new Salaries.Business.Luni(objAngajat.AngajatorId);
			lunaData= luni.GetLunaActiva();

			// DataSet-ul cu numele tuturor angajatilor.
			objAngajat.CategorieId = -1;
			DataSet dsAngajati = objAngajat.GetAllAngajati();
			
			drpInspectorResurseUmane.DataSource = dsAngajati;
			drpInspectorResurseUmane.DataTextField = "NumeIntregCuTitlu";
			drpInspectorResurseUmane.DataValueField = "AngajatID";
			drpInspectorResurseUmane.DataBind();

			Salaries.Business.AdminAngajator adminAng = new Salaries.Business.AdminAngajator();
			adminAng.AngajatorId = Int32.Parse(Session["AngajatorId"].ToString());
			DataSet ds = adminAng.GetReprezLegali();
			foreach(DataRow dr in ds.Tables[0].Rows)
			{
				// Numele managerului general. 
				if (dr["NumeFunctie"].ToString().Equals("Manager general"))
					txtManagerGeneral.Text = dr["NumeReprez"].ToString() + " " + dr["PrenumeReprez"].ToString();
				// Numele directorului economic.
				if (dr["NumeFunctie"].ToString().Equals("Director economic"))
					txtDirectorEconomic.Text = dr["NumeReprez"].ToString() + " " + dr["PrenumeReprez"].ToString();
			}
			//header de tabel
			Utilities.CreateTableHeader(Table2, "Adeverinta pentru medicul de familie", "", "normal");
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
			this.btnGenerati.Click += new System.EventHandler(this.btnGenerati_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region este generata comunicarea si sunt inserate datele in baza de date
		private void btnGenerati_Click(object sender, System.EventArgs e)
		{
			Salaries.Business.Angajat inspectorResurseUmane = new Salaries.Business.Angajat();
			inspectorResurseUmane.AngajatId = long.Parse(drpInspectorResurseUmane.SelectedValue);
			inspectorResurseUmane.LoadAngajat();

			if(ExistaToateDatele())
			{
				//sunt introduse in sesiune tipul comunicarii, numarul acesteia si suma
				Session["TipComunicare"] = "adeverinta_medic.xml";
				Session["Numar"] = txtNrCom.Text;
				Session["DataInregistrarii"]=txtDataInregistrarii.Text;
				
				// Numele managerului general. 
				Session["ManagerGeneral"] = txtManagerGeneral.Text;
				// Numele directorului economic.
				Session["DirectorEconomic"] = txtDirectorEconomic.Text;
				
				// Numele inspectorului de resurse umane. 
				Session["InspectorResurseUmane"] = drpInspectorResurseUmane.SelectedItem.Text;
				// Email-ul inspectorului de resurse umane
				Session["InspResUmaneMail"] = inspectorResurseUmane.Email; 
				// Telefonul inspectorului de resurse umane
				Session["InspResUmaneNrTel"] = inspectorResurseUmane.Telefon; 

				Response.Redirect("Comunicari/comunicare.aspx?id=" + objAngajat.AngajatId);

				//este generata comunicarea
				lblEroare.Text = "Comunicarea a fost generata.";
			}
			else
			{
				char[] sep = {':'};//se stabileste separatorul
				Array aDate = dateNecesare.Split(sep);//se face impartirea in functie de separator
				string dateNecesareF="";

				for(int i=0;i<aDate.Length-2;i++)
				{
					dateNecesareF+=aDate.GetValue(i).ToString()+", ";
				}
				dateNecesareF+=aDate.GetValue(aDate.Length-2).ToString();

				lblEroare.Text="Pentru a genera adeverinta medicala a acestui angajat trebuie sa mai completati urmatoarele campuri: "+dateNecesareF;
			}
		}
		#endregion
		
		#region Se verifica daca exista toate datele necesare generaii comunicarii
		public bool ExistaToateDatele()
		{
			bool existaToateDatele = true;
			
			//este aflata luna activa
			Salaries.Business.Luni luni = new Salaries.Business.Luni(objAngajat.AngajatorId);
			Salaries.Data.LunaData lunaData= luni.GetLunaActiva();

			//numar de inregistrare contract de munca
			if(objAngajat.NrContractMunca.ToString()=="")
			{
				existaToateDatele=false;
				dateNecesare+=" numar contract de munca:";
			}
		
			//se verifica nationalitatea angajatului
			//in cazul in care angajatul este cetatean strain se mai verifica niste campuri daca sunt completate
			int nationalitate = objAngajat.Nationalitate;
			
			int idTaraDeBaza=0;
			//practic DataSet-ul returneaza un singur rand
			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			DataSet dsTaraDeBaza = tari.GetTaraDeBaza();
			foreach(DataRow row in dsTaraDeBaza.Tables[0].Rows)
			{
				idTaraDeBaza=int.Parse(row["TaraID"].ToString());
			}

			//daca este cetatean strain
			if(nationalitate!=idTaraDeBaza)
			{				
				if(objAngajat.NIF == null)
				{
					existaToateDatele = false;
					dateNecesare +=" numarul de inregistrare fiscala:";
				}
			}
			// in cazul in care angajatul este cetatean roman 
			else
			{
				//cu domiciliul in strainatate 
				if(objAngajat.DTara!=nationalitate)
				{
					if (objAngajat.NIF == null)
					{
						existaToateDatele = false;
						dateNecesare +=" numarul de inregistrare fiscala:";
					}
					else
					{
						//trebuie verificat si numarul de inregistreare fiscala sau CNP-ul
						if((objAngajat.NIF == null)&&(objAngajat.CNP.ToString()=="0"))
						{
							existaToateDatele = false;
							dateNecesare +=" numarul de inregistrare fiscala sau CNP-ul angajatului:";
						}
					}
				}
			}
			return existaToateDatele;
		}
		#endregion
	}
}
