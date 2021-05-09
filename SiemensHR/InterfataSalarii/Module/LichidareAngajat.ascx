<%@ Control Language="c#" AutoEventWireup="false" Codebehind="LichidareAngajat.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.LichidareAngajat" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
	function SalveazaClick()
	{
		TransferDateLichidare();
		var nrArticol = document.getElementById( NrArticolMain ).value;
		if (ValidareNrArticol(nrArticol))
	    {
			document.getElementById( TipActiuneLichidare ).value = "adaugaLichidare";
			document.getElementById( FormClientID ).submit();
		}
		else
			alert("Nr. articol trebuie sa fie alfanumeric (cifre,litere) de maxim 4 caractere!");
		
	}
	
	function PreviewClick()
	{
		TransferDateLichidare();
		document.getElementById( TipActiuneLichidare ).value = "previewLichidare";
		document.getElementById( FormClientID ).submit();
	}
	
	function ValidareNrArticol(cuv)
	{
		var re = new RegExp("^[(a-zA-Z0-9)?]{0,4}$");
		if (cuv.match(re)==null)
		{
			return false;
		}
		else
		{
			return true;
		} 
	}
	
	function TransferDateLichidare()
	{
		document.getElementById( NrInregistrareMain ).value = document.getElementById( NrInregistrareClient ).value;
		document.getElementById( DataLichidareMain ).value = document.getElementById( DataLichidareClient  ).value;
		
		document.getElementById( AvansuriDecontareMain ).value = document.getElementById( AvansuriDecontareClient ).value;
		document.getElementById( AbonamenteMain ).value = document.getElementById( AbonamenteClient ).value;
		document.getElementById( TicheteMasaMain ).value = document.getElementById( TicheteMasaClient ).value;
		document.getElementById( EchipamentLucruMain ).value = document.getElementById( EchipamentLucruClient ).value;
		document.getElementById( LaptopMain ).value = document.getElementById( LaptopClient ).value;
		document.getElementById( TelServiciuMain ).value = document.getElementById( TelServiciuClient ).value;
		document.getElementById( ObiecteInventarMain ).value = document.getElementById( ObiecteInventarClient ).value;
		document.getElementById( CartiMain ).value = document.getElementById( CartiClient ).value;
		document.getElementById( CDMain ).value = document.getElementById( CDClient ).value;
		
		document.getElementById( DataInregistrareMain ).value = document.getElementById( DataInregistrareClient ).value;
		document.getElementById( NrArticolMain ).value = document.getElementById( NrArticolClient ).value;
		document.getElementById( LunaRetinereMain ).value = document.getElementById( LunaRetinereClient ).value;
	}
	
//Oprescu Claudia
function ChangeMotivDePlecare()
{
	var lstMotivDePlecareClient = document.getElementById( lstMotivDePlecare );
	document.getElementById(txtMotivDePlecareHidden).value=lstMotivDePlecareClient.options[lstMotivDePlecareClient.selectedIndex].value;
}
	
</script>
<table cellSpacing="0" cellPadding="0" width="550" border="0">
	<tr>
		<td style="WIDTH: 521px"><IMG height="30" src="../images/1x1.gif"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td style="WIDTH: 609px">
			<table id="add_form" cellSpacing="1" cellPadding="0" width="100%" border="0" runat="server">
				<tr>
					<td align="center"><asp:table id="add_header" runat="server"></asp:table></td>
				</tr>
				<tr>
					<td class="tabBackground">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD class="NormalGreenBold" style="WIDTH: 225px">Nr inregistrare :</TD>
								<TD><asp:textbox id="txtNrInregistrare" runat="server" CssClass="NumericEditBoxuri" Width="100px"
										MaxLength="10" size="15"></asp:textbox><SPAN class="CommentRedBold">*</SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<td class="NormalGreenBold" style="WIDTH: 225px">Data inregistrare :</td>
								<td><asp:textbox id="txtDataInregistrare" style="CURSOR: hand; TEXT-ALIGN: center" onclick="ShowCalendar(this,'..//')"
										runat="server" CssClass="NormalEditBoxuri" size="10" Width="100px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN><SPAN class="CommentRedBold"></SPAN></td>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<td class="NormalGreenBold" style="WIDTH: 225px">Data lichidare :</td>
								<td><asp:textbox id="txtDataLichidare" style="CURSOR: hand; TEXT-ALIGN: center" onclick="ShowCalendar(this,'..//')"
										runat="server" CssClass="NormalEditBoxuri" size="10" Width="100px"></asp:textbox><SPAN class="CommentRedBold">*</SPAN></td>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<td class="NormalGreenBold" style="WIDTH: 225px">Nr articol :</td>
								<td><asp:textbox id="txtNrArticol" runat="server" CssClass="NumericEditBoxuri" size="10" Width="100px"></asp:textbox><SPAN class="CommentRedBold"></SPAN></td>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="WIDTH: 225px">Avansuri spre decontare :</TD>
								<TD><asp:textbox id="txtAvansuriDecontare" runat="server" CssClass="NumericEditBoxuri" Width="100px"
										MaxLength="15" size="50">0</asp:textbox><SPAN class="CommentRedBold"></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="WIDTH: 225px">Abonamente :</TD>
								<TD><asp:textbox id="txtAbonamente" runat="server" CssClass="NumericEditBoxuri" Width="100px" MaxLength="15"
										size="50">0</asp:textbox><SPAN class="CommentRedBold"></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="WIDTH: 225px">Tichete de masa :</TD>
								<TD><asp:textbox id="txtTicheteMasa" runat="server" CssClass="NumericEditBoxuri" Width="100px" MaxLength="15"
										size="50">0</asp:textbox><SPAN class="CommentRedBold"></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="WIDTH: 225px">Echipament de lucru :</TD>
								<TD><asp:textbox id="txtEchipamentLucru" runat="server" CssClass="NumericEditBoxuri" Width="100px"
										MaxLength="15" size="50">0</asp:textbox><SPAN class="CommentRedBold"></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="WIDTH: 225px">Laptop :</TD>
								<TD><asp:textbox id="txtLaptop" runat="server" CssClass="NumericEditBoxuri" Width="100px" MaxLength="15"
										size="50">0</asp:textbox><SPAN class="CommentRedBold"></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="WIDTH: 225px">Telefon de serviciu :</TD>
								<TD><asp:textbox id="txtTelServiciu" runat="server" CssClass="NumericEditBoxuri" Width="100px" MaxLength="15"
										size="50">0</asp:textbox><SPAN class="CommentRedBold"></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="WIDTH: 225px">Alte obiecte de inventar :</TD>
								<TD><asp:textbox id="txtObiecteInventar" runat="server" CssClass="NumericEditBoxuri" Width="100px"
										MaxLength="15" size="50">0</asp:textbox><SPAN class="CommentRedBold"></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="WIDTH: 225px">Carti :</TD>
								<TD><asp:textbox id="txtCarti" runat="server" CssClass="NumericEditBoxuri" Width="100px" MaxLength="15"
										size="50">0</asp:textbox><SPAN class="CommentRedBold"></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold" style="WIDTH: 225px">CD-uri :</TD>
								<TD><asp:textbox id="txtCD" runat="server" CssClass="NumericEditBoxuri" Width="100px" MaxLength="15"
										size="50">0</asp:textbox><SPAN class="CommentRedBold"></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<td class="NormalGreenBold" style="WIDTH: 225px">Luna retinere :</td>
								<td><asp:textbox id="txtLunaRetinere" style="CURSOR: hand; TEXT-ALIGN: center" onclick="ShowCalendar(this,'..//')"
										runat="server" CssClass="NormalEditBoxuri" size="10" Width="100px"></asp:textbox><SPAN class="CommentRedBold"></SPAN></td>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></td>
							</tr>
							<TR>
								<td class="NormalGreenBold" style="WIDTH: 225px; HEIGHT: 13px">
									Motiv plecare&nbsp;:</td>
								<td style="HEIGHT: 13px"><SPAN class="CommentRedBold">
										<asp:dropdownlist id="lstMotivDePlecare" runat="server" Width="350px" CssClass="SelectStyle" onchange="ChangeMotivDePlecare()"></asp:dropdownlist></SPAN></td>
							</TR>
						</table>
					</td>
				</tr>
				<TR>
					<td class="CommentRedBold" colSpan="2" style="HEIGHT: 14px">* - Campuri obligatorii</td>
				</TR>
				<TR>
					<TD align="center" colSpan="2" height="50"><input class="ButtonStyle" id="btnSave" onmouseover="MouseOverButton(this)" onclick="SalveazaClick()"
							onmouseout="MouseOutButton(this)" type="button" value="  Salveaza" runat="server">&nbsp;
						<input class="ButtonStyle" id="btnPrev" onmouseover="MouseOverButton(this)" onclick="PreviewClick()"
							onmouseout="MouseOutButton(this)" type="button" value="  Preview  " runat="server">&nbsp;&nbsp;
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><INPUT class="ButtonStyle" id="btnAnuleaza1" style="VISIBILITY: hidden" onclick="history.back()"
							type="button" value="  Anuleaza  "></TD>
				</TR>
			</table>
		</td>
	</tr>
</table>
