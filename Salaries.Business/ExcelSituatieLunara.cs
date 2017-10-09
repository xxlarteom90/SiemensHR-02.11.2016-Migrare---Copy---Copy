using System;
using Excel = Microsoft.Office.Interop.Excel;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for ExcelSituatieLunara.
	/// </summary>
	public class ExcelSituatieLunara
	{
		private ExcelHandler excelHandler;
		private string fileName;

		public ExcelSituatieLunara(string fileName)
		{
			this.fileName = fileName;
			excelHandler = new ExcelHandler(fileName);
		}

		public void GetValues()
		{
			string sir = "";
			//for (int i=0; i<=20; i++)
			//{
				Excel.Range range = excelHandler.GetRange(2,5);
				string a = range.get_Value(Type.Missing).ToString();
				sir += "----"+a;
			//}
			/*Excel.Application appXls = new Excel.Application();
			appXls.Visible = false;

			Excel._Workbook wbXls = (Excel._Workbook)(appXls.Workbooks.Open( fileName, Type.Missing, false, Type.Missing,  Type.Missing,  Type.Missing, true,  Type.Missing,  Type.Missing, true,  Type.Missing,  Type.Missing,  Type.Missing,  Type.Missing,  Type.Missing ));
			Excel._Worksheet activeWsXls = (Excel._Worksheet)wbXls.ActiveSheet;

			for (int i = 1; i <= 10; i++)
			{
				Excel.Range range = activeWsXls.get_Range("A"+i.ToString(), "T" + i.ToString());
				System.Array myvalues = (System.Array)range.Cells.get_Value(range);
				//string[] strArray = ConvertToStringArray(myvalues);
				int nr = myvalues.Length;
			}*/

			/*
			Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(
					fileName, 0, true, 5,
					"", "", true, Excel.XlPlatform.xlWindows, "\t", false, false,
					0, true); 
			Excel.Sheets sheets = theWorkbook.Worksheets;
			Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
			for (int i = 1; i <= 10; i++)
			{
				Excel.Range range = worksheet.get_Range("A"+i.ToString(), "J" + i.ToString());
				System.Array myvalues = (System.Array)range.Cells.Value;
				string[] strArray = ConvertToStringArray(myvalues);
			}*/
		}
	}
}
