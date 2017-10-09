using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for IstoricNIF.
	/// </summary>
	public class IstoricNIF
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul NIF-ului
		private int nifId;
		//Id-ul angajatului
		private long angajatId;
		//Valoarea pentru NIF
		private string nif;
		//Specifica daca NIF-ul este activ sau nu
		private bool activ;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public IstoricNIF()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul NIF-ului.
		/// </summary>
		public int NifId
		{
			get{ return nifId; }
			set{ nifId = value;}
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
		/// Valoarea NIF-ului.
		/// </summary>
		public string NIF
		{
			get{ return nif; }
			set{ nif = value;}
		}
		/// <summary>
		/// Specifica daca NIF-ul este activ sau nu
		/// </summary>
		public bool Activ
		{
			get{ return activ; }
			set{ activ = value;}
		}
		#endregion

		#region LoadIstoricNIFuri
		/// <summary>
		/// Procedura selecteaza toate NIF-urile unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine toate NIF-urile unui angajat</returns>
		public DataSet LoadIstoricNIFuri()
		{
			Salaries.Data.IstoricNIF istNIF = new Salaries.Data.IstoricNIF(settings.ConnectionString);
			return istNIF.LoadIstoricNIFuri(angajatId);
		}
		#endregion

		#region InsertNIF
		/// <summary>
		/// Procedura adauga un NIF
		/// </summary>
		/// <returns>Returneaza true daca a fost facuta adauagarea corecta si false altfel</returns>
		public bool InsertNIF()
		{
			Salaries.Data.IstoricNIF istNIF = new Salaries.Data.IstoricNIF(settings.ConnectionString);
			return istNIF.InsertNIF(angajatId, nif, activ);
		}
		#endregion

		#region UpdateNIF
		/// <summary>
		/// Procedura actualizeaza un NIF
		/// </summary>
		/// <returns>Returneaza true daca a fost facuta adauagarea corecta si false altfel</returns>
		public bool UpdateNIF()
		{
			Salaries.Data.IstoricNIF istNIF = new Salaries.Data.IstoricNIF(settings.ConnectionString);
			return istNIF.UpdateNIF(nifId, angajatId, nif, activ);
		}
		#endregion

		#region DeleteNIF
		/// <summary>
		/// Procedura sterge un NIF
		/// </summary>
		/// <param name="nifId">Id-ul NIF-ului care se sterge</param>
		public void DeleteNIF()
		{
			Salaries.Data.IstoricNIF istNIF = new Salaries.Data.IstoricNIF(settings.ConnectionString);
			istNIF.DeleteNIF(nifId);
		}
		#endregion
	}
}
