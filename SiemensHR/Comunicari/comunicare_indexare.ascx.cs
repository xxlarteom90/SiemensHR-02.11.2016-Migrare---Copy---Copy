//Autor: Alexandru Mihai
//Modificat: Muntean Raluca Cristina

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

using SiemensHR.Classes;
using SiemensHR.utils;

namespace SiemensHR.Comunicari
{
	/// <summary>
	///		Summary description for comunicare_indexare.
	/// </summary>
	public class comunicare_indexare : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Constante
		private const int LUNA_INDEXARE_1 = 4;
		private const int LUNA_INDEXARE_2 = 10;
		#endregion

		#region Variabile
		protected System.Web.UI.WebControls.TextBox txtNrCom;
		protected System.Web.UI.WebControls.Button btnGenerati;
		protected System.Web.UI.WebControls.Table Table2;
		protected System.Web.UI.WebControls.Label lblCmpObl;
		protected System.Web.UI.WebControls.Label lblCmpOblig;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldCmpObl;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldNrCom;
		protected System.Web.UI.WebControls.TextBox txtDataInregistrarii;
		protected System.Web.UI.WebControls.Label lblDataInteg;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldDataInreg;		
		protected System.Web.UI.WebControls.Label lblEroare;
		protected System.Web.UI.WebControls.ValidationSummary sumarValidare;

		protected Salaries.Business.Luni luni;
		protected Salaries.Data.LunaData lunaData;
		protected System.Web.UI.WebControls.TextBox txtManagerGeneral;
		protected System.Web.UI.WebControls.TextBox txtDirectorEconomic;
		public Salaries.Business.Angajat objAngajat;
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

			// Este aflata luna activa
			luni = new Salaries.Business.Luni(objAngajat.AngajatorId);
			lunaData= luni.GetLunaActiva();

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
			
			Utilities.CreateTableHeader(Table2, "Comunicare indexare drepturi banesti pentru luna "+" "+lunaData.Data.Month.ToString()+" / "+lunaData.Data.Year.ToString(), "", "normal");
		}
		#endregion

		#region Generare comunicare
		private void btnGenerati_Click(object sender, System.EventArgs e)
		{
			Salaries.Business.Salariu salariu = new Salaries.Business.Salariu();
			salariu.AngajatID = objAngajat.AngajatId;
            
			// true, daca este luna incheie un trimestru, false altfel
			bool lnSfDeTrim=false;

			// Valoarea indexata a venitului brut.
			float venitBrutIndexat = 0;
	
			int lunaCurenta=int.Parse(luni.GetLunaActiva().Data.Month.ToString());
		
			switch(lunaCurenta)
			{
				case LUNA_INDEXARE_1:
					lnSfDeTrim=true;
					break;
				case LUNA_INDEXARE_2:
					lnSfDeTrim=true;
					break;
			}
			
			venitBrutIndexat = salariu.CalculVenitBrutIndexat();
			/*
				Se verifica daca este cazul sa se genereze o astfel de comunicare.
			Anul este impartit in patru trimestre(lunile 1-3,4-6,7-9,10-12)
			Indexarea se reflecta in salariul din ultima luna a trimestrului. Cum 
			salariul primit in luna activa este de pe luna anterioara, indexarea
			trebuie sa fie facuta in fiecare din lunile 1,4,7 si 10.Se verifica, de asemenea,
			daca angajatul a lucrat cel putin o luna pe trimestrul anterior.
			*/
			if((lnSfDeTrim) && (venitBrutIndexat != 0))
			{
				// Sunt introduse in sesiune datele referitoare la comunicare.
				// Tipul comunicarii.
				Session["TipComunicare"] = "comunicare indexare.xml";
				// Numarul comunicarii.
				Session["Numar"] = txtNrCom.Text;
				// Data inregistrarii comunicarii.
				Session["DataInregistrarii"]=txtDataInregistrarii.Text;
				// Procentul inflatiei.
				Session["ProcentIndexare"] = (salariu.CalculProcentIndexareAngajat() - 1)*100;
				// Valoarea salariului de incadrare dupa indexare.
				Session["SalariuIncadrare"]=  venitBrutIndexat;
				// Numele managerului general. 
				Session["ManagerGeneral"] = txtManagerGeneral.Text;
				// Numele directorului economic.
				Session["DirectorEconomic"] = txtDirectorEconomic.Text;

				Response.Redirect("Comunicari/comunicare.aspx?id=" + objAngajat.AngajatId);

				lblEroare.Text = "Comunicarea a fost generata.";
			}
				// Altfel este afisat un mesaj de eroare.
			else
			{
				if (!lnSfDeTrim)
				{
					lblEroare.Text = "Pe aceasta luna nu trebuie generata o astfel de comunicare!";
				}
				if (venitBrutIndexat == 0)
				{
					lblEroare.Text = "Acestui angajat nu i-a fost indexat salariul in luna curenta!";
				}
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
			this.btnGenerati.Click += new System.EventHandler(this.btnGenerati_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
