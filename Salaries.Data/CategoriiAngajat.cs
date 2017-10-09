using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for Luni.
	/// </summary>
	public struct CategorieData
	{		
		public int CategorieId;
		public int LunaId; 
		public string Denumire;
		public string Descriere;
		public decimal DPB;
		public bool ScutireImpozit;
		public bool ScutireCASAngajat;
		public bool ScutireCASAngajator;
		public bool ScutireSomajAngajat;
		public bool ScutireSomajAngajator;
		public bool ScutireAsigSanAngajat;
		public bool ScturieAsigSanAngajator;
		public bool PrimesteDPB;	
	}

	public class CategoriiAngajat : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="connectionString">String-ul de conexiune</param>
		public CategoriiAngajat(string connectionString): base (connectionString){}
		#endregion

		#region InsertCategorie
		/// <summary>
		/// Procedura adauga o categorie salariala
		/// </summary>
		/// <param name="lunaId"></param>
		/// <param name="denumire"></param>
		/// <param name="descriere"></param>
		/// <param name="DPB"></param>
		/// <param name="scutireImpozit"></param>
		/// <param name="scutireCASAngajat"></param>
		/// <param name="scutireCASAngajator"></param>
		/// <param name="scutireSomajAngajat"></param>
		/// <param name="scutireSomajAngajator"></param>
		/// <param name="scutireAsigSanAngajat"></param>
		/// <param name="scutireAsigSanAngajator"></param>
		/// <param name="primesteDPB"></param>
		/// <returns>Returneaza rezultatul adaugarii</returns>
		public int InsertCategorie(			
			int lunaId, 
			string denumire,
			string descriere,
			decimal DPB,
			bool scutireImpozit,
			bool scutireCASAngajat,
			bool scutireCASAngajator,
			bool scutireSomajAngajat,
			bool scutireSomajAngajator,
			bool scutireAsigSanAngajat,
			bool scutireAsigSanAngajator,
			bool primesteDPB	
		)
		{
			int numAffected;
			SqlParameter[] parameters = 
				{
					Salaries.Data.DbObject.AddInputParameter("@CategorieID",SqlDbType.Int,4,-1),

					Salaries.Data.DbObject.AddInputParameter("@LunaID", SqlDbType.Int, 4,lunaId),
					Salaries.Data.DbObject.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255,denumire),
					Salaries.Data.DbObject.AddInputParameter("@Descriere", SqlDbType.NVarChar, 4000,descriere),
					Salaries.Data.DbObject.AddInputParameter("@DPB", SqlDbType.Money, 8,DPB),
					// scutiri 
					Salaries.Data.DbObject.AddInputParameter("@ScutireImpozit",SqlDbType.Bit,1,scutireImpozit),
					Salaries.Data.DbObject.AddInputParameter("@ScutireCASAngajat",SqlDbType.Bit,1,scutireCASAngajat),
					Salaries.Data.DbObject.AddInputParameter("@ScutireCASAngajator",SqlDbType.Bit,1,scutireCASAngajator),
					Salaries.Data.DbObject.AddInputParameter("@ScutireSomajAngajat",SqlDbType.Bit,1,scutireSomajAngajat),
					Salaries.Data.DbObject.AddInputParameter("@ScutireSomajAngajator",SqlDbType.Bit,1,scutireSomajAngajator),
					Salaries.Data.DbObject.AddInputParameter("@ScutireAsigSanAngajat",SqlDbType.Bit,1,scutireAsigSanAngajat),
					Salaries.Data.DbObject.AddInputParameter("@ScutireAsigSanAngajator",SqlDbType.Bit,1,scutireAsigSanAngajator),
					Salaries.Data.DbObject.AddInputParameter("@PrimesteDPB",SqlDbType.Bit,1,primesteDPB),

					Salaries.Data.DbObject.AddInputParameter("@tip_actiune", SqlDbType.Int, 4,0),
					Salaries.Data.DbObject.AddOutputParameter("@rc",SqlDbType.Int,4)		
				};	

			RunProcedure("sal_InsertUpdateDeleteCategorieAngajat", parameters, out numAffected);
			return (int)parameters[14].Value;
		}
		#endregion

		#region UpdateCategorie
		/// <summary>
		/// Procedura actualizeaza o categorie
		/// </summary>
		/// <param name="categorieId"></param>
		/// <param name="lunaId"></param>
		/// <param name="denumire"></param>
		/// <param name="descriere"></param>
		/// <param name="DPB"></param>
		/// <param name="scutireImpozit"></param>
		/// <param name="scutireCASAngajat"></param>
		/// <param name="scutireCASAngajator"></param>
		/// <param name="scutireSomajAngajat"></param>
		/// <param name="scutireSomajAngajator"></param>
		/// <param name="scutireAsigSanAngajat"></param>
		/// <param name="scutireAsigSanAngajator"></param>
		/// <param name="primesteDPB"></param>
		/// <returns>Returneaza rezultatul actualizarii</returns>
		public int UpdateCategorie(
			int categorieId,
			int lunaId, 
			string denumire,
			string descriere,
			decimal DPB,
			bool scutireImpozit,
			bool scutireCASAngajat,
			bool scutireCASAngajator,
			bool scutireSomajAngajat,
			bool scutireSomajAngajator,
			bool scutireAsigSanAngajat,
			bool scutireAsigSanAngajator,
			bool primesteDPB	
			)
		{
			int numAffected;
			SqlParameter[] parameters = 
				{
					
					Salaries.Data.DbObject.AddInputParameter("@CategorieID",SqlDbType.Int,4,categorieId),
					
					Salaries.Data.DbObject.AddInputParameter("@LunaID", SqlDbType.Int, 4,lunaId),
					Salaries.Data.DbObject.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255,denumire),
					Salaries.Data.DbObject.AddInputParameter("@Descriere", SqlDbType.NVarChar, 4000,descriere),
					Salaries.Data.DbObject.AddInputParameter("@DPB", SqlDbType.Money, 8,DPB),
					// scutiri 
					Salaries.Data.DbObject.AddInputParameter("@ScutireImpozit",SqlDbType.Bit,1,scutireImpozit),
					Salaries.Data.DbObject.AddInputParameter("@ScutireCASAngajat",SqlDbType.Bit,1,scutireCASAngajat),
					Salaries.Data.DbObject.AddInputParameter("@ScutireCASAngajator",SqlDbType.Bit,1,scutireCASAngajator),
					Salaries.Data.DbObject.AddInputParameter("@ScutireSomajAngajat",SqlDbType.Bit,1,scutireSomajAngajat),
					Salaries.Data.DbObject.AddInputParameter("@ScutireSomajAngajator",SqlDbType.Bit,1,scutireSomajAngajator),
					Salaries.Data.DbObject.AddInputParameter("@ScutireAsigSanAngajat",SqlDbType.Bit,1,scutireAsigSanAngajat),
					Salaries.Data.DbObject.AddInputParameter("@ScutireAsigSanAngajator",SqlDbType.Bit,1,scutireAsigSanAngajator),
					Salaries.Data.DbObject.AddInputParameter("@PrimesteDPB",SqlDbType.Bit,1,primesteDPB),

					Salaries.Data.DbObject.AddInputParameter("@tip_actiune", SqlDbType.Int, 4,1), //update
					Salaries.Data.DbObject.AddOutputParameter("@rc",SqlDbType.Int,4)		
				};	

			RunProcedure("sal_InsertUpdateDeleteCategorieAngajat", parameters, out numAffected);
			return (int)parameters[14].Value;
		}
		#endregion

		#region DeleteCategorie
		/// <summary>
		/// Procedura sterge o categorie
		/// </summary>
		/// <param name="categorieId">Id-ul categoriei care se sterge</param>
		/// <returns>Returneaza rezultatul stergerii</returns>
		public int DeleteCategorie(int categorieId)
		{	
			int numAffected;
			SqlParameter[] parameters = 
				{
					
					Salaries.Data.DbObject.AddInputParameter("@CategorieID",SqlDbType.Int,4,categorieId),
					
					Salaries.Data.DbObject.AddInputParameter("@LunaID", SqlDbType.Int, 4,0),
					Salaries.Data.DbObject.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255,""),
					Salaries.Data.DbObject.AddInputParameter("@Descriere", SqlDbType.NVarChar, 4000,""),
					Salaries.Data.DbObject.AddInputParameter("@DPB", SqlDbType.Money, 8,0),
					// scutiri 
					Salaries.Data.DbObject.AddInputParameter("@ScutireImpozit",SqlDbType.Bit,1,false),
					Salaries.Data.DbObject.AddInputParameter("@ScutireCASAngajat",SqlDbType.Bit,1,false),
					Salaries.Data.DbObject.AddInputParameter("@ScutireCASAngajator",SqlDbType.Bit,1,false),
					Salaries.Data.DbObject.AddInputParameter("@ScutireSomajAngajat",SqlDbType.Bit,1,false),
					Salaries.Data.DbObject.AddInputParameter("@ScutireSomajAngajator",SqlDbType.Bit,1,false),
					Salaries.Data.DbObject.AddInputParameter("@ScutireAsigSanAngajat",SqlDbType.Bit,1,false),
					Salaries.Data.DbObject.AddInputParameter("@ScutireAsigSanAngajator",SqlDbType.Bit,1,false),
					
					Salaries.Data.DbObject.AddInputParameter("@PrimesteDPB",SqlDbType.Bit,1,false),

					Salaries.Data.DbObject.AddInputParameter("@tip_actiune", SqlDbType.Int, 4,2), //delete
					Salaries.Data.DbObject.AddOutputParameter("@rc",SqlDbType.Int,4)	
				};	

			RunProcedure("sal_InsertUpdateDeleteCategorieAngajat", parameters, out numAffected);
			return (int)parameters[14].Value;
		}
		#endregion
		
		#region InsertCategorie
		/// <summary>
		/// Procedura adauga o categorie salariala
		/// </summary>
		/// <param name="categorieData">Obiectul care contine datele categoriei</param>
		/// <returns>Returneaza rezultatul adaugarii</returns>
		public int  InsertCategorie(CategorieData categorieData)
		{
			return this.InsertCategorie(						
						categorieData.LunaId,
						categorieData.Denumire,
						categorieData.Descriere,
						categorieData.DPB,
						categorieData.ScutireImpozit,
						categorieData.ScutireCASAngajat,
						categorieData.ScutireCASAngajator,
						categorieData.ScutireSomajAngajat,
						categorieData.ScutireSomajAngajator,
						categorieData.ScutireAsigSanAngajat,
						categorieData.ScturieAsigSanAngajator,
						categorieData.PrimesteDPB);
		}
		#endregion

		#region UpdateCategorie
		/// <summary>
		/// Proceudra actualizeaza o categorie
		/// </summary>
		/// <param name="categorieData">Obiectul care contine datele cateoriei</param>
		/// <returns>Returneaza rezultatul actualizarii</returns>
		public int UpdateCategorie(CategorieData categorieData)
		{
			return this.UpdateCategorie(
				categorieData.CategorieId,
				categorieData.LunaId,
				categorieData.Denumire,
				categorieData.Descriere,
				categorieData.DPB,
				categorieData.ScutireImpozit,
				categorieData.ScutireCASAngajat,
				categorieData.ScutireCASAngajator,
				categorieData.ScutireSomajAngajat,
				categorieData.ScutireSomajAngajator,
				categorieData.ScutireAsigSanAngajat,
				categorieData.ScturieAsigSanAngajator,
				categorieData.PrimesteDPB);
		}
		#endregion

		#region DeleteCategorie
		/// <summary>
		/// Procedura sterge o categorie salariala
		/// </summary>
		/// <param name="categorieData">Obiectul care contine datele categoriei</param>
		/// <returns>Returneaza rezultatul stergerii</returns>
		public int DeleteCategorie(CategorieData categorieData)
		{
			return this.DeleteCategorie(categorieData.CategorieId);
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza datele unei categorii salariale
		/// </summary>
		/// <param name="categorieId">Id-ul categoriei selectate</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public CategorieData GetDetalii(int categorieId)
		{	
			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@CategorieID", SqlDbType.Int, 4, categorieId)
			};	
			DataSet detaliiCategorie = RunProcedure("spGetCategorieDenumire", parameters, "DetaliiCategorie");

			using(detaliiCategorie)
			{
				CategorieData categorieData = new CategorieData();
				if (detaliiCategorie.Tables["DetaliiCategorie"].Rows.Count > 0)
				{
					DataRow dr = detaliiCategorie.Tables["DetaliiCategorie"].Rows[0];
					
					categorieData.CategorieId = categorieId;
					categorieData.Denumire = dr["Denumire"].ToString();
					categorieData.Descriere = dr["Descriere"].ToString();
					categorieData.DPB= decimal.Parse(dr["DPB"].ToString());			
					
					categorieData.LunaId = int.Parse(dr["LunaID"].ToString());
					
					categorieData.ScutireAsigSanAngajat = bool.Parse(dr["ScutireAsigSanAngajat"].ToString());
					categorieData.ScturieAsigSanAngajator = bool.Parse(dr["ScutireAsigSanAngajator"].ToString());
					categorieData.ScutireCASAngajat = bool.Parse(dr["ScutireCASAngajat"].ToString());
					categorieData.ScutireCASAngajator = bool.Parse(dr["ScutireCASAngajator"].ToString());
					categorieData.ScutireImpozit = bool.Parse(dr["ScutireImpozit"].ToString());
					categorieData.ScutireSomajAngajat = bool.Parse(dr["ScutireSomajAngajat"].ToString());
					categorieData.ScutireSomajAngajator = bool.Parse(dr["ScutireSomajAngajator"].ToString());
					categorieData.PrimesteDPB = bool.Parse(dr["PrimesteDPB"].ToString());
				}
				else
					categorieData.LunaId = -1;

				return categorieData;
			}
		}
		#endregion

		#region GetCategoriiAngajat
		/// <summary>
		/// Procedura selecteaza categoriile salariale ale unui angajat
		/// </summary>
		/// <param name="lunaId">Id-ul lunii pentru care se selecteaza</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetCategoriiAngajat(int lunaId)
		{			
			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@LunaID", SqlDbType.Int, 4,lunaId)
			};	

			return RunProcedure("spGetCategoriiAngajatLunaID", parameters, "CategoriiAngajat");			
		}
		#endregion
		
		#region GetCategorieAngajati
		/// <summary>
		/// Procedura selecteaza categoria salariala a unui angajat
		/// </summary>
		/// <param name="categorieId">Id-ul categoriei selectate</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetCategorieAngajati(int categorieId)
		{			
			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@CategorieID", SqlDbType.Int, 4, categorieId)
			};	
			return RunProcedure("spGetAllAngajatiCategorieId", parameters, "CategorieAngajati");
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
		public bool CheckIfCategoriiAngajatCanBeAdded(
			int categorieId, int lunaId, string denumire, string descriere, decimal DPB, 
			bool scutireImpozit, bool scutireCASAngajat, bool scutireCASAngajator,
			bool scutireSomajAngajat, bool scutireSomajAngajator, bool scutireAsigSanAngajat, 
			bool scutireAsigSanAngajator, bool primesteDPB)
		{
			SqlParameter[] parameters = 
				{
					Salaries.Data.DbObject.AddInputParameter("@CategorieID", SqlDbType.Int, 4, categorieId),
					Salaries.Data.DbObject.AddInputParameter("@LunaID", SqlDbType.Int, 4, lunaId),
					Salaries.Data.DbObject.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255, denumire),
					Salaries.Data.DbObject.AddInputParameter("@Descriere", SqlDbType.NVarChar, 4000, descriere),
					Salaries.Data.DbObject.AddInputParameter("@DPB", SqlDbType.Money, 8, DPB),

					Salaries.Data.DbObject.AddInputParameter("@ScutireImpozit",SqlDbType.Bit,1,scutireImpozit),
					Salaries.Data.DbObject.AddInputParameter("@ScutireCASAngajat",SqlDbType.Bit,1,scutireCASAngajat),
					Salaries.Data.DbObject.AddInputParameter("@ScutireCASAngajator",SqlDbType.Bit,1,scutireCASAngajator),
					Salaries.Data.DbObject.AddInputParameter("@ScutireSomajAngajat",SqlDbType.Bit,1,scutireSomajAngajat),
					Salaries.Data.DbObject.AddInputParameter("@ScutireSomajAngajator",SqlDbType.Bit,1,scutireSomajAngajator),
					Salaries.Data.DbObject.AddInputParameter("@ScutireAsigSanAngajat",SqlDbType.Bit,1,scutireAsigSanAngajat),
					Salaries.Data.DbObject.AddInputParameter("@ScutireAsigSanAngajator",SqlDbType.Bit,1,scutireAsigSanAngajator),
					
					Salaries.Data.DbObject.AddInputParameter("@PrimesteDPB",SqlDbType.Bit,1,primesteDPB),
					new SqlParameter("@NrCategorii", SqlDbType.Int, 4)
				};
			
			parameters[ 13 ].Direction = ParameterDirection.ReturnValue;
			
			RunProcedure("spCheckIfCategorieAngajatCanBeAdded", parameters);
			return int.Parse(parameters[13].Value.ToString()) == 0;
		}
		#endregion
	}
}
