using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for IstoricNIF.
	/// </summary>
	public class IstoricNIF
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		private Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		public IstoricNIF( long AngajatID )
		{
			m_AngajatID = AngajatID;
			LoadIstoricNIFuri();
		}

		private void LoadIstoricNIFuri()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetNIFuriAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		static public bool InsertNIF( long AngajatID, string NrNIF, bool Activ )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);

			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteNIF", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NIFID", SqlDbType.Int, 4, -1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NIF", SqlDbType.NVarChar, 50, NrNIF));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, Activ));

			// Modificat: Anca Holostencu
			// Descriere: Adaugarea este facuta doar daca nu exista deja un NIF identic. Trebuie surprins
			//			  cazul in care exista un NIF cu acelasi numar.

			// se dauga parametrul care va retine valoare returnata de procedura (cel care indica daca inserarea a fost facuta)
			myCommand.Parameters.Add( new SqlParameter( "@rc", SqlDbType.Int ) );
			myCommand.Parameters[ "@rc" ].Direction = ParameterDirection.ReturnValue;

			m_con.Open();
			myCommand.ExecuteNonQuery();
			m_con.Close();
			m_con.Dispose();

			// daca nu s-a facut adaugarea, se returneaza false
			if( ( int )myCommand.Parameters[ "@rc" ].Value == -1 )
				return false;

			return true;
		}

		static public bool UpdateNIF( long AngajatID, int NIFID, string NrNIF, bool Activ)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);

			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteNIF", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NIFID", SqlDbType.Int, 4, NIFID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NIF", SqlDbType.NVarChar, 50, NrNIF));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, Activ));

			// Modificat: Anca Holostencu
			// Descriere: Modificarea este facuta doar daca nu exista deja un NIF identic. Trebuie surprins
			//			  cazul in care exista un NIF cu acelasi numar.

			// se dauga parametrul care va retine valoare returnata de procedura (cel care indica daca modificarea a fost facuta)
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

		static public void DeleteNIF( int NIFID )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteNIF", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NIFID", SqlDbType.Int, 4, NIFID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, -1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NIF", SqlDbType.NVarChar, 50, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, 0));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}*/
	}
}
