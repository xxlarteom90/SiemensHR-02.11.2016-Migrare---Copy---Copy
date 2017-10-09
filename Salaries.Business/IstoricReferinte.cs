using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for IstoricReferinte.
	/// </summary>
	public class IstoricReferinte
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul referintei
		private int referintaId;
		//Id-ul angajatului
		private long angajatId;
		//Titlul referintei
		private string titlu;
		//Data referintei
		private DateTime data;
		//Descrierea referintei
		private string descriere;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public IstoricReferinte()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul referintei.
		/// </summary>
		public int ReferintaId
		{
			get{ return referintaId; }
			set{ referintaId = value;}
		}
		/// <summary>
		/// ID-ul angajatului.
		/// </summary>
		public long AngajatId
		{
			get{ return angajatId; }
			set{ angajatId = value;}
		}
		/// <summary>
		/// Titlul referintei.
		/// </summary>
		public string Titlu
		{
			get{ return titlu; }
			set{ titlu = value;}
		}
		/// <summary>
		/// Data referintei.
		/// </summary>
		public DateTime Data
		{
			get{ return data; }
			set{ data = value;}
		}
		/// <summary>
		/// Descrierea referintei.
		/// </summary>
		public string Descriere
		{
			get{ return descriere; }
			set{ descriere = value;}
		}
		#endregion

		#region LoadReferinte
		/// <summary>
		/// Procedura selecteaza referintele unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadReferinte()
		{
			Salaries.Data.IstoricReferinte istReferinte = new Salaries.Data.IstoricReferinte(settings.ConnectionString);
			return istReferinte.LoadReferinte(angajatId);
		}
		#endregion

		#region InsertReferinta
		/// <summary>
		/// Procedura adauga o referinta
		/// </summary>
		/// <returns>Returneaza true daca a fost facuta adaugarea si false altfel</returns>
		public bool InsertReferinta()
		{
			Salaries.Data.IstoricReferinte istReferinte = new Salaries.Data.IstoricReferinte(settings.ConnectionString);
			return istReferinte.InsertReferinta(angajatId, titlu, data, descriere);
		}
		#endregion

		#region UpdateReferinta
		/// <summary>
		/// Procedura actualizeaza o referinta
		/// </summary>
		/// <returns>Returneaza true daca a fost facuta modificarea si false altfel</returns>
		public bool UpdateReferinta()
		{
			Salaries.Data.IstoricReferinte istReferinte = new Salaries.Data.IstoricReferinte(settings.ConnectionString);
			return istReferinte.UpdateReferinta(referintaId, angajatId, titlu, data, descriere);
		}
		#endregion

		#region DeleteReferinta
		/// <summary>
		/// Procedura sterge o referinta
		/// </summary>
		public void DeleteReferinta()
		{
			Salaries.Data.IstoricReferinte istReferinte = new Salaries.Data.IstoricReferinte(settings.ConnectionString);
			istReferinte.DeleteReferinta(referintaId);
		}
		#endregion
	}
}
