/*
 * Modificat:	Lungu Andreea
 * Data:		20.09.2010
 * Descriere:	Sincronizarea datelor angajatilor.
 */

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SiemensHR.utils;
using System.Collections;
using System.Text.RegularExpressions;
using System.Security.Principal;

using SiemensTM.Classes;
using SiemensHR.Classes;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for SincronizareDateAngajati.
	/// </summary>
	public class SincronizareDateAngajati : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.HtmlControls.HtmlTableRow Tr1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trNrOreLucrate;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.ValidationSummary Validationsummary2;
		protected System.Web.UI.WebControls.Label lblMesajImport;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileImportFisier;
		protected System.Web.UI.HtmlControls.HtmlInputButton ButtonImport;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqFieldValImport;
		private string actionSincronizareDateAngajati = "";
		protected System.Web.UI.WebControls.Label lblMesaj;
		protected System.Web.UI.HtmlControls.HtmlTableCell tablePontaj;
		private int angajatorID;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTemplate;
		protected System.Web.UI.WebControls.Label lblAtentie;
		protected System.Security.Principal.WindowsPrincipal user;
		#endregion
		
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			CreateJavascriptVar();

			angajatorID = this.GetAngajator();

			/*if (ButtonImport.Value.Equals("Import pontaj"))
				tdTemplate.InnerHtml = "<a target=_blank href='Templates\\TemplatePontaj.xls'>template pontaj</a>";
			else
				tdTemplate.InnerHtml = "<a target=_blank href='Templates\\TemplateSituatieLunara.xls'>template situatie lunara</a>";*/
			actionSincronizareDateAngajati = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ActionSincronizareDateAngajatiValue" )).Value;
				

			//user-ul loginat
			user = new WindowsPrincipal(WindowsIdentity.GetCurrent());

			if (!IsPostBack)
			{
				lblMesajImport.Text = "";
			}
			else
			{
			}
			HandleActions();
		}

		#endregion

		#region variabile javascript
		private void CreateJavascriptVar()
		{
			string script_text = "<script>var ctrlID = \""+this.ClientID+"\"</script>";
			Response.Write(script_text);
			Response.Write("<script>var reqImport = \"" + reqFieldValImport.ClientID + "\"</script>");
			Response.Write("<script>var butImport = \"" + ButtonImport.ClientID + "\"</script>");
			Response.Write("<script>var tdTemp = \"" + tdTemplate.ClientID + "\"</script>");
			Response.Write("<script>var lblMsg = \"" + lblMesaj.ClientID + "\"</script>");
			Response.Write("<script>var lblMsgImport = \"" + lblMesajImport.ClientID + "\"</script>");
			Response.Write("<script>var lblAtentieClient = \"" + lblAtentie.ClientID + "\"</script>");
			Response.Write("<script>var fileImport = \"" + fileImportFisier.ClientID + "\"</script>");
		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			/*base.OnPreRender (e);

			Salaries.Business.Luni l = new Salaries.Business.Luni(this.GetAngajator(), this.GetCurrentMonth());
			this.SelectedDate = l.Data;
			this.SaveSessionKey( Definitions.SelectedDateKEY, this.SelectedDate );
			string script_text = "<script>var ctrlID = \""+this.ClientID+"\"</script>";
			Response.Write(script_text);*/
		}
		#endregion

		#region Render
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render( writer );
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
 
		#region click button import 
		private void ButtonImport_Click()
		{
			ErrHandler.MyErrHandler.WriteError("SincronizareDateAngajati.ascx - start - click_Import()");
			ScrieInFisierTest();

			lblMesajImport.Text = Environment.NewLine;
			if ((fileImportFisier.PostedFile.FileName!="") || (fileImportFisier.PostedFile.ContentLength!=0))
			{
				string caleFisier = fileImportFisier.PostedFile.FileName;
				string contentFile = fileImportFisier.PostedFile.ContentType.ToString();
				
				if (fileImportFisier.PostedFile.ContentType.ToString().Equals("application/vnd.ms-excel"))
				{
					//salvez fisierul pe server
					caleFisier = SaveFileOnServer(fileImportFisier);

					int idAngajator = GetAngajator();
					int idLuna = this.GetCurrentMonth();
					//nu le pot trece in alt proiect pt ca am clase ce le folosesc din proiectul asta si nu prea pot trece SiemensHR ca referinta la alte proiect - creez ciclu
					//Salaries.Business.PontajAngajati imp = new Salaries.Business.PontajAngajati(idAngajator, idLuna);
					//string mesajImport = imp.ImportPontaj(caleFisier);
					
					string tempPath = System.IO.Path.GetTempPath();
					System.IO.StreamWriter sw = new System.IO.StreamWriter(Server.MapPath("Templates\\logImport.txt"), true);
					sw.WriteLine("----temp path:"+ tempPath);
					sw.Close();

					//---scriu in log----
					Salaries.Data.ImportFisier sitData = new Salaries.Data.ImportFisier();
					DataTable dt = sitData.GetDataTableFromImport(caleFisier);
					ScrieInFisierDate(caleFisier, "pontaj", dt);
					//------
					string mesajImport = ImportFisierSincronizare(caleFisier);
					//aici as putea sa si adaug in bd 		
					if (mesajImport.IndexOf("Fisierul nu este in formatul corespunzator")>=0)
					{
						lblMesajImport.Text = "Fisierul nu este in formatul corespunzator";
						lblMesaj.Text = "";
					}
					else
					{
						lblMesajImport.Text = "A fost importat fisierul pentru delegatii. \r\n";
						if (!mesajImport.Equals(""))
						{
							lblMesaj.Text += mesajImport.Replace(Environment.NewLine,"<br> ");
							//Session["FeedbackImport"] = lblMesaj.Text;
							//Response.Write("<script> var win=window.open('ShowMessage.aspx','FeedbackImport','height=200,width=500,menubar=no,status=no,toolbar=no,resizable=yes');win.focus();</script>");
						}
						ScrieInFisierMesaj(mesajImport);
					}
				}
				else
				{
					Response.Write("<script> alert('Introduceti fisiere Excel.');</script>");
				}
			}
			ErrHandler.MyErrHandler.WriteError("SincronizareDateAngajati.ascx - end - click_Import() ");
		}
		#endregion

		#region save file on server
		public string SaveFileOnServer(System.Web.UI.HtmlControls.HtmlInputFile fileImport)
		{
			ErrHandler.MyErrHandler.WriteError("SincronizareDateAngajati.ascx - start - SaveFileOnServer() - " + fileImportFisier.PostedFile.FileName);
			string fn = System.IO.Path.GetFileName(fileImport.PostedFile.FileName);
			string numeFis = fn.Substring(0,fn.LastIndexOf("."));
			string extensie = fn.Substring(fn.LastIndexOf("."));
			string SaveLocation = Server.MapPath("Templates\\Bulk") + "\\" +  numeFis + "_" + 
					DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "_" + 
					DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + extensie;
			try
			{
				fileImport.PostedFile.SaveAs(SaveLocation);
				//Response.Write("The file has been uploaded.");
			}
			catch ( Exception ex )
			{
				//Response.Write("Error: " + ex.Message);
				//Note: Exception.Message returns a detailed message that describes the current exception. 
				//For security reasons, we do not recommend that you return Exception.Message to end users in 
				//production environments. It would be better to put a generic error message. 
				ErrHandler.MyErrHandler.WriteError("SincronizareDateAngajati.ascx - error - SaveFileOnServer() - " + ex.Message);
			}
			ErrHandler.MyErrHandler.WriteError("SincronizareDateAngajati.ascx - end - SaveFileOnServer() - " + SaveLocation);
			return SaveLocation;
		}
		#endregion

		#region scrie in fis
		public void ScrieInFisierTest()
		{
			System.IO.StreamWriter sw = new System.IO.StreamWriter(Server.MapPath("Templates\\logImport.txt"), true);
			try
			{
				sw.WriteLine("Test ");
				sw.WriteLine("Data: " + DateTime.Now);
				sw.WriteLine("User: " + user.Identity.Name);
			}
			catch(Exception exc)
			{
			}
			finally
			{
				sw.Close();
			}
		}
		public void ScrieInFisierDate(string caleFisier, string optiune, DataTable dt)
		{
			System.IO.StreamWriter sw = new System.IO.StreamWriter(Server.MapPath("Templates\\logImport.txt"), true);
			try
			{
				sw.WriteLine("Se incearca importul fisierului " + caleFisier + " pt " + optiune);
				sw.WriteLine("Data: " + DateTime.Now);
				sw.WriteLine("User: " + user.Identity.Name);
				foreach(DataRow dr in dt.Rows)
				{
					for(int i = 0; i<dt.Columns.Count; i++)
					{
						if (i==1)
							sw.Write(String.Format("|{0,35}|",dr[i].ToString()));
						else
							sw.Write(String.Format("|{0,21}|",dr[i].ToString()));
					}
					sw.WriteLine();
				}
			}
			catch(Exception exc)
			{
			}
			finally
			{
			   sw.Close();
			}
		}

		public void ScrieInFisierMesaj(string mesajImport)
		{
			System.IO.StreamWriter sw = new System.IO.StreamWriter(Server.MapPath("Templates\\logImport.txt"), true);
			try
			{
				sw.WriteLine(mesajImport);
				sw.WriteLine("----------------------------------------------");
				sw.WriteLine();
			}
			catch(Exception exc)
			{}
			finally
			{
				sw.Close();
			}
		}
		#endregion

		#region HandleActions
		/// <summary>
		/// Executa operatia
		/// </summary>
		private void HandleActions()
		{
			switch( actionSincronizareDateAngajati )
			{
				case "sincronizareDateAngajati":
					lblMesaj.Text = "";
					lblMesajImport.Text = "";
					if (!fileImportFisier.Value.Equals(""))
					{
						ButtonImport_Click();
						actionSincronizareDateAngajati = "";
						((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ActionSincronizareDateAngajatiValue" )).Value = "";
					}
					else
					{
						Response.Write("<script> alert('Trebuie sa completati numele fisierului!'); </script>");
					}
					break;
				default:
					break;
			}

		}
		#endregion

	
		#region import fisier sincronizare date angajti
		//Lungu Andreea - 20.09.2010
		public string ImportFisierSincronizare(string fileName)
		{
			ErrHandler.MyErrHandler.WriteError("SincronizareDateAngajati.ascx - start - ImportFisierSincronizare() - " + fileName);
			string marca = "", numePrenume = "", birou = "";
			Salaries.Data.ImportFisier imp = new Salaries.Data.ImportFisier();
			DataTable dt = imp.GetDataTableFromImport(fileName);

			string mesajImport = "";
			foreach (DataRow dr in dt.Rows)
			{
				#region preiau datele din row-ul respectiv
				try
				{
					marca = dr["Marca"].ToString();
					numePrenume = dr["Nume si Prenume"].ToString();
					birou = dr["Birou"].ToString();
				}
				catch(Exception exc)
				{
					mesajImport += "Fisierul nu este in formatul corespunzator";
					ErrHandler.MyErrHandler.WriteError("SincronizareDateAngajati.ascx - error - ImportFisierSincronizare() - 'Fisierul nu este in formatul corespunzator' ");
					break;
				}
				#endregion

				#region determin id-ul angajatului pe baza marcii
				//determin id-ul angajatului pe baza marcii
				Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
				ang.Marca = marca;
				int idAngajat = ang.GetAngajatIDByMarca(marca);	
				ang.AngajatId = idAngajat;
				ang.LoadAngajat();

//				ang.LoadAngajat();
//				bool esteLichidat = true;
//				if ((ang.DataLichidare == DateTime.MinValue) || (ang.DataLichidare>dataStartLunaActiva))
//					esteLichidat = false;
				#endregion
				
				//if ((idAngajat != -1) && (!esteLichidat))
				if (idAngajat != -1)
				{
					ang.Birou = birou;
					ang.UpdateAngajat();
				}
				else
				{
					if (!dr["Marca"].ToString().Equals(""))
						mesajImport += "Nu exista angajatul cu marca " + dr["Marca"].ToString() + Environment.NewLine;
					//ar trebui sa scriu intr-un fisier ca sa pot da un feedback
					//if (esteLichidat)
					//	mesajImport += "Angajatul " + dr["Nume si Prenume"].ToString() + " este lichidat.";
				}
			}
			ErrHandler.MyErrHandler.WriteError("SincronizareDateAngajati.ascx - end - ImportFisierSincronizare() - " + fileName);
			if (mesajImport.Equals(""))
				mesajImport = "Sincronizarea datelor a fost realizata.";
			return mesajImport;
		}
		#endregion
	}
}
