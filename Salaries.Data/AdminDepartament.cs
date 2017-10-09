using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminDepartament.
	/// </summary>	
	public class AdminDepartament : Salaries.Data.DbObject
	{
		#region AdminDepartament
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminDepartament(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoDepartamente
		/// <summary>
		/// Procedura determina toate datele despre departamentele cu un anumit parinte
		/// </summary>
		/// <param name="deptParinte">Departamentul parinte pentur care se determina departamentele</param>
		/// <returns>Returneaza un DataSet care contine toate subdepartamentele unui departament parinte</returns>
		public DataSet LoadInfoDepartamente(int deptParinte)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@DeptParinte", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = deptParinte;
			
			return RunProcedure("GetDepartamente", parameters, "GetDepartamente");
		}
		#endregion

		#region InsertDepartament
		/// <summary>
		/// Procedura adauga un departament
		/// </summary>
		/// <param name="departamentId">Id-ul departamentului</param>
		/// <param name="denumire">Denumirea departamentului</param>
		/// <param name="centruCostId">Centrul de cost de care apartine departamentul</param>
		/// <param name="sefId">Seful departamentului</param>
		/// <param name="inlocSefId">Inlocuitorul sefului de departament</param>
		/// <param name="deptPatinte">Departamentul parinte</param>
		public void InsertDepartament(int departamentId, string denumire, int centruCostId, int sefId, int inlocSefId, string secretarariat, int deptParinte)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@DepartamentID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 255),
								new SqlParameter("@CentruCostID", SqlDbType.Int, 4),
								new SqlParameter("@SefID", SqlDbType.Int, 4),
								new SqlParameter("@InlocSefID", SqlDbType.Int, 4),
								new SqlParameter("@Secretariat", SqlDbType.NVarChar, 30),
								new SqlParameter("@DeptParinte", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = denumire;
			parameters[3].Value = centruCostId;
			parameters[4].Value = sefId;
			parameters[5].Value = -1;
			parameters[6].Value = secretarariat;
			
			if (inlocSefId != -1)
			{
				parameters[5].Value = inlocSefId;
			}
			parameters[7].Value = deptParinte;
			
			RunProcedure("InsertUpdateDeleteDepartament", parameters);
		}
		#endregion

		#region UpdateDepartament
		/// <summary>
		/// Procedura actualizeaza un departament
		/// </summary>
		/// <param name="departamentId">Id-ul departamentului</param>
		/// <param name="denumire">Denumirea departamentului</param>
		/// <param name="centruCostId">Centrul de cost de care apartine departamentul</param>
		/// <param name="sefId">Seful departamentului</param>
		/// <param name="inlocSefId">Inlocuitorul sefului de departament</param>
		/// <param name="deptPatinte">Departamentul parinte</param>
		public void UpdateDepartament(int departamentId, string denumire, int centruCostId, int sefId, int inlocSefId, string secretariat, int deptParinte)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@DepartamentID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 255),
								new SqlParameter("@CentruCostID", SqlDbType.Int, 4),
								new SqlParameter("@SefID", SqlDbType.Int, 4),
								new SqlParameter("@InlocSefID", SqlDbType.Int, 4),
								new SqlParameter("@Secretariat", SqlDbType.NVarChar, 30),
								new SqlParameter("@DeptParinte", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = 1;
			parameters[1].Value = departamentId;
			parameters[2].Value = denumire;
			parameters[3].Value = centruCostId;
			parameters[4].Value = sefId;
			parameters[5].Value = inlocSefId;
			parameters[6].Value = secretariat;
			parameters[7].Value = deptParinte;
			
			RunProcedure("InsertUpdateDeleteDepartament", parameters);
		}
		#endregion

		#region DeleteDepartament
		/// <summary>
		/// Procedura sterge un departament
		/// </summary>
		/// <param name="DepartamentID">Id-ul departamentului care se sterge</param>
		public void DeleteDepartament(int departamentId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@DepartamentID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 255),
								new SqlParameter("@CentruCostID", SqlDbType.Int, 4),
								new SqlParameter("@SefID", SqlDbType.Int, 4),
								new SqlParameter("@InlocSefID", SqlDbType.Int, 4),
								new SqlParameter("@Secretariat", SqlDbType.NVarChar, 30),
								new SqlParameter("@DeptParinte", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = 2;
			parameters[1].Value = departamentId;
			parameters[2].Value = "";
			parameters[3].Value = 0;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = "";
			parameters[7].Value = 0;
			
			RunProcedure("InsertUpdateDeleteDepartament", parameters);
		}
		#endregion

		#region GetDepartamentInfo
		/// <summary>
		/// Procedura incarca datele despre un anumit departament
		/// </summary>
		/// <param name="DepartamentID">Id-ul departamentului pentru care se obtin datele</param>
		/// <returns>Returneaza departamentul selectat</returns>
		public DataSet GetDepartamentInfo(int DepartamentID)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@DepartamentID", SqlDbType.Int, 4),
							};
			
			parameters[0].Value = DepartamentID;
	
			return RunProcedure("GetDepartamentInfo", parameters, "GetDepartamentInfo");
		}
		#endregion

		#region CheckIfDepartamentCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un departament poate fi sters
		/// </summary>
		/// <param name="DepartamentID">Id-ul departamentului care se verifica daca se poate sterge</param>
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
		public int CheckIfDepartamentCanBeDeleted( int DepartamentID)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@DepartamentID", SqlDbType.Int, 4),
								new SqlParameter("@SePoateSterge", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = DepartamentID;
			parameters[1].Direction = ParameterDirection.Output;
	
			RunProcedure("spCheckIfDepartamentCanBeDeleted", parameters);
			return int.Parse(parameters[1].Value.ToString());
		}
		#endregion

		#region CheckIfAdminDepartamentCanBeAdded
		/// <summary>
		/// Procedura verifica daca se poate face adaugare/modificare in tabela Departamente fara a se crea duplicate
		/// </summary>
		/// <param name="departamentID">Id-ul departamentrului care nu trebuie sa coincida</param>
		/// <param name="centruCostID">Id-ul pentru centrul de cost</param>
		/// <param name="denumire">Denumirea pentru centrul de cost</param>
		/// <param name="sefID">Id-ul sefului</param>
		/// <param name="inlocSefID">Id-ul inlocuitorului sefului</param>
		/// <param name="deptParinte">Departamentul parinte</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfAdminDepartamentCanBeAdded(int departamentID, int centruCostID, string denumire, int deptParinte)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@DepartamentID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 255),
								new SqlParameter("@CentruCostID", SqlDbType.Int, 4),
								new SqlParameter("@DeptParinte", SqlDbType.Int, 4),
								new SqlParameter("@NrDepartamente", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = departamentID;
			parameters[1].Value = denumire;
			parameters[2].Value = centruCostID;
			parameters[3].Value = deptParinte;
			parameters[4].Direction = ParameterDirection.Output;
	
			RunProcedure("spCheckIfAdminDepartamentCanBeAdded", parameters);
			return byte.Parse(parameters[4].Value.ToString()) == 0;
		}
		#endregion

		#region GetSefPentruDepartament
		/// <summary>
		/// Procedura determina sefii departamentelor
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele respective</returns>
		public DataSet GetSefPentruDepartament()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetSefPentruDepartament", parameters, "GetSefPentruDepartament");
		}
		#endregion

		#region GetSecretaraPentruDepartament
		/// <summary>
		/// Procedura determina secretarele departamentelor
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele respective</returns>
		public DataSet GetSecretaraPentruDepartament()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetSecretaraPentruDepartament", parameters, "GetSecretaraPentruDepartament");
		}
		#endregion

		#region GetAllDepartamente
		/// <summary>
		/// Procedura aduce toate departamentele existente.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine toate departamentele</returns>
		public DataSet GetAllDepartamente()
		{
			SqlParameter[] parameters = {};

			return RunProcedure("GetAllDepartamente", parameters, "GetDepartamente");
		}
		#endregion
	}
}
