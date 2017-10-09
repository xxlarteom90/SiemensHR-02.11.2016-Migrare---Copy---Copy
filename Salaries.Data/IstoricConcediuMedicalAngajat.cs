using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for IstoricConcediuMedicalAngajat.
	/// </summary>
	public class IstoricConcediuMedicalAngajat : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public IstoricConcediuMedicalAngajat(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadIstoricCM
		/// <summary>
		/// Procedura selecteaza concediile medicale ale unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="codAbsenta">Tipul absentei</param>
		/// <param name="codAbsentaContinuare">Tipul continuarii de absenta</param>
		/// <returns>Returneaza un DataSet care contine date despre concediu</returns>
		public DataSet LoadIstoricCM(long angajatId, string codAbsenta, string codAbsentaContinuare)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@CodAbsenta", SqlDbType.NVarChar, 5),
					new SqlParameter("@CodAbsentaContinuare", SqlDbType.NVarChar, 5)
				};
			
			parameters[0].Value = angajatId;
			parameters[1].Value = codAbsenta;
			parameters[2].Value = codAbsentaContinuare;

			return RunProcedure("tm_GetIntervaleAbsentaCM", parameters, "GetIntervaleAbsentaCM");
		}
		#endregion
	}
}
