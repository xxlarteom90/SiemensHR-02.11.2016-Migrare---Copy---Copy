//Autor: Muntean Raluca Cristina
//Descriere: Modul de administrare inflatie - procente lunare inflatie

using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

using Salaries.Business;
using SiemensHR.utils;
using SiemensHR.Classes;

namespace SiemensHR.InterfataSalarii.Module
{
	/// <summary>
	///		Summary description for Admin_InflatieLunara.
	/// </summary>
	public class Admin_InflatieLunara : SiemensHR.InterfataSalarii.Classes.BaseModule
	{
		#region Variabile
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.Table tableTabs;
		protected System.Web.UI.WebControls.Table listTable;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummary1;
		protected System.Web.UI.HtmlControls.HtmlTableRow trActiv;
		
		public int AngajatorID;
		protected System.Web.UI.WebControls.DropDownList drpAni;
		protected System.Web.UI.WebControls.Button btnAdaugaProcentInfl;
		protected System.Web.UI.WebControls.Label lInflatieCurenta;
		protected System.Web.UI.WebControls.Label lblCmpObli;
		protected System.Web.UI.WebControls.RequiredFieldValidator vldCmpOblProc;
		protected System.Web.UI.WebControls.Label lblCmpObl;
		protected System.Web.UI.WebControls.RangeValidator vldProc;
		protected System.Web.UI.WebControls.TextBox txtProcentInflatie;
		protected System.Web.UI.WebControls.ValidationSummary vldSummary;
		protected System.Web.UI.WebControls.Label Label1;
		protected int lunaId;
		#endregion
		
		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			string script_text = "<script>var ctrlID = \""+this.ClientID+"\"</script>";
			Response.Write(script_text);
		    
			//id-ul angajatorului
			this.AngajatorID=this.GetAngajator();
		
			//luna activa a angajatorului
			Salaries.Business.Luni luni = new Salaries.Business.Luni(this.GetAngajator());
			Salaries.Data.LunaData lunaData = luni.GetLunaActiva();	
		    //id-ul lunii active 
			int lunaActivaID = lunaData.LunaId;
			
			if(!IsPostBack)
			{
				string procInflatie = luni.GetDetalii(lunaActivaID).ProcentInflatie.ToString();
				txtProcentInflatie.Text = procInflatie;

				string[] textTabs = {"Lista luni pe anul curent", "Modificare procent inflatie"};
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "../", true);

				//anii din baza de date pentru care sunt calculate salariile
				DataSet dsAni=luni.GetAniSal_Salarii();
				if(dsAni.Tables[0].Rows.Count!=0)
				{
					//populeaza dropdownlist-ul
					foreach(DataRow row in dsAni.Tables["Ani"].Rows)
					{
						ListItem NewItem = new ListItem();
						NewItem.Text = row["An"].ToString();
						drpAni.Items.Add(NewItem);
					}
				}
				else
				{
					ListItem NewItem = new ListItem();
					NewItem.Text = luni.GetLunaActiva().Data.Year.ToString();
					drpAni.Items.Add(NewItem);
				}
			}
			else
			{
				string[] textTabs = {"Lista luni pentru anul selectat", "Modificare procent inflatie"};
				Utilities.CreateHeaderWithTabs(tableTabs, textTabs, "../", true);
			}
		}
		#endregion

		#region LoadInflatieList
		/// <summary>
		/// Este obtinuta lista lunilor(denumire, procent inflatie,..) pentru anul selectat in dropdownlist
		/// </summary>
		private void LoadInflatieList()
		{
			try
			{
				listTable.Rows.Clear();
				listTable.Attributes.Add("width", "100%");
				listTable.Style.Add("border","1px solid #20b2aa");
				listTable.Attributes.Add("cellpadding", "0");
				listTable.Attributes.Add("cellspacing", "1");

			
				string[] arHeader = {"Denumire", "ProcentInflatie"};
				string[] arCols = {"Denumire", "ProcentInflatie"};
				
				lunaId = this.GetCurrentMonth();//id-ul lunii curente

				Salaries.Business.Luni luni=new Salaries.Business.Luni(this.AngajatorID,lunaId);
				
				//anul selectat de utilizator
				int an=int.Parse(drpAni.SelectedItem.Text);
				
				//returneaza lunile din anul dat ca parametru pentru care sunt calculate salariile 
				//in baza de date
				//DataSet ds=luni.GetLuniSal_Salarii(an);
				DataSet ds=luni.GetLuniSal_Luni(an,this.AngajatorID);

				ListTable objListTable = new ListTable(listTable, ds, arHeader, arCols);
				objListTable.textForEmptyDataSet= "Nu exista date!";

				string[] ar_OnClickParam =  {"Denumire","ProcentInflatie"};
				
				string[] ar_OnClickParamType =new string[ ar_OnClickParam.Length];
				for (int i=0;i< ar_OnClickParamType.Length;i++)
					ar_OnClickParamType[i]="dataset";

			
				objListTable.OnclickParams = ar_OnClickParam;
				objListTable.OnclickParamsType = ar_OnClickParamType;

				objListTable.DrawListTableWithDigits(4);		
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}	
		}
		#endregion

		#region btnAdaugaProcentInfl_Click
		/// <summary>
		/// Este adaugat procentul inflatiei pentru luna activa
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAdaugaProcentInfl_Click(object sender, System.EventArgs e)
		{
			try
			{
				//luna curenta
				lunaId = this.GetCurrentMonth();

				//este setat procentul de inflatie
				Salaries.Business.Luni luni=new Salaries.Business.Luni(this.AngajatorID,lunaId);
				luni.ProcentInfl=float.Parse(txtProcentInflatie.Text);
				
				//se face update-ul
				luni.Update();
				
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}

			LoadInflatieList();
		}
		#endregion
	
		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
		
			Salaries.Business.Luni luni = new Salaries.Business.Luni(this.GetAngajator());
			Salaries.Data.LunaData lunaData = luni.GetLunaActiva();		
	
			if (lunaData.LunaId!=-1)
			{
				bool enabled = this.GetCurrentMonth()==lunaData.LunaId;
				this.btnAdaugaProcentInfl.Enabled=enabled;

				this.tableTabs.Enabled=enabled;
			}		
				
			this.LoadInflatieList();
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
			this.btnAdaugaProcentInfl.Click += new System.EventHandler(this.btnAdaugaProcentInfl_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion	
	}
}
