<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ChangePoza.ascx.cs" Inherits="SiemensHR.EditTasks.ChangePoza" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellSpacing="1" cellPadding="0" width="500" align="center" border="0">
	<tr>
		<td colSpan="2"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td colSpan="2"><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td colspan="2" align="center">
			<asp:Table id="tableTabs" runat="server"></asp:Table>
		</td>
		<!--  <td class=tab colspan=2 align=center>Schimba poza angajat</td>-->
	</tr>
	<tr>
		<td height="60">
			<table cellSpacing="0" cellPadding="0" width="100%" height="100%" align="center" border="0"
				class="tabBackground">
				<tr>
					<td align="right" class="NormalGreenBold" width="40%">Poza noua:&nbsp;</td>
					<td><INPUT class="NormalEditBoxuri" id="filePozaAngajat" type="file" name="File1" runat="server">
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Selectati poza!" ControlToValidate="filePozaAngajat"
							CssClass="AlertRedBold"><</asp:RequiredFieldValidator>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<TR>
		<TD align="center" colSpan="2" height="30">
			<asp:ValidationSummary id="ValidationSummary1" runat="server" CssClass="AlertRedBold"></asp:ValidationSummary>
		</TD>
	</TR>
	<tr>
		<td align="center" colspan="2" height="50">
			<asp:Button id="btnSalveaza" runat="server" Text="Salveaza" onmouseover="MouseOverButton(this)"
				onmouseout="MouseOutButton(this)" CssClass="ButtonStyle"></asp:Button></td>
	</tr>
</table>
