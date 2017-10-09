//Autor: Mihai Alexandru
//Modificat: Muntean Raluca Cristina
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
using System.Xml;
using System.Xml.XPath;
using System.Threading;
using System.Globalization;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.Comunicari
{
	/// <summary>
	/// Summary description for comunicare.
	/// </summary>
	public class comunicare : System.Web.UI.Page
	{
		#region Constante
		private const int LUNA_INDEXARE_1 = 4;
		private const int LUNA_INDEXARE_2 = 10;
		#endregion

		#region Variabile
		public Salaries.Business.Angajat objAngajat;
		public XmlDocument word;
		public XmlNamespaceManager nsMgr;
		private long idAngajat;
		private DateTime DataCurenta;
		private Salaries.Business.Angajat objSefAngajat;
		private string date;
		private byte zero = 0x00;

		private static string []codAbsente = 
				{
					"ES", "I", "CO", "CM", "CCM", "OC", "AN", "CFP", "DI", "DE", "COA"
				};
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			DataCurenta = DateTime.Now;
			idAngajat = Convert.ToInt32(Request.QueryString["id"]);

			string tipcomunicare = Session["TipComunicare"].ToString(); 

			objAngajat = new Salaries.Business.Angajat();
			objAngajat.AngajatId = idAngajat;
			objAngajat.LoadAngajat();

			word = new XmlDocument();
			word.Load(Server.MapPath(tipcomunicare));

			nsMgr = new XmlNamespaceManager(word.NameTable);
			nsMgr.AddNamespace("ns0","http://schemas.pse.siemens.ro/SiemensHR");
			nsMgr.AddNamespace("w","http://schemas.microsoft.com/office/word/2003/wordml");
			nsMgr.AddNamespace("wx","http://schemas.microsoft.com/office/word/2003/auxHint");
			
			// Datele angajatului
			ProcessNodes("Nume", objAngajat.Nume);
			ProcessNodes("Prenume", objAngajat.Prenume);
			ProcessNodes("Marca", objAngajat.Marca);
			
			// Functia angajatului.
			ProcessNodes("NumeFunctie", objAngajat.FunctieCurentaNume);
			
			//are functie de conducere: DA/NU
			decimal ic=decimal.Parse(objAngajat.IndemnizatieConducere.ToString());

			if (decimal.Parse(objAngajat.IndemnizatieConducere.ToString())>0 )
			{
				ProcessNodes("FunctieConducere", "DA");
			}
			else
			{
				ProcessNodes("FunctieConducere", "NU");
			}
					
			// Este completat modul de adresare.
			string adresare = objAngajat.Sex == "m" ? "Stimate Domnule" :
				objAngajat.StareCivila.CompareTo(zero) == 0 ? "Stimata Doamna" : "Stimata Domnisoara";
			ProcessNodes("Adresare", adresare);
			
			// Datele angajatorului
			ProcessNodes("NumeAngajator", objAngajat.NumeAngajator);
			
			// Datele conducerii.
			if (Session["ManagerGeneral"] != null)
			{
				ProcessNodes("Conducere1", Session["ManagerGeneral"].ToString());
				ProcessNodes("Functie1", "Manager General");
			}
			else
			{
				ProcessNodes("Conducere1", " ");
				ProcessNodes("Functie1", "Manager General");
			
			}
			
			if (Session["DirectorEconomic"] != null)
			{
				ProcessNodes("Conducere2", Session["DirectorEconomic"].ToString());
				ProcessNodes("Functie2", "DirectorEconomic");
			}
			else
			{
				ProcessNodes("Conducere2", " ");
				ProcessNodes("Functie2", " ");
			}

			string myFileName = "";
			//in functie de tipul comunicarii sunt completate anumite campuri
			switch(tipcomunicare)
			{
				case "comunicare prima.xml":
						ProcessPrima();
						myFileName = "Comunicare prima " + objAngajat.Nume + " " + objAngajat.Prenume + ".doc";
						break;
				case "comunicare majorare.xml":
						ProcessMajorari();
					    myFileName = "Comunicare majorare " + objAngajat.Nume + " " + objAngajat.Prenume + ".doc";
						break;
				case "comunicare indexare.xml":
						ProcessIndexare();
						myFileName = "Comunicare indexare " + objAngajat.Nume + " " + objAngajat.Prenume + ".doc";
						break;
				case "comunicare indexare majorare.xml":
						ProcessIndexareMajorare();
						myFileName = "Comunicare indexare majorare " + objAngajat.Nume + " " + objAngajat.Prenume + ".doc";
						break;
				case "comunicare prelungire cim.xml":
						ProcessPrelungireCIM();
						myFileName = "Comunicare prelungire CIM " + objAngajat.Nume + " " + objAngajat.Prenume + ".doc";
						break;
				case "contractMunca_b.xml":
						ProcessContractDeMunca();
						myFileName = "Contract munca " + objAngajat.Nume + " " + objAngajat.Prenume + ".doc";
						break;
				case "contractMunca_f.xml":
						ProcessContractDeMunca();
						myFileName = "Contract munca " + objAngajat.Nume + " " + objAngajat.Prenume + ".doc";
						break;
				case "Nota de lichidare.xml":
						ProcessLichidare();
						myFileName = "Nota de lichidare " + objAngajat.Nume + " " + objAngajat.Prenume + ".doc";
						break;
				case "fisa postului.xml":
						ProcessFisaPostului();
						myFileName = "Fisa postului " + objAngajat.Nume + " " + objAngajat.Prenume + ".doc";
						break;
				case "fisa manager pr.xml":
						ProcessFisaPostului();
						myFileName = "Fisa postului " + objAngajat.Nume + " " + objAngajat.Prenume + ".doc";
						break;
				case "adeverinta_medic.xml":
						ProcessAdeverintaMedic();
						myFileName = "Adeverinta medic " + objAngajat.Nume + " " + objAngajat.Prenume + ".doc";
						break;
			}
			
			//comunicarea este salvata in result.xml
			word.Save(Server.MapPath("result.xml"));	
		
			//Response.Redirect(Server.MapPath("result.xml"));
			//Modified: Ionel Popa ... 16.08.2005
			//se downloadeaza fisierul 
			Response.ContentType = "text/plain";
			string FilePath = Server.MapPath("result.xml");
			//Response.AppendHeader( "content-disposition", "attachment; filename="+FilePath );
			Response.AppendHeader( "content-disposition", "attachment; filename=" + myFileName );
			Response.WriteFile(FilePath);
			Response.End();		
		}
		#endregion
		
		#region process comunicari 
		//noduri despre angajator
		public void ProcessAngajator()
		{
			//date angajator
			Salaries.Business.AdminAngajator objAngajator = new Salaries.Business.AdminAngajator();
			objAngajator.AngajatorId = objAngajat.AngajatorId;
			DataRow rowAngajator = objAngajator.LoadInfoAngajator().Tables[0].Rows[0];
			//localitate
			ProcessNodes("AngLocalitate",rowAngajator["Localitate"].ToString());
			//strada
			ProcessNodes("AngAdresaStr",rowAngajator["Strada"].ToString());
			//numar
			ProcessNodes("AngAdresaNr",rowAngajator["Numar"].ToString());
			//bloc
			if(rowAngajator["Bloc"].ToString()!=" ")
				ProcessNodes("AngAdresaBl",rowAngajator["Bloc"].ToString());
			else
				ProcessNodes("AngAdresaBl","-");
			//scara
			if(rowAngajator["Scara"].ToString()!=" ")
				ProcessNodes("AngAdresaSc",rowAngajator["Scara"].ToString());
			else
				ProcessNodes("AngAdresaSc","-");
			
			//numar inregistrare registrul comertului
			ProcessNodes("NrInregORC",rowAngajator["NrInregORC"].ToString());
			//CUI
			ProcessNodes("CUI",rowAngajator["CUI_CNP"].ToString());
		}
		
		//adeverinta pentru medicl de familie
		public void ProcessAdeverintaMedic()
		{
			// Date Inspector resurse umane.
			if (Session["InspectorResurseUmane"] != null)
			{
				ProcessNodes("IspectorResurseUmane", Session["InspectorResurseUmane"].ToString());

				if (Session["InspResUmaneMail"]!= null)
				{
					ProcessNodes("InspResUmaneMail",Session["InspResUmaneMail"].ToString());
				}
				else
				{
					ProcessNodes("InspResUmaneMail"," ");
				}

				if (Session["InspResUmaneNrTel"] != null)
				{
					ProcessNodes("InspResUmaneNrTel",Session["InspResUmaneNrTel"].ToString());
				}
				else
				{
					ProcessNodes("InspResUmaneNrTel","-");
				}
			
			}
			//daca nu exista un angajat in functia de inspector resurse umane
			else
			{
				ProcessNodes("IspectorResurseUmane", " ");
				ProcessNodes("InspResUmaneMail","-");
				ProcessNodes("InspResUmaneNrTel","-");			
			}
			
			//mod adresare
			string adresare = objAngajat.Sex == "m" ? "dl." :
				objAngajat.StareCivila.CompareTo(zero) == 0 ? "d-na" : "d-ra";
			ProcessNodes("Adresare", adresare);
			
			//este aflata luna activa
			Salaries.Business.Luni luni = new Salaries.Business.Luni(objAngajat.AngajatorId);
			Salaries.Data.LunaData lunaData= luni.GetLunaActiva();
			Salaries.Business.VariabileGlobale variabileGlobale = new Salaries.Business.VariabileGlobale();
			
			//data, luna curenta, an curent
			date = Session["DataInregistrarii"].ToString();
			ProcessNodes("DataInregistrarii", date);

			//numarul comunicarii
			ProcessNodes("Numar", Session["Numar"].ToString());
			
			//date angajat

			//determinata sau nedeterminata
			//felul angajarii: angajatul a a incheiat un contract pentru o perioada determinata, in acest caz
			//trebuie completate: data inceperii, data incheierii sau pentru o perioada nedeterminata
			//in acest caz trebuie completata data inceperii contractului
			if(objAngajat.PerioadaDeterminata)
			{
				//data pana la care a fost incheiat contractul
				ProcessNodes("DataAngDeLa",objAngajat.DataDeLa.Date.ToShortDateString()+" pana la "+objAngajat.DataPanaLa.Date.ToShortDateString());
				
				//tip perioada angajare
				ProcessNodes("TipPerioadaAng","determinata");
			}
			else
			{
				//data pana la care a fost incheiat contractul
				ProcessNodes("DataAngDeLa",objAngajat.DataDeLa.Date.ToShortDateString());
				
				//tip perioada angajare
				ProcessNodes("TipPerioadaAng","nedeterminata");
			}
			//tip fisa fiscala
			if(objAngajat.ModIncadrare.ToString()=="0")
				ProcessNodes("TipFisaFiscala", "cu functie de baza");
			else
				ProcessNodes("TipFisaFiscala", "fara functie de baza");
			
			//numar de inregistrare contract de munca
			ProcessNodes("NrContractMunca", objAngajat.NrContractMunca.ToString());
			
			//CAS angajat
			ProcessNodes("CASangajat",variabileGlobale.GetProcentSanatateAngajat(lunaData.LunaId).ToString()+"%");

			//CNP
			ProcessNodes("CNP",objAngajat.CNP.ToString());

			//adresa angajat
			//adresa angajator
			Salaries.Business.AdminAngajator objAngajator = new Salaries.Business.AdminAngajator();
			objAngajator.AngajatorId = objAngajat.AngajatorId;
			DataRow rowAngajator = objAngajator.LoadInfoAngajator().Tables[0].Rows[0];
			//localitate
			ProcessNodes("AngLocalitate", rowAngajator["Localitate"].ToString());
			//strada
			ProcessNodes("AngAdresaStr", rowAngajator["Strada"].ToString());
			//numar
			ProcessNodes("AngAdresaNr", rowAngajator["Numar"].ToString());
			//bloc
			if(rowAngajator["Bloc"].ToString()!=" ")
				ProcessNodes("AngAdresaBl", rowAngajator["Bloc"].ToString());
			else
				ProcessNodes("AngAdresaBl","-");
			
			//date personale
			//nationalitatea angajatului
			int nationalitate=int.Parse(objAngajat.Nationalitate.ToString());
			//daca nationalitatea angajatului corespunde cu cea a locuitorilor tarii de baza trebuie completat
			//contractul de munca cu anumite date: date buletin, cnp, permisul de munca nu trebuie completat
			//daca angajatul este cetatean strain atunci contractul de munca trebuie completat cu datele din 
			//pasaport, NIF(echivalentul CNP-ului) si datele despre permisul de munca
			
			int idTaraDeBaza=0;
			//practic DataSet-ul returneaza un singur rand
			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			DataSet dsTaraDeBaza = tari.GetTaraDeBaza();
			foreach(DataRow row in dsTaraDeBaza.Tables[0].Rows)
			{
				idTaraDeBaza=int.Parse(row["TaraID"].ToString());
			}
			//angajatul nu are cetatenie romana
			if(objAngajat.Nationalitate!=idTaraDeBaza)
			{
				//nif angajat
				ProcessNodes("CNP",objAngajat.NIF.ToString());
			}
			//daca este cetatean roman
			else
			{
				//daca cetateanul este roman si tara de domiciliu este tara de baza
				//atunci se iau datele din buletin
				if(objAngajat.DTara==idTaraDeBaza)
				{
					//cnp angajat
					ProcessNodes("CNP",objAngajat.CNP.ToString());
				}
				//daca cetateanul roman are domiciliul in strainatate
				else
				{
					//numar de identificare fiscala angajat sau CNP
					if(objAngajat.NIF.ToString()!="0")
						ProcessNodes("CNP",objAngajat.NIF.ToString());
					if(objAngajat.CNP.ToString()!="0")
						ProcessNodes("CNP",objAngajat.CNP.ToString());
				}
			}
			//CUI
			ProcessNodes("CUI",rowAngajator["CUI_CNP"].ToString());
			
			//CAS angajator
			ProcessNodes("CASangajator", variabileGlobale.GetProcentSanatateAgajator(lunaData.LunaId).ToString()+"%");
			
		}
		
		//contract de munca
		public void ProcessContractDeMunca()
		{
			/*if (Session["ManagerHR"] != null)
			{
				ProcessNodes("NumeManagerHR", Session["ManagerHR"].ToString());
			}
			else
			{
				ProcessNodes("NumeManagerHR", " ");
			}*/
			//andreea - 19.07.2012
			if (Session["ManagerGeneral"] != null)
			{
				ProcessNodes("ManagerGeneral", Session["ManagerGeneral"].ToString());
			}
			else
			{
				ProcessNodes("ManagerGeneral", " ");
			}
			if (Session["ManagerHR"] != null)
			{
				ProcessNodes("ManagerHR", Session["ManagerHR"].ToString());
			}
			else
			{
				ProcessNodes("ManagerHR", " ");
			}
			if (Session["DirectorEconomic"] != null)
			{
				ProcessNodes("DirectorEconomic", Session["DirectorEconomic"].ToString());
			}
			else
			{
				ProcessNodes("DirectorEconomic", " ");
			}

			//numarul contractului de munca
			ProcessNodes("NrContractMunca",objAngajat.NrContractMunca.ToString());
			
			//materiale igienico sanitare
			ProcessNodes("MatIgiSan",objAngajat.MatIgiSan.ToString());
			//echipament industrial de protectie
			ProcessNodes("EchIndProtectie",objAngajat.EchIndProtectie.ToString());
			//echipament industrial lucru
			ProcessNodes("EchIndLucru",objAngajat.EchIndLucru.ToString());
			//alte drepturi si obligatii
			ProcessNodes("AlteDrepturi",objAngajat.AlteDrSiObl.ToString());
			//alimentatie de protectie
			ProcessNodes("AlimDeProtectie",objAngajat.AlimProtectie.ToString());
			//perioada de proba - nr luni
			if(objAngajat.PerProba.ToString()!="")
				ProcessNodes("PerProba",objAngajat.PerProba.ToString());
			else
				ProcessNodes("PerProba","-");

			//alte clauze
			if(objAngajat.AlteClauzeCIM.ToString()!="")
				ProcessNodes("AlteClauze",objAngajat.AlteClauzeCIM.ToString());
			else
				ProcessNodes("AlteClauze","-");

			
			//salariul brut
			ProcessNodes("SalariuBrutSB",objAngajat.SalariuBaza.ToString("N", Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits));
			//indemnizatia de conducere
			ProcessNodes("SalariuBrutIC",objAngajat.IndemnizatieConducere.ToString("N", Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits));
			
			//adresa angajat
			//strada
			ProcessNodes("AdresaStr",objAngajat.DStrada.ToString());
			//numar
			ProcessNodes("AdresaNr",objAngajat.DNumar.ToString());
			//bloc
			if(objAngajat.DBloc.ToString()!="")
				ProcessNodes("AdresaBl",objAngajat.DBloc.ToString());
			else
				ProcessNodes("AdresaBl","-");
			//scara
			if(objAngajat.DScara.ToString()!="")
				ProcessNodes("AdresaSc",objAngajat.DScara.ToString());
			else
				ProcessNodes("AdresaSc","-");
			//apartament
			if(objAngajat.DApartament.ToString()!="")
				ProcessNodes("AdresaAp",objAngajat.DApartament.ToString());
			else
				ProcessNodes("AdresaAp","-");

			//localitate
			ProcessNodes("AdresaLocaliate",objAngajat.DLocalitate.ToString());
			//judet
			Salaries.Business.AdminJudete infoJudet = new Salaries.Business.AdminJudete();
			infoJudet.JudetId = objAngajat.DJudetSectorId;
			string judetNume = infoJudet.GetJudetInfo().Tables[0].Rows[0]["Nume"].ToString();
			ProcessNodes("AdresaJudet",judetNume);

			//program lucru
			if(int.Parse(objAngajat.ProgramLucru.ToString())==8)
			{
				//norma
				ProcessNodes("ProgramLucru",objAngajat.ProgramLucru.ToString());
				//numarul de ore lucrate pe sapt
				int prgPrSapt=int.Parse(objAngajat.ProgramLucru.ToString())*5;
				ProcessNodes("ProgramOrePeSapt",prgPrSapt.ToString());
				//norma in cazul in care aceasta nu este de 8 ore
				ProcessNodes("ProgramLucruFrac","-");
				//numarul de ore lucrate pe saptamana in cazul in care angajatul nu are norma intreaga
				ProcessNodes("ProgramOrePeSaptFrac","-");
				RemoveNode("DurataNormaFractionara");
			}
			else
			{
				//norma
				ProcessNodes("ProgramLucruFrac",objAngajat.ProgramLucru.ToString());
				//numarul de ore lucrate pe sapt
				int prgPrSapt=int.Parse(objAngajat.ProgramLucru.ToString())*5;
				ProcessNodes("ProgramOrePeSaptFrac",prgPrSapt.ToString());
				//norma in cazul in care aceasta nu este de 8 ore
				ProcessNodes("ProgramLucru","-");
				//numarul de ore lucrate pe saptamana in cazul in care angajatul nu are norma intreaga
				ProcessNodes("ProgramOrePeSapt","-");
				RemoveNode("DurataNormaIntreaga");
			}
			//numarul de zile de concediu la care are dreptun un angajat intr-un an
			ProcessNodes("NrZileCO",objAngajat.NrZileCOAn.ToString());
			//felul angajarii: angajatul a a incheiat un contract pentru o perioada determinata, in acest caz
			//trebuie completate:nr luni, data inceperii, data incheierii sau pentru o perioada nedeterminata
			//in acest caz trebuie completata data inceperii contractului
			if(objAngajat.PerioadaDeterminata)
			{
				//data pana la care a fost incheiat contractul
				//ProcessNodes("DataAngPanaLa",objAngajat.DataPanaLa.Date.ToShortDateString());
				ProcessNodes("DataAngPanaLa",objAngajat.DataPanaLa.Date.ToString("dd.MM.yyyy"));
				//data incheierii contractului
				ProcessNodes("DataAngDeLa",objAngajat.DataDeLa.Date.ToString("dd.MM.yyyy"));
				//numarul de zile de la data angajarii pana la data inceierii contractului
				System.TimeSpan nrZile=objAngajat.DataPanaLa.Subtract(objAngajat.DataDeLa);
				//numarul de luni
				int nrLuni = int.Parse(nrZile.Days.ToString())/30;
				if(nrLuni>1)
					//numarul de luni
					ProcessNodes("DetermNrLuni",nrLuni.ToString());
				else
					//numarul de luni
					ProcessNodes("DetermNrLuni",nrLuni.ToString()+"luna");
				ProcessNodes("NedetDataAngDeLa","-");
				RemoveNode("DurataNedeterminata");
			}
			else
			{
				//data pana la care a fost incheiat contractul
				ProcessNodes("DataAngPanaLa","-")	;
				//data incheierii contractului
				ProcessNodes("DataAngDeLa","-");
				//numarul de luni
				ProcessNodes("DetermNrLuni","-");
				ProcessNodes("NedetDataAngDeLa",objAngajat.DataDeLa.Date.ToString("dd.MM.yyyy"));
				RemoveNode("DurataDeterminata");
			}
			//numarul de zile de concediu de odihna suplimentar
			ProcessNodes("NrZileCOSupl",objAngajat.NrZileCOSupl.ToString());
			//sporuri
			ProcessNodes("Sporuri",(objAngajat.Sporuri.ToString("N", Salaries.Business.VariabileGlobale.numberInfoFormatWithDigits)));
			//alte adaosuri
			ProcessNodes("AlteAdaosuri",objAngajat.AlteAdaosuri.ToString("N", Salaries.Business.VariabileGlobale.numberInfoFormatWithDigits));
			
			//date personale
			//nationalitatea angajatului
			int nationalitate=int.Parse(objAngajat.Nationalitate.ToString());
			//daca nationalitatea angajatului corespunde cu cea a locuitorilor tarii de baza trebuie completat
			//contractul de munca cu anumite date: date buletin, cnp, permisul de munca nu trebuie completat
			//daca angajatul este cetatean strain atunci contractul de munca trebuie completat cu datele din 
			//pasaport, NIF(echivalentul CNP-ului) si datele despre permisul de munca
			if (objAngajat.Sex.Equals("m"))
				ProcessNodes("TitluAdresare","domnul");
			else
			{
				if (objAngajat.StareCivila == 1)
					ProcessNodes("TitluAdresare","domnisoara");
				else
					ProcessNodes("TitluAdresare","doamna");
			}
			int idTaraDeBaza=0;
			//practic DataSet-ul returneaza un singur rand
			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			DataSet dsTaraDeBaza = tari.GetTaraDeBaza();
			foreach(DataRow row in dsTaraDeBaza.Tables[0].Rows)
			{
				idTaraDeBaza=int.Parse(row["TaraID"].ToString());
			}
			//angajatul nu are cetatenie romana
			if(objAngajat.Nationalitate!=idTaraDeBaza)
			{
				//seria pasaportului
				if(objAngajat.PASSerie.ToString()!=" ")
					ProcessNodes("BuletinSerie",objAngajat.PASSerie.ToString());
				else
					ProcessNodes("BuletinSerie","-");
				//numarul pasaportului
				if((objAngajat.PASNumar.ToString()!=" ")&&(objAngajat.PASNumar.ToString()!="0"))
					ProcessNodes("BuletinNr",objAngajat.PASNumar.ToString());
				else
					ProcessNodes("BuletinNr","-");
				//data eliberarii buletinului
				if(objAngajat.PASDataEliberarii.Date==DateTime.MinValue)
					ProcessNodes("BuletinDataElib","-");
				else
					ProcessNodes("BuletinDataElib",objAngajat.PASDataEliberarii.Date.ToString("dd.MM.yyyy"));
				//buleti eliberat de
				ProcessNodes("BuletinElibDe","-");

				//nif angajat
				if (objAngajat.NIF != null)
					ProcessNodes("CNP",objAngajat.NIF.ToString());
				else
					ProcessNodes("CNP","-");

				//date permis de munca
				//serie permis de munca
				if((objAngajat.NrPermisMunca.ToString()!=" ")&&(objAngajat.NrPermisMunca.ToString()!="0"))
					ProcessNodes("PermisMuncaSeria",objAngajat.NrPermisMunca.ToString());
				else
					ProcessNodes("PermisMuncaSeria","-");
				//data eliberarii permisului de munca
				if((objAngajat.PermMuncaEliberat.ToString()!=" ")&&(objAngajat.PermMuncaEliberat.Date!=DateTime.MinValue))
					ProcessNodes("PermisMuncaDinData",objAngajat.PermMuncaEliberat.Date.ToString("dd.MM.yyyy"));
				else
					ProcessNodes("PermisMuncaDinData","-");

				RemoveNode("CIText");
							
			}
			//daca este cetatean roman
			else
			{
				//daca cetateanul este roman si tara de domiciliu este tara de baza
				//atunci se iau datele din buletin
				if(objAngajat.DTara==idTaraDeBaza)
				{
					//seria buletinului
					if ( (objAngajat.CISerie != null) && (objAngajat.CISerie.ToString() != " ") ) 
						ProcessNodes("BuletinSerie",objAngajat.CISerie.ToString());
					else
						ProcessNodes("BuletinSerie","-");

					//numarul buletinului
					if ( (objAngajat.CINumar != null) && (objAngajat.CINumar.ToString() != "0") )
						ProcessNodes("BuletinNr",objAngajat.CINumar.ToString());
					else
						ProcessNodes("BuletinNr","-");

					//data eliberarii buletinului
					if (objAngajat.CIDataEliberarii.Date == DateTime.MinValue)
						ProcessNodes("BuletinDataElib","-");
					else
						ProcessNodes("BuletinDataElib",objAngajat.CIDataEliberarii.Date.ToString("dd.MM.yyyy"));

					//buleti eliberat de
					if ( (objAngajat.CIEliberatDe != null) && (objAngajat.CIEliberatDe.ToString() != " ") )
						ProcessNodes("BuletinElibDe",objAngajat.CIEliberatDe.ToString());
					else
						ProcessNodes("BuletinElibDe","-");
					
					//cnp angajat
					if (objAngajat.CNP.ToString() != "0")
						ProcessNodes("CNP",objAngajat.CNP.ToString());
					else
						ProcessNodes("CNP","-");
				}
				//daca cetateanul roman are domiciliul in strainatate
				else
				{
					//seria pasaportului
					if ( (objAngajat.PASSerie != null) && (objAngajat.PASSerie.ToString() != " ") )
						ProcessNodes("BuletinSerie",objAngajat.PASSerie.ToString());
					else
						ProcessNodes("BuletinSerie","-");

					//numarul pasaportului
					if((objAngajat.PASNumar.ToString()!=" ")&&(objAngajat.PASNumar.ToString() != "0"))
						ProcessNodes("BuletinNr",objAngajat.PASNumar.ToString());
					else
						ProcessNodes("BuletinNr","-");

					//data eliberarii pasaportului
					if(objAngajat.PASDataEliberarii.Date==DateTime.MinValue)
						ProcessNodes("BuletinDataElib","-");
					else
						ProcessNodes("BuletinDataElib",objAngajat.PASDataEliberarii.Date.ToString("dd.MM.yyyy"));

					//buletin eliberat de
					if ( (objAngajat.CIEliberatDe != null) && (objAngajat.CIEliberatDe.ToString() != " ") )
						ProcessNodes("BuletinElibDe",objAngajat.CIEliberatDe.ToString());
					else
						ProcessNodes("BuletinDataElib","-");
					
					//numar de identificare fiscala angajat sau CNP
					if ( (objAngajat.NIF != null) && (objAngajat.NIF.ToString() != "0") )
						ProcessNodes("CNP",objAngajat.NIF.ToString());
					else
						ProcessNodes("CNP","-");
					if (objAngajat.CNP.ToString() != "0")
						ProcessNodes("CNP",objAngajat.CNP.ToString());
					else
						ProcessNodes("CNP","-");
				}
				//date permis de munca
				//serie permis de munca
				ProcessNodes("PermisMuncaSeria","-");
				//data eliberarii permisului de munca
				ProcessNodes("PermisMuncaDinData","-");

				RemoveNode("PasaportText");
				RemoveNode("PermisMuncaText");
			}
			//adresa angajator
			Salaries.Business.AdminAngajator objAngajator = new Salaries.Business.AdminAngajator();
			objAngajator.AngajatorId = objAngajat.AngajatorId;
			DataRow rowAngajator = objAngajator.LoadInfoAngajator().Tables[0].Rows[0];
			//strada
			ProcessNodes("AngAdresaStr", rowAngajator["Strada"].ToString());
			//numar
			ProcessNodes("AngAdresaNr", rowAngajator["Numar"].ToString());
			//bloc
			if(rowAngajator["Bloc"].ToString()!="")
				ProcessNodes("AngAdresaBl", rowAngajator["Bloc"].ToString());
			else
				ProcessNodes("AngAdresaBl","-");
			//scara
			if(rowAngajator["Scara"].ToString()!="")
				ProcessNodes("AngAdresaSc", rowAngajator["Scara"].ToString());
			else
				ProcessNodes("AngAdresaSc","-");

			//apartament
			if(rowAngajator["Apartament"].ToString()!="")
				ProcessNodes("AngAdresaAp", rowAngajator["Apartament"].ToString());
			else
				ProcessNodes("AngAdresaAp","-");
			//telefon/fax
			string tel="",fax="";
			if(rowAngajator["Telefon"].ToString() != "")
				tel=rowAngajator["Telefon"].ToString();
			else
				tel="-";
			if(rowAngajator["Fax"].ToString() != "")
				fax=rowAngajator["Fax"].ToString();
			else
				fax="-";
			ProcessNodes("AngTelFax",tel+","+fax);

			string localitate = "";
			string judet = "";
			if(rowAngajator["Localitate"].ToString() != "")
				localitate = rowAngajator["Localitate"].ToString();
			else
				localitate = "-";
			if(rowAngajator["Judet"].ToString() != "")
				judet = rowAngajator["Judet"].ToString();
			else
				judet = "-";
			ProcessNodes("AngAdresaLocalitate", localitate);
			ProcessNodes("AngAdresaJudet", judet);

			//numar inregistrare registrul comertului
			ProcessNodes("NrInregORC",rowAngajator["NrInregOrc"].ToString());
			//CUI
			ProcessNodes("CUI",rowAngajator["CUI_CNP"].ToString());
			//ziua in care se plateste salariul
			if(rowAngajator["ZiLichidareSalar"].ToString().ToString()!="")
				ProcessNodes("AngZiSalar",rowAngajator["ZiLichidareSalar"].ToString());			
			else
				ProcessNodes("AngZiSalar","-");
		}
		
		//comunicare prima
		public void ProcessPrima()
		{
			// Departament-ul din care face parte angajatul.
			if(objAngajat.DepartamentCurentDenumire!="")
			{
				ProcessNodes("Departament", objAngajat.DepartamentCurentDenumire);
			}
			else
			{
				ProcessNodes("Departament", "-");
			}
			
			//data, luna curenta, an curent
			date = Session["DataInregistrarii"].ToString();
			ProcessNodes("DataInregistrarii", date);
			//este aflata luna activa
			Salaries.Business.Luni luni = new Salaries.Business.Luni(objAngajat.AngajatorId);
			Salaries.Data.LunaData lunaData= luni.GetLunaActiva();
			
			ProcessNodes("LunaCurenta", lunaData.Data.Month.ToString());
			//numarul comunicarii
			ProcessNodes("Numar", Session["Numar"].ToString());
			//prima(suma)
			if (Session["Suma"] != null)
			{
				ProcessNodes("SumaPrima", Session["Suma"].ToString());
			}

			//date despre angajator
			ProcessAngajator();	
		}

		//comunicare indexare
		public void ProcessIndexare()
		{
			//date despre angajator
			ProcessAngajator();
			
			Salaries.Business.Luni luni=new Salaries.Business.Luni(objAngajat.AngajatorId);
			Salaries.Data.LunaData lunaData= luni.GetLunaActiva();

			//data inregistrarii
			ProcessNodes("DataInregistrarii",Session["DataInregistrarii"].ToString());
			
			//luna curenta
			ProcessNodes("LunaCurenta", lunaData.Data.Month.ToString()+"/"+lunaData.Data.Year.ToString());

			//data inceperii [Data inceperii]
			ProcessNodes("DataInceperii", lunaData.Data.Month.ToString()+"/"+lunaData.Data.Year.ToString());

			//numarul comunicarii
			ProcessNodes("Numar", Session["Numar"].ToString());
			
			//anul curent
			string anCurent = DataCurenta.ToString("yyyy", new System.Globalization.CultureInfo("ro-RO"));
			ProcessNodes("AnCurent", anCurent);
			
			//este stabilit trimestrul
			switch(int.Parse(luni.GetLunaActiva().Data.Month.ToString()))
			{
				case LUNA_INDEXARE_1:
					ProcessNodes("TrimAnterior", "I");
					break;
				case LUNA_INDEXARE_2:
					ProcessNodes("TrimAnterior", "al II-lea");
					break;
			}
			
			//data inceperii indexarii
			ProcessNodes("DataInceperii", luni.GetLunaActiva().Data.Month.ToString()+"/"+luni.GetLunaActiva().Data.Year.ToString());
			
			//salariu brut+indemnizatie de conducere [SalariuBrut]
			float noulSalariuBrut=float.Parse(Session["SalariuIncadrare"].ToString())+float.Parse(objAngajat.IndemnizatieConducere.ToString());
			ProcessNodes("SalariuBrut", noulSalariuBrut.ToString());

			//indemnizatie de conducere[SalariuBrutIC]
			ProcessNodes("SalariuBrutIC", float.Parse(objAngajat.IndemnizatieConducere.ToString()).ToString());

			//salariu de incadrare [SalariuBrutSB]
			ProcessNodes("SalariuBrutSB", Session["SalariuIncadrare"].ToString());
			
			//procentul de indexare
			if(Session["ProcentIndexare"]!=null)
			{
				ProcessNodes("ProcentIndexare", Session["ProcentIndexare"].ToString());
			}
		}
		
		//comunicare indexare majorare
		public void ProcessIndexareMajorare()
		{
			//date despre angajator
			ProcessAngajator();
			
			Salaries.Business.Luni luni=new Salaries.Business.Luni(objAngajat.AngajatorId);
			Salaries.Data.LunaData lunaData= luni.GetLunaActiva();

			//data inregistrarii
			ProcessNodes("DataInregistrarii",Session["DataInregistrarii"].ToString());
			
			//luna curenta
			ProcessNodes("LunaCurenta", lunaData.Data.Month.ToString()+"/"+lunaData.Data.Year.ToString());

			//data inceperii [Data inceperii]
			ProcessNodes("DataInceperii", lunaData.Data.Month.ToString()+"/"+lunaData.Data.Year.ToString());

			//numarul comunicarii
			ProcessNodes("Numar", Session["Numar"].ToString());

			//anul curent
			string anCurent = lunaData.Data.Year.ToString();
			ProcessNodes("AnCurent", anCurent);
			
			//este stabilit trimestrul
			switch(int.Parse(luni.GetLunaActiva().Data.Month.ToString()))
			{
				case LUNA_INDEXARE_1:
					ProcessNodes("TrimAnterior", "I");	
					break;
				case LUNA_INDEXARE_2:
					ProcessNodes("TrimAnterior", "al II-lea");
					break;
			}
			
			//suma majorare
			if (Session["SumaMajorare"] != null)
			{
				ProcessNodes("SumaMajorare", Session["SumaMajorare"].ToString());
			}
			else
			{
				ProcessNodes("SumaMajorare", "0");
			}
	
			//salariu brut+indemnizatie de conducere [SalariuBrut]
			decimal salariuTotal = objAngajat.SalariuBaza + objAngajat.IndemnizatieConducere;
			ProcessNodes("SalariuBrut", salariuTotal.ToString());

			//indemnizatie de conducere[SalariuBrutIC]
			ProcessNodes("SalariuBrutIC", objAngajat.IndemnizatieConducere.ToString());

			//salariu de incadrare [SalariuBrutSB]
			ProcessNodes("SalariuBrutSB", objAngajat.SalariuBaza.ToString());
			
			//procentul de indexare
			if(Session["ProcentIndexare"]!=null)
				ProcessNodes("ProcentIndexare", Session["ProcentIndexare"].ToString());
		}

		//comunicare prelungire cim
		public void ProcessPrelungireCIM()
		{
			//numar comunicare
			ProcessNodes("Numar", "Nr. "+Session["NumarComunicare"].ToString());
			//marca
			ProcessNodes("Marca", objAngajat.Marca);
			//data curenta
			ProcessNodes("DataGenerarii", DateTime.Today.ToString("dd.MM.yyyy"));
			//prenume
			ProcessNodes("Prenume", objAngajat.Prenume);
			//nume
			ProcessNodes("Nume", objAngajat.Nume);
			//data angajarii
			ProcessNodes("DataAngajarii", objAngajat.DataDeLa.ToString("dd.MM.yyyy"));
			//stimate domnule/stimata doamna
			string adresare = objAngajat.Sex == "m" ? "Stimate Domnule" :
				objAngajat.StareCivila.CompareTo(zero) == 0 ? "Stimata Doamna" : "Stimata Domnisoara";
			ProcessNodes("Adresare", adresare);
			//pana la data
			if(objAngajat.PerioadaDeterminata==true)
				ProcessNodes("DataPanaLa", objAngajat.DataPanaLa.ToString("dd.MM.yyyy"));
			else
				ProcessNodes("DataPanaLa", "nedeterminat");
		}
		
		//comunicare majorari
		public void ProcessMajorari()
		{
			// Suma cu care a fost majorat salariul brut.
			float majorareSalariuBrut = 0;
			// Suma cu care a fost majorata indemnizatia de conducere.
			float majorareIndemnizatieConducere = 0;
			// Suma majorarilor.
			float totalMajorari = 0;
			// Salariu de incadrate + indemnizatia de conducere.
			float totalSalariu = 0;
			// Salariul de incadrare actual.
			float salariuIncadrare = 0;
			// Indemnizatia de conducere actuala.
			float indemnizatieConducere = 0;
			// Salariul de incadrare anterior.
			float salariuIncadrareAnterior = 0;
			// Indemnizatia de conducere anterioara.
			float indemnizatieConducereAnt = 0;

			//date despre angajator
			ProcessAngajator();
			
			ProcessNodes("Numar", Session["Numar"].ToString());

			// Suma majorare salariu brut.
			if (Session["SumaMajorareSalariuBrut"] != null)
			{
				salariuIncadrare = float.Parse(objAngajat.SalariuBaza.ToString());
				salariuIncadrareAnterior = float.Parse(Session["SalariuBrutAnterior"].ToString());

				majorareSalariuBrut =float.Parse(Session["SumaMajorareSalariuBrut"].ToString());

				ProcessNodes("SumaMajorareSB", majorareSalariuBrut.ToString());
			}
			else
			{
				ProcessNodes("SumaMajorareSB", "0");
			}
			
		
			if (Session["IndemnizatieConducereAnterioara"] != null)
			{
				indemnizatieConducere = float.Parse(objAngajat.IndemnizatieConducere.ToString());
				indemnizatieConducereAnt = float.Parse(Session["IndemnizatieConducereAnterioara"].ToString()) ;
				
				majorareIndemnizatieConducere = indemnizatieConducere - indemnizatieConducereAnt;
				
				ProcessNodes("SumaMajorareIC", majorareIndemnizatieConducere.ToString());
			}	
			else
			{
				ProcessNodes("SumaMajorareIC", "0");
			}

			// Suma majorari.
			totalMajorari = majorareSalariuBrut + majorareIndemnizatieConducere;
			
			ProcessNodes("SumaMajorare", totalMajorari.ToString());
			
			// salariu brut+indemnizatie de conducere [SalariuBrut]
			totalSalariu =  salariuIncadrare + indemnizatieConducere;
			ProcessNodes("SalariuBrut", totalSalariu.ToString());

			// Indemnizatia de conducere[SalariuBrutIC]
			ProcessNodes("SalariuBrutIC", indemnizatieConducere.ToString());

			// Salariu de incadrare [SalariuBrutSB]
			ProcessNodes("SalariuBrutSB", salariuIncadrare.ToString());

			// Este aflata luna activa.
			Salaries.Business.Luni luni = new Salaries.Business.Luni(objAngajat.AngajatorId);
			Salaries.Data.LunaData lunaData= luni.GetLunaActiva();
			ProcessNodes("LunaCurenta", lunaData.Data.Month.ToString()+"/"+lunaData.Data.Year.ToString());

			// data inceperii [Data inceperii]
			// luna activa
			ProcessNodes("DataInceperii", lunaData.Data.Month.ToString()+"/"+lunaData.Data.Year.ToString());
			
			// Data inregistrarii.
			date = Session["DataInregistrarii"].ToString();
			ProcessNodes("DataInregistrarii", date);
		}

		//fisa postului
		public void ProcessFisaPostului()
		{
			//date despre angajator
			ProcessAngajator();

			if (Session["ManagerHR"] != null)
			{
				ProcessNodes("NumeManagerHR", Session["ManagerHR"].ToString());
			}
			else
			{
				ProcessNodes("NumeManagerHR", " ");
			}
			
			//Numele intreg al sefului
			string sef=objAngajat.SefId.ToString();
			if((sef!="")&&(sef!="0"))
			{
				objSefAngajat = new Salaries.Business.Angajat();
				objSefAngajat.AngajatId = int.Parse(sef);
				objSefAngajat.LoadAngajat();
			
				ProcessNodes("NumeSef", objSefAngajat.Nume+" "+objSefAngajat.Prenume);
			}
			else
				ProcessNodes("NumeSef", "NuAreSef");
			ProcessNodes("DataInregistrarii", Session["DataInregistrarii"].ToString());
		}

		//Dovlecel Vlad
		public void ProcessLichidare()
		{
			ProcessNodes("SerieCarnetMunca", objAngajat.CMSerie );//seria carnetului de munca
			ProcessNodes("DenumireAngajator", objAngajat.NumeAngajator);//denumirea angajatorului
			//numarul comunicarii
			ProcessNodes("NrInregistrare", Session["NrInregistrare"].ToString());
			string dataLichidariiString = ((DateTime)Session["DataLichidare"]).ToString("d MMMM yyyy", new System.Globalization.CultureInfo("ro-RO"));
			ProcessNodes("DataLichidare", dataLichidariiString);

			string dataInregistrareString = ((DateTime)Session["DataInregistrare"]).ToString("d MMMM yyyy", new System.Globalization.CultureInfo("ro-RO"));
			ProcessNodes("DataInregistrarii", dataInregistrareString);

			ProcessNodes("NrArticol", Session["NrArticol"].ToString());

			ProcessNodes("AvansDecontare", Session["AvansDecontare"].ToString());
			ProcessNodes("Abonamente", Session["Abonamente"].ToString());
			ProcessNodes("TicheteMasa", Session["TicheteMasa"].ToString());
			ProcessNodes("EchipamentLucru", Session["EchipamentLucru"].ToString());
			ProcessNodes("Laptop", Session["Laptop"].ToString());
			ProcessNodes("TelefonServiciu", Session["TelefonServiciu"].ToString());
			ProcessNodes("ObiecteInventar", Session["ObiecteInventar"].ToString());
			ProcessNodes("Carti", Session["Carti"].ToString());
			ProcessNodes("CDuri", Session["CDuri"].ToString());

			string lunaRetinereString = ((DateTime)Session[ "LunaRetinere"]).ToString("MMMM yyyy", new System.Globalization.CultureInfo("ro-RO"));
			if (lunaRetinereString == "ianuarie 0001")
			{
				lunaRetinereString = "-";
			}
			ProcessNodes("NumeLuna", lunaRetinereString);
			
			//calcularea tuturor numerelor zilelor de concediu din "Nota de lichidare.xml"

			int nrZileConFaraPlataAbs = GetNrZileTotalConcediuFaraPlataAbsenteNemotInvoiri();
			ProcessNodes( "NrZileConcediuFaraPlata", nrZileConFaraPlataAbs.ToString());

			string sss = nrZileConFaraPlataAbs.ToString();

			int nrZileDisponibileConcediuOdihna = GetNrZileDisponibileConcediiOdihna();
			ProcessNodes( "NrZileDisponibileConcediuOdihna", nrZileDisponibileConcediuOdihna.ToString());

			int nrZileEfectuateConcediuOdihna = GetNrZileEfectuateConcediiOdihna();
			ProcessNodes( "NrZileEfectuateConcediuOdihna", nrZileEfectuateConcediuOdihna.ToString());

			//int nrZileDiferentaConcediuOdihna = GetNrZileDiferentaConcediiOdihna();
			int nrZileDiferentaConcediuOdihna = nrZileDisponibileConcediuOdihna-nrZileEfectuateConcediuOdihna;
			ProcessNodes( "NrZileDiferentaConcediuOdihna", nrZileDiferentaConcediuOdihna.ToString());

			int nrZileConMedPlatit12Luni = GetNrZileConMedPlatitUltimele12Luni();
			ProcessNodes( "NrZileConcediuMedPlatit", nrZileConMedPlatit12Luni.ToString());
		}

		#endregion

		#region ProcessNodes si FillNodes
		public void ProcessNodes(string sNodeName, string sNodeValue)
		{
			XmlNodeList oNodeList = word.SelectNodes("//ns0:" + sNodeName + "//w:p",
				nsMgr);
			if (oNodeList.Count != 0)
				FillNodes(oNodeList, sNodeValue);
			oNodeList = word.SelectNodes("//ns0:" + sNodeName, nsMgr);
			if (oNodeList.Count != 0)
				FillNodes(oNodeList, sNodeValue);

		}

		private void FillNodes(XmlNodeList oNodeList, string sNodeValue)
		{
			XmlNode oXMLNode, oInnerNode;
			for (int i= 0; i < oNodeList.Count; i++)
			{
				oXMLNode = oNodeList[i];
				oInnerNode = oXMLNode.SelectSingleNode("w:r/w:t", nsMgr);
				if (oInnerNode != null)
					oInnerNode.InnerText = sNodeValue;
			}
		}

		public void RemoveNode(string sNodeName)
		{
			XmlNodeList oNodeList = word.SelectNodes("//ns0:" + sNodeName + "//w:p",
				nsMgr);
			if (oNodeList.Count != 0)
			{
				foreach(XmlNode node in oNodeList)
				{
					XmlNode parent = node.ParentNode;
					node.ParentNode.RemoveChild(node);
				}
			}
			oNodeList = word.SelectNodes("//ns0:" + sNodeName, nsMgr);
			if (oNodeList.Count != 0)
			{
				foreach(XmlNode node in oNodeList)
				{
					XmlNode parent = node.ParentNode;
					node.ParentNode.RemoveChild(node);
				}
			}

		}

		#endregion
	
		#region Private methods for Lichidare

		private int GetNrZileTotalConcediuFaraPlataAbsenteNemotInvoiri()
		{
			Salaries.Business.PontajAngajat pa = new Salaries.Business.PontajAngajat( idAngajat );

			DateTime dataPanaLa;
			if( objAngajat.PerioadaDeterminata )
			{
				dataPanaLa = objAngajat.DataPanaLa;
			}
			else
			{
				dataPanaLa = DateTime.MaxValue;
			}
			int nrZileInvoire = pa.GetAngajatNrZileAbsenteTipLuna( objAngajat.DataDeLa , dataPanaLa, codAbsente[ 1 ] );
			int nrZileAbsenteNemotivate = pa.GetAngajatNrZileAbsenteTipLuna( objAngajat.DataDeLa, dataPanaLa, codAbsente[ 6 ] );
			int nrZileConcediuFaraPlata = pa.GetAngajatNrZileAbsenteTipLuna( objAngajat.DataDeLa, dataPanaLa, codAbsente[ 7 ] );

			return nrZileInvoire+nrZileAbsenteNemotivate+nrZileConcediuFaraPlata;
		}

		private int GetNrZileDiferentaConcediiOdihna()
		{
			return GetNrZileDisponibileConcediiOdihna()-GetNrZileEfectuateConcediiOdihna();
		}

		//totalul zilelor de CO pe care si le putea lua un angajat de cand este angajat la firma
		private int GetNrZileDisponibileConcediiOdihna()
		{
			int nrZileDisp = 0;
			DateTime dataLichidare = (DateTime)Session[ "DataLichidare" ];
            
			Salaries.Business.PontajAngajat pa = new Salaries.Business.PontajAngajat( this.idAngajat );

			for( int i=objAngajat.DataDeLa.Year; i<=dataLichidare.Year-1; i++ )
			{
				nrZileDisp += pa.GetAngajatNrZileCODisponibileAn( new DateTime( i, 1, 1 ), new DateTime( i, 12, 31 ), objAngajat.AngajatorId );
			}
			nrZileDisp += pa.GetAngajatNrZileCODisponibileAn( new DateTime( dataLichidare.Year, 1, 1 ), new DateTime( dataLichidare.Year, dataLichidare.Month, dataLichidare.Day ), objAngajat.AngajatorId );

			return nrZileDisp;
		}

		//Numarul de zile de CO efectuate de catre un angajat de la inceputul contractului de munca
		private int GetNrZileEfectuateConcediiOdihna()
		{
			Salaries.Business.PontajAngajat pa = new Salaries.Business.PontajAngajat( idAngajat );

			DateTime dataPanaLa;
			if( objAngajat.PerioadaDeterminata )
			{
				dataPanaLa = objAngajat.DataPanaLa;
			}
			else
			{
				dataPanaLa = DateTime.MaxValue;
			}
			int nrZileConcediuOdihnaLuna = pa.GetAngajatNrZileAbsenteTipLuna( objAngajat.DataDeLa, dataPanaLa, codAbsente[ 2 ] );

			return nrZileConcediuOdihnaLuna;
		}

		//Numarul de zile de concediu medical platit pe ultimele 12 luni
		//momentan concediul medical platit este considerat ca fiind tot concediul medical luat
		private int GetNrZileConMedPlatitUltimele12Luni()
		{
			int nrZile = 0;
			Salaries.Business.PontajAngajat pa = new Salaries.Business.PontajAngajat( idAngajat );

			DateTime dataEnd = (DateTime)Session[ "DataLichidare" ];
			DateTime dataSt = dataEnd.AddMonths( -11 );
			dataSt = new DateTime( dataSt.Year, dataSt.Month, 1 );

			nrZile = pa.GetAngajatNrZileAbsenteTipLuna( dataSt, dataEnd, codAbsente[ 3 ] );
			nrZile += pa.GetAngajatNrZileAbsenteTipLuna( dataSt, dataEnd, codAbsente[ 4 ] );

			return nrZile;
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
