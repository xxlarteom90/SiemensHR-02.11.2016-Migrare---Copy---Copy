/*
 * Author:		Lungu Andreea
 * Date:		19.03.2010
 * Description:	Retinerile recurente pentru un angajat
 * 
 */ 

using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for RetineriRecurenteAngajat.
	/// </summary>
	public class RetineriRecurenteAngajat
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//structura de retinere de recurenta
		private Salaries.Data.RetinereRecurentaAngajat retAng;
		//oare am nevoie de valorile vechi???
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public RetineriRecurenteAngajat()
		{
			settings = Configuration.ModuleConfig.GetSettings();
			retAng = new Salaries.Data.RetinereRecurentaAngajat();
		}
		#endregion

		#region Properies
		/// <summary>
		/// retinerea recurenta
		/// </summary>
		public Salaries.Data.RetinereRecurentaAngajat RetAng
		{
			get{ return retAng; }
			set{ retAng = value;}
		}
		#endregion

		#region LoadRetineriAngajat
		/// <summary>
		/// Procedura selecteaza retinerile recurente unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadRetineriAngajat()
		{
			Salaries.Data.RetineriRecurenteAngajat retineri = new Salaries.Data.RetineriRecurenteAngajat(settings.ConnectionString);
			return retineri.LoadRetineriAngajat(retAng.AngajatID);
		}
		#endregion

		#region GetRetinere
		/// <summary>
		/// Procedura aduce datele unei retineri
		/// </summary>
		public void GetRetinere(int idRetinere)
		{
			Salaries.Data.RetineriRecurenteAngajat retineri = new Salaries.Data.RetineriRecurenteAngajat(settings.ConnectionString);
			retAng =  retineri.GetRetinere(idRetinere);
		}
		#endregion

		#region VerificaIntersectie
		/// <summary>
		/// Verifica daca se poate face o anuita operatie
		/// </summary>
		public int VerificaIntersectieNrRetineri()
		{
			Salaries.Data.RetineriRecurenteAngajat retineri = new Salaries.Data.RetineriRecurenteAngajat(settings.ConnectionString);
			return retineri.VerificaIntersectieNrRetineri((int)retAng.AngajatID, retAng.TipRetinere, retAng.DataInceput, retAng.DataSfarsit);
		}
		#endregion

		#region InsertRetinereAngajat
		/// <summary>
		/// Procedura adauga o retinere recurenta pentur angajat
		/// </summary>
		public void InsertRetinereRecurentaAngajat()
		{
			//se adauga retinerea in baza de date
			Salaries.Data.RetineriRecurenteAngajat retineri = new Salaries.Data.RetineriRecurenteAngajat(settings.ConnectionString);
			retineri.InsertRetinereRecurentaAngajat(retAng);
		}
		#endregion

		#region UpdateRetinereRecurentaAngajat()
		/// <summary>
		/// Procedura actualizeaza o retinere
		/// </summary>
		public void UpdateRetinereRecurentaAngajat()
		{
			Salaries.Data.RetineriRecurenteAngajat retineri = new Salaries.Data.RetineriRecurenteAngajat(settings.ConnectionString);
			retineri.UpdateRetinereRecurentaAngajat(retAng);
		}
		#endregion

		#region DeleteRetinereRecurentaAngajat
		/// <summary>
		/// Procedura sterge o retinere recurenta
		/// </summary>
		public void DeleteRetinereRecurentaAngajat()
		{
			Salaries.Data.RetineriRecurenteAngajat retineri = new Salaries.Data.RetineriRecurenteAngajat(settings.ConnectionString);
			retineri.DeleteRetinereRecurentaAngajat(retAng);
		}
		#endregion
	}
}
