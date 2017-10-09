<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_DeclaratiaA11.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_DeclaratiaA11" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<table id="main" width="100%" Height="100%">
	<TR>
		<TD vAlign="top">
			<cc1:reportviewer id="raportDeclaratiaA11" runat="server" Width="100%" Height="600px" BackColor="White"
				BorderColor="Transparent" Parameters="False" Toolbar="True" ForeColor="White" Zoom="100%" ReportPath="/Rapoarte/A11"></cc1:reportviewer>
		</TD>
	</TR>
	<tr>
		<td>
			<asp:Button id="btnDownloadA11" runat="server" Text="Download a11.txt" CssClass="ButtonStyle"></asp:Button>
		</td>
	</tr>
</table>
