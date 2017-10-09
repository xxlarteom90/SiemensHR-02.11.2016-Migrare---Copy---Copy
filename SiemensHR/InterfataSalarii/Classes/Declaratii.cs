//Autor: Muntean Raluca Cristina
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace SiemensHR.InterfataSalarii.Classes
{
	/// <summary>
	/// Summary description for Declaratii.
	/// </summary>
	public class Declaratii: Salaries.Data.DbObject
	{
		//proprietati
		private string path;

		#region Proprietati
		
		public string Path
		{
			get
			{
				return path;
			}
			set
			{
				this.path=value;
			}
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="newConnectionString"></param>
		public Declaratii(string newConnectionString): base (newConnectionString)
		{}
		#endregion
		
		#region Verificare existenta stat de plata pentru luna data ca parametru
		/// <summary>
		/// Verifica daca exista stat de plata pentru luna curenta
		/// </summary>
		/// <param name="LunaID">Id-ul lunii</param>
		/// <param name="AngajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza true daca exista statul de plata si false altfel</returns>
		public bool StatDePlataExists(int LunaID,int AngajatorID)
		{
			Salaries.Business.Salariu sal=new Salaries.Business.Salariu();
			DataSet dsStatPlata=sal.StatPlata(LunaID,AngajatorID);
			
			//daca nu exista stat de plata returneaza false
			if(dsStatPlata.Tables[0].Rows.Count==0)
				return false;
			return true;
		}
		#endregion 
		
		#region Completare data set-uri folosind proceduri stocate 
		#region FillDataSetA11SP
		/// <summary>
		/// Completare data set folosind proceduri stocate - anexa 1.1
		/// declaratie initiala privind evidenta nominala a asiguratilor 
		/// si a obligatiilor de plata catre bugetul asigurarilor sociale de stat
		/// </summary>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet FillDataSetA11SP(int lunaID, int angajatorID)
		{
			//declarare parametrii
			SqlParameter[] parameters =
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatorID", SqlDbType.Int,4)
				};
			
			//setare parametrii
			parameters[0].Value = lunaID;
			parameters[1].Value = angajatorID;
			
			//executie procedura stocata
			DataSet dsA11 = RunProcedure("GetA11", parameters, "A11");

			return dsA11;
		}
		#endregion
		
		#region FillDataSetA12SP
		/// <summary>
		/// Completare data set folosind proceduri stocate - Bass -anexa 1.2
		/// declaratia initiala privind evidenta nominala a asiguratilor si a
		/// obligatiilor de plata catre bugetul asigurarilor sociale de stat
		/// </summary>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet FillDataSetA12SP(int lunaID, int angajatorID)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatorID", SqlDbType.Int,4)
				};
			parameters[0].Value = lunaID;
			parameters[1].Value = angajatorID;

			DataSet dsA12 = RunProcedure("GetA12", parameters, "A12");
			return dsA12;
		}
		#endregion
		
		#region FillDataSetA12_NRMSP
		/// <summary>
		/// Completare data set folosind proceduri stocate- BASS -anexa 1.2- numa mediu angajati
		/// </summary>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet FillDataSetA12_NRMSP(int lunaID, int angajatorID)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatorID", SqlDbType.Int,4)
				};
			parameters[0].Value = lunaID;
			parameters[1].Value = angajatorID;

			DataSet dsA12_NRM = RunProcedure("GetA12_NRM", parameters, "A12_NRM");
			return dsA12_NRM;
		}
		#endregion

		#region FillDataSetCap1SP
		/// <summary>
		/// Completare data set folosind proceduri stocate - somaj - capitolul 1
		/// declaratie privind evidenta nominala a asiguratilor sau obligatiilor
		/// de plata la bugetul asigurarilor pentru somaj
		/// </summary>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet FillDataSetCap1SP(int lunaID, int angajatorID)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatorID", SqlDbType.Int,4)
				};
			parameters[0].Value = lunaID;
			parameters[1].Value = angajatorID;

			DataSet dsCap1 = RunProcedure("GetCap1", parameters, "Cap1");
			return dsCap1;
		}
		#endregion

		#region FillDataSetCap2SP
		/// <summary>
		/// Completare data set folosind proceduri stocate - somaj -capitol 2
		/// date despre angajator; deduceri si reduceri
		/// </summary>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneza un DataSet care contine aceste date</returns>
		public DataSet FillDataSetCap2SP(int lunaID, int angajatorID)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@LunaID", SqlDbType.Int, 4),
					new SqlParameter("@AngajatorID", SqlDbType.Int,4)
				};
			parameters[0].Value = lunaID;
			parameters[1].Value = angajatorID;

			DataSet dsCap2 = RunProcedure("GetCap2", parameters, "Cap2");
			return dsCap2;
		}
		#endregion

		#region FillDataSetREP_aaaaSP
		/// <summary>
		/// Completare data set folosind proceduri stocate - fise fiscale-date de identificare angajator
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet FillDataSetREP_aaaaSP(int angajatorID)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@AngajatorID", SqlDbType.Int,4)
				};
			parameters[0].Value = angajatorID;

			DataSet dsREP_aaaa = RunProcedure("GetREP_aaaa", parameters, "REP_aaaa");
			return dsREP_aaaa;
		}
	
		#endregion

		#region FillDataSetFF1_aaaaSP
		/// <summary>
		/// Completare data set folosind proceduri stocate- fise fiscale -FF1:
		/// date de identificare angajati, total coeficienti de deducere, coeficienti de deducere
		/// pentru situatia proprie a angajatului, venit net, impozit retinut, impozit
		/// pe veniturile din salarii cu impunere finala, venit scutit,informatii privind operatiunile
		/// de regularizare efectuate
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <param name="an">Anul</param>
		/// <param name="lunaStart">Data de inceput a lunii</param>
		/// <param name="lunaStop">Data de sfarsit a lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet FillDataSetFF1_aaaaSP(int angajatID, int an, int lunaStart, int lunaStop)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@AngajatID", SqlDbType.Int,4),
					new SqlParameter("@An", SqlDbType.Int,4),
					new SqlParameter("@LunaStart", SqlDbType.Int,4),
					new SqlParameter("@LunaStop", SqlDbType.Int,4)
				};
			parameters[0].Value = angajatID;
			parameters[1].Value = an;
			parameters[2].Value = lunaStart;
			parameters[3].Value = lunaStop;

			DataSet dsFF1_aaaa = RunProcedure("GetFF1_aaaa", parameters, "FF1_aaaa");
			return dsFF1_aaaa;
		}

		#endregion

		#region FillDataSetDED_aaaaSP
		/// <summary>
		/// Completare data set folosind proceduri stocate - fise fiscale - 
		/// date de identificare persoana in intretinere,coeficienti de deducere
		/// suplimentara pentru persoanele aflate in intretinerea angajatilor
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet FillDataSetDED_aaaaSP(int angajatID)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@AngajatID", SqlDbType.Int,4)
				};
			parameters[0].Value = angajatID;

			DataSet dsDED_aaaa = RunProcedure("GetDED_aaaa", parameters, "DED_aaaa");
			return dsDED_aaaa;
		}

		#endregion
	
		#region FillDataSetFF2_aaaaSP
		/// <summary>
		/// Completare data set folosind proceduri stocate- fise fiscale - FF2
		/// date de identificare angajati, tip venit, venit baza de calcul, impozit retinut
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		/// <param name="an">Anul</param>
		/// <param name="lunaStart">Data de inceput a lunii</param>
		/// <param name="lunaStop">Data de sfarsit a lunii</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet FillDataSetFF2_aaaaSP(int angajatID, int an, int lunaStart, int lunaStop)
		{
			SqlParameter[] parameters =
				{
					new SqlParameter("@AngajatID", SqlDbType.Int,4),
					new SqlParameter("@An", SqlDbType.Int,4),
					new SqlParameter("@LunaStart", SqlDbType.Int,4),
					new SqlParameter("@LunaStop", SqlDbType.Int,4)
				};
			parameters[0].Value = angajatID;
			parameters[1].Value = an;
			parameters[2].Value = lunaStart;
			parameters[3].Value = lunaStop;

			DataSet dsFF2_aaaa = RunProcedure("GetFF2_aaaa", parameters, "FF2_aaaa");
			return dsFF2_aaaa;
		}
		#endregion
	
		#region FillDataSetAngajatiFF1SP
		/// <summary>
		/// Returneaza toti angajatii care au functia de baza la angajatorul dat ca parametru
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet FillDataSetAngajatiFF1SP( int angajatorID)
		{
			//declarare parametrii
			SqlParameter[] parameters =
				{
					new SqlParameter("@AngajatorID", SqlDbType.Int,4)
				};
			
			//setare parametrii
			parameters[0].Value = angajatorID;
			
			//executie procedura stocata
			DataSet dsAngajatiFF1 = RunProcedure("GetAngajatiCuFctDeBaza", parameters, "AngajatiFF1");

			return dsAngajatiFF1;
		}

		#endregion
		
		#region FillDataSetAngajatiFF2SP
		/// <summary>
		/// Returneaza toti angajatii care nu au functia de baza la angajatorul dat ca parametru
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet FillDataSetAngajatiFF2SP( int angajatorID)
		{
			//declarare parametrii
			SqlParameter[] parameters =
				{
					new SqlParameter("@AngajatorID", SqlDbType.Int,4)
				};
			
			//setare parametrii
			parameters[0].Value = angajatorID;
			
			//executie procedura stocata
			DataSet dsAngajatiFF2 = RunProcedure("GetAngajatiFaraFctDeBaza", parameters, "AngajatiFF2");

			return dsAngajatiFF2;
		}
		
		#endregion
		
		#region FillDataSetAniSP
		/// <summary>
		/// Returneaza anii pentru care sunt calculate salariile in baza de date
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet FillDataSetAniSP()
		{
			//declarare parametrii
			SqlParameter[] parameters ={};

			//executie procedura stocata
			DataSet dsAni = RunProcedure("GetAniSal_Salarii",parameters,"Ani");

			return dsAni;
		}

		#endregion
		
		#region FillDataSetLuniSP
		/// <summary>
		/// Returneaza lunile din anul dat ca parametru pentru care sunt calculate salariile in baza de date
		/// </summary>
		/// <param name="an">Anul</param>
		/// <returns>Returneaza un DataSet care contine </returns>
		public DataSet FillDataSetLuniSP(int an)
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
	
		#region FillDataSetDbf
		/// <summary>
		/// Returneaza datele din dbf-ul dat ca parametru
		/// </summary>
		/// <param name="numeDbf">Numele dbf-ului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet FillDataSetDbf(string numeDbf)
		{
			OleDbConnection conn;
			DataSet ds=new DataSet();
			
			string connString=GetConnectionFoxPro();
			try
			{
				using(conn=new OleDbConnection(connString))
				{
					conn.Open();
					
					string com="SELECT * FROM "+numeDbf;
					OleDbCommand comm=new OleDbCommand(com,conn);
					OleDbDataAdapter adapt1=new OleDbDataAdapter(comm);
					adapt1.Fill(ds,"A11");
				
					conn.Close();
				}
			}
			catch
			{
				return ds;
			}

			return ds;}

		#endregion		
		#endregion

		#region Connection string pentru Fox Pro,executia comenzii de inserare si completare date din Dbf
		#region GetConnectionFoxPro
		/// <summary>
		/// Returneaza connection string-ul pentru FoxPro
		/// </summary>
		/// <returns></returns>
		private string GetConnectionFoxPro() 
		{
			return @"Provider=vfpoledb.1;" + @"Data Source="+this.path+@"\DeclaratiiDB\Siemens.dbc;" + "Exclusive=false;Nulls=false";	
		}
		#endregion
		
		#region DoCommand
		/// <summary>
		/// Executa comanda sql
		/// </summary>
		/// <param name="sql">Comanda SQL executata</param>
		/// <returns>Returneaza un string care contine rezultatul executiei comenzii</returns>
		public string DoCommand(string sql) 
		{
			OleDbConnection myConnection= new OleDbConnection(GetConnectionFoxPro());
			OleDbCommand myCommand = new OleDbCommand(sql,myConnection);
			try
			{
				myCommand.Connection.Open();
				myCommand.ExecuteNonQuery();
			}
			catch(OleDbException exc)
			{
				return "Eroare la conectare. "+exc.Message;
					
			}
			catch(Exception ex)
			{
				return "Eroare la inserare. "+ex.Message;
			}
			finally
			{            
				if (myConnection != null)
				{
					if (myConnection.State==System.Data.ConnectionState.Open) 
						myConnection.Close();
				} 
			} 

			return "Inserare realizata cu succes!";
		}
		#endregion
		#endregion	
	}
}
