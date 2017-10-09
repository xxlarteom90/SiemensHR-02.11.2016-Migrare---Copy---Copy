<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SalariiLunaLucru.ascx.cs" Inherits="SiemensHR.InterfataSalarii.SalariiLunaLucru" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<table cellSpacing="0" cellPadding="0" width="100%" bgColor="#f3f6f9" border="0">
	<tr>
		<td class="TaskStyle" align="center" height="30">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
			Luna curenta:&nbsp;&nbsp;
			<asp:dropdownlist id="lstLuni" AutoPostBack="True" Width="185px" runat="server"></asp:dropdownlist>
			<%
				if ( IsPontajAvailable())
				{
			%>
			<asp:Button id="CalculSalarii" runat="server" CssClass="ButtonStyle" Text="Calcul salarii luna activa"></asp:Button>
			<asp:Button id="InchideLunaActiva" Width="150px" runat="server" CssClass="ButtonStyle" Text="Inchide luna activa"></asp:Button>
			<asp:Button id="btnRedeschidereLuna" runat="server" Text="Redeschidere luna anterioara" CssClass="ButtonStyle"></asp:Button></td>
		<%
				}
				else
				{
			%>
		<asp:Button id="Button1" runat="server" CssClass="ButtonStyle" Text="Calcul salarii luna activa"
			Enabled="false"></asp:Button>
		<asp:Button id="Button2" Width="150px" runat="server" CssClass="ButtonStyle" Text="Inchide luna activa"
			Enabled="false"></asp:Button>
		<asp:Button id="Button3" runat="server" Text="Redeschidere luna anterioara" CssClass="ButtonStyle"
			Enabled="false"></asp:Button></TD>
		<%
				}			
			%>
	</tr>
</table>
<INPUT id="HDACT" style="WIDTH: 30px; HEIGHT: 8px" type="hidden" size="1" name="Hidden1"
	runat="server">
<script>
	function CheckDelete( text )
	{
		if (confirm(text))
			return true;
		else
			return false;
	}
</script>
