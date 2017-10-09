/*
 * Autor: Cristina Raluca Muntean
 * Data:  6.03.2005 
 */
using System;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Realizeaza toate operatiile necesare pentru administrarea conturilor angajatorului.
	/// </summary>
	public class ContAngajator: Salaries.Business.BizObject
	{
		private Configuration.ModuleSettings settings;
		
		// ID-ul contului.
		private int contID;
		// ID-ul angajatorului.
		private int angajatorID;
		// ID-ul bancii.
		private int bancaID;
		// Numar cont format vechi.
		private string numarContVechi;
		// Numar cont in format IBAN.
		private string numarContIBAN;
		// Moneda in care a fost deschis contul.
		private string moneda;
		// Starea contului: activ - true, inactiv - false.
		private bool activ;
		
		#region Constructor
	
		/// <summary>
		/// Constructor.
		/// </summary>
		public ContAngajator()
		{
			// Sunt preluate setarile(stringul de conexiune la baza de date, etc).
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Methods

		/// <summary>
		/// Este inserat in baza de date un cont bancar al unui angajator.
		/// </summary>
		/// <returns> Returneaza 0 in cazul in care inserarea s-a facut cu succes, 
		/// un intreg diferit de 0, altfel. </returns>
		public int Insert()
		{
			return new Salaries.Data.ConturiAngajator(settings.ConnectionString).Insert(
				angajatorID, bancaID,numarContVechi, numarContIBAN, moneda, activ);
		}

		/// <summary>
		/// Modifica un cont bancar al unui angajator.  
		/// </summary>
		/// <returns> Returneaza 0 in cazul in care modificarea s-a facut cu succes, 
		/// un intreg diferit de 0, altfel. </returns>
		public int Update()
		{
			return new Salaries.Data.ConturiAngajator(settings.ConnectionString).Update( 
				contID, angajatorID, bancaID, numarContVechi, numarContIBAN, moneda, activ);
		}
	
		/// <summary>
		/// Sterge din baza de date un cont bancar al unui angajator.  
		/// </summary>
		/// <returns> Returneaza 0 in cazul in care stergerea s-a facut cu succes, 
		/// un intreg diferit de 0, altfel. </returns>
		public int Delete()
		{
			return new Salaries.Data.ConturiAngajator(settings.ConnectionString).Delete(contID);
		}
		
		/// <summary>
		/// Returneaza toate conturile bancare ale angajatorului.
		/// </summary>
		/// <returns> Un DataSet cu toate datele aferente conturilor bancare ale angajatorului.
		/// </returns>
		public DataSet GetConturiBancareAngajator()
		{
			return new Salaries.Data.ConturiAngajator(settings.ConnectionString).GetConturiBancareAngajator(angajatorID);
		}

		/// <summary>
		/// Returneaza toate conturile bancare active ale angajatorului.
		/// </summary>
		/// <returns> Un DataSet cu toate datele aferente conturilor bancare active ale angajatorului.
		/// </returns>
		public DataSet GetConturiBancareActiveAngajator()
		{
			return new Salaries.Data.ConturiAngajator(settings.ConnectionString).GetConturiBancareActiveAngajator(angajatorID);
		}

		/// <summary>
		/// Sunt sterse toate conturile angajatorului.
		/// </summary>
		/// <returns> Returneaza 0 in cazul in care stergerea s-a facut cu succes, 
		/// un intreg diferit de 0, altfel. </returns>
		public int DeleteConturiAngajator()
		{
			return new Salaries.Data.ConturiAngajator(settings.ConnectionString).DeleteConturiAngajator(angajatorID);
		}

		#endregion

		#region Properies

		/// <summary>
		/// ID-ul contului.
		/// </summary>
		public int ContID
		{
			get
			{
				return contID;
			}

			set
			{
				contID = value;
			}
		}

		/// <summary>
		/// ID-ul angajatorului.
		/// </summary>
		public int AngajatorID
		{
			get
			{
				return angajatorID;
			}

			set
			{
				angajatorID = value;
			}
		}

		/// <summary>
		/// ID-ul bancii de care apartine contul.
		/// </summary>
		public int BancaID
		{
			get
			{
				return bancaID;
			}

			set
			{
				bancaID = value;
			}
		}

		/// <summary>
		/// Numarul contului in format vechi.
		/// </summary>
		public string NumarContVechi
		{
			get
			{
				return numarContVechi;
			}

			set
			{
				numarContVechi = value;
			}
		}

		/// <summary>
		/// Numarul contului in forma IBAN.
		/// </summary>
		public string NumarContIBAN
		{
			get
			{
				return numarContIBAN;
			}

			set
			{
				numarContIBAN = value;
			}
		}

		/// <summary>
		/// Moneda in care a fost deschis contul.
		/// </summary>
		public string Moneda
		{
			get
			{
				return moneda;
			}

			set
			{
				moneda = value;
			}
		}

		/// <summary>
		/// Starea contului: activ - true, inactiv - false. 
		/// Pot fi active in acelasi timp doar conturi in monede diferite.
		/// </summary>
		public bool Activ
		{
			get
			{
				return activ;
			}

			set
			{
				activ = value;
			}
		}
		#endregion
	}
}
