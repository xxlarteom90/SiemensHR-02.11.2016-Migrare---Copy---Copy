<%@ Page language="c#" Codebehind="Managers.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.Managers" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Managers</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript" src="../js/jsCode.js"></script>
		<LINK href="../StyleHR.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0" height="100%">
			<tr>
				<td width="100%" align="center" class="BigPageHeader" height="30">
					<span class="BigPageHeader1">HR</span> Toolkit</td>
				<td colspan="2" align="right" width="455"><img src="../images/header1.gif"></td>
			</tr>
			<tr>
				<td style="HEIGHT: 1px"></td>
				<td class="NormalBlueBold" align="right" style="HEIGHT: 1px">HR Toolkit 
					v1.0&nbsp;&nbsp;&nbsp;</td>
			</tr>
			<tr>
				<td colspan="3" height="10" align="center">
					<asp:Label id="lblErr" runat="server" CssClass="AlertRedBold"></asp:Label></td>
			</tr>
			<tr>
				<td align="center" valign="top" colspan="3">
					<asp:Table id="mainTable" runat="server"></asp:Table>
				</td>
			</tr>
		</TABLE>
	</body>
</HTML>
