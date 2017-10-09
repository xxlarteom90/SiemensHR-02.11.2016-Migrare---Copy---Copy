using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SiemensHR.utils;


namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for AdminDepartamenturi.
	/// </summary>
	/// 
	public struct Departament
	{
		/*public int DepartamentID;
		public string Nume;
		public string Denumire;
		public int CentruCostID;
		public int SefID;
		public int InlocSefID;
		public int DeptParinte;*/
	}

	public class Admin_Departamente
	{
		/*protected Salaries.Configuration.ModuleSettings settings;
		int ParentID;
		private DataSet m_ds;

		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		public Admin_Departamente(int ParentID)
		{
			this.ParentID = ParentID;
			m_ds = LoadInfoDepartament(this.ParentID);
		}

		public DataSet LoadInfoDepartament(int DeptParinte)
		{

			settings = Salaries.Configuration.ModuleConfig.GetSettings();	
			
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetDepartamente", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DeptParinte", SqlDbType.Int, 4, DeptParinte));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			return ds;
		}

		static public void InsertDepartament(Departament newDepartament)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;	
			
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteDepartament", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DepartamentID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255, newDepartament.Denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CentruCostID", SqlDbType.Int, 4, newDepartament.CentruCostID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SefID", SqlDbType.Int, 4, newDepartament.SefID));
			if ( newDepartament.InlocSefID != -1)
			{
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@InlocSefID", SqlDbType.Int, 4, newDepartament.InlocSefID));
			}
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DeptParinte", SqlDbType.Int, 4, newDepartament.DeptParinte));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void UpdateDepartament(Departament newDepartament)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteDepartament", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DepartamentID", SqlDbType.Int, 4, newDepartament.DepartamentID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255, newDepartament.Denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CentruCostID", SqlDbType.Int, 4, newDepartament.CentruCostID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SefID", SqlDbType.Int, 4, newDepartament.SefID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@InlocSefID", SqlDbType.Int, 4, newDepartament.InlocSefID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DeptParinte", SqlDbType.Int, 4, newDepartament.DeptParinte));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void DeleteDepartament(int DepartamentID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteDepartament", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DepartamentID", SqlDbType.Int, 4, DepartamentID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CentruCostID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@SefID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@InlocSefID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DeptParinte", SqlDbType.Int, 4, 0));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public Departament GetDepartamentInfo( int DepartamentID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("GetDepartamentInfo", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DepartamentID", SqlDbType.Int, 4, DepartamentID));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for DepartamentID=" +  DepartamentID.ToString());
			else
			{
				Departament infoDepartament = new Departament();
				
				infoDepartament.Denumire = ds.Tables[0].Rows[0]["Denumire"].ToString();
				infoDepartament.CentruCostID = int.Parse(ds.Tables[0].Rows[0]["CentruCostID"].ToString());
				infoDepartament.DepartamentID = int.Parse(ds.Tables[0].Rows[0]["DepartamentID"].ToString());
				if( ds.Tables[0].Rows[0]["SefID"] != System.DBNull.Value )
                    infoDepartament.SefID = int.Parse(ds.Tables[0].Rows[0]["SefID"].ToString());
				else
					infoDepartament.SefID = -1;
				if( ds.Tables[0].Rows[0]["InlocSefID"] != System.DBNull.Value )
					infoDepartament.InlocSefID = int.Parse(ds.Tables[0].Rows[0]["InlocSefID"].ToString());
				else
					infoDepartament.InlocSefID = -1;
				infoDepartament.DeptParinte = int.Parse(ds.Tables[0].Rows[0]["DeptParinte"].ToString());
				
				return infoDepartament;
			}
		}

		/// <summary>
		/// Procedura verifica daca un departament poate fi sters
		/// </summary>
		/// <param name="DepartamentID">Id-ul departamentului care se verifica daca se poate sterge</param>
		/// <returns>Returneaza rezultatul verificarii daca departamentul poate fi sters
		/// 0 - se poate sterge
		/// 1 - este asociat unor angajati
		/// 2 - este departament parinte
		/// 3 - este ultimul din lista
		/// </returns>
		/// <remarks>
		/// Modificat:	Oprescu Claudia
		/// Data:		27.02.2007
		/// </remarks>
		static public int CheckIfDepartamentCanBeDeleted( int DepartamentID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfDepartamentCanBeDeleted", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DepartamentID", SqlDbType.Int, 4, DepartamentID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@SePoateSterge", SqlDbType.Int, 4));
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			return int.Parse(myCommand.Parameters[1].Value.ToString());
		}

		/// <summary>
		/// Procedura verifica daca se poate face adaugare/modificare in tabela Departamente fara a se crea duplicate
		/// </summary>
		/// <param name="departamentID">Id-ul departamentrului care nu trebuie sa coincida</param>
		/// <param name="centruCostID">Id-ul pentru centrul de cost</param>
		/// <param name="denumire">Denumirea pentru centrul de cost</param>
		/// <param name="sefID">Id-ul sefului</param>
		/// <param name="inlocSefID">Id-ul inlocuitorului sefului</param>
		/// <param name="deptParinte">Departamentul parinte</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		static public bool CheckIfAdminDepartamentCanBeAdded(int departamentID, int centruCostID, string denumire, int sefID, int inlocSefID, int deptParinte)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfAdminDepartamentCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CentruCostID", SqlDbType.Int, 4, centruCostID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 255, denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DeptParinte", SqlDbType.Int, 4, deptParinte));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DepartamentID", SqlDbType.Int, 4, departamentID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrDepartamente", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[4].Value.ToString()) == 0;
		}*/
	}
}
