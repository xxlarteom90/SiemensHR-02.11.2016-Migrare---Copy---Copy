/*
 *	Autor:     Cristina Muntean
 *	Data:      22.03.2005
 *  Descriere: este efectuat calculul salariilor
 */
using System;
using System.Collections;
using Salaries.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for Process.
	/// </summary>
	public class Process
	{
		#region	Atribute private
		//Setarile aplicatiei
		private Configuration.ModuleSettings settings;
		//Id-ul angajatorului
		private int angajatorID;
		//Id-ul lunii
		private int lunaID;
		#endregion

		#region Proprietati
		
		public int LunaID
		{
			get { return lunaID; }
			set { lunaID = value; }
		}

		public int AngajatorID
		{
			get { return angajatorID; }
			set { angajatorID = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="pAngajatorID">Id-ul angajatorului</param>
		/// <param name="pLunaID">Id-ul lunii</param>
		public Process(int pAngajatorID, int pLunaID)
		{
			settings = Configuration.ModuleConfig.GetSettings();
			angajatorID = pAngajatorID;
			lunaID = pLunaID;

		}
		#endregion

		#region Constructor
		//Adaugat:	Alex Ciobanu
		//Data:		14.09.2005
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="pAngajatorID">Id-ul angajatorului</param>
		/// <param name="pLunaID">Id-ul lunii</param>
		/// <param name="st"></param>
		public Process(int pAngajatorID, int pLunaID,Configuration.ModuleSettings st)
		{
			settings = st;
			angajatorID = pAngajatorID;
			lunaID = pLunaID;
		}
		#endregion

		#region ProcessSalariiFinal
		/// <summary>
		/// Este efectuat calculul final al salariilor
		/// </summary>
		public void ProcessSalariiFinal()
		{
			//sunt sterse din baza de date salariile calculate inainte de inchiderea lunii
			Salaries.Data.Process processSalarii = new Data.Process(settings.ConnectionString);
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			//sunt preluate toate id-urile angajatilor
			angajat.AngajatorId = angajatorID;
			ArrayList alAng = angajat.GetSal_SituatieLunaraAngajatiIDs(lunaID);
			int tot=alAng.Count,prev=Parameters.Task_PercentDone,current=0;
			foreach(int angajatID in alAng)
			{
				//este sters salariul angajatului pe o anumita luna
				current++;
				Parameters.Task_PercentDone=prev+(int)(current*10/tot);
				processSalarii.DeleteSalariuLuna(lunaID, angajatID);
			}
			
			//sunt calculate salariile si sunt introduse datele in baza de date
			ProcessSalariiIntermediar();	
		}
		#endregion

		#region  ProcessSalariiIntermediar
		/// <summary>
		/// Este efectuat calculul salariului pentru fiecare angajat in parte
		/// </summary>
		public void ProcessSalariiIntermediar()
		{
			Salaries.Data.Process processSalarii = new Salaries.Data.Process(settings.ConnectionString);
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.AngajatorId = angajatorID;
			//sunt preluate toate id-urile angajatilor
			ArrayList alAng = angajat.GetSal_SituatieLunaraAngajatiIDs(lunaID);
			processSalarii.DeleteSalarii(lunaID, angajatorID);
			int total=alAng.Count,previous=Parameters.Task_PercentDone,current=0;
			foreach(int id in alAng)
			{
				current++;
				Parameters.Task_PercentDone=previous+(int)(current*33/total);
				//este sters salariul angajatului pe o anumita luna
				//processSalarii.DeleteSalariuLuna(lunaID, id);
				
				//este calculat salariul angajatului
				ProcessSalariuAngajat(id);
			}
		}
		#endregion

		#region ProcessSalariuAngajat
		/// <summary>
		/// Este efectuat calculul salariului unui angajat
		/// </summary>
		/// <param name="angajatID">Id-ul angajatului</param>
		public void ProcessSalariuAngajat(int angajatID)
		{
			Data.Process processSalariu = new Data.Process(settings.ConnectionString);
			processSalariu.ProcessSalariuAngajat(lunaID, angajatID);
		}
		#endregion
	}
}
