//	Author:		Lungu Andreea
//	Data:		03.11.2009
//	Descriere:	Clasa va lucra cu fisiere excel pentru situatia lunara

using System;
using System.Data;
using System.Data.OleDb;

namespace Salaries.Data
{
	/// <summary>
	/// Summary description for ImportFisier.
	/// </summary>
	public class ImportFisier
	{
		private const string connStrExcel = "connStrExcel";
		private const string importLogFolder = "importFolder";

		public ImportFisier()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public DataTable GetDataTableFromImport(string fileName)
		{
			DataTable dt = new DataTable();
			string msg = "";
			string tempPath = System.IO.Path.GetTempPath();
			string path = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(importLogFolder);
			//System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\Inetpub\\wwwroot\\hr\\InterfataSalarii\\Templates\\logImport.txt", true);
			//D:\IIS\Default Web Site\hr\InterfataSalarii\Templates
			//System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\IIS\\Default Web Site\\hr\\InterfataSalarii\\Templates\\logImport.txt", true);
			System.IO.StreamWriter sw = new System.IO.StreamWriter(path + "\\logImport.txt", true);
			try
			{
				sw.WriteLine(" temp path:"+ tempPath);
				sw.WriteLine("import ");

				string strConn = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(connStrExcel);
				strConn += "Data Source=" + fileName.Replace("\\","\\\\") + ";";
				sw.WriteLine(strConn);
				OleDbConnection connection = new OleDbConnection(strConn);
				connection.Open();
				sw.WriteLine("a deschis conexiunea ");
				//You must use the $ after the object you reference in the spreadsheet
				OleDbDataAdapter myCommand = new OleDbDataAdapter("SELECT * FROM [Sheet1$]",strConn);
				DataSet myDataSet = new DataSet();
				myCommand.Fill(myDataSet, "ExcelInfo");
				sw.WriteLine("a citit din excel ");
				dt = myDataSet.Tables["ExcelInfo"];
			}
			catch(Exception exc)
			{
				msg = exc.Message;
			}
			finally
			{
				sw.Close();
			}
			string s = msg;
			return dt;
		}
	}
}
