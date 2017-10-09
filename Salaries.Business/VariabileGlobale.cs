/*
 *	Modificat:		Oprescu Claudia 
 *	Data:			13.04.2006
 *	Descriere:		Clasa se ocupa cu gestiunea unei variabile globale
 */

using System;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace Salaries.Business
{
	/// <summary>
	/// Administrarea variabilelor globale
	/// </summary>
	public class VariabileGlobale
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul variabilei globale
		private int variabilaGlobalaID;	
		//Denumirea variabilei globale
		private string denumire;
		//Descrierea variabilei globale 
		private string descriere;
		//Codul vaiabilei globale
		private string cod;
		#endregion
		
		#region Format pentru date numerice
		//Variabila statica prin care se seteaza formatul pentru variabilele de tip numar
		public static NumberFormatInfo numberInfoFormatWithDigits = new CultureInfo("ro-RO", false).NumberFormat;
		public static NumberFormatInfo numberInfoFormatWithoutDigits = new CultureInfo("ro-RO", false).NumberFormat;
		#endregion
		
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public VariabileGlobale()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul variabilei globale.
		/// </summary>
		public int VariabilaGlobalaID
		{
			get
			{
				return variabilaGlobalaID;
			}
			set
			{
				variabilaGlobalaID=value;
			}
		}
		/// <summary>
		/// Denumirea variabilei globale.
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
		/// Descrierea variabilei globale.
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
		/// Codul variabilei globale.
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
		#endregion
		
		#region Insert
		/// <summary>
		/// Insereaza o variabila globala
		/// </summary>
		/// <returns>Id-ul variabilei globale nou adaugata</returns>
		public int Insert()
		{
			Salaries.Data.VariabileGlobale variabilaGlobala = new Salaries.Data.VariabileGlobale(settings.ConnectionString);
			return variabilaGlobala.Insert(denumire, descriere, cod);		
		}
		#endregion

		#region Update
		/// <summary>
		/// Actualizeaza o variabila globala
		/// </summary>
		public void Update()
		{
			Salaries.Data.VariabileGlobale variabilaGlobala = new Salaries.Data.VariabileGlobale(settings.ConnectionString);
			variabilaGlobala.Update(variabilaGlobalaID, denumire, descriere, cod);		
		}
		#endregion

		#region Delete
		/// <summary>
		/// Sterge variabila globala
		/// </summary>
		public void Delete()
		{
			Salaries.Data.VariabileGlobale variabilaGlobala = new Salaries.Data.VariabileGlobale(settings.ConnectionString);
			variabilaGlobala.Delete(variabilaGlobalaID);
		}
		#endregion
		
		#region GetVariabilaGlobalaInfo
		/// <summary>
		/// Informatii despre o variabila globala
		/// </summary>
		/// <param name="variabilaGlobalaID">Id-ul variabilei globale</param>
		/// <returns>Se returneaza un DataSet care contine toate detaiile despre o variabila globala</returns>
		public DataSet GetVariabilaGlobalaInfo(int variabilaGlobalaID)
		{
			Salaries.Data.VariabileGlobale variabilaGlobala = new Salaries.Data.VariabileGlobale(settings.ConnectionString);
			return variabilaGlobala.GetVaiabilaGlobalaInfo(variabilaGlobalaID);
		}
		#endregion

		#region GetAllVariabileGloale
		/// <summary>
		/// Sunt obtinute informatii despre toate tipurile de variabile globale
		/// </summary>
		/// <returns>Se returneaza un dataset care contine aceste valori</returns>
		public DataSet GetAllVariabileGloale()
		{
			Salaries.Data.VariabileGlobale variabilaGlobala = new Salaries.Data.VariabileGlobale(settings.ConnectionString);
			return variabilaGlobala.GetAllVariabileGlobale();	
		}
		#endregion

		#region GetAllVariabileGlobaleNeadaugate
		/// <summary>
		/// Se obtin informatii despre toate tipurile da variabile care nu au fost adaugate pentur luna curenta
		/// </summary>
		/// <param name="lunaID">Id-ul lunii pentru care se adauga</param>
		/// <returns>Se returneaza un DataSet care contine toate detaiile despre o variabila globala</returns>
		public DataSet GetAllVariabileGlobaleNeadaugate(int lunaID)
		{
			Salaries.Data.VariabileGlobale variabilaGlobala = new Salaries.Data.VariabileGlobale(settings.ConnectionString);
			return variabilaGlobala.GetAllVariabileGlobaleNeadaugate(lunaID);
		}
		#endregion

		#region CheckIfTipVariabilaGlobalaCanBeDeleted
		/// <summary>
		/// Verifica daca se poate sterge variabila globala reprezentata de obiectul apelant. Pentru aceasta, creeaza
		/// un obiect de tip Salaries.Data.VariabileGlobale si ii apeleaza metoda CheckIfTipVariabilaGlobalaCanBeDeleted(variabilaGlobalaID),
		/// returnand rezultatul intors de aceasta.
		/// Vezi descrierea metodei CheckIfTipVariabilaGlobalaCanBeDeleted(variabilaGlobalaID), din clasa Salaries.Data.VariabileGlobale.
		/// </summary>
		/// <returns> Returneaza rezultatul verificarii stergerii
		///	0 - se poate sterge
		///	1 - exista date asociate
		///	2 - tipul de variabila este ultimul din lista
		///	</returns>
		public int CheckIfTipVariabilaGlobalaCanBeDeleted() 
		{
			Salaries.Data.VariabileGlobale variabilaGlobala = new Salaries.Data.VariabileGlobale(settings.ConnectionString);
			return variabilaGlobala.CheckIfTipVariabilaGlobalaCanBeDeleted(variabilaGlobalaID);	
		}
		#endregion

		#region GetProcentSanatateAngajat
		/// <summary>
		/// Este obtinuta valoarea procentului din baza de calcul a contributiei individuale de asigurari de sanatate.
		/// </summary>
		/// <param name="lunaID"> ID-ul lunii pentru care se doreste valoarea procentului.</param>
		/// <returns> Valoarea procentului din baza de calcul a contributiei individuale de asigurari de sanatate.</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  09.05.2006
		/// </remarks>
		public float GetProcentSanatateAngajat(int lunaID)
		{
			Salaries.Data.VariabileGlobale variabilaGlobala = new Salaries.Data.VariabileGlobale(settings.ConnectionString);

			return variabilaGlobala.GetProcentSanatateAngajat(lunaID);
		}
		#endregion

		#region GetProcentSanatateAgajator
		/// <summary>
		/// Este obtinut valoarea procentului din baza de calcul a contributieide sanatate a angajatorului.
		/// </summary>
		/// <param name="lunaID"> ID-ul lunii pentru care se doreste valoarea procentului.</param>
		/// <returns> Valoarea procentului din baza de calcul a contributieide sanatate a angajatorului..</returns>
		/// <remarks>
		/// Autor: Cristina Raluca Muntean
		/// Data:  09.05.2006
		/// </remarks>
		public float GetProcentSanatateAgajator(int lunaID)
		{
			Salaries.Data.VariabileGlobale variabilaGlobala = new Salaries.Data.VariabileGlobale(settings.ConnectionString);

			return variabilaGlobala.GetProcentSanatateAgajator(lunaID);
		}
		#endregion

		#region CheckIfTipVariabilaGlobalaCanBeAdded
		/// <summary>
		/// Procedura verifica sa nu se adauge duplicate in tabela sal_VariabileGlobaleTipuri
		/// </summary>
		/// <param name="variabilaGlobalaID">Id-ul variabilei care nu trebuie sa coincida</param>
		/// <param name="denumire">Denumirea tipului de variabila</param>
		/// <param name="cod">Codul pentru tipul de variabila</param>
		/// <returns>Returneaza true daca se poate face adaugare/modificare si false altfel</returns>
		public bool CheckIfTipVariabilaGlobalaCanBeAdded() 
		{
			Salaries.Data.VariabileGlobale variabilaGlobala = new Salaries.Data.VariabileGlobale(settings.ConnectionString);
			return variabilaGlobala.CheckIfTipVariabilaGlobalaCanBeAdded(variabilaGlobalaID, denumire, cod);	
		}
		#endregion
	}
}
