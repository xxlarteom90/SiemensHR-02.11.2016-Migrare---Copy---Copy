<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminChangePassword.ascx.cs" Inherits="SiemensHR.Administrare.AdminChangePassword" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
function sp3FormIDfix()
{
	document.forms[0].id=ctrlID + "_Form1";
	document.getElementById(requiredUtilizatorClientID).innerText = '';
	document.getElementById(regExpUtilizatorClientID).innerText = '';
	document.getElementById(requiredParolaVecheClientID).innerText = '';	
	document.getElementById(requiredParolaClientID).innerText = '';	
	document.getElementById(requiredConfirmareClientID).innerText = '';
	document.getElementById(compareValParolaConfirmareClientID).innerText = '';
}
</script>
<form id="Form1" name="Form1" method="post" encType="multipart/form-data" runat="server">
	<TABLE class="tabBackground" id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
			<TD>
				<asp:literal id="litError" runat="server"></asp:literal></TD>
		</TR>
		<TR id="listUtilizatori_form">
			<TD align="center"></TD>
		</TR>
		<TR id="addUtilizator_form">
			<TD align="center">
				<TABLE id="Table7" cellSpacing="1" cellPadding="0" border="0">
					<TR>
						<TD class="BigBlueBold" id="tdTitle" align="center" colSpan="2" height="50">Modificare date 
							utilizator</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<asp:table id="headerTable" runat="server"></asp:table></TD>
					</TR>
					<TR>
						<TD>
							<TABLE class="tabBackground" id="Table8" cellSpacing="1" cellPadding="0" border="0">
								<TR>
									<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
								</TR>
								<TR>
									<TD class="NormalGreenBold">Utilizator:</TD>
									<TD>
										<asp:textbox id="txtUtilizator" runat="server" Width="300px" CssClass="NormalEditBoxuri" MaxLength="100"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredUtilizator" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati numele utilizatorului!"
											ControlToValidate="txtUtilizator"><</asp:requiredfieldvalidator>
										<asp:regularexpressionvalidator id="regExpUtilizator" runat="server" CssClass="AlertRedBold" ErrorMessage="Numele utilizatorului nu poate sa contina caractere invalide: <>()';&quot;\"
											ControlToValidate="txtUtilizator" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
								</TR>
								<TR>
									<TD class="NormalGreenBold">Vechea parola:</TD>
									<TD>
										<asp:textbox id="txtParolaVeche" runat="server" Width="300px" CssClass="NormalEditBoxuri" TextMode="Password"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredParolaVeche" runat="server" CssClass="AlertRedBold" ErrorMessage="Trebuie completata parola!"
											ControlToValidate="txtParolaVeche"><</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
								</TR>
								<TR>
									<TD class="NormalGreenBold">Noua parola:</TD>
									<TD>
										<asp:textbox id="txtParolaNoua" runat="server" Width="300px" CssClass="NormalEditBoxuri" TextMode="Password"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredParola" runat="server" CssClass="AlertRedBold" ErrorMessage="Trebuie completata parola!"
											ControlToValidate="txtParolaNoua"><</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
								</TR>
								<TR id="confirmare_line">
									<TD class="NormalGreenBold">Confirmare parola:</TD>
									<TD>
										<asp:textbox id="txtConfirmareParola" runat="server" Width="300px" CssClass="NormalEditBoxuri"
											TextMode="Password"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredConfirmare" runat="server" CssClass="AlertRedBold" ErrorMessage="Trebuie completata confiramrea parolei!"
											ControlToValidate="txtConfirmareParola"><</asp:requiredfieldvalidator>
										<asp:comparevalidator id="compareValParolaConfirmare" runat="server" CssClass="AlertRedBold" ErrorMessage="Confirmarea trebuie sa coincida cu parola!"
											ControlToValidate="txtConfirmareParola" ControlToCompare="txtParolaNoua"><</asp:comparevalidator></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="CommentRedBold" colSpan="2">* - Campuri obligatorii</TD>
					</TR>
					<TR id="addUtilizator_line">
						<TD align="center" colSpan="2" height="50">
							<asp:button id="btnModifyUtilizator" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Modifica utilizator"></asp:button></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2">
							<asp:validationsummary id="vldSummary" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="AlertRedBold" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
</form>
<script>
	sp3FormIDfix();
</script>

