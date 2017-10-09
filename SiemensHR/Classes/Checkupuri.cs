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
	public class Checkupuri
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		protected Salaries.Configuration.ModuleSettings settings;

		
		public Checkupuri(long AngajatID)
		{
			//
			// TODO: Add constructor logic here
			//
			m_AngajatID = AngajatID;
			LoadCheckupuri();
		}

		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		private void LoadCheckupuri()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetCheckupuriAngajat", m_con);
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

		
		public int GetIDOfCheckup(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return Convert.ToInt32(m_ds.Tables[0].Rows[RowIndex]["CheckupID"]);
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRows().ToString());
		}
		
		public string GetNecesarInstruire(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return m_ds.Tables[0].Rows[RowIndex]["NecesarInstruire"].ToString();
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRows().ToString());
		}

		public string GetDataUrmatorului(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return Utilities.ConvertDateTime2Text(Convert.ToDateTime(m_ds.Tables[0].Rows[RowIndex]["DataUrmatorului"]));
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRows().ToString());
		}

		
		public int GetResponsabilID(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return Convert.ToInt32(m_ds.Tables[0].Rows[RowIndex]["ResponsabilID"]);
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRows().ToString());
		}
		
		public string GetDataEfectuarii(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return Utilities.ConvertDateTime2Text(Convert.ToDateTime(m_ds.Tables[0].Rows[RowIndex]["DataEfectuarii"]));
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRows().ToString());
		}

	
		public object LoadCheckupAngajat( long CheckupID)
		{	
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			m_con.Open();
			
			SqlCommand myCommand = new SqlCommand("spGetCheckup", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CheckupID", SqlDbType.BigInt, 10, CheckupID));
			
			object obj = myCommand.ExecuteScalar();
			m_con.Close();
			if (obj!=System.DBNull.Value)
				return obj;
			else
				return null;
		}




		public int InsertCheckup(string necesarInstruire,DateTime dataUrmatorului,int responsabilID,string dataEfectuarii,string checkupFile)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteCheckup", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CheckupID", SqlDbType.BigInt, 10, -1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NecesarInstruire", SqlDbType.NVarChar, 255,necesarInstruire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataUrmatorului", SqlDbType.DateTime, 8, dataUrmatorului.ToShortDateString()));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));

			if ( responsabilID != -1 )
			{
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ResponsabilID", SqlDbType.BigInt, 10, responsabilID));
			}

			if ( dataEfectuarii != "")
			{
				DateTime dataEfec = Utilities.ConvertText2DateTime(dataEfectuarii);
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEfectuarii", SqlDbType.DateTime, 8, dataEfec.ToShortDateString()));
			}
			
			if (checkupFile!=null && checkupFile.Length>0)
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CheckupFile", SqlDbType.NVarChar, 255, checkupFile));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);	
			return int.Parse(m_ds.Tables[0].Rows[0]["NewID"].ToString());
		}

		public void UpdateCheckup(int CheckupID,string new_necesarInstruire,DateTime new_dataUrmatorului,int new_responsabilID,string new_dataEfectuarii,string checkupFile)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteCheckup", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CheckupID", SqlDbType.BigInt, 10, CheckupID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NecesarInstruire", SqlDbType.NVarChar, 255,new_necesarInstruire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataUrmatorului", SqlDbType.DateTime, 8, new_dataUrmatorului.ToShortDateString()));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));

			if ( new_responsabilID != -1)
			{
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ResponsabilID", SqlDbType.BigInt, 10, new_responsabilID));
			}

			if ( new_dataEfectuarii != "")
			{
				DateTime dataEfec = Utilities.ConvertText2DateTime(new_dataEfectuarii);
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEfectuarii", SqlDbType.DateTime, 8, dataEfec.ToShortDateString()));
			}

			if (checkupFile!=null && checkupFile.Length>0)
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CheckupFile", SqlDbType.NVarChar, 255, checkupFile));	
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);	
		}

		public void DeleteCheckup(int CheckupID)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteCheckup", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CheckupID", SqlDbType.BigInt, 10, CheckupID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NecesarInstruire", SqlDbType.NVarChar, 255,""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataUrmatorului", SqlDbType.DateTime, 8, DateTime.Now));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ResponsabilID", SqlDbType.BigInt, 10, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEfectuarii", SqlDbType.DateTime, 8, DateTime.Now));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);	
		}*/



	}
}
