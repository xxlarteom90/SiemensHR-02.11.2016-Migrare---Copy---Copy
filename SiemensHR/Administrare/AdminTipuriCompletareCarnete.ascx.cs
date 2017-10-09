using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.Administrare
{
	/// <summary>
	///		Summary description for AdminTipuriCompletareCarnete.
	/// </summary>
	public class AdminTipuriCompletareCarnete : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.TextBox txtDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.TextBox txtCod;
		protected System.Web.UI.WebControls.TextBox txtTipCompletareID;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_form;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTitle;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_addLine;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_editLine;
		protected System.Web.UI.WebControls.TextBox txtProcent;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCod;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredProcent;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularProcent;
		protected System.Web.UI.WebControls.RangeValidator rangeProcent;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCod;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_buttonLine;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			litError.Text = "";

			btnDelete.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti acest tip de completare?')");

			Utilities.CreateTableHeader(headerTable, "Date identificare tip completare carnete de munca", "../", "small");
			
			txtTipCompletareID.Style.Add("display" ,"none");

			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var requiredCod = \"" + requiredCod.ClientID + "\"</script>");
			Response.Write("<script>var requiredProcent = \"" + requiredProcent.ClientID + "\"</script>");
			Response.Write("<script>var regularProcent = \"" + regularProcent.ClientID + "\"</script>");
			Response.Write("<script>var rangeProcent = \"" + rangeProcent.ClientID + "\"</script>");
			Response.Write("<script>var regularDenumire = \"" + regularDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularCod = \"" + regularCod.ClientID + "\"</script>");
			
			if (!IsPostBack)
				ListareTipuriCompletareCarnete();
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
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnInapoi.Click += new System.EventHandler(this.btnInapoi_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region ListareTipuriCompletareCarnete
		/// <summary>
		/// Lista tipurilor de completare carnete
		/// </summary>
		public void ListareTipuriCompletareCarnete()
		{
			try
			{
				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
				

				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista tipurilor de completare a carnetelor de munca";
				myCell.Height = new Unit(50);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				// lista de banci existente
				myRow = new TableRow();
				myCell = new TableCell();
				myCell.Attributes.Add("width", "100%");
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Top;
				Table listTable = new Table();

				string[] tableHeader = {"Descriere", "Cod", "Procent"};
				string[] tableCols = {"ModCompletare", "Cod", "Procent"};

				Salaries.Business.AdminTipuriCompletareCarnete objAdminTipuriCompletare = new Salaries.Business.AdminTipuriCompletareCarnete();
				objAdminTipuriCompletare.AngajatorId = GetAngajator();	
				ListTable objListTable = new ListTable(listTable, objAdminTipuriCompletare.LoadInfoTipuriCompletare(), tableHeader, tableCols);

				string[] ar_OnClickParam = {"CompletareCarneteValoriID"};
				string[] ar_OnClickParamType = {"dataset"};

				objListTable.OnclickJSMethod = "SelectLine";
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.DrawListTableWithDigits(4);                				

				myCell.Controls.Add(listTable);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				td_editLine.Visible = false;
				add_form.Style.Add("display","none");
				btnEdit.Style.Add("display", "none");
				td_addLine.Visible = true;
				add_buttonLine.Visible = true;
				tdTitle.InnerText = "Adaugare tip completare carnete de munca";
	
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnAdd_Click
		/// <summary>
		/// Adauga un tip de completare
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try 
			{
				Salaries.Business.AdminTipuriCompletareCarnete tipCompletareCarnet = new Salaries.Business.AdminTipuriCompletareCarnete();
				tipCompletareCarnet.TipCompletareCarnetId = 0;
				tipCompletareCarnet.AngajatorId = GetAngajator();
				tipCompletareCarnet.Descriere  = txtDenumire.Text;
				tipCompletareCarnet.Cod = txtCod.Text;
				tipCompletareCarnet.Procent = float.Parse(txtProcent.Text);
				
				if (tipCompletareCarnet.CheckIfCarneteTipuriCanBeAdded())
				{
					tipCompletareCarnet.InsertTipCompletare();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un tip ce completare de carnete cu aceleasi date!'); </script>");
				}
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			ListareTipuriCompletareCarnete();
		}
		#endregion

		#region btnModify_Click
		/// <summary>
		/// Modifica un tip de completare
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				int tipCompletareId = Convert.ToInt32(txtTipCompletareID.Text);
				Salaries.Business.AdminTipuriCompletareCarnete tipCompletareCarnet = new Salaries.Business.AdminTipuriCompletareCarnete();
				tipCompletareCarnet.TipCompletareCarnetId = tipCompletareId;
				tipCompletareCarnet.AngajatorId = GetAngajator();
				tipCompletareCarnet.Descriere  = txtDenumire.Text;
				tipCompletareCarnet.Cod = txtCod.Text;
				tipCompletareCarnet.Procent = float.Parse(txtProcent.Text);
                				
				if (tipCompletareCarnet.CheckIfCarneteTipuriCanBeAdded())
				{
					tipCompletareCarnet.UpdateTipCompletare();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un tip ce completare de carnete cu aceleasi date!'); </script>");
				}				
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			ListareTipuriCompletareCarnete();
		}
		#endregion

		#region btnDelete_Click
		/// <summary>
		/// Sterge un tip de completare
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				int tipCompletareId = Convert.ToInt32(txtTipCompletareID.Text);
				Salaries.Business.AdminTipuriCompletareCarnete objAdminTipuriCompletare = new Salaries.Business.AdminTipuriCompletareCarnete();
				objAdminTipuriCompletare.AngajatorId = GetAngajator();
				objAdminTipuriCompletare.TipCompletareCarnetId = tipCompletareId;	
				
				int sePoateSterge = objAdminTipuriCompletare.CheckIfTipCompletareCarnetCanBeDeleted();	
				if ( sePoateSterge == 1)
				{
					Response.Write("<script> alert('Tipul de completare nu poate fi sters! Este inca asociat unor angajatori!'); </script>");
					FillEditForm();
				}
				if ( sePoateSterge == 2)
				{
					Response.Write("<script> alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin un tip de completare de carnet de munca.'); </script>");
					FillEditForm();
				}
				if ( sePoateSterge == 0)
				{
					objAdminTipuriCompletare.DeleteTipCompletare();
					ListareTipuriCompletareCarnete();
				}	
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
		/// Editeaza un tip de completare
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			FillEditForm();
		}
		#endregion

		#region FillEditForm
		/// <summary>
		/// Completeaza campurile unui tip de completare
		/// </summary>
		private void FillEditForm()
		{
			try 
			{
				int tipCompletareId = Convert.ToInt32(txtTipCompletareID.Text);
				
				Salaries.Business.AdminTipuriCompletareCarnete objAdminTipuriCompletare = new Salaries.Business.AdminTipuriCompletareCarnete();
				objAdminTipuriCompletare.AngajatorId = GetAngajator();
				objAdminTipuriCompletare.TipCompletareCarnetId = tipCompletareId;					
				DataRow rowTipCompletare = objAdminTipuriCompletare.GetTipCompletareInfo().Tables[0].Rows[0];

				txtDenumire.Text = rowTipCompletare["ModCompletare"].ToString();
				txtCod.Text = rowTipCompletare["Cod"].ToString();
				txtProcent.Text = rowTipCompletare["Procent"].ToString();

				td_addLine.Visible = false;
				td_editLine.Visible = true;
				add_form.Style.Add("display","");
				add_buttonLine.Visible = false;
				tdTitle.InnerText = "Editare tip completare carnete munca";
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnInapoi_Click
		/// <summary>
		/// Revine la lista cu tipuri de completare
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			ListareTipuriCompletareCarnete();
		}
		#endregion
	}
}
