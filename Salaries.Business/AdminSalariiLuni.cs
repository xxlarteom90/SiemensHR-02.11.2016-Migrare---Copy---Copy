using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminSalariiLuni.
	/// </summary>
	public class AdminSalariiLuni
	{
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminSalariiLuni()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region LoadInfoLuniSalarii
		/// <summary>
		/// Procedura selecteaza lunile de salarii existente in baza de date
		/// </summary>
		/// <returns>Procedura returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadInfoLuniSalarii()
		{
			Salaries.Data.AdminSalariiLuni salarii = new Salaries.Data.AdminSalariiLuni(settings.ConnectionString);
			return salarii.LoadInfoLuniSalarii();
		}
		#endregion

		#region LoadInfoLuniSalariiUnion
		/// <summary>
		/// Sunt selectate toate lunile. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoLuniSalariiUnion()
		{
			Salaries.Data.AdminSalariiLuni salarii = new Salaries.Data.AdminSalariiLuni(settings.ConnectionString);
			return salarii.LoadInfoLuniSalariiUnion();
		}
		#endregion
	}
}
