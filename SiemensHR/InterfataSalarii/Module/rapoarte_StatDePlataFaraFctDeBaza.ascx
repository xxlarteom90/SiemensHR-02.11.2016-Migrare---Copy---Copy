<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_StatDePlataFaraFctDeBaza.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_StatDePlataFaraFctDeBaza" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table height="100%" cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td height="100%">
			<cc1:ReportViewer id="rapStatPlata" runat="server" Width="100%" Height="600px" BackColor="White" BorderColor="Transparent"
				Parameters="False" Toolbar="True" ForeColor="White" Zoom="100%" ReportPath="/Rapoarte/StatDePlataFctDeBaza"></cc1:ReportViewer>
		</td>
	</tr>
</table>
