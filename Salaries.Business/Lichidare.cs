/*
 *	Modificat:	Oprescu Claudia
 *	Data:		10.07.2007
 *	Descriere:	A fost adaugat campul pentru Motiv de plecare. 
 */

using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for Lichidare.
	/// </summary>
	public class Lichidare
	{
		private Configuration.ModuleSettings settings;

		#region Constructor

		public Lichidare()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}

		#endregion

		#region Add
		public bool AddLichidare( Salaries.Data.LichidareStruct lichidare )
		{
			return this.AddLichidare( lichidare.NrInregistrare, lichidare.DataLichidare, lichidare.AngajatID, lichidare.MotivDePlecareId, lichidare.AvansuriDecontare, lichidare.Abonamente, lichidare.TicheteMasa, lichidare.EchipamentLucru, lichidare.Laptop, lichidare.TelServiciu, lichidare.ObiecteInventar, lichidare.Carti, lichidare.CD, lichidare.DataInregistrare,lichidare.NrArticol, lichidare.LunaRetinere );
		}

		public bool AddLichidare( string nrInregistrare, DateTime dataLichidare, long angajatID, int motivDePlecareId, decimal avansuriDecontare, decimal abonamente, decimal ticheteMasa, decimal echipamenteLucru, decimal laptop, decimal telServiciu, decimal obiecteInventar, decimal carti, decimal cd, DateTime dataInregistrare, string nrArticol, DateTime lunaRetinere )
		{
			return new Salaries.Data.Lichidare( this.settings.ConnectionString ).InsertLichidare( nrInregistrare, dataLichidare, angajatID, motivDePlecareId, avansuriDecontare, abonamente, ticheteMasa, echipamenteLucru, laptop, telServiciu, obiecteInventar, carti, cd, dataInregistrare, nrArticol, lunaRetinere );
		}
		#endregion 

		#region Update
		public bool UpdateLichidare( Salaries.Data.LichidareStruct lichidare )
		{
			return new Salaries.Data.Lichidare( this.settings.ConnectionString ).UpdateLichidare( lichidare );
		}

		public bool UpdateLichidare( int lichidareID, string nrInregistrare, DateTime dataLichidare, long angajatID, int motivDePlecareId, decimal avansuriDecontare, decimal abonamente, decimal ticheteMasa, decimal echipamenteLucru, decimal laptop, decimal telServiciu, decimal obiecteInventar, decimal carti, decimal cd, DateTime dataInregistrare, string nrArticol, DateTime lunaRetinere )
		{
			return new Salaries.Data.Lichidare( this.settings.ConnectionString ).UpdateLichidare( lichidareID, nrInregistrare, dataLichidare, angajatID, motivDePlecareId, avansuriDecontare, abonamente, ticheteMasa, echipamenteLucru, laptop, telServiciu, obiecteInventar, carti, cd, dataInregistrare, nrArticol, lunaRetinere );
		}
		#endregion 

		#region Delete
		public bool DeleteLichidare( Salaries.Data.LichidareStruct lichidare )
		{
			return this.DeleteLichidare( lichidare.LichidareID );
		}

		public bool DeleteLichidare( int lichidareID )
		{
			return new Salaries.Data.Lichidare( this.settings.ConnectionString ).DeleteLichidare( lichidareID );
		}

		#endregion Delete

		#region CheckIfLichidareCanBeAdded
		/// <summary>
		/// Procedura selecteaza lichidarile din luna curenta ale unui angajat
		/// </summary>
		/// <param name="angajatID">Angajatul pentru care se obtin lichidarile</param>
		/// <param name="dataLichidare">Luna pentru care se selecteaza lichidarile</param>
		/// <returns>Returneaza 0 daca nu angajatul nu are lichidari pe luna respectiva si id-ul lichidarii in cazul in care aceasta exista</returns>
		public int CheckIfLichidareCanBeAdded(long angajatID, DateTime dataLichidare)
		{
			return new Salaries.Data.Lichidare( this.settings.ConnectionString ).CheckIfLichidareCanBeAdded(angajatID, dataLichidare);
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
			return new Salaries.Data.Lichidare( this.settings.ConnectionString ).GetLichidareAngajat(angajatId, dataLichidare);
		}
		#endregion
	}
}
