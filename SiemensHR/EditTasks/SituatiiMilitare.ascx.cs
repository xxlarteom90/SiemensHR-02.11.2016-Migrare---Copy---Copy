using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.EditTasks
{
	/// <summary>
	///		Summary description for SituatieMilitara.
	/// </summary>
	public class SituatiiMilitare : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredProgramLucru;
		protected System.Web.UI.WebControls.Button butSaveAngajat;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.TextBox txtEvidentaCMJ;
		protected System.Web.UI.WebControls.TextBox txtDataIntrareEvidenta;
		protected System.Web.UI.WebControls.TextBox txtGradul;
		protected System.Web.UI.WebControls.TextBox txtSerieLivret;
		protected System.Web.UI.WebControls.TextBox txtNumarLivret;
		protected System.Web.UI.WebControls.TextBox txtSpecialitatiMilitare;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredCMJ;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularEvidenta;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularGrad;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularSerie;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularNumar;
		protected System.Web.UI.WebControls.RegularExpressionValidator regularSpecialitati;
		public Salaries.Business.Angajat objAngajat;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
				LoadSituatieMilitaraInfo();
		}
		#endregion

		#region LoadSituatieMilitaraInfo
		/// <summary>
		/// Afiseaza situatia militara a unui angajat
		/// </summary>
		private void LoadSituatieMilitaraInfo()
		{
			try
			{
				string[] textTabs = {"Editare date situatie militara"};
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "", false);

				txtEvidentaCMJ.Text = objAngajat.EvidentaCMJ;
				txtDataIntrareEvidenta.Text = Utilities.ConvertDateTime2Text(objAngajat.DataIntrareEvidenta);
				txtGradul.Text = objAngajat.Gradul;
				txtSerieLivret.Text = objAngajat.SerieLivret;
				txtNumarLivret.Text = objAngajat.NumarLivret;
				txtSpecialitatiMilitare.Text = objAngajat.SpecialitatiMilitara;

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
		/// Salveaza situatia militara a unui angajat
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void butSaveAngajat_Click(object sender, System.EventArgs e)
		{
			try
			{
				Salaries.Business.SituatieMilitara sitMilitara = new Salaries.Business.SituatieMilitara();
				sitMilitara.AngajatId = objAngajat.AngajatId;
				sitMilitara.DataIntrareEvidenta = Utilities.ConvertText2DateTime(txtDataIntrareEvidenta.Text);
				sitMilitara.EvidentaCMJ = txtEvidentaCMJ.Text;
				sitMilitara.Gradul = txtGradul.Text;
				sitMilitara.NumarLivret = txtNumarLivret.Text;
				sitMilitara.SerieLivret = txtSerieLivret.Text;
				sitMilitara.SpecialitatiMilitare = txtSpecialitatiMilitare.Text;
				sitMilitara.InsertUpdateSituatieMilitara();

				DataRow situatie = sitMilitara.GetSituatieMilitaraInfo().Tables[0].Rows[0];
				objAngajat.EvidentaCMJ = situatie["EvidentaCMJ"].ToString();
				objAngajat.DataIntrareEvidenta = DateTime.Parse(situatie["DataIntrareEvidenta"].ToString());
				objAngajat.Gradul = situatie["Gradul"].ToString();
				objAngajat.NumarLivret = situatie["NumarLivret"].ToString();
				objAngajat.SerieLivret = situatie["SerieLivret"].ToString();
				objAngajat.SpecialitatiMilitara = situatie["SpecialitatiMilitare"].ToString();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}	

			LoadSituatieMilitaraInfo();
		}
		#endregion
	}
}
