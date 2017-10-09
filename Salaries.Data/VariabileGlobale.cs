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
	/// Clasa se ocupa cu operatiile executate pe tabela sal_VariabileGlobaleTipuri
	/// </summary>
	public class VariabileGlobale : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor care primeste ca si parametru stringul de conexiune la baza de date
		/// Este mostenit constructorul din clasa de baza
		/// </summary>
		/// <param name="newConnectionString"></param>
		public VariabileGlobale(string connectionString) : base (connectionString)
		{
		}
		#endregion

		#region Insert
		/// <summary>
		/// Procedura realizeaza adaugarea in baza de date a unui tip de variabila globala
		/// </summary>
		/// <param name="denumire"> parametru care contine denumirea pentru tip de variabila globala </param>
		/// <param name="descriere"> parametru care contine descrierea pentru tip de variabila globala </param>
		/// <param name="cod"> parametru care contine codul pentru tip de variabila globala </param>
		/// <returns>procedura returneaza id-ul inregitrarii</returns>
		public int Insert(string denumire, string descriere, string cod)
		{
			SqlParameter[] parameters = 
				{
					Salaries.Data.DbObject.AddOutputParameter("@VariabilaGlobalaID",SqlDbType.Int,4),
					Salaries.Data.DbObject.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255, denumire),
					Salaries.Data.DbObject.AddInputParameter("@Descriere", SqlDbType.NVarChar, 512, descriere),
					Salaries.Data.DbObject.AddInputParameter("@Cod", SqlDbType.NVarChar, 32, cod)
				};

			RunProcedure("spInsertVariabileGlobaleTipuri", parameters);

			return (int)parameters[0].Value;
		}
		#endregion

		#region Update
		/// <summary>
		/// Procedura realizeaza actualizarea unei variabile globale
		/// </summary>
		/// <param name="variabilaGlobalaID">parametrul contine id-ul variabilei globale care va fi modificata</param>
		/// <param name="denumire">parametrul contine noua valoare pentru denumire a variabilei globale</param>
		/// <param name="descriere">parametrul contine noua valoare pentru descriere a variabilei globale</param>
		/// <param name="cod">parametrul contine noua valoare pentru cod a vairabilei globale</param>
		/// <returns></returns>
		public void Update(int variabilaGlobalaId, string denumire, string descriere, string cod)
		{
			SqlParameter[] parameters = 
				{
					Salaries.Data.DbObject.AddInputParameter("@VariabilaGlobalaID",SqlDbType.Int,4, variabilaGlobalaId),
					Salaries.Data.DbObject.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255, denumire),
					Salaries.Data.DbObject.AddInputParameter("@Descriere", SqlDbType.NVarChar, 512, descriere),
					Salaries.Data.DbObject.AddInputParameter("@Cod", SqlDbType.NVarChar, 32, cod)
				};

			RunProcedure("spUpdateVariabileGlobaleTipuri", parameters);
		}
		#endregion

		#region Delete
		/// <summary>
		///  Procedura realizeaza stergerea unei variabile globale
		/// </summary>
		/// <param name="variabilaGlobalaId">parametrul contine id-ul variabilei globale care va fi stearsa</param>
		/// <returns></returns>
		public void Delete(int variabilaGlobalaId)
		{
			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@VariabilaGlobalaID",SqlDbType.Int,4, variabilaGlobalaId)
			};	

			RunProcedure("spDeleteVariabileGlobaleTipuri", parameters);
		}
		#endregion
		
		#region GetVaiabilaGlobalaInfo
		/// <summary>
		/// Procedura obtine informatii despre o variabila globala
		/// </summary>
		/// <param name="variabilaGlobalaId">parametrul contine id-ul variailei globale despre care se doresc informatii</param>
		/// <returns>este returnat un DataSet care contine infrmatiile selectate</returns>
		public DataSet GetVaiabilaGlobalaInfo(int variabilaGlobalaId)
		{
			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@VariabilaGlobalaID",SqlDbType.Int,4, variabilaGlobalaId)
			};	

			return RunProcedure("spGetVariabileGlobaleTipuriInfo", parameters, "VariabilaGlobalaInfo");
		}	
		#endregion

		#region GetAllVariabileGlobale
		/// <summary>
		/// Procedura obtine informatii despre toate variabilele globale
		/// </summary>
		/// <returns>este retrnat un dataset care contine aceste valori</returns>
		public DataSet GetAllVariabileGlobale()
		{
			SqlParameter[] parameters = {};

			return RunProcedure("spGetAllVariabileGlobaleTipuri", parameters, "AllVariabileGlobale");
		}	
		#endregion

		#region CheckIfTipVariabilaGlobalaCanBeDeleted
		/// <summary>
		/// Executa procedura stocata CheckIfTipVariabilaGlobalaCanBeDeleted si returneaza rezultatul oferit de aceasta.
		/// Procedura CheckIfTipVariabilaGlobalaCanBeDeleted verifica daca exista referinte in tabela
		///			sal_VariabileGlobaleValori la tipul de variabila globala cu id-ul VariabilaGlobalaID.
		/// Se returneaza 0 daca exista cel putin o astfel de referinta, sau 1, in caz contrar (daca nu exista legaturi in tabela sal_VariabileGlobaleValori).
		/// Functia CheckIfTipVariabilaGlobalaCanBeDeleted(int VariabilaGlobalaID) interpreteaza rezultatul obtinut in
		/// urma executiei procedurii stocate cu acelasi nume.
		/// </summary>
		/// <param name="variabilaGlobalaId">id-ul variabilei globale pentru care se doreste verificarea</param>
		/// <returns> Returneaza rezultatul verificarii stergerii
		///	0 - se poate sterge
		///	1 - exista date asociate
		///	2 - tipul de variabila este ultimul din lista
		///	</returns>
		public int CheckIfTipVariabilaGlobalaCanBeDeleted(int variabilaGlobalaId)
		{
			SqlParameter[] parameters = 
				{
					Salaries.Data.DbObject.AddInputParameter("@VariabilaGlobalaID", SqlDbType.Int, 4, variabilaGlobalaId),
					Salaries.Data.DbObject.AddOutputParameter("@SePoateSterge", SqlDbType.Int, 4)
				};

			RunProcedure("spCheckIfTipVariabilaGlobalaCanBeDeleted", parameters);

			return int.Parse(parameters[1].Value.ToString());
		}
		#endregion

		#region GetAllVariabileGlobaleNeadaugate
		/// <summary>
		///  Procedura returneaza acele tipuri de variabile globale care nu au fost adaugate pentru luna curenta
		/// </summary>
		/// <param name="lunaId">parametrul contine id-ul lunii pentru care se cauta tipurile deja exstente</param>
		/// <returns>returneaza un data set cu aceste valori</returns>
		public DataSet GetAllVariabileGlobaleNeadaugate(int lunaId)
		{
			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@LunaID",SqlDbType.Int,4, lunaId)
			};	

			return RunProcedure("spGetAllVariabileGlobaleTipuriNeadaugate", parameters, "AllVariabileGlobaleNeadaugate");
		}
		#endregion

		#region GetProcentSanatateAngajat
		/// <summary>
		/// Este obtinuta valoarea procentului din baza de calcul a contributiei individuale de asigurari de sanatate.
		/// </summary>
		/// <param name="lunaId"> ID-ul lunii pentru care se doreste valoarea procentului.</param>
		/// <returns> Valoarea procentului din baza de calcul a contributiei individuale de asigurari de sanatate.</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  09.05.2006
		/// </remarks>
		public float GetProcentSanatateAngajat(int lunaId)
		{
			float procentCASangajat;

			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@lunaID",SqlDbType.Int,4, lunaId)
				, Salaries.Data.DbObject.AddOutputParameter("@procentCAS", SqlDbType.Float, 8)
			};	

			RunProcedure("spGetProcentSanatateAngajat", parameters);

			procentCASangajat = float.Parse(parameters[1].Value.ToString());

			return procentCASangajat;
		}
		#endregion

		#region GetProcentSanatateAgajator
		/// <summary>
		/// Este obtinut valoarea procentului din baza de calcul a contributieide sanatate a angajatorului.
		/// </summary>
		/// <param name="lunaId"> ID-ul lunii pentru care se doreste valoarea procentului.</param>
		/// <returns> Valoarea procentului din baza de calcul a contributieide sanatate a angajatorului..</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  09.05.2006
		/// </remarks>
		public float GetProcentSanatateAgajator(int lunaId)
		{
			float procentCASangajator;

			SqlParameter[] parameters = 
			{
				Salaries.Data.DbObject.AddInputParameter("@lunaID",SqlDbType.Int,4, lunaId)
				, Salaries.Data.DbObject.AddOutputParameter("@procentCAS", SqlDbType.Float, 8)
			};	

			RunProcedure("spGetProcentSanatateAngajator", parameters);

			procentCASangajator = float.Parse(parameters[1].Value.ToString());

			return procentCASangajator;
		}
		#endregion

		#region CheckIfTipVariabilaGlobalaCanBeAdded
		/// <summary>
		/// Procedura verifica sa nu se adauge duplicate in tabela sal_VariabileGlobaleTipuri
		/// </summary>
		/// <param name="variabilaGlobalaId">Id-ul variabilei care nu trebuie sa coincida</param>
		/// <param name="denumire">Denumirea tipului de variabila</param>
		/// <param name="cod">Codul pentru tipul de variabila</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfTipVariabilaGlobalaCanBeAdded(int variabilaGlobalaId, string denumire, string cod)
		{
			SqlParameter[] parameters = 
				{
					Salaries.Data.DbObject.AddInputParameter("@VariabilaGlobalaID", SqlDbType.Int, 4, variabilaGlobalaId),
					Salaries.Data.DbObject.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255, denumire),
					Salaries.Data.DbObject.AddInputParameter("@Cod", SqlDbType.NVarChar, 32, cod),
					Salaries.Data.DbObject.AddOutputParameter("@NrVariabile", SqlDbType.Int, 4)
				};

			RunProcedure("spCheckIfVariabileCanBeAdded", parameters);

			return byte.Parse(parameters[3].Value.ToString()) == 0;
		}
		#endregion
	}
}
