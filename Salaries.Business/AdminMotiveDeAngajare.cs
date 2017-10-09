/*
 * Autor:		Oprescu Claudia
 * Data:		09.07.2007
 * Descriere:	Clasa se ocupa cu Motivele de angajare.
 */	

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminMotiveDeAngajare.
	/// </summary>
	public class AdminMotiveDeAngajare
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul motivului
		private int motivDeAngajareId;
		//Codul motivului
		private string cod;
		//Denumirea motivului
		private string denumire;
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul motivului.
		/// </summary>
		public int MotivDeAngajareId
		{
			get{ return motivDeAngajareId; }
			set{ motivDeAngajareId = value;}
		}
		/// <summary>
		/// Codul motivului.
		/// </summary>
		public string Cod
		{
			get{ return cod; }
			set{ cod = value;}
		}
		/// <summary>
		/// Denumirea motivului.
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
		public AdminMotiveDeAngajare()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region LoadMotiveDeAngajare
		/// <summary>
		/// Procedura selecteaza motivele de angajare
		/// </summary>
		/// <returns>Returneaza un DataSet care contine motivele de angajare</returns>
		public DataSet LoadMotiveDeAngajare()
		{
			Salaries.Data.AdminMotiveDeAngajare motive = new Salaries.Data.AdminMotiveDeAngajare(settings.ConnectionString);
			return motive.LoadMotiveDeAngajare();
		}
		#endregion
	}
}
