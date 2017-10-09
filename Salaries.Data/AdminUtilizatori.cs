using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminUtilizatori.
	/// </summary>
	public class AdminUtilizatori : Salaries.Data.DbObject
	{
		#region AdminUtilizatori
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminUtilizatori(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoUtilizatori
		/// <summary>
		/// Procedura selecteaza utilizatorii unui angajator
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului pentru care sunt selectati utilizatorii</param>
		public DataSet LoadInfoUtilizatori(int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorId", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = angajatorId;	
			return RunProcedure("spGetUtilizatoriAngajator", parameters, "GetUtilizatoriAngajator");
		}
		#endregion

		#region InsertUtilizator
		//Autor: Lungu Andreea
		//Data: 01.11.2007
		/// <summary>
		/// Procedura adauga un utilizator
		/// </summary>
		/// <param name="grupUtilizatorAngajatorId">id0ul grupului din care face parte din cdrul angajatorului</param>
		/// <param name="nume">numele utilizatorului</param>
		/// <param name="parola">parola utilizatorului</param>
		public void InsertUtilizator(int grupUtilizatorAngajatorId, string nume, string parola, string email)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@UtilizatorId", SqlDbType.Int, 4),
								new SqlParameter("@GrupUtilizatorAngajatorId", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 100),
								new SqlParameter("@Parola", SqlDbType.NVarChar, 100),
								new SqlParameter("@Email", SqlDbType.NVarChar, 100)
							};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = grupUtilizatorAngajatorId;
			parameters[3].Value = nume;
			parameters[4].Value = parola;
			parameters[5].Value = email;

			RunProcedure("InsertUpdateDeleteUtilizator", parameters);
		}
		#endregion

		#region UpdateUtilizator
		//autor: Lungu Andreea
		//data: 02.11.2007
		/// <summary>
		/// Procedura modifica datele unui utilizator.
		/// </summary>
		/// <param name="utilizatorId">id-ul utilizatorului</param>
		public void UpdateUtilizator(string nume, string parola, int utilizatorId, string email)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@UtilizatorId", SqlDbType.Int, 4),
								new SqlParameter("@GrupUtilizatorAngajatorId", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 100),
								new SqlParameter("@Parola", SqlDbType.NVarChar, 100),
								new SqlParameter("@Email", SqlDbType.NVarChar, 100)
							};
			
			parameters[0].Value = 1;
			parameters[1].Value = utilizatorId;
			parameters[2].Value = 0;
			parameters[3].Value = nume;
			parameters[4].Value = parola;
			parameters[5].Value = email;

			RunProcedure("InsertUpdateDeleteUtilizator", parameters);
		}
		#endregion

		#region DeleteUtilizator
		//autor: Lungu Andreea
		//data: 01.11.2007
		/// <summary>
		/// Procedura sterge un utilizator.
		/// </summary>
		/// <param name="utilizatorId">id-ul utilizatorului</param>
		public void DeleteUtilizator(int utilizatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@UtilizatorId", SqlDbType.Int, 4),
								new SqlParameter("@GrupUtilizatorAngajatorId", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 100),
								new SqlParameter("@Parola", SqlDbType.NVarChar, 100),
								new SqlParameter("@Email", SqlDbType.NVarChar, 100)
							};
			
			parameters[0].Value = 2;
			parameters[1].Value = utilizatorId;
			parameters[2].Value = 0;
			parameters[3].Value = "";
			parameters[4].Value = "";
			parameters[5].Value = "";

			RunProcedure("InsertUpdateDeleteUtilizator", parameters);
		}
		#endregion

		#region VerificaExistentaUtilizator
		/// <summary>
	    /// Verifica daca mai exista inca un utilizator ce are acelasi acelasi grup, angajator, nume si parola cu utilizatorul ce se doreste a fi
		/// adaugat
	    /// </summary>
	    /// <param name="UtilizatorId">id-ul utilizatorului</param>
	    /// <param name="GrupUtilizatorAngajatorId">id-ul grupului</param>
	    /// <param name="nume">nume utilizator</param>
	    /// <param name="parola">parola utilizator</param>
	    /// <returns>true in cazul in care mai exista o banca ce are aceleasi caracteristici, false altfel.</returns>
	    /// <remarks>
	    /// Autor: Lungu Andreea
	    /// Data: 01.11.2007
	    /// </remarks>
		public bool VerificaExistentaUtilizator(int utilizatorId, int GrupUtilizatorAngajatorId, string nume, string parola)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@UtilizatorId", SqlDbType.Int, 4),
								new SqlParameter("@GrupUtilizatorAngajatorId", SqlDbType.Int, 4),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 100),
								new SqlParameter("@Parola", SqlDbType.NVarChar, 100),
								new SqlParameter("@NrUtilizatori", SqlDbType.Int, 1)
							};
			
			parameters[0].Value = utilizatorId;
			parameters[1].Value = GrupUtilizatorAngajatorId;
			parameters[2].Value = nume;
			parameters[3].Value = parola;
			parameters[4].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfUtilizatorCanBeAdded", parameters);
			if (Convert.ToInt32(parameters[4].Value.ToString())>0)
				return true;
			else
				return false;
		}
		#endregion

		#region VerificaStergereUtilizator
		/// <summary>
		/// Verifica daca se poate sterge un utilizator
		/// </summary>
		/// <param name="utilizatorId">id-ul utilizatorului</param>
		/// <returns>true in cazul in care se poate sterge, false altfel</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 01.11.2007
		/// </remarks>
		public int VerificaStergereUtilizator(int utilizatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@UtilizatorId", SqlDbType.Int, 4),
								new SqlParameter("@sePoateSterge", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = utilizatorId;
			parameters[1].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfUtilizatorCanBeDeleted", parameters);
			return int.Parse(parameters[1].Value.ToString());
			//returneaza 0 - se poate sterge; 1 - nu se poate sterge pt ca este ultimul user din lista.
		}
		#endregion

		#region GetGrupUtilizatorAngajatorId
		/// <summary>
		/// Procedura ce returneaza id-ul legaturii dintre angajator si grup
		/// </summary>
		/// <param name="angajatorId">id  angajator</param>
		/// <param name="grupId">id grup</param>
		/// <returns>id-ul legaturii dintre angajator si grup</returns>
		/// <remarks>
		/// Autor: Lungu Andreea
		/// Data: 01.11.2007
		/// </remarks>
		public int GetGrupUtilizatorAngajatorId(int angajatorId, int grupId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@AngajatorId", SqlDbType.Int, 4),
								new SqlParameter("@GrupId", SqlDbType.Int, 4),
								new SqlParameter("@GrupUtilizatorAngajatorId", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = angajatorId;
			parameters[1].Value = grupId;
			parameters[2].Direction = ParameterDirection.Output;

			RunProcedure("spGetGrupUtilizatorAngajatorId", parameters);
			return int.Parse(parameters[2].Value.ToString());
		}
		#endregion

		#region GetUtilizatorId
		//Autor: Lungu Andreea
		//Data: 02.11.2007
		/// <summary>
		/// Procedura aduce id-ul utilizatorului care are numele, parola si angajatorul precizate.
		/// </summary>
		/// <param name="nume">nume utilizator</param>
		/// <param name="parola">parola utilizator</param>
		/// <param name="angajatorId">id angajator</param>
		/// <returns>id-ul utilizatorului</returns>
		public int GetUtilizatorId(string nume, string parola, int angajatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@Nume", SqlDbType.NVarChar, 100),
								new SqlParameter("@Parola", SqlDbType.NVarChar, 100),
								new SqlParameter("@AngajatorId", SqlDbType.Int, 4),
								new SqlParameter("@UtilizatorId", SqlDbType.Int, 4),
			};
			
			parameters[0].Value = nume;
			parameters[1].Value = parola;
			parameters[2].Value = angajatorId;
			parameters[3].Direction = ParameterDirection.Output;

			RunProcedure("spGetUtilizatorId", parameters);
			return int.Parse(parameters[3].Value.ToString());
		
		}
		#endregion

		#region LoadInfoUtilizator
		/// <summary>
		/// Procedura selecteaza detaliile unui utilizatori
		/// </summary>
		/// <param name="utilizatorId">Id-ul utilizatorului</param>
		public DataSet LoadInfoUtilizator(int utilizatorId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@UtilizatorId", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = utilizatorId;	
			return RunProcedure("spUtilizatori_LoadInfoUtilizator", parameters, "LoadInfoUtilizator");
		}
		#endregion

	}
}
