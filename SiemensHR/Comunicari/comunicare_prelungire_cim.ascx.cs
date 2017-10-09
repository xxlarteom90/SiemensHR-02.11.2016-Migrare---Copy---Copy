namespace SiemensHR.Comunicari
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using SiemensHR.Classes;
	using SiemensHR.utils;

	/// <summary>
	///		Summary description for comunicare_prelungire_cim.
	/// </summary>
	public class comunicare_prelungire_cim : System.Web.UI.UserControl
	{
		#region variabile
		protected System.Web.UI.WebControls.Table Table2;
		protected System.Web.UI.WebControls.Label lblCmpObl;
		protected System.Web.UI.WebControls.Button btnGenerati;
		protected System.Web.UI.WebControls.TextBox txtDataDeLa;
		protected System.Web.UI.WebControls.TextBox txtDataPanaLa;
		protected System.Web.UI.HtmlControls.HtmlSelect lstPerAngajarii;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataPanaLa;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredDataDeLa;
		protected System.Web.UI.WebControls.Label lblEroare;
		protected System.Web.UI.WebControls.ValidationSummary sumarValidare;
		protected System.Web.UI.WebControls.TextBox txtNumarComunicare;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqNumarComunicare;
		protected System.Web.UI.WebControls.TextBox txtDataGenerarii;
		protected System.Web.UI.WebControls.RequiredFieldValidator reqDataGenerarii;
		public Salaries.Business.Angajat objAngajat;
		#endregion

		#region page load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			if (objAngajat.IsLichidat)
			{
				btnGenerati.Enabled = false;
				lstPerAngajarii.Disabled = true;
				txtDataDeLa.Enabled = false;
				txtDataPanaLa.Enabled=false;

				lblEroare.Text = "Angajatul selectat este lichidat!";
			}
			else
			{
				Salaries.Business.Angajat dateAngajat = new Salaries.Business.Angajat();
				dateAngajat.AngajatId=Convert.ToInt32(objAngajat.AngajatId);
				DataTable dt = dateAngajat.GetDetaliiAngajat().Tables[0];

				foreach (DataRow dr in dt.Rows)
				{
					lstPerAngajarii.SelectedIndex=dr["PerioadaDeterminata"].ToString().Equals("True")?0:1;
					if(dr["DataDeLa"]!=DBNull.Value)
						txtDataDeLa.Text=Convert.ToDateTime(dr["DataDeLa"]).ToString("dd.MM.yyyy");
					if(dr["DataPanaLa"]!=DBNull.Value)
						txtDataPanaLa.Text=Convert.ToDateTime(dr["DataPanaLa"]).ToString("dd.MM.yyyy");
					txtDataGenerarii.Text = DateTime.Today.ToString("dd.MM.yyyy");
					break;
				}
			}

			//header de tabel
			Utilities.CreateTableHeader(Table2, "Comunicare prelungire contract individual de munca", "", "normal");	
		}
		#endregion

		#region Generarea comunicarii 
		private void btnGenerati_Click(object sender, System.EventArgs e)
		{
			Session["TipComunicare"] = "comunicare prelungire cim.xml";
			Session["NumarComunicare"] = txtNumarComunicare.Text;
			objAngajat.PerioadaDeterminata=(lstPerAngajarii.SelectedIndex==0);
			objAngajat.DataDeLa=Utilities.ConvertText2DateTime(txtDataDeLa.Text);
			if (objAngajat.PerioadaDeterminata)
			{
				objAngajat.DataPanaLa=Utilities.ConvertText2DateTime(txtDataPanaLa.Text);
			}
			else
			{
				objAngajat.DataPanaLa=DateTime.MinValue;
			}
			Response.Redirect("Comunicari/comunicare.aspx?id=" + objAngajat.AngajatId);
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
			this.btnGenerati.Click += new System.EventHandler(this.btnGenerati_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
	}
}
