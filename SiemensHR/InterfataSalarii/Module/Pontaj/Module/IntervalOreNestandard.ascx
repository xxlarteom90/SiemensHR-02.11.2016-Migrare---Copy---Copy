<%@ Control Language="c#" AutoEventWireup="false" Codebehind="IntervalOreNestandard.ascx.cs" Inherits="SiemensTM.Module.IntervalOreNestandard" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table>
	<tr>
		<td width="375">
			Numar ore suplimentare de tipul&nbsp;<asp:Label ID="labelTipOreSuplimentare" Runat="server"></asp:Label>:
		</td>
		<td>
			<asp:TextBox ID="txtNrOreSuplimentare" Runat="server" Width="50" MaxLength="5">0</asp:TextBox><asp:comparevalidator id="CompareValidator1" runat="server" ErrorMessage="Valoare reala" ControlToValidate="txtNrOreSuplimentare"
				Type="Double" Operator="DataTypeCheck" CssClass="AlertRedBold"><</asp:comparevalidator>
		</td>
	</tr>
</table>
