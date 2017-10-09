<%@ Register TagPrefix="uc1" TagName="SalariiLunaLucru" Src="Module/SalariiLunaLucru.ascx" %>
<%@ Page Culture="RO-ro" language="c#" Codebehind="Salarii.aspx.cs" AutoEventWireup="false" Inherits="SiemensHR.InterfataSalarii.Salarii" %>
<%@ Register TagPrefix="uc1" TagName="MainSalarii" Src="Module/MainSalarii.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageHeader" Src="../PageHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderMenu" Src="../HeaderMenu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML XMLNS:IE>
	<HEAD>
		<title>HR Toolkit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" src="../js/jsCode.js"></script>
		<!--<script language="javascript" src="Module/Pontaj/js/jsCode.js"></script>-->
		<script language="javascript" src="Module/Pontaj/js/Intervale.js"></script>
		<LINK href="../StyleHR.css" type="text/css" rel="stylesheet">
		<script>
function CancelValidation()
{
document.Form1.onsubmit=MySubmit;
return -1;
}
function MySubmit()
{

}
		</script>
	</HEAD>
	<body>
		<form id="Form1" name="x" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td style="HEIGHT: 16px" vAlign="top" height="16"><uc1:pageheader id="PageHeader1" runat="server" relativePath="../"></uc1:pageheader></td>
				</tr>
				<tr>
					<td vAlign="top" align="center" height="20"><uc1:headermenu id="HeaderMenu1" runat="server" relativePath="../"></uc1:headermenu></td>
				</tr>
				<tr>
					<td vAlign="top" align="center"><uc1:mainsalarii id="MainSalarii1" runat="server"></uc1:mainsalarii></td>
				</tr>
			</table>
			<input id="ClientSelectedDate" type="hidden" name="ClientSelectedDate" runat="server">
			<input id="IntervaleSaveInfoID" type="hidden" name="IntervaleSaveInfoID" runat="server">
			<input id="IntervaleAbsenteSaveInfoID" type="hidden" name="IntervaleAbsenteSaveInfoID"
				runat="server"> <input id="actionIntervale" type="hidden" name="actionIntervale" runat="server">
			<!-- inputuri pt intervale orare--><input id="OraStart1" style="WIDTH: 70px; HEIGHT: 22px" type="hidden" maxLength="5" size="5"
				name="OraStart1" runat="server"> <input id="OraEnd1" style="WIDTH: 70px; HEIGHT: 22px" type="hidden" maxLength="5" size="16"
				name="OraEnd1" runat="server"> <input id="TipInterval1" type="hidden" name="TipInterval1" runat="server">
			<input id="CheckInterval1" type="checkbox" name="CheckInterval1" runat="server">
			<input id="IntervalID1" type="hidden" name="IntervalID1" runat="server"> 
			<!-- input pt drop down list cu angajati din Pontaje --><input id="angajatiDDLHidden" type="hidden" name="angajatiDDLHidden" runat="server">
			<!-- input pt drop down list-ul cu tip pontaj --><input id="ClientTipPontajHidden" type="hidden" name="ClientTipPontajHidden" runat="server">
			<!-- input pt a vedea daca drop down list-ul cu bolile e vizibil sau nu --><input id="NomenclatorBoliVisible1" type="hidden" name="NomenclatorBoliVisible1" runat="server">
			<!-- input-uri pt datele specifice absentelor... !!!mai tre pt observatii --><input id="DataStart1" style="WIDTH: 70px; HEIGHT: 22px" type="hidden" maxLength="10" size="10"
				name="DataStart1" runat="server"> <input id="DataEnd1" style="WIDTH: 70px; HEIGHT: 22px" type="hidden" maxLength="10" size="10"
				name="DataEnd1" runat="server"> <input id="TipIntervalAbsente1" type="hidden" name="TipIntervalAbsente1" runat="server">
			<input id="TipBoalaAbsente1" type="hidden" name="TipBoalaAbsente1" runat="server">
			<input id="CheckIntervalAbsente1" type="checkbox" name="CheckIntervalAbsente1" runat="server">
			<input id="IntervalAbsenteID1" type="hidden" name="IntervalAbsenteID1" runat="server">
			<input id="ObservatiiID" type="hidden" name="ObservatiiID" runat="server"> <input id="MedieZilnica1" type="hidden" name="MedieZilnica1" runat="server">
			<!-- input-uri pt Initializare luna --><input id="ActionInitializareLunaValoare" type="hidden" name="ActionInitializareLunaValoare"
				runat="server"> <input id="ListaCategoriiValue" type="hidden" name="ListaCategoriiValue" runat="server">
			<input id="txtNrZileLunaHidden" type="hidden" name="txtNrZileLunaHidden" runat="server">
			<input id="txtAlteDrepturiHidden" type="hidden" name="txtAlteDrepturiHidden" runat="server">
			<input id="txtAlteDrepturiNetHidden" type="hidden" name="txtAlteDrepturiNetHidden" runat="server">
			<input id="txtAjutorDecesHidden" type="hidden" name="txtAjutorDecesHidden" runat="server">
			<input id="txtNrOreConcediuBoalaHidden" type="hidden" name="txtNrOreConcediuBoalaHidden"
				runat="server"> <input id="txtNrOreConcediuOdihnaHidden" type="hidden" name="txtNrOreConcediuOdihnaHidden"
				runat="server"> <input id="txtNrZileCOneefectuatHidden" type="hidden" name="txtNrZileCOneefectuatHidden"
				runat="server"> <input id="txtNrZileCOefectInAvansHidden" type="hidden" name="txtNrZileCOefectInAvansHidden"
				runat="server"> <input id="txtNrOreEvenimDeosebHidden" type="hidden" name="txtNrOreEvenimDeosebHidden"
				runat="server"> <input id="txtNrOreInvoireHidden" type="hidden" name="txtNrOreInvoireHidden" runat="server">
			<input id="txtNrOreObligatiiCetatenestiHidden" type="hidden" name="txtNrOreObligatiiCetatenestiHidden"
				runat="server"> <input id="txtNrOreAbsenteNemotivateHidden" type="hidden" name="txtNrOreAbsenteNemotivateHidden"
				runat="server"> <input id="txtNrOreConcediuFaraPlataHidden" type="hidden" name="txtNrOreConcediuFaraPlataHidden"
				runat="server"> <input id="txtNrOreLucrateHidden" type="hidden" name="txtNrOreLucrateHidden" runat="server">
			<input id="txtNrOreSup100ProcHidden" type="hidden" name="txtNrOreSup100ProcHidden" runat="server">
			<input id="txtNrOreSup50ProcHidden" type="hidden" name="txtNrOreSup50ProcHidden" runat="server">
			<input id="txtPrimeSpecialeHidden" type="hidden" name="txtPrimeSpecialeHidden" runat="server">
			<input id="txtSporActivitatiSupHidden" type="hidden" name="txtSporActivitatiSupHidden"
				runat="server"> <input id="txtEmergencyServiceHidden" type="hidden" name="txtEmergencyServiceHidden" runat="server">
			<input id="txtAvansHidden" type="hidden" name="txtAvansHidden" runat="server"> <input id="txtRetineriHidden1" type="hidden" name="txtRetineriHidden1" runat="server"><INPUT id="txtRetineriHidden2" type="hidden" name="txtRetineriHidden2" runat="server"><INPUT id="txtRetineriHidden3" type="hidden" name="txtRetineriHidden3" runat="server"><INPUT id="txtRetineriHidden4" type="hidden" name="txtRetineriHidden4" runat="server"><INPUT id="txtRetineriHidden5" type="hidden" name="txtRetineriHidden5" runat="server"><INPUT id="txtRetineriHidden6" type="hidden" name="txtRetineriHidden6" runat="server"><INPUT id="txtRetineriHidden7" type="hidden" name="txtRetineriHidden7" runat="server">
			<input id="txtPrimaProiectHidden" type="hidden" name="txtPrimaProiectHidden" runat="server">
			<input id="txtRegularizareHidden" type="hidden" name="txtRegularizareHidden" runat="server">
			<input id="txtRetinereSanatateHidden" type="hidden" name="txtRetinereSanatateHidden" runat="server">
			<!-- input pt butoanele de generare a situtiei lunare --><input id="ActionGenerareSituatieLunaraValue" type="hidden" name="ActionGenerareSituatieLunaraValue"
				runat="server"> 
			<!-- Input-uri pt SituatieLunaraAngajat--><input id="actionSituatieLunaraAngajatValue" type="hidden" name="actionSituatieLunaraAngajatValue"
				runat="server"> <input id="txtSituatieIDHidden" type="hidden" name="txtSituatieIDHidden" runat="server">
			<!-- Input-uri pt LichidareAngajat--><input id="txtTipActiuneLichidareHidden" type="hidden" name="txtTipActiuneLichidareHidden"
				runat="server"> <input id="txtNrInregistrareHidden" type="hidden" name="txtNrInregistrareHidden" runat="server">
			<input id="txtDataLichidareHidden" type="hidden" name="txtDataLichidareHidden" runat="server">
			<input id="txtAvansuriDecontareHidden" type="hidden" name="txtAvansuriDecontareHidden"
				runat="server"> <input id="txtAbonamenteHidden" type="hidden" name="txtAbonamenteHidden" runat="server">
			<input id="txtTicheteMasaHidden" type="hidden" name="txtTicheteMasaHidden" runat="server">
			<input id="txtEchipamentLucruHidden" type="hidden" name="txtEchipamentLucruHidden" runat="server">
			<input id="txtLaptopHidden" type="hidden" name="txtLaptopHidden" runat="server">
			<input id="txtTelServiciuHidden" type="hidden" name="txtTelServiciuHidden" runat="server">
			<input id="txtObiecteInventarHidden" type="hidden" name="txtObiecteInventarHidden" runat="server">
			<input id="txtCartiHidden" type="hidden" name="txtCartiHidden" runat="server"> <input id="txtCDHidden" type="hidden" name="txtCDHidden" runat="server">
			<input id="txtDataInregistrareHidden" type="hidden" name="txtDataInregistrareHidden" runat="server">
			<input id="txtNrArticolHidden" type="hidden" name="txtNrArticolHidden" runat="server">
			<input id="txtLunaRetinereHidden" type="hidden" name="txtLunaRetinereHidden" runat="server">
			<!-- Added: Ionel Popa --><input id="txtPerformIndexingHidden" type="hidden" name="txtPerformIndexingHidden" runat="server">
			<INPUT id="txtSerieHidden" type="hidden" runat="server" NAME="txtSerieHidden"><INPUT id="txtNumarHidden" type="hidden" runat="server" NAME="txtNumarHidden"><INPUT id="txtMotivDePlecareHidden" type="hidden" name="txtMotivDePlecareHidden" runat="server">
			<INPUT id="ActionImportLunaValue" type="hidden" name="ActionImportLunaValue" runat="server">
			<INPUT id="ActionImportDelegatiiLunaValue" type="hidden" name="ActionImportDelegatiiLunaValue"
				runat="server"><INPUT id="ActionSincronizareDateAngajatiValue" type="hidden" name="ActionSincronizareDateAngajatiValue"
				runat="server"> 
			<!-- Input-uri pt RetineriAngajat--><input id="txtActiuneRetinere" type="hidden" name="actionRetinereValue" runat="server">
			<INPUT id="txtDataStartRetinereHidden" type="hidden" name="actionRetinereValue" runat="server">
			<INPUT id="txtDataEndRetinereHidden" type="hidden" name="actionRetinereValue" runat="server">
			<INPUT id="txtValoareRetinereHidden" type="hidden" name="actionRetinereValue" runat="server">
			<INPUT id="tipRetinereHidden" type="hidden" name="actionRetinereValue" runat="server">
			<INPUT id="txtDenumireRetinereHidden" type="hidden" name="actionRetinereValue" runat="server">
			<INPUT id="chkAlertaRetinereHidden" type="checkbox" name="CheckInterval1" runat="server">
			<INPUT id="txtRetinereIdHidden" type="hidden" name="actionRetinereValue" runat="server">&nbsp;
			<INPUT id="txtNrTicheteHidden" type="hidden" name="txtNrTicheteHidden" runat="server">
			<INPUT id="txtCorectiiTicheteHidden" type="hidden" name="txtCorectiiTicheteHidden" runat="server">
			<INPUT id="txtNrOreLucrateDelegatieInternaHidden" type="hidden" name="txtNrOreLucrateDelegatieInternaHidden" runat="server">
			<INPUT id="txtNrOreLucrateDelegatieExternaHidden" type="hidden" name="txtNrOreLucrateDelegatieExternaHidden" runat="server">
			<INPUT id="txtDiurnaImpozabilaHidden" type="hidden" name="txtDiurnaImpozabilaHidden" runat="server"> 
			<INPUT id="txtDrepturiInNaturaHidden" type="hidden" name="txtDrepturiInNaturaHidden" runat="server">
			<INPUT style="Z-INDEX: 0" id="txtCertificatInitialHidden" type="hidden" name="txtCertificatInitialHidden"
				runat="server"><INPUT style="Z-INDEX: 0" id="txtCnpCopilHidden" type="hidden" name="txtCnpCopil" runat="server">
			<INPUT style="Z-INDEX: 0" id="txtDataAcordariiCertificatHidden" type="hidden" name="txtDataAcordariiCertificat"
				runat="server"> <INPUT style="Z-INDEX: 0" id="txtLocPrescriereCertificatHidden" type="hidden" name="txtLocPrescriereCertificat"
				runat="server"><INPUT style="Z-INDEX: 0" id="txtCodUrgentaHidden" type="hidden" name="txtCodUrgenta" runat="server"><INPUT style="Z-INDEX: 0" id="txtNrAvizMedicExpertHidden" type="hidden" name="txtNrAvizMedicExpert"
				runat="server"><INPUT style="Z-INDEX: 0" id="txtSerieCertificatHidden" type="hidden" name="txtSerieCertificat"
				runat="server"><INPUT style="Z-INDEX: 0" id="txtNumarCertificatHidden" type="hidden" name="txtNumarCertificat"
				runat="server"> <INPUT style="Z-INDEX: 0" id="ActionTrimiteMailFluturasiLunaValue" type="hidden" name="ActionImportLunaValue"
				runat="server"> <INPUT id="MailFluturasiLunaValue" type="hidden" runat="server" NAME="MailFluturasiLunaValue">
		</form>
	</body>
</HTML>
