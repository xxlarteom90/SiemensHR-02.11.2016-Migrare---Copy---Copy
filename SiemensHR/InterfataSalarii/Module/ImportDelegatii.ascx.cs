/*
 * Modificat:	Lungu Andreea
 * Data:		24.08.2010
 * Descriere:	Importul delegatiilor.
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
	///		Summary description for ImportDelegatii.
	/// </summary>
	public class ImportDelegatii : SiemensHR.InterfataSalarii.Classes.BaseModule
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
		private string actionImportDelegatiiLuna = "";
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
		protected System.Security.Principal.WindowsPrincipal user;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdRezultateImport;
		private Salaries.Data.TipAbsente[] sirTipuri;
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
			actionImportDelegatiiLuna = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ActionImportDelegatiiLunaValue" )).Value;
				
			Salaries.Business.NomenclatorTipAbsente tipAbs = new Salaries.Business.NomenclatorTipAbsente();
			sirTipuri= tipAbs.GetDetaliiTipuriAbsente();

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
		private void ButtonImportDelegatii_Click()
		{
			ErrHandler.MyErrHandler.WriteError("ImportDelegatii.ascx - start - click_ImportDelegatii() - lunaID: " + lunaID);
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
					ScrieInFisierDate(caleFisier, "delegatii", dt);
					
					//------
					string mesajImport = ImportFisierDelegatii(caleFisier);
					//aici as putea sa si adaug in bd 	
					System.IO.StreamWriter swRez = new System.IO.StreamWriter(Server.MapPath("Templates\\RezultateImport.txt"), false);
					if (mesajImport.IndexOf("Fisierul nu este in formatul corespunzator")>=0)
					{
						lblMesajImport.Text = "Fisierul nu este in formatul corespunzator";
						swRez.WriteLine("Fisierul nu este in formatul corespunzator. \r\n");
						lblMesaj.Text = "";
					}
					else
					{
						lblMesajImport.Text = "A fost importat fisierul pentru delegatii. \r\n";
						swRez.WriteLine("A fost importat fisierul pentru delegatii. \r\n");
						if (!mesajImport.Equals(""))
						{
							swRez.WriteLine("Probleme: \r\n");
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
			ErrHandler.MyErrHandler.WriteError("ImportDelegatii.ascx - end - click_ImportDelegatii() - lunaID: " + lunaID);
		}
		#endregion

		#region save file on server
		public string SaveFileOnServer(System.Web.UI.HtmlControls.HtmlInputFile fileImport)
		{
			ErrHandler.MyErrHandler.WriteError("ImportDelegatii.ascx - start - SaveFileOnServer() - lunaID: " + lunaID + " - " + fileImportFisier.PostedFile.FileName);
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
				ErrHandler.MyErrHandler.WriteError("ImportDelegatii.ascx - error - SaveFileOnServer() - lunaID: " + lunaID + " - " + ex.Message);
			}
			ErrHandler.MyErrHandler.WriteError("ImportDelegatii.ascx - end - SaveFileOnServer() - lunaID: " + lunaID + " - " + SaveLocation);
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
				lblMesajImport.Text = "Nu se pot importa date pentru delegatii decat in luna activa!";
			}
			else
			{
				switch( actionImportDelegatiiLuna )
				{
					case "importDelegatii":
						lblMesaj.Text = "";
						lblMesajImport.Text = "";
						if (!fileImportFisier.Value.Equals(""))
						{
							ButtonImportDelegatii_Click();
							actionImportDelegatiiLuna = "";
							((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "ActionImportDelegatiiLunaValue" )).Value = "";
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
		
		#region import fisier delegatii
		//Lungu Andreea - 03.11.2009
		public string ImportFisierDelegatii(string fileName)
		{
			ErrHandler.MyErrHandler.WriteError("ImportDelegatii.ascx - start - ImportDelegatii() - lunaID: " + lunaID + " - " + fileName);
			string marca = "", numePrenume = "", perioada = "", tipDelegatie = "", observatii = "";
			int luna = 0, an = 0;
			tipDelegatie = "DE";
			observatii = "";
			Salaries.Data.ImportFisier imp = new Salaries.Data.ImportFisier();
			DataTable dt = imp.GetDataTableFromImport(fileName);

			string mesajImport = "";
			if (dt.Rows.Count == 0)
			{
				mesajImport = "Fisierul nu este in formatul corespunzator sau nu contine informatii.";
				ErrHandler.MyErrHandler.WriteError("ImportDelegatii.ascx - end - ImportDelegatii() - lunaID: " + lunaID + " - " + fileName);
				return mesajImport;
			}
			bool okRow = false;
			
			//foreach (DataRow dr in dt.Rows)
			for (int index = 0; index<dt.Rows.Count; index++)
			{
				DataRow dr = dt.Rows[index];
				if (okRow && !dr.IsNull(3))
				{
					#region preiau datele din row-ul respectiv
					try
					{
						marca = dr.ItemArray[2].ToString(); //marca
						numePrenume = dr.ItemArray[3].ToString() + " " + dr.ItemArray[4].ToString(); //nume, prenume
						perioada = dr.ItemArray[5].ToString(); //Perioada depl
						luna = Int32.Parse(dr.ItemArray[7].ToString()); //luna
						an = Int32.Parse(dr.ItemArray[8].ToString()); //an
					}
					catch(Exception exc)
					{
						/*mesajImport += "Fisierul nu este in formatul corespunzator";
						ErrHandler.MyErrHandler.WriteError("ImportDelegatii.ascx - error - ImportDelegatii() - 'Fisierul nu este in formatul corespunzator' ");
						break;*/
						mesajImport += "Datele pentru " + numePrenume + " nu sunt corecte." + Environment.NewLine;
						ErrHandler.MyErrHandler.WriteError("ImportDelegatii.ascx - error - ImportDelegatii() - 'Datele pentru " + numePrenume + " nu sunt corecte.' - index row: " + dr.ToString());
						//break;
						//dr = dt.Rows[dt.Rows.
					}
					#endregion

					#region determin id-ul angajatului pe baza marcii
					//determin id-ul angajatului pe baza marcii
					Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
					ang.Marca = marca;
					int idAngajat = ang.GetAngajatIDByMarca(marca);	
					#endregion
				
					//if ((idAngajat != -1) && (!esteLichidat))
					if (idAngajat != -1)
					{
						if (!perioada.Equals("-"))
						{
							string[] perioade = perioada.Split(';');
							for(int i = 0; i < perioade.Length; i++)
							{
								if (!perioade[i].Equals(""))
								{
									#region dataInceput - dataSfarsit
									DateTime dataInceput = new DateTime();
									DateTime dataSfarsit = new DateTime();
									string[] sir = perioade[i].Split('-');
									try
									{
										if (sir.Length == 1) //am o singura zi, nu o perioada
										{
											dataInceput = new DateTime(an, luna, Int32.Parse(sir[0]));
											dataSfarsit = new DateTime(an, luna, Int32.Parse(sir[0]));
										}
										else
										{
											if (sir.Length == 2)  //am periada
											{
												dataInceput = new DateTime(an, luna, Int32.Parse(sir[0]));
												dataSfarsit = new DateTime(an, luna, Int32.Parse(sir[1]));
											}
											else
											{
												/*mesajImport += "Fisierul nu este in formatul corespunzator";
												ErrHandler.MyErrHandler.WriteError("ImportDelegatii.ascx - error - ImportDelegatii() - 'Fisierul nu este in formatul corespunzator' ");
												break;*/
												mesajImport += "Datele pentru " + numePrenume + " nu sunt corecte." + Environment.NewLine;
												ErrHandler.MyErrHandler.WriteError("ImportDelegatii.ascx - error - ImportDelegatii() - 'Datele pentru " + numePrenume + " nu sunt corecte.' - index row: " + dr.ToString());
												//break;
					
											}
										}
									}
									catch(Exception exc)
									{
										mesajImport += "Datele pentru " + numePrenume + " nu sunt corecte." + Environment.NewLine;
										ErrHandler.MyErrHandler.WriteError("ImportDelegatii.ascx - error - ImportDelegatii() - 'Datele pentru " + numePrenume + " nu sunt corecte.' - index row: " + dr.ToString());
									}
									#endregion

									#region verific daca dataInceput si dataSfarsit sunt in luna activa
									bool intervaleCorecte = true;
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
									#endregion

									if (intervaleCorecte)
										mesajImport += AddDelegatii(numePrenume, marca, dataInceput, dataSfarsit, tipDelegatie, observatii);
								}
							}
						}
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
				if (dr.ItemArray[0].ToString().Equals("Departament") && dr.ItemArray[1].ToString().Equals("Punct de lucru") && dr.ItemArray[2].ToString().Equals("Marca"))
					okRow = true;
			}
			ErrHandler.MyErrHandler.WriteError("ImportDelegatii.ascx - end - ImportDelegatii() - lunaID: " + lunaID + " - " + fileName);
			return mesajImport;
		}
		#endregion

		#region add interval absenta
		private string AddDelegatii(string numePrenume, string marcaAngajat, DateTime dataInceput, DateTime dataSfarsit, string tipDelegatie, string observatii)
		{
			string mesaj = "";
			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.Marca = marcaAngajat;
			int idAngajat = ang.GetAngajatIDByMarca(marcaAngajat);
			
			if (idAngajat!=-1)
			{
				int idTipDelegatie = -1;
				foreach ( Salaries.Data.TipAbsente item in sirTipuri)
				{
					if (item.CodAbsenta.Equals(tipDelegatie))
						idTipDelegatie = item.TipAbsentaID;
				}

				if (idTipDelegatie!=-1)
				{
					//introduc 
					mesaj += AdaugaDelegatie(numePrenume, marcaAngajat, idAngajat, dataInceput, dataSfarsit, idTipDelegatie, observatii);
				}
				else
					//nu e bun tipul absentei
					mesaj += "Pentru angajatul " + numePrenume + " nu este corect tipul absentei." + Environment.NewLine;
			}
			else
				mesaj += "Nu a fost gasit angajatul " + numePrenume + "." + Environment.NewLine;
			return mesaj;
		}

		public string AdaugaDelegatie(string numePrenume, string marcaAngajat, int idAngajat, DateTime dataInceput, DateTime dataSfarsit, int idTipAbsenta, string observatii)
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
			bool existaIntervalDeja = new IntervaleAbsenteAngajat(idAngajat).CheckExistaIntervalAbsenta(dataInceput,dataSfarsit, idTipAbsenta, -1);
			if (!existaIntervalDeja)
			{
				//verificare de introducere
				int potIntrodInBD = new IntervaleAbsenteAngajat(idAngajat).IntersectieCuAlteIntervaleAbsente( dataInceput, dataSfarsit, -1 );
				switch( potIntrodInBD )
				{
					case 0:
						string [][]tmp = GetOreLucrateIntervaleSpecialeLuna(idAngajat);
						msg += Insert(numePrenume, idAngajat, dataInceput, dataSfarsit, idTipAbsenta, observatii);
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
						msg += Insert(numePrenume, idAngajat, dataInceput, dataSfarsit, idTipAbsenta, observatii);
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
//			else
//			{
//				msg += "Pentru angajatul " + numePrenume + " intervalul de delegatii este deja introdus.";
//			}
			return msg;
		}

		private String Insert(string numePrenume, int idAngajat, DateTime dataInceput, DateTime dataSfarsit, int idTipAbsenta, string observatii)
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
			//SiemensTM.Module.Intervale intervUC = new SiemensTM.Module.Intervale();
			//intervUC.AngajatID = idAngajat;
			//bool continuareAbsenta = intervUC.VerificaContinuareAbsenta( idTipAbsenta, dataInceput );
			//int boalaID = -1;
			//if( FolosesteBoli( idTipAbsenta ))
			//{
			//	boalaID = int.Parse( ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "TipBoalaAbsente1" )).Value );
			//}
			//IntervaleAbsenteAngajat intervAbs = new IntervaleAbsenteAngajat( idAngajat );
			//if( continuareAbsenta || ( !intervUC.VerificaTipContinuareAbsenta( idTipAbsenta, intervAbs )))
			//{
			//	bool tipContinuareAbsenta = intervUC.VerificaTipContinuareAbsenta( idTipAbsenta,new IntervaleAbsenteAngajat( idAngajat ));
			//	if( tipContinuareAbsenta)
			//		new IntervaleAngajat( idAngajat ).DeleteTemporarIntervaleAngajatPerioada( dataInceput, dataSfarsit, false);
        		new IntervaleAbsenteAngajat( idAngajat ).InsertIntervalAbsenteAngajat( idTipAbsenta, dataInceput, dataSfarsit, observatii, -1, false, 0, "", "",false,"","",DateTime.Today,"","","","");
			//}
			//else
			//{
			//	msg += "Pentru angajatul  " + numePrenume + " continuarea absentei medicale nu se poate lega de concediul medical!" + Environment.NewLine ;
			//}
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
	}
}
