using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.EditTasks
{
	/// <summary>
	///		Summary description for IstoricCartiIdentitate.
	/// </summary>
	public class IstoricCartiIdentitate : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
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
		protected System.Web.UI.WebControls.Button btnAdaugaDepartament;
		protected System.Web.UI.WebControls.Button btnModificaDate;
		protected System.Web.UI.WebControls.Button btnStergeDate;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActivSeparator;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActiv;
		protected System.Web.UI.HtmlControls.HtmlInputCheckBox chkActiv;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtCarteIdentitateIDHidden;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCNPAnterior;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredSerie;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredNumar;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredEliberatDe;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator vldRegExprDescriere;

		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
		
			btnStergeDate.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti aceasta inregistrare?')");

			string[] textTabs = {"Istoric carti de identitate", "Adauga carte de identitate"};
			LoadIstoricCartiIdentitate();

			if (Session["Recrutori"].ToString() == "Recrutori")
			{
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "../", true);
				Response.Write("<script> var TipUtilizator = 'Recrutor'; </script>");
			}
			else
			{
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", true);
				Response.Write("<script> var TipUtilizator = ''; </script>");
			}
		}
		#endregion

		#region LoadIstoricCartiIdentitate
		/// <summary>
		/// Listeaza cartile de identitate
		/// </summary>
		private void LoadIstoricCartiIdentitate()
		{
			try
			{
				listTable.Rows.Clear();

				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

				Salaries.Business.IstoricCartiIdentitate istCI = new Salaries.Business.IstoricCartiIdentitate();
				istCI.AngajatId = AngajatID;
				
				string[] arHeader = {"CNP", "CNP anterior", "Serie", "Numar", "Eliberat de", "Data eliberare", "Valabil pana la", "Activ"};
				string[] arCols = { "CNP", "CNPAnterior", "Serie", "Numar", "EliberatDe", "DataEliberarii", "ValabilPanaLa", "Activ"};
				
				ListTable objListTable = new ListTable(listTable, istCI.LoadIstoricCartiIdentitate(), arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista nici o carte de identitate asociata acestui angajat!";

				string[] ar_OnClickParam = { AngajatID.ToString(), "CarteIdentitateID", "CNP", "CNPAnterior", "Serie", "Numar", "EliberatDe", "DataEliberarii", "ValabilPanaLa", "Activ" };
				string[] ar_OnClickParamType = { "const", "dataset", "dataset", "dataset", "dataset", "dataset", "dataset", "dataset", "dataset", "dataset" };
			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;
				objListTable.OnclickJSMethod = "SelectCarteIdentitate";

				objListTable.DrawListTableWithoutDigits();
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
			this.btnAdaugaDepartament.Click += new System.EventHandler(this.btnAdaugaCarteIdentitate_Click);
			this.btnModificaDate.Click += new System.EventHandler(this.btnModificaDate_Click);
			this.btnStergeDate.Click += new System.EventHandler(this.btnStergeDate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAdaugaCarteIdentitate_Click
		/// <summary>
		/// Adauga o carte de identitate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaCarteIdentitate_Click(object sender, System.EventArgs e)
		{
			try
			{
				long CNP = 0;
				try
				{
					CNP = long.Parse( txtCNP.Text );
				}
				catch{}
				long CNPAnterior = 0;
				try
				{
					CNPAnterior = long.Parse( txtCNPAnterior.Text );
				}
				catch{}

				string serie = txtCISerie.Text;
				string numar = txtCINumar.Text;
//				long numar = 0;
//				try
//				{
//					numar = Convert.ToInt64( txtCINumar.Text );
//				}
//				catch{}
				string eliberatDe = txtCIEliberatDe.Text;
				DateTime dataEliberarii = Utilities.ConvertText2DateTime( txtCIDataEliberarii.Text );
				DateTime valabilPanaLa = Utilities.ConvertText2DateTime( txtCIValabilPanaLa.Text );

				bool activ = chkActiv.Checked;

				Salaries.Business.IstoricCartiIdentitate istCI = new Salaries.Business.IstoricCartiIdentitate();
				istCI.CarteIdentitateId = 0;
				istCI.AngajatId = AngajatID;
				istCI.CNP = CNP;
				istCI.CNPAnterior = CNPAnterior;
				istCI.Serie = serie;
				istCI.Numar = numar;
				istCI.EliberatDe = eliberatDe;
				istCI.DataEliberarii = dataEliberarii;
				istCI.ValabilPanaLa = valabilPanaLa;
				istCI.Activ = activ;

				if( !istCI.InsertCarteIdentitate() )
				{
					Response.Write( "<script>alert( 'Adaugarea nu a fost facuta, deoarece exista deja o carte de identitate cu aceleasi date!' )</script>" );
				}
				else
				{
					LoadIstoricCartiIdentitate();
				}

			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnModificaDate_Click
		/// <summary>
		/// Modifica o carte de identitate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModificaDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				int CarteIdentitateID = Convert.ToInt32(txtCarteIdentitateIDHidden.Value);
								
				long CNP = 0;
				try
				{
					CNP = long.Parse( txtCNP.Text );
				}
				catch{}
				long CNPAnterior = 0;
				try
				{
					CNPAnterior = long.Parse( txtCNPAnterior.Text );
				}
				catch{}

				string serie = txtCISerie.Text;
				string numar = txtCINumar.Text;
//				long numar = 0;
//				try
//				{
//					numar = Convert.ToInt64( txtCINumar.Text );
//				}
//				catch{}
				string eliberatDe = txtCIEliberatDe.Text;
				DateTime dataEliberarii = Utilities.ConvertText2DateTime( txtCIDataEliberarii.Text );
				DateTime valabilPanaLa = Utilities.ConvertText2DateTime( txtCIValabilPanaLa.Text );

				bool activ = chkActiv.Checked;

				Salaries.Business.IstoricCartiIdentitate istCI = new Salaries.Business.IstoricCartiIdentitate();
				istCI.CarteIdentitateId = CarteIdentitateID;
				istCI.AngajatId = AngajatID;
				istCI.CNP = CNP;
				istCI.CNPAnterior = CNPAnterior;
				istCI.Serie = serie;
				istCI.Numar = numar;
				istCI.EliberatDe = eliberatDe;
				istCI.DataEliberarii = dataEliberarii;
				istCI.ValabilPanaLa = valabilPanaLa;
				istCI.Activ = activ;

				if( !istCI.UpdateCarteIdentitate() )
				{
					Response.Write( "<script>alert( 'Modificarea nu a fost facuta, deoarece mai exista o carte de identitate cu aceleasi date!' )</script>" );
				}
				else
				{
					LoadIstoricCartiIdentitate();
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region btnStergeDate_Click
		/// <summary>
		/// Sterge o carte de identitate
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStergeDate_Click(object sender, System.EventArgs e)
		{
			try
			{
				int carteIdentiateId = Convert.ToInt32(txtCarteIdentitateIDHidden.Value);
				Salaries.Business.IstoricCartiIdentitate istCI = new Salaries.Business.IstoricCartiIdentitate();
				istCI.CarteIdentitateId = carteIdentiateId;

				if(!chkActiv.Checked)
				{
					istCI.DeleteCarteIdentitate();
				}
				else
				{
					Response.Write( "<script>alert( 'Nu se poate sterge o carte de identitate activa!' )</script>" );
				}
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadIstoricCartiIdentitate();
		}
		#endregion
	}
}
