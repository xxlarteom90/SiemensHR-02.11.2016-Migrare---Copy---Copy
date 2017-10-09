/*
 * Modificat:	Oprescu Claudia
 * Data:		09.07.2007
 * Descriere:	A fost adaugata lista pentru Motivul de angajare .
 *				A fost adaugata lista pentru Tipul de angajat.
 * 
 * Modificat:	Oprescu Claudia
 * Data:		09.07.2007
 * Descriere:	A fost adaugata lista pentru Motivul de angajare .
 * 
 * Modificat:	Oprescu Claudia
 * Data:		12.07.2007
 * Descriere:	A fost adaugat campul pentru GID.
 * 
 * Modificat:	Oprescu Claudia
 * Data:		19.09.2007
 * Descriere:	Au fost adaugate campuri pentru PMP si AZM.
 * 
 * Modificat:	Fratila Claudia
 * Data:		29.11.2007
 * Descriere:	A fost adaugata posibilitatea de a sepecifica pentru un angajat daca este scutit de contributia pentru sanatate sau nu.
 *				A fost adaugata posibilitatea de a sepecifica pentru un angajat daca este scutit de contributia pentru CAS sau nu.
 * 
 * Modificat:	Lungu Andreea
 * Data:		20.05.2010
 * Descriere:	A fost schimbata partea de vechime
 * 
 * Modificat:	Lungu Andreea
 * Data:		15.02.2011
 * Descriere:	A fost adaugat "angajat scutit contributie somaj".
 *  
 * Modificat:	Manuel Neagoe
 * Data:		29.01.2013
 * Descriere:	A fost adaugat "Tip Asigurat".
*/

using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data.SqlClient;

using SiemensHR.utils;
using SiemensHR.Classes;
using Salaries.Business;

/*
* Modificat:	Lungu Andreea
* Data:			28.05.2008
* Descriere:	Au fost facute modificari astfel incat atunci cand se selecteaza un punct de lucru pentru angajat sa se seteze implicit o casa de asigurari.
*/
namespace SiemensHR
{
    /// <summary>
    ///		Summary description for EditAngajatDateAngajare.
    /// </summary>
    public class EditAngajatDateAngajare : System.Web.UI.UserControl
    {
        #region Variabile
        protected System.Web.UI.WebControls.DropDownList lstAngajator;
        protected System.Web.UI.WebControls.TextBox txtMarca;
        protected System.Web.UI.WebControls.RequiredFieldValidator requiredMarca;
        protected System.Web.UI.WebControls.DropDownList lstModIncadrare;
        protected System.Web.UI.WebControls.TextBox txtProgramLucru;
        protected System.Web.UI.WebControls.TextBox txtCMSerie;
        protected System.Web.UI.WebControls.TextBox txtCMNumar;
        protected System.Web.UI.WebControls.TextBox txtCMEmitent;
        protected System.Web.UI.WebControls.TextBox txtCMDataEmiterii;
        protected System.Web.UI.WebControls.TextBox txtCMNrInregITM;
        protected System.Web.UI.WebControls.Literal litError;
        protected System.Web.UI.WebControls.Button butSaveAngajat;
        protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
        protected System.Web.UI.WebControls.DropDownList lstTipFisaFiscala;
        protected System.Web.UI.WebControls.DropDownList lstAreCardBancar;
        protected System.Web.UI.WebControls.RegularExpressionValidator regularProgramLucru;
        protected System.Web.UI.WebControls.RequiredFieldValidator requiredProgramLucru;
        protected System.Web.UI.WebControls.Table tableTabs;

        //protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
        protected System.Web.UI.HtmlControls.HtmlSelect lstPerAngajarii;
        protected System.Web.UI.HtmlControls.HtmlGenericControl toHide;

        protected System.Web.UI.WebControls.TextBox txtDataPanaLa;
        protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataPanaLa;
        protected System.Web.UI.WebControls.TextBox txtNrContractMunca;
        protected System.Web.UI.WebControls.TextBox txtDataInreg;
        protected System.Web.UI.WebControls.CompareValidator CompareValidator2;
        protected System.Web.UI.WebControls.CompareValidator CompareValidator3;
        protected System.Web.UI.WebControls.TextBox txtSalariu;
        protected System.Web.UI.WebControls.TextBox txtIndemnizatie;
        protected System.Web.UI.WebControls.DropDownList lstCategorie;
        protected System.Web.UI.WebControls.TextBox txtTelMunca;
        protected System.Web.UI.WebControls.TextBox txtEmail;
        protected System.Web.UI.WebControls.TextBox txtDataDeLa;
        protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataDeLa;
        protected System.Web.UI.WebControls.DropDownList dropDataCAS;
        protected System.Web.UI.WebControls.TextBox txtCAS1;
        protected System.Web.UI.WebControls.TextBox txtCAS2;
        protected System.Web.UI.WebControls.TextBox txtCAS3;
        protected System.Web.UI.WebControls.TextBox txtCAS4;
        protected System.Web.UI.WebControls.TextBox txtCAS5;
        protected System.Web.UI.WebControls.TextBox txtCAS6;
        protected System.Web.UI.WebControls.DropDownList dropLunileId;
        protected int[] tabLuni = new int[6];
        protected double[] tabCAS = new double[6];
        //protected Boolean notCAS;
        protected Boolean valInsert, valUpdate;
        protected System.Web.UI.WebControls.RadioButton radioDa;
        protected System.Web.UI.WebControls.RadioButton radioNu;
        protected System.Web.UI.WebControls.DropDownList dropLunileAnului;
        protected System.Web.UI.WebControls.Label txtLuna1;
        protected System.Web.UI.WebControls.Label txtLuna2;
        protected System.Web.UI.WebControls.Label txtLuna3;
        protected System.Web.UI.WebControls.Label txtLuna4;
        protected System.Web.UI.WebControls.Label txtLuna5;
        protected System.Web.UI.WebControls.Label txtLuna6;
        protected System.Web.UI.WebControls.TextBox txtNrZileCOAn;
        protected System.Web.UI.WebControls.CompareValidator Comparevalidator1;
        protected System.Web.UI.WebControls.TextBox txtSumaMajorare;
        protected System.Web.UI.WebControls.CompareValidator Comparevalidator5;
        protected System.Web.UI.WebControls.TextBox txtDataPlanificareMajorare;
        protected System.Web.UI.WebControls.TextBox txtPerProba;
        protected System.Web.UI.WebControls.TextBox txtSporuri;
        protected System.Web.UI.WebControls.CompareValidator vldSporuri;
        protected System.Web.UI.WebControls.TextBox txtAlteAdaosuri;
        protected System.Web.UI.WebControls.CompareValidator vldAlteAdaosuri;
        protected System.Web.UI.WebControls.TextBox txtNrZileCOSupl;
        protected System.Web.UI.WebControls.CompareValidator cmpNrZileCoSupl;
        protected System.Web.UI.WebControls.TextBox txtAlteClauzeCIM;
        protected System.Web.UI.WebControls.DropDownList drpEchIndProtectie;
        protected System.Web.UI.WebControls.TextBox txtEchIndProtectie;
        protected System.Web.UI.WebControls.DropDownList drpEchIndLucru;
        protected System.Web.UI.WebControls.TextBox txtEchIndLucru;
        protected System.Web.UI.WebControls.DropDownList drpMatIgiSan;
        protected System.Web.UI.WebControls.TextBox txtMatIgiSan;
        protected System.Web.UI.WebControls.DropDownList drpAlimProtectie;
        protected System.Web.UI.WebControls.TextBox txtAlimProtectie;
        protected System.Web.UI.WebControls.DropDownList drpAlteDrSiObl;
        protected System.Web.UI.WebControls.TextBox txtAlteDrSiObl;
        protected System.Web.UI.WebControls.DropDownList lstSef;
        protected Salaries.Configuration.ModuleSettings settings;
        protected System.Web.UI.WebControls.CheckBox lichidatCheck;
        protected System.Web.UI.WebControls.CheckBox pensionatCheck;
        protected System.Web.UI.WebControls.DropDownList lstPunctLucru;
        protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenPunctLucru;
        protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenPunctLucruVechi;
        protected System.Web.UI.WebControls.DropDownList lstCasaDeAsigurari;
        protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenCasaDeAsigurari;
        protected System.Web.UI.WebControls.RegularExpressionValidator regularEmail;
        protected System.Web.UI.WebControls.RequiredFieldValidator requiredNrZileCOAn;
        protected System.Web.UI.WebControls.RequiredFieldValidator requiredNrZileCOSupl;
        protected System.Web.UI.WebControls.RequiredFieldValidator requiredCategorie;
        protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
        protected System.Web.UI.WebControls.RegularExpressionValidator regularMarca;
        protected System.Web.UI.WebControls.ValidationSummary ValidationSummary2;
        protected System.Web.UI.WebControls.RegularExpressionValidator regularPerioadaProba;
        protected System.Web.UI.WebControls.RegularExpressionValidator regularNrContract;
        protected System.Web.UI.WebControls.RegularExpressionValidator regularSerie;
        protected System.Web.UI.WebControls.RegularExpressionValidator regularNumar;
        protected System.Web.UI.WebControls.RegularExpressionValidator regularEmitent;
        protected System.Web.UI.WebControls.RegularExpressionValidator regularNrInreg;
        protected System.Web.UI.WebControls.CompareValidator Comparevalidator10;
        protected System.Web.UI.WebControls.CompareValidator Comparevalidator4;
        protected System.Web.UI.WebControls.CompareValidator Comparevalidator6;
        protected System.Web.UI.WebControls.CompareValidator Comparevalidator7;
        protected System.Web.UI.WebControls.CompareValidator Comparevalidator8;
        protected System.Web.UI.WebControls.CompareValidator Comparevalidator9;
        private bool eroareLoadCheckCAS;
        protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenExistaDateCAS;
        protected System.Web.UI.WebControls.DropDownList lstMotivDeAngajare;
        protected System.Web.UI.WebControls.DropDownList lstTipDeAngajat;
        protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenMotivDeAngajare;
        protected System.Web.UI.HtmlControls.HtmlInputText txtHiddenTipDeAngajat;
        protected System.Web.UI.WebControls.TextBox txtGid;
        protected System.Web.UI.WebControls.RequiredFieldValidator requiredGid;
        protected System.Web.UI.WebControls.RegularExpressionValidator regularGid;
        protected System.Web.UI.WebControls.RadioButtonList rblPMP;
        protected System.Web.UI.WebControls.RadioButtonList rblAZM;
        protected System.Web.UI.WebControls.RadioButtonList rblRetinereSanatate;
        protected System.Web.UI.WebControls.RadioButtonList rblRetinereCAS;
        protected System.Web.UI.WebControls.Label lblLichidat;
        protected System.Web.UI.WebControls.Label lTotal;
        protected System.Web.UI.WebControls.Label lZileTotal;
        protected System.Web.UI.WebControls.Label lLuniTotal;
        protected System.Web.UI.WebControls.Label lAniTotal;
        protected System.Web.UI.WebControls.Label lTotalAngCurent;
        protected System.Web.UI.WebControls.Label lZileAngCurent;
        protected System.Web.UI.WebControls.Label lLuniAngCurent;
        protected System.Web.UI.WebControls.Label lAniAngCurent;
        protected System.Web.UI.WebControls.Label lTotalAnterior;
        protected System.Web.UI.WebControls.Label lZileAnterior;
        protected System.Web.UI.WebControls.Label lLuniAnterior;
        protected System.Web.UI.WebControls.Label lAniAnterior;
        protected System.Web.UI.WebControls.Label lTotalIntrerupere;
        protected System.Web.UI.WebControls.Label lZileIntrerupere;
        protected System.Web.UI.WebControls.Label lLuniIntrerupere;
        protected System.Web.UI.WebControls.Label lAniIntrerupere;
        protected System.Web.UI.WebControls.Label lTotalAngAnterior;
        protected System.Web.UI.WebControls.Label lZileAngAnterior;
        protected System.Web.UI.WebControls.Label lLuniAngAnterior;
        protected System.Web.UI.WebControls.Label lAniAngAnterior;
        protected System.Web.UI.HtmlControls.HtmlInputRadioButton radioButtonDa;
        protected System.Web.UI.HtmlControls.HtmlInputRadioButton radioButtonNu;
        protected System.Web.UI.HtmlControls.HtmlTableCell tdPerioade;
        protected System.Web.UI.HtmlControls.HtmlTable tabelPerioade;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txtSirDeLa;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txtSirPanaLa;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txtSirIdPerioada;
        protected System.Web.UI.WebControls.TextBox txtBirou;
        protected System.Web.UI.WebControls.RadioButtonList rblRetinereSomaj;
        protected System.Web.UI.WebControls.RequiredFieldValidator reqFieldValNrContractMunca;
        protected System.Web.UI.WebControls.RequiredFieldValidator reqFieldValDataInregistrareContract;
        protected System.Web.UI.HtmlControls.HtmlInputHidden txtSirLaSiemens;
        protected System.Web.UI.WebControls.DropDownList lstTipAsigurat;

        public Salaries.Business.Angajat objAngajat;
        #endregion

        #region Page_Load
        private void Page_Load(object sender, System.EventArgs e)
        {
            valInsert = false;
            valUpdate = false;
            eroareLoadCheckCAS = false;
            settings = Salaries.Configuration.ModuleConfig.GetSettings();
            UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);

            //ClientID-urile unor textBox-uri si dropdownlist-uri--> JavaScript
            GetClientIDs();
            //seteaza vizibilitatea unor textbox-uri
            SetTextBoxVisibility();

            Salaries.Business.AdminAngajator angajator = new Salaries.Business.AdminAngajator();
            lstAngajator.DataSource = angajator.LoadInfoAngajatori();
            lstAngajator.DataValueField = "AngajatorID";
            lstAngajator.DataTextField = "Denumire";
            lstAngajator.DataBind();
            lstAngajator.SelectedValue = objAngajat.AngajatorId.ToString();


            if (!IsPostBack)
            {
                BindSefDDL();
                //BindCasaDeAsigurari();
                BindMotiveDeAngajare();
                BindTipuriDeAngajati();
                BindTipAsigurat();
            }

            //Lungu Andreea 27.06.2008
            //se populeaza cele doua dropdownlist-uri si se selecteaza valoarea care e in campurile hidden
            //BindPunctLucru();
            if (txtHiddenPunctLucru.Value != "")
            {
                lstPunctLucru.SelectedValue = txtHiddenPunctLucru.Value;
            }
            BindCasaDeAsigurari();
            if (txtHiddenCasaDeAsigurari.Value != "")
            {
                lstCasaDeAsigurari.SelectedValue = txtHiddenCasaDeAsigurari.Value;
            }

            Luni luni = new Luni(int.Parse(lstAngajator.SelectedValue));
            int LunaID = luni.GetLunaActiva().LunaId;

            AdminSalariiCategoriiAngajati ca = new AdminSalariiCategoriiAngajati();
            ca.LunaId = LunaID;
            lstCategorie.DataSource = ca.LoadInfoCategoriiLunaId();
            lstCategorie.DataTextField = "Denumire";
            lstCategorie.DataValueField = "CategorieID";
            lstCategorie.DataBind();

            txtTelMunca.Text = objAngajat.TelMunca;
            txtEmail.Text = objAngajat.Email;

            txtMarca.Text = objAngajat.Marca;
            txtGid.Text = objAngajat.Gid;
            txtProgramLucru.Text = objAngajat.ProgramLucru.ToString();
            txtHiddenPunctLucruVechi.Value = objAngajat.PunctLucruId.ToString();
            //Lungu Andreea
            if (!IsPostBack)
                txtHiddenPunctLucru.Value = objAngajat.PunctLucruId.ToString();

            txtHiddenCasaDeAsigurari.Value = objAngajat.CasaDeAsigurariId.ToString();
            txtHiddenMotivDeAngajare.Value = objAngajat.MotivDeAngajareId.ToString();
            txtHiddenTipDeAngajat.Value = objAngajat.TipDeAngajatId.ToString();

            lstPunctLucru.SelectedValue = objAngajat.PunctLucruId.ToString();
            lstCasaDeAsigurari.SelectedValue = objAngajat.CasaDeAsigurariId.ToString();
            lstMotivDeAngajare.SelectedValue = objAngajat.MotivDeAngajareId.ToString();
            lstTipDeAngajat.SelectedValue = objAngajat.TipDeAngajatId.ToString();
            lstModIncadrare.SelectedValue = objAngajat.ModIncadrare.ToString();
            lstTipFisaFiscala.SelectedValue = objAngajat.TipFisaFiscala.ToString();
            try
            {
                lstTipAsigurat.SelectedValue = objAngajat.TipAsiguratId.ToString();
            }
            catch { }

            try
            {
                lstCategorie.SelectedValue = objAngajat.CategorieId.ToString();
            }

            catch { }

            try
            {
                lstSef.SelectedValue = objAngajat.SefId.ToString();
            }
            catch { }

            //Lungu Andreea - 03.06.2010 - am comentat pentru ca vechimea se afiseaza altfel
            //				txtAniVechimeMunca.Text = objAngajat.AniVechimeMunca.ToString();
            //				txtLuniVechimeMunca.Text = objAngajat.LuniVechimeMunca.ToString();
            //				txtZileVechimeMunca.Text = objAngajat.ZileVechimeMunca.ToString();

            txtCMSerie.Text = objAngajat.CMSerie;
            txtCMNumar.Text = objAngajat.CMNumar;
            txtCMNrInregITM.Text = objAngajat.CMNrInregITM;
            txtCMEmitent.Text = objAngajat.CMEmitent;
            txtCMDataEmiterii.Text = Utilities.ConvertDateTime2Text(objAngajat.CMDataEmiterii);

            lstPerAngajarii.SelectedIndex = (objAngajat.PerioadaDeterminata == true) ? 0 : 1;

            txtDataDeLa.Text = Utilities.ConvertDateTime2Text(objAngajat.DataDeLa);
            if (objAngajat.PerioadaDeterminata == true)
            {
                txtDataPanaLa.Text = Utilities.ConvertDateTime2Text(objAngajat.DataPanaLa);
            }
            //perioada de proba
            txtPerProba.Text = objAngajat.PerProba.ToString();
            txtNrContractMunca.Text = objAngajat.NrContractMunca;
            txtDataInreg.Text = Utilities.ConvertDateTime2Text(objAngajat.DataInregContractMunca);
            //Modified: Popa Ionel
            //Trebuie refacut codul astfel incat sa functioneze validatorii de double
            /*
            txtSalariu.Text = objAngajat.SalariuBaza.ToString("N",VariabileGlobale.numberInfoFormatWithDigits);			
            txtIndemnizatie.Text = objAngajat.IndemnizatieConducere.ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithDigits);
            txtSporuri.Text = objAngajat.Sporuri.ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithDigits);
            txtAlteAdaosuri.Text = objAngajat.AlteAdaosuri.ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithDigits);
            txtSumaMajorare.Text = objAngajat.SumaMajorare.ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithDigits);
            */
            txtSalariu.Text = objAngajat.SalariuBaza.ToString();
            txtIndemnizatie.Text = objAngajat.IndemnizatieConducere.ToString();
            txtSporuri.Text = objAngajat.Sporuri.ToString();
            txtAlteAdaosuri.Text = objAngajat.AlteAdaosuri.ToString();
            txtSumaMajorare.Text = objAngajat.SumaMajorare.ToString();
            if (objAngajat.DataMajorare != DateTime.MinValue)
            {
                //txtDataPlanificareMajorare.Text=objAngajat.DataMajorare.ToShortDateString();
                txtDataPlanificareMajorare.Text = Utilities.ConvertDateTime2Text(objAngajat.DataMajorare);
            }
            else
            {
                txtDataPlanificareMajorare.Text = "";
            }
            txtNrZileCOAn.Text = objAngajat.NrZileCOAn.ToString();
            //numar zile de concediu suplimentar pe an
            txtNrZileCOSupl.Text = objAngajat.NrZileCOSupl.ToString();
            txtAlteClauzeCIM.Text = objAngajat.AlteClauzeCIM.ToString();

            //Modified: Ionel Popa
            //Date despre lichidare
            lichidatCheck.Checked = objAngajat.IsLichidat;
            //Daca angajatul nu este lichidat atunci nu se poate lichida doar prin simpla check-uire - trebuie sa mearga in Pontaj\Lichidare Angajat
            if (!objAngajat.IsLichidat)
            {
                lichidatCheck.Enabled = false;
                lblLichidat.Text = "";
            }
            else
                lblLichidat.Text = "LICHIDAT";
            //Date despre pensionare
            pensionatCheck.Checked = objAngajat.IsPensionat;
            rblPMP.SelectedValue = objAngajat.PMP ? "1" : "0";
            rblAZM.SelectedValue = objAngajat.AZM ? "1" : "0";
            rblRetinereSanatate.SelectedValue = objAngajat.RetinereSanatate ? "1" : "0";
            rblRetinereCAS.SelectedValue = objAngajat.RetinereCAS ? "1" : "0";
            rblRetinereSomaj.SelectedValue = objAngajat.RetinereSomaj ? "1" : "0";
            txtBirou.Text = objAngajat.Birou;

            //se incarca controalele cu datele specifice angajtului
            IncarcaDrepturiObligatii();

            //Lungu Andreea - 02.01.2010
            //VechimeInMunca();
            VariabileJavascriptVechime();
            CalculeazaVechimi();

            //Oprescu Claudia
            //se retin angajatorii si punctele de lucru corespunzatoare lor
            txtHiddenPunctLucru.Style.Add("display", "none");
            txtHiddenPunctLucruVechi.Style.Add("display", "none");
            txtHiddenCasaDeAsigurari.Style.Add("display", "none");
            txtHiddenMotivDeAngajare.Style.Add("display", "none");
            txtHiddenTipDeAngajat.Style.Add("display", "none");
            string sirAngajatorPunctLucru = GetSirAngajatorPunctLucru();
            Response.Write("<script>var angajatorPunctLucru = " + sirAngajatorPunctLucru + ";</script>");
            Response.Write("<script>var lstAngajator = '" + this.lstAngajator.ClientID + "';</script>");
            Response.Write("<script>var lstPunctLucru = '" + this.lstPunctLucru.ClientID + "';</script>");
            Response.Write("<script>var lstCasaDeAsigurari = '" + this.lstCasaDeAsigurari.ClientID + "';</script>");
            Response.Write("<script>var lstMotivDeAngajare = '" + this.lstMotivDeAngajare.ClientID + "';</script>");
            Response.Write("<script>var lstTipDeAngajat = '" + this.lstTipDeAngajat.ClientID + "';</script>");
            Response.Write("<script>var txtHiddenPunctLucru = '" + this.txtHiddenPunctLucru.ClientID + "'</script>");
            Response.Write("<script>var txtHiddenPunctLucruVechi = '" + this.txtHiddenPunctLucruVechi.ClientID + "'</script>");
            Response.Write("<script>var txtHiddenCasaDeAsigurari = '" + this.txtHiddenCasaDeAsigurari.ClientID + "'</script>");
            Response.Write("<script>var txtHiddenExistaDateCAS = '" + this.txtHiddenExistaDateCAS.ClientID + "'</script>");
            Response.Write("<script>var txtHiddenMotivDeAngajare = '" + this.txtHiddenMotivDeAngajare.ClientID + "'</script>");
            Response.Write("<script>var txtHiddenTipDeAngajat = '" + this.txtHiddenTipDeAngajat.ClientID + "'</script>");

            //Lungu Andreea - 28.05.2008
            string sirPuncteLucru = GetSirPuncteLucru();
            Response.Write("<script>var sirPuncteLucru = " + sirPuncteLucru + ";</script>");

            string[] textTabs = { "Editare date angajat", "Date PSI" };
            Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);

            string script_text = "<script>var ctrlID = \"" + this.UniqueID + "\"</script>";
            Response.Write(script_text);

            InitCAS();
        }

        private void BindSefDDL()
        {
            Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
            angajat.CategorieId = -1;
            angajat.AngajatorId = Convert.ToInt32(lstAngajator.SelectedValue);
            DataSet ds = angajat.GetAllAngajati();
            this.lstSef.DataSource = ds;
            this.lstSef.DataValueField = "AngajatID";
            this.lstSef.DataTextField = "NumeIntreg";
            this.lstSef.DataBind();
        }


        private void BindCasaDeAsigurari()
        {
            Salaries.Business.CasaDeAsigurari objCasaDeAsigurari = new Salaries.Business.CasaDeAsigurari();
            lstCasaDeAsigurari.DataSource = objCasaDeAsigurari.GetAllCasaDeAsigurari();
            lstCasaDeAsigurari.DataTextField = "Denumire";
            lstCasaDeAsigurari.DataValueField = "CasaDeAsigurariID";
            lstCasaDeAsigurari.DataBind();
        }


        /// <summary>
        /// Adaugat:	ManuelNeagoe
        /// Data:		29.01.2013
        /// Descriere:	Se incarca lista care contine tipurile de asigurat
        /// </summary>
        private void BindTipAsigurat()
        {
            Salaries.Business.TipAsigurat objTipAsigurat = new Salaries.Business.TipAsigurat();
            lstTipAsigurat.DataSource = objTipAsigurat.GetAllTipAsigurat();
            lstTipAsigurat.DataTextField = "Descriere";
            lstTipAsigurat.DataValueField = "TipAsiguratID";
            lstTipAsigurat.DataBind();
        }

        /// <summary>
        /// Adaugat:	Oprescu Claudia
        /// Data:		09.07.2007
        /// Descriere:	Se incarca lista care contine motivele de angajare
        /// </summary>
        private void BindMotiveDeAngajare()
        {
            Salaries.Business.AdminMotiveDeAngajare objMotive = new Salaries.Business.AdminMotiveDeAngajare();
            lstMotivDeAngajare.DataSource = objMotive.LoadMotiveDeAngajare();
            lstMotivDeAngajare.DataTextField = "DenumireIntreaga";
            lstMotivDeAngajare.DataValueField = "MotivDeAngajareId";
            lstMotivDeAngajare.DataBind();
        }

        /// <summary>
        /// Adaugat:	Oprescu Claudia
        /// Data:		09.07.2007
        /// Descriere:	Se incarca lista care contine tipurile de angajati
        /// </summary>
        private void BindTipuriDeAngajati()
        {
            Salaries.Business.AdminTipuriDeAngajati objTipuriAngajati = new Salaries.Business.AdminTipuriDeAngajati();
            lstTipDeAngajat.DataSource = objTipuriAngajati.LoadTipuriDeAngajati();
            lstTipDeAngajat.DataTextField = "DenumireIntreaga";
            lstTipDeAngajat.DataValueField = "TipDeAngajatId";
            lstTipDeAngajat.DataBind();
        }

        #endregion

        #region SetTextBoxVisibility
        /// <summary>
        /// Seteaza vizibilitatea unor textbox-uri
        /// </summary>
        public void SetTextBoxVisibility()
        {
            txtEchIndProtectie.Style.Add("display", "none");
            txtEchIndLucru.Style.Add("display", "none");
            txtMatIgiSan.Style.Add("display", "none");
            txtAlimProtectie.Style.Add("display", "none");
            txtAlteDrSiObl.Style.Add("display", "none");
        }
        #endregion

        #region GetClientIDs
        /// <summary>
        /// ClientID-urile unor dropdown-uri si textbox-uri-->JavaScript
        /// </summary>
        public void GetClientIDs()
        {
            Response.Write("<script>var txtEchIndLucruClient = '" + txtEchIndLucru.ClientID + "'</script>");
            Response.Write("<script>var drpEchIndLucruClient = '" + drpEchIndLucru.ClientID + "'</script>");
            Response.Write("<script>var txtEchIndProtectieClient = '" + txtEchIndProtectie.ClientID + "'</script>");
            Response.Write("<script>var drpEchIndProtectieClient = '" + drpEchIndProtectie.ClientID + "'</script>");
            Response.Write("<script>var txtMatIgiSanClient = '" + txtMatIgiSan.ClientID + "'</script>");
            Response.Write("<script>var drpMatIgiSanClient = '" + drpMatIgiSan.ClientID + "'</script>");
            Response.Write("<script>var txtAlimProtectieClient = '" + txtAlimProtectie.ClientID + "'</script>");
            Response.Write("<script>var drpAlimProtectieClient = '" + drpAlimProtectie.ClientID + "'</script>");
            Response.Write("<script>var txtAlteDrSiOblClient = '" + txtAlteDrSiObl.ClientID + "'</script>");
            Response.Write("<script>var drpAlteDrSiOblClient = '" + drpAlteDrSiObl.ClientID + "'</script>");
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

        #region IncarcaDrepturiObligatii()
        /// <summary>
        /// Procedura incarca drapturi si obligatii ale angajatului
        /// </summary>
        private void IncarcaDrepturiObligatii()
        {
            //Cristina Muntean
            //drepturi si obligatii privind sanatatea si securitatea in munca
            //echipament individual de protectie
            switch (objAngajat.EchIndProtectie)
            {
                case "DA - specific meseriei":
                    txtEchIndProtectie.Style.Add("display", "none");
                    drpEchIndProtectie.Items.FindByText("DA - specific meseriei").Selected = true;
                    break;
                case "NU":
                    txtEchIndProtectie.Style.Add("display", "none");
                    drpEchIndProtectie.Items.FindByText("NU").Selected = true;
                    break;
                default:
                    txtEchIndProtectie.Style.Add("display", "");
                    txtEchIndProtectie.Text = objAngajat.EchIndProtectie.ToString();
                    drpEchIndProtectie.Items.FindByText("DA").Selected = true;
                    break;
            }


            //echipament individual de lucru
            switch (objAngajat.EchIndLucru)
            {
                case "DA - specific meseriei":
                    txtEchIndLucru.Style.Add("display", "none");
                    drpEchIndLucru.Items.FindByText("DA - specific meseriei").Selected = true;
                    break;
                case "NU":
                    txtEchIndLucru.Style.Add("display", "none");
                    drpEchIndLucru.Items.FindByText("NU").Selected = true;
                    break;
                default:
                    txtEchIndLucru.Style.Add("display", "");
                    txtEchIndLucru.Text = objAngajat.EchIndLucru.ToString();
                    drpEchIndLucru.Items.FindByText("DA").Selected = true;
                    break;
            }

            //materiale igienico-sanitare
            switch (objAngajat.MatIgiSan)
            {
                case "DA - specific meseriei":
                    txtMatIgiSan.Style.Add("display", "none");
                    drpMatIgiSan.Items.FindByText("DA - specific meseriei").Selected = true;
                    break;
                case "NU":
                    txtMatIgiSan.Style.Add("display", "none");
                    drpMatIgiSan.Items.FindByText("NU").Selected = true;
                    break;
                default:
                    txtMatIgiSan.Style.Add("display", "");
                    txtMatIgiSan.Text = objAngajat.MatIgiSan.ToString();
                    drpMatIgiSan.Items.FindByText("DA").Selected = true;
                    break;
            }
            //alimentatie de protectie
            switch (objAngajat.AlimProtectie)
            {
                case "DA - specific meseriei":
                    txtAlimProtectie.Style.Add("display", "none");
                    drpAlimProtectie.Items.FindByText("DA - specific meseriei").Selected = true;
                    break;
                case "NU":
                    txtAlimProtectie.Style.Add("display", "none");
                    drpAlimProtectie.Items.FindByText("NU").Selected = true;
                    break;
                default:
                    txtAlimProtectie.Style.Add("display", "");
                    txtAlimProtectie.Text = objAngajat.AlimProtectie.ToString();
                    drpAlimProtectie.Items.FindByText("DA").Selected = true;
                    break;
            }
            //alte drepturi si obligatii privind sanatatea in munca
            switch (objAngajat.AlteDrSiObl)
            {
                case "DA - specific meseriei":
                    txtAlteDrSiObl.Style.Add("display", "none");
                    drpAlteDrSiObl.Items.FindByText("DA - specific meseriei").Selected = true;
                    break;
                case "NU":
                    txtAlteDrSiObl.Style.Add("display", "none");
                    drpAlteDrSiObl.Items.FindByText("NU").Selected = true;
                    break;
                default:
                    txtAlteDrSiObl.Style.Add("display", "");
                    txtAlteDrSiObl.Text = objAngajat.AlteDrSiObl.ToString();
                    drpAlteDrSiObl.Items.FindByText("DA").Selected = true;
                    break;
            }

            //Lungu Andreea - 03.06.2010 - am comentat pentru ca vechimea se afiseaza altfel
            //			txtAniVechimeMunca.Text = objAngajat.AniVechimeMunca.ToString();
            //			txtLuniVechimeMunca.Text = objAngajat.LuniVechimeMunca.ToString();
            //			txtZileVechimeMunca.Text = objAngajat.ZileVechimeMunca.ToString();
        }

        #endregion

        #region butSaveAngajat
        /// <summary>
        /// Salveaza datele angajatului
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butSaveAngajat_Click(object sender, System.EventArgs e)
        {
            try
            {
                objAngajat.PunctLucruId = Convert.ToInt32(txtHiddenPunctLucru.Value);
                //txtHiddenPunctLucruVechi.Value = txtHiddenPunctLucru.Value;
                objAngajat.CasaDeAsigurariId = int.Parse(txtHiddenCasaDeAsigurari.Value);
                objAngajat.TipAsiguratId = Convert.ToInt32(lstTipAsigurat.SelectedValue);
                objAngajat.MotivDeAngajareId = int.Parse(txtHiddenMotivDeAngajare.Value);
                objAngajat.TipDeAngajatId = int.Parse(txtHiddenTipDeAngajat.Value);
                objAngajat.AngajatorId = Convert.ToInt32(lstAngajator.SelectedValue);
                objAngajat.Marca = txtMarca.Text;
                objAngajat.Gid = txtGid.Text;
                objAngajat.ProgramLucru = Convert.ToByte(txtProgramLucru.Text);
                objAngajat.ModIncadrare = Convert.ToByte(lstModIncadrare.SelectedValue);
                objAngajat.TipFisaFiscala = Convert.ToByte(lstTipFisaFiscala.SelectedValue);

                #region vechime
                //Lungu Andreea - 03.06.2010 - am comentat pentru ca vechimea se afiseaza altfel
                //				if (txtAniVechimeMunca.Text!="")
                //					objAngajat.AniVechimeMunca = Convert.ToByte(txtAniVechimeMunca.Text);
                //				else
                //					objAngajat.AniVechimeMunca = 0;
                //				if  (txtLuniVechimeMunca.Text!="")
                //					objAngajat.LuniVechimeMunca = Convert.ToByte(txtLuniVechimeMunca.Text);
                //				else
                //					objAngajat.LuniVechimeMunca = 0;
                //				if (txtZileVechimeMunca.Text!="")
                //					objAngajat.ZileVechimeMunca = Convert.ToByte(txtZileVechimeMunca.Text);
                //				else
                //					objAngajat.ZileVechimeMunca = 0;

                //Lungu Andreea - 02.06.2010
                string dataDeLaText = txtSirDeLa.Value;
                string dataPanaLaText = txtSirPanaLa.Value;
                string idPerioade = txtSirIdPerioada.Value;
                string laSiemens = txtSirLaSiemens.Value;
                if (!idPerioade.Equals("[]"))
                {
                    dataDeLaText = dataDeLaText.Substring(1, dataDeLaText.Length - 2);
                    dataPanaLaText = dataPanaLaText.Substring(1, dataPanaLaText.Length - 2);
                    idPerioade = idPerioade.Substring(1, idPerioade.Length - 2);
                    laSiemens = laSiemens.Substring(1, laSiemens.Length - 2);
                }
                string[] sirDataDeLa = dataDeLaText.Split(',');
                string[] sirDataPanaLa = dataPanaLaText.Split(',');
                string[] sirIdPerioade = idPerioade.Split(',');
                string[] sirLaSiemens = laSiemens.Split(',');

                for (int i = 0; i < sirDataDeLa.Length; i++)
                {
                    sirDataDeLa[i] = sirDataDeLa[i].Substring(1, sirDataDeLa[i].Length - 2);
                    sirDataPanaLa[i] = sirDataPanaLa[i].Substring(1, sirDataPanaLa[i].Length - 2);
                }

                //verific ca datele sunt in formatul coresponzator
                DateTime[] perDataDeLa = new DateTime[sirDataDeLa.Length];
                DateTime[] perDataPanaLa = new DateTime[sirDataPanaLa.Length];
                string textEroareVechime = "";
                try
                {
                    for (int i = 0; i < sirDataDeLa.Length; i++)
                    {
                        if (!sirDataDeLa[i].Equals(""))
                        {
                            DateTime dataDeLa = SiemensTM.utils.Utilities.ConvertText2DateTime(sirDataDeLa[i]);
                            perDataDeLa[i] = dataDeLa;
                            DateTime dataPanaLa = SiemensTM.utils.Utilities.ConvertText2DateTime(sirDataPanaLa[i]);
                            perDataPanaLa[i] = dataPanaLa;
                        }
                    }
                }
                catch (Exception exc)
                {
                    ErrHandler.MyErrHandler.WriteError("EditAngajatDateAngajare.aspx -  angID: " + objAngajat.AngajatId + " - introducere perioade vechime - dataDeLa: " + dataDeLaText + " - dataPanaLa: " + dataPanaLaText + " - idPerioade: " + idPerioade);
                    textEroareVechime = "Datele introduse pentru cartea de munca nu sunt in formatul coresponzator.";
                }

                //verific ca perioadele sa nu se intersecteze
                //				for (int i=0; i<perDataDeLa.Length; i++)
                //				{
                //					for (int j=0; j<perDataDeLa.Length; j++)
                //						if ((i!=j) && ((perDataDeLa[j]<perDataDeLa[i] && perDataDeLa[i]<perDataPanaLa[j]) || (perDataDeLa[j]<perDataDeLa[i] && perDataPanaLa[i]<perDataPanaLa[j])))
                //							textEroareVechime += "Perioadele introduse pentru cartea de munca se intersecteaza.";
                //				}


                if (textEroareVechime.Equals(""))
                {
                    //sterg toate perioadele din cartea de munca a unui angajat
                    Salaries.Business.CarteDeMunca carteM = new Salaries.Business.CarteDeMunca();
                    carteM.IdAngajat = objAngajat.AngajatId;
                    //					carteM.DeleteToatePerioadeleAngajat();
                    bool existaPerioade = false;
                    for (int i = 0; i < sirDataDeLa.Length; i++)
                    {
                        //if (!sirDataDeLa[i].Equals(""))
                        if (!sirIdPerioade[i].Equals(""))
                        {
                            if ((!sirIdPerioade[i].Equals("0")) && (sirDataDeLa[i].Equals("")) && (sirDataDeLa[i].Equals("")))
                            {
                                if (!sirIdPerioade[i].Equals("[]"))
                                {
                                    carteM.IdPerioada = Int32.Parse(sirIdPerioade[i]);
                                    carteM.DeletePerioadaCarteDeMunca();
                                }
                            }
                            else
                            {
                                existaPerioade = true;
                                DateTime dataDeLa = SiemensTM.utils.Utilities.ConvertText2DateTime(sirDataDeLa[i]);
                                DateTime dataPanaLa = SiemensTM.utils.Utilities.ConvertText2DateTime(sirDataPanaLa[i]);
                                int idPerioada = Int32.Parse(sirIdPerioade[i]);
                                //nu prea cred ca imi trebuie id-ul
                                carteM.IdAngajat = objAngajat.AngajatId;
                                carteM.IdPerioada = idPerioada;
                                carteM.DataDeLa = dataDeLa;
                                carteM.DataPanaLa = dataPanaLa;
                                carteM.LaSiemens = sirLaSiemens[i].Equals("1") ? true : false;
                                if (idPerioada != 0)
                                    carteM.UpdatePerioadaCarteDeMunca();
                                else
                                    carteM.InsertPerioadaCarteDeMunca();
                            }

                        }
                    }
                    if (!existaPerioade)
                        carteM.DeleteToatePerioadeleAngajat();
                    VariabileJavascriptVechime();
                    CalculeazaVechimi();
                }
                else
                {
                    Response.Write("<script>alert('Angajatul nu a fost modificat." + textEroareVechime + "');</script>");
                    return;
                }
                #endregion

                objAngajat.CMDataEmiterii = Utilities.ConvertText2DateTime(txtCMDataEmiterii.Text);
                objAngajat.CMEmitent = txtCMEmitent.Text;
                objAngajat.CMNrInregITM = txtCMNrInregITM.Text;
                objAngajat.CMNumar = txtCMNumar.Text;
                objAngajat.CMSerie = txtCMSerie.Text;
                objAngajat.PerioadaDeterminata = (lstPerAngajarii.SelectedIndex == 0);
                objAngajat.DataDeLa = Utilities.ConvertText2DateTime(txtDataDeLa.Text);
                if (objAngajat.PerioadaDeterminata)
                {
                    objAngajat.DataPanaLa = Utilities.ConvertText2DateTime(txtDataPanaLa.Text);
                }
                else
                {
                    objAngajat.DataPanaLa = DateTime.MinValue;
                }
                //perioada de proba
                objAngajat.PerProba = txtPerProba.Text;

                if (lstSef.Items.Count > 0)
                    objAngajat.SefId = int.Parse(lstSef.SelectedValue.ToString());
                else
                    objAngajat.SefId = -1;
                objAngajat.NrContractMunca = txtNrContractMunca.Text;
                objAngajat.DataInregContractMunca = Utilities.ConvertText2DateTime(txtDataInreg.Text);
                objAngajat.SalariuBaza = decimal.Parse(txtSalariu.Text);
                objAngajat.IndemnizatieConducere = decimal.Parse(txtIndemnizatie.Text);
                if (txtSporuri.Text == "")
                    txtSporuri.Text = "0";
                objAngajat.Sporuri = decimal.Parse(txtSporuri.Text);
                if (txtAlteAdaosuri.Text == "")
                    txtAlteAdaosuri.Text = "0";
                objAngajat.AlteAdaosuri = decimal.Parse(txtAlteAdaosuri.Text);
                if (txtDataPlanificareMajorare.Text != "")
                {
                    if (txtSumaMajorare.Text == "")
                        txtSumaMajorare.Text = "0";
                    objAngajat.SumaMajorare = decimal.Parse(txtSumaMajorare.Text);
                    objAngajat.DataMajorare = Utilities.ConvertText2DateTime(txtDataPlanificareMajorare.Text);
                }

                objAngajat.NrZileCOAn = int.Parse(txtNrZileCOAn.Text);
                //numar zile de concediu suplimentar pe an
                objAngajat.NrZileCOSupl = int.Parse(txtNrZileCOSupl.Text);
                //alte date ale contractului individual de munca
                objAngajat.AlteClauzeCIM = txtAlteClauzeCIM.Text;
                if (lstCategorie.Items.Count > 0)
                    objAngajat.CategorieId = int.Parse(lstCategorie.SelectedValue);
                else
                    objAngajat.CategorieId = -1;

                objAngajat.TelMunca = this.txtTelMunca.Text;
                objAngajat.Email = this.txtEmail.Text;

                //echipament individual de protectie
                if (drpEchIndProtectie.SelectedItem.Text == "DA")
                    objAngajat.EchIndProtectie = txtEchIndProtectie.Text;
                else
                    objAngajat.EchIndProtectie = drpEchIndProtectie.SelectedItem.Text;
                //echipament individual de lucru
                if (drpEchIndLucru.SelectedItem.Text == "DA")
                    objAngajat.EchIndLucru = txtEchIndLucru.Text;
                else
                    objAngajat.EchIndLucru = drpEchIndLucru.SelectedItem.Text;
                //materiale igienico sanitare
                if (drpMatIgiSan.SelectedItem.Text == "DA")
                    objAngajat.MatIgiSan = txtMatIgiSan.Text;
                else
                    objAngajat.MatIgiSan = drpMatIgiSan.SelectedItem.Text;
                //alimentatie de protectie
                if (drpAlimProtectie.SelectedItem.Text == "DA")
                    objAngajat.AlimProtectie = txtAlimProtectie.Text;
                else
                    objAngajat.AlimProtectie = drpAlimProtectie.SelectedItem.Text;
                //alte drepturi si obligatii privind sanatatea in munca
                if (drpAlteDrSiObl.SelectedItem.Text == "DA")
                    objAngajat.AlteDrSiObl = txtAlteDrSiObl.Text;
                else
                    objAngajat.AlteDrSiObl = drpAlteDrSiObl.SelectedItem.Text;
                //alte clauze ale contractului individual de munca
                objAngajat.AlteClauzeCIM = txtAlteClauzeCIM.Text;

                //Dovlecel Vlad
                Salaries.Business.Luni l = new Salaries.Business.Luni(objAngajat.AngajatorId);
                Salaries.Data.LunaData ld = l.GetLunaActiva();
                ld.Data = new DateTime(ld.Data.Year, ld.Data.Month, DateTime.DaysInMonth(ld.Data.Year, ld.Data.Month), 23, 59, 59);
                bool verifIntrod = true;
                string textEroare = "";

                if (objAngajat.PerioadaDeterminata && objAngajat.DataDeLa >= objAngajat.DataPanaLa)
                {
                    textEroare = " Data angajarii trebuie sa fie mai mica decat data expirarii contractului de munca!";
                    verifIntrod = false;
                }

                //Lichidat
                objAngajat.IsLichidat = lichidatCheck.Checked;
                //Daca angajatul nu este lichidat atunci nu se poate lichida doar prin simpla check-uire - trebuie sa mearga in Pontaj\Lichidare Angajat
                if (!objAngajat.IsLichidat)
                {
                    lichidatCheck.Enabled = false;
                }

                //Pensionat
                objAngajat.IsPensionat = pensionatCheck.Checked;
                if (rblPMP.SelectedValue == "1")
                {
                    objAngajat.PMP = true;
                }
                else
                {
                    objAngajat.PMP = false;
                }
                if (rblAZM.SelectedValue == "1")
                {
                    objAngajat.AZM = true;
                }
                else
                {
                    objAngajat.AZM = false;
                }
                if (rblRetinereSanatate.SelectedValue == "1")
                {
                    objAngajat.RetinereSanatate = true;
                }
                else
                {
                    objAngajat.RetinereSanatate = false;
                }
                if (rblRetinereCAS.SelectedValue == "1")
                {
                    objAngajat.RetinereCAS = true;
                }
                else
                {
                    objAngajat.RetinereCAS = false;
                }
                if (rblRetinereSomaj.SelectedValue == "1")
                {
                    objAngajat.RetinereSomaj = true;
                }
                else
                {
                    objAngajat.RetinereSomaj = false;
                }
                objAngajat.Birou = txtBirou.Text;

                // added by Anca:
                // NIF-ul nu poate avea valoarea NULL
                objAngajat.NIF = "";

                //se verifica datele unui angajat
                int rezultatVerificareDate = objAngajat.CheckDateAngajatForUpdate();
                //nu se pot specifica doi angajati cu aceeasi marca
                if (rezultatVerificareDate == 1)
                {
                    textEroare += " Nu se pot introduce doi angajati cu aceeasi marca!";
                }
                //nu se pot specifica doi agajati cu acelasi gid
                if (rezultatVerificareDate == 2)
                {
                    textEroare += " Nu se pot introduce doi angajati cu acelasi GID!";
                }
                if ((verifIntrod) && (textEroare == ""))
                {
                    objAngajat.UpdateAngajat();

                    //dupa ce se actualizeaza un angajat trebuie actualizate si controalele corespunzatoare lui
                    IncarcaDrepturiObligatii();
                    //this.VechimeInMunca();
                    CalculeazaVechimi();

                    SiemensTM.Classes.IntervaleAngajat ia = new SiemensTM.Classes.IntervaleAngajat(objAngajat.AngajatId);
                    //Modified: Ionel Popa
                    //Description: Stergem din pontaj zilele care nu sunt in perioada contractului din luna curenta
                    Salaries.Data.LunaData firstDay = l.GetLunaActiva();
                    if (firstDay.Data < objAngajat.DataDeLa)
                    {
                        ia.DeleteIntervaleVizibileAngajatPerioada(firstDay.Data, objAngajat.DataDeLa);
                    }

                    if (!objAngajat.PerioadaDeterminata)
                    {
                        ia.InitializeOreLucrateLunaAngajat(ld.Data, objAngajat.DataDeLa, System.DBNull.Value);
                        //InitializareLunaAngajat( AngajatID );
                    }
                    else
                    {
                        //Modified: Ionel Popa
                        //Description: In cazul in care se modifica DataPanaLa intervalele pentru angajat se modifica in functie de DataLichidare
                        if (objAngajat.IsLichidat)
                        {
                            ia.InitializeOreLucrateLunaAngajat(ld.Data, objAngajat.DataDeLa, objAngajat.DataLichidare);
                        }
                        else
                        {
                            ia.InitializeOreLucrateLunaAngajat(ld.Data, objAngajat.DataDeLa, System.DBNull.Value);
                        }
                    }

                    bool notCAS = txtHiddenExistaDateCAS.Value == "1";
                    //daca se specifica valori pentru veniturile brute pe ultimele sase luni
                    if (!notCAS)
                    {
                        //se valideaza aceste date
                        this.LoadCheckCAS();
                        //daca se face update
                        if (valUpdate)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                objAngajat.UpdateCAS(6 - i, tabCAS[i]);
                            }
                        }
                        else
                        {
                            //daca se face adaugare de venituri brute
                            if (valInsert)
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    objAngajat.InsertCAS(6 - i, tabCAS[i]);
                                }
                            }
                        }

                        //se genereaza situatia lunara a angajatului
                        SiemensTM.Classes.SituatieAngajat situatieAngajat = new SiemensTM.Classes.SituatieAngajat(objAngajat.AngajatId);
                        situatieAngajat.GenerareSituatieLunaraAngajat();
                    }
                    //daca nu se specifica valori pentru datele veniturilor brute
                    else
                    {
                        //se sterg valorile veniturilor brute daca acestea exista
                        objAngajat.DeleteCAS();
                        SiemensTM.Classes.SituatieAngajat situatieAngajat = new SiemensTM.Classes.SituatieAngajat(objAngajat.AngajatId);
                        situatieAngajat.GenerareSituatieLunaraAngajat();
                    }
                    txtHiddenPunctLucruVechi.Value = txtHiddenPunctLucru.Value;
                }
                else
                {
                    Response.Write("<script>alert('Angajatul nu a fost modificat." + textEroare + "');</script>");
                }
            }
            catch (Exception ex)
            {
                litError.Text = "The following error occurred: <br>";
                litError.Text += ex.Message;
                InitCAS();
            }

            //InitCAS();
        }
        #endregion

        #region InsertAngajatInEdoc
        /// <summary>
        /// Adauga un user in Edoc
        /// </summary>
        /// <param name="mark">Marca angajatului</param>
        /// <param name="name">Numele angajatului</param>
        /// <param name="email">Adresa de email a angajatului</param>
        /// <param name="telephone">Nr de telefon</param>
        /// <param name="personal_data">Date personale</param>
        /// <param name="user_name">Numele utilizatorului</param>
        /// <param name="password">Parola utilizatorului</param>
        /// <param name="sid"></param>
        /// <param name="deleted">Poate fi sters sau nu</param>
        private void InsertAngajatInEdoc(string mark,
            string name,
            string email,
            string telephone,
            string personal_data,
            string user_name,
            string password,
            string sid,
            bool deleted)
        {
            edoc.User user = new SiemensHR.edoc.User();
            user.InsertUpdateUser(mark, name, email, telephone, personal_data, user_name,
                password, sid, deleted);
        }
        #endregion

        #region VechimeInMunca
        /// <summary>
        /// Procedura calculeaza vechimea in munca a angajatului
        /// </summary>
        //		private void VechimeInMunca()
        //		{
        //			DataTable dt=objAngajat.GetVechimeInMuncaAngajatorCurr().Tables[0];
        //			this.lAniVechimeCurr.Text=dt.Rows[0][0].ToString()+" ani,";
        //			this.lLuniVechimeCurr.Text=dt.Rows[0][1].ToString()+" luni,";
        //			this.lZileVechimeCurr.Text=dt.Rows[0][2].ToString()+" zile";
        //
        //			dt=objAngajat.GetVechimeInMuncaPerTotal().Tables[0];
        //			this.lAniVechime.Text=dt.Rows[0][0].ToString()+" ani,";
        //			this.lLuniVechime.Text=dt.Rows[0][1].ToString()+" luni,";
        //			this.lZileVechime.Text=dt.Rows[0][2].ToString()+" zile";

        //			SiemensHR.EditTasks.CarteDeMunca carteMuncaUC = (SiemensHR.EditTasks.CarteDeMunca) LoadControl("CarteDeMunca.ascx");
        //			carteMuncaUC.AngajatID = objAngajat.AngajatId;
        //			td_vechime.Controls.Add(carteMuncaUC);
        //		}
        #endregion

        #region InitCAS
        /// <summary>
        /// Procedura initializeaza datele pentru CAS
        /// </summary>
        private void InitCAS()
        {
            try
            {
                //se selecteaza valorile veniturilor brute ale unui angajat
                dropDataCAS.DataSource = objAngajat.GetValoriCAS();
                dropDataCAS.DataTextField = "ID_Luna";
                dropDataCAS.DataValueField = "ValCAS";
                dropDataCAS.DataBind();

                //se completeaza controalele cu aceste valori
                txtCAS1.Text = dropDataCAS.Items[0].Value.ToString();
                txtCAS2.Text = dropDataCAS.Items[1].Value.ToString();
                txtCAS3.Text = dropDataCAS.Items[2].Value.ToString();
                txtCAS4.Text = dropDataCAS.Items[3].Value.ToString();
                txtCAS5.Text = dropDataCAS.Items[4].Value.ToString();
                txtCAS6.Text = dropDataCAS.Items[5].Value.ToString();

                if (eroareLoadCheckCAS)
                {
                    clearCAS();
                }

                valInsert = false;
                valUpdate = false;

                //daca angajatul nu are vanituri asociate, se va putea face o adaugare de venituri brute
                if (txtCAS1.Text.Length == 0)
                {
                    valInsert = true;
                    LoadMonthForInsert();
                    radioDa.Checked = true;
                }
                //altfel se va putea face actualizarea acestora
                else
                {
                    valUpdate = true;
                    radioNu.Checked = true;
                }
            }
            //daca nu exista valori pentru angajat
            catch (Exception)
            {
                //se va putea face adaugare de valori ale veniturilor brute
                clearCAS();
                valUpdate = false;
                valInsert = true;
                LoadMonthForInsert();
                radioNu.Checked = false;
                radioDa.Checked = true;
            }
        }
        #endregion

        #region clearCAS
        /// <summary>
        /// Procedura goleste continutul controalele pentru specificarea valorilor veniturilor brute anterioare angajarii
        /// </summary>
        private void clearCAS()
        {
            txtCAS1.Text = "";
            txtCAS2.Text = "";
            txtCAS3.Text = "";
            txtCAS4.Text = "";
            txtCAS5.Text = "";
            txtCAS6.Text = "";
        }
        #endregion

        #region LoadCheckCAS
        /// <summary>
        /// Procedura varifica daca valorile veniturilor brute specificare sunt corecte. 
        /// Daca nu sunt corecte este afisat un mesaj de avertizare.
        /// </summary>
        private void LoadCheckCAS()
        {
            try
            {
                tabCAS[0] = Convert.ToDouble(txtCAS1.Text);
                tabCAS[1] = Convert.ToDouble(txtCAS2.Text);
                tabCAS[2] = Convert.ToDouble(txtCAS3.Text);
                tabCAS[3] = Convert.ToDouble(txtCAS4.Text);
                tabCAS[4] = Convert.ToDouble(txtCAS5.Text);
                tabCAS[5] = Convert.ToDouble(txtCAS6.Text);
            }
            catch (Exception)
            {
                valInsert = false;
                valUpdate = false;
                eroareLoadCheckCAS = true;
                clearCAS();
                if (this.radioNu.Checked)
                {
                    Response.Write("<script> alert('Va rugam introduceti valorile veniturilor brute ale angajatului pe ultimele sase luni!'); </script>");
                }
            }
        }
        #endregion

        #region LoadMonthForInsert
        /// <summary>
        /// Procedura seteaza date angajarii
        /// </summary>
        private void LoadMonthForInsert()
        {
            DateTime dataAngajarii = objAngajat.DataDeLa;
        }
        #endregion

        #region GetLunaAnName
        /// <summary>
        /// Procedura creaza un string care contine o anumita data
        /// </summary>
        /// <param name="s">Data specificata</param>
        /// <returns>Returneaza data sub forma de string</returns>
        private String GetLunaAnName(DateTime s)
        {
            String luna = (s.Month == 1 ? "Ianuarie" : s.Month == 2 ? "Februarie" : s.Month == 3 ? "Martie" : s.Month == 4 ? "Aprilie" : s.Month == 5 ? "Mai" : s.Month == 6 ? "Iunie" : s.Month == 7 ? "Iulie" : s.Month == 8 ? "August" : s.Month == 9 ? "Septembrie" : s.Month == 10 ? "Octombrie" : s.Month == 11 ? "Noiembrie" : s.Month == 12 ? "Decembrie" : "");
            return luna + " " + s.Year.ToString();
        }
        #endregion

        #region GetSirAngajatorPunctLucru
        /// <summary>
        /// Proceudra creaza sirul de puncte de lucru ale angajatorului
        /// </summary>
        /// <returns>Returneaza un string care contine aceste puncete de lucru</returns>
        private string GetSirAngajatorPunctLucru()
        {
            // Punctele de lucru ale angajatorilor.
            Salaries.Business.AdminPunctLucru puncteLucru = new Salaries.Business.AdminPunctLucru();
            DataSet dsPuncteDeLucru = puncteLucru.GetPuncteDeLucruAngajatori();

            string sirAngajatorPunctLucru = "";
            string sirAngajator = "[";
            string sirPunctLucru = "[";
            string sirNume = "[";

            for (int i = 0; i < dsPuncteDeLucru.Tables[0].Rows.Count - 1; i++)
            {
                sirAngajator += dsPuncteDeLucru.Tables[0].Rows[i]["AngajatorID"].ToString() + ", ";
                sirPunctLucru += dsPuncteDeLucru.Tables[0].Rows[i]["PunctLucruID"].ToString() + ", ";
                sirNume += "'" + dsPuncteDeLucru.Tables[0].Rows[i]["Nume"].ToString().TrimEnd() + "', ";
            }
            if (dsPuncteDeLucru.Tables[0].Rows.Count > 0)
            {
                sirAngajator += dsPuncteDeLucru.Tables[0].Rows[dsPuncteDeLucru.Tables[0].Rows.Count - 1]["AngajatorID"].ToString() + "]";
                sirPunctLucru += dsPuncteDeLucru.Tables[0].Rows[dsPuncteDeLucru.Tables[0].Rows.Count - 1]["PunctLucruID"].ToString() + "]";
                sirNume += "'" + dsPuncteDeLucru.Tables[0].Rows[dsPuncteDeLucru.Tables[0].Rows.Count - 1]["Nume"].ToString().TrimEnd() + "']";

                sirAngajatorPunctLucru = "[" + sirAngajator + "," + sirPunctLucru + "," + sirNume + "]";
            }
            else
            {
                sirAngajatorPunctLucru = "[[],[]]";
            }

            return sirAngajatorPunctLucru;
        }
        #endregion

        #region GetSirPuncteLucru
        /// <summary>
        /// SirPuncteLucru()
        /// </summary>
        /// <returns>Returneaza sirul punctelor de lucru in care e specificata si casa de asigurari implicita</returns>
        //Lungu Andreea 26.05.2008 
        //Descriere: Acest sir este creat ca atunci cand se selecteaza un punct de lucru sa se selecteze automat 
        //           si casa de asigurari care a fost setata ca fiind implicita ramanand totusi si posibilitatea 
        //           de a alege si alta casa de asigurari
        private string GetSirPuncteLucru()
        {
            string sirPuncte = "[";
            string sirPuncteUnic = "";

            Salaries.Business.AdminPunctLucru objAdminPunctLucru = new Salaries.Business.AdminPunctLucru();
            objAdminPunctLucru.AngajatorId = Convert.ToInt32(lstAngajator.SelectedValue, 10);
            DataSet ds = objAdminPunctLucru.LoadInfoPunctLucruAngajatori();

            for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                sirPuncteUnic = "[" + dr["PunctLucruId"].ToString() + ",'" + dr["Nume"].ToString() + "'," + dr["IdCasaDeAsigImplicita"].ToString() + ",'" + dr["Denumire"].ToString() + "']";
                sirPuncte += sirPuncteUnic + ",";
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1];
                sirPuncteUnic = "[" + dr["PunctLucruId"].ToString() + ",'" + dr["Nume"].ToString() + "'," + dr["IdCasaDeAsigImplicita"].ToString() + ",'" + dr["Denumire"].ToString() + "']";
                sirPuncte += sirPuncteUnic + "]";
            }
            else
            {
                sirPuncte = "[]";
            }
            return sirPuncte;
        }
        #endregion

        #region vechime munca
        private void VariabileJavascriptVechime()
        {
            //string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
            Response.Write("<script> var tabelPerioadeClient = '" + tabelPerioade.ClientID + "'; </script>");

            string[] siruri = GetSiruriPerioade();
            string sirIdPerioada = siruri[0];
            string sirDataDeLa = siruri[1];
            string sirDataPanaLa = siruri[2];
            string sirLaSiemens = siruri[3];
            //Response.Write(script_text);

            Response.Write("<script> var tdPerioadeID='" + tdPerioade.ClientID + "'</script>");
            Response.Write("<script>var rbDaID = '" + radioButtonDa.ClientID + "'</script>");
            Response.Write("<script>var rbNuID = '" + radioButtonNu.ClientID + "'</script>");

            //client id-urile pentru listbox-uri, dropdown si textbox-uri
            Response.Write("<script>var lAniAngAnteriorID = '" + lAniAngAnterior.ClientID + "'</script>");
            Response.Write("<script>var lLuniAngAnteriorID = '" + lLuniAngAnterior.ClientID + "'</script>");
            Response.Write("<script>var lZileAngAnteriorID = '" + lZileAngAnterior.ClientID + "'</script>");

            Response.Write("<script>var lAniAngCurentID = '" + lAniAngCurent.ClientID + "'</script>");
            Response.Write("<script>var lLuniAngCurentID = '" + lLuniAngCurent.ClientID + "'</script>");
            Response.Write("<script>var lZileAngCurentID = '" + lZileAngCurent.ClientID + "'</script>");

            Response.Write("<script>var lAniAnteriorID = '" + lAniAnterior.ClientID + "'</script>");
            Response.Write("<script>var lLuniAnteriorID = '" + lLuniAnterior.ClientID + "'</script>");
            Response.Write("<script>var lZileAnteriorID = '" + lZileAnterior.ClientID + "'</script>");

            Response.Write("<script>var lAniIntrerupereID = '" + lAniIntrerupere.ClientID + "'</script>");
            Response.Write("<script>var lLuniIntrerupereID = '" + lLuniIntrerupere.ClientID + "'</script>");
            Response.Write("<script>var lZileIntrerupereID = '" + lZileIntrerupere.ClientID + "'</script>");

            Response.Write("<script>var lAniTotalID = '" + lAniTotal.ClientID + "'</script>");
            Response.Write("<script>var lLuniTotalID = '" + lLuniTotal.ClientID + "'</script>");
            Response.Write("<script>var lZileTotalID = '" + lZileTotal.ClientID + "'</script>");

            Response.Write("<script>var txtSirDataDeLaClient = '" + txtSirDeLa.ClientID + "';</script>");
            Response.Write("<script>var txtSirDataPanaLaClient = '" + txtSirPanaLa.ClientID + "';</script>");
            Response.Write("<script>var txtSirIdPerioadaClient = '" + txtSirIdPerioada.ClientID + "';</script>");
            Response.Write("<script>var txtSirLaSiemensClient = '" + txtSirLaSiemens.ClientID + "';</script>");

            txtSirDeLa.Value = sirDataDeLa;
            txtSirPanaLa.Value = sirDataPanaLa;
            txtSirIdPerioada.Value = sirIdPerioada;
            txtSirLaSiemens.Value = sirLaSiemens;

            Response.Write("<script>var sirDataDeLaClient = " + sirDataDeLa + ";</script>");
            Response.Write("<script>var sirDataPanaLaClient = " + sirDataPanaLa + ";</script>");
            Response.Write("<script>var sirIdPerioadaClient = " + sirIdPerioada + ";</script>");
            Response.Write("<script>var sirLaSiemensClient = " + sirLaSiemens + ";</script>");
        }

        /// <summary>
        /// idPerioada, dataDela, dataPanaLa
        /// </summary>
        /// <returns> Returneaza un sir de stringuri.</returns>
        private string[] GetSiruriPerioade()
        {
            string sirDataDeLa = "[";
            string sirDataPanaLa = "[";
            string sirIdPerioada = "[";
            string sirLaSiemens = "[";

            //aduc din baza de date datasetul ce contine toate perioadele din cartea de munca a angajatului
            Salaries.Business.CarteDeMunca perioadeCM = new Salaries.Business.CarteDeMunca();
            perioadeCM.IdAngajat = objAngajat.AngajatId;
            DataSet ds = perioadeCM.LoadCarteDeMuncaAngajat();
            for (int i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                //eventual sa transform data intr-un anumit format 
                DateTime dataDeLa = (DateTime)dr["DataDeLa"];
                DateTime dataPanaLa = (DateTime)dr["DataPanaLa"];
                sirDataDeLa += "'" + SiemensHR.Classes.Utilities.ConvertDateTime2Text(dataDeLa) + "',";
                sirDataPanaLa += "'" + SiemensHR.Classes.Utilities.ConvertDateTime2Text(dataPanaLa) + "',";
                sirIdPerioada += dr["ID"].ToString() + ",";
                bool laSiemens = (bool)dr["LaSiemens"];
                sirLaSiemens += (laSiemens == true) ? "1," : "0,";
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime dataDeLa = (DateTime)ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["DataDeLa"];
                DateTime dataPanaLa = (DateTime)ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["DataPanaLa"];
                sirDataDeLa += "'" + SiemensHR.Classes.Utilities.ConvertDateTime2Text(dataDeLa) + "']";
                sirDataPanaLa += "'" + SiemensHR.Classes.Utilities.ConvertDateTime2Text(dataPanaLa) + "']";
                sirIdPerioada += ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["ID"].ToString() + "]";
                bool laSiemens = (bool)ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["LaSiemens"];
                sirLaSiemens += (laSiemens == true) ? "1]" : "0]";
            }
            else
            {
                sirDataDeLa = "[]";
                sirDataPanaLa = "[]";
                sirIdPerioada = "[]";
                sirLaSiemens = "[]";
            }

            string[] siruri = new string[4];
            siruri[0] = sirIdPerioada;
            siruri[1] = sirDataDeLa;
            siruri[2] = sirDataPanaLa;
            siruri[3] = sirLaSiemens;

            return siruri;
        }

        //Lungu Andreea - 02.01.2010
        private void CalculeazaVechimi()
        {
            //aduc din baza de date datasetul ce contine toate perioadele din cartea de munca a angajatului
            Salaries.Business.CarteDeMunca perioadeCM = new Salaries.Business.CarteDeMunca();
            perioadeCM.IdAngajat = objAngajat.AngajatId;
            DataSet ds = perioadeCM.LoadCarteDeMuncaAngajat();

            Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
            ang.AngajatId = objAngajat.AngajatId;
            ang.LoadAngajat();

            DateTime dataPanaLaUltima = ang.DataDeLa;

            //vechime anterioara totala - suma tuturor perioadelor
            int aniAngAnterior = 0;
            int luniAngAnterior = 0;
            int zileAngAnterior = 0;

            int aniAnteriorTotal = 0;
            int luniAnteriorTotal = 0;
            int zileAnteriorTotal = 0;

            int nr = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                nr++;
                DateTime dataDeLa = (DateTime)dr["DataDeLa"];
                DateTime dataPanaLa = (DateTime)dr["DataPanaLa"];
                int[] diferente = GetDiferentaDate(dataDeLa, dataPanaLa);

                aniAnteriorTotal += diferente[0];
                luniAnteriorTotal += diferente[1];
                zileAnteriorTotal += diferente[2];

                if (nr == ds.Tables[0].Rows.Count)
                {
                    //vechime la angajatorul anterior - ultima inregistrare din carte de munca
                    aniAngAnterior = diferente[0];
                    luniAngAnterior = diferente[1];
                    zileAngAnterior = diferente[2];

                    dataPanaLaUltima = dataPanaLa;
                }
            }
            lAniAngAnterior.Text = aniAngAnterior.ToString() + " ani";
            lLuniAngAnterior.Text = luniAngAnterior.ToString() + " luni";
            lZileAngAnterior.Text = zileAngAnterior.ToString() + " zile";
            lTotalAngAnterior.Text = SiemensTM.utils.Utilities.TransformIntoTwoDigits(aniAngAnterior) + " / " + SiemensTM.utils.Utilities.TransformIntoTwoDigits(luniAngAnterior) + " / " + SiemensTM.utils.Utilities.TransformIntoTwoDigits(zileAngAnterior);

            //calcul vechime intrerupere
            int aniIntrerupere = 0;
            int luniIntrerupere = 0;
            int zileIntrerupere = 0;
            if (ds.Tables[0].Rows.Count != 0)
            {
                int[] diferenteIntrerupere = GetDiferentaDate(dataPanaLaUltima, ang.DataDeLa);
                aniIntrerupere = diferenteIntrerupere[0];
                luniIntrerupere = diferenteIntrerupere[1];
                zileIntrerupere = diferenteIntrerupere[2];
            }
            lAniIntrerupere.Text = aniIntrerupere.ToString() + " ani";
            lLuniIntrerupere.Text = luniIntrerupere.ToString() + " luni";
            lZileIntrerupere.Text = zileIntrerupere.ToString() + " zile";
            lTotalIntrerupere.Text = SiemensTM.utils.Utilities.TransformIntoTwoDigits(aniIntrerupere) + " / " + SiemensTM.utils.Utilities.TransformIntoTwoDigits(luniIntrerupere) + " / " + SiemensTM.utils.Utilities.TransformIntoTwoDigits(zileIntrerupere);

            //vechime la angajatorul curent
            int aniCurent = 0;
            int luniCurent = 0;
            int zileCurent = 0;
            DateTime dataFinal = DateTime.Today;
            if (ang.DataPanaLa.Year != 1)
                dataFinal = ang.DataPanaLa;
            if (DateTime.Now < dataFinal)
                dataFinal = DateTime.Now;
            int[] diferenteCurent = GetDiferentaDate(ang.DataDeLa, dataFinal);
            aniCurent = diferenteCurent[0];
            luniCurent = diferenteCurent[1];
            zileCurent = diferenteCurent[2];
            lAniAngCurent.Text = aniCurent.ToString() + " ani";
            lLuniAngCurent.Text = luniCurent.ToString() + " luni";
            lZileAngCurent.Text = zileCurent.ToString() + " zile";
            lTotalAngCurent.Text = SiemensTM.utils.Utilities.TransformIntoTwoDigits(aniCurent) + " / " + SiemensTM.utils.Utilities.TransformIntoTwoDigits(luniCurent) + " / " + SiemensTM.utils.Utilities.TransformIntoTwoDigits(zileCurent);

            //vechime totala in munca = vechime anterioara + vechime angajator curent
            int aniTotalInMunca = aniAnteriorTotal + aniCurent;
            int luniTotalInMunca = luniAnteriorTotal + luniCurent;
            int zileTotalInMunca = zileAnteriorTotal + zileCurent;

            AniLuniZile(ref aniTotalInMunca, ref luniTotalInMunca, ref zileTotalInMunca);
            lAniTotal.Text = aniTotalInMunca.ToString() + " ani";
            lLuniTotal.Text = luniTotalInMunca.ToString() + " luni";
            lZileTotal.Text = zileTotalInMunca.ToString() + " zile";
            lTotal.Text = SiemensTM.utils.Utilities.TransformIntoTwoDigits(aniTotalInMunca) + " / " + SiemensTM.utils.Utilities.TransformIntoTwoDigits(luniTotalInMunca) + " / " + SiemensTM.utils.Utilities.TransformIntoTwoDigits(zileTotalInMunca);

            AniLuniZile(ref aniAnteriorTotal, ref luniAnteriorTotal, ref zileAnteriorTotal);
            lAniAnterior.Text = aniAnteriorTotal.ToString() + " ani";
            lLuniAnterior.Text = luniAnteriorTotal.ToString() + " luni";
            lZileAnterior.Text = zileAnteriorTotal.ToString() + " zile";
            lTotalAnterior.Text = SiemensTM.utils.Utilities.TransformIntoTwoDigits(aniAnteriorTotal) + " / " + SiemensTM.utils.Utilities.TransformIntoTwoDigits(luniAnteriorTotal) + " / " + SiemensTM.utils.Utilities.TransformIntoTwoDigits(zileAnteriorTotal);

            objAngajat.AniVechimeMunca = Convert.ToByte(aniAnteriorTotal);
            objAngajat.LuniVechimeMunca = Convert.ToByte(luniAnteriorTotal);
            objAngajat.ZileVechimeMunca = Convert.ToByte(zileAnteriorTotal);

        }
        //Lungu Andreea - 02.01.2010
        private int[] GetDiferentaDate(DateTime dataDeLa, DateTime dataPanaLa)
        {
            DateTime dataDeLaInitiala = dataDeLa;
            DateTime dataPanaLaInitiala = dataPanaLa;

            int difAni = dataPanaLa.Year - dataDeLa.Year;
            int difLuni = 0;
            int difZile = 0;

            DateTime dataNouaAni = dataDeLa.AddYears(difAni);
            if (dataNouaAni > dataPanaLa)
            {
                dataNouaAni = dataDeLa.AddYears(difAni - 1);
                difAni = difAni - 1;
            }
            DateTime dataNouaLuni = dataNouaAni;
            for (int i = 0; i < 12; i++)
            {
                difLuni = i;
                dataNouaLuni = dataNouaAni.AddMonths(i);
                if (dataNouaLuni > dataPanaLa)
                {
                    difLuni = i - 1;
                    dataNouaLuni = dataNouaAni.AddMonths(difLuni);
                    break;
                }
            }
            DateTime dataNouaZile = dataNouaLuni;
            for (int i = 0; i < 31; i++)
            {
                difZile = i;
                dataNouaZile = dataNouaLuni.AddDays(i);
                if (dataNouaZile > dataPanaLa)
                {
                    difZile = i - 1;
                    dataNouaZile = dataNouaLuni.AddDays(difZile);
                    break;
                }
            }

            int[] dif = new int[3];
            dif[0] = difAni;
            dif[1] = difLuni;
            dif[2] = difZile;

            return dif;
        }

        //Lungu Andreea - 03.06.2010
        //transform zilele in luni si lunile in ani
        private void AniLuniZile(ref int ani, ref int luni, ref int zile)
        {
            int a = zile / 61;
            if (a != 0)
            {
                luni += 2 * a;
                zile -= 61 * a;
            }
            if ((zile > 30) && (zile < 61))
            {
                luni += 1;
                zile -= 30;
            }

            int b = luni / 12;
            if (b != 0)
            {
                ani += b;
                luni -= b * 12;
            }
        }
        #endregion
    }
}
