/*
 *	Modificat:		Oprescu Claudia 
 *	Data:			13.04.2006
 *	Descriere:		Clasa se ocupa cu gestiunea unei variabile globale
 */

using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Data
{
	/// <summary>
	/// Clasa se ocupa cu operatiile executate pe tabela sal_VariabileGlobaleValoriTipuri
	/// </summary>
	public class VariabileGlobaleValori : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor care primeste ca si parametru stringul de conexiune la baza de date
		/// Este mostenit constructorul din clasa de baza
		/// </summary>
		/// <param name="connectionString"> String-ul de conectare la baza de date.</param>
		public VariabileGlobaleValori(string connectionString) : base (connectionString)
		{
		}
		#endregion

		#region Insert
		/// <summary>
		/// Procedura insereaza o inregistrare in tabela sal_VariabileGlobaleValori
		/// </summary>
		/// <param name="variabilaGlobalaId">tipul de variabila de care apartine variabila</param>
		/// <param name="lunaId">luna pentru care se adauga variabila</param>
		/// <param name="valoare">valoarea variabilei care se adauga</param>
		/// <returns>id-ul inregistrarii nou adaugate</returns>
		public int Insert(int variabilaGlobalaId, int lunaId, float valoare)
		{
			SqlParameter[] parameters = 
				{
					Salaries.Data.DbObject.AddOutputParameter("@ID",SqlDbType.Int,4),
					Salaries.Data.DbObject.AddInputParameter("@VariabilaGlobalaID", SqlDbType.Int, 4, variabilaGlobalaId),
					Salaries.Data.DbObject.AddInputParameter("@LunaID", SqlDbType.Int, 4, lunaId),
					Salaries.Data.DbObject.AddInputParameter("@Valoare", SqlDbType.Float, 8, valoare)
				};
			RunProcedure("spInsertVariabileGlobaleValori", parameters);
			return (int)parameters[0].Value;
		}
		#endregion

		#region Update
		/// <summary>
		/// Procedura actualizeaza o inregistrare din tabela sal_VariabileGlobaleValori
		/// </summary>
		/// <param name="id">id-ul inregistrarii care se ascualizeaza</param>
		/// <param name="variabilaGlobalaId">tipul de variabila de care apartine variabila</param>
		/// <param name="lunaId">luna pentru care se adauga variabila</param>
		/// <param name="valoare">valoarea variabilei care se adauga</param>
		public void Update(int id, int variabilaGlobalaId, int lunaId, float valoare)
		{
			SqlParameter[] parameters = 
				{
					Salaries.Data.DbObject.AddInputParameter("@ID",SqlDbType.Int,4, id),
					Salaries.Data.DbObject.AddInputParameter("@VariabilaGlobalaID", SqlDbType.Int, 4, variabilaGlobalaId),
					Salaries.Data.DbObject.AddInputParameter("@LunaID", SqlDbType.Int, 4, lunaId),
					Salaries.Data.DbObject.AddInputParameter("@Valoare", SqlDbType.Float, 8, valoare)
				};
			RunProcedure("spUpdateVariabileGlobaleValori", parameters);
		}
		#endregion

		#region GetVariabileGlobaleValoriInfo
		/// <summary>
		/// Procedura obtine informatii despre o anumita variabila globala. Informatiile sunt luate din tabelele sal_VariabileGlobaleValori si sal_VariabileGlobaleTipuri
		/// </summary>
		/// <param name="id">id-ul variabilei despre care se obtin informatii</param>
		/// <returns>Se returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetVariabileGlobaleValoriInfo(int id)
		{
			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@ID",SqlDbType.Int,4, id)
			};	
			return RunProcedure("spGetVariabileGlobaleValoriInfo", parameters, "VariabileGlobaleValoriInfo");
		}	
		#endregion

		#region GetAllVariabileGlobaleValoriPeLuna
		/// <summary>
		/// Procedura obtine informatii despre toate variabilele globale dintr-o anumita luna. 
		/// Sunt luate din tabelele sal_VariabileGlobaleValori si sal_VariabileGlobaleTipuri.
		/// </summary>
		/// <param name="lunaId">id-ul lunii pentru care sa obtin variabile</param>
		/// <returns>Se returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAllVariabileGlobaleValoriPeLuna(int lunaId)
		{
			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@LunaID",SqlDbType.Int,4, lunaId)
			};	
			return RunProcedure("spGetAllVariabileGlobaleValoriPeLuna", parameters, "AllVariabileGlobaleValoriPeLuna");
		}
		#endregion

		#region GetLuniVariabileGlobale
		/// <summary>
		/// Procedura returneaza perechi formate din luna si an pentru acele luni pentru care exista valori de variabile globale
		/// </summary>
		/// <returns>Se returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetLuniVariabileGlobale()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("spGetLuniVariabileGlobale", parameters, "GetLuniVariabileGlobale");
		}
		#endregion

		#region VerificaProcentInflatie
		/// <summary>
		/// Procedura verifica daca procentul de inflatie este negativ. Daca aceasta valoare este negativa nu se poate efectua inchiderea de luna
		/// </summary>
		/// <param name="lunaId">Luna pentru care se verifica valoarea procentului de inflatie</param>
		/// <returns>Returneaza true daca se poate face inchiderea de luna si false altfel</returns>
		/// <remarks>
		/// Autor:	Oprescu Claudia
		/// Data:	30.01.2007
		/// </remarks>
		public bool VerificaProcentInflatie(int lunaId)
		{
			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@LunaID", SqlDbType.Int, 4, lunaId),
				Salaries.Data.DbObject.AddOutputParameter("@ProcentInflatie",SqlDbType.Float, 8)
			};	
			RunProcedure("spVerificaProcentInflatie", parameters, "ProcentInflatie");			
			return float.Parse(parameters[1].Value.ToString()) != 0;
		}
		#endregion
	}
}
