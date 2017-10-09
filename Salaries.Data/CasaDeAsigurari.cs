/*
 * 
 * Autor:	Oprescu Claudia
 * Data:	11.04.2006
 * Descriere:	Clasa se ocupa cu gestiunea unei case de asigurari
 * 
 * Modificat:	Lungu Andreea
 * Data:		21.02.2011
 * Descriere:	S-a adaugat o codificare la casa de asigurari.
 */

using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Data
{
	/// <summary>
	/// Clasa se ocupa cu oreratiile executate pe tabela cu casa de asigurari
	/// </summary>
	public class CasaDeAsigurari : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor care primeste ca si parametru stringul de conexiune la baza de date
		/// Este mostenit constructorul din clasa de baza
		/// </summary>
		/// <param name="connectionString"> String-ul de conectare la baza de date.</param>
		public CasaDeAsigurari(string connectionString) : base (connectionString)
		{
		}
		#endregion

		#region Insert
		/// <summary>
		/// Procedura realizeaza adaugarea in baza de date a unei case de asigurari
		/// </summary>
		/// <param name="cod"> parametru care contine codul pentru casa de asigurari </param>
		/// <param name="denumire"> parametru care contine denumirea pentru casa de asigurari </param>
		/// <param name="descriere"> parametru care contine descrierea pentru casa de asigurari </param>
		/// <returns>procedura returneaza numarul de randuri afectate de adaugare</returns>
		public int Insert(string cod, string denumire, string descriere, string codificare)
		{
			//int numAffected;
			SqlParameter[] parameters = 
				{
					Salaries.Data.DbObject.AddInputParameter("@CasaDeAsigurariID",SqlDbType.Int,4,-1),
					Salaries.Data.DbObject.AddInputParameter("@Cod", SqlDbType.NVarChar, 10, cod),
					Salaries.Data.DbObject.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, denumire),
					Salaries.Data.DbObject.AddInputParameter("@Descriere", SqlDbType.NVarChar, 250, descriere),
					Salaries.Data.DbObject.AddInputParameter("@Codificare", SqlDbType.NVarChar, 10, codificare),
					Salaries.Data.DbObject.AddInputParameter("@tip_actiune", SqlDbType.Int, 4,0), //insert
					new SqlParameter( "@rc", SqlDbType.Int, 4 )
				};
	
			// Adaugat: Anca Holostencu
			// Descriere: Trebuie setata directia parametrului @rc la return, deoarece altfel el este considerat de output si
			//			  SQL Server va da o eroare deoarece in procedura stocata @rc nu este parametru de output, ci de return
			parameters[ 6 ].Direction = ParameterDirection.ReturnValue;

			RunProcedure("InsertUpdateDeleteCasaDeAsigurari", parameters);
			return (int)parameters[6].Value;
		}
		#endregion
		
		#region Update
		/// <summary>
		/// Procedura realizeaza actualizarea unei case de asigurari
		/// </summary>
		/// <param name="casaDeAsigurariId">parametrul contine id-ul casei de asigurari care va fi modificata</param>
		/// <param name="cod">parametrul contine noua valoare pentru cod a casei de asigurari</param>
		/// <param name="denumire">parametrul contine noua valoare pentru denumire a casei de asigurari</param>
		/// <param name="descriere">parametrul contine noua valoare pentru descriere a casei de asigurari</param>
		/// <param name="codificare">parametrul contine noua valoare pentru codificare a casei de asigurari</param>
		/// <returns></returns>
		public void Update(int casaDeAsigurariId, string cod, string denumire, string descriere, string codificare)
		{
			SqlParameter[] parameters = 
				{
					Salaries.Data.DbObject.AddInputParameter("@CasaDeAsigurariID",SqlDbType.Int,4, casaDeAsigurariId),
					Salaries.Data.DbObject.AddInputParameter("@Cod", SqlDbType.NVarChar, 10, cod),
					Salaries.Data.DbObject.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, denumire),
					Salaries.Data.DbObject.AddInputParameter("@Descriere", SqlDbType.NVarChar, 250, descriere),
										Salaries.Data.DbObject.AddInputParameter("@Codificare", SqlDbType.NVarChar, 10, codificare),
					Salaries.Data.DbObject.AddInputParameter("@tip_actiune", SqlDbType.Int, 4,1), //update
					new SqlParameter( "@rc", SqlDbType.Int, 4 )
				};

			// Adaugat: Anca Holostencu
			// Descriere: Trebuie setata directia parametrului @rc la return, deoarece altfel el este considerat de output si
			//			  SQL Server va da o eroare deoarece in procedura stocata @rc nu este parametru de output, ci de return
			parameters[ 6 ].Direction = ParameterDirection.ReturnValue;

			RunProcedure("InsertUpdateDeleteCasaDeAsigurari", parameters);
		}
		#endregion

		#region Delete
		/// <summary>
		///  Procedura realizeaza stergerea unei case de asigurari
		/// </summary>
		/// <param name="CasaDeAsigurariID">parametrul contine id-ul casei de asigurari care va fi stearsa</param>
		/// <returns></returns>
		public void Delete(int casaDeAsigurariId)
		{
			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@CasaDeAsigurariID",SqlDbType.Int,4, casaDeAsigurariId),
				Salaries.Data.DbObject.AddInputParameter("@Cod", SqlDbType.NVarChar, 10, ""),
				Salaries.Data.DbObject.AddInputParameter("@Denumire", SqlDbType.NVarChar, 50, ""),
				Salaries.Data.DbObject.AddInputParameter("@Descriere", SqlDbType.NVarChar, 250, ""),
				Salaries.Data.DbObject.AddInputParameter("@Codificare", SqlDbType.NVarChar, 10, ""),
				Salaries.Data.DbObject.AddInputParameter("@tip_actiune", SqlDbType.Int, 4,2), //delete
				new SqlParameter( "@rc", SqlDbType.Int, 4 )
			};	

			// Adaugat: Anca Holostencu
			// Descriere: Trebuie setata directia parametrului @rc la return, deoarece altfel el este considerat de output si
			//			  SQL Server va da o eroare deoarece in procedura stocata @rc nu este parametru de output, ci de return
			parameters[ 6 ].Direction = ParameterDirection.ReturnValue;

			RunProcedure("InsertUpdateDeleteCasaDeAsigurari", parameters);
		}
		#endregion
		
		#region GetCasaDeAsigurariInfo
		/// <summary>
		/// Procedura obtine informatii despre o casa de asigurari
		/// </summary>
		/// <param name="CasaDeAsigurariID">parametrul contine id-ul casei de asigurari despre care se doresc informatii</param>
		/// <returns>este returnat un DataSet care contine infrmatiile selectate</returns>
		public DataSet GetCasaDeAsigurariInfo(int casaDeAsigurariId)
		{
			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@CasaDeAsigurariID",SqlDbType.Int,4, casaDeAsigurariId)
			};	

			return RunProcedure("GetCasaDeAsigurariInfo", parameters, "CasaDeAsigurariInfo");
		}	
		#endregion

		#region GetAllCasaDeAsigurari
		/// <summary>
		/// Procedura obtine informatii despre toate casele de asigurari
		/// </summary>
		/// <returns>este retrnat un dataset care contine aceste valori</returns>
		public DataSet GetAllCasaDeAsigurari()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetAllCasaDeAsigurari", parameters, "AllCasaDeAsigurari");
		}	
		#endregion

		#region CheckIfCasaAsigurariCanBeDeleted
		/// <summary>
		/// Executa procedura stocata <c>CheckIfCasaAsigurariCanBeDeleted</c> si returneaza rezultatul oferit
		/// de aceasta.
		/// 
		/// Procedura <c>CheckIfCasaAsigurariCanBeDeleted</c> verifica daca exista referinte in tabela
		/// <c>Angajati</c> la casa de asigurari cu id-ul c>casaAsigurariID</c>, returnand 0 daca exista cel putin
		/// o astfel de referinta, sau 1, in caz contrar (daca nu exista legaturi in tabela <c>Angajati</c> la casa de
		/// asigurari cu id-ul <c>casaAsigurariID</c>)
		/// 
		/// </summary>
		/// <param name="casaAsigurariID">id-ul casei de asigurari pentru care se doreste verificarea</param>
		/// <returns>1 daca exista date asociate ei, 
		///			 2 daca e ultima din lista
		///			 0 daca se poate efectua stergerea
		///	</returns>
		///	<remarks>Autor: Anca Holostencu</remarks>
		public int CheckIfCasaAsigurariCanBeDeleted( int casaAsigurariID )
		{
			SqlParameter[] parameters = {
											Salaries.Data.DbObject.AddInputParameter( "@CasaDeAsigurariID", SqlDbType.Int, 4, casaAsigurariID ),
											new SqlParameter( "@Raspuns", SqlDbType.Int, 4 )
										};
			parameters[ 1 ].Direction = ParameterDirection.ReturnValue;

			RunProcedure( "CheckIfCasaAsigurariCanBeDeleted", parameters );

			return int.Parse(parameters[ 1 ].Value.ToString());
		}
		#endregion

		#region VerificaExistentaCasaDeAsigurari
		/// <summary>
		/// Verifica daca se poate adauga/modifica o casa de asigurari cu denumirea si codul introduse de utilizator.
		/// </summary>
		/// <param name="casaAsigurariID"> ID-ul casei de asigurari. In cazul adaugarii unei case noi valoarea va fi -1.</param>
		/// <param name="cod"> Codul casei de asigurari</param>
		/// <param name="denumire"> Denumirea casei de asigurari.</param>
		/// <returns> true, daca se poate adauga/modifica, false in caz contrar</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  14.06.2006
		/// </remarks>
		public bool VerificaExistentaCasaDeAsigurari( int casaAsigurariID, string denumire, string cod )
		{
			bool existaCasaDeAsigurari;

			SqlParameter[] parameters = 
				{
					new SqlParameter("@casaDeAsigurariID", SqlDbType.Int, 4),
					new SqlParameter("@denumire", SqlDbType.NVarChar, 50),
					new SqlParameter("@cod", SqlDbType.NVarChar, 10),
					new SqlParameter("@existaCasaDeAsigurari", SqlDbType.Bit, 1 )		
				};

			parameters[0].Value = casaAsigurariID;
			parameters[1].Value = denumire;
			parameters[2].Value = cod;
			parameters[3].Direction = ParameterDirection.Output;

			RunProcedure( "CheckIfExistaCasaDeAsigurari", parameters );

			existaCasaDeAsigurari = bool.Parse( parameters[3].Value.ToString());
			
			return existaCasaDeAsigurari;
		}
		#endregion
	}
}

