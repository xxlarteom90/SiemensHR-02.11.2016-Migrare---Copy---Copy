<%@ Control Language="c#" AutoEventWireup="false" Codebehind="ManagersOptions_EvolutieSal.ascx.cs" Inherits="SiemensHR.ManagersOptions_EvolutieSal" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<form id="wsww" method="post" runat="server">
	<table id="table1" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
		<TR>
			<TD class="GreenSeparator" colSpan="2" height="1"><IMG height="1" src="images/1x1.gif"></TD>
		</TR>
		<tr style="FONT-WEIGHT: bold; TEXT-TRANSFORM: none; COLOR: #20b2aa; FONT-FAMILY: Arial">
			<td align="center" colSpan="2" height="32">Evolutia salariilor angajatilor din 
				departamentul&nbsp;
				<asp:label id="numeDept" runat="server"></asp:label></td>
		</tr>
		<TR>
			<TD class="GreenSeparator" colSpan="2" height="1"><IMG height="1" src="images/1x1.gif"></TD>
		</TR>
		<tr>
			<td align="right" height="32">
				<asp:label id="Label2" runat="server" Width="252px" CssClass="NormalGreenBold">Angajat pentru care se urmareste evolutia:</asp:label></td>
			<td align="left" height="32">
				<asp:dropdownlist id="lstAngajati" runat="server" Width="250px"></asp:dropdownlist></td>
		</tr>
		<tr>
			<td align="right" height="32">
				<asp:label id="Label3" runat="server" Width="240px" CssClass="NormalGreenBold">Perioada pe care se va urmari evolutia:</asp:label></td>
			<td align="left" height="32">
				<asp:dropdownlist id="DropDownList1" runat="server" Width="250px">
					<asp:ListItem Value="2">Pe ultimele 2 luni</asp:ListItem>
					<asp:ListItem Value="3">Pe ultimele 3 luni</asp:ListItem>
					<asp:ListItem Value="6">Pe ultimele 6 luni</asp:ListItem>
					<asp:ListItem Value="12">In ultimul an</asp:ListItem>
					<asp:ListItem Value="100" Selected="True">Fara perioada de timp</asp:ListItem>
				</asp:dropdownlist></td>
		</tr>
		<tr>
			<td align="center" width="40%" colspan="2" height="50">
				<asp:Button id="btnAfiseaza" runat="server" Text="Afiseaza" CssClass="ButtonStyle"></asp:Button></td>
		</tr>
		<tr>
			<td vAlign="top" align="center" colSpan="2">
				<P><asp:placeholder id="PlaceHolder1" runat="server"></asp:placeholder></P>
			</td>
		</tr>
	</table>
</form>
