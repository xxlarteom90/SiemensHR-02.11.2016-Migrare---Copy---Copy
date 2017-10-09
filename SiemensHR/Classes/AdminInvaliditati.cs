using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SiemensHR.utils;

namespace SiemensHR.Classes
{

	public struct Invaliditate
	{
		/*public int InvaliditateID;
		public string Nume;
		public float Coeficient;
		public string Descriere;*/
	}

	/// <summary>
	/// Summary description for AdminInvaliditati.
	/// </summary>
	public class AdminInvaliditati
	{
		/*private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;

		public AdminInvaliditati()
		{
			LoadInfoInvaliditati();
		}

		private void LoadInfoInvaliditati()
		{

			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("spGetAllInvaliditati", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		#region Static Methods

		static public void InsertInvaliditate( Invaliditate newInvaliditate )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteInvaliditate", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@InvaliditateID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, newInvaliditate.Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Coeficient", SqlDbType.Float, 8, newInvaliditate.Coeficient));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, newInvaliditate.Descriere));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void UpdateInvaliditate( Invaliditate invalidData )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteInvaliditate", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@InvaliditateID", SqlDbType.Int, 4, invalidData.InvaliditateID ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, invalidData.Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Coeficient", SqlDbType.Float, 8, invalidData.Coeficient));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, invalidData.Descriere));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void DeleteInvaliditate( int InvaliditateID )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteInvaliditate", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@InvaliditateID", SqlDbType.Int, 4, InvaliditateID ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Coeficient", SqlDbType.Float, 8, 0 ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 255, ""));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public Invaliditate GetInvaliditateInfo( int InvaliditateID )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetInvaliditate", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@InvaliditateID", SqlDbType.Int, 4, InvaliditateID ));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for InvaliditateID=" +  InvaliditateID.ToString());
			else
			{
				Invaliditate infoInvaliditate;
				infoInvaliditate.InvaliditateID = InvaliditateID;
				infoInvaliditate.Nume = ds.Tables[0].Rows[0]["Nume"].ToString();
				infoInvaliditate.Coeficient = float.Parse( ds.Tables[0].Rows[0]["Coeficient"].ToString());
				infoInvaliditate.Descriere = ds.Tables[0].Rows[0]["Descriere"].ToString();
				
				return infoInvaliditate;
			}
		}

		/// <summary>
		/// Procedura verifica daca o invaliditate poate fi stearsa, adica nu exista inregistrari in tabela AngajatPersoaneInIntretinere si tm_IntervaleAngajat
		/// </summary>
		/// <param name="invaliditateID">Id-ul invaliditatii care se verifica</param>
		/// <returns>Returneaza true daca se poate face stergerea si false altfel</returns>
		static public int CheckIfInvaliditateCanBeDeleted(int invaliditateID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfInvaliditateCanBeDeleted", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@InvaliditateID", SqlDbType.Int, 4, invaliditateID));
			myCommand.Parameters.Add(new SqlParameter("@Raspuns", SqlDbType.Int, 4));
			myCommand.Parameters[1].Direction = ParameterDirection.ReturnValue;
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return int.Parse(myCommand.Parameters[1].Value.ToString());
		}

		/// <summary>
		/// Procedura verifica daca mai exista in baza de date o invaliditate cu aceleasi date
		/// </summary>
		/// <param name="invaliditateID">Id-ul invaliditatii care se verifica</param>
		/// <param name="nume">Numele invaliditatii</param>
		/// <param name="coeficient">Coeficientul invaliditatii</param>
		/// <returns>Returneaza true daca se poate face modificarea si false altfel</returns>
		static public bool CheckIfInvaliditateCanBeAdded(int invaliditateID, string nume, float coeficient)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfInvaliditateCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Coeficient", SqlDbType.Float, 5, coeficient));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@InvaliditateID", SqlDbType.Int, 4, invaliditateID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrInvaliditati", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[3].Value.ToString()) == 0;
		}
		#endregion

		#region Properties
		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}
		#endregion*/
	}
}
