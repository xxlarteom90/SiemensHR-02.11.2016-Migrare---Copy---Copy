/*
 *	Autor:     Cristina Muntean
 *	Data:      22.03.2005
 *  Descriere: sunt apelate procedurile stocate cu ajutorul carora este efectuat calculul salariilor
 */

using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Data
{
	public class ProcessDetails
	{	
		//Id-ul lunii
		public int LunaID;
		//Id-ul angajatorului
		public int AngajatorID;	
	}

	/// <summary>
	/// Clasa contine metode pentru calculul salarial.
	/// </summary>
	public class Process: Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="connectionString"> String-ul de conectare la baza de date.</param>
		public Process(string connectionString):	base (connectionString)
		{}
		#endregion

		#region ProcessSalariuAngajat
		/// <summary>
		/// Se calculeaza salariul unui angajat
		/// </summary>
		/// <param name="lunaId"> Id-ul lunii pentru care se doreste calcularea salariului.</param>
		/// <param name="angajatId"> Id-ul angajatului pentru care se doreste calcularea salariului.</param>
		/// <returns> Numarul de randuri afectate de efectuarea calculului salarial.</returns>
		public int ProcessSalariuAngajat(int lunaId, int angajatId)
		{
			int numAffected;
		
			//este declarat sirul de parametrii
			SqlParameter[] parameters = 
				{
					
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),										
				};
			
			//sunt setati parametrii
			parameters[0].Value = lunaId;
			parameters[1].Value = angajatId;
						
			//este rulata procedura stocata
			RunProcedure("spCalculDateSalariuAngajat", parameters, out numAffected);
			return numAffected;
		}
		#endregion
		
		#region CalculSalariiAngajati
		/// <summary>
		/// Este efectuat calculul salarial pentru toti angajatii unui angajator.
		/// </summary>
		/// <param name="lunaId"> Id-ul lunii pentru care se doreste efectuarea caculului salarial.</param>
		/// <param name="angajatorId"> Id-ul angajatorului pentru care se doreste efectuarea calculului salarial.</param>
		/// <returns> Numarul de randuri afectate de efectuarea calculului salarial.</returns>
		public int CalculSalariiAngajati( int lunaId, int angajatorId)
		{
			int numAffected;
		
			//este declarat sirul de parametrii
			SqlParameter[] parameters = 
				{
					
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4),										
			};
			
			//sunt setati parametrii
			parameters[0].Value = lunaId;
			parameters[1].Value = angajatorId;
						
			//este rulata procedura stocata
			RunProcedure("spCalculSalariiAngajati", parameters, out numAffected);		
			return numAffected;
		}
		#endregion

		#region DeleteSalariuLuna
		/// <summary>
		/// Este sters salariul unui anumit angajat pe o anumita luna.
		/// </summary>
		/// <param name="lunaId"> Id-ul lunii pentru care se doreste stergerea datelor legate de salarizare.</param>
		/// <param name="angajatId"> Id-ul angajatului pentru care se doreste stergerea datelor legate de salarizare.</param>
		/// <returns> Numarul de randuri afectate de efectuarea operatiei de stergere.</returns>
		public int DeleteSalariuLuna(int lunaId, int angajatId)
		{
			int numAffected;
		
			//este declarat sirul de parametrii
			SqlParameter[] parameters = 
				{
					
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4)								
			};
			
			//sunt setati parametrii
			parameters[0].Value = lunaId;
			parameters[1].Value = angajatId;
						
			//este rulata procedura stocata
			RunProcedure("spDeleteSalariuLunaAngajat", parameters, out numAffected);
			return numAffected;
		}
		#endregion

		#region DeleteSalariuLuna
		/// <summary>
		/// Sunt sterse toate datele aferente salarizarii dintr-o luna.
		/// </summary>
		/// <param name="lunaId"> Id-ul lunii pentru care se doreste stergerea tuturor datelor aferente salarizarii.</param>
		/// <param name="angajatorId"> Id-ul angajatorului pentru care se dorste stergerea datelor aferente salarizarii.</param>
		/// <returns> Numarul de randuri afectate de efectuarea operatiei.</returns>
		public int DeleteSalarii(int lunaId, int angajatorId)
		{
			int numAffected;
		
			//este declarat sirul de parametrii
			SqlParameter[] parameters = 
				{
					
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4)								
				};
			
			//sunt setati parametrii
			parameters[0].Value = lunaId;
			parameters[1].Value = angajatorId;
						
			//este rulata procedura stocata
			RunProcedure("spDeleteSalariiLunaAngajator", parameters, out numAffected);
			return numAffected;
		}
		#endregion
	}
}
