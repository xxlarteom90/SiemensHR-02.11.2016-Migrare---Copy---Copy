namespace SiemensHR.Administrare
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using SiemensHR.Classes;

	/// <summary>
	///		Summary description for EditUtilizator.
	/// </summary>
	public class EditUtilizator : System.Web.UI.UserControl
	{
		#region variabile
		protected System.Web.UI.WebControls.ValidationSummary vldSummary;
		protected System.Web.UI.WebControls.Button btnDeleteUtilizator;
		protected System.Web.UI.WebControls.RegularExpressionValidator regExpUtilizator;
		protected System.Web.UI.WebControls.RequiredFieldValidator requiredUtilizator;
		protected System.Web.UI.WebControls.TextBox txtUtilizator;
		protected System.Web.UI.WebControls.DropDownList dropDownListGrupuri;
		protected System.Web.UI.WebControls.Table headerTable;
		protected System.Web.UI.WebControls.Literal litError;
		protected System.Web.UI.WebControls.DataList listaNivele;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtGrupID;
		private int idUtilizator;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.Button btnSalveazaUtilizator;
		private int angajatorId;
		#endregion

		#region Page Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			angajatorId = int.Parse(Session["AngajatorID"].ToString());

			int idUtiliz = Int32.Parse(Request.QueryString["id"]);
			idUtilizator = idUtiliz;
			if (idUtiliz != -1 ) //adica am editare
			{
				Utilities.CreateTableHeader(headerTable, "Editare utilizator", "../", "small");
				if (!IsPostBack)
				{
					BindComboGrup();
					BindUtilizator();
					BindNiveleUtilizator();					
				}
			}
			else  //adica am adugare utilizator
			{
				if (!IsPostBack)
				{
					BindComboGrup();
				}
			}
		}

		#endregion

		#region bind
		private void BindComboGrup()
		{
			Salaries.Business.GrupUtilizatori grupuri = new Salaries.Business.GrupUtilizatori();
			dropDownListGrupuri.DataSource = grupuri.GetGrupuriUtilizatori();
			dropDownListGrupuri.DataTextField = "NumeGrup";
			dropDownListGrupuri.DataValueField = "GrupID";
			dropDownListGrupuri.DataBind();
		}

		private void BindUtilizator()
		{
			Salaries.Business.AdminUtilizatori adminUtiliz = new Salaries.Business.AdminUtilizatori();
			adminUtiliz.UtilizatorId = idUtilizator;
			adminUtiliz.LoadInfoUtilizator();

			txtUtilizator.Text = adminUtiliz.Nume;
			txtGrupID.Value = adminUtiliz.GrupUtilizatorAngajatorId.ToString();
			dropDownListGrupuri.SelectedValue = adminUtiliz.GrupUtilizatorAngajatorId.ToString();
			txtEmail.Text = adminUtiliz.Email;
		}
		#endregion

		#region BindNiveleUtilizator
		private void BindNiveleUtilizator()
		{
			Salaries.Business.NivelUtilizator niv = new Salaries.Business.NivelUtilizator();	
			niv.AngajatorId = Int32.Parse(Session["AngajatorID"].ToString());
			listaNivele.DataSource = niv.LoadNivelePentruUtilizator(idUtilizator);
			listaNivele.DataBind();
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
			this.btnSalveazaUtilizator.Click += new System.EventHandler(this.btnSalveaza_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region salveaza utilizator
		private void btnSalveaza_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				Salaries.Business.AdminUtilizatori ut = new Salaries.Business.AdminUtilizatori();
				ut.UtilizatorId = idUtilizator;
				ut.LoadInfoUtilizator();

				Salaries.Business.AdminUtilizatori utilizator = new Salaries.Business.AdminUtilizatori();
				utilizator.UtilizatorId = idUtilizator;
				utilizator.Nume = txtUtilizator.Text;
				utilizator.Email = txtEmail.Text;
				utilizator.Parola = ut.Parola;
				utilizator.GrupUtilizatorAngajatorId = utilizator.GetGrupAngajatorUtilizatorId(angajatorId,Convert.ToInt32(txtGrupID.Value));
				
				if ( (!dropDownListGrupuri.SelectedItem.Text.Equals("Managers")) || IsManagerDepartament(utilizator.Nume))
				{
					utilizator.UpdateUtilizator();
				}
				else
				{
					Response.Write("<script>alert('Numele utilizatorului din grupul Managers trebuie sa fie de tipul nume_denumire departament');</script>");
				}
				
				//nivele
				foreach(DataListItem it in listaNivele.Items)
				{
					int index = it.ItemIndex;
					int idNivel = Int32.Parse(listaNivele.DataKeys[index].ToString());
					System.Web.UI.WebControls.CheckBox chk = (System.Web.UI.WebControls.CheckBox) it.FindControl("checkBoxNivel");
					bool esteInNivel = chk.Checked;

					Salaries.Business.NivelUtilizator niv = new Salaries.Business.NivelUtilizator();	
					niv.AngajatorId = Int32.Parse(Session["AngajatorID"].ToString());
					niv.IdNivel = idNivel;
			
					if  (niv.EsteUtilizatorInNivel(idUtilizator))
					{
						if (!esteInNivel)
							niv.RemoveUtilizatorFromNivel(idUtilizator);
					}
					else
					{
						if (esteInNivel)
							niv.AddUtilizatorInNivel(idUtilizator);
					}

				}
				BindComboGrup();
				BindUtilizator();
				BindNiveleUtilizator();
			}
			catch(Exception ex)
			{
				litError.Text = "The following error occurred: <br>";
				litError.Text += ex.Message;
			}
		}
		#endregion

		#region IsManagerDepartament
		/// <summary>
		/// Autor:		Lungu Andreea
		/// Data:		02.11.2007
		/// Descriere:	Procedura verifica daca numele specificat pentru un utilizator din grupul Managers
		///				este de forma string_numeDepartament
		/// </summary>
		/// <param name="numeManager">Numele utilizatorului</param>
		/// <returns>Returneaza true daca numele este corect si false altfel</returns>
		public static bool IsManagerDepartament(string numeManager)
		{
			if (numeManager.LastIndexOf("_")>=0)
			{
				string dep = numeManager.Substring(numeManager.LastIndexOf("_")+1);
				Salaries.Business.AdminDepartament departamente = new Salaries.Business.AdminDepartament();
				DataSet ds = departamente.GetAllDepartamente();
				for (int i=0; i<ds.Tables[0].Rows.Count; i++)
				{
					string n = ds.Tables[0].Rows[i]["Denumire"].ToString();
					if (n == dep)  
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}
		#endregion

	}
}
