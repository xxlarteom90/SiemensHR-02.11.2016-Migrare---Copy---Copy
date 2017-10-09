<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_DeclaratieUnica.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_DeclaratieUnica" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<table style="WIDTH: 496px; HEIGHT: 44px" id="main" width="496" height="44">
	<tr height="15%" width="100%">
		<td colSpan="2" align="center"><asp:button style="Z-INDEX: 0" id="btnGenereaza" CssClass="ButtonStyle" runat="server" Text="Genereaza fisierul xml pentru declaratia unica"></asp:button></td>
	</tr>
	<TR>
		<TD style="HEIGHT: 46px" class="NormalGreenBold" colSpan="2" align="center"><asp:hyperlink id="hyperLinkDeclaratie" runat="server" Target="_blank">download declaratie unica</asp:hyperlink></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 22px" colSpan="2" align="center">
			<asp:button style="Z-INDEX: 0" id="btnValideaza" Text="Valideaza fisierul" runat="server" CssClass="ButtonStyle"></asp:button></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 22px" class="NormalGreenBold" colSpan="2" align="center">
			<asp:hyperlink style="Z-INDEX: 0" id="hyperLinkFisierErori" runat="server" Target="_blank">download fisier erori</asp:hyperlink></TD>
	</TR>
	<TR>
		<TD style="HEIGHT: 22px" class="NormalGreenBold" colSpan="2" align="center">
			<asp:hyperlink style="Z-INDEX: 0" id="hyperLinkFisierPdf" runat="server" Target="_blank">download fisier pdf</asp:hyperlink></TD>
	</TR>
	<TR height="5%" width="100%">
		<TD style="HEIGHT: 22px" colSpan="2" align="left"><asp:label id="labelError" CssClass="AlertRedBold" runat="server"></asp:label></TD>
	</TR>
	<tr height="1%" width="100%">
		<td colSpan="2" align="center"><asp:validationsummary id="sumarValidare" runat="server" Width="452px" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
	</tr>
</table>
