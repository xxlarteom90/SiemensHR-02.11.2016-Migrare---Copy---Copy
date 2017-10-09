<%@ Register TagPrefix="cc1" Namespace="ReportingServices" Assembly="ReportViewer" %>
<%@ Control Language="c#" AutoEventWireup="false" Codebehind="rapoarte_DeclaratieSanatateA3b.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.rapoarte_DeclaratieSanatateA3b" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>



<table id=main height="100%" width="100%">
  <tr height="15%" width="100%">
    <td align=center colSpan=2>
      <table>
        <tr>
          <td class=NormalGreenBold style="HEIGHT: 19px" 
            >Casa de asigurari: </TD>
          <td style="HEIGHT: 19px"><asp:dropdownlist id=drpCaseDeAsig CssClass="NormalEditBoxuri" Width="297px" runat="server"></asp:dropdownlist><SPAN 
            class=CommentRedBold>*</SPAN> </TD></TR>
        <tr>
          <td class=CommentRedBold align=left colSpan=2>* 
            - Campuri obligatorii </TD></TR>
        <tr>
          <td align=center colSpan=2><asp:button id=btnAfiseaza CssClass="ButtonStyle" runat="server" Text="Afiseaza"></asp:button></TD></TR></TABLE></TD></TR>
  <TR height="5%" width="100%">
    <TD style="HEIGHT: 22px" align=left colSpan=2><asp:label id=labelError CssClass="AlertRedBold" runat="server"></asp:label></TD></TR>
  <tr height="1%" width="100%">
    <td align=center colSpan=2><asp:validationsummary id=sumarValidare Width="159px" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary></TD></TR>
  <TR height="79%" width="100%">
    <TD vAlign=top colSpan=2><cc1:reportviewer id=raportSanatate Width="100%" runat="server" ReportPath="/Rapoarte/Anexa3b" Zoom="100%" ForeColor="White" Toolbar="True" Parameters="False" BorderColor="Transparent" BackColor="White" height="500px"></cc1:reportviewer></TD></TR></TABLE>
