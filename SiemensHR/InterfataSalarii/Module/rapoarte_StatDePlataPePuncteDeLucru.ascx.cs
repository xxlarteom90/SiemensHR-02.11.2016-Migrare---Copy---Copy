using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	/// Permite generarea raportului ce cuprinde statul de plata pe puncte de lucru.
	/// </summary>
	/// <remarks>
	/// Autor: Cristina Raluca Muntean
	/// Data:  23.03.2007
	/// </remarks>
	public class rapoarte_StatDePlataPePuncteDeLucru : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected ReportingServices.ReportViewer rapStatPlataPuncteLucru;
		#endregion

		#region Constante
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

			this.rapStatPlataPuncteLucru.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);
			this.rapStatPlataPuncteLucru.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
			this.rapStatPlataPuncteLucru.SetQueryParameter("LunaID",this.GetCurrentMonth().ToString());
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
