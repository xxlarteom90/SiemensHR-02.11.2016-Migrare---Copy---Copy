/*
* Modificat:	Fratila Claudia
* Data:		31.10.2007
* Descriere:	A fost modificata clasa astfel incat sa existe doua moduri autentificare: Windows sau user si parola.
* 				Tipul de autentificare este stabilit in fisierul de configurare.
* 				0 - fara autnetificare
* 				1 - autentificare windows
* 				2 - autentificare user si parola
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Security.Principal;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.Recrutori
{
	/// <summary>
	/// Summary description for Recrutori.
	/// </summary>
	public class Recrutori : System.Web.UI.Page
	{
		#region Variabile
		protected System.Web.UI.WebControls.Table tableCautareRapida;
		protected System.Web.UI.WebControls.TextBox txtNumeSearch;
		protected System.Web.UI.WebControls.TextBox txtPrenumeSearch;
		protected System.Web.UI.WebControls.DropDownList lstNationalitateSearch;
		protected System.Web.UI.WebControls.DropDownList lstTaraOrigineSearch;
		protected System.Web.UI.WebControls.DropDownList lstStareCivilaSearch;
		protected System.Web.UI.WebControls.DropDownList lstCopiiSearch;
		protected System.Web.UI.WebControls.DropDownList lstSexSearch;
		protected System.Web.UI.WebControls.DropDownList lstTitulaturaSearch;
		protected System.Web.UI.WebControls.DropDownList lstStudiiSearch;
		protected System.Web.UI.WebControls.TextBox txtMarcaSearch;
		protected System.Web.UI.WebControls.DropDownList lstDepartamentSearch;
		protected System.Web.UI.WebControls.DropDownList lstFunctieSearch;
		protected System.Web.UI.WebControls.DropDownList lstModIncadrareSearch;
		protected System.Web.UI.WebControls.DropDownList lstIndemnizatieConducereSearch;
		protected System.Web.UI.WebControls.DropDownList lstScutitImpozitSearch;
		protected System.Web.UI.WebControls.DropDownList lstCategorieAngajatSearch;
		protected System.Web.UI.WebControls.DropDownList lstDeducereSearch;
		protected System.Web.UI.WebControls.Label lblCopii;
		protected System.Web.UI.WebControls.DropDownList lstDeducereCopiiSearch;
		protected System.Web.UI.WebControls.DropDownList lstContBancarExistentaSearch;
		protected System.Web.UI.WebControls.Label lblBanca;
		protected System.Web.UI.WebControls.DropDownList lstBancaSearch;
		protected System.Web.UI.WebControls.DropDownList lstTipDataAngajareSearch;
		protected System.Web.UI.WebControls.TextBox txtDataAngajatiSearch;
		protected System.Web.UI.WebControls.DropDownList lstLunaAngajatiSearch;
		protected System.Web.UI.WebControls.DropDownList lstAnAngajatiSearch;
		protected System.Web.UI.WebControls.TextBox txtDataStartAngajatiSearch;
		protected System.Web.UI.WebControls.TextBox txtDataEndAngajatiSearch;
		protected System.Web.UI.WebControls.DropDownList lstPerioadaDeterminataSearch;
		protected System.Web.UI.WebControls.Button btnAdvancedSearch;
		protected System.Web.UI.HtmlControls.HtmlTable tableCautareAvansataVisible;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdDataFixaSearch;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdLunaSearch;
		protected System.Web.UI.HtmlControls.HtmlTableCell tdIntervalSearch;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnCautareAvansata;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtTipCautareHidden;
		protected System.Security.Principal.WindowsPrincipal user;
		protected Salaries.Configuration.ModuleSettings settings;
		private const int anValInferioara = 80;
		private const int anValSuperioara = 30;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
			Utilities.CreateTableHeader(tableCautareRapida, "Cautare rapida", "../", "normal");

			if (!IsPostBack)
			{
				//se obtine tipul de autentificare la aplicatie
				string authentication = Salaries.Configuration.CryptographyClass.getSettingsWithoutDecode("authentication");
				
				//virtual path
				string path = Page.Request.FilePath;
				char separator = '/';
				string [] pathArr = path.Split(separator);
				int nr = pathArr.Length;

				//autentificare de tip windows
				if (authentication == "1")
				{
					//user-ul loginat
					user = new WindowsPrincipal(WindowsIdentity.GetCurrent());

					//user-ul loginat nu are dreptul sa acceseze aceasta pagina este redirectat catre o pagina care sa il instiinteze de acest lucru
					if(!Salaries.Business.Authentication.HasUserRightsOnPage(pathArr[nr-1],user))
					{
						ErrHandler.MyErrHandler.WriteError("Recrutori.aspx - autentificare windows fara drepturi - " + user.Identity.Name);
						Server.Transfer("../Unauthorized.aspx");
					}
				}
				//autentificare cu user si parola
				else
				{
					try
					{
						string nume = Session["Nume"].ToString();
						string parola = Session["Parola"].ToString();
						int angajatorId = int.Parse(Session["AngajatorId"].ToString());

						//user-ul loginat nu are dreptul sa acceseze aceasta pagina este redirectat catre o pagina care sa il instiinteze de acest lucru
						if(!Salaries.Business.Authentication.HasUserRightsOnPage(pathArr[nr-1], nume, parola, angajatorId))
						{
							ErrHandler.MyErrHandler.WriteError("Recrutori.aspx - autentificare user parola fara drepturi - " + nume + ", " + angajatorId);
							Server.Transfer("../Unauthorized.aspx");
						}
					}
					catch(Exception exc)
					{
						Response.Redirect("../index.aspx");
					}
				}
			}
		}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);

			ListItem myItem = new ListItem("","-1");
			lstDepartamentSearch.Items.Add(myItem);
			UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);
			utilDb.CreateDepartamenteSelectBox(0, 0, lstDepartamentSearch);

			BindNationalitateCombo();
			BindTaraDeOrigineCombo();
			BindTitulaturaCombo();
			BindStudiiCombo();
			BindFunctieCombo();
			BindCategorieCombo();
			BindBancaCombo();
			BindDataAngajareCombo();

			tableCautareAvansataVisible.Style.Add( "display", "none" );
			//nu e niciunul vizibil
			tdDataFixaSearch.Style.Add( "display", "none" );
			tdLunaSearch.Style.Add( "display", "none" );
			tdIntervalSearch.Style.Add( "display", "none" );

			lblBanca.Style.Add( "display", "none" );
			lstBancaSearch.Style.Add( "display", "none" );

			lblCopii.Style.Add( "display", "none" );
			lstDeducereCopiiSearch.Style.Add( "display", "none" );

			CreazaVarJavaScript();
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnAdvancedSearch.Click += new System.EventHandler(this.btnFastSearch_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region CreazaVarJavaScript
		/// <summary>
		/// Perocedura creaza variabilele JavaScript
		/// </summary>
		private void CreazaVarJavaScript()
		{   
			string sirCategorii = GetSirCategorii();
			Response.Write( "<script>var categorii = "+sirCategorii+";</script>");
			Response.Write( "<script>var lstCategoriiSearchClient = '"+lstCategorieAngajatSearch.ClientID+"';</script>");
			Response.Write( "<script>var lblBancaClient = '"+lblBanca.ClientID+"';</script>");
			Response.Write( "<script>var lstBancaSearchClient = '"+lstBancaSearch.ClientID+"';</script>");
			Response.Write( "<script>var lstContBancarExistentaSearchClient = '"+lstContBancarExistentaSearch.ClientID+"';</script>");

			Response.Write( "<script>var lblCopiiClient = '"+lblCopii.ClientID+"';</script>");
			Response.Write( "<script>var lstDeducereSearchClient = '"+lstDeducereSearch.ClientID+"';</script>");
			Response.Write( "<script>var lstDeducereCopiiSearchClient = '"+lstDeducereCopiiSearch.ClientID+"';</script>");

			Response.Write( "<script>var lstTipDataAngajareSearchClient = '"+lstTipDataAngajareSearch.ClientID+"';</script>");

			Response.Write( "<script>var txtTipCautareHiddenClient = '"+txtTipCautareHidden.ClientID+"';</script>");

			Response.Write( "<script>var tableCautareRapidaClient = '"+tableCautareRapida.ClientID+"';</script>");	
		}
		#endregion

		#region GetSirCategorii
		/// <summary>
		/// Procedura creaza sirul de categorii salariale ale angajatilor
		/// </summary>
		/// <returns>Returneaza un string care contine aceste date</returns>
		private string GetSirCategorii()
		{
			string sirCategorii = "";
			string sirCategoriiText = "[";
			string sirCategoriiValue = "[";
			string sirCategoriiScutireImpozit = "[";

			DataSet ds = (DataSet)lstCategorieAngajatSearch.DataSource;
			for( int i=0; i<ds.Tables[ 0 ].Rows.Count-1; i++ )
			{
				DataRow dr = ds.Tables[ 0 ].Rows[ i ];
				sirCategoriiText += "'"+dr[ "Denumire" ].ToString()+"', ";
				sirCategoriiValue += dr[ "CategorieID" ].ToString()+", ";
				sirCategoriiScutireImpozit += (bool)dr[ "ScutireImpozit" ] ? "1, " : "0, ";
			}
			if( ds.Tables[ 0 ].Rows.Count > 0 )
			{
				sirCategoriiText += "'"+ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "Denumire" ].ToString()+"']";
				sirCategoriiValue += ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "CategorieID" ].ToString()+"]";
				sirCategoriiScutireImpozit += (bool)ds.Tables[ 0 ].Rows[ ds.Tables[ 0 ].Rows.Count-1 ][ "ScutireImpozit" ] ? "1]" : "0]";
			
				sirCategorii = "["+sirCategoriiText+","+sirCategoriiValue+","+sirCategoriiScutireImpozit+"]";
			}
			else
			{
				sirCategorii = "[[],[],[]]";
			}

			return sirCategorii;
		}
		#endregion

		#region btnFastSearch_Click
		/// <summary>
		/// Porneste motorul de cautare rapida
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnFastSearch_Click(object sender, System.EventArgs e)
		{
			Session["txtTipCautareHidden"] = txtTipCautareHidden.Value;
			
			Session["txtNumeSearch"] = (txtNumeSearch.Text=="") ? "-1" : txtNumeSearch.Text;
			Session["txtPrenumeSearch"]= (txtPrenumeSearch.Text=="") ? "-1" : txtPrenumeSearch.Text;

			Session["lstNationalitateSearch"] = lstNationalitateSearch.SelectedValue;
			Session["lstTaraOrigineSearch"] = lstTaraOrigineSearch.SelectedValue;//tara de origine
			Session["lstStareCivilaSearch"] = lstStareCivilaSearch.SelectedValue;
			Session["lstCopiiSearch"] = lstCopiiSearch.SelectedValue;//copii
			Session["lstSexSearch"] = lstSexSearch.SelectedValue;
			Session["lstTitulaturaSearch"] = lstTitulaturaSearch.SelectedValue;
			Session["lstStudiiSearch"] = lstStudiiSearch.SelectedValue;
			Session["txtMarcaSearch"] = (txtMarcaSearch.Text=="") ? "-1" : txtMarcaSearch.Text;
			Session["lstDepartamentSearch"] = lstDepartamentSearch.SelectedValue;
			Session["lstFunctieSearch"] = lstFunctieSearch.SelectedValue;//functie
			Session["lstModIncadrareSearch"] = lstModIncadrareSearch.SelectedValue;
			Session["lstIndemnizatieConducereSearch"] = lstIndemnizatieConducereSearch.SelectedValue;//indemnizatie conducere
			
			//categorie angajat : scutit impozit/categorii
			Session["lstScutitImpozitSearch"] = lstScutitImpozitSearch.SelectedValue;//scutit impozit |
			Session["lstCategorieAngajatSearch"] = lstCategorieAngajatSearch.SelectedValue;//categorii |

			//deducere+copii
			Session["lstDeducereSearch"] = lstDeducereSearch.SelectedValue;//deducere |
			Session["lstDeducereCopiiSearch"] = lstDeducereCopiiSearch.SelectedValue;// copii |
			
			//conturi bancare: are conturi/banca
			Session["lstContBancarExistentaSearch"] = lstContBancarExistentaSearch.SelectedValue;//are conturi |
			Session["lstBancaSearch"] = lstBancaSearch.SelectedValue;//banca |
			
			//Data angajarii: tip data angajare/data fixa - data/luna - luna+an/interval - dataSt+dataEnd/blank - nimic/
			Session["lstTipDataAngajareSearch"] = lstTipDataAngajareSearch.SelectedValue;
			int searchTipDataAngajare = Convert.ToInt32( lstTipDataAngajareSearch.SelectedValue );
			switch( searchTipDataAngajare )
			{
				case 0:
					try
					{
						Session["txtDataAngajatiSearch"] = txtDataAngajatiSearch.Text;
					}
					catch{}
					break;
				case 1:
					try
					{
						Session["lstAnAngajatisearch"] = lstAnAngajatiSearch.SelectedValue;
						Session["lstLunaAngajatiSearch"] = lstLunaAngajatiSearch.SelectedValue;
					}
					catch{}
					break;
				case 2:
					try
					{
						Session["txtDataStartAngajatiSearch"] = txtDataStartAngajatiSearch.Text;
						Session["txtDataEndAngajatiSearch"] = txtDataEndAngajatiSearch.Text;
					}
					catch{}
					break;
				case -1:
					break;
			}
			Session["lstPerioadaDeterminataSearch"] = lstPerioadaDeterminataSearch.SelectedValue;//Contract pe perioada determinata

			Response.Redirect("SearchAngajatiList_Recrutori.aspx");		
		}
		#endregion

		#region btnAdvancedSearch_Click
		/// <summary>
		/// Porneste motorul de cautare avansata
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdvancedSearch_Click(object sender, System.EventArgs e)
		{
			Session["txtTipCautareHidden"] = txtTipCautareHidden.Value;
			
			Session["txtNumeSearch"] = (txtNumeSearch.Text=="") ? "-1" : txtNumeSearch.Text;
			Session["txtPrenumeSearch"]= (txtPrenumeSearch.Text=="") ? "-1" : txtPrenumeSearch.Text;

			Session["lstNationalitateSearch"] = lstNationalitateSearch.SelectedValue;
			Session["lstTaraOrigineSearch"] = lstTaraOrigineSearch.SelectedValue;//tara de origine
			Session["lstStareCivilaSearch"] = lstStareCivilaSearch.SelectedValue;
			Session["lstCopiiSearch"] = lstCopiiSearch.SelectedValue;//copii
			Session["lstSexSearch"] = lstSexSearch.SelectedValue;
			Session["lstTitulaturaSearch"] = lstTitulaturaSearch.SelectedValue;
			Session["lstStudiiSearch"] = lstStudiiSearch.SelectedValue;
			Session["txtMarcaSearch"] = (txtMarcaSearch.Text=="") ? "-1" : txtMarcaSearch.Text;
			Session["lstDepartamentSearch"] = lstDepartamentSearch.SelectedValue;
			Session["lstFunctieSearch"] = lstFunctieSearch.SelectedValue;//functie
			Session["lstModIncadrareSearch"] = lstModIncadrareSearch.SelectedValue;
			Session["lstIndemnizatieConducereSearch"] = lstIndemnizatieConducereSearch.SelectedValue;//indemnizatie conducere
			
			//categorie angajat : scutit impozit/categorii
			Session["lstScutitImpozitSearch"] = lstScutitImpozitSearch.SelectedValue;//scutit impozit |
			Session["lstCategorieAngajatSearch"] = lstCategorieAngajatSearch.SelectedValue;//categorii |

			//deducere+copii
			Session["lstDeducereSearch"] = lstDeducereSearch.SelectedValue;//deducere |
			Session["lstDeducereCopiiSearch"] = lstDeducereCopiiSearch.SelectedValue;// copii |
			
			//conturi bancare: are conturi/banca
			Session["lstContBancarExistentaSearch"] = lstContBancarExistentaSearch.SelectedValue;//are conturi |
			Session["lstBancaSearch"] = lstBancaSearch.SelectedValue;//banca |
			
			//Data angajarii: tip data angajare/data fixa - data/luna - luna+an/interval - dataSt+dataEnd/blank - nimic/
			Session["lstTipDataAngajareSearch"] = lstTipDataAngajareSearch.SelectedValue;
			int searchTipDataAngajare = Convert.ToInt32( lstTipDataAngajareSearch.SelectedValue );
			switch( searchTipDataAngajare )
			{
				case 0:
					try
					{
						Session["txtDataAngajatiSearch"] = txtDataAngajatiSearch.Text;
					}
					catch{}
					break;
				case 1:
					try
					{
						Session["lstAnAngajatisearch"] = lstAnAngajatiSearch.SelectedValue;
						Session["lstLunaAngajatiSearch"] = lstLunaAngajatiSearch.SelectedValue;
					}
					catch{}
					break;
				case 2:
					try
					{
						Session["txtDataStartAngajatiSearch"] = txtDataStartAngajatiSearch.Text;
						Session["txtDataEndAngajatiSearch"] = txtDataEndAngajatiSearch.Text;
					}
					catch{}
					break;
				case -1:
					break;
			}
			Session["lstPerioadaDeterminataSearch"] = lstPerioadaDeterminataSearch.SelectedValue;//Contract pe perioada determinata

			Response.Redirect("SearchAngajatiList_Recrutori.aspx");		
		}
		#endregion

		#region Proceduri pentru popularea controalelor
		private void BindNationalitateCombo()
		{
			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			lstNationalitateSearch.DataSource = tari.GetNationalitatiUnion();
			lstNationalitateSearch.DataValueField = "TaraID";
			lstNationalitateSearch.DataTextField = "Nationalitate";
			lstNationalitateSearch.DataBind();
		}

		private void BindTitulaturaCombo()
		{
			Salaries.Business.AdminTitluriAngajati titluri = new Salaries.Business.AdminTitluriAngajati();
			lstTitulaturaSearch.DataSource = titluri.LoadInfoTitluriAngajatiUnion();
			lstTitulaturaSearch.DataValueField = "TitluID";
			lstTitulaturaSearch.DataTextField = "DenCompusa";
			lstTitulaturaSearch.DataBind();	
		}

		private void BindTaraDeOrigineCombo()
		{
			Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
			lstTaraOrigineSearch.DataSource = tari.LoadInfoTariUnion();
			lstTaraOrigineSearch.DataValueField = "TaraID";
			lstTaraOrigineSearch.DataTextField = "DenCompusa";
			lstTaraOrigineSearch.DataBind();
		}

		private void BindStudiiCombo()
		{
			Salaries.Business.AdminStudii studii = new Salaries.Business.AdminStudii();
			lstStudiiSearch.DataSource = studii.LoadInfoStudiiUnion(); 
			lstStudiiSearch.DataValueField = "StudiuID";
			lstStudiiSearch.DataTextField = "Nume";
			lstStudiiSearch.DataBind();
		}

		private void BindFunctieCombo()
		{
			Salaries.Business.AdminFunctii functie = new Salaries.Business.AdminFunctii();
			lstFunctieSearch.DataSource = functie.LoadInfoFunctiiUnion();
			lstFunctieSearch.DataValueField = "FunctieID";
			lstFunctieSearch.DataTextField = "DenCompusa";
			lstFunctieSearch.DataBind();
		}

		private void BindCategorieCombo()
		{
			//o sa trebuiasca sa fac cu siruri in JS in functie de combo-ul ScutitImpozit
			Salaries.Business.Luni luni = new Salaries.Business.Luni( Convert.ToInt32( Session[ "AngajatorID" ].ToString()));
			int lunaID = luni.GetLunaActiva().LunaId;
			//mai tre sa preiau luna activa
			Salaries.Business.AdminSalariiCategoriiAngajati ca = new Salaries.Business.AdminSalariiCategoriiAngajati();
			ca.LunaId = lunaID;
			lstCategorieAngajatSearch.DataSource = ca.LoadInfoCategoriiUnion();
			lstCategorieAngajatSearch.DataValueField = "CategorieID";
			lstCategorieAngajatSearch.DataTextField = "Denumire";
			lstCategorieAngajatSearch.DataBind();
		}

		private void BindBancaCombo()
		{
			Salaries.Business.AdminBanci banci = new Salaries.Business.AdminBanci();	
			lstBancaSearch.DataSource = banci.LoadInfoBanciUnion();
			lstBancaSearch.DataValueField = "BancaID";
			lstBancaSearch.DataTextField = "Nume";
			lstBancaSearch.DataBind();
		}

		private void BindDataAngajareCombo()
		{
			BindAnAngajareCombo();
			BindLunaAngajareCombo();
		}

		private void BindLunaAngajareCombo()
		{
			Salaries.Business.AdminSalariiLuni salarii = new Salaries.Business.AdminSalariiLuni();
			lstLunaAngajatiSearch.DataSource = salarii.LoadInfoLuniSalariiUnion();
			lstLunaAngajatiSearch.DataValueField = "LunaTextID";
			lstLunaAngajatiSearch.DataTextField = "Denumire";
			lstLunaAngajatiSearch.DataBind();
		}

		private void BindAnAngajareCombo()
		{
			Salaries.Business.Luni l = new Salaries.Business.Luni( Convert.ToInt32( Session[ "AngajatorID" ].ToString()));
			int an = l.GetLunaActiva().Data.Year;

			int itemValue = -1;

			lstAnAngajatiSearch.Items.Add( new ListItem( "", itemValue.ToString()));
			lstAnAngajatiSearch.SelectedValue = itemValue.ToString();

			for( int i=-anValInferioara; i<=anValSuperioara; i++ )
			{
				lstAnAngajatiSearch.Items.Add( new ListItem(( an+i ).ToString(), ( an+i ).ToString()));
			}
		}
		#endregion
	}
}
