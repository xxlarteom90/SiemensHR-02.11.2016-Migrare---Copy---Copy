using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for IstoricAlerte.
	/// </summary>
	public class IstoricAlerte : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public IstoricAlerte(string connectionString): base (connectionString)
		{}
		#endregion

		#region GetAlertaInfo
		/// <summary>
		/// Procedura selecteaza o alerta
		/// </summary>
		/// <param name="alertaId">Id-ul alertei</param>
		/// <returns>Returneaza un DataSet care contine datele despre alerta</returns>
	    public DataSet GetAlertaInfo(int alertaId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AlertaID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = alertaId;
			return RunProcedure("GetAlertaInfo", parameters, "GetAlertaInfo");
		}
		#endregion

		#region LoadInfoAlerta
		/// <summary>
		/// Procedura selecteaza alertele unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine date despre alertele angajatului</returns>
		public DataSet LoadInfoAlerta(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = angajatId;
			return RunProcedure("GetAngajatAlerte", parameters, "GetAngajatAlerte");
		}
		#endregion

		#region InsertAlerta
		/// <summary>
		/// Procedura adauga o alerta
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="dataExpirare">Data de expirare a alertei</param>
		/// <param name="perioadaCritica">Perioada critica a alertei</param>
		/// <param name="descriere">Descrierea alertei</param>
		/// <param name="activ">Specifica daca alerta este activa sau nu</param>
		public void InsertAlerta(long angajatId, DateTime dataExpirare, int perioadaCritica, string descriere, bool activ)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@AlertaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@DataExpirare", SqlDbType.DateTime, 8),
					new SqlParameter("@PerioadaCritica", SqlDbType.Int, 4),
					new SqlParameter("@Descriere", SqlDbType.NVarChar, 200),
					new SqlParameter("@Activ", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = angajatId;
			parameters[3].Value = dataExpirare;
			parameters[4].Value = perioadaCritica;
			parameters[5].Value = descriere;
			parameters[6].Value = activ;

			RunProcedure("InsertUpdateDeleteAlerte", parameters);
		}
		#endregion

		#region UpdateAlerta
		/// <summary>
		/// Procedura actualizeaza o alerta
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="dataExpirare">Data de expirare a alertei</param>
		/// <param name="perioadaCritica">Perioada critica a alertei</param>
		/// <param name="descriere">Descrierea alertei</param>
		/// <param name="activ">Specifica daca alerta este activa sau nu</param>
		public void UpdateAlerta(int alertaId, long angajatId, DateTime dataExpirare, int perioadaCritica, string descriere, bool activ)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@AlertaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@DataExpirare", SqlDbType.DateTime, 8),
					new SqlParameter("@PerioadaCritica", SqlDbType.Int, 4),
					new SqlParameter("@Descriere", SqlDbType.NVarChar, 200),
					new SqlParameter("@Activ", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = alertaId;
			parameters[2].Value = angajatId;
			parameters[3].Value = dataExpirare;
			parameters[4].Value = perioadaCritica;
			parameters[5].Value = descriere;
			parameters[6].Value = activ;

			RunProcedure("InsertUpdateDeleteAlerte", parameters);
		}
		#endregion

		#region DeleteAlerta
		/// <summary>
		/// Procedura sterge o alerta
		/// </summary>
		/// <param name="alertaId">Id-ul alertei</param>
		public void DeleteAlerta(int alertaId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@AlertaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@DataExpirare", SqlDbType.DateTime, 8),
					new SqlParameter("@PerioadaCritica", SqlDbType.Int, 4),
					new SqlParameter("@Descriere", SqlDbType.NVarChar, 200),
					new SqlParameter("@Activ", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = alertaId;
			parameters[2].Value = 0;
			parameters[3].Value = System.DBNull.Value;
			parameters[4].Value = 0;
			parameters[5].Value = "";
			parameters[6].Value = true;

			RunProcedure("InsertUpdateDeleteAlerte", parameters);
		}
		#endregion
	}
}
