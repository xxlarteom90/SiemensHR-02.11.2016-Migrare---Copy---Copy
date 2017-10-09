/*
 * Component..........: Angajat class
 * FileName...........: Angajat.cs
 * Author.............: Puiu Moarcas, PSE BS TH; PSE Siemens RO
 * Creation Date......: 29/04/2004
 * Notes..............: This class is used to retrive and set data into the database, for an employee
 * 
 * */

//Modificat: Oprescu Claudia
//Descriere: s-a modificat tipul atributului pentru numar de pasaport si buletin de la int la string pentru a contine si litere
//			 s-a modificat tipul proprietatilor care returneaza aceste valori pentru a corespunde cu tipul atributelor
//			 s-a adaugat un parametru pentru punctul de lucru
//			 s-a adaugat un parametru pentru casa de asigurari

using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;
using SiemensHR.utils;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for Angajat.
	/// </summary>
	public class Angajat
	{
		//declare private variables 
#region Variables for Angajati table		
		// from Angajati table
		private long m_AngajatID;
		private int m_AngajatorID;
		private int m_PunctLucruID;
		private int m_CasaDeAsigurariID;
		private string m_Marca;
		private string m_Nume;
		private string m_Prenume;
		private string m_NumeAnterior;
		private int m_TitluID;
		private string m_TitluSimbol;
		private string m_TitluDenumire;
		private string m_PrenumeTata;
		private string m_PrenumeMama;
		private int m_StudiuID;
		private string m_AnAbsolvire;
		private string m_NrDiploma;
		private string m_Descriere;
		private byte m_ModIncadrare;
		private byte m_ProgramLucru;
		private string m_Telefon;
		private DateTime m_DataNasterii;
		private int m_JudetNastereID;
		private int m_TaraNastereID;
		private string m_LocalitateNastere;
		private byte m_StareCivila;
		private byte m_NrCopii;
		private string m_Sex;
		//private string m_Nationalitate;
		private int m_Nationalitate;
		private long m_CNP;
		private long m_CNPAnterior;
		private byte m_TipFisaFiscala;
		private byte m_AniVechimeMunca;
		private byte m_LuniVechimeMunca;
		private int m_ZileVechimeMunca;
		private byte m_AreCardBancar;
		private byte[] m_PozaAngajat;
		private int m_FunctieCurentaID;
		private string m_FunctieCurentaNume;
		private string m_FunctieCurentaCod;
		private int m_DepartamentCurentID;
		private string m_DepartamentCurentDenumire;
		private string m_DepartamentCurentCod;
		private long m_SefID;
		private string m_NumeAngajator;
		private int m_CentruCostID;
		private string m_NumeCentruCost;
		private int m_CentruCostCod;
		private SituatieMilitaraInfo m_infoSituatieMilitara;
		private bool m_PerioadaDeterminata;
		private System.DateTime m_DataPanaLa;
		private System.DateTime m_DataDeLa;
		private string m_NrContractMunca;
		private System.DateTime m_DataInregContractMunca;
		private string m_EchIndProtectie;
		private string m_EchIndLucru;
		private string m_MatIgiSan;
		private string m_AlimProtectie;
		private string m_AlteDrSiObl;
		private string m_AlteClauzeCIM;
		private string m_PerProba;
		private short m_Invaliditate;
		private decimal m_SalariuBaza;
		private decimal m_IndemnizatieConducere;
		private decimal m_Sporuri;
		private decimal m_AlteAdaosuri;
		private decimal m_SumaMajorare;
		private DateTime m_DataMajorare;
		private int m_NrZileCOAn;
		private int m_NrZileCOSupl;
		private int m_CategorieID;
		private string m_Email;
		private string m_TelMunca;
		private bool m_isLichidat;
		private bool m_isPensionat;
		private DateTime m_DataLichidare;
		
#endregion

#region Variables for CartiIdentitate table
		// from CartiIdentitate table
		private string m_CISerie;
		private string m_CINumar;
		private string m_CIEliberatDe;
		private DateTime m_CIDataEliberarii;
		private DateTime m_CIValabilPanaLa;
#endregion

#region Variable for Pasapoarte table
		// from Pasapoarte table
		private string m_PASSerie;
		private string m_PASNumar;
		private string m_PASEliberatDe;
		private DateTime m_PASDataEliberarii;
		private DateTime m_PASValabilPanaLa;
		private DateTime m_PermMuncaEliberat;
		private DateTime m_PermMuncaExpira;
		private DateTime m_PermSedereEliberat;
		private DateTime m_PermSedereExpira;
		//private long m_NrPermisMunca;
#endregion

#region Variable for PermiseMunca table
		private DateTime m_PermisMuncaDataEliberare;
		private DateTime m_PermisMuncaDataExpirare;
		private string m_SeriePermisMunca;
		private long m_NrPermisMunca;
#endregion

#region Variable for LegitimatiiSedere table
		private DateTime m_LegitimatieSedereDataEliberare;
		private DateTime m_LegitimatieSedereDataExpirare;
		private string m_SerieLegitimatieSedere;
		private string m_NrLegitimatieSedere;
#endregion

#region Variable for NIF table
		private string m_NIF;
		private int m_tipNationalitateDomiciliu;
#endregion

#region Variables for Domicilii table
		// from Domicilii table - 
		// D = domiciliu
		private int m_DTara;
		private string m_DLocalitate;
		private int m_DJudetSectorID;
		private string m_DStrada;
		private string m_DNumar;
		private string m_DCodPostal;
		private string m_DBloc;
		private string m_DScara;
		private string m_DEtaj;
		private string m_DApartament;
		// R = resedinta
		private int m_RTara;
		private string m_RLocalitate;
		private int m_RJudetSectorID;
		private string m_RStrada;
		private string m_RNumar;
		private string m_RCodPostal;
		private string m_RBloc;
		private string m_RScara;
		private string m_REtaj;
		private string m_RApartament;
#endregion

#region Variables for CarneteMunca table

		private string m_CMSerie;
		private string m_CMNumar;
		private string m_CMEmitent;
		private DateTime m_CMDataEmiterii;
		private string m_CMNrInregITM;

#endregion

#region Variables for Alerte Speciale

		private string m_AlerteSpeciale;

#endregion

		// Controls access to class-level variables.
#region Set/Get properties for fields from Angajati table
		// retriving and setting m_AngajatID private variable
		public long AngajatID
		{
			get
			{
				return m_AngajatID;
			}
			set
			{
				m_AngajatID = value;
			}
		}

		public int PunctLucruID
		{
			get
			{
				return m_PunctLucruID;
			}
			set
			{
				m_PunctLucruID = value;
			}
		}

		public int CasaDeAsigurariID
		{
			get
			{
				return m_CasaDeAsigurariID;
			}
			set
			{
				m_CasaDeAsigurariID = value;
			}
		}


		public int CentruCostID
		{
			get
			{
				return m_CentruCostID;
			}
			set
			{
				m_CentruCostID = value;
			}
		}

		public string NumeCentruCost
		{
			get
			{
				return m_NumeCentruCost;
			}
			set
			{
				m_NumeCentruCost = value;
			}
		}

		public int CentruCostCod
		{
			get
			{
				return m_CentruCostCod;
			}
			set
			{
				m_CentruCostCod = value;
			}
		}

		public string NumeAngajator
		{
			get
			{
				return m_NumeAngajator;
			}
			set
			{
				m_NumeAngajator = value;
			}
		}

		// retriving and setting m_AngajatorID private variable
		public int AngajatorID
		{
			get
			{
				return m_AngajatorID;
			}
			set
			{
				m_AngajatorID = value;
			}
		}
		
		// retriving and setting m_Marca private variable
		public string Marca
		{
			get
			{
				return m_Marca;
			}
			set
			{
				m_Marca = value;
			}
		}

		// retriving and setting m_Nume private variable
		public string Nume
		{
			get
			{
				return m_Nume;
			}
			set
			{
				m_Nume = value;
			}
		}

		// retriving and setting m_Prenume private variable
		public string Prenume
		{
			get
			{
				return m_Prenume;
			}
			set
			{
				m_Prenume = value;
			}
		}

		public string NumeAnterior
		{
			get
			{
				return m_NumeAnterior;
			}
			set
			{
				m_NumeAnterior = value;
			}
		}

		// retriving and setting m_TitluID private variable
		public int TitluID
		{
			get
			{
				return m_TitluID;
			}
			set
			{
				m_TitluID = value;
			}
		}

		// retriving and setting m_TitluSimbol private variable
		public string TitluSimbol
		{
			get
			{
				return m_TitluSimbol;
			}
			set
			{
				m_TitluSimbol = value;
			}
		}

		// retriving and setting m_TitluDenumire private variable
		public string TitluDenumire
		{
			get
			{
				return m_TitluDenumire;
			}
			set
			{
				m_TitluDenumire = value;
			}
		}

		// retriving and setting m_PrenumeMama private variable
		public string PrenumeMama
		{
			get
			{
				return m_PrenumeMama;
			}
			set
			{
				m_PrenumeMama = value;
			}
		}

		// retriving and setting m_PrenumeTata private variable
		public string PrenumeTata
		{
			get
			{
				return m_PrenumeTata;
			}
			set
			{
				m_PrenumeTata = value;
			}
		}

		// retriving and setting m_StudiuID private variable
		public int StudiuID
		{
			get
			{
				return m_StudiuID;
			}
			set
			{
				m_StudiuID = value;
			}
		}

		// retriving and setting m_AnAbsolvire private variable
		public string AnAbsolvire
		{
			get
			{
				return m_AnAbsolvire;
			}
			set
			{
				m_AnAbsolvire = value;
			}
		}

		// retriving and setting m_NrDiploma private variable
		public string NrDiploma
		{
			get
			{
				return m_NrDiploma;
			}
			set
			{
				m_NrDiploma = value;
			}
		}

		// retriving and setting m_Descriere private variable
		public string Descriere
		{
			get
			{
				return m_Descriere;
			}
			set
			{
				m_Descriere = value;
			}
		}

		// retriving and setting m_ModIncadrare private variable
		public byte ModIncadrare
		{
			get
			{
				return m_ModIncadrare;
			}
			set
			{
				m_ModIncadrare = value;
			}
		}

		// retriving and setting m_ProgramLucru private variable
		public byte ProgramLucru
		{
			get
			{
				return m_ProgramLucru;
			}
			set
			{
				m_ProgramLucru = value;
			}
		}
		
		// retriving and setting m_Telefon private variable
		public string Telefon
		{
			get
			{
				return m_Telefon;
			}
			set
			{
				m_Telefon = value;
			}
		}

		// retriving and setting m_DataNasterii private variable
		public DateTime DataNasterii
		{
			get
			{
				return m_DataNasterii;
			}
			set
			{
				m_DataNasterii = value;
			}
		}
		// retriving and setting m_JudetNastereID private variable
		public int JudetNastereID
		{
			get
			{
				return m_JudetNastereID;
			}
			set
			{
				m_JudetNastereID = value;
			}
		}
		// retriving and setting m_TaraNastereID private variable
		public int TaraNastereID
		{
			get
			{
				return m_TaraNastereID;
			}
			set
			{
				m_TaraNastereID = value;
			}
		}
		// retriving and setting m_LocalitateNastere private variable
		public string LocalitateNastere
		{
			get
			{
				return m_LocalitateNastere;
			}
			set
			{
				m_LocalitateNastere = value;
			}
		}

		// retriving and setting m_StareCivila private variable
		public byte StareCivila
		{
			get
			{
				return m_StareCivila;
			}
			set
			{
				m_StareCivila = value;
			}
		}
		// retriving and setting m_NrCopii private variable
		public byte NrCopii
		{
			get
			{
				return m_NrCopii;
			}
			set
			{
				m_NrCopii = value;
			}
		}

		// retriving and setting m_Sex private variable
		public string Sex
		{
			get
			{
				return m_Sex;
			}
			set
			{
				m_Sex = value;
			}
		}
		// retriving and setting m_Nationalitate private variable
		public int Nationalitate
		{
			get
			{
				return m_Nationalitate;
			}
			set
			{
				m_Nationalitate = value;
			}
		}
		// retriving and setting m_CNP private variable
		public long CNP
		{
			get
			{
				return m_CNP;
			}
			set
			{
				m_CNP = value;
			}
		}

		public long CNPAnterior
		{
			get
			{
				return m_CNPAnterior;
			}
			set 
			{
				m_CNPAnterior = value;
			}
		}

		// retriving and setting m_TipFisaFiscala private variable
		public byte TipFisaFiscala
		{
			get
			{
				return m_TipFisaFiscala;
			}
			set
			{
				m_TipFisaFiscala = value;
			}
		}

		// retriving and setting m_AniVechimeMunca private variable
		public byte AniVechimeMunca
		{
			get
			{
				return m_AniVechimeMunca;
			}
			set
			{
				m_AniVechimeMunca = value;
			}
		}
		// retriving and setting m_LuniVechimeMunca private variable
		public byte LuniVechimeMunca
		{
			get
			{
				return m_LuniVechimeMunca;
			}
			set
			{
				m_LuniVechimeMunca = value;
			}
		}
		// retriving and setting m_ZileVechimeMunca private variable
		public int ZileVechimeMunca
		{
			get
			{
				return m_ZileVechimeMunca;
			}
			set
			{
				m_ZileVechimeMunca = value;
			}
		}

		// retriving and setting m_AreCardBancar private variable
		public byte AreCardBancar
		{
			get
			{
				return m_AreCardBancar;
			}
			set
			{
				m_AreCardBancar = value;
			}
		}

		// retriving and setting m_PozaFileName private variable
		public byte[] PozaAngajat
		{
			get
			{
				return m_PozaAngajat;
			}
			set
			{
				m_PozaAngajat = value;
			}
		}

		// retriving and setting m_FunctieCurentaID private variable
		public int FunctieCurentaID
		{
			get
			{
				return m_FunctieCurentaID;
			}
			set
			{
				m_FunctieCurentaID = value;
			}
		}
	
		// retriving and setting m_FunctieCurentaNume private variable
		public string FunctieCurentaNume
		{
			get
			{
				return m_FunctieCurentaNume;
			}
			set
			{
				m_FunctieCurentaNume = value;
			}
		}
		// retriving and setting m_FunctieCurentaCod private variable
		public string FunctieCurentaCod
		{
			get
			{
				return m_FunctieCurentaCod;
			}
			set
			{
				m_FunctieCurentaCod = value;
			}
		}

		// retriving and setting m_DepartamentCurentID private variable
		public int DepartamentCurentID
		{
			get
			{
				return m_DepartamentCurentID;
			}
			set
			{
				m_DepartamentCurentID = value;
			}
		}
		// retriving and setting m_DepartamentCurentDenumire private variable
		public string DepartamentCurentDenumire
		{
			get
			{
				return m_DepartamentCurentDenumire;
			}
			set
			{
				m_DepartamentCurentDenumire = value;
			}
		}
		// retriving and setting m_DepartamentCurentCod private variable
		public string DepartamentCurentCod
		{
			get
			{
				return m_DepartamentCurentCod;
			}
			set
			{
				m_DepartamentCurentCod = value;
			}
		}

		public bool PerioadaDeterminata
		{
			get{ return m_PerioadaDeterminata;}
			set{ m_PerioadaDeterminata=value; }
		}

		public DateTime DataPanaLa
		{
			get{return m_DataPanaLa; }
			set{m_DataPanaLa=value;}
		}

		public DateTime DataDeLa
		{
			get{return m_DataDeLa; }
			set{m_DataDeLa=value;}
		}

		public DateTime DataInregContractMunca
		{
			get{return m_DataInregContractMunca; }
			set{m_DataInregContractMunca=value;}
		}

		public string NrContractMunca
		{
			get{return m_NrContractMunca; }
			set{m_NrContractMunca=value;}
		
		}
		//echipament individual de protectie
		public string EchIndProtectie
		{
			get{return m_EchIndProtectie; }
			set{m_EchIndProtectie=value;}
		
		}
		//echipament individual de lucru
		public string EchIndLucru
		{
			get{return m_EchIndLucru; }
			set{m_EchIndLucru=value;}
		
		}
		//materiale igienico sanitare
		public string MatIgiSan
		{
			get{return m_MatIgiSan; }
			set{m_MatIgiSan=value;}
		
		}
		//alimentatie de protectie
		public string AlimProtectie
		{
			get{return m_AlimProtectie; }
			set{m_AlimProtectie=value;}
		
		}
		
		//alte drepturi si obligatii privind sanatatea in munca
		public string AlteDrSiObl
		{
			get{return m_AlteDrSiObl; }
			set{m_AlteDrSiObl=value;}
		
		}

		//alte clauze ale contactului individual de munca
		public string AlteClauzeCIM
		{
			get{return m_AlteClauzeCIM; }
			set{m_AlteClauzeCIM=value;}
		
		}

		//perioada de proba
		public string PerProba
		{
			get{return m_PerProba; }
			set{m_PerProba=value;}
		
		}

		// retriving and setting m_SefID private variable
		public long SefID
		{
			get
			{
				return m_SefID;
			}
			set
			{
				m_SefID = value;
			}
		}
		// retriving and setting m_infoSituatieMilitara private variable
		public SituatieMilitaraInfo InfoSituatieMilitara
		{
			get
			{
				return m_infoSituatieMilitara;
			}
			set
			{
				m_infoSituatieMilitara = value;
			}
		}

		public short Invaliditate
		{
			get{return m_Invaliditate;}
			set{m_Invaliditate=value;}
		}

		public decimal SalariuBaza
		{
			get{return m_SalariuBaza;}
			set{m_SalariuBaza=value;}
		}

		public decimal IndemnizatieConducere
		{
			get{return m_IndemnizatieConducere;}
			set{m_IndemnizatieConducere=value;}
		}
		
		//sporuri
		public decimal Sporuri
		{
			get{return m_Sporuri;}
			set{m_Sporuri=value;}
		}

		//alte adaosuri
		public decimal AlteAdaosuri
		{
			get{return m_AlteAdaosuri;}
			set{m_AlteAdaosuri=value;}
		}
		public decimal SumaMajorare
		{
			get{return m_SumaMajorare;}
			set{m_SumaMajorare=value;}
		}
        
		public DateTime DataMajorare
		{
			get{return m_DataMajorare;}
			set{m_DataMajorare=value;}
		}

		public int NrZileCOAn
		{
			get{return m_NrZileCOAn;}
			set{m_NrZileCOAn=value;}
		}

		//numarul de zile de concediu de odihna suplimentar(pe an)
		public int NrZileCOSupl
		{
			get{return m_NrZileCOSupl;}
			set{m_NrZileCOSupl=value;}
		}

		public int CategorieID
		{
			get{return m_CategorieID;}
			set{m_CategorieID=value;}
		}
		public string Email
		{
			get
			{
				return m_Email;
			}
			set
			{
				m_Email = value;
			}
		}
		public string TelMunca
		{
			get
			{
				return m_TelMunca;
			}
			set
			{
				m_TelMunca = value;
			}
		}
		
		public bool isLichidat
		{
			get
			{
				return m_isLichidat;
			}
			set
			{
				m_isLichidat = value;
			}
		}

		public bool isPensionat
		{
			get
			{
				return m_isPensionat;
			}
			set
			{
				m_isPensionat = value;
			}
		}



		#endregion

#region Set/Get properties for fields from CartiIndentitate table
		// retriving and setting m_Serie private variable
		public string CISerie
		{
			get
			{
				return m_CISerie;
			}
			set
			{
				m_CISerie = value;
			}
		}
		// retriving and setting m_Numar private variable
		public string CINumar
		{
			get
			{
				return m_CINumar;
			}
			set
			{
				m_CINumar = value;
			}
		}
		// retriving and setting m_EliberatDe private variable
		public string CIEliberatDe
		{
			get
			{
				return m_CIEliberatDe;
			}
			set
			{
				m_CIEliberatDe = value;
			}
		}
		// retriving and setting m_DataEliberarii private variable
		public DateTime CIDataEliberarii
		{
			get
			{
				return m_CIDataEliberarii;
			}
			set
			{
				m_CIDataEliberarii = value;
			}
		}
		// retriving and setting m_ValabilPanaLa private variable
		public DateTime CIValabilPanaLa
		{
			get
			{
				return m_CIValabilPanaLa;
			}
			set
			{
				m_CIValabilPanaLa = value;
			}
		}
#endregion

#region Set/Get properties for fields from Pasapoarte table
		// retriving and setting m_Serie private variable
		public string PASSerie
		{
			get
			{
				return m_PASSerie;
			}
			set
			{
				m_PASSerie = value;
			}
		}
		// retriving and setting m_Numar private variable
		public string PASNumar
		{
			get
			{
				return m_PASNumar;
			}
			set
			{
				m_PASNumar = value;
			}
		}
		// retriving and setting m_EliberatDe private variable
		public string PASEliberatDe
		{
			get
			{
				return m_PASEliberatDe;
			}
			set
			{
				m_PASEliberatDe = value;
			}
		}
		// retriving and setting m_DataEliberarii private variable
		public DateTime PASDataEliberarii
		{
			get
			{
				return m_PASDataEliberarii;
			}
			set
			{
				m_PASDataEliberarii = value;
			}
		}
		// retriving and setting m_ValabilPanaLa private variable
		public DateTime PASValabilPanaLa
		{
			get
			{
				return m_PASValabilPanaLa;
			}
			set
			{
				m_PASValabilPanaLa = value;
			}
		}
		public DateTime PermMuncaExpira
		{
			get
			{
				return m_PermMuncaExpira;
			}
			set
			{
				m_PermMuncaExpira=value;
			}
		}
		public DateTime PermMuncaEliberat
		{
			get
			{
				return m_PermMuncaEliberat;
			}
			set
			{
				m_PermMuncaEliberat=value;
			}
		}
		public DateTime PermSedereEliberat
		{
			get
			{
				return m_PermSedereEliberat;
			}
			set
			{
				m_PermSedereEliberat=value;
			}
		}
		public DateTime PermSedereExpira
		{
			get
			{
				return m_PermSedereExpira;
			}
			set
			{
				m_PermSedereExpira=value;
			}
		}
		/*public long NrPermisMunca
		{
			get
			{
				return m_NrPermisMunca;
			}
			set
			{
				m_NrPermisMunca=value;
			}
		}*/
		#endregion

#region Set/Get properties for fields from PermiseMunca

		public DateTime PermisMuncaDataExpirare
		{
			get
			{
				return m_PermisMuncaDataExpirare;
			}
			set
			{
				m_PermisMuncaDataExpirare=value;
			}
		}

		public DateTime PermisMuncaDataEliberare
		{
			get
			{
				return m_PermisMuncaDataEliberare;
			}
			set
			{
				m_PermisMuncaDataEliberare=value;
			}
		}

		public string SeriePermisMunca
		{
			get
			{
				return m_SeriePermisMunca;
			}
			set
			{
				m_SeriePermisMunca = value;
			}
		}
		
		public long NrPermisMunca
		{
			get
			{
				return m_NrPermisMunca;
			}
			set
			{
				m_NrPermisMunca = value;
			}
		}
#endregion

#region Set/Get properties for fields from LegitimatiiSedere

		public DateTime LegitimatieSedereDataExpirare
		{
			get
			{
				return m_LegitimatieSedereDataExpirare;
			}
			set
			{
				m_LegitimatieSedereDataExpirare=value;
			}
		}

		public DateTime LegitimatieSedereDataEliberare
		{
			get
			{
				return m_LegitimatieSedereDataEliberare;
			}
			set
			{
				m_LegitimatieSedereDataEliberare=value;
			}
		}

		public string SerieLegitimatieSedere
		{
			get
			{
				return m_SerieLegitimatieSedere;
			}
			set
			{
				m_SerieLegitimatieSedere = value;
			}
		}
		
		public string NrLegitimatieSedere
		{
			get
			{
				return m_NrLegitimatieSedere;
			}
			set
			{
				m_NrLegitimatieSedere = value;
			}
		}
#endregion

#region Set/Get properties for fields from NIF
		public string NIF
		{
			get
			{
				return m_NIF;
			}
			set
			{
				m_NIF = value;
			}
		}

		public int TipNationalitateDomiciliu
		{
			get
			{
				return m_tipNationalitateDomiciliu;
			}
			set
			{
				m_tipNationalitateDomiciliu = value;
			}
		}
#endregion

#region Set/Get properties for fields from Alerte Speciale
		public string AlerteSpeciale
		{
			get
			{
				return m_AlerteSpeciale;
			}
			set
			{
					m_AlerteSpeciale = value;
			}
		}
#endregion

#region Set/Get properties for fields from Domicilii table
		// retriving and setting m_DTara private variable
		public int DTara
		{
			get
			{
				return m_DTara;
			}
			set
			{
				m_DTara = value;
			}
		}
		// retriving and setting m_DLocalitate private variable
		public string DLocalitate
		{
			get
			{
				return m_DLocalitate;
			}
			set
			{
				m_DLocalitate = value;
			}
		}
		// retriving and setting m_DJudetSectorID private variable
		public int DJudetSectorID
		{
			get
			{
				return m_DJudetSectorID;
			}
			set
			{
				m_DJudetSectorID = value;
			}
		}
		// retriving and setting m_DStrada private variable
		public string DStrada
		{
			get
			{
				return m_DStrada;
			}
			set
			{
				m_DStrada = value;
			}
		}
		// retriving and setting m_DNumar private variable
		public string DNumar
		{
			get
			{
				return m_DNumar;
			}
			set
			{
				m_DNumar = value;
			}
		}
		// retriving and setting m_DCodPostal private variable
		public string DCodPostal
		{
			get
			{
				return m_DCodPostal;
			}
			set
			{
				m_DCodPostal = value;
			}
		}
		// retriving and setting m_DBloc private variable
		public string DBloc
		{
			get
			{
				return m_DBloc;
			}
			set
			{
				m_DBloc = value;
			}
		}
		// retriving and setting m_DScara private variable
		public string DScara
		{
			get
			{
				return m_DScara;
			}
			set
			{
				m_DScara = value;
			}
		}
		// retriving and setting m_DEtaj private variable
		public string DEtaj
		{
			get
			{
				return m_DEtaj;
			}
			set
			{
				m_DEtaj = value;
			}
		}
		// retriving and setting m_DApartament private variable
		public string DApartament
		{
			get
			{
				return m_DApartament;
			}
			set
			{
				m_DApartament = value;
			}
		}

		// retriving and setting m_RTara private variable
		public int RTara
		{
			get
			{
				return m_RTara;
			}
			set
			{
				m_RTara = value;
			}
		}

		// retriving and setting m_RLocalitate private variable
		public string RLocalitate
		{
			get
			{
				return m_RLocalitate;
			}
			set
			{
				m_RLocalitate = value;
			}
		}
		// retriving and setting m_RJudetSectorID private variable
		public int RJudetSectorID
		{
			get
			{
				return m_RJudetSectorID;
			}
			set
			{
				m_RJudetSectorID = value;
			}
		}
		// retriving and setting m_RStrada private variable
		public string RStrada
		{
			get
			{
				return m_RStrada;
			}
			set
			{
				m_RStrada = value;
			}
		}
		// retriving and setting m_RNumar private variable
		public string RNumar
		{
			get
			{
				return m_RNumar;
			}
			set
			{
				m_RNumar = value;
			}
		}
		// retriving and setting m_RCodPostal private variable
		public string RCodPostal
		{
			get
			{
				return m_RCodPostal;
			}
			set
			{
				m_RCodPostal = value;
			}
		}
		// retriving and setting m_RBloc private variable
		public string RBloc
		{
			get
			{
				return m_RBloc;
			}
			set
			{
				m_RBloc = value;
			}
		}
		// retriving and setting m_RScara private variable
		public string RScara
		{
			get
			{
				return m_RScara;
			}
			set
			{
				m_RScara = value;
			}
		}
		// retriving and setting m_REtaj private variable
		public string REtaj
		{
			get
			{
				return m_REtaj;
			}
			set
			{
				m_REtaj = value;
			}
		}
		// retriving and setting m_RApartament private variable
		public string RApartament
		{
			get
			{
				return m_RApartament;
			}
			set
			{
				m_RApartament = value;
			}
		}

#endregion

#region Set/Get properties for fields from CarneteMunca table
		// retriving and setting m_CMSerie private variable
		public string CMSerie
		{
			get
			{
				return m_CMSerie;
			}
			set
			{
				m_CMSerie = value;
			}
		}
		// retriving and setting m_CMNumar private variable
		public string CMNumar
		{
			get
			{
				return m_CMNumar;
			}
			set
			{
				m_CMNumar = value;
			}
		}
		// retriving and setting m_CMEmitent private variable
		public string CMEmitent
		{
			get
			{
				return m_CMEmitent;
			}
			set
			{
				m_CMEmitent = value;
			}
		}
		// retriving and setting m_CMDataEmiterii private variable
		public DateTime CMDataEmiterii
		{
			get
			{
				return m_CMDataEmiterii;
			}
			set
			{
				m_CMDataEmiterii = value;
			}
		}
		// retriving and setting m_CMDataInregITMprivate variable
		public string CMNrInregITM
		{
			get
			{
				return m_CMNrInregITM;
			}
			set
			{
				m_CMNrInregITM = value;
			}
		}
		#endregion

#region Set/Get properties for fields from Domicilii table
		// retriving and setting m_DTara private variable
		public DateTime DataLichidare
		{
			get
			{
				return m_DataLichidare;
			}
			set
			{
				m_DataLichidare = value;
			}
		}
#endregion

		private SqlConnection m_con;
		protected Salaries.Configuration.ModuleSettings settings;

		public Angajat()
		{
			//
			// TODO: Add constructor logic here
			//
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			m_con = new SqlConnection(settings.ConnectionString);

		}
		//Adaugat:	Alex Ciobanu
		//Data:		14.09.2005
		public Angajat(Salaries.Configuration.ModuleSettings st)
		{
			settings=st;
			m_con = new SqlConnection(settings.ConnectionString);
		}


		/*public long InsertAngajat()
		{
			//SqlCommand insertCommand = new SqlCommand("InsertUpdateAngajat", m_con);
			//SqlCommand insertCommand = new SqlCommand("tmp_InsertUpdateAngajat", m_con);
			SqlCommand insertCommand = new SqlCommand("tmp_InsertUpdateAngajat_010205", m_con);
			insertCommand.CommandType = CommandType.StoredProcedure;
			
			LoadParametersIntoCommand(insertCommand);
			
			SqlDataAdapter dAdapt = new SqlDataAdapter(insertCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return Convert.ToInt64(insertCommand.Parameters["@new_id"].Value.ToString());
		}*/


		/*public DataSet GetVechimeInMuncaPerTotal(int id)
		{
			SqlCommand myCommand = new SqlCommand("GetAngajatVechimeInMunca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, id));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Curr", SqlDbType.Bit, 4, 0));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
            return ds;   
		}

		//Dovlecel Vlad
		public DataSet GetAllAngajati( int categorieID, int angajatorID )
		{
			SqlCommand myCommand = new SqlCommand("GetAllAngajati", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID", SqlDbType.Int, 4, categorieID ));
			//Modificat:Muntean Raluca Cristina  - am adaugat ca parametru si id-ul angajatorului
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, angajatorID ));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return ds;   
		}

		/*
		 * Added:       Cristina Raluca Muntean
		 * Date:        13.09.2005
		 * Description: Returneaza toti angajatii care apartin de un angajator si care au avut contract in luna trimisa ca parametru
		 */
		/*public DataSet GetAllAngajatiDinLuna( int lunaID, int angajatorID )
		{
			try
			{
				SqlCommand myCommand = new SqlCommand("GetAllAngajatiDinLuna", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@LunaID", SqlDbType.Int, 4, lunaID ));
				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, angajatorID ));

				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
			
				return ds;   
			}
			catch{ return null;}
		}
		 
		//Dovlecel Vlad
		public int GetNormaAngajat( long angajatID )
		{
			try
			{
				//SqlCommand myCommand = new SqlCommand("GetAngajatNorma", m_con);
				SqlCommand myCommand = new SqlCommand("GetAngajat", m_con);
				myCommand.CommandType = CommandType.StoredProcedure;

				myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, angajatID ));

				SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);

				//return int.Parse( ds.Tables[ 0 ].Rows[ 0 ][ "NormaLucru" ].ToString());
				return int.Parse( ds.Tables[ 0 ].Rows[ 0 ][ "ProgramLucru" ].ToString());
			}
			catch
			{
				return 0;
			}
			
		}

		public DataSet GetVechimeInMuncaAngajatorCurr(int id)
		{
			SqlCommand myCommand = new SqlCommand("GetAngajatVechimeInMunca", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, id));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Curr", SqlDbType.Bit, 4, 1));
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return ds;   
		}


		public void LoadAngajat(long id)
		{
		
			SqlCommand myCommand = new SqlCommand("GetAngajatInfo", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;

			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.BigInt, 10, id));

			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);

			//Modificat:	Oprescu Claudia
			//Descriere:	Se obtine situatia unui angajatu numai daca acesta exista
			if (ds.Tables[0].Rows.Count > 0)
			{
				DataRow dataRow = ds.Tables[0].Rows[0];
				AngajatID = Convert.ToInt64(dataRow["AngajatID"]);
				Nume = dataRow["Nume"].ToString();
				Prenume = dataRow["Prenume"].ToString();
				if (!Convert.IsDBNull(dataRow["TitluID"]))
					TitluID = Convert.ToInt32(dataRow["TitluID"]);
				TitluSimbol = dataRow["TitluSimbol"].ToString();
				TitluDenumire = dataRow["TitluDenumire"].ToString();
			
				NumeAngajator = dataRow["NumeAngajator"].ToString();
			
				if (!Convert.IsDBNull(dataRow["AngajatorID"]))
					AngajatorID = Convert.ToInt32(dataRow["AngajatorID"]);
				if (!Convert.IsDBNull(dataRow["PunctLucruID"]))
					PunctLucruID = Convert.ToInt32(dataRow["PunctLucruID"]);
				if (!Convert.IsDBNull(dataRow["CasaDeAsigurariID"]))
					CasaDeAsigurariID = Convert.ToInt32(dataRow["CasaDeAsigurariID"]);
				Marca = dataRow["Marca"].ToString();
				PrenumeTata = dataRow["PrenumeTata"].ToString();
				PrenumeMama = dataRow["PrenumeMama"].ToString();
				NumeAnterior = dataRow["NumeAnterior"].ToString();
				if (!Convert.IsDBNull(dataRow["StudiuID"]))
					StudiuID = Convert.ToInt32(dataRow["StudiuID"]);
				if (!Convert.IsDBNull(dataRow["AnAbsolvire"]))
					AnAbsolvire = dataRow["AnAbsolvire"].ToString();
				NrDiploma = dataRow["NrDiploma"].ToString();
				Descriere = dataRow["Descriere"].ToString();
				if (!Convert.IsDBNull(dataRow["ModIncadrare"]))
					ModIncadrare = Convert.ToByte(dataRow["ModIncadrare"]);
				if (!Convert.IsDBNull(dataRow["ProgramLucru"]))
					ProgramLucru = Convert.ToByte(dataRow["ProgramLucru"]);
            
				// load datele despre Buletin
				if( !Convert.IsDBNull( dataRow[ "CNP" ] ))
					CNP = Convert.ToInt64(dataRow["CNP"]);
				if( !Convert.IsDBNull( dataRow[ "CNPAnterior" ] ))
					CNPAnterior = Convert.ToInt64(dataRow["CNPAnterior"]);
				if( !Convert.IsDBNull( dataRow[ "CISerie" ] ))
					CISerie = dataRow["CISerie"].ToString();
				if (!Convert.IsDBNull(dataRow["CINumar"]))
					//CINumar = Convert.ToInt64(dataRow["CINumar"]);
					CINumar = dataRow["CINumar"].ToString();
				if( !Convert.IsDBNull( dataRow[ "CIEliberatDe" ] ))
					CIEliberatDe = dataRow["CIEliberatDe"].ToString();
				if ( !Convert.IsDBNull(dataRow["CIDataEliberarii"]))
					CIDataEliberarii = Convert.ToDateTime(dataRow["CIDataEliberarii"]);
				if (!Convert.IsDBNull(dataRow["CIValabilPanaLa"]))
					CIValabilPanaLa = Convert.ToDateTime(dataRow["CIValabilPanaLa"]);

				//load datele despre Pasaport
				if( !Convert.IsDBNull( dataRow[ "PASSerie" ] ))
					PASSerie = dataRow["PASSerie"].ToString();
				if (!Convert.IsDBNull(dataRow["PASNumar"]))
					//PASNumar = Convert.ToInt64(dataRow["PASNumar"]);
					PASNumar = dataRow["PASNumar"].ToString();
				if( !Convert.IsDBNull( dataRow[ "PASEliberatDe" ] ))
					PASEliberatDe = dataRow["PASEliberatDe"].ToString();
				if (!Convert.IsDBNull(dataRow["PasDataEliberarii"]))
					PASDataEliberarii = Convert.ToDateTime(dataRow["PASDataEliberarii"]);
				if (!Convert.IsDBNull(dataRow["PASValabilPanaLa"]))
					PASValabilPanaLa = Convert.ToDateTime(dataRow["PASValabilPanaLa"]);

				//load datele despre Permisul de munca
				if( !Convert.IsDBNull( dataRow[ "SeriePermisMunca" ] ))
					SeriePermisMunca = dataRow["SeriePermisMunca"].ToString();
				if (!Convert.IsDBNull(dataRow["NrPermisMunca"]))
					NrPermisMunca = Convert.ToInt64(dataRow["NrPermisMunca"]);
				if (!Convert.IsDBNull(dataRow["PermMuncaDataEliberare"]))
					PermisMuncaDataEliberare = Convert.ToDateTime(dataRow["PermMuncaDataEliberare"]);
				if (!Convert.IsDBNull(dataRow["PermMuncaDataExpirare"]))
					PermisMuncaDataExpirare = Convert.ToDateTime(dataRow["PermMuncaDataExpirare"]);

				//load datele despre Legitimatia de sedere
				if( !Convert.IsDBNull( dataRow[ "SerieLegitimatieSedere" ] ))
					SerieLegitimatieSedere = dataRow["SerieLegitimatieSedere"].ToString();
				if (!Convert.IsDBNull(dataRow["NrLegitimatieSedere"]))
					NrLegitimatieSedere = dataRow["NrLegitimatieSedere"].ToString();
				if (!Convert.IsDBNull(dataRow["LegitimatieSedereDataEliberare"]))
					LegitimatieSedereDataEliberare = Convert.ToDateTime(dataRow["LegitimatieSedereDataEliberare"]);
				if (!Convert.IsDBNull(dataRow["LegitimatieSedereDataExpirare"]))
					LegitimatieSedereDataExpirare = Convert.ToDateTime(dataRow["LegitimatieSedereDataExpirare"]);

				//load datele despre NIF
				if( !Convert.IsDBNull( dataRow[ "NIF" ] ))
					NIF = dataRow["NIF"].ToString();

				/*			if(!Convert.IsDBNull(dataRow["PermMuncaEliberat"]))
								PermMuncaEliberat=Convert.ToDateTime(dataRow["PermMuncaEliberat"]);
							if(!Convert.IsDBNull(dataRow["PermMuncaExpira"]))
								PermMuncaExpira=Convert.ToDateTime(dataRow["PermMuncaExpira"]);
							if(!Convert.IsDBNull(dataRow["PermSedereEliberat"]))
								PermSedereEliberat=Convert.ToDateTime(dataRow["PermSedereEliberat"]);
							if(!Convert.IsDBNull(dataRow["PermSedereExpira"]))
								PermSedereExpira=Convert.ToDateTime(dataRow["PermSedereExpira"]);
							if(!Convert.IsDBNull(dataRow["NrPermisMunca"]))
								NrPermisMunca=Convert.ToInt64(dataRow["NrPermisMunca"]);*/

				// load datele despre Domiciliu
				/*if (!Convert.IsDBNull(dataRow["DTaraID"]))
					DTara = Convert.ToInt32(dataRow["DTaraID"]);
				else
					DTara = 0;
				DLocalitate = dataRow["DLocalitate"].ToString();
				if (!Convert.IsDBNull(dataRow["DJudetSectorID"]))
					DJudetSectorID = Convert.ToInt32(dataRow["DJudetSectorID"]);
				else 
					DJudetSectorID = 0;
				DStrada = dataRow["DStrada"].ToString();
				DNumar = dataRow["DNumar"].ToString();
				DCodPostal = dataRow["DCodPostal"].ToString();
				DBloc = dataRow["DBloc"].ToString();
				DScara = dataRow["DScara"].ToString();
				DEtaj = dataRow["DEtaj"].ToString();
				DApartament = dataRow["DApartament"].ToString();
				// end - load datele despre Resedinta

				// load datele despre Resedinta
				if (!Convert.IsDBNull(dataRow["RTaraID"]))
					RTara = Convert.ToInt32(dataRow["RTaraID"]);
				else
					RTara = 0;
				RLocalitate = dataRow["RLocalitate"].ToString();
				if (!Convert.IsDBNull(dataRow["RJudetSectorID"]))
					RJudetSectorID = Convert.ToInt32(dataRow["RJudetSectorID"]);
				else 
					RJudetSectorID = 0;
				RStrada = dataRow["RStrada"].ToString();
				RNumar = dataRow["RNumar"].ToString();
				RCodPostal = dataRow["RCodPostal"].ToString();
				RBloc = dataRow["RBloc"].ToString();
				RScara = dataRow["RScara"].ToString();
				REtaj = dataRow["REtaj"].ToString();
				RApartament = dataRow["RApartament"].ToString();
				// end - load datele despre Resedinta

				// load date carnet de munca
				CMSerie = dataRow["CMSerie"].ToString();
				CMNumar = dataRow["CMNumar"].ToString();
				CMEmitent = dataRow["CMEmitent"].ToString();
				CMNrInregITM = dataRow["CMNrInregITM"].ToString();
				if (!Convert.IsDBNull(dataRow["CMDataEmiterii"]))
					CMDataEmiterii = Convert.ToDateTime(dataRow["CMDataEmiterii"]);
				// end  -  load date carnet de munca
			
				Telefon = dataRow["Telefon"].ToString();
				if (!Convert.IsDBNull(dataRow["DataNasterii"]))
					DataNasterii = Convert.ToDateTime(dataRow["DataNasterii"]);
				if (!Convert.IsDBNull(dataRow["JudetNastereID"]))
					JudetNastereID = Convert.ToInt32(dataRow["JudetNastereID"]);
				if (!Convert.IsDBNull(dataRow["TaraNastereID"]))
					TaraNastereID = Convert.ToInt32(dataRow["TaraNastereID"]);
				LocalitateNastere = dataRow["LocalitateNastere"].ToString();
				if (!Convert.IsDBNull(dataRow["StareCivila"]))
					StareCivila = Convert.ToByte(dataRow["StareCivila"]);
				if (!Convert.IsDBNull(dataRow["NrCopii"]))
					NrCopii = Convert.ToByte(dataRow["NrCopii"]);
				Sex = dataRow["Sex"].ToString();
				Nationalitate = int.Parse( dataRow["Nationalitate"].ToString());
			
				//CNP = Convert.ToInt64(dataRow["CNP"]);
				//CNPAnterior = Convert.ToInt64(dataRow["CNPAnterior"]);
				if (!Convert.IsDBNull(dataRow["TipFisaFiscala"]))
					TipFisaFiscala = Convert.ToByte(dataRow["TipFisaFiscala"]);
				if (!Convert.IsDBNull(dataRow["AniVechimeMunca"]))
					AniVechimeMunca = Convert.ToByte(dataRow["AniVechimeMunca"]);
				if (!Convert.IsDBNull(dataRow["LuniVechimeMunca"]))
					LuniVechimeMunca = Convert.ToByte(dataRow["LuniVechimeMunca"]);
				if (!Convert.IsDBNull(dataRow["ZileVechimeMunca"]))
					ZileVechimeMunca = Convert.ToInt32(dataRow["ZileVechimeMunca"]);
				if (!Convert.IsDBNull(dataRow["AreCardBancar"]))
					AreCardBancar = Convert.ToByte(dataRow["AreCardBancar"]);
		
				PozaAngajat = (byte[]) LoadPozaAngajat(AngajatID);
			

				if (!Convert.IsDBNull(dataRow["FunctieID"]))
					FunctieCurentaID = Convert.ToInt32(dataRow["FunctieID"]);
				else
					FunctieCurentaID=0;
				FunctieCurentaNume = dataRow["FunctieNume"].ToString();
				FunctieCurentaCod = dataRow["FunctieCod"].ToString();

				if (!Convert.IsDBNull(dataRow["CentruCostID"]))
					CentruCostID = Convert.ToInt32(dataRow["CentruCostID"]);
				else
					CentruCostID=0;

				if (!Convert.IsDBNull(dataRow["DepartamentID"]))
					DepartamentCurentID = Convert.ToInt32(dataRow["DepartamentID"]);
				else
					DepartamentCurentID =0;
				DepartamentCurentCod = dataRow["DepartamentCod"].ToString();
				DepartamentCurentDenumire = dataRow["DepartamentDenumire"].ToString();

				PerioadaDeterminata=System.Boolean.Parse(dataRow["PerioadaDeterminata"].ToString());
				if (!Convert.IsDBNull(dataRow["DataPanaLa"]))
					DataPanaLa = Convert.ToDateTime(dataRow["DataPanaLa"]);
				else
					DataPanaLa =DateTime.MinValue;
				//dovle
				if (!Convert.IsDBNull(dataRow["DataDeLa"]))
					DataDeLa = Convert.ToDateTime(dataRow["DataDeLa"]);
				else
					DataDeLa =DateTime.MinValue;

				//Ionel Popa
				if (!Convert.IsDBNull(dataRow["DataLichidare"]))
					DataLichidare = Convert.ToDateTime(dataRow["DataLichidare"]);
				else
					DataLichidare =DateTime.MinValue;

				//Lichidat
				isLichidat = System.Boolean.Parse(dataRow["Lichidat"].ToString());

				//Pensionat
				isPensionat = System.Boolean.Parse(dataRow["Pensionar"].ToString());

				//date contract de munca
				this.NrContractMunca= dataRow["NrContractMunca"].ToString();
				this.DataInregContractMunca= dataRow["DataInregContractMunca"]==System.DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dataRow["DataInregContractMunca"]);
				//echipament individual de protectie
				EchIndProtectie = dataRow["EchIndProtectie"].ToString();
				//echipament individual de lucru
				EchIndLucru = dataRow["EchIndLucru"].ToString();
				//materiale igienico sanitare
				MatIgiSan = dataRow["MatIgiSan"].ToString();
				//alimentatie de protectie
				AlimProtectie = dataRow["AlimProtectie"].ToString();
				//alte drepturi si obligati privind sanatatea in munca
				AlteDrSiObl = dataRow["AlteDrSiObl"].ToString();
				//alte clauze ale contractului individual de munca
				AlteClauzeCIM = dataRow["AlteClauzeCIM"].ToString();
				//perioada de proba
				PerProba = dataRow["PerProba"].ToString();
			
				this.Invaliditate=(short)dataRow["Invaliditate"];
				this.SalariuBaza=(decimal)dataRow["SalariuBazaActual"];
				this.IndemnizatieConducere=(decimal)dataRow["IndemnizatieConducereActual"];
				//sporuri
				if(!Convert.IsDBNull(dataRow["Sporuri"]))
					Sporuri = (decimal)dataRow["Sporuri"];
				else
					Sporuri = decimal.Parse("0");
				//alte adaosuri
				if(!Convert.IsDBNull(dataRow["AlteAdaosuri"]))
					AlteAdaosuri = (decimal)dataRow["AlteAdaosuri"];
				else
					AlteAdaosuri = decimal.Parse("0");

				if (!Convert.IsDBNull(dataRow["DataMajorare"]))
					//if( dataRow[ "DataMajorare" ] != System.DBNull.Value )
				{
					this.SumaMajorare = (decimal)dataRow[ "SumaMajorare" ];
					//this.DataMajorare = Utilities.ConvertText2DateTime( dataow[ "DataMajorare" ].ToString());
					/*char [] spl = { ' ' };
					string []data = dataRow[ "DataMajorare" ].ToString().Split( spl );
					//this.DataMajorare = (DateTime)dataRow[ "DataMajorare" ];
					this.DataMajorare = Utilities.ConvertText2DateTime( data[ 0 ].Replace( "/", "." ));*/
				/*	this.DataMajorare = Convert.ToDateTime( dataRow[ "DataMajorare" ] );
				}
				else
				{
					this.SumaMajorare = 0;
					this.DataMajorare = DateTime.MinValue;
				}

				this.NrZileCOAn=(int)dataRow["NrZileCOAn"];
				//numarul de zile de concediu de odihna suplimentar(pe an)
				if(!Convert.IsDBNull(dataRow["NrZileCOSupl"]))
					NrZileCOSupl = (int)dataRow["NrZileCOSupl"];
				else
					NrZileCOSupl = int.Parse("0");


				if (!Convert.IsDBNull(dataRow["SefID"]))
					SefID = Convert.ToInt64(dataRow["SefID"]);
				else
					SefID = 0;

				NumeCentruCost = dataRow["CentruCostNume"].ToString();

				// start load info situatia militara
				if (!Convert.IsDBNull(dataRow["DataIntrareEvidenta"]))
					m_infoSituatieMilitara.DataIntrareEvidenta = Convert.ToDateTime(dataRow["DataIntrareEvidenta"]);
				m_infoSituatieMilitara.EvidentaCMJ = dataRow["EvidentaCMJ"].ToString();
				m_infoSituatieMilitara.Gradul = dataRow["Gradul"].ToString();
				m_infoSituatieMilitara.NumarLivret = dataRow["NumarLivret"].ToString();
				m_infoSituatieMilitara.SerieLivret = dataRow["SerieLivret"].ToString();
				m_infoSituatieMilitara.SpecialitatiMilitare = dataRow["SpecialitatiMilitare"].ToString();
				// end load situatie militara info
				m_CategorieID=(int)dataRow["CategorieID"]; 
				m_Email = dataRow["Email"].ToString();
				m_TelMunca = dataRow["TelMunca"].ToString();
			}
		}

		
		public object LoadPozaAngajat( long id)
		{	
			m_con.Open();
			SqlCommand myCommand = new SqlCommand("spGetPozaAngajat", m_con);
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, id));
			myCommand.CommandType = CommandType.StoredProcedure;
			object obj = myCommand.ExecuteScalar();
			m_con.Close();
			if (obj!=System.DBNull.Value)
				return obj;
			else
				return null;
		}

		
		public void UpdateAngajat()
		{
			if (AngajatID!=0)
			{
				SqlCommand updateCommand = new SqlCommand("tmp_InsertUpdateAngajat_010205", m_con);
				updateCommand.CommandType = CommandType.StoredProcedure;
				
				LoadParametersIntoCommand(updateCommand);
                				
				SqlDataAdapter dAdapt = new SqlDataAdapter(updateCommand);
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
			}
			else
				throw new Exception("AngajatID=0, inside Angajat class!");
		}


		private void LoadParametersIntoCommand(SqlCommand myCmd)
		{
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, m_AngajatID));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, m_AngajatorID));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@PunctLucruID", SqlDbType.Int, 4, m_PunctLucruID));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@CasaDeAsigurariID", SqlDbType.Int, 4, m_CasaDeAsigurariID));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Marca", SqlDbType.NVarChar, 8, m_Marca));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Nume", SqlDbType.NVarChar, 50, m_Nume));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Prenume", SqlDbType.NVarChar, 50, m_Prenume));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@NumeAnterior", SqlDbType.NVarChar, 50, m_NumeAnterior));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@TitluID", SqlDbType.Int, 4, m_TitluID));
			if (m_PozaAngajat!=null)
				myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Poza", SqlDbType.Image, PozaAngajat.Length, m_PozaAngajat));
			else
				myCmd.Parameters.Add(UtilitiesDb.AddNULLParameter("@Poza", SqlDbType.Image,0));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@PrenumeMama", SqlDbType.NVarChar, 50 , m_PrenumeMama));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@PrenumeTata", SqlDbType.NVarChar, 50 , m_PrenumeTata));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@StudiuID", SqlDbType.Int, 4 , m_StudiuID));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@AnAbsolvire", SqlDbType.NVarChar, 4 , m_AnAbsolvire));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@NrDiploma", SqlDbType.VarChar, 50 , m_NrDiploma));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Descriere", SqlDbType.NVarChar, 100 , m_Descriere));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@ModIncadrare", SqlDbType.Bit, 1 , m_ModIncadrare));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@ProgramLucru", SqlDbType.TinyInt, 4 , m_ProgramLucru));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Telefon", SqlDbType.NVarChar, 25 , m_Telefon));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@DataNasterii", SqlDbType.DateTime, 8 , m_DataNasterii));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraNastereID", SqlDbType.Int, 4 , m_TaraNastereID));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@JudetNastereID", SqlDbType.Int, 4 , m_JudetNastereID));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@LocalitateNastere", SqlDbType.NVarChar, 50 , m_LocalitateNastere));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@StareCivila", SqlDbType.TinyInt, 2 , m_StareCivila));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@NrCopii", SqlDbType.TinyInt, 2 , m_NrCopii));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Sex", SqlDbType.Char, 1, m_Sex));
			//myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Nationalitate", SqlDbType.NVarChar, 50 , m_Nationalitate));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Nationalitate", SqlDbType.Int, 4 , m_Nationalitate));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@TipFisaFiscala", SqlDbType.Bit, 1 , m_TipFisaFiscala));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@AniVechimeMunca", SqlDbType.TinyInt, 4 , m_AniVechimeMunca));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@LuniVechimeMunca", SqlDbType.TinyInt, 4 , m_LuniVechimeMunca));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@ZileVechimeMunca", SqlDbType.TinyInt, 4 , m_ZileVechimeMunca));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@AreCardBancar", SqlDbType.Bit, 1 , m_AreCardBancar));
			//pentru perioada determinata
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@PerioadaDeterminata", SqlDbType.Bit, 1 , m_PerioadaDeterminata));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@DataPanaLa", SqlDbType.DateTime, 8 , m_DataPanaLa));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@DataDeLa", SqlDbType.DateTime, 8 , m_DataDeLa));

			//pentru date despre lichidare
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Lichidat", SqlDbType.Bit, 1 , m_isLichidat));
			
			//pentru date despre pensionare
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Pensionat", SqlDbType.Bit, 1 , m_isPensionat));			

			//pentru contract munca
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@NrContractMunca", SqlDbType.VarChar, 50 , m_NrContractMunca));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@DataInregContractMunca", SqlDbType.DateTime,8 , m_DataInregContractMunca));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@EchIndProtectie", SqlDbType.NVarChar,100 , m_EchIndProtectie));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@EchIndLucru", SqlDbType.NVarChar,100 , m_EchIndLucru));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@MatIgiSan", SqlDbType.NVarChar,100 , m_MatIgiSan));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@AlimProtectie", SqlDbType.NVarChar,100 , m_AlimProtectie));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@AlteDrSiObl", SqlDbType.NVarChar,100 , m_AlteDrSiObl));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@AlteClauzeCIM", SqlDbType.NVarChar,100 , m_AlteClauzeCIM));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@PerProba", SqlDbType.NVarChar,50 , m_PerProba));
			//pt invaliditate
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Invaliditate", SqlDbType.SmallInt,2 , m_Invaliditate));
			//pt salariu+indemnizatie de conducere
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@FunctieID", SqlDbType.Int,4 , m_FunctieCurentaID.ToString()));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@CentruCostID", SqlDbType.Int,4 , m_CentruCostID.ToString()));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@DepartamentID", SqlDbType.Int,4 , m_DepartamentCurentID.ToString()));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@SalariuBaza", SqlDbType.Money,8 , m_SalariuBaza.ToString()));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@IndemnizatieConducere", SqlDbType.Money,8 , m_IndemnizatieConducere.ToString()));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Sporuri", SqlDbType.Money,8 , m_Sporuri.ToString()));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@AlteAdaosuri", SqlDbType.Money,8 , m_AlteAdaosuri.ToString()));
			if( m_DataMajorare != DateTime.MinValue )
			{
				myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@SumaMajorare", SqlDbType.Money,8 , m_SumaMajorare.ToString()));
				myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@DataMajorare", SqlDbType.DateTime,8 , m_DataMajorare ));
			}
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@NrZileCOAn", SqlDbType.Int,4 , m_NrZileCOAn ));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@NrZileCOSupl", SqlDbType.Int,4 , m_NrZileCOSupl ));

			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@SefID", SqlDbType.Int, 4 , m_SefID));

			//BULETIN
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@CNP", SqlDbType.BigInt, 9 , m_CNP));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@CNPAnterior", SqlDbType.BigInt, 9 , m_CNPAnterior));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@SerieCI", SqlDbType.Char, 2 , m_CISerie));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@NumarCI", SqlDbType.NVarChar, 20 , m_CINumar));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@EliberatDeCI", SqlDbType.NVarChar, 50 , m_CIEliberatDe));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEliberariiCI", SqlDbType.DateTime, 8 , m_CIDataEliberarii));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@ValabilPanaLaCI", SqlDbType.DateTime, 8 , m_CIValabilPanaLa));
			

			//PASAPORT
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@SeriePas", SqlDbType.NVarChar, 10 , m_PASSerie));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@NumarPas", SqlDbType.NVarChar, 20 , m_PASNumar));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@EliberatDePas", SqlDbType.NVarChar, 50 , m_PASEliberatDe));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEliberariiPas", SqlDbType.DateTime, 8 , m_PASDataEliberarii));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@ValabilPanaLaPas", SqlDbType.DateTime, 8 , m_PASValabilPanaLa));

			//PERMIS MUNCA
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEliberarePermisMunca", SqlDbType.DateTime, 8 , m_PermisMuncaDataEliberare));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@DataExpirarePermisMunca", SqlDbType.DateTime, 8 , m_PermisMuncaDataExpirare));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@NrPermisMunca", SqlDbType.BigInt,10 , m_NrPermisMunca));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@SeriePermisMunca", SqlDbType.NVarChar,10 , m_SeriePermisMunca));

			//LEGITIMATIE SEDERE
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEliberareLegitimatieSedere", SqlDbType.DateTime, 8 , m_LegitimatieSedereDataEliberare));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@DataExpirareLegitimatieSedere", SqlDbType.DateTime, 8 , m_LegitimatieSedereDataExpirare));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@NrLegitimatieSedere", SqlDbType.NVarChar,50 , m_NrLegitimatieSedere));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@SerieLegitimatieSedere", SqlDbType.NVarChar,10 , m_SerieLegitimatieSedere));

			//NIF
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@NIF", SqlDbType.NVarChar, 50, m_NIF));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@TipNationalitateDomiciliu", SqlDbType.SmallInt, 2 , m_tipNationalitateDomiciliu));
			
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraID", SqlDbType.Int, 4 , m_DTara));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Localitate", SqlDbType.NVarChar, 50 , m_DLocalitate));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@JudetSectorID", SqlDbType.Int, 4 , m_DJudetSectorID));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Strada", SqlDbType.NVarChar, 50 , m_DStrada));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@NumarStr", SqlDbType.NVarChar, 10 , m_DNumar));
			if( m_DCodPostal != "" )
				myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@CodPostal", SqlDbType.NVarChar, 20 , m_DCodPostal));
			//else
				//myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@CodPostal", SqlDbType., 20 , m_DCodPostal));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Bloc", SqlDbType.NVarChar, 32 , m_DBloc));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Scara", SqlDbType.NVarChar, 5 , m_DScara));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Etaj", SqlDbType.NVarChar, 5 , m_DEtaj));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Apartament", SqlDbType.NVarChar, 5 , m_DApartament));

			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@TaraIDRes", SqlDbType.Int, 4 , m_RTara));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@LocalitateRes", SqlDbType.NVarChar, 50 , m_RLocalitate));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@JudetSectorIDRes", SqlDbType.Int, 4 , m_RJudetSectorID));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@StradaRes", SqlDbType.NVarChar, 50 , m_RStrada));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@NumarStrRes", SqlDbType.NVarChar, 10 , m_RNumar));
			if( m_RCodPostal != "" )
                myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@CodPostalRes", SqlDbType.NVarChar, 20 , m_RCodPostal));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@BlocRes", SqlDbType.NVarChar, 32 , m_RBloc));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@ScaraRes", SqlDbType.NVarChar, 5 , m_RScara));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@EtajRes", SqlDbType.NVarChar, 5 , m_REtaj));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@ApartamentRes", SqlDbType.NVarChar, 5 , m_RApartament));

			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Serie", SqlDbType.NVarChar, 5 , m_CMSerie));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Numar", SqlDbType.NVarChar, 10 , m_CMNumar));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Emitent", SqlDbType.NVarChar, 50 , m_CMEmitent));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@DataEmiterii", SqlDbType.DateTime, 8 , m_CMDataEmiterii));
	
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@NrInregITM", SqlDbType.NVarChar, 25 , m_CMNrInregITM));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@CategorieID",SqlDbType.Int,4,m_CategorieID));

			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@Email", SqlDbType.NVarChar, 255 , m_Email));
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@TelMunca", SqlDbType.NVarChar, 255 , m_TelMunca));
			SqlParameter param = new SqlParameter("@new_id", SqlDbType.Int, 4);
			param.Direction = ParameterDirection.Output;
			myCmd.Parameters.Add(param);

			//Alerte speciale
			myCmd.Parameters.Add(UtilitiesDb.AddInputParameter("@AlerteSpeciale", SqlDbType.NVarChar, 2056, m_AlerteSpeciale));

		}

		public void SetetazaAngajatiLunaInactivi( int angajatorID )
		{
			Salaries.Business.Luni l = new Salaries.Business.Luni( angajatorID );
			Salaries.Data.LunaData ld = l.GetLunaActiva();
			DateTime data = new DateTime( ld.Data.Year, ld.Data.Month, DateTime.DaysInMonth( ld.Data.Year, ld.Data.Month ));

			SqlCommand seteazaInactivi = new SqlCommand("SeteazaInactivAngajatiExpiraContractLunaCurenta", m_con);
			seteazaInactivi.CommandType = CommandType.StoredProcedure;
				
			seteazaInactivi.Parameters.Add(UtilitiesDb.AddInputParameter("@Data", SqlDbType.DateTime, 8 , data ));
			seteazaInactivi.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4 , angajatorID ));

			SqlDataAdapter dAdapt = new SqlDataAdapter( seteazaInactivi );
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
		}
		
		//Cristina Muntean
		//de exp: daca sunt doi angajati cu aceeasi marca returneaza false, altfel returneaza true
		public bool CheckDateAngajat()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("CheckDateAngajat", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, AngajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Marca", SqlDbType.NVarChar, 8, Marca));
			
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NuExistaMarca", SqlDbType.Bit, 0));
			
			m_con.Open();
			myCommand.ExecuteNonQuery();
			bool existaMarca = (bool)myCommand.Parameters["@NuExistaMarca"].Value;
			m_con.Close();
	
			return existaMarca;
		}
		
		//Cristina Muntean
		//de exp: daca sunt mai sunt si alti angajati cu aceasta marca in afara de cel in cauza returneaza false, altfel returneaza true
		public bool CheckDateAngajatForUpdate()
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			SqlConnection m_con = new SqlConnection(settings.ConnectionString);
			SqlCommand myCommand = new SqlCommand("CheckDateAngajatForUpdate", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatorID", SqlDbType.Int, 4, AngajatorID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@AngajatID", SqlDbType.Int, 4, AngajatID));
			myCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@Marca", SqlDbType.NVarChar, 8, Marca));
			
			myCommand.Parameters.Add(UtilitiesDb.AddOutputParameter("@NuExistaMarca", SqlDbType.Bit, 0));
			
			m_con.Open();
			myCommand.ExecuteNonQuery();
			bool existaMarca = (bool)myCommand.Parameters["@NuExistaMarca"].Value;
			m_con.Close();
	
			return existaMarca;
		}

		/// <summary>
		/// Metoda este folosita pentru a obtine id-urile tuturor angajatilor
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste valori</returns>
		public DataSet GetAngajatIDAll()
		{
			SqlCommand myCommand = new SqlCommand("spGetAngajatIDAll", m_con);
			myCommand.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter dAdapt = new SqlDataAdapter(myCommand);
			DataSet ds = new DataSet();
			dAdapt.Fill(ds);
			
			return ds;   
		}*/

	}
}
