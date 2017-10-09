<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Salarii_Pontaj.ascx.cs" Inherits="SiemensHR.InterfataSalarii.Module.Salarii_Pontaj" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script>
/*
function SelectPontajOption(Option )
{
	document.location = "Salarii.aspx?Tab=Pontaj&Option=" + Option;
}
*/

</script>
<table height="100%" cellSpacing="0" cellPadding="0" width="100%" onload="GenerareSituatieLunaraAngajat();">
	<tr>
		<td>
			<table height="100%" width="100%">
				<tr>
					<td>
						<table>
							<tr>
								<td class="TaskStyle"><asp:label id="labelAngajatCurent" Width="100%" Visible="True" Runat="server">Angajat curent :&nbsp;</asp:label></td>
								<td><asp:dropdownlist id="angajatDDL" Width="392px" Visible="True" Runat="server" AutoPostBack="True"></asp:dropdownlist></td>
								<td><input class="ButtonStyle" id="ButtonGenerareSituatieLunaraAngajat" onmouseover="MouseOverButton(this)"
										onclick="GenerareSituatieLunaraAngajat();" onmouseout="MouseOutButton(this)" type="button"
										value="Situatie lunara angajat" name="ButtonGenerareSituatieLunaraAngajat" runat="server">
								</td>
								<td><input class="ButtonStyle" id="ButtonGenerareSituatieLunaraTotiAngajatii" onmouseover="MouseOverButton(this)"
										onclick="GenerareSituatieLunaraTotiAngajatii()" onmouseout="MouseOutButton(this)" type="button"
										value="Situatie lunara toti angajatii" name="ButtonGenerareSituatieLunaraTotiAngajatii"
										runat="server">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr height="100%">
					<td id="Center" align="center" runat="server"></td>
				</tr>
			</table>
		</td>
	</tr>
</table>
