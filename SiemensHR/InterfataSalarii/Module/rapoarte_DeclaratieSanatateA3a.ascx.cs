/*
 * Autor:     Cristina Raluca Muntean
 * Data:      18.04.2006
 * Descriere: Este generata declatatia pentru sanatate Anexa3a
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
	///	Este generata declatatia pentru sanatate Anexa3a.
	/// </summary>
	public class rapoarte_DeclaratieSanatateA3a : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Button btnAfiseaza;
		protected System.Web.UI.WebControls.Label labelError;
		protected ReportingServices.ReportViewer raportSanatate;
		protected System.Web.UI.WebControls.ValidationSummary sumarValidare;
		#endregion
		protected System.Web.UI.WebControls.DropDownList drpCaseDeAsig;


		
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
				DataSet dsCaseDeAsig = new DataSet(); 
				Salaries.Business.AdminAngajator angajator = new Salaries.Business.AdminAngajator();
				angajator.AngajatorId = this.GetAngajator();

				// Luna curenta.
				Salaries.Business.Luni luna = new Salaries.Business.Luni( this.GetAngajator() );
				Salaries.Data.LunaData lunaCurenta = luna.GetLunaActiva();
            
				if (!IsPostBack)
				{
					// Lista caselor de asigurari ale unui angajator.
					dsCaseDeAsig = angajator.GetCaseDeAsigurari();
					drpCaseDeAsig.DataSource = dsCaseDeAsig;
					drpCaseDeAsig.DataTextField = "Denumire";
					drpCaseDeAsig.DataValueField = "Denumire";
					drpCaseDeAsig.DataBind();
				}

				this.raportSanatate.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);
				// Sunt setati parametrii raportului.
				// ID-ul angajatorului pentru care se genereaza declaratia.
				this.raportSanatate.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
				// Id-ul lunii pentru care se genereaza declaratia.
				this.raportSanatate.SetQueryParameter("LunaID",this.GetCurrentMonth().ToString());
				// Punctul de lucru.
				this.raportSanatate.SetQueryParameter("DenumireCasaDeAsigurari",drpCaseDeAsig.SelectedItem.Value);
				this.raportSanatate.SetQueryParameter("ReprezentantLegalID", "-1");
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
			this.btnAfiseaza.Click += new System.EventHandler(this.btnAfiseaza_Click);
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
