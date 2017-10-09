using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for IstoricPasaport.
	/// </summary>
	public class IstoricPasaport
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul pasaportului
		private int pasaportId;
		//Id-ul angajatului
		private long angajatId;
		//Seria pentur pasaport
		private string serie;
		//Numarul pentru pasaport
		private string numar;
		//Institutia care a eliberat pasaportul
		private string eliberatDe;
		//Data la care a fost eliberat
		private DateTime dataEliberarii;
		//Data pana la care este valabil
		private DateTime valabilPanaLa;
		//Specifica daca NIF-ul este activ sau nu
		private bool activ;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public IstoricPasaport()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul pasaportului.
		/// </summary>
		public int PasaportId
		{
			get{ return pasaportId; }
			set{ pasaportId = value;}
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
		/// Seria pasaportului.
		/// </summary>
		public string Serie
		{
			get{ return serie; }
			set{ serie = value;}
		}
		/// <summary>
		/// Numarul pasaportului.
		/// </summary>
		public string Numar
		{
			get{ return numar; }
			set{ numar = value;}
		}
		/// <summary>
		/// Institutia care a eliberat pasaportul.
		/// </summary>
		public string EliberatDe
		{
			get{ return eliberatDe; }
			set{ eliberatDe = value;}
		}
		/// <summary>
		/// Data eliberarii.
		/// </summary>
		public DateTime DataEliberarii
		{
			get{ return dataEliberarii; }
			set{ dataEliberarii = value;}
		}
		/// <summary>
		/// Data pana la care e valabil.
		/// </summary>
		public DateTime ValabilPanaLa
		{
			get{ return valabilPanaLa; }
			set{ valabilPanaLa = value;}
		}
		/// <summary>
		/// Specifica daca pasaportul este activ sau nu.
		/// </summary>
		public bool Activ
		{
			get{ return activ; }
			set{ activ = value;}
		}
		#endregion

		#region LoadIstoricPasapoarte
		/// <summary>
		/// Procedura selecteaza pasapoartele unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadIstoricPasapoarte()
		{
			Salaries.Data.IstoricPasaport istPas = new Salaries.Data.IstoricPasaport(settings.ConnectionString);
			return istPas.LoadIstoricPasapoarte(angajatId);
		}
		#endregion

		#region InsertPasaport
		/// <summary>
		/// Procedura adauga un pasaport pentur un angajat
		/// </summary>
		public void InsertPasaport()
		{
			Salaries.Data.IstoricPasaport istPas = new Salaries.Data.IstoricPasaport(settings.ConnectionString);
			istPas.InsertPasaport(angajatId, serie, numar, eliberatDe, dataEliberarii, valabilPanaLa, activ);
		}
		#endregion

		#region UpdatePasaport
		/// <summary>
		/// Procedura actualizeaza un pasaport al unui angajat
		/// </summary>
		public void UpdatePasaport()
		{
			Salaries.Data.IstoricPasaport istPas = new Salaries.Data.IstoricPasaport(settings.ConnectionString);
			istPas.UpdatePasaport(pasaportId, angajatId, serie, numar, eliberatDe, dataEliberarii, valabilPanaLa, activ);
		}
		#endregion

		#region DeletePasaport
		/// <summary>
		/// Procedura sterge un pasaport
		/// </summary>
		public void DeletePasaport()
		{
			Salaries.Data.IstoricPasaport istPas = new Salaries.Data.IstoricPasaport(settings.ConnectionString);
			istPas.DeletePasaport(pasaportId);
		}
		#endregion

		#region CheckIfPasaportCanBeAdded
		/// <summary>
		/// Procedura verifica daca un pasaport poate fi adaugat astfel incat sa nu se creeze duplicate
		/// </summary>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfPasaportCanBeAdded()
		{
			Salaries.Data.IstoricPasaport istPas = new Salaries.Data.IstoricPasaport(settings.ConnectionString);
			return istPas.CheckIfPasaportCanBeAdded(pasaportId, serie, numar);
		}
		#endregion
	}
}
