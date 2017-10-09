/*
 * Modificat:	Oprescu Claudia
 * Data:		10.07.2007
 * Descriere:	A fost adaugata lista pentru Motivul de plecare.
 * 
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
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using Salaries.Data;
using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for LichidareAngajat.
	/// </summary>
	public class LichidareAngajat : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Table add_header;
		protected System.Web.UI.WebControls.TextBox txtBoalaID;
		protected System.Web.UI.WebControls.Button btnSalveaza;
		protected System.Web.UI.WebControls.Button btnInapoi;
		protected System.Web.UI.WebControls.TextBox txtNrInregistrare;
		protected System.Web.UI.WebControls.TextBox txtDataLichidare;
		protected System.Web.UI.WebControls.Button btnPreview;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.TextBox txtAvansuriDecontare;
		protected System.Web.UI.WebControls.TextBox txtAbonamente;
		protected System.Web.UI.WebControls.TextBox txtTicheteMasa;
		protected System.Web.UI.WebControls.TextBox txtEchipamentLucru;
		protected System.Web.UI.WebControls.TextBox txtLaptop;
		protected System.Web.UI.WebControls.TextBox txtTelServiciu;
		protected System.Web.UI.WebControls.TextBox txtObiecteInventar;
		protected System.Web.UI.WebControls.TextBox txtCarti;
		protected System.Web.UI.WebControls.TextBox txtCD;
		protected System.Web.UI.HtmlControls.HtmlTable add_form;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnPrev;

		public string tipActiune = "";
		protected System.Web.UI.WebControls.TextBox txtDataInregistrare;
		protected System.Web.UI.WebControls.TextBox txtNrArticol;
		protected System.Web.UI.WebControls.TextBox txtLunaRetinere;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnSave;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.DropDownList lstMotivDePlecare;
		public Salaries.Business.Angajat objAngajat;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			TransferDateLichidareLaClient();
			if (!IsPostBack)
			{
				BindMotiveDePlecare();
			}

			//Modificat: Oprescu Claudia
			//Descriere: Daca angajatul selectat este lichidat atunci se vizualizeaza datele despre lichidare corespunzatoare
			if (this.txtNrInregistrare.Text.Equals(""))
			{
				try
				{
					Salaries.Business.Luni l = new Salaries.Business.Luni( this.GetAngajator());
					Salaries.Data.LunaData ld = l.GetLunaActiva();
					int AngajatID = int.Parse(Session["AngajatID"].ToString());

					Salaries.Business.Lichidare lichidare = new Salaries.Business.Lichidare();
					DataSet ds = lichidare.GetLichidareAngajat(AngajatID, ld.Data);

					if (ds.Tables[0].Rows.Count > 0)
					{
						lstMotivDePlecare.SelectedValue = ds.Tables[0].Rows[0]["MotivDePlecareId"].ToString();
						this.txtNrInregistrare.Text = ds.Tables[0].Rows[0]["NrInregistrare"].ToString();
						if (DateTime.Parse(ds.Tables[0].Rows[0]["DataInregistrare"].ToString()).ToShortDateString() == "01.01.1753")
							this.txtDataInregistrare.Text = "";
						else
							this.txtDataInregistrare.Text = DateTime.Parse(ds.Tables[0].Rows[0]["DataInregistrare"].ToString()).ToShortDateString();
						this.txtDataLichidare.Text = DateTime.Parse(ds.Tables[0].Rows[0]["DataLichidare"].ToString()).ToShortDateString();
						//this.txtNrArticol.Text = float.Parse(ds.Tables[0].Rows[0]["NrArticol"].ToString()).ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits);
						this.txtNrArticol.Text = ds.Tables[0].Rows[0]["NrArticol"].ToString();
						this.txtAvansuriDecontare.Text = float.Parse(ds.Tables[0].Rows[0]["AvansuriDecontare"].ToString()).ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits);
						this.txtAbonamente.Text = float.Parse(ds.Tables[0].Rows[0]["Abonamente"].ToString()).ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits);
						this.txtTicheteMasa.Text = float.Parse(ds.Tables[0].Rows[0]["TicheteMasa"].ToString()).ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits);
						this.txtEchipamentLucru.Text = float.Parse(ds.Tables[0].Rows[0]["EchipamentLucru"].ToString()).ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits);
						this.txtLaptop.Text = float.Parse(ds.Tables[0].Rows[0]["Laptop"].ToString()).ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits);
						this.txtTelServiciu.Text = float.Parse(ds.Tables[0].Rows[0]["telServiciu"].ToString()).ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits);
						this.txtObiecteInventar.Text = float.Parse(ds.Tables[0].Rows[0]["ObiecteInventar"].ToString()).ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits);
						this.txtCarti.Text = float.Parse(ds.Tables[0].Rows[0]["Carti"].ToString()).ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits);
						this.txtCD.Text = float.Parse(ds.Tables[0].Rows[0]["CD"].ToString()).ToString("N",Salaries.Business.VariabileGlobale.numberInfoFormatWithoutDigits);
						if (DateTime.Parse(ds.Tables[0].Rows[0]["LunaRetinere"].ToString()).ToShortDateString() == "01.01.1753")
							this.txtLunaRetinere.Text = "";
						else
							this.txtLunaRetinere.Text = DateTime.Parse(ds.Tables[0].Rows[0]["LunaRetinere"].ToString()).ToShortDateString();
					}
				}
				catch{}
			}
		}
		#endregion
		
		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			this.HandleActions();
		}
		#endregion

		#region Render
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render (writer);

			Response.Write( "<script>var NrInregistrareClient = '"+this.txtNrInregistrare.ClientID+"';</script>" );
			Response.Write( "<script>var DataLichidareClient = '"+this.txtDataLichidare.ClientID+"';</script>" );

			Response.Write( "<script>var AvansuriDecontareClient = '"+this.txtAvansuriDecontare.ClientID+"';</script>" );
			Response.Write( "<script>var AbonamenteClient = '"+this.txtAbonamente.ClientID+"';</script>" );
			Response.Write( "<script>var TicheteMasaClient = '"+this.txtTicheteMasa.ClientID+"';</script>" );
			Response.Write( "<script>var EchipamentLucruClient = '"+this.txtEchipamentLucru.ClientID+"';</script>" );
			Response.Write( "<script>var LaptopClient = '"+this.txtLaptop.ClientID+"';</script>" );
			Response.Write( "<script>var TelServiciuClient = '"+this.txtTelServiciu.ClientID+"';</script>" );
			Response.Write( "<script>var ObiecteInventarClient = '"+this.txtObiecteInventar.ClientID+"';</script>" );
			Response.Write( "<script>var CartiClient = '"+this.txtCarti.ClientID+"';</script>" );
			Response.Write( "<script>var CDClient = '"+this.txtCD.ClientID+"';</script>" );

			Response.Write( "<script>var DataInregistrareClient = '"+this.txtDataInregistrare.ClientID+"';</script>" );
			Response.Write( "<script>var NrArticolClient = '"+this.txtNrArticol.ClientID+"';</script>" );
			Response.Write( "<script>var LunaRetinereClient = '"+this.txtLunaRetinere.ClientID+"';</script>" );
			Response.Write( "<script>var lstMotivDePlecare = '"+this.lstMotivDePlecare.ClientID+"';</script>" );
		}
		#endregion

		#region BindMotiveDePlecare
		/// <summary>
		/// Adaugat:	Oprescu Claudia
		/// Data:		10.07.2007
		/// Descriere:	Se incarca lista care contine motivele de plecare
		/// </summary>
		private void BindMotiveDePlecare()
		{
			try
			{
				Salaries.Business.AdminMotiveDePlecare objMotive = new Salaries.Business.AdminMotiveDePlecare();
				lstMotivDePlecare.DataSource = objMotive.LoadMotiveDePlecare();
				lstMotivDePlecare.DataTextField = "DenumireIntreaga";
				lstMotivDePlecare.DataValueField = "MotivDePlecareId";
				lstMotivDePlecare.DataBind();
				if (lstMotivDePlecare.Items.Count > 0)
				{
					lstMotivDePlecare.SelectedIndex = 0;
					((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtMotivDePlecareHidden" )).Value = lstMotivDePlecare.Items[0].Value;
				}
			}
			catch(Exception ex){}
		}
		#endregion
		
		#region TransferDateLichidareLaClient
		/// <summary>
		/// Daca angajatul este deja lichiat, atunci se vor completa campurile cu datele lichidarii
		/// </summary>
		private void TransferDateLichidareLaClient()
		{
			tipActiune = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtTipActiuneLichidareHidden" )).Value;

			txtNrInregistrare.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrInregistrareHidden" )).Value;
			txtDataLichidare.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDataLichidareHidden" )).Value;
			if (((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtMotivDePlecareHidden" )).Value != "")
			{
				lstMotivDePlecare.SelectedValue = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtMotivDePlecareHidden" )).Value;
			}

			txtAvansuriDecontare.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAvansuriDecontareHidden" )).Value;
			txtAvansuriDecontare.Text = txtAvansuriDecontare.Text == "" ? "0" : txtAvansuriDecontare.Text;
			txtAbonamente.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAbonamenteHidden" )).Value;
			txtAbonamente.Text = txtAbonamente.Text == "" ? "0" : txtAbonamente.Text;
			txtTicheteMasa.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtTicheteMasaHidden" )).Value;
			txtTicheteMasa.Text = txtTicheteMasa.Text == "" ? "0" : txtTicheteMasa.Text;
			txtEchipamentLucru.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtEchipamentLucruHidden" )).Value;
			txtEchipamentLucru.Text = txtEchipamentLucru.Text == "" ? "0" : txtEchipamentLucru.Text;
			txtLaptop.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtLaptopHidden" )).Value;
			txtLaptop.Text = txtLaptop.Text == "" ? "0" : txtLaptop.Text;
			txtTelServiciu.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtTelServiciuHidden" )).Value;
			txtTelServiciu.Text = txtTelServiciu.Text == "" ? "0" : txtTelServiciu.Text;
			txtObiecteInventar.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtObiecteInventarHidden" )).Value;
			txtObiecteInventar.Text = txtObiecteInventar.Text == "" ? "0" : txtObiecteInventar.Text;
			txtCarti.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtCartiHidden" )).Value;
			txtCarti.Text = txtCarti.Text == "" ? "0" : txtCarti.Text;
			txtCD.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtCDHidden" )).Value;
			txtCD.Text = txtCD.Text == "" ? "0" : txtCD.Text;

			txtDataInregistrare.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDataInregistrareHidden" )).Value;
			txtNrArticol.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrArticolHidden" )).Value;
			txtLunaRetinere.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtLunaRetinereHidden" )).Value;

			EmptyMainHiddenTextBoxes();
		}
		#endregion
		
		#region EmptyMainHiddenTextBoxes
		/// <summary>
		/// Se golesc valorile controalelor
		/// </summary>
		private void EmptyMainHiddenTextBoxes()
		{
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtTipActiuneLichidareHidden" )).Value = "";

			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrInregistrareHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDataLichidareHidden" )).Value = "";

			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAvansuriDecontareHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtAbonamenteHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtTicheteMasaHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtEchipamentLucruHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtLaptopHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtTelServiciuHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtObiecteInventarHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtCartiHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtCDHidden" )).Value = "";

			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDataInregistrareHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtNrArticolHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtLunaRetinereHidden" )).Value = "";
		}
		#endregion

		#region HandleActions
		/// <summary>
		/// Executa o actiune
		/// </summary>
		private void HandleActions()
		{
			switch( this.tipActiune )
			{
				case "adaugaLichidare":
					btnSalveaza_Click();
					break;
				case "previewLichidare":
					btnPreview_Click();
					break;
				default:
					break;
			}
			tipActiune = "";
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

		#region btnSalveaza_Click
		/// <summary>
		/// Salveaza o lichidate
		/// </summary>
		private void btnSalveaza_Click()
		{
			/*
			 * Modified:  Cristina Raluca Muntean
			 * Date:      10.09.2005
			 * Descriere: Modificarea consta in validarea datelor de intrare, a statusului angajatului(lichidat/nu este lichidat)
			 * si a generarii situatiei lunare conform cu noile date corespunzatoare lichidarii.			  
			 */

			//Modificat: Oprescu Claudia
			//Descriere: Se face mai intai validarea datelor introduse si apoi daca angajatul nu este lichidat se face lichidarea lui
			//			 Daca este deja lichidat se face actualizare la datele lichidarii, adica se sterge cea veche si se adauga una noua
			int idAng = GetAngajat();
			ErrHandler.MyErrHandler.WriteError("LichidareAngajat.ascx - start - Salveaza() - idAng: " + idAng.ToString());
			try
			{
				Salaries.Data.LichidareStruct lichidare = new Salaries.Data.LichidareStruct();
				Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
				angajat.AngajatId = GetAngajat();
				angajat.LoadAngajat();
			
				lichidare.AngajatID = this.GetAngajat();

				//variabila booleana care indica daca au fost completate toate campurile obligatorii
				bool fill = true;
				//variabila booleana care indica daca au fost completate corect campurile
				bool correct = true;
				
				//se verifica daca au fost completate campurile 
				if(txtNrInregistrare.Text == "" || txtDataLichidare.Text == "" || txtDataInregistrare.Text == "")
				{
					fill = false;
				}
				try
				{
					lichidare.NrInregistrare = txtNrInregistrare.Text;
					lichidare.DataLichidare = Utilities.ConvertText2DateTime( txtDataLichidare.Text );
					lichidare.MotivDePlecareId = int.Parse(((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtMotivDePlecareHidden" )).Value);
					
					lichidare.NrArticol = txtNrArticol.Text;
					lichidare.AvansuriDecontare = decimal.Parse( txtAvansuriDecontare.Text );
					lichidare.Abonamente = decimal.Parse( txtAbonamente.Text );
					lichidare.TicheteMasa = decimal.Parse( txtTicheteMasa.Text );
					lichidare.EchipamentLucru = decimal.Parse( txtEchipamentLucru.Text );
					lichidare.Laptop = decimal.Parse( txtLaptop.Text );
					lichidare.TelServiciu = decimal.Parse( txtTelServiciu.Text );
					lichidare.ObiecteInventar = decimal.Parse( txtObiecteInventar.Text );
					lichidare.Carti = decimal.Parse( txtCarti.Text );
					lichidare.CD = decimal.Parse( txtCD.Text );

					lichidare.DataInregistrare = Utilities.ConvertText2DateTime( txtDataInregistrare.Text );
					if (txtLunaRetinere.Text == "")
						lichidare.LunaRetinere = Utilities.ConvertText2DateTime( "1.1.1753" );
					else
						lichidare.LunaRetinere = Utilities.ConvertText2DateTime( txtLunaRetinere.Text );

				}
				catch(Exception)
				{
					//in cazul in care apare o eroare la conversie inseamna ca nu au fost completate corect campurile
					correct = false;
				}
				
				Salaries.Business.Luni luni = new Salaries.Business.Luni( this.GetAngajator());
				Salaries.Data.LunaData lunaData = luni.GetLunaActiva();

				//daca au fost completate toate campurile corect si data lichidarii se afla in luna activa se poate realiza efectiv lichidarea
				if( fill && correct )
					if ( (lunaData.Data.Month==DateTime.Parse(txtDataLichidare.Text).Date.Month && lunaData.Data.Year==DateTime.Parse(txtDataLichidare.Text).Date.Year) ||
							(DateTime.Parse(txtDataLichidare.Text).Date.Day ==1) && (DateTime.Parse(txtDataLichidare.Text).Date.Month == lunaData.Data.Month + 1) && (lunaData.Data.Year==DateTime.Parse(txtDataLichidare.Text).Date.Year) ||
							(DateTime.Parse(txtDataLichidare.Text).Date.Day ==1) && (DateTime.Parse(txtDataLichidare.Text).Date.Month == 1) && (lunaData.Data.Month == 12) && (lunaData.Data.Year+1==DateTime.Parse(txtDataLichidare.Text).Date.Year))
					{
						SiemensTM.Classes.IntervaleAngajat intervaleAngajat = new SiemensTM.Classes.IntervaleAngajat( lichidare.AngajatID );
						//sterge toate intervalele orare, inclusiv capetele de interval
						intervaleAngajat.DeleteIntervaleAngajatPerioada( lichidare.DataLichidare, DateTime.MaxValue, true );
						//initializeaza luna pentru angajatul in cauza
						intervaleAngajat.InitializeOreLucrateLunaAngajat(lunaData.Data, objAngajat.DataDeLa, lichidare.DataLichidare);
					
						//se genereaza situatia lunara a angajatului
						//Salaries.Business.SituatieLunaraAngajat sla = new Salaries.Business.SituatieLunaraAngajat( lichidare.AngajatID );
						//sla.GenerareSituatieLunaraAngajat( this.GetCurrentMonth(), this.GetAngajator());
						
						//Adaugat:		Oprescu Claudia
						//Descriere:	Se verifica sa nu existe deja o lichidare pentru luna activa.
						//				Daca exista atunci se actualizeaza acea inregistrare.
						//				Daca nu exista se adauga o inregistrare noua.
						int lichidareID = new Salaries.Business.Lichidare().CheckIfLichidareCanBeAdded(lichidare.AngajatID, lichidare.DataLichidare);
						if (lichidareID == 0)
						{
							new Salaries.Business.Lichidare().AddLichidare( lichidare );
						}
						else
						{
							lichidare.LichidareID = lichidareID;
							new Salaries.Business.Lichidare().UpdateLichidare(lichidare);
						}
						
						//Modified: Cristina Raluca Muntean
						//se genereaza situatia lunara a angajatului
						SiemensTM.Classes.SituatieAngajat situatieLunaraAng = new SiemensTM.Classes.SituatieAngajat(this.GetAngajat());
							//Added: Ionel Popa -> daca este lichidat in prima zi a lunii i se sterge situatia lunara
							Salaries.Business.Luni activeMonth = new Salaries.Business.Luni( this.GetAngajator(), lunaData.LunaId);
						if( activeMonth.Data == lichidare.DataLichidare)
						{
							Salaries.Business.SituatieLunaraAngajat sla = new Salaries.Business.SituatieLunaraAngajat(this.GetAngajat());
							sla.DeleteSituatieAngajat( GetCurrentMonth() , this.GetAngajat());
						}
						else
						{
							//Modificat:	Oprescu Claudia
							//Descriere:	Se apeleaza metoda pentru generarea situatiei lunare a angajatului
							//				La generarea situatiei se calculeaza numarul de zile de concediu de odihna neefectuat si efectuat in avans
							situatieLunaraAng.GenerareSituatieLunaraAngajatLichidat();
						}

							//javascript
							StringBuilder jScript = new StringBuilder();
							jScript.Append("<script language=\"JavaScript\">");
							jScript.Append("window.open('../Comunicari/comunicare.aspx?id=" + objAngajat.AngajatId + "',null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes')");
							jScript.Append("</script>");

							AdaugaInSesiune();

							Response.Write(jScript.ToString());
					}
					else
					{
						//este afisat mesajul de eroare
						Response.Write( "<script>alert( 'Data lichidarii angajatului trebuie sa faca parte din luna activa!' );</script>" );
					}
				else
				{
					//in functie de eroare este afisat mesajul corespunzator
					if(!correct)
						Response.Write( "<script>alert( 'Datele introduse nu sunt corecte!' );</script>" );
					if(!fill)
						Response.Write( "<script>alert( 'Trebuie sa completati toate datele!' );</script>" );
				}
			}
			catch (Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
				ErrHandler.MyErrHandler.WriteError("LichidareAngajat.ascx - start - Salveaza() - idAng: " + idAng.ToString() + " - " + ex.Message);
			}
			ErrHandler.MyErrHandler.WriteError("LichidareAngajat.ascx - end - Salveaza() - idAng: " + idAng.ToString());
		}
		#endregion
		
		#region btnPreview_Click
		/// <summary>
		/// Se vizualizeaza nota de lichidare
		/// </summary>
		private void btnPreview_Click()
		{
			/*
			 * Modified:  Oprescu Claudia
			 * Date:      02.03.2006
			 * Descriere: Modificarea consta in validarea datelor de intrare			  
			 */

			//variabila booleana care indica daca au fost completate toate campurile obligatorii
			bool fill = true;
			//variabila booleana care indica daca au fost completate corect campurile
			bool correct = true;
				
			Salaries.Data.LichidareStruct lichidare = new Salaries.Data.LichidareStruct();
			Salaries.Business.Angajat angajat = new Salaries.Business.Angajat();
			angajat.AngajatId = GetAngajat();
			angajat.LoadAngajat();

			//se verifica daca au fost completate campurile 
			if(txtNrInregistrare.Text == "" || txtDataLichidare.Text == "" || txtDataInregistrare.Text == "" )
			{
				fill = false;
			}
			try
			{
				lichidare.NrInregistrare = txtNrInregistrare.Text;
				lichidare.DataLichidare = Utilities.ConvertText2DateTime( txtDataLichidare.Text );
						
				lichidare.NrArticol = txtNrArticol.Text;
				lichidare.AvansuriDecontare = decimal.Parse( txtAvansuriDecontare.Text );
				lichidare.Abonamente = decimal.Parse( txtAbonamente.Text );
				lichidare.TicheteMasa = decimal.Parse( txtTicheteMasa.Text );
				lichidare.EchipamentLucru = decimal.Parse( txtEchipamentLucru.Text );
				lichidare.Laptop = decimal.Parse( txtLaptop.Text );
				lichidare.TelServiciu = decimal.Parse( txtTelServiciu.Text );
				lichidare.ObiecteInventar = decimal.Parse( txtObiecteInventar.Text );
				lichidare.Carti = decimal.Parse( txtCarti.Text );
				lichidare.CD = decimal.Parse( txtCD.Text );

				lichidare.DataInregistrare = Utilities.ConvertText2DateTime( txtDataInregistrare.Text );
				if (txtLunaRetinere.Text == "")
					lichidare.LunaRetinere = Utilities.ConvertText2DateTime( "1.1.1753" );
				else
					lichidare.LunaRetinere = Utilities.ConvertText2DateTime( txtLunaRetinere.Text );

			}
			catch(Exception)
			{
				//in cazul in care apare o eroare la conversie inseamna ca nu au fost completate corect campurile
				correct = false;
			}
			if (fill && correct)
			{
				//tre afisata nota de lichidare, in vederea printarii
				//javascript
				StringBuilder jScript = new StringBuilder();
				jScript.Append("<script language=\"JavaScript\">");
				jScript.Append("window.open('../Comunicari/comunicare.aspx?id=" + objAngajat.AngajatId + "', null,'status=yes,toolbar=no,menubar=no,location=no,resizable=yes,scrollbars=yes')");
				jScript.Append("</script>");

				AdaugaInSesiune();

				Response.Write(jScript.ToString());
			}
			else
			{
				//in functie de eroare este afisat mesajul corespunzator
				if(!correct)
					Response.Write( "<script>alert( 'Datele introduse nu sunt corecte!' );</script>" );
				if(!fill)
					Response.Write( "<script>alert( 'Trebuie sa completati toate datele!' );</script>" );
			}
		}
		#endregion

		#region AdaugaInSesiune
		/// <summary>
		/// Se retin datele lichidarii
		/// </summary>
		private void AdaugaInSesiune()
		{
			Session["TipComunicare"] = "Nota de lichidare.xml";
			Session["NrInregistrare"] = txtNrInregistrare.Text;
			Session["AvansDecontare"] = txtAvansuriDecontare.Text;
			Session["Abonamente"] = txtAbonamente.Text;
			Session["TicheteMasa"] = txtTicheteMasa.Text;
			Session["EchipamentLucru"] = txtEchipamentLucru.Text;
			Session["Laptop"] = txtLaptop.Text;
			Session["TelefonServiciu"] = txtTelServiciu.Text;
			Session["ObiecteInventar"] = txtObiecteInventar.Text;
			Session["Carti"] = txtCarti.Text;
			Session["CDuri"] = txtCD.Text;
			Session["DataLichidare"] = Utilities.ConvertText2DateTime( txtDataLichidare.Text );
			Session["DataInregistrare"] = Utilities.ConvertText2DateTime( txtDataInregistrare.Text );
			Session["NrArticol"] = txtNrArticol.Text;
			Session["LunaRetinere"] = Utilities.ConvertText2DateTime( txtLunaRetinere.Text );
		}
		#endregion
	}
}
