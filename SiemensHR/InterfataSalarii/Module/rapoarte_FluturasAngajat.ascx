<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_FluturasAngajat.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_FluturasAngajat" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table height="100%" cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td>&nbsp;
			<asp:dropdownlist id="lstAngajati" AutoPostBack="True" runat="server" Width="336px"></asp:dropdownlist></td>
	</tr>
	<tr>
		<td height="100%">
			<cc1:ReportViewer id="rapFluturas" runat="server" Width="100%"
				Height="800px" BackColor="White" BorderColor="Transparent" Parameters="True" Toolbar="False" ForeColor="White"
				Zoom="100%"></cc1:ReportViewer>
		</td>
	</tr>
</table>
