/*
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
using System.Text.RegularExpressions;

//using SiemensHR.utils;
using SiemensHR.Classes;
using SiemensTM.Classes;
using SiemensTM.utils;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for RetineriAngajat.
	/// </summary>
	public class RetineriAngajat : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;

		public long AngajatID;
		public long lunaID;
		public DateTime dataStartLunaActiva;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.DropDownList ddlTipuriRetineri;
		protected System.Web.UI.WebControls.TextBox txtRetinere;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldRegExprDescriere;
		protected System.Web.UI.WebControls.TextBox txtDataStart;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.TextBox txtDataEnd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.TextBox txtValoare;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.CompareValidator Comparevalidator7;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkAlerta;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnAdaugaRetinere;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnModificaRetinere;
		protected System.Web.UI.HtmlControls.HtmlInputButton btnStergeRetinere;
		protected System.Web.UI.HtmlControls.HtmlInputText DateStart;
		protected System.Web.UI.HtmlControls.HtmlInputText DateEnd;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtRetinereID;
		public string actiuneRetinere;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			#region variabile javascript
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			
			Response.Write( "<script>var DateStartID = '"+this.DateStart.ClientID+"';</script>");
			Response.Write( "<script>var DateEndID = '"+this.DateEnd.ClientID+"';</script>");
			Response.Write( "<script>var ddlTipuriRetineriClient = '"+this.ddlTipuriRetineri.ClientID+"';</script>");
			Response.Write( "<script>var txtDenumireRetinereClient = '"+this.txtRetinere.ClientID+"';</script>");
			Response.Write( "<script>var txtDataStartClient = '"+this.txtDataStart.ClientID+"';</script>");
			Response.Write( "<script>var txtDataEndClient = '"+this.txtDataEnd.ClientID+"';</script>");
			Response.Write( "<script>var txtValoareClient = '"+this.txtValoare.ClientID+"';</script>");
			Response.Write( "<script>var chkAlertaClient = '"+this.chkAlerta.ClientID+"';</script>");
			Response.Write( "<script>var txtRetinereIdClient = '"+this.txtRetinereID.ClientID+"';</script>");
			#endregion

			string[] textTabs = {"Lista retineri angajat", "Adauga retinere angajat"};
			LoadRetineriAngajat();
			SiemensTM.utils.Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "../", true);
			Response.Write("<script> var TipUtilizator = ''; </script>");

			#region angajat, luna activa
			Salaries.Business.Angajat objAngajat = new Salaries.Business.Angajat();
			objAngajat.AngajatId = AngajatID;
			objAngajat.LoadAngajat();
			
			Salaries.Business.Luni luni = new Salaries.Business.Luni( objAngajat.AngajatorId );
			Salaries.Data.LunaData lunaData = luni.GetLunaActiva();
			lunaID = lunaData.LunaId;
			dataStartLunaActiva = lunaData.Data;
			#endregion

			Response.Write("<script> LunaActivaDataStart =  '"+dataStartLunaActiva.ToString("dd.MM.yyyy")+"'</script>");			
			
			actiuneRetinere = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtActiuneRetinere" )).Value;
			if (IsPostBack)
			{
				TransferDateRetinereLaClient();
				HandleActions();
			}
			else
			{
				LoadTipuriRetineri();
				TransferDateRetinereLaClient();
			}
		}
		#endregion

		#region Render
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render (writer);
			
			Salaries.Business.Angajat objAngajat = new Salaries.Business.Angajat();
			objAngajat.AngajatId = AngajatID;
			objAngajat.LoadAngajat();
			
			/* Description:Pentru a nu se permite introducerea unui tip de absenta cand angajatul este lichidat, 
			 * este obtinuta data lichidarii si scrisa pe javascript pentru a se putea face validarile.
			 */
			string dataLichidare;
			if((DateTime.Equals(objAngajat.DataLichidare, System.DBNull.Value)) || (DateTime.Equals(objAngajat.DataLichidare,DateTime.MinValue)))
				dataLichidare = DateTime.MaxValue.ToString("dd.MM.yyyy");
			else
				dataLichidare = objAngajat.DataLichidare.ToString("dd.MM.yyyy");
			Response.Write("<script>DataLichidare =  '"+dataLichidare+"'</script>");
			
			DateTime DataAngajare = objAngajat.DataDeLa;
			Response.Write("<script>AngajareDataStart =  '"+DataAngajare.ToString("dd.MM.yyyy")+"'</script>");	
			
			//Response.Write( "<script>var CheckIntreruperi = '"+this.CheckInterval.ClientID+"';</script>");
//			//Response.Write( "<script>var IntervIntreruperiID = '"+this.txtIntrerupereID.ClientID+"';</script>");
//			Response.Write( "<script>var ObservatiiIDIntrerupere = '"+this.txtObservatii.ClientID+"';</script>");
//			Response.Write( "<script>var ClientObservatiiID = '"+this.txtObservatii.ClientID+"';</script>");
//					
			//string valoare = "<script>var tmpIntreruperi = new CreateIntervalIntreruperiElement('"+this.ClientID+"','"+this.txtDataStart.ClientID+"','"+this.txtDataEnd.ClientID+"','"+this.txtRetinereID.ClientID+"',null,'"+this.txtObservatii.ClientID+"');</script>";
			//Response.Write( valoare );	
		}
		#endregion

		#region ValidareDate
		/// <summary>
		/// Se face validarea datelor inanite de a adauga/modfica o retinere.
		/// </summary>
		/// <returns>Returneaza true daca datele sunt corecte si false altfel</returns>
		private bool ValidareDate()
		{
			//campurile trebuie completate obligatoriu
			if ((this.txtDataStart.Text == "") ||
				(this.txtDataEnd.Text == "") ||
				(this.txtValoare.Text == ""))
				return false;

			//campurile trebuie sa fie valori reale
			Regex expresieDouble = new Regex(@"^[0-9][0-9]*([.]|[,])*[0-9]*$");
			if (!expresieDouble.IsMatch(this.txtValoare.Text))
				return false;
			return true;
		}
		#endregion

		#region HandleActions
		/// <summary>
		/// Executa operatia
		/// </summary>
		private void HandleActions()
		{
			switch( actiuneRetinere )
			{
				case "adaugaRetinere":
					if (ValidareDate())
					{
						btnAdauga_Click();
						actiuneRetinere = "";
						((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtActiuneRetinere" )).Value = "";
					}
					else
					{
						Response.Write("<script> alert('Trebuie sa completati corect campurile!'); </script>");
					}
					break;
				case "modificaRetinere":
					if (ValidareDate())
					{
						btnModificaDate_Click();
						actiuneRetinere = "";
						((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtActiuneRetinere" )).Value = "";
					}
					else
					{
						Response.Write("<script> alert('Trebuie sa completati corect campurile!'); </script>");
					}
					break;
				case "stergeRetinere":
					if (ValidareDate())
					{
						btnStergeDate_Click();
						actiuneRetinere = "";
						((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtActiuneRetinere" )).Value = "";
					}
					else
					{
						Response.Write("<script> alert('Trebuie sa completati corect campurile!'); </script>");
					}
					break;
				default:
					break;
			}
		}
		#endregion

		#region TransferDateRetinereLaClient
		private void TransferDateRetinereLaClient()
		{	
			//actiuneRetinere = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtActiuneRetinere" )).Value;
			txtRetinere.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDenumireRetinereHidden" )).Value;
			if (((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "tipRetinereHidden" )).Value != "")
			{
				ddlTipuriRetineri.SelectedValue = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "tipRetinereHidden" )).Value;
			}
			txtDataStart.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDataStartRetinereHidden" )).Value;
			txtDataEnd.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDataEndRetinereHidden" )).Value;
			txtValoare.Text = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtValoareRetinereHidden" )).Value;
			txtRetinereID.Value = ((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetinereIdHidden" )).Value;
			chkAlerta.Checked = ((System.Web.UI.HtmlControls.HtmlInputCheckBox)Page.FindControl( "chkAlertaRetinereHidden" )).Checked;
		
			EmptyMainHiddenTextBoxes();
		}
		#endregion

		#region EmptyMainHiddenTextBoxes
		/// <summary>
		/// Se golesc valorile controalelor
		/// </summary>
		private void EmptyMainHiddenTextBoxes()
		{
			//((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtActiuneRetinere" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDenumireRetinereHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "tipRetinereHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDataStartRetinereHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtDataEndRetinereHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtValoareRetinereHidden" )).Value = "";
			((System.Web.UI.HtmlControls.HtmlInputHidden)Page.FindControl( "txtRetinereIdHidden" )).Value = "-1";
			//((System.Web.UI.HtmlControls.HtmlInputCheckBox)Page.FindControl( "chkAlertaRetinereHidden" )).Value = "";
		}
		#endregion

		#region LoadRetineriAngajat
		/// <summary>
		/// Listeaza retinerile unui angajat 
		/// </summary>
		private void LoadRetineriAngajat()
		{
			try
			{
				listTable.Rows.Clear();

				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

				Salaries.Business.RetineriRecurenteAngajat retineriBL = new Salaries.Business.RetineriRecurenteAngajat();
				retineriBL.RetAng.AngajatID = AngajatID;
				
				string[] arHeader = {"Tip retinere", "Denumire", "Data de inceput", "Data de sfarsit", "Valoare", "Alerta"};
				string[] arCols = {"TipRetinere", "DenumireRetinere", "DataInceput", "DataSfarsit", "Valoare", "Alerta"};
				
				SiemensHR.Classes.ListTable objListTable = new SiemensHR.Classes.ListTable(listTable, retineriBL.LoadRetineriAngajat(), arHeader, arCols);
				objListTable.textForEmptyDataSet = "Nu exista nici o retinere asociata acestui angajat!";

				//string[] ar_OnClickParam = { AngajatID.ToString(), "IdRetinere", "AngajatID", "DataInceput", "DataSfarsit", "Valoare", "Alerta"};
				//string[] ar_OnClickParamType = { "const", "dataset", "dataset", "dataset", "dataset"};
				string[] ar_OnClickParam = { "IdRetinere", "AngajatID", "TipRetinere", "DenumireRetinere", "DataInceput", "DataSfarsit", "Valoare", "Alerta"};
				string[] ar_OnClickParamType = { "dataset", "dataset", "dataset", "dataset", "dataset", "dataset", "dataset", "dataset"};
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectSuspendareCIM";

				objListTable.DrawListTableWithoutDigits();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}	
		}
		#endregion

		#region LoadTipuriRetineri
		public void LoadTipuriRetineri()
		{
			Salaries.Business.TypesOfRestraints retBL = new Salaries.Business.TypesOfRestraints();
			DataSet dsTipuriRetineri = retBL.GetLabels((int)lunaID);
			//ddlTipuriRetineri.DataSource = dsTipuriRetineri;
			//ddlTipuriRetineri.DataTextField = "Denumire";
			//ddlTipuriRetineri.DataValueField = "Nume";
			//ddlTipuriRetineri.DataBind();

            
			foreach(DataRow dr in dsTipuriRetineri.Tables[0].Rows)
			{
				if (!dr["Eticheta"].ToString().Equals(""))
				{
					ListItem tipItem;
					tipItem = new ListItem(dr["Denumire"].ToString(), dr["Nume"].ToString());
					ddlTipuriRetineri.Items.Add(tipItem);
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdauga_Click
		/// <summary>
		/// Adauga o retinere
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdauga_Click()
		{
			ErrHandler.MyErrHandler.WriteError("RetineriAngajat.ascx - start - AdaugaRetinere() - angID: " + AngajatID + " - " + txtDataStart.Text + " - " + txtDataEnd.Text);
			try
			{
				DateTime dataStart = SiemensTM.utils.Utilities.ConvertText2DateTime( txtDataStart.Text/*DateStart.Value*/ );
				DateTime dataEnd = SiemensTM.utils.Utilities.ConvertText2DateTime( txtDataEnd.Text/*DateEnd.Value*/ );
				string denumireRetinere = txtRetinere.Text;
				decimal valoare = decimal.Parse(txtValoare.Text);
				string tipRetinere = ddlTipuriRetineri.SelectedValue;
				bool alerta = chkAlerta.Checked;
				int retinereId = Convert.ToInt32(txtRetinereID.Value);

				DateTime data1 = new DateTime(dataStart.Year, dataStart.Month, 1);
				DateTime data2;
				if (dataEnd.Month !=  12)
				{
					data2 = new DateTime(dataEnd.Year, dataEnd.Month+1, 1);
					data2 = data2.AddDays(-1);
				}
				else
				{
					data2 = new DateTime(dataEnd.Year, dataEnd.Month, 31);
				}	
				//data de start as cam vrea sa fie in luna activa pentru a nu avea probleme cu legaturile catre tipul de retinere
				if (data1 != dataStartLunaActiva || data2 < dataStartLunaActiva)
				{
					Response.Write("<script> alert('Data de inceput trebuie sa fie in luna activa si data de sfarsit trebuie sa fie dupa data de inceput!'); </script>");
					return;
				}
				
				//sa verific daca pot adauga, daca nu exista inca o retinere cu acelasi tip de retinere si perioada intersectatat
				Salaries.Business.RetineriRecurenteAngajat ret = new Salaries.Business.RetineriRecurenteAngajat();
				ret.RetAng.AngajatID = AngajatID;
				ret.RetAng.IdRetinere = retinereId;
				ret.RetAng.TipRetinere = tipRetinere;
				ret.RetAng.DenumireRetinere = denumireRetinere;
				ret.RetAng.DataInceput = data1;
				ret.RetAng.DataSfarsit = data2;
				ret.RetAng.Valoare = valoare;
				ret.RetAng.Alerta = alerta;
				if (ret.VerificaIntersectieNrRetineri() == 0)
				{
					ret.InsertRetinereRecurentaAngajat();
				}
				else
				{
					Response.Write("<script> alert('Nu se poate introduce acelasi tip de retinere pentru perioade ce se intersecteaza!'); </script>");
				}

				//daca am perioada activa trebuie sa modific valorile retinerilor
				//actualizarea retinerilor
				if (ret.RetAng.DataInceput <= dataStartLunaActiva && dataStartLunaActiva <= ret.RetAng.DataSfarsit)
				{
					Salaries.Business.TipuriRetineriValori tipuri = new Salaries.Business.TipuriRetineriValori();
					tipuri.UpdateValoareRetinere((int) lunaID, AngajatID, ret.RetAng.TipRetinere, ret.RetAng.Valoare);
				}

				Salaries.Business.SituatieLunaraAngajat sitAngajat = new Salaries.Business.SituatieLunaraAngajat(AngajatID);
				sitAngajat.GenerareSituatieLunaraAngajat((int)AngajatID, (int)lunaID);
				
				LoadRetineriAngajat();
				this.txtDataStart.Text = "";
				this.txtDataEnd.Text = "";
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
				ErrHandler.MyErrHandler.WriteError("RetineriAngajat.ascx - error - - angID: " + AngajatID + " - " + ex.Message);
			}
			ErrHandler.MyErrHandler.WriteError("RetineriAngajat.ascx - end - AdaugaRetinere() - angID: " + AngajatID);
		}
		#endregion

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica o intrerupere CIM
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click()
		{
			ErrHandler.MyErrHandler.WriteError("RetineriAngajat.ascx - start - ModificaRetinere() - angID: " + AngajatID + " - " + txtDataStart.Text + " - " + txtDataEnd.Text);
			try
			{
				int retinereId = Convert.ToInt32(txtRetinereID.Value);
				Salaries.Business.RetineriRecurenteAngajat ret = new Salaries.Business.RetineriRecurenteAngajat();
				ret.GetRetinere(retinereId);
				Salaries.Business.RetineriRecurenteAngajat retinereVeche = ret;
				DateTime dataStart = SiemensTM.utils.Utilities.ConvertText2DateTime( txtDataStart.Text/*DateStart.Value*/ );
				DateTime dataEnd = SiemensTM.utils.Utilities.ConvertText2DateTime( txtDataEnd.Text/*DateEnd.Value*/ );
				string tipRetinere = ddlTipuriRetineri.SelectedValue;
				string denumireRetinere = txtRetinere.Text;
				decimal valoare = decimal.Parse(txtValoare.Text);
				bool alerta = chkAlerta.Checked;				
				DateTime data1 = new DateTime(dataStart.Year, dataStart.Month, 1);
				DateTime data2;
				if (dataEnd.Month !=  12)
				{
					data2 = new DateTime(dataEnd.Year, dataEnd.Month+1, 1);
					data2 = data2.AddDays(-1);
				}
				else
				{
					data2 = new DateTime(dataEnd.Year, dataEnd.Month, 31);
				}
				
				//daca noile date sunt inaintea lunii active
				if (data1.CompareTo(ret.RetAng.DataInceput) != 0 && data1 < dataStartLunaActiva)
				{
					Response.Write("<script> alert('Nu se pot modifica retinerile pentru lunile anterioare') </script>");
					return;
				}
				if ( (data1.CompareTo(ret.RetAng.DataInceput) > 0 || (data1.CompareTo(ret.RetAng.DataInceput)==0 && (data1.CompareTo(dataStartLunaActiva)<0)) )
						&& data2 >= dataStartLunaActiva && valoare != ret.RetAng.Valoare)
				{
					Response.Write("<script> alert('Se vor realiza doua intervale separate pentru ca difera valorile retinerii pentru lunile anterioare si cele viitoare'); </script>");
					//se face update la retinerea deja existenta...se modifica data sfarsit si anume pana la luna activa
					ret.RetAng.DataSfarsit = dataStartLunaActiva.AddDays(-1);
					ret.UpdateRetinereRecurentaAngajat();
					//se adauga o noua inregistrare cu noua retinere
					ret.RetAng.AngajatID = AngajatID;
					ret.RetAng.IdRetinere = 0;
					ret.RetAng.TipRetinere = tipRetinere;
					ret.RetAng.DenumireRetinere = denumireRetinere;
					ret.RetAng.DataInceput = dataStartLunaActiva;
					ret.RetAng.DataSfarsit = data2;
					ret.RetAng.Valoare = valoare;
					ret.RetAng.Alerta = alerta;
					ret.InsertRetinereRecurentaAngajat();
					
					//daca am perioada activa trebuie sa modific valorile retinerilor
					//actualizarea retinerilor
					if (ret.RetAng.DataInceput <= dataStartLunaActiva && dataStartLunaActiva <= ret.RetAng.DataSfarsit)
					{
						Salaries.Business.TipuriRetineriValori tipuri = new Salaries.Business.TipuriRetineriValori();
						tipuri.UpdateValoareRetinere((int)lunaID, AngajatID, ret.RetAng.TipRetinere, ret.RetAng.Valoare);
					}

					LoadRetineriAngajat();
					this.txtDataStart.Text = "";
					this.txtDataEnd.Text = "";
					return;
				}

				// in rest	se face modificare...inseamna ca se modifica doar alerta sau datele astfel incat sa nu influeneteze					
				ret = new Salaries.Business.RetineriRecurenteAngajat();
				ret.RetAng.AngajatID = AngajatID;
				ret.RetAng.IdRetinere = retinereId;
				ret.RetAng.TipRetinere = tipRetinere;
				ret.RetAng.DenumireRetinere = denumireRetinere;
				ret.RetAng.DataInceput = data1;
				ret.RetAng.DataSfarsit = data2;
				ret.RetAng.Valoare = valoare;
				ret.RetAng.Alerta = alerta;
				ret.UpdateRetinereRecurentaAngajat();

				//daca am perioada activa trebuie sa modific valorile retinerilor
				//actualizarea retinerilor
				if (ret.RetAng.DataInceput <= dataStartLunaActiva && dataStartLunaActiva <= ret.RetAng.DataSfarsit && retinereVeche.RetAng.Valoare!=ret.RetAng.Valoare)
				{
					Salaries.Business.TipuriRetineriValori tipuri = new Salaries.Business.TipuriRetineriValori();
					tipuri.UpdateValoareRetinere((int)lunaID, AngajatID, ret.RetAng.TipRetinere, ret.RetAng.Valoare);
				}

				Salaries.Business.SituatieLunaraAngajat sitAngajat = new Salaries.Business.SituatieLunaraAngajat(AngajatID);
				sitAngajat.GenerareSituatieLunaraAngajat((int)AngajatID, (int)lunaID);

				LoadRetineriAngajat();
				this.txtDataStart.Text = "";
				this.txtDataEnd.Text = "";
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
				ErrHandler.MyErrHandler.WriteError("RetineriAngajat.ascx - error - ModificaRetinere() - angID: " + AngajatID + " - " + ex.Message);
			}
			ErrHandler.MyErrHandler.WriteError("RetineriAngajat.ascx - end - ModificaRetinere() - angID: " + AngajatID);
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge o intrerupere CIM
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click()
		{
			ErrHandler.MyErrHandler.WriteError("RetineriAngajat.ascx - start - StergeRetinere() - angID: " + AngajatID  + " - " + txtDataStart.Text + " - " + txtDataEnd.Text);
			int retinereId = Convert.ToInt32(txtRetinereID.Value);
			Salaries.Business.RetineriRecurenteAngajat ret = new Salaries.Business.RetineriRecurenteAngajat();
			ret.GetRetinere(retinereId);
			DateTime dataStart = ret.RetAng.DataInceput;
			DateTime dataEnd = ret.RetAng.DataSfarsit;
			DateTime data1 = new DateTime(dataStart.Year, dataStart.Month, 1);
			DateTime data2;
			if (dataEnd.Month !=  12)
			{
				data2 = new DateTime(dataEnd.Year, dataEnd.Month+1, 1);
				data2 = data2.AddDays(-1);
			}
			else
			{
				data2 = new DateTime(dataEnd.Year, dataEnd.Month, 31);
			}

			if (data1.CompareTo(ret.RetAng.DataInceput) != 0 && data1 < dataStartLunaActiva)
			{
				Response.Write("<script> alert('Nu se pot modifica retinerile pentru lunile anterioare'); </script>");
				return;
			}
			//if (data1.CompareTo(ret.RetAng.DataInceput) >= 0 && data2 >= dataStartLunaActiva )
			 if ( (data1.CompareTo(ret.RetAng.DataInceput) > 0 || (data1.CompareTo(ret.RetAng.DataInceput)==0 && (data1.CompareTo(dataStartLunaActiva)<0)) )
				&& data2 >= dataStartLunaActiva)
			{
				Response.Write("<script> alert('Se va updata intervalul astfel incat sa ramana doar perioada dinaintea lunii active.'); </script>");
				//se face update la retinerea deja existenta...se modifica data sfarsit si anume pana la luna activa
				ret.RetAng.DataSfarsit = dataStartLunaActiva.AddDays(-1);
				ret.UpdateRetinereRecurentaAngajat();
				LoadRetineriAngajat();
				this.txtDataStart.Text = "";
				this.txtDataEnd.Text = "";
				return;
			}
						
			//daca am perioada activa trebuie sa modific valorile retinerilor
			//actualizarea retinerilor
			if (ret.RetAng.DataInceput <= dataStartLunaActiva && dataStartLunaActiva <= ret.RetAng.DataSfarsit)
			{
				Salaries.Business.TipuriRetineriValori tipuri = new Salaries.Business.TipuriRetineriValori();
				tipuri.UpdateValoareRetinere((int)lunaID, AngajatID, ret.RetAng.TipRetinere, 0);
			}
			ret.DeleteRetinereRecurentaAngajat();

			Salaries.Business.SituatieLunaraAngajat sitAngajat = new Salaries.Business.SituatieLunaraAngajat(AngajatID);
			sitAngajat.GenerareSituatieLunaraAngajat((int)AngajatID, (int)lunaID);

			LoadRetineriAngajat();
			this.txtDataStart.Text = "";
			this.txtDataEnd.Text = "";

			ErrHandler.MyErrHandler.WriteError("RetineriAngajat.ascx - end - StergeRetinere() - angID: " + AngajatID);
		}
		#endregion

	}
}
