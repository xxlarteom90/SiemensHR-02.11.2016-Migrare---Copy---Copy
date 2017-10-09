/*
 * Autor:     Oprescu Claudia
 * Data:      21.09.2006
 * Descriere: Este generata Anexa2 pentru sanatate.
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
	/// Este generata declaratia pentru sanatate CM_DCL_A2.
	/// </summary>
	public class rapoarte_DeclaratieSanatateA2 : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Label labelError;
		protected ReportingServices.ReportViewer raportDeclaratieA2;
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

			try
			{
				this.raportDeclaratieA2.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);
				// Sunt setati parametrii raportului.
				// ID-ul angajatorului pentru care se genereaza declaratia pentru sanatate.
				this.raportDeclaratieA2.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
				// Id-ul lunii pentru care se genereaza declaratia pentru sanatate.
				this.raportDeclaratieA2.SetQueryParameter("LunaID",this.GetCurrentMonth().ToString());
				// Rectificativa.
				this.raportDeclaratieA2.SetQueryParameter("Rectificativa", "0");
			}
			catch ( Exception )
			{
				labelError.Text = "Pentru a putea genera raportul trebuie sa fie disponibile toate datele necesare!";
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

		#region btnAfiseaza_Click
		/// <summary>
		/// Afiseaza raportul
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAfiseaza_Click(object sender, System.EventArgs e)
		{}
		#endregion
	}
}
