<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditUtilizator.ascx.cs" Inherits="SiemensHR.Administrare.EditUtilizator" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<FORM id="Form1" runat="server">
	<TABLE class="tabBackground" id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
			<TD><asp:literal id="litError" runat="server"></asp:literal></TD>
		</TR>
		<TR id="listUtilizatori_form">
			<TD align="center"></TD>
		</TR>
		<TR id="addUtilizator_form">
			<TD align="center">
				<TABLE id="Table7" cellSpacing="1" cellPadding="0" border="0">
					<TR>
						<TD class="BigBlueBold" id="tdTitle" align="center" colSpan="2" height="50">Editare&nbsp;utilizator</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><asp:table id="headerTable" runat="server"></asp:table></TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 124px">
							<TABLE class="tabBackground" id="Table8" cellSpacing="1" cellPadding="0" border="0">
								<TR>
									<TD class="NormalGreenBold">Grup:</TD>
									<TD><asp:dropdownlist id="dropDownListGrupuri" runat="server" Width="304px" onChange="GrupChanged(this)"></asp:dropdownlist></TD>
								</TR>
								<TR>
									<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
								</TR>
								<TR>
									<TD class="NormalGreenBold">Utilizator:</TD>
									<TD><asp:textbox id="txtUtilizator" runat="server" Width="300px" CssClass="NormalEditBoxuri" MaxLength="100"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredUtilizator" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati numele utilizatorului!"
											ControlToValidate="txtUtilizator"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regExpUtilizator" runat="server" CssClass="AlertRedBold" ErrorMessage="Numele utilizatorului nu poate sa contina caractere invalide: <>()';&quot;\"
											ControlToValidate="txtUtilizator" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
								</TR>
								<TR>
									<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
								</TR>
								<TR>
									<TD class="NormalGreenBold">Email:</TD>
									<TD class="CommentRedBold"><asp:textbox id="txtEmail" runat="server" Width="300px" CssClass="NormalEditBoxuri"></asp:textbox>*
										<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="AlertRedBold" ErrorMessage="Trebuie completata adresa de mail!"
											ControlToValidate="txtEmail"><</asp:requiredfieldvalidator></TD>
								</TR>
								<TR>
									<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></TD>
								</TR>
								<TR>
									<TD class="NormalGreenBold" colSpan="2">Categoriile (nivelele) pentru care 
										utilizatorul are drepturi:</TD>
								</TR>
								<TR>
									<TD class="NormalGreenBold" colSpan="2"><asp:datalist id="listaNivele" runat="server" DataKeyField="IDNivelAngajat">
											<ItemTemplate>
												<asp:CheckBox id=checkBoxNivel runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"NivelAngajat")%>' CssClass="NormalBlackBold" Checked='<%#DataBinder.Eval(Container.DataItem,"EsteInNivel")%>'>
												</asp:CheckBox>
											</ItemTemplate>
										</asp:datalist></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD class="CommentRedBold" colSpan="2">* - Campuri obligatorii</TD>
					</TR>
					<TR id="addUtilizator_line">
						<TD align="center" colSpan="2" height="50"><asp:button id="btnSalveazaUtilizator" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Salveaza utilizator"></asp:button>&nbsp;
							<asp:button id="btnDeleteUtilizator" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Sterge utilizator" CausesValidation="False"></asp:button></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><asp:validationsummary id="vldSummary" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="AlertRedBold" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
					</TR>
					<TR id="idGrup_line">
						<TD align="center" colSpan="2"><INPUT id="txtGrupID" type="hidden" name="Hidden1" runat="server">&nbsp;</TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
</FORM>
