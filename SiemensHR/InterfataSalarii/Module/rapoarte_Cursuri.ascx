<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_Cursuri.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_Cursuri" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table id="main" width="100%" Height="100%">
	<TR>
		<TD vAlign="top">
			<cc1:reportviewer id="raportCursuri" runat="server" Width="100%" Height="600px" BackColor="White"
				BorderColor="Transparent" Parameters="False" Toolbar="True" ForeColor="White" Zoom="100%" ReportPath="/Rapoarte/TraininguriAngajatiVar2"></cc1:reportviewer>
		</TD>
	</TR>
</table>
