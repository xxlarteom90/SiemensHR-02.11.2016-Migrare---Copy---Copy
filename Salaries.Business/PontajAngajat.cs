using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for PontajAngajat.
	/// </summary>
	public class PontajAngajat : Salaries.Business.BizObject
	{
		#region Atribute private
		//Setarile aplicatiei
		private Configuration.ModuleSettings settings;
		//Id-ul angajatului
		private long angajatId;
		#endregion

		#region Constructor
		public PontajAngajat( long angajatId)
		{
			settings = Configuration.ModuleConfig.GetSettings();
			this.angajatId = angajatId;
		}

		public PontajAngajat(long angajatId,Salaries.Configuration.ModuleSettings st)
		{
			settings=st;
			this.angajatId = angajatId;
		}
		#endregion

		#region Proprietati

		/// <summary>
		/// Id-ul angajatului.
		/// </summary>
		public long AngajatId
		{
			get
			{
				return angajatId;
			}

			set
			{
				angajatId = value;
			}
		}
		#endregion
		
		#region GetNrZileLuna
		/// <summary>
		/// Procedura calculeaza nr de zile ale unei luni
		/// </summary>
		/// <param name="luna">Luna pt care se calculeaza</param>
		/// <returns>Returneaza nr de zile</returns>
		public int GetNrZileLuna( int luna )
		{
			Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
			return pa.GetNrZileLuna( luna );
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
			Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
			return pa.GetNrZileLucratoarePerioada( dataStart, dataEnd );
		}
		#endregion

		#region GetAngajatNrOreLucrateLuna
		/// <summary>
		/// Procedura calculeaza nr de ore lucrate de angajat pe luna
		/// </summary>
		/// <param name="luna">Luna pentru care se calculeaza</param>
		/// <returns>Returneaza nr de ore lucrate</returns>
		public TimeSpan GetAngajatNrOreLucrateLuna( int luna )
		{
			try
			{
				Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
				DataSet ds = pa.GetAngajatNrOreLucrateLuna( angajatId, luna );

				return TimpLuna( ds );
			}
			catch
			{
				return new TimeSpan( 0 );
			}
		}
		#endregion

		#region GetAngajatNrOreLucrateLuna
		/// <summary>
		/// Procedura calculeaza nr de ore lucrate de angajat pe luna
		/// </summary>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <returns>Returneaza timpul lucrat</returns>
		public TimeSpan GetAngajatNrOreLucrateLuna( DateTime dataStart, DateTime dataEnd )
		{
			try
			{
				Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
				DataSet ds = pa.GetAngajatNrOreLucrateLuna( angajatId, dataStart, dataEnd );

				return TimpLuna( ds );
			}
			catch
			{
				return new TimeSpan( 0 );
			}
		}
		#endregion

		#region GetAngajatNrOreTipLucrate
		/// <summary>
		/// Procedura calculeaza nr de ore de un anumit tip lucrate de angajat
		/// </summary>
		/// <param name="luna">Luna pentru care se calculeaza</param>
		/// <param name="tipOre">Tipul orelor</param>
		/// <returns>Returneaza timpul lucrat</returns>
		public TimeSpan GetAngajatNrOreTipLucrate( int luna, string tipOre )
		{
			try
			{
				Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
				
				DataSet ds = pa.GetAngajatNrOreTipLucrate( angajatId, luna, tipOre );

				return TimpLuna( ds );
			}
			catch
			{
				return new TimeSpan( 0 );
			}
		}
		#endregion

		#region GetAngajatNrOreTipLucrate
		/// <summary>
		/// Procedura calculeaza nr de ore de un anumit tip lucrate de angajat pe o perioada de timp
		/// </summary>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <param name="tipOre">Tipul orelor lucrate</param>
		/// <returns>Returneaza timpul lucrat</returns>
		public TimeSpan GetAngajatNrOreTipLucrate( DateTime dataStart, DateTime dataEnd, string tipOre )
		{
			try
			{
				Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
				
				DataSet ds = pa.GetAngajatNrOreTipLucrate( angajatId, dataStart, dataEnd, tipOre );

				return TimpLuna( ds );
			}
			catch
			{
				return new TimeSpan( 0 );
			}
		}
		#endregion

		#region GetAngajatZileOreTipLucrate
		/// <summary>
		/// Procedura calculeaza nr ore de un anumit tip lucrate de angajat
		/// </summary>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <param name="tipInterval">Tipul orelor lucrate</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAngajatZileOreTipLucrate( DateTime dataStart, DateTime dataEnd, int tipInterval )
		{
			try
			{
				Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
				return pa.GetAngajatZileOreTipLucrate( angajatId, dataStart, dataEnd, tipInterval );
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetIntervaleLibereZi
		/// <summary>
		/// Preia intervalele libere dintr-o zi; sunt 2 cazuri: intervale libere din timpul zilei si weekend (8-22)
		/// si intervale din timpul noptii (22-6).
		/// </summary>
		/// <param name="oraMin"></param>
		/// <param name="oraMax"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data.IntervalOrar[] GetIntervaleLibereZi( int oraMin, int oraMax, DateTime data )
		{
			try
			{
				DateTime oraMinima = new DateTime( data.Year, data.Month, data.Day, oraMin, 0, 0 );
				DateTime oraMaxima = new DateTime( data.Year, data.Month, data.Day, oraMax, 0, 0 );

				Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
				DataSet ds = pa.GetAngajatNrOreLucrateLuna( angajatId, data, data );
				DataView dv = new DataView( ds.Tables[ 0 ] );

				if( oraMin<oraMax )
				//cazul in care avem ore speciale normale (ziua in timpul saptamanii, weekend)
				{
					dv.RowFilter = "'"+oraMinima.ToString()+"'<OraStart and OraEnd<'"+oraMaxima.ToString()+"'";
					dv.Sort = "OraStart";
					//stabilirea numarului de intervale
					if( dv.Count>0 )
					{
						int intervalDimension = 0;
						
						if( oraMinima<(DateTime)dv[ 0 ][ "OraStart" ] )
						{
							intervalDimension++;
						}
						
						if( dv.Count>1 )
						{
							for( int i=0; i<dv.Count-1; i++ )
							{
								if((DateTime)dv[ i ][ "OraEnd" ]<(DateTime)dv[ i+1 ][ "OraStart" ] )
								{
									intervalDimension++;
								}
							}
						}
						
						if((DateTime)dv[ dv.Count-1 ][ "OraEnd" ]<oraMaxima )
						{
							intervalDimension++;
						}
						Data.IntervalOrar [] intervalOrar = new Salaries.Data.IntervalOrar[ intervalDimension ];

						//crearea de intervale
						int intervalIndex = 0;
						
						if( oraMinima<(DateTime)dv[ 0 ][ "OraStart" ] )
						{
							intervalOrar[ intervalIndex ].Data = data;
							intervalOrar[ intervalIndex ].OraStart = oraMinima;
							intervalOrar[ intervalIndex ].OraEnd = (DateTime)dv[ 0 ][ "OraStart" ];
							intervalIndex++;
						}
						
						if( dv.Count>1 )
						{
							for( int i=0; i<dv.Count-1; i++ )
							{
								if((DateTime)dv[ i ][ "OraEnd" ]<(DateTime)dv[ i+1 ][ "OraStart" ] )
								{
									intervalOrar[ intervalIndex ].Data = data;
									intervalOrar[ intervalIndex ].OraStart = (DateTime)dv[ i ][ "OraEnd" ];
									intervalOrar[ intervalIndex ].OraEnd = (DateTime)dv[ i+1 ][ "OraStart" ];
									intervalIndex++;
								}
							}
						}
						
						if((DateTime)dv[ dv.Count-1 ][ "OraEnd" ]<oraMaxima )
						{
							intervalOrar[ intervalIndex ].Data = data;
							intervalOrar[ intervalIndex ].OraStart = (DateTime)dv[ dv.Count-1 ][ "OraEnd" ];
							intervalOrar[ intervalIndex ].OraEnd = oraMaxima;
						}
						return intervalOrar;
					}
					else
					{
						Data.IntervalOrar [] intervalOrar = new Salaries.Data.IntervalOrar[ 1 ];
						intervalOrar[ 0 ].Data = data;
						intervalOrar[ 0 ].OraStart = oraMinima;
						intervalOrar[ 0 ].OraEnd = oraMaxima;
						return intervalOrar;
					}
				}
				else
				//cazul in care avem ore suplimentare speciale (noaptea)
				{
					DateTime ora0 = new DateTime( data.Year, data.Month, data.Day, 0, 0, 0 );
					DateTime ora24 = new DateTime( data.Year, data.Month, data.Day, 0, 0, 0 );
					ora24 = ora24.AddDays( 1 );

					//intervalul de la 00:00 - 06:00
					dv.RowFilter = "'"+ora0.ToString()+"'<=OraStart and OraEnd<='"+oraMaxima.ToString()+"'";
					dv.Sort = "OraStart";
					
					//stabilirea numarului de intervale
					int intervalDimension = 0;
					
					if( dv.Count>0 )
					{
						if( ora0<(DateTime)dv[ 0 ][ "OraStart" ] )
						{
							intervalDimension++;
						}
						
						if( dv.Count>1 )
						{
							for( int i=0; i<dv.Count-1; i++ )
							{
								if((DateTime)dv[ i ][ "OraEnd" ]<(DateTime)dv[ i+1 ][ "OraStart" ] )
								{
									intervalDimension++;
								}
							}
						}
						
						if((DateTime)dv[ dv.Count-1 ][ "OraEnd" ]<oraMaxima )
						{
							intervalDimension++;
						}
					}
					else
					{
						intervalDimension++;
					}

					//intervalul de la 22:00 - 24:00
					dv.RowFilter= "'"+oraMinima.ToString()+"'<=OraStart and OraEnd<='"+ora24.ToString()+"'";
					
					if( dv.Count>0 )
					{
						if( oraMinima<(DateTime)dv[ 0 ][ "OraStart" ] )
						{
							intervalDimension++;
						}
						
						if( dv.Count>1 )
						{
							for( int i=0; i<dv.Count-1; i++ )
							{
								if((DateTime)dv[ i ][ "OraEnd" ]<(DateTime)dv[ i+1 ][ "OraStart" ] )
								{
									intervalDimension++;
								}
							}
						}
		
						if((DateTime)dv[ dv.Count-1 ][ "OraEnd" ]<ora24 )
						{
							intervalDimension++;
						}
					}
					else
					{
						intervalDimension++;
					}

					//crearea de intervale
					Data.IntervalOrar [] intervalOrar = new Salaries.Data.IntervalOrar[ intervalDimension ];
					dv.RowFilter = "'"+ora0.ToString()+"'<=OraStart and OraEnd<='"+oraMaxima.ToString()+"'";
					int intervalIndex = 0;

					if( dv.Count>0 )
					{
						if( ora0<(DateTime)dv[ 0 ][ "OraStart" ] )
						{
							intervalOrar[ intervalIndex ].Data = data;
							intervalOrar[ intervalIndex ].OraStart = ora0;
							intervalOrar[ intervalIndex ].OraEnd = (DateTime)dv[ 0 ][ "OraStart" ];
							intervalIndex++;
						}
						
						if( dv.Count>1 )
						{
							for( int i=0; i<dv.Count-1; i++ )
							{
								if((DateTime)dv[ i ][ "OraEnd" ]<(DateTime)dv[ i+1 ][ "OraStart" ] )
								{
									intervalOrar[ intervalIndex ].Data = data;
									intervalOrar[ intervalIndex ].OraStart = (DateTime)dv[ i ][ "OraEnd" ];
									intervalOrar[ intervalIndex ].OraEnd = (DateTime)dv[ i+1 ][ "OraStart" ];
									intervalIndex++;
								}
							}
						}
						
						if((DateTime)dv[ dv.Count-1 ][ "OraEnd" ]<oraMaxima )
						{
							intervalOrar[ intervalIndex ].Data = data;
							intervalOrar[ intervalIndex ].OraStart = (DateTime)dv[ dv.Count-1 ][ "OraEnd" ];
							intervalOrar[ intervalIndex ].OraEnd = oraMaxima;
							intervalIndex++;
						}
					}
					else
					{
						intervalOrar[ intervalIndex ].Data = data;
						intervalOrar[ intervalIndex ].OraStart = ora0;
						intervalOrar[ intervalIndex ].OraEnd = oraMaxima;
						intervalIndex++;
					}

					//intervalul de la 22:00 - 24:00
					dv.RowFilter= "'"+oraMinima.ToString()+"'<=OraStart and OraEnd<='"+ora24.ToString()+"'";
					
					if( dv.Count>0 )
					{
						if( oraMinima<(DateTime)dv[ 0 ][ "OraStart" ] )
						{
							intervalOrar[ intervalIndex ].Data = data;
							intervalOrar[ intervalIndex ].OraStart = oraMinima;
							intervalOrar[ intervalIndex ].OraEnd = (DateTime)dv[ 0 ][ "OraStart" ];
							intervalIndex++;
						}
						
						if( dv.Count>1 )
						{
							for( int i=0; i<dv.Count-1; i++ )
							{
								if((DateTime)dv[ i ][ "OraEnd" ]<(DateTime)dv[ i+1 ][ "OraStart" ] )
								{
									intervalOrar[ intervalIndex ].Data = data;
									intervalOrar[ intervalIndex ].OraStart = (DateTime)dv[ i ][ "OraEnd" ];
									intervalOrar[ intervalIndex ].OraEnd = (DateTime)dv[ i+1 ][ "OraStart" ];
									intervalIndex++;
								}
							}
						}
					
						if((DateTime)dv[ dv.Count-1 ][ "OraEnd" ]<ora24 )
						{
							intervalOrar[ intervalIndex ].Data = data;
						
							if((DateTime)dv[ dv.Count-1 ][ "OraEnd" ]>oraMinima )
							{
								intervalOrar[ intervalIndex ].OraStart = (DateTime)dv[ dv.Count-1 ][ "OraEnd" ];
							}
							else
							{
								intervalOrar[ intervalIndex ].OraStart = oraMinima;
							}
							intervalOrar[ intervalIndex ].OraEnd = ora24;
						}
					}
					else
					{
						intervalOrar[ intervalIndex ].Data = data;
						intervalOrar[ intervalIndex ].OraStart = oraMinima;
						intervalOrar[ intervalIndex ].OraEnd = ora24;
						intervalIndex++;
					}
					return intervalOrar;
				}
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetAngajatNrZileAbsenteTotalLuna
		/// <summary>
		/// Procedura selecteaza nr de zile de absenta ale unui angajat pe luna
		/// </summary>
		/// <param name="luna">Luna pentru care se selecteaza</param>
		/// <returns>Returneaza nr de zile de absenta</returns>
		public int GetAngajatNrZileAbsenteTotalLuna( int luna )
		{
			try
			{
				Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
				DataSet ds = pa.GetAngajatNrZileAbsenteTotalLuna( angajatId, luna );
				DateTime primaZi = pa.GetPrimaZiDinLuna( luna );
				DateTime ultimaZi = new DateTime( primaZi.Year, primaZi.Month, DateTime.DaysInMonth( primaZi.Year, primaZi.Month ));
				return TimpAbsente( ds, pa, primaZi, ultimaZi );
			}
			catch
			{
				return 0;
			}
		}
		#endregion

		#region GetAngajatNrZileAbsenteTipLuna
		/// <summary>
		/// Procedura selecteaza nr de zile de absenta de un anumit tip pe luna
		/// </summary>
		/// <param name="luna">Luna pentru care se selecteaza</param>
		/// <param name="tipAbsente">Tipul absentelor</param>
		/// <returns>Returneaza nr de zile de absenta</returns>
		public int GetAngajatNrZileAbsenteTipLuna( int luna, string tipAbsente )
		{
			try
			{
				Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
				DataSet ds = pa.GetAngajatNrZileAbsenteTipLuna( angajatId, luna, tipAbsente );
				DateTime primaZi = pa.GetPrimaZiDinLuna( luna );
				DateTime ultimaZi = new DateTime( primaZi.Year, primaZi.Month, DateTime.DaysInMonth( primaZi.Year, primaZi.Month ));
				return TimpAbsente( ds, pa, primaZi, ultimaZi );
			}
			catch
			{
				return 0;
			}
		}
		#endregion
		
		#region GetNrZileConcediuBoalaFirma
		/// <summary>
		/// Returneaza numarul de zile de concediu de boala platite de firma.
		/// </summary>
		/// <param name="lunaId"> Id-ul lunii pentru care se doreste aflarea numarului de zile de concediu 
		/// de boala platite de firma.</param>
		/// <returns> Numarul de zile de concediu de boala platite de firma.</returns>
		/// <remarks>
		/// Autor: Muntean Raluca Cristina
		/// Data: 1.06.2005
		/// </remarks>
		public int GetNrZileConcediuBoalaFirma(int lunaId)
		{
			try
			{
				Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
				return  pa.GetNrZileConcediuBoalaFirma( int.Parse(angajatId.ToString()), lunaId);
			}
			catch
			{
				return 0;
			}	
		}
		#endregion

		#region GetNrZileConcediuBoalaBASS
		/// <summary>
		/// Returneaza numarul de zile de concediu de boala platite de BASS.
		/// </summary>
		/// <param name="lunaId"> Id-ul lunii pentru care se doreste aflarea numarului de zile 
		/// de concediu de boala platite de BASS.</param>
		/// <returns> Numarul de zile de concediu de boala platite de BASS</returns>
		/// <remarks>
		/// Autor: Muntean Raluca Cristina
		/// Data: 1.06.2005
		/// </remarks>
		public int GetNrZileConcediuBoalaBASS(int lunaId)
		{
			try
			{
				Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
				return  pa.GetNrZileConcediuBoalaBASS( int.Parse(angajatId.ToString()), lunaId);
			}
			catch
			{
				return 0;
			}	
		}
		#endregion

		#region GetAngajatNrZileCOLuateAn
		/// <summary>
		/// Procedura calculeaza nr de zile de CO lunare de angajat
		/// </summary>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <param name="IntervalID">Id-ul intervalului</param>
		/// <returns>Returneaza nr de zile de CO</returns>
		public int GetAngajatNrZileCOLuateAn( DateTime dataStart, DateTime dataEnd, int IntervalID )
		{
			try
			{
				Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
				
				DataSet ds = pa.GetAngajatNrZileAbsenteTipLuna( angajatId, dataStart, dataEnd, SituatieLunaraAngajat.codAbsente[ 2 ] );
				
				//sterge CO care au inceput in anul precedent si se termina in anul curent (pt ca apartin de anul precedent)
				for( int i=0; i<ds.Tables[ 0 ].Rows.Count; i++ )
				{
					DataRow dr = ds.Tables[ 0 ].Rows[ i ];
					if((DateTime)dr[ "DataStart" ] < dataStart || (DateTime)dr[ "DataStart" ] > dataEnd || IntervalID==int.Parse( dr[ "IntervalAbsentaID" ].ToString()))
					{
						ds.Tables[ 0 ].Rows.RemoveAt( i );
						i--;
					}
				}
				
				//pt cazul in care concediul incepe in Decembrie si se termina prin Ianuarie
				if( (DateTime)ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "DataStart" ]<=dataEnd && dataEnd<(DateTime)ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "DataEnd" ] )
				{
					dataEnd = (DateTime)ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "DataEnd" ];
				}

				return TimpAbsente( ds, pa, dataStart, dataEnd );
			}
			catch
			{
				return 0;
			}
		}
		#endregion

		#region GetNrZileConcediuOdihnaRamase
		/// <summary>
		/// Calculeaza numarul de zile de concediu de odihna ramase.
		/// </summary>
		/// <param name="lunaId"> Id-ul lunii.</param>
		/// <returns> Numarul de zile de concediu de odihna ramase.</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  21.04.2006
		/// </remarks>
		public int GetNrZileConcediuOdihnaRamase( int lunaId )
		{
			int nrZileCOneefectuate;

			Data.PontajAngajat pontajAngajat = new Data.PontajAngajat(settings.ConnectionString);
			nrZileCOneefectuate = pontajAngajat.GetNrZileConcediuOdihnaRamase(lunaId, angajatId);

			return nrZileCOneefectuate;
		}
		#endregion

		#region GetAngajatNrZileCODisponibileAn
		/// <summary>
		/// Procedura calculeaza nr de zile de CO disponibile pe an
		/// </summary>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza nr de zile de CO disponibile</returns>
		public int GetAngajatNrZileCODisponibileAn( DateTime dataStart, DateTime dataEnd, int angajatorID )
		{
			try
			{
				Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
				angajat.AngajatId = angajatId;
				DataSet ds = angajat.GetDetaliiAngajat();

				if( dataStart.Year < ((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataDeLa" ]).Year )
				{
					return 0;
				}
				else if( dataStart.Year == ((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataDeLa" ]).Year )
				{
					dataStart = (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataDeLa" ];
				}

				if((bool)ds.Tables[ 0 ].Rows[ 0 ][ "Lichidat" ] )
				{
					if( dataEnd.Year > ((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataLichidare" ]).Year )
					{
						return 0;
					}
					else if( dataEnd.Year == ((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataLichidare" ]).Year )
					{
						dataEnd = (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataLichidare" ];
					}
				}

				float nrZileAngPerLuna = 0;
				float nrZileDisponibile = 0;
				float nrZileCOAn = float.Parse( ds.Tables[ 0 ].Rows[ 0 ][ "NrZileCOAn" ].ToString());
				float norma = float.Parse( ds.Tables[ 0 ].Rows[ 0 ][ "ProgramLucru" ].ToString());


				for( int i=dataStart.Month; i<=dataEnd.Month; i++ )
				{
					int ziSt = 1;
					int ziEnd = DateTime.DaysInMonth( dataStart.Year, i );
					if( dataStart.Month==i )
					{
						ziSt = dataStart.Day;
					}

					DateTime dt = new DateTime( dataStart.Year, i, ziSt );

					Luni luni = new Luni( angajatorID );
					int lunaID = luni.GetDetaliiByData( dt ).LunaId;
					Data.LunaData lunaData = luni.GetDetalii( lunaID );

					Data.IntervaleSchimbariLuna []interv = GetIntervalProgramLucru( lunaID );

					if( interv.Length > 0 )
					{
						for( int j=0; j<interv.Length; j++ )
						{
							norma = interv[ j ].ProgramLucru;
							if( ziSt <= interv[ j ].DataEnd.Day )
							{
								if( ziSt <= interv[ j ].DataStart.Day )
								{
									ziSt = interv[ j ].DataStart.Day;
								}
								ziEnd = interv[ j ].DataEnd.Day;
								nrZileAngPerLuna = GetAngajatNrZileCODisponibileLunaAn( dataStart.Year, i, ziSt, ziEnd );

								//folosim varianta initala, deoarece la formula data de Sica, nr de zile disponibile creste cu 1 pt anumiti ani
								nrZileDisponibile += ( nrZileCOAn*8*nrZileAngPerLuna )/( 12*8*DateTime.DaysInMonth( dataStart.Year, i ));
							}
						}
					}
					else
					{
						nrZileAngPerLuna = GetAngajatNrZileCODisponibileLunaAn( dataStart.Year, i, ziSt, ziEnd );

						//folosim varianta initala, deoarece la formula data de Sica, nr de zile disponibile creste cu 1 pt anumiti ani
						nrZileDisponibile += ( nrZileCOAn*8*nrZileAngPerLuna )/( 12*8*DateTime.DaysInMonth( dataStart.Year, i ));
					}
				}

				if( nrZileDisponibile>nrZileCOAn )
				{
					nrZileDisponibile = nrZileCOAn;
				}
				if( nrZileDisponibile%1<0.5 )
				{
					return (int)nrZileDisponibile;
				}
				return (int)nrZileDisponibile+1;
			}
			catch
			{
				return 0;
			}
		}
		#endregion

		#region GetAngajatNrZileCODisponibileLunaAn
		/// <summary>
		/// Procedura calculeaza nr de zile de CO disponibile pe o luna intr-un an
		/// </summary>
		/// <param name="an">Anul</param>
		/// <param name="luna">Luna</param>
		/// <param name="ziStart">Prima zi a intervalului</param>
		/// <param name="ziEnd">Ultima zi a intervalului</param>
		/// <returns>Returneaza nr de zile de CO</returns>
		public int GetAngajatNrZileCODisponibileLunaAn( int an, int luna, int ziStart, int ziEnd )
		{
			return ziEnd-ziStart+1;
		}
		#endregion

		#region GetAngajatNrZileAbsenteTipLuna
		/// <summary>
		/// Procedura calculeaza nr de zile de absenta de un anumit tip pe luna
		/// </summary>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data se sfarsit</param>
		/// <param name="tipAbsente">Tipul absentei</param>
		/// <returns>Returneaza nr de zile de absenta</returns>
		public int GetAngajatNrZileAbsenteTipLuna( DateTime dataStart, DateTime dataEnd, string tipAbsente )
		{
			try
			{
				Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
				DataSet ds = pa.GetAngajatNrZileAbsenteTipLuna( angajatId, dataStart, dataEnd, tipAbsente );
				
				return TimpAbsente( ds, pa, dataStart, dataEnd );
			}
			catch
			{
				return 0;
			}
		}
		#endregion

		#region GetAngajatNrZileCuSarbatoriAbsenteTipLuna
		/// <summary>
		/// Procedura calculeaza nr de zile de absente de un anumit tip
		/// </summary>
		/// <param name="dataStart">Data de inceput</param>
		/// <param name="dataEnd">Data de sfarsit</param>
		/// <param name="tipAbsente">Tipul absentei</param>
		/// <returns>Returneaza nr de zile calculete</returns>
		public int GetAngajatNrZileCuSarbatoriAbsenteTipLuna( DateTime dataStart, DateTime dataEnd, string tipAbsente )
		{
			try
			{
				Data.PontajAngajat pa = new Data.PontajAngajat( settings.ConnectionString );
				DataSet ds = pa.GetAngajatNrZileAbsenteTipLuna( angajatId, dataStart, dataEnd, tipAbsente );
				
				return TimpAbsenteCuWeekend( ds, pa, dataStart, dataEnd );
			}
			catch
			{
				return 0;
			}
		}
		#endregion

		#region GetIntervaleSchimbariLuna
		/// <summary>
		/// Procedura selecteaza schimbarile dintr-o luna 
		/// </summary>
		/// <param name="luna">Luna</param>
		/// <returns>Returneaza un sir de obiecte care contine aceste date</returns>
		public Data.IntervaleSchimbariLuna[] GetIntervaleSchimbariLuna( int luna )
		{
			return new Data.PontajAngajat( settings.ConnectionString ).GetIntervaleSchimbariLuna( luna, angajatId, settings.ConnectionString );
		}
		#endregion

		#region GetIntervaleAngajat
		/// <summary>
		/// Procedura selecteaza intervalele unui angajat
		/// </summary>
		/// <param name="luna">Luna pentru care se selecteaza</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetIntervaleAngajat( int luna )
		{
			return new Data.PontajAngajat( settings.ConnectionString ).GetIntervaleAngajat( luna, angajatId);
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
			return new Data.PontajAngajat( settings.ConnectionString ).GetNrZileLucratoareInterval( dataStart, dataEnd );
		}
		#endregion

		#region TimpLuna
		/// <summary>
		/// Procedura calculeaza nr de zile dintr-o luna
		/// </summary>
		/// <param name="ds"></param>
		/// <returns>Returneaza timpul lucrat</returns>
		private TimeSpan TimpLuna( DataSet ds )
		{
			TimeSpan timpLucrat = new TimeSpan( 0 );
			foreach( DataRow dr in ds.Tables[ 0 ].Rows )
			{
				DateTime oraSt = (DateTime)dr[ "OraStart" ];
				DateTime oraEnd = (DateTime)dr[ "OraEnd" ];
				TimeSpan ts = new TimeSpan( timpLucrat.Ticks+oraEnd.Ticks-oraSt.Ticks );
				timpLucrat = ts;
			}
			return timpLucrat;
		}
		#endregion

		#region TimpAbsente
		/// <summary>
		/// Returneaza nr de zile absentate dintr-o luna.
		/// </summary>
		/// <param name="ds"></param>
		/// <param name="pa"></param>
		/// <param name="primaZi"></param>
		/// <param name="ultimaZi"></param>
		/// <returns></returns>
		private int TimpAbsente( DataSet ds, Salaries.Data.PontajAngajat pa, DateTime primaZi, DateTime ultimaZi )
		{
			int timpAbsente = 0;
			foreach( DataRow dr in ds.Tables[ 0 ].Rows )
			{
				DateTime dataSt = (DateTime)dr[ "DataStart" ];
				dataSt = dataSt > primaZi ? dataSt : primaZi;

				DateTime dataEnd = (DateTime)dr[ "DataEnd" ];
				dataEnd = dataEnd < ultimaZi ? dataEnd : ultimaZi;

				TimeSpan ts = new TimeSpan( dataEnd.Ticks-dataSt.Ticks );
				timpAbsente += ts.Days+1-pa.GetNrZileSarbatoareInterval( dataSt, dataEnd );
			}
			return timpAbsente;
		}
		#endregion

		#region TimpAbsenteCuWeekend
		/// <summary>
		/// Returneaza nr de zile absentate dintr-o luna
		/// </summary>
		/// <param name="ds"></param>
		/// <param name="pa"></param>
		/// <param name="primaZi"></param>
		/// <param name="ultimaZi"></param>
		/// <returns></returns>
		private int TimpAbsenteCuWeekend( DataSet ds, Salaries.Data.PontajAngajat pa, DateTime primaZi, DateTime ultimaZi )
		{
			int timpAbsente = 0;
			foreach( DataRow dr in ds.Tables[ 0 ].Rows )
			{
				DateTime dataSt = (DateTime)dr[ "DataStart" ];
				dataSt = dataSt > primaZi ? dataSt : primaZi;

				DateTime dataEnd = (DateTime)dr[ "DataEnd" ];
				dataEnd = dataEnd < ultimaZi ? dataEnd : ultimaZi;

				TimeSpan ts = new TimeSpan( dataEnd.Ticks-dataSt.Ticks );
				timpAbsente += ts.Days+1;
			}
			return timpAbsente;
		}
		#endregion

		#region GetIntervalProgramLucru
		/// <summary>
		/// Procedura selecteaza programul de lucru pe anumite intervale ale angajatului
		/// </summary>
		/// <param name="lunaID">Luna pentru care se selecteaza</param>
		/// <returns>Returneaza un sir de obiecte care contin aceste date</returns>
		private Data.IntervaleSchimbariLuna[] GetIntervalProgramLucru( int lunaID )
		{
			Data.IntervaleSchimbariLuna []intervFinal;
			try
			{
				Data.IntervaleSchimbariLuna []interv = GetIntervaleSchimbariLuna( lunaID );
				intervFinal = new Salaries.Data.IntervaleSchimbariLuna[ interv.Length ];

				int index = 0;
				intervFinal[ index ] = interv[ index ];
			
				for( int i=1; i<interv.Length; i++ )
				{
					if( interv[ i ].ProgramLucru != intervFinal[ index ].ProgramLucru )
					{
						intervFinal[ index ].DataEnd = interv[ i-1 ].DataEnd;
						index++;
						intervFinal[ index ] = interv[ i ];
					}
				}

				intervFinal[ index ].DataEnd = interv[ interv.Length-1 ].DataEnd;
			}
			catch
			{
				intervFinal = new Data.IntervaleSchimbariLuna[ 0 ];
			}
			return intervFinal;
		}
		#endregion

		#region GetNrZileIntervaleIntreruperi
		/// <summary>
		/// Procedura determina numarul de zile cu intreruperi de contracte de munca
		/// </summary>
		/// <param name="angajatId">Angajatul pentru care sa cauta numarul de zile</param>
		/// <param name="lunaId">Luna pentru care se cauta numarul de zile</param>
		/// <returns>Returneaza numarul de zile alocate intreruperilor de contracte de munca</returns>
		/// <remarks>Adaugat:	Oprescu Claudia
		///			 Data:		15.11.2006
		/// </remarks>
		public int GetNrZileIntervaleIntreruperi( int angajatId, int lunaId )
		{
			return new Data.PontajAngajat( settings.ConnectionString ).GetNrZileIntervaleIntreruperi(angajatId, lunaId);
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
			return new Data.PontajAngajat( settings.ConnectionString ).GetNrZileConcediuBoalaPlatiteFirma(angajatorId);
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
			return new Data.PontajAngajat( settings.ConnectionString ).GetAllZileLucratoareLuna(luna);
		}
		#endregion
	}
}
