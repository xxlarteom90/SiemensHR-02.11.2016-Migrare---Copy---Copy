using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SiemensHR.utils;
using Salaries.Business;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for AdminAngajator.
	/// </summary>
	public class AdminAngajator
	{
		/*private DataSet m_ds;
		protected Salaries.Configuration.ModuleSettings settings;

		#region Declararea variabilelor private
		private int m_AngajatorID;
		private string m_Denumire;
		private int m_TipPersoana;
		private string m_CUI_CNP;
		private string m_NrInregORC;
		private string m_Telefon;
		private string m_Fax;
		private string m_PaginaWeb;
		private string m_Email;
		private int m_TaraID;
		private int m_JudetSectorID;
		private int m_TipCompletareID;
		private string m_Localitate;
		private string m_Strada;
		private string m_Numar;
		private string m_CodPostal;
		private string m_Bloc;
		private string m_Scara;
		private string m_Etaj;
		private string m_Apartament;
		private string m_ZiLichidareSalar;
		private DateTime m_LunaActiva;
		private string m_Sector;
	#endregion

		#region Declararea proprietatilor de Set/Get ptr. variabilele private

		public int AngajatorID
		{
			get {return m_AngajatorID;}
			set { m_AngajatorID =  value;}
		}

		public string Denumire
		{
			get {return m_Denumire;}
			set { m_Denumire = value; }
		}

		public int TipPersoana
		{
			get {return m_TipPersoana;}
			set {m_TipPersoana = value;}
		}

		public string CUI_CNP
		{
			get {return m_CUI_CNP;}
			set { m_CUI_CNP = value;}
		}

		public string NrInregORC
		{
			get {return m_NrInregORC;}
			set { m_NrInregORC = value;}
		}

		public string Telefon
		{
			get { return m_Telefon;}
			set { m_Telefon = value;}
		}

		public string Fax
		{
			get { return m_Fax;}
			set { m_Fax = value; }
		}

		public string PaginaWeb
		{
			get { return m_PaginaWeb;}
			set { m_PaginaWeb = value;}
		}

		public string Email
		{
			get { return m_Email;}
			set { m_Email = value;}
		}

		public int TaraID
		{
			get { return m_TaraID; }
			set { m_TaraID = value;}
		}

		public int JudetSectorID
		{
			get { return m_JudetSectorID;}
			set { m_JudetSectorID = value;}
		}

		public int TipCompletareID
		{
			get { return m_TipCompletareID;}
			set { m_TipCompletareID = value;}
		}

		public string Localitate
		{
			get {return m_Localitate;}
			set { m_Localitate = value;}
		}

		public string Strada
		{
			get { return m_Strada;}
			set { m_Strada = value;}
		}

		public string Numar
		{
			get { return m_Numar;}
			set { m_Numar = value;} 
		}

		public string CodPostal
		{
			get { return m_CodPostal;}
			set { m_CodPostal = value;}
		}

		public string Bloc
		{
			get { return m_Bloc;}
			set { m_Bloc = value;}
		}

		public string Scara
		{
			get { return m_Scara;}
			set { m_Scara = value;}
		}

		public string Etaj
		{
			get { return m_Etaj;}
			set { m_Etaj = value;}
		}

		public string Apartament
		{
			get { return m_Apartament;}
			set { m_Apartament = value;}
		}

		public string ZiLichidareSalar
		{
			get { return m_ZiLichidareSalar;}
			set { m_ZiLichidareSalar = value; }
		}

		public DateTime LunaActiva
		{
			get { return m_LunaActiva;}
			set { m_LunaActiva = value;}
		}

		public string Sector
		{
			get { return m_Sector;}
			set { m_Sector = value;}
		}
	#endregion


		public AdminAngajator()
		{
			AngajatorID =0;
			Denumire = "";
			TipPersoana = 1;
			CUI_CNP="";
			Telefon = "";
			Fax = "";
			Localitate = "";
			Strada = "";
			Numar = "";
			CodPostal = "";
			ZiLichidareSalar = "";
			m_LunaActiva = DateTime.Now;
			Sector = "";
		}

		public void LoadInfoAngajator( int idAngajator )
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("GetAngajatorInfo", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, idAngajator));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			m_ds = new DataSet();
			dAdapt.Fill(m_ds);	

			DataRow dRow = m_ds.Tables[0].Rows[0];
			
			AngajatorID = idAngajator;
			Denumire = dRow["Denumire"].ToString();
			TipPersoana = Convert.ToInt32(dRow["TipPersoana"]);
			CUI_CNP = dRow["CUI_CNP"].ToString();
			NrInregORC = dRow["NrInregORC"].ToString();
			Telefon = dRow["Telefon"].ToString();
			Fax = dRow["Fax"].ToString();
			PaginaWeb = dRow["PaginaWeb"].ToString();
			Email = dRow["Email"].ToString();
			TaraID = Convert.ToInt32(dRow["taraID"]);
			JudetSectorID = Convert.ToInt32(dRow["JudetSectorID"]);
			TipCompletareID = Convert.ToInt32(dRow["TipCompletareCarnetID"]);
			Localitate = dRow["Localitate"].ToString();
			Strada = dRow["Strada"].ToString();
			Numar = dRow["Numar"].ToString();
			CodPostal = dRow["CodPostal"].ToString();
			Bloc = dRow["Bloc"].ToString();
			Scara = dRow["Scara"].ToString();
			Etaj = dRow["Etaj"].ToString();
			Apartament = dRow["Apartament"].ToString();
			ZiLichidareSalar = dRow["ZiLichidareSalar"].ToString();
			Sector = dRow["Sector"].ToString();
		}

		public object GetValueByName( string colName)
		{
			if (m_ds.Tables[0].Rows.Count!=0)
			{
				return m_ds.Tables[0].Rows[0][colName];
			}
			else
				throw new Exception("GetValueByName. Error reading from DataSet. DataSet is empty!");
		}

		/// <summary>
		/// Angajatorii din sistem.
		/// </summary>
		/// <returns>Un DataSet ce cuprinde toti angajatorii din sistem.</returns>
		/// <remarks>
		/// Modificari:
		/// Autor: Cristina Raluca Muntean
		/// Data: 2.06.2006
		/// Descriere: Am inlocuit rularea unei instructiuni sql, cu rularea procedurii stocate.
		/// </remarks>
		static public DataSet LoadInfoAngajatori()
		{
			// String-ul de conectare la baza de date.
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			// DataSet-ul ce va contine lista angajatorilor.
			DataSet dsAngajatori = new DataSet();

			SqlConnection sqlConnection = new SqlConnection(connStr);
			SqlCommand sqlCommand = new SqlCommand("GetAngajatori", sqlConnection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			sqlDataAdapter.Fill(dsAngajatori);

			return dsAngajatori;
		}
		
		//returneaza array-uri cu AngajatorID si Numnarul de angajati asignati la fiecare 
		static public string GetJSArrays()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("CountAngajatiPerAngajator", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			string arAngajatorID = "";
			string arNoAngajati = "";
			for(int i=0 ;i < ds.Tables[0].Rows.Count; i++)
			{
				DataRow row = ds.Tables[0].Rows[i];
				if (arAngajatorID!="")
					arAngajatorID += ",";
				arAngajatorID += "'" + row["AngajatorID"] + "'";
				if (arNoAngajati!="")
					arNoAngajati += ",";
				arNoAngajati += "'" + row["noangajati"] + "'";
			}

			return "var arAngajatorID = new Array("+ arAngajatorID + "); var arNoAngajati = new Array(" + arNoAngajati + ")";

		}

		public void UpdateAngajator(int idAngajator)
		{
			if (idAngajator==0)
				throw new Exception("Cannot save! AngajatorID = 0!");
			else
			{
				AngajatorID = idAngajator;

				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				SqlConnection m_con = new SqlConnection(settings.ConnectionString);
				SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteAngajator", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 1));
				
				LoadParameters(myCommand);

				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
			}
		}

		public void DeleteAngajator( int idAngajator )
		{
			if (idAngajator==0)
				throw new Exception("Cannot delete! AngajatorID = 0!");
			else
			{
				AngajatorID = idAngajator;

				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				SqlConnection m_con = new SqlConnection(settings.ConnectionString);

				SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteAngajator", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;
				
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 2));
				
				LoadParameters(myCommand);

				m_con.Open();
				myCommand.ExecuteNonQuery();

				m_con.Close();
			}
		}

		public void InsertAngajator()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertUpdateDeleteAngajator", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
		
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@tip_actiune", SqlDbType.Int, 4, 0));
		
			LoadParameters(myCommand);

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}
		//insereaza un angajator si returneaza id-ul angajatorului tocmai inserat
		public int InsertAngajatorWithIDReturn()
		{

			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("InsertAngajatorWithIDReturn", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 100, Denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipPersoana", SqlDbType.Bit, 1, TipPersoana));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CUI_CNP", SqlDbType.NVarChar, 25, CUI_CNP));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NrInregORC", SqlDbType.NVarChar, 25, NrInregORC));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Telefon", SqlDbType.NVarChar, 25, Telefon));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Fax", SqlDbType.NVarChar, 25, Fax));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PaginaWeb", SqlDbType.NVarChar, 25, PaginaWeb));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Email", SqlDbType.NVarChar, 25, Email));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraID", SqlDbType.Int, 4, TaraID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@JudetSectorID", SqlDbType.Int, 4, JudetSectorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipCompletareID", SqlDbType.Int, 4, TipCompletareID));			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Localitate", SqlDbType.NVarChar, 50, Localitate));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Strada", SqlDbType.NVarChar, 50, Strada));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.NVarChar, 10, Numar));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodPostal", SqlDbType.NVarChar, 20, CodPostal));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Bloc", SqlDbType.NVarChar, 5, Bloc));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Scara", SqlDbType.NVarChar, 5, Scara));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Etaj", SqlDbType.NVarChar, 5, Etaj));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Apartament", SqlDbType.NVarChar, 5, Apartament));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ZiLichidareSalar", SqlDbType.NVarChar, 2, ZiLichidareSalar));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Sector", SqlDbType.NVarChar, 5, Sector));


			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@AngajatorID", SqlDbType.Int, 4));
			
			m_con.Open();
			myCommand.ExecuteNonQuery();
			int angajatorID = (int)myCommand.Parameters["@AngajatorID"].Value;
			m_con.Close();
	
			return angajatorID;
		}



		/// <summary>
		/// Procedura insereaza primul angajator la rularea aplicatiei
		/// </summary>
		/// <param name="data">Luna activa pentru care se porneste aplicatia</param>
		/// <returns>Returneaza id-ul angajatorului adaugat</returns>
		public int InsertFirstAngajator(DateTime data)
		{	
			int idAngajator;

			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("spSetFirstAngajator", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlParameter[] parameters = 
				{
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8, data)),
					myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@AngajatorID", SqlDbType.Int, 4)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 100, Denumire)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipPersoana", SqlDbType.Bit, 1, TipPersoana)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CUI_CNP", SqlDbType.NVarChar, 25, CUI_CNP)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NrInregORC", SqlDbType.NVarChar, 25, NrInregORC)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Telefon", SqlDbType.NVarChar, 25, Telefon)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Fax", SqlDbType.NVarChar, 25, Fax)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PaginaWeb", SqlDbType.NVarChar, 25, PaginaWeb)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Email", SqlDbType.NVarChar, 25, Email)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraID", SqlDbType.Int, 4, TaraID)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@JudetSectorID", SqlDbType.Int, 4, JudetSectorID)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Localitate", SqlDbType.NVarChar, 50, Localitate)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Strada", SqlDbType.NVarChar, 50, Strada)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.NVarChar, 10, Numar)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodPostal", SqlDbType.NVarChar, 20, CodPostal)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Bloc", SqlDbType.NVarChar, 5, Bloc)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Scara", SqlDbType.NVarChar, 5, Scara)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Etaj", SqlDbType.NVarChar, 5, Etaj)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Apartament", SqlDbType.NVarChar, 5, Apartament)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ZiLichidareSalar", SqlDbType.NVarChar, 2, ZiLichidareSalar)),
					myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Sector", SqlDbType.NVarChar, 5, Sector)),
				};
	
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			idAngajator = int.Parse(parameters[1].Value.ToString());

			//Inseram in tm_zile zilele pentru luna activa ... daca aceastea nu exista deja
			Luni l = new Luni(idAngajator);
			l.FillZileLuna( int.Parse(data.Month.ToString()), int.Parse(data.Year.ToString()) );
			return idAngajator;
		}

		private void LoadParameters( SqlCommand myCommand)
		{
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, AngajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 100, Denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipPersoana", SqlDbType.Bit, 1, TipPersoana));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CUI_CNP", SqlDbType.NVarChar, 25, CUI_CNP));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NrInregORC", SqlDbType.NVarChar, 25, NrInregORC));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Telefon", SqlDbType.NVarChar, 25, Telefon));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Fax", SqlDbType.NVarChar, 25, Fax));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@PaginaWeb", SqlDbType.NVarChar, 25, PaginaWeb));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Email", SqlDbType.NVarChar, 25, Email));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraID", SqlDbType.Int, 4, TaraID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@JudetSectorID", SqlDbType.Int, 4, JudetSectorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipCompletareID", SqlDbType.Int, 4, TipCompletareID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Localitate", SqlDbType.NVarChar, 50, Localitate));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Strada", SqlDbType.NVarChar, 50, Strada));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.NVarChar, 10, Numar));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CodPostal", SqlDbType.NVarChar, 20, CodPostal));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Bloc", SqlDbType.NVarChar, 5, Bloc));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Scara", SqlDbType.NVarChar, 5, Scara));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Etaj", SqlDbType.NVarChar, 5, Etaj));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Apartament", SqlDbType.NVarChar, 5, Apartament));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@ZiLichidareSalar", SqlDbType.NVarChar, 2, ZiLichidareSalar));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Sector", SqlDbType.NVarChar, 5, Sector));
		}

		/// <summary>
		/// Procedura verifica sa nu se creeze duplicate in tablea Angajatori prin adaugare/modificare
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului care nu trebuie sa coincida</param>
		/// <param name="denumire">Denumirea angajatorului</param>
		/// <param name="CUI_CNP">CUI_CNP pentru angajator</param>
		/// <param name="nrInregORC">Nr inreg pentru angajator</param>
		/// <returns>Returneaza true daca se poate face adaugarea/modificarea si false altfel</returns>
		static public bool CheckIfAngajatorCanBeAdded(int angajatorID, string denumire, string CUI_CNP, string nrInregORC)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spCheckIfAngajatorCanBeAdded", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Denumire", SqlDbType.NVarChar, 100, denumire));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CUI_CNP", SqlDbType.NVarChar, 25, CUI_CNP));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@NrInregORC", SqlDbType.NVarChar, 25, nrInregORC));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, angajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NrAngajatori", SqlDbType.Int, 4));
			myCommand.CommandType = CommandType.StoredProcedure;

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return byte.Parse(myCommand.Parameters[4].Value.ToString()) == 0;
		}

		/*
		 * Added:       Ionel Popa
		 * Date:        21.07.2006
		 * Description: Returneaza punctele de lucrur pentru angajatorul respectiv
		 */
		/*public DataSet GetPuncteLucru( int angajatorID )
		{
			try
			{
				string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
				SqlConnection m_con = new SqlConnection(connStr);

				SqlCommand myCommand = new SqlCommand("GetPuncteLucru", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, angajatorID ));

				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
			
				return ds;   
			}
			catch{ return null;}
		}*/
	}
}
