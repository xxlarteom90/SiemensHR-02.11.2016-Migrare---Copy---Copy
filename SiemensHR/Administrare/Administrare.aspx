<%@ Page language="c#" Codebehind="Administrare.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.Administrare.Administrare" %>
<%@ Register TagPrefix="uc1" TagName="PageHeader" Src="../PageHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderMenu" Src="../HeaderMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>HR Toolkit</title>
		<script>
			var arTabs;
			
			function SelectTab(index)
			{
				var lastSelectedNodeID = document.getElementById('LastSelectedNodeID').value;
				document.location = "Administrare.aspx?node="+lastSelectedNodeID+"&cmd="+arTabs[index];
			}
		</script>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="../js/jsCode.js"></script>
		<script language="javascript" src="../js/navigation_tree.js"></script>
		<script>var images_path = "../images/";</script>
		<LINK href="../StyleHR.css" type="text/css" rel="stylesheet">
  </HEAD>
	<body topmargin="0" leftmargin="0">
		<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
			<tr>
				<td colspan="2">
					<uc1:pageheader id="PageHeader1" relativePath="../" runat="server"></uc1:pageheader></td>
			</tr>
			<tr>
				<td align="center" colspan="2"><uc1:headermenu id="HeaderMenu1" runat="server" relativePath="../"></uc1:headermenu></td>
			</tr>
			<tr></TD>
				<td vAlign="top" align="center">
					<asp:Table id="mainTable" runat="server" HorizontalAlign="Left" Width="100%" Height="100%"
						CellPadding="0" CellSpacing="0"></asp:Table></td>
			</tr>
		</table>
	</body>
</HTML>
