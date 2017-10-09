using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for MainSalarii.
	/// </summary>
	public class MainSalarii : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.HtmlControls.HtmlTableCell Container;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.HtmlControls.HtmlTableCell Tabs;
		/// <summary>Meniul din stanga al paginii</summary>
		protected AdminMeniu adminMeniu;
		#endregion
		
		#region Page_Load 
		private void Page_Load(object sender, System.EventArgs e)
		{
			string Tab = Request.Params["Tab"];
			if (Tab==null || Tab.Length==0) Tab="Administrare";

			// Modificat: Anca Holostencu
			// Descriere: Adaugat meniul din partea stanga a paginii
			TableCell celulaMeniu = new TableCell();
			celulaMeniu.Height = Unit.Point( 550 );
			celulaMeniu.Width = Unit.Point( 190 );
			celulaMeniu.BorderWidth = 0;
			celulaMeniu.HorizontalAlign = HorizontalAlign.Left;

			adminMeniu = ( AdminMeniu )LoadControl( Request.ApplicationPath + "/AdminMeniu.ascx" );
			adminMeniu.XmlSursa = "../Navigare/Salarii_Navigare.xml";
			celulaMeniu.Controls.Add( adminMeniu );

			Table continut = new Table();
			continut.Width = Unit.Percentage(95);
			continut.HorizontalAlign = HorizontalAlign.Center;
			
			TableCell celulaContinut = new TableCell();
			celulaContinut.VerticalAlign = VerticalAlign.Top;
			celulaContinut.Controls.Add( continut );

			TableRow randLiber = new TableRow();
			randLiber.Cells.Add( new TableCell() );
			randLiber.Height = Unit.Point( 20 );
			continut.Rows.Add( randLiber );
			
			TableRow continutPagina = new TableRow();
			continutPagina.Cells.Add( celulaMeniu );
			continutPagina.Cells.Add( celulaContinut );

			mainTable.Rows.Add( continutPagina );

			TableCell cell = new TableCell();
			cell.Width = Unit.Percentage(100);
			TableRow row = new TableRow();
			row.Cells.Add( cell );
			cell.Attributes.Add("align","center");
			continut.Rows.Add( row );

			switch (Tab)
			{
				case "Administrare":
					Salarii_Administrare SalariiAdmin = (Salarii_Administrare) LoadControl("Salarii_Administrare.ascx");
					cell.Controls.Add(SalariiAdmin);
				break;
				case "Pontaj":
					Salarii_Pontaj SalariiPontaj = (Salarii_Pontaj) LoadControl("Salarii_Pontaj.ascx");
					cell.Controls.Add(SalariiPontaj);
				break;
				case "Rapoarte":
					Salarii_Rapoarte SalariiRapoarte = (Salarii_Rapoarte) LoadControl("Salarii_Rapoarte.ascx");
					cell.Controls.Add(SalariiRapoarte);
				break;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Render
		protected override void Render(HtmlTextWriter writer)
		{			
			base.Render (writer);
			Response.Write( adminMeniu.ScriptNavigare );
		}
		#endregion
	}
}
