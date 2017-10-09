using System.Configuration;
using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensTM.utils;

namespace SiemensTM.Module
{
	/// <summary>
	///		Summary description for IntervalOreNestandard.
	/// </summary>
	public class IntervalOreNestandard : System.Web.UI.UserControl
	{
		#region Variabile
		public System.Web.UI.WebControls.Label labelTipOreSuplimentare;
		public System.Web.UI.WebControls.TextBox txtNrOreSuplimentare;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		public int tipIntervalID = -1;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.txtNrOreSuplimentare.Attributes["onblur"] = "NrOreSuplimentare_Changed("+tipIntervalID.ToString()+", this)";
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
