<%@ Register TagPrefix="uc1" TagName="AdminCategorii" Src="Module/Admin_CategoriiAngajati.ascx" %>
<%@ Page language="c#" Codebehind="AdminCategoriiAngajati_AddAngajat.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.InterfataSalarii.AdminCategoriiAngajati_AddAngajat" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<LINK href="../StyleHR.css" type="text/css" rel="stylesheet">
<script language="javascript" src="Module/Pontaj/js/jsCode.js"></script>
<HTML>
	<HEAD>
		<title>Administrare titluri angajati</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
<form id="Form1" name="Form1" method="post" encType="multipart/form-data" runat="server">
		<table align="center" width="100%">
			<tr align="center">
				<td align="center">
					<uc1:AdminCategorii id="AdminCategorii" runat="server"></uc1:AdminCategorii>
				</td>
			</tr>
		</table>
		<script>
 		RefreshAddAngajatPage();
		</script>
		</form>
	</body>
</HTML>
