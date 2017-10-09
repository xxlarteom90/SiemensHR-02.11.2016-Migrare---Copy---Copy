<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ManagersOptions_Checkup.ascx.cs" Inherits="SiemensHR.ManagersOptions_Checkup" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<form id="Form1" name="Form1" method="post" runat="server">
	<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
			<TD class="GreenSeparator" colSpan="3" height="1"><IMG height="1" src="images/1x1.gif"></TD>
		</TR>
		<tr style="FONT-WEIGHT: bold; TEXT-TRANSFORM: none; COLOR: #20b2aa; FONT-FAMILY: Arial">
			<td align="center" colspan="3" height="35">
				Check-up-uri din departamentul&nbsp;
				<asp:Label id="numeDept" runat="server"></asp:Label>
			</td>
		</tr>
		<TR>
			<TD class="GreenSeparator" colSpan="3" height="1"><IMG height="1" src="images/1x1.gif"></TD>
		</TR>
		<TR class="NormalGreenBold">
			<TD style="HEIGHT: 36px" align="left">
				<DIV id="DataStart" style="DISPLAY: inline; WIDTH: 192px; HEIGHT: 22px" ms_positioning="FlowLayout">Data 
					de inceput a perioadei&nbsp;&nbsp;</DIV>
				<asp:textbox id="txtDataStart" style="CURSOR: hand" onclick="ShowCalendar(this,'../')" runat="server"
					MaxLength="10" Height="20px" ReadOnly="True" Width="100px" CssClass="NormalEditBoxuri"></asp:textbox></TD>
			<TD style="HEIGHT: 36px" align="left">
				<DIV id="DataStop" style="DISPLAY: inline; WIDTH: 177px; HEIGHT: 22px" align="left" ms_positioning="FlowLayout">Data 
					de sfarsit a perioadei&nbsp;</DIV>
				<asp:textbox id="txtDataStop" style="CURSOR: hand" onclick="ShowCalendar(this,'../')" runat="server"
					MaxLength="10" Height="20px" ReadOnly="True" Width="100px" CssClass="NormalEditBoxuri"></asp:textbox></TD>
			<td><asp:button id="btnAfiseaza" runat="server" Width="95px" CssClass="ButtonStyle" Text="Afiseaza"></asp:button></td>
		</TR>
		<TR>
			<TD style="HEIGHT: 10px" align="left">
				<asp:RequiredFieldValidator id="RequiredFieldValidator1" CssClass="AlertRedBold" runat="server" ErrorMessage="Data de start nu a fost introdusa"
					ControlToValidate="txtDataStart"></asp:RequiredFieldValidator></TD>
			<td>
				<asp:RequiredFieldValidator id="RequiredFieldValidator2" CssClass="AlertRedBold" runat="server" ErrorMessage="Data de stop nu a fost introdusa"
					ControlToValidate="txtDataStop"></asp:RequiredFieldValidator></td>
			<td></td>
		</TR>
		<TR>
			<TD vAlign="top" colSpan="3"><asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder></TD>
		</TR>
	</TABLE>
</form>
