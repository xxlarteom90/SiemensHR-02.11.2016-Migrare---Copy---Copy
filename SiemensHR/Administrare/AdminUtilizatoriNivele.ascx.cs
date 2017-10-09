namespace SiemensHR.Administrare
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for AdminUtilizatoriNivele.
	/// </summary>
	public class AdminUtilizatoriNivele : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DataGrid listDataGrid;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Literal litError;
		private int Index;
		private int angajatorId;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			//Utilities.CreateTableHeader(headerTable, "Date utilizator", "../", "small");	

			angajatorId = int.Parse(Session["AngajatorID"].ToString());

			CompletareTitlu();
			PopulareTabela();
		}

		#region CompletareTitlu
		//Autor: Lungu Andreea
		//Data:  31.10.2007
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
			myCell.Text = "Lista utilizatorilor existenti";
			myCell.Height = new Unit(50);
			myRow.Cells.Add(myCell);
			mainTable.Rows.Add(myRow);
		
			listDataGrid.Visible = true;
		}
		#endregion

		#region PopulareTabela
		//Autor: Lungu Andreea
		//Data:  31.10.2007
		/// <summary>
		/// Populeaza lista cu tari
		/// </summary>
		public void PopulareTabela()
		{
			Index = listDataGrid.CurrentPageIndex * 30 + 1;
			Salaries.Business.AdminUtilizatori objAdminUtilizatori = new Salaries.Business.AdminUtilizatori();	
			listDataGrid.DataSource = objAdminUtilizatori.LoadInfoUtilizatori(angajatorId);
			listDataGrid.DataBind();
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
			this.listDataGrid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGrid_ItemCreated);
			this.listDataGrid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGrid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region listDataGrid_ItemCreated
		//Autor: Lungu Andreea
		//Data:  31.10.2007
		/// <summary>
		/// Se creaza o inregistrare in lista.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listDataGrid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
		//Autor: Lungu Andreea
		//Data:  31.10.2007
		/// <summary>
		/// creaza o inregistrare in lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listDataGrid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
				e.Item.Attributes.Add("onclick", "EditUtilizator(" + e.Item.Cells[1].Text  + ")" );

				e.Item.Cells[1].Style.Add("display", "none");
			}
			else
			{
				TableCell myCellHeader = new TableCell();
				myCellHeader.Text = "Nr. crt";
				e.Item.Cells.AddAt(0, myCellHeader);
				for (int i=1; i<e.Item.Cells.Count ; i++)
				{
					// ascund prima coloana.. care este id utilizator
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
			//e.Item.Cells[e.Item.Cells.Count-2].Visible = false;
			//e.Item.Cells[e.Item.Cells.Count-1].Visible = false;
		}
		#endregion

		#region listDataGrid_PageIndexChanged
		//Autor: Lungu Andreea
		//Data:  31.10.2007
		/// <summary>
		/// Se trece la o alta pagina.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void listDataGrid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			Salaries.Business.AdminUtilizatori utilizator = new Salaries.Business.AdminUtilizatori();
			DataSet dt = utilizator.LoadInfoUtilizatori(angajatorId);
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
