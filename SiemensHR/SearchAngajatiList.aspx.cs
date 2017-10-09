//Modificat: Oprescu Claudia
//Descriere: la switch searchTipDataAngajare pentru case 1 ambele atribuiri se faceau pentru searchLunaData 
//			 si una trebuie pentru searchAnData

/*
* Modificat:	Fratila Claudia
* Data:			31.10.2007
* Descriere:	A fost modificata clasa astfel incat sa existe doua moduri autentificare: Windows sau user si parola.
* 				Tipul de autentificare este stabilit in fisierul de configurare.
* 				0 - fara autnetificare
* 				1 - autentificare windows
* 				2 - autentificare user si parola

* Modificat:	Lungu Andreea
* Data:			17.09.2010
* Descriere:	Am adaugat la cautare avansata punctul de lucru.
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
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Principal;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR
{
	/// <summary>
	/// Summary description for SearchAngajatiList.
	/// </summary>
	public class SearchAngajatiList : System.Web.UI.Page
	{
		#region Variabile
		protected System.Web.UI.WebControls.DataGrid listDataGrid;
		private int Index;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Security.Principal.WindowsPrincipal user;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			settings = Salaries.Configuration.ModuleConfig.GetSettings();
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
						ErrHandler.MyErrHandler.WriteError("SearchAngajatiList.aspx - autentificare windows fara drepturi - " + user.Identity.Name);
						Server.Transfer("Unauthorized.aspx");
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
							ErrHandler.MyErrHandler.WriteError("SearchAngajati.aspx - autentificare user parola fara drepturi - " + nume + ", " + angajatorId);
							Server.Transfer("Unauthorized.aspx");
						}
					}
					catch(Exception exc)
					{
						Response.Redirect("index.aspx");
					}
				}
				
				string searchTipCautare = Session["txtTipCautareHidden"].ToString();

				string searchNume = Session["txtNumeSearch"].ToString();
				string searchPrenume = Session["txtPrenumeSearch"].ToString();

				int searchNationalitate = Convert.ToInt32( Session["lstNationalitateSearch"] );
				int searchTaraOrigine = Convert.ToInt32( Session[ "lstTaraOrigineSearch" ] );//tara de origine
				int searchStareCivila = Convert.ToInt32(Session["lstStareCivilaSearch"]);
				int searchCopii = Convert.ToInt32( Session[ "lstCopiiSearch" ] );//copii
				string searchSex = Session["lstSexSearch"].ToString();
				int searchTitulatura = Convert.ToInt32(Session["lstTitulaturaSearch"]);
				int searchStudii = Convert.ToInt32(Session["lstStudiiSearch"]);
				string searchMarca = Session["txtMarcaSearch"].ToString();
				int searchDepartament = Convert.ToInt32(Session["lstDepartamentSearch"]);
				int searchFunctie = Convert.ToInt32( Session[ "lstFunctieSearch" ] );//functie
				int searchModIncadrare = Convert.ToInt32(Session["lstModIncadrareSearch"]);
				int searchIndemnizatieConducere = Convert.ToInt32( Session[ "lstIndemnizatieConducereSearch" ] );//indemnizatie conducere
				int searchPunctLucru = Convert.ToInt32( Session["lstPunctLucruSearch"]);

				//categorie angajat : scutit impozit/categorii
				int searchScutitImpozit = Convert.ToInt32( Session[ "lstScutitImpozitSearch" ] );//scutit impozit |
				int searchCategorii = Convert.ToInt32( Session[ "lstCategorieAngajatSearch" ] );//categorii |
				
				//deducere+copii
				int searchDeducere = Convert.ToInt32( Session[ "lstDeducereSearch" ] );//deducere |
				int searchDeducereCopii = Convert.ToInt32( Session[ "lstDeducereCopiiSearch" ] );// copii |
				
				//conturi bancare: are conturi/banca
				int searchContBancarExistenta = Convert.ToInt32( Session[ "lstContBancarExistentaSearch" ] );//are conturi |
				int searchBanca = Convert.ToInt32(Session[ "lstBancaSearch" ] );//banca |
			
				//Data angajarii: tip data angajare/data fixa - data/luna - luna+an/interval - dataSt+dataEnd/blank - nimic/
				int searchTipDataAngajare = Convert.ToInt32( Session[ "lstTipDataAngajareSearch" ] );
				DateTime searchDataFixa = DateTime.MinValue;
				DateTime searchIntervalDataStart = DateTime.MinValue;
				DateTime searchIntervalDataEnd = DateTime.MinValue;
				int searchAnData = -1;
				int searchLunaData = -1;

				switch( searchTipDataAngajare )
				{
					case 0:
						try
						{
							searchDataFixa = Utilities.ConvertText2DateTime( Session[ "txtDataAngajatiSearch" ].ToString());
							Session.Remove("txtDataAngajatiSearch");
						}
						catch{}
						break;
					case 1:
						try
						{
							searchAnData = Convert.ToInt32( Session[ "lstAnAngajatiSearch" ] );
							searchLunaData = Convert.ToInt32( Session[ "lstLunaAngajatiSearch" ] );
							Session.Remove("lstAnAngajatiSearch");
							Session.Remove("lstLunaAngajatiSearch");
						}
						catch{}
						break;
					case 2:
						try
						{
							searchIntervalDataStart = Utilities.ConvertText2DateTime(Session[ "txtDataStartAngajatiSearch" ].ToString());
							searchIntervalDataEnd = Utilities.ConvertText2DateTime(Session[ "txtDataEndAngajatiSearch" ].ToString() );
							Session.Remove("txtDataStartAngajatiSearch");
							Session.Remove("txtDataEndAngajatiSearch");
						}
						catch{}
						break;
					case -1:
						break;
				}
				int searchPerioadaDeterminata = Convert.ToInt32( Session[ "lstPerioadaDeterminataSearch" ] );//Contract pe perioada determinata
				int searchAngajatLichidat = Convert.ToInt32( Session[ "lstAngajatLichidatSearch" ] );//Angajat lichidat
		
				//stergerea variabilelor de sesiune
				stergeVariabile();
	
				//comanda de cautare
				SqlConnection m_con = new SqlConnection(settings.ConnectionString);
				SqlCommand searchCommand = new SqlCommand("tmp_CautareAngajat", m_con );
				searchCommand.CommandType = CommandType.StoredProcedure;

				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_TipCautare", SqlDbType.NVarChar, 50, searchTipCautare ));
			
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_Nume", SqlDbType.NVarChar, 50, searchNume));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_Prenume", SqlDbType.NVarChar, 50, searchPrenume));

				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_Nationalitate", SqlDbType.Int, 4, searchNationalitate));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_TaraOrigineID", SqlDbType.Int, 4, searchTaraOrigine ));//tara de origine
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_StareCivila", SqlDbType.Int, 4, searchStareCivila));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_Copii", SqlDbType.Int, 4, searchCopii ));//copii
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_Sex", SqlDbType.Char, searchSex.Length, searchSex));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_TitluID", SqlDbType.Int, 4, searchTitulatura));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_StudiuID", SqlDbType.Int, 4, searchStudii));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_Marca", SqlDbType.NVarChar, 8, searchMarca));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_DepartamentID", SqlDbType.Int, 5, searchDepartament));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_FunctieID", SqlDbType.Int, 4, searchFunctie ));//functie
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_ModIncadrare", SqlDbType.Int, 4,  searchModIncadrare));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_IndemnizatieConducere", SqlDbType.Int, 4, searchIndemnizatieConducere));//indemnizatie de conducere
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_PunctLucruID", SqlDbType.Int, 4, searchPunctLucru));
				
				//categorie angajat
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_ScutitImpozit", SqlDbType.Int, 4, searchScutitImpozit ));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_CategorieID", SqlDbType.Int, 4, searchCategorii));
			
				//deducere
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_Deducere", SqlDbType.Int, 4, searchDeducere ));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_DeducereCopii", SqlDbType.Int, 4, searchDeducereCopii ));
			
				//conturi bancare
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_ContBancarExistenta", SqlDbType.Int, 4, searchContBancarExistenta ));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_BancaID", SqlDbType.Int, 4, searchBanca ));
			
				//data angajarii
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_TipDataAngajare", SqlDbType.Int, 4, searchTipDataAngajare ));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_DataFixa", SqlDbType.DateTime, 8, searchDataFixa ));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_LunaData", SqlDbType.Int, 4, searchLunaData ));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_AnData", SqlDbType.Int, 4, searchAnData ));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_IntervalDataStart", SqlDbType.DateTime, 8, searchIntervalDataStart ));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_IntervalDataEnd", SqlDbType.DateTime, 8, searchIntervalDataEnd ));
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_DataMinValue", SqlDbType.DateTime, 8, DateTime.MinValue ));

				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_PerioadaDeterminata", SqlDbType.Int, 4, searchPerioadaDeterminata));//Contract pe perioada determinata
				searchCommand.Parameters.Add(UtilitiesDb.AddInputParameter("@in_AngajatLichidat", SqlDbType.Int, 4, searchAngajatLichidat));//Angajat lichidat
				
				SqlDataAdapter dAdapt = new SqlDataAdapter(searchCommand);
				DataSet ds = new DataSet();
				dAdapt.Fill(ds);
			
				Session["SortBy"] = "";
				Index =1;
				Session["DataSource_searchList"]  = ds;
				listDataGrid.DataSource = ds;
				listDataGrid.DataBind();
			}				
		}
		#endregion

		#region stergeVariabile
		/// <summary>
		/// Se sterg variabilele de sesiune
		/// </summary>
		private void stergeVariabile()
		{
			Session.Remove("txtTipCautareHidden");

			Session.Remove("txtNumeSearch");
			Session.Remove("txtPrenumeSearch");

			Session.Remove("lstNationalitateSearch");
			Session.Remove("lstTaraOrigineSearch");
			Session.Remove("lstStareCivilaSearch");
			Session.Remove("lstCopiiSearch");
			Session.Remove("lstSexSearch");
			Session.Remove("lstTitulaturaSearch");
			Session.Remove("lstStudiiSearch");
			Session.Remove("txtMarcaSearch");
			Session.Remove("lstDepartamentSearch");
			Session.Remove("lstFunctieSearch");
			Session.Remove("lstModIncadrareSearch");
			Session.Remove("lstIndemnizatieConducereSearch");
			Session.Remove("lstPunctLucruSearch");

			Session.Remove("lstScutitImpozitSearch");
			Session.Remove("lstCategorieAngajatSearch");

			Session.Remove("lstDeducereSearch");
			Session.Remove("lstDeducereCopiiSearch");

			Session.Remove("lstContBancarExistentaSearch");
			Session.Remove("lstBancaSearch");

			Session.Remove("lstTipDataAngajareSearch");
			Session.Remove("lstPerioadaDeterminataSearch");
		}
		#endregion

		#region listDataGrid_ItemDataBound
		/// <summary>
		/// Se adauga o inregistrare in tabel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listDataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemIndex!=-1)  // daca e header nu pune evenimentele
			{
				TableCell myCell = new TableCell();
				myCell.Text = Index.ToString();
				myCell.Attributes.Add("align","center");
				e.Item.Cells.AddAt(0, myCell);
				for(int j=0; j<e.Item.Cells.Count; j++)
					e.Item.Cells[j].Attributes.Add("class","UnderlineNormalBlack");
				Index++;
				e.Item.Attributes.Add("onmouseover", "MouseOverTableLine(this)");
				e.Item.Attributes.Add("onmouseout", "MouseOutTableLine(this)");
				e.Item.Attributes.Add("onclick", "EditAngajat(this)");

				e.Item.Cells[1].Style.Add("display", "none");
			}
			else
			{
				TableCell myCellHeader = new TableCell();
				myCellHeader.Text = "Nr. crt";
				e.Item.Cells.AddAt(0, myCellHeader);
				for (int i=1; i<e.Item.Cells.Count ; i++)
				{
					// ascund prima coloana.. care este id angajat
					if (i==1)
						e.Item.Cells[i].Style.Add("display", "none");
					if(e.Item.Cells[i].Controls.Count>0)
					{
						// setez clasa de CSS ptr. header de table + evenimente client
						LinkButton linkbtn = (LinkButton) e.Item.Cells[i].Controls[0];
						linkbtn.CssClass = "SortStyle";
						linkbtn.Attributes.Add("onmouseover","MouseOverSortHeader(this)");
						linkbtn.Attributes.Add("onmouseout","MouseOutSortHeader(this)");
					}
				}
			}
		}
		#endregion

		#region listDataGrid_SortCommand
		/// <summary>
		/// Procedura permite sortarea angajatilor pe coloane
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listDataGrid_SortCommand(Object sender, DataGridSortCommandEventArgs e)
		{
			// Retrieve the data source from session state.
			DataSet dt = (DataSet)Session["DataSource_searchList"];

			// Create a DataView from the DataTable.
			DataView dv = dt.Tables[0].DefaultView;

			// The DataView provides an easy way to sort. Simply set the
			// Sort property with the name of the field to sort by.
			dv.Sort = e.SortExpression;
			Session["SortBy"] = e.SortExpression;
			// Rebind the data source 
			listDataGrid.DataSource = dv;
			Index = (listDataGrid.CurrentPageIndex * listDataGrid.PageSize) + 1;
			listDataGrid.DataBind();
		}
		#endregion

		#region listDataGrid_PageIndexChanged
		/// <summary>
		/// Procedura trece la urmatoarea pagina cu angajati din lista
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listDataGrid_PageIndexChanged(Object sender, DataGridPageChangedEventArgs	e)
		{

			DataSet dt = (DataSet)Session["DataSource_searchList"];

			listDataGrid.CurrentPageIndex = e.NewPageIndex;

			// Rebind the data to refresh the DataGrid control. 
			DataView dv = dt.Tables[0].DefaultView;

			if (Session["SortBy"].ToString()!="")
					dv.Sort = Session["SortBy"].ToString();
			listDataGrid.DataSource = dv;
			Index = (e.NewPageIndex * listDataGrid.PageSize) + 1;
			listDataGrid.DataBind();
		}
		#endregion

		#region listDataGrid_ItemCreated
		/// <summary>
		/// Procedura creaza o inregistrare in tabelul cu angajati
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void listDataGrid_ItemCreated(Object sender, DataGridItemEventArgs e)
		{
			string szLnk = "System.Web.UI.WebControls.DataGridLinkButton";
			string szLbl = "System.Web.UI.WebControls.Label";

			if (e.Item.ItemType == ListItemType.Pager)
			{
				TableCell cellPager = (TableCell) e.Item.Controls[0];
				cellPager.CssClass = "PagingBackStyle";
				for(int i=0; i<cellPager.Controls.Count; i++)
				{
					if ( cellPager.Controls[i].GetType().ToString() == szLnk)
					{
						LinkButton ctrl = (LinkButton) cellPager.Controls[i];
						ctrl.CssClass = "PagingStyle";
						ctrl.Attributes.Add("onmouseover","MouseOverPageNumber(this)");
						ctrl.Attributes.Add("onmouseout","MouseOutPageNumber(this)");
					}
					if (cellPager.Controls[i].GetType().ToString()== szLbl)
					{
						WebControl webCtrl = (WebControl) cellPager.Controls[i];
						webCtrl.CssClass = "SelectPageNumberStyle";
					}
				}
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.listDataGrid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGrid_ItemCreated);
			this.listDataGrid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.listDataGrid_PageIndexChanged);
			this.listDataGrid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.listDataGrid_SortCommand);
			this.listDataGrid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.listDataGrid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
