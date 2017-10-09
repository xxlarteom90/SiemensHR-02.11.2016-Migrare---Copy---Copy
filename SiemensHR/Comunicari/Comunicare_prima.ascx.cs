//Autor: Cristina Raluca Muntean
//Descriere: Este generata comunicarea primei pentru un anumit angajat

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
	///		Summary description for Comunicare_prima.
	/// </summary>
	/// 
	public class Comunicare_prima : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.TextBox txtNrCom;
		protected System.Web.UI.WebControls.TextBox txtDataInregistrarii;
		protected System.Web.UI.WebControls.Label lblNrCom;
		protected System.Web.UI.WebControls.Label lblCmpObl;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldNrComRegExp;
		protected System.Web.UI.WebControls.Table Table2;
		protected System.Web.UI.WebControls.Button btnGenerati;

		protected Salaries.Configuration.ModuleSettings settings;
		protected Salaries.Data.LunaData lunaData;
		protected System.Web.UI.WebControls.Label lblDataInteg;

		public Salaries.Business.Angajat objAngajat;
		protected System.Web.UI.WebControls.Label lblEroare;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldDataInreg;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldCmpObl;
		protected System.Web.UI.WebControls.ValidationSummary sumarValidare;
		protected System.Web.UI.WebControls.TextBox txtDirectorEconomic;
		protected System.Web.UI.WebControls.TextBox txtManagerGeneral;
		//in cazul in care lipsesc date necesare generarii comunicarii sunt retinute in acest string 
		protected string dateNecesare=""; 
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (objAngajat.IsLichidat)
			{
				btnGenerati.Enabled = false;
				txtNrCom.Enabled = false;
				txtDataInregistrarii.Enabled = false;

				lblEroare.Text = "Angajatul selectat este lichidat!";
			}
			
			// DataSet-ul cu numele tuturor angajatilor.
			objAngajat.CategorieId = -1;

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

			//este aflata luna activa
			Salaries.Business.Luni luni = new Salaries.Business.Luni(objAngajat.AngajatorId);
			lunaData= luni.GetLunaActiva();
			
			//header de tabel
			Utilities.CreateTableHeader(Table2, "Comunicare prima pentru luna "+" "+lunaData.Data.Month.ToString()+" / "+lunaData.Data.Year.ToString(), "", "normal");	
		}
		#endregion
	
		#region Generarea comunicarii 
		private void btnGenerati_Click(object sender, System.EventArgs e)
		{
			// Situatia lunara a angajatului.
			Salaries.Business.SituatieLunaraAngajat situatieLunara =new Salaries.Business.SituatieLunaraAngajat(objAngajat.AngajatId);
			Salaries.Data.InfoSituatieLunara infoSituatieLunara = situatieLunara.GetSituatieLunaraAngajat(objAngajat.AngajatId, lunaData.LunaId);
			// Datele necesare comunicarii care nu sunt completate. 
			string dateNecesareF=string.Empty;

			if (ExistaToateDatele() && infoSituatieLunara.SituatieID != -1)
			{
				// Sunt introduse in sesiune tipul comunicarii, numarul acesteia si suma
				// Tipul comunicarii.
				Session["TipComunicare"] = "comunicare prima.xml";
				// Numarul comunicarii.
				Session["Numar"] = txtNrCom.Text;
				// Valoarea primei.
				Session["Suma"] = infoSituatieLunara.PrimaProiect.ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithDigits);
				// Data inregistrarii declaratiei.
				Session["DataInregistrarii"] = txtDataInregistrarii.Text;
				// Numele managerului general. 
				Session["ManagerGeneral"] = txtManagerGeneral.Text;
				// Numele directorului economic.
				Session["DirectorEconomic"] = txtDirectorEconomic.Text;
				//este generata comunicarea
				lblEroare.Text = "Comunicarea a fost generata.";

				Response.Redirect("Comunicari/comunicare.aspx?id=" + objAngajat.AngajatId);
			}
			else
			{
				if (dateNecesare ==  string.Empty)
				{
					lblEroare.Text="Pentru a genera comnunicarea trebuie sa generati situatia lunara a angajatului.";
				}
				else
				{
					// Se stabileste separatorul.
					char[] sep = {':'};

					// Se face impartirea in functie de separator.
					Array aDate = dateNecesare.Split(sep);

					for(int i=0; i<aDate.Length-2; i++)
					{
						dateNecesareF+=aDate.GetValue(i).ToString()+", ";
					}

					dateNecesareF+=aDate.GetValue(aDate.Length-2).ToString();

					lblEroare.Text="Pentru a genera comnunicarea trebuie sa mai completati urmatoarele campuri: "+dateNecesareF;
				}
			}
		}
		#endregion
		
		#region Se verifica daca exista toate datele necesare generarii comunicarii
		/// <summary>
		/// Se verifica daca exista toate datele necesare comunicarii.
		/// </summary>
		/// <returns> true in cazul in care exista toate datele, false altfel.</returns>
		public bool ExistaToateDatele()
		{
			bool verificare=true;

			if(objAngajat.DepartamentCurentDenumire=="")
			{
				verificare=false;

				dateNecesare+=" departamentul in care este angajatul:";
			}
			
			return verificare;
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
	}
}
