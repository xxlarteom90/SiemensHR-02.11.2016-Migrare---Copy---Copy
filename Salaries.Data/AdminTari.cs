using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminTari.
	/// </summary>
	public class AdminTari : Salaries.Data.DbObject
	{
		#region AdminTari
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminTari(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoTari
		/// <summary>
		/// Procedura selecteaza toate tarile
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoTari()
		{
			SqlParameter[] parameters = {};		
			return RunProcedure("GetAllTari", parameters, "GetAllTari");
		}
		#endregion

		#region LoadInfoTariCuJudete
		/// <summary>
		/// Procedura selecteaza toate tarile care au judete asociate
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoTariCuJudete()
		{
			SqlParameter[] parameters = {};		
			return RunProcedure("spGetAllTariCuJudete", parameters, "GetAllTariCuJudete");
		}
		#endregion

		#region LoadInfoTariUnion
		/// <summary>
		/// Sunt selectate toate tarile. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoTariUnion()
		{
			SqlParameter[] parameters = {};		
			return RunProcedure("spGetAllTariUnion", parameters, "GetAllTariUnion");
		}
		#endregion

		#region GetNationalitati
		/// <summary>
		/// Lista nationalitatilor din sistem
		/// </summary>
		/// <returns> Un DataSet cu toate nationalitatile din sistem.</returns>
		/// <remarks> 
		/// Autor: Cristina Raluca Muntean
		/// Data:  31.05.2006
		/// </remarks>
		public DataSet GetNationalitati()
		{
			SqlParameter[] parameters = {};		
			return RunProcedure("GetAllNationalitati", parameters, "GetAllNationalitati");
		}
		#endregion

		#region GetNationalitatiUnion
		/// <summary>
		/// Sunt selectate toate nationalitatile. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet GetNationalitatiUnion()
		{
			SqlParameter[] parameters = {};		
			return RunProcedure("spGetAllNationalitatiUnion", parameters, "GetAllNationalitatiUnion");
		}
		#endregion

		#region InsertTara
		/// <summary>
		/// Procedura adauga o tara
		/// </summary>
		/// <param name="numeTara">Denumirea tarii</param>
		/// <param name="simbol">Simbolul tarii</param>
		/// <param name="nationalitate">Nationalitatea tarii</param>
		/// <param name="taraDeBaza">Specifica daca tara este de baza sau nu</param>
		public void InsertTara(string numeTara, string simbol, string nationalitate, bool taraDeBaza)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TaraID", SqlDbType.Int, 4),
								new SqlParameter("@NumeTara", SqlDbType.NVarChar, 50),
								new SqlParameter("@Simbol", SqlDbType.NVarChar, 255),
								new SqlParameter("@Nationalitate", SqlDbType.NVarChar, 50),
								new SqlParameter("@TaraDeBaza", SqlDbType.Bit, 1)
							};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = numeTara;
			parameters[3].Value = simbol;
			parameters[4].Value = nationalitate;
			parameters[5].Value = taraDeBaza;

			RunProcedure("InsertUpdateDeleteTara", parameters);
		}
		#endregion

		#region UpdateTara
		/// <summary>
		/// Procedura actualizeaza o tara
		/// </summary>
		/// <param name="taraId">Id-ul tarii care se actualizeaza</param>
		/// <param name="numeTara">Denumirea tarii</param>
		/// <param name="simbol">Simbolul tarii</param>
		/// <param name="nationalitate">Nationalitatea tarii</param>
		/// <param name="taraDeBaza">Specifica daca tara este tara de baza sau nu</param>
		public void UpdateTara(int taraId, string numeTara, string simbol, string nationalitate, bool taraDeBaza)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TaraID", SqlDbType.Int, 4),
								new SqlParameter("@NumeTara", SqlDbType.NVarChar, 50),
								new SqlParameter("@Simbol", SqlDbType.NVarChar, 255),
								new SqlParameter("@Nationalitate", SqlDbType.NVarChar, 50),
								new SqlParameter("@TaraDeBaza", SqlDbType.Bit, 1)
							};
			
			parameters[0].Value = 1;
			parameters[1].Value = taraId;
			parameters[2].Value = numeTara;
			parameters[3].Value = simbol;
			parameters[4].Value = nationalitate;
			parameters[5].Value = taraDeBaza;

			RunProcedure("InsertUpdateDeleteTara", parameters);
		}
		#endregion

		#region DeleteTara
		/// <summary>
		/// Procedura sterge o tara
		/// </summary>
		/// <param name="taraId">Id-ul tarii care se sterge</param>
		public void DeleteTara(int taraId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@TaraID", SqlDbType.Int, 4),
								new SqlParameter("@NumeTara", SqlDbType.NVarChar, 50),
								new SqlParameter("@Simbol", SqlDbType.NVarChar, 255),
								new SqlParameter("@Nationalitate", SqlDbType.NVarChar, 50),
								new SqlParameter("@TaraDeBaza", SqlDbType.Bit, 1)
							};
			
			parameters[0].Value = 2;
			parameters[1].Value = taraId;
			parameters[2].Value = "";
			parameters[3].Value = "";
			parameters[4].Value = "";
			parameters[5].Value = false;

			RunProcedure("InsertUpdateDeleteTara", parameters);
		}
		#endregion

		#region GetTaraInfo
		/// <summary>
		/// Procedura selecteaza o tara
		/// </summary>
		/// <param name="taraId">Id-ul tarii selectate</param>
		/// <returns>Returneaza un DataSet care contine date despre tara selectata</returns>
		public DataSet GetTaraInfo(int taraId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@TaraID", SqlDbType.Int, 4)
							};
			parameters[0].Value = taraId;
			return RunProcedure("spGetTara", parameters, "GetTara");
		}
		#endregion

		#region GetTaraDeBaza
		/// <summary>
		/// Procedura selecteaza tara de baza
		/// </summary>
		/// <returns>Procedura returneaza un DataSet care contine datele despre tara de baza</returns>
		public DataSet GetTaraDeBaza()
		{
			SqlParameter[] parameters = {};
			return RunProcedure("GetTaraDeBaza", parameters, "GetTaraDeBaza");
		}
		#endregion

		#region CheckIfTaraCanBeDeleted
		/// <summary>
		/// Procedura verifica daca o tara poate fi stearsa
		/// </summary>
		/// <param name="taraId">Id-ul tarii pentru care se face verificarea</param>
		/// <returns>Returneaza true daca se poate sterge si false altfel</returns>
		public bool CheckIfTaraCanBeDeleted(int taraId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@TaraID", SqlDbType.Int, 4),
								new SqlParameter("@Raspuns", SqlDbType.Bit, 1)
							};

			parameters[0].Value = taraId;
			parameters[1].Direction = ParameterDirection.ReturnValue;

			DataSet ds = RunProcedure("spCheckIfTaraCanBeDeleted", parameters, "CheckIfTaraCanBeDeleted");
			return byte.Parse(parameters[1].Value.ToString()) == 1;
		}
		#endregion

		#region CheckIfTaraCanBeAdded
		/// <summary>
		/// Procedura veririca sa nu se creeze duplicate in tabela Tari prin adaugare/modificare
		/// </summary>
		/// <param name="taraId">Id-ul tarii care nu trebuie sa concida</param>
		/// <param name="numeTara">Numele tarii</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfTaraCanBeAdded(int taraId, string numeTara)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@NumeTara", SqlDbType.NVarChar, 50),
								new SqlParameter("@TaraID", SqlDbType.Int, 4),
								new SqlParameter("@NrTari", SqlDbType.Int, 4)
							};

			parameters[0].Value = numeTara;
			parameters[1].Value = taraId;
			parameters[2].Direction = ParameterDirection.Output;

			DataSet ds = RunProcedure("spCheckIfTaraCanBeAdded", parameters, "CheckIfTaraCanBeAdded");
			return byte.Parse(parameters[2].Value.ToString()) == 0;
		}
		#endregion
	}
}
