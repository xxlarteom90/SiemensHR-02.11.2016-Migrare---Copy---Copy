using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SiemensHR.utils;


namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for AdminJudete.
	/// </summary>
	/// 
	public struct Judet
	{
		/*public int TaraID;
		public int JudetID;
		public string Nume;
		public string Simbol;
		public string Cod;*/
	}

	public class AdminJudete
	{
		/*private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;


		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		public AdminJudete()
		{
			LoadInfoJudete();
		}

		private void LoadInfoJudete()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetAllJudete", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);
		}

		/// <summary>
		/// Procedura returneaza toate judetele unei tari
		/// </summary>
		/// <param name="taraID">Id-ul tarii pentru care sunt returnate judetele</param>
		/// <returns>Returneaza un DataSet care contine judetele tarii</returns>
		static public DataSet GetAllJudeteTara(int taraID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetAllJudeteTara", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;		
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraID", SqlDbType.Int, 4, taraID ));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			return ds;
		}

		static public void InsertJudet(Judet newJudet)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteJudet", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@JudetID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraID", SqlDbType.Int, 4, newJudet.TaraID ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, newJudet.Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Simbol", SqlDbType.NVarChar, 255, newJudet.Simbol));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.NVarChar, 5, newJudet.Cod));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void UpdateJudet(Judet categData, int JudetID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteJudet", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@JudetID", SqlDbType.Int, 4, JudetID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraID", SqlDbType.Int, 4, categData.TaraID ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, categData.Nume));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Simbol", SqlDbType.NVarChar, 255, categData.Simbol));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.NVarChar, 5, categData.Cod));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public void DeleteJudet(int JudetID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteJudet", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@JudetID", SqlDbType.Int, 4, JudetID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraID", SqlDbType.Int, 4, -1 ));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Simbol", SqlDbType.NVarChar, 255, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Cod", SqlDbType.NVarChar, 5, ""));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}

		static public Judet GetJudetInfo( int JudetID)
		{
			Judet infoJudet = new Judet(); 
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);

			SqlCommand myCommand = new SqlCommand("GetJudetInfo", m_con);
			myCommand.Parameters.Add( new SqlParameter( "@JudetID", SqlDbType.Int, 4 ) );
			myCommand.Parameters[ 0 ].Value = JudetID;
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for JudetID=" +  JudetID.ToString());
			else
			{
				
				infoJudet.TaraID = int.Parse( ds.Tables[0].Rows[0]["TaraID"].ToString());
				infoJudet.Nume = ds.Tables[0].Rows[0]["Nume"].ToString();
				infoJudet.Simbol = ds.Tables[0].Rows[0]["Simbol"].ToString();
				infoJudet.Cod = ds.Tables[0].Rows[0]["Cod"].ToString();
				
				return infoJudet;
			}
		}

		static public int CheckIfJudetCanBeDeleted( int JudetID )
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);

			SqlCommand myCommand = new SqlCommand("CheckIfJudetCanBeDeleted", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add( new SqlParameter( "@JudetID", SqlDbType.Int, 4 ) );
			myCommand.Parameters.Add( new SqlParameter( "@Raspuns", SqlDbType.Int, 4 ) );
			
			myCommand.Parameters[ 0 ].Value = JudetID;
			myCommand.Parameters[ 1 ].Direction = ParameterDirection.ReturnValue;

			m_con.Open();
			myCommand.ExecuteNonQuery();
			m_con.Close();
			
			return int.Parse( myCommand.Parameters[ "@Raspuns" ].Value.ToString() );
		}

		/// <summary>
		/// Se verifica daca exista un judet ce are aceleasi date cu cel trimis ca parametru.
		/// </summary>
		/// <param name="judet"> Judetul ce se doreste a fi verificat</param>
		/// <returns>true in cazul in care exista, false altfel.</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  15.06.2006
		/// </remarks>
		static public bool VerificareExistentaJudet(Judet judet)
		{
			bool existaJudetul;
			string connString = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection sqlConnection = new SqlConnection(connString);
			sqlConnection.Open();

			SqlCommand sqlCommand = new SqlCommand("CheckIfExistaJudet", sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			sqlCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@judetID", SqlDbType.Int, 4, judet.JudetID));
			sqlCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@taraID", SqlDbType.Int, 4, judet.TaraID ));
			sqlCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@nume", SqlDbType.NVarChar, 50, judet.Nume));
			sqlCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@simbol", SqlDbType.NVarChar, 2, judet.Simbol));
			sqlCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@cod", SqlDbType.NVarChar, 5, judet.Cod));
			sqlCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@existaJudet", SqlDbType.Bit, 1));		
			sqlCommand.ExecuteNonQuery();

			sqlConnection.Close();
			
			existaJudetul = bool.Parse( sqlCommand.Parameters[ "@existaJudet" ].Value.ToString() );

			return existaJudetul;
		}*/
	}
}
