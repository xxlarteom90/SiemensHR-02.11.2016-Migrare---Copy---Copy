using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SiemensHR.Conducere
{
	/*public abstract class Conducere
	{
		public string m_Nume;
		public string m_Titlu;
		public string m_Functie;
		public int m_AngajatID;

		public Conducere()
		{
			

		}

		public string Nume
		{
			get
			{
				return m_Nume;
			}
			set
			{
				m_Nume = value;
			}
		}
		public string Titlu
		{
			get
			{
				return m_Titlu;
			}
			set
			{
				m_Titlu = value;
			}
		}
		public string Functie
		{
			get
			{
				return m_Functie;
			}
			set
			{
				m_Functie = value;
			}
		}
		public int AngajatID
		{
			get
			{
				return m_AngajatID;
			}
			set
			{
				m_AngajatID = value;
			}
		}
	}

	public class GeneralManager : Conducere
	{
		protected Salaries.Configuration.ModuleSettings settings;
		public GeneralManager()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection conn = new SqlConnection(settings.ConnectionString);
			SqlCommand command = new SqlCommand("GetConducere", conn);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@Functie", 3);
			conn.Open();
			SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
			if(reader.HasRows)
			{
				reader.Read();
				Titlu = reader.GetString(0);
				Nume = reader.GetString(1);
				Functie = reader.GetString(2);
				AngajatID = reader.GetInt32(3);
			}
			else
			{	
				Titlu = "";
				Nume = "";
				Functie = "";
				AngajatID = 0;
			
			}

		}
		
	}

	public class DirectorEconomic : Conducere
	{
		protected Salaries.Configuration.ModuleSettings settings;
		public DirectorEconomic()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection conn = new SqlConnection(settings.ConnectionString);
			SqlCommand command = new SqlCommand("GetConducere", conn);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@Functie", 4);
			conn.Open();
			SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
			if(reader.HasRows)
			{	
				reader.Read();
				Titlu = reader.GetString(0);
				Nume = reader.GetString(1);
				Functie = reader.GetString(2);
				AngajatID =	reader.GetInt32(3);
			}
			else
			{
				Titlu = "";
				Nume = "";
				Functie = "";
				AngajatID =	0;
			}

		}

	}

	//Cristina Raluca Muntean
	//inspector de resurse umane
	public class InspectorResurseUmane : Conducere
	{
		protected Salaries.Configuration.ModuleSettings settings;
		public InspectorResurseUmane()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection conn = new SqlConnection(settings.ConnectionString);
			SqlCommand command = new SqlCommand("GetConducere", conn);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@Functie", 342304);
			conn.Open();
			SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
			if(reader.HasRows)
			{
				reader.Read();
				Titlu = reader.GetString(0);
				Nume = reader.GetString(1);
				Functie = reader.GetString(2);
				AngajatID = reader.GetInt32(3);
			}
			else
			{
				Titlu = "";
				Nume = "";
				Functie = "";
				AngajatID = 0;
			
			}
		}

	}
	
	
	//Cristina Raluca Muntean
	//manager HR
	public class ManagerHR : Conducere
	{
		protected Salaries.Configuration.ModuleSettings settings;
		public ManagerHR()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection conn = new SqlConnection(settings.ConnectionString);
			SqlCommand command = new SqlCommand("GetConducere", conn);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Add("@Functie", 242103);
			conn.Open();
			SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
			if(reader.HasRows)
			{
				reader.Read();
				Titlu = reader.GetString(0);
				Nume = reader.GetString(1);
				Functie = reader.GetString(2);
				AngajatID = reader.GetInt32(3);
			}
			else
			{
				Titlu = "";
				Nume = "";
				Functie = "";
				AngajatID = 0;
			}
		}

	}*/
	
}