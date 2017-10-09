using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using SiemensHR.Classes;
using SiemensHR.utils;

namespace SiemensHR.EditTasks
{
	/// <summary>
	///		Summary description for NivelAngajat.
	/// </summary>
	/// 
	public class NivelAngajat : System.Web.UI.UserControl
	{
		#region Variabile

		protected System.Web.UI.WebControls.Image imgSpace;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.DataList listaNivele;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.WebControls.Button btnSalveaza;
		public long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			string script_text = "<script>var ctrlID = \""+this.UniqueID+"\"</script>";
			Response.Write(script_text);
			BindNiveleAngajat();
			//btnStergeDate.Attributes.Add("onclick", "return CheckDelete('Doriti sa stergeti acest cont?')");

		}
		#endregion

		#region BindNiveleAngajat
		private void BindNiveleAngajat()
		{
			Salaries.Business.NivelAngajat niv = new Salaries.Business.NivelAngajat();	
			niv.AngajatorId = Int32.Parse(Session["AngajatorID"].ToString());
			listaNivele.DataSource = niv.LoadNivelePentruAngajat(AngajatID);
			listaNivele.DataBind();
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
			this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSalveaza_Click(object sender, System.EventArgs e)
		{
			try
			{
				foreach(DataListItem it in listaNivele.Items)
				{
					int index = it.ItemIndex;
					int idNivel = Int32.Parse(listaNivele.DataKeys[index].ToString());
					System.Web.UI.WebControls.CheckBox chk = (System.Web.UI.WebControls.CheckBox) it.FindControl("checkBoxNivel");
					bool esteInNivel = chk.Checked;

					Salaries.Business.NivelAngajat niv = new Salaries.Business.NivelAngajat();	
					niv.AngajatorId = Int32.Parse(Session["AngajatorID"].ToString());
					niv.IdNivelAngajat = idNivel;
			
					if  (niv.EsteAngajatInNivel(AngajatID))
					{
						if (!esteInNivel)
							niv.RemoveAngajatFromNivel(AngajatID);
					}
					else
					{
						if (esteInNivel)
							niv.AddAngajatInNivel(AngajatID);
					}

				}
				BindNiveleAngajat();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
	}
}
