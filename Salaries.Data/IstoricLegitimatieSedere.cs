using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for IstoricLegitimatieSedere.
	/// </summary>
	public class IstoricLegitimatieSedere : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public IstoricLegitimatieSedere(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadIstoricLegitimatiiSedere
		/// <summary>
		/// Procedura selecteaza legitimatiile de sedere ale unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine legitimatiile de sedere</returns>
		public DataSet LoadIstoricLegitimatiiSedere(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatId;
			return RunProcedure("GetLegitimatiiSedereAngajat", parameters, "GetLegitimatiiSedereAngajat");
		}
		#endregion

		#region InsertLegitimatieSedere
		/// <summary>
		/// Procedura adauga o legitimatie de sedere pentru angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="serieLegitimatieSedere">Seria legitimatie sedere</param>
		/// <param name="nrLegitimatieSedere">Nr legitimatie sedere</param>
		/// <param name="legitimatieSedereDataEliberare">Data eliberare legitimatie sedere</param>
		/// <param name="legitimatieSedereDataExpirare">Data expirare legitimatie sedere</param>
		/// <param name="activ">Specifica daca legitimatia este activa sau nu</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool InsertLegitimatieSedere(long angajatId, string serieLegitimatieSedere, string nrLegitimatieSedere, DateTime legitimatieSedereDataEliberare, DateTime legitimatieSedereDataExpirare, bool activ )
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@LegitimatieSedereID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NrLegitimatieSedere", SqlDbType.NVarChar, 50),
					new SqlParameter("@SerieLegitimatieSedere", SqlDbType.NVarChar, 10),
					new SqlParameter("@LegitimatieSedereDataEliberare", SqlDbType.DateTime),
					new SqlParameter("@LegitimatieSedereDataExpirare", SqlDbType.DateTime, 8),
					new SqlParameter("@Activ", SqlDbType.Bit, 1),
					new SqlParameter("@rc", SqlDbType.Int)
				};
			
			parameters[0].Value = 0;
			parameters[1].Value = -1;
			parameters[2].Value = angajatId;
			parameters[3].Value = nrLegitimatieSedere;
			parameters[4].Value = serieLegitimatieSedere;
			parameters[5].Value = legitimatieSedereDataEliberare;
			parameters[6].Value = legitimatieSedereDataExpirare;
			parameters[7].Value = activ;
			parameters[8].Direction = ParameterDirection.ReturnValue;
			
			RunProcedure("InsertUpdateDeleteLegitimatieSedere", parameters);

			// daca nu s-a facut inserarea, se returneaza false
			if	(int.Parse(parameters[8].Value.ToString()) == -1)
				return false;
			return true;
		}
		#endregion

		#region UpdateLegitimatieSedere
		/// <summary>
		/// Procedura actualizeaza o legitimatie de sedere
		/// </summary>
		/// <param name="legitimatieSedereId">Id-ul legitimatiei de sedere</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="serieLegitimatieSedere">Seria legitimatie sedere</param>
		/// <param name="nrLegitimatieSedere">Nr legitimatie sedere</param>
		/// <param name="legitimatieSedereDataEliberare">Data eliberare legitimatie sedere</param>
		/// <param name="legitimatieSedereDataExpirare">Data expirare legitimatie sedere</param>
		/// <param name="activ">Specifica daca legitimatia este activa sau nu</param>
		/// <returns>Returneaza true daca s-a facut modificarea si false altfel</returns>
		public bool UpdateLegitimatieSedere(int legitimatieSedereId, long angajatId, string serieLegitimatieSedere, string nrLegitimatieSedere, DateTime legitimatieSedereDataEliberare, DateTime legitimatieSedereDataExpirare, bool activ )
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@LegitimatieSedereID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@SerieLegitimatieSedere", SqlDbType.NVarChar, 10),
					new SqlParameter("@NrLegitimatieSedere", SqlDbType.NVarChar, 50),
					new SqlParameter("@LegitimatieSedereDataEliberare", SqlDbType.DateTime),
					new SqlParameter("@LegitimatieSedereDataExpirare", SqlDbType.DateTime, 8),
					new SqlParameter("@Activ", SqlDbType.Bit, 1),
					new SqlParameter("@rc", SqlDbType.Int)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = legitimatieSedereId;
			parameters[2].Value = angajatId;
			parameters[3].Value = serieLegitimatieSedere;
			parameters[4].Value = nrLegitimatieSedere;
			parameters[5].Value = legitimatieSedereDataEliberare;
			parameters[6].Value = legitimatieSedereDataExpirare;
			parameters[7].Value = activ;
			parameters[8].Direction = ParameterDirection.ReturnValue;
			
			RunProcedure("InsertUpdateDeleteLegitimatieSedere", parameters);

			// daca nu s-a facut inserarea, se returneaza false
			if	(int.Parse(parameters[8].Value.ToString()) == -1)
				return false;
			return true;
		}
		#endregion

		#region DeleteLegitimatieSedere
		/// <summary>
		/// Procedura sterge o legitimatie de sedere
		/// </summary>
		/// <param name="legitimatieSedereId">Id-ul legitimatiei de sedere</param>
		public void DeleteLegitimatieSedere(int legitimatieSedereId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@LegitimatieSedereID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NrLegitimatieSedere", SqlDbType.NVarChar, 50),
					new SqlParameter("@SerieLegitimatieSedere", SqlDbType.NVarChar, 10),
					new SqlParameter("@LegitimatieSedereDataEliberare", SqlDbType.DateTime, 8),
					new SqlParameter("@LegitimatieSedereDataExpirare", SqlDbType.DateTime, 8),
					new SqlParameter("@Activ", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = legitimatieSedereId;
			parameters[2].Value = 0;
			parameters[3].Value = "";
			parameters[4].Value = "";
			parameters[5].Value = System.DBNull.Value;
			parameters[6].Value = System.DBNull.Value;
			parameters[7].Value = false;
			
			RunProcedure("InsertUpdateDeleteLegitimatieSedere", parameters);
		}
		#endregion
	}
}
