using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for Luni.
	/// </summary>
	public struct LunaData
	{	
		//Data de inceput a lunii
		public DateTime Data;
		//Id-ul lunii
		public int LunaId;
		//Luna este activa sau nu
		public bool Activ;
		//Procentul de inflatie al lunii
		public float ProcentInflatie;
		//Id-ul angajatorului
		public int AngajatorId;
	}

	public class Luni : Salaries.Data.DbObject
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="connectionString">String-ul de conexiune la baza de date</param>
		public Luni(string connectionString): base (connectionString){}
		#endregion

		#region InsertLuna
		/// <summary>
		/// Procedura adauga o noua luna
		/// </summary>
		/// <param name="data">Data de inceput</param>
		/// <param name="activ">Luna este activa sau nu</param>
		/// <param name="procentInflatie">Procentul de inflatie</param>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza rezultatul adaugarii</returns>
		public int InsertLuna(DateTime data, bool activ, float procentInflatie, int angajatorId)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@ProcentInflatie", SqlDbType.Float, 8),
					new SqlParameter("@Activ", SqlDbType.Bit, 1),
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
					new SqlParameter("@rc", SqlDbType.Int, 4),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)
				};
			
			parameters[0].Value = -1;
			parameters[1].Value = data;
			parameters[2].Value = procentInflatie;
			parameters[3].Value = activ;
			parameters[4].Value = angajatorId;
			parameters[5].Direction = ParameterDirection.Output;
			parameters[6].Value = 0;

			RunProcedure("sal_InsertUpdateDeleteLuna", parameters, out numAffected);

			return (int)parameters[5].Value;
		}
		#endregion
	
		#region InsertLuna
		/// <summary>
		/// Procedura adauga o luna
		/// </summary>
		/// <param name="lunaData">Obiectul care se adauga</param>
		/// <returns>Returneaza rezultatul adaugarii</returns>
		public int InsertLuna(LunaData lunaData)
		{
			return this.InsertLuna(lunaData.Data, lunaData.Activ, lunaData.ProcentInflatie, lunaData.AngajatorId);
		}
		#endregion

		#region UpdateLuna
		/// <summary>
		/// Procedura actualizeaza o luna
		/// </summary>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <param name="data">Data de inceput a lunii</param>
		/// <param name="activ">Luna este activa sau nu</param>
		/// <param name="procentInflatie">Procentul de inflatie</param>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza rezultatul actualizarii</returns>
		public int UpdateLuna(int lunaId, DateTime data, bool activ, float procentInflatie, int angajatorId)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{	new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@ProcentInflatie", SqlDbType.Float, 8),
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
					new SqlParameter("@Activ", SqlDbType.Bit, 1),
					new SqlParameter("@rc", SqlDbType.Int, 4),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)								
				};
			
			parameters[0].Value = lunaId;
			parameters[1].Value = data;
			parameters[2].Value = procentInflatie;
			parameters[3].Value = angajatorId;
			parameters[4].Value = activ;
			parameters[5].Direction = ParameterDirection.Output;
			parameters[6].Value = 1;

			RunProcedure("sal_InsertUpdateDeleteLuna", parameters, out numAffected);

			return (int)parameters[5].Value;
		}
		#endregion

		#region UpdateLuna
		/// <summary>
		/// Procedura actualizeaza o luna
		/// </summary>
		/// <param name="lunaData">Obiectul care contine luna care se va actualiza</param>
		/// <returns>Returneaza rezultatul adaugarii</returns>
		public int UpdateLuna(LunaData lunaData)
		{
			return this.UpdateLuna(lunaData.LunaId, lunaData.Data, lunaData.Activ, lunaData.ProcentInflatie, lunaData.AngajatorId);
		}
		#endregion

		#region DeleteLuna
		/// <summary>
		/// Procedura sterge o luna
		/// </summary>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza rezultatul stergerii</returns>
		public int DeleteLuna(int lunaId)
		{
			int numAffected;
		
			SqlParameter[] parameters = 
				{		
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@Data", SqlDbType.DateTime, 8),
					new SqlParameter("@ProcentInflatie", SqlDbType.Float, 8),
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4),
					new SqlParameter("@Activ", SqlDbType.Bit, 1),
					new SqlParameter("@rc", SqlDbType.Int, 4),
					new SqlParameter("@tip_actiune", SqlDbType.Int, 4)		
				};
			
			parameters[0].Value = lunaId;
			parameters[1].Value = DateTime.Now;
			parameters[2].Value = 0;
			parameters[3].Value = 0;
			parameters[4].Value = 0;
			parameters[5].Direction = ParameterDirection.Output;
			parameters[6].Value = 2;

			RunProcedure("sal_InsertUpdateDeleteLuna", parameters, out numAffected);

			return (int)parameters[5].Value;
		}
		#endregion

		#region DeleteLuna
		/// <summary>
		/// Procedura sterge o luna
		/// </summary>
		/// <param name="lunaData">Obiectul care contine datele lunii care se sterge</param>
		/// <returns>Returneaza rezultatul stergerii</returns>
		public int DeleteLuna(LunaData lunaData)
		{
			return this.DeleteLuna(lunaData.LunaId);
		}
		#endregion

		#region GetLunaActiva
		/// <summary>
		/// Procedura selecteaza luna activa
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza un obiect care contine datele lunii active</returns>
		public LunaData GetLunaActiva(int angajatorId)
		{	
			SqlParameter[] parameters = {new SqlParameter("@AngajatorID", SqlDbType.Int, 4)};

			parameters[0].Value = angajatorId;

			using(DataSet detaliiLunaActiva = RunProcedure("sal_GetLunaActiva", parameters , "InfoLuna"))
			{
				LunaData lunaData = new LunaData();

				if (detaliiLunaActiva.Tables["InfoLuna"].Rows.Count > 0)
				{
					DataRow rowDetalii = detaliiLunaActiva.Tables["InfoLuna"].Rows[0];

					lunaData.AngajatorId = angajatorId;
					lunaData.LunaId = (int)rowDetalii["LunaID"];
					lunaData.Data = (DateTime)rowDetalii["Data"];
					lunaData.ProcentInflatie = float.Parse(rowDetalii["ProcentInflatie"].ToString());			
					lunaData.Activ = (bool) rowDetalii["Activ"];				
				}
				else
					lunaData.LunaId = -1;

				return lunaData;
			}						
		}
		#endregion

		#region GetLunaActiva
		/// <summary>
		/// Procedura selecteaza luna activa
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine datele lunii active</returns>
		public DataSet GetLunaActivaDataSet(int angajatorId)
		{	
			SqlParameter[] parameters = {new SqlParameter("@AngajatorID", SqlDbType.Int, 4)};
			parameters[0].Value = angajatorId;
			return RunProcedure("sal_GetLunaActiva", parameters , "InfoLuna");					
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza detaliile unei luni
		/// </summary>
		/// <param name="id">Id-ul lunii</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public LunaData GetDetalii(int id)
		{
			
			SqlParameter[] parameters = {new SqlParameter("@LunaID", SqlDbType.Int, 4)};

			parameters[0].Value = id;

			using(DataSet detaliiLunaActiva = RunProcedure("sal_GetLunaInflById", parameters , "InfoLunaById"))
			{
				LunaData lunaData = new LunaData();

				if (detaliiLunaActiva.Tables["InfoLunaById"].Rows.Count > 0)
				{
					DataRow rowDetalii = detaliiLunaActiva.Tables["InfoLunaById"].Rows[0];

					lunaData.AngajatorId = (int)rowDetalii["AngajatorID"];
					lunaData.LunaId = (int)rowDetalii["LunaID"];
					lunaData.Data = (DateTime)rowDetalii["Data"];
					lunaData.ProcentInflatie = float.Parse(rowDetalii["ProcentInflatie"].ToString());			
					lunaData.Activ = (bool) rowDetalii["Activ"];			
				}
				else
					lunaData.LunaId = -1;

				return lunaData;
			}
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza datele unei luni
		/// </summary>
		/// <param name="data">Data de inceput a lunii</param>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza un obiect care contine datele lunii</returns>
		public LunaData GetDetalii( DateTime data, int angajatorId )
		{
			SqlParameter[] parameters = 
				{
					new SqlParameter("@DataCurenta", SqlDbType.DateTime, 8),
					new SqlParameter("@AngajatorID", SqlDbType.Int, 4)
				};

			parameters[0].Value = data;
			parameters[1].Value = angajatorId;

			using(DataSet detaliiLunaActiva = RunProcedure("GetLunaDetaliiByData", parameters , "InfoLunaByData"))
			{
				LunaData lunaData = new LunaData();

				if (detaliiLunaActiva.Tables["InfoLunaByData"].Rows.Count > 0)
				{
					DataRow rowDetalii = detaliiLunaActiva.Tables["InfoLunaByData"].Rows[0];

					lunaData.AngajatorId = (int)rowDetalii["AngajatorID"];
					lunaData.LunaId = (int)rowDetalii["LunaID"];
					lunaData.Data = (DateTime)rowDetalii["Data"];
					lunaData.ProcentInflatie = float.Parse(rowDetalii["ProcentInflatie"].ToString());			
					lunaData.Activ = (bool) rowDetalii["Activ"];			
				}
				else
					lunaData.LunaId = -1;

				return lunaData;
			}
		}
		#endregion

		#region GetLuni
		/// <summary>
		/// Procedura selecteaza lunile unui angajator
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetLuni(int angajatorId)
		{			
			SqlParameter[] parameters = {new SqlParameter("@AngajatorID", SqlDbType.Int, 4)};

			parameters[0].Value = angajatorId;

			using(DataSet detaliiLuni = RunProcedure("sal_GetLuni", parameters , "Luni"))
			{				
				return detaliiLuni;
			}						
		}
		#endregion

		#region CopySetariSalarii_Luna
		/// <summary>
		/// Procedura copiaza setarile lunii anterioare
		/// </summary>
		/// <param name="lunaVeche">Luna anterioara</param>
		/// <param name="lunaNoua">Luna curenta</param>
		public void CopySetariSalarii_Luna(int lunaVeche, int lunaNoua)
		{
			SqlParameter[] parameters = 
			{
					new SqlParameter("@LunaOld", SqlDbType.Int, 4),
					new SqlParameter("@LunaNew", SqlDbType.Int, 4),
			};
			
			parameters[0].Value = lunaVeche;
			parameters[1].Value = lunaNoua;
			
			RunProcedure("sal_CopySetariSalarii_LunaActiva2", parameters);
		}
		#endregion

		#region FillZileLuna
		/// <summary>
		/// Procedura completeaza zilele unei luni
		/// </summary>
		/// <param name="luna">Luna pentru care se completeaza</param>
		/// <param name="an">Anul pentru care se completeaza</param>
		/// <returns>Returneaza un intreg care reprezinta nr inregistrarilor afectate</returns>
		public int FillZileLuna( int luna, int an )
		{
			try
			{
				int numAffected = 0;

				for( int i=1; i<=DateTime.DaysInMonth( an, luna ); i++ )
				{
					SqlParameter []parameters = 
					{
						new SqlParameter( "@Data", SqlDbType.DateTime, 8 ),
						new SqlParameter( "@Sarbatoare", SqlDbType.Bit, 1 ),
						new SqlParameter( "@Denumire", SqlDbType.NVarChar, 255 ),
						new SqlParameter( "@Descriere", SqlDbType.NText, 16 ),
						new SqlParameter( "@SetataAdmin", SqlDbType.Bit, 1 ),
						new SqlParameter( "@tip_actiune", SqlDbType.Int, 4 )
					};

					DateTime dt = new DateTime( an, luna, i );
					parameters[ 0 ].Value = dt;
					parameters[ 1 ].Value = ( dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday || ExistaSarbatoareZi( dt )) ? true : false;
					parameters[ 2 ].Value = dt.DayOfWeek.ToString();
					parameters[ 3 ].Value = "";
					parameters[ 4 ].Value = false;
					parameters[ 5 ].Value = 0; //insert

					int numAff = 0;

					RunProcedure( "tm_InsertUpdateDeleteZi", parameters, out numAff );

					numAffected += numAff;
				}
				return numAffected;
			}
			catch( Exception exc)
			{
				string a  = exc.Message;
				return -1;
			}
		}
		#endregion
		
		#region ExistaSarbatoareZi
		/// <summary>
		/// Procedura verifica daca o data este zi de sarbatoare
		/// </summary>
		/// <param name="data">Data verificata</param>
		/// <returns>Returneaza true daca este sarbatoare si false altfel</returns>
		private bool ExistaSarbatoareZi(DateTime data)
		{
			try
			{
				SqlParameter []parameters = 
				{
					new SqlParameter( "@Data", SqlDbType.DateTime, 8 )
				};

				parameters[ 0 ].Value = data;
				
				DataSet ds = RunProcedure( "tm_EsteZiSarbatoare", parameters, "Sarbatoare" );

				if( ds.Tables[ "Sarbatoare" ].Rows.Count == 0 )
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			catch
			{
				return false;
			}
		}
		#endregion

		#region GetAniSal_Salarii
		/// <summary>
		/// Returneaza anii pentru care sunt calculate salariile in baza de date.
		/// </summary>
		/// <returns> Anii pentru care sunt calculate salariile in baza de date.</returns>
		/// <remarks>
		/// Autor: Muntean Raluca Cristina
		/// </remarks>
		public DataSet GetAniSal_Salarii()
		{
			//declarare parametrii
			SqlParameter[] parameters ={};

			//executie procedura stocata
			DataSet dsAni = RunProcedure("GetAniSal_Salarii",parameters,"Ani");

			return dsAni;
		}
		#endregion
		
		#region GetLuniSal_Salarii
		/// <summary>
		/// Returneaza lunile din anul dat ca parametru pentru care sunt calculate salariile.
		/// </summary>
		/// <param name="an"> Anul pentru care se doreste aflarea lunilor pentru care sun calculate salariile.</param>
		/// <returns> Lunile din anul dat ca parametru pentru care sunt calculate salariile.</returns>
		public DataSet GetLuniSal_Salarii(int an)
		{
			//declarare parametrii
			SqlParameter[] parameters =
				{
					new SqlParameter("@An", SqlDbType.Int,4)
				};

			//setare pamametrii
			parameters[0].Value=an;

			//executie procedura stocata
			DataSet dsLuni = RunProcedure("GetLuni_An",parameters,"Luni");

			return dsLuni;
		}
		#endregion

		#region GetLuniSal_Luni
		/// <summary>
		/// Returneaza lunile din anul dat ca parametru 
		/// </summary>
		/// <param name="an">Anul specificat</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetLuniSal_Luni(int an,int angajatorID)
		{
			//declarare parametrii
			SqlParameter[] parameters =
				{
					new SqlParameter("@An", SqlDbType.Int,4),
					new SqlParameter("@AngajatorID", SqlDbType.Int,4)
				};
			//setare pamametrii
			parameters[0].Value=an;
			parameters[1].Value=angajatorID;

			//executie procedura stocata
			DataSet dsLuni = RunProcedure("GetAllLuni_An",parameters,"Luni");

			return dsLuni;
		}
		#endregion

		#region GetLunaPrecedenta
		/// <summary>
		/// Procedura selecteaza datele pt luna precedenta
		/// </summary>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza nr de inregistrari afectate</returns>
		public int GetLunaPrecedenta( int lunaID, int angajatorID )
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@LunaID", SqlDbType.Int,4),
					new SqlParameter("@AngajatorID", SqlDbType.Int,4),
					new SqlParameter("@ReturnValue", SqlDbType.Int,4)
				};
			//setare pamametrii
			parameters[ 0 ].Value = lunaID;
			parameters[ 1 ].Value = angajatorID;
			parameters[ 2 ].Direction = ParameterDirection.Output;

			//executie procedura stocata
			int rowsAffected = 0;
			return RunProcedure("GetLunaPrecedenta",parameters,out rowsAffected);
		}
		#endregion

		#region RedeschidereLunaPrecedenta
		/// <summary>
		/// Redeschide luna precedenta lunii active.
		/// </summary>
		/// <returns> Returneaza 0 in cazul in care redeschiderea s-a realizat cu succes si
		/// o valoare diferita de 0, altfel.</returns>
		/// <remarks> 
		/// Autor: Cristina Muntean
		/// Data:  13.12.2006
		/// </remarks>
		public int RedeschidereLunaPrecedenta()
		{
			SqlParameter[] parameters = {
										new SqlParameter("@rc", SqlDbType.Int, 4),
										};

			parameters[0].Direction = ParameterDirection.Output;
			
			RunProcedure("spRedeschidereLunaPrecedenta", parameters);

			return int.Parse(parameters[0].Value.ToString());
		}	
		#endregion

		#region ExistaZilePentruLunaActiva
		/// <summary>
		/// Verificam daca exista zile pt luna activa in table tm_zile
		/// </summary>
		/// <param name="lunaId">Id-ul lunii</param>
		/// <returns>Returneaza un DataSet care contine zilele lunii active</returns>
		public DataSet ExistaZilePentruLunaActiva(int lunaId)
		{	
			SqlParameter[] parameters = {
											new SqlParameter("@LunaID", SqlDbType.Int, 4)
										};
			parameters[0].Value = lunaId;
			return RunProcedure("spExistaZilePentruLunaActiva", parameters , "ExistaZilePentruLunaActiva");					
		}
		#endregion
	}
}
