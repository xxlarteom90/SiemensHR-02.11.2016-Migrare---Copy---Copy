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
	public class CheckupuriAngajat : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Image imgSpace;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataEnd;
		protected System.Web.UI.WebControls.TextBox txtDataEfectuarii;
		protected System.Web.UI.WebControls.TextBox txtDataUrmatorului;
		protected System.Web.UI.WebControls.TextBox txtNecesarInstruire;
		protected System.Web.UI.WebControls.DropDownList lstResponsabil;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileCheckup;
		public long AngajatID;
		public long SefID;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.Button btnAdauga;
		protected System.Web.UI.WebControls.Button btnModifica;
		protected System.Web.UI.WebControls.Button btnSterge;
		protected System.Web.UI.HtmlControls.HtmlInputHidden CheckupID;
		protected System.Web.UI.HtmlControls.HtmlTableCell CheckupFile;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCaleFisier;
		private string CheckupPath = "/Checkup";
		#endregion
		
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			LoadFormCheckupuri();

			btnSterge.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta inregistrare?')");
			
			string[] textTabs = {"Lista checkup", "Adauga checkup"};
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

		#region LoadFormCheckupuri
		/// <summary>
		/// Afiseaza lista cu checkup-uri
		/// </summary>
		private void LoadFormCheckupuri()
		{
			try
			{
				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);				
				listTable.Rows.Clear();

				//Modificat:Muntean Raluca Cristina  - am adaugat ca parametru si id-ul angajatorului
				utilDb.CreateAngajatiSelectBoxEx(this.lstResponsabil,this.GetAngajator());
				
				Salaries.Business.Angajat objAngajat = new Salaries.Business.Angajat();
				objAngajat.AngajatId = AngajatID;
				objAngajat.LoadAngajat();

				this.lstResponsabil.SelectedValue = "-1";
				if(objAngajat.SefId.ToString()!="-1")
				{
					if (lstResponsabil.Items.FindByValue(this.SefID.ToString()) != null)
					{
						this.lstResponsabil.SelectedValue = this.SefID.ToString();
					}
				}
                
				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");
							
				Salaries.Business.Checkupuri checkupList =  new Salaries.Business.Checkupuri();
				checkupList.AngajatId = AngajatID;
				
				string[] arHeader = {"Necesar Instruire","Data urmatorului","Responsabil", "Data efectuarii","Fisier Checkup","Tip Fisier"};
				string[] arCols = {"NecesarInstruire", "DataUrmatorului","NumeIntreg","DataEfectuarii","CheckupFile","CheckupID"};
				
				ListTable objListTable = new ListTable(listTable, checkupList.LoadCheckupuriAngajat(), arHeader, arCols);
						
				objListTable.textForEmptyDataSet= "Nu exista nici un checkup asociat acestui angajat!";
				
				string[] ar_OnClickParam = {AngajatID.ToString(),"CheckupID","NecesarInstruire","DataEfectuarii","ResponsabilID","DataUrmatorului","CheckupFile"};
				string[] ar_OnClickParamType = {"const","dataset","dataset","dataset", "dataset","dataset","dataset"};
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectCheckup";
						
				objListTable.DrawListTableWithoutDigits();
				
				for (int i=1;i<listTable.Rows.Count-1;i++)
				{
					TableRow r = listTable.Rows[i];
				
					//Daca linia nu este separator (are mai multe celule)
					if (r.Cells.Count>=6) 
					{
						if (r.Cells[3].Text=="")
						{
							r.Cells[3].Text = "NU ESTE ANGAJAT AL FIRMEI";
						}

						string name = "Checkup_"+r.Cells[6].Text+"_"+r.Cells[5].Text;
						string FullPath = GetCheckupPath()+"//"+name;
						
						if (Session["Recrutori"].ToString() == "Recrutori")
						{
							if  (r.Cells[5].Text.Length==0) {r.Cells[5].Text=" nu exista ";r.Cells[6].Text="n/a";} 
							else	r.Cells[6].Text="<img src='../utils/ShowIcon.aspx?AngajatID="+this.AngajatID+"&CheckupID="+r.Cells[6].Text+"&file="+r.Cells[5].Text+"'>";
						}
						else
						{
							if  (r.Cells[5].Text.Length==0) {r.Cells[5].Text=" nu exista ";r.Cells[6].Text="n/a";} 
							else	r.Cells[6].Text="<img src='utils/ShowIcon.aspx?AngajatID="+this.AngajatID+"&CheckupID="+r.Cells[6].Text+"&file="+r.Cells[5].Text+"'>";
						}
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
			this.btnAdauga.Click += new System.EventHandler(this.btnAdaugaCheckup_Click);
			this.btnModifica.Click += new System.EventHandler(this.btnModificaDate_Click);
			this.btnSterge.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica un checkup
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				string name=this.fileCheckup.PostedFile.FileName;
				name=name.Substring(name.LastIndexOf("\\")+1);

				Salaries.Business.Checkupuri checkup = new Salaries.Business.Checkupuri();
				checkup.CheckupId = int.Parse(CheckupID.Value);
				checkup.AngajatId = AngajatID;
				checkup.CheckupFile = name;
				if (txtDataEfectuarii.Text != "")
				{
					checkup.DataEfectuarii = Utilities.ConvertText2DateTime(txtDataEfectuarii.Text);
				}
				else
				{
					checkup.DataEfectuarii = DateTime.MinValue;
				}
				checkup.DataUrmatorului = Utilities.ConvertText2DateTime(txtDataUrmatorului.Text);
				checkup.NecesarInstruire = txtNecesarInstruire.Text;
				checkup.ResponsabilId = int.Parse(lstResponsabil.SelectedValue);
				
				checkup.UpdateCheckup();
	
				name = "Checkup_"+this.CheckupID.Value+"_"+name;
				File_handler(this.fileCheckup,name,this.GetCheckupPath()+"\\"+this.AngajatID);
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadFormCheckupuri();
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge un checkup
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.Checkupuri checkup = new Salaries.Business.Checkupuri();
				checkup.CheckupId = int.Parse(CheckupID.Value);
				checkup.DeleteCheckup();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadFormCheckupuri();
		}
		#endregion

		#region btnAdaugaCheckup_Click
		/// <summary>
		/// Adauga checkup
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaCheckup_Click(object sender, System.EventArgs e)
		{
			try
			{
				string name=this.fileCheckup.PostedFile.FileName;
				name=name.Substring(name.LastIndexOf("\\")+1);

				Salaries.Business.Checkupuri checkup = new Salaries.Business.Checkupuri();
				checkup.CheckupId = 0;
				checkup.AngajatId = AngajatID;
				checkup.CheckupFile = name;
				if (txtDataEfectuarii.Text != "")
				{
					checkup.DataEfectuarii = Utilities.ConvertText2DateTime(txtDataEfectuarii.Text);
				}

				checkup.DataUrmatorului = Utilities.ConvertText2DateTime(txtDataUrmatorului.Text);
				checkup.NecesarInstruire = txtNecesarInstruire.Text;
				checkup.ResponsabilId = int.Parse(lstResponsabil.SelectedValue);
						
				int NewID = checkup.InsertCheckup();
				name = "Checkup_"+NewID+"_"+name;
				File_handler(this.fileCheckup,name,this.GetCheckupPath()+"\\"+this.AngajatID);
				
				txtNecesarInstruire.Text = "";
				txtDataEfectuarii.Text = "";
				txtDataUrmatorului.Text = "";
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadFormCheckupuri();
		}
		#endregion

		#region GetCheckupPath
		/// <summary>
		/// Procedura returneaza calea unui checkup
		/// </summary>
		/// <returns>Returneaza clea fisierului</returns>
		private string GetCheckupPath()
		{
			return Server.MapPath(Request.ApplicationPath+this.CheckupPath);
		}
		#endregion

		#region File_handler
		/// <summary>
		/// Procedura salveaza fisierul care contine checkup-ul
		/// </summary>
		/// <param name="inputFile">Fisierul</param>
		/// <param name="DestinationName">Calea destinatie</param>
		/// <param name="DestinationFolder">Directorul destinatie</param>
		/// <returns>Returneaza true daca s-a facut salvarea si false altfel</returns>
		private bool File_handler(HtmlInputFile inputFile,string DestinationName,string DestinationFolder)
		{
			if( inputFile.PostedFile != null && inputFile.Value!="")
			{
				HttpPostedFile myFile = inputFile.PostedFile;
				int nFileLen = myFile.ContentLength;
		
				byte[] myData = new byte[nFileLen];
				myFile.InputStream.Read(myData, 0, nFileLen);
				
				return Utilities.UploadFileToFolder(DestinationName,DestinationFolder,nFileLen,myData);
			} 
			else
			{
				return false;
			}
		}
		#endregion
	}
}
