using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for IstoricLegitimatieSedere.
	/// </summary>
	public class IstoricLegitimatieSedere
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		private Salaries.Configuration.ModuleSettings settings;


		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		public IstoricLegitimatieSedere( long AngajatID )
		{
			m_AngajatID = AngajatID;
			LoadIstoricLegitimatiiSedere();
		}

		private void LoadIstoricLegitimatiiSedere()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetLegitimatiiSedereAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		static public bool InsertLegitimatieSedere( long AngajatID, string SerieLegitimatieSedere, string NrLegitimatieSedere, DateTime LegitimatieSedereDataEliberare, DateTime LegitimatieSedereDataExpirare, bool Activ )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteLegitimatieSedere", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LegitimatieSedereID", SqlDbType.Int, 4, -1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NrLegitimatieSedere", SqlDbType.NVarChar, 50, NrLegitimatieSedere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SerieLegitimatieSedere", SqlDbType.NVarChar, 10, SerieLegitimatieSedere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LegitimatieSedereDataEliberare", SqlDbType.DateTime, 8, LegitimatieSedereDataEliberare));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LegitimatieSedereDataExpirare", SqlDbType.DateTime, 8, LegitimatieSedereDataExpirare));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, Activ));

			// Modificat: Anca Holostencu
			// Descriere: Inserarea este facuta doar daca nu mai exista o legitimatie cu acelasi numar si aceeasi serie.
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

		static public bool UpdateLegitimatieSedere( long AngajatID, int LegitimatieSedereID, string SerieLegitimatieSedere, string NrLegitimatieSedere, DateTime LegitimatieSedereDataEliberare, DateTime LegitimatieSedereDataExpirare, bool Activ)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteLegitimatieSedere", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LegitimatieSedereID", SqlDbType.Int, 4, LegitimatieSedereID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NrLegitimatieSedere", SqlDbType.NVarChar, 50, NrLegitimatieSedere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SerieLegitimatieSedere", SqlDbType.NVarChar, 10, SerieLegitimatieSedere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LegitimatieSedereDataEliberare", SqlDbType.DateTime, 8, LegitimatieSedereDataEliberare));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LegitimatieSedereDataExpirare", SqlDbType.DateTime, 8, LegitimatieSedereDataExpirare));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, Activ));

			// Modificat: Anca Holostencu
			// Descriere: Modificarea este facuta doar daca nu mai exista o legitimatie cu acelasi numar si aceeasi serie.
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

		static public void DeleteLegitimatieSedere( int LegitimatieSedereID )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteLegitimatieSedere", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LegitimatieSedereID", SqlDbType.Int, 4, LegitimatieSedereID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NrLegitimatieSedere", SqlDbType.NVarChar, 50, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SerieLegitimatieSedere", SqlDbType.NVarChar, 10, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LegitimatieSedereDataEliberare", SqlDbType.DateTime, 8, DateTime.MinValue));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LegitimatieSedereDataExpirare", SqlDbType.DateTime, 8, DateTime.MinValue));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, 0));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}*/

	}
}
