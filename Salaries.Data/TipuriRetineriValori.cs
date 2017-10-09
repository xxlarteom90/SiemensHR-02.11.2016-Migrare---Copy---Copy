using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for TipuriRetineriValori.
	/// </summary>
	public class TipuriRetineriValori : Salaries.Data.DbObject
	{
		#region Constructori
		public TipuriRetineriValori(string connectionString ) : base( connectionString )
		{
		}
		#endregion

		#region InsertRetineriValori
		/// <summary>
		/// Metoda este folosita pentru a adauga valorile retinerilor pentru un angajat
		/// </summary>
		/// <param name="lunaId">Luna pentru care se adauga retinerile</param>
		/// <param name="angajatId">Angajatul pentru care se adauga retinerile</param>
		public void InsertRetineriValori(int lunaId, long angajatId)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4)
					, new SqlParameter("@AngajatID", SqlDbType.BigInt, 8)
				};
			parameters[0].Value = lunaId;
			parameters[1].Value = angajatId;
			
			RunProcedure("spInsertRetineriValori", parameters);
		}
		#endregion

		#region UpdateRetineriValori
		/// <summary>
		/// Metoda este folosita pentru a actualiza valorile etichetelor pentru un angajat intr-o luna
		/// </summary>
		/// <param name="lunaId">Luna pentru care se actualizeaza etichetele</param>
		/// <param name="angajatId">Angajatul pentru care se actualizeaza etichetele</param>
		/// <param name="retinere1">Valorile retinerilor</param>
		/// <param name="retinere2"></param>
		/// <param name="retinere3"></param>
		/// <param name="retinere4"></param>
		/// <param name="retinere5"></param>
		/// <param name="retinere6"></param>
		/// <param name="retinere7"></param>
		public void UpdateRetineriValori(int lunaId, long angajatId, decimal retinere1, decimal retinere2, decimal retinere3, decimal retinere4, decimal retinere5, decimal retinere6, decimal retinere7)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4)
					, new SqlParameter("@AngajatID", SqlDbType.BigInt, 8)
					, new SqlParameter("@Retinere1", SqlDbType.Decimal, 8)
					, new SqlParameter("@Retinere2", SqlDbType.Decimal, 8)
					, new SqlParameter("@Retinere3", SqlDbType.Decimal, 8)
					, new SqlParameter("@Retinere4", SqlDbType.Decimal, 8)
					, new SqlParameter("@Retinere5", SqlDbType.Decimal, 8)
					, new SqlParameter("@Retinere6", SqlDbType.Decimal, 8)
					, new SqlParameter("@Retinere7", SqlDbType.Decimal, 8)
				};
			parameters[0].Value = lunaId;
			parameters[1].Value = angajatId;
			parameters[2].Value = retinere1;
			parameters[3].Value = retinere2;
			parameters[4].Value = retinere3;
			parameters[5].Value = retinere4;
			parameters[6].Value = retinere5;
			parameters[7].Value = retinere6;
			parameters[8].Value = retinere7;
			
			RunProcedure("spUpdateRetineriValori", parameters);
		}
		#endregion

		#region UpdateValoareRetinere
		/// <summary>
		/// Metoda este folosita pentru a actualiza valorea unei retineri pentru un angajat intr-o luna
		/// </summary>
		/// <param name="lunaId">Luna pentru care se actualizeaza etichetele</param>
		/// <param name="angajatId">Angajatul pentru care se actualizeaza etichetele</param>
		/// <param name="numeRetinere"></param>
		/// <param name="retinereValoare"></param>
		public void UpdateValoareRetinere(int lunaId, long angajatId, string numeRetinere, decimal valoareRetinere)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4)
					, new SqlParameter("@AngajatID", SqlDbType.BigInt, 8)
					, new SqlParameter("@NumeRetinere", SqlDbType.NVarChar, 50)
					, new SqlParameter("@ValoareRetinere", SqlDbType.Decimal, 8)
				};
			parameters[0].Value = lunaId;
			parameters[1].Value = angajatId;
			parameters[2].Value = numeRetinere;
			parameters[3].Value = valoareRetinere;
			
			RunProcedure("spUpdateValoareRetinere", parameters);
		}
		#endregion

		#region GetRetineriValori
		/// <summary>
		/// Metoda returneaza tipurile de retineri impreuna cu valorile acestora pentru un angajat intr-o anumita luna
		/// </summary>
		/// <param name="LunaId">Luna pentru care se obtin retineri</param>
		/// <param name="AngajatId">Angajatul pentru care se obtine retinerile</param>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetRetineriValori(int lunaId, long angajatId)
		{
			SqlParameter[] parameters = { new SqlParameter("@LunaID", SqlDbType.Int, 4),
										  new SqlParameter("@AngajatID", SqlDbType.BigInt, 8)};
			parameters[0].Value = lunaId;
			parameters[1].Value = angajatId;
			return RunProcedure("spGetRetineriValori", parameters, "RetineriValori");
		}
		#endregion
	}
}
