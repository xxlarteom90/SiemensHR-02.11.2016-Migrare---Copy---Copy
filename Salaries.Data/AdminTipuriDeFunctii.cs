/*
 * Autor:		Oprescu Claudia
 * Data:		10.07.2007
 * Descriere:	Clasa se ocupa cu Tipurile de functii.
 */	

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminTipuriDeFunctii.
	/// </summary>
	public class AdminTipuriDeFunctii : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public AdminTipuriDeFunctii(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadTipuriDeFunctii
		/// <summary>
		/// Procedura selecteaza tipurile de functii existente
		/// </summary>
		/// <returns>Returneaza un DataSet care contine tipurile de functii</returns>
		public DataSet LoadTipuriDeFunctii()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("spGetTipuriDeFunctii", parameters, "GetTipuriDeFunctii");
		}
		#endregion
	}
}
