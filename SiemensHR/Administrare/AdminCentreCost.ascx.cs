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
	///		Summary description for AdminCentreCost.
	/// </summary>
	public class AdminCentreCost : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.TextBox txtDenumire;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.TextBox txtCod;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCod;
		protected System.Web.UI.WebControls.TextBox txtDescriere;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_editLine;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCod;
		protected System.Web.UI.WebControls.Button btnEditCentruCost;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_buttonLine;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_addLine;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_form;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTitle;
		protected System.Web.UI.WebControls.TextBox txtCentruCostID;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.DataGrid listDataGrid;
		private int Index;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			litError.Text = "";
			lblMessage.Text = "";

			btnDelete.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti acest centru de cost?')");

			Utilities.CreateTableHeader(headerTable, "Date identificare centru de cost", "../", "small");
			
			Response.Write("<script>var requiredCod = \"" + requiredCod.ClientID + "\"</script>");
			Response.Write("<script>var regularCod = \"" + regularCod.ClientID + "\"</script>");
			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularDenumire = \"" + regularDenumire.ClientID + "\"</script>");
			Response.Write("<script>var lblMessage = \"" + lblMessage.ClientID + "\"</script>");

			txtCentruCostID.Style.Add("display" ,"none");
			if(!IsPostBack)
			{
				//ListareCentreCost();
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
			myCell.Text = "Lista centrelor de cost existente";
			myCell.Height = new Unit(50);
			myRow.Cells.Add(myCell);
			mainTable.Rows.Add(myRow);
				
			td_editLine.Visible = false;
			add_form.Style.Add("display","none");
			btnEditCentruCost.Style.Add("display", "none");
			td_addLine.Visible = true;
			add_buttonLine.Visible = true;
			tdTitle.InnerText = "Adaugare centru de cost";

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
			Salaries.Business.AdminCentreCost objAdminCentreCost = new Salaries.Business.AdminCentreCost();
			listDataGrid.DataSource = objAdminCentreCost.LoadInfoCentreCost();
			listDataGrid.DataBind();
		}
		#endregion

		#region ListareCentreCost - COMENTATA
		/*public void ListareCentreCost()
		{
			try
			{
				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();		

				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista centrelor de cost existente";
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

				string[] tableHeader = {"Cod", "Denumire", "Descriere"};
				string[] tableCols = {"Cod", "Nume", "Descriere"};

				Salaries.Business.AdminCentreCost objAdminCentreCost = new Salaries.Business.AdminCentreCost();
				ListTable objListTable = new ListTable(listTable, objAdminCentreCost.LoadInfoCentreCost(), tableHeader, tableCols);

				string[] ar_OnClickParam = {"CentruCostID"};
				string[] ar_OnClickParamType = {"dataset"};

				objListTable.OnclickJSMethod = "SelectCentruCost";
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.DrawListTableWithoutDigits();                				

				myCell.Controls.Add(listTable);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				td_editLine.Visible = false;
				add_form.Style.Add("display","none");
				btnEditCentruCost.Style.Add("display", "none");
				td_addLine.Visible = true;
				add_buttonLine.Visible = true;
				tdTitle.InnerText = "Adaugare centru de cost";
	
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
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnEditCentruCost.Click += new System.EventHandler(this.btnEditCentruCost_Click);
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.btnInapoi.Click += new System.EventHandler(this.btnInapoi_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdd_Click
		/// <summary>
		/// Adauga un centru de cost
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			try 
			{
				Salaries.Business.AdminCentreCost newCentruCost = new Salaries.Business.AdminCentreCost();
				newCentruCost.CentruCostId = 0;
				newCentruCost.Nume  = txtDenumire.Text;
				newCentruCost.Cod = txtCod.Text;
				newCentruCost.Descriere = txtDescriere.Text;
				
				if (newCentruCost.CheckIfCentruCostCanBeAdded())
				{
					newCentruCost.InsertCentruCost();
					
					//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu centre de cost
					CreateRefreshFunction();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un centru de cost cu acest cod!'); </script>");
				}				
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			//ListareCentreCost();
			CompletareTitlu();
			PopulareTabela();
		}
		#endregion

		#region btnEditCentruCost_Click
		/// <summary>
		/// Se incarca datele unui centru de cost
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEditCentruCost_Click(object sender, System.EventArgs e)
		{
			FillEditForm();
		}
		#endregion

		#region FillEditForm
		/// <summary>
		/// Se incarca datele unui centru de cost
		/// </summary>
		private void FillEditForm()
		{
			try 
			{
				int centruCostId = Convert.ToInt32(txtCentruCostID.Text);				
				Salaries.Business.AdminCentreCost infoCentruCost = new Salaries.Business.AdminCentreCost();
				infoCentruCost.CentruCostId = centruCostId;
				DataRow rowCentruCost = infoCentruCost.GetCentruCostInfo().Tables[0].Rows[0];

				txtCod.Text = rowCentruCost["Cod"].ToString();
				txtDenumire.Text = rowCentruCost["Nume"].ToString();
				txtDescriere.Text = rowCentruCost["Descriere"].ToString();
				txtCentruCostID.Text = centruCostId.ToString();

				td_addLine.Visible = false;
				listDataGrid.Visible = false;
				td_editLine.Visible = true;
				add_form.Style.Add("display","");
				add_buttonLine.Visible = false;
				tdTitle.InnerText = "Editare centru de cost";
			
				//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu centre de cost
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
		/// Revine la lista cu centre de cost
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			//ListareCentreCost();
			CompletareTitlu();
			PopulareTabela();

			//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu centre de cost
			//In acest caz va fi goala ... 
			CreateEmptyRefreshFunction();
		}
		#endregion

		#region btnModify_Click
		/// <summary>
		/// Modifica datele unui centru de cost
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModify_Click(object sender, System.EventArgs e)
		{	
			try
			{
				int centruCostId = Convert.ToInt32(txtCentruCostID.Text);
				Salaries.Business.AdminCentreCost objCentruCost = new Salaries.Business.AdminCentreCost();

				objCentruCost.CentruCostId = centruCostId;
				objCentruCost.Nume  = txtDenumire.Text;
				objCentruCost.Cod = txtCod.Text;
				objCentruCost.Descriere = txtDescriere.Text;
                
				if (objCentruCost.CheckIfCentruCostCanBeAdded())
				{
					objCentruCost.UpdateCentruCost();
					
					//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu centre de cost
					CreateRefreshFunction();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un centru de cost cu acest cod!'); </script>");
				}
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			//ListareCentreCost();
			CompletareTitlu();
			PopulareTabela();
		}
		#endregion

		#region btnDelete_Click
		/// <summary>
		/// Sterge un centru de cost
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			try
			{
				int centruCostId = Convert.ToInt32(txtCentruCostID.Text);
				Salaries.Business.AdminCentreCost centruCost = new Salaries.Business.AdminCentreCost();
				centruCost.CentruCostId = centruCostId;

				int sePoateSterge = centruCost.CheckIfCentruCostCanBeDeleted();
				if (sePoateSterge == 0)
				{
					centruCost.DeleteCentruCost();
					//ListareCentreCost();
					CompletareTitlu();
					PopulareTabela();
				}
				if (sePoateSterge == 1)
				{
					Response.Write("<script> alert('Centrul de cost nu poate fi sters! Este inca asociat unor angajati!'); </script>");
				}
				if (sePoateSterge == 2)
				{
					Response.Write("<script> alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin un centru de cost.'); </script>");
				}

				//Daca pagina de administrare a fost deschisa din alta pagina cream functia care va face refresh la combo-ul cu centre de cost
				CreateRefreshFunction();

			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}	
		}
		#endregion

		#region CreateRefreshFunction
		/// <summary>
		/// Daca pagina de administrare a fost deschisa din IstoricCentreCost cream functia care va face refresh la combo-ul cu centre de cost
		/// </summary>
		private void CreateRefreshFunction()
		{
			string outStr = "";
			
			//cream scriptul care va contine functia de refresh
			//ne bazam pe faptul ca se cunoaste numele selectului care contine centrele de cost
			//initial se sterg toate intrarile din combo
			outStr +=	"<script> \r\n function RefreshParentPage() \r\n" +
				"{ \r\n" +
				"window.opener.DeleteCentreCostCombo(); \r\n" +
				" FillCentreCostCOmbo(); \r\n" +
				"} \r\n";

			outStr +=	" function FillCentreCostCOmbo() \r\n" +
				"{ \r\n";
			//acum se creeaza functie care adauga centrele de cost din recordset
			//se foloseste o functie din parent page... FillCentruCostCombo
			Salaries.Business.AdminCentreCost objAdminCentreCost = new Salaries.Business.AdminCentreCost();	
			
			foreach ( DataRow dataRow in objAdminCentreCost.LoadInfoCentreCost().Tables[0].Rows)
			{
				outStr +=	"window.opener.FillCentruCostCombo('" +
					dataRow["Cod"].ToString() + " - " + dataRow["Nume"].ToString() + "'," +
					dataRow["CentruCostID"].ToString() + ");";
			}

						
			outStr +=	"} \r\n" +
				"</script>";

			Response.Write( outStr);
		}
		#endregion

		#region CreateEmptyRefreshFunction
		/// <summary>
		/// Refresh combo cu centre de cost. Combo-ul va fi gol.
		/// </summary>
		private void CreateEmptyRefreshFunction()
		{
			string outStr = "";

			outStr += "<script>function RefreshParentPage() {}</script>";
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
				e.Item.Attributes.Add("onclick", "SelectCentruCost(" + e.Item.Cells[1].Text + ")");

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
			Salaries.Business.AdminCentreCost objAdminCentreCost = new Salaries.Business.AdminCentreCost();
			DataSet dt = objAdminCentreCost.LoadInfoCentreCost();
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
