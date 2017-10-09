using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SiemensHR.utils;
using System.Web.UI.WebControls;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for Admin_SalariiCategoriiAngajati.
	/// </summary>
	public class Admin_SalariiCategoriiAngajati
	{
		/*private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		public Admin_SalariiCategoriiAngajati(int LunaID)
		{
			LoadInfoCategorii(LunaID);
		}

		public Admin_SalariiCategoriiAngajati()
		{
			LoadInfoCategorii();
		}


		private void CopyCategoryLunaActiva(int CategorieID,int LunaActivaID)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();	
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("sal_InitCategoriiLunaActiva", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, CategorieID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LunaActivaID", SqlDbType.Int, 4, LunaActivaID));	
			

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
		
		}


		private void LoadInfoCategorii( int LunaID)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();	
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("spGetAllCategoriiAngajatiLunaID", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LunaID", SqlDbType.Int, 4, LunaID));
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		/// <summary>
		/// Sunt selectate toate categoriile de angajati. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <param name="LunaID">Id-ul lunii pentru care sunt selecatate categoriile de angajati</param>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		static public DataSet LoadInfoCategoriiUnion(int LunaID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetAllCategoriiAngajatiUnion", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LunaID", SqlDbType.Int, 4, LunaID));
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			return ds;
		}

		private void LoadInfoCategorii()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();	
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("spGetAllCategoriiAngajati", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		public static void InsertCategorie(int LunaID, string Denumire, string ListaImpozite)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteCategorieSalarii", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, Denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LunaID", SqlDbType.Int, 4, LunaID));	
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ListaImpozite", SqlDbType.NVarChar, 100, ListaImpozite));	

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
		}

		public static void UpdateCategorie(int CategorieID,  string Denumire, string ListaImpozite)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteCategorieSalarii", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, CategorieID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, Denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LunaID", SqlDbType.Int, 4, 0));	
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ListaImpozite", SqlDbType.NVarChar, 100, ListaImpozite));	

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
		}

		public static void DeleteCategorie(int CategorieID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteCategorieSalarii", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, CategorieID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LunaID", SqlDbType.Int, 4, 0));	
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ListaImpozite", SqlDbType.NVarChar, 10, ""));	

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
		}

		public static string GetCategorieDenumire( int CategorieID )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetCategorieDenumire", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, CategorieID));
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			//Modificat:	Oprescu Claudia
			//Descriere:	Se selecteaza o categorie numai daca id-ul ei este nenul
			if (CategorieID > 0)
			{
				if (ds.Tables[0].Rows.Count>0)
					return ds.Tables[0].Rows[0]["Denumire"].ToString();
				else
					throw new Exception("No data at CategorieID=" + CategorieID.ToString());
			}
			else
				return "";
			
		}

		public static string GetListaImpoziteAsignate( int CategorieID )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetListaImpoziteAsignate", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, CategorieID));
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			string retVal= "" ;
			for(int i=0; i<ds.Tables[0].Rows.Count; i++)
			{
				if (retVal!="")
					retVal += ",";
				retVal += ds.Tables[0].Rows[i]["ImpozitID"].ToString();
			}
			
			return retVal;
		}

		public static void FillListaImpoziteAsignate( int CategorieID, ListBox tmpList)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("GetImpoziteCategorie", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, CategorieID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			tmpList.Items.Clear();
			for(int i=0 ; i<ds.Tables[0].Rows.Count; i++)
			{
				string Denumire = ds.Tables[0].Rows[i]["Denumire"].ToString();
				string Procent = ds.Tables[0].Rows[i]["Procent"].ToString();
				string ImpozitID = ds.Tables[0].Rows[i]["ImpozitID"].ToString();

				ListItem myItem = new ListItem(Denumire + " - " + Procent + "%", ImpozitID);
				tmpList.Items.Add(myItem);
			}
		}

		public static bool CheckIfCategorieAngajatiCanBeDeleted( int CategorieID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfCategorieAngajatiCanBeDeleted", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, CategorieID));
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (Convert.ToInt32(ds.Tables[0].Rows[0]["norec"])>0)
				return false;
			else
				return true;
		}*/
	}
}
