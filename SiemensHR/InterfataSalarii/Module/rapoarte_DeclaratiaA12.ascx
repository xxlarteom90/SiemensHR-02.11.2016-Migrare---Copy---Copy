<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_DeclaratiaA12.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_DeclaratiaA12" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<table id="main" height="100%" width="100%">
	<tr>
		<td align="center" colSpan="2">
			<table>
				<tr>
					<td class="NormalGreenBold">Data platii:
					</td>
					<td><asp:textbox id="txtDataPlatii" MaxLength="10" CssClass="NormalEditBoxuri" Width="210px" runat="server"></asp:textbox><SPAN class="CommentRedBold">*
							<asp:requiredfieldvalidator id="requiredData" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati data platii!"
								ControlToValidate="txtDataPlatii"><</asp:requiredfieldvalidator></SPAN>
						<asp:regularexpressionvalidator id="vldData" runat="server" ControlToValidate="txtDataPlatii" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[/.](0[1-9]|1[012])[/.](19|20)\d\d"
							ErrorMessage="Trebuie sa completati corect data platii!" CssClass="AlertRedBold"><</asp:regularexpressionvalidator></td>
				</tr>
				<tr>
					<td class="NormalGreenBold">Numar file anexa A11:
					</td>
					<td><asp:textbox id="txtNrFileAnexa11" MaxLength="6" Width="208px" runat="server">0</asp:textbox><SPAN class="CommentRedBold">*</SPAN>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati numar file anexa A11!"
							ControlToValidate="txtNrFileAnexa11"><</asp:requiredfieldvalidator>
						<asp:rangevalidator id="vldNrFileAnexa11" runat="server" ControlToValidate="txtNrFileAnexa11" ErrorMessage="Numarul de file al anexei A11 trebuie completat corect!"
							MaximumValue="999999" MinimumValue="0" Type="Integer" CssClass="AlertRedBold"><</asp:rangevalidator></td>
				</tr>
				<tr>
					<td class="CommentRedBold" align="left" colSpan="2">* - Campuri obligatorii
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="2">
						<asp:button id="btnAfiseaza" CssClass="ButtonStyle" runat="server" Text="Afiseaza"></asp:button>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td style="HEIGHT: 75px" align="center" colSpan="2">
			<asp:validationsummary id="sumarValidare" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
	</tr>
	<TR>
		<TD style="HEIGHT: 22px" align="left"><asp:label id="labelError" CssClass="AlertRedBold" runat="server"></asp:label></TD>
	</TR>
	<TR>
		<TD vAlign="top" colSpan="2"><cc1:reportviewer id="raportDeclaratiaA12" runat="server" ReportPath="/Rapoarte/A12" Zoom="100%" ForeColor="White"
				Toolbar="True" Parameters="False" BorderColor="Transparent" BackColor="White"
				width="100%"></cc1:reportviewer></TD>
	</TR>
	<tr>
		<td>
			<asp:Button id="btnDownloadA12" runat="server" CssClass="ButtonStyle" Text="Download a12.txt"></asp:Button>
		</td>
	</tr>
</table>
