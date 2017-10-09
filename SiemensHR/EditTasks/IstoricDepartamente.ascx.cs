using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

using SiemensHR.Classes;
using SiemensHR.utils;

namespace SiemensHR
{
	/// <summary>
	///		Summary description for IstoricDepartamente.
	/// </summary>
	public class IstoricDepartamente : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.DropDownList lstDepartament;
		protected System.Web.UI.WebControls.TextBox txtDataStart;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataStart;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Image imgSpace;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.Button btnAdauga;
		protected System.Web.UI.WebControls.Button btnModifica;
		protected System.Web.UI.WebControls.Button btnSterge;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;

		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			LoadFormIstoricDepartamente();

			btnSterge.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta inregistrare?')");

			string[] textTabs = {"Istoric departamente", "Adauga departament"};
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
		}
		#endregion

		#region LoadFormIstoricDepartamente
		/// <summary>
		/// Listeaza departamentele angajatului
		/// </summary>
		private void LoadFormIstoricDepartamente()
		{
			try
			{
				listTable.Rows.Clear();
				lstDepartament.Items.Clear();

				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);
				utilDb.CreateDepartamenteSelectBox(0, 0, lstDepartament);

				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

				Salaries.Business.IstoricDepartament istDept = new Salaries.Business.IstoricDepartament();
				istDept.AngajatId = AngajatID;
				
				string[] arHeader = {"Departament", "Data start"};
				string[] arCols = {"DenumireCompleta", "DataStart"};
				ListTable objListTable = new ListTable(listTable, istDept.LoadIstoricDepartament(), arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista nici un departament asociat acestui angajat!";

				string[] ar_OnClickParam = {"DepartamentID", "DataStart", AngajatID.ToString()};
				string[] ar_OnClickParamType = {"dataset", "dataset", "const"};
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectDepartament";

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
			this.btnAdauga.Click += new System.EventHandler(this.btnAdaugaDepartament_Click);
			this.btnModifica.Click += new System.EventHandler(this.btnModificaDate_Click);
			this.btnSterge.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdaugaDepartament_Click
		/// <summary>
		/// Adauga un departament
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaDepartament_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricDepartament istDept = new Salaries.Business.IstoricDepartament();
				istDept.AngajatId = AngajatID;
				istDept.DepartamentId = Convert.ToInt32(lstDepartament.SelectedValue);
				istDept.DataStartNoua = Utilities.ConvertText2DateTime(txtDataStart.Text);

				if (istDept.CheckIfDepartamentCanBeAdded())
				{
					istDept.InsertDepartament();
					lstDepartament.SelectedIndex = 0;
					txtDataStart.Text = "";
				}
				else
				{
					Response.Write("<script> alert('Pentru aceasta data exista deja un departament!'); </script>");
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadFormIstoricDepartamente();
		}
		#endregion

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica un departament
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricDepartament istDept = new Salaries.Business.IstoricDepartament();
				istDept.AngajatId = AngajatID;
				istDept.DepartamentId = Convert.ToInt32(lstDepartament.SelectedValue);
				istDept.DataStartVeche = Utilities.ConvertText2DateTime(Request.Form["old_DataStart"].ToString());
				istDept.DataStartNoua = Utilities.ConvertText2DateTime(txtDataStart.Text);

				if (istDept.DataStartVeche == istDept.DataStartNoua)
				{
					istDept.UpdateDepartament();
				}
				else
				{
					if (istDept.CheckIfDepartamentCanBeAdded())
					{
						istDept.UpdateDepartament();
						lstDepartament.SelectedIndex = 0;
						txtDataStart.Text = "";
					}
					else
					{
						Response.Write("<script> alert('Pentru aceasta data exista deja un departament!'); </script>");
					}
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadFormIstoricDepartamente();
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge un departament
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricDepartament istDept = new Salaries.Business.IstoricDepartament();
				istDept.AngajatId = AngajatID;
				istDept.DepartamentId = Convert.ToInt32(lstDepartament.SelectedValue);
				istDept.DataStartNoua = Utilities.ConvertText2DateTime(txtDataStart.Text);
				istDept.DataStartVeche = Utilities.ConvertText2DateTime(Request.Form["old_DataStart"].ToString());
				
				istDept.DeleteDepartament();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadFormIstoricDepartamente();
		}
		#endregion
	}
}
