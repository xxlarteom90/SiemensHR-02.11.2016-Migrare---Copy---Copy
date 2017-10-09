using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//using Microsoft.Office.Interop.Owc11;

using Salaries.Data;
using SiemensHR.Classes;

namespace SiemensHR
{
	/// <summary>
	///		Summary description for ManagersOptions_EvolutieSal.
	/// </summary>
	public class ManagersOptions_EvolutieSal : System.Web.UI.UserControl	
	{
		#region Variabile
		protected System.Web.UI.WebControls.DropDownList lstAngajati;
		protected Salaries.Configuration.ModuleSettings settings;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.Label numeDept;
		protected System.Web.UI.WebControls.Button btnAfiseaza;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolder1;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.numeDept.Text = Parameters.NumeDepartament;
			this.settings = Salaries.Configuration.ModuleConfig.GetSettings();
			if(!this.IsPostBack)
			{
				UtilitiesDb utilDb = new UtilitiesDb(settings.ConnectionString);
				utilDb.CreateAngajatiPeDeptSelectBox(this.lstAngajati,Parameters.NumeDepartament);
				if(lstAngajati.Items.Count!=0)
					Parameters.DataAngajat=lstAngajati.Items[0];
				else
				{
					Table t=new Table();
					t.Attributes.Add("class","tabBackground");
					t.Attributes.Add("borderColor","green");
					t.Attributes.Add("cellSpacing","6");
					TableRow tr=new TableRow();
					TableCell tc=new TableCell();
					t.Rows.Add(new TableRow());
					t.Rows[0].Cells.Add(new TableCell());
					t.Rows[0].Cells[0].Text=" ";
					t.Rows[0].Cells[0].Attributes.Add("class","NormalBlackBold");
					tc.Text="<font size='3'>Nu exista angajati asignati direct acestui departament!</font>";
					tc.Font.Size=3;
					tc.Attributes.Add("class","NormalBlackBold");
					tc.Attributes.Add("align","center");
					tr.Cells.Add(tc);
					t.Rows.Add(tr);
					t.Rows.Add(new TableRow());
					t.Rows[2].Cells.Add(new TableCell());
					t.Rows[2].Cells[0].Text="<font size='3'>Va rugam incercati in subdepartamentele asociate.</font>";
					t.Rows[2].Cells[0].Attributes.Add("class","NormalBlackBold");
					t.Rows[2].Cells[0].Attributes.Add("align","center");
					this.PlaceHolder1.Controls.Add(t);
					this.lstAngajati.Enabled=false;
					this.DropDownList1.Enabled=false;
					return;
				}
				this.lstAngajati.Enabled=true;
				this.DropDownList1.Enabled=true;
			}
			System.Web.UI.WebControls.Image img=new System.Web.UI.WebControls.Image();
			img.ImageUrl="MakeChart.aspx";
			this.PlaceHolder1.Controls.Add(img);
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
			this.lstAngajati.SelectedIndexChanged += new System.EventHandler(this.lstAngajati_SelectedIndexChanged);
			this.DropDownList1.SelectedIndexChanged += new System.EventHandler(this.DropDownList1_SelectedIndexChanged);
			this.btnAfiseaza.Click += new System.EventHandler(this.btnAfiseaza_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region lstAngajati_SelectedIndexChanged
		/// <summary>
		/// Se salveaza datele angajatului nou selectat
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstAngajati_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Parameters.DataAngajat=lstAngajati.SelectedItem;
		}
		#endregion

		#region DropDownList1_SelectedIndexChanged
		/// <summary>
		/// Se salveaza perioada de timp selectat pentru vizualizare
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Parameters.TimeSpan=int.Parse(this.DropDownList1.SelectedValue);
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
			Parameters.DataAngajat=lstAngajati.SelectedItem;
			Parameters.TimeSpan=int.Parse(this.DropDownList1.SelectedValue);
		}
		#endregion
	}
}
