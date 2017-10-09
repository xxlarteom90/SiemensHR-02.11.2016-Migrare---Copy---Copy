using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminTipuriCompletareCarnete.
	/// </summary>
	public class AdminTipuriCompletareCarnete
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul tipului de completare de carnet de munca
		private int tipCompletareCarnetId;
		//Id-ul angajatorului
		private int angajatorId;
		//Descrierea tipului de completare
		private string descriere;
		//Codul tipului de completare
		private string cod;
		//Procentrul tipului de completare
		private float procent;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminTipuriCompletareCarnete()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul tipului de completare de carnet de munca
		/// </summary>
		public int TipCompletareCarnetId
		{
			get	{ return tipCompletareCarnetId; }
			set { tipCompletareCarnetId = value; }
		}
		/// <summary>
		/// Id-ul angajatorului
		/// </summary>
		public int AngajatorId
		{
			get	{ return angajatorId; }
			set { angajatorId = value; }
		}
		/// <summary>
		/// Descrierea tipului de completare
		/// </summary>
		public string Descriere
		{
			get	{ return descriere; }
			set { descriere = value; }
		}
		/// <summary>
		/// Codul tipului de completare
		/// </summary>
		public string Cod
		{
			get	{ return cod; }
			set { cod = value; }
		}
		/// <summary>
		/// Procentrul tipului de completare
		/// </summary>
		public float Procent
		{
			get	{ return procent; }
			set { procent = value; }
		}
		#endregion

		#region LoadInfoTipuriCompletare
		/// <summary>
		/// Procedura selecteaza tipurile de completare ale carnetelor de munca ale unui angajator
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadInfoTipuriCompletare()
		{
			Salaries.Data.AdminTipuriCompletareCarnete tipCompletare = new Salaries.Data.AdminTipuriCompletareCarnete(settings.ConnectionString);
			return tipCompletare.LoadInfoTipuriCompletare(angajatorId);
		}
		#endregion

		#region InsertTipCompletare
		/// <summary>
		/// Procedura adauga un tip de completare de carnet de munca
		/// </summary>
		public void InsertTipCompletare()
		{
			Salaries.Data.AdminTipuriCompletareCarnete tipCompletare = new Salaries.Data.AdminTipuriCompletareCarnete(settings.ConnectionString);
			tipCompletare.InsertTipCompletare(tipCompletareCarnetId, angajatorId, descriere, cod, procent);
		}
		#endregion

		#region UpdateTipCompletare
		/// <summary>
		/// Procedura actualizeaza un tip de completare de carnet de munca
		/// </summary>
		public void UpdateTipCompletare()
		{
			Salaries.Data.AdminTipuriCompletareCarnete tipCompletare = new Salaries.Data.AdminTipuriCompletareCarnete(settings.ConnectionString);
			tipCompletare.UpdateTipCompletare(tipCompletareCarnetId, angajatorId, descriere, cod, procent);
		}
		#endregion

		#region DeleteTipCompletare
		/// <summary>
		/// Procedura sterfe un tip de completare de carnet de munca
		/// </summary>
		public void DeleteTipCompletare()
		{
			Salaries.Data.AdminTipuriCompletareCarnete tipCompletare = new Salaries.Data.AdminTipuriCompletareCarnete(settings.ConnectionString);
			tipCompletare.DeleteTipCompletare(tipCompletareCarnetId, angajatorId);
		}
		#endregion

		#region GetTipCompletareInfo
		/// <summary>
		/// Procedura selecteaza un tip de completare de carnet a unui angajator
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetTipCompletareInfo()
		{
			Salaries.Data.AdminTipuriCompletareCarnete tipCompletare = new Salaries.Data.AdminTipuriCompletareCarnete(settings.ConnectionString);
			return tipCompletare.GetTipCompletareInfo(tipCompletareCarnetId, angajatorId);
		}
		#endregion

		#region GetTipuriCompletareCarnete
		/// <summary>
		/// Returneaza tipurile de completare are carnetelor de munca.
		/// </summary>
		/// <returns> Tipurile de completare ale carnetelor de munca sunt stocate intr-un DataSet.</returns>
		public DataSet GetTipuriCompletareCarnete()
		{
			Salaries.Data.AdminTipuriCompletareCarnete tipCompletare = new Salaries.Data.AdminTipuriCompletareCarnete(settings.ConnectionString);
			return tipCompletare.GetTipuriCompletareCarnete(angajatorId);
		}
		#endregion

		#region CheckIfTipCompletareCarnetCanBeDeleted
		/// <summary>
		/// Procedura verifica daca un tip de completare poate fi sters sau nu
		/// </summary>
		/// <returns>Returneaza 0 daca se poate face stergerea, 
		///						1 daca exista date asociate tipului,
		///						2 daca tipul este ultimul din lista
		///	</returns>
		///	<remarks>
		///	Autor:	Oprescu Claudia
		///	Data:	23.03.2007
		///	</remarks>
		public int CheckIfTipCompletareCarnetCanBeDeleted()
		{
			Salaries.Data.AdminTipuriCompletareCarnete tipCompletare = new Salaries.Data.AdminTipuriCompletareCarnete(settings.ConnectionString);
			return tipCompletare.CheckIfTipCompletareCarnetCanBeDeleted(tipCompletareCarnetId);
		}
		#endregion

		#region CheckIfCarneteTipuriCanBeAdded
		/// <summary>
		/// Procedura verifica sa nu se aduage duplicate in tabela sal_CompletareCarneteTipuri
		/// </summary>
		/// <returns>Retunreaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfCarneteTipuriCanBeAdded()
		{
			Salaries.Data.AdminTipuriCompletareCarnete tipCompletare = new Salaries.Data.AdminTipuriCompletareCarnete(settings.ConnectionString);
			return tipCompletare.CheckIfCarneteTipuriCanBeAdded(tipCompletareCarnetId, descriere, cod, angajatorId);
		}
		#endregion
	}
}
