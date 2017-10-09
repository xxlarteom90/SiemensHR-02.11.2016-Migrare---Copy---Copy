/*
 * Autor:     Cristina Raluca Muntean
 * Data:      6.03.2006
 * Descriere: Adaugarea partii de administrare a conturilor bancare.
 *			  Adaugarea TextBox-ului aferent zilei lichidarii drepturilor salariale.
 *			  Adaugarea listei cu tipurile de completare ale carnetelor de munca. 
 * 
 * Modificari:	Oprescu Claudia
 * Descriere:	Adaugarea de puncte de lucru pentru un angajator.
 * 
 * Modificari:	Lungu Andreea
 * Data:		08.04.2008
 * Descriere:	A fost adaugat campul nr de inregistrare la ITM pentru angajator
 */

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using SiemensHR.Classes;
using SiemensHR.utils;

namespace SiemensHR.Administrare
{
	/// <summary>
	///	Realizeaza toate operatiile necesare administrarii angajatorilor.
	/// </summary>
	public class AdminAngajatori: SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDenumire;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredFiliala;
		protected System.Web.UI.WebControls.Button btnAddBanca;
		protected System.Web.UI.WebControls.TextBox txtDenumire;
		protected System.Web.UI.WebControls.DropDownList lstTipPersoana;
		protected System.Web.UI.WebControls.TextBox txtCUI_CNP;
		protected System.Web.UI.WebControls.TextBox txtNrInreg;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredNrInreg;
		protected System.Web.UI.WebControls.TextBox txtTelefon;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredTelefon;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.TextBox txtAdresaWeb;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.DropDownList lstDTara;
		protected System.Web.UI.WebControls.TextBox txtDLocalitate;
		protected System.Web.UI.WebControls.TextBox txtDStrada;
		protected System.Web.UI.WebControls.TextBox txtDNumar;
		protected System.Web.UI.WebControls.TextBox txtDCodPostal;
		protected System.Web.UI.WebControls.TextBox txtDBloc;
		protected System.Web.UI.WebControls.TextBox txtDScara;
		protected System.Web.UI.WebControls.TextBox txtDEtaj;
		protected System.Web.UI.WebControls.TextBox txtDApartament;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDLocalitate;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDStrada;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDNumar;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDCodPostal;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Table mainTable;
		protected System.Web.UI.HtmlControls.HtmlSelect drpDomDeActPrincipal;
		protected System.Web.UI.WebControls.ListBox lstBoxDomenii;
		protected System.Web.UI.WebControls.ListBox lstBoxDomeniiAngajator;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenDomDeActPpID;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenDomDeActListID;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTaraHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtJudetSectorHidden;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.DropDownList lstTipCompletare;
		protected System.Web.UI.WebControls.TextBox txtNumarContVechi;
		protected System.Web.UI.WebControls.TextBox txtNumarContIBAN;
		protected System.Web.UI.WebControls.DropDownList drpMoneda;
		protected System.Web.UI.WebControls.CheckBox chkActiv;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTipCompletareHidden;
		protected System.Web.UI.WebControls.RangeValidator vldZiuaLichidarii;
		protected System.Web.UI.WebControls.TextBox txtZiLichidareSalariu;
		protected System.Web.UI.WebControls.DropDownList drpBanci;
		protected System.Web.UI.WebControls.ListBox lstConturiBancare;
		protected System.Web.UI.HtmlControls.HtmlInputText txtListaConturiHidden;
		protected System.Web.UI.WebControls.ListBox Listbox1;
		protected System.Web.UI.WebControls.ListBox Listbox2;
		protected System.Web.UI.HtmlControls.HtmlInputText Text1;
		protected System.Web.UI.HtmlControls.HtmlInputText Text2;
		protected System.Web.UI.HtmlControls.HtmlSelect Select1;
		protected System.Web.UI.WebControls.TextBox txtNumePunctLucru;
		protected System.Web.UI.WebControls.ListBox lstPunctLucru;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenPunctLucru;
		protected System.Web.UI.WebControls.DropDownList lstDJudet;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDJudet;
		protected System.Web.UI.WebControls.TextBox txtDSector;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularEmail;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularTelefon;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularFax;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredConturi;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDCodPostal;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDBloc;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDScara;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDEtaj;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDApartament;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDomenii;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredPuncteLucru;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDenumire;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCUI;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNrInreg;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularAdresaWeb;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularSector;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularLocalitate;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularStrada;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNumar;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNrInregItm;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredNrInregItm;
		protected System.Web.UI.WebControls.TextBox txtNrInregItm;
		protected System.Web.UI.WebControls.DropDownList drpCaseDeAsigurari;
		protected Salaries.Configuration.ModuleSettings settings;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Tipurile de completare ale carnetelor de munca.
			Salaries.Business.AdminTipuriCompletareCarnete tipCompletareCarnete = new Salaries.Business.AdminTipuriCompletareCarnete();
			tipCompletareCarnete.AngajatorId = GetAngajator();
			
			// Lista bancilor.
			Salaries.Business.AdminBanci banci = new Salaries.Business.AdminBanci();
			
			string[] textTabs = {"Date angajator", "Conturi bancare", "Adresa angajator", "Domenii de activitate", "Punct de lucru"};
			Utilities.CreateHeaderWithTabsForAdminAngajator(tableTabs, textTabs, "../", true);

			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			
			UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);
			
			// Sunt facute invizibile textbox-urile
			txtHiddenDomDeActPpID.Style.Add("display","none");
			txtHiddenDomDeActListID.Style.Add("display","none");
			txtHiddenPunctLucru.Style.Add("display","none");
			
			//Lungu Andreea 28.05.2008
			//este populat dropdownlist-ul ce contine casele de asigurari
			DataSet dsCaseDeAsig = new DataSet(); 
			Salaries.Business.CasaDeAsigurari casaAsig = new Salaries.Business.CasaDeAsigurari();
			// Lista caselor de asigurari ale unui angajator.
			dsCaseDeAsig = casaAsig.GetAllCasaDeAsigurari();
			drpCaseDeAsigurari.DataSource = dsCaseDeAsig;
			drpCaseDeAsigurari.DataTextField = "Denumire";
			drpCaseDeAsigurari.DataValueField = "CasaDeAsigurariID";
			drpCaseDeAsigurari.DataBind();

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
			lstDJudet.DataSource = judete.GetAllJudeteTara();
			lstDJudet.DataTextField = "NumeCompus";
			lstDJudet.DataValueField = "JudetID";
			lstDJudet.DataBind();
			if( txtJudetSectorHidden.Value != "" )
			{
				lstDJudet.SelectedValue = txtJudetSectorHidden.Value;
			}
			
			// Listarea tipurilor de completare a carnetelor de munca.
			lstTipCompletare.DataSource = tipCompletareCarnete.GetTipuriCompletareCarnete();
			lstTipCompletare.DataTextField = "ModCompletare";
			lstTipCompletare.DataValueField = "CompletareCarneteValoriID";
			lstTipCompletare.DataBind();

			if (txtTipCompletareHidden.Value != "")
			{
				lstTipCompletare.SelectedValue = txtTipCompletareHidden.Value;
			}

			// Listare banci.
			drpBanci.DataSource = banci.GetBanci();
			drpBanci.DataTextField = "NumeBanca";
			drpBanci.DataValueField = "BancaID";
			drpBanci.DataBind();

			// Listare domenii de activitate ale angajatorului
			ListareDomeniiDeActivitate();
			
			txtTaraHidden.Value = txtTaraHidden.Value == "" ? lstDTara.SelectedValue : txtTaraHidden.Value;		
			txtJudetSectorHidden.Value = txtJudetSectorHidden.Value == "" ? lstDJudet.SelectedValue : txtJudetSectorHidden.Value;
			txtTipCompletareHidden.Value = txtTipCompletareHidden.Value == "" ? lstTipCompletare.SelectedValue : txtTipCompletareHidden.Value;

			ListareAngajatori();
		}
		#endregion
		
		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			CreateVarJavaScript();
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
			lstDJudet.DataSource = judete.GetAllJudeteTara();
			lstDJudet.DataTextField = "NumeCompus";
			lstDJudet.DataValueField = "JudetID";
			lstDJudet.DataBind();
		}
		#endregion

		#region CreateVarJavaScript
		/// <summary>
		/// Procedura scrie variabilele pe JavaScript
		/// </summary>
		private void CreateVarJavaScript()
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			string sirTari = GetSirTari();
			string sirJudeteText = GetSirJudeteText();
			string sirJudeteValue = GetSirJudeteValue();
			Response.Write(script_text);

			//client id-urile pentru listbox-uri, dropdown si textbox-uri
			Response.Write( "<script>var lstBoxDomeniiClient = '"+lstBoxDomenii.ClientID+"'</script>" );
			Response.Write( "<script>var lstBoxDomeniiAngajatorClient = '"+lstBoxDomeniiAngajator.ClientID+"'</script>" );
			Response.Write( "<script>var drpDomDeActPrincipalClient = '"+drpDomDeActPrincipal.ClientID+"'</script>" );
			Response.Write( "<script>var txtHiddenDomDeActPpIDClient = '"+txtHiddenDomDeActPpID.ClientID+"'</script>" );
			Response.Write( "<script>var txtHiddenDomDeActListIDClient = '"+txtHiddenDomDeActListID.ClientID+"'</script>" );
			Response.Write( "<script>var txtTaraHiddenClient = '"+txtTaraHidden.ClientID+"'</script>" );
			Response.Write( "<script>var txtJudetSectorHiddenClient='"+txtJudetSectorHidden.ClientID+"'</script>" );
			Response.Write( "<script>var lstDJudetClient='"+lstDJudet.ClientID+"'</script>" );
			Response.Write( "<script>var tari = "+sirTari+";</script>");
			Response.Write( "<script>var judeteText = "+sirJudeteText+";</script>" );
			Response.Write( "<script>var judeteValue = "+sirJudeteValue+";</script>" );

			// Controalele pentru datele aferente conturilor bancare.
			Response.Write( "<script>var drpBanciClientID = '" + drpBanci.ClientID + "';</script>" );
			Response.Write( "<script>var txtNumarContVechiClientID = '" + txtNumarContVechi.ClientID + "';</script>" );
			Response.Write( "<script>var txtNumarContIBANClientID = '" + txtNumarContIBAN.ClientID + "'; </script>" );
			Response.Write( "<script>var drpMonedaClientID = '" + drpMoneda.ClientID + "';</script>" );
			Response.Write( "<script>var chkActivClientID = '" + chkActiv.ClientID + "'; </script>" );
			Response.Write( "<script>var lstConturiBancareClientID = '" + lstConturiBancare.ClientID + "';</script>" );
			Response.Write( "<script>var txtListaConturiHiddenClientID = '" + txtListaConturiHidden.ClientID + "'</script>" );
			
			//Oprescu Cludia
			//se adauga controalele pentru gestiunea punctelor de lucru
			Response.Write( "<script>var txtNumePunctLucru = '" + txtNumePunctLucru.ClientID + "'</script>" );
			Response.Write( "<script>var lstPunctLucru = '" + lstPunctLucru.ClientID + "'</script>" );
			Response.Write( "<script>var txtHiddenPunctLucru = '"+txtHiddenPunctLucru.ClientID+"'</script>" );

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
				// DataSet-ul contine lista tuturor domeniilor de activitate disponibile 
				// pentru angajatorul trimis ca parametru. Parametrul fiind -1 va returna toate domeniile
				// de activitate disponibile in sistem.
				Salaries.Business.AdminDomeniiDeActivitate domenii = new Salaries.Business.AdminDomeniiDeActivitate();
				DataSet dsDomDeAct = domenii.GetDomeniiDeActDisponibilePtAngajator(-1);
				
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
		
		#region ListareAngajatori
		/// <summary>
		/// Lista angajatorilor
		/// </summary>
		public void ListareAngajatori()
		{
			try
			{
				TableRow myRow = new TableRow();
				TableCell myCell = new TableCell();

				//titlul de la listare
				myCell.CssClass = "BigBlueBold";
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Middle;
				myCell.Text = "Lista angajatorilor existenti";
				myCell.Height = new Unit(50);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);

				// lista de banci existente
				myRow = new TableRow();
				myCell = new TableCell();
				myCell.Attributes.Add("width", "100%");
				myCell.HorizontalAlign = HorizontalAlign.Center;
				myCell.VerticalAlign = VerticalAlign.Top;
				Table listTable = new Table();

				string[] tableHeader = {"Denumire", "CUI / CNP", "Nr. inreg. ", "Telefon"};
				string[] tableCols = {"Denumire", "CUI_CNP", "NrInregORC", "Telefon"};

				Salaries.Business.AdminAngajator angajator = new Salaries.Business.AdminAngajator();
				ListTable objListTable = new ListTable(listTable, angajator.LoadInfoAngajatori(), tableHeader, tableCols);

				string[] ar_OnClickParam = {"AngajatorID"};
				string[] ar_OnClickParamType = {"dataset"};

				objListTable.OnclickJSMethod = "SelectAngajator";
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.DrawListTableWithoutDigits();                				

				myCell.Controls.Add(listTable);
				myRow.Cells.Add(myCell);
				mainTable.Rows.Add(myRow);
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion
	
		#region btnAddAngajator_Click
		/// <summary>
		/// Adauga un nou angajator
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks> 
		/// Modificari:
		/// Cristina Muntean:
		/// Adaugarea de domenii de activitate.
		/// Adaugarea conturilor bancare.
		/// Adaugarea zilei de lichidare a salariului.
		/// Adaugarea tipului de completare a carnetelor de munca.
		/// </remarks>
		private void btnAddAngajator_Click(object sender, System.EventArgs e)
		{
			// Lista conturilor bancare ale angajatorului.
			string conturiBancare;
			string[] listaConturiBancare;
			
			try
			{
				lstDTara.SelectedValue = txtTaraHidden.Value;
				BindLstDJudetDDL();
				lstDJudet.SelectedValue = txtJudetSectorHidden.Value;

				Salaries.Business.AdminAngajator myAdmin = new Salaries.Business.AdminAngajator();
				myAdmin.AngajatorId = 0;
				myAdmin.Denumire  = txtDenumire.Text;
				myAdmin.TipPersoana = Convert.ToInt32(lstTipPersoana.SelectedValue);
				myAdmin.CUI_CNP = txtCUI_CNP.Text;
				myAdmin.NrInregORC = txtNrInreg.Text;
				myAdmin.NrInregITM = txtNrInregItm.Text;
				myAdmin.Telefon = txtTelefon.Text;
				myAdmin.Fax = txtFax.Text;
				myAdmin.PaginaWeb = txtAdresaWeb.Text;
				myAdmin.Email = txtEmail.Text;
				myAdmin.ZiLichidareSalar = txtZiLichidareSalariu.Text;
				myAdmin.TipCompletareId = int.Parse(lstTipCompletare.SelectedValue);

				myAdmin.TaraId = Convert.ToInt32(lstDTara.SelectedValue);
				myAdmin.JudetSectorId = Convert.ToInt32(lstDJudet.SelectedValue);
				myAdmin.Localitate = txtDLocalitate.Text;
				myAdmin.Strada = txtDStrada.Text;
				myAdmin.Numar = txtDNumar.Text;
				myAdmin.CodPostal = txtDCodPostal.Text;
				myAdmin.Bloc = txtDBloc.Text;
				myAdmin.Scara = txtDScara.Text;
				myAdmin.Etaj = txtDEtaj.Text;
				myAdmin.Apartament = txtDApartament.Text;
				myAdmin.Sector = txtDSector.Text;
				int angajatorId = 0;

				if (myAdmin.CheckIfAngajatorCanBeAdded())
				{
					angajatorId = myAdmin.InsertAngajatorWithIDReturn();
				}
				else
				{
					Response.Write("<script> alert('Mai exista un angajator cu aceste date!'); </script>");
					return;
				}
					
				string domeniiAngajatorIDList=txtHiddenDomDeActListID.Value.ToString();
				if(domeniiAngajatorIDList!="")
				{
					// Se stabileste separatorul.
					char[] sep = {','};
					// Se face impartirea in functie de separator.
					Array aList = domeniiAngajatorIDList.Split(sep);

					//adauga domeniile de activitate din listbox-ul cu domeniile de activitate ale angajatorului
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
						
						Salaries.Business.ConturiAngajator contAngajator = new Salaries.Business.ConturiAngajator();

						// Datele contului bancar.
						contAngajator.AngajatorId = angajatorId;
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
				//se adauga in baza de date Punctele de lucru ale unui angajator
				/*string lstPunctLucru = txtHiddenPunctLucru.Value.ToString();
				if(lstPunctLucru!="")
				{
					char[] sep = {','};
					Array aList = lstPunctLucru.Split(sep);

					for(int i=0;i<aList.Length;i++)
					{
						Salaries.Business.AdminPunctLucru newAdminPunctLucru = new Salaries.Business.AdminPunctLucru();
						newAdminPunctLucru.PunctLucruId = 0;
						newAdminPunctLucru.AngajatorId = angajatorId;
						newAdminPunctLucru.Nume = aList.GetValue(i).ToString();
						newAdminPunctLucru.InsertPunctLucru();
					}
				}*/

				//Lungu Andreea 28.05.2008 - s-au facut modificari deoarece pentru un anumit punct de lucru s-a adaugat  o casa de asigurari implicita
				string lstPunctLucru = txtHiddenPunctLucru.Value.ToString();
				if(lstPunctLucru!="")
				{
					char[] sep = {';'};
					Array sirPunctLucru = lstPunctLucru.Split(';');
					
					for(int i=0;i<sirPunctLucru.Length;i++)
					{
						//sunt adaugate numai acele Puncte 
						Array PunctLucru = sirPunctLucru.GetValue(i).ToString().Split(',');						
						
							Salaries.Business.AdminPunctLucru newAdminPunctLucru = new Salaries.Business.AdminPunctLucru();
							newAdminPunctLucru.PunctLucruId = 0;
							newAdminPunctLucru.AngajatorId = angajatorId;
							newAdminPunctLucru.Nume = PunctLucru.GetValue(1).ToString();
							newAdminPunctLucru.IdCasaDeAsigImplicita = Int32.Parse(PunctLucru.GetValue(0).ToString());
							newAdminPunctLucru.InsertPunctLucru();
					
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
			this.btnAddBanca.Click += new System.EventHandler(this.btnAddAngajator_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion		
	}
}
