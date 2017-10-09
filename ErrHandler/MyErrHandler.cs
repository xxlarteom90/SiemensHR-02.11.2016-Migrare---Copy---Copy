/*
 * Autor:		Lungu Andreea
 * Data:		16.12.2009
 * Descriere:	O clasa ce ajuta la retinerea intr-un fisier a erorilor (si nu numai - trace) aparatu in aplicatie.
 * 
 */ 
using System;
using System.IO;
using System.Globalization;
using Salaries;
using System.Security.Principal;

namespace ErrHandler
{
	/// <summary>
	/// Summary description for ErrHandler.
	/// </summary>
	public class MyErrHandler
	{
		private const string ERROR_FOLDER = "errorFolder";
		private static System.Security.Principal.WindowsPrincipal myUser;

		public MyErrHandler()
		{
			//
			// TODO: Add constructor logic here
			//
			
		}

		/// Handles error by accepting the error message
		/// Displays the page on which the error occured
		public static void WriteError(string errorMessage)
		{
			myUser = new WindowsPrincipal(WindowsIdentity.GetCurrent());
			string path = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode(ERROR_FOLDER);
			//sa am grija cum fac cu calea - pentru ca trebuie sa mearga si din directorul radacina si din alte foldere InterfataSalarii, Administrare
			//daca vreau sa mearga si in celelalte proiecte - trebui sa fac proiect separat
			path += "\\" + DateTime.Today.ToString("dd-MM-yy") + ".txt";
			if (!File.Exists(path))
			{
				File.Create(path).Close();
			}
			using (StreamWriter w = File.AppendText(path))
			{
				w.WriteLine();
				string err = errorMessage;
				w.Write("{0} - {1} - {2}", DateTime.Now.ToString("dd.MM.yyyy HH:mm"), myUser.Identity.Name, err);
				w.Flush();
				w.Close();
			} 
		}
	}
}
