using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for EvalurariPsihologice.
	/// </summary>
	public class EvalurariPsihologice : Salaries.Data.DbObject
	{
		#region Constructor

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public EvalurariPsihologice(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadEvaluariPsihologiceAngajat
		/// <summary>
		/// Procedura selecteaza toate evaluarile psihologice ale unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine evaluarile</returns>
		public DataSet LoadEvaluariPsihologiceAngajat(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = angajatId;
			return RunProcedure("GetEvaluariPsihologiceAngajat", parameters, "GetEvaluariPsihologiceAngajat");
		}
		#endregion

		#region InsertEvaloarePsihologica
		/// <summary>
		/// Procedura adauga o evaluare psihologica
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="tipRaportId">Id-ul tipului de raport al evaluarii</param>
		/// <param name="data">Data evaluarii</param>
		/// <param name="evalPsihologicaFile">Fisierul pentru evaluare</param>
		/// <returns>Returneaza id-ul evaluarii adaugate</returns>
		public int InsertEvaloarePsihologica(long angajatId, int tipRaportId, DateTime data, string evalPsihologicaFile)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@EvalPsihologicaID", SqlDbType.BigInt, 10),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@TipRaportID", SqlDbType.Int, 4),
					new SqlParameter("@Raport", SqlDbType.NVarChar, 255)
				};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = angajatId;
			parameters[3].Value = data.ToShortDateString();
			parameters[4].Value = tipRaportId;
			if ((evalPsihologicaFile!=null) && (evalPsihologicaFile.Length>0))
			{
				parameters[5].Value = evalPsihologicaFile;
			}
			else
			{
				parameters[5].Value = System.DBNull.Value;
			}
			DataSet ds = RunProcedure("InsertUpdateDeleteEvaluarePsihologica", parameters, "InsertUpdateDeleteEvaluarePsihologica");
			return int.Parse(ds.Tables[0].Rows[0]["NewID"].ToString());
		}
		#endregion

		#region UpdateEvaloarePsihologica
		/// <summary>
		/// Procedura actualizeaza o evaluare psihologica
		/// </summary>
		/// <param name="evaluarePsihologicaId">Id-ul evaluarii</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="tipRaportId">Id-ul tipului de raport al evaluarii</param>
		/// <param name="data">Data evaluarii</param>
		/// <param name="evalPsihologicaFile">Fisierul pentru evaluare</param>
		public void UpdateEvaloarePsihologica(int evaluarePsihologicaId, long angajatId, int tipRaportId, DateTime data, string evalPsihologicaFile)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@EvalPsihologicaID", SqlDbType.BigInt, 10),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@TipRaportID", SqlDbType.Int, 4),
					new SqlParameter("@Raport", SqlDbType.NVarChar, 255)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = evaluarePsihologicaId;
			parameters[2].Value = angajatId;
			parameters[3].Value = data.ToShortDateString();
			parameters[4].Value = tipRaportId;
			if ((evalPsihologicaFile!=null) && (evalPsihologicaFile.Length>0))
			{
				parameters[5].Value = evalPsihologicaFile;
			}
			else
			{
				parameters[5].Value = System.DBNull.Value;
			}
			RunProcedure("InsertUpdateDeleteEvaluarePsihologica", parameters);
		}
		#endregion

		#region DeleteEvaloarePsihologica
		/// <summary>
		/// Procedura sterge o evaluare psihologica
		/// </summary>
		/// <param name="evaluarePsihologicaId">Id-ul evaluarii</param>
		public void DeleteEvaloarePsihologica(int evaluarePsihologicaId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@EvalPsihologicaID", SqlDbType.BigInt, 10),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@TipRaportID", SqlDbType.Int, 4),
					new SqlParameter("@Raport", SqlDbType.NVarChar, 255)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = evaluarePsihologicaId;
			parameters[2].Value = 0;
			parameters[3].Value = DateTime.Now;
			parameters[4].Value = 0;
			parameters[5].Value = System.DBNull.Value;

			RunProcedure("InsertUpdateDeleteEvaluarePsihologica", parameters);
		}
		#endregion
	}
}
