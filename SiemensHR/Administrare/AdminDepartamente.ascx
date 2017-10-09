<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminDepartamente.ascx.cs" Inherits="SiemensHR.Administrare.AdminDepartamente" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<LINK href="../StyleHR.css" type="text/css" rel="stylesheet">
<script language="javascript" src="../js/tree.js"></script>
<script>

function sp3FormIDfix()
{
document.forms[0].id=ctrlID + "_Form1";
document.getElementById(requiredDenumire).innerText = '';
document.getElementById(regularDenumire).innerText = '';
}

function ShowAddForm()
{
	list_form.style.display = "none";
	eval(ctrlID + "_add_buttonLine.style.display = 'none'");
	eval(ctrlID + "_add_form.style.display = ''");		
	eval(ctrlID + "_Form1." + ctrlID + "_txtDenumire.value = '';");
	eval(ctrlID + "_Form1." + ctrlID + "_txtSecretariat.value = '';");
	eval(ctrlID + "_Form1." + ctrlID + "_lstCentruCost.selectedIndex = 0;");	
	
	eval(ctrlID + "_Form1." + ctrlID + "_lstDeptParinte.value = lstDeptParinteDefaultVal;");
	eval(ctrlID + "_Form1." + ctrlID + "_lstSef.value = lstSefDefaultVal;");
	eval(ctrlID + "_Form1." + ctrlID + "_lstInlocSef.value = lstInlocSefDefaultVal;");
	//eval(ctrlID + "_Form1." + ctrlID + "_lstSecretara.value = lstSecretaraDefaultVal;");
}

function ShowList()
{
	list_form.style.display = "";
	eval(ctrlID + "_add_buttonLine.style.display = ''");
	eval(ctrlID + "_add_form.style.display = 'none'");
}

function SelectLine( id )
{
	//daca dept este chiar dept firma atunci nu se incearca editarea lui
	if ( FirstDeptID != id )
	{
		eval(ctrlID + "_Form1." + ctrlID + "_txtDeptID.value = id;");
		eval(ctrlID + "_Form1." + ctrlID + "_btnEdit.click();");
	}
}

function SchimbaDeptParinte()
{
	eval( "document.getElementById( DeptParinteIDClient ).value = "+ctrlID+"_Form1."+ctrlID+"_lstDeptParinte.value;" );
	//document.write( "####"+document.getElementById( DeptParinteIDClient ).value+"%%%%" );
}

var images_path = "../images/";
</script>
<form id="Form1" name="Form1" method="post" runat="server">
	<table class="tabBackground" cellSpacing="0" cellPadding="0" width="100%" border="0" id="Table1">
		<tr>
			<td><asp:literal id="litError" runat="server"></asp:literal></td>
		</tr>
		<tr id="list_form">
			<td align="center"><asp:table id="mainTable" runat="server"></asp:table></td>
		</tr>
		<TR id="add_form" runat="server">
			<TD align="center">
				<table cellSpacing="1" cellPadding="0" border="0" id="Table2">
					<tr>
						<td class="BigBlueBold" id="tdTitle" runat="server" align="center" colSpan="2" height="50">
							Introduce&nbsp;departament nou</td>
					</tr>
					<tr>
						<td align="center" colSpan="2"><asp:table id="headerTable" runat="server"></asp:table></td>
					</tr>
					<tr>
						<td>
							<table class="tabBackground" cellSpacing="1" cellPadding="0" border="0" width="100%" id="Table3">
								<TR>
									<TD class="NormalGreenBold" style="HEIGHT: 7px">Departament parinte:
									</TD>
									<TD style="HEIGHT: 7px">
										<asp:DropDownList id="lstDeptParinte" runat="server" Width="300px" onChange="SchimbaDeptParinte();"></asp:DropDownList>
										<asp:Label ID="labelExistentaDepartamente" Runat="server" Width="300px" CssClass="NormalGreenBoldAlignRight"
											Visible="False">Nu are parinte</asp:Label>
									</TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td class="NormalGreenBold">Denumire :</td>
									<td><asp:textbox id="txtDenumire" runat="server" MaxLength="100" CssClass="NormalEditBoxuri" size="50"
											Width="300px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredDenumire" runat="server" ControlToValidate="txtDenumire" ErrorMessage="Completati denumirea departamentului !"
											CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
										<asp:regularexpressionvalidator id="regularDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Nu puteti adauga caractere invalide pentru denumire: <>()';&quot;\"
											ControlToValidate="txtDenumire" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold">Centru de cost&nbsp;:</TD>
									<TD><SPAN>
											<asp:DropDownList id="lstCentruCost" runat="server" Width="300px"></asp:DropDownList></SPAN></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold" style="HEIGHT: 16px">Sef :</TD>
									<TD style="HEIGHT: 16px">
										<asp:DropDownList id="lstSef" runat="server" Width="300px"></asp:DropDownList><SPAN class="CommentRedBold">*</SPAN></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold">Inloc. Sef :</TD>
									<TD>
										<asp:DropDownList id="lstInlocSef" runat="server" Width="300px"></asp:DropDownList></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold">Secretariat:</TD>
									<TD>
										<asp:textbox id="txtSecretariat" runat="server" Width="300px" CssClass="NormalEditBoxuri" size="50"
											MaxLength="100"></asp:textbox>
										<asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" CssClass="AlertRedBold" ErrorMessage="Nu puteti adauga caractere invalide pentru denumire: <>()';&quot;\"
											ControlToValidate="txtSecretariat" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD>
								</TR>
							</table>
							<input type="hidden" id="txtDeptID" runat="server"> <INPUT id="DeptParinteID" type="hidden" name="Hidden1" runat="server">
						</td>
					</tr>
					<TR>
						<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii</td>
					</TR>
					<tr id="td_addLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnAdd" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Salveaza Departament"></asp:button>&nbsp;
							<input class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowList()" onmouseout="MouseOutButton(this)"
								type="button" value="  Inapoi  ">
							<asp:button id="btnEdit" runat="server" Text="Edit" CausesValidation="False"></asp:button></td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:Label id="lblMessage" runat="server" CssClass="AlertRedBold"></asp:Label>&nbsp;</TD>
					</TR>
					<tr id="td_editLine" runat="server">
						<td align="center" colSpan="2" height="50"><asp:button id="btnModify" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Modifica Departament"></asp:button>&nbsp;
							<asp:button id="btnDelete" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Sterge Departament" CausesValidation="False"></asp:button>&nbsp;
							<asp:Button id="btnInapoi" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="   Inapoi   " CausesValidation="False"></asp:Button></td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:validationsummary id="ValidationSummary1" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="AlertRedBold" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary>
						</TD>
					</TR>
				</table>
			</TD>
		</TR>
		<tr id="add_buttonLine" runat="server" height="50">
			<td align="center">
				<table cellSpacing="0" cellPadding="0" border="0" id="Table4">
					<tr>
						<td colspan="2" id="TreeContainer"></td>
					</tr>
					<tr>
						<td colspan="2" height="10">&nbsp;</td>
					</tr>
					<tr>
						<td class="UnderlineBlackBold">Pentru adaugarea unui Dept nou apasati pe acest 
							buton:
						</td>
						<td align="left">&nbsp;<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowAddForm()"
								onmouseout="MouseOutButton(this)" type="button" value="Departament nou">&nbsp;</td>
					</tr>
					<tr>
						<td colspan="2" height="10">&nbsp;</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</form>
<script>
sp3FormIDfix();
</script>

