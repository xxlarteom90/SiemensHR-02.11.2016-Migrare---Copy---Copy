using System;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for SituatieLunaraAngajati.
	/// </summary>
	public class SituatieLunaraAngajati
	{
		private int lunaID;
		private int angajatorID;

		public SituatieLunaraAngajati(int angajatorId, int lunaID)
		{
			this.lunaID = lunaID;
			this.angajatorID = angajatorID;
		}
		
		
	}
}
