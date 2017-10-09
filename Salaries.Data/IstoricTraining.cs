using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for IstoricTraining.
	/// </summary>
	public class IstoricTraining : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public IstoricTraining(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadIstoricTraining
		/// <summary>
		/// Procedura selecteaza cursurile unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="tip">Tipul de curs: intern sau extern</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadIstoricTraining(long angajatId, bool tip)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@Tip", SqlDbType.Bit, 1)
				};
			parameters[0].Value = angajatId;
			parameters[1].Value = tip;
			return RunProcedure("GetIstoricTrainingAngajat", parameters, "GetIstoricTrainingAngajat");
		}
		#endregion

		#region InsertIstoricTraining
		/// <summary>
		/// Procedura adauga un curs pentru un angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="trainingId">Id-ul cursului</param>
		/// <param name="dataStart">Data start</param>
		/// <param name="dataEnd">Data sfarsit</param>
		public void InsertIstoricTraining(long angajatId, int trainingId, DateTime dataStart, DateTime dataEnd)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@IstoricTrainingID", SqlDbType.BigInt, 10),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@TrainingID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8)
				};
			
			parameters[0].Value = 0;
			parameters[1].Value = -1;
			parameters[2].Value = angajatId;
			parameters[3].Value = trainingId;
			parameters[4].Value = dataStart;
			parameters[5].Value = dataEnd;
			
			RunProcedure("InsertUpdateDeleteIstoricTraining", parameters);
		}
		#endregion

		#region UpdateIstoricTraining
		/// <summary>
		/// Procedura actualizeaza un curs pentru angajat
		/// </summary>
		/// <param name="istoricTrainingId">Id-ul istoricului de curs</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="trainingId">Id-ul cursului</param>
		/// <param name="dataStart">Data start</param>
		/// <param name="dataEnd">Data sfarsit</param>
		public void UpdateIstoricTraining(int istoricTrainingId, long angajatId, int trainingId, DateTime dataStart, DateTime dataEnd)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@IstoricTrainingID", SqlDbType.BigInt, 10),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@TrainingID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = istoricTrainingId;
			parameters[2].Value = angajatId;
			parameters[3].Value = trainingId;
			parameters[4].Value = dataStart;
			parameters[5].Value = dataEnd;
			
			RunProcedure("InsertUpdateDeleteIstoricTraining", parameters);
		}
		#endregion

		#region DeleteIstoricTraining
		/// <summary>
		/// Procedura sterge un curs al unui angajat
		/// </summary>
		/// <param name="istoricTrainingId">Id-ul cursului</param>
		public void DeleteIstoricTraining(int istoricTrainingId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@IstoricTrainingID", SqlDbType.BigInt, 10),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@TrainingID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = istoricTrainingId;
			parameters[2].Value = 0;
			parameters[3].Value = 0;
			parameters[4].Value = DateTime.Now;
			parameters[5].Value = DateTime.Now;
			
			RunProcedure("InsertUpdateDeleteIstoricTraining", parameters);
		}
		#endregion
	}
}
