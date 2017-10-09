//Autor: Cristina Raluca Muntean
//Descriere: clasa gestioneaza alertele unui angajat
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for IstoricAlerte.
	/// </summary>
	public struct Alerta
	{
		/*public int AlertaID;
		public int AngajatID;
		public DateTime DataExpirare;
		public int PerioadaCritica;
		public string Descriere;
		public bool Activ;*/
	}

	public class IstoricAlerte
	{
		/*private DataSet m_ds;
		private int m_AngajatID;
		protected Salaries.Configuration.ModuleSettings settings;

		public DataSet getDataSet
		{
			get { return m_ds;}
			set {}
		}

		public IstoricAlerte(int AngajatID)
		{
			this.m_AngajatID = AngajatID;
			m_ds = LoadInfoAlerta(this.m_AngajatID);
		}
		

		//returneaza toate datele legat e de alerta cu id-ul alertaID
		static public Alerta GetAlertaInfo( int alertaID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("GetAlertaInfo", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AlertaID", SqlDbType.Int, 4, alertaID));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if (ds.Tables[0].Rows.Count==0)
				throw new Exception("Returnig no data for AlertaID=" +  alertaID.ToString());
			else
			{
				Alerta infoAlerta = new Alerta();
				
				infoAlerta.AngajatID = int.Parse(ds.Tables[0].Rows[0]["AngajatID"].ToString());
				infoAlerta.DataExpirare = DateTime.Parse(ds.Tables[0].Rows[0]["DataExpirare"].ToString());
				infoAlerta.PerioadaCritica = int.Parse(ds.Tables[0].Rows[0]["PerioadaCritica"].ToString());
				infoAlerta.Descriere = ds.Tables[0].Rows[0]["Descriere"].ToString();
				infoAlerta.Activ = bool.Parse(ds.Tables[0].Rows[0]["Activ"].ToString());
				
				return infoAlerta;
			}
		}

		//returneaza toate alertele angajatului cu id-ul angajatID
		public DataSet LoadInfoAlerta(int angajatID)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetAngajatAlerte", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, angajatID));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);

			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			return ds;
		}
		
		//este inserata o alerta in baza de date
		static public void InsertAlerta(Alerta newAlerta)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteAlerte", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AlertaID", SqlDbType.Int, 4, newAlerta.AlertaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, newAlerta.AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataExpirare", SqlDbType.DateTime, 8, newAlerta.DataExpirare));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PerioadaCritica", SqlDbType.Int, 4, newAlerta.PerioadaCritica));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 200, newAlerta.Descriere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, newAlerta.Activ));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	
		}
		
		//se face update alertei cu id-ul alertaID
		static public void UpdateAlerta(Alerta newAlerta)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteAlerte", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AlertaID", SqlDbType.Int, 4, newAlerta.AlertaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, newAlerta.AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataExpirare", SqlDbType.DateTime, 8, newAlerta.DataExpirare));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PerioadaCritica", SqlDbType.Int, 4, newAlerta.PerioadaCritica));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 200, newAlerta.Descriere));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, newAlerta.Activ));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}
		
		//este stearsa alerta cu id-ul alertaID
		static public void DeleteAlerta(int alertaID)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteAlerte", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AlertaID", SqlDbType.Int, 4, alertaID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DataExpirare", SqlDbType.DateTime, 8, DateTime.MinValue));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PerioadaCritica", SqlDbType.Int, 4, 0));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 200, ""));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Activ", SqlDbType.Bit, 1, true));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);	

		}*/
	}
}
