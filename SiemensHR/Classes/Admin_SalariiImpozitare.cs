using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SiemensHR.utils;
using System.Web.UI.WebControls;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for Admin_SalariiImpozitare.
	/// </summary>
	public class Admin_SalariiImpozitare
	{
		/*protected Salaries.Configuration.ModuleSettings settings;
		public Admin_SalariiImpozitare()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		static public void UpdateImpozitar(double ValMin, double ValMax, double SumaBaza, double Procent, int ImpozitarID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteImpozitar", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ImpozitarID", SqlDbType.Int, 4, ImpozitarID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ValMin", SqlDbType.Decimal, 19, ValMin));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ValMax", SqlDbType.Decimal, 19, ValMax));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SumaBaza", SqlDbType.Decimal, 19, SumaBaza));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Decimal, 6, Procent));

            	

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
		}

		static public void InsertImpozitar(double ValMin, double ValMax, double SumaBaza, double Procent, int CategorieID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteImpozitar", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ImpozitarID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, CategorieID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ValMin", SqlDbType.Decimal, 19, ValMin));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ValMax", SqlDbType.Decimal, 19, ValMax));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SumaBaza", SqlDbType.Decimal, 19, SumaBaza));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Decimal, 6, Procent));

            	

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
		}

		static public void DeleteImpozitar( int ImpozitarID )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteImpozitar", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ImpozitarID", SqlDbType.Int, 4, ImpozitarID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ValMin", SqlDbType.Decimal, 19, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ValMax", SqlDbType.Decimal, 19, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SumaBaza", SqlDbType.Decimal, 19, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Decimal, 6, 0));

   
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}*/
	}
}
