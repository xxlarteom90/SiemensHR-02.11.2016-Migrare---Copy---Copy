using System;
using System.IO;
using System.Web;
using System.Text;
// add a reference to System.Web assembly
using System.Web.Caching;
using System.Xml.Serialization;
using System.Xml;
using System.Configuration;


namespace Salaries.Configuration
{
	public class ModuleConfig
	{
		#region GetSettings
		/// <summary>
		/// Se preiau datele din web.config pentru conexiunea la baza de date
		/// </summary>
		/// <returns></returns>
		public static ModuleSettings GetSettings()
		{
			HttpContext context = HttpContext.Current;
			string str=context.User.Identity.Name;
			string dataSource;
			string initialCatalog;
			string userID;
			string pwd;
			string connString="";

			ModuleSettings data = (ModuleSettings)context.Cache["Salaries_Settings"];

			if (data == null)
			{
				try
				{
					data = new ModuleSettings();
					
					//sunt preluate datele din web.config
					string workstation = CryptographyClass.getSettingsWithoutDecode("domain");
					dataSource = CryptographyClass.getSetting("dataSource");
					initialCatalog = CryptographyClass.getSetting("initialCatalog");
					userID = CryptographyClass.getSetting("userID");
					pwd = CryptographyClass.getSetting("pwd");
					
					//este construit connection string-ul
					connString = "workstation id="+workstation+";packet size=4096;data source="+dataSource+";persist security info=True;initial catalog="+initialCatalog+";user id="+userID+";pwd="+pwd+";Min Pool Size=3;Max Pool Size=30";
					
					//este setat connection string-ul
					data.ConnectionString = connString;
					
					//daca se fol metoda asta in web.config in appSettings trebuie adaugat tag-ul
					//<add key="ConnStr" value="workstation id=RO1CV0FC;packet size=4096;data source=bavc02cd;persist security info=True;initial catalog=SiemensHR_Test;user id=cata;pwd=?K0.11aUkcu0F;" />
					//data.ConnectionString = new System.Configuration.AppSettingsReader().GetValue("ConnStr",System.Type.GetType("System.String")).ToString();
				}
				catch (System.IO.FileNotFoundException)
				{
					// if the file is not found, return a new empty class
					data = new ModuleSettings();
				}
				catch
				{
					// if the file is not found, return a new empty class
					data = new ModuleSettings();
				}
			}
			return data;
		}
		#endregion

		#region SetConnectionString
		/// <summary>
		/// Procedura adauga datele criptate pentru conexiunea la baza de date in web.config
		/// </summary>
		/// <param name="dataSource">Numele serverului</param>
		/// <param name="initialCatalog">Numele bazei de date</param>
		/// <param name="userID">Numele utilizatorului</param>
		/// <param name="pwd">Parola utilizatorului</param>
		public static void SetConnectionString(string dataSource,string initialCatalog,string userID,string pwd)
		{
			//sunt adaugate datele in web.config, inainte de a fi adaugate acestea sunt criptate
			CryptographyClass.writeSetting("dataSource", dataSource, true);
			CryptographyClass.writeSetting("userID", userID, true);
			CryptographyClass.writeSetting("initialCatalog", initialCatalog, true);
			//daca se doreste si schimbarea parolei atunci este si aceasta modificata
			CryptographyClass.writeSetting("pwd", pwd, true);
		}
		#endregion
	}
	
	public class ModuleSettings
	{		
		//String-ul de conexiune la baza de date
		private string connectionString;
			
		[XmlElement]
		public string ConnectionString
		{
			get { return connectionString; }
			set { connectionString = value; }
		}		
	}

}
