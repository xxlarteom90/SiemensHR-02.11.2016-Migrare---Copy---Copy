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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Principal;

using Salaries.Configuration;
using Salaries.Business;
using SiemensHR.utils;
using SiemensHR.Classes;
using System.IO;

namespace SiemensHR
{
	/// <summary>
	/// Summary description for index.
	/// </summary>
	public class index : System.Web.UI.Page
	{
		#region Variabile
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Security.Principal.WindowsPrincipal user;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		
        {
            if (!IsPostBack)
            {
                //se obtine tipul de autentificare la aplicatie
                string authentication = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("authentication");
                //daca utilizatorul nu are acces la aplicatie atunci este redirectat catre o pagina in care este afisat un mesaj de avertizare
                if (authentication == "0")
                {
                    ErrHandler.MyErrHandler.WriteError("Index.aspx - utilizatorul nu are acces la aplicatie");
                    Response.Redirect("Unauthorized.aspx");
                }

                //este sters tot din sesine
                Session.RemoveAll();
                try
                {
                    //se preia stringul de conexiune din web.config
                    settings = Salaries.Configuration.ModuleConfig.GetSettings();
                    UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);

                    //daca lipseste una din datele strinct necesare pentru conectare la baza, 
                    //utilizatorul este redirectat catre pagina pentru introducerea acestor valori
                    string[] s = settings.ConnectionString.Split(';');
                    if ((s[2] == "data source=") || (s[4] == "initial catalog=") || (s[5] == "user id=") || (s[6] == "pwd="))
                    {
                        Response.Redirect("AdminSetari.aspx");
                    }

                    //se verifica daca se pot obtine date din baza de date
                    int angajatorId = 0;
                    try
                    {
                        //daca nu se pot atunci stringul de conexiune nu este corect si utilizatorul este redirectat pentru
                        //introducerea unui string de conexiune corect
                        Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
                        int TaraID = int.Parse(tari.LoadInfoTari().Tables[0].Rows[0]["TaraID"].ToString());
                    }
                    catch (Exception e1)
                    {
                        Response.Redirect("AdminSetari.aspx");
                        string msg = e1.Message;
                    }

                    //se selecteaza un angajator
                    Salaries.Business.AdminAngajator angajator = new Salaries.Business.AdminAngajator();
                    try
                    {
                        //daca nu se poate face acest lucru atunci in baza nu exista angajatori si utilizatorul este
                        //redirectat catre pagina pentru introducerea primului angajator
                        angajatorId = int.Parse(angajator.LoadInfoAngajatori().Tables[0].Rows[0]["AngajatorID"].ToString());
                    }
                    catch
                    {
                        Response.Redirect("Administrare/AdminPrimulAngajator.aspx");
                    }

                    Session["AngajatorID"] = angajatorId.ToString();
                    Session["AngajatorDenumire"] = angajator.LoadInfoAngajatori().Tables[0].Rows[0]["Denumire"].ToString();

                    //autentificarea este de tip windows prin Active Directory
                    if ( authentication == "1")
                    {
                        //este preluat user-ul loginat
                        user = new WindowsPrincipal(WindowsIdentity.GetCurrent());

                        //daca utilizatorul face parte din grupul HR
                        if (Salaries.Business.Authentication.IsUserInHRgroup(user))
                        {
                            Session["administrare_departamente"] = "";
                            Response.Redirect("Home.aspx");
                        }
                        else
                        {
                            //daca user-ul faca parte din grupul de manageri
                            if (Salaries.Business.Authentication.IsUserInManagersGroup(user))
                            {
                                Response.Redirect("Managers/Managers.aspx");
                            }
                            else
                            {
                                //daca user-ul faca parte din grupul de recrutori
                                if (Salaries.Business.Authentication.IsUserInRecrutoriGroup(user))
                                {
                                    Response.Redirect("Recrutori/Recrutori.aspx");
                                }
                                else
                                {
                                    ErrHandler.MyErrHandler.WriteError("Index.aspx - autentificare windows fara drepturi - " + user.Identity.Name);
                                    Response.Redirect("Unauthorized.aspx");
                                }
                            }
                        }
                    }
                    //autentificarea este cu user si parola
                    else
                    {
                        Response.Redirect("AdminUserParola.aspx");
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }
            }
		}
		#endregion

		#region Page_PreRender
		private void Page_PreRender(object sender, System.EventArgs e)
		{}
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
