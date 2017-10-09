using System;
using System.Data;
using System.Data.SqlClient;

/*
 * Modificat:	Lungu Andreea
 * Data:		08.04.2008
 * Descriere:	A fost adaugat campul nrInregITM pentru angajator
 * */

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminAngajator.
	/// </summary>
	public class AdminAngajator
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul angajatorului
		private int angajatorId;
		//Denumirea angajatorului
		private string denumire;
		//Tipul de angajator
		private int tipPersoana;
		//CUI sau CNP pentru angajator
		private string cui_CNP;
		//Numarul de inregistrare ORC
		private string nrInregORC;
		//Numarul de inregistrare ITM
		private string nrInregITM;
		//Numarul de telefon
		private string telefon;
		//Numarul de fax
		private string fax;
		//Pagina de web
		private string paginaWeb;
		//Adresa de email
		private string email;
		//Id-ul tarii angajatorului
		private int taraId;
		//Id-ul judetului angajatorului
		private int judetSectorId;
		//Id-ul tipului de completare a carnetelor de munca
		private int tipCompletareId;
		//Localitatea
		private string localitate;
		//Strada
		private string strada;
		//Numarul
		private string numar;
		//Codul postal
		private string codPostal;
		//Blocul
		private string bloc;
		//Scara
		private string scara;
		//Etajul
		private string etaj;
		//Apartamentul
		private string apartament;
		//Ziua platii
		private string ziLichidareSalar;
		//Luna activa
		private DateTime lunaActiva;
		//Sectorul
		private string sector;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminAngajator()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		public int AngajatorId
		{
			get {return angajatorId;}
			set { angajatorId =  value;}
		}

		public string Denumire
		{
			get {return denumire;}
			set { denumire = value; }
		}

		public int TipPersoana
		{
			get {return tipPersoana;}
			set {tipPersoana = value;}
		}

		public string CUI_CNP
		{
			get {return cui_CNP;}
			set { cui_CNP = value;}
		}

		public string NrInregORC
		{
			get {return nrInregORC;}
			set { nrInregORC = value;}
		}

		public string NrInregITM
		{
			get {return nrInregITM;}
			set { nrInregITM = value;}
		}

		public string Telefon
		{
			get { return telefon;}
			set { telefon = value;}
		}

		public string Fax
		{
			get { return fax;}
			set { fax = value; }
		}

		public string PaginaWeb
		{
			get { return paginaWeb;}
			set { paginaWeb = value;}
		}

		public string Email
		{
			get { return email;}
			set { email = value;}
		}

		public int TaraId
		{
			get { return taraId; }
			set { taraId = value;}
		}

		public int JudetSectorId
		{
			get { return judetSectorId;}
			set { judetSectorId = value;}
		}

		public int TipCompletareId
		{
			get { return tipCompletareId;}
			set { tipCompletareId = value;}
		}

		public string Localitate
		{
			get {return localitate;}
			set { localitate = value;}
		}

		public string Strada
		{
			get { return strada;}
			set { strada = value;}
		}

		public string Numar
		{
			get { return numar;}
			set { numar = value;} 
		}

		public string CodPostal
		{
			get { return codPostal;}
			set { codPostal = value;}
		}

		public string Bloc
		{
			get { return bloc;}
			set { bloc = value;}
		}

		public string Scara
		{
			get { return scara;}
			set { scara = value;}
		}

		public string Etaj
		{
			get { return etaj;}
			set { etaj = value;}
		}

		public string Apartament
		{
			get { return apartament;}
			set { apartament = value;}
		}

		public string ZiLichidareSalar
		{
			get { return ziLichidareSalar;}
			set { ziLichidareSalar = value; }
		}

		public DateTime LunaActiva
		{
			get { return lunaActiva;}
			set { lunaActiva = value;}
		}

		public string Sector
		{
			get { return sector;}
			set { sector = value;}
		}
		#endregion

		#region GetJSArrays
		/// <summary>
		/// Returneaza array-uri cu AngajatorID si Numnarul de angajati asignati la fiecare 
		/// </summary>
		/// <returns></returns>
		public string GetJSArrays()
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			return angajator.GetJSArrays();
		}
		#endregion

		#region LoadInfoAngajator
		/// <summary>
		/// Procedura selecteaza datele despre un angajator
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele despre angajator</returns>
		public DataSet LoadInfoAngajator()
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			return angajator.LoadInfoAngajator(angajatorId);
		}
		#endregion

		#region LoadInfoAngajatori
		/// <summary>
		/// Angajatorii din sistem.
		/// </summary>
		/// <returns>Un DataSet ce cuprinde toti angajatorii din sistem.</returns>
		/// <remarks>
		/// Modificari:
		/// Autor: Cristina Raluca Muntean
		/// Data: 2.06.2006
		/// Descriere: Am inlocuit rularea unei instructiuni sql, cu rularea procedurii stocate.
		/// </remarks>
		public DataSet LoadInfoAngajatori()
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			return angajator.LoadInfoAngajatori();
		}
		#endregion

		#region InsertAngajator
		/// <summary>
		/// Procedura actualizeaza un angajator
		/// </summary>
		public void InsertAngajator()
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			angajator.InsertAngajator(angajatorId, denumire, tipPersoana, cui_CNP, nrInregORC, nrInregITM, telefon, fax, paginaWeb, email, taraId, judetSectorId, tipCompletareId, localitate, strada, numar, codPostal, bloc, scara, etaj, apartament, ziLichidareSalar, sector);
		}
		#endregion

		#region InsertAngajatorWithIDReturn
		/// <summary>
		/// insereaza un angajator si returneaza id-ul angajatorului tocmai inserat
		/// </summary>
		public int InsertAngajatorWithIDReturn()		
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			return angajator.InsertAngajatorWithIDReturn(denumire, tipPersoana, cui_CNP, nrInregORC, nrInregITM, telefon, fax, paginaWeb, email, taraId, judetSectorId, tipCompletareId, localitate, strada, numar, codPostal, bloc, scara, etaj, apartament, ziLichidareSalar, sector);
		}
		#endregion

		#region InsertFirstAngajator
		/// <summary>
		/// Procedura insereaza primul angajator la rularea aplicatiei
		/// </summary>
		/// <returns>Returneaza id-ul angajatorului adaugat</returns>
		public int InsertFirstAngajator()
		{	
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			return angajator.InsertFirstAngajator(lunaActiva, denumire, tipPersoana, cui_CNP, nrInregORC, nrInregITM, telefon, fax, paginaWeb, email, taraId, judetSectorId, tipCompletareId, localitate, strada, numar, codPostal, bloc, scara, etaj, apartament, ziLichidareSalar, sector);
		}
		#endregion

		#region UpdateAngajator
		/// <summary>
		/// Procedura actualizeaza un angajator
		/// </summary>
		public void UpdateAngajator()
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			angajator.UpdateAngajator(angajatorId, denumire, tipPersoana, cui_CNP, nrInregORC, nrInregITM, telefon, fax, paginaWeb, email, taraId, judetSectorId, tipCompletareId, localitate, strada, numar, codPostal, bloc, scara, etaj, apartament, ziLichidareSalar, sector);
		}
		#endregion

		#region DeleteAngajator
		/// <summary>
		/// Procedura actualizeaza un angajator
		/// </summary>
		public void DeleteAngajator()
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			angajator.DeleteAngajator(angajatorId);
		}
		#endregion

		#region CheckIfAngajatorCanBeAdded
		/// <summary>
		/// Procedura verifica sa nu se creeze duplicate in tablea Angajatori prin adaugare/modificare
		/// </summary>
		/// <returns>Returneaza true daca se poate face adaugarea/modificarea si false altfel</returns>
		public bool CheckIfAngajatorCanBeAdded()
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			return angajator.CheckIfAngajatorCanBeAdded(angajatorId, denumire, CUI_CNP, nrInregORC);
		}
		#endregion

		#region GetPuncteLucru
		/// <summary>
		/// Procedura selecteaza punctele de lucru ale unui angajator
		/// </summary>
		/// <returns>Returneaza un DataSet care contine punctele de lucru</returns>
		public DataSet GetPuncteLucru()
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			return angajator.GetPuncteLucru(angajatorId);
		}
		#endregion

		#region GetCaseDeAsigurari
		/// <summary>
		/// Procedura selecteaza casele de asigurari ale unui angajator
		/// </summary>
		/// <returns>Returneaza un DataSet care contine casele de asigurari</returns>
		public DataSet GetCaseDeAsigurari()
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			return angajator.GetCaseDeAsig();
		}
		#endregion

		#region GetFunctiiReprez
		/// <summary>
		/// Procedura selecteaza functiile reprezentantilor legali care nu au atasata o persoana
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		//Lungu Andreea - 02.09.2008
		public DataSet GetAllFunctiiReprez()
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			return angajator.GetAllFunctiiReprez();
		}
		#endregion

		#region GetAllFunctiiReprez
		/// <summary>
		/// Procedura selecteaza toate functiile reprezentantilor legali
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		//Lungu Andreea - 02.09.2008
		public DataSet GetFunctiiReprez()
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			return angajator.GetFunctiiReprez(angajatorId);
		}
		#endregion

		#region GetReprezLegali
		//Lungu Andreea - 20.08.2008
		//Este adus un dataset ce contine toti reprezentantii legali stabiliti ai angajatorului.
		public DataSet GetReprezLegali()
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			return angajator.GetReprezLegali(angajatorId);
		}
		#endregion

		#region SetReprezLegal
		//Lungu Andreea - 19.08.2008
		//Este setat un reprezentant legal pentru angajator.
		public void SetReprezLegal(int functieReprezId, string numeReprez, string prenumeReprez)
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			angajator.SetReprezLegal(angajatorId, functieReprezId, numeReprez, prenumeReprez);
		}
		#endregion

		#region GetAngajatorInfoFiseFiscale
		//Manuel Neagoe - 01.03.2013
		//Este adus un dataset ce contine toti reprez legali stabiliti ai angajatorului.
		public DataSet GetAngajatorInfoFiseFiscale(int angajatorId)
		{
			Salaries.Data.AdminAngajator angajator = new Salaries.Data.AdminAngajator(settings.ConnectionString);
			return angajator.GetAngajatorInfoFiseFiscale(angajatorId);
		}
		#endregion
	}
}
