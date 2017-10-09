using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Salaries.Data;

namespace SiemensHR
{
	/// <summary>
	///		Summary description for ManagersOptions_ContrMuncaRaport1.
	/// </summary>
	public class MO_CheckupRaport : System.Web.UI.UserControl
	{
		#region Constrante
		// Numele cheii din web.config care contine calea catre serverul cu rapoartele.
		private const string STRING_URL = "rapoarteServerUrl";
		#endregion		

		#region Variabile
		protected System.Web.UI.WebControls.Label lblErr;
		protected ReportingServices.ReportViewer rapCheckup;
		protected string datastart,datastop;
		#endregion

		#region Proprietati
		public string DataStart
		{
			set
			{
				datastart=value;
			}
		}

		public string DataStop
		{
			set
			{
				datastop=value;
			}
		}
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{}
		#endregion
		
		#region OnPreRender
		/// <summary>
		/// Se stabilesc parametrii raportului si se genereaza raportul
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			this.rapCheckup.ServerUrl = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(STRING_URL);

			this.rapCheckup.SetQueryParameter("dataStart",Parameters.DateAdjust(datastart));
			this.rapCheckup.SetQueryParameter("dataStop",Parameters.DateAdjust(datastop));
			this.rapCheckup.SetQueryParameter("numeDepartament",Parameters.NumeDepartament);

			Parameters.ProcessErrors(this.lblErr);
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
