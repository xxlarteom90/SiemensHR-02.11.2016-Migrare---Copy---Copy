<%@ Control Language="c#" AutoEventWireup="false" Codebehind="AdminUtilizatori.ascx.cs" Inherits="SiemensHR.Administrare.AdminUtilizatori" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>



<script>
function sp3FormIDfix()
{
	document.forms[0].id=ctrlID + "_Form1";
	document.getElementById(requiredUtilizatorClientID).innerText = '';
	document.getElementById(regExpUtilizatorClientID).innerText = '';
	document.getElementById(requiredParolaClientID).innerText = '';	
	document.getElementById(requiredConfirmareClientID).innerText = '';
	document.getElementById(compareValParolaConfirmareClientID).innerText = '';
}
function ShowAddUtilizator()
{
	tdTitle.innerText = "Adaugare utilizator";
	listUtilizatori_form.style.display = "none";
	editUtilizator_line.style.display = "none";	
	addUtilizator_button.style.display = "none";
	addUtilizator_form.style.display = "";
	addUtilizator_line.style.display = "";
	confirmare_line.style.display = "";
	idGrup_line.style.display = "none";
	
	eval(ctrlID + "_Form1." + ctrlID + "_txtUtilizator.value = '';");
	eval(ctrlID + "_Form1." + ctrlID + "_txtParola.value = '';");	
	eval(ctrlID + "_Form1." + ctrlID + "_txtConfirmareParola.value = '';");
	eval(ctrlID + "_Form1." + ctrlID + "_dropDownListGrupuri.selectedIndex = 0;");	
		
	document.getElementById(txtGrupIdClient).value = eval(ctrlID + "_Form1." + ctrlID + "_dropDownListGrupuri.value");	
	document.getElementById(txtUtilizatorIDClient).value = "0";	
	
}

function ShowListUtilizatori()
{
	listUtilizatori_form.style.display = "";
	editUtilizator_line.style.display = "none";
	addUtilizator_button.style.display = "";
	addUtilizator_form.style.display = "none";
	addUtilizator_line.style.display = "";
}

function SelectUtilizator( idUtilizator, grup, numeUtilizator, parolaUtilizator,idGrup)
{
	/*tdTitle.innerText = "Editare utilizator";
	listUtilizatori_form.style.display = "none";
	editUtilizator_line.style.display = "";	
	addUtilizator_form.style.display = "";
	addUtilizator_line.style.display = "none";
	addUtilizator_button.style.display = "none";
	confirmare_line.style.display = "none";
	idGrup_line.style.display = "none";
	
	eval(ctrlID + "_Form1." + ctrlID + "_txtUtilizator.value = numeUtilizator;");
	eval(ctrlID + "_Form1." + ctrlID + "_txtParola.value = parolaUtilizator;");	
	eval(ctrlID + "_Form1." + ctrlID + "_dropDownListGrupuri.value = idGrup");
	
	document.getElementById(txtUtilizatorIDClient).value = idUtilizator;	
	document.getElementById(txtGrupIdClient).value = eval(ctrlID + "_Form1." + ctrlID + "_dropDownListGrupuri.value");	
	
	*/

	eval(ctrlID + "_Form1." + ctrlID + "_txtUtilizator.value = numeUtilizator;");
	eval(ctrlID + "_Form1." + ctrlID + "_txtParola.value = parolaUtilizator;");	
	eval(ctrlID + "_Form1." + ctrlID + "_dropDownListGrupuri.value = idGrup");
	
	document.getElementById(txtUtilizatorIDClient).value = idUtilizator;	
	document.getElementById(txtGrupIdClient).value = eval(ctrlID + "_Form1." + ctrlID + "_dropDownListGrupuri.value");	
	eval(ctrlID + "_Form1." + ctrlID + "_btnDeleteUtilizator.click();");	
	
	//eval(ctrlID + "_Form1.txtUtilizatorID.value = idUtilizator.innerText = idUtilizator;");		
}

function GrupChanged(grup)
{
	document.getElementById(txtGrupIdClient).value = grup.value;
}

function CheckDeleteUtilizator( text )
{
	if (confirm(text))
		return true;
	else
		return false;
}
</script>

<form runat="server">
<TABLE class=tabBackground id=Table6 cellSpacing=0 cellPadding=0 width="100%" 
border=0>
  <TR>
    <TD><asp:literal id=litError 
      runat="server"></asp:literal></TD></TR>
  <TR id=listUtilizatori_form>
    <TD align=center><asp:table id=mainTable runat="server"></asp:table><asp:datagrid id=listDataGrid runat="server" BorderWidth="1px" CellSpacing="1" BorderColor="LightSeaGreen" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="30" Width="390px">
					<ItemStyle CssClass="UnderlineNormalBlack"></ItemStyle>
					<HeaderStyle CssClass="HeaderBlueBold"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="UtilizatorID" HeaderText="UtilizatorID"></asp:BoundColumn>
						<asp:BoundColumn DataField="NumeGrup" HeaderText="Grup"></asp:BoundColumn>
						<asp:BoundColumn DataField="Nume" HeaderText="Utilizator"></asp:BoundColumn>
						<asp:BoundColumn DataField="Parola" HeaderText="Parola"></asp:BoundColumn>
						<asp:BoundColumn DataField="GrupID" HeaderText="Grup ID"></asp:BoundColumn>
					</Columns>
					<PagerStyle Mode="NumericPages"></PagerStyle>
				</asp:datagrid></TD></TR>
  <TR id=addUtilizator_form style="DISPLAY: none">
    <TD align=center>
      <TABLE id=Table7 cellSpacing=1 cellPadding=0 border=0>
        <TR>
          <TD class=BigBlueBold id=tdTitle align=center colSpan=2 height=50 
          >Adaugare utilizator</TD></TR>
        <TR>
          <TD align=center colSpan=2><asp:table id=headerTable runat="server"></asp:table></TD></TR>
        <TR>
          <TD>
            <TABLE class=tabBackground id=Table8 cellSpacing=1 cellPadding=0 
            border=0>
              <TR>
                <TD class=NormalGreenBold>Grup:</TD>
                <TD><asp:dropdownlist id=dropDownListGrupuri runat="server" Width="304px" onChange="GrupChanged(this)"></asp:dropdownlist></TD></TR>
              <TR>
                <TD class=GreenSeparator colSpan=2><IMG height=1 src="images/1x1.gif" ></TD></TR>
              <TR>
                <TD class=NormalGreenBold>Utilizator:</TD>
                <TD><asp:textbox id=txtUtilizator runat="server" Width="300px" CssClass="NormalEditBoxuri" MaxLength="100"></asp:textbox><SPAN 
                  class=CommentRedBold>*</SPAN> <asp:requiredfieldvalidator id=requiredUtilizator runat="server" CssClass="AlertRedBold" ErrorMessage="Completati numele utilizatorului!" ControlToValidate="txtUtilizator"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id=regExpUtilizator runat="server" CssClass="AlertRedBold" ErrorMessage="Numele utilizatorului nu poate sa contina caractere invalide: <>()';&quot;\" ControlToValidate="txtUtilizator" ValidationExpression="^[^>|(|)|<|'|&quot;|;|\\]*$"><</asp:regularexpressionvalidator></TD></TR>
              <TR>
                <TD class=GreenSeparator colSpan=2><IMG height=1 src="images/1x1.gif" ></TD></TR>
              <TR>
                <TD class=NormalGreenBold>Email:</TD>
                <TD class=CommentRedBold><asp:textbox id=txtEmail runat="server" Width="300px" CssClass="NormalEditBoxuri" MaxLength="100"></asp:textbox>* 
<asp:requiredfieldvalidator id=Requiredfieldvalidator1 runat="server" CssClass="AlertRedBold" ErrorMessage="Trebuie completata adresa de email!" ControlToValidate="txtEmail"><</asp:requiredfieldvalidator><asp:regularexpressionvalidator id=regularEmail runat="server" CssClass="AlertRedBold" ErrorMessage="Adresa de email incorecta!" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"><  </asp:regularexpressionvalidator></TD></TR>
              <TR>
                <TD class=GreenSeparator colSpan=2><IMG height=1 src="images/1x1.gif" ></TD></TR>
              <TR>
                <TD class=NormalGreenBold>Parola:</TD>
                <TD><asp:textbox id=txtParola runat="server" Width="300px" CssClass="NormalEditBoxuri" TextMode="Password"></asp:textbox><SPAN 
                  class=CommentRedBold>*</SPAN> <asp:requiredfieldvalidator id=requiredParola runat="server" CssClass="AlertRedBold" ErrorMessage="Trebuie completata parola!" ControlToValidate="txtParola"><</asp:requiredfieldvalidator></TD></TR>
              <TR>
                <TD class=GreenSeparator colSpan=2><IMG height=1 src="images/1x1.gif" ></TD></TR>
              <TR id=confirmare_line>
                <TD class=NormalGreenBold>Confirmare 
                  parola:</TD>
                <TD><asp:textbox id=txtConfirmareParola runat="server" Width="300px" CssClass="NormalEditBoxuri" TextMode="Password"></asp:textbox><SPAN 
                  class=CommentRedBold>*</SPAN> <asp:requiredfieldvalidator id=requiredConfirmare runat="server" CssClass="AlertRedBold" ErrorMessage="Trebuie completata confiramrea parolei!" ControlToValidate="txtConfirmareParola"><</asp:requiredfieldvalidator><asp:comparevalidator id=compareValParolaConfirmare runat="server" CssClass="AlertRedBold" ErrorMessage="Confirmarea trebuie sa coincida cu parola!" ControlToValidate="txtConfirmareParola" ControlToCompare="txtParola"><</asp:comparevalidator></TD></TR></TABLE></TD></TR>
        <TR>
          <TD class=CommentRedBold colSpan=2>* - Campuri 
            obligatorii</TD></TR>
        <TR id=addUtilizator_line>
          <TD align=center colSpan=2 height=50><asp:button id=btnAddUtilizator onmouseover=MouseOverButton(this) onmouseout=MouseOutButton(this) runat="server" CssClass="ButtonStyle" Text="Salveaza utilizator"></asp:button>&nbsp; 
<INPUT class=ButtonStyle onmouseover=MouseOverButton(this) onclick=ShowListUtilizatori() onmouseout=MouseOutButton(this) type=button value="  Inapoi  "></TD></TR>
        <TR id=editUtilizator_line>
          <TD align=center colSpan=2 height=50>&nbsp; <asp:button id=btnDeleteUtilizator onmouseover=MouseOverButton(this) onmouseout=MouseOutButton(this) runat="server" CssClass="ButtonStyle" Text="Sterge utilizator" CausesValidation="False"></asp:button>&nbsp;<INPUT class=ButtonStyle onmouseover=MouseOverButton(this) onclick=ShowListUtilizatori() onmouseout=MouseOutButton(this) type=button value="  Inapoi  "></TD></TR>
        <TR>
          <TD align=center colSpan=2><asp:validationsummary id=vldSummary onmouseover=MouseOverButton(this) onmouseout=MouseOutButton(this) runat="server" CssClass="AlertRedBold" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary><INPUT 
            id=txtUtilizatorID type=hidden value=0 name=txtBancaID 
            runat="server"></TD></TR>
        <TR id=idGrup_line>
          <TD align=center colSpan=2><INPUT id="txtGrupID" type="hidden" name="Hidden1" runat="server">&nbsp;</TD></TR></TABLE></TD></TR>
		<TR id="addUtilizator_button" height="50">
			<TD align="center">
				<TABLE id="Table9" cellSpacing="0" cellPadding="0" border="0">
					<TR>
						<TD class="UnderlineBlackBold">Pentru adaugarea unui utilizator&nbsp;nou apasati pe 
							acest buton:
						</TD>
						<TD>&nbsp;<INPUT class="ButtonStyle" onmouseover="MouseOverButton(this)" onclick="ShowAddUtilizator()"
								onmouseout="MouseOutButton(this)" type="button" value="Utilizator nou">&nbsp;</TD>
					</TR>
				</TABLE>
			</TD>
		</TR></TABLE>&nbsp; 
</FORM>
<script>
	sp3FormIDfix();
</script>

