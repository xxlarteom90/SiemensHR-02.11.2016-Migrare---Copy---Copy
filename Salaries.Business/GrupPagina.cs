using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Administreaza accesul diferitelor grupuri de utilizatori la paginile aplicatiei
	/// </summary>
	public class GrupPagina
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		// ID-ul
		private int grupPaginaID;
		// ID-ul grupului.
		private int grupID;
		// ID-ul paginii.
		private int paginaID;
		#endregion

		#region Proprietati
		public int GrupPaginaID
		{
			get{return grupPaginaID;}
			set{grupPaginaID=value;}
		}

		public int GrupID
		{
			get{return grupID;}
			set{grupID=value;}
		}

		public int PaginaID
		{
			get{return paginaID;}
			set{paginaID=value;}
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public GrupPagina()
		{	
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Returneaza toate detaliile despre o inregistrare
		/// </summary>
		/// <param name="grupPaginaID">Id-ul inregistrarii</param>
		/// <returns></returns>
		public Salaries.Data.GrupPaginaDetails GetDetalii(int grupPaginaID)
		{
			Data.GrupPagini grupPg = new Salaries.Data.GrupPagini(settings.ConnectionString);
			return grupPg.GetDetalii(grupPaginaID);
		}
		#endregion
		
		#region GetPaginiGrup
		/// <summary>
		/// Returneaza toate paginile la care are acces un grup
		/// </summary>
		/// <param name="grupID">Id-ul grupului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetPaginiGrup(int grupID)
		{
			Data.GrupPagini grupPg = new Salaries.Data.GrupPagini(settings.ConnectionString);
			return grupPg.GetPaginiGrup(grupID);
		}
		#endregion

		#region Insert
		/// <summary>
		/// Insereaza un grup de utilizatori
		/// </summary>
		/// <param name="grupID">Id-ul grupului</param>
		/// <param name="paginaID">Id-ul paginii</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public int Insert(int grupID, int paginaID)
		{
			Data.GrupPagini grupPg = new Salaries.Data.GrupPagini(settings.ConnectionString);
			return grupPg.Insert(grupID,paginaID);
		}
		#endregion

		#region Update
		/// <summary>
		/// Face update unui grup de utilizatori
		/// </summary>
		public void Update()
		{
			Data.GrupPagini grupPg = new Salaries.Data.GrupPagini(settings.ConnectionString);
			grupPg.Update(grupPaginaID, grupID, paginaID);
		}
		#endregion

		#region Delete
		/// <summary>
		/// Sterge un grup de utilizatori
		/// </summary>
		public void Delete()
		{
			Data.GrupPagini grupPg = new Salaries.Data.GrupPagini(settings.ConnectionString);
			grupPg.Delete(grupPaginaID);
		}
		#endregion		
	}
}
