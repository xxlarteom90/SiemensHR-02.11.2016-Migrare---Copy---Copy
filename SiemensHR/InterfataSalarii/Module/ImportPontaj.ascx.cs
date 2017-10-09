/*
* Modificat:	Lungu Andreea
* Data:			05.11.2009
* Descriere:	Un user control pentru a se putea import fisiere excel pentru situatie lunara si pontaj

 * Modificat:	Lungu Andreea
 * Data:		17.12.2009
 * Descriere:	S-a adaugat log.
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
	///		Summary description for ImportPontaj.
	/// </summary>
	public class ImportPontaj : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.HtmlControls.HtmlTableRow Tr1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trNrOreLucrate;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.ValidationSummary Validationsummary2;
		protected System.Web.UI.WebControls.Label lblMesajImport;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileImportFisier;
		protected System.Web.UI.HtmlControls.HtmlInputButton ButtonImport;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqFieldValImport;
		private string actionImportLuna = "";
		private DateTime dataStartLunaActiva;
		private DateTime dataEndLunaActiva;
		protected System.Web.UI.WebControls.Label lblMesaj;
		protected System.Web.UI.HtmlControls.HtmlTableCell tablePontaj;
		private int lunaID;
		private int lunaActiva;
		private int angajatorID;
		private int idCO = -1, idCOA = -1, idCM = -1, idCCM = -1;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdTemplate;
		protected System.Web.UI.WebControls.Label lblAtentie;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdRezultateImport;
		protected System.Security.Principal.WindowsPrincipal user;
		#endregion
		
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			CreateJavascriptVar();
			lunaID = this.GetCurrentMonth();
			Salaries.Business.Luni l = new Salaries.Business.Luni(this.GetAngajator(), lunaID);
			this.dataStartLunaActiva = l.Data;
			this.dataEndLunaActiva = dataStartLunaActiva.AddMonths(1).AddDays(-1);
			angajatorID = this.GetAngajator();
			Salaries.Business.Luni salLuni = new Salaries.Business.Luni(angajatorID);
			lunaActiva = salLuni.GetLunaActiva().LunaId;

			/*if (ButtonImport.Value.Equals("Import pontaj"))
				tdTemplate.InnerHtml = "<a target=_blank href='Templates\\TemplatePontaj.xls'>template pontaj</a>";
			else
				tdTemplate.InnerHtml = "<a target=_blank href='Templates\\TemplateSituatieLunara.xls'>template situatie lunara</a>";*/
			actionImportLuna = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ActionImportLunaValue" )).Value;
			
			string[] textTabs = {"Import pontaj", "Import situatie lunara"};
			Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "../", true);
			
			//user-ul loginat
			user = new WindowsPrincipal(WindowsIdentity.GetCurrent());

			if (!IsPostBack)
			{
				lblMesajImport.Text = "";
			}
			else
			{
			}
			System.IO.StreamWriter swRez = new System.IO.StreamWriter(Server.MapPath("Templates\\RezultateImport.txt"), false);
			swRez.WriteLine();
			swRez.Close();

			GetIdTipAbsente();
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
			Response.Write("<script>var tdRez = \"" + tdRezultateImport.ClientID + "\"</script>");
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
		private void ButtonImportSituatieLunara_Click()
		{
			ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - start - click_ImportSituatieLunara() - lunaID: " + lunaID);
			ScrieInFisierTest();

			Session["FeedbackImport"] = "";
			lblMesajImport.Text = "<br>";
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
					//---scriu in log----
					string tempPath = System.IO.Path.GetTempPath();
					System.IO.StreamWriter sw = new System.IO.StreamWriter(Server.MapPath("Templates\\logImport.txt"), true);
					sw.WriteLine("----temp path:"+ tempPath);
					sw.Close();

					Salaries.Data.ImportFisier sitData = new Salaries.Data.ImportFisier();
					DataTable dt = sitData.GetDataTableFromImport(caleFisier);
					ScrieInFisierDate(caleFisier, "situatie lunara", dt);
					//------
					//Salaries.Business.SituatieLunaraAngajati imp = new Salaries.Business.SituatieLunaraAngajati(idAngajator, idLuna);
					string mesajImport = ImportSituatieLunara(caleFisier);
					//aici as putea sa si adaug in bd 
					System.IO.StreamWriter swRez = new System.IO.StreamWriter(Server.MapPath("Templates\\RezultateImport.txt"), true);
					if (mesajImport.IndexOf("Fisierul nu este in formatul corespunzator")>=0)
					{
						lblMesajImport.Text = "Fisierul nu este in formatul corespunzator";
						lblMesaj.Text = "";
						swRez.WriteLine("Fisierul nu este in formatul corespunzator");
					}
					else
					{
						swRez.WriteLine("A fost importat fisierul pentru situatie lunara. \r\n");
						lblMesajImport.Text = "A fost importat fisierul pentru situatie lunara.";
						if (!mesajImport.Equals(""))
						{
							lblMesaj.Text += mesajImport.Replace(Environment.NewLine,"<br> ");
							//Session["FeedbackImport"] = lblMesaj.Text;
							//Response.Write("<script> var win=window.open('ShowMessage.aspx','FeedbackImport','height=200,width=500,menubar=no,status=no,toolbar=no,resizable=yes');win.focus();</script>");
						}
						swRez.WriteLine(mesajImport);
						ScrieInFisierMesaj(mesajImport);
					}
					swRez.Close();
				}
				else
				{
					Response.Write("<script> alert('Introduceti fisiere Excel.');</script>");
				}
			}
			ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - end - click_ImportSituatieLunara() - lunaID: " + lunaID);
		}

		private void ButtonImportPontaj_Click()
		{
			ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - start - click_ImportPontaj() - lunaID: " + lunaID);
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
					System.IO.StreamWriter sw = new System.IO.StreamWriter(Server.MapPath("Templates\\logImport.txt"), false);
					sw.WriteLine("----temp path:"+ tempPath);
					sw.Close();
					//---scriu in log----
					Salaries.Data.ImportFisier sitData = new Salaries.Data.ImportFisier();
					DataTable dt = sitData.GetDataTableFromImport(caleFisier);
					ScrieInFisierDate(caleFisier, "pontaj", dt);
					//------
					string mesajImport = ImportFisierPontaj(caleFisier);
					//aici as putea sa si adaug in bd 	
					System.IO.StreamWriter swRez = new System.IO.StreamWriter(Server.MapPath("Templates\\RezultateImport.txt"), false);
					if (mesajImport.IndexOf("Fisierul nu este in formatul corespunzator")>=0)
					{
						lblMesajImport.Text = "Fisierul nu este in formatul corespunzator";
						lblMesaj.Text = "";
						swRez.WriteLine("Fisierul nu este in formatul corespunzator");
					}
					else
					{
						swRez.WriteLine("A fost importat fisierul pentru situatie lunara. \r\n");
						lblMesajImport.Text = "A fost importat fisierul pentru pontaj. \r\n";
						if (!mesajImport.Equals(""))
						{
							lblMesaj.Text += mesajImport.Replace(Environment.NewLine,"<br> ");
							//Session["FeedbackImport"] = lblMesaj.Text;
							//Response.Write("<script> var win=window.open('ShowMessage.aspx','FeedbackImport','height=200,width=500,menubar=no,status=no,toolbar=no,resizable=yes');win.focus();</script>");
						}
						swRez.WriteLine(mesajImport);
						ScrieInFisierMesaj(mesajImport);
					}
					swRez.Close();
				}
				else
				{
					Response.Write("<script> alert('Introduceti fisiere Excel.');</script>");
				}
			}
			ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - end - click_ImportPontaj() - lunaID: " + lunaID);
		}
		#endregion

		#region save file on server
		public string SaveFileOnServer(System.Web.UI.HtmlControls.HtmlInputFile fileImport)
		{
			ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - start - SaveFileOnServer() - lunaID: " + lunaID + " - " + fileImport.PostedFile.FileName);
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
				ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - error - SaveFileOnServer() - lunaID: " + lunaID + " - " + ex.Message);
			}
			ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - end - SaveFileOnServer() - lunaID: " + lunaID + " - " + SaveLocation);
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
			//aici trebuie sa verific daca e luna activa sau nu
			if (lunaID!=lunaActiva)
			{
				lblMesajImport.Text = "Nu se pot importa date pentru pontaj sau situatie lunara decat in luna activa!";
			}
			else
			{
				switch( actionImportLuna )
				{
					case "importPontaj":
						lblMesaj.Text = "";
						lblMesajImport.Text = "";
						if (!fileImportFisier.Value.Equals(""))
						{
							ButtonImport.Value = "Import pontaj";
							ButtonImportPontaj_Click();
							actionImportLuna = "";
							((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ActionInitializareLunaValoare" )).Value = "";
						}
						else
						{
							Response.Write("<script> alert('Trebuie sa completati numele fisierului!'); </script>");
						}
						break;
					case "importSituatie":
						lblMesaj.Text = "";
						lblMesajImport.Text = "";
						if (!fileImportFisier.Value.Equals(""))
						{
							ButtonImport.Value = "Import situatie lunara";
							ButtonImportSituatieLunara_Click();
							actionImportLuna = "";
							((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ActionInitializareLunaValoare" )).Value = "";
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
		}
		#endregion

		#region import fisier situatie lunara
		//Lungu Andreea - 03.11.2009
		public string ImportSituatieLunara(string fileName)
		{
			ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - start - ImportSituatieLunara() - lunaID: " + lunaID + " - " + fileName);
			Salaries.Data.ImportFisier sitData = new Salaries.Data.ImportFisier();
			DataTable dt = sitData.GetDataTableFromImport(fileName);

			string mesajImport = "";
			try
			{
				foreach (DataRow dr in dt.Rows)
				{
					//determin id-ul angajatului pe baza marcii
					string marca = dr["Marca"].ToString();
					string nrOreSupl100 = dr["Nr Ore Supl 100%"].ToString();
					string nrOreSupl200 = dr["Nr Ore Supl 200%"].ToString();
					string drepturiInNatura = dr["Drepturi in natura"].ToString();
					string alteDrepturi = dr["Alte drepturi brut"].ToString();
					string alteDrepturiNet = dr["Alte drepturi net"].ToString();
					string ajutorDeces = dr["Ajutor de deces"].ToString();
					string avans = dr["Avans"].ToString();
					string emService = dr["Emergency service"].ToString();
					string primaProiect = dr["Prima proiect"].ToString();
					string primeSpeciale = dr["Prime speciale"].ToString();
					string regularizare = dr["Regularizare"].ToString();
					string sporActivSup = dr["Spor activitati suplimentare"].ToString();
					string retinere1 = dr["Retinere_1"].ToString();
					string retinere2 = dr["Retinere_2"].ToString();
					string retinere3 = dr["Retinere_3"].ToString();
					string retinere4 = dr["Retinere_4"].ToString();
					string retinere5 = dr["Retinere_5"].ToString();
					string retinere6 = dr["Retinere_6"].ToString();
					string retinere7 = dr["Retinere_7"].ToString();
					string corectiiTichete = dr["Corectii tichete"].ToString();	
					string diurnaImpozabila = dr["Diurna impozabila"].ToString();

					Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
					ang.Marca = marca;
					int idAngajat = ang.GetAngajatIDByMarca(marca);
					if (idAngajat != -1)
					{
						try
						{
							Salaries.Business.SituatieLunaraAngajat sitAngajat = new Salaries.Business.SituatieLunaraAngajat(idAngajat);
							Salaries.Data.InfoSituatieLunara infoSitAng = sitAngajat.GetSituatieLunaraAngajat(idAngajat, lunaID);
							//pastrez retinerile vechi
							decimal retinere1_veche = infoSitAng.Retineri1;
							decimal retinere2_veche = infoSitAng.Retineri2;
							decimal retinere3_veche = infoSitAng.Retineri3;
							decimal retinere4_veche = infoSitAng.Retineri4;
							decimal retinere5_veche = infoSitAng.Retineri5;
							decimal retinere6_veche = infoSitAng.Retineri6;
							decimal retinere7_veche = infoSitAng.Retineri7;
							
							//ore suplim 50% ?????
							infoSitAng.NrOreSup50Proc = Int32.Parse(nrOreSupl100);
							infoSitAng.NrOreSup100Proc = Int32.Parse(nrOreSupl200);
							infoSitAng.DrepturiInNatura = Decimal.Parse(drepturiInNatura);
							infoSitAng.AlteDrepturi = Decimal.Parse(alteDrepturi);
							infoSitAng.AlteDrepturiNet = Decimal.Parse(alteDrepturiNet);
							infoSitAng.AjutorDeces = Decimal.Parse(ajutorDeces);
							infoSitAng.Avans = Decimal.Parse(avans);
							infoSitAng.EmergencyService = Decimal.Parse(emService);
							infoSitAng.PrimaProiect = Decimal.Parse(primaProiect);
							infoSitAng.PrimeSpeciale = Decimal.Parse(primeSpeciale);
							infoSitAng.Regularizare = Decimal.Parse(regularizare);
							infoSitAng.SporActivitatiSup = Decimal.Parse(sporActivSup);
							if (infoSitAng.CorectiiTichete == 0 && !corectiiTichete.Equals(""))
								infoSitAng.CorectiiTichete = (float) Decimal.Parse(corectiiTichete);
							infoSitAng.DiurnaImpozabila = Decimal.Parse(diurnaImpozabila);

							#region retineri
							Salaries.Configuration.ModuleSettings settings = Salaries.Configuration.ModuleConfig.GetSettings();
							Salaries.Data.RetineriRecurenteAngajat retineri = new Salaries.Data.RetineriRecurenteAngajat(settings.ConnectionString);
							if (retinere1_veche==0) 
								infoSitAng.Retineri1 = Decimal.Parse(retinere1);
							else
							{
								int nr = retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_1",dataStartLunaActiva, dataEndLunaActiva);
								if (nr == 0)
									infoSitAng.Retineri1 = Decimal.Parse(retinere1);
								else
									mesajImport += "Pt angajatul " + dr["Nume si Prenume"].ToString() + " exista deja o valoare pentru Retinere_1." + Environment.NewLine;
							}
							if (retinere2_veche==0) 
								infoSitAng.Retineri2 = Decimal.Parse(retinere2);
							else
							{
								int nr = retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_2",dataStartLunaActiva, dataEndLunaActiva);
								if (nr == 0)
									infoSitAng.Retineri2 = Decimal.Parse(retinere2);
								else
									mesajImport += "Pt angajatul " + dr["Nume si Prenume"].ToString() + " exista deja o valoare pentru Retinere_2." + Environment.NewLine;
							}
							if (retinere3_veche==0) 
								infoSitAng.Retineri3 = Decimal.Parse(retinere3);
							else
							{
								int nr = retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_3",dataStartLunaActiva, dataEndLunaActiva);
								if (nr == 0)
									infoSitAng.Retineri3 = Decimal.Parse(retinere3);
								else
									mesajImport += "Pt angajatul " + dr["Nume si Prenume"].ToString() + " exista deja o valoare pentru Retinere_3." + Environment.NewLine;
							}
							if (retinere4_veche==0) 
								infoSitAng.Retineri4 = Decimal.Parse(retinere4);
							else
							{
								int nr = retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_4",dataStartLunaActiva, dataEndLunaActiva);
								if (nr == 0)
									infoSitAng.Retineri4 = Decimal.Parse(retinere4);
								else
									mesajImport += "Pt angajatul " + dr["Nume si Prenume"].ToString() + " exista deja o valoare pentru Retinere_4." + Environment.NewLine;
							}
							if (retinere5_veche==0) 
								infoSitAng.Retineri5 = Decimal.Parse(retinere5);
							else
							{
								int nr = retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_5",dataStartLunaActiva, dataEndLunaActiva);
								if (nr == 0)
									infoSitAng.Retineri5 = Decimal.Parse(retinere5);
								else
									mesajImport += "Pt angajatul " + dr["Nume si Prenume"].ToString() + " exista deja o valoare pentru Retinere_5." + Environment.NewLine;
							}
							if (retinere6_veche==0) 
								infoSitAng.Retineri6 = Decimal.Parse(retinere6);
							else
							{
								int nr = retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_6",dataStartLunaActiva, dataEndLunaActiva);
								if (nr == 0)
									infoSitAng.Retineri6 = Decimal.Parse(retinere6);
								else
									mesajImport += "Pt angajatul " + dr["Nume si Prenume"].ToString() + " exista deja o valoare pentru Retinere_6." + Environment.NewLine;
							}
							if (retinere7_veche==0) 
								infoSitAng.Retineri7 = Decimal.Parse(retinere7);
							else
							{
								int nr = retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_7",dataStartLunaActiva, dataEndLunaActiva);
								if (nr == 0)
									infoSitAng.Retineri7 = Decimal.Parse(retinere7);
								else
									mesajImport += "Pt angajatul " + dr["Nume si Prenume"].ToString() + " exista deja o valoare pentru Retinere_7." + Environment.NewLine;
							}
							#endregion
													
							/*if (retinere1_veche==0 || (retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_1",dataStartLunaActiva, dataEndLunaActiva)==0)) //sau puteam sa pun  if (infoSitAng.Retineri1==0)
								infoSitAng.Retineri1 = Decimal.Parse(retinere1);
							if (retinere2_veche==0 || (retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_2",dataStartLunaActiva, dataEndLunaActiva)==0))
								infoSitAng.Retineri2 = Decimal.Parse(retinere2);
							if (retinere3_veche==0 || (retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_3",dataStartLunaActiva, dataEndLunaActiva)==0))
								infoSitAng.Retineri3 = Decimal.Parse(retinere3);
							if (retinere4_veche==0 || (retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_4",dataStartLunaActiva, dataEndLunaActiva)==0))
								infoSitAng.Retineri4 = Decimal.Parse(retinere4);
							if (retinere5_veche==0 || (retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_5",dataStartLunaActiva, dataEndLunaActiva)==0))
								infoSitAng.Retineri5 = Decimal.Parse(retinere5);
							if (retinere6_veche==0 || (retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_6",dataStartLunaActiva, dataEndLunaActiva)==0))
								infoSitAng.Retineri6 = Decimal.Parse(retinere6);
							if (retinere7_veche==0 || (retineri.VerificaIntersectieNrRetineri(idAngajat,"Retinere_7",dataStartLunaActiva, dataEndLunaActiva)==0))
								infoSitAng.Retineri7 = Decimal.Parse(retinere7);*/

							sitAngajat.ModifSituatieLunaraAngajat(infoSitAng);
							//sitAngajat.GenerareSituatieLunaraAngajat(idAngajat, lunaID);

							//ore 100%
							Salaries.Business.Luni l = new Salaries.Business.Luni(angajatorID);
							Salaries.Data.LunaData ld = l.GetDetalii( lunaID );
							int tipIntervalID = new SiemensTM.Classes.IntervaleAngajat( idAngajat ).GetTipIntervalIDByName( Salaries.Business.SituatieLunaraAngajat.denumireOreLucrate[ 1 ] );;
							int valEroare = new SiemensTM.Classes.IntervaleAngajat( idAngajat ).DistribuieOreSuplimentareTip( ld.Data, tipIntervalID, infoSitAng.NrOreSup50Proc, 0, 0 );
							if( valEroare == 1 )
							{
								mesajImport += "Pt angajatul " + dr["Nume si Prenume"].ToString() + " nr de ore suplimentare 100% depaseste nr de ore disponibile. " + Environment.NewLine;
							}

							//ore 200%
							tipIntervalID = new SiemensTM.Classes.IntervaleAngajat( idAngajat ).GetTipIntervalIDByName( Salaries.Business.SituatieLunaraAngajat.denumireOreLucrate[ 2 ] );;
							valEroare =  new SiemensTM.Classes.IntervaleAngajat( idAngajat ).DistribuieOreSuplimentareTip( ld.Data, tipIntervalID, infoSitAng.NrOreSup100Proc, 0, 1 );
							if( valEroare == 1 )
							{
								mesajImport += "Pt angajatul " + dr["Nume si Prenume"].ToString() + " nr de ore suplimentare 200% depaseste nr de ore disponibile. " + Environment.NewLine;
							}
						}
						catch(Exception exc)
						{
							string msg = "Datele pt angajatul " + dr["Nume si Prenume"].ToString() + " sunt eronate. " + Environment.NewLine;
							mesajImport += "Datele pt angajatul " + dr["Nume si Prenume"].ToString() + " sunt eronate. " + Environment.NewLine;
							//ar trebui sa scriu intr-un fisier ca sa pot da un feedback
							ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - error - ImportSituatieLunara() - '" + msg + "' " + " - " + exc.Message);
						}
					}
					else
					{
						if (!dr["Marca"].ToString().Equals(""))
							mesajImport += "Nu exista angajatul cu marca " + dr["Marca"].ToString() + Environment.NewLine;
						//ar trebui sa scriu intr-un fisier ca sa pot da un feedback
					}
				}
			}
			catch(Exception exc)
			{
				mesajImport += "Fisierul nu este in formatul corespunzator";
				ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - error - ImportSituatieLunara() - 'Fisierul nu este in formatul corespunzator' " + " - " + exc.Message);
			}
			ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - end - ImportSituatieLunara() - lunaID: " + lunaID + " - " + fileName);
			return mesajImport;
		}
		#endregion

		//////////////////////////////
		#region id-uri pentru tip absenta
		private void GetIdTipAbsente()
		{
			//tip absenta - cod absenta
			Salaries.Business.NomenclatorTipAbsente tipAbs = new Salaries.Business.NomenclatorTipAbsente();
			Salaries.Data.TipAbsente[] sirTipuri= tipAbs.GetDetaliiTipuriAbsente();
			foreach ( Salaries.Data.TipAbsente item in sirTipuri)
			{
				if (item.CodAbsenta.Equals("CM"))
					idCM = item.TipAbsentaID;
				if (item.CodAbsenta.Equals("CCM"))
					idCCM = item.TipAbsentaID;
				if (item.CodAbsenta.Equals("CO"))
					idCO = item.TipAbsentaID;
				if (item.CodAbsenta.Equals("COA"))
					idCOA = item.TipAbsentaID;
			}
		}
		#endregion
		
		#region import fisier pontaj
		//Lungu Andreea - 03.11.2009
		public string ImportFisierPontaj(string fileName)
		{
			ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - start - ImportPontaj() - lunaID: " + lunaID + " - " + fileName);
			string marca = "", numePrenume = "", dataI = "", dataS = "", observatii = "", tipAbsenta = "", boala = "", serie = "", numar = "" ;
			Salaries.Data.ImportFisier imp = new Salaries.Data.ImportFisier();
			DataTable dt = imp.GetDataTableFromImport(fileName);
			bool esteCertificatInitial = false;
			string serieCertificatInitial = "", numarCertificatInitial = "", dataA = "", cnpCopil = "", loculPrescrierii = "", codUrgenta = "", nrAvizExpert = "";
			DateTime dataAcordarii;

			string mesajImport = "";
			foreach (DataRow dr in dt.Rows)
			{
				//determin id-ul angajatului pe baza marcii
				try
				{
					marca = dr["Marca"].ToString();
					numePrenume = dr["Nume si Prenume"].ToString();
					dataI = dr["Prima zi absenta"].ToString();
					dataS = dr["Ultima zi absenta"].ToString();
					observatii = dr["Observatii"].ToString();
					tipAbsenta = dr["Tip absenta"].ToString();
					boala = dr["Boala"].ToString();
					serie = dr["Serie"].ToString();
					numar = dr["Numar"].ToString();
					if (dr["Este certificat initial"].ToString().Trim().Equals("Da"))
                        esteCertificatInitial = true;
					else
						esteCertificatInitial = false;
					serieCertificatInitial = dr["Serie certificat initial"].ToString();
					numarCertificatInitial = dr["Numar certificat initial"].ToString();
					dataA = dr["Data acordarii"].ToString();
					cnpCopil = dr["Cnp copil"].ToString();
					loculPrescrierii = dr["Locul prescrierii"].ToString();
					codUrgenta = dr["Cod urgenta"].ToString();
					nrAvizExpert = dr["Nr aviz medic expert"].ToString();
					if (!boala.Trim().Equals("") && !dataA.Trim().Equals(""))
						dataAcordarii = Utilities.ConvertText2DateTime(dataA.Substring(0,dataA.IndexOf(" ")));
					else
						dataAcordarii = DateTime.Now;
				}
				catch(Exception exc)
				{
					mesajImport += "Fisierul nu este in formatul corespunzator";
					ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - error - ImportPontaj() - 'Fisierul nu este in formatul corespunzator' ");
					break;
				}

				Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
				ang.Marca = marca;
				int idAngajat = ang.GetAngajatIDByMarca(marca);
				ang.LoadAngajat();
				bool esteLichidat = true;
				if ((ang.DataLichidare == DateTime.MinValue) || (ang.DataLichidare>dataStartLunaActiva))
					esteLichidat = false;
				
				if ((idAngajat != -1) && (!esteLichidat))
				//if (idAngajat != -1)
				{
					DateTime dataInceput = new DateTime();
					DateTime dataSfarsit = new DateTime();
					bool intervaleCorecte = true;
					try
					{
						//aici eventual sa si verific daca sunt in luna activa
						dataInceput = Utilities.ConvertText2DateTime(dataI.Substring(0,dataI.IndexOf(" ")));
						dataSfarsit = Utilities.ConvertText2DateTime(dataS.Substring(0,dataS.IndexOf(" ")));
						if ((dataInceput < dataStartLunaActiva && dataSfarsit < dataStartLunaActiva) ||
							(dataInceput > dataEndLunaActiva && dataSfarsit > dataEndLunaActiva))
						{
							intervaleCorecte = false;
							mesajImport += "Intervalele pt angajatul " + numePrenume + " nu sunt in luna curenta. " +  Environment.NewLine;
						}
						else
						{
							if (dataInceput < dataStartLunaActiva && dataSfarsit>= dataStartLunaActiva && dataSfarsit <= dataEndLunaActiva) //doar datasfarsit e in luna activa
								dataInceput = dataStartLunaActiva;
							if (dataInceput >= dataStartLunaActiva && dataInceput <= dataEndLunaActiva && dataSfarsit > dataEndLunaActiva) //doar datainceput e in luna activa
								dataSfarsit = dataEndLunaActiva;
							if (dataInceput < dataStartLunaActiva && dataSfarsit > dataEndLunaActiva)
							{
								dataInceput = dataStartLunaActiva;
								dataSfarsit = dataEndLunaActiva;
							}
						}
					}
					catch(Exception exc)
					{
						intervaleCorecte = false;
						string msg = "Intervalele pt angajatul " + numePrenume + " sunt gresite. " +  Environment.NewLine;
						mesajImport += "Intervalele pt angajatul " + numePrenume + " sunt gresite. " +  Environment.NewLine;
						//ar trebui sa scriu intr-un fisier ca sa pot da un feedback
						ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - error - ImportPontaj() - '" + msg + "' ");
			
					}
					if (intervaleCorecte)
						mesajImport += AddIntervalAbsenteOperation(numePrenume, marca, dataInceput, dataSfarsit, observatii, tipAbsenta, boala, serie, numar, esteCertificatInitial, serieCertificatInitial, numarCertificatInitial, dataAcordarii, cnpCopil, loculPrescrierii, codUrgenta, nrAvizExpert);
				}
				else
				{
					if (!dr["Marca"].ToString().Equals(""))
						mesajImport += "Nu exista angajatul cu marca " + dr["Marca"].ToString() + Environment.NewLine;
					//ar trebui sa scriu intr-un fisier ca sa pot da un feedback
					/*if (esteLichidat)
						mesajImport += "Angajatul " + dr["Nume si Prenume"].ToString() + " este lichidat.";*/
				}
			}
			ErrHandler.MyErrHandler.WriteError("ImportPontaj.ascx - end - ImportPontaj() - lunaID: " + lunaID + " - " + fileName);
			return mesajImport;
		}
		#endregion

		#region add interval absenta
		private string AddIntervalAbsenteOperation(string numePrenume, string marcaAngajat, DateTime dataInceput, DateTime dataSfarsit, string observatii, string tipAbsenta, string boala, string serie, string numar, bool esteCertificatInitial, string serieCertificatInitial, string numarCertificatInitial, DateTime dataAcordarii, string cnpCopil, string loculPrescrierii, string codUrgenta, string nrAvixExpert)
		{
			string mesaj = "";
			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.Marca = marcaAngajat;
			int idAngajat = ang.GetAngajatIDByMarca(marcaAngajat);
			
			if (idAngajat!=-1)
			{
				//tip absenta - cod absenta
				Salaries.Business.NomenclatorTipAbsente tipAbs = new Salaries.Business.NomenclatorTipAbsente();
				Salaries.Data.TipAbsente[] sirTipuri= tipAbs.GetDetaliiTipuriAbsente();
				int idTipAbsenta = -1;
				foreach ( Salaries.Data.TipAbsente item in sirTipuri)
				{
					if (item.CodAbsenta.Equals(tipAbsenta))
						idTipAbsenta = item.TipAbsentaID;
				}

				if (idTipAbsenta!=-1)
				{
					if (boala.Equals("") && (idTipAbsenta!=idCM) && (idTipAbsenta!=idCCM))
					{
						//nu am cm sau ccm
						//introduc 
						mesaj += AdaugaAbsenta(numePrenume, marcaAngajat, idAngajat, dataInceput, dataSfarsit, observatii, idTipAbsenta, -1, null, null, false, null, null, DateTime.Today, null, null, null, null);
					}
					else
					{
						int idBoala = -1;
						Salaries.Business.NomenclatorBoli boli = new Salaries.Business.NomenclatorBoli();
						DataSet dsBoli = boli.GetBoli();
						foreach(DataRow drBoala in dsBoli.Tables[0].Rows)
						{
							string codBoala = drBoala["Cod"].ToString() + " - " + drBoala["Categorie"].ToString();
							if  (boala.Equals(codBoala))
							{
								idBoala = Int32.Parse(drBoala["BoalaID"].ToString());
								break;
							}
						}
						if (idBoala!=-1)
						{
							//ok introduc intervalul de absenta 
							mesaj += AdaugaAbsenta(numePrenume, marcaAngajat, idAngajat, dataInceput, dataSfarsit, observatii, idTipAbsenta, idBoala, serie, numar, esteCertificatInitial, serieCertificatInitial, numarCertificatInitial, dataAcordarii, cnpCopil, loculPrescrierii, codUrgenta, nrAvixExpert);
						}
						else
						{
							//nu e corecta boala
							mesaj += "Pentru angajatul " + numePrenume + " nu este corect tipul bolii." + Environment.NewLine;
						}
					}	
				}
				else
					//nu e bun tipul absentei
					mesaj += "Pentru angajatul " + numePrenume + " nu este corect tipul absentei." + Environment.NewLine;
			}
			else
				mesaj += "Nu a fost gasit angajatul " + numePrenume + "." + Environment.NewLine;
			return mesaj;
		}

		public string AdaugaAbsenta(string numePrenume, string marcaAngajat, int idAngajat, DateTime dataInceput, DateTime dataSfarsit, string observatii, int idTipAbsenta, int idBoala, string serie, string numar, bool esteCertificatInitial, string serieCertificatInitial, string numarCertificatInitial, DateTime dataAcordarii, string cnpCopil, string loculPrescrierii, string codUrgenta, string nrAvixExpert)
		{
			string msg = "";
			//verificare daca e absenta lucratoare
			DataSet dsIntervalAbsenta = new IntervaleAbsenteAngajat(idAngajat).GetTipIntervalAbsentaAngajat(idTipAbsenta);
			bool lucratoare = false;
			try
			{
				if( dsIntervalAbsenta.Tables[0].Rows.Count>0 && (bool)dsIntervalAbsenta.Tables[0].Rows[0]["Lucratoare"] )
				{
					lucratoare = true;
				}
			}
			catch
			{
				lucratoare = false;
			}
			SiemensTM.Module.Intervale intervUC = new SiemensTM.Module.Intervale();
			intervUC.AngajatID = idAngajat;
			bool existaIntervalDeja = new IntervaleAbsenteAngajat(idAngajat).CheckExistaIntervalAbsenta(dataInceput,dataSfarsit, idTipAbsenta, idBoala);
			if (!existaIntervalDeja)
			{
				//verificare de introducere
				int potIntrodInBD = new IntervaleAbsenteAngajat(idAngajat).IntersectieCuAlteIntervaleAbsente( dataInceput, dataSfarsit, -1 );
				switch( potIntrodInBD )
				{
					case 0:
						string [][]tmp = GetOreLucrateIntervaleSpecialeLuna(idAngajat);
						msg += Insert(numePrenume, idAngajat, dataInceput, dataSfarsit, observatii, idTipAbsenta, idBoala, serie, numar, esteCertificatInitial, serieCertificatInitial, numarCertificatInitial, dataAcordarii, cnpCopil, loculPrescrierii, codUrgenta, nrAvixExpert);
						RedistribuireOreSuplimentareLunaAngajat(tmp, idAngajat);
						break;
					case 1:	
						msg += "Pentru angajatul " + numePrenume + " data de inceput este inclusa in alt interval." + Environment.NewLine;
						break;
					case 2:
						msg += "Pentru angajatul " + numePrenume + " data de sfarsit este inclusa in alt interval." + Environment.NewLine;
						break;
					case 3:
						msg += "Pentru angajatul " + numePrenume + " data de inceput si de sfarsit sunt incluse in alt interval." + Environment.NewLine;
						break;
					case 4:
						msg += "Pentru angajatul " + numePrenume + " intervalul contine un alt interval." + Environment.NewLine;
						break;
					case 5:
						bool tipContinuareAbsenta = intervUC.VerificaTipContinuareAbsenta( idTipAbsenta,new IntervaleAbsenteAngajat(idAngajat));
						if( !lucratoare  && !tipContinuareAbsenta)
						{
							new IntervaleAngajat(idAngajat).DeleteTemporarIntervaleAngajatPerioada(dataInceput, dataSfarsit, false);
						}
						tmp = GetOreLucrateIntervaleSpecialeLuna(idAngajat);
						msg += Insert(numePrenume, idAngajat, dataInceput, dataSfarsit, observatii, idTipAbsenta, idBoala, serie, numar, esteCertificatInitial, serieCertificatInitial, numarCertificatInitial, dataAcordarii, cnpCopil, loculPrescrierii, codUrgenta, nrAvixExpert);
						RedistribuireOreSuplimentareLunaAngajat(tmp, idAngajat);
						break;
					case 6:
						msg += "Pentru angajatul " + numePrenume + " data de inceput este inclusa intr-o intrerupere de contract." + Environment.NewLine;
						break;
					case 7:
						msg += "Pentru angajatul " + numePrenume + " data de sfarsit este inclusa intr-o intrerupere de contract." + Environment.NewLine;
						break;
					case 8:
						msg += "Pentru angajatul " + numePrenume + " data de inceput si de sfarsit sunt incluse intr-o intrerupere de contract." + Environment.NewLine;
						break;
					case 9:
						msg += "Pentru angajatul " + numePrenume + " intervalul contine o intrerupere de contract." + Environment.NewLine;
						break;
					default:
						break;
				}
			}
			return msg;
		}

		private String Insert(string numePrenume, int idAngajat, DateTime dataInceput, DateTime dataSfarsit, string observatii, int idTipAbsenta, int idBoala, string serie, string numar, bool esteCertificatInitial, string serieCertificatInitial, string numarCertificatInitial, DateTime dataAcordarii, string cnpCopil, string loculPrescrierii, string codUrgenta, string nrAvixExpert)
		{
			string msg = "";
			//tip interval???
			IntervaleAbsenteAngajat interval = new IntervaleAbsenteAngajat(idAngajat);
			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.AngajatId = idAngajat;
			//oare trebuie sa fac load angajat????
			double medieZilnicaConcediuOdihna = ang.GetMedieZilnicaConcediuDeOdihna(lunaID);
			double medieZilnicaConcediuBoala = ang.GetMedieZilnicaConcediuDeBoala(lunaID);
			double medieZilnicaContinuareConcediuBoala = ang.GetMedieZilnicaContinuareConcediuDeBoala(lunaID);
			
			// ca la insert interval absenta
			SiemensTM.Module.Intervale intervUC = new SiemensTM.Module.Intervale();
			intervUC.AngajatID = idAngajat;
			bool continuareAbsenta = intervUC.VerificaContinuareAbsenta( idTipAbsenta, dataInceput );
			//int boalaID = -1;
			/*if( FolosesteBoli( idTipAbsenta ))
			{
				boalaID = int.Parse( ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "TipBoalaAbsente1" )).Value );
			}*/
			IntervaleAbsenteAngajat intervAbs = new IntervaleAbsenteAngajat( idAngajat );
			if( continuareAbsenta || ( !intervUC.VerificaTipContinuareAbsenta( idTipAbsenta, intervAbs )))
			{
				bool tipContinuareAbsenta = intervUC.VerificaTipContinuareAbsenta( idTipAbsenta,new IntervaleAbsenteAngajat( idAngajat ));
				if( tipContinuareAbsenta)
					new IntervaleAngajat( idAngajat ).DeleteTemporarIntervaleAngajatPerioada( dataInceput, dataSfarsit, false);

				if (idTipAbsenta == idCO || idTipAbsenta == idCOA)
					new IntervaleAbsenteAngajat( idAngajat ).InsertIntervalAbsenteAngajat( idTipAbsenta, dataInceput, dataSfarsit, observatii, idBoala, continuareAbsenta, medieZilnicaConcediuOdihna, serie, numar, esteCertificatInitial, serieCertificatInitial, numarCertificatInitial, dataAcordarii, cnpCopil, loculPrescrierii, codUrgenta, nrAvixExpert);
				else if (idTipAbsenta == idCM)
					new IntervaleAbsenteAngajat( idAngajat ).InsertIntervalAbsenteAngajat( idTipAbsenta, dataInceput, dataSfarsit, observatii, idBoala, continuareAbsenta, medieZilnicaConcediuBoala, serie, numar, esteCertificatInitial, serieCertificatInitial, numarCertificatInitial, dataAcordarii, cnpCopil, loculPrescrierii, codUrgenta, nrAvixExpert);
				else if (idTipAbsenta == idCCM)
					new IntervaleAbsenteAngajat( idAngajat ).InsertIntervalAbsenteAngajat( idTipAbsenta, dataInceput, dataSfarsit, observatii, idBoala, continuareAbsenta, medieZilnicaContinuareConcediuBoala, serie, numar, esteCertificatInitial, serieCertificatInitial, numarCertificatInitial, dataAcordarii, cnpCopil, loculPrescrierii, codUrgenta, nrAvixExpert);
				else
					new IntervaleAbsenteAngajat( idAngajat ).InsertIntervalAbsenteAngajat( idTipAbsenta, dataInceput, dataSfarsit, observatii, idBoala, continuareAbsenta, 0, serie, numar, esteCertificatInitial, serieCertificatInitial, numarCertificatInitial, dataAcordarii, cnpCopil, loculPrescrierii, codUrgenta, nrAvixExpert);
			}
			else
			{
				msg += "Pentru angajatul  " + numePrenume + " continuarea absentei medicale nu se poate lega de concediul medical!" + Environment.NewLine ;
			}
			return msg;
		}
		//poate fi intr-o clasa separata
		private string[][] GetOreLucrateIntervaleSpecialeLuna(int idAngajat)
		{
			IntervaleAngajat ia = new IntervaleAngajat(idAngajat);
			DataSet ds = ia.GetTipuriIntervaleOreSuplimentare();

			//col1 = id-ul tipului de interval; col2 = nr de ore suplimentare pe luna; col3 = ore suplimentare normale sau de weekend-noapte
			string [][]tmp = new string[ ds.Tables[ 0 ].Rows.Count][];
			int i=0;
			DateTime dataSt = new DateTime(dataStartLunaActiva.Year, dataStartLunaActiva.Month, 1 );
			DateTime dataEnd = new DateTime(dataStartLunaActiva.Year, dataStartLunaActiva.Month, DateTime.DaysInMonth(dataStartLunaActiva.Year,dataStartLunaActiva.Month));
								
			foreach( DataRow dr in ds.Tables[ 0 ].Rows )
			{
				tmp[ i ] = new string[ 3 ];
				tmp[ i ][ 0 ] = dr[ "TipIntervalID" ].ToString();
				tmp[ i ][ 1 ] = ia.GetNrOreLucratePerioadaTip( dataSt, dataEnd, int.Parse( tmp[ i ][ 0 ] )).ToString();
				tmp[ i ][ 2 ] = dr[ "AplicWeekendNoapte" ].ToString();
				i++;
			}
			return tmp;
		}
		//poate fi intr-o clasa separata
		private void RedistribuireOreSuplimentareLunaAngajat(string[][] tmp, int idAngajat)
		{
			for( int j=0; j<tmp.Length; j++ )
			{
				int tipIntervalID = int.Parse( tmp[ j ][ 0 ] );
				double nrOreSuplimentare = double.Parse( tmp[ j ][ 1 ] );
				int tipOraSupl = bool.Parse( tmp[ j ][ 2 ].ToLower())? 1 : 0;

				double nrOreSuplimentare_old = 0;

				int valEroare = new IntervaleAngajat(idAngajat).DistribuieOreSuplimentareTip(dataStartLunaActiva, tipIntervalID, nrOreSuplimentare, nrOreSuplimentare_old, tipOraSupl );
				if( valEroare == 1 )
				{
					Response.Write( "<script>alert( 'Numarul de ore suplimentare depaseste numarul de ore disponibile!' );</script>" );
				}
			}
		}
		#endregion

		#region comentat - diverse incercari
		/*private void Update(int idAngajat, DateTime dataInceput, DateTime dataSfarsit, string observatii, int idTipAbsenta, int idBoala, string serie, string numar)
		{
			SiemensTM.Module.Intervale intervUC = new SiemensTM.Module.Intervale();
			intervUC.AngajatID = idAngajat;
			bool continuareAbsenta = intervUC.VerificaContinuareAbsenta(idTipAbsenta, dataInceput);
			int boalaID = -1;
			if( intervUC.FolosesteBoli(idTipAbsenta))
			{
				boalaID = idBoala;
			}
                            
			IntervaleAbsenteAngajat iaa = new IntervaleAbsenteAngajat(idAngajat);
			if( continuareAbsenta || ( !intervUC.VerificaTipContinuareAbsenta( idTipAbsenta, iaa )))
			{
				//dovle
				DataSet ds = iaa.GetIntervalAbsentaAngajatByID( IntervalID );
				if( ds.Tables[ 0 ].Rows.Count > 0 && ds != null )
				{
					if((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ]>dataSfarsit )
					{
						new IntervaleAngajat(idAngajat).RestoreIntervaleAngajatPerioadaSterseTemporar( dataSfarsit.AddDays( 1 ), (DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataEnd" ] );
					}
					if((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ]<dataInceput )
					{
						new IntervaleAngajat(idAngajat).RestoreIntervaleAngajatPerioadaSterseTemporar((DateTime)ds.Tables[ 0 ].Rows[ 0 ][ "DataStart" ], dataInceput.AddDays( -1 ));
					}					
				}
				iaa.UpdateIntervalAbsenteAngajat( IntervalID, idTipAbsenta, dataInceput, dataSfarsit, observatii, boalaID, continuareAbsenta, medieZilnica, serie, numar );
			}
			else
			{
				Response.Write( "<script> alert( '"+Definitions.alertContinuareAbsentaMedicala+"' );</script>" );
			}
		}*/
		#endregion

	}
}
