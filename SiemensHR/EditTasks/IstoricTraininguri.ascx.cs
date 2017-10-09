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
	///		Summary description for IstoricTraininge.
	/// </summary>
	public class IstoricTraininguri : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.TextBox txtDataStart;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.Table listTable2;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataStart;
		protected System.Web.UI.WebControls.Image imgSpace;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.TextBox txtDataEnd;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataEnd;
		protected System.Web.UI.WebControls.DropDownList lstTraining;
		protected System.Web.UI.WebControls.DropDownList lstTraining2;
		protected System.Web.UI.WebControls.DropDownList tipTraining;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.Button btnAdauga;
		protected System.Web.UI.WebControls.Button btnModifica;
		protected System.Web.UI.WebControls.Button btnSterge;
		protected System.Web.UI.WebControls.ValidationSummary Validationsummary2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden IstoricTrainingID;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;

		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			LoadFormIstoricTraining();
			
			btnSterge.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta inregistrare?')");
			
			this.tipTraining.Attributes.Add("onchange","SelectTipTraining(this.value,false)");
			
			this.tipTraining.Attributes.Add("onchange","SelectTipTraining(this.value,true)");
			
			string[] textTabs = {"Istoric training", "Adauga training la istoric"};
			if (Session["Recrutori"].ToString() == "Recrutori")
			{
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "../", true);
				Response.Write("<script> var TipUtilizator = 'Recrutor'; </script>");
				//this.Button1.Style.Add("display", "none");
			}
			else
			{
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);
				Response.Write("<script> var TipUtilizator = ''; </script>");
				this.Button1.Style.Add("display", "");
			}
		}
		#endregion

		#region LoadFormIstoricTraining
		/// <summary>
		/// Listeaza training-urile unui angajat
		/// </summary>
		private void LoadFormIstoricTraining()
		{
			try
			{
				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);
				utilDb.CreateInternalTrainingSelectBox(this.lstTraining);
				if (this.lstTraining.Items.Count==0) this.tipTraining.Items.RemoveAt(0);
				utilDb.CreateExternalTrainingSelectBox(this.lstTraining2);
				if (this.lstTraining2.Items.Count==0) this.tipTraining.Items.RemoveAt(1);				
				
				listTable.Rows.Clear();
				listTable2.Rows.Clear();
				
				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

				listTable2.Attributes.Add("width", "100%");
				listTable2.Style.Add("border","1px solid #20b2aa");
				listTable2.Attributes.Add("cellpadding", "0");
				listTable2.Attributes.Add("cellspacing", "1");

			
				Salaries.Business.IstoricTraining istTraining =  new Salaries.Business.IstoricTraining();
				istTraining.AngajatId = AngajatID;
				
				string[] arHeader = {"Tip Training","Descriere","Diploma", "Data start","Data end"};
				string[] arCols = {"Nume", "Descriere","Diploma","DataStart","DataEnd"};
				
				ListTable objListTable = new ListTable(listTable, istTraining.LoadIstoricTraining(true), arHeader, arCols);
				ListTable objListTable2 = new ListTable(listTable2, istTraining.LoadIstoricTraining(false), arHeader, arCols);
				
				objListTable.textForEmptyDataSet= "Nu exista nici un training intern asociat acestui angajat!";
				objListTable2.textForEmptyDataSet= "Nu exista nici un training extern  asociat acestui angajat!";
				
				string[] ar_OnClickParam = {"IstoricTrainingID","Intern","TrainingID", "DataStart","DataEnd",AngajatID.ToString()};
				string[] ar_OnClickParamType = {"dataset","dataset","dataset", "dataset","dataset", "const"};
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectTraining";

				objListTable2.OnclickParams = ar_OnClickParam;
				objListTable2.OnclickParamsType = ar_OnClickParamType;
				objListTable2.OnclickJSMethod = "SelectTraining";

				
				objListTable.DrawListTableWithoutDigits();
				objListTable2.DrawListTableWithoutDigits();

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
			this.btnAdauga.Click += new System.EventHandler(this.btnAdaugaTraining_Click);
			this.btnModifica.Click += new System.EventHandler(this.btnModificaDate_Click);
			this.btnSterge.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdaugaTraining_Click
		/// <summary>
		/// Adauga un training
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaTraining_Click(object sender, System.EventArgs e)
		{
			try
			{
				int TrainingID =(this.tipTraining.SelectedValue=="1")? Convert.ToInt32(lstTraining.SelectedValue): Convert.ToInt32(lstTraining2.SelectedValue);
				
				Salaries.Business.IstoricTraining istTraining = new Salaries.Business.IstoricTraining();
				istTraining.IstoricTrainingId = 0;
				istTraining.AngajatId = AngajatID;
				istTraining.TrainingId = TrainingID;
				istTraining.DataStart = Utilities.ConvertText2DateTime(txtDataStart.Text);
				istTraining.DataEnd = Utilities.ConvertText2DateTime(txtDataEnd.Text);
				istTraining.InsertIstoricTraining();

				tipTraining.SelectedIndex = 0;
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadFormIstoricTraining();
		}
		#endregion

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica un training
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click(object sender, System.EventArgs e)
		{
			try
			{	
				bool tipTraining = this.tipTraining.SelectedValue=="1";
				Salaries.Business.IstoricTraining istTraining = new Salaries.Business.IstoricTraining();
				istTraining.IstoricTrainingId = int.Parse(this.IstoricTrainingID.Value);
				istTraining.AngajatId = AngajatID;
				istTraining.TrainingId = (tipTraining) ? Convert.ToInt32(lstTraining.SelectedValue):Convert.ToInt32(lstTraining2.SelectedValue);
				istTraining.DataStart = Utilities.ConvertText2DateTime(txtDataStart.Text);
				istTraining.DataEnd = Utilities.ConvertText2DateTime(txtDataEnd.Text);
				
				istTraining.UpdateIstoricTraining();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadFormIstoricTraining();
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge un training
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricTraining istTraining = new Salaries.Business.IstoricTraining();
				istTraining.IstoricTrainingId = int.Parse(this.IstoricTrainingID.Value);		
				istTraining.DeleteIstoricTraining();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadFormIstoricTraining();
		}
		#endregion	
	}
}
