<%@ Register TagPrefix="uc1" TagName="SalariiLunaLucru" Src="SalariiLunaLucru.ascx" %>
<%@ Register TagPrefix="uc1" TagName="SalariiHeaderMenu" Src="SalariiHeaderMenu.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="MainSalarii.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.MainSalarii" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="Salarii_Administrare" Src="Salarii_Administrare.ascx" %>
<script language="javascript" src="../js/navigation_tree.js"></script>
<script>var images_path = "../images/";</script>
<script>
	function SelectOption( Tab,Option )
	{
		var lastSelectedNodeID = document.getElementById('LastSelectedNodeID').value;
		document.location.href = "Salarii.aspx?Tab=" + Tab + "&Option=" + Option+"&node="+lastSelectedNodeID;
	}
</script>
<table cellSpacing="0" cellPadding="0" width="100%" border="0" height="100%">
	<tr>
		<td id="Tabs" runat="server">
			<uc1:SalariiLunaLucru id="SalariiLunaLucru1" runat="server"></uc1:SalariiLunaLucru>
		</td>
	</tr>
	<TR>
		<TD style="HEIGHT: 20px">
			<asp:Table id="mainTable" runat="server" HorizontalAlign="Left" Width="100%" Height="100%"
				CellPadding="0" CellSpacing="0"></asp:Table></TD>
	</TR>
	<tr>
		<td height="100%" valign="top" id="Container" runat="server">
		</td>
	</tr>
</table>
