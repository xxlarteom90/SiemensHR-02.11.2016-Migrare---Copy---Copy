/*
 * Autor: Cristina Raluca Muntean
 * Data:  6.03.2005 
 */
using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{

	/// <summary>
	/// Se realizeaza operatiile necesare pentru administrarea conturilor unui angajatorului.
	/// </summary>
	public class ConturiAngajator : Salaries.Data.DbObject
	{
		#region Constructor

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public ConturiAngajator(string connectionString): base (connectionString)
		{
		}
		#endregion

		#region Insert
		/// <summary>
		/// Insereaza in baza de date un cont bancar al unui angajator.  
		/// </summary>
		/// <param name="angajatorIc"> ID-ul angajatorului</param>
		/// <param name="bancaIc"> ID-ul bancii de care apartine contul.</param>
		/// <param name="numarContVechi"> Numarul contului in forma veche.</param>
		/// <param name="numarContIBAN"> Numarul contului in forma IBAN.</param>
		/// <param name="moneda"> Moneda in care este facut contul: LEI sau EURO.</param>
		/// <param name="activ"> true - activ, false - inactiv. 
		/// Pot fi active in acelasi timp doar conturi in monede diferite.</param>
		/// <returns> Returneaza 0 in cazul in care inserarea s-a facut cu succes, 
		/// un intreg diferit de 0, altfel. </returns>
		public int Insert( int angajatorIc, int bancaIc, string numarContVechi, string numarContIBAN, string moneda, bool activ )
		{
			// Numarul randurilor afectate de operatia pe baza de date.
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@ContID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
					new SqlParameter("@BancaID", SqlDbType.Int, 4),
					new SqlParameter("@NumarContVechi", SqlDbType.NVarChar, 30),
					new SqlParameter("@NumarContIBAN", SqlDbType.NVarChar, 24),
					new SqlParameter("@Moneda", SqlDbType.NVarChar, 4),
					new SqlParameter("@Activ", SqlDbType.Bit, 1),
					new SqlParameter("@returnValue", SqlDbType.Int, 4)
				};
			
			// Tipul actiunii trebuie setat, 0 = adaugare. 
			parameters[0].Value = 0;
			// ID-ul contului.
			parameters[1].Value = 0;
			// ID-ul angajatorului
			parameters[2].Value = angajatorIc;
			// ID-ul bancii.
			parameters[3].Value = bancaIc;
			// Numarul contului in forma veche.
			parameters[4].Value = numarContVechi;
			// Numarul contului in forma IBAN.
			parameters[5].Value = numarContIBAN;
			// Moneda in care este deschis contul.
			parameters[6].Value = moneda;
			// Starea contului: activ - true, inactiv - false.
			parameters[7].Value = activ;
			// Parametrul de iesire.
			parameters[8].Direction = ParameterDirection.Output; 

			// Este rulata procedura stocata care face inserarea datelor in baza de date.
			RunProcedure("InsertUpdateDeleteContAngajator", parameters, out numAffected);
			
			return (int)parameters[8].Value;
		}
		#endregion

		#region Update
		/// <summary>
		/// Modifica un cont bancar al unui angajator.  
		/// </summary>
		/// <param name="angajatorId"> ID-ul angajatorului</param>
		/// <param name="bancaId"> ID-ul bancii de care apartine contul.</param>
		/// <param name="numarContVechi"> Numarul contului in forma veche.</param>
		/// <param name="numarContIBAN"> Numarul contului in forma IBAN.</param>
		/// <param name="moneda"> Moneda in care este facut contul: LEI sau EURO.</param>
		/// <param name="activ"> true - activ, false - inactiv. 
		/// Pot fi active in acelasi timp doar conturi in monede diferite.</param>
		/// <returns> Returneaza 0 in cazul in care modificarea s-a facut cu succes, 
		/// un intreg diferit de 0, altfel. </returns>
		public int Update( int contId, int angajatorId, int bancaId, string numarContVechi, string numarContIBAN, string moneda, bool activ )
		{
			// Numarul randurilor afectate de operatia pe baza de date.
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@ContID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
					new SqlParameter("@BancaID", SqlDbType.Int, 4),
					new SqlParameter("@NumarContVechi", SqlDbType.NVarChar, 30),
					new SqlParameter("@NumarContIBAN", SqlDbType.NVarChar, 24),
					new SqlParameter("@Moneda", SqlDbType.NVarChar, 4),
					new SqlParameter("@Activ", SqlDbType.Bit, 1),
					new SqlParameter("@returnValue", SqlDbType.Int, 4)
				};
			
			// Tipul actiunii trebuie setat, 1 = modificare. 
			parameters[0].Value = 1;
			// ID-ul contului.
			parameters[1].Value = contId;
			// ID-ul angajatorului
			parameters[2].Value = angajatorId;
			// ID-ul bancii.
			parameters[3].Value = bancaId;
			// Numarul contului in forma veche.
			parameters[4].Value = numarContVechi;
			// Numarul contului in forma IBAN.
			parameters[5].Value = numarContIBAN;
			// Moneda in care este deschis contul.
			parameters[6].Value = moneda;
			// Starea contului: activ - true, inactiv - false.
			parameters[7].Value = activ;
			// Parametrul de iesire.
			parameters[8].Direction = ParameterDirection.Output; 

			// Este rulata procedura stocata care face modificarea datelor din baza de date.
			RunProcedure("InsertUpdateDeleteContAngajator", parameters, out numAffected);
			
			return (int)parameters[8].Value;
		}
		#endregion

		#region Delete
		/// <summary>
		/// Sterge din baza de date un cont bancar al unui angajator.
		/// </summary>
		/// <param name="contId"> ID-ul contului care se doreste a fi sters.</param>
		/// <returns> Returneaza 0 in cazul in care stergerea s-a facut cu succes, 
		/// un intreg diferit de 0, altfel. </returns>
		public int Delete(int contId)
		{
			// Numarul randurilor afectate de operatia pe baza de date.
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@ContID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
					new SqlParameter("@BancaID", SqlDbType.Int, 4),
					new SqlParameter("@NumarContVechi", SqlDbType.NVarChar, 30),
					new SqlParameter("@NumarContIBAN", SqlDbType.NVarChar, 24),
					new SqlParameter("@Moneda", SqlDbType.NVarChar, 4),
					new SqlParameter("@Activ", SqlDbType.Bit, 1),
					new SqlParameter("@returnValue", SqlDbType.Int, 4)
				};
			
			// Tipul actiunii trebuie setat, 2 = stergere. 
			parameters[0].Value = 2;
			// ID-ul contului.
			parameters[1].Value = contId;
			// ID-ul angajatorului
			parameters[2].Value = 0;
			// ID-ul bancii.
			parameters[3].Value = 0;
			// Numarul contului in forma veche.
			parameters[4].Value = string.Empty;
			// Numarul contului in forma IBAN.
			parameters[5].Value = string.Empty;
			// Moneda in care este deschis contul.
			parameters[6].Value = string.Empty;
			// Starea contului: activ - true, inactiv - false.
			parameters[7].Value = false;
			// Parametrul de iesire.
			parameters[8].Direction = ParameterDirection.Output; 

			// Este rulata procedura stocata care face modificarea datelor din baza de date.
			RunProcedure("InsertUpdateDeleteContAngajator", parameters, out numAffected);
			
			return (int)parameters[8].Value;
		}
		#endregion

		#region GetConturiBancareAngajator
		/// <summary>
		/// Returneaza toate conturile bancare ale unui angajator.
		/// </summary>
		/// <param name="angajatorID"> ID-ul angajatorului.</param>
		/// <returns> Un DataSet cu toate datele despre conturile angajatorului.</returns>
		public DataSet GetConturiBancareAngajator(int angajatorId)
		{
			DataSet dsConturiAngajator = new DataSet();

			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
				};
			
			// Id-ul angajatorului. 
			parameters[0].Value = angajatorId;
			
			// Este rulata procedura stocata care face modificarea datelor din baza de date.
			dsConturiAngajator = RunProcedure("GetConturiAngajator", parameters, "ConturiAngajator");
			
			return dsConturiAngajator;
		}
		#endregion

		#region GetConturiBancareActiveAngajator
		/// <summary>
		/// Returneaza toate conturile bancare active ale unui angajator.
		/// </summary>
		/// <param name="angajatorId"> ID-ul angajatorului.</param>
		/// <returns> Un DataSet cu toate datele despre conturile active ale angajatorului.</returns>
		public DataSet GetConturiBancareActiveAngajator(int angajatorId)
		{
			DataSet dsConturiAngajator = new DataSet();

			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
				};
			
			// Id-ul angajatorului. 
			parameters[0].Value = angajatorId;
			
			// Este rulata procedura stocata care face modificarea datelor din baza de date.
			dsConturiAngajator = RunProcedure("GetConturiActiveAngajator", parameters, "ConturiAngajator");
			
			return dsConturiAngajator;
		}
		#endregion

		#region DeleteConturiAngajator
		/// <summary>
		/// Sunt sterse toate conturile bancare ale angajatorului cu ID-ul trimis ca parametru.
		/// </summary>
		/// <param name="angajatorId"> ID-ul angajatorului.</param>
		/// <returns> Returneaza 0 in cazul in care stergerea s-a facut cu succes, 
		/// un intreg diferit de 0, altfel. </returns>
		public int DeleteConturiAngajator(int angajatorId)
		{
			// Numarul randurilor afectate de operatia pe baza de date.
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
					new SqlParameter("@returnValue", SqlDbType.Int, 4)
				};
			
			// ID-ul angajatorului. 
			parameters[0].Value = angajatorId;
			// Parametrul de iesire.
			parameters[1].Direction = ParameterDirection.Output; 

			// Este rulata procedura stocata care face modificarea datelor din baza de date.
			RunProcedure("DeleteAllConturiAngajator", parameters, out numAffected);
			
			return (int)parameters[1].Value;
		}
		#endregion

		#region GetMonedaConturiAngajati
		/// <summary>
		/// Returneaza tipurile de monede in care au angajatii deschise conturi.
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului pentru care se selecteaza tipurile de monede</param>
		/// <returns> Un DataSet cu lista monede.</returns>
		public DataSet GetMonedaConturiAngajati(int angajatorId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
				};
			parameters[0].Value = angajatorId;
			return RunProcedure("GetMonedaConturiAngajati", parameters, "GetMonedaConturiAngajati");
		}
		#endregion
	}
}
