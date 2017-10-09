using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminCentreCost.
	/// </summary>
	public class AdminCentreCost
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul centrului de cost
		private int centruCostId;
		//Codul centrului de cost
		private string cod;
		//Denumirea centrului de cost
		private string nume;
		//Descrierea centrului de cost
		private string descriere;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminCentreCost()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul centrului de cost.
		/// </summary>
		public int CentruCostId
		{
			get	{ return centruCostId; }
			set { centruCostId = value; }
		}
		/// <summary>
		/// Codul centrului de cost.
		/// </summary>
		public string Cod
		{
			get	{ return cod; }
			set { cod = value; }
		}
		/// <summary>
		/// Denumirea centrului de cost.
		/// </summary>
		public string Nume
		{
			get	{ return nume; }
			set { nume = value; }
		}
		/// <summary>
		/// Descrierea centrului de cost.
		/// </summary>
		public string Descriere
		{
			get	{ return descriere; }
			set { descriere = value; }
		}
		#endregion

		#region LoadInfoCentreCost
		/// <summary>
		/// Procedura selecteaza toate contrele de cost
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste centre de cost</returns>
		public DataSet LoadInfoCentreCost()
		{
			Salaries.Data.AdminCentreCost centruCost = new Salaries.Data.AdminCentreCost(settings.ConnectionString);
			return centruCost.LoadInfoCentreCost();
		}
		#endregion

		#region InsertCentruCost
		/// <summary>
		/// Procedura adauga un centru de cost
		/// </summary>
		public void InsertCentruCost()
		{
			Salaries.Data.AdminCentreCost centruCost = new Salaries.Data.AdminCentreCost(settings.ConnectionString);
			centruCost.InsertCentruCost(centruCostId, cod, nume, descriere);
		}
		#endregion

		#region UpdateCentruCost
		/// <summary>
		/// Procedura actualizeaza un centru de cost
		/// </summary>s
		public void UpdateCentruCost()
		{
			Salaries.Data.AdminCentreCost centruCost = new Salaries.Data.AdminCentreCost(settings.ConnectionString);
			centruCost.UpdateCentruCost(centruCostId, cod, nume, descriere);
		}
		#endregion

		#region DeleteCentruCost
		/// <summary>
		/// Procedura sterge un centru de cost
		/// </summary>
		public void DeleteCentruCost()
		{
			Salaries.Data.AdminCentreCost centruCost = new Salaries.Data.AdminCentreCost(settings.ConnectionString);
			centruCost.DeleteCentruCost(centruCostId);
		}
		#endregion

		#region GetCentruCostInfo
		/// <summary>
		/// Procedura selecteaza un centru de cost
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele despre un centru de cost</returns>
		public DataSet GetCentruCostInfo()
		{
			Salaries.Data.AdminCentreCost centruCost = new Salaries.Data.AdminCentreCost(settings.ConnectionString);
			return centruCost.GetCentruCostInfo(centruCostId);
		}
		#endregion

		#region CheckIfCentruCostCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un centru de cost se poate sterge
		/// </summary>
		/// <returns>Returneaza rezultatul verificarii</returns>
		public int CheckIfCentruCostCanBeDeleted()
		{
			Salaries.Data.AdminCentreCost centruCost = new Salaries.Data.AdminCentreCost(settings.ConnectionString);
			return centruCost.CheckIfCentruCostCanBeDeleted(centruCostId);
		}
		#endregion

		#region CheckIfCentruCostCanBeAdded
		/// <summary>
		/// Procedura verifica sa nu se creeze duplicate la daugare sau modificare in tabela CentreCost
		/// </summary>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfCentruCostCanBeAdded()
		{
			Salaries.Data.AdminCentreCost centruCost = new Salaries.Data.AdminCentreCost(settings.ConnectionString);
			return centruCost.CheckIfCentruCostCanBeAdded(centruCostId, cod);
		}
		#endregion

		#region GetCentruCostPentruDepartament
		/// <summary>
		/// Procedura determina centrul de cost al unui departament
		/// </summary>
		/// <param name="departamentId">Id-ul departamentului pentru care se determina centrul de cost</param>
		/// <returns>Returneaza id-ul centrului de cost corespunzator departamentului</returns>
		public int GetCentruCostPentruDepartament(int departamentId)
		{
			Salaries.Data.AdminCentreCost centruCost = new Salaries.Data.AdminCentreCost(settings.ConnectionString);
			return centruCost.GetCentruCostPentruDepartament(departamentId);
		}
		#endregion
	}
}
