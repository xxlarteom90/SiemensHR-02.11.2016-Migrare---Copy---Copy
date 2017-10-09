/*
* Modificat:	Fratila Claudia
* Data:			31.10.2007
* Descriere:	A fost modificata clasa astfel incat sa existe doua moduri autentificare: Windows sau user si parola.
* 				Tipul de autentificare este stabilit in fisierul de configurare.
* 				0 - fara autnetificare
* 				1 - autentificare windows
* 				2 - autentificare user si parola
*/

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SiemensHR.Administrare
{
	/// <summary>
	///		Summary description for AdminUserParola.
	/// </summary>
	public class AdminUserParola : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnLogin;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.TextBox txtParola;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredUtilizator;
		protected System.Web.UI.WebControls.TextBox txtUtilizator;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_form;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTitle;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdNouaParola;
		protected System.Web.UI.HtmlControls.HtmlTableRow td_addLine;
		protected System.Web.UI.HtmlControls.HtmlTableRow add_buttonLine;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnLogin_Click
		private void btnLogin_Click(object sender, System.EventArgs e)
		{
			int angajatorId = 0;
			try
			{
				Session["Nume"] = txtUtilizator.Text;
				Session["Parola"] = txtParola.Text;
				Salaries.Business.AdminUtilizatori utiliz = new Salaries.Business.AdminUtilizatori();
				angajatorId = int.Parse(Session["AngajatorID"].ToString());
				utiliz.Nume = txtUtilizator.Text;
				utiliz.Parola = txtParola.Text;
				Session["IdUtilizator"] = utiliz.GetUtilizatorId(angajatorId);
			}
			catch (Exception ex)
			{
				Response.Redirect("index.aspx");
			}

			//daca utilizatorul face parte din grupul HR
			if(Salaries.Business.Authentication.IsUserInHRgroup(txtUtilizator.Text, txtParola.Text, angajatorId))
			{
				Session["administrare_departamente"] = "";
				Response.Redirect("Home.aspx");	
			}
			else
			{
				//daca user-ul faca parte din grupul de manageri
				if(Salaries.Business.Authentication.IsUserInManagersGroup(txtUtilizator.Text, txtParola.Text, angajatorId))
				{
					Response.Redirect("Managers/Managers.aspx");
				}
				else
				{
					//daca user-ul faca parte din grupul de recrutori
					if(Salaries.Business.Authentication.IsUserInRecrutoriGroup(txtUtilizator.Text, txtParola.Text, angajatorId))
					{
						Response.Redirect("Recrutori/Recrutori.aspx");
					}
						//user-ul nu are dreptul de a accesa aplicatia
					else
					{
						Response.Redirect("Unauthorized.aspx");
					}
				}
			}
			
		}
		#endregion
	}
}
