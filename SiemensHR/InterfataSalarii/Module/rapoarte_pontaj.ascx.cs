namespace SiemensHR.InterfataSalarii.Module
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for rapoarte_pontaj.
	/// </summary>
	public class rapoarte_Pontaj : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		protected System.Web.UI.WebControls.Button btnAfiseaza;
		protected System.Web.UI.WebControls.Label labelError;
		protected System.Web.UI.WebControls.ValidationSummary sumarValidare;
		protected ReportingServices.ReportViewer raportPontaj;
		protected ReportingServices.ReportViewer raportFisierMulticache;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldData;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredData;
		//protected System.Web.UI.WebControls.TextBox txtDataPlatii;
		//protected System.Web.UI.WebControls.TextBox txtLunaAn;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		//protected System.Web.UI.WebControls.TextBox txtTipulPlatii;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.TextBox txtDataPlatii;
		protected System.Web.UI.WebControls.DropDownList drpContAngajator;
		protected System.Web.UI.WebControls.DropDownList drpMonedaCont;
		protected System.Web.UI.WebControls.TextBox txtTipulPlatii;
		protected System.Web.UI.WebControls.TextBox txtLunaAn;
		//protected System.Web.UI.WebControls.DropDownList drpMonedaCont;
		//protected System.Web.UI.WebControls.DropDownList drpContAngajator; 

		#region Constrante
		// Numele cheii din web.config care contine calea catre serverul cu rapoartele.
		private const string STRING_URL = "rapoarteServerUrl";
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}
		/*
		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			try
			{
				// Conturile angajatorului.
				Salaries.Business.ConturiAngajator conturiAngajator = new Salaries.Business.ConturiAngajator();
				DataSet dsConturiActive = new DataSet(); 
				// Monezile in care au angajatii deschise conturi.
				DataSet dsMonede = new DataSet();
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

					// Monezile in care au angajatii deschise conturi
					dsMonede = conturiAngajator.GetMonedaConturiAngajati();
					drpMonedaCont.DataSource = dsMonede;
					drpMonedaCont.DataTextField = "Moneda";
					drpMonedaCont.DataValueField = "Moneda";
					drpMonedaCont.DataBind();

					// Luna pentru care se face plata.
					switch (lunaCurenta.Data.Month)
					{
						case 1: txtLunaAn.Text = "ian.";
							break;
						case 2: txtLunaAn.Text = "feb.";
							break;
						case 3: txtLunaAn.Text = "martie";
							break;
						case 4: txtLunaAn.Text = "apr.";
							break;
						case 5: txtLunaAn.Text = "mai";
							break;
						case 6: txtLunaAn.Text = "iun.";
							break;
						case 7: txtLunaAn.Text = "iul.";
							break;
						case 8: txtLunaAn.Text = "aug.";
							break;
						case 9: txtLunaAn.Text = "sept.";
							break;
						case 10: txtLunaAn.Text = "oct.";
							break;
						case 11: txtLunaAn.Text = "noi.";
							break;
						case 12: txtLunaAn.Text = "dec.";
							break;
					}

					txtLunaAn.Text += lunaCurenta.Data.Year.ToString();

					// Este setata data la care se face plata.
					txtDataPlatii.Text = lunaCurenta.Data.ToShortDateString();
				}

				this.raportPontaj.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);
				// Sunt setati parametrii raportului.
				// ID-ul angajatorului pentru care se genereaza fisierul multicache
				this.raportPontaj.SetQueryParameter("AngajatorID",this.GetAngajator().ToString());
				// Id-ul lunii pentru care se genereaza fisierul multicache.
				this.raportPontaj.SetQueryParameter("LunaID",this.GetCurrentMonth().ToString());
				// ID-ul contului angajatorului.
				this.raportPontaj.SetQueryParameter("ContID",drpContAngajator.SelectedItem.Value);
				// Moneda in care sunt deschise conturile angajatilor.
				this.raportPontaj.SetQueryParameter("Moneda",drpMonedaCont.SelectedItem.Text);
				// Luna si anul la care se face plata.
				this.raportPontaj.SetQueryParameter("LunaAn",txtLunaAn.Text);
				// Data platii.
				this.raportPontaj.SetQueryParameter("Data",txtDataPlatii.Text);
				// Tipul platii.
				this.raportPontaj.SetQueryParameter("TipPlata",txtTipulPlatii.Text);
			}
			catch ( Exception )
			{
				labelError.Text = "Pentru a putea genera raportul trebuie sa fie disponibile toate datele necesare!";
			}
		}
		#endregion
		*/
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
