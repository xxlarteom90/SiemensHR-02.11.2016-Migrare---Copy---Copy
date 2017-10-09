using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{

	public struct Boala
	{
		public int BoalaId;
		public string CodBoala;
		public string CategorieBoala;
		public float Procent;
		public bool Stagiu;
	}

	/// <summary>
	/// Summary description for NomenclatorBoli.
	/// </summary>
	public class NomenclatorBoli : Salaries.Data.DbObject
	{
		#region Constructor
		public NomenclatorBoli( string connectionString ) : base( connectionString )
		{
		}
		#endregion

		#region InsertBoli
		/// <summary>
		/// Procedura adauga o boala
		/// </summary>
		/// <param name="procent">Procentul platit</param>
		/// <param name="cod">Codul bolii</param>
		/// <param name="categorie">Categoria bolii</param>
		/// <param name="stagiu">Presupune stagiu sau nu</param>
		/// <returns>Returneaza true daca a fost adaugata si false altfel</returns>
		public bool InsertBoli(float procent,string cod,string categorie,bool stagiu)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@CodBoala", SqlDbType.NVarChar, 2),
					new SqlParameter("@CategorieBoala", SqlDbType.NVarChar, 150),
					new SqlParameter("@Procent", SqlDbType.Real, 5),
					new SqlParameter("@Stagiu", SqlDbType.VarChar, 2),
					new SqlParameter("@BoalaID", SqlDbType.Int, 4),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = cod;
			parameters[ 1 ].Value = categorie;
			parameters[ 2 ].Value = procent;
			parameters[ 3 ].Value = stagiu ? "da" : "nu"; 
			parameters[ 4 ].Value = -1;
			parameters[ 5 ].Value = 0; //insert
			RunProcedure("InsertUpdateDeleteBoala", parameters, out numAffected);
			return (numAffected > 0);
		}
		#endregion

		#region InsertBoala
		/// <summary>
		/// Procedura adauga o boala
		/// </summary>
		/// <param name="boala">Obiectul care contine datele bolii</param>
		/// <returns>Returneaza true daca a fost facuta adaugarea si false altfel</returns>
		public bool InsertBoala( Boala boala ) 
		{
			return this.InsertBoli( boala.Procent, boala.CodBoala, boala.CategorieBoala, boala.Stagiu );
		}
		#endregion

		#region UpdateBoli
		/// <summary>
		/// Procedura actualizeaza o boala
		/// </summary>
		/// <param name="boalaId">Id-ul bolii</param>
		/// <param name="procent">Procentul bolii</param>
		/// <param name="cod">Codul bolii</param>
		/// <param name="categorie">Categoria bolii</param>
		/// <param name="stagiu">Necesita stagiu sau nu</param>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool UpdateBoli(int boalaId,float procent,string cod,string categorie,	bool stagiu)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@BoalaID", SqlDbType.Int, 4),
					new SqlParameter("@CodBoala", SqlDbType.NVarChar, 2),
					new SqlParameter("@CategorieBoala", SqlDbType.NVarChar, 150),
					new SqlParameter("@Procent", SqlDbType.Real, 5),
					new SqlParameter("@Stagiu", SqlDbType.NVarChar, 2),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = boalaId;
			parameters[ 1 ].Value = cod;
			parameters[ 2 ].Value = categorie;
			parameters[ 3 ].Value = procent;
			parameters[ 4 ].Value = stagiu ? "da" : "nu";
			parameters[ 5 ].Value = 1; //update
			
			
			RunProcedure("InsertUpdateDeleteBoala", parameters, out numAffected);
			return (numAffected > 0);
		}
		#endregion
		
		#region UpdateBoala
		/// <summary>
		/// Procedura actualizeaza o boala
		/// </summary>
		/// <param name="boala">Obiectul care contine datele bolii</param>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool UpdateBoala( Boala boala )
		{
			return this.UpdateBoli( boala.BoalaId, boala.Procent, boala.CodBoala, boala.CategorieBoala, boala.Stagiu );
		}
		#endregion

		#region DeleteBoli
		/// <summary>
		/// Procedura sterge o boala
		/// </summary>
		/// <param name="boalaId">Id-ul bolii care se sterge</param>
		/// <returns>Returneaza true daca s-a facut stergerea si false altfel</returns>
		public bool DeleteBoli( int boalaId )
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@BoalaID", SqlDbType.Int, 4),
					new SqlParameter("@CodBoala", SqlDbType.NVarChar, 2),
					new SqlParameter("@CategorieBoala", SqlDbType.NVarChar, 150),
					new SqlParameter("@Procent", SqlDbType.Float, 5),
					new SqlParameter("@Stagiu", SqlDbType.NVarChar, 2),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = boalaId;
			parameters[ 1 ].Value = "";
			parameters[ 2 ].Value = "";
			parameters[ 3 ].Value = 0;
			parameters[ 4 ].Value = "";
			parameters[ 5 ].Value = 2; //delete
			
			
			RunProcedure("InsertUpdateDeleteBoala", parameters, out numAffected);
			return (numAffected > 0);
		}
		#endregion

		#region GetBoli
		/// <summary>
		/// Procedura selecteaza toate bolile
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetBoli()
		{			
			DataSet ds = RunProcedure( "spGetAllBoli", new SqlParameter[ 0 ], "Boli" );
			return ds;
		}
		#endregion

		#region GetBoli
		/// <summary>
		/// Procedura selecteaza o boala
		/// </summary>
		/// <param name="idBoala">Id-ul bolii selectate</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetBoli( string idBoala )
		{				
			SqlParameter[] parameters = 
				{
					new SqlParameter("@BoalaID", SqlDbType.Int, 4)
				};		
			parameters[ 0 ].Value = idBoala;
			return RunProcedure("spGetBoala", parameters, "Boli");
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza datele unei boli
		/// </summary>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public Boala GetDetalii()
		{
			DataSet detaliiCategorie = RunProcedure( "spGetAllBoli", new SqlParameter[ 0 ], "Boli" );

			using( detaliiCategorie )
			{
				Boala boala = new Boala();
				if( detaliiCategorie.Tables[ "Boli" ].Rows.Count > 0)
				{
					DataRow dr = detaliiCategorie.Tables[ "Boli" ].Rows[0];
					
					boala.BoalaId = int.Parse( dr[ "BoalaID" ].ToString());
					boala.CodBoala = dr[ "Cod" ].ToString();
					boala.CategorieBoala = dr[ "Categorie" ].ToString();
					boala.Procent = float.Parse( dr[ "Procent" ].ToString());
					boala.Stagiu = dr[ "Stagiu" ].ToString().Equals( "da" );
				}
				else
					boala.BoalaId = -1;

				return boala;
			}
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza datele unei boli
		/// </summary>
		/// <param name="idBoala">Id-ul bolii selectate</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public Boala GetDetalii( string idBoala )
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@BoalaID", SqlDbType.Int, 4)
				};		
			parameters[ 0 ].Value = idBoala;
			DataSet detaliiCategorie = RunProcedure("spGetBoala", parameters, "Boli");

			using( detaliiCategorie )
			{
				Boala boala = new Boala();
				if( detaliiCategorie.Tables[ "Boli" ].Rows.Count > 0)
				{
					DataRow dr = detaliiCategorie.Tables[ "Boli" ].Rows[0];
					
					boala.BoalaId = int.Parse( dr[ "BoalaID" ].ToString());
					boala.CodBoala = dr[ "Cod" ].ToString();
					boala.CategorieBoala = dr[ "Categorie" ].ToString();
					boala.Procent = float.Parse( dr[ "Procent" ].ToString());
					boala.Stagiu = dr[ "Stagiu" ].ToString().Equals( "da" );
				}
				else
					boala.BoalaId = -1;

				return boala;
			}
		}
		#endregion

		#region CheckIfBoalaCanBeAdded
		/// <summary>
		/// Procedura verifica daca mai exista deja o boala cu exact aceleasi date. 
		/// </summary>
		/// <param name="boalaId">id-ul pentru boala</param>
		/// <param name="cod">codul pentru boala</param>
		/// <param name="categorie">categoria din care face parte boala</param>
		/// <param name="procent">procentrul pentru boala</param>
		/// <param name="stagiu">stagiu pentru boala</param>
		/// <returns>Este returnat true daca mai exista deja o boala si false daca nu mai exista deja o boala cu aceleasi date</returns>
		public bool CheckIfBoalaCanBeAdded(int boalaId, string cod, string categorie, float procent, string stagiu)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@BoalaID", SqlDbType.Int, 4),
					new SqlParameter("@CodBoala", SqlDbType.NVarChar, 2),
					new SqlParameter("@CategorieBoala", SqlDbType.NVarChar, 150),
					new SqlParameter("@Procent", SqlDbType.Float, 5),
					new SqlParameter("@Stagiu", SqlDbType.NVarChar, 2),
					new SqlParameter("@NrBoli", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = boalaId;
			parameters[ 1 ].Value = cod;
			parameters[ 2 ].Value = categorie;
			parameters[ 3 ].Value = procent;
			parameters[ 4 ].Value = stagiu;	
			parameters[ 5 ].Value = 0;
			parameters[ 5 ].Direction = ParameterDirection.ReturnValue;
			
			RunProcedure("spCheckIfBoalaCanBeAdded", parameters);
			return int.Parse(parameters[5].Value.ToString()) == 0;
		}
		#endregion

		#region CheckIfBoalaCanBeDeleted
		/// <summary>
		/// Procedura verifica daca o boala poate fi stearsa. Nu se poate sterge o boala pentru care exista concedii medicale atasate.
		/// </summary>
		/// <param name="boalaId">Id-ul bolii care se sterge</param>
		/// <returns>Returneaza true daca se poate face stergerea si false altfel</returns>
		public int CheckIfBoalaCanBeDeleted(int boalaId)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@BoalaID", SqlDbType.Int, 4)
					, new SqlParameter("@sePoateSterge", SqlDbType.Int, 4)
				};
			parameters[0].Value = boalaId;
			parameters[1].Direction = ParameterDirection.Output;
			
			RunProcedure("spCheckIfBoalaCanBeDeleted", parameters);
			return int.Parse(parameters[1].Value.ToString());
		}

		#endregion
	}
}
