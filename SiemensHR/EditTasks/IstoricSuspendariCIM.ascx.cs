/*
 * Modificat:	Lungu Andreea
 * Data:		17.12.2009
 * Descriere:	S-a adaugat log.
 */

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

//using SiemensHR.utils;
using SiemensHR.Classes;
using SiemensTM.Classes;
using SiemensTM.utils;

namespace SiemensHR.EditTasks
{
	/// <summary>
	///		Summary description for IstoricCartiIdentitate.
	/// </summary>
	public class IstoricSuspendariCIM : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.Button btnModificaDate;
		protected System.Web.UI.WebControls.Button btnStergeDate;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlInputText DateStart;
		protected System.Web.UI.HtmlControls.HtmlInputText DateEnd;
		protected System.Web.UI.WebControls.Button btnAdaugaSuspendare;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldRegExprDescriere;
		protected System.Web.UI.WebControls.TextBox txtObservatii;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtIntrerupereID;

		public long AngajatID;
		protected System.Web.UI.WebControls.TextBox txtDataStart;
		protected System.Web.UI.WebControls.TextBox txtDataEnd;
		public DateTime dataStartLunaActiva;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			
			Response.Write( "<script>var DateStartID = '"+this.DateStart.ClientID+"';</script>");
			Response.Write( "<script>var DateEndID = '"+this.DateEnd.ClientID+"';</script>");
			Response.Write( "<script>var txtDataStartID = '"+this.txtDataStart.ClientID+"';</script>");
			Response.Write( "<script>var txtDataEndID = '"+this.txtDataEnd.ClientID+"';</script>");
			
			this.txtDataStart.Attributes["onblur"] = " if (document.getElementById(txtDataStartID).value!='') {getIntervalIntreruperi('"+this.ClientID+"').DataStartChanged();" +
								"document.getElementById(DateStartID).value=document.getElementById(txtDataStartID).value;" +
								"if (!isDate(document.getElementById(txtDataStartID).value)) { alert('Data de inceput nu este corecta!'); document.getElementById(txtDataStartID).value='';} }";
			this.txtDataEnd.Attributes["onblur"] = " if (document.getElementById(txtDataEndID).value!='') {getIntervalIntreruperi('"+this.ClientID+"').DataEndIntrerupereChanged(); " +
								"document.getElementById(DateEndID).value=document.getElementById(txtDataEndID).value;" +
								"if (!isDate(document.getElementById(txtDataEndID).value))  { alert('Data de sfarsit nu este corecta!'); document.getElementById(txtDataEndID).value='';} }";
		
			this.txtObservatii.Attributes[ "onblur" ] = "getIntervalIntreruperi('"+this.ClientID+"').ObservatiiIntreruperiChanged()";

			string[] textTabs = {"Istoric intreruperi CIM", "Adauga intrerupere CIM"};
			LoadIstoricSuspendariCIM();

			SiemensTM.utils.Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);
			Response.Write("<script> var TipUtilizator = ''; </script>");

			Salaries.Business.Angajat objAngajat = new Salaries.Business.Angajat();
			objAngajat.AngajatId = AngajatID;
			objAngajat.LoadAngajat();
			
			Salaries.Business.Luni luni = new Salaries.Business.Luni( objAngajat.AngajatorId );
			Salaries.Data.LunaData lunaData = luni.GetLunaActiva();
			dataStartLunaActiva = lunaData.Data;

			Response.Write("<script>LunaActivaDataStart =  '"+dataStartLunaActiva.ToString("dd.MM.yyyy")+"'</script>");			
			btnStergeDate.Attributes.Add("onclick","return CheckDelete('Sunteti sigur ca vreti sa stergeti intreruperea?');");
		}
		#endregion

		#region Render
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render (writer);
			
			Salaries.Business.Angajat objAngajat = new Salaries.Business.Angajat();
			objAngajat.AngajatId = AngajatID;
			objAngajat.LoadAngajat();
			
			/* Description:Pentru a nu se permite introducerea unui tip de absenta cand angajatul este lichidat, 
			 * este obtinuta data lichidarii si scrisa pe javascript pentru a se putea face validarile.
			 */
			string dataLichidare;
			if((DateTime.Equals(objAngajat.DataLichidare, System.DBNull.Value)) || (DateTime.Equals(objAngajat.DataLichidare,DateTime.MinValue)))
				dataLichidare = DateTime.MaxValue.ToString("dd.MM.yyyy");
			else
				dataLichidare = objAngajat.DataLichidare.ToString("dd.MM.yyyy");
			Response.Write("<script>DataLichidare =  '"+dataLichidare+"'</script>");
			
			DateTime DataAngajare = objAngajat.DataDeLa;
			Response.Write("<script>AngajareDataStart =  '"+DataAngajare.ToString("dd.MM.yyyy")+"'</script>");
	

			Response.Write( "<script>var DataStartIntrerupere = '"+this.txtDataStart.ClientID+"';</script>");
			Response.Write( "<script>var DataEndIntrerupere = '"+this.txtDataEnd.ClientID+"';</script>");
			//Response.Write( "<script>var CheckIntreruperi = '"+this.CheckInterval.ClientID+"';</script>");
			Response.Write( "<script>var IntervIntreruperiID = '"+this.txtIntrerupereID.ClientID+"';</script>");
			Response.Write( "<script>var ObservatiiIDIntrerupere = '"+this.txtObservatii.ClientID+"';</script>");
			Response.Write( "<script>var ClientObservatiiID = '"+this.txtObservatii.ClientID+"';</script>");
					
			string valoare = "<script>var tmpIntreruperi = new CreateIntervalIntreruperiElement('"+this.ClientID+"','"+this.txtDataStart.ClientID+"','"+this.txtDataEnd.ClientID+"','"+this.txtIntrerupereID.ClientID+"',null,'"+this.txtObservatii.ClientID+"');</script>";
			Response.Write( valoare );	
		}
		#endregion

		#region LoadIstoricSuspendariCIM
		/// <summary>
		/// Listeaza suspendarile contractului individual de munca
		/// </summary>
		private void LoadIstoricSuspendariCIM()
		{
			try
			{
				listTable.Rows.Clear();

				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

				IntervaleIntreruperiAngajat istSuspCIM = new IntervaleIntreruperiAngajat(AngajatID);
				
				string[] arHeader = {"Data de inceput", "Data de sfarsit", "Observatii"};
				string[] arCols = {"DataStart", "DataEnd", "Descriere"};
				
				SiemensHR.Classes.ListTable objListTable = new SiemensHR.Classes.ListTable(listTable, istSuspCIM.LoadIntreruperiCIM(), arHeader, arCols);
				objListTable.textForEmptyDataSet = "Nu exista nici o intrerupere a contractului individual de munca asociata acestui angajat!";

				string[] ar_OnClickParam = { AngajatID.ToString(), "AngajatIntrerupereID", "DataStart", "DataEnd", "Descriere"};
				string[] ar_OnClickParamType = { "const", "dataset", "dataset", "dataset","dataset"};
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectSuspendareCIM";

				objListTable.DrawListTableWithoutDigits();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
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
			this.btnAdaugaSuspendare.Click += new System.EventHandler(this.btnAdaugaSuspendare_Click);
			this.btnModificaDate.Click += new System.EventHandler(this.btnModificaDate_Click);
			this.btnStergeDate.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdaugaSuspendare_Click
		/// <summary>
		/// Adauga o intrerupere CIM
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaSuspendare_Click(object sender, System.EventArgs e)
		{
			ErrHandler.MyErrHandler.WriteError("IstoricSuspendariCIM.ascx - start - AdaugaSuspendare() - angID: " + AngajatID + " - " + txtDataStart.Text + " - " + txtDataEnd.Text);
			try
			{
				DateTime dataStart = SiemensTM.utils.Utilities.ConvertText2DateTime( DateStart.Value/*txtDataStart.Text*/ );
				DateTime dataEnd = SiemensTM.utils.Utilities.ConvertText2DateTime( DateEnd.Value/*txtDataEnd.Text*/ );
				string observatii = txtObservatii.Text;
				int intrerupereId = Convert.ToInt32(txtIntrerupereID.Value);
						
				//IntervaleIntreruperiAngajat interv = new IntervaleIntreruperiAngajat(AngajatID);
				ActiuneInsertIntreruperiBDPosibil( dataStart, dataEnd, observatii, 0, -1, null );
				LoadIstoricSuspendariCIM();
				this.txtDataStart.Text = "";
				this.txtDataEnd.Text = "";
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
				ErrHandler.MyErrHandler.WriteError("IstoricSuspendariCIM.ascx - error - - angID: " + AngajatID + " - " + ex.Message);
			}
			ErrHandler.MyErrHandler.WriteError("IstoricSuspendariCIM.ascx - end - AdaugaSuspendare() - angID: " + AngajatID);
		}
		#endregion

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
					this.txtDataStart.Text = "";
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaAbsenteInceput+"' );</script>" );
					break;
				case 2:
					this.txtDataEnd.Text = "";
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaAbsenteSfarsit+"' );</script>" );
					break;
				case 3:
					this.txtDataStart.Text = "";
					this.txtDataEnd.Text = "";
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
					this.txtDataStart.Text = "";
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntreruperiInceput+"' );</script>" );
					break;
				case 7:
					this.txtDataEnd.Text = "";
					Response.Write( "<script> alert( '"+Definitions.alertAdaugaIntreruperiSfarsit+"' );</script>" );
					break;
				case 8:
					this.txtDataStart.Text = "";
					this.txtDataEnd.Text = "";
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
			DateTime dataSt = new DateTime( this.dataStartLunaActiva.Year, this.dataStartLunaActiva.Month, 1 );
			DateTime dataEnd = new DateTime( this.dataStartLunaActiva.Year, this.dataStartLunaActiva.Month, DateTime.DaysInMonth( this.dataStartLunaActiva.Year, this.dataStartLunaActiva.Month ));
								
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
			/*string dataS = "";
			try
			{
				dataS = SiemensTM.utils.Utilities.ConvertToShort(SiemensTM.utils.Utilities.ConvertText2DateTime(this.txtDataEnd.Text).AddDays( 1 )).ToString();
			}
			catch (Exception ex)
			{
				Response.Write( "<script> alert( '"+Definitions.alertInceput+"' );</script>" );
				return;
			}
			char []split = new char[ 1 ]; split[ 0 ] = ' ';
			dataS = dataS.Split( split )[ 0 ];

			this.txtDataStart.Text = dataS;
			this.txtDataEnd.Text = "";*/
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
		}

		#endregion

		#region RedistribuireOreSuplimentareLunaAngajat
		/// <summary>
		/// Procedura redistribuie orele suplimentare ale angajatului
		/// </summary>
		/// <param name="tmp"></param>
		private void RedistribuireOreSuplimentareLunaAngajat( string [][]tmp )
		{
			for( int j=0; j<tmp.Length; j++ )
			{

				int tipIntervalID = int.Parse( tmp[ j ][ 0 ] );
				double nrOreSuplimentare = double.Parse( tmp[ j ][ 1 ] );
				int tipOraSupl = bool.Parse( tmp[ j ][ 2 ].ToLower())? 1 : 0;

				double nrOreSuplimentare_old = 0;

				int valEroare = new IntervaleAngajat( this.AngajatID ).DistribuieOreSuplimentareTip( this.dataStartLunaActiva, tipIntervalID, nrOreSuplimentare, nrOreSuplimentare_old, tipOraSupl );
				if( valEroare == 1 )
				{
					Response.Write( "<script>alert( 'Numarul de ore suplimentare depaseste numarul de ore disponibile!' );</script>" );
				}
			}
		}

		#endregion	

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica o intrerupere CIM
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click(object sender, System.EventArgs e)
		{
			ErrHandler.MyErrHandler.WriteError("IstoricSuspendariCIM.ascx - start - ModificaSuspendare() - angID: " + AngajatID + " - " + txtDataStart.Text + " - " + txtDataEnd.Text);
			try
			{
				DateTime dataStart = SiemensTM.utils.Utilities.ConvertText2DateTime( DateStart.Value );
				DateTime dataEnd = SiemensTM.utils.Utilities.ConvertText2DateTime( DateEnd.Value );
				string observatii = txtObservatii.Text;
				int intrerupereId = Convert.ToInt32(txtIntrerupereID.Value);
				IntervaleIntreruperiAngajat iia = new IntervaleIntreruperiAngajat( this.AngajatID );
				ActiuneInsertIntreruperiBDPosibil( dataStart, dataEnd, observatii, 1, intrerupereId, iia );
				LoadIstoricSuspendariCIM();
				this.txtDataStart.Text = "";
				this.txtDataEnd.Text = "";
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
				ErrHandler.MyErrHandler.WriteError("IstoricSuspendariCIM.ascx - error - ModificaSuspendare() - angID: " + AngajatID + " - " + ex.Message);
			}
			ErrHandler.MyErrHandler.WriteError("IstoricSuspendariCIM.ascx - end - ModificaSuspendare() - angID: " + AngajatID);
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge o intrerupere CIM
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			ErrHandler.MyErrHandler.WriteError("IstoricSuspendariCIM.ascx - start - StergeSuspendare() - angID: " + AngajatID  + " - " + txtDataStart.Text + " - " + txtDataEnd.Text);

			DateTime dataStart = SiemensTM.utils.Utilities.ConvertText2DateTime( DateStart.Value );
			DateTime dataEnd = SiemensTM.utils.Utilities.ConvertText2DateTime( DateEnd.Value );
			string observatii = txtObservatii.Text;
			int intrerupereId = Convert.ToInt32(txtIntrerupereID.Value);
			IntervaleIntreruperiAngajat iia = new IntervaleIntreruperiAngajat( this.AngajatID );
		 	

			DataSet ds = iia.GetIntervalIntreruperiAngajatByID( intrerupereId );
				
			if( ds.Tables[ 0 ].Rows.Count > 0 && ds != null )
			{
				if ((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ]<dataStartLunaActiva)
				{
					new IntervaleAngajat( this.AngajatID ).RestoreIntervaleAngajatPerioadaSterseTemporar(dataStartLunaActiva, (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ] );
					DateTime dataEndInt = dataStartLunaActiva.AddDays(-1);
					iia.UpdateIntervalIntreruperiAngajat( intrerupereId,(DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ], dataEndInt, ds.Tables[ 0 ].Rows[ 0 ][ "Descriere" ].ToString());
				}
				else
				{
					new IntervaleAngajat( this.AngajatID ).RestoreIntervaleAngajatPerioadaSterseTemporar((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ], (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ] );
					iia.DeleteIntervalIntreruperiAngajat( intrerupereId );
				}
			}
			else
			{
				iia.DeleteIntervalIntreruperiAngajat( intrerupereId );
			}
			string [][]tmp = GetOreLucrateIntervaleSpecialeLuna();				
			RedistribuireOreSuplimentareLunaAngajat( tmp );
			LoadIstoricSuspendariCIM();
			this.txtDataStart.Text = "";
			this.txtDataEnd.Text = "";

			ErrHandler.MyErrHandler.WriteError("IstoricSuspendariCIM.ascx - end - StergeSuspendare() - angID: " + AngajatID);
		}
		#endregion
	}
}
