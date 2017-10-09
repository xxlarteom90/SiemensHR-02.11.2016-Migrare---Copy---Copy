<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Interval.ascx.cs" Inherits="SiemensTM.Module.Interval" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td><input id="OraStart" style="WIDTH: 70px; HEIGHT: 22px" type="text" maxLength="5" size="5"
				name="OraStart" runat="server">
		</td>
		<td align="center" width="20">&nbsp;<b>:</b>&nbsp;
		</td>
		<td><input id="OraEnd" style="WIDTH: 70px; HEIGHT: 22px" type="text" maxLength="5" size="16"
				name="OraEnd" runat="server">
		</td>
		<td>&nbsp;
			<asp:dropdownlist id="TipInterval" runat="server" Width="160px"></asp:dropdownlist></td>
		<td>
			&nbsp; <input type="checkbox" id="CheckInterval" runat="server"><input type="hidden" runat="server" id="IntervalID">
		</td>
	</tr>
</table>
