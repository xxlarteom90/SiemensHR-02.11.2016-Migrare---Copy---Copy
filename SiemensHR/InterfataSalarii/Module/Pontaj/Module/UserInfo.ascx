<%@ Control Language="c#" AutoEventWireup="false" Codebehind="UserInfo.ascx.cs" Inherits="SiemensTM.Module.UserInfo" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table width="100%" class="tabBackground">
	<tr>
		<td id="imageAngajat" align="center">
			<table width="150" cellspacing="0" cellpadding="2">
				<tr>
					<td align="center">
						<img src="utils/ShowPicture.aspx" width="150">
					</td>
				</tr>
				<tr>
					<td align="center">
						<asp:Label id="lblTitlu" CssClass="NormalGreenBold" runat="server"></asp:Label>
					</td>
				</tr>
				<TR>
					<TD align="center">
						<asp:Label id="lblNume" CssClass="NormalBlackBold" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Label id="lblFunctie" CssClass="NormalGreenBold" runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:Label id="lblDepartament" CssClass="NormalGreenBold" runat="server"></asp:Label></TD>
				</TR>
			</table>
		</td>
	</tr>
</table>
