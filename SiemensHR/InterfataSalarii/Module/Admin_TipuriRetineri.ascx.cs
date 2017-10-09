using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Salaries.Business;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for Admin_TipuriRetineri.
	/// </summary>
	public class Admin_TipuriRetineri : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Button butSaveData;
		protected System.Web.UI.HtmlControls.HtmlTableCell Center;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			Luni l = new Luni(int.Parse(Session["AngajatorID"].ToString()));				
			int LunaID = GetCurrentMonth();
			DataSet dsRestraints = new TypesOfRestraints().GetLabels(LunaID);

			if (l.GetLunaActiva().LunaId == LunaID)
			{
				butSaveData.Visible = true;
			}
			else
			{
				butSaveData.Visible = false;
			}
				
			Table restraintsTable = new Table();
			TableRow tr = null;
			TableCell tc = null;
			System.Web.UI.Control ctl = null;

			int lunaActivaId = l.GetLunaActiva().LunaId;
			Salaries.Business.Luni lunaActiva = new Salaries.Business.Luni(this.GetAngajator(), lunaActivaId);
			DateTime dataStartLunaActiva = lunaActiva.Data;
			DateTime dataEndLunaActiva = dataStartLunaActiva.AddMonths(1).AddDays(-1);

			Center.Controls.Clear();
			foreach(DataRow dr in dsRestraints.Tables[0].Rows)
			{
				tr = new TableRow();

				ctl = new Label();
				((Label)ctl).Text = dr[0].ToString();
				string tipRetinere = dr[0].ToString();
				((Label)ctl).CssClass = "NormalGreenBold";
				ctl.ID = dr[0].ToString() + "Label";
				tc = new TableCell();
				tc.Controls.Add(ctl);
				tr.Cells.Add(tc);

				ctl = new TextBox();
				ctl.ID = dr[0].ToString()+";"+LunaID;
				if( dr[1] != System.DBNull.Value)
					((TextBox)ctl).Text = dr[1].ToString();
				Salaries.Configuration.ModuleSettings settings = Salaries.Configuration.ModuleConfig.GetSettings();
				Salaries.Data.RetineriRecurenteAngajat retineri = new Salaries.Data.RetineriRecurenteAngajat(settings.ConnectionString);
				int nr = retineri.VerificaIntersectieNrRetineri(0,tipRetinere,dataStartLunaActiva, dataEndLunaActiva);
				if (l.GetLunaActiva().LunaId!= LunaID || nr!=0)
					((TextBox)ctl).ReadOnly = true;
				if (l.GetLunaActiva().LunaId == LunaID)
					((TextBox)ctl).TextChanged += new System.EventHandler(this.TextBox_TextChanged);
				tc = new TableCell();
				tc.Controls.Add(ctl);
				tr.Cells.Add(tc);
		
				restraintsTable.Rows.Add(tr);
				Center.Controls.Add(restraintsTable);
			}
		}
		#endregion

		#region TextBox_TextChanged
		/// <summary>
		/// Actiunea executata la modificarea denumirii unei etichete
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextBox_TextChanged(object sender, System.EventArgs e)
		{
			string labelOfType = ((TextBox)sender).Text;
			string[] sir = ((System.Web.UI.Control)sender).ID.Split(';');
			string nameOfType = sir[0];

			Luni l = new Luni(int.Parse(Session["AngajatorID"].ToString()));				
			int LunaID = GetCurrentMonth();
			
			//Daca s-a sters textul din control atunci eticheta trebuie stearsa
			if (labelOfType == "")
			{
				//Se verifica daca se poate sterge eticheta
				if (new TypesOfRestraints().CheckIfLabelCanBeDeleted(nameOfType, LunaID))
				{
					//Daca da atunci se actualizeaza valoarea etichetei la stingul vid
					new TypesOfRestraints().UpdateLabel( nameOfType, labelOfType, LunaID);
				}
				else
				{
					//Daca nu se poate face stergerea utilizatorul este avertizat de acest lucru
					Response.Write("<script> alert('Retinerea are asociate valori pentru angajati si nu poate fi stearsa!'); </script>");
				}
			}
				//Daca exista text in control atunci se actualizeaza eticheta la valoarea din control
			else
			{
				new TypesOfRestraints().UpdateLabel( nameOfType, labelOfType, LunaID);
			}

			//Se reincarca controalele cu valorile etichetelor
			DataSet dsRestraints = new TypesOfRestraints().GetLabels(LunaID);
			foreach(DataRow dr in dsRestraints.Tables[0].Rows)
			{
				sir = ((TextBox)sender).ID.Split(';');
				if ( sir[0] == dr[0].ToString() )
					((TextBox)sender).Text = dr[1].ToString();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
