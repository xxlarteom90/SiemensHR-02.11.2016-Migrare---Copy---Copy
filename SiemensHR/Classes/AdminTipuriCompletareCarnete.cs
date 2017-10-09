/*
 * Modificari:
 * Autor:     Cristina Raluca Muntean
 * Data:      6.03.2006
 * Descriere: Adaugare metoda GetTipuriCompletareCarnete(int angajatorID);
 */
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	public struct TipCompletareCarnet
	{
		/*public string Descriere;
		public string Cod;
		public float Procent;*/
	}

	/// <summary>
	/// Summary description for AdminTipuriCompletareCarnete.
	/// </summary>
	public class AdminTipuriCompletareCarnete
	{
		/*private int m_AngajatorID;
		private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;

		public AdminTipuriCompletareCarnete(int AngajatorID)
		{
			m_AngajatorID = AngajatorID;
			LoadInfoTipuriCompletare();
		}
		
		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		private void LoadInfoTipuriCompletare()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("spGetTipuriCompletareCarnete", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, m_AngajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddNULLParameter("@tipCompletareCarnetID", SqlDbType.Int, 4));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		public void InsertTipCompletare(TipCompletareCarnet newTipCompletareCarnet)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTipCompletare", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, m_AngajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipCompletareID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, newTipCompletareCarnet.Descriere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.NVarChar, 100, newTipCompletareCarnet.Cod));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Float, 255, newTipCompletareCarnet.Procent));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		public void UpdateTipCompletare(TipCompletareCarnet tipCompletareCarnet, int tipCompletareCarnetID)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTipCompletare", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, m_AngajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipCompletareID", SqlDbType.Int, 4, tipCompletareCarnetID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, tipCompletareCarnet.Descriere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.NVarChar, 100, tipCompletareCarnet.Cod));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Float, 255, tipCompletareCarnet.Procent));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		public void DeleteTipCompletare(int tipCompletareCarnetID)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteTipCompletare", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
		
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, m_AngajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipCompletareID", SqlDbType.Int, 4, tipCompletareCarnetID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.NVarChar, 100, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Float, 8, 0));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		public TipCompletareCarnet GetTipCompletareInfo( int tipCompletareCarnetID)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("spGetTipuriCompletareCarnete", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, m_AngajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tipCompletareCarnetID", SqlDbType.Int, 4, tipCompletareCarnetID));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for TipCompletareCarnetID=" +  tipCompletareCarnetID.ToString());
			else
			{
				TipCompletareCarnet tipCompletareCarnet;
				tipCompletareCarnet.Descriere = ds.Tables[0].Rows[0]["ModCompletare"].ToString();
				tipCompletareCarnet.Cod = ds.Tables[0].Rows[0]["Cod"].ToString();
				tipCompletareCarnet.Procent = float.Parse(ds.Tables[0].Rows[0]["Procent"].ToString());
				
				return tipCompletareCarnet;
			}
		}

		/// <summary>
		/// Procedura verifica daca un tip de completare poate fi sters sau nu
		/// </summary>
		/// <param name="tipCompletareCarnetID">Id-ul tipului pentru care se face verificarea</param>
		/// <returns>Returneaza 0 daca se poate face stergerea, 
		///						1 daca exista date asociate tipului,
		///						2 daca tipul este ultimul din lista
		///	</returns>
		///	<remarks>
		///	Autor:	Oprescu Claudia
		///	Data:	23.03.2007
		///	</remarks>
		public int CheckIfTipCompletareCarnetCanBeDeleted( int tipCompletareCarnetID)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("spCheckIfTipuriCompletareCarneteCanBeDeleted", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipCompletareCarnetID", SqlDbType.Int, 4, tipCompletareCarnetID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@SePoateSterge", SqlDbType.Int, 4));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			return int.Parse(myCommand.Parameters[1].Value.ToString());
		}

		/// <summary>
		/// Returneaza tipurile de completare are carnetelor de munca.
		/// </summary>
		/// <returns> Tipurile de completare ale carnetelor de munca sunt stocate intr-un DataSet.</returns>
		public DataSet GetTipuriCompletareCarnete()
		{
			// DataSet-ul care va contine tipurile de completare ale carnetelor de munca.
			DataSet dsTipuriCompletareCarnete = new DataSet();
	
			// Sunt preluate setarile.
			settings = Salaries.Configuration.ModuleConfig.GetSettings();

			// Conexiunea la baza de date
			SqlConnection sqlConnection = new SqlConnection(settings.ConnectionString);
			
			// Comanda SQL - procedura stocata.
			SqlCommand sqlCommand = new SqlCommand("spGetTipuriCompletareCarnete", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;

			// Sunt adaugati parametrii.
			sqlCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, m_AngajatorID ));
			sqlCommand.Parameters.Add(UtilitiesDb.AddNULLParameter("@tipCompletareCarnetID", SqlDbType.Int, 4));

			// Este completat DataSet-ul.
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			sqlDataAdapter.Fill(dsTipuriCompletareCarnete);

			return dsTipuriCompletareCarnete;
		}

		/// <summary>
		/// Procedura verifica sa nu se aduage duplicate in tabela sal_CompletareCarneteTipuri
		/// </summary>
		/// <param name="completareCarnetTipID">Id-ul tipului de carnet care nu trebuie sa coincida</param>
		/// <param name="modCompletare">Modul de completare al carnetului</param>
		/// <param name="cod">Codul pentru tipul de carnet</param>
		/// <param name="angajatorID"> Id-ul angajatorului pentru care se verifica tipurile de carnete</param>
		/// <returns>Retunreaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfCarneteTipuriCanBeAdded(int completareCarnetTipID, string modCompletare, string cod, int angajatorID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfCarneteTipuriCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ModCompletare", SqlDbType.NVarChar, 128, modCompletare));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.NVarChar, 32, cod));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, angajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CompletareCarnetTipID", SqlDbType.Int, 4, completareCarnetTipID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrTipuri", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return int.Parse(myCommand.Parameters[4].Value.ToString()) == 0;
		}*/
	}
}
