/*
 * Autor:		Oprescu Claudia
 * Data:		10.07.2007
 * Descriere:	Clasa se ocupa cu Tipurile de functii.
 */	

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminTipuriDeFunctii.
	/// </summary>
	public class AdminTipuriDeFunctii
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul tipului de functie
		private int tipDeFunctieId;
		//Codul tipului de functie
		private string cod;
		//Denumirea tipului de functie
		private string denumire;
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul tipului de functie.
		/// </summary>
		public int TipDeFunctieId
		{
			get{ return tipDeFunctieId; }
			set{ tipDeFunctieId = value;}
		}
		/// <summary>
		/// Codul tipului de functie.
		/// </summary>
		public string Cod
		{
			get{ return cod; }
			set{ cod = value;}
		}
		/// <summary>
		/// Denumirea tipului de functie.
		/// </summary>
		public string Denumire
		{
			get{ return denumire; }
			set{ denumire = value;}
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminTipuriDeFunctii()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region LoadTipuriDeFunctii
		/// <summary>
		/// Procedura selecteaza tipurile de functii existente
		/// </summary>
		/// <returns>Returneaza un DataSet care contine tipurile de functii</returns>
		public DataSet LoadTipuriDeFunctii()
		{
			Salaries.Data.AdminTipuriDeFunctii tipuriFunctii = new Salaries.Data.AdminTipuriDeFunctii(settings.ConnectionString);
			return tipuriFunctii.LoadTipuriDeFunctii();
		}
		#endregion
	}
}
