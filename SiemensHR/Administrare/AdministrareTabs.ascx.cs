using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensHR.Classes;

namespace SiemensHR.Administrare
{
	/// <summary>
	///		Summary description for AdministrareTabs.
	/// </summary>
	public class AdministrareTabs : System.Web.UI.UserControl
	{
		public string selectedTab;
		protected System.Web.UI.WebControls.Table tabsTable;
		
		//Modified: Ionel Popa
		//Description: am scos tabul "Categorii"

		// Modificat: Anca Holostencu
		// Descriere: Adaugat tab-ul "Case de asigurari"; organizat codul
		private string[] Tabs_text = {							// tab index:
										// Altele
										"Banci",					// 0
										"Case de asigurari",		// 1
										"Judete",					// 2
										"Tipuri rapoarte",			// 3
										"Tari",						// 4

										 // Angajator
										"Angajatori",				// 5
										"Centre cost",				// 6
										"Completare carnete munca",	// 7
										"Departamente",				// 8	
										"Domenii de activitate",	// 9
										 
										 // Angajati
										"Cursuri",					// 10
										"Functii",					// 11
										"Invaliditati",				// 12
										"Studii",					// 13
										"Titluri",					// 14

										 // Salarii
										"Variabile salarizare"		// 15	
									 };

		public string[] Tabs_cmd = {
										"admin_banci",
										"admin_case_de_asigurari",
										"admin_judete",
										"admin_tip_rapoarte",
										"admin_tari",

										"admin_angajatori",
										"admin_centrecost",
										"admin_completare_carnete",
										"admin_departamente",
										"admin_domenii_de_activitate",
										
										"admin_traininguri",
										"admin_functii",
										"admin_invaliditati",
										"admin_studii",
										"admin_titutalturi",
										
										"admin_variabile_salarizare"
								  };

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			TabsTable tabsTable_obj = new TabsTable(tabsTable, Request.QueryString["Cmd"],Tabs_cmd, Tabs_text) ;
			Response.Write(tabsTable_obj.BuildClientArrayCmd());
			tabsTable = tabsTable_obj.BuildTabsTable();
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
