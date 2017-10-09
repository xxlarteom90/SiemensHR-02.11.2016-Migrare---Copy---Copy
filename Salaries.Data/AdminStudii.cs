using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminStudii.
	/// </summary>
	public class AdminStudii : Salaries.Data.DbObject
	{
		#region AdminStudii
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminStudii(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoStudii
		/// <summary>
		/// Procedura selecteaza toate categoriile de studii
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele specificate</returns>
		public DataSet LoadInfoStudii()
		{
			SqlParameter[] parameters = {};		
			return RunProcedure("spGetAllStudii", parameters, "GetAllStudii");
		}
		#endregion

		#region LoadInfoStudiiUnion
		/// <summary>
		/// Sunt selectate toate studiile. La aceste inregistrari se adauga o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoStudiiUnion()
		{
			SqlParameter[] parameters = {};		
			return RunProcedure("spGetAllStudiiUnion", parameters, "GetAllStudiiUnion");
		}
		#endregion

		#region InsertStudiu
		/// <summary>
		/// Procedura adauga o categorie de studii
		/// </summary>
		/// <param name="studiuId">Id-ul categoriei de studii</param>
		/// <param name="nume">Denumirea categoriei de studii care se adauga</param>
		public void InsertStudiu(int studiuId, string nume)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@StudiuID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 100)
							};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = nume;

			RunProcedure("InsertUpdateDeleteStudiu", parameters);
		}
		#endregion

		#region UpdateStudiu
		/// <summary>
		/// Procedura actualizeaza o categorie de studii
		/// </summary>
		/// <param name="studiuId">Id-ul categoriei de studii</param>
		/// <param name="nume">Denumirea categoriei de studii care se adauga</param>
		public void UpdateStudiu(int studiuId, string nume)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@StudiuID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 100)
							};
			
			parameters[0].Value = 1;
			parameters[1].Value = studiuId;
			parameters[2].Value = nume;

			RunProcedure("InsertUpdateDeleteStudiu", parameters);
		}
		#endregion

		#region DeleteStudiu
		/// <summary>
		/// Procedura sterge o categorie de studii
		/// </summary>
		/// <param name="studiuId">Id-ul categoriei de studii</param>
		public void DeleteStudiu(int studiuId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@StudiuID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 100)
							};
			
			parameters[0].Value = 2;
			parameters[1].Value = studiuId;
			parameters[2].Value = "";

			RunProcedure("InsertUpdateDeleteStudiu", parameters);
		}
		#endregion

		#region GetStudiuInfo
		/// <summary>
		/// Procedura selecteaza o categorie de studii
		/// </summary>
		/// <param name="studiuId">Id-ul categoriei de studii selectata</param>
		/// <returns>Returneaza un DataSet care contine categoria de studii selectata</returns>
		public DataSet GetStudiuInfo(int studiuId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@StudiuID", SqlDbType.Int, 4)
							};
			parameters[0].Value = studiuId;
			return RunProcedure("spGetStudiu", parameters, "GetStudiu");
		}
		#endregion

		#region CheckIfStudiuCanBeDeleted
		/// <summary>
		/// Procedura verifica daca o categorie de studii poate fi stearsa
		/// </summary>
		/// <param name="StudiuID">Id-ul studiului care se verifica</param>
		/// <returns>Returneaza rezultatul verificarii
		/// 0 - se poate sterge categoria
		/// 1 - categoria este asociata unor angajati
		/// 2 - categoria este ultima din lista
		/// </returns>
		public int CheckIfStudiuCanBeDeleted(int studiuId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@StudiuID", SqlDbType.Int, 4),
								new SqlParameter("@SePoateSterge", SqlDbType.Int, 4)
							};
			parameters[0].Value = studiuId;
			parameters[1].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfStudiuCanBeDeleted", parameters);
			return int.Parse(parameters[1].Value.ToString());
		}
		#endregion

		#region CheckIfStudiuCanBeAdded
		/// <summary>
		/// Procedura verifica sa nu se adauge duplicate in tabela Studii
		/// </summary>
		/// <param name="studiuID">Id-ul studiului care nu trebuie sa coincida</param>
		/// <param name="nume">Numele studiului</param>
		/// <returns>Returneaza true daca se poate face adaugarea si false altfel</returns>
		public bool CheckIfStudiuCanBeAdded(int studiuId, string nume)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@Nume", SqlDbType.NVarChar, 100),
								new SqlParameter("@StudiuID", SqlDbType.Int, 4),
								new SqlParameter("@NrStudii", SqlDbType.Int, 4)
							};
			parameters[0].Value = nume;
			parameters[1].Value = studiuId;
			parameters[2].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfStudiuCanBeAdded", parameters);
			return byte.Parse(parameters[2].Value.ToString()) == 0;
		}
		#endregion
	}
}
