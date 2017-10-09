using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminTipuriRapoarte.
	/// </summary>
	public class AdminTipuriRapoarte : Salaries.Data.DbObject
	{
		#region AdminTipuriRapoarte
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminTipuriRapoarte(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoTipuriRapoarte
		/// <summary>
		/// Procedura selecteaza toate tipurile de rapoarte
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadInfoTipuriRapoarte()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("spGetAllTipuriRapoarte", parameters, "GetAllTipuriRapoarte");
		}
		#endregion

		#region InsertTipRaport
		/// <summary>
		/// Procedura adauga un tip de raport
		/// </summary>
		/// <param name="tipRaportId">Id-ul tipului de raport</param>
		/// <param name="denumire">Denumirea tipului de raport</param>
		/// <param name="descriere"></param>
		public void InsertTipRaport(int tipRaportId, string denumire, string descriere)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TipRaportID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 50),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255)
							};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = denumire;
			parameters[3].Value = descriere;

			RunProcedure("InsertUpdateDeleteTipRaport", parameters);
		}
		#endregion

		#region UpdateTipRaport
		/// <summary>
		/// Procedura actualizeaza un tip de raport
		/// </summary>
		/// <param name="tipRaportId">Id-ul tipului de raport</param>
		/// <param name="denumire">Denumirea tipului de raport</param>
		/// <param name="descriere"></param>
		public void UpdateTipRaport(int tipRaportId, string denumire, string descriere)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TipRaportID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 50),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255)
							};
			
			parameters[0].Value = 1;
			parameters[1].Value = tipRaportId;
			parameters[2].Value = denumire;
			parameters[3].Value = descriere;

			RunProcedure("InsertUpdateDeleteTipRaport", parameters);
		}
		#endregion

		#region DeleteTipRaport
		/// <summary>
		/// Procedura sterge un tip de raport
		/// </summary>
		/// <param name="tipRaportId">Id-ul tipului de raport</param>
		public void DeleteTipRaport(int tipRaportId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TipRaportID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 50),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255)
							};
			
			parameters[0].Value = 2;
			parameters[1].Value = tipRaportId;
			parameters[2].Value = "";
			parameters[3].Value = "";

			RunProcedure("InsertUpdateDeleteTipRaport", parameters);
		}
		#endregion

		#region GetTipRaportInfo
		/// <summary>
		/// Procedura selecteaza un tip de raport
		/// </summary>
		/// <param name="tipRaportId">Id-ul raportului selectat</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipRaportInfo(int tipRaportId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@TipRaportID", SqlDbType.Int, 4)
							};
			parameters[0].Value = tipRaportId;
			return RunProcedure("spGetTipRaport", parameters, "GetTipRaport");
		}
		#endregion

		#region CheckIfTipRaportCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un tip de raport poate fi sters
		/// </summary>
		/// <param name="tipRaportId">Id-ul tipului de raport care se verifica daca se poate sterge</param>
		/// <returns>Returneaza rezultatul verificarii</returns>
		public int CheckIfTipRaportCanBeDeleted(int tipRaportId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@TipRaportID", SqlDbType.Int, 4),
								new SqlParameter("@SePoateSterge", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = tipRaportId;
			parameters[1].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfTipRaportCanBeDeleted", parameters);
			return int.Parse(parameters[1].Value.ToString());
		}
		#endregion

		#region CheckIfTipRaportCanBeAdded
		/// <summary>
		/// Procedura verifica sa nu se adauge duplicate in tabela TipuriRapoarte prin adaugare/modificare
		/// </summary>
		/// <param name="tipRaportID">Id-ul tipului de raport care nu trebuie sa coincida</param>
		/// <param name="denumire">Numele tipului de raport</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfTipRaportCanBeAdded(int tipRaportId, string denumire)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@TipRaportID", SqlDbType.Int, 4),
								new SqlParameter("@Denumire", SqlDbType.NVarChar, 50),
								new SqlParameter("@NrTipuri", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = tipRaportId;
			parameters[1].Value = denumire;
			parameters[2].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfTipRaportCanBeAdded", parameters);
			return byte.Parse(parameters[2].Value.ToString()) == 0;
		}
		#endregion
	}
}
