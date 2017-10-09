/*
 * Author:	Lungu Andreea
 * Date:	23.08.2010
 * Description:	Type of employee - for different users
 */

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for NivelAngajat.
	/// </summary>
	public class NivelAngajat : Salaries.Data.DbObject
	{
		#region NivelAngajat
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public NivelAngajat(string connectionString) : base (connectionString)
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

		#region LoadNivelePentruAngajat
		/// <summary>
		/// Procedura selecteaza toate nivelele
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste nivele</returns>
		public DataSet LoadNivelePentruAngajat(int angajatorId, long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatorID", SqlDbType.BigInt, 10),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatorId;
			parameters[1].Value = angajatId;
			return RunProcedure("spNivele_GetAllNiveleAngajat", parameters, "GetAllNiveleAngajat");
		}
		#endregion

		#region EsteAngajatInNivel
		/// <summary>
		/// Procedura selecteaza toate nivelele
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste nivele</returns>
		public bool EsteAngajatInNivel(long angajatId, long idNivel)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@IdNivel", SqlDbType.BigInt, 10),
					new SqlParameter("@Nr", SqlDbType.Int, 4)
				};
			parameters[0].Value = angajatId;
			parameters[1].Value = idNivel;
			parameters[2].Direction = ParameterDirection.Output;
			RunProcedure("spNivele_CheckIfAngajatIsInNivel", parameters, "CheckIfAngajatIsInNivel");
			if (Int32.Parse(parameters[2].Value.ToString()) == 0)
				return false;
			else
				return true;
		}
		#endregion

		#region RemoveAngajatFromNivel
		/// <summary>
		/// Procedura sterge legatura dintre un angajat si un nivel
		/// </summary>
		public void RemoveAngajatFromNivel(long angajatId, int idNivel)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@IdNivel", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatId;
			parameters[1].Value = idNivel;
			RunProcedure("spNivele_RemoveAngajatFromNivel", parameters, "RemoveAngajatFromNivel");
		}
		#endregion

		#region AddAngajatInNivel
		/// <summary>
		/// Procedura adauga legatura dintre un angajat si un nivel
		/// </summary>
		public void AddAngajatInNivel(long angajatId, int idNivel)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@IdNivel", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatId;
			parameters[1].Value = idNivel;
			RunProcedure("spNivele_AddAngajatInNivel", parameters, "AddAngajatInNivel");
		}
		#endregion

		#region GetAngajatiPentruUtilizator
		/// <summary>
		/// Procedura aduce angajatii la care acces un utilizator.
		/// </summary>
		public DataSet GetAngajatiPentruUtilizator(long angajatorId, int idUtilizator)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@UtilizatorID", SqlDbType.BigInt, 10),
					new SqlParameter("@AngajatorId", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = idUtilizator;
			parameters[1].Value = angajatorId;
			return RunProcedure("GetAngajatiPentruUtilizator", parameters, "GetAngajatiPentruUtilizator");
		}
		#endregion
	}
}
