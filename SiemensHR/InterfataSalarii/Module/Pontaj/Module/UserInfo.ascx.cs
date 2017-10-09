using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensTM.Classes;
using SiemensHR.Classes;

namespace SiemensTM.Module
{
	/// <summary>
	///		Summary description for UserInfo.
	/// </summary>
	public class UserInfo : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Label lblNume;
		protected System.Web.UI.WebControls.Label lblFunctie;
		protected System.Web.UI.WebControls.Label lblDepartament;
		protected System.Web.UI.WebControls.Label lblTitlu;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			SiemensTM.Classes.Login l = new SiemensTM.Classes.Login();
			Salaries.Business.Angajat objAngajat = l.GetLoggedAngajat();
			if (objAngajat!=null)
			{
				int id = new SiemensTM.Classes.Login().GetLoggedUserID();
			
				lblNume.Text = objAngajat.Nume + " " + objAngajat.Prenume;
				lblTitlu.Text = objAngajat.TitluSimbol;
				if (l.IsAdminUser()) lblTitlu.Text=" Administrator - "+lblTitlu.Text;
				
				lblFunctie.Text = objAngajat.FunctieCurentaNume;
				lblDepartament.Text = objAngajat.DepartamentCurentCod;
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
