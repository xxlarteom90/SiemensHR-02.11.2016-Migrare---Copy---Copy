using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using SiemensHR.utils;

namespace SiemensHR.Classes
{

	public struct IntervalSchimbari
	{
		/*public DateTime DataStart;
		public DateTime DataEnd;
		public int ProgramLucru;
		public double SalariuBaza;
		public double IndemnizatieConducere;
		public int Invaliditate;
		public string InvaliditateText;
		public int CategorieID;
		public string CategorieText;*/
	}

	/// <summary>
	/// Summary description for IstoricSchimbareDateAngajat.
	/// </summary>
	public class IstoricSchimbareDateAngajat
	{

		/*private DataSet m_ds;
		private long m_AngajatID;
		private Salaries.Configuration.ModuleSettings settings;

		public IstoricSchimbareDateAngajat( long AngajatID )
		{
			m_AngajatID = AngajatID;
			LoadIstoricSchimbari();
		}

		public DataSet getDataSet
		{
			get {return m_ds;}
			set {}
		}

		private void LoadIstoricSchimbari()
		{
			try
			{
				if( m_ds != null )
				{
					m_ds.Tables.Clear();
				}
				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				SqlConnection m_con = new SqlConnection(settings.ConnectionString);
				SqlCommand myCommand = new SqlCommand("GetIstoricSchimbariAngajat", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));

				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				m_ds = new DataSet();
				dAdapt.Fill(m_ds);

				IntervalSchimbari []intervale = new IntervalSchimbari[ m_ds.Tables[ 0 ].Rows.Count ];
				intervale = GetIntervaleSchimbariAngajat();

				DataSet ds = new DataSet();
				DataTable dt = new DataTable( "IntervaleSchibari" );

				DataColumn dcDataSt = new DataColumn( "DataStart", Type.GetType( "System.DateTime" ));
				DataColumn dcDataEnd = new DataColumn( "DataEnd", Type.GetType( "System.DateTime" ));
				DataColumn dcProgramLucru = new DataColumn( "ProgramLucru", Type.GetType( "System.Int32" ));
				DataColumn dcSalariuBaza = new DataColumn( "SalariuBaza", Type.GetType( "System.Decimal" ));
				DataColumn dcIndemnizatieCond = new DataColumn( "IndemnizatieConducere", Type.GetType( "System.Decimal" ));
				DataColumn dcInvaliditate = new DataColumn( "Invaliditate", Type.GetType( "System.Int16" ));
				DataColumn dcInvaliditateText = new DataColumn( "InvaliditateText", Type.GetType( "System.String" ));
				DataColumn dcCategorieID = new DataColumn( "CategorieID", Type.GetType( "System.Int32" ));
				DataColumn dcCategorieText = new DataColumn( "CategorieText", Type.GetType( "System.String" ));

				dt.Columns.Add( dcDataSt ); dt.Columns.Add( dcDataEnd ); dt.Columns.Add( dcProgramLucru ); dt.Columns.Add( dcSalariuBaza );
				dt.Columns.Add( dcIndemnizatieCond ); dt.Columns.Add( dcInvaliditate ); dt.Columns.Add( dcInvaliditateText ); dt.Columns.Add( dcCategorieID ); dt.Columns.Add( dcCategorieText );

				foreach( IntervalSchimbari ints in intervale )
				{
					object []obj = new object[ 9 ];
					obj[ 0 ] = ints.DataStart;
					obj[ 1 ] = ints.DataEnd;
					obj[ 2 ] = ints.ProgramLucru;
					obj[ 3 ] = ints.SalariuBaza;
					obj[ 4 ] = ints.IndemnizatieConducere;
					obj[ 5 ] = ints.Invaliditate;
					obj[ 6 ] = ints.InvaliditateText;
					obj[ 7 ] = ints.CategorieID;
					obj[ 8 ] = ints.CategorieText;

					dt.Rows.Add( obj );
				}
				
				if( m_ds != null )
				{
					m_ds.Tables.Clear();
				}
				m_ds.Tables.Add( dt );

			}
			catch
			{
			}
		}

		public IntervalSchimbari []GetIntervaleSchimbariAngajat()
		{
			IntervalSchimbari []intervale = new IntervalSchimbari[ m_ds.Tables[ 0 ].Rows.Count ];
			
			int norma = int.Parse( m_ds.Tables[ 0 ].Rows[ 0 ][ "ProgramLucru" ].ToString());
			double salariuBaza = double.Parse( m_ds.Tables[ 0 ].Rows[ 0 ][ "SalariuBaza" ].ToString());
			double indemnizatieConducere = double.Parse( m_ds.Tables[ 0 ].Rows[ 0 ][ "IndemnizatieConducere" ].ToString());
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
					double.Parse( dr[ "SalariuBaza" ].ToString()) != salariuBaza ||
					double.Parse( dr[ "IndemnizatieConducere" ].ToString()) != indemnizatieConducere ||
					int.Parse( dr[ "Invaliditate" ].ToString()) != invaliditate ||
					dr[ "Denumire" ].ToString() != categorieText )
				{
					intervale[ j ].DataEnd = (DateTime)m_ds.Tables[ 0 ].Rows[ i-1 ][ "Data" ];

					j++;

					intervale[ j ].DataStart = (DateTime)m_ds.Tables[ 0 ].Rows[ i ][ "Data" ];

					norma = int.Parse( m_ds.Tables[ 0 ].Rows[ i ][ "ProgramLucru" ].ToString());
					salariuBaza = double.Parse( m_ds.Tables[ 0 ].Rows[ i ][ "SalariuBaza" ].ToString());
					indemnizatieConducere = double.Parse( m_ds.Tables[ 0 ].Rows[ i ][ "IndemnizatieConducere" ].ToString());
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
			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.AngajatId = m_AngajatID;
			ang.LoadAngajat();
			intervale[ j ].DataEnd = ang.DataPanaLa;
			
            intervale[ 0 ].DataStart = ang.DataDeLa;

			if( intervale[ j ].DataEnd == DateTime.MinValue)
			{
				intervale[ j ].DataEnd = DateTime.MaxValue;
			}
			
			IntervalSchimbari []intervaleFinale = new IntervalSchimbari[ j+1 ];
			for( int i=0; i<j+1; i++ )
			{
				intervaleFinale[ i ] = intervale[ i ];
			}
			
			return intervaleFinale;
		}

		public DataSet GetAllInvaliditati()
		{
			try
			{
				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				SqlConnection m_con = new SqlConnection(settings.ConnectionString);
				SqlCommand myCommand = new SqlCommand("GetAllInvaliditati", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				DataSet ds = new DataSet();
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				m_ds = new DataSet();
				dAdapt.Fill(ds);	
				return ds;
			}
			catch
			{
				return null;
			}
		}


		public void InsertSchimbareProgramLucru( IntervalSchimbari intsch )
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("tm_UpdatePerioadaZileNormaLucruAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 8, m_AngajatID ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ProgramLucru", SqlDbType.Int, 4, intsch.ProgramLucru ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, intsch.DataStart.ToShortDateString()));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, intsch.DataEnd.ToShortDateString()));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}

		public void InsertSchimbareSalariuBaza( IntervalSchimbari intsch )
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("tm_UpdatePerioadaZileSalariuBazaActualAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 8, m_AngajatID ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SalariuBaza", SqlDbType.Money, 8, intsch.SalariuBaza ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, intsch.DataStart.ToShortDateString()));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, intsch.DataEnd.ToShortDateString()));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	
		}

		public void InsertSchimbareIndemnizatieConducere( IntervalSchimbari intsch )
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("tm_UpdatePerioadaZileIndeminzatieConducereAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 8, m_AngajatID ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IndemnizatieConducere", SqlDbType.Money, 8, intsch.IndemnizatieConducere ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, intsch.DataStart.ToShortDateString()));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, intsch.DataEnd.ToShortDateString()));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	
		}

		public void InsertSchimbareInvaliditate( IntervalSchimbari intsch )
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("tm_UpdatePerioadaZileInvaliditateAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 8, m_AngajatID ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Invaliditate", SqlDbType.SmallInt, 2, intsch.Invaliditate ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, intsch.DataStart.ToShortDateString()));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, intsch.DataEnd.ToShortDateString()));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	
		}

		public void InsertSchimbareCategorie( IntervalSchimbari intsch )
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("tm_UpdatePerioadaZileCategorieIDAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 8, m_AngajatID ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, intsch.CategorieID ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, intsch.DataStart.ToShortDateString()));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, intsch.DataEnd.ToShortDateString()));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}

		public void InsertCapatIntervalSchimbareAngajat( IntervalSchimbari intsch )
		{
			DateTime oraStart = new DateTime( intsch.DataEnd.Year, intsch.DataEnd.Month, intsch.DataEnd.Day, 0, 0, 0 );
			DateTime oraEnd = new DateTime( intsch.DataEnd.Year, intsch.DataEnd.Month, intsch.DataEnd.Day, 0, 0, 0 );

			DataSet myDs = new Salaries.Business.NomenclatorTipOreLucrate().GetTipuriOreLucrate();
			if( myDs != null && myDs.Tables[ 0 ].Rows.Count > 0 )
			{

				int tipIntervalID = int.Parse( myDs.Tables[ 0 ].Rows[ 0 ][ "TipIntervalID" ].ToString());

				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				SqlConnection m_con = new SqlConnection(settings.ConnectionString);
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteCapatIntervalAngajat", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalAngajatID", SqlDbType.Int, 4, -1 ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, intsch.DataEnd.ToShortDateString()));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipIntervalID", SqlDbType.Int, 4, tipIntervalID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@OraStart", SqlDbType.DateTime, 8, oraStart ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@OraEnd", SqlDbType.DateTime, 8, oraEnd ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, m_AngajatID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ProgramLucru", SqlDbType.Int, 4, intsch.ProgramLucru ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SalariuBaza", SqlDbType.Money, 8, intsch.SalariuBaza ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IndemnizatieConducere", SqlDbType.Money, 8, intsch.IndemnizatieConducere ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Invaliditate", SqlDbType.SmallInt, 2, intsch.Invaliditate ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, intsch.CategorieID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0 ));


				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);	
			}
		}

		public void UpdateCapatIntervalSchimbareAngajat( IntervalSchimbari intsch, int IntervalID )
		{
			DateTime oraStart = new DateTime( intsch.DataEnd.Year, intsch.DataEnd.Month, intsch.DataEnd.Day, 0, 0, 0 );
			DateTime oraEnd = new DateTime( intsch.DataEnd.Year, intsch.DataEnd.Month, intsch.DataEnd.Day, 0, 0, 0 );

			DataSet myDs = new Salaries.Business.NomenclatorTipOreLucrate().GetTipuriOreLucrate();
			if( myDs != null && myDs.Tables[ 0 ].Rows.Count > 0 )
			{

				int tipIntervalID = int.Parse( myDs.Tables[ 0 ].Rows[ 0 ][ "TipIntervalID" ].ToString());

				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				SqlConnection m_con = new SqlConnection(settings.ConnectionString);
				SqlCommand myCommand = new SqlCommand("tm_InsertUpdateDeleteCapatIntervalAngajat", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IntervalAngajatID", SqlDbType.Int, 4, IntervalID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, intsch.DataEnd.ToShortDateString()));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipIntervalID", SqlDbType.Int, 4, tipIntervalID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@OraStart", SqlDbType.DateTime, 8, oraStart ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@OraEnd", SqlDbType.DateTime, 8, oraEnd ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, m_AngajatID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ProgramLucru", SqlDbType.Int, 4, intsch.ProgramLucru ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SalariuBaza", SqlDbType.Money, 8, intsch.SalariuBaza ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IndemnizatieConducere", SqlDbType.Money, 8, intsch.IndemnizatieConducere ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Invaliditate", SqlDbType.SmallInt, 2, intsch.Invaliditate ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, intsch.CategorieID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1 ));//update


				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);	
			}
		}

		public int GetCategorieCorspunzatoareDinLunaActiva( int categID )
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("salarii_GetCategorie", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, categID ));//update

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet dsCategorie = new DataSet();
			dAdapt.Fill(dsCategorie);

            int angajatorID = 0;
			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.AngajatId = m_AngajatID;
			ang.LoadAngajat();
			angajatorID = ang.AngajatorId;
			myCommand = new SqlCommand("salarii_GetAngajatiCategoriiLunaActiva", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, angajatorID ));

			dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			string categText = "";
			if( dsCategorie != null && dsCategorie.Tables[ 0 ].Rows.Count > 0 )
			{
				categText = dsCategorie.Tables[ 0 ].Rows[ 0 ][ "Denumire" ].ToString();
			}

			if( ds != null && ds.Tables[ 0 ].Rows.Count > 0 )
			{
				foreach( DataRow dr in ds.Tables[ 0 ].Rows )
				{
					if( dr[ "Denumire" ].ToString() == categText )
					{
						return int.Parse( dr[ "CategorieID" ].ToString());
					}
				}
				
			}
			return -1;
		}

		public DataSet GetCapatIntervalAngajatZi( DateTime data )
		{
			try
			{
				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				SqlConnection m_con = new SqlConnection(settings.ConnectionString);
				SqlCommand myCommand = new SqlCommand("tm_GetCapatIntervalAngajatZi", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, data ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, m_AngajatID ));

				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);

				return ds;
			}
			catch
			{
				return null;
			}
		}*/

		/*public void UpdateSchimbare(int departamentID, DateTime new_dataStart, DateTime old_dataStart)
		{
			SqlConnection m_con = new SqlConnection(ConfigurationSettings.AppSettings["ConnStr"]);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteIstoricDepartament", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, m_AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DepartamentID", SqlDbType.Int, 4, departamentID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, new_dataStart.ToShortDateString()));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@old_DataStart", SqlDbType.DateTime, 8, old_dataStart.ToShortDateString()));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);	
		}*/

		/*public void DeleteSchimbare( DateTime dataStart, DateTime dataEnd, long angajatID )
		{
			if( m_ds.Tables[ 0 ].Rows.Count > 1 )
			{
				IntervalSchimbari ints = GetPrevIntervalSchimbareByDataStart( dataStart );
				ints.CategorieID = GetCategorieCorspunzatoareDinLunaActiva( ints.CategorieID );
				if( ints.ProgramLucru != -1 )
				{
					settings = Salaries.Configuration.ModuleConfig.GetSettings();
					SqlConnection m_con = new SqlConnection(settings.ConnectionString);
					SqlCommand myCommand = new SqlCommand("tm_DeleteSchimbareAngajat", m_con);
					myCommand.CommandType = CommandType.StoredProcedure;

					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, m_AngajatID ));
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataStart", SqlDbType.DateTime, 8, ints.DataStart.ToShortDateString()));
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEnd", SqlDbType.DateTime, 8, ints.DataEnd.ToShortDateString()));

					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ProgramLucru", SqlDbType.Int, 4, ints.ProgramLucru ));
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SalariuBaza", SqlDbType.Money, 8, ints.SalariuBaza ));
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@IndemnizatieConducere", SqlDbType.Money, 8, ints.IndemnizatieConducere ));
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Invaliditate", SqlDbType.SmallInt, 2, ints.Invaliditate ));
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, ints.CategorieID ));

					SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
					DataSet ds = new DataSet();
					dAdapt.Fill(ds);


					LoadIstoricSchimbari();
					IntervalSchimbari intsPrevLast = GetLastIntervalSchimbare();
					intsPrevLast.CategorieID = GetCategorieCorspunzatoareDinLunaActiva( intsPrevLast.CategorieID );
					
					Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
					ang.AngajatId = m_AngajatID;
					ang.LoadAngajat();

					SqlCommand myCommandAng = new SqlCommand("UpdateAngajatDateSchimbate", m_con);
					myCommandAng.CommandType = CommandType.StoredProcedure;

					myCommandAng.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, m_AngajatID ));
					myCommandAng.Parameters.Add(UtilitiesDb.AddInputParameter("@ProgramLucru", SqlDbType.Int, 4, intsPrevLast.ProgramLucru ));
					myCommandAng.Parameters.Add(UtilitiesDb.AddInputParameter("@SalariuBaza", SqlDbType.Money, 8, intsPrevLast.SalariuBaza ));
					myCommandAng.Parameters.Add(UtilitiesDb.AddInputParameter("@IndemnizatieConducere", SqlDbType.Money, 8, intsPrevLast.IndemnizatieConducere ));
					myCommandAng.Parameters.Add(UtilitiesDb.AddInputParameter("@Invaliditate", SqlDbType.SmallInt, 2, intsPrevLast.Invaliditate ));
					myCommandAng.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, intsPrevLast.CategorieID ));
					
					dAdapt = new SqlDataAdapter(myCommandAng);
					ds = new DataSet();
					dAdapt.Fill(ds);
				}
			}
		}

		private IntervalSchimbari GetPrevIntervalSchimbareByDataStart( DateTime dataStart )
		{
			IntervalSchimbari ints = new IntervalSchimbari();
			for(int i=0; i<m_ds.Tables[ 0 ].Rows.Count; i++ )
			{
				DataRow dr = m_ds.Tables[ 0 ].Rows[ i ];
				if((DateTime)dr[ "DataStart" ] == dataStart )
				{
					if( i == 0 )
					{
						ints.DataStart = dataStart;
						ints.DataEnd = (DateTime)m_ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ];
						ints.ProgramLucru = int.Parse( m_ds.Tables[ 0 ].Rows[ 1 ][ "ProgramLucru" ].ToString());
						ints.SalariuBaza = double.Parse( m_ds.Tables[ 0 ].Rows[ 1 ][ "SalariuBaza" ].ToString());
						ints.IndemnizatieConducere = double.Parse( m_ds.Tables[ 0 ].Rows[ 1 ][ "IndemnizatieConducere" ].ToString());
						ints.Invaliditate = int.Parse( m_ds.Tables[ 0 ].Rows[ 1 ][ "Invaliditate" ].ToString());
						ints.CategorieID = int.Parse( m_ds.Tables[ 0 ].Rows[ 1 ][ "CategorieID" ].ToString());
						return ints;
					}
					else
					{
						ints.DataStart = dataStart;
						ints.DataEnd = (DateTime)m_ds.Tables[ 0 ].Rows[ i ][ "DataEnd" ];
						ints.ProgramLucru = int.Parse( m_ds.Tables[ 0 ].Rows[ i-1 ][ "ProgramLucru" ].ToString());
						ints.SalariuBaza = double.Parse( m_ds.Tables[ 0 ].Rows[ i-1 ][ "SalariuBaza" ].ToString());
						ints.IndemnizatieConducere = double.Parse( m_ds.Tables[ 0 ].Rows[ i-1 ][ "IndemnizatieConducere" ].ToString());
						ints.Invaliditate = int.Parse( m_ds.Tables[ 0 ].Rows[ i-1 ][ "Invaliditate" ].ToString());
						ints.CategorieID = int.Parse( m_ds.Tables[ 0 ].Rows[ i-1 ][ "CategorieID" ].ToString());
						return ints;
					}
				}
			}
			ints.ProgramLucru = -1;
			return ints;
		}

		public IntervalSchimbari GetIntervalSchimbareByDataInside( DateTime data )
		{
			IntervalSchimbari ints = new IntervalSchimbari();
			for(int i=0; i<m_ds.Tables[ 0 ].Rows.Count; i++ )
			{
				DataRow dr = m_ds.Tables[ 0 ].Rows[ i ];
				if((DateTime)dr[ "DataStart" ] <= data && data <= ((DateTime)dr[ "DataEnd" ]))
				{
					ints.DataStart = (DateTime)m_ds.Tables[ 0 ].Rows[ i ][ "DataStart" ];
					ints.DataEnd = data;
					ints.ProgramLucru = int.Parse( m_ds.Tables[ 0 ].Rows[ i ][ "ProgramLucru" ].ToString());
					ints.SalariuBaza = double.Parse( m_ds.Tables[ 0 ].Rows[ i ][ "SalariuBaza" ].ToString());
					ints.IndemnizatieConducere = double.Parse( m_ds.Tables[ 0 ].Rows[ i ][ "IndemnizatieConducere" ].ToString());
					ints.Invaliditate = int.Parse( m_ds.Tables[ 0 ].Rows[ i ][ "Invaliditate" ].ToString());
					ints.CategorieID = int.Parse( m_ds.Tables[ 0 ].Rows[ i ][ "CategorieID" ].ToString());
					return ints;
				}
			}
			ints.ProgramLucru = -1;
			return ints;
		}

		public IntervalSchimbari GetLastIntervalSchimbare()
		{
			IntervalSchimbari ints = new IntervalSchimbari();
			try
			{
				DataRow dr = m_ds.Tables[ 0 ].Rows[ m_ds.Tables[ 0 ].Rows.Count-1 ];

				ints.ProgramLucru = int.Parse( dr[ "ProgramLucru" ].ToString());
				ints.SalariuBaza = double.Parse( dr[ "SalariuBaza" ].ToString());
				ints.IndemnizatieConducere = double.Parse( dr[ "IndemnizatieConducere" ].ToString());
				ints.Invaliditate = int.Parse( dr[ "Invaliditate" ].ToString());
				ints.CategorieID = int.Parse( dr[ "CategorieID" ].ToString());
				return ints;
			}
			catch
			{
				ints.ProgramLucru = -1;
				return ints;
			}
		}

		public bool DataInLunaActiva( DateTime dt )
		{
			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.AngajatId = m_AngajatID;
			ang.LoadAngajat();

			Salaries.Business.Luni l = new Salaries.Business.Luni( ang.AngajatorId );
			Salaries.Data.LunaData ld = l.GetLunaActiva();

			return ( dt.Month==ld.Data.Month && dt.Year==ld.Data.Year ) ? true : false;
		}*/


	}
}
