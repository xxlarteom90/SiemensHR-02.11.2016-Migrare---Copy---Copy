using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensTM.Classes;

namespace SiemensTM.Module
{
	/// <summary>
	///		Summary description for HeaderMenu.
	/// </summary>
	public class HeaderMenu : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.HtmlControls.HtmlTableCell admin_separator;
		protected System.Web.UI.HtmlControls.HtmlTableCell admin_link;

		public string relativePath;
		#endregion
		
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{

			SiemensTM.Classes.Login l = (SiemensTM.Classes.Login)this.Page;
			if (l.IsUserLogged() && l.IsAdminUser()) 
			{
				this.admin_separator.InnerHtml="&nbsp;|&nbsp;";
				this.admin_link.InnerHtml="Administrare";
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
