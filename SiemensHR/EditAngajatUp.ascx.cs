using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SiemensHR.Classes;

namespace SiemensHR
{
	/// <summary>
	///		Summary description for EditAngajatUp.
	/// </summary>
	public class EditAngajatUp : System.Web.UI.UserControl
	{
		#region Variabile
		public long AngajatID;
		private int tipNationalitateDomiciliu = 0;
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			CreateVarTipNationalitateDomiciliu();

			/*string script = "<script>\n";
			script += "function SelectTask( task )\n";
			script += "{\n";
			script += "document.location = \"EditAngajat.aspx?cmd=\" + task + \"&id=" + AngajatID.ToString() + "\"\n" ;
			script += "}\n";
			script += "</script>\n";
		
			Response.Write(script);*/
			string tipAlerta = Request.QueryString["alerta"];
			if(tipAlerta == null)
				tipAlerta = "-1";

			string script = "<script>\n";
			script += "function SelectTask(task)\n";
			script += "{\n";
			script += "var potIncarcaPagina = true;";
			script += "switch( tipNationalitateDomiciliu )\n";
			script += "{\n";
			script += "case 0:\n";
			script += "		if( task=='istoric_permis_munca' || task=='istoric_legitimatie_sedere' || task=='istoric_NIF')\n";
			script += "			potIncarcaPagina = false;\n";
			script += "break;\n";
			script += "case 1:\n";
			script += "		if( task=='istoric_permis_munca' )\n";
			script += "			potIncarcaPagina = false;\n";
			script += "break;\n";
			script += "case 2:\n";
					//trebuie pt buletin daca o sa se modifice
			script += "break;\n";
			script += "}\n";
			script += "if( potIncarcaPagina ) {\n";
			script +="     var lastSelectedNodeID = document.getElementById('LastSelectedNodeID').value;";
			script +="     var tipAlerta ='"+tipAlerta+"';";
			script +="     if(tipAlerta == '-1')";

			if (Session["Recrutori"].ToString() == "Recrutori")
			{ 
				script +="	  	   document.location = \"EditAngajat_Recrutori.aspx?node=\"+lastSelectedNodeID+\"&cmd=\" + task + \"&id=" + AngajatID.ToString() + " \"\n" ;
				script +="     else";
				script +="	  	   document.location = \"EditAngajat_Recrutori.aspx?node=\"+lastSelectedNodeID+\"&cmd=\" + task+\"&alerta=\" + tipAlerta + \"&id=" + AngajatID.ToString() + " \"\n" ;
			}
			else
			{
				script +="	  	   document.location = \"EditAngajat.aspx?node=\"+lastSelectedNodeID+\"&cmd=\" + task + \"&id=" + AngajatID.ToString() + " \"\n" ;
				script +="     else";
				script +="	  	   document.location = \"EditAngajat.aspx?node=\"+lastSelectedNodeID+\"&cmd=\" + task+\"&alerta=\" + tipAlerta + \"&id=" + AngajatID.ToString() + " \"\n" ;
			}
			script += "} else\n";
			script += "		alert( 'Nu puteti incarca pagina respectiva!!!' );\n";
			script += "}\n";
			script += "</script>\n";
			Response.Write(script);
		}
		#endregion

		#region CreateVarTipNationalitateDomiciliu
		/// <summary>
		/// Procedura stabileste valoarea pentru tipul de nationalitate a angajatului
		/// </summary>
		private void CreateVarTipNationalitateDomiciliu()
		{
			int taraBazaID = 0;
			try
			{
				Salaries.Business.AdminTari tari = new Salaries.Business.AdminTari();
				DataSet dsTaraBaza = tari.GetTaraDeBaza();
				taraBazaID = int.Parse( dsTaraBaza.Tables[ 0 ].Rows[ 0 ][ "TaraID" ].ToString());
			}
			catch
			{
				taraBazaID = 0;
			}

			Salaries.Business.Angajat ang = new Salaries.Business.Angajat();
			ang.AngajatId = AngajatID;
			ang.LoadAngajat();

			if( ang.Nationalitate == taraBazaID )
			{
				if( ang.DTara == taraBazaID )
				{
					tipNationalitateDomiciliu = 0;
				}
				else
				{
					tipNationalitateDomiciliu = 1;
				}
			}
			else
			{
				tipNationalitateDomiciliu = 2;
			}

			Response.Write( "<script>var tipNationalitateDomiciliu = "+tipNationalitateDomiciliu+";</script>" );
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
