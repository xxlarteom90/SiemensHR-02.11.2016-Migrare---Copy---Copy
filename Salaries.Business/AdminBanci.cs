using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for AdminBanci.
	/// </summary>
	public class AdminBanci
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul bancii
		private int bancaId;
		//Codul bancii
		private string cod;
		//Denumirea bancii
		private string nume;
		//Filiala bancii
		private string filiala;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public AdminBanci()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// Id-ul bancii.
		/// </summary>
		public int BancaId
		{
			get	{ return bancaId; }
			set { bancaId = value; }
		}
		/// <summary>
		/// Codul bancii.
		/// </summary>
		public string Cod
		{
			get	{ return cod; }
			set { cod = value; }
		}
		/// <summary>
		/// Denumirea bancii.
		/// </summary>
		public string Nume
		{
			get	{ return nume; }
			set { nume = value; }
		}
		/// <summary>
		/// Filiala bancii.
		/// </summary>
		public string Filiala
		{
			get	{ return filiala; }
			set { filiala = value; }
		}
		#endregion

		#region LoadInfoBanci
		/// <summary>
		/// Procedura selecteaza toate bancile
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste banci</returns>
		public DataSet LoadInfoBanci()
		{
			Salaries.Data.AdminBanci banca = new Salaries.Data.AdminBanci(settings.ConnectionString);
			return banca.LoadInfoBanci();
		}
		#endregion

		#region LoadInfoBanciUnion
		/// <summary>
		/// Sunt selectate toate bancile. La aceste inregistrari se adauga o inregistrare vida.
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inrgistrari</returns>
		public DataSet LoadInfoBanciUnion()
		{
			Salaries.Data.AdminBanci banca = new Salaries.Data.AdminBanci(settings.ConnectionString);
			return banca.LoadInfoBanciUnion();
		}
		#endregion

		#region LoadInfoBanca
		//Lungu Andreea - 09.08.2011
		/// <summary>
		/// Sunt completate datele unei banci.
		/// </summary>
		public void LoadInfoBanca(int idBanca)
		{
			Salaries.Data.AdminBanci banca = new Salaries.Data.AdminBanci(settings.ConnectionString);
			DataSet ds = banca.LoadInfoBanca(idBanca);
			if (ds.Tables[0].Rows.Count == 1)
			{
				DataRow dr = ds.Tables[0].Rows[0];
				this.nume = dr["Nume"].ToString();
				this.bancaId = idBanca;
				this.cod = dr["CodBanca"].ToString();
				this.filiala = dr["Filiala"].ToString();
			}
		}
		#endregion

		#region GetBanci
		/// <summary>
		/// Returneaza urmatoarele date despre fiecare banca: codul bancii - numele bancii si id-ul acesteia.
		/// </summary>
		/// <returns> Toate datele aferente bancilor sunt stocate intr-un DataSet.</returns>
		public DataSet GetBanci()
		{
			Salaries.Data.AdminBanci banca = new Salaries.Data.AdminBanci(settings.ConnectionString);
			return banca.GetBanci();
		}
		#endregion

		#region GetJSArrays
		/// <summary>
		/// Returneaza array-uri cu BancaID si Numnarul de conturi asignate la fiecare banca
		/// </summary>
		/// <returns>Procedura returneaza stringul care contine bancile si numerele de cont ale acestora</returns>
		public string GetJSArrays()
		{
			Salaries.Data.AdminBanci banca = new Salaries.Data.AdminBanci(settings.ConnectionString);
			return banca.GetJSArrays();
		}
		#endregion

		#region InsertBanca
		/// <summary>
		/// Procedura adauga o banca
		/// </summary>
		public void InsertBanca()
		{
			Salaries.Data.AdminBanci banca = new Salaries.Data.AdminBanci(settings.ConnectionString);
			banca.InsertBanca(cod, nume, filiala);
		}
		#endregion

		#region UpdateBanca
		/// <summary>
		/// Procedura actualizeaza o banca
		/// </summary>
		public void UpdateBanca()
		{
			Salaries.Data.AdminBanci banca = new Salaries.Data.AdminBanci(settings.ConnectionString);
			banca.UpdateBanca(bancaId, cod, nume, filiala);
		}
		#endregion

		#region DeleteBanca
		/// <summary>
		/// Procedura sterge o banca
		/// </summary>
		public void DeleteBanca()
		{
			Salaries.Data.AdminBanci banca = new Salaries.Data.AdminBanci(settings.ConnectionString);
			banca.DeleteBanca(bancaId);
		}
		#endregion

		#region VerificaExistentaBanca
		/// <summary>
		/// Verifica daca mai exista inca o banca ce are acelasi cod si/sau denumire cu banca ce se doreste a fi
		/// adaugata/modificata.
		/// </summary>
		/// <returns> true in cazul in care mai exista o banca ce are aceleasi caracteristici, false altfel.</returns>
		/// <remarks>
		/// Autor:  Cristina Raluca Muntean
		/// Data:   14.06.2006
		/// </remarks>
		public bool VerificaExistentaBanca()
		{
			Salaries.Data.AdminBanci banca = new Salaries.Data.AdminBanci(settings.ConnectionString);
			return banca.VerificaExistentaBanca(bancaId, cod, nume, filiala);
		}
		#endregion

		#region VerificaStergereBanca
		/// <summary>
		/// Verifica daca se poate sterge banca.
		/// </summary>
		/// <returns> true in cazul in care se poate sterge banca, false altfel.</returns>
		/// <remarks>
		/// Autor:  Cristina Raluca Muntean
		/// Data:   14.06.2006
		/// </remarks>
		public int VerificaStergereBanca()
		{
			Salaries.Data.AdminBanci banca = new Salaries.Data.AdminBanci(settings.ConnectionString);
			return banca.VerificaStergereBanca(bancaId);
		}
		#endregion
	}
}
