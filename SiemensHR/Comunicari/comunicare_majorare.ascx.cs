//Autor:Alex Mihai
//Modificat:Muntean Raluca Cristina
//Descriere:Este generata comunicarea majorarii salariului pentru un anumit angajat

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
	///		Summary description for comunicare_majorare.
	/// </summary>
	public class comunicare_majorare : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Button btnGenerati;
		protected System.Web.UI.WebControls.Table Table2;
		protected System.Web.UI.WebControls.TextBox txtDataInregistrarii;
		protected System.Web.UI.WebControls.Label lblDataInteg;
		protected System.Web.UI.WebControls.TextBox txtNrCom;
		protected System.Web.UI.WebControls.Label lblNrCom;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldNrCom;
		protected System.Web.UI.WebControls.Label lblCmpObl;
		protected System.Web.UI.WebControls.Label lblEroare;
		protected System.Web.UI.WebControls.ValidationSummary sumarValidare;

		protected Salaries.Business.Luni luni;
		protected Salaries.Data.LunaData lunaData;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldDataInreg;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldCmpObl;
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
						
			Utilities.CreateTableHeader(Table2, "Comunicare majorare drepturi banesti pentru luna "+" "+lunaData.Data.Month.ToString()+" / "+lunaData.Data.Year.ToString(), "", "normal");
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
				
		#region Generare comunicare 
		private void btnGenerati_Click(object sender, System.EventArgs e)
		{
			Salaries.Data.LunaData lunaAnterioara = luni.GetDetaliiByData(lunaData.Data.AddMonths(-1));
            
			// Situatia lunara a angajatului.
			Salaries.Business.SituatieLunaraAngajat situatieLunara =new Salaries.Business.SituatieLunaraAngajat(objAngajat.AngajatId);
			// Situatia lunara din luna curenta.
			Salaries.Data.InfoSituatieLunara infoSituatieLunara = situatieLunara.GetSituatieLunaraAngajat(objAngajat.AngajatId, lunaData.LunaId);
			// Situatia lunara de pe luna precedenta.
			Salaries.Data.InfoSituatieLunara infoSituatieLunaraAnt = situatieLunara.GetSituatieLunaraAngajat(objAngajat.AngajatId, lunaAnterioara.LunaId);			
			
			Salaries.Business.Salariu salariu = new Salaries.Business.Salariu();
			salariu.AngajatID = objAngajat.AngajatId;
            
			// Valoarea indexata a venitului brut.
			float sumaMajorareSalariuBrut = 0;
					
			sumaMajorareSalariuBrut = float.Parse(objAngajat.SalariuBaza.ToString()) - salariu.CalculVenitBrutIndexat();
			
			if (infoSituatieLunara.SituatieID != -1 && infoSituatieLunaraAnt.SituatieID != -1)
			{
				// Tipul comunicarii.
				Session["TipComunicare"] = "comunicare majorare.xml";	
				// Numarul comunicarii.
				Session["Numar"] = txtNrCom.Text;
				// Data inregistrarii comunicarii.
				Session["DataInregistrarii"] = txtDataInregistrarii.Text;
				// Salariul brut anterior.
				Session["SalariuBrutAnterior"] = infoSituatieLunaraAnt.SalariuBaza.ToString(); 		
				// Indemnizatie conducere anterioara.
				Session["IndemnizatieConducereAnterioara"] = infoSituatieLunaraAnt.IndemnizatieConducere.ToString();			
				// Suma cu care a fost majorat salariu de incadrare.
				Session["SumaMajorareSalariuBrut"] = sumaMajorareSalariuBrut.ToString();
				// Numele managerului general. 
				Session["ManagerGeneral"] = txtManagerGeneral.Text;
				// Numele directorului economic.
				Session["DirectorEconomic"] = txtDirectorEconomic.Text;

				Response.Redirect("Comunicari/comunicare.aspx?id=" + objAngajat.AngajatId);

				lblEroare.Text = "Comunicarea a fost generata.";
			}
			else
			{
				lblEroare.Text="Angajatul nu are situatii lunare generate!";				
			}
		}
		#endregion
	}
}
