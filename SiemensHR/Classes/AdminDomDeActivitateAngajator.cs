//Autor: Cristina Raluca Muntean
//Descriere: clasa gestioneaza domeniile de activitate
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
	public struct DomDeActivitateAngajator
	{
		/*public int DomeniuAngajatorID; //id-ul 
		public int DomDeActivitateID; //id-ul domeniului de activitate
		public int AngajatorID; //id-ul angajatorului
		public bool Principal; //true daca domeniul e principa, false altfel;un angajator are un sg domeniu principal
		*/
	}

	public class AdminDomDeActivitateAngajator
	{
		/*private DataSet m_ds;
		private int m_AngajatorID;
		private Salaries.Configuration.ModuleSettings settings;
		
		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}
		
		//constructor
		public AdminDomDeActivitateAngajator(int angajatorID)
		{
			this.m_AngajatorID=angajatorID;
			m_ds = LoadInfoDomDeActivitateAngajator(this.m_AngajatorID);
		}
		//returneaza toate domeniile de activitate ale unui angajator
		public DataSet LoadInfoDomDeActivitateAngajator(int angajatorID)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetDomDeActivitateAngajator", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, angajatorID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			return ds;
		}

		//returneaza toate datele legate de domeniul de activitate al angajatorului
		static public DomDeActivitateAngajator GetDomDeActivitateAngajatorInfo( int domeniuAngajatorID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("GetDomDeActivitateAngajatorInfo", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomeniuAngajatorID", SqlDbType.Int, 4, domeniuAngajatorID));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for DomeniuAngajatorID=" +  domeniuAngajatorID.ToString());
			else
			{
				DomDeActivitateAngajator infoDomDeActAngajator = new DomDeActivitateAngajator();
				
				infoDomDeActAngajator.DomeniuAngajatorID = int.Parse(ds.Tables[0].Rows[0]["DomeniuAngajatorID"].ToString());
				infoDomDeActAngajator.AngajatorID = int.Parse(ds.Tables[0].Rows[0]["AngajatorID"].ToString());
				infoDomDeActAngajator.DomDeActivitateID = int.Parse(ds.Tables[0].Rows[0]["DomDeActivitateID"].ToString());
				infoDomDeActAngajator.Principal = bool.Parse(ds.Tables[0].Rows[0]["Principal"].ToString());
								
				return infoDomDeActAngajator;
			}
		}
		
		
		//este inserat un domeniu de activitate pentru un angajator in baza de date
		static public void InsertDomDeActivitateAngajator(DomDeActivitateAngajator newDomDeActAngajator)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteDomDeActivitateAngajator", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomeniuAngajatorID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, newDomDeActAngajator.AngajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomDeActivitateID", SqlDbType.Int, 4, newDomDeActAngajator.DomDeActivitateID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Principal", SqlDbType.Bit, 1, newDomDeActAngajator.Principal));

						
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	
		}

		

		//se face update domeniului de activitate pentru un angajator cu id-ul domeniuAngajatorID
		static public void UpdateDomDeActivitateAngajator(DomDeActivitateAngajator newDomDeActAngajator)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteDomDeActivitateAngajator", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomeniuAngajatorID", SqlDbType.Int, 4,newDomDeActAngajator.DomeniuAngajatorID ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, newDomDeActAngajator.AngajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomDeActivitateID", SqlDbType.Int, 4, newDomDeActAngajator.DomDeActivitateID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Principal", SqlDbType.Bit, 1, newDomDeActAngajator.Principal));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}
				
		//este stears domeniul de activitate cu id-ul newDomDeActAngajator.DomDeActivitateID angajatorului cu id-ul
		//newDomDeActAngajator.AngajatorID
		static public void DeleteDomDeActivitateAngajator(DomDeActivitateAngajator newDomDeActAngajator)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteDomDeActivitateAngajator", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomeniuAngajatorID", SqlDbType.Int, 4, newDomDeActAngajator.DomeniuAngajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, newDomDeActAngajator.AngajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomDeActivitateID", SqlDbType.Int, 4, newDomDeActAngajator.DomDeActivitateID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Principal", SqlDbType.Bit, 1, newDomDeActAngajator.Principal));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}
		
		//sunt sterse toate domeniile de activitate ale angajatorului cu id-ul AngajatorID
		static public void DeleteAllDomDeActivitateAngajator(int angajatorID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteDomDeActivitateAngajator", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 3));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomeniuAngajatorID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, angajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DomDeActivitateID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Principal", SqlDbType.Bit, 1, false));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}*/
		
	}
}
