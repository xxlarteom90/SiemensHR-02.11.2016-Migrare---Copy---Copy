using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SiemensHR.utils;


namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for AdminGrupeMunca.
	/// </summary>
	/// 
	public struct GrupaMunca
	{
		public string Nume;
		public string Descriere;
	}

	public class AdminGrupeMunca
	{
		private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		public AdminGrupeMunca()
		{
			LoadInfoGrupeMunca();
		}

		private void LoadInfoGrupeMunca()
		{

			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("select * from GrupeMunca", m_con);
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		static public void InsertGrupaMunca(GrupaMunca newGrupaMunca)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteGrupaMunca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@GrupaMuncaID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, newGrupaMunca.Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, newGrupaMunca.Descriere));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void UpdateGrupaMunca(GrupaMunca categData, int GrupaMuncaID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteGrupaMunca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@GrupaMuncaID", SqlDbType.Int, 4, GrupaMuncaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, categData.Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, categData.Descriere));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void DeleteGrupaMunca(int GrupaMuncaID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteGrupaMunca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@GrupaMuncaID", SqlDbType.Int, 4, GrupaMuncaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, ""));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public GrupaMunca GetGrupaMuncaInfo( int GrupaMuncaID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("select * from GrupeMunca where GrupaMuncaID=" + GrupaMuncaID.ToString(), m_con);
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for GrupaMuncaID=" +  GrupaMuncaID.ToString());
			else
			{
				GrupaMunca infoGrupaMunca;
				infoGrupaMunca.Nume = ds.Tables[0].Rows[0]["Nume"].ToString();
				infoGrupaMunca.Descriere = ds.Tables[0].Rows[0]["Descriere"].ToString();
				
				return infoGrupaMunca;
			}
		}

		static public bool CheckIfGrupaMuncaCanBeDeleted( int GrupaMuncaID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("select count(GrupaMuncaID) as norec from IstoricGrupeMunca where GrupaMuncaID=" + GrupaMuncaID.ToString(), m_con);
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (Convert.ToInt32(ds.Tables[0].Rows[0]["norec"])>0)
				return false;
			else
				return true;
		}

		/// <summary>
		/// Procedura verifica daca mai exista in baza de date o grupa de munca cu acelasi nume
		/// </summary>
		/// <param name="grupaMuncaID">Id-ul grupei de munca care nu se testeaza</param>
		/// <param name="nume">Numele grupei care nu trebuie sa coincida</param>
		/// <returns>Returneaza true daca se poate face actualizarea si false altfel</returns>
		static public bool CheckIfGrupaMuncaCanBeAdded(int grupaMuncaID, string nume)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfGrupaMuncaCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@GrupaMuncaID", SqlDbType.Int, 4, grupaMuncaID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrGrupe", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[2].Value.ToString()) == 0;
		}
	}
}
