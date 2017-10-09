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
	///		Summary description for IstoricTraininguri.
	/// </summary>
	public class EvaluariPsihologiceAngajat : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Image imgSpace;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredData;
		protected System.Web.UI.WebControls.TextBox txtData;			
		protected System.Web.UI.WebControls.DropDownList lstTipRaportID;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileEvaluarePsihologica;
		protected System.Web.UI.WebControls.RequiredFieldValidator NecesarInstruireValidator;
		public long AngajatID;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataStart;
		protected System.Web.UI.WebControls.DropDownList lstTipTipRaportID;		
		protected System.Web.UI.WebControls.DropDownList lstEditTipTipRaportID;	
		protected System.Web.UI.HtmlControls.HtmlInputHidden EvaluarePsihologicaID;	
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.Button btnAdauga;
		protected System.Web.UI.WebControls.Button btnModifica;
		protected System.Web.UI.WebControls.Button btnSterge;
		protected System.Web.UI.HtmlControls.HtmlTableCell EvaluarePsihologicaFile;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCaleEval;
		private string EvaluarePsihologicaPath = "/EvaluarePsihologica";
		#endregion
		
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			LoadFormEvaluariPsihologice();

			btnSterge.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta inregistrare?')");
			
			string[] textTabs = {"Lista evaluari psihologice", "Adauga evaluare"};
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

		#region LoadFormEvaluariPsihologice
		/// <summary>
		/// Listarea evaluarilor psihologice
		/// </summary>
		private void LoadFormEvaluariPsihologice()
		{
			try
			{
				Salaries.Business.AdminTipuriRapoarte tipuriRapoarte = new Salaries.Business.AdminTipuriRapoarte();
					
				lstTipRaportID.Items.Clear();
				lstTipRaportID.DataSource = tipuriRapoarte.LoadInfoTipuriRapoarte();
				lstTipRaportID.DataTextField = "Denumire";
				lstTipRaportID.DataValueField = "TipRaportID";
				lstTipRaportID.DataBind();

				listTable.Rows.Clear();
				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");
							
				Salaries.Business.EvaluariPsihologice evaluarePsihologicaList =  new Salaries.Business.EvaluariPsihologice();
				evaluarePsihologicaList.AngajatId = AngajatID;
			
				string[] arHeader = {"Data efectuarii","Tip Raport", "Fisier Evaluare","Tip Fisier"};
				string[] arCols = {"Data", "DenumireTipRaport","Raport","EvalPsihologicaID"};
				
				ListTable objListTable = new ListTable(listTable, evaluarePsihologicaList.LoadEvaluariPsihologiceAngajat(), arHeader, arCols);
			
				objListTable.textForEmptyDataSet= "Nu exista nici o evaluare psihologica asociata acestui angajat!";
				
				string[] ar_OnClickParam = {AngajatID.ToString(),"EvalPsihologicaID","Data","TipRaportID","Raport"};
				string[] ar_OnClickParamType = {"const","dataset","dataset","dataset", "dataset"};
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectEvaluarePsihologica";
						
				objListTable.DrawListTableWithoutDigits();
				
				for (int i=1;i<listTable.Rows.Count-1;i++)
				{
					TableRow r = listTable.Rows[i];
					if (r.Cells.Count>=5) 
					{
						string name = "EvaluarePsihologica_"+r.Cells[4].Text+"_"+r.Cells[3].Text;
						string FullPath = GetEvaluarePsihologicaPath()+"//"+name;
						
						if (Session["Recrutori"].ToString() == "Recrutori")
						{
							if  (r.Cells[3].Text.Length==0) {r.Cells[3].Text=" nu exista ";r.Cells[4].Text="n/a";} 
							else	r.Cells[4].Text="<img src='../utils/ShowIcon.aspx?AngajatID="+this.AngajatID+"&EvaluarePsihologicaID="+r.Cells[4].Text+"&file="+r.Cells[3].Text+"'>";
						}
						else
						{
							if  (r.Cells[3].Text.Length==0) {r.Cells[3].Text=" nu exista ";r.Cells[4].Text="n/a";} 
							else	r.Cells[4].Text="<img src='utils/ShowIcon.aspx?AngajatID="+this.AngajatID+"&EvaluarePsihologicaID="+r.Cells[4].Text+"&file="+r.Cells[3].Text+"'>";

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
			this.btnAdauga.Click += new System.EventHandler(this.btnAdaugaEvaluarePsihologica_Click);
			this.btnModifica.Click += new System.EventHandler(this.btnModificaDate_Click);
			this.btnSterge.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica o evaluare psihologica
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click(object sender, System.EventArgs e)
		{
			try
			{	
				string name=this.fileEvaluarePsihologica.PostedFile.FileName;
				name=name.Substring(name.LastIndexOf("\\")+1);
	
				Salaries.Business.EvaluariPsihologice evaluare = new Salaries.Business.EvaluariPsihologice();
				evaluare.EvaluarePsihologicaId = int.Parse(EvaluarePsihologicaID.Value);
				evaluare.Data = Utilities.ConvertText2DateTime(txtData.Text);
				evaluare.TipRaportId = int.Parse(lstTipRaportID.SelectedValue);
				evaluare.AngajatId = AngajatID;
				evaluare.Raport = name;
				evaluare.UpdateEvaloarePsihologica();

				name = "EvaluarePsihologica_"+this.EvaluarePsihologicaID.Value+"_"+name;
				File_handler(this.fileEvaluarePsihologica,name,this.GetEvaluarePsihologicaPath()+"\\"+this.AngajatID);

			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadFormEvaluariPsihologice();
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge o evaluare psihologica
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.EvaluariPsihologice evaluare = new Salaries.Business.EvaluariPsihologice();
				evaluare.EvaluarePsihologicaId = int.Parse(EvaluarePsihologicaID.Value);
				evaluare.DeleteEvaloarePsihologica();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadFormEvaluariPsihologice();
		}
		#endregion

		#region btnAdaugaEvaluarePsihologica_Click
		/// <summary>
		/// Adauga o evaluare psihologica
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaEvaluarePsihologica_Click(object sender, System.EventArgs e)
		{
			try
			{	
				string name=this.fileEvaluarePsihologica.PostedFile.FileName;
				name=name.Substring(name.LastIndexOf("\\")+1);
	
				Salaries.Business.EvaluariPsihologice evaluare = new Salaries.Business.EvaluariPsihologice();
				evaluare.EvaluarePsihologicaId = 0;
				evaluare.Data = Utilities.ConvertText2DateTime(txtData.Text);
				evaluare.TipRaportId = int.Parse(lstTipRaportID.SelectedValue);
				evaluare.AngajatId = AngajatID;
				evaluare.Raport = name;
				
				int NewID = evaluare.InsertEvaloarePsihologica();
				name = "EvaluarePsihologica_"+NewID+"_"+name;
				File_handler(this.fileEvaluarePsihologica,name,this.GetEvaluarePsihologicaPath()+"\\"+this.AngajatID);
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
			
			LoadFormEvaluariPsihologice();
		}
		#endregion

		#region GetEvaluarePsihologicaPath
		/// <summary>
		/// Procedura selecteaza documentul asociat unei evaluari psihologice
		/// </summary>
		/// <returns></returns>
		private string GetEvaluarePsihologicaPath()
		{
			return Server.MapPath(Request.ApplicationPath+this.EvaluarePsihologicaPath);
		}
		#endregion

		#region File_handler
		/// <summary>
		/// Procedura salveaza un fisier asociat unui fisier
		/// </summary>
		/// <param name="inputFile">Fisierul asociat unei evaluari psihologice</param>
		/// <param name="DestinationName">Fisierul destinatie</param>
		/// <param name="DestinationFolder">Directorul destinatie</param>
		/// <returns>Returneaza true daca s-a salvat fisierul si false altfel</returns>
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
