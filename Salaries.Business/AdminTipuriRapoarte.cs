using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminTipuriRapoarte.
	/// </summary>
	public class AdminTipuriRapoarte
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul tipului de raport
		private int tipRaportId;
		//Denumirea tipului de raport
		private string denumire;
		//Descrierea tipului de raport
		private string descriere;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminTipuriRapoarte()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul tipului de raport
		/// </summary>
		public int TipRaportId
		{
			get	{ return tipRaportId; }
			set { tipRaportId = value; }
		}
		/// <summary>
		/// Denumirea tipului de raport
		/// </summary>
		public string Denumire
		{
			get	{ return denumire; }
			set { denumire = value; }
		}
		/// <summary>
		/// Descrierea tipului de raport
		/// </summary>
		public string Descriere
		{
			get	{ return descriere; }
			set { descriere = value; }
		}
		#endregion

		#region LoadInfoTipuriRapoarte
		/// <summary>
		/// Procedura selecteaza toate tipurile de rapoarte
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadInfoTipuriRapoarte()
		{
			Salaries.Data.AdminTipuriRapoarte tipRaport = new Salaries.Data.AdminTipuriRapoarte(settings.ConnectionString);
			return tipRaport.LoadInfoTipuriRapoarte();
		}
		#endregion

		#region InsertTipRaport
		/// <summary>
		/// Procedura adauga un tip de raport
		/// </summary>
		public void InsertTipRaport()
		{
			Salaries.Data.AdminTipuriRapoarte tipRaport = new Salaries.Data.AdminTipuriRapoarte(settings.ConnectionString);
			tipRaport.InsertTipRaport(tipRaportId, denumire, descriere);
		}
		#endregion

		#region UpdateTipRaport
		/// <summary>
		/// Procedura actualizeaza un tip de raport
		/// </summary>
		public void UpdateTipRaport()
		{
			Salaries.Data.AdminTipuriRapoarte tipRaport = new Salaries.Data.AdminTipuriRapoarte(settings.ConnectionString);
			tipRaport.UpdateTipRaport(tipRaportId, denumire, descriere);
		}
		#endregion

		#region DeleteTipRaport
		/// <summary>
		/// Procedura sterge un tip de raport
		/// </summary>
		public void DeleteTipRaport()
		{
			Salaries.Data.AdminTipuriRapoarte tipRaport = new Salaries.Data.AdminTipuriRapoarte(settings.ConnectionString);
			tipRaport.DeleteTipRaport(tipRaportId);
		}
		#endregion

		#region GetTipRaportInfo
		/// <summary>
		/// Procedura selecteaza un tip de raport
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipRaportInfo()
		{
			Salaries.Data.AdminTipuriRapoarte tipRaport = new Salaries.Data.AdminTipuriRapoarte(settings.ConnectionString);
			return tipRaport.GetTipRaportInfo(tipRaportId);
		}
		#endregion

		#region CheckIfTipRaportCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un tip de raport poate fi sters
		/// </summary>
		/// <returns>Returneaza rezultatul verificarii</returns>
		public int CheckIfTipRaportCanBeDeleted()
		{
			Salaries.Data.AdminTipuriRapoarte tipRaport = new Salaries.Data.AdminTipuriRapoarte(settings.ConnectionString);
			return tipRaport.CheckIfTipRaportCanBeDeleted(tipRaportId);
		}
		#endregion

		#region CheckIfTipRaportCanBeAdded
		/// <summary>
		/// Procedura verifica sa nu se adauge duplicate in tabela TipuriRapoarte prin adaugare/modificare
		/// </summary>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfTipRaportCanBeAdded()
		{
			Salaries.Data.AdminTipuriRapoarte tipRaport = new Salaries.Data.AdminTipuriRapoarte(settings.ConnectionString);
			return tipRaport.CheckIfTipRaportCanBeAdded(tipRaportId, denumire);
		}
		#endregion
	}
}
