/*
 * 
 * Autor:	Manuel Neagoe
 * Data:	28.01.2013
 * Descriere:	Clasa se ocupa cu gestiunea unui tip de asigurat
 */

using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Data
{
	/// <summary>
	/// Clasa se ocupa cu oreratiile executate pe tabela cu tip de asigurat
	/// </summary>
	public class TipAsigurat : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor care primeste ca si parametru stringul de conexiune la baza de date
		/// Este mostenit constructorul din clasa de baza
		/// </summary>
		/// <param name="connectionString"> String-ul de conectare la baza de date.</param>
		public TipAsigurat(string connectionString) : base (connectionString)
		{
		}
		#endregion

		#region Insert
		/// <summary>
		/// Procedura realizeaza adaugarea in baza de date a unui tip de asigurat
		/// </summary>
		/// <param name="cod"> parametru care contine codul pentru casa de asigurari </param>
		/// <param name="denumire"> parametru care contine denumirea pentru casa de asigurari </param>
		/// <param name="descriere"> parametru care contine descrierea pentru casa de asigurari </param>
		/// <returns>procedura returneaza numarul de randuri afectate de adaugare</returns>
		public int Insert(int tipAsiguratID, string descriere)
		{
			//int numAffected;
			SqlParameter[] parameters = 
				{
					Salaries.Data.DbObject.AddInputParameter("@TipAsiguratID",SqlDbType.Int,4,tipAsiguratID),
					Salaries.Data.DbObject.AddInputParameter("@Descriere", SqlDbType.NVarChar, 250, descriere),
					Salaries.Data.DbObject.AddInputParameter("@tip_actiune", SqlDbType.Int, 4,0), //insert
					new SqlParameter( "@rc", SqlDbType.Int, 4 )
				};
			// Descriere: Trebuie setata directia parametrului @rc la return, deoarece altfel el este considerat de output si
			//			  SQL Server va da o eroare deoarece in procedura stocata @rc nu este parametru de output, ci de return
			parameters[ 3 ].Direction = ParameterDirection.ReturnValue;

			RunProcedure("InsertUpdateDeleteTipAsigurat", parameters);
			return (int)parameters[3].Value;
		}
		#endregion
		
		#region Update
		/// <summary>
		/// Procedura realizeaza actualizarea unui tip de asigurat
		/// </summary>
		/// <param name="TipAsiguratId">parametrul contine id-ul casei de asigurari care va fi modificata</param>
		/// <param name="cod">parametrul contine noua valoare pentru cod a casei de asigurari</param>
		/// <param name="denumire">parametrul contine noua valoare pentru denumire a casei de asigurari</param>
		/// <param name="descriere">parametrul contine noua valoare pentru descriere a casei de asigurari</param>
		/// <param name="codificare">parametrul contine noua valoare pentru codificare a casei de asigurari</param>
		/// <returns></returns>
		public void Update(int tipAsiguratId, string descriere)
		{
			SqlParameter[] parameters = 
				{
					Salaries.Data.DbObject.AddInputParameter("@TipAsiguratID",SqlDbType.Int,4, tipAsiguratId),
					Salaries.Data.DbObject.AddInputParameter("@Descriere", SqlDbType.NVarChar, 250, descriere),
					Salaries.Data.DbObject.AddInputParameter("@tip_actiune", SqlDbType.Int, 4,1), //update
					new SqlParameter( "@rc", SqlDbType.Int, 4 )
				};

			// Descriere: Trebuie setata directia parametrului @rc la return, deoarece altfel el este considerat de output si
			//			  SQL Server va da o eroare deoarece in procedura stocata @rc nu este parametru de output, ci de return
			parameters[ 3 ].Direction = ParameterDirection.ReturnValue;

			RunProcedure("InsertUpdateDeleteTipAsigurat", parameters);
		}
		#endregion

		#region Delete
		/// <summary>
		///  Procedura realizeaza stergerea unui tip de asigurat
		/// </summary>
		/// <param name="TipAsiguratID">parametrul contine id-ul casei de asigurari care va fi stearsa</param>
		/// <returns></returns>
		public void Delete(int tipAsiguratId)
		{
			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@TipAsiguratID",SqlDbType.Int,4, tipAsiguratId),
				Salaries.Data.DbObject.AddInputParameter("@Descriere", SqlDbType.NVarChar, 250, ""),
				Salaries.Data.DbObject.AddInputParameter("@tip_actiune", SqlDbType.Int, 4,2), //delete
				new SqlParameter( "@rc", SqlDbType.Int, 4 )
			};	

			// Descriere: Trebuie setata directia parametrului @rc la return, deoarece altfel el este considerat de output si
			//			  SQL Server va da o eroare deoarece in procedura stocata @rc nu este parametru de output, ci de return
			parameters[ 3 ].Direction = ParameterDirection.ReturnValue;

			RunProcedure("InsertUpdateDeleteTipAsigurat", parameters);
		}
		#endregion
		
		#region GetTipAsiguratInfo
		/// <summary>
		/// Procedura obtine informatii despre un tip de asigurat
		/// </summary>
		/// <param name="TipAsiguratID">parametrul contine id-ul tipului de asigurat despre care se doresc informatii</param>
		/// <returns>este returnat un DataSet care contine infrmatiile selectate</returns>
		public DataSet GetTipAsiguratInfo(int tipAsiguratId)
		{
			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@TipAsiguratID",SqlDbType.Int,4, tipAsiguratId)
			};	

			return RunProcedure("GetTipAsiguratInfo", parameters, "TipAsiguratInfo");
		}	
		#endregion

		#region GetAllTipAsigurat
		/// <summary>
		/// Procedura obtine informatii despre toate tipurile de asigurat
		/// </summary>
		/// <returns>este returnat un dataset care contine aceste valori</returns>
		public DataSet GetAllTipAsigurat()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetAllTipAsigurat", parameters, "TipAsigurat");
		}	
		#endregion

		#region CheckIfTipAsiguratCanBeDeleted
		/// <summary>
		/// Executa procedura stocata <c>CheckIfTipAsiguratCanBeDeleted</c> si returneaza rezultatul oferit
		/// de aceasta.
		/// 
		/// Procedura <c>CheckIfTipAsiguratCanBeDeleted</c> verifica daca exista referinte in tabela
		/// <c>Angajati</c> la tip asigurat cu id-ul c>tipAsiguratID</c>, returnand 0 daca exista cel putin
		/// o astfel de referinta, sau 1, in caz contrar (daca nu exista legaturi in tabela <c>Angajati</c> la tipul de
		/// asigurat cu id-ul <c>tipAsiguratID</c>)
		/// 
		/// </summary>
		/// <param name="tipAsiguratID">id-ul tipului de asigurat pentru care se doreste verificarea</param>
		/// <returns>1 daca exista date asociate lui, 
		///			 2 daca e ultimul din lista
		///			 0 daca se poate efectua stergerea
		///	</returns>
		public int CheckIfTipAsiguratCanBeDeleted( int tipAsiguratID )
		{
			SqlParameter[] parameters = {
											Salaries.Data.DbObject.AddInputParameter( "@TipAsiguratID", SqlDbType.Int, 4, tipAsiguratID ),
											new SqlParameter( "@Raspuns", SqlDbType.Int, 4 )
										};
			parameters[ 1 ].Direction = ParameterDirection.ReturnValue;

			RunProcedure( "CheckIfTipAsiguratCanBeDeleted", parameters );

			return int.Parse(parameters[ 1 ].Value.ToString());
		}
		#endregion

		#region VerificaExistentaTipAsigurat
		/// <summary>
		/// Verifica daca se poate adauga/modifica un tip de asigurat cu ID-ul si descrierea introdusa de utilizator.
		/// </summary>
		/// <param name="tipAsiguratID"> ID-ul tipului de asigurat. In cazul adaugarii unui tip nou valoarea va fi -1.</param>
		/// <param name="descriere"> Descrierea tipului de asigurat.</param>
		/// <returns> true, daca se poate adauga/modifica, false in caz contrar</returns>
		/// <remarks>
		/// </remarks>
		public bool VerificaExistentaTipAsigurat( int tipAsiguratID, string descriere )
		{
			bool existaTipAsigurat;

			SqlParameter[] parameters = 
				{
					new SqlParameter("@TipAsiguratID", SqlDbType.Int, 4),
					new SqlParameter("@descriere", SqlDbType.NVarChar, 250),
					new SqlParameter("@existaTipAsigurat", SqlDbType.Bit, 1 )		
				};

			parameters[0].Value = tipAsiguratID;
			parameters[1].Value = descriere;
			parameters[3].Direction = ParameterDirection.Output;

			RunProcedure( "CheckIfExistaTipAsigurat", parameters );

			existaTipAsigurat = bool.Parse( parameters[3].Value.ToString());
			
			return existaTipAsigurat;
		}
		#endregion
	}
}
