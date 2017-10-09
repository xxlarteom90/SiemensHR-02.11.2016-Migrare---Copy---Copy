using System;
using System.Drawing;

namespace SiemensTM.Classes
{
	/// <summary>
	/// Summary description for Definitions.
	/// </summary>
	public class Definitions
	{
		#region Variabile
		public static string UserKEY = "CurrentUser";
		public static string UserInstanceKEY = "CurrentUserInstance";
		public static string TitluKEY = "Titlu";
		public static string NumeKEY = "Nume";
		public static string FunctieKEY = "Functie";
		public static string DepartamentKEY = "Departament";
		
		public static string SelectedDateKEY ="SelectedDate";

		public static Color Color_Altern = Color.FromName("D0E8F4");//Color.LightGray; 
		public static Color Color_AlternMedicalContinuare = Color.BlueViolet; 

		public static Color Color_ZiSelected = Color.GreenYellow;
		public static Color Color_ZiLucru = Color.White;
		public static Color Color_ZiSarbatoare = Color.LightGray;
		
		public static Color Color_StampNecompletat = Color.White;
		public static Color Color_StampCompletatPartial= Color.Yellow;
		public static Color Color_StampCompletat = Color.GreenYellow;

		public static Color Color_StampAbsenta = Color.Violet;
		public static Color Color_StampDelegatie = Color.LightYellow;
		public static Color Color_StampEmergencyService = Color.LightBlue;
		public static Color Color_StampZileLunaImposibile = Color.OrangeRed;
		public static Color Color_StampZileLunaIntreruperi = Color.OrangeRed;
		public const string TextZileLunaImposibile = " - ";

		public static string CodContinuareConcediuMedical = "CCM";

		public static string DenumireContinuareConcediuMedical = "Continuare concediu medical";
		public static string DenumireConcediuMedical = "Concediu medical";

		//Modificat:	Oprescu Claudia
		//Data:			27.07.2007
		//Descriere:	A fost adaugata o alerta pentru a verifica daca data de inceput si de sfarsit a unui interval sa nu fie inversate.
		//
		//Modificat:	Fratila Claudia
		//Data:			29.10.2007
		//Descriere:	A fost adaugata o alerta pentru a verifica corectitudinea unei data. 
		//				Ex:	31.09.2007 nu exista.
		public const string alertInceput = "Data de inceput nu este corecta. Formatul pentru data este zz.ll.aaaa. Va rugam verificati din nou aceasta valoare!";
		public const string alertSfarsit = "Data de sfarsit nu este corecta. Formatul pentru data este zz.ll.aaaa. Va rugam verificati din nou aceasta valoare!";
		public const string alertAdaugaAbsenteDateInversate = "Data de inceput este dupa data de sfarsit a intervalului!!!";
		public const string alertAdaugaAbsenteInceput = "Data de inceput este continuta intr-un interval de absente!!!";
		public const string alertAdaugaAbsenteSfarsit = "Data de sfarsit este continuta intr-un interval de absente!!!";
		public const string alertAdaugaAbsenteInceputSfarsit = "Data de inceput si cea de sfarsit sunt continute intr-un interval de absente!!!";
		public const string alertAdaugaAbsenteContineInterval = "Intervalul introdus contine intervale de absente deja existente!!!";
		public const string alertAdaugaAbsenteContineZileLucrate = "Intervalul introdus contine zile pontate ca lucrate!!!";
		public const string alertAdaugaIntervaleOreSuprapusAbsenta = "Intervalul orar introdus se afla intr-o zi de absenta!!!";
		public const string alertAdaugaIntervaleOreSuprapusIntrerupere = "Intervalul orar introdus se afla intr-o intrerupere de contract!!!";
		public const string alertAdaugaIntervaleOreDupaTerminare = "Intervalul orar introdus este in afara perioadei contractului de munca!!!";
		public const string alertAdaugaIntervaleOreSaptamanaDepasire = "Intervalul orar introdus duce la depasirea numarului de ore admins pt o saptamana. Prin urmare data de sfarsit a fost modelata corespunzator!!!";

		public const string alertAdaugaIntreruperiInceput = "Data de inceput este continuta intr-un interval de intreruperi de contracte!!!";
		public const string alertAdaugaIntreruperiSfarsit = "Data de sfarsit este continuta intr-un interval de intreruperi de contracte!!!";
		public const string alertAdaugaIntreruperiInceputSfarsit = "Data de inceput si cea de sfarsit sunt continute intr-un interval de intreruperi de contracte!!!";
		public const string alertAdaugaIntreruperiContineInterval = "Intervalul introdus contine intervale de intreruperi de contracte deja existente!!!";
		
		public const string alertContinuareAbsentaMedicala = "Continuarea absentei medicale nu se poate lega de concediul medical!!!";
		public const string alertMedieZilnicaIncorecta = "Media zilnica trebuie sa aiba o valoare numerica pozitiva diferita de zero!";
		public const string alertSerieConecdiuMedical = "Nu ati completat valoarea pentru seria concediului medical!";
		public const string alertNumarConecdiuMedical = "Nu ati completat valoarea pentru numarul concediului medical!";

		public const string alertAdaugaCODepasireZileAn = "Concediul de odihna introdus duce la depasirea numarului de zile de concediu de odihna alocate pe an!!!";

		public static DateTime OraStandardDeInitializareLucru = new DateTime( DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0 );
		public static string OraStandardDeInitializareLucruString = "08:00";

		public static string []tipuriPontaje = {"lucru", "absente", "intreruperi"};

		public static string []tipuriPontajeText = {"Ore lucrate", "Absente/Delegatii/Emergency service", "Intreruperi contracte munca"};

		public static int oraStartZi = 6;
		public static int oraEndZi = 22;
		#endregion

		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public Definitions()
		{}
		#endregion
	}
}
