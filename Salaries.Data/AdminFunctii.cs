using System;
using System.Data;
using System.Data.SqlClient;

// Modificat:	Lungu Andreea
// Data:		22.07.2008
// Descriere:	A fost adaugat atributul suporta scutire impozit (posibilaScutireImpozit)

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminFunctii.
	/// </summary>
	public class AdminFunctii : Salaries.Data.DbObject
	{
		#region AdminFunctii
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminFunctii(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoFunctii
		/// <summary>
		/// Procedura selecteaza toate functiile
		/// </summary>
		public DataSet LoadInfoFunctii()
		{
			SqlParameter[] parameters = {};				
			return RunProcedure("spGetAllFunctii", parameters, "GetAllFunctii");
		}
		#endregion

		#region LoadInfoFunctiiUnion
		/// <summary>
		/// Sunt selectate toate functiile. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care cotine aceste inregistrari</returns>
		public DataSet LoadInfoFunctiiUnion()
		{
			SqlParameter[] parameters = {};				
			return RunProcedure("spGetAllFunctiiUnion", parameters, "GetAllFunctiiUnion");
		}
		#endregion

		#region LoadInfoCodSiemensNumeFunctie
		/// <summary>
		/// Procedura selecteaza toate functiile sub forma urmatoarei structuri codul Siemens - numele functiei
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele selectate</returns>
		public DataSet LoadInfoCodSiemensNumeFunctie()
		{
			SqlParameter[] parameters = {};				
			return RunProcedure("spGetAllFunctiiCodSiemensNumeFunctie", parameters, "GetAllFunctiiCodSiemensNumeFunctie");
		}
		#endregion

		#region LoadInfoCodCORNumeFunctie
		/// <summary>
		/// Procedura selecteaza toate functiile sub forma urmatoarei structuri codul COR - numele functiei
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele selectate</returns>
		public DataSet LoadInfoCodCORNumeFunctie()
		{		
			SqlParameter[] parameters = {};				
			return RunProcedure("spGetAllFunctiiCodCORNumeFunctie", parameters, "GetAllFunctiiCodCORNumeFunctie");
		}
		#endregion	

		#region GetFunctieInfo
		/// <summary>
		/// Procedura selecteaza o functie
		/// </summary>
		/// <param name="functieId">Id-ul functiei selectate</param>
		/// <returns>Returneaza un DataSet care contine datele despre functie</returns>
		public DataSet GetFunctieInfo(int functieId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@FunctieID", SqlDbType.Int, 4)
							};

			parameters[0].Value = functieId;
			return RunProcedure("spGetFunctie", parameters, "GetFunctie");
		}
		#endregion

		#region InsertFunctie
		/// <summary>
		/// Procedura adauga o functie
		/// </summary>
		/// <param name="functieId">Id-ul functiei</param>
		/// <param name="cod">Codul fucntiei</param>
		/// <param name="codSiemens">Codul Siemens al functiei</param>
		/// <param name="nume">Denumirea functiei</param>
		/// <param name="jobFamilyId">Id-ul familiei de functii</param>
		/// <param name="tipDeFunctieId">Id-ul tipului de functie</param>
		/// <param name="tipDeSegmentId">Id-ul tipului de segment</param>
		/// <param name="pozitie">Pozitia functiei</param>
		/// <param name="descriere">Descrierea functiei</param>
		/// <param name="norma">Norma functiei</param>
		/// <param name="posibilaScutireImpozit">Posibilitatea de a suporta sau nu scutirea de impozit</param>						
		public void InsertFunctie(int functieId, long cod, string codSiemens, string nume, int jobFamilyId, int tipDeFunctieId, int tipDeSegmentId, int pozitie, string descriere, int norma, bool posibilaScutireImpozit)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@FunctieID", SqlDbType.Int, 4),
								new SqlParameter("@Cod", SqlDbType.BigInt, 10),
								new SqlParameter("@CodSiemens", SqlDbType.NVarChar, 20),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@JobFamilyId", SqlDbType.Int, 4),
								new SqlParameter("@TipDeFunctieId", SqlDbType.Int, 4),
								new SqlParameter("@TipDeSegmentId", SqlDbType.Int, 4),
								new SqlParameter("@Pozitie", SqlDbType.Int, 4),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255),
								new SqlParameter("@NormaLucru", SqlDbType.Int, 2),
								new SqlParameter("@PosibilaScutireImpozit", SqlDbType.Bit, 1)
							};

			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = cod;
			parameters[3].Value = codSiemens;
			parameters[4].Value = nume;
			parameters[5].Value = jobFamilyId;
			parameters[6].Value = tipDeFunctieId;
			parameters[7].Value = tipDeSegmentId;
			parameters[8].Value = pozitie;
			parameters[9].Value = descriere;
			parameters[10].Value = norma;
			parameters[11].Value = posibilaScutireImpozit;

			RunProcedure("InsertUpdateDeleteFunctie", parameters);
		}
		#endregion

		#region UpdateFunctie
		/// <summary>
		/// Procedura actualizeaza o functie
		/// </summary>
		/// <param name="functieId">Id-ul functiei</param>
		/// <param name="cod">Codul fucntiei</param>
		/// <param name="codSiemens">Codul Siemens al functiei</param>
		/// <param name="nume">Denumirea functiei</param>
 		/// <param name="jobFamilyId">Id-ul familiei de functii</param>
		/// <param name="tipDeFunctieId">Id-ul tipului de functie</param>
		/// <param name="tipDeSegmentId">Id-ul tipului de segment</param>
		/// <param name="pozitie">Pozitia functiei</param>
		/// <param name="descriere">Descrierea functiei</param>
		/// <param name="norma">Norma functiei</param>
		/// <param name="posibilaSutireImpozit">Posibilitatea de a suporta sau nu scutirea de impozit</param>
		public void UpdateFunctie(int functieId, long cod, string codSiemens, string nume, int jobFamilyId, int tipDeFunctieId, int tipDeSegmentId, int pozitie, string descriere, int norma, bool posibilaScutireImpozit)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@FunctieID", SqlDbType.Int, 4),
								new SqlParameter("@Cod", SqlDbType.BigInt, 10),
								new SqlParameter("@CodSiemens", SqlDbType.NVarChar, 20),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@JobFamilyId", SqlDbType.Int, 4),
								new SqlParameter("@TipDeFunctieId", SqlDbType.Int, 4),
								new SqlParameter("@TipDeSegmentId", SqlDbType.Int, 4),
								new SqlParameter("@Pozitie", SqlDbType.Int, 4),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255),
								new SqlParameter("@NormaLucru", SqlDbType.Int, 2),
								new SqlParameter("@PosibilaScutireImpozit", SqlDbType.Bit, 1)
							};

			parameters[0].Value = 1;
			parameters[1].Value = functieId;
			parameters[2].Value = cod;
			parameters[3].Value = codSiemens;
			parameters[4].Value = nume;
			parameters[5].Value = jobFamilyId;
			parameters[6].Value = tipDeFunctieId;
			parameters[7].Value = tipDeSegmentId;
			parameters[8].Value = pozitie;
			parameters[9].Value = descriere;
			parameters[10].Value = norma;
			parameters[11].Value = posibilaScutireImpozit;

			RunProcedure("InsertUpdateDeleteFunctie", parameters);
		}
		#endregion

		#region DeleteFunctie
		/// <summary>
		/// Procedura sterge o functie
		/// </summary>
		/// <param name="functieId">Id-ul functiei</param>
		public void DeleteFunctie(int functieId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@FunctieID", SqlDbType.Int, 4),
								new SqlParameter("@Cod", SqlDbType.BigInt, 10),
								new SqlParameter("@CodSiemens", SqlDbType.NVarChar, 20),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@JobFamilyId", SqlDbType.Int, 4),
								new SqlParameter("@TipDeFunctieId", SqlDbType.Int, 4),
								new SqlParameter("@TipDeSegmentId", SqlDbType.Int, 4),
								new SqlParameter("@Pozitie", SqlDbType.Int, 4),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255),
								new SqlParameter("@NormaLucru", SqlDbType.Int, 2),
								new SqlParameter("@PosibilaScutireImpozit", SqlDbType.Bit, 1)
							};

			parameters[0].Value = 2;
			parameters[1].Value = functieId;
			parameters[2].Value = 0;
			parameters[3].Value = "";
			parameters[4].Value = "";
			parameters[5].Value = 0;
			parameters[6].Value = 0;
			parameters[7].Value = 0;
			parameters[8].Value = 0;
			parameters[9].Value = "";
			parameters[10].Value = 0;
			parameters[11].Value = false;

			RunProcedure("InsertUpdateDeleteFunctie", parameters);
		}
		#endregion

		#region CheckIfFunctieCanBeDeleted
		/// <summary>
		/// Procedura determina daca o functie poate fi stearsa
		/// </summary>
		/// <param name="FunctieID">Id-ul functiei pentru care se face verificarea</param>
		/// <returns>Returneaza rezultatul verificarii
		/// 0 - se poate sterge functia
		/// 1 - exista date asociate ei
		/// 2 - este ultima din lista
		/// </returns>
		public int CheckIfFunctieCanBeDeleted(int functieId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@FunctieID", SqlDbType.Int, 4),
								new SqlParameter("@SePoateSterge", SqlDbType.Int, 2)
							};

			parameters[0].Value = functieId;
			parameters[1].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfFunctieCanBeDeleted", parameters);
			return int.Parse(parameters[1].Value.ToString());
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
			SqlParameter[] parameters = {};
			DataSet ds = RunProcedure("CheckIfToateFunctiileAuCodSiemens", parameters, "CheckIfToateFunctiileAuCodSiemens");
			if (Convert.ToInt32(ds.Tables[0].Rows[0]["norec"])>0)
				return false;
			else
				return true;
		}
		#endregion

		#region CheckIfFunctieCanBeAdded
		/// <summary>
		/// Procedura verifica daca mai exista in baza de date o functie cu acelasi cod
		/// </summary>
		/// <param name="functieId">id/ul functiei fata de care trebuie sa fie diferit</param>
		/// <param name="cod">codul care se cauta pentru o functie</param>
		/// <param name="nume">numele functiei care se adauga</param>
		/// <returns>daca nu mai exista o functie cu acelasi cod si deci se poate face adaugare se returneaza true, altfel false</returns>
		public bool CheckIfFunctieCanBeAdded(int functieId, long cod, string nume)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@Cod", SqlDbType.BigInt, 8),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@FunctieID", SqlDbType.Int, 4),
								new SqlParameter("@NrFunctii", SqlDbType.Int, 4)
							};

			parameters[0].Value = cod;
			parameters[1].Value = nume;
			parameters[2].Value = functieId;
			parameters[3].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfFunctieCanBeAdded", parameters);
			return byte.Parse(parameters[3].Value.ToString()) == 0;
		}
		#endregion
	}
}
