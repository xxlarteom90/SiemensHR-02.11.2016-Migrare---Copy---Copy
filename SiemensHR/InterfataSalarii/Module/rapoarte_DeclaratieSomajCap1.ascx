<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_DeclaratieSomajCap1.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_DeclaratieSomajCap1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<table id="main" height="100%" width="100%">
	<TR height="100%" width="100%">
		<TD vAlign="top" colSpan="2"><cc1:reportviewer id="raportSomaj" runat="server" Width="100%" height="600px" 
				BackColor="White" BorderColor="Transparent" Parameters="False" Toolbar="True" ForeColor="White" Zoom="100%" ReportPath="/Rapoarte/Cap1"></cc1:reportviewer></TD>
	</TR>
	<tr>
		<td>
			<asp:Button id="btnDownloadCap1" runat="server" Text="Download cap1.txt" CssClass="ButtonStyle"></asp:Button>
		</td>
	</tr>
</table>
