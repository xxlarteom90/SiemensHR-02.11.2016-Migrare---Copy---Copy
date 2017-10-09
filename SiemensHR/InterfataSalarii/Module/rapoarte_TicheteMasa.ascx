<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_TicheteMasa.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_TicheteMasa" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<table height="100%" cellSpacing="0" cellPadding="0" width="100%">
	<tr>
		<td height="100%">
			<cc1:ReportViewer id="rapTicheteMasa" runat="server" Width="100%" Height="600px" BackColor="White"
				BorderColor="Transparent" Parameters="False" Toolbar="True" ForeColor="White" Zoom="100%" ReportPath="/Rapoarte/TicheteMasa"></cc1:ReportViewer>
		</td>
	</tr>
</table>
