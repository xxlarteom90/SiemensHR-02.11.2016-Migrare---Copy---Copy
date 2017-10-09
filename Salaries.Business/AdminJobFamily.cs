/*
 * Autor:		Oprescu Claudia
 * Data:		10.07.2007
 * Descriere:	Clasa se ocupa cu Familiile de functii.
 */

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminJobFamily.
	/// </summary>
	public class AdminJobFamily
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul familiei de functii
		private int jobFamilyId;
		//Codul familiei de functii
		private string cod;
		//Denumirea familiei de functii
		private string denumire;
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul familiei de functii.
		/// </summary>
		public int JobFamilyId
		{
			get{ return jobFamilyId; }
			set{ jobFamilyId = value;}
		}
		/// <summary>
		/// Codul familiei de functii.
		/// </summary>
		public string Cod
		{
			get{ return cod; }
			set{ cod = value;}
		}
		/// <summary>
		/// Denumirea familiei de functii.
		/// </summary>
		public string Denumire
		{
			get{ return denumire; }
			set{ denumire = value;}
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminJobFamily()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region LoadJobFamily
		/// <summary>
		/// Procedura selecteaza Familiile de functii
		/// </summary>
		/// <returns>Returneaza un DataSet care contine Familiile de functii</returns>
		public DataSet LoadJobFamily()
		{
			Salaries.Data.AdminJobFamily job = new Salaries.Data.AdminJobFamily(settings.ConnectionString);
			return job.LoadJobFamily();
		}
		#endregion
	}
}
