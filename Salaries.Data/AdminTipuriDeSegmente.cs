/*
 * Autor:		Oprescu Claudia
 * Data:		10.07.2007
 * Descriere:	Clasa se ocupa cu Tipurile de segmente de management.
 */	

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminTipuriDeSegmente.
	/// </summary>
	public class AdminTipuriDeSegmente : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public AdminTipuriDeSegmente(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadTipuriDeSegmente
		/// <summary>
		/// Procedura selecteaza tipurile de segmente de management existente
		/// </summary>
		/// <returns>Returneaza un DataSet care contine segmente de management de functii</returns>
		public DataSet LoadTipuriDeSegmente()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("spGetTipuriDeSegmente", parameters, "GetTipuriDeSegmente");
		}
		#endregion
	}
}
