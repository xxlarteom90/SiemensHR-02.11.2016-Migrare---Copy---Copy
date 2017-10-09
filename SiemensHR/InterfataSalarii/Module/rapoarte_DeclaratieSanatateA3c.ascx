<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_DeclaratieSanatateA3c.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_DeclaratieSanatateA3c" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table id="main" height="100%" width="100%">
	<tr>
		<td align="center" valign="middle" colSpan="2" height="35%">
			<table>
				<tr>
					<td class="NormalGreenBold">Suma restanta:
					</td>
					<td><asp:textbox id="txtSumaRestanta" MaxLength="8" CssClass="NormalEditBoxuri" Width="296px" runat="server">0</asp:textbox><SPAN class="CommentRedBold">*</SPAN>
						<asp:requiredfieldvalidator id="requiredData" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSumaRestanta"
							ErrorMessage="Completati suma restanta!"><</asp:requiredfieldvalidator>
						<asp:RangeValidator id="vldSumaRestanta" runat="server" ErrorMessage="Trebuie sa completati corect suma restanta!"
							Type="Double" MinimumValue="0" MaximumValue="99999999" ControlToValidate="txtSumaRestanta" CssClass="AlertRedBold"><</asp:RangeValidator></td>
				</tr>
				<tr>
					<td class="NormalGreenBold">Data platii:
					</td>
					<td><asp:textbox id="txtDataPlatii" MaxLength="10" CssClass="NormalEditBoxuri" Width="296px" runat="server"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
						<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDataPlatii"
							ErrorMessage="Completati data platii!"><</asp:requiredfieldvalidator>
						<asp:regularexpressionvalidator id="vldData" runat="server" ControlToValidate="txtDataPlatii" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[/.](0[1-9]|1[012])[/.](19|20)\d\d"
							ErrorMessage="Trebuie sa completati corect data platii!" CssClass="AlertRedBold"><</asp:regularexpressionvalidator></td>
				</tr>
				<tr>
					<td class="NormalGreenBold">Reprezentant legal:
					</td>
					<td><asp:dropdownlist id="drpReprezentantLegal" runat="server" Width="297px" CssClass="NormalEditBoxuri"></asp:dropdownlist><SPAN class="CommentRedBold">*</SPAN>
					</td>
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
	<TR height="5%">
		<TD align="left"><asp:label id="labelError" CssClass="AlertRedBold" runat="server"></asp:label></TD>
	</TR>
	<tr height="1%">
		<td align="center" colSpan="2">
			<asp:validationsummary id="sumarValidare" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
	</tr>
	<TR height="64%">
		<TD vAlign="top" colSpan="2">
			<cc1:reportviewer id="raportSanatate" runat="server" ReportPath="/Rapoarte/Anexa3c" Zoom="100%" ForeColor="White"
				Toolbar="True" Parameters="False" BorderColor="Transparent" BackColor="White" width="100%" height="500px"></cc1:reportviewer>
		</TD>
	</TR>
</table>
