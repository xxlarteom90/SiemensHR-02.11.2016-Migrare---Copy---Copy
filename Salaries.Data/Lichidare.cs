/*
 *	Modificat:	Oprescu Claudia
 *	Data:		10.07.2007
 *	Descriere:	A fost adaugat campul pentru Motivul plecarii. 
 */

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	public struct LichidareStruct
	{
		public int LichidareID;
		public string NrInregistrare;
		public DateTime DataLichidare;
		public long AngajatID;
		public int MotivDePlecareId;
		
		public decimal AvansuriDecontare;
		public decimal Abonamente;
		public decimal TicheteMasa;
		public decimal EchipamentLucru;
		public decimal Laptop;
		public decimal TelServiciu;
		public decimal ObiecteInventar;
		public decimal Carti;
		public decimal CD;

		public DateTime DataInregistrare;
		public string NrArticol;
		public DateTime LunaRetinere;
	}

	/// <summary>
	/// Summary description for Lichidare.
	/// </summary>
	public class Lichidare : Salaries.Data.DbObject
	{
		#region Constructor

		public Lichidare( string newConnectionString ) : base( newConnectionString )
		{
		}

		#endregion

		#region Insert

		public bool InsertLichidare
			(
			string NrInregistrare,
			DateTime DataLichidare,
			long AngajatID,
			int MotivDePlecareId,

			decimal AvansuriDecontare,
			decimal Abonamente,
			decimal TicheteMasa,
			decimal EchipamentLucru,
			decimal Laptop,
			decimal TelServiciu,
			decimal ObiecteInventar,
			decimal Carti,
			decimal CD,

			DateTime DataInregistrare,
			string NrArticol,
			DateTime LunaRetinere
			)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@NrInregistrare", SqlDbType.NVarChar, 15),
					new SqlParameter("@DataLichidare", SqlDbType.DateTime, 8),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@MotivDePlecareId", SqlDbType.Int, 4),
					new SqlParameter("@LichidareID", SqlDbType.Int, 4),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),

					new SqlParameter("@AvansuriDecontare", SqlDbType.Money, 8),
					new SqlParameter("@Abonamente", SqlDbType.Money, 8),
					new SqlParameter("@TicheteMasa", SqlDbType.Money, 8),
					new SqlParameter("@EchipamentLucru", SqlDbType.Money, 8),
					new SqlParameter("@Laptop", SqlDbType.Money, 8),
					new SqlParameter("@TelServiciu", SqlDbType.Money, 8),
					new SqlParameter("@ObiecteInventar", SqlDbType.Money, 8),
					new SqlParameter("@Carti", SqlDbType.Money, 8),
					new SqlParameter("@CD", SqlDbType.Money, 8),

					new SqlParameter("@DataInregistrare", SqlDbType.DateTime, 8),
					new SqlParameter("@NrArticol", SqlDbType.NVarChar, 15),
					new SqlParameter("@LunaRetinere", SqlDbType.DateTime, 8)
				};
			
			parameters[ 0 ].Value = NrInregistrare;
			parameters[ 1 ].Value = DataLichidare;
			parameters[ 2 ].Value = AngajatID;
			parameters[ 3 ].Value = MotivDePlecareId;
			parameters[ 4 ].Value = -1; 
			parameters[ 5 ].Value = 0; //insert

			parameters[ 6 ].Value = AvansuriDecontare;
			parameters[ 7 ].Value = Abonamente;
			parameters[ 8 ].Value = TicheteMasa;
			parameters[ 9 ].Value = EchipamentLucru;
			parameters[ 10 ].Value = Laptop;
			parameters[ 11 ].Value = TelServiciu;
			parameters[ 12 ].Value = ObiecteInventar;
			parameters[ 13 ].Value = Carti;
			parameters[ 14 ].Value = CD;

			parameters[ 15 ].Value = DataInregistrare;
			parameters[ 16 ].Value = NrArticol;
			parameters[ 17 ].Value = LunaRetinere;

			RunProcedure("InsertUpdateDeleteLichidareAngajat", parameters, out numAffected);
			return (numAffected > 0);
		}

		
		public bool InsertLichidare( LichidareStruct lichidare ) 
		{
			return this.InsertLichidare( lichidare.NrInregistrare, lichidare.DataLichidare, lichidare.AngajatID, lichidare.MotivDePlecareId, lichidare.AvansuriDecontare, lichidare.Abonamente, lichidare.TicheteMasa, lichidare.EchipamentLucru, lichidare.Laptop, lichidare.TelServiciu, lichidare.ObiecteInventar, lichidare.Carti, lichidare.CD, lichidare.DataInregistrare,lichidare.NrArticol, lichidare.LunaRetinere );
		}
		#endregion

		#region Update
		public bool UpdateLichidare
			(
			int LichidareID,
			string NrInregistrare,
			DateTime DataLichidare,
			long AngajatID,
			int MotivDePlecareId,

			decimal AvansuriDecontare,
			decimal Abonamente,
			decimal TicheteMasa,
			decimal EchipamentLucru,
			decimal Laptop,
			decimal TelServiciu,
			decimal ObiecteInventar,
			decimal Carti,
			decimal CD,

			DateTime DataInregistrare,
			string NrArticol,
			DateTime LunaRetinere
			)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@NrInregistrare", SqlDbType.NVarChar, 15),
					new SqlParameter("@DataLichidare", SqlDbType.DateTime, 8),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@MotivDePlecareId", SqlDbType.Int, 4),
					new SqlParameter("@LichidareID", SqlDbType.Int, 4),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),

					new SqlParameter("@AvansuriDecontare", SqlDbType.Money, 8),
					new SqlParameter("@Abonamente", SqlDbType.Money, 8),
					new SqlParameter("@TicheteMasa", SqlDbType.Money, 8),
					new SqlParameter("@EchipamentLucru", SqlDbType.Money, 8),
					new SqlParameter("@Laptop", SqlDbType.Money, 8),
					new SqlParameter("@TelServiciu", SqlDbType.Money, 8),
					new SqlParameter("@ObiecteInventar", SqlDbType.Money, 8),
					new SqlParameter("@Carti", SqlDbType.Money, 8),
					new SqlParameter("@CD", SqlDbType.Money, 8),

					new SqlParameter("@DataInregistrare", SqlDbType.DateTime, 8),
					new SqlParameter("@NrArticol", SqlDbType.NVarChar, 15),
					new SqlParameter("@LunaRetinere", SqlDbType.DateTime, 8)
				};
			
			parameters[ 0 ].Value = NrInregistrare;
			parameters[ 1 ].Value = DataLichidare;
			parameters[ 2 ].Value = AngajatID;
			parameters[ 3 ].Value = MotivDePlecareId;
			parameters[ 4 ].Value = LichidareID; 
			parameters[ 5 ].Value = 1; //update

			parameters[ 6 ].Value = AvansuriDecontare;
			parameters[ 7 ].Value = Abonamente;
			parameters[ 8 ].Value = TicheteMasa;
			parameters[ 9 ].Value = EchipamentLucru;
			parameters[ 10 ].Value = Laptop;
			parameters[ 11 ].Value = TelServiciu;
			parameters[ 12 ].Value = ObiecteInventar;
			parameters[ 13 ].Value = Carti;
			parameters[ 14 ].Value = CD;

			parameters[ 15 ].Value = DataInregistrare;
			parameters[ 16 ].Value = NrArticol;
			parameters[ 17 ].Value = LunaRetinere;

			RunProcedure("InsertUpdateDeleteLichidareAngajat", parameters, out numAffected);
			return (numAffected > 0);
		}

		
		public bool UpdateLichidare( LichidareStruct lichidare )
		{
			return this.UpdateLichidare( lichidare.LichidareID, lichidare.NrInregistrare, lichidare.DataLichidare, lichidare.AngajatID, lichidare.MotivDePlecareId, lichidare.AvansuriDecontare, lichidare.Abonamente, lichidare.TicheteMasa, lichidare.EchipamentLucru, lichidare.Laptop, lichidare.TelServiciu, lichidare.ObiecteInventar, lichidare.Carti, lichidare.CD, lichidare.DataInregistrare,lichidare.NrArticol, lichidare.LunaRetinere );
		}
		#endregion

		#region Delete
		
		public bool DeleteLichidare( int LichidareID )
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@NrInregistrare", SqlDbType.NVarChar, 15),
					new SqlParameter("@DataLichidare", SqlDbType.DateTime, 8),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@LichidareID", SqlDbType.Int, 4),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),

					new SqlParameter("@AvansuriDecontare", SqlDbType.Money, 8),
					new SqlParameter("@Abonamente", SqlDbType.Money, 8),
					new SqlParameter("@TicheteMasa", SqlDbType.Money, 8),
					new SqlParameter("@EchipamentLucru", SqlDbType.Money, 8),
					new SqlParameter("@Laptop", SqlDbType.Money, 8),
					new SqlParameter("@TelServiciu", SqlDbType.Money, 8),
					new SqlParameter("@ObiecteInventar", SqlDbType.Money, 8),
					new SqlParameter("@Carti", SqlDbType.Money, 8),
					new SqlParameter("@CD", SqlDbType.Money, 8),

					new SqlParameter("@DataInregistrare", SqlDbType.DateTime, 8),
					new SqlParameter("@NrArticol", SqlDbType.NVarChar, 15),
					new SqlParameter("@Carti", SqlDbType.Money, 8)
				};
			
			parameters[ 0 ].Value = "";
			parameters[ 1 ].Value = DateTime.Now;
			parameters[ 2 ].Value = 0;
			parameters[ 3 ].Value = LichidareID; 
			parameters[ 4 ].Value = 2; //delete

			parameters[ 5 ].Value = 0;
			parameters[ 6 ].Value = 0;
			parameters[ 7 ].Value = 0;
			parameters[ 8 ].Value = 0;
			parameters[ 9 ].Value = 0;
			parameters[ 10 ].Value = 0;
			parameters[ 11 ].Value = 0;
			parameters[ 12 ].Value = 0;
			parameters[ 13 ].Value = 0;

			parameters[ 14 ].Value = DateTime.Now;
			parameters[ 15 ].Value = "";
			parameters[ 16 ].Value = DateTime.Now;

			RunProcedure("InsertUpdateDeleteLichidareAngajat", parameters, out numAffected);
			return (numAffected > 0);
		}
		#endregion

		#region CheckIfLichidareCanBeAdded
		/// <summary>
		/// Procedura selecteaza lichidarile din luna curenta ale unui angajat
		/// </summary>
		/// <param name="angajatID">Angajatul pentru care se obtin lichidarile</param>
		/// <param name="dataLichidare">Luna pentru care se selecteaza lichidarile</param>
		/// <returns>Returneaza 0 daca nu angajatul nu are lichidari pe luna respectiva si id-ul lichidarii in cazul in care aceasta exista</returns>
		public int CheckIfLichidareCanBeAdded(long angajatID, DateTime dataLichidare)
		{
			SqlParameter[] parameters = 
				{
					Salaries.Data.DbObject.AddInputParameter("@AngajatID", SqlDbType.BigInt, 8, angajatID),
					Salaries.Data.DbObject.AddInputParameter("@DataLichidare", SqlDbType.DateTime, 8, dataLichidare)
				};

			DataSet ds = RunProcedure("spCheckIfLichidareCanBeAdded", parameters, "LichidariAngajat");
			if (ds.Tables[0].Rows.Count == 0)
				return 0;
			else
				return int.Parse(ds.Tables[0].Rows[0]["LichidareID"].ToString());
		}
		#endregion

		#region GetLichidareAngajat
		/// <summary>
		/// Procedura selecteaza lichidarea unui angajat daca aceasta exista
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="dataLichidare">Data lichidarii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetLichidareAngajat(long angajatId, DateTime dataLichidare)
		{
			SqlParameter[] parameters = 
				{
					Salaries.Data.DbObject.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, angajatId),
					Salaries.Data.DbObject.AddInputParameter("@DataLichidare", SqlDbType.DateTime, 8, dataLichidare)
				};

			return RunProcedure("GetLichidareAngajat", parameters, "GetLichidareAngajat");
		}
		#endregion
	}
}
