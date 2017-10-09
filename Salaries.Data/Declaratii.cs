/*
 * Autor: Cristina Raluca Muntean 
 * Data:  24.07.2006 
 */
using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Data
{
	/// <summary>
	/// Clasa permite obtinerea datelor din baza de date aferente declaratiilor.
	/// </summary>
	public class Declaratii: Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> String-ul de conectare la baza de date.</param>
		public Declaratii(string connectionString): base (connectionString)
		{ }
		#endregion

		#region GetDateDeclaratieCASa11
		/// <summary>
		/// Sunt obtinute din baza de date toate datele necesare completarii
		/// declaratiei a11 pentru CAS.
		/// </summary>
		/// <param name="lunaId"> ID-ul lunii pentru care se doreste completarea declaratiei.</param>
		/// <param name="angajatorId"> ID-ul angajatorului pentru care se doreste conpletarea declaratiei.</param>
		/// <returns> Un DataSet cu toate datele necesare completarii declaratiiei a11 pentru CAS.</returns>
		public DataSet GetDateDeclaratieCASa11(int lunaId, int angajatorId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@lunaID", SqlDbType.Int, 4),
					new SqlParameter("@angajatorID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = lunaId;
			parameters[1].Value = angajatorId;

			return RunProcedure("spDeclaratieCASa11", parameters , "DeclaratiaA11");
		}
		#endregion

		#region GetDateDeclaratieCASa12
		/// <summary>
		/// Sunt obtinute din baza de date toate datele necesare completarii
		/// declaratiei a12 pentru CAS.
		/// </summary>
		/// <param name="lunaId"> ID-ul lunii pentru care se doreste completarea declaratiei.</param>
		/// <param name="angajatorId"> ID-ul angajatorului pentru care se doreste conpletarea declaratiei.</param>
		/// <param name="dataPlataSalariu"> Data platii drepturilor salariale.</param>
		/// <param name="nrFileAnexa11"> Numarul de file ale Anexei 11.</param>
		/// <returns> Un DataSet cu toate datele necesare completarii declaratiiei a11 pentru CAS.</returns>
		public DataSet GetDateDeclaratieCASa12(int lunaId, int angajatorId, DateTime dataPlataSalariu, int nrFileAnexa11)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@lunaID", SqlDbType.Int, 4),
					new SqlParameter("@angajatorID", SqlDbType.Int, 4),
					new SqlParameter("@dataPlataSalariu", SqlDbType.DateTime, 8),
					new SqlParameter("@nrFileAnexa11", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = lunaId;
			parameters[1].Value = angajatorId;
			parameters[2].Value = dataPlataSalariu;
			parameters[3].Value = nrFileAnexa11;

			return RunProcedure("spDeclaratieCASa12", parameters , "DeclaratiaA12");
		}
		#endregion

		#region GetDateDeclaratieSomajCap1
		/// <summary>
		/// Sunt obtinute din baza de date toate datele necesare completarii
		/// declaratiei cap1 pentru somaj.
		/// </summary>
		/// <param name="lunaId"> ID-ul lunii pentru care se doreste completarea declaratiei.</param>
		/// <param name="angajatorId"> ID-ul angajatorului pentru care se doreste conpletarea declaratiei.</param>
		/// <returns> Un DataSet cu toate datele necesare completarii declaratiiei cap1 pentru somaj.</returns>
		public DataSet GetDateDeclaratieSomajCap1(int lunaId, int angajatorId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@lunaID", SqlDbType.Int, 4),
					new SqlParameter("@angajatorID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = lunaId;
			parameters[1].Value = angajatorId;

			return RunProcedure("spDeclaratieSomajCap1", parameters , "DeclaratiaCap1");
		}
		#endregion

		#region GetDateDeclaratieSomajCap2
		/// <summary>
		/// Sunt obtinute din baza de date toate datele necesare completarii
		/// declaratiei cap1 pentru somaj.
		/// </summary>
		/// <param name="lunaId"> ID-ul lunii pentru care se doreste completarea declaratiei.</param>
		/// <param name="angajatorId"> ID-ul angajatorului pentru care se doreste conpletarea declaratiei.</param>
		/// <returns> Un DataSet cu toate datele necesare completarii declaratiiei cap1 pentru somaj.</returns>
		public DataSet GetDateDeclaratieSomajCap2(int lunaId, int angajatorId)
		{
			// Lungu Andreea - 15.08.2008 - a  fost scos param @reprezentantLegalId 
			SqlParameter[] parameters = 
				{
					new SqlParameter("@lunaID", SqlDbType.Int, 4),
					new SqlParameter("@angajatorID", SqlDbType.Int, 4)					
				};
			
			parameters[0].Value = lunaId;
			parameters[1].Value = angajatorId;
	
			return RunProcedure("spDeclaratieSomajCap2", parameters , "DeclaratiaCap2");
		}
		#endregion

		#region FiseFiscale
		public DataSet GetDateFiseFiscale1(int angajatorID, int an, int casaDeAsigurariID)
		{
			SqlParameter[] parameters = {
											new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
											new SqlParameter("@An", SqlDbType.Int, 4),
											new SqlParameter("@CasaDeAsigurariID", SqlDbType.Int, 4),
			};
			parameters[0].Value = angajatorID;
			parameters[1].Value = an;
			parameters[2].Value = casaDeAsigurariID;
			return RunProcedure("dbo.Raport_FisaFiscala", parameters , "dbo.Raport_FisaFiscala");

		}
		#endregion
	}
}
