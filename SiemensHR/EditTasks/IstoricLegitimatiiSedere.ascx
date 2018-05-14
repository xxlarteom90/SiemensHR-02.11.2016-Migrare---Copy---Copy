<%@ Control Language="c#" AutoEventWireup="false" Codebehind="IstoricLegitimatiiSedere.ascx.cs" Inherits="SiemensHR.EditTasks.IstoricLegitimatiiSedere" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
var arTabs = new Array('tableIstoricLegitimatiiSedere', 'tableAdaugaLegitimatiiSedere');

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
		
		eval( ctrlID+"_Form1."+ctrlID+"_txtSerieLegitimatieSedere.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtNrLegitimatieSedere.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtLegitimatieSedereDataEliberare.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtLegitimatieSedereDataExpirare.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtLegitimatieSedereIDHidden.value = '';");
		eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked = false;");
		eval(ctrlID + "_trActiv.style.display ='';");
		eval(ctrlID + "_trActivSeparator.style.display ='';");
		
		tdAdaugareEditare.innerHTML = "Adaugare legitimatia de sedere";
	}
	
	function SelectLegitimatieSedere( angajatID, LegitimatieSedereID, serie, numar, dataEliberare, dataExpirare, activ)
	{
		tableIstoricLegitimatiiSedere.style.display = "none";
		tableAdaugaLegitimatiiSedere.style.display = "";
		edit_line.style.display = "";
		add_line.style.display = "none";
		tdAdaugareEditare.innerText = "Editare legitimatia de sedere";
		
		eval( ctrlID+"_Form1."+ctrlID+"_txtSerieLegitimatieSedere.value = serie;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtNrLegitimatieSedere.value = numar;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtLegitimatieSedereDataEliberare.value = dataEliberare;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtLegitimatieSedereDataExpirare.value = dataExpirare;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtLegitimatieSedereIDHidden.value = LegitimatieSedereID;");
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
		tableAdaugaLegitimatiiSedere.style.display='none';
		tableIstoricLegitimatiiSedere.style.display='';
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
		<td id="tableIstoricLegitimatiiSedere" vAlign="top" align="center" height="100%"><asp:table id="listTable" runat="server"></asp:table></td>
		<td id="tableAdaugaLegitimatiiSedere" align="center">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="tabBackground">
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" align="center" colSpan="2" id="tdAdaugareEditare"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold" width="30%">Serie:</TD>
								<TD><asp:textbox id="txtSerieLegitimatieSedere" runat="server" CssClass="NormalEditBoxuri" Width="120px"
										MaxLength="10"></asp:textbox><span class="CommentRedBold">*</span>
									<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSerieLegitimatieSedere"
										ErrorMessage="Introduceti numai litere!" ValidationExpression="[a-zA-Z]*"><</asp:regularexpressionvalidator>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Completati seria legitimatiei de sedere!"
										ControlToValidate="txtSerieLegitimatieSedere" CssClass="AlertRedBold"><</asp:RequiredFieldValidator>
								</TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Numar:</TD>
								<TD><asp:textbox id="txtNrLegitimatieSedere" runat="server" CssClass="NormalEditBoxuri" Width="120px"
										MaxLength="10"></asp:textbox><span class="CommentRedBold">*</span>
									<asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ErrorMessage="Introduceti numai cifre!"
										ControlToValidate="txtNrLegitimatieSedere" ValidationExpression="[0-9]+" CssClass="AlertRedBold"><</asp:RegularExpressionValidator>
									<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Completati numarul legitimatiei de sedere!"
										ControlToValidate="txtNrLegitimatieSedere" CssClass="AlertRedBold"><</asp:RequiredFieldValidator>
								</TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Data eliberarii:</TD>
								<TD><asp:textbox id="txtLegitimatieSedereDataEliberare" style="CURSOR: hand" onclick="ShowCalendar(this,'')"
										runat="server" CssClass="NormalEditBoxuri" Width="70px" ReadOnly="False"></asp:textbox><span class="CommentRedBold">*</span>
									<asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Selectati data eliberarii!"
										ControlToValidate="txtLegitimatieSedereDataEliberare" CssClass="AlertRedBold"><</asp:RequiredFieldValidator>
								</TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Valabil pana la:</TD>
								<TD><asp:textbox id="txtLegitimatieSedereDataExpirare" style="CURSOR: hand" onclick="ShowCalendar(this,'')"
										runat="server" CssClass="NormalEditBoxuri" Width="70px" ReadOnly="False"></asp:textbox><span class="CommentRedBold">*</span>
									<asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="Selectati pana cand e valabil!"
										ControlToValidate="txtLegitimatieSedereDataExpirare" CssClass="AlertRedBold"><</asp:RequiredFieldValidator>
								</TD>
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
					<td align="center"><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="AlertRedBold" ShowMessageBox="True"
							ShowSummary="False"></asp:validationsummary></td>
				</tr>
			</TABLE>
		</td>
	</tr>
</table>
<input id="txtLegitimatieSedereIDHidden" runat="server" type="hidden" name="txtLegitimatieSedereIDHidden">
<script>
	
	sp3FormIDfix();
	eval(ctrlID + "_tab1.click()");
</script>
