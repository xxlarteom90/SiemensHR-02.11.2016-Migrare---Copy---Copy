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
	///		Summary description for AdminTipuriRapoarte.
	/// </summary>
	public class AdminTipuriRapoarte : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.TextBox txtDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.TextBox txtDescriere;
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
		protected System.Web.UI.WebControls.TextBox txtTipRaportID;
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
			lblMessage.Visible = false;

			btnDelete.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti acest tip de raport?')");

			Utilities.CreateTableHeader(headerTable, "Date identificare tip raport", "../", "small");
			
			txtTipRaportID.Style.Add("display" ,"none");

			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularDenumire = \"" + regularDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularDescriere = \"" + regularDescriere.ClientID + "\"</script>");
			Response.Write("<script>var lblMessage = \"" + lblMessage.ClientID + "\"</script>");
			
			if (!IsPostBack)
				ListareTipuriRapoarte();
		}
		#endregion

		#region ListareTipuriRapoarte
		/// <summary>
		/// Listarea tipurilor de rapoarte
		/// </summary>
		public void ListareTipuriRapoarte()
		{
			try
			{
				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
				

				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista tipurilor de rapoarte existente";
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

				string[] tableHeader = {"Denumire", "Descriere"};
				string[] tableCols = {"Denumire", "Descriere"};

				Salaries.Business.AdminTipuriRapoarte objAdminTipuriRapoarte = new Salaries.Business.AdminTipuriRapoarte();	
				ListTable objListTable = new ListTable(listTable, objAdminTipuriRapoarte.LoadInfoTipuriRapoarte(), tableHeader, tableCols);

				string[] ar_OnClickParam = {"TipRaportID"};
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
				tdTitle.InnerText = "Adaugare tip raport";
	
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
		/// Adauga un tip de raport
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try 
			{
				Salaries.Business.AdminTipuriRapoarte newTipRaport = new Salaries.Business.AdminTipuriRapoarte();
				newTipRaport.TipRaportId = 0;
				newTipRaport.Denumire  = txtDenumire.Text;
				newTipRaport.Descriere = txtDescriere.Text;
				
				if (newTipRaport.CheckIfTipRaportCanBeAdded())
				{
					newTipRaport.InsertTipRaport();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un tip de raport cu acest nume!'); </script>");
				}

				//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu tipuri rapoarte
				CreateRefreshFunction();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			ListareTipuriRapoarte();
		}
		#endregion

		#region btnModify_Click
		/// <summary>
		/// Modifica un tip de raport
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			try
			{
				int tipRaportId = Convert.ToInt32(txtTipRaportID.Text);
				Salaries.Business.AdminTipuriRapoarte objTipRaport = new Salaries.Business.AdminTipuriRapoarte();
				objTipRaport.TipRaportId = tipRaportId;	
				objTipRaport.Denumire  = txtDenumire.Text;
				objTipRaport.Descriere = txtDescriere.Text;
                
				if (objTipRaport.CheckIfTipRaportCanBeAdded())
				{
					objTipRaport.UpdateTipRaport();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un tip de raport cu acest nume!'); </script>");
				}

				//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu tipuri rapoarte
				CreateRefreshFunction();
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			ListareTipuriRapoarte();
		}
		#endregion

		#region btnDelete_Click
		/// <summary>
		/// Sterge un tip de raport
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				int tipRaportId = Convert.ToInt32(txtTipRaportID.Text);
				Salaries.Business.AdminTipuriRapoarte rapoarte = new Salaries.Business.AdminTipuriRapoarte();
				rapoarte.TipRaportId = tipRaportId;
				int sePoateSterge = rapoarte.CheckIfTipRaportCanBeDeleted();

				if (sePoateSterge == 1)
				{
					Response.Write("<script> alert('Tipul de raport nu poate fi sters! Este inca asociat unor angajati!'); </script>");
					FillEditForm();
				}
				if (sePoateSterge == 2)
				{
					Response.Write("<script> alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin un tip de raport psihologic.'); </script>");
					FillEditForm();
				}
				if (sePoateSterge == 0)
				{
					rapoarte.DeleteTipRaport();
					ListareTipuriRapoarte();
				}
				//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu tipuri rapoarte
				CreateRefreshFunction();

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
		/// Editeaza un tip de raport
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
		/// Completeaza campurile cu datele tipului de raport
		/// </summary>
		private void FillEditForm()
		{
			try 
			{
				int tipRaportId = Convert.ToInt32(txtTipRaportID.Text);
				Salaries.Business.AdminTipuriRapoarte infoTipRaport = new Salaries.Business.AdminTipuriRapoarte();
				infoTipRaport.TipRaportId = tipRaportId;
				DataRow rowTipRaport = infoTipRaport.GetTipRaportInfo().Tables[0].Rows[0];

				txtDenumire.Text = rowTipRaport["Denumire"].ToString();
				txtDescriere.Text = rowTipRaport["Descriere"].ToString();
				txtTipRaportID.Text = tipRaportId.ToString();

				td_addLine.Visible = false;
				td_editLine.Visible = true;
				add_form.Style.Add("display","");
				add_buttonLine.Visible = false;
				tdTitle.InnerText = "Editare tip raport";
				//lblMessage.Visible = false;

				//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu tipuri rapoarte
				//In acest caz va fi goala ... 
				CreateEmptyRefreshFunction();
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
		/// Revine la lista cu tipuri de rapoarte
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			ListareTipuriRapoarte();

			//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu tipuri rapoarte
			//In acest caz va fi goala ... 
			CreateEmptyRefreshFunction();
		}
		#endregion

		#region CreateRefreshFunction
		/// <summary>
		/// Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu tipuri rapoarte
		/// </summary>
		private void CreateRefreshFunction()
		{
			string outStr = "";
			
			//cream scriptul care va contine functia de refresh
			//ne bazam pe faptul ca se cunoaste numele selectului care contine tipurile de rapoarte
			//initial se sterg toate intrarile din combo
			outStr +=	"<script> \r\n function RefreshParentPage() \r\n" +
				"{ \r\n" +
				"window.opener.DeleteTipuriRapoarteCombo(); \r\n" +
				" FillTipuriRapoarteCOmbo(); \r\n" +
				"} \r\n";

			outStr +=	" function FillTipuriRapoarteCOmbo() \r\n" +
				"{ \r\n";
			//acum se creeaza functie care adauga categoriile din recordset
			//se foloseste o functie din parent page... FillTipRaportCombo
			Salaries.Business.AdminTipuriRapoarte objAdminTipuriRapoarte = new Salaries.Business.AdminTipuriRapoarte();	
			
			foreach ( DataRow dataRow in objAdminTipuriRapoarte.LoadInfoTipuriRapoarte().Tables[0].Rows)
			{
				outStr +=	"window.opener.FillTipRaportCombo('" +
					dataRow["Denumire"].ToString() + "'," +
					dataRow["TipRaportID"].ToString() + ");";
			}

						
			outStr +=	"} \r\n" +
				"</script>";

			Response.Write( outStr);
		}
		#endregion

		#region CreateEmptyRefreshFunction
		/// <summary>
		/// Creeaza o functie de refresh goala pt cazul in care se incearca editarea unui tip de raport
		/// </summary>
		private void CreateEmptyRefreshFunction()
		{
			string outStr = "";

			outStr += "<script>function RefreshParentPage() {}</script>";
			Response.Write( outStr);
		}
		#endregion
	}
}
