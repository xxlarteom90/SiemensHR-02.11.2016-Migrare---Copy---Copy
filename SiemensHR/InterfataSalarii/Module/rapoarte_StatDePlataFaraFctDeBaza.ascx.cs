using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Permite generarea raportului ce cuprinde statul de plata pentru angajatii 
	///		fara functia de baza la angajatorul curent.
	/// </summary>
	public class rapoarte_StatDePlataFaraFctDeBaza : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected ReportingServices.ReportViewer rapStatPlata;
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

			this.rapStatPlata.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);
			this.rapStatPlata.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
			this.rapStatPlata.SetQueryParameter("LunaID",this.GetCurrentMonth().ToString());
			this.rapStatPlata.SetQueryParameter("ModIncadrare","1");
			this.rapStatPlata.SetQueryParameter("Locul","CU FUNCTIA DE BAZA LA ALTA UNITATE");
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
