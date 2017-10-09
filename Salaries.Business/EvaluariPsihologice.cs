using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for EvaluariPsihologice.
	/// </summary>
	public class EvaluariPsihologice
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul evaluarii
		private int evaluarePsihologicaId;
		//Id-ul angajatului
		private long angajatId;
		//Data evaluarii
		private DateTime data;
		//Tipul raportului
		private int tipRaportId;
		//Raportul evaluarii
		private string raport;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public EvaluariPsihologice()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul evaluarii.
		/// </summary>
		public int EvaluarePsihologicaId
		{
			get{ return evaluarePsihologicaId; }
			set{ evaluarePsihologicaId = value;}
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
		/// Data evaluarii.
		/// </summary>
		public DateTime Data
		{
			get{ return data; }
			set{ data = value;}
		}
		/// <summary>
		/// ID-ul tipului de raport.
		/// </summary>
		public int TipRaportId
		{
			get{ return tipRaportId; }
			set{ tipRaportId = value;}
		}
		/// <summary>
		/// Raportul evaluarii.
		/// </summary>
		public string Raport
		{
			get{ return raport; }
			set{ raport = value;}
		}
		#endregion

		#region LoadEvaluariPsihologiceAngajat
		/// <summary>
		/// Procedura selecteaza toate evaluarile psihologice ale unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine evaluarile</returns>
		public DataSet LoadEvaluariPsihologiceAngajat()
		{
			Salaries.Data.EvalurariPsihologice evaluare = new Salaries.Data.EvalurariPsihologice(settings.ConnectionString);
			return evaluare.LoadEvaluariPsihologiceAngajat(angajatId);
		}
		#endregion

		#region InsertEvaloarePsihologica
		/// <summary>
		/// Procedura adauga o evaluare psihologica
		/// </summary>
		/// <returns>Returneaza id-ul evaluarii adaugate</returns>
		public int InsertEvaloarePsihologica()
		{
			Salaries.Data.EvalurariPsihologice evaluare = new Salaries.Data.EvalurariPsihologice(settings.ConnectionString);
			return evaluare.InsertEvaloarePsihologica(angajatId, tipRaportId, data, raport);
		}
		#endregion

		#region UpdateEvaloarePsihologica
		/// <summary>
		/// Procedura actualizeaza o evaluare psihologica
		/// </summary>
		public void UpdateEvaloarePsihologica()
		{
			Salaries.Data.EvalurariPsihologice evaluare = new Salaries.Data.EvalurariPsihologice(settings.ConnectionString);
			evaluare.UpdateEvaloarePsihologica(evaluarePsihologicaId, angajatId, tipRaportId, data, raport);
		}
		#endregion

		#region DeleteEvaloarePsihologica
		/// <summary>
		/// Procedura sterge o evaluare psihologica
		/// </summary>
		public void DeleteEvaloarePsihologica()
		{
			Salaries.Data.EvalurariPsihologice evaluare = new Salaries.Data.EvalurariPsihologice(settings.ConnectionString);
			evaluare.DeleteEvaloarePsihologica(evaluarePsihologicaId);
		}
		#endregion
	}
}
