using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

using SiemensTM.utils;

namespace SiemensTM.Classes
{
	/// <summary>
	/// Summary description for Zile.
	/// </summary>
	public class AbsenteAngajat
	{
		#region Variabile
		private SqlConnection m_con;
		private long AngajatID;
		private Salaries.Configuration.ModuleSettings settings;
		#endregion		

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="_AngajatID">Id-ul angajatului</param>
		public AbsenteAngajat(long _AngajatID)
		{
			this.AngajatID=_AngajatID;
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			m_con = new SqlConnection(settings.ConnectionString);
		}
		#endregion
		
		#region InsertAbsentaAngajat
		/// <summary>
		/// Procedura adauga un interval de absenta
		/// </summary>
		/// <param name="Data">Data absentei</param>
		/// <param name="TipAbsentaID">Tipul absentei</param>
		public void InsertAbsentaAngajat(DateTime Data,int TipAbsentaID)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteAbsentaAngajat", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AbsentaAngajatID", SqlDbType.Int, 4, -1));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, Data));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipAbsentaID", SqlDbType.Int, 4, TipAbsentaID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();
			}
			catch{}
		}
		#endregion
	
		#region UpdateAbsentaAngajat
		/// <summary>
		/// Procedura actualizeaza un interval de absenta
		/// </summary>
		/// <param name="AbsentaAngajatID">Id-ul absentei</param>
		/// <param name="TipAbsentaID">Id-ul tipului de absenta</param>
		public void UpdateAbsentaAngajat(int AbsentaAngajatID,int TipAbsentaID)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteAbsentaAngajat", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AbsentaAngajatID", SqlDbType.Int, 4, AbsentaAngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipAbsentaID", SqlDbType.Int, 4, TipAbsentaID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, DateTime.Now));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));			
				
				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();
			}
			catch{}
		}
		#endregion
	
		#region DeleteAbsentaAngajat
		/// <summary>
		/// Procedura sterge o absenta
		/// </summary>
		/// <param name="AbsentaAngajatID">Id-ul absentei</param>
		public void DeleteAbsentaAngajat(int AbsentaAngajatID)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteAbsentaAngajat", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AbsentaAngajatID", SqlDbType.Int, 4, AbsentaAngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipAbsentaID", SqlDbType.Int, 4, 0));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, DateTime.Now));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				
				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();
			}
			catch{}
		}
		#endregion

		#region GetZileLunaTipAbsenta
		/// <summary>
		/// Procedura selecteaza zilele cu un anumit tip de absenta dintr-o luna
		/// </summary>
		/// <param name="An">Anul</param>
		/// <param name="Luna">Luna</param>
		/// <param name="TipAbsentaID">Tipul absentei</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetZileLunaTipAbsenta(int An, int Luna,int TipAbsentaID)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetZileLunaTipAbsenta", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipAbsentaID", SqlDbType.Int, 4, TipAbsentaID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@An", SqlDbType.Int, 4, An));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Luna", SqlDbType.Int, 4, Luna));
				
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				return ds;
			}
			catch
			{
				return null;
			}		
		}
		#endregion

		#region GetAbsenteLuna
		/// <summary>
		/// Procedura selecteaza absentele unei luni
		/// </summary>
		/// <param name="An">Anul</param>
		/// <param name="Luna">Luna</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAbsenteLuna(int An, int Luna)
		{
			SqlCommand myCommand = new SqlCommand("tm_GetAbsenteLuna", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@An", SqlDbType.Int, 4, An));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Luna", SqlDbType.Int, 4, Luna));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);			
			return ds;
		}
		#endregion
	}
}
