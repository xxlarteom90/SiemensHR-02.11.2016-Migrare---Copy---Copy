using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for CarteDeMunca.
	/// </summary>
	public class CarteDeMunca
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul perioadei din cartea de munca
		private long idPerioada;
		//Id-ul angajatului
		private long idAngajat;
		//Data de inceput a perioadei
		private DateTime dataDeLa;
		//Data de sfarsit a perioadei
		private DateTime dataPanaLa;
		//daca la siemens sau nu
		private bool laSiemens;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public CarteDeMunca()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul perioadei din cartea de munca
		/// </summary>
		public long IdPerioada
		{
			get	{ return idPerioada; }
			set { idPerioada = value; }
		}
		/// <summary>
		/// Id angajat.
		/// </summary>
		public long IdAngajat
		{
			get	{ return idAngajat; }
			set { idAngajat = value; }
		}
		/// <summary>
		/// Data de inceput a perioadei.
		/// </summary>
		public DateTime DataDeLa
		{
			get	{ return dataDeLa; }
			set { dataDeLa = value; }
		}
		/// <summary>
		/// Data de sfarsit a perioadei.
		/// </summary>
		public DateTime DataPanaLa
		{
			get	{ return dataPanaLa; }
			set { dataPanaLa = value; }
		}
		/// <summary>
		/// La siemens sau nu.
		/// </summary>
		public bool LaSiemens
		{
			get	{ return laSiemens; }
			set { laSiemens = value; }
		}

		#endregion

		#region LoadCarteDeMuncaAngajat
		/// <summary>
		/// Procedura selecteaza toate perioadele din cartea de munca a unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadCarteDeMuncaAngajat()
		{
			Salaries.Data.CarteDeMunca carteMunca = new Salaries.Data.CarteDeMunca(settings.ConnectionString);
			return carteMunca.LoadCarteDeMuncaAngajat(idAngajat);
		}
		#endregion

		#region InsertPerioadaCarteDeMunca
		/// <summary>
		/// Procedura adauga o perioada in carte de munca
		/// </summary>
		public void InsertPerioadaCarteDeMunca()
		{
			Salaries.Data.CarteDeMunca carteMunca = new Salaries.Data.CarteDeMunca(settings.ConnectionString);
			carteMunca.InsertPerioadaCarteDeMunca(idAngajat, dataDeLa, dataPanaLa, laSiemens);
		}
		#endregion

		#region UpdatePerioadaCarteDeMunca
		/// <summary>
		/// Procedura modifica o perioada in carte de munca
		/// </summary>
		public void UpdatePerioadaCarteDeMunca()
		{
			Salaries.Data.CarteDeMunca carteMunca = new Salaries.Data.CarteDeMunca(settings.ConnectionString);
			carteMunca.UpdatePerioadaCarteDeMunca(idPerioada, idAngajat, dataDeLa, dataPanaLa, laSiemens);
		}
		#endregion

		#region DeletePerioadaCarteDeMunca
		/// <summary>
		/// Procedura sterge o perioada in carte de munca
		/// </summary>
		public void DeletePerioadaCarteDeMunca()
		{
			Salaries.Data.CarteDeMunca carteMunca = new Salaries.Data.CarteDeMunca(settings.ConnectionString);
			carteMunca.DeletePerioadaCarteDeMunca(idPerioada, idAngajat, dataDeLa, dataPanaLa, laSiemens);
		}
		#endregion

		#region DeleteToatePerioadeleAngajat
		/// <summary>
		/// Procedura sterge perioadele din cartea de munca ale unui angajat
		/// </summary>
		public void DeleteToatePerioadeleAngajat()
		{
			Salaries.Data.CarteDeMunca carteMunca = new Salaries.Data.CarteDeMunca(settings.ConnectionString);
			carteMunca.DeleteToatePerioadeleAngajat(idAngajat);
		}
		#endregion
	}
}
