<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminCaseDeAsigurari.ascx.cs" Inherits="SiemensHR.Administrare.AdminCaseDeAsigurari" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
	function sp3FormIDfix() {
		document.forms[0].id=ctrlID + "_Form1";
		
		document.getElementById(requiredDenumireClientID).innerText = '';
		document.getElementById(requiredCodClientID).innerText = '';
		document.getElementById(requiredDescriereClientID).innerText = '';	
		document.getElementById(requiredCodificareClientID).innerText = '';
		document.getElementById(regularDenumireClientID).innerText = '';
		document.getElementById(regularCodClientID).innerText = '';
		document.getElementById(regularDescriereClientID).innerText = '';	
		document.getElementById(regularCodificareClientID).innerText = '';
	}
	
	function ShowAddForm() 
	{
		list_form.style.display = "none";
		eval(ctrlID + "_add_buttonLine.style.display = 'none'");
		eval(ctrlID + "_add_form.style.display = ''");		
		eval(ctrlID + "_Form1." + ctrlID + "_txtDenumire.value = '';");	
		eval(ctrlID + "_Form1." + ctrlID + "_txtCod.value = '';");	
		eval(ctrlID + "_Form1." + ctrlID + "_txtDescriere.value = '';");
		eval(ctrlID + "_Form1." + ctrlID + "_txtCodificare.value = '';");
	}

	function ShowList() {
		list_form.style.display = "";
		eval(ctrlID + "_add_buttonLine.style.display = ''");
		eval(ctrlID + "_add_form.style.display = 'none'");
	}

	function SelectLine( id, activ ) 
	{
		eval(ctrlID + "_Form1." + ctrlID + "_txtCasaDeAsigurariID.value = id;");
		eval(ctrlID + "_Form1." + ctrlID + "_btnEdit.click();");		
	}
</script>
<FORM id="Form1" name="Form1" method="post" runat="server">
	<TABLE class="tabBackground" id="Table1" height="200" cellSpacing="0" cellPadding="0" width="100%"
		border="0">
		<TR>
			<TD><asp:literal id="litError" runat="server"></asp:literal></TD>
		</TR>
		<TR id="list_form">
			<TD align="center"><asp:table id="mainTable" runat="server"></asp:table></TD>
		</TR>
		<TR id="add_form" runat="server">
			<TD align="center">
				<TABLE id="Table2" cellSpacing="1" cellPadding="0" border="0">
					<TR>
						<TD class="BigBlueBold" id="tdTitle" align="center" colSpan="2" height="50" runat="server">Adaugare&nbsp;casa 
							de asigurari</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><asp:table id="headerTable" runat="server"></asp:table></TD>
					</TR>
					<TR>
						<TD>
							<TABLE class="tabBackground" id="Table3" cellSpacing="1" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="NormalGreenBold" style="WIDTH: 83px">Denumire:&nbsp;</TD>
									<TD>&nbsp;
										<asp:textbox id="txtDenumire" runat="server" Width="278px" MaxLength="50" CssClass="NormalEditBoxuri"
											size="50"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredDenumire" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDenumire"
											ErrorMessage="Completati denumirea casei de asigurari!"><</asp:requiredfieldvalidator>
										<asp:RegularExpressionValidator id="regularDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Denumirea nu poate sa contina caractere invalide: <>()';&quot;\ "
											ControlToValidate="txtDenumire" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold" style="WIDTH: 83px">Cod:&nbsp;</TD>
									<TD>&nbsp;
										<asp:textbox id="txtCod" runat="server" Width="278px" MaxLength="10" CssClass="NormalEditBoxuri"
											size="50"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredCod" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCod"
											ErrorMessage="Completati codul!"><</asp:requiredfieldvalidator>
										<asp:RegularExpressionValidator id="regularCod" runat="server" CssClass="AlertRedBold" ErrorMessage="Codul nu poate sa contina caractere invalide: <>()';&quot;\ "
											ControlToValidate="txtCod" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold" style="WIDTH: 83px">Descriere:&nbsp;</TD>
									<TD>&nbsp;
										<asp:textbox id="txtDescriere" runat="server" Width="277px" MaxLength="250" CssClass="AreaStyle"
											Columns="40" TextMode="MultiLine" Rows="3"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredDescriere" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDescriere"
											ErrorMessage="Completati descrierea!"><</asp:requiredfieldvalidator>
										<asp:RegularExpressionValidator id="regularDescriere" runat="server" CssClass="AlertRedBold" ErrorMessage="Descrierea nu poate sa contina caractere invalide: <>()';&quot;\ "
											ControlToValidate="txtDescriere" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold" style="WIDTH: 83px">Codificare:&nbsp;</TD>
									<TD>&nbsp;
										<asp:textbox id="txtCodificare" runat="server" Width="278px" MaxLength="10" CssClass="NormalEditBoxuri"
											size="50"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredCodificare" runat="server" CssClass="AlertRedBold" ControlToValidate="txtCodificare"
											ErrorMessage="Completati codul!"><</asp:requiredfieldvalidator>
										<asp:RegularExpressionValidator id="regularCodificare" runat="server" CssClass="AlertRedBold" ErrorMessage="Codificarea nu poate sa contina caractere invalide: <>()';&quot;\ "
											ControlToValidate="txtCodificare" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></TD>
								</TR>
							</TABLE>
							<asp:textbox id="txtCasaDeAsigurariID" runat="server"></asp:textbox></TD>
					</TR>
					<TR>
						<TD class="CommentRedBold" colSpan="2">* - Campuri obligatorii</TD>
					</TR>
					<TR id="td_addLine" runat="server">
						<TD align="center" colSpan="2" height="50"><asp:button id="btnAdd" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Salveaza casa de asigurari"></asp:button>&nbsp;
							<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowList()" onmouseout="MouseOutButton(this)"
								type="button" value="  Inapoi  ">
							<asp:button id="btnEdit" runat="server" Text="Edit" CausesValidation="False"></asp:button></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><asp:label id="lblMessage" runat="server" CssClass="AlertRedBold"></asp:label>&nbsp;</TD>
					</TR>
					<TR id="td_editLine" runat="server">
						<TD align="center" colSpan="2" height="50"><asp:button id="btnModify" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Salveaza modificarile"></asp:button>&nbsp;
							<asp:button id="btnDelete" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Sterge casa de asigurari" CausesValidation="False"></asp:button>&nbsp;
							<asp:button id="btnInapoi" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="   Inapoi   " CausesValidation="False"></asp:button></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><asp:validationsummary id="ValidationSummary1" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="AlertRedBold" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
		<TR id="add_buttonLine" runat="server">
			<TD align="center" height="50">
				<TABLE id="Table4" cellSpacing="0" cellPadding="0" border="0">
					<TR>
						<TD class="UnderlineBlackBold">Pentru a adauga o&nbsp;casa de asigurare noua, 
							apasati pe acest buton:
						</TD>
						<TD>&nbsp;<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowAddForm()"
								onmouseout="MouseOutButton(this)" type="button" value="Casa de asigurare noua">&nbsp;</TD>
					</TR>
				</TABLE>
			</TD>
		</TR>
	</TABLE>
</FORM>
<SCRIPT>
sp3FormIDfix();
</SCRIPT>
