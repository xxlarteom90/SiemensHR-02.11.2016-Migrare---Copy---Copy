using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for IstoricPermisMunca.
	/// </summary>
	public class IstoricPermisMunca
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		private Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		public IstoricPermisMunca( long AngajatID )
		{
			m_AngajatID = AngajatID;
			LoadIstoricPermiseMunca();
		}

		private void LoadIstoricPermiseMunca()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetPermiseMuncaAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		static public void InsertPermisMunca( long AngajatID, string SeriePermisMunca, long NrPermisMunca, DateTime PermisMuncaDataEliberare, DateTime PermisMuncaDataExpirare, bool Activ )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeletePermisMunca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PermisMuncaID", SqlDbType.Int, 4, -1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NrpermisMunca", SqlDbType.BigInt, 10, NrPermisMunca));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SeriepermisMunca", SqlDbType.NVarChar, 10, SeriePermisMunca));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PermMuncaDataEliberare", SqlDbType.DateTime, 8, PermisMuncaDataEliberare));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PermMuncaDataExpirare", SqlDbType.DateTime, 8, PermisMuncaDataExpirare));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, Activ));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	
		}

		static public void UpdatePermisMunca( long AngajatID, int PermisMuncaID, string SeriePermisMunca, long NrPermisMunca, DateTime PermisMuncaDataEliberare, DateTime PermisMuncaDataExpirare, bool Activ)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeletePermisMunca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PermisMuncaID", SqlDbType.Int, 4, PermisMuncaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NrpermisMunca", SqlDbType.BigInt, 10, NrPermisMunca));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SeriepermisMunca", SqlDbType.NVarChar, 10, SeriePermisMunca));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PermMuncaDataEliberare", SqlDbType.DateTime, 8, PermisMuncaDataEliberare));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PermMuncaDataExpirare", SqlDbType.DateTime, 8, PermisMuncaDataExpirare));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, Activ));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void DeletePermisMunca( int PermisMuncaID )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeletePermisMunca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PermisMuncaID", SqlDbType.Int, 4, PermisMuncaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, -1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NrpermisMunca", SqlDbType.BigInt, 10, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SeriepermisMunca", SqlDbType.NVarChar, 10, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PermMuncaDataEliberare", SqlDbType.DateTime, 8, DateTime.MinValue));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PermMuncaDataExpirare", SqlDbType.DateTime, 8, DateTime.MinValue));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, 0));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		/// <summary>
		/// Procedura verifica daca un permise de munca poate fi adaugat astfel incat sa nu se creeze duplicate
		/// </summary>
		/// <param name="permisId">Id-ul permisului care se verifica</param>
		/// <param name="serie">Seria permisului</param>
		/// <param name="numar">Numarul permisului</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		static public bool CheckIfPermisMuncaCanBeAdded(int permisId, string serie, long numar)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfPermisMuncaCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PermisMuncaID", SqlDbType.Int, 4, permisId));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Serie", SqlDbType.NVarChar, 10, serie));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.BigInt, 8, numar));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrPermise", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[3].Value.ToString()) == 0;
		}*/
	}
}
