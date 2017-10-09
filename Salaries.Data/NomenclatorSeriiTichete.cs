using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Data
{

	public struct SeriiTichete
	{
		public int SerieId;
		public long SerieInceput;
		public long SerieSfarsit;
		public int LunaID;
		public int PunctLucruID;
	}

	/// <summary>
	/// Summary description for NomenclatorSeriiTichete.
	/// </summary>
	public class NomenclatorSeriiTichete : Salaries.Data.DbObject
	{
		#region Constructor
		public NomenclatorSeriiTichete( string connectionString ) : base( connectionString )
		{
		}
		#endregion

		#region InsertSerii
		/// <summary>
		/// Procedura adauga un interval de serii
		/// </summary>
		/// <param name="serieID">id-ul seriei</param>
		/// <param name="serieInceput">nr seriei de inceput</param>
		/// <param name="serieSfarsit">nr seriei de sfarsit</param>
		/// <param name="lunaID">luna pentru care se considera seriile</param>
		/// <returns>Returneaza true daca a fost adaugata si false altfel</returns>
		public bool InsertSerii(int serieID, long serieInceput, long serieSfarsit, long lunaID, int punctLucruID)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@SerieID", SqlDbType.Int, 4),
					new SqlParameter("@SerieInceput", SqlDbType.BigInt, 8),
					new SqlParameter("@SerieSfarsit", SqlDbType.BigInt, 8),
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@PunctLucruID", SqlDbType.Int, 4),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = serieID;
			parameters[ 1 ].Value = serieInceput;
			parameters[ 2 ].Value = serieSfarsit;
			parameters[ 3 ].Value = lunaID;
			parameters[ 4 ].Value = punctLucruID;
			parameters[ 5 ].Value = 0; //insert
			RunProcedure("InsertUpdateDeleteSeriiTichete", parameters, out numAffected);
			return (numAffected > 0);
		}
		#endregion

		#region InsertSerii
		/// <summary>
		/// Procedura adauga un interval de serii
		/// </summary>
		/// <param name="boala">Obiectul care contine datele intervalului de serii</param>
		/// <returns>Returneaza true daca a fost facuta adaugarea si false altfel</returns>
		public bool InsertSerii( SeriiTichete serii ) 
		{
			return this.InsertSerii( serii.SerieId, serii.SerieInceput, serii.SerieSfarsit, serii.LunaID, serii.PunctLucruID );
		}
		#endregion

		#region UpdateSerii
		/// <summary>
		/// Procedura actualizeaza o boala
		/// </summary>
		/// <param name="serieID">id-ul seriei</param>
		/// <param name="serieInceput">nr seriei de inceput</param>
		/// <param name="serieSfarsit">nr seriei de sfarsit</param>
		/// <param name="lunaID">luna pentru care se considera seriile</param>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool UpdateSerii(int serieID, long serieInceput, long serieSfarsit, long lunaID, int punctLucruID)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@SerieID", SqlDbType.Int, 4),
					new SqlParameter("@SerieInceput", SqlDbType.BigInt, 8),
					new SqlParameter("@SerieSfarsit", SqlDbType.BigInt, 8),
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@PunctLucruID", SqlDbType.Int, 4),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = serieID;
			parameters[ 1 ].Value = serieInceput;
			parameters[ 2 ].Value = serieSfarsit;
			parameters[ 3 ].Value = lunaID;
			parameters[ 4 ].Value = punctLucruID;
			parameters[ 5 ].Value = 1; //update
			RunProcedure("InsertUpdateDeleteSeriiTichete", parameters, out numAffected);
			return (numAffected > 0);
		}
		#endregion
		
		#region UpdateSerii
		/// <summary>
		/// Procedura actualizeaza un interval de serii
		/// </summary>
		/// <param name="boala">Obiectul care contine datele intervalului de serii</param>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool UpdateSerii( SeriiTichete serii )
		{
			return this.UpdateSerii( serii.SerieId, serii.SerieInceput, serii.SerieSfarsit, serii.LunaID, serii.PunctLucruID );
		}
		#endregion

		#region DeleteSerii
		/// <summary>
		/// Procedura sterge un interval de serii
		/// </summary>
		/// <param name="serieId">Id-ul intervalului de serii</param>
		/// <returns>Returneaza true daca s-a facut stergerea si false altfel</returns>
		public bool DeleteSerii( int serieId )
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@SerieID", SqlDbType.Int, 4),
					new SqlParameter("@SerieInceput", SqlDbType.BigInt, 8),
					new SqlParameter("@SerieSfarsit", SqlDbType.BigInt, 8),
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@PunctLucruID", SqlDbType.Int, 4),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = serieId;
			parameters[ 1 ].Value = -1;
			parameters[ 2 ].Value = -1;
			parameters[ 3 ].Value = -1;
			parameters[ 4 ].Value = -1;
			parameters[ 5 ].Value = 2; //delete
			RunProcedure("InsertUpdateDeleteSeriiTichete", parameters, out numAffected);
			return (numAffected > 0);
		}
		#endregion

		#region GetSeriiTichete
		/// <summary>
		/// Procedura selecteaza toate intervalele de serii
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetSeriiTichete()
		{			
			DataSet ds = RunProcedure( "spGetAllSeriiTichete", new SqlParameter[ 0 ], "SeriiTichete" );
			return ds;
		}
		#endregion

		#region GetSeriiTichete
		/// <summary>
		/// Procedura selecteaza un interval de serii
		/// </summary>
		/// <param name="idBoala">Id-ulintervalului de serii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetSeriiTichete( int  serieID)
		{				
			SqlParameter[] parameters = 
				{
					new SqlParameter("@SerieID", SqlDbType.Int, 4)
				};		
			parameters[ 0 ].Value = serieID;
			return RunProcedure("spGetSeriiTichete", parameters, "SeriiTichete");
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza datele unui interval de serii
		/// </summary>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public SeriiTichete GetDetalii()
		{
			DataSet detalii = RunProcedure( "spGetAllSeriiTichete", new SqlParameter[ 0 ], "SeriiTichete" );

			using( detalii )
			{
				SeriiTichete serii = new SeriiTichete();
				if( detalii.Tables[ "SeriiTichete" ].Rows.Count > 0)
				{
					DataRow dr = detalii.Tables[ "SeriiTichete" ].Rows[0];
					
					serii.SerieId = int.Parse( dr[ "SerieID" ].ToString());
					serii.SerieInceput = long.Parse( dr[ "SerieInceput" ].ToString());
					serii.SerieSfarsit = long.Parse( dr[ "SerieSfarsit" ].ToString());
					serii.LunaID = int.Parse( dr[ "LunaID" ].ToString());
					serii.PunctLucruID = int.Parse( dr["PunctLucruID"].ToString());
				}
				else
					serii.SerieId = -1;

				return serii;
			}
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza datele unui interval
		/// </summary>
		/// <param name="serieId">Id-ul seriei</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public SeriiTichete GetDetalii( int serieId)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@SerieID", SqlDbType.Int, 4)
				};		
			parameters[ 0 ].Value = serieId;
			DataSet detalii = RunProcedure("spGetSeriiTichete", parameters, "SeriiTichete");

			using( detalii )
			{
				SeriiTichete serii = new SeriiTichete();
				if( detalii.Tables[ "SeriiTichete" ].Rows.Count > 0)
				{
					DataRow dr = detalii.Tables[ "SeriiTichete" ].Rows[0];
					
					serii.SerieId = int.Parse( dr[ "SerieID" ].ToString());
					serii.SerieInceput = long.Parse( dr[ "SerieInceput" ].ToString());
					serii.SerieSfarsit = long.Parse( dr[ "SerieSfarsit" ].ToString());
					serii.LunaID = int.Parse( dr[ "LunaID" ].ToString());
					serii.PunctLucruID = int.Parse( dr["PunctLucruID"].ToString());
				}
				else
					serii.SerieId = -1;

				return serii;
			}
		}
		#endregion

		#region CheckIfSeriiTicheteCanBeAdded
		/// <summary>
		/// Procedura verifica daca mai exista deja un interval de serii cu exact aceleasi date. 
		/// </summary>
		/// <param name="serieID">id-ul seriei</param>
		/// <param name="serieInceput">nr seriei de inceput</param>
		/// <param name="serieSfarsit">nr seriei de sfarsit</param>
		/// <param name="lunaID">luna pentru care se considera seriile</param>
		/// <returns>Este returnat true daca mai exista deja un interval de serii si false daca nu mai exista deja un interval de serii cu aceleasi date</returns>
		public bool CheckIfSeriiTicheteCanBeAdded(int serieID, long serieInceput, long serieSfarsit, long lunaID, int punctLucruID)
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@SerieID", SqlDbType.Int, 4),
					new SqlParameter("@SerieInceput", SqlDbType.BigInt, 8),
					new SqlParameter("@SerieSfarsit", SqlDbType.BigInt, 8),
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@PunctLucruID", SqlDbType.Int, 4),
					new SqlParameter("@NrSerii", SqlDbType.Int, 4)
				};
			
			parameters[ 0 ].Value = serieID;
			parameters[ 1 ].Value = serieInceput;
			parameters[ 2 ].Value = serieSfarsit;
			parameters[ 3 ].Value = lunaID;
			parameters[ 4 ].Value = punctLucruID;
			parameters[ 5 ].Value = 0;
			parameters[ 5 ].Direction = ParameterDirection.Output;
						
			RunProcedure("spCheckIfSeriiTicheteCanBeAdded", parameters);
			return int.Parse(parameters[5].Value.ToString()) == 0;
		}
		#endregion

		#region CheckIfSeriiTicheteCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un interval de serii poate fi sters. Nu se poate sterge un interval de serii dintr-o luna precedenta.
		/// </summary>
		/// <param name="boalaId">Id-ul intervalului de serii care se sterge</param>
		/// <returns>Returneaza true daca se poate face stergerea si false altfel</returns>
		public int CheckIfSeriiTicheteCanBeDeleted(int serieId)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@SerieID", SqlDbType.Int, 4),
					new SqlParameter("@sePoateSterge", SqlDbType.Int, 4)
				};
			parameters[0].Value = serieId;
			parameters[1].Direction = ParameterDirection.Output;
			
			RunProcedure("spCheckIfSeriiTicheteCanBeDeleted", parameters);
			return int.Parse(parameters[1].Value.ToString());
		}

		#endregion
	}
}
