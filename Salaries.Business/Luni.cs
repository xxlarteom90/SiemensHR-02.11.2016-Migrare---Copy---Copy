
using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for SituatieLunaraAngajat.
	/// new version mircea
	/// </summary>
	public class Luni : Salaries.Business.BizObject
	{
		#region Atribute private
		//Setarile aplicatiei
		private Configuration.ModuleSettings settings;
		//Id-ul angajatorului
		public int AngajatorID;
		//Id-ul lunii
		public int id;
		//Data lunii
		public DateTime data;
		//Specifica daca luna este activa sau nu
		public bool activ;
		//Valoarea procentului de inflatie a lunii
		public float procentInfl;
		#endregion

		#region Properietati
		public DateTime Data
		{
			get{return data;}
			set{data=value;}
		}

		public float ProcentInfl
		{
			get{return procentInfl;}
			set{procentInfl=value;}
		}
		public bool Activ
		{
			get{return activ;}
			set{activ=value;}
		}
		#endregion
		
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="pAngajatorID">Id-ul angajatorului</param>
		public Luni(int pAngajatorID)
		{
			settings = Configuration.ModuleConfig.GetSettings();
			this.AngajatorID=pAngajatorID;
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="pAngajatorID">Id-ul angajatorului</param>
		/// <param name="id">Id-ul lunii</param>
		public Luni(int pAngajatorID,int id)
		{
			settings = Configuration.ModuleConfig.GetSettings();
			this.AngajatorID=pAngajatorID;
			this.id=id;
			LoadLunaInflID(id);
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Adaugat:	Alex Ciobanu
		/// Data:		14.09.2005
		/// Constructor
		/// </summary>
		/// <param name="pAngajatorID">Id-ul angajatorului</param>
		/// <param name="st"></param>
		public Luni(int pAngajatorID,Configuration.ModuleSettings st)
		{
			settings = st;
			this.AngajatorID=pAngajatorID;
		}
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// Adaugat:	Alex Ciobanu
		/// Data:		14.09.2005
		/// </summary>
		/// <param name="pAngajatorID">Id-ul angajatorului</param>
		/// <param name="id">Id-ul lunii</param>
		/// <param name="st"></param>
		public Luni(int pAngajatorID,int id,Configuration.ModuleSettings st)
		{
			settings = st;
			this.AngajatorID=pAngajatorID;
			this.id=id;
			LoadLunaInflID(id);
		}
		#endregion
		
		#region LoadLunaInflID
		/// <summary>
		/// Procedura selecteaza datele unei luni
		/// </summary>
		/// <param name="id">Id-ul lunii</param>
		private void LoadLunaInflID(int id)
		{
			Data.Luni luni = new Data.Luni(settings.ConnectionString);
			Salaries.Data.LunaData detalii = luni.GetDetalii(id);
			this.data=detalii.Data;
			this.activ=detalii.Activ;
			this.procentInfl=detalii.ProcentInflatie;			
		}
		#endregion

		#region Create
		/// <summary>
		/// Procedura creaza o luna activa
		/// </summary>
		/// <param name="data">Data lunii</param>
		/// <param name="activ">Luna este activa sau nu</param>
		/// <param name="procentInfl">Procentul de inflatie al lunii</param>
		/// <param name="AngajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public int Create(DateTime data, bool activ ,float procentInfl,int AngajatorID)
		{
			Data.Luni nouaLuna = new Data.Luni(settings.ConnectionString);
			id = nouaLuna.InsertLuna(data,activ,procentInfl,AngajatorID);
			LoadLunaInflID(id);
			return id;
		}
		#endregion

		#region Update
		/// <summary>
		/// Procedura actualizeaza o luna
		/// </summary>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public int Update()
		{
			Data.Luni luni = new Data.Luni(settings.ConnectionString);
			return luni.UpdateLuna(id,data,activ,procentInfl,this.AngajatorID);
		}
		#endregion

		#region Delete
		/// <summary>
		/// Procedura sterge o luna
		/// </summary>
		public void Delete()
		{
			Data.Luni luni = new Data.Luni(settings.ConnectionString);
			luni.DeleteLuna(id);
		}
		#endregion

		#region AddLuna
		/// <summary>
		/// Procedura adauga o luna
		/// </summary>
		/// <param name="ld">Obiectul adaugat</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public int AddLuna(Salaries.Data.LunaData ld)
		{			
			return this.AddLuna(ld.Data,ld.Activ,ld.ProcentInflatie,ld.AngajatorId);
		}
		#endregion
		
		#region AddLuna
		/// <summary>
		/// Procedura adauga o luna
		/// </summary>
		/// <param name="data">Data lunii</param>
		/// <param name="activ">Luna este activa sau nu</param>
		/// <param name="procentInfl">Procentul de inflatie al lunii</param>
		/// <param name="AngajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza true daca s-a facut adaugarea si false altfel</returns>
		public int AddLuna(DateTime Data,	bool Activ,	float ProcentInflatie,int AngajatorID)
		{
			return new Salaries.Data.Luni(this.settings.ConnectionString).InsertLuna(Data,Activ,ProcentInflatie,AngajatorID);
		}
		#endregion

		#region ModifLuna
		/// <summary>
		/// Procedura modifica datele unei luni
		/// </summary>
		/// <param name="Data">Data lunii</param>
		/// <param name="Activ">Specifica daca luna este activa sau nu</param>
		/// <param name="ProcentInflatie">Procentul de inflatie al lunii</param>
		/// <returns>Returneaza true daca s-a facut modificarea si false altfel</returns>
		public int ModifLuna(DateTime Data,	bool Activ,	float ProcentInflatie)
		{
			Salaries.Data.LunaData ld=new Salaries.Data.LunaData();
			ld.Data=Data;
			ld.Activ=Activ;
			ld.ProcentInflatie=ProcentInflatie;
			return new Salaries.Data.Luni(this.settings.ConnectionString).UpdateLuna(ld);
		}
		#endregion

		#region ModifLuna
		/// <summary>
		/// Procedura modifica datele unei luni
		/// </summary>
		/// <param name="ld">Obiectul modificat</param>
		/// <returns>Returneaza true daca s-a facut modificarea si false altfel</returns>
		public int ModifLuna(Salaries.Data.LunaData ld)
		{
			return new Salaries.Data.Luni(this.settings.ConnectionString).UpdateLuna(ld);
		}
		#endregion

		#region DeleteLuna
		/// <summary>
		/// Procedura sterge o luna
		/// </summary>
		/// <param name="LunaID">Id-ul lunii care se sterge</param>
		/// <returns>Returneaza true daca s-a facut stergerea si false altfel</returns>
		public int DeleteLuna(int LunaID)
		{
			return new Salaries.Data.Luni(this.settings.ConnectionString).DeleteLuna(LunaID);
		}
		#endregion	
	
		#region GetLunaActiva
		/// <summary>
		/// Procedura selecteaza luna activa
		/// </summary>
		/// <returns>Returneaza un obiect care contine datele lunii active</returns>
		public Salaries.Data.LunaData GetLunaActiva()
		{
			return new Salaries.Data.Luni(this.settings.ConnectionString).GetLunaActiva(this.AngajatorID);
		}
		#endregion

		#region GetLunaActiva
		/// <summary>
		/// Procedura selecteaza luna activa
		/// </summary>
		/// <returns>Returneaza un DataSet care contine datele lunii active</returns>
		public DataSet GetLunaActivaDataSet()
		{	
			return new Salaries.Data.Luni(this.settings.ConnectionString).GetLunaActivaDataSet(AngajatorID);
		}
		#endregion

		#region GetLuni
		/// <summary>
		/// Procedura selecteaza toate lunile
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetLuni()
		{
			return new Salaries.Data.Luni(this.settings.ConnectionString).GetLuni(this.AngajatorID);
		}
		#endregion

		#region GetAniSal_Salarii
		/// <summary>
		/// Muntean Raluca Cristina
		/// Returneaza anii pentru care sunt calculate salariile in baza de date
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAniSal_Salarii()
		{
			return new Salaries.Data.Luni(this.settings.ConnectionString).GetAniSal_Salarii();
		}
		#endregion
		
		#region GetLuniSal_Salarii
		/// <summary>
		/// Muntean Raluca Cristina
		/// Returneaza lunile din anul dat ca parametru pentru care sunt calculate salariile
		/// in baza de date
		/// </summary>
		/// <param name="an">Anul pentru care se selecteaza lunile</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetLuniSal_Salarii(int an)
		{
			return new Salaries.Data.Luni(this.settings.ConnectionString).GetLuniSal_Salarii(an);
		}
		#endregion
		
		#region GetLuniSal_Luni
		/// <summary>
		/// Muntean Raluca Cristina
		/// Returneaza lunile din anul dat ca parametru pentru care sunt calculate salariile
		/// in baza de date
		/// </summary>
		/// <param name="an">Anul pentru care se selecteaza lunile</param>
		/// <param name="angajatorID">Angajatorul pentru care se selecteaza lunile</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetLuniSal_Luni(int an, int angajatorID)
		{
			return new Salaries.Data.Luni(this.settings.ConnectionString).GetLuniSal_Luni(an,angajatorID);
		}
		#endregion
		
		#region CalculSalariiAngajati
		/// <summary>
		/// Cristina Muntean
		/// sunt calculate salariile in varianata finala
		/// </summary>
		/// <param name="LunaID">Id-ul lunii pentru care sunt calculare salariile</param>
		public void CalculSalariiAngajati(int LunaID)
		{
			new Process(this.AngajatorID,LunaID,settings).ProcessSalariiFinal();
		}
		#endregion
		
		#region CalculSalariiIndexate
		/// <summary>
		/// Autor: Cristina Raluca Muntean
		/// Data: 28.12.2005
		/// Descriere: Returneaza valorile salariilor indexate ale angajatilor.
		/// </summary>
		/// <param name="angajatorID">Id-ul angajatorului</param>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet CalculSalariiIndexate(int angajatorID)
		{
			Salaries.Business.Salariu salariiIdexate = new Salaries.Business.Salariu();
			DataSet dsSalariiIndexate = salariiIdexate.CalculSalariiIndexate(angajatorID);

			return dsSalariiIndexate;
		}
		#endregion
        
		#region CalculIntermediarSalariiAngajati
		/// <summary>
		/// Cristina Muntean
		/// Sunt calculate salariile in varianta intermediara
		/// </summary>
		/// <param name="LunaID">Id-ul lunii pentru care sunt calculare salariile</param>
		public void CalculIntermediarSalariiAngajati(int LunaID)
		{
			new Process(this.AngajatorID,LunaID,settings).ProcessSalariiIntermediar();
		}
		#endregion
		
		#region SalariiLunaActiva
		/// <summary>
		/// Sunt calculate salariile din luna activa, inainte sa fie inchisa luna(este facut un calcul intermediar)
		/// </summary>
		public void SalariiLunaActiva()
		{
			Salaries.Data.LunaData lunaActiva = this.GetLunaActiva();
			this.CalculIntermediarSalariiAngajati(lunaActiva.LunaId);
		}
		#endregion
		
		#region InchideLunaActiva
		/// <summary>
		/// Este inchisa luna si este efectuat calculul final al salariilor
		/// </summary>
		public void InchideLunaActiva()
		{		
			Salaries.Data.LunaData lunaActiva = this.GetLunaActiva();

			//sunt calculate salariile angajtior
			this.CalculSalariiAngajati(lunaActiva.LunaId);

			lunaActiva.Activ=false;
			this.ModifLuna(lunaActiva);
		
			Salaries.Data.LunaData dlNext = new Salaries.Data.LunaData();
			dlNext.Activ=true;
			dlNext.Data=lunaActiva.Data.AddMonths(1);
			dlNext.LunaId=-1;
			dlNext.AngajatorId = lunaActiva.AngajatorId;
			dlNext.ProcentInflatie=0;
			this.AddLuna(dlNext);
		
			this.CopySetariSalarii_Luna(lunaActiva.LunaId,this.GetLunaActiva().LunaId);
		}
		#endregion
		
		#region RedeschidereLunaPrecedenta
		/// <summary>
		/// Este redeschisa luna precedenta lunii active.
		/// </summary>
		/// <returns> Returneaza 0 in cazul in care redeschiderea s-a realizat cu succes, 
		/// o valoare diferita de 0, altfel</returns>
		/// <remarks>
		/// Autor: Cristina Muntean
		/// Data   13.12.2006
		/// </remarks>
		public int RedeschidereLunaPrecedenta()
		{
			return new Salaries.Data.Luni(this.settings.ConnectionString).RedeschidereLunaPrecedenta();
		}
		#endregion

		#region CopySetariSalarii_Luna
		/// <summary>
		/// Procedura copiaza salariile de pe o luna pe alte
		/// </summary>
		/// <param name="LunaOld">Vechea luna</param>
		/// <param name="LunaNew">Noua luna</param>
		public void CopySetariSalarii_Luna(int LunaOld,int LunaNew)
		{
			new Salaries.Data.Luni(this.settings.ConnectionString).CopySetariSalarii_Luna(LunaOld,LunaNew);
		}
		#endregion

		#region FillZileLuna
		/// <summary>
		/// Procedura completeaza zilele pentru o luna
		/// </summary>
		/// <param name="luna">Luna</param>
		/// <param name="an">Anul</param>
		public void FillZileLuna( int luna, int an )
		{
			new Salaries.Data.Luni( this.settings.ConnectionString ).FillZileLuna( luna, an );
		}
		#endregion

		#region GetLunaPrecedenta
		/// <summary>
		/// Procedura selecteaza luna precedenta
		/// </summary>
		/// <param name="lunaID">Id-ul lunii curente</param>
		/// <returns>Returneaza id-ul lunii precedente</returns>
		public int GetLunaPrecedenta( int lunaID )
		{
			return new Salaries.Data.Luni( this.settings.ConnectionString ).GetLunaPrecedenta( lunaID, AngajatorID );
		}
		#endregion

		#region GetDetalii
		/// <summary>
		/// Procedura selecteaza detaliile unei luni
		/// </summary>
		/// <param name="lunaID">Id-ul lunii selectate</param>
		/// <returns>Returneaza un obiecte care contine detaliile lunii selectate</returns>
		public Data.LunaData GetDetalii( int lunaID )
		{
			return new Data.Luni( settings.ConnectionString ).GetDetalii( lunaID );
		}
		#endregion

		#region GetDetaliiByData
		/// <summary>
		/// Procedura selecteaza detaliile unei luni
		/// </summary>
		/// <param name="data">Data de inceput a lunii pentru care se selecteaza datele</param>
		/// <returns>Returneaza un obiect care contine aceste date</returns>
		public Data.LunaData GetDetaliiByData( DateTime data )
		{
			return new Data.Luni( settings.ConnectionString ).GetDetalii( data, AngajatorID ); 
		}	
		#endregion

		#region ExistaZilePentruLunaActiva
		/// <summary>
		/// Verificam daca exista zile pt luna activa in table tm_zile
		/// </summary>
		/// <returns>Returneaza un DataSet care contine zilele lunii active</returns>
		public DataSet ExistaZilePentruLunaActiva()
		{	
			return new Data.Luni(settings.ConnectionString).ExistaZilePentruLunaActiva(id); 
		}
		#endregion
	}
}


