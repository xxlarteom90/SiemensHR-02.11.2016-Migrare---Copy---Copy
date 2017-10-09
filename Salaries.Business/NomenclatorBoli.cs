using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for NomenclatorBoli.
	/// </summary>
	public class NomenclatorBoli
	{
		private Configuration.ModuleSettings settings;

		#region Constructor
		public NomenclatorBoli()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}

		#endregion

		#region Add
		/// <summary>
		/// Pprocedura adauga un tip de boala
		/// </summary>
		/// <param name="boala"></param>
		/// <returns></returns>
		public bool AddBoala( Salaries.Data.Boala boala )
		{
			return this.AddBoala( boala.Procent, boala.CodBoala, boala.CategorieBoala, boala.Stagiu );
		}

		public bool AddBoala( float procent, string codBoala, string categorieBoala, bool stagiu )
		{
		   
			return new Salaries.Data.NomenclatorBoli( this.settings.ConnectionString ).InsertBoli( procent, codBoala, categorieBoala, stagiu );
		}
		#endregion 

		#region Update
		/// <summary>
		/// Procedura actualizeaza un tip de boala
		/// </summary>
		/// <param name="boala"></param>
		/// <returns></returns>
		public bool UpdateBoala( Salaries.Data.Boala boala )
		{
			return new Salaries.Data.NomenclatorBoli( this.settings.ConnectionString ).UpdateBoala( boala );
		}

		public bool UpdateBoala( int boalaID, float procent, string codBoala, string categorieBoala, bool stagiu )
		{
			return new Salaries.Data.NomenclatorBoli( this.settings.ConnectionString ).UpdateBoli( boalaID, procent, codBoala, categorieBoala, stagiu );
		}
		#endregion 

		#region Delete
		/// <summary>
		/// Pprocedura sterge un tip de boala
		/// </summary>
		/// <param name="boala"></param>
		/// <returns></returns>
		public bool DeleteBoala( Salaries.Data.Boala boala )
		{
			return this.DeleteBoala( boala.BoalaId );
		}

		public bool DeleteBoala( int boalaID )
		{
			return new Salaries.Data.NomenclatorBoli( this.settings.ConnectionString ).DeleteBoli( boalaID );
		}

		#endregion Delete

		#region GetBoli
		/// <summary>
		/// Procedura selecteaza toate tipurile de boli
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetBoli()
		{			
			return new Salaries.Data.NomenclatorBoli( settings.ConnectionString ).GetBoli();
		}
		#endregion

		#region GetBoli
		/// <summary>
		/// Procedura selecteaza o boala
		/// </summary>
		/// <param name="idBoala">Id-ul bolii selectate</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetBoli(string idBoala)
		{
			return new Salaries.Data.NomenclatorBoli( settings.ConnectionString ).GetBoli( idBoala );
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza deteliile unei boli
		/// </summary>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public Salaries.Data.Boala GetDetalii()
		{
			return new Salaries.Data.NomenclatorBoli( settings.ConnectionString ).GetDetalii();
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza deteliile unei boli
		/// </summary>
		/// <param name="idBoala">Id-ul bolii selectate</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public Salaries.Data.Boala GetDetalii( string idBoala )
		{
			return new Salaries.Data.NomenclatorBoli( settings.ConnectionString ).GetDetalii( idBoala );
		}
		#endregion

		#region CheckIfBoalaCanBeAdded
		/// <summary>
		/// Procedura verifica daca mai exista deja o boala cu exact aceleasi date. 
		/// </summary>
		/// <param name="boalaID">id-ul pentru boala</param>
		/// <param name="cod">codul pentru boala</param>
		/// <param name="categorie">categoria din care face parte boala</param>
		/// <param name="procent">procentrul pentru boala</param>
		/// <param name="stagiu">stagiu pentru boala</param>
		/// <returns>Este returnat true daca mai exista deja o boala si false daca nu mai exista deja o boala cu aceleasi date</returns>
		public bool CheckIfBoalaCanBeAdded(int boalaID, string cod, string categorie, float procent, string stagiu)
		{
			return new Salaries.Data.NomenclatorBoli( this.settings.ConnectionString ).CheckIfBoalaCanBeAdded(boalaID, cod, categorie, procent, stagiu);
		}
		#endregion

		#region CheckIfBoalaCanBeDeleted
		/// <summary>
		/// Procedura verifica daca o boala poate fi stearsa. Nu se poate sterge o boala pentru care exista concedii medicale atasate.
		/// </summary>
		/// <param name="boalaID">Id-ul bolii care se sterge</param>
		/// <returns>Returneaza true daca se poate face stergerea si false altfel</returns>
		public int CheckIfBoalaCanBeDeleted(int boalaID)
		{
			return new Salaries.Data.NomenclatorBoli( this.settings.ConnectionString ).CheckIfBoalaCanBeDeleted(boalaID);
		}
		#endregion
	}
}
