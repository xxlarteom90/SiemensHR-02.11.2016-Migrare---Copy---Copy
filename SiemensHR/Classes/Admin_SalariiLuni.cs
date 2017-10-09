using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for Admin_SalariiLuni.
	/// </summary>
	public class Admin_SalariiLuni
	{
		/*private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		public Admin_SalariiLuni()
		{
			LoadInfoLuniSalarii();
		}

		private void LoadInfoLuniSalarii()
		{

			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetLuniSalarii", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		/// <summary>
		/// Sunt selectate toate lunile. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		static public DataSet LoadInfoLuniSalariiUnion()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetAllLuniTextUnion", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			return ds;
		}*/
	}
}
