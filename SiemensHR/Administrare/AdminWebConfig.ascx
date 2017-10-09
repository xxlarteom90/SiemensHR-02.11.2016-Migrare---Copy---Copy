<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminWebConfig.ascx.cs" Inherits="SiemensHR.Administrare.AdminWebConfig" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<form id="Form1" name="Form1" method="post" runat="server">
	<table class="tabBackground" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<tr>
			<td><asp:literal id="litError" runat="server"></asp:literal></td>
		</tr>
		<tr id="list_form">
			<td align="center"><asp:table id="mainTable" runat="server"></asp:table></td>
		</tr>
		<TR id="add_form" runat="server">
			<TD align="center">
				<table id="Table2" cellSpacing="1" cellPadding="0" border="0">
					<tr>
						<td class="BigBlueBold" id="tdTitle" align="center" colSpan="2" height="50" runat="server">Date 
							necesare conectarii la baza de date</td>
					</tr>
					<tr>
						<td align="center" colSpan="2"><asp:table id="headerTable" runat="server"></asp:table></td>
					</tr>
					<tr>
						<td>
							<table class="tabBackground" id="Table3" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<tr>
									<td class="NormalGreenBold">Numele serverului:</td>
									<td><asp:textbox id="txtNumeServer" runat="server" CssClass="NormalEditBoxuri" Width="300px"></asp:textbox>
										<SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Trebuie completat numele server-ului!"
											ControlToValidate="txtNumeServer" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
										<asp:RegularExpressionValidator id="regularCod" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNumeServer"
											ErrorMessage="Numele serverului nu poate sa contina caractere invalide: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold">Numele bazei de date:</TD>
									<TD><asp:textbox id="txtNumeBazaDeDate" runat="server" CssClass="NormalEditBoxuri" Width="300px"></asp:textbox>
										<SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ErrorMessage="Trebuie completat numele bazei de date!"
											ControlToValidate="txtNumeBazaDeDate" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
										<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNumeBazaDeDate"
											ErrorMessage="Numele bazei de date nu poate sa contina caractere invalide: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td class="NormalGreenBold">Utilizator:</td>
									<td><asp:textbox id="txtNumeUtilizator" runat="server" CssClass="NormalEditBoxuri" Width="300px"
											MaxLength="100"></asp:textbox>
										<SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredUtilizator" runat="server" ErrorMessage="Completati numele utilizatorului!"
											ControlToValidate="txtNumeUtilizator" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
										<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" CssClass="AlertRedBold" ControlToValidate="txtNumeServer"
											ErrorMessage="Numele utilizatorului nu poate sa contina caractere invalide: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold" id="tdVecheaParola" runat="server">Vechea parola:</TD>
									<TD><asp:textbox id="txtVecheaParola" runat="server" CssClass="NormalEditBoxuri" Width="300px" TextMode="Password"></asp:textbox>
										<SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="Trebuie completata vechea parola !"
											ControlToValidate="txtVecheaParola" CssClass="AlertRedBold"><</asp:requiredfieldvalidator></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold" id="tdNouaParola" runat="server">Noua parola:</TD>
									<TD><asp:textbox id="txtNouaParola" runat="server" CssClass="NormalEditBoxuri" Width="300px" TextMode="Password"></asp:textbox>
										<SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="Trebuie completata noua parola!"
											ControlToValidate="txtNouaParola" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
									</TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold" id="tdConfirmareNouaParola" runat="server">Confirmare 
										parola:</TD>
									<TD><asp:textbox id="txtConfirmareParola" runat="server" CssClass="NormalEditBoxuri" Width="300px"
											TextMode="Password"></asp:textbox>
										<SPAN class="CommentRedBold">*</SPAN>
										<asp:comparevalidator id="CompareValidator1" runat="server" ErrorMessage="Valoarea introdusa pentru confirmarea parolei nu coincide cu parola introdusa initial!"
											ControlToValidate="txtConfirmareParola" ControlToCompare="txtNouaParola" CssClass="AlertRedBold"><</asp:comparevalidator>
										<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" ErrorMessage="Trebuie completat campul de confirmare pentru noua parola!"
											ControlToValidate="txtConfirmareParola" CssClass="AlertRedBold"><</asp:requiredfieldvalidator></TD>
								</TR>
							</table>
						</td>
					</tr>
					<TR>
						<TD class="NormalGreenBold" colSpan="2">Dupa salvarea acestor date veti fi 
							redirectionat catre prima pagina a aplicatiei.</TD>
					</TR>
					<TR>
						<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii</td>
					</TR>
					<tr id="td_addLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnAdd" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Salveaza date"></asp:button>&nbsp;</td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:label id="lblMessage" runat="server" CssClass="AlertRedBold"></asp:label>&nbsp;</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><asp:validationsummary id="ValidationSummary1" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="AlertRedBold" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
					</TR>
				</table>
			</TD>
		</TR>
		<tr id="add_buttonLine" height="50" runat="server">
			<td align="center"></td>
		</tr>
	</table>
</form>
