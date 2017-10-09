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
	///		Summary description for AdminTitluriAngajati.
	/// </summary>
	public class AdminTitluriAngajati : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.TextBox txtDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_form;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTitle;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_addLine;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_editLine;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.TextBox txtTitluAngajatID;
		protected System.Web.UI.WebControls.TextBox txtSimbol;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularSimbol;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredSimbol;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_buttonLine;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			litError.Text = "";

			btnDelete.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti acest titlu?')");

			Utilities.CreateTableHeader(headerTable, "Date identificare titlu angajat", "../", "small");
			
			txtTitluAngajatID.Style.Add("display" ,"none");

			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularDenumire = \"" + regularDenumire.ClientID + "\"</script>");
			Response.Write("<script>var requiredSimbol = \"" + requiredSimbol.ClientID + "\"</script>");
			Response.Write("<script>var regularSimbol = \"" + regularSimbol.ClientID + "\"</script>");
			
			if (!IsPostBack)
				ListareTitluriAngajati();
		}
		#endregion

		#region ListareTitluriAngajati
		/// <summary>
		/// Listarea titlurilor angajatilor
		/// </summary>
		public void ListareTitluriAngajati()
		{
			try
			{
				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
				

				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista titlurilor existente";
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

				string[] tableHeader = {"Denumire", "Simbol"};
				string[] tableCols = {"Denumire", "Simbol"};

				Salaries.Business.AdminTitluriAngajati objAdminTitluriAngajati = new Salaries.Business.AdminTitluriAngajati();
				ListTable objListTable = new ListTable(listTable, objAdminTitluriAngajati.LoadInfoTitluriAngajati(), tableHeader, tableCols);

				string[] ar_OnClickParam = {"TitluID"};
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
				tdTitle.InnerText = "Adaugare titlu angajat";
				lblMessage.Text ="";
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
		/// Adauga un titlu pentru angajati
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try 
			{
				Salaries.Business.AdminTitluriAngajati newTitluAngajat = new Salaries.Business.AdminTitluriAngajati();
				newTitluAngajat.TitluId = 0;
				newTitluAngajat.Denumire  = txtDenumire.Text;
				newTitluAngajat.Simbol = txtSimbol.Text;
				
				if (newTitluAngajat.CheckIfTitluAngajatCanBeAdded())
				{
					newTitluAngajat.InsertTitluAngajat();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un titlu cu aceste date!'); </script>");
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu titluri
				CreateRefreshFunctionForAddAngajat();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			ListareTitluriAngajati();
		}
		#endregion

		#region btnModify_Click
		/// <summary>
		/// Modifica un titlu pentru angajati
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				int titluAngajatId = Convert.ToInt32(txtTitluAngajatID.Text);
				Salaries.Business.AdminTitluriAngajati objTitluAngajat = new Salaries.Business.AdminTitluriAngajati();
				objTitluAngajat.TitluId = titluAngajatId;
				objTitluAngajat.Denumire  = txtDenumire.Text;
				objTitluAngajat.Simbol = txtSimbol.Text;
                
				if (objTitluAngajat.CheckIfTitluAngajatCanBeAdded())
				{
					objTitluAngajat.UpdateTitluAngajat();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un titlu cu aceste date!'); </script>");
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu titluri
				CreateRefreshFunctionForAddAngajat();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			ListareTitluriAngajati();
		}
		#endregion

		#region btnDelete_Click
		/// <summary>
		/// Sterge un titlu pentru angajati
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				int titluAngajatId = Convert.ToInt32(txtTitluAngajatID.Text);
				Salaries.Business.AdminTitluriAngajati titluri = new Salaries.Business.AdminTitluriAngajati();
				titluri.TitluId = titluAngajatId;
				
				int sePoateSterge = titluri.CheckIfTitluAngajatCanBeDeleted();
				if (sePoateSterge == 1)
				{
					Response.Write("<script> alert('Titlul nu poate fi sters! Este inca asociat unor angajati!'); </script>");
					FillEditForm();
				}
				if (sePoateSterge == 2)
				{
					Response.Write("<script> alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin un titlu.'); </script>");
					FillEditForm();
				}
				if (sePoateSterge == 0)
				{
					titluri.DeleteTitluAngajat();
					ListareTitluriAngajati();
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu titluri
				CreateRefreshFunctionForAddAngajat();

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
		/// Editeaza un titlu pentru angajati
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
		/// Completeaza campurile pentru un titlu
		/// </summary>
		private void FillEditForm()
		{
			try 
			{
				int titluAngajatId = Convert.ToInt32(txtTitluAngajatID.Text);
				Salaries.Business.AdminTitluriAngajati titluri = new Salaries.Business.AdminTitluriAngajati();
				titluri.TitluId = titluAngajatId;
				DataRow rowTitlu = titluri.GetTitluAngajatInfo().Tables[0].Rows[0];

				txtDenumire.Text = rowTitlu["Denumire"].ToString();
				txtSimbol.Text = rowTitlu["Simbol"].ToString();
				txtTitluAngajatID.Text = titluAngajatId.ToString();

				td_addLine.Visible = false;
				td_editLine.Visible = true;
				add_form.Style.Add("display","");
				add_buttonLine.Visible = false;
				tdTitle.InnerText = "Editare titlu angajat";
				//lblMessage.Visible = false;

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu titluri
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

		#region btnInapoi_Click
		/// <summary>
		/// Revine la lista cu titluri
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			ListareTitluriAngajati();

			//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu titluri
			//In acest caz va fi goala ...
			CreateEmptyRefreshFunctionForAddAngajat();
		}
		#endregion

		#region CreateRefreshFunctionForAddAngajat
		/// <summary>
		/// Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu titluri
		/// </summary>
		private void CreateRefreshFunctionForAddAngajat()
		{
			string outStr = "";
			
			//cream scriptul care va contine functia de refresh
			//ne bazam pe faptul ca se cunoaste numele selectului care contine titlurile
			//initial se sterg toate intrarile din combo
			outStr +=	"<script> \r\n function RefreshAddAngajatPage() \r\n" +
						"{ \r\n" +
						"window.opener.DeleteTitluCombo(); \r\n" +
						" FillTitluriCOmbo(); \r\n" +
						"} \r\n";

			//acum se creeaza functie care adauga titlurile din recordset
			//se foloseste o functie din AddAngajat ... FillTitluCombo
			Salaries.Business.AdminTitluriAngajati objAdminTitluriAngajati = new Salaries.Business.AdminTitluriAngajati();

			outStr +=	" function FillTitluriCOmbo() \r\n" +
						"{ \r\n";
			foreach ( DataRow dataRow in objAdminTitluriAngajati.LoadInfoTitluriAngajati().Tables[0].Rows)
			{
				outStr +=	"window.opener.FillTitluCombo('" +
							dataRow["Simbol"].ToString() + " - " + dataRow["Denumire"].ToString() + "'," +
							dataRow["TitluID"].ToString() + ");";
			}
			
			outStr +=	"} \r\n" +
						"</script>";

			Response.Write( outStr);
		}
		#endregion

		#region CreateEmptyRefreshFunctionForAddAngajat
		/// <summary>
		/// Creeaza o functie de refresh goala pt cazul in care se incearca editare unui titlu
		/// </summary>
		private void CreateEmptyRefreshFunctionForAddAngajat()
		{
			string outStr = "";
			outStr += "<script> function RefreshAddAngajatPage() {}; </script>";
			Response.Write( outStr);
		}
		#endregion
	}
}
