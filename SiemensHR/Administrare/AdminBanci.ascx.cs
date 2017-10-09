using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensHR.Classes;
using SiemensHR.utils;

namespace SiemensHR.Administrare
{
	/// <summary>
	///		Summary description for AdminBanci.
	/// </summary>
	public class AdminBanci : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		private string[] tableHeader = {"Cod", "Denumire", "Filiala"};
		protected System.Web.UI.WebControls.Table mainTable;
		private string[] tableCols = {"CodBanca", "Nume", "Filiala"};
		protected System.Web.UI.WebControls.TextBox txtCodBanca;
		protected System.Web.UI.WebControls.TextBox txtDenumireBanca;
		protected System.Web.UI.WebControls.TextBox txtFilialaBanca;
		protected System.Web.UI.WebControls.Button btnAddBanca;
		protected System.Web.UI.WebControls.Button btnModifyBanca;
		protected System.Web.UI.WebControls.Button btnDeleteBanca;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCod;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredFiliala;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.ValidationSummary vldSummary;
		protected System.Web.UI.WebControls.RegularExpressionValidator regExprVldDenumire;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCod;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularFiliala;
		protected System.Web.UI.WebControls.DataGrid listDataGrid;
		public string localCmd;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTitle;
		private int Index;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			Response.Write("<script>var requiredDenumireClientID = \""+requiredDenumire.ClientID+"\"</script>");
			Response.Write("<script>var requiredCodClientID = \""+requiredCod.ClientID+"\"</script>");
			Response.Write("<script>var requiredFilialaClientID = \""+requiredFiliala.ClientID+"\"</script>");
			Response.Write("<script>var regExprVldDenumireClientID = \""+regExprVldDenumire.ClientID+"\"</script>");
			Response.Write("<script>var regularCodClientID = \""+ regularCod.ClientID+"\"</script>");
			Response.Write("<script>var regularFilialaClientID = \""+regularFiliala.ClientID+"\"</script>");
			litError.Text = "";

			Salaries.Business.AdminBanci banci = new Salaries.Business.AdminBanci();
			Response.Write("<script>" + banci.GetJSArrays() + "</script>");

			btnDeleteBanca.Attributes.Add("onclick", "return CheckDeleteBanca('Doriti sa stergeti aceasta banca?')");
			Utilities.CreateTableHeader(headerTable, "Date identificare banca", "../", "small");	
			if (!IsPostBack)
			{
				//ListareBanci();
				CompletareTitlu();
				PopulareTabela();
			}
		}

		#endregion

		#region CompletareTitlu
		/// <summary>
		/// Completeaza titlul listei cu tari
		/// </summary>
		public void CompletareTitlu()
		{
			TableRow myRow = new TableRow();
			TableCell myCell = new TableCell();

			//titlul de la listare
			myCell.CssClass = "BigBlueBold";
			myCell.HorizontalAlign = HorizontalAlign.Center;
			myCell.VerticalAlign = VerticalAlign.Middle;
			myCell.Text = "Lista bancilor existente";
			myCell.Height = new Unit(50);
			myRow.Cells.Add(myCell);
			mainTable.Rows.Add(myRow);
		
			listDataGrid.Visible = true;
		}
		#endregion

		#region PopulareTabela
		/// <summary>
		/// Populeaza lista cu tari
		/// </summary>
		public void PopulareTabela()
		{
			Index = listDataGrid.CurrentPageIndex * 30 + 1;
			Salaries.Business.AdminBanci objAdminBanci = new Salaries.Business.AdminBanci();	
			listDataGrid.DataSource = objAdminBanci.LoadInfoBanci();
			listDataGrid.DataBind();
		}
		#endregion

		#region ListareBanci - COMENTATA
		/*/// <summary>
		/// Procedura listeaza bancile
		/// </summary>
		public void ListareBanci()
		{
			try
			{
				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();
				
				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista bancilor existente";
				myCell.Height = new Unit(50);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				// lista de banci existente
				myRow = new TableRow();
				myCell = new TableCell();
				myCell.Attributes.Add("width", "100%");
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Top;
				Table listBanciTable = new Table();

				Salaries.Business.AdminBanci objAdminBanci = new Salaries.Business.AdminBanci();	
				ListTable objListTable = new ListTable(listBanciTable, objAdminBanci.LoadInfoBanci(), tableHeader, tableCols);

				string[] ar_OnClickParam = {"BancaID", "CodBanca", "Nume", "Filiala"};
				string[] ar_OnClickParamType = {"dataset", "dataset", "dataset", "dataset"};

				objListTable.OnclickJSMethod = "SelectBanca";
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.DrawListTableWithoutDigits();                				

				myCell.Controls.Add(listBanciTable);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}*/

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
			this.listDataGrid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGrid_ItemCreated);
			this.listDataGrid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.listDataGrid_PageIndexChanged);
			this.listDataGrid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGrid_ItemDataBound);
			this.btnAddBanca.Click += new System.EventHandler(this.btnAddBanca_Click);
			this.btnModifyBanca.Click += new System.EventHandler(this.btnModifyBanca_Click);
			this.btnDeleteBanca.Click += new System.EventHandler(this.btnDeleteBanca_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAddBanca_Click
		/// <summary>
		/// Adauga o banca
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddBanca_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.AdminBanci banca = new Salaries.Business.AdminBanci();
				banca.BancaId = -1;
				banca.Cod = txtCodBanca.Text;
				banca.Nume = txtDenumireBanca.Text;
				banca.Filiala = txtFilialaBanca.Text;

				if(!banca.VerificaExistentaBanca())
				{
					banca.InsertBanca();
					
					// Daca pagina de administrare a fost deschisa din AddAngajat cream functia care va 
					// face refresh la combo-ul cu banci
					CreateRefreshFunction();
				}
				else
				{
					Response.Write("<script>alert('Exista in baza de date o banca ce are aceleasi caracteristici cu cea pe care doriti sa o introduceti!');</script>");
				}
				//ListareBanci();
				CompletareTitlu();
				PopulareTabela();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnDeleteBanca_Click
		/// <summary>
		/// Sterge o banca
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDeleteBanca_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.AdminBanci banca = new Salaries.Business.AdminBanci();
				banca.BancaId = Convert.ToInt32(Request.Form["txtBancaID"]);
				int sePoateSterge = banca.VerificaStergereBanca();
				
				if (sePoateSterge == 0)
				{
					banca.DeleteBanca();
				
					// Daca pagina de administrare a fost deschisa din AddAngajat cream functia 
					// care va face refresh la combo-ul cu banci
					CreateRefreshFunction();
				}
				if (sePoateSterge == 1)
				{
					Response.Write("<script>alert('Banca nu poate fi stearsa deoarece exista conturi asociate acesteia!');</script>");
				}
				if (sePoateSterge == 2)
				{
					Response.Write("<script>alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin o banca.');</script>");
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			//ListareBanci();
			CompletareTitlu();
			PopulareTabela();
		}
		#endregion

		#region btnModifyBanca_Click
		/// <summary>
		/// Modifica o banca
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModifyBanca_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.AdminBanci banca = new Salaries.Business.AdminBanci();
				banca.BancaId = Convert.ToInt32(Request.Form["txtBancaID"]);
				banca.Cod = txtCodBanca.Text;
				banca.Nume = txtDenumireBanca.Text;
				banca.Filiala = txtFilialaBanca.Text;

				if(!banca.VerificaExistentaBanca())
				{
					banca.UpdateBanca();

					// Daca pagina de administrare a fost deschisa din AddAngajat cream functia care 
					// va face refresh la combo-ul cu banci
					CreateRefreshFunction();
				}
				else
				{
					Response.Write("<script>alert('Exista in baza de date o banca ce are aceleasi caracteristici cu cea pe care doriti sa o introduceti!');</script>");
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			//ListareBanci();
			CompletareTitlu();
			PopulareTabela();
		}
		#endregion

		#region CreateRefreshFunction
		/// <summary>
		/// Daca pagina de administrare a fost deschisa din ConturiBanci cream functia care va face refresh la combo-ul cu banci
		/// </summary>
		private void CreateRefreshFunction()
		{
			string outStr = "";
			
			//cream scriptul care va contine functia de refresh
			//ne bazam pe faptul ca se cunoaste numele selectului care contine bancile
			//initial se sterg toate intrarile din combo
			outStr +=	"<script> \r\n function RefreshParentPage() \r\n" +
				"{ \r\n" +
				"window.opener.DeleteBanciCombo(); \r\n" +
				" FillBanciCOmbo(); \r\n" +
				"} \r\n";

			//acum se creeaza functie care adauga functiile din recordset
			//se foloseste o functie din Conturi_Banca ... FillBancaCombo
			Salaries.Business.AdminBanci objAdminBanci = new Salaries.Business.AdminBanci();	
							
			outStr +=	" function FillBanciCOmbo() \r\n" +
				"{ \r\n";
			foreach ( DataRow dataRow in objAdminBanci.LoadInfoBanci().Tables[0].Rows)
			{
				outStr +=	"window.opener.FillBancaCombo('" +
					dataRow["Nume"].ToString() + "'," +
					dataRow["BancaID"].ToString() + ");";
			}
			
			outStr +=	"} \r\n" +
				"</script>";

			Response.Write( outStr);
		}
		#endregion

		#region listDataGrid_ItemCreated
		/// <summary>
		/// Se creaza o inregistrare in lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void listDataGrid_ItemCreated(Object sender, DataGridItemEventArgs e)
		{
			string szLnk = "System.Web.UI.WebControls.DataGridLinkButton";
			string szLbl = "System.Web.UI.WebControls.Label";

			if (e.Item.ItemType == ListItemType.Pager)
			{
				TableCell cellPager = (TableCell) e.Item.Controls[0];
				cellPager.CssClass = "PagingBackStyle";
				for(int i=0; i<cellPager.Controls.Count; i++)
				{
					if ( cellPager.Controls[i].GetType().ToString() == szLnk)
					{
						LinkButton ctrl = (LinkButton) cellPager.Controls[i];
						ctrl.CssClass = "PagingStyle";
						ctrl.Attributes.Add("onmouseover","MouseOverPageNumber(this)");
						ctrl.Attributes.Add("onmouseout","MouseOutPageNumber(this)");
					}
					if (cellPager.Controls[i].GetType().ToString()== szLbl)
					{
						WebControl webCtrl = (WebControl) cellPager.Controls[i];
						webCtrl.CssClass = "SelectPageNumberStyle";
					}
				}
			}		
		}
		#endregion

		#region listDataGrid_ItemDataBound
		/// <summary>
		/// Creaza o inregistrare in lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void listDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemIndex!=-1)  // daca e header nu pune evenimentele
			{
				TableCell myCell = new TableCell();
				myCell.Text = Index.ToString();
				myCell.Attributes.Add("align","center");
				e.Item.Cells.AddAt(0, myCell);
				for(int j=0; j<e.Item.Cells.Count; j++)
					e.Item.Cells[j].Attributes.Add("class","UnderlineNormalBlack");
				Index++;
				e.Item.Attributes.Add("onmouseover", "MouseOverTableLine(this)");
				e.Item.Attributes.Add("onmouseout", "MouseOutTableLine(this)");
				e.Item.Attributes.Add("onclick", "SelectBanca(" + e.Item.Cells[1].Text  + ",'" + e.Item.Cells[2].Text + "','" + e.Item.Cells[3].Text + "','" + e.Item.Cells[4].Text + "')");

				e.Item.Cells[1].Style.Add("display", "none");
			}
			else
			{
				TableCell myCellHeader = new TableCell();
				myCellHeader.Text = "Nr. crt";
				e.Item.Cells.AddAt(0, myCellHeader);
				for (int i=1; i<e.Item.Cells.Count ; i++)
				{
					// ascund prima coloana.. care este id angajat
					if (i==1)
						e.Item.Cells[i].Style.Add("display", "none");
					if(e.Item.Cells[i].Controls.Count>0)
					{
						// setez clasa de CSS ptr. header de table + evenimente client
						LinkButton linkbtn = (LinkButton) e.Item.Cells[i].Controls[0];
						linkbtn.CssClass = "SortStyle";
						linkbtn.Attributes.Add("onmouseover","MouseOverSortHeader(this)");
						linkbtn.Attributes.Add("onmouseout","MouseOutSortHeader(this)");
					}
				}
			}
		}
		#endregion

		#region listDataGrid_PageIndexChanged
		/// <summary>
		/// Se trece la urmatoarea pagina in lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void listDataGrid_PageIndexChanged(Object sender, DataGridPageChangedEventArgs	e)
		{
			Salaries.Business.AdminBanci banci = new Salaries.Business.AdminBanci();
			DataSet dt = banci.LoadInfoBanci();
			CompletareTitlu();

			listDataGrid.CurrentPageIndex = e.NewPageIndex;
			DataView dv = dt.Tables[0].DefaultView;

			listDataGrid.DataSource = dv;
			Index = (e.NewPageIndex * listDataGrid.PageSize) + 1;
			listDataGrid.DataBind();
		}
		#endregion
	}
}
