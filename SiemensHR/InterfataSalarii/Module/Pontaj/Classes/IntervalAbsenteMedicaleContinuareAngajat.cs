using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

using SiemensTM.utils;

namespace SiemensTM.Classes
{
	/// <summary>
	/// Summary description for IntervalAbsenteMedicaleContinuareAngajat.
	/// </summary>
	public class IntervalAbsenteMedicaleContinuareAngajat
	{
		#region Variabile
		private SqlConnection m_con;
		private int AbsentaID;
		private Salaries.Configuration.ModuleSettings settings;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="_AbsentaID"></param>
		public IntervalAbsenteMedicaleContinuareAngajat( int _AbsentaID )
		{
			this.AbsentaID = _AbsentaID;
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			m_con = new SqlConnection(settings.ConnectionString);
		}
		#endregion

		#region InsertIntervalAbsenteMedicaleContinuare
		/// <summary>
		/// Procedura adauga un interval de absenta medicala
		/// </summary>
		/// <param name="DataStart">Data de inceput</param>
		/// <param name="DataEnd">Data de sfarsit</param>
		/// <param name="Observatii">Observatii</param>
		/// <param name="boalaID">Id-ul bolii</param>
		public void InsertIntervalAbsenteMedicaleContinuare( DateTime DataStart, DateTime DataEnd, string Observatii, int boalaID )
		{
			SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteIntervalAbsentaMedicalaContinuare", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0 ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AbsentaContinuareID", SqlDbType.Int, 4, -1 ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AbsentaID", SqlDbType.Int, 4, this.AbsentaID ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, DataStart ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, DataEnd ));				
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Observatii", SqlDbType.NText, 16, Observatii ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BoalaID", SqlDbType.Int, 4, boalaID ));

			m_con.Open();
			myCommand.ExecuteNonQuery();
			m_con.Close();
		}
		#endregion
	
		#region UpdateIntervalAbsenteMedicaleContinuare
		/// <summary>
		/// Procedura actualizeaza un tip de absenta medicala
		/// </summary>
		/// <param name="AbsentaContinuareID">Id-ul absentei medicale</param>
		/// <param name="DataStart">Data de inceput</param>
		/// <param name="DataEnd">Data de sfarsit</param>
		/// <param name="Observatii">Observatii</param>
		/// <param name="boalaID">Id-ul bolii</param>
		public void UpdateIntervalAbsenteMedicaleContinuare( int AbsentaContinuareID, DateTime DataStart, DateTime DataEnd, string Observatii, int boalaID )
		{	
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteIntervalAbsentaMedicalaContinuare", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AbsentaContinuareID", SqlDbType.Int, 4, AbsentaContinuareID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AbsentaID", SqlDbType.Int, 4, this.AbsentaID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, DataStart ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, DataEnd ));				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Observatii", SqlDbType.NText, 16, Observatii ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BoalaID", SqlDbType.Int, 4, boalaID ));

				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();			
			}
			catch{}
		}
		#endregion
	
		#region DeleteIntervalAbsenteMedicaleContinuare
		/// <summary>
		/// Procedura sterge un interval de absenta medicala
		/// </summary>
		/// <param name="AbsentaContinuareID">Id-ul absentei care se sterge</param>
		public void DeleteIntervalAbsenteMedicaleContinuare( int AbsentaContinuareID )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteIntervalAbsentaMedicalaContinuare", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AbsentaContinuareID", SqlDbType.Int, 4, AbsentaContinuareID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AbsentaID", SqlDbType.Int, 4, -1 ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, DateTime.Now ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, DateTime.Now ));				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Observatii", SqlDbType.NText, 16, "" ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BoalaID", SqlDbType.Int, 4, -1 ));

				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();			
			}
			catch{}
		}
		#endregion
	
		#region GetIntervaleAbsentaMedicaleContinuare
		/// <summary>
		/// Procedura selecteaza intervalele de absenta medicale continuare de concediu medical
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIntervaleAbsentaMedicaleContinuare()
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetIntervaleAbsentaMedicalaContinuare", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AbsentaID", SqlDbType.Int, 4, this.AbsentaID ));
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
	}
}
