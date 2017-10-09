<%@ Control Language="c#" AutoEventWireup="false" Codebehind="MO_CheckupRaport.ascx.cs" Inherits="SiemensHR.MO_CheckupRaport" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<table id="mainTable" height="100%" width="100%">
	<tr>
		<td width="100%" align="center"><asp:label id="lblErr" Width="96px" runat="server" CssClass="AlertRedBold"></asp:label></td>
	</tr>
	<tr height="100%">
		<td vAlign="top" width="100%"><cc1:reportviewer id="rapCheckup" Width="100%" runat="server"
				Parameters="False" Toolbar="Default" ReportPath="/Rapoarte/CheckupAngajat" Height="100%"></cc1:reportviewer></td>
	</tr>
</table>
