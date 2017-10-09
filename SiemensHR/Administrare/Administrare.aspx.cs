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

namespace SiemensHR.Administrare
{
	/// <summary>
	/// Summary description for Administrare.
	/// </summary>
	public class Administrare : System.Web.UI.Page
	{
		protected System.Security.Principal.WindowsPrincipal user;
		protected System.Web.UI.WebControls.Table mainTable;
		//Meniul din stanga al paginii
		protected AdminMeniu adminMeniu;
	
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
		
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
						ErrHandler.MyErrHandler.WriteError("Administrare.aspx - autentificare windows fara drepturi - " + user.Identity.Name);
						Response.Redirect("../Unauthorized.aspx");
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
							ErrHandler.MyErrHandler.WriteError("Administrare.aspx - autentificare user parola fara drepturi - " + nume + ", " + angajatorId);
							Response.Redirect("../Unauthorized.aspx");
						}
					}
					catch(Exception exc)
					{
						Response.Redirect("../index.aspx");
					}
				}
			}
			
			Response.Write( ConstrSirComenzi() );
			
			TableCell celulaMeniu = new TableCell();
			celulaMeniu.Height = Unit.Point( 570 );
			celulaMeniu.Width = Unit.Point( 190 );
			celulaMeniu.BorderWidth = 0;
			celulaMeniu.HorizontalAlign = HorizontalAlign.Left;

			adminMeniu = ( AdminMeniu )LoadControl( Request.ApplicationPath + "/AdminMeniu.ascx" );
			adminMeniu.XmlSursa = "../Navigare/Administrare_Navigare.xml";
			celulaMeniu.Controls.Add( adminMeniu );

			Table continut = new Table();
			continut.HorizontalAlign = HorizontalAlign.Center;
			
			TableCell celulaContinut = new TableCell();
			celulaContinut.VerticalAlign = VerticalAlign.Top;
			celulaContinut.Controls.Add( continut );

			TableRow randLiber = new TableRow();
			randLiber.Cells.Add( new TableCell() );
			randLiber.Height = Unit.Point( 20 );
			continut.Rows.Add( randLiber );
			
			TableRow continutPagina = new TableRow();
			continutPagina.Cells.Add( celulaMeniu );
			continutPagina.Cells.Add( celulaContinut );

			mainTable.Rows.Add( continutPagina );

			TableCell myCell = new TableCell();

			TableRow myRow = new TableRow();
			myRow.Cells.Add(myCell);
			continut.Rows.Add(myRow);
			
			string myCmd = Request.QueryString["cmd"];
			switch (myCmd)
			{
				case "admin_banci":	
					AdminBanci myAdminBanci = (AdminBanci) LoadControl("AdminBanci.ascx");
					myCell.Controls.Add(myAdminBanci);
					break;
				case "admin_angajatori":
				case null:
					int idAngajator = Convert.ToInt32(Request.QueryString["id"]);
					// nu este editare angajator
					if (idAngajator==0) 
					{						
						AdminAngajatori myAdminAngajatori = (AdminAngajatori) LoadControl("AdminAngajatori.ascx");
						myCell.Controls.Add(myAdminAngajatori);
					}
					// este editre angajator
					else 
					{
						AdminAngajatoriEdit myAdminAngajatori = (AdminAngajatoriEdit) LoadControl("AdminAngajatoriEdit.ascx");
						myAdminAngajatori.idAngajator = idAngajator;
						myCell.Controls.Add(myAdminAngajatori);
					}
					break;
				case "admin_centrecost":
					AdminCentreCost myAdminCentreCost = (AdminCentreCost) LoadControl("AdminCentreCost.ascx");
					myCell.Controls.Add(myAdminCentreCost);
					break;
				case "admin_tip_rapoarte":
					AdminTipuriRapoarte myAdminTipuriRapoarte = (AdminTipuriRapoarte) LoadControl("AdminTipuriRapoarte.ascx");
					myCell.Controls.Add(myAdminTipuriRapoarte);
					break;
				case "admin_judete":
					AdminJudete myAdminjudete = (AdminJudete) LoadControl("AdminJudete.ascx");
					myCell.Controls.Add(myAdminjudete);
					break;
				case "admin_tari":
					AdminTari myAdmintari = (AdminTari) LoadControl("AdminTari.ascx");
					myCell.Controls.Add(myAdmintari);
					break;
				case "admin_titutalturi":
					AdminTitluriAngajati myAdmintitluriangajati = (AdminTitluriAngajati) LoadControl("AdminTitluriAngajati.ascx");
					myCell.Controls.Add(myAdmintitluriangajati);
					break;
				case "admin_studii":
					AdminStudii myAdminStudii = (AdminStudii) LoadControl("AdminStudii.ascx");
					myCell.Controls.Add(myAdminStudii);
					break;
				case "admin_functii":
					AdminFunctii myAdminFunctii = (AdminFunctii) LoadControl("AdminFunctii.ascx");
					myCell.Controls.Add(myAdminFunctii);
					break;
				case "admin_traininguri":
					AdminTraininguri myAdminTraininguri = (AdminTraininguri) LoadControl("AdminTraininguri.ascx");
					myCell.Controls.Add(myAdminTraininguri);
					break;
				case "admin_departamente":
					Session["administrare_departamente"] = "administrare_departamente";
					AdminDepartamente myAdminDept = (AdminDepartamente) LoadControl("AdminDepartamente.ascx");
					myCell.Controls.Add(myAdminDept);
					break;
				case "admin_invaliditati":
					AdminInvaliditati myAdminInv = (AdminInvaliditati) LoadControl("AdminInvaliditati.ascx");
					myCell.Controls.Add(myAdminInv);
					break;
				case "admin_domenii_de_activitate":
					AdminDomeniiDeActivitate myAdminDomDeAct = (AdminDomeniiDeActivitate) LoadControl("AdminDomeniiDeActivitate.ascx");
					myCell.Controls.Add(myAdminDomDeAct);
					break;
				case "admin_completare_carnete":
					AdminTipuriCompletareCarnete myAdminCompletareCarnete = (AdminTipuriCompletareCarnete) LoadControl("AdminTipuriCompletareCarnete.ascx");
					myCell.Controls.Add(myAdminCompletareCarnete);
					break;
				// Adaugat de Anca Holostencu
				// Descriere: Tab-ul pentru administrarea caselor de asigurari si cel pentru variabilele globale
				case "admin_case_de_asigurari":
					myCell.Controls.Add((AdminCaseDeAsigurari)LoadControl("AdminCaseDeAsigurari.ascx") );
					break;
				case "admin_variabile_salarizare":
					myCell.Controls.Add((AdminVariabileGlobale)LoadControl("AdminVariabileGlobale.ascx") );
					break;
				//Adaugat:		Lungu Andreea
				//Data:			02.11.2007
				//Descriere:	Modulul pentru gestiunea utilizatorilor aplicatiei.
				case "admin_utilizatori":
					myCell.Controls.Add((AdminUtilizatori)LoadControl("AdminUtilizatori.ascx"));
					break;
				//Adaugat:		Lungu Andreea
				//Data:			02.11.2007
				//Descriere:	Modificarea parolei pentru utilizatorul curent al aplicatiei.
				case "admin_schimbare_parola":
					myCell.Controls.Add((AdminChangePassword)LoadControl("AdminChangePassword.ascx"));
					break;
				case "admin_utilizatori_nivele":
					myCell.Controls.Add((AdminUtilizatoriNivele)LoadControl("AdminUtilizatoriNivele.ascx"));
					break;
				case "edit_utilizator":
					myCell.Controls.Add((EditUtilizator)LoadControl("EditUtilizator.ascx"));
					break;
			}
		}
		#endregion

		#region ConstrSirComenzi
		private string ConstrSirComenzi() 
		{
			string curent_cmd = Request.QueryString["cmd"];
			if (curent_cmd==null)
				curent_cmd = "admin_angajatori";

			return "<script>var arTabs = new Array(" +
									"\"admin_banci\", " +
									"\"admin_case_de_asigurari\", " +
									"\"admin_judete\", " +
									"\"admin_tip_rapoarte\", " +
									"\"admin_tari\", " +

									"\"admin_angajatori\", " +
									"\"admin_centrecost\", " +
									"\"admin_completare_carnete\", " +
									"\"admin_departamente\", " +
									"\"admin_domenii_de_activitate\", " +
										
									"\"admin_traininguri\", " +
									"\"admin_functii\", " +
									"\"admin_invaliditati\", " +
									"\"admin_studii\", " +
									"\"admin_titutalturi\", " +
									
									"\"admin_variabile_salarizare\", " +
									"\"admin_utilizatori\", " +
									"\"admin_schimbare_parola\", " +
									"\"admin_utilizatori_nivele\" ); " +
							"var selectedTab = \"" + curent_cmd + "\";" +
				   "</script>";
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

		#region Render
		protected override void Render(HtmlTextWriter writer)
		{			
			base.Render (writer);
			Response.Write( adminMeniu.ScriptNavigare );
		}
		#endregion
	}
}
