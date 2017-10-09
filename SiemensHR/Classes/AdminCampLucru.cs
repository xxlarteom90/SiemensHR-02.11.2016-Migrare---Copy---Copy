/*
 * Autor:     Oprescu Claudia
 * Data:      30.03.2006
 * Descriere: Clasa se ocupa cu gestiunea unui punct de lucru: 
 *			  adaugare, modificare, stergere,
 *			  selectare Puncturi de lucru pentru un anumit angajator,
 *			  stergerea Puncturilor de lucru ale unui anumit angajator
 */

namespace SiemensHR.Classes
{	
	using System;
	using System.Data;
	using System.Data.SqlClient;
	using System.Configuration;
	using SiemensHR.utils;
	using Salaries.Business;

	public class AdminPunctLucru
	{
		private DataSet dsPuncteDeLucru;
		protected Salaries.Configuration.ModuleSettings settings;


		/*#region Declararea variabilelor private
		private int punctLucruID;
		private int angajatorID;
		private string nume;
		#endregion

		#region Declararea proprietatilor de Set/Get ptr. variabilele private

		public int PunctLucruID
		{
			get 
			{
				return punctLucruID;
			}
			set 
			{
				punctLucruID =  value;
			}
		}
		public int AngajatorID
		{
			get 
			{
				return angajatorID;
			}
			set 
			{ 
				angajatorID =  value;
			}
		}

		public string Nume
		{
			get 
			{
				return nume;
			}
			set 
			{ 
				nume = value; 
			}
		}

		#endregion

		#region public AdminPunctLucru()
		/// <summary>
		/// Constructor implicit
		/// </summary>
		public AdminPunctLucru()
		{
			punctLucruID = 0;
			angajatorID =0;
			nume = "";
		}
		#endregion

		#region public void LoadInfoPunctLucru( int punctLucruID )
		/// <summary>
		/// Se obtin informatiile despre un anumit punct de lucru
		/// </summary>
		/// <param name="PunctLucruID"></param>
		public void LoadInfoPunctLucru( int punctLucruID )
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetPunctLucruInfo", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PunctLucruID", SqlDbType.Int, 4, PunctLucruID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			dsPuncteDeLucru = new DataSet();
			dAdapt.Fill(dsPuncteDeLucru);	

			DataRow dRow = dsPuncteDeLucru.Tables[0].Rows[0];
			
			punctLucruID = punctLucruID;
			angajatorID = int.Parse(dRow["AngajatorID"].ToString());
			nume = dRow["Nume"].ToString();
		}
		#endregion

		#region public DataSet LoadInfoPunctLucruAngajator( int angajatorID )
		/// <summary>
		/// Se obtin Puncturile de lucru ale unui anumit angajator
		/// </summary>
		/// <param name="angajatorID"></param>
		/// <returns></returns>
		public DataSet LoadInfoPunctLucruAngajator( int angajatorID )
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection sqlConnection = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetPunctLucruInfoAngajator", sqlConnection);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, angajatorID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			dsPuncteDeLucru = new DataSet();
			dAdapt.Fill(dsPuncteDeLucru);	

			return dsPuncteDeLucru;
		}
		#endregion

		#region public DataSet GetPuncteDeLucruAngajatori()
		/// <summary>
		/// Se obtin punctele de lucru ale angajatorilor.
		/// </summary>
		/// <returns>Un DataSet ce cuprinde toate punctele de lucru ale angajatorilor.</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  3.06.2006
		/// </remarks>
		public DataSet GetPuncteDeLucruAngajatori()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection sqlConnection = new SqlConnection(settings.ConnectionString);
			
			SqlCommand sqlCommand = new SqlCommand("GetPuncteDeLucruAngajatori", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
				
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			dsPuncteDeLucru = new DataSet();
			sqlDataAdapter.Fill(dsPuncteDeLucru);	

			return dsPuncteDeLucru;
		}
		#endregion

		#region public void UpdatePunctLucru(int punctLucruID)
		/// <summary>
		/// Se actualizeaza un punct de lucru
		/// </summary>
		/// <param name="PunctLucruID"></param>
		public void UpdatePunctLucru(int punctLucruID)
		{
			if (punctLucruID==0)
			{
				throw new Exception("Cannot save! PunctLucruID = 0!");
			}
			else
			{
				punctLucruID = punctLucruID;

				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				SqlConnection m_con = new SqlConnection(settings.ConnectionString);
				SqlCommand myCommand = new SqlCommand("InsertUpdateDeletePunctLucru", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
				
				LoadParameters(myCommand);
				
				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
			}
		}
		#endregion

		#region public void DeletePunctLucru( int PunctLucruID )
		/// <summary>
		/// Se sterge un punct de lucru
		/// </summary>
		/// <param name="PunctLucruID"></param>
		public void DeletePunctLucru( int punctLucruID )
		{
			if (punctLucruID==0)
				throw new Exception("Cannot delete! PunctLucruID = 0!");
			else
			{
				this.punctLucruID = punctLucruID;

				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				SqlConnection sqlConnection = new SqlConnection(settings.ConnectionString);
				SqlCommand myCommand = new SqlCommand("InsertUpdateDeletePunctLucru", sqlConnection);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
				
				LoadParameters(myCommand);

				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
			}
		}
		#endregion

		#region public void InsertPunctLucru()
		/// <summary>
		/// Se adauga un punct de lucru
		/// </summary>
		public void InsertPunctLucru()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection sqlConnection = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeletePunctLucru", sqlConnection);
			myCommand.CommandType = CommandType.StoredProcedure;
		
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
		
			LoadParameters(myCommand);

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}
		#endregion

		#region private void LoadParameters( SqlCommand myCommand)
		/// <summary>
		/// Se incarca parametrii pentru o comanda
		/// </summary>
		/// <param name="myCommand"></param>
		private void LoadParameters( SqlCommand myCommand)
		{
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PunctLucruID", SqlDbType.Int, 4, punctLucruID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, angajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, nume));
		}
		#endregion

		#region static public void DeleteAllPunctLucruAngajator(int angajatorID)
		/// <summary>
		/// Sunt sterse toate domeniile de activitate ale angajatorului cu id-ul AngajatorID
		/// </summary>
		/// <param name="angajatorID"></param>
		public void DeleteAllPunctLucruAngajator(int angajatorID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection sqlConnection = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("DeleteAllPunctLucruAngajator", sqlConnection);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, angajatorID));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}
		#endregion
		
		#region public bool CheckIfPunctLucruCanBeDeleted( int PunctLucruID)
		/// <summary>
		/// Verifica daca un punct de lucru poate fi sters, adica nu sunt angajati pentru el
		/// </summary>
		/// <param name="PunctLucruID"></param>
		/// <returns></returns>
		public bool CheckIfPunctLucruCanBeDeleted( int PunctLucruID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection sqlConnection = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfPunctLucruCanBeDeleted", sqlConnection);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PunctLucruID", SqlDbType.Int, 4, PunctLucruID));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (Convert.ToInt32(ds.Tables[0].Rows[0]["norec"])>0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		#endregion*/
	}
}

