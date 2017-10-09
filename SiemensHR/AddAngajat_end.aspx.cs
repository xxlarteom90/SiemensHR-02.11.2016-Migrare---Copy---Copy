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

using SiemensHR.Classes;

namespace SiemensHR
{
	/// <summary>
	/// Summary description for AddAngajat_end.
	/// </summary>
	public class AddAngajat_end : System.Web.UI.Page
	{
		#region Variabile
		protected System.Web.UI.WebControls.Button btnAddAngaajt;
		protected System.Web.UI.WebControls.Button btnEditAngajat;
		protected System.Web.UI.WebControls.Literal litError;
		private long AngajatID;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
				AngajatID = Convert.ToInt64(Request.QueryString["idAngajat"].ToString());
			else
				AngajatID = Convert.ToInt64(Request.Form["idAngajat"]);
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
			this.btnAddAngaajt.Click += new System.EventHandler(this.btnAddAngajat_Click);
			this.btnEditAngajat.Click += new System.EventHandler(this.btnEditAngajat_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAddAngajat_Click
		/// <summary>
		/// Procedura redirecteaza catre pagina pentru adaugarea unui angajat
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddAngajat_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AddAngajat.aspx");
		}
		#endregion

		#region btnEditAngajat_Click
		/// <summary>
		/// Procedura redirecteaza catre pagina pentru editarea unui angajat
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEditAngajat_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("EditAngajat.aspx?id=" + AngajatID + "&alerta=edit_angajat");
		}
		#endregion
	}
}
