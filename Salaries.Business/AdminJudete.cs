using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminJudete.
	/// </summary>
	public class AdminJudete
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul tarii
		private int taraId;
		//Id-ul judetului
		private int judetId;
		//Numele judetului
		private string nume;
		//Simbolul judetului
		private string simbol;
		//Codul judetului
		private string cod;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminJudete()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul tarii
		/// </summary>
		public int TaraId
		{
			get { return taraId; }
			set { taraId =  value; }
		}
		/// <summary>
		/// Id-ul judetului
		/// </summary>
		public int JudetId
		{
			get { return judetId; }
			set { judetId =  value; }
		}
		/// <summary>
		/// Numele judetului
		/// </summary>
		public string Nume
		{
			get { return nume; }
			set { nume =  value; }
		}
		/// <summary>
		/// Simbol judetului
		/// </summary>
		public string Simbol
		{
			get { return simbol; }
			set { simbol =  value; }
		}
		/// <summary>
		/// Codul judetului
		/// </summary>
		public string Cod
		{
			get { return cod; }
			set { cod =  value; }
		}
		#endregion

		#region LoadInfoJudete
		/// <summary>
		/// Procedura selecteaza toate judetele
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadInfoJudete()
		{
			Salaries.Data.AdminJudete judet = new Salaries.Data.AdminJudete(settings.ConnectionString);
			return judet.LoadInfoJudete();
		}
		#endregion

		#region GetAllJudeteTara
		/// <summary>
		/// Procedura returneaza toate judetele unei tari
		/// </summary>
		/// <returns>Returneaza un DataSet care contine judetele tarii</returns>
		public DataSet GetAllJudeteTara()
		{
			Salaries.Data.AdminJudete judet = new Salaries.Data.AdminJudete(settings.ConnectionString);
			return judet.GetAllJudeteTara(taraId);
		}
		#endregion

		#region InsertJudet
		/// <summary>
		/// Procedura adauga un judet
		/// </summary>
		public void InsertJudet()
		{
			Salaries.Data.AdminJudete judet = new Salaries.Data.AdminJudete(settings.ConnectionString);
			judet.InsertJudet(judetId, taraId, nume, simbol, cod);
		}
		#endregion

		#region UpdateJudet
		/// <summary>
		/// Procedura actualizeaza un judet
		/// </summary>
		public void UpdateJudet()
		{
			Salaries.Data.AdminJudete judet = new Salaries.Data.AdminJudete(settings.ConnectionString);
			judet.UpdateJudet(judetId, taraId, nume, simbol, cod);
		}
		#endregion

		#region DeleteJudet
		/// <summary>
		/// Procedura sterge un judet
		/// </summary>
		public void DeleteJudet()
		{
			Salaries.Data.AdminJudete judet = new Salaries.Data.AdminJudete(settings.ConnectionString);
			judet.DeleteJudet(judetId);
		}
		#endregion

		#region GetJudetInfo
		/// <summary>
		/// Procedura selecteaza un judet
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele despre judet</returns>
		public DataSet GetJudetInfo()
		{
			Salaries.Data.AdminJudete judet = new Salaries.Data.AdminJudete(settings.ConnectionString);
			return judet.GetJudetInfo(judetId);
		}
		#endregion

		#region CheckIfJudetCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un judet poate fi sters
		/// </summary>
		/// <returns>Returneaza rezulatul verificarii</returns>
		public int CheckIfJudetCanBeDeleted()
		{
			Salaries.Data.AdminJudete judet = new Salaries.Data.AdminJudete(settings.ConnectionString);
			return judet.CheckIfJudetCanBeDeleted(judetId);
		}
		#endregion

		#region VerificareExistentaJudet
		/// <summary>
		/// Se verifica daca exista un judet ce are aceleasi date cu cel trimis ca parametru.
		/// </summary>
		/// <returns>true in cazul in care exista, false altfel.</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  15.06.2006
		/// </remarks>
		public bool VerificareExistentaJudet()
		{
			Salaries.Data.AdminJudete judet = new Salaries.Data.AdminJudete(settings.ConnectionString);
			return judet.VerificareExistentaJudet(judetId, taraId, nume, simbol, cod);
		}
		#endregion
	}
}
