using System;

namespace SiemensHR.InterfataSalarii.Classes
{
	/// <summary>
	/// Summary description for Definitions.
	/// </summary>
	public class Definitions
	{
		#region Variabile
		public static string LunaCurentaKey="LunaCurenta";
		public static string AngajatorKey="AngajatorID";
		public static string AngajatKey ="AngajatID";

		public static string AlertStergereTipOraLucruImposibila = "Acest tip de ora de lucru nu poate fi sters!";
		public static string AlertStergereTipAbsentaImposibila = "Acest tip de absenta nu poate fi sters!";

		public static int NrOreNormaStandard = 8;
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
