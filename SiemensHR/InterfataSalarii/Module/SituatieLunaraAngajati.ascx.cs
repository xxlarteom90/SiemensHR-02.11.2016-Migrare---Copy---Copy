using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
	
using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for SituatieLunaraAngajati.
	/// </summary>
	public class SituatieLunaraAngajati : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.DropDownList lstAngajati;
		protected System.Web.UI.HtmlControls.HtmlTableCell Container;
		protected SituatieLunaraAngajat SituatieLunaraAngajat1;
		protected Salaries.Configuration.ModuleSettings settings;	
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			lstAngajati.Visible = false;

			if (!IsPostBack)
			{
				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);
				utilDb.CreateAngajatiSiVidSelectBox(this.lstAngajati);
				this.SetAngajat(long.Parse(this.lstAngajati.SelectedValue));
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
			this.lstAngajati.SelectedIndexChanged += new System.EventHandler(this.lstAngajati_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
		}
		#endregion

		#region lstAngajati_SelectedIndexChanged
		/// <summary>
		/// Procedura modifica angajatul selectat
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstAngajati_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.SetAngajat(long.Parse(this.lstAngajati.SelectedValue));
		}
		#endregion

	}
}
