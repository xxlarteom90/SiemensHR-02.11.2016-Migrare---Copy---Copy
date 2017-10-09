using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for IstoricConcediuMedicalAngajat.
	/// </summary>
	public class IstoricConcediuMedicalAngajat
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
		public IstoricConcediuMedicalAngajat()
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

		#region LoadIstoricCM
		/// <summary>
		/// Procedura selecteaza concediile medicale ale unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine date despre concediu</returns>
		public DataSet LoadIstoricCM()
		{
			Salaries.Data.IstoricConcediuMedicalAngajat istCM = new Salaries.Data.IstoricConcediuMedicalAngajat(settings.ConnectionString);
			return istCM.LoadIstoricCM(angajatId, Salaries.Business.SituatieLunaraAngajat.codAbsente[ 3 ], Salaries.Business.SituatieLunaraAngajat.codAbsente[ 4 ]);
		}
		#endregion
	}
}
