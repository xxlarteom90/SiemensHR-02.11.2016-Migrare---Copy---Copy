using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminTitluriAngajati.
	/// </summary>
	public class AdminTitluriAngajati : Salaries.Data.DbObject
	{
		#region AdminTitluriAngajati
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminTitluriAngajati(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoTitluriAngajati
		/// <summary>
		/// Procedura selecteaza titlurile unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadInfoTitluriAngajati()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetTitluriAngajati", parameters, "GetTitluriAngajati");
		}
		#endregion

		#region LoadInfoTitluriAngajatiUnion
		/// <summary>
		/// Sunt selectate toate categoriile de angajati. La aceste inregistrari se adauga o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoTitluriAngajatiUnion()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("spGetAllTitluriAngajatiUnion", parameters, "GetAllTitluriAngajatiUnion");
		}
		#endregion

		#region InsertTitluAngajat
		/// <summary>
		/// Procedura adauga un titlu pentru angajati
		/// </summary>
		/// <param name="titluId">Id-ul titlului</param>
		/// <param name="denumire">Denumirea titlului</param>
		/// <param name="simbol">Simbolul titlului</param>
		public void InsertTitluAngajat(int titluId, string denumire, string simbol)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TitluID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 50),
								new SqlParameter("@Simbol", SqlDbType.NVarChar, 255)
							};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = denumire;
			parameters[3].Value = simbol;

			RunProcedure("InsertUpdateDeleteTitluAngajat", parameters);
		}
		#endregion

		#region UpdateTitluAngajat
		/// <summary>
		/// Procedura actualizeaza un titlu pentur angajat
		/// </summary>
		/// <param name="titluId">Id-ul titlului</param>
		/// <param name="denumire">Denumirea titlului</param>
		/// <param name="simbol">Simbolul titlului</param>
		public void UpdateTitluAngajat(int titluId, string denumire, string simbol)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TitluID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 50),
								new SqlParameter("@Simbol", SqlDbType.NVarChar, 255)
							};
			
			parameters[0].Value = 1;
			parameters[1].Value = titluId;
			parameters[2].Value = denumire;
			parameters[3].Value = simbol;

			RunProcedure("InsertUpdateDeleteTitluAngajat", parameters);
		}
		#endregion

		#region DeleteTitluAngajat
		/// <summary>
		/// Procedura sterge un titlu pentru angajat
		/// </summary>
		/// <param name="titluId">Id-ul titlului care se sterge</param>
		public void DeleteTitluAngajat(int titluId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TitluID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 50),
								new SqlParameter("@Simbol", SqlDbType.NVarChar, 255)
							};
			
			parameters[0].Value = 2;
			parameters[1].Value = titluId;
			parameters[2].Value = "";
			parameters[3].Value = "";

			RunProcedure("InsertUpdateDeleteTitluAngajat", parameters);
		}
		#endregion

		#region GetTitluAngajatInfo
		/// <summary>
		/// Procedura selecteaza un titlu pentru angajat
		/// </summary>
		/// <param name="titluId">Id-ul titlului selectat</param>
		/// <returns>Returneaza un DataSet care contine datele despre titlu</returns>
		public DataSet GetTitluAngajatInfo(int titluId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@TitluAngajatID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = titluId;
			return RunProcedure("spGetTitluAngajat", parameters, "GetTitluAngajat");
		}
		#endregion

		#region CheckIfTitluAngajatCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un titlu poate fi sters
		/// </summary>
		/// <param name="TitluID">Id-ul titlui pentru care se face verificarea</param>
		/// <returns>Returneaza rezultatul verificarii
		/// 0 - se poate sterge titlul
		/// 1 - exista date asociate titlului
		/// 2 - titlul este ultimul din lista
		/// </returns>
		public int CheckIfTitluAngajatCanBeDeleted(int titluId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@TitluAngajatID", SqlDbType.Int, 4),
								new SqlParameter("@SePoateSterge", SqlDbType.Int, 4)
							};
			parameters[0].Value = titluId;
			parameters[1].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfTitluriAngajatiCanBeDeleted", parameters);
			return byte.Parse(parameters[1].Value.ToString());
		}
		#endregion

		#region CheckIfTitluAngajatCanBeAdded
		/// <summary>
		/// Procedura verifica sa nu se creeze duplicate in tabela TitluriAngajati
		/// </summary>
		/// <param name="titluID">Id-ul titlului care nu trebuie sa coincida</param>
		/// <param name="denumire">Denumirea titlului</param>
		/// <param name="simbol">Simbolul titlului</param>
		/// <returns>Returneaza true daca se poate face modificare/adaugare si false altfel</returns>
		public bool CheckIfTitluAngajatCanBeAdded(int titluId, string denumire, string simbol)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@TitluID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 50),
								new SqlParameter("@Simbol", SqlDbType.NVarChar, 255),
								new SqlParameter("@NrTitluri", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = titluId;
			parameters[1].Value = denumire;
			parameters[2].Value = simbol;
			parameters[3].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfTitluriAngajatiCanBeAdded", parameters);
			return byte.Parse(parameters[3].Value.ToString()) == 0;
		}
		#endregion
	}
}
