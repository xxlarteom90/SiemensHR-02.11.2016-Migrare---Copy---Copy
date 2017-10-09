using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for IstoricSchimbareDateAngajat.
	/// </summary>
	public class IstoricSchimbareDateAngajat
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul intervalului
		private int intervalAngajatId;
		//Id-ul angajatului
		private long angajatId;
		//Data de inceput a modificarii
		private DateTime dataStart;
		//Data de sfarsit a modificarii
		private DateTime dataEnd;
		//Programul de lucru
		private int programLucru;
		//Salariul de baza
		private decimal salariuBaza;
		//Indemnizatie de conducere
		private decimal indemnizatieConducere;
		//Id-ul invaliditatii
		private int invaliditateId;
		//Textul pentru invaliditate
		private string invaliditateText;
		//Id-ul categoriei
		private int categorieId;
		//Textul categoriei
		private string categorieText;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructorul vid
		/// </summary>
		public IstoricSchimbareDateAngajat()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies
		/// <summary>
		/// ID-ul intervalului angajatului.
		/// </summary>
		public int IntervalAngajatId
		{
			get{ return intervalAngajatId; }
			set{ intervalAngajatId = value;}
		}
		/// <summary>
		/// ID-ul angajatului.
		/// </summary>
		public long AngajatId
		{
			get{ return angajatId; }
			set{ angajatId = value;}
		}
		/// <summary>
		/// Data de inceput a modificarii.
		/// </summary>
		public DateTime DataStart
		{
			get{ return dataStart; }
			set{ dataStart = value;}
		}
		/// <summary>
		/// Data de sfarsit a modificarii.
		/// </summary>
		public DateTime DataEnd
		{
			get{ return dataEnd; }
			set{ dataEnd = value;}
		}
		/// <summary>
		/// Programul de lucru.
		/// </summary>
		public int ProgramLucru
		{
			get{ return programLucru; }
			set{ programLucru = value;}
		}
		/// <summary>
		/// Salariul de baza.
		/// </summary>
		public decimal SalariuBaza
		{
			get{ return salariuBaza; }
			set{ salariuBaza = value;}
		}
		/// <summary>
		///Indemnizatia de conducere.
		/// </summary>
		public decimal IndemnizatieConducere
		{
			get{ return indemnizatieConducere; }
			set{ indemnizatieConducere = value;}
		}
		/// <summary>
		/// Id-ul invaliditatii.
		/// </summary>
		public int InvaliditateId
		{
			get{ return invaliditateId; }
			set{ invaliditateId = value;}
		}
		/// <summary>
		/// Textul pentru invaliditate.
		/// </summary>
		public string InvaliditateText
		{
			get{ return invaliditateText; }
			set{ invaliditateText = value;}
		}
		/// <summary>
		/// Id-ul categoriei.
		/// </summary>
		public int CategorieId
		{
			get{ return categorieId; }
			set{ categorieId = value;}
		}
		/// <summary>
		/// Textul pentru categorie.
		/// </summary>
		public string CategorieText
		{
			get{ return categorieText; }
			set{ categorieText = value;}
		}
		#endregion

		#region LoadIstoricSchimbari
		/// <summary>
		/// Procedura selectaza schimbarile unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet LoadIstoricSchimbari()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			return istSchimbare.LoadIstoricSchimbari(angajatId);
		}
		#endregion

		#region GetAllInvaliditati
		/// <summary>
		/// Procedura selecteaza toate tipurile de invaliditati
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetAllInvaliditati()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			return istSchimbare.GetAllInvaliditati();
		}
		#endregion

		#region InsertSchimbareProgramLucru
		/// <summary>
		/// Procedura adauga o schimbare pentru programul de lucru
		/// </summary>
		public void InsertSchimbareProgramLucru()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			istSchimbare.InsertSchimbareProgramLucru(angajatId, programLucru, dataStart, dataEnd);
		}
		#endregion

		#region InsertSchimbareSalariuBaza
		/// <summary>
		/// Procedura adauga o schimbare pentru salariul de baza
		/// </summary>
		public void InsertSchimbareSalariuBaza()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			istSchimbare.InsertSchimbareSalariuBaza(angajatId, salariuBaza, dataStart, dataEnd);
		}
		#endregion

		#region InsertSchimbareIndemnizatieConducere
		/// <summary>
		/// Procedura adauga o schimbare pentru indemnizatia de conducere
		/// </summary>
		public void InsertSchimbareIndemnizatieConducere()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			istSchimbare.InsertSchimbareIndemnizatieConducere(angajatId, indemnizatieConducere, dataStart, dataEnd);
		}
		#endregion

		#region InsertSchimbareInvaliditate
		/// <summary>
		/// Procedura adauga o schimbare pentru indemnizatia de conducere
		/// </summary>
		public void InsertSchimbareInvaliditate()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			istSchimbare.InsertSchimbareInvaliditate(angajatId, invaliditateId, dataStart, dataEnd);
		}
		#endregion

		#region InsertSchimbareCategorie
		/// <summary>
		/// Procedura adauga o schimbare pentru indemnizatia de conducere
		/// </summary>
		public void InsertSchimbareCategorie()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			istSchimbare.InsertSchimbareCategorie(angajatId, categorieId, dataStart, dataEnd);
		}
		#endregion

		#region InsertCapatIntervalSchimbareAngajat
		/// <summary>
		/// Procedura adauga un capat de interval
		/// </summary>
		public void InsertCapatIntervalSchimbareAngajat()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			istSchimbare.InsertCapatIntervalSchimbareAngajat(dataStart, dataEnd, angajatId, programLucru, salariuBaza, indemnizatieConducere, invaliditateId, categorieId);
		}
		#endregion

		#region UpdateCapatIntervalSchimbareAngajat
		/// <summary>
		/// Procedura actualizeaza un capat de interval
		/// </summary>
		public void UpdateCapatIntervalSchimbareAngajat()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			istSchimbare.UpdateCapatIntervalSchimbareAngajat(intervalAngajatId, dataStart, dataEnd, angajatId, programLucru, salariuBaza, indemnizatieConducere, invaliditateId, categorieId);
		}
		#endregion

		#region GetCategorieCorspunzatoareDinLunaActiva
		/// <summary>
		/// Returneaza id-ul categoriei
		/// </summary>
		/// <returns>Returneaza id-ul categoriei</returns>
		public int GetCategorieCorspunzatoareDinLunaActiva()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			return istSchimbare.GetCategorieCorspunzatoareDinLunaActiva(categorieId, angajatId);
		}
		#endregion

		#region GetCapatIntervalAngajatZi
		/// <summary>
		/// Procedura selecteaza capatul de interval pentru o data a unui angajat
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public DataSet GetCapatIntervalAngajatZi()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			return istSchimbare.GetCapatIntervalAngajatZi(dataStart, angajatId);
		}
		#endregion

		#region DeleteSchimbare
		/// <summary>
		/// Procedura sterge o schimbare
		/// </summary>
		public void DeleteSchimbare()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			istSchimbare.DeleteSchimbare(dataStart, dataEnd, angajatId);
		}
		#endregion

		#region GetPrevIntervalSchimbareByDataStart
		/// <summary>
		/// Procedura determina un interval al angajatului dupa data de start
		/// </summary>
		/// <returns>Returneaza un obiect IstoricSchimbareDateAngajat care contine aceste date</returns>
		public IstoricSchimbareDateAngajat GetPrevIntervalSchimbareByDataStart()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			DataRow dr = istSchimbare.GetPrevIntervalSchimbareByDataStart(dataStart, angajatId);
			
			IstoricSchimbareDateAngajat ints = new IstoricSchimbareDateAngajat();
			if (dr != null)
			{
				ints.DataStart = (DateTime)dr[ "DataStart" ];
				ints.DataEnd = (DateTime)dr[ "DataEnd" ];
				ints.AngajatId = angajatId;
				ints.ProgramLucru = int.Parse(dr[ "ProgramLucru" ].ToString());
				ints.SalariuBaza = decimal.Parse(dr[ "SalariuBaza" ].ToString());
				ints.IndemnizatieConducere = decimal.Parse(dr[ "IndemnizatieConducere" ].ToString());
				ints.InvaliditateId = int.Parse(dr[ "Invaliditate" ].ToString());
				ints.CategorieId = int.Parse(dr[ "CategorieID" ].ToString());
			}
			return ints;
		}
		#endregion

		#region GetIntervalSchimbareByDataInside
		/// <summary>
		/// Procedura determina un interval al angajatului dupa date din intrval
		/// </summary>
		/// <returns>Returneaza un obiect IstoricSchimbareDateAngajat care contine aceste date</returns>
		public IstoricSchimbareDateAngajat GetIntervalSchimbareByDataInside()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			DataRow dr = istSchimbare.GetIntervalSchimbareByDataInside(dataStart, angajatId);

			IstoricSchimbareDateAngajat ints = new IstoricSchimbareDateAngajat();
			if (dr != null)
			{
				ints.DataStart = (DateTime)dr[ "DataStart" ];
				ints.DataEnd = (DateTime)dr[ "DataEnd" ];
				ints.AngajatId = angajatId;
				ints.ProgramLucru = int.Parse( dr[ "ProgramLucru" ].ToString());
				ints.SalariuBaza = decimal.Parse( dr[ "SalariuBaza" ].ToString());
				ints.IndemnizatieConducere = decimal.Parse( dr[ "IndemnizatieConducere" ].ToString());
				ints.InvaliditateId = int.Parse( dr[ "Invaliditate" ].ToString());
				ints.CategorieId = int.Parse( dr[ "CategorieID" ].ToString());
			}
			return ints;
		}
		#endregion

		#region GetLastIntervalSchimbare
		/// <summary>
		/// Procedura selecteaza ultimul interval
		/// </summary>
		/// <returns>Returneaza un obiect IstoricSchimbareDateAngajat care contine aceste date</returns>
		public IstoricSchimbareDateAngajat GetLastIntervalSchimbare()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			DataRow dr = istSchimbare.GetLastIntervalSchimbare(angajatId);

			IstoricSchimbareDateAngajat ints = new IstoricSchimbareDateAngajat();
			if (dr != null)
			{
				ints.DataStart = (DateTime)dr[ "DataStart" ];
				ints.DataEnd = (DateTime)dr[ "DataEnd" ];
				ints.AngajatId = angajatId;
				ints.ProgramLucru = int.Parse( dr[ "ProgramLucru" ].ToString());
				ints.SalariuBaza = decimal.Parse( dr[ "SalariuBaza" ].ToString());
				ints.IndemnizatieConducere = decimal.Parse( dr[ "IndemnizatieConducere" ].ToString());
				ints.InvaliditateId = int.Parse( dr[ "Invaliditate" ].ToString());
				ints.CategorieId = int.Parse( dr[ "CategorieID" ].ToString());
			}
			return ints;
		}
		#endregion

		#region DataInLunaActiva
		/// <summary>
		/// Procedura verifica daca o data este in luna activa
		/// </summary>
		/// <returns>Returneaza true daca e in interval si false altfel</returns>
		public bool DataInLunaActiva()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			return istSchimbare.DataInLunaActiva(dataStart);
		}
		#endregion

		#region DataEsteZiSarbatoare
		/// <summary>
		/// Procedura verifica daca o anumita data este specificata ca si sarbatoare
		/// </summary>
		/// <returns>Returneaza true daca este sarbatoare si false altfel</returns>
		public bool DataEsteZiSarbatoare()
		{
			Salaries.Data.IstoricSchimbareDateAngajat istSchimbare = new Salaries.Data.IstoricSchimbareDateAngajat(settings.ConnectionString);
			return istSchimbare.DataEsteZiSarbatoare(dataStart);
		}
		#endregion
	}
}
