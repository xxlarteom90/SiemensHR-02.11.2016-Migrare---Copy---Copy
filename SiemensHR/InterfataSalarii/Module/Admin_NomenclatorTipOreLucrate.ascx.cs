using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for Admin_NomenclatorTipOreLucrate.
	/// </summary>
	public class Admin_NomenclatorTipOreLucrate : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table add_header;
		protected System.Web.UI.WebControls.TextBox txtDenumireTipOre;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumireTipOre;
		protected System.Web.UI.WebControls.TextBox txtProcentTipOre;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredProcentTipOre;
		protected System.Web.UI.WebControls.TextBox txtDescriereTipOre;
		protected System.Web.UI.WebControls.CheckBox cbStandardTipOre;
		protected System.Web.UI.WebControls.CheckBox cbModificabilaTipOre;
		protected System.Web.UI.WebControls.CheckBox cbFolosireTipOre;
		protected System.Web.UI.WebControls.Button btnSalveaza;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox txtTipIntervalID;
		protected System.Web.UI.HtmlControls.HtmlTable add_form;
		protected System.Web.UI.WebControls.Label labelDenumireTipOre;

		protected bool VarExists = false;
		protected System.Web.UI.WebControls.CheckBox cbBonuriMasa;
		protected System.Web.UI.WebControls.TextBox txtNrMaximOreSapt;
		protected System.Web.UI.WebControls.CheckBox cbWeekendNoapte;
		protected System.Web.UI.HtmlControls.HtmlTableRow trWeekendNoapte;
		protected System.Web.UI.HtmlControls.HtmlTableRow trWeekendNoapteSeparator;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.RangeValidator rngVldProcent;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqVldNrOreMaxim;
		protected System.Web.UI.WebControls.RangeValidator rngVldNrOreMaxim;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.HtmlControls.HtmlTable list_form;
		protected bool EditMode = false;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.ClientID+"\"</script>";
			Response.Write( script_text );
			litError.Text = "";

			btnEdit.Style.Add( "display", "none" );
			txtTipIntervalID.Style.Add( "display", "none" );
			trWeekendNoapte.Style.Add( "display", "none" );
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			UtilitiesDb utilDb = new UtilitiesDb( settings.ConnectionString);
						
			if( !IsPostBack )
			{
				this.btnSalveaza.Enabled = true;
			}

			Response.Write( "<script>var trWeekendNoapteClient = '"+trWeekendNoapte.ClientID+"'</script>" );
			Response.Write( "<script>var trWeekendNoapteSeparatorClient = '"+trWeekendNoapteSeparator.ClientID+"'</script>" );
		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			if (!this.EditMode )		
			{
				ListTipOreLucrate();
			}
		}
		#endregion

		#region EnableSomeControls
		/// <summary>
		/// Procedura seteaza vizibilitatea campurilor in functie de tipul actiunii executate
		/// </summary>
		/// <param name="adaugare">True daca este adaugare si false altfel</param>
		private void EnableSomeControls( bool adaugare )
		{
			if( !adaugare )
			{
				Salaries.Data.TipOreLucrate tipOre = new Salaries.Business.NomenclatorTipOreLucrate().GetDetaliiTipuriOreLucrate( int.Parse( this.txtTipIntervalID.Text ));
				if( tipOre.Modificare )
				{
					this.labelDenumireTipOre.Visible = false;
					this.txtDenumireTipOre.Visible = true;

					this.cbModificabilaTipOre.Enabled = true;
				}
				else
				{
					this.labelDenumireTipOre.Visible = true;
					this.txtDenumireTipOre.Visible = false;

					this.cbModificabilaTipOre.Enabled = false;
				}
			}
			else
			{
				labelDenumireTipOre.Visible = false;
				this.txtDenumireTipOre.Visible = true;
				this.cbModificabilaTipOre.Enabled = true;
			}
		}
		#endregion

		#region ListTipOreLucrate
		/// <summary>
		///		Cu ajutorul metodei ListTipOreLucrate se genereaza tabelul ce va fi afisat. 
		///		Acest tabel contine toate tipurile de ore lucrate existente in baza de date.
		/// </summary>
		private void ListTipOreLucrate()
		{	
			try
			{
				list_form.Style.Add("display","");
				add_form.Style.Add("display","none");
				btnSalveaza.Visible = false;
				btnInapoi.Visible = false;
				txtTipIntervalID.Text = "0";

				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
				
				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Nomenclator tipuri ore lucrate";
				myCell.Height = new Unit(50);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				// lista de impozite existente
				myRow = new TableRow();
				myCell = new TableCell();
				myCell.Attributes.Add("width", "100%");
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Top;
				Table listTable = new Table();
			
				string[] tableHeader = { "Denumire", "Procent", "Descriere", "Nr maxim ore", "Tip ora standard", "Modificabila ulterior", "Folosire curenta", "Bonuri de masa" };
				string[] tableCols = { "Denumire", "Procent", "Descriere", "NrMaximOreSapt", "Standard", "Modificare", "Folosire", "BonuriMasa" };
				ListTable objListTable = new ListTable( listTable, new Salaries.Business.NomenclatorTipOreLucrate().GetTipuriOreLucrate(), tableHeader, tableCols );

				objListTable.textForEmptyDataSet = "Nu exista date in nomenclatorul de tipuri de ore lucrate!";

				string[] ar_OnClickParam = { "TipIntervalID" };
				string[] ar_OnClickParamType = { "dataset" };

				objListTable.OnclickJSMethod = "SelectTipOraLucrata";
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.DrawListTableWithoutDigits();                				

				myCell.Controls.Add(listTable);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);
			}
			catch (Exception ex)
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
			this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
			this.btnInapoi.Click += new System.EventHandler(this.btnInapoi_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnInapoi_Click
		/// <summary>
		///		Eveniment specific apasarii butonului de "Inapoi" din fereastra de editare.
		/// </summary>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			this.EditMode=false;
		}
		#endregion

		#region btnSalveaza_Click
		/// <summary>
		///		Metoda care se apeleaza la apasarea butonului de salvare din fereastra de editare.
		///		Se selecteaza optiunea de Update sau Insert cu datele aferente.
		/// </summary>
		private void btnSalveaza_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.VarExists = new Salaries.Business.NomenclatorTipOreLucrate().GetTipuriOreLucrate( int.Parse( this.txtTipIntervalID.Text )).Tables[0].Rows.Count>0;
				Salaries.Data.TipOreLucrate tipOre = new Salaries.Data.TipOreLucrate();
			
				tipOre.TipIntervalID = (this.VarExists) ? int.Parse( this.txtTipIntervalID.Text ) : -1;
				tipOre.Denumire = this.txtDenumireTipOre.Text;
				tipOre.Procent = float.Parse( this.txtProcentTipOre.Text );
				tipOre.Descriere = this.txtDescriereTipOre.Text;
				tipOre.NrMaximOreSapt = float.Parse( this.txtNrMaximOreSapt.Text );
				tipOre.Standard = this.cbStandardTipOre.Checked;
				tipOre.Modificare = this.cbModificabilaTipOre.Checked;
				tipOre.Folosire = this.cbFolosireTipOre.Checked;
				tipOre.BonuriMasa = this.cbBonuriMasa.Checked;

				if( this.cbStandardTipOre.Checked )
				{
					tipOre.AplicWeekendNoapte = this.cbWeekendNoapte.Checked;
				}
				else
				{
					tipOre.AplicWeekendNoapte = false;
				}

				if((this.VarExists))
				{
					new Salaries.Business.NomenclatorTipOreLucrate().UpdateTipOreLucrate( tipOre );
				}
				else 
				{
					new Salaries.Business.NomenclatorTipOreLucrate().InsertTipOreLucrate( tipOre );
				}

				this.EditMode = false;
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnEdit_Click
		/// <summary>
		///		Metoda care se apeleaza cand se doreste adaugarea unei noi boli sau 
		///		editarea uneia existente.
		/// </summary>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			this.EditMode=true;
			this.VarExists = new Salaries.Business.NomenclatorTipOreLucrate().GetTipuriOreLucrate( int.Parse( this.txtTipIntervalID.Text )).Tables[0].Rows.Count>0;
			try
			{
				if( this.VarExists )
				{
					EnableSomeControls( false );

					int tipIntervalID = Convert.ToInt32( this.txtTipIntervalID.Text );
					Salaries.Data.TipOreLucrate tipOre  = new Salaries.Business.NomenclatorTipOreLucrate().GetDetaliiTipuriOreLucrate( int.Parse( this.txtTipIntervalID.Text ));
			
					this.txtDenumireTipOre.Text = tipOre.Denumire;

					this.labelDenumireTipOre.Text = tipOre.Denumire;

					this.txtProcentTipOre.Text = tipOre.Procent.ToString();
					this.txtDescriereTipOre.Text = tipOre.Descriere;
					this.txtNrMaximOreSapt.Text = tipOre.NrMaximOreSapt.ToString();
					this.cbStandardTipOre.Checked = tipOre.Standard;
					this.cbModificabilaTipOre.Checked = tipOre.Modificare;
					this.cbFolosireTipOre.Checked = tipOre.Folosire;
					this.cbBonuriMasa.Checked = tipOre.BonuriMasa;
					
					if( !tipOre.Standard )
					{
						this.cbWeekendNoapte.Style.Add( "display", "none" );
						this.cbWeekendNoapte.Checked = tipOre.AplicWeekendNoapte;
						this.cbStandardTipOre.Enabled = true;
					}
					else
					{
						this.cbWeekendNoapte.Style.Add( "display", "" );
						this.cbStandardTipOre.Enabled = false;
					}
				}
				else
				{
					EnableSomeControls( true );

					this.txtDenumireTipOre.Text = "";

					this.labelDenumireTipOre.Text = "";

					this.txtProcentTipOre.Text = "0";
					this.txtDescriereTipOre.Text = "";
					this.cbStandardTipOre.Checked = false;
					this.cbModificabilaTipOre.Checked = false;
					this.cbFolosireTipOre.Checked = true;
					this.cbWeekendNoapte.Style.Add( "display", "" );
					this.cbWeekendNoapte.Checked = false;
				}
				list_form.Style.Add("display","none");
				add_form.Style.Add("display","");
				btnSalveaza.Visible = true;
				btnInapoi.Visible = true;
				
				this.btnSalveaza.Enabled = true;
				
				Utilities.CreateTableHeader(add_header, "Nomenclator tipuri de ore lucrate", "../", "small");

			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnAdaugaTipOreLucrate_Click
		/// <summary>
		///		Metoda specifica pt apasarea butonului de adaugare.
		/// </summary>
		private void btnAdaugaTipOreLucrate_Click(object sender, System.EventArgs e)
		{
			try
			{
				btnEdit_Click( sender, e );
				
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion
	}
}
