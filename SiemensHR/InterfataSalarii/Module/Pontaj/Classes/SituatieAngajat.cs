using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

using SiemensTM.utils;
using Salaries.Business;
using Salaries.Data;

namespace SiemensTM.Classes
{
	/// <summary>
	/// Summary description for Zile.
	/// </summary>
	public class SituatieAngajat 
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
		public SituatieAngajat(long _AngajatID)
		{
			this.AngajatID=_AngajatID;
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
		public SituatieAngajat(long _AngajatID,Salaries.Configuration.ModuleSettings st)
		{
			this.AngajatID=_AngajatID;
			settings = st;
			m_con = new SqlConnection(settings.ConnectionString);
		}
		#endregion

		#region GetOreZi
		/// <summary>
		/// Procedura calculeaza nr de ore pe zi
		/// </summary>
		/// <param name="Data">Data</param>
		/// <returns>Returneaza nr de ore pe zi</returns>
		public float GetOreZi(DateTime Data)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetOreZi", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, Data));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
							
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				return float.Parse(ds.Tables[0].Rows[0][0].ToString());								
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		
		#region GetOreZiLuna
		/// <summary>
		/// Procedura calculeaza nr de ore pe zi pentru fiecare zi din luna
		/// </summary>
		/// <param name="Data">Data</param>
		/// <returns>Returneaza un dataset</returns>
		//Lungu Andreea - 08.09.2008 
		//Descriere - se creaza un dataset ce contine nr de ore pentru fiecare  zi a lunii
		public DataSet GetOreZiLuna(DateTime dataStart, DateTime dataEnd)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetOreZi_Luna", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, dataEnd));
						
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

		#region GetNormaZi
		/// <summary>
		/// Procedura determina norma pentru o anumita zi
		/// </summary>
		/// <param name="Data">Data</param>
		/// <returns>Returneaza valoarea normei</returns>
		public int GetNormaZi( DateTime Data )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetZiAngajatInfo", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, Data));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				return int.Parse( ds.Tables[ 0 ].Rows[ 0 ][ "ProgramLucru" ].ToString());
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region GetNormaZiLuna
		/// <summary>
		/// Procedura determina norma pentru o anumita zi
		/// </summary>
		/// <param name="Data">Data</param>
		/// <returns>Returneaza valoarea normei</returns>
		//Lungu Andreea - 08.09.2008 
		//Descriere - se creaza un dataset ce contine programul de lucru pentru fiecare  zi a lunii
		public DataSet GetNormaZiLuna( DateTime dataStart, DateTime dataEnd )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetZiAngajatInfo_Luna", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, dataStart));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, dataEnd));
				
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

		#region GetZiAngajat
		/// <summary>
		/// Procedura determina datele unei zile de lucru ale unui angajat
		/// </summary>
		/// <param name="Data">Data</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetZiAngajat( DateTime Data )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetZiAngajatInfo", m_con);
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

		#region GetZiApartenentaIntervalDateAngajare
		/// <summary>
		/// Preia datele specifice (prog lucru, sal baza, etc) din intervalul de care apartine ziua data ca param
		/// </summary>
		/// <param name="Data">Data</param>
		/// <returns>Returneaza o inregistrare din tabela</returns>
		public DataRow GetZiApartenentaIntervalDateAngajare( DateTime Data )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetZiIntervalApartenentaInfo", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, Data));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
				return ds.Tables[ 0 ].Rows[ 0 ];
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetIntervaleAbsentaAngajatLunaByDataInside
		/// <summary>
		/// Procedura selecteaza intervalele de absenta al angajatului
		/// </summary>
		/// <param name="Data">Data</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIntervaleAbsentaAngajatLunaByDataInside(DateTime Data)
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetIntervaleAbsentaSiEmergencyLuna", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataCurenta", SqlDbType.DateTime, 8, Data ));
								
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

		#region GetAbsentaMedicalaContinuareLuna
		/// <summary>
		/// Procedura determina intervalele de absenta medicala de tip continuare
		/// </summary>
		/// <param name="Data">Data</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAbsentaMedicalaContinuareLuna( DateTime Data )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetIntervaleAbsentaMedicalaContinuareLuna", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, this.AngajatID));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataCurenta", SqlDbType.DateTime, 8, Data ));
				
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
		
		#region IsAbsenta
		/// <summary>
		/// Procedura verifica daca o data este absenta sau nu
		/// </summary>
		/// <param name="Data">Data</param>
		/// <returns>Returneaza true daca data este absenta si false altfel</returns>
		public bool IsAbsenta(DateTime Data)
		{
			DataSet ds = new AbsenteAngajat(this.AngajatID).GetAbsenteLuna(Data.Year,Data.Month);
			DataTable dt = ds.Tables[0];
			
			DataColumn[] keys = new DataColumn[1];
			keys[0] = ds.Tables[0].Columns["Data"];
		
			dt.PrimaryKey=keys;
			return dt.Rows.Contains(Data);
		}
		#endregion

		#region GetCodBoala
		/// <summary>
		/// Procedura determina codul unei boli
		/// </summary>
		/// <param name="boalaID">Id-ul bolii</param>
		/// <returns>Returneaza codul bolii</returns>
		public string GetCodBoala( string boalaID )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("tm_GetCodBoala", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@BoalaID", SqlDbType.Int, 4, boalaID ));
				
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);

				if( ds.Tables[ 0 ].Rows.Count > 0 )
				{
					return ds.Tables[ 0 ].Rows[ 0 ][ "Cod" ].ToString();
				}
				return "";
			}
			catch
			{
				return "";
			}
		}
		#endregion

		#region GenerareSituatieLunaraAngajat
		/// <summary>
		/// Genereaza situatia lunara a unui angajat.
		/// </summary>
		/// <remarks>
		/// Added: Cristina Raluca Muntean
		/// Date: 7.09.2005
		/// </remarks>
		public void GenerareSituatieLunaraAngajat()
		{
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.AngajatId = AngajatID;
			angajat.LoadAngajat();

			//este obtinuta prima zi a lunii active
			Salaries.Business.Luni luna = new Salaries.Business.Luni(angajat.AngajatorId,settings);
			Salaries.Data.LunaData lunaActiva = luna.GetLunaActiva();
			
			Salaries.Business.PontajAngajat pontajAngajat = new Salaries.Business.PontajAngajat( this.AngajatID, settings );

			DataSet dsIntervaleAngajat = pontajAngajat.GetIntervaleAngajat( lunaActiva.LunaId );

			//daca nu au fost initializate orele unui angajat, se face aceasta initializare
			if(dsIntervaleAngajat.Tables[0].Rows.Count == 0)
			{			
				//intervale angajat
				IntervaleAngajat intervAng = new IntervaleAngajat(AngajatID,settings);
			
				//sunt intializate orele lucrate de catre angajat
				intervAng.InitializeOreLucrateLunaAngajat( lunaActiva.Data, angajat.DataDeLa, angajat.DataLichidare );
			}

			//situatia lunara a unui angajat
			Salaries.Business.SituatieLunaraAngajat situatieLunaraAng = new Salaries.Business.SituatieLunaraAngajat(AngajatID,settings);
			
			//se genereaza situatia lunara a angajatului
			situatieLunaraAng.GenerareSituatieLunaraAngajat(lunaActiva.LunaId, angajat.AngajatorId);
		}
		#endregion

		#region GenerareSituatieLunaraAngajatLichidat
		/// <summary>
		/// Procedura genereaza situatia lunara unui angajat care a fost lichidat
		/// </summary>
		public void GenerareSituatieLunaraAngajatLichidat()
		{
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.AngajatId = AngajatID;
			angajat.LoadAngajat();

			//este obtinuta prima zi a lunii active
			Salaries.Business.Luni luna = new Salaries.Business.Luni(angajat.AngajatorId,settings);
			Salaries.Data.LunaData lunaActiva = luna.GetLunaActiva();
			
			Salaries.Business.PontajAngajat pontajAngajat = new Salaries.Business.PontajAngajat( this.AngajatID, settings );

			DataSet dsIntervaleAngajat = pontajAngajat.GetIntervaleAngajat( lunaActiva.LunaId );

			//daca nu au fost initializate orele unui angajat, se face aceasta initializare
			if(dsIntervaleAngajat.Tables[0].Rows.Count == 0)
			{			
				//intervale angajat
				IntervaleAngajat intervAng = new IntervaleAngajat(AngajatID,settings);
			
				//sunt intializate orele lucrate de catre angajat
				intervAng.InitializeOreLucrateLunaAngajat( lunaActiva.Data, angajat.DataDeLa, angajat.DataLichidare );
			}

			//situatia lunara a unui angajat
			Salaries.Business.SituatieLunaraAngajat situatieLunaraAng = new Salaries.Business.SituatieLunaraAngajat(AngajatID,settings);
			
			//se genereaza situatia lunara a angajatului
			situatieLunaraAng.GenerareSituatieLunaraAngajatLichidat(lunaActiva.LunaId, angajat.AngajatorId);
		}
		#endregion
	}
}
