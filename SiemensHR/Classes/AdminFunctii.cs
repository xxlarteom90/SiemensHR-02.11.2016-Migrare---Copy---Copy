using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SiemensHR.utils;


namespace SiemensHR.Classes
{

	public struct Functie
	{
		/*public long Cod;
		public string CodSiemens;
		public string Nume;
		public string Descriere;
		public int NormaLucru;*/
	}
	/// <summary>
	/// Summary description for AdminFunctii.
	/// </summary>
	public class AdminFunctii
	{

		/*private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		public AdminFunctii()
		{
			LoadInfoFunctii();
		}

		private void LoadInfoFunctii()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("spGetAllFunctii", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		/// <summary>
		/// Sunt selectate toate functiile. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care cotine aceste inregistrari</returns>
		static public DataSet LoadInfoFunctiiUnion()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetAllFunctiiUnion", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			return ds;
		}

		/// <summary>
		/// Procedura selecteaza toate functiile sub forma urmatoarei structuri codul Siemens - numele functiei
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele selectate</returns>
		static public DataSet LoadInfoCodSiemensNumeFunctie()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetAllFunctiiCodSiemensNumeFunctie", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			return ds;
		}

		/// <summary>
		/// Procedura selecteaza toate functiile sub forma urmatoarei structuri codul COR - numele functiei
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele selectate</returns>
		static public DataSet LoadInfoCodCORNumeFunctie()
		{		
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetAllFunctiiCodCORNumeFunctie", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			return ds;
		}

		static public void InsertFunctie(Functie newFunctie)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteFunctie", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@FunctieID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.BigInt, 10, newFunctie.Cod));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodSiemens", SqlDbType.NVarChar, 20, newFunctie.CodSiemens));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, newFunctie.Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, newFunctie.Descriere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NormaLucru", SqlDbType.Int, 2, newFunctie.NormaLucru));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public Functie GetFunctieInfo( int FunctieID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetFunctie", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@FunctieID", SqlDbType.Int, 4, FunctieID));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for FunctieID=" +  FunctieID.ToString());
			else
			{
				Functie infoFunctie;
				infoFunctie.Cod = Convert.ToInt64(ds.Tables[0].Rows[0]["Cod"]);
				infoFunctie.CodSiemens = ds.Tables[0].Rows[0]["CodSiemens"].ToString();
				infoFunctie.Nume = ds.Tables[0].Rows[0]["Nume"].ToString();
				infoFunctie.Descriere = ds.Tables[0].Rows[0]["Descriere"].ToString();
				infoFunctie.NormaLucru = Convert.ToInt32(ds.Tables[0].Rows[0]["NormaLucru"]);
				
				return infoFunctie;
			}
		}

		static public void UpdateFunctie(Functie newFunctie, int FunctieID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteFunctie", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@FunctieID", SqlDbType.Int, 4, FunctieID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.BigInt, 10, newFunctie.Cod));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodSiemens", SqlDbType.NVarChar, 20, newFunctie.CodSiemens));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, newFunctie.Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, newFunctie.Descriere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NormaLucru", SqlDbType.Int, 2, newFunctie.NormaLucru));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}


		static public void DeleteFunctie(int FunctieID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteFunctie", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@FunctieID", SqlDbType.Int, 4, FunctieID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.BigInt, 10, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodSiemens", SqlDbType.NVarChar, 20, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NormaLucru", SqlDbType.Int, 2, 0));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		/// <summary>
		/// Procedura determina daca o functie poate fi stearsa
		/// </summary>
		/// <param name="FunctieID">Id-ul functiei pentru care se face verificarea</param>
		/// <returns>Returneaza rezultatul verificarii
		/// 0 - se poate sterge functia
		/// 1 - exista date asociate ei
		/// 2 - este ultima din lista
		/// </returns>
		static public int CheckIfFunctieCanBeDeleted( int FunctieID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfFunctieCanBeDeleted", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@FunctieID", SqlDbType.Int, 4, FunctieID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@SePoateSterge", SqlDbType.Int, 4));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return int.Parse(myCommand.Parameters[1].Value.ToString());
		}
		/*Se verifica daca toate functiile au si codul Siemens atasat.
		  La adaugarea functiei unui angajat in cazul in care o functie nu are cod Siemens atunci in
		dropdownlist-ul cu functii va fi afisat Codul COR - Nume functiei, altfel se va afisa
		Codul Siemens - Numele functiei*/
		/*static public bool CheckIfToateFunctiileAuCodSiemens()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("CheckIfToateFunctiileAuCodSiemens", m_con);
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (Convert.ToInt32(ds.Tables[0].Rows[0]["norec"])>0)
				return false;
			else
				return true;
		}

		/// <summary>
		/// Procedura verifica daca mai exista in baza de date o functie cu acelasi cod
		/// </summary>
		/// <param name="functieID">id/ul functiei fata de care trebuie sa fie diferit</param>
		/// <param name="cod">codul care se cauta pentru o functie</param>
		/// <returns>daca nu mai exista o functie cu acelasi cod si deci se poate face adaugare se returneaza true, altfel false</returns>
		static public bool CheckIfFunctieCanBeAdded(int functieID, int cod)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfFunctieCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.Int, 4, cod));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@FunctieID", SqlDbType.Int, 4, functieID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrFunctii", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[2].Value.ToString()) == 0;
		}*/
	}
}
