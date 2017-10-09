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
	public class Zile
	{
		#region Variabile	
		private SqlConnection m_con;
		private Salaries.Configuration.ModuleSettings settings;
		#endregion
		
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public Zile()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			m_con = new SqlConnection(settings.ConnectionString);
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="st"></param>
		public Zile(Salaries.Configuration.ModuleSettings st)
		{
			settings=st;
			m_con = new SqlConnection(settings.ConnectionString);
		}
		#endregion

		#region NrZile
		/// <summary>
		/// Procedura determina nr de zile dintr-o luna
		/// </summary>
		/// <param name="An">Anul</param>
		/// <param name="Luna">Luna</param>
		/// <returns>Returneaza nr de zile</returns>
		public int NrZile(int An,int Luna)
		{
			System.Globalization.GregorianCalendar x = new System.Globalization.GregorianCalendar();						
			return x.GetDaysInMonth(An,Luna);
		}
		#endregion

		#region IsWeekEnd
		/// <summary>
		/// Procedura verifica daca o zi este zi de weekend sau nu
		/// </summary>
		/// <param name="dt">Data verificata</param>
		/// <returns>Returneaza true daca data este zi de sarbatoare si false altfel</returns>
		public bool IsWeekEnd(DateTime dt)
		{
			System.Globalization.GregorianCalendar x = new System.Globalization.GregorianCalendar();				
			System.DayOfWeek dow = x.GetDayOfWeek(dt);
			return (dow==System.DayOfWeek.Saturday || dow==System.DayOfWeek.Sunday);
		}
		#endregion

		#region IsSarbatoare
		/// <summary>
		/// Procedura verifica daca o zi este zi de sarbatoare
		/// </summary>
		/// <param name="dt">Data verificata</param>
		/// <returns>Returneaza true daca este sarbatoare si false altfel</returns>
		public bool IsSarbatoare( DateTime dt )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetZiDetaliu", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, dt));

				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);

				return (bool)ds.Tables[ 0 ].Rows[ 0 ][ "Sarbatoare" ];
			}
			catch
			{
				return false;
			}
		}
		#endregion

		#region InsertLuna
		/// <summary>
		/// Procedura adauga o luna
		/// </summary>
		/// <param name="An">Anul</param>
		/// <param name="Luna">Luna</param>
		public void InsertLuna(int An, int Luna)
		{
			for (int i=1;i<=this.NrZile(An,Luna);i++)
			{
				DateTime data = new DateTime(An,Luna,i);
				this.InsertZi(data,this.IsWeekEnd(data),data.DayOfWeek.ToString(),"");	
			}		
		}
		#endregion

		#region InsertZi
		/// <summary>
		/// Procedura adauga o zi
		/// </summary>
		/// <param name="Data">Data</param>
		/// <param name="Sarbatoare">Este sarbatoare sau nu</param>
		/// <param name="Denumire">Denumirea</param>
		/// <param name="Descriere">Descriearea</param>
		public void InsertZi(DateTime Data,bool Sarbatoare,string Denumire,string Descriere)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteZi", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, Data.ToShortDateString()));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Sarbatoare", SqlDbType.Bit, 1, Sarbatoare));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255, Denumire));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NText, 4000, Descriere));

				m_con.Open();
				myCommand.ExecuteNonQuery();
				m_con.Close();
			}
			catch{}
		}
		#endregion
	
		#region GetLuna
		/// <summary>
		/// Procedura selecteaza o luna
		/// </summary>
		/// <param name="An">Anul</param>
		/// <param name="Luna">Luna</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetLuna(int An, int Luna)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetZileLuna", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
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

		#region GetLunaAngajat
		/// <summary>
		/// Procedura selecteaza o anumita luna pentru un angajat
		/// </summary>
		/// <param name="An">Anul</param>
		/// <param name="Luna">Luna</param>
		/// <param name="DataInceput">Data de inceput a lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetLunaAngajat(int An, int Luna, DateTime DataInceput)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetZileLunaAngajat", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@An", SqlDbType.Int, 4, An));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Luna", SqlDbType.Int, 4, Luna));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataInceput", SqlDbType.DateTime, 8, DataInceput ));
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

		#region GetZileWeekendPosibileLunaAngajat
		/// <summary>
		/// Procedura determina zilele de weekend posibile pentru un angajat
		/// </summary>
		/// <param name="An">Anul</param>
		/// <param name="Luna">Luna</param>
		/// <param name="DataInceput">Data de inceput</param>
		/// <param name="DataSfarsit">Data de sfarsit</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetZileWeekendPosibileLunaAngajat(int An, int Luna, DateTime DataInceput, DateTime DataSfarsit)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetZileWeekendPosibileLunaAngajat", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@An", SqlDbType.Int, 4, An));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Luna", SqlDbType.Int, 4, Luna));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataInceput", SqlDbType.DateTime, 8, DataInceput ));
				if( DataSfarsit == DateTime.MinValue )
				{
					DataSfarsit = DateTime.MaxValue;
				}
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataSfarsit", SqlDbType.DateTime, 8, DataSfarsit ));
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

		#region GetZileLunaExpirareContract
		/// <summary>
		/// Daca expira contractul in luna data ca parametru retrneaza doar zilele pana la data expirarii
		/// </summary>
		/// <param name="An">Anul</param>
		/// <param name="Luna">Luna</param>
		/// <param name="DataInceput">Data de inceput</param>
		/// <param name="DataSfarsit">Data de sfarsit</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetZileLunaExpirareContract(int An, int Luna, DateTime DataInceput, DateTime DataExpirare)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetZileLunaPosibile", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@An", SqlDbType.Int, 4, An));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Luna", SqlDbType.Int, 4, Luna));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataInceput", SqlDbType.DateTime, 8, DataInceput ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataExpirare", SqlDbType.DateTime, 8, DataExpirare ));
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

		#region GetZileLunaImposibile
		/// <summary>
		/// Daca expira contractul in luna data ca parametru retrneaza doar zilele dupa data expirarii
		/// </summary>
		/// <param name="An">Anul</param>
		/// <param name="Luna">Luna</param>
		/// <param name="DataExpirare">Data de sfarsit</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetZileLunaImposibile(int An, int Luna, DateTime DataExpirare)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetZileLunaImposibile", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@An", SqlDbType.Int, 4, An));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Luna", SqlDbType.Int, 4, Luna));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataExpirare", SqlDbType.DateTime, 8, DataExpirare ));
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

		#region GetZileIntrerupereContract
		/// <summary>
		/// Zilele din luna curenta... pt care este intrerupt contractul
		/// </summary>
		/// <param name="An">Anul</param>
		/// <param name="Luna">Luna</param>
		/// <param name="DataStart">Data de inceput</param>
		/// <param name="DataEnd">Data de sfarsit</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetZileIntrerupereContract(int An, int Luna, DateTime DataStart, DateTime DataEnd )
		{
			try
			{
				DataStart = GetDataStart( DataStart, An, Luna );
				DataEnd = GetDataEnd( DataEnd, An, Luna );

				SqlCommand myCommand = new SqlCommand("tm_GetZileLunaIntrerupereContract", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, DataStart ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, DataEnd ));

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

		#region GetDataStart
		/// <summary>
		/// Procedura determina data de inceput a unei luni
		/// </summary>
		/// <param name="dataSt">Data de inceput</param>
		/// <param name="an">Anul</param>
		/// <param name="luna">Luna</param>
		/// <returns>Returneaza data de inceput</returns>
		private DateTime GetDataStart( DateTime dataSt, int an, int luna )
		{
			DateTime dtInceput = new DateTime( an, luna, 1 );
			DateTime dtSt = new DateTime( dataSt.Year, dataSt.Month, dataSt.Day );
			return ( dtInceput >= dtSt ? dtInceput : dtSt );
		}
		#endregion
	
		#region GetDataEnd
		/// <summary>
		/// Procedura determina data de sfarsit a unei luni
		/// </summary>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <param name="an">Anul</param>
		/// <param name="luna">Luna</param>
		/// <returns>Returneaza data de sfarsit</returns>
		private DateTime GetDataEnd( DateTime dataEnd, int an, int luna )
		{
			DateTime dtSfarsit = new DateTime( an, luna, DateTime.DaysInMonth( an, luna ));
			DateTime dtEnd = new DateTime( dataEnd.Year, dataEnd.Month, dataEnd.Day );
			return ( dtSfarsit >= dtEnd ? dtEnd : dtSfarsit );
		}
		#endregion
	}
}
