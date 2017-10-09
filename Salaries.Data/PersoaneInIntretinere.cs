using System;
using System.Data;
using System.Data.SqlClient;

/*
 *	Modificat:	Lungu Andreea
 *	Data:		18.03.2008
 *	Descriere:	A fost adaugat campul activ.
 *		(daca persoana respectiva este sau nu in intretinerea unui angajat 
 *		 la un moment dat depinde de variabila activ la acel moment)	
*/

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for PersoaneInIntretinere.
	/// </summary>
	public class DetaliiPersoane
	{
		//Id-ul persoanei
		public int ID;
		//Id-ul angajatului
		public int AngajatID;
		//Numele angajatului
		public string Nume;
		//Prenumele angajatului
		public string Prenume;
		//Tipul persoanei
		public int TipID;
		//CNP-ul persoanei
		public long CNP;
		//Tipul de invaliditate
		public int InvaliditateID;
		//Coeficientul persoanei
		public decimal Coeficient;
		//activ sau inactiv
		public bool Activ;
	};

	public class PersoaneInIntretinere : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="connectionString">String-ul de conexiune la baza de date</param>
		public PersoaneInIntretinere(string connectionString): base (connectionString)
		{}
		#endregion

		#region Delete
		/// <summary>
		/// Procedura sterge o persoana in intretinere
		/// </summary>
		/// <param name="id">Id-ul persoanei</param>
		/// <returns>Returneaza true daca s-a efectuat stergerea si false altfel</returns>
		public bool Delete(int id)
		{
			int numAffected;
					
			SqlParameter[] parameters = {new SqlParameter("@ID", SqlDbType.Int, 4)};
			parameters[0].Value = id;
			
			RunProcedure("sal_DeletePersoanaInIntretinere", parameters, out numAffected);
			return (numAffected == 1);
		}
		#endregion

		#region Update
		/// <summary>
		/// Procedura actualizeaza o persoana in intretinere
		/// </summary>
		/// <param name="id">Id-ul persoanei</param>
		/// <param name="nume">Numele persoanei</param>
		/// <param name="prenume">Prenumele persoanei</param>
		/// <param name="cnp">CNP-ul persoanei</param>
		/// <param name="tipid">Tipul persoanei</param>
		/// <param name="invaliditateid">Tipul de invaliditate</param>
		/// <param name="activ">Daca persoana mai este sau nu in intretinerea angajatului</param>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool Update(int id, string nume,string prenume,long cnp, int tipid, int invaliditateid, bool activ)
		{
			int numAffected;
		
			SqlParameter[] parameters = { new SqlParameter("@ID", SqlDbType.Int, 4),										
											new SqlParameter("@Nume", SqlDbType.NVarChar,50),
											new SqlParameter("@Prenume", SqlDbType.NVarChar,50),
											new SqlParameter("@TipID", SqlDbType.Int),
											new SqlParameter("@CNP", SqlDbType.BigInt),
											new SqlParameter("@InvaliditateID", SqlDbType.Int),
											new SqlParameter("@Activ",SqlDbType.Bit)};
			
			parameters[0].Value = id;			
			parameters[1].Value = nume;
			parameters[2].Value = prenume;
			parameters[3].Value = tipid;
			parameters[4].Value = cnp;
			parameters[5].Value = invaliditateid;
			parameters[6].Value = activ;
			
			RunProcedure("sal_UpdatePersoanaInIntretinere", parameters, out numAffected);

			return (numAffected == 1);
		}
		#endregion

		#region Add
		/// <summary>
		/// Procedura adauga o persoana in intretinere
		/// </summary>
		/// <param name="angajatid">Id-ul angajatului</param>
		/// <param name="nume">Numele angajatului</param>
		/// <param name="prenume">Prenumele angajatului</param>
		/// <param name="cnp">CNP-ul angajatului</param>
		/// <param name="tipid">Tipul persoanei</param>
		/// <param name="invaliditateid">Tipul de invaliditate</param>
		/// <param name="activ">Daca persoana mai este sau nu in intretinerea angajatului</param>
		public void Add(int angajatid, string nume, string prenume, long cnp, int tipid, int invaliditateid, bool activ)
		{
			int numAffected;
		
			SqlParameter[] parameters = { 	new SqlParameter("@AngajatID", SqlDbType.Int, 4),
											new SqlParameter("@Nume", SqlDbType.NVarChar,50),
											new SqlParameter("@Prenume", SqlDbType.NVarChar,50),
											new SqlParameter("@CNP", SqlDbType.BigInt),
											new SqlParameter("@TipID", SqlDbType.Int),
											new SqlParameter("@InvaliditateID", SqlDbType.Int),
											new SqlParameter("@Activ",SqlDbType.Bit),
											new SqlParameter("@SetID", SqlDbType.Int, 4)
										};

			parameters[0].Value = angajatid;
			parameters[1].Value = nume;
			parameters[2].Value = prenume;
			parameters[3].Value = cnp;
			parameters[4].Value = tipid;
			parameters[5].Value = invaliditateid;
			parameters[6].Value = activ;
			parameters[7].Direction = ParameterDirection.Output;
			
			RunProcedure("sal_InsertPersoanaInIntretinere", parameters, out numAffected);
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza detaliile unei persoane in intretinere
		/// </summary>
		/// <param name="id">Id-ul persoanei</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public DetaliiPersoane GetDetalii(int id)
		{
			SqlParameter[] parameters = { new SqlParameter("@PersID", SqlDbType.Int, 4) };
			parameters[0].Value = id;
			
			using(DataSet detaliiDS = RunProcedure("PersoanaInIntretinereById", parameters, "Detalii"))
			{
				DetaliiPersoane detalii = new DetaliiPersoane();
				if (detaliiDS.Tables[0].Rows.Count > 0)
				{
					DataRow rowDetalii = detaliiDS.Tables[0].Rows[0];
					detalii.ID = id;
					detalii.AngajatID = (int)rowDetalii["AngajatID"];
					detalii.TipID =(int)rowDetalii["TipID"];
					detalii.CNP=(long)rowDetalii["CNP"];
					detalii.InvaliditateID=(int)rowDetalii["InvaliditateID"];
					detalii.Activ = (bool)rowDetalii["Activ"];
				}
				else
					detalii.ID = -1;

				return detalii;
			}
		}
		#endregion

		#region GetAllTipuriPersoaneInIntretinere
		/// <summary>
		/// Procedura returneaza toate tipurile de persoane in intretinere
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet GetAllTipuriPersoaneInIntretinere()
		{		
			SqlParameter[] parameters = {};
			return RunProcedure("spGetAllTipuriPersoaneInIntretinere", parameters, "GetAllTipuriPersoaneInIntretinere");
		}
		#endregion

		#region CheckIfPersoanaIntretinereCanBeAdded
		/// <summary>
		/// Procedura verifica daca o persoana poate fi adaugata/modificata astfel incat sa nu se creeze duplicate 
		/// </summary>
		/// <param name="persoanaId">Id-ul persoanei pentru care se face verificarea</param>
		/// <param name="cnp">CNP-ul care se verifica sa nu mai existe deja</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		/// <remarks>
		/// Adaugat:	Oprescu Claudia
		/// Data:		08.02.2007
		/// </remarks>
		public bool CheckIfPersoanaIntretinereCanBeAdded(int persoanaId, long cnp)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@PersoanaID", SqlDbType.Int, 4),
					new SqlParameter("@CNP", SqlDbType.BigInt, 8),
					new SqlParameter("@NrPersoane", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = persoanaId;
			parameters[ 1 ].Value = cnp;	
			parameters[ 2 ].Value = 0;
			parameters[ 2 ].Direction = ParameterDirection.ReturnValue;
			
			RunProcedure("spCheckIfPersoanaIntretinereCanBeAdded", parameters);
			return int.Parse(parameters[2].Value.ToString()) == 0;
		}
		#endregion
	}
}
