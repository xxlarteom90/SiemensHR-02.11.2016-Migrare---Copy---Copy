
/*
 * Creat:		Lungu Andreea
 * Data:		06.04.2008
 * Descriere:	Este generat raportul contracte_itm
 * 
 */

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	/// Este generat raportul contracte itm pentru inspectoratul teritorial de munca.
	/// </summary>
	public class rapoarte_ContracteItm : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		
		#region Variabile

		protected ReportingServices.ReportViewer raportContracteItm;
		// Numele cheii din web.config care contine calea catre serverul cu rapoartele.
		private const string STRING_URL = "rapoarteServerUrl";
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			
			this.raportContracteItm.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);
			// Sunt setati parametrii raportului.
			// Id-ul lunii pentru care se genereaza raportul.
			this.raportContracteItm.SetQueryParameter("LunaID",this.GetCurrentMonth().ToString());
			// ID-ul angajatorului pentru care se genereaza raportul.
			this.raportContracteItm.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
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
