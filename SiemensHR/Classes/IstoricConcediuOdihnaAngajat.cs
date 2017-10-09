using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using SiemensHR.utils;


namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for IstoricConcediuOdihnaAngajat.
	/// </summary>
	public class IstoricConcediuOdihnaAngajat
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		protected Salaries.Configuration.ModuleSettings settings;

		public IstoricConcediuOdihnaAngajat( long AngajatID )
		{
			m_AngajatID = AngajatID;
			LoadIstoricCO();
		}

		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		private void LoadIstoricCO()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("tm_GetIntervaleAbsentaTip", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodAbsenta", SqlDbType.NVarChar, 5, Salaries.Business.SituatieLunaraAngajat.codAbsente[ 2 ] ));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}*/

	}
}
