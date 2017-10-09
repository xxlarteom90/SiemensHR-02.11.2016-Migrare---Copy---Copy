using System;
using System.Security.Principal;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for Authentication.
	/// </summary>
	public class Authentication
	{
		#region Variabile
		private static Configuration.ModuleSettings settings;
		private static string groupHR;
		private static string groupManagers;
		private static string groupRecrutori;
		#endregion

		#region Authentication
		/// <summary>
		/// Constructor
		/// </summary>
		public Authentication()
		{			
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region IsUserLogged
		/// <summary>
		/// Verifica daca un user este logginat
		/// </summary>
		/// <param name="user">Utilizatorul verificat</param>
		/// <returns>Returneaza true daca utilizatorul este autentificat si false altfel</returns>
		public static bool IsUserLogged(WindowsPrincipal user)
		{
			if (null != user)
			{

				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion

		#region IsUserLogged
		/// <summary>
		/// Verifica daca un utilizator este loginat
		/// </summary>
		/// <param name="nume">Numele utilizatorului</param>
		/// <param name="parola">Parola utilizatorului</param>
		/// <param name="angajatorId">Id-ul angajatorului de care apartine utilizatorul</param>
		/// <returns>Returneaza true daca utilizatorul are datele complete si false altfel</returns>
		public static bool IsUserLogged(string nume, string parola, int angajatorId)
		{
			Salaries.Business.AdminUtilizatori utilizatori = new AdminUtilizatori();
			DataSet ds = utilizatori.LoadInfoUtilizatori(angajatorId);
			for (int i=0; i<ds.Tables[0].Rows.Count; i++)
			{
				string n = ds.Tables[0].Rows[i]["Nume"].ToString();
				string p = ds.Tables[0].Rows[i]["Parola"].ToString();
				p = Salaries.Configuration.CryptographyClass.decodeSTR(p);
				if ((n == nume) && (p == parola)) 
				{
					return true;
				}
			}
			return false;
		}
		#endregion

		#region IsUserInGroup
		/// <summary>
		/// Verifica daca un user este intr-un anumit grup
		/// </summary>
		/// <param name="groupName">Numele grupului</param>
		/// <param name="domainName">Numele domeniului</param>
		/// <param name="user">Numele utilizatorului</param>
		/// <returns>Returneaza true daca utilizatorul este in grupul respectiv si false altfel</returns>
		public static bool IsUserInGroup(string groupName, string domainName, WindowsPrincipal user)
		{
			try
			{
				if(IsUserLogged(user))
				{
					if ( user.IsInRole(domainName+"\\"+groupName) )
						return true;
					else
						return false;
				}
				else
					return false;
			}
			catch
			{return false;}
		}
		#endregion

		#region IsUserInGroup
		/// <summary>
		/// Se verifica daca un utilizator este intr-un anumit grup
		/// </summary>
		/// <param name="nume">Numele utilizatorului</param>
		/// <param name="parola">Parola utilizatorului</param>
		/// <param name="angajatorId">Id-ul angajatorului de care apartine utilizatorul</param>
		/// <param name="grup">Numele grupului pentru care se face verificarea</param>
		/// <returns>Returneaza true daca utilizatorul este in grup si false altfel</returns>
		public static bool IsUserInGroup(string nume, string parola, int angajatorId, string grup)
		{
			try
			{
				Salaries.Business.AdminUtilizatori utilizatori = new AdminUtilizatori();
				DataSet ds = utilizatori.LoadInfoUtilizatori(angajatorId);
				//se parcurg utilizatorii asociati unui angajator
				for (int i=0; i<ds.Tables[0].Rows.Count; i++)
				{
					string n = ds.Tables[0].Rows[i]["Nume"].ToString();
					string p = ds.Tables[0].Rows[i]["Parola"].ToString();
					string g = ds.Tables[0].Rows[i]["NumeGrup"].ToString();
					p = Salaries.Configuration.CryptographyClass.decodeSTR(p);
					//daca numele, parola si grupul coincid, atunci se returneaza true
					if ((n == nume) && (p == parola) && (g == grup)) 
					{
						return true;
					}
				}
				return false;
			}
			catch(Exception ex) 
			{
				return false;
			}
		}
		#endregion

		#region IsUserInHRgroup
		/// <summary>
		/// Verifica daca un user este in grupul HRUsers
		/// </summary>
		/// <param name="user">Numele utilizatorului</param>
		/// <returns>Returneaza true daca utilizatorul este in grupul HR si false altfel</returns>
		public static bool IsUserInHRgroup(WindowsPrincipal user)
		{
			try
			{
				if(IsUserLogged(user))
				{
					string domain  = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("domain");
					groupHR = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("groupHR");

                    if (user.IsInRole(domain + "\\" + groupHR))
                    {
                        System.IO.File.WriteAllText("D:\\test.log", "OK " +  user.Identity.Name + " " + domain + " " + groupHR);
                        return true;
                    }
                    else
                    {
                        System.IO.File.WriteAllText("D:\\test.log", "NOT OK " + user.Identity.Name + " " + domain + " " + groupHR);
                        return false;
                    }
				}
				else 
					return false;
			}
			catch(Exception ex) {return false;}
		}
		#endregion

		#region IsUserInHRgroup
		/// <summary>
		/// Verifica daca utilizatorul este in grupul HRUsers
		/// </summary>
		/// <param name="nume">Numele utilizatorului</param>
		/// <param name="parola">Parola utilizatorului</param>
		/// <param name="angajatorId">Id-ul angajatorului de care apartine utilizatorul</param>
		/// <returns>Returneaza true daca utilizatorul este in grup si false altfel</returns>
		public static bool IsUserInHRgroup(string nume, string parola, int angajatorId)
		{
			//se obtine numele grupului HRUsers
			string groupHR = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("groupHR");
			return IsUserInGroup(nume, parola, angajatorId, groupHR);
		}
		#endregion

		#region IsUserInManagersGroup
		/// <summary>
		/// Verifica daca un user este in grupul Managers
		/// </summary>
		/// <param name="user">Numele utilizatorului</param>
		/// <returns>Returneaza true daca utilizatorul este in grupul Managers si false altfel</returns>
		public static bool IsUserInManagersGroup(WindowsPrincipal user)
		{
			try
			{
				if(IsUserLogged(user))
				{
					string domain  = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("domain");
					groupManagers = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("groupManagers");

					if(user.IsInRole(domain+"\\"+groupManagers))
						return true;
					else
						return false;
				}
				else
					return false;
			}
			catch(Exception ex) {return false;}
		}
		#endregion

		#region IsUserInManagersGroup
		/// <summary>
		/// Verifica daca utilizatorul este in grupul Managers
		/// </summary>
		/// <param name="nume">Numele utilizatorului</param>
		/// <param name="parola">Parola utilizatorului</param>
		/// <param name="angajatorId">Id-ul angajatorului de care apartine utilizatorul</param>
		/// <returns>Returneaza true daca utilizatorul este in grup si false altfel</returns>
		public static bool IsUserInManagersGroup(string nume, string parola, int angajatorId)
		{
			//se obtine numele grupului Managers
			string groupManagers = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("groupManagers");
			return IsUserInGroup(nume, parola, angajatorId, groupManagers);
		}
		#endregion

		#region IsUserInRecrutoriGroup
		/// <summary>
		/// Procedura verifica daca un user este in grupul Recrutori
		/// </summary>
		/// <param name="user">Utilizatorul pentru care se verifica</param>
		/// <returns>Returneaza true daca este in grup si false altfel</returns>
		public static bool IsUserInRecrutoriGroup(WindowsPrincipal user)
		{
			try
			{
				if(IsUserLogged(user))
				{
					string domain  = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("domain");
					groupRecrutori = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("groupRecrutori");

					if(user.IsInRole(domain+"\\"+groupRecrutori))
						return true;
					else
						return false;
				}
				else
					return false;
			}
			catch(Exception ex) {return false;}
		}
		#endregion

		#region IsUserInRecrutoriGroup
		/// <summary>
		/// Verifica daca utilizatorul este in grupul Recrutori
		/// </summary>
		/// <param name="nume">Numele utilizatorului</param>
		/// <param name="parola">Parola utilizatorului</param>
		/// <param name="angajatorId">Id-ul angajatorului de care apartine utilizatorul</param>
		/// <returns>Returneaza true daca utilizatorul este in grup si false altfel</returns>
		public static bool IsUserInRecrutoriGroup(string nume, string parola, int angajatorId)
		{
			//se obtine numele grupului Recrutori
			string groupRecrutori = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("groupRecrutori");
			return IsUserInGroup(nume, parola, angajatorId, groupRecrutori);
		}
		#endregion

		#region HasUserRightsOnPage
		/// <summary>
		/// Verifica daca un user are dreptul de a vedea o anumita pagina
		/// </summary>
		/// <param name="path">Denumirea paginii</param>
		/// <param name="user">Numele utilizatorului</param>
		/// <returns>Returneaza true daca are acces la pagina si false altfel</returns>
		public static bool HasUserRightsOnPage(string path,WindowsPrincipal user)
		{
			try
			{
				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				Data.Authentication auth = new Data.Authentication(settings.ConnectionString);
				
				//numele grupului HR
				groupHR = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("groupHR");
				//numele grupului de manageri
				groupManagers = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("groupManagers");
				//Modificat:	Oprescu Claudia
				//Data:			20.12.3006
				//Descriere:	S-a adaugat si grupul pentru recrutori la autentificarea utilizatorului
				//numele grupului de recrutori
				groupRecrutori = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("groupRecrutori");

				//se verifica daca user-ul autentificat este in grupul HR
				if(IsUserInHRgroup(user))
				{
					return auth.HasUserRightsOnPage(groupHR, path);
				}
				else
				{
					//se verifica daca user-ul autentificat este in grupul managerilor
					if(IsUserInManagersGroup(user))
					{
						return auth.HasUserRightsOnPage(groupManagers, path);
					}
					else
					{
						if(IsUserInRecrutoriGroup(user))
						{
							return auth.HasUserRightsOnPage(groupRecrutori, path);
						}
					}
				}
						
				return false;
			}
			catch { return false;}
		}
		#endregion

		#region HasUserRightsOnPage
		/// <summary>
		/// Procedura verifica daca un utilizator are dreptul de a accesa o anumita pagina a aplicatiei
		/// </summary>
		/// <param name="path">Numele paginii</param>
		/// <param name="nume">Numele utilizatorului</param>
		/// <param name="parola">Parola utilizatorului</param>
		/// <param name="angajatorId">Id-ul angajatorului de care apartine utilizatorul</param>
		/// <returns>Returneaza true daca utilizatorul poate accesa pagina si false altfel</returns>
		public static bool HasUserRightsOnPage(string path, string nume, string parola, int angajatorId)
		{
			try
			{
				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				Data.Authentication auth = new Data.Authentication(settings.ConnectionString);
				
				//numele grupului HR
				groupHR = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("groupHR");
				//numele grupului de manageri
				groupManagers = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("groupManagers");
				//numele grupului de recrutori
				groupRecrutori = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("groupRecrutori");

				//se verifica daca user-ul autentificat este in grupul HR
				if(IsUserInHRgroup(nume, parola, angajatorId))
				{
					return auth.HasUserRightsOnPage(groupHR, path);
				}
				else
				{
					//se verifica daca user-ul autentificat este in grupul managerilor
					if(IsUserInManagersGroup(nume, parola, angajatorId))
					{
						return auth.HasUserRightsOnPage(groupManagers, path);
					}
					else
					{
						//se verifica daca user-ul autentificat este in grupul recrutorilor
						if(IsUserInRecrutoriGroup(nume, parola, angajatorId))
						{
							return auth.HasUserRightsOnPage(groupRecrutori, path);
						}
					}
				}
						
				return false;
			}
			catch 
			{
				return false;
			}
		}
		#endregion
	}
}
