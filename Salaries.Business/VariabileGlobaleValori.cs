/*
 *	Modificat:		Oprescu Claudia 
 *	Data:			13.04.2006
 *	Descriere:		Clasa se ocupa cu gestiunea unei variabile globale
 */

using System;
using System.Data.SqlClient;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Administrarea variabilelor globale
	/// </summary>
	public class VariabileGlobaleValori
	{
		#region Atribute private
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		//Id-ul variabilei globale
		private int id;	
		//Id-ul tipului de variabila globala
		private int variabilaGlobalaID;
		//Id-ul lunii de care apartine variabila globala 
		private int lunaID;
		//Valoarea vaiabilei globale
		private float valoare;
		// Denumirea variabilei globale
		private string denumire;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public VariabileGlobaleValori()
		{
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Proprietati
		/// <summary>
		/// ID-ul variabilei globale.
		/// </summary>
		public int ID
		{
			get
			{
				return id;
			}
			set
			{
				id=value;
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
		/// ID-ul tipului de variabila globala.
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
		/// Id-ul lunii de care apartine variabila globala.
		/// </summary>
		public int LunaID
		{
			get
			{
				return lunaID;
			}
			set
			{
				lunaID=value;
			}
		}
		/// <summary>
		/// Valoarea variabilei globale.
		/// </summary>
		public float Valoare
		{
			get
			{
				return valoare;
			}
			set
			{
				valoare=value;
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
			Salaries.Data.VariabileGlobaleValori variabilaGlobala = new Salaries.Data.VariabileGlobaleValori(settings.ConnectionString);
			return variabilaGlobala.Insert(variabilaGlobalaID, lunaID, valoare);		
		}
		#endregion

		#region Update
		/// <summary>
		/// Actualizeaza o variabila globala
		/// </summary>
		public void Update()
		{
			Salaries.Data.VariabileGlobaleValori variabilaGlobala = new Salaries.Data.VariabileGlobaleValori(settings.ConnectionString);
			variabilaGlobala.Update(id, variabilaGlobalaID, lunaID, valoare);		
		}
		#endregion

		#region GetVariabileGlobaleValoriInfo
		/// <summary>
		/// Procedura obtine informatii despre o anumita variabila globala. Informatiile sunt luate din tabelele sal_VariabileGlobaleValori si sal_VariabileGlobaleTipuri
		/// </summary>
		/// <param name="id">id-ul variabilei despre care se obtin informatii</param>
		/// <returns>Se returneaza true daca variabila exista, false altfel</returns>
		public bool GetVariabileGlobaleValoriInfo(int id)
		{
			Salaries.Data.VariabileGlobaleValori variabilaGlobala = new Salaries.Data.VariabileGlobaleValori(settings.ConnectionString);
			DataSet dsVariabilaSalarizare = variabilaGlobala.GetVariabileGlobaleValoriInfo(id);	
			
			if(dsVariabilaSalarizare.Tables[0].Rows.Count > 0)
			{
				valoare = float.Parse(dsVariabilaSalarizare.Tables[0].Rows[0]["Valoare"].ToString());
				this.id = id;
				lunaID = int.Parse(dsVariabilaSalarizare.Tables[0].Rows[0]["LunaID"].ToString());
				variabilaGlobalaID = int.Parse(dsVariabilaSalarizare.Tables[0].Rows[0]["VariabilaGlobalaID"].ToString());
				denumire = dsVariabilaSalarizare.Tables[0].Rows[0]["Denumire"].ToString();
				
				return true;
			}
			else
			{
				return false;
			}
		}	
		#endregion

		#region GetAllVariabileGlobaleValoriPeLuna
		/// <summary>
		/// Procedura obtine informatii despre toate variabilele globale dintr-o anumita luna. 
		/// Sunt luate din tabelele sal_VariabileGlobaleValori si sal_VariabileGlobaleTipuri.
		/// </summary>
		/// <param name="lunaID">id-ul lunii pentru care sa obtin variabile</param>
		/// <returns>Se returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAllVariabileGlobaleValoriPeLuna(int lunaID)
		{
			Salaries.Data.VariabileGlobaleValori variabilaGlobala = new Salaries.Data.VariabileGlobaleValori(settings.ConnectionString);
			return variabilaGlobala.GetAllVariabileGlobaleValoriPeLuna(lunaID);	
		}
		#endregion

		#region GetLuniVariabileGlobale
		/// <summary>
		/// Procedura returneaza perechi formate din luna si an pentru acele luni pentru care exista valori de variabile globale
		/// </summary>
		/// <returns>Se returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetLuniVariabileGlobale()
		{
			Salaries.Data.VariabileGlobaleValori variabilaGlobala = new Salaries.Data.VariabileGlobaleValori(settings.ConnectionString);
			return variabilaGlobala.GetLuniVariabileGlobale();	
		}
		#endregion

		#region VerificaProcentInflatie
		/// <summary>
		/// Procedura verifica daca procentul de inflatie este negativ. Daca aceasta valoare este negativa nu se poate efectua inchiderea de luna
		/// </summary>
		/// <param name="lunaId">Luna pentru care se verifica valoarea procentului de inflatie</param>
		/// <returns>Returneaza true daca se poate face inchiderea de luna si false altfel</returns>
		/// <remarks>
		/// Autor:	Oprescu Claudia
		/// Data:	30.01.2007
		/// </remarks>
		public bool VerificaProcentInflatie(int lunaId)
		{
			Salaries.Data.VariabileGlobaleValori variabilaGlobala = new Salaries.Data.VariabileGlobaleValori(settings.ConnectionString);
			return variabilaGlobala.VerificaProcentInflatie(lunaId);
		}
		#endregion
	}
}
