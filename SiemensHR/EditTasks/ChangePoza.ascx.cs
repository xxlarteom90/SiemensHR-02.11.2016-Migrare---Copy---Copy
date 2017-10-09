using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.EditTasks
{
	/// <summary>
	///		Summary description for ChangePoza.
	/// </summary>
	public class ChangePoza : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.HtmlControls.HtmlInputFile filePozaAngajat;
		protected System.Web.UI.WebControls.Button btnSalveaza;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected Salaries.Configuration.ModuleSettings settings;

		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string[] textTabs = {"Schimba poza angajat"};
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", false);
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
			this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnSalveaza_Click
		/// <summary>
		/// Procedura salveaza poza adaugata
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSalveaza_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ((filePozaAngajat.PostedFile.FileName!="") || (filePozaAngajat.PostedFile.ContentLength!=0))
				{
					string contentFile = filePozaAngajat.PostedFile.ContentType.ToString();
					
					if (contentFile.Substring(0,5)=="image")
					{
						FileStream fp = new FileStream(filePozaAngajat.PostedFile.FileName,FileMode.Open,FileAccess.Read);
						BinaryReader br = new BinaryReader(fp);

						byte[] buffer = br.ReadBytes((int)fp.Length);
							
						br.Close();
						fp.Close();

						Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
						angajat.AngajatId = AngajatID;
						angajat.UpdatePoza(buffer);
					}
					else
					{
						throw new Exception("Se pot salva numai fisiere de tip image (gif, jpg, jpeg...)!");
					}
                }
				else
					throw new Exception("Invalid file name or file length zero!");
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion
	}
}
