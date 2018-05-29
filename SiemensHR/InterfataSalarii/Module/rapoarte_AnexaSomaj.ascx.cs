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
	public class rapoarte_AnexaSomaj : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
        #region Variabile
        protected System.Web.UI.WebControls.Label labelError;
        protected System.Web.UI.WebControls.ValidationSummary sumarValidare;
        protected System.Web.UI.WebControls.DropDownList drpAngajatiLichidati;
        protected ReportingServices.ReportViewer raportAnexaSomaj;
        protected System.Web.UI.WebControls.Button btnAfiseaza;
        private int idAngajat;
        #endregion
		protected ReportingServices.ReportViewer raportDateLichidare;

		#region Constrante
		// Numele cheii din web.config care contine calea catre serverul cu rapoartele.
		private const string STRING_URL = "rapoarteServerUrl";
		#endregion

		#region Page_Load
		protected void Page_Load(object sender, System.EventArgs e)
		{
		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			try
			{
				labelError.Text = "";
				DataSet dsAngajatiLichidati = new DataSet(); 
				int angajatorId = this.GetAngajator();
				Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
				angajat.AngajatorId = angajatorId;

				// Luna curenta.
				Salaries.Business.Luni luna = new Salaries.Business.Luni( angajatorId );
				Salaries.Data.LunaData lunaCurenta = luna.GetLunaActiva();
            
				if (drpAngajatiLichidati.SelectedValue!="")
					idAngajat = Int32.Parse(drpAngajatiLichidati.SelectedValue);
				else
					idAngajat = 0;
				//if (!IsPostBack)
				//{
					// Lista caselor de asigurari ale unui angajator.
					dsAngajatiLichidati = angajat.GetAllAngajatiLichidati(this.GetCurrentMonth());
					drpAngajatiLichidati.DataSource = dsAngajatiLichidati;
					drpAngajatiLichidati.DataTextField = "NumeIntreg";
					drpAngajatiLichidati.DataValueField = "AngajatId";
					drpAngajatiLichidati.DataBind();
				//}
				bool exista = false;
				foreach(DataRow dr in dsAngajatiLichidati.Tables[0].Rows)
					if (Int32.Parse(dr["AngajatId"].ToString()) == idAngajat)
						exista = true;

				if (idAngajat!=0 && exista)
					drpAngajatiLichidati.SelectedValue = idAngajat.ToString();

				this.raportAnexaSomaj.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);
				// Sunt setati parametrii raportului.
				// ID-ul angajatorului pentru care se genereaza raportul.
				this.raportAnexaSomaj.SetQueryParameter("AngajatorID",angajatorId.ToString());
				// Id-ul angajatului pentru care se genereaza raportul.
				this.raportAnexaSomaj.SetQueryParameter("AngajatID",drpAngajatiLichidati.SelectedItem.Value);	
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

		}
		#endregion

		#region btnAfiseaza_Click
		/// <summary>
		/// Afiseaza raportul
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnAfiseaza_Click(object sender, System.EventArgs e)
		{
		}
		#endregion

	}
}
