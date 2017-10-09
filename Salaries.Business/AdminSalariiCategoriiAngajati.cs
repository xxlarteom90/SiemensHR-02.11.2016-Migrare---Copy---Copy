using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminSalariiCategoriiAngajati.
	/// </summary>
	public class AdminSalariiCategoriiAngajati
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul categoriei
		private int categorieId;
		//Denumirea categoriei
		private string denumire;
		//Id-ul lunii pentru categorie
		private int lunaId;
		//Lista cu impozite
		private string listaImpozite;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminSalariiCategoriiAngajati()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul categoriei.
		/// </summary>
		public int CategorieId
		{
			get	{ return categorieId; }
			set { categorieId = value; }
		}
		/// <summary>
		/// Denumirea categoriei.
		/// </summary>
		public string Denumire
		{
			get	{ return denumire; }
			set { denumire = value; }
		}
		/// <summary>
		/// ID-ul lunii pentru categorie.
		/// </summary>
		public int LunaId
		{
			get	{ return lunaId; }
			set { lunaId = value; }
		}
		/// <summary>
		/// Lista cu impozite.
		/// </summary>
		public string ListaImpozite
		{
			get	{ return listaImpozite; }
			set { listaImpozite = value; }
		}
		#endregion

		#region CopyCategoryLunaActiva
		/// <summary>
		/// Procedura initializeaza categoriile pentru luna activa
		/// </summary>
		public void CopyCategoryLunaActiva()
		{
			Salaries.Data.AdminSalariiCategoriiAngajati categorii = new Salaries.Data.AdminSalariiCategoriiAngajati(settings.ConnectionString);
			categorii.CopyCategoryLunaActiva(categorieId, lunaId);
		}
		#endregion

		#region LoadInfoCategoriiLunaId
		/// <summary>
		/// Procedura selecteaza categoriile unei anumite luni
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadInfoCategoriiLunaId()
		{
			Salaries.Data.AdminSalariiCategoriiAngajati categorii = new Salaries.Data.AdminSalariiCategoriiAngajati(settings.ConnectionString);
			return categorii.LoadInfoCategoriiLunaId(lunaId);
		}
		#endregion


		#region LoadInfoCategoriiNesLunaId
		/// <summary>
		/// Procedura selecteaza categoriile unei anumite luni care nu au scutire de impozit
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		//Lungu Andreea 22.07.2008
		public DataSet LoadInfoCategoriiNesLunaId()
		{
			Salaries.Data.AdminSalariiCategoriiAngajati categorii = new Salaries.Data.AdminSalariiCategoriiAngajati(settings.ConnectionString);
			return categorii.LoadInfoCategoriiNesLunaId(lunaId);
		}
		#endregion


		#region LoadInfoCategoriiUnion
		/// <summary>
		/// Sunt selectate toate categoriile de angajati. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoCategoriiUnion()
		{
			Salaries.Data.AdminSalariiCategoriiAngajati categorii = new Salaries.Data.AdminSalariiCategoriiAngajati(settings.ConnectionString);
			return categorii.LoadInfoCategoriiUnion(lunaId);
		}
		#endregion

		#region LoadInfoCategorii
		/// <summary>
		/// Procedura selecteaza toate categoriile de angajati
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoCategorii()
		{
			Salaries.Data.AdminSalariiCategoriiAngajati categorii = new Salaries.Data.AdminSalariiCategoriiAngajati(settings.ConnectionString);
			return categorii.LoadInfoCategorii();
		}
		#endregion

		#region InsertCategorie
		/// <summary>
		/// Procedura adauga o categorie
		/// </summary>
		public void InsertCategorie()
		{
			Salaries.Data.AdminSalariiCategoriiAngajati categorii = new Salaries.Data.AdminSalariiCategoriiAngajati(settings.ConnectionString);
			categorii.InsertCategorie(lunaId, denumire, listaImpozite);
		}
		#endregion

		#region UpdateCategorie
		/// <summary>
		/// Procedura modifica o categorie
		/// </summary>
		public void UpdateCategorie()
		{
			Salaries.Data.AdminSalariiCategoriiAngajati categorii = new Salaries.Data.AdminSalariiCategoriiAngajati(settings.ConnectionString);
			categorii.UpdateCategorie(categorieId,  denumire, listaImpozite);
		}
		#endregion

		#region DeleteCategorie
		/// <summary>
		/// Procedura sterge o categorie
		/// </summary>
		public void DeleteCategorie()
		{
			Salaries.Data.AdminSalariiCategoriiAngajati categorii = new Salaries.Data.AdminSalariiCategoriiAngajati(settings.ConnectionString);
			categorii.DeleteCategorie(categorieId);
		}
		#endregion

		#region GetCategorieDenumire
		/// <summary>
		/// Procedura returneaza denumirea unei categorii
		/// </summary>
		/// <returns>Returneaza denumirea categoriei</returns>
		public string GetCategorieDenumire()
		{	
			Salaries.Data.AdminSalariiCategoriiAngajati categorii = new Salaries.Data.AdminSalariiCategoriiAngajati(settings.ConnectionString);
			return categorii.GetCategorieDenumire(categorieId);
		}
		#endregion

		#region CheckIfCategorieAngajatiCanBeDeleted
		/// <summary>
		/// Procedura determina daca o categorie de angajati poate fi stearsa sau nu
		/// </summary>
		/// <returns>Returneaza true daca se poate efectua stergerea si false altfel</returns>
		public bool CheckIfCategorieAngajatiCanBeDeleted()
		{
			Salaries.Data.AdminSalariiCategoriiAngajati categorii = new Salaries.Data.AdminSalariiCategoriiAngajati(settings.ConnectionString);
			return categorii.CheckIfCategorieAngajatiCanBeDeleted(categorieId);
		}
		#endregion
	}
}
