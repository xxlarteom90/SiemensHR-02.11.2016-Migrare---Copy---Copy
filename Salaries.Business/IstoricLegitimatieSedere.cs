using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for IstoricLegitimatieSedere.
	/// </summary>
	public class IstoricLegitimatieSedere
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul legitimatiei de sedere
		private int legitimatieSedereId;
		//Id-ul angajatului
		private long angajatId;
		//Numarul legitimatiei de sedere
		private string nrLegitimatieSedere;
		//Seria legitimatiei de sedere
		private string serieLegitimatieSedere;
		//Data de eliberare a legitimatiei de sedere
		private DateTime legitimatieSedereDataEliberare;
		//Data de expirare a legitimatiei de sedere
		private DateTime legitimatieSedereDataExpirare;
		//Specifica daca legitimatia este activa sau nu
		private bool activ;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public IstoricLegitimatieSedere()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul legitimatiei de sedere.
		/// </summary>
		public int LegitimatieSedereId
		{
			get{ return legitimatieSedereId; }
			set{ legitimatieSedereId = value;}
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
		/// Numarul legitimatiei de sedere.
		/// </summary>
		public string NrLegitimatieSedere
		{
			get{ return nrLegitimatieSedere; }
			set{ nrLegitimatieSedere = value;}
		}
		/// <summary>
		/// Seria legitimatiei de sedere.
		/// </summary>
		public string SerieLegitimatieSedere
		{
			get{ return serieLegitimatieSedere; }
			set{ serieLegitimatieSedere = value;}
		}
		/// <summary>
		/// Data de eliberare legitimatiei de sedere.
		/// </summary>
		public DateTime LegitimatieSedereDataEliberare
		{
			get{ return legitimatieSedereDataEliberare; }
			set{ legitimatieSedereDataEliberare = value;}
		}
		/// <summary>
		/// Data expirare legitimatiei de sedere.
		/// </summary>
		public DateTime LegitimatieSedereDataExpirare
		{
			get{ return legitimatieSedereDataExpirare; }
			set{ legitimatieSedereDataExpirare = value;}
		}
		/// <summary>
		/// Specifica daca legitimatia este activa sau nu.
		/// </summary>
		public bool Activ
		{
			get{ return activ; }
			set{ activ = value;}
		}
		#endregion

		#region LoadIstoricLegitimatiiSedere
		/// <summary>
		/// Procedura selecteaza legitimatiile de sedere ale unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine legitimatiile de sedere</returns>
		public DataSet LoadIstoricLegitimatiiSedere()
		{
			Salaries.Data.IstoricLegitimatieSedere istLegitimatie = new Salaries.Data.IstoricLegitimatieSedere(settings.ConnectionString);
			return istLegitimatie.LoadIstoricLegitimatiiSedere(angajatId);
		}
		#endregion

		#region InsertLegitimatieSedere
		/// <summary>
		/// Procedura adauga o legitimatie de sedere pentru angajat
		/// </summary>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public bool InsertLegitimatieSedere()
		{
			Salaries.Data.IstoricLegitimatieSedere istLegitimatie = new Salaries.Data.IstoricLegitimatieSedere(settings.ConnectionString);
			return istLegitimatie.InsertLegitimatieSedere(angajatId, serieLegitimatieSedere, nrLegitimatieSedere, legitimatieSedereDataEliberare, legitimatieSedereDataExpirare, activ);
		}
		#endregion

		#region UpdateLegitimatieSedere
		/// <summary>
		/// Procedura actualizeaza o legitimatie de sedere
		/// </summary>
		/// <returns>Returneaza true daca s-a facut modificarea si false altfel</returns>
		public bool UpdateLegitimatieSedere()
		{
			Salaries.Data.IstoricLegitimatieSedere istLegitimatie = new Salaries.Data.IstoricLegitimatieSedere(settings.ConnectionString);
			return istLegitimatie.UpdateLegitimatieSedere(legitimatieSedereId, angajatId, serieLegitimatieSedere, nrLegitimatieSedere, legitimatieSedereDataEliberare, legitimatieSedereDataExpirare, activ);
		}
		#endregion

		#region DeleteLegitimatieSedere
		/// <summary>
		/// Procedura sterge o legitimatie de sedere
		/// </summary>
		public void DeleteLegitimatieSedere()
		{
			Salaries.Data.IstoricLegitimatieSedere istLegitimatie = new Salaries.Data.IstoricLegitimatieSedere(settings.ConnectionString);
			istLegitimatie.DeleteLegitimatieSedere(legitimatieSedereId);
		}
		#endregion
	}
}
