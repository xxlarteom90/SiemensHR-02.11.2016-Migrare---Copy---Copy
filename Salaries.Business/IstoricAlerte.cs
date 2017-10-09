using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for IstoricAlerte.
	/// </summary>
	public class IstoricAlerte
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul alertei
		private int alertaId;
		//Id-ul angajatului
		private long angajatId;
		//Data de expirare
		private DateTime dataExpirare;
		//Perioada critica a alertei
		private int perioadaCritica;
		//Descrierea alertei
		private string descriere;
		//Specifica daca alerta este activa sau nu
		private bool activ;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public IstoricAlerte()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul alertei.
		/// </summary>
		public int AlertaId
		{
			get{ return alertaId; }
			set{ alertaId = value;}
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
		/// Data de expirare a alertei.
		/// </summary>
		public DateTime DataExpirare
		{
			get{ return dataExpirare; }
			set{ dataExpirare = value;}
		}
		/// <summary>
		/// Perioada critica a alertei.
		/// </summary>
		public int PerioadaCritica
		{
			get{ return perioadaCritica; }
			set{ perioadaCritica = value;}
		}
		/// <summary>
		/// Descrierea alertei.
		/// </summary>
		public string Descriere
		{
			get{ return descriere; }
			set{ descriere = value;}
		}
		/// <summary>
		/// Specifica daca alerta este activa sau nu.
		/// </summary>
		public bool Activ
		{
			get{ return activ; }
			set{ activ = value;}
		}
		#endregion

		#region GetAlertaInfo
		/// <summary>
		/// Procedura selecteaza o alerta
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele despre alerta</returns>
		public DataSet GetAlertaInfo()
		{
			Salaries.Data.IstoricAlerte alerta = new Salaries.Data.IstoricAlerte(settings.ConnectionString);
			return alerta.GetAlertaInfo(alertaId);
		}
		#endregion

		#region LoadInfoAlerta
		/// <summary>
		/// Procedura selecteaza alertele unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine date despre alertele angajatului</returns>
		public DataSet LoadInfoAlerta()
		{
			Salaries.Data.IstoricAlerte alerta = new Salaries.Data.IstoricAlerte(settings.ConnectionString);
			return alerta.LoadInfoAlerta(angajatId);
		}
		#endregion

		#region InsertAlerta
		/// <summary>
		/// Procedura adauga o alerta
		/// </summary>
		public void InsertAlerta()
		{
			Salaries.Data.IstoricAlerte alerta = new Salaries.Data.IstoricAlerte(settings.ConnectionString);
		    alerta.InsertAlerta(angajatId, dataExpirare, perioadaCritica, descriere, activ);
		}
		#endregion

		#region UpdateAlerta
		/// <summary>
		/// Procedura actualizeaza o alerta
		/// </summary>
		public void UpdateAlerta()
		{
			Salaries.Data.IstoricAlerte alerta = new Salaries.Data.IstoricAlerte(settings.ConnectionString);
			alerta.UpdateAlerta(alertaId, angajatId, dataExpirare, perioadaCritica, descriere, activ);
		}
		#endregion

		#region DeleteAlerta
		/// <summary>
		/// Procedura sterge o alerta
		/// </summary>
		public void DeleteAlerta()
		{
			Salaries.Data.IstoricAlerte alerta = new Salaries.Data.IstoricAlerte(settings.ConnectionString);
			alerta.DeleteAlerta(alertaId);
		}
		#endregion
	}
}
