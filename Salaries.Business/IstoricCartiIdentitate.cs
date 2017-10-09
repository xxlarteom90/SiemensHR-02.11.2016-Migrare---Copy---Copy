using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for IstoricCartiIdentitate.
	/// </summary>
	public class IstoricCartiIdentitate
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul cartii de identitate
		private int carteIdentitateId;
		//Id-ul angajatului
		private long angajatId;
		//CNP-ul angajatului
		private long cnp;
		//CNP-ul anterior al angajatului
		private long cnpAnterior;
		//Numarul CI
		private string numar;
		//Serie CI
		private string serie;
		//Eliberat de CI
		private string eliberatDe;
		//Data eliberarii CI
		private DateTime dataEliberarii;
		//Valabil pana la CI
		private DateTime valabilPanaLa;
		//Specifica daca este activa sau nu
		private bool activ;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public IstoricCartiIdentitate()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul cartii de identitate.
		/// </summary>
		public int CarteIdentitateId
		{
			get{ return carteIdentitateId; }
			set{ carteIdentitateId = value;}
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
		/// CNP-ul angajatului.
		/// </summary>
		public long CNP
		{
			get{ return cnp; }
			set{ cnp = value;}
		}
		/// <summary>
		/// CNP-ul anterior al angajatului.
		/// </summary>
		public long CNPAnterior
		{
			get{ return cnpAnterior; }
			set{ cnpAnterior = value;}
		}
		/// <summary>
		/// Numar CI.
		/// </summary>
		public string Numar
		{
			get{ return numar; }
			set{ numar = value;}
		}
		/// <summary>
		/// Serie CI.
		/// </summary>
		public string Serie
		{
			get{ return serie; }
			set{ serie = value;}
		}
		/// <summary>
		/// Eliberat De CI.
		/// </summary>
		public string EliberatDe
		{
			get{ return eliberatDe; }
			set{ eliberatDe = value;}
		}
		/// <summary>
		/// Data eliberarii CI.
		/// </summary>
		public DateTime DataEliberarii
		{
			get{ return dataEliberarii; }
			set{ dataEliberarii = value;}
		}
		/// <summary>
		/// Valabil pana la CI.
		/// </summary>
		public DateTime ValabilPanaLa
		{
			get{ return valabilPanaLa; }
			set{ valabilPanaLa = value;}
		}
		/// <summary>
		/// Specifica daca este activa sau nu.
		/// </summary>
		public bool Activ
		{
			get{ return activ; }
			set{ activ = value;}
		}
		#endregion

		#region LoadIstoricCartiIdentitate
		/// <summary>
		/// Procedura selecteaza cartile de identitate ale unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine cartile de identitate ale angajatului</returns>
		public DataSet LoadIstoricCartiIdentitate()
		{
			Salaries.Data.IstoricCartiIdentitate ci = new Salaries.Data.IstoricCartiIdentitate(settings.ConnectionString);
			return ci.LoadIstoricCartiIdentitate(angajatId);
		}
		#endregion

		#region CheckIfIsCarteIdentitateActiva
		/// <summary>
		/// Verifica daca este activa o carte de identitate.
		/// </summary>
		/// <returns>true daca este activa, false altfel</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data: 26.05.2006
		/// </remarks>
		public bool CheckIfIsCarteIdentitateActiva()
		{
			Salaries.Data.IstoricCartiIdentitate ci = new Salaries.Data.IstoricCartiIdentitate(settings.ConnectionString);
			return ci.CheckIfIsCarteIdentitateActiva(carteIdentitateId);
		}
		#endregion

		#region InsertCarteIdentitate
		/// <summary>
		/// Procedura adauga o carte de identitate
		/// </summary>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool InsertCarteIdentitate()
		{
			Salaries.Data.IstoricCartiIdentitate ci = new Salaries.Data.IstoricCartiIdentitate(settings.ConnectionString);
			return ci.InsertCarteIdentitate(angajatId, cnp, cnpAnterior, serie, numar, eliberatDe, dataEliberarii, valabilPanaLa, activ);
		}
		#endregion

		#region UpdateCarteIdentitate
		/// <summary>
		/// Procedura actualizeaza o carte de identitate
		/// </summary>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool UpdateCarteIdentitate()
		{
			Salaries.Data.IstoricCartiIdentitate ci = new Salaries.Data.IstoricCartiIdentitate(settings.ConnectionString);
			return ci.UpdateCarteIdentitate(carteIdentitateId, angajatId, cnp, cnpAnterior, serie, numar, eliberatDe, dataEliberarii, valabilPanaLa, activ);
		}
		#endregion

		#region DeleteCarteIdentitate
		/// <summary>
		/// Procedura sterge o carte de identitate
		/// </summary>
		public void DeleteCarteIdentitate()
		{
			Salaries.Data.IstoricCartiIdentitate ci = new Salaries.Data.IstoricCartiIdentitate(settings.ConnectionString);
			ci.DeleteCarteIdentitate(carteIdentitateId);
		}
		#endregion
	}
}
