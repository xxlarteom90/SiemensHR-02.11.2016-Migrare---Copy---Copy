<%@ Control Language="c#" AutoEventWireup="false" Codebehind="IstoricConcediiOdihnaAngajat.ascx.cs" Inherits="SiemensHR.EditTasks.IstoricConcediiOdihnaAngajat" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

	<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
		<tr>
			<td colSpan="3"><asp:literal id="litError" runat="server"></asp:literal></td>
		</tr>
		<tr>
			<td colSpan="3"><IMG height="10" src="../images/1x1.gif"></td>
		</tr>
		<tr>
			<td colSpan="3"><asp:table id="tableTabs" runat="server"></asp:table></td>
		</tr>
		<tr>
			<td id="tableIstoricCO" vAlign="top" align="center" colSpan="3" height="100%"><asp:table id="listTable" runat="server"></asp:table></td>
		</tr>
	</table>
