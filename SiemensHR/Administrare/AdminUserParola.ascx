<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminUserParola.ascx.cs" Inherits="SiemensHR.Administrare.AdminUserParola" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<FORM id="Form1" name="Form1" method="post" runat="server">
	<TABLE class="tabBackground" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
			<TD>
				<asp:literal id="litError" runat="server"></asp:literal></TD>
		</TR>
		<TR id="list_form">
			<TD align="center">
				<asp:table id="mainTable" runat="server"></asp:table></TD>
		</TR>
		<TR id="add_form" runat="server">
			<TD align="center">
				<TABLE id="Table2" cellSpacing="1" cellPadding="0" border="0">
					<TR>
						<TD class="BigBlueBold" id="tdTitle" align="center" colSpan="2" height="50" runat="server">Date 
							necesare&nbsp;vizualizarii aplicatiei</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<asp:table id="headerTable" runat="server"></asp:table></TD>
					</TR>
					<TR>
						<TD>
							<TABLE class="tabBackground" id="Table3" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
								</TR>
								<TR>
									<TD class="NormalGreenBold">Utilizator:</TD>
									<TD>
										<asp:textbox id="txtUtilizator" runat="server" CssClass="NormalEditBoxuri" Width="300px" MaxLength="100"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredUtilizator" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati numele utilizatorului!"
											ControlToValidate="txtUtilizator"><</asp:requiredfieldvalidator>
										<asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" CssClass="AlertRedBold" ErrorMessage="Numele utilizatorului nu poate sa contina caractere invalide: <>()';&quot;\"
											ControlToValidate="txtUtilizator" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></TD>
								</TR>
								<TR>
									<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
								</TR>
								<TR>
									<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
								</TR>
								<TR>
									<TD class="NormalGreenBold" id="tdNouaParola" runat="server">Parola:</TD>
									<TD>
										<asp:textbox id="txtParola" runat="server" CssClass="NormalEditBoxuri" Width="300px" TextMode="Password"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" CssClass="AlertRedBold" ErrorMessage="Trebuie completata parola!"
											ControlToValidate="txtParola"><</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="NormalGreenBold" colSpan="2">Dupa&nbsp;introducerea acestor date veti fi 
							redirectionat catre prima pagina a aplicatiei.</TD>
					</TR>
					<TR>
						<TD class="CommentRedBold" colSpan="2">* - Campuri obligatorii</TD>
					</TR>
					<TR id="td_addLine" runat="server">
						<TD align="center" colSpan="2" height="9" style="HEIGHT: 9px">
							<asp:button id="btnLogin" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Login"></asp:button>&nbsp;</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<asp:label id="lblMessage" runat="server" CssClass="AlertRedBold"></asp:label>&nbsp;</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<asp:validationsummary id="ValidationSummary1" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="AlertRedBold" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR id="add_buttonLine" height="50" runat="server">
			<TD align="center"></TD>
		</TR>
	</TABLE>
</FORM>
