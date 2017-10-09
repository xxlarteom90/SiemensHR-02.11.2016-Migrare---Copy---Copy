using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminDomeniiDeActivitate.
	/// </summary>
	public class AdminDomeniiDeActivitate  : Salaries.Data.DbObject
	{
		#region AdminDomeniiDeActivitate
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminDomeniiDeActivitate(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoDomeniiDeActivitate
		/// <summary>
		/// Procedura selecteaza toate domeniile de activitate
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste domenii</returns>
		public DataSet LoadInfoDomeniiDeActivitate()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetAllDomeniiDeActivitate", parameters, "GetAllDomeniiDeActivitate");
		}
		#endregion

		#region GetDomeniuDeActivitateInfo
		/// <summary>
		/// Procedura selecteaza un domeniu de activitate
		/// </summary>
		/// <param name="domeniuDeActivitateId">Id-ul domeniului de activitate selectat</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetDomeniuDeActivitateInfo(int domeniuDeActivitateId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@DomDeActivitateID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = domeniuDeActivitateId;			
			return RunProcedure("GetDomeniuDeActivitateInfo", parameters, "GetDomeniuDeActivitateInfo");
		}
		#endregion

		#region InsertDomeniuDeActivitate
		/// <summary>
		/// Procedura adauga un domeniu de activitate
		/// </summary>
		/// <param name="domeniuDeActivitateId">Id-ul domeniului de activitate</param>
		/// <param name="codCAEN">Codul CAEN al domeniului</param>
		/// <param name="denumire">Denumirea domeniului</param>
		/// <param name="descriere">Descrierea domeniului</param>
		/// <param name="procent">Procentul domeniului</param>
		/// <param name="norma">Norma procentului</param>
		public void InsertDomeniuDeActivitate(int domeniuDeActivitateId, int codCAEN, string denumire, string descriere, double procent, int norma, bool retinereAccidente)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@DomDeActivitateID", SqlDbType.Int, 4),
								new SqlParameter("@CodCAEN", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 100),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 200),
								new SqlParameter("@Procent", SqlDbType.Real, 4),
								new SqlParameter("@Norma", SqlDbType.Int, 4),
								new SqlParameter("@RetinereAccidente", SqlDbType.Bit, 1)
							};

			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = codCAEN;
			parameters[3].Value = denumire;
			parameters[4].Value = descriere;
			parameters[5].Value = procent;
			parameters[6].Value = norma;
			parameters[7].Value = retinereAccidente;

			RunProcedure("InsertUpdateDeleteDomeniuDeActivitate", parameters);
		}
		#endregion

		#region UpdateDomeniuDeActivitate
		/// <summary>
		/// Procedura actualizeaza un domeniu de activitate
		/// </summary>
		/// <param name="domeniuDeActivitateId">Id-ul domeniului de activitate</param>
		/// <param name="codCAEN">Codul CAEN al domeniului</param>
		/// <param name="denumire">Denumirea domeniului</param>
		/// <param name="descriere">Descrierea domeniului</param>
		/// <param name="procent">Procentul domeniului</param>
		/// <param name="norma">Norma procentului</param>
		public void UpdateDomeniuDeActivitate(int domeniuDeActivitateId, int codCAEN, string denumire, string descriere, double procent, int norma, bool retinereAccidente)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@DomDeActivitateID", SqlDbType.Int, 4),
								new SqlParameter("@CodCAEN", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 100),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 200),
								new SqlParameter("@Procent", SqlDbType.Real, 4),
								new SqlParameter("@Norma", SqlDbType.Int, 4),
								new SqlParameter("@RetinereAccidente", SqlDbType.Bit, 1)
							};

			parameters[0].Value = 1;
			parameters[1].Value = domeniuDeActivitateId;
			parameters[2].Value = codCAEN;
			parameters[3].Value = denumire;
			parameters[4].Value = descriere;
			parameters[5].Value = procent;
			parameters[6].Value = norma;
			parameters[7].Value = retinereAccidente;

			RunProcedure("InsertUpdateDeleteDomeniuDeActivitate", parameters);
		}
		#endregion

		#region DeleteDomeniuDeActivitate
		/// <summary>
		/// Procedura sterge un domeniu de activitate
		/// </summary>
		/// <param name="domeniuDeActivitateId">Id-ul domeniului de activitate care se sterge</param>
		public void DeleteDomeniuDeActivitate(int domeniuDeActivitateId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@DomDeActivitateID", SqlDbType.Int, 4),
								new SqlParameter("@CodCAEN", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 100),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 200),
								new SqlParameter("@Procent", SqlDbType.Real, 4),
								new SqlParameter("@Norma", SqlDbType.Int, 4),
								new SqlParameter("@RetinereAccidente", SqlDbType.Bit, 1)
							};

			parameters[0].Value = 2;
			parameters[1].Value = domeniuDeActivitateId;
			parameters[2].Value = 0;
			parameters[3].Value = "";
			parameters[4].Value = "";
			parameters[5].Value = 0;
			parameters[6].Value = 8;
			parameters[7].Value = true;

			RunProcedure("InsertUpdateDeleteDomeniuDeActivitate", parameters);
		}
		#endregion

		#region GetDomeniiDeActDisponibilePtAngajator
		/// <summary>
		/// Procedura selecteaza domeniile de activitate ale unui angajator
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetDomeniiDeActDisponibilePtAngajator(int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
							};

			parameters[0].Value = angajatorId;
			return RunProcedure("GetDomDeActDisponibilePtAngajator", parameters, "GetDomDeActDisponibilePtAngajator");
		}
		#endregion

		#region CheckIfDomeniuDeActivitateCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un domeniu de activitate poate fi sters
		/// </summary>
		/// <param name="domDeActivitateId">Id-ul domeniului de activitate pentru care se face verificarea</param>
		/// <returns>Returneaza rezultatul verificarii daca s-a putut efectua stergerea
		/// 0 - se poate sterge
		/// 1 - exista date asociate domeniului
		/// 2 - este ultimul domeniu din lista
		/// </returns>
		/// <remarks>
		/// Modificat:	Oprescu Claudia
		/// Data:		27.02.2007
		/// </remarks>
		public int CheckIfDomeniuDeActivitateCanBeDeleted(int domDeActivitateId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@DomDeActivitateID", SqlDbType.Int, 4),
								new SqlParameter("@SePoateSterge", SqlDbType.Int, 4)
							};

			parameters[0].Value = domDeActivitateId;
			parameters[1].Direction = ParameterDirection.Output;
			RunProcedure("CheckIfDomDeActCanBeDeleted", parameters);

			return int.Parse(parameters[1].Value.ToString());
		}
		#endregion

		#region CheckIfDomeniuDeActivitateCanBeAdded
		/// <summary>
		/// Procedura este folosita pentru a verifica daca se poate face adaugare/modificare fara a se crea duplicate
		/// </summary>
		/// <param name="domDeActivitateID">Id-ul domeniului de activitate care nu trebuie sa concida</param>
		/// <param name="codCAEN">Codul pentru un domeniu</param>
		/// <param name="denumire">Denumirea pentru un domeniu</param>
		/// <param name="procent">Procentul pentru un domeniu</param>
		/// <param name="norma">Norma pentru un domeniu</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfDomeniuDeActivitateCanBeAdded(int domDeActivitateId, int codCAEN, string denumire, float procent, int norma)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@DomDeActivitateID", SqlDbType.Int, 4),
								new SqlParameter("@CodCAEN", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 100),
								new SqlParameter("@Procent", SqlDbType.Real, 4),
								new SqlParameter("@Norma", SqlDbType.Int, 4),
								new SqlParameter("@NrDomenii", SqlDbType.Int, 4)
							};

			parameters[0].Value = domDeActivitateId;
			parameters[1].Value = codCAEN;
			parameters[2].Value = denumire;
			parameters[3].Value = procent;
			parameters[4].Value = norma;
			parameters[5].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfDomeniuDeActivitateCanBeAdded", parameters);
			return byte.Parse(parameters[5].Value.ToString()) == 0;
		}
		#endregion
	}
}
