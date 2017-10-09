using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SiemensHR.utils;


namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for AdminTari.
	/// </summary>
	/// 
	public struct Tara
	{
		/*public string NumeTara;
		public string Simbol;
		public string Nationalitate;
		public bool TaraDeBaza;*/
	}

	public class AdminTari
	{
		/*private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		public AdminTari()
		{
			LoadInfoTari();
		}

		private void LoadInfoTari()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();

			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetAllTari", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		/// <summary>
		/// Sunt selectate toate tarile. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		static public DataSet LoadInfoTariUnion()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetAllTariUnion", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			return ds;
		}

		/// <summary>
		/// Lista nationalitatilor din sistem
		/// </summary>
		/// <returns> Un DataSet cu toate nationalitatile din sistem.</returns>
		/// <remarks> 
		/// Autor: Cristina Raluca Muntean
		/// Data:  31.05.2006
		/// </remarks>
		static public DataSet GetNationalitati()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection sqlConnection = new SqlConnection(connStr);
			
			SqlCommand sqlCommand = new SqlCommand("GetAllNationalitati", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
			DataSet dsNationalitati = new DataSet();
			sqlAdapter.Fill(dsNationalitati);

			return dsNationalitati;
		}

		/// <summary>
		/// Sunt selectate toate nationalitatile. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		static public DataSet GetNationalitatiUnion()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection sqlConnection = new SqlConnection(connStr);
			
			SqlCommand sqlCommand = new SqlCommand("spGetAllNationalitatiUnion", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCommand);
			DataSet dsNationalitati = new DataSet();
			sqlAdapter.Fill(dsNationalitati);

			return dsNationalitati;
		}

		static public void InsertTara(Tara newTara)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTara", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NumeTara", SqlDbType.NVarChar, 50, newTara.NumeTara));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Simbol", SqlDbType.NVarChar, 255, newTara.Simbol));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nationalitate", SqlDbType.NVarChar, 50, newTara.Nationalitate));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraDeBaza", SqlDbType.Bit, 1, newTara.TaraDeBaza));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void UpdateTara(Tara categData, int TaraID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTara", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraID", SqlDbType.Int, 4, TaraID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NumeTara", SqlDbType.NVarChar, 50, categData.NumeTara));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Simbol", SqlDbType.NVarChar, 255, categData.Simbol));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nationalitate", SqlDbType.NVarChar, 50, categData.Nationalitate));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraDeBaza", SqlDbType.Bit, 1, categData.TaraDeBaza));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void DeleteTara(int TaraID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTara", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraID", SqlDbType.Int, 4, TaraID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NumeTara", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Simbol", SqlDbType.NVarChar, 255, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nationalitate", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraDeBaza", SqlDbType.Bit, 1, false));


			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public Tara GetTaraInfo( int TaraID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetTara", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraID", SqlDbType.Int, 4, TaraID));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for TaraID=" +  TaraID.ToString());
			else
			{
				Tara infoTara;
				infoTara.NumeTara = ds.Tables[0].Rows[0]["NumeTara"].ToString();
				infoTara.Simbol = ds.Tables[0].Rows[0]["Simbol"].ToString();
				infoTara.Nationalitate = ds.Tables[0].Rows[0]["Nationalitate"].ToString();
				infoTara.TaraDeBaza = (bool)ds.Tables[0].Rows[0]["TaraDeBaza"];
				
				return infoTara;
			}
		}

		public static DataSet GetTaraDeBaza()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("GetTaraDeBaza", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			return ds;
		}

		static public bool CheckIfTaraCanBeDeleted(int TaraID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfTaraCanBeDeleted", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraID", SqlDbType.Int, 4, TaraID));
			myCommand.Parameters.Add(new SqlParameter("@Raspuns", SqlDbType.Bit, 1));
			myCommand.Parameters[1].Direction = ParameterDirection.ReturnValue;
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[1].Value.ToString()) == 1;
		}

		/// <summary>
		/// Procedura veririca sa nu se creeze duplicate in tabela Tari prin adaugare/modificare
		/// </summary>
		/// <param name="taraID">Id-ul tarii care nu trebuie sa concida</param>
		/// <param name="numeTara">Numele tarii</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		static public bool CheckIfTaraCanBeAdded(int taraID, string numeTara)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfTaraCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NumeTara", SqlDbType.NVarChar, 50, numeTara));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraID", SqlDbType.Int, 4, taraID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrTari", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[2].Value.ToString()) == 0;
		}*/
	}
}
