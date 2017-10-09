//Modificat: Oprescu Claudia
//Descriere: s-a renuntat la conversia la numar pentru campurile corespunzatoare numarului de buletin si pasaport
//			 cand se face editarea unui angajet nu se mai incarca si datele despre pasaport si buletin			

/*
* Modificat:	Lungu Andreea
* Data:		    15.02.2011
* Descriere:	S-a adaugat data schimbarii numelui. 
*/

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.IO;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR
{
	/// <summary>
	///		Summary description for EditAngajatDatePersonale.
	/// </summary>
	public class EditAngajatDatePersonale : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.TextBox txtNume;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredField_nume;
		protected System.Web.UI.WebControls.TextBox txtPrenume;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredField_prenume;
		protected System.Web.UI.WebControls.DropDownList lstStareCivila;
		protected System.Web.UI.WebControls.TextBox txtNrCopii;
		protected System.Web.UI.WebControls.DropDownList lstSex;
		protected System.Web.UI.WebControls.DropDownList lstTitlu;
		protected System.Web.UI.WebControls.DropDownList lstStudiu;
		protected System.Web.UI.WebControls.TextBox txtAnAbsolvire;
		protected System.Web.UI.WebControls.TextBox txtNrDiploma;
		protected System.Web.UI.WebControls.TextBox txtTelefon;
		protected System.Web.UI.WebControls.TextBox txtDescriere;
		protected System.Web.UI.WebControls.DropDownList lstDTara;
		protected System.Web.UI.WebControls.DropDownList lstRTara;
		protected System.Web.UI.WebControls.DropDownList lstDJudetSector;
		protected System.Web.UI.WebControls.DropDownList lstRJudetSector;
		protected System.Web.UI.WebControls.TextBox txtDLocalitate;
		protected System.Web.UI.WebControls.TextBox txtRLocalitate;
		protected System.Web.UI.WebControls.TextBox txtDStrada;
		protected System.Web.UI.WebControls.TextBox txtRStrada;
		protected System.Web.UI.WebControls.TextBox txtDNumar;
		protected System.Web.UI.WebControls.TextBox txtRNumar;
		protected System.Web.UI.WebControls.TextBox txtDCodPostal;
		protected System.Web.UI.WebControls.TextBox txtRCodPostal;
		protected System.Web.UI.WebControls.TextBox txtDBloc;
		protected System.Web.UI.WebControls.TextBox txtRBloc;
		protected System.Web.UI.WebControls.TextBox txtDScara;
		protected System.Web.UI.WebControls.TextBox txtRScara;
		protected System.Web.UI.WebControls.TextBox txtDEtaj;
		protected System.Web.UI.WebControls.TextBox txtREtaj;
		protected System.Web.UI.WebControls.TextBox txtDApartament;
		protected System.Web.UI.WebControls.TextBox txtRApartament;
		protected System.Web.UI.WebControls.DropDownList lstAngajator;
		protected System.Web.UI.WebControls.DropDownList lstDepartament;
		protected System.Web.UI.WebControls.TextBox txtMarca;
		protected System.Web.UI.WebControls.DropDownList lstModIncadrare;
		protected System.Web.UI.WebControls.TextBox txtProgramLucru;
		protected System.Web.UI.WebControls.TextBox txtCMSerie;
		protected System.Web.UI.WebControls.TextBox txtCMNumar;
		protected System.Web.UI.WebControls.TextBox txtCMEmitent;
		protected System.Web.UI.WebControls.TextBox txtCMDataEmiterii;
		protected System.Web.UI.WebControls.TextBox txtCMNrInregITM;
		protected System.Web.UI.WebControls.DropDownList lstTipFisaFiscala;
		protected System.Web.UI.WebControls.TextBox txtAniVechimeMunca;
		protected System.Web.UI.WebControls.TextBox txtLuniVechimeMunca;
		protected System.Web.UI.WebControls.TextBox txtZileVechimeMunca;
		protected System.Web.UI.WebControls.DropDownList lstAreCardBancar;
		protected System.Web.UI.WebControls.TextBox txtDataNasterii;
		protected System.Web.UI.WebControls.DropDownList lstTaraNastere;
		protected System.Web.UI.WebControls.DropDownList lstJudetNastere;
		protected System.Web.UI.WebControls.TextBox txtLocalitateNastere;
		protected System.Web.UI.WebControls.TextBox txtPrenumeMama;
		protected System.Web.UI.WebControls.TextBox txtPrenumeTata;
		protected System.Web.UI.WebControls.Button butSaveAngajat;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlInputFile filePozaAngajat;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDLocalitate;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDStrada;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredRLocalitate;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredRStrada;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataNasterii;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredLocalitateNastere;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.DropDownList chkLstInvalid;
		protected System.Web.UI.WebControls.TextBox txtNumeAnterior;
		protected System.Web.UI.HtmlControls.HtmlInputHidden DTaraHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden RTaraHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden DJudetSectorHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden RJudetSectorHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TaraNastereHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden JudetNastereHidden;

		public Salaries.Business.Angajat objAngajat;
		protected System.Web.UI.WebControls.DropDownList lstNationalitate;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.TextBox txtCNP;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCNP;
		protected System.Web.UI.WebControls.CustomValidator customCNP;
		protected System.Web.UI.WebControls.TextBox txtCNPAnterior;
		protected System.Web.UI.WebControls.CustomValidator Customvalidator1;
		protected System.Web.UI.WebControls.TextBox txtCISerie;
		protected System.Web.UI.WebControls.TextBox txtCINumar;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularCINumar;
		protected System.Web.UI.WebControls.TextBox txtCIEliberatDe;
		protected System.Web.UI.WebControls.TextBox txtCIDataEliberarii;
		protected System.Web.UI.WebControls.TextBox txtCIValabilPanaLa;
		protected System.Web.UI.WebControls.TextBox txtPASSerie;
		protected System.Web.UI.WebControls.TextBox txtPASNumar;
		protected System.Web.UI.WebControls.TextBox txtPASEliberatDe;
		protected System.Web.UI.WebControls.TextBox txtPASDataEliberarii;
		protected System.Web.UI.WebControls.TextBox txtPASValabilPanaLa;
		protected System.Web.UI.HtmlControls.HtmlTableRow trBuletin;
		protected System.Web.UI.HtmlControls.HtmlTableRow trPasaport;
		protected System.Web.UI.WebControls.RangeValidator vldAnAbsolvire;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqVldNrCopii;
		protected System.Web.UI.WebControls.RangeValidator vldNrCopii;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularProgramLucru;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNume;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularPrenume;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNumeAnterior;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNrDiploma;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularLocalitate;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularStrada;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNumar;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDNumar;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDCodPostal;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDCodPostal;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDBloc;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDScara;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDEtaj;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularDApartament;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator4;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator5;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator6;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator7;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator8;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator9;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator10;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator11;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator12;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator13;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator14;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button2;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnTara;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnJudet;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnTara1;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnJudet1;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnTara2;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnJudet2;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularPoza;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredFieldValAnAbsolvire;
		protected System.Web.UI.WebControls.TextBox txtDataSchimbariiNumelui;
		//daca modificati denumirea variabilei, trebuie sa o modificati si in AddAngajat.aspx.cs
		private const string directorCopierePoze = "Poze";
		#endregion

		#region Page_Load
        private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			trBuletin.Style.Add( "display", "none" );
			trPasaport.Style.Add( "display", "none" );
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			
			LoadAngajatDates();

			string[] textTabs = {"Date identificare", "Domiciliu - Resedinta", "Date personale"};
			if (Session["Recrutori"].ToString() == "Recrutori")
			{
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "../", true);
				Response.Write("<script> var TipUtilizator = 'Recrutor'; </script>");
				this.Button1.Style.Add("display","none");
				this.Button2.Style.Add("display","none");
				this.btnTara.Style.Add("display","none");
				this.btnJudet.Style.Add("display","none");
				this.btnTara1.Style.Add("display","none");
				this.btnJudet1.Style.Add("display","none");
				this.btnTara2.Style.Add("display","none");
				this.btnJudet2.Style.Add("display","none");
			}
			else
			{
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);
				Response.Write("<script> var TipUtilizator = ''; </script>");
				this.Button1.Style.Add("display","");
				this.Button2.Style.Add("display","");
				this.btnTara.Style.Add("display","");
				this.btnJudet.Style.Add("display","");
				this.btnTara1.Style.Add("display","");
				this.btnJudet1.Style.Add("display","");
				this.btnTara2.Style.Add("display","");
				this.btnJudet2.Style.Add("display","");
			}
		}
		#endregion

		#region CreateVarJavaScript
		/// <summary>
		/// Creaza variabilele JavaScript
		/// </summary>
		private void CreateVarJavaScript()
		{
			Response.Write( "<script>var DTaraHiddenClient = '"+this.DTaraHidden.ClientID+"';</script>" );
			Response.Write( "<script>var RTaraHiddenClient = '"+this.RTaraHidden.ClientID+"';</script>" );
			Response.Write( "<script>var DJudetHiddenClient = '"+this.DJudetSectorHidden.ClientID+"';</script>" );
			Response.Write( "<script>var RJudetHiddenClient = '"+this.RJudetSectorHidden.ClientID+"';</script>" );

			Response.Write( "<script>var TaraNastereHiddenClient = '"+this.TaraNastereHidden.ClientID+"';</script>" );
			Response.Write( "<script>var JudetNastereHiddenClient = '"+this.JudetNastereHidden.ClientID+"';</script>" );

			Response.Write( "<script>var lstDJudeteClient = '"+this.lstDJudetSector.ClientID+"';</script>" );
			Response.Write( "<script>var lstRJudeteClient = '"+this.lstRJudetSector.ClientID+"';</script>" );
			Response.Write( "<script>var lstJudetNastereClient = '"+this.lstJudetNastere.ClientID+"';</script>" );
			string sirTari = GetSirTari();
			string sirJudeteText = GetSirJudeteText();
			string sirJudeteValue = GetSirJudeteValue();
			Response.Write( "<script>var tari = "+sirTari+";</script>");
			Response.Write( "<script>var judeteText = "+sirJudeteText+";</script>" );
			Response.Write( "<script>var judeteValue = "+sirJudeteValue+";</script>" );
		}
		#endregion

		#region CreateVarTipNationalitateDomiciliu
		/// <summary>
		/// Stabileste valorile pentru tipul de nationalitate
		/// </summary>
		/// <param name="ang">Angajatul pentru care se stabilesc datele</param>
		private void CreateVarTipNationalitateDomiciliu(Salaries.Business.Angajat ang )
		{
			int taraBazaID = 0;
			try
			{
				Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
				DataSet dsTaraBaza = tari.GetTaraDeBaza();
				taraBazaID = int.Parse( dsTaraBaza.Tables[ 0 ].Rows[ 0 ][ "TaraID" ].ToString());
			}
			catch
			{
				taraBazaID = 0;
			}

			int tipNationalitateDomiciliu = 0;

			if( ang.Nationalitate == taraBazaID )
			{
				if( ang.DTara == taraBazaID )
				{
					tipNationalitateDomiciliu = 0;
				}
				else
				{
					tipNationalitateDomiciliu = 1;
				}
			}
			else
			{
				tipNationalitateDomiciliu = 2;
			}

			Response.Write( "<script>tipNationalitateDomiciliu = "+tipNationalitateDomiciliu+";</script>" );
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
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
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
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
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
		#endregion

		#region Stabilirea de legaturi cu combobox-uri
		private void BindLstDJudetDDL()
		{
			Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
			lstDJudetSector.DataSource = judete.LoadInfoJudete();
			lstDJudetSector.DataTextField = "NumeCompus";
			lstDJudetSector.DataValueField = "JudetID";
			lstDJudetSector.DataBind();
		}

		private void BindLstRJudetDDL()
		{
			Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
			lstRJudetSector.DataSource = judete.LoadInfoJudete();
			lstRJudetSector.DataTextField = "NumeCompus";
			lstRJudetSector.DataValueField = "JudetID";
			lstRJudetSector.DataBind();
		}

		private void BindLstJudetNastereDDL()
		{
			Salaries.Business.AdminJudete judete = new Salaries.Business.AdminJudete();
			lstJudetNastere.DataSource = judete.LoadInfoJudete();
			lstJudetNastere.DataTextField = "NumeCompus";
			lstJudetNastere.DataValueField = "JudetID";
			lstJudetNastere.DataBind();
		}

		private void BindLstNationalitateDDL()
		{
			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			this.lstNationalitate.DataSource = tari.GetNationalitati();
			this.lstNationalitate.DataValueField = "TaraID";
			this.lstNationalitate.DataTextField = "Nationalitate";
			this.lstNationalitate.DataBind();
		}

		private void BindInvaliditateDDL()
		{
			Salaries.Business.IstoricSchimbareDateAngajat isda = new Salaries.Business.IstoricSchimbareDateAngajat();
			DataSet ds = isda.GetAllInvaliditati();

			chkLstInvalid.DataSource = ds;
			chkLstInvalid.DataTextField = "Nume";
			chkLstInvalid.DataValueField = "InvaliditateID";
			chkLstInvalid.DataBind();
		}
		#endregion

		#region LoadAngajatDates
		/// <summary>
		/// Procedura incarca datele unui angajat
		/// </summary>
		private void LoadAngajatDates()
		{
			// Titlurile ce le pot avea angajatii.
			Salaries.Business.AdminTitluriAngajati titluri = new Salaries.Business.AdminTitluriAngajati();
		
			// Studiile pe care le pot avea angajatii.
			Salaries.Business.AdminStudii studii = new Salaries.Business.AdminStudii();
			
			// Tarile din sistem.
			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
						
			try
			{			
				// Se completeaza formularul de editare cu datele din baza de date
				lstTitlu.DataSource = titluri.LoadInfoTitluriAngajati();
				lstTitlu.DataValueField = "TitluID";
				lstTitlu.DataTextField = "Denumire";
				lstTitlu.DataBind();	
					
				lstStudiu.DataSource = studii.LoadInfoStudii();
				lstStudiu.DataValueField = "StudiuID";
				lstStudiu.DataTextField = "Nume";
				lstStudiu.DataBind();

				lstTaraNastere.DataSource = tari.LoadInfoTariCuJudete();
				lstTaraNastere.DataTextField = "NumeTara";
				lstTaraNastere.DataValueField = "TaraID";
				lstTaraNastere.DataBind();

				lstDTara.DataSource = tari.LoadInfoTariCuJudete();
				lstDTara.DataTextField = "NumeTara";
				lstDTara.DataValueField = "TaraID";
				lstDTara.DataBind();

				lstRTara.DataSource = tari.LoadInfoTariCuJudete();
				lstRTara.DataTextField = "NumeTara";
				lstRTara.DataValueField = "TaraID";
				lstRTara.DataBind();

				BindLstDJudetDDL();
				BindLstRJudetDDL();
				BindLstJudetNastereDDL();
				BindLstNationalitateDDL();

				if( !IsPostBack )
				{
					BindInvaliditateDDL();
				}

				this.chkLstInvalid.SelectedValue=objAngajat.Invaliditate.ToString();

				txtNume.Text = objAngajat.Nume;
				txtPrenume.Text = objAngajat.Prenume;
				txtNumeAnterior.Text = objAngajat.NumeAnterior.ToString();
				txtDataSchimbariiNumelui.Text = Utilities.ConvertDateTime2Text(objAngajat.DataSchimbariiNumelui);
				lstStareCivila.SelectedValue = objAngajat.StareCivila.ToString();
				txtNrCopii.Text = objAngajat.NrCopii.ToString();
				lstSex.SelectedValue = objAngajat.Sex.ToString();
				lstNationalitate.SelectedValue = objAngajat.Nationalitate.ToString();
				lstTitlu.SelectedValue = objAngajat.TitluId.ToString();
				lstStudiu.SelectedValue = objAngajat.StudiuId.ToString();
				txtAnAbsolvire.Text = objAngajat.AnAbsolvire.ToString();
				txtNrDiploma.Text = objAngajat.NrDiploma;
				txtTelefon.Text = objAngajat.Telefon;
				txtDescriere.Text = objAngajat.Descriere;
				txtCNP.Text = objAngajat.CNP.ToString();
				txtCNPAnterior.Text = objAngajat.CNPAnterior.ToString();
				txtDataNasterii.Text = Utilities.ConvertDateTime2Text(objAngajat.DataNasterii);
				if (objAngajat.TaraNastereId!=0)
				{
					lstTaraNastere.SelectedValue = TaraNastereHidden.Value == "" ? objAngajat.TaraNastereId.ToString() : TaraNastereHidden.Value;
				}
				if (objAngajat.JudetNastereId!=0)
				{
					BindLstJudetNastereDDL();
					lstJudetNastere.SelectedValue = JudetNastereHidden.Value == "" ? objAngajat.JudetNastereId.ToString() : JudetNastereHidden.Value;
				}
				txtLocalitateNastere.Text = objAngajat.LocalitateNastere;
				txtPrenumeMama.Text = objAngajat.PrenumeMama;
				txtPrenumeTata.Text = objAngajat.PrenumeTata;
				
				if (objAngajat.DTara !=0)
				{
					lstDTara.SelectedValue = DTaraHidden.Value == "" ? objAngajat.DTara.ToString() : DTaraHidden.Value;
				}
				if (objAngajat.DJudetSectorId != 0)
				{
					BindLstDJudetDDL();
					lstDJudetSector.SelectedValue = DJudetSectorHidden.Value == "" ? objAngajat.DJudetSectorId.ToString() : DJudetSectorHidden.Value;
				}
				txtDLocalitate.Text = objAngajat.DLocalitate;
				txtDStrada.Text = objAngajat.DStrada;
				txtDNumar.Text = objAngajat.DNumar;
				txtDCodPostal.Text = objAngajat.DCodPostal.ToString();
				txtDBloc.Text = objAngajat.DBloc;
				txtDScara.Text = objAngajat.DScara;
				txtDEtaj.Text = objAngajat.DEtaj;
				txtDApartament.Text = objAngajat.DApartament;

				if (objAngajat.RTara !=0)
				{
					lstRTara.SelectedValue = RTaraHidden.Value == "" ? objAngajat.RTara.ToString() : RTaraHidden.Value;
				}
				if (objAngajat.RJudetSectorId != 0)
				{
					BindLstRJudetDDL();
					lstRJudetSector.SelectedValue = RJudetSectorHidden.Value == "" ? objAngajat.RJudetSectorId.ToString() : RJudetSectorHidden.Value;
				}
				txtRLocalitate.Text = objAngajat.RLocalitate;
				txtRStrada.Text = objAngajat.RStrada;
				txtRNumar.Text = objAngajat.RNumar;
				txtRCodPostal.Text = objAngajat.RCodPostal.ToString();
				txtRBloc.Text = objAngajat.RBloc;
				txtRScara.Text = objAngajat.RScara;
				txtREtaj.Text = objAngajat.REtaj;
				txtRApartament.Text = objAngajat.RApartament;

				DTaraHidden.Value = DTaraHidden.Value == "" ? lstDTara.SelectedValue : DTaraHidden.Value;
				RTaraHidden.Value = RTaraHidden.Value == "" ? lstRTara.SelectedValue : RTaraHidden.Value;
				TaraNastereHidden.Value = TaraNastereHidden.Value == "" ? lstTaraNastere.SelectedValue : TaraNastereHidden.Value;
				DJudetSectorHidden.Value = DJudetSectorHidden.Value == "" ? lstDJudetSector.SelectedValue : DJudetSectorHidden.Value;
				RJudetSectorHidden.Value = RJudetSectorHidden.Value == "" ? lstRJudetSector.SelectedValue : RJudetSectorHidden.Value;
				JudetNastereHidden.Value = JudetNastereHidden.Value == "" ? lstJudetNastere.SelectedValue : JudetNastereHidden.Value;

				CreateVarJavaScript();

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
			this.butSaveAngajat.Click += new System.EventHandler(this.butSaveAngajat_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region butSaveAngajat_Click
		/// <summary>
		/// Salveaza datele unui angajat
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void butSaveAngajat_Click(object sender, System.EventArgs e)
		{
			try
			{
				DTaraHidden.Value = DTaraHidden.Value == "" ? lstDTara.SelectedValue : DTaraHidden.Value;
				RTaraHidden.Value = RTaraHidden.Value == "" ? lstRTara.SelectedValue : RTaraHidden.Value;
				TaraNastereHidden.Value = TaraNastereHidden.Value == "" ? lstTaraNastere.SelectedValue : TaraNastereHidden.Value;
				DJudetSectorHidden.Value = DJudetSectorHidden.Value == "" ? lstDJudetSector.SelectedValue : DJudetSectorHidden.Value;
				RJudetSectorHidden.Value = RJudetSectorHidden.Value == "" ? lstRJudetSector.SelectedValue : RJudetSectorHidden.Value;
				JudetNastereHidden.Value = JudetNastereHidden.Value == "" ? lstJudetNastere.SelectedValue : JudetNastereHidden.Value;

				lstDTara.SelectedValue = DTaraHidden.Value;
				lstRTara.SelectedValue = RTaraHidden.Value;
				lstTaraNastere.SelectedValue = TaraNastereHidden.Value;

				BindLstDJudetDDL();
				BindLstRJudetDDL();
				BindLstJudetNastereDDL();

				lstDJudetSector.SelectedValue = DJudetSectorHidden.Value;
				lstRJudetSector.SelectedValue = RJudetSectorHidden.Value;
				lstJudetNastere.SelectedValue = JudetNastereHidden.Value;

				//Date personale
				objAngajat.Nume = txtNume.Text;
				objAngajat.Prenume = txtPrenume.Text;
				objAngajat.NumeAnterior = txtNumeAnterior.Text;
				objAngajat.DataSchimbariiNumelui = Utilities.ConvertText2DateTime(txtDataSchimbariiNumelui.Text);
				objAngajat.StareCivila = Convert.ToByte(lstStareCivila.SelectedValue, 10);
				objAngajat.NrCopii = Convert.ToByte(txtNrCopii.Text, 10);
				objAngajat.Sex = lstSex.SelectedValue;
				objAngajat.Nationalitate = int.Parse( lstNationalitate.SelectedValue );
				objAngajat.TitluId = Convert.ToInt32(lstTitlu.SelectedValue, 10);
				objAngajat.StudiuId = Convert.ToInt32(lstStudiu.SelectedValue, 10);
				if (txtAnAbsolvire.Text != "")
				{
					objAngajat.AnAbsolvire = int.Parse(txtAnAbsolvire.Text);
				}
				objAngajat.NrDiploma = txtNrDiploma.Text;
				objAngajat.Telefon = txtTelefon.Text;
				objAngajat.Descriere = txtDescriere.Text;

				if ((filePozaAngajat.PostedFile.FileName!="") || (filePozaAngajat.PostedFile.ContentLength!=0))
				{
					string contentFile = filePozaAngajat.PostedFile.ContentType.ToString();
					
					if (contentFile.Substring(0,5)=="image")
					{
						//Modificat: Oprescu Claudia
						//Descriere: Se incearca copierea. Daca poza depaseste dimensiunea se arunca o exceptie
						try
						{
							objAngajat.PozaAngajat = CopiazaPozaPeServer();
						}
						catch(Exception ex)
						{
							Response.Write("<script>alert('"+ ex.Message +"');</script>" );
						}
					}
					else
					{
						Response.Write("<script>alert('Se pot salva numai fisiere de tip image (gif, jpg, jpeg...)!');</script>");
					}
				}

				//Domiciliul  - Resedinta
				objAngajat.DTara = Convert.ToInt32(lstDTara.SelectedValue, 10);
				objAngajat.DJudetSectorId = Convert.ToInt32(lstDJudetSector.SelectedValue,10);
				objAngajat.DLocalitate = txtDLocalitate.Text;	
				objAngajat.DStrada = txtDStrada.Text;
				objAngajat.DNumar = txtDNumar.Text;
				objAngajat.DCodPostal = long.Parse(txtDCodPostal.Text);
				objAngajat.DScara = txtDScara.Text;
				objAngajat.DBloc = txtDBloc.Text;
				objAngajat.DEtaj = txtDEtaj.Text;
				objAngajat.DApartament = txtDApartament.Text;

				objAngajat.RTara = Convert.ToInt32(lstRTara.SelectedValue, 10);
				objAngajat.RJudetSectorId = Convert.ToInt32(lstRJudetSector.SelectedValue, 10);
				objAngajat.RLocalitate = txtRLocalitate.Text;
				objAngajat.RApartament = txtRApartament.Text;
				objAngajat.RBloc = txtRBloc.Text;
				objAngajat.RCodPostal = long.Parse(txtRCodPostal.Text);
				objAngajat.REtaj = txtREtaj.Text;
				objAngajat.RNumar = txtRNumar.Text;
				objAngajat.RScara = txtRScara.Text;
				objAngajat.RStrada = txtRStrada.Text;

				//Buletin pasaport
				objAngajat.CNP = Convert.ToInt64(txtCNP.Text, 10);
				objAngajat.DataNasterii = Utilities.ConvertText2DateTime(txtDataNasterii.Text);
				objAngajat.TaraNastereId = Convert.ToInt32(lstTaraNastere.SelectedValue,10);
				objAngajat.JudetNastereId = Convert.ToInt32(lstJudetNastere.SelectedValue, 10);
				objAngajat.LocalitateNastere = txtLocalitateNastere.Text;
				objAngajat.PrenumeMama = txtPrenumeMama.Text;
				objAngajat.PrenumeTata = txtPrenumeTata.Text;

				objAngajat.CIDataEliberarii = Utilities.ConvertText2DateTime(txtCIDataEliberarii.Text);
				objAngajat.CIEliberatDe = txtCIEliberatDe.Text;
				objAngajat.CINumar = txtCINumar.Text;
				objAngajat.CISerie = txtCISerie.Text;
				
				if (txtCIValabilPanaLa.Text!="")
				{
					objAngajat.CIValabilPanaLa = Utilities.ConvertText2DateTime(txtCIValabilPanaLa.Text);
				}

				objAngajat.PASDataEliberarii = Utilities.ConvertText2DateTime(txtPASDataEliberarii.Text);
				objAngajat.PASEliberatDe = txtPASEliberatDe.Text;
				objAngajat.PASNumar = txtPASNumar.Text;
				objAngajat.PASSerie = txtPASSerie.Text;
				objAngajat.PASValabilPanaLa = Utilities.ConvertText2DateTime(txtPASValabilPanaLa.Text);
				objAngajat.Invaliditate=short.Parse(chkLstInvalid.SelectedValue);

				// added by Anca Holostencu:
				// NIF nu poate avea valoarea NULL
				objAngajat.NIF = "";

				objAngajat.UpdateAngajat();

				DTaraHidden.Value = "";
				RTaraHidden.Value = "";
				TaraNastereHidden.Value = "";
				DJudetSectorHidden.Value = "";
				RJudetSectorHidden.Value = "";
				JudetNastereHidden.Value = "";

				long idAng = objAngajat.AngajatId;
				objAngajat = new Salaries.Business.Angajat();
				objAngajat.AngajatId = idAng;
				objAngajat.LoadAngajat();

				CreateVarTipNationalitateDomiciliu( objAngajat );

			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region CopiazaPozaPeServer
		/// <summary>
		/// Procedura copiaza poza angajatului pe server
		/// </summary>
		/// <returns>Returneaza un sir de biti care contin poza</returns>
		private byte[] CopiazaPozaPeServer()
		{
			string StrFileName = (DateTime.Now.ToString().Replace( "/", "_" ).Replace( ":", "_" ).Replace( " ", "_" ))+filePozaAngajat.PostedFile.FileName.Substring( filePozaAngajat.PostedFile.FileName.LastIndexOf("\\") + 1 );
			string sSavePath = "../"+directorCopierePoze+"/";
			string sSavePathFull = Server.MapPath( sSavePath+StrFileName );

			if( !Directory.Exists( Server.MapPath( sSavePath )))
			{
				Directory.CreateDirectory( Server.MapPath( sSavePath ).Substring( 0, Server.MapPath( sSavePath ).Length-1));
			}
			filePozaAngajat.PostedFile.SaveAs( sSavePathFull );

			FileStream fp = new FileStream( sSavePathFull, FileMode.Open, FileAccess.Read );
			BinaryReader br = new BinaryReader(fp);

			byte[] buffer = br.ReadBytes((int)fp.Length);
					
			//daca este depasita dimesniunea se arunca o exceptie
			if (buffer.Length > 65536)
			{
				throw new Exception("Poza are dimensiune prea mare!");
			}
			else
			{
				br.Close();
				fp.Close();

				if( File.Exists( sSavePathFull ))
				{
					File.Delete( sSavePathFull );
				}
				return buffer;
			}
		}
		#endregion
	}
}
