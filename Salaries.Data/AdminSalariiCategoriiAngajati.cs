using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminSalariiCategoriiAngajati.
	/// </summary>
	public class AdminSalariiCategoriiAngajati : Salaries.Data.DbObject
	{
		#region AdminSalariiCategoriiAngajati
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminSalariiCategoriiAngajati(string connectionString) : base (connectionString)
		{}
		#endregion

		#region CopyCategoryLunaActiva
		/// <summary>
		/// Procedura initializeaza categoriile pentru luna activa
		/// </summary>
		/// <param name="categorieId">Id-ul categoriei</param>
		/// <param name="lunaActivaId">Id-ul lunii active</param>
		public void CopyCategoryLunaActiva(int categorieId, int lunaActivaId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@CategorieID", SqlDbType.Int, 4),
								new SqlParameter("@LunaActivaID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = categorieId;
			parameters[1].Value = lunaActivaId;
			RunProcedure("sal_InitCategoriiLunaActiva", parameters);
		}
		#endregion

		#region LoadInfoCategoriiLunaId
		/// <summary>
		/// Procedura selecteaza categoriile unei anumite luni
		/// </summary>
		/// <param name="lunaId">Luna pentru care sunt selectate categoriile</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadInfoCategoriiLunaId(int lunaId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@LunaID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = lunaId;
			return RunProcedure("spGetAllCategoriiAngajatiLunaID", parameters, "GetAllCategoriiAngajatiLunaID");
		}
		#endregion

		#region LoadInfoCategoriiNesLunaId
		/// <summary>
		/// Procedura selecteaza categoriile unei anumite luni care nu permit scutire la impozit
		/// </summary>
		/// <param name="lunaId">Luna pentru care sunt selectate categoriile</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>\
		// Lungu Andreea 22.07.2008
		public DataSet LoadInfoCategoriiNesLunaId(int lunaId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@LunaID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = lunaId;
			return RunProcedure("spGetAllCategoriiNesAngajatiLunaID", parameters, "GetAllCategoriiNesAngajatiLunaID");
		}
		#endregion

		#region LoadInfoCategoriiUnion
		/// <summary>
		/// Sunt selectate toate categoriile de angajati. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <param name="lunaId">Id-ul lunii pentru care sunt selecatate categoriile de angajati</param>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoCategoriiUnion(int lunaId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@LunaID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = lunaId;
			return RunProcedure("spGetAllCategoriiAngajatiUnion", parameters, "GetAllCategoriiAngajatiUnion");
		}
		#endregion

		#region LoadInfoCategorii
		/// <summary>
		/// Procedura selecteaza toate categoriile de angajati
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoCategorii()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("spGetAllCategoriiAngajati", parameters, "GetAllCategoriiAngajati");
		}
		#endregion

		#region InsertCategorie
		/// <summary>
		/// Procedura adauga o categorie
		/// </summary>
		/// <param name="lunaId">Id-ul lunii pentru care se adauga categria</param>
		/// <param name="denumire">Denumirea categoriei</param>
		/// <param name="listaImpozite">Lista de impozite</param>
		public void InsertCategorie(int lunaId, string denumire, string listaImpozite)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@CategorieID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 50),
								new SqlParameter("@LunaID", SqlDbType.Int, 4),
								new SqlParameter("@ListaImpozite", SqlDbType.NVarChar, 100)
							};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = denumire;
			parameters[3].Value = lunaId;
			parameters[4].Value = listaImpozite;

			RunProcedure("InsertUpdateDeleteCategorieSalarii", parameters);
		}
		#endregion

		#region UpdateCategorie
		/// <summary>
		/// Procedura actualizeaza o categorie de salarii
		/// </summary>
		/// <param name="categorieId">Id-ul categoriei care se actualizeaza</param>
		/// <param name="denumire">Denumirea categoriei</param>
		/// <param name="listaImpozite">Lista de impozite pentru categorie</param>
		public void UpdateCategorie(int categorieId,  string denumire, string listaImpozite)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@CategorieID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 50),
								new SqlParameter("@LunaID", SqlDbType.Int, 4),
								new SqlParameter("@ListaImpozite", SqlDbType.NVarChar, 100)
							};
			
			parameters[0].Value = 1;
			parameters[1].Value = categorieId;
			parameters[2].Value = denumire;
			parameters[3].Value = 0;
			parameters[4].Value = listaImpozite;

			RunProcedure("InsertUpdateDeleteCategorieSalarii", parameters);
		}
		#endregion

		#region DeleteCategorie
		/// <summary>
		/// Procedura sterge o categorie de salarii
		/// </summary>
		/// <param name="categorieId">Id-ul categoriei care se sterge</param>
		public void DeleteCategorie(int categorieId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@CategorieID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 50),
								new SqlParameter("@LunaID", SqlDbType.Int, 4),
								new SqlParameter("@ListaImpozite", SqlDbType.NVarChar, 100)
							};
			
			parameters[0].Value = 2;
			parameters[1].Value = categorieId;
			parameters[2].Value = "";
			parameters[3].Value = 0;
			parameters[4].Value = "";

			RunProcedure("InsertUpdateDeleteCategorieSalarii", parameters);
		}
		#endregion

		#region GetCategorieDenumire
		/// <summary>
		/// Procedura returneaza denumirea unei categorii
		/// </summary>
		/// <param name="categorieId">Id-ul categoriei</param>
		/// <returns>Returneaza denumirea categoriei</returns>
		public string GetCategorieDenumire(int categorieId)
		{		
			SqlParameter[] parameters = 
							{
								new SqlParameter("@CategorieID", SqlDbType.Int, 4)
							};
			parameters[0].Value = categorieId;
			DataSet ds = RunProcedure("spGetCategorieDenumire", parameters, "GetCategorieDenumire");

			//Modificat:	Oprescu Claudia
			//Descriere:	Se selecteaza o categorie numai daca id-ul ei este nenul
			if (categorieId > 0)
			{
				if (ds.Tables[0].Rows.Count>0)
				{
					return ds.Tables[0].Rows[0]["Denumire"].ToString();
				}
				else
				{
					return "";
				}
			}
			else
			{
				return "";
			}
		}
		#endregion

		#region GetCategorie
		/// <summary>
		/// Procedura returneaza denumirea unei categorii
		/// </summary>
		/// <param name="categorieId">Id-ul categoriei</param>
		/// <returns>Returneaza un dataSet ce contine informatiile categoriei</returns>
		// Lungu Andreea - 24.07.2008
		public DataSet GetCategorie(int categorieId)
		{		
			SqlParameter[] parameters = 
							{
								new SqlParameter("@CategorieID", SqlDbType.Int, 4)
							};
			parameters[0].Value = categorieId;
			DataSet ds = RunProcedure("spGetCategorieDenumire", parameters, "GetCategorieDenumire");
			return ds;
		}
		#endregion

		#region CheckIfCategorieAngajatiCanBeDeleted
		/// <summary>
		/// Procedura determina daca o categorie de angajati poate fi stearsa sau nu
		/// </summary>
		/// <param name="categorieId">Id-ul categoriei pentru care se face verificarea</param>
		/// <returns>Returneaza true daca se poate efectua stergerea si false altfel</returns>
		public bool CheckIfCategorieAngajatiCanBeDeleted(int categorieId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@CategorieID", SqlDbType.Int, 4)
							};
			parameters[0].Value = categorieId;
			DataSet ds = RunProcedure("spCheckIfCategorieAngajatiCanBeDeleted", parameters, "CheckIfCategorieAngajatiCanBeDeleted");
			
			if (Convert.ToInt32(ds.Tables[0].Rows[0]["norec"])>0)
				return false;
			else
				return true;
		}
		#endregion
	}
}
