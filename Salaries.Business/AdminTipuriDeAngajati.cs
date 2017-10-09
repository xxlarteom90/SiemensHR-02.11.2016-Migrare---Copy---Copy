/*
 * Autor:		Oprescu Claudia
 * Data:		09.07.2007
 * Descriere:	Clasa se ocupa cu Tipurile de agajati.
 */	

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminTipuriDeAngajati.
	/// </summary>
	public class AdminTipuriDeAngajati
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul tipului de angajat
		private int tipDeAngajatId;
		//Codul tipului de angajat
		private string cod;
		//Denumirea tipului de angajat
		private string denumire;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminTipuriDeAngajati()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul tipului de angajat.
		/// </summary>
		public int TipDeAngajatId
		{
			get{ return tipDeAngajatId; }
			set{ tipDeAngajatId = value;}
		}
		/// <summary>
		/// Codul tipului de angajat.
		/// </summary>
		public string Cod
		{
			get{ return cod; }
			set{ cod = value;}
		}
		/// <summary>
		/// Denumirea tipului de angajat.
		/// </summary>
		public string Denumire
		{
			get{ return denumire; }
			set{ denumire = value;}
		}
		#endregion

		#region LoadTipuriDeAngajati
		/// <summary>
		/// Procedura selecteaza tipurile de angajati existente
		/// </summary>
		/// <returns>Returneaza un DataSet care contine tipurile de angajati</returns>
		public DataSet LoadTipuriDeAngajati()
		{
			Salaries.Data.AdminTipuriDeAngajati tipuriAngajati = new Salaries.Data.AdminTipuriDeAngajati(settings.ConnectionString);
			return tipuriAngajati.LoadTipuriDeAngajati();
		}
		#endregion
	}
}
