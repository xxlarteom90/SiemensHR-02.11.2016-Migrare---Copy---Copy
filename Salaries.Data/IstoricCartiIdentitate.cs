using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for IstoricCartiIdentitate.
	/// </summary>
	public class IstoricCartiIdentitate : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public IstoricCartiIdentitate(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadIstoricCartiIdentitate
		/// <summary>
		/// Procedura selecteaza cartile de identitate ale unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine cartile de identitate ale angajatului</returns>
		public DataSet LoadIstoricCartiIdentitate(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10)
				};
			
			parameters[0].Value = angajatId;
			return RunProcedure("GetCartiIdentitateAngajat", parameters, "GetCartiIdentitateAngajat");
		}
		#endregion

		#region CheckIfIsCarteIdentitateActiva
		/// <summary>
		/// Verifica daca este activa o carte de identitate.
		/// </summary>
		/// <param name="CarteIdentitateID">Id-ul cartii de identitate.</param>
		/// <returns>true daca este activa, false altfel</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data: 26.05.2006
		/// </remarks>
		public bool CheckIfIsCarteIdentitateActiva(int carteIdentitateId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@CarteIdentitateID", SqlDbType.Int, 4),
					new SqlParameter("@esteActiva", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = carteIdentitateId;
			parameters[1].Direction = ParameterDirection.Output;
			
			RunProcedure("CheckIfCarteIdentitateActiva", parameters);
			return bool.Parse(parameters[1].Value.ToString());
		}
		#endregion

		#region InsertCarteIdentitate
		/// <summary>
		/// Procedura adauga o carte de identitate
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="cnp">CNP-ul angajatului</param>
		/// <param name="cnpAnterior">CNP-ul anterior al angajatului</param>
		/// <param name="serie">Seria pentru CI</param>
		/// <param name="numar">Numar pentru CI</param>
		/// <param name="eliberatDe">Eliberat de</param>
		/// <param name="dataEliberarii">Data eliberarii</param>
		/// <param name="valabilPanaLa">Valabil pana la</param>
		/// <param name="activ">Specifica daca este activ sau nu</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool InsertCarteIdentitate(long angajatId, long cnp, long cnpAnterior, string serie, string numar, string eliberatDe, DateTime dataEliberarii, DateTime valabilPanaLa, bool activ)
		{
			// Modificat: Anca Holostencu
			// Descriere: Adaugarea este facuta doar daca nu mai exista o carte de identitate cu aceleasi date.
			//			  Trebuie surprins cazul in care inserarea nu a fost facuta.

			// se dauga parametrul care va retine valoarea returnata de procedura (cel care indica daca inserarea a fost facuta)
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@CarteIdentitateID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@CNP", SqlDbType.BigInt, 10),
					new SqlParameter("@CNPAnterior", SqlDbType.BigInt, 10),
					new SqlParameter("@Numar", SqlDbType.VarChar, 10),
					new SqlParameter("@Serie", SqlDbType.NVarChar, 10),
					new SqlParameter("@EliberatDe", SqlDbType.NVarChar, 50),
					new SqlParameter("@DataEliberarii", SqlDbType.DateTime, 8),
					new SqlParameter("@ValabilPanaLa", SqlDbType.DateTime, 8),
					new SqlParameter("@Activ", SqlDbType.Bit, 1),
					new SqlParameter( "@rc", SqlDbType.Int)
				};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = angajatId;
			parameters[3].Value = cnp;
			parameters[4].Value = cnpAnterior;
			parameters[5].Value = numar;
			parameters[6].Value = serie;
			parameters[7].Value = eliberatDe;
			parameters[8].Value = dataEliberarii;
			parameters[9].Value = valabilPanaLa;
			parameters[10].Value = activ;
			parameters[11].Direction = ParameterDirection.ReturnValue;

			RunProcedure("InsertUpdateDeleteCarteIdentitate", parameters);
			
			// daca nu s-a facut inserarea, se returneaza false
			if (int.Parse(parameters[11].Value.ToString()) == -1)
				return false;

			return true;
		}
		#endregion

		#region UpdateCarteIdentitate
		/// <summary>
		/// Procedura actualizeaza o carte de identitate
		/// </summary>
		/// <param name="carteIdentitateId">Id-ul cartii de identitate</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="cnp">CNP-ul angajatului</param>
		/// <param name="cnpAnterior">CNP-ul anterior al angajatului</param>
		/// <param name="serie">Seria pentru CI</param>
		/// <param name="numar">Numar pentru CI</param>
		/// <param name="eliberatDe">Eliberat de</param>
		/// <param name="dataEliberarii">Data eliberarii</param>
		/// <param name="valabilPanaLa">Valabil pana la</param>
		/// <param name="activ">Specifica daca este activ sau nu</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool UpdateCarteIdentitate(int carteIdentitateId, long angajatId, long cnp, long cnpAnterior, string serie, string numar, string eliberatDe, DateTime dataEliberarii, DateTime valabilPanaLa, bool activ)
		{
			// Modificat: Anca Holostencu
			// Descriere: Adaugarea este facuta doar daca nu mai exista o carte de identitate cu aceleasi date.
			//			  Trebuie surprins cazul in care inserarea nu a fost facuta.

			// se dauga parametrul care va retine valoarea returnata de procedura (cel care indica daca inserarea a fost facuta)
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@CarteIdentitateID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@CNP", SqlDbType.BigInt, 10),
					new SqlParameter("@CNPAnterior", SqlDbType.BigInt, 10),
					new SqlParameter("@Numar", SqlDbType.VarChar, 10),
					new SqlParameter("@Serie", SqlDbType.NVarChar, 10),
					new SqlParameter("@EliberatDe", SqlDbType.NVarChar, 50),
					new SqlParameter("@DataEliberarii", SqlDbType.DateTime, 8),
					new SqlParameter("@ValabilPanaLa", SqlDbType.DateTime, 8),
					new SqlParameter("@Activ", SqlDbType.Bit, 1),
					new SqlParameter( "@rc", SqlDbType.Int)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = carteIdentitateId;
			parameters[2].Value = angajatId;
			parameters[3].Value = cnp;
			parameters[4].Value = cnpAnterior;
			parameters[5].Value = numar;
			parameters[6].Value = serie;
			parameters[7].Value = eliberatDe;
			parameters[8].Value = dataEliberarii;
			parameters[9].Value = valabilPanaLa;
			parameters[10].Value = activ;
			parameters[11].Direction = ParameterDirection.ReturnValue;

			RunProcedure("InsertUpdateDeleteCarteIdentitate", parameters);
			
			// daca nu s-a facut inserarea, se returneaza false
			if (int.Parse(parameters[11].Value.ToString()) == -1)
				return false;

			return true;
		}
		#endregion

		#region DeleteCarteIdentitate
		/// <summary>
		/// Procedura sterge o carte de identitate
		/// </summary>
		/// <param name="carteIdentitateId">Id-ul cartii de identitate care se sterge</param>
		public void DeleteCarteIdentitate(int carteIdentitateId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@CarteIdentitateID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@CNP", SqlDbType.BigInt, 10),
					new SqlParameter("@CNPAnterior", SqlDbType.BigInt, 10),
					new SqlParameter("@Numar", SqlDbType.VarChar, 10),
					new SqlParameter("@Serie", SqlDbType.NVarChar, 10),
					new SqlParameter("@EliberatDe", SqlDbType.NVarChar, 50),
					new SqlParameter("@DataEliberarii", SqlDbType.DateTime, 8),
					new SqlParameter("@ValabilPanaLa", SqlDbType.DateTime, 8),
					new SqlParameter("@Activ", SqlDbType.Bit, 1),
					new SqlParameter( "@rc", SqlDbType.Int)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = carteIdentitateId;
			parameters[2].Value = 0;
			parameters[3].Value = 0;
			parameters[4].Value = 0;
			parameters[5].Value = "";
			parameters[6].Value = "";
			parameters[7].Value = "";
			parameters[8].Value = System.DBNull.Value;
			parameters[9].Value = System.DBNull.Value;
			parameters[10].Value = false;
			parameters[11].Direction = ParameterDirection.ReturnValue;

			RunProcedure("InsertUpdateDeleteCarteIdentitate", parameters);
		}
		#endregion
	}
}
