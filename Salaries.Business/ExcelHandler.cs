using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;


namespace Salaries.Business
{
	/// <summary>
	/// Aceasta clasa se ocupa cu "manuirea" unui fisier excel
	/// </summary>
	public class ExcelHandler
	{
		private string filePath; //calea unde se afla fis
		private Excel.Application appXls; //aplicatia excel
		private Excel._Workbook wbXls; //workbook-ul excel
		private Excel._Worksheet activeWsXls; //worksheet-ul activ din aplicatia excel

		//constanta ce contine formatul celulelor de tipul Suma pe taxe (col C).
		private const string formatValSume = "_-* #,##0.00_-;-* #,##0.00_-;_-* \"-\"??_-;_-@_-";

		/// <summary>
		/// Constructorul incarca fisierul care se afla la url-ul "filePath" in aplicatia excel
		/// si incarca workbook-ul si sheet-ul activ existent
		/// </summary>
		public ExcelHandler( string filePath)
		{
			this.filePath = filePath;

			try
			{
				GC.Collect();// stergerea proceselor excel existente
				appXls = new Excel.Application();
				appXls.Visible = false;

				wbXls = (Excel._Workbook)(appXls.Workbooks.Open( filePath, Type.Missing, false, Type.Missing,  Type.Missing,  Type.Missing, true,  Type.Missing,  Type.Missing, true,  Type.Missing,  Type.Missing,  Type.Missing,  Type.Missing,  Type.Missing ));
				activeWsXls = (Excel._Worksheet)wbXls.ActiveSheet;
			}
			catch(Exception exc)
			{
				string a = exc.Message;
				GC.Collect();
			}
		}

		/// <summary>
		/// Inchide toate procesele ce tin de excel si cheama garbage collector-ul
		/// </summary>
		public void Terminate()
		{
			wbXls.Close( null, null, null );
			appXls.Workbooks.Close();
			appXls.Quit();
			
			System.Runtime.InteropServices.Marshal.ReleaseComObject( appXls );
			System.Runtime.InteropServices.Marshal.ReleaseComObject( this.activeWsXls );
			System.Runtime.InteropServices.Marshal.ReleaseComObject( wbXls );
			this.activeWsXls=null;
			wbXls = null;
			appXls = null;
			GC.Collect();  // colectarea componentelor

			//omoara toate procesele excel
			System.Diagnostics.Process []p1 = System.Diagnostics.Process.GetProcessesByName( "excel" );
			foreach( System.Diagnostics.Process proc in p1 )
			{
				if( !proc.CloseMainWindow())
				{
					try
					{
						proc.Kill();
					}
					catch{}
				}
			}
		}

		/// <summary>
		/// returneaza textul continut in celula ceruta
		/// </summary>
		//public string GetCellValue( string cellID )
		public string GetCellValue( int cellRow, int cellCol )
		{
			return this.activeWsXls.Cells[ cellRow, cellCol ].ToString();
		}

		/// <summary>
		/// seteaza valoarea din celula specificata
		/// </summary>
		//public void SetCellValue( string cellID, object val )
		public void SetCellValue( int cellRow, int cellCol, object val )
		{
			this.activeWsXls.Cells[ cellRow, cellCol ] = val;
		}

		/// <summary>
		/// inchide workbook-ul curent
		/// </summary>
		public void CloseActiveWorkBook( bool saveChanges, string filePath )
		{
			this.appXls.ActiveWorkbook.Close( saveChanges, filePath, Type.Missing);
		}

		/// <summary>
		/// salveaza workbook-ul curent
		/// </summary>
		public void SaveActiveWorkBookChanges()
		{
			this.appXls.ActiveWorkbook.Save();
		}

		public void SaveAsWorkbook( string path )
		{
			this.appXls.ActiveWorkbook.SaveAs( path,Excel.XlFileFormat.xlWorkbookNormal,
				null,null,false,false,Excel.XlSaveAsAccessMode.xlShared,false,false,null,null,null);
		}

		/// <summary>
		/// stabileste formatul celulelor. Se fol doar pentru sume momentan.
		/// </summary>
		public void CellFormat( string rngStart, string rngStop )
		{
			Excel.Range range = (Excel.Range)activeWsXls.get_Range( rngStart, rngStop );
			range.Cells.NumberFormat = formatValSume;
		}

		public Excel.Range GetRange(int row, int col)
		{
			return (Excel.Range)this.appXls.Cells[row, col];
		}
	}
}
