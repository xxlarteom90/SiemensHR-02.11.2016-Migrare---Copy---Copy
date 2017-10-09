/*
 * Autor:	ManuelNeagoe
 * Data:	28.01.2013
 */

using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for TipAsigurat.
	/// </summary>
	public class TipAsigurat
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul casei de asigurari
		private int tipAsiguratID;
		//Descrierea casei de asigurari 
		private string descriere;	
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public TipAsigurat()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul tipului de asigurat.
		/// </summary>
		public int TipAsiguratID
		{
			get {return tipAsiguratID;}
			set {tipAsiguratID=value;}
		}
		/// <summary>
		/// Descrierea tipului de asigurat.
		/// </summary>
		public string Descriere
		{
			get {return descriere;}
			set {descriere=value;}
		}
		#endregion

		#region Insert
		/// <summary>
		/// Insereaza un tip de asigurat
		/// </summary>
		/// <returns>Id-ul tipului de angajat</returns>
		public int Insert()
		{
			Data.TipAsigurat tipAsigurat = new Salaries.Data.TipAsigurat(settings.ConnectionString);
			return tipAsigurat.Insert(tipAsiguratID, descriere);		
		}
		#endregion

		#region Update
		/// <summary>
		/// Actualizeaza o casa de asigurari
		/// </summary>
		public void Update()
		{
			Data.TipAsigurat tipAsigurat = new Salaries.Data.TipAsigurat(settings.ConnectionString);
			tipAsigurat.Update(tipAsiguratID, descriere);		
		}
		#endregion

		#region Delete
		/// <summary>
		/// Sterge casa de asigurari
		/// </summary>
		public void Delete()
		{
			Data.TipAsigurat tipAsigurat = new Salaries.Data.TipAsigurat(settings.ConnectionString);
			tipAsigurat.Delete(tipAsiguratID);
		}
		#endregion
		
		#region GetTipAsiguratInfo
		/// <summary>
		/// Informatii despre un tip de asigurat
		/// </summary>
		/// <param name="tipAsiguratID">Id-ul tipului de asigurat</param>
		/// <returns>Se returneaza un DataSet care contine toate detaiile despre un tip de asigurat</returns>
		public DataSet GetTipAsiguratInfo(int tipAsiguratID)
		{
			Data.TipAsigurat tipAsigurat = new Salaries.Data.TipAsigurat(settings.ConnectionString);
			return tipAsigurat.GetTipAsiguratInfo(tipAsiguratID);	
		}
		#endregion

		#region GetAllTipAsigurat
		/// <summary>
		/// Sunt obtinute informatii despre toate tipurile de asigurat
		/// </summary>
		/// <returns>Se returneaza un dataset care contine aceste valori</returns>
		public DataSet GetAllTipAsigurat()
		{
			Data.TipAsigurat tipAsigurat = new Salaries.Data.TipAsigurat(settings.ConnectionString);
			return tipAsigurat.GetAllTipAsigurat();	
		}
		#endregion

		#region CheckIfTipAsiguratCanBeDeleted
		/// <summary>
		/// Verifica daca se poate sterge un tip de asigurat reprezentat de obiectul apelant. Pentru aceasta, creeaza
		/// un obiect de tip <c>Salaries.Data.TipAsigurat</c> si ii apeleaza metoda <c>CheckIfTipAsiguratCanBeDeleted( int tipAsiguratID )</c>,
		/// returnand rezultatul intors de aceasta.
		/// </summary>
		/// <returns>1 daca exista date asociate lui, 
		///			 2 daca e ultimul din lista
		///			 0 daca se poate efectua stergerea
		///	</returns>
		public int CheckIfTipAsiguratCanBeDeleted() 
		{
			return new Salaries.Data.TipAsigurat( settings.ConnectionString ).CheckIfTipAsiguratCanBeDeleted( tipAsiguratID );
		}
		#endregion

		#region VerificaExistentaTipAsigurat
		/// <summary>
		/// Verifica daca se poate adauga/modifica un tip de asigurat cu ID-ul si denumirea introduse de utilizator.
		/// </summary>
		/// <returns>true, daca se poate adauga/modifica, false in caz contrar</returns>

		public bool VerificaExistentaTipAsigurat() 
		{
			return new Salaries.Data.TipAsigurat(settings.ConnectionString).VerificaExistentaTipAsigurat(tipAsiguratID, descriere);
		}
		#endregion
	}
}
