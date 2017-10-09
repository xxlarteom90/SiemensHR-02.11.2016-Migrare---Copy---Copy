using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminDomeniiDeActivitate.
	/// </summary>
	public class AdminDomeniiDeActivitate
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul domeniului de activitate
		private int domeniuDeActivitateId;
		//Codul CAEN al domeniului de activitate
		private int codCAEN;
		//Denumirea domeniului
		private string denumire;
		//Descrierea domeniului de activitate
		private string descriere;
		//Procentul aferent domeniului de activitate
		private float procent;
		//Norma domeniului de activitate
		private int norma;
		//retinere contributie pentru accidentele de munca
		private bool retinereAccidente;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminDomeniiDeActivitate()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul domeniului de activitate
		/// </summary>
		public int DomeniuDeActivitateId
		{
			get { return domeniuDeActivitateId; }
			set { domeniuDeActivitateId =  value; }
		}
		/// <summary>
		/// Codul CAEN al domeniului de activitate
		/// </summary>
		public int CodCAEN
		{
			get { return codCAEN; }
			set { codCAEN =  value; }
		}
		/// <summary>
		/// Denumirea domeniului
		/// </summary>
		public string Denumire
		{
			get { return denumire; }
			set { denumire =  value; }
		}
		/// <summary>
		/// Descrierea domeniului de activitate
		/// </summary>
		public string Descriere
		{
			get { return descriere; }
			set { descriere =  value; }
		}
		/// <summary>
		/// Procentul aferent domeniului de activitate
		/// </summary>
		public float Procent
		{
			get { return procent; }
			set { procent =  value; }
		}
		/// <summary>
		/// Norma domeniului de activitate
		/// </summary>
		public int Norma
		{
			get { return norma; }
			set { norma =  value; }
		}
		/// <summary>
		/// Retinere pt contributia la accidente de munca
		/// </summary>
		public bool RetinereAccidente
		{
			get { return retinereAccidente; }
			set { retinereAccidente =  value; }
		}
		#endregion

		#region LoadInfoDomeniiDeActivitate
		/// <summary>
		/// Procedura selecteaza toate domeniile de activitate
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste domenii</returns>
		public DataSet LoadInfoDomeniiDeActivitate()
		{
			Salaries.Data.AdminDomeniiDeActivitate domenii = new Salaries.Data.AdminDomeniiDeActivitate(settings.ConnectionString);
			return domenii.LoadInfoDomeniiDeActivitate();
		}
		#endregion

		#region GetDomeniuDeActivitateInfo
		/// <summary>
		/// Procedura selecteaza un domeniu de activitate
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetDomeniuDeActivitateInfo()
		{
			Salaries.Data.AdminDomeniiDeActivitate domenii = new Salaries.Data.AdminDomeniiDeActivitate(settings.ConnectionString);
			return domenii.GetDomeniuDeActivitateInfo(domeniuDeActivitateId);
		}
		#endregion

		#region InsertDomeniuDeActivitate
		/// <summary>
		/// Procedura adauga un domeniu de activitate
		/// </summary>
		public void InsertDomeniuDeActivitate()
		{
			Salaries.Data.AdminDomeniiDeActivitate domenii = new Salaries.Data.AdminDomeniiDeActivitate(settings.ConnectionString);
			domenii.InsertDomeniuDeActivitate(domeniuDeActivitateId, codCAEN, denumire, descriere, procent, norma, retinereAccidente);
		}
		#endregion

		#region UpdateDomeniuDeActivitate
		/// <summary>
		/// Procedura actualizeaza un domeniu de activitate
		/// </summary>
		public void UpdateDomeniuDeActivitate()
		{
			Salaries.Data.AdminDomeniiDeActivitate domenii = new Salaries.Data.AdminDomeniiDeActivitate(settings.ConnectionString);
			domenii.UpdateDomeniuDeActivitate(domeniuDeActivitateId, codCAEN, denumire, descriere, procent, norma, retinereAccidente);
		}
		#endregion

		#region DeleteDomeniuDeActivitate
		/// <summary>
		/// Procedura sterge un domeniu de activitate
		/// </summary>
		public void DeleteDomeniuDeActivitate()
		{
			Salaries.Data.AdminDomeniiDeActivitate domenii = new Salaries.Data.AdminDomeniiDeActivitate(settings.ConnectionString);
			domenii.DeleteDomeniuDeActivitate(domeniuDeActivitateId);
		}
		#endregion

		#region GetDomeniiDeActDisponibilePtAngajator
		/// <summary>
		/// Procedura selecteaza domeniile de activitate ale unui angajator
		/// </summary>
		/// <param name="angajatorId">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetDomeniiDeActDisponibilePtAngajator(int angajatorId)
		{
			Salaries.Data.AdminDomeniiDeActivitate domenii = new Salaries.Data.AdminDomeniiDeActivitate(settings.ConnectionString);
			return domenii.GetDomeniiDeActDisponibilePtAngajator(angajatorId);
		}
		#endregion

		#region CheckIfDomeniuDeActivitateCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un domeniu de activitate poate fi sters
		/// </summary>
		/// <param name="domDeActivitateId">Id-ul domeniului de activitate pentru care se face verificarea</param>
		/// <returns>Returneaza rezultatul verificarii daca s-a putut efectua stergerea
		/// 0 - se poate sterge
		/// 1 - exista date asociate domeniului
		/// 2 - este ultimul domeniu din lista
		/// </returns>
		/// <remarks>
		/// Modificat:	Oprescu Claudia
		/// Data:		27.02.2007
		/// </remarks>
		public int CheckIfDomeniuDeActivitateCanBeDeleted()
		{
			Salaries.Data.AdminDomeniiDeActivitate domenii = new Salaries.Data.AdminDomeniiDeActivitate(settings.ConnectionString);
			return domenii.CheckIfDomeniuDeActivitateCanBeDeleted(domeniuDeActivitateId);
		}
		#endregion

		#region CheckIfDomeniuDeActivitateCanBeAdded
		/// <summary>
		/// Procedura este folosita pentru a verifica daca se poate face adaugare/modificare fara a se crea duplicate
		/// </summary>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfDomeniuDeActivitateCanBeAdded()
		{
			Salaries.Data.AdminDomeniiDeActivitate domenii = new Salaries.Data.AdminDomeniiDeActivitate(settings.ConnectionString);
			return domenii.CheckIfDomeniuDeActivitateCanBeAdded(domeniuDeActivitateId, codCAEN, denumire, procent, norma);
		}
		#endregion
	}
}
