using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for NomenclatorTipAbsente.
	/// </summary>
	public class NomenclatorTipAbsente : Salaries.Business.BizObject
	{
		private Configuration.ModuleSettings settings;

		#region Constructor

		public NomenclatorTipAbsente()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}

		#endregion

		#region Add
		/// <summary>
		/// Procedura adauga un tip de absenta
		/// </summary>
		/// <param name="denumire">Denumirea</param>
		/// <param name="procent">Procentul</param>
		/// <param name="descriere">Descrierea</param>
		/// <param name="medical">Absenta medicala dau nu</param>
		/// <param name="codAbsenta">Codul absentei</param>
		/// <param name="modificare">Poate fi modificata sau nu</param>
		/// <param name="folosire"></param>
		/// <param name="lucratoare">Absenta lucratoare sau nu</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool InsertTipAbsenta(string denumire,float procent,string descriere,bool medical,string codAbsenta,	bool modificare,bool folosire,bool lucratoare)
		{
			return new Salaries.Data.NomenclatorTipAbsente( settings.ConnectionString  ).InsertTipAbsente( denumire, procent, descriere, medical, codAbsenta, modificare, folosire, lucratoare );
		}
		#endregion

		#region InsertTipAbsenta
		/// <summary>
		/// Procedura adauga un tip de absenta
		/// </summary>
		/// <param name="tipAbs">Obiectul care se adaauga</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool InsertTipAbsenta( Salaries.Data.TipAbsente tipAbs )
		{
			return new Salaries.Data.NomenclatorTipAbsente( settings.ConnectionString  ).InsertTipAbsente( tipAbs );
		}
		#endregion

		#region Update
		/// <summary>
		/// Procedura actualizeaza un tip de absenta
		/// </summary>
		/// <param name="tipAbsentaID">Id-ul tipului de absenta actualizat</param>
		/// <param name="denumire">Denumirea</param>
		/// <param name="procent">Procentul</param>
		/// <param name="descriere">Descrierea</param>
		/// <param name="medical">Absenta medicala dau nu</param>
		/// <param name="codAbsenta">Codul absentei</param>
		/// <param name="modificare">Poate fi modificata sau nu</param>
		/// <param name="folosire"></param>
		/// <param name="lucratoare">Absenta lucratoare sau nu</param>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool UpdateTipAbsenta(int tipAbsentaID,string denumire,float procent,string descriere,bool medical,string codAbsenta,bool modificare,bool folosire,	bool lucratoare)
		{
			return new Salaries.Data.NomenclatorTipAbsente( settings.ConnectionString ).UpdateTipAbsente( tipAbsentaID, denumire, procent, descriere, medical, codAbsenta, modificare, folosire, lucratoare );
		}
		#endregion

		#region UpdateTipAbsenta
		/// <summary>
		/// Procedura actualizeaza un tip de absenta
		/// </summary>
		/// <param name="tipAbs">Obiectul actualizat</param>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool UpdateTipAbsenta( Salaries.Data.TipAbsente tipAbs )
		{
			return new Salaries.Data.NomenclatorTipAbsente( settings.ConnectionString ).UpdateTipAbsente( tipAbs );
		}
		#endregion

		#region Delete
		/// <summary>
		/// Procedura sterge un tip de absenta
		/// </summary>
		/// <param name="tipAbsentaID">Tipul de absenta sters</param>
		/// <returns>eturneaza true daca s-a facut stergerea si false altfel</returns>
		public bool DeleteTipAbsenta( int tipAbsentaID )
		{
			return new Salaries.Data.NomenclatorTipAbsente( settings.ConnectionString  ).DeleteTipAbsente( tipAbsentaID );
		}
		#endregion

		#region GetTipuriAbsente
		/// <summary>
		/// Procedura selecteaza toate tipurile de 
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipuriAbsente()
		{
			return new Salaries.Data.NomenclatorTipAbsente( settings.ConnectionString ).GetTipuriAbsente();
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
			return new Salaries.Data.NomenclatorTipAbsente( settings.ConnectionString ).GetTipuriAbsenteLunaCurenta();
		}
		#endregion

		#region GetTipuriAbsente
		/// <summary>
		/// Procedura selecteaza un tip de absenta
		/// </summary>
		/// <param name="tipAbsentaID">Id-ul absentei selectate</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipuriAbsente( int tipAbsentaID )
		{
			return new Salaries.Data.NomenclatorTipAbsente( settings.ConnectionString ).GetTipuriAbsente( tipAbsentaID );
		}
		#endregion

		#region GetDetaliiTipuriAbsente
		/// <summary>
		/// Procedura selecteaza tipurile de absenta
		/// </summary>
		/// <returns>Returneaza un sir de obiecte care contin aceste absenta</returns>
		public Salaries.Data.TipAbsente[] GetDetaliiTipuriAbsente()
		{
			return new Salaries.Data.NomenclatorTipAbsente( settings.ConnectionString ).GetDetaliiTipuriAbsente();
		}
		#endregion

		#region GetDetaliiTipuriAbsente
		/// <summary>
		/// Procedura selecteaza detaliile unui tip de absenta
		/// </summary>
		/// <param name="tipAbsentaID">Id-ul tipului de absenta</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public Salaries.Data.TipAbsente GetDetaliiTipuriAbsente( int tipAbsentaID )
		{
			return new Salaries.Data.NomenclatorTipAbsente( settings.ConnectionString ).GetDetaliiTipuriAbsente( tipAbsentaID );
		}
		#endregion
	}
}
