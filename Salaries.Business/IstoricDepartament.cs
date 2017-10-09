using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for IstoricDepartament.
	/// </summary>
	public class IstoricDepartament
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul angajatului
		private long angajatId;
		//Id-ul departamentului
		private int departamentId;
		//Data de inceput a activitatii la departament nou
		private DateTime dataStartNoua;
		//Data de inceput a activitatii la departament vechi
		private DateTime dataStartVeche;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public IstoricDepartament()
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
		/// ID-ul departamentului.
		/// </summary>
		public int DepartamentId
		{
			get{ return departamentId; }
			set{ departamentId = value;}
		}
		/// <summary>
		/// Data de inceput a activitatii la departament nou.
		/// </summary>
		public DateTime DataStartNoua
		{
			get{ return dataStartNoua; }
			set{ dataStartNoua = value;}
		}
		/// <summary>
		/// Data de inceput a activitatii la departament vechi.
		/// </summary>
		public DateTime DataStartVeche
		{
			get{ return dataStartVeche; }
			set{ dataStartVeche = value;}
		}
		#endregion

		#region LoadIstoricDepartament
		/// <summary>
		/// Procedura selecteaza departamentele unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine departamentele</returns>
		public DataSet LoadIstoricDepartament()
		{
			Salaries.Data.IstoricDepartament istDept = new Salaries.Data.IstoricDepartament(settings.ConnectionString);
			return istDept.LoadIstoricDepartament(angajatId);
		}
		#endregion

		#region InsertDepartament
		/// <summary>
		/// Procedura adauga un departament pentru un angajat
		/// </summary>
		public void InsertDepartament()
		{
			Salaries.Data.IstoricDepartament istDept = new Salaries.Data.IstoricDepartament(settings.ConnectionString);
			istDept.InsertDepartament(angajatId, departamentId, dataStartNoua);
		}
		#endregion

		#region UpdateDepartament
		/// <summary>
		/// Procedura actualizeaza un departament
		/// </summary>
		public void UpdateDepartament()
		{
			Salaries.Data.IstoricDepartament istDept = new Salaries.Data.IstoricDepartament(settings.ConnectionString);
			istDept.UpdateDepartament(angajatId, departamentId, dataStartNoua, dataStartVeche);
		}
		#endregion

		#region DeleteDepartament
		/// <summary>
		/// Procedura sterge un departament
		/// </summary>
		public void DeleteDepartament()
		{
			Salaries.Data.IstoricDepartament istDept = new Salaries.Data.IstoricDepartament(settings.ConnectionString);
			istDept.DeleteDepartament(angajatId, departamentId, dataStartNoua);
		}
		#endregion

		#region CheckIfDepartamentCanBeAdded
		/// <summary>
		/// Procedura verifica daca in tabela IstoricAngajatDepartament mai exista un departament adaugat pentru aceeasi data
		/// </summary>
		/// <returns>true daca se poate adauga o noua inregistrare si false altfel</returns>
		public bool CheckIfDepartamentCanBeAdded()
		{
			Salaries.Data.IstoricDepartament istDept = new Salaries.Data.IstoricDepartament(settings.ConnectionString);
			return istDept.CheckIfDepartamentCanBeAdded(angajatId, dataStartNoua);
		}
		#endregion
	}
}
