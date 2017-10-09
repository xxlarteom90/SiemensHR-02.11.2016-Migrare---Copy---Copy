/*
 * Autor: Cristina Muntean 
 */
using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	public struct ConcediiMedicale
	{
		public int id_Criteriu;
		public int ValMinimAngajati;
		public int ValMaximAngajati;
		public int NrZilePlatite;
	}

	/// <summary>
	/// Summary description for NomenclatorConcediiMedicale.
	/// </summary>
	public class NomenclatorConcediiMedicale: Salaries.Data.DbObject
	{
		#region Constructor
		public NomenclatorConcediiMedicale( string newConnectionString ) : base( newConnectionString )
		{		
		}
		#endregion

		#region GetConcediiMedicale
		/// <summary>
		/// Procedura selecteaza concediile mediclae
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetConcediiMedicale()
		{			
			SqlParameter[] parameters = {};

			return RunProcedure("GetConcediiMedicale", parameters, "ConcediiMedicale");
		}
		#endregion

		#region Insert
		/// <summary>
		/// Procedura adauga un concediu medical
		/// </summary>
		/// <param name="valMinimAngajati">Nr minim de angajati</param>
		/// <param name="valMaximAngajati">Nr maxim de angajati</param>
		/// <param name="nrZilePlatite">Nr de zile platite</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool Insert(int valMinimAngajati,int valMaximAngajati,int nrZilePlatite)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@id_Criteriu", SqlDbType.Int, 4),
					new SqlParameter("@ValMinimAngajati", SqlDbType.Int, 4),
					new SqlParameter("@ValMaximAngajati", SqlDbType.Int, 4),
					new SqlParameter("@NrZilePlatite", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = 0;
			parameters[ 1 ].Value = 0;
			parameters[ 2 ].Value = valMinimAngajati;
			parameters[ 3 ].Value = valMaximAngajati;
			parameters[ 4 ].Value = nrZilePlatite;
			
			RunProcedure("InsertUpdateConcediuMedicZilePlatite", parameters, out numAffected);
			
			return (numAffected > 0);
		}
		#endregion

		#region Update
		/// <summary>
		/// Procedura actualizeaza datele unui concediu medical
		/// </summary>
		/// <param name="id_Criteriu">Id-ul criteriului de concediu medical</param>
		/// <param name="valMinimAngajati">Nr minim  de angajati</param>
		/// <param name="valMaximAngajati">Nr maxim de angajati</param>
		/// <param name="nrZilePlatite">Nr de zile platite</param>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool Update(int id_Criteriu,int valMinimAngajati,int valMaximAngajati,int nrZilePlatite)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@id_Criteriu", SqlDbType.Int, 4),
					new SqlParameter("@ValMinimAngajati", SqlDbType.Int, 4),
					new SqlParameter("@ValMaximAngajati", SqlDbType.Int, 4),
					new SqlParameter("@NrZilePlatite", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = 1;
			parameters[ 1 ].Value = id_Criteriu;
			parameters[ 2 ].Value = valMinimAngajati;
			parameters[ 3 ].Value = valMaximAngajati;
			parameters[ 4 ].Value = nrZilePlatite;

			RunProcedure("InsertUpdateConcediuMedicZilePlatite", parameters, out numAffected);
			
			return (numAffected > 0);
		}

		#endregion

		#region Delete
		/// <summary>
		/// Procedura sterge un criteriu de concediu medical
		/// </summary>
		/// <param name="id_Criteriu">Id-ul criteriului care se sterge</param>
		/// <returns>Returneaza true daca s-a facut stergerea si false altfel</returns>
		public bool Delete(int id_Criteriu)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@id_Criteriu", SqlDbType.Int, 4),
					new SqlParameter("@ValMinimAngajati", SqlDbType.Int, 4),
					new SqlParameter("@ValMaximAngajati", SqlDbType.Int, 4),
					new SqlParameter("@NrZilePlatite", SqlDbType.Int, 4)
				};

			parameters[ 0 ].Value = 2;
			parameters[ 1 ].Value = id_Criteriu;
			parameters[ 2 ].Value = 0;
			parameters[ 3 ].Value = 0;
			parameters[ 4 ].Value = 0;
			
			RunProcedure("InsertUpdateConcediuMedicZilePlatite", parameters, out numAffected);

			return (numAffected == 1);
		}
		#endregion

		#region CheckInsertConcediuMedical
		/// <summary>
		/// Procedura verifica daca un criteriu de concediu medical poate fi adaugat
		/// </summary>
		/// <param name="valMinimAngajati">Nr minim de angajati</param>
		/// <param name="valMaximAngajati">Nr maxim de angajati</param>
		/// <param name="idCriteriu">Id-ul criteriului</param>
		/// <returns>Returneaza rezultatul verificarii</returns>
		public int CheckInsertConcediuMedical(int valMinimAngajati, int valMaximAngajati, int idCriteriu)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@ValMin", SqlDbType.Int, 4),
					new SqlParameter("@ValMax", SqlDbType.Int, 4),
					new SqlParameter("@id_criteriu", SqlDbType.Int, 4),
					new SqlParameter("@OK", SqlDbType.Int, 4)
				};
		
			parameters[ 0 ].Value = valMinimAngajati;
			parameters[ 1 ].Value = valMaximAngajati;
			parameters[ 2 ].Value = idCriteriu;
			parameters[ 3 ].Direction = ParameterDirection.Output;
			
			RunProcedure("CheckInsertConcediiMedic", parameters, out numAffected);

			return (int)parameters[3].Value;
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
			SqlParameter[] parameters = 
				{
					new SqlParameter("@id_Criteriu", SqlDbType.Int, 4),
					new SqlParameter("@sePoateSterge", SqlDbType.Int, 4)
				};
		
			parameters[ 0 ].Value = concediuMedicalID;
			parameters[ 1 ].Direction = ParameterDirection.Output;
			
			RunProcedure("spCheckIfConcediuMedicalCanBeDeleted", parameters);
			return int.Parse(parameters[1].Value.ToString()) == 1;
		}
		#endregion
	}
}
