using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for Checkupuri.
	/// </summary>
	public class Checkupuri : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public Checkupuri(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadCheckupuriAngajat
		/// <summary>
		/// Procedura selecteaza checkup-urile unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadCheckupuriAngajat(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = angajatId;
			return RunProcedure("GetCheckupuriAngajat", parameters, "GetCheckupuriAngajat");
		}
		#endregion

		#region InsertCheckup
		/// <summary>
		/// Procedura adauga un checkup
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="necesarInstruire">Necesarul de instruire</param>
		/// <param name="dataUrmatorului">Data urmatorului</param>
		/// <param name="responsabilId">Id-ul responsabilului</param>
		/// <param name="dataEfectuarii">Data efectuarii checkup-ului</param>
		/// <param name="checkupFile">Fisierul de checkup</param>
		/// <returns>Returneaza id-ul checkup-ului nou adaugat</returns>
		public int InsertCheckup(long angajatId, string necesarInstruire, DateTime dataUrmatorului, long responsabilId, DateTime dataEfectuarii, string checkupFile)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@CheckupID", SqlDbType.BigInt, 10),
					new SqlParameter("@NecesarInstruire", SqlDbType.NVarChar, 255),
					new SqlParameter("@DataUrmatorului", SqlDbType.DateTime, 8),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@ResponsabilID", SqlDbType.BigInt, 10),
					new SqlParameter("@DataEfectuarii", SqlDbType.DateTime, 8),
					new SqlParameter("@CheckupFile", SqlDbType.NVarChar, 255)
				};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = necesarInstruire;
			parameters[3].Value = dataUrmatorului;
			parameters[4].Value = angajatId;
			if (responsabilId != -1)
			{
				parameters[5].Value = responsabilId;
			}
			else
			{
				parameters[5].Value = System.DBNull.Value;
			}
			if (dataEfectuarii != DateTime.MinValue)
			{
				parameters[6].Value = dataEfectuarii;
			}
			else
			{
				parameters[6].Value = System.DBNull.Value;
			}
			if ((checkupFile!=null) && (checkupFile.Length>0))
			{
				parameters[7].Value = checkupFile;
			}
			else
			{
				parameters[7].Value = System.DBNull.Value;
			}
			DataSet ds = RunProcedure("InsertUpdateDeleteCheckup", parameters, "InsertUpdateDeleteCheckup");
			return int.Parse(ds.Tables[0].Rows[0]["NewID"].ToString());
		}
		#endregion

		#region UpdateCheckup
		/// <summary>
		/// Procedura actualizeaza un checkup
		/// </summary>
		/// <param name="checkupId">Id-ul checkup-ului</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="necesarInstruire">Necesarul de instruire</param>
		/// <param name="dataUrmatorului">Data urmatorului</param>
		/// <param name="responsabilId">Id-ul responsabilului</param>
		/// <param name="dataEfectuarii">Data efectuarii checkup-ului</param>
		/// <param name="checkupFile">Fisierul de checkup</param>
		public void UpdateCheckup(int checkupId, long angajatId, string necesarInstruire, DateTime dataUrmatorului, long responsabilId, DateTime dataEfectuarii, string checkupFile)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@CheckupID", SqlDbType.BigInt, 10),
					new SqlParameter("@NecesarInstruire", SqlDbType.NVarChar, 255),
					new SqlParameter("@DataUrmatorului", SqlDbType.DateTime, 8),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@ResponsabilID", SqlDbType.BigInt, 10),
					new SqlParameter("@DataEfectuarii", SqlDbType.DateTime, 8),
					new SqlParameter("@CheckupFile", SqlDbType.NVarChar, 255)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = checkupId;
			parameters[2].Value = necesarInstruire;
			parameters[3].Value = dataUrmatorului;
			parameters[4].Value = angajatId;
			if (responsabilId != -1)
			{
				parameters[5].Value = responsabilId;
			}
			else
			{
				parameters[5].Value = System.DBNull.Value;
			}
			if (dataEfectuarii != DateTime.MinValue)
			{
				parameters[6].Value = dataEfectuarii;
			}
			else
			{
				parameters[6].Value = System.DBNull.Value;
			}
			if ((checkupFile!=null) && (checkupFile.Length>0))
			{
				parameters[7].Value = checkupFile;
			}
			else
			{
				parameters[7].Value = System.DBNull.Value;
			}
			RunProcedure("InsertUpdateDeleteCheckup", parameters);
		}
		#endregion

		#region DeleteCheckup
		/// <summary>
		/// Procedura sterge un checkup
		/// </summary>
		/// <param name="checkupId">Id-ul checkup-ului care se sterge</param>
		public void DeleteCheckup(int checkupId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@CheckupID", SqlDbType.BigInt, 10),
					new SqlParameter("@NecesarInstruire", SqlDbType.NVarChar, 255),
					new SqlParameter("@DataUrmatorului", SqlDbType.DateTime, 8),
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10),
					new SqlParameter("@ResponsabilID", SqlDbType.BigInt, 10),
					new SqlParameter("@DataEfectuarii", SqlDbType.DateTime, 8),
					new SqlParameter("@CheckupFile", SqlDbType.NVarChar, 255)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = checkupId;
			parameters[2].Value = "";
			parameters[3].Value = DateTime.Now;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = DateTime.Now;
			parameters[7].Value = System.DBNull.Value;

			RunProcedure("InsertUpdateDeleteCheckup", parameters);
		}
		#endregion
	}
}
