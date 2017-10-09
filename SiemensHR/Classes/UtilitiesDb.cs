using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;
using SiemensHR.Classes;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for Utilities.
	/// </summary>
	public class UtilitiesDb
	{
		//Stringul de conexiune la baza de date
		private string m_strConn;
		//Conexiunea la baza de date
		private SqlConnection  m_sqlConn;

		#region Proprietati
		public string strConn
		{
			get{ return m_strConn; }
			set { m_strConn = value;}
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="strConnection">Stringul de conexiune la baza de date</param>
		public UtilitiesDb(string strConnection)
		{
			strConn = strConnection;

			m_sqlConn = new SqlConnection(strConn);
		}
		#endregion

		#region CreateCentruCostSelectBox
		/// <summary>
		/// Creaza ComboBox cu centre de cost
		/// </summary>
		/// <param name="listObj">Lista cu centre de cost</param>
		/// <remarks>
		/// Oprescu Claudia
		/// </remarks>
		public void CreateCentruCostSelectBox(DropDownList listObj)
		{
			Salaries.Business.AdminCentreCost centre = new Salaries.Business.AdminCentreCost();
			DataSet ds = centre.LoadInfoCentreCost();
			DataTable myTable = new DataTable();
			myTable = ds.Tables[0];
			for (int i=0; i<myTable.Rows.Count; i++)
			{
				DataRow myRow = myTable.Rows[i];
				ListItem myItem = new ListItem(myRow["cod"].ToString() + " - " + myRow["nume"].ToString(), myRow["centrucostid"].ToString());
				listObj.Items.Add(myItem);		
			}
		}
		#endregion

		#region CreateDepartamenteSelectBox
		/// <summary>
		/// Procedura creaza lista cu departamente
		/// </summary>
		/// <param name="parinte">Departamenul parinte</param>
		/// <param name="nivel">Nivelul unui departament</param>
		/// <param name="listObj">Lista care va contine departamentele</param>
		public void CreateDepartamenteSelectBox(int parinte, int nivel, DropDownList listObj)
		{		
			Salaries.Business.AdminDepartament departamente = new Salaries.Business.AdminDepartament();
			departamente.DeptParinte = parinte;
			
			DataTable myTable = new DataTable();
			myTable = departamente.LoadInfoDepartamente().Tables[0];
			string nivel_text = "";
			
			for(int j=0; j<nivel; j++)
				nivel_text += ".  .  ";
			for (int i=0; i<myTable.Rows.Count; i++)
			{
				DataRow myRow = myTable.Rows[i];
				ListItem myItem = new ListItem(nivel_text + myRow["nume"].ToString(), myRow["DepartamentID"].ToString());
				listObj.Items.Add(myItem);

				nivel ++;
				CreateDepartamenteSelectBox(Convert.ToInt32(myRow["DepartamentID"]), nivel, listObj);
				nivel--;				
			}
		}
		#endregion

		#region CreateAngajatiSelectBoxPeLuna
		/// <summary>
		/// Creeaza dropdownlist-ul cu angajatii care au avut contract in luna trimisa ca parametru
		/// </summary>
		/// <param name="listObj">Lista cu angajati</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <param name="lunaID">Id-ul lunii</param>
		/// <remarks>
		/// Added:       Cristina Raluca Muntean
		/// Date:        13.09.2005
		/// </remarks>
		public void CreateAngajatiSelectBoxPeLuna(DropDownList listObj, int angajatorID, int lunaID)
		{
			try
			{
				Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
				angajat.AngajatorId = angajatorID;
				DataSet ds = angajat.GetAllAngajatiDinLuna(lunaID);
			
				DataTable myTable = new DataTable();
				myTable = ds.Tables[0];
				listObj.Items.Clear();			
				for (int i=0; i<myTable.Rows.Count; i++)
				{
					DataRow myRow = myTable.Rows[i];
					ListItem myItem = new ListItem(myRow["NumeIntreg"].ToString(), myRow["AngajatID"].ToString());
					listObj.Items.Add(myItem);	
				}
			}
			catch{}
		}
		#endregion

		#region CreateAngajatiSelectBox
		/// <summary>
		/// Procedura creaza lista cu angajati
		/// </summary>
		/// <param name="listObj">Lista care va contine angajatii</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		public void CreateAngajatiSelectBox(DropDownList listObj, int angajatorID)
		{
			/*Modificat:Muntean Raluca Cristina  
			DataSet-ul contine numele intregi si id-urile angajatilor activi, care au fost angajati
			in luna curenta sau intr-o luna anterioara acesteia, angajatii apartin de angajatorul
			cu id-ul trimis ca parametru*/
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.AngajatorId = angajatorID;
			angajat.CategorieId = -1;
			DataSet ds = angajat.GetAllAngajati();
			DataTable myTable = new DataTable();
			myTable = ds.Tables[0];
			listObj.Items.Clear();			
			for (int i=0; i<myTable.Rows.Count; i++)
			{
				DataRow myRow = myTable.Rows[i];
				ListItem myItem = new ListItem(myRow["NumeIntreg"].ToString(), myRow["AngajatID"].ToString());
				listObj.Items.Add(myItem);	
			}
		}
		#endregion

		#region CreateAngajatiSelectBoxEx
		/// <summary>
		/// Functia creaza un dropdown cu angajatii si mai are o optiune "Nu este angajat al firmei"
		/// </summary>
		/// <param name="listObj">Lista care va contine angajatii</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <remarks>
		/// Adaugat:	Ionel Popa
		/// </remarks>
		public void CreateAngajatiSelectBoxEx(DropDownList listObj, int angajatorID)
		{
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.AngajatorId = angajatorID;
			angajat.CategorieId = -1;
			DataSet ds = angajat.GetAllAngajati();

			DataTable myTable = new DataTable();
			myTable = ds.Tables[0];
			listObj.Items.Clear();
			ListItem myItem = new ListItem("NU ESTE ANGAJAT AL FIRMEI", "-1");
			listObj.Items.Add(myItem);
			for (int i=0; i<myTable.Rows.Count; i++)
			{
				DataRow myRow = myTable.Rows[i];
				myItem = new ListItem(myRow["NumeIntreg"].ToString(), myRow["AngajatID"].ToString());
				listObj.Items.Add(myItem);		
			}
		}
		#endregion

		#region CreateDepartamentAngajatiSelectBox
		/// <summary>
		/// Angajatii care apar in dropdown-urile de la departamente sa contina toti angajatii( indiferent daca sunt lichidati sau nu, activi sau nu, sau daca data angajarii e ulterioara)
		/// </summary>
		/// <param name="listObj">Lista care va contine departamentele</param>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <remarks>
		/// Adaugat:	Ionel Popa
		/// </remarks>
		public void CreateDepartamentAngajatiSelectBox(DropDownList listObj, int angajatorID)
		{
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.AngajatorId = angajatorID;
			angajat.CategorieId = -2;
			DataSet ds = angajat.GetAllAngajati();

			DataTable myTable = new DataTable();
			myTable = ds.Tables[0];
			listObj.Items.Clear();			
			for (int i=0; i<myTable.Rows.Count; i++)
			{
				DataRow myRow = myTable.Rows[i];
				ListItem myItem = new ListItem(myRow["NumeIntreg"].ToString(), myRow["AngajatID"].ToString());
				listObj.Items.Add(myItem);			
			}			
		}
		#endregion

		#region CreateAngajatiPeDeptSelectBox
		/// <summary>
		/// Selecteaza toti angajatii dintr-un departament si ii afiseaza intr-un dropdown
		/// </summary>
		/// <param name="listObj">Lista care va contine angajatii</param>
		/// <param name="NumeDept">Numele departamentului</param>
		public void CreateAngajatiPeDeptSelectBox(DropDownList listObj,string NumeDept)
		{
			SqlCommand SqlComm=new SqlCommand();
			SqlComm.CommandType=CommandType.StoredProcedure;
			SqlComm.CommandText="EGetAngajatifromDept";
			SqlComm.Parameters.Add("@NumeDept",SqlDbType.VarChar,10);
			SqlComm.Parameters["@NumeDept"].Value=NumeDept;
			DataSet ds = CreateDataSet(SqlComm);
			listObj.Items.Clear();			
			for (int i=0; i<ds.Tables[0].Rows.Count; i++)
			{
				DataRow myRow = ds.Tables[0].Rows[i];
				ListItem myItem = new ListItem(myRow["NumeIntreg"].ToString(), myRow["AngajatID"].ToString());
				listObj.Items.Add(myItem);			
			}
		}
		#endregion
		
		#region CreateAngajatiSiVidSelectBox
		/// <summary>
		/// Procedura creaza lista cu angajati
		/// </summary>
		/// <param name="listObj">Lista care va contine angajatii</param>
		public void CreateAngajatiSiVidSelectBox(DropDownList listObj)
		{			
			Salaries.Business.Angajat objAngajati = new Salaries.Business.Angajat();
			DataSet ds = objAngajati.GetAllAngajatiNumeIntregUnion();
			
			DataTable myTable = new DataTable();
			myTable = ds.Tables[0];
			listObj.Items.Clear();			
			for (int i=0; i<myTable.Rows.Count; i++)
			{
				DataRow myRow = myTable.Rows[i];
				ListItem myItem = new ListItem(myRow["NumeIntreg"].ToString(), myRow["AngajatID"].ToString());
				listObj.Items.Add(myItem);			
			}	
		}
		#endregion

		#region CreateInternalTrainingSelectBox
		/// <summary>
		/// Procedura creaza lista cu training-urile interne
		/// </summary>
		/// <param name="listObj">Lista care va contine training-urile</param>
		public void CreateInternalTrainingSelectBox(DropDownList listObj)
		{
			Salaries.Business.AdminTraining training = new Salaries.Business.AdminTraining();
			training.Intern = true;
			DataSet ds = training.LoadInfoTraininguri();

			DataTable myTable = new DataTable();
			myTable = ds.Tables[0];
			listObj.Items.Clear();			
			for (int i=0; i<myTable.Rows.Count; i++)
			{
				DataRow myRow = myTable.Rows[i];
				ListItem myItem = new ListItem(myRow["Nume"].ToString(), myRow["TrainingID"].ToString());
				listObj.Items.Add(myItem);		
			}
		}
		#endregion

		#region CreateExternalTrainingSelectBox
		/// <summary>
		/// Procedura creaza lista cu training-urile externe
		/// </summary>
		/// <param name="listObj">Lista care va contine training-urile</param>
		public void CreateExternalTrainingSelectBox(DropDownList listObj)
		{
			Salaries.Business.AdminTraining training = new Salaries.Business.AdminTraining();
			training.Intern = false;
			DataSet ds = training.LoadInfoTraininguri();

			DataTable myTable = new DataTable();
			myTable = ds.Tables[0];
			listObj.Items.Clear();			
			for (int i=0; i<myTable.Rows.Count; i++)
			{
				DataRow myRow = myTable.Rows[i];
				ListItem myItem = new ListItem(myRow["Nume"].ToString(), myRow["TrainingID"].ToString());
				listObj.Items.Add(myItem);			
			}
		}
		#endregion

		#region CreateDataSet
		/// <summary>
		/// Procedura creaza un DataSet
		/// </summary>
		/// <param name="sqlCommand">Comanda SQL</param>
		/// <returns>Returneaza un DataSet care contine datele</returns>
		public DataSet CreateDataSet(string sqlCommand)
		{
			SqlDataAdapter m_adaptor;
			m_adaptor = new SqlDataAdapter(sqlCommand, m_sqlConn);
			DataSet ds = new DataSet();
			m_adaptor.Fill(ds);

			return ds;
		}
		#endregion

		#region CreateDataSet
		/// <summary>
		/// Procedura creaza un DataSet
		/// </summary>
		/// <param name="sqlCommand">Comanda SQL</param>
		/// <returns>Returneaza un DataSet care contine datele</returns>
		public DataSet CreateDataSet(SqlCommand sqlCommand)
		{
			SqlDataAdapter m_adaptor;
			if(sqlCommand.Connection==null)
			{
				sqlCommand.Connection=m_sqlConn;
			}
			m_adaptor = new SqlDataAdapter(sqlCommand);
			DataSet ds = new DataSet();
			m_adaptor.Fill(ds);

			return ds;
		}
		#endregion

		#region ExecuteScalar
		/// <summary>
		/// Procedura executa o comanda SQL
		/// </summary>
		/// <param name="sqlCommand">Comanda SQL</param>
		/// <returns>Returneaza rezultatul obtinut</returns>
		public object ExecuteScalar(string sqlCommand)
		{
			m_sqlConn.Open();
			SqlCommand myCommand = new SqlCommand(sqlCommand, m_sqlConn);
			object obj = myCommand.ExecuteScalar();
			m_sqlConn.Close();
			if (obj!=System.DBNull.Value)
				return obj;
			else
				return null;
		}
		#endregion

		#region AddInputParameter
		/// <summary>
		/// Procedura adauga un parametru de intrare
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <param name="paramValue">Valoarea parametrului</param>
		/// <returns>Returneaza parametrul creat</returns>
		static public SqlParameter AddInputParameter( string paramName, SqlDbType paramType, int paramSize, string paramValue)
		{
			SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
			param.Direction = ParameterDirection.Input;
			param.Value = paramValue;

			return param;
		}
		#endregion

		#region AddOutputParameter
		/// <summary>
		/// Procedura creaza un parametru de iesire
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrilor</param>
		/// <returns>Returneaza parametrul creat</returns>
		static public SqlParameter AddOutputParameter( string paramName, SqlDbType paramType, int paramSize)
		{
			SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
			param.Direction = ParameterDirection.Output;
		
			return param;
		}
		#endregion

		#region AddInputParameter
		/// <summary>
		/// Procedura creaza un parametru de intrare
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <returns>Returneaza parametru creat</returns>
		static public  SqlParameter AddInputParameter( string paramName, SqlDbType paramType, int paramSize)
		{
			SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
			param.Direction = ParameterDirection.Input;
			return param;
		}
		#endregion

		#region AddInputParameter
		/// <summary>
		/// Procedura creaza un parametru de intrare
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <param name="paramValue">Valoarea parametrului</param>
		/// <returns>Returneaza parametrul creat</returns>
		static public SqlParameter AddInputParameter( string paramName, SqlDbType paramType, int paramSize, int paramValue)
		{
			SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
			param.Direction = ParameterDirection.Input;
			param.Value = paramValue;

			return param;
		}
		#endregion

		#region AddInputParameter
		/// <summary>
		/// Procedura creaza un parametru de intrare
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <param name="paramValue">Valoarea parametrului</param>
		/// <returns>Returneaza parametrul creat</returns>
		static public SqlParameter AddInputParameter( string paramName, SqlDbType paramType, int paramSize, bool paramValue)
		{
			SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
			param.Direction = ParameterDirection.Input;
			param.Value = paramValue;

			return param;
		}
		#endregion

		#region AddInputParameter
		/// <summary>
		/// Procedura creaza un parametru de intrare
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <param name="paramValue">Valoarea parametrului</param>
		/// <returns>Returneaza parametrul creat</returns>
		static public  SqlParameter AddInputParameter( string paramName, SqlDbType paramType, int paramSize, byte[] paramValue)
		{
			SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
			param.Direction = ParameterDirection.Input;
			param.Value = paramValue;

			return param;
		}
		#endregion

		#region AddInputParameter
		/// <summary>
		/// Procedura adauga un parametru de intrare
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <param name="paramValue">Valoarea parametrului</param>
		/// <returns></returns>
		static public  SqlParameter AddInputParameter( string paramName, SqlDbType paramType, int paramSize, double paramValue)
		{
			SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
			param.Direction = ParameterDirection.Input;
			param.Value = paramValue;

			return param;
		}
		#endregion

		#region AddInputParameter
		/// <summary>
		/// Procedura creaza un parametru de intrare
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <param name="paramValue">Valoarea parametrului</param>
		/// <returns>Returneaza parametrul creat</returns>
		static public SqlParameter AddInputParameter( string paramName, SqlDbType paramType, int paramSize, DateTime paramValue)
		{
			SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
			param.Direction = ParameterDirection.Input;
			if (paramValue != DateTime.MinValue)
				param.Value = paramValue;
			else
				param.Value = System.DBNull.Value;

			return param;
		}
		#endregion

		#region AddNULLParameter
		/// <summary>
		/// Procedura creaza un parametru cu valoarea null
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <returns></returns>
		static public  SqlParameter AddNULLParameter( string paramName, SqlDbType paramType, int paramSize)
		{
			SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
			param.Direction = ParameterDirection.Input;
			param.Value = System.DBNull.Value;

			return param;
		}
		#endregion
	}
}
