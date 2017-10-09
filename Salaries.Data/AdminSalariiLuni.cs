using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminSalariiLuni.
	/// </summary>
	public class AdminSalariiLuni : Salaries.Data.DbObject
	{
		#region AdminSalariiLuni
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminSalariiLuni(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoLuniSalarii
		/// <summary>
		/// Procedura selecteaza lunile de salarii existente in baza de date
		/// </summary>
		/// <returns>Procedura returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadInfoLuniSalarii()
		{
			SqlParameter[] parameters = {};		
			return RunProcedure("GetLuniSalarii", parameters, "GetLuniSalarii");
		}
		#endregion

		#region LoadInfoLuniSalariiUnion
		/// <summary>
		/// Sunt selectate toate lunile. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoLuniSalariiUnion()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("spGetAllLuniTextUnion", parameters, "GetAllLuniTextUnion");
		}
		#endregion
	}
}
