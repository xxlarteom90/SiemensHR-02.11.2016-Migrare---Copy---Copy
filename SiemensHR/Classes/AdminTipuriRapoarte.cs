using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SiemensHR.utils;


namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for AdminTipuriRapoarte.
	/// </summary>
	/// 
	public struct TipRaport
	{
		/*public string Denumire;
		public string Descriere;*/
	}

	public class AdminTipuriRapoarte
	{
		/*private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;


		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		public AdminTipuriRapoarte()
		{
			LoadInfoTipuriRapoarte();
		}

		private void LoadInfoTipuriRapoarte()
		{

			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("spGetAllTipuriRapoarte", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		static public void InsertTipRaport(TipRaport newTipRaport)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTipRaport", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipRaportID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, newTipRaport.Denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, newTipRaport.Descriere));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void UpdateTipRaport(TipRaport rapData, int TipRaportID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTipRaport", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipRaportID", SqlDbType.Int, 4, TipRaportID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, rapData.Denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, rapData.Descriere));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void DeleteTipRaport(int TipRaportID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTipRaport", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipRaportID", SqlDbType.Int, 4, TipRaportID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, ""));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public TipRaport GetTipRaportInfo( int TipRaportID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetTipRaport", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipRaportID", SqlDbType.Int, 4, TipRaportID));
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for TipRaportID=" +  TipRaportID.ToString());
			else
			{
				TipRaport infoTipRaport;
				infoTipRaport.Denumire = ds.Tables[0].Rows[0]["Denumire"].ToString();
				infoTipRaport.Descriere = ds.Tables[0].Rows[0]["Descriere"].ToString();
				
				return infoTipRaport;
			}
		}

		static public int CheckIfTipRaportCanBeDeleted( int TipRaportID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfTipRaportCanBeDeleted", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipRaportID", SqlDbType.Int, 4, TipRaportID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@SePoateSterge", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return int.Parse(myCommand.Parameters[1].Value.ToString());
		}

		/// <summary>
		/// Procedura verifica sa nu se adauge duplicate in tabela TipuriRapoarte prin adaugare/modificare
		/// </summary>
		/// <param name="tipRaportID">Id-ul tipului de raport care nu trebuie sa coincida</param>
		/// <param name="denumire">Numele tipului de raport</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		static public bool CheckIfTipRaportCanBeAdded(int tipRaportID, string denumire)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfTipRaportCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipRaportID", SqlDbType.Int, 4, tipRaportID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrTipuri", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[2].Value.ToString()) == 0;
		}*/
	}
}
