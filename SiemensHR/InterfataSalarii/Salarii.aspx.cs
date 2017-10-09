/*
* Modificat:	Fratila Claudia
* Data:			31.10.2007
* Descriere:	A fost modificata clasa astfel incat sa existe doua moduri autentificare: Windows sau user si parola.
* 				Tipul de autentificare este stabilit in fisierul de configurare.
* 				0 - fara autnetificare
* 				1 - autentificare windows
* 				2 - autentificare user si parola
*
* Data:			03.12.2007
* Descriere:	A fost adaugat un camp pentru specificarea retinerii pentru sanatate.
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

namespace SiemensHR.InterfataSalarii
{
	/// <summary>
	/// Summary description for Salarii.
	/// </summary>
	public class Salarii : System.Web.UI.Page
	{
		#region Variabile
		protected System.Web.UI.HtmlControls.HtmlInputHidden ClientSelectedDate;
		protected System.Web.UI.HtmlControls.HtmlInputHidden IntervaleSaveInfoID;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TipInterval1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden OraStart1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden OraEnd1;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox CheckInterval1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden IntervalID1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden angajatiDDLHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ClientTipPontajHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden NomenclatorBoliVisible1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TipBoalaAbsente1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden DataStart1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden DataEnd1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TipIntervalAbsente1;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox CheckIntervalAbsente1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden IntervalAbsenteID1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden IntervaleAbsenteSaveInfoID;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ObservatiiID;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TipIntervalAbsenteText1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ActionInitializareLunaValoare;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ListaCategoriiValue;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrZileLunaHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrOreConcediuBoalaHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrOreConcediuOdihnaHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrOreEvenimDeosebHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrOreLucrateHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrOreSup100ProcHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrOreSup50ProcHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPrimeSpecialeHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtSporActivitatiSupHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtEmergencyServiceHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ActionGenerareSituatieLunaraValue;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrOreObligatiiCetatenestiHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrOreInvoireHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrOreAbsenteNemotivateHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrOreConcediuFaraPlataHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden actionSituatieLunaraAngajatValue;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtSituatieIDHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTipActiuneLichidareHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrInregistrareHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtDataLichidareHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAvansuriDecontareHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAbonamenteHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTicheteMasaHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtEchipamentLucruHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtLaptopHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTelServiciuHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtObiecteInventarHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtCartiHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtCDHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtDataInregistrareHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrArticolHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtLunaRetinereHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden MedieZilnica1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAvansHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtRetinereSanatateHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAlteDrepturiHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAlteDrepturiNetHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAjutorDecesHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPrimaProiectHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtRegularizareHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden actionIntervale;
		protected System.Security.Principal.WindowsPrincipal user;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtSerieHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNumarHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrZileCOneefectuatHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrZileCOefectInAvansHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtRetineriHidden1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtRetineriHidden2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtRetineriHidden3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtRetineriHidden4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtRetineriHidden5;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtRetineriHidden6;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtRetineriHidden7;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtMotivDePlecareHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ActionImportLunaValue;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtActiuneRetinere;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtDataStartRetinereHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtDataEndRetinereHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtValoareRetinereHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tipRetinereHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtDenumireRetinereHidden;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkAlertaRetinereHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtRetinereIdHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ActionImportDelegatiiLunaValue;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrTicheteHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtCorectiiTicheteHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrOreLucrateDelegatieInternaHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrOreLucrateDelegatieExternaHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtDiurnaImpozabilaHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ActionSincronizareDateAngajatiValue;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtDrepturiInNaturaHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtCnpCopilHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtDataAcordariiCertificatHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtLocPrescriereCertificatHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtCodUrgentaHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNrAvizMedicExpertHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtSerieCertificatHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtNumarCertificatHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtCertificatInitialHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ActionTrimiteMailFluturasiLunaValue;
		protected System.Web.UI.HtmlControls.HtmlInputHidden MailFluturasiLunaValue;
		//Added: Ionel Popa
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtPerformIndexingHidden;
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
						ErrHandler.MyErrHandler.WriteError("Salarii.aspx - autentificare windows fara drepturi - " + user.Identity.Name);
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

						//user-ul loginat nu are dreptul sa acceseze aceasta pagina este redirectat catre o pagina care sa il instiinteze de acest lucru
						if(!Salaries.Business.Authentication.HasUserRightsOnPage(pathArr[nr-1], nume, parola, angajatorId))
						{
							ErrHandler.MyErrHandler.WriteError("Salarii.aspx - autentificare user parola fara drepturi - " + nume + ", " + angajatorId);
							Server.Transfer("../Unauthorized.aspx"); 
						}
					}
					catch(Exception exc)
					{
						Response.Redirect("../index.aspx");
					}
				}
			}

			string myCmd = Request.QueryString["cmd"]; // comanda
			CheckInterval1.Visible = false;
			CheckIntervalAbsente1.Visible = false;
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
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render (writer);
			//variabile JavaScript pt data, tip de operatie
			Response.Write("<script>var ActionIntervaleID = '"+this.actionIntervale.ClientID+"';</script>");
			Response.Write("<script>var IntervaleSaveInfoID = '"+this.IntervaleSaveInfoID.ClientID+"';</script>");
			Response.Write("<script>var IntervaleAbsenteSaveInfoID = '"+this.IntervaleAbsenteSaveInfoID.ClientID+"';</script>");
			Response.Write("<script>var ClientSelectedDateID = '"+this.ClientSelectedDate.ClientID+"';</script>");
			
			//variabile JavaScript pt datele corespunzatoare unui interval care va fi introdus
			Response.Write( "<script>var ClientOraStart = '"+this.OraStart1.ClientID+"';</script>" );
			Response.Write( "<script>var ClientOraEnd = '"+this.OraEnd1.ClientID+"';</script>" );
			Response.Write( "<script>var ClientTipInterval = '"+this.TipInterval1.ClientID+"';</script>" );
			Response.Write( "<script>var ClientCheck = '"+this.CheckInterval1.ClientID+"';</script>" );
			Response.Write( "<script>var ClientIntervalID = '"+this.IntervalID1.ClientID+"';</script>" );
			
			//variabile JavaScript pt drop down list-ul cu angajatii din pontaje
			Response.Write( "<script>var ClientAngajatiDDLID = '"+this.angajatiDDLHidden.ClientID+"';</script>" );
			Response.Write( "<script>var ClientTipPontajHidden = '"+this.ClientTipPontajHidden.ClientID+"';</script>" );
			Response.Write( "<script>var ClientNomenclatorBoliVisible = '"+this.NomenclatorBoliVisible1.ClientID+"';</script>" );
			
			//variabile JavaScript pt datele corespunzatoare unei absente care va fi introdusa
			Response.Write( "<script>var ClientDataStart = '"+this.DataStart1.ClientID+"';</script>" );
			Response.Write( "<script>var ClientDataEnd = '"+this.DataEnd1.ClientID+"';</script>" );
			Response.Write( "<script>var ClientTipIntervalAbsente = '"+this.TipIntervalAbsente1.ClientID+"';</script>" );
			Response.Write( "<script>var ClientTipBoalaAbsente = '"+this.TipBoalaAbsente1.ClientID+"';</script>" );
			Response.Write( "<script>var ClientCheckAbsente = '"+this.CheckIntervalAbsente1.ClientID+"';</script>" );
			Response.Write( "<script>var ClientIntervalAbsenteID = '"+this.IntervalAbsenteID1.ClientID+"';</script>" );
			Response.Write( "<script>var ClientObservatiiID = '"+this.ObservatiiID.ClientID+"';</script>" );
			Response.Write( "<script>var ClientMedieZilnica = '"+this.MedieZilnica1.ClientID+"';</script>" );
			
			//Oprescu Claudia
			//S-au adaugat si cele doua campuri pentru serie si numar
			Response.Write( "<script>var txtSerieHidden = '"+this.txtSerieHidden.ClientID+"';</script>" );
			Response.Write( "<script>var txtNumarHidden = '"+this.txtNumarHidden.ClientID+"';</script>" );

            //var javascript pt initializare luna
			Response.Write( "<script>var ActionInitializareValue = '"+this.ActionInitializareLunaValoare.ClientID+"';</script>" );
			Response.Write( "<script>var ListaCategoriiVal = '"+this.ListaCategoriiValue.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrZileLunaMain = '"+this.txtNrZileLunaHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtAlteDrepturiMain = '"+this.txtAlteDrepturiHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtAlteDrepturiNetMain = '"+this.txtAlteDrepturiNetHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtAjutorDecesMain = '"+this.txtAjutorDecesHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreConcediuBoalaMain = '"+this.txtNrOreConcediuBoalaHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreConcediuOdihnaMain = '"+this.txtNrOreConcediuOdihnaHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrZileCONeefectuatMain = '"+this.txtNrZileCOneefectuatHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrZileCOefectInAvansMain = '"+this.txtNrZileCOefectInAvansHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreEvenimDeosebMain = '"+this.txtNrOreEvenimDeosebHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreInvoireMain = '"+this.txtNrOreInvoireHidden.ClientID+"';</script>" );

			Response.Write( "<script>var TxtNrOreObligatiiCetatenestiMain = '"+this.txtNrOreObligatiiCetatenestiHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreAbsenteNemotivateMain = '"+this.txtNrOreAbsenteNemotivateHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreConcediuFaraPlataMain = '"+this.txtNrOreConcediuFaraPlataHidden.ClientID+"';</script>" );

			Response.Write( "<script>var TxtNrOreLucrateMain = '"+this.txtNrOreLucrateHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreSup100ProcMain = '"+this.txtNrOreSup100ProcHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreSup50ProcMain = '"+this.txtNrOreSup50ProcHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtPrimeSpecialeMain = '"+this.txtPrimeSpecialeHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtSporActivitatiSupMain = '"+this.txtSporActivitatiSupHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtEmergencyServiceMain = '"+this.txtEmergencyServiceHidden.ClientID+"';</script>" );

			//Adaugat:		Oprescu Claudia
			//Descriere:	S-au adaugat variabile pentru cele 7 retineri
			Response.Write( "<script>var TxtAvansMain = '"+this.txtAvansHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetineriMain1 = '"+this.txtRetineriHidden1.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetineriMain2 = '"+this.txtRetineriHidden2.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetineriMain3 = '"+this.txtRetineriHidden3.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetineriMain4 = '"+this.txtRetineriHidden4.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetineriMain5 = '"+this.txtRetineriHidden5.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetineriMain6 = '"+this.txtRetineriHidden6.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetineriMain7 = '"+this.txtRetineriHidden7.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRegularizareMain = '"+this.txtRegularizareHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtPrimaProiectMain = '"+this.txtPrimaProiectHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtRetinereSanatateMain = '"+this.txtRetinereSanatateHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrTicheteMain = '"+this.txtNrTicheteHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtCorectiiTicheteMain = '"+this.txtCorectiiTicheteHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreLucrateDelegatieInternaMain = '"+this.txtNrOreLucrateDelegatieInternaHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtNrOreLucrateDelegatieExternaMain = '"+this.txtNrOreLucrateDelegatieExternaHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtDiurnaImpozabilaMain = '"+this.txtDiurnaImpozabilaHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TxtDrepturiInNaturaMain = '"+this.txtDrepturiInNaturaHidden.ClientID+"';</script>" );
			
			//Added: Ionel Popa
			Response.Write( "<script>var TxtIndexareSalariiMain = '"+this.txtPerformIndexingHidden.ClientID+"';</script>" );

			//var JavaScript pt generarea de situatii lunare
			Response.Write( "<script>var ActionGenerareSituatieLunaraMain = '"+this.ActionGenerareSituatieLunaraValue.ClientID+"';</script>" );

			//var js pt situatie lunara angajat
			Response.Write( "<script>var ActionSituatieLunaraAngajatMain = '"+this.actionSituatieLunaraAngajatValue.ClientID+"';</script>" );
			Response.Write( "<script>var TxtSituatieIDMain = '"+this.txtSituatieIDHidden.ClientID+"';</script>" );
			
			//var js pt lichidare angajat
			Response.Write( "<script>var TipActiuneLichidare = '"+this.txtTipActiuneLichidareHidden.ClientID+"';</script>" );
			Response.Write( "<script>var NrInregistrareMain = '"+this.txtNrInregistrareHidden.ClientID+"';</script>" );
			Response.Write( "<script>var DataLichidareMain = '"+this.txtDataLichidareHidden.ClientID+"';</script>" );
			Response.Write( "<script>var txtMotivDePlecareHidden = '"+this.txtMotivDePlecareHidden.ClientID+"';</script>" );

			Response.Write( "<script>var AvansuriDecontareMain = '"+this.txtAvansuriDecontareHidden.ClientID+"';</script>" );
			Response.Write( "<script>var AbonamenteMain = '"+this.txtAbonamenteHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TicheteMasaMain = '"+this.txtTicheteMasaHidden.ClientID+"';</script>" );
			Response.Write( "<script>var EchipamentLucruMain = '"+this.txtEchipamentLucruHidden.ClientID+"';</script>" );
			Response.Write( "<script>var LaptopMain = '"+this.txtLaptopHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TelServiciuMain = '"+this.txtTelServiciuHidden.ClientID+"';</script>" );
			Response.Write( "<script>var ObiecteInventarMain = '"+this.txtObiecteInventarHidden.ClientID+"';</script>" );
			Response.Write( "<script>var CartiMain = '"+this.txtCartiHidden.ClientID+"';</script>" );
			Response.Write( "<script>var CDMain = '"+this.txtCDHidden.ClientID+"';</script>" );

			Response.Write( "<script>var DataInregistrareMain = '"+this.txtDataInregistrareHidden.ClientID+"';</script>" );
			Response.Write( "<script>var NrArticolMain = '"+this.txtNrArticolHidden.ClientID+"';</script>" );
			Response.Write( "<script>var LunaRetinereMain = '"+this.txtLunaRetinereHidden.ClientID+"';</script>" );

			//pt import
			Response.Write( "<script>var ActionImportValue = '"+this.ActionImportLunaValue.ClientID+"';</script>" );
			Response.Write( "<script>var ActionImportDelegatiiValue = '"+this.ActionImportDelegatiiLunaValue.ClientID+"';</script>" );
			Response.Write( "<script>var ActionSincronizareValue = '"+this.ActionSincronizareDateAngajatiValue.ClientID+"';</script>" );
			
			//pt trimitere mail fluturasi
			Response.Write( "<script>var ActionTrimiteMailFluturasiValue = '"+this.ActionTrimiteMailFluturasiLunaValue.ClientID+"';</script>" );
			Response.Write( "<script>var mailFluturasiValue = '"+this.MailFluturasiLunaValue.ClientID+"';</script>" );
			
			//pt retineri angajat
			Response.Write( "<script>var ActionRetinereValue = '"+this.txtActiuneRetinere.ClientID+"';</script>" );
			Response.Write( "<script>var DenumireRetinereMain = '"+this.txtDenumireRetinereHidden.ClientID+"';</script>" );
			Response.Write( "<script>var TipRetinereMain = '"+this.tipRetinereHidden.ClientID+"';</script>" );
			Response.Write( "<script>var DataStartRetinereMain = '"+this.txtDataStartRetinereHidden.ClientID+"';</script>" );
			Response.Write( "<script>var DataEndRetinereMain = '"+this.txtDataEndRetinereHidden.ClientID+"';</script>" );
			Response.Write( "<script>var ValoareRetinereMain = '"+this.txtValoareRetinereHidden.ClientID+"';</script>" );
			Response.Write( "<script>var AlertaRetinereMain = '"+this.chkAlertaRetinereHidden.ClientID+"';</script>" );
			Response.Write( "<script>var RetinereIdMain = '"+this.txtRetinereIdHidden.ClientID+"';</script>" );

			//-----------Chiperescu Daniela 22.02.2011 - pentru concediul medical ------
			Response.Write( "<script>var txtNumarCertificatHidden = '"+this.txtNumarCertificatHidden.ClientID+"';</script>" );
			Response.Write( "<script>var txtSerieCertificatHidden = '"+this.txtSerieCertificatHidden.ClientID+"';</script>" );
			Response.Write( "<script>var txtCertificatInitialHidden = '"+this.txtCertificatInitialHidden.ClientID+"';</script>" );
			Response.Write( "<script>var txtDataAcordariiCertificatHidden = '"+this.txtDataAcordariiCertificatHidden.ClientID+"';</script>" );
			Response.Write( "<script>var txtCnpCopilHidden = '"+this.txtCnpCopilHidden.ClientID+"';</script>" );
			Response.Write( "<script>var txtLocPrescriereCertificatHidden = '"+this.txtLocPrescriereCertificatHidden.ClientID+"';</script>" );
			Response.Write( "<script>var txtCodUrgentaHidden = '"+this.txtCodUrgentaHidden.ClientID+"';</script>" );
			Response.Write( "<script>var txtNrAvizMedicExpertHidden = '"+this.txtNrAvizMedicExpertHidden.ClientID+"';</script>" );
			//-----------Chiperescu Daniela 22.02.2011 - pentru concediul medical ------

		}
		#endregion
	}
}
