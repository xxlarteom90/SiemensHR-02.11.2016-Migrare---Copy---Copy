/*
 * Autor:		Oprescu Claudia
 * Data:		09.07.2007
 * Descriere:	Clasa se ocupa cu Tipurile de angajati.
 */	

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminTipuriDeAngajati.
	/// </summary>
	public class AdminTipuriDeAngajati : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public AdminTipuriDeAngajati(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadTipuriDeAngajati
		/// <summary>
		/// Procedura selecteaza tipurile de angajati existente
		/// </summary>
		/// <returns>Returneaza un DataSet care contine tipurile de angajati</returns>
		public DataSet LoadTipuriDeAngajati()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("spGetTipuriDeAngajati", parameters, "GetTipuriDeAngajati");
		}
		#endregion
	}
}
