/*
 * Autor:		Oprescu Claudia
 * Data:		10.07.2007
 * Descriere:	Clasa se ocupa cu Familiile de functii.
 */

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminJobFamily.
	/// </summary>
	public class AdminJobFamily : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public AdminJobFamily(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadJobFamily
		/// <summary>
		/// Procedura selecteaza Familiile de functii
		/// </summary>
		/// <returns>Returneaza un DataSet care contine Familiile de functii</returns>
		public DataSet LoadJobFamily()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("spGetJobFamily", parameters, "GetJobFamily");
		}
		#endregion
	}
}
