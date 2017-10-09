/*
* Modificat:	Fratila Claudia
* Data:			03.12.2007
* Descriere:	In situatia lunara a unui angajat se poate specifica o alta suma pentru retinerea pentru sanatate.
				Daca nu a fost specificata nici o valoare, atunci se va calcula valoarea implicita.
*/

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

using SiemensHR.utils;
using SiemensHR.Classes;
using Salaries.Business;

namespace SiemensHR.InterfataSalarii
{
	/// <summary>
	///		Summary description for Coeficienti.
	/// </summary>
	public class SituatieLunaraAngajat : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator2;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator3;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator4;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator5;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator6;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator7;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator8;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator9;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator10;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator18;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox txtNrOreEvenimDeoseb;
		protected System.Web.UI.WebControls.TextBox txtNrOreInvoire;
		protected System.Web.UI.WebControls.TextBox txtNrOreConcediuOdihna;
		protected System.Web.UI.WebControls.TextBox txtNrOreConcediuBoala;
		protected System.Web.UI.WebControls.TextBox txtEmergencyService;
		protected System.Web.UI.WebControls.TextBox txtPrimeSpeciale;
		protected System.Web.UI.WebControls.TextBox txtNrOreLucrate;
		protected System.Web.UI.WebControls.TextBox txtNrOreSup50Proc;
		protected System.Web.UI.WebControls.TextBox txtNrOreSup100Proc;
		protected System.Web.UI.WebControls.TextBox txtSporActivitatiSup;
		protected System.Web.UI.WebControls.TextBox txtNrZileLuna;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator11;
		protected System.Web.UI.WebControls.Label txtCategorie;
		protected System.Web.UI.HtmlControls.HtmlTableCell LunaContainer;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtSituatieID;
		protected System.Web.UI.WebControls.TextBox txtNrOreObligatiiCetatenesti;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator12;
		protected System.Web.UI.WebControls.TextBox txtNrOreAbsenteNemotivate;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator13;
		protected System.Web.UI.WebControls.TextBox txtNrOreConcediuFaraPlata;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator14;
		protected System.Web.UI.HtmlControls.HtmlInputButton buttonAdaugaSituatie;
		protected System.Web.UI.HtmlControls.HtmlInputButton buttonModificaSituatia;
		protected System.Web.UI.HtmlControls.HtmlInputButton buttonStergeSituatia;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActiv;
		protected System.Web.UI.WebControls.TextBox txtAvans;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator15;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator16;
		protected System.Web.UI.WebControls.TextBox txtPrimaProiect;
		protected System.Web.UI.WebControls.TextBox txtRetinereSanatate;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator17;

		public string actionSituatieLunaraAngajat = "";
		private string SituatieID = "";
		protected string NrZileLuna = "";
		protected string AlteDrepturi = "";
		protected string AlteDrepturiNet = "";
		protected string AjutorDeces = "";
		protected string NrOreConcediuBoala = "";
		protected string NrOreConcediuOdihna = "";
		protected string NrZileConcediuOdihnaNeefectuat = "";
		protected string NrZileConcediuOdihnaEfectInAvans = "";
		protected string NrOreEvenimenteDeosebite = "";
		protected string NrOreInvoire = "";
		protected string NrOreObligatiiCetatenesti = "";
		protected string NrOreAbsenteNemotivate = "";
		protected string NrOreConcediuFaraPlata = "";
		protected string NrOreLucrate = "";
		protected string NrOreSup100Proc = "";
		protected string NrOreSup50Proc = "";
		protected string PrimeSpeciale = "";
		protected string SporActivitatiSup = "";
		protected string EmergencyServices = "";

		protected string Avans = "";
		protected string Retinere1 = "";
		protected string Retinere2 = "";
		protected string Retinere3 = "";
		protected string Retinere4 = "";
		protected string Retinere5 = "";
		protected string Retinere6 = "";
		protected string Retinere7 = "";
		protected string Regularizare = "";
		protected string PrimaProiect = "";
		protected string RetinereSanatate = "";
		protected string DrepturiInNatura = "";

		protected string NrOreLucrateDelegatieInterna = "";
		protected string NrOreLucrateDelegatieExterna = "";
		protected string DiurnaImpozabila = "";
		protected string NrTichete = "";
		protected string CorectiiTichete = "";

		protected bool lichidat = false;
		protected System.Web.UI.WebControls.TextBox txtAlteDrepturiNet;
		protected System.Web.UI.WebControls.TextBox txtAlteDrepturi;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator19;
		protected System.Web.UI.WebControls.TextBox txtAjutorDeces;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator20;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator21;
		protected System.Web.UI.WebControls.TextBox txtRegularizare;
		protected System.Web.UI.WebControls.TextBox txtNrZileCOneefectuat;
		protected System.Web.UI.WebControls.RangeValidator vldNrZileCOneefectuat;
		protected System.Web.UI.WebControls.TextBox txtNrZileCOefectInAvans;
		protected System.Web.UI.WebControls.RangeValidator vldNrZileCOefectInAvans;
		protected System.Web.UI.WebControls.TextBox txtMedieZilnicaCO;
		protected System.Web.UI.WebControls.TextBox txtRetineri1;
		protected System.Web.UI.WebControls.TextBox txtRetineri2;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator22;
		protected System.Web.UI.WebControls.TextBox txtRetineri3;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator23;
		protected System.Web.UI.WebControls.TextBox txtRetineri4;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator24;
		protected System.Web.UI.WebControls.TextBox txtRetineri5;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator25;
		protected System.Web.UI.WebControls.TextBox txtRetineri6;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator26;
		protected System.Web.UI.WebControls.TextBox txtRetineri7;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator27;
		protected System.Web.UI.WebControls.Label lblRetineri1;
		protected System.Web.UI.WebControls.Label lblRetineri2;
		protected System.Web.UI.WebControls.Label lblRetineri3;
		protected System.Web.UI.WebControls.Label lblRetineri4;
		protected System.Web.UI.WebControls.Label lblRetineri5;
		protected System.Web.UI.WebControls.Label lblRetineri6;
		protected System.Web.UI.WebControls.Label lblRetineri7;
		protected System.Web.UI.HtmlControls.HtmlTableRow trRetineri1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trRetineri2;
		protected System.Web.UI.HtmlControls.HtmlTableRow trRetineri3;
		protected System.Web.UI.HtmlControls.HtmlTableRow trRetineri4;
		protected System.Web.UI.HtmlControls.HtmlTableRow trRetineri5;
		protected System.Web.UI.HtmlControls.HtmlTableRow trRetineri6;
		protected System.Web.UI.HtmlControls.HtmlTableRow trRetineri7;
		protected System.Web.UI.HtmlControls.HtmlTableRow trSeparator1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trSeparator2;
		protected System.Web.UI.HtmlControls.HtmlTableRow trSeparator3;
		protected System.Web.UI.HtmlControls.HtmlTableRow trSeparator4;
		protected System.Web.UI.HtmlControls.HtmlTableRow trSeparator5;
		protected System.Web.UI.HtmlControls.HtmlTableRow trSeparator6;
		protected System.Web.UI.HtmlControls.HtmlTableRow trSeparator7;
		protected System.Web.UI.WebControls.RangeValidator vldProc;
		protected System.Web.UI.WebControls.TextBox t;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator28;
		protected System.Web.UI.WebControls.TextBox txtNrTichete;
		protected System.Web.UI.WebControls.TextBox txtCorectiiTichete;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator30;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator31;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator29;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator32;
		protected System.Web.UI.WebControls.TextBox txtNrOreLucrateDelegatieInterna;
		protected System.Web.UI.WebControls.TextBox txtNrOreLucrateDelegatieExterna;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator33;
		protected System.Web.UI.WebControls.TextBox txtDrepturiInNatura;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator34;
		protected System.Web.UI.WebControls.TextBox txtDiurnaImpozabila;
		protected System.Web.UI.HtmlControls.HtmlInputButton modifica;
		#endregion

		#region Page_Load(object sender, System.EventArgs e)
		private void Page_Load(object sender, System.EventArgs e)
		{			
			SeteazaCampuriReadOnly();			
		}
		#endregion

		#region OnPreRender(EventArgs e)
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.AngajatId = GetAngajat();
			angajat.LoadAngajat();
			
			lichidat = angajat.IsLichidat;

			actionSituatieLunaraAngajat = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "actionSituatieLunaraAngajatValue" )).Value;

			this.HandleAction();

			this.buttonAdaugaSituatie.Visible = new Luni(this.GetAngajator()).GetLunaActiva().LunaId!=-1;

			AdminSalariiCategoriiAngajati ca = new AdminSalariiCategoriiAngajati();
			ca.CategorieId = angajat.CategorieId;
			this.txtCategorie.Text = ca.GetCategorieDenumire();
		
			string script_text = "<script>var ctrlID = \""+this.ClientID+"\"</script>";
			Response.Write(script_text);
	
			buttonStergeSituatia.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti situatia?')");
		
			string[] textTabs = {"Lista situatii lunare"};
			
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "../", true);
			if (!IsPostBack)
			{
				Salaries.Data.LunaData ldActiva = new Salaries.Business.Luni(this.GetAngajator()).GetLunaActiva();				
				if (ldActiva.LunaId==-1)
				
				{
					this.LunaContainer.InnerHtml = " Nu exista luni active definite in sistem pt angajatorul curent!";
				}
			}

			//Adaugat:		Oprescu Claudia
			//Descriere:	Se apeleaza metoda pentru generarea situatiei lunare inainte de a se completa tabelul		
			SiemensTM.Classes.SituatieAngajat situatieLunaraAng;
			long angajatId = this.GetAngajat();
			situatieLunaraAng = new SiemensTM.Classes.SituatieAngajat(angajatId);
			/*if (angajat.isLichidat)
			{
				situatieLunaraAng.GenerareSituatieLunaraAngajatLichidat();
			}
			else
			{*/
				situatieLunaraAng.GenerareSituatieLunaraAngajat();
			//}
			this.LoadSituatiiList();

			//Lungu Andreea - 08.04.2010
			int idAngajat = (int)angajat.AngajatId;
			Salaries.Business.Luni luni = new Salaries.Business.Luni( angajat.AngajatorId );
			Salaries.Data.LunaData lunaData = luni.GetLunaActiva();
			int lunaID = lunaData.LunaId;
			DateTime dataStartLunaActiva = lunaData.Data;
			DateTime dataEndLunaActiva =  dataStartLunaActiva.AddMonths(1).AddDays(-1);

			Salaries.Configuration.ModuleSettings settings = Salaries.Configuration.ModuleConfig.GetSettings();
			Salaries.Data.RetineriRecurenteAngajat retineri = new Salaries.Data.RetineriRecurenteAngajat(settings.ConnectionString);
			if (retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_1",dataStartLunaActiva, dataEndLunaActiva) != 0)
			{
				txtRetineri1.ReadOnly = true;
				lblRetineri1.Text += " (retinere pe o anumita perioada) ";
			}
			if (retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_2",dataStartLunaActiva, dataEndLunaActiva) != 0)
			{
				txtRetineri2.ReadOnly = true;
				lblRetineri2.Text += " (retinere pe o anumita perioada) ";
			}
			if (retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_3",dataStartLunaActiva, dataEndLunaActiva) != 0)
			{
				txtRetineri3.ReadOnly = true;
				lblRetineri3.Text += " (retinere pe o anumita perioada) ";
			}
			if (retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_4",dataStartLunaActiva, dataEndLunaActiva) != 0)
			{
				txtRetineri4.ReadOnly = true;
				lblRetineri4.Text += " (retinere pe o anumita perioada) ";
			}
			if (retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_5",dataStartLunaActiva, dataEndLunaActiva) != 0)
			{
				txtRetineri5.ReadOnly = true;
				lblRetineri5.Text += " (retinere pe o anumita perioada) ";
			}
			if (retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_6",dataStartLunaActiva, dataEndLunaActiva) != 0)
			{
				txtRetineri6.ReadOnly = true;
				lblRetineri6.Text += " (retinere pe o anumita perioada) ";
			}
			if (retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_7",dataStartLunaActiva, dataEndLunaActiva) != 0)
			{
				txtRetineri7.ReadOnly = true;
				lblRetineri7.Text += " (retinere pe o anumita perioada) ";
			}
		}
		#endregion

		#region Render
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render (writer);
			
			Response.Write( "<script>var TxtSituatieIDClient = '"+this.txtSituatieID.ClientID+"';</script>" );

			Response.Write( "<script>var TxtNrZileLunaClient = '"+this.txtNrZileLuna.ClientID+"';</script>" );
			Response.Write( "<script>var TxtAlteDrepturiClient = '"+this.txtAlteDrepturi.ClientID+"';</script>" );
			Response.Write( "<script>var TxtAlteDrepturiNetClient = '"+this.txtAlteDrepturiNet.ClientID+"';</script>" );
			Response.Write( "<script>var TxtAjutorDecesClient = '"+this.txtAjutorDeces.ClientID+"';</script>" );
			
			Response.Write( "<script>var TxtNrOreConcediuBoalaClient = '"+this.txtNrOreConcediuBoala.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreConcediuOdihnaClient = '"+this.txtNrOreConcediuOdihna.ClientID+"';</script>" );

			Response.Write( "<script>var TxtNrZileCOefectInAvansClient = '"+this.txtNrZileCOefectInAvans.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrZileCONeefectuatClient = '"+this.txtNrZileCOneefectuat.ClientID+"';</script>" );

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

			//Adaugat:		Oprescu Claudia	
			//Descriere:	S-au adaugat controalele pentru cele 7 retineri
			Response.Write( "<script>var TxtAvansClient = '"+this.txtAvans.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetineriClient1 = '"+this.txtRetineri1.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetineriClient2 = '"+this.txtRetineri2.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetineriClient3 = '"+this.txtRetineri3.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetineriClient4 = '"+this.txtRetineri4.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetineriClient5 = '"+this.txtRetineri5.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetineriClient6 = '"+this.txtRetineri6.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetineriClient7 = '"+this.txtRetineri7.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRegularizareClient = '"+this.txtRegularizare.ClientID+"';</script>" );
			Response.Write( "<script>var TxtPrimaProiectClient = '"+this.txtPrimaProiect.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetinereSanatateClient = '"+this.txtRetinereSanatate.ClientID+"';</script>" );
			
			//Lungu Andreea
			Response.Write( "<script>var TxtNrOreLucrateDelegatieInternaClient = '"+this.txtNrOreLucrateDelegatieInterna.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreLucrateDelegatieExternaClient = '"+this.txtNrOreLucrateDelegatieExterna.ClientID+"';</script>" );
			Response.Write( "<script>var TxtDiurnaImpozabilaClient = '"+this.txtDiurnaImpozabila.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrTicheteClient = '"+this.txtNrTichete.ClientID+"';</script>" );
			Response.Write( "<script>var TxtCorectiiTicheteClient = '"+this.txtCorectiiTichete.ClientID+"';</script>" );		
			Response.Write( "<script>var TxtDrepturiInNaturaClient = '"+this.txtDrepturiInNatura.ClientID+"';</script>" );
		}
		#endregion

		#region SeteazaCampuriReadOnly
		/// <summary>
		/// Seteaza campurile ale caror valori nu pot fi modificate
		/// </summary>
		private void SeteazaCampuriReadOnly()
		{
			txtNrZileLuna.ReadOnly = true;
			txtNrOreLucrate.ReadOnly = true;
			txtNrOreEvenimDeoseb.ReadOnly = true;
			txtNrOreInvoire.ReadOnly = true;
			txtNrOreConcediuOdihna.ReadOnly = true;
			txtNrOreConcediuBoala.ReadOnly = true;
			txtNrOreObligatiiCetatenesti.ReadOnly = true;
			txtNrOreAbsenteNemotivate.ReadOnly = true;
			txtNrOreConcediuFaraPlata.ReadOnly = true;
			txtNrTichete.ReadOnly = true;
			txtNrOreLucrateDelegatieInterna.ReadOnly = true;
			txtNrOreLucrateDelegatieExterna.ReadOnly = true;
		}
		#endregion

		#region HandleAction
		/// <summary>
		/// Executa actiunea
		/// </summary>
		private void HandleAction()
		{
			TransferDateInControaleLocale();

			switch( actionSituatieLunaraAngajat )
			{
				case "adaugaSituatieLunaraAngajat":
					buttonAdaugaSituatieClick();
					break;
				case "modificaSituatieLunaraAngajat":
					//se retine ca s-a facut modificarea situatiei lunare
					Session["ModificaSituatie"] = "modificareSituatie";
					buttonModificaSituatieClick();
					Session["ModificaSituatie"] = "";
					break;
				case "stergeSituatieLunaraAngajat":
					buttonStergeSituatieClick();
					break;
				default:
					break;
			}

			actionSituatieLunaraAngajat = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "actionSituatieLunaraAngajatValue" )).Value = "";
		}
		#endregion

		#region TransferDateInControaleLocale
		/// <summary>
		/// Completeaza campurile situatiei lunare cu datele existente
		/// </summary>
		private void TransferDateInControaleLocale()
		{
			//Adagat:		Oprescu Claudia
			//Descriere:	Se preiau valorile etichetelor. Pentru cele care au valori diferite de stringurile vide
			//				se afiseaza liniile din tabel care contin controalele pentru etichetele respective
			Salaries.Data.LunaData ldActiva = new Salaries.Business.Luni(this.GetAngajator()).GetLunaActiva();
			TypesOfRestraints tip = new TypesOfRestraints();
			DataSet ds = tip.GetLabels(ldActiva.LunaId);
			if (ds.Tables[0].Rows[0]["Eticheta"].ToString() != "")
			{
				//Se afiseaza label-ul care contine numele retinerii
				lblRetineri1.Text = ds.Tables[0].Rows[0]["Eticheta"].ToString();
				//Se afiseaza linia care contine controalele
				trRetineri1.Style.Add("display", "");
				//Se afiseaza separatorul liniilor
				trSeparator1.Style.Add("display", "");
			}
			if (ds.Tables[0].Rows[1]["Eticheta"].ToString() != "")
			{
				lblRetineri2.Text = ds.Tables[0].Rows[1]["Eticheta"].ToString();
				trRetineri2.Style.Add("display", "");
				trSeparator2.Style.Add("display", "");
			}
			if (ds.Tables[0].Rows[2]["Eticheta"].ToString() != "")
			{
				lblRetineri3.Text = ds.Tables[0].Rows[2]["Eticheta"].ToString();
				trRetineri3.Style.Add("display", "");
				trSeparator3.Style.Add("display", "");
			}
			if (ds.Tables[0].Rows[3]["Eticheta"].ToString() != "")
			{
				lblRetineri4.Text = ds.Tables[0].Rows[3]["Eticheta"].ToString();
				trRetineri4.Style.Add("display", "");
				trSeparator4.Style.Add("display", "");
			}
			if (ds.Tables[0].Rows[4]["Eticheta"].ToString() != "")
			{
				lblRetineri5.Text = ds.Tables[0].Rows[4]["Eticheta"].ToString();
				trRetineri5.Style.Add("display", "");
				trSeparator5.Style.Add("display", "");
			}
			if (ds.Tables[0].Rows[5]["Eticheta"].ToString() != "")
			{
				lblRetineri6.Text = ds.Tables[0].Rows[5]["Eticheta"].ToString();
				trRetineri6.Style.Add("display", "");
				trSeparator6.Style.Add("display", "");
			}
			if (ds.Tables[0].Rows[6]["Eticheta"].ToString() != "")
			{
				lblRetineri7.Text = ds.Tables[0].Rows[6]["Eticheta"].ToString();
				trRetineri7.Style.Add("display", "");
				trSeparator7.Style.Add("display", "");
			}
			
			txtNrZileLuna.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrZileLunaHidden" )).Value;
			txtAlteDrepturi.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAlteDrepturiHidden" )).Value;
			txtAlteDrepturiNet.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAlteDrepturiNetHidden" )).Value;
			txtAjutorDeces.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAjutorDecesHidden" )).Value;
			txtNrOreConcediuBoala.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreConcediuBoalaHidden" )).Value;
			txtNrOreConcediuOdihna.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreConcediuOdihnaHidden" )).Value;
			
			if (lichidat)
			{
				txtNrZileCOneefectuat.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrZileCOneefectuatHidden" )).Value;
				txtNrZileCOefectInAvans.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrZileCOefectInAvansHidden" )).Value;
			}

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
			txtRetineri1.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden1" )).Value;
			txtRetineri2.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden2" )).Value;
			txtRetineri3.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden3" )).Value;
			txtRetineri4.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden4" )).Value;
			txtRetineri5.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden5" )).Value;
			txtRetineri6.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden6" )).Value;
			txtRetineri7.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden7" )).Value;
			txtRegularizare.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRegularizareHidden" )).Value;
			txtPrimaProiect.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtPrimaProiectHidden" )).Value;
			txtRetinereSanatate.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetinereSanatateHidden" )).Value;
			txtDrepturiInNatura.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDrepturiInNaturaHidden" )).Value;
			
			//Lungu Andreea
			txtNrOreLucrateDelegatieInterna.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreLucrateDelegatieInternaHidden" )).Value;
			txtNrOreLucrateDelegatieExterna.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreLucrateDelegatieExternaHidden" )).Value;
			txtDiurnaImpozabila.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDiurnaImpozabilaHidden" )).Value;
			txtNrTichete.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrTicheteHidden" )).Value;
			txtCorectiiTichete.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtCorectiiTicheteHidden" )).Value;
			
			SituatieID = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtSituatieIDHidden" )).Value;
			NrZileLuna = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrZileLunaHidden" )).Value;
			AlteDrepturi = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAlteDrepturiHidden" )).Value;
			AlteDrepturiNet = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAlteDrepturiNetHidden" )).Value;
			AjutorDeces = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAjutorDecesHidden" )).Value;
			NrOreConcediuBoala = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreConcediuBoalaHidden" )).Value;
			NrOreConcediuOdihna = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreConcediuOdihnaHidden" )).Value;
			
			if (lichidat)
			{
				NrZileConcediuOdihnaNeefectuat = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrZileCOneefectuatHidden" )).Value;
				NrZileConcediuOdihnaEfectInAvans = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrZileCOefectInAvansHidden" )).Value;
			}
			
			NrOreEvenimenteDeosebite = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreEvenimDeosebHidden" )).Value;
			NrOreInvoire = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreInvoireHidden" )).Value;

			NrOreObligatiiCetatenesti = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreObligatiiCetatenestiHidden" )).Value;
			NrOreAbsenteNemotivate = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreAbsenteNemotivateHidden" )).Value;
			NrOreConcediuFaraPlata = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreConcediuFaraPlataHidden" )).Value;

			NrOreLucrate = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreLucrateHidden" )).Value;
			NrOreSup100Proc = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreSup100ProcHidden" )).Value;
			NrOreSup50Proc = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreSup50ProcHidden" )).Value;
			PrimeSpeciale = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtPrimeSpecialeHidden" )).Value;
			SporActivitatiSup = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtSporActivitatiSupHidden" )).Value;
			EmergencyServices = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtEmergencyServiceHidden" )).Value;

			Avans = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAvansHidden" )).Value;
			Retinere1 = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden1" )).Value;
			Retinere2 = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden2" )).Value;
			Retinere3 = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden3" )).Value;
			Retinere4 = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden4" )).Value;
			Retinere5 = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden5" )).Value;
			Retinere6 = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden6" )).Value;
			Retinere7 = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden7" )).Value;
			Regularizare = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRegularizareHidden" )).Value;
			PrimaProiect = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtPrimaProiectHidden" )).Value;
			RetinereSanatate = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetinereSanatateHidden" )).Value;
			DrepturiInNatura = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDrepturiInNaturaHidden" )).Value;

			//Lungu Andreea
			NrOreLucrateDelegatieInterna = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreLucrateDelegatieInternaHidden" )).Value;
			NrOreLucrateDelegatieExterna = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreLucrateDelegatieExternaHidden" )).Value;
			DiurnaImpozabila = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDiurnaImpozabilaHidden" )).Value;
			NrTichete = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrTicheteHidden" )).Value;
			CorectiiTichete = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtCorectiiTicheteHidden" )).Value;
			
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ListaCategoriiValue" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrZileLunaHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAlteDrepturiHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAlteDrepturiNetHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAjutorDecesHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreConcediuBoalaHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreConcediuOdihnaHidden" )).Value = "";
			
			if (lichidat)
			{
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrZileCOneefectuatHidden" )).Value = "";
				((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrZileCOefectInAvansHidden" )).Value = "";
			}

			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreObligatiiCetatenestiHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreAbsenteNemotivateHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreConcediuFaraPlataHidden" )).Value = "";

			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreEvenimDeosebHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreInvoireHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreLucrateHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreSup100ProcHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreSup50ProcHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtPrimeSpecialeHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtSporActivitatiSupHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtEmergencyServiceHidden" )).Value = "";

			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAvansHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden1" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden2" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden3" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden4" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden5" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden6" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetineriHidden7" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRegularizareHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtPrimaProiectHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetinereSanatateHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDrepturiInNaturaHidden" )).Value = "";

			//Lungu Andreea
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreLucrateDelegatieInternaHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrOreLucrateDelegatieExternaHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDiurnaImpozabilaHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrTicheteHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtCorectiiTicheteHidden" )).Value = "";
		}

		#endregion

		#region LoadSituatiiList
		/// <summary>
		/// Afiseaza situatia lunara a angajatului
		/// </summary>
		private void LoadSituatiiList()
		{
			try
			{
				//Oprescu Claudia
				//Daca angajatul este lichidat la data de 1 a lunii curente apare un mesaj
				//altfel se genereaza situaliza lui lunara
				Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
				angajat.AngajatId = GetAngajat();
				angajat.LoadAngajat();
				Salaries.Data.LunaData ldActiva = new Salaries.Business.Luni(this.GetAngajator()).GetLunaActiva();
				string[] arHeader;
				string[] arCols;
				int index = 0;
				
				listTable.Rows.Clear();
				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

				//S-au modificat sirurile pentru a contine si cele 7 retineri
				if(angajat.IsLichidat)
				{

					arHeader = new string[]{"Luna",
											"Nr ore lucrate", 
											"Nr ore suplimentare 100%",
											"Nr ore suplimentare 200%",
											"Nr zile luna",
											"Nr zile lucrate",
											"Nr zile absente nemotivate",
											"Nr zile concediu boala", 
											"Nr zile concediu boala BASS",
											"Nr zile concediu boala firma",
											"Nr zile concediu fara plata", 
											"Nr zile concediu odihna",
											"Nr zile concediu odihna neefectuat",
											"Nr zile concediu odihna necuvenit",
											"Nr zile emergency service", 
											"Nr zile evenimente deosebite",
											"Nr zile lucrate delegatie externa",
											"Nr zile totale delegatie externa",
											"Nr zile lucrate delegatie interna",
											"Nr zile totale delegatie interna",
											"Diurna impozabila",
											"Nr zile invoire",  
											"Nr zile obligatii cetatenesti",
										    "Nr tichete drepturi",
                                            "Nr corectii tichete",
                                            "Nr total tichete",
											"Alte drepturi brut", 
											"Alte drepturi net",
											"Ajutor deces",
											"Avans", 
											"Emergency service",
											"Drepturi in natura",
											"Indemnizatie conducere",
											"Prima proiect",
											"Prime speciale",
											"Regularizare", 
											"Salariu de baza",
											"Spor activitati sup",			 
											"Retinere sanatate",
										    "R1", "R2", "R3", "R4", "R5", "R6", "R7",
											"Norma", 
											"Invaliditate", 
											"Categorie"};

					arCols = new string[]{	"Luna",
											"NrOreLucrate", 
											"NrOreSup50Proc",
											"NrOreSup100Proc",
											"NrZileLuna",
											"NrZileLucrateLuna",
											"NrOreAbsenteNemotivate",
											"NrOreConcediuBoala",
											"NrOreConcediuBoalaBASS",
											"NrOreConcediuBoalaFirma",
											"NrOreConcediuFaraPlata",
											"NrOreConcediuOdihna", 
											"NrZileCOneefectuat",
											"NrZileCOEfectuatInAvans",
											"NrOreEmergencyService",
											"NrOreEvenimDeoseb",
											"NrOreLucrateDelegatieExterna",
											"NrOreTotalDelegatieExterna",
											"NrOreLucrateDelegatieInterna",
											"NrOreTotalDelegatieInterna",
											"DiurnaImpozabila",
											"NrOreInvoire",
											"NrOreObligatiiCetatenesti",
                                            "NrTichete",
                                            "CorectiiTichete",
										    "NrTotalTichete",
											"AlteDrepturi", 
											"AlteDrepturiNet",
											"AjutorDeces",
											"Avans",
											"EmergencyService",
											"DrepturiInNatura",
											"IndemnizatieConducere",
											"PrimeProiect",
											"PrimeSpeciale",
											"Regularizare",
											"SalariuBaza",
											"SporActivitatiSup",
											"RetinereSanatate",
                                            "Retinere1", "Retinere2", "Retinere3", "Retinere4", "Retinere5", "Retinere6", "Retinere7", 
											"ProgramLucru",
											"Nume",
											"Denumire"};
					index = 39;
				}
				else
				{
					arHeader = new string[]{"Luna",
											"Nr ore lucrate",
											"Nr ore suplimentare 100%",
											"Nr ore suplimentare 200%",
											"Nr zile luna",
											"Nr zile lucrate",
											"Nr zile absente nemotivate",
											"Nr zile concediu boala",
											"Nr zile concediu boala BASS",
											"Nr zile concediu boala firma",
											"Nr zile concediu fara plata",
											"Nr zile concediu odihna",
											"Nr zile emergency service",
											"Nr zile evenimente deosebite",
											"Nr zile lucrate delegatie externa",
											"Nr zile totale delegatie externa",
											"Nr zile lucrate delegatie interna",
											"Nr zile totale delegatie interna",	
											"Diurna impozabila",
											"Nr zile invoire",
											"Nr zile obligatii cetatenesti",
                                            "Nr tichete drepturi",
                                            "Nr corectii tichete",
										    "Nr total tichete",
										    "Alte drepturi brut",
											"Alte drepturi net",
											"Ajutor deces",
											"Avans",
											"Emergency service",
										    "Drepturi in natura",
											"Indemnizatie conducere",
											"Prima proiect",
											"Prime speciale",
											"Regularizare",
											"Salariu de baza",
											"Spor activitati sup",
											"Retinere sanatate",
											"R1", "R2", "R3", "R4", "R5", "R6", "R7",	
											"Norma",
											"Invaliditate",
											"Categorie"};

					arCols = new string[] {	"Luna",
											"NrOreLucrate",
											"NrOreSup50Proc",
											"NrOreSup100Proc",
											"NrZileLuna",
											"NrZileLucrateLuna",
											"NrOreAbsenteNemotivate",
											"NrOreConcediuBoala",
											"NrOreConcediuBoalaBASS",
											"NrOreConcediuBoalaFirma",
											"NrOreConcediuFaraPlata",
											"NrOreConcediuOdihna",
											"NrOreEmergencyService",
											"NrOreEvenimDeoseb",
											"NrOreLucrateDelegatieExterna",
											"NrOreTotalDelegatieExterna",
											"NrOreLucrateDelegatieInterna",
											"NrOreTotalDelegatieInterna",
											"DiurnaImpozabila",
											"NrOreInvoire",
											"NrOreObligatiiCetatenesti",
										    "NrTichete",
										    "CorectiiTichete",
											"NrTotalTichete",
										    "AlteDrepturi",	
											"AlteDrepturiNet",
											"AjutorDeces",
											"Avans",
											"EmergencyService",
										    "DrepturiInNatura",
											"IndemnizatieConducere",
											"PrimeProiect",
											"PrimeSpeciale",
											"Regularizare",
											"SalariuBaza",
											"SporActivitatiSup",
											"RetinereSanatate",
										    "Retinere1", "Retinere2", "Retinere3", "Retinere4", "Retinere5", "Retinere6", "Retinere7",
											"ProgramLucru",
											"Nume",
											"Denumire"};
					index = 37;
					
				}

				//Adaugat:		Oprescu Claudia
				//Descriere:	Se stabilesc label-urile pentru retineri
				TypesOfRestraints tip = new TypesOfRestraints();
				DataSet ds = tip.GetLabels(GetCurrentMonth());
				arHeader[index] = ds.Tables[0].Rows[0]["Eticheta"].ToString();
				arHeader[index + 1] = ds.Tables[0].Rows[1]["Eticheta"].ToString();
				arHeader[index + 2] = ds.Tables[0].Rows[2]["Eticheta"].ToString();
				arHeader[index + 3] = ds.Tables[0].Rows[3]["Eticheta"].ToString();
				arHeader[index + 4] = ds.Tables[0].Rows[4]["Eticheta"].ToString();
				arHeader[index + 5] = ds.Tables[0].Rows[5]["Eticheta"].ToString();
				arHeader[index + 6] = ds.Tables[0].Rows[6]["Eticheta"].ToString();

				//Angajatul a fost lichidat la data de 1 a lunii active si luna curenta este cea activa
				//se afiseaza mesajul corespunzator si altfel situatia lunara a angajatului
				if ((angajat.DataLichidare == ldActiva.Data) && (ldActiva.LunaId == GetCurrentMonth()))
				{
					arHeader = new string[1];
					arHeader[0] = "Angajatul a fost lichidat la data de : " + angajat.DataLichidare.ToShortDateString();
					arCols = new string[1];
					this.modifica.Visible = false;
				}
				else
				{
					//pentru o luna diferita de cea activa butonul pentru actualizarea situatiei lunare nu mai este vizibil
					if (GetCurrentMonth() != ldActiva.LunaId)
					{
						modifica.Visible = false;
					}
					else
					{
						this.modifica.Visible = true;
					}
				}

				Salaries.Business.SituatieLunaraAngajat sla =new Salaries.Business.SituatieLunaraAngajat(this.GetAngajat());

				ListTableVertical objListTable = new ListTableVertical(listTable, sla.GetSituatiiLunare(GetCurrentMonth()), arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista situatii lunare definite!";
		
				string[] ar_OnClickParam =new string[arCols.Length];

				ar_OnClickParam[0]="SituatieID";
				for (int i=1;i<ar_OnClickParam.Length;i++) 
					ar_OnClickParam[i]=arCols[i];

				string[] ar_OnClickParamType = new string[ar_OnClickParam.Length];
				for (int i=0;i<ar_OnClickParamType.Length;i++)
					ar_OnClickParamType[i]="dataset";
		
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				if (lichidat)
				{
					objListTable.OnclickJSMethod = "SelectSituatieLichidat";
				}
				else
				{
					objListTable.OnclickJSMethod = "SelectSituatie";
				}
			
				this.modifica.Attributes.Add("style","display: \"\" ");
				try
				{
					this.modifica.Attributes.Add("onclick",objListTable.OnclickJSMethod +"(" + objListTable.GetJSParamsList(0) + ")");
				}
				catch(Exception)
				{
				
					this.modifica.Attributes.Add("style","display: none");
				}
			
				objListTable.DrawListTableWithoutDigits();	
				//Lungu Andreea - 30.08.2010 - to do - nr cu/fara zecimale
				//objListTable.DrawListTableWithDigits(2);
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message+"<br>";
				litError.Text +=ex.StackTrace;
			}	
		}
		#endregion

		#region buttonAdaugaSituatieClick
		/// <summary>
		/// Adauga o situatie lunara
		/// </summary>
		private void buttonAdaugaSituatieClick()
		{
			int angId = GetAngajat();
			int lunaId = GetCurrentMonth();
			ErrHandler.MyErrHandler.WriteError("SituatieLunaraAngajat.ascx - start - click_AdaugaSituatie() - lunaID: " + lunaId + " - angId: " + angId);
			try
			{
				Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
				angajat.AngajatId = GetAngajat();
				angajat.LoadAngajat();
						
				Salaries.Business.SituatieLunaraAngajat sla = new Salaries.Business.SituatieLunaraAngajat(this.GetAngajat());
				
				Salaries.Data.InfoSituatieLunara x = new Salaries.Data.InfoSituatieLunara();
							
				x.SituatieID = -1;
				x.AngajatID=this.GetAngajat();
				x.LunaID = this.GetCurrentMonth();

				x.NrZileLuna = float.Parse(this.NrZileLuna);
				x.AlteDrepturi = decimal.Parse(this.AlteDrepturi);
				x.AlteDrepturiNet = decimal.Parse(this.AlteDrepturiNet);
				x.AjutorDeces = decimal.Parse(this.AjutorDeces);
				x.NrOreConcediuBoala = float.Parse(this.NrOreConcediuBoala);
				x.NrOreConcediuOdihna = float.Parse(this.NrOreConcediuOdihna);
				
				if(angajat.IsLichidat)
				{
					x.NrZileConcediuOdihnaNeefectuat = float.Parse(this.NrZileConcediuOdihnaNeefectuat);
					x.NrZileConcediuOdihnaEfectuatInAvans = float.Parse(this.NrZileConcediuOdihnaEfectInAvans);
				}

				x.NrOreEvenimDeoseb = float.Parse(this.NrOreEvenimenteDeosebite);
				x.NrOreInvoire = float.Parse(this.NrOreInvoire);

				x.NrOreObligatiiCetatenesti = float.Parse( this.NrOreObligatiiCetatenesti );
				x.NrOreAbsenteNemotivate = float.Parse( this.NrOreAbsenteNemotivate );
				x.NrOreConcediuFaraPlata = float.Parse( this.NrOreConcediuFaraPlata );

				x.NrOreLucrate = float.Parse(this.NrOreLucrate);
				x.NrOreSup100Proc = float.Parse(this.NrOreSup100Proc);
				x.NrOreSup50Proc = float.Parse(this.NrOreSup50Proc);
				x.PrimeSpeciale = decimal.Parse(this.PrimeSpeciale);
				x.SporActivitatiSup = decimal.Parse(this.SporActivitatiSup);
				x.EmergencyService = decimal.Parse(this.EmergencyServices);

				x.Avans = decimal.Parse(this.Avans);
				x.Regularizare = decimal.Parse(this.Regularizare);
				x.PrimaProiect = decimal.Parse(this.PrimaProiect);
				x.RetinereSanatate = decimal.Parse(this.RetinereSanatate);
				x.DrepturiInNatura = decimal.Parse(this.DrepturiInNatura);

				//Lungu Andreea
				x.NrOreLucrateDelegatieInterna = float.Parse(this.NrOreLucrateDelegatieInterna);
				x.NrOreLucrateDelegatieExterna = float.Parse(this.NrOreLucrateDelegatieExterna);
				x.DiurnaImpozabila = decimal.Parse(this.DiurnaImpozabila);
				x.NrTichete = float.Parse(this.NrTichete);
				x.CorectiiTichete = float.Parse(this.CorectiiTichete);
				
				x.CategorieID = angajat.CategorieId;
				
				//Dovlecel Vlad - nu il lasam sa adauge manual situatii lunare
				//sla.AddSituatieLunaraAngajat(x);
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
				ErrHandler.MyErrHandler.WriteError("SituatieLunaraAngajat.ascx - error - click_AdaugaSituatie() - lunaID: " + lunaId + " - angId: " + angId + " - " + ex.Message);
			}
			LoadSituatiiList();
			ErrHandler.MyErrHandler.WriteError("SituatieLunaraAngajat.ascx - end - click_AdaugaSituatie() - lunaID: " + lunaId + " - angId: " + angId);
		}
		#endregion

		#region NrZile
		/// <summary>
		/// Procedura calculeaza nr de zile ale unei luni
		/// </summary>
		/// <param name="An">Anul</param>
		/// <param name="Luna">Luna</param>
		/// <returns>Returneaza nr de zile din luna</returns>
		public int NrZile(int An,int Luna)
		{
			System.Globalization.GregorianCalendar x = new System.Globalization.GregorianCalendar();						
			return x.GetDaysInMonth(An,Luna);
		}
		#endregion

		#region ValidareDate
		/// <summary>
		/// Se face validarea datelor inanite de a modifica situatia angajatului.
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
				(this.txtAjutorDeces.Text == "") ||
				(this.txtAvans.Text == "") ||
				(this.txtEmergencyService.Text == "") ||
				(this.txtPrimaProiect.Text == "") ||
				(this.txtRetinereSanatate.Text == "") ||
				(this.txtDrepturiInNatura.Text == "") ||
				(this.txtCorectiiTichete.Text == "") ||
				(this.txtPrimeSpeciale.Text == "") ||
				(this.txtRegularizare.Text == "") ||
				(this.txtSporActivitatiSup.Text == "") ||
				(this.txtRetineri1.Text == "") ||
				(this.txtRetineri2.Text == "") ||
				(this.txtRetineri3.Text == "") ||
				(this.txtRetineri4.Text == "") ||
				(this.txtRetineri5.Text == "") ||
				(this.txtRetineri6.Text == "") ||
				(this.txtRetineri7.Text == ""))
				return false;

			//campurile trebuie sa fie valori intregi
			Regex expresieInteger = new Regex("^[0-9][0-9]*");  
			if (!expresieInteger.IsMatch(this.txtNrOreSup50Proc.Text))
				return false;
			if (!expresieInteger.IsMatch(this.txtNrOreSup100Proc.Text))
				return false;

			//campurile trebuie sa fie valori reale
			Regex expresieDouble = new Regex(@"^[-]?[0-9][0-9]*([.]|[,])*[0-9]*$");
			Regex expresieDoublePozitiv = new Regex(@"^[0-9][0-9]*([.]|[,])*[0-9]*$");
			if (!expresieDouble.IsMatch(this.txtAlteDrepturi.Text))
				return false;
			if (!expresieDoublePozitiv.IsMatch(this.txtAlteDrepturiNet.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtAjutorDeces.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtAvans.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtEmergencyService.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtPrimaProiect.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtRetinereSanatate.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtDrepturiInNatura.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtCorectiiTichete.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtPrimeSpeciale.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtRegularizare.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtSporActivitatiSup.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtRetineri1.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtRetineri2.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtRetineri3.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtRetineri4.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtRetineri5.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtRetineri6.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtRetineri7.Text))
				return false;
			if (!expresieDouble.IsMatch(this.txtDiurnaImpozabila.Text))
				return false;
			return true;
		}
		#endregion

		#region buttonModificaSituatieClick 
		/// <summary>
		/// Modifica situatia lunara a angajatului
		/// </summary>
		private void buttonModificaSituatieClick()
		{
			if (ValidareDate())
			{
				int angId = GetAngajat();
				int lunaId = GetCurrentMonth();
				ErrHandler.MyErrHandler.WriteError("SituatieLunaraAngajat.ascx - start - click_ModificaSituatie() - lunaID: " + lunaId + " - angId: " + angId);

				try 
				{
					long angajatID = GetAngajat();
					Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
					angajat.AngajatId = angajatID;
					angajat.LoadAngajat();

					Salaries.Business.SituatieLunaraAngajat sla = new Salaries.Business.SituatieLunaraAngajat(angajatID);
				
					Salaries.Data.InfoSituatieLunara situatie_old = new Salaries.Business.SituatieLunaraAngajat( angajatID ).GetSituatieLunaraAngajat( int.Parse(this.SituatieID)) ;
					Salaries.Data.InfoSituatieLunara x = new Salaries.Data.InfoSituatieLunara();
				
					x.SituatieID = int.Parse(this.SituatieID);
					x.AngajatID = angajatID;
					x.LunaID = this.GetCurrentMonth();
					x.NrZileLuna = float.Parse(this.NrZileLuna);
					x.AlteDrepturi = decimal.Parse(this.AlteDrepturi);
					x.AlteDrepturiNet = decimal.Parse(this.AlteDrepturiNet);
					x.AjutorDeces = decimal.Parse(this.AjutorDeces);
					x.NrOreConcediuBoala = float.Parse(this.NrOreConcediuBoala);
					x.NrOreConcediuOdihna = float.Parse(this.NrOreConcediuOdihna);

					if(angajat.IsLichidat)
					{
						x.NrZileConcediuOdihnaNeefectuat = float.Parse(this.NrZileConcediuOdihnaNeefectuat);
						x.NrZileConcediuOdihnaEfectuatInAvans = float.Parse(this.NrZileConcediuOdihnaEfectInAvans);
					}

					x.NrOreEvenimDeoseb = float.Parse(this.NrOreEvenimenteDeosebite);
					x.NrOreInvoire = float.Parse(this.NrOreInvoire);

					x.NrOreObligatiiCetatenesti = float.Parse( this.NrOreObligatiiCetatenesti );
					x.NrOreAbsenteNemotivate = float.Parse( this.NrOreAbsenteNemotivate );
					x.NrOreConcediuFaraPlata = float.Parse( this.NrOreConcediuFaraPlata );

					x.NrOreTotalDelegatieInterna = situatie_old.NrOreTotalDelegatieInterna;
					x.NrOreTotalDelegatieExterna = situatie_old.NrOreTotalDelegatieExterna;
					//x.NrOreLucrateDelegatieInterna = situatie_old.NrOreLucrateDelegatieInterna;
					//x.NrOreLucrateDelegatieExterna = situatie_old.NrOreLucrateDelegatieExterna;
					x.NrOreLucrateDelegatieInterna = float.Parse(this.NrOreLucrateDelegatieInterna);
					x.NrOreLucrateDelegatieExterna = float.Parse(this.NrOreLucrateDelegatieExterna);
					x.DiurnaImpozabila = decimal.Parse(this.DiurnaImpozabila);
					x.NrOreEmergencyService = situatie_old.NrOreEmergencyService;
				
					x.NrOreLucrate = float.Parse(this.NrOreLucrate);
					x.NrOreSup100Proc = float.Parse(this.NrOreSup100Proc);
					x.NrOreSup50Proc = float.Parse(this.NrOreSup50Proc);
					x.PrimeSpeciale = decimal.Parse(this.PrimeSpeciale);
					x.SporActivitatiSup = decimal.Parse(this.SporActivitatiSup);
					x.EmergencyService = decimal.Parse(this.EmergencyServices);

					x.Avans = decimal.Parse(this.Avans);
					if (this.Retinere1 != "")
						x.Retineri1 = decimal.Parse(this.Retinere1);
					if (this.Retinere2 != "")
						x.Retineri2 = decimal.Parse(this.Retinere2);
					if (this.Retinere3 != "")
						x.Retineri3 = decimal.Parse(this.Retinere3);
					if (this.Retinere4 != "")
						x.Retineri4 = decimal.Parse(this.Retinere4);
					if (this.Retinere5 != "")
						x.Retineri5 = decimal.Parse(this.Retinere5);
					if (this.Retinere6 != "")
						x.Retineri6 = decimal.Parse(this.Retinere6);
					if (this.Retinere7 != "")
						x.Retineri7 = decimal.Parse(this.Retinere7);
					x.Regularizare = decimal.Parse(this.Regularizare);
					x.PrimaProiect = decimal.Parse(this.PrimaProiect);
					x.RetinereSanatate = decimal.Parse(this.RetinereSanatate);
					x.DrepturiInNatura = decimal.Parse(this.DrepturiInNatura);
					
					//Lungu Andreea
					x.NrTichete = float.Parse(this.NrTichete);
					x.CorectiiTichete = float.Parse(this.CorectiiTichete);
					//nr total tichete
					x.NrTotalTichete = (int) Math.Ceiling(x.NrTichete + x.CorectiiTichete);
					if (x.NrTotalTichete < 0)
						//x.NrTotalTichete = (int) Math.Ceiling(x.NrTichete);
						x.NrTotalTichete = 0;

					x.CategorieID = situatie_old.CategorieID;
					x.Invaliditate = situatie_old.Invaliditate;
			
					sla.ModifSituatieLunaraAngajat(x);
				
					string aaa = Session["ModificaSituatie"].ToString();
					sla.GenerareSituatieLunaraAngajat(this.GetCurrentMonth(),this.GetAngajator());

					//stergerea si redistribuirea orelor suplimentare

					//ore 100%
					int lunaID = this.GetCurrentMonth();
					Luni l = new Luni( this.GetAngajator());
					Salaries.Data.LunaData ld = l.GetDetalii( lunaID );
					int tipIntervalID = new SiemensTM.Classes.IntervaleAngajat( angajatID ).GetTipIntervalIDByName( Salaries.Business.SituatieLunaraAngajat.denumireOreLucrate[ 1 ] );;
					int valEroare = new SiemensTM.Classes.IntervaleAngajat( angajatID ).DistribuieOreSuplimentareTip( ld.Data, tipIntervalID, x.NrOreSup50Proc, 0, 0 );
					if( valEroare == 1 )
					{
						Response.Write( "<script>alert( 'Numarul de ore suplimentare 100% depaseste numarul de ore disponibile!' );</script>" );
					}
					string bbb = aaa;

					//ore 200%
					tipIntervalID = new SiemensTM.Classes.IntervaleAngajat( angajatID ).GetTipIntervalIDByName( Salaries.Business.SituatieLunaraAngajat.denumireOreLucrate[ 2 ] );;
					valEroare =  new SiemensTM.Classes.IntervaleAngajat( angajatID ).DistribuieOreSuplimentareTip( ld.Data, tipIntervalID, x.NrOreSup100Proc, 0, 1 );
					if( valEroare == 1 )
					{
						Response.Write( "<script>alert( 'Numarul de ore suplimentare 200% depaseste numarul de ore disponibile!' );</script>" );
					}
				}
				catch(Exception ex)
				{
					litError.Text = "The following error occurred: <br>";
					litError.Text += ex.Message;
					ErrHandler.MyErrHandler.WriteError("SituatieLunaraAngajat.ascx - error - click_ModificaSituatie() - lunaID: " + lunaId + " - angId: " + angId + " - " + ex.Message);
			
				}

				LoadSituatiiList();

				ErrHandler.MyErrHandler.WriteError("SituatieLunaraAngajat.ascx - end - click_ModificaSituatie() - lunaID: " + lunaId + " - angId: " + angId);
			
			}
			else
			{
				Response.Write( "<script>alert( 'Datele introduse nu sunt corecte!' );</script>" );
			}
		}
		#endregion
		
		#region buttonStergeSituatieClick
		/// <summary>
		/// Sterge situatia lunara
		/// </summary>
		private void buttonStergeSituatieClick()
		{
			int angId = GetAngajat();
			int lunaId = GetCurrentMonth();
			ErrHandler.MyErrHandler.WriteError("SituatieLunaraAngajat.ascx - start - click_StergeSituatie() - lunaID: " + lunaId + " - angId: " + angId);
			
			try 
			{
				Salaries.Business.SituatieLunaraAngajat sla = new Salaries.Business.SituatieLunaraAngajat(this.GetAngajat());
				Salaries.Data.InfoSituatieLunara x = new Salaries.Data.InfoSituatieLunara();
				x.SituatieID = int.Parse(this.txtSituatieID.Value);
				//sla.DeleteSituatieLunaraAngajat(x);
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
				ErrHandler.MyErrHandler.WriteError("SituatieLunaraAngajat.ascx - error - click_StergeSituatie() - lunaID: " + lunaId + " - angId: " + angId + " - " + ex.Message);
			
			}
			LoadSituatiiList();
			ErrHandler.MyErrHandler.WriteError("SituatieLunaraAngajat.ascx - end - click_StergeSituatie() - lunaID: " + lunaId + " - angId: " + angId);
			
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
