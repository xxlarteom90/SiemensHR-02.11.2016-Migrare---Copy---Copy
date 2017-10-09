using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for IstoricPermisMunca.
	/// </summary>
	public class IstoricPermisMunca : Salaries.Data.DbObject
	{ 
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public IstoricPermisMunca(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadIstoricPermiseMunca
		/// <summary>
		/// Procedura selecteaza permisele de munca ale unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadIstoricPermiseMunca(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatId;
			return RunProcedure("GetPermiseMuncaAngajat", parameters, "GetPermiseMuncaAngajat");
		}
		#endregion

		#region InsertPermisMunca
		/// <summary>
		/// Procedura adauga un permis de munca
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="seriePermisMunca">Seria permisului de munca</param>
		/// <param name="nrPermisMunca">Numarul permisului de munca</param>
		/// <param name="permisMuncaDataEliberare">Data eliberare</param>
		/// <param name="permisMuncaDataExpirare">Data expirare</param>
		/// <param name="activ">Specifica daca permisul este activ sau nu</param>
		public void InsertPermisMunca(long angajatId, string seriePermisMunca, long nrPermisMunca, DateTime permisMuncaDataEliberare, DateTime permisMuncaDataExpirare, bool activ)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@PermisMuncaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NrpermisMunca", SqlDbType.BigInt, 10),
					new SqlParameter("@SeriepermisMunca", SqlDbType.NVarChar, 10),
					new SqlParameter("@PermMuncaDataEliberare", SqlDbType.DateTime, 8),
					new SqlParameter("@PermMuncaDataExpirare", SqlDbType.DateTime, 8),
					new SqlParameter("@Activ", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 0;
			parameters[1].Value = -1;
			parameters[2].Value = angajatId;
			parameters[3].Value = nrPermisMunca;
			parameters[4].Value = seriePermisMunca;
			parameters[5].Value = permisMuncaDataEliberare;
			parameters[6].Value = permisMuncaDataExpirare;
			parameters[7].Value = activ;
			
			RunProcedure("InsertUpdateDeletePermisMunca", parameters);
		}
		#endregion

		#region UpdatePermisMunca
		/// <summary>
		/// Procedura actualizeaza un permis de munca
		/// </summary>
		/// <param name="permisMuncaId">Id-ul permisului de munca</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="seriePermisMunca">Seria permisului de munca</param>
		/// <param name="nrPermisMunca">Numarul permisului de munca</param>
		/// <param name="permisMuncaDataEliberare">Data eliberare</param>
		/// <param name="permisMuncaDataExpirare">Data expirare</param>
		/// <param name="activ">Specifica daca permisul este activ sau nu</param>
		public void UpdatePermisMunca(int permisMuncaId, long angajatId, string seriePermisMunca, long nrPermisMunca, DateTime permisMuncaDataEliberare, DateTime permisMuncaDataExpirare, bool activ)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@PermisMuncaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NrpermisMunca", SqlDbType.BigInt, 10),
					new SqlParameter("@SeriepermisMunca", SqlDbType.NVarChar, 10),
					new SqlParameter("@PermMuncaDataEliberare", SqlDbType.DateTime, 8),
					new SqlParameter("@PermMuncaDataExpirare", SqlDbType.DateTime, 8),
					new SqlParameter("@Activ", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = permisMuncaId;
			parameters[2].Value = angajatId;
			parameters[3].Value = nrPermisMunca;
			parameters[4].Value = seriePermisMunca;
			parameters[5].Value = permisMuncaDataEliberare;
			parameters[6].Value = permisMuncaDataExpirare;
			parameters[7].Value = activ;
			
			RunProcedure("InsertUpdateDeletePermisMunca", parameters);
		}
		#endregion

		#region DeletePermisMunca
		/// <summary>
		/// Procedura sterge un permis de munca
		/// </summary>
		/// <param name="permisMuncaId">Id-ul permisului de munca</param>
		public void DeletePermisMunca(int permisMuncaId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@PermisMuncaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NrpermisMunca", SqlDbType.BigInt, 10),
					new SqlParameter("@SeriepermisMunca", SqlDbType.NVarChar, 10),
					new SqlParameter("@PermMuncaDataEliberare", SqlDbType.DateTime, 8),
					new SqlParameter("@PermMuncaDataExpirare", SqlDbType.DateTime, 8),
					new SqlParameter("@Activ", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = permisMuncaId;
			parameters[2].Value = -1;
			parameters[3].Value = 0;
			parameters[4].Value = "";
			parameters[5].Value = System.DBNull.Value;
			parameters[6].Value = System.DBNull.Value;
			parameters[7].Value = false;
			
			RunProcedure("InsertUpdateDeletePermisMunca", parameters);
		}
		#endregion

		#region CheckIfPermisMuncaCanBeAdded
		/// <summary>
		/// Procedura verifica daca un permise de munca poate fi adaugat astfel incat sa nu se creeze duplicate
		/// </summary>
		/// <param name="permisId">Id-ul permisului care se verifica</param>
		/// <param name="serie">Seria permisului</param>
		/// <param name="numar">Numarul permisului</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfPermisMuncaCanBeAdded(int permisId, string serie, long numar)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@PermisMuncaID", SqlDbType.Int, 4),
					new SqlParameter("@Serie", SqlDbType.NVarChar, 10),
					new SqlParameter("@Numar", SqlDbType.BigInt, 8),
					new SqlParameter("@NrPermise", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = permisId;
			parameters[1].Value = serie;
			parameters[2].Value = numar;
			parameters[3].Direction = ParameterDirection.Output;
			
			RunProcedure("spCheckIfPermisMuncaCanBeAdded", parameters);
			return byte.Parse(parameters[3].Value.ToString()) == 0;
		}
		#endregion
	}
}
