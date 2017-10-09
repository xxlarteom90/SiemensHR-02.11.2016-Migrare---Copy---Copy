using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for IstoricFunctie.
	/// </summary>
	public class IstoricFunctie : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public IstoricFunctie(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadIstoricFunctii
		/// <summary>
		/// Procedura selecteaza functiile unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadIstoricFunctii(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatId;
			return RunProcedure("GetIstoricFunctiiAngajat", parameters, "GetIstoricFunctiiAngajat");
		}
		#endregion

		#region LoadIstoricFunctiiLunaActiva
		/// <summary>
		/// Procedura selecteaza functiile unui angajat din luna activa 
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		// Lungu Andreea 22.07.2008
		public DataSet LoadIstoricFunctiiLunaActiva(long angajatId, DateTime data)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@Data", SqlDbType.DateTime)
				};
			parameters[0].Value = angajatId;
			parameters[1].Value = data;
			return RunProcedure("GetIstoricFunctiiLunaActiva", parameters, "GetIstoricFunctiiLunaActiva");
		}
		#endregion

		#region GetFunctieCurenta
		/// <summary>
		/// Procedura selecteaza functia curenta a unui angajat 
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		// Lungu Andreea 22.07.2008
		public DataSet GetFunctieCurenta(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatId;
			return RunProcedure("GetFunctieCurenta", parameters, "GetFunctieCurenta");
		}
		#endregion

		#region InsertFunctie
		/// <summary>
		/// Procedura adauga o functie pentur angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="functieId">Id-ul functiei</param>
		/// <param name="dataStart">Data de incepere a activitatii in functie</param>
		public void InsertFunctie(long angajatId, int functieId, DateTime dataStart)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@FunctieID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8)
				};
			
			parameters[0].Value = 0;
			parameters[1].Value = angajatId;
			parameters[2].Value = functieId;
			parameters[3].Value = dataStart;
			
			RunProcedure("InsertUpdateDeleteIstoricFunctie", parameters);
		}
		#endregion

		#region UpdateFunctie
		/// <summary>
		/// Procedura actualizeaza o functie
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="functieId">Id-ul functiei</param>
		/// <param name="new_dataStart">Noua data pentru functie</param>
		/// <param name="old_dataStart">Vechea data pentru functie</param>
		public void UpdateFunctie(long angajatId, int functieId, DateTime new_dataStart, DateTime old_dataStart)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@FunctieID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@old_DataStart", SqlDbType.DateTime, 8)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = angajatId;
			parameters[2].Value = functieId;
			parameters[3].Value = new_dataStart;
			parameters[4].Value = old_dataStart;
			
			RunProcedure("InsertUpdateDeleteIstoricFunctie", parameters);
		}
		#endregion

		#region DeleteFunctie
		/// <summary>
		/// Procedura sterge o functie
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="functieId">Id-ul functiei</param>
		/// <param name="new_dataStart">Noua data pentru functie</param>
		/// <param name="old_dataStart">Vechea data pentru functie</param>
		public void DeleteFunctie(long angajatId, int functieId, DateTime new_dataStart, DateTime old_dataStart)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@FunctieID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@old_DataStart", SqlDbType.DateTime, 8)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = angajatId;
			parameters[2].Value = functieId;
			parameters[3].Value = new_dataStart;
			parameters[4].Value = old_dataStart;
			
			RunProcedure("InsertUpdateDeleteIstoricFunctie", parameters);
		}
		#endregion

		#region CheckIfIstoricFunctiiCanBeAdded
		/// <summary>
		/// Procedura verifica dca amia exista o inregistrare cu aceleasi date
		/// </summary>
		/// <param name="angajatId">id-ul angajatului pentru care sa adauga functia</param>
		/// <param name="dataStart">data pentru care sa adauga functia</param>
		/// <returns>Procedura returneaza true sau false in functia daca se pot face adaugari sau nu </returns>
		public bool CheckIfIstoricFunctiiCanBeAdded(long angajatId, DateTime dataStart)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@NrIstoricFunctii", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = angajatId;
			parameters[1].Value = dataStart;
			parameters[2].Direction = ParameterDirection.Output;
			
			RunProcedure("spCheckIfIstoricFunctiiCanBeAdded", parameters);
			return byte.Parse(parameters[2].Value.ToString()) == 0;
		}
		#endregion
	}
}
