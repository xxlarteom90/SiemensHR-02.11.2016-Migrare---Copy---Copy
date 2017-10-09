using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;

using SiemensHR.Classes;
using SiemensHR.utils;

namespace SiemensHR
{
	/// <summary>
	///		Summary description for EditAngajatLeft.
	/// </summary>
	public class EditAngajatLeft : System.Web.UI.UserControl
	{
		#region Variabile
		protected System.Web.UI.WebControls.Image imgAngajat;
		protected System.Web.UI.WebControls.Label lblNume;
		protected System.Web.UI.WebControls.Label lblTitlu;
		protected System.Web.UI.WebControls.Label lblFunctie;
		protected System.Web.UI.WebControls.Label lblDepartament;

		public long m_AngajatID;
		public Salaries.Business.Angajat objAngajat;
		public string NavigationScript;
		private string numeXmlSursa;
		#endregion

		#region Proprietati
		public string XmlSursa
		{
			set {this.numeXmlSursa = value;}
			get {return this.numeXmlSursa;}
		}
		public long AngajatID
		{
			get { return m_AngajatID; }
			set { m_AngajatID = value; }
		}
		#endregion

		#region Page_Load
		private void Page_Load(object sender, System.EventArgs e)
		{
			imgAngajat.ImageUrl = "utils/ShowPicture.aspx?Id=" + AngajatID;
			lblNume.Text = objAngajat.Nume + " " + objAngajat.Prenume;
			lblTitlu.Text = objAngajat.TitluSimbol;
			lblFunctie.Text = objAngajat.FunctieCurentaNume;
			lblDepartament.Text = objAngajat.DepartamentCurentCod;
			this.NavigationScript = this.ScriptMeniu("TreeContainer");
		}
		#endregion

		#region ScriptSubmeniu
		/// <summary>
		/// Construieste script-ul corespunzator submeniului descris de <c>xmlRootNode</c>, adaugandu-l la elementul de meniu
		/// cu id-ul <c>parentElementID</c>.
		/// </summary>
		/// <param name="xmlRootNode">nodul xml care descrie structura arborescenta a submeniului</param>
		/// <param name="parentElementID">id-ul (numele) elementului de meniu care va contine submeniul</param>
		/// <returns>un <c>string</c> reprezentand script-ul corespunzator submeniului</returns>
		protected string ScriptSubmeniu( XmlNode xmlRootNode, string parentElementID )
		{
			// script-ul submeniului
			string script = "";

			// index-ul elementului (al catelea este in submeniu)
			int index = 1;

			// se obtine nodul xml care descrie submeniul (nodul avand tag-ul <Options> contine noduri de tip <option>, care
			// descriu elementele submeniului)
			XmlNode options = xmlRootNode.SelectSingleNode("descendant::Options");

			// se parcurg nodurile xml de tip <option> pentru a obtine elementele submeniului
			foreach( XmlNode option in options )
			{
				// daca nodul curent este un comentariu, se trece la nodul urmator
				if( option.Attributes == null )
					continue;

				// se construieste id-ul elementului din submeniu, concatenand id-ul parintelui cu indexul
				string ID = parentElementID + index;
			
				// se verifica daca elementul curent din submeniu are setata proprietatea openDefault si daca da, se adauga la
				// script-ul rezultat variabila javascript care retine id-ul elementului selectat implicit
				if( XMLHandler.GetXmlAttrValue( option, "OpenDefault" ) != null )
					script += "<script> var  DefaultSelectedNodeID = 'Element_" + ID + "' </script>";

				// se construieste script-ul pentru submeniu
				script +=	// se creeaza elementul parinte al submeniului, apeland metoda javascript CreateNodeMeniu(...) din
					// script=ul js/navigation_tree.js, cu urmatorii parametri:
					"<script> var MenuElement_" + ID + " = new CreateNodeMeniu( " +
					// "Element_" + ID - reprezinta valoarea atribuita parametrului NodeID si desemneaza id-ul (numele)
					// elementului parinte al submeniului
					"\"Element_" + ID + "\", " +
					// textul reprezentat de valoarea atributului Text al nodului radacina din xml-ul sursa - reprezinta
					// textul ce va fi afisat in submeniu pentru acest element,
					"\"" + XMLHandler.GetXmlAttrValue( option, "Text" ) + "\", " +
					// string-ul vid pentru parametrul Values,
					"\"\", " +
					// valoarea atributului Expanded - poate fi true sau false si indica daca elementul trebuie afisat
					// expandat (daca submeniurile sale sunt ascunse initial sau sunt vizibile),
					XMLHandler.GetXmlAttrValue( option, "Expanded" ) + ", " +
					// null, pentru parametrul ContainerID - pentru submeniuri acesta nu trebuie specificat
					"null, " +
					// valoarea atributului text din nodul xml - reprezinta textul afisat pe link-ul submeniului
					"\"" + XMLHandler.GetXmlAttrValue( option, "Text" ) + "\", " +
					// valoarea atributului Link - url-ul asociat link-ului 
					"\"" + XMLHandler.GetXmlAttrValue( option, "Link" ) + "\", " +
					// valoarea atributului Target - target-ul link-ului elementului de meniu
					"\"" + XMLHandler.GetXmlAttrValue( option, "Target" ) + "\", " +
					// valoarea atributului OnClick a nodului xml - desemneaza numele functiei javascript ce va fi apelata
					// la declansarea evenimentului onClick pe elementul de submeniu (localizarea paginii corespunzatoare
					// elementului)
					"\"" + XMLHandler.GetXmlAttrValue( option, "OnClick" ) + "\" ); " +
					// se obtine meniul parinte (apeland functia javascript getMenuNode(...)) si i se adauga submeniul creat
					"getMenuNode( \"Element_" + parentElementID + "\" ).AddSubNode( \"Element_" + ID + "\" );" +
					// se incheie script-ul si se reapeleaza metoda pentru a adauga eventualele submeniuri ale submeniului creat
					"</script>\n" + ScriptSubmeniu( option, ID );
			
				// se mareste indexul, deoarece se trece la urmatorul element din submeniu, aflat pe acelasi nivel
				index++;
			}
			
			// se returneaza script-ul submeniului
			return script;			
		}
		#endregion
		
		#region ScriptMeniu
		/// <summary>
		/// Costruieste script-ul pentru afisarea si navigarea prin meniu. Metoda construieste elementul radacina al meniului
		/// dupa care apeleaza metoda <c>ScriptSubmeniu</c> pentru a obtine partea de script corespunzatoare submeniurilor
		/// aferente acesteia.
		/// </summary>
		/// <returns>string-ul reprezentand script-ul pentru navigarea prin meniu</returns>
		protected string ScriptMeniu( string containerID)
		{		
			// se incarca xml-ul ce descrie structura arborescenta a meniului
			
			
			XMLHandler xmlHandler = new XMLHandler();
			xmlHandler.LoadXMLDoc( Server.MapPath( numeXmlSursa ) );
			
			// se obtine nodul radacina al documentului xml; acesta este sursa de informatii pe baza careia se va construi elementul
			// radacina din meniu
			XmlNode xmlRootNode = xmlHandler.GetDocument().DocumentElement;		

			// se construieste script-ul rezultat
			string script =	// se creeaza elementul radacina al meniului, apeland metoda javascript CreateNodeMeniu(...) din
				// script=ul js/navigation_tree.js, cu urmatorii parametri:
				"<script> var MenuElement_0 = new CreateNodeMeniu( " +
				// "Element_0" - reprezinta valoarea atribuita parametrului NodeID si desemneaza id-ul (numele)
				// elementului radacina al meniului (deoarece acesta este elementul radacina al meniului, sufixul id-ului
				// sau este 0),
				"\"Element_0\", " +
				// textul reprezentat de valoarea atributului Text al nodului radacina din xml-ul sursa - reprezinta
				// textul ce va fi afisat in meniu pentru acest element,
				"\"" + XMLHandler.GetXmlAttrValue( xmlRootNode, "Text" ) + "\", " +
				// string-ul vid pentru parametrul Values,
				"\"\", " +
				// valoarea atributului Expanded - poate fi true sau false si indica daca elementul trebuie afisat
				// expandat (daca submeniurile sale sunt ascunse initial sau sunt vizibile),
				XMLHandler.GetXmlAttrValue( xmlRootNode, "Expanded" ) + ", " +
				// containerID - id-ul (numele) componentei care contine elementul de meniu
				"\"" + containerID + "\", " +
				// valoarea atributului text din nodul xml radacina - reprezinta textul afisat pe link-ul meniului
				"\"" + XMLHandler.GetXmlAttrValue( xmlRootNode, "Text" ) + "\", " +
				// valoarea atributului Link - url-ul asociat link-ului 
				"\"" + XMLHandler.GetXmlAttrValue( xmlRootNode, "Link" ) + "\", " +
				// valoarea atributului Target - target-ul link-ului elementului de meniu
				"\"" + XMLHandler.GetXmlAttrValue( xmlRootNode, "Target" ) + "\", " +
				// valoarea atributului OnClick a nodului xml - desemneaza numele functiei javascript ce va fi apelata
				// la declansarea evenimentului onClick pe elementul de meniu (localizarea paginii corespunzatoare
				// elementului)
				"\"" + XMLHandler.GetXmlAttrValue( xmlRootNode, "OnClick" ) + "\" );" +
				// se inchide tag-ul <script>
				"</script>\n" +
				// se apeleaza ScriptSubmeniu(...) pentru a adauga script-urile corespunzatoare submeniurilor atasate
				// elementului radacina; ca parametri se transmit nodul xml radacina si 0 = id-ul elementului radacina
				// din meniu
				ScriptSubmeniu( xmlRootNode, "0" )+
				// se ataseaza script-ul de apel al functiei javascript care realizeaza expandarea ultimului element din
				// meniu selectat
				"<script>" +
				"HandleLastSelectedNode();" +
				// se apeleaza metoda Render(), de afisare a meniului
				"MenuElement_0.Render();" +
				"</script>\n";
			// se verifica daca nodul radacina are setata proprietatea openDefault si daca da, se adauga la script-ul rezultat
			// variabila javascript care retine id-ul elementului selectat implicit
			if( XMLHandler.GetXmlAttrValue( xmlRootNode, "OpenDefault" ) != null )
			{
				script += "<script> var  DefaultSelectedNodeID = 'Element_0' </script>";				
			}
			
			// se returneaza scrip-ul construit
			return script;
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

		#region OnPreRender
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender (e);
			Response.Write("<script>var DefaultSelectedNodeID = ''</script>");
			Response.Write("<script>var LastSelectedNodeID = '"+Request.QueryString["node"]+"'</script>");
		}
		#endregion
	}
}
