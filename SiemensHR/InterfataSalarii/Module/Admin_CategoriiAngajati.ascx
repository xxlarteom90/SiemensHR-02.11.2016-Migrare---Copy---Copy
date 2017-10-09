<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Admin_CategoriiAngajati.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Admin_CategoriiAngajati" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script>

function sp3FormIDfix()
{
	document.forms[0].id=ctrlID + "_Form1";
}
		
function SelectCategorie(
	CategorieID,
	Denumire,
	Descriere,
	DPB,
	ScutireImpozit,
	ScutireCASAngajat,
	ScutireCASAngajator,
	ScutireSomajAngajat,
	ScutireSomajAngajator,
	ScutireAsigSanAngajat,
	ScutireAsigSanAngajator,
	PrimesteDPB)
{
	eval("Form1." + ctrlID + "_txtCategorieID.value = CategorieID;");
	document.getElementById(ctrlIDtxtDPB).value = DPB;
	eval("Form1." + ctrlID + "_chkScutireImpozit.checked = "+ScutireImpozit.toLowerCase()+";");
	eval("Form1." + ctrlID + "_chkScutireCASAngajat.checked ="+ ScutireCASAngajat.toLowerCase()+";");
	eval("Form1." + ctrlID + "_chkScutireCASAngajator.checked ="+ ScutireCASAngajator.toLowerCase()+";");
	eval("Form1." + ctrlID + "_chkScutireSomajAngajat.checked = "+ScutireSomajAngajat.toLowerCase()+";");
	eval("Form1." + ctrlID + "_chkScutireSomajAngajator.checked = "+ScutireSomajAngajator.toLowerCase()+";");
	eval("Form1." + ctrlID + "_chkScutireAsigSanAngajat.checked = "+ScutireAsigSanAngajat.toLowerCase()+";");
	eval("Form1." + ctrlID + "_chkScutireAsigSanAngajator.checked ="+ ScutireAsigSanAngajator.toLowerCase()+";");
	eval("Form1." + ctrlID + "_chkPrimesteDPB.checked ="+ PrimesteDPB.toLowerCase()+";");
	PrimesteDPBChange();
	eval("Form1." + ctrlID + "_btnEdit.click();");	
}


function PrimesteDPBChange()
{
	if ( ! document.getElementById(ctrlIDchkPrimesteDPB).checked )
	{
		document.getElementById(ctrlIDDBPLine).style.display = 'none';
		document.getElementById(ctrlIDtxtDPB).value = 0;
	}
	else
	{
		document.getElementById(ctrlIDDBPLine).style.display = '';
	}
}

/*
*	Modificat:	Lungu Andreea
*	Data:		27.07.2007
*	Descriere:	Adaugarea unei noi conditii pentru a se verifica daca DPB este negativ sau nu
*/
function CheckDPB(source, arg)
{
	var numar = eval("Form1." + ctrlID + "_txtDPB.value");
	if ( (eval("Form1." + ctrlID + "_chkPrimesteDPB.checked")) && 
	     ( (eval("Form1." + ctrlID + "_txtDPB.value <= 0;")) || (numar.indexOf("-")==0) ) 
	   )
	{
		arg.IsValid = false;
	}
	else
	{
		arg.IsValid = true;
	}
}

</script>
<input id="ImpoziteAsignate" type="hidden" name="ImpoziteAsignate">
<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
	<TBODY>
		<tr>
			<td><IMG height="30" src="../images/1x1.gif"><asp:literal id="litError" runat="server"></asp:literal></td>
		</tr>
		<tr>
			<td class="tabBackground" align="center">
				<table id="list_form" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
					<tr>
						<td align="center"><asp:table id="mainTable" runat="server" Width="620px"></asp:table></td>
					</tr>
					<tr>
						<td align="center" height="50"><asp:button id="btnAdaugaCategorie" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" Visible="False" CausesValidation="False" Text="Adauga categorie" CssClass="ButtonStyle"></asp:button></td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td>
				<table id="add_form" cellSpacing="1" cellPadding="0" width="100%" border="0" runat="server">
					<tr>
						<td align="center"><asp:table id="add_header" runat="server"></asp:table></td>
					</tr>
					<tr>
						<td class="tabBackground">
							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td class="NormalGreenBold" style="HEIGHT: 27px">Denumire categorie:</td>
									<td style="HEIGHT: 27px"><asp:label id="lblDenumire" runat="server" CssClass="textStyle1"></asp:label></td>
								</tr>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold">Descriere categorie:</TD>
									<TD><asp:textbox id="txtDescriere" runat="server" Width="200px" Height="64px" TextMode="MultiLine"></asp:textbox><asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" CssClass="AlertRedBold" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"
											ControlToValidate="txtDescriere" ErrorMessage="Descrierea nu poate sa contina caractere invalide: <>()';&quot;\"><</asp:regularexpressionvalidator></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR>
									<TD class="NormalGreenBold" style="HEIGHT: 19px">Primeste DPB</TD>
									<TD style="HEIGHT: 19px"><asp:checkbox id="chkPrimesteDPB" runat="server" Checked="True"></asp:checkbox></TD>
								</TR>
								<tr>
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<TR id="DPBLine" runat="server">
									<TD class="NormalGreenBold"><STRONG>DPB</STRONG></TD>
									<TD><asp:textbox id="txtDPB" runat="server" Width="200px" CssClass="NormalEditBoxuri" MaxLength="50"
											size="50">0</asp:textbox><asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDPB"
											ErrorMessage="Completati DPB"><</asp:requiredfieldvalidator><asp:comparevalidator id="Comparevalidator5" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDPB"
											ErrorMessage="Introduceti o valoare reala!" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator><asp:customvalidator id="CustomValidator1" runat="server" CssClass="AlertRedBold" ControlToValidate="txtDPB"
											ErrorMessage="Daca se introduce DPB, valoarea trebuie sa fie pozitiva!" ClientValidationFunction="CheckDPB"><</asp:customvalidator></TD>
								</TR>
								<TR style="DISPLAY: none">
									<TD class="NormalGreenBold" style="HEIGHT: 19px">Scutire Impozit</TD>
									<TD style="HEIGHT: 19px"><asp:checkbox id="chkScutireImpozit" runat="server"></asp:checkbox></TD>
								</TR>
								<TR style="DISPLAY: none">
									<TD class="NormalGreenBold" style="HEIGHT: 19px">Scutire CAS Angajat</TD>
									<TD style="HEIGHT: 19px"><asp:checkbox id="chkScutireCASAngajat" runat="server"></asp:checkbox></TD>
								</TR>
								<TR style="DISPLAY: none">
									<TD class="NormalGreenBold" style="HEIGHT: 19px">Scutire CAS Angajator</TD>
									<TD style="HEIGHT: 19px"><asp:checkbox id="chkScutireCASAngajator" runat="server"></asp:checkbox></TD>
								</TR>
								<TR style="DISPLAY: none">
									<TD class="NormalGreenBold" style="HEIGHT: 19px">Scutire Somaj Angajat</TD>
									<TD style="HEIGHT: 19px"><asp:checkbox id="chkScutireSomajAngajat" runat="server"></asp:checkbox></TD>
								</TR>
								<TR style="DISPLAY: none">
									<TD class="NormalGreenBold" style="HEIGHT: 19px">Scutire Somaj Angajator</TD>
									<TD style="HEIGHT: 19px"><asp:checkbox id="chkScutireSomajAngajator" runat="server"></asp:checkbox></TD>
								</TR>
								<TR style="DISPLAY: none">
									<TD class="NormalGreenBold" style="HEIGHT: 19px">Scutire Asig. San. Angajat</TD>
									<TD style="HEIGHT: 19px"><asp:checkbox id="chkScutireAsigSanAngajat" runat="server"></asp:checkbox></TD>
								</TR>
								<TR style="DISPLAY: none">
									<TD class="NormalGreenBold" style="HEIGHT: 19px">Scutire Asig. San. Angajator</TD>
									<TD style="HEIGHT: 19px"><asp:checkbox id="chkScutireAsigSanAngajator" runat="server"></asp:checkbox></TD>
								</TR>
								<TR style="DISPLAY: none">
									<TD class="NormalGreenBold"></TD>
									<TD></TD>
								</TR>
								<tr style="DISPLAY: none">
									<td class="GreenSeparator" colSpan="2"><IMG height="1" src="images/1x1.gif"></td>
								</tr>
								<tr>
									<td style="PADDING-RIGHT: 2px; PADDING-LEFT: 2px; PADDING-BOTTOM: 10px; PADDING-TOP: 2px"
										align="center" colSpan="2"><asp:label id="lblError" runat="server" CssClass="AlertRedBold"></asp:label></td>
								</tr>
							</table>
						</td>
					</tr>
					<TR>
						<td class="CommentRedBold" colSpan="2">* - Campuri obligatorii<asp:textbox id="txtCategorieID" runat="server"></asp:textbox></td>
					</TR>
					<TR>
						<TD align="center" colSpan="2" height="50"><asp:button id="btnSalveaza" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" Text="  Salveaza  " CssClass="ButtonStyle"></asp:button>&nbsp;
							<asp:button id="btnSterge" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" Visible="False" CausesValidation="False" Text="  Sterge  " CssClass="ButtonStyle"></asp:button>&nbsp;
							<asp:button id="btnInapoi" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
								runat="server" CausesValidation="False" Text="  Inapoi  " CssClass="ButtonStyle"></asp:button><asp:button id="btnEdit" runat="server" CausesValidation="False" Text="Edit"></asp:button></TD>
					</TR>
					<TR>
						<TD align="center" colSpan="2"><asp:validationsummary id="ValidationSummary1" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD>
					</TR>
				</table>
			</td>
		</tr>
	</TBODY>
</table>
</TD></TR></TBODY></TABLE>
