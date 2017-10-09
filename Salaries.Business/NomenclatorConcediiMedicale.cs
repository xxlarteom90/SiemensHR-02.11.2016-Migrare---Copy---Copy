/*
 * Autor: Cristina Muntean
 */
using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for NomenclatorConcediiMedicale.
	/// </summary>
	public class NomenclatorConcediiMedicale: Salaries.Business.BizObject
	{
		#region Atribute private
		//Setarile aplicatiei
		private Configuration.ModuleSettings settings;
		//Id-ul criteriului de concediu medical
		private int id_Criteriu;
		//Numarul minim de angajati
		private int valMinimAngajati;
		//Numarul maxim de angajati
		private int valMaximAngajati;
		//Nr de zile platite
		private int nrZilePlatite;
		#endregion

		#region Proprietati
		public int Id_Criteriu
		{
			get { return id_Criteriu; }
			set { id_Criteriu = value; }
		}
		public int ValMinimAngajati
		{
			get { return valMinimAngajati; }
			set { valMinimAngajati = value; }
		}
		public int ValMaximAngajati
		{
			get { return valMaximAngajati; }
			set { valMaximAngajati = value; }
		}
		public int NrZilePlatite
		{
			get { return nrZilePlatite; }
			set { nrZilePlatite = value; }
		}
		#endregion

		#region Constructor
		public NomenclatorConcediiMedicale()
		{
			settings = Configuration.ModuleConfig.GetSettings();
			ResetConcediiMedicale();
		}
		#endregion

		#region ResetConcediiMedicale
		/// <summary>
		/// Procedura reseteaza datele criteriului de concediu medical
		/// </summary>
		private void ResetConcediiMedicale()
		{
			id_Criteriu = -1;
			valMinimAngajati = -1;
			valMaximAngajati = -1;
			nrZilePlatite = -1;
		}
		#endregion
        
		#region Insert
		/// <summary>
		/// Procedura adauga un criteriu de concediu medical
		/// </summary>
		/// <param name="valMinimAngajati">Nr minim de angajati</param>
		/// <param name="valMaximAngajati">Nr maxim de angajati</param>
		/// <param name="nrZilePlatite">Nr de zile platite</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool Insert(int valMinimAngajati, int valMaximAngajati, int nrZilePlatite)
		{
			Data.NomenclatorConcediiMedicale concediiMedicale = new Data.NomenclatorConcediiMedicale(settings.ConnectionString);
			bool inserted = concediiMedicale.Insert(valMinimAngajati, valMaximAngajati, nrZilePlatite);
			return inserted;
		}
		#endregion
	
		#region Update
		/// <summary>
		/// Procedura actualizeaza un criteriu de concediu medical
		/// </summary>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool Update()
		{
			Data.NomenclatorConcediiMedicale concediiMedicale = new Data.NomenclatorConcediiMedicale(settings.ConnectionString);
			bool updated = concediiMedicale.Update(id_Criteriu, valMinimAngajati, valMaximAngajati, nrZilePlatite);
			return updated;
		}
		#endregion

		#region Delete
		/// <summary>
		/// Procedura sterge un criteriu de concediu medical
		/// </summary>
		/// <returns>Returneaza true daca s-a facut stergerea si false altfel</returns>
		public bool Delete()
		{
			Data.NomenclatorConcediiMedicale concediiMedicale = new Data.NomenclatorConcediiMedicale(settings.ConnectionString);
			bool deleted = concediiMedicale.Delete(id_Criteriu);
			ResetConcediiMedicale();
			return deleted;
		}
		#endregion

		#region GetConcediiMedicale
		/// <summary>
		/// Procedura selecteaza criteriile de concedii medicale
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public  DataSet GetConcediiMedicale()
		{
			Data.NomenclatorConcediiMedicale concediiMedicale = new Data.NomenclatorConcediiMedicale(settings.ConnectionString);
			return concediiMedicale.GetConcediiMedicale();
		}
		#endregion

		#region CheckInsertConcediuMedical
		/// <summary>
		/// Procedura verifica daca un criteriu de concediu medical poate fi adaugat
		/// </summary>
		/// <returns>Returneaza rezultatul verificarii</returns>
		public int CheckInsertConcediuMedical()
		{
			Data.NomenclatorConcediiMedicale concediiMedicale = new Data.NomenclatorConcediiMedicale(settings.ConnectionString);
			return concediiMedicale.CheckInsertConcediuMedical(valMinimAngajati, valMaximAngajati, id_Criteriu);
		}
		#endregion

		#region CheckIfConcediuMedicalCanBeDeleted 
		/// <summary>
		/// Procedura verifica daca un criteriu de concediu medical poate fi sters sau nu
		/// </summary>
		/// <param name="concediuMedicalID">Id-ul criteriului care se verifica daca poate fi sters sau nu</param>
		/// <returns>Returneaza true daca se poate face stergerea si false altfel</returns>
		public bool CheckIfConcediuMedicalCanBeDeleted(int concediuMedicalID)
		{
			Data.NomenclatorConcediiMedicale concediiMedicale = new Data.NomenclatorConcediiMedicale(settings.ConnectionString);
			return concediiMedicale.CheckIfConcediuMedicalCanBeDeleted(concediuMedicalID);
		}
		#endregion
	}
}
