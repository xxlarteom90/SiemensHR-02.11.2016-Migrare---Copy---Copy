/*
 * Autor:     Cristina Raluca Muntean
 * Data:      18.04.2006
 * Descriere: Este generata Anexa3c pentru sanatate.
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
	///	Este generata Anexa 3c pentru sanatate.
	/// </summary>
	public class rapoarte_DeclaratieSanatateA3c : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.TextBox txtSumaRestanta;
		protected System.Web.UI.WebControls.TextBox txtDataPlatii;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldData;
		protected System.Web.UI.WebControls.DropDownList drpReprezentantLegal;
		protected System.Web.UI.WebControls.Button btnAfiseaza;
		protected System.Web.UI.WebControls.ValidationSummary sumarValidare;
		protected System.Web.UI.WebControls.Label labelError;
		protected ReportingServices.ReportViewer raportSanatate;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredData;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RangeValidator vldSumaRestanta;
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
				DataSet dsAngajati = new DataSet(); 
				Salaries.Business.Angajat angajati = new Salaries.Business.Angajat();

				// Luna curenta.
				Salaries.Business.Luni luna = new Salaries.Business.Luni( this.GetAngajator() );
				Salaries.Data.LunaData lunaCurenta = luna.GetLunaActiva();
            
				if (!IsPostBack)
				{
					// Lista angajatilor firmei pentru care se genereaza declaratia pentru sanatate.
					angajati.AngajatorId = GetAngajator();
					dsAngajati = angajati.GetAllAngajatiDinLuna(this.GetCurrentMonth());
					drpReprezentantLegal.DataSource = dsAngajati;
					drpReprezentantLegal.DataTextField = "NumeIntreg";
					drpReprezentantLegal.DataValueField = "AngajatID";
					drpReprezentantLegal.DataBind();

					// Este setata data platii drepturilor salariale.
					txtDataPlatii.Text = lunaCurenta.Data.ToShortDateString();
				}

				this.raportSanatate.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);
				// Sunt setati parametrii raportului.
				// ID-ul angajatorului pentru care se genereaza declaratia.
				this.raportSanatate.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
				// Id-ul lunii pentru care se genereaza declaratia.
				this.raportSanatate.SetQueryParameter("LunaID",this.GetCurrentMonth().ToString());
				// ID-ul reprezentantului legal al firmei.
				this.raportSanatate.SetQueryParameter("ReprezentantLegalID",drpReprezentantLegal.SelectedItem.Value);
				// Suma restanta.
				this.raportSanatate.SetQueryParameter("Restanta",txtSumaRestanta.Text);
				// Data platii drepturilor salariale.
				this.raportSanatate.SetQueryParameter("DataPlataSalarii",txtDataPlatii.Text);
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
	}
}
