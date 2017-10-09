using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for Checkupuri.
	/// </summary>
	public class Checkupuri 
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul checkup-ului
		private int checkupId;
		//Id-ul angajatului
		private long angajatId;
		//Necesar instruire pentru checkup
		private string necesarInstruire;
		//Data efectuarii urmatorului
		private DateTime dataUrmatorului;
		//Id-ul responsabilului
		private long responsabilId;
		//Data efectuarii checkup-ului
		private DateTime dataEfectuarii;
		//Fisierul de checkup
		private string checkupFile;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public Checkupuri()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul checkup-ului.
		/// </summary>
		public int CheckupId
		{
			get{ return checkupId; }
			set{ checkupId = value;}
		}
		/// <summary>
		/// ID-ul angajatului.
		/// </summary>
		public long AngajatId
		{
			get{ return angajatId; }
			set{ angajatId = value;}
		}
		/// <summary>
		/// Necesar instruire.
		/// </summary>
		public string NecesarInstruire
		{
			get{ return necesarInstruire; }
			set{ necesarInstruire = value;}
		}
		/// <summary>
		/// Data urmatorului checkup.
		/// </summary>
		public DateTime DataUrmatorului
		{
			get{ return dataUrmatorului; }
			set{ dataUrmatorului = value;}
		}
		/// <summary>
		/// ID-ul respunsabilului.
		/// </summary>
		public long ResponsabilId
		{
			get{ return responsabilId; }
			set{ responsabilId = value;}
		}
		/// <summary>
		/// Data efectuarii checkup.
		/// </summary>
		public DateTime DataEfectuarii
		{
			get{ return dataEfectuarii; }
			set{ dataEfectuarii = value;}
		}
		/// <summary>
		/// Fisierul checkup-ului.
		/// </summary>
		public string CheckupFile
		{
			get{ return checkupFile; }
			set{ checkupFile = value;}
		}
		#endregion

		#region LoadCheckupuriAngajat
		/// <summary>
		/// Procedura selecteaza checkup-urile unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadCheckupuriAngajat()
		{
			Salaries.Data.Checkupuri checkup = new Salaries.Data.Checkupuri(settings.ConnectionString);
			return checkup.LoadCheckupuriAngajat(angajatId);
		}
		#endregion

		#region InsertCheckup
		/// <summary>
		/// Procedura adauga un checkup
		/// </summary>
		/// <returns>Returneaza id-ul checkup-ului nou adaugat</returns>
		public int InsertCheckup()
		{
			Salaries.Data.Checkupuri checkup = new Salaries.Data.Checkupuri(settings.ConnectionString);
			return checkup.InsertCheckup(angajatId, necesarInstruire, dataUrmatorului, responsabilId, dataEfectuarii, checkupFile);
		}
		#endregion

		#region UpdateCheckup
		/// <summary>
		/// Procedura actualizeaza un checkup
		/// </summary>
		public void UpdateCheckup()
		{
			Salaries.Data.Checkupuri checkup = new Salaries.Data.Checkupuri(settings.ConnectionString);
			checkup.UpdateCheckup(checkupId, angajatId, necesarInstruire, dataUrmatorului, responsabilId, dataEfectuarii, checkupFile);
		}
		#endregion

		#region DeleteCheckup
		/// <summary>
		/// Procedura sterge un checkup
		/// </summary>
		public void DeleteCheckup()
		{
			Salaries.Data.Checkupuri checkup = new Salaries.Data.Checkupuri(settings.ConnectionString);
			checkup.DeleteCheckup(checkupId);
		}
		#endregion
	}
}
