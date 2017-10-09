using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SiemensHR.utils;


namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for IstoricCategorie.
	/// </summary>
	public class IstoricCategorie
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		protected Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		public IstoricCategorie(long AngajatID)
		{
			m_AngajatID = AngajatID;
			LoadIstoricCategorii();
		}

		public int GetNumberOfCategorii()
		{
			return m_ds.Tables[0].Rows.Count;
		}

		private void LoadIstoricCategorii()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetIstoricCategoriiAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		static public void InsertCategorie(long AngajatID, int CategorieID, DateTime dataStart)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricCategorie", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, CategorieID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}

		static public void UpdateCategorie(long AngajatID, int CategorieID, DateTime dataStart, DateTime old_dataStart)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricCategorie", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, CategorieID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@old_DataStart", SqlDbType.DateTime, 8, old_dataStart));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}

		static public void DeleteCategorie(long AngajatID, int CategorieID, DateTime dataStart, DateTime old_dataStart)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricCategorie", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, CategorieID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@old_DataStart", SqlDbType.DateTime, 8, old_dataStart));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}*/
	}
}
