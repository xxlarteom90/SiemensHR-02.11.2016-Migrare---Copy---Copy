<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ImportPontaj.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.ImportPontaj" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="javascript" src="../js/jsCode.js"></script>
<script>
var arTabs = new Array('tablePontaj','tableSituatie');
	function SelectTab(index)
	{
		for(i=0; i<arTabs.length; i++)
		{
			if (i==index)
			{
				document.getElementById(lblMsg).innerText = '';
				document.getElementById(lblMsgImport).innerText = '';
				eval(ctrlID + "_tab"+ (i+1)+ ".className='tabActive'");
	            document.getElementById(fileImport).value = '';
				eval("Form1." + ctrlID + "_fileImportFisier.value = '';");
				if (arTabs[i] == 'tablePontaj')
				{
					eval("Form1." + ctrlID + "_ButtonImport.value = 'Import pontaj';");
					tdTitlu.innerHTML = 'Import pontaj';
					importButton = 'Import pontaj';
					document.getElementById(lblAtentieClient).innerHTML = 'Atentie! Angajatii vor fi identificati prin intermediul marcii. <br> Se vor lua in considerare doar intervalele din luna activa.';
					document.getElementById(tdTemp).innerHTML = "<a target=_blank href='Templates\\TemplatePontaj.xls'>template pontaj</a>";
				    document.getElementById(tdRez).innerHTML = "<a target=_blank href='Templates\\RezultateImport.txt'>Rezultate import</a>";

				}	
				else
				{
					eval("Form1." + ctrlID + "_ButtonImport.value = 'Import situatie lunara';");
					tdTitlu.innerHTML = 'Import situatie lunara';
					document.getElementById(lblAtentieClient).innerHTML = 'Atentie! Angajatii vor fi identificati prin intermediul marcii. <br> Situatia lunara este valabila pentru luna activa. <br> Daca exista deja retineri pe o anumita perioada atasate, acestea nu se vor modifica.';
					document.getElementById(tdTemp).innerHTML = "<a target=_blank href='Templates\\TemplateSituatieLunara.xls'>template situatie lunara</a>";
					document.getElementById(tdRez).innerHTML = "<a target=_blank href='Templates\\RezultateImport.txt'>Rezultate import</a>";
				} 
			}
			else
			{
				eval(ctrlID + "_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID + "_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
			}
		}
		document.getElementById(reqImport).innerText = '';
	}
	
	function SelectTabInitial(index)
	{
		for(i=0; i<arTabs.length; i++)
		{
			if (i==index)
			{
				eval(ctrlID + "_tab"+ (i+1)+ ".className='tabActive'");
				eval("Form1." + ctrlID + "_fileImportFisier.value = '';");
				if (arTabs[i] == 'tablePontaj')
				{
					eval("Form1." + ctrlID + "_ButtonImport.value = 'Import pontaj';");
					tdTitlu.innerHTML = 'Import pontaj';
					importButton = 'Import pontaj';
					document.getElementById(lblAtentieClient).innerHTML = 'Atentie! Angajatii vor fi identificati prin intermediul marcii. <br> Se vor lua in considerare doar intervalele din luna activa.';
					document.getElementById(tdTemp).innerHTML = "<a target=_blank href='Templates\\TemplatePontaj.xls'>template pontaj</a>";
					document.getElementById(tdRez).innerHTML = "<a target=_blank href='Templates\\RezultateImport.txt'>Rezultate import</a>";
				}	
				else
				{
					eval("Form1." + ctrlID + "_ButtonImport.value = 'Import situatie lunara';");
					tdTitlu.innerHTML = 'Import situatie lunara';
					importButton = 'Import situatie lunara';
					document.getElementById(lblAtentieClient).innerHTML = 'Atentie! Angajatii vor fi identificati prin intermediul marcii. <br> Situatia lunara este valabila pentru luna activa. <br> Daca exista deja retineri pe o anumita perioada atasate, acestea nu se vor modifica.';
					document.getElementById(tdTemp).innerHTML = "<a target=_blank href='Templates\\TemplateSituatieLunara.xls'>template situatie lunara</a>";
					document.getElementById(tdRez).innerHTML = "<a target=_blank href='Templates\\RezultateImport.txt'>Rezultate import</a>";
				} 
			}
			else
			{
				eval(ctrlID + "_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID + "_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
			}
		}
		document.getElementById(reqImport).innerText = '';
	}
	
function ImportClick()
{
	if (eval("Form1." + ctrlID + "_ButtonImport.value") == 'Import pontaj')
	{
		ImportPontajClick();
	}
	else
		ImportSituatieClick();
}

</script>
<table cellSpacing="0" cellPadding="0" width="542" align="center" border="0">
	<tr>
		<td class="AlertRedBold" colSpan="3"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td style="WIDTH: 542px" colSpan="2"><IMG height="10" src="../images/1x1.gif"></td>
	</tr>
	<tr>
		<td style="WIDTH: 542px" colSpan="2"><asp:table id="tableTabs" runat="server" Width="80%"></asp:table></td>
	</tr>
	<TR>
		<TD id="tablePontaj" vAlign="top" align="center" runat="server">
			<TABLE class="tabBackground" id="Table1" height="48" cellSpacing="0" cellPadding="0" width="100%"
				align="center" border="0">
				<TR>
					<TD class="HeaderGreenBold" id="tdTitlu" align="center" colSpan="2">Import pontaj</TD>
				</TR>
				<TR>
					<TD class="GreenSeparator" colSpan="2"><IMG height="1" src="../images/1x1.gif"></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 108px" height="10"></TD>
					<TD class="NormalGreenBold" height="10"></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 108px" width="108">&nbsp;&nbsp;Fisier</TD>
					<TD class="NormalGreenBold" width="85%"><SPAN class="CommentRedBold"><INPUT class="NormalEditBoxuri" id="fileImportFisier" style="WIDTH: 360px; HEIGHT: 19px"
								type="file" size="40" name="File1" runat="server">
							<asp:requiredfieldvalidator id="reqFieldValImport" runat="server" ErrorMessage="Introduceti fisierul de import!"
								ControlToValidate="fileImportFisier"><</asp:requiredfieldvalidator></SPAN></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 108px" vAlign="middle" width="108">&nbsp; 
						Template</TD>
					<TD class="NormalGreenBold" id="tdTemplate" runat="server"></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 108px" width="108" height="10"></TD>
					<TD class="NormalGreenBold" height="10"></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 108px" width="108" height="10"></TD>
					<TD class="NormalGreenBold" height="10">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<INPUT class="ButtonStyle" id="ButtonImport" onmouseover="MouseOverButton(this)" style="WIDTH: 248px"
							onclick="ImportClick()" onmouseout="MouseOutButton(this)" type="button" value="Import pontaj" name="ButtonImport" runat="server"></TD>
				</TR>
				<TR id="Tr1" runat="server">
					<TD class="NormalGreenBold" style="WIDTH: 49px" colSpan="2">
						<P><asp:label id="lblAtentie" runat="server" Width="520px" CssClass="AlertRedBold"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 200px" colSpan="2" height="7"></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" id="tdRezultateImport" runat="server" style="WIDTH: 200px"
						colSpan="2"></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 200px" colSpan="2"><asp:label id="lblMesajImport" runat="server" Width="528px" CssClass="AlertRedBold"></asp:label></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 200px" colSpan="2"><asp:label id="lblMesaj" runat="server" Width="528px" CssClass="MenuStyle"></asp:label></TD>
				</TR>
				<TR>
					<TD class="NormalGreenBold" style="WIDTH: 200px" colSpan="2"><asp:validationsummary id="Validationsummary2" runat="server" ShowSummary="False"></asp:validationsummary></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</table>
<script>
	if (eval("Form1." + ctrlID + "_ButtonImport.value") == 'Import pontaj')
		SelectTabInitial(0);
		//eval(ctrlID + "_tab1.click()");
	else
		SelectTabInitial(1);
		//eval(ctrlID + "_tab2.click()");
</script>
