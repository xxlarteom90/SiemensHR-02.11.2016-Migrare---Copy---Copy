using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for ConturiAngajat.
	/// </summary>
	public class ConturiAngajat : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="connectionString"> Stringul de conectare la baza de date.</param>
		public ConturiAngajat(string connectionString): base (connectionString)
		{}
		#endregion

		#region LoadConturiBanca
		/// <summary>
		/// Procedura selecteaza conturile unui angajat
		/// </summary>
		/// <param name="angajatId">Id-ul angajatului pentru care se selecteaza conturile</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadConturiBanca(long angajatId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@AngajatID", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = angajatId;
			return RunProcedure("GetAngajatConturiBanca", parameters, "GetAngajatConturiBanca");
		}
		#endregion

		#region InsertCont
		/// <summary>
		/// Procedura adauga un cont pentru angajat
		/// </summary>
		/// <param name="bancaID">Id-ul bancii la care este contul</param>
		/// <param name="numarCont">Numarul de cont</param>
		/// <param name="moneda">Tipul monezii pentru cont</param>
		/// <param name="angajatId">Id-ul angajatului pentru care se adauga contul</param>
		/// <param name="activ">Specifica daca acest cont este activ sau nu</param>
		public void InsertCont(int bancaId, string numarCont, string moneda, long angajatId, bool activ)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@ContID", SqlDbType.Int, 4),
					new SqlParameter("@BancaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NumarCont", SqlDbType.VarChar, 50),
					new SqlParameter("@Moneda", SqlDbType.VarChar, 3),
					new SqlParameter("@Activ", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 0;
			parameters[1].Value = 0;
			parameters[2].Value = bancaId;
			parameters[3].Value = angajatId;
			parameters[4].Value = numarCont;
			parameters[5].Value = moneda;
			parameters[6].Value = activ;

			RunProcedure("InsertUpdateDeleteContAngajat", parameters);
		}
		#endregion

		#region UpdateCont
		/// <summary>
		/// Procedura actualizeaza un cont al unui angajat
		/// </summary>
		/// <param name="contId">Id-ul contului</param>
		/// <param name="bancaID">Id-ul bancii la care este contul</param>
		/// <param name="numarCont">Numarul de cont</param>
		/// <param name="moneda">Tipul monezii pentru cont</param>
		/// <param name="angajatId">Id-ul angajatului pentru care se adauga contul</param>
		/// <param name="activ">Specifica daca acest cont este activ sau nu</param>
		public void UpdateCont(int contId, int bancaId, string numarCont, string moneda, long angajatId, bool activ)
		{	
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@ContID", SqlDbType.Int, 4),
					new SqlParameter("@BancaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NumarCont", SqlDbType.VarChar, 50),
					new SqlParameter("@Moneda", SqlDbType.VarChar, 3),
					new SqlParameter("@Activ", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 1;
			parameters[1].Value = contId;
			parameters[2].Value = bancaId;
			parameters[3].Value = angajatId;
			parameters[4].Value = numarCont;
			parameters[5].Value = moneda;
			parameters[6].Value = activ;

			RunProcedure("InsertUpdateDeleteContAngajat", parameters);
		}
		#endregion

		#region DeleteCont
		/// <summary>
		/// Procedura sterge un cont al unui angajat
		/// </summary>
		/// <param name="contId">Id-ul contului care se sterge</param>
		public void DeleteCont(int contId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4),
					new SqlParameter("@ContID", SqlDbType.Int, 4),
					new SqlParameter("@BancaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatID", SqlDbType.Int, 4),
					new SqlParameter("@NumarCont", SqlDbType.VarChar, 50),
					new SqlParameter("@Moneda", SqlDbType.VarChar, 3),
					new SqlParameter("@Activ", SqlDbType.Bit, 1)
				};
			
			parameters[0].Value = 2;
			parameters[1].Value = contId;
			parameters[2].Value = 0;
			parameters[3].Value = 0;
			parameters[4].Value = "";
			parameters[5].Value = "";
			parameters[6].Value = false;

			RunProcedure("InsertUpdateDeleteContAngajat", parameters);
		}
		#endregion		

		#region CheckIfContAngajatCanBeAdded
		/// <summary>
		/// Procedura verifica daca un cont al unui angajat poate fi adaugat
		/// </summary>
		/// <param name="numarCont">Contul angajatului</param>
		/// <param name="contID">Id-ul contului angajatului</param>
		/// <returns>Returneaza true daca se poate face adaugare sau modificare, si false altfel</returns>
		public bool CheckIfContAngajatCanBeAdded(string numarCont, int contId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@NumarCont", SqlDbType.NVarChar, 50),
					new SqlParameter("@ContID", SqlDbType.Int, 4),
					new SqlParameter("@NrConturi", SqlDbType.Int, 4)
				};

			parameters[0].Value = numarCont;
			parameters[1].Value = contId;
			parameters[2].Direction = ParameterDirection.Output;

			RunProcedure("spCheckIfContAngajatCanBeAdded", parameters);
			return byte.Parse(parameters[2].Value.ToString()) == 0;
		}
		#endregion
	}
}
