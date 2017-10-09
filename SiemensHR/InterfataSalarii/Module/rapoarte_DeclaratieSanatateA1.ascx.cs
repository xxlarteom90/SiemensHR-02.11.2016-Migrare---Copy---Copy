/*
 * Autor:     Cristina Raluca Muntean
 * Data:      17.04.2006
 * Descriere: Este generata Anexa3a pentru sanatate.
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
	/// Este generata declaratia pentru sanatate CM_DCL_A1.
	/// </summary>
	public class rapoarte_DeclaratieSanatateA1 : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.DropDownList drpContAngajator;
		protected System.Web.UI.WebControls.Label labelError;
		protected System.Web.UI.WebControls.Button btnAfiseaza;
		protected System.Web.UI.WebControls.ValidationSummary sumarValidare;
		protected ReportingServices.ReportViewer raportDeclaratieA1;
		protected System.Web.UI.WebControls.RangeValidator vldNrFileAnexa2;
		protected System.Web.UI.WebControls.TextBox txtDataPlatii;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldData;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredData;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.TextBox txtNrFleAnexa2;
		#endregion

		#region Constrante
		// Numele cheii din web.config care contine calea catre serverul cu rapoartele.
		private const string STRING_URL = "rapoarteServerUrl";
		#endregion
		
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
		}
		#endregion
        
		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			try
			{
				// Conturile angajatorului.
				Salaries.Business.ConturiAngajator conturiAngajator = new Salaries.Business.ConturiAngajator();
				DataSet dsConturiActive = new DataSet(); 
			
				// Luna curenta.
				Salaries.Business.Luni luna = new Salaries.Business.Luni( this.GetAngajator() );
				Salaries.Data.LunaData lunaCurenta = luna.GetLunaActiva();
            
				if (!IsPostBack)
				{
					// Conturile active ale angajatorului.
					conturiAngajator.AngajatorId = this.GetAngajator();
					dsConturiActive = conturiAngajator.GetConturiBancareActiveAngajator();
					drpContAngajator.DataSource = dsConturiActive;
					drpContAngajator.DataTextField = "NumarContIBAN";
					drpContAngajator.DataValueField = "ContID";
					drpContAngajator.DataBind();

					// Este setata data la care se face plata.
					txtDataPlatii.Text = lunaCurenta.Data.ToShortDateString();
				}
				this.raportDeclaratieA1.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);
				// Sunt setati parametrii raportului.
				// ID-ul angajatorului pentru care se genereaza declaratia pentru sanatate.
				this.raportDeclaratieA1.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
				// Id-ul lunii pentru care se genereaza declaratia pentru sanatate.
				this.raportDeclaratieA1.SetQueryParameter("LunaID_1",this.GetCurrentMonth().ToString());
				// ID-ul contului angajatorului.
				this.raportDeclaratieA1.SetQueryParameter("ContID",drpContAngajator.SelectedItem.Value);
				// Numarul de file ale anexei 2.
				this.raportDeclaratieA1.SetQueryParameter("NrFileAnexa2",txtNrFleAnexa2.Text);
				// Data platii drepturilor salariale.
				this.raportDeclaratieA1.SetQueryParameter("DataPlataSalarii",txtDataPlatii.Text);
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
		private void btnAfiseaza_Click(object sender, System.EventArgs e)
		{		
		}
		#endregion
	}
}
