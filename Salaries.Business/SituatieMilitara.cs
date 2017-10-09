using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for SituatieMilitara.
	/// </summary>
	public class SituatieMilitara
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul angajatului
		private long angajatId;
		//Evidenta CMJ
		private string evidentaCMJ;
		//Data intrarii in evidenta
		private DateTime dataIntrareEvidenta;
		//Gradul
		private string gradul;
		//Serie livret
		private string serieLivret;
		//Numar livret
		private string numarLivret;
		//Specialitati militare
		private string specialitatiMilitare;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public SituatieMilitara()
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
		/// <summary>
		/// Evidenta CMJ.
		/// </summary>
		public string EvidentaCMJ
		{
			get{ return evidentaCMJ; }
			set{ evidentaCMJ = value;}
		}
		/// <summary>
		/// Data intrarii in evidenta.
		/// </summary>
		public DateTime DataIntrareEvidenta
		{
			get{ return dataIntrareEvidenta; }
			set{ dataIntrareEvidenta = value;}
		}
		/// <summary>
		/// Gradul.
		/// </summary>
		public string Gradul
		{
			get{ return gradul; }
			set{ gradul = value;}
		}
		/// <summary>
		/// Serie livret.
		/// </summary>
		public string SerieLivret
		{
			get{ return serieLivret; }
			set{ serieLivret = value;}
		}
		/// <summary>
		/// Numar livret.
		/// </summary>
		public string NumarLivret
		{
			get{ return numarLivret; }
			set{ numarLivret = value;}
		}
		/// <summary>
		/// Specialitati militare.
		/// </summary>
		public string SpecialitatiMilitare
		{
			get{ return specialitatiMilitare; }
			set{ specialitatiMilitare = value;}
		}
		#endregion

		#region GetSituatieMilitaraInfo
		/// <summary>
		/// Procedura selecteaza situatia militara a unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetSituatieMilitaraInfo()
		{
			Salaries.Data.SituatieMilitara sit = new Salaries.Data.SituatieMilitara(settings.ConnectionString);
			return sit.GetSituatieMilitaraInfo(angajatId);
		}
		#endregion

		#region InsertUpdateSituatieMilitara
		/// <summary>
		/// Procedura adauga situatia militara a unui angajat
		/// </summary>
		public void InsertUpdateSituatieMilitara()
		{
			Salaries.Data.SituatieMilitara sit = new Salaries.Data.SituatieMilitara(settings.ConnectionString);
			sit.InsertUpdateSituatieMilitara(angajatId, serieLivret, numarLivret, evidentaCMJ, dataIntrareEvidenta, gradul, specialitatiMilitare);
		}
		#endregion
	}
}
