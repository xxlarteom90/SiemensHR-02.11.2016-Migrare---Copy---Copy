/*
 * Autor:	Oprescu Claudia
 * Data:	11.04.2006
 */

using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Administrarea caselor de asigurari
	/// </summary>
	public class CasaDeAsigurari 
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul casei de asigurari
		private int casaDeAsigurariID;
		//Codul casei de asigurari
		private string cod;
		//Denumirea casei de asigurari
		private string denumire;
		//Descrierea casei de asigurari 
		private string descriere;	
		//Codificarea casei de asigurari
		private string codificare;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public CasaDeAsigurari()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul casei de asigurari.
		/// </summary>
		public int CasaDeAsigurariID
		{
			get
			{
				return casaDeAsigurariID;
			}
			set
			{
				casaDeAsigurariID=value;
			}
		}
		/// <summary>
		/// Codul casei de asigurari.
		/// </summary>
		public string Cod
		{
			get
			{
				return cod;
			}
			set
			{
				cod=value;
			}
		}
		/// <summary>
		/// Denumirea casei de asigurari.
		/// </summary>
		public string Denumire
		{
			get
			{
				return denumire;
			}
			set
			{
				denumire=value;
			}
		}
		/// <summary>
		/// Descrierea casei de asigurari.
		/// </summary>
		public string Descriere
		{
			get
			{
				return descriere;
			}
			set
			{
				descriere=value;
			}
		}
		/// <summary>
		/// Codificarea casei de asigurari.
		/// </summary>
		public string Codificare
		{
			get
			{
				return codificare;
			}
			set
			{
				codificare = value;
			}
		}
		#endregion
		
		#region Insert
		/// <summary>
		/// Insereaza o casa de asigurari
		/// </summary>
		/// <returns>Id-ul casei de asigurari nou adaugata</returns>
		public int Insert()
		{
			Data.CasaDeAsigurari casaAsigurari = new Salaries.Data.CasaDeAsigurari(settings.ConnectionString);
			return casaAsigurari.Insert(cod, denumire, descriere, codificare);		
		}
		#endregion

		#region Update
		/// <summary>
		/// Actualizeaza o casa de asigurari
		/// </summary>
		public void Update()
		{
			Data.CasaDeAsigurari casaAsigurari = new Salaries.Data.CasaDeAsigurari(settings.ConnectionString);
			casaAsigurari.Update(casaDeAsigurariID, cod, denumire, descriere, codificare);		
		}
		#endregion

		#region Delete
		/// <summary>
		/// Sterge casa de asigurari
		/// </summary>
		public void Delete()
		{
			Data.CasaDeAsigurari casaAsigurari = new Salaries.Data.CasaDeAsigurari(settings.ConnectionString);
			casaAsigurari.Delete(casaDeAsigurariID);
		}
		#endregion
		
		#region GetCasaDeAsigurariInfo
		/// <summary>
		/// Informatii despre o casa de asigurari
		/// </summary>
		/// <param name="CasaDeAsigurariID">Id-ul casei de asigurari</param>
		/// <returns>Se returneaza un DataSet care contine toate detaiile despre o casa de asigurari</returns>
		public DataSet GetCasaDeAsigurariInfo(int casaDeAsigurariID)
		{
			Data.CasaDeAsigurari casaAsigurari = new Salaries.Data.CasaDeAsigurari(settings.ConnectionString);
			return casaAsigurari.GetCasaDeAsigurariInfo(casaDeAsigurariID);	
		}
		#endregion

		#region GetAllCasaDeAsigurari
		/// <summary>
		/// Sunt obtinute informatii despre toate casele de asigurari
		/// </summary>
		/// <returns>Se returneaza un dataset care contine aceste valori</returns>
		public DataSet GetAllCasaDeAsigurari()
		{
			Data.CasaDeAsigurari casaAsigurari = new Salaries.Data.CasaDeAsigurari(settings.ConnectionString);
			return casaAsigurari.GetAllCasaDeAsigurari();	
		}
		#endregion

		#region CheckIfCasaAsigurariCanBeDeleted
		/// <summary>
		/// Verifica daca se poate sterge casa de asigurari reprezentata de obiectul apelant. Pentru aceasta, creeaza
		/// un obiect de tip <c>Salaries.Data.CasaDeAsigurari</c> si ii apeleaza metoda <c>CheckIfCasaAsigurariCanBeDeleted( int casaAsigurariID )</c>,
		/// returnand rezultatul intors de aceasta.
		/// </summary>
		/// <returns>1 daca exista date asociate ei, 
		///			 2 daca e ultima din lista
		///			 0 daca se poate efectua stergerea
		///	</returns>
		/// <remarks>
		/// Vezi descrierea metodei <c>CheckIfCasaAsigurariCanBeDeleted( int casaAsigurariID )</c>, din clasa <c>Salaries.Data.CasaDeAsigurari</c>.
		/// 
		/// Autor: Anca Holostencu
		/// </remarks>
		public int CheckIfCasaAsigurariCanBeDeleted() 
		{
			return new Salaries.Data.CasaDeAsigurari( settings.ConnectionString ).CheckIfCasaAsigurariCanBeDeleted( casaDeAsigurariID );
		}
		#endregion

		#region VerificaExistentaCasaDeAsigurari
		/// <summary>
		/// Verifica daca se poate adauga/modifica o casa de asigurari cu denumirea si codul introduse de utilizator.
		/// </summary>
		/// <returns>true, daca se poate adauga/modifica, false in caz contrar</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  14.06.2006
		/// </remarks>
		public bool VerificaExistentaCasaDeAsigurari() 
		{
			return new Salaries.Data.CasaDeAsigurari(settings.ConnectionString).VerificaExistentaCasaDeAsigurari(casaDeAsigurariID, denumire, cod);
		}
		#endregion
	}
}

