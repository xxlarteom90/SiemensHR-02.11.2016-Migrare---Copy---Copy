/*
 * Autor: Cristina Raluca Muntean
 * Data:  22.08.2005
 */
using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Administrarea grupurilor de utilizatori ai aplicatiei.
	/// </summary>
	public class GrupUtilizatori
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		// ID-ul grupului de utilizatori.
		private int grupID;
		// Numele grupului de utilizatori.
		private string numeGrup;
		// Descrierea grupului de utilizatori.
		private string descriereGrup;
		#endregion
		
		#region Constructor
		
		/// <summary>
		/// Constructor.
		/// </summary>
		public GrupUtilizatori()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati

		/// <summary>
		/// ID-ul grupului de utilizatori.
		/// </summary>
		public int GrupID
		{
			get
			{
				return grupID;
			}
			set
			{
				grupID=value;
			}
		}

		/// <summary>
		/// Numele grupului de utilizatori.
		/// </summary>
		public string NumeGrup
		{
			get
			{
				return numeGrup;
			}
			set
			{
				numeGrup=value;
			}
		}

		/// <summary>
		/// Descrierea grupului de utilizatori.
		/// </summary>
		public string DescriereGrup
		{
			get
			{
				return descriereGrup;
			}
			set
			{
				descriereGrup=value;
			}
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Returneaza toate detaliile despre un grup de utilizatori.
		/// </summary>
		/// <param name="grupID"> ID-ul grupului de utilizatori.</param>
		/// <returns> Un struct ce cuprinde toate detaliile despre un grup de utilizatori.</returns>
		public  Salaries.Data.GrupUtilizatoriDetails GetDetalii(int grupID)
		{
			Data.GrupuriUtilizatori grup = new Salaries.Data.GrupuriUtilizatori(settings.ConnectionString);

			return grup.GetDetalii(grupID);
		}
		#endregion
		
		#region GetGrupuriUtilizatori
		/// <summary>
		/// Returneaza detaliile despre toate grupurile de utilizatori.
		/// </summary>
		/// <returns></returns>
		public DataSet GetGrupuriUtilizatori()
		{
			Data.GrupuriUtilizatori grup = new Salaries.Data.GrupuriUtilizatori(settings.ConnectionString);

			return grup.GetGrupuriUtilizatori();
		}
		#endregion

		#region Insert
		/// <summary>
		/// Insereaza un grup de utilizatori.
		/// </summary>
		/// <param name="numeGrup"> Numele grupului de utilizatori.</param>
		/// <param name="descriereGrup"> Descrierea grupului de utilizatori.</param>
		/// <returns> ID_ul grupului de utilizatori inserat.</returns>
		public int Insert(string numeGrup, string descriereGrup)
		{
			Data.GrupuriUtilizatori grup = new Salaries.Data.GrupuriUtilizatori(settings.ConnectionString);

			return grup.Insert(numeGrup, descriereGrup);
		}
		#endregion

		#region Update
		/// <summary>
		/// Este realizat update-ul grupului de utilizatori.
		/// </summary>
		public void Update()
		{
			Data.GrupuriUtilizatori grup = new Salaries.Data.GrupuriUtilizatori(settings.ConnectionString);

			grup.Update(grupID, numeGrup, descriereGrup);
		}
		#endregion

		#region Delete
		/// <summary>
		/// Sterge grupul de utilizatori.
		/// </summary>
		public void Delete()
		{
			Data.GrupuriUtilizatori grup = new Salaries.Data.GrupuriUtilizatori(settings.ConnectionString);
			grup.Delete(grupID);	
		}
		#endregion		
	}
}
