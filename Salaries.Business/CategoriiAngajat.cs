using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for Luni.
	/// </summary>
	public class CategoriiAngajat : Salaries.Business.BizObject
	{
		#region Variabile
		private Configuration.ModuleSettings settings;
		#endregion
		
		#region CategoriiAngajat
		/// <summary>
		/// Constructor
		/// </summary>
		public CategoriiAngajat()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion
		
		#region InsertCategorie
		/// <summary>
		/// Procedura adauga o categorie salariala
		/// </summary>
		/// <param name="LunaID"></param>
		/// <param name="Denumire"></param>
		/// <param name="Descriere"></param>
		/// <param name="DPB"></param>
		/// <param name="ScutireImpozit"></param>
		/// <param name="ScutireCASAngajat"></param>
		/// <param name="ScutireCASAngajator"></param>
		/// <param name="ScutireSomajAngajat"></param>
		/// <param name="ScutireSomajAngajator"></param>
		/// <param name="ScutireAsigSanAngajat"></param>
		/// <param name="ScutireAsigSanAngajator"></param>
		/// <param name="PrimesteDPB"></param>
		/// <returns></returns>
		public int InsertCategorie(
			int LunaID, 
			string Denumire,
			string Descriere,
			decimal DPB,
			bool ScutireImpozit,
			bool ScutireCASAngajat,
			bool ScutireCASAngajator,
			bool ScutireSomajAngajat,
			bool ScutireSomajAngajator,
			bool ScutireAsigSanAngajat,
			bool ScutireAsigSanAngajator,
			bool PrimesteDPB)
		{
			return new Salaries.Data.CategoriiAngajat(settings.ConnectionString).InsertCategorie
		(	
				LunaID,
				Denumire,
				Descriere,
				DPB,
				ScutireImpozit,
				ScutireCASAngajat,
				ScutireCASAngajator,
				ScutireSomajAngajat,
				ScutireSomajAngajator,
				ScutireAsigSanAngajat,
				ScutireAsigSanAngajator,
				PrimesteDPB
				);		
		}
		#endregion

		#region UpdateCategorie
		/// <summary>
		/// Procedura actualizeaza o categorie
		/// </summary>
		/// <param name="CategorieID"></param>
		/// <param name="LunaID"></param>
		/// <param name="Denumire"></param>
		/// <param name="Descriere"></param>
		/// <param name="DPB"></param>
		/// <param name="ScutireImpozit"></param>
		/// <param name="ScutireCASAngajat"></param>
		/// <param name="ScutireCASAngajator"></param>
		/// <param name="ScutireSomajAngajat"></param>
		/// <param name="ScutireSomajAngajator"></param>
		/// <param name="ScutireAsigSanAngajat"></param>
		/// <param name="ScutireAsigSanAngajator"></param>
		/// <param name="PrimesteDPB"></param>
		/// <returns></returns>
		public int UpdateCategorie(
			
			int CategorieID,
			int LunaID, 
			string Denumire,
			string Descriere,
			decimal DPB,
			bool ScutireImpozit,
			bool ScutireCASAngajat,
			bool ScutireCASAngajator,
			bool ScutireSomajAngajat,
			bool ScutireSomajAngajator,
			bool ScutireAsigSanAngajat,
			bool ScutireAsigSanAngajator,
			bool PrimesteDPB
			)
		{
			return new Salaries.Data.CategoriiAngajat(settings.ConnectionString).UpdateCategorie
				(	
				CategorieID,
				LunaID,
				Denumire,
				Descriere,
				DPB,
				ScutireImpozit,
				ScutireCASAngajat,
				ScutireCASAngajator,
				ScutireSomajAngajat,
				ScutireSomajAngajator,
				ScutireAsigSanAngajat,
				ScutireAsigSanAngajator,
				PrimesteDPB
				);		
		}
		#endregion

		#region DeleteCategorie
		/// <summary>
		/// Procedura sterge o categorie
		/// </summary>
		/// <param name="CategorieID">Id-ul categoriei care se sterge</param>
		/// <returns></returns>
		public int DeleteCategorie(int CategorieID)
		{
			return new Salaries.Data.CategoriiAngajat(settings.ConnectionString).DeleteCategorie(CategorieID);
		}
		#endregion
	
		#region InsertCategorie
		/// <summary>
		/// Procedura adauga o categorie
		/// </summary>
		/// <param name="cd">Obiectul adaugat</param>
		/// <returns></returns>
		public int  InsertCategorie(Salaries.Data.CategorieData cd)
		{
			return new Salaries.Data.CategoriiAngajat(settings.ConnectionString).InsertCategorie(cd);
		}
		#endregion

		#region UpdateCategorie
		/// <summary>
		/// Procdura actualizeaza o categorie
		/// </summary>
		/// <param name="cd">Obiectul actualizat</param>
		/// <returns></returns>
		public int UpdateCategorie(Salaries.Data.CategorieData cd)
		{
			return new Salaries.Data.CategoriiAngajat(settings.ConnectionString).UpdateCategorie(cd);	
		}
		#endregion
	
		#region GetDetalii
		/// <summary>
		/// Procedura obtine detaliile unei categorii
		/// </summary>
		/// <param name="CategorieID">Id-ul categoriei</param>
		/// <returns></returns>
		public Salaries.Data.CategorieData GetDetalii(int CategorieID)
		{
			return new Salaries.Data.CategoriiAngajat(settings.ConnectionString).GetDetalii(CategorieID);	
		}
		#endregion

		#region GetCategoriiAngajat
		/// <summary>
		/// Procedura selecteaza categoriile angajatilor
		/// </summary>
		/// <param name="LunaID">Id-ul lunii pentru care se selecteaza</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetCategoriiAngajat(int LunaID)
		{			
			return new Salaries.Data.CategoriiAngajat(settings.ConnectionString).GetCategoriiAngajat(LunaID);							
		}
		#endregion

		#region GetCategorieAngajati
		/// <summary>
		/// Procedura selecteaza o categorie
		/// </summary>
		/// <param name="CategorieID">Id-ul categoriei selectate</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetCategorieAngajati(int CategorieID)
		{
			return new Salaries.Data.CategoriiAngajat(settings.ConnectionString).GetCategorieAngajati(CategorieID);
		}
		#endregion

		#region CheckIfCategoriiAngajatCanBeAdded
		/// <summary>
		/// Procedura verifica daca mai exista deja o categorie cu exact aceleasi date. 
		/// </summary>
		/// <param name="CategorieID">id-ul categoriei fata de care trebuie sa fie diferit</param>
		/// <param name="LunaID">datele despre o categorie care se verifica sa nu existe deja</param>
		/// <param name="Denumire"></param>
		/// <param name="Descriere"></param>
		/// <param name="DPB"></param>
		/// <param name="ScutireImpozit"></param>
		/// <param name="ScutireCASAngajat"></param>
		/// <param name="ScutireCASAngajator"></param>
		/// <param name="ScutireSomajAngajat"></param>
		/// <param name="ScutireSomajAngajator"></param>
		/// <param name="ScutireAsigSanAngajat"></param>
		/// <param name="ScutireAsigSanAngajator"></param>
		/// <param name="PrimesteDPB"></param>
		/// <returns>Este returnat true daca mai exista deja o categorie si false altfel. Daca nu mai exista se poate face adaugare sau actualizare</returns>
		public bool CheckIfCategoriiAngajatCanBeAdded(int CategorieID,int LunaID, string Denumire, string Descriere, decimal DPB, bool ScutireImpozit, bool ScutireCASAngajat, bool ScutireCASAngajator, bool ScutireSomajAngajat, bool ScutireSomajAngajator, bool ScutireAsigSanAngajat, bool ScutireAsigSanAngajator, bool PrimesteDPB)
		{
			return new Salaries.Data.CategoriiAngajat( this.settings.ConnectionString ).CheckIfCategoriiAngajatCanBeAdded(CategorieID, LunaID, Denumire, Descriere, DPB, ScutireImpozit, ScutireCASAngajat, ScutireCASAngajator, ScutireSomajAngajat, ScutireSomajAngajator, ScutireAsigSanAngajat, ScutireAsigSanAngajator,	PrimesteDPB);
		}	
		#endregion
	}
}
