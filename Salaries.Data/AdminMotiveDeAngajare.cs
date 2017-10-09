/*
 * Autor:		Oprescu Claudia
 * Data:		09.07.2007
 * Descriere:	Clasa se ocupa cu Motivele de angajare.
 */	

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminMotiveDeAngajare.
	/// </summary>
	public class AdminMotiveDeAngajare : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public AdminMotiveDeAngajare(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadMotiveDeAngajare
		/// <summary>
		/// Procedura selecteaza motivele de angajare
		/// </summary>
		/// <returns>Returneaza un DataSet care contine motivele de angajare</returns>
		public DataSet LoadMotiveDeAngajare()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("spGetMotiveDeAngajare", parameters, "GetMotiveDeAngajare");
		}
		#endregion
	}
}
