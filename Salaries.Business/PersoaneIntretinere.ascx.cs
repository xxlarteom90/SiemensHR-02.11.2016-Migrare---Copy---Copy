namespace SiemensHR.EditTasks
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using SiemensHR.utils;
    using SiemensHR.Classes;
	using System.Configuration;


	/// <summary>
	///		Summary description for PersoaneIntretinere.
	/// </summary>
	public class PersoaneIntretinere : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.Button btnAdaugaPersInIntretinere;
		protected System.Web.UI.WebControls.Button btnModificaPersoana;
		protected System.Web.UI.WebControls.Button btnStergePersoana;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActiv;
		protected System.Web.UI.WebControls.DropDownList ddlCalitate;
		protected System.Web.UI.WebControls.DropDownList ddlInvaliditate;
		protected System.Web.UI.WebControls.Label lCoefTotal;
		protected System.Web.UI.WebControls.TextBox txtNume;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredField_nume;
		protected System.Web.UI.WebControls.TextBox txtPrenume;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredField_prenume;
		protected System.Web.UI.WebControls.TextBox txtCNP;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCNP;
		protected System.Web.UI.WebControls.CustomValidator customCNP;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden persID;
		protected System.Web.UI.WebControls.Label lCoefTotalPersIntret;
		protected Salaries.Configuration.ModuleSettings settings;

		
		public long AngajatID;
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			LoadPersoaneList();
			
			btnStergePersoana.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti acest cont?')");

			string[] textTabs = {"Lista persoanelor aflate in intretinere ", "Adauga persoana"};
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);
			
		}

		
		private void LoadPersoaneList()
		{
			
			try
			{
				listTable.Rows.Clear();
				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);
				ddlInvaliditate.DataSource = utilDb.CreateDataSet("Select InvaliditateID, Nume  from Invaliditati order by Nume");
				ddlInvaliditate.DataValueField = "InvaliditateID";
				ddlInvaliditate.DataTextField = "Nume";
				ddlInvaliditate.DataBind();	

				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

				/*
				*	Changed: Ionel Popa
				*			- S-au scos coloanele calitate, invaliditate si coeficient
				string[] arHeader = {"Nume","Prenume","CNP", "Calitate", "Invaliditate","Coeficient"};
				string[] arCols = {"Nume","Prenume","CNP", "Calitat", "Invalid","Coeficient"};
				*/			
				string[] arHeader = {"Nume","Prenume","CNP"};
				string[] arCols = {"Nume","Prenume","CNP"};
			
				Salaries.Business.Angajat angajatCurent=new Salaries.Business.Angajat((int)this.AngajatID);
		        DataSet ds=angajatCurent.PersoaneInIntretinere();

				//Din cauza scoaterii coloanelor de mai sus se scoate si acest coeficient
				//this.lCoefTotalPersIntret.Text="Coeficientul pt toate persoanele aflate in intretinere este: "+angajatCurent.CoefTotalPtPersInIntretinere;

				ListTable objListTable = new ListTable(listTable, ds, arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista nici o persoana in intretinerea angajatului!";

				string[] ar_OnClickParam =  {"ID","Nume","Prenume","CNP", "Calitate", "Invaliditate","Coeficient"};
				
				string[] ar_OnClickParamType =new string[ ar_OnClickParam.Length];
				for (int i=0;i< ar_OnClickParamType.Length;i++)
					ar_OnClickParamType[i]="dataset";

			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectPersoana";

				objListTable.DrawListTable();

		
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}	
		}


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
			this.btnAdaugaPersInIntretinere.Click += new System.EventHandler(this.btnAdaugaPersInIntretinere_Click);
			this.btnModificaPersoana.Click += new System.EventHandler(this.btnModificaPersoana_Click);
			this.btnStergePersoana.Click += new System.EventHandler(this.btnStergePersoana_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAdaugaPersInIntretinere_Click(object sender, System.EventArgs e)
		{
			try
			{		
				Salaries.Business.PersoanaInIntretinere pers=new Salaries.Business.PersoanaInIntretinere();
                string Nume=this.txtNume.Text;   
				string Prenume=this.txtPrenume.Text;
                long CNP=long.Parse(this.txtCNP.Text);
				short Calitate=short.Parse(ddlCalitate.SelectedValue);
				short Invaliditate=short.Parse(ddlInvaliditate.SelectedValue);

				pers.Create((int)AngajatID,Nume,Prenume,CNP,Calitate,Invaliditate);								
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			LoadPersoaneList();
		}

		private void btnModificaPersoana_Click(object sender, System.EventArgs e)
		{
			try
			{	
				int id=int.Parse(persID.Value);
				Salaries.Business.PersoanaInIntretinere pers=new Salaries.Business.PersoanaInIntretinere(id);
				pers.Nume=this.txtNume.Text;   
				pers.Prenume=this.txtPrenume.Text;
				pers.CNP=long.Parse(this.txtCNP.Text);
				pers.Calitate=short.Parse(ddlCalitate.SelectedValue);
				pers.Invaliditate=short.Parse(ddlInvaliditate.SelectedValue);

				pers.Update();			
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			LoadPersoaneList();
		}

		private void btnStergePersoana_Click(object sender, System.EventArgs e)
		{
			try
			{
				int id=int.Parse(persID.Value);
				Salaries.Business.PersoanaInIntretinere pers=new Salaries.Business.PersoanaInIntretinere(id);	
				pers.Delete();			
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			LoadPersoaneList();
		}


	}
}
