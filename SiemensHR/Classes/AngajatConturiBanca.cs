/*
 * Modificari:
 * Autor: Cristina Raluca Muntean
 * Data: 10.03.2005
 * Descriere: Adaugare metoda GetMonedaConturiAngajati.
 */
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using SiemensHR.utils;


namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for AngajatConturiBanca.
	/// </summary>
	public class AngajatConturiBanca
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		protected Salaries.Configuration.ModuleSettings settings;

		public long AngajatID
		{
			get {return m_AngajatID;}
			set {m_AngajatID = value;}
		}

		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		public AngajatConturiBanca(long AngajatID)
		{
			//
			// TODO: Add constructor logic here
			//
			m_AngajatID = AngajatID;
			LoadConturiBanca();
		}

		public int GetNumberOfAccounts()
		{
			return m_ds.Tables[0].Rows.Count;
		}

		private void LoadConturiBanca()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetAngajatConturiBanca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		static public void InsertCont(int BancaID, string nrCont, string Moneda, long AngajatID,bool Activ)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteContAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ContID", SqlDbType.Int, 4,0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BancaID", SqlDbType.Int, 4, BancaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NumarCont", SqlDbType.VarChar, 50, nrCont));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Moneda", SqlDbType.VarChar, 3, Moneda));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1,Activ ));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	
		}

		static public void DeleteCont(int ContID )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteContAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ContID", SqlDbType.BigInt, 10, ContID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BancaID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NumarCont", SqlDbType.VarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Moneda", SqlDbType.VarChar, 3, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, 0));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	
		}

		static public void UpdateCont(int ContID, int BancaID, int AngajatId, string nrCont, string Moneda,bool Activ)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteContAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ContID", SqlDbType.Int, 4, ContID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BancaID", SqlDbType.Int, 4, BancaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, AngajatId));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NumarCont", SqlDbType.VarChar, 50, nrCont));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Moneda", SqlDbType.VarChar, 3, Moneda));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, Activ));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	
		}

		/// <summary>
		/// Returneaza tipurile de monede in care au angajatii deschise conturi.
		/// </summary>
		/// <param name="angajatorID"> ID-ul angajatorului.</param>
		/// <returns> Un DataSet cu lista monede.</returns>
		static public DataSet GetMonedaConturiAngajati(int angajatorID)
		{
			DataSet dsMonede = new DataSet();
			string connectionString = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection sqlConnection= new SqlConnection(connectionString);
			SqlCommand sqlCommand = new SqlCommand("GetMonedaConturiAngajati", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;

			sqlCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, angajatorID));

			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			sqlDataAdapter.Fill(dsMonede);	

			return dsMonede;
		}

		/// <summary>
		/// Procedura verifica daca un cont al unui angajat poate fi adaugat
		/// </summary>
		/// <param name="contAngajat">Contul angajatului</param>
		/// <param name="contID">Id-ul contului angajatului</param>
		/// <returns>Returneaza true daca se poate face adaugare sau modificare, si false altfel</returns>
		static public bool CheckIfContAngajatCanBeAdded(string contAngajat, int contID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfContAngajatCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NumarCont", SqlDbType.NVarChar, 50, contAngajat));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ContID", SqlDbType.Int, 4, contID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrConturi", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[2].Value.ToString()) == 0;
		}*/
	}
}
