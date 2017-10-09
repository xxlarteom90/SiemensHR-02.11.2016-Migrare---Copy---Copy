using System;
using System.Data;

namespace Salaries.Business
{
	/// <summary>
	/// Summary description for Impozitar.
	/// </summary>
	public class Impozitar_anual : Salaries.Business.BizObject
	{
		private Configuration.ModuleSettings settings;

		private int id;
		private decimal valMin;
		private decimal valMax;
		private decimal suma;
		private decimal procent;
		private System.DateTime data;
		private int categorieId;

		public Impozitar_anual()
		{
			settings = Configuration.ModuleConfig.GetSettings();
			ResetImpozitar();
		}

		public Impozitar_anual(DateTime timp,decimal suma,int categorieId)
		{
			settings = Configuration.ModuleConfig.GetSettings();
			data = timp;
			LoadImpozitarCurent(suma,categorieId);
		}

		public Impozitar_anual(int id)
		{
			settings = Configuration.ModuleConfig.GetSettings();
			this.id=id;
			LoadImpozitarID();
		}

		private void ResetImpozitar()
		{
			id = -1;
			data = DateTime.MinValue;
			valMin=0;
			valMax=0;
			suma=0;		
			procent=0;
			categorieId=0;
		}

		private void LoadImpozitarCurent(decimal suma,int categorieId)
		{
			Data.Impozitar_anual impozitar = new Data.Impozitar_anual(settings.ConnectionString);
			Data.DetaliiImpozitar_anual detalii = impozitar.GetDetalii(data,suma,categorieId);
			this.id = detalii.ID;			
			this.valMin=detalii.ValMin;		
			this.valMax=detalii.ValMax;
			this.suma=detalii.Suma;						
			this.procent=detalii.Procent;
		}

		private void LoadImpozitarID()
		{
			Data.Impozitar_anual impoz = new Data.Impozitar_anual(settings.ConnectionString);
			Data.DetaliiImpozitar_anual detalii = impoz.GetDetalii(id);
			this.data=detalii.Data;
			this.valMin=detalii.ValMin;
			this.valMax=detalii.ValMax;
			this.procent=detalii.Procent;
			this.suma=detalii.Suma;
			this.categorieId=detalii.CategorieID;
		}

		public int Create(DateTime data,decimal valMin,decimal valMax,decimal suma,decimal procent,int categorieId)
		{
			Data.Impozitar_anual impozitar = new Data.Impozitar_anual(settings.ConnectionString);
			id = impozitar.Add(data,valMin,valMax,suma,procent,categorieId);
			LoadImpozitarID();
			return id;
		}

		public bool Update()
		{
			Data.Impozitar_anual coeficienti = new Data.Impozitar_anual(settings.ConnectionString);
			return coeficienti.Update(id,data,valMin,valMax,suma,procent,categorieId);
		}

		public bool Delete()
		{
			Data.Impozitar_anual impozitar = new Data.Impozitar_anual(settings.ConnectionString);
			bool ret = impozitar.Delete(id);
			ResetImpozitar();
			return ret;
		}
		
		public  DataSet GetImpozitar(int LunaID)
		{
			Data.Impozitar_anual impoz=new Data.Impozitar_anual(settings.ConnectionString);
			return impoz.GetImpozitar(LunaID);
		}
	
		#region Properties
		public int IDImpozitar
		{
			get{return id;}
			set{id=value;}
		}
		public decimal ValMin
		{
			get{return valMin;}
			set{valMin=value;}
		}
		 
		public decimal ValMax
		{
			get{return valMax;}
			set{valMax=value;}
		}

		public decimal Suma
		{
			get	{return suma;}
			set {suma=value;}
		}

		public decimal Procent
		{
			get{return procent;}
			set{procent=value;}
		}
		
		public DateTime Data
		{
			get{return data;}
			set {data=value;}
		}

		public int CategorieID
		{
			get{ return categorieId; }
			set{ categorieId=value; }
		}

		#endregion
	}
}
