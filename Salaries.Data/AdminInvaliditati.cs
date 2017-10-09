using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminInvaliditati.
	/// </summary>
	public class AdminInvaliditati : Salaries.Data.DbObject
	{
		#region AdminInvaliditati
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminInvaliditati(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoInvaliditati
		/// <summary>
		/// Procedura selecteaza toate invaliditatile
		/// </summary>
		/// <returns></returns>
		public DataSet LoadInfoInvaliditati()
		{
			SqlParameter[] parameters = {};			
			return RunProcedure("spGetAllInvaliditati", parameters, "GetAllInvaliditati");
		}
		#endregion

		#region InsertInvaliditate
		/// <summary>
		/// Procedura adauga o invaliditate
		/// </summary>
		/// <param name="invaliditateId">Id-ul invaliditatii</param>
		/// <param name="nume">Denumirea invaliditatii</param>
		/// <param name="coeficient">Coeficientul invaliditatii</param>
		/// <param name="descriere">Descrierea invaliditatii</param>
		public void InsertInvaliditate(int invaliditateId, string nume, double coeficient, string descriere)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@InvaliditateID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Coeficient", SqlDbType.Float, 8),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255)
							};

			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = nume;
			parameters[3].Value = coeficient;
			parameters[4].Value = descriere;

			RunProcedure("InsertUpdateDeleteInvaliditate", parameters);
		}
		#endregion

		#region UpdateInvaliditate
		/// <summary>
		/// Procedura actualizeaza o invaliditate
		/// </summary>
		/// <param name="invaliditateId">Id-ul invaliditatii</param>
		/// <param name="nume">Denumirea invaliditatii</param>
		/// <param name="coeficient">Coeficientul invaliditatii</param>
		/// <param name="descriere">Descrierea invaliditatii</param>
		public void UpdateInvaliditate(int invaliditateId, string nume, double coeficient, string descriere)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@InvaliditateID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Coeficient", SqlDbType.Float, 8),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255)
							};

			parameters[0].Value = 1;
			parameters[1].Value = invaliditateId;
			parameters[2].Value = nume;
			parameters[3].Value = coeficient;
			parameters[4].Value = descriere;

			RunProcedure("InsertUpdateDeleteInvaliditate", parameters);
		}
		#endregion

		#region DeleteInvaliditate
		/// <summary>
		/// Procedura sterge o invaliditate
		/// </summary>
		/// <param name="invaliditateId">Id-ul invaliditatii care se sterge</param>
		public void DeleteInvaliditate(int invaliditateId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@InvaliditateID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Coeficient", SqlDbType.Float, 8),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255)
							};

			parameters[0].Value = 2;
			parameters[1].Value = invaliditateId;
			parameters[2].Value = "";
			parameters[3].Value = 0;
			parameters[4].Value = "";

			RunProcedure("InsertUpdateDeleteInvaliditate", parameters);
		}
		#endregion

		#region GetInvaliditateInfo
		/// <summary>
		/// Procedura selecteaza o invaliditate
		/// </summary>
		/// <param name="invaliditateId">Id-ul invaliditatii selectate</param>
		/// <returns>Returneaza un DataSet care contine datele despre invaliditate</returns>
		public DataSet GetInvaliditateInfo(int invaliditateId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@InvaliditateID", SqlDbType.Int, 4)
							};
			parameters[0].Value = invaliditateId;
			return RunProcedure("spGetInvaliditate", parameters, "GetInvaliditate");
		}
		#endregion

		#region CheckIfInvaliditateCanBeDeleted
		/// <summary>
		/// Procedura verifica daca o invaliditate poate fi stearsa, adica nu exista inregistrari in tabela AngajatPersoaneInIntretinere si tm_IntervaleAngajat
		/// </summary>
		/// <param name="invaliditateID">Id-ul invaliditatii care se verifica</param>
		/// <returns>Returneaza true daca se poate face stergerea si false altfel</returns>
		public int CheckIfInvaliditateCanBeDeleted(int invaliditateId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@InvaliditateID", SqlDbType.Int, 4),
								new SqlParameter("@Raspuns", SqlDbType.Int, 4)
							};

			parameters[0].Value = invaliditateId;
			parameters[1].Direction = ParameterDirection.ReturnValue;

			RunProcedure("spCheckIfInvaliditateCanBeDeleted", parameters);
			return int.Parse(parameters[1].Value.ToString());
		}
		#endregion

		#region CheckIfInvaliditateCanBeAdded
		/// <summary>
		/// Procedura verifica daca mai exista in baza de date o invaliditate cu aceleasi date
		/// </summary>
		/// <param name="invaliditateID">Id-ul invaliditatii care se verifica</param>
		/// <param name="nume">Numele invaliditatii</param>
		/// <param name="coeficient">Coeficientul invaliditatii</param>
		/// <returns>Returneaza true daca se poate face modificarea si false altfel</returns>
		public bool CheckIfInvaliditateCanBeAdded(int invaliditateId, string nume, float coeficient)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@InvaliditateID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Coeficient", SqlDbType.Float, 8),
								new SqlParameter("@NrInvaliditati", SqlDbType.Int, 4)
							};

			parameters[0].Value = invaliditateId;
			parameters[1].Value = nume;
			parameters[2].Value = coeficient;
			parameters[3].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfInvaliditateCanBeAdded", parameters);
			return byte.Parse(parameters[3].Value.ToString()) == 0;
		}
		#endregion
	}
}
