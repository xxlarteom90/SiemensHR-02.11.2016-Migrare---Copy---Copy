using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for IstoricConcediuOdihnaAngajat.
	/// </summary>
	public class IstoricConcediuOdihnaAngajat : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public IstoricConcediuOdihnaAngajat(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadIstoricCO
		/// <summary>
		/// Procedura selecteaza concediile de oaihna ale unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="codAbsenta">Codul absentei</param>
		/// <returns>Returneaza un DataSet care contine concediile angajatului</returns>
		public DataSet LoadIstoricCO(long angajatId, string codAbsenta)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@CodAbsenta", SqlDbType.NVarChar, 5),
				};
			
			parameters[0].Value = angajatId;
			parameters[1].Value = codAbsenta;

			return RunProcedure("tm_GetIntervaleAbsentaTip", parameters, "GetIntervaleAbsentaTip");
		}
		#endregion
	}
}
