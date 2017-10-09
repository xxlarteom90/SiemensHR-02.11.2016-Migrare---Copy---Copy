using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SiemensHR.utils;


namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for AdminLocuriMunca.
	/// </summary>
	/// 
	public struct LocMunca
	{
		public string Nume;
		public string Descriere;
	}

	public class AdminLocuriMunca
	{
		private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		public AdminLocuriMunca()
		{
			LoadInfoLocuriMunca();
		}

		private void LoadInfoLocuriMunca()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("select * from LocuriMunca order by Nume", m_con);
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		static public void InsertLocMunca(LocMunca newLocMunca)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteLocMunca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LocMuncaID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, newLocMunca.Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, newLocMunca.Descriere));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void UpdateLocMunca(LocMunca categData, int LocMuncaID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteLocMunca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LocMuncaID", SqlDbType.Int, 4, LocMuncaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, categData.Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, categData.Descriere));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void DeleteLocMunca(int LocMuncaID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteLocMunca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LocMuncaID", SqlDbType.Int, 4, LocMuncaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, ""));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public LocMunca GetLocMuncaInfo( int LocMuncaID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("select * from LocuriMunca where LocMuncaID=" + LocMuncaID.ToString(), m_con);
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for LocMuncaID=" +  LocMuncaID.ToString());
			else
			{
				LocMunca infoLocMunca;
				infoLocMunca.Nume = ds.Tables[0].Rows[0]["Nume"].ToString();
				infoLocMunca.Descriere = ds.Tables[0].Rows[0]["Descriere"].ToString();
				
				return infoLocMunca;
			}
		}

		static public bool CheckIfLocMuncaCanBeDeleted( int LocMuncaID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("select count(LocMuncaID) as norec from IstoricLocMunca where LocMuncaID=" + LocMuncaID.ToString(), m_con);
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (Convert.ToInt32(ds.Tables[0].Rows[0]["norec"])>0)
				return false;
			else
				return true;
		}

		/// <summary>
		/// Procedura verifica sa nu se adauge duplicate in tabela LocuriMunca
		/// </summary>
		/// <param name="locMuncaID">Id-ul locului de munca pentru care se verifica sa nu coincida</param>
		/// <param name="nume">Numele locului de munca</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare sau false altfel</returns>
		static public bool CheckIfLocMuncaCanBeAdded(int locMuncaID, string nume)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfLocMuncaCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LocMuncaID", SqlDbType.Int, 4, locMuncaID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrLocuriMunca", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[2].Value.ToString()) == 0;
		}
	}
}
