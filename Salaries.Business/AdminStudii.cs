using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminStudii.
	/// </summary>
	public class AdminStudii
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul categoriei de studii
		private int studiuId;
		//Denumirea categoriei de studii
		private string nume;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminStudii()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul categoriei de studii
		/// </summary>
		public int StudiuId
		{
			get	{ return studiuId; }
			set { studiuId = value; }
		}
		/// <summary>
		/// Denumirea categoriei de studii
		/// </summary>
		public string Nume
		{
			get	{ return nume; }
			set { nume = value; }
		}
		#endregion

		#region LoadInfoStudii
		/// <summary>
		/// Procedura selecteaza toate categoriile de studii
		/// </summary>
		/// <returns></returns>
		public DataSet LoadInfoStudii()
		{
			Salaries.Data.AdminStudii studii = new Salaries.Data.AdminStudii(settings.ConnectionString);
			return studii.LoadInfoStudii();
		}
		#endregion

		#region LoadInfoStudiiUnion
		/// <summary>
		/// Sunt selectate toate studiile. La aceste inregistrari se adauga o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoStudiiUnion()
		{
			Salaries.Data.AdminStudii studii = new Salaries.Data.AdminStudii(settings.ConnectionString);
			return studii.LoadInfoStudiiUnion();
		}
		#endregion

		#region InsertStudiu
		/// <summary>
		/// Procedura adauga o categorie de studii
		/// </summary>
		public void InsertStudiu()
		{
			Salaries.Data.AdminStudii studii = new Salaries.Data.AdminStudii(settings.ConnectionString);
			studii.InsertStudiu(studiuId, nume);
		}
		#endregion

		#region UpdateStudiu
		/// <summary>
		/// Procedura actualizeaza o categorie de studii
		/// </summary>
		public void UpdateStudiu()
		{
			Salaries.Data.AdminStudii studii = new Salaries.Data.AdminStudii(settings.ConnectionString);
			studii.UpdateStudiu(studiuId, nume);
		}
		#endregion

		#region DeleteStudiu
		/// <summary>
		/// Procedura sterge o categorie de studii
		/// </summary>
		public void DeleteStudiu()
		{
			Salaries.Data.AdminStudii studii = new Salaries.Data.AdminStudii(settings.ConnectionString);
			studii.DeleteStudiu(studiuId);
		}
		#endregion

		#region GetStudiuInfo
		/// <summary>
		/// Procedura selecteaza o categorie de studii
		/// </summary>
		/// <returns>Returneaza un DataSet care contine categoria de studii selectata</returns>
		public DataSet GetStudiuInfo()
		{
			Salaries.Data.AdminStudii studii = new Salaries.Data.AdminStudii(settings.ConnectionString);
			return studii.GetStudiuInfo(studiuId);
		}
		#endregion

		#region CheckIfStudiuCanBeDeleted
		/// <summary>
		/// Procedura verifica daca o categorie de studii poate fi stearsa
		/// </summary>
		/// <returns>Returneaza rezultatul verificarii
		/// 0 - se poate sterge categoria
		/// 1 - categoria este asociata unor angajati
		/// 2 - categoria este ultima din lista
		/// </returns>
		public int CheckIfStudiuCanBeDeleted()
		{
			Salaries.Data.AdminStudii studii = new Salaries.Data.AdminStudii(settings.ConnectionString);
			return studii.CheckIfStudiuCanBeDeleted(studiuId);
		}
		#endregion

		#region CheckIfStudiuCanBeAdded
		/// <summary>
		/// Procedura verifica sa nu se adauge duplicate in tabela Studii
		/// </summary>
		/// <returns>Returneaza true daca se poate face adaugarea si false altfel</returns>
		public bool CheckIfStudiuCanBeAdded()
		{
			Salaries.Data.AdminStudii studii = new Salaries.Data.AdminStudii(settings.ConnectionString);
			return studii.CheckIfStudiuCanBeAdded(studiuId, nume);
		}
		#endregion
	}
}
