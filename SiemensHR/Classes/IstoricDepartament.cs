using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for IstoricDepartament.
	/// </summary>
	public class IstoricDepartament
	{
		/*private DataSet m_ds;
		private long m_AngajatID;
		protected Salaries.Configuration.ModuleSettings settings;

		public IstoricDepartament(long AngajatID)
		{
			//
			// TODO: Add constructor logic here
			//
			m_AngajatID = AngajatID;
			LoadIstoricDepartament();
		}

		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		private void LoadIstoricDepartament()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetIstoricDepartamenteAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		public int GetNumberOfDeparments()
		{
			return m_ds.Tables[0].Rows.Count;
		}

		public string GetCodOfDeparment(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return m_ds.Tables[0].Rows[RowIndex]["Cod"].ToString();
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfDeparments().ToString());
		}

		public string GetNameOfDeparment(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return m_ds.Tables[0].Rows[RowIndex]["Denumire"].ToString();
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfDeparments().ToString());
		}

		public int GetIDOfDeparment(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return Convert.ToInt32(m_ds.Tables[0].Rows[RowIndex]["DepartamentID"]);
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfDeparments().ToString());
		}

		public string GetDataStartOfDeparment(int RowIndex)
		{
			if (RowIndex < m_ds.Tables[0].Rows.Count)
				return Utilities.ConvertDateTime2Text(Convert.ToDateTime(m_ds.Tables[0].Rows[RowIndex]["DataStart"]));
			else
				throw new Exception("Requested index is out of range!<br>Index requested:" + RowIndex.ToString() + "<br>No. rows:" + GetNumberOfDeparments().ToString());
		}


		public void InsertDepartament(int departamentID, DateTime dataStart)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricDepartament", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DepartamentID", SqlDbType.Int, 4, departamentID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart.ToShortDateString()));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);	

		}

		public void UpdateDepartament(int departamentID, DateTime new_dataStart, DateTime old_dataStart)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricDepartament", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DepartamentID", SqlDbType.Int, 4, departamentID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, new_dataStart.ToShortDateString()));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@old_DataStart", SqlDbType.DateTime, 8, old_dataStart.ToShortDateString()));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);	
		}

		public void DeleteDepartament(int departamentID, DateTime dataStart)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricDepartament", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DepartamentID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart.ToShortDateString()));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);	
		}

		/// <summary>
		/// Procedura verifica daca in tabela IstoricAngajatDepartament mai exista un departament adaugat pentru aceeasi data
		/// </summary>
		/// <param name="angajatId">id-ul angajatului pentru care se cauta inregistrari</param>
		/// <param name="dataStart">data pentru care nu trebuie sa mai existe un angajat adugat</param>
		/// <returns>true daca se poate adauga o noua inregistrare si false altfel</returns>
		public bool CheckIfDepartamentCanBeAdded(long angajatId, DateTime dataStart)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfDepartamentCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 8, angajatId));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrDepartamente", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[2].Value.ToString()) == 0;
		}*/

	}
}
