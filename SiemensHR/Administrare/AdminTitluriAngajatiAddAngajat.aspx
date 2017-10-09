<%@ Page language="c#" Codebehind="AdminTitluriAngajatiAddAngajat.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.Administrare.AdminTitluriAngajatiAddAngajat" %>
<%@ Register TagPrefix="uc1" TagName="AdminTitluri" Src="AdminTitluriAngajati.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 
<LINK href="../StyleHR.css" type="text/css" rel="stylesheet">
<script language="javascript" src="../js/jsCode.js"></script>
<html>
  <head>
    <title>Administrare titluri angajati</title>
    <meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" Content="C#">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body MS_POSITIONING="GridLayout">
	
 	<table align=center width=100%>
		<tr align=center>
			<td align=center>
				<uc1:AdminTitluri id="AdminTitluri" runat="server"></uc1:AdminTitluri>
			</td>
		</tr>
	</table>
 	<script>
 		RefreshAddAngajatPage();
 	</script>
  </body>
</html>