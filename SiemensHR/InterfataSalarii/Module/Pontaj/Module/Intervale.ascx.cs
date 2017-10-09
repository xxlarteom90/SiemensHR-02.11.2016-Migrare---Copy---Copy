/*
 * Modificat:	Lungu Andreea
 * Data:		18.12.2009
 * Descriere:	A fost adaugat log. 
 */ 

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

using Salaries.Business;
using SiemensTM.utils;
using SiemensTM.Classes;

namespace SiemensTM.Module
{
	/// <summary>
	///		Summary description for Intervale.
	///		
	///		Modificat:	Oprescu Claudia
	///		Descriere:	S-au modificat aceste metode pentru a putea primi ca si parametrii si cele doua campuri pentru serie si numar
	/// </summary>
	public class Intervale: ModuleLogin
	{
		#region Variabile
		protected System.Web.UI.HtmlControls.HtmlTableCell Title;
		public DateTime SelectedDate;
		public long AngajatID;
		protected System.Web.UI.HtmlControls.HtmlTableCell ControlVizibil;
		protected System.Web.UI.HtmlControls.HtmlTableCell AddLine;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		protected System.Web.UI.HtmlControls.HtmlTableCell SaveLine;
		protected System.Web.UI.HtmlControls.HtmlInputHidden actionIntervale1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden IntervaleSaveInfoID1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden IntervaleAbsenteSaveInfoID1;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button2;
		protected System.Web.UI.HtmlControls.HtmlTableCell IntervaleExistenteLucrate;
		protected bool CreateIntervale = true;
		protected Interval AddInterval;
		protected IntervalAbsente AddIntervalAbsente;
		protected IntervalIntreruperiContract AddIntervalIntreruperi;
		protected System.Web.UI.HtmlControls.HtmlSelect selectTipPontaj;
		protected System.Web.UI.HtmlControls.HtmlTableCell IntervaleExistenteIntreruperi;
		protected System.Web.UI.HtmlControls.HtmlTableCell IntervaleExistente;
		protected System.Web.UI.HtmlControls.HtmlInputButton Salveaza;
		protected System.Web.UI.HtmlControls.HtmlTable tableBut;
		protected System.Web.UI.HtmlControls.HtmlTableCell OreSuplimentareLucrate;
		protected string tipPontaj;
		protected Salaries.Configuration.ModuleSettings settings;
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
			this.ID = "AddLine";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Create and initialize methods

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{		
			this.selectTipPontaj.Attributes["SelectedIndexChanged"] = "getInterval('"+this.ClientID+"').OraStartChanged()";
			actionIntervale1 = (System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "actionIntervale" );
			IntervaleSaveInfoID1 = (System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "IntervaleSaveInfoID" );
			IntervaleAbsenteSaveInfoID1 = (System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "IntervaleAbsenteSaveInfoID" );

			if( !IsPostBack )
			{
				FillTipPontajSelect();
			}
			CreazaVariabilaJSTipAbsente();
		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			settings = Salaries.Configuration.ModuleConfig.GetSettings();

			this.AngajatID = this.GetLoggedUserID();
			if( !IsPostBack )
			{
				CreazaSirTipuriOreSuplimentareJS();
			}			
			
			this.HandleActions();
			tipPontaj = (( System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ClientTipPontajHidden" )).Value;
			
			if( tipPontaj == Definitions.tipuriPontaje[ 0 ] )
			{
				EnableControls( 0 );
				CreateIntervaleOreSuplimentare();
				selectTipPontaj.Value = tipPontaj;
			}
			else
			{
				if( tipPontaj == Definitions.tipuriPontaje[ 1 ] )
				{
					EnableControls( 1 );
					selectTipPontaj.Value = tipPontaj;
					CreateIntervaleAbsenteExistente();
				}
				else 
				{
					if( tipPontaj == Definitions.tipuriPontaje[ 2 ] )
					{
						EnableControls( 2 );
						CreateIntreruperiContracteMuncaExistente();
						selectTipPontaj.Value = tipPontaj;
					}
					//default
					else 
					{
						if( tipPontaj == "" )
						{
							EnableControls( 0 );
							(( System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ClientTipPontajHidden" )).Value = selectTipPontaj.Value;
							CreateIntervaleOreSuplimentare();
						}
					}
				}
			}
			#region Scrie variabile JS pentru validare absente	
			
			int LunaActivaID = int.Parse(Session[SiemensHR.InterfataSalarii.Classes.Definitions.LunaCurentaKey].ToString());
			int AngajatorID = int.Parse(Session[SiemensHR.InterfataSalarii.Classes.Definitions.AngajatorKey].ToString());
			Salaries.Business.Luni l = new Salaries.Business.Luni(AngajatorID,LunaActivaID);

			Salaries.Business.Angajat objAngajat = new Salaries.Business.Angajat();
			objAngajat.AngajatId = GetLoggedAngajat().AngajatId;
			objAngajat.LoadAngajat();
			AngajatID = GetLoggedAngajat().AngajatId;
			
			/*
			 * Modified:   Cristina Raluca Muntean
			 * Date:       15.09.2005
			 * Description:Pentru a nu se permite introducerea unui tip de absenta cand angajatul este lichidat, 
			 * este obtinuta data lichidarii si scrisa pe javascript pentru a se putea face validarile.
			 */
			string dataLichidare;
			if((DateTime.Equals(objAngajat.DataLichidare, System.DBNull.Value)) || (DateTime.Equals(objAngajat.DataLichidare,DateTime.MinValue)))
				dataLichidare = DateTime.MaxValue.ToString("dd.MM.yyyy");
			else
				dataLichidare = objAngajat.DataLichidare.ToString("dd.MM.yyyy");
			Response.Write("<script>DataLichidare =  '"+dataLichidare+"'</script>");
			
			DateTime DataAngajare = objAngajat.DataDeLa;

			Response.Write("<script>LunaActivaDataStart =  '"+l.GetLunaActiva().Data.ToString("dd.MM.yyyy")+"'</script>");			
			Response.Write("<script>AngajareDataStart =  '"+DataAngajare.ToString("dd.MM.yyyy")+"'</script>");
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.AngajatId = GetAngajat();

			//Modificat:	Oprescu Claudia
			//Descriere:	Se apeleaza metoda pentru actualizarea valorii mediei zilnice pentru concediul de boala
			// Media zilnica aferenta concediului de boala al angajatului.
			double medieZilnicaConcediuBoala = 0;
			double medieZilnicaContinuareConcediuBoala = 0;
			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.AngajatId = GetLoggedAngajat().AngajatId;

			//Modificat:	Lungu Andreea
			//Data:			12.09.2008
			//Descriere:	Se calculeaza ci media zilnica a continuarii concediului medical pentru ca 
			// aceasta nu coincide cu media zilnica a concediului medical calculata pentru luna corespunzatoare.
			medieZilnicaConcediuBoala = ang.GetMedieZilnicaConcediuDeBoala(LunaActivaID);
			medieZilnicaContinuareConcediuBoala = angajat.GetMedieZilnicaContinuareConcediuDeBoala(LunaActivaID);
			Response.Write("<script>  var medieZilnicaCB = '" + medieZilnicaConcediuBoala + "'; </script>");	
			Response.Write("<script>  var medieZilnicaCCB = '" + medieZilnicaContinuareConcediuBoala + "'; </script>");	

			
			//Adaugat:		Oprescu Claudia
			//Data:			22.02.2007
			//Descriere:	Se determina numarul de zile de concediu de odihna corespunzatoare angajatului
			Salaries.Business.Luni luna = new Salaries.Business.Luni(objAngajat.AngajatorId);
			Salaries.Business.PontajAngajat pontajAngajat = new Salaries.Business.PontajAngajat(AngajatID);
			DateTime primaZiAn = new DateTime( luna.GetLunaActiva().Data.Year , 1, 1 );
			DateTime ultimaZiAn = new DateTime( luna.GetLunaActiva().Data.Year, 12, 31 );
			//numarul de zile de CO disponibile pe an ale angajatului
			int nrZileDisponibile = pontajAngajat.GetAngajatNrZileCODisponibileAn( primaZiAn, ultimaZiAn, objAngajat.AngajatorId);
			//numarul de zile de CO suplimentare pe an ale angajatului
			int nrZileCOSupl = objAngajat.NrZileCOSupl;
			//numarul de zile de CO luate de angajat inaintea lunii active
			int nrZileLuateAn = pontajAngajat.GetAngajatNrZileCOLuateAn( primaZiAn, luna.GetLunaActiva().Data.AddDays(-1), -1);
			//numarul de zile de CO luate pe luna activa
			int nrZileConcediuNou = 0;
			//id-ul concediului de odihna
			int concediuOdihnaID = new utils.UtilitiesDb(settings.ConnectionString).GetConcediuOdihnaID();
			Response.Write( "<script> var nrZileDisponibile = " + nrZileDisponibile + "; </script>" );
			Response.Write( "<script> var nrZileCOSupl = " + nrZileCOSupl + "; </script>" );
			Response.Write( "<script> var nrZileLuateAn = " + nrZileLuateAn + "; </script>" );
			Response.Write( "<script> var nrZileConcediuNou = " + nrZileConcediuNou + "; </script>" );
			Response.Write( "<script> var zileSarbatoare = " + GetZileSarbatoare(luna.GetLunaActiva().Data, pontajAngajat) + "; </script>" );
			Response.Write( "<script> var concediuOdihnaID = " + concediuOdihnaID + "; </script>" );
			#endregion
		}
		#endregion

		#region Render
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render (writer);
			Response.Write("<script>var ClientTipPontaj = '"+this.selectTipPontaj.ClientID+"';</script>");
			Response.Write("<script>var ClientInterval = '"+this.AddInterval.ClientID+"';</script>");
			Response.Write("<script>var ClientIntervalAbsente = '"+this.AddIntervalAbsente.ClientID+"';</script>");
			Response.Write("<script>var ClientIntervalIntreruperi = '"+this.AddIntervalIntreruperi.ClientID+"';</script>");
		}
		#endregion

		#region GetZileSarbatoare
		/// <summary>
		/// Procedura scrie pe javascript zilele lucratoare ale lunii active
		/// </summary>
		/// <param name="luna">Luna activa</param>
		/// <param name="pontaj">Pontaj angajatului curent</param>
		/// <returns>Retruneaza un string care contine zirul zilelor lucratoare ale lunii active</returns>
		/// <remarks>
		/// Autor:		Oprescu Claudia
		/// Data:		22.02.2007
		/// </remarks>
		private string GetZileSarbatoare(DateTime luna, PontajAngajat pontaj)
		{
			string sirZileSarbatoare = "";
			
			DataSet dsZile = (DataSet)pontaj.GetAllZileLucratoareLuna(luna);
			if (dsZile.Tables[ 0 ].Rows. Count > 0)
			{
				sirZileSarbatoare = "[";
				for( int i=0; i<dsZile.Tables[ 0 ].Rows.Count-1; i++ )
				{
					DataRow dr = dsZile.Tables[ 0 ].Rows[ i ];
					sirZileSarbatoare += dr[ "Zi" ].ToString()+", ";
				}
				sirZileSarbatoare += dsZile.Tables[ 0 ].Rows[ dsZile.Tables[ 0 ].Rows.Count-1 ][ "Zi" ].ToString()+"]";
			}
			if( sirZileSarbatoare == "" )
			{
				sirZileSarbatoare += "[]";
			}
			return sirZileSarbatoare;
		}
		#endregion

		#region CreazaSirTipuriOreSuplimentareJS
		/// <summary>
		/// Creaza sirul de variabile JavaScript pentru ore suplimentare
		/// </summary>
		private void CreazaSirTipuriOreSuplimentareJS()
		{
			string tipOreSuplimentare = "";
			try
			{
				IntervaleAngajat ia = new IntervaleAngajat(this.AngajatID);
				DataSet ds = ia.GetTipuriIntervaleOreSuplimentare();

				string tipOreSuplimentareText = "";
				string tipOreSuplimentareID = "";
				string tipOreSuplimentareWeekendNoapte = "";
				string tipOreSuplimentareNrOre = "";
				DateTime dataSt = new DateTime( this.SelectedDate.Year, this.SelectedDate.Month, 1 );
				DateTime dataEnd = new DateTime( this.SelectedDate.Year, this.SelectedDate.Month, DateTime.DaysInMonth( this.SelectedDate.Year, this.SelectedDate.Month ));

				foreach( DataRow dr in ds.Tables[ 0 ].Rows )
				{
					tipOreSuplimentareID += dr[ "TipIntervalID" ].ToString()+",";
					tipOreSuplimentareText += "'"+dr[ "Denumire" ].ToString()+"',";
					if( !Convert.IsDBNull(dr["AplicWeekendNoapte"]))
					{
						tipOreSuplimentareWeekendNoapte += (bool)dr[ "AplicWeekendNoapte" ] ? "1," : "0,";
					}
					else
					{
						tipOreSuplimentareWeekendNoapte += "0,";
					}

					double nrOreLucrateTip = new IntervaleAngajat( this.AngajatID ).GetNrOreLucratePerioadaTip( dataSt, dataEnd, int.Parse( dr[ "TipIntervalID" ].ToString()));
					tipOreSuplimentareNrOre += nrOreLucrateTip.ToString().Replace( ",", "." )+",";
				}
				tipOreSuplimentareText = tipOreSuplimentareText.Substring( 0, tipOreSuplimentareText.Length-1 );
				tipOreSuplimentareID = tipOreSuplimentareID.Substring( 0, tipOreSuplimentareID.Length-1 );
				tipOreSuplimentareWeekendNoapte = tipOreSuplimentareWeekendNoapte.Substring( 0, tipOreSuplimentareWeekendNoapte.Length-1 );
				tipOreSuplimentareNrOre = tipOreSuplimentareNrOre.Substring( 0, tipOreSuplimentareNrOre.Length-1 );
				tipOreSuplimentare = "[["+tipOreSuplimentareID+"],["+tipOreSuplimentareWeekendNoapte+"],["+tipOreSuplimentareNrOre+"]]";
			}
			catch
			{
				tipOreSuplimentare = "[[][][]]";
			}
			Response.Write( "<script>var dateOreSuplimentare = "+tipOreSuplimentare+";</script>" );
		}
		#endregion

		#region DeleteElementsUnusableFromTipIntervalAngajatCombo
		/// <summary>
		/// Sterge intervale
		/// </summary>
		private void DeleteElementsUnusableFromTipIntervalAngajatCombo()
		{
			IntervaleAngajat ia = new IntervaleAngajat(this.AngajatID);
			DataSet ds = ia.GetTipuriIntervaleFolosire();
			
			for( int i=0; i<ds.Tables[ 0 ].Rows.Count; i++ )
			{
				ListItem li = this.AddInterval.TipInterval.Items.FindByValue( ds.Tables[ 0 ].Rows[ i ][ "TipintervalID" ].ToString());
				this.AddInterval.TipInterval.Items.Remove( li );
			}
		}
		#endregion

		#region FillTipPontajSelect
		/// <summary>
		/// Umplerea drop down list-ului cu tipurile de pontaje
		/// </summary>
		private void FillTipPontajSelect()
		{
			for( int i = 0; i < Definitions.tipuriPontaje.Length; i++ )
			{
				selectTipPontaj.Items.Add( new ListItem( Definitions.tipuriPontajeText[ i ], Definitions.tipuriPontaje[ i ] ));
			}
		}
		#endregion

		#region CreazaVariabilaJSTipAbsente
		/// <summary>
		/// Creaza o variabila JavaScript cu toate id-urile tipurilor de absente considerate ca fiind medicale
		/// </summary>
		private void CreazaVariabilaJSTipAbsente()
		{
			IntervaleAngajat ia = new IntervaleAngajat(this.AngajatID);
			DataSet ds = ia.GetTipuriAbsenteMedicale();
			
			string variabila = "<script>var TipAbsenteMedical = [" ;
			foreach( DataRow dr in ds.Tables[ 0 ].Rows )
			{
				variabila += dr[ "TipAbsentaID" ].ToString()+",";
			}
			if( variabila[ variabila.Length-1 ] != '[' )
			{
				variabila = variabila.Substring( 0, variabila.Length-1 );
			}
			variabila += "];</script>";
			Response.Write( variabila );
		}
		#endregion

		#region EnableControls
		/// <summary>
		/// Sunt activate controalele in functie de operatia executata
		/// </summary>
		/// <param name="enable">Tipul operatiei</param>
		private void EnableControls( int enable )
		{
			switch( enable )
			{
				case 0: //pt intervale orare
					AddInterval.Visible = false;
					AddIntervalAbsente.Visible = false;
					AddIntervalIntreruperi.Visible = false;
					Button1.Visible = false;

					Button2.Visible = false;
					break;

				case 1: //pt intervale de absente
					AddInterval.Visible = false;
					AddIntervalAbsente.Visible = true;
					AddIntervalIntreruperi.Visible = false;
					Button1.Visible = true;

					Button2.Visible = true;

					break;
					
				case 2: //pt intreruperi contracte de munca
					AddInterval.Visible = false;
					AddIntervalAbsente.Visible = false;
					AddIntervalIntreruperi.Visible = true;
					Button1.Visible = true;

					Button2.Visible = true;
					break;

				default:
					break;
			}
		}
		#endregion

		#endregion

		#region Create user controls methods

		#region CreateIntervaleOreExistente
		/// <summary>
		/// Creaza controalele pt intervalele orare existente
		/// </summary>
		private void CreateIntervaleOreExistente()
		{
			this.Title.InnerHtml = "<font size=4>"+this.SelectedDate.DayOfWeek.ToString()+",&nbsp;"+this.SelectedDate.ToShortDateString()+"</font>";
			this.Title.Visible = true;
			
			IntervaleAngajat ia = new IntervaleAngajat(this.AngajatID);

			DataSet ds = ia.GetIntervaleAngajatZi(Utilities.ConvertToShort(this.SelectedDate));

			Table t_IntervaleExistente  = new Table();
			t_IntervaleExistente.Attributes["width"]="100%";
			t_IntervaleExistente.CellSpacing=1;
			t_IntervaleExistente.CellPadding=1;
			bool altern = false;
		
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
		
				int TipIntervalID = int.Parse(dr["TipIntervalID"].ToString());
				string OraStart = dr["OraStart"].ToString();
				string OraEnd = dr["OraEnd"].ToString();

				Interval tmp = (Interval) LoadControl("Interval.ascx");
				tmp.Selectable=true;
				tmp.OraStart.Value = Utilities.ConvertDateTimeToHour(DateTime.Parse(OraStart));
				tmp.OraEnd.Value = Utilities.ConvertDateTimeToHour(DateTime.Parse(OraEnd));
				tmp.TipIntervalID= TipIntervalID;
				
				tmp.ID = "Interval_"+dr["IntervalAngajatID"].ToString();
				tmp.IntervalID.Value = dr["IntervalAngajatID"].ToString();

				tmp.AngajatID = this.AngajatID;
				tmp.SelectedDate = Utilities.ConvertToShort( this.SelectedDate );

				TableRow tr = new TableRow();

				if (altern)
				{
					tr.BackColor=Definitions.Color_Altern;
				}
				altern=!altern;

				TableCell tc = new TableCell();
								
				tc.Controls.Add(tmp);
				tr.Cells.Add(tc);
				t_IntervaleExistente.Rows.Add(tr);

			}
		
			if (ds.Tables[0].Rows.Count>0)
			{
				this.IntervaleExistenteLucrate.Controls.Add(t_IntervaleExistente);

				tableBut.Visible = true;
			}
			else
			{
				tableBut.Visible = false;
			}
		}
		#endregion

		#region CreateIntervaleOreSuplimentare
		/// <summary>
		/// Creaza controalele pt tipurile de ore suplimentare existente
		/// </summary>
		private void CreateIntervaleOreSuplimentare()
		{
			this.Title.InnerHtml = "<font size=4>"+this.SelectedDate.DayOfWeek.ToString()+",&nbsp;"+this.SelectedDate.ToShortDateString()+"</font>";
			this.Title.Visible = true;
			
			IntervaleAngajat ia = new IntervaleAngajat(this.AngajatID);
			DataSet ds = ia.GetTipuriIntervaleOreSuplimentare();
			Table t_IntervaleExistente  = new Table();
			t_IntervaleExistente.Attributes["width"]="100%";
			t_IntervaleExistente.CellSpacing=1;
			t_IntervaleExistente.CellPadding=1;
			bool altern = false;
		
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				IntervalOreNestandard tmp = (IntervalOreNestandard) LoadControl( "IntervalOreNestandard.ascx" );
				tmp.tipIntervalID = int.Parse( dr[ "TipIntervalID" ].ToString());
				tmp.labelTipOreSuplimentare.Text = dr[ "Denumire" ].ToString();

				DateTime dataSt = new DateTime( this.SelectedDate.Year, this.SelectedDate.Month, 1 );
				DateTime dataEnd = new DateTime( this.SelectedDate.Year, this.SelectedDate.Month, DateTime.DaysInMonth( this.SelectedDate.Year, this.SelectedDate.Month ));
				tmp.txtNrOreSuplimentare.Text = ia.GetNrOreLucratePerioadaTip( dataSt, dataEnd, tmp.tipIntervalID ).ToString();

				TableRow tr = new TableRow();

				if (altern)
				{
					tr.BackColor=Definitions.Color_Altern;
				}
				altern=!altern;

				TableCell tc = new TableCell();
								
				tc.Controls.Add(tmp);
				tr.Cells.Add(tc);
				t_IntervaleExistente.Rows.Add(tr);
			}
		
			if (ds.Tables[0].Rows.Count>0)
			{
				this.IntervaleExistenteLucrate.Controls.Add(t_IntervaleExistente);
				tableBut.Visible = true;
			}
			else
			{
				tableBut.Visible = false;
			}
		}
		#endregion

		#region CreateIntervaleAbsenteExistente
		/// <summary>
		/// Creaza controale pt intervalele de absente existente
		/// </summary>
		private void CreateIntervaleAbsenteExistente()
		{
			this.Title.InnerHtml = "<font size=4>"+this.SelectedDate.DayOfWeek.ToString()+",&nbsp;"+this.SelectedDate.ToShortDateString()+"</font>";	
			IntervaleAbsenteAngajat iaa = new IntervaleAbsenteAngajat(this.AngajatID);
			DataSet ds = iaa.GetIntervaleAbsenteSiEmergencyAngajatLuna( Utilities.ConvertToShort( this.SelectedDate ));

			Table t_IntervaleAbsenteExistente  = new Table();
			t_IntervaleAbsenteExistente.Attributes["width"]="100%";
			t_IntervaleAbsenteExistente.CellSpacing=1;
			t_IntervaleAbsenteExistente.CellPadding=1;
			bool altern = false;
		
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
		
				int TipIntervalID = int.Parse(dr["TipAbsentaID"].ToString());
				string DataStart = dr["DataStart"].ToString();
				string DataEnd = dr["DataEnd"].ToString();
				string observ = dr[ "Observatii" ].ToString();
				int TipBoalaID = -1;
				if( dr[ "BoalaID" ].ToString() != ""  )
				{
					TipBoalaID = int.Parse( dr[ "BoalaID" ].ToString());
				}
				string medieZilnica = dr[ "MedieZilnica" ].ToString();

				IntervalAbsente tmp = (IntervalAbsente) LoadControl("IntervalAbsente.ascx");
				tmp.Selectable=true;
				char []spliter = new char[ 1 ];
				spliter[ 0 ] = ' ';
				DataStart = DataStart.Split( spliter, 2 )[ 0 ];
				DataEnd = DataEnd.Split( spliter, 2 )[ 0 ];
				tmp.DataStart.Value = DataStart;
				tmp.DataEnd.Value = DataEnd;
				tmp.TipIntervalID= TipIntervalID;
				tmp.TipBoalaID = TipBoalaID;
				tmp.textObservatii = observ;
				tmp.MedieZilnica.Value = medieZilnica;
				tmp.Serie.Value = dr["Serie"].ToString().TrimEnd();
				tmp.Numar.Value = dr["Numar"].ToString().TrimEnd();
				//----------Chiperescu Daniela 22.02.2011---------------------------------
				try
				{
					tmp.CertificatInitial.Value = Convert.ToBoolean(dr["EsteCertificat"])?"Da":"Nu";
				}
				catch(Exception)
				{
					tmp.CertificatInitial.Value = "";
				}
				tmp.SerieCertificat.Value = dr["SerieCertificatInitial"].ToString().TrimEnd();
				tmp.NumarCertificat.Value = dr["NumarCertificatInitial"].ToString().TrimEnd();
				try
				{
					tmp.DataAcordariiCertificat.Value = Convert.ToDateTime(dr["DataAcordariiCertificat"].ToString().TrimEnd()).ToString("dd.MM.yyyy");
				}
				catch(Exception)
				{
					tmp.DataAcordariiCertificat.Value = "";
				}
				tmp.CnpCopil.Value = dr["CnpCopil"].ToString().TrimEnd();
				tmp.LocPrescriereCertificat.Value = dr["LocPrescriereCertificat"].ToString().TrimEnd();
				tmp.CodUrgenta.Value = dr["CodUrgenta"].ToString().TrimEnd();
				tmp.NrAvizMedicExpert.Value = dr["NrAvizMedicExpert"].ToString().TrimEnd();
				//----------Chiperescu Daniela 22.02.2011---------------------------------
				tmp.LabelsVisible = false;
				tmp.ID = "IntervalAbsente_"+dr["IntervalAbsentaID"].ToString();
				tmp.IntervalID.Value = dr["IntervalAbsentaID"].ToString();

				TableRow tr = new TableRow();

				if (altern)
				{
					tr.BackColor=Definitions.Color_Altern;
				}
				altern=!altern;

				TableCell tc = new TableCell();

				tc.Controls.Add(tmp);
				tr.CssClass = "rowStyle";
				tr.Cells.Add(tc);
				t_IntervaleAbsenteExistente.Rows.Add(tr);

				if( dr != ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ] )
				{
					AdaugaLinieVida( t_IntervaleAbsenteExistente, !altern );
				}
			}
		
			if (ds.Tables[0].Rows.Count>0)
			{
				this.IntervaleExistente.Controls.Add(t_IntervaleAbsenteExistente);
				tableBut.Visible = true;
			}
			else
			{
				tableBut.Visible = false;
			}


		}
		#endregion

		#region CreateIntreruperiContracteMuncaExistente
		/// <summary>
		/// Creaza controale pt intervalele de absente existente
		/// </summary>
		private void CreateIntreruperiContracteMuncaExistente()
		{
			this.Title.InnerHtml = "<font size=4>"+this.SelectedDate.DayOfWeek.ToString()+",&nbsp;"+this.SelectedDate.ToShortDateString()+"</font>";
			IntervaleIntreruperiAngajat iia = new IntervaleIntreruperiAngajat(this.AngajatID);
			DataSet ds = iia.GetIntervaleIntreruperiAngajatLuna( Utilities.ConvertToShort( this.SelectedDate ));

			Table t_IntervaleIntreruperiExistente = new Table();
			t_IntervaleIntreruperiExistente.Attributes["width"]="100%";
			t_IntervaleIntreruperiExistente.CellSpacing=1;
			t_IntervaleIntreruperiExistente.CellPadding=1;
			bool altern = false;

			//Lungu Andreea - 12.11.2008
			int LunaActivaID = int.Parse(Session[SiemensHR.InterfataSalarii.Classes.Definitions.LunaCurentaKey].ToString());
			int AngajatorID = int.Parse(Session[SiemensHR.InterfataSalarii.Classes.Definitions.AngajatorKey].ToString());
			Salaries.Business.Luni l = new Salaries.Business.Luni(AngajatorID,LunaActivaID);
			DateTime dataLunaActiva = l.GetLunaActiva().Data;
		
			foreach (DataRow dr in ds.Tables[0].Rows)
			{
				string DataStart = dr["DataStart"].ToString();
				string DataEnd = dr["DataEnd"].ToString();
				string descriere = dr[ "Descriere" ].ToString();

				IntervalIntreruperiContract tmp = (IntervalIntreruperiContract) LoadControl("IntervalIntreruperiContract.ascx");
				tmp.Selectable=true;
				char []spliter = new char[ 1 ];
				spliter[ 0 ] = ' ';
				DataStart = DataStart.Split( spliter, 2 )[ 0 ];
				DataEnd = DataEnd.Split( spliter, 2 )[ 0 ];
				//Lungu Andreea - 12.11.2008
				DateTime dataSt = ((DateTime)dr["DataStart"]);
				if (( dataSt.Year < dataLunaActiva.Year) || 
					(( dataSt.Year == dataLunaActiva.Year) &&(dataSt.Month<dataLunaActiva.Month)))
					tmp.DataStart.Disabled = true;
				tmp.DataStart.Value = DataStart;
				tmp.DataEnd.Value = DataEnd;
				tmp.textObservatii = descriere;
				tmp.LabelsVisible = false;
				
				tmp.ID = "IntervalIntreruperiContract_"+dr["AngajatIntrerupereID"].ToString();
				tmp.IntervalID.Value = dr["AngajatIntrerupereID"].ToString();

				TableRow tr = new TableRow();

				if (altern)
				{
					tr.BackColor=Definitions.Color_Altern;
				}
				altern=!altern;

				TableCell tc = new TableCell();

				tc.Controls.Add(tmp);
				tr.CssClass = "rowStyle";
				tr.Cells.Add(tc);
				t_IntervaleIntreruperiExistente.Rows.Add(tr);

				if( dr != ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ] )
				{
					AdaugaLinieVida( t_IntervaleIntreruperiExistente, !altern );
				}

			}
		
			if (ds.Tables[0].Rows.Count>0)
			{
				this.IntervaleExistenteIntreruperi.Controls.Add(t_IntervaleIntreruperiExistente);
				tableBut.Visible = true;
			}
			else
			{
				tableBut.Visible = false;
			}
		}
		#endregion

		#region AdaugaLinieVida
		/// <summary>
		/// Aduaga o linie de spatiere
		/// </summary>
		/// <param name="table"></param>
		/// <param name="altern"></param>
		private void AdaugaLinieVida( System.Web.UI.WebControls.Table table, bool altern )
		{
			TableCell tc = new TableCell();
			TableRow tr = new TableRow();

			if (altern)
			{
				tr.BackColor=Definitions.Color_Altern;
			}
			
			tc.Text = "&nbsp;";
			tr.Cells.Add( tc );
			table.Rows.Add( tr );
		}
		#endregion

		#endregion

		#region HandleActions
		/// <summary>
		/// Executa actiunea
		/// </summary>
		protected void HandleActions()
		{
			AngajatID = this.GetLoggedUserID();
			Salaries.Business.Angajat objectAngajat = new Salaries.Business.Angajat();
			objectAngajat.AngajatId = AngajatID;
			objectAngajat.LoadAngajat();

			this.AddInterval.Selectable=false;
			this.AddIntervalAbsente.Selectable = false;
			this.AddIntervalIntreruperi.Selectable = false;

			if (IsPostBack)
			{
				switch (this.actionIntervale1.Value)
				{
					case "addInterval" :
						AddIntervalOperation();
						break;

					case "addIntervalAbsente" :
						AddIntervalAbsenteOperation();
						break;

					case "addIntervalIntreruperi" :
						AddIntervalIntreruperiOperation();
						break;

					case "saveIntervale" :
						SaveIntervaleOperation();
						break;

					case "saveIntervaleAbsente" :
						SaveIntervaleAbsenteOperation();
						break;

					case "saveIntervaleIntreruperi" :
						SaveIntervaleIntreruperiOperation();
						break;

					case "deleteIntervaleSelectate" :
						DeleteIntervaleSelectateOperation();
						break;

					case "deleteIntervaleAbsenteSelectate" :
						DeleteIntervaleAbsenteSelectateOperation();
						break;

					case "deleteIntervaleIntreruperiSelectate" :
						DeleteIntervaleIntreruperiSelectateOperation();
						break;

					default:
						break;
				}
													
				CreazaSirTipuriOreSuplimentareJS();
			} // postback
		}

		#endregion	

		#region Intervale

		#region AddIntervalOperation
		/// <summary>
		/// Adauga un interval
		/// </summary>
		private void AddIntervalOperation()
		{
			
			this.AddInterval.TipInterval.SelectedValue = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "TipInterval1" )).Value;
			this.AddInterval.OraStart.Value = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "OraStart1" )).Value;
			this.AddInterval.OraEnd.Value = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "OraEnd1" )).Value;
					
			int tipIntervalID = int.Parse(this.AddInterval.TipInterval.SelectedValue);

			DateTime OraStart = Utilities.DateFromOra(this.SelectedDate,this.AddInterval.OraStart.Value);
			DateTime OraEnd = Utilities.DateFromOra(this.SelectedDate,this.AddInterval.OraEnd.Value);

			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - AddIntervalOperation() - idAng: " + AngajatID + " - dataStart: " + OraStart.ToString() + " - dataEnd: " + OraEnd.ToString() + " - tipInterval: " + this.AddInterval.TipInterval.SelectedValue + ", id: " + tipIntervalID);
			int potIntrodInBd = new IntervaleAngajat( this.AngajatID ).GetIntervaleIntersectieAbsente( Utilities.ConvertToShort(this.SelectedDate));

			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.AngajatId = AngajatID;
			angajat.LoadAngajat();

			if( angajat.DataPanaLa<=this.SelectedDate && angajat.PerioadaDeterminata )
			{
				potIntrodInBd = 3;
			}

			//verificare pt depasire de ore pe saptamana
			double nrOreLucrateSapt = new IntervaleAngajat( this.AngajatID ).GetNrOreLucrateSaptamanaByDataInside( Utilities.ConvertToShort(this.SelectedDate), tipIntervalID );
			TimeSpan ts = new TimeSpan( OraEnd.Ticks-OraStart.Ticks );
			double nrOreInterval = (double)ts.Days*24+(double)ts.Hours+(double)ts.Minutes/60;

			double valMax = int.Parse( new TipuriIntervale().GetTipInterval( tipIntervalID ).Tables[ 0 ].Rows[ 0 ][ "NrMaximOreSapt" ].ToString());

			if( potIntrodInBd == 0 )
			{
				if( nrOreLucrateSapt+nrOreInterval > valMax )
				{
					if( nrOreLucrateSapt == valMax )
					{
						potIntrodInBd = 4;
					}
					else if( nrOreLucrateSapt < valMax )
					{
						DateTime tmp_OraStart = new DateTime();
						tmp_OraStart = OraStart.AddHours( valMax-nrOreLucrateSapt );
						DateTime tmp_OraEnd = new DateTime();
						tmp_OraEnd = OraEnd;
						OraEnd = tmp_OraStart;
						Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntervaleOreSaptamanaDepasire+"' );</script>" );
					}
				}
			}

			switch( potIntrodInBd )
			{
				case 0 :
					DataSet dsZi = new SituatieAngajat( this.AngajatID ).GetZiAngajat( Utilities.ConvertToShort(this.SelectedDate));
					int programLucru;
					float salBaza;
					float indemCond;
					int invaliditate;
					int categID;
					if( dsZi != null && dsZi.Tables[ 0 ].Rows.Count > 0 )
					{
						programLucru = int.Parse( dsZi.Tables[ 0 ].Rows[ 0 ][ "ProgramLucru" ].ToString());
						salBaza = float.Parse( dsZi.Tables[ 0 ].Rows[ 0 ][ "SalariuBaza" ].ToString());
						indemCond = float.Parse( dsZi.Tables[ 0 ].Rows[ 0 ][ "IndemnizatieConducere" ].ToString());
						invaliditate = int.Parse( dsZi.Tables[ 0 ].Rows[ 0 ][ "Invaliditate" ].ToString());
						categID = int.Parse( dsZi.Tables[ 0 ].Rows[ 0 ][ "CategorieID" ].ToString());
					}
					else
					{
						DataRow dr = new SituatieAngajat( this.AngajatID ).GetZiApartenentaIntervalDateAngajare( Utilities.ConvertToShort( this.SelectedDate ));
						if( dr != null )
						{
							programLucru = int.Parse( dr[ "ProgramLucru" ].ToString());
							salBaza = float.Parse( dr[ "SalariuBaza" ].ToString());
							indemCond = float.Parse( dr[ "IndemnizatieConducere" ].ToString());
							invaliditate = int.Parse( dr[ "Invaliditate" ].ToString());
							categID = int.Parse( dr[ "CategorieID" ].ToString());
						}
						else
						{
							Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
							ang.AngajatId = AngajatID;
							ang.LoadAngajat();

							programLucru = ang.ProgramLucru;
							salBaza = (float)ang.SalariuBaza;
							indemCond = (float)ang.IndemnizatieConducere;
							invaliditate = ang.Invaliditate;
							categID = ang.CategorieId;
						}
					}
					new IntervaleAngajat(this.AngajatID).InsertIntervalAngajat(Utilities.ConvertToShort(this.SelectedDate),tipIntervalID,OraStart,OraEnd,programLucru, salBaza, indemCond, invaliditate, categID );

					this.AddInterval.tipuriNestandard = false;
					if( nrOreLucrateSapt+nrOreInterval > valMax )
					{
						if( nrOreLucrateSapt < valMax )
						{
							string oraEndString = OraEnd.Hour.ToString().Length == 1 ? "0"+OraEnd.Hour.ToString() : OraEnd.Hour.ToString();
							string minutEndString = OraEnd.Minute.ToString().Length == 1 ? "0"+OraEnd.Minute.ToString() : OraEnd.Minute.ToString();
							this.AddInterval.OraStart.Value = oraEndString+":"+minutEndString;
							this.AddInterval.OraEnd.Value = this.AddInterval.OraEnd.Value;

							this.AddInterval.tipuriNestandard = true;
						}
						else
						{
							this.AddInterval.OraStart.Value=this.AddInterval.OraEnd.Value;
							this.AddInterval.OraEnd.Value="";
						}
					}
					else
					{
						this.AddInterval.OraStart.Value=this.AddInterval.OraEnd.Value;
						this.AddInterval.OraEnd.Value="";
					}
					break;

				case 1:
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntervaleOreSuprapusAbsenta+"' );</script>" );
					break;

				case 2:
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntervaleOreSuprapusIntrerupere+"' );</script>" );
					break;

				case 3:
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntervaleOreDupaTerminare+"' );</script>" );
					break;
				case 4:
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntervaleOreSaptamanaDepasire+"' );</script>" );
					break;
			}
			this.actionIntervale1.Value="";
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - AddIntervalOperation() - idAng: " + AngajatID + " - dataStart: " + OraStart.ToString() + " - dataEnd: " + OraEnd.ToString() + " - tipInterval: " + this.AddInterval.TipInterval.SelectedValue + ", id: " + tipIntervalID);
		}

		#endregion

		#region SaveIntervaleOperation
		/// <summary>
		/// Salveaza datele unui interval
		/// </summary>
		private void SaveIntervaleOperation()
		{
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - SaveIntervaleOperation()(introducere ore suplimentare si salvarea lor) - idAng: " + AngajatID );
			//introducerea de ore suplimentare si distribuirea acestora
			//---------------------------------------------------------//
			try
			{
				//stergerea orelor suplimentare
				DateTime dataStart = new DateTime( this.SelectedDate.Year, this.SelectedDate.Month, 1 );
				DateTime dataEnd = new DateTime( this.SelectedDate.Year, this.SelectedDate.Month, DateTime.DaysInMonth( this.SelectedDate.Year, this.SelectedDate.Month ));
				IntervaleAngajat ia = new IntervaleAngajat(this.AngajatID);
				DataSet ds = ia.GetTipuriIntervaleOreSuplimentare();
				ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - SaveIntervalOperation()(introducere ore suplimentare si salvarea lor) - idAng: " + AngajatID + " - dataStart: " + dataStart.ToString() + " - dataEnd: " + dataEnd.ToString());
				//distribuirea noilor ore suplimentare
				string [] IntervaleInfo  = this.IntervaleSaveInfoID1.Value.Split(";".ToCharArray());
				//int startDayDistribution = 1;
				int i = 0;
				for( int j=0; j<ds.Tables[ 0 ].Rows.Count; j++)
				{
					string []info = IntervaleInfo[ i ].Split("|".ToCharArray());
					int tipIntervalID = int.Parse( info[ 0 ] );
					double nrOreSuplimentare = double.Parse( info[ 1 ].Replace( ".", "," ));
					int tipOraSupl = int.Parse( info[ 2 ] );

					double nrOreSuplimentare_old = ia.GetNrOreLucratePerioadaTip( dataStart, dataEnd, tipIntervalID );
					
					int valEroare = ia.DistribuieOreSuplimentareTip( this.SelectedDate, tipIntervalID, nrOreSuplimentare, nrOreSuplimentare_old, tipOraSupl );

					if( valEroare == 1 )
					{
						Response.Write( "<script>alert( 'Numarul de ore suplimentare depaseste numarul de ore disponibile!' );</script>" );
					}

					i++;
				}
				ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - SaveIntervalOperation()(introducere ore suplimentare si salvarea lor) - idAng: " + AngajatID + " - dataStart: " + dataStart.ToString() + " - dataEnd: " + dataEnd.ToString());
			}
			catch( Exception)
			{
				ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - SaveIntervaleOperation()(introducere ore suplimentare si salvarea lor) - 'Valorile specificare pentru numerele de ore suplimentare nu sunt corecte!' " );
				Response.Write( "<script> alert( 'Valorile specificare pentru numerele de ore suplimentare nu sunt corecte!' );</script>" );
				return;
			}

			this.actionIntervale1.Value="";
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - SaveIntervaleOperation()(introducere ore suplimentare si salvarea lor) - idAng: " + AngajatID );
		}

		#endregion

		#region DeleteIntervaleSelectateOperation
		/// <summary>
		/// Sterge un interval
		/// </summary>
		private void DeleteIntervaleSelectateOperation()
		{
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - DeleteIntervaleSelectateOperation() - idAng: " + AngajatID );
			string aux = this.IntervaleSaveInfoID1.Value.Substring(0,this.IntervaleSaveInfoID1.Value.Length-1);
						
			string []IntervaleInfo  = aux.Split(";".ToCharArray());
										
			IntervaleAngajat ia = new IntervaleAngajat(this.AngajatID);
						
			for (int i=0;i<IntervaleInfo.Length;i++)
			{
						
				int IntervalID = int.Parse(IntervaleInfo[i]);
							
				ia.DeleteIntervalAngajat(IntervalID);
			}	

			this.actionIntervale1.Value="";
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - DeleteIntervaleSelectateOperation() - idAng: " + AngajatID );
		}

		#endregion

		#endregion
		
		#region Intervale absente
			
		#region FolosesteBoli
		/// <summary>
		/// Procedura verifica daca intervalul este de boala sau nu
		/// </summary>
		/// <param name="tipIntervalAbsentaID">Id-ul tipului de interval</param>
		/// <returns>Returneaza true daca e interval de boala si false altfel</returns>
		public bool FolosesteBoli( int tipIntervalAbsentaID )
		{
			IntervaleAngajat ia = new IntervaleAngajat(this.AngajatID);
			DataSet ds = ia.GetTipuriAbsenteMedicale();
			
			foreach( DataRow dr in ds.Tables[ 0 ].Rows )
			{
				if( int.Parse( dr[ "TipAbsentaID" ].ToString()) == tipIntervalAbsentaID )
					return true;
			}
			return false;
		}

		#endregion

		#region ActiuneInsertAbsenteBDPosibil
		//tipActiune = 0 - Insert, tipActiune = 1 - Update
		/// <summary>
		/// Adauga un intrval de absenta
		/// </summary>
		/// <param name="DataStart"></param>
		/// <param name="DataEnd"></param>
		/// <param name="tipIntervalAbsenteID"></param>
		/// <param name="observatii"></param>
		/// <param name="medieZilnica"></param>
		/// <param name="tipActiune"></param>
		/// <param name="IntervalID"></param>
		/// <param name="iaa"></param>
		/// <param name="BoalaID"></param>
		/// <param name="serie"></param>
		/// <param name="numar"></param>
		private void ActiuneInsertAbsenteBDPosibil( DateTime DataStart, DateTime DataEnd, int tipIntervalAbsenteID, string observatii, double medieZilnica, int tipActiune, int IntervalID, IntervaleAbsenteAngajat iaa, int BoalaID, string serie, string numar, bool certificatInitial, string serieCertificat, string numarCertificat, DateTime dataAcordarii, string cnpCopil, string locPrescriere, string codUrgenta, string nrAvizMedic )
		{
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - ActiuneInsertAbsenteBDPosibil()(introducere ore suplimentare si salvarea lor) - idAng: " + AngajatID + " - dataStart: " + DataStart.ToString() + " - dataEnd: " + DataEnd.ToString() + " - tipIntervalAbsenteID: " + tipIntervalAbsenteID + " - mz: " + medieZilnica);
			//verificare daca e absenta lucratoare
			DataSet dsIntervalAbsenta = new IntervaleAbsenteAngajat( this.AngajatID ).GetTipIntervalAbsentaAngajat( tipIntervalAbsenteID );
			bool lucratoare = false;
			try
			{
				if( dsIntervalAbsenta.Tables[ 0 ].Rows.Count>0 && (bool)dsIntervalAbsenta.Tables[ 0 ].Rows[ 0 ][ "Lucratoare" ] )
				{
					lucratoare = true;
				}
			}
			catch
			{
				lucratoare = false;
			}

			//verificare de introducere
			int potIntrodInBD = new IntervaleAbsenteAngajat( this.AngajatID ).IntersectieCuAlteIntervaleAbsente( DataStart, DataEnd, IntervalID );

			// In cazul in care tipul absentei este concediu de odihna.
			/*if( new IntervaleAbsenteAngajat( this.AngajatID ).GetCodAbsenta( tipIntervalAbsenteID ) == Salaries.Business.SituatieLunaraAngajat.codAbsente[ 2 ] )
			{

				int potIntrodInBDVerDepasire = new IntervaleAbsenteAngajat( this.AngajatID ).VerificareDepasireZileCOAn( DataStart, DataEnd, IntervalID );

				potIntrodInBD = potIntrodInBDVerDepasire == 10 ? 10 : potIntrodInBD;
			}*/

			switch( potIntrodInBD )
			{
				case 0:
					string [][]tmp = GetOreLucrateIntervaleSpecialeLuna();
					switch( tipActiune )
					{
						case 0:
							InsertIntervalAbsentaPosibil( DataStart, DataEnd, tipIntervalAbsenteID, observatii, medieZilnica, tipActiune, IntervalID, iaa, BoalaID, serie, numar, certificatInitial,serieCertificat,numarCertificat,dataAcordarii,cnpCopil,locPrescriere,codUrgenta,nrAvizMedic );
							break;
						case 1:
							UpdateIntervalAbsentaPosibil( DataStart, DataEnd, tipIntervalAbsenteID, observatii, medieZilnica, tipActiune, IntervalID, iaa, BoalaID, serie, numar, certificatInitial, serieCertificat, numarCertificat,dataAcordarii,cnpCopil, locPrescriere,codUrgenta,nrAvizMedic);
							break;
					}
					RedistribuireOreSuplimentareLunaAngajat( tmp );
					break;
				case 1:
					this.AddIntervalAbsente.DataStart.Value = "";
					this.AddIntervalAbsente.TipBoalaID = BoalaID;
					this.AddIntervalAbsente.TipIntervalID = tipIntervalAbsenteID;
					
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaAbsenteInceput+"' );</script>" );

					break;
				case 2:
					this.AddIntervalAbsente.DataEnd.Value = "";
					this.AddIntervalAbsente.TipBoalaID = BoalaID;
					this.AddIntervalAbsente.TipIntervalID = tipIntervalAbsenteID;

					Response.Write( "<script> alert( '"+Definitions.alertAdaugaAbsenteSfarsit+"' );</script>" );

					break;
				case 3:
					this.AddIntervalAbsente.DataStart.Value = "";
					this.AddIntervalAbsente.DataEnd.Value = "";
					this.AddIntervalAbsente.TipBoalaID = BoalaID;
					this.AddIntervalAbsente.TipIntervalID = tipIntervalAbsenteID;

					Response.Write( "<script> alert( '"+Definitions.alertAdaugaAbsenteInceputSfarsit+"' );</script>" );

					break;
				case 4:
					this.AddIntervalAbsente.TipBoalaID = BoalaID;
					this.AddIntervalAbsente.TipIntervalID = tipIntervalAbsenteID;

					Response.Write( "<script> alert( '"+Definitions.alertAdaugaAbsenteContineInterval+"' );</script>" );

					break;
				case 5:
					this.AddIntervalAbsente.TipBoalaID = BoalaID;
					this.AddIntervalAbsente.TipIntervalID = tipIntervalAbsenteID;

					bool tipContinuareAbsenta = VerificaTipContinuareAbsenta( tipIntervalAbsenteID,new IntervaleAbsenteAngajat( this.AngajatID ));
					
					if( !lucratoare  && !tipContinuareAbsenta)
					{
						new IntervaleAngajat( this.AngajatID ).DeleteTemporarIntervaleAngajatPerioada( DataStart, DataEnd, false);
					}

					tmp = GetOreLucrateIntervaleSpecialeLuna();

					switch( tipActiune )
					{
						case 0:

							InsertIntervalAbsentaPosibil( DataStart, DataEnd, tipIntervalAbsenteID, observatii, medieZilnica, tipActiune, IntervalID, iaa, BoalaID,serie, numar, certificatInitial, serieCertificat, numarCertificat,dataAcordarii, cnpCopil, locPrescriere, codUrgenta, nrAvizMedic );
							break;
						case 1:
							UpdateIntervalAbsentaPosibil( DataStart, DataEnd, tipIntervalAbsenteID, observatii, medieZilnica, tipActiune, IntervalID, iaa, BoalaID, serie, numar, certificatInitial, serieCertificat,numarCertificat,dataAcordarii,cnpCopil,locPrescriere,codUrgenta,nrAvizMedic );
							break;
					}
					RedistribuireOreSuplimentareLunaAngajat( tmp );
					break;
				case 6:

					this.AddIntervalAbsente.DataStart.Value = "";
					
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntreruperiInceput+"' );</script>" );

					break;
				case 7:

					this.AddIntervalAbsente.DataEnd.Value = "";

					Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntreruperiSfarsit+"' );</script>" );

					break;
				case 8:

					this.AddIntervalAbsente.DataStart.Value = "";
					this.AddIntervalAbsente.DataEnd.Value = "";

					Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntreruperiInceputSfarsit+"' );</script>" );

					break;
				case 9:

					Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntreruperiContineInterval+"' );</script>" );

					break;
				/*case 10:
					//Response.Write("<script>  var seSalveazaDepasireClient = '" + seSalveazaDepasire.ClientID + "'; </script>");
					//Response.Write( "<script> if (confirm( '"+Definitions.alertAdaugaCODepasireZileAn+"' )) { alert(document.getElementById(seSalveazaDepasireClient)); document.getElementById(seSalveazaDepasireClient).value = 'saveIntervaleAbsente' };</script>" );
					this.Salveaza.Attributes.Add("onclick", "if (confirm( '"+Definitions.alertAdaugaCODepasireZileAn+"' )) { SubmitSave() }");
					break;*/
				default:
					break;
			}
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - ActiuneInsertAbsenteBDPosibil()(introducere ore suplimentare si salvarea lor) - idAng: " + AngajatID + " - dataStart: " + DataStart.ToString() + " - dataEnd: " + DataEnd.ToString() + " - tipIntervalAbsenteID: " + tipIntervalAbsenteID + " - mz: " + medieZilnica);	
		}

		#endregion

		#region GetOreLucrateIntervaleSpecialeLuna
		/// <summary>
		/// Procedura determina orele lucrate pe luna
		/// </summary>
		/// <returns></returns>
		private string [][]GetOreLucrateIntervaleSpecialeLuna()
		{
			IntervaleAngajat ia = new IntervaleAngajat(this.AngajatID);
			DataSet ds = ia.GetTipuriIntervaleOreSuplimentare();

			//col1 = id-ul tipului de interval; col2 = nr de ore suplimentare pe luna; col3 = ore suplimentare normale sau de weekend-noapte
			string [][]tmp = new string[ ds.Tables[ 0 ].Rows.Count][];
			int i=0;
			DateTime dataSt = new DateTime( this.SelectedDate.Year, this.SelectedDate.Month, 1 );
			DateTime dataEnd = new DateTime( this.SelectedDate.Year, this.SelectedDate.Month, DateTime.DaysInMonth( this.SelectedDate.Year, this.SelectedDate.Month ));
								
			foreach( DataRow dr in ds.Tables[ 0 ].Rows )
			{
				tmp[ i ] = new string[ 3 ];
				tmp[ i ][ 0 ] = dr[ "TipIntervalID" ].ToString();
				tmp[ i ][ 1 ] = ia.GetNrOreLucratePerioadaTip( dataSt, dataEnd, int.Parse( tmp[ i ][ 0 ] )).ToString();
				tmp[ i ][ 2 ] = dr[ "AplicWeekendNoapte" ].ToString();
				i++;
			}
			return tmp;
		}

		#endregion

		#region RedistribuireOreSuplimentareLunaAngajat
		/// <summary>
		/// Procedura redistribuie orele suplimentare ale angajatului
		/// </summary>
		/// <param name="tmp"></param>
		private void RedistribuireOreSuplimentareLunaAngajat( string [][]tmp )
		{
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - RedistribuireOreSupl() - idAng: " + AngajatID);
			for( int j=0; j<tmp.Length; j++ )
			{

				int tipIntervalID = int.Parse( tmp[ j ][ 0 ] );
				double nrOreSuplimentare = double.Parse( tmp[ j ][ 1 ] );
				int tipOraSupl = bool.Parse( tmp[ j ][ 2 ].ToLower())? 1 : 0;

				double nrOreSuplimentare_old = 0;

				int valEroare = new IntervaleAngajat( this.AngajatID ).DistribuieOreSuplimentareTip( this.SelectedDate, tipIntervalID, nrOreSuplimentare, nrOreSuplimentare_old, tipOraSupl );
				if( valEroare == 1 )
				{
					Response.Write( "<script>alert( 'Numarul de ore suplimentare depaseste numarul de ore disponibile!' );</script>" );
				}
			}
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - RedistribuireOreSupl() - idAng: " + AngajatID);
		}

		#endregion	

		#region AddIntervalAbsenteOperation
		/// <summary>
		/// Este adaugat intervalul de absenta
		/// </summary>
		/// <remarks>
		/// Modificari:
		/// Autor: Cristina Raluca Muntean
		/// Data:  29.06.2006
		/// Descriere: Am modificat astfel incat daca tipul de absenta este concediu de odihna sau concediu de pe anul 
		/// precedent sa se preia valoarea mediei zilnice.
		/// 
		/// Autor:		Fratila Claudia
		/// Data:		29.10.2007
		/// Descriere:	S-a adaugat un mesaj de avertizare la specificarea unei date care nu exista.
		///				Ex: 31.09.2007
		/// </remarks>
		private void AddIntervalAbsenteOperation()
		{
			DateTime DataStart = DateTime.Now;
			DateTime DataEnd = DateTime.Now;

			this.AddIntervalAbsente.TipIntervalAbsenteDDL.SelectedValue = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "TipIntervalAbsente1" )).Value;
			this.AddIntervalAbsente.DataStart.Value = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "DataStart1" )).Value;
			this.AddIntervalAbsente.DataEnd.Value = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "DataEnd1" )).Value;
			
			int tipIntervalAbsenteID = int.Parse( this.AddIntervalAbsente.TipIntervalAbsenteDDL.SelectedValue );	
			try
			{
				DataStart = Utilities.ConvertText2DateTime( this.AddIntervalAbsente.DataStart.Value );
			}
			catch (Exception ex)
			{
				Response.Write( "<script> alert( '"+Definitions.alertInceput+"' );</script>" );
				return;
			}
			try
			{
				DataEnd = Utilities.ConvertText2DateTime( this.AddIntervalAbsente.DataEnd.Value );
			}
			catch (Exception ex)
			{
				Response.Write( "<script> alert( '"+Definitions.alertSfarsit+"' );</script>" );
				return;
			}

			string observatii = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ObservatiiID" )).Value;
			this.AddIntervalAbsente.observatii.Value = observatii;
			int BoalaID = -1;
			string serie = "", numar = "";
			bool certificatInitial=false;
			string serieCertificatInitial="", numarCertificatInitial="";
			DateTime dataAcordariiCertificatului=DateTime.Today;
			string cnpCopil="", loculDePrescriere="", codUrgenta="", nrAvizMedic="";
			double MedieZilnica = 0;

			//Numai daca s-a selectat un concediu medical sau o continuare de concediu medical se face validarea pentru boala si medie
			string tipIntervalAbsenteText = this.AddIntervalAbsente.TipIntervalAbsenteDDL.SelectedItem.Text;
			
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - AddIntervalAbsenteOperation() - idAng: " + AngajatID + " - dataStart: " + DataStart.ToString() + " - dataEnd: " + DataEnd.ToString() + " - tipIntervalAbsenteId: " + tipIntervalAbsenteID);

			if ((tipIntervalAbsenteText == "Concediu Medical") || (tipIntervalAbsenteText == "Continuare Concediu Medical"))
			{
				if( ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "TipBoalaAbsente1" )).Value != "" )
				{
					BoalaID = int.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "TipBoalaAbsente1" )).Value );
					
					//Oprescu Claudia
					//S-au adaugat si cele doua campuri pentru serie si numar care sunt obligatorii
					serie = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtSerieHidden" )).Value.ToString();
					if (serie == "")
					{
						Response.Write( "<script> alert( '"+Definitions.alertSerieConecdiuMedical+"' );</script>" );
						return;
					}

					numar = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNumarHidden" )).Value.ToString();
					if (numar == "")
					{
						Response.Write( "<script> alert( '"+Definitions.alertNumarConecdiuMedical+"' );</script>" );
						return;
					}
					//-------------------------------Daniela Chiperescu - 21.02.2011-------------
					serieCertificatInitial=((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtSerieCertificatHidden" )).Value.ToString();
					numarCertificatInitial=((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNumarCertificatHidden" )).Value.ToString();
					certificatInitial = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtCertificatInitialHidden" )).Value.ToString().Equals("Da")?true:false;
					dataAcordariiCertificatului=Utilities.ConvertText2DateTime(((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDataAcordariiCertificatHidden" )).Value.ToString());
					cnpCopil = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtCnpCopilHidden" )).Value.ToString();
					codUrgenta=((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtCodUrgentaHidden" )).Value.ToString();
					loculDePrescriere=((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtLocPrescriereCertificatHidden" )).Value.ToString();
					nrAvizMedic=((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrAvizMedicExpertHidden" )).Value.ToString();
					//-------------------------------Daniela Chiperescu - 21.02.2011-------------
					this.AddIntervalAbsente.Serie.Value = serie;
					this.AddIntervalAbsente.Numar.Value = numar;
					//-------------------------------Daniela Chiperescu - 21.02.2011-------------
					this.AddIntervalAbsente.CertificatInitial.Value = certificatInitial?"Da":"Nu";
					this.AddIntervalAbsente.SerieCertificat.Value = serieCertificatInitial;
					this.AddIntervalAbsente.NumarCertificat.Value = numarCertificatInitial;
					this.AddIntervalAbsente.DataAcordariiCertificat.Value = Utilities.ConvertDateTime2Text(dataAcordariiCertificatului).ToString();
					this.AddIntervalAbsente.CnpCopil.Value=cnpCopil;
					this.AddIntervalAbsente.CodUrgenta.Value = codUrgenta;
					this.AddIntervalAbsente.LocPrescriereCertificat.Value=loculDePrescriere;
					this.AddIntervalAbsente.NrAvizMedicExpert.Value = nrAvizMedic;
					//-------------------------------Daniela Chiperescu - 21.02.2011-------------
				}
			}
				
			if ((tipIntervalAbsenteText == "Concediu Medical") || (tipIntervalAbsenteText == "Continuare Concediu Medical") ||
				(tipIntervalAbsenteText == "Concediu Odihna") || (tipIntervalAbsenteText == "Concediu Odihna Anul Precedent"))
			{
				if( ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "MedieZilnica1" )).Value != "" )
				{
					try
					{
						MedieZilnica = double.Parse( ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "MedieZilnica1" )).Value );
						if ( MedieZilnica <= 0 )
							throw new Exception();
					}
					catch( Exception)
					{
						Response.Write( "<script> alert( '"+Definitions.alertMedieZilnicaIncorecta+"' );</script>" );
						ErrHandler.MyErrHandler.WriteError("Intervale.ascx - error - AddIntervalAbsenteOperation() - idAng: " + AngajatID + " - " + Definitions.alertMedieZilnicaIncorecta );
						return;
					}
				}

				this.AddIntervalAbsente.MedieZilnica.Value = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "MedieZilnica1" )).Value;
			}		

			ActiuneInsertAbsenteBDPosibil( DataStart, DataEnd, tipIntervalAbsenteID, observatii, MedieZilnica, 0, -1, null, -1,serie, numar, certificatInitial, serieCertificatInitial,numarCertificatInitial,dataAcordariiCertificatului,cnpCopil,loculDePrescriere,codUrgenta,nrAvizMedic );

			this.actionIntervale1.Value="";
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - AddIntervalAbsenteOperation() - idAng: " + AngajatID);
		}

		#endregion

		#region InsertIntervalAbsentaPosibil
		/// <summary>
		/// Adaugarea propriu-zisa a absentelor
		/// 
		/// Autor:		Fratila Claudia
		/// Data:		29.10.2007
		/// Descriere:	S-a adaugat un mesaj de avertizare la specificarea unei date care nu exista.
		///				Ex: 31.09.2007
		/// </summary>
		/// <param name="DataStart"></param>
		/// <param name="DataEnd"></param>
		/// <param name="tipIntervalAbsenteID"></param>
		/// <param name="observatii"></param>
		/// <param name="medieZilnica"></param>
		/// <param name="tipActiune"></param>
		/// <param name="IntervalID"></param>
		/// <param name="iaa"></param>
		/// <param name="BoalaID"></param>
		/// <param name="serie"></param>
		/// <param name="numar"></param>
		private void InsertIntervalAbsentaPosibil( DateTime DataStart, DateTime DataEnd, int tipIntervalAbsenteID, string observatii, double medieZilnica, int tipActiune, int IntervalID, IntervaleAbsenteAngajat iaa, int BoalaID, string serie, string numar, bool certificatInitial, string serieCertificat, string numarCertificat, DateTime dataAcordarii, string cnpCopil, string locPrescriere, string codUrgenta, string nrAvizMedic )
		{
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - InsertIntervalAbsentaPosibil() - actiune: " + tipActiune + " - idAng: " + AngajatID + " - dataStart: " + DataStart.ToString() + " - dataEnd: " + DataEnd.ToString() + " - tipIntervalAbsenteId: " + tipIntervalAbsenteID + " - mz: " + medieZilnica);
			bool continuareAbsenta = VerificaContinuareAbsenta( tipIntervalAbsenteID, DataStart );
			int boalaID = -1;
			if( FolosesteBoli( tipIntervalAbsenteID ))
			{
				boalaID = int.Parse( ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "TipBoalaAbsente1" )).Value );
			}
			IntervaleAbsenteAngajat intervAbs = new IntervaleAbsenteAngajat( this.AngajatID );
			if( continuareAbsenta || ( !VerificaTipContinuareAbsenta( tipIntervalAbsenteID, intervAbs )))
			{


				bool tipContinuareAbsenta = VerificaTipContinuareAbsenta( tipIntervalAbsenteID,new IntervaleAbsenteAngajat( this.AngajatID ));
				if( tipContinuareAbsenta)
					new IntervaleAngajat( this.AngajatID ).DeleteTemporarIntervaleAngajatPerioada( DataStart, DataEnd, false);


				new IntervaleAbsenteAngajat( this.AngajatID ).InsertIntervalAbsenteAngajat( tipIntervalAbsenteID, DataStart, DataEnd, observatii, boalaID, continuareAbsenta, medieZilnica, serie, numar,certificatInitial,serieCertificat,numarCertificat,dataAcordarii,cnpCopil,locPrescriere,codUrgenta,nrAvizMedic );
				string dataS = "";
				try
				{
					dataS = Utilities.ConvertToShort(Utilities.ConvertText2DateTime( this.AddIntervalAbsente.DataEnd.Value ).AddDays( 1 )).ToString();
				}
				catch (Exception ex)
				{
					Response.Write( "<script> alert( '"+Definitions.alertInceput+"' );</script>" );
					ErrHandler.MyErrHandler.WriteError("Intervale.ascx - error - InsertIntervalAbsentaPosibil() - idAng: " + AngajatID + " - " + Definitions.alertInceput);
					return;
				}

				char []split = new char[ 1 ]; split[ 0 ] = ' ';
				dataS = dataS.Split( split )[ 0 ];

				this.AddIntervalAbsente.DataStart.Value = dataS;
				this.AddIntervalAbsente.DataEnd.Value = "";
				this.AddIntervalAbsente.MedieZilnica.Value = "0";
				this.AddIntervalAbsente.Serie.Value = "";
				this.AddIntervalAbsente.Numar.Value = "";
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtSerieHidden" )).Value = "";
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNumarHidden" )).Value = "";
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "MedieZilnica1" )).Value = "0";
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtSerieCertificatHidden" )).Value = "";
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNumarCertificatHidden" )).Value = "";
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtCertificatInitialHidden" )).Value = "";
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDataAcordariiCertificatHidden" )).Value = "";
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtCnpCopilHidden" )).Value = "";
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtCodUrgentaHidden" )).Value = "";
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtLocPrescriereCertificatHidden" )).Value = "";
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrAvizMedicExpertHidden" )).Value = "";
			}
			else
			{
				Response.Write( "<script> alert( '"+Definitions.alertContinuareAbsentaMedicala+"' );</script>" );
				this.AddIntervalAbsente.TipBoalaID = boalaID;
				this.AddIntervalAbsente.TipIntervalID = tipIntervalAbsenteID;
			}
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - InsertIntervalAbsentaPosibil() - actiune: " + tipActiune + " - idAng: " + AngajatID);
		}

		#endregion

		#region UpdateIntervalAbsentaPosibil
		/// <summary>
		/// Actualizarea unui interval de absenta 
		/// </summary>
		/// <param name="DataStart"></param>
		/// <param name="DataEnd"></param>
		/// <param name="tipIntervalAbsenteID"></param>
		/// <param name="observatii"></param>
		/// <param name="medieZilnica"></param>
		/// <param name="tipActiune"></param>
		/// <param name="IntervalID"></param>
		/// <param name="iaa"></param>
		/// <param name="BoalaID"></param>
		/// <param name="serie"></param>
		/// <param name="numar"></param>
		private void UpdateIntervalAbsentaPosibil( DateTime DataStart, DateTime DataEnd, int tipIntervalAbsenteID, string observatii, double medieZilnica, int tipActiune, int IntervalID, IntervaleAbsenteAngajat iaa, int BoalaID, string serie, string numar, bool certificatInitial, string serieCertificat, string numarCertificat, DateTime dataAcordarii, string cnpCopil, string locPrescriere, string codUrgenta, string nrAvizMedic )
		{
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - UpdateIntervalAbsentaPosibil() - actiune: " + tipActiune + " - idAng: " + AngajatID + " - dataStart: " + DataStart.ToString() + " - dataEnd: " + DataEnd.ToString() + " - tipIntervalAbsenteId: " + tipIntervalAbsenteID + " - mz: " + medieZilnica);
			bool continuareAbsenta = VerificaContinuareAbsenta( tipIntervalAbsenteID, DataStart );
			int boalaID = -1;
			if( FolosesteBoli( tipIntervalAbsenteID ))
			{
				boalaID = BoalaID;
			}
                            
			IntervaleAbsenteAngajat intervAbs = new IntervaleAbsenteAngajat( this.AngajatID );
			if( continuareAbsenta || ( !VerificaTipContinuareAbsenta( tipIntervalAbsenteID, intervAbs )))
			{
				//dovle
				DataSet ds = iaa.GetIntervalAbsentaAngajatByID( IntervalID );
				if( ds.Tables[ 0 ].Rows.Count > 0 && ds != null )
				{
					if((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ]>DataEnd )
					{
						new IntervaleAngajat( this.AngajatID ).RestoreIntervaleAngajatPerioadaSterseTemporar( DataEnd.AddDays( 1 ), (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ] );
					}
					if((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ]<DataStart )
					{
						new IntervaleAngajat( this.AngajatID ).RestoreIntervaleAngajatPerioadaSterseTemporar((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ], DataStart.AddDays( -1 ));
					}					
				}

				iaa.UpdateIntervalAbsenteAngajat( IntervalID, tipIntervalAbsenteID, DataStart, DataEnd, observatii, boalaID, continuareAbsenta, medieZilnica, serie, numar, certificatInitial,serieCertificat, numarCertificat,dataAcordarii,cnpCopil,locPrescriere,codUrgenta,nrAvizMedic );
			}
			else
			{
				Response.Write( "<script> alert( '"+Definitions.alertContinuareAbsentaMedicala+"' );</script>" );
			}
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - UpdateIntervalAbsentaPosibil() - actiune: " + tipActiune + " - idAng: " + AngajatID);
		}

		#endregion

		#region SaveIntervaleAbsenteOperation
		/// <summary>
		/// Salvarea datelor unui interval de absenta
		/// 
		/// Autor:		Fratila Claudia
		/// Data:		29.10.2007
		/// Descriere:	S-a adaugat un mesaj de avertizare la specificarea unei date care nu exista.
		///				Ex: 31.09.2007
		/// </summary>
		private void SaveIntervaleAbsenteOperation()
		{
			DateTime DataStart = DateTime.Now;
			DateTime DataEnd = DateTime.Now;
			string [] IntervaleAbsenteInfo  = this.IntervaleAbsenteSaveInfoID1.Value.Split( "^".ToCharArray());
			IntervaleAbsenteAngajat iaa = new IntervaleAbsenteAngajat( this.AngajatID );
						
			for( int i=0; i<IntervaleAbsenteInfo.Length; i++ )
			{
				string []  info = IntervaleAbsenteInfo[ i ].Split( "#".ToCharArray());
				int IntervalID = int.Parse( info[0] );
						
				try
				{
					DataStart = Utilities.ConvertText2DateTime( info[ 1 ] );
				}
				catch (Exception ex)
				{
					Response.Write( "<script> alert( '"+Definitions.alertInceput+"' );</script>" );
					return;
				}
				try
				{
					DataEnd = Utilities.ConvertText2DateTime( info[ 2 ] );
				}
				catch (Exception ex)
				{
					Response.Write( "<script> alert( '"+Definitions.alertSfarsit+"' );</script>" );
					return;
				}

				int tipIntervalAbsenteID = int.Parse(info[3]);

				ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - SaveIntervaleAbsentaOperation() - idAng: " + AngajatID + " - dataStart: " + DataStart.ToString() + " - dataEnd: " + DataEnd.ToString() + " - tipIntervalAbsenteId: " + tipIntervalAbsenteID);
				string observatii = info[ 4 ];
				int BoalaID = -1;
				string serie = "", numar = "", numarCertificat="", serieCertificat="", cnpCopil="",locPrescriereCertificat="",codUrgenta="",nrAvizMedica="";
				bool  certificatInitial=false;
				DateTime dataAcordariiCertificat=DateTime.Today;
				double medieZilnica = 0;
				if(( info[ 5 ] != "")&&((info[9]=="Concediu Medical")||(info[9]=="Continuare Concediu Medical")))
				{
					BoalaID = int.Parse( info[ 5 ] );
					//Oprescu Claudia
					//S-au adaugat si cele doua campuri pentru serie si numar
					serie = info[7];
					numar = info[8];
					//----------Chiperescu Daniela 22.02.2011---------------------------------
					if(info.Length>10)
					{
						certificatInitial=(info[10]=="Da")?true:false;
						serieCertificat=info[11];
						numarCertificat=info[12];
						dataAcordariiCertificat=Utilities.ConvertText2DateTime(info[13]);
						cnpCopil=info[14];
						locPrescriereCertificat=info[15];
						codUrgenta=info[16];
						nrAvizMedica=info[17];
					}
					//----------Chiperescu Daniela 22.02.2011---------------------------------
					if (serie == "")
					{
						Response.Write( "<script> alert( '"+Definitions.alertSerieConecdiuMedical+"' );</script>" );
						return;
					}
					if (numar == "")
					{
						Response.Write( "<script> alert( '"+Definitions.alertNumarConecdiuMedical+"' );</script>" );
						return;
					}
					try
					{
						medieZilnica = double.Parse( info[ 6 ] );
						if ( medieZilnica <= 0 )
							throw new Exception();
					}
					catch( Exception)
					{
						Response.Write( "<script> alert( '"+Definitions.alertMedieZilnicaIncorecta+"' );</script>" );
						return;
					}
				}
				if((info[9]=="Concediu Odihna") || (info[9]=="Concediu Odihna Anul Precedent"))
				{
					try
					{
						medieZilnica = double.Parse( info[ 6 ] );
						if ( medieZilnica <= 0 )
							throw new Exception();
					}
					catch( Exception)
					{
						Response.Write( "<script> alert( '"+Definitions.alertMedieZilnicaIncorecta+"' );</script>" );
						return;
					}
				}
				ActiuneInsertAbsenteBDPosibil( DataStart, DataEnd, tipIntervalAbsenteID, observatii, medieZilnica, 1, IntervalID, iaa, BoalaID,serie, numar,certificatInitial,serieCertificat,numarCertificat,dataAcordariiCertificat,cnpCopil,locPrescriereCertificat,codUrgenta,nrAvizMedica);
			}	

			this.actionIntervale1.Value="";
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - SaveIntervaleAbsentaeOperation() - idAng: " + AngajatID );
		}

		#endregion	

		#region DeleteIntervaleAbsenteSelectateOperation
		/// <summary>
		/// Sterge un interval de absenta
		/// </summary>
		private void DeleteIntervaleAbsenteSelectateOperation()
		{
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - DeleteIntervaleAbsentaSelectateOperation() - idAng: " + AngajatID );
			string aux = this.IntervaleAbsenteSaveInfoID1.Value.Substring( 0, this.IntervaleAbsenteSaveInfoID1.Value.Length-1 );
						
			string []IntervaleInfo  = aux.Split("^".ToCharArray());
										
			IntervaleAbsenteAngajat iaa = new IntervaleAbsenteAngajat( this.AngajatID );
			DataSet ds = new DataSet();
						
			for( int i=0; i<IntervaleInfo.Length;i++)
			{
				int IntervalID = int.Parse( IntervaleInfo[ i ] );

				int []continuariId = iaa.GetIntervalAbsentaContinuari( IntervalID );
				if( continuariId != null )
				{
					for( int j=0; j<continuariId.Length; j++ )
					{
						ds = iaa.GetIntervalAbsentaAngajatByID( continuariId[ j ] );
						if( ds.Tables[ 0 ].Rows.Count > 0 && ds != null )
						{
							new IntervaleAngajat( this.AngajatID ).RestoreIntervaleAngajatPerioadaSterseTemporar( (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ], (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ] );
						}
						iaa.DeleteIntervalAbsenteAngajat( continuariId[ j ] );
					}
				}

				ds = iaa.GetIntervalAbsentaAngajatByID( IntervalID );
				if( ds.Tables[ 0 ].Rows.Count > 0 && ds != null )
				{
					new IntervaleAngajat( this.AngajatID ).RestoreIntervaleAngajatPerioadaSterseTemporar( (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ], (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ] );
				}

				string [][]tmp = GetOreLucrateIntervaleSpecialeLuna();
				ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - DeleteIntervaleAbsentaSelectateOperation() - idInterv: " + IntervalID );
				iaa.DeleteIntervalAbsenteAngajat( IntervalID );
				RedistribuireOreSuplimentareLunaAngajat( tmp );

			}	

			this.actionIntervale1.Value="";
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - DeleteIntervaleAbsentaSelectateOperation() - idAng: " + AngajatID );
		}

		#endregion 

		#endregion	

		#region Intervale intreruperi

		#region ActiuneInsertIntreruperiBDPosibil
		/// <summary>
		/// Procedura adauga un interval de intrerupere
		/// </summary>
		/// <param name="DataStart"></param>
		/// <param name="DataEnd"></param>
		/// <param name="descriere"></param>
		/// <param name="tipActiune"></param>
		/// <param name="IntervalID"></param>
		/// <param name="iia"></param>
		private void ActiuneInsertIntreruperiBDPosibil( DateTime DataStart, DateTime DataEnd, string descriere, int tipActiune, int IntervalID, IntervaleIntreruperiAngajat iia )
		{
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - ActiuneInsertIntreruperiBDPosibil() - idAng: " + AngajatID + " - dataStart: " + DataStart.ToString() + " - dataEnd: " + DataEnd.ToString() + " - intervalID: " + IntervalID);
			int potIntrodInBD = new IntervaleIntreruperiAngajat( this.AngajatID ).IntersectieCuIntervaleExistente( DataStart, DataEnd, IntervalID );

			switch( potIntrodInBD )
			{
				case 0:
					string [][]tmp = GetOreLucrateIntervaleSpecialeLuna();
				switch( tipActiune )
				{
					case 0:
						InsertIntervalIntreruperiPosibil( DataStart, DataEnd, descriere, tipActiune, IntervalID, iia );
						RedistribuireOreSuplimentareLunaAngajat( tmp );									
						break;

					case 1:
						UpdateIntervalIntreruperiPosibil( DataStart, DataEnd, descriere, tipActiune, IntervalID, iia );
						break;
				}
					RedistribuireOreSuplimentareLunaAngajat( tmp );
					break;
				case 1:
					this.AddIntervalIntreruperi.DataStart.Value = "";
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaAbsenteInceput+"' );</script>" );
					break;
				case 2:
					this.AddIntervalIntreruperi.DataEnd.Value = "";
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaAbsenteSfarsit+"' );</script>" );
					break;
				case 3:
					this.AddIntervalIntreruperi.DataStart.Value = "";
					this.AddIntervalIntreruperi.DataEnd.Value = "";
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaAbsenteInceputSfarsit+"' );</script>" );
					break;
				case 4:
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaAbsenteContineInterval+"' );</script>" );
					break;
				case 5:
					new IntervaleAngajat( this.AngajatID ).DeleteTemporarIntervaleAngajatPerioada( DataStart, DataEnd, false );
					tmp = GetOreLucrateIntervaleSpecialeLuna();
				switch( tipActiune )
				{
					case 0:
						InsertIntervalIntreruperiPosibil( DataStart, DataEnd, descriere, tipActiune, IntervalID, iia );
						break;

					case 1:
						UpdateIntervalIntreruperiPosibil( DataStart, DataEnd, descriere, tipActiune, IntervalID, iia );
						break;
				}
					RedistribuireOreSuplimentareLunaAngajat( tmp );
					break;
				case 6:
					this.AddIntervalIntreruperi.DataStart.Value = "";
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntreruperiInceput+"' );</script>" );
					break;
				case 7:
					this.AddIntervalIntreruperi.DataEnd.Value = "";
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntreruperiSfarsit+"' );</script>" );
					break;
				case 8:
					this.AddIntervalIntreruperi.DataStart.Value = "";
					this.AddIntervalIntreruperi.DataEnd.Value = "";
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntreruperiInceputSfarsit+"' );</script>" );
					break;
				case 9:
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntreruperiContineInterval+"' );</script>" );
					break;
				//se verifica faptul ca data de inceput si de sfarsit a intervalului sa nu fie inversate
				case 10:
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaAbsenteDateInversate+"' );</script>" );
					break;
				default:
					break;
			}
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - ActiuneInsertIntreruperiBDPosibil() - actiune: " + tipActiune + " - idAng: " + AngajatID);
		}

		#endregion

		#region AddIntervalIntreruperiOperation
		/// <summary>
		/// Adauga in intrval de intrerupere
		///
		/// Autor:		Fratila Claudia
		/// Data:		29.10.2007
		/// Descriere:	S-a adaugat un mesaj de avertizare la specificarea unei date care nu exista.
		///				Ex: 31.09.2007
		/// </summary>
		private void AddIntervalIntreruperiOperation()
		{
			DateTime DataStart = DateTime.Now;
			DateTime DataEnd = DateTime.Now;
			this.AddIntervalIntreruperi.DataStart.Value = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "DataStart1" )).Value;
			this.AddIntervalIntreruperi.DataEnd.Value = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "DataEnd1" )).Value;
				
			try
			{
				DataStart = Utilities.ConvertText2DateTime( this.AddIntervalIntreruperi.DataStart.Value );
			}
			catch (Exception ex)
			{
				Response.Write( "<script> alert( '"+Definitions.alertInceput+"' );</script>" );
				return;
			}
			try
			{
				DataEnd = Utilities.ConvertText2DateTime( this.AddIntervalIntreruperi.DataEnd.Value );
			}
			catch (Exception ex)
			{
				Response.Write( "<script> alert( '"+Definitions.alertSfarsit+"' );</script>" );
				return;
			}
			
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - AddIntervalIntreruperiOperatii() - idAng: " + AngajatID + " - dataStart: " + DataStart.ToString() + " - dataEnd: " + DataEnd.ToString());
			
			string descriere = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ObservatiiID" )).Value;
			this.AddIntervalIntreruperi.descriere.Value = descriere;

			ActiuneInsertIntreruperiBDPosibil( DataStart, DataEnd, descriere, 0, -1, null );
			this.actionIntervale1.Value="";

			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - AddIntervalIntreruperiOperatii() - idAng: " + AngajatID);
			
		}

		#endregion

		#region InsertIntervalIntreruperiPosibil
		/// <summary>
		/// Adaugarea propriu-zisa a absentelor
		/// 
		/// Autor:		Fratila Claudia
		/// Data:		29.10.2007
		/// Descriere:	S-a adaugat un mesaj de avertizare la specificarea unei date care nu exista.
		///				Ex: 31.09.2007
		/// </summary>
		/// <param name="DataStart"></param>
		/// <param name="DataEnd"></param>
		/// <param name="descriere"></param>
		/// <param name="tipActiune"></param>
		/// <param name="IntervalID"></param>
		/// <param name="iia"></param>
		private void InsertIntervalIntreruperiPosibil( DateTime DataStart, DateTime DataEnd, string descriere, int tipActiune, int IntervalID, IntervaleIntreruperiAngajat iia )
		{
			IntervaleIntreruperiAngajat intervIntr = new IntervaleIntreruperiAngajat( this.AngajatID );
			intervIntr.InsertIntervalIntreruperiAngajat( DataStart, DataEnd, descriere );
			string dataS = "";
			try
			{
				dataS = Utilities.ConvertToShort(Utilities.ConvertText2DateTime(this.AddIntervalIntreruperi.DataEnd.Value).AddDays( 1 )).ToString();
			}
			catch (Exception ex)
			{
				Response.Write( "<script> alert( '"+Definitions.alertInceput+"' );</script>" );
				return;
			}

			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - InsertIntervalIntreruperiPosibil() - actiune: " + tipActiune + " - idAng: " + AngajatID + " - dataStart: " + DataStart.ToString() + " - dataEnd: " + DataEnd.ToString() + " - intervalID: " + IntervalID);

			char []split = new char[ 1 ]; split[ 0 ] = ' ';
			dataS = dataS.Split( split )[ 0 ];

			this.AddIntervalIntreruperi.DataStart.Value = dataS;
			this.AddIntervalIntreruperi.DataEnd.Value = "";

			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - AddIntervalIntreruperiOperatii() - actiune: " + tipActiune + " - idAng: " + AngajatID);
		}

		#endregion

		#region UpdateIntervalIntreruperiPosibil
		/// <summary>
		/// Actualizeaza un interval de intrerupere
		/// </summary>
		/// <param name="DataStart"></param>
		/// <param name="DataEnd"></param>
		/// <param name="descriere"></param>
		/// <param name="tipActiune"></param>
		/// <param name="IntervalID"></param>
		/// <param name="iia"></param>
		private void UpdateIntervalIntreruperiPosibil( DateTime DataStart, DateTime DataEnd, string descriere, int tipActiune, int IntervalID, IntervaleIntreruperiAngajat iia )
		{
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - UpdateIntervalIntreruperiPosibil() - actiune: " + tipActiune + " - idAng: " + AngajatID + " - dataStart: " + DataStart.ToString() + " - dataEnd: " + DataEnd.ToString() + " - intervalID: " + IntervalID);
			//dovle
			DataSet ds = iia.GetIntervalIntreruperiAngajatByID( IntervalID );
			if( ds.Tables[ 0 ].Rows.Count > 0 && ds != null )
			{
				if((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ]>DataEnd )
				{
					new IntervaleAngajat( this.AngajatID ).RestoreIntervaleAngajatPerioadaSterseTemporar( DataEnd.AddDays( 1 ), (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ] );
				}
				if((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ]<DataStart )
				{
					new IntervaleAngajat( this.AngajatID ).RestoreIntervaleAngajatPerioadaSterseTemporar((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ], DataStart.AddDays( -1 ));
				}					
			}
			iia.UpdateIntervalIntreruperiAngajat( IntervalID, DataStart, DataEnd, descriere );
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - UpdateIntervalIntreruperiPosibil() - actiune: " + tipActiune + " - idAng: " + AngajatID);
		}

		#endregion

		#region SaveIntervaleIntreruperiOperation
		/// <summary>
		/// Salveaza datele unui interval de intrerupere
		/// 
		/// Autor:		Fratila Claudia
		/// Data:		29.10.2007
		/// Descriere:	S-a adaugat un mesaj de avertizare la specificarea unei date care nu exista.
		///				Ex: 31.09.2007
		/// </summary>
		private void SaveIntervaleIntreruperiOperation()
		{
			DateTime DataStart = DateTime.Now;
			DateTime DataEnd = DateTime.Now;
			string [] IntervaleIntreruperiInfo  = this.IntervaleAbsenteSaveInfoID1.Value.Split( "^".ToCharArray());
				
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - SaveIntervalIntreruperiPosibil() - idAng: " + AngajatID);
						
			IntervaleIntreruperiAngajat iia = new IntervaleIntreruperiAngajat( this.AngajatID );
						
			for( int i=0; i<IntervaleIntreruperiInfo.Length; i++ )
			{
				string []  info = IntervaleIntreruperiInfo[ i ].Split( "#".ToCharArray());
				int IntervalID = int.Parse( info[0] );
					
				try
				{
					DataStart = Utilities.ConvertText2DateTime( info[ 1 ] );				
				}
				catch (Exception ex)
				{
					Response.Write( "<script> alert( '"+Definitions.alertInceput+"' );</script>" );
					return;
				}
				try
				{
					DataEnd = Utilities.ConvertText2DateTime( info[ 2 ] );				
				}
				catch (Exception ex)
				{
					Response.Write( "<script> alert( '"+Definitions.alertSfarsit+"' );</script>" );
					return;
				}
				
				string descriere = info[ 3 ];
				ActiuneInsertIntreruperiBDPosibil( DataStart, DataEnd, descriere, 1, IntervalID, iia );
			}	
			this.actionIntervale1.Value="";
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - SaveIntervalIntreruperiPosibil() - idAng: " + AngajatID);
		}

		#endregion

		#region DeleteIntervaleIntreruperiSelectateOperation
		/// <summary>
		/// Sterge un interval de intrerupere
		/// </summary>
		private void DeleteIntervaleIntreruperiSelectateOperation()
		{
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - start - DeleteIntervaleIntreruperiSelectateOperation() - idAng: " + AngajatID);
			
			string aux = this.IntervaleAbsenteSaveInfoID1.Value.Substring( 0, this.IntervaleAbsenteSaveInfoID1.Value.Length-1 );
						
			string []IntervaleInfo  = aux.Split("^".ToCharArray());
										
			IntervaleIntreruperiAngajat iia = new IntervaleIntreruperiAngajat( this.AngajatID );
				
			//Lungu Andreea - 12.11.2008
			int LunaActivaID = int.Parse(Session[SiemensHR.InterfataSalarii.Classes.Definitions.LunaCurentaKey].ToString());
			int AngajatorID = int.Parse(Session[SiemensHR.InterfataSalarii.Classes.Definitions.AngajatorKey].ToString());
			Salaries.Business.Luni l = new Salaries.Business.Luni(AngajatorID,LunaActivaID);
			DateTime dataLunaActiva = l.GetLunaActiva().Data;
			for( int i=0; i<IntervaleInfo.Length;i++)
			{
				int IntervalID = int.Parse( IntervaleInfo[ i ] );

				DataSet ds = iia.GetIntervalIntreruperiAngajatByID( IntervalID );
				if( ds.Tables[ 0 ].Rows.Count > 0 && ds != null )
				{
					if ((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ]<dataLunaActiva)
					{
						new IntervaleAngajat( this.AngajatID ).RestoreIntervaleAngajatPerioadaSterseTemporar(dataLunaActiva, (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ] );
						DateTime dataEndInt = dataLunaActiva.AddDays(-1);
						iia.UpdateIntervalIntreruperiAngajat( IntervalID,(DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ], dataEndInt, ds.Tables[ 0 ].Rows[ 0 ][ "Descriere" ].ToString());
					}
					else
					{
						new IntervaleAngajat( this.AngajatID ).RestoreIntervaleAngajatPerioadaSterseTemporar((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ], (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ] );
						iia.DeleteIntervalIntreruperiAngajat( IntervalID );
					}
					//new IntervaleAngajat( this.AngajatID ).RestoreIntervaleAngajatPerioadaSterseTemporar((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ], (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ] );
				}
				else
				{
					iia.DeleteIntervalIntreruperiAngajat( IntervalID );
				}
				string [][]tmp = GetOreLucrateIntervaleSpecialeLuna();				
				RedistribuireOreSuplimentareLunaAngajat( tmp );
			}	

			this.actionIntervale1.Value="";
			ErrHandler.MyErrHandler.WriteError("Intervale.ascx - end - DeleteIntervaleIntreruperiSelectatePosibil() - idAng: " + AngajatID);
		}

		#endregion

		#endregion

		#region Continuare absenta

		#region VerificaContinuareAbsenta
		/// <summary>
		/// Verifica continuarea absentei dupa data
		/// </summary>
		/// <param name="tipIntervalAbsentaID"></param>
		/// <param name="dataStart"></param>
		/// <returns></returns>
		public bool VerificaContinuareAbsenta( int tipIntervalAbsentaID, DateTime dataStart )
		{
			try
			{
				IntervaleAbsenteAngajat iaa = new IntervaleAbsenteAngajat( this.AngajatID );
				if( VerificaTipContinuareAbsenta( tipIntervalAbsentaID, iaa ))
				{
					if( VerificaLegaturaContinuareAbsenta( iaa, dataStart ))
					{
						return true;
					}
				}
			
				return false;
			}
			catch
			{
				return false;
			}
		}

		#endregion

		#region VerificaTipContinuareAbsenta
		/// <summary>
		/// Verifica continuarea absentei dupa tip
		/// </summary>
		/// <param name="tipIntervalAbsentaID"></param>
		/// <param name="iaa"></param>
		/// <returns></returns>
		public bool VerificaTipContinuareAbsenta( int tipIntervalAbsentaID, IntervaleAbsenteAngajat iaa )
		{
			try
			{
				DataSet dsTip = iaa.GetTipIntervalAbsentaAngajat( tipIntervalAbsentaID );
				if( dsTip.Tables[ 0 ].Rows[ 0 ][ "Denumire" ].ToString().ToLower() == Definitions.DenumireContinuareConcediuMedical.ToLower())
				{
					return true;
				}
				return false;
			}
			catch
			{
				return false;
			}
		}

		#endregion

		#region VerificaLegaturaContinuareAbsenta
		/// <summary>
		/// Verifica continuarea absentei dupa legatura
		/// </summary>
		/// <param name="iaa"></param>
		/// <param name="dataStart"></param>
		/// <returns></returns>
		private bool VerificaLegaturaContinuareAbsenta( IntervaleAbsenteAngajat iaa, DateTime dataStart )
		{
			DataSet ds = iaa.GetIntervalAbsentaAngajatByDataEnd( ZiuaPrecedenta( dataStart ));

			if( ds.Tables[ 0 ].Rows.Count == 1 )
			{
				DataRow dr = ds.Tables[ 0 ].Rows[ 0 ];
				if( dr[ "Denumire" ].ToString().ToLower() == Definitions.DenumireContinuareConcediuMedical.ToLower() ||
					dr[ "Denumire" ].ToString().ToLower() == Definitions.DenumireConcediuMedical.ToLower())
				{
					return true;
				}
			}
			return false;
		}

		#endregion

		#endregion

		#region ZiuaPrecedenta
		/// <summary>
		/// Procedura determina ziua precedenta unei date
		/// </summary>
		/// <param name="dt">Data</param>
		/// <returns>Returneaza ziua precedenta</returns>
		private DateTime ZiuaPrecedenta( DateTime dt )
		{
			return dt.AddDays( -1 );
		}

		#endregion

		#region ZiuaUrmatoare
		/// <summary>
		/// Procedura determina ziua urmatoare unei date
		/// </summary>
		/// <param name="dt">Data</param>
		/// <returns>Returneaza ziua urmatoare</returns>
		private DateTime ZiuaUrmatoare( DateTime dt )
		{
			return dt.AddDays( 1 );
		}
		#endregion

	}
}
