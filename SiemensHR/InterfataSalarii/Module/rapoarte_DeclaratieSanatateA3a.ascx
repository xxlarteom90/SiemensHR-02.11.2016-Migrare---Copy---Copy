<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_DeclaratieSanatateA3a.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_DeclaratieSanatateA3a" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<table id="main" height="100%" width="100%">
	<tr height="15%" width="100%">
		<td align="center" colSpan="2">
			<table>
				<tr>
					<td class="NormalGreenBold">Casa de asigurari:
					</td>
					<td><asp:dropdownlist id="drpCaseDeAsig" runat="server" Width="210px" CssClass="NormalEditBoxuri"></asp:dropdownlist><SPAN class="CommentRedBold">*</SPAN>
					</td>
				</tr>
				<tr>
					<td class="CommentRedBold" align="left" colspan="2">* - Campuri obligatorii
					</td>
				</tr>
				<tr>
					<td align="center" colspan="2">
						<asp:button id="btnAfiseaza" runat="server" Text="Afiseaza" CssClass="ButtonStyle"></asp:button>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<TR height="5%" width="100%">
		<TD style="HEIGHT: 22px" align="left" colspan="2">
			<asp:label id="labelError" runat="server" CssClass="AlertRedBold"></asp:label>
		</TD>
	</TR>
	<tr height="1%" width="100%">
		<td align="center" colSpan="2">
			<asp:ValidationSummary id="sumarValidare" runat="server" ShowMessageBox="True" Width="159px" ShowSummary="False"></asp:ValidationSummary>
		</td>
	</tr>
	<TR height="79%" width="100%">
		<TD vAlign="top" colSpan="2"><cc1:reportviewer id="raportSanatate" runat="server" Width="100%" Height="500px" BackColor="White"
				BorderColor="Transparent" Parameters="False" Toolbar="True" ForeColor="White" Zoom="100%" ReportPath="/Rapoarte/Anexa3a"></cc1:reportviewer></TD>
	</TR>
</table>
