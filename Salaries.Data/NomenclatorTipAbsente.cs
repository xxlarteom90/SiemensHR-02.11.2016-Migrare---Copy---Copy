using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{

	public struct TipAbsente
	{
		public int TipAbsentaID;
		public string Denumire;
		public float Procent;
		public string Descriere;
		public bool Medical;
		public string CodAbsenta;
		public bool Modificare;
		public bool Folosire;
		public bool Lucratoare;
	}


	/// <summary>
	/// Summary description for NomenclatorTipAbsente.
	/// </summary>
	public class NomenclatorTipAbsente : Salaries.Data.DbObject
	{
		#region Constructor

		public NomenclatorTipAbsente( string connectionString ) : base( connectionString )
		{
		}

		#endregion
		
		#region InsertTipAbsente
		/// <summary>
		/// Procedura adauga un tip de absenta
		/// </summary>
		/// <param name="denumire">Denumirea</param>
		/// <param name="procent">Procentul</param>
		/// <param name="descriere">Descrierea</param>
		/// <param name="medical">Absenta medicala sau nu</param>
		/// <param name="codAbsenta">Codul absentei</param>
		/// <param name="modificare">Poate fi modificata sau nu</param>
		/// <param name="folosire"></param>
		/// <param name="lucratoare">Absenta lucratoare</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool InsertTipAbsente
			(
			string denumire, 
			float procent,
			string descriere,
			bool medical,
			string codAbsenta,
			bool modificare,
			bool folosire,
			bool lucratoare
			)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@TipAbsentaID", SqlDbType.Int, 4),
					new SqlParameter("@Denumire", SqlDbType.NVarChar, 255),
					new SqlParameter("@Procent", SqlDbType.Real, 8),
					new SqlParameter("@Descriere", SqlDbType.NText, 16),
					new SqlParameter("@Medical", SqlDbType.Bit, 1),
					new SqlParameter("@CodAbsenta", SqlDbType.NVarChar, 5),
					new SqlParameter("@Modificare", SqlDbType.Bit, 1),
					new SqlParameter("@Folosire", SqlDbType.Bit, 1),
					new SqlParameter("@Lucratoare", SqlDbType.Bit, 1),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = -1;
			parameters[ 1 ].Value = denumire;
			parameters[ 2 ].Value = procent;
			parameters[ 3 ].Value = descriere;
			parameters[ 4 ].Value = medical;
			parameters[ 5 ].Value = codAbsenta;
			parameters[ 6 ].Value = modificare;
			parameters[ 7 ].Value = folosire;
			parameters[ 8 ].Value = lucratoare;
			parameters[ 9 ].Value = 0; //insert
			RunProcedure("tm_InsertUpdateDeleteTipAbsenta", parameters, out numAffected);
			return (numAffected > 0);
		}
		#endregion
		
		#region InsertTipAbsente
		/// <summary>
		/// Procedura adauga un tip de absenta
		/// </summary>
		/// <param name="tipAbs">Obiectul care contine datele tipului de absenta</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool InsertTipAbsente( TipAbsente tipAbs ) 
		{
			return this.InsertTipAbsente( tipAbs.Denumire, tipAbs.Procent, tipAbs.Descriere, tipAbs.Medical, tipAbs.CodAbsenta, tipAbs.Modificare, tipAbs.Folosire, tipAbs.Lucratoare );
		}

		#endregion

		#region UpdateTipAbsente
		/// <summary>
		/// Procedura actualizeaza un tip de absente
		/// </summary>
		/// <param name="tipAbsentaID">Id-ul absentei</param>
		/// <param name="denumire">Denumirea</param>
		/// <param name="procent">Procentul</param>
		/// <param name="descriere">Descrierea</param>
		/// <param name="medical">Absenta medicala</param>
		/// <param name="codAbsenta">Codul absentei</param>
		/// <param name="modificare">Se poate modifica sau nu</param>
		/// <param name="folosire"></param>
		/// <param name="lucratoare">Absenta lucratoare</param>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altefel</returns>
		public bool UpdateTipAbsente
			(
			int tipAbsentaID,
			string denumire, 
			float procent,
			string descriere,
			bool medical,
			string codAbsenta,
			bool modificare,
			bool folosire,
			bool lucratoare
			)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@TipAbsentaID", SqlDbType.Int, 4),
					new SqlParameter("@Denumire", SqlDbType.NVarChar, 255),
					new SqlParameter("@Procent", SqlDbType.Real, 8),
					new SqlParameter("@Descriere", SqlDbType.NText, 16),
					new SqlParameter("@Medical", SqlDbType.Bit, 1),
					new SqlParameter("@CodAbsenta", SqlDbType.NVarChar, 5),
					new SqlParameter("@Modificare", SqlDbType.Bit, 1),
					new SqlParameter("@Folosire", SqlDbType.Bit, 1),
					new SqlParameter("@Lucratoare", SqlDbType.Bit, 1),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = tipAbsentaID;
			parameters[ 1 ].Value = denumire;
			parameters[ 2 ].Value = procent;
			parameters[ 3 ].Value = descriere;
			parameters[ 4 ].Value = medical;
			parameters[ 5 ].Value = codAbsenta;
			parameters[ 6 ].Value = modificare;
			parameters[ 7 ].Value = folosire;
			parameters[ 8 ].Value = lucratoare;
			parameters[ 9 ].Value = 1; //update
			RunProcedure("tm_InsertUpdateDeleteTipAbsenta", parameters, out numAffected);
			return (numAffected > 0);
		}
		#endregion

		#region UpdateTipAbsente
		/// <summary>
		/// Procedura actualizeaza un tip de absenta
		/// </summary>
		/// <param name="tipAbs">Obiectul care contine tipul de absenta</param>
		/// <returns>Returneaza true daca se poate face actualizarea si false altfel</returns>
		public bool UpdateTipAbsente( TipAbsente tipAbs )
		{
			return this.UpdateTipAbsente( tipAbs.TipAbsentaID, tipAbs.Denumire, tipAbs.Procent, tipAbs.Descriere, tipAbs.Medical, tipAbs.CodAbsenta, tipAbs.Modificare, tipAbs.Folosire, tipAbs.Lucratoare );
		}
		#endregion

		#region DeleteTipAbsente
		/// <summary>
		/// Procedura sterge un tip de absenta
		/// </summary>
		/// <param name="tipAbsentaID">Tipul de absenta actualizat</param>
		/// <returns>Returneaza true daca s-a facut stergerea si false altfel</returns>
		public bool DeleteTipAbsente( int tipAbsentaID )
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@TipAbsentaID", SqlDbType.Int, 4),
					new SqlParameter("@Denumire", SqlDbType.NVarChar, 255),
					new SqlParameter("@Procent", SqlDbType.Real, 8),
					new SqlParameter("@Descriere", SqlDbType.NText, 16),
					new SqlParameter("@Medical", SqlDbType.Bit, 1),
					new SqlParameter("@CodAbsenta", SqlDbType.NVarChar, 5),
					new SqlParameter("@Modificare", SqlDbType.Bit, 1),
					new SqlParameter("@Folosire", SqlDbType.Bit, 1),
					new SqlParameter("@Lucratoare", SqlDbType.Bit, 1),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = tipAbsentaID;
			parameters[ 1 ].Value = "";
			parameters[ 2 ].Value = 0;
			parameters[ 3 ].Value = "";
			parameters[ 4 ].Value = false;
			parameters[ 5 ].Value = "";
			parameters[ 6 ].Value = false;
			parameters[ 7 ].Value = false;
			parameters[ 8 ].Value = false;
			parameters[ 9 ].Value = 2; //delete
			RunProcedure("tm_InsertUpdateDeleteTipAbsenta", parameters, out numAffected);
			return (numAffected > 0);
		}

		#endregion

		#region GetTipuriAbsente
		/// <summary>
		/// Returneaza toate absentele din sistem.
		/// </summary>
		/// <returns> Un DataSet cu toate absentele din sistem.</returns>
		public DataSet GetTipuriAbsente()
		{			
			try
			{
				DataSet ds = RunProcedure( "tm_GetTipuriAbsente", new SqlParameter[ 0 ], "TipuriAbsente" );
				
				return ds;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetTipuriAbsenteLunaCurenta
		/// <summary>
		/// Returneaza toate absentele din sistem pentru luna curenta, deoarece in luna
		/// ianuarie avem un tip de absenta in plus(concediu de odihna anul precedent).
		/// </summary>
		/// <returns> Un DataSet cu toate absentele din sistem, aferente lunii curente.
		/// </returns>
		public DataSet GetTipuriAbsenteLunaCurenta()
		{		
			DataSet dsTipAbsente = new DataSet();

			try
			{
				SqlParameter[] parameters = {};

				dsTipAbsente = RunProcedure( "tm_GetTipuriAbsenteLunaCurenta", parameters, "TipuriAbsente" );

				return dsTipAbsente;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetTipuriAbsente
		/// <summary>
		/// Procedura selecteaza un tip de absenta
		/// </summary>
		/// <param name="tipAbsentaID">Id-ul tipului de absenta selectat</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipuriAbsente( int tipAbsentaID )
		{			
			try
			{
				SqlParameter []parameters = 
					{
						new SqlParameter("@TipAbsentaID", SqlDbType.Int, 4)
					};

				parameters[ 0 ].Value = tipAbsentaID;
				DataSet ds = RunProcedure( "tm_GetTipIntervalAbsenta", parameters , "TipuriAbsente" );

				return ds;
			}
			catch
			{
				return null;
			}
		}
		#endregion

		#region GetDetaliiTipuriAbsente
		/// <summary>
		/// Procedura selecteaza detaliile tipurilor de absente
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public TipAbsente[] GetDetaliiTipuriAbsente()
		{
			try
			{
				DataSet ds = RunProcedure( "tm_GetTipuriAbsente", new SqlParameter[ 0 ], "TipuriAbsente" );
				using( ds )
				{
					TipAbsente []tipAbs = new TipAbsente[ ds.Tables[ "TipuriAbsente" ].Rows.Count ];
					int i = -1;
					foreach( DataRow dr in ds.Tables[ "TipuriAbsente" ].Rows )
					{
						i++;
						tipAbs[ i ].TipAbsentaID = int.Parse( dr[ "TipAbsentaID" ].ToString());
						tipAbs[ i ].Denumire = dr[ "Denumire" ].ToString();
						tipAbs[ i ].Procent = float.Parse( dr[ "Procent" ].ToString());
						tipAbs[ i ].Descriere = dr[ "Descriere" ].ToString();
						tipAbs[ i ].Medical = (bool)dr[ "Medical" ];
						tipAbs[ i ].CodAbsenta = dr[ "CodAbsenta" ].ToString();
						tipAbs[ i ].Modificare = (bool)dr[ "Modificare" ];
						tipAbs[ i ].Folosire = (bool)dr[ "Folosire" ];
						tipAbs[ i ].Lucratoare = (bool)dr[ "Lucratoare" ];
					}
					return tipAbs;
				}
			}
			catch
			{
				TipAbsente []tAbs = new TipAbsente[ 1 ];
				tAbs[ 0 ].TipAbsentaID = -1;
				return tAbs;
			}
		}
		#endregion

		#region GetDetaliiTipuriAbsente
		/// <summary>
		/// Procedura selecteaza detaliile unui tip de absenta
		/// </summary>
		/// <param name="tipAbsentaID">Id-ul tipului de absenta selectat</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public TipAbsente GetDetaliiTipuriAbsente( int tipAbsentaID )
		{
			try
			{
				SqlParameter []parameters = 
					{
						new SqlParameter("@TipAbsentaID", SqlDbType.Int, 4)
					};

				parameters[ 0 ].Value = tipAbsentaID;
				DataSet ds = RunProcedure( "tm_GetTipIntervalAbsenta", parameters, "TipuriAbsente" );
				
				using( ds )
				{
					TipAbsente tipAbs = new TipAbsente();

					DataRow dr = ds.Tables[ "TipuriAbsente" ].Rows[ 0 ];
					
					tipAbs.TipAbsentaID = int.Parse( dr[ "TipAbsentaID" ].ToString());
					tipAbs.Denumire = dr[ "Denumire" ].ToString();
					tipAbs.Procent = float.Parse( dr[ "Procent" ].ToString());
					tipAbs.Descriere = dr[ "Descriere" ].ToString();
					tipAbs.Medical = (bool)dr[ "Medical" ];
					tipAbs.CodAbsenta = dr[ "CodAbsenta" ].ToString();
					tipAbs.Modificare = (bool)dr[ "Modificare" ];
					tipAbs.Folosire = (bool)dr[ "Folosire" ];
					tipAbs.Lucratoare = (bool)dr[ "Lucratoare" ];
					
					return tipAbs;
				}
			}
			catch
			{
				TipAbsente tAbs = new TipAbsente();
				tAbs.TipAbsentaID = -1;
				return tAbs;
			}
		}
		#endregion
	}
}
