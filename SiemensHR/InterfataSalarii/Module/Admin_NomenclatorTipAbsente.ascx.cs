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
	///		Summary description for Admin_NomenclatorTipAbsente.
	/// </summary>
	public class Admin_NomenclatorTipAbsente : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Table add_header;
		protected System.Web.UI.WebControls.Button btnSalveaza;
		protected System.Web.UI.WebControls.Button btnSterge;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTable list_form;
		protected System.Web.UI.WebControls.TextBox txtDenumireTipAbsenta;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumireTipAbsenta;
		protected System.Web.UI.WebControls.TextBox txtProcentTipAbsenta;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredProcentTipAbsenta;
		protected System.Web.UI.WebControls.TextBox txtDescriereTipAbsenta;
		protected System.Web.UI.WebControls.CheckBox cbMedicalTipAbsenta;
		protected System.Web.UI.WebControls.CheckBox cbModificabilaTipAbsenta;
		protected System.Web.UI.WebControls.CheckBox cbFolosireTipAbsenta;
		protected System.Web.UI.WebControls.TextBox txtCodTipAbsenta;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCodTipAbsenta;
		protected System.Web.UI.HtmlControls.HtmlTable add_form;
		protected System.Web.UI.WebControls.TextBox txtTipAbsentaID;
		protected System.Web.UI.WebControls.Button btnAdaugaTipAbsenta;

		protected bool VarExists = false;
		protected System.Web.UI.WebControls.Label labelDenumireTipAbsenta;
		protected System.Web.UI.WebControls.Label labelCodTipAbsenta;
		protected System.Web.UI.WebControls.CheckBox cbAbsentaLucratoare;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.RangeValidator rngVldProcent;
		protected bool EditMode = false;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.ClientID+"\"</script>";
			Response.Write( script_text );
			litError.Text = "";

			btnEdit.Style.Add( "display", "none" );
			txtTipAbsentaID.Style.Add( "display", "none" );

			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			UtilitiesDb utilDb = new UtilitiesDb( settings.ConnectionString);
						
			if( !IsPostBack )
			{
				this.btnSalveaza.Enabled = true;
			}
		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			if (!this.EditMode)		
			{
				ListTipAbsente();
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
				Salaries.Data.TipAbsente tipAbs = new Salaries.Business.NomenclatorTipAbsente().GetDetaliiTipuriAbsente( int.Parse( this.txtTipAbsentaID.Text ));
				if( tipAbs.Modificare )
				{
					this.labelDenumireTipAbsenta.Visible = false;
					this.txtDenumireTipAbsenta.Visible = true;

					this.labelCodTipAbsenta.Visible = false;
					this.txtCodTipAbsenta.Visible = true;

					this.cbModificabilaTipAbsenta.Enabled = true;
				}
				else
				{
					this.labelDenumireTipAbsenta.Visible = true;
					this.txtDenumireTipAbsenta.Visible = false;

					this.labelCodTipAbsenta.Visible = true;
					this.txtCodTipAbsenta.Visible = false;

					this.cbModificabilaTipAbsenta.Enabled = false;
				}
			}
			else
			{
				labelDenumireTipAbsenta.Visible = false;
				this.txtDenumireTipAbsenta.Visible = true;

				this.labelCodTipAbsenta.Visible = false;
				this.txtCodTipAbsenta.Visible = true;

				this.cbModificabilaTipAbsenta.Enabled = true;
			}
		}
		#endregion

		#region ListTipAbsente
		/// <summary>
		///		Cu ajutorul metodei ListTipAbsente se genereaza tabelul ce va fi afisat. 
		///		Acest tabel contine toate tipurile de absente existente in baza de date.
		/// </summary>
		private void ListTipAbsente()
		{
			try
			{
				list_form.Style.Add("display","");
				add_form.Style.Add("display","none");
				btnSalveaza.Visible = false;
				btnInapoi.Visible = false;
				txtTipAbsentaID.Text = "0";

				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
				
				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Nomenclator tipuri absente";
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

				string[] tableHeader = { "Denumire", "Cod", "Procent", "Descriere", "Absenta medicala", "Modificabila ulterior", "Folosire curenta", "Absenta lucratoare" };
				string[] tableCols = { "Denumire", "CodAbsenta", "Procent", "Descriere", "Medical", "Modificare", "Folosire", "Lucratoare" };
				ListTable objListTable = new ListTable( listTable, new Salaries.Business.NomenclatorTipAbsente().GetTipuriAbsente(), tableHeader, tableCols );

				objListTable.textForEmptyDataSet = "Nu exista date in nomenclatorul de tipuri de absente!";

				string[] ar_OnClickParam = { "TipAbsentaID" };
				string[] ar_OnClickParamType = { "dataset" };

				objListTable.OnclickJSMethod = "SelectTipAbsenta";
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.DrawListTableWithDigits();                				

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
			this.btnAdaugaTipAbsenta.Click += new System.EventHandler(this.btnAdaugaTipAbsenta_Click);
			this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
			this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
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
				this.VarExists = new Salaries.Business.NomenclatorTipAbsente().GetTipuriAbsente( int.Parse( this.txtTipAbsentaID.Text )).Tables[0].Rows.Count>0;
				Salaries.Data.TipAbsente tipAbs = new Salaries.Data.TipAbsente();
				
				tipAbs.TipAbsentaID = (this.VarExists) ? int.Parse( this.txtTipAbsentaID.Text ) : -1;
				tipAbs.Denumire = this.txtDenumireTipAbsenta.Text;
				tipAbs.CodAbsenta = this.txtCodTipAbsenta.Text;
				tipAbs.Procent = float.Parse( this.txtProcentTipAbsenta.Text );
				tipAbs.Descriere = this.txtDescriereTipAbsenta.Text;
				tipAbs.Medical = this.cbMedicalTipAbsenta.Checked;
				tipAbs.Modificare = this.cbModificabilaTipAbsenta.Checked;
				tipAbs.Folosire = this.cbFolosireTipAbsenta.Checked;
				tipAbs.Lucratoare = this.cbAbsentaLucratoare.Checked;

				if( this.VarExists )
				{
					new Salaries.Business.NomenclatorTipAbsente().UpdateTipAbsenta( tipAbs );
				}
				else 
				{
					new Salaries.Business.NomenclatorTipAbsente().InsertTipAbsenta( tipAbs );
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
			this.VarExists = new Salaries.Business.NomenclatorTipAbsente().GetTipuriAbsente( int.Parse( this.txtTipAbsentaID.Text )).Tables[0].Rows.Count>0;
			
			try
			{
				if( this.VarExists )
				{
					EnableSomeControls( false );
					int tipAbsentaID = Convert.ToInt32( this.txtTipAbsentaID.Text );
					Salaries.Data.TipAbsente tipAbs  = new Salaries.Business.NomenclatorTipAbsente().GetDetaliiTipuriAbsente( int.Parse( this.txtTipAbsentaID.Text ));
			
					this.txtDenumireTipAbsenta.Text = tipAbs.Denumire;
					this.labelDenumireTipAbsenta.Text = tipAbs.Denumire;
					this.txtCodTipAbsenta.Text = tipAbs.CodAbsenta;
					this.labelCodTipAbsenta.Text = tipAbs.CodAbsenta;
					this.txtProcentTipAbsenta.Text = tipAbs.Procent.ToString();
					this.txtDescriereTipAbsenta.Text = tipAbs.Descriere;
					this.cbMedicalTipAbsenta.Checked = tipAbs.Medical;
					this.cbModificabilaTipAbsenta.Checked = tipAbs.Modificare;
					this.cbFolosireTipAbsenta.Checked = tipAbs.Folosire;
					this.cbAbsentaLucratoare.Checked = tipAbs.Lucratoare;
					this.btnSterge.Visible = true;
				}
				else
				{
					EnableSomeControls( true );

					this.txtDenumireTipAbsenta.Text = "";
					this.txtCodTipAbsenta.Text = "";
					this.txtProcentTipAbsenta.Text = "0";
					this.txtDescriereTipAbsenta.Text = "";
					this.cbMedicalTipAbsenta.Checked = false;
					this.cbModificabilaTipAbsenta.Checked = false;
					this.cbFolosireTipAbsenta.Checked = true;
					this.cbAbsentaLucratoare.Checked = false;
				}
				list_form.Style.Add("display","none");
				add_form.Style.Add("display","");
				btnSalveaza.Visible = true;
				btnSterge.Visible = false;
				btnInapoi.Visible = true;
				
				this.btnSalveaza.Enabled = true;
				
				Utilities.CreateTableHeader(add_header, "Nomenclator tipuri de absente", "../", "small");

			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnAdaugaTipAbsenta_Click
		/// <summary>
		///		Metoda specifica pt apasarea butonului de adaugare.
		/// </summary>
		private void btnAdaugaTipAbsenta_Click(object sender, System.EventArgs e)
		{
			try
			{
				//AddMode = true;
				//EnableSomeControls( true );
				btnEdit_Click( sender, e );
				
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnSterge_Click
		/// <summary>
		///		Metoda specifica pt apasarea butonului de stergere.
		/// </summary>
		private void btnSterge_Click(object sender, System.EventArgs e)
		{
			try
			{
				int tipAbsentaID = Convert.ToInt32( this.txtTipAbsentaID.Text );

				if( this.txtDenumireTipAbsenta.Visible )
				{
					new Salaries.Business.NomenclatorTipAbsente().DeleteTipAbsenta( tipAbsentaID );
				}
				else
				{
					Response.Write( "<script>alert( '"+InterfataSalarii.Classes.Definitions.AlertStergereTipOraLucruImposibila+"' );</script>" );
				}
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
