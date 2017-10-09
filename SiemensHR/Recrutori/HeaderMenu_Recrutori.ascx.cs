using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SiemensHR
{
	/// <summary>
	///		Summary description for HeaderMenu.
	/// </summary>
	public class HeaderMenu_Recrutori : System.Web.UI.UserControl
	{
		public string relativePath;
		
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//se stabileste calea pe proiectul curent
			//numele directorului virtual in care este proiectul
			string virtualDirectory = Request.ServerVariables["PATH_INFO"].ToString().Split('/')[1];
			//numele serverului
			string serverName = Request.ServerVariables["SERVER_NAME"].ToString();
			//calea completa
			
			string path = serverName + "/" + virtualDirectory;
			//pt HRDemo
			//string path = serverName;
			Response.Write( "<script>var fullPath = '"+ path +"';</script>" );
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
