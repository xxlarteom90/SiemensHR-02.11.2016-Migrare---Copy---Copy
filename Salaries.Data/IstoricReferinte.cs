using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for IstoricReferinte.
	/// </summary>
	public class IstoricReferinte : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public IstoricReferinte(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadReferinte
		/// <summary>
		/// Procedura selecteaza referintele unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadReferinte(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatId;
			return RunProcedure("GetReferinteAngajat", parameters, "GetReferinteAngajat");
		}
		#endregion

		#region InsertReferinta
		/// <summary>
		/// Procedura adauga o referinta
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="titlu">Titlul referintei</param>
		/// <param name="data">Data referintei</param>
		/// <param name="descriere">Descrierea referintei</param>
		/// <returns>Returneaza true daca a fost facuta adaugarea si false altfel</returns>
		public bool InsertReferinta(long angajatId, string titlu, DateTime data, string descriere)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@ReferintaID", SqlDbType.BigInt, 10),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@Titlu", SqlDbType.NVarChar, 255),
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@Descriere", SqlDbType.NText,4096),
					new SqlParameter("@rc", SqlDbType.Int)
				};
			
			parameters[0].Value = -1;
			parameters[1].Value = angajatId;
			parameters[2].Value = titlu;
			if (data == DateTime.MinValue)
			{
				parameters[3].Value = System.DBNull.Value;
			}
			else
			{
				parameters[3].Value = data;
			}
			parameters[4].Value = descriere;
			parameters[5].Direction = ParameterDirection.ReturnValue;
			
			RunProcedure("InsertUpdateDeleteReferinta", parameters);
			if ((int)parameters[5].Value == -1 )
				return false;

			return true;
		}
		#endregion

		#region UpdateReferinta
		/// <summary>
		/// Procedura actualizeaza o referinta
		/// </summary>
		/// <param name="referintaId">Id-ul referintei</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="titlu">Titlul referintei</param>
		/// <param name="data">Data referintei</param>
		/// <param name="descriere">Descrierea referintei</param>
		/// <returns>Returneaza true daca a fost facuta modificarea si false altfel</returns>
		public bool UpdateReferinta(int referintaId, long angajatId, string titlu, DateTime data, string descriere)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@ReferintaID", SqlDbType.BigInt, 10),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@Titlu", SqlDbType.NVarChar, 255),
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@Descriere", SqlDbType.NText,4096),
					new SqlParameter("@rc", SqlDbType.Int)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = referintaId;
			parameters[2].Value = angajatId;
			parameters[3].Value = titlu;
			if (data == DateTime.MinValue)
			{
				parameters[4].Value = System.DBNull.Value;
			}
			else
			{
				parameters[4].Value = data;
			}
			parameters[5].Value = descriere;
			parameters[6].Direction = ParameterDirection.ReturnValue;
			
			RunProcedure("InsertUpdateDeleteReferinta", parameters);
			if ((int)parameters[6].Value == -1 )
				return false;

			return true;
		}
		#endregion

		#region DeleteReferinta
		/// <summary>
		/// Procedura sterge o referinta
		/// </summary>
		/// <param name="referintaId">Id-ul referintei care se sterge</param>
		public void DeleteReferinta(int referintaId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@ReferintaID", SqlDbType.BigInt, 10),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@Titlu", SqlDbType.NVarChar, 255),
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@Descriere", SqlDbType.NText,4096)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = referintaId;
			parameters[2].Value = 0;
			parameters[3].Value = "";
			parameters[4].Value = DateTime.Now;
			parameters[5].Value = "";
			
			RunProcedure("InsertUpdateDeleteReferinta", parameters);
		}
		#endregion
	}
}
