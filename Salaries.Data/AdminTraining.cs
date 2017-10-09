using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminTraining.
	/// </summary>
	public class AdminTraining : Salaries.Data.DbObject
	{
		#region AdminTraining
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminTraining(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoTraininguri
		/// <summary>
		/// Procedura selecteaza cursurile de un anumit tip: intern sau extern
		/// </summary>
		/// <param name="intern">Tipul cursurilor</param>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoTraininguri(bool intern)
		{
			string aux  = intern ? "1": "0"; 
			SqlParameter[] parameters = 
							{
								new SqlParameter("@TipTraining", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = aux;	
			return RunProcedure("spGetAllTraininguri", parameters, "GetAllTraininguri");
		}
		#endregion

		#region InsertTraining
		/// <summary>
		/// Procedura adauga un curs
		/// </summary>
		/// <param name="nume">Denumirea cursului</param>
		/// <param name="descriere">Descrierea cursului</param>
		/// <param name="diploma">Tipul de diploma asociat cursului</param>
		/// <param name="intern">Specifica daca este un curs intern sau extern</param>
		public void InsertTraining(string nume, string descriere, string diploma, bool intern)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TrainingID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255),
								new SqlParameter("@Diploma", SqlDbType.NVarChar, 255),
								new SqlParameter("@Intern", SqlDbType.Bit, 1)
							};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = nume;
			parameters[3].Value = descriere;
			parameters[4].Value = diploma;
			parameters[5].Value = intern;

			RunProcedure("InsertUpdateDeleteTraining", parameters);
		}
		#endregion

		#region UpdateTraining
		/// <summary>
		/// Procedura adauga un curs
		/// </summary>
		/// <param name="trainingId">Id-ul cursrului care se actualizeaza</param>
		/// <param name="nume">Denumirea cursului</param>
		/// <param name="descriere">Descrierea cursului</param>
		/// <param name="diploma">Tipul de diploma asociat cursului</param>
		/// <param name="intern">Specifica daca este un curs intern sau extern</param>
		public void UpdateTraining(int trainingId, string nume, string descriere, string diploma, bool intern)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TrainingID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255),
								new SqlParameter("@Diploma", SqlDbType.NVarChar, 255),
								new SqlParameter("@Intern", SqlDbType.Bit, 1)
							};
			
			parameters[0].Value = 1;
			parameters[1].Value = trainingId;
			parameters[2].Value = nume;
			parameters[3].Value = descriere;
			parameters[4].Value = diploma;
			parameters[5].Value = intern;

			RunProcedure("InsertUpdateDeleteTraining", parameters);
		}
		#endregion

		#region DeleteTraining
		/// <summary>
		/// Procedura sterg un curs
		/// </summary>
		/// <param name="trainingId">Id-ul cursului care se sterge</param>
		public void DeleteTraining(int trainingId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TrainingID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255),
								new SqlParameter("@Diploma", SqlDbType.NVarChar, 255),
								new SqlParameter("@Intern", SqlDbType.Bit, 1)
							};
			
			parameters[0].Value = 2;
			parameters[1].Value = trainingId;
			parameters[2].Value = "";
			parameters[3].Value = "";
			parameters[4].Value = "";
			parameters[5].Value = false;

			RunProcedure("InsertUpdateDeleteTraining", parameters);
		}
		#endregion

		#region GetTrainingInfo
		/// <summary>
		/// Procedura selecteaza un curs
		/// </summary>
		/// <param name="trainingId">Id-ul cursului selectat</param>
		/// <returns>Returneaza un DataSet care contine datele despre curs</returns>
		public DataSet GetTrainingInfo(int trainingId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@TrainingID", SqlDbType.Int, 4)
							};
			parameters[0].Value = trainingId;
			return RunProcedure("spGetTraining", parameters, "GetTraining");
		}
		#endregion

		#region CheckIfTrainingCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un curs poate fi sters
		/// </summary>
		/// <param name="TrainingID">Id-ul cursului pentru care se face verificarea</param>
		/// <returns>Returneaza rezultatul verificarii
		/// 0 - se poate sterge
		/// 1 - exista date asociate cursului
		/// 2 - este ultimul curs din lista
		/// </returns>
		public int CheckIfTrainingCanBeDeleted(int trainingId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@TrainingID", SqlDbType.Int, 4),
								new SqlParameter("@SePoateSterge", SqlDbType.Int, 4)
							};
			parameters[0].Value = trainingId;
			parameters[1].Direction = ParameterDirection.Output;
			
			RunProcedure("spCheckIfTrainingCanBeDeleted", parameters);
			return int.Parse(parameters[1].Value.ToString());
		}
		#endregion

		#region CheckIfTrainingCanBeAdded
		/// <summary>
		/// Procedura verifica daca mai exista un training cu aceleasi date
		/// </summary>
		/// <param name="trainingId">Id-ul trainingului care nu trebuie sa concida</param>
		/// <param name="nume">Numele trainingului</param>
		/// <param name="diploma">Specifica ce fel de diploma se acorda pentru training</param>
		/// <param name="intern">Specifica daca este training intern sau extern</param>
		/// <returns>Returneaza true daca se poate face adugarea sau modificare si false altfel</returns>
		public bool CheckIfTrainingCanBeAdded(int trainingId, string nume, string diploma, bool intern)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@TrainingID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Diploma", SqlDbType.NVarChar, 255),
								new SqlParameter("@Intern", SqlDbType.Bit, 1),
								new SqlParameter("@NrTraininguri", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = trainingId;
			parameters[1].Value = nume;
			parameters[2].Value = diploma;
			parameters[3].Value = intern;
			parameters[4].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfTrainingCanBeAdded", parameters);
			return byte.Parse(parameters[4].Value.ToString()) == 0;
		}
		#endregion
	}
}
