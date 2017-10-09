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
	public class EvaluariPsihologice
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		protected Salaries.Configuration.ModuleSettings settings;
		
		public EvaluariPsihologice(long AngajatID)
		{
			//
			// TODO: Add constructor logic here
			//
			m_AngajatID = AngajatID;
			LoadEvaluariPsihologice();
		}

		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		private void LoadEvaluariPsihologice()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetEvaluariPsihologiceAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		public int GetNumberOfRows()
		{
			return m_ds.Tables[0].Rows.Count;
		}

		
		public int GetIDOfEvalPsihologica(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return Convert.ToInt32(m_ds.Tables[0].Rows[RowIndex]["EvalPsihologicaID"]);
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRows().ToString());
		}
		
	

		public string GetData(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return Utilities.ConvertDateTime2Text(Convert.ToDateTime(m_ds.Tables[0].Rows[RowIndex]["Data"]));
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRows().ToString());
		}

		public object LoadEvalPsihologicaAngajat( long EvalPsihologicaID)
		{	
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			m_con.Open();		
			SqlCommand myCommand = new SqlCommand("spGetEvaluarePsihologica", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@EvalPsihologicaID", SqlDbType.BigInt, 10, EvalPsihologicaID));

			object obj = myCommand.ExecuteScalar();
			m_con.Close();
			if (obj!=System.DBNull.Value)
				return obj;
			else
				return null;
		}

		public int InsertEvalPsihologica(int tipRaportID,DateTime data,string evalPsihologicaFile)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteEvaluarePsihologica", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@EvalPsihologicaID", SqlDbType.BigInt, 10, -1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, data.ToShortDateString()));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipRaportID", SqlDbType.Int, 4, tipRaportID));
			
			if (evalPsihologicaFile!=null && evalPsihologicaFile.Length>0)
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Raport", SqlDbType.NVarChar, 255, evalPsihologicaFile));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);	
			return int.Parse(m_ds.Tables[0].Rows[0]["NewID"].ToString());
		}

		public void UpdateEvalPsihologica(int EvalPsihologicaID,int new_tipRaportID,DateTime new_data,string evalPsihologicaFile)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteEvaluarePsihologica", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@EvalPsihologicaID", SqlDbType.BigInt, 10, EvalPsihologicaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, new_data.ToShortDateString()));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipRaportID", SqlDbType.Int, 4, new_tipRaportID));
			if (evalPsihologicaFile!=null && evalPsihologicaFile.Length>0)
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Raport", SqlDbType.NVarChar, 255, evalPsihologicaFile));	
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);	
		}

		public void DeleteEvalPsihologica(int EvalPsihologicaID)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteEvaluarePsihologica", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@EvalPsihologicaID", SqlDbType.BigInt, 10, EvalPsihologicaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, DateTime.Now));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipRaportID", SqlDbType.Int, 4, 0));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);	
		}*/



	}
}
