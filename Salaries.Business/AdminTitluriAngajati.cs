using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminTitluriAngajati.
	/// </summary>
	public class AdminTitluriAngajati 
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul titlului
		private int titluId;
		//Denumirea titlului
		private string denumire;
		//Simbolul titlului
		private string simbol;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminTitluriAngajati()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul titlului
		/// </summary>
		public int TitluId
		{
			get	{ return titluId; }
			set { titluId = value; }
		}
		/// <summary>
		/// Denumirea titlului
		/// </summary>
		public string Denumire
		{
			get	{ return denumire; }
			set { denumire = value; }
		}
		/// <summary>
		/// Simbolul titlului
		/// </summary>
		public string Simbol
		{
			get	{ return simbol; }
			set { simbol = value; }
		}
		#endregion

		#region LoadInfoTitluriAngajati
		/// <summary>
		/// Procedura selecteaza titlurile unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadInfoTitluriAngajati()
		{
			Salaries.Data.AdminTitluriAngajati titlu = new Salaries.Data.AdminTitluriAngajati(settings.ConnectionString);
			return titlu.LoadInfoTitluriAngajati();
		}
		#endregion

		#region LoadInfoTitluriAngajatiUnion
		/// <summary>
		/// Sunt selectate toate categoriile de angajati. La aceste inregistrari se adauga o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoTitluriAngajatiUnion()
		{
			Salaries.Data.AdminTitluriAngajati titlu = new Salaries.Data.AdminTitluriAngajati(settings.ConnectionString);
			return titlu.LoadInfoTitluriAngajatiUnion();
		}
		#endregion

		#region InsertTitluAngajat
		/// <summary>
		/// Procedura adauga un titlu pentru angajati
		/// </summary>
		public void InsertTitluAngajat()
		{
			Salaries.Data.AdminTitluriAngajati titlu = new Salaries.Data.AdminTitluriAngajati(settings.ConnectionString);
			titlu.InsertTitluAngajat(titluId, denumire, simbol);
		}
		#endregion

		#region UpdateTitluAngajat
		/// <summary>
		/// Procedura actualizeaza un titlu pentur angajat
		/// </summary>
		public void UpdateTitluAngajat()
		{
			Salaries.Data.AdminTitluriAngajati titlu = new Salaries.Data.AdminTitluriAngajati(settings.ConnectionString);
			titlu.UpdateTitluAngajat(titluId, denumire, simbol);
		}
		#endregion

		#region DeleteTitluAngajat
		/// <summary>
		/// Procedura sterge un titlu pentru angajat
		/// </summary>
		public void DeleteTitluAngajat()
		{
			Salaries.Data.AdminTitluriAngajati titlu = new Salaries.Data.AdminTitluriAngajati(settings.ConnectionString);
			titlu.DeleteTitluAngajat(titluId);
		}
		#endregion

		#region GetTitluAngajatInfo
		/// <summary>
		/// Procedura selecteaza un titlu pentru angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele despre titlu</returns>
		public DataSet GetTitluAngajatInfo()
		{
			Salaries.Data.AdminTitluriAngajati titlu = new Salaries.Data.AdminTitluriAngajati(settings.ConnectionString);
			return titlu.GetTitluAngajatInfo(titluId);
		}
		#endregion

		#region CheckIfTitluAngajatCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un titlu poate fi sters
		/// </summary>
		/// <returns>Returneaza rezultatul verificarii
		/// 0 - se poate sterge titlul
		/// 1 - exista date asociate titlului
		/// 2 - titlul este ultimul din lista
		/// </returns>
		public int CheckIfTitluAngajatCanBeDeleted()
		{
			Salaries.Data.AdminTitluriAngajati titlu = new Salaries.Data.AdminTitluriAngajati(settings.ConnectionString);
			return titlu.CheckIfTitluAngajatCanBeDeleted(titluId);
		}
		#endregion

		#region CheckIfTitluAngajatCanBeAdded
		/// <summary>
		/// Procedura verifica sa nu se creeze duplicate in tabela TitluriAngajati
		/// </summary>
		/// <returns>Returneaza true daca se poate face modificare/adaugare si false altfel</returns>
		public bool CheckIfTitluAngajatCanBeAdded()
		{
			Salaries.Data.AdminTitluriAngajati titlu = new Salaries.Data.AdminTitluriAngajati(settings.ConnectionString);
			return titlu.CheckIfTitluAngajatCanBeAdded(titluId, denumire, simbol);
		}
		#endregion
	}
}
