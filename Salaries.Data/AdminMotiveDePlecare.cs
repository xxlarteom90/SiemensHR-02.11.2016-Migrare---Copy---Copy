/*
 * Autor:		Oprescu Claudia
 * Data:		10.07.2007
 * Descriere:	Clasa se ocupa cu Motivele de plecare.
 */	

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminMotiveDePlecare.
	/// </summary>
	public class AdminMotiveDePlecare : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public AdminMotiveDePlecare(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadMotiveDePlecare
		/// <summary>
		/// Procedura selecteaza motivele de plecare
		/// </summary>
		/// <returns>Returneaza un DataSet care contine motivele de plecare</returns>
		public DataSet LoadMotiveDePlecare()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("spGetMotiveDePlecare", parameters, "GetMotiveDePlecare");
		}
		#endregion
	}
}
