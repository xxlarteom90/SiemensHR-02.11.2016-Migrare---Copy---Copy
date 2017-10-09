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
using Salaries.Business;
using System.Security.Principal;

using SiemensHR.Classes;
using SiemensHR.Comunicari;
using SiemensHR.EditTasks;
using SiemensHR.EditTasks;

namespace SiemensHR
{
	/// <summary>
	/// Summary description for EditAngajat.
	/// </summary>
	public class EditAngajat_Recrutori: System.Web.UI.Page
	{
		#region Variabile
		protected System.Web.UI.WebControls.Table mainTable;
		private Salaries.Business.Angajat objAngajat;
		private long idAngajat;
		private EditAngajatLeft myEditAngajatLeft;
		protected System.Security.Principal.WindowsPrincipal user;
		#endregion

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
						ErrHandler.MyErrHandler.WriteError("EditAngajat_Recrutori.aspx - autentificare windows fara drepturi - " + user.Identity.Name);
						Server.Transfer("../Unauthorized.aspx");
					}
				}
				//autenticiare cu user si parola
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
							ErrHandler.MyErrHandler.WriteError("EditAngajat_Recrutori.aspx - autentificare user name fara drepturi - " + nume + ", " + angajatorId);
							Server.Transfer("../Unauthorized.aspx");
						}
					}
					catch(Exception exc)
					{
						Response.Redirect("../index.aspx");
					}
				}
			}

            idAngajat = Convert.ToInt32(Request.QueryString["id"]);
			string myCmd = Request.QueryString["cmd"];
			
			mainTable.Attributes.Add("width", "100%");
			mainTable.Attributes.Add("height", "100%");
			mainTable.Attributes.Add("border", "0");
			mainTable.Attributes.Add("cellpadding", "0");
			mainTable.Attributes.Add("cellspacing", "0");

			TableRow myRow;
			TableRow mySecondRow;
			TableCell myCell;

			// al doilea table.. care va contine 2 linii - taskuri si control centru
			Table secondTable = new Table();
			secondTable.Attributes.Add("width", "100%");
			secondTable.Attributes.Add("height", "100%");
			secondTable.Attributes.Add("border", "0");
			secondTable.Attributes.Add("cellpadding", "0");
			secondTable.Attributes.Add("cellspacing", "0");

			try
			{		
				objAngajat = new Salaries.Business.Angajat();
				objAngajat.AngajatId = idAngajat;
				objAngajat.LoadAngajat();
			}
			catch(Exception ex)
			{
				Response.Write("Error loading employee data: <br>");
				Response.Write(ex.Message);
				Response.End();
			}

	
			// se adauga partea stanga
			myRow = new TableRow();
			myCell = new TableCell();
			myCell = new TableCell();
			myCell.RowSpan = 3;
			myCell.Width = new Unit(310, UnitType.Pixel);
			myEditAngajatLeft = (EditAngajatLeft) LoadControl("../EditAngajatLeft.ascx");
			
			myEditAngajatLeft.XmlSursa = "../Navigare/EditAngajat_LeftNavigation_Recrutori.xml";
			myEditAngajatLeft.AngajatID = idAngajat;
			myEditAngajatLeft.objAngajat = objAngajat;
			myCell.Attributes.Add("valign", "top");
			myCell.Controls.Add(myEditAngajatLeft);
			myRow.Cells.Add(myCell);

			// se adauga partea dreapta
			mySecondRow = new TableRow();
			myCell = new TableCell();
			EditAngajatUp myEditAngajatUp = (EditAngajatUp) LoadControl("../EditAngajatUp.ascx");
			myCell.Attributes.Add("valign", "top");
			myCell.Attributes.Add("height", "10");
			myEditAngajatUp.AngajatID = idAngajat;
			myCell.Controls.Add(myEditAngajatUp);
			mySecondRow.Cells.Add(myCell);
			secondTable.Rows.Add(mySecondRow);

			// se adauga a doua linie din tabel.. ce contine controlul
			mySecondRow = new TableRow();
			myCell = new TableCell();
			myCell.Attributes.Add("valign","top");
			myCell.Attributes.Add("height","100%");
			myCell.Attributes.Add("align","center");
			
			Session["Recrutori"] = "Recrutori";
			
			switch (myCmd)
			{
				case "date_personale":
				case null:
					EditAngajatDatePersonale myEditControl = (EditAngajatDatePersonale) LoadControl("../EditTasks/EditAngajatDatePersonale.ascx");
					myEditControl.objAngajat = objAngajat;
					myCell.Controls.Add(myEditControl);
					break;

                //    // Artiom Modificat
                //case "date_angajare":
                //    // var control = LoadControl("EditTasks/EditAngajatDateAngajare.ascx");
                //    // EditAngajatDateAngajare myEditDateAngajatControl = (EditAngajatDateAngajare) control;

                //    EditAngajatDateAngajare myEditDateAngajatControl = (EditAngajatDateAngajare)LoadControl("../EditTasks/EditAngajatDateAngajare.ascx");
                //    myEditDateAngajatControl.objAngajat = objAngajat;
                //    myCell.Controls.Add(myEditDateAngajatControl);
                //    break;


				case "istoric_carte_identitate":
					EditTasks.IstoricCartiIdentitate myIstoricCartiIdentitate = (EditTasks.IstoricCartiIdentitate) LoadControl("../EditTasks/IstoricCartiIdentitate.ascx");
					myIstoricCartiIdentitate.AngajatID = objAngajat.AngajatId;
					myCell.Controls.Add(myIstoricCartiIdentitate);
					break;
				case "istoric_departamente":
					IstoricDepartamente myIstoricDepartamenteControl = (IstoricDepartamente) LoadControl("../EditTasks/IstoricDepartamente.ascx");
					myIstoricDepartamenteControl.AngajatID = objAngajat.AngajatId;
					myCell.Controls.Add(myIstoricDepartamenteControl);
					break;
				case "fisa_postului":
					fisa_postului myfisapostului = (fisa_postului) LoadControl("../Comunicari/fisa_postului.ascx");
					myfisapostului.objAngajat = objAngajat;
					myCell.Controls.Add(myfisapostului);
					break;
				case "change_poza":
					ChangePoza myChangePoza = (ChangePoza) LoadControl("../EditTasks/ChangePoza.ascx");
					myChangePoza.AngajatID = objAngajat.AngajatId;
					myCell.Controls.Add(myChangePoza);
					break;
				case "istoric_functii":
					IstoricFunctii myIstoricFunctii = (IstoricFunctii) LoadControl("../EditTasks/IstoricFunctii.ascx");
					myIstoricFunctii.AngajatID = objAngajat.AngajatId;
					myCell.Controls.Add(myIstoricFunctii);
					break;
				case "istoric_training":
					IstoricTraininguri myIstoricTraininguri = (IstoricTraininguri) LoadControl("../EditTasks/IstoricTraininguri.ascx");
					myIstoricTraininguri.AngajatID = objAngajat.AngajatId;
					myCell.Controls.Add(myIstoricTraininguri);
					break;
				case "checkupuri":
					CheckupuriAngajat myCheckup = (CheckupuriAngajat) LoadControl("../EditTasks/CheckupuriAngajat.ascx");
					myCheckup.AngajatID = objAngajat.AngajatId;
					myCheckup.SefID = objAngajat.SefId;
					myCell.Controls.Add(myCheckup);
					break;
				case "evaluari_psihologice":
					EvaluariPsihologiceAngajat myEval = (EvaluariPsihologiceAngajat) LoadControl("../EditTasks/EvaluariPsihologiceAngajat.ascx");
					myEval.AngajatID = objAngajat.AngajatId;
					myCell.Controls.Add(myEval);
					break;
				case "istoric_referinte":
					ReferinteAngajat myReferinte = (ReferinteAngajat) LoadControl("../EditTasks/ReferinteAngajat.ascx");
					myReferinte.AngajatID = objAngajat.AngajatId;
					myCell.Controls.Add(myReferinte);
					break;
				default:
					myCell.Text = "<img src=\"images/1x1.gif\" width=\"100%\" height=\"100%\">";
					break;
			}
			mySecondRow.Cells.Add(myCell);
			secondTable.Rows.Add(mySecondRow);

//			 se adauga al doilea tabel la primul
			myCell = new TableCell();
			myCell.Controls.Add(secondTable);
			myCell.Attributes.Add("height","100%");
			myCell.Attributes.Add("width","100%");
			myRow.Cells.Add(myCell);
			mainTable.Rows.Add(myRow);	
		}
		#endregion

		#region Page_PreRender
		private void Page_PreRender(object sender, System.EventArgs e)
		{	}
		#endregion
		
		#region Render
		protected override void Render(HtmlTextWriter writer)
		{
			base.Render (writer);
			string aux = myEditAngajatLeft.NavigationScript;
			Response.Write(this.myEditAngajatLeft.NavigationScript);
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
			this.Load +=new System.EventHandler(this.Page_Load);
			this.Load += new System.EventHandler(this.Page_PreRender);

		}
		#endregion
	}
}
