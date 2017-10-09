using System;
using System.Data;
using System.Data.SqlClient;

// Modificat:	Lungu Andreea
// Data:		22.07.2008
// Descriere:	A fost adaugat atributul suporta scutire impozit (posibilaScutireImpozit)

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminFunctii.
	/// </summary>
	public class AdminFunctii
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul functiei
		private int functieId;
		//Codul functiei
		private long cod;
		//Codul Siemens al functiei
		private string codSiemens;
		//Denumirea functiei
		private string nume;
		//Id-ul familiei de functii
		private int jobFamilyId;
		//Id-ul tipului de functie
		private int tipDeFunctieId;
		//Id-ul tipului de segment de management
		private int tipDeSegmentId;
		//Pozitia functiei
		private int pozitie;
		//Descrierea functiei
		private string descriere;
		//Norma functiei
		private int normaLucru;
		//Suporta sau nu impozit functia respectiva
		private bool posibilaScutireImpozit;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminFunctii()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul functiei
		/// </summary>
		public int FunctieId
		{
			get { return functieId; }
			set { functieId =  value; }
		}
		/// <summary>
		/// Codul functiei
		/// </summary>
		public long Cod
		{
			get { return cod; }
			set { cod =  value; }
		}
		/// <summary>
		/// Codul Siemens al functiei
		/// </summary>
		public string CodSiemens
		{
			get { return codSiemens; }
			set { codSiemens =  value; }
		}
		/// <summary>
		/// Denumirea functiei
		/// </summary>
		public string Nume
		{
			get { return nume; }
			set { nume =  value; }
		}
		/// <summary>
		/// Id-ul familiei de functii
		/// </summary>
		public int JobFamilyId
		{
			get { return jobFamilyId; }
			set { jobFamilyId =  value; }
		}
		/// <summary>
		/// Id-ul tipului de functie
		/// </summary>
		public int TipDeFunctieId
		{
			get { return tipDeFunctieId; }
			set { tipDeFunctieId =  value; }
		}
		/// <summary>
		/// Id-ul tipului de segment de management
		/// </summary>
		public int TipDeSegmentId
		{
			get { return tipDeSegmentId; }
			set { tipDeSegmentId =  value; }
		}
		/// <summary>
		/// Pozitia functiei
		/// </summary>
		public int Pozitie
		{
			get { return pozitie; }
			set { pozitie =  value; }
		}
		/// <summary>
		/// Descrierea functiei
		/// </summary>
		public string Descriere
		{
			get { return descriere; }
			set { descriere =  value; }
		}
		/// <summary>
		/// Norma functiei
		/// </summary>
		public int NormaLucru
		{
			get { return normaLucru; }
			set { normaLucru =  value; }
		}
		/// <summary>
		/// Posibilitatea de a suporta scutire de impozit
		/// </summary>
		public bool PosibilaScutireImpozit
		{
			get { return posibilaScutireImpozit; }
			set { posibilaScutireImpozit =  value; }
		}
		#endregion

		#region LoadInfoFunctii
		/// <summary>
		/// Procedura selecteaza toate functiile
		/// </summary>
		public DataSet LoadInfoFunctii()
		{
			Salaries.Data.AdminFunctii functie = new Salaries.Data.AdminFunctii(settings.ConnectionString);
			return functie.LoadInfoFunctii();
		}
		#endregion

		#region LoadInfoFunctiiUnion
		/// <summary>
		/// Sunt selectate toate functiile. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care cotine aceste inregistrari</returns>
		public DataSet LoadInfoFunctiiUnion()
		{
			Salaries.Data.AdminFunctii functie = new Salaries.Data.AdminFunctii(settings.ConnectionString);
			return functie.LoadInfoFunctiiUnion();
		}
		#endregion

		#region LoadInfoCodSiemensNumeFunctie
		/// <summary>
		/// Procedura selecteaza toate functiile sub forma urmatoarei structuri codul Siemens - numele functiei
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele selectate</returns>
		public DataSet LoadInfoCodSiemensNumeFunctie()
		{
			Salaries.Data.AdminFunctii functie = new Salaries.Data.AdminFunctii(settings.ConnectionString);
			return functie.LoadInfoCodSiemensNumeFunctie();
		}
		#endregion

		#region LoadInfoCodCORNumeFunctie
		/// <summary>
		/// Procedura selecteaza toate functiile sub forma urmatoarei structuri codul COR - numele functiei
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele selectate</returns>
		public DataSet LoadInfoCodCORNumeFunctie()
		{		
			Salaries.Data.AdminFunctii functie = new Salaries.Data.AdminFunctii(settings.ConnectionString);
			return functie.LoadInfoCodCORNumeFunctie();
		}
		#endregion	

		#region GetFunctieInfo
		/// <summary>
		/// Procedura selecteaza o functie
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele despre functie</returns>
		public DataSet GetFunctieInfo()
		{
			Salaries.Data.AdminFunctii functie = new Salaries.Data.AdminFunctii(settings.ConnectionString);
			return functie.GetFunctieInfo(functieId);
		}
		#endregion

		#region InsertFunctie
		/// <summary>
		/// Procedura adauga o functie
		/// </summary>
		public void InsertFunctie()
		{
			Salaries.Data.AdminFunctii functie = new Salaries.Data.AdminFunctii(settings.ConnectionString);
			functie.InsertFunctie(functieId, cod, codSiemens, nume, jobFamilyId, tipDeFunctieId, tipDeSegmentId, pozitie, descriere, normaLucru, posibilaScutireImpozit);
		}
		#endregion

		#region UpdateFunctie
		/// <summary>
		/// Procedura actualizeaza o functie
		/// </summary>
		public void UpdateFunctie()
		{
			Salaries.Data.AdminFunctii functie = new Salaries.Data.AdminFunctii(settings.ConnectionString);
			functie.UpdateFunctie(functieId, cod, codSiemens, nume, jobFamilyId, tipDeFunctieId, tipDeSegmentId, pozitie, descriere, normaLucru, posibilaScutireImpozit);
		}
		#endregion

		#region DeleteFunctie
		/// <summary>
		/// Procedura sterge o functie
		/// </summary>
		public void DeleteFunctie()
		{
			Salaries.Data.AdminFunctii functie = new Salaries.Data.AdminFunctii(settings.ConnectionString);
			functie.DeleteFunctie(functieId);
		}
		#endregion

		#region CheckIfFunctieCanBeDeleted
		/// <summary>
		/// Procedura determina daca o functie poate fi stearsa
		/// </summary>
		/// <returns>Returneaza rezultatul verificarii
		/// 0 - se poate sterge functia
		/// 1 - exista date asociate ei
		/// 2 - este ultima din lista
		/// </returns>
		public int CheckIfFunctieCanBeDeleted()
		{
			Salaries.Data.AdminFunctii functie = new Salaries.Data.AdminFunctii(settings.ConnectionString);
			return functie.CheckIfFunctieCanBeDeleted(functieId);
		}
		#endregion

		#region CheckIfToateFunctiileAuCodSiemens
		/// <summary>
		/// Se verifica daca toate functiile au si codul Siemens atasat.
		/// La adaugarea functiei unui angajat in cazul in care o functie nu are cod Siemens atunci in
		/// dropdownlist-ul cu functii va fi afisat Codul COR - Nume functiei, altfel se va afisa
		/// Codul Siemens - Numele functiei
		/// </summary>
		/// <returns>Procerua returneaza true daca functiile au cod Siemens si false altfel</returns>
		public bool CheckIfToateFunctiileAuCodSiemens()
		{
			Salaries.Data.AdminFunctii functie = new Salaries.Data.AdminFunctii(settings.ConnectionString);
			return functie.CheckIfToateFunctiileAuCodSiemens();
		}
		#endregion

		#region CheckIfFunctieCanBeAdded
		/// <summary>
		/// Procedura verifica daca mai exista in baza de date o functie cu acelasi cod
		/// </summary>
		/// <returns>daca nu mai exista o functie cu acelasi cod si deci se poate face adaugare se returneaza true, altfel false</returns>
		public bool CheckIfFunctieCanBeAdded()
		{
			Salaries.Data.AdminFunctii functie = new Salaries.Data.AdminFunctii(settings.ConnectionString);
			return functie.CheckIfFunctieCanBeAdded(functieId, cod, nume);
		}
		#endregion
	}
}
