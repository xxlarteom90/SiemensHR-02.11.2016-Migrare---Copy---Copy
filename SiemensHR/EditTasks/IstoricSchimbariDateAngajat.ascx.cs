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
using System.Globalization;
using System.Threading;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.EditTasks
{
	/// <summary>
	///		Summary description for IstoricSchimbariDateAngajat.
	/// </summary>
	public class IstoricSchimbariDateAngajat : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnModificaDate;
		protected System.Web.UI.WebControls.TextBox txtDataStartProgramLucru;
		protected System.Web.UI.WebControls.TextBox txtProgramLucru;
		protected System.Web.UI.WebControls.TextBox txtDataStartSalariuBaza;
		protected System.Web.UI.WebControls.TextBox txtDataStartIndemnizatieConducere;
		protected System.Web.UI.WebControls.DropDownList chkLstInvalid;
		protected System.Web.UI.WebControls.TextBox txtDataStartInvaliditate;
		protected System.Web.UI.WebControls.DropDownList lstCategorie;
		protected System.Web.UI.WebControls.TextBox txtDataStartCategorie;
		protected System.Web.UI.WebControls.TextBox txtIndemnizatieConducere;
		protected System.Web.UI.WebControls.Button btnStergeDate;
		protected System.Web.UI.WebControls.Button btnAdaugaSchimbare;
		protected System.Web.UI.WebControls.TextBox txtEditDataStartNormaLucru;
		protected System.Web.UI.WebControls.TextBox txtEditSalariuBaza;
		protected System.Web.UI.WebControls.TextBox txtEditDataStartSalariuBaza;
		protected System.Web.UI.WebControls.TextBox txtEditIndemnizatieConducere;
		protected System.Web.UI.WebControls.TextBox txtEditDataStartIndemnizatieConducere;
		protected System.Web.UI.WebControls.RadioButtonList chkEditLstInvalid;
		protected System.Web.UI.WebControls.TextBox txtEditDataStartInvaliditate;
		protected System.Web.UI.WebControls.DropDownList lstEditCategorie;
		protected System.Web.UI.WebControls.TextBox txtEditDataStartCategori;
		protected System.Web.UI.WebControls.TextBox txtEditProgramLucru;
		protected System.Web.UI.HtmlControls.HtmlInputHidden del_DataStart;
		protected System.Web.UI.HtmlControls.HtmlInputHidden del_DataEnd;
		protected System.Web.UI.HtmlControls.HtmlInputHidden del_AngajatID;
		protected System.Web.UI.WebControls.Button btnAnuleaza;

		protected string programLucru;
		protected string lstInvalid;
		protected string categorie;
		protected Salaries.Business.Luni luna;
		protected Salaries.Data.LunaData lunaActiva;
		private NumberFormatInfo numberInfoFormat;

		protected System.Web.UI.WebControls.RegularExpressionValidator vldProgramLucru;
		protected System.Web.UI.WebControls.TextBox txtSalariuBaza;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPosibilitateScutireImpozit;

		public long AngajatID;
		#endregion
		
		#region Page_Load
		///<remarks>
		/// Modificari:
		/// Autor: Cristina Raluca Muntean
		/// Data:  23.03.2006
		/// Descriere: Stabilirea vizibilitatii tag-ului de adaugare a unei schimbari 
		/// in functie de starea angajatului: lichidat sau nu.
		///</remarks>
		private void Page_Load(object sender, System.EventArgs e)
		{
			numberInfoFormat = new CultureInfo( "ro-RO", false ).NumberFormat;
			numberInfoFormat.CurrencyDecimalDigits = 0;
			numberInfoFormat.NumberDecimalDigits = 0;

			// Angajatul curent.
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.AngajatId = AngajatID;
			angajat.LoadAngajat();

			// Date luna curenta
			luna = new Salaries.Business.Luni( angajat.AngajatorId );
			lunaActiva = luna.GetLunaActiva();
			DateTime sfarsitLunaActiva = new DateTime(lunaActiva.Data.Year,lunaActiva.Data.Month,DateTime.DaysInMonth(lunaActiva.Data.Year,lunaActiva.Data.Month));
			
			btnStergeDate.Style.Add( "display", "none" );
			btnStergeDate.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta inregistrare?')");

			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			
			// Lungu Andreea 22.07.2008
			LoadFunctie();
			if( !IsPostBack )
			{
				// Este completat controlul aferent categoriilor.
				CreateCategorieSelectBox();
				BindInvaliditateDDL();
			}
			
			// Sunt incarcate schimbarile angajatului.
			LoadFormIstoricSchimbari();
		

			if (( !angajat.IsLichidat ) && (DateTime.Compare(angajat.DataDeLa,sfarsitLunaActiva)<=0))
			{
				// In cazul in care nu este lichidat se permite accesarea tab-ului 
				// pentru adaugarea unei schimbari si sunt completate
				// controalele cu datele angajatului curent.
				FillEdituriSchimbare();

				// Este creat tabelul cu taburile.
				Response.Write("<script>var arTabs = new Array('tableIstoricSchimbari', 'tableAdaugaSchimbare');</script>");
				string[] textTabs = {"Istoric schimbari", "Adauga schimbare"};
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);
				
				// In cazul in care angajatul nu este lichidat trebuie sa fie vizibil tab-ul
				// pentru adaugarea unei schimbari.
				Response.Write("<script>var ascundeAdaugare = false;</script>");
			}
			else
			{
				// In cazul in care nu este lichida se va incarca doar tab-ul 
				// ce cuprinde lista schimbarilor.
				Response.Write("<script>var arTabs = new Array('tableIstoricSchimbari');</script>");
				string[] textTabs = {"Istoric schimbari"};
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);

				// In cazul in care angajatul este lichidat nu trebuie sa fie vizibil tab-ul
				// pentru adaugarea unei schimbari.
				Response.Write("<script>var ascundeAdaugare = true;</script>");
			}
		}
		#endregion
	
		#region FillEdituriSchimbare
		/// <summary>
		/// Procedura completeaza controalele cu datele unei schimbari
		/// </summary>
		private void FillEdituriSchimbare()
		{
			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.AngajatId = AngajatID;
			ang.LoadAngajat();
			this.txtProgramLucru.Text = ang.ProgramLucru.ToString();

			string indemnizatieConducere = ang.IndemnizatieConducere.ToString("N", numberInfoFormat);
			indemnizatieConducere = indemnizatieConducere.Replace(".","");
			this.txtIndemnizatieConducere.Text = indemnizatieConducere;

			string salariuBaza = ang.SalariuBaza.ToString("N", numberInfoFormat);
			salariuBaza = salariuBaza.Replace(".","");
			this.txtSalariuBaza.Text = salariuBaza;

			this.chkLstInvalid.SelectedValue = ang.Invaliditate.ToString();
			this.lstCategorie.SelectedValue = ang.CategorieId.ToString();
			
			string dataLunaActiva = lunaActiva.Data.ToShortDateString();

			/*
			 *	Modified: Ionel Popa
			 *				Daca angajatul incepe contractul in luna activa atunci data de start a schimbarii pt controalele de mai jos este egala cu 
			 *				data de inceput a contractului
			*/
			Salaries.Business.IstoricSchimbareDateAngajat istoricSchimbare = new Salaries.Business.IstoricSchimbareDateAngajat();
			if( ang.DataDeLa.Month == lunaActiva.Data.Month && ang.DataDeLa.Year == lunaActiva.Data.Year)
			{
				istoricSchimbare.DataStart = ang.DataDeLa;
				while (istoricSchimbare.DataEsteZiSarbatoare())
				{
					istoricSchimbare.DataStart = istoricSchimbare.DataStart.AddDays(1);
				}
				txtDataStartProgramLucru.Text = istoricSchimbare.DataStart.ToShortDateString();
				txtDataStartInvaliditate.Text = istoricSchimbare.DataStart.ToShortDateString();
				txtDataStartCategorie.Text  = istoricSchimbare.DataStart.ToShortDateString();
			}
			else
			{
				istoricSchimbare.DataStart = lunaActiva.Data;
				while (istoricSchimbare.DataEsteZiSarbatoare())
				{
					istoricSchimbare.DataStart = istoricSchimbare.DataStart.AddDays(1);
				}
				txtDataStartProgramLucru.Text = istoricSchimbare.DataStart.ToShortDateString();;
				txtDataStartInvaliditate.Text = istoricSchimbare.DataStart.ToShortDateString();;
				txtDataStartCategorie.Text  = istoricSchimbare.DataStart.ToShortDateString();;
			}

			ClearEdituriDataStart();
		}
		#endregion

		#region ClearEdituriDataStart
		/// <summary>
		/// Procedura sterge datele din controale
		/// </summary>
		private void ClearEdituriDataStart()
		{
			this.txtDataStartSalariuBaza.Text = "";
			this.txtDataStartIndemnizatieConducere.Text = "";
		}
		#endregion

		#region LoadFormIstoricSchimbari
		/// <summary>
		/// Listeaza schimbarile existente
		/// </summary>
		private void LoadFormIstoricSchimbari()
		{
			try
			{
				listTable.Rows.Clear();
				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

				Salaries.Business.IstoricSchimbareDateAngajat istSch = new Salaries.Business.IstoricSchimbareDateAngajat();
				istSch.AngajatId = AngajatID;
				
				string[] arHeader = {"Norma", "Salariu de baza", "Indemnizatie de conducere", "Invaliditate", "Categorie", "Data inceput", "Data sfarsit" };
				string[] arCols = {"ProgramLucru", "SalariuBaza", "IndemnizatieConducere", "InvaliditateText", "CategorieText", "DataStart", "DataEnd" };
				ListTable objListTable = new ListTable(listTable, istSch.LoadIstoricSchimbari(), arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista nici o schimbare asociata acestui angajat!";

				string[] ar_OnClickParam = { "DataStart", "DataEnd", AngajatID.ToString()};
				string[] ar_OnClickParamType = {"dataset", "dataset", "const"};
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectSchimbare";

				objListTable.DrawListTableWithDigits();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region LoadFunctie
		/// <summary>
		/// Aduce functia curenta a angajatului si implicit posibilitatea de a avea scutire sau nu de la impozit
		/// </summary>
		private void LoadFunctie()
		{
			try
			{
				Salaries.Business.IstoricFunctie istFunct = new Salaries.Business.IstoricFunctie();
				istFunct.AngajatId = AngajatID;
				DataSet ds = istFunct.GetFunctieCurenta();
				txtPosibilitateScutireImpozit.Value = ds.Tables[0].Rows[0]["PosibilaScutireImpozit"].ToString();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region CreateCategorieSelectBox
		/// <summary>
		/// Procedura creaza lista care contine categoiile salariale ale angajatilor
		/// </summary>
		private void CreateCategorieSelectBox()
		{
			// Id-ul lunii active.
			int lunaID;
			// Angajatul curent.
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.AngajatId = AngajatID;

			// Sunt preluate datele despre angajatul curent.
			angajat.LoadAngajat();
				
			// Sunt preluate datele 
			Salaries.Business.Luni luna = new Salaries.Business.Luni( angajat.AngajatorId );
			lunaID = luna.GetLunaActiva().LunaId;

			//Admin_SalariiCategoriiAngajati categoriiAngajati = new Admin_SalariiCategoriiAngajati(lunaID);
			Salaries.Business.AdminSalariiCategoriiAngajati categoriiAngajati = new Salaries.Business.AdminSalariiCategoriiAngajati();
			categoriiAngajati.LunaId = lunaID;
			
			if (txtPosibilitateScutireImpozit.Value.Equals("True"))
                lstCategorie.DataSource = categoriiAngajati.LoadInfoCategoriiLunaId();
			else
				lstCategorie.DataSource = categoriiAngajati.LoadInfoCategoriiNesLunaId();
			lstCategorie.DataValueField="CategorieID";
			lstCategorie.DataTextField="Denumire";
			lstCategorie.DataBind();
		}
		#endregion

		#region BindInvaliditateDDL
		/// <summary>
		/// Procedura creaza lista care contine tipurile de invaliditati existente
		/// </summary>
		private void BindInvaliditateDDL()
		{
			Salaries.Business.IstoricSchimbareDateAngajat isda = new Salaries.Business.IstoricSchimbareDateAngajat();
			isda.AngajatId = -1;
			DataSet ds = isda.GetAllInvaliditati();

			chkLstInvalid.DataSource = ds;
			chkLstInvalid.DataTextField = "Nume";
			chkLstInvalid.DataValueField = "InvaliditateID";
			chkLstInvalid.DataBind();
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
			this.btnAdaugaSchimbare.Click += new System.EventHandler(this.btnAdaugaSchimbare_Click);
			this.btnStergeDate.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdaugaSchimbare_Click
		/// <summary>
		/// Adauga o schimbare
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaSchimbare_Click(object sender, System.EventArgs e)
		{
			ErrHandler.MyErrHandler.WriteError("IstoricSchimbariDateAngajat.ascx - start - AdaugaSchimbare() - angID: " + AngajatID + " - " + txtSalariuBaza.Text + " - " + txtDataStartSalariuBaza.Text + " - " + txtIndemnizatieConducere.Text + " - " + txtDataStartIndemnizatieConducere.Text);
			bool corectLunaActiva = true;
			bool corectDataPanaLa = true;
			bool corectSarbatoare = true;

			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.AngajatId = AngajatID;
			ang.LoadAngajat();

			programLucru = ang.ProgramLucru.ToString();
			lstInvalid = ang.Invaliditate.ToString();
			categorie = ang.CategorieId.ToString();
			
			try
			{
				Salaries.Business.Luni luna = new Salaries.Business.Luni( ang.AngajatorId );
				Salaries.Data.LunaData lunaActiva = luna.GetLunaActiva();
				string dataLunaActiva = lunaActiva.Data.ToShortDateString();

				Salaries.Business.IstoricSchimbareDateAngajat intsch = new Salaries.Business.IstoricSchimbareDateAngajat();
				intsch.AngajatId = AngajatID;
				intsch.DataEnd = DateTime.MaxValue;

				Salaries.Business.IstoricSchimbareDateAngajat istoricSchimbariDataDeLa = new Salaries.Business.IstoricSchimbareDateAngajat();
				istoricSchimbariDataDeLa.DataStart = ang.DataDeLa;		
				while (istoricSchimbariDataDeLa.DataEsteZiSarbatoare())
				{
					istoricSchimbariDataDeLa.DataStart = istoricSchimbariDataDeLa.DataStart.AddDays(1);
				}
				
				//pt schimbare de program de lucru
				//Modified: Ionel Popa -> data de start trebuie sa fie egala cu inceputul contractului de munca in cazul in care schimbarea are
				//							loc in prima luna a contractului
				if( DateTime.Parse(dataLunaActiva).Month == ang.DataDeLa.Month && DateTime.Parse(dataLunaActiva).Year == ang.DataDeLa.Year)
				{
					//intsch.DataStart = ang.DataDeLa;
					intsch.DataStart = istoricSchimbariDataDeLa.DataStart;
				}
				else
					intsch.DataStart = DateTime.Parse(txtDataStartProgramLucru.Text/*dataLunaActiva*/);

				
				if( txtProgramLucru.Text != programLucru) 
				{
					Salaries.Business.IstoricSchimbareDateAngajat isda = new Salaries.Business.IstoricSchimbareDateAngajat();
					isda.AngajatId = AngajatID;
					isda.DataStart = intsch.DataStart;
					
					if (isda.DataInLunaActiva())
					{
						if (((ang.PerioadaDeterminata) && (intsch.DataStart < ang.DataPanaLa)) || (!ang.PerioadaDeterminata))
						{																														 
							Salaries.Business.IstoricSchimbareDateAngajat interv = new Salaries.Business.IstoricSchimbareDateAngajat();
							interv.AngajatId = AngajatID;
							DataSet existaCapat = new DataSet();
	
							if(/*ang.DataDeLa*/istoricSchimbariDataDeLa.DataStart != intsch.DataStart)
							{
								isda.DataStart = intsch.DataStart.AddDays(-1);
								while (isda.DataEsteZiSarbatoare())
								{
									isda.DataStart = isda.DataStart.AddDays(-1);
								}
								interv = isda.GetIntervalSchimbareByDataInside();
								isda.CategorieId = interv.CategorieId;
								interv.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();
							
								//trebuie facut pt toate if-urile si mai tre facuta adaugarea capatului in tm_IntervaleAngajat cu data 00:00:00 AM
								isda.DataStart = intsch.DataStart.AddDays(-1);
								while (isda.DataEsteZiSarbatoare())
								{
									isda.DataStart = isda.DataStart.AddDays(-1);
								}
								existaCapat = isda.GetCapatIntervalAngajatZi();
						
								if( existaCapat == null || existaCapat.Tables[ 0 ].Rows.Count == 0 )
								{
									interv.InsertCapatIntervalSchimbareAngajat();
								}
								else
								{
									interv.IntervalAngajatId = int.Parse( existaCapat.Tables[ 0 ].Rows[ 0 ][ "IntervalAngajatID" ].ToString());
									interv.UpdateCapatIntervalSchimbareAngajat();
								}
							}

							intsch.ProgramLucru = int.Parse(txtProgramLucru.Text);
							intsch.InsertSchimbareProgramLucru();

							isda.DataStart = intsch.DataStart;
							interv = isda.GetIntervalSchimbareByDataInside();
							interv.ProgramLucru = intsch.ProgramLucru;
							isda.CategorieId = interv.CategorieId;
							interv.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();

							isda.DataStart = intsch.DataStart;
							existaCapat = isda.GetCapatIntervalAngajatZi();
							if( existaCapat == null || existaCapat.Tables[ 0 ].Rows.Count == 0 )
							{
								interv.InsertCapatIntervalSchimbareAngajat();
							}
							else
							{
								interv.IntervalAngajatId = int.Parse( existaCapat.Tables[ 0 ].Rows[ 0 ][ "IntervalAngajatID" ].ToString());
								interv.UpdateCapatIntervalSchimbareAngajat();
							}

							//redinitializare luna
							ReinitializareLunaActivaAngajat();

						}//if perioada determinata
						else
						{
							corectDataPanaLa = false;
						}
					}//if luna activa
					else
					{
						corectLunaActiva = false;
					}
				}

				//pt schimbare de salariu de baza
				intsch.DataStart = Utilities.ConvertText2DateTime( txtDataStartSalariuBaza.Text );
				if( txtDataStartSalariuBaza.Text != "" && ang.DataDeLa <= intsch.DataStart)
				{
					Salaries.Business.IstoricSchimbareDateAngajat isda = new Salaries.Business.IstoricSchimbareDateAngajat();
					isda.AngajatId = AngajatID;
					isda.DataStart = intsch.DataStart;
					
					if (!isda.DataEsteZiSarbatoare())
					{
						if (isda.DataInLunaActiva())
						{
							if (((ang.PerioadaDeterminata) && (intsch.DataStart < ang.DataPanaLa)) || (!ang.PerioadaDeterminata))
							{
								Salaries.Business.IstoricSchimbareDateAngajat interv = new Salaries.Business.IstoricSchimbareDateAngajat();
								interv.AngajatId = AngajatID;
								DataSet existaCapat = new DataSet();

								if(/*ang.DataDeLa*/istoricSchimbariDataDeLa.DataStart != intsch.DataStart)
								{
									isda.DataStart = intsch.DataStart.AddDays(-1);
									while (isda.DataEsteZiSarbatoare())
									{
										isda.DataStart = isda.DataStart.AddDays(-1);
									}
									interv = isda.GetIntervalSchimbareByDataInside();
									isda.CategorieId = interv.CategorieId;
									interv.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();
							
									//trebuie facut pt toate if-urile si mai tre facuta adaugarea capatului in tm_IntervaleAngajat cu data 00:00:00 AM
									isda.DataStart = intsch.DataStart.AddDays(-1);
									while (isda.DataEsteZiSarbatoare())
									{
										isda.DataStart = isda.DataStart.AddDays(-1);
									}
									existaCapat = isda.GetCapatIntervalAngajatZi( );
									if( existaCapat == null || existaCapat.Tables[ 0 ].Rows.Count == 0 )
									{
										interv.InsertCapatIntervalSchimbareAngajat();
									}
									else
									{
										interv.IntervalAngajatId = int.Parse( existaCapat.Tables[ 0 ].Rows[ 0 ][ "IntervalAngajatID" ].ToString());
										interv.UpdateCapatIntervalSchimbareAngajat();
									}
								}
							
								intsch.SalariuBaza = decimal.Parse(txtSalariuBaza.Text);
								intsch.InsertSchimbareSalariuBaza();

								//Modificat:	Oprescu Claudia
								//Data:			07.09.2007
								//Descriere:	La modificarea salariului de baza al unui angajat trebuie recalculata media zilnica a concediului de odihna al acestuia
								//se regenereaza situatia lunara a angajatului cu salariul modificat
								SiemensTM.Classes.SituatieAngajat situatieLunaraAng = new SiemensTM.Classes.SituatieAngajat(AngajatID);
								situatieLunaraAng.GenerareSituatieLunaraAngajat();

								//se recalculeaza media zilnica a concediului de odihna al angajatului
								ang.RecalculMedieZilnicaConcediuOdihna(AngajatID, intsch.DataStart, intsch.DataEnd);

								isda.DataStart = intsch.DataStart;
								interv = isda.GetIntervalSchimbareByDataInside();
								interv.SalariuBaza = intsch.SalariuBaza;
								isda.CategorieId = interv.CategorieId;
								interv.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();

								isda.DataStart = intsch.DataStart;
								existaCapat = isda.GetCapatIntervalAngajatZi();
								if( existaCapat == null || existaCapat.Tables[ 0 ].Rows.Count == 0 )
								{
									interv.InsertCapatIntervalSchimbareAngajat();
								}
								else
								{
									interv.IntervalAngajatId = int.Parse( existaCapat.Tables[ 0 ].Rows[ 0 ][ "IntervalAngajatID" ].ToString());
									interv.UpdateCapatIntervalSchimbareAngajat();
								}

							}//if perioada determinata
							else
							{
								corectDataPanaLa = false;
							}
						}//if luna activa
						else
						{
							corectLunaActiva = false;
						}
					}//if sarbatoare
					else
					{	
						corectSarbatoare = false;
					}
				}

				//pt schimbare de indemnizatie de conducere
				intsch.DataStart = Utilities.ConvertText2DateTime( txtDataStartIndemnizatieConducere.Text );
				if( txtDataStartIndemnizatieConducere.Text != "" && ang.DataDeLa <= intsch.DataStart)
				{
					Salaries.Business.IstoricSchimbareDateAngajat isda = new Salaries.Business.IstoricSchimbareDateAngajat();
					isda.AngajatId = AngajatID;
					isda.DataStart = intsch.DataStart;
					
					if (!isda.DataEsteZiSarbatoare())
					{
						if (isda.DataInLunaActiva())
						{
							if (((ang.PerioadaDeterminata) && (intsch.DataStart < ang.DataPanaLa)) || (!ang.PerioadaDeterminata))
							{
								Salaries.Business.IstoricSchimbareDateAngajat interv = new Salaries.Business.IstoricSchimbareDateAngajat();
								interv.AngajatId = AngajatID;
								DataSet existaCapat = new DataSet();

								if (/*ang.DataDeLa*/istoricSchimbariDataDeLa.DataStart != intsch.DataStart)
								{
									isda.DataStart = intsch.DataStart.AddDays( -1);
									while (isda.DataEsteZiSarbatoare())
									{
										isda.DataStart = isda.DataStart.AddDays(-1);
									}
									interv = isda.GetIntervalSchimbareByDataInside();
									isda.CategorieId = interv.CategorieId;
									interv.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();
							
									//trebuie facut pt toate if-urile si mai tre facuta adaugarea capatului in tm_IntervaleAngajat cu data 00:00:00 AM
									isda.DataStart = intsch.DataStart.AddDays( -1 );
									while (isda.DataEsteZiSarbatoare())
									{
										isda.DataStart = isda.DataStart.AddDays(-1);
									}
									existaCapat = isda.GetCapatIntervalAngajatZi();
									if( existaCapat == null || existaCapat.Tables[ 0 ].Rows.Count == 0 )
									{
										interv.InsertCapatIntervalSchimbareAngajat();
									}
									else
									{
										interv.IntervalAngajatId = int.Parse( existaCapat.Tables[ 0 ].Rows[ 0 ][ "IntervalAngajatID" ].ToString());
										interv.UpdateCapatIntervalSchimbareAngajat();
									}
								}

								/*string indemnizatieConducere = txtIndemnizatieConducere.Text; 
								indemnizatieConducere = indemnizatieConducere.Replace(",",".");*/
								intsch.IndemnizatieConducere = decimal.Parse(txtIndemnizatieConducere.Text);
								intsch.InsertSchimbareIndemnizatieConducere();

								isda.DataStart = intsch.DataStart;
								interv = isda.GetIntervalSchimbareByDataInside();
								interv.IndemnizatieConducere = intsch.IndemnizatieConducere;
								isda.CategorieId = interv.CategorieId;
								interv.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();

								isda.DataStart = intsch.DataStart;
								existaCapat = isda.GetCapatIntervalAngajatZi();
								if( existaCapat == null || existaCapat.Tables[ 0 ].Rows.Count == 0 )
								{
									interv.InsertCapatIntervalSchimbareAngajat();
								}
								else
								{
									interv.IntervalAngajatId = int.Parse( existaCapat.Tables[ 0 ].Rows[ 0 ][ "IntervalAngajatID" ].ToString());
									interv.UpdateCapatIntervalSchimbareAngajat();
								}

							}//if perioada determinata
							else
							{
								corectDataPanaLa = false;
							}
						}//if luna activa
						else
						{
							corectLunaActiva = false;
						}
					}//if sarbatoare
					else
					{	
						corectSarbatoare = false;
					}
				}
				
				//pt schimbare de invaliditate
				//Modified: Ionel Popa -> data de start trebuie sa fie egala cu inceputul contractului de munca in cazul in care schimbarea are
				//							loc in prima luna a contractului
				if( DateTime.Parse(dataLunaActiva).Month == ang.DataDeLa.Month && DateTime.Parse(dataLunaActiva).Year == ang.DataDeLa.Year)
				{
					//intsch.DataStart = ang.DataDeLa;
					intsch.DataStart = istoricSchimbariDataDeLa.DataStart;
				}
				else
					intsch.DataStart = DateTime.Parse(txtDataStartInvaliditate.Text/*dataLunaActiva*/);

				if( chkLstInvalid.SelectedValue.ToString() != lstInvalid && ang.DataDeLa <= intsch.DataStart)
				{
					Salaries.Business.IstoricSchimbareDateAngajat isda = new Salaries.Business.IstoricSchimbareDateAngajat();
					isda.AngajatId = AngajatID;
					isda.DataStart = intsch.DataStart;

					if (isda.DataInLunaActiva())
					{
						if (((ang.PerioadaDeterminata) && (intsch.DataStart < ang.DataPanaLa)) || (!ang.PerioadaDeterminata))
						{
							Salaries.Business.IstoricSchimbareDateAngajat interv = new Salaries.Business.IstoricSchimbareDateAngajat();
							interv.AngajatId = AngajatID;
							DataSet existaCapat = new DataSet();

							if(/*ang.DataDeLa*/istoricSchimbariDataDeLa.DataStart != intsch.DataStart)
							{
								interv.DataStart = intsch.DataStart.AddDays( -1);
								while (interv.DataEsteZiSarbatoare())
								{
									interv.DataStart = interv.DataStart.AddDays(-1);
								}
								interv = isda.GetIntervalSchimbareByDataInside();
								isda.CategorieId = interv.CategorieId;
								interv.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();
								//trebuie facut pt toate if-urile si mai tre facuta adaugarea capatului in tm_IntervaleAngajat cu data 00:00:00 AM
							
								isda.DataStart = intsch.DataStart.AddDays( -1 );
								while (isda.DataEsteZiSarbatoare())
								{
									isda.DataStart = isda.DataStart.AddDays(-1);
								}
								existaCapat = isda.GetCapatIntervalAngajatZi();
								if( existaCapat == null || existaCapat.Tables[ 0 ].Rows.Count == 0 )
								{
									interv.InsertCapatIntervalSchimbareAngajat();
								}
								else
								{
									interv.IntervalAngajatId = int.Parse( existaCapat.Tables[ 0 ].Rows[ 0 ][ "IntervalAngajatID" ].ToString());
									interv.UpdateCapatIntervalSchimbareAngajat();
								}
							}

							intsch.InvaliditateId = short.Parse( chkLstInvalid.SelectedValue );
							intsch.InsertSchimbareInvaliditate();

							isda.DataStart = intsch.DataStart;
							interv = isda.GetIntervalSchimbareByDataInside();
							interv.InvaliditateId = intsch.InvaliditateId;
							isda.CategorieId = interv.CategorieId;
							interv.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();

							isda.DataStart = intsch.DataStart;
							existaCapat = isda.GetCapatIntervalAngajatZi();
							if( existaCapat == null || existaCapat.Tables[ 0 ].Rows.Count == 0 )
							{
								interv.InsertCapatIntervalSchimbareAngajat();
							}
							else
							{
								interv.IntervalAngajatId = int.Parse( existaCapat.Tables[ 0 ].Rows[ 0 ][ "IntervalAngajatID" ].ToString());
								interv.UpdateCapatIntervalSchimbareAngajat();
							}

						}//if perioada determinata
						else
						{
							corectDataPanaLa = false;
						}
					}//if luna activa
					else
					{
						corectLunaActiva = false;
					}
				}

				//pt schimbare de categorie
				//Modified: Ionel Popa -> data de start trebuie sa fie egala cu inceputul contractului de munca in cazul in care schimbarea are
				//							loc in prima luna a contractului
				if( DateTime.Parse(dataLunaActiva).Month == ang.DataDeLa.Month && DateTime.Parse(dataLunaActiva).Year == ang.DataDeLa.Year)
				{
					//intsch.DataStart = ang.DataDeLa;
					intsch.DataStart = istoricSchimbariDataDeLa.DataStart;
				}
				else
					intsch.DataStart = DateTime.Parse(txtDataStartCategorie.Text/*dataLunaActiva*/);

				if( lstCategorie.SelectedValue.ToString() != categorie && ang.DataDeLa <= intsch.DataStart)
				{
					Salaries.Business.IstoricSchimbareDateAngajat isda = new Salaries.Business.IstoricSchimbareDateAngajat();
					isda.AngajatId = AngajatID;
					isda.DataStart = intsch.DataStart;
					
					if (isda.DataInLunaActiva())
					{
						if (((ang.PerioadaDeterminata) && (intsch.DataStart < ang.DataPanaLa)) || (!ang.PerioadaDeterminata))
						{
							Salaries.Business.IstoricSchimbareDateAngajat interv = new Salaries.Business.IstoricSchimbareDateAngajat();
							interv.AngajatId = AngajatID;
							DataSet existaCapat = new DataSet();

							if(/*ang.DataDeLa*/istoricSchimbariDataDeLa.DataStart != intsch.DataStart)
							{
								isda.DataStart = intsch.DataStart.AddDays( -1);
								while (isda.DataEsteZiSarbatoare())
								{
									isda.DataStart = isda.DataStart.AddDays(-1);
								}
								interv = isda.GetIntervalSchimbareByDataInside();
								isda.CategorieId = interv.CategorieId;
								interv.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();
							
								//trebuie facut pt toate if-urile si mai tre facuta adaugarea capatului in tm_IntervaleAngajat cu data 00:00:00 AM
								isda.DataStart = intsch.DataStart.AddDays( -1 );
								while (isda.DataEsteZiSarbatoare())
								{
									isda.DataStart = isda.DataStart.AddDays(-1);
								}
								existaCapat = isda.GetCapatIntervalAngajatZi();
								if( existaCapat == null || existaCapat.Tables[ 0 ].Rows.Count == 0 )
								{
									interv.InsertCapatIntervalSchimbareAngajat(  );
								}
								else
								{
									interv.IntervalAngajatId = int.Parse( existaCapat.Tables[ 0 ].Rows[ 0 ][ "IntervalAngajatID" ].ToString());
									interv.UpdateCapatIntervalSchimbareAngajat();
								}
							}

							intsch.CategorieId = int.Parse( lstCategorie.SelectedValue );
							intsch.InsertSchimbareCategorie();
						
							isda.DataStart = intsch.DataStart;
							interv = isda.GetIntervalSchimbareByDataInside();
							interv.CategorieId = intsch.CategorieId;

							isda.DataStart = intsch.DataStart;
							existaCapat = isda.GetCapatIntervalAngajatZi();
							if( existaCapat == null || existaCapat.Tables[ 0 ].Rows.Count == 0 )
							{
								interv.InsertCapatIntervalSchimbareAngajat();
							}
							else
							{
								interv.IntervalAngajatId = int.Parse( existaCapat.Tables[ 0 ].Rows[ 0 ][ "IntervalAngajatID" ].ToString());
								interv.UpdateCapatIntervalSchimbareAngajat();
							}

						}//if perioada determinata
						else
						{
							corectDataPanaLa = false;
						}
					}//if luna activa
					else
					{
						corectLunaActiva = false;
					}
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
				ErrHandler.MyErrHandler.WriteError("IstoricSchimbariDateAngajat.ascx - error - angID: " + AngajatID + " - " + ex.Message);
			}

			if (corectDataPanaLa && corectLunaActiva && corectSarbatoare)
			{
				LoadFormIstoricSchimbari();
				FillEdituriSchimbare();
			}
			else
			{
				if (!corectLunaActiva)
				{
					ErrHandler.MyErrHandler.WriteError("IstoricSuspendariCIM.ascx - AdaugaSuspendare() - angID: " + AngajatID + " - 'Puteti schimba datele angajatului numai daca data inceperii schimbarii este in luna activa!' ");
					Response.Write( "<script>alert( 'Puteti schimba datele angajatului numai daca data inceperii schimbarii este in luna activa!' );</script>" );
				}
				if (!corectDataPanaLa)
				{
					ErrHandler.MyErrHandler.WriteError("IstoricSuspendariCIM.ascx - AdaugaSuspendare() - angID: " + AngajatID + " - 'Puteti schimba datele angajatului numai daca data inceperii schimbarii este mai mica decat data incheierii contractului!' ");
					Response.Write( "<script>alert( 'Puteti schimba datele angajatului numai daca data inceperii schimbarii este mai mica decat data incheierii contractului!' );</script>" );
				}
				if (!corectSarbatoare)
				{
					ErrHandler.MyErrHandler.WriteError("IstoricSuspendariCIM.ascx - AdaugaSuspendare() - angID: " + AngajatID + " - 'Puteti schimba datele angajatului numai daca data inceperii schimbarii este o zi lucratoare!' ");
					Response.Write( "<script>alert( 'Puteti schimba datele angajatului numai daca data inceperii schimbarii este o zi lucratoare!' );</script>" );
				}
			}
			ErrHandler.MyErrHandler.WriteError("IstoricSchimbariDateAngajat.ascx - end - AdaugaSchimbare() - angID: " + AngajatID);
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge o schimbarae
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			ErrHandler.MyErrHandler.WriteError("IstoricSchimbariDateAngajat.ascx - start - StergeSchimbare() - angID: " + AngajatID + " - " + txtSalariuBaza.Text + " - " + txtDataStartSalariuBaza.Text + " - " + txtIndemnizatieConducere.Text + " - " + txtDataStartIndemnizatieConducere.Text);
			try
			{
				Salaries.Business.IstoricSchimbareDateAngajat isda = new Salaries.Business.IstoricSchimbareDateAngajat();
				isda.AngajatId = AngajatID;
				isda.DataStart = Utilities.ConvertText2DateTime( del_DataStart.Value );
				isda.DataEnd = Utilities.ConvertText2DateTime( del_DataEnd.Value );
				if	(isda.DataInLunaActiva())
				{
					isda.DeleteSchimbare();
				}
				else
				{
					Response.Write( "<script>alert( 'Nu puteti sterge o schimbare care incepe intr-o luna precedenta!' );</script>" );
				}
				LoadFormIstoricSchimbari();
				FillEdituriSchimbare();
			}
			catch (Exception ex)
			{
				string mes = ex.Message;
				ErrHandler.MyErrHandler.WriteError("IstoricSchimbariDateAngajat.ascx - error - angID: " + AngajatID + " - " + ex.Message);
			}
			ErrHandler.MyErrHandler.WriteError("IstoricSchimbariDateAngajat.ascx - end - StergeSchimbare() - angID: " + AngajatID);
		}
		#endregion

		#region ReinitializareLunaActivaAngajat
		/// <summary>
		/// Procedura reinitializeaza luna activa
		/// </summary>
		private void ReinitializareLunaActivaAngajat()
		{
			ErrHandler.MyErrHandler.WriteError("IstoricSchimbariDateAngajat.ascx - start - ReinitializareLunaActivaAngajat() - angID: " + AngajatID);
			//preluare ore normale si suplimentare
			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.AngajatId = AngajatID;
			ang.LoadAngajat();
			Salaries.Data.LunaData lunaData = new Salaries.Business.Luni( ang.AngajatorId ).GetLunaActiva();

			Salaries.Business.PontajAngajat pa = new Salaries.Business.PontajAngajat( this.AngajatID );
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
			SiemensTM.Classes.IntervaleAngajat ia = new SiemensTM.Classes.IntervaleAngajat( this.AngajatID );

			ia.DeleteIntervaleVizibileAngajatPerioada( lunaData.Data, new DateTime( lunaData.Data.Year, lunaData.Data.Month, DateTime.DaysInMonth( lunaData.Data.Year, lunaData.Data.Month )));

			//reinitializarea angajatului
			for( i=0; i<intervaleNrOreLucrate.Length; i++ )
			{
				//reinitializare pe intervale de zile
				ia.InitializeOreLucratePerioadaAngajatFromIntervalSchimbare( lunaData.Data, intervSL[ i ] );
			}

			//initializeaza orele suplimentare 100%
			int tipIntervalID = new SiemensTM.Classes.IntervaleAngajat( this.AngajatID ).GetTipIntervalIDByName( Salaries.Business.SituatieLunaraAngajat.denumireOreLucrate[ 1 ] );
			double nrOreSuplimentare = nrOreSuplimentare50;
			double nrOreSuplimentare_old = 0;
			
			if( tipIntervalID > 0 )
			{
				ia.DistribuieOreSuplimentareInRegimNormal( lunaData.Data, nrOreSuplimentare50, tipIntervalID, nrOreSuplimentare_old );
			}

			//initializeaza orele suplimentare 200%
			tipIntervalID = new SiemensTM.Classes.IntervaleAngajat( this.AngajatID ).GetTipIntervalIDByName( Salaries.Business.SituatieLunaraAngajat.denumireOreLucrate[ 2 ] );
			nrOreSuplimentare = nrOreSuplimentare100;
		
			if( tipIntervalID > 0 )
			{
				ia.DistribuieOreSuplimentareInRegimWeekendNoapte( lunaData.Data, nrOreSuplimentare, tipIntervalID, nrOreSuplimentare_old );
			}

			ErrHandler.MyErrHandler.WriteError("IstoricSchimbariDateAngajat.ascx - end - ReinitializareLunaActivaAngajat() - angID : " + AngajatID);
		}
		#endregion

		#region VariabileJavascript - siruri functii/scutiri
		/// <summary>
		/// Proceudra creaza sirul de functii ale angajatului din luna activa
		/// </summary>
		/// <returns>Returneaza un string care contine aceste functii</returns>
		/*private string GetSirFunctiiAngajatLunaActiva()
		{
			// Punctele de lucru ale angajatorilor.
			Salaries.Business.AdminFunctii functiiAng = new Salaries.Business.AdminFunctii();
			DataSet dsPuncteDeLucru = puncteLucru.GetPuncteDeLucruAngajatori();
			
			string sirAngajatorPunctLucru = "";
			string sirAngajator = "[";
			string sirPunctLucru = "[";
			string sirNume = "[";

			for( int i=0; i<dsPuncteDeLucru.Tables[0].Rows.Count-1; i++ )
			{
				sirAngajator += dsPuncteDeLucru.Tables[0].Rows[i]["AngajatorID"].ToString()+", ";
				sirPunctLucru += dsPuncteDeLucru.Tables[0].Rows[i]["PunctLucruID"].ToString()+", ";
				sirNume += "'" + dsPuncteDeLucru.Tables[0].Rows[i]["Nume"].ToString().TrimEnd()+"', ";
			}
			if( dsPuncteDeLucru.Tables[0].Rows.Count > 0 )
			{
				sirAngajator+= dsPuncteDeLucru.Tables[0].Rows[ dsPuncteDeLucru.Tables[0].Rows.Count-1 ]["AngajatorID"].ToString()+"]";
				sirPunctLucru += dsPuncteDeLucru.Tables[0].Rows[ dsPuncteDeLucru.Tables[0].Rows.Count-1 ]["PunctLucruID"].ToString()+"]";
				sirNume += "'" + dsPuncteDeLucru.Tables[0].Rows[ dsPuncteDeLucru.Tables[0].Rows.Count-1 ]["Nume"].ToString().TrimEnd()+"']";
			
				sirAngajatorPunctLucru = "["+sirAngajator+","+sirPunctLucru+","+sirNume+"]";
			}
			else
			{
				sirAngajatorPunctLucru = "[[],[]]";
			}

			return sirAngajatorPunctLucru;
		}
		
		/// <summary>
		/// SirPuncteLucru()
		/// </summary>
		/// <returns>Returneaza sirul punctelor de lucru in care e specificata si casa de asigurari implicita</returns>
		//Lungu Andreea 26.05.2008 
		//Descriere: Acest sir este creat ca atunci cand se selecteaza un punct de lucru sa se selecteze automat 
		//           si casa de asigurari care a fost setata ca fiind implicita ramanand totusi si posibilitatea 
		//           de a alege si alta casa de asigurari
		private string GetSirPuncteLucru()
		{
			string sirPuncte = "[";
			string sirPuncteUnic = "";
			
			Salaries.Business.AdminPunctLucru objAdminPunctLucru = new Salaries.Business.AdminPunctLucru();
			objAdminPunctLucru.AngajatorId = Convert.ToInt32(lstAngajator.SelectedValue, 10);
			DataSet ds = objAdminPunctLucru.LoadInfoPunctLucruAngajatori();

			for( int i=0; i<ds.Tables[0].Rows.Count-1; i++ )
			{
				DataRow dr = ds.Tables[0].Rows[i];
				sirPuncteUnic = "[" + dr["PunctLucruId"].ToString() + ",'" + dr["Nume"].ToString() + "'," + dr["IdCasaDeAsigImplicita"].ToString() + ",'"+dr["Denumire"].ToString() + "']";
				sirPuncte += sirPuncteUnic + ",";
			}
			if( ds.Tables[0].Rows.Count > 0 )
			{
				DataRow dr = ds.Tables[0].Rows[ds.Tables[0].Rows.Count-1];
				sirPuncteUnic = "[" + dr["PunctLucruId"].ToString() + ",'" + dr["Nume"].ToString() + "'," + dr["IdCasaDeAsigImplicita"].ToString() + ",'"+dr["Denumire"].ToString() + "']";
				sirPuncte += sirPuncteUnic + "]";
			}
			else
			{
				sirPuncte = "[]";
			}
			return sirPuncte;
		}*/
		#endregion
	}
}
