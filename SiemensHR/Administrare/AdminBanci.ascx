<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminBanci.ascx.cs" Inherits="SiemensHR.Administrare.AdminBanci" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
function sp3FormIDfix()
{
document.forms[0].id=ctrlID + "_Form1";
document.getElementById(requiredDenumireClientID).innerText = '';
document.getElementById(requiredCodClientID).innerText = '';
document.getElementById(requiredFilialaClientID).innerText = '';	
document.getElementById(regExprVldDenumireClientID).innerText = '';
document.getElementById(regularCodClientID).innerText = '';
document.getElementById(regularFilialaClientID).innerText = '';
}
function ShowAddBanca()
{
	tdTitle.innerText = "Adaugare banca";
	listBanca_form.style.display = "none";
	editBanca_line.style.display = "none";	
	addBanca_button.style.display = "none";
	addBanca_form.style.display = "";
	addBanca_line.style.display = "";
	
	eval(ctrlID + "_Form1." + ctrlID + "_txtCodBanca.value = '';");
	eval(ctrlID + "_Form1." + ctrlID + "_txtDenumireBanca.value = '';");	
	eval(ctrlID + "_Form1." + ctrlID + "_txtFilialaBanca.value = '';");	
}

function ShowListBanci()
{
	listBanca_form.style.display = "";
	editBanca_line.style.display = "none";
	addBanca_button.style.display = "";
	addBanca_form.style.display = "none";
	addBanca_line.style.display = "";
}

function SelectBanca( idBanca, codBanca, denumireBanca, filialaBanca)
{
	tdTitle.innerText = "Editare banca";
	listBanca_form.style.display = "none";
	editBanca_line.style.display = "";	
	addBanca_form.style.display = "";
	addBanca_line.style.display = "none";
	addBanca_button.style.display = "none";
		
	eval(ctrlID + "_Form1." + ctrlID + "_txtCodBanca.value = codBanca;");
	eval(ctrlID + "_Form1." + ctrlID + "_txtDenumireBanca.value = denumireBanca;");	
	eval(ctrlID + "_Form1." + ctrlID + "_txtFilialaBanca.value = filialaBanca;");	
	eval(ctrlID + "_Form1.txtBancaID.value = idBanca.innerText =idBanca;");		
}

function CheckDeleteBanca( text )
{
	eval("var bancaID = " + ctrlID + "_Form1.txtBancaID.value");
	for(var i=0; i<arBanciID.length; i++)
	{	
		if (bancaID== arBanciID[i])
		{
			if (Number(arNoConturi[i])!=0)
			{
				alert("Banca nu poate fi stearsa!\nExista conturi asociate acestei banci!");
				return false;
			}
		}
	}
	if (confirm(text))
		return true;
	else
		return false;
}

</script>
<form id="Form1" name="Form1" method="post" encType="multipart/form-data" runat="server">
	<table class="tabBackground" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<tr>
			<td><asp:literal id="litError" runat="server"></asp:literal></td>
		</tr>
		<tr id="listBanca_form">
			<td align="center"><asp:table id="mainTable" runat="server"></asp:table><asp:datagrid id="listDataGrid" runat="server" PageSize="30" AllowPaging="True" AutoGenerateColumns="False"
					GridLines="None" BorderColor="LightSeaGreen" CellSpacing="1" BorderWidth="1px" Width="390px">
					<ItemStyle CssClass="UnderlineNormalBlack"></ItemStyle>
					<HeaderStyle CssClass="HeaderBlueBold"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="BancaID" HeaderText="BancaID"></asp:BoundColumn>
						<asp:BoundColumn DataField="CodBanca" HeaderText="Cod banca"></asp:BoundColumn>
						<asp:BoundColumn DataField="Nume" HeaderText="Nume"></asp:BoundColumn>
						<asp:BoundColumn DataField="Filiala" HeaderText="Filiala"></asp:BoundColumn>
					</Columns>
					<PagerStyle Mode="NumericPages"></PagerStyle>
				</asp:datagrid></td>
		</tr>
		<TR id="addBanca_form" style="DISPLAY: none">
			<TD align="center">
				<table cellSpacing="1" cellPadding="0" border="0">
					<tr>
						<td class="BigBlueBold" id="tdTitle" align="center" colSpan="2" height="50">Adaugare 
							banca</td>
					</tr>
					<tr>
						<td align="center" colSpan="2"><asp:table id="headerTable" runat="server"></asp:table></td>
					</tr>
					<tr>
						<td>
							<table class="tabBackground" cellSpacing="1" cellPadding="0" border="0">
								<tr>
									<td class="NormalGreenBold">Denumire :</td>
									<td><asp:textbox id="txtDenumireBanca" runat="server" Width="327px" CssClass="NormalEditBoxuri" MaxLength="100"
											TextMode="MultiLine"></asp:textbox><SPAN class="CommentRedBold">*
											<asp:requiredfieldvalidator id="requiredDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati denumirea bancii!"
												ControlToValidate="txtDenumireBanca"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regExprVldDenumire" runat="server" CssClass="AlertRedBold" ErrorMessage="Denumirea nu poate sa contina caractere invalide: <>()';&quot;\ "
												ControlToValidate="txtDenumireBanca" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></SPAN></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td class="NormalGreenBold">Cod :</td>
									<td><asp:textbox id="txtCodBanca" runat="server" CssClass="NormalEditBoxuri" MaxLength="50"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredCod" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati codul bancii!"
											ControlToValidate="txtCodBanca"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularCod" runat="server" CssClass="AlertRedBold" ErrorMessage="Codul nu poate sa contina caractere invalide: <>()';&quot;\ "
											ControlToValidate="txtCodBanca" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td class="NormalGreenBold">Filiala :</td>
									<td><asp:textbox id="txtFilialaBanca" runat="server" CssClass="NormalEditBoxuri" MaxLength="100"></asp:textbox><SPAN class="CommentRedBold">*</SPAN>
										<asp:requiredfieldvalidator id="requiredFiliala" runat="server" CssClass="AlertRedBold" ErrorMessage="Completati filiala bancii!"
											ControlToValidate="txtFilialaBanca"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id="regularFiliala" runat="server" CssClass="AlertRedBold" ErrorMessage="Filiala nu poate sa contina caractere invalide: <>()';&quot;\ "
											ControlToValidate="txtFilialaBanca" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></td>
								</tr>
							</table>
						</td>
					</tr>
					<TR>
						<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii</td>
					</TR>
					<tr id="addBanca_line">
						<td align="center" colSpan="2" height="50"><asp:button id="btnAddBanca" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Salveaza banca"></asp:button>&nbsp;
							<input class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowListBanci()"
								onmouseout="MouseOutButton(this)" type="button" value="  Inapoi  "></td>
					</tr>
					<tr id="editBanca_line">
						<td align="center" colSpan="2" height="50"><asp:button id="btnModifyBanca" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Modifica banca"></asp:button>&nbsp;
							<asp:button id="btnDeleteBanca" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="ButtonStyle" Text="Sterge banca" CausesValidation="False"></asp:button>&nbsp;<input class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowListBanci()"
								onmouseout="MouseOutButton(this)" type="button" value="  Inapoi  "></td>
					</tr>
					<TR>
						<TD align="center" colSpan="2"><asp:validationsummary id="vldSummary" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CssClass="AlertRedBold" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary><input id="txtBancaID" type="hidden" value="0" name="txtBancaID"></TD>
					</TR>
				</table>
			</TD>
		</TR>
		<tr id="addBanca_button" height="50">
			<td align="center">
				<table cellSpacing="0" cellPadding="0" border="0">
					<tr>
						<td class="UnderlineBlackBold">Pentru adaugarea unei banci noi apasati pe acest 
							buton:
						</td>
						<td>&nbsp;<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowAddBanca()"
								onmouseout="MouseOutButton(this)" type="button" value="Banca noua">&nbsp;</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</form>
<script>
sp3FormIDfix();
</script>
