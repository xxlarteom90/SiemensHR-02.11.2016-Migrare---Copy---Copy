/*
 * Autor:     Cristina Raluca Muntean
 * Data:      31.07.2006
 * Descriere: Este generat raportul aferent tichetelor de masa.
 */

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Permite generarea raportului ce cuprinde lista cu tichetele de masa aferente angajatilor.
	/// </summary>
	public class rapoarte_TicheteDeMasa : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected ReportingServices.ReportViewer raportTicheteDeMasa;
		#endregion

		#region Constrante
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

			this.raportTicheteDeMasa.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);
			// Sunt setati parametrii raportului.
			// ID-ul angajatorului pentru care se genereaza declaratia.
			this.raportTicheteDeMasa.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
			// Id-ul lunii pentru care se genereaza declaratia.
			this.raportTicheteDeMasa.SetQueryParameter("LunaID",this.GetCurrentMonth().ToString());
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
