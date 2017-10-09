using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for SituatieMilitara.
	/// </summary>
	public class SituatieMilitara : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public SituatieMilitara(string connectionString): base (connectionString)
		{}
		#endregion

		#region GetSituatieMilitaraInfo
		/// <summary>
		/// Procedura selecteaza situatia militara a unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetSituatieMilitaraInfo(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatId;
			return RunProcedure("spGetSituatieMilitara", parameters, "GetSituatieMilitara");
		}
		#endregion

		#region InsertUpdateSituatieMilitara
		/// <summary>
		/// Procedura adauga situatia militara a unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="serie">Seria </param>
		/// <param name="numar">Numar</param>
		/// <param name="evidentaCMJ">In evidenta CMJ</param>
		/// <param name="data">Data intrarii in evidenta</param>
		/// <param name="gradul">Gradul</param>
		/// <param name="specialitati">Specialitati militare</param>
		public void InsertUpdateSituatieMilitara(long angajatId, string serie, string numar, string evidentaCMJ, DateTime data, string gradul, string specialitati)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@SerieLivret", SqlDbType.NVarChar, 5),
					new SqlParameter("@NumarLivret", SqlDbType.NVarChar, 10),
					new SqlParameter("@EvidentaCMJ", SqlDbType.NVarChar, 100),
					new SqlParameter("@DataIntrareEvidenta", SqlDbType.DateTime, 8),
					new SqlParameter("@Gradul", SqlDbType.NVarChar, 50),
					new SqlParameter("@SpecialitatiMilitare", SqlDbType.NVarChar, 100),
				};
			
			parameters[0].Value = angajatId;
			parameters[1].Value = serie;
			parameters[2].Value = numar;
			parameters[3].Value = evidentaCMJ;
			parameters[4].Value = data;
			parameters[5].Value = gradul;
			parameters[6].Value = specialitati;
			
			RunProcedure("InsertUpdateSituatieMilitara", parameters);
		}
		#endregion
	}
}
