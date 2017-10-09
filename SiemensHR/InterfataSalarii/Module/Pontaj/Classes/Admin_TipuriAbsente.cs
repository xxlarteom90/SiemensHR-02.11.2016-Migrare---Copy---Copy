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
	public class TipuriAbsente
	{
		#region Variabile
		private SqlConnection m_con;
		private Salaries.Configuration.ModuleSettings settings;
		#endregion
		
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public TipuriAbsente()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			m_con = new SqlConnection(settings.ConnectionString);
		}
		#endregion

		#region InsertTipAbsenta
		/// <summary>
		/// Procedura adauga un tip de absenta
		/// </summary>
		/// <param name="Procent">Procentul</param>
		/// <param name="Denumire">Denumirea</param>
		/// <param name="Descriere">Descierea</param>
		/// <param name="codAbsenta">Codul absentei</param>
		/// <param name="medical">Absenta medicala sau nu</param>
		/// <param name="modificare">Paote fi nodificata sau nu</param>
		/// <param name="folosire"></param>
		public void InsertTipAbsenta(double Procent,string Denumire,string Descriere, string codAbsenta, bool medical, bool modificare, bool folosire)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteTipAbsenta", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipAbsentaID", SqlDbType.Int, 4, -1));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Real, 4, Procent)); 
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255, Denumire));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NText, 4000, Descriere));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodAbsenta", SqlDbType.NVarChar, 5, codAbsenta));

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Medical", SqlDbType.Bit, 1, medical));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Modificare", SqlDbType.Bit, 1, modificare));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Folosire", SqlDbType.Bit, 1, folosire));
				
				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();				
			}
			catch{}
		}
		#endregion
	
		#region UpdateTipAbsenta
		/// <summary>
		/// Procedura actualizeaza un tip de absenta
		/// </summary>
		/// <param name="TipAbsentaID">Id-ul tipului de absenta</param>
		/// <param name="Procent">Procentul</param>
		/// <param name="Denumire">Denumirea</param>
		/// <param name="Descriere">Descierea</param>
		/// <param name="codAbsenta">Codul absentei</param>
		/// <param name="medical">Absenta medicala sau nu</param>
		/// <param name="modificare">Paote fi nodificata sau nu</param>
		/// <param name="folosire"></param>
		public void UpdateTipAbsenta(int TipAbsentaID,float Procent,string Denumire,string Descriere, string codAbsenta, bool medical, bool modificare, bool folosire)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteTipAbsenta", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipAbsentaID", SqlDbType.Int, 4, TipAbsentaID)); 
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Real, 4, Procent)); 
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255, Denumire));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NText, 4000, Descriere));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodAbsenta", SqlDbType.NVarChar, 5, codAbsenta));

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Medical", SqlDbType.Bit, 1, medical));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Modificare", SqlDbType.Bit, 1, modificare));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Folosire", SqlDbType.Bit, 1, folosire));

				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();
				
			}
			catch{}
		}
		#endregion
	
		#region DeleteTipAbsenta
		/// <summary>
		/// Procedura sterge un tip de absenta
		/// </summary>
		/// <param name="TipAbsentaID">Id-ul tipului de absenta</param>
		public void DeleteTipAbsenta(int TipAbsentaID)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteTipAbsenta", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipAbsentaID", SqlDbType.Int, 4, TipAbsentaID)); 
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Real, 4, 0)); 
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255,""));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NText, 4000, ""));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodAbsenta", SqlDbType.NVarChar, 5, ""));

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Medical", SqlDbType.Bit, 1, false));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Modificare", SqlDbType.Bit, 1, false));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Folosire", SqlDbType.Bit, 1, false));

				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();
				
			}
			catch{}
		}
		#endregion
	
		#region GetTipuriAbsente
		/// <summary>
		/// Procedura selecteaza tipurile de absente
		/// </summary>
		/// <param name="An">Anul</param>
		/// <param name="Luna">Luna</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipuriAbsente(int An, int Luna)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetTipuriAbsente", m_con);
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
