/*
 * Modificari:
 * Autor:     Cristina Raluca Muntean
 * Data:      6.03.2006
 * Descriere: Adaugare metoda GetBanci()
 */
using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using SiemensHR.utils;
namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for AdminBanci.
	/// </summary>
	public class AdminBanci
	{
		/*private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;


		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		public AdminBanci()
		{
			LoadInfoBanci();
		}

		private void LoadInfoBanci()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("spGetAllBanci", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		/// <summary>
		/// Sunt selectate toate bancile. La aceste inregistrari se adauga o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inrgistrari</returns>
		static public DataSet LoadInfoBanciUnion()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetAllBanciUnion", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			return ds;
		}

		/// <summary>
		/// Returneaza urmatoarele date despre fiecare banca: codul bancii - numele bancii si id-ul acesteia.
		/// </summary>
		/// <returns> Toate datele aferente bancilor sunt stocate intr-un DataSet.</returns>
		public DataSet GetBanci()
		{
			// DataSet-ul cate va contine lista bancilor impreuna cu toate datele 
			// aferente acestora.
			DataSet dsBanci = new DataSet();
			// Conexiunea la baza de date.
			SqlConnection sqlConnection;
			// Comanda SQL.
			SqlCommand sqlCommand; 
			SqlDataAdapter sqlDataAdapter;

			settings = Salaries.Configuration.ModuleConfig.GetSettings();

			// Conexiunea la baza de date.
			sqlConnection = new SqlConnection(settings.ConnectionString);

			// Comanda SQL.
			sqlCommand = new SqlCommand("GetBanci", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;

			sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			sqlDataAdapter.Fill(dsBanci);

			return dsBanci;
		}

		//returneaza array-uri cu BancaID si Numnarul de conturi asignate la fiecare banca
		static public string GetJSArrays()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("CountConturiPerBanca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			string arBancaID = "";
			string arNoConturi = "";
			for(int i=0 ;i < ds.Tables[0].Rows.Count; i++)
			{
				DataRow row = ds.Tables[0].Rows[i];
				if (arBancaID!="")
					arBancaID += ",";
				arBancaID += "'" + row["BancaID"] + "'";
				if (arNoConturi!="")
					arNoConturi += ",";
				arNoConturi += "'" + Convert.ToInt32(row["nocontangajati"]) + Convert.ToInt32(row["nocontangajator"]) + "'";
			}

			return "var arBanciID = new Array("+ arBancaID + "); var arNoConturi = new Array(" + arNoConturi + ")";

		}

		public int GetNumberOfRecords()
		{
			return m_ds.Tables[0].Rows.Count;
		}

		public string GetBankCod(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return m_ds.Tables[0].Rows[RowIndex]["CodBanca"].ToString();
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRecords().ToString());
		}

		public string GetBankName(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return m_ds.Tables[0].Rows[RowIndex]["Nume"].ToString();
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRecords().ToString());
		}

		public string GetBankFiliala(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return m_ds.Tables[0].Rows[RowIndex]["Filiala"].ToString();
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRecords().ToString());
		}

		public string GetBankID(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return m_ds.Tables[0].Rows[RowIndex]["BancaID"].ToString();
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfRecords().ToString());
		}

		static public void InsertBanca(string Cod, string Nume, string Filiala)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteBanca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BancaID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodBanca", SqlDbType.NVarChar, 50, Cod));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NumeBanca", SqlDbType.NVarChar, 100, Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@FilialaBanca", SqlDbType.NVarChar, 100, Filiala));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}
		
		/// <summary>
		/// Verifica daca mai exista inca o banca ce are acelasi cod si/sau denumire cu banca ce se doreste a fi
		/// adaugata/modificata.
		/// </summary>
		/// <param name="bancaID">ID-ul bancii.</param>
		/// <param name="codBanca">Codul bancii.</param>
		/// <param name="nume">Numele bancii.</param>
		/// <param name="filiala">Filiala bancii.</param>
		/// <returns> true in cazul in care mai exista o banca ce are aceleasi caracteristici, false altfel.</returns>
		/// <remarks>
		/// Autor:  Cristina Raluca Muntean
		/// Data:   14.06.2006
		/// </remarks>
		static public bool VerificaExistentaBanca(int bancaID, string codBanca, string nume, string filiala)
		{
			bool existaBanca;
			string connectionString = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			SqlCommand sqlCommand = new SqlCommand("CheckIfExistaBanca", sqlConnection);
			
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@bancaID", SqlDbType.Int, 4, bancaID));
			sqlCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@codBanca", SqlDbType.NVarChar, 50, codBanca));
			sqlCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@nume", SqlDbType.NVarChar, 100, nume));
			sqlCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@filiala", SqlDbType.NVarChar, 100, filiala));
			sqlCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@existaBanca", SqlDbType.Bit,1));

			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			existaBanca = bool.Parse(sqlCommand.Parameters[4].Value.ToString());
			sqlConnection.Close();

			return existaBanca;
		}

		/// <summary>
		/// Verifica daca se poate sterge banca.
		/// </summary>
		/// <param name="bancaID">ID-ul bancii.</param>
		/// <returns> true in cazul in care se poate sterge banca, false altfel.</returns>
		/// <remarks>
		/// Autor:  Cristina Raluca Muntean
		/// Data:   14.06.2006
		/// </remarks>
		static public int VerificaStergereBanca(int bancaID)
		{
			int sePoateSterge;
			string connectionString = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			SqlCommand sqlCommand = new SqlCommand("CheckIfBancaCanBeDeleted", sqlConnection);
			
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@bancaID", SqlDbType.Int, 4, bancaID));
			sqlCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@sePoateSterge", SqlDbType.Int,4));

			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sePoateSterge = int.Parse(sqlCommand.Parameters[1].Value.ToString());
			sqlConnection.Close();

			return sePoateSterge;
		}		

		static public void DeleteBanca( int BancaID )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteBanca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BancaID", SqlDbType.Int, 4, BancaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodBanca", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NumeBanca", SqlDbType.NVarChar, 100, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@FilialaBanca", SqlDbType.NVarChar, 100, ""));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}
		
		static public void UpdateBanca(int BancaID, string Cod, string Nume, string Filiala)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteBanca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BancaID", SqlDbType.Int, 4, BancaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodBanca", SqlDbType.NVarChar, 50, Cod));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NumeBanca", SqlDbType.NVarChar, 100, Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@FilialaBanca", SqlDbType.NVarChar, 100, Filiala));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}*/
	}
}
