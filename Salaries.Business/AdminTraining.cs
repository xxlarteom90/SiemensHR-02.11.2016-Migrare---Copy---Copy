using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminTraining.
	/// </summary>
	public class AdminTraining
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul cursului
		private int trainingId;
		//Denumirea cursului
		private string nume;
		//Descrierea cursului
		private string descriere;
		//Tipul de diploma acordata
		private string diploma;
		//Specifica daca este curs intern sau nu
		private bool intern;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminTraining()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul cursului.
		/// </summary>
		public int TrainingId
		{
			get	{ return trainingId; }
			set { trainingId = value; }
		}
		/// <summary>
		/// Denumirea cursului.
		/// </summary>
		public string Nume
		{
			get	{ return nume; }
			set { nume = value; }
		}
		/// <summary>
		/// Descrierea cursului.
		/// </summary>
		public string Descriere
		{
			get	{ return descriere; }
			set { descriere = value; }
		}
		/// <summary>
		/// Tipul de diploma acordata.
		/// </summary>
		public string Diploma
		{
			get	{ return diploma; }
			set { diploma = value; }
		}
		/// <summary>
		/// Specifica daca este curs intern sau nu
		/// </summary>
		public bool Intern
		{
			get	{ return intern; }
			set { intern = value; }
		}
		#endregion

		#region LoadInfoTraininguri
		/// <summary>
		/// Procedura selecteaza cursurile de un anumit tip: intern sau extern
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoTraininguri()
		{
			Salaries.Data.AdminTraining training = new Salaries.Data.AdminTraining(settings.ConnectionString);
			return training.LoadInfoTraininguri(intern);
		}
		#endregion

		#region InsertTraining
		/// <summary>
		/// Procedura adauga un curs
		/// </summary>
		public void InsertTraining()
		{
			Salaries.Data.AdminTraining training = new Salaries.Data.AdminTraining(settings.ConnectionString);
			training.InsertTraining(nume, descriere, diploma, intern);
		}
		#endregion

		#region UpdateTraining
		/// <summary>
		/// Procedura adauga un curs
		/// </summary>
		public void UpdateTraining()
		{
			Salaries.Data.AdminTraining training = new Salaries.Data.AdminTraining(settings.ConnectionString);
			training.UpdateTraining(trainingId, nume, descriere, diploma, intern);
		}
		#endregion

		#region DeleteTraining
		/// <summary>
		/// Procedura sterg un curs
		/// </summary>
		public void DeleteTraining()
		{
			Salaries.Data.AdminTraining training = new Salaries.Data.AdminTraining(settings.ConnectionString);
			training.DeleteTraining(trainingId);
		}
		#endregion

		#region GetTrainingInfo
		/// <summary>
		/// Procedura selecteaza un curs
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele despre curs</returns>
		public DataSet GetTrainingInfo()
		{
			Salaries.Data.AdminTraining training = new Salaries.Data.AdminTraining(settings.ConnectionString);
			return training.GetTrainingInfo(trainingId);
		}
		#endregion

		#region CheckIfTrainingCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un curs poate fi sters
		/// </summary>
		/// <returns>Returneaza rezultatul verificarii
		/// 0 - se poate sterge
		/// 1 - exista date asociate cursului
		/// 2 - este ultimul curs din lista
		/// </returns>
		public int CheckIfTrainingCanBeDeleted()
		{
			Salaries.Data.AdminTraining training = new Salaries.Data.AdminTraining(settings.ConnectionString);
			return training.CheckIfTrainingCanBeDeleted(trainingId);
		}
		#endregion

		#region CheckIfTrainingCanBeAdded
		/// <summary>
		/// Procedura verifica daca mai exista un training cu aceleasi date
		/// </summary>
		/// <returns>Returneaza true daca se poate face adugarea sau modificare si false altfel</returns>
		public bool CheckIfTrainingCanBeAdded()
		{
			Salaries.Data.AdminTraining training = new Salaries.Data.AdminTraining(settings.ConnectionString);
			return training.CheckIfTrainingCanBeAdded(trainingId, nume, diploma, intern);
		}
		#endregion
	}
}
