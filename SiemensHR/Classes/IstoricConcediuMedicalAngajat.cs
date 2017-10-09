using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for IstoricConcediuMedicalAngajat.
	/// </summary>
	public class IstoricConcediuMedicalAngajat
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		protected Salaries.Configuration.ModuleSettings settings;

		public IstoricConcediuMedicalAngajat( long AngajatID )
		{
			m_AngajatID = AngajatID;
			LoadIstoricCM();
		}

		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		private void LoadIstoricCM()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("tm_GetIntervaleAbsentaCM", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodAbsenta", SqlDbType.NVarChar, 5, Salaries.Business.SituatieLunaraAngajat.codAbsente[ 3 ] ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodAbsentaContinuare", SqlDbType.NVarChar, 5, Salaries.Business.SituatieLunaraAngajat.codAbsente[ 4 ] ));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}*/

	}
}
