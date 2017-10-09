//Autor: Cristina Raluca Muntean
//Descriere: clasa gestioneaza domeniile de activitate

//Modificat: Oprescu Claudia
//Descriere: s-a modificat tipul parametrului procent de la float la real pentru ca erau probleme la adugarea in baza de date
//Modificat: Anca Holostencu
//Descriere: S-a adaugat campul Norma
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SiemensHR.utils;

namespace SiemensHR.Classes
{

	/// <summary>
	/// Summary description for AdminDomeniiDeActivitate.
	/// </summary>
	public struct DomeniuDeActivitate
	{
		//id-ul domeniului de activitate
		/*public int DomDeActivitateID;
		//codul CAEN al domeniului de activitate
		public int CodCAEN;
		//denumirea domeniului
		public string Denumire;
		//descrierea domeniului de activitate
		public string Descriere;
		//procentul aferent domeniului de activitate
		public float Procent;
		//norma domeniului de activitate
		public int Norma;*/
	}

	public class AdminDomeniiDeActivitate
	{
		/*private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;
		
		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}
		
		//constructor
		public AdminDomeniiDeActivitate()
		{
			m_ds = LoadInfoDomeniiDeActivitate();
		}
		//returneaza toate domeniile de activitate 
		public DataSet LoadInfoDomeniiDeActivitate()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetAllDomeniiDeActivitate", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			return ds;
		}

		//returneaza toate datele legate de domeniul de activitate cu id-ul domDeActivitateID
		static public DomeniuDeActivitate GetDomeniuDeActivitateInfo( int domDeActivitateID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("GetDomeniuDeActivitateInfo", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomDeActivitateID", SqlDbType.Int, 4, domDeActivitateID));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for DomDeActivitateID=" +  domDeActivitateID.ToString());
			else
			{
				DomeniuDeActivitate infoDomeniuDeActivitate = new DomeniuDeActivitate();
				
				infoDomeniuDeActivitate.DomDeActivitateID = int.Parse(ds.Tables[0].Rows[0]["DomDeActivitateID"].ToString());
				infoDomeniuDeActivitate.CodCAEN = int.Parse(ds.Tables[0].Rows[0]["CodCAEN"].ToString());
				infoDomeniuDeActivitate.Denumire = ds.Tables[0].Rows[0]["Denumire"].ToString();
				infoDomeniuDeActivitate.Descriere = ds.Tables[0].Rows[0]["Descriere"].ToString();
				infoDomeniuDeActivitate.Procent = float.Parse(ds.Tables[0].Rows[0]["Procent"].ToString());
				infoDomeniuDeActivitate.Norma = int.Parse(ds.Tables[0].Rows[0]["Norma"].ToString());
								
				return infoDomeniuDeActivitate;
			}
		}
		
		
		//este inserat un domeniu de activitate in baza de date
		static public void InsertDomeniuDeActivitate(DomeniuDeActivitate newDomeniuDeActivitate)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteDomeniuDeActivitate", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomDeActivitateID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodCAEN", SqlDbType.Int, 4, newDomeniuDeActivitate.CodCAEN));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 100, newDomeniuDeActivitate.Denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 200, newDomeniuDeActivitate.Descriere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Real, 4, newDomeniuDeActivitate.Procent));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Norma", SqlDbType.Int, 4, newDomeniuDeActivitate.Norma));

			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	
		}

		

		//se face update domeniului de activitate cu id-ul domDeActivitateID
		static public void UpdateDomeniuDeActivitate(DomeniuDeActivitate newDomeniuDeActivitate)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteDomeniuDeActivitate", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomDeActivitateID", SqlDbType.Int, 4, newDomeniuDeActivitate.DomDeActivitateID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodCAEN", SqlDbType.Int, 4, newDomeniuDeActivitate.CodCAEN));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 100, newDomeniuDeActivitate.Denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 200, newDomeniuDeActivitate.Descriere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Float, 8, newDomeniuDeActivitate.Procent));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Norma", SqlDbType.Int, 4, newDomeniuDeActivitate.Norma));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}
		
		
		//este stears domeniul de activitate cu id-ul domeniuDeActivitateID
		static public void DeleteDomeniuDeActivitate(int domeniuDeActivitateID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteDomeniuDeActivitate", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomDeActivitateID", SqlDbType.Int, 4, domeniuDeActivitateID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodCAEN", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 100, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 200, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Float, 8, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Norma", SqlDbType.Int, 4, 8));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}
		//returneaza toate domeniile de activitate disponibile pentru un anumit angajator
		static public DataSet GetDomDeActDisponibilePtAngajator(int angajatorID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("GetDomDeActDisponibilePtAngajator", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, angajatorID));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

			return ds;

		}

		/// <summary>
		/// Procedura verifica daca un domeniu de activitate poate fi sters
		/// </summary>
		/// <param name="domDeActivitateID">Id-ul domeniului de activitate pentru care se face verificarea</param>
		/// <returns>Returneaza rezultatul verificarii daca s-a putut efectua stergerea
		/// 0 - se poate sterge
		/// 1 - exista date asociate domeniului
		/// 2 - este ultimul domeniu din lista
		/// </returns>
		/// <remarks>
		/// Modificat:	Oprescu Claudia
		/// Data:		27.02.2007
		/// </remarks>
		static public int CheckIfDomDeActCanBeDeleted( int domDeActivitateID)
		{
			//se numara aparitii ale id-ului domeniului de activitate trimis ca parametru
			//in tabela DomDeActivitateAngajator
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("CheckIfDomDeActCanBeDeleted", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomDeActivitateID", SqlDbType.Int, 4, domDeActivitateID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@SePoateSterge", SqlDbType.Int, 4));
						
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return int.Parse(myCommand.Parameters[1].Value.ToString());
		}

		/// <summary>
		/// Procedura este folosita pentru a verifica daca se poate face adaugare/modificare fara a se crea duplicate
		/// </summary>
		/// <param name="domDeActivitateID">Id-ul domeniului de activitate care nu trebuie sa concida</param>
		/// <param name="codCAEN">Codul pentru un domeniu</param>
		/// <param name="denumire">Denumirea pentru un domeniu</param>
		/// <param name="procent">Procentul pentru un domeniu</param>
		/// <param name="norma">Norma pentru un domeniu</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		static public bool CheckIfDomeniuDeActivitateCanBeAdded(int domDeActivitateID, int codCAEN, string denumire, float procent, int norma)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfDomeniuDeActivitateCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodCAEN", SqlDbType.Int, 4, codCAEN));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 100, denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Procent", SqlDbType.Real, 4, procent));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Norma", SqlDbType.Int, 4, norma));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomDeActivitateID", SqlDbType.Int, 4, domDeActivitateID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrDomenii", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[5].Value.ToString()) == 0;
		}	*/	
	}
}
