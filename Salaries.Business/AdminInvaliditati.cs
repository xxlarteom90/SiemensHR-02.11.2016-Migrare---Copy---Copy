using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminInvaliditati.
	/// </summary>
	public class AdminInvaliditati
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul invaliditatii
		private int invaliditateId;
		//Denumirea invaliditatii
		private string nume;
		//Coeficientul invaliditatii
		private float coeficient;
		//Descrierea invaliditatii
		private string descriere;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminInvaliditati()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul invaliditatii
		/// </summary>
		public int InvaliditateId
		{
			get { return invaliditateId; }
			set { invaliditateId =  value; }
		}
		/// <summary>
		/// Denumirea invaliditatii
		/// </summary>
		public string Nume
		{
			get { return nume; }
			set { nume =  value; }
		}
		/// <summary>
		/// Coeficientul invaliditatii
		/// </summary>
		public float Coeficient
		{
			get { return coeficient; }
			set { coeficient =  value; }
		}
		/// <summary>
		/// Descrierea invaliditatii
		/// </summary>
		public string Descriere
		{
			get { return descriere; }
			set { descriere =  value; }
		}
		#endregion

		#region LoadInfoInvaliditati
		/// <summary>
		/// Procedura selecteaza toate invaliditatile
		/// </summary>
		/// <returns></returns>
		public DataSet LoadInfoInvaliditati()
		{
			Salaries.Data.AdminInvaliditati invaliditate = new Salaries.Data.AdminInvaliditati(settings.ConnectionString);
			return invaliditate.LoadInfoInvaliditati();
		}
		#endregion

		#region InsertInvaliditate
		/// <summary>
		/// Procedura adauga o invaliditate
		/// </summary>
		public void InsertInvaliditate()
		{
			Salaries.Data.AdminInvaliditati invaliditate = new Salaries.Data.AdminInvaliditati(settings.ConnectionString);
			invaliditate.InsertInvaliditate(invaliditateId, nume, coeficient, descriere);
		}
		#endregion

		#region UpdateInvaliditate
		/// <summary>
		/// Procedura actualizeaza o invaliditate
		/// </summary>
		public void UpdateInvaliditate()
		{
			Salaries.Data.AdminInvaliditati invaliditate = new Salaries.Data.AdminInvaliditati(settings.ConnectionString);
			invaliditate.UpdateInvaliditate(invaliditateId, nume, coeficient, descriere);
		}
		#endregion

		#region DeleteInvaliditate
		/// <summary>
		/// Procedura sterge o invaliditate
		/// </summary>
		public void DeleteInvaliditate()
		{
			Salaries.Data.AdminInvaliditati invaliditate = new Salaries.Data.AdminInvaliditati(settings.ConnectionString);
			invaliditate.DeleteInvaliditate(invaliditateId);
		}
		#endregion

		#region GetInvaliditateInfo
		/// <summary>
		/// Procedura selecteaza o invaliditate
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele despre invaliditate</returns>
		public DataSet GetInvaliditateInfo()
		{
			Salaries.Data.AdminInvaliditati invaliditate = new Salaries.Data.AdminInvaliditati(settings.ConnectionString);
			return invaliditate.GetInvaliditateInfo(invaliditateId);
		}
		#endregion

		#region CheckIfInvaliditateCanBeDeleted
		/// <summary>
		/// Procedura verifica daca o invaliditate poate fi stearsa, adica nu exista inregistrari in tabela AngajatPersoaneInIntretinere si tm_IntervaleAngajat
		/// </summary>
		/// <returns>Returneaza true daca se poate face stergerea si false altfel</returns>
		public int CheckIfInvaliditateCanBeDeleted()
		{
			Salaries.Data.AdminInvaliditati invaliditate = new Salaries.Data.AdminInvaliditati(settings.ConnectionString);
			return invaliditate.CheckIfInvaliditateCanBeDeleted(invaliditateId);
		}
		#endregion

		#region CheckIfInvaliditateCanBeAdded
		/// <summary>
		/// Procedura verifica daca mai exista in baza de date o invaliditate cu aceleasi date
		/// </summary>
		/// <returns>Returneaza true daca se poate face modificarea si false altfel</returns>
		public bool CheckIfInvaliditateCanBeAdded()
		{
			Salaries.Data.AdminInvaliditati invaliditate = new Salaries.Data.AdminInvaliditati(settings.ConnectionString);
			return invaliditate.CheckIfInvaliditateCanBeAdded(invaliditateId, nume, coeficient);
		}
		#endregion
	}
}
