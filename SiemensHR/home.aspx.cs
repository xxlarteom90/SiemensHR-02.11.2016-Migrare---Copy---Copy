/*
* Modificat:	Fratila Claudia
* Data:		31.10.2007
* Descriere:	A fost modificata clasa astfel incat sa existe doua moduri autentificare: Windows sau user si parola.
* 				Tipul de autentificare este stabilit in fisierul de configurare.
* 				0 - fara autnetificare
* 				1 - autentificare windows
* 				2 - autentificare user si parola
*/	

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;			
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Principal;
using System.Globalization;

using SiemensHR.utils;

namespace SiemensHR
{
	/// <summary>
	/// Summary description for home.
	/// </summary>
	public class home : System.Web.UI.Page
	{
		#region Variabile
		protected System.Security.Principal.WindowsPrincipal user;
		#endregion
	
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{

			ErrHandler.MyErrHandler.WriteError("home.aspx");
			if(!IsPostBack)
			{	
				//se obtine tipul de autentificare la aplicatie
				string authentication = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("authentication");
				
				//virtual path
				string path = Page.Request.FilePath;
				char separator = '/';
				string [] pathArr = path.Split(separator);
				int nr = pathArr.Length;

				//autentificare de tip windows
				if (authentication == "1")
				{
					//user-ul loginat
					user = new WindowsPrincipal(WindowsIdentity.GetCurrent());

					//user-ul loginat nu are dreptul sa acceseze aceasta pagina este redirectat catre o pagina care sa il instiinteze de acest lucru
					if(!Salaries.Business.Authentication.HasUserRightsOnPage(pathArr[nr-1],user))
					{
						ErrHandler.MyErrHandler.WriteError("Home.aspx - autentificare windows fara drepturi - " + user.Identity.Name);
						Response.Redirect("Unauthorized.aspx");
					}
				}
				//autentificare cu user si parola
				else
				{
					try
					{
						string nume = Session["Nume"].ToString();
						string parola = Session["Parola"].ToString();
						int angajatorId = int.Parse(Session["AngajatorId"].ToString());

						//user-ul loginat nu are dreptul sa acceseze aceasta pagina este redirectat catre o pagina care sa il instiinteze de acest lucru
						if(!Salaries.Business.Authentication.HasUserRightsOnPage(pathArr[nr-1], nume, parola, angajatorId))
						{
							ErrHandler.MyErrHandler.WriteError("Home.aspx - autentificare user parola fara drepturi - " + nume + ", " + angajatorId);
							Response.Redirect("Unauthorized.aspx");
						}
					}
					catch(Exception exc)
					{
						Response.Redirect("index.aspx");
					}
				}
					
				//Setam session-ul pentru paginile de administrare din AddAngajat
				Session["AdminCategoriiAngajati_AddAngajat"] = 0;
			}
			
			string numberOfDigits = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("numberOfDigits");
			Salaries.Business.VariabileGlobale.numberInfoFormatWithDigits.NumberDecimalDigits = int.Parse(numberOfDigits);
			Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits.NumberDecimalDigits = 0;

			//Variabilele de sesiune au valoare vida
			Session["ModificaSituatie"] = "";
			Session["Recrutori"] = "";
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion		
	}
}
