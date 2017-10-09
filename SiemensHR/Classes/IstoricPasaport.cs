using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for IstoricPasaport.
	/// </summary>
	public class IstoricPasaport
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		private Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		public IstoricPasaport( long AngajatID )
		{
			m_AngajatID = AngajatID;
			LoadIstoricPasapoarte();
		}

		private void LoadIstoricPasapoarte()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetPasapoarteAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		static public void InsertPasaport( long AngajatID, string Serie, string Numar, string EliberatDe, DateTime DataEliberarii, DateTime ValabilPanaLa, bool Activ )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeletePasaport", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PasaportID", SqlDbType.Int, 4, -1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.NVarChar, 50, Numar));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Serie", SqlDbType.NVarChar, 10, Serie));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@EliberatDe", SqlDbType.NVarChar, 50, EliberatDe));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEliberarii", SqlDbType.DateTime, 8, DataEliberarii));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ValabilPanaLa", SqlDbType.DateTime, 8, ValabilPanaLa));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, Activ));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void UpdatePasaport( long AngajatID, int PasaportID, string Serie, string Numar, string EliberatDe, DateTime DataEliberarii, DateTime ValabilPanaLa, bool Activ)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeletePasaport", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PasaportID", SqlDbType.Int, 4, PasaportID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.NVarChar, 50, Numar));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Serie", SqlDbType.NVarChar, 10, Serie));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@EliberatDe", SqlDbType.NVarChar, 50, EliberatDe));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEliberarii", SqlDbType.DateTime, 8, DataEliberarii));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ValabilPanaLa", SqlDbType.DateTime, 8, ValabilPanaLa));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, Activ));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void DeletePasaport( int PasaportID )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeletePasaport", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PasaportID", SqlDbType.Int, 4, PasaportID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Serie", SqlDbType.NVarChar, 10, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@EliberatDe", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEliberarii", SqlDbType.DateTime, 8, DateTime.MinValue));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ValabilPanaLa", SqlDbType.DateTime, 8, DateTime.MinValue));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, 0));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		/// <summary>
		/// Procedura verifica daca un pasaport poate fi adaugat astfel incat sa nu se creeze duplicate
		/// </summary>
		/// <param name="pasaportId">Id-ul pasaportului care se verifica</param>
		/// <param name="serie">Seria pasaportului</param>
		/// <param name="numar">Numarul pasaportului</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		static public bool CheckIfPasaportCanBeAdded(int pasaportId, string serie, string numar)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfPasaportCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PasaportID", SqlDbType.Int, 4, pasaportId));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Serie", SqlDbType.NVarChar, 10, serie));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.NVarChar, 50, numar));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrPasapoarte", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[3].Value.ToString()) == 0;
		}*/
	}
}
