using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for SarbatoriLegale.
	/// </summary>
	public class SarbatoriLegale
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul sarbatorii
		private int sarbatoareId;
		//Denumirea sarbatorii
		private string denumire;
		//Descrierea sarbatorii
		private string descriere;
		//Data sarbatorii
		private DateTime dataSarbatoare;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public SarbatoriLegale()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul sarbatorii.
		/// </summary>
		public int SarbatoareId
		{
			get{ return sarbatoareId; }
			set{ sarbatoareId = value;}
		}
		/// <summary>
		/// Denumirea sarbatorii.
		/// </summary>
		public string Denumire
		{
			get{ return denumire; }
			set{ denumire = value;}
		}
		/// <summary>
		/// Descrierea sarbatorii.
		/// </summary>
		public string Descriere
		{
			get{ return descriere; }
			set{ descriere = value;}
		}
		/// <summary>
		/// Data sarbatorii.
		/// </summary>
		public DateTime DataSarbatoare
		{
			get{ return dataSarbatoare; }
			set{ dataSarbatoare = value;}
		}
		#endregion

		#region LoadSarbatoriLegale
		/// <summary>
		/// Procedura selecteaza sarbatorile legale
		/// </summary>
		/// <returns>Returneaza un DataSet care contine sarbatorile</returns>
		public DataSet LoadSarbatoriLegale()
		{
			Salaries.Data.SarbatoriLegale sarbatori = new Salaries.Data.SarbatoriLegale(settings.ConnectionString);
			return sarbatori.LoadSarbatoriLegale();
		}
		#endregion

		#region InsertSarbatoareLegala
		/// <summary>
		/// Procedura adauga o sarbatoare legala
		/// </summary>
		public void InsertSarbatoareLegala()
		{
			Salaries.Data.SarbatoriLegale sarbatori = new Salaries.Data.SarbatoriLegale(settings.ConnectionString);
			sarbatori.InsertSarbatoareLegala(denumire, descriere, dataSarbatoare);
		}
		#endregion

		#region UpdateSarbatoareLegala
		/// <summary>
		/// Procedura actualizeaza o sarbatoare legala
		/// </summary>
		/// <param name="oldData">Data veche a sarbatorii legale</param>
		public void UpdateSarbatoareLegala(DateTime oldData)
		{
			Salaries.Data.SarbatoriLegale sarbatori = new Salaries.Data.SarbatoriLegale(settings.ConnectionString);
			sarbatori.UpdateSarbatoareLegala(denumire, descriere, dataSarbatoare, oldData);
		}
		#endregion

		#region DeleteSarbatoareLegala
		/// <summary>
		/// Procedura sterge o sarbatoare legala
		/// </summary>
		public void DeleteSarbatoareLegala()
		{
			Salaries.Data.SarbatoriLegale sarbatori = new Salaries.Data.SarbatoriLegale(settings.ConnectionString);
			sarbatori.DeleteSarbatoareLegala(dataSarbatoare);
		}
		#endregion

		#region CheckInsertSarbatoareLegala
		/// <summary>
		/// Procedura verifica daca o sarbatoare legala exista deja pentru o anumita data
		/// </summary>
		/// <returns>Returneaza true daca nu apare si false altfel</returns>
		public bool CheckInsertSarbatoareLegala()
		{
			Salaries.Data.SarbatoriLegale sarbatori = new Salaries.Data.SarbatoriLegale(settings.ConnectionString);
			return sarbatori.CheckInsertSarbatoareLegala(dataSarbatoare);
		}
		#endregion

		#region SetDataTipSarbatoare
		/// <summary>
		/// Procedura seteaza o data ca fiind sarbatoare
		/// </summary>
		/// <param name="sarbatoare">Este sarbatoare sau nu</param>
		public void SetDataTipSarbatoare(bool sarbatoare)
		{
			Salaries.Data.SarbatoriLegale sarbatori = new Salaries.Data.SarbatoriLegale(settings.ConnectionString);
			sarbatori.SetDataTipSarbatoare(dataSarbatoare, sarbatoare);
		}
		#endregion
	}
}
