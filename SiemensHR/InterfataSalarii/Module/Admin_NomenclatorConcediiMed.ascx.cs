using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data.SqlClient;

using Salaries.Business;
using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for Admin_NomenclatorConcediiMed.
	/// </summary>
	public class Admin_NomenclatorConcediiMed :  SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.Button btnAdauga;
		protected System.Web.UI.WebControls.Button btnModificaDate;
		protected System.Web.UI.WebControls.Button btnStergeDate;
		protected System.Web.UI.WebControls.Literal errorLit;
		protected System.Web.UI.WebControls.TextBox txtValMinimAngajati;
		protected System.Web.UI.WebControls.TextBox txtValMaximAngajati;
		protected System.Web.UI.WebControls.TextBox txtNrZilePlatite;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.ValidationSummary vldSummary;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqVldNrMinAngajati;
		protected System.Web.UI.WebControls.RegularExpressionValidator regExprVldNrMinAngajati;
		protected System.Web.UI.WebControls.RegularExpressionValidator regExprVldNrMaxAngajati;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqVldNrMaxAngajati;
		protected System.Web.UI.WebControls.RegularExpressionValidator regExprVldNrZilePlatite;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqVldNrZilePlatite;
		protected System.Web.UI.WebControls.TextBox txtIdCriteriu;
		protected System.Web.UI.WebControls.Label lblCmpObligatoriu1;
		protected System.Web.UI.WebControls.Label lblCmpObligatoriu2;
		protected System.Web.UI.WebControls.Label lblCmpObligatoriu3;
		protected System.Web.UI.WebControls.Label lblCmpObl;
		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			errorLit.Text="";
			string script_text = "<script>var ctrlID = \""+this.ClientID+"\"</script>";
			Response.Write(script_text);
			Response.Write("<script>var regExprVldNrMinAngajatiClientID = \""+regExprVldNrMinAngajati.ClientID+"\"</script>");
			Response.Write("<script>var reqVldNrMinAngajatiClientID = \""+reqVldNrMinAngajati.ClientID+"\"</script>");
			Response.Write("<script>var regExprVldNrMaxAngajatiClientID = \""+regExprVldNrMaxAngajati.ClientID+"\"</script>");
			Response.Write("<script>var reqVldNrMaxAngajatiClientID = \""+reqVldNrMaxAngajati.ClientID+"\"</script>");
			Response.Write("<script>var regExprVldNrZilePlatiteClientID = \""+regExprVldNrZilePlatite.ClientID+"\"</script>");
			Response.Write("<script>var reqVldNrZilePlatiteClientID = \""+reqVldNrZilePlatite.ClientID+"\"</script>");
		
			btnStergeDate.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta inregistrare?')");

			string[] textTabs = {"Concedii medicale", "Adauga"};
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "../", true);

			LoadConcediiMedicale();

			txtIdCriteriu.Style.Add("display","none");
		}
		#endregion

		#region LoadConcediiMedicale
		/// <summary>
		/// Listeaza concediile medicale
		/// </summary>
		private void LoadConcediiMedicale()
		{
			errorLit.Text="";
			try
			{
				DataSet dsConcediiMedicale = new DataSet();
				Salaries.Business.NomenclatorConcediiMedicale nomenclatorConcediiMedicale = new NomenclatorConcediiMedicale();
				dsConcediiMedicale = nomenclatorConcediiMedicale.GetConcediiMedicale();

				listTable.Rows.Clear();
				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");
				
				string[] arHeader = {"Nr. minim angajati", "Nr. maxim angajati","Nr. zile platite"};
				string[] arCols = { "ValMinimAngajati", "ValMaximAngajati","NrZilePlatite"};
				ListTable objListTable = new ListTable(listTable, dsConcediiMedicale, arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista concedii medicale!";

				string[] ar_OnClickParam = {"id_Criteriu", "ValMinimAngajati", "ValMaximAngajati","NrZilePlatite"};
				string[] ar_OnClickParamType = {"dataset", "dataset", "dataset","dataset"};
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectFunctie";

				objListTable.DrawListTableWithoutDigits();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}	
		}
		#endregion

		#region btnSaveSarbatoriLegale_Click
		/// <summary>
		/// Salveaza un tip de concediu medical
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSaveSarbatoriLegale_Click(object sender, System.EventArgs e)
		{
			errorLit.Text="";
			try
			{
				Salaries.Business.NomenclatorConcediiMedicale concediuMedical = new NomenclatorConcediiMedicale();
				
				concediuMedical.ValMinimAngajati = Convert.ToInt32(txtValMinimAngajati.Text);
				concediuMedical.ValMaximAngajati = Convert.ToInt32(txtValMaximAngajati.Text);

				if((concediuMedical.CheckInsertConcediuMedical()==0)&&(concediuMedical.ValMinimAngajati <= concediuMedical.ValMaximAngajati))
				{
					concediuMedical.Insert(Convert.ToInt32(txtValMinimAngajati.Text), Convert.ToInt32(txtValMaximAngajati.Text),Convert.ToInt32(txtNrZilePlatite.Text));
					
					LoadConcediiMedicale();
				}
				else
				{
					Response.Write( "<script>alert( 'Datele introduse sunt incorecte!!!' );</script>" );
				}

			}
			catch(Exception ex)
			{
				errorLit.Text="Adaugarea esuata!!!"+ex.Message;
			}
		}
		#endregion 

		#region btnUpdateSarbatoriLegale_Click
		/// <summary>
		/// Actualizeaza un tip de concediu medical
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUpdateSarbatoriLegale_Click(object sender, System.EventArgs e)
		{
			errorLit.Text="";
			try
			{
				Salaries.Business.NomenclatorConcediiMedicale concediuMedical = new NomenclatorConcediiMedicale();
				
				concediuMedical.Id_Criteriu = Convert.ToInt32(txtIdCriteriu.Text);
				concediuMedical.ValMinimAngajati = Convert.ToInt32(txtValMinimAngajati.Text);
				concediuMedical.ValMaximAngajati = Convert.ToInt32(txtValMaximAngajati.Text);
				concediuMedical.NrZilePlatite = Convert.ToInt32(txtNrZilePlatite.Text);

				if((concediuMedical.CheckInsertConcediuMedical()== 0)&&(concediuMedical.ValMinimAngajati <= concediuMedical.ValMaximAngajati))
				{
					concediuMedical.Update();
					
					LoadConcediiMedicale();
				}
				else
				{
					Response.Write( "<script>alert( 'Datele introduse sunt incorecte!!!' );</script>" );
				}
			}
			catch(Exception ex)
			{
				errorLit.Text="Editarea esuata!!!"+ex.Message;
			}
		}
		#endregion

		#region btnDelete_Click
		/// <summary>
		/// Sterge un tip de concediu medical
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			errorLit.Text="";
			try
			{
				Salaries.Business.NomenclatorConcediiMedicale concediuMedical = new NomenclatorConcediiMedicale();
				concediuMedical.Id_Criteriu = Convert.ToInt32(txtIdCriteriu.Text);

				if (concediuMedical.CheckIfConcediuMedicalCanBeDeleted(concediuMedical.Id_Criteriu))
				{
					concediuMedical.Delete();
				}
				else
				{
					Response.Write("<script>alert('Operatiunea nu a fost efectuata deoarece nomenclatoul trebuie sa contina cel putin un criteriu de acordare a concediului medical.');</script>");
				}
				
				LoadConcediiMedicale();
			}
			catch(Exception ex)
			{
				errorLit.Text="Stergerea esuata!!!"+ex.Message;
			}
		}
		#endregion

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnAdauga.Click += new System.EventHandler(this.btnSaveSarbatoriLegale_Click);
			this.btnModificaDate.Click += new System.EventHandler(this.btnUpdateSarbatoriLegale_Click);
			this.btnStergeDate.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion		
	}
}

