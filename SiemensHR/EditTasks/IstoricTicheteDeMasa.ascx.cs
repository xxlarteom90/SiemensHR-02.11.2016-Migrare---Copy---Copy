using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.EditTasks
{
	/// <summary>
	///		Summary description for IstoricTicheteDeMasa.
	/// </summary>
	public class IstoricTicheteDeMasa : System.Web.UI.UserControl
	{
		#region Variabile

		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.DataGrid listDataGrid;
		protected System.Web.UI.WebControls.Table mainTable;

		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!IsPostBack)
			{
				CompletareTitlu();
				PopulareGrid();
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
			myCell.Text = "Lista tichetelor de masa pe luni";
			myCell.Height = new Unit(50);
			myRow.Cells.Add(myCell);
			mainTable.Rows.Add(myRow);
		}
		#endregion

		#region PopulareGrid
		/// <summary>
		/// Populeaza lista cu tichete
		/// </summary>
		public void PopulareGrid()
		{
			Salaries.Business.SituatieLunaraAngajat ist = new Salaries.Business.SituatieLunaraAngajat(AngajatID);
			listDataGrid.DataSource = ist.GetAllSituatiiLunareAngajatDataSet();
			listDataGrid.DataBind();
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
			Salaries.Business.SituatieLunaraAngajat ist = new Salaries.Business.SituatieLunaraAngajat(AngajatID);
			DataSet dt = ist.GetAllSituatiiLunareAngajatDataSet();
			CompletareTitlu();

			listDataGrid.CurrentPageIndex = e.NewPageIndex;
			DataView dv = dt.Tables[0].DefaultView;

			listDataGrid.DataSource = dv;
			listDataGrid.DataBind();
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
				for(int j=0; j<e.Item.Cells.Count; j++)
					e.Item.Cells[j].Attributes.Add("class","UnderlineNormalBlack");
				e.Item.Attributes.Add("onmouseover", "MouseOverTableLine(this)");
				e.Item.Attributes.Add("onmouseout", "MouseOutTableLine(this)");
			}
			else
			{
				for (int i=0; i<e.Item.Cells.Count ; i++)
				{
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
