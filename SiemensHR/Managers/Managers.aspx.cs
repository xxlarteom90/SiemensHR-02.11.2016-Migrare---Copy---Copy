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
using Salaries.Configuration;
using System.Security.Principal;

using Salaries.Business;
using Salaries.Data;
using SiemensHR.utils;

namespace SiemensHR
{
	/// <summary>
	/// Summary description for Managers.
	/// </summary>
	public class Managers : System.Web.UI.Page
	{
		#region Variabile
		protected System.Security.Principal.WindowsPrincipal user;
		protected System.Web.UI.WebControls.Label lblErr;
		protected System.Web.UI.WebControls.Table mainTable;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				try
				{
					//se obtine tipul de autentificare la aplicatie
					string authentication = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("authentication");
					
					//autentificare de tip windows
					if (authentication == "1")
					{
						//este preluat user-ul loginat
						user = new WindowsPrincipal(WindowsIdentity.GetCurrent());

						//se verifica daca user-ul face parte din grupul Managers
						if(Salaries.Business.Authentication.IsUserInManagersGroup(user))
						{
							lblErr.Text = "";

							//numele user-ului
							string userName = user.Identity.Name;
						
							//numele departamentului din care face parte user-ul
							string numeDepartament = "";
					
							//numele user-ului va fi de forma: numeUser_numeDepartament
							//este definit separatorul
							char separator = '_';
					
							string [] arrUserName = userName.Split(separator);

							if(arrUserName.Length > 1)
							{
								//este obtinut numele departamentului din care face parte user-ul
								numeDepartament = arrUserName[1].ToString();
								Parameters.NumeDepartament = numeDepartament;
							
							}
							else
								//daca user-ul nu face parte din nici un departement, se afiseaza mesaj de eroare
								lblErr.Text = "Ne pare rau, dar nu faceti parte din nici un departament!";
						}
						else
						{
							ErrHandler.MyErrHandler.WriteError("Managers.aspx - autentificare windows fara drepturi - " + user.Identity.Name);
							Server.Transfer("../Unauthorized.aspx");
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
						
							//se verifica daca utilizatorul face parte din grupul Managers
							if(Salaries.Business.Authentication.IsUserInManagersGroup(nume, parola, angajatorId))
							{
								lblErr.Text = "";

								//numele user-ului
								string userName = nume;
						
								//numele departamentului din care face parte user-ul
								string numeDepartament = "";
					
								//numele user-ului va fi de forma: numeUser_numeDepartament
								//este definit separatorul
								char separator = '_';
					
								string [] arrUserName = userName.Split(separator);

								if(arrUserName.Length > 1)
								{
									//este obtinut numele departamentului din care face parte user-ul
									numeDepartament = arrUserName[1].ToString();
									Parameters.NumeDepartament = numeDepartament;							
								}
								else
								{
									//daca user-ul nu face parte din nici un departement, se afiseaza mesaj de eroare
									lblErr.Text = "Ne pare rau, dar nu faceti parte din nici un departament!";
								}
							}
							else
							{
								ErrHandler.MyErrHandler.WriteError("SearchAngajati.aspx - autentificare user parola fara drepturi - " + nume + ", " + angajatorId);
								Server.Transfer("../Unauthorized.aspx");
							}
						}
						catch(Exception exc)
						{
							Response.Redirect("../index.aspx");
						}
					}				
				}
				catch(Exception ex)
				{
					lblErr.Text = ex.Message;
				}
			}
			string myCmd = Request.QueryString["cmd"]; // comanda

			// setez atributele tabelului principal
			mainTable.Attributes.Add("width", "100%");
			mainTable.Attributes.Add("height", "100%");
			mainTable.Attributes.Add("border", "0");
			mainTable.Attributes.Add("cellpadding", "0");
			mainTable.Attributes.Add("cellspacing", "0");

			TableRow myRow; 
			TableRow mySecondRow; 
			TableCell myCell;

			// al doilea tabel.. care va contine 1 linie - control centru
			Table secondTable = new Table();
			secondTable.Attributes.Add("width", "100%");
			secondTable.Attributes.Add("height", "100%");
			secondTable.Attributes.Add("border", "0");
			secondTable.Attributes.Add("cellpadding", "0");
			secondTable.Attributes.Add("cellspacing", "0");

			// se adauga partea stanga - optiuni la salarii
			myRow = new TableRow();
			myCell = new TableCell();
			myCell = new TableCell();
			myCell.Width = new Unit(200, UnitType.Pixel);
			ManagersOptions myManagersOptions = (ManagersOptions) LoadControl("ManagersOptions.ascx");
			myCell.Attributes.Add("valign", "top");
			myCell.Attributes.Add("height","100%");
			myCell.Controls.Add(myManagersOptions);
			myRow.Cells.Add(myCell);

			// se adauga prima linie din tabel.. ce contine controlul
			mySecondRow = new TableRow();
			myCell = new TableCell();
			myCell.Attributes.Add("valign","top");
			myCell.Attributes.Add("height","100%");
			myCell.Attributes.Add("align","center");
			if(myCmd==null) myCmd="contract_munca";	
			switch (myCmd)
			{
				case "contract_munca":
					ManagersOptions_ContrMunca myContrMunca= (ManagersOptions_ContrMunca) LoadControl("ManagersOptions_ContrMunca.ascx");
					myCell.Controls.Add(myContrMunca);
					break;
				case "check_up":
					ManagersOptions_Checkup myCheckup= (ManagersOptions_Checkup) LoadControl("ManagersOptions_Checkup.ascx");
					myCell.Controls.Add(myCheckup);
					break;
				case "data_majorare":
					ManagersOptions_DataMajorare myDataMajorare= (ManagersOptions_DataMajorare) LoadControl("ManagersOptions_DataMajorare.ascx");
					myCell.Controls.Add(myDataMajorare);
					break;
				case "evolutie_salariu":
					ManagersOptions_EvolutieSal myEvSal= (ManagersOptions_EvolutieSal) LoadControl("ManagersOptions_EvolutieSal.ascx");
					myCell.Controls.Add(myEvSal);
					break;
				case "salarii_angajati":
					ManagersOptions_EvSalAngDept myEvSalDept= (ManagersOptions_EvSalAngDept) LoadControl("ManagersOptions_EvSalAngDept.ascx");
					myCell.Controls.Add(myEvSalDept);
					break;
				case "exit":
					Response.Write("<script>window.close();</script>");
					break;
			}
		
			mySecondRow.Cells.Add(myCell);
			secondTable.Rows.Add(mySecondRow);

			// se adauga al doilea tabel la primul
			myCell = new TableCell();
			myCell.Controls.Add(secondTable);
			myCell.Attributes.Add("height","100%");
			myCell.Attributes.Add("width","100%");
			myRow.Cells.Add(myCell);
			mainTable.Rows.Add(myRow);
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
