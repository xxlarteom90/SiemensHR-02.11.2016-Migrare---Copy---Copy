using System;
using System.Data;
using Salaries.Business;
using System.Data.SqlClient;
using System.Web.UI;

using SiemensHR.Classes;
using SiemensHR.utils;

namespace SiemensHR.InterfataSalarii.Classes
{
	/// <summary>
	/// Summary description for BaseModule.
	/// </summary>
	public class BaseModule : System.Web.UI.UserControl
	{
		#region Variabile
		private Salaries.Configuration.ModuleSettings settings;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public BaseModule()
		{}
		#endregion

		#region SaveSessionKey
		/// <summary>
		/// Proceudra salveaza valoarea unei variabile de sesiune
		/// </summary>
		/// <param name="key">Numele cheii</param>
		/// <param name="_value">Valoarea variabilei</param>
		public void SaveSessionKey(string key,object _value)
		{
			Session[key]=_value;
		}
		#endregion
		
		#region GetSessionKey
		/// <summary>
		/// Procedura returneaza valoarea unei variabile de sesiune
		/// </summary>
		/// <param name="key">Numele variabilei de sesiune</param>
		/// <returns>Returneaza valoarea variabilei</returns>
		public object GetSessionKey(string key)
		{
			return this.Session[key];
		}
		#endregion
		
		#region SetCurrentMonth
		/// <summary>
		/// Procedura seteaza valoarea variabilei de sesiune care retine luna curenta
		/// </summary>
		/// <param name="LunaID">Id-ul lunii curente</param>
		public void SetCurrentMonth(int LunaID)
		{
			this.SaveSessionKey(Definitions.LunaCurentaKey,LunaID);
		}
		#endregion
		
		#region GetAngajator
		/// <summary>
		/// Procedura returneaza angajatorul curent
		/// </summary>
		/// <returns>Id-ul angajatorului curent</returns>
		public int GetAngajator()
		{
			return int.Parse(this.GetSessionKey(Definitions.AngajatorKey).ToString());
		}
		#endregion

		#region GetAngajat
		/// <summary>
		/// Procedura returneaza angajatul curent
		/// </summary>
		/// <returns>Returneaza id-ul angajatului curent</returns>
		public int GetAngajat()
		{
			return int.Parse(this.GetSessionKey(Definitions.AngajatKey).ToString());
		}
		#endregion

		#region SetAngajat
		/// <summary>
		/// Procedura seteaza valoarea variabilei care retine angajatul curent
		/// </summary>
		/// <param name="AngajatID">Id-ul angajatului</param>
		public void SetAngajat(long AngajatID)
		{
			this.SaveSessionKey(Definitions.AngajatKey,AngajatID);
		}
		#endregion

		#region CurrentMonthInSession
		/// <summary>
		/// Predura obtine valoarea variabilei de sesiune a lunii curente
		/// </summary>
		/// <returns>Returneaza true daca acesta este diferita de null si false altfel</returns>
		public bool CurrentMonthInSession()
		{
			return this.GetSessionKey(Definitions.LunaCurentaKey)!=null;
		}
		#endregion

		#region GetCurrentMonth
		/// <summary>
		/// Predura obtine valoarea variabilei de sesiune a lunii curente
		/// </summary>
		/// <returns>Returneaza id-ul lunii curente</returns>
		public int GetCurrentMonth()
		{
			return (int) this.GetSessionKey(Definitions.LunaCurentaKey);
		}
		#endregion

		#region IsPontajAvailable
		/// <summary>
		/// Functie necesara pentru verificarea existentei datelor necesate functionarii pontajului.
		/// Daca aceste date nu sunt disponibile, atunci link-ul 'Pontaj' nu este accesibil
		/// </summary>
		/// <returns>Returneaza true daca datele sunt disponibile si false altfel</returns>
		public bool IsPontajAvailable()
		{
			DataSet ds;
			//Verificam daca exista intrari in nomenclator boli
			NomenclatorBoli nb = new NomenclatorBoli();
			ds = nb.GetBoli();
			if ( ds.Tables[0].Rows.Count == 0)
			{
				return false;
			}
			else
			{
				ds.Clear();
			}

			//Verificam daca exista intrari in nomenclator tipurie ore lucrate
			NomenclatorTipOreLucrate ntol = new NomenclatorTipOreLucrate();
			ds = ntol.GetTipuriOreLucrate();
			if ( ds.Tables[0].Rows.Count == 0)
			{
				return false;
			}
			else
			{
				ds.Clear();
			}

			//Verificam daca exista intrari in nomenclator tipuri absente
			NomenclatorTipAbsente nta = new NomenclatorTipAbsente();
			ds = nta.GetTipuriAbsente();
			if ( ds.Tables[0].Rows.Count == 0)
			{
				return false;
			}
			else
			{
				ds.Clear();
			}

			//Verificam daca angajatorul curent are luna activa
			int idAngajator = int.Parse(Session["AngajatorID"].ToString());
			Salaries.Business.Luni objLuni = new Salaries.Business.Luni(idAngajator);
			DataSet myDs = objLuni.GetLunaActivaDataSet();

			string idLunaActiva;
			int lunaID = 0;
			if ( myDs.Tables[0].Rows.Count == 0)
			{
				return false;
			}
			else
			{
				idLunaActiva = myDs.Tables[0].Rows[0][0].ToString();
				lunaID =  int.Parse(myDs.Tables[0].Rows[0]["LunaID"].ToString());
				myDs.Clear();
			}

			//Verificam daca exista zile pt luna activa in table tm_zile	
			objLuni.id = lunaID;
			myDs = objLuni.ExistaZilePentruLunaActiva();
			if ( myDs.Tables[0].Rows.Count == 0)
			{
				return false;
			}
			else
			{
				myDs.Clear();
			}

			//Verficicam daca exista angajati pt angajatorul curent
			//Pentru ca exista un singur angajator nu mai este necesar parametrul pentru idAngajator
			//Este suficient sa se selecteze toti angajatii pentru a verifica daca exista angajati la angajatorul curent
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			myDs = angajat.GetAngajatIDAll();
			if ( myDs.Tables[0].Rows.Count == 0)
			{
				return false;
			}

			return true;
		}
		#endregion
	}
}
