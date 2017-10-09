<%@ Control Language="c#" AutoEventWireup="false" Codebehind="IntervalIntreruperiContract.ascx.cs" Inherits="SiemensTM.Module.IntervalIntreruperiContract" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table cellSpacing="0" cellPadding="0">
	<tr>
		<td class="TaskStyle">Perioada :&nbsp;</td>
		<td style="HEIGHT: 23px">
			<input id="DateStart" style="WIDTH: 70px; HEIGHT: 22px" type="text" maxLength="10" size="10"
				name="DateStart" runat="server">
		</td>
		<td style="HEIGHT: 23px" align="center" width="20">&nbsp;<b>:</b>&nbsp;
		</td>
		<td style="HEIGHT: 23px">
			<input id="DateEnd" style="WIDTH: 70px; HEIGHT: 22px" type="text" maxLength="10" size="10"
				name="DateEnd" runat="server">
		</td>
		<td>
			<input id="IntervalIntrerupereID" type="hidden" name="IntervalIntrerupereID" runat="server"
				style="WIDTH: 150px">
		</td>
		<td style="HEIGHT: 23px" align="left" width="100%">
			&nbsp; <input id="CheckInterval" type="checkbox" name="CheckInterval" runat="server">
		</td>
	</tr>
	<tr id="linieLabel" runat="server">
		<td style="HEIGHT: 23px"></td>
		<td style="HEIGHT: 23px" class="TaskStyleSmall"><asp:label id="LabelDataEnd" Runat="server">dd.mm.yyyy</asp:label></td>
		<td align="center" width="20" style="HEIGHT: 23px"></td>
		<td style="HEIGHT: 23px" class="TaskStyleSmall"><asp:label id="LabelDataStart" Runat="server">dd.mm.yyyy</asp:label></td>
	</tr>
	<tr>
		<td class="TaskStyle">Observatii :&nbsp;</td>
		<td colspan="4">
			<textarea id="observatiiTA" runat="server" name="observatiiTA" wrap="soft" style="WIDTH: 100%"></textarea>
		</td>
	</tr>
</table>
