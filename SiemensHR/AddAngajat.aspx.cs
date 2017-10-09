//Modificat: Oprescu Claudia
//Descriere: s-au modificat controalele pentru validarea numarului de buletin si pasaport pentru a accepta si litere nu numai cifre
//			 nu se mai face conversia la numar pentru numarul de pasaport si buletin			 
//
//			 s-a modificat cautarea unui centru de cost in functie de departamentul selectat		
//			 s-a adaugat cautarea unui punct de lucru in functie de angajatorul selectat	

/*
 * Modificat:	Oprescu Claudia
 * Data:		09.07.2007
 * Descriere:	A fost adaugata lista pentru Motivul de angajare .
 *				A fost adaugata lista pentru Tipul de angajat.
 * 
 * Modificat:	Oprescu Claudia
 * Data:		12.07.2007
 * Descriere:	A fost adaugat campul pentru GID.
 * 
 * Modificat:	Oprescu Claudia
 * Data:		26.07.2007
 * Descriere:	La adaugarea unui angajat se selectau toate judetele in functie de tara de domiciliu. Judetul de resedinta 
 *				trebuie selectat in functie de tara de resedinta. La fel si cu judetul de nastere.
 * 
 * Modificat:	Oprescu Claudia
 * Data:		19.09.2007
 * Descriere:	Au fost adaugate doua campuri PMP si AZM.
 * 
 * Modificat:	Fratila Claudia
 * Data:		31.10.2007
 * Descriere:	A fost modificata clasa astfel incat sa existe doua moduri autentificare: Windows sau user si parola.
 * 				Tipul de autentificare este stabilit in fisierul de configurare.
 * 				0 - fara autnetificare
 * 				1 - autentificare windows
 * 				2 - autentificare user si parola
 * 
 * Modificat:	Fratila Claudia
 * Data:		29.11.2007
 * Descriere:	A fost adaugata posibilitatea de a sepecifica pentru un angajat daca este scutit de contributia pentru sanatate sau nu.
 *				A fost adaugata posibilitatea de a sepecifica pentru un angajat daca este scutit de contributia pentru CAS sau nu.
 *
 * Modificat:	Lungu Andreea
 * Data:		26.05.2008
 * Descriere:	Au fost facute modificari astfel incat atunci cand se selecteaza un punct de lucru pentru angajat sa se seteze implicit o casa de asigurari.
 * 
 * Modificat:	Lungu Andreea
 * Data:		17.12.2009
 * Descriere:	S-a adaugat logg. 
 * 
 * Modificat:	Lungu Andreea
 * Data:		15.02.2011
 * Descriere:	S-a adaugat dataSchimbariiNumelui si retinereSomaj 
 * 
 * Modificat:	Manuel Neagoe
 * Data:		30.01.2013
 * Descriere:	S-a adaugat tip asigurat
 * 
 * 
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
using System.IO;
using System.Security.Principal;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		#region Variabile
		protected System.Web.UI.WebControls.DropDownList lstAngajator;
		protected System.Web.UI.WebControls.TextBox txtMarca;
		protected System.Web.UI.WebControls.TextBox txtPrenume;
		protected System.Web.UI.WebControls.DropDownList lstTitlu;
				
		protected System.Web.UI.WebControls.TextBox txtPrenumeMama;
		protected System.Web.UI.WebControls.TextBox txtPrenumeTata;
		protected System.Web.UI.WebControls.DropDownList lstStudiu;
		protected System.Web.UI.WebControls.TextBox txtAnAbsolvire;
		protected System.Web.UI.WebControls.TextBox txtNrDiploma;
		protected System.Web.UI.WebControls.DropDownList lstModIncadrare;
		protected System.Web.UI.WebControls.TextBox txtProgramLucru;
		protected System.Web.UI.WebControls.TextBox txtCISerie;
		protected System.Web.UI.WebControls.TextBox txtCINumar;
		protected System.Web.UI.WebControls.TextBox txtCIEliberatDe;
		protected System.Web.UI.WebControls.TextBox txtCIDataEliberarii;
		protected System.Web.UI.WebControls.TextBox txtCIValabilPanaLa;
		protected System.Web.UI.WebControls.TextBox txtPASSerie;
		protected System.Web.UI.WebControls.TextBox txtPASNumar;
		protected System.Web.UI.WebControls.TextBox txtPASEliberatDe;
		protected System.Web.UI.WebControls.TextBox txtPASDataEliberarii;
		protected System.Web.UI.WebControls.TextBox txtDLocalitate;
		protected System.Web.UI.WebControls.TextBox txtDStrada;
		protected System.Web.UI.WebControls.DropDownList lstDJudetSector;
		protected System.Web.UI.WebControls.TextBox txtDNumar;
		protected System.Web.UI.WebControls.TextBox txtDCodPostal;
		protected System.Web.UI.WebControls.TextBox txtDBloc;
		protected System.Web.UI.WebControls.TextBox txtDScara;
		protected System.Web.UI.WebControls.TextBox txtDEtaj;
		protected System.Web.UI.WebControls.TextBox txtDApartament;
		protected System.Web.UI.WebControls.TextBox txtRLocalitate;
		protected System.Web.UI.WebControls.DropDownList lstRJudetSector;
		protected System.Web.UI.WebControls.TextBox txtRStrada;
		protected System.Web.UI.WebControls.TextBox txtRNumar;
		protected System.Web.UI.WebControls.TextBox txtRCodPostal;
		protected System.Web.UI.WebControls.TextBox txtRBloc;
		protected System.Web.UI.WebControls.TextBox txtRScara;
		protected System.Web.UI.WebControls.TextBox txtREtaj;
		protected System.Web.UI.WebControls.TextBox txtTelefon;
		protected System.Web.UI.WebControls.TextBox txtDataNasterii;
		protected System.Web.UI.WebControls.DropDownList lstJudetNastere;
		protected System.Web.UI.WebControls.TextBox txtLocalitateNastere;
		protected System.Web.UI.WebControls.DropDownList lstStareCivila;
		protected System.Web.UI.WebControls.TextBox txtNrCopii;
		protected System.Web.UI.WebControls.DropDownList lstSex;
		protected System.Web.UI.WebControls.TextBox txtCMSerie;
		protected System.Web.UI.WebControls.TextBox txtCNP;
		protected System.Web.UI.WebControls.TextBox txtAniVechimeMunca;
		protected System.Web.UI.WebControls.TextBox txtZileVechimeMunca;
		protected System.Web.UI.WebControls.DropDownList lstTipFisaFiscala;
		protected System.Web.UI.WebControls.DropDownList lstAreCardBancar;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Button butSaveAngajat;
		protected System.Web.UI.WebControls.TextBox txtPASValabilPanaLa;
		protected System.Web.UI.WebControls.TextBox txtRApartament;
		protected System.Web.UI.WebControls.TextBox txtCMNumar;
		protected System.Web.UI.WebControls.TextBox txtCMEmitent;
		protected System.Web.UI.WebControls.TextBox txtCMDataEmiterii;
		protected System.Web.UI.WebControls.TextBox txtCMNrInregITM;
		protected System.Web.UI.WebControls.TextBox txtLuniVechimeMunca;
		protected System.Web.UI.WebControls.DropDownList lstTaraNastere;
		protected System.Web.UI.WebControls.DropDownList lstNationalitate;
		protected System.Web.UI.WebControls.DropDownList lstDTara;
		protected System.Web.UI.WebControls.DropDownList lstRTara;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredField_nume;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredField_prenume;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredField_nationalitate;
		protected System.Web.UI.HtmlControls.HtmlInputFile filePozaAngajat;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDLocalitate;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDStrada;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredRLocalitate;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredRStrada;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCNP;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataNasterii;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredLocalitateNastere;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredMarca;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularProgramLucru;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularAniVechime;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularLuniVechime;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularZileVechime;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCINumar;
		protected System.Web.UI.WebControls.CustomValidator customCNP;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.TextBox txtDataPanaLa;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataPanaLa;
		protected System.Web.UI.HtmlControls.HtmlSelect lstPerAngajarii;
		protected System.Web.UI.WebControls.TextBox txtNrContractMunca;
		protected System.Web.UI.WebControls.TextBox txtDataInreg;
		protected System.Web.UI.WebControls.DropDownList chkLstInvalid;
		protected System.Web.UI.WebControls.TextBox txtSalariu;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
		protected System.Web.UI.WebControls.TextBox txtIndemnizatie;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator3;
		protected System.Web.UI.WebControls.DropDownList lstCategorie;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox txtTelMunca;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtNumeAnterior;
		protected System.Web.UI.WebControls.TextBox txtNume;
		protected System.Web.UI.WebControls.TextBox txtCNPAnterior;
		protected System.Web.UI.WebControls.CustomValidator Customvalidator1;
		protected System.Web.UI.WebControls.TextBox txtDataDeLa;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataDeLa;
		protected System.Web.UI.WebControls.TextBox txtCAS1;
		protected System.Web.UI.WebControls.RadioButton radioDa;
		protected System.Web.UI.WebControls.RadioButton radioNu;
		protected System.Web.UI.WebControls.TextBox txtCAS2;
		protected System.Web.UI.WebControls.TextBox txtCAS3;
		protected System.Web.UI.WebControls.TextBox txtCAS4;
		protected System.Web.UI.WebControls.TextBox txtCAS5;
		protected System.Web.UI.WebControls.TextBox txtCAS6;
		protected System.Web.UI.WebControls.DropDownList dropLunaActiva;
		protected System.Web.UI.WebControls.DropDownList dropLunileAnului;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredProgramLucru;
		protected int[] tabLuni=new int[6];
		protected double[] tabCAS=new double[6];
		protected System.Web.UI.WebControls.Label txtLuna1;
		protected System.Web.UI.WebControls.Label txtLuna2;
		protected System.Web.UI.WebControls.Label txtLuna3;
		protected System.Web.UI.WebControls.Label txtLuna4;
		protected System.Web.UI.WebControls.Label txtLuna5;
		protected System.Web.UI.WebControls.Label txtLuna6;
		protected System.Web.UI.WebControls.Label txtLunaActiva;
		protected System.Web.UI.HtmlControls.HtmlInputHidden RTaraHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden DJudetSectorHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden RJudetSectorHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TaraNastereHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden JudetNastereHidden;
		protected System.Web.UI.WebControls.Label labelLunaActiva;
		protected System.Web.UI.WebControls.TextBox txtNrZileCOAn;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
		private Boolean InsCAS;
		protected System.Web.UI.WebControls.DropDownList lstFunctie;
		protected System.Web.UI.WebControls.TextBox txtSumaMajorare;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator5;
		protected System.Web.UI.WebControls.TextBox txtDataPlanificareMajorare;
		protected System.Web.UI.WebControls.DropDownList lstDepartament;
		protected System.Web.UI.WebControls.TextBox txtSporuri;
		protected System.Web.UI.WebControls.CompareValidator cmpVldSporuri;
		protected System.Web.UI.WebControls.TextBox txtAlteAdaosuri;
		protected System.Web.UI.WebControls.CompareValidator cmpAlteAdaosuri;
		protected System.Web.UI.WebControls.TextBox txtNrZileCOSupl;
		protected System.Web.UI.WebControls.CompareValidator cmpVldNrZileCOSupl;
		protected System.Web.UI.WebControls.TextBox txtAlteClauzeCIM;
		protected System.Web.UI.WebControls.TextBox txtEchIndProtectie;
		protected System.Web.UI.WebControls.TextBox txtMatIgiSan;
		protected System.Web.UI.WebControls.TextBox txtAlteDrSiObl;
		protected System.Web.UI.WebControls.TextBox txtAlimProtectie;
		protected System.Web.UI.WebControls.DropDownList drpEchIndProtectie;
		protected System.Web.UI.WebControls.DropDownList drpMatIgiSan;
		protected System.Web.UI.WebControls.DropDownList drpAlimProtectie;
		protected System.Web.UI.WebControls.DropDownList drpAlteDrSiObl;
		protected System.Web.UI.WebControls.DropDownList drpEchIndLucru;
		protected System.Web.UI.WebControls.TextBox txtEchIndLucru;
		protected System.Web.UI.WebControls.TextBox txtPerProba;
		protected System.Web.UI.HtmlControls.HtmlTable tableBuletin;
		protected System.Web.UI.HtmlControls.HtmlTable tablePasaport;
		protected System.Web.UI.WebControls.TextBox txtSeriePermisMunca;
		protected System.Web.UI.WebControls.TextBox txtNrPermisMunca;
		protected System.Web.UI.WebControls.TextBox txtPermisMuncaDataEliberare;
		protected System.Web.UI.HtmlControls.HtmlTable tablePermisMunca;
		protected System.Web.UI.WebControls.TextBox txtPermisMuncaDataExpirare;
		protected System.Web.UI.WebControls.TextBox txtSerieLegitimatieSedere;
		protected System.Web.UI.WebControls.TextBox txtNrLegitimatieSedere;
		protected System.Web.UI.WebControls.TextBox txtLegitimatieSedereDataEliberare;
		protected System.Web.UI.WebControls.TextBox txtLegitimatieSedereDataExpirare;
		protected System.Web.UI.HtmlControls.HtmlTable tableLegitimatieSedere;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanCNP;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanDataNasterii;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanLocalitateNastere;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanPrenumeMama;


		//daca modificati denumirea variabilei, trebuie sa o modificati si in EditTasks/EditAngajatDatePersonale.ascx.cs
		private const string directorCopierePoze = "Poze";
		protected System.Web.UI.WebControls.TextBox txtNIF;
		protected System.Web.UI.HtmlControls.HtmlTable tableNIF;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanTaraNastere;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanJudetNastere;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanSerieBI;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanNumarBI;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanEliberatDeBI;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanDataEliberareBI;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanDataExpirareBI;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanSeriePasaport;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanNumarPasaport;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanPasaportEliberatDe;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanDataEliberarePasaport;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanDataExpirarePasaport;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanSeriePermisMunca;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanNumarPermisMunca;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanDataEliberarePermisMunca;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanDataExpirarePermisMunca;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanSerieLegitimatieSedere;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanNumarLegitimatieSedere;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanDataEliberareLegitimatieSedere;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanDataExpirareLegitimatieSedere;
		protected System.Web.UI.HtmlControls.HtmlGenericControl spanNIF;
		protected System.Web.UI.HtmlControls.HtmlGenericControl labPanaLa;

		private int taraBazaID;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TaraBazaIDHidden;
		protected System.Web.UI.HtmlControls.HtmlTable tableNationalitate;
		protected System.Web.UI.HtmlControls.HtmlInputButton butSaveAngajatInput;
		protected System.Web.UI.WebControls.TextBox txtDataExpirare;
		protected System.Web.UI.WebControls.TextBox txtPerioadaCritica;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActivSeparator;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActiv;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkActiv;
		protected System.Web.UI.WebControls.TextBox txtDes;
		protected System.Web.UI.WebControls.TextBox txtDescriereAlerta;
		protected System.Web.UI.WebControls.TextBox txtDescriere;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtAlerteHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden DTaraHidden;
		protected System.Web.UI.WebControls.DropDownList lstSef;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;

		//TipNationalitateDomiciliu = 0 - nationalitatea tarii de baza (romana) si domiciliu in tara de baza (Romania)
		//TipNationalitateDomiciliu = 1 - nationalitatea tarii de baza (romana) si domiciliu in alta tara decat tara de baza (nu Romania)
		//TipNationalitateDomiciliu = 2 - nationalitatea diferita de ceea a tarii de baza (nu romana)
		private int tipNationalitateDomiciliu = 0;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.DropDownList lstPunctLucru;
		protected System.Web.UI.WebControls.DropDownList lstCasaDeAsigurari;
		protected System.Web.UI.WebControls.DropDownList lstTipAsigurat;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCategorie;
		protected System.Web.UI.WebControls.RangeValidator vldAnAbsolvire;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularEmail;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNume;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularPrenume;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNumeAnterior;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNrDiploma;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNrCopii;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularLocalitate;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularStrada;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNumar;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDNumar;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDCodPostal;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDCodPostal;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDBloc;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDScara;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDEtaj;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDApartament;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator5;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator6;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator7;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator8;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator9;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator10;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator11;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator14;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator15;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator16;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator17;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator18;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator19;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator20;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator21;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator22;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator23;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator5;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator24;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator25;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator26;
		protected System.Web.UI.WebControls.RangeValidator rangeLuniVechime;
		protected System.Web.UI.WebControls.RangeValidator rangeZileVechime;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator4;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator6;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator7;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator8;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator9;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator10;
		protected System.Web.UI.WebControls.DropDownList lstTipAngajat;
		protected System.Web.UI.WebControls.DropDownList lstMotivDeAngajare;
		protected System.Web.UI.WebControls.DropDownList lstTipDeAngajat;
		protected System.Web.UI.WebControls.TextBox txtGid;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredGid;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularGid;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularPoza;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator28;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator27;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6;
		protected System.Web.UI.WebControls.RadioButtonList rblPMP;
		protected System.Web.UI.WebControls.RadioButtonList rblAZM;
		protected System.Web.UI.WebControls.RadioButtonList rblRetinereSanatate;
		protected System.Web.UI.WebControls.RadioButtonList rblRetinereCAS;
		protected System.Web.UI.HtmlControls.HtmlInputHidden PunctLucruHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden CaseDeAsigurareHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden categorieIdHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden functieIdHidden;
		protected System.Web.UI.WebControls.TextBox txtBirou;
		protected System.Web.UI.WebControls.DropDownList ddlNivelAngajat;
		protected System.Web.UI.WebControls.TextBox txtDataSchimbariiNumelui;
		protected System.Web.UI.WebControls.RadioButtonList rblRetinereSomaj;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqFieldValNrContractMunca;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqFieldValDataInregistrareContract;
		protected System.Security.Principal.WindowsPrincipal user;
		#endregion

		#region PageLoad()
		private void Page_Load(object sender, System.EventArgs e)
		{

			// Put user code to initialize the page here		
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
						ErrHandler.MyErrHandler.WriteError("AddAngajat.aspx - autentificare windows fara drepturi - " + user.Identity.Name);
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
							ErrHandler.MyErrHandler.WriteError("AddAngajat.aspx - autentificare user parola fara drepturi - " + nume + ", " + angajatorId);
							Response.Redirect("Unauthorized.aspx");
						}
					}
					catch(Exception exc)
					{
						Response.Redirect("index.aspx");
					}
				}
			}

			//Doar se vizualizeaza departamente
			Session["administrare_departamente"] = "";
			settings = Salaries.Configuration.ModuleConfig.GetSettings();

			butSaveAngajat.Style.Add( "display", "none" );
			//Se selecteaza tara de baza
			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			try
			{
				DataSet dsTaraBaza = tari.GetTaraDeBaza();
				taraBazaID = int.Parse( dsTaraBaza.Tables[ 0 ].Rows[ 0 ][ "TaraID" ].ToString());
			}
			catch
			{
				taraBazaID = 0;
			}
			TaraBazaIDHidden.Value = taraBazaID.ToString();
			
			UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);

			if( !IsPostBack )
			{
				//Se completeaza combobox-ul cu angajatori
				Salaries.Business.AdminAngajator angajator = new Salaries.Business.AdminAngajator();
				lstAngajator.DataSource = angajator.LoadInfoAngajatori();
				lstAngajator.DataValueField = "AngajatorID";
				lstAngajator.DataTextField = "Denumire";
				lstAngajator.DataBind();
				lstAngajator.SelectedValue = Session["AngajatorID"].ToString();
				//lstAngajator.Enabled = false;
			}

			//Se selecteaza luna activa
			Salaries.Business.Luni luna = new Salaries.Business.Luni( int.Parse( lstAngajator.SelectedValue ));
			Salaries.Data.LunaData ld = luna.GetLunaActiva();
			labelLunaActiva.Text = this.GetLunaAnName( ld.Data );

			if( !IsPostBack )
			{
				Salaries.Business.Luni luni = new Salaries.Business.Luni(int.Parse(lstAngajator.SelectedValue));
				
				int LunaID = luni.GetLunaActiva().LunaId;

				//Categoriile angajatilor
				//Admin_SalariiCategoriiAngajati ca = new Admin_SalariiCategoriiAngajati(LunaID);
				Salaries.Business.AdminSalariiCategoriiAngajati ca = new Salaries.Business.AdminSalariiCategoriiAngajati();
				ca.LunaId = LunaID;
				lstCategorie.DataSource = ca.LoadInfoCategoriiLunaId();
				lstCategorie.DataTextField="Denumire";
				lstCategorie.DataValueField="CategorieID";
				lstCategorie.DataBind();
			
				// Titlurile ce le pot avea angajatii.
				Salaries.Business.AdminTitluriAngajati titluri = new Salaries.Business.AdminTitluriAngajati();
				lstTitlu.DataSource = titluri.LoadInfoTitluriAngajati();
				lstTitlu.DataValueField = "TitluID";
				lstTitlu.DataTextField = "Denumire";
				lstTitlu.DataBind();	
			
				// Studiile angajatilor
				Salaries.Business.AdminStudii studii = new Salaries.Business.AdminStudii(); 
				lstStudiu.DataSource = studii.LoadInfoStudii();
				lstStudiu.DataValueField = "StudiuID";
				lstStudiu.DataTextField = "Nume";
				lstStudiu.DataBind();

				BindInvaliditateDDL();
				BindDepartamenteDDL();
				BindSefDDL();
				BindNationalitateDDL();
				
				BindMotiveDeAngajare();
				BindTipuriDeAngajati();
				BindTipAsigurat();
			}

			//Lungu Andreea 27.06.2008
			//se populeaza cele doua dropdownlist-uri si se selecteaza valoarea care e in campurile hidden
			BindPunctLucru();
			if( PunctLucruHidden.Value != "" )
			{
				lstPunctLucru.SelectedValue = PunctLucruHidden.Value;
			}
			BindCasaDeAsigurari();
			if( CaseDeAsigurareHidden.Value != "" )
			{
				lstCasaDeAsigurari.SelectedValue = CaseDeAsigurareHidden.Value;
			}


			// Tarile existente
			lstTaraNastere.DataSource = tari.LoadInfoTariCuJudete();
			lstTaraNastere.DataTextField = "NumeTara";
			lstTaraNastere.DataValueField = "TaraID";
			lstTaraNastere.DataBind();
			if( TaraNastereHidden.Value != "" )
			{
				lstTaraNastere.SelectedValue = TaraNastereHidden.Value;
			}

			// Tarile existenete pentru domiciliu
			lstDTara.DataSource = tari.LoadInfoTariCuJudete();
			lstDTara.DataTextField = "NumeTara";
			lstDTara.DataValueField = "TaraID";
			lstDTara.DataBind();
			if( DTaraHidden.Value != "" )
			{
				lstDTara.SelectedValue = DTaraHidden.Value;
			}

			// Tarile existente pentru resedinta
			lstRTara.DataSource = tari.LoadInfoTariCuJudete();
			lstRTara.DataTextField = "NumeTara";
			lstRTara.DataValueField = "TaraID";
			lstRTara.DataBind();
			if( RTaraHidden.Value != "" )
			{
				lstRTara.SelectedValue = RTaraHidden.Value;
			}

			// Judetele existente
			Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
			judete.TaraId = int.Parse(lstDTara.SelectedValue);
			lstDJudetSector.DataSource = judete.GetAllJudeteTara();
			lstDJudetSector.DataTextField = "NumeCompus";
			lstDJudetSector.DataValueField = "JudetID";
			lstDJudetSector.DataBind();
			if( DJudetSectorHidden.Value != "" )
			{
				lstDJudetSector.SelectedValue = DJudetSectorHidden.Value;
			}

			// Judetele existente pentru resedinta
			judete.TaraId = int.Parse(lstRTara.SelectedValue);
			lstRJudetSector.DataSource = judete.GetAllJudeteTara();
			lstRJudetSector.DataTextField = "NumeCompus";
			lstRJudetSector.DataValueField = "JudetID";
			lstRJudetSector.DataBind();
			if( RJudetSectorHidden.Value != "" )
			{
				lstRJudetSector.SelectedValue = RJudetSectorHidden.Value;
			}

			// Judetele existente pentru locul nasterii
			judete.TaraId = int.Parse(lstTaraNastere.SelectedValue);
			lstJudetNastere.DataSource = judete.GetAllJudeteTara();
			lstJudetNastere.DataTextField = "NumeCompus";
			lstJudetNastere.DataValueField = "JudetID";
			lstJudetNastere.DataBind();
			if( JudetNastereHidden.Value != "" )
			{
				lstJudetNastere.SelectedValue = JudetNastereHidden.Value;
			}
			
			if( !IsPostBack )
			{
				Salaries.Business.AdminFunctii functii = new Salaries.Business.AdminFunctii();
				//daca toate functiile au atasat un cod Siemens 
				if(functii.CheckIfToateFunctiileAuCodSiemens())
					//in dropdownlist se vor afisa codul Siemens - numele functiei
					lstFunctie.DataSource = functii.LoadInfoCodSiemensNumeFunctie();
				else
					//in dropdownlist se vor afisa codul COR - numele functiei
					lstFunctie.DataSource = functii.LoadInfoCodCORNumeFunctie();
				lstFunctie.DataTextField = "CodNume";
				lstFunctie.DataValueField = "FunctieID";
				lstFunctie.DataBind();
			}

			DTaraHidden.Value = DTaraHidden.Value == "" ? lstDTara.SelectedValue : DTaraHidden.Value;
			RTaraHidden.Value = RTaraHidden.Value == "" ? lstRTara.SelectedValue : RTaraHidden.Value;
			TaraNastereHidden.Value = TaraNastereHidden.Value == "" ? lstTaraNastere.SelectedValue : TaraNastereHidden.Value;
			DJudetSectorHidden.Value = DJudetSectorHidden.Value == "" ? lstDJudetSector.SelectedValue : DJudetSectorHidden.Value;
			RJudetSectorHidden.Value = RJudetSectorHidden.Value == "" ? lstRJudetSector.SelectedValue : RJudetSectorHidden.Value;
			JudetNastereHidden.Value = JudetNastereHidden.Value == "" ? lstJudetNastere.SelectedValue : JudetNastereHidden.Value;

			string[] textTabs = {"Identificare", "Domiciliu - resedinta", "Date identificare", "Date angajare", "Date PSI", "Alerte speciale"};
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);

			CreateVarJavaScript();
			
			if( lstPerAngajarii.Value == "1" )
			{
				labPanaLa.Style.Add( "display", "" );
				txtDataPanaLa.Visible = true;
			}
			else
			{
				labPanaLa.Style.Add( "display", "none" );
				txtDataPanaLa.Visible = false;
			}

			//ClientID-urile unor textBox-uri si dropdownlist-uri--> JavaScript
			GetClientIDs();
			//seteaza vizibilitatea unor textbox-uri
			SetTextBoxVisibility();

			//afiseaza tabele specifice pt nationalitatea si domiciliul selectate
			AfisTipNationalitateDomiciliuSelectat();

			if (radioNu.Checked)
			{
				InsCAS = true;
			}
			else
			{
				InsCAS = false;
			}
		}

		#endregion	
	
		#region SetTextBoxVisibility
		/// <summary>
		/// Seteaza vizibilitatea unor textbox-uri
		/// </summary>
		public void SetTextBoxVisibility()
		{
			txtEchIndProtectie.Style.Add("display","none");
			txtEchIndLucru.Style.Add("display","none");
			txtMatIgiSan.Style.Add("display","none");
			txtAlimProtectie.Style.Add("display","none");
			txtAlteDrSiObl.Style.Add("display","none");
		}
		#endregion

		#region Incarcarea datelor in controale
		private void BindLstDJudetDDL()
		{
			Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
			judete.TaraId = int.Parse(lstDTara.SelectedValue);
			lstDJudetSector.DataSource =  judete.GetAllJudeteTara(); 
			lstDJudetSector.DataTextField = "NumeCompus";
			lstDJudetSector.DataValueField = "JudetID";
			lstDJudetSector.DataBind();
		}

		private void BindLstRJudetDDL()
		{
			Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
			judete.TaraId = int.Parse(lstDTara.SelectedValue);
			lstRJudetSector.DataSource =  judete.GetAllJudeteTara(); 
			lstRJudetSector.DataTextField = "NumeCompus";
			lstRJudetSector.DataValueField = "JudetID";
			lstRJudetSector.DataBind();
		}

		private void BindLstJudetNastereDDL()
		{
			Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
			judete.TaraId = int.Parse(lstDTara.SelectedValue);
			lstJudetNastere.DataSource =  judete.GetAllJudeteTara(); 
			lstJudetNastere.DataTextField = "NumeCompus";
			lstJudetNastere.DataValueField = "JudetID";
			lstJudetNastere.DataBind();
		}

		//Oprescu Claudia
		//se selecteaza punctele de lucru ale unui angajator
		private void BindPunctLucru()
		{
			Salaries.Business.AdminPunctLucru objAdminPunctLucru = new Salaries.Business.AdminPunctLucru();
			objAdminPunctLucru.AngajatorId = Convert.ToInt32(lstAngajator.SelectedValue, 10);
			lstPunctLucru.DataSource = objAdminPunctLucru.LoadInfoPunctLucruAngajator();
			lstPunctLucru.DataTextField = "Nume";
			lstPunctLucru.DataValueField = "PunctLucruID";
			lstPunctLucru.DataBind();
		}

		//Oprescu Claudia
		//se selecteaza casele de asigurari
		private void BindCasaDeAsigurari()
		{
			Salaries.Business.CasaDeAsigurari objCasaDeAsigurari = new Salaries.Business.CasaDeAsigurari();
			lstCasaDeAsigurari.DataSource = objCasaDeAsigurari.GetAllCasaDeAsigurari();
			lstCasaDeAsigurari.DataTextField = "Denumire";
			lstCasaDeAsigurari.DataValueField = "CasaDeAsigurariID";
			lstCasaDeAsigurari.DataBind();
		}

		/// <summary>
		/// Adaugat:	ManuelNeagoe
		/// Data:		30.01.2013
		/// Descriere:	Se incarca lista care contine tipurile de asigurat
		/// </summary>
		private void BindTipAsigurat()
		{
			Salaries.Business.TipAsigurat objTipAsigurat = new Salaries.Business.TipAsigurat();
			lstTipAsigurat.DataSource = objTipAsigurat.GetAllTipAsigurat();
			lstTipAsigurat.DataTextField = "Descriere";
			lstTipAsigurat.DataValueField = "TipAsiguratID";
			lstTipAsigurat.DataBind();
		}

		private void BindDepartamenteDDL()
		{
			new UtilitiesDb(settings.ConnectionString ).CreateDepartamenteSelectBox( 0, 0, this.lstDepartament );
		}

		private void BindInvaliditateDDL()
		{
			Salaries.Business.IstoricSchimbareDateAngajat isda = new Salaries.Business.IstoricSchimbareDateAngajat();
			DataSet ds = isda.GetAllInvaliditati();

			chkLstInvalid.DataSource = ds;
			chkLstInvalid.DataTextField = "Nume";
			chkLstInvalid.DataValueField = "InvaliditateID";
			chkLstInvalid.DataBind();
		}

		private void BindSefDDL()
		{
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.CategorieId = -1;
			angajat.AngajatorId = Convert.ToInt32(lstAngajator.SelectedValue, 10);
			DataSet ds = angajat.GetAllAngajati();
			this.lstSef.DataSource = ds;
			this.lstSef.DataValueField = "AngajatID";
			this.lstSef.DataTextField = "NumeIntreg";
			this.lstSef.DataBind();
		}

		private void BindNationalitateDDL()
		{
			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			this.lstNationalitate.DataSource = tari.GetNationalitati();
			this.lstNationalitate.DataValueField = "TaraID";
			this.lstNationalitate.DataTextField = "Nationalitate";
			this.lstNationalitate.DataBind();
		}

		/// <summary>
		/// Adaugat:	Oprescu Claudia
		/// Data:		09.07.2007
		/// Descriere:	Se incarca lista care contine motivele de angajare
		/// </summary>
		private void BindMotiveDeAngajare()
		{
			Salaries.Business.AdminMotiveDeAngajare objMotive = new Salaries.Business.AdminMotiveDeAngajare();
			lstMotivDeAngajare.DataSource = objMotive.LoadMotiveDeAngajare();
			lstMotivDeAngajare.DataTextField = "DenumireIntreaga";
			lstMotivDeAngajare.DataValueField = "MotivDeAngajareId";
			lstMotivDeAngajare.DataBind();
		}

		/// <summary>
		/// Adaugat:	Oprescu Claudia
		/// Data:		09.07.2007
		/// Descriere:	Se incarca lista care contine tipurile de angajati
		/// </summary>
		private void BindTipuriDeAngajati()
		{
			Salaries.Business.AdminTipuriDeAngajati objTipuriAngajati = new Salaries.Business.AdminTipuriDeAngajati();
			lstTipDeAngajat.DataSource = objTipuriAngajati.LoadTipuriDeAngajati();
			lstTipDeAngajat.DataTextField = "DenumireIntreaga";
			lstTipDeAngajat.DataValueField = "TipDeAngajatId";
			lstTipDeAngajat.DataBind();
		}



		private void SpanBuletinVisible( bool visibility )
		{
			string val = visibility ? "" : "none";
			spanCNP.Style.Add( "display", val );
			spanSerieBI.Style.Add( "display", val );
			spanNumarBI.Style.Add( "display", val );
			spanEliberatDeBI.Style.Add( "display", val );
			spanDataEliberareBI.Style.Add( "display", val );
			spanDataExpirareBI.Style.Add( "display", val );
		}

		private void SpanPasaportVisible( bool visibility )
		{
			string val = visibility ? "" : "none";
			spanSerieBI.Style.Add( "display", val );
			spanNumarBI.Style.Add( "display", val );
			spanDataEliberarePasaport.Style.Add( "display", val );
			spanDataExpirarePasaport.Style.Add( "display", val );
			spanPasaportEliberatDe.Style.Add( "display", val );
		}

		private void SpanPermisMuncaVisible( bool visibility )
		{
			string val = visibility ? "" : "none";
			spanSeriePermisMunca.Style.Add( "display", val );
			spanNumarPermisMunca.Style.Add( "display", val );
			spanDataEliberarePermisMunca.Style.Add( "display", val );
			spanDataExpirarePermisMunca.Style.Add( "display", val );
		}

		private void SpanLegitimatieSedereVisible( bool visibility )
		{
			string val = visibility ? "" : "none";
			spanSerieLegitimatieSedere.Style.Add( "display", val );
			spanNumarLegitimatieSedere.Style.Add( "display", val );
			spanDataEliberareLegitimatieSedere.Style.Add( "display", val );
			spanDataExpirareLegitimatieSedere.Style.Add( "display", val );
		}

		private void SpanNIFVisible( bool visibility )
		{
			string val = visibility ? "" : "none";
			spanNIF.Style.Add( "display", val );
		}

		private void AfisTipNationalitateDomiciliuSelectat()
		{
			if( int.Parse( lstNationalitate.SelectedValue ) == taraBazaID )
			{
				if( int.Parse( lstDTara.SelectedValue ) == taraBazaID )
				{
					SpanBuletinVisible( true );	//true
					SpanPasaportVisible( false );//false
					tableBuletin.Style.Add( "display", "" );
					tablePasaport.Style.Add( "display", "" );
					tablePermisMunca.Style.Add( "display", "none" );
					tableLegitimatieSedere.Style.Add( "display", "none" );
					tableNIF.Style.Add( "display", "none" );
				}
				else
				{
					SpanBuletinVisible( false );//false
					SpanPasaportVisible( true );//true
					tableBuletin.Style.Add( "display", "" );
					tablePasaport.Style.Add( "display", "" );
					tablePermisMunca.Style.Add( "display", "none" );
					tableLegitimatieSedere.Style.Add( "display", "" );
					tableNIF.Style.Add( "display", "" );
				}
			}
			else
			{
				SpanPasaportVisible( true );
				SpanPermisMuncaVisible( false );
				SpanLegitimatieSedereVisible( false );
				SpanNIFVisible( false );
				tableBuletin.Style.Add( "display", "none" );
				tablePasaport.Style.Add( "display", "" );
				tablePermisMunca.Style.Add( "display", "" );
				tableLegitimatieSedere.Style.Add( "display", "" );
				tableNIF.Style.Add( "display", "" );
			}
		}
		#endregion
		
		#region GetClientIDs
		/// <summary>
		/// ClientID-urile unor dropdown-uri si textbox-uri-->JavaScript
		/// </summary>
		public void GetClientIDs()
		{
			Response.Write( "<script>var txtEchIndLucruClient = '"+txtEchIndLucru.ClientID+"'</script>" );
			Response.Write( "<script>var drpEchIndLucruClient = '"+drpEchIndLucru.ClientID+"'</script>" );
			Response.Write( "<script>var txtEchIndProtectieClient = '"+txtEchIndProtectie.ClientID+"'</script>" );
			Response.Write( "<script>var drpEchIndProtectieClient = '"+drpEchIndProtectie.ClientID+"'</script>" );
			Response.Write( "<script>var txtMatIgiSanClient = '"+txtMatIgiSan.ClientID+"'</script>" );
			Response.Write( "<script>var drpMatIgiSanClient = '"+drpMatIgiSan.ClientID+"'</script>" );
			Response.Write( "<script>var txtAlimProtectieClient = '"+txtAlimProtectie.ClientID+"'</script>" );
			Response.Write( "<script>var drpAlimProtectieClient = '"+drpAlimProtectie.ClientID+"'</script>" );
			Response.Write( "<script>var txtAlteDrSiOblClient = '"+txtAlteDrSiObl.ClientID+"'</script>" );
			Response.Write( "<script>var drpAlteDrSiOblClient = '"+drpAlteDrSiObl.ClientID+"'</script>" );
		}
		#endregion

		#region CreateVarJavaScript
		/// <summary>
		/// Scrie variabilele JavaScript
		/// </summary>
		private void CreateVarJavaScript()
		{
			Response.Write( "<script>var DTaraHiddenClient = '"+this.DTaraHidden.ClientID+"';</script>" );
			Response.Write( "<script>var RTaraHiddenClient = '"+this.RTaraHidden.ClientID+"';</script>" );
			Response.Write( "<script>var DJudetHiddenClient = '"+this.DJudetSectorHidden.ClientID+"';</script>" );
			Response.Write( "<script>var RJudetHiddenClient = '"+this.RJudetSectorHidden.ClientID+"';</script>" );
			Response.Write( "<script>var PunctLucruHiddenClient = '"+this.PunctLucruHidden.ClientID+"';</script>" );
			Response.Write( "<script>var CaseDeAsigHiddenClient = '"+this.CaseDeAsigurareHidden.ClientID+"';</script>" );


			Response.Write( "<script>var TaraNastereHiddenClient = '"+this.TaraNastereHidden.ClientID+"';</script>" );
			Response.Write( "<script>var JudetNastereHiddenClient = '"+this.JudetNastereHidden.ClientID+"';</script>" );

			Response.Write( "<script>var lstDJudeteClient = '"+this.lstDJudetSector.ClientID+"';</script>" );
			Response.Write( "<script>var lstRJudeteClient = '"+this.lstRJudetSector.ClientID+"';</script>" );
			Response.Write( "<script>var lstJudetNastereClient = '"+this.lstJudetNastere.ClientID+"';</script>" );
			
			string sirTari = GetSirTari();
			string sirJudeteText = GetSirJudeteText();
			string sirJudeteValue = GetSirJudeteValue();
			Response.Write( "<script>var tari = "+sirTari+";</script>");
			Response.Write( "<script>var judeteText = "+sirJudeteText+";</script>" );
			Response.Write( "<script>var judeteValue = "+sirJudeteValue+";</script>" );
			
			string sirPuncteLucru = GetSirPuncteLucru();
			Response.Write( "<script>var drpPuncteLucruClient = '"+this.lstPunctLucru.ClientID+"';</script>" );
			Response.Write( "<script>var drpCaseDeAsigClient = '"+this.lstCasaDeAsigurari.ClientID+"';</script>" );
			Response.Write( "<script>var sirPuncteLucru = "+sirPuncteLucru+";</script>" );

			Response.Write( "<script>var NationalitateClinet = '"+lstNationalitate.ClientID+"';</script>" );
			Response.Write( "<script>var taraBazaID = "+taraBazaID+";</script>" );

			string sirSefDepartament = GetSirSefDepartament();
			Response.Write( "<script>var sefDepartament = "+sirSefDepartament+";</script>" );
			Response.Write( "<script>var lstDepartament = '"+this.lstDepartament.ClientID+"';</script>" );
			Response.Write( "<script>var lstSef = '"+this.lstSef.ClientID+"';</script>" );

			//Lungu Andreea 28.07.2008
			Response.Write( "<script>var categorieIdHiddenClient = '"+this.categorieIdHidden.ClientID+"';</script>" );
			Response.Write( "<script>var functieIdHiddenClient = '"+this.functieIdHidden.ClientID+"';</script>" );
			string sirFunctii = GetSirFunctiiScutireImpozit();
			Response.Write( "<script>var drpFunctieClient = '"+this.lstFunctie.ClientID+"';</script>" );
			Response.Write( "<script>var drpCategorieClient = '"+this.lstCategorie.ClientID+"';</script>" );
			Response.Write( "<script>var sirFunctii = "+sirFunctii+";</script>" );
		
		}
		#endregion

		#region Creaza siruri pentru JavaScript pentru judete, tari, departamente
		/// <summary>
		/// Sir departamente
		/// </summary>
		/// <returns></returns>
		private string GetSirSefDepartament()
		{
			//Oprescu Claudia
			// se incarca intr-un sir departamentele si sefii corespunzatoare acestora
			Salaries.Business.AdminDepartament departamente = new Salaries.Business.AdminDepartament();
			DataSet ds = departamente.GetSefPentruDepartament();

			string sirSefDepartament = "";
			string sirSef = "[";
			string sirDepartament = "[";

			for( int i=0; i<ds.Tables[0].Rows.Count-1; i++ )
			{
				sirSef += ds.Tables[0].Rows[i]["AngajatID"].ToString()+", ";
				sirDepartament += ds.Tables[0].Rows[i]["DepartamentID"].ToString()+", ";
			}
			if( ds.Tables[0].Rows.Count > 0 )
			{
				sirSef+= ds.Tables[0].Rows[ ds.Tables[0].Rows.Count-1 ]["AngajatID"].ToString()+"]";
				sirDepartament += ds.Tables[0].Rows[ ds.Tables[0].Rows.Count-1 ]["DepartamentID"].ToString()+"]";
			
				sirSefDepartament = "["+sirSef+","+sirDepartament+"]";
			}
			else
			{
				sirSefDepartament = "[[],[]]";
			}

			return sirSefDepartament;
		}

		/// <summary>
		/// Sir tari
		/// </summary>
		/// <returns></returns>
		private string GetSirTari()
		{
			string sirTari = "";
			string sirTariText = "[";
			string sirTariValue = "[";

			DataSet ds = (DataSet)lstDTara.DataSource;
			for( int i=0; i<ds.Tables[ 0 ].Rows.Count-1; i++ )
			{
				DataRow dr = ds.Tables[ 0 ].Rows[ i ];
				sirTariText += "'"+dr[ "NumeTara" ].ToString()+"', ";
				sirTariValue += dr[ "TaraID" ].ToString()+", ";
			}
			if( ds.Tables[ 0 ].Rows.Count > 0 )
			{
				sirTariText += "'"+ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "NumeTara" ].ToString()+"']";
				sirTariValue += ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "TaraID" ].ToString()+"]";
			
				sirTari = "["+sirTariText+","+sirTariValue+"]";
			}
			else
			{
				sirTari = "[[],[]]";
			}

			return sirTari;
		}

		/// <summary>
		/// Sir judete text
		/// </summary>
		/// <returns></returns>
		private string GetSirJudeteText()
		{
			string sirJudText = "";
			string sirJudTextFinal = "";
			Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
			
			DataSet dsTari = (DataSet)lstDTara.DataSource;
			foreach( DataRow drTari in dsTari.Tables[ 0 ].Rows )
			{
				judete.TaraId = int.Parse(drTari[ "TaraID" ].ToString());
				DataSet ds = judete.GetAllJudeteTara();
				if( ds.Tables[ 0 ].Rows. Count > 0 )
				{
					sirJudText = "[";

					for( int i=0; i<ds.Tables[ 0 ].Rows.Count-1; i++ )
					{
						DataRow dr = ds.Tables[ 0 ].Rows[ i ];
						sirJudText += "'"+dr[ "NumeCompus" ].ToString()+"', ";
					}
					sirJudText += "'"+ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "NumeCompus" ].ToString()+"']";
				}
				else
				{
					sirJudText = "[]";
				}
				sirJudTextFinal += sirJudText+", ";
			}
			if( sirJudTextFinal == "" )
			{
				sirJudTextFinal += "[[]]";
			}
			else
			{
				sirJudTextFinal = sirJudTextFinal.Substring( 0, sirJudTextFinal.Length-2 );
				sirJudTextFinal = "["+sirJudTextFinal+"]";
			}

			return sirJudTextFinal;
		}

		/// <summary>
		/// Sir judete
		/// </summary>
		/// <returns></returns>
		private string GetSirJudeteValue()
		{
			string sirJudVal = "";
			string sirJudValFinal = "";
			Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
		
			DataSet dsTari = (DataSet)lstDTara.DataSource;
			foreach( DataRow drTari in dsTari.Tables[ 0 ].Rows )
			{
				judete.TaraId = int.Parse(drTari[ "TaraID" ].ToString());
				DataSet ds = judete.GetAllJudeteTara();
				if( ds.Tables[ 0 ].Rows.Count > 0 )
				{
					sirJudVal = "[";

					for( int i=0; i<ds.Tables[ 0 ].Rows.Count-1; i++ )
					{
						DataRow dr = ds.Tables[ 0 ].Rows[ i ];
						sirJudVal += dr[ "JudetID" ].ToString()+", ";
					}
					sirJudVal += ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "JudetID" ].ToString()+"]";
				}
				else
				{
					sirJudVal = "[]";
				}
				sirJudValFinal += sirJudVal+", ";
			}
			if( sirJudValFinal == "" )
			{
				sirJudValFinal += "[[]]";
			}
			else
			{
				sirJudValFinal = sirJudValFinal.Substring( 0, sirJudValFinal.Length-2 );
				sirJudValFinal = "["+sirJudValFinal+"]";
			}

			return sirJudValFinal;
		}
		/// <summary>
		/// SirPuncteLucru()
		/// </summary>
		/// <returns>Returneaza sirul punctelor de lucru in care e specificata si casa de asigurari implicita</returns>
		//Lungu Andreea 26.05.2008 
		//Descriere: Acest sir este creat ca atunci cand se selecteaza un punct de lucru sa se selecteze automat 
		//           si casa de asigurari care a fost setata ca fiind implicita ramanand totusi si posibilitatea 
		//           de a alege si alta casa de asigurari
		private string GetSirPuncteLucru()
		{
			string sirPuncte = "[";
			string sirPuncteUnic = "";
			
			DataSet ds = (DataSet)lstPunctLucru.DataSource;
			for( int i=0; i<ds.Tables[0].Rows.Count-1; i++ )
			{
				DataRow dr = ds.Tables[0].Rows[i];
				sirPuncteUnic = "[" + dr["PunctLucruId"].ToString() + ",'" + dr["Nume"].ToString() + "'," + dr["IdCasaDeAsigImplicita"].ToString() + ",'"+dr["Denumire"].ToString() + "']";
				sirPuncte += sirPuncteUnic + ",";
			}
			if( ds.Tables[0].Rows.Count > 0 )
			{
				DataRow dr = ds.Tables[0].Rows[ds.Tables[0].Rows.Count-1];
				sirPuncteUnic = "[" + dr["PunctLucruId"].ToString() + ",'" + dr["Nume"].ToString() + "'," + dr["IdCasaDeAsigImplicita"].ToString() + ",'"+dr["Denumire"].ToString() + "']";
				sirPuncte += sirPuncteUnic + "]";
			}
			else
			{
				sirPuncte = "[]";
			}
			return sirPuncte;
		}

		// Lungu Andreea 28.07.2008
		// Descriere:	Este creat un sir cu functii prin care se specifica daca functia respectiva suporta sau nu scutire de impozit.
		private string GetSirFunctiiScutireImpozit()
		{
			Salaries.Business.AdminFunctii functii = new Salaries.Business.AdminFunctii();
			DataSet ds = functii.LoadInfoFunctii();

			string sirFunctii = "[";
			string sirFunctiiUnic = "";
			
			for( int i=0; i<ds.Tables[0].Rows.Count-1; i++ )
			{
				DataRow dr = ds.Tables[0].Rows[i];
				string suportaScutire = "";
				if ((bool) dr["PosibilaScutireImpozit"])
					suportaScutire = "Da";
				else
					suportaScutire = "Nu";
				sirFunctiiUnic = "[" + dr["FunctieId"].ToString() + ",'" + dr["Cod"].ToString() + " - " + dr["Nume"].ToString() + "','" + suportaScutire + "']";
				sirFunctii += sirFunctiiUnic + ",";
			}
			if( ds.Tables[0].Rows.Count > 0 )
			{
				DataRow dr = ds.Tables[0].Rows[ds.Tables[0].Rows.Count-1];
				string suportaScutire = "";
				if ((bool) dr["PosibilaScutireImpozit"])
					suportaScutire = "Da";
				else
					suportaScutire = "Nu";
				sirFunctiiUnic = "[" + dr["FunctieId"].ToString() + ",'" + dr["Cod"].ToString() + " - " + dr["Nume"].ToString() + "','" + suportaScutire + "']";
				sirFunctii += sirFunctiiUnic + "]";
			}
			else
			{
				sirFunctii = "[]";
			}
			return sirFunctii;
		}
		#endregion		

		#region CopiazaPozaPeServer
		/// <summary>
		/// Procedura copiaza poza unui angajat pe server
		/// </summary>
		/// <returns>Returneaza poza angajatului</returns>
		private byte[] CopiazaPozaPeServer()
		{
			string StrFileName = (DateTime.Now.ToString().Replace( "/", "_" ).Replace( ":", "_" ).Replace( " ", "_" ))+filePozaAngajat.PostedFile.FileName.Substring( filePozaAngajat.PostedFile.FileName.LastIndexOf("\\") + 1 );
			string sSavePath = "../"+directorCopierePoze+"/";
			string sSavePathFull = Server.MapPath( sSavePath+StrFileName );

			if( !Directory.Exists( Server.MapPath( sSavePath )))
			{
				Directory.CreateDirectory( Server.MapPath( sSavePath ).Substring( 0, Server.MapPath( sSavePath ).Length-1));
			}
			filePozaAngajat.PostedFile.SaveAs( sSavePathFull );

			FileStream fp = new FileStream( sSavePathFull, FileMode.Open, FileAccess.Read );
			BinaryReader br = new BinaryReader(fp);

			byte[] buffer = br.ReadBytes((int)fp.Length);

			//daca se depaseste dimensiunea se arunca o exceptie
			if (buffer.Length > 65536)
			{
				throw new Exception("Poza are dimensiune prea mare!");
			}
			else
			{	
				br.Close();
				fp.Close();

				if( File.Exists( sSavePathFull ))
				{
					File.Delete( sSavePathFull );
				}
				return buffer;
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.radioDa.CheckedChanged += new System.EventHandler(this.radioDa_CheckedChanged);
			this.radioNu.CheckedChanged += new System.EventHandler(this.radioNu_CheckedChanged);
			this.butSaveAngajat.Click += new System.EventHandler(this.butSaveAngajat_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region InsertAngajat
		/// <summary>
		/// Procedura adauga un angajat
		/// </summary>
		public void InsertAngajat()
		{
			ErrHandler.MyErrHandler.WriteError("AddAngajat.aspx - start - InsertAngajat()");
			try
			{
				Salaries.Business.Angajat objAngajat = new Salaries.Business.Angajat();
				objAngajat.AngajatId = 0;
				objAngajat.TipNationalitateDomiciliu = tipNationalitateDomiciliu;
			
				objAngajat.AngajatorId = Convert.ToInt32(lstAngajator.SelectedValue, 10);
				//Lungu Andreea 26.05.2003
				//objAngajat.PunctLucruId = Convert.ToInt32(lstPunctLucru.SelectedValue, 10);
				//objAngajat.CasaDeAsigurariId = Convert.ToInt32(lstCasaDeAsigurari.SelectedValue, 10);
				objAngajat.PunctLucruId = Convert.ToInt32(PunctLucruHidden.Value,10);
				objAngajat.CasaDeAsigurariId = Convert.ToInt32(CaseDeAsigurareHidden.Value,10);
				objAngajat.TipAsiguratId = Convert.ToInt32(lstTipAsigurat.SelectedValue, 10);
				objAngajat.MotivDeAngajareId = Convert.ToInt32(lstMotivDeAngajare.SelectedValue, 10);
				objAngajat.TipDeAngajatId = Convert.ToInt32(lstTipDeAngajat.SelectedValue, 10);
				objAngajat.Marca = txtMarca.Text;
				objAngajat.Gid = txtGid.Text;
				objAngajat.Nume = txtNume.Text;
				objAngajat.Prenume = txtPrenume.Text;
				objAngajat.NumeAnterior = txtNumeAnterior.Text;
				objAngajat.DataSchimbariiNumelui = Utilities.ConvertText2DateTime(txtDataSchimbariiNumelui.Text);
				objAngajat.TitluId = Convert.ToInt32(lstTitlu.SelectedValue, 10);
				
				objAngajat.StudiuId = Convert.ToInt32(lstStudiu.SelectedValue, 10);
				if (txtAnAbsolvire.Text != "")
				{
					objAngajat.AnAbsolvire = int.Parse(txtAnAbsolvire.Text);
				}
				objAngajat.NrDiploma = txtNrDiploma.Text;
				objAngajat.Descriere = txtDescriere.Text;
				objAngajat.ModIncadrare = Convert.ToByte(lstModIncadrare.SelectedValue, 10);
				objAngajat.ProgramLucru = Convert.ToByte(txtProgramLucru.Text, 10);
				objAngajat.PerioadaDeterminata=(lstPerAngajarii.Items[lstPerAngajarii.SelectedIndex].Text.Trim()=="Determinata");
				objAngajat.DataDeLa=Utilities.ConvertText2DateTime(txtDataDeLa.Text);
				objAngajat.PerProba=txtPerProba.Text;
				
				if (objAngajat.PerioadaDeterminata)
				{
					objAngajat.DataPanaLa=Utilities.ConvertText2DateTime(txtDataPanaLa.Text);
				}
				objAngajat.NrContractMunca=txtNrContractMunca.Text;
				objAngajat.DataInregContractMunca=Utilities.ConvertText2DateTime(txtDataInreg.Text);
			
				//echipament individual de protectie
				if(drpEchIndProtectie.SelectedItem.Text=="DA")
					objAngajat.EchIndProtectie=txtEchIndProtectie.Text;
				else
					objAngajat.EchIndProtectie=drpEchIndProtectie.SelectedItem.Text;
			
				//echipament individual de lucru
				if(drpEchIndLucru.SelectedItem.Text=="DA")
					objAngajat.EchIndLucru=txtEchIndLucru.Text;
				else
					objAngajat.EchIndLucru=drpEchIndLucru.SelectedItem.Text;
			
				//materiale igienico sanitare
				if(drpMatIgiSan.SelectedItem.Text=="DA")
					objAngajat.MatIgiSan=txtMatIgiSan.Text;
				else
					objAngajat.MatIgiSan=drpMatIgiSan.SelectedItem.Text;
			
				//alimentatie de protectie
				if(drpAlimProtectie.SelectedItem.Text=="DA")
					objAngajat.AlimProtectie=txtAlimProtectie.Text;
				else
					objAngajat.AlimProtectie=drpAlimProtectie.SelectedItem.Text;
				
				//alte drepturi si obligatii privind sanatatea in munca
				if(drpAlteDrSiObl.SelectedItem.Text=="DA")
					objAngajat.AlteDrSiObl=txtAlteDrSiObl.Text;
				else
					objAngajat.AlteDrSiObl=drpAlteDrSiObl.SelectedItem.Text;
				
				//alte clauze ale contractului individual de munca
				objAngajat.AlteClauzeCIM=txtAlteClauzeCIM.Text;
				//Lungu Andreea 29.07.2008
				objAngajat.FunctieCurentaId = int.Parse(functieIdHidden.Value);
				//objAngajat.FunctieCurentaId = int.Parse( lstFunctie.SelectedValue.ToString());
				objAngajat.DepartamentCurentId = int.Parse( lstDepartament.SelectedValue.ToString());
		
				if (lstSef.Items.Count > 0)
				{
					objAngajat.SefId = int.Parse( lstSef.SelectedValue.ToString());
				}
				else
				{
					objAngajat.SefId = -1;
				}
				
				if ((filePozaAngajat.PostedFile.FileName!="") || (filePozaAngajat.PostedFile.ContentLength!=0))
				{
					string contentFile = filePozaAngajat.PostedFile.ContentType.ToString();
					if (contentFile.Substring(0,5)=="image")
					{
						try
						{
							objAngajat.PozaAngajat = CopiazaPozaPeServer();
						}
						catch(Exception ex)
						{
							litError.Text = ex.Message;
							ErrHandler.MyErrHandler.WriteError("AddAngajat.aspx - error - copiere poza pe server - " + ex.Message);
						}
					}
					else
					{
						litError.Text = "Se pot salva numai fisiere de tip image (gif, jpg, jpeg...)!";
					}
				}

				//NATIONALITATE
				//objAngajat.Nationalitate = txtNationalitate.Text;
				objAngajat.Nationalitate = int.Parse( lstNationalitate.SelectedValue );
				objAngajat.PrenumeMama = txtPrenumeMama.Text;
				objAngajat.PrenumeTata = txtPrenumeTata.Text;
				objAngajat.DataNasterii = Utilities.ConvertText2DateTime(txtDataNasterii.Text);
				objAngajat.TaraNastereId = Convert.ToInt32(TaraNastereHidden.Value,10);
				objAngajat.JudetNastereId = Convert.ToInt32(JudetNastereHidden.Value, 10);
				objAngajat.LocalitateNastere = txtLocalitateNastere.Text;
				
				//BULETIN
				if (txtCNP.Text != "")
					objAngajat.CNP = Convert.ToInt64(txtCNP.Text, 10);
				objAngajat.CNPAnterior = txtCNPAnterior.Text;
				objAngajat.CIDataEliberarii = Utilities.ConvertText2DateTime(txtCIDataEliberarii.Text);
				objAngajat.CIEliberatDe = txtCIEliberatDe.Text;
				//nu se mai face conversia la numar
				objAngajat.CINumar = txtCINumar.Text;
				objAngajat.CISerie = txtCISerie.Text;
				objAngajat.CIValabilPanaLa = Utilities.ConvertText2DateTime(txtCIValabilPanaLa.Text);

				//PASAPORT
				objAngajat.PASDataEliberarii = Utilities.ConvertText2DateTime(txtPASDataEliberarii.Text);
				objAngajat.PASEliberatDe = txtPASEliberatDe.Text;
				//nu se mai face conversia la numar
				objAngajat.PASNumar = txtPASNumar.Text;
				objAngajat.PASSerie = txtPASSerie.Text;
				objAngajat.PASValabilPanaLa = Utilities.ConvertText2DateTime(txtPASValabilPanaLa.Text);
				//PERMIS MUNCA
				if( txtPermisMuncaDataExpirare.Text != "" )
					objAngajat.PermMuncaEliberat = Utilities.ConvertText2DateTime(txtPermisMuncaDataExpirare.Text);
				if( txtPermisMuncaDataEliberare.Text != "" )
					objAngajat.PermMuncaExpira = Utilities.ConvertText2DateTime(txtPermisMuncaDataEliberare.Text);
				if( txtSeriePermisMunca.Text != "" )
					objAngajat.SeriePermisMunca = txtSeriePermisMunca.Text;
				if( txtNrPermisMunca.Text != "" )
					objAngajat.NrPermisMunca = long.Parse(txtNrPermisMunca.Text);
				//LEGITIMATIE SEDERE
				if( txtLegitimatieSedereDataExpirare.Text != "" )
					objAngajat.LegitimatieSedereDataExpirare = Utilities.ConvertText2DateTime(txtLegitimatieSedereDataExpirare.Text);
				if( txtLegitimatieSedereDataEliberare.Text != "" )
					objAngajat.LegitimatieSedereDataEliberare = Utilities.ConvertText2DateTime(txtLegitimatieSedereDataEliberare.Text);
				if( txtSerieLegitimatieSedere.Text != "" )
					objAngajat.SerieLegitimatieSedere = txtSerieLegitimatieSedere.Text;
				if( txtNrLegitimatieSedere.Text != "" )
					objAngajat.NrLegitimatieSedere =  txtNrLegitimatieSedere.Text;
				//NIF
				objAngajat.NIF = txtNIF.Text;
				objAngajat.TipNationalitateDomiciliu = tipNationalitateDomiciliu;

				//DATE DOMICILIU
				objAngajat.DTara = Convert.ToInt32(DTaraHidden.Value, 10);
				objAngajat.DApartament = txtDApartament.Text;
				objAngajat.DBloc = txtDBloc.Text;
				objAngajat.DCodPostal = long.Parse(txtDCodPostal.Text);
				objAngajat.DEtaj = txtDEtaj.Text;
				objAngajat.DJudetSectorId = Convert.ToInt32(DJudetSectorHidden.Value,10);
				objAngajat.DLocalitate = txtDLocalitate.Text;
				objAngajat.DNumar = txtDNumar.Text;
				objAngajat.DScara = txtDScara.Text;
				objAngajat.DStrada = txtDStrada.Text;

				//DATE RESEDINTA
				objAngajat.RTara = Convert.ToInt32(RTaraHidden.Value, 10);
				objAngajat.RApartament = txtRApartament.Text;
				objAngajat.RBloc = txtRBloc.Text;
				objAngajat.RCodPostal = long.Parse(txtRCodPostal.Text);
				objAngajat.REtaj = txtREtaj.Text;
				objAngajat.RJudetSectorId = Convert.ToInt32(RJudetSectorHidden.Value, 10);
				objAngajat.RLocalitate = txtRLocalitate.Text;
				objAngajat.RNumar = txtRNumar.Text;
				objAngajat.RScara = txtRScara.Text;
				objAngajat.RStrada = txtRStrada.Text;

				objAngajat.Telefon = txtTelefon.Text;
				objAngajat.StareCivila = Convert.ToByte(lstStareCivila.SelectedValue, 10);
			
				if (txtNrCopii.Text != "")
				{
					objAngajat.NrCopii = Convert.ToByte(txtNrCopii.Text, 10);
				}
				else			
				{
					objAngajat.NrCopii = 0;
				}

				objAngajat.Sex = lstSex.SelectedValue;

				objAngajat.CMDataEmiterii = Utilities.ConvertText2DateTime(txtCMDataEmiterii.Text);
				objAngajat.CMEmitent = txtCMEmitent.Text;
				objAngajat.CMNrInregITM = txtCMNrInregITM.Text;
				objAngajat.CMNumar = txtCMNumar.Text;
				objAngajat.CMSerie = txtCMSerie.Text;
				objAngajat.Invaliditate=short.Parse(chkLstInvalid.SelectedValue);

				//ALERTE SPECIALE
				objAngajat.AlerteSpeciale = txtAlerteHidden.Value;
				if (rblPMP.SelectedValue == "1")
				{
					objAngajat.PMP = true;
				}
				else
				{
					objAngajat.PMP = false;
				}
				if (rblAZM.SelectedValue == "1")
				{
					objAngajat.AZM = true;
				}
				else
				{
					objAngajat.AZM = false;
				}
				if (rblRetinereSanatate.SelectedValue == "1")
				{
					objAngajat.RetinereSanatate = true;
				}
				else
				{
					objAngajat.RetinereSanatate = false;
				}
				if (rblRetinereCAS.SelectedValue == "1")
				{
					objAngajat.RetinereCAS = true;
				}
				else
				{
					objAngajat.RetinereCAS = false;
				}
				if (rblRetinereSomaj.SelectedValue == "1")
				{
					objAngajat.RetinereSomaj = true;
				}
				else
				{
					objAngajat.RetinereSomaj = false;
				}

				objAngajat.TipFisaFiscala = Convert.ToByte(lstTipFisaFiscala.SelectedValue,10);
				if (txtAniVechimeMunca.Text!="")
					objAngajat.AniVechimeMunca = Convert.ToByte(txtAniVechimeMunca.Text, 10);
				if (txtLuniVechimeMunca.Text!="")
					objAngajat.LuniVechimeMunca = Convert.ToByte(txtLuniVechimeMunca.Text, 10);
				if (txtZileVechimeMunca.Text!="")
					objAngajat.ZileVechimeMunca = Convert.ToInt32(txtZileVechimeMunca.Text, 10);
				objAngajat.AreCardBancar = Convert.ToByte(lstAreCardBancar.SelectedValue, 10);
				objAngajat.SalariuBaza=decimal.Parse(txtSalariu.Text);
				objAngajat.IndemnizatieConducere=decimal.Parse(txtIndemnizatie.Text);
				objAngajat.Sporuri=decimal.Parse(txtSporuri.Text);
				objAngajat.AlteAdaosuri=decimal.Parse(txtAlteAdaosuri.Text);
				if( txtDataPlanificareMajorare.Text != "" )
				{
					objAngajat.SumaMajorare = decimal.Parse( txtSumaMajorare.Text );
					objAngajat.DataMajorare = Utilities.ConvertText2DateTime( txtDataPlanificareMajorare.Text );
				}
				objAngajat.NrZileCOAn=int.Parse(txtNrZileCOAn.Text);
				objAngajat.NrZileCOSupl=int.Parse(txtNrZileCOSupl.Text);
				//Lungu Andreea 29.07.2008
				objAngajat.CategorieId = int.Parse(categorieIdHidden.Value);
				/*
				if (lstCategorie.Items.Count > 0)
				{
					objAngajat.CategorieId=int.Parse(lstCategorie.SelectedValue);
				}
				else
					objAngajat.CategorieId = -1;
				*/
				objAngajat.Email = this.txtEmail.Text;
				objAngajat.TelMunca = this.txtTelMunca.Text;

				objAngajat.Birou = this.txtBirou.Text;

				//Dovlecel Vlad: begin
				Salaries.Business.Luni luni = new Salaries.Business.Luni( objAngajat.AngajatorId );
				Salaries.Data.LunaData lunaData = luni.GetLunaActiva();
				lunaData.Data = new DateTime( lunaData.Data.Year, lunaData.Data.Month, DateTime.DaysInMonth( lunaData.Data.Year, lunaData.Data.Month ), 23, 59, 59 );
				
				bool verifIntrod = true;
				string textEroare = "";

				if( objAngajat.PerioadaDeterminata && objAngajat.DataDeLa >= objAngajat.DataPanaLa )
				{
					textEroare = " Data angajarii trebuie sa fie mai mica decat data expirarii contractului de munca!";
					verifIntrod = false;
				}	
			
				//daca se specifica valori pentru venituri brute acestea trebuie validate
				//daca apar erori, utilizatorul va primi un mesaj de averitzare
				if(InsCAS)
				{
					try
					{
						if ((txtCAS1.Text != "") && (txtCAS2.Text != "") && (txtCAS3.Text != "") && (txtCAS4.Text != "") && (txtCAS5.Text != "") && (txtCAS6.Text != ""))
						{
							tabCAS[0]=Convert.ToDouble(txtCAS1.Text);
							tabCAS[1]=Convert.ToDouble(txtCAS2.Text);
							tabCAS[2]=Convert.ToDouble(txtCAS3.Text);
							tabCAS[3]=Convert.ToDouble(txtCAS4.Text);
							tabCAS[4]=Convert.ToDouble(txtCAS5.Text);
							tabCAS[5]=Convert.ToDouble(txtCAS6.Text);
						}
						else
						{
							throw new Exception("Nu au fost completate toate valorile CAS!");
						}
					}
					catch(Exception)
					{
						textEroare += "Va rugam introduceti valorile veniturilor brute ale angajatului pe ultimele sase luni!";
					}
				}
				
				//se verifica datele unui angajat
				int rezultatVerificareDate = objAngajat.CheckDateAngajat();
				//nu se pot specifica doi angajati cu aceeasi marca
				if (rezultatVerificareDate == 1)
				{
					textEroare +=" Nu se pot introduce doi angajati cu aceeasi marca!";				
				}
				//nu se pot specifica doi agajati cu acelasi gid
				if (rezultatVerificareDate == 2)
				{
					textEroare +=" Nu se pot introduce doi angajati cu acelasi GID!";	
				}
				//datele sunt corecte
				if ((verifIntrod) && (textEroare == ""))
				{			
					long AngajatID = objAngajat.InsertAngajat();
					Salaries.Business.TipuriRetineriValori trv = new Salaries.Business.TipuriRetineriValori();
					trv.InsertRetineriValori(lunaData.LunaId, AngajatID);

					SiemensTM.Classes.IntervaleAngajat ia = new SiemensTM.Classes.IntervaleAngajat( AngajatID );
				
					//Modified: Cristina Raluca Muntean
					//ultimul parametru trimis metodei trebuie sa fie data lichidarii angajatului
					//(deoarece uneori prelungirea contractelor nu se face chiar la termen)
					ia.InitializeOreLucrateLunaAngajat( lunaData.Data, objAngajat.DataDeLa, objAngajat.DataLichidare );
				
					//generarea situatiei lunare a angajatului
					new Salaries.Business.SituatieLunaraAngajat( AngajatID ).GenerareSituatieLunaraAngajat( lunaData.LunaId, objAngajat.AngajatorId );
			
					//daca au fost specificate valori pentru veniturile brute
					if(InsCAS)
					{
						//se adauga aceste valori in baza de date
						for(int j=0;j<6;j++)
						{
							InsertCAS(AngajatID, 6 - j,tabCAS[j]);
						}
					}

					//Added: Ionel Popa
					//Description: Combo-box-ul din pagina EditAngajat are nevoie de un dataset cu cei carora li se pot edita datele. In acest caz este doar angajatul proaspat introdus
					Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
					Session["DataSource_EditAngajat"]  = angajat.LoadAngajat(AngajatID);
					Response.Redirect("AddAngajat_end.aspx?idAngajat=" + AngajatID.ToString());
				}
				else
				{
					Response.Write("<script>alert('Angajatul nu a fost introdus."+ textEroare +"');</script>" );
								
					//daca sunt mesaje de eroare acestea se afiseaza
					if (!litError.Text.Equals(""))
					{
						Response.Write("<script>alert('"+ litError.Text +"');</script>" );
						litError.Text = "";
					}
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
				ErrHandler.MyErrHandler.WriteError("AddAngajat.aspx - " + ex.Message);
			}
			ErrHandler.MyErrHandler.WriteError("AddAngajat.aspx - end - InsertAngajat()");
		}
		#endregion

		#region InsertAngajatInEdoc
		/// <summary>
		/// Procedura adauga un angajat in Edoc
		/// </summary>
		private void InsertAngajatInEdoc(string mark,
			string name,
			string email,
			string telephone,
			string personal_data,
			string user_name,
			string password,
			string sid,
			bool deleted)
		{
			edoc.User user = new SiemensHR.edoc.User();
			user.InsertUpdateUser(mark, name, email, telephone, personal_data, user_name, 
				password, sid, deleted);
		}

		#endregion

		#region butSaveAngajat_Click
		/// <summary>
		/// Procedura salveaza datele unui angajat
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void butSaveAngajat_Click(object sender, System.EventArgs e)
		{
			//TipNationalitateDomiciliu = 0 - nationalitatea tarii de baza (romana) si domiciliu in tara de baza (Romania)
			//TipNationalitateDomiciliu = 1 - nationalitatea tarii de baza (romana) si domiciliu in alta tara decat tara de baza (nu Romania)
			//TipNationalitateDomiciliu = 2 - nationalitatea diferita de ceea a tarii de baza (nu romana)
			if( int.Parse( lstNationalitate.SelectedValue ) == taraBazaID )
			{
				if( int.Parse( DTaraHidden.Value ) == taraBazaID )
				{
					tipNationalitateDomiciliu = 0;
				}
				else
				{
					tipNationalitateDomiciliu = 1;
				}
			}
			else
			{
				tipNationalitateDomiciliu = 2;
			}
			InsertAngajat();	
		}
		
		#endregion

		#region InsertCAS
		/// <summary>
		/// Procedura adauga datele CAS ale unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <param name="valCAS">Valoarea CAS</param>
		private void InsertCAS(long angajatId,int lunaId, double valCAS)
		{
			try
			{
				Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
				angajat.AngajatId = angajatId;
				angajat.InsertCAS(lunaId, valCAS);
			}
			catch(Exception errorInsertCAS)
			{
				litError.Text=errorInsertCAS.Message;	
			}
		}

		#endregion

		#region radioNu_CheckedChanged
		/// <summary>
		/// Stabileste ca nu se dau date CAS
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioNu_CheckedChanged(object sender, System.EventArgs e)
		{
			InsCAS=true;
		}
		#endregion

		#region radioDa_CheckedChanged
		/// <summary>
		/// Stabileste ca se dau date CAS
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioDa_CheckedChanged(object sender, System.EventArgs e)
		{
			InsCAS=false;
		}
		#endregion

		#region GetLunaAnName
		/// <summary>
		/// Procedura transforma data in string
		/// </summary>
		/// <param name="s">Data</param>
		/// <returns>Returneaza data sub forma de string</returns>
		private String GetLunaAnName(DateTime s)
		{
			String luna=(s.Month==1?"Ianuarie":s.Month==2?"Februarie":s.Month==3?"Martie":s.Month==4?"Aprilie":s.Month==5?"Mai":s.Month==6?"Iunie":s.Month==7?"Iulie":s.Month==8?"August":s.Month==9?"Septembrie":s.Month==10?"Octombrie":s.Month==11?"Noiembrie":s.Month==12?"Decembrie":"");
			return luna+" "+s.Year.ToString();
		}
		#endregion
	}
}
