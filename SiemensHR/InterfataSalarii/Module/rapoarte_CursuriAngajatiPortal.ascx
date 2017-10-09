<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_CursuriAngajatiPortal.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_CursuriAngajatiPortal" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<table id="main" width="100%" Height="100%">
	<TR>
		<TD vAlign="top">
			<cc1:reportviewer id="raportCursuriAngajati" runat="server" Width="100%" Height="600px" BackColor="White"
				BorderColor="Transparent" Parameters="False" Toolbar="True" ForeColor="White" Zoom="100%" ReportPath="/Rapoarte/TraininguriAngajatiPortal"></cc1:reportviewer>
		</TD>
	</TR>
</table>
