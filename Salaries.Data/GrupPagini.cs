using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Data
{
	public struct GrupPaginaDetails
	{
		public int GrupPaginaID;
		public int GrupID;
		public int PaginaID;
	}

	/// <summary>
	/// Summary description for GrupPagini.
	/// </summary>
	public class GrupPagini: Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="newConnectionString">String-ul de conexiune la baza de date</param>
		public GrupPagini(string newConnectionString): base (newConnectionString){}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Returneaza toate detaliile despre o inregistrare din tabela GrupPagini
		/// </summary>
		/// <param name="grupPaginaID">Id-ul inregistrarii</param>
		/// <returns>Returneaza un obiect care contine datele inregistrarii</returns>
		public GrupPaginaDetails GetDetalii(int grupPaginaID)
		{
			SqlParameter[] parameters = {new SqlParameter("@GrupPaginaID", SqlDbType.Int, 4)};
			
			parameters[0].Value = grupPaginaID;

			using(DataSet detaliiGrup = RunProcedure("GetGrupPaginiInfo", parameters , "InfoGrupPagina"))
			{
				GrupPaginaDetails  grupPagina = new GrupPaginaDetails();
				if (detaliiGrup.Tables["InfoGrupPagina"].Rows.Count > 0)
				{
					DataRow rowDetalii = detaliiGrup.Tables["InfoGrupPagina"].Rows[0];
					grupPagina.GrupPaginaID = (int)rowDetalii["GrupPaginaID"];
					grupPagina.GrupID= (int)rowDetalii["GrupID"];
					grupPagina.PaginaID = (int)rowDetalii["PaginaID"];
				}
				else
					grupPagina.GrupPaginaID = -1;

				return grupPagina;
			}
		}
		#endregion
		
		#region GetPaginiGrup
		/// <summary>
		/// Returneaza toate paginile la care acces un grup
		/// </summary>
		/// <param name="grupID">Id-ul grupului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetPaginiGrup(int grupID)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@GrupID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = grupID;

			return RunProcedure("GetPaginiGrup", parameters , "InfoGrupPagini");
		}
		#endregion

		#region Insert
		/// <summary>
		/// Insereaza o inregistrare in tabela GrupPagini
		/// </summary>
		/// <param name="grupID">Id-ul grupului</param>
		/// <param name="paginaID">Id-ul paginii</param>
		/// <returns>Returneaza rezultatul adaugarii</returns>
		public int Insert(int grupID, int paginaID)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@GrupID", SqlDbType.Int, 4),
					new SqlParameter("@PaginaID", SqlDbType.Int, 4),
					new SqlParameter("@GrupPaginaID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = grupID;
			parameters[1].Value = paginaID;
			parameters[2].Direction = ParameterDirection.Output;

			RunProcedure("InsertGrupPagini", parameters, out numAffected);
			
			return (int)parameters[2].Value;
		}
		#endregion

		#region Update
		/// <summary>
		/// Face update unei inregistrari
		/// </summary>
		/// <param name="grupPaginaID">Id-ul inregistrarii</param>
		/// <param name="grupID">Id-ul grupului</param>
		/// <param name="paginaID">Id-ul paginii</param>
		public void Update(int grupPaginaID, int grupID, int paginaID)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@GrupPaginaID", SqlDbType.Int, 4),
					new SqlParameter("@GrupID", SqlDbType.Int, 4),
					new SqlParameter("@PaginaID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = grupPaginaID;
			parameters[1].Value = grupID;
			parameters[2].Value = paginaID;
			
			RunProcedure("UpdateGrupPagini", parameters);
		}
		#endregion

		#region Delete
		/// <summary>
		/// Sterge o inregistrare
		/// </summary>
		/// <param name="grupPaginaID">Id-ul grupului care se sterge</param>
		public void Delete(int grupPaginaID)
		{
				
			SqlParameter[] parameters = 
				{
					new SqlParameter("@GrupPaginaID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = grupPaginaID;
			
			RunProcedure("DeleteGrupPagini", parameters);
		}
		#endregion
	}
}
