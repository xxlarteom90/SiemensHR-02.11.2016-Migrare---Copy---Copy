<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_DeclaratieSanatateA1.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_DeclaratieSanatateA1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
</SCRIPT>
<table id="main" height="100%" width="100%">
	<tr>
		<td align="center" colSpan="2">
			<table>
				<tr>
					<td class="NormalGreenBold">Data platii:
					</td>
					<td><asp:textbox id="txtDataPlatii" CssClass="NormalEditBoxuri" Width="210px" runat="server" MaxLength="10"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
						<asp:requiredfieldvalidator id="requiredData" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDataPlatii"
							ErrorMessage="Completati data platii!"><</asp:requiredfieldvalidator>
						<asp:regularexpressionvalidator id="vldData" runat="server" ErrorMessage="Trebuie sa completati corect data platii!"
							ControlToValidate="txtDataPlatii" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[/.](0[1-9]|1[012])[/.](19|20)\d\d"
							CssClass="AlertRedBold"><</asp:regularexpressionvalidator></td>
				</tr>
				<tr>
					<td class="NormalGreenBold">Cont angajator:
					</td>
					<td><asp:dropdownlist id="drpContAngajator" CssClass="NormalEditBoxuri" Width="210px" runat="server"></asp:dropdownlist><SPAN class="CommentRedBold">*</SPAN>
					</td>
				</tr>
				<tr>
					<td class="NormalGreenBold" style="HEIGHT: 25px">Numar file anexa 2:
					</td>
					<td style="HEIGHT: 25px"><asp:textbox id="txtNrFleAnexa2" CssClass="NormalEditBoxuri" Width="208px" runat="server" MaxLength="6">0</asp:textbox><SPAN class="CommentRedBold">*
							<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNrFleAnexa2"
								ErrorMessage="Completati numar file anexa 2!"><</asp:requiredfieldvalidator>
							<asp:rangevalidator id="vldNrFileAnexa2" runat="server" MinimumValue="0" MaximumValue="999999" Type="Integer"
								ErrorMessage="Trebuie sa completati corect numarul de file ale anexei 2!" ControlToValidate="txtNrFleAnexa2"
								CssClass="AlertRedBold"><</asp:rangevalidator></SPAN></td>
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
		<td style="HEIGHT: 88px" align="center" colSpan="2">
			<asp:validationsummary id="sumarValidare" Width="159px" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
	</tr>
	<TR>
		<TD style="HEIGHT: 22px" align="left" colSpan="2"><asp:label id="labelError" CssClass="AlertRedBold" runat="server"></asp:label></TD>
	</TR>
	<TR>
		<TD vAlign="top" colSpan="2"><cc1:reportviewer id="raportDeclaratieA1" Width="100%" runat="server" ReportPath="/Rapoarte/CM_DCL_A1"
				Zoom="100%" ForeColor="White" Toolbar="True" Parameters="False" BorderColor="Transparent" BackColor="White" 
				Height="139px"></cc1:reportviewer></TD>
	</TR>
</table>
