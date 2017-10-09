using System;
using System.Data;
using System.Data.SqlClient;

//	Modificat: Lungu Andreea 26.05.2008
// a fost adaugat un nou camp IdCasaDeAsigImplicita

//	Modificat: Lungu Andreea 16.02.2011
// a fost adaugat noi campuri CUI si NrCrtSediuSecundar

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminPunctLucru.
	/// </summary>
	public class AdminPunctLucru
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul punctului de lucru
		private int punctLucruId;
		//Id-ul angajatorului
		private int angajatorId;
		//Denumirea punctului de lucru
		private string nume;
		//id-ul casei de asigurari implicite
		private int idCasaDeAsigImplicita;
		//cui
		private string cui;
		//nr. crt. sediu secundar
		private string nrCrtSediuSecundar;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminPunctLucru()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul punctului de lucru
		/// </summary>
		public int PunctLucruId
		{
			get { return punctLucruId; }
			set { punctLucruId =  value; }
		}
		/// <summary>
		/// Id-ul angajatorului
		/// </summary>
		public int AngajatorId
		{
			get { return angajatorId; }
			set { angajatorId =  value; }
		}
		/// <summary>
		/// Denumirea punctului de lucru
		/// </summary>
		public string Nume
		{
			get { return nume; }
			set { nume = value; }
		}
		/// <summary>
		/// Id-ul casei de asigurari care se considera implicita
		/// </summary>
		public int IdCasaDeAsigImplicita
		{
			get { return idCasaDeAsigImplicita; }
			set { idCasaDeAsigImplicita =  value; }
		}
		/// <summary>
		/// CUI
		/// </summary>
		public string Cui
		{
			get { return cui; }
			set { cui = value; }
		}
		/// <summary>
		/// Nr. crt. sediu secundar
		/// </summary>
		public string NrCrtSediuSecundar
		{
			get { return nrCrtSediuSecundar; }
			set { nrCrtSediuSecundar = value; }
		}
		#endregion

		#region LoadInfoPunctLucru
		/// <summary>
		/// Se obtin informatiile despre un anumit punct de lucru
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele despre un punct de lucru</returns>
		public DataSet LoadInfoPunctLucru()
		{
			Salaries.Data.AdminPunctLucru punctLucru = new Salaries.Data.AdminPunctLucru(settings.ConnectionString);
			return punctLucru.LoadInfoPunctLucru(punctLucruId);
		}
		#endregion

		#region LoadInfoPunctLucruAngajator
		/// <summary>
		/// Se obtin Punctele de lucru ale unui anumit angajator
		/// </summary>
		/// <returns>Returneaza un DataSet care contine punctele de lucru ale angajatorului</returns>
		public DataSet LoadInfoPunctLucruAngajator()
		{
			Salaries.Data.AdminPunctLucru punctLucru = new Salaries.Data.AdminPunctLucru(settings.ConnectionString);
			return punctLucru.LoadInfoPunctLucruAngajator(angajatorId);
		}
		#endregion

		#region LoadInfoPunctLucruAngajatorUnion
		/// <summary>
		/// Se obtin Punctele de lucru ale unui anumit angajator. Se adauga o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine punctele de lucru ale angajatorului</returns>
		public DataSet LoadInfoPunctLucruAngajatorUnion()
		{
			Salaries.Data.AdminPunctLucru punctLucru = new Salaries.Data.AdminPunctLucru(settings.ConnectionString);
			return punctLucru.LoadInfoPunctLucruAngajatorUnion(angajatorId);
		}
		#endregion

		#region LoadInfoPunctLucruAngajatori
		/// <summary>
		/// Se obtin Punctele de lucru ale tuturor angajatorilor
		/// </summary>
		/// <returns>Returneaza un DataSet care contine punctele de lucru ale angajatorilor</returns>
		// Lungu Andreea - 28.05.2008
		public DataSet LoadInfoPunctLucruAngajatori()
		{
			Salaries.Data.AdminPunctLucru punctLucru = new Salaries.Data.AdminPunctLucru(settings.ConnectionString);
			return punctLucru.LoadInfoPunctLucruAngajatori();
		}
		#endregion

		#region GetPuncteDeLucruAngajatori
		/// <summary>
		/// Se obtin punctele de lucru ale angajatorilor.
		/// </summary>
		/// <returns>Un DataSet ce cuprinde toate punctele de lucru ale angajatorilor.</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  3.06.2006
		/// </remarks>
		public DataSet GetPuncteDeLucruAngajatori()
		{
			Salaries.Data.AdminPunctLucru punctLucru = new Salaries.Data.AdminPunctLucru(settings.ConnectionString);
			return punctLucru.GetPuncteDeLucruAngajatori();
		}
		#endregion

		#region InsertPunctLucru
		/// <summary>
		/// Procedura adauga un punct de lucru
		/// </summary>
		public void InsertPunctLucru()
		{
			Salaries.Data.AdminPunctLucru punctLucru = new Salaries.Data.AdminPunctLucru(settings.ConnectionString);
			punctLucru.InsertPunctLucru(punctLucruId, angajatorId, nume, idCasaDeAsigImplicita, cui, nrCrtSediuSecundar);
		}
		#endregion

		#region UpdatePunctLucru
		/// <summary>
		/// Procedura actualizeaza un punct de lucru
		/// </summary>
		public void UpdatePunctLucru()
		{
			Salaries.Data.AdminPunctLucru punctLucru = new Salaries.Data.AdminPunctLucru(settings.ConnectionString);
			punctLucru.UpdatePunctLucru(punctLucruId, angajatorId, nume, idCasaDeAsigImplicita, cui, nrCrtSediuSecundar);
		}
		#endregion

		#region DeletePunctLucru
		/// <summary>
		/// Procedura sterge un punct de lucru
		/// </summary>
		public void DeletePunctLucru()
		{
			Salaries.Data.AdminPunctLucru punctLucru = new Salaries.Data.AdminPunctLucru(settings.ConnectionString);
			punctLucru.DeletePunctLucru(punctLucruId);
		}
		#endregion

		#region DeleteAllPunctLucruAngajator
		/// <summary>
		/// Sunt sterse toate domeniile de activitate ale angajatorului cu id-ul AngajatorID
		/// </summary>
		public void DeleteAllPunctLucruAngajator()
		{
			Salaries.Data.AdminPunctLucru punctLucru = new Salaries.Data.AdminPunctLucru(settings.ConnectionString);
			punctLucru.DeleteAllPunctLucruAngajator(angajatorId);
		}
		#endregion

		#region CheckIfPunctLucruCanBeDeleted
		/// <summary>
		/// Verifica daca un punct de lucru poate fi sters, adica nu sunt angajati pentru el
		/// </summary>
		/// <returns>Returneaza true daca se poate efectua stergerea si false altfel</returns>
		public bool CheckIfPunctLucruCanBeDeleted()
		{
			Salaries.Data.AdminPunctLucru punctLucru = new Salaries.Data.AdminPunctLucru(settings.ConnectionString);
			return punctLucru.CheckIfPunctLucruCanBeDeleted(punctLucruId);
		}
		#endregion
	}
}
