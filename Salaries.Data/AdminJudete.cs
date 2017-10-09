using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminJudete.
	/// </summary>
	public class AdminJudete : Salaries.Data.DbObject
	{
		#region AdminJudete
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminJudete(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoJudete
		/// <summary>
		/// Procedura selecteaza toate judetele
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadInfoJudete()
		{
			SqlParameter[] parameters = {};		
			return RunProcedure("GetAllJudete", parameters, "GetAllJudete");
		}
		#endregion

		#region GetAllJudeteTara
		/// <summary>
		/// Procedura returneaza toate judetele unei tari
		/// </summary>
		/// <param name="taraID">Id-ul tarii pentru care sunt returnate judetele</param>
		/// <returns>Returneaza un DataSet care contine judetele tarii</returns>
		public DataSet GetAllJudeteTara(int taraId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@TaraID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = taraId;			
			return RunProcedure("spGetAllJudeteTara", parameters, "GetAllJudeteTara");
		}
		#endregion

		#region InsertJudet
		/// <summary>
		/// Procedura adauga un judet
		/// </summary>
		/// <param name="judetId">Id-ul judetului</param>
		/// <param name="taraId">Tara de care apartine judetul</param>
		/// <param name="nume">Denumriea judetului</param>
		/// <param name="simbol">Simbolul judetului</param>
		/// <param name="cod">Codul judetului</param>
		public void InsertJudet(int judetId, int taraId, string nume, string simbol, string cod)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@JudetID", SqlDbType.Int, 4),
								new SqlParameter("@TaraID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Simbol", SqlDbType.NVarChar, 255),
								new SqlParameter("@Cod", SqlDbType.NVarChar, 5)
							};

			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = taraId;
			parameters[3].Value = nume;
			parameters[4].Value = simbol;
			parameters[5].Value = cod;

			RunProcedure("InsertUpdateDeleteJudet", parameters);
		}
		#endregion

		#region UpdateJudet
		/// <summary>
		/// Procedura actualizeaza un judet
		/// </summary>
		/// <param name="judetId">Id-ul judetului</param>
		/// <param name="taraId">Tara de care apartine judetul</param>
		/// <param name="nume">Denumriea judetului</param>
		/// <param name="simbol">Simbolul judetului</param>
		/// <param name="cod">Codul judetului</param>
		public void UpdateJudet(int judetId, int taraId, string nume, string simbol, string cod)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@JudetID", SqlDbType.Int, 4),
								new SqlParameter("@TaraID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Simbol", SqlDbType.NVarChar, 255),
								new SqlParameter("@Cod", SqlDbType.NVarChar, 5)
							};

			parameters[0].Value = 1;
			parameters[1].Value = judetId;
			parameters[2].Value = taraId;
			parameters[3].Value = nume;
			parameters[4].Value = simbol;
			parameters[5].Value = cod;

			RunProcedure("InsertUpdateDeleteJudet", parameters);
		}
		#endregion

		#region DeleteJudet
		/// <summary>
		/// Procedura sterge un judet
		/// </summary>
		/// <param name="judetId">Id-ul judetului ce se sterge</param>
		public void DeleteJudet(int judetId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@JudetID", SqlDbType.Int, 4),
								new SqlParameter("@TaraID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Simbol", SqlDbType.NVarChar, 255),
								new SqlParameter("@Cod", SqlDbType.NVarChar, 5)
							};

			parameters[0].Value = 2;
			parameters[1].Value = judetId;
			parameters[2].Value = -1;
			parameters[3].Value = "";
			parameters[4].Value = "";
			parameters[5].Value = "";

			RunProcedure("InsertUpdateDeleteJudet", parameters);
		}
		#endregion

		#region GetJudetInfo
		/// <summary>
		/// Procedura selecteaza un judet
		/// </summary>
		/// <param name="judetId">Id-ul judetului selectat</param>
		/// <returns>Returneaza un DataSet care contine datele despre judet</returns>
		public DataSet GetJudetInfo(int judetId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@JudetID", SqlDbType.Int, 4)
							};
			parameters[0].Value = judetId;
			return RunProcedure("GetJudetInfo", parameters, "GetJudetInfo");
		}
		#endregion

		#region CheckIfJudetCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un judet poate fi sters
		/// </summary>
		/// <param name="judetId">Id-ul judetului pentru care se facee verificarea</param>
		/// <returns>Returneaza rezulatul verificarii</returns>
		public int CheckIfJudetCanBeDeleted(int judetId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@JudetID", SqlDbType.Int, 4),
								new SqlParameter("@Raspuns", SqlDbType.Int, 4)
							};
			parameters[0].Value = judetId;
			parameters[1].Direction = ParameterDirection.ReturnValue;
			RunProcedure("CheckIfJudetCanBeDeleted", parameters, "CheckIfJudetCanBeDeleted");

			return int.Parse(parameters[1].Value.ToString());
		}
		#endregion

		#region VerificareExistentaJudet
		/// <summary>
		/// Se verifica daca exista un judet ce are aceleasi date cu cel trimis ca parametru.
		/// </summary>
		/// <param name="judetId">Id-ul judetului</param>
		/// <param name="taraId">Tara de care apartine judetul</param>
		/// <param name="nume">Denumriea judetului</param>
		/// <param name="simbol">Simbolul judetului</param>
		/// <param name="cod">Codul judetului</param>
		/// <returns>true in cazul in care exista, false altfel.</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  15.06.2006
		/// </remarks>
		public bool VerificareExistentaJudet(int judetId, int taraId, string nume, string simbol, string cod)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@JudetID", SqlDbType.Int, 4),
								new SqlParameter("@TaraID", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 50),
								new SqlParameter("@Simbol", SqlDbType.NVarChar, 255),
								new SqlParameter("@Cod", SqlDbType.NVarChar, 5),
								new SqlParameter("@existaJudet", SqlDbType.Bit, 1)
							};

			parameters[0].Value = judetId;
			parameters[1].Value = taraId;
			parameters[2].Value = nume;
			parameters[3].Value = simbol;
			parameters[4].Value = cod;
			parameters[5].Direction = ParameterDirection.Output;

			RunProcedure("CheckIfExistaJudet", parameters);
			return bool.Parse( parameters[5].Value.ToString() );
		}
		#endregion
	}
}
