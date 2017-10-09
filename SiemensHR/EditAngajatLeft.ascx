<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditAngajatLeft.ascx.cs" Inherits="SiemensHR.EditAngajatLeft" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table height="100%" cellSpacing="0" cellPadding="0" width="265" bgColor="#ededed" border="0"
	valign="top">
	<tr>
		<td style="PADDING-RIGHT: 2px; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; PADDING-TOP: 8px"
			vAlign="top" align="center" colSpan="2"><asp:image BorderWidth="1" id="imgAngajat" runat="server" width="150"></asp:image></td>
	</tr>
	<tr>
		<td colSpan="2"><IMG height="5" src="images/1x1.gif"></td>
	</tr>
	<TR>
		<TD vAlign="top" align="center" colSpan="2"><asp:label id="lblTitlu" runat="server" CssClass="NormalGreenBold"></asp:label></TD>
	</TR>
	<TR>
		<TD vAlign="top" align="center" colSpan="2"><asp:label id="lblNume" runat="server" CssClass="NormalBlackBold"></asp:label></TD>
	</TR>
	<TR>
		<TD vAlign="top" align="center" colSpan="2"><asp:label id="lblFunctie" runat="server" CssClass="NormalGreenBold"></asp:label></TD>
	</TR>
	<TR>
		<TD vAlign="top" align="center" colSpan="2"><asp:label id="lblDepartament" runat="server" CssClass="NormalGreenBold"></asp:label></TD>
	</TR>
	<tr>
		<td class="BlueSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
	</tr>
	<tr>
		<td colSpan="2"><IMG height="10" src="images/1x1.gif"></td>
	</tr>
	<tr>
		<td height="100%" id="TreeContainer" name="TreeContainer" valign="top" width="100%"
			align="left">
		</td>
	</tr>
	<tr>
		<td height="100%">&nbsp;</td>
	</tr>
</table>
<input type="hidden" id="LastSelectedNodeID" name="LastSelectedNodeID">
