using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for NomenclatorSeriiTichete.
	/// </summary>
	public class NomenclatorSeriiTichete
	{
		private Configuration.ModuleSettings settings;

		#region Constructor
		public NomenclatorSeriiTichete()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}

		#endregion

		#region Add
		/// <summary>
		/// Pprocedura adauga un interval de serii
		/// </summary>
		/// <param name="serii"></param>
		/// <returns></returns>
		public bool AddSeriiTichete( Salaries.Data.SeriiTichete serii )
		{
			return this.AddSeriiTichete( serii.SerieId, serii.SerieInceput, serii.SerieSfarsit, serii.LunaID, serii.PunctLucruID);
		}

		public bool AddSeriiTichete( int serieId, long serieInceput, long serieSfarsit, int lunaId, int punctLucruId )
		{
		   
			return new Salaries.Data.NomenclatorSeriiTichete( this.settings.ConnectionString ).InsertSerii( serieId, serieInceput, serieSfarsit, lunaId, punctLucruId );
		}
		#endregion 

		#region Update
		/// <summary>
		/// Procedura actualizeaza un interval de serii
		/// </summary>
		/// <param name="serii"></param>
		/// <returns></returns>
		public bool UpdateSeriiTichete( Salaries.Data.SeriiTichete serii )
		{
			return new Salaries.Data.NomenclatorSeriiTichete( this.settings.ConnectionString ).UpdateSerii( serii );
		}

		public bool UpdateSeriiTichete( int serieId, long serieInceput, long serieSfarsit, int lunaId, int punctLucruId )
		{
			return new Salaries.Data.NomenclatorSeriiTichete( this.settings.ConnectionString ).UpdateSerii( serieId, serieInceput, serieSfarsit, lunaId, punctLucruId);
		}
		#endregion 

		#region Delete
		/// <summary>
		/// Pprocedura sterge un interval de serii
		/// </summary>
		/// <param name="serii"></param>
		/// <returns></returns>
		public bool DeleteSeriiTichete( Salaries.Data.SeriiTichete serii )
		{
			return this.DeleteSeriiTichete( serii.SerieId );
		}

		public bool DeleteSeriiTichete( int serieId )
		{
			return new Salaries.Data.NomenclatorSeriiTichete( this.settings.ConnectionString ).DeleteSerii( serieId );
		}

		#endregion Delete

		#region GetSeriiTichete
		/// <summary>
		/// Procedura selecteaza toate intervalele de serii
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetSeriiTichete()
		{			
			return new Salaries.Data.NomenclatorSeriiTichete( settings.ConnectionString ).GetSeriiTichete();
		}
		#endregion

		#region GetSeriiTichete
		/// <summary>
		/// Procedura selecteaza un interval de serii
		/// </summary>
		/// <param name="serieId">Id-ul intervalului de serii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetSeriiTichete(int serieId)
		{
			return new Salaries.Data.NomenclatorSeriiTichete( settings.ConnectionString ).GetSeriiTichete( serieId );
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza detaliile unui interval de serii
		/// </summary>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public Salaries.Data.SeriiTichete GetDetalii()
		{
			return new Salaries.Data.NomenclatorSeriiTichete( settings.ConnectionString ).GetDetalii();
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza detaliile unui interval de serii
		/// </summary>
		/// <param name="serieId">Id-ul intervalului de serii</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public Salaries.Data.SeriiTichete GetDetalii( int serieId )
		{
			return new Salaries.Data.NomenclatorSeriiTichete( settings.ConnectionString ).GetDetalii( serieId );
		}
		#endregion

		#region CheckIfSeriiTicheteCanBeAdded
		/// <summary>
		/// Procedura verifica daca mai exista deja un interval de serii cu exact aceleasi date. 
		/// </summary>
		/// <param name="serieID">id-ul seriei</param>
		/// <param name="serieInceput">nr seriei de inceput</param>
		/// <param name="serieSfarsit">nr seriei de sfarsit</param>
		/// <param name="lunaID">luna pentru care se considera seriile</param>
		/// <returns>Este returnat true daca mai exista deja un interval de serii si false daca nu mai exista deja un interval de serii cu aceleasi date</returns>
		public bool CheckIfSeriiTicheteCanBeAdded(int serieId, long serieInceput, long serieSfarsit, int lunaId, int punctLucruId)
		{
			return new Salaries.Data.NomenclatorSeriiTichete( this.settings.ConnectionString ).CheckIfSeriiTicheteCanBeAdded(serieId, serieInceput, serieSfarsit, lunaId, punctLucruId);
		}
		#endregion

		#region CheckIfSeriiTicheteCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un interval de serii poate fi stears. Nu se poate sterge un interval de serii daca este intr-o luna anterioara celei curente.
		/// </summary>
		/// <param name="serieId">Id-ul intervalului de serii care se sterge</param>
		/// <returns>Returneaza true daca se poate face stergerea si false altfel</returns>
		public int CheckIfSeriiTicheteCanBeDeleted(int serieID)
		{
			return new Salaries.Data.NomenclatorSeriiTichete( this.settings.ConnectionString ).CheckIfSeriiTicheteCanBeDeleted(serieID);
		}
		#endregion
	}
}
