using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

using SiemensTM.utils;

namespace SiemensTM.Classes
{
	/// <summary>
	/// Summary description for IntervaleIntreruperiAngajat.
	/// </summary>
	public class IntervaleIntreruperiAngajat
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
		public IntervaleIntreruperiAngajat( long _AngajatID)
		{
			this.AngajatID = _AngajatID;
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			m_con = new SqlConnection(settings.ConnectionString);
		}
		#endregion

		#region InsertIntervalIntreruperiAngajat
		/// <summary>
		/// Procedura adauga un interval de intrerupere
		/// </summary>
		/// <param name="DataStart">Data de inceput</param>
		/// <param name="DataEnd">Data de sfarsit</param>
		/// <param name="Descriere">Descrierea</param>
		public void InsertIntervalIntreruperiAngajat( DateTime DataStart, DateTime DataEnd, string Descriere )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteAngajatIntreruperi", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatIntrerupereID", SqlDbType.Int, 4, -1));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, DataStart));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, DataEnd));				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NText, 16, Descriere));

				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();
			}
			catch{}
		}
		#endregion
	
		#region UpdateIntervalIntreruperiAngajat
		/// <summary>
		/// Procedura actualizeaza un interval de intrerupere
		/// </summary>
		/// <param name="AngajatIntrerupereID">Id-ul intreruperii</param>
		/// <param name="DataStart">Data de inceput</param>
		/// <param name="DataEnd">Data de sfarsit</param>
		/// <param name="Descriere">Descrierea</param>
		public void UpdateIntervalIntreruperiAngajat( int AngajatIntrerupereID, DateTime DataStart, DateTime DataEnd, string Descriere )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteAngajatIntreruperi", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatIntrerupereID", SqlDbType.Int, 4, AngajatIntrerupereID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, DataStart));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, DataEnd));				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NText, 16, Descriere));

				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();
			}
			catch{}
		}
		#endregion
	
		#region DeleteIntervalIntreruperiAngajat
		/// <summary>
		/// Sterge un interval de intrerupere
		/// </summary>
		/// <param name="AngajatIntrerupereID">Id-ul intreruperii</param>
		public void DeleteIntervalIntreruperiAngajat( int AngajatIntrerupereID )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteAngajatIntreruperi", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatIntrerupereID", SqlDbType.Int, 4, AngajatIntrerupereID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, DateTime.Now));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, DateTime.Now));				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NText, 16, ""));

				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();
			}
			catch{}
		}
		#endregion

		#region GetIntervaleIntreruperiAngajatLuna
		/// <summary>
		/// Procedura selecteaza intervalele de intrerupere
		/// </summary>
		/// <param name="Data">Data</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIntervaleIntreruperiAngajatLuna(DateTime Data)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("GetIntervaleAngajatIntreruperiLuna", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataCurenta", SqlDbType.DateTime, 8, Data ));

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

		#region LoadIntreruperiCIM
		/// <summary>
		/// Procedura selecteaza intervalele de intrerupere
		/// </summary>
		/// <param name="Data">Data</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadIntreruperiCIM()
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("GetIntervaleIntreruperiAngajat", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
			
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

		#region GetIntervalIntreruperiAngajatByID
		/// <summary>
		/// Procedura selecteaza un interval de intrerupere
		/// </summary>
		/// <param name="IntrerupereID">Id-ul intervalului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIntervalIntreruperiAngajatByID( int IntrerupereID )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("GetIntervalAngajatIntrerupereByID", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntrerupereID", SqlDbType.Int, 4, IntrerupereID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				
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

		#region IntersectieCuIntervaleExistente
		/// <summary>
		/// 0 - Poate fi introdus; 1 - DataStart e inclusa in alt interval; 2 - DataEnd e inclusa in alt interval;
		/// 3 - DataStart si DataEnd sunt incluse in alte intervale; 4 - Intervalul introdus contine un interval existent;
		/// 5 - Intervalul introdus contine zile pontate ca fiind lucrate; 
		/// 6 - DataStart e inclusa in alt interval de intreruperi; 7 - DataEnd e inclusa in alt interval de intreruperi;
		/// 8 - DataStart si DataEnd sunt incluse in alte intervale de intreruperi; 9 - Intervalul introdus contine un interval de intreruperi existent
		/// </summary>
		/// <param name="DataStart">Data de inceput</param>
		/// <param name="DataEnd">Data de sfarsit</param>
		/// <param name="IntervalID">Id-ul intervalului</param>
		/// <returns>Returneaza rezultatul verufucaruu</returns>
		public int IntersectieCuIntervaleExistente( DateTime DataStart, DateTime DataEnd, int IntervalID )
		{
			try
			{
				//Modificat:	Oprescu Claudia
				//Data:			27.07.2007
				//Descriere:	A fost adaugata verificarea pentru data de inceput si de sfarst astfel incat sa nu fie inversate
				//				S-a modificat ordinea de verificare a intervalelor.
				//				Initial se verificau in ordinea Absente, LucrarePerioada si apoi Intreruperi.
				//				Ordinea actuala este Intreruperi, Absente si LucratePerioada.
				if (DataStart > DataEnd)
				{
					return 10;
				}

				SqlCommand myCommand = new SqlCommand("GetIntervaleAngajatIntreruperi", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalID", SqlDbType.Int, 4, IntervalID ));
				
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);

				int poateStart = 0, poateEnd = 0;

				foreach( DataRow dr in ds.Tables[ 0 ].Rows )
				{
					if( DataStart <= (DateTime)dr[ "DataStart" ] && (DateTime)dr[ "DataEnd" ] <= DataEnd )
					{
						return 9;
					}
					if((DateTime)dr[ "DataStart" ] <= DataStart && DataStart <= (DateTime)dr[ "DataEnd" ] )
					{
						poateStart = 1;
					}
					if( (DateTime)dr[ "DataStart" ] <= DataEnd && DataEnd <= (DateTime)dr[ "DataEnd" ] )
					{
						poateEnd = 1;
					}
					if( poateStart == 1 && poateEnd == 1 )
					{
						return 8;
					}
				}
				if( poateStart == 1 )
				{
					return 6;
				}
				else if( poateEnd == 1 )
				{
					return 7;
				}

				myCommand = new SqlCommand("tm_GetIntervaleAbsenta", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalID", SqlDbType.Int, 4, -1 ));
				
				ds = new DataSet();
				dAdapt.Fill(ds);

				foreach( DataRow dr in ds.Tables[ 0 ].Rows )
				{
					if( DataStart <= (DateTime)dr[ "DataStart" ] && (DateTime)dr[ "DataEnd" ] <= DataEnd )
					{
						return 4;
					}
					if((DateTime)dr[ "DataStart" ] <= DataStart && DataStart <= (DateTime)dr[ "DataEnd" ] )
					{
						poateStart = 1;
					}
					if( (DateTime)dr[ "DataStart" ] <= DataEnd && DataEnd <= (DateTime)dr[ "DataEnd" ] )
					{
						poateEnd = 1;
					}
					if( poateStart == 1 && poateEnd == 1 )
					{
						return 3;
					}
				}
				if( poateStart == 1 )
				{
					return 1;
				}
				else if( poateEnd == 1 )
				{
					return 2;
				}

                myCommand = new SqlCommand("tm_GetIntervaleLucratePerioada", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, DataStart ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, DataEnd ));
				
				ds = new DataSet();
				dAdapt.Fill(ds);

				if( ds.Tables[ 0 ].Rows.Count>0 )
				{
					return 5;
				}

				return 0;
			}
			catch
			{
				return -1;
			}
		}
		#endregion
	}
}
