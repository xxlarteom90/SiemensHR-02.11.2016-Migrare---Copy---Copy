using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;
using SiemensTM.Classes;

namespace SiemensTM.utils
{
	/// <summary>
	/// Summary description for Utilities.
	/// </summary>
	public class UtilitiesDb
	{
		#region Variabile
		private string m_strConn;
		private SqlConnection  m_sqlConn;
		#endregion

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
		/// <param name="strConnection"></param>
		public UtilitiesDb(string strConnection)
		{
			strConn = strConnection;
			m_sqlConn = new SqlConnection(strConn);
		}
		#endregion

		#region CreateTipIntervaleSelectBox
		/// <summary>
		/// Creaza lista cu tipuri de intervale
		/// </summary>
		/// <param name="listObj"></param>
		/// <param name="AngajatID"></param>
		/// <param name="SelectedDate"></param>
		/// <param name="addComponent"></param>
		public void CreateTipIntervaleSelectBox(DropDownList listObj, long AngajatID, DateTime SelectedDate, bool addComponent)
		{
			TipuriIntervale tipuri = new TipuriIntervale();
			DataSet ds = tipuri.GetTipuriIntervale();
			DataTable myTable = new DataTable();
			myTable = ds.Tables[0];
			listObj.Items.Clear();			
			for (int i=0; i<myTable.Rows.Count; i++)
			{
				double nrOreLucrateSapt = new SiemensTM.Classes.IntervaleAngajat( AngajatID ).GetNrOreLucrateSaptamanaByDataInside( Utilities.ConvertToShort(SelectedDate), int.Parse( myTable.Rows[ i ][ "TipIntervalID" ].ToString()));
				double valMax = int.Parse( new SiemensTM.Classes.TipuriIntervale().GetTipInterval( int.Parse( myTable.Rows[ i ][ "TipIntervalID" ].ToString())).Tables[ 0 ].Rows[ 0 ][ "NrMaximOreSapt" ].ToString());
				
				if( nrOreLucrateSapt < valMax || !addComponent )
				{
					DataRow myRow = myTable.Rows[i];
					ListItem myItem = new ListItem(myRow["Denumire"].ToString(), myRow["TipIntervalID"].ToString());
					listObj.Items.Add(myItem);
				}		
			}
		}
		#endregion

		#region CreateTipIntervaleNestandardSelectBox
		/// <summary>
		/// Creaza lista cu tipuri de intervale nestandard
		/// </summary>
		/// <param name="listObj"></param>
		public void CreateTipIntervaleNestandardSelectBox(DropDownList listObj)
		{
			TipuriIntervale tipuri = new TipuriIntervale();
			DataSet ds = tipuri.GetTipuriIntervaleNestandard();
			DataTable myTable = new DataTable();
			myTable = ds.Tables[0];
			listObj.Items.Clear();			
			for (int i=0; i<myTable.Rows.Count; i++)
			{
				DataRow myRow = myTable.Rows[i];
				ListItem myItem = new ListItem(myRow["Denumire"].ToString(), myRow["TipIntervalID"].ToString());
				listObj.Items.Add(myItem);		
			}
		}
		#endregion

		#region CreateTipAbsenteSelectBox
		/// <summary>
		/// Returneaza datele necesare pentru popularea ComboBoxului aferent tipurilor 
		/// de absente.
		/// </summary>
		/// <param name="listObj"> ComboBox-ul ce trebuie populat.</param>
		/// <remarks>
		/// Modificari:
		/// Autor: Cristina Raluca Muntean	
		/// Data: 29.06.2006
		/// Descriere: Se apeleaza metoda GetTipuriAbsenteLuna din clasa NomenclatorTipAbsente.
		/// </remarks>
		public void CreateTipAbsenteSelectBox(DropDownList listObj)
		{
			Salaries.Business.NomenclatorTipAbsente tipAbsente = new Salaries.Business.NomenclatorTipAbsente();
			// DataSet-ul ce contine tipurile de absente aferente lunii curente.
			// Exista absente, cum ar fi concediul de odihna de pe anul precedent, care
			// trebuie sa apara doar in luna ianuarie.
			DataSet dsTipAbsente = tipAbsente.GetTipuriAbsenteLunaCurenta();
			DataTable dataTable = new DataTable();
			dataTable = dsTipAbsente.Tables[0];
			listObj.Items.Clear();	
		
			for (int i=0; i<dataTable.Rows.Count; i++)
			{
				DataRow myRow = dataTable.Rows[i];
				ListItem listItem = new ListItem(myRow["Denumire"].ToString(), myRow["TipAbsentaID"].ToString());
				listObj.Items.Add(listItem);		
			}
		}
		#endregion

		#region GetConcediuOdihnaID
		/// <summary>
		/// Returneaza id-ul corespunzaor concediului de odihna
		/// </summary>
		/// <returns></returns>
		public int GetConcediuOdihnaID()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("tm_GetTipuriAbsenteCO", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			if(ds.Tables[0].Rows.Count > 0)
				return int.Parse(ds.Tables[0].Rows[0]["TipAbsentaID"].ToString());
			else 
				return -1;
		}
		#endregion

		#region GetConcediuOdihnaAnulPrecedentID
		/// <summary>
		/// Returneaza id-ul corespunzaor concediului de odihna
		/// </summary>
		/// <returns></returns>
		public int GetConcediuOdihnaAnulPrecedentID()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("tm_GetTipuriAbsenteCOA", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			if(ds.Tables[0].Rows.Count > 0)
				return int.Parse(ds.Tables[0].Rows[0]["TipAbsentaID"].ToString());
			else 
				return -1;
		}
		#endregion

		#region GetContinuareConcediuMedicalID
		/// <summary>
		/// Returneaza id-ul corespunzaor continuare concediu medical
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// Oprescu Claudia
		/// </remarks>
		public int GetContinuareConcediuMedicalID()
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("tm_GetTipuriAbsenteCCM", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			if(ds.Tables[0].Rows.Count > 0)
				return int.Parse(ds.Tables[0].Rows[0]["TipAbsentaID"].ToString());
			else 
				return -1;
		}
		#endregion

		#region CreateTipBoliSelectBox
		/// <summary>
		/// Creaza lista cu tipuri de boli
		/// </summary>
		/// <param name="listObj"></param>
		public void CreateTipBoliSelectBox(DropDownList listObj)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetAllBoli", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			DataTable myTable = new DataTable();
			myTable = ds.Tables[0];
			listObj.Items.Clear();			
			for (int i=0; i<myTable.Rows.Count; i++)
			{
				DataRow myRow = myTable.Rows[i];
				ListItem myItem = new ListItem(myRow["CodCategorie"].ToString(), myRow["BoalaID"].ToString());
				listObj.Items.Add(myItem);			
			}
		}
		#endregion

		#region CreateDepartamenteSelectBox
		/// <summary>
		/// Creaza lista cu departamente
		/// </summary>
		/// <param name="parinte"></param>
		/// <param name="nivel"></param>
		/// <param name="listObj"></param>
		public void CreateDepartamenteSelectBox(int parinte, int nivel, DropDownList listObj)
		{	
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("GetDepartamente", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@DeptParinte", SqlDbType.Int, 4, parinte));
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			DataTable myTable = new DataTable();
			myTable = ds.Tables[0];
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

		#region CreateAngajatiSelectBox
		/// <summary>
		/// Creaza lista cu angajati
		/// </summary>
		/// <param name="listObj"></param>
		public void CreateAngajatiSelectBox(DropDownList listObj)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetAllAngajatiNumeIntreg", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

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
		/// Creaza lista cu training-uri interne
		/// </summary>
		/// <param name="listObj"></param>
		public void CreateInternalTrainingSelectBox(DropDownList listObj)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetTrainingDupaTip", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipTraining", SqlDbType.Int, 4, 1));
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
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
		/// Creaza lista cu training-uri externe
		/// </summary>
		/// <param name="listObj"></param>
		public void CreateExternalTrainingSelectBox(DropDownList listObj)
		{
			string connStr = Salaries.Configuration.ModuleConfig.GetSettings().ConnectionString;
			SqlConnection m_con = new SqlConnection(connStr);
			SqlCommand myCommand = new SqlCommand("spGetTrainingDupaTip", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@TipTraining", SqlDbType.Int, 4, 0));
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
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
		/// Executa o comanda SQL
		/// </summary>
		/// <param name="sqlCommand">Comanda executata</param>
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

		#region ExecuteScalar
		/// <summary>
		/// Executa o comanda SQL
		/// </summary>
		/// <param name="sqlCommand">Comanda executata</param>
		/// <returns>Returneaza rezultatul executiei</returns>
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
		/// Creaza un parametru de intrare
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <param name="paramValue">Valoara parametrului de tip string</param>
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
		/// Creaza un parametru de iesire
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <param name="paramValue">Valoara parametrului</param>
		/// <returns>Returneaza parametrul creat</returns>
		static public SqlParameter AddOutputParameter( string paramName, SqlDbType paramType, int paramSize, string paramValue)
		{
			SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
			param.Direction = ParameterDirection.Output;
			param.Value = paramValue;
			return param;
		}
		#endregion

		#region AddInputParameter
		/// <summary>
		/// Creaza un parametru de intrare
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <returns>Returneaza parametrul creat</returns>
		static public  SqlParameter AddInputParameter( string paramName, SqlDbType paramType, int paramSize)
		{
			SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
			param.Direction = ParameterDirection.Input;
			return param;
		}
		#endregion

		#region AddInputParameter
		/// <summary>
		/// Creaza un parametru de intrare
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <param name="paramValue">Valoara parametrului de tip int</param>
		/// <returns>Returneaza parametrul creat</returns>
		static public  SqlParameter AddInputParameter( string paramName, SqlDbType paramType, int paramSize, int paramValue)
		{
			SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
			param.Direction = ParameterDirection.Input;
			param.Value = paramValue;
			return param;
		}
		#endregion

		#region AddInputParameter
		/// <summary>
		/// Creaza un parametru de intrare
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <param name="paramValue">Valoara parametrului de tip boolean</param>
		/// <returns>Returneaza parametrul creat</returns>
		static public  SqlParameter AddInputParameter( string paramName, SqlDbType paramType, int paramSize, bool paramValue)
		{
			SqlParameter param = new SqlParameter(paramName, paramType, paramSize);
			param.Direction = ParameterDirection.Input;
			param.Value = paramValue;
			return param;
		}
		#endregion
		
		#region AddInputParameter
		/// <summary>
		/// Creaza un parametru de intrare
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <param name="paramValue">Valoara parametrului de tip byte[]</param>
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
		/// Creaza un parametru de intrare
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <param name="paramValue">Valoara parametrului de tip double</param>
		/// <returns>Returneaza parametrul creat</returns>
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
		/// Creaza un parametru de intrare
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <param name="paramValue">Valoara parametrului de tip data</param>
		/// <returns>Returneaza parametrul creat</returns>
		static public  SqlParameter AddInputParameter( string paramName, SqlDbType paramType, int paramSize, DateTime paramValue)
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
		/// Creaza un parametru cu valoarea null
		/// </summary>
		/// <param name="paramName">Numele parametrului</param>
		/// <param name="paramType">Tipul parametrului</param>
		/// <param name="paramSize">Dimensiunea parametrului</param>
		/// <returns>Returneaza parametrul creat</returns>
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
