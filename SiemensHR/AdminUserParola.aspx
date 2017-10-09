<%@ Register TagPrefix="uc1" TagName="HeaderMenu" Src="HeaderMenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="AdminUserParola" Src="Administrare/AdminUserParola.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageHeader" Src="PageHeader.ascx" %>
<%@ Page language="c#" Codebehind="AdminUserParola.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.AdminUserParola" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HR Toolkit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="StyleHR.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="js/jsCode.js"></script>
		<LINK href="StyleHR.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form name="form1" method="post">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" align="center" border="0">
				<TR>
					<TD align="center" width="100%" colSpan="2">
						<uc1:pageheader id="PageHeader1" runat="server"></uc1:pageheader></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<uc1:AdminUserParola id="AdminUserParola1" runat="server"></uc1:AdminUserParola></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
