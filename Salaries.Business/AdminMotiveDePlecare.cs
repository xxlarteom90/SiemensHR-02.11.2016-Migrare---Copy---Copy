/*
 * Autor:		Oprescu Claudia
 * Data:		10.07.2007
 * Descriere:	Clasa se ocupa cu Motivele de plecare.
 */	

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminMotiveDePlecare.
	/// </summary>
	public class AdminMotiveDePlecare
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul motivului
		private int motivDePlecareId;
		//Codul motivului
		private string cod;
		//Denumirea motivului
		private string denumire;
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul motivului.
		/// </summary>
		public int MotivDePlecareId
		{
			get{ return motivDePlecareId; }
			set{ motivDePlecareId = value;}
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
		public AdminMotiveDePlecare()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region LoadMotiveDePlecare
		/// <summary>
		/// Procedura selecteaza motivele de plecare
		/// </summary>
		/// <returns>Returneaza un DataSet care contine motivele de plecare</returns>
		public DataSet LoadMotiveDePlecare()
		{
			Salaries.Data.AdminMotiveDePlecare motive = new Salaries.Data.AdminMotiveDePlecare(settings.ConnectionString);
			return motive.LoadMotiveDePlecare();
		}
		#endregion
	}
}
