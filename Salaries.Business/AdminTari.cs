using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminTari.
	/// </summary>
	public class AdminTari
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul tarii
		private int taraId;
		//Denumirea tarii
		private string numeTara;
		//Simbolul tarii
		private string simbol;
		//Nationalitatea tarii
		private string nationalitate;
		//Specifica daca tara este tara de baza sau nu
		private bool taraDeBaza;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminTari()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul tarii.
		/// </summary>
		public int TaraId
		{
			get	{ return taraId; }
			set { taraId = value; }
		}
		/// <summary>
		/// Denumirea tarii.
		/// </summary>
		public string NumeTara
		{
			get	{ return numeTara; }
			set { numeTara = value; }
		}
		/// <summary>
		/// Simbolul tarii.
		/// </summary>
		public string Simbol
		{
			get	{ return simbol; }
			set { simbol = value; }
		}
		/// <summary>
		/// Nationalitatea tarii.
		/// </summary>
		public string Nationalitate
		{
			get	{ return nationalitate; }
			set { nationalitate = value; }
		}
		/// <summary>
		/// Specifica daca tara este sau nu tara de baza
		/// </summary>
		public bool TaraDeBaza
		{
			get	{ return taraDeBaza; }
			set { taraDeBaza = value; }
		}
		#endregion

		#region LoadInfoTari
		/// <summary>
		/// Procedura selecteaza toate tarile
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoTari()
		{
			Salaries.Data.AdminTari tara = new Salaries.Data.AdminTari(settings.ConnectionString);
			return tara.LoadInfoTari();
		}
		#endregion

		#region LoadInfoTariCuJudete
		/// <summary>
		/// Procedura selecteaza toate tarile care au judete asociate
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoTariCuJudete()
		{
			Salaries.Data.AdminTari tara = new Salaries.Data.AdminTari(settings.ConnectionString);
			return tara.LoadInfoTariCuJudete();
		}
		#endregion

		#region LoadInfoTariUnion
		/// <summary>
		/// Sunt selectate toate tarile. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet LoadInfoTariUnion()
		{
			Salaries.Data.AdminTari tara = new Salaries.Data.AdminTari(settings.ConnectionString);
			return tara.LoadInfoTariUnion();
		}
		#endregion

		#region GetNationalitati
		/// <summary>
		/// Lista nationalitatilor din sistem
		/// </summary>
		/// <returns> Un DataSet cu toate nationalitatile din sistem.</returns>
		/// <remarks> 
		/// Autor: Cristina Raluca Muntean
		/// Data:  31.05.2006
		/// </remarks>
		public DataSet GetNationalitati()
		{
			Salaries.Data.AdminTari tara = new Salaries.Data.AdminTari(settings.ConnectionString);
			return tara.GetNationalitati();
		}
		#endregion

		#region GetNationalitatiUnion
		/// <summary>
		/// Sunt selectate toate nationalitatile. La aceste inregistrari se adauga si o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet GetNationalitatiUnion()
		{
			Salaries.Data.AdminTari tara = new Salaries.Data.AdminTari(settings.ConnectionString);
			return tara.GetNationalitatiUnion();
		}
		#endregion

		#region InsertTara
		/// <summary>
		/// Procedura adauga o tara
		/// </summary>
		public void InsertTara()
		{
			Salaries.Data.AdminTari tara = new Salaries.Data.AdminTari(settings.ConnectionString);
			tara.InsertTara(numeTara, simbol, nationalitate, taraDeBaza);
		}
		#endregion

		#region UpdateTara
		/// <summary>
		/// Procedura actualizeaza o tara
		/// </summary>
		public void UpdateTara()
		{
			Salaries.Data.AdminTari tara = new Salaries.Data.AdminTari(settings.ConnectionString);
			tara.UpdateTara(taraId, numeTara, simbol, nationalitate, taraDeBaza);
		}
		#endregion

		#region DeleteTara
		/// <summary>
		/// Procedura sterge o tara
		/// </summary>
		public void DeleteTara()
		{
			Salaries.Data.AdminTari tara = new Salaries.Data.AdminTari(settings.ConnectionString);
			tara.DeleteTara(taraId);
		}
		#endregion

		#region GetTaraInfo
		/// <summary>
		/// Procedura selecteaza o tara
		/// </summary>
		/// <returns>Returneaza un DataSet care contine date despre tara selectata</returns>
		public DataSet GetTaraInfo()
		{
			Salaries.Data.AdminTari tara = new Salaries.Data.AdminTari(settings.ConnectionString);
			return tara.GetTaraInfo(taraId);
		}
		#endregion

		#region GetTaraDeBaza
		/// <summary>
		/// Procedura selecteaza tara de baza
		/// </summary>
		/// <returns>Procedura returneaza un DataSet care contine datele despre tara de baza</returns>
		public DataSet GetTaraDeBaza()
		{
			Salaries.Data.AdminTari tara = new Salaries.Data.AdminTari(settings.ConnectionString);
			 return tara.GetTaraDeBaza();
		}
		#endregion

		#region CheckIfTaraCanBeDeleted
		/// <summary>
		/// Procedura verifica daca o tara poate fi stearsa
		/// </summary>
		/// <returns>Returneaza true daca se poate sterge si false altfel</returns>
		public bool CheckIfTaraCanBeDeleted()
		{
			Salaries.Data.AdminTari tara = new Salaries.Data.AdminTari(settings.ConnectionString);
			return tara.CheckIfTaraCanBeDeleted(taraId);
		}
		#endregion

		#region CheckIfTaraCanBeAdded
		/// <summary>
		/// Procedura veririca sa nu se creeze duplicate in tabela Tari prin adaugare/modificare
		/// </summary>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfTaraCanBeAdded()
		{
			Salaries.Data.AdminTari tara = new Salaries.Data.AdminTari(settings.ConnectionString);
			return tara.CheckIfTaraCanBeAdded(taraId, numeTara);
		}
		#endregion
	}
}
