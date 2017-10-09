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
using System.Data.SqlClient;

using Salaries.Business;
using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for Admin_NomenclatorSarbatoriLegale.
	/// </summary>
	public class Admin_NomenclatorSarbatoriLegale :  SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.Button btnAdauga;
		protected System.Web.UI.WebControls.Button btnModificaDate;
		protected System.Web.UI.WebControls.Button btnStergeDate;
		protected System.Web.UI.WebControls.TextBox old_DataStart;
		protected System.Web.UI.WebControls.Literal errorLit;
		protected System.Web.UI.WebControls.TextBox txtSarbatoriLegaleDenum;
		protected System.Web.UI.WebControls.TextBox txtSarbatoriLegaleDescr;
		protected System.Web.UI.WebControls.TextBox txtAddDateSarbatoriLegale;
		protected System.Web.UI.WebControls.DropDownList lstFunctie;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.ValidationSummary vldSummary;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredData;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDescriere;
		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.ClientID+"\"</script>";
			Response.Write(script_text);
		
			btnStergeDate.Attributes.Add("onclick", "return CheckDelete('Stergerea unei sarbatori din luna activa va avea ca si efect recalcularea situatiei lunare a angajatilor. \\nDoriti sa stergeti aceasta sarbatoare?')");

			string[] textTabs = {"Sarbatori legale", "Adauga"};
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "../", true);

			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var requiredData = \"" + requiredData.ClientID + "\"</script>");
			Response.Write("<script>var regularDescriere = \"" + regularDescriere.ClientID + "\"</script>");
            Response.Write("<script>var Regularexpressionvalidator2 = \"" + Regularexpressionvalidator2.ClientID + "\"</script>");
	
			LoadSarbatoriLegale();

			old_DataStart.Style.Add("display","none");
		}
		#endregion

		#region LoadSarbatoriLegale
		/// <summary>
		/// Listeaza sarbatorile legale
		/// </summary>
		private void LoadSarbatoriLegale()
		{
			try
			{
				listTable.Rows.Clear();
				Salaries.Business.SarbatoriLegale sarbatori = new Salaries.Business.SarbatoriLegale();
				DataSet ds = sarbatori.LoadSarbatoriLegale();

				lstFunctie.DataSource = ds;
				lstFunctie.DataValueField = "Data";
				lstFunctie.DataTextField = "Denumirea";
				lstFunctie.DataBind();		

				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");
				
				string[] arHeader = {"Data", "Denumirea", "Descrierea"};
				string[] arCols = {"Data", "Denumirea", "Descrierea"};
				ListTable objListTable = new ListTable(listTable, ds, arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista sarbatori legale!";

				string[] ar_OnClickParam = {"Data", "Denumirea", "Descrierea"};
				string[] ar_OnClickParamType = {"dataset", "dataset", "dataset"};
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectFunctie";

				objListTable.DrawListTableWithoutDigits();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}	
		}
		#endregion
	
		#region btnSaveSarbatoriLegale_Click
		/// <summary>
		/// Salveaza o sarbatoare legala
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSaveSarbatoriLegale_Click(object sender, System.EventArgs e)
		{
			ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - start - Save() - " + txtAddDateSarbatoriLegale.Text);
			try
			{
				Salaries.Business.SarbatoriLegale sarbatori = new Salaries.Business.SarbatoriLegale();
				DateTime dataSarbatoare = Convert.ToDateTime(txtAddDateSarbatoriLegale.Text);
				sarbatori.DataSarbatoare = dataSarbatoare;
				if(sarbatori.CheckInsertSarbatoareLegala())
				{
					if(DataDupaLunaCurenta( dataSarbatoare ) || DataInLunaCurenta( dataSarbatoare ))
					{
						sarbatori.Denumire = txtSarbatoriLegaleDenum.Text;
						sarbatori.Descriere = txtSarbatoriLegaleDescr.Text;
						sarbatori.DataSarbatoare = dataSarbatoare;
						sarbatori.InsertSarbatoareLegala();
						
						if( DataInLunaCurenta( dataSarbatoare ))
						{
							ReinitializeazaLuna( dataSarbatoare, true );
						}

						LoadSarbatoriLegale();
					}
					else
					{
						ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - Save() - 'Nu puteti sa introduceti sarbatori specifice unei luni anterioare celei active!!!'");
						Response.Write( "<script>alert( 'Nu puteti sa introduceti sarbatori specifice unei luni anterioare celei active!!!' );</script>" );
					}
				}
				else
				{
					ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - Save() - 'Nu puteti sa introduceti doua sarbatori in aceeasi zi!!!'");
					Response.Write( "<script>alert( 'Nu puteti sa introduceti doua sarbatori in aceeasi zi!!!' );</script>" );
				}
			}
			catch(Exception ex)
			{
				errorLit.Text="Adaugarea esuata!!!"+ex.Message;
				ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - error - Save() - " + ex.Message);
			}
			ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - end - Save()");
		}
		#endregion

		#region btnUpdateSarbatoriLegale_Click
		/// <summary>
		/// Actualizeaza o sarbatoare legala
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUpdateSarbatoriLegale_Click(object sender, System.EventArgs e)
		{
			ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - start - Update() - " + txtAddDateSarbatoriLegale.Text);
			try
			{
				Salaries.Business.SarbatoriLegale sarbatori = new Salaries.Business.SarbatoriLegale();
				DateTime dataSarbatoare = Convert.ToDateTime(txtAddDateSarbatoriLegale.Text);
				DateTime old_dataSarbatoare = Convert.ToDateTime(old_DataStart.Text);
				sarbatori.DataSarbatoare = dataSarbatoare;

				//daca a fost aleasa o noua data pentru sarbatoare 
				if (dataSarbatoare.Date != old_dataSarbatoare.Date)
				{
					//se verifica sa nu mai existe o alta sarbatoare in acea zi
					if(sarbatori.CheckInsertSarbatoareLegala())
					{
						//daca data aleasa este corecta se adauga sarbatoarea in tabela
						if( DataDupaLunaCurenta( dataSarbatoare) || DataInLunaCurenta( dataSarbatoare))
						{
							sarbatori.Denumire = txtSarbatoriLegaleDenum.Text;
							sarbatori.Descriere = txtSarbatoriLegaleDescr.Text;
							sarbatori.DataSarbatoare = dataSarbatoare;
							sarbatori.UpdateSarbatoareLegala(old_dataSarbatoare);

							if( DataInLunaCurenta( dataSarbatoare ))
							{
								SetDataTipSarbatoare(old_dataSarbatoare, false);//scoaterea vechii date din tm_zile
								ReinitializeazaLuna( dataSarbatoare, true );
							}

							LoadSarbatoriLegale();
						}
						else
						{
							ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - Save() - 'Nu puteti sa introduceti sarbatori specifice unei luni anterioare lunii active!!!'");	
							Response.Write( "<script>alert( 'Nu puteti sa introduceti sarbatori specifice unei luni anterioare lunii active!!!' );</script>" );
						}
					}
					else
					{
						ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - Save() - 'Nu puteti sa introduceti doua sarbatori in aceeasi zi!!!'");
						Response.Write( "<script>alert( 'Nu puteti sa introduceti doua sarbatori in aceeasi zi!!!' );</script>" );
					}
				}
				//daca nu a fost modificata data sarbatorii nu mai trebuie verificata pentru a fi unica
				//ea este deja pentru ca a fost verificata la adaugare
				else
				{
					//se mai verifica doar sa fie in luna activa
					if( DataDupaLunaCurenta( dataSarbatoare) || DataInLunaCurenta( dataSarbatoare))
					{
						sarbatori.Denumire = txtSarbatoriLegaleDenum.Text;
						sarbatori.Descriere = txtSarbatoriLegaleDescr.Text;
						sarbatori.DataSarbatoare = dataSarbatoare;
						sarbatori.UpdateSarbatoareLegala(old_dataSarbatoare);

						//Lungu Andreea - 29.06.2009
						//daca este aceeasi data, vechea data nu trebuie scoasa din tm_zile
						//inseamna ca am modificat doar detalii de denumire si descriere
						/*if( DataInLunaCurenta( dataSarbatoare ))
						{
							SetDataTipSarbatoare(old_dataSarbatoare, false);//scoaterea vechii date din tm_zile
							//ReinitializeazaLuna( dataSarbatoare, true );
						}*/

						LoadSarbatoriLegale();
					}
					else
					{
						ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - Save() - 'Nu puteti sa introduceti sarbatori specifice lunii unei luni anterioare lunii active!!!'");
						Response.Write( "<script>alert( 'Nu puteti sa introduceti sarbatori specifice lunii unei luni anterioare lunii active!!!' );</script>" );
					}
				}
			}
			catch(Exception ex)
			{
				errorLit.Text="Editarea esuata!!!"+ex.Message;
				ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - error - Update() - " + ex.Message);
			}	
			ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - end - Update() - " + txtAddDateSarbatoriLegale.Text);
		}
		#endregion
			
		#region btnDelete_Click
		/// <summary>
		/// Sterge o sarbatoare legala
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - start - Delete() - " + txtAddDateSarbatoriLegale.Text);
			try
			{
				Salaries.Business.SarbatoriLegale sarbatori = new Salaries.Business.SarbatoriLegale();
				DateTime dataSarbatoare = Convert.ToDateTime(txtAddDateSarbatoriLegale.Text);
				if( DataDupaLunaCurenta( dataSarbatoare) || DataInLunaCurenta( dataSarbatoare ))
				{
					sarbatori.Denumire = "";
					sarbatori.Descriere = "";
					sarbatori.DataSarbatoare = dataSarbatoare;
					sarbatori.DeleteSarbatoareLegala();

					if( DataInLunaCurenta( dataSarbatoare ))
					{
						ReinitializeazaLuna( dataSarbatoare, false ); 
					}

					LoadSarbatoriLegale();
				}
				else
				{
					ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - start - Delete() - 'Nu puteti sa stergeti sarbatori specifice unei luni anterioare lunii active!!!'");
					Response.Write( "<script>alert( 'Nu puteti sa stergeti sarbatori specifice unei luni anterioare lunii active!!!' );</script>" );
				}
			}
			catch(Exception errDelete)
			{
				errorLit.Text="Stergerea esuata!!!"+errDelete.Message ;
				ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - Delete() - " + errDelete.Message);
			}
			ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - end - Delete() - " + txtAddDateSarbatoriLegale.Text);
		}
		#endregion

		#region DataInLunaCurenta
		/// <summary>
		/// Proceudra verifica daca o data este in luna curenta
		/// </summary>
		/// <param name="data">Date care se verifica</param>
		/// <returns>Returneaza true daca e in luna curenta si false altfel</returns>
		private bool DataInLunaCurenta( DateTime data )
		{
			Luni l = new Luni( this.GetAngajator());
			Salaries.Data.LunaData ld = l.GetLunaActiva();
			return (ld.Data.Month == data.Month) && (ld.Data.Year == data.Year);
		}
		#endregion

		#region DataDupaLunaCurenta
		/// <summary>
		/// Procedura verifica daca data este dupa luna activa
		/// </summary>
		/// <param name="data">Data verificata</param>
		/// <returns>Returneaza true daca e dupa luna activa si false altfel</returns>
		private bool DataDupaLunaCurenta( DateTime data )
		{
			Luni l = new Luni( this.GetAngajator());
			Salaries.Data.LunaData ld = l.GetLunaActiva();
			DateTime dataUltimaZiLunaActiva = ld.Data.AddMonths( 1 );
			return dataUltimaZiLunaActiva<=data;
		}
		#endregion
		
		#region ReinitializeazaLuna
		/// <summary>
		/// Procedura reinitializeaza o luna
		/// </summary>
		/// <param name="dataSarbatoare"></param>
		/// <param name="sarbatoare"></param>
		private void ReinitializeazaLuna( DateTime dataSarbatoare, bool sarbatoare)
		{
			ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - start - ReinitializeazaLuna() - " + dataSarbatoare.ToShortDateString() + " - " + sarbatoare.ToString());
			//seteaza in tm_zile data ca fiind sarbatoare
			SetDataTipSarbatoare(dataSarbatoare, sarbatoare);

			//reinitializare ore (normale si suplimentare) din luna activa pt toti angajatii activi
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.CategorieId = -1;
			angajat.AngajatorId = GetAngajator(); 

			//Modificat:Muntean Raluca Cristina  - am adaugat ca parametru si id-ul angajatorului
			DataSet ds = angajat.GetAllAngajati();//toti angajatii activi
			foreach( DataRow dr in ds.Tables[ 0 ].Rows )
			{
				ReinitializeOreLunaActivaAngajat( long.Parse( dr[ "AngajatID" ].ToString()));
			}
			ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - end - ReinitializeazaLuna() - " + dataSarbatoare.ToShortDateString() + " - " + sarbatoare.ToString());	
		}
		#endregion
		
		#region SetDataTipSarbatoare
		/// <summary>
		/// Procedura seteaza o data ca fiind sarbatoare
		/// </summary>
		/// <param name="dataSarbatoare">Data specificata</param>
		/// <param name="sarbatoare">Este sarbatoare sau nu</param>
		private void SetDataTipSarbatoare(DateTime dataSarbatoare, bool sarbatoare)
		{
			ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - start - SetDataTipSarbatoare() - " + dataSarbatoare.ToShortDateString() + " - " + sarbatoare.ToString());
			try
			{
				Salaries.Business.SarbatoriLegale sarbatori = new Salaries.Business.SarbatoriLegale();
				sarbatori.DataSarbatoare = dataSarbatoare;
				bool parametruSarbatoare = sarbatoare;
				if(!sarbatoare)
				{
					if(!IsWeekEnd(dataSarbatoare))
					{
						parametruSarbatoare = sarbatoare;
					}
					else
					{
						parametruSarbatoare = !sarbatoare;
					}
				}
				else
				{
					parametruSarbatoare = sarbatoare;				
				}
				sarbatori.SetDataTipSarbatoare(parametruSarbatoare);
			}
			catch(Exception exc)
			{
				ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - error - SetDataTipSarbatoare() - " + dataSarbatoare.ToShortDateString() + " - " + sarbatoare.ToString() + " - " + exc.Message);
			}
			ErrHandler.MyErrHandler.WriteError("Admin_NomenclatorSarbatoriLegale.ascx - end - SetDataTipSarbatoare() - " + dataSarbatoare.ToShortDateString() + " - " + sarbatoare.ToString());
		}
		#endregion
		
		#region IsWeekEnd
		/// <summary>
		/// Procedura verifica daca o data este zi de weekend
		/// </summary>
		/// <param name="dt">Data verificata</param>
		/// <returns>Returneaza true daca e zi de weekend si false altfel</returns>
		public bool IsWeekEnd(DateTime dt)
		{
			System.Globalization.GregorianCalendar x = new System.Globalization.GregorianCalendar();				
			System.DayOfWeek dow = x.GetDayOfWeek(dt);
			return (dow==System.DayOfWeek.Saturday || dow==System.DayOfWeek.Sunday);
		}
		#endregion

		#region ReinitializeOreLunaActivaAngajat
		/// <summary>
		/// Reinitializare ore (normale si suplimentare)
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		private void ReinitializeOreLunaActivaAngajat( long angajatID )
		{
			//preluare ore normale si suplimentare
			Salaries.Data.LunaData lunaData = new Luni( this.GetAngajator()).GetLunaActiva();

			PontajAngajat pa = new PontajAngajat( angajatID );
			Salaries.Data.IntervaleSchimbariLuna []intervSL = pa.GetIntervaleSchimbariLuna( lunaData.LunaId );

			float nrOreLucrate = 0;
			float nrOreSuplimentare50 = 0;
			float nrOreSuplimentare100 = 0;

			float []intervaleNrOreLucrate = new float[ intervSL.Length ];
			int i=0;
			foreach( Salaries.Data.IntervaleSchimbariLuna interv in intervSL )
			{

				int nrZileLucratoareLuna = pa.GetNrZileLucratoarePerioada( interv.DataStart, interv.DataEnd );

				TimeSpan nrOreLucrateLuna = pa.GetAngajatNrOreTipLucrate( interv.DataStart, interv.DataEnd, Salaries.Business.SituatieLunaraAngajat.denumireOreLucrate[ 0 ] );
				TimeSpan nrOreSuplimentare50Luna = pa.GetAngajatNrOreTipLucrate( interv.DataStart, interv.DataEnd, Salaries.Business.SituatieLunaraAngajat.denumireOreLucrate[ 1 ] );
				TimeSpan nrOreSuplimentare100Luna = pa.GetAngajatNrOreTipLucrate( interv.DataStart, interv.DataEnd, Salaries.Business.SituatieLunaraAngajat.denumireOreLucrate[ 2 ] );

				nrOreLucrate += nrOreLucrateLuna.Days*24+nrOreLucrateLuna.Hours+(float)nrOreLucrateLuna.Minutes/60;
				nrOreSuplimentare50 += nrOreSuplimentare50Luna.Days*24+nrOreSuplimentare50Luna.Hours+(float)nrOreSuplimentare50Luna.Minutes/60;
				nrOreSuplimentare100 += nrOreSuplimentare100Luna.Days*24+nrOreSuplimentare100Luna.Hours+(float)nrOreSuplimentare100Luna.Minutes/60;

				intervaleNrOreLucrate[ i ] = nrOreLucrateLuna.Days*24+nrOreLucrateLuna.Hours+(float)nrOreLucrateLuna.Minutes/60;
				i++;
			}
			//stergere ore din luna activa
			SiemensTM.Classes.IntervaleAngajat ia = new SiemensTM.Classes.IntervaleAngajat( angajatID );
			ia.DeleteIntervaleVizibileAngajatPerioada( lunaData.Data, new DateTime( lunaData.Data.Year, lunaData.Data.Month, DateTime.DaysInMonth( lunaData.Data.Year, lunaData.Data.Month )));

			//reinitializarea angajatului
			for( i=0; i<intervaleNrOreLucrate.Length; i++ )
			{
				//reinitializare pe intervale de zile
				ia.InitializeOreLucratePerioadaAngajatFromIntervalSchimbare( lunaData.Data, intervSL[ i ] );
			}

			//initializeaza orele suplimentare 100%
			int tipIntervalID = new SiemensTM.Classes.IntervaleAngajat( angajatID ).GetTipIntervalIDByName( Salaries.Business.SituatieLunaraAngajat.denumireOreLucrate[ 1 ] );
			double nrOreSuplimentare = nrOreSuplimentare50;
			double nrOreSuplimentare_old = 0;
			if( tipIntervalID > 0 )
			{
				ia.DistribuieOreSuplimentareInRegimNormal( lunaData.Data, nrOreSuplimentare50, tipIntervalID, nrOreSuplimentare_old );
			}

			//initializeaza orele suplimentare 200%
			tipIntervalID = new SiemensTM.Classes.IntervaleAngajat( angajatID ).GetTipIntervalIDByName( Salaries.Business.SituatieLunaraAngajat.denumireOreLucrate[ 2 ] );
			nrOreSuplimentare = nrOreSuplimentare100;
			if( tipIntervalID > 0 )
			{
				ia.DistribuieOreSuplimentareInRegimWeekendNoapte( lunaData.Data, nrOreSuplimentare, tipIntervalID, nrOreSuplimentare_old );
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
			this.btnAdauga.Click += new System.EventHandler(this.btnSaveSarbatoriLegale_Click);
			this.btnModificaDate.Click += new System.EventHandler(this.btnUpdateSarbatoriLegale_Click);
			this.btnStergeDate.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}

