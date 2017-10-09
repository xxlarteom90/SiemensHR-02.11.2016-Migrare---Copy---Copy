using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for IstoricPasaport.
	/// </summary>
	public class IstoricPasaport : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public IstoricPasaport(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadIstoricPasapoarte
		/// <summary>
		/// Procedura selecteaza pasapoartele unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadIstoricPasapoarte(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.BigInt, 10)
				};
			parameters[0].Value = angajatId;
			return RunProcedure("GetPasapoarteAngajat", parameters, "GetPasapoarteAngajat");
		}
		#endregion

		#region InsertPasaport
		/// <summary>
		/// Procedura adauga un pasaport pentur un angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="serie">Seria pasaportului</param>
		/// <param name="numar">Numarul pasaportului</param>
		/// <param name="eliberatDe">Eliberat de</param>
		/// <param name="dataEliberarii">Data eliberarii</param>
		/// <param name="valabilPanaLa">Valabil pana la</param>
		/// <param name="activ">Specifica daca pasaportul este activ sau nu</param>
		public void InsertPasaport(long angajatId, string serie, string numar, string eliberatDe, DateTime dataEliberarii, DateTime valabilPanaLa, bool activ)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@PasaportID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@Numar", SqlDbType.NVarChar, 50),
					new SqlParameter("@Serie", SqlDbType.NVarChar, 10),
					new SqlParameter("@EliberatDe", SqlDbType.NVarChar, 50),
					new SqlParameter("@DataEliberarii", SqlDbType.DateTime, 8),
					new SqlParameter("@ValabilPanaLa", SqlDbType.DateTime),
					new SqlParameter("@Activ", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 0;
			parameters[1].Value = -1;
			parameters[2].Value = angajatId;
			parameters[3].Value = numar;
			parameters[4].Value = serie;
			parameters[5].Value = eliberatDe;
			parameters[6].Value = dataEliberarii;
			parameters[7].Value = valabilPanaLa;
			parameters[8].Value = activ;
			
			RunProcedure("InsertUpdateDeletePasaport", parameters);
		}
		#endregion

		#region UpdatePasaport
		/// <summary>
		/// Procedura actualizeaza un pasaport al unui angajat
		/// </summary>
		/// <param name="pasaportId">Id-ul pasaportului</param>
		/// <param name="angajatId">Id-ul angajatului</param>
		/// <param name="serie">Seria pasaportului</param>
		/// <param name="numar">Numarul pasaportului</param>
		/// <param name="eliberatDe">Eliberat de</param>
		/// <param name="dataEliberarii">Data eliberarii</param>
		/// <param name="valabilPanaLa">Valabil pana la</param>
		/// <param name="activ">Specifica daca pasaportul este activ sau nu</param>
		public void UpdatePasaport(int pasaportId, long angajatId,  string serie, string numar, string eliberatDe, DateTime dataEliberarii, DateTime valabilPanaLa, bool activ)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@PasaportID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@Numar", SqlDbType.NVarChar, 50),
					new SqlParameter("@Serie", SqlDbType.NVarChar, 10),
					new SqlParameter("@EliberatDe", SqlDbType.NVarChar, 50),
					new SqlParameter("@DataEliberarii", SqlDbType.DateTime, 8),
					new SqlParameter("@ValabilPanaLa", SqlDbType.DateTime),
					new SqlParameter("@Activ", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = pasaportId;
			parameters[2].Value = angajatId;
			parameters[3].Value = numar;
			parameters[4].Value = serie;
			parameters[5].Value = eliberatDe;
			parameters[6].Value = dataEliberarii;
			parameters[7].Value = valabilPanaLa;
			parameters[8].Value = activ;
			
			RunProcedure("InsertUpdateDeletePasaport", parameters);
		}
		#endregion

		#region DeletePasaport
		/// <summary>
		/// Procedura sterge un pasaport
		/// </summary>
		/// <param name="pasaportId">Id-ul pasaportului care se sterge</param>
		public void DeletePasaport(int pasaportId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@PasaportID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@Numar", SqlDbType.NVarChar, 50),
					new SqlParameter("@Serie", SqlDbType.NVarChar, 10),
					new SqlParameter("@EliberatDe", SqlDbType.NVarChar, 50),
					new SqlParameter("@DataEliberarii", SqlDbType.DateTime, 8),
					new SqlParameter("@ValabilPanaLa", SqlDbType.DateTime),
					new SqlParameter("@Activ", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = pasaportId;
			parameters[2].Value = 0;
			parameters[3].Value = "";
			parameters[4].Value = "";
			parameters[5].Value = "";
			parameters[6].Value = System.DBNull.Value;
			parameters[7].Value = System.DBNull.Value;
			parameters[8].Value = false;
			
			RunProcedure("InsertUpdateDeletePasaport", parameters);
		}
		#endregion

		#region CheckIfPasaportCanBeAdded
		/// <summary>
		/// Procedura verifica daca un pasaport poate fi adaugat astfel incat sa nu se creeze duplicate
		/// </summary>
		/// <param name="pasaportId">Id-ul pasaportului care se verifica</param>
		/// <param name="serie">Seria pasaportului</param>
		/// <param name="numar">Numarul pasaportului</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfPasaportCanBeAdded(int pasaportId, string serie, string numar)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@PasaportID", SqlDbType.Int, 4),
					new SqlParameter("@Numar", SqlDbType.NVarChar, 50),
					new SqlParameter("@Serie", SqlDbType.NVarChar, 10),
					new SqlParameter("@NrPasapoarte", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = pasaportId;
			parameters[1].Value = numar;
			parameters[2].Value = serie;
			parameters[3].Direction = ParameterDirection.Output;
			
			RunProcedure("spCheckIfPasaportCanBeAdded", parameters);
			return byte.Parse(parameters[3].Value.ToString()) == 0;
		}
		#endregion
	}
}
