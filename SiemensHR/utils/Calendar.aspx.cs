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
using System.Timers;

namespace SiemensHR.utils
{
	/// <summary>
	/// Summary description for Calendar.
	/// </summary>
	public class Calendar : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList lstMonth;
		protected System.Web.UI.WebControls.DropDownList lstYear;
		protected System.Web.UI.WebControls.Calendar Calendar1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				//if (Calendar1.SelectedDate.Year == 1)
				//	Calendar1.SelectedDate = DateTime.Now;

				int anStart = DateTime.Now.Year - 80;
				int anEnd = DateTime.Now.Year + 30;
				ListItem myItem;
				for(int j=anStart; j<=anEnd; j++)
				{
					myItem = new ListItem(j.ToString(), j.ToString());
					if (j==Calendar1.TodaysDate.Year)
						myItem.Selected = true;
					lstYear.Items.Add(myItem);
				}
				lstMonth.SelectedValue = Calendar1.TodaysDate.Month.ToString();	
			}
		}

		private void Page_PreRender(object sender, System.EventArgs e)
		{
				
		}

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
			this.lstMonth.SelectedIndexChanged += new System.EventHandler(this.lstMonth_SelectedIndexChanged);
			this.lstYear.SelectedIndexChanged += new System.EventHandler(this.lstYear_SelectedIndexChanged);
			this.Calendar1.VisibleMonthChanged += new System.Web.UI.WebControls.MonthChangedEventHandler(this.Calendar1_VisibleMonthChanged);
			this.Calendar1.SelectionChanged += new System.EventHandler(this.Calendar1_SelectionChanged);
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new System.EventHandler(this.Page_PreRender);

		}
		#endregion

		private void Calendar1_SelectionChanged(object sender, System.EventArgs e)
		{
			Response.Write("<script>");
			Response.Write("if (typeof(window.opener.lastDateFieldSelected)=='object')");
            Response.Write("{");
            Response.Write("window.opener.lastDateFieldSelected.value = '" + Calendar1.SelectedDate.Day +
            "." + Calendar1.SelectedDate.Month + "." + Calendar1.SelectedDate.Year + "';");
			Response.Write("window.close();");
			Response.Write("}");
			Response.Write("</script>");
		}

		private void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs  e)
		{

			lstMonth.SelectedValue = e.NewDate.Month.ToString();	
			lstYear.SelectedValue = e.NewDate.Year.ToString();
		}
		private void lstMonth_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Calendar1.VisibleDate = new DateTime(Convert.ToInt32(lstYear.SelectedValue), Convert.ToInt32(lstMonth.SelectedValue), Calendar1.SelectedDate.Day);
		}

		private void lstYear_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Calendar1.VisibleDate = new DateTime(Convert.ToInt32(lstYear.SelectedValue), Convert.ToInt32(lstMonth.SelectedValue), Calendar1.SelectedDate.Day);
		}
	}
}
