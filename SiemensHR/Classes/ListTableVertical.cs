using System;
using System.Data;
using System.Web.UI.WebControls;
using SiemensHR.utils;
using System.Globalization;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for ListTable.
	/// </summary>
	public class ListTableVertical
	{
		#region Atribute private
		private string[] tableHeader;
		private string[] tableRows;
		private string[] m_OnclickParams;
		private string[] m_OnclickParamsType;
		private string m_OnclickJSMethod;
		private DataSet m_ds;
		private bool m_hasCounter;
		private bool m_hasSeparator;
		private Table m_table;
		private string m_textForEmptyDataSet;
		private int numRowsInDataSet;
		//Adaugat:		Oprescu Claudia
		//Descriere:	Sirul specifica randurile care vor aparea in tabel
		private bool[] tableHeaderVisible;
		#endregion
		
		#region Proprietati
		public int NumRowsInDataSet
		{
			get
			{
				return this.numRowsInDataSet;
			}
		}
		
		public string OnclickJSMethod
		{
			get { return m_OnclickJSMethod;}
			set { m_OnclickJSMethod = value;}
		}

		
		public string[] OnclickParamsType
		{
			get { return m_OnclickParamsType;}
			set { m_OnclickParamsType = value; }
		}

		public string[] OnclickParams
		{
			get { return m_OnclickParams;}
			set { m_OnclickParams = value; }
		}

		public string textForEmptyDataSet
		{
			get {return m_textForEmptyDataSet;}
			set { m_textForEmptyDataSet = value;}
		}

		public bool hasCounter
		{
			get {return m_hasCounter;}
			set { m_hasCounter = value;}
		}

		public bool hasSeparator
		{
			get {return m_hasSeparator;}
			set { m_hasSeparator = value;}
		}
		#endregion
		
		#region ListTableVertical
		/// <summary>
		/// Procedura creaza un tabel vertival
		/// </summary>
		/// <param name="destTable"></param>
		/// <param name="ds"></param>
		/// <param name="arrayHeader">Denumirile coloanelor</param>
		/// <param name="arrayRows">Denumirile randurilor</param>
		public ListTableVertical(Table destTable, DataSet ds, string[] arrayHeader, string[] arrayRows)
		{
			tableHeader = arrayHeader;
			tableRows = arrayRows;
			m_hasCounter = hasCounter;
			m_ds = ds;
			m_table = destTable;
			m_hasCounter = true;
			m_hasSeparator = true;
			m_OnclickParams = new string[0];
			m_OnclickParamsType = new string[0];
			this.numRowsInDataSet = ds.Tables[0].Rows.Count;

			//La incaput toate randurile apar si sunt setate valorile true
			tableHeaderVisible = new bool[arrayHeader.Length];
			for (int i=0; i<arrayHeader.Length; i++)
				tableHeaderVisible[i] = true;
		}
		#endregion

		#region DrawListTableWithDigits
		/// <summary>
		/// Metoda este folosita pentru a completa un tabel cu datele din baza de date. Aceasta metoda va afisa valorile numerice cu zecimale. 
		/// Numarul de zecimale care se va afisa este preluat din web.config
		/// </summary>
		public void DrawListTableWithDigits()
		{
			TableCell tmpCell;
			TableRow tmpRow;
			//m_table.Style.Add("border", "1px solid #20b2aa");
			m_table.Attributes.Add("cellpadding","0");
			m_table.Attributes.Add("cellspacing","1");
			m_table.Attributes.Add("bgColor", "#20b2aa");
			m_table.Rows.Clear();

			//Oprescu Claudia
			//Daca tabelul are o singura coloana atunci angajatul este lichidat la data de 1 a lunii curente
			//altfel se genereaza situatia lui lunara
			if (tableHeader.Length == 1)
			{
				tmpRow = new TableRow();
				tmpCell = new TableCell();
				tmpCell.CssClass = "NormalGreenBoldVerticalTableAlignCenter";
				tmpCell.Attributes.Add("width", "600");
				tmpCell.Text = tableHeader[0];
				tmpRow.Cells.Add(tmpCell);
				m_table.Rows.Add(tmpRow);
			}
			else
			{
				//-------------------se creaza header-ul tabelului------------------	
				if (m_hasCounter)
				{
					tmpRow = new TableRow();
					tmpCell = new TableCell();
					tmpCell.CssClass = "NormalGreenBoldVerticalTable";
					tmpCell.Attributes.Add("width", "30");
					tmpCell.Text = "Nr.";
					tmpRow.Cells.Add(tmpCell);
					m_table.Rows.Add(tmpRow);
				}
			
				for(int i = 0; i < this.tableHeader.Length; i++)
				{
					tmpRow = new TableRow();
					tmpCell = new TableCell();
					tmpCell.CssClass = "NormalGreenBoldVerticalTable";
					tmpCell.Text = tableHeader[i];
					tmpRow.Cells.Add(tmpCell);
					//Daca un rand are denumire atunci apare in tabel. In caz contrar nu si se schimba valoarea asociata la false
					if (tableHeader[i] != "")
						m_table.Rows.Add(tmpRow);
					else
						tableHeaderVisible[i] = false;
					//m_table.Rows.Add(this.CreateSeparatorLine());
			
				}

				//------------------------------------------------------------------

				//-------------------se creaza coloanele cu date--------------------
				for(int rowCount = 0; rowCount < m_ds.Tables[0].Rows.Count; rowCount++)
				{
					string[] theData;
					theData = FillTableFromDataSet(rowCount, Salaries.Business.VariabileGlobale.numberInfoFormatWithDigits);
					for(int i = 0; i < theData.Length; i++)
					{	
						tmpCell = new TableCell();
						tmpCell.Text = theData[i];
						tmpCell.CssClass = "NormalBlackVerticalTable";
						m_table.Rows[i].Cells.Add(tmpCell);
					}
					//if (m_hasSeparator)
					//	m_table.Rows[0].Cells.Add(CreateSeparatorColumn());
				}

				if (m_ds.Tables[0].Rows.Count==0)
				{
					m_table.Rows[0].Cells.Add(CreateEmptyMessageCell());
				}
			}
		}
		#endregion

		#region DrawListTableWithDigits
		/// <summary>
		/// Procedura creaza un tabel in care campurile numerice sunt afisate cu un anumit numar de zecimale
		/// </summary>
		/// <param name="nrZecimale">Numarul de zecimale care apar pe interfata</param>
		public void DrawListTableWithDigits(int nrZecimale)
		{
			NumberFormatInfo numberOfDigits = new CultureInfo("ro-RO", false).NumberFormat;
			numberOfDigits.NumberDecimalDigits = nrZecimale;

			TableCell tmpCell;
			TableRow tmpRow;
			//m_table.Style.Add("border", "1px solid #20b2aa");
			m_table.Attributes.Add("cellpadding","0");
			m_table.Attributes.Add("cellspacing","1");
			m_table.Attributes.Add("bgColor", "#20b2aa");
			m_table.Rows.Clear();

			//Oprescu Claudia
			//Daca tabelul are o singura coloana atunci angajatul este lichidat la data de 1 a lunii curente
			//altfel se genereaza situatia lui lunara
			if (tableHeader.Length == 1)
			{
				tmpRow = new TableRow();
				tmpCell = new TableCell();
				tmpCell.CssClass = "NormalGreenBoldVerticalTableAlignCenter";
				tmpCell.Attributes.Add("width", "600");
				tmpCell.Text = tableHeader[0];
				tmpRow.Cells.Add(tmpCell);
				m_table.Rows.Add(tmpRow);
			}
			else
			{
				//-------------------se creaza header-ul tabelului------------------	
				if (m_hasCounter)
				{
					tmpRow = new TableRow();
					tmpCell = new TableCell();
					tmpCell.CssClass = "NormalGreenBoldVerticalTable";
					tmpCell.Attributes.Add("width", "30");
					tmpCell.Text = "Nr.";
					tmpRow.Cells.Add(tmpCell);
					m_table.Rows.Add(tmpRow);
				}
			
				for(int i = 0; i < this.tableHeader.Length; i++)
				{
					tmpRow = new TableRow();
					tmpCell = new TableCell();
					tmpCell.CssClass = "NormalGreenBoldVerticalTable";
					tmpCell.Text = tableHeader[i];
					tmpRow.Cells.Add(tmpCell);
					//Daca un rand are denumire atunci apare in tabel. In caz contrar nu si se schimba valoarea asociata la false
					if (tableHeader[i] != "")
						m_table.Rows.Add(tmpRow);
					else
						tableHeaderVisible[i] = false;
					//m_table.Rows.Add(this.CreateSeparatorLine());
			
				}

				//------------------------------------------------------------------

				//-------------------se creaza coloanele cu date--------------------
				for(int rowCount = 0; rowCount < m_ds.Tables[0].Rows.Count; rowCount++)
				{
					string[] theData;
					theData = FillTableFromDataSet(rowCount, numberOfDigits);
					for(int i = 0; i < theData.Length; i++)
					{	
						tmpCell = new TableCell();
						tmpCell.Text = theData[i];
						tmpCell.CssClass = "NormalBlackVerticalTable";
						m_table.Rows[i].Cells.Add(tmpCell);
					}
					//if (m_hasSeparator)
					//	m_table.Rows[0].Cells.Add(CreateSeparatorColumn());
				}

				if (m_ds.Tables[0].Rows.Count==0)
				{
					m_table.Rows[0].Cells.Add(CreateEmptyMessageCell());
				}
			}
		}
		#endregion

		#region DrawListTableWithoutDigits
		/// <summary>
		/// Metoda este folosita pentru a completa un tabel cu datele din baza de date. Aceasta metoda va afisa valorile numerice fara zecimale. 
		/// </summary>
		public void DrawListTableWithoutDigits()
		{
			TableCell tmpCell;
			TableRow tmpRow;
			//m_table.Style.Add("border", "1px solid #20b2aa");
			m_table.Attributes.Add("cellpadding","0");
			m_table.Attributes.Add("cellspacing","1");
			m_table.Attributes.Add("bgColor", "#20b2aa");
			m_table.Rows.Clear();

			//Oprescu Claudia
			//Daca tabelul are o singura coloana atunci angajatul este lichidat la data de 1 a lunii curente
			//altfel se genereaza situatia lui lunara
			if (tableHeader.Length == 1)
			{
				tmpRow = new TableRow();
				tmpCell = new TableCell();
				tmpCell.CssClass = "NormalGreenBoldVerticalTableAlignCenter";
				tmpCell.Attributes.Add("width", "600");
				tmpCell.Text = tableHeader[0];
				tmpRow.Cells.Add(tmpCell);
				m_table.Rows.Add(tmpRow);
			}
			else
			{
				//-------------------se creaza header-ul tabelului------------------	
				if (m_hasCounter)
				{
					tmpRow = new TableRow();
					tmpCell = new TableCell();
					tmpCell.CssClass = "NormalGreenBoldVerticalTable";
					tmpCell.Attributes.Add("width", "30");
					tmpCell.Text = "Nr.";
					tmpRow.Cells.Add(tmpCell);
					m_table.Rows.Add(tmpRow);	
				}
			
				for(int i = 0; i < this.tableHeader.Length; i++)
				{
					tmpRow = new TableRow();
					tmpCell = new TableCell();
					tmpCell.CssClass = "NormalGreenBoldVerticalTable";
					tmpCell.Text = tableHeader[i];
					tmpRow.Cells.Add(tmpCell);
					//Daca un rand are denumire atunci apare in tabel. In caz contrar nu si se schimba valoarea asociata la false
					if (tableHeader[i] != "")
						m_table.Rows.Add(tmpRow);
					else
						tableHeaderVisible[i] = false;
					//m_table.Rows.Add(this.CreateSeparatorLine());
				}

				//------------------------------------------------------------------

				//-------------------se creaza coloanele cu date--------------------
				for(int rowCount = 0; rowCount < m_ds.Tables[0].Rows.Count; rowCount++)
				{
					string[] theData;
					theData = FillTableFromDataSet(rowCount, Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits);
					for(int i = 0; i < theData.Length; i++)
					{	
						tmpCell = new TableCell();
						tmpCell.Text = theData[i];
						tmpCell.CssClass = "NormalBlackVerticalTable";
						m_table.Rows[i].Cells.Add(tmpCell);
						//if (m_hasSeparator)
						//	m_table.Rows[0].Cells.Add(CreateSeparatorColumn());
					}
				}

				if (m_ds.Tables[0].Rows.Count==0)
				{
					m_table.Rows[0].Cells.Add(CreateEmptyMessageCell());
				}
			}
		}
		#endregion

		#region GetColumnsNumber
		/// <summary>
		/// Procedura determina nr de coloane
		/// </summary>
		/// <returns>Returneaza nr de coloane</returns>
		private int GetColumnsNumber()
		{
			if (m_hasCounter)
			{
				return tableHeader.Length+1;
			}
			else
			{
				return tableHeader.Length;
			}
		}
		#endregion

		#region CreateEmptyMessageCell
		/// <summary>
		/// Creeaza linia cu mesajul ptr. Dataset gol
		/// </summary>
		/// <returns>Returneaza o celula goala</returns>
		private TableCell CreateEmptyMessageCell()
		{
			TableCell tmpCell = new TableCell();;
			tmpCell.CssClass = "NormalBlackVerticalTable";
			tmpCell.RowSpan = (m_hasCounter ? (tableRows.Length+1) : tableRows.Length);
			tmpCell.Text = m_textForEmptyDataSet;
			tmpCell.Attributes.Add("width", "270");
			tmpCell.Attributes.Add("height", "100%");
			tmpCell.Attributes.Add("align", "center");
			return tmpCell;
		}
		#endregion

		#region FillTableFromDataSet
		/// <summary>
		/// Creeaza un string array cu inregistrari din dataset
		/// </summary>
		/// <param name="rowIndex">Nr inregistrarii</param>
		/// <param name="numberFormatInfo">Se formateaza valorile numerice</param>
		/// <returns></returns>
		private string[] FillTableFromDataSet(int rowIndex, NumberFormatInfo numberFormatInfo)
		{
			string[] tmpString = new string[this.m_table.Rows.Count];
			int i=0;
            if (m_hasCounter)
			{
				// adauga celula de nr. crt.
				tmpString[i] = (rowIndex+1).ToString();
				i=1;
			}

			int colNr = 0;
			//for (int j = i; j < this.tableRows.Length+i; j++)

			//Este parcurs sirul de etichete care ar trebui sa apara in tabel
			for (int j = 0; j < this.tableRows.Length; j++)
			{
				//Daca o eticheta poate aparea in tabel atunci se aduga un rand pentru ea
				if (tableHeaderVisible[j])
				{
					// adauga fiecare celula conform arrayului de coloane
					switch (m_ds.Tables[0].Rows[rowIndex][tableRows[j]].GetType().ToString())
					{						
						case "System.Boolean":
							tmpString[colNr+i] = Boolean.Parse(m_ds.Tables[0].Rows[rowIndex][tableRows[j]].ToString())==true?"Da":"Nu";
							break;
						case "System.DateTime":
							tmpString[colNr+i] = Utilities.ConvertDateTime2Text(Convert.ToDateTime(m_ds.Tables[0].Rows[rowIndex][tableRows[j]]));
							break;
						case "System.Decimal":
							//Lungu Andreea - 30 august 2010  - to do - pt nr fara zecimale sa nu imi afiseze zecimalele
							tmpString[colNr+i] = decimal.Parse(m_ds.Tables[0].Rows[rowIndex][tableRows[j]].ToString()).ToString("N",numberFormatInfo);
							break;
						case "System.Float":
							tmpString[colNr+i] = float.Parse(m_ds.Tables[0].Rows[rowIndex][tableRows[j]].ToString()).ToString("N",numberFormatInfo);					
							break;
						case "System.Double":
							tmpString[colNr+i] = double.Parse(m_ds.Tables[0].Rows[rowIndex][tableRows[j]].ToString()).ToString("N",numberFormatInfo);					
							break;
						case "System.Single":
							tmpString[colNr+i] = Single.Parse(m_ds.Tables[0].Rows[rowIndex][tableRows[j]].ToString()).ToString("N",numberFormatInfo);					
							break;
						default:
							tmpString[colNr+i] = m_ds.Tables[0].Rows[rowIndex][tableRows[j]].ToString();
							break;
					}colNr++;
				}
				
			}
			return tmpString;
		}
		#endregion

		#region GetJSParamFromDataSet
		/// <summary>
		/// Procedura obtine parametrii de tip JS dintr-un DataSet
		/// </summary>
		/// <param name="rowIndex">Nr inregistrarii</param>
		/// <param name="paramIndex">Nr parametrului</param>
		/// <returns>Returneaza valoarea parametrului</returns>
		private string GetJSParamFromDataSet( int rowIndex, int paramIndex )
		{
			string tmpStr = "";
			switch ( m_ds.Tables[0].Rows[rowIndex][m_OnclickParams[paramIndex]].GetType().ToString())
			{
				case "System.DateTime":
					tmpStr =  Utilities.ConvertDateTime2Text(Convert.ToDateTime(m_ds.Tables[0].Rows[rowIndex][m_OnclickParams[paramIndex]]));
					break;
				default:
					tmpStr = m_ds.Tables[0].Rows[rowIndex][m_OnclickParams[paramIndex]].ToString();
					break;
			}
			return tmpStr;
		}
		#endregion

		#region GetJSParamsList
		/// <summary>
		/// Procedura returneaza un parametru de tip JS din lista
		/// </summary>
		/// <param name="rowIndex">Nr parametrului returnat</param>
		/// <returns>Returneaza valoarea parametrului</returns>
		public string GetJSParamsList( int rowIndex )
		{
			string paramStr = "";

			for(int i=0; i<m_OnclickParams.Length; i++)
			{
				switch (m_OnclickParamsType[i])
				{
					case "dataset":
						paramStr += "'" + GetJSParamFromDataSet(rowIndex, i) + "',";
						break;
					case "const":
						paramStr += "'" + m_OnclickParams[i] + "',";
						break;
				}
			}
			if (paramStr!="")
				paramStr = paramStr.Substring(0, paramStr.Length-1);
			return paramStr;
		}
		#endregion
		
		#region CreateSeparatorColumn
		/// <summary>
		/// Se adauga coloana de separare
		/// </summary>
		/// <returns>Returneaza o inregistrare din tabel</returns>
		private TableCell CreateSeparatorColumn()
		{
			TableCell myCell = new TableCell();
			myCell.CssClass = "GreenSeparator";
			myCell.RowSpan = (m_hasCounter ? (tableRows.Length+1) : tableRows.Length);
			myCell.Text = "<img src=\"images/1x1.gif\" height=1>";
			myCell.Attributes.Add("align", "center");
			return myCell;
		}
		#endregion

		#region CreateSeparatorLine
		/// <summary>
		/// Se adauga linia de separare
		/// </summary>
		/// <returns>Returneaza o inregistrare din tabel</returns>
		private TableRow CreateSeparatorLine()
		{
			TableRow myRow = new TableRow();
			TableCell myCell = new TableCell();
			myCell.CssClass = "GreenSeparator";
			myCell.ColumnSpan = this.m_ds.Tables[0].Rows.Count+1;
			myCell.Text = "<img src=\"images/1x1.gif\" height=1>";
			myCell.Attributes.Add("align", "center");
			myRow.Cells.Add(myCell);
			return myRow;
		}
		#endregion
	}
}
