using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for IstoricNIF.
	/// </summary>
	public class IstoricNIF : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public IstoricNIF(string connectionString): base (connectionString)
		{}
		#endregion
	
		#region LoadIstoricNIFuri
		/// <summary>
		/// Procedura selecteaza toate NIF-urile unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine toate NIF-urile unui angajat</returns>
		public DataSet LoadIstoricNIFuri(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatId;
			return RunProcedure("GetNIFuriAngajat", parameters, "GetNIFuriAngajat");
		}
		#endregion

		#region InsertNIF
		/// <summary>
		/// Procedura adauga un NIF
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="nrNIF">Numarul de inregistrare fiscal</param>
		/// <param name="activ">Specifica daca NIF este activ sau nu</param>
		/// <returns>Returneaza true daca a fost facuta adauagarea corecta si false altfel</returns>
		public bool InsertNIF(long angajatId, string nrNIF, bool activ)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@NIFID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NIF", SqlDbType.NVarChar, 50),
					new SqlParameter("@Activ", SqlDbType.Bit, 1),
					new SqlParameter("@rc", SqlDbType.Int)
				};
			
			parameters[0].Value = 0;
			parameters[1].Value = -1;
			parameters[2].Value = angajatId;
			parameters[3].Value = nrNIF;
			parameters[4].Value = activ;
			parameters[5].Direction = ParameterDirection.ReturnValue;
			
			RunProcedure("InsertUpdateDeleteNIF", parameters);

			if	(int.Parse(parameters[5].Value.ToString()) == -1)
				return false;
			return true;
		}
		#endregion

		#region UpdateNIF
		/// <summary>
		/// Procedura actualizeaza un NIF
		/// </summary>
		/// <param name="nifId">Id-ul NIF-ului</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="nrNIF">Numarul de inregistrare fiscal</param>
		/// <param name="activ">Specifica daca NIF este activ sau nu</param>
		/// <returns>Returneaza true daca a fost facuta adauagarea corecta si false altfel</returns>
		public bool UpdateNIF(int nifId, long angajatId, string nrNIF, bool activ)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@NIFID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NIF", SqlDbType.NVarChar, 50),
					new SqlParameter("@Activ", SqlDbType.Bit, 1),
					new SqlParameter("@rc", SqlDbType.Int)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = nifId;
			parameters[2].Value = angajatId;
			parameters[3].Value = nrNIF;
			parameters[4].Value = activ;
			parameters[5].Direction = ParameterDirection.ReturnValue;
			
			RunProcedure("InsertUpdateDeleteNIF", parameters);

			if	(int.Parse(parameters[5].Value.ToString()) == -1)
				return false;
			return true;
		}
		#endregion

		#region DeleteNIF
		/// <summary>
		/// Procedura sterge un NIF
		/// </summary>
		/// <param name="nifId">Id-ul NIF-ului care se sterge</param>
		public void DeleteNIF(int nifId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@NIFID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NIF", SqlDbType.NVarChar, 50),
					new SqlParameter("@Activ", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = nifId;
			parameters[2].Value = -1;
			parameters[3].Value = 0;
			parameters[4].Value = 0;
			
			RunProcedure("InsertUpdateDeleteNIF", parameters);
		}
		#endregion
	}
}
