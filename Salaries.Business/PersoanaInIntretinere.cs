using System;
using System.Data;

/*
 *	Modificat:	Lungu Andreea
 *	Data:		18.03.2008
 *	Descriere:	A fost adaugat campul activ.
 * */

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for PersoanaInIntretinere.
	/// </summary>
	public sealed class PersoanaInIntretinere:Salaries.Business.BizObject
	{				
		#region Atribute private
		private Configuration.ModuleSettings settings;
		//CNP-ul persoanei
		private long cnp;
		//Numele persoanei
		private string nume;
		//Prenumele persoanei
		private string prenume;
		//Coeficientul 
		private decimal coeficient;
		//Tipul persoanei in intretinere
		private int tipid;
		//Tipul invaliditatii
		private int invaliditateid;
		//Activ - persoana respectiva este sau nu in intretinerea angajatului
		private bool activ;
		//Id-ul angajatului
		private int angajatid;
		//Id-ul persoanei
		private int id;
		#endregion

		#region Proprietati

		public int ID
		{
			get {return id;}
			set {id=value;}
		}

		public long CNP
		{
			get{return cnp;}
			set{cnp=value;}
		}

		public string Nume
		{
			get{return nume;}
			set{nume=value;}
		}

		public string Prenume
		{
			get{return prenume;}
			set{prenume=value;}
		}

		public decimal Coeficient
		{
			get{return coeficient;}
		}

		public int TipID
		{
			get{return tipid;}
			set{tipid=value;}
		}

		public int InvaliditateID
		{
			get{return invaliditateid;}
			set{invaliditateid=value;}
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
		public PersoanaInIntretinere()
		{
			settings = Configuration.ModuleConfig.GetSettings();
			ResetDate();
		}
		#endregion
		
		#region PersoanaInIntretinere
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="id">Id-ul persoanei</param>
		public PersoanaInIntretinere(int id)
		{
			settings = Configuration.ModuleConfig.GetSettings();
			this.id=id;
			LoadPersoanaID();
		}
		#endregion
		
		#region ResetDate
		/// <summary>
		/// Procedura reseteaza datele unei persoane
		/// </summary>
		private void ResetDate()
		{
			this.id=-1;
			this.nume=string.Empty;
			this.prenume=string.Empty;
            this.cnp=0;
			this.coeficient=0;
			this.activ = true;
		}
		#endregion

		#region LoadPersoanaID
		/// <summary>
		/// Procedura selecteaza datele unei persoane
		/// </summary>
		private void LoadPersoanaID()
		{
			Data.PersoaneInIntretinere pers = new Data.PersoaneInIntretinere(settings.ConnectionString);
			Data.DetaliiPersoane detalii = pers.GetDetalii(id);
			this.Nume = detalii.Nume;
			this.Prenume = detalii.Prenume;
			this.CNP = detalii.CNP;
			this.tipid = detalii.TipID;
			this.InvaliditateID = detalii.InvaliditateID;
			this.Activ = detalii.Activ;
			this.ID = detalii.ID;
			this.angajatid = detalii.AngajatID;
		}
		#endregion
		
		#region Create
		/// <summary>
		/// Procedura adauga o persoana in intretinere
		/// </summary>
		/// <param name="angajatid">Id-ul angajatului</param>
		/// <param name="nume">Numele persoanei</param>
		/// <param name="prenume">Prenumele persoanei</param>
		/// <param name="cnp">CNP-ul persoanei</param>
		/// <param name="tipid">Tipul persoanei</param>
		/// <param name="invaliditateid">Tipul de invaliditate</param>
		/// <param name="activ">Daca persoana este sau nu in intretinere la momentul respectiv</param>
		public void Create(int angajatid,string nume,string prenume,long cnp, int tipid, int invaliditateid, bool activ)
		{
			Data.PersoaneInIntretinere pers=new Data.PersoaneInIntretinere(settings.ConnectionString);
			pers.Add(angajatid, nume, prenume, cnp, tipid, invaliditateid, activ);
			LoadPersoanaID();
		}
		#endregion

		#region Update
		/// <summary>
		/// Procedura actualizeaza o persoana
		/// </summary>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool Update()
		{
			Data.PersoaneInIntretinere pers=new Data.PersoaneInIntretinere(settings.ConnectionString);
			return pers.Update(id, nume, prenume, cnp, tipid, invaliditateid, activ);
		}
		#endregion

		#region Delete
		/// <summary>
		/// Procedura sterge o persoana in intretinere
		/// </summary>
		/// <returns>Returneaza true daca s-a facut stergerea si false altfel</returns>
		public bool Delete()
		{
			Data.PersoaneInIntretinere pers=new Data.PersoaneInIntretinere(settings.ConnectionString);
			bool ret=pers.Delete(id);
			ResetDate();
			return ret;
		}
		#endregion

		#region GetAllTipuriPersoaneInIntretinere
		/// <summary>
		/// Procedura returneaza toate tipurile de persoane in intretinere
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste inregistrari</returns>
		public DataSet GetAllTipuriPersoaneInIntretinere()
		{	
			Data.PersoaneInIntretinere pers=new Data.PersoaneInIntretinere(settings.ConnectionString);
			return pers.GetAllTipuriPersoaneInIntretinere();
		}
		#endregion

		#region CheckIfPersoanaIntretinereCanBeAdded
		/// <summary>
		/// Procedura verifica daca o persoana poate fi adaugata/modificata astfel incat sa nu se creeze duplicate 
		/// </summary>
		/// <param name="persoanaId">Id-ul persoanei pentru care se face verificarea</param>
		/// <param name="cnp">CNP-ul care se verifica sa nu mai existe deja</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		/// <remarks>
		/// Adaugat:	Oprescu Claudia
		/// Data:		08.02.2007
		/// </remarks>
		public bool CheckIfPersoanaIntretinereCanBeAdded(int persoanaId, long cnp)
		{
			Data.PersoaneInIntretinere pers=new Data.PersoaneInIntretinere(settings.ConnectionString);
			return pers.CheckIfPersoanaIntretinereCanBeAdded(persoanaId, cnp);
		}
		#endregion	
	}
}
