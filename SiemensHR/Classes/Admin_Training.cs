using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SiemensHR.utils;


namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for AdminTraininguri.
	/// </summary>
	/// 
	public struct Training
	{
		/*public string Nume;
		public string Descriere;
		public string Diploma;
		public bool Intern;*/
	}

	public class AdminTraininguri
	{
		/*private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;


		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		public AdminTraininguri(bool Intern)
		{
			LoadInfoTraininguri(Intern);
		}

		private void LoadInfoTraininguri(bool Intern)
		{
			string aux  = Intern ? "1": "0"; 

			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("spGetAllTraininguri", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipTraining", SqlDbType.Int, 4, aux));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		static public void InsertTraining(Training newTraining)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTraining", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TrainingID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, newTraining.Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, newTraining.Descriere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Diploma", SqlDbType.NVarChar, 255, newTraining.Diploma));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Intern", SqlDbType.Bit, 255, newTraining.Intern));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void UpdateTraining(Training TrainingData, int TrainingID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTraining", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TrainingID", SqlDbType.Int, 4, TrainingID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, TrainingData.Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, TrainingData.Descriere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Diploma", SqlDbType.NVarChar, 255, TrainingData.Diploma));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Intern", SqlDbType.Bit, 255, TrainingData.Intern));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void DeleteTraining(int TrainingID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTraining", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TrainingID", SqlDbType.Int, 4, TrainingID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Diploma", SqlDbType.NVarChar, 255, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Intern", SqlDbType.Bit, 255, 0));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public Training GetTrainingInfo( int TrainingID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetTraining", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TrainingID", SqlDbType.Int, 4, TrainingID));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for TrainingID=" +  TrainingID.ToString());
			else
			{
				Training infoTraining;
				infoTraining.Nume = ds.Tables[0].Rows[0]["Nume"].ToString();
				infoTraining.Descriere = ds.Tables[0].Rows[0]["Descriere"].ToString();
				infoTraining.Diploma = ds.Tables[0].Rows[0]["Diploma"].ToString();
				infoTraining.Intern = bool.Parse(ds.Tables[0].Rows[0]["Intern"].ToString());
				return infoTraining;
			}
		}

		/// <summary>
		/// Procedura verifica daca un curs poate fi sters
		/// </summary>
		/// <param name="TrainingID">Id-ul cursului pentru care se face verificarea</param>
		/// <returns>Returneaza rezultatul verificarii
		/// 0 - se poate sterge
		/// 1 - exista date asociate cursului
		/// 2 - este ultimul curs din lista
		/// </returns>
		static public int CheckIfTrainingCanBeDeleted( int TrainingID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfTrainingCanBeDeleted", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TrainingID", SqlDbType.Int, 4, TrainingID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@SePoateSterge", SqlDbType.Int, 4));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return int.Parse(myCommand.Parameters[1].Value.ToString());
		}

		/// <summary>
		/// Procedura verifica daca mai exista un training cu aceleasi date
		/// </summary>
		/// <param name="trainingID">Id-ul trainingului care nu trebuie sa concida</param>
		/// <param name="nume">Numele trainingului</param>
		/// <param name="diploma">Specifica ce fel de diploma se acorda pentru training</param>
		/// <param name="intern">Specifica daca este training intern sau extern</param>
		/// <returns>Returneaza true daca se poate face adugarea sau modificare si false altfel</returns>
		static public bool CheckIfTrainingCanBeAdded(int trainingID, string nume, string diploma, bool intern)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfTrainingCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 255, nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Diploma", SqlDbType.NVarChar, 255, diploma));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Intern", SqlDbType.Bit, 1, intern));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TrainingID", SqlDbType.Int, 4, trainingID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrTraininguri", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[4].Value.ToString()) == 0;
		}*/
	}
}
