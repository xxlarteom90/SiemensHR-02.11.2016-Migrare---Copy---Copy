/*
 * Author:	Lungu Andreea
 * Date:	08.10.2010
 * Description:	Type of employee - for different users
 */

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for NivelUtilizator.
	/// </summary>
	public class NivelUtilizator : Salaries.Data.DbObject
	{
		#region NivelUtilizator
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public NivelUtilizator(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadNivele
		/// <summary>
		/// Procedura selecteaza toate nivelele
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste nivele</returns>
		public DataSet LoadNivele(int angajatorId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatorID", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatorId;
			return RunProcedure("spNivele_GetAllNivele", parameters, "GetAllNivele");
		}
		#endregion

		#region LoadNivelePentruUtilizator
		/// <summary>
		/// Procedura selecteaza toate nivelele
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste nivele</returns>
		public DataSet LoadNivelePentruUtilizator(int angajatorId, long utilizatorId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatorID", SqlDbType.BigInt, 10),
					new SqlParameter("@UtilizatorID", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatorId;
			parameters[1].Value = utilizatorId;
			return RunProcedure("spNivele_GetAllNiveleUtilizator", parameters, "GetAllNiveleUtilizator");
		}
		#endregion

		#region EsteUtilizatorInNivel
		/// <summary>
		/// Procedura selecteaza toate nivelele
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste nivele</returns>
		public bool EsteUtilizatorInNivel(long utilizatorId, long idNivel)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@UtilizatorID", SqlDbType.BigInt, 10),
					new SqlParameter("@IdNivel", SqlDbType.BigInt, 10),
					new SqlParameter("@Nr", SqlDbType.Int, 4)
				};
			parameters[0].Value = utilizatorId;
			parameters[1].Value = idNivel;
			parameters[2].Direction = ParameterDirection.Output;
			RunProcedure("spNivele_CheckIfUtilizatorIsInNivel", parameters, "CheckIfUtilizatorIsInNivel");
			if (Int32.Parse(parameters[2].Value.ToString()) == 0)
				return false;
			else
				return true;
		}
		#endregion

		#region RemoveUtilizatorFromNivel
		/// <summary>
		/// Procedura sterge legatura dintre un utilizator si un nivel
		/// </summary>
		public void RemoveUtilizatorFromNivel(long utilizatorId, int idNivel)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@UtilizatorID", SqlDbType.BigInt, 10),
					new SqlParameter("@IdNivel", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = utilizatorId;
			parameters[1].Value = idNivel;
			RunProcedure("spNivele_RemoveUtilizatorFromNivel", parameters, "RemoveUtilizatorFromNivel");
		}
		#endregion

		#region AddUtilizatorInNivel
		/// <summary>
		/// Procedura adauga legatura dintre un angajat si un nivel
		/// </summary>
		public void AddUtilizatorInNivel(long utilizatorId, int idNivel)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@UtilizatorID", SqlDbType.BigInt, 10),
					new SqlParameter("@IdNivel", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = utilizatorId;
			parameters[1].Value = idNivel;
			RunProcedure("spNivele_AddUtilizatorInNivel", parameters, "AddUtilizatorInNivel");
		}
		#endregion
	}
}
