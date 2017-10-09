using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

using SiemensTM.utils;

namespace SiemensTM.Classes
{
	public struct WeekDates
	{
		public DateTime dataStart;
		public DateTime dataEnd;
	}

	/// <summary>
	/// Summary description for Zile.
	/// </summary>
	public class IntervaleAngajat
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
		public IntervaleAngajat(long _AngajatID)
		{
			this.AngajatID = _AngajatID;
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			m_con = new SqlConnection(settings.ConnectionString);
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="_AngajatID">Id-ul angajatului</param>
		/// <param name="st"></param>
		public IntervaleAngajat(long _AngajatID,Salaries.Configuration.ModuleSettings st)
		{
			this.AngajatID = _AngajatID;
			settings = st;
			m_con = new SqlConnection(settings.ConnectionString);
		}
		#endregion

		#region InsertIntervalAngajat
		/// <summary>
		/// Procedura adauga un interval
		/// </summary>
		/// <param name="Data">Data</param>
		/// <param name="TipIntervalID">Tipul intervalului</param>
		/// <param name="OraStart"></param>
		/// <param name="OraEnd"></param>
		/// <param name="programLucru">Programul de lucru</param>
		/// <param name="salariuBaza">Salariul de baza</param>
		/// <param name="indemnizatieConducere">Indemnizatia de conducere</param>
		/// <param name="invaliditate">Tipul de invaliditate</param>
		/// <param name="categorieID">Tipul de categorie</param>
		public void InsertIntervalAngajat(DateTime Data,int TipIntervalID,DateTime OraStart,DateTime OraEnd, int programLucru, float salariuBaza, float indemnizatieConducere, int invaliditate, int categorieID )
		{
			SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteIntervalAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalAngajatID", SqlDbType.Int, 4, -1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, Data));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipIntervalID", SqlDbType.Int, 4, TipIntervalID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@OraStart", SqlDbType.DateTime, 8, OraStart));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@OraEnd", SqlDbType.DateTime, 8, OraEnd));				
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ProgramLucru", SqlDbType.Int, 4, programLucru));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SalariuBaza", SqlDbType.Money, 8, salariuBaza));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IndemnizatieConducere", SqlDbType.Money, 8, indemnizatieConducere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Invaliditate", SqlDbType.SmallInt, 2, invaliditate));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, categorieID));
			
			m_con.Open();
			myCommand.ExecuteNonQuery();
			m_con.Close();
		}
		#endregion

		#region InsertIntervalAngajatConcediu
		/// <summary>
		/// Procedura adauga un interval de tip concediu
		/// </summary>
		/// <param name="Data">Data</param>
		/// <param name="TipIntervalID">Tipul intervalului</param>
		/// <param name="OraStart"></param>
		/// <param name="OraEnd"></param>
		/// <param name="programLucru">Programul de lucru</param>
		/// <param name="salariuBaza">Salariul de baza</param>
		/// <param name="indemnizatieConducere">Indemnizatia de conducere</param>
		/// <param name="invaliditate">Tipul de invaliditate</param>
		/// <param name="categorieID">Tipul de categorie</param>
		public void InsertIntervalAngajatConcediu(DateTime Data,int TipIntervalID,DateTime OraStart,DateTime OraEnd, int programLucru, float salariuBaza, float indemnizatieConducere, int invaliditate, int categorieID )
		{
			SqlCommand myCommand = new SqlCommand("tm_InsertIntervalAngajatConcediu", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
				
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalAngajatID", SqlDbType.Int, 4, -1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, Data));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipIntervalID", SqlDbType.Int, 4, TipIntervalID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@OraStart", SqlDbType.DateTime, 8, OraStart));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@OraEnd", SqlDbType.DateTime, 8, OraEnd));				
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ProgramLucru", SqlDbType.Int, 4, programLucru));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SalariuBaza", SqlDbType.Money, 8, salariuBaza));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IndemnizatieConducere", SqlDbType.Money, 8, indemnizatieConducere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Invaliditate", SqlDbType.SmallInt, 2, invaliditate));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, categorieID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Deleted", SqlDbType.Bit, 4, true));

			m_con.Open();
			myCommand.ExecuteNonQuery();
			m_con.Close();	
		}
		#endregion
		
		#region UpdateIntervalAngajat
		/// <summary>
		/// Procedura actualizeaza un interval
		/// </summary>
		/// <param name="IntervalAngajatID">Id-ul intervalului</param>
		/// <param name="TipIntervalID">Tipul intervalului</param>
		/// <param name="OraStart"></param>
		/// <param name="OraEnd"></param>
		/// <param name="programLucru">Programul de lucru</param>
		/// <param name="salariuBaza">Salariul de baza</param>
		/// <param name="indemnizatieConducere">Indemnizatia de conducere</param>
		/// <param name="invaliditate">Tipul de invaliditate</param>
		/// <param name="categorieID">Tipul de categorie</param>
		public void UpdateIntervalAngajat(int IntervalAngajatID,int TipIntervalID,DateTime OraStart,DateTime OraEnd, int programLucru, float salariuBaza, float indemnizatieConducere, int invaliditate, int categorieID)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteIntervalAngajat", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalAngajatID", SqlDbType.Int, 4, IntervalAngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipIntervalID", SqlDbType.Int, 4, TipIntervalID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, DateTime.Now));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@OraStart", SqlDbType.DateTime, 8, OraStart));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@OraEnd", SqlDbType.DateTime, 8, OraEnd));				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ProgramLucru", SqlDbType.Int, 4, programLucru));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SalariuBaza", SqlDbType.Money, 8, salariuBaza));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IndemnizatieConducere", SqlDbType.Money, 8, indemnizatieConducere));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Invaliditate", SqlDbType.SmallInt, 2, invaliditate));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, categorieID));

				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();	
			}
			catch
			{}
		}
		#endregion
	
		#region DeleteIntervalAngajat
		/// <summary>
		/// Procedura sterge un interval
		/// </summary>
		/// <param name="IntervalAngajatID">Id-ul intervalului</param>
		public void DeleteIntervalAngajat(int IntervalAngajatID)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteIntervalAngajat", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalAngajatID", SqlDbType.Int, 4, IntervalAngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipIntervalID", SqlDbType.Int, 4, 0));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, DateTime.Now));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@OraStart", SqlDbType.DateTime, 8, DateTime.Now));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@OraEnd", SqlDbType.DateTime, 8, DateTime.Now));				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ProgramLucru", SqlDbType.Int, 4, -1));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SalariuBaza", SqlDbType.Money, 8, 0));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IndemnizatieConducere", SqlDbType.Money, 8, 0));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Invaliditate", SqlDbType.SmallInt, 2, -1));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, -1));
				
				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();
			}
			catch
			{}
		}
		#endregion
	
		#region GetIntervaleAngajatZi
		/// <summary>
		/// Procedura selecteaza intervalele pentru o zi
		/// </summary>
		/// <param name="Data">Data</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIntervaleAngajatZi(DateTime Data)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetIntervaleZi", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, Data));
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

		//Lungu Andreea - 13.11.2008
		#region GetIntervaleAngajat
		/// <summary>
		/// Procedura selecteaza intervalele pentru o zi
		/// </summary>
		/// <param name="Data">Data</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIntervaleAngajat(DateTime Data)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetIntervale", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, Data));
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

		#region GetTipuriIntervaleOreSuplimentare
		/// <summary>
		/// Procedura selecteaza tipurile de intervale ore suplimentare
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipuriIntervaleOreSuplimentare()
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetTipuriIntervaleSuplimentare", m_con);
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

		#region GetIntervaleTipAngajatZi
		/// <summary>
		/// Procedura selecteaza intervalele de un anumit tip dintr-o zi
		/// </summary>
		/// <param name="Data">Data</param>
		/// <param name="TipIntervalID">Id-ul tipului de interval</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIntervaleTipAngajatZi(DateTime Data,int TipIntervalID)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetIntervaleZi", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, Data));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipIntervalID", SqlDbType.Int, 4, TipIntervalID));
				
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

		#region GetIntervaleIntersectieAbsente
		/// <summary>
		/// Procedura selecteaza intervalele de absente care se intersecteaza
		/// </summary>
		/// <param name="Data">Data curenta</param>
		/// <returns>Returneaza rezultatul verificarii</returns>
		public int GetIntervaleIntersectieAbsente( DateTime Data )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand( "tm_GetIntervaleAbsentaLuna", m_con );
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				//myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Luna", SqlDbType.Int, 4, Data.Month ));
				//myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@An", SqlDbType.Int, 4, Data.Year ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataCurenta", SqlDbType.DateTime, 8, Data ));
				
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				
				foreach( DataRow dr in ds.Tables[ 0 ].Rows )
				{
					if((DateTime)dr[ "DataStart" ]<=Data && Data<=(DateTime)dr[ "DataEnd" ] )
					{
						return 1;
					}
				}

				myCommand = new SqlCommand("GetIntervaleAngajatIntreruperi", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalID", SqlDbType.Int, 4, -1 ));
				
				ds = new DataSet();
				dAdapt.Fill(ds);

				foreach( DataRow dr in ds.Tables[ 0 ].Rows )
				{
					//if(( DataStart < (DateTime)dr[ "DataStart" ] && (DateTime)dr[ "DataEnd" ] < DataEnd ) || ( DataStart < (DateTime)dr[ "DataEnd" ] && (DateTime)dr[ "DataEnd" ] < DataEnd ))
					if((DateTime)dr[ "DataStart" ]<=Data && Data<=(DateTime)dr[ "DataEnd" ] )
					{
						return 2;
					}
				}
				return 0;
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region GetNrOreLucrateSaptamanaByDataInside
		/// <summary>
		/// Returneaza nr de ore pontate ca fiind lucrate intr-o saptamana de un anumit tip
		/// </summary>
		/// <param name="dataInside">Data</param>
		/// <param name="tipOraID">Tipul de ore</param>
		/// <returns>Returneaza nr de ore lucrate</returns>
		public double GetNrOreLucrateSaptamanaByDataInside( DateTime dataInside, int tipOraID )
		{
			try
			{
				WeekDates week = GetDatesOfWeekByDataInside( dataInside );
				return GetNrOreLucratePerioadaTip( week.dataStart, week.dataEnd, tipOraID );				
			}
			catch
			{
				return 0;
			}
		}
		#endregion

		#region GetNrOreLucratePerioadaTip
		/// <summary>
		/// Procedura selecteaza nr de ore lucrate pe o perioada de timp
		/// </summary>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <param name="tipOraID">Tipul orelor lucrate</param>
		/// <returns>Returneaza nr de ore lucrate</returns>
		public double GetNrOreLucratePerioadaTip( DateTime dataStart, DateTime dataEnd, int tipOraID )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand( "tm_GetNrOreTipPerioada", m_con );
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, dataEnd ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipOre", SqlDbType.Int, 4, tipOraID ));

				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				return ( double.Parse( ds.Tables[ 0 ].Rows[ 0 ][ "NrMinute" ].ToString()))/60;
			}
			catch
			{
				return 0;
			}
		}
		#endregion

		#region GetNrOreLucrateSaptamanaByDataInsideFaraIntervalCurent
		/// <summary>
		/// Returneaza nr de ore pontate ca fiind lucrate intr-o saptamana de un anumit tip, dar fara intervalul curent
		/// </summary>
		/// <param name="intervalID"></param>
		/// <param name="dataInside"></param>
		/// <param name="oraStart"></param>
		/// <param name="oraEnd"></param>
		/// <param name="tipOraID"></param>
		/// <returns></returns>
		public double GetNrOreLucrateSaptamanaByDataInsideFaraIntervalCurent( int intervalID, DateTime dataInside, DateTime oraStart, DateTime oraEnd, int tipOraID )
		{
			try
			{
				WeekDates week = GetDatesOfWeekByDataInside( dataInside );

				SqlCommand myCommand = new SqlCommand( "tm_GetNrOreTipPerioadaFaraInterval", m_con );
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, week.dataStart ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, week.dataEnd ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipOre", SqlDbType.Int, 4, tipOraID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalID", SqlDbType.Int, 4, intervalID ));

				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				
				double dd = ( double.Parse( ds.Tables[ 0 ].Rows[ 0 ][ "NrMinute" ].ToString()))/60;
				return ( double.Parse( ds.Tables[ 0 ].Rows[ 0 ][ "NrMinute" ].ToString()))/60;
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region GetDatesOfWeekByDataInside
		/// <summary>
		/// Returneaza data de inceput si data de sfarsit a saptamanii care contine "dataInside"
		/// </summary>
		/// <param name="dataInside"></param>
		/// <returns></returns>
		private WeekDates GetDatesOfWeekByDataInside( DateTime dataInside )
		{
			string dayOfWeek = dataInside.DayOfWeek.ToString();
			int dayNo = 0;
			switch( dayOfWeek )
			{
				case "Monday":
					dayNo = 1;
					break;
				case "Tuesday":
					dayNo = 2;
					break;
				case "Wednesday":
					dayNo = 3;
					break;
				case "Thursday":
					dayNo = 4;
					break;
				case "Friday":
					dayNo = 5;
					break;
				case "Saturday":
					dayNo = 6;
					break;
				case "Sunday":
					dayNo = 7;
					break;
				default:
					break;
			}

			WeekDates week = new WeekDates();
			week.dataStart = new DateTime( dataInside.Year, dataInside.Month, dataInside.Day );
			week.dataStart = week.dataStart.AddDays( -( dayNo-1 ));
			week.dataEnd = new DateTime( dataInside.Year, dataInside.Month, dataInside.Day );
			week.dataEnd = week.dataEnd.AddDays( 7-dayNo );
			return week;
		}
		#endregion

		#region GetTipIntervalStandard
		/// <summary>
		/// Returneaza id-ul intervalului setat ca fiind standard; 
		/// daca nu exista un astfel de interval, se selecteaza primul tip de interval din baza de date
		/// </summary>
		/// <returns></returns>
		public int GetTipIntervalStandard()
		{
			try
			{
				SqlCommand myCommand = new SqlCommand( "tm_GetTipuriIntervale", m_con );
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				
				foreach( DataRow dr in ds.Tables[ 0 ].Rows )
				{
					if((bool)dr[ "Standard" ] )
					{
						return int.Parse( dr[ "TipIntervalID" ].ToString());
					}
				}
				return int.Parse(ds.Tables[ 0 ].Rows[ 0 ][ "TipIntervalID" ].ToString());
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region InitializeOreLucrateLunaAngajat
		/// <summary>
		/// Metoda de initializare (completare automata) a orelor lucrate intr-o luna
		/// </summary>
		/// <param name="SelectedDate"></param>
		/// <param name="DataInceput"></param>
		/// <param name="DataExpirare"></param>
		/// <returns></returns>
		public bool InitializeOreLucrateLunaAngajat( DateTime SelectedDate, DateTime DataInceput, object DataExpirare )
		{
			bool valReturn = false;
			Zile z = new Zile(settings);
			DataSet ds, dsIntreruperi;

			if( (DataExpirare == System.DBNull.Value) || (DateTime.Equals(DataExpirare,DateTime.MinValue)))
			{
				ds = z.GetLunaAngajat( SelectedDate.Year, SelectedDate.Month, DataInceput );
			}
			else
			{
				ds = z.GetZileLunaExpirareContract( SelectedDate.Year, SelectedDate.Month, DataInceput, (DateTime)DataExpirare );
			}
			
			dsIntreruperi = GetZileIntreruperiLuna( SelectedDate );
			//Lungu Andreea - 10.11.2008
			//----------------------------------------------------------------------------------------------------//
			if (dsIntreruperi != null)
			{
				foreach(DataRow dr in dsIntreruperi.Tables[0].Rows)
				{
					int tipIntervalID = GetTipIntervalStandard();
					DateTime data = Utilities.ConvertToShort( (DateTime)dr[ "Data" ] );

					Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
					angajat.AngajatId = AngajatID;
					int normaLucru = angajat.GetNormaAngajat();
					DateTime oraStart = Utilities.DateFromOra( data, Definitions.OraStandardDeInitializareLucruString );
					DateTime oraTmp = oraStart;
					oraTmp = oraTmp.AddHours( normaLucru );
					DateTime oraEnd = Utilities.DateFromOra( data, oraTmp.Hour.ToString()+":"+oraTmp.Minute.ToString());

					Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
					ang.AngajatId = AngajatID;
					ang.LoadAngajat();

					if( normaLucru > 0 )
					{
						DataSet dsInterv = GetIntervaleAngajat((DateTime)dr[ "Data" ]);
						if (dsInterv!=null && dsInterv.Tables[0].Rows.Count!=0)
						{
							foreach (DataRow drInt in dsInterv.Tables[0].Rows)
							{
								if ((bool)drInt["Sarbatoare"])
									DeleteIntervalAngajat(Int32.Parse(drInt["IntervalAngajatID"].ToString()));
								else
									UpdateIntervalAngajat(Int32.Parse(drInt["IntervalAngajatID"].ToString()),Int32.Parse(drInt["TipIntervalID"].ToString()), oraStart, oraEnd, ang.ProgramLucru, (float)ang.SalariuBaza, (float)ang.IndemnizatieConducere, ang.Invaliditate, ang.CategorieId );
							}
						}
						else
						{
							bool eSarbatoare = false;
							foreach( DataRow drZile in ds.Tables[0].Rows)
								if ((DateTime) drZile["Data"] == (DateTime)dr[ "Data" ])
									eSarbatoare = (bool) drZile["Sarbatoare"];
							if (!eSarbatoare)
							{
								InsertIntervalAngajat((DateTime)dr[ "Data" ], tipIntervalID, oraStart, oraEnd, ang.ProgramLucru, (float)ang.SalariuBaza, (float)ang.IndemnizatieConducere, ang.Invaliditate, ang.CategorieId );
								new IntervaleAngajat( this.AngajatID ).DeleteTemporarIntervaleAngajatPerioada( (DateTime)dr["Data"], (DateTime)dr["Data"], false );
							}
						}
					}
				}
			}
			//----------------------------------------------------------------------------------------------------//
			GetZileLunaPosibileTotal( ds, dsIntreruperi );
			
			foreach( DataRow dr in ds.Tables[ 0 ].Rows )
			{
			
				if(( !(bool)dr[ "Sarbatoare" ] ) && ( !ZiApartineConcediu((DateTime)dr[ "Data" ] )) && ( !ZiApartinePontajLucru((DateTime)dr[ "Data" ] )))
				{
					int tipIntervalID = GetTipIntervalStandard();
					DateTime data = Utilities.ConvertToShort( (DateTime)dr[ "Data" ] );

					Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
					angajat.AngajatId = AngajatID;
					int normaLucru = angajat.GetNormaAngajat();
					DateTime oraStart = Utilities.DateFromOra( data, Definitions.OraStandardDeInitializareLucruString );
					DateTime oraTmp = oraStart;
					oraTmp = oraTmp.AddHours( normaLucru );
					DateTime oraEnd = Utilities.DateFromOra( data, oraTmp.Hour.ToString()+":"+oraTmp.Minute.ToString());

					Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
					ang.AngajatId = AngajatID;
					ang.LoadAngajat();

					if( normaLucru > 0 )
					{
						InsertIntervalAngajat((DateTime)dr[ "Data" ], tipIntervalID, oraStart, oraEnd, ang.ProgramLucru, (float)ang.SalariuBaza, (float)ang.IndemnizatieConducere, ang.Invaliditate, ang.CategorieId );
					}
				}
				else
				{
					if(( !(bool)dr[ "Sarbatoare" ] )&& (ZiApartineConcediu((DateTime)dr[ "Data" ]))&& (!ZiApartinePontaj((DateTime)dr[ "Data" ])))
					{
						int tipIntervalID = GetTipIntervalStandard();
						DateTime data = Utilities.ConvertToShort( (DateTime)dr[ "Data" ] );
						
						Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
						angajat.AngajatId = AngajatID;
						int normaLucru = angajat.GetNormaAngajat();
					
						DateTime oraStart = Utilities.DateFromOra( data, Definitions.OraStandardDeInitializareLucruString );
						DateTime oraTmp = oraStart;
						oraTmp = oraTmp.AddHours( normaLucru );
						DateTime oraEnd = Utilities.DateFromOra( data, oraTmp.Hour.ToString()+":"+oraTmp.Minute.ToString());

						Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
						ang.AngajatId = AngajatID;
						ang.LoadAngajat();

						if( normaLucru > 0 )
						{
							InsertIntervalAngajatConcediu((DateTime)dr[ "Data" ], tipIntervalID, oraStart, oraEnd, ang.ProgramLucru, (float)ang.SalariuBaza, (float)ang.IndemnizatieConducere, ang.Invaliditate, ang.CategorieId );
						}
					}
				}
				
				if (ZiApartineIntrerupere((DateTime)dr["Data"],dsIntreruperi))
				{
					new IntervaleAngajat( this.AngajatID ).DeleteTemporarIntervaleAngajatPerioada( (DateTime)dr["Data"], (DateTime)dr["Data"], false );
				}
			}
			return valReturn;
		}
		#endregion

		#region InitializeOreLucratePerioadaAngajatFromIntervalSchimbare
		/// <summary>
		/// Metoda de initializare (completare automata) a orelor lucrate dintr-un interval
		/// </summary>
		/// <param name="SelectedDate"></param>
		/// <param name="isl"></param>
		/// <returns></returns>
		public bool InitializeOreLucratePerioadaAngajatFromIntervalSchimbare( DateTime SelectedDate, Salaries.Data.IntervaleSchimbariLuna isl )
		{
			bool valReturn = false;
			Zile z = new Zile();
			DataSet ds, dsIntreruperi;

			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.AngajatId = AngajatID;
			ang.LoadAngajat();
			
			if( ang.DataDeLa<=isl.DataStart )
			{
				ds = z.GetZileLunaExpirareContract( SelectedDate.Year, SelectedDate.Month, isl.DataStart, isl.DataEnd.AddDays( 1 ) );
			}
			else
			{
				ds = z.GetZileLunaExpirareContract( SelectedDate.Year, SelectedDate.Month, isl.DataStart, isl.DataEnd.AddDays( 1 ) );
			}

			//Lungu Andreea - 10.11.2008
			dsIntreruperi = GetZileIntreruperiLuna( SelectedDate );
			if (dsIntreruperi != null)
			{
				foreach(DataRow dr in dsIntreruperi.Tables[0].Rows)
				{
					int tipIntervalID = GetTipIntervalStandard();
					DateTime data = Utilities.ConvertToShort( (DateTime)dr[ "Data" ] );

					int normaLucru = isl.ProgramLucru;
					DateTime oraStart = Utilities.DateFromOra( data, Definitions.OraStandardDeInitializareLucruString );
					DateTime oraTmp = oraStart;
					oraTmp = oraTmp.AddHours( normaLucru );
					DateTime oraEnd = Utilities.DateFromOra( data, oraTmp.Hour.ToString()+":"+oraTmp.Minute.ToString());

					if( normaLucru > 0 )
					{
						DataSet dsInterv = GetIntervaleAngajat((DateTime)dr[ "Data" ]);
						if (dsInterv!=null && dsInterv.Tables[0].Rows.Count!=0)
						{
							foreach (DataRow drInt in dsInterv.Tables[0].Rows)
							{
								if ((bool)drInt["Sarbatoare"])
									DeleteIntervalAngajat(Int32.Parse(drInt["IntervalAngajatID"].ToString()));
								else
									UpdateIntervalAngajat(Int32.Parse(drInt["IntervalAngajatID"].ToString()),Int32.Parse(drInt["TipIntervalID"].ToString()), oraStart, oraEnd, isl.ProgramLucru, isl.SalariuBaza, isl.IndemnizatieConducere, isl.Invaliditate, isl.CategorieID );
							}
						}
						else
						{
							bool eSarbatoare = false;
							foreach( DataRow drZile in ds.Tables[0].Rows)
								if ((DateTime) drZile["Data"] == (DateTime)dr[ "Data" ])
									eSarbatoare = (bool) drZile["Sarbatoare"];
							if (!eSarbatoare)
							{
								InsertIntervalAngajat((DateTime)dr[ "Data" ], tipIntervalID, oraStart, oraEnd, isl.ProgramLucru, isl.SalariuBaza, isl.IndemnizatieConducere, isl.Invaliditate, isl.CategorieID );
								new IntervaleAngajat( this.AngajatID ).DeleteTemporarIntervaleAngajatPerioada( (DateTime)dr["Data"], (DateTime)dr["Data"], false );
							}
						}
					}
				}
			}
			GetZileLunaPosibileTotal( ds, dsIntreruperi );

			foreach( DataRow dr in ds.Tables[ 0 ].Rows )
			{
				if(( !(bool)dr[ "Sarbatoare" ] ) && ( !ZiApartineConcediu((DateTime)dr[ "Data" ] )) && ( !ZiApartinePontajLucru((DateTime)dr[ "Data" ] )))
				{
					int tipIntervalID = GetTipIntervalStandard();
					DateTime data = Utilities.ConvertToShort( (DateTime)dr[ "Data" ] );

					int normaLucru = isl.ProgramLucru;
					DateTime oraStart = Utilities.DateFromOra( data, Definitions.OraStandardDeInitializareLucruString );
					DateTime oraTmp = oraStart;
					oraTmp = oraTmp.AddHours( normaLucru );
					DateTime oraEnd = Utilities.DateFromOra( data, oraTmp.Hour.ToString()+":"+oraTmp.Minute.ToString());

					if( normaLucru > 0 )
					{
						InsertIntervalAngajat((DateTime)dr[ "Data" ], tipIntervalID, oraStart, oraEnd, isl.ProgramLucru, isl.SalariuBaza, isl.IndemnizatieConducere, isl.Invaliditate, isl.CategorieID );
					}
				}
				else
				{
					if(( !(bool)dr[ "Sarbatoare" ] )&& (ZiApartineConcediu((DateTime)dr[ "Data" ]))&& (!ZiApartinePontaj((DateTime)dr[ "Data" ])))
					{
						int tipIntervalID = GetTipIntervalStandard();
						DateTime data = Utilities.ConvertToShort( (DateTime)dr[ "Data" ] );

						int normaLucru = isl.ProgramLucru;
						DateTime oraStart = Utilities.DateFromOra( data, Definitions.OraStandardDeInitializareLucruString );
						DateTime oraTmp = oraStart;
						oraTmp = oraTmp.AddHours( normaLucru );
						DateTime oraEnd = Utilities.DateFromOra( data, oraTmp.Hour.ToString()+":"+oraTmp.Minute.ToString());

						if( normaLucru > 0 )
						{
							InsertIntervalAngajatConcediu((DateTime)dr[ "Data" ], tipIntervalID, oraStart, oraEnd, isl.ProgramLucru, isl.SalariuBaza, isl.IndemnizatieConducere, isl.Invaliditate, isl.CategorieID );
						}
					}
				}
			}

			return valReturn;
		}
		#endregion

		#region DeleteIntervaleAngajatPerioada
		/// <summary>
		/// tipuriInterv = 0 - intervalele orare ; = 1 - intervalele orare si capetele de interval
		/// </summary>
		/// <param name="dataStart"></param>
		/// <param name="dataEnd"></param>
		/// <param name="tipuriInterv"></param>
		/// <returns></returns>
		public int DeleteIntervaleAngajatPerioada( DateTime dataStart, DateTime dataEnd, bool tipuriInterv )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_DeleteIntervaleAngajatPerioada", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, dataEnd ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipuriInterv", SqlDbType.Bit, 1, tipuriInterv ));
				
				m_con.Open();
				int affected = myCommand.ExecuteNonQuery();
				m_con.Close();
				return affected;
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region DeleteIntervaleVizibileAngajatPerioada
		/// <summary>
		/// TipuriInterv = 0 - intervalele orare ; = 1 - intervalele orare si capetele de interval
		/// </summary>
		/// <param name="dataStart"></param>
		/// <param name="dataEnd"></param>
		/// <returns></returns>
		public int DeleteIntervaleVizibileAngajatPerioada( DateTime dataStart, DateTime dataEnd )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_DeleteIntervaleVizibileAngajatPerioada", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, dataEnd ));
				
				m_con.Open();
				int affected = myCommand.ExecuteNonQuery();
				m_con.Close();
				return affected;
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region DeleteIntervaleTipAngajatPerioada
		/// <summary>
		/// Procedura sterge intervalele de un anumit tip pe o perioada
		/// </summary>
		/// <param name="dataStart"></param>
		/// <param name="dataEnd"></param>
		/// <param name="tipIntervalID"></param>
		/// <returns></returns>
		public int DeleteIntervaleTipAngajatPerioada( DateTime dataStart, DateTime dataEnd, int tipIntervalID )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_DeleteIntervaleTipAngajatPerioada", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, dataEnd ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipIntervalID", SqlDbType.Int, 4, tipIntervalID ));
				
				m_con.Open();
				int affected = myCommand.ExecuteNonQuery();
				m_con.Close();
				return affected;
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region DeleteTemporarIntervaleAngajatPerioada
		/// <summary>
		/// Procedura sterge intervalele temporare
		/// </summary>
		/// <param name="dataStart"></param>
		/// <param name="dataEnd"></param>
		/// <param name="tipuriInterv"></param>
		/// <returns></returns>
		public int DeleteTemporarIntervaleAngajatPerioada( DateTime dataStart, DateTime dataEnd, bool tipuriInterv )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_DeleteIntervaleAngajatPerioadaTemporar", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, dataEnd ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipuriInterv", SqlDbType.Bit, 1, tipuriInterv ));
				
				m_con.Open();
				int affected = myCommand.ExecuteNonQuery();
				m_con.Close();
				return affected;
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region DeleteDefinitivIntervaleAngajatPerioadaTemporare
		/// <summary>
		/// Procedura sterge definitiv intervalele temporare
		/// </summary>
		/// <returns></returns>
		public int DeleteDefinitivIntervaleAngajatPerioadaTemporare()
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_DeleteDefinitivIntervaleAngajatPerioadaTemporar", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				m_con.Open();
				int affected = myCommand.ExecuteNonQuery();
				m_con.Close();
				return affected;
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region RestoreIntervaleAngajatPerioadaSterseTemporar
		/// <summary>
		/// Procedura restaureaza intervalele temporare
		/// </summary>
		/// <param name="dataStart"></param>
		/// <param name="dataEnd"></param>
		/// <returns></returns>
		public int RestoreIntervaleAngajatPerioadaSterseTemporar( DateTime dataStart, DateTime dataEnd )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_RestoreIntervaleAngajatPerioadaSterseTemporar", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, dataEnd ));
				
				m_con.Open();
				int affected = myCommand.ExecuteNonQuery();
				m_con.Close();
				return affected;
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region ZiApartineConcediu
		/// <summary>
		/// Procedura verifica daca o zi apartine unui concediu
		/// </summary>
		/// <param name="data">Data verificata</param>
		/// <returns></returns>
		private bool ZiApartineConcediu( DateTime data )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand( "tm_GetIntervaleAbsentaZi", m_con );
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataCurenta", SqlDbType.DateTime, 8, data ));

				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				
				if( ds.Tables[ 0 ].Rows.Count > 0 )
				{
					return true;
				}
				return false;
				
			}
			catch
			{
				return true;
			}
		}
		#endregion

		#region ZiApartinePontajLucru
		/// <summary>
		/// Verifica daca ziua "data" contine ore pontate ca fiind lucrate
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private bool ZiApartinePontajLucru( DateTime data )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand( "tm_GetIntervaleZi", m_con );
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, data ));

				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				
				if( ds.Tables[ 0 ].Rows.Count > 0 )
				{
					return true;
				}
				return false;
				
			}
			catch
			{
				return true;
			}
		}
		#endregion

		#region ZiApartinePontaj
		/// <summary>
		/// Returneaza true daca esista o inregistrare introdusa in pontaj pentru aceasta data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private bool ZiApartinePontaj( DateTime data )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand( "tm_GetIntervaleZiPontata", m_con );
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, data ));

				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				
				if( ds.Tables[ 0 ].Rows.Count > 0 )
				{
					return true;
				}
				return false;
			}
			catch
			{
				return true;
			}
		}
		#endregion

		#region ZiApartineIntrerupere
		/// <summary>
		/// Returneaza true daca esista o inregistrare introdusa in pontaj pentru aceasta data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private bool ZiApartineIntrerupere( DateTime data, DataSet dsIntreruperi )
		{
			if (dsIntreruperi!=null)
			{
				bool esteIntrerupere = false;
				foreach(DataRow dr in dsIntreruperi.Tables[0].Rows)
				{
					if (((DateTime) dr["Data"]) == data)
						esteIntrerupere = true;
				}
				return esteIntrerupere;
			}
			else
				return false;
		}
		#endregion

		#region GetZileIntreruperiLuna
		/// <summary>
		/// Procedura selecteaza zilele intreruperi din luna
		/// </summary>
		/// <param name="SelectedDate"></param>
		/// <returns></returns>
		private DataSet GetZileIntreruperiLuna( DateTime SelectedDate )
		{
			try
			{
				DataSet ds = new IntervaleIntreruperiAngajat( AngajatID ).GetIntervaleIntreruperiAngajatLuna( SelectedDate );
				Zile z = new Zile();
				DataSet dsZile = z.GetZileIntrerupereContract( SelectedDate.Year, SelectedDate.Month, (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ], (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ] );
				for( int i=1; i<ds.Tables[ 0 ].Rows.Count; i++ )
				{
					DataRow dr = ds.Tables[ 0 ].Rows[ i ];
					dsZile.Merge( z.GetZileIntrerupereContract( SelectedDate.Year, SelectedDate.Month, (DateTime)dr[ "DataStart" ], (DateTime)dr[ "DataEnd" ] ));
				}
				return dsZile;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetZileLunaPosibileTotal
		/// <summary>
		/// Dataset cu toate zilele din luna in care se poate lucra
		/// </summary>
		/// <param name="dsZilePosibile"></param>
		/// <param name="dsZileIntreruperi"></param>
		/// <returns></returns>
		private DataSet GetZileLunaPosibileTotal( DataSet dsZilePosibile, DataSet dsZileIntreruperi )
		{
			try
			{
				int indiceIntreruperi = 0;
				for( int i=0; i<dsZilePosibile.Tables[ 0 ].Rows.Count; i++ )
				{
					DataRow drPosibil = dsZilePosibile.Tables[ 0 ].Rows[ i ];
					DataRow drImposibil = dsZileIntreruperi.Tables[ 0 ].Rows[ indiceIntreruperi ];
				
					if((DateTime)drPosibil[ "Data" ] == (DateTime)drImposibil[ "Data" ] )
					{
						dsZilePosibile.Tables[ 0 ].Rows.Remove( drPosibil );
						dsZileIntreruperi.Tables[ 0 ].Rows.Remove( drImposibil );
						i--;
					}
				}
				return dsZilePosibile;
			}
			catch
			{
				return null;
			}
		}
		#endregion
		
		#region DistribuieOreSuplimentareTip
		/// <summary>
		/// Algoritmul de distribuire a orelor suplimentare 
		///	return - 0 : distribuire efectuata cu succes
		///		   - 1 : depasirea numarului de ore disponibile
		/// </summary>
		/// <param name="selectedDate"></param>
		/// <param name="tipIntervalID"></param>
		/// <param name="nrOreSuplimentare"></param>
		/// <param name="nrOreSuplimentare_old"></param>
		/// <param name="tipOraSuplimentara"></param>
		/// <returns></returns>
		public int DistribuieOreSuplimentareTip( DateTime selectedDate, int tipIntervalID, double nrOreSuplimentare, double nrOreSuplimentare_old, int tipOraSuplimentara )
		{
			DateTime dataStart = new DateTime( selectedDate.Year, selectedDate.Month, 1 );
			DateTime dataEnd = new DateTime( selectedDate.Year, selectedDate.Month, DateTime.DaysInMonth( selectedDate.Year, selectedDate.Month ));
			//stergerea intervalelor de ore suplimentare existente
			DeleteIntervaleTipAngajatPerioada( dataStart, dataEnd, tipIntervalID );
			int retVal = 0;

			//---------- Algortimul de distribuire ---------------
			switch( tipOraSuplimentara )
			{
				case 0:
					retVal = DistribuieOreSuplimentareInRegimNormal( selectedDate, nrOreSuplimentare, tipIntervalID, nrOreSuplimentare_old );
					break;
				case 1:
					retVal = DistribuieOreSuplimentareInRegimWeekendNoapte( selectedDate, nrOreSuplimentare, tipIntervalID, nrOreSuplimentare_old );
					break;
				default:
					break;
			}
			return retVal;
		}
		#endregion

		#region metode algoritm distribuire ore suplimentare in regim normal

		#region DistribuieOreSuplimentareInRegimNormal
		/// <summary>
		/// algoritmul de distribuire a orelor suplimentare in regim normal (in zilele lucratoare)
		/// return - 0 : distribuire efectuata cu succes
		///		 - 1 : depasirea numarului de ore disponibile
		/// </summary>
		/// <param name="selectedDate"></param>
		/// <param name="nrOreSuplimentare"></param>
		/// <param name="tipIntervalID"></param>
		/// <param name="nrOreSuplimentare_old"></param>
		/// <returns></returns>
		/// <remarks>
		/// Modificat:		Oprescu Claudia
		/// Data:			26.07.2007
		/// Descriere:		Se va calcula medieDistributie numai daca nrZile este o valoare pozitiva.
		/// </remarks>
		public int DistribuieOreSuplimentareInRegimNormal( DateTime selectedDate, double nrOreSuplimentare, int tipIntervalID, double nrOreSuplimentare_old )
		{
			int valRet = 0;
			if( nrOreSuplimentare == 0 )
			{
				return 0;
			}
			//preiau zilele posibile (zile lucratoare - absente)
			int tipIntervalNormalID = GetTipIntervalStandard();
			DateTime dataStart = new DateTime( selectedDate.Year, selectedDate.Month, 1 );
			DateTime dataEnd = new DateTime( selectedDate.Year, selectedDate.Month, DateTime.DaysInMonth( selectedDate.Year, selectedDate.Month ));
			DataSet dsZilePosibile = new Salaries.Business.PontajAngajat( this.AngajatID ).GetAngajatZileOreTipLucrate( dataStart, dataEnd, tipIntervalNormalID );

			//verificare daca numarul orelor posibile pt introducere este mai mare decat cel al orelor suplimentare
			double nrOreDisponibileLuna = 0;
			foreach( DataRow dr in dsZilePosibile.Tables[ 0 ].Rows )
			{
				nrOreDisponibileLuna += GetNrOreSuplimentareInRegimNormalDisponibileZi((DateTime)dr[ "Data" ] );
			}
			if( nrOreDisponibileLuna < nrOreSuplimentare )
			{
				nrOreSuplimentare = nrOreSuplimentare_old;
				valRet = 1;
			}

			//calculez media de distributie
			int nrZile = dsZilePosibile.Tables[ 0 ].Rows.Count;
			double medieDistributie = 0;
			if (nrZile > 0)
			{
				medieDistributie = (double)( nrOreSuplimentare/nrZile );
			}
			else
			{
				medieDistributie = 0;
			}
			double nrOreSuplimentareRest = nrOreSuplimentare%1;
			int nrOreSuplimentareIntreg = Convert.ToInt32( nrOreSuplimentare-nrOreSuplimentareRest );


			int dsIndex = 0;
			//cazul in care nr de ore suplimentare e mai mic decat nr de zile disponibile din luna
			if( medieDistributie<=1 && medieDistributie>0 )
			{
				//distribuirea orelor suplimentare in functie de medie, la primele zile
				int i = 0;
				while( i<nrOreSuplimentareIntreg )
				{
					if( dsIndex==dsZilePosibile.Tables[ 0 ].Rows.Count )
					{
						dsIndex = 0;
					}
					double nrOreDisponibile = GetNrOreSuplimentareInRegimNormalDisponibileZi((DateTime)dsZilePosibile.Tables[ 0 ].Rows[ dsIndex ][ "Data" ] );
					if( nrOreDisponibile>=1 )
					{
						//insert un interval de o ora suplimentara
						GenereazaIntervalOreSuplimentareZiInRegimNormal( (DateTime)dsZilePosibile.Tables[ 0 ].Rows[ dsIndex ][ "Data" ], 1, tipIntervalID );
						i++;
					}
					dsIndex++;
				}
				if( nrOreSuplimentareRest!=0 )
				{
					bool introdus = false;
					while( !introdus )
					{
						if( dsIndex==dsZilePosibile.Tables[ 0 ].Rows.Count )
						{
							dsIndex = 0;
						}
						double nrOreDisponibile = GetNrOreSuplimentareInRegimNormalDisponibileZi((DateTime)dsZilePosibile.Tables[ 0 ].Rows[ dsIndex ][ "Data" ] );
						if( nrOreDisponibile>=nrOreSuplimentareRest )
						{
							introdus = true;
							//insert interval care are "minute" minute la primul care se poate, incepand de la dsIndex
							GenereazaIntervalOreSuplimentareZiInRegimNormal((DateTime)dsZilePosibile.Tables[ 0 ].Rows[ dsIndex ][ "Data" ], nrOreSuplimentareRest, tipIntervalID );
						}
						dsIndex++;
					}
				}
			}
				//cazul in care media e mai mare ca 1
			else
			{
				int medieDistributieIntreg = Convert.ToInt32( medieDistributie-medieDistributie%1 );
				double nrOreRest = nrOreSuplimentareIntreg-medieDistributieIntreg*nrZile;

				//distribuirea partii intregi a mediei la toata luna
				foreach( DataRow dr in dsZilePosibile.Tables[ 0 ].Rows )
				{
					double nrOreDisponibile = GetNrOreSuplimentareInRegimNormalDisponibileZi((DateTime)dr[ "Data" ] );
					if( nrOreDisponibile>=medieDistributieIntreg )
					{
						//insert interval de ore suplimentare
						GenereazaIntervalOreSuplimentareZiInRegimNormal((DateTime)dr[ "Data" ], medieDistributieIntreg, tipIntervalID );
					}
					else
					{
						//insert interval de ore suplimentare de marimea numarului de ore disponibile si adaugarea restului de ore la rest
						nrOreRest += (double)medieDistributieIntreg-nrOreDisponibile;
						//insert iterval de ore
						GenereazaIntervalOreSuplimentareZiInRegimNormal((DateTime)dr[ "Data" ], nrOreDisponibile, tipIntervalID );
					}
				}
				//distribuirea restului la primele zile disponibile din luna
				dsIndex = 0;
				while( nrOreRest>0 )
				{
					if( dsIndex==dsZilePosibile.Tables[ 0 ].Rows.Count )
					{
						dsIndex = 0;
					}
					try
					{
						double nrOreDisponibile = GetNrOreSuplimentareInRegimNormalDisponibileZi((DateTime)dsZilePosibile.Tables[ 0 ].Rows[ dsIndex ][ "Data" ] );
						//--insert interval orar
						if( nrOreDisponibile>nrOreRest )
						{
							GenereazaIntervalOreSuplimentareZiInRegimNormal((DateTime)dsZilePosibile.Tables[ 0 ].Rows[ dsIndex ][ "Data" ], nrOreRest, tipIntervalID );
							nrOreRest = 0;
						}
						else
						{
							GenereazaIntervalOreSuplimentareZiInRegimNormal((DateTime)dsZilePosibile.Tables[ 0 ].Rows[ dsIndex ][ "Data" ], nrOreDisponibile, tipIntervalID );
							nrOreRest -= nrOreDisponibile;
						}
					}
					catch{}

					dsIndex++;
				}
				//distribuirea restului de la orele suplimentare la prima zi disponibila
				if( nrOreSuplimentareRest!=0 )
				{
					//double minute = nrOreSuplimentareRest*60;
					bool introdus = false;
					while( !introdus )
					{
						if( dsIndex==dsZilePosibile.Tables[ 0 ].Rows.Count )
						{
							dsIndex = 0;
						}
						double nrOreDisponibile = GetNrOreSuplimentareInRegimNormalDisponibileZi((DateTime)dsZilePosibile.Tables[ 0 ].Rows[ dsIndex ][ "Data" ] );
						if( nrOreDisponibile>=nrOreSuplimentareRest )
						{
							introdus = true;
							//insert interval care are "minute" minute la primul care se poate, incepand de la dsIndex
							GenereazaIntervalOreSuplimentareZiInRegimNormal((DateTime)dsZilePosibile.Tables[ 0 ].Rows[ dsIndex ][ "Data" ], nrOreSuplimentareRest, tipIntervalID );
						}
						dsIndex++;
					}
				}
			}
			return valRet;
		}
		#endregion

		#region GetNrOreSuplimentareInRegimNormalDisponibileZi
		/// <summary>
		/// Returneaza nr de ore suplimentare disponibile dintr-o zi
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public double GetNrOreSuplimentareInRegimNormalDisponibileZi( DateTime data )
		{
			try
			{
				double nrOreSupl = 0;
				Salaries.Data.IntervalOrar []intervale = new Salaries.Business.PontajAngajat(this.AngajatID ).GetIntervaleLibereZi( Definitions.oraStartZi, Definitions.oraEndZi, data );
				for( int i=0; i<intervale.Length; i++ )
				{
					TimeSpan ts = new TimeSpan( intervale[ i ].OraEnd.Ticks-intervale[ i ].OraStart.Ticks );
					nrOreSupl += ts.Hours+(double)ts.Minutes/60;
				}
				return nrOreSupl;
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region GenereazaIntervalOreSuplimentareZiInRegimNormal
		/// <summary>
		/// Genereaza intervalele orare si le introduce in baza de date
		/// </summary>
		/// <param name="data"></param>
		/// <param name="nrOreSuplimentare"></param>
		/// <param name="tipIntervalID"></param>
		private void GenereazaIntervalOreSuplimentareZiInRegimNormal( DateTime data, double nrOreSuplimentare, int tipIntervalID )
		{
			//preiau datele referitoare la programul de lucru, etc
			int programLucru;
			float salBaza;
			float indemCond;
			int invaliditate;
			int categID;
			DataRow dr = new SituatieAngajat( this.AngajatID ).GetZiApartenentaIntervalDateAngajare( Utilities.ConvertToShort( data ));
			if( dr != null )
			{
				programLucru = int.Parse( dr[ "ProgramLucru" ].ToString());
				salBaza = float.Parse( dr[ "SalariuBaza" ].ToString());
				indemCond = float.Parse( dr[ "IndemnizatieConducere" ].ToString());
				invaliditate = int.Parse( dr[ "Invaliditate" ].ToString());
				categID = int.Parse( dr[ "CategorieID" ].ToString());
			}
			else
			{
				Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
				ang.AngajatId = AngajatID;
				ang.LoadAngajat();

				programLucru = ang.ProgramLucru;
				salBaza = (float)ang.SalariuBaza;
				indemCond = (float)ang.IndemnizatieConducere;
				invaliditate = ang.Invaliditate;
				categID = ang.CategorieId;
			}

			//preiau intervalele libere pt adaugare de ore
			Salaries.Data.IntervalOrar []intervale = new Salaries.Business.PontajAngajat(this.AngajatID ).GetIntervaleLibereZi( Definitions.oraStartZi, Definitions.oraEndZi, data );

			double nrOreSuplimentareRamase = nrOreSuplimentare;

			//algoritmul de adaugare a orelor suplimentare
			if( intervale.Length>0 )
			{

				int i = intervale.Length-1;
				while( nrOreSuplimentareRamase>0 )
				{
					TimeSpan ts = new TimeSpan( intervale[ i ].OraEnd.Ticks-intervale[ i ].OraStart.Ticks );
					double nrOreInterval = ts.Hours+(double)ts.Minutes/60;
					if( nrOreSuplimentareRamase>=nrOreInterval )
					{
						InsertIntervalAngajat( data, tipIntervalID, intervale[ i ].OraStart, intervale[ i ].OraEnd, programLucru, salBaza, indemCond, invaliditate, categID );
						nrOreSuplimentareRamase -= nrOreInterval;
					}
					else
					{
						InsertIntervalAngajat( data, tipIntervalID, intervale[ i ].OraStart, intervale[ i ].OraStart.AddHours( nrOreSuplimentareRamase ), programLucru, salBaza, indemCond, invaliditate, categID );
						nrOreSuplimentareRamase = 0;
					}
					i--;
				}
			}
			else
			{
			}
		}
		#endregion

		#endregion

		#region metode algoritm distribuire ore suplimentare in regim special

		#region DistribuieOreSuplimentareInRegimWeekendNoapte
		/// <summary>
		/// algoritmul de distribuire a orelor suplimentare in regim special (weekend, noapte si zile de sarbatoare)
		/// return - 0 : distribuire efectuata cu succes
		///		 - 1 : depasirea numarului de ore disponibile
		/// </summary>
		/// <param name="selectedDate"></param>
		/// <param name="nrOreSuplimentare"></param>
		/// <param name="tipIntervalID"></param>
		/// <param name="nrOreSuplimentare_old"></param>
		/// <returns></returns>
		public int DistribuieOreSuplimentareInRegimWeekendNoapte( DateTime selectedDate, double nrOreSuplimentare, int tipIntervalID, double nrOreSuplimentare_old )
		{
			int retVal = 0;
			if( nrOreSuplimentare == 0 )
			{
				return 0;
			}

			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.AngajatId = AngajatID;
			ang.LoadAngajat();
			
			//preiau zilele posibile (zile lucratoare noaptea + weeked-uri + sarbatori - absente)
			//int tipIntervalNormalID = new IntervaleAngajat( this.AngajatID ).GetTipIntervalStandard();
			DateTime dataStart = new DateTime( selectedDate.Year, selectedDate.Month, 1 );
			DateTime dataEnd = new DateTime( selectedDate.Year, selectedDate.Month, DateTime.DaysInMonth( selectedDate.Year, selectedDate.Month ));
			Zile z = new Zile();
			DataSet dsZilePosibile = z.GetLunaAngajat( selectedDate.Year ,selectedDate.Month, ang.DataDeLa );
			DataSet dsZileWeekendPosibile = z.GetZileWeekendPosibileLunaAngajat( selectedDate.Year ,selectedDate.Month, ang.DataDeLa, ang.DataPanaLa );
			int tipIntervalNormalID = GetTipIntervalStandard();
			DataSet dsZileLucratoarePosibile = new Salaries.Business.PontajAngajat( this.AngajatID ).GetAngajatZileOreTipLucrate( dataStart, dataEnd, tipIntervalNormalID );

			DataView dvZileWeekend = new DataView( dsZileWeekendPosibile.Tables[ 0 ] );
			FiltreazaZilePosibileWeekend( ref dvZileWeekend, selectedDate );
			DataView dvZileSaptamanaNoapte = new DataView( dsZileLucratoarePosibile.Tables[ 0 ] );

			//verificare daca numarul orelor posibile pt introducere este mai mare decat cel al orelor suplimentare
			double nrOreDisponibileLuna = 0;
			//calculez numar ore posibile weekend-uri si sarbatori
			double nrOrePosibilWeekend = 0;
			double nrOrePosibilSaptamana = 0;
			for( int i=0; i<dvZileWeekend.Count; i++ )
			{
				DataRowView dr = dvZileWeekend[ i ];
				nrOrePosibilWeekend += GetNrOreSuplimentareInRegimSpecialDisponibileZi((DateTime)dr[ "Data" ], (bool)dr[ "Sarbatoare" ] );
			}
			foreach( DataRow dr in dvZileSaptamanaNoapte.Table.Rows )
			{
				nrOrePosibilSaptamana += GetNrOreSuplimentareInRegimSpecialDisponibileZi((DateTime)dr[ "Data" ], false );
			}
			nrOreDisponibileLuna = nrOrePosibilSaptamana+nrOrePosibilWeekend;
			if( nrOreDisponibileLuna < nrOreSuplimentare )
			{
				nrOreSuplimentare = nrOreSuplimentare_old;
				retVal = 1;
			}

			double nrOreRamase = nrOreSuplimentare;
			//distribuie orele suplimentare liniar, in weekend-uri (6-22)
			for( int i=0; i<dvZileWeekend.Count; i++ )
			{
				DataRowView dr = dvZileWeekend[ i ];
				double nrOreDisponibile = GetNrOreSuplimentareInRegimSpecialDisponibileZi((DateTime)dr[ "Data" ], (bool)dr[ "Sarbatoare" ] );
				if( nrOreDisponibile<nrOreRamase )
				{
					GenereazaIntervalOreSuplimentareZiInRegimSpecial((DateTime)dr[ "Data" ], nrOreDisponibile, tipIntervalID, (bool)dr[ "Sarbatoare" ] );
					nrOreRamase -= nrOreDisponibile;
				}
				else
				{
					GenereazaIntervalOreSuplimentareZiInRegimSpecial((DateTime)dr[ "Data" ], nrOreRamase, tipIntervalID, (bool)dr[ "Sarbatoare" ] );
					nrOreRamase = 0;
				}
			}
			//distribuie ore in weekend-uri ==> rest ore suplimentare
			//distribuie rest ore suplimentare in zile lucratoare noaptea (22-24 si in 00-06)
			if( nrOreRamase>0 )
			{
				int dvIndex = 0;
				while( nrOreRamase>0 )
				{
					if( dvZileSaptamanaNoapte.Table.Rows.Count==dvIndex )
					{
						dvIndex = 0;
					}

					double nrOreDisponibile = GetNrOreSuplimentareInRegimSpecialDisponibileZi((DateTime)dvZileSaptamanaNoapte.Table.Rows[ dvIndex ][ "Data" ], false );
					if( nrOreDisponibile<nrOreRamase )
					{
						GenereazaIntervalOreSuplimentareZiInRegimSpecial((DateTime)dvZileSaptamanaNoapte.Table.Rows[ dvIndex ][ "Data" ], nrOreDisponibile, tipIntervalID, false );
						nrOreRamase -= nrOreDisponibile;
					}
					else
					{
						GenereazaIntervalOreSuplimentareZiInRegimSpecial((DateTime)dvZileSaptamanaNoapte.Table.Rows[ dvIndex ][ "Data" ], nrOreRamase, tipIntervalID, false );
						nrOreRamase = 0;
					}
					dvIndex++;
				}
			}
			return retVal;
		}
		#endregion

		#region FiltreazaZilePosibileWeekend
		/// <summary>
		/// Procedura filtreaza zilele posibile de weekend
		/// </summary>
		/// <param name="dvZileWeekend"></param>
		/// <param name="selectedDate"></param>
		public void FiltreazaZilePosibileWeekend( ref DataView dvZileWeekend, DateTime selectedDate )
		{
			string filtruAbsente = "";
			string filtruIntreruperi = "";
			//pt absente
			try
			{
				DataSet ds = new IntervaleAbsenteAngajat( this.AngajatID ).GetIntervaleAbsenteAngajatLuna( Utilities.ConvertToShort( selectedDate ));
				foreach( DataRow dr in ds.Tables[ 0 ].Rows )
				{
					filtruAbsente += "( Data<'"+dr[ "DataStart" ].ToString()+"' or '"+dr[ "DataEnd" ].ToString()+"'<Data ) and ";
				}
				filtruAbsente = filtruAbsente.Substring( 0, filtruAbsente.Length-5 );
			}
			catch{}
			//pt intreruperi
			try
			{
				DataSet ds = new IntervaleIntreruperiAngajat( this.AngajatID ).GetIntervaleIntreruperiAngajatLuna( Utilities.ConvertToShort( selectedDate ));
				foreach( DataRow dr in ds.Tables[ 0 ].Rows )
				{
					filtruIntreruperi += "( Data<'"+dr[ "DataStart" ].ToString()+"' or '"+dr[ "DataEnd" ].ToString()+"'<Data ) and ";
				}
				filtruIntreruperi = filtruIntreruperi.Substring( 0, filtruIntreruperi.Length-5 );
			}
			catch{}
			try
			{
				dvZileWeekend.RowFilter = filtruAbsente=="" ? filtruIntreruperi : filtruIntreruperi=="" ? filtruAbsente : filtruAbsente+" and "+filtruIntreruperi;
			}
			catch{}
		}
		#endregion

		#region GetNrOreSuplimentareInRegimSpecialDisponibileZi
		/// <summary>
		/// Returneaza nr de ore suplimentare disponibile dintr-o zi pt ore suplimentare speciale
		/// </summary>
		/// <param name="data"></param>
		/// <param name="sarbatoare"></param>
		/// <returns></returns>
		public double GetNrOreSuplimentareInRegimSpecialDisponibileZi( DateTime data, bool sarbatoare )
		{
			try
			{
				double nrOreSupl = 0;
				Salaries.Data.IntervalOrar []intervale;
				if( !sarbatoare )
				{
					intervale = new Salaries.Business.PontajAngajat(this.AngajatID ).GetIntervaleLibereZi( Definitions.oraEndZi, Definitions.oraStartZi, data );
				}
				else
				{
					intervale = new Salaries.Business.PontajAngajat(this.AngajatID ).GetIntervaleLibereZi( Definitions.oraStartZi, Definitions.oraEndZi, data );
				}
				for( int i=0; i<intervale.Length; i++ )
				{
					TimeSpan ts = new TimeSpan( intervale[ i ].OraEnd.Ticks-intervale[ i ].OraStart.Ticks );
					nrOreSupl += ts.Hours+(double)ts.Minutes/60;
				}
				return nrOreSupl;
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region GenereazaIntervalOreSuplimentareZiInRegimSpecial
		/// <summary>
		/// Genereaza intervalele de ore suplimentare in regim special
		/// </summary>
		/// <param name="data"></param>
		/// <param name="nrOreSuplimentare"></param>
		/// <param name="tipIntervalID"></param>
		/// <param name="sarbatoare"></param>
		private void GenereazaIntervalOreSuplimentareZiInRegimSpecial( DateTime data, double nrOreSuplimentare, int tipIntervalID, bool sarbatoare )
		{
			//preiau datele referitoare la programul de lucru, etc
			int programLucru;
			float salBaza;
			float indemCond;
			int invaliditate;
			int categID;

			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.AngajatId = AngajatID;
			ang.LoadAngajat();

			programLucru = ang.ProgramLucru;
			salBaza = (float)ang.SalariuBaza;
			indemCond = (float)ang.IndemnizatieConducere;
			invaliditate = ang.Invaliditate;
			categID = ang.CategorieId;

			Salaries.Data.LunaData lunaData = new Salaries.Business.Luni( ang.AngajatorId ).GetLunaActiva();

			Salaries.Business.PontajAngajat pa = new Salaries.Business.PontajAngajat( this.AngajatID );
			Salaries.Data.IntervaleSchimbariLuna []intervSL = pa.GetIntervaleSchimbariLuna( lunaData.LunaId );

			for( int i=0; i<intervSL.Length; i++ )
			{
				if( intervSL[ i ].DataStart<=data && data<=intervSL[ i ].DataEnd )
				{
					programLucru = intervSL[ i ].ProgramLucru;
					salBaza = intervSL[ i ].SalariuBaza;
					indemCond = intervSL[ i ].IndemnizatieConducere;
					invaliditate = intervSL[ i ].Invaliditate;
					categID = intervSL[ i ].CategorieID;
				}
			}

			Salaries.Data.IntervalOrar []intervale;
			if( !sarbatoare )
			{
				intervale = new Salaries.Business.PontajAngajat(this.AngajatID ).GetIntervaleLibereZi( Definitions.oraEndZi, Definitions.oraStartZi, data );
			}
			else
			{
				intervale = new Salaries.Business.PontajAngajat(this.AngajatID ).GetIntervaleLibereZi( Definitions.oraStartZi, Definitions.oraEndZi, data );
			}

			double nrOreSuplimentareRamase = nrOreSuplimentare;

			//algoritmul de adaugare a orelor suplimentare
			if( intervale.Length>0 )
			{

				int i = intervale.Length-1;
				while( nrOreSuplimentareRamase>0 )
				{
					TimeSpan ts = new TimeSpan( intervale[ i ].OraEnd.Ticks-intervale[ i ].OraStart.Ticks );
					double nrOreInterval = ts.Hours+(double)ts.Minutes/60;
					if( nrOreSuplimentareRamase>=nrOreInterval )
					{
						InsertIntervalAngajat( data, tipIntervalID, intervale[ i ].OraStart, intervale[ i ].OraEnd, programLucru, salBaza, indemCond, invaliditate, categID );
						nrOreSuplimentareRamase -= nrOreInterval;
					}
					else
					{
						InsertIntervalAngajat( data, tipIntervalID, intervale[ i ].OraStart, intervale[ i ].OraStart.AddHours( nrOreSuplimentareRamase ), programLucru, salBaza, indemCond, invaliditate, categID );
						nrOreSuplimentareRamase = 0;
					}
					i--;
				}
			}
		}
		#endregion

		#endregion

		#region GetTipIntervalIDByName
		/// <summary>
		/// Procedura determina tipul unui interval dupa denumire
		/// </summary>
		/// <param name="denumireTipOraLucrata"></param>
		/// <returns></returns>
		public int GetTipIntervalIDByName( string denumireTipOraLucrata )
		{
			try
			{
				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				SqlConnection m_con=new SqlConnection(settings.ConnectionString);
				SqlCommand getCommand= new SqlCommand("tm_GetTipuriIntervaleSuplimentare", m_con );
				getCommand.CommandType = CommandType.StoredProcedure;

				SqlDataAdapter dAdapter = new SqlDataAdapter(getCommand);
	
				DataSet ds = new DataSet();
				dAdapter.Fill(ds);

				DataView dv = new DataView( ds.Tables[ 0 ] );
				dv.RowFilter = "Denumire = '"+denumireTipOraLucrata+"'";
				return int.Parse( dv[ 0 ][ "TipIntervalID" ].ToString());
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region GetTipuriIntervaleFolosire
		/// <summary>
		/// Procedura determina tipurile de intervale folosite
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipuriIntervaleFolosire()
		{
			SqlCommand myCommand = new SqlCommand("tm_GetTipuriIntervaleFolosire", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			return ds;
		}
		#endregion

		#region GetTipuriAbsenteMedicale
		/// <summary>
		/// Procedura determina tipurile de absente medicale
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipuriAbsenteMedicale()
		{
			SqlCommand myCommand = new SqlCommand("tm_GetTipuriAbsenteMedicale", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			return ds;
		}
		#endregion
	}
}
