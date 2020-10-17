using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminCentreCost.
	/// </summary>
	public class AdminCentreCost : Salaries.Data.DbObject
	{
		#region AdminCentreCost
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminCentreCost(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoCentreCost
		/// <summary>
		/// Procedura selecteaza toate contrele de cost
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste centre de cost</returns>
		public DataSet LoadInfoCentreCost()
		{
			SqlParameter[] parameters = {};					
			return RunProcedure("spGetAllCentreCost", parameters, "GetAllCentreCost");
		}
		#endregion

		#region InsertCentruCost
		/// <summary>
		/// Procedura adauga un centru de cost
		/// </summary>
		/// <param name="centruCostId">Id-ul centrului de cost</param>
		/// <param name="cod">Codul centrului de cost</param>
		/// <param name="nume">Denumirea centrului de cost</param>
		/// <param name="descriere">Descrierea centrului de cost</param>
		public void InsertCentruCost(int centruCostId, string cod, string nume, string descriere)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@CentruCostID", SqlDbType.Int, 4),
								new SqlParameter("@Cod", SqlDbType.NVarChar, 20),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255)
							};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = cod;
			parameters[3].Value = nume;
			parameters[4].Value = descriere;
			
			RunProcedure("InsertUpdateDeleteCentruCost", parameters);
		}
		#endregion

		#region UpdateCentruCost
		/// <summary>
		/// Procedura actualizeaza un centru de cost
		/// </summary>
		/// <param name="centruCostId">Id-ul centrului de cost</param>
		/// <param name="cod">Codul centrului de cost</param>
		/// <param name="nume">Denumirea centrului de cost</param>
		/// <param name="descriere">Descrierea centrului de cost</param>
		public void UpdateCentruCost(int centruCostId, string cod, string nume, string descriere)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@CentruCostID", SqlDbType.Int, 4),
								new SqlParameter("@Cod", SqlDbType.NVarChar, 10),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255)
							};
			
			parameters[0].Value = 1;
			parameters[1].Value = centruCostId;
			parameters[2].Value = cod;
			parameters[3].Value = nume;
			parameters[4].Value = descriere;
			
			RunProcedure("InsertUpdateDeleteCentruCost", parameters);
		}
		#endregion

		#region DeleteCentruCost
		/// <summary>
		/// Procedura sterge un centru de cost
		/// </summary>
		/// <param name="centruCostId">Id-ul centrului de cost care se sterge</param>
		public void DeleteCentruCost(int centruCostId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@CentruCostID", SqlDbType.Int, 4),
								new SqlParameter("@Cod", SqlDbType.NVarChar, 10),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255)
							};
			
			parameters[0].Value = 2;
			parameters[1].Value = centruCostId;
			parameters[2].Value = 0;
			parameters[3].Value = "";
			parameters[4].Value = "";
			
			RunProcedure("InsertUpdateDeleteCentruCost", parameters);
		}
		#endregion

		#region GetCentruCostInfo
		/// <summary>
		/// Procedura selecteaza un centru de cost
		/// </summary>
		/// <param name="centruCostId">Id-ul centrului de cost selectat</param>
		/// <returns>Returneaza un DataSet care contine datele despre un centru de cost</returns>
		public DataSet GetCentruCostInfo(int centruCostId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@CentruCostID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = centruCostId;
			return RunProcedure("spGetCentruCost", parameters, "GetCentruCost");
		}
		#endregion

		#region CheckIfCentruCostCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un centru de cost se poate sterge
		/// </summary>
		/// <param name="centruCostId">Id-ul centrului de cost care se verifica daca se poate sterge</param>
		/// <returns>Returneaza rezultatul verificarii</returns>
		public int CheckIfCentruCostCanBeDeleted(int centruCostId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@CentruCostID", SqlDbType.Int, 4),
								new SqlParameter("@SePoateSterge", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = centruCostId;
			parameters[1].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfCentruCostCanBeDeleted", parameters);
			return int.Parse(parameters[1].Value.ToString());
		}
		#endregion

		#region CheckIfCentruCostCanBeAdded
		/// <summary>
		/// Procedura verifica sa nu se creeze duplicate la daugare sau modificare in tabela CentreCost
		/// </summary>
		/// <param name="centruCostID">Id-ul centrului de cost care nu trebuie sa coincida</param>
		/// <param name="cod">Codul centrului de cost</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfCentruCostCanBeAdded(int centruCostId, string cod)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@CentruCostID", SqlDbType.Int, 4),
								new SqlParameter("@Cod", SqlDbType.NVarChar, 10),
								new SqlParameter("@NrCentre", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = centruCostId;
			parameters[1].Value = cod;
			parameters[2].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfAdminCentruCostCanBeAdded", parameters);
			return byte.Parse(parameters[2].Value.ToString())  == 0;
		}
		#endregion

		#region GetCentruCostPentruDepartament
		/// <summary>
		/// Procedura determina centrul de cost al unui departament
		/// </summary>
		/// <param name="departamentId">Id-ul departamentului pentru care se determina centrul de cost</param>
		/// <returns>Returneaza id-ul centrului de cost corespunzator departamentului</returns>
		public int GetCentruCostPentruDepartament(int departamentId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@DepartamentID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = departamentId;
			DataSet ds = RunProcedure("spGetCentruCostPentruDepartament", parameters, "GetCentruCostPentruDepartament");
			
			if (ds.Tables[0].Rows.Count > 0)
				return int.Parse(ds.Tables[0].Rows[0]["CentruCostID"].ToString());
			else
				return -1;
		}
		#endregion
	}
}
