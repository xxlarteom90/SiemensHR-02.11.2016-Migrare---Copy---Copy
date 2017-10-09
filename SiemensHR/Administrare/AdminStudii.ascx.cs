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
	///		Summary description for AdminStudii.
	/// </summary>
	public class AdminStudii : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.TextBox txtDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
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
		protected System.Web.UI.WebControls.TextBox txtStudiuID;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_buttonLine;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			litError.Text = "";
			lblMessage.Text = "";

			btnDelete.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta categorie de studiu?')");

			Utilities.CreateTableHeader(headerTable, "Date identificare studiu", "../", "small");
			
			txtStudiuID.Style.Add("display" ,"none");

			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularDenumire = \"" + regularDenumire.ClientID + "\"</script>");
			
			if (!IsPostBack)
				ListareStudii();
		}
		#endregion

		#region ListareStudii
		/// <summary>
		/// Listarea studiilor
		/// </summary>
		public void ListareStudii()
		{	
			try
			{
				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
				

				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista categoriilor de studiu existente";
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

				string[] tableHeader = {"Denumire categorie studiu"};
				string[] tableCols = {"Nume"};

				Salaries.Business.AdminStudii objAdminStudii = new Salaries.Business.AdminStudii();	
				ListTable objListTable = new ListTable(listTable, objAdminStudii.LoadInfoStudii(), tableHeader, tableCols);

				string[] ar_OnClickParam = {"StudiuID"};
				string[] ar_OnClickParamType = {"dataset"};

				objListTable.OnclickJSMethod = "SelectLine";
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.DrawListTableWithoutDigits();                				

				myCell.Controls.Add(listTable);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				td_editLine.Visible = false;
				add_form.Style.Add("display","none");
				btnEdit.Style.Add("display", "none");
				td_addLine.Visible = true;
				add_buttonLine.Visible = true;
				tdTitle.InnerText = "Adaugare categorie de studiu noua";
	
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
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnInapoi.Click += new System.EventHandler(this.btnInapoi_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdd_Click
		/// <summary>
		/// Adauga o categorie de studii
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try 
			{
				string newStudiu  = txtDenumire.Text;
				Salaries.Business.AdminStudii studiu = new Salaries.Business.AdminStudii();
				studiu.StudiuId = 0;
				studiu.Nume = newStudiu;
				
				if (studiu.CheckIfStudiuCanBeAdded())
				{
					studiu.InsertStudiu();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un studiu cu acelasi nume!'); </script>");
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu studii
				CreateRefreshFunctionForAddAngajat();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			ListareStudii();
		}
		#endregion

		#region btnEdit_Click
		/// <summary>
		/// Editeaza o categorie de studii
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
		/// Completeaza campurile pentru o categorie de studii
		/// </summary>
		private void FillEditForm()
		{
			try 
			{
				int studiuId = Convert.ToInt32(txtStudiuID.Text);
				Salaries.Business.AdminStudii studiu = new Salaries.Business.AdminStudii();
				studiu.StudiuId = studiuId;
				DataRow rowStudiu = studiu.GetStudiuInfo().Tables[0].Rows[0];

				txtDenumire.Text = rowStudiu["Nume"].ToString();
				txtStudiuID.Text = studiuId.ToString();

				td_addLine.Visible = false;
				td_editLine.Visible = true;
				add_form.Style.Add("display","");
				add_buttonLine.Visible = false;
				tdTitle.InnerText = "Editare categorie studiu";

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu studii
				//In acest caz va fi goala ... 
				CreateEmptyRefreshFunctionForAddAngajat();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnModify_Click
		/// <summary>
		/// Modifica o categorie de studii
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				int studiuId = Convert.ToInt32(txtStudiuID.Text);
				Salaries.Business.AdminStudii studiu = new Salaries.Business.AdminStudii();
				studiu.StudiuId = studiuId;
				studiu.Nume = txtDenumire.Text;
                
				if (studiu.CheckIfStudiuCanBeAdded())
				{
					studiu.UpdateStudiu();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un studiu cu acelasi nume!'); </script>");
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu studii
				CreateRefreshFunctionForAddAngajat();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			ListareStudii();
		}
		#endregion

		#region btnDelete_Click
		/// <summary>
		/// Sterge o categorie de studii
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				int studiuId = Convert.ToInt32(txtStudiuID.Text);
				Salaries.Business.AdminStudii studiu = new Salaries.Business.AdminStudii();
				studiu.StudiuId = studiuId;
				int sePoateSterge = studiu.CheckIfStudiuCanBeDeleted();

				if (sePoateSterge == 1)
				{
					Response.Write("<script> alert('Categoria de studiu nu poate fi stearsa! Este inca asociata unor angajati!'); </script>");
					FillEditForm();
				}
				if (sePoateSterge == 2)
				{
					Response.Write("<script> alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin o categorie de studii.'); </script>");
					FillEditForm();
				}
				if (sePoateSterge == 0)
				{
					studiu.DeleteStudiu();
					ListareStudii();
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu studii
				CreateRefreshFunctionForAddAngajat();

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
		/// Revine la lista ce contine categorii de studii
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			ListareStudii();

			//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu studii
			//In acest caz va fi goala ... 
			CreateEmptyRefreshFunctionForAddAngajat();
		}
		#endregion

		#region CreateRefreshFunctionForAddAngajat
		/// <summary>
		/// Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu studii
		/// </summary>
		private void CreateRefreshFunctionForAddAngajat()
		{
			string outStr = "";
			
			//cream scriptul care va contine functia de refresh
			//ne bazam pe faptul ca se cunoaste numele selectului care contine studiile
			//initial se sterg toate intrarile din combo
			outStr +=	"<script> \r\n function RefreshAddAngajatPage() \r\n" +
				"{ \r\n" +
				"window.opener.DeleteStudiiCombo(); \r\n" +
				" FillStudiiCOmbo(); \r\n" +
				"} \r\n";

			//acum se creeaza functie care adauga studiile din recordset
			//se foloseste o functie din AddAngajat ... FillStudiuCombo
			Salaries.Business.AdminStudii objAdminStudii = new Salaries.Business.AdminStudii();

			outStr +=	" function FillStudiiCOmbo() \r\n" +
				"{ \r\n";
			foreach ( DataRow dataRow in objAdminStudii.LoadInfoStudii().Tables[0].Rows)
			{
				outStr +=	"window.opener.FillStudiuCombo('" +
					dataRow["Nume"].ToString() + "'," +
					dataRow["StudiuID"].ToString() + ");";
			}
			
			outStr +=	"} \r\n" +
				"</script>";

			Response.Write( outStr);
		}
		#endregion

		#region CreateEmptyRefreshFunctionForAddAngajat
		/// <summary>
		/// Creeaza o functie de refresh goala pt cazul in care se incearca editare unui studiu
		/// </summary>
		private void CreateEmptyRefreshFunctionForAddAngajat()
		{
			string outStr = "";

			outStr += "<script> function RefreshAddAngajatPage() {}; </script>"
				;
			Response.Write( outStr);
		}
		#endregion
	}
}
