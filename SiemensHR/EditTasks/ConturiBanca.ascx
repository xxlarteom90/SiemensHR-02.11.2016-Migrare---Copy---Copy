<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ConturiBanca.ascx.cs" Inherits="SiemensHR.EditTasks.ConturiBanca" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
var arTabs = new Array('tableListConturi', 'tableAdaugaCont');

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
		
		editButtonsLine.style.display = "none";
		addButtonsLine.style.display = "";
		tdTextLine.innerText = "Adauga cont";
		eval(ctrlID + "_Form1." + ctrlID + "_txtNumarCont.value = '';");
		eval(ctrlID + "_trActiv.style.display ='';");					   		
		eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked =true;");		
	}
	
	function SelectCont( activ,contID, bancaID, nrCont, moneda)
	{
		tableListConturi.style.display = "none";
		editButtonsLine.style.display = "";
		addButtonsLine.style.display = "none";
		tableAdaugaCont.style.display = "";
				
		eval(ctrlID + "_Form1." + ctrlID + "_lstBanca.value = bancaID;");
		eval(ctrlID + "_Form1." + ctrlID + "_txtNumarCont.value = nrCont;");
		eval(ctrlID + "_Form1." + ctrlID + "_lstMoneda.value = moneda;");		
		eval(ctrlID + "_Form1.txtContID.value = contID;");
		
		if (activ=='False')
		{
		    eval(ctrlID + "_trActiv.style.display ='';");					    
		    eval(ctrlID + "_Form1." + ctrlID + "_btnStergeDate.style.display = '';");		
			eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked =false;");			
		}
		else
		{
			eval(ctrlID + "_trActiv.style.display ='none';");					   
		    eval(ctrlID + "_Form1." + ctrlID + "_btnStergeDate.style.display = 'none';");		
		    eval(ctrlID + "_Form1."+ ctrlID + "_chkActiv.checked =true;");			
		}
		tdTextLine.innerText = "Editeaza cont";
		
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

//Deschide o fereastra noua in care se va incarca fereastra de admin pt invaliditati, titluri, studii sau categorii
function OpenAdminWindow( typeOfAdminPage)
{
	
	switch (typeOfAdminPage)
	{
		case "banci":
			h = Calculate_y_coordinate( 300);
			w = Calculate_x_coordinate( 600);
			oNewWindow = window.open("Administrare/AdminBanciConturiBanca.aspx",null,"height=300,width=600, top=" + h + ",left=" + w + " ,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes");
			oNewWindow.focus();
			break;
		default:
			break;
	}
}

//Sterge toate intrarile din combo-ul cu functii
function DeleteBanciCombo()
{
	var banciCombo = document.getElementById( ctrlID + '_lstBanca' ); 
	while( banciCombo.length > 0 )
	{
		banciCombo.remove( banciCombo.selectedIndex );
	}
}

//Adauga o intrare la la combo-ul cu functii
function FillBancaCombo( bancaText, bancaValoare)
{
	var banciCombo = document.getElementById( ctrlID + '_lstBanca' );
	var o = new Option();
	o.text = bancaText;
	o.value = bancaValoare;
	banciCombo.add( o, 0 ); 
}	

</script>
<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
	<tr>
		<td colSpan="3"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td colSpan="2"><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td colSpan="2"><asp:table id="tableTabs" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td id="tableListConturi" vAlign="top" align="center" colSpan="2" height="100%"><asp:table id="listTable" runat="server"></asp:table></td>
		<td id="tableAdaugaCont" align="center" colSpan="2">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="tabBackground">
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" id="tdTextLine" align="center" colSpan="2">Adaugati 
									cont:</td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Banca:<input id="txtContID" type="hidden" value="0" name="txtContID"></TD>
								<TD class="NormalGreenBold"><asp:dropdownlist id="lstBanca" runat="server" CssClass="SelectStyle" Width="260px"></asp:dropdownlist><INPUT onclick="javascript:OpenAdminWindow('banci')" type="button" value="...">
								</TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Numar cont:</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNumarCont" runat="server" CssClass="NormalEditBoxuri" size="30"></asp:textbox><asp:requiredfieldvalidator id="requiredDataStart" runat="server" ControlToValidate="txtNumarCont" ErrorMessage="Completati numarul contului!"
										CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
									<asp:RegularExpressionValidator id="regularDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Numarul de cont nu poate sa contina caractere invalide: <>()';&quot;\ "
										ControlToValidate="txtNumarCont" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:RegularExpressionValidator></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Moneda:</TD>
								<TD class="NormalGreenBold"><asp:dropdownlist id="lstMoneda" runat="server" CssClass="SelectStyle" Width="100px">
										<asp:ListItem Value="EUR">EURO</asp:ListItem>
										<asp:ListItem Value="ROL">LEI</asp:ListItem>
										<asp:ListItem Value="USD">USD</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<tr id="trActiv" runat="server">
								<TD class="NormalGreenBold">Activ:</TD>
								<TD class="NormalGreenBold"><input id="chkActiv" type="checkbox" runat="server"></TD>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr id="addButtonsLine">
					<td align="center" height="100%"><asp:button id="btnAdaugaDepartament" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Salveaza cont   "></asp:button></td>
				<tr id="editButtonsLine">
					<td align="center" height="100%"><asp:button id="btnModificaDate" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Modifica cont  "></asp:button>&nbsp;
						<asp:button id="btnStergeDate" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="  Sterge cont  " CausesValidation="false"></asp:button>&nbsp;
						<input class="ButtonStyle" id="btnInapoi" onmouseover="MouseOverButton(this)" onclick="tableAdaugaCont.style.display='none';tableListConturi.style.display=''"
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
<script>
	sp3FormIDfix();
	eval(ctrlID + "_tab1.click()");
</script>
