<%@ Control Language="c#" AutoEventWireup="false" Codebehind="MO_DataMajorareRaport.ascx.cs" Inherits="SiemensHR.MO_DataMajorareRaport" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<TABLE id="mainTable" height="100%" width="100%">
	<TR>
		<TD width="100%">
			<asp:label id="lblErr" runat="server" Width="96px"></asp:label></TD>
	</TR>
	<TR height="100%">
		<TD vAlign="top" width="100%">
			<cc1:ReportViewer id="rapDataMajorare" runat="server" Width="100%" Height="100%" ReportPath="/Rapoarte/DataMajorareAngajat"
				Parameters="False" ></cc1:ReportViewer></TD>
	</TR>
</TABLE>
