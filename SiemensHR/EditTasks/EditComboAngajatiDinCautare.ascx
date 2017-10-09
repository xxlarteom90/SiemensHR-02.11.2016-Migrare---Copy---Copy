<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditComboAngajatiDinCautare.ascx.cs" Inherits="SiemensHR.EditTasks.EditComboAngajatiDinCautare" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellSpacing="0" cellPadding="0" border="0">
	<tr>
		<td class="TaskStyle"><asp:label id="labelAngajatCurent" Width="100%" Visible="True" Runat="server">Angajat curent :</asp:label></td>
		<TD class="TaskStyle"><asp:dropdownlist id="drpNumeAngajat" Width="300px" Visible="True" Runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
	</tr>
	<tr>
		<td></td>
		<TD><asp:label id="lblErr" runat="server"></asp:label></TD>
	</tr>
</table>
