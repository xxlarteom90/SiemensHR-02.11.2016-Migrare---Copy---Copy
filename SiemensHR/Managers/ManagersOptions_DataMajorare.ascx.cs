/*
 *	Autor:		Ciobanu Alex 
 *  Data:		17.8.2005
 *	Denumire:	ManagersOptions_DataMajorare.ascx.cs
 *	Descriere:	Controlul permite utilizatorului sa selecteze datele de inceput si de sfarsit ale perioadei 
 *				de timp pe care doreste sa fie afisat raportul pentru datele de majorare ale angajatilor si 
 *				sa vizualizeze aceste date.
*/	

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Salaries.Data;

namespace SiemensHR
{
	/// <summary>
	///		Summary description for ManagersOptions_DataMajorare.
	/// </summary>
	public class ManagersOptions_DataMajorare : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.TextBox txtDataStart;
		protected System.Web.UI.WebControls.TextBox txtDataStop;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.Label numeDept;
		protected System.Web.UI.WebControls.Button btnAfiseaza;
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolder1;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.numeDept.Text = Parameters.NumeDepartament;
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
			this.btnAfiseaza.Click += new System.EventHandler(this.btnAfiseaza_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region btnAfiseaza_Click
		/// <summary>
		/// Afiseaza raportul
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAfiseaza_Click(object sender, System.EventArgs e)
		{
			MO_DataMajorareRaport myMODMR = (MO_DataMajorareRaport) LoadControl("MO_DataMajorareRaport.ascx");
			myMODMR.DataStart=Parameters.MKConv(txtDataStart.Text);
			myMODMR.DataStop=Parameters.MKConv(txtDataStop.Text);
			PlaceHolder1.Controls.Clear();
			PlaceHolder1.Controls.Add(myMODMR);
		}
		#endregion
	}
}
