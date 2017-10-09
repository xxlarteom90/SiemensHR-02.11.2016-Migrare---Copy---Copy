using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminTipuriCompletareCarnete.
	/// </summary>
	public class AdminTipuriCompletareCarnete : Salaries.Data.DbObject
	{
		#region AdminTipuriCompletareCarnete
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminTipuriCompletareCarnete(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoTipuriCompletare
		/// <summary>
		/// Procedura selecteaza tipurile de completare ale carnetelor de munca ale unui angajator
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului pentru care se face selectarea</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadInfoTipuriCompletare(int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@tipCompletareCarnetID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = angajatorId;
			parameters[1].Direction = ParameterDirection.Input;
			parameters[1].Value = System.DBNull.Value;
			return RunProcedure("spGetTipuriCompletareCarnete", parameters, "GetTipuriCompletareCarnete");
		}
		#endregion

		#region InsertTipCompletare
		/// <summary>
		/// Procedura adauga un tip de completare de carnet de munca
		/// </summary>
		/// <param name="tipCompletareCarnetId">Id-ul tipului de completare de carnet</param>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="descriere">Descrierea tipului de completare</param>
		/// <param name="cod">Codul tipului de completare</param>
		/// <param name="procent">Procentul tipului de completare</param>
		public void InsertTipCompletare(int tipCompletareCarnetId, int angajatorId, string descriere, string cod, float procent)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TipCompletareID", SqlDbType.Int, 4),
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255),
								new SqlParameter("@Cod", SqlDbType.NVarChar, 100),
								new SqlParameter("@Procent", SqlDbType.Float, 255)
							};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = angajatorId;
			parameters[3].Value = descriere;
			parameters[4].Value = cod;
			parameters[5].Value = procent;

			RunProcedure("InsertUpdateDeleteTipCompletare", parameters);
		}
		#endregion

		#region UpdateTipCompletare
		/// <summary>
		/// Procedura actualizeaza un tip de completare de carnet de munca
		/// </summary>
		/// <param name="tipCompletareCarnetId">Id-ul tipului de completare de carnet</param>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <param name="descriere">Descrierea tipului de completare</param>
		/// <param name="cod">Codul tipului de completare</param>
		/// <param name="procent">Procentul tipului de completare</param>
		public void UpdateTipCompletare(int tipCompletareCarnetId, int angajatorId, string descriere, string cod, float procent)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TipCompletareID", SqlDbType.Int, 4),
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255),
								new SqlParameter("@Cod", SqlDbType.NVarChar, 100),
								new SqlParameter("@Procent", SqlDbType.Float, 255)
							};
			
			parameters[0].Value = 1;
			parameters[1].Value = tipCompletareCarnetId;
			parameters[2].Value = angajatorId;
			parameters[3].Value = descriere;
			parameters[4].Value = cod;
			parameters[5].Value = procent;

			RunProcedure("InsertUpdateDeleteTipCompletare", parameters);
		}
		#endregion

		#region DeleteTipCompletare
		/// <summary>
		/// Procedura sterfe un tip de completare de carnet de munca
		/// </summary>
		/// <param name="tipCompletareCarnetId">Id-ul tipului de completare de carnet</param>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		public void DeleteTipCompletare(int tipCompletareCarnetId, int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TipCompletareID", SqlDbType.Int, 4),
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@Descriere", SqlDbType.NVarChar, 255),
								new SqlParameter("@Cod", SqlDbType.NVarChar, 100),
								new SqlParameter("@Procent", SqlDbType.Float, 255)
							};
			
			parameters[0].Value = 2;
			parameters[1].Value = tipCompletareCarnetId;
			parameters[2].Value = angajatorId;
			parameters[3].Value = "";
			parameters[4].Value = "";
			parameters[5].Value = 0;

			RunProcedure("InsertUpdateDeleteTipCompletare", parameters);
		}
		#endregion

		#region GetTipCompletareInfo
		/// <summary>
		/// Procedura selecteaza un tip de completare de carnet a unui angajator
		/// </summary>
		/// <param name="tipCompletareCarnetId">Id-ul tipului de completare selectat</param>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipCompletareInfo(int tipCompletareCarnetId, int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tipCompletareCarnetID", SqlDbType.Int, 4),
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
							};
			
			parameters[0].Value = tipCompletareCarnetId;
			parameters[1].Value = angajatorId;

			return RunProcedure("spGetTipuriCompletareCarnete", parameters, "GetTipuriCompletareCarnete");
		}
		#endregion

		#region GetTipuriCompletareCarnete
		/// <summary>
		/// Returneaza tipurile de completare are carnetelor de munca.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului pentru care sunt selectate tipurile de completare</param>
		/// <returns> Tipurile de completare ale carnetelor de munca sunt stocate intr-un DataSet.</returns>
		public DataSet GetTipuriCompletareCarnete(int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@tipCompletareCarnetID", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = angajatorId;
			parameters[1].Direction = ParameterDirection.Input;
			parameters[1].Value = System.DBNull.Value;

			return RunProcedure("spGetTipuriCompletareCarnete", parameters, "GetTipuriCompletareCarnete");
		}
		#endregion

		#region CheckIfTipCompletareCarnetCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un tip de completare poate fi sters sau nu
		/// </summary>
		/// <param name="tipCompletareCarnetID">Id-ul tipului pentru care se face verificarea</param>
		/// <returns>Returneaza 0 daca se poate face stergerea, 
		///						1 daca exista date asociate tipului,
		///						2 daca tipul este ultimul din lista
		///	</returns>
		///	<remarks>
		///	Autor:	Oprescu Claudia
		///	Data:	23.03.2007
		///	</remarks>
		public int CheckIfTipCompletareCarnetCanBeDeleted(int tipCompletareCarnetId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@TipCompletareCarnetID", SqlDbType.Int, 4),
								new SqlParameter("@SePoateSterge", SqlDbType.Int, 4),
			};
			
			parameters[0].Value = tipCompletareCarnetId;
			parameters[1].Direction = ParameterDirection.Output;
			
			RunProcedure("spCheckIfTipuriCompletareCarneteCanBeDeleted", parameters);
			return int.Parse(parameters[1].Value.ToString());
		}
		#endregion

		#region CheckIfCarneteTipuriCanBeAdded
		/// <summary>
		/// Procedura verifica sa nu se aduage duplicate in tabela sal_CompletareCarneteTipuri
		/// </summary>
		/// <param name="completareCarnetTipID">Id-ul tipului de carnet care nu trebuie sa coincida</param>
		/// <param name="modCompletare">Modul de completare al carnetului</param>
		/// <param name="cod">Codul pentru tipul de carnet</param>
		/// <param name="angajatorID"> Id-ul angajatorului pentru care se verifica tipurile de carnete</param>
		/// <returns>Retunreaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfCarneteTipuriCanBeAdded(int completareCarnetTipId, string modCompletare, string cod, int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@ModCompletare", SqlDbType.NVarChar, 128),
								new SqlParameter("@Cod", SqlDbType.NVarChar, 32),
								new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
								new SqlParameter("@CompletareCarnetTipID", SqlDbType.Int, 4),
								new SqlParameter("@NrTipuri", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = modCompletare;
			parameters[1].Value = cod;
			parameters[2].Value = angajatorId;
			parameters[3].Value = completareCarnetTipId;
			parameters[4].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfCarneteTipuriCanBeAdded", parameters);
			return int.Parse(parameters[4].Value.ToString()) == 0;
		}
		#endregion
	}
}
