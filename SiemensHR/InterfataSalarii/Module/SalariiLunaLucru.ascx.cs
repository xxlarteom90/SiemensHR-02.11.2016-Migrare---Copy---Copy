using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data.SqlClient;

using SiemensHR.utils;

namespace SiemensHR.InterfataSalarii
{
	/// <summary>
	///		Summary description for SalariiLunaLucru.
	/// </summary>
	public class SalariiLunaLucru : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Button InchideLunaActiva;
		protected System.Web.UI.WebControls.Button CalculSalarii;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.DropDownList lstLuni;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HDACT;
		protected System.Web.UI.WebControls.Button btnRedeschidereLuna;
		protected System.Web.UI.WebControls.Button Button3;
		protected Salaries.Configuration.ModuleSettings settings;	
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			Salaries.Business.Luni luni = new Salaries.Business.Luni(this.GetAngajator());
			Salaries.Data.LunaData lunaData = luni.GetLunaActiva();

			if (!IsPostBack)
			{
				BindComboLstLuni( luni );

				if (!this.CurrentMonthInSession())
				{	
					if (lunaData.LunaId != -1) 
					{
						this.lstLuni.SelectedValue = lunaData.LunaId.ToString();	
					}

					this.SetCurrentMonth(int.Parse(this.lstLuni.SelectedValue));
				} 
				else
				{
					this.lstLuni.SelectedValue = this.GetCurrentMonth().ToString();
				}
			}
			this.SetCurrentMonth(int.Parse(this.lstLuni.SelectedValue));
			
			//this.CalculSalarii.Attributes["onclick"]="CancelValidation();return -1;";
			this.CalculSalarii.Attributes.Add("onclick", "return CheckDelete('Sunteti sigur ca doriti sa efectuati calculul salarial?');");
			this.InchideLunaActiva.Attributes.Add("onclick", "return CheckDelete('Sunteti sigur ca doriti sa inchideti luna activa?');");
			this.btnRedeschidereLuna.Attributes.Add("onclick", "return CheckDelete('Sunteti sigur ca doriti sa redeschideti luna anterioara?');");
		}

		#endregion

		#region BindComboLstLuni
		/// <summary>
		/// Este completat combobox-ul care contine lunile existente
		/// </summary>
		/// <param name="luni">Obiectul care contine lunile</param>
		private void BindComboLstLuni( Salaries.Business.Luni luni )
		{
			this.lstLuni.DataSource = luni.GetLuni();
			this.lstLuni.DataValueField = "LunaID";
			this.lstLuni.DataTextField = "Denumire";
			this.lstLuni.DataBind();
		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			Salaries.Business.Luni luni = new Salaries.Business.Luni(this.GetAngajator());
			Salaries.Data.LunaData lunaData = luni.GetLunaActiva();	
			
			Salaries.Data.LunaData ldActiva = new Salaries.Business.Luni(this.GetAngajator()).GetLunaActiva();							
			
			// Verificam daca luna selectata este activa
			if ( ldActiva.LunaId != GetCurrentMonth())
			{
				Response.Write("<script>var IsCurrentMonthActive = 0;</script>");
			}
			else
			{
				Response.Write("<script>var IsCurrentMonthActive = 1;</script>");
			}
		}

		#endregion

		#region VerificaVariabileSalarizare
		/// <summary>
		/// Procedura verifica daca toate variabilele de salatizare au valori diferite de zero
		/// </summary>
		/// <param name="lunaId">Id-ul lunii pentru care se verifica valorile variabilelor</param>
		/// <returns>Returneaza true daca aceste variabile au valori corecte si false altfel</returns>
		/// <remarks>
		/// Adaugat:	Oprescu Claudia
		/// Data:		20.02.2007
		/// </remarks>
		private bool VerificaVariabileSalarizare(int lunaId)
		{
			Salaries.Business.VariabileGlobaleValori variabila = new Salaries.Business.VariabileGlobaleValori();
			DataSet ds = variabila.GetAllVariabileGlobaleValoriPeLuna(lunaId);
			for (int i=0; i<ds.Tables[0].Rows.Count; i++)
			{
				if ( float.Parse(ds.Tables[0].Rows[i]["Valoare"].ToString()) <= 0 )
				{
					return false;
				}
			}
			return true;
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
			this.lstLuni.SelectedIndexChanged += new System.EventHandler(this.lstLuni_SelectedIndexChanged);
			this.CalculSalarii.Click += new System.EventHandler(this.CalculSalarii_Click);
			this.InchideLunaActiva.Click += new System.EventHandler(this.InchideLunaActiva_Click);
			this.btnRedeschidereLuna.Click += new System.EventHandler(this.btnRedeschidereLuna_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region lstLuni_SelectedIndexChanged
		/// <summary>
		/// Modifica luna curenta daca a fost selectata alta din lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstLuni_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.SetCurrentMonth(int.Parse(this.lstLuni.SelectedValue));
		}
		#endregion

		#region InchideLunaActiva_Click
		/// <summary>
		/// Inchide luna activa
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void InchideLunaActiva_Click(object sender, System.EventArgs e)
		{
			//Modificat:	Oprescu Claudia
			//Data:			20.02.2007
			//Descriere:	Se efectueaza o serie de verificari inainte de inchiderea lunii.
			//				Nomencalatorul cu criterii de acordare a concediului medical nu poate fi gol.
			//				In nomenclator trebuie sa existe un interval corespunzator numarului de angajati.
			//				Procentul de inflatie nu poate fi zero.
			//				Variabilele de salarizare trebuie sa aiba valori diferite de zero.

			Salaries.Business.Luni luni = new Salaries.Business.Luni( this.GetAngajator());
			Salaries.Data.LunaData lunaData = luni.GetLunaActiva();

			Salaries.Business.NomenclatorConcediiMedicale concedii = new Salaries.Business.NomenclatorConcediiMedicale();
			DataSet ds = concedii.GetConcediiMedicale();

			//daca nomenclatorul cu concedii medicale nu are nici un concediu medical se va afisa un mesaj de avertizare
			if (ds.Tables[0].Rows.Count == 0)
			{
				Response.Write("<script> alert('Nomenclatorul pentru criterii de acordare a concediului medical este gol. \\nNu se poate efectua inchiderea de luna. Va rugam specificati valori pentru acest criteriu!'); </script>");
			}
			//daca exista date in nomenclator
			else
			{
				//trebuie sa existe un interval corespunzator numarului de angajati din firma
				//daca nu exista nici un interval utilizatorul va primi un mesaj de avertizare
				Salaries.Business.PontajAngajat pontaj = new Salaries.Business.PontajAngajat(-1);
				if (pontaj.GetNrZileConcediuBoalaPlatiteFirma(this.GetAngajator()) == 0)
				{
					Response.Write("<script> alert('Nomenclatorul pentru criterii de acordare a concediului medical nu contine un interval corespunzator numarului de angajati. \\nNu se poate efectua inchiderea de luna. Va rugam specificati valori corecte pentru acest criteriu!'); </script>");
				}
				//daca exista un interval corespunzator in nomenclator
				else
				{
					//se verifica procentul de inflatie care nu poate fi zero
					//daca procentul are valoarea zero utilizatorul va primi un mesaj de avertizare
					Salaries.Business.VariabileGlobaleValori variabila = new Salaries.Business.VariabileGlobaleValori();
					if (!variabila.VerificaProcentInflatie(lunaData.LunaId))
					{
						Response.Write("<script> alert('Procentul de inflatie al acestei luni este zero. \\nNu se poate efectua inchiderea de luna. Va rugam modificati acest procent!'); </script>");
					}
					//daca si proncetul de inflatie este corect
					else
					{
						//se verifica variabilele de salarizare care nu trebuie sa aiba valoarea zero
						//daca exista o variabila cu valoarea zero, utilizatorul va primi un mesaj de avertizare
						if (!VerificaVariabileSalarizare(lunaData.LunaId))
						{
							Response.Write("<script> alert('Pentru aceasta luna exista variabile de salarizare cu valoarea zero. \\nNu se poate efectua inchiderea de luna. Va rugam modificati aceste valori!'); </script>");
						}
						//daca si variabilele de salarizare sunt corecte, atunci se va efectua inchiderea de luna
						else
						{
							//Modificat:	Oprescu Claudia
							//Data:			08.03.2007
							//Descriere:	Nu se mai sterg intervalele angajatului din pontaj
							//StergeToateIntervaleleOrareSetateDeleted();
							
							
							SituatieLunaraTotiAngajatii();
							//MODIFIED: Ionel Popa ... 16.08.2005
							//DESCRIPTION: Angajatii carora le expira contractul in luna curenta NU trebuie dezactivati automat la inchiderea lunii
							//SetareExpirareContractLunaInactiv();
							new Salaries.Business.Luni(this.GetAngajator()).InchideLunaActiva();

							//generam situatia lunara pentru angajatorul activ
							//operatia se executa dupa calculul salariilor pentru ca situatia angajatorului se bazeaza pe contributiile individuala ale angajatilor
							SituatieLunaraAngajator();
			
							lunaData = luni.GetLunaActiva();
							luni.FillZileLuna( lunaData.Data.Month, lunaData.Data.Year );

							this.SetCurrentMonth( lunaData.LunaId );
					
							Response.Redirect( "Salarii.aspx?Tab=Pontaj&Option=initializare_luna", true );
						}
					}
				}
			}
		}
		#endregion
		
		#region CalculSalarii_Click
		/// <summary>
		/// Calculeaza salarii pentru luna activa
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalculSalarii_Click(object sender, System.EventArgs e)
		{
			string a = Session["ModificaSituatie"].ToString();
			string b = a;
			//daca s-a facut modificare de situatile lunare nu se apeleaza algoritmul de calcul salarii
			//si se face redirectare la pagina cu situatia lunara a angajatului
			if (Session["ModificaSituatie"].ToString() == "")
			{
				Salaries.Business.NomenclatorConcediiMedicale concedii = new Salaries.Business.NomenclatorConcediiMedicale();
				DataSet ds = concedii.GetConcediiMedicale();

				if (ds.Tables[0].Rows.Count > 0)
				{
					//generam situatia lunara pentru toti angajatii
					SituatieLunaraTotiAngajatii();

					//calculam salariile angajatilor
					new Salaries.Business.Luni(this.GetAngajator()).SalariiLunaActiva();

					//generam situatia lunara pentru angajatorul activ
					//operatia se executa dupa calculul salariilor pentru ca situatia angajatorului se bazeaza pe contributiile individuala ale angajatilor
					try
					{
						SituatieLunaraAngajator();
					}
					catch{}
				}
				else
				{
					Response.Write("<script> alert('Nomenclatorul pentru criterii de acordare a concediului medical este gol. \\nNu se poate efectua calculul salarial. Va rugam specificati valori pentru acest criteriu!'); </script>");
				}
			}
			else
			{
				//se face redirectare la pagina cu situatia lunara a angajatului
				Session["ModificaSituatie"] = "";
				Response.Redirect("Salarii.aspx?Tab=Pontaj&Option=situatie_lunara");
			}
		}
		#endregion

		#region btnRedeschidereLuna_Click
		/// <summary>
		/// Este realizata redeschiderea lunii precedente lunii active.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// Autor: Cristina Muntean
		/// Data:  13.12.2006
		/// </remarks>
		private void btnRedeschidereLuna_Click(object sender, System.EventArgs e)
		{
			int redeschidereValida;

			Salaries.Business.Luni luni = new Salaries.Business.Luni(this.GetAngajator());
			Salaries.Data.LunaData lunaData = luni.GetLunaActiva();
			
			// Se poate efectua o redeschidere de luna numai daca exista cel putin doua luni in sistem.
			if (luni.GetLuni().Tables[0].Rows.Count > 1)
			{
				// Este efectiata redeschiderea de luna.
				redeschidereValida = luni.RedeschidereLunaPrecedenta();
			
				BindComboLstLuni( luni );
				this.SetCurrentMonth(int.Parse(this.lstLuni.SelectedValue));
				this.CalculSalarii.Attributes["onclick"]="CancelValidation();return -1;";

				if (redeschidereValida != 0)
				{
					Response.Write("<script>alert('Va rugam sa repetati actiunea!')</script>");
				}
				else
				{
					Response.Write("<script>alert('Redeschiderea a fost realizata cu succes!')</script>");
				}
			}
			else
			{
				Response.Write("<script>alert('Luna activa este ultima luna din sistem! Nu se poate efectua o redeschidere de luna!')</script>");
			}
		}
		#endregion

		#region SituatieLunaraAngajator
		/// <summary>
		/// Genereaza sitatia lunara pentru un anumit angajator
		/// </summary>
		private void SituatieLunaraAngajator()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			new Salaries.Business.SituatieLunaraAngajator(this.GetAngajator(), settings.ConnectionString).GenerareSituatieLunaraAngajator(this.GetCurrentMonth());
		}
		#endregion

		#region SituatieLunaraTotiAngajatii
		/// <summary>
		/// Genereaza situatia lunara pentru toti angajatii
		/// </summary>
		private void SituatieLunaraTotiAngajatii()
		{
			SiemensTM.Classes.SituatieAngajat situatieLunaraAng;
			//Modificat:Muntean Raluca Cristina  - am adaugat ca parametru si id-ul angajatorului
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.CategorieId = -1;
			angajat.AngajatorId = GetAngajator();
			DataSet ds = angajat.GetAllAngajati();
			foreach( DataRow dr in ds.Tables[ 0 ].Rows )
			{
				//Modified: Cristina Raluca Muntean
				//se genereaza situatia lunara a unui angajat
				//se apeleaza aceasta metoda pentru ca in cazul in care nu a fost initializata luna, sa se faca si aceasta operatie
				situatieLunaraAng = new SiemensTM.Classes.SituatieAngajat(long.Parse( dr[ "AngajatID" ].ToString()));
				situatieLunaraAng.GenerareSituatieLunaraAngajat();
			}
		}
		#endregion

		#region SetareExpirareContractLunaInactiv
		/// <summary>
		/// Seteaza angajatii carora le expira contractul in luna activa
		/// </summary>
		private void SetareExpirareContractLunaInactiv()
		{
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.AngajatorId = GetAngajator();
			angajat.SetetazaAngajatiLunaInactivi();
		}
		#endregion

		#region StergeToateIntervaleleOrareSetateDeleted
		/// <summary>
		/// Sterge toate intervalele orare setate
		/// </summary>
		private void StergeToateIntervaleleOrareSetateDeleted()
		{
			new SiemensTM.Classes.IntervaleAngajat( -1 ).DeleteDefinitivIntervaleAngajatPerioadaTemporare();
		}
		#endregion	
	}
}
