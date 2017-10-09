using System;

using SiemensTM.Classes;
using SiemensHR.Classes;

namespace SiemensTM.Classes
{
	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login : System.Web.UI.Page
	{
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public Login()
		{}
		#endregion

		#region SaveSessionKey
		/// <summary>
		/// Procedura creaza o variabile de sesiune cu o anumita valoare
		/// </summary>
		/// <param name="key">Numele variabilei</param>
		/// <param name="_value">Valoarea variabilei</param>
		public void SaveSessionKey(string key,object _value)
		{
			this.Session.Add(key,_value);
		}
		#endregion

		#region ClearSessionKey
		/// <summary>
		/// Procedura sterge o variabila de sesiune
		/// </summary>
		/// <param name="key">Numele variabilei</param>
		public void ClearSessionKey(string key)
		{
			this.Session.Remove(key);
		}
		#endregion

		#region GetSessionKey
		/// <summary>
		/// Procedura obtine valoarea unei variabile de sesiune
		/// </summary>
		/// <param name="key">Numele variabilei</param>
		/// <returns>Returneaza valoarea variabilei</returns>
		public object GetSessionKey(string key)
		{
			return this.Session[key];
		}
		#endregion

		#region IsUserLogged
		/// <summary>
		/// Procedura verifica daca un utilizator este autentificat
		/// </summary>
		/// <returns>Returneaza true daca utilizatorul este autentificat si false altfel</returns>
		public bool IsUserLogged()
		{
			return this.GetSessionKey(Definitions.UserKEY)!=null;
		}
		#endregion

		#region IsAdminUser
		/// <summary>
		/// Procedura verifica daca utilizatorul curent este administrator al aplicatiei
		/// </summary>
		/// <returns>Returneaza true daca este administrator si false altfel</returns>
		public bool IsAdminUser()
		{
			return (this.GetLoggedUserID()==1017);
		}
		#endregion

		#region GetLoggedUserID
		/// <summary>
		/// Procedura determina Id-ul utilizatorului autentificat
		/// </summary>
		/// <returns>Returneaza id-ul utilizatorului</returns>
		public int GetLoggedUserID()
		{
			if (this.IsUserLogged())
			{
				return int.Parse(this.GetSessionKey(Definitions.UserKEY).ToString()); 
			}
			else 
			{
				return -1;
			}
		}
		#endregion

		#region GetLoggedAngajat
		/// <summary>
		/// Procedura obtine datele angajatului curent
		/// </summary>
		/// <returns>Returneaza un obiect care contine datele angajatului</returns>
		public Salaries.Business.Angajat GetLoggedAngajat()
		{
			if (this.IsUserLogged())
			{
				return (Salaries.Business.Angajat)this.GetSessionKey(Definitions.UserInstanceKEY);
			}
			else 
			{
				return null;
			}
		}
		#endregion

		#region DoLogin
		/// <summary>
		/// Procedura realizeaza autentificarea utilizatorului
		/// </summary>
		/// <param name="Firma">Firma</param>
		/// <param name="Utilizator">Utilizatorul</param>
		/// <param name="Parola">Parola</param>
		public void DoLogin(string Firma,string Utilizator,string Parola)
		{
			// ************************* obs 1 : to perform login ! - sp - return AngajatID
			int AngajatID = 1017;

			Salaries.Business.Angajat a = new Salaries.Business.Angajat();
			a.AngajatId = AngajatID;
			a.LoadAngajat();	
	
			this.SaveSessionKey(Definitions.UserKEY,AngajatID);
			this.SaveSessionKey(Definitions.UserInstanceKEY,a);
		}
		#endregion

		#region DoQuickLogin
		/// <summary>
		/// Procedura realizeaza autentificarea utilizatorului
		/// </summary>
		/// <param name="AngajatID">Id-ul angajatului</param>
		public void DoQuickLogin(int AngajatID)
		{
			// ************************* obs 1 : to perform login ! - sp - return AngajatID
			Salaries.Business.Angajat a = new Salaries.Business.Angajat();
			a.AngajatId = AngajatID;
			a.LoadAngajat();
			
			this.SaveSessionKey(Definitions.UserKEY,AngajatID);
			this.SaveSessionKey(Definitions.UserInstanceKEY,a);
		}
		#endregion

		#region DoLogout
		/// <summary>
		/// Procedura sterge datele utilizatorului curent
		/// </summary>
		public void DoLogout()
		{
			// ************************* obs 1 : to perform login !
			this.ClearSessionKey(Definitions.UserKEY);
		}
		#endregion

		#region Render
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render (writer);
			if (! this.IsUserLogged()) Response.Redirect("login.aspx",true);
		}
		#endregion
	}
}
