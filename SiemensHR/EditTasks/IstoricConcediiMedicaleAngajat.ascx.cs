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
	///		Summary description for IstoricConcediiMedicaleAngajat.
	/// </summary>
	public class IstoricConcediiMedicaleAngajat : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;

		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			LoadFormIstoricCM();

			string[] textTabs = { "Istoric concedii medicale" };
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", false);
		}
		#endregion

		#region LoadFormIstoricCM
		/// <summary>
		/// Listeaza concediile medicale
		/// </summary>
		private void LoadFormIstoricCM()
		{
			try
			{
				listTable.Rows.Clear();
				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");
			
				Salaries.Business.IstoricConcediuMedicalAngajat istCMA = new Salaries.Business.IstoricConcediuMedicalAngajat();
				istCMA.AngajatId = AngajatID;

				string[] arHeader = { "Data de inceput", "Data de sfarsit", "Observatii" };
				string[] arCols = { "DataStart", "DataEnd", "Observatii" };
				ListTable objListTable = new ListTable(listTable, istCMA.LoadIstoricCM(), arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista nici un concediu medical pt acest angajat!";
				objListTable.DrawListTableWithoutDigits();
			}
			catch(Exception ex)
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
