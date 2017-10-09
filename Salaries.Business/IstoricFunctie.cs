using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for IstoricFunctie.
	/// </summary>
	public class IstoricFunctie
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul angajatului
		private long angajatId;
		//Id-ul functiei
		private int functieId;
		//Data de inceput a activitatii la functia noua
		private DateTime dataStartNoua;
		//Data de inceput a activitatii la functia veche
		private DateTime dataStartVeche;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public IstoricFunctie()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul angajatului.
		/// </summary>
		public long AngajatId
		{
			get{ return angajatId; }
			set{ angajatId = value;}
		}
		/// <summary>
		/// ID-ul functiei.
		/// </summary>
		public int FunctieId
		{
			get{ return functieId; }
			set{ functieId = value;}
		}
		/// <summary>
		/// Data de inceput a activitatii la functia noua.
		/// </summary>
		public DateTime DataStartNoua
		{
			get{ return dataStartNoua; }
			set{ dataStartNoua = value;}
		}
		/// <summary>
		/// Data de inceput a activitatii la functia veche.
		/// </summary>
		public DateTime DataStartVeche
		{
			get{ return dataStartVeche; }
			set{ dataStartVeche = value;}
		}
		#endregion

		#region LoadIstoricFunctii
		/// <summary>
		/// Procedura selecteaza functiile unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadIstoricFunctii()
		{
			Salaries.Data.IstoricFunctie istFunctie = new Salaries.Data.IstoricFunctie(settings.ConnectionString);
			return istFunctie.LoadIstoricFunctii(angajatId);
		}
		#endregion

		#region LoadIstoricFunctiiLunaActiva
		/// <summary>
		/// Procedura selecteaza functiile unui angajat din luna activa sau daca nu functia curenta
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		// Lungu Andreea 22.07.2008
		public DataSet LoadIstoricFunctiiLunaActiva(DateTime data)
		{
			Salaries.Data.IstoricFunctie istFunctie = new Salaries.Data.IstoricFunctie(settings.ConnectionString);
			return istFunctie.LoadIstoricFunctiiLunaActiva(angajatId, data);
		}
		#endregion

		#region GetFunctieCurenta
		/// <summary>
		/// Procedura selecteaza functia curenta a unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		// Lungu Andreea 22.07.2008
		public DataSet GetFunctieCurenta()
		{
			Salaries.Data.IstoricFunctie istFunctie = new Salaries.Data.IstoricFunctie(settings.ConnectionString);
			return istFunctie.GetFunctieCurenta(angajatId);
		}
		#endregion

		#region InsertFunctie
		/// <summary>
		/// Procedura adauga o functie pentur angajat
		/// </summary>
		public void InsertFunctie()
		{
			Salaries.Data.IstoricFunctie istFunctie = new Salaries.Data.IstoricFunctie(settings.ConnectionString);
			istFunctie.InsertFunctie(angajatId, functieId, dataStartNoua);
		}
		#endregion

		#region UpdateFunctie
		/// <summary>
		/// Procedura actualizeaza o functie
		/// </summary>
		public void UpdateFunctie()
		{
			Salaries.Data.IstoricFunctie istFunctie = new Salaries.Data.IstoricFunctie(settings.ConnectionString);
			istFunctie.UpdateFunctie(angajatId, functieId, dataStartNoua, dataStartVeche);
		}
		#endregion

		#region DeleteFunctie
		/// <summary>
		/// Procedura sterge o functie
		/// </summary>
		public void DeleteFunctie()
		{
			Salaries.Data.IstoricFunctie istFunctie = new Salaries.Data.IstoricFunctie(settings.ConnectionString);
			istFunctie.DeleteFunctie(angajatId, functieId, dataStartNoua, dataStartVeche);
		}
		#endregion

		#region CheckIfIstoricFunctiiCanBeAdded
		/// <summary>
		/// Procedura verifica dca amia exista o inregistrare cu aceleasi date
		/// </summary>
		/// <returns>Procedura returneaza true sau false in functia daca se pot face adaugari sau nu </returns>
		public bool CheckIfIstoricFunctiiCanBeAdded()
		{
			Salaries.Data.IstoricFunctie istFunctie = new Salaries.Data.IstoricFunctie(settings.ConnectionString);
			return istFunctie.CheckIfIstoricFunctiiCanBeAdded(angajatId, dataStartNoua);
		}
		#endregion

		#region CheckIfFunctiaCoincideCuIncadrarea
		/// <summary>
		/// Procedura verifica daca functia aleasa coincide cu incadrarea angajatului (scutit/nescutit) de impozit la momentul respectiv
		/// </summary>
		/// <returns>Procedura returneaza true sau false daca functia coincide cu incadrare </returns>
		// Lungu Andreea - 24.07.2008
		// se verifica daca functia care se doreste coincide cu incadrarea angajatului (scutit/nescutit) 
		public bool CheckIfFunctiaCoincideCuIncadrarea()
		{
			//sunt aduse toate schimbarile angajatului
			Salaries.Data.IstoricSchimbareDateAngajat istSch = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			DataSet dsSch = istSch.LoadIstoricSchimbari(angajatId);
			DataTable dt = dsSch.Tables[0];
			DataRow myRow = null;
			//se cauta schimbarea corespunzatoare datei introduse
			foreach(DataRow dr in dt.Rows)
			{
				if (((DateTime)dr["DataStart"] <= dataStartNoua) && (dataStartNoua <= (DateTime)dr["DataEnd"]))
				{
					myRow = dr;
					break;
				}
			}
			if (myRow!=null)
			{
				//se aduc informatii despre categoria aflata in istoric schimbari
				Salaries.Data.AdminSalariiCategoriiAngajati adminCateg = new Salaries.Data.AdminSalariiCategoriiAngajati(settings.ConnectionString);
				DataSet dsCateg = adminCateg.GetCategorie(Int32.Parse(myRow["CategorieId"].ToString()));
				bool scutireImpozit = (bool) dsCateg.Tables[0].Rows[0]["ScutireImpozit"];
				//se aduc informatii despre functia care se doreste a fi introdusa
				Salaries.Data.AdminFunctii admFunct = new Salaries.Data.AdminFunctii(settings.ConnectionString);
				DataSet dsFunct = admFunct.GetFunctieInfo(functieId);
				bool suportaImpozit = (bool) dsFunct.Tables[0].Rows[0]["PosibilaScutireImpozit"];
			
				if (scutireImpozit && !suportaImpozit) //daca categoria din istoric schimbari are scutire impozit si noua functie nu suporta scutire
					return false;
			}
			return true;
		}
		#endregion
	}
}
