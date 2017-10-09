using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for IstoricCarteIdentitate.
	/// </summary>
	public class IstoricCarteIdentitate
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		protected Salaries.Configuration.ModuleSettings settings;
		
		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		public IstoricCarteIdentitate( long AngajatID )
		{
			m_AngajatID = AngajatID;
			LoadIstoricCartiIdentitate();
		}

		private void LoadIstoricCartiIdentitate()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetCartiIdentitateAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}
		
		/// <summary>
		/// Verifica daca este activa o carte de identitate.
		/// </summary>
		/// <param name="CarteIdentitateID">Id-ul cartii de identitate.</param>
		/// <returns>true daca este activa, false altfel</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data: 26.05.2006
		/// </remarks>
		static public bool CheckIfIsCarteIdentitateActiva(int carteIdentitateID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);

			SqlCommand myCommand = new SqlCommand("CheckIfCarteIdentitateActiva", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CarteIdentitateID", SqlDbType.Int, 4, carteIdentitateID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@esteActiva", SqlDbType.Bit, 1));

			m_con.Open();
			myCommand.ExecuteNonQuery();
			m_con.Close();
			m_con.Dispose();

			return (bool)myCommand.Parameters[1].Value;
		}

		static public bool InsertCarteIdentitate( long AngajatID, long CNP, long CNPAnterior, string Serie, long Numar, string EliberatDe, DateTime DataEliberarii, DateTime ValabilPanaLa, bool Activ )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);

			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteCarteIdentitate", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CarteIdentitateID", SqlDbType.Int, 4, -1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CNP", SqlDbType.BigInt, 10, CNP));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CNPAnterior", SqlDbType.BigInt, 10, CNPAnterior));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.BigInt, 10, Numar));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Serie", SqlDbType.NVarChar, 10, Serie));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@EliberatDe", SqlDbType.NVarChar, 50, EliberatDe));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEliberarii", SqlDbType.DateTime, 8, DataEliberarii));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ValabilPanaLa", SqlDbType.DateTime, 8, ValabilPanaLa));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, Activ));

			// Modificat: Anca Holostencu
			// Descriere: Adaugarea este facuta doar daca nu mai exista o carte de identitate cu aceleasi date.
			//			  Trebuie surprins cazul in care inserarea nu a fost facuta.

			// se dauga parametrul care va retine valoarea returnata de procedura (cel care indica daca inserarea a fost facuta)
			myCommand.Parameters.Add( new SqlParameter( "@rc", SqlDbType.Int ) );
			myCommand.Parameters[ "@rc" ].Direction = ParameterDirection.ReturnValue;

			m_con.Open();
			myCommand.ExecuteNonQuery();
			m_con.Close();
			m_con.Dispose();

			// daca nu s-a facut inserarea, se returneaza false
			if( ( int )myCommand.Parameters[ "@rc" ].Value == -1 )
				return false;

			return true;
		}

		static public bool UpdateCarteIdentitate( long AngajatID, int CarteIdentitateID, long CNP, long CNPAnterior, string Serie, long Numar, string EliberatDe, DateTime DataEliberarii, DateTime ValabilPanaLa, bool Activ)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);

			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteCarteIdentitate", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CarteIdentitateID", SqlDbType.Int, 4, CarteIdentitateID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CNP", SqlDbType.BigInt, 10, CNP));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CNPAnterior", SqlDbType.BigInt, 10, CNPAnterior));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.BigInt, 10, Numar));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Serie", SqlDbType.NVarChar, 10, Serie));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@EliberatDe", SqlDbType.NVarChar, 50, EliberatDe));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEliberarii", SqlDbType.DateTime, 8, DataEliberarii));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ValabilPanaLa", SqlDbType.DateTime, 8, ValabilPanaLa));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, Activ));

			// Modificat: Anca Holostencu
			// Descriere: Modificarea este facuta doar daca nu mai exista o carte de identitate cu aceleasi date.
			//			  Trebuie surprins cazul in care modificarea nu a fost facuta.

			// se dauga parametrul care va retine valoarea returnata de procedura (cel care indica daca modificarea a fost facuta)
			myCommand.Parameters.Add( new SqlParameter( "@rc", SqlDbType.Int ) );
			myCommand.Parameters[ "@rc" ].Direction = ParameterDirection.ReturnValue;

			m_con.Open();
			myCommand.ExecuteNonQuery();
			m_con.Close();
			m_con.Dispose();

			// daca nu s-a facut modificarea, se returneaza false
			if( ( int )myCommand.Parameters[ "@rc" ].Value == -1 )
				return false;

			return true;
		}

		static public void DeleteCarteIdentitate( int CarteIdentitateID )
		{
				string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteCarteIdentitate", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CarteIdentitateID", SqlDbType.Int, 4, CarteIdentitateID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CNP", SqlDbType.BigInt, 10, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CNPAnterior", SqlDbType.BigInt, 10, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.BigInt, 10, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Serie", SqlDbType.NVarChar, 10, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@EliberatDe", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEliberarii", SqlDbType.DateTime, 8, DateTime.MinValue));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ValabilPanaLa", SqlDbType.DateTime, 8, DateTime.MinValue));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, 0));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}*/

	}
}
