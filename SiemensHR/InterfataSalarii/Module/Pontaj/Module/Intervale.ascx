<%@ Control Language="c#" AutoEventWireup="false" Codebehind="Intervale.ascx.cs" Inherits="SiemensTM.Module.Intervale" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="uc1" TagName="IntervalIntreruperiContract" Src="IntervalIntreruperiContract.ascx" %>
<%@ Register TagPrefix="uc1" TagName="IntervalAbsente" Src="IntervalAbsente.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Interval" Src="Interval.ascx" %>
<table class="tabBackground" cellSpacing="2" cellPadding="2" width="100%">
	<tr>
		<td>
			<table height="100%">
				<tr>
					<td>
						<select id="selectTipPontaj" onchange="SubmitTipPontaj()" name="selectTipPontaj" runat="server">
						</select>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td class="NormalGreenBold" id="Title" runat="server"></td>
	</tr>
	<tr>
		<td class="tabBackground" id="OreSuplimentareLucrate" runat="server"></td>
	</tr>
	<tr>
		<td class="tabBackground" id="IntervaleExistenteLucrate" runat="server"></td>
	</tr>
	<tr>
		<td class="tabBackground" id="IntervaleExistente" runat="server"></td>
	</tr>
	<tr>
		<td class="tabBackground" id="IntervaleExistenteIntreruperi" runat="server"></td>
	</tr>
	<tr class="tabBackground">
		<td id="SaveLine" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="2" width="100%">
				<tr>
					<td></td>
					<td>
						<table id="tableBut" align="center" runat="server">
							<tr>
								<td><input class="ButtonStyle" id="Salveaza" onmouseover="MouseOverButton(this)" onclick="SubmitSave()"
										onmouseout="MouseOutButton(this)" type="button" value="Salveaza" name="Salveaza" runat="server">
								</td>
								<td><input class="ButtonStyle" id="Button2" onmouseover="MouseOverButton(this)" onclick="SubmitDeleteSelected()"
										onmouseout="MouseOutButton(this)" type="button" value="Sterge intervalele selectate"
										name="Button2" runat="server">
								</td>
							</tr>
						</table>
					</td>
					<td width="100%"></td>
				</tr>
				<TR>
					<TD></TD>
					<TD></TD>
				</TR>
			</table>
		</td>
	</tr>
	<tr>
		<td height="10">&nbsp;</td>
	</tr>
	<tr>
		<td id="AddLine" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="2" width="100%">
				<tr>
					<td id="ControlVizibil" runat="server"><uc1:interval id="AddInterval" runat="server"></uc1:interval><uc1:intervalabsente id="AddIntervalAbsente" runat="server"></uc1:intervalabsente><uc1:intervalintrerupericontract id="AddIntervalIntreruperi" runat="server"></uc1:intervalintrerupericontract></td>
					<td width="100%"></td>
				</tr>
				<tr>
					<td>
						<table align="center">
							<tr>
								<td><input class="ButtonStyle" id="Button1" onmouseover="MouseOverButton(this)" onclick="SubmitAdd()"
										onmouseout="MouseOutButton(this)" type="button" value="Adauga" name="Button1" runat="server">
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
</SELECT>
