<%@ Register TagPrefix="uc1" TagName="AdminDepartament" Src="AdminDepartamente.ascx" %>
<%@ Page language="c#" Codebehind="AdminDepartamenteIstoricDepartamente.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.Administrare.AdminDepartamenteIstoricDepartamente" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrare Departamente</title>
		<LINK href="../StyleHR.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../js/jsCode.js"></script>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<table align="center" width="100%">
			<tr align="center">
				<td align="center">
					<uc1:AdminDepartament id="AdminDepartament" runat="server"></uc1:AdminDepartament>
				</td>
			</tr>
		</table>
		<script>
 		RefreshParentPage();
		</script>
	</body>
</HTML>
