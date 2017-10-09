<%@ Control Language="c#" AutoEventWireup="false" Codebehind="IstoricPasapoarte.ascx.cs" Inherits="SiemensHR.EditTasks.IstoricPasapoarte" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
var arTabs = new Array('tableIstoricPasapoarte', 'tableAdaugaPasapoarte');

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
		
		eval( ctrlID+"_Form1."+ctrlID+"_txtPASSerie.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPASNumar.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPASEliberatDe.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPASDataEliberarii.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPASValabilPanaLa.value = '';" );
		eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked = false;");
		eval( ctrlID+"_Form1."+ctrlID+"_txtPasaportIDHidden.value = '';");
		eval(ctrlID + "_trActiv.style.display ='';");
		eval(ctrlID + "_trActivSeparator.style.display ='';");
		
		tdAdaugareEditare.innerHTML = "Adaugare pasaport";
	}
	
	function SelectPasaport( angajatID, PasaportID, serie, numar, eliberatDe, dataEliberare, dataExpirare, activ )
	{
		tableIstoricPasapoarte.style.display = "none";
		tableAdaugaPasapoarte.style.display = "";
		edit_line.style.display = "";
		add_line.style.display = "none";
		tdAdaugareEditare.innerHTML = "Editare pasaport";
		
		eval( ctrlID+"_Form1."+ctrlID+"_txtPASSerie.value = serie;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPASNumar.value = numar;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPASEliberatDe.value = eliberatDe;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPASDataEliberarii.value = dataEliberare;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPASValabilPanaLa.value = dataExpirare;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPasaportIDHidden.value = PasaportID;");
		
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
		
		
		/*eval(ctrlID + "_Form1." + ctrlID + "_lstCentruCost.value = CentruCostID;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtDataStart.value = dataStart;");
		eval(ctrlID + "_Form1." + ctrlID + "_old_DataStart.value = dataStart;");		*/
		
	}
	
	function BackToList()
	{
		tableAdaugaPasapoarte.style.display='none';
		tableIstoricPasapoarte.style.display='';
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
		<td id="tableIstoricPasapoarte" vAlign="top" align="center" height="100%"><asp:table id="listTable" runat="server"></asp:table></td>
		<td id="tableAdaugaPasapoarte" align="center">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="tabBackground">
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" id="tdAdaugareEditare" align="center" colSpan="2"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Serie:</TD>
								<TD><asp:textbox id="txtPASSerie" runat="server" Width="120px" MaxLength="10" CssClass="NormalEditBoxuri"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPASSerie"
										ErrorMessage="Completati seria pasaportului!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPASSerie"
										ErrorMessage="Introduceti numai litere pentru serie!" ValidationExpression="[a-zA-Z]*">< </asp:regularexpressionvalidator></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Numar:</TD>
								<TD><asp:textbox id="txtPASNumar" runat="server" Width="120px" MaxLength="9" CssClass="NormalEditBoxuri"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPASNumar"
										ErrorMessage="Completati numarul pasaportului!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPASNumar"
										ErrorMessage="Introduceti numai cifre pentru numar!" ValidationExpression="[0-9]+"><</asp:regularexpressionvalidator></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Emis de:</TD>
								<TD><asp:textbox id="txtPASEliberatDe" runat="server" Width="120px" MaxLength="50" CssClass="NormalEditBoxuri"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPASEliberatDe"
										ErrorMessage="Completati de cine a fost eliberat!"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="vldRegExprDescriere" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPASEliberatDe"
										ErrorMessage="Eliberat de nu poate sa contina caractere invalide: <>()';&quot;\" ValidationExpression="^[^>|(|)|<|'|&quot;]*$"><</asp:regularexpressionvalidator></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Data emiterii:</TD>
								<TD><asp:textbox id="txtPASDataEliberarii" style="CURSOR: hand" onclick="ShowCalendar(this,'')" runat="server"
										Width="70px" CssClass="NormalEditBoxuri" ReadOnly="True"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPASDataEliberarii"
										ErrorMessage="Selectati data eliberarii!"><</asp:requiredfieldvalidator></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Valabil pana la:</TD>
								<TD><asp:textbox id="txtPASValabilPanaLa" style="CURSOR: hand" onclick="ShowCalendar(this,'')" runat="server"
										Width="70px" CssClass="NormalEditBoxuri" ReadOnly="True"></asp:textbox><asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" CssClass="AlertRedBold" ControlToValidate="txtPASValabilPanaLa"
										ErrorMessage="Selectati pana cand e valabil!"><</asp:requiredfieldvalidator></TD>
							</tr>
							<tr id="trActivSeparator" runat="server">
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr id="trActiv" runat="server">
								<TD class="NormalGreenBold">Activ:</TD>
								<TD class="NormalGreenBold"><input id="chkActiv" type="checkbox" name="chkActiv" runat="server"></TD>
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
					<td align="center"><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="AlertRedBold" Height="32px" ShowSummary="False"
							ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</TABLE>
		</td>
	</tr>
</table>
<input id="txtPasaportIDHidden" type="hidden" name="txtPasaportIDHidden" runat="server">
<script>
	
	sp3FormIDfix();
	eval(ctrlID + "_tab1.click()");
</script>
