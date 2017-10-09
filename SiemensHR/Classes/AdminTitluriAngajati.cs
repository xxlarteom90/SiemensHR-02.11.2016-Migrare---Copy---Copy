using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SiemensHR.utils;


namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for AdminTitluriAngajati.
	/// </summary>
	/// 
	public struct TitluAngajat
	{
		/*public string Denumire;
		public string Simbol;*/
	}

	public class AdminTitluriAngajati
	{
		/*private DataSet dsTitluriAngajati;
		protected Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get { return dsTitluriAngajati;}
			set {}
		}

		public AdminTitluriAngajati()
		{
			LoadInfoTitluriAngajati();
		}

		private void LoadInfoTitluriAngajati()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection sqlConnection = new SqlConnection(settings.ConnectionString);
			SqlCommand sqlCommand = new SqlCommand("GetTitluriAngajati", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(sqlCommand);
			dsTitluriAngajati = new DataSet();
			dAdapt.Fill(dsTitluriAngajati);
		}

		/// <summary>
		/// Sunt selectate toate categoriile de angajati. La aceste inregistrari se adauga o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		static public DataSet LoadInfoTitluriAngajatiUnion()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand sqlCommand = new SqlCommand("spGetAllTitluriAngajatiUnion", m_con);
			sqlCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(sqlCommand);
			DataSet dsTitluriAngajati = new DataSet();
			dAdapt.Fill(dsTitluriAngajati);
			return dsTitluriAngajati;
		}

		static public void InsertTitluAngajat(TitluAngajat newTitluAngajat)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTitluAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TitluID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, newTitluAngajat.Denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Simbol", SqlDbType.NVarChar, 255, newTitluAngajat.Simbol));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void UpdateTitluAngajat(TitluAngajat categData, int TitluID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTitluAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TitluID", SqlDbType.Int, 4, TitluID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, categData.Denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Simbol", SqlDbType.NVarChar, 255, categData.Simbol));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void DeleteTitluAngajat(int TitluID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTitluAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TitluID", SqlDbType.Int, 4, TitluID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Simbol", SqlDbType.NVarChar, 255, ""));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public TitluAngajat GetTitluAngajatInfo( int TitluID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetTitluAngajat", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TitluAngajatID", SqlDbType.Int, 4, TitluID));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for TitluID=" +  TitluID.ToString());
			else
			{
				TitluAngajat infoTitluAngajat;
				infoTitluAngajat.Denumire = ds.Tables[0].Rows[0]["Denumire"].ToString();
				infoTitluAngajat.Simbol = ds.Tables[0].Rows[0]["Simbol"].ToString();
				
				return infoTitluAngajat;
			}
		}

		/// <summary>
		/// Procedura verifica daca un titlu poate fi sters
		/// </summary>
		/// <param name="TitluID">Id-ul titlui pentru care se face verificarea</param>
		/// <returns>Returneaza rezultatul verificarii
		/// 0 - se poate sterge titlul
		/// 1 - exista date asociate titlului
		/// 2 - titlul este ultimul din lista
		/// </returns>
		static public int CheckIfTitluAngajatCanBeDeleted( int TitluID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfTitluriAngajatiCanBeDeleted", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TitluAngajatID", SqlDbType.Int, 4, TitluID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@SePoateSterge", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[1].Value.ToString());
		}

		/// <summary>
		/// Procedura verifica sa nu se creeze duplicate in tabela TitluriAngajati
		/// </summary>
		/// <param name="titluID">Id-ul titlului care nu trebuie sa coincida</param>
		/// <param name="denumire">Denumirea titlului</param>
		/// <param name="simbol">Simbolul titlului</param>
		/// <returns>Returneaza true daca se poate face modificare/adaugare si false altfel</returns>
		static public bool CheckIfTitluAngajatCanBeAdded(int titluID, string denumire, string simbol)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfTitluriAngajatiCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 100, denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Simbol", SqlDbType.NVarChar, 10, simbol));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TitluID", SqlDbType.Int, 4, titluID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrTitluri", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[3].Value.ToString()) == 0;
		}*/
	}
}
