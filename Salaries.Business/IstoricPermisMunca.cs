using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for IstoricPermisMunca.
	/// </summary>
	public class IstoricPermisMunca
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul permisului de munca
		private int permisMuncaId;
		//Id-ul angajatului
		private long angajatId;
		//Seria permisului de munca
		private string serie;
		//Numarul permisului de munca
		private long numar;
		//Data de eliberare
		private DateTime dataEliberare;
		//Data de expirare
		private DateTime dataExpirare;
		//Specifica daca permisul de munca este acitiv sau nu
		private bool activ;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public IstoricPermisMunca()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul permisului de munca.
		/// </summary>
		public int PermisMuncaId
		{
			get{ return permisMuncaId; }
			set{ permisMuncaId = value;}
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
		/// Seria permisului de munca.
		/// </summary>
		public string Serie
		{
			get{ return serie; }
			set{ serie = value;}
		}
		/// <summary>
		/// Numarul permisului de munca.
		/// </summary>
		public long Numar
		{
			get{ return numar; }
			set{ numar = value;}
		}
		/// <summary>
		/// Data eliberarii.
		/// </summary>
		public DateTime DataEliberare
		{
			get{ return dataEliberare; }
			set{ dataEliberare = value;}
		}
		/// <summary>
		/// Data pana la care e valabil.
		/// </summary>
		public DateTime DataExpirare
		{
			get{ return dataExpirare; }
			set{ dataExpirare = value;}
		}
		/// <summary>
		/// Specifica daca permisul de munca este acitiv sau nu.
		/// </summary>
		public bool Activ
		{
			get{ return activ; }
			set{ activ = value;}
		}
		#endregion

		#region LoadIstoricPermiseMunca
		/// <summary>
		/// Procedura selecteaza permisele de munca ale unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadIstoricPermiseMunca()
		{
			Salaries.Data.IstoricPermisMunca istPermis = new Salaries.Data.IstoricPermisMunca(settings.ConnectionString);
			return istPermis.LoadIstoricPermiseMunca(angajatId);
		}
		#endregion

		#region InsertPermisMunca
		/// <summary>
		/// Procedura adauga un permis de munca
		/// </summary>
		public void InsertPermisMunca()
		{
			Salaries.Data.IstoricPermisMunca istPermis = new Salaries.Data.IstoricPermisMunca(settings.ConnectionString);
			istPermis.InsertPermisMunca(angajatId, serie, numar, dataEliberare, dataExpirare, activ);
		}
		#endregion

		#region UpdatePermisMunca
		/// <summary>
		/// Procedura actualizeaza un permis de munca
		/// </summary>
		public void UpdatePermisMunca()
		{
			Salaries.Data.IstoricPermisMunca istPermis = new Salaries.Data.IstoricPermisMunca(settings.ConnectionString);
			istPermis.UpdatePermisMunca(permisMuncaId, angajatId, serie, numar, dataEliberare, dataExpirare, activ);
		}
		#endregion

		#region DeletePermisMunca
		/// <summary>
		/// Procedura sterge un permis de munca
		/// </summary>
		public void DeletePermisMunca()
		{
			Salaries.Data.IstoricPermisMunca istPermis = new Salaries.Data.IstoricPermisMunca(settings.ConnectionString);
			istPermis.DeletePermisMunca(permisMuncaId);
		}
		#endregion

		#region CheckIfPermisMuncaCanBeAdded
		/// <summary>
		/// Procedura verifica daca un permise de munca poate fi adaugat astfel incat sa nu se creeze duplicate
		/// </summary>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfPermisMuncaCanBeAdded()
		{
			Salaries.Data.IstoricPermisMunca istPermis = new Salaries.Data.IstoricPermisMunca(settings.ConnectionString);
			return istPermis.CheckIfPermisMuncaCanBeAdded(permisMuncaId, serie, numar);
		}
		#endregion
	}
}
