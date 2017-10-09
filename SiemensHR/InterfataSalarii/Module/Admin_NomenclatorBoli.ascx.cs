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
	///		Aceasta clasa se mapeaza pe tabela "Boli". Cu ajutorul ei se realizeaza 
	///		managementul nomenclatorului de boli.
	/// </summary>
	public class Admin_NomenclatorBoli : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Table add_header;
		protected System.Web.UI.WebControls.Button btnSalveaza;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTable list_form;
		protected System.Web.UI.WebControls.TextBox txtCodBoala;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCodBoala;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCodBoala;
		protected System.Web.UI.WebControls.TextBox txtProcent;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredProcent;
		protected System.Web.UI.WebControls.TextBox txtCategorieBoala;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCategorieBoala;
		protected System.Web.UI.HtmlControls.HtmlTable add_form;
		protected System.Web.UI.WebControls.TextBox txtBoalaID;
		protected System.Web.UI.WebControls.Button btnAdaugaCategorie;
		protected System.Web.UI.WebControls.Button btnSterge;
		protected System.Web.UI.WebControls.CheckBox cbStagiu;

		protected Salaries.Configuration.ModuleSettings settings;

		protected bool VarExists = false;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected bool EditMode = false;
		#endregion

		#region Page_Load
		/// <summary>
		///	Se initializeaza datele specifice paginii
		/// </summary>
		private void Page_Load( object sender, System.EventArgs e )
		{
			string script_text = "<script>var ctrlID = \""+this.ClientID+"\"</script>";
			Response.Write( script_text );
			litError.Text = "";
			
			btnEdit.Style.Add( "display", "none" );
			txtBoalaID.Style.Add( "display", "none" );

			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			UtilitiesDb utilDb = new UtilitiesDb( settings.ConnectionString );
									
			if( !IsPostBack )
			{
				this.btnSalveaza.Enabled = true;
			}
		}
		#endregion

		#region OnPreRender
		/// <summary>
		///	Aceasta metoda are ca scop setarea continutului paginii
		/// </summary>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			
			if (!this.EditMode )		
			{
				ListBoli();
			}
		}
		#endregion

		#region ListBoli
		/// <summary>
		///		Cu ajutorul metodei ListBoli se genereaza tabelul ce va fi afisat. 
		///		Acest tabel contine toate bolile existente in baza de date.
		/// </summary>
		private void ListBoli()
		{
			try
			{
				list_form.Style.Add("display","");
				add_form.Style.Add("display","none");
				btnSalveaza.Visible = false;
				btnInapoi.Visible = false;
				txtBoalaID.Text = "0";

				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
				
				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Nomenclator boli";
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

				string[] tableHeader = { "Cod boala", "Categorie boala", "Procent", "Necesita Stagiu" };
				string[] tableCols = { "Cod", "Categorie", "Procent", "Stagiu" };
				ListTable objListTable = new ListTable(listTable, new Salaries.Business.NomenclatorBoli().GetBoli(), tableHeader, tableCols);

				objListTable.textForEmptyDataSet = "Nu exista date in nomenclatorul de boli!";

				string[] ar_OnClickParam = { "BoalaID" };
				string[] ar_OnClickParamType = { "dataset" };

				objListTable.OnclickJSMethod = "SelectBoala";
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
			this.btnAdaugaCategorie.Click += new System.EventHandler(this.btnAdaugaCategorie_Click);
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
				this.VarExists = new Salaries.Business.NomenclatorBoli().GetBoli( this.txtBoalaID.Text ).Tables[0].Rows.Count>0;
				Salaries.Data.Boala boala = new Salaries.Data.Boala();

				boala.CodBoala = this.txtCodBoala.Text;
				boala.CategorieBoala = this.txtCategorieBoala.Text;
				boala.Procent = float.Parse( this.txtProcent.Text );
				boala.BoalaId = (this.VarExists) ? int.Parse( this.txtBoalaID.Text ) : -1;
				boala.Stagiu = cbStagiu.Checked;

				string stagiu = cbStagiu.Checked ? "da" : "nu"; 

				//se verifica mai intai daca nu exista o boala cu aceleasi date
				bool adauga = new Salaries.Business.NomenclatorBoli().CheckIfBoalaCanBeAdded(boala.BoalaId, boala.CodBoala, boala.CategorieBoala, boala.Procent, stagiu);
				if (adauga)
				{
					if( this.VarExists )
					{
						new Salaries.Business.NomenclatorBoli().UpdateBoala( boala );
					}
					else 
					{
						new Salaries.Business.NomenclatorBoli().AddBoala( boala );
					}
				}
				else
				{
					//daca exista se va afisa un mesaj de avertizare
					Response.Write("<script> alert('Mai exista o boala cu aceste date!'); </script>");
				}
				this.EditMode = false;//adaugat de vlad
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
			this.VarExists = new Salaries.Business.NomenclatorBoli().GetBoli( this.txtBoalaID.Text ).Tables[0].Rows.Count>0;
			try
			{
				if( this.VarExists )
				{
					int BoalaID = Convert.ToInt32( txtBoalaID.Text );
					Salaries.Data.Boala boala  = new Salaries.Business.NomenclatorBoli().GetDetalii( this.txtBoalaID.Text );
			
					this.txtCodBoala.Text = boala.CodBoala;
					this.txtCategorieBoala.Text = boala.CategorieBoala;
					this.txtProcent.Text = boala.Procent.ToString();
					this.cbStagiu.Checked = boala.Stagiu;
					this.btnSterge.Visible = true;
				}
				else
				{
					this.txtCodBoala.Text = "";
					this.txtCategorieBoala.Text = "";
					this.txtProcent.Text = "";
					this.cbStagiu.Checked = false;
					this.btnSterge.Visible = false;
				}
				list_form.Style.Add("display","none");
				add_form.Style.Add("display","");
				btnSalveaza.Visible = true;
				btnInapoi.Visible = true;
			
				this.btnSalveaza.Enabled = true;
				
				Utilities.CreateTableHeader(add_header, "Nomenclator boli", "../", "small");
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnAdaugaCategorie_Click
		/// <summary>
		///		Metoda specifica pt apasarea butonului de adaugare.
		/// </summary>
		private void btnAdaugaCategorie_Click(object sender, System.EventArgs e)
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

		#region btnSterge_Click
		/// <summary>
		///		Metoda specifica pt apasarea butonului de stergere.
		/// </summary>
		private void btnSterge_Click(object sender, System.EventArgs e)
		{
			try
			{
				int BoalaID = Convert.ToInt32( txtBoalaID.Text );
				int sePoateSterge = new Salaries.Business.NomenclatorBoli().CheckIfBoalaCanBeDeleted(BoalaID);

				if (sePoateSterge == 0)
				{
					new Salaries.Business.NomenclatorBoli().DeleteBoala( BoalaID );
				}
				if (sePoateSterge == 1)
				{
					Response.Write("<script> alert('Aceasta boala nu poate fi stearsa pentru ca exista integistrari atasate ei!'); </script>");
				}
				if (sePoateSterge == 2)
				{
					Response.Write("<script>alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin o boala.');</script>");
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
