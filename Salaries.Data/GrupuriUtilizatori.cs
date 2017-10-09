/* 
 * Autor: Cristina Raluca Muntean
 * Data:  22.08.2005
 */
using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Data
{
	/// <summary>
	/// Toate datele aferente unui grup de utilizatori.
	/// </summary>
	public struct GrupUtilizatoriDetails
	{
		// ID-ul grupului de utilizatori.
		public int GrupID;
		// Numele grupului de utilizatori.
		public string NumeGrup; 
		// Descrierea grupului de utilizatori.
		public string DescriereGrup;
	}

	/// <summary>
	/// Administrarea grupurilor de utilizatori ai aplicatiei.
	/// </summary>
	public class GrupuriUtilizatori: Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> String-ul de conexiune la baza de date.</param>
		public GrupuriUtilizatori(string connectionString): base (connectionString)
		{	
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Returneaza toate detaliile despre un grup de utilizatori.
		/// </summary>
		/// <param name="grupID"> ID-ul grupului de utilizatori.</param>
		/// <returns> Un struct ce cuprinde toate detaliile destre grupul de utilizatori.</returns>
		public GrupUtilizatoriDetails GetDetalii(int grupID)
		{
			SqlParameter[] parameters = {new SqlParameter("@GrupID", SqlDbType.Int, 4)};
			
			parameters[0].Value = grupID;

			using(DataSet detaliiGrup = RunProcedure("GetGrupUtilizatoriInfo", parameters , "InfoGrup"))
			{
				GrupUtilizatoriDetails  grup = new GrupUtilizatoriDetails();
				if (detaliiGrup.Tables["InfoGrup"].Rows.Count > 0)
				{
					DataRow rowDetalii = detaliiGrup.Tables["InfoGrup"].Rows[0];
					grup.GrupID= (int)rowDetalii["GrupID"];
					grup.NumeGrup = rowDetalii["NumeGrup"].ToString();
					grup.DescriereGrup = rowDetalii["DescriereGrup"].ToString();
				}
				else
					grup.GrupID = -1;

				return grup;
			}
		}
		#endregion
		
		#region GetGrupuriUtilizatori
		/// <summary>
		/// Returneaza detaliile despre toate grupurile de utilizatori
		/// </summary>
		/// <returns> Un DataSet cu datele despre toate grupurile de utilizatori.</returns>
		public DataSet GetGrupuriUtilizatori()
		{
			SqlParameter[] parameters = {};

			return RunProcedure("GetGrupuriUtilizatori", parameters , "InfoGrup");
		}
		#endregion

		#region Insert
		/// <summary>
		/// Insereaza un grup de utilizatori.
		/// </summary>
		/// <param name="numeGrup"> Numele grupului de utilizatori.</param>
		/// <param name="descriereGrup"> Descrierea grupului de utilizatori.</param>
		/// <returns> ID-ul grupului de utilizatori inserat.</returns>
		public int Insert(string numeGrup, string descriereGrup)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@NumeGrup", SqlDbType.NVarChar, 50),
					new SqlParameter("@DescriereGrup", SqlDbType.NVarChar, 100),
					new SqlParameter("@GrupID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = numeGrup;
			parameters[1].Value = descriereGrup;
			parameters[2].Direction = ParameterDirection.Output;

			RunProcedure("InsertGrupUtilizatori", parameters, out numAffected);
			
			return (int)parameters[2].Value;
		}
		#endregion

		#region Update
		/// <summary>
		/// Este realizat update-ul unui grup de utilizatori.
		/// </summary>
		/// <param name="grupID"> ID-ul grupului de utilizatori.</param>
		/// <param name="numeGrup"> Numele grupului de utilizatori.</param>
		/// <param name="descriereGrup"> Descrierea grupului de utilizatori.</param>
		public void Update(int grupID, string numeGrup, string descriereGrup)
		{
					
			SqlParameter[] parameters = 
				{
					new SqlParameter("@GrupID", SqlDbType.Int, 4),
					new SqlParameter("@NumeGrup", SqlDbType.NVarChar, 50),
					new SqlParameter("@DescriereGrup", SqlDbType.NVarChar, 100)
				};
			
			parameters[0].Value = grupID;
			parameters[1].Value = numeGrup;
			parameters[2].Value = descriereGrup;
			
			RunProcedure("UpdateGrupUtilizatori", parameters);
		}
		#endregion

		#region Delete
		/// <summary>
		/// Sterge un grup de utilizatori.
		/// </summary>
		/// <param name="grupID"> ID-ul gupului de utilizatori care se doreste a fi sters.</param>
		public void Delete(int grupID)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@GrupID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = grupID;
			
			RunProcedure("DeleteGrupUtilizatori", parameters);
		}
		#endregion
	}
}
