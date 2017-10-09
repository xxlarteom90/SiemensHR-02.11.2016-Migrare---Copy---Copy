using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SiemensHR.utils;


namespace SiemensHR.Classes
{
	public struct ImpozitInfo
	{
		public string Denumire;
		public double Procent;
		public	string Tip;
		public	int AplicatLaID;
	}
	/// <summary>
	/// Summary description for Admin_SalariiImpozite.
	/// </summary>
	public class Admin_SalariiImpozite
	{
		private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		public Admin_SalariiImpozite( int LunaID)
		{
			//LoadInfoImpozite(LunaID);
		}

		/*private void LoadInfoImpozite( int LunaID)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetInfoSalariiImpozite", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LunaID", SqlDbType.Int, 4, LunaID));			

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		public static ImpozitInfo GetImpozitInfo( int ImpozitID )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("select * from Salarii_Impozite where ImpozitID=" + ImpozitID.ToString(), m_con);

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			ImpozitInfo tmpImpozit = new ImpozitInfo();
			if (ds.Tables[0].Rows.Count!=0)
			{
				DataRow dataRow = ds.Tables[0].Rows[0];
				tmpImpozit.AplicatLaID = Convert.ToInt32(dataRow["AplicatLaID"]);
				tmpImpozit.Denumire = dataRow["Denumire"].ToString();
				tmpImpozit.Procent = Convert.ToDouble(dataRow["Procent"]);
				tmpImpozit.Tip = dataRow["Tip"].ToString();
			}

			return tmpImpozit;
		}

		public static void InsertImpozit(int LunaID, ImpozitInfo newImpozit)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteImpozit", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ImpozitID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, newImpozit.Denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Float, 6, newImpozit.Procent));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LunaID", SqlDbType.Int, 4, LunaID));	
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Tip", SqlDbType.NVarChar, 10, newImpozit.Tip));	
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AplicatLaID", SqlDbType.Int, 4, newImpozit.AplicatLaID));	

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
		}

		public static void UpdateImpozit(int LunaID, int ImpozitID, ImpozitInfo infoImpozit)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteImpozit", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ImpozitID", SqlDbType.Int, 4, ImpozitID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, infoImpozit.Denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Float, 6, infoImpozit.Procent));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LunaID", SqlDbType.Int, 4, LunaID));	
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Tip", SqlDbType.NVarChar, 10, infoImpozit.Tip));	
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AplicatLaID", SqlDbType.Int, 4, infoImpozit.AplicatLaID));	

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
		}

		public static void DeleteImpozit( int ImpozitID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteImpozit", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ImpozitID", SqlDbType.Int, 4, ImpozitID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Float, 6, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LunaID", SqlDbType.Int, 4, 0));	
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Tip", SqlDbType.NVarChar, 10, ""));	
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AplicatLaID", SqlDbType.Int, 4, 0));	

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
		}*/
	}
}
