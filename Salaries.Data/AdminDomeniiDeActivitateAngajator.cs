using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminDomeniiDeActivitateAngajator.
	/// </summary>
	public class AdminDomeniiDeActivitateAngajator : Salaries.Data.DbObject
	{
		#region AdminDomeniiDeActivitateAngajator
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminDomeniiDeActivitateAngajator(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoDomeniiDeActivitateAngajator
		/// <summary>
		/// Procedure selecteaza domeniile de activitate ale unui angajator
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului pentru care se selecteaza domeniile de activitate</param>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoDomeniiDeActivitateAngajator(int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = angajatorId;			
			return RunProcedure("GetDomDeActivitateAngajator", parameters, "GetDomDeActivitateAngajator");
		}
		#endregion

		#region GetDomeniuDeActivitateAngajatorInfo
		/// <summary>
		/// Procedura selecteaza un domeniu de activitate al unui angajator
		/// </summary>
		/// <param name="domeniuAngajatorId">Id-ul domeniului de activitate selectat</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetDomeniuDeActivitateAngajatorInfo(int domeniuAngajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@DomeniuAngajatorID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = domeniuAngajatorId;			
			return RunProcedure("GetDomDeActivitateAngajatorInfo", parameters, "GetDomDeActivitateAngajatorInfo");
		}
		#endregion

		#region GetPrincipalDomeniuDeActivitateAngajatorInfo
		/// <summary>
		/// Procedura selecteaza domeniul principal de activitate al unui angajator
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetPrincipalDomeniuDeActivitateAngajatorInfo(int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = angajatorId;			
			return RunProcedure("GetPrincipalDomDeActivitateAngajatorInfo", parameters, "GetPrincipalDomDeActivitateAngajatorInfo");
		}
		#endregion

		#region InsertDomeniuDeActivitateAngajator
		/// <summary>
		/// Procedura adauga un domeniu de activitate pentru un angajator
		/// </summary>
		/// <param name="domeniuAngajatorId">Id-ul domeniului nou</param>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="domeniuDeActivitateId">Id-ul domeniului de activitate care se adauga</param>
		/// <param name="principal">Specifica daca domeniul nou adaugat este principal sau nu</param>
		public void InsertDomeniuDeActivitateAngajator(int domeniuAngajatorId, int angajatorId, int domeniuDeActivitateId, bool principal)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@DomeniuAngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@DomDeActivitateID", SqlDbType.Int, 4),
								new SqlParameter("@Principal", SqlDbType.Bit, 1)
							};

			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = angajatorId;
			parameters[3].Value = domeniuDeActivitateId;
			parameters[4].Value = principal;
		
			RunProcedure("InsertUpdateDeleteDomDeActivitateAngajator", parameters);
		}
		#endregion

		#region UpdateDomeniuDeActivitateAngajator
		/// <summary>
		/// Procedura actualizeaza un domeniu de activitate
		/// </summary>
		/// <param name="domeniuAngajatorId">Id-ul domeniului nou</param>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="domeniuDeActivitateId">Id-ul domeniului de activitate care se adauga</param>
		/// <param name="principal">Specifica daca domeniul nou adaugat este principal sau nu</param>
		public void UpdateDomeniuDeActivitateAngajator(int domeniuAngajatorId, int angajatorId, int domeniuDeActivitateId, bool principal)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@DomeniuAngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@DomDeActivitateID", SqlDbType.Int, 4),
								new SqlParameter("@Principal", SqlDbType.Bit, 1)
							};

			parameters[0].Value = 1;
			parameters[1].Value = domeniuAngajatorId;
			parameters[2].Value = angajatorId;
			parameters[3].Value = domeniuDeActivitateId;
			parameters[4].Value = principal;
		
			RunProcedure("InsertUpdateDeleteDomDeActivitateAngajator", parameters);
		}
		#endregion

		#region DeleteDomeniuDeActivitateAngajator
		/// <summary>
		/// Procedura sterge un domeniu de activitate al unui angajator
		/// </summary>
		/// <param name="domeniuAngajatorId">Id-ul domeniului nou</param>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="domeniuDeActivitateId">Id-ul domeniului de activitate care se adauga</param>
		/// <param name="principal">Specifica daca domeniul nou adaugat este principal sau nu</param>
		public void DeleteDomeniuDeActivitateAngajator(int domeniuAngajatorId, int angajatorId, int domeniuDeActivitateId, bool principal)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@DomeniuAngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@DomDeActivitateID", SqlDbType.Int, 4),
								new SqlParameter("@Principal", SqlDbType.Bit, 1)
							};

			parameters[0].Value = 2;
			parameters[1].Value = domeniuAngajatorId;
			parameters[2].Value = angajatorId;
			parameters[3].Value = domeniuDeActivitateId;
			parameters[4].Value = principal;
		
			RunProcedure("InsertUpdateDeleteDomDeActivitateAngajator", parameters);
		}
		#endregion

		#region DeleteAllDomeniiDeActivitateAngajator
		/// <summary>
		/// Procedura sterge toate domeniile de activitate ale unui angajator
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului pentru care se sterg domeniile</param>
		public void DeleteAllDomeniiDeActivitateAngajator(int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@DomeniuAngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@DomDeActivitateID", SqlDbType.Int, 4),
								new SqlParameter("@Principal", SqlDbType.Bit, 1)
							};

			parameters[0].Value = 3;
			parameters[1].Value = 0;
			parameters[2].Value = angajatorId;
			parameters[3].Value = 0;
			parameters[4].Value = false;
		
			RunProcedure("InsertUpdateDeleteDomDeActivitateAngajator", parameters);
		}
		#endregion
	}
}
