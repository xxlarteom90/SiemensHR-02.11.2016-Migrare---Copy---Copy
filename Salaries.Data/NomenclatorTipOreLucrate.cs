using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{

	public struct TipOreLucrate
	{
		public int TipIntervalID;
		public string Denumire;
		public float Procent;
		public string Descriere;
		public float NrMaximOreSapt;
		public bool Standard;
		public bool Modificare;
		public bool Folosire;
		public bool BonuriMasa;
		public bool AplicWeekendNoapte;
	}
	
	/// <summary>
	/// Summary description for NomenclatorTipOreLucrate.
	/// </summary>
	public class NomenclatorTipOreLucrate : Salaries.Data.DbObject
	{
		#region Constructor

		public NomenclatorTipOreLucrate( string connectionString ) : base( connectionString )
		{
		}

		#endregion

		#region InsertTipOreLucrate
		/// <summary>
		/// Procedura adauga un tip de ore lucrate
		/// </summary>
		/// <param name="denumire">Denumirea</param>
		/// <param name="procent">Procentul</param>
		/// <param name="descriere">Descrierea</param>
		/// <param name="nrMaximOreSapt">Nr maxim de ore pe saptamana</param>
		/// <param name="standard">Ore standard sau nu</param>
		/// <param name="modificare">Pot fi modificate sau nu</param>
		/// <param name="folosire"></param>
		/// <param name="bonuriMasa">Se acorda bonuri de masa</param>
		/// <param name="aplicWeekendNoapte"></param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool InsertTipOreLucrate
			(
			string denumire, 
			double procent,
			string descriere,
			float nrMaximOreSapt,
			bool standard,
			bool modificare,
			bool folosire,
			bool bonuriMasa,
			bool aplicWeekendNoapte
			)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@TipIntervalID", SqlDbType.Int, 4),
					new SqlParameter("@Denumire", SqlDbType.NVarChar, 255),
					new SqlParameter("@Procent", SqlDbType.Real, 8),
					new SqlParameter("@Descriere", SqlDbType.NText, 16),
					new SqlParameter("@NrMaximOreSapt", SqlDbType.Real, 8),
					new SqlParameter("@Standard", SqlDbType.Bit, 1),
					new SqlParameter("@Modificare", SqlDbType.Bit, 1),
					new SqlParameter("@Folosire", SqlDbType.Bit, 1),
					new SqlParameter("@BonuriMasa", SqlDbType.Bit, 1),
					new SqlParameter("@AplicWeekendNoapte", SqlDbType.Bit, 1),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = -1;
			parameters[ 1 ].Value = denumire;
			parameters[ 2 ].Value = procent;
			parameters[ 3 ].Value = descriere;
			parameters[ 4 ].Value = nrMaximOreSapt;
			parameters[ 5 ].Value = standard;
			parameters[ 6 ].Value = modificare;
			parameters[ 7 ].Value = folosire;
			parameters[ 8 ].Value = bonuriMasa;

			if( !standard )
			{
				parameters[ 9 ].Value = aplicWeekendNoapte;
			}
			else
			{
				parameters[ 9 ].Value = false;
			}
			parameters[ 10 ].Value = 0; //insert

			RunProcedure("tm_InsertUpdateDeleteTipInterval", parameters, out numAffected);

			return (numAffected > 0);
		}
		#endregion
		
		#region InsertTipOreLucrate
		/// <summary>
		/// Procedura adauga un tip de ore lucrate
		/// </summary>
		/// <param name="tipOre">Obiectul care contine date despre tipul de ore</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool InsertTipOreLucrate( TipOreLucrate tipOre ) 
		{
			return this.InsertTipOreLucrate( tipOre.Denumire, tipOre.Procent, tipOre.Descriere, tipOre.NrMaximOreSapt, tipOre.Standard, tipOre.Modificare, tipOre.Folosire, tipOre.BonuriMasa, tipOre.AplicWeekendNoapte );
		}
		#endregion

		#region UpdateTipOreLucrate
		/// <summary>
		/// Procedura actualizeaza un tip de ore lucrate
		/// </summary>
		/// <param name="tipIntervalID">Id-ul tipului de interval</param>
		/// <param name="denumire">Denumirea</param>
		/// <param name="procent">Procentul</param>
		/// <param name="descriere">Descrierea</param>
		/// <param name="nrMaximOreSapt">Nr maxim de ore pe saptamana</param>
		/// <param name="standard">Ore standard sau nu</param>
		/// <param name="modificare">Pot fi modificate sau nu</param>
		/// <param name="folosire"></param>
		/// <param name="bonuriMasa">Se acorda bonuri de masa</param>
		/// <param name="aplicWeekendNoapte"></param>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool UpdateTipOreLucrate
			(
			int tipIntervalID,
			string denumire, 
			double procent,
			string descriere,
			double nrMaximOreSapt,
			bool standard,
			bool modificare,
			bool folosire,
			bool bonuriMasa,
			bool aplicWeekendNoapte
			)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@TipIntervalID", SqlDbType.Int, 4),
					new SqlParameter("@Denumire", SqlDbType.NVarChar, 255),
					new SqlParameter("@Procent", SqlDbType.Real, 8),
					new SqlParameter("@Descriere", SqlDbType.NText, 16),
					new SqlParameter("@NrMaximOreSapt", SqlDbType.Real, 8),
					new SqlParameter("@Standard", SqlDbType.Bit, 1),
					new SqlParameter("@Modificare", SqlDbType.Bit, 1),
					new SqlParameter("@Folosire", SqlDbType.Bit, 1),
					new SqlParameter("@BonuriMasa", SqlDbType.Bit, 1),
					new SqlParameter("@AplicWeekendNoapte", SqlDbType.Bit, 1),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = tipIntervalID;
			parameters[ 1 ].Value = denumire;
			parameters[ 2 ].Value = procent;
			parameters[ 3 ].Value = descriere;
			parameters[ 4 ].Value = nrMaximOreSapt;
			parameters[ 5 ].Value = standard;
			parameters[ 6 ].Value = modificare;
			parameters[ 7 ].Value = folosire;
			parameters[ 8 ].Value = bonuriMasa;
			parameters[ 9 ].Value = aplicWeekendNoapte;
			parameters[ 10 ].Value = 1; //update
			RunProcedure("tm_InsertUpdateDeleteTipInterval", parameters, out numAffected);
			return (numAffected > 0);
		}
		#endregion
	
		#region UpdateTipOreLucrate
		/// <summary>
		/// Procdura actualizeaza un tip de ore lucrate
		/// </summary>
		/// <param name="tipOre">Obiectul care contine datele tipului de ore</param>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool UpdateTipOreLucrate( TipOreLucrate tipOre )
		{
			return this.UpdateTipOreLucrate( tipOre.TipIntervalID, tipOre.Denumire, tipOre.Procent, tipOre.Descriere, tipOre.NrMaximOreSapt, tipOre.Standard, tipOre.Modificare, tipOre.Folosire, tipOre.BonuriMasa, tipOre.AplicWeekendNoapte );
		}
		#endregion

		#region DeleteTipOreLucrate
		/// <summary>
		/// Procedura sterge un tip de ore lucrate
		/// </summary>
		/// <param name="tipIntervalID">Id-ul tipului de ore</param>
		/// <returns>Returneaza true daca s-a facut stergerea si false altfel</returns>
		public bool DeleteTipOreLucrate( int tipIntervalID )
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@TipIntervalID", SqlDbType.Int, 4),
					new SqlParameter("@Denumire", SqlDbType.NVarChar, 255),
					new SqlParameter("@Procent", SqlDbType.Real, 8),
					new SqlParameter("@Descriere", SqlDbType.NText, 16),
					new SqlParameter("@Standard", SqlDbType.Bit, 1),
					new SqlParameter("@Modificare", SqlDbType.Bit, 1),
					new SqlParameter("@Folosire", SqlDbType.Bit, 1),
					new SqlParameter("@BonuriMasa", SqlDbType.Bit, 1),
					new SqlParameter("@AplicWeekendNoapte", SqlDbType.Bit, 1),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = tipIntervalID;
			parameters[ 1 ].Value = "";
			parameters[ 2 ].Value = 0;
			parameters[ 3 ].Value = "";
			parameters[ 4 ].Value = false;
			parameters[ 5 ].Value = false;
			parameters[ 6 ].Value = false;
			parameters[ 7 ].Value = false;
			parameters[ 8 ].Value = false;
			parameters[ 9 ].Value = 2; //insert

			RunProcedure("tm_InsertUpdateDeleteTipInterval", parameters, out numAffected);
			return (numAffected > 0);
		}
		#endregion

		#region GetTipuriOreLucrate
		/// <summary>
		/// Procedura selecteaza toate tipurile de ore lucrate
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipuriOreLucrate()
		{			
			try
			{
				DataSet ds = RunProcedure( "tm_GetTipuriIntervale", new SqlParameter[ 0 ], "TipuriOreLucrate" );
				
				return ds;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetTipuriOreLucrate
		/// <summary>
		/// Procedura selecteaza un tip de ore lucrate
		/// </summary>
		/// <param name="tipIntervalID">Id-ul tipului de ore lucrate</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipuriOreLucrate( int tipIntervalID )
		{			
			try
			{
				SqlParameter []parameters = 
					{
						new SqlParameter("@TipIntervalID", SqlDbType.Int, 4)
					};

				parameters[ 0 ].Value = tipIntervalID;
				DataSet ds = RunProcedure( "tm_GetTipInterval", parameters , "TipuriOreLucrate" );

				return ds;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetDetaliiTipuriOreLucrate
		/// <summary>
		/// Procedura selecteaza detaliile unui tip de ore lucrate
		/// </summary>
		/// <returns>Returneaza un sir de obiecte care contin aceste date</returns>
		public TipOreLucrate[] GetDetaliiTipuriOreLucrate()
		{
			try
			{
				DataSet ds = RunProcedure( "tm_GetTipuriIntervale", new SqlParameter[ 0 ], "TipuriOreLucrate" );
	
				using( ds )
				{
					TipOreLucrate []tipOre = new TipOreLucrate[ ds.Tables[ "TipuriOreLucrate" ].Rows.Count ];
					int i = -1;
					foreach( DataRow dr in ds.Tables[ "TipuriOreLucrate" ].Rows )
					{
						i++;
						tipOre[ i ].TipIntervalID = int.Parse( dr[ "TipIntervalID" ].ToString());
						tipOre[ i ].Denumire = dr[ "Denumire" ].ToString();
						tipOre[ i ].Procent = float.Parse( dr[ "Procent" ].ToString());
						tipOre[ i ].Descriere = dr[ "Descriere" ].ToString();
						tipOre[ i ].NrMaximOreSapt = float.Parse( dr[ "NrMaximOreSapt" ].ToString());
						tipOre[ i ].Standard = (bool)dr[ "Standard" ];
						tipOre[ i ].Modificare = (bool)dr[ "Modificare" ];
						tipOre[ i ].Folosire = (bool)dr[ "Folosire" ];
						tipOre[ i ].BonuriMasa = (bool)dr[ "BonuriMasa" ];
						tipOre[ i ].AplicWeekendNoapte = (bool)dr[ "AplicWeekendNoapte" ];
					}
					return tipOre;
				}
			}
			catch
			{
				TipOreLucrate []tOre = new TipOreLucrate[ 1 ];
				tOre[ 0 ].TipIntervalID = -1;
				return tOre;
			}
		}
		#endregion

		#region GetDetaliiTipuriOreLucrate
		/// <summary>
		/// Procedura selecteaza detaliile unui tip de ore lucrate
		/// </summary>
		/// <param name="tipIntervalID">Id-ul tipului de ore lucrate</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public TipOreLucrate GetDetaliiTipuriOreLucrate( int tipIntervalID )
		{
			try
			{
				SqlParameter []parameters = 
					{
						new SqlParameter("@TipIntervalID", SqlDbType.Int, 4)
					};

				parameters[ 0 ].Value = tipIntervalID;
				DataSet ds = RunProcedure( "tm_GetTipInterval", parameters, "TipuriOreLucrate" );
	
				using( ds )
				{
					TipOreLucrate tipOre = new TipOreLucrate();

					DataRow dr = ds.Tables[ "TipuriOreLucrate" ].Rows[ 0 ];
					
					tipOre.TipIntervalID = int.Parse( dr[ "TipIntervalID" ].ToString());
					tipOre.Denumire = dr[ "Denumire" ].ToString();
					tipOre.Procent = float.Parse( dr[ "Procent" ].ToString());
					tipOre.Descriere = dr[ "Descriere" ].ToString();
					tipOre.NrMaximOreSapt = float.Parse( dr[ "NrMaximOreSapt" ].ToString());
					tipOre.Standard = (bool)dr[ "Standard" ];
					tipOre.Modificare = (bool)dr[ "Modificare" ];
					tipOre.Folosire = (bool)dr[ "Folosire" ];
					tipOre.BonuriMasa = (bool)dr[ "BonuriMasa" ];
					tipOre.AplicWeekendNoapte = (bool)dr[ "AplicWeekendNoapte" ];
					
					return tipOre;
				}
			}
			catch
			{
				TipOreLucrate tOre = new TipOreLucrate();
				tOre.TipIntervalID = -1;
				return tOre;
			}
		}
		#endregion
	}
}

