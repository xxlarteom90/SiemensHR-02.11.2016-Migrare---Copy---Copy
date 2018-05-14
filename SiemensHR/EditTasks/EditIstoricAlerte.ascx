<%@ Control Language="c#" AutoEventWireup="false" Codebehind="EditIstoricAlerte.ascx.cs" Inherits="SiemensHR.EditTasks.EditIstoricAlerte" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
var arTabs = new Array('tableIstoricAlerte', 'tableAdaugaAlerta');

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
			}
			else
			{
				eval(ctrlID + "_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID + "_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabs[i] + ".style.display='none'");
			}
		}
		eval( ctrlID+"_Form1."+ctrlID+"_txtDescriere.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtDataExpirare.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPerioadaCritica.value = '';" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtAlertaIDHidden.value = '';");
		eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked = false;");
		
		tdAdaugareEditare.innerHTML = "Adaugare alerta";
	}
	
	function SelectAlerta( angajatID, alertaID, descriere, dataExpirare, perioadaCritica, activ)
	{
		tableIstoricAlerte.style.display = "none";
		tableAdaugaAlerta.style.display = "";
		edit_line.style.display = "";
		add_line.style.display = "none";
		tdAdaugareEditare.innerText = "Editare alerta";
		
		eval( ctrlID+"_Form1."+ctrlID+"_txtDescriere.value = descriere;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtDataExpirare.value = dataExpirare;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtPerioadaCritica.value = perioadaCritica;" );
		eval( ctrlID+"_Form1."+ctrlID+"_txtAlertaIDHidden.value = alertaID;");

		eval(ctrlID + "_trActiv.style.display ='';");
		eval(ctrlID + "_trActivSeparator.style.display ='';");
		
		if( activ=="False" )
		{
	
			eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked =false;");
		}
		else
		{
			//eval(ctrlID + "_trActiv.style.display ='none';");
			//eval(ctrlID + "_trActivSeparator.style.display ='none';");
	
			eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked =true;");
		}
		
	}
	
	function BackToList()
	{
		tableAdaugaAlerta.style.display='none';
		tableIstoricAlerte.style.display='';
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
		<td id="tableIstoricAlerte" vAlign="top" align="center" height="100%"><asp:table id="listTable" runat="server"></asp:table></td>
		<td id="tableAdaugaAlerta" align="center">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="tabBackground">
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" align="center" colSpan="2" id="tdAdaugareEditare"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Descriere:</TD>
								<TD>
									<asp:textbox id="txtDescriere" runat="server" MaxLength="10" CssClass="NormalEditBoxuri" TextMode="MultiLine"
										Width="280px"></asp:textbox>
									<span class="CommentRedBold">*
										<asp:RequiredFieldValidator id="vldDescriere" runat="server" ErrorMessage="Trebuie sa completati descrierea alertei!"
											ControlToValidate="txtDescriere" CssClass="AlertRedBold"><</asp:RequiredFieldValidator>
										<asp:RegularExpressionValidator id="vldRegExprDescriere" runat="server" ErrorMessage="Descrierea alertei nu trebuie sa contina caracterele invalide: (, ), <, >, ' sau &quot; !"
											ControlToValidate="txtDescriere" ValidationExpression="^[^>|(|)|<|'|&quot;]*$" CssClass="AlertRedBold"><</asp:RegularExpressionValidator></span>
								</TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Data expirarii:</TD>
								<TD>
									<asp:textbox id="txtDataExpirare" style="CURSOR: hand" onclick="ShowCalendar(this,'')" runat="server"
										CssClass="NormalEditBoxuri" ReadOnly="False"></asp:textbox>
									<span class="CommentRedBold">*</span>
									<asp:RequiredFieldValidator id="vldDataExpirarii" runat="server" ErrorMessage="Trebuie sa completati data expirarii!"
										ControlToValidate="txtDataExpirare" CssClass="AlertRedBold"><</asp:RequiredFieldValidator>
								</TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<tr>
								<TD class="NormalGreenBold">Nr. zile pentru declansare alerta:</TD>
								<TD>
									<asp:textbox id="txtPerioadaCritica" runat="server" MaxLength="9" CssClass="NormalEditBoxuri"></asp:textbox>
									<span class="CommentRedBold">*</span>
									<asp:RequiredFieldValidator id="vldReqNrZileDeclansare" runat="server" ErrorMessage="Trebuie sa completati numarul de zile pentru declansarea alertei!"
										ControlToValidate="txtPerioadaCritica" CssClass="AlertRedBold"><</asp:RequiredFieldValidator>
									<asp:RangeValidator id="rangeVldNrZileDeclansare" runat="server" ErrorMessage="Trebuie sa completati corect numarul de zile pentru declansare!"
										ControlToValidate="txtPerioadaCritica" Type="Integer" MaximumValue="999999" MinimumValue="0" CssClass="AlertRedBold"><</asp:RangeValidator>
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
					<td align="center" height="100%"><asp:button id="btnAdaugaAlerta" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
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
					<td align="center"><asp:validationsummary id="ValidationSummary1" runat="server" CssClass="AlertRedBold" ShowSummary="False"
							ShowMessageBox="True"></asp:validationsummary></td>
				</tr>
			</TABLE>
		</td>
	</tr>
</table>
<input id="txtAlertaIDHidden" type="hidden" name="txtAlertaIDHidden" runat="server">
<script>
	
	sp3FormIDfix();
	eval(ctrlID + "_tab1.click()");
</script>
