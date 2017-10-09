using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for NomenclatorTipOreLucrate.
	/// </summary>
	public class NomenclatorTipOreLucrate : Salaries.Business.BizObject
	{
		private Configuration.ModuleSettings settings;

		#region Constructor

		public NomenclatorTipOreLucrate()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}

		#endregion

		#region Add
		/// <summary>
		/// Procedura adauga un tip de ore lucrate
		/// </summary>
		/// <param name="denumire">Denumirea</param>
		/// <param name="procent">Procentul</param>
		/// <param name="descriere">Descrierea</param>
		/// <param name="nrMaximOreSapt">Nr maxim de ore admise pe saptamana</param>
		/// <param name="standard">Ore stantandard sau nu</param>
		/// <param name="modificare">Poate fi modificat sau nu</param>
		/// <param name="folosire"></param>
		/// <param name="bonuriMasa">Se acorda bonuri de masa sau nu</param>
		/// <param name="aplicWeekendNoapte"></param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool InsertTipOreLucrate
			(
			string denumire, 
			float procent,
			string descriere,
			float nrMaximOreSapt,
			bool standard,
			bool modificare,
			bool folosire,
			bool bonuriMasa,
			bool aplicWeekendNoapte
			)
		{
			return new Salaries.Data.NomenclatorTipOreLucrate( settings.ConnectionString  ).InsertTipOreLucrate( denumire, procent, descriere, nrMaximOreSapt, standard, modificare, folosire, bonuriMasa, aplicWeekendNoapte );
		}
		#endregion

		#region InsertTipOreLucrate
		/// <summary>
		/// Procedura adauga un tip de ore lucrate
		/// </summary>
		/// <param name="tipOre">Obiectul care se adauga</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool InsertTipOreLucrate( Salaries.Data.TipOreLucrate tipOre )
		{
			return new Salaries.Data.NomenclatorTipOreLucrate( settings.ConnectionString  ).InsertTipOreLucrate( tipOre );
		}
		#endregion

		#region Update
		/// <summary>
		/// Procedura actualizeaza un tip de ore lucrate
		/// </summary>
		/// <param name="tipIntervalID">Id-ul tipului actualizat</param>
		/// <param name="denumire">Denumirea</param>
		/// <param name="procent">Procentul</param>
		/// <param name="descriere">Descrierea</param>
		/// <param name="nrMaximOreSapt">Nr maxim de ore admise pe saptamana</param>
		/// <param name="standard">Ore stantandard sau nu</param>
		/// <param name="modificare">Poate fi modificat sau nu</param>
		/// <param name="folosire"></param>
		/// <param name="bonuriMasa">Se acorda bonuri de masa sau nu</param>
		/// <param name="aplicWeekendNoapte"></param>
		/// <returns>Returneaza true daca s-a facut modificare si false altfel</returns>
		public bool UpdateTipOreLucrate
			(
			int tipIntervalID,
			string denumire, 
			float procent,
			string descriere,
			float nrMaximOreSapt,
			bool standard,
			bool modificare,
			bool folosire,
			bool bonuriMasa,
			bool aplicWeekendNoapte
			)
		{
			return new Salaries.Data.NomenclatorTipOreLucrate( settings.ConnectionString ).UpdateTipOreLucrate( tipIntervalID, denumire, procent, descriere, nrMaximOreSapt, standard, modificare, folosire, bonuriMasa, aplicWeekendNoapte );
		}
		#endregion

		#region UpdateTipOreLucrate
		/// <summary>
		/// Procedura actualizeaza un tip de ore lucrate
		/// </summary>
		/// <param name="tipOre">Obiectul care se actualizeaza</param>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool UpdateTipOreLucrate( Salaries.Data.TipOreLucrate tipOre )
		{
			return new Salaries.Data.NomenclatorTipOreLucrate( settings.ConnectionString ).UpdateTipOreLucrate( tipOre );
		}
		#endregion

		#region Delete
		/// <summary>
		/// Procedura sterge un tip de ore lucrate
		/// </summary>
		/// <param name="tipIntervalID">Id-ul tipului de ore care se sterge</param>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool DeleteTipOreLucrate( int tipIntervalID )
		{
			return new Salaries.Data.NomenclatorTipOreLucrate( settings.ConnectionString  ).DeleteTipOreLucrate( tipIntervalID );
		}
		#endregion

		#region GetTipuriOreLucrate
		/// <summary>
		/// Procedura selecteaza tipurile de ore lucrate
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipuriOreLucrate()
		{
			return new Salaries.Data.NomenclatorTipOreLucrate( settings.ConnectionString  ).GetTipuriOreLucrate();
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
			return new Salaries.Data.NomenclatorTipOreLucrate( settings.ConnectionString  ).GetTipuriOreLucrate( tipIntervalID );
		}
		#endregion

		#region GetDetaliiTipuriOreLucrate
		/// <summary>
		/// Procedura selecteaza tipurile de ore lucrate
		/// </summary>
		/// <returns>Returneaza un sir de obiecte care contin aceste date</returns>
		public Salaries.Data.TipOreLucrate[] GetDetaliiTipuriOreLucrate()
		{
			return new Salaries.Data.NomenclatorTipOreLucrate( settings.ConnectionString  ).GetDetaliiTipuriOreLucrate();
		}
		#endregion

		#region GetDetaliiTipuriOreLucrate
		/// <summary>
		/// Procedura selecteaza un tip de ore lucrate
		/// </summary>
		/// <param name="tipIntervalID">Id-ul tipului de ore selectat</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public Salaries.Data.TipOreLucrate GetDetaliiTipuriOreLucrate( int tipIntervalID )
		{
			return new Salaries.Data.NomenclatorTipOreLucrate( settings.ConnectionString  ).GetDetaliiTipuriOreLucrate( tipIntervalID );
		}
		#endregion
	}
}
