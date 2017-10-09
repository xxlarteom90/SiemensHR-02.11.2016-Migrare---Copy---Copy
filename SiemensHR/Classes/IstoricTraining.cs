using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for IstoricDepartament.
	/// </summary>
	public class IstoricTraining
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		private int tipTraining;
		private Salaries.Configuration.ModuleSettings settings;

		public IstoricTraining(long AngajatID,int tip)
		{
			//
			// TODO: Add constructor logic here
			//
			m_AngajatID = AngajatID;
			tipTraining=tip;
			LoadIstoricTraining();
		}

		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		private void LoadIstoricTraining()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetIstoricTrainingAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Tip", SqlDbType.Bit, 1, tipTraining));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		public int GetNumberOfRows()
		{
			return m_ds.Tables[0].Rows.Count;
		}

		
		public int GetIDOfIstoricTraining(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return Convert.ToInt32(m_ds.Tables[0].Rows[RowIndex]["IstoricTrainingID"]);
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRows().ToString());
		}
		
		public string GetNameOfTraining(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return m_ds.Tables[0].Rows[RowIndex]["Nume"].ToString();
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRows().ToString());
		}

		public int GetIDOfTraining(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return Convert.ToInt32(m_ds.Tables[0].Rows[RowIndex]["TrainingID"]);
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRows().ToString());
		}

		public string GetDataStartOfIstoricTraining(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return Utilities.ConvertDateTime2Text(Convert.ToDateTime(m_ds.Tables[0].Rows[RowIndex]["DataStart"]));
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRows().ToString());
		}
		public string GetDataEndOfIstoricTraining(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return Utilities.ConvertDateTime2Text(Convert.ToDateTime(m_ds.Tables[0].Rows[RowIndex]["DataEnd"]));
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRows().ToString());
		}


		public void InsertIstoricTraining(int TrainingID, DateTime dataStart,DateTime dataEnd)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricTraining", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IstoricTrainingID", SqlDbType.BigInt, 10, -1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TrainingID", SqlDbType.Int, 4, TrainingID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart.ToShortDateString()));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, dataEnd.ToShortDateString()));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);	

		}

		public void UpdateIstoricTraining(int IstoricTrainingID,int new_TrainingID,DateTime new_dataStart,DateTime new_dataEnd)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricTraining", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IstoricTrainingID", SqlDbType.BigInt, 10, IstoricTrainingID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TrainingID", SqlDbType.Int, 4, new_TrainingID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, new_dataStart.ToShortDateString()));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, new_dataEnd.ToShortDateString()));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);	
		}

		public void DeleteIstoricTraining(int IstoricTrainingID)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricTraining", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IstoricTrainingID", SqlDbType.BigInt, 10, IstoricTrainingID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TrainingID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, DateTime.Now));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, DateTime.Now));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);	
		}*/



	}
}
