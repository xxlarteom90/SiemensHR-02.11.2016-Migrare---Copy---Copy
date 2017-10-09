<%request.setCharacterEncoding("Windows-1252");%>
<%@page contentType="text/html;charset=Windows-1252"%>
<%@page import="java.util.*"%>
<%@page import="java.net.URL"%>
<%@page import="c1.search.c1searchengine"%>
<%@page import="c1.search.C1SearchItem"%>
<%
String strRep = "HTMLSearch";

boolean _bOpenLinkInRightWindow = true;

%>
<%
class c1serversearch
{
  private URL _baseURL;
  private String _strRepository;
  private Object[] _arrObj;

  public c1serversearch(URL baseuri, String strRepository)
  {
    _baseURL = baseuri;
    _strRepository = strRepository;
    _arrObj = null;
  }
  public void execQuery(String strQuery)
  {
    c1searchengine searchEng = new c1searchengine(_strRepository, _baseURL);
    _arrObj = searchEng.executeQuery(strQuery);
  }
  
  public Object[] getObtainedItems()
  {
    return _arrObj;
  }
  
  public int getDocumentCount()
  {
    if (_arrObj == null)
    {
      return 0;
    }
    return _arrObj.length;
  }
};
%>
<html>
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=Windows-1252">
    <title>Search</title>
    <link rel="stylesheet" href="Theme/search.css" type="text/css">
    <script language="JavaScript" src="linker.js"></script>
	<script language="JavaScript" src="special.js"></script>
	<script language="JavaScript" src="common.js"></script>
	<script language="JavaScript" src="c1search.js"></script>

<script language="JavaScript">
<!--
if (typeof d2hLoadWindows != "undefined")
    d2hLoadWindows();
//-->
</script>

    </head>
    <body id="D2HSearch" class="itemlist">
      <%String strQuery = request.getParameter("query");%>
        <form class="clsFrmHidden">
            <input type="hidden" name="curSel" id="curSel">
        </form>
        <table border="0" cellpadding="0" cellspacing="0"><tr><td nowrap>
        <form name="frmResult" id="frmResult">
        <%
        if (strQuery != null && strQuery.length() > 0)
        {
          c1serversearch search = null;
          URL baseUrl = null;
          try
          {
            String current = request.getRequestURI();
            int indx = current.lastIndexOf("/");
            String contextPath = null;
            if (indx != -1)
              contextPath = current.substring(0, indx);
            else
              contextPath = request.getContextPath();
            baseUrl = new URL("http", request.getServerName(), request.getServerPort(), contextPath + "/");
            search = new c1serversearch(baseUrl, strRep);
            search.execQuery(strQuery);
          }
          catch(Exception e)
          {
          %>
          <%=e.toString()%>
          <%
          }
          int docCount = 0;
          if (search != null)
          {
             docCount = search.getDocumentCount();
          }
          if (docCount == 0)
          {
          %>
           <p>No topics found.</p>
          <%
          }
          else
          {
              Object[] arrObj = search.getObtainedItems();
              C1SearchItem item;
              for (int i = 0; i < arrObj.length; i++)
              {
                item = (C1SearchItem)arrObj[i];
              %>
                <div nowrap class="clsSearchResultItem">
                 <a id="ri-<%=i+1%>" href="<%= item.getFileName()%>" target="<%= (_bOpenLinkInRightWindow ? "right" : "_parent")%>" onclick="return d2hSearchItemSelect('<%= item.getFileName()%>', event)" onmouseover="d2hItemOver(event)" onmouseout="d2hItemOut(event)">
                  <%=item.getTitle()%>
                 </a>
                </div>
              <%
              }
          }
      } 
      %>
    </form>
    </td></tr></table>
  </body>
</html>
