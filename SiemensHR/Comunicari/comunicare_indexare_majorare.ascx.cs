//Autor: Cristina Raluca Muntean
//Descriere: Este generata comunicarea majorarii salariului precum si cea legata de indexare pentru un anumit angajat

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
	///		Summary description for comunicare_indexare_majorare.
	/// </summary>
	public class comunicare_indexare_majorare : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Constante
		private const int LUNA_INDEXARE_1 = 4;
		private const int LUNA_INDEXARE_2 = 10;
		#endregion

		#region Variabile
		protected System.Web.UI.WebControls.TextBox txtNrCom;
		protected System.Web.UI.WebControls.Button btnGenerati;
		protected System.Web.UI.WebControls.Table Table2;
		protected System.Web.UI.WebControls.Label lblNrCom;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldRNrCom;
		protected System.Web.UI.WebControls.Label lblCmpObl;
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
			
			Utilities.CreateTableHeader(Table2, "Comunicare indexare si majorare drepturi banesti pentru luna "+" "+lunaData.Data.Month.ToString()+" / "+lunaData.Data.Year.ToString(), "", "normal");
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
		
		#region butonul de generare a comunicarii
		private void btnGenerati_Click(object sender, System.EventArgs e)
		{
			// Date luna anterioara.
			Salaries.Data.LunaData lunaAnterioara = luni.GetDetaliiByData(lunaData.Data.AddMonths(-1));
			// Situatia lunara a angajatului.
			Salaries.Business.SituatieLunaraAngajat situatieLunara =new Salaries.Business.SituatieLunaraAngajat(objAngajat.AngajatId);
			// Situatia lunara din luna curenta.
			Salaries.Data.InfoSituatieLunara infoSituatieLunara = situatieLunara.GetSituatieLunaraAngajat(objAngajat.AngajatId, lunaData.LunaId);
			// Situatia lunara de pe luna precedenta.
			Salaries.Data.InfoSituatieLunara infoSituatieLunaraAnt = situatieLunara.GetSituatieLunaraAngajat(objAngajat.AngajatId, lunaAnterioara.LunaId);			
			
			Salaries.Business.Salariu salariu = new Salaries.Business.Salariu();
			salariu.AngajatID = objAngajat.AngajatId;
            
			// true, daca este luna incheie un trimestru, false altfel
			bool lnSfDeTrim=false;
			// Suma cu care a fost majorat salariul angajatului.
			float sumaMajorare = 0;

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
				Session["ProcentIndexare"] = (salariu.CalculProcentIndexareAngajat()-1)*100;
				// Este calculata valoarea majorarii.
				sumaMajorare = (infoSituatieLunara.IndemnizatieConducere - infoSituatieLunaraAnt.IndemnizatieConducere) +
							   (infoSituatieLunara.SalariuBaza - salariu.CalculVenitBrutIndexat());
				// Valoare majorare.
				Session["SumaMajorare"] = sumaMajorare;
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
					lblEroare.Text = "Acestui angajat nu trebuie sa ii fie indexat salariul!";
				}
			}
		}
		#endregion
	}
}
