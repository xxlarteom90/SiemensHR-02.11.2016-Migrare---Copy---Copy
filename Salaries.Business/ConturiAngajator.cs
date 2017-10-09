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
	public class ConturiAngajator: Salaries.Business.BizObject
	{
		#region Atribute private
		private Configuration.ModuleSettings settings;
		// ID-ul contului.
		private int contId;
		// ID-ul angajatorului.
		private int angajatorId;
		// ID-ul bancii.
		private int bancaId;
		// Numar cont format vechi.
		private string numarContVechi;
		// Numar cont in format IBAN.
		private string numarContIBAN;
		// Moneda in care a fost deschis contul.
		private string moneda;
		// Starea contului: activ - true, inactiv - false.
		private bool activ;
		#endregion
		
		#region Constructor
	
		/// <summary>
		/// Constructor.
		/// </summary>
		public ConturiAngajator()
		{
			// Sunt preluate setarile(stringul de conexiune la baza de date, etc).
			settings = Configuration.ModuleConfig.GetSettings();
		}
		#endregion

		#region Properies

		/// <summary>
		/// ID-ul contului.
		/// </summary>
		public int ContId
		{
			get
			{
				return contId;
			}

			set
			{
				contId = value;
			}
		}

		/// <summary>
		/// ID-ul angajatorului.
		/// </summary>
		public int AngajatorId
		{
			get
			{
				return angajatorId;
			}

			set
			{
				angajatorId = value;
			}
		}

		/// <summary>
		/// ID-ul bancii de care apartine contul.
		/// </summary>
		public int BancaId
		{
			get
			{
				return bancaId;
			}

			set
			{
				bancaId = value;
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

		#region Insert
		/// <summary>
		/// Este inserat in baza de date un cont bancar al unui angajator.
		/// </summary>
		/// <returns> Returneaza 0 in cazul in care inserarea s-a facut cu succes, 
		/// un intreg diferit de 0, altfel. </returns>
		public int Insert()
		{
			return new Salaries.Data.ConturiAngajator(settings.ConnectionString).Insert(
				angajatorId, bancaId,numarContVechi, numarContIBAN, moneda, activ);
		}
		#endregion

		#region Update
		/// <summary>
		/// Modifica un cont bancar al unui angajator.  
		/// </summary>
		/// <returns> Returneaza 0 in cazul in care modificarea s-a facut cu succes, 
		/// un intreg diferit de 0, altfel. </returns>
		public int Update()
		{
			return new Salaries.Data.ConturiAngajator(settings.ConnectionString).Update( 
				contId, angajatorId, bancaId, numarContVechi, numarContIBAN, moneda, activ);
		}
		#endregion
	
		#region Delete
		/// <summary>
		/// Sterge din baza de date un cont bancar al unui angajator.  
		/// </summary>
		/// <returns> Returneaza 0 in cazul in care stergerea s-a facut cu succes, 
		/// un intreg diferit de 0, altfel. </returns>
		public int Delete()
		{
			return new Salaries.Data.ConturiAngajator(settings.ConnectionString).Delete(contId);
		}
		#endregion
		
		#region GetConturiBancareAngajator
		/// <summary>
		/// Returneaza toate conturile bancare ale angajatorului.
		/// </summary>
		/// <returns> Un DataSet cu toate datele aferente conturilor bancare ale angajatorului.
		/// </returns>
		public DataSet GetConturiBancareAngajator()
		{
			return new Salaries.Data.ConturiAngajator(settings.ConnectionString).GetConturiBancareAngajator(angajatorId);
		}
		#endregion

		#region GetConturiBancareActiveAngajator
		/// <summary>
		/// Returneaza toate conturile bancare active ale angajatorului.
		/// </summary>
		/// <returns> Un DataSet cu toate datele aferente conturilor bancare active ale angajatorului.
		/// </returns>
		public DataSet GetConturiBancareActiveAngajator()
		{
			return new Salaries.Data.ConturiAngajator(settings.ConnectionString).GetConturiBancareActiveAngajator(angajatorId);
		}
		#endregion

		#region DeleteConturiAngajator
		/// <summary>
		/// Sunt sterse toate conturile angajatorului.
		/// </summary>
		/// <returns> Returneaza 0 in cazul in care stergerea s-a facut cu succes, 
		/// un intreg diferit de 0, altfel. </returns>
		public int DeleteConturiAngajator()
		{
			return new Salaries.Data.ConturiAngajator(settings.ConnectionString).DeleteConturiAngajator(angajatorId);
		}

		#endregion

		#region GetMonedaConturiAngajati
		/// <summary>
		/// Returneaza tipurile de monede in care au angajatii deschise conturi.
		/// </summary>
		/// <returns> Un DataSet cu lista monede.</returns>
		public DataSet GetMonedaConturiAngajati()
		{
			return new Salaries.Data.ConturiAngajator(settings.ConnectionString).GetMonedaConturiAngajati(angajatorId);
		}
		#endregion
	}
}
