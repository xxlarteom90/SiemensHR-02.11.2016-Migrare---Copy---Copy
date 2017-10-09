/*
* Modificat:	Fratila Claudia
* Data:			29.11.2007
* Descriere:	La initializarea unei luni, pentru cangajatii scutiti de contributia la sanatate, se va calcula valoarea implicita care trebuie retinuta din venit.
	RetinereSanatate = Procent din baza de calcul a contributiei individuale de asigurari de sanatate(PBCISAN) * Salariul minim pe economie (SMINEC)				
* 
* Modificat:	Lungu Andreea
* Data:			18.12.2009
* Descriere:	S-a adaugat logg.
*/

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SiemensHR.utils;
using System.Collections;
using System.Text.RegularExpressions;

using SiemensTM.Classes;
using SiemensHR.Classes;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for InitializareLuna.
	/// </summary>
	public class InitializareLuna : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Constante
		private const int LUNA_INDEXARE_1 = 4;
		private const int LUNA_INDEXARE_2 = 10;
		#endregion

		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.TextBox txtNrZileLuna;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator11;
		protected System.Web.UI.WebControls.TextBox txtNrOreLucrate;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.TextBox txtNrOreSup50Proc;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator2;
		protected System.Web.UI.WebControls.TextBox txtNrOreSup100Proc;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator3;
		protected System.Web.UI.WebControls.TextBox txtNrOreEvenimDeoseb;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator4;
		protected System.Web.UI.WebControls.TextBox txtNrOreInvoire;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator5;
		protected System.Web.UI.WebControls.TextBox txtNrOreConcediuOdihna;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator18;
		protected System.Web.UI.WebControls.TextBox txtNrOreConcediuBoala;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator6;
		protected System.Web.UI.WebControls.TextBox txtSporActivitatiSup;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator7;
		protected System.Web.UI.WebControls.TextBox txtEmergencyService;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator8;
		protected System.Web.UI.WebControls.TextBox txtPrimeSpeciale;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator9;
		protected System.Web.UI.WebControls.TextBox txtAlteDrepturi;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator10;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTableCell LunaContainer;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActiv;
		protected System.Web.UI.WebControls.DropDownList lstCategorii;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtSituatieID;

		public DateTime SelectedDate;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnModificaSituatia1;
		protected System.Web.UI.WebControls.TextBox txtNrOreObligatiiCetatenesti;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator12;
		protected System.Web.UI.WebControls.TextBox txtNrOreAbsenteNemotivate;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator13;
		protected System.Web.UI.WebControls.TextBox txtNrOreConcediuFaraPlata;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator14;
		protected System.Web.UI.HtmlControls.HtmlTableRow trNrOreLucrate;
		protected System.Web.UI.HtmlControls.HtmlTableRow trNrOreEvenimenteDeosebite;
		protected System.Web.UI.HtmlControls.HtmlTableRow trNrOreInvoire;
		protected System.Web.UI.HtmlControls.HtmlTableRow trNrOreConcediuOdihna;
		protected System.Web.UI.HtmlControls.HtmlTableRow trNrOreConcediuBoala;
		protected System.Web.UI.HtmlControls.HtmlTableRow trNrOreObligatiiCetatenesti;
		protected System.Web.UI.HtmlControls.HtmlTableRow trNrOreAbsenteNemotivate;
		protected System.Web.UI.HtmlControls.HtmlTableRow trNrOreConcediuFaraPlata;
		protected System.Web.UI.WebControls.TextBox txtAvans;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator15;
		protected System.Web.UI.WebControls.TextBox txtPrimaProiect;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator17;
		protected System.Web.UI.WebControls.TextBox txtAlteDrepturiNet;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator19;
		protected System.Web.UI.HtmlControls.HtmlTableRow tdIndexare;
		protected System.Web.UI.WebControls.CheckBox indexareCheckBox;
		private string actionInitializareLuna = "";
		private bool performIndexing;
		#endregion
		
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			SeteazaCampuriInvizibile();

			Salaries.Business.Luni l = new Salaries.Business.Luni(this.GetAngajator(), this.GetCurrentMonth());
			this.SelectedDate = l.Data;
			
			if(IsPostBack)
			{
				//performIndexing = this.indexareCheckBox.Checked;
				performIndexing = !tdIndexare.Disabled && indexareCheckBox.Checked;
			}

				/*
				* Adaugat:   Cristina Raluca Mutean
				* Data:      29.12.2005
				* Descriere: Seteaza vizibil sau nu randul corespunzator controalelor legate de indexare
				* in functie de luna activa.
				*/
				/*if (( this.SelectedDate.Month == LUNA_INDEXARE_1 ) || ( this.SelectedDate.Month == LUNA_INDEXARE_2 ))
				{
					tdIndexare.Disabled = false;
					indexareCheckBox.Checked = true;
				}
				else
				{
					tdIndexare.Disabled = true;
					indexareCheckBox.Checked = false;
				}*/


			//daca este luna de executare a indexarii
			if (( this.SelectedDate.Month == LUNA_INDEXARE_1 ) || ( this.SelectedDate.Month == LUNA_INDEXARE_2 ))
			{
				//se calculeaza salariul indexat al unui angajat
				float venitBrutIndexat = 0;
				Salaries.Business.Angajat objAngajat = new Salaries.Business.Angajat();
				Salaries.Business.Salariu salariu = new Salaries.Business.Salariu();
				DataSet ds = objAngajat.GetAngajatIDAll();
				if (ds.Tables[0].Rows.Count > 0)
				{
					salariu.AngajatID = int.Parse(ds.Tables[0].Rows[0]["AngajatId"].ToString());
					objAngajat.AngajatId = int.Parse(ds.Tables[0].Rows[0]["AngajatId"].ToString());
					objAngajat.LoadAngajat();
					venitBrutIndexat = salariu.CalculVenitBrutIndexat();
				}
		
				//daca nu a fost executata deja indexarea, adica salariu curent este egal cu cel indexat
				if (decimal.Parse(venitBrutIndexat.ToString()) != objAngajat.SalariuBaza)
				{
					//se seteaza campul pentru efectuarea indexarii ca fiind activ
					tdIndexare.Disabled = false;
					//indexareCheckBox.Checked = true;
				}
				//a fost deja executata o indexare, nu se va mai realiza alta indexare
				else
				{
					tdIndexare.Disabled = true;
					//indexareCheckBox.Checked = false;
				}
				indexareCheckBox.Checked = true;
			}
			//nu este luna de indexare
			else
			{
				tdIndexare.Disabled = true;
				indexareCheckBox.Checked = false;
			}
		}

		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			Salaries.Business.Luni l = new Salaries.Business.Luni(this.GetAngajator(), this.GetCurrentMonth());
			this.SelectedDate = l.Data;
				
			this.SaveSessionKey( Definitions.SelectedDateKEY, this.SelectedDate );
			
			if (!IsPostBack)
			{
			
				//selecteaza primul element din luna
				Salaries.Business.CategoriiAngajat ca = new Salaries.Business.CategoriiAngajat();
							
				lstCategorii.DataSource = ca.GetCategoriiAngajat(this.GetCurrentMonth());
				lstCategorii.DataTextField="Denumire";
				lstCategorii.DataValueField="CategorieID";
				lstCategorii.DataBind();
				lstCategorii.Items.Insert(0,new ListItem("[toate]","-1"));
			}
			else
			{
				if( ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ListaCategoriiValue" )).Value != "" )
				{
					TransferaValoriInEditboxuri();
				}
			}
			string script_text = "<script>var ctrlID = \""+this.ClientID+"\"</script>";
			Response.Write(script_text);

			actionInitializareLuna = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ActionInitializareLunaValoare" )).Value;

			FillCampuriPosibile();

			HandleActions();
		}

		#endregion

		#region Render
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render( writer );

			Response.Write( "<script>var ListaCategoriiDDL = '"+this.lstCategorii.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrZileLunaClient = '"+this.txtNrZileLuna.ClientID+"';</script>" );
			Response.Write( "<script>var TxtAlteDrepturiClient = '"+this.txtAlteDrepturi.ClientID+"';</script>" );
			Response.Write( "<script>var TxtAlteDrepturiNetClient = '"+this.txtAlteDrepturiNet.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreConcediuBoalaClient = '"+this.txtNrOreConcediuBoala.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreConcediuOdihnaClient = '"+this.txtNrOreConcediuOdihna.ClientID+"';</script>" );

			Response.Write( "<script>var TxtNrOreEvenimDeosebClient = '"+this.txtNrOreEvenimDeoseb.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreInvoireClient = '"+this.txtNrOreInvoire.ClientID+"';</script>" );

			Response.Write( "<script>var TxtNrOreObligatiiCetatenestiClient = '"+this.txtNrOreObligatiiCetatenesti.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreAbsenteNemotivateClient = '"+this.txtNrOreAbsenteNemotivate.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreConcediuFaraPlataClient = '"+this.txtNrOreConcediuFaraPlata.ClientID+"';</script>" );

			Response.Write( "<script>var TxtNrOreLucrateClient = '"+this.txtNrOreLucrate.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreSup100ProcClient = '"+this.txtNrOreSup100Proc.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreSup50ProcClient = '"+this.txtNrOreSup50Proc.ClientID+"';</script>" );
			Response.Write( "<script>var TxtPrimeSpecialeClient = '"+this.txtPrimeSpeciale.ClientID+"';</script>" );
			Response.Write( "<script>var TxtSporActivitatiSupClient = '"+this.txtSporActivitatiSup.ClientID+"';</script>" );
			Response.Write( "<script>var TxtEmergencyServiceClient = '"+this.txtEmergencyService.ClientID+"';</script>" );

			Response.Write( "<script>var TxtAvansClient = '"+this.txtAvans.ClientID+"';</script>" );
			Response.Write( "<script>var TxtPrimaProiectClient = '"+this.txtPrimaProiect.ClientID+"';</script>" );

			//Add: Ionel Popa
			Response.Write( "<script>var TxtIndexareSalariiClient = '"+this.tdIndexare.ClientID/*this.indexareCheckBox.ClientID*/+"';</script>" );
			Response.Write( "<script>var indexareCheckBoxClient = '"+this.indexareCheckBox.ClientID+"';</script>" );
		}

		#endregion

		#region SeteazaCampuriInvizibile
		/// <summary>
		/// Seteaza campurile vizibile in functie de operatia executata
		/// </summary>
		private void SeteazaCampuriInvizibile()
		{
			txtNrZileLuna.ReadOnly = true;
			trNrOreLucrate.Style.Add( "display", "none" );
			trNrOreEvenimenteDeosebite.Style.Add( "display", "none" );
			trNrOreInvoire.Style.Add( "display", "none" );
			trNrOreConcediuOdihna.Style.Add( "display", "none" );
			trNrOreConcediuBoala.Style.Add( "display", "none" );
			trNrOreObligatiiCetatenesti.Style.Add( "display", "none" );
			trNrOreAbsenteNemotivate.Style.Add( "display", "none" );
			trNrOreConcediuFaraPlata.Style.Add( "display", "none" );
		}

		#endregion

		#region FillCampuriPosibile
		/// <summary>
		/// Completeaza campurile care ar valori predefinite
		/// </summary>
		private void FillCampuriPosibile()
		{
			Salaries.Business.PontajAngajat pa = new Salaries.Business.PontajAngajat( -1 );
			int nrZileLucratoare = pa.GetNrZileLuna( this.GetCurrentMonth());
			int nrOreLucru = nrZileLucratoare * InterfataSalarii.Classes.Definitions.NrOreNormaStandard;

			this.txtNrZileLuna.Text = nrZileLucratoare.ToString();
			this.txtNrOreLucrate.Text = nrOreLucru.ToString();
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
 	
		#region ValidareDate
		/// <summary>
		/// Se face validarea datelor inanite de a initializa luna.
		/// </summary>
		/// <returns>Returneaza true daca datele sunt corecte si false altfel</returns>
		/// <remarks>
		/// Adaugat:		Oprescu Claudia
		/// </remarks>
		private bool ValidareDate()
		{
			//campurile trebuie completate obligatoriu
			if ((this.txtNrOreSup50Proc.Text == "") ||
				(this.txtNrOreSup100Proc.Text == "") ||
				(this.txtAlteDrepturi.Text == "") ||
				(this.txtAlteDrepturiNet.Text == "") ||
				(this.txtAvans.Text == "") ||
				(this.txtEmergencyService.Text == "") ||
				(this.txtPrimaProiect.Text == "") ||
				(this.txtPrimeSpeciale.Text == "") ||
				(this.txtSporActivitatiSup.Text == ""))
				return false;

			//campurile trebuie sa fie valori intregi
			Regex expresieInteger = new Regex(@"^[0-9][0-9]*");
			if (!expresieInteger.IsMatch(this.txtNrOreSup50Proc.Text))
				return false;
			if (!expresieInteger.IsMatch(this.txtNrOreSup100Proc.Text))
				return false;

			//campurile trebuie sa fie valori reale
			Regex expresieDouble = new Regex(@"^[0-9][0-9]*([.]|[,])*[0-9]*$");
			if (!expresieDouble.IsMatch(this.txtAlteDrepturi.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtAlteDrepturiNet.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtAvans.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtEmergencyService.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtPrimaProiect.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtPrimeSpeciale.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtSporActivitatiSup.Text))
				return false;
			return true;
		}
		#endregion

		#region TransferaValoriInEditboxuri
		/// <summary>
		/// Sunt completate contoalele cu valori corespunzatoare
		/// </summary>
		private void TransferaValoriInEditboxuri()
		{
			lstCategorii.SelectedValue = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ListaCategoriiValue" )).Value;
			txtNrZileLuna.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrZileLunaHidden" )).Value;
			txtAlteDrepturi.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAlteDrepturiHidden" )).Value;
			txtAlteDrepturiNet.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAlteDrepturiNetHidden" )).Value;
			txtNrOreConcediuBoala.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreConcediuBoalaHidden" )).Value;
			txtNrOreConcediuOdihna.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreConcediuOdihnaHidden" )).Value;
			txtNrOreEvenimDeoseb.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreEvenimDeosebHidden" )).Value;
			txtNrOreInvoire.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreInvoireHidden" )).Value;

			txtNrOreObligatiiCetatenesti.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreObligatiiCetatenestiHidden" )).Value;
			txtNrOreAbsenteNemotivate.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreAbsenteNemotivateHidden" )).Value;
			txtNrOreConcediuFaraPlata.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreConcediuFaraPlataHidden" )).Value;

			txtNrOreLucrate.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreLucrateHidden" )).Value;
			txtNrOreSup100Proc.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreSup100ProcHidden" )).Value;
			txtNrOreSup50Proc.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreSup50ProcHidden" )).Value;
			txtPrimeSpeciale.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtPrimeSpecialeHidden" )).Value;
			txtSporActivitatiSup.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtSporActivitatiSupHidden" )).Value;
			txtEmergencyService.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtEmergencyServiceHidden" )).Value;

			txtAvans.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAvansHidden" )).Value;
			txtPrimaProiect.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtPrimaProiectHidden" )).Value;

			//Added: Ionel Popa
			performIndexing = bool.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtPerformIndexingHidden" )).Value.ToString());

			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ListaCategoriiValue" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrZileLunaHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAlteDrepturiHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAlteDrepturiNetHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreConcediuBoalaHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreConcediuOdihnaHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreEvenimDeosebHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreInvoireHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreLucrateHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreSup100ProcHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreSup50ProcHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtPrimeSpecialeHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtSporActivitatiSupHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtEmergencyServiceHidden" )).Value = "";

			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAvansHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRegularizareHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtPrimaProiectHidden" )).Value = "";

			//Added: Ionel Popa
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtPerformIndexingHidden" )).Value = "";
		}
		#endregion

		#region HandleActions
		/// <summary>
		/// Executa operatia
		/// </summary>
		private void HandleActions()
		{
			switch( actionInitializareLuna )
			{
				case "initializareLuna":
					if (ValidareDate())
					{
						InitializareLunaClick();
						actionInitializareLuna = "";
						((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ActionInitializareLunaValoare" )).Value = "";
					}
					else
					{
						Response.Write("<script> alert('Trebuie sa completati corect campurile!'); </script>");
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region InitializareLunaClick
		/// <summary>
		/// Initializeaza luna
		/// </summary>
		private void InitializareLunaClick()
		{
			ErrHandler.MyErrHandler.WriteError("InitializareLuna.ascx - start - click_initializareLuna()");
			// Va contine salariile indexate ale angajatilor.
			DataSet dsSalariiIndexate = new DataSet();
			Salaries.Business.Luni luna = new Salaries.Business.Luni(this.GetAngajator());
			ArrayList categs = new ArrayList();

			/*
			 * Adaugat:		Oprescu Claudia
			 * Data:		24.04.2007
			 * Descriere:	Daca exista angajati carora le-a expirat contractul de munca, nu se permite initializarea lunii pentru care trebuie facuta indexarea
			 */
			if ( performIndexing && (( this.SelectedDate.Month == 4 ) || ( this.SelectedDate.Month == 10 )) )
			{
				Salaries.Business.Angajat angajati = new Salaries.Business.Angajat();
				Salaries.Business.IstoricSchimbareDateAngajat dataPosibilaIndexare = new Salaries.Business.IstoricSchimbareDateAngajat();
				dataPosibilaIndexare.DataStart = luna.GetLunaActiva().Data;
				while (dataPosibilaIndexare.DataEsteZiSarbatoare())
				{
					dataPosibilaIndexare.DataStart = dataPosibilaIndexare.DataStart.AddDays(1);
				}
				DataSet dsAngajatiExpiraContract = angajati.GetAngajatiExpiraContractLunaCurenta(dataPosibilaIndexare.DataStart);
				if (dsAngajatiExpiraContract.Tables[0].Rows.Count != 0)
				{
					Response.Write("<script> alert('Exista angajati carora le-a expirat contractul de munca, adica data de sfarsit a contractului este mai mica decat prima zi lucratoare a lunii curente. \\nPentru a vizualiza acesti angajati, accesati modulul Home al aplicatiei. \\nVa rugam actualizati data de sfarsit a contractului pentru acesti angajati pentru a se putea efectua indexarea. \\nVa multumim!'); </script>");
					return;
				}
			}

			InitializeOreLucrateLunaAngajati();
		
			if (this.lstCategorii.SelectedIndex==0)
			{
				for (int i=1;i<this.lstCategorii.Items.Count;i++) 
				{
					categs.Add(int.Parse(this.lstCategorii.Items[i].Value));
				}
			} 
			else 
			{
				categs.Add(this.lstCategorii.SelectedValue);
			}
			
			/*
			* Adaugat:  Muntean Raluca Cristina
			* Data:     29.12.2005
			* Descriere:Sunt calculate salariile indexate ale angajatilor
			* si introduce schimbarea in baza de date. 
			* 
			* Modificat: 
			*		- Ionel Popa - 18.12.2006: indexarea se face o data la sase luni: aprilie si octombrie
			*/
			if (performIndexing && (( this.SelectedDate.Month == 4 ) || ( this.SelectedDate.Month == 10 )))
			{
				ErrHandler.MyErrHandler.WriteError("InitializareLuna.ascx - click_initializareLuna() - start - indexare");
				//a fost exectuata indexare si campul pentru specificarea indexarii este inactiv
				tdIndexare.Disabled = true;
				indexareCheckBox.Checked = true;
	
				ErrHandler.MyErrHandler.WriteError("InitializareLuna.ascx - click_initializareLuna() - start - calcul salarii indexate");
				dsSalariiIndexate = luna.CalculSalariiIndexate(this.GetAngajator());
				ErrHandler.MyErrHandler.WriteError("InitializareLuna.ascx - click_initializareLuna() - end - calcul salarii indexate");

				Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
				Salaries.Business.IstoricSchimbareDateAngajat isda;
				Salaries.Data.LunaData lunaActiva = luna.GetLunaActiva();
				string dataLunaActiva = lunaActiva.Data.ToShortDateString();

				//Se creaza noul interval de schimbari:
				//Va contine ca data de start inceputul lunii si ca data de sfarsit DataTime.MaxValue 
				Salaries.Business.IstoricSchimbareDateAngajat intsch = new Salaries.Business.IstoricSchimbareDateAngajat();
				intsch.DataEnd = DateTime.MaxValue;
				intsch.DataStart = DateTime.Parse(dataLunaActiva );
				//se stabileste data de inceput a schimbarii
				//daca este o zi de sarbatoare, se va lua data urmatoare
				while (intsch.DataEsteZiSarbatoare())
				{
					intsch.DataStart = intsch.DataStart.AddDays(1);
				}

				Salaries.Business.IstoricSchimbareDateAngajat interv;
				//Un angajat poate avea cel putin un interval care se termina inaintea datei de inceput a intervalului de schimbare
				//In acest caz retinem acest interval
				//Salaries.Business.IstoricSchimbareDateAngajat possibleLastInterval;
		
				ErrHandler.MyErrHandler.WriteError("InitializareLuna.ascx - click_initializareLuna() - start - schimbare date angajat(sal indexat)");
				foreach ( DataRow angajatRow in dsSalariiIndexate.Tables[0].Rows )
				{
					ang.AngajatId = long.Parse(angajatRow["AngajatID"].ToString());
					ang.LoadAngajat();
			
					//Se initializeaza schimbarile angajatului 
					isda = new Salaries.Business.IstoricSchimbareDateAngajat();
					isda.AngajatId = ang.AngajatId;
					isda.DataStart = intsch.DataStart;
					intsch.AngajatId = ang.AngajatId;
				
					if ( !ang.IsLichidat )
					{
						interv = new Salaries.Business.IstoricSchimbareDateAngajat();
						DataSet existaCapat = new DataSet();

						//Se verifica daca data de angajare este diferita de inceputul intervalului de schimbare
						//In cazul in care sunt egale ... nu se face indexarea
						/*if(ang.DataDeLa != intsch.DataStart)
						{						
							//Se extrage intervalul precedent intervalului de schimbare
							isda.DataStart = intsch.DataStart.AddDays( -1 );
							interv = isda.GetIntervalSchimbareByDataInside();
							//In cazul in care angajatul a fost angajat pe o perioada determinata e posibil sa nu existe un interval care sa includa aceasta data
							if( interv.ProgramLucru == -1)
							{
								interv = isda.GetLastIntervalSchimbare();
								//Se seteaza doar DataEnd pentru ca aceasta e necesara mai jos in InsertCapatIntervalSchimbareAngajat/UpdateCapatIntervalSchimbareAngajat
								interv.DataStart = intsch.DataStart.AddDays( -1 );
								//Initializam si acest interval
								possibleLastInterval = isda.GetLastIntervalSchimbare();
								possibleLastInterval.DataStart = intsch.DataStart.AddDays( -1 );
								isda.CategorieId = interv.CategorieId;
								possibleLastInterval.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();
							}
							else
							{
								isda.CategorieId = interv.CategorieId;
								interv.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();
								//Initializam si acest interval
								isda.DataStart = intsch.DataStart.AddDays( -1 );
								possibleLastInterval = isda.GetIntervalSchimbareByDataInside();
								isda.CategorieId = interv.CategorieId;
								possibleLastInterval.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();
							}

						
							//Se verifica daca data de start a intervalului de schimbare este capat de interval
							//Aceasta verificare este necesara pentru ca intervalele sa fie continue
							//De ex: in cazul in care exista un capat mai mic decat capatul de start al intervalului de schimbare acesta este actualizat cu capatul de start al intervalului de schimbare
							//!!Prin actiunea de mai jos se seteaza ca si capat de interval ultima zi a lunii precedente
							isda.DataStart = intsch.DataStart.AddDays( -1 );
							existaCapat = isda.GetCapatIntervalAngajatZi();
							if ( existaCapat == null || existaCapat.Tables[ 0 ].Rows.Count == 0 )
							{
								//Daca nu exista un capat de interval acesta va fi inserat
								interv.InsertCapatIntervalSchimbareAngajat();
							}
							else
							{
								//Daca exista un capat de interval acesta este actualizat
								interv.IntervalAngajatId = int.Parse( existaCapat.Tables[ 0 ].Rows[ 0 ][ "IntervalAngajatID" ].ToString());
								interv.UpdateCapatIntervalSchimbareAngajat();
							}

							//Se actulizeaza salariul de baza cu cel indexat 
							intsch.SalariuBaza = decimal.Parse( angajatRow["SalariuIndexat"].ToString() );
							//Se insereaza schimbarea pentru angajatul curent
							intsch.InsertSchimbareSalariuBaza();

							//Se seteaza ca si capat de interval inceputul lunii active
							isda.DataStart = intsch.DataStart;
							interv = isda.GetIntervalSchimbareByDataInside();
							if( interv.ProgramLucru == -1)
							{
								interv = possibleLastInterval;
								interv.DataStart = DateTime.Parse(dataLunaActiva );
							}					
							interv.SalariuBaza = intsch.SalariuBaza;
							isda.CategorieId = interv.CategorieId;
							interv.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();
					
							isda.DataStart = intsch.DataStart; 
							existaCapat = isda.GetCapatIntervalAngajatZi();
							if( existaCapat == null || existaCapat.Tables[ 0 ].Rows.Count == 0 )
							{
								interv.InsertCapatIntervalSchimbareAngajat();
							}
							else
							{
								interv.IntervalAngajatId = int.Parse( existaCapat.Tables[ 0 ].Rows[ 0 ][ "IntervalAngajatID" ].ToString());
								interv.UpdateCapatIntervalSchimbareAngajat();
							}
						}*/

						//Se verifica daca data de angajare este diferita de inceputul intervalului de schimbare
						//In cazul in care sunt egale ... nu se face indexarea
						if(ang.DataDeLa != intsch.DataStart)
						{
							//Se extrage intervalul precedent intervalului de schimbare
							isda.DataStart = intsch.DataStart.AddDays(-1);
							//daca este o zi de sarbatoare, se va trece la ziua anterioara pana se va gasi o zi care nu este sarbatoare
							while (isda.DataEsteZiSarbatoare())
							{
								isda.DataStart = isda.DataStart.AddDays(-1);
							}
							interv = isda.GetIntervalSchimbareByDataInside();
							isda.CategorieId = interv.CategorieId;
							interv.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();
						
							//Se verifica daca data de start a intervalului de schimbare este capat de interval
							//Aceasta verificare este necesara pentru ca intervalele sa fie continue
							//De ex: in cazul in care exista un capat mai mic decat capatul de start al intervalului de schimbare acesta este actualizat cu capatul de start al intervalului de schimbare
							//!!Prin actiunea de mai jos se seteaza ca si capat de interval ultima zi a lunii precedente
							isda.DataStart = intsch.DataStart.AddDays(-1);
							//daca este o zi de sarbatoare, se va trece la ziua anterioara pana se va gasi o zi care nu este sarbatoare
							while (isda.DataEsteZiSarbatoare())
							{
								isda.DataStart = isda.DataStart.AddDays(-1);
							}
							existaCapat = isda.GetCapatIntervalAngajatZi( );
							if( existaCapat == null || existaCapat.Tables[ 0 ].Rows.Count == 0 )
							{
								//Daca nu exista un capat de interval acesta va fi inserat
								interv.InsertCapatIntervalSchimbareAngajat();
							}
							else
							{
								//Daca exista un capat de interval acesta este actualizat
								interv.IntervalAngajatId = int.Parse( existaCapat.Tables[ 0 ].Rows[ 0 ][ "IntervalAngajatID" ].ToString());
								interv.UpdateCapatIntervalSchimbareAngajat();
							}
						}

						//Se actulizeaza salariul de baza cu cel indexat 
						intsch.SalariuBaza = decimal.Parse( angajatRow["SalariuIndexat"].ToString() );
						//Se insereaza schimbarea pentru angajatul curent
						intsch.InsertSchimbareSalariuBaza();

						//Se seteaza ca si capat de interval inceputul lunii active
						isda.DataStart = intsch.DataStart;
						interv = isda.GetIntervalSchimbareByDataInside();
						interv.SalariuBaza = intsch.SalariuBaza;
						isda.CategorieId = interv.CategorieId;
						interv.CategorieId = isda.GetCategorieCorspunzatoareDinLunaActiva();

						isda.DataStart = intsch.DataStart;
						existaCapat = isda.GetCapatIntervalAngajatZi();
						if( existaCapat == null || existaCapat.Tables[ 0 ].Rows.Count == 0 )
						{
							interv.InsertCapatIntervalSchimbareAngajat();
						}
						else
						{
							interv.IntervalAngajatId = int.Parse( existaCapat.Tables[ 0 ].Rows[ 0 ][ "IntervalAngajatID" ].ToString());
							interv.UpdateCapatIntervalSchimbareAngajat();
						}
					}
				}
				ErrHandler.MyErrHandler.WriteError("InitializareLuna.ascx - click_initializareLuna() - end - schimbare date angajat(sal indexat)");
				ErrHandler.MyErrHandler.WriteError("InitializareLuna.ascx - click_initializareLuna() - end - indexare");
			}

			ErrHandler.MyErrHandler.WriteError("InitializareLuna.ascx - click_initializareLuna() - start - adaugarea etichetelor asociate retinerilor");
			//Adaugat:		Oprescu Claudia
			//Descriere:	La initializarea fiecarei luni se adauga etichetele asociate acesteia
			Salaries.Business.TypesOfRestraints tr = new Salaries.Business.TypesOfRestraints();
			tr.InsertLabel(this.GetCurrentMonth());
			
			//Descriere:	Pentru fiecare angajat se adauga valori pentru retinerea din luna nou adaugata
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			DataSet angajatiID = angajat.GetAngajatIDAll();
			foreach (DataRow dr in angajatiID.Tables[0].Rows)
			{
				long AngajatID = long.Parse(dr["AngajatID"].ToString());
				Salaries.Business.TipuriRetineriValori trv = new Salaries.Business.TipuriRetineriValori();
				trv.InsertRetineriValori(this.GetCurrentMonth(), AngajatID);
			}
			ErrHandler.MyErrHandler.WriteError("InitializareLuna.ascx - click_initializareLuna() - end - adaugarea etichetelor asociate retinerilor");

			ErrHandler.MyErrHandler.WriteError("InitializareLuna.ascx - click_initializareLuna() - start - generare situatii lunare");
			for (int i=0;i<categs.Count;i++)	
			{
				int CategorieID = int.Parse(categs[i].ToString());

				DataSet CategorieAngajati = new Salaries.Business.CategoriiAngajat().GetCategorieAngajati(CategorieID);

				foreach (DataRow dr in CategorieAngajati.Tables[0].Rows)
				{
					long AngajatID = long.Parse(dr["AngajatID"].ToString());
				
					Salaries.Business.SituatieLunaraAngajat sla = new Salaries.Business.SituatieLunaraAngajat( AngajatID );
					sla.GenerareSituatieLunaraAngajat( this.GetCurrentMonth(), this.GetAngajator());

					//se adauga valorile retinerilor pentru un angajat dintr-o luna
					//Salaries.Business.TipuriRetineriValori().InsertRetineriValori(this.GetCurrentMonth(), this.GetAngajator());

					Salaries.Data.InfoSituatieLunara isl = sla.GetSituatieLunaraAngajat( AngajatID, this.GetCurrentMonth());
		
					//Salaries.Business.SituatieLunaraAngajat sla = new Salaries.Business.SituatieLunaraAngajat(AngajatID);
		
					Salaries.Data.InfoSituatieLunara x = new Salaries.Data.InfoSituatieLunara();
						
					x.SituatieID = -1;
					x.AngajatID = AngajatID;
					x.LunaID = this.GetCurrentMonth();
					x.NrZileLuna = isl.NrZileLuna;
					x.NrOreConcediuBoala = isl.NrOreConcediuBoala;
					x.NrOreConcediuOdihna = isl.NrOreConcediuOdihna;
					x.NrOreEvenimDeoseb = isl.NrOreEvenimDeoseb;
					x.NrOreInvoire = isl.NrOreInvoire;
					x.NrOreObligatiiCetatenesti = isl.NrOreObligatiiCetatenesti;
					x.NrOreAbsenteNemotivate = isl.NrOreAbsenteNemotivate;
					x.NrOreConcediuFaraPlata = isl.NrOreConcediuFaraPlata;
					x.NrOreLucrate = isl.NrOreLucrate;
					//x.NrOreSup100Proc = isl.NrOreSup100Proc;
					//x.NrOreSup50Proc = isl.NrOreSup50Proc;
					x.NrOreSup100Proc = int.Parse(this.txtNrOreSup100Proc.Text);
					x.NrOreSup50Proc = int.Parse(this.txtNrOreSup50Proc.Text);

					x.PrimeSpeciale = decimal.Parse(this.txtPrimeSpeciale.Text);
					x.SporActivitatiSup = decimal.Parse(this.txtSporActivitatiSup.Text);
					x.EmergencyService = decimal.Parse(this.txtEmergencyService.Text);
					x.AlteDrepturi = decimal.Parse(this.txtAlteDrepturi.Text);
					x.AlteDrepturiNet = decimal.Parse(this.txtAlteDrepturiNet.Text);
					x.Avans = decimal.Parse(this.txtAvans.Text);
					x.PrimaProiect = decimal.Parse(this.txtPrimaProiect.Text);

					//se calculeaza suma pe care trebuie sa o plateasca cei scutiti de contributia la sanatate
					int lunaID = this.GetCurrentMonth();
					x.RetinereSanatate = 0;
					x.CategorieID = CategorieID;	

					sla.AddSituatieLunaraAngajat(x, true);

					//distribuie orele suplimentare
					//ore 100%
					lunaID = this.GetCurrentMonth();
					Salaries.Business.Luni l = new Salaries.Business.Luni( this.GetAngajator());
					Salaries.Data.LunaData ld = l.GetDetalii( lunaID );
					int tipIntervalID = new SiemensTM.Classes.IntervaleAngajat( AngajatID ).GetTipIntervalIDByName( Salaries.Business.SituatieLunaraAngajat.denumireOreLucrate[ 1 ] );;
					int valEroare = new SiemensTM.Classes.IntervaleAngajat( AngajatID ).DistribuieOreSuplimentareTip( ld.Data, tipIntervalID, x.NrOreSup50Proc, 0, 0 );

					/*if ( valEroare == 1 )
					{
						Response.Write( "<script>alert( 'Numarul de ore suplimentare 100% depaseste numarul de ore disponibile!' );</script>" );
					}*/
			
					//ore 200%
					tipIntervalID = new SiemensTM.Classes.IntervaleAngajat( AngajatID ).GetTipIntervalIDByName( Salaries.Business.SituatieLunaraAngajat.denumireOreLucrate[ 2 ] );;
					valEroare = new SiemensTM.Classes.IntervaleAngajat( AngajatID ).DistribuieOreSuplimentareTip( ld.Data, tipIntervalID, x.NrOreSup100Proc, 0, 1 );
					
					//Reportare
					sla.ReporteazaDiferentaCorectiTichete(lunaID);
					sla.GenerareSituatieLunaraAngajat( this.GetCurrentMonth(), this.GetAngajator());
				
					/*if ( valEroare == 1 )
					{
						Response.Write( "<script>alert( 'Numarul de ore suplimentare 200% depaseste numarul de ore disponibile!' );</script>" );
					}*/
				}
			}
			ErrHandler.MyErrHandler.WriteError("InitializareLuna.ascx - click_initializareLuna() - end - generare situatii lunare");
			ErrHandler.MyErrHandler.WriteError("InitializareLuna.ascx - end - click_initializareLuna()");
		}
		#endregion

		#region InitializeOreLucrateLunaAngajati
		/// <summary>
		/// Initializeaza ore lucrate ale unui angajat
		/// </summary>
		private void InitializeOreLucrateLunaAngajati()
		{
			ErrHandler.MyErrHandler.WriteError("InitializareLuna.ascx - start - initializeOreLucrateLuna()");
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.CategorieId = int.Parse( lstCategorii.SelectedValue );
			angajat.AngajatorId = GetAngajator();
			//Modificat:Muntean Raluca Cristina  - am adaugat ca parametru si id-ul angajatorului
			DataSet ds = angajat.GetAllAngajati();

			foreach( DataRow dr in ds.Tables[ 0 ].Rows )
			{
				IntervaleAngajat ia = new IntervaleAngajat( long.Parse( dr[ "AngajatID" ].ToString()));
				//Modified: Ionel Popa
				//Description: In loc de DataPanaLa se transmite DataLichidare ( pentru ca e posibil ca prelungirea contractului sa se faca mai greu )
				ia.InitializeOreLucrateLunaAngajat( this.SelectedDate, (DateTime)dr[ "DataDeLa" ], dr[ "DataLichidare" ] );
			}
			ErrHandler.MyErrHandler.WriteError("InitializareLuna.ascx - end - initializeOreLucrateLuna()");
		}
		#endregion
	}
}
