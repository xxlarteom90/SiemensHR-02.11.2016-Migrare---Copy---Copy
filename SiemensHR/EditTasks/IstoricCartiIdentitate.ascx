<%@ Control Language="c#" AutoEventWireup="false" Codebehind="IstoricCartiIdentitate.ascx.cs" Inherits="SiemensHR.EditTasks.IstoricCartiIdentitate" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
var arTabs = new Array('tableIstoricCartiIdentitate', 'tableAdaugaCartiIdentitate');

	function SelectTab(index)
	{
		for(i=0; i<arTabs.length; i++)
		{
			if (i==index)
			{
				eval(arTabs[i] + ".style.display=''");
				eval(ctrlID + "_tab"+ (i+1)+ ".className='tabActive'");
				add_line.style.display = "";
				edit_line.style.display = "none";
				//eval(ctrlID + "_Form1." + ctrlID + "_txtDataStart.value = '';");
					
			}
			else
			{
				eval(ctrlID + "_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID + "_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabs[i] + ".style.display='none'");
			}
		}
		
		eval( ctrlID+"_Form1."+ctrlID+"_txtCNP.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtCNPAnterior.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtCISerie.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtCINumar.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtCIEliberatDe.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtCIDataEliberarii.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtCIValabilPanaLa.value = '';" );
		eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked = false;");
		eval( ctrlID+"_Form1."+ctrlID+"_txtCarteIdentitateIDHidden.value = '';");
		
		if( index == 1 ) {
			eval( ctrlID + "_trActivSeparator.style.display = '';" );
			eval( ctrlID + "_trActiv.style.display = '';" );
			titluTab.innerText = "Adaugare carte de identitate";
		}
	}
	
	function SelectCarteIdentitate( angajatID, CarteIdentitateID, cnp, cnpAnterior, serie, numar, eliberatDe, dataEliberare, dataExpirare, activ)
	{
		tableIstoricCartiIdentitate.style.display = "none";
		tableAdaugaCartiIdentitate.style.display = "";
		edit_line.style.display = "";
		add_line.style.display = "none";
		titluTab.innerText = "Editare carte de identitate";
		
		eval( ctrlID+"_Form1."+ctrlID+"_txtCNP.value = cnp;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtCNPAnterior.value = cnpAnterior;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtCISerie.value = serie;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtCINumar.value = numar;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtCIEliberatDe.value = eliberatDe;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtCIDataEliberarii.value = dataEliberare;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtCIValabilPanaLa.value = dataExpirare;" );
		eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked = activ;");
		eval( ctrlID+"_Form1."+ctrlID+"_txtCarteIdentitateIDHidden.value = CarteIdentitateID;");
		
		if( activ=="False" )
		{
			eval(ctrlID + "_trActiv.style.display ='';");
			eval(ctrlID + "_trActivSeparator.style.display ='';");
		    eval(ctrlID + "_Form1." + ctrlID + "_btnStergeDate.style.display = '';");
			eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked =false;");
		}
		else
		{
			eval(ctrlID + "_trActiv.style.display ='none';");
			eval(ctrlID + "_trActivSeparator.style.display ='none';");
		    eval(ctrlID + "_Form1." + ctrlID + "_btnStergeDate.style.display = 'none';");		
			eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked =true;");
		}
		
		
		/*
		eval(ctrlID + "_trActiv.style.display ='';");
		eval(ctrlID + "_trActivSeparator.style.display ='';");
		
		*/
		
	}
	
	function BackToList()
	{
		tableAdaugaCartiIdentitate.style.display='none';
		tableIstoricCartiIdentitate.style.display='';
		edit_line.style.display = "none";
		add_line.style.display = "";
		
	}


</script>
<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0" valign="top">
	<tr>
		<td><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td><asp:table id="tableTabs" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td id="tableIstoricCartiIdentitate" vAlign="top" align="center" height="100%"><asp:table id="listTable" runat="server"></asp:table></td>
		<td id="tableAdaugaCartiIdentitate" align="center">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="tabBackground">
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" id="titluTab" align="center" colSpan="2"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">CNP:</TD>
								<TD><asp:textbox id="txtCNP" runat="server" Width="150px" MaxLength="13" CssClass="NormalEditBoxuri"></asp:textbox><span class="CommentRedBold">*</span>
									<asp:requiredfieldvalidator id="requiredCNP" runat="server" ErrorMessage="Completati CNP!" ControlToValidate="txtCNP"
										CssClass="AlertRedBold"><</asp:requiredfieldvalidator><asp:customvalidator id="customCNP" runat="server" CssClass="AlertRedBold" ErrorMessage="CNP nu e valid!"
										ControlToValidate="txtCNP" ClientValidationFunction="CheckCNP"><    </asp:customvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="4"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<td class="NormalGreenBold">CNP anterior:</td>
								<TD><asp:textbox id="txtCNPAnterior" runat="server" Width="150px" MaxLength="13" CssClass="NormalEditBoxuri"></asp:textbox><SPAN class="CommentRedBold">*
									</SPAN>
									<asp:requiredfieldvalidator id="requiredCNPAnterior" runat="server" ErrorMessage="Completati CNP anterior!"
										ControlToValidate="txtCNPAnterior" CssClass="AlertRedBold"><</asp:requiredfieldvalidator><asp:customvalidator id="Customvalidator1" runat="server" CssClass="AlertRedBold" ErrorMessage="CNP anterior nu e valid!"
										ControlToValidate="txtCNPAnterior" ClientValidationFunction="CheckCNP"><    </asp:customvalidator></TD>
							</tr>
							<!-- locul anterior -->
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Serie:</TD>
								<td><asp:textbox id="txtCISerie" runat="server" Width="150px" MaxLength="2" CssClass="NormalEditBoxuri"></asp:textbox><SPAN class="CommentRedBold">*
										<asp:requiredfieldvalidator id="requiredSerie" runat="server" ErrorMessage="Completati seria!" ControlToValidate="txtCISerie"
											CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
										<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" CssClass="AlertRedBold" ErrorMessage="Serie CI - litere!"
											ControlToValidate="txtCISerie" ValidationExpression="[a-zA-Z]*"><  </asp:regularexpressionvalidator></SPAN></td>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Numar:</TD>
								<TD><asp:textbox id="txtCINumar" runat="server" Width="150px" MaxLength="8" CssClass="NormalEditBoxuri"></asp:textbox><SPAN class="CommentRedBold">*
										<asp:requiredfieldvalidator id="requiredNumar" runat="server" ErrorMessage="Completati numarul!" ControlToValidate="txtCINumar"
											CssClass="AlertRedBold"><</asp:requiredfieldvalidator></SPAN><asp:regularexpressionvalidator id="regularCINumar" runat="server" CssClass="AlertRedBold" ErrorMessage="Numar CI - numeric!"
										ControlToValidate="txtCINumar" ValidationExpression="\d*"><  </asp:regularexpressionvalidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Eliberat de:</TD>
								<TD><asp:textbox id="txtCIEliberatDe" runat="server" Width="150px" MaxLength="50" CssClass="NormalEditBoxuri"></asp:textbox><SPAN class="CommentRedBold">*
										<asp:requiredfieldvalidator id="requiredEliberatDe" runat="server" ErrorMessage="Completati datele de eliberare!"
											ControlToValidate="txtCIEliberatDe" CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
										<asp:RegularExpressionValidator id="vldRegExprDescriere" runat="server" ErrorMessage="Eliberat de nu poate contine caractere invalide: : <>()';&quot;\"
											ControlToValidate="txtCIEliberatDe" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$" CssClass="AlertRedBold"><</asp:RegularExpressionValidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Data eliberarii:</TD>
								<TD><asp:textbox id="txtCIDataEliberarii" style="CURSOR: hand" onclick="ShowCalendar(this,'')" runat="server"
										Width="150px" CssClass="NormalEditBoxuri"></asp:textbox><SPAN class="CommentRedBold">*
										<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="Completati data eliberarii!"
											ControlToValidate="txtCIDataEliberarii" CssClass="AlertRedBold"><</asp:requiredfieldvalidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Valabil pana la:</TD>
								<TD><asp:textbox id="txtCIValabilPanaLa" style="CURSOR: hand" onclick="ShowCalendar(this,'')" runat="server"
										Width="150px" CssClass="NormalEditBoxuri"></asp:textbox><SPAN class="CommentRedBold">*
										<asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ErrorMessage="Completati data valabilitatii!"
											ControlToValidate="txtCIValabilPanaLa" CssClass="AlertRedBold"><</asp:requiredfieldvalidator></SPAN></TD>
							</TR>
							<tr id="trActivSeparator" runat="server">
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr id="trActiv" runat="server">
								<TD class="NormalGreenBold">Activ:</TD>
								<TD class="NormalGreenBold"><input id="chkActiv" type="checkbox" name="chkActiv" runat="server" style="PADDING-LEFT: 0px; MARGIN-LEFT: 0px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none"
										size="20"></TD>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr id="add_line">
					<td align="center" height="100%"><asp:button id="btnAdaugaDepartament" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Salveaza date  "></asp:button></td>
				</tr>
				<tr id="edit_line" style="DISPLAY: none">
					<td align="center" height="100%"><asp:button id="btnModificaDate" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Modifica date  "></asp:button>&nbsp;
						<asp:button id="btnStergeDate" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Sterge date  " CausesValidation="false"></asp:button>&nbsp;
						<input class="ButtonStyle" id="btnInapoi" onmouseover="MouseOverButton(this)" onclick="BackToList()"
							onmouseout="MouseOutButton(this)" type="button" value="  Inapoi  ">
					</td>
				</tr>
				<tr>
					<td align="center"><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="AlertRedBold" ShowMessageBox="True"
							ShowSummary="False"></asp:validationsummary></td>
				</tr>
			</TABLE>
		</td>
	</tr>
</table>
<input id="txtCarteIdentitateIDHidden" runat="server" type="hidden" name="txtCarteIdentitateIDHidden">
<script>
	
	sp3FormIDfix();
	eval(ctrlID + "_tab1.click()");
</script>
