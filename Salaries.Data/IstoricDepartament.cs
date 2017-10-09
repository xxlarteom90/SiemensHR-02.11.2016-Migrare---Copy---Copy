using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for IstoricDepartament.
	/// </summary>
	public class IstoricDepartament : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public IstoricDepartament(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadIstoricDepartament
		/// <summary>
		/// Procedura selecteaza departamentele unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine departamentele</returns>
		public DataSet LoadIstoricDepartament(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10)
			};
			parameters[0].Value = angajatId;
			return RunProcedure("GetIstoricDepartamenteAngajat", parameters, "GetIstoricDepartamenteAngajat");
		}
		#endregion

		#region InsertDepartament
		/// <summary>
		/// Procedura adauga un departament pentru un angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="departamentId">Id-ul departamentului</param>
		/// <param name="dataStart">Data de inceput a activitatii</param>
		public void InsertDepartament(long angajatId, int departamentId, DateTime dataStart)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@DepartamentID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8)
				};
			
			parameters[0].Value = 0;
			parameters[1].Value = angajatId;
			parameters[2].Value = departamentId;
			parameters[3].Value = dataStart;
			
			RunProcedure("InsertUpdateDeleteIstoricDepartament", parameters);
		}
		#endregion

		#region UpdateDepartament
		/// <summary>
		/// Procedura actualizeaza un departament
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="departamentId">Id-ul departamentului</param>
		/// <param name="new_dataStart">Noua data pentru departament</param>
		/// <param name="old_dataStart">Vechea data pentru departament</param>
		public void UpdateDepartament(long angajatId, int departamentId, DateTime new_dataStart, DateTime old_dataStart)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@DepartamentID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@old_DataStart", SqlDbType.DateTime, 8)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = angajatId;
			parameters[2].Value = departamentId;
			parameters[3].Value = new_dataStart.ToShortDateString();
			parameters[4].Value = old_dataStart.ToShortDateString();
			
			RunProcedure("InsertUpdateDeleteIstoricDepartament", parameters);
		}
		#endregion

		#region DeleteDepartament
		/// <summary>
		/// Procedura sterge un departament
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="departamentId">Id-ul departamentului</param>
		/// <param name="dataStart">Data de inceput a activitatii la departament</param>
		public void DeleteDepartament(long angajatId, int departamentId, DateTime dataStart)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@DepartamentID", SqlDbType.Int, 4),
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = angajatId;
			parameters[2].Value = 0;
			parameters[3].Value = dataStart.ToShortDateString();
			
			RunProcedure("InsertUpdateDeleteIstoricDepartament", parameters);
		}
		#endregion

		#region CheckIfDepartamentCanBeAdded
		/// <summary>
		/// Procedura verifica daca in tabela IstoricAngajatDepartament mai exista un departament adaugat pentru aceeasi data
		/// </summary>
		/// <param name="angajatId">id-ul angajatului pentru care se cauta inregistrari</param>
		/// <param name="dataStart">data pentru care nu trebuie sa mai existe un angajat adugat</param>
		/// <returns>true daca se poate adauga o noua inregistrare si false altfel</returns>
		public bool CheckIfDepartamentCanBeAdded(long angajatId, DateTime dataStart)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),					
					new SqlParameter("@DataStart", SqlDbType.DateTime, 8),
					new SqlParameter("@NrDepartamente", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = angajatId;
			parameters[1].Value = dataStart;
			parameters[2].Direction = ParameterDirection.Output;
			
			RunProcedure("spCheckIfDepartamentCanBeAdded", parameters);
			return byte.Parse(parameters[2].Value.ToString()) == 0;
		}
		#endregion
	}
}
