<%@ Page language="c#" Codebehind="EditAngajat.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.EditAngajat" %>
<%@ Register TagPrefix="uc1" TagName="EditComboAngajatiDinCautare" Src="EditTasks/EditComboAngajatiDinCautare.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageHeader" Src="PageHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderMenu" Src="HeaderMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>HR Toolkit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="js/jsCode.js"></script>
		<script language="javascript" src="js/navigation_tree.js"></script>
		<LINK href="StyleHR.css" type="text/css" rel="stylesheet">
		<script>
	images_path = "images/";
	function sp3FormIDfix()
	{
	document.forms[0].id=ctrlID + "_Form1";
	}
	
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" encType="multipart/form-data" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td height="80"><uc1:pageheader id="PageHeader1" runat="server"></uc1:pageheader></td>
				</tr>
				<tr>
					<td vAlign="top" align="center" height="20"><uc1:headermenu id="HeaderMenu1" runat="server"></uc1:headermenu></td>
				</tr>
				<TR>
					<TD vAlign="top" align="center" height="20"><uc1:editcomboangajatidincautare id="EditComboAngajatiDinCautare1" runat="server"></uc1:editcomboangajatidincautare></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center"><asp:table id="mainTable" runat="server"></asp:table></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
