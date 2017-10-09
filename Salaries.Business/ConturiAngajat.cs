using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for ConturiAngajat.
	/// </summary>
	public class ConturiAngajat
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		// ID-ul contului.
		private int contId;
		// ID-ul angajatului.
		private long angajatId;
		// ID-ul bancii.
		private int bancaId;
		// Numar cont.
		private string numarCont;
		// Moneda in care a fost deschis contul.
		private string moneda;
		// Starea contului: activ - true, inactiv - false.
		private bool activ;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public ConturiAngajat()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul contului.
		/// </summary>
		public int ContId
		{
			get{ return contId; }
			set{ contId = value;}
		}
		/// <summary>
		/// ID-ul angajatului.
		/// </summary>
		public long AngajatId
		{
			get { return angajatId; }
			set { angajatId = value; }
		}
		/// <summary>
		/// ID-ul bancii de care apartine contul.
		/// </summary>
		public int BancaId
		{
			get { return bancaId; }
			set { bancaId = value; }
		}
		/// <summary>
		/// Numarul contuluii.
		/// </summary>
		public string NumarCont
		{
			get { return numarCont; }
			set { numarCont = value; }
		}
		/// <summary>
		/// Moneda in care a fost deschis contul.
		/// </summary>
		public string Moneda
		{
			get { return moneda; }
			set { moneda = value; }
		}
		/// <summary>
		/// Starea contului: activ - true, inactiv - false. 
		/// Pot fi active in acelasi timp doar conturi in monede diferite.
		/// </summary>
		public bool Activ
		{
			get { return activ; }
			set { activ = value; }
		}
		#endregion

		#region LoadConturiBanca
		/// <summary>
		/// Procedura selecteaza conturile unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadConturiBanca()
		{
			Salaries.Data.ConturiAngajat conturi = new Salaries.Data.ConturiAngajat(settings.ConnectionString);
			return conturi.LoadConturiBanca(angajatId);
		}
		#endregion

		#region InsertCont
		/// <summary>
		/// Procedura adauga un cont pentru angajat
		/// </summary>
		public void InsertCont()
		{
			Salaries.Data.ConturiAngajat conturi = new Salaries.Data.ConturiAngajat(settings.ConnectionString);
			conturi.InsertCont(bancaId, numarCont, moneda, angajatId, activ);
		}
		#endregion

		#region UpdateCont
		/// <summary>
		/// Procedura actualizeaza un cont al unui angajat
		/// </summary>
		public void UpdateCont()
		{	
			Salaries.Data.ConturiAngajat conturi = new Salaries.Data.ConturiAngajat(settings.ConnectionString);
			conturi.UpdateCont(contId, bancaId, numarCont, moneda, angajatId, activ);
		}
		#endregion

		#region DeleteCont
		/// <summary>
		/// Procedura sterge un cont al unui angajat
		/// </summary>
		public void DeleteCont()
		{
			Salaries.Data.ConturiAngajat conturi = new Salaries.Data.ConturiAngajat(settings.ConnectionString);
			conturi.DeleteCont(contId);
		}
		#endregion

		#region CheckIfContAngajatCanBeAdded
		/// <summary>
		/// Procedura verifica daca un cont al unui angajat poate fi adaugat
		/// </summary>
		/// <returns>Returneaza true daca se poate face adaugare sau modificare, si false altfel</returns>
		public bool CheckIfContAngajatCanBeAdded()
		{
			Salaries.Data.ConturiAngajat conturi = new Salaries.Data.ConturiAngajat(settings.ConnectionString);
			return conturi.CheckIfContAngajatCanBeAdded(numarCont, contId);
		}
		#endregion
	}
}
