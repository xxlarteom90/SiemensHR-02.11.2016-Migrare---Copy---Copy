/*
 *	Modificat:	Oprescu Claudia
 *	Descriere:	Se incarca campurile de lucru ale unui anumit angajator
 */
/*
 *	Modificat:	Lungu Andreea
 *	Descriere:	S-a adaugat  un camp pentru angajator: nr. inreg Itm 
 * 
 */

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data.SqlClient;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.Administrare
{
	/// <summary>
	///		Summary description for AdminAngajatoriEdit.
	/// </summary>
	public class AdminAngajatoriEdit : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.TextBox txtDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.DropDownList lstTipPersoana;
		protected System.Web.UI.WebControls.TextBox txtCUI_CNP;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredFiliala;
		protected System.Web.UI.WebControls.TextBox txtNrInreg;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredNrInreg;
		protected System.Web.UI.WebControls.TextBox txtTelefon;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredTelefon;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.TextBox txtAdresaWeb;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.DropDownList lstDTara;
		protected System.Web.UI.WebControls.DropDownList lstDJudetSector;
		protected System.Web.UI.WebControls.TextBox txtDLocalitate;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDLocalitate;
		protected System.Web.UI.WebControls.TextBox txtDStrada;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDStrada;
		protected System.Web.UI.WebControls.TextBox txtDNumar;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDNumar;
		protected System.Web.UI.WebControls.TextBox txtDCodPostal;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDCodPostal;
		protected System.Web.UI.WebControls.TextBox txtDBloc;
		protected System.Web.UI.WebControls.TextBox txtDScara;
		protected System.Web.UI.WebControls.TextBox txtDEtaj;
		protected System.Web.UI.WebControls.TextBox txtDApartament;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnSterge;
		protected System.Web.UI.WebControls.Table tableDateAngajator;
		protected System.Web.UI.WebControls.Table tableAdresa;
		protected System.Web.UI.WebControls.TextBox txtZiLichidareSalar;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.ListBox lstBoxDomenii;
		protected System.Web.UI.WebControls.ListBox lstBoxDomeniiAngajator;
		protected System.Web.UI.HtmlControls.HtmlSelect drpDomDeActPrincipal;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenDomDeActPpID;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenDomDeActListID;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTaraHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtJudetSectorHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTipCompletareHidden;
		protected System.Web.UI.WebControls.DropDownList lstTipCompletare;

		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.DropDownList drpBanci;
		protected System.Web.UI.WebControls.TextBox txtNumarContVechi;
		protected System.Web.UI.WebControls.TextBox txtNumarContIBAN;
		protected System.Web.UI.WebControls.DropDownList drpMoneda;
		protected System.Web.UI.WebControls.CheckBox chkActiv;
		protected System.Web.UI.WebControls.ListBox lstConturiBancare;
		protected System.Web.UI.HtmlControls.HtmlInputText txtListaConturiHidden;

		protected System.Web.UI.WebControls.TextBox txtNumePunctLucru;
		protected System.Web.UI.WebControls.ListBox lstPunctLucru;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenPunctLucru;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtDSector;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularEmail;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularTelefon;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularFax;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCUI;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNrInreg;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularAdresaWeb;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredConturi;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDCodPostal;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDBloc;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDScara;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDEtaj;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDApartament;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDomenii;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredPuncteLucru;
		protected System.Web.UI.WebControls.RangeValidator vldZiuaLichidarii;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDJudet;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularSector;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularLocalitate;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularStrada;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNumar;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNrInregItm;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredNrInregItm;
		protected System.Web.UI.WebControls.TextBox txtNrInregItm;
		protected System.Web.UI.WebControls.DropDownList drpCaseDeAsigurari;
		protected System.Web.UI.WebControls.DropDownList drpFunctiiReprez;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenReprez;
		protected System.Web.UI.WebControls.TextBox txtNumeReprez;
		protected System.Web.UI.WebControls.TextBox txtPrenumeReprez;
		protected System.Web.UI.WebControls.ListBox lstReprezLegali;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenNrFunctii;
		protected System.Web.UI.WebControls.CompareValidator compValFunctii;
		protected System.Web.UI.WebControls.TextBox txtCUI;
		protected System.Web.UI.WebControls.TextBox txtNrCrtSediuSecundar;

		public  int idAngajator;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				// Lista bancilor.
				Salaries.Business.AdminBanci banci = new Salaries.Business.AdminBanci();

				settings = Salaries.Configuration.ModuleConfig.GetSettings();
				litError.Text = "";
				string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";

				//sunt facute invizibile textbox-urile
				txtHiddenDomDeActPpID.Style.Add("display","none");
				txtHiddenDomDeActListID.Style.Add("display","none");
				//txtHiddenPunctLucru.Style.Add("display","none");
				
				Salaries.Business.AdminAngajator angajator = new Salaries.Business.AdminAngajator();
				Response.Write(script_text);
				Response.Write("<script>" + angajator.GetJSArrays() + "</script>");
			
				//client id-urile pentru listbox-uri, dropdown si textbox-uri
				Response.Write( "<script>var lstBoxDomeniiClient = '"+lstBoxDomenii.ClientID+"'</script>" );
				Response.Write( "<script>var lstBoxDomeniiAngajatorClient = '"+lstBoxDomeniiAngajator.ClientID+"'</script>" );
				Response.Write( "<script>var drpDomDeActPrincipalClient = '"+drpDomDeActPrincipal.ClientID+"'</script>" );
				Response.Write( "<script>var txtHiddenDomDeActPpIDClient = '"+txtHiddenDomDeActPpID.ClientID+"'</script>" );
				Response.Write( "<script>var txtHiddenDomDeActListIDClient = '"+txtHiddenDomDeActListID.ClientID+"'</script>" );
				Response.Write( "<script>var txtTaraHiddenClient = '"+txtTaraHidden.ClientID+"'</script>" );
				Response.Write( "<script>var txtJudetSectorHiddenClient='"+txtJudetSectorHidden.ClientID+"'</script>" );
				Response.Write( "<script>var txtTipCompletareHiddenClient='"+txtTipCompletareHidden.ClientID+"'</script>" );
				Response.Write( "<script>var lstDJudetSectorClient='"+lstDJudetSector.ClientID+"'</script>" );
				Response.Write( "<script>var txtSectorClient='"+txtDSector.ClientID+"'</script>" );

				// Controalele pentru datele aferente conturilor bancare.
				Response.Write( "<script>var drpBanciClientID = '" + drpBanci.ClientID + "';</script>" );
				Response.Write( "<script>var txtNumarContVechiClientID = '" + txtNumarContVechi.ClientID + "';</script>" );
				Response.Write( "<script>var txtNumarContIBANClientID = '" + txtNumarContIBAN.ClientID + "'; </script>" );
				Response.Write( "<script>var drpMonedaClientID = '" + drpMoneda.ClientID + "';</script>" );
				Response.Write( "<script>var chkActivClientID = '" + chkActiv.ClientID + "'; </script>" );
				Response.Write( "<script>var lstConturiBancareClientID = '" + lstConturiBancare.ClientID + "';</script>" );
				Response.Write( "<script>var txtListaConturiHiddenClientID = '" + txtListaConturiHidden.ClientID + "'</script>" );
				
				Response.Write( "<script>var txtNumePunctLucru = '" + txtNumePunctLucru.ClientID + "'</script>" );
				Response.Write( "<script>var lstPunctLucru = '" + lstPunctLucru.ClientID + "'</script>" );
				Response.Write( "<script>var txtHiddenPunctLucru = '"+txtHiddenPunctLucru.ClientID+"'</script>" );
				Response.Write( "<script>var drpCaseDeAsigClientID = '" + drpCaseDeAsigurari.ClientID + "';</script>" );
				Response.Write( "<script>var txtCUI = '" + txtCUI.ClientID + "'</script>" );
				Response.Write( "<script>var txtNrCrtSediuSecundar = '" + txtNrCrtSediuSecundar.ClientID + "'</script>" );
				
				//Lungu Andreea - 19.08.2008
				Response.Write( "<script>var txtNumeReprez = '" + txtNumeReprez.ClientID + "'</script>" );
				Response.Write( "<script>var txtPrenumeReprez = '" + txtPrenumeReprez.ClientID + "'</script>" );
				Response.Write( "<script>var drpFunctiiReprez = '" + drpFunctiiReprez.ClientID + "'</script>" );
				Response.Write( "<script>var lstReprezLegali = '" + lstReprezLegali.ClientID + "'</script>" );
				Response.Write( "<script>var txtHiddenReprez = '" + txtHiddenReprez.ClientID + "'</script>" );
				Response.Write( "<script>var txtHiddenNrFunctii = '" + txtHiddenNrFunctii.ClientID + "'</script>" );
				ScrieVariabileJavaScript();

				btnSterge.Attributes.Add("onclick", "return CheckDeleteAngajator('Doriti sa stergeti acest angajator?')");

				string[] textTabs = {"Date angajator", "Conturi angajator", "Adresa angajator", "Domenii de activitate", "Punct de lucru", "Reprezentanti legali"};
				Utilities.CreateHeaderWithTabsForAdminAngajator(tableTabs, textTabs, "../", true);
				UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);	
			
				if(!IsPostBack)
				{
					Salaries.Business.AdminAngajator myAdmin = new Salaries.Business.AdminAngajator();
					myAdmin.AngajatorId = GetAngajator();
					DataRow rowAngajator = myAdmin.LoadInfoAngajator().Tables[0].Rows[0];

					txtDenumire.Text = rowAngajator["Denumire"].ToString();
					lstTipPersoana.SelectedValue = rowAngajator["TipPersoana"].ToString() == "True" ? "1" : "0";
					txtCUI_CNP.Text = rowAngajator["CUI_CNP"].ToString();
					txtNrInreg.Text = rowAngajator["NrInregORC"].ToString();
					//Lungu Andreea 08.04.2008
					txtNrInregItm.Text = rowAngajator["NrInregITM"].ToString();
					txtTelefon.Text = rowAngajator["Telefon"].ToString();
					txtFax.Text = rowAngajator["Fax"].ToString();
					txtAdresaWeb.Text = rowAngajator["PaginaWeb"].ToString();
					txtEmail.Text = rowAngajator["Email"].ToString();
					lstDTara.SelectedValue = rowAngajator["TaraId"].ToString();
					lstDJudetSector.SelectedValue = rowAngajator["JudetSectorId"].ToString();
					lstTipCompletare.SelectedValue = rowAngajator["TipCompletareCarnetId"].ToString();
					txtDLocalitate.Text = rowAngajator["Localitate"].ToString();
					txtDStrada.Text = rowAngajator["Strada"].ToString();
					txtDNumar.Text = rowAngajator["Numar"].ToString();
					txtDCodPostal.Text = rowAngajator["CodPostal"].ToString();
					txtDBloc.Text = rowAngajator["Bloc"].ToString();
					txtDScara.Text = rowAngajator["Scara"].ToString();
					txtDEtaj.Text = rowAngajator["Etaj"].ToString();
					txtDApartament.Text = rowAngajator["Apartament"].ToString();
					txtDSector.Text = rowAngajator["Sector"].ToString();
					txtZiLichidareSalar.Text = rowAngajator["ZiLichidareSalar"].ToString();
				
					//tara
					Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
					lstDTara.DataSource =  tari.LoadInfoTariCuJudete();
					lstDTara.DataTextField = "NumeTara";
					lstDTara.DataValueField = "TaraID";
					lstDTara.DataBind();
					if( txtTaraHidden.Value != "" )
					{
						lstDTara.SelectedValue = txtTaraHidden.Value;
					}
				
					//judetul
					Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
					judete.TaraId = int.Parse(lstDTara.SelectedValue);
					lstDJudetSector.DataSource = judete.GetAllJudeteTara();
					lstDJudetSector.DataTextField = "NumeCompus";
					lstDJudetSector.DataValueField = "JudetID";
					lstDJudetSector.DataBind();
					if( txtJudetSectorHidden.Value != "" )
					{
						lstDJudetSector.SelectedValue = txtJudetSectorHidden.Value;
					}
					
					//tipuri completare carnete
					Salaries.Business.AdminTipuriCompletareCarnete tipuriCarnete = new Salaries.Business.AdminTipuriCompletareCarnete();
					tipuriCarnete.AngajatorId = GetAngajator();
					lstTipCompletare.DataSource = tipuriCarnete.GetTipuriCompletareCarnete();
					lstTipCompletare.DataTextField = "ModCompletare";
					lstTipCompletare.DataValueField = "CompletareCarneteValoriID";
					lstTipCompletare.DataBind();
					if ( txtTipCompletareHidden.Value != "")
					{
						lstTipCompletare.SelectedValue = txtTipCompletareHidden.Value;
					}

					// Listare banci.
					drpBanci.DataSource = banci.GetBanci();
					drpBanci.DataTextField = "NumeBanca";
					drpBanci.DataValueField = "BancaID";
					drpBanci.DataBind();

					//Lungu Andreea 23.05.2008
					//este populat dropdownlist-u ce contine casele de asigurari
					DataSet dsCaseDeAsig = new DataSet(); 
					angajator.AngajatorId = this.GetAngajator();
            
					//Lista caselor de asigurari ale unui angajator.
					dsCaseDeAsig = angajator.GetCaseDeAsigurari();
					drpCaseDeAsigurari.DataSource = dsCaseDeAsig;
					drpCaseDeAsigurari.DataTextField = "DenumireCod";
					drpCaseDeAsigurari.DataValueField = "CasaDeAsigurariID";
					drpCaseDeAsigurari.DataBind();
					
					//Lungu Andreea 19.08.2008
					//este populat dropdownlist-ul ce contine functiile reprzentantilor legali
					DataSet dsFunctiiReprez = new DataSet(); 
					angajator.AngajatorId = this.GetAngajator();
            
					//Lista functiilor reprezentantilor legali ale unui angajator.
					dsFunctiiReprez = angajator.GetFunctiiReprez();
					drpFunctiiReprez.DataSource = dsFunctiiReprez;
					drpFunctiiReprez.DataTextField = "NumeFunctie";
					drpFunctiiReprez.DataValueField = "FunctieReprezID";
					drpFunctiiReprez.DataBind();	
					txtHiddenNrFunctii.Value = drpFunctiiReprez.Items.Count.ToString();
					
					string sirTari = GetSirTari();
					string sirJudeteText = GetSirJudeteText();
					string sirJudeteValue = GetSirJudeteValue();
					Response.Write( "<script>var tari = "+sirTari+";</script>");
					Response.Write( "<script>var judeteText = "+sirJudeteText+";</script>" );
					Response.Write( "<script>var judeteValue = "+sirJudeteValue+";</script>" );
					
					//listare domenii de activitate disponibile
					ListareDomDeActAngajator();
					//listare domenii de activitate ale angajatorului
					ListareDomeniiDeActivitate();
					//adaugare domenii de activitate in dropdownlist si adaugare in textbox-ul ascuns id-ul 
					//domeniului de activitate principal
					FillDrpDomDeActPrincipal();
					
					//Listarea conturilor bancare.
					ListareConturiBancareAngajator();

					//listare punct de lucru
					ListarePunctLucru();

					//listare reprezentanti legali
					ListareReprezLegali();

				}
				txtTaraHidden.Value = txtTaraHidden.Value == "" ? lstDTara.SelectedValue : txtTaraHidden.Value;		
				txtJudetSectorHidden.Value = txtJudetSectorHidden.Value == "" ? lstDJudetSector.SelectedValue : txtJudetSectorHidden.Value;
				txtTipCompletareHidden.Value = txtTipCompletareHidden.Value == "" ? lstTipCompletare.SelectedValue : txtJudetSectorHidden.Value;
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region ScrieVariabileJavaScript
		/// <summary>
		/// Scrie variabilele pe JavaScript
		/// </summary>
		public void ScrieVariabileJavaScript()
		{
			//Oprescu Claudia
			//Sunt scrisi validatorii
			Response.Write("<script>var requiredDenumire = \"" + requiredDenumire.ClientID + "\"</script>");
			Response.Write("<script>var requiredFiliala = \"" + requiredFiliala.ClientID + "\"</script>");
			Response.Write("<script>var requiredNrInreg = \"" + requiredNrInreg.ClientID + "\"</script>");
			Response.Write("<script>var requiredTelefon = \"" + requiredTelefon.ClientID + "\"</script>");
			Response.Write("<script>var regularTelefon = \"" + regularTelefon.ClientID + "\"</script>");
			Response.Write("<script>var regularFax = \"" + regularFax.ClientID + "\"</script>");
			Response.Write("<script>var regularEmail = \"" + regularEmail.ClientID + "\"</script>");
			Response.Write("<script>var vldZiuaLichidarii = \"" + vldZiuaLichidarii.ClientID + "\"</script>");
			Response.Write("<script>var requiredConturi = \"" + requiredConturi.ClientID + "\"</script>");
			Response.Write("<script>var requiredDJudet = \"" + requiredDJudet.ClientID + "\"</script>");
			Response.Write("<script>var requiredDLocalitate = \"" + requiredDLocalitate.ClientID + "\"</script>");
			Response.Write("<script>var requiredDStrada = \"" + requiredDStrada.ClientID + "\"</script>");
			Response.Write("<script>var requiredDNumar = \"" + requiredDNumar.ClientID + "\"</script>");
			Response.Write("<script>var requiredDCodPostal = \"" + requiredDCodPostal.ClientID + "\"</script>");
			Response.Write("<script>var regularDenumire = \"" + regularDenumire.ClientID + "\"</script>");
			Response.Write("<script>var regularCUI = \"" + regularCUI.ClientID + "\"</script>");
			Response.Write("<script>var regularNrInreg = \"" + regularNrInreg.ClientID + "\"</script>");
			Response.Write("<script>var regularAdresaWeb = \"" + regularAdresaWeb.ClientID + "\"</script>");
			Response.Write("<script>var regularSector = \"" + regularSector.ClientID + "\"</script>");
			Response.Write("<script>var regularLocalitate = \"" + regularLocalitate.ClientID + "\"</script>");
			Response.Write("<script>var regularStrada = \"" + regularStrada.ClientID + "\"</script>");
			Response.Write("<script>var regularNumar = \"" + regularNumar.ClientID + "\"</script>");
			Response.Write("<script>var regularDCodPostal = \"" + regularDCodPostal.ClientID + "\"</script>");
			Response.Write("<script>var regularDBloc = \"" + regularDBloc.ClientID + "\"</script>");
			Response.Write("<script>var regularDScara = \"" + regularDScara.ClientID + "\"</script>");
			Response.Write("<script>var regularDEtaj = \"" + regularDEtaj.ClientID + "\"</script>");
			Response.Write("<script>var regularDApartament = \"" + regularDApartament.ClientID + "\"</script>");
			Response.Write("<script>var requiredDomenii = \"" + requiredDomenii.ClientID + "\"</script>");
			Response.Write("<script>var requiredPuncteLucru = \"" + requiredPuncteLucru.ClientID + "\"</script>");
			//Lungu Andreea 08.04.2008
			Response.Write("<script>var requiredNrInregItm = \"" + requiredNrInregItm.ClientID + "\"</script>");
			Response.Write("<script>var regularNrInregItm = \"" + regularNrInregItm.ClientID + "\"</script>");		
		}
		#endregion

		#region ListareConturiBancareAngajator
		/// <summary>
		/// Sunt adaugate in control toate conturile bancare ale angajatorului editat si
		/// este completat si controlul ascuns ce contine lista conturilor bancare. 
		/// </summary>
		private void ListareConturiBancareAngajator()
		{
			Salaries.Business.ConturiAngajator contAngajator = new Salaries.Business.ConturiAngajator();
			// Conturile bancare ale angajatorului.
			DataSet dsConturiBancare = new DataSet();
            // Este construit stringul care va fi pus in TextBox-ul ascuns ce contine lista 
			// conturilor bancare ale angajatorului. Datele despre conturi sunt despartite
			// prin punct si virgula, iar datele despre un cont prin virgula. Ordinea datelor despre 
			// un cont bancar este urmatoarea: id banca, numar cont in format vechi, numar cont
			// in format IBAN, moneda, activ
			string conturiAngajator = string.Empty;
			// Numarul contului.
			int i = 0;
			// Textul aferent unui cont bancar si afisat in ListBox.
			string contBancarText = string.Empty;
			
			// ID-ul angajatorului.
			contAngajator.AngajatorId = idAngajator;
			
			// Sunt obtinute conturile bancare ale angajatorului editat.
			dsConturiBancare = contAngajator.GetConturiBancareAngajator();
			
			foreach( DataRow drCont in dsConturiBancare.Tables[0].Rows)
			{

				if (conturiAngajator == string.Empty)
				{
					conturiAngajator = drCont["BancaID"].ToString() + "," + 
						drCont["NumarContVechi"].ToString() + "," + 
						drCont["NumarContIBAN"].ToString() + "," + 
						drCont["Moneda"].ToString();

					if ( bool.Parse(drCont["Activ"].ToString()) )
					{
						conturiAngajator += "," + "true";
					}
					else
					{
						conturiAngajator += "," + "false";
					}
				}
				else
				{
					conturiAngajator += ";" + drCont["BancaID"].ToString() + "," + 
						drCont["NumarContVechi"].ToString() + "," + 
						drCont["NumarContIBAN"].ToString() + "," + 
						drCont["Moneda"].ToString() ;

					if ( bool.Parse(drCont["Activ"].ToString()) )
					{
						conturiAngajator += "," + "true";
					}
					else
					{
						conturiAngajator += "," + "false";
					}
				}
				
				contBancarText = drCont["CodBanca"].ToString() + "-" + drCont["Nume"].ToString() +
					", " + drCont["NumarContVechi"].ToString() + ", " + drCont["NumarContIBAN"].ToString() +
					", " + drCont["Moneda"].ToString();
				
				if ( bool.Parse(drCont["Activ"].ToString()) )
				{
					contBancarText += ", " + "DA";
				}
				else
				{
					contBancarText += ", " + "NU";
				}

				ListItem contBancarItem = new ListItem(contBancarText, i.ToString());
				// Este adaugat contul bancar in lista.
				lstConturiBancare.Items.Add(contBancarItem);

				// Este completata valoarea controlului ascuns care contine toate datele despre
				// conturile bancare ale angajatorului.
				txtListaConturiHidden.Value = conturiAngajator;

				i++;
			}
        }
		#endregion

		#region ListareDomeniiDeActivitate
		/// <summary>
		/// Listarea tuturor domeniilor de activitate
		/// </summary>
		/// <remarks>
		/// Cristina Muntean
		/// </remarks>
		public void ListareDomeniiDeActivitate()
		{
			try
			{
				//dataSet-ul contine lista tuturor domeniilor de activitate disponibile pentru angajatorul trimis ca parametru
				//DataSet dsDomDeAct = objAdminDomDeAct.getDataSet;
				Salaries.Business.AdminDomeniiDeActivitate domenii = new Salaries.Business.AdminDomeniiDeActivitate();
				DataSet dsDomDeAct = domenii.GetDomeniiDeActDisponibilePtAngajator(idAngajator);
				
				//pentru fiecare rand al dataset-ului este adaugat un item in listbox
				foreach(DataRow row in dsDomDeAct.Tables[0].Rows)
				{
					//textul item-ului este alcatuit din codul CAEN al domeniului, denumirea si descrierea acestuia
					string textDomeniu;
					if(row["Descriere"].ToString()!="")
						textDomeniu=row["CodCAEN"].ToString()+","+row["Denumire"].ToString()+","+row["Descriere"].ToString();
					else
						textDomeniu=row["CodCAEN"].ToString()+","+row["Denumire"].ToString()+", - ";
					//valoarea este id-ul domeniului
					string valueDomeniuID=row["DomDeActivitateID"].ToString();
					ListItem item=new ListItem(textDomeniu,valueDomeniuID);
					//este adaugat item-ul in listbox
					lstBoxDomenii.Items.Add(item);
				}
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region ListareDomDeActAngajator
		/// <summary>
		/// Listarea tuturor domeniilor de activitatea ale angajtorului
		/// </summary>
		public void ListareDomDeActAngajator()
		{
			try
			{
				Salaries.Business.AdminDomeniiDeActivitateAngajator objAdminDomDeActAng = new Salaries.Business.AdminDomeniiDeActivitateAngajator();
				objAdminDomDeActAng.AngajatorId = idAngajator;
				//dataSet-ul contine lista tuturor domeniilor de activitate ale unui angajator
				DataSet dsDomDeActAng = objAdminDomDeActAng.LoadInfoDomeniiDeActivitateAngajator();
				//foreach(DataRow row in dsDomDeActAng.Tables[0].Rows)
				for(int i=0;i<dsDomDeActAng.Tables[0].Rows.Count;i++)
				{
					DataRow row = dsDomDeActAng.Tables[0].Rows[i];
					//sunt obtinute toate datele despre domeniul de activitate cu ID-ul row["DomDeActivitateID"] 
					Salaries.Business.AdminDomeniiDeActivitate domenii = new Salaries.Business.AdminDomeniiDeActivitate();
					domenii.DomeniuDeActivitateId = int.Parse(row["DomDeActivitateID"].ToString());
					DataRow rowDomeniu = domenii.GetDomeniuDeActivitateInfo().Tables[0].Rows[0];
										
					//textul item-ului este alcatuit din codul CAEN al domeniului, denumirea si descrierea acestuia
					string textDomeniu = rowDomeniu["CodCAEN"].ToString() + "," + rowDomeniu["Denumire"].ToString() + "," + rowDomeniu["Descriere"].ToString();
					//valoarea este id-ul domeniului
					string valueDomeniuID = rowDomeniu["DomDeActivitateId"].ToString();
					ListItem item=new ListItem(textDomeniu,valueDomeniuID);
					lstBoxDomeniiAngajator.Items.Add(item);
					//scrie in textbox-ul ascuns id-urile domeniilor de activitate ale angajatorilor
					if(i!=dsDomDeActAng.Tables[0].Rows.Count-1)
						txtHiddenDomDeActListID.Value+=valueDomeniuID+",";
					else
						txtHiddenDomDeActListID.Value+=valueDomeniuID;
				}
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region FillDrpDomDeActPrincipal
		/// <summary>
		/// Incarca in dropdownlist domeniile de activitate ale angajatorului, iar cel selectat este cel principal
		/// </summary>
		/// <remarks>
		/// Cristina Muntean
		/// </remarks>
		public void FillDrpDomDeActPrincipal()
		{
			//indexul domeniului de activitate principal 
			int indexItemPrincipal=0;

			Salaries.Business.AdminDomeniiDeActivitateAngajator objAdminDomDeActAng = new Salaries.Business.AdminDomeniiDeActivitateAngajator();
			objAdminDomDeActAng.AngajatorId = idAngajator;
			//dataSet-ul contine lista tuturor domeniilor de activitate ale unui angajator
			DataSet dsDomDeActAng = objAdminDomDeActAng.LoadInfoDomeniiDeActivitateAngajator();
			//foreach(DataRow row in dsDomDeActAng.Tables[0].Rows)
			for(int i=0;i<dsDomDeActAng.Tables[0].Rows.Count;i++)
			{
				DataRow row = dsDomDeActAng.Tables[0].Rows[i];
				//sunt obtinute toate datele despre domeniul de activitate cu ID-ul row["DomDeActivitateID"] 
				Salaries.Business.AdminDomeniiDeActivitate domenii = new Salaries.Business.AdminDomeniiDeActivitate();
				domenii.DomeniuDeActivitateId = int.Parse(row["DomDeActivitateID"].ToString());
				DataRow rowDomeniu = domenii.GetDomeniuDeActivitateInfo().Tables[0].Rows[0];
										
				//textul item-ului este alcatuit din codul CAEN al domeniului, denumirea si descrierea acestuia
				string textDomeniu = rowDomeniu["CodCAEN"].ToString() + "," + rowDomeniu["Denumire"].ToString() + "," + rowDomeniu["Descriere"].ToString();
				//valoarea este id-ul domeniului
				string valueDomeniuID = domenii.DomeniuDeActivitateId.ToString();
				ListItem item=new ListItem(textDomeniu,valueDomeniuID);
				drpDomDeActPrincipal.Items.Add(item);
				//daca domeniul de activitate e cel principal atunci e adaugat si in textbox-ul acuns
				//si este retinut indexul acestuia
				if(bool.Parse(row["Principal"].ToString()))
				{
					txtHiddenDomDeActPpID.Value = row["DomDeActivitateID"].ToString();
					indexItemPrincipal=i;
				}
			}
			drpDomDeActPrincipal.SelectedIndex=indexItemPrincipal;
		}
		#endregion

		#region ListarePunctLucru
		/// <summary>
		/// Incarca lista de puncte de lucru cu valorile corespunzatoare unui anumit angajator
		/// </summary>
		/// <remarks>
		/// Oprescu Claudia 
		/// </remarks>
		public void ListarePunctLucru()
		{
			//Lungu Andreea 23.05.2008
			//listarea punctelor de lucru sa contina casele de asigurari implicite
			//pastrez id casei de asig in textbox-ul hidden
			try
			{
				Salaries.Business.AdminPunctLucru objAdminPunctLucru = new Salaries.Business.AdminPunctLucru();
				objAdminPunctLucru.AngajatorId = idAngajator;
				DataSet dsPunctLucru = objAdminPunctLucru.LoadInfoPunctLucruAngajator();
				for(int i=0;i<dsPunctLucru.Tables[0].Rows.Count;i++)
				{
					DataRow row = dsPunctLucru.Tables[0].Rows[i];
					
					ListItem item=new ListItem(row["Nume"].ToString().Trim() + "," + row["DenumireCod"].ToString().Trim() + "," + row["CUI"].ToString().Trim() + "," + row["NrCrtSediuSecundar"].ToString().Trim(),row["PunctLucruID"].ToString());
					lstPunctLucru.Items.Add(item);
					
					objAdminPunctLucru.PunctLucruId = int.Parse(row["PunctLucruID"].ToString());
					//valorile "da" si "nu" care se adauga semnifica faptul ca acel punct de lucru nu poate fi sters pentru ce sunt inregistrari pentru el
					if (objAdminPunctLucru.CheckIfPunctLucruCanBeDeleted())
						if(i!=dsPunctLucru.Tables[0].Rows.Count-1)
							txtHiddenPunctLucru.Value += row["PunctLucruID"].ToString()+ "," + row["CasaDeAsigurariId"].ToString()+ "," + row["Nume"].ToString().TrimEnd()+ "," + row["DenumireCod"].ToString().TrimEnd() + "," + row["CUI"].ToString().TrimEnd() + "," + row["NrCrtSediuSecundar"].ToString().TrimEnd() + ",da;";
						else
							txtHiddenPunctLucru.Value += row["PunctLucruID"].ToString()+ "," + row["CasaDeAsigurariId"].ToString()+ "," + row["Nume"].ToString().TrimEnd() + "," + row["DenumireCod"].ToString().TrimEnd() + "," + row["CUI"].ToString().TrimEnd() + "," + row["NrCrtSediuSecundar"].ToString().TrimEnd() + ",da";
					else
						if(i!=dsPunctLucru.Tables[0].Rows.Count-1)
							txtHiddenPunctLucru.Value += row["PunctLucruID"].ToString()+ "," + row["CasaDeAsigurariId"].ToString()+ "," + row["Nume"].ToString().TrimEnd()+ "," + row["DenumireCod"].ToString().TrimEnd() + "," + row["CUI"].ToString().TrimEnd() + "," + row["NrCrtSediuSecundar"].ToString().TrimEnd() + ",nu;";
						else
							txtHiddenPunctLucru.Value += row["PunctLucruID"].ToString()+ "," + row["CasaDeAsigurariId"].ToString()+ "," + row["Nume"].ToString().TrimEnd()+ "," + row["DenumireCod"].ToString().TrimEnd() + "," + row["CUI"].ToString().TrimEnd() + "," + row["NrCrtSediuSecundar"].ToString().TrimEnd() + ",nu";
				}
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}

		#endregion

		#region ListareReprezLegali
		/// <summary>
		/// Incarca lista de reprezentanti legali a unui angajator
		/// </summary>
		/// <remarks>
		/// Lungu Andreea - 20.08.2008 
		/// </remarks>
		public void ListareReprezLegali()
		{
			try
			{
				Salaries.Business.AdminAngajator objAdminAngajator = new Salaries.Business.AdminAngajator();
				objAdminAngajator.AngajatorId = idAngajator;
				DataSet dsReprezLegali = objAdminAngajator.GetReprezLegali();
				for(int i=0;i<dsReprezLegali.Tables[0].Rows.Count;i++)
				{
					DataRow row = dsReprezLegali.Tables[0].Rows[i];
					
					ListItem item=new ListItem(row["NumeReprez"].ToString() + "," + row["PrenumeReprez"].ToString() + "," + row["NumeFunctie"].ToString() ,row["FunctieReprezID"].ToString());
					lstReprezLegali.Items.Add(item);
					
					if(i!=dsReprezLegali.Tables[0].Rows.Count-1)
						txtHiddenReprez.Value+=row["FunctieReprezID"].ToString()+ "," + row["NumeReprez"].ToString()+ "," + row["PrenumeReprez"].ToString().TrimEnd()+ "," + row["NumeFunctie"].ToString().TrimEnd() + ";";
					else
						txtHiddenReprez.Value+=row["FunctieReprezID"].ToString()+ "," + row["NumeReprez"].ToString()+ "," + row["PrenumeReprez"].ToString().TrimEnd()+ "," + row["NumeFunctie"].ToString().TrimEnd();
				}
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}

		#endregion

		#region GetSirTari(),GetSirJudeteText(),GetSirJudeteValue(),BindLstDJudetDDL()	
		/// <summary>
		/// Tarile.
		/// </summary>
		/// <returns> Returneaza tarile.</returns>
		private string GetSirTari()
		{
			string sirTari = "";
			string sirTariText = "[";
			string sirTariValue = "[";

			DataSet ds = (DataSet)lstDTara.DataSource;
			for( int i=0; i<ds.Tables[ 0 ].Rows.Count-1; i++ )
			{
				DataRow dr = ds.Tables[ 0 ].Rows[ i ];
				sirTariText += "'"+dr[ "NumeTara" ].ToString()+"', ";
				sirTariValue += dr[ "TaraID" ].ToString()+", ";
			}
			if( ds.Tables[ 0 ].Rows.Count > 0 )
			{
				sirTariText += "'"+ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "NumeTara" ].ToString()+"']";
				sirTariValue += ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "TaraID" ].ToString()+"]";
			
				sirTari = "["+sirTariText+","+sirTariValue+"]";
			}
			else
			{
				sirTari = "[[],[]]";
			}

			return sirTari;
		}

		/// <summary>
		/// Numele judetelor din fiecare tara.
		/// </summary>
		/// <returns> Returneaza numele judetelor din fiecare tara.</returns>
		private string GetSirJudeteText()
		{
			string sirJudText = "";
			string sirJudTextFinal = "";
			Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
		
			DataSet dsTari = (DataSet)lstDTara.DataSource;
			foreach( DataRow drTari in dsTari.Tables[ 0 ].Rows )
			{
				judete.TaraId = int.Parse(drTari[ "TaraID" ].ToString());
				DataSet ds = judete.GetAllJudeteTara();
				if( ds.Tables[ 0 ].Rows. Count > 0 )
				{
					sirJudText = "[";

					for( int i=0; i<ds.Tables[ 0 ].Rows.Count-1; i++ )
					{
						DataRow dr = ds.Tables[ 0 ].Rows[ i ];
						sirJudText += "'"+dr[ "NumeCompus" ].ToString()+"', ";
					}
					sirJudText += "'"+ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "NumeCompus" ].ToString()+"']";
				}
				else
				{
					sirJudText = "[]";
				}
				sirJudTextFinal += sirJudText+", ";
			}
			if( sirJudTextFinal == "" )
			{
				sirJudTextFinal += "[[]]";
			}
			else
			{
				sirJudTextFinal = sirJudTextFinal.Substring( 0, sirJudTextFinal.Length-2 );
				sirJudTextFinal = "["+sirJudTextFinal+"]";
			}

			return sirJudTextFinal;
		}
		
		/// <summary>
		/// ID-urile judetelor din fiecare tara.
		/// </summary>
		/// <returns> Returneaza id-urile judetelor din fiecare tara.</returns>
		private string GetSirJudeteValue()
		{
			string sirJudVal = "";
			string sirJudValFinal = "";
			Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
			
			DataSet dsTari = (DataSet)lstDTara.DataSource;
			foreach( DataRow drTari in dsTari.Tables[ 0 ].Rows )
			{
				judete.TaraId = int.Parse(drTari[ "TaraID" ].ToString());
				DataSet ds = judete.GetAllJudeteTara();
				if( ds.Tables[ 0 ].Rows.Count > 0 )
				{
					sirJudVal = "[";

					for( int i=0; i<ds.Tables[ 0 ].Rows.Count-1; i++ )
					{
						DataRow dr = ds.Tables[ 0 ].Rows[ i ];
						sirJudVal += dr[ "JudetID" ].ToString()+", ";
					}
					sirJudVal += ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "JudetID" ].ToString()+"]";
				}
				else
				{
					sirJudVal = "[]";
				}
			
				sirJudValFinal += sirJudVal+", ";
			}
			if( sirJudValFinal == "" )
			{
				sirJudValFinal += "[[]]";
			}
			else
			{
				sirJudValFinal = sirJudValFinal.Substring( 0, sirJudValFinal.Length-2 );
				sirJudValFinal = "["+sirJudValFinal+"]";
			}

			return sirJudValFinal;
		}

		/// <summary>
		/// Face legatura intre dropdownlis-ul cu judete si judetele din tara cu id-ul lstDTara.SelectedValue din baza de date
		/// </summary>
		private void BindLstDJudetDDL()
		{
			Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
			judete.TaraId = int.Parse(lstDTara.SelectedValue);
			lstDJudetSector.DataSource = judete.GetAllJudeteTara();
			lstDJudetSector.DataTextField = "NumeCompus";
			lstDJudetSector.DataValueField = "JudetID";
			lstDJudetSector.DataBind();
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
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
			this.btnInapoi.Click += new System.EventHandler(this.btnInapoi_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		#region btnInapoi_Click
		/// <summary>
		/// Procedura revine la lista cu angajatori
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnInapoi_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("Administrare.aspx?cmd=admin_angajatori");
		}
		#endregion
		
		#region btnSave_Click
		/// <summary>
		/// Sunt salvate modificarile facute asupra datelor angakatorului.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks> Modificari:
		/// Autor:    Cristina Raluca Muntean
		/// Adaugarea datelor despre domeniile de activitate.
		/// Adaugarea datelor despre conturile bancare.
		/// </remarks>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			// Lista conturilor bancare ale angajatorului.
			string conturiBancare;
			string[] listaConturiBancare;
			Salaries.Business.ConturiAngajator contAngajator = new Salaries.Business.ConturiAngajator();

			try
			{
				lstDTara.SelectedValue = txtTaraHidden.Value;
				BindLstDJudetDDL();				
				lstDJudetSector.SelectedValue = txtJudetSectorHidden.Value; 

				int angajatorId = Convert.ToInt32(Request.Form["txtAngajatorID"]);
				Salaries.Business.AdminAngajator myAdmin = new Salaries.Business.AdminAngajator();
				myAdmin.AngajatorId = angajatorId;
				myAdmin.Denumire  = txtDenumire.Text;
				myAdmin.TipPersoana = Convert.ToInt32(lstTipPersoana.SelectedValue);
				myAdmin.CUI_CNP = txtCUI_CNP.Text;
				myAdmin.NrInregORC = txtNrInreg.Text;
				myAdmin.NrInregITM = txtNrInregItm.Text; //Lungu Andreea 08.04.2009
				myAdmin.Telefon = txtTelefon.Text;
				myAdmin.Fax = txtFax.Text;
				myAdmin.PaginaWeb = txtAdresaWeb.Text;
				myAdmin.Email = txtEmail.Text;
				myAdmin.TaraId = Convert.ToInt32(lstDTara.SelectedValue);
				myAdmin.JudetSectorId = Convert.ToInt32(lstDJudetSector.SelectedValue);
				myAdmin.TipCompletareId = Convert.ToInt32(lstTipCompletare.SelectedValue);
				myAdmin.Localitate = txtDLocalitate.Text;
				myAdmin.Strada = txtDStrada.Text;
				myAdmin.Numar = txtDNumar.Text;
				myAdmin.CodPostal = txtDCodPostal.Text;
				myAdmin.Bloc = txtDBloc.Text;
				myAdmin.Scara = txtDScara.Text;
				myAdmin.Etaj = txtDEtaj.Text;
				myAdmin.Apartament = txtDApartament.Text;
				myAdmin.Sector = txtDSector.Text;
				myAdmin.ZiLichidareSalar = txtZiLichidareSalar.Text;
                
				if (myAdmin.CheckIfAngajatorCanBeAdded())
				{
					myAdmin.UpdateAngajator();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un angajator cu aceste date!'); </script>");
					return;
				}

				//Cristina Muntean
				//sterge toate domeniile de activitate ale angajatorului
				Salaries.Business.AdminDomeniiDeActivitateAngajator domeniiAngajator = new Salaries.Business.AdminDomeniiDeActivitateAngajator();
				domeniiAngajator.AngajatorId = idAngajator;
				domeniiAngajator.DeleteAllDomeniiDeActivitateAngajator();
				
				//Cristina Muntean
				string domeniiAngajatorIDList=txtHiddenDomDeActListID.Value.ToString();
				if(domeniiAngajatorIDList!="")
				{
					char[] sep = {','};//se stabileste separatorul
					//se afla partea intreaga a sumei
					Array aList = domeniiAngajatorIDList.Split(sep);//se face impartirea in functie de separator

					//sterge toate domeniile de activitate ale angajatorului
					domeniiAngajator.DeleteAllDomeniiDeActivitateAngajator();
								
					//adauga domeniile de activitate din listbox-ul cu domeniile de activitate ale angajatorului
					//foreach(ListItem item in lstBoxDomeniiAngajator.Items)
					for(int i=0;i<aList.Length;i++)
					{
						Salaries.Business.AdminDomeniiDeActivitateAngajator newDomDeActivitateAngajator = new Salaries.Business.AdminDomeniiDeActivitateAngajator();
						//id-ul inregistrarii care urmeaza a fi adaugata
						//primeste o valoare numai pentru a trimite un obiect complet
						//la inserare inregistrarea va primi un id unuic
						newDomDeActivitateAngajator.DomeniuAngajatorId = 0;
						//id-ul angajatorului
						//newDomDeActivitateAngajator.AngajatorID=this.GetAngajator();
						newDomDeActivitateAngajator.AngajatorId = angajatorId;
						//id-ul domeniului de activitate
						newDomDeActivitateAngajator.DomeniuDeActivitateId = int.Parse(aList.GetValue(i).ToString());

						//daca e domeniu principal sau nu
						if(txtHiddenDomDeActPpID.Value.ToString()==aList.GetValue(i).ToString())
							newDomDeActivitateAngajator.Principal=true;
						else
							newDomDeActivitateAngajator.Principal=false;
						//este inserat in baza de date domeniul de activitate pentru angajatorul cu id-ul AngajatorID
						newDomDeActivitateAngajator.InsertDomeniuDeActivitateAngajator();
					}
				}

				conturiBancare= txtListaConturiHidden.Value.ToString();
				// ID-ul angajatorului.
				contAngajator.AngajatorId = angajatorId;
				contAngajator.DeleteConturiAngajator();

				if (conturiBancare != "")
				{
					// Se face impartirea in functie de separator.
					// Conturile bancare ale angajatorului sunt separate prin punct si virgula.
					listaConturiBancare = conturiBancare.Split(';');
					Array  dateContBancar;

					// Sunt adaugate conturile bancare ale angajatorului.
					for (int i=0; i<listaConturiBancare.Length; i++)
					{ 
						// Datele despre un cont bancar sunt separate prin virgula.
						dateContBancar = listaConturiBancare.GetValue(i).ToString().Split(',');
						
						// Datele contului bancar.
						contAngajator.BancaId = int.Parse(dateContBancar.GetValue(0).ToString());
						contAngajator.NumarContVechi = dateContBancar.GetValue(1).ToString();
						contAngajator.NumarContIBAN = dateContBancar.GetValue(2).ToString();
						contAngajator.Moneda = dateContBancar.GetValue(3).ToString();
						contAngajator.Activ = bool.Parse(dateContBancar.GetValue(4).ToString());
						
						// Este facuta inserarea in baza de date.
						contAngajator.Insert();
					}
				}

				//Oprescu Claudia
				//se sterg toate punctele de lucru ale unui angajtor si se adauga valorile noi introduse
				//Lungu Andreea 26.05.2008 - s-au facut modificari deoarece pentru un anumit punct de lucru s-a adaugat  o casa de asigurari implicita
				string lstPunctLucru = txtHiddenPunctLucru.Value.ToString();
				if(lstPunctLucru!="")
				{
					char[] sep = {';'};
					Array sirPunctLucru = lstPunctLucru.Split(';');
					Salaries.Business.AdminPunctLucru objAdminPunctLucru = new Salaries.Business.AdminPunctLucru();
					objAdminPunctLucru.AngajatorId = angajatorId;
					DataSet ds = objAdminPunctLucru.LoadInfoPunctLucruAngajator();
					for(int i=0;i<ds.Tables[0].Rows.Count;i++)
					{		
						objAdminPunctLucru.PunctLucruId = int.Parse(ds.Tables[0].Rows[i]["PunctLucruID"].ToString());
						//daca un punct de lucru pote fi sters atunci se sterge
						if (objAdminPunctLucru.CheckIfPunctLucruCanBeDeleted())
						{
							objAdminPunctLucru.DeletePunctLucru();
						}
					}
					for(int i=0;i<sirPunctLucru.Length;i++)
					{
						//sunt adaugate numai acele Puncte 
						Array PunctLucru = sirPunctLucru.GetValue(i).ToString().Split(',');	
						Salaries.Business.AdminPunctLucru newAdminPunctLucru = new Salaries.Business.AdminPunctLucru();
						newAdminPunctLucru.AngajatorId = angajatorId;
						newAdminPunctLucru.Nume = PunctLucru.GetValue(2).ToString();
						newAdminPunctLucru.IdCasaDeAsigImplicita = Int32.Parse(PunctLucru.GetValue(1).ToString());
						newAdminPunctLucru.Cui = PunctLucru.GetValue(4).ToString();
						newAdminPunctLucru.NrCrtSediuSecundar = PunctLucru.GetValue(5).ToString();
					
						if (PunctLucru.GetValue(6).ToString().Equals("da"))
						{
							newAdminPunctLucru.PunctLucruId = 0;
							newAdminPunctLucru.InsertPunctLucru();
						}
						else
						{
							newAdminPunctLucru.PunctLucruId = Int32.Parse(PunctLucru.GetValue(0).ToString());
							newAdminPunctLucru.UpdatePunctLucru();
						}
					}
				}

				//Lungu Andreea - 20.08.2008
				//se modifica reprezentantii legali ai angajatorului
				string lstReprez = txtHiddenReprez.Value.ToString();
				if(lstReprez!="")
				{
					char[] sep = {';'};
					Array sirReprez = lstReprez.Split(';');
					
					for(int i=0;i<sirReprez.Length;i++)
					{
						//sunt adaugate numai acele Puncte 
						Array reprez = sirReprez.GetValue(i).ToString().Split(',');						
						
						Salaries.Business.AdminAngajator newAdminAngajator = new Salaries.Business.AdminAngajator();
						newAdminAngajator.AngajatorId = angajatorId;
						newAdminAngajator.SetReprezLegal(Int32.Parse(reprez.GetValue(0).ToString()), reprez.GetValue(1).ToString(), reprez.GetValue(2).ToString());
					}
				}

				Response.Redirect("Administrare.aspx?cmd=admin_angajatori");
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnSterge_Click
		/// <summary>
		/// Sunt sterse datele legate de un angjator.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks> Modificari:
		/// Autor:     Cristina Raluca Muntean
		/// Data:      9.03.2006
		/// Descriere: Inainte de stergerea angajatorului se sterg domeniile de
		/// activitate ale acestuia si conturile sale bancare.</remarks>
		private void btnSterge_Click(object sender, System.EventArgs e)
		{
			Salaries.Business.ConturiAngajator contAngajator = new Salaries.Business.ConturiAngajator();

			try
			{
				//sterge toate domeniile de activitate ale angajatorului
				Salaries.Business.AdminDomeniiDeActivitateAngajator domeniiAngajator = new Salaries.Business.AdminDomeniiDeActivitateAngajator();
				domeniiAngajator.DeleteAllDomeniiDeActivitateAngajator();

				// Sterge toate conturile bancare ale unui angajator.
				contAngajator.AngajatorId = idAngajator;
				contAngajator.DeleteConturiAngajator();

				Salaries.Business.AdminAngajator myAdmin = new Salaries.Business.AdminAngajator();
				myAdmin.AngajatorId = idAngajator;
			    myAdmin.DeleteAngajator();
								
				Response.Redirect("Administrare.aspx?cmd=admin_angajatori");
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
