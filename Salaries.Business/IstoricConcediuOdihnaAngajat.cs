using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for IstoricConcediuOdihnaAngajat.
	/// </summary>
	public class IstoricConcediuOdihnaAngajat
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul angajatului
		private long angajatId;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public IstoricConcediuOdihnaAngajat()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul angajatului.
		/// </summary>
		public long AngajatId
		{
			get{ return angajatId; }
			set{ angajatId = value;}
		}
		#endregion

		#region LoadIstoricCO
		/// <summary>
		/// Procedura selecteaza concediile de oaihna ale unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine concediile angajatului</returns>
		public DataSet LoadIstoricCO()
		{
			Salaries.Data.IstoricConcediuOdihnaAngajat istCO = new Salaries.Data.IstoricConcediuOdihnaAngajat(settings.ConnectionString);
			return istCO.LoadIstoricCO(angajatId, Salaries.Business.SituatieLunaraAngajat.codAbsente[ 2 ]);
		}
		#endregion
	}
}
