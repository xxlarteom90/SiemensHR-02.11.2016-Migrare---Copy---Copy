using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Data
{
	public struct PgPpAplicDetails
	{
		public int PaginaID;
		public string NumePagina;
		public string DescrierePagina;
	}

	/// <summary>
	/// Summary description for PaginiPpAplicatie.
	/// </summary>
	public class PaginiPpAplicatie: Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune</param>
		public PaginiPpAplicatie(string connectionString): base (connectionString){}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Returneaza toate detaliile despre o pagina
		/// </summary>
		/// <param name="paginaId">Id-ul paginii selectate</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public PgPpAplicDetails GetDetalii(int paginaId)
		{
			
			SqlParameter[] parameters = {new SqlParameter("@PaginaID", SqlDbType.Int, 4)};
			
			parameters[0].Value = paginaId;

			using(DataSet detaliiGrup = RunProcedure("GetPaginaPpAplicInfo", parameters , "InfoPagina"))
			{
				PgPpAplicDetails  pagina = new PgPpAplicDetails();
				if (detaliiGrup.Tables["InfoPagina"].Rows.Count > 0)
				{
					DataRow rowDetalii = detaliiGrup.Tables["InfoPagina"].Rows[0];
					pagina.PaginaID = (int)rowDetalii["PaginaID"];
					pagina.NumePagina = rowDetalii["NumePagina"].ToString();
					pagina.DescrierePagina = rowDetalii["DescrierePagina"].ToString();
				}
				else
					pagina.PaginaID = -1;

				return pagina;
			}
		}
		#endregion
		
		#region GetPaginiPpAplicatie
		/// <summary>
		/// Procedura returneaza toate paginile
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetPaginiPpAplicatie()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetPaginiPpAplicatie", parameters , "InfoPagina");
		}
		#endregion

		#region Insert
		/// <summary>
		/// Insereaza un grup de utilizatori
		/// </summary>
		/// <param name="numePagina">Numele paginii</param>
		/// <param name="descrierePagina">Descrierea paginii</param>
		/// <returns>Returneaza rezultatul adaugarii</returns>
		public int Insert(string numePagina, string descrierePagina)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@NumePagina", SqlDbType.NVarChar, 50),
					new SqlParameter("@DescrierePagina", SqlDbType.NVarChar, 100),
					new SqlParameter("@PaginaID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = numePagina;
			parameters[1].Value = descrierePagina;
			parameters[2].Direction = ParameterDirection.Output;

			RunProcedure("InsertPaginaPpAplicatie", parameters, out numAffected);
			
			return (int)parameters[2].Value;
		}
		#endregion

		#region Update
		/// <summary>
		/// Procedura face update unei pagini
		/// </summary>
		/// <param name="paginaId">Id-ul paginii</param>
		/// <param name="numePagina">Numele paginii</param>
		/// <param name="descrierePagina">Descrierea paginii</param>
		public void Update(int paginaId, string numePagina, string descrierePagina)
		{		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@PaginaID", SqlDbType.Int, 4),
					new SqlParameter("@NumePagina", SqlDbType.NVarChar, 50),
					new SqlParameter("@DescrierePagina", SqlDbType.NVarChar, 100)
				};
			
			parameters[0].Value = paginaId;
			parameters[1].Value = numePagina;
			parameters[2].Value = descrierePagina;
			
			RunProcedure("UpdatePaginaPpAplicatie", parameters);
		}
		#endregion

		#region Delete
		/// <summary>
		/// Procedura sterge o pagina
		/// </summary>
		/// <param name="paginaId">Id-ul paginii</param>
		public void Delete(int paginaId)
		{		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@PaginaID", SqlDbType.Int, 4)
				};
			parameters[0].Value = paginaId;
			RunProcedure("DeletePaginaPpAplicatie", parameters);
		}
		#endregion
	}
}
