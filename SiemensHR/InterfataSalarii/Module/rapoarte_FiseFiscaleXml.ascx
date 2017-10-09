<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_FiseFiscaleXml.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_FiseFiscaleXml" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<table id="main" height="100%" width="100%" style="Z-INDEX: 0">
	<tr height="15%" width="100%">
		<td align="center" colSpan="2">
			<table>
				<TR>
					<TD class="NormalGreenBold" style="HEIGHT: 26px">An:</TD>
					<TD style="HEIGHT: 26px">
						<asp:TextBox id="textBoxAn" CssClass="NormalEditBoxuri" runat="server"></asp:TextBox>
						<asp:RequiredFieldValidator id="reqFieldValAn" runat="server" ErrorMessage="Trebuie inrodus anul pentru care se doreste fisa fiscale!"
							ControlToValidate="textBoxAn"><</asp:RequiredFieldValidator>
						<asp:RangeValidator id="rangeValAn" runat="server" ErrorMessage="Introduceti un an!" Type="Integer"
							MinimumValue="1900" MaximumValue="3000" ControlToValidate="textBoxAn"><</asp:RangeValidator></TD>
				</TR>
				<tr>
					<td class="NormalGreenBold">Casa de asigurari:
					</td>
					<td><asp:dropdownlist id="drpCaseDeAsig" runat="server" Width="210px" CssClass="NormalEditBoxuri"></asp:dropdownlist><SPAN class="CommentRedBold">*</SPAN>
					</td>
				</tr>
				<TR>
					<td class="NormalGreenBold">Tip declaratie:
					</td>
					<td><asp:dropdownlist id="drpTipDeclaratie" runat="server" Width="210px" CssClass="NormalEditBoxuri">
							<asp:ListItem Value="0">Declaratie Initiala</asp:ListItem>
							<asp:ListItem Value="1">Declaratie Rectificativa</asp:ListItem>
						</asp:dropdownlist><SPAN class="CommentRedBold">*</SPAN></td>
				<tr>
					<td class="CommentRedBold" align="left" colspan="2">* - Campuri obligatorii
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr height="15%" width="100%">
		<td align="center" colSpan="2">
			<table style="WIDTH: 496px; HEIGHT: 44px" id="main" width="496" height="44">
				<tr height="15%" width="100%">
					<td colSpan="2" align="center"><asp:button style="Z-INDEX: 0" id="btnGenereaza" CssClass="ButtonStyle" runat="server" Text="Genereaza fisierul xml pentru fise fiscale"></asp:button></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 46px" class="NormalGreenBold" colSpan="2" align="center"><asp:hyperlink id="hyperLinkDeclaratie" runat="server" Target="_blank">download fise fiscale</asp:hyperlink></TD>
				</TR>
				<tr height="1%" width="100%">
					<td colSpan="2" align="center"><asp:validationsummary id="sumarValidare" runat="server" Width="452px" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</table>
		</td>
	</tr>
	<TR height="10%" width="100%">
		<TD style="HEIGHT: 22px" align="left" colspan="2">
			<asp:label id="labelError" runat="server" CssClass="AlertRedBold" style="Z-INDEX: 0"></asp:label></TD>
		</TD>
	</TR>
</table>
