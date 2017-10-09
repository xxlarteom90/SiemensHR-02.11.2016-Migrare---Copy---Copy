<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_TicheteDeMasa.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_TicheteDeMasa" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<table id="main" width="100%" Height="100%">
	<TR>
		<TD vAlign="top">
			<cc1:reportviewer id="raportTicheteDeMasa" runat="server" Width="100%" Height="600px" 
				BackColor="White" BorderColor="Transparent" Parameters="False" Toolbar="True" ForeColor="White"
				Zoom="100%" ReportPath="/Rapoarte/TicheteDeMasaFirma"></cc1:reportviewer>
		</TD>
	</TR>
</table>
