using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminDepartament.
	/// </summary>
	public class AdminDepartament
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul departamentului
		private int departamentId;
		//Denumirea departamentului
		private string denumire;
		//Id-ul centrului de cost
		private int centruCostId;
		//Id-ul sefului de departament
		private int sefId;
		//Id-ul inlocuitorului sefului de departament
		private int inlocSefId;
		//Secretariat
		private string secretariat;
		//Departamentul parinte
		private int deptParinte;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminDepartament()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul departamentului.
		/// </summary>
		public int DepartamentId
		{
			get	{ return departamentId; }
			set { departamentId = value; }
		}
		/// <summary>
		/// Denumirea departamentului.
		/// </summary>
		public string Denumire
		{
			get	{ return denumire; }
			set { denumire = value; }
		}
		/// <summary>
		/// Centrul de cost al departamentului.
		/// </summary>
		public int CentruCostId
		{
			get	{ return centruCostId; }
			set { centruCostId = value; }
		}
		/// <summary>
		/// Seful departamentului.
		/// </summary>
		public int SefId
		{
			get	{ return sefId; }
			set { sefId = value; }
		}
		/// <summary>
		/// Inlocuitorul sefului departamentului.
		/// </summary>
		public int InlocSefId
		{
			get	{ return inlocSefId; }
			set { inlocSefId = value; }
		}
		/// <summary>
		/// Secretara departamentului departamentului.
		/// </summary>
		public string Secretariat
		{
			get	{ return secretariat; }
			set { secretariat = value; }
		}
		/// <summary>
		/// Departamentul parinte.
		/// </summary>
		public int DeptParinte
		{
			get	{ return deptParinte; }
			set { deptParinte = value; }
		}
		#endregion

		#region LoadInfoDepartamente
		/// <summary>
		/// Procedura determina toate datele despre departamentele cu un anumit parinte
		/// </summary>
		/// <returns>Returneaza un DataSet care contine toate subdepartamentele unui departament parinte</returns>
		public DataSet LoadInfoDepartamente()
		{
			Salaries.Data.AdminDepartament departament = new Salaries.Data.AdminDepartament(settings.ConnectionString);
			return departament.LoadInfoDepartamente(deptParinte);
		}
		#endregion

		#region InsertDepartament
		/// <summary>
		/// Procedura adauga un departament
		/// </summary>
		public void InsertDepartament()
		{
			Salaries.Data.AdminDepartament departament = new Salaries.Data.AdminDepartament(settings.ConnectionString);
			departament.InsertDepartament(departamentId, denumire, centruCostId, sefId, inlocSefId, secretariat, deptParinte);
		}
		#endregion

		#region UpdateDepartament
		/// <summary>
		/// Procedura modifica un departament
		/// </summary>
		public void UpdateDepartament()
		{
			Salaries.Data.AdminDepartament departament = new Salaries.Data.AdminDepartament(settings.ConnectionString);
			departament.UpdateDepartament(departamentId, denumire, centruCostId, sefId, inlocSefId, secretariat, deptParinte);
		}
		#endregion

		#region DeleteDepartament
		/// <summary>
		/// Procedura sterge un departament
		/// </summary>
		public void DeleteDepartament()
		{
			Salaries.Data.AdminDepartament departament = new Salaries.Data.AdminDepartament(settings.ConnectionString);
			departament.DeleteDepartament(departamentId);
		}
		#endregion

		#region GetDepartamentInfo
		/// <summary>
		/// Procedura incarca datele despre un anumit departament
		/// </summary>
		/// <returns>Returneaza departamentul selectat</returns>
		public DataSet GetDepartamentInfo()
		{
			Salaries.Data.AdminDepartament departament = new Salaries.Data.AdminDepartament(settings.ConnectionString);
			return departament.GetDepartamentInfo(departamentId);
		}
		#endregion

		#region CheckIfDepartamentCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un departament poate fi sters
		/// </summary>
		/// <returns>Returneaza rezultatul verificarii daca departamentul poate fi sters
		/// 0 - se poate sterge
		/// 1 - este asociat unor angajati
		/// 2 - este departament parinte
		/// 3 - este ultimul din lista
		/// </returns>
		/// <remarks>
		/// Modificat:	Oprescu Claudia
		/// Data:		27.02.2007
		/// </remarks>
		public int CheckIfDepartamentCanBeDeleted()
		{
			Salaries.Data.AdminDepartament departament = new Salaries.Data.AdminDepartament(settings.ConnectionString);
			return departament.CheckIfDepartamentCanBeDeleted(departamentId);
		}
		#endregion

		#region CheckIfAdminDepartamentCanBeAdded
		/// <summary>
		/// Procedura verifica daca se poate face adaugare/modificare in tabela Departamente fara a se crea duplicate
		/// </summary>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfAdminDepartamentCanBeAdded()
		{
			Salaries.Data.AdminDepartament departament = new Salaries.Data.AdminDepartament(settings.ConnectionString);
			return departament.CheckIfAdminDepartamentCanBeAdded(departamentId, centruCostId, denumire, deptParinte);
		}
		#endregion

		#region GetSefPentruDepartament
		/// <summary>
		/// Procedura determina sefii departamentelor
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele respective</returns>
		public DataSet GetSefPentruDepartament()
		{
			Salaries.Data.AdminDepartament departament = new Salaries.Data.AdminDepartament(settings.ConnectionString);
			return departament.GetSefPentruDepartament();
		}
		#endregion

		#region GetSecretaraPentruDepartament
		/// <summary>
		/// Procedura determina secretarele departamentelor
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele respective</returns>
		public DataSet GetSecretaraPentruDepartament()
		{
			Salaries.Data.AdminDepartament departament = new Salaries.Data.AdminDepartament(settings.ConnectionString);
			return departament.GetSecretaraPentruDepartament();
		}
		#endregion

		#region GetAllDepartamente
		// Autor: Lungu Andreea
		// Data: 02.11.2007
		/// <summary>
		/// Procedura determina toate datele despre toate departamentele.
		/// </summary>
		/// <returns> Returneaza un DataSet care contine toate departamentele.</returns>
		public DataSet GetAllDepartamente()
		{
			Salaries.Data.AdminDepartament departament = new Salaries.Data.AdminDepartament(settings.ConnectionString);
			return departament.GetAllDepartamente();
		}
		#endregion

	}
}
