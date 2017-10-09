namespace SiemensHR.InterfataSalarii.Module
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	//using Word = Microsoft.Office.Interop.Word; 
	using Salaries.Configuration;

	/// <summary>
	///		Summary description for Fluturasi.
	/// </summary>
	public class Fluturasi : SiemensHR.InterfataSalarii.Classes.BaseModule
	{

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.buttonGenereazaFluturasi.Click += new System.EventHandler(this.button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

        //Word.Application wrdApp;
        //Word._Document wrdDoc;
        //Object oMissing = System.Reflection.Missing.Value;
        //Object oFalse = false;
        //Object oTrue = true;
       protected System.Web.UI.WebControls.Button buttonGenereazaFluturasi;

        private void button1_Click(object sender, System.EventArgs e)
        {
        //    Word.MailMerge wrdMailMerge;
        //    Word.MailMergeFields wrdMergeFields;

        //    // Create an instance of Word  and make it visible.
        //    wrdApp = new Word.Application();
        //    // Add a new document.
        //    Object oName = Server.MapPath( "" )+"\\Module\\Fluturas fata 2008.doc";
        //    wrdDoc = wrdApp.Documents.Add(ref oName,ref oMissing,ref oMissing,ref oMissing);
			
        //    //creez string-ul de conexiune
        //    string dataSource = CryptographyClass.getSetting("dataSource");
        //    string initialCatalog = CryptographyClass.getSetting("initialCatalog");
        //    string userID = CryptographyClass.getSetting("userID");
        //    string pwd = CryptographyClass.getSetting("pwd");
        //    string sqlConn = "DSN=MyDSN;SERVER="+dataSource+";DATABASE="+initialCatalog+";UID="+userID+";PWD="+pwd+";Trusted_Connection=No";
        //    object oSqlConn = sqlConn;

        //    //aflu luna cureta si luna activa
        //    int idAngajator = this.GetAngajator();
        //    Salaries.Business.Luni objLuni = new Salaries.Business.Luni(idAngajator);
        //    DataSet myDs = objLuni.GetLunaActivaDataSet();
        //    int idLunaActiva = -1;
        //    if ( myDs.Tables[0].Rows.Count != 0)
        //        idLunaActiva = Int32.Parse(myDs.Tables[0].Rows[0][3].ToString());
        //    int idLunaCurenta = Int32.Parse(this.GetCurrentMonth().ToString());
			
        //    string sqlStat = "";
        //    bool esteFacutCalculSalarial = false;
        //    if (idLunaActiva == idLunaCurenta)
        //    {
        //        sqlStat = "SELECT  top 100 percent * from v_Fluturasi";
        //        Salaries.Business.Salariu sal = new Salaries.Business.Salariu();
        //        esteFacutCalculSalarial = sal.VerifyCalculSalarial(idAngajator);
        //    }
        //    else
        //    {
        //        esteFacutCalculSalarial = true;
        //        sqlStat = "SELECT  top 100 percent * from FunctionFluturasi('"+idLunaCurenta+"')";
        //    }
        //    object oSql = sqlStat;
			

        //    try
        //    {
        //        if (esteFacutCalculSalarial)
        //        {
        //            //string ODCFile = Server.MapPath( "" )+"\\Module\\Fluturasi SiemensHR.odc";
        //            //wrdDoc.MailMerge.OpenDataSource(ODCFile,ref oMissing,ref oMissing,ref oFalse,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oSql,ref oMissing,ref oFalse,ref oMissing); 
        //            wrdDoc.MailMerge.OpenDataSource("",ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oMissing,ref oSqlConn,ref oSql,ref oMissing,ref oMissing,ref oMissing); 
        //            wrdMailMerge = wrdDoc.MailMerge;
        //            wrdMergeFields = wrdMailMerge.Fields;
        //            wrdApp.Visible = true;
        //            //wrdDoc.Select();
        //            wrdMailMerge = wrdDoc.MailMerge;
        //            // Perform mail merge.
        //            //wrdMailMerge.Destination = Word.WdMailMergeDestination.wdSendToNewDocument;
        //            wrdMailMerge.Execute(ref oFalse);
        //            // Close the original form document.
        //            wrdDoc.Saved = true;
        //            wrdDoc.Close(ref oFalse,ref oMissing,ref oMissing);
        //            // Release References.
        //            wrdMailMerge = null;
        //            wrdMergeFields = null;
        //            wrdDoc = null;
        //            wrdApp = null;
        //        }
        //        else
        //            Response.Write("<script> alert('Nu se pot genera fluturasii deoarece nu a fost facut calculul salarial');</script>");
				
        //    }
        //    catch(Exception exc)
        //    {
        //        Response.Write("<script> alert('"+exc.Message+"');</script>");
        //    }
        //    finally
        //    {
        //        wrdDoc.Close(ref oFalse,ref oMissing,ref oMissing);
        //    }
			
        } 
	}
}
