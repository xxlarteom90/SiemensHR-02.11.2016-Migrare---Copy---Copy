using System;
using System.Web.UI.WebControls;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for TabsTable.
	/// </summary>
	public class TabsTable
	{
		#region Atribute private
		public double noTabsPerLine;
		private string curent_cmd;
		private Table mainTable;

		private string[] arTabs_text;
		private string[] arTabs ;
		private TableRow[] tabRows;
		#endregion

		#region TabsTable
		/// <summary>
		/// Creata tab-urile tabelelor
		/// </summary>
		/// <param name="destinationTable">Tabelul destinatie</param>
		/// <param name="curent_Command">Comanda curenta</param>
		/// <param name="tabs_Command">Comenzile tab-urilor</param>
		/// <param name="tabs_Text">Textul tab-urilor</param>
		public TabsTable(Table destinationTable, string curent_Command, string[] tabs_Command, string[] tabs_Text)
		{
			// nr max de taburi pe linie
			noTabsPerLine = 10;

			mainTable = destinationTable;
			curent_cmd = curent_Command; // comanda curenta
			arTabs_text = tabs_Text; // arrayul cu texte
			arTabs = tabs_Command; // arrayul cu comenzi

			mainTable.Attributes.Add("border","0");
			mainTable.Attributes.Add("cellpadding","0");
			mainTable.Attributes.Add("cellspacing","0");
		}
		#endregion

		#region BuildClientArrayCmd
		/// <summary>
		/// Construieste sirul curent de comenzi
		/// </summary>
		/// <returns>Returneaza un string care contine aceste comenzi</returns>
		public string BuildClientArrayCmd()
		{
			if (curent_cmd==null)
			{
				curent_cmd = arTabs[0];
			}
			//scriu arrayul de taburi pe client... ptr a avea comenzile
			string script_text = "<script>var arTabs = new Array(";
			int i;
			string tmpStr = "";
			for(i=0; i<arTabs.Length; i++)
				if (tmpStr!="")
					tmpStr += ",\"" + arTabs[i] + "\"";
				else
					tmpStr += "\"" + arTabs[i] + "\"";
			script_text += tmpStr + ");var selectedTab = \"" + curent_cmd + "\";</script>";
			return script_text;
		}
		#endregion

		#region BuildTabsTable
		/// <summary>
		/// Procedura creaza un tabel cu tab-uri
		/// </summary>
		/// <returns>Returneaza tabelul care contine aceste tab-uri</returns>
		public Table BuildTabsTable()
		{
			double noTabRows = Math.Ceiling(arTabs.Length/noTabsPerLine);
			// initializez arrayul de linii de tab
			tabRows = new TableRow[Convert.ToInt32(noTabRows)];
			// linie noua de taburi
			TableRow myRow = new TableRow(); 
			TableCell myCell = new TableCell();

			int countTabs=1;
			int noTabRowsIndex=0;
			bool findCmd_flag = false;
			int i;

			// se creeaza dinamic taburile folosindu-se arrayurile arTabs si arTabs_text
			myRow.Height = new Unit("24");
			for(i=0; i<arTabs.Length; i++)
			{
				if (countTabs<=noTabsPerLine) // daca nu s-a umplut inca linia se mai adauga un tab
				{
					// adauga un tab
					myRow.Cells.Add(CreateTabCell(arTabs_text[i], i));
					if (arTabs[i]==curent_cmd)
					{
						findCmd_flag = true;
					}
					// se adauga un spatiu de 5px intre taburi
					myRow.Cells.Add(CreateSpaceCell(2));
					countTabs++;
				}
				else
				{
					// adaug linia de taburi la array
					if (findCmd_flag)
					{
						tabRows[tabRows.Length-1] = myRow;
					}
					else
					{
						tabRows[noTabRowsIndex++] = myRow;
					}
					findCmd_flag = false;

					// adauga colt dreapta
					myCell = new TableCell();
					// linie noua de taburi
					myRow = new TableRow();
					myRow.Height = new Unit("24");
					// adauga colt stanga
					myCell = new TableCell();
					myRow.Cells.Add(CreateSpaceCell(2));
					myRow.Cells.Add(CreateTabCell(arTabs_text[i], i));

					// se adauga un spatiu de 5px intre taburi
					myRow.Cells.Add(CreateSpaceCell(2));
					countTabs=2;
				}
			}
			// adaug linia de taburi la array
			tabRows[noTabRowsIndex] = myRow;

			Table myTable;
			for (i=0; i<tabRows.Length-1; i++)
			{
				// creeaza un tabel ce va contine 1 linie taburi
				myTable = CreateTable();
				myTable.Attributes.Add("border", "0");
				myTable.CellSpacing = 0;
				myTable.CellPadding = 0;

				// testez ca linia care se scrie sa nu aiba mai multe taburi decat urmatoarea
				if (tabRows[i].Cells.Count>tabRows[i+1].Cells.Count)
				{
					while(tabRows[i+1].Cells.Count<noTabsPerLine*2)
					{
						// iau ultima celula din linie
						myCell = tabRows[i].Cells[ tabRows[i].Cells.Count-3];
						// adaug celula in linia urmatoare
						tabRows[i+1].Cells.AddAt(1, myCell);
						// iau ultima celula din linie
						myCell = tabRows[i].Cells[ tabRows[i].Cells.Count-3];
						// adaug celula in linia urmatoare
						tabRows[i+1].Cells.AddAt(1, myCell);		
					}
				}

				myTable.Rows.Add(tabRows[i]);
				mainTable.Rows.Add(CreateMainRowTabs(myTable));
			}
			myTable = CreateTable();
			myTable.Rows.Add(tabRows[tabRows.Length-1]);
			mainTable.Rows.Add(CreateMainRowTabs(myTable));

			return mainTable;
		}
		#endregion

		#region CreateTable
		/// <summary>
		/// Procedura creaza un tabel
		/// </summary>
		/// <returns>Returneaza un tabel gol</returns>
		private Table CreateTable()
		{
			Table tmpTable = new Table();
			tmpTable.Attributes.Add("border","0");
			tmpTable.Attributes.Add("cellpadding","0");
			tmpTable.Attributes.Add("cellspacing","0");
			return tmpTable;
		}
		#endregion

		#region CreateTabCell
		/// <summary>
		/// Procedura creaza o celula in tabel
		/// </summary>
		/// <param name="text">Textul celulei</param>
		/// <param name="index">Indexul celulei</param>
		/// <returns>Returneaza celula din tabel</returns>
		private TableCell CreateTabCell( string text, int index)
		{
			TableCell tmpCell = new TableCell();
			tmpCell.Text = text;
			tmpCell.CssClass = "tab";
			tmpCell.Attributes.Add("onmouseover", "MouseOverTabs(this)");
			tmpCell.Attributes.Add("onmouseout", "MouseOutTabs(this)");
			tmpCell.Attributes.Add("onclick", "SelectTab(" + index.ToString() + ")");
			tmpCell.Attributes.Add("id", "tab" + (index+1).ToString() + "");
			return tmpCell;
		}
		#endregion

		#region CreateSpaceCell
		/// <summary>
		/// Procedura creaza o celula de separare
		/// </summary>
		/// <param name="widthCell">Dimesiunea celulei</param>
		/// <returns>Returneaza celula creata</returns>
		private TableCell CreateSpaceCell(int widthCell)
		{
			TableCell tmpCell= new TableCell();
			tmpCell.Width = new Unit(widthCell.ToString());
			tmpCell.Text = "<img height=\"100%\" src=\"../images/separator-tab.gif\" >";
			return tmpCell;
		}
		#endregion
		
		#region CreateMainRowTabs
		/// <summary>
		/// Procedura creaza randul care contine tab-urile principale
		/// </summary>
		/// <param name="tmpTable">Tabelul care va contine tab-urile</param>
		/// <returns>Returneaza o intregistrare din tabel care va contine tab-urile</returns>
		private TableRow CreateMainRowTabs( Table tmpTable )
		{
			TableRow tmpRow = new TableRow();
			TableCell tmpCell = new TableCell();
			tmpCell.Attributes.Add("align","center");
			tmpCell.Controls.Add(tmpTable);
			tmpRow.Cells.Add(tmpCell);
			return tmpRow;	
		}
		#endregion
	}
}
