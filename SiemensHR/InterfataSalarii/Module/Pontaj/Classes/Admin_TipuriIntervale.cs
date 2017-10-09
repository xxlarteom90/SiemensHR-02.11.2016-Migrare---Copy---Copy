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
	public class TipuriIntervale
	{
		#region Variabile
		private SqlConnection m_con;
		private Salaries.Configuration.ModuleSettings settings;
		#endregion
		
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public TipuriIntervale()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			m_con = new SqlConnection(settings.ConnectionString);
		}
		#endregion
		
		#region InsertTipInterval
		/// <summary>
		/// Procedura adauga un tip de interval
		/// </summary>
		/// <param name="Procent">Procentul</param>
		/// <param name="Denumire">Denumirea</param>
		/// <param name="Descriere">Descrierea</param>
		/// <param name="modificare">Poate fi modificat sau nu</param>
		/// <param name="folosire"></param>
		/// <param name="bonuriMasa">Se acorda bonuri de masa</param>
		/// <param name="aplicWeekendNoapte"></param>
		public void InsertTipInterval(float Procent,string Denumire,string Descriere, bool modificare, bool folosire, bool bonuriMasa, bool aplicWeekendNoapte)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteTipInterval", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipIntervalID", SqlDbType.Int, 4, -1));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Float, 4, Procent)); 
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255, Denumire));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NText, 4000, Descriere));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Modificare", SqlDbType.Bit, 1, modificare));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Folosire", SqlDbType.Bit, 1, folosire));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BonuriMasa", SqlDbType.Bit, 1, bonuriMasa));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AplicWeekendNoapte", SqlDbType.Bit, 1, aplicWeekendNoapte));
				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();
			}
			catch{}
		}
		#endregion
	
		#region UpdateTipInterval
		/// <summary>
		/// Procedura actualizeaza un tip de interval
		/// </summary>
		/// <param name="TipIntervalID">Id-ul tipului de interval</param>
		/// <param name="Procent">Procentul</param>
		/// <param name="Denumire">Denumirea</param>
		/// <param name="Descriere">Descrierea</param>
		/// <param name="modificare">Poate fi modificat sau nu</param>
		/// <param name="folosire"></param>
		/// <param name="bonuriMasa">Se acorda bonuri de masa</param>
		/// <param name="aplicWeekendNoapte"></param>
		public void UpdateTipInterval(int TipIntervalID,float Procent,string Denumire,string Descriere, bool modificare, bool folosire, bool bonuriMasa, bool aplicWeekendNoapte)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteTipInterval", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipIntervalID", SqlDbType.Int, 4, TipIntervalID)); 
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Float, 4, Procent)); 
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255, Denumire));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NText, 4000, Descriere));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Modificare", SqlDbType.Bit, 1, modificare));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Folosire", SqlDbType.Bit, 1, folosire));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BonuriMasa", SqlDbType.Bit, 1, bonuriMasa));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AplicWeekendNoapte", SqlDbType.Bit, 1, aplicWeekendNoapte));
				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();
			}
			catch{}
		}
		#endregion
	
		#region DeleteTipInterval
		/// <summary>
		/// Procedura sterge un tip de interval
		/// </summary>
		/// <param name="TipIntervalID">Id-ul tipului de interval</param>
		public void DeleteTipInterval(int TipIntervalID)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteTipInterval", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipIntervalID", SqlDbType.Int, 4, TipIntervalID)); 
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Float, 4, 0)); 
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255,""));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NText, 4000, ""));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Modificare", SqlDbType.Bit, 1, false));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Folosire", SqlDbType.Bit, 1, false));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BonuriMasa", SqlDbType.Bit, 1, false));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AplicWeekendNoapte", SqlDbType.Bit, 1, false));
				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();
			}
			catch{}
		}
		#endregion
	
		#region GetTipuriIntervale
		/// <summary>
		/// Procedura selecteaza tipurile de intervale
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipuriIntervale()
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetTipuriIntervale", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
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

		#region GetTipInterval
		/// <summary>
		/// Procedura selecteaza un tip de interval
		/// </summary>
		/// <param name="TipIntervalID">Id-ul tipului de interval</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipInterval( int TipIntervalID )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetTipInterval", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter( "@TipIntervalID", SqlDbType.Int, 4, TipIntervalID ));

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
		
		#region GetTipuriIntervaleNestandard
		/// <summary>
		/// Procedura returneaza intervalele de tin nestandard
		/// </summary>
		/// <returns>Retruneaza un data set care contine aceste intervale</returns>
		public DataSet GetTipuriIntervaleNestandard()
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetTipuriIntervaleNestandard", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
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
