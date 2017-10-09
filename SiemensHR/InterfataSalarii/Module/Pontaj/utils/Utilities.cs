using System;
using System.Web.UI.WebControls;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace SiemensTM.utils
{
	/// <summary>
	/// Class folosita ptr diferite operatiuni generale
	/// - ConvertText2DateTime - converteste un text(zi.luna.an) la o structura DateTime
	/// - ConvertDateTime2Text - converteste o structura DateTime la un text(zi.luna.an)
	/// - CreateTableHeader - creeaza un header rotunjit de tabel - folosit la formulare
	/// - CreateHeaderWithTabs - creeaza linia de tabel cu taburi
	/// - CreateOptionList -  creeaza un tabel cu optiuni-taskuri 
	/// </summary>
	public class Utilities
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public Utilities()
		{}
		#endregion
	
		#region ConvertToShort
		/// <summary>
		/// converteste un text de genul zi.luna.an intr-o class DateTime
		/// </summary>
		static public DateTime ConvertToShort(DateTime data)
		{
			return DateTime.Parse(data.ToShortDateString());
		}
		#endregion
		
		#region ConvertDateTimeToHour
		/// <summary>
		/// Procedura converteste o data in format cu ore
		/// </summary>
		/// <param name="Data">Data</param>
		/// <returns>Returneaza un string care contine data in noul format</returns>
		static public string ConvertDateTimeToHour(DateTime Data)
		{
			int Hour = Data.Hour;
			int Minute = Data.Minute;
			bool PM = Data.ToShortTimeString().IndexOf("PM")>0;
			string s_h = Hour.ToString();
			string s_m = Minute.ToString();

			if (s_h.Length==1) s_h="0"+s_h;
			if (s_m.Length==1) s_m="0"+s_m;	
			return s_h+":"+s_m;
		}
		#endregion
		
		#region ConvertText2DateTime
		/// <summary>
		/// Procedura transforma un text in data
		/// </summary>
		/// <param name="text">Texul</param>
		/// <returns>Returneaza un obiect de tip data</returns>
		static public DateTime ConvertText2DateTime( string text )
		{
			string[] split_array = null;
			DateTime retVal;
			
			if (text!="")
			{
				split_array = text.Split('.');

				if (split_array.Length==3)
				{
					int an = Convert.ToInt32(split_array[2]);
					int luna = Convert.ToInt32(split_array[1]);
					int zi = Convert.ToInt32(split_array[0]);
					retVal = new DateTime(an, luna, zi);
				}
				else
					throw new Exception("Invalid string format was past to Utilities.ConvertText2DateTime method!");
			}
			else
				retVal = DateTime.MinValue;
		
			return retVal;
		}
		#endregion
		
		#region ConvertDateTime2Text
		/// <summary>
		/// Converteste o structura DateTime la un text de forma zi.luna.an
		/// </summary>
		/// <param name="data">Data</param>
		/// <returns>Returneaza noul format</returns>
		static public string ConvertDateTime2Text( DateTime data)
		{
			string dataText = "";
			
			if (data.Equals(DateTime.MinValue))
				dataText = "";
			else
			{
				if (data.Day<10)
					dataText += "0" + data.Day.ToString();
				else
					dataText += data.Day.ToString();
				dataText +=".";
				if (data.Month<10)
					dataText += "0" + data.Month.ToString();
				else
					dataText += data.Month.ToString();
				dataText += ".";
				dataText += data.Year.ToString();
			}
			return dataText;
		}
		#endregion

		#region CreateTableHeader
		/// <summary>
		/// creeaza un header rotunjit de tabel - folosit la formulare
		/// tmpTable - tabelul in care se creeaza headerul
		/// text - textul care sa apara in headerul de tabel
		/// relativePath - calea relativa la folderul Images (ex: "", "../")
		/// type - small sau normal - daca se doreste header mic sau normal
		/// </summary>
		static public Table CreateTableHeader(Table tmpTable, string text, string relativePath, string type)
		{
			TableRow tmpRow =  new TableRow();
			
			tmpTable.CellPadding = 0;
			tmpTable.CellSpacing = 0;
			tmpTable.BorderWidth = new Unit("0");

			// creeaza coltul stanga al headerului
			TableCell tmpCell = new TableCell();
			tmpCell.Text = "<img src=\"" + relativePath + "images/stanga-header-" + type + ".gif\">";
			tmpRow.Cells.Add(tmpCell);

			// creeaza celula centrala ce contine textul din header
			tmpCell = new TableCell();
			tmpCell.Text =text;
			tmpCell.CssClass = "tab1";
			tmpCell.Width = new Unit("100%");
			tmpCell.Style.Add("background-image", "url('" + relativePath + "images/fill-header-" + type + ".gif')");
			tmpRow.Cells.Add(tmpCell);
	
			// creeaza coltul dreapta la headerului
			tmpCell = new TableCell();
			tmpCell.Text = "<img src=\"" + relativePath + "images/dreapta-header-" + type + ".gif\">";
			tmpRow.Cells.Add(tmpCell);

			tmpTable.Rows.Add(tmpRow);

			return tmpTable;
		}
		#endregion

		#region CreateHeaderWithTabs
		/// <summary>
		///<list type="bullet">
		///<listheader>Creeaza linia de tabel cu taburi</listheader>
		///<item>tmpTable - tabelul unde se creeaza taburile</item>
		///<item>textTabs - array cu textele taburilor</item>
		///<item>relativePath - calea relativa de la pagina la folderul Images (ex."", ".../")</item>
		///<item>withEvents - true, false - daca se vrea si evenimente java script sau nu</item>
		///</list>
		/// </summary>
		static public Table CreateHeaderWithTabs(Table tmpTable, string[] textTabs, string relativePath, bool withEvents)
		{
			TableRow tmpRow =  new TableRow();
			
			tmpTable.CellPadding = 0;
			tmpTable.CellSpacing = 0;
			tmpTable.BorderWidth = new Unit("0");
			tmpTable.Height = new Unit("24");
			tmpTable.Width = new Unit("100%");

			// adauga prima celula ce contine colul stanga de la linia de taburi
			TableCell tmpCell = new TableCell();
			tmpCell.Width = new Unit("17");
			tmpCell.Text = "<img src=\"" + relativePath + "images/colt-tab.gif\">";
			tmpRow.Cells.Add(tmpCell);
			
			// adauga un separator
			tmpRow.Cells.Add(CreateSeparatorForTabs(relativePath));			

			for (int i=0; i<textTabs.Length; i++)
			{
				// creeaza un tab
				tmpCell = new TableCell();
				tmpCell.CssClass = "tab";
				tmpCell.ID = "tab" + (i+1);
				tmpCell.Text = textTabs[i]; // seteaza textul din array-ul de texte
				if (withEvents) //daca se doresc evenimente - se adauga
				{
					tmpCell.Attributes.Add("onmouseover","MouseOverTabs(this)");
					tmpCell.Attributes.Add("onmouseout","MouseOutTabs(this)");
					tmpCell.Attributes.Add("onclick","SelectTab(" + i + ")");
				}
				tmpRow.Cells.Add(tmpCell); // se adauga celula cu tabul creat la linia de taburi
				
				// se adauga un separator
				tmpRow.Cells.Add(CreateSeparatorForTabs(relativePath));		

			}
			// se adauga coltul dreapta de la linia de taburi
			tmpCell = new TableCell();
			tmpCell.Width = new Unit("17");
			tmpCell.Text = "<img src=\"" + relativePath + "images/colt-tab1.gif\">";
			tmpRow.Cells.Add(tmpCell);

			tmpTable.Rows.Add(tmpRow);
				
			return tmpTable;
		}
		#endregion

		#region CreateSeparatorForTabs
		/// <summary>
		/// creeaza o celula de separatie ptr. taburi
		/// </summary>
		static private TableCell CreateSeparatorForTabs(string relativePath)
		{
			TableCell tmpCell = new TableCell();
			tmpCell.Width = new Unit("2");
			tmpCell.Text = "<img height=100% src=\"" + relativePath + "images/separator-tab.gif\">";

			return tmpCell;
		}
		#endregion

		#region CreateOptionList
		/// <summary>
		/// creeaza un tabel cu optiuni-taskuri 
		/// textOptions - array cu textele de la optiuni-taskuri
		/// cmsOptions - array cu comenzile pe care sa le asocieze optiunilor-taskurilor
		/// JSFuntion - functia care sa fie apelata la onclick
		/// la onclick pe client
		/// relativePath - calea relativa la folderul images (ex: "", "../")
		/// tableHeight - inaltimea tabelului
		/// tableWidth -latimea tabelului
		/// </summary>
		static public void CreateOptionList(Table mainTable, string[] textOptions, string[] cmdOptions, string JSFunction,
			string relativePath, string tableHeight, string tableWidth)
		{
			TableRow tmpRow;
			TableCell tmpCell;

			mainTable.Attributes.Add("width", tableWidth);
			mainTable.Attributes.Add("height", tableHeight);
			mainTable.CellSpacing = 1;
			mainTable.CellPadding = 0;
			mainTable.BorderWidth = 0;
			mainTable.Attributes.Add("bgcolor", "#f3f6f9");

			for (int i=0; i<textOptions.Length; i++)
			{
				tmpRow = new TableRow();
				//se adauga prima celula = contine imaginea cu puncte din fata taskurilor
				tmpCell = new TableCell();
				tmpCell.Width = new Unit("15px");
				tmpCell.Text = "<img src=\"" + relativePath + "images/puncte.gif\">";
				tmpRow.Cells.Add(tmpCell);

				//se adauga optiunea din lista
				tmpCell = new TableCell();
				tmpCell.CssClass = "TaskStyle";
				tmpCell.Attributes.Add("onmouseover", "MouseOverTasks(this)");
				tmpCell.Attributes.Add("onmouseout", "MouseOutTasks(this)");
				tmpCell.Attributes.Add("onclick", JSFunction + "('" + cmdOptions[i] + "')");
				tmpCell.Text = textOptions[i];
				tmpRow.Cells.Add(tmpCell);
				
				mainTable.Rows.Add(tmpRow); // se adauga linia cu optiunea - task
				mainTable.Rows.Add(CreateSeparatorForTasks(relativePath, 2)); // se adauga o linie separatoare

			}
			// se adauga o linie goala de 100% ptr a nu se lati liniile cu optiuni
			tmpRow = new TableRow();
			tmpCell = new TableCell();
			tmpCell.Height = new Unit("100%");
			tmpCell.Text = "&nbsp;";
			tmpRow.Cells.Add(tmpCell);
			mainTable.Rows.Add(tmpRow);
		}
		#endregion

		#region CreateSeparatorForTasks
		/// <summary>
		/// creaza o linie de separatie pe verticala intre optiuni - taskuri
		///</sumarry>
		static private TableRow CreateSeparatorForTasks(string relativePath, int colSpan)
		{
			Table tmpTable = new Table();
			TableRow tmpRow = new TableRow();
			TableCell tmpCell = new TableCell();

			//se adauga linia de separare
			tmpTable.Width = new Unit("90%");
			tmpTable.CellPadding =0;
			tmpTable.CellSpacing =0;
			tmpTable.BorderWidth = 0;
			tmpCell.CssClass = "BlueSeparator";
			tmpCell.Text = "<img height=1 src=\"" + relativePath + "images/1x1.gif\">";
			tmpRow.Cells.Add(tmpCell);
			tmpTable.Rows.Add(tmpRow); // se creeaza un tabel cu linia de separatie

			tmpRow = new TableRow();
			tmpCell = new TableCell();// tabelul se adauga intr-o linie noua
			tmpCell.ColumnSpan = colSpan;
			tmpCell.Controls.Add(tmpTable);
			tmpCell.HorizontalAlign = HorizontalAlign.Center;
			tmpRow.Cells.Add(tmpCell);

			return tmpRow;
		}
		#endregion


		//************************************ File & Folder functions
		#region DirectoryExists
		/// <summary>
		/// Procedura verifica daca un director exsita
		/// </summary>
		/// <param name="path">Calea directorului</param>
		/// <returns>Returneaza true daca directorul exista si false altfel</returns>
		public static bool DirectoryExists(string path)
		{
			return Directory.Exists(path);
		}
		#endregion

		#region MakeFolder
		/// <summary>
		/// Procedura creaza un director
		/// </summary>
		/// <param name="path">Calea directorului</param>
		/// <returns>Returneaza true daca a fost creat directorul si false altfel</returns>
		public static bool MakeFolder(string path)
		{
			bool ok;
			try
			{
				ok=true;
				Directory.CreateDirectory(path);
			}
			catch
			{
				ok=false;
			}
			return ok;
		}
		#endregion

		#region UploadFileToFolder
		/// <summary>
		/// Procedura adauga un fisier intr-un director
		/// </summary>
		/// <param name="FileName">Numele fisierului</param>
		/// <param name="FolderPath">Calea directorului</param>
		/// <param name="FileLem">Dimensiunea fisierului</param>
		/// <param name="FileData">Data continuta in fisier</param>
		/// <returns>Returneaza true daca a fost adaugat fisierul si flase altfel</returns>
		public static bool UploadFileToFolder(string FileName,string FolderPath,int FileLem,byte[] FileData)
		{
			bool ok;
			try
			{
				if (!DirectoryExists(FolderPath)) MakeFolder(FolderPath);
				WriteToFile(FolderPath+"\\"+FileName,ref FileData);
				ok=true;
			}
			catch
			{
				ok=false;
			}
			return ok;
		}
		#endregion

		#region WriteToFile
		/// <summary>
		/// Procedura scrie date intr-un fisier
		/// </summary>
		/// <param name="strPath">Calea fisierului</param>
		/// <param name="Buffer">Buffer-ul care contine datele</param>
		private static void WriteToFile(string strPath, ref byte[] Buffer)
		{
			FileStream newFile = new FileStream(strPath, FileMode.Create);
			newFile.Write(Buffer, 0, Buffer.Length);
			newFile.Close();
		}
		#endregion

		#region DateFromOra
		/// <summary>
		/// Procedura creaza o data care contine si ora
		/// </summary>
		/// <param name="date">Data</param>
		/// <param name="ora">Ora</param>
		/// <returns>Returneaza un obiect care contine data</returns>
		public static DateTime DateFromOra(DateTime date,string ora)
		{
			string [] tmp = ora.Split(":".ToCharArray());
			int h = int.Parse(tmp[0]);
			int m = int.Parse(tmp[1]);
			return new DateTime(date.Year,date.Month,date.Day,h,m,0);
		}
		#endregion

		#region TransformIntoTwoDigits
		//Lungu Andreea - 02.01.2010
		public static string TransformIntoTwoDigits(int nr)
		{
			if (nr>9 && nr<100)
				return nr.ToString();
			else
				if (nr<=9)
				return "0" + nr.ToString();
			return nr.ToString();
		}
		#endregion

		#region TransformIntoTwoDigits
		//Lungu Andreea - 02.01.2010
		public static string TransformIntoThreeCaracters(int nr)
		{
			if (nr>9 && nr<100)
				return "  " + nr.ToString();
			else
				if (nr<=9)
				return "   " + nr.ToString();
			return nr.ToString();
		}
		#endregion
	}

	public class Shell 
	{
		#region Constante
		public static uint SHGFI_ICON = 0x100; // get icon
		public static uint SHGFI_USEFILEATTRIBUTES = 0x10; // use passed
		public static uint FILE_ATTRIBUTE_NORMAL = 0x80;
		#endregion

		[DllImport("Shell32.dll")]

		#region SHGetFileInfo
		public static extern int SHGetFileInfo( string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, int cbfileInfo, uint uFlags);
		#endregion

		#region SHFILEINFO
		public struct SHFILEINFO 
		{
			public IntPtr hIcon;
			public int iIcon;
			public int dwAttributes;
			public string szDisplayName;
			public string szTypeName;
		}
		#endregion

		#region GetFileIcon
		/// <summary>
		/// Procedura determina tipul de icoana a unui document
		/// </summary>
		/// <param name="fullpath">Calea documentului</param>
		/// <returns>Returneaza imaginea documentului</returns>
		public static System.Drawing.Image GetFileIcon(string fullpath) 
		{
			SHFILEINFO info = new SHFILEINFO();
			int retval = SHGetFileInfo(fullpath, FILE_ATTRIBUTE_NORMAL, ref info,
				System.Runtime.InteropServices.Marshal.SizeOf(info), SHGFI_USEFILEATTRIBUTES
				| SHGFI_ICON);

			if (retval == 0) 
			{
				return null; // error occured
			}

			System.Drawing.Icon icon = System.Drawing.Icon.FromHandle(info.hIcon);
			ImageList imglist = new ImageList();
			imglist.ImageSize =icon.Size;
			imglist.Images.Add(icon);

			System.Drawing.Image image = imglist.Images[0];
			icon.Dispose();
			return image;
		}
		#endregion
	}
}