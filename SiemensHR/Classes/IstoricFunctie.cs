using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for IstoricFunctie.
	/// </summary>
	public class IstoricFunctie
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		private Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		public IstoricFunctie(long AngajatID)
		{
			m_AngajatID = AngajatID;
			LoadIstoricFunctii();
		}

		private void LoadIstoricFunctii()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetIstoricFunctiiAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		static public void InsertFunctie(long AngajatID, int FunctieID, DateTime dataStart)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricFunctie", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@FunctieID", SqlDbType.Int, 4, FunctieID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}

		static public void UpdateFunctie(long AngajatID, int FunctieID, DateTime dataStart, DateTime old_dataStart)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricFunctie", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@FunctieID", SqlDbType.Int, 4, FunctieID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@old_DataStart", SqlDbType.DateTime, 8, old_dataStart));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}

		static public void DeleteFunctie(long AngajatID, int FunctieID, DateTime dataStart, DateTime old_dataStart)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricFunctie", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@FunctieID", SqlDbType.Int, 4, FunctieID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@old_DataStart", SqlDbType.DateTime, 8, old_dataStart));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	
		}

		/// <summary>
		/// Procedura verifica dca amia exista o inregistrare cu aceleasi date
		/// </summary>
		/// <param name="angajatId">id-ul angajatului pentru care sa adauga functia</param>
		/// <param name="dataStart">data pentru care sa adauga functia</param>
		/// <returns>Procedura returneaza true sau false in functia daca se pot face adaugari sau nu </returns>
		static public bool CheckIfIstoricFunctiiCanBeAdded(long angajatId, DateTime dataStart)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfIstoricFunctiiCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 8, angajatId));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrIstoricFunctii", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[2].Value.ToString()) == 0;
		}*/
	}
}
