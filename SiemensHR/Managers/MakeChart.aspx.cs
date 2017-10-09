using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//using Microsoft.Office.Interop.Owc11;  // office 2003
//using OWC;  // office 2007
using Microsoft.Office.Interop;


using Salaries.Data;

namespace SiemensHR
{
	/// <summary>
	/// Summary description for MakeChart.
	/// </summary>
	public class MakeChart : System.Web.UI.Page
	{
		#region Variabile
		protected Salaries.Configuration.ModuleSettings settings;
		//protected ChartSpace cs; // office 2003
		protected System.Web.UI.WebControls.PlaceHolder PlaceHolder1;
		protected System.Data.SqlClient.SqlConnection Conn;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter DataAdapter;
		//protected ChChart cc;  // office 2003
		//protected WCChart cc; // office 2007
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{}
		#endregion

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			if(Parameters.DataAngajat==null)
			{
				return;
			}
			settings=Salaries.Configuration.ModuleConfig.GetSettings();
			Conn.ConnectionString=settings.ConnectionString;
			this.sqlSelectCommand1.Parameters["@dept"].Value=Parameters.NumeDepartament;
			this.sqlSelectCommand1.Parameters["@angid"].Value=Parameters.DataAngajat.Value;
			this.sqlSelectCommand1.Parameters["@tspan"].Value=Parameters.TimeSpan;
			DataSet ds=new DataSet("Salarii");
			DataAdapter.Fill(ds);
			Parameters.Chart_SetData(ds.Tables[0],"data","VenitNet","Evolutia salariului angajatului "+Parameters.DataAngajat.Text,"Timp","Salariu");
			Response.BinaryWrite(Parameters.Chart_MakePicture("gif",512,400));
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
			this.Conn = new System.Data.SqlClient.SqlConnection();
			this.DataAdapter = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			// 
			// DataAdapter
			// 
			this.DataAdapter.SelectCommand = this.sqlSelectCommand1;
			this.DataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																								  new System.Data.Common.DataTableMapping("Table", "EvolutieSalariu", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("Data", "Data"),
																																																					 new System.Data.Common.DataColumnMapping("VenitBrut", "VenitBrut"),
																																																					 new System.Data.Common.DataColumnMapping("VenitNet", "VenitNet"),
																																																					 new System.Data.Common.DataColumnMapping("AngajatID", "AngajatID")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "[EvolutieSalariu]";
			this.sqlSelectCommand1.Connection=Conn;
			this.sqlSelectCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@dept", System.Data.SqlDbType.NVarChar, 10));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@angid", System.Data.SqlDbType.Int, 4));
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tspan", System.Data.SqlDbType.Int, 4));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
