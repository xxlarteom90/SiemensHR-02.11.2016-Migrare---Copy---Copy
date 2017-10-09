<%@ Page language="c#" Codebehind="AddAngajat_end.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.AddAngajat_end" %>
<%@ Register TagPrefix="uc1" TagName="PageHeader" Src="PageHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderMenu" Src="HeaderMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>HR Toolkit</title>
<meta content="Microsoft Visual Studio .NET 7.1" name=GENERATOR>
<meta content=C# name=CODE_LANGUAGE>
<meta content=JavaScript name=vs_defaultClientScript>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="StyleHR.css" type=text/css rel=stylesheet >
  </HEAD>
<body>
<script language=javascript src="js/jsCode.js"></script>

<form id="Form1" method=post runat="server" enctype="multipart/form-data">
<table cellSpacing=0 cellPadding=0 width="100%" align=center border=0>
  <tr>
    <td>
<uc1:PageHeader id=PageHeader1 runat="server"></uc1:PageHeader></td></tr>
  <tr>
    <td align=center>
<uc1:HeaderMenu id=HeaderMenu1 runat="server"></uc1:HeaderMenu></td></tr>
  <tr>
    <td><asp:literal id=litError 
      runat="server"></asp:literal></td></tr>
	<tr>
		<td><img src="images/1x1.gif" height=50></td>
	</tr>      
  <TR>
    <TD align=center>
    <table border=0 cellpadding=0 cellspacing=0 width=600  class=tabBackground>
    <tr>
		<td height=50 class=NormalBlackBold align=center>Datele angajatului au fost salvate!</td>
    </tr>
    <tr>
		<td align=center height=100>
<asp:Button id=btnAddAngaajt onmouseover=MouseOverButton(this) onmouseout=MouseOutButton(this) runat="server" Text="Adauga angajat nou" CssClass="ButtonStyle"></asp:Button>&nbsp;&nbsp;
<asp:Button id=btnEditAngajat  onmouseover=MouseOverButton(this) onmouseout=MouseOutButton(this) runat="server" Text="Editeaza date angajat" CssClass="ButtonStyle"></asp:Button></td>
    </tr>
    </table>
   </TD></TR>
</table>
<input type=hidden name=idAngajat value="<%Response.Write(Request.QueryString["idAngajat"].ToString());%>">
     </form>
	
  </body>
</HTML>
