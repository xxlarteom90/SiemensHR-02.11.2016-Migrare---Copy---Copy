using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for AdminBanci.
	/// </summary>
	public class AdminBanci : Salaries.Data.DbObject
	{
		#region AdminBanci
		/// <summary>
		/// Constructorul cu string de conexiune
		/// </summary>
		/// <param name="connectionString">Stringul de conexiune la baza de date</param>
		public AdminBanci(string connectionString) : base (connectionString)
		{}
		#endregion

		#region LoadInfoBanci
		/// <summary>
		/// Procedura selecteaza toate bancile
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste banci</returns>
		public DataSet LoadInfoBanci()
		{
			SqlParameter[] parameters = {};					
			return RunProcedure("spGetAllBanci", parameters, "GetAllBanci");
		}
		#endregion

		#region LoadInfoBanciUnion
		/// <summary>
		/// Sunt selectate toate bancile. La aceste inregistrari se adauga o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inrgistrari</returns>
		public DataSet LoadInfoBanciUnion()
		{
			SqlParameter[] parameters = {};					
			return RunProcedure("spGetAllBanciUnion", parameters, "GetAllBanciUnion");
		}
		#endregion

		#region LoadInfoBanca
		//Lungu Andreea - 09.08.2011
		/// <summary>
		/// Procedura selecteaza o banca
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste banci</returns>
		public DataSet LoadInfoBanca(int idBanca)
		{
			SqlParameter[] parameters = 
						{
							new SqlParameter("@BancaID", SqlDbType.Int, 4),
						};	
			parameters[0].Value = idBanca;	
			return RunProcedure("spGetBancaById", parameters, "GetBancaById");
		}
		#endregion

		#region GetBanci
		/// <summary>
		/// Returneaza urmatoarele date despre fiecare banca: codul bancii - numele bancii si id-ul acesteia.
		/// </summary>
		/// <returns> Toate datele aferente bancilor sunt stocate intr-un DataSet.</returns>
		public DataSet GetBanci()
		{
			SqlParameter[] parameters = {};					
			return RunProcedure("GetBanci", parameters, "GetBanci");
		}
		#endregion

		#region GetJSArrays
		/// <summary>
		/// Returneaza array-uri cu BancaID si Numnarul de conturi asignate la fiecare banca
		/// </summary>
		/// <returns>Procedura returneaza stringul care contine bancile si numerele de cont ale acestora</returns>
		public string GetJSArrays()
		{
			SqlParameter[] parameters = {};					
			DataSet ds = RunProcedure("CountConturiPerBanca", parameters, "CountConturiPerBanca");

			string arBancaID = "";
			string arNoConturi = "";
			for(int i=0 ;i < ds.Tables[0].Rows.Count; i++)
			{
				DataRow row = ds.Tables[0].Rows[i];
				if (arBancaID!="")
					arBancaID += ",";
				arBancaID += "'" + row["BancaID"] + "'";
				if (arNoConturi!="")
					arNoConturi += ",";
				arNoConturi += "'" + Convert.ToInt32(row["nocontangajati"]) + Convert.ToInt32(row["nocontangajator"]) + "'";
			}

			return "var arBanciID = new Array("+ arBancaID + "); var arNoConturi = new Array(" + arNoConturi + ")";
		}
		#endregion

		#region InsertBanca
		/// <summary>
		/// Procedura adauga o banca
		/// </summary>
		/// <param name="cod">Codul bancii</param>
		/// <param name="nume">Numele bancii</param>
		/// <param name="filiala">Filiala bancii</param>
		public void InsertBanca(string cod, string nume, string filiala)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@BancaID", SqlDbType.Int, 4),
								new SqlParameter("@CodBanca", SqlDbType.NVarChar, 50),
								new SqlParameter("@NumeBanca", SqlDbType.NVarChar, 100),
								new SqlParameter("@FilialaBanca", SqlDbType.NVarChar, 100)
							};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = cod;
			parameters[3].Value = nume;
			parameters[4].Value = filiala;

			RunProcedure("InsertUpdateDeleteBanca", parameters);
		}
		#endregion

		#region UpdateBanca
		/// <summary>
		/// Procedura actualizeaza o banca
		/// </summary>
		/// <param name="bancaId">Id-ul bancii care se actualizeaza</param>
		/// <param name="cod">Codul bancii</param>
		/// <param name="nume">Denumirea bancii</param>
		/// <param name="filiala">Filiala bancii</param>
		public void UpdateBanca(int bancaId, string cod, string nume, string filiala)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@BancaID", SqlDbType.Int, 4),
								new SqlParameter("@CodBanca", SqlDbType.NVarChar, 50),
								new SqlParameter("@NumeBanca", SqlDbType.NVarChar, 100),
								new SqlParameter("@FilialaBanca", SqlDbType.NVarChar, 100)
							};
			
			parameters[0].Value = 1;
			parameters[1].Value = bancaId;
			parameters[2].Value = cod;
			parameters[3].Value = nume;
			parameters[4].Value = filiala;

			RunProcedure("InsertUpdateDeleteBanca", parameters);
		}
		#endregion

		#region DeleteBanca
		/// <summary>
		/// Procedura sterge o banca
		/// </summary>
		/// <param name="bancaId">Id-ul bancii care se stere</param>
		public void DeleteBanca(int bancaId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
								new SqlParameter("@BancaID", SqlDbType.Int, 4),
								new SqlParameter("@CodBanca", SqlDbType.NVarChar, 50),
								new SqlParameter("@NumeBanca", SqlDbType.NVarChar, 100),
								new SqlParameter("@FilialaBanca", SqlDbType.NVarChar, 100)
							};
			
			parameters[0].Value = 2;
			parameters[1].Value = bancaId;
			parameters[2].Value = "";
			parameters[3].Value = "";
			parameters[4].Value = "";

			RunProcedure("InsertUpdateDeleteBanca", parameters);
		}
		#endregion

		#region VerificaExistentaBanca
		/// <summary>
		/// Verifica daca mai exista inca o banca ce are acelasi cod si/sau denumire cu banca ce se doreste a fi
		/// adaugata/modificata.
		/// </summary>
		/// <param name="bancaId">ID-ul bancii.</param>
		/// <param name="codBanca">Codul bancii.</param>
		/// <param name="nume">Numele bancii.</param>
		/// <param name="filiala">Filiala bancii.</param>
		/// <returns> true in cazul in care mai exista o banca ce are aceleasi caracteristici, false altfel.</returns>
		/// <remarks>
		/// Autor:  Cristina Raluca Muntean
		/// Data:   14.06.2006
		/// </remarks>
		public bool VerificaExistentaBanca(int bancaId, string codBanca, string nume, string filiala)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@BancaID", SqlDbType.Int, 4),
								new SqlParameter("@CodBanca", SqlDbType.NVarChar, 50),
								new SqlParameter("@Nume", SqlDbType.NVarChar, 100),
								new SqlParameter("@Filiala", SqlDbType.NVarChar, 100),
								new SqlParameter("@existaBanca", SqlDbType.Bit, 1)
							};
			
			parameters[0].Value = bancaId;
			parameters[1].Value = codBanca;
			parameters[2].Value = nume;
			parameters[3].Value = filiala;
			parameters[4].Direction = ParameterDirection.Output;

			RunProcedure("CheckIfExistaBanca", parameters);
			return bool.Parse(parameters[4].Value.ToString());
		}
		#endregion

		#region VerificaStergereBanca
		/// <summary>
		/// Verifica daca se poate sterge banca.
		/// </summary>
		/// <param name="bancaId">ID-ul bancii.</param>
		/// <returns> true in cazul in care se poate sterge banca, false altfel.</returns>
		/// <remarks>
		/// Autor:  Cristina Raluca Muntean
		/// Data:   14.06.2006
		/// </remarks>
		public int VerificaStergereBanca(int bancaId)
		{
			SqlParameter[] parameters = 
							{
								new SqlParameter("@bancaID", SqlDbType.Int, 4),
								new SqlParameter("@sePoateSterge", SqlDbType.Int, 4)
							};
			
			parameters[0].Value = bancaId;
			parameters[1].Direction = ParameterDirection.Output;

			RunProcedure("CheckIfBancaCanBeDeleted", parameters);
			return int.Parse(parameters[1].Value.ToString());
		}
		#endregion
	}
}
