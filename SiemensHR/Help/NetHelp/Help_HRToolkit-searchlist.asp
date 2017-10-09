<%@language="VBScript"%>
<%
Option Explicit

Const c_JavaHome = ""

Const c_CantCreateEngine = "Can't create search engine. "
Const c_InitEngineFailed = "Failed to initialize search engine. "
Const c_ExecuteQueryFailed = "Failed to execute query. "

Const c_bOpenLinkInRightWindow = True

Const c_rep = "HTMLSearch"
Dim query : query = Cstr(Request.Item("query"))
Dim url : url = "file:" & Server.MapPath(".") & "\"
Dim classpath : classpath = Server.MapPath(".") & "\WEB-INF\lib\c1searchengine.jar;" & Server.MapPath(".") & "\WEB-INF\lib\jsearch.jar;"
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
	<form class="clsFrmHidden">
		<input type="hidden" name="curSel" id="curSel">
	</form>
	<table border="0" cellpadding="0" cellspacing="0"><tr><td nowrap>
	<form name="frmResult" id="frmResult">
<%
	if len(query) > 0 then
		On Error Resume Next
		Dim count: count = 0
		Dim search : Set search = CreateObject("C1D2HASPHandler.NetHelpSearch")
		if Err <> 0 then 
			Response.Write c_CantCreateEngine & Err.Description
			Response.End
		else
			if not search.Init(c_JavaHome, classpath) then
				Response.Write "Error: " & search.GetLastError
				Response.End
			end if
			if Err <> 0 then 
				Response.Write c_InitEngineFailed & Err.Description
			else
				count = search.ExecuteQuery(c_rep, url, query)
				if Err <> 0 then 
					Response.Write c_ExecuteQueryFailed & Err.Description
					Response.End
				else 
					if count = -1 then
						Response.Write "Error: " & search.GetLastError
						Response.End
					end if
				end if
			end if
		end if
		On Error Goto 0

		if count <= 0 then
%>
        <p>No topics found.</p>
<%
		else
			Dim i
			Dim file, title, target
			if c_bOpenLinkInRightWindow then
			    target = "right"
			else
			    target = "_parent"
			end if
			for i = 0 to count-1
				file = search.GetFile(i)
				title = search.GetTitle(i)
%>
		<div nowrap class="clsSearchResultItem">
		<a id="ri-<%=i+1%>" href="<%=file%>" target="<%=target%>" onclick="return d2hSearchItemSelect('<%=file%>', event)" onmouseover="d2hItemOver(event)" onmouseout="d2hItemOut(event)">
			<%=title%>
		</a>
		</div>
<%
			next
		end if
		set search = Nothing
	end if
%>
    </form>
    </td></tr></table>
  </body>
</html>
