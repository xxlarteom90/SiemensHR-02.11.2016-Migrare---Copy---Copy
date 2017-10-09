using System;
using System.Data;
using System.Web.UI.WebControls;
using SiemensTM.utils;

namespace SiemensTM.Classes
{
	/// <summary>
	/// Summary description for ListTable.
	/// </summary>
	public class ListTable
	{
		#region Variabile
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

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="destTable"></param>
		/// <param name="ds"></param>
		/// <param name="arrayHeader"></param>
		/// <param name="arrayColumns"></param>
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

		#region DrawListTable
		/// <summary>
		/// Procedura creaza un tabel
		/// </summary>
		public void DrawListTable()
		{
			m_table.Style.Add("border", "1px solid #20b2aa");
			m_table.Attributes.Add("cellpadding","0");
			m_table.Attributes.Add("cellspacing","1");
			m_table.Attributes.Add("bgColor", "#ffffff");
			m_table.Rows.Add(CreateTableListHeader());

			for(int rowCount=0; rowCount<m_ds.Tables[0].Rows.Count; rowCount++)
			{
				m_table.Rows.Add(FillTableFromDataSet(rowCount));
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
		/// Procedura calculeaza nr de coloane
		/// </summary>
		/// <returns>Returneaza nr de coloane</returns>
		private int GetColumnsNumber()
		{
			if (m_hasCounter)
				return tableHeader.Length+1;
			else
				return tableHeader.Length;
		}
		#endregion

		#region CreateEmptyMessageRow
		/// <summary>
		/// Creeaza linia cu mesajul ptr. Dataset gol
		/// </summary>
		/// <returns>Returneaza o inregistrare</returns>
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
		/// <returns>Returneaza o inregistrare</returns>
		private TableRow FillTableFromDataSet(int rowIndex)
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
					case "System.Float":
						tmpCell.Text = float.Parse(m_ds.Tables[0].Rows[rowIndex][tableCols[i]].ToString()).ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithDigits);
						break;
					case "System.Double":
						tmpCell.Text = double.Parse(m_ds.Tables[0].Rows[rowIndex][tableCols[i]].ToString()).ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithDigits);
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
		/// Procedura creaza un parametru pe JavaScript
		/// </summary>
		/// <param name="rowIndex">Nr inregistrarii</param>
		/// <param name="paramIndex">Numele parametrului</param>
		/// <returns>Returneaza variabila JavaScript</returns>
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
		/// Procedura creaza o lista cu parametrii JavaScript
		/// </summary>
		/// <param name="rowIndex">Nr inregistrarii</param>
		/// <returns>Returneaza lista de parametrii</returns>
		private string GetJSParamsList( int rowIndex )
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
		
		#region CreateSeparatorLine
		/// <summary>
		/// Se adauga linia de separare
		/// </summary>
		/// <returns>Returneaza o inregistrare care contine linia de separare</returns>
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
		/// <returns>Returneaza o inregistrare care contine capul de tabel</returns> 
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
