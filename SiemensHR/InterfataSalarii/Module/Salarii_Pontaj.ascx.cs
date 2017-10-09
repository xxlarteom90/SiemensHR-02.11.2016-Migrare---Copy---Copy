using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensHR.utils;
using SiemensHR.Classes;
using SiemensHR.InterfataSalarii.Module.Pontaj;
using Salaries.Business;
using Salaries.Data;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for Salarii_Administrare.
	/// </summary>
	public class Salarii_Pontaj : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.DropDownList angajatDDL;
		protected System.Web.UI.WebControls.Label labelAngajatCurent;
		protected System.Web.UI.HtmlControls.HtmlInputButton ButtonGenerareSituatieLunaraAngajat;
		protected System.Web.UI.HtmlControls.HtmlInputButton ButtonGenerareSituatieLunaraTotiAngajatii;
		protected System.Web.UI.HtmlControls.HtmlTableCell Center;
		protected Salaries.Configuration.ModuleSettings settings;	
		public string actionGenerareSituatieLunara = "";
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			actionGenerareSituatieLunara = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ActionGenerareSituatieLunaraValue" )).Value; 
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			if (this.Page.Request.Params["idAng"] != null)
			{
				this.SetAngajat( long.Parse(this.Page.Request.Params["idAng"] ));
				Session["AngajatID"] = long.Parse(this.Page.Request.Params["idAng"]);
				string cale = Request.Url.AbsoluteUri;
				int poz1 = cale.IndexOf("Salarii.aspx");
				int poz2 = cale.IndexOf("&idAng=");
				string caleFinala = cale.Substring(poz1, poz2-poz1);
				Response.Redirect(caleFinala);
				//Response.Redirect("Salarii.aspx?Tab=Pontaj&Option=retineri_recurente_angajat&node=Element_025");
			}

			UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);
			utilDb.CreateAngajatiSelectBoxPeLuna( this.angajatDDL,this.GetAngajator(), this.GetCurrentMonth());
			try
			{
				this.angajatDDL.SelectedValue = this.GetAngajat().ToString();
			}
			catch
			{
				if (this.angajatDDL.Items.Count > 0)
				{
					this.SetAngajat( long.Parse(this.angajatDDL.SelectedValue ));
				}
			}
		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			GenerareaSituatieiLunare();

			string Option = this.Page.Request.Params["Option"];		
			
			if (Option==null) Option="situatie_lunara";

			switch (Option)
			{
				
				case "situatie_lunara":
					EnableAngajatCurent( true );
					//Se actualizeaza variabila care specifica modificarea situatiei lunare a unui angajat
					Session["ModificaSituatie"] = "";
					SituatieLunaraAngajati mySituatie = (SituatieLunaraAngajati) LoadControl("SituatieLunaraAngajati.ascx");
					this.Center.Controls.Add(mySituatie);
					break;
				case "initializare_luna":
					//luna activa a angajatorului
					Salaries.Business.Luni luni = new Salaries.Business.Luni(this.GetAngajator());
					Salaries.Data.LunaData lunaData = luni.GetLunaActiva();	

					//daca luna selectata de utilizator este luna activa atunci link-ul este activ, altfel acesta devine inactiv
					if(this.GetCurrentMonth() == lunaData.LunaId)
					{
						EnableAngajatCurent( false );
						InitializareLuna myInit = (InitializareLuna) LoadControl("InitializareLuna.ascx");
						this.Center.Controls.Add(myInit);
					}
					else
					{
						Response.Write("<script>alert(\"Luna selectata este inactiva! \\nInitializarea se poate face doar in luna activa! \");</script>");
						
						EnableAngajatCurent( true );
						SituatieLunaraAngajati mySituatie1 = (SituatieLunaraAngajati) LoadControl("SituatieLunaraAngajati.ascx");
						this.Center.Controls.Add(mySituatie1);
					}
					break;
				case "pontaj_individual":
					EnableAngajatCurent( true );
					PontajModule myPontaj = (PontajModule) LoadControl("Pontaj/PontajModule.ascx");
					myPontaj.AngajatorID = this.GetAngajator();
					myPontaj.CurrentMonthID = this.GetCurrentMonth();
					this.Center.Controls.Add(myPontaj);
					break;
				case "lichidare_angajat":					
					try
					{		
						//luna activa a angajatorului
						Salaries.Business.Luni luna = new Salaries.Business.Luni(this.GetAngajator());
						Salaries.Data.LunaData lunaActiva = luna.GetLunaActiva();	

						//daca luna selectata de utilizator este luna activa atunci link-ul este activ, altfel acesta devine inactiv
						if(this.GetCurrentMonth() == lunaActiva.LunaId)
						{
							Salaries.Business.Angajat objAngajat = new Salaries.Business.Angajat();
							objAngajat.AngajatId = GetAngajat();
							objAngajat.LoadAngajat();

							EnableAngajatCurent( true );
							LichidareAngajat lichidare = (LichidareAngajat) LoadControl("LichidareAngajat.ascx");
							lichidare.objAngajat = objAngajat;
							this.Center.Controls.Add(lichidare);
						}
						else
						{
							Response.Write("<script>alert(\"Luna selectata este inactiva! \\nUn angajat poate fi lichidat numai in luna activa! \");</script>");
						
							EnableAngajatCurent( true );
							SituatieLunaraAngajati mySituatie1 = (SituatieLunaraAngajati) LoadControl("SituatieLunaraAngajati.ascx");
							this.Center.Controls.Add(mySituatie1);
						}
					}
					catch(Exception ex)
					{
						Response.Write("Error loading employee data: <br>");
						Response.Write(ex.Message);
						Response.End();
					}
					break;
				case "retineri_recurente_angajat":
					EnableAngajatCurent( true );
					RetineriAngajat myRetineri = (RetineriAngajat) LoadControl( "RetineriAngajat.ascx" );
					myRetineri.AngajatID = GetAngajat();
					this.Center.Controls.Add( myRetineri );
					break;
				case "import":
					EnableAngajatCurent( false );
					ImportPontaj myImport = (ImportPontaj) LoadControl("ImportPontaj.ascx");
					this.Center.Controls.Add(myImport);
					break;
				case "import_delegatii":
					EnableAngajatCurent( false );
					ImportDelegatii importDel = (ImportDelegatii) LoadControl("ImportDelegatii.ascx");
					this.Center.Controls.Add(importDel);
					break;
				case "trimitere_fluturasi":
					EnableAngajatCurent( false );
					TrimitereFluturasi trimFlut = (TrimitereFluturasi) LoadControl("TrimitereFluturasi.ascx");
					this.Center.Controls.Add(trimFlut);
					break;
				case "sincronizare_date_angajati":
					EnableAngajatCurent( false );
					SincronizareDateAngajati sinc = (SincronizareDateAngajati) LoadControl("SincronizareDateAngajati.ascx");
					//ImportSalarii myImport = (ImportSalarii) LoadControl("ImportSalarii.ascx");
					this.Center.Controls.Add(sinc);
					break;
			}

			//poate strica
			//Modificat:	Oprescu Claudia
			//Descriere:	Se seteaza un angajat numai daca exista in control date
			if (this.angajatDDL.Items.Count > 0)
			{
				this.SetAngajat( long.Parse( angajatDDL.SelectedValue ));
				
				// Se calculeaza valoarea mediei zilnice si se scrie valoarea pe Javascript.
				CalculMedieZilnicaConcediuOdihna();
			}	
		}
		#endregion

		#region GenerareaSituatieiLunare
		/// <summary>
		/// Genereaza situatia lunara
		/// </summary>
		private void GenerareaSituatieiLunare()
		{
			SiemensTM.Classes.SituatieAngajat situatieLunaraAng;

			switch( actionGenerareSituatieLunara )
			{
				case "generareSituatieLunaraAngajat" :
					//Modified: Cristina Raluca Muntean
					//se genereaza situatia lunara a unui angajat
					//se apeleaza aceasta metoda pentru ca in cazul in care nu a fost initializata luna, sa se faca si aceasta operatie
					situatieLunaraAng = new SiemensTM.Classes.SituatieAngajat(this.GetAngajat());
					situatieLunaraAng.GenerareSituatieLunaraAngajat();

					//Oprescu Claudia
					//se face redirectare la pagina cu situatia unui angajat
					Response.Redirect("Salarii.aspx?Tab=Pontaj&Option=situatie_lunara");
					break;

				case "generareSituatieLunaraTotiAngajatii" :
					//Modificat:Muntean Raluca Cristina  - am adaugat ca parametru si id-ul angajatorului
					Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
					angajat.AngajatorId = GetAngajator();
					angajat.CategorieId = -1;
					DataSet ds = angajat.GetAllAngajati();
					foreach( DataRow dr in ds.Tables[ 0 ].Rows )
					{
						//Modified: Cristina Raluca Muntean
						//se genereaza situatia lunara a unui angajat
						//se apeleaza aceasta metoda pentru ca in cazul in care nu a fost initializata luna, sa se faca si aceasta operatie
						situatieLunaraAng = new SiemensTM.Classes.SituatieAngajat(long.Parse( dr[ "AngajatID" ].ToString()));
						situatieLunaraAng.GenerareSituatieLunaraAngajat();
					}
					break;
				default:
					break;
			}
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ActionGenerareSituatieLunaraValue" )).Value = "";
		}
		#endregion

		#region EnableAngajatCurent
		/// <summary>
		/// Afiseaza butoanele pentru genrearea situatiilor lunare in functie de luna activa
		/// </summary>
		/// <param name="val">Se afiseaza butoanele sau nu</param>
		private void EnableAngajatCurent( bool val )
		{
			this.angajatDDL.Visible = val;
			this.labelAngajatCurent.Visible = val;
			this.ButtonGenerareSituatieLunaraAngajat.Visible = val;
			this.ButtonGenerareSituatieLunaraTotiAngajatii.Visible = val;

			Salaries.Business.Luni luni = new Salaries.Business.Luni(this.GetAngajator());
			Salaries.Data.LunaData lunaData = luni.GetLunaActiva();			
			if( lunaData.LunaId!=-1 && val )
			{
				this.ButtonGenerareSituatieLunaraAngajat.Visible =  this.GetCurrentMonth() == lunaData.LunaId;
				this.ButtonGenerareSituatieLunaraTotiAngajatii.Visible = this.GetCurrentMonth()==lunaData.LunaId;
			}
		}
		#endregion

		#region CalculMedieZilnicaConcediuOdihna
		/// <summary>
		/// Se calculeaza media zilnica a concediului de odihna a angajatului, in cazul in care sunt
		/// suficiente date in baza de date si este scrisa valoarea pe Javascript.
		/// </summary>
		/// <remarks>
		/// Autor: Cristina Muntean
		/// Data:  14.03.2006
		/// </remarks>
		private void CalculMedieZilnicaConcediuOdihna()
		{
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.AngajatId = GetAngajat();
			// ID-ul lunii curente
			int lunaID = this.GetCurrentMonth();
			// Media zilnica aferenta concediului de odihna al angajatului.
			
			double medieZilnicaConcediuOdihna = 0;
			// Media zilnica aferenta concediului de boala al angajatului.
			//double medieZilnicaConcediuBoala = 0;
			//double medieZilnicaContinuareConcediuBoala = 0;
			
			//Modificat:	Lungu Andreea
			//Data:			12.09.2008
			//Descriere:	Se calculeaza ci media zilnica a continuarii concediului medical pentru ca 
			// aceasta nu coincide cu media zilnica a concediului medical calculata pentru luna corespunzatoare.
			medieZilnicaConcediuOdihna = angajat.GetMedieZilnicaConcediuDeOdihna(lunaID);
			//double medieZilnicaConcediuBoala = angajat.GetMedieZilnicaConcediuDeBoala(lunaID);
			//double medieZilnicaContinuareConcediuBoala = angajat.GetMedieZilnicaContinuareConcediuDeBoala(lunaID);
		
            // Este scrisa variabila pe javascript
		
			Response.Write("<script>  var medieZilnicaCO = '" + medieZilnicaConcediuOdihna + "'; </script>");
			//Response.Write("<script>  var medieZilnicaCB = '" + medieZilnicaConcediuBoala + "'; </script>");
			//Response.Write("<script>  var medieZilnicaCCB = '" + medieZilnicaContinuareConcediuBoala + "'; </script>");
			
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
			this.angajatDDL.SelectedIndexChanged += new System.EventHandler(this.angajatDDL_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region angajatDDL_SelectedIndexChanged
		/// <summary>
		/// La selectarea unui angajat se seteaza ID-ul angajatului curent.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void angajatDDL_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Este setat ID-ul angajatului curent.
			this.SetAngajat( long.Parse(this.angajatDDL.SelectedValue ));

			//Modificat: Oprescu Claudia
			//Descriere: Se retine intr-o variabila de sesiune id-ul angajatului selectat
			Session["AngajatID"] = long.Parse(this.angajatDDL.SelectedValue);
		}
		#endregion
	}
}
