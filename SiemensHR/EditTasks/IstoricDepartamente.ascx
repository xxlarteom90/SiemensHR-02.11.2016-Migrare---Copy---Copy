<%@ Control Language="c#" AutoEventWireup="false" Codebehind="IstoricDepartamente.ascx.cs" Inherits="SiemensHR.IstoricDepartamente" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript" src="../js/jsCode.js"></script>
<script>
var arTabs = new Array('tableIstoricDepartamente', 'tableAdaugaDepartament');

	function SelectTab(index)
	{
		for(i=0; i<arTabs.length; i++)
		{
			if (i==index)
			{
				eval(arTabs[i] + ".style.display=''");
				eval(ctrlID + "_tab"+ (i+1)+ ".className='tabActive'");
					
			}
			else
			{
				eval(ctrlID + "_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID + "_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabs[i] + ".style.display='none'");
			}
		}
		eval(ctrlID + "_Form1." + ctrlID + "_txtDataStart.value = '';");
		eval(ctrlID + "_Form1.old_DataStart.value = '';");
		
		editButtonsLine.style.display = "none";
		addButtonsLine.style.display = "";
		tdTextLine.innerText = "Adauga departament";
	}
	
	function SelectDepartament( departamentID, dataStart, angajatID)
	{
		tableIstoricDepartamente.style.display = "none";
		editButtonsLine.style.display = "";
		addButtonsLine.style.display = "none";
		tableAdaugaDepartament.style.display = "";
		
		eval(ctrlID + "_Form1." + ctrlID + "_lstDepartament.value = departamentID;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtDataStart.value = dataStart;");
		eval(ctrlID + "_Form1.old_DataStart.value = dataStart;");	
		tdTextLine.innerText = "Editeaza departament";		
	}

//Calculeaza coordonata - x a coltului stanga sus a unei ferestre noi pt a fi pozitionata pe centru
function Calculate_x_coordinate( window_width)
{
	return (screen.width - window_width)/2;
}

//Calculeaza coordonata - y a coltului stanga sus a unei ferestre noi pt a fi pozitionata pe centru
function Calculate_y_coordinate( window_height)
{
	return (screen.height - window_height)/2;
}

//Deschide o fereastra noua in care se va incarca fereastra de admin pt departamente
function OpenAdminWindow( typeOfAdminPage)
{
	
	switch (typeOfAdminPage)
	{
		case "departamente":
			h = Calculate_y_coordinate( 300);
			w = Calculate_x_coordinate( 600);
			oNewWindow = window.open("Administrare/AdminDepartamenteIstoricDepartamente.aspx",null,"height=300,width=600, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		default:
			break;
	}
}

//Sterge toate intrarile din combo-ul cu departamente
function DeleteDepartamenteCombo()
{
	var departamenteCombo = document.getElementById( ctrlID + '_lstDepartament' ); 
	while( departamenteCombo.length > 0 )
	{
		departamenteCombo.remove( departamenteCombo.selectedIndex );
	}
}

//Adauga o intrare la la combo-ul cu departamente
function FillDepartamentCombo( departamentText, departamentValoare)
{
	var departamenteCombo = document.getElementById( ctrlID + '_lstDepartament' );
	var o = new Option();
	o.text = departamentText;
	o.value = departamentValoare;
	departamenteCombo.add( o, departamenteCombo.length ); 
}	

</script>
<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
	<tr>
		<td colSpan="2"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td colSpan="2"><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td colspan="2">
			<asp:Table id="tableTabs" runat="server"></asp:Table></td>
	</tr>
	<tr>
		<td id="tableIstoricDepartamente" vAlign="top" align="center" colSpan="2" height="100%"><asp:table id="listTable" runat="server"></asp:table></td>
		<td id="tableAdaugaDepartament" align="center" colSpan="2">
			<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="tabBackground">
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" id="tdTextLine" align="center" colSpan="2">Adauga 
									departament:</td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Departament:</TD>
								<TD class="NormalGreenBold">
									<asp:dropdownlist id="lstDepartament" runat="server" CssClass="SelectStyle" Width="300px"></asp:dropdownlist>
									<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Selectati departamentul!"
										ControlToValidate="lstDepartament" CssClass="AlertRedBold"><</asp:RequiredFieldValidator>
									<INPUT onclick="javascript:OpenAdminWindow('departamente')" type="button" value="..." id="Button1"
										name="Button1" runat="server">
								</TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Data inceput activitate:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtDataStart" style="CURSOR: hand; TEXT-ALIGN: center" onclick="if (TipUtilizator == 'Recrutor') { ShowCalendar(this,'../'); } else { ShowCalendar(this,''); }"
										runat="server" CssClass="NormalEditBoxuri" size="10"></asp:textbox><asp:requiredfieldvalidator id="requiredDataStart" runat="server" ControlToValidate="txtDataStart" ErrorMessage="Completati data de incepere a activitati!"
										CssClass="AlertRedBold"><</asp:requiredfieldvalidator></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="center"><input type="hidden" name="old_DataStart"></td>
				</tr>
				<tr id="addButtonsLine">
					<td align="center" height="100%"><asp:button id="btnAdauga" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Salveaza date   "></asp:button></td>
				<tr id="editButtonsLine">
					<td align="center" height="24" style="HEIGHT: 24px"><asp:button id="btnModifica" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Modifica date  "></asp:button>&nbsp;
						<asp:button id="btnSterge" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Sterge date  " CausesValidation="false"></asp:button>&nbsp;
						<input id="btnInapoi" type="button" onclick="tableAdaugaDepartament.style.display='none';tableIstoricDepartamente.style.display=''"
							onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)" class="ButtonStyle"
							value="  Inapoi  ">
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
<script>
	sp3FormIDfix();
	eval(ctrlID + "_tab1.click()");
</script>
