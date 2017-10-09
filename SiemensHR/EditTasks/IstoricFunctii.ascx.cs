using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.EditTasks
{
	/// <summary>
	///		Summary description for IstoricFunctii.
	/// </summary>
	public class IstoricFunctii : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.TextBox txtDataStart;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataStart;
		protected System.Web.UI.WebControls.Button btnAdauga;
		protected System.Web.UI.WebControls.Button btnModificaDate;
		protected System.Web.UI.WebControls.Button btnStergeDate;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox old_DataStart;
		protected System.Web.UI.WebControls.DropDownList lstFunctie;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
		
			btnStergeDate.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta inregistrare?')");

			string[] textTabs = {"Istoric functii", "Adauga functie"};
			if (Session["Recrutori"].ToString() == "Recrutori")
			{
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "../", true);
				Response.Write("<script> var TipUtilizator = 'Recrutor'; </script>");
				this.Button1.Style.Add("display", "none");
			}
			else
			{
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);
				Response.Write("<script> var TipUtilizator = ''; </script>");
				this.Button1.Style.Add("display", "");
			}
			LoadIstoricFunctii();
			old_DataStart.Style.Add("display","none");
		}
		#endregion

		#region LoadIstoricFunctii
		/// <summary>
		/// Listeaza functiile unui angajat
		/// </summary>
		private void LoadIstoricFunctii()
		{
			try
			{
				listTable.Rows.Clear();			
				//daca toate functiile au cod Siemens atasat
				Salaries.Business.AdminFunctii functie = new Salaries.Business.AdminFunctii();
				if(functie.CheckIfToateFunctiileAuCodSiemens())
				{
					//este afisat in dropdownlist codul Siemens - numele functiei
					lstFunctie.DataSource = functie.LoadInfoCodSiemensNumeFunctie();
				}
				//altfel
				else
				{
					//este afisat in dropdownlist codul COR - numele functiei
					lstFunctie.DataSource = functie.LoadInfoCodCORNumeFunctie();
				}
				lstFunctie.DataValueField = "FunctieID";
				lstFunctie.DataTextField = "CodNume";
				lstFunctie.DataBind();		

				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

				Salaries.Business.IstoricFunctie istFunctie = new Salaries.Business.IstoricFunctie();
				istFunctie.AngajatId = AngajatID;
				
				string[] arHeader = {"Functie", "Norma lucru", "Data start"};
				string[] arCols = {"Nume", "NormaLucru", "DataStart"};
				ListTable objListTable = new ListTable(listTable, istFunctie.LoadIstoricFunctii(), arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista nici o functie asociata acestui angajat!";

				string[] ar_OnClickParam = {"FunctieID", "DataStart", AngajatID.ToString()};
				string[] ar_OnClickParamType = {"dataset", "dataset", "const"};
			
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
			this.btnAdauga.Click += new System.EventHandler(this.btnAdauga_Click);
			this.btnModificaDate.Click += new System.EventHandler(this.btnModificaDate_Click);
			this.btnStergeDate.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdauga_Click
		/// <summary>
		/// Adauga o functie
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdauga_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricFunctie istFunctie = new Salaries.Business.IstoricFunctie();
				istFunctie.AngajatId = AngajatID;
				istFunctie.FunctieId = Convert.ToInt32(lstFunctie.SelectedValue);
				istFunctie.DataStartNoua = Utilities.ConvertText2DateTime(txtDataStart.Text);

				if (istFunctie.CheckIfIstoricFunctiiCanBeAdded())
				{
					if (istFunctie.CheckIfFunctiaCoincideCuIncadrarea())
						istFunctie.InsertFunctie();
					else
						Response.Write("<script> alert('Noua functie nu coincide cu incadrarea angajatului (scutit/nescutit de impozit)!'); </script>");
				}
				else
				{
					Response.Write("<script> alert('Mai exista o inregistrare cu acesta data!'); </script>");
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadIstoricFunctii();
		}
		#endregion

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica o functie
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click(object sender, System.EventArgs e)
		{
			try
			{	
				Salaries.Business.IstoricFunctie istFunctie = new Salaries.Business.IstoricFunctie();
				istFunctie.AngajatId = AngajatID;
				istFunctie.FunctieId = Convert.ToInt32(lstFunctie.SelectedValue);
				istFunctie.DataStartNoua = Utilities.ConvertText2DateTime(txtDataStart.Text);
				istFunctie.DataStartVeche = Utilities.ConvertText2DateTime(old_DataStart.Text);

				//daca data ramane aceeasi nu se mai verifica pentru duplicate
				if (istFunctie.DataStartNoua == istFunctie.DataStartVeche)
				{
					istFunctie.UpdateFunctie();
				}
				//daca se modifica data se verifica sa nu existe duplicate
				else
				{
					if (istFunctie.CheckIfIstoricFunctiiCanBeAdded())
					{
						istFunctie.UpdateFunctie();
					}
					else
					{
						Response.Write("<script> alert('Mai exista o inregistrare cu acesta data!'); </script>");
					}
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadIstoricFunctii();
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge o functie
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricFunctie istFunctie = new Salaries.Business.IstoricFunctie();
				istFunctie.AngajatId = AngajatID;
				istFunctie.FunctieId = Convert.ToInt32(lstFunctie.SelectedValue);
				istFunctie.DataStartNoua = Utilities.ConvertText2DateTime(txtDataStart.Text);
				istFunctie.DataStartVeche = Utilities.ConvertText2DateTime(old_DataStart.Text);

				istFunctie.DeleteFunctie();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadIstoricFunctii();
		}
		#endregion
	}
}
