<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_DateLichidare.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_DateLichidare" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table id="main" height="100%" width="100%">
	<tr height="15%" width="100%">
		<td align="center" colSpan="2">
			<table>
				<tr>
					<td class="NormalGreenBold" style="HEIGHT: 17px">Angajatul lichidat:
					</td>
					<td style="HEIGHT: 17px"><asp:dropdownlist id="drpAngajatiLichidati" CssClass="NormalEditBoxuri" Width="331px" runat="server"></asp:dropdownlist><SPAN class="CommentRedBold">*</SPAN>
					</td>
				</tr>
				<tr>
					<td class="CommentRedBold" align="left" colSpan="2">* - Campuri obligatorii
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><asp:button id="btnAfiseaza" CssClass="ButtonStyle" runat="server" Text="Afiseaza"></asp:button></td>
				</tr>
			</table>
		</td>
	</tr>
	<TR height="5%" width="100%">
		<TD style="HEIGHT: 22px" align="left" colSpan="2"><asp:label id="labelError" CssClass="AlertRedBold" runat="server"></asp:label></TD>
	</TR>
	<tr height="1%" width="100%">
		<td align="center" colSpan="2"><asp:validationsummary id="sumarValidare" Width="159px" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
	</tr>
	<TR height="79%" width="100%">
		<TD vAlign="top" colSpan="2"><cc1:reportviewer id="raportDateLichidare" Width="100%" runat="server" ReportPath="/Rapoarte/AnexaLaNL"
				Zoom="100%" ForeColor="White" Toolbar="True" Parameters="False" BorderColor="Transparent" BackColor="White" Height="500px"></cc1:reportviewer></TD>
	</TR>
</table>
