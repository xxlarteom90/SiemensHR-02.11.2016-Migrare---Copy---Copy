/*
 * Autor: Cristina Raluca Muntean
 * Data:  24.07.2006
 */
using System;
using System.Xml;
using System.Text;
using System.IO;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Clasa permite generarea declaratiilor ce trebuie depuse la stat: CAS, somaj
	/// </summary>
	public class Declaratii: IDisposable
	{
		#region Constants
		// Numele nodului ce contine date despre fiecare camp al declaratiei in parte. 
		private const string CAMP_NOD = "DeclaratiaA11/Camp";
		// Numele atributului ce contine numele campului aferent declaratiei
		private const string NUME_CAMP_DECLARATIE = "numeCampDeclaratie";
		// Numele atributului ce contine numele campului din baza de date corespondent 
		// numelui campului din declaratiei.
		private const string NUME_CAMP_BAZA_DE_DATE = "numeCampBazaDeDate";
		// Numele atributului ce contine dimensiunea aferenta campului din declaratie.
		private const string DIMENSIUNE_CAMP = "dimensiune";
		// Numele atributului ce contine tipul campului. In functie de numele campului se face 
		// alinierea:
		// N - numeric, aliniat la dreapta
		// C - caracter(alfanumeric), aliniat la stanga.
		private const string TIP_CAMP = "tipCamp";
		// Tip numeric.
		private const string NUMERIC = "N";
		// Tip caracter.
		private const string CARACTER = "C";
		// Numele nodului din fisierul XML ce contine datele aferente declaratiei pentru CAS A11.
		private const string DECLARATIE_A11_NOD = "Declaratii/DeclaratiiCAS/DeclaratiaA11";
		// Numele nodului din fisierul XML ce contine datele aferente declaratiei pentru CAS A12.
		private const string DECLARATIE_A12_NOD = "Declaratii/DeclaratiiCAS/DeclaratiaA12";
		// Numele nodului din fisierul XML ce contine datele aferente declaratiei pentru somaj Cap1.
		private const string DECLARATIE_CAP1_NOD = "Declaratii/DeclaratiiSomaj/DeclaratiaCap1";
		// Numele nodului din fisierul XML ce contine datele aferente declaratiei pentru somaj Cap2.
		private const string DECLARATIE_CAP2_NOD = "Declaratii/DeclaratiiSomaj/DeclaratiaCap2";
		
		#endregion
	
		#region Atribute private
		// Id-ul lunii pentru care se doreste generarea declaratiei.
		protected int lunaID;
		// Id-ul angajatorului pentru care se doreste generarea declaratiei.
		protected int angajatorID;
		// Calea catre fisierul in care trebuie scrise datele aferente declaratiei.
		protected string caleFisierDeclaratie;
		// Calea catre fisierul XML din care trebuie preluate datele.
		protected string caleFisierXML;
		// Documentul XML ce contine toate datele despre declaratii.
		private XmlDocument xmlDocument;
		// O lista cu nodurile ce contin date despre campurile aferente declaratiei.
		private XmlNodeList listaCampuri;
		// Setarile aplicatiei.
		private Configuration.ModuleSettings settings;
		// Daca resursele au fost eliberate atunci valoarea variabilei e false, altfel true.
		private bool disposed = false;
		#endregion
			
		#region Constructor
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="lunaID"> Id-ul lunii pentru care se doreste generarea declaratiei.</param>
		/// <param name="angajatorID"> Id-ul angajatorului pentru care se doreste generarea declaratiei.</param>
		/// <param name="caleFisier"> Calea catre fisierul in care trebuie scrise datele aferente declaratiei.</param>
		public Declaratii(int lunaID, int angajatorID, string caleFisierDeclaratie, string caleFisierXML)
		{
			settings = Configuration.ModuleConfig.GetSettings();

			xmlDocument = new XmlDocument();
			this.lunaID = lunaID;
			this.angajatorID = angajatorID;
			this.caleFisierDeclaratie = caleFisierDeclaratie;
			this.caleFisierXML = caleFisierXML;
			this.xmlDocument = GetXmlDocumentDinFisier(caleFisierXML);
		}

		public Declaratii(int lunaID, int angajatorID)
		 {
			 settings = Configuration.ModuleConfig.GetSettings();
			 this.lunaID = lunaID;
			 this.angajatorID = angajatorID;
		 }
		#endregion
		
		#region Destructor
		/// <summary>
		/// Destructor.
		/// </summary>
		~Declaratii()
		{
			// Call Dispose with false.  Since we're in the  destructor call,
			// the managed resources will be  disposed of anyways.
			Dispose(false);
		}
		#endregion

		#region GenerareDeclaratieCASa11
		/// <summary>
		/// Generarea declaratiei pentru CAS A11. 
		/// </summary>
		public void GenerareDeclaratieCASa11()
		{
			// DataSet ce contine toate datele aferete declaratiei.
			DataSet dsDateDeclaratie = new DataSet();
			// O linie ce va fi scrisa in fisier.
			StringBuilder linieFisier = new StringBuilder();

			StreamWriter streamWriter;
			streamWriter = File.CreateText(caleFisierDeclaratie);
			// Valoarea unui cam din declaratie.
			string valoareCamp;
			// Dimensiunea unui camp din declaratie.
			int dimensiune;
			// Tipul campului din declaratie.
			string tipCamp;
			
			Salaries.Data.Declaratii declaratiaA11 = new Salaries.Data.Declaratii(settings.ConnectionString);
			dsDateDeclaratie  = declaratiaA11.GetDateDeclaratieCASa11(lunaID, angajatorID);
			
			GetCampuriDeclaratie(DECLARATIE_A11_NOD);

			try
			{
				foreach(DataRow drDate in dsDateDeclaratie.Tables[0].Rows)
				{
					for(int i=0; i<listaCampuri.Count; i++)
					{
						tipCamp = listaCampuri[i].Attributes[TIP_CAMP].Value.ToString();
						valoareCamp = drDate[listaCampuri[i].Attributes[NUME_CAMP_BAZA_DE_DATE].Value.ToString()].ToString();
						dimensiune = int.Parse(listaCampuri[i].Attributes[DIMENSIUNE_CAMP].Value.ToString());
						
						linieFisier.Append(ConversieCampCAS(valoareCamp, dimensiune, tipCamp));
					}
					
					streamWriter.WriteLine(linieFisier.ToString());
					linieFisier.Remove(0,linieFisier.Length);
				}
			}
			catch(System.Xml.XmlException)
			{
				throw new XmlException
					("Structura fisierului XML este gresita! Lipseste ce putin unul din urmatoarelea tribute: "+
					NUME_CAMP_DECLARATIE +", "+NUME_CAMP_BAZA_DE_DATE+", "+DIMENSIUNE_CAMP+", "+TIP_CAMP);
			}

			streamWriter.Close();
		}
		#endregion

		#region GenerareDeclaratieCASa12
		/// <summary>
		/// Generarea declaratiei pentru CAS A12. 
		/// </summary>
		/// <param name="dataPlataSalariu"> Data platii drepturilor salariale.</param>
		/// <param name="nrFileAnexa11"> Numarul de file ale anexei 1.1.</param>
		public void GenerareDeclaratieCASa12(DateTime dataPlataSalariu, int nrFileAnexa11)
		{
			// DataSet ce contine toate datele aferete declaratiei.
			DataSet dsDateDeclaratie = new DataSet();
			// O linie ce va fi scrisa in fisier.
			StringBuilder linieFisier = new StringBuilder();

			StreamWriter streamWriter;
			streamWriter = File.CreateText(caleFisierDeclaratie);
			// Valoarea unui cam din declaratie.
			string valoareCamp;
			// Dimensiunea unui camp din declaratie.
			int dimensiune;
			// Tipul campului din declaratie.
			string tipCamp;
			
			Salaries.Data.Declaratii declaratiaA12 = new Salaries.Data.Declaratii(settings.ConnectionString);
			dsDateDeclaratie  = declaratiaA12.GetDateDeclaratieCASa12(lunaID, angajatorID, dataPlataSalariu, nrFileAnexa11);
			
			GetCampuriDeclaratie(DECLARATIE_A12_NOD);

			try
			{
				foreach(DataRow drDate in dsDateDeclaratie.Tables[0].Rows)
				{
					for(int i=0; i<listaCampuri.Count; i++)
					{
						valoareCamp = drDate[listaCampuri[i].Attributes[NUME_CAMP_BAZA_DE_DATE].Value.ToString()].ToString();
						dimensiune = int.Parse(listaCampuri[i].Attributes[DIMENSIUNE_CAMP].Value.ToString());
						tipCamp = listaCampuri[i].Attributes[TIP_CAMP].Value.ToString();

						linieFisier.Append(ConversieCampCAS(valoareCamp, dimensiune, tipCamp));
					}
					
					streamWriter.WriteLine(linieFisier.ToString());
					linieFisier.Remove(0,linieFisier.Length);
				}
			}
			catch(System.Xml.XmlException)
			{
				throw new XmlException
					("Structura fisierului XML este gresita! Lipseste ce putin unul din urmatoarelea tribute: "+
					NUME_CAMP_DECLARATIE +", "+NUME_CAMP_BAZA_DE_DATE+", "+DIMENSIUNE_CAMP+", "+TIP_CAMP);
			}

			streamWriter.Close();
		}
		#endregion

		#region
		public DataSet GetDateDeclaratieCASa12(DateTime dataPlataSalariu, int nrFileAnexa11)
		{
			Salaries.Data.Declaratii declaratiaA12 = new Salaries.Data.Declaratii(settings.ConnectionString);
		    return declaratiaA12.GetDateDeclaratieCASa12(lunaID, angajatorID, dataPlataSalariu, nrFileAnexa11);
		}
		#endregion

		#region GenerareDeclaratieSomajCap1
		/// <summary>
		/// Generarea declaratiei pentru somaj Cap1. 
		/// </summary>
		public void GenerareDeclaratieSomajCap1()
		{
			// DataSet ce contine toate datele aferete declaratiei.
			DataSet dsDateDeclaratie = new DataSet();
			// O linie ce va fi scrisa in fisier.
			StringBuilder linieFisier = new StringBuilder();

			StreamWriter streamWriter;
			streamWriter = File.CreateText(caleFisierDeclaratie);
			// Valoarea unui cam din declaratie.
			string valoareCamp;
			// Dimensiunea unui camp din declaratie.
			int dimensiune;
			// Tipul campului din declaratie.
			string tipCamp;
			
			Salaries.Data.Declaratii declaratiaCap1 = new Salaries.Data.Declaratii(settings.ConnectionString);
			dsDateDeclaratie  = declaratiaCap1.GetDateDeclaratieSomajCap1(lunaID, angajatorID);
			
			GetCampuriDeclaratie(DECLARATIE_CAP1_NOD);

			try
			{
				foreach(DataRow drDate in dsDateDeclaratie.Tables[0].Rows)
				{
					for(int i=0; i<listaCampuri.Count; i++)
					{
						valoareCamp = drDate[listaCampuri[i].Attributes[NUME_CAMP_BAZA_DE_DATE].Value.ToString()].ToString();
						dimensiune = int.Parse(listaCampuri[i].Attributes[DIMENSIUNE_CAMP].Value.ToString());
						tipCamp = listaCampuri[i].Attributes[TIP_CAMP].Value.ToString();

						linieFisier.Append(ConversieCampSomaj(valoareCamp, dimensiune, tipCamp));
					}
					
					streamWriter.WriteLine(linieFisier.ToString());
					linieFisier.Remove(0,linieFisier.Length);
				}
			}
			catch(System.Xml.XmlException)
			{
				throw new XmlException
					("Structura fisierului XML este gresita! Lipseste ce putin unul din urmatoarelea tribute: "+
					NUME_CAMP_DECLARATIE +", "+NUME_CAMP_BAZA_DE_DATE+", "+DIMENSIUNE_CAMP+", "+TIP_CAMP);
			}

			streamWriter.Close();
		}
		#endregion

		#region GenerareDeclaratieSomajCap2
		/// <summary>
		/// Generarea declaratiei pentru somaj Cap2. 
		/// </summary>
		public void GenerareDeclaratieSomajCap2()
		{
			// Lungu Andreea - 15.08.2008 - a fost scos parametrul reprezentantLegalID

			// DataSet ce contine toate datele aferete declaratiei.
			DataSet dsDateDeclaratie = new DataSet();
			// O linie ce va fi scrisa in fisier.
			StringBuilder linieFisier = new StringBuilder();

			StreamWriter streamWriter;
			streamWriter = File.CreateText(caleFisierDeclaratie);
			// Valoarea unui cam din declaratie.
			string valoareCamp;
			// Dimensiunea unui camp din declaratie.
			int dimensiune;
			// Tipul campului din declaratie.
			string tipCamp;
			
			Salaries.Data.Declaratii declaratiaCap2 = new Salaries.Data.Declaratii(settings.ConnectionString);
			dsDateDeclaratie  = declaratiaCap2.GetDateDeclaratieSomajCap2(lunaID, angajatorID);
			
			GetCampuriDeclaratie(DECLARATIE_CAP2_NOD);

			try
			{
				foreach(DataRow drDate in dsDateDeclaratie.Tables[0].Rows)
				{
					for(int i=0; i<listaCampuri.Count; i++)
					{
						valoareCamp = drDate[listaCampuri[i].Attributes[NUME_CAMP_BAZA_DE_DATE].Value.ToString()].ToString();
						dimensiune = int.Parse(listaCampuri[i].Attributes[DIMENSIUNE_CAMP].Value.ToString());
						tipCamp = listaCampuri[i].Attributes[TIP_CAMP].Value.ToString();

						linieFisier.Append(ConversieCampSomaj(valoareCamp, dimensiune, tipCamp));
					}
					
					streamWriter.WriteLine(linieFisier.ToString());
					linieFisier.Remove(0,linieFisier.Length);
				}
			}
			catch(System.Xml.XmlException)
			{
				throw new XmlException
					("Structura fisierului XML este gresita! Lipseste ce putin unul din urmatoarelea tribute: "+
					NUME_CAMP_DECLARATIE +", "+NUME_CAMP_BAZA_DE_DATE+", "+DIMENSIUNE_CAMP+", "+TIP_CAMP);
			}

			streamWriter.Close();
		}
		#endregion

		#region GetXmlDocumentDinFisier
		/// <summary>
		/// Este incarcat fisierul XML.
		/// </summary>
		/// <param name="caleFisier"> Calea catre fisierul XML ce trebuie incarcat. </param>
		/// <returns> XmlDocument-ul cu datele aferente. </returns>
		private XmlDocument GetXmlDocumentDinFisier(string caleFisier)
		{
			// Continutul fisierului.
			string continutFisier;

			XmlDocument xmlDoc = new XmlDocument();
			
			// Este obtinut continutul fisierului.
			continutFisier = GetStringDinFisier(caleFisier);
			
			try
			{
				xmlDoc.LoadXml(continutFisier);
			}
			catch (System.Xml.XmlException)
			{
				throw new XmlException("Eroare de incarcare a fisierului XML aferent declaratiilor: " + caleFisier);
			}

			return xmlDoc;
		}
		#endregion

		#region GetStringDinFisier
		/// <summary>
		/// Este incarcat continutul fisierului.
		/// </summary>
		/// <param name="caleFisier"> Numele fisierului. </param>
		/// <returns> Continutul fisierului incarcat intr-un string. </returns>
		private string GetStringDinFisier(string caleFisier)
		{		
			using( StreamReader streamReader = new StreamReader(caleFisier))
			{
				return streamReader.ReadToEnd();
			}
		}
		#endregion

		#region GetCampuriDeclaratie
		/// <summary>
		/// Returneaza nodul aferent declaratiei.
		/// </summary>
		/// <param name="nodDeclaratie"> Numele nodului aferent declaratiei ce se doreste a fi generata.</param>
		private void GetCampuriDeclaratie(string numeNodDeclaratie)
		{
			XmlNode nodDeclaratie = xmlDocument.SelectSingleNode(numeNodDeclaratie);
			
			if (nodDeclaratie.HasChildNodes)
			{
				listaCampuri = nodDeclaratie.ChildNodes;
			}
			else
			{
				throw new System.Exception
					("Nodul aferent declaratiei nu contine nodurile ce descriu structura declaratiei");
			}
		}
		#endregion

		#region ConversieCampCAS
		/// <summary>
		/// Se aplica o conversie asupra campului. Regula este urmatoarea:
		/// in cazul in care dimensiunea campului este mai mare decat cea prevazuta de lege, 
		/// atunci este micsorata dimensiunea valorii, altfel sunt adaugate spatii inaintea
		/// valorii campului pana se ajunge la dimensiunea prevazuta de lege.
		/// </summary>
		/// <param name="valoareCamp"> Valoarea campului.</param>
		/// <param name="dimensiune"> Dimensinea aferenta campului.</param>
		/// <param name="tipCamp"> Tipul campului.</param>
		/// <returns> Valoarea campului dupa aplicarea conversiei.</returns>
		private string ConversieCampCAS(string valoareCamp, int dimensiune, string tipCamp)
		{
			valoareCamp = valoareCamp.Replace(',', '.');
			valoareCamp = valoareCamp.Trim();
			if (valoareCamp.Length == dimensiune)
			{
				return valoareCamp;
			}
			else
			{
				if (valoareCamp.Length < dimensiune)
				{
					// In functie de tipul campului este facuta alinierea, astfel:
					// N - numeric, aliniat la dreapta
					// C - caracter, aliniat la stanga.					
					switch (tipCamp)
					{ 
						case NUMERIC:
							return valoareCamp.PadLeft(dimensiune);
						case CARACTER:
							return valoareCamp.PadRight(dimensiune);
						default:
							throw new System.Exception("Tipul unui camp din declaratie a fost setat incorect!");
					}
				}
				else
				{
					return valoareCamp.Substring(0, dimensiune);
				}
			}	
		}
		#endregion

		#region ConversieCampSomaj
		/// <summary>
		/// Se aplica o conversie asupra campului. Regula este urmatoarea:
		/// in cazul in care dimensiunea campului este mai mare decat cea prevazuta de lege, 
		/// atunci este micsorata dimensiunea valorii, altfel sunt adaugate spatii inaintea
		/// valorii campului pana se ajunge la dimensiunea prevazuta de lege. Toate campurile 
		/// de tip caracter sunt scrise cu majuscule.
		/// </summary>
		/// <param name="valoareCamp"> Valoarea campului.</param>
		/// <param name="dimensiune"> Dimensinea aferenta campului.</param>
		/// <param name="tipCamp"> Tipul campului.</param>
		/// <returns> Valoarea campului dupa aplicarea conversiei.</returns>
		private string ConversieCampSomaj(string valoareCamp, int dimensiune, string tipCamp)
		{
			valoareCamp = valoareCamp.Replace(',', '.');
			valoareCamp = valoareCamp.Trim();
			if (valoareCamp.Length == dimensiune)
			{
				return valoareCamp.ToUpper();
			}
			else
			{
				if (valoareCamp.Length < dimensiune)
				{
					// In functie de tipul campului este facuta alinierea, astfel:
					// N - numeric, aliniat la dreapta
					// C - caracter, aliniat la stanga.					
					switch (tipCamp)
					{ 
						case NUMERIC:
							return valoareCamp.PadLeft(dimensiune);
						case CARACTER:
							return valoareCamp.ToUpper().PadRight(dimensiune);
						default:
							throw new System.Exception("Tipul unui camp din declaratie a fost setat incorect!");
					}
				}
				else
				{
					return valoareCamp.ToUpper().Substring(0, dimensiune);
				}
			}	
		}
		#endregion

		#region IDisposable Members

		/// <summary>
		/// Efectueaza toate operatiile necesare eliberarii resurselor.
		/// </summary>
		public void Dispose()
		{
			// Dispose of the managed and unmanaged resources.
			Dispose(true);

			// Tell the GC that the Finalize process no longer needs
			// to be run for this object.
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// If disposeManagedResources equals true, the method has been called directly
		/// or indirectly by a user's code. Managed and unmanaged resources can be disposed.
		/// If disposing equals false, the method has been called by the runtime from inside
		/// the finalizer and you should not reference other objects. 
		/// </summary>
		protected virtual void Dispose(bool disposeManagedResources)
		{
			if (!this.disposed)
			{
				if (disposeManagedResources)
				{
					// Dispose managed resources.
					if (xmlDocument != null)
					{
						xmlDocument = null;
					}

					if (listaCampuri != null) 
					{
						listaCampuri = null;
					}
				}

				this.disposed = true;
			}
		}
		#endregion

		#region FiseFiscale
		public DataSet GetDateFiseFiscale(int an, int casaDeAsigurariID)
		{
			Salaries.Data.Declaratii declaratie = new Salaries.Data.Declaratii(settings.ConnectionString);
			return declaratie.GetDateFiseFiscale1(angajatorID, an, casaDeAsigurariID);
		}
		#endregion

	}
}
