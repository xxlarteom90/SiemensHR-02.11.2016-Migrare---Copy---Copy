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
	///		Summary description for AdminInvaliditati.
	/// </summary>
	public class AdminInvaliditati : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.TextBox txtDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.TextBox txtDescriere;
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
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCoeficient;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCoeficient;
		protected System.Web.UI.WebControls.TextBox txtInvaliditateID;
		protected System.Web.UI.WebControls.TextBox txtCoeficient;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDescriere;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_buttonLine;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			litError.Text = "";

			btnDelete.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta categorie?')");
			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var requiredCoeficient = \"" + requiredCoeficient.ClientID + "\"</script>");
			Response.Write("<script>var regularDenumire = \"" + regularDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularCoeficient = \"" + regularCoeficient.ClientID + "\"</script>");
			Response.Write("<script>var regularDescriere = \"" + regularDescriere.ClientID + "\"</script>");

			Utilities.CreateTableHeader(headerTable, "Date identificare categorie", "../", "small");
			
			txtInvaliditateID.Style.Add("display" ,"none");
			
			if (!IsPostBack)
				ListareInvaliditati();
		}
		#endregion

		#region ListareInvaliditati
		public void ListareInvaliditati()
		{
			try
			{
				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
				

				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista invaliditatilor existente";
				myCell.Height = new Unit(50);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				// lista de invaliditati existente
				myRow = new TableRow();
				myCell = new TableCell();
				myCell.Attributes.Add("width", "100%");
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Top;
				Table listTable = new Table();

				string[] tableHeader = {"Denumire", "Coeficient", "Descriere"};
				string[] tableCols = {"Nume", "Coeficient", "Descriere"};

				Salaries.Business.AdminInvaliditati objAdminInvaliditati = new Salaries.Business.AdminInvaliditati();
				ListTable objListTable = new ListTable(listTable, objAdminInvaliditati.LoadInfoInvaliditati(), tableHeader, tableCols);

				string[] ar_OnClickParam = {"InvaliditateID"};
				string[] ar_OnClickParamType = {"dataset"};

				objListTable.OnclickJSMethod = "SelectLine";
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.DrawListTableWithDigits();                				

				myCell.Controls.Add(listTable);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				td_editLine.Visible = false;
				add_form.Style.Add("display","none");
				btnEdit.Style.Add("display", "none");
				td_addLine.Visible = true;
				add_buttonLine.Visible = true;
				tdTitle.InnerText = "Adaugare invaliditate";
	
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
		/// Adauga un tip de invaliditate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try 
			{
				Salaries.Business.AdminInvaliditati newInvaliditate = new Salaries.Business.AdminInvaliditati();
				newInvaliditate.InvaliditateId = 0;
				newInvaliditate.Nume = txtDenumire.Text;
				newInvaliditate.Coeficient = float.Parse( txtCoeficient.Text );
				newInvaliditate.Descriere = txtDescriere.Text;
				
				if (newInvaliditate.CheckIfInvaliditateCanBeAdded())
				{
					newInvaliditate.InsertInvaliditate();
				}
				else
				{
					Response.Write("<script> alert('Mai exista o invaliditate cu aceleasi date!'); </script>");
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu invaliditati
				CreateRefreshFunctionForAddAngajat();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			ListareInvaliditati();
		}
		#endregion

		#region btnModify_Click
		/// <summary>
		/// Modifica un tip de invaliditate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				int invaliditateId = Convert.ToInt32(txtInvaliditateID.Text);
				Salaries.Business.AdminInvaliditati objInvaliditate = new Salaries.Business.AdminInvaliditati();

				objInvaliditate.InvaliditateId = invaliditateId;
				objInvaliditate.Nume = txtDenumire.Text;
				objInvaliditate.Coeficient = float.Parse( txtCoeficient.Text );
				objInvaliditate.Descriere = txtDescriere.Text;
                
				if (objInvaliditate.CheckIfInvaliditateCanBeAdded())
				{
					objInvaliditate.UpdateInvaliditate();
				}
				else
				{
					Response.Write("<script> alert('Modificarea nu a fost efectuata deoarece mai exista o invaliditate cu acelasi date!'); </script>");
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu invaliditati
				CreateRefreshFunctionForAddAngajat();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			ListareInvaliditati();
		}
		#endregion

		#region btnDelete_Click
		/// <summary>
		/// Sterge un tip de invaliditate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				int invaliditateId = Convert.ToInt32(txtInvaliditateID.Text);
				Salaries.Business.AdminInvaliditati invaliditate = new Salaries.Business.AdminInvaliditati();
				invaliditate.InvaliditateId = invaliditateId;
				int sePoateSterge = invaliditate.CheckIfInvaliditateCanBeDeleted();
				
				if (sePoateSterge == 0)
				{
					invaliditate.DeleteInvaliditate();
					ListareInvaliditati();
				}
				if (sePoateSterge == 1)
				{
					Response.Write( "<script>alert( 'Stergerea nu poate fi efectuata deoarece sunt introdusi angajati cu acest tip de invaliditate!' );</script>" );
					FillEditForm();
				}
				if (sePoateSterge == 2)
				{
					Response.Write( "<script>alert( 'Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin o invaliditate.' );</script>" );
					FillEditForm();
				}

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu invaliditati
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
		/// Editeaza un tip de invaliditate
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
		/// Completeaza campurile pentru un tip de invaliditate
		/// </summary>
		private void FillEditForm()
		{
			try 
			{
				int invaliditateId = Convert.ToInt32(txtInvaliditateID.Text);
				Salaries.Business.AdminInvaliditati invaliditate = new Salaries.Business.AdminInvaliditati();
				invaliditate.InvaliditateId = invaliditateId;
				DataRow rowInvaliditate = invaliditate.GetInvaliditateInfo().Tables[0].Rows[0];

				txtDenumire.Text = rowInvaliditate["Nume"].ToString();
				txtCoeficient.Text = rowInvaliditate["Coeficient"].ToString();
				txtDescriere.Text = rowInvaliditate["Descriere"].ToString();
				txtInvaliditateID.Text = invaliditateId.ToString();

				td_addLine.Visible = false;
				td_editLine.Visible = true;
				add_form.Style.Add("display","");
				add_buttonLine.Visible = false;
				tdTitle.InnerText = "Editare invaliditate";
				//lblMessage.Visible = false;

				//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu invaliditati
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
		/// Revine la lista cu invaliditati
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			ListareInvaliditati();

			//Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu invaliditati
			//In acest caz va fi goala ... 
			CreateEmptyRefreshFunctionForAddAngajat();
		}
		#endregion

		#region CreateRefreshFunctionForAddAngajat
		/// <summary>
		/// Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va face refresh la combo-ul cu invaliditati
		/// </summary>
		private void CreateRefreshFunctionForAddAngajat()
		{
			string outStr = "";
			
			//cream scriptul care va contine functia de refresh
			//ne bazam pe faptul ca se cunoaste numele selectului care contine invaliditatile
			//initial se sterg toate intrarile din combo
			outStr +=	"<script> \r\n function RefreshAddAngajatPage() \r\n" +
				"{ \r\n" +
				"window.opener.DeleteInvaliditatiCombo(); \r\n" +
				" FillInvaliditatiCOmbo(); \r\n" +
				"} \r\n";

			//acum se creeaza functie care adauga invaliditatile din recordset
			//se foloseste o functie din AddAngajat ... FillInvaliditateCombo
			Salaries.Business.AdminInvaliditati objAdminInvaliditati = new Salaries.Business.AdminInvaliditati();
			
			outStr +=	" function FillInvaliditatiCOmbo() \r\n" +
				"{ \r\n";
			foreach ( DataRow dataRow in objAdminInvaliditati.LoadInfoInvaliditati().Tables[0].Rows)
			{
				outStr +=	"window.opener.FillInvaliditateCombo('" +
					dataRow["Nume"].ToString() + "'," +
					dataRow["InvaliditateID"].ToString() + ");";
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

			outStr += "<script> function RefreshAddAngajatPage() {}; </script>"
				;
			Response.Write( outStr);
		}
		#endregion
	}
}
