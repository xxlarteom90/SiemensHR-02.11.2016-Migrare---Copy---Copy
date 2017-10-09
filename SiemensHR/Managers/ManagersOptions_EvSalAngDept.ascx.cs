using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//using Microsoft.Office.Interop.Owc11;

using Salaries.Data;

namespace SiemensHR
{
	/// <summary>
	///		Summary description for ManagersOptions_EvSalAngDept.
	/// </summary>
	public class ManagersOptions_EvSalAngDept : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox txtDataStop;
		protected System.Web.UI.WebControls.TextBox txtDataStart;
		protected System.Web.UI.WebControls.Label numeDept;
		protected System.Data.SqlClient.SqlDataAdapter DataAd;
		protected System.Data.SqlClient.SqlCommand SelCom;
		protected System.Data.SqlClient.SqlConnection Conn;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl div2;
		protected System.Web.UI.WebControls.Button btnAfiseaza;
		protected Salaries.Configuration.ModuleSettings settings;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Write("<script>\n\tvar ctrlID='"+this.UniqueID+"'\n\tvar toggle=1\n</script>");
			settings=Salaries.Configuration.ModuleConfig.GetSettings();
			this.Conn.ConnectionString=settings.ConnectionString;
			this.numeDept.Text = Parameters.NumeDepartament;
			if(!IsPostBack)
				div2.Style.Add("display","none");
			else{
				if (this.Hidden1.Value=="")
				{
					div2.Style.Clear();
					div2.Style.Add("DISPLAY","none");
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
			this.DataAd = new System.Data.SqlClient.SqlDataAdapter();
			this.SelCom = new System.Data.SqlClient.SqlCommand();
			this.Conn = new System.Data.SqlClient.SqlConnection();
			this.btnAfiseaza.Click += new System.EventHandler(this.btnAfiseaza_Click);
			// 
			// DataAd
			// 
			this.DataAd.SelectCommand = this.SelCom;
			// 
			// SelCom
			// 
			this.SelCom.CommandText = "[EvolutieSalariiAngajatiDept]";
			this.SelCom.CommandType = System.Data.CommandType.StoredProcedure;
			this.SelCom.Connection = this.Conn;
			this.SelCom.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dept", System.Data.SqlDbType.VarChar, 10));
			this.SelCom.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dataStop", System.Data.SqlDbType.DateTime, 8));
			this.SelCom.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dataStart", System.Data.SqlDbType.DateTime, 8));
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
			SelCom.Parameters["@dataStart"].Value=Parameters.MKConv(txtDataStart.Text);
			SelCom.Parameters["@dataStop"].Value=Parameters.MKConv(txtDataStop.Text);
			SelCom.Parameters["@dept"].Value=Parameters.NumeDepartament;
			DataSet ds=new DataSet("Set");
			DataAd.Fill(ds,"Results");
			if(ds.Tables["Results"].Rows.Count==0)
			{
				this.Hidden1.Value="";
				div2.Style.Clear();
				div2.Style.Add("font-weight","normal");
				return;
			}
			SelCom.Parameters.RemoveAt("@dept");
			SelCom.CommandText="[EGetLuniEvSalAngajatiDept]";
			DataAd.Fill(ds,"HelpData");
			DataTable dTable=new DataTable("Results");
			dTable.Columns.Add("Nume",Type.GetType("System.String"));
			foreach(DataRow row in ds.Tables["HelpData"].Rows)
				dTable.Columns.Add("Venit "+row["Data"]+" ",Type.GetType("System.Int32"));
			int i=0,j=0;
			DataRow d=dTable.NewRow();
			d["Nume"]=ds.Tables["Results"].Rows[j]["Nume"];
			dTable.Rows.Add(d);
			do
			{
				if(dTable.Rows[i]["Nume"].ToString()==ds.Tables["Results"].Rows[j]["Nume"].ToString())
				{
					dTable.Rows[i]["Venit "+ds.Tables["Results"].Rows[j]["Data"].ToString()+" "]=ds.Tables["Results"].Rows[j]["Venit"];
					j++;
				}
				else
				{
					d=dTable.NewRow();
					d["Nume"]=ds.Tables["Results"].Rows[j]["Nume"];
					dTable.Rows.Add(d);
					i++;
				}
			}while(j<ds.Tables["Results"].Rows.Count);
			ds.Dispose();
			string csvData="";
			for(int k=0; k<dTable.Columns.Count; k++)
				csvData+=",";
			csvData+="\n";
			foreach(DataColumn dc in dTable.Columns)
				csvData+=dc.ColumnName+",";
			csvData+="\n";
			foreach(DataRow drow in dTable.Rows)
			{
				foreach(object ob in drow.ItemArray)
					csvData+=ob.ToString()+",";
				csvData+="\n";
			}
			this.Hidden1.Value=csvData;
		}
		#endregion
	}
}
