<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Admin_InflatieLunara.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.Admin_InflatieLunara" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
var arTabs = new Array('tableListInflatie', 'tableAdaugaInflatie');

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
				eval(arTabs[i] + ".style.display='none'");
				eval(ctrlID + "_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
		
			}
		}
		addButtonsLine.style.display = "";
		addButtonsLine.style.display = "";
	}
	
	function SelectInflatie(Denumire,ProcentInflatie)
	{	
		tableListInflatie.style.display = "none";
		editButtonsLine.style.display = "";
		addButtonsLine.style.display = "none";
		tableAdaugaInflatie.style.display = "";
											
		tdTextLine.innerText = "Editeaza inflatie:";
		
	}
	
</script>
<table cellSpacing="0" cellPadding="0" width="600" align="center" border="0">
	<tr>
		<td style="HEIGHT: 35px" colSpan="3"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td class="NormalBlueBold" colSpan="2"><IMG height="10" src="../images/1x1.gif">&nbsp; 
			Selectati anul :
			<asp:dropdownlist id="drpAni" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
	</tr>
	<tr>
		<td height="4"></td>
	</tr>
	<tr>
		<td colSpan="2"><asp:table id="tableTabs" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td id="tableListInflatie" style="HEIGHT: 219px" vAlign="top" align="center" colSpan="2"
			height="219"><asp:table id="listTable" runat="server"></asp:table></td>
		<td id="tableAdaugaInflatie" style="HEIGHT: 219px" vAlign="top" align="center" colSpan="2">
			<TABLE height="200" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td class="tabBackground">
						<TABLE height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center" border="0">
							<tr>
								<td class="HeaderGreenBold" id="tdTextLine" align="center" colSpan="2">Modificare 
									procent inflatie pentru luna curenta
								</td>
							</tr>
							<tr id="trActiv" runat="server">
								<TD class="NormalGreenBold">Procent:
								</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtProcentInflatie" runat="server" CssClass="NormalEditBoxuri" MaxLength="6"></asp:textbox><asp:label id="lblCmpObli" runat="server" ForeColor="Red" Font-Size="Smaller">*</asp:label><asp:requiredfieldvalidator id="vldCmpOblProc" runat="server" ControlToValidate="txtProcentInflatie" ErrorMessage="Trebuie sa completati valoarea procentului de inflatie!"
										CssClass="AlertRedBold"><</asp:requiredfieldvalidator>
									<asp:rangevalidator id="vldProc" runat="server" Font-Size="Smaller" ControlToValidate="txtProcentInflatie"
										ErrorMessage="Trebuie sa completati corect valoarea procentului de inflatie!" Type="Double" MinimumValue="1"
										MaximumValue="100" CssClass="AlertRedBold"><</asp:rangevalidator><span class="CommentRedBold"></span></TD>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr id="addButtonsLine">
					<td align="center" height="100%"><asp:button id="btnAdaugaProcentInfl" onmouseover="MouseOverButton(this)" onmouseout="MouseOutButton(this)"
							runat="server" CssClass="ButtonStyle" Text="Salveaza"></asp:button></td>
				<tr>
					<td align="left">
						<P>
							<asp:label id="Label1" runat="server" Font-Size="Smaller" ForeColor="Red">Exemplu: 0,6% va fi introdus sub forma 1,006</asp:label><br>
							<asp:label id="lblCmpObl" runat="server" ForeColor="Red" Font-Size="Smaller">* - Camp obligatoriu</asp:label></P>
					</td>
				</tr>
			</TABLE>
			<asp:ValidationSummary id="vldSummary" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></td>
	</tr>
	<tr>
		<td colSpan="3"><asp:label id="lInflatieCurenta" runat="server"></asp:label></td>
	</tr>
</table>
<script>
	eval(ctrlID + "_tab1.click()");
</script>
