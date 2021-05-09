/*
 *	Modificat:		Oprescu Claudia 
 *	Data:			09.07.2007
 *	Descriere:		Au fost adaugate campuri pentru Motivul de angajare si pentru Tipul angajatului.
 * 
 *	Modificat:		Oprescu Claudia
 *	Data:			12.07.2007
 *	Descriere:		A fost adaugat camp pentru GID. 
 * 
 *  Modificat:		Oprescu Claudia
 *	Data:			19.09.2007
 *	Descriere:		Au fost adaugate campuri pentru PMP si AZM.
 * 
 *	Modificat:		Fratila Claudia
 *	Data:			29.11.2007
 *	Descriere:		A fost adaugat camp pentru Sanatate (specifica daca angajatul este scutit sau nu de contributia la sanatate).
 *					A fost adaugat camp pentru CAS (specifica daca angajatul este scutit sau nu de contributia la CAS).
 * 
 *	Modificat:		Andreea Lungu
 *	Data:			23.08.2010
 *	Descriere:		A fost adaugat camp pentru Birou 
 * 
 *  Modificat:		Andreea Lungu
 *	Data:			15.02.2011
 *	Descriere:		A fost adaugat camp pentru Data schimbarii numelui si pentru Somaj (specifica daca anajatul este scutit sau nu de contributia la somaj)
 * 
 *  Modificat:		Manuel Neagoe
 *	Data:			29.01.2013
 *	Descriere:		A fost adaugat campul Tip Asigurat. 

*/

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Salaries.Business
{
	/// <summary>
	/// Administrarea angajatilor.
	/// </summary>
	public class Angajat
	{
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;

		#region Variabile
		#region Variables for Angajati table		
		// from Angajati table
		private long angajatId;
		private int angajatorId;
		private int punctLucruId;
		private int casaDeAsigurariId;
		private int motivDeAngajareId;
		private int tipDeAngajatId;
		private string marca;
		private string gid;
		private string nume;
		private string prenume;
		private string numeAnterior;
		private DateTime dataSchimbariiNumelui;
		private int titluId;
		private string titluSimbol;
		private string prenumeTata;
		private string prenumeMama;
		private int studiuId;
		private int anAbsolvire;
		private string nrDiploma;
		private string descriere;
		private byte modIncadrare;
		private byte programLucru;
		private string telefon;
		private DateTime dataNasterii;
		private int judetNastereId;
		private int taraNastereId;
		private string localitateNastere;
		private byte stareCivila;
		private byte nrCopii;
		private string sex;
		private int nationalitate;
		private long cnp;
		private string cnpAnterior;
		private byte tipFisaFiscala;
		private byte aniVechimeMunca;
		private byte luniVechimeMunca;
		private int zileVechimeMunca;
		private byte areCardBancar;
		private byte[] pozaAngajat;
		private string functieCurentaNume;
		private string functieCurentaCod;
		private int functieCurentaId;
		private int departamentCurentId;
		private string departamentCurentDenumire;
		private string departamentCurentCod;
		private long sefId;
		private string numeAngajator;
		private string evidentaCMJ;
		private	DateTime dataIntrareEvidenta; 
		private	string gradul;
		private	string serieLivret; 
		private string numarLivret; 
		private string specialitatiMilitare;
		private bool perioadaDeterminata;
		private DateTime dataPanaLa;
		private DateTime dataDeLa;
		private string nrContractMunca;
		private DateTime dataInregContractMunca;
		private string echIndProtectie;
		private string echIndLucru;
		private string matIgiSan;
		private string alimProtectie;
		private string alteDrSiObl;
		private string alteClauzeCIM;
		private string perProba;
		private short invaliditate;
		private decimal salariuBaza;
		private decimal indemnizatieConducere;
		private decimal sporuri;
		private decimal alteAdaosuri;
		private decimal sumaMajorare;
		private DateTime dataMajorare;
		private int nrZileCOAn;
		private int nrZileCOSupl;
		private int categorieId;
		private string email;
		private string telMunca;
		private bool isLichidat;
		private DateTime dataLichidare;
		private bool isPensionat;
		private string birou;
		private int tipAsiguratId;
		#endregion

		#region Variables for CartiIdentitate table
		// from CartiIdentitate table
		private string ciSerie;
		private string ciNumar;
		private string ciEliberatDe;
		private DateTime ciDataEliberarii;
		private DateTime ciValabilPanaLa;
		#endregion

		#region Variable for Pasapoarte table
		// from Pasapoarte table
		private string pasSerie;
		private string pasNumar;
		private string pasEliberatDe;
		private DateTime pasDataEliberarii;
		private DateTime pasValabilPanaLa;

		//private long NrPermisMunca;
		#endregion

		#region Variable for PermiseMunca table		
		private DateTime permMuncaEliberat;
		private DateTime permMuncaExpira;
		//private DateTime permSedereEliberat;
		//private DateTime permSedereExpira;
		//private DateTime permMuncaDataEliberare;
		//private DateTime permMuncaDataExpirare;
		private string seriePermisMunca;
		private long nrPermisMunca;
		#endregion

		#region Variable for LegitimatiiSedere table
		private DateTime legitimatieSedereDataEliberare;
		private DateTime legitimatieSedereDataExpirare;
		private string serieLegitimatieSedere;
		private string nrLegitimatieSedere;
		#endregion

		#region Variable for NIF table
		private string nif;
		private int tipNationalitateDomiciliu;
		#endregion

		#region Variables for Domicilii table
		// from Domicilii table - 
		// D = domiciliu
		private int dTara;
		private string dLocalitate;
		private int dJudetSectorId;
		private string dStrada;
		private string dNumar;
		private long dCodPostal;
		private string dBloc;
		private string dScara;
		private string dEtaj;
		private string dApartament;
		// R = resedinta
		private int rTara;
		private string rLocalitate;
		private int rJudetSectorId;
		private string rStrada;
		private string rNumar;
		private long rCodPostal;
		private string rBloc;
		private string rScara;
		private string rEtaj;
		private string rApartament;
		#endregion

		#region Variables for CarneteMunca table
		private string cmSerie;
		private string cmNumar;
		private string cmEmitent;
		private DateTime cmDataEmiterii;
		private string cmNrInregITM;
		#endregion

		#region Variables for Alerte Speciale
		private string alerteSpeciale;
		private bool pmp;
		private bool azm;
		private bool retinereSanatate;
		private bool retinereCAS;
		private bool retinereSomaj;
		#endregion
		#endregion

		#region Proprietati
		#region Set/Get properties for fields from Angajati table
		public long AngajatId
		{
			get { return angajatId; }
			set { angajatId = value; }
		}

		public int PunctLucruId
		{
			get { return punctLucruId; }
			set { punctLucruId = value;}
		}

		public int CasaDeAsigurariId
		{
			get { return casaDeAsigurariId; }
			set { casaDeAsigurariId = value; }
		}

		public int TipAsiguratId
		{
			get { return tipAsiguratId; }
			set { tipAsiguratId = value; }
		}

		public int MotivDeAngajareId
		{
			get { return motivDeAngajareId; }
			set { motivDeAngajareId = value; }
		}

		public int TipDeAngajatId
		{
			get { return tipDeAngajatId; }
			set { tipDeAngajatId = value; }
		}

		public string NumeAngajator
		{
			get { return numeAngajator; }
			set	{ numeAngajator = value; }
		}

		public int AngajatorId
		{
			get { return angajatorId; }
			set { angajatorId = value; }
		}
		
		public string Marca
		{
			get { return marca; }
			set { marca = value; }
		}

		public string Gid
		{
			get { return gid; }
			set { gid = value; }
		}

		public string Nume
		{
			get	{ return nume; }
			set	{ nume = value; }
		}

		public string Prenume
		{
			get { return prenume; }
			set { prenume = value; }
		}

		public string NumeAnterior
		{
			get { return numeAnterior; }
			set { numeAnterior = value; }
		}

		public DateTime DataSchimbariiNumelui
		{
			get{return dataSchimbariiNumelui; }
			set{dataSchimbariiNumelui = value;}
		}

		public int TitluId
		{
			get { return titluId; }
			set { titluId = value; }
		}

		public string TitluSimbol
		{
			get { return titluSimbol; }
			set { titluSimbol = value; }
		}
		public string PrenumeMama
		{
			get { return prenumeMama; }
			set { prenumeMama = value; }
		}

		public string PrenumeTata
		{
			get { return prenumeTata;}
			set { prenumeTata = value;}
		}

		public int StudiuId
		{
			get { return studiuId;}
			set { studiuId = value;}
		}

		public int AnAbsolvire
		{
			get	{ return anAbsolvire; }
			set { anAbsolvire = value; }
		}

		public string NrDiploma
		{
			get	{ return nrDiploma; }
			set { nrDiploma = value; }
		}

		public string Descriere
		{
			get	{ return descriere; }
			set { descriere = value; }
		}

		public byte ModIncadrare
		{
			get { return modIncadrare;}
			set { modIncadrare = value;}
		}

		public byte ProgramLucru
		{
			get { return programLucru;}
			set { programLucru = value; }
		}
		
		public string Telefon
		{
			get { return telefon; }
			set { telefon = value; }
		}

		public DateTime DataNasterii
		{
			get { return dataNasterii; }
			set { dataNasterii = value; }
		}
		public int JudetNastereId
		{
			get { return judetNastereId; }
			set { judetNastereId = value;}
		}
		public int TaraNastereId
		{
			get { return taraNastereId; }
			set { taraNastereId = value; }
		}
		public string LocalitateNastere
		{
			get { return localitateNastere;}
			set { localitateNastere = value; }
		}

		public byte StareCivila
		{
			get { return stareCivila; }
			set { stareCivila = value; }
		}
		public byte NrCopii
		{
			get { return nrCopii; }
			set { nrCopii = value; }
		}

		public string Sex
		{
			get	{ return sex; }
			set { sex = value; }
		}
		public int Nationalitate
		{
			get { return nationalitate; }
			set { nationalitate = value; }
		}
		public long CNP
		{
			get	{ return cnp; }
			set { cnp = value; }
		}

		public string CNPAnterior
		{
			get { return cnpAnterior; }
			set { cnpAnterior = value; }
		}

		public byte TipFisaFiscala
		{
			get	{ return tipFisaFiscala;}
			set { tipFisaFiscala = value; }
		}

		public byte AniVechimeMunca
		{
			get { return aniVechimeMunca;}
			set { aniVechimeMunca = value;}
		}
		public byte LuniVechimeMunca
		{
			get { return luniVechimeMunca; }
			set { luniVechimeMunca = value;}
		}
		public int ZileVechimeMunca
		{
			get { return zileVechimeMunca; }
			set { zileVechimeMunca = value;}
		}

		public byte AreCardBancar
		{
			get { return areCardBancar; }
			set { areCardBancar = value;}
		}

		public byte[] PozaAngajat
		{
			get { return pozaAngajat;}
			set { pozaAngajat = value;}
		}

		public int FunctieCurentaId
		{
			get { return functieCurentaId;}
			set { functieCurentaId = value;}
		}
	
		public string FunctieCurentaNume
		{
			get{ return functieCurentaNume;}
			set {functieCurentaNume = value;}
		}
		public string FunctieCurentaCod
		{
			get {return functieCurentaCod;}
			set {functieCurentaCod = value;}
		}

		public int DepartamentCurentId
		{
			get {return departamentCurentId;}
			set {departamentCurentId = value;}
		}
		public string DepartamentCurentDenumire
		{
			get
			{return departamentCurentDenumire;}
			set
			{departamentCurentDenumire = value;}
		}
		public string DepartamentCurentCod
		{
			get {return departamentCurentCod;}
			set {departamentCurentCod = value;}
		}

		public bool PerioadaDeterminata
		{
			get{ return perioadaDeterminata;}
			set{ perioadaDeterminata=value; }
		}

		public DateTime DataPanaLa
		{
			get{return dataPanaLa; }
			set{dataPanaLa=value;}
		}

		public DateTime DataDeLa
		{
			get{return dataDeLa; }
			set{dataDeLa=value;}
		}

		public DateTime DataInregContractMunca
		{
			get{return dataInregContractMunca; }
			set{dataInregContractMunca=value;}
		}

		public string NrContractMunca
		{
			get{return nrContractMunca; }
			set{nrContractMunca=value;}
		
		}
		//echipament individual de protectie
		public string EchIndProtectie
		{
			get{return echIndProtectie; }
			set{echIndProtectie=value;}
		
		}
		//echipament individual de lucru
		public string EchIndLucru
		{
			get{return echIndLucru; }
			set{echIndLucru=value;}
		
		}
		//materiale igienico sanitare
		public string MatIgiSan
		{
			get{return matIgiSan; }
			set{matIgiSan=value;}
		
		}
		//alimentatie de protectie
		public string AlimProtectie
		{
			get{return alimProtectie; }
			set{alimProtectie=value;}
		}
		
		//alte drepturi si obligatii privind sanatatea in munca
		public string AlteDrSiObl
		{
			get{return alteDrSiObl; }
			set{alteDrSiObl=value;}
		}

		//alte clauze ale contactului individual de munca
		public string AlteClauzeCIM
		{
			get{return alteClauzeCIM; }
			set{alteClauzeCIM=value;}
		}

		//perioada de proba
		public string PerProba
		{
			get{return perProba; }
			set{perProba=value;}
		}

		// retriving and setting SefId private variable
		public long SefId
		{
			get { return sefId;}
			set { sefId = value;}
		}

		public string EvidentaCMJ
		{
			get { return evidentaCMJ;}
			set { evidentaCMJ = value;}
		}
		public DateTime DataIntrareEvidenta
		{
			get { return dataIntrareEvidenta;}
			set { dataIntrareEvidenta = value;}
		}

		public string Gradul
		{
			get { return gradul;}
			set { gradul = value;}
		}
		public string SerieLivret
		{
			get { return serieLivret;}
			set { serieLivret = value;}
		}
		public string NumarLivret
		{
			get { return numarLivret;}
			set { numarLivret = value;}
		}
		public string SpecialitatiMilitara
		{
			 get { return specialitatiMilitare;}
			 set { specialitatiMilitare = value;}
		}
		public short Invaliditate
		{
			get{return invaliditate;}
			set{invaliditate=value;}
		}

		public decimal SalariuBaza
		{
			get{return salariuBaza;}
			set{salariuBaza=value;}
		}

		public decimal IndemnizatieConducere
		{
			get{return indemnizatieConducere;}
			set{indemnizatieConducere=value;}
		}
		
		//sporuri
		public decimal Sporuri
		{
			get{return sporuri;}
			set{sporuri=value;}
		}

		//alte adaosuri
		public decimal AlteAdaosuri
		{
			get{return alteAdaosuri;}
			set{alteAdaosuri=value;}
		}
		public decimal SumaMajorare
		{
			get{return sumaMajorare;}
			set{sumaMajorare=value;}
		}
        
		public DateTime DataMajorare
		{
			get{return dataMajorare;}
			set {dataMajorare=value;}
		}

		public int NrZileCOAn
		{
			get{return nrZileCOAn;}
			set{nrZileCOAn=value;}
		}

		//numarul de zile de concediu de odihna suplimentar(pe an)
		public int NrZileCOSupl
		{
			get{return nrZileCOSupl;}
			set{nrZileCOSupl=value;}
		}

		public int CategorieId
		{
			get{return categorieId;}
			set{categorieId=value;}
		}
		public string Email
		{
			get {return email;}
			set {email = value;}
		}
		public string TelMunca
		{
			get { return telMunca;	}
			set { telMunca = value;}
		}
		
		public bool IsLichidat
		{
			get {return isLichidat;}
			set {isLichidat = value;}
		}

		public DateTime DataLichidare
		{
			get {return dataLichidare;}
			set {dataLichidare = value;}
		}

		public bool IsPensionat
		{
			get {return isPensionat;}
			set {isPensionat = value;}
		}

		public string Birou
		{
			get	{return birou;}
			set	{birou = value;}
		}
		#endregion

		#region Set/Get properties for fields from CartiIndentitate table
		// retriving and setting Serie private variable
		public string CISerie
		{
			get{return ciSerie;}
			set	{ciSerie = value;}
		}
		// retriving and setting Numar private variable
		public string CINumar
		{
			get{return ciNumar;}
			set{ciNumar = value;}
		}
		// retriving and setting EliberatDe private variable
		public string CIEliberatDe
		{
			get{return ciEliberatDe;}
			set{ciEliberatDe = value;}
		}
		// retriving and setting DataEliberarii private variable
		public DateTime CIDataEliberarii
		{
			get{return ciDataEliberarii;}
			set{ciDataEliberarii = value;}
		}
		// retriving and setting ValabilPanaLa private variable
		public DateTime CIValabilPanaLa
		{
			get{return ciValabilPanaLa;}
			set{ciValabilPanaLa = value;}
		}
		#endregion

		#region Set/Get properties for fields from Pasapoarte table
		// retriving and setting Serie private variable
		public string PASSerie
		{
			get{return pasSerie;}
			set{pasSerie = value;}
		}
		// retriving and setting Numar private variable
		public string PASNumar
		{
			get{return pasNumar;}
			set{pasNumar = value;}
		}
		// retriving and setting EliberatDe private variable
		public string PASEliberatDe
		{
			get{return pasEliberatDe;}
			set{pasEliberatDe = value;}
		}
		// retriving and setting DataEliberarii private variable
		public DateTime PASDataEliberarii
		{
			get{return pasDataEliberarii;}
			set{pasDataEliberarii = value;}
		}
		// retriving and setting ValabilPanaLa private variable
		public DateTime PASValabilPanaLa
		{
			get{return pasValabilPanaLa;}
			set{pasValabilPanaLa = value;}
		}
		
		#endregion

		#region Set/Get properties for fields from PermiseMunca
		public DateTime PermMuncaExpira
		{
			get{return permMuncaExpira;}
			set{permMuncaExpira=value;}
		}
		public DateTime PermMuncaEliberat
		{
			get{return permMuncaEliberat;}
			set{permMuncaEliberat=value;}
		}
		/*public DateTime PermSedereEliberat
		{
			get{return permSedereEliberat;}
			set{permSedereEliberat=value;}
		}
		public DateTime PermSedereExpira
		{
			get{return permSedereExpira;}
			set{permSedereExpira=value;}
		}
		public DateTime PermMuncaDataExpirare
		{
			get{return permMuncaDataExpirare;}
			set{permMuncaDataExpirare=value;}
		}

		public DateTime PermMuncaDataEliberare
		{
			get{return permMuncaDataEliberare;}
			set{permMuncaDataEliberare=value;}
		}*/

		public string SeriePermisMunca
		{
			get{return seriePermisMunca;}
			set{seriePermisMunca = value;}
		}
		
		public long NrPermisMunca
		{
			get	{return nrPermisMunca;}
			set{nrPermisMunca = value;}
		}
		#endregion

		#region Set/Get properties for fields from LegitimatiiSedere
		public DateTime LegitimatieSedereDataExpirare
		{
			get{return legitimatieSedereDataExpirare;}
			set{legitimatieSedereDataExpirare=value;}
		}

		public DateTime LegitimatieSedereDataEliberare
		{
			get{return legitimatieSedereDataEliberare;}
			set{legitimatieSedereDataEliberare=value;}
		}

		public string SerieLegitimatieSedere
		{
			get{return serieLegitimatieSedere;}
			set{serieLegitimatieSedere = value;}
		}
		
		public string NrLegitimatieSedere
		{
			get{return nrLegitimatieSedere;}
			set{nrLegitimatieSedere = value;}
		}
		#endregion

		#region Set/Get properties for fields from NIF
		public string NIF
		{
			get{return nif;}
			set{nif = value;}
		}

		public int TipNationalitateDomiciliu
		{
			get{return tipNationalitateDomiciliu;}
			set{tipNationalitateDomiciliu = value;}
		}
		#endregion

		#region Set/Get properties for fields from Alerte Speciale
		public string AlerteSpeciale
		{
			get{return alerteSpeciale;}
			set{alerteSpeciale = value;}
		}
		public bool PMP
		{
			get{return pmp;}
			set{pmp = value;}
		}
		public bool AZM
		{
			get{return azm;}
			set{azm = value;}
		}
		public bool RetinereSanatate
		{
			get{return retinereSanatate;}
			set{retinereSanatate = value;}
		}
		public bool RetinereCAS
		{
			get{return retinereCAS;}
			set{retinereCAS = value;}
		}
		public bool RetinereSomaj
		{
			get{return retinereSomaj;}
			set{retinereSomaj = value;}
		}
		#endregion

		#region Set/Get properties for fields from Domicilii table
		// retriving and setting DTara private variable
		public int DTara
		{
			get{return dTara;}
			set{dTara = value;}
		}
		// retriving and setting dLocalitate private variable
		public string DLocalitate
		{
			get{return dLocalitate;}
			set{dLocalitate = value;}
		}
		// retriving and setting dJudetSectorId private variable
		public int DJudetSectorId
		{
			get	{return dJudetSectorId;}
			set{dJudetSectorId = value;}
		}
		// retriving and setting dStrada private variable
		public string DStrada
		{
			get	{return dStrada;}
			set{dStrada = value;}
		}
		// retriving and setting dNumar private variable
		public string DNumar
		{
			get{return dNumar;}
			set{dNumar = value;}
		}
		// retriving and setting dCodPostal private variable
		public long DCodPostal
		{
			get{return dCodPostal;}
			set{dCodPostal = value;}
		}
		// retriving and setting dBloc private variable
		public string DBloc
		{
			get{return dBloc;}
			set{dBloc = value;}
		}
		// retriving and setting dScara private variable
		public string DScara
		{
			get{return dScara;}
			set{dScara = value;}
		}
		// retriving and setting dEtaj private variable
		public string DEtaj
		{
			get{return dEtaj;}
			set{dEtaj = value;}
		}
		// retriving and setting dApartament private variable
		public string DApartament
		{
			get{return dApartament;}
			set{dApartament = value;}
		}

		// retriving and setting RTara private variable
		public int RTara
		{
			get{return rTara;}
			set{rTara = value;}
		}

		// retriving and setting rLocalitate private variable
		public string RLocalitate
		{
			get{return rLocalitate;}
			set{rLocalitate = value;}
		}
		// retriving and setting rJudetSectorId private variable
		public int RJudetSectorId
		{
			get{return rJudetSectorId;}
			set{rJudetSectorId = value;}
		}
		// retriving and setting rStrada private variable
		public string RStrada
		{
			get{return rStrada;}
			set{rStrada = value;}
		}
		// retriving and setting rNumar private variable
		public string RNumar
		{
			get{return rNumar;}
			set{rNumar = value;}
		}
		// retriving and setting rCodPostal private variable
		public long RCodPostal
		{
			get{return rCodPostal;}
			set{rCodPostal = value;}
		}
		// retriving and setting rBloc private variable
		public string RBloc
		{
			get{return rBloc;}
			set{rBloc = value;}
		}
		// retriving and setting rScara private variable
		public string RScara
		{
			get{return rScara;}
			set{rScara = value;}
		}
		// retriving and setting rEtaj private variable
		public string REtaj
		{
			get{return rEtaj;}
			set{rEtaj = value;}
		}
		// retriving and setting rApartament private variable
		public string RApartament
		{
			get{return rApartament;}
			set{rApartament = value;}
		}

		#endregion

		#region Set/Get properties for fields from CarneteMunca table
		// retriving and setting cmSerie private variable
		public string CMSerie
		{
			get{return cmSerie;}
			set{cmSerie = value;}
		}
		// retriving and setting cmNumar private variable
		public string CMNumar
		{
			get{return cmNumar;}
			set{cmNumar = value;}
		}
		// retriving and setting cmEmitent private variable
		public string CMEmitent
		{
			get{return cmEmitent;}
			set{cmEmitent = value;}
		}
		// retriving and setting cmDataEmiterii private variable
		public DateTime CMDataEmiterii
		{
			get{return cmDataEmiterii;}
			set{cmDataEmiterii = value;}
		}
		// retriving and setting cmDataInregITMprivate variable
		public string CMNrInregITM
		{
			get{return cmNrInregITM;}
			set{cmNrInregITM = value;}
		}
		#endregion
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public Angajat()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region InsertAngajat
		public long InsertAngajat()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.InsertAngajat(
				angajatId,  angajatorId,  punctLucruId,  casaDeAsigurariId, motivDeAngajareId, tipDeAngajatId,
				marca, gid,
				nume,  prenume,  numeAnterior, dataSchimbariiNumelui,
				titluId,
				prenumeTata,  prenumeMama,
				studiuId,  anAbsolvire,  nrDiploma,
				descriere,
				modIncadrare,
				programLucru,
				telefon,
				dataNasterii,  judetNastereId,  taraNastereId,  localitateNastere,
				stareCivila,
				nrCopii,
				sex,
				nationalitate,
				cnp,  cnpAnterior,
				tipFisaFiscala,
				aniVechimeMunca,  luniVechimeMunca,  zileVechimeMunca,
				areCardBancar,
				pozaAngajat,
				functieCurentaId,
				departamentCurentId,
				sefId,
				numeAngajator,
				perioadaDeterminata,  dataPanaLa,  dataDeLa,
				nrContractMunca,  dataInregContractMunca, 
				echIndProtectie,  echIndLucru,  matIgiSan,  alimProtectie,  alteDrSiObl,  alteClauzeCIM,
				perProba,
				invaliditate,
				salariuBaza,  indemnizatieConducere,
				sporuri,  alteAdaosuri,  sumaMajorare,  dataMajorare,
				nrZileCOAn,  nrZileCOSupl,
				categorieId,
				email, telMunca,
				isLichidat,  isPensionat,
				ciSerie,  ciNumar,  ciEliberatDe,  ciDataEliberarii,  ciValabilPanaLa,
				pasSerie,  pasNumar,  pasEliberatDe,  pasDataEliberarii,  pasValabilPanaLa,
				permMuncaEliberat,  permMuncaExpira,  seriePermisMunca,  nrPermisMunca,
				legitimatieSedereDataEliberare,  legitimatieSedereDataExpirare,  serieLegitimatieSedere,  nrLegitimatieSedere,
				nif,
				tipNationalitateDomiciliu,
				dTara,  dLocalitate,  dJudetSectorId,  dStrada,  dNumar,  dCodPostal,  dBloc,  dScara,  dEtaj,  dApartament,
				rTara,  rLocalitate,  rJudetSectorId,  rStrada,  rNumar,  rCodPostal,  rBloc,  rScara,  rEtaj,  rApartament,
				cmSerie,  cmNumar,  cmEmitent,  cmDataEmiterii,  cmNrInregITM,
				alerteSpeciale, pmp, azm, retinereSanatate, retinereCAS, retinereSomaj,
				birou, tipAsiguratId
				);
		}

		#endregion

		#region UpdateAngajat
		/// <summary>
		/// Procedura actualizeaza un angajat
		/// </summary>
		public void UpdateAngajat()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			angajat.UpdateAngajat(
				angajatId,  angajatorId,  punctLucruId,  casaDeAsigurariId, motivDeAngajareId, tipDeAngajatId,
				marca, gid,
				nume,  prenume,  numeAnterior, dataSchimbariiNumelui,
				titluId,
				prenumeTata,  prenumeMama,
				studiuId,  anAbsolvire,  nrDiploma,
				descriere,
				modIncadrare,
				programLucru,
				telefon,
				dataNasterii,  judetNastereId,  taraNastereId,  localitateNastere,
				stareCivila,
				nrCopii,
				sex,
				nationalitate,
				cnp,  cnpAnterior,
				tipFisaFiscala,
				aniVechimeMunca,  luniVechimeMunca,  zileVechimeMunca,
				areCardBancar,
				pozaAngajat,
				functieCurentaId,
				departamentCurentId,
				sefId,
				numeAngajator,
				perioadaDeterminata,  dataPanaLa,  dataDeLa,
				nrContractMunca,  dataInregContractMunca, 
				echIndProtectie,  echIndLucru,  matIgiSan,  alimProtectie,  alteDrSiObl,  alteClauzeCIM,
				perProba,
				invaliditate,
				salariuBaza,  indemnizatieConducere,
				sporuri,  alteAdaosuri,  sumaMajorare,  dataMajorare,
				nrZileCOAn,  nrZileCOSupl,
				categorieId,
				email, telMunca,
				isLichidat,  isPensionat,
				ciSerie,  ciNumar,  ciEliberatDe,  ciDataEliberarii,  ciValabilPanaLa,
				pasSerie,  pasNumar,  pasEliberatDe,  pasDataEliberarii,  pasValabilPanaLa,
				permMuncaEliberat,  permMuncaExpira,  seriePermisMunca,  nrPermisMunca,
				legitimatieSedereDataEliberare,  legitimatieSedereDataExpirare,  serieLegitimatieSedere,  nrLegitimatieSedere,
				nif,
				tipNationalitateDomiciliu,
				dTara,  dLocalitate,  dJudetSectorId,  dStrada,  dNumar,  dCodPostal,  dBloc,  dScara,  dEtaj,  dApartament,
				rTara,  rLocalitate,  rJudetSectorId,  rStrada,  rNumar,  rCodPostal,  rBloc,  rScara,  rEtaj,  rApartament,
				cmSerie,  cmNumar,  cmEmitent,  cmDataEmiterii,  cmNrInregITM,
				alerteSpeciale, pmp, azm, retinereSanatate, retinereCAS, retinereSomaj,
				birou, tipAsiguratId
				);
		}
		#endregion

		#region CheckDateAngajat
		/// <summary>
		///Cristina Muntean
		///de exp: daca sunt doi angajati cu aceeasi marca returneaza false, altfel returneaza true
		/// </summary>
		/// <returns>Returneaza rezultatul verificarii: 
		/// 1 daca marca mai exista
		/// 2 daca gid mai exista
		/// 0 daca datele sunt corecte
		/// </returns>
		public int CheckDateAngajat()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.CheckDateAngajat(angajatorId, marca, gid, cnp);
		}
		#endregion
	
		#region CheckDateAngajatForUpdate
		/// <summary>
		/// Cristina Muntean
		/// Daca sunt mai sunt si alti angajati cu aceasta marca in afara de cel in cauza returneaza false, altfel returneaza true
		/// </summary>
		/// <returns>Returneaza rezultatul verificarii: 
		/// 1 daca marca mai exista
		/// 2 daca gid mai exista
		/// 0 daca datele sunt corecte
		/// </returns>
		public int CheckDateAngajatForUpdate()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.CheckDateAngajatForUpdate(angajatorId, angajatId, marca, gid);
		}
		#endregion

		#region GetVechimeInMuncaAngajatorCurr
		/// <summary>
		/// Procedura determina vechimea in munca a unui angajat la angajatorul curent
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetVechimeInMuncaAngajatorCurr()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetVechimeInMuncaAngajatorCurr(angajatId);
		}
		#endregion

		#region GetVechimeInMuncaPerTotal
		/// <summary>
		/// Procedura determina vechimea in munca a unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetVechimeInMuncaPerTotal()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetVechimeInMuncaPerTotal(angajatId);
		}
		#endregion

		#region GetAllAngajati
		/// <summary>
		/// Procedura selecteaza toti angajatii care apartin unei anumite categorii
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAllAngajati()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetAllAngajati(categorieId, angajatorId);
		}
		#endregion

		#region GetAngajatIDAll
		/// <summary>
		/// Metoda este folosita pentru a obtine id-urile tuturor angajatilor
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatIDAll()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetAngajatIDAll();
		}
		#endregion

		#region GetAllAngajatiDinLuna
		/// <summary>
		/// Added:       Cristina Raluca Muntean
		/// Date:        13.09.2005
		/// Description: Returneaza toti angajatii care apartin de un angajator si care au avut contract in luna trimisa ca parametru
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAllAngajatiDinLuna(int lunaId)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetAllAngajatiDinLuna(lunaId, angajatorId);
		}
		#endregion

		#region GetAllAngajatiLichidati
		/// <summary>
		/// Procedura selecteaza toti angajatii lichidati
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAllAngajatiLichidati(int lunaCurenta)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetAllAngajatiLichidati(angajatorId, lunaCurenta);
		}
		#endregion

		#region GetNormaAngajat
		/// <summary>
		/// Procedura determina norma unui angajat
		/// </summary>
		/// <returns>Returneaza valoarea normei</returns>
		public int GetNormaAngajat()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetNormaAngajat(angajatId);
		}
		#endregion

		#region LoadAngajat
		/// <summary>
		/// Procedura incarca datele unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele despre angajat</returns>
		public void LoadAngajat()
		{
				Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
				DataSet ds = angajat.LoadAngajat(angajatId);
			
				if (ds.Tables[0].Rows.Count > 0)
				{
					DataRow dataRow = ds.Tables[0].Rows[0];
					angajatId = Convert.ToInt64(dataRow["AngajatID"].ToString());
					nume = dataRow["Nume"].ToString();
					prenume = dataRow["Prenume"].ToString();
					if (!Convert.IsDBNull(dataRow["TitluID"]))
						titluId = Convert.ToInt32(dataRow["TitluID"]);			
					numeAngajator = dataRow["NumeAngajator"].ToString();
					if (!Convert.IsDBNull(dataRow["AngajatorID"]))
						angajatorId = Convert.ToInt32(dataRow["AngajatorID"]);
					if (!Convert.IsDBNull(dataRow["PunctLucruID"]))
						punctLucruId = Convert.ToInt32(dataRow["PunctLucruID"]);
					if (!Convert.IsDBNull(dataRow["CasaDeAsigurariID"]))
						casaDeAsigurariId = Convert.ToInt32(dataRow["CasaDeAsigurariID"]);
					if (!Convert.IsDBNull(dataRow["TipAsiguratID"]))
						tipAsiguratId = Convert.ToInt32(dataRow["TipAsiguratID"]);
					if (!Convert.IsDBNull(dataRow["MotivDeAngajareId"]))
						motivDeAngajareId = Convert.ToInt32(dataRow["MotivDeAngajareId"]);
					if (!Convert.IsDBNull(dataRow["TipDeAngajatId"]))
						tipDeAngajatId = Convert.ToInt32(dataRow["TipDeAngajatId"]);
					marca = dataRow["Marca"].ToString();
					gid = dataRow["Gid"].ToString();
					prenumeTata = dataRow["PrenumeTata"].ToString();
					prenumeMama = dataRow["PrenumeMama"].ToString();
					numeAnterior = dataRow["NumeAnterior"].ToString();
					if (!Convert.IsDBNull(dataRow["DataSchimbariiNumelui"]))
						dataSchimbariiNumelui = Convert.ToDateTime(dataRow["DataSchimbariiNumelui"]);
					if (!Convert.IsDBNull(dataRow["StudiuID"]))
						studiuId = Convert.ToInt32(dataRow["StudiuID"]);
					if (!Convert.IsDBNull(dataRow["AnAbsolvire"]))
						AnAbsolvire = int.Parse(dataRow["AnAbsolvire"].ToString());
					nrDiploma = dataRow["NrDiploma"].ToString();
					descriere = dataRow["Descriere"].ToString();
					if (!Convert.IsDBNull(dataRow["ModIncadrare"]))
						modIncadrare = Convert.ToByte(dataRow["ModIncadrare"]);
					if (!Convert.IsDBNull(dataRow["ProgramLucru"]))
						programLucru = Convert.ToByte(dataRow["ProgramLucru"]);
            
					// load datele despre Buletin
					if( !Convert.IsDBNull( dataRow[ "CNP" ] ))
						cnp = Convert.ToInt64(dataRow["CNP"].ToString());
					if( !Convert.IsDBNull( dataRow[ "CNPAnterior" ] ))
						cnpAnterior = dataRow["CNPAnterior"].ToString();
					if( !Convert.IsDBNull( dataRow[ "CISerie" ] ))
						ciSerie = dataRow["CISerie"].ToString();
					if (!Convert.IsDBNull(dataRow["CINumar"]))
						ciNumar = dataRow["CINumar"].ToString();
					if( !Convert.IsDBNull( dataRow[ "CIEliberatDe" ] ))
						ciEliberatDe = dataRow["CIEliberatDe"].ToString();
					if ( !Convert.IsDBNull(dataRow["CIDataEliberarii"]))
						ciDataEliberarii = Convert.ToDateTime(dataRow["CIDataEliberarii"]);
					if (!Convert.IsDBNull(dataRow["CIValabilPanaLa"]))
						ciValabilPanaLa = Convert.ToDateTime(dataRow["CIValabilPanaLa"]);

					//load datele despre Pasaport
					if( !Convert.IsDBNull( dataRow[ "PASSerie" ] ))
						pasSerie = dataRow["PASSerie"].ToString();
					if (!Convert.IsDBNull(dataRow["PASNumar"]))
						pasNumar = dataRow["PASNumar"].ToString();
					if( !Convert.IsDBNull( dataRow[ "PASEliberatDe" ] ))
						pasEliberatDe = dataRow["PASEliberatDe"].ToString();
					if (!Convert.IsDBNull(dataRow["PasDataEliberarii"]))
						pasDataEliberarii = Convert.ToDateTime(dataRow["PASDataEliberarii"]);
					if (!Convert.IsDBNull(dataRow["PASValabilPanaLa"]))
						pasValabilPanaLa = Convert.ToDateTime(dataRow["PASValabilPanaLa"]);

					//load datele despre Permisul de munca
					if(!Convert.IsDBNull( dataRow[ "SeriePermisMunca" ] ))
						seriePermisMunca = dataRow["SeriePermisMunca"].ToString();
					if (!Convert.IsDBNull(dataRow["NrPermisMunca"]))
						nrPermisMunca = Convert.ToInt64(dataRow["NrPermisMunca"].ToString());
					if (!Convert.IsDBNull(dataRow["PermMuncaDataEliberare"]))
						permMuncaEliberat = Convert.ToDateTime(dataRow["PermMuncaDataEliberare"]);
					if (!Convert.IsDBNull(dataRow["PermMuncaDataExpirare"]))
						permMuncaExpira = Convert.ToDateTime(dataRow["PermMuncaDataExpirare"]);

					//load datele despre Legitimatia de sedere
					if (!Convert.IsDBNull( dataRow[ "SerieLegitimatieSedere" ] ))
						serieLegitimatieSedere = dataRow["SerieLegitimatieSedere"].ToString();
					if (!Convert.IsDBNull(dataRow["NrLegitimatieSedere"]))
						nrLegitimatieSedere = dataRow["NrLegitimatieSedere"].ToString();
					if (!Convert.IsDBNull(dataRow["LegitimatieSedereDataEliberare"]))
						legitimatieSedereDataEliberare = Convert.ToDateTime(dataRow["LegitimatieSedereDataEliberare"]);
					if (!Convert.IsDBNull(dataRow["LegitimatieSedereDataExpirare"]))
						legitimatieSedereDataExpirare = Convert.ToDateTime(dataRow["LegitimatieSedereDataExpirare"]);

					//load datele despre NIF
					if (!Convert.IsDBNull( dataRow[ "NIF" ] ))
						nif = dataRow["NIF"].ToString();

					// load datele despre Domiciliu
					if (!Convert.IsDBNull(dataRow["DTaraID"]))
						dTara = Convert.ToInt32(dataRow["DTaraID"]);
					else
						dTara = 0;
					dLocalitate = dataRow["DLocalitate"].ToString();
					if (!Convert.IsDBNull(dataRow["DJudetSectorID"]))
						dJudetSectorId = Convert.ToInt32(dataRow["DJudetSectorID"]);
					else 
						dJudetSectorId = 0;
					dStrada = dataRow["DStrada"].ToString();
					dNumar = dataRow["DNumar"].ToString();
					dCodPostal = long.Parse(dataRow["DCodPostal"].ToString());
					dBloc = dataRow["DBloc"].ToString();
					dScara = dataRow["DScara"].ToString();
					dEtaj = dataRow["DEtaj"].ToString();
					dApartament = dataRow["DApartament"].ToString();
					// end - load datele despre Resedinta

					// load datele despre Resedinta
					if (!Convert.IsDBNull(dataRow["RTaraID"]))
						rTara = Convert.ToInt32(dataRow["RTaraID"]);
					else
						rTara = 0;
					rLocalitate = dataRow["RLocalitate"].ToString();
					if (!Convert.IsDBNull(dataRow["RJudetSectorID"]))
						rJudetSectorId = Convert.ToInt32(dataRow["RJudetSectorID"]);
					else 
						rJudetSectorId = 0;
					rStrada = dataRow["RStrada"].ToString();
					rNumar = dataRow["RNumar"].ToString();
					rCodPostal = long.Parse(dataRow["RCodPostal"].ToString());
					rBloc = dataRow["RBloc"].ToString();
					rScara = dataRow["RScara"].ToString();
					rEtaj = dataRow["REtaj"].ToString();
					rApartament = dataRow["RApartament"].ToString();
					// end - load datele despre Resedinta

					// load date carnet de munca
					cmSerie = dataRow["CMSerie"].ToString();
					cmNumar = dataRow["CMNumar"].ToString();
					cmEmitent = dataRow["CMEmitent"].ToString();
					cmNrInregITM = dataRow["CMNrInregITM"].ToString();
					if (!Convert.IsDBNull(dataRow["CMDataEmiterii"]))
						cmDataEmiterii = Convert.ToDateTime(dataRow["CMDataEmiterii"]);
					// end  -  load date carnet de munca
			
					telefon = dataRow["Telefon"].ToString();
					if (!Convert.IsDBNull(dataRow["DataNasterii"]))
						dataNasterii = Convert.ToDateTime(dataRow["DataNasterii"]);
					if (!Convert.IsDBNull(dataRow["JudetNastereID"]))
						judetNastereId = Convert.ToInt32(dataRow["JudetNastereID"]);
					if (!Convert.IsDBNull(dataRow["TaraNastereID"]))
						taraNastereId = Convert.ToInt32(dataRow["TaraNastereID"]);
					LocalitateNastere = dataRow["LocalitateNastere"].ToString();
					if (!Convert.IsDBNull(dataRow["StareCivila"]))
						stareCivila = Convert.ToByte(dataRow["StareCivila"]);
					if (!Convert.IsDBNull(dataRow["NrCopii"]))
						nrCopii = Convert.ToByte(dataRow["NrCopii"]);
					sex = dataRow["Sex"].ToString();
					nationalitate = int.Parse( dataRow["Nationalitate"].ToString());
			
					if (!Convert.IsDBNull(dataRow["TipFisaFiscala"]))
						tipFisaFiscala = Convert.ToByte(dataRow["TipFisaFiscala"]);
					if (!Convert.IsDBNull(dataRow["AniVechimeMunca"]))
						aniVechimeMunca = Convert.ToByte(dataRow["AniVechimeMunca"]);
					if (!Convert.IsDBNull(dataRow["LuniVechimeMunca"]))
						luniVechimeMunca = Convert.ToByte(dataRow["LuniVechimeMunca"]);
					if (!Convert.IsDBNull(dataRow["ZileVechimeMunca"]))
						zileVechimeMunca = Convert.ToInt32(dataRow["ZileVechimeMunca"]);
					if (!Convert.IsDBNull(dataRow["AreCardBancar"]))
						areCardBancar = Convert.ToByte(dataRow["AreCardBancar"]);
		
					pozaAngajat = (byte[]) LoadPozaAngajat();

					if (!Convert.IsDBNull(dataRow["FunctieID"]))
						functieCurentaId = Convert.ToInt32(dataRow["FunctieID"]);
					else
						functieCurentaId=0;
					functieCurentaNume = dataRow["FunctieNume"].ToString();
					functieCurentaCod = dataRow["FunctieCod"].ToString();

					if (!Convert.IsDBNull(dataRow["DepartamentID"]))
						departamentCurentId = Convert.ToInt32(dataRow["DepartamentID"]);
					else
						departamentCurentId =0;
					departamentCurentCod = dataRow["DepartamentCod"].ToString();
					departamentCurentDenumire = dataRow["DepartamentDenumire"].ToString();

					perioadaDeterminata=System.Boolean.Parse(dataRow["PerioadaDeterminata"].ToString());
					if (!Convert.IsDBNull(dataRow["DataPanaLa"]))
						dataPanaLa = Convert.ToDateTime(dataRow["DataPanaLa"]);
					else
						dataPanaLa =DateTime.MinValue;
					if (!Convert.IsDBNull(dataRow["DataDeLa"]))
						dataDeLa = Convert.ToDateTime(dataRow["DataDeLa"]);
					else
						dataDeLa =DateTime.MinValue;

					//Ionel Popa
					if (!Convert.IsDBNull(dataRow["DataLichidare"]))
						dataLichidare = Convert.ToDateTime(dataRow["DataLichidare"]);
					else
						dataLichidare =DateTime.MinValue;

					//Lichidat
					isLichidat = System.Boolean.Parse(dataRow["Lichidat"].ToString());

					//Pensionat
					isPensionat = System.Boolean.Parse(dataRow["Pensionar"].ToString());

					//date contract de munca
					nrContractMunca= dataRow["NrContractMunca"].ToString();
					dataInregContractMunca= dataRow["DataInregContractMunca"]==System.DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow["DataInregContractMunca"]);
					//echipament individual de protectie
					echIndProtectie = dataRow["EchIndProtectie"].ToString();
					//echipament individual de lucru
					echIndLucru = dataRow["EchIndLucru"].ToString();
					//materiale igienico sanitare
					matIgiSan = dataRow["MatIgiSan"].ToString();
					//alimentatie de protectie
					alimProtectie = dataRow["AlimProtectie"].ToString();
					//alte drepturi si obligati privind sanatatea in munca
					alteDrSiObl = dataRow["AlteDrSiObl"].ToString();
					//alte clauze ale contractului individual de munca
					alteClauzeCIM = dataRow["AlteClauzeCIM"].ToString();
					//perioada de proba
					perProba = dataRow["PerProba"].ToString();
			
					invaliditate=(short)dataRow["Invaliditate"];
					salariuBaza=(decimal)dataRow["SalariuBazaActual"];
					indemnizatieConducere=(decimal)dataRow["IndemnizatieConducereActual"];
					//sporuri
					if(!Convert.IsDBNull(dataRow["Sporuri"]))
						sporuri = (decimal)dataRow["Sporuri"];
					else
						sporuri = decimal.Parse("0");
					//alte adaosuri
					if(!Convert.IsDBNull(dataRow["AlteAdaosuri"]))
						alteAdaosuri = (decimal)dataRow["AlteAdaosuri"];
					else
						alteAdaosuri = decimal.Parse("0");

					if (!Convert.IsDBNull(dataRow["DataMajorare"]))
					{
						sumaMajorare = (decimal)dataRow[ "SumaMajorare" ];
						dataMajorare = Convert.ToDateTime( dataRow[ "DataMajorare" ] );
					}
					else
					{
						sumaMajorare = 0;
						dataMajorare = DateTime.MinValue;
					}

					nrZileCOAn=(int)dataRow["NrZileCOAn"];
					//numarul de zile de concediu de odihna suplimentar(pe an)
					if(!Convert.IsDBNull(dataRow["NrZileCOSupl"]))
						nrZileCOSupl = (int)dataRow["NrZileCOSupl"];
					else
						nrZileCOSupl = int.Parse("0");

					if (!Convert.IsDBNull(dataRow["SefID"]))
						sefId = Convert.ToInt64(dataRow["SefID"].ToString());
					else
						SefId = 0;

					// start load info situatia militara
					if (!Convert.IsDBNull(dataRow["DataIntrareEvidenta"]))
						dataIntrareEvidenta = Convert.ToDateTime(dataRow["DataIntrareEvidenta"]);
					evidentaCMJ = dataRow["EvidentaCMJ"].ToString();
					gradul = dataRow["Gradul"].ToString();
					numarLivret = dataRow["NumarLivret"].ToString();
					serieLivret = dataRow["SerieLivret"].ToString();
					specialitatiMilitare = dataRow["SpecialitatiMilitare"].ToString();
					// end load situatie militara info
					categorieId=(int)dataRow["CategorieID"]; 
					email = dataRow["Email"].ToString();
					telMunca = dataRow["TelMunca"].ToString();
					pmp = bool.Parse(dataRow["PMP"].ToString());
					azm = bool.Parse(dataRow["AZM"].ToString());
					retinereSanatate = bool.Parse(dataRow["RetinereSanatate"].ToString());
					retinereCAS = bool.Parse(dataRow["RetinereCAS"].ToString());
					retinereSomaj = bool.Parse(dataRow["RetinereSomaj"].ToString());
					birou = dataRow["Birou"].ToString();
				}
		}
		#endregion

		#region LoadPozaAngajat
		/// <summary>
		/// Procedura selecteaza poza unui angajat
		/// </summary>
		/// <returns>Returneaza un obiect care contine poza angajatului</returns>
		public object LoadPozaAngajat()
		{	
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.LoadPozaAngajat(angajatId);
		}
		#endregion

		#region SetetazaAngajatiLunaInactivi
		/// <summary>
		/// Procedura seteaza angajatii din luna inactivi
		/// </summary>
		/// <param name="data">Luna pentru case se modifica angajatii</param>
		public void SetetazaAngajatiLunaInactivi()
		{
			Salaries.Business.Luni l = new Salaries.Business.Luni(angajatorId);
			Salaries.Data.LunaData ld = l.GetLunaActiva();
			DateTime data = new DateTime( ld.Data.Year, ld.Data.Month, DateTime.DaysInMonth( ld.Data.Year, ld.Data.Month ));
	
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			angajat.SetetazaAngajatiLunaInactivi(angajatorId, data);
		}
		#endregion

		#region GetPersoaneInIntretinere
		/// <summary>
		/// Procedura selecteaza persoanele in intretinere ale unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele selectate</returns>
		public DataSet GetPersoaneInIntretinere()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetPersoaneInIntretinere(angajatId);
		}
		#endregion	
		
		#region VerificaDateSalariuPtUltimele3Luni
		/// <summary>
		/// Verifica daca sunt date in statul de plata din baza de date pe ultimele trei luni pentru
		/// un anumit angajat.
		/// </summary>
		/// <param name="lunaID"> ID-ul lunii</param>
		/// <returns> true in cazul in care sunt date in statul de plata pe ultimele trei luni, false altfel.</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  14.03.2006
		/// </remarks>
		public bool VerificaDateSalariuPtUltimele3Luni(int lunaId)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.VerificaDateSalariuPtUltimele3Luni(angajatId, lunaId);
		}

		#endregion

		#region GetMedieZilnicaConcediuDeOdihna
		/// <summary>
		/// Calculeaza media zilnica a unui angajat pentru concediul de odihna.
		/// </summary>
		/// <param name="lunaID"> ID-ul lunii.</param>
		/// <returns> Media zilnica aferenta concediului de odihna.</returns>
		/// <remarks> 
		/// Autor: Cristina Raluca Muntean
		/// Data:  14.03.2006
		/// </remarks>
		public double GetMedieZilnicaConcediuDeOdihna(int lunaId)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			// Este preluata valoarea mediei zilnice pentru concediul de odihna al angajatului.
			return angajat.GetMedieZilnicaConcediuDeOdihna(angajatId, lunaId);
		}
		#endregion

		#region RecalculMedieZilnicaConcediuOdihna
		/// <summary>
		/// Procedura recalculeaza media zilnica a concediului de odihna a unui angajat in cazul in care a fost
		/// adaugata o modificare a salariului de baza al angajatului pe luna curenta.
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="dataStart">Data de incepul a lunii curente</param>
		/// <param name="dataEnd">Data de sfarsit a lunii curente</param>
		public void RecalculMedieZilnicaConcediuOdihna(long angajatId, DateTime dataStart, DateTime dataEnd)
		{			
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			angajat.RecalculMedieZilnicaConcediuOdihna(angajatId, dataStart, dataEnd);
		}
		#endregion

		#region GetMedieZilnicaConcediuDeBoala
		/// <summary>
		/// Calculeaza media zilnica a unui angajat pentru concediul de boala.
		/// </summary>
		/// <param name="lunaID">Id-ul lunii pentru care se face media</param>
		/// <returns>Returneaza valoarea mediei zilnice</returns>
		public double GetMedieZilnicaConcediuDeBoala(int lunaId)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			// Este preluata valoarea mediei zilnice pentru concediul de boala al angajatului.
			return angajat.GetMedieZilnicaConcediuDeBoala(angajatId, lunaId);
		}
		public DataSet GetMedieZilnicaConcediuDeBoalaDataSet(int lunaId)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			// Este preluata valoarea mediei zilnice pentru concediul de boala al angajatului.
			return angajat.GetMedieZilnicaConcediuDeBoalaDataSet(angajatId, lunaId);
		}
		#endregion

		#region GetMedieZilnicaContinuareConcediuDeBoala
		/// <summary>
		/// Calculeaza media zilnica a unui angajat pentru continuare concediul de boala.
		/// </summary>
		/// <param name="lunaID">Id-ul lunii pentru care se face media</param>
		/// <returns>Returneaza valoarea mediei zilnice</returns>
		// Lungu Andreea - 12.09.2008
		public double GetMedieZilnicaContinuareConcediuDeBoala(int lunaId)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			// Este preluata valoarea mediei zilnice pentru continuare concediul de boala al angajatului.
			return angajat.GetMedieZilnicaContinuareConcediuDeBoala(angajatId, lunaId);
		}
		public DataSet GetMedieZilnicaContinuareConcediuDeBoalaDataSet(int lunaId)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			// Este preluata valoarea mediei zilnice pentru continuare concediul de boala al angajatului.
			return angajat.GetMedieZilnicaContinuareConcediuDeBoalaDataSet(angajatId, lunaId);
		}
		#endregion

		#region GetDetaliiAngajat
		/// <summary>
		/// Procedura selecteaza un angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetDetaliiAngajat()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			// Este preluata valoarea mediei zilnice pentru concediul de boala al angajatului.
			return angajat.GetDetaliiAngajat(angajatId);
		}
		#endregion

		#region GetSal_SituatieLunaraAngajatiIDs
		/// <summary>
		/// Returneaza toate id-urile angajatilor unui angajator pentru o anumita luna.
		/// </summary>
		/// <param name="lunaId"> ID-ul lunii.</param>
		/// <returns></returns>
		/// <remarks> Autor: Cristina Muntean</remarks>
		public ArrayList GetSal_SituatieLunaraAngajatiIDs(int lunaId)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetSal_SituatieLunaraAngajatiIDs(angajatorId, lunaId);			
		}
		#endregion

		#region GetAngajatiExpiraContractLunaCurenta
		/// <summary>
		/// Procedura selecteaza angajatii carora le expira contractul de munca
		/// </summary>
		/// <param name="data">Data in functie de care se selecteaza angajatii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAngajatiExpiraContractLunaCurenta(DateTime data)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetAngajatiExpiraContractLunaCurenta(data);			
		}
		#endregion
		
		#region InsertCAS
		/// <summary>
		/// Procedura adauga datele CAS ale unui angajat pentru o anumita luna
		/// </summary>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <param name="valCAS">Valoarea CAS</param>
		public void InsertCAS(int lunaId, double valCAS)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			angajat.InsertCAS(angajatId, lunaId, valCAS);
		}
		#endregion

		#region UpdateCAS
		/// <summary>
		/// Procedura modifica datele CAS ale unui angajat pentru o anumita luna
		/// </summary>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <param name="valCAS">Valoarea CAS</param>
		public void UpdateCAS(int lunaId, double valCAS)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			angajat.UpdateCAS(angajatId, lunaId, valCAS);
		}
		#endregion

		#region DeleteCAS
		/// <summary>
		/// Procedura sterge datele CAS ale unui angajat pentru o anumita luna
		/// </summary>
		public void DeleteCAS()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			angajat.DeleteCAS(angajatId);
		}
		#endregion

		#region GetValoriCAS
		/// <summary>
		/// Procedura determina valorile CAS ale unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetValoriCAS()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetValoriCAS(angajatId);
		}
		#endregion

		#region UpdatePoza
		/// <summary>
		/// Procedura actualizeaza poza unui angajat
		/// </summary>
		/// <param name="buffer">Poza angajatului</param>
		public void UpdatePoza(byte[] buffer)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			angajat.UpdatePoza(angajatId, buffer);
		}
		#endregion

		#region GetAngajatiAlerteSpeciale
		/// <summary>
		/// Procedura este folosita pentru a selecta angajatii cu alerte speciale
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatiAlerteSpeciale()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetAngajatiAlerteSpeciale();
		}
		#endregion

		#region GetAngajatiExpiraDataMajorare
		/// <summary>
		/// Procedura este folosita pentru a selecta angajatii pentru care trebuie sa se efectueaza o majorare
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatiExpiraDataMajorare()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetAngajatiExpiraDataMajorare();
		}
		#endregion

		#region GetAngajatiExpiraPasaport
		/// <summary>
		/// Procedura este folosita pentru a selecta angajatii carora le-a expirat pasaportul
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatiExpiraPasaport()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetAngajatiExpiraPasaport();
		}
		#endregion

		#region GetAngajatiExpiraPermisMunca
		/// <summary>
		/// Procedura este folosita pentru a selecta angajatii carora le-a expirat permisul de munca
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatiExpiraPermisMunca()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetAngajatiExpiraPermisMunca();
		}
		#endregion

		#region GetAngajatiExpiraPermisSedere
		/// <summary>
		/// Procedura este folosita pentru a selecta angajatii carora le-a expirat permisul de sedere
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatiExpiraPermisSedere()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetAngajatiExpiraPermisSedere();
		}
		#endregion

		#region GetAngajatiExpiraRetineri
		/// <summary>
		/// Procedura este folosita pentru a selecta angajatii carora le expira retinerile luna aceasta
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatiExpiraRetineri(int lunaID)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetAngajatiExpiraRetineri(lunaID);
		}
		#endregion

		#region GetAllAngajatiNumeIntregUnion
		/// <summary>
		/// Procedura este folosita pentru a selecta angajatii
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAllAngajatiNumeIntregUnion()
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetAllAngajatiNumeIntregUnion();
		}
		#endregion

		#region GetAngajatIDByMarca
		//Lungu Andreea - 04.11.2009
		public int GetAngajatIDByMarca(string marca)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			return angajat.GetAngajatIDByMarca(marca);
		}
		#endregion

		#region GetNrZileSuspendateContract
		/// <summary>
		/// Calculeaza mnr de zile suspendate dintr-o luna
		/// </summary>
		/// <param name="lunaID">Id-ul lunii pentru care se face media</param>
		/// <returns>Returneaza valoarea mediei zilnice</returns>
		public int GetNrZileSuspendateContract(int lunaId)
		{
			Salaries.Data.Angajat angajat = new Salaries.Data.Angajat(settings.ConnectionString);
			// Este preluata valoarea mediei zilnice pentru concediul de boala al angajatului.
			return angajat.GetNrZileSuspendateContract(angajatId, lunaId);
		}
		#endregion
	}
}
