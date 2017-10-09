using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for IstoricTraining.
	/// </summary>
	public class IstoricTraining
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul istoricului
		private int istoricTrainingId;
		//Id-ul angajatului
		private long angajatId;
		//Id-ul cursului
		private int trainingId;
		//Data de inceput
		private DateTime dataStart;
		//Data de sfarsit
		private DateTime dataEnd;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public IstoricTraining()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul istoricului.
		/// </summary>
		public int IstoricTrainingId
		{
			get{ return istoricTrainingId; }
			set{ istoricTrainingId = value;}
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
		/// ID-ul cursului.
		/// </summary>
		public int TrainingId
		{
			get{ return trainingId; }
			set{ trainingId = value;}
		}
		/// <summary>
		/// Data de inceput.
		/// </summary>
		public DateTime DataStart
		{
			get{ return dataStart; }
			set{ dataStart = value;}
		}
		/// <summary>
		/// Data de sfarsit.
		/// </summary>
		public DateTime DataEnd
		{
			get{ return dataEnd; }
			set{ dataEnd = value;}
		}
		#endregion

		#region LoadIstoricTraining
		/// <summary>
		/// Procedura selecteaza cursurile unui angajat
		/// </summary>
		/// <param name="tip">Tipul de curs: intern sau extern</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadIstoricTraining(bool tip)
		{
			Salaries.Data.IstoricTraining istTraining = new Salaries.Data.IstoricTraining(settings.ConnectionString);
			return istTraining.LoadIstoricTraining(angajatId, tip);
		}
		#endregion

		#region InsertIstoricTraining
		/// <summary>
		/// Procedura adauga un curs pentru un angajat
		/// </summary>
		public void InsertIstoricTraining()
		{
			Salaries.Data.IstoricTraining istTraining = new Salaries.Data.IstoricTraining(settings.ConnectionString);
			istTraining.InsertIstoricTraining(angajatId, trainingId, dataStart, dataEnd);
		}
		#endregion

		#region UpdateIstoricTraining
		/// <summary>
		/// Procedura actualizeaza un curs pentru angajat
		/// </summary>
		public void UpdateIstoricTraining()
		{
			Salaries.Data.IstoricTraining istTraining = new Salaries.Data.IstoricTraining(settings.ConnectionString);
			istTraining.UpdateIstoricTraining(istoricTrainingId, angajatId, trainingId, dataStart, dataEnd);
		}
		#endregion

		#region DeleteIstoricTraining
		/// <summary>
		/// Procedura sterge un curs al unui angajat
		/// </summary>
		public void DeleteIstoricTraining()
		{
			Salaries.Data.IstoricTraining istTraining = new Salaries.Data.IstoricTraining(settings.ConnectionString);
			istTraining.DeleteIstoricTraining(istoricTrainingId);
		}
		#endregion
	}
}
