using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for IstoricCentruCost.
	/// </summary>
	public class IstoricCentruCost
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		protected Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		public IstoricCentruCost(long AngajatID )
		{
			m_AngajatID = AngajatID;
			LoadIstoricCentreCost();
		}

		public int GetNumberOfCentreCost()
		{
			return m_ds.Tables[0].Rows.Count;
		}


		private void LoadIstoricCentreCost()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetIstoricCentreCostAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		
		static public void InsertCentruCost(long AngajatID, int CentruCostID, DateTime dataStart)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricCentruCost", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CentruCostID", SqlDbType.Int, 4, CentruCostID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}

		static public void UpdateCentruCost(long AngajatID, int CentruCostID, DateTime dataStart, DateTime old_dataStart)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricCentruCost", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CentruCostID", SqlDbType.Int, 4, CentruCostID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@old_DataStart", SqlDbType.DateTime, 8, old_dataStart));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}

		static public void DeleteCentruCost(long AngajatID, int CentruCostID, DateTime dataStart, DateTime old_dataStart)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricCentruCost", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CentruCostID", SqlDbType.Int, 4, CentruCostID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@old_DataStart", SqlDbType.DateTime, 8, old_dataStart));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}

		/// <summary>
		/// Procedura verifica daca in tabela IstoricCentr2Cost mai exista un centru de cost adaugat pentru aceeasi data
		/// </summary>
		/// <param name="angajatId">id-ul angajatului pentru care se cauta inregistrari</param>
		/// <param name="dataStart">data pentru care nu trebuie sa mai existe un angajat adugat</param>
		/// <returns>true daca se poate adauga o noua inregistrare si false altfel</returns>
		static public bool CheckIfCentruCostCanBeAdded(long angajatId, DateTime dataStart)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfCentruCostCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 8, angajatId));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrCentruCost", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[2].Value.ToString()) == 0;
		}*/
	}
}
