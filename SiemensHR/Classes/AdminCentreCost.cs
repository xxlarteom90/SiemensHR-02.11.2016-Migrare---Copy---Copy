using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for AdminCentreCost.
	/// </summary>
	/// 
	public struct CentruCost
	{
		/*public string Cod;
		public string Nume;
		public string Descriere;*/
	}

	public class AdminCentreCost
	{
		/*private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		public AdminCentreCost()
		{
			LoadInfoCentreCost();
		}

		private void LoadInfoCentreCost()
		{

			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("spGetAllCentreCost", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		static public void InsertCentruCost(CentruCost centruCost)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteCentruCost", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CentruCostID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.NVarChar, 10, centruCost.Cod));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, centruCost.Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, centruCost.Descriere));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void UpdateCentruCost(CentruCost centruCost, int CentruCostID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteCentruCost", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CentruCostID", SqlDbType.Int, 4, CentruCostID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.NVarChar, 10, centruCost.Cod));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, centruCost.Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, centruCost.Descriere));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void DeleteCentruCost(int CentruCostID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteCentruCost", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CentruCostID", SqlDbType.Int, 4, CentruCostID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.NVarChar, 10, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, ""));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}


		static public CentruCost GetCentruCostInfo( int CentruCostID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetCentruCost", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CentruCostID", SqlDbType.Int, 4, CentruCostID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for CentruCostID=" +  CentruCostID.ToString());
			else
			{
				CentruCost infoCentruCost;
				infoCentruCost.Cod = ds.Tables[0].Rows[0]["Cod"].ToString();
				infoCentruCost.Nume = ds.Tables[0].Rows[0]["Nume"].ToString();
				infoCentruCost.Descriere = ds.Tables[0].Rows[0]["Descriere"].ToString();
				
				return infoCentruCost;
			}
		}

		static public int CheckIfCentruCostCanBeDeleted( int CentruCostID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfCentruCostCanBeDeleted", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CentruCostID", SqlDbType.Int, 4, CentruCostID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@SePoateSterge", SqlDbType.Int, 4));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return int.Parse(myCommand.Parameters[1].Value.ToString());
		}

		/// <summary>
		/// Procedura verifica sa nu se creeze duplicate la daugare sau modificare in tabela CentreCost
		/// </summary>
		/// <param name="centruCostID">Id-ul centrului de cost care nu trebuie sa coincida</param>
		/// <param name="cod">Codul centrului de cost</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		static public bool CheckIfCentruCostCanBeAdded(int centruCostID, string cod)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfAdminCentruCostCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.NVarChar, 10, cod));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CentruCostID", SqlDbType.Int, 4, centruCostID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrCentre", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[2].Value.ToString()) == 0;
		}

		/// <summary>
		/// Procedura determina centrul de cost al unui departament
		/// </summary>
		/// <param name="departamentID">Id-ul departamentului pentru care se determina centrul de cost</param>
		/// <returns>Returneaza id-ul centrului de cost corespunzator departamentului</returns>
		static public int GetCentruCostPentruDepartament(int departamentID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetCentruCostPentruDepartament", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DepartamentID", SqlDbType.Int, 4, departamentID));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			if (ds.Tables[0].Rows.Count > 0)
				return int.Parse(ds.Tables[0].Rows[0]["CentruCostID"].ToString());
			else
				return -1;
		}*/

	}
}
