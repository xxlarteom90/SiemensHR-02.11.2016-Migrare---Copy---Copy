using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR
{
	/// <summary>
	///		Summary description for ManagersOptions.
	/// </summary>
	public class ManagersOptions : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Table OptionTable;

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string[] textOptions = {"Check-up-uri","Contracte de munca","Evolutie salarii","Majorari salarii", "Salarii angajati","Exit"};
			string[] cmdOptions = {"check_up","contract_munca","evolutie_salariu","data_majorare","salarii_angajati","exit"};

			Utilities.CreateOptionList(OptionTable, textOptions, cmdOptions, "SelectManagersOption", "../", "100%", "150");
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
