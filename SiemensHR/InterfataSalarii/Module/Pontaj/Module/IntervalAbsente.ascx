<%@ Control Language="c#" AutoEventWireup="false" Codebehind="IntervalAbsente.ascx.cs" Inherits="SiemensTM.Module.IntervalAbsente" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table cellSpacing="0" cellPadding="0">
	<tr>
		<td class="TaskStyle">Perioada :&nbsp;</td>
		<td style="WIDTH: 80px"><input style="WIDTH: 70px; HEIGHT: 22px" id="DateStart" maxLength="10" size="10" name="DateStart"
				runat="server">
		</td>
		<td width="15" align="center" style="WIDTH: 15px">&nbsp;<b>:</b>&nbsp;
		</td>
		<td style="WIDTH: 88px"><input style="WIDTH: 70px; HEIGHT: 22px" id="DateEnd" maxLength="10" size="10" name="DateEnd"
				runat="server">
		</td>
		<td>
			&nbsp;
			<asp:dropdownlist id="TipAbsentaDDL" runat="server" Width="300px"></asp:dropdownlist></td>
		<td></td>
		<td width="100%"></td>
	</tr>
	<tr>
		<td></td>
		<td class="TaskStyleSmall" vAlign="top" style="WIDTH: 80px"><asp:label id="LabelDataEnd" Runat="server">dd.mm.yyyy</asp:label></td>
		<td width="15" align="center" style="WIDTH: 15px"></td>
		<td class="TaskStyleSmall" vAlign="top" style="WIDTH: 88px"><asp:label id="LabelDataStart" Runat="server">dd.mm.yyyy</asp:label></td>
		<td>&nbsp;
			<table id="tableCM" runat="server">
				<TBODY>
					<tr>
						<td colSpan="2"><asp:dropdownlist id="TipBoalaDDL" runat="server" Width="300px"></asp:dropdownlist></td>
					</tr>
					<tr>
						<td class="TaskStyle" nowrap>Serie</td>
						<td><input id="txtSerie" maxLength="10" size="17" name="txtSerie" runat="server" style="WIDTH: 136px; HEIGHT: 22px">
						</td>
					</tr>
					<tr>
						<td class="TaskStyle" nowrap>Numar:</td>
						<td><input id="txtNumar" maxLength="50" size="17" name="txtNumar" runat="server" style="WIDTH: 136px; HEIGHT: 22px">
						</td>
					</tr>
					<tr>
						<td class="TaskStyle" vAlign="top" nowrap>Este certificat initial?</td>
						<td><SELECT id="txtCertificatInitial" name="txtCertificatInitial" runat="server">
								<OPTION selected value=""></OPTION>
								<OPTION value="Da">Da</OPTION>
								<option value="Nu">Nu</option>
							</SELECT>
							<table style="Z-INDEX: 0" id="tabelCertificat" runat="server">
								<TR>
									<TD class="TaskStyle" nowrap>Serie certificat initial:</TD>
									<TD><INPUT id="txtSerieCertificat" maxLength="50" size="12" name="txtSerieCertificat" runat="server">
									</TD>
								</TR>
								<TR>
									<TD class="TaskStyle" nowrap>Numar certificat initial:</TD>
									<TD><INPUT id="txtNumarCertificat" maxLength="50" size="12" name="txtNumarCertificat" runat="server">
									</TD>
								</TR>
							</table>
						</td>
					</tr>
					<tr>
						<td></td>
						<td></td>
					</tr>
					<tr>
						<td class="TaskStyle" nowrap>Data acordarii:</td>
						<td class="TaskStyle">
							<P><input id="txtDataAcordariiCertificat" maxLength="50" size="17" name="txtDataAcordariiCertificat"
									runat="server">&nbsp;dd.mm.yyyy</P>
						</td>
					</tr>
					<tr id="cnpCopilTr" runat="server">
						<td class="TaskStyle" nowrap>CNP copil:</td>
						<td><input id="txtCnpCopil" maxLength="50" size="17" name="txtCnpCopil" runat="server">
						</td>
					</tr>
					<tr>
						<td class="TaskStyle" nowrap>Locul de prescriere a certificatului:</td>
						<td><SELECT id="txtLocPrescriereCertificat" name="txtLocPrescriereCertificat" runat="server" style="WIDTH: 248px">
								<option selected></option>
								<OPTION>1 - eliberat de medicul de familie</OPTION>
								<OPTION>2 - eliberat de spital</OPTION>
								<OPTION>3 - eliberat de ambulatoriu</OPTION>
								<OPTION>4 - eliberat de CAS</OPTION>
							</SELECT>
						</td>
					</tr>
					<tr id="codUrgentaTr" runat="server">
						<td class="TaskStyle" nowrap>Cod urgenta:</td>
						<td><input id="txtCodUrgenta" maxLength="50" size="17" name="txtCodUrgenta" runat="server" style="WIDTH: 136px; HEIGHT: 22px">
						</td>
					</tr>
					<tr>
						<td class="TaskStyle" nowrap>Numarul avizului medicului expert:</td>
						<td><input id="txtNrAvizMedicExpert" maxLength="50" size="17" name="txtNrAvizMedicExpert" runat="server" style="WIDTH: 136px; HEIGHT: 22px">
						</td>
					</tr>
				</TBODY>
			</table>
		</td>
		<td style="HEIGHT: 23px" vAlign="top">&nbsp; <input id="CheckInterval" type="checkbox" name="CheckInterval" runat="server">
			<input id="IntervalAbsentaID" type="hidden" name="IntervalAbsentaID" runat="server">
		</td>
	</tr>
	<tr>
		<td class="TaskStyle" style="WIDTH: 76px">Observatii :&nbsp;</td>
		<td colSpan="5"><textarea style="WIDTH: 100%" id="observatiiTA" name="observatiiTA" runat="server"></textarea>
		</td>
	</tr>
	<tr id="trMedieZilnica" runat="server">
		<td colSpan="6">
			<table>
				<tr>
					<td class="TaskStyle">Medie zilnica:</td>
					<td><input style="WIDTH: 70px; HEIGHT: 22px" id="txtMedieZilnica" value="0" maxLength="10"
							size="10" name="txtMedieZilnica" runat="server"><asp:comparevalidator id="CompareValidator2" runat="server" ErrorMessage="Medie zilnica - introduceti o valoare numerica!"
							ControlToValidate="txtMedieZilnica" Type="Double" Operator="DataTypeCheck"><</asp:comparevalidator>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
