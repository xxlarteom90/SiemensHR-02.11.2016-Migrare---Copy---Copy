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
	public class ReferinteAngajat : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataStart;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Image imgSpace;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.RequiredFieldValidator NecesarInstruireValidator;

		public long AngajatID;
		private int MaxDescriere = 50;		
		
		protected System.Web.UI.WebControls.TextBox txtData;
		protected System.Web.UI.WebControls.TextBox txtTitlu;
		protected System.Web.UI.WebControls.TextBox txtDescriere;
		protected System.Web.UI.WebControls.Button btnAdauga;
		protected System.Web.UI.WebControls.Button btnModifica;
		protected System.Web.UI.WebControls.Button btnSterge;
		protected System.Web.UI.HtmlControls.HtmlInputHidden ReferintaID;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;

		protected Salaries.Configuration.ModuleSettings settings;
		#endregion
		
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			LoadFormReferinte();

			btnSterge.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta inregistrare?')");
			
			string[] textTabs = {"Lista referinte", "Adauga referinta"};
			if (Session["Recrutori"].ToString() == "Recrutori")
			{
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "../", true);
				Response.Write("<script> var TipUtilizator = 'Recrutor'; </script>");
			}
			else
			{
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);
				Response.Write("<script> var TipUtilizator = ''; </script>");
			}
		}
		#endregion

		#region LoadFormReferinte
		/// <summary>
		/// Listeaza referintele unui angajat
		/// </summary>
		private void LoadFormReferinte()
		{
			try
			{	
				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);
				
				listTable.Rows.Clear();	
				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");
			
				Salaries.Business.IstoricReferinte ReferinteList =  new Salaries.Business.IstoricReferinte();
				ReferinteList.AngajatId = AngajatID;
						
				string[] arHeader = {"Titlu","Descriere", "Data"};
				string[] arCols = {"Titlu", "Descriere","Data"};
				
				ListTable objListTable = new ListTable(listTable, ReferinteList.LoadReferinte(), arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista nici o referinta asociata acestui angajat!";
				
				string[] ar_OnClickParam = {"ReferintaID","Titlu","Data","Descriere"};
				string[] ar_OnClickParamType = {"dataset","dataset","dataset","dataset"};
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectReferinta";
						
				objListTable.DrawListTableWithoutDigits();
				
				for (int i=1;i<listTable.Rows.Count-1;i++)
				{
					TableRow r = listTable.Rows[i];
					if (r.Cells.Count==4) 
					{
						string Descriere = r.Cells[2].Text;
						if (Descriere.Length>this.MaxDescriere) Descriere = Descriere.Substring(0,MaxDescriere)+"...";
						r.Cells[2].Text=Descriere;
						r.Cells[2].Attributes["alt"]=Descriere;
					}

				}
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
			this.btnAdauga.Click += new System.EventHandler(this.btnAdaugaReferinta_Click);
			this.btnModifica.Click += new System.EventHandler(this.btnModificaDate_Click);
			this.btnSterge.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		#region btnAdaugaReferinta_Click
		/// <summary>
		/// Adauga o referinta
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaReferinta_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricReferinte istReferinta = new Salaries.Business.IstoricReferinte();
				istReferinta.ReferintaId = 0;
				istReferinta.AngajatId = AngajatID;
				istReferinta.Data = Utilities.ConvertText2DateTime(txtData.Text);
				istReferinta.Titlu = txtTitlu.Text;
				istReferinta.Descriere = txtDescriere.Text;

				if	(!istReferinta.InsertReferinta())
				{
					Response.Write( "<script>alert( 'Adaugarea nu a fost facuta, deoarece exista deja o referinta cu aceleasi date!' )</script>" );
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadFormReferinte();
		}
		#endregion

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica o referinta
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricReferinte istReferinta = new Salaries.Business.IstoricReferinte();
				istReferinta.ReferintaId = int.Parse(this.ReferintaID.Value);
				istReferinta.AngajatId = AngajatID;
				istReferinta.Data = Utilities.ConvertText2DateTime(txtData.Text);
				istReferinta.Titlu = txtTitlu.Text;
				istReferinta.Descriere = txtDescriere.Text;

				if (!istReferinta.UpdateReferinta())
				{
					Response.Write( "<script>alert( 'Modificarea nu a fost facuta, deoarece exista deja o referinta cu aceleasi date!' )</script>" );
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadFormReferinte();
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge o referinta
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.IstoricReferinte istReferinta = new Salaries.Business.IstoricReferinte();
				istReferinta.ReferintaId = int.Parse(this.ReferintaID.Value);
				istReferinta.DeleteReferinta();	
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadFormReferinte();
		}
		#endregion		
	}
}
