<%@ Control Language="c#" AutoEventWireup="false" Codebehind="IstoricPermiseMunca.ascx.cs" Inherits="SiemensHR.EditTasks.IstoricPermiseMunca" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
var arTabs = new Array('tableIstoricPermiseMunca', 'tableAdaugaPermiseMunca');

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
		
		eval( ctrlID+"_Form1."+ctrlID+"_txtSeriePermisMunca.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtNrPermisMunca.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPermisMuncaDataEliberare.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPermisMuncaDataExpirare.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPermisMuncaIDHidden.value = '';");
		eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked = false;");
		eval(ctrlID + "_trActiv.style.display ='';");
		eval(ctrlID + "_trActivSeparator.style.display ='';");
		
		tdAdaugareEditare.innerHTML = "Adaugare permis de munca";
	}
	
	function SelectPermisMunca( angajatID, PermisMuncaID, serie, numar, dataEliberare, dataExpirare, activ)
	{
		tableIstoricPermiseMunca.style.display = "none";
		tableAdaugaPermiseMunca.style.display = "";
		edit_line.style.display = "";
		add_line.style.display = "none";
		tdAdaugareEditare.innerHTML = "Editare permis de munca";
		
		eval( ctrlID+"_Form1."+ctrlID+"_txtSeriePermisMunca.value = serie;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtNrPermisMunca.value = numar;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPermisMuncaDataEliberare.value = dataEliberare;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPermisMuncaDataExpirare.value = dataExpirare;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPermisMuncaIDHidden.value = PermisMuncaID;");
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
		tableAdaugaPermiseMunca.style.display='none';
		tableIstoricPermiseMunca.style.display='';
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
		<td id="tableIstoricPermiseMunca" vAlign="top" align="center" height="100%"><asp:table id="listTable" runat="server"></asp:table></td>
		<td id="tableAdaugaPermiseMunca" align="center">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="tabBackground">
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" align="center" colSpan="2" id="tdAdaugareEditare"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold" width="30%">Serie:</TD>
								<TD><asp:textbox id="txtSeriePermisMunca" runat="server" CssClass="NormalEditBoxuri" Width="120px"
										MaxLength="10"></asp:textbox><span class="CommentRedBold">*</span>
									<asp:RequiredFieldValidator id="requiredSerie" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati seria!"
										ControlToValidate="txtSeriePermisMunca"><</asp:RequiredFieldValidator>
									<asp:regularexpressionvalidator id="Regularexpressionvalidator2" runat="server" CssClass="AlertRedBold" ControlToValidate="txtSeriePermisMunca"
										ErrorMessage="Introduceti numai litere!" ValidationExpression="[a-zA-Z]*">< </asp:regularexpressionvalidator>
								</TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Numar:</TD>
								<TD><asp:textbox id="txtNrPermisMunca" runat="server" CssClass="NormalEditBoxuri" Width="120px" MaxLength="10"></asp:textbox><span class="CommentRedBold">*</span>
									<asp:RequiredFieldValidator id="requiredNumar" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati numarul!"
										ControlToValidate="txtNrPermisMunca"><</asp:RequiredFieldValidator>
									<asp:comparevalidator id="vldNumar" runat="server" CssClass="AlertRedBold" ErrorMessage="Introduceti o valoare numerica pozitiva!"
										ControlToValidate="txtNrPermisMunca" Operator="GreaterThan" Type="Integer" ValueToCompare="0"><</asp:comparevalidator>
								</TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Data eliberarii:</TD>
								<TD><asp:textbox id="txtPermisMuncaDataEliberare" style="CURSOR: hand" onclick="ShowCalendar(this,'')"
										runat="server" CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox><span class="CommentRedBold">*</span>
									<asp:RequiredFieldValidator id="requiredDataEliberarii" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati data eliberarii!"
										ControlToValidate="txtPermisMuncaDataEliberare"><</asp:RequiredFieldValidator>
								</TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Valabil pana la:</TD>
								<TD><asp:textbox id="txtPermisMuncaDataExpirare" style="CURSOR: hand" onclick="ShowCalendar(this,'')"
										runat="server" CssClass="NormalEditBoxuri" Width="70px" ReadOnly="True"></asp:textbox><span class="CommentRedBold">*</span>
									<asp:RequiredFieldValidator id="requiredDataExpirare" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati data de expirare!"
										ControlToValidate="txtPermisMuncaDataExpirare"><</asp:RequiredFieldValidator>
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
<input id="txtPermisMuncaIDHidden" runat="server" type="hidden" name="txtPermisMuncaIDHidden">
<script>
	
	sp3FormIDfix();
	eval(ctrlID + "_tab1.click()");
</script>
