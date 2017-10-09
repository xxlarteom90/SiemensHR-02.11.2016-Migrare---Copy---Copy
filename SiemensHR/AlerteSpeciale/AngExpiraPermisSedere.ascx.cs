using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR
{
	/// <summary>
	///		Summary description for AngExpiraPermisSedere.
	/// </summary>
	public class AngExpiraPermisSedere: System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Table tablePermisSederetHeader;
		protected System.Web.UI.WebControls.DataGrid listDataGrid3;
		protected System.Web.UI.WebControls.Table ResultTable;
		private int IndexP;
		protected Salaries.Configuration.ModuleSettings settings;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			Utilities.CreateTableHeader(tablePermisSederetHeader,"Angajatii carora le expira permisul de sedere in mai putin de 60 zile", "","normal");
			if (!IsPostBack)
			{												
				Salaries.Business.Angajat objAngajat = new Salaries.Business.Angajat();
				DataSet ds = objAngajat.GetAngajatiExpiraPermisSedere();

				Session["SortBy"] = "";
				IndexP =1;
				Session["DataSource_PermisSedere"]  = ds;

				listDataGrid3.DataSource = ds;
				listDataGrid3.DataBind();								
			}
		}
		#endregion

		#region CreateResultTable
		/// <summary>
		/// Procedura creaza tabelul cu rezultate
		/// </summary>
		/// <param name="tmpTable">Tabelul care va contine datele</param>
		/// <param name="text">Textul capului de tabel</param>
		/// <param name="relativePath">Calea relativa</param>
		/// <param name="type">Tipul</param>
		/// <returns>Returneaza tabelul creat</returns>
		protected Table CreateResultTable(Table tmpTable, string text, string relativePath, string type)
		{
			TableRow tmpRow =  new TableRow();
			
			tmpTable.CellPadding = 0;
			tmpTable.CellSpacing = 0;
			tmpTable.BorderWidth = new Unit("0");

			TableCell tmpCell = new TableCell();
			tmpCell = new TableCell();
			tmpCell.Text =text;
			tmpCell.CssClass = "tab1";
			tmpCell.Width = new Unit("100%");
			tmpCell.Attributes.Add("align", "center");
			tmpRow.Cells.Add(tmpCell);
	
			tmpTable.Rows.Add(tmpRow);
			return tmpTable;
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
			this.listDataGrid3.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGrid_ItemCreated);
			this.listDataGrid3.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.listDataGrid_PageIndexChanged);
			this.listDataGrid3.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.listDataGrid_SortCommand);
			this.listDataGrid3.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGrid_ItemDataBound);
			this.listDataGrid3.Load += new System.EventHandler(this.listDataGrid_Load);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		#region listDataGrid_ItemCreated
		/// <summary>
		/// Procedura creaza o inregistrare in tabel
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
					//string text = cellPager.Controls[i].GetType().ToString();
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
		/// Proceudra creaza o inregistrare in tabel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void listDataGrid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		
			if (e.Item.ItemIndex!=-1)  // daca e header nu pune evenimentele
			{
				TableCell myCell = new TableCell();
				myCell.Text = IndexP.ToString();
				myCell.Attributes.Add("align","center");
				e.Item.Cells.AddAt(0, myCell);
				for(int j=0; j<e.Item.Cells.Count; j++)
					e.Item.Cells[j].Attributes.Add("class","UnderlineNormalBlack");
				IndexP++;
				e.Item.Attributes.Add("onmouseover", "MouseOverTableLine(this)");
				e.Item.Attributes.Add("onmouseout", "MouseOutTableLine(this)");
				e.Item.Attributes.Add("onclick", "EditAngajatAlertaPermisSedere(this)");
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

		#region listDataGrid_SortCommand
		/// <summary>
		/// Procedura permite sortarea datelor pe coloane
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void listDataGrid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			// Retrieve the data source from session state.
			DataSet dt3 = (DataSet)Session["DataSource_PermisSedere"];

			// Create a DataView from the DataTable.
			DataView dv3 = dt3.Tables[0].DefaultView;

			// The DataView provides an easy way to sort. Simply set the
			// Sort property with the name of the field to sort by.
			dv3.Sort = e.SortExpression;
			Session["SortBy2"] = e.SortExpression;
			// RebIndexP the data source 
			listDataGrid3.DataSource = dv3;
			IndexP = (listDataGrid3.CurrentPageIndex * listDataGrid3.PageSize) + 1;
			listDataGrid3.DataBind();
		}
		#endregion

		#region RefreshTableContract
		/// <summary>
		/// Procedura actualizeaza datele in tabel
		/// </summary>
		private void RefreshTablePermisSedere()
		{
			DataSet dt3 = (DataSet)Session["DataSource_PermisSedere"];
			DataView dv3 = dt3.Tables[0].DefaultView;
			listDataGrid3.DataSource = dv3;
			IndexP = (listDataGrid3.CurrentPageIndex * listDataGrid3.PageSize) + 1;
			listDataGrid3.DataBind();

			//dovle
			if( dt3.Tables[ 0 ].Rows.Count == 0 )
			{
				listDataGrid3.Visible = false;
				CreateResultTable(ResultTable, "Nu exista nici un angajat caruia sa ii expire permisul de sedere", "", "normal");
			}
			else
			{
				listDataGrid3.Visible = true;
			}
		}
		#endregion

		#region listDataGrid_Load
		/// <summary>
		/// Proceudra incarca datele in tabel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listDataGrid_Load(object sender, System.EventArgs e)
		{
			RefreshTablePermisSedere();	
		}
		#endregion

		#region listDataGrid_PageIndexChanged
		/// <summary>
		/// Procedura afiseaza datele de pe pagina urmatoare a tabelului
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void listDataGrid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			listDataGrid3.CurrentPageIndex = e.NewPageIndex;
			RefreshTablePermisSedere();	
		}
		#endregion
	}
}