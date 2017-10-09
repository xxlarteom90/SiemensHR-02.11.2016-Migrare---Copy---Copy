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
	public class ListTable
	{
		#region Atribute private
		private string[] tableHeader;
		private string[] tableCols;
		private string[] m_OnclickParams;
		private string[] m_OnclickParamsType;
		private string m_OnclickJSMethod;

		private DataSet m_ds;
		private bool m_hasCounter;
		private bool m_hasSeparator;
		private Table m_table;
		private string m_textForEmptyDataSet;
		#endregion

		#region Proprietati
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

		#region ListTable
		/// <summary>
		/// Procedura afiseaza tabelul
		/// </summary>
		/// <param name="destTable"></param>
		/// <param name="ds">DataSet care contine datele</param>
		/// <param name="arrayHeader">Capul de tabel</param>
		/// <param name="arrayColumns">Sirul de coloane</param>
		public ListTable(Table destTable, DataSet ds, string [] arrayHeader, string[] arrayColumns)
		{
			tableHeader = arrayHeader;
			tableCols = arrayColumns;
			m_hasCounter = hasCounter;
			m_ds = ds;
			m_table = destTable;
			m_hasCounter = true;
			m_hasSeparator = true;
			m_OnclickParams = new string[0];
			m_OnclickParamsType = new string[0];
		}
		#endregion

		#region DrawListTableWithDigits
		/// <summary>
		/// Metoda este folosita pentru a completa un tabel cu datele din baza de date. Aceasta metoda va afisa valorile numerice cu zecimale. 
		/// Numarul de zecimale care se va afisa este preluat din web.config
		/// </summary>
		public void DrawListTableWithDigits()
		{
			m_table.Style.Add("border", "1px solid #20b2aa");
			m_table.Attributes.Add("cellpadding","0");
			m_table.Attributes.Add("cellspacing","1");
			m_table.Attributes.Add("bgColor", "#ffffff");

			m_table.Rows.Add(CreateTableListHeader());

			for(int rowCount=0; rowCount<m_ds.Tables[0].Rows.Count; rowCount++)
			{
				m_table.Rows.Add(FillTableFromDataSet(rowCount, Salaries.Business.VariabileGlobale.numberInfoFormatWithDigits));
				if (m_hasSeparator)
					m_table.Rows.Add(CreateSeparatorLine());
			}
			if (m_ds.Tables[0].Rows.Count==0)
			{
				m_table.Rows.Add(CreateEmptyMessageRow());
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

			m_table.Style.Add("border", "1px solid #20b2aa");
			m_table.Attributes.Add("cellpadding","0");
			m_table.Attributes.Add("cellspacing","1");
			m_table.Attributes.Add("bgColor", "#ffffff");

			m_table.Rows.Add(CreateTableListHeader());

			for(int rowCount=0; rowCount<m_ds.Tables[0].Rows.Count; rowCount++)
			{
				m_table.Rows.Add(FillTableFromDataSet(rowCount, numberOfDigits));
				if (m_hasSeparator)
					m_table.Rows.Add(CreateSeparatorLine());
			}
			if (m_ds.Tables[0].Rows.Count==0)
			{
				m_table.Rows.Add(CreateEmptyMessageRow());
			}
		}
		#endregion

		#region DrawListTableWithoutDigits
		/// <summary>
		/// Metoda este folosita pentru a completa un tabel cu datele din baza de date. Aceasta metoda va afisa valorile numerice fara zecimale. 
		/// </summary>
		public void DrawListTableWithoutDigits()
		{
			
			m_table.Style.Add("border", "1px solid #20b2aa");
			m_table.Attributes.Add("cellpadding","0");
			m_table.Attributes.Add("cellspacing","1");
			m_table.Attributes.Add("bgColor", "#ffffff");

			m_table.Rows.Add(CreateTableListHeader());

			for(int rowCount=0; rowCount<m_ds.Tables[0].Rows.Count; rowCount++)
			{
				m_table.Rows.Add(FillTableFromDataSet(rowCount, Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits));
				if (m_hasSeparator)
					m_table.Rows.Add(CreateSeparatorLine());
			}
			if (m_ds.Tables[0].Rows.Count==0)
			{
				m_table.Rows.Add(CreateEmptyMessageRow());
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

		#region CreateEmptyMessageRow
		/// <summary>
		/// Creeaza linia cu mesajul ptr. Dataset gol
		/// </summary>
		/// <returns>Returneaza o inregistrare in tabel</returns>
		private TableRow CreateEmptyMessageRow()
		{
			TableRow tmpRow = new TableRow();
			TableCell tmpCell = new TableCell();;

			tmpCell.CssClass = "NormalBlackBold";
			tmpCell.Text = m_textForEmptyDataSet;
			tmpCell.Attributes.Add("width", "100%");
			tmpCell.Attributes.Add("height", "100");
			tmpCell.Attributes.Add("align", "center");
			tmpCell.ColumnSpan = GetColumnsNumber();
			tmpRow.Cells.Add(tmpCell);

			return tmpRow;
		}
		#endregion

		#region FillTableFromDataSet
		/// <summary>
		/// Creeaza o linie cu inregistrari din dataset
		/// </summary>
		/// <param name="rowIndex">Nr inregistrarii</param>
		/// <param name="numberFormatInfo">Se foloseste formatarea numerelor</param>
		/// <returns>Returneaza o inregistrare in tabela</returns>
		private TableRow FillTableFromDataSet(int rowIndex, NumberFormatInfo numberFormatInfo)
		{
			TableRow tmpRow = new TableRow();
			TableCell tmpCell;

            if (m_hasCounter)
			{
				// adauga celula de nr. crt.
				tmpCell = new TableCell();
				tmpCell.Text = (rowIndex+1).ToString();
				tmpCell.CssClass = "NormalBlack";
				tmpRow.Cells.Add(tmpCell);
			}

			for (int i=0; i<tableCols.Length; i++)
			{
				// adauga fiecare celula conform arrayului de coloane
				tmpCell = new TableCell();
				tmpCell.CssClass = "NormalBlack";
				switch (m_ds.Tables[0].Rows[rowIndex][tableCols[i]].GetType().ToString())
				{						
					case "System.Boolean":
						tmpCell.Text = Boolean.Parse(m_ds.Tables[0].Rows[rowIndex][tableCols[i]].ToString())==true?"Da":"Nu";
						break;
					case "System.DateTime":
						tmpCell.Text = Utilities.ConvertDateTime2Text(Convert.ToDateTime(m_ds.Tables[0].Rows[rowIndex][tableCols[i]]));
						break;
					case "System.Decimal":
						tmpCell.Text = decimal.Parse(m_ds.Tables[0].Rows[rowIndex][tableCols[i]].ToString()).ToString("N",numberFormatInfo);
						break;
					case "System.Float":
						tmpCell.Text = float.Parse(m_ds.Tables[0].Rows[rowIndex][tableCols[i]].ToString()).ToString("N",numberFormatInfo);
						break;
					case "System.Double":
						tmpCell.Text = double.Parse(m_ds.Tables[0].Rows[rowIndex][tableCols[i]].ToString()).ToString("N",numberFormatInfo);
						break;
					case "System.Single":
						tmpCell.Text = Single.Parse(m_ds.Tables[0].Rows[rowIndex][tableCols[i]].ToString()).ToString("N",numberFormatInfo);
						break;
					default:
						tmpCell.Text = m_ds.Tables[0].Rows[rowIndex][tableCols[i]].ToString();
						break;
				}			
				tmpRow.Cells.Add(tmpCell);
			}
			tmpRow.Attributes.Add("onmouseover", "MouseOverTableLine(this)");
			tmpRow.Attributes.Add("onmouseout", "MouseOutTableLine(this)");
			
			if ((m_OnclickParams.Length!=0) && (m_OnclickParamsType.Length!=0))
				tmpRow.Attributes.Add("onclick", m_OnclickJSMethod +"(" + GetJSParamsList(rowIndex)  + ")");

			return tmpRow;
		}
		#endregion

		#region GetJSParamFromDataSet
		/// <summary>
		/// Procedura obtine parametrii de tip JS dintr-un DataSet
		/// </summary>
		/// <param name="rowIndex">Nr inregistrarii</param>
		/// <param name="paramIndex">Nr parametrului</param>
		/// <returns>Returneaza valoarea parametrului</returns>
		private string GetJSParamFromDataSet(int rowIndex, int paramIndex)
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
		private string GetJSParamsList( int rowIndex )
		{
			string paramStr = "";

			for(int i=0; i<m_OnclickParams.Length; i++)
			{
				switch (m_OnclickParamsType[i])
				{
					case "dataset":
						paramStr += "'" + GetJSParamFromDataSet(rowIndex, i).Trim() + "',";
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
			myCell.ColumnSpan = (m_hasCounter ? (tableCols.Length+1) : tableCols.Length);
			myCell.Text = "<img src=\"images/1x1.gif\" height=1>";
			myCell.Attributes.Add("align", "center");
			myRow.Cells.Add(myCell);

			return myRow;
		}
		#endregion

		#region CreateTableListHeader
		/// <summary>
		/// Creeaza linia de header a tabelului
		/// </summary>
		/// <returns>Returneaza o inregistrare din tabel</returns>
		private TableRow CreateTableListHeader()
		{
			TableRow tmpRow = new TableRow();
			TableCell tmpCell;

			if (m_hasCounter)
			{
				tmpCell = new TableCell();
				tmpCell.CssClass = "HeaderBlueBold";
				tmpCell.Attributes.Add("width", "30");
				tmpCell.Text = "Nr.";
				tmpRow.Cells.Add(tmpCell);
			}

			for (int i=0; i<tableHeader.Length; i++)
			{
				tmpCell = new TableCell();
				tmpCell.CssClass = "HeaderBlueBold";
				tmpCell.Text = tableHeader[i];
				tmpRow.Cells.Add(tmpCell);
			}

			return tmpRow;
		}
		#endregion
	}
}
