using System;
using System.Data;
using System.Data.SqlClient;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for Coeficienti.
	/// </summary>
	public sealed class Coeficienti : Salaries.Business.BizObject
	{
		#region Atribute private
		private Configuration.ModuleSettings settings;
		private int setID;
		private DateTime deLa;
		private decimal deducere;
		private decimal coefInvalidGrd1;
		private decimal coefInvalidGrd2;
		private decimal coefCopil12;
		private decimal coefCopil3;
		private decimal coefUrmCopil;
		private decimal coefSot;
		private decimal coefTotal;
		private decimal coefSanatate;
		private decimal coefPensie;
		private decimal coefSomaj;
		private decimal coefCheltProf;
		private decimal cASAngajator;
		private decimal sanatateAngajator;
		private decimal somajAngajator;
		private decimal fondRiscAngajator;
		private bool cartiCameraMunca;
		private decimal cartiCamera;
		private decimal cartiAngajator;
		#endregion

		#region Proprietati
		public int SetID
		{
			get { return setID;}
		}

		public DateTime DeLa
		{
			get { return deLa; }
			set { deLa = value; }
		}

		public decimal Deducere
		{
			get { return deducere; }
			set { deducere = value; }
		}

		public decimal CoefInvalidGrd1
		{
			get { return coefInvalidGrd1; }
			set { coefInvalidGrd1 = value; }
		}

		public decimal CoefInvalidGrd2
		{
			get { return coefInvalidGrd2; }
			set { coefInvalidGrd2 = value; }
		}

		public decimal CoefCopil12
		{
			get { return coefCopil12; }
			set { coefCopil12 = value; }
		}

		public decimal CoefCopil3
		{
			get { return coefCopil3; }
			set { coefCopil3 = value; }
		}

		public decimal CoefUrmCopil
		{
			get { return coefUrmCopil; }
			set { coefUrmCopil = value; }
		}

		public decimal CoefSot
		{
			get { return coefSot; }
			set { coefSot = value; }
		}

		public decimal CoefTotal
		{
			get { return coefTotal; }
			set { coefTotal = value; }
		}

		public decimal CoefSanatate
		{
			get { return coefSanatate; } 
			set { coefSanatate = value; }
		}

		public decimal CoefPensie
		{
			get { return coefPensie; }
			set { coefPensie = value; }
		}

		public decimal CoefSomaj
		{
			get { return coefSomaj; }
			set { coefSomaj = value; }
		}

		public decimal CoefCheltProf
		{
			get { return coefCheltProf;}
			set { coefCheltProf = value; }
		}

		public decimal CASAngajator
		{
			get { return cASAngajator; }
			set { cASAngajator = value; }
		}

		public decimal SanatateAngajator
		{
			get { return sanatateAngajator; }
			set { sanatateAngajator = value; }
		}

		public decimal SomajAngajator
		{
			get { return somajAngajator; }
			set { somajAngajator = value; }
		}

		public decimal FondRiscAngajator
		{
			get { return fondRiscAngajator; }
			set { fondRiscAngajator = value; }
		}

		public bool CartiCameraMunca
		{
			get { return cartiCameraMunca; }
			set { cartiCameraMunca = value; }
		}

		public decimal CartiCamera
		{
			get { return cartiCamera; }
			set { cartiCamera = value; }
		}

		public decimal CartiAngajator
		{
			get { return cartiAngajator; }
			set { cartiAngajator = value; }
		}
		#endregion

		#region Coeficienti
		/// <summary>
		/// Constructor
		/// </summary>
		public Coeficienti()
		{
			settings = Configuration.ModuleConfig.GetSettings();
			ResetCoeficienti();
		}
		#endregion

		#region Coeficienti
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="timp"></param>
		public Coeficienti(DateTime timp)
		{
			settings = Configuration.ModuleConfig.GetSettings();
			deLa = timp;
			LoadCoeficientiCurenti();
		}
		#endregion

		#region ResetCoeficienti
		/// <summary>
		/// Procedura reseteaza coeficientii
		/// </summary>
		private void ResetCoeficienti()
		{
			setID = -1;
			deLa = DateTime.MinValue;
			deducere = 0;
			coefInvalidGrd1 = 0;
			coefInvalidGrd2 = 0;
			coefCopil12 = 0;
			coefCopil3 = 0;
			coefUrmCopil = 0;
			coefSot = 0;
			coefTotal = 0;
			coefSanatate = 0;
			coefPensie = 0;
			coefSomaj = 0;
			coefCheltProf = 0;
			cASAngajator = 0;
			sanatateAngajator = 0;
			somajAngajator = 0;
			fondRiscAngajator = 0;
			cartiCameraMunca = false;
			cartiCamera = 0;
			cartiAngajator = 0;
		}
		#endregion

		#region LoadCoeficientiCurenti
		/// <summary>
		/// Procedura selecteaza coeficientii curenti
		/// </summary>
		private void LoadCoeficientiCurenti()
		{
			Data.Coeficienti coeficienti = new Data.Coeficienti(settings.ConnectionString);
			Data.DetaliiCoeficienti detalii = coeficienti.GetDetalii(deLa);
			setID = detalii.SetID;
			deducere = detalii.Deducere;
			coefInvalidGrd1 = detalii.CoefInvalidGrd1;
			coefInvalidGrd2 = detalii.CoefInvalidGrd2;
			coefCopil12 = detalii.CoefCopil12;
			coefCopil3 = detalii.CoefCopil3;
			coefUrmCopil = detalii.CoefUrmCopil;
			coefSot = detalii.CoefSot;
			coefTotal = detalii.CoefTotal;
			coefSanatate = detalii.CoefSanatate;
			coefPensie = detalii.CoefPensie;
			coefSomaj = detalii.CoefSomaj;
			coefCheltProf = detalii.CoefCheltProf;
			cASAngajator = detalii.CASAngajator;
			sanatateAngajator = detalii.SanatateAngajator;
			somajAngajator = detalii.SomajAngajator;
			fondRiscAngajator = detalii.FondRiscAngajator;
			cartiCameraMunca = detalii.CartiCameraMunca;
			cartiCamera = detalii.CartiCamera;
			cartiAngajator = detalii.CartiAngajator;
		}
		#endregion

		#region LoadCoeficientiID
		/// <summary>
		/// Procedura selecteaza detaliile unor coeficienti
		/// </summary>
		private void LoadCoeficientiID()
		{
			Data.Coeficienti coeficienti = new Data.Coeficienti(settings.ConnectionString);
			Data.DetaliiCoeficienti detalii = coeficienti.GetDetalii(setID);
			deLa = detalii.DeLa;
			deducere = detalii.Deducere;
			coefInvalidGrd1 = detalii.CoefInvalidGrd1;
			coefInvalidGrd2 = detalii.CoefInvalidGrd2;
			coefCopil12 = detalii.CoefCopil12;
			coefCopil3 = detalii.CoefCopil3;
			coefUrmCopil = detalii.CoefUrmCopil;
			coefSot = detalii.CoefSot;
			coefTotal = detalii.CoefTotal;
			coefSanatate = detalii.CoefSanatate;
			coefPensie = detalii.CoefPensie;
			coefSomaj = detalii.CoefSomaj;
			coefCheltProf = detalii.CoefCheltProf;
			cASAngajator = detalii.CASAngajator;
			sanatateAngajator = detalii.SanatateAngajator;
			somajAngajator = detalii.SomajAngajator;
			fondRiscAngajator = detalii.FondRiscAngajator;
			cartiCameraMunca = detalii.CartiCameraMunca;
			cartiCamera = detalii.CartiCamera;
			cartiAngajator = detalii.CartiAngajator;
		}
		#endregion

		#region LoadCoeficientiID
		/// <summary>
		/// Procedura selecteaza valoarea coeficientului cu un id anume
		/// </summary>
		/// <param name="existingID">Id-ul coeficientului existent</param>
		/// <returns>Returneaza valoarea coeficientului</returns>
		private int LoadCoeficientiID(int existingID)
		{
			setID = existingID;
			LoadCoeficientiID();
			return setID;
		}
		#endregion

		#region Create
		/// <summary>
		/// Procdura creaza o categorie de coeficienti
		/// </summary>
		/// <param name="deLa"></param>
		/// <param name="deducere"></param>
		/// <param name="coefInvalidGrd1"></param>
		/// <param name="coefInvalidGrd2"></param>
		/// <param name="coefCopil12"></param>
		/// <param name="coefCopil3"></param>
		/// <param name="coefUrmCopil"></param>
		/// <param name="coefSot"></param>
		/// <param name="coefTotal"></param>
		/// <param name="coefSanatate"></param>
		/// <param name="coefPensie"></param>
		/// <param name="coefSomaj"></param>
		/// <param name="coefCheltProf"></param>
		/// <param name="casAngajator"></param>
		/// <param name="sanatateAngajator"></param>
		/// <param name="somajAngajator"></param>
		/// <param name="fondRiscAngajator"></param>
		/// <param name="cartiCameraMunca"></param>
		/// <param name="cartiCamera"></param>
		/// <param name="cartiAngajator"></param>
		/// <returns></returns>
		public int Create(DateTime deLa, decimal deducere, decimal coefInvalidGrd1,
			decimal coefInvalidGrd2, decimal coefCopil12, decimal coefCopil3, decimal coefUrmCopil, 
			decimal coefSot, decimal coefTotal, decimal coefSanatate, decimal coefPensie,
			decimal coefSomaj, decimal coefCheltProf, decimal casAngajator,
			decimal sanatateAngajator, decimal somajAngajator, decimal fondRiscAngajator,
			bool cartiCameraMunca, decimal cartiCamera, decimal cartiAngajator)
		{
			Data.Coeficienti coeficienti = new Data.Coeficienti(settings.ConnectionString);
			setID = coeficienti.Add(deLa,  deducere,  coefInvalidGrd1,
									coefInvalidGrd2,  coefCopil12,  coefCopil3,  coefUrmCopil, 
									coefSot,  coefTotal,  coefSanatate,  coefPensie,
									coefSomaj,  coefCheltProf,  casAngajator,
									sanatateAngajator,  somajAngajator,  fondRiscAngajator,
									cartiCameraMunca,  cartiCamera,  cartiAngajator);
			LoadCoeficientiID();
			return setID;
		}
		#endregion

		#region Update
		/// <summary>
		/// Procedura actualizeaza o categorie de coeficienti
		/// </summary>
		/// <returns>Returneaza true daca s-a facut actualizarea si false altfel</returns>
		public bool Update()
		{
			Data.Coeficienti coeficienti = new Data.Coeficienti(settings.ConnectionString);
			return coeficienti.Update(setID, deLa, deducere, coefInvalidGrd1, coefInvalidGrd2, coefCopil12,
				coefCopil3, coefUrmCopil, coefSot, coefTotal, coefSanatate, coefPensie, coefSomaj,
				coefCheltProf, cASAngajator, sanatateAngajator, somajAngajator, fondRiscAngajator,
				cartiCameraMunca, cartiCamera, cartiAngajator);
		}
		#endregion
	
		#region GetCoeficienti
		/// <summary>
		/// Procedura selecteaza coeficienti
		/// </summary>
		/// <returns>Returneaza un DataSet care contine aceste date</returns>
		public  DataSet GetCoeficienti()
		{
			Data.Coeficienti coeficienti=new Data.Coeficienti(settings.ConnectionString);
			return coeficienti.GetCoeficienti();
		}
		#endregion

		#region GetCoefPtDeducere
		/// <summary>
		/// Procedura selecteaza coeficientul pentru deducere
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public decimal GetCoefPtDeducere(short val)
		{
			decimal retVal=0;
			switch (val)
			{				
				case 1: retVal= CoefInvalidGrd1;
					    break;
				case 2: retVal= CoefInvalidGrd2;
						break;
			}
			return retVal;
		}
		#endregion
	}
}
