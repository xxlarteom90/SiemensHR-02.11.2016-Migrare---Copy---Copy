using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Data
{

	public struct IntervaleSchimbariLuna
	{
		public DateTime DataStart;
		public DateTime DataEnd;
		public int ProgramLucru;
		public float SalariuBaza;
		public float IndemnizatieConducere;
		public int Invaliditate;
		public string InvaliditateText;
		public int CategorieID;
		public string CategorieText;
	}

	public struct IntervalOrar
	{
		public DateTime OraStart;
		public DateTime OraEnd;
		public DateTime Data;
	}

	/// <summary>
	/// Summary description for PontajAngajat.
	/// </summary>
	public class PontajAngajat : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune</param>
		public PontajAngajat( string connectionString ): base( connectionString ){}
		#endregion

		#region GetNrZileConcediuOdihnaRamase
		/// <summary>
		/// Calculeaza numarul de zile de concediu de odihna ramase.
		/// </summary>
		/// <param name="lunaID"> ID-ul lunii.</param>
		/// <returns> Numarul de zile de concediu de odihna ramase.</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  21.04.2006
		/// </remarks>
		public int GetNrZileConcediuOdihnaRamase( int lunaID, long angajatID)
		{
			SqlParameter[] parameters = 
			{
				new SqlParameter("@lunaID", SqlDbType.Int, 4),
				new SqlParameter("@angajatID", SqlDbType.Int, 4),
				new SqlParameter("@nrZileCORamase", SqlDbType.Int, 4)
			};
			
			parameters[0].Value = lunaID;
			parameters[1].Value = angajatID;
			parameters[2].Direction = ParameterDirection.Output;

			RunProcedure( "spCalculNrZileConcediuOdihnaNeefectuate",parameters);

			return int.Parse(parameters[2].Value.ToString());
		}
		#endregion

		#region GetNrZileLuna
		/// <summary>
		/// Procedura calculeaza nr de zile pe luna
		/// </summary>
		/// <param name="lunaID">ID-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public int GetNrZileLuna( int lunaID )
		{
			try
			{
				DateTime dt = GetPrimaZiDinLuna( lunaID );
				SqlParameter[] parameters = 
				{
					new SqlParameter("@Luna", SqlDbType.Int, 4),
					new SqlParameter("@An", SqlDbType.Int, 4),
				};
			
				parameters[ 0 ].Value = dt.Month;
				parameters[ 1 ].Value = dt.Year;

				DataSet ds = RunProcedure( "tm_GetZileLucratoareLuna",parameters,"ZileLucratoareLuna" );
				return ds.Tables[ "ZileLucratoareLuna" ].Rows.Count;
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region GetNrZileLucratoarePerioada
		/// <summary>
		/// Procedura calculeaza nr de zile lucratoare pe o perioada
		/// </summary>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <returns>Returneaza nr de zile lucratoare</returns>
		public int GetNrZileLucratoarePerioada( DateTime dataStart, DateTime dataEnd )
		{
			try
			{
				SqlParameter[] parameters = 
				{
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8)
				};
			
				parameters[ 0 ].Value = dataStart;
				parameters[ 1 ].Value = dataEnd;

				DataSet ds = RunProcedure( "tm_GetZileLucratoarePerioada",parameters,"ZileLucratoareLuna" );

				return ds.Tables[ "ZileLucratoareLuna" ].Rows.Count;
			}
			catch
			{
				return -1;
			}
		}
		#endregion

		#region GetAngajatNrOreLucrateLuna
		/// <summary>
		/// Procedura calculeaza nr de ore lucrate de angajat pe luna
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>eturneaza un DataSet care contine aceste date</returns>
		public DataSet GetAngajatNrOreLucrateLuna( long angajatID, int lunaID )
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8),
			};
			
			DateTime primaZi = GetPrimaZiDinLuna( lunaID );
			DateTime ultimaZi = new DateTime( primaZi.Year, primaZi.Month, DateTime.DaysInMonth( primaZi.Year, primaZi.Month ));
			parameters[ 0 ].Value = angajatID;
			parameters[ 1 ].Value = primaZi;
			parameters[ 2 ].Value = ultimaZi;

			DataSet ds = RunProcedure( "tm_GetIntervaleLucratePerioada",parameters,"PerioadaLucrata" );
			return ds;
		}
		#endregion

		#region GetAngajatNrOreLucrateLuna
		/// <summary>
		/// PRocedura calculeaza nr de ore lucrate de angajat pe luna
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data se sfarsit</param>
		/// <returns></returns>
		public DataSet GetAngajatNrOreLucrateLuna( long angajatID, DateTime dataStart, DateTime dataEnd )
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8),
			};
			
			parameters[ 0 ].Value = angajatID;
			parameters[ 1 ].Value = dataStart;
			parameters[ 2 ].Value = dataEnd;

			DataSet ds = RunProcedure( "tm_GetIntervaleLucratePerioada",parameters,"PerioadaLucrata" );
			return ds;
		}
		#endregion

		#region GetAngajatNrOreTipLucrate
		/// <summary>
		/// Procedura calculeaza nr de ore de un anumit tip lucrate de angajat
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <param name="tipOre">Tipul orelor</param>
		/// <returns>Reurneaza un DataSet care contine aceste date</returns>
		public DataSet GetAngajatNrOreTipLucrate( long angajatID, int lunaID, string tipOre )
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8),
					new SqlParameter("@DescriereInterval", SqlDbType.NVarChar, 255)
				};
			
			DateTime primaZi = GetPrimaZiDinLuna( lunaID );
			DateTime ultimaZi = new DateTime( primaZi.Year, primaZi.Month, DateTime.DaysInMonth( primaZi.Year, primaZi.Month ));
			parameters[ 0 ].Value = angajatID;
			parameters[ 1 ].Value = primaZi;
			parameters[ 2 ].Value = ultimaZi;
			parameters[ 3 ].Value = tipOre;

			DataSet ds = RunProcedure( "tm_GetAngajatNrOreTipLucrate",parameters,"OreTipLucrate" );
			return ds;
		}
		#endregion

		#region GetAngajatNrOreTipLucrate
		/// <summary>
		/// Procedura calculeaza nr de ore de un anumit tip lucrate de angajat intr-un interval de timp
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <param name="tipOre">Tipul orelor</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAngajatNrOreTipLucrate( long angajatID, DateTime dataStart, DateTime dataEnd, string tipOre )
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8),
					new SqlParameter("@DescriereInterval", SqlDbType.NVarChar, 255)
				};
			
			parameters[ 0 ].Value = angajatID;
			parameters[ 1 ].Value = dataStart;
			parameters[ 2 ].Value = dataEnd;
			parameters[ 3 ].Value = tipOre;

			DataSet ds = RunProcedure( "tm_GetAngajatNrOreTipLucrate",parameters,"OreTipLucrate" );
			return ds;
		}
		#endregion

		#region GetAngajatZileOreTipLucrate
		/// <summary>
		/// Procedura calculeaza nr de ore de un anumit tip lucrate de angajat intr-un interval de timp 
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <param name="tipInterval">Id-ul tipului de interval</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAngajatZileOreTipLucrate( long angajatID, DateTime dataStart, DateTime dataEnd, int tipInterval )
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8),
					new SqlParameter("@TipIntervalID", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = angajatID;
			parameters[ 1 ].Value = dataStart;
			parameters[ 2 ].Value = dataEnd;
			parameters[ 3 ].Value = tipInterval;

			DataSet ds = RunProcedure( "tm_GetAngajatZileOreTipLucratePerioada",parameters,"OreTipLucrate" );
			return ds;
		}
		#endregion

		#region GetAngajatNrZileAbsenteTotalLuna
		/// <summary>
		/// Procedura selecteaza nr de zile de absenta ale unui angajat pe luna
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <param name="lunaID">Luna pentru care se selecteaza</param>
		/// <returns>Returneaza nr de zile de absenta</returns>
		public DataSet GetAngajatNrZileAbsenteTotalLuna( long angajatID, int lunaID )
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8),
					new SqlParameter("@CodAbsenta", SqlDbType.NVarChar, 5)
				};
			
			DateTime primaZi = GetPrimaZiDinLuna( lunaID );
			DateTime ultimaZi = new DateTime( primaZi.Year, primaZi.Month, DateTime.DaysInMonth( primaZi.Year, primaZi.Month ));
			parameters[ 0 ].Value = angajatID;
			parameters[ 1 ].Value = primaZi;
			parameters[ 2 ].Value = ultimaZi;
			parameters[ 3 ].Value = "";

			DataSet ds = RunProcedure( "tm_GetAngajatNrZileAbsentePerioada",parameters,"OreTipLucrate" );
			return ds;
		}
		#endregion

		#region GetAngajatNrZileAbsenteTipLuna
		/// <summary>
		/// Procedura calculeaza zilele de absenta de un anumit tip dintr-o luna
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <param name="tipAbsente">Tipul absentei</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAngajatNrZileAbsenteTipLuna( long angajatID, int lunaID, string tipAbsente )
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8),
					new SqlParameter("@CodAbsenta", SqlDbType.NVarChar, 5)
				};
			
			DateTime primaZi = GetPrimaZiDinLuna( lunaID );
			DateTime ultimaZi = new DateTime( primaZi.Year, primaZi.Month, DateTime.DaysInMonth( primaZi.Year, primaZi.Month ));
			parameters[ 0 ].Value = angajatID;
			parameters[ 1 ].Value = primaZi;
			parameters[ 2 ].Value = ultimaZi;
			parameters[ 3 ].Value = tipAbsente;

			DataSet ds = RunProcedure( "tm_GetAngajatNrZileAbsentePerioada",parameters,"OreTipLucrate" );
			return ds;
		}
		#endregion

		#region GetAngajatNrZileAbsenteTipLuna
		/// <summary>
		/// Procedura selecteaza nr de zile de absenta de un anumit tip pe luna
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <param name="tipAbsente">Tipul de absenta</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAngajatNrZileAbsenteTipLuna( long angajatID, DateTime dataStart, DateTime dataEnd, string tipAbsente )
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8),
					new SqlParameter("@CodAbsenta", SqlDbType.NVarChar, 5)
				};
			
			parameters[ 0 ].Value = angajatID;
			parameters[ 1 ].Value = dataStart;
			parameters[ 2 ].Value = dataEnd;
			parameters[ 3 ].Value = tipAbsente;

			DataSet ds = RunProcedure( "tm_GetAngajatNrZileAbsentePerioada",parameters,"OreTipLucrate" );
			return ds;
		}
		#endregion

		#region GetNrZileSarbatoareInterval
		/// <summary>
		/// Procedura calculeaza nr de zile de sarbatoare dintr-un interval
		/// </summary>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public int GetNrZileSarbatoareInterval( DateTime dataStart, DateTime dataEnd )
		{
			try
			{
				SqlParameter[] parameters = 
				{
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8)
				};
			
				parameters[ 0 ].Value = dataStart;
				parameters[ 1 ].Value = dataEnd;

				DataSet ds = RunProcedure( "tm_GetZileSarbatoareInterval",parameters,"ZileSarbatoare" );

				return ds.Tables[ "ZileSarbatoare" ].Rows.Count;
			}
			catch
			{
				return 0;
			}
		}
		#endregion

		#region GetNrZileLucratoareInterval
		/// <summary>
		/// Procedura calculeaza nr de zile lucratoare dintr-un interval
		/// </summary>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <returns>Returneaza nr de zile lucratoare</returns>
		public int GetNrZileLucratoareInterval( DateTime dataStart, DateTime dataEnd )
		{
			try
			{
				SqlParameter[] parameters = 
				{
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataStop", SqlDbType.DateTime, 8)
				};
			
				parameters[ 0 ].Value = dataStart;
				parameters[ 1 ].Value = dataEnd;

				int rowsAff = 0;

				int nrZileLucratoare = RunProcedure( "GetNrZileLucratoare",parameters, out rowsAff );

				return nrZileLucratoare;
			}
			catch
			{
				return 0;
			}
		}
		#endregion

		#region GetIntervaleAngajat
		/// <summary>
		/// Returneaza toate inregistrarile din tm_IntervaleAngajat dintr-o anumita luna pentru un anumit angajat
		/// </summary>
		/// <param name="luna">Id-ul lunii</param>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIntervaleAngajat( int luna, long angajatID)
		{
			DateTime primaZi = GetPrimaZiDinLuna( luna );
			DateTime ultimaZi = new DateTime( primaZi.Year, primaZi.Month, DateTime.DaysInMonth( primaZi.Year, primaZi.Month ));

			SqlParameter []parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8)
				};

			parameters[ 0 ].Value = angajatID;
			parameters[ 1 ].Value = primaZi;
			parameters[ 2 ].Value = ultimaZi;

			DataSet m_ds = RunProcedure( "GetIstoricSchimbariLunaAngajat", parameters, "Intervale" );
			return m_ds;
		}
		#endregion

		#region GetIntervaleSchimbariLuna
		/// <summary>
		/// Procedura selecteaza schimbarile dintr-o luna 
		/// </summary>
		/// <param name="luna">Id-ul lunii</param>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <param name="connectionString">String-ul de conexiune la baza de date</param>
		/// <returns>Returneaza un sir care contine aceste date</returns>
		public IntervaleSchimbariLuna[] GetIntervaleSchimbariLuna( int luna, long angajatID, string connectionString )
		{
			DateTime primaZi = GetPrimaZiDinLuna( luna );
			DateTime ultimaZi = new DateTime( primaZi.Year, primaZi.Month, DateTime.DaysInMonth( primaZi.Year, primaZi.Month ));

			SqlParameter []parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@DataEnd", SqlDbType.DateTime, 8)
				};

			parameters[ 0 ].Value = angajatID;
			parameters[ 1 ].Value = primaZi;
			parameters[ 2 ].Value = ultimaZi;

			DataSet m_ds = RunProcedure( "GetIstoricSchimbariLunaAngajat", parameters, "Intervale" );

			IntervaleSchimbariLuna []intervale = new IntervaleSchimbariLuna[ m_ds.Tables[ 0 ].Rows.Count ];
			            
			if(intervale.Length > 0)
			{
				int norma = int.Parse( m_ds.Tables[ 0 ].Rows[ 0 ][ "ProgramLucru" ].ToString());
				float salariuBaza = float.Parse( m_ds.Tables[ 0 ].Rows[ 0 ][ "SalariuBaza" ].ToString());
				float indemnizatieConducere = float.Parse( m_ds.Tables[ 0 ].Rows[ 0 ][ "IndemnizatieConducere" ].ToString());
				int invaliditate = int.Parse( m_ds.Tables[ 0 ].Rows[ 0 ][ "Invaliditate" ].ToString());
				string invaliditateText = m_ds.Tables[ 0 ].Rows[ 0 ][ "Nume" ].ToString();
				int categorieID = int.Parse( m_ds.Tables[ 0 ].Rows[ 0 ][ "CategorieID" ].ToString());
				string categorieText = m_ds.Tables[ 0 ].Rows[ 0 ][ "Denumire" ].ToString();

				intervale[ 0 ].DataStart = (DateTime)m_ds.Tables[ 0 ].Rows[ 0 ][ "Data" ];
				intervale[ 0 ].ProgramLucru = norma;
				intervale[ 0 ].SalariuBaza = salariuBaza;
				intervale[ 0 ].IndemnizatieConducere = indemnizatieConducere;
				intervale[ 0 ].Invaliditate = invaliditate;
				intervale[ 0 ].InvaliditateText = invaliditateText;
				intervale[ 0 ].CategorieID = categorieID;
				intervale[ 0 ].CategorieText = categorieText;

				int j = 0;

				for( int i=1; i<m_ds.Tables[ 0 ].Rows.Count; i++ )
				{
					DataRow dr = m_ds.Tables[ 0 ].Rows[ i ];
					if( int.Parse( dr[ "ProgramLucru" ].ToString()) != norma ||
						float.Parse( dr[ "SalariuBaza" ].ToString()) != salariuBaza ||
						float.Parse( dr[ "IndemnizatieConducere" ].ToString()) != indemnizatieConducere ||
						int.Parse( dr[ "Invaliditate" ].ToString()) != invaliditate ||
						dr[ "Denumire" ].ToString() != categorieText )
					{
						intervale[ j ].DataEnd = (DateTime)m_ds.Tables[ 0 ].Rows[ i-1 ][ "Data" ];

						j++;

						intervale[ j ].DataStart = (DateTime)m_ds.Tables[ 0 ].Rows[ i ][ "Data" ];

						norma = int.Parse( m_ds.Tables[ 0 ].Rows[ i ][ "ProgramLucru" ].ToString());
						salariuBaza = float.Parse( m_ds.Tables[ 0 ].Rows[ i ][ "SalariuBaza" ].ToString());
						indemnizatieConducere = float.Parse( m_ds.Tables[ 0 ].Rows[ i ][ "IndemnizatieConducere" ].ToString());
						invaliditate = int.Parse( m_ds.Tables[ 0 ].Rows[ i ][ "Invaliditate" ].ToString());
						invaliditateText = m_ds.Tables[ 0 ].Rows[ i ][ "Nume" ].ToString();
						categorieID = int.Parse( m_ds.Tables[ 0 ].Rows[ i ][ "CategorieID" ].ToString());
						categorieText = m_ds.Tables[ 0 ].Rows[ i ][ "Denumire" ].ToString();

						intervale[ j ].ProgramLucru = norma;
						intervale[ j ].SalariuBaza = salariuBaza;
						intervale[ j ].IndemnizatieConducere = indemnizatieConducere;
						intervale[ j ].Invaliditate = invaliditate;
						intervale[ j ].InvaliditateText = invaliditateText;
						intervale[ j ].CategorieID = categorieID;
						intervale[ j ].CategorieText = categorieText;
					}

				}
				Angajat ang = new Angajat(ConnectionString);
				DataSet ds = ang.GetDetaliiAngajat(angajatID);
			
				if ( ((ds.Tables[ 0 ].Rows[ 0 ][ "DataLichidare"] != System.DBNull.Value) ||(DateTime.Equals(ds.Tables[ 0 ].Rows[ 0 ][ "DataLichidare"],DateTime.MinValue))) && (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataLichidare"] <= ultimaZi)
				{
					DateTime dataLichidare = (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataLichidare"];
				
					intervale[ j ].DataEnd = dataLichidare.AddDays(-1);
				}
				else
				{
					intervale[ j ].DataEnd = ultimaZi;
				}

				IntervaleSchimbariLuna []intervaleFinale = new IntervaleSchimbariLuna[ j+1 ];
				for( int i=0; i<j+1; i++ )
				{
					intervaleFinale[ i ] = intervale[ i ];
				}
				//daca angajatul are contractul inceput de la o data anterioara primei zi din luna, pt primul interval,
				//dataStart e prima zi din luna
				try
				{
					DateTime dataDeLa = (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataDeLa" ];
					if( dataDeLa<intervaleFinale[ 0 ].DataStart && intervaleFinale[ 0 ].DataStart>primaZi )
					{
						if( dataDeLa<=primaZi )
						{
							intervaleFinale[ 0 ].DataStart = primaZi;
						}
						else
						{
							intervaleFinale[ 0 ].DataStart = dataDeLa;
						}
					}
				}
				catch
				{}
				return intervaleFinale;
			}
			return intervale;
		}
		#endregion

		#region GetPrimaZiDinLuna
		/// <summary>
		/// Procedura determina prima zi din luna
		/// </summary>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza prima zi a lunii</returns>
		public DateTime GetPrimaZiDinLuna( int lunaID )
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
			};
			
			parameters[ 0 ].Value = lunaID;
			DataSet ds = RunProcedure( "tm_GetLuna",parameters,"LunaCurenta" );
			if (ds.Tables[ "LunaCurenta" ].Rows.Count > 0)
				return (DateTime)ds.Tables[ "LunaCurenta" ].Rows[ 0 ][ "Data" ];
			else 
				return DateTime.Now;
		}
		#endregion

		#region GetNrZileConcediuBoalaFirma
		/// <summary>
		/// Autor: Muntean Raluca Cristina
		/// Data: 01.06.2005
		/// Descriere: returneaza numarul de zile de concediu de boala platite de catre firma
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza nr de zile de CO</returns>
		public int GetNrZileConcediuBoalaFirma(int angajatID, int lunaID)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@LunaID", SqlDbType.Int, 4)
				};

			parameters[0].Value = angajatID;
			parameters[1].Value = lunaID;

			DataSet ds = RunProcedure("spCalculNrZileConcediuBoalaFirmaSiBass", parameters, "NrZile");
			return (int.Parse(ds.Tables[0].Rows[0]["NrZileFirma"].ToString()));
		}	
		#endregion

		#region GetNrZileConcediuBoalaBASS
		/// <summary>
		/// Autor: Muntean Raluca Cristina
		/// Data: 01.06.2005
		/// Descriere: returneaza numarul de zile de concediu de boala platite de catre BASS
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <returns>Returneaza nr de zile de CB</returns>
		public int GetNrZileConcediuBoalaBASS(int angajatID, int lunaID)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@LunaID", SqlDbType.Int, 4)
				};

			parameters[0].Value = angajatID;
			parameters[1].Value = lunaID;

			DataSet ds = RunProcedure("spCalculNrZileConcediuBoalaFirmaSiBass", parameters, "NrZile");
			return (int.Parse(ds.Tables[0].Rows[0]["NrZileBASS"].ToString()));
		}
		#endregion

		#region GetNrZileConcediuBoalaPlatiteFirma
		/// <summary>
		/// Procedura determina numarul de zile de concediu de boala platite de firma
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului pentru care se determina aceasta valoare</param>
		/// <returns>Returneaza numarul de zile de concediu de boala</returns>
		/// <remarks>Adaugat:	Oprescu Claudia
		///			 Data:		20.02.2007
		/// </remarks>
		public int GetNrZileConcediuBoalaPlatiteFirma(int angajatorId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
					new SqlParameter("@NrMaxZileCBSuportateDeFirma", SqlDbType.Int, 4)
				};

			parameters[0].Value = angajatorId;
			parameters[1].Direction = ParameterDirection.Output;

			DataSet ds = RunProcedure("spCalculNrZileConcediuBoalaFirma", parameters, "NrZile");
			return (int.Parse(parameters[1].Value.ToString()));
		}
		#endregion

		#region GetNrZileIntervaleIntreruperi
		/// <summary>
		/// Procedura determina numarul de zile cu intreruperi de contracte de munca
		/// </summary>
		/// <param name="angajatID">Angajatul pentru care sa cauta numarul de zile</param>
		/// <param name="lunaID">Luna pentru care se cauta numarul de zile</param>
		/// <returns>Returneaza numarul de zile alocate intreruperilor de contracte de munca</returns>
		/// <remarks>Adaugat:	Oprescu Claudia
		///			 Data:		15.11.2006
		/// </remarks>
		public int GetNrZileIntervaleIntreruperi(int angajatID, int lunaID)
		{
			SqlParameter[] parameters = 
			{
				new SqlParameter("@AngajatID", SqlDbType.Int, 4),
				new SqlParameter("@LunaID", SqlDbType.Int, 4),
				new SqlParameter("@NrZile", SqlDbType.Int, 4)
			};

			parameters[0].Value = angajatID;
			parameters[1].Value = lunaID;
			parameters[2].Direction = ParameterDirection.ReturnValue;

			RunProcedure("tm_GetNrZileIntervaleIntreruperi", parameters);
			return (int.Parse(parameters[2].Value.ToString()));
		}
		#endregion

		#region GetAllZileLucratoareLuna
		/// <summary>
		/// Procedura determina zilele lucratoare ale lunii active
		/// </summary>
		/// <param name="luna">Luna activa</param>
		/// <returns>Returneaza un tabela in care sunt retinute zilele lucratoare ale lunii active</returns>
		/// <remarks>
		/// Adaugat:	Oprescu Claudia
		/// Data:		22.02.2007
		/// </remarks>
		public DataSet GetAllZileLucratoareLuna(DateTime luna)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@data", SqlDbType.DateTime, 8)
				};

			parameters[0].Value = luna;
			return RunProcedure("spGetAllZileLucratoareLuna", parameters, "ZileLucratoare");
		}
		#endregion
	}
}
