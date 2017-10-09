using System;
using System.Xml;
using System.Data;

namespace SiemensHR.Classes
{
	/// <summary>
	/// Summary description for XMLHandler.
	/// </summary>
	public class XMLHandler
	{
		private XmlDocument xmlDoc = null; 
		
		#region Constructor
		/// <summary>
		/// Constructor
		/// </summary>
		public XMLHandler()
		{
			xmlDoc = new XmlDocument();
		}
		#endregion

		#region LoadXMLDoc
		/// <summary>
		/// Procedura inarca u fisier XML
		/// </summary>
		/// <param name="FullPath">Calea fisierului</param>
		public void LoadXMLDoc(string FullPath)
		{
			xmlDoc.Load(FullPath);
		}
		#endregion

		#region GetDocument
		/// <summary>
		/// Procedura returneaza un fisier XML
		/// </summary>
		/// <returns></returns>
		public XmlDocument GetDocument()
		{
			return xmlDoc;
		}
		#endregion

		#region GetDocInnerXml
		/// <summary>
		/// Procedura returneaza continutul doc al unui fisier XML
		/// </summary>
		/// <returns></returns>
		public string GetDocInnerXml()
		{
			return xmlDoc.InnerXml;
		}
		#endregion

		#region GetDocInnerText
		/// <summary>
		/// Procedura returneaza continutul unui text
		/// </summary>
		/// <returns></returns>
		public string GetDocInnerText()
		{
			return xmlDoc.InnerText;
		}
		#endregion

		#region GetXmlNodeListByTag
		/// <summary>
		/// Procedura obtine nodurile unui tag
		/// </summary>
		/// <param name="pTagName">Numele tag-ului</param>
		/// <returns>Returneaza lista de noduri</returns>
		public XmlNodeList GetXmlNodeListByTag(string pTagName)
		{
			return  xmlDoc.GetElementsByTagName(pTagName);
		}
		#endregion

		#region GetXmlNodeListByXPath
		/// <summary>
		/// Proceudra returneaza nodurile unui xpath
		/// </summary>
		/// <param name="pXPath">Valoarea pentru xpath</param>
		/// <returns>Returneaza lista cu noduri</returns>
		public XmlNodeList GetXmlNodeListByXPath(string pXPath)
		{
			return xmlDoc.SelectNodes(pXPath);
		}
		#endregion

		#region CreateNewXmlNode
		/// <summary>
		/// Procedura creaza un nou nod XML
		/// </summary>
		/// <param name="pXmlDoc">Continutul nodului</param>
		/// <param name="pTagName">Numele tag-ului</param>
		/// <returns>Returneaza nodul creat</returns>
		public static XmlNode CreateNewXmlNode(XmlDocument pXmlDoc,string pTagName )
		{
			return pXmlDoc.CreateNode(XmlNodeType.Element,pTagName,"");
		}
		#endregion

		#region CreateNewXmlAttribute
		/// <summary>
		/// Procedura creaza un nod XML cu anumite atribute
		/// </summary>
		/// <param name="pXmlDoc">Continutul nodului</param>
		/// <param name="pAttrName">Atributul nodului</param>
		/// <param name="pValue">Valoarea nodului</param>
		/// <returns>Returneaza nodul creat</returns>
		public static XmlAttribute CreateNewXmlAttribute(XmlDocument pXmlDoc,string pAttrName,string pValue)
		{
			XmlAttribute xa = pXmlDoc.CreateAttribute(pAttrName);
			xa.Value = pValue;
			return xa;
		}
		#endregion

		#region GetXmlAttrValue
		/// <summary>
		/// Procedura obtine valoarea atributului unui nod
		/// </summary>
		/// <param name="pXmlNode">Nodul</param>
		/// <param name="pAttrName">Atributul</param>
		/// <returns>Valoarea atributului</returns>
		public static string GetXmlAttrValue(XmlNode pXmlNode,string pAttrName)
		{
			// Adaugat: Anca Holostencu
			if( pXmlNode.Attributes == null )
			{
				return null;
			}

			if (pXmlNode.Attributes[pAttrName]!=null)
			{
				return pXmlNode.Attributes[pAttrName].Value;
			}
			else 
			{
				return null;
			}
		}
		#endregion

		#region GetXmlAttrValue
		/// <summary>
		/// Procedura salveaza fisierul XML
		/// </summary>
		/// <param name="FullPath">Numele fisierului</param>
		public void SaveToXMLFile(string FullPath)
		{
			xmlDoc.Save(FullPath);
		}
		#endregion
	}
}
