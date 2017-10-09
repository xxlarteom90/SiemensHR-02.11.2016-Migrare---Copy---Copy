using System;
using System.Data;
using System.Data.SqlClient;

//	Modificat: Lungu Andreea 26.05.2008
// a fost adaugat un nou camp IdCasaDeAsigImplicita

//	Modificat: Lungu Andreea 16.02.2011
// a fost adaugat noi campuri CUI si NrCrtSediuSecundar

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminPunctLucru.
	/// </summary>
	public class AdminPunctLucru : Salaries.Data.DbObject
	{
		#region AdminPunctLucru
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminPunctLucru(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoPunctLucru
		/// <summary>
		/// Se obtin informatiile despre un anumit punct de lucru
		/// </summary>
		/// <param name="punctLucruId"></param>
		/// <returns>Returneaza un DataSet care contine datele despre un punct de lucru</returns>
		public DataSet LoadInfoPunctLucru(int punctLucruId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@PunctLucruID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = punctLucruId;			
			return RunProcedure("GetPunctLucruInfo", parameters, "GetPunctLucruInfo");
		}
		#endregion

		#region LoadInfoPunctLucruAngajator
		/// <summary>
		/// Se obtin Punctele de lucru ale unui anumit angajator
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine punctele de lucru ale angajatorului</returns>
		public DataSet LoadInfoPunctLucruAngajator(int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = angajatorId;			
			return RunProcedure("GetPunctLucruInfoAngajator", parameters, "GetPunctLucruInfoAngajator");
		}
		#endregion

		#region LoadInfoPunctLucruAngajatorUnion
		/// <summary>
		/// Se obtin Punctele de lucru ale unui anumit angajator. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine punctele de lucru ale angajatorului</returns>
		public DataSet LoadInfoPunctLucruAngajatorUnion(int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = angajatorId;			
			return RunProcedure("GetPunctLucruInfoAngajatorUnion", parameters, "GetPunctLucruInfoAngajatorUnion");
		}
		#endregion

		#region LoadInfoPunctLucruAngajatori
		/// <summary>
		/// Se obtin Punctele de lucru ale tuturor angajatorilor
		/// </summary>
		/// <returns>Returneaza un DataSet care contine punctele de lucru ale angajatorilor</returns>
		// Lungu Andreea - 28.05.2008
		public DataSet LoadInfoPunctLucruAngajatori()
		{
			SqlParameter[] parameters = {};
			
			return RunProcedure("GetPunctLucruInfoAngajatori", parameters, "GetPunctLucruInfoAngajatori");
		}
		#endregion

		#region GetPuncteDeLucruAngajatori
		/// <summary>
		/// Se obtin punctele de lucru ale angajatorilor.
		/// </summary>
		/// <returns>Un DataSet ce cuprinde toate punctele de lucru ale angajatorilor.</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  3.06.2006
		/// </remarks>
		public DataSet GetPuncteDeLucruAngajatori()
		{
			SqlParameter[] parameters = {};		
			return RunProcedure("GetPuncteDeLucruAngajatori", parameters, "GetPuncteDeLucruAngajatori");
		}
		#endregion

		#region InsertPunctLucru
		/// <summary>
		/// Procedura adauga un punct de lucru
		/// </summary>
		/// <param name="punctLucruId">Id-ul punctului de lucru</param>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="nume">Numele punctului de lucru</param>
		/// <param name="idCasaDeAsigImplicita">id-ul casei de asigurari</param>
		public void InsertPunctLucru(int punctLucruId, int angajatorId, string nume, int idCasaDeAsigImplicita, string cui, string nrCrtSediuSecundar)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@PunctLucruId", SqlDbType.Int, 4),
								new SqlParameter("@AngajatorId", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@IdCasaDeAsigImplicita",SqlDbType.Int,4),
								new SqlParameter("@Cui", SqlDbType.NVarChar, 20),
								new SqlParameter("@NrCrtSediuSecundar", SqlDbType.NVarChar, 20)
							};

			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = angajatorId;
			parameters[3].Value = nume;
			parameters[4].Value = idCasaDeAsigImplicita;
			parameters[5].Value = cui;
			parameters[6].Value = nrCrtSediuSecundar;

			RunProcedure("InsertUpdateDeletePunctLucru", parameters);
		}
		#endregion

		#region UpdatePunctLucru
		/// <summary>
		/// Procedura actualizeaza un punct de lucru
		/// </summary>
		/// <param name="punctLucruId">Id-ul punctului de lucru care se actualizeaza</param>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="nume">Numele punctului de lucru</param>
	 	/// <param name="idCasaDeAsigImplicita">id-ul casei de asigurari</param>
		public void UpdatePunctLucru(int punctLucruId, int angajatorId, string nume, int idCasaDeAsigImplicita, string cui, string nrCrtSediuSecundar)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@PunctLucruId", SqlDbType.Int, 4),
								new SqlParameter("@AngajatorId", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@IdCasaDeAsigImplicita",SqlDbType.Int,4),
								new SqlParameter("@Cui", SqlDbType.NVarChar, 20),
								new SqlParameter("@NrCrtSediuSecundar", SqlDbType.NVarChar, 20)
							};

			parameters[0].Value = 1;
			parameters[1].Value = punctLucruId;
			parameters[2].Value = angajatorId;
			parameters[3].Value = nume;
			parameters[4].Value = idCasaDeAsigImplicita;
			parameters[5].Value = cui;
			parameters[6].Value = nrCrtSediuSecundar;

			RunProcedure("InsertUpdateDeletePunctLucru", parameters);
		}
		#endregion

		#region DeletePunctLucru
		/// <summary>
		/// Procedura sterge un punct de lucru
		/// </summary>
		/// <param name="punctLucruId">Id-ul puctului de lucru care se sterge</param>	
		public void DeletePunctLucru(int punctLucruId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@PunctLucruId", SqlDbType.Int, 4),
								new SqlParameter("@AngajatorId", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@IdCasaDeAsigImplicita",SqlDbType.Int,4),
								new SqlParameter("@Cui", SqlDbType.NVarChar, 20),
								new SqlParameter("@NrCrtSediuSecundar", SqlDbType.NVarChar, 20)
							};

			parameters[0].Value = 2;
			parameters[1].Value = punctLucruId;
			parameters[2].Value = 0;
			parameters[3].Value = "";
			parameters[4].Value = 0;
			parameters[5].Value = "";
			parameters[6].Value = "";

			RunProcedure("InsertUpdateDeletePunctLucru", parameters);
		}
		#endregion

		#region DeleteAllPunctLucruAngajator
		/// <summary>
		/// Sunt sterse toate domeniile de activitate ale angajatorului cu id-ul AngajatorID
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului pentru care se sterg punctele de lucru</param>
		public void DeleteAllPunctLucruAngajator(int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorId", SqlDbType.Int, 4)
							};

			parameters[0].Value = angajatorId;
			RunProcedure("DeleteAllPunctLucruAngajator", parameters);
		}
		#endregion

		#region CheckIfPunctLucruCanBeDeleted
		/// <summary>
		/// Verifica daca un punct de lucru poate fi sters, adica nu sunt angajati pentru el
		/// </summary>
		/// <param name="punctLucruId">Id-ul punctului de lucru pentru care se face verificarea</param>
		/// <returns>Returneaza true daca se poate efectua stergerea si false altfel</returns>
		public bool CheckIfPunctLucruCanBeDeleted(int punctLucruId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@PunctLucruID", SqlDbType.Int, 4)
							};

			parameters[0].Value = punctLucruId;
			DataSet ds = RunProcedure("spCheckIfPunctLucruCanBeDeleted", parameters, "CheckIfPunctLucruCanBeDeleted");

			if (Convert.ToInt32(ds.Tables[0].Rows[0]["norec"].ToString())>0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		#endregion
	}
}
