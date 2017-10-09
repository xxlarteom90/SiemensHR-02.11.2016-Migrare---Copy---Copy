<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_DeclaratieSanatateA2.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_DeclaratieSanatateA2" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
</SCRIPT>
<table id="main" height="100%" width="100%">
	<TR>
		<TD align="left" colSpan="2"><asp:label id="labelError" CssClass="AlertRedBold" runat="server"></asp:label></TD>
	</TR>
	<TR>
		<TD vAlign="top"><cc1:reportviewer id="raportDeclaratieA2" Width="100%" height="600px" runat="server" ReportPath="/Rapoarte/CM_DCL_A2"
				Zoom="100%" ForeColor="White" Toolbar="True" Parameters="False" BorderColor="Transparent" BackColor="White"></cc1:reportviewer></TD>
	</TR>
</table>
