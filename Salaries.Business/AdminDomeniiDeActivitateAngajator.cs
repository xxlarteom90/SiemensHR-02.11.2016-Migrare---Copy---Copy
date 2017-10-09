using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminDomeniiDeActivitateAngajator.
	/// </summary>
	public class AdminDomeniiDeActivitateAngajator
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul domeniului de activitate al angajatorului
		private int domeniuAngajatorId; 
		//Id-ul domeniului de activitate
		private int domeniuDeActivitateId; 
		//Id-ul angajatorului
		private int angajatorId; 
		//true daca domeniul e principa, false altfel;un angajator are un sg domeniu principal
		private bool principal; 
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminDomeniiDeActivitateAngajator()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul domeniului de activitate al angajatorului
		/// </summary>
		public int DomeniuAngajatorId
		{
			get { return domeniuAngajatorId; }
			set { domeniuAngajatorId =  value; }
		}
		/// <summary>
		/// Id-ul domeniului de activitate
		/// </summary>
		public int DomeniuDeActivitateId
		{
			get { return domeniuDeActivitateId; }
			set { domeniuDeActivitateId =  value; }
		}
		/// <summary>
		/// Id-ul angajatorului
		/// </summary>
		public int AngajatorId
		{
			get { return angajatorId; }
			set { angajatorId =  value; }
		}
		/// <summary>
		/// true daca domeniul e principa, false altfel;un angajator are un sg domeniu principal
		/// </summary>
		public bool Principal
		{
			get { return principal; }
			set { principal =  value; }
		}
		#endregion

		#region LoadInfoDomeniiDeActivitateAngajator
		/// <summary>
		/// Procedure selecteaza domeniile de activitate ale unui angajator
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoDomeniiDeActivitateAngajator()
		{
			Salaries.Data.AdminDomeniiDeActivitateAngajator domenii = new Salaries.Data.AdminDomeniiDeActivitateAngajator(settings.ConnectionString);
			return domenii.LoadInfoDomeniiDeActivitateAngajator(angajatorId);
		}
		#endregion

		#region GetDomeniuDeActivitateAngajatorInfo
		/// <summary>
		/// Procedura selecteaza un domeniu de activitate al unui angajator
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetDomeniuDeActivitateAngajatorInfo()
		{
			Salaries.Data.AdminDomeniiDeActivitateAngajator domenii = new Salaries.Data.AdminDomeniiDeActivitateAngajator(settings.ConnectionString);
			return domenii.GetDomeniuDeActivitateAngajatorInfo(domeniuAngajatorId);
		}
		#endregion

		#region GetPrincipalDomeniuDeActivitateAngajatorInfo
		/// <summary>
		/// Procedura selecteaza domeniul principal de activitate al unui angajator
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetPrincipalDomeniuDeActivitateAngajatorInfo()
		{
			Salaries.Data.AdminDomeniiDeActivitateAngajator domenii = new Salaries.Data.AdminDomeniiDeActivitateAngajator(settings.ConnectionString);
			return domenii.GetPrincipalDomeniuDeActivitateAngajatorInfo(angajatorId);
		}
		#endregion

		#region InsertDomeniuDeActivitateAngajator
		/// <summary>
		/// Procedura adauga un domeniu de activitate pentru un angajator
		/// </summary>
		public void InsertDomeniuDeActivitateAngajator()
		{
			Salaries.Data.AdminDomeniiDeActivitateAngajator domenii = new Salaries.Data.AdminDomeniiDeActivitateAngajator(settings.ConnectionString);
			domenii.InsertDomeniuDeActivitateAngajator(domeniuAngajatorId, angajatorId, domeniuDeActivitateId, principal);
		}
		#endregion

		#region UpdateDomeniuDeActivitateAngajator
		/// <summary>
		/// Procedura actualizeaza un domeniu de activitate
		/// </summary>
		public void UpdateDomeniuDeActivitateAngajator()
		{
			Salaries.Data.AdminDomeniiDeActivitateAngajator domenii = new Salaries.Data.AdminDomeniiDeActivitateAngajator(settings.ConnectionString);
			domenii.UpdateDomeniuDeActivitateAngajator(domeniuAngajatorId, angajatorId, domeniuDeActivitateId, principal);
		}
		#endregion

		#region DeleteDomeniuDeActivitateAngajator
		/// <summary>
		/// Procedura sterge un domeniu de activitate al unui angajator
		/// </summary>
		public void DeleteDomeniuDeActivitateAngajator()
		{
			Salaries.Data.AdminDomeniiDeActivitateAngajator domenii = new Salaries.Data.AdminDomeniiDeActivitateAngajator(settings.ConnectionString);
			domenii.DeleteDomeniuDeActivitateAngajator(domeniuAngajatorId, angajatorId, domeniuDeActivitateId, principal);
		}
		#endregion

		#region DeleteAllDomeniiDeActivitateAngajator
		/// <summary>
		/// Procedura sterge toate domeniile de activitate ale unui angajator
		/// </summary>
		public void DeleteAllDomeniiDeActivitateAngajator()
		{
			Salaries.Data.AdminDomeniiDeActivitateAngajator domenii = new Salaries.Data.AdminDomeniiDeActivitateAngajator(settings.ConnectionString);
			domenii.DeleteAllDomeniiDeActivitateAngajator(angajatorId);
		}
		#endregion
	}
}
