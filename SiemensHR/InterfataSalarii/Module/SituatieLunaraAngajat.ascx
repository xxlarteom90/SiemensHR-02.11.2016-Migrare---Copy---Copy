<%@ Control Language="c#" AutoEventWireup="false" Codebehind="SituatieLunaraAngajat.ascx.cs" Inherits="SiemensHR.InterfataSalarii.SituatieLunaraAngajat" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<script>
	var arTabs = new Array('tableListSit');

	function SelectTab(index)
	{
		for(i=0; i<arTabs.length; i++)
		{
			if (i==index)
			{
				eval(arTabs[i] + ".style.display=''");
				eval(ctrlID+"_tab"+ (i+1)+ ".className='tabActive'");
					
			}
			else
			{
				eval(ctrlID+"_tab"+ (i+1) + ".className='tab'");
				eval(ctrlID+"_tab"+ (i+1) + ".style.backgroundColor='#7b8fc2'");
				eval(arTabs[i] + ".style.display='none'");
			}
		}
		editButtonsLine.style.display = "none";
		addButtonsLine.style.display = "";
		tdTextLine.innerText = "Adauga situatie";
		tableAdaugaSit.style.display = "none";			
		completeFields(0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);		
	}
	
	/*
		Functie apelata in cazul in care angajatul este lichidat.
	*/
	function completeFieldsLichidare
	(						NrZileLuna,
							NrOreLucrate,
							NrOreSup50Proc,
							NrOreSup100Proc,
							NrOreEvenimDeoseb,
							NrOreInvoire,
							NrOreConcediuOdihna,
							NrZileCOneefectuat,
							NrZileCOefectuatInAvans,
							NrOreConcediuBoala,
							NrOreObligatiiCetatenesti,
							NrOreAbsenteNemotivate,
							NrOreConcediuFaraPlata,
							NrOreLucrateDelegatieInterna,
							NrOreLucrateDelegatieExterna,
							DiurnaImpozabila,
							NrTichete,
							CorectiiTichete,
							SporActivitatiSup,
							EmergencyService,
							PrimeSpeciale,
							AlteDrepturi,
							AlteDrepturiNet,
							AjutorDeces,
							Avans,
							Retinere1,
							Retinere2,
							Retinere3,
							Retinere4,
							Retinere5,
							Retinere6,
							Retinere7,
							Regularizare,
							PrimaProiect,
							RetinereSanatate,
							DrepturiInNatura
							)
	{
		eval("Form1."+ctrlID+"_txtNrZileLuna.value = NrZileLuna;");		
		eval("Form1."+ctrlID+"_txtNrOreLucrate.value = NrOreLucrate;");		
		eval("Form1."+ctrlID+"_txtNrOreSup50Proc.value = NrOreSup50Proc;");
		eval("Form1." +ctrlID+"_txtNrOreSup100Proc.value =NrOreSup100Proc ;");
		eval("Form1." +ctrlID+"_txtNrOreEvenimDeoseb.value =NrOreEvenimDeoseb ;");
		eval("Form1." +ctrlID+"_txtNrOreInvoire.value =NrOreInvoire ;");
		eval("Form1." +ctrlID+"_txtNrOreConcediuOdihna.value =NrOreConcediuOdihna ;");
		eval("Form1." +ctrlID+"_txtNrZileCOneefectuat.value = NrZileCOneefectuat ;");
		eval("Form1." +ctrlID+"_txtNrZileCOefectInAvans.value = NrZileCOefectuatInAvans ;");
		eval("Form1." +ctrlID+"_txtNrOreConcediuBoala.value =NrOreConcediuBoala ;");
		
		eval("Form1." +ctrlID+"_txtNrOreObligatiiCetatenesti.value = NrOreObligatiiCetatenesti;");
		eval("Form1." +ctrlID+"_txtNrOreAbsenteNemotivate.value = NrOreAbsenteNemotivate;");
		eval("Form1." +ctrlID+"_txtNrOreConcediuFaraPlata.value = NrOreConcediuFaraPlata;");
		
		eval("Form1." +ctrlID+"_txtSporActivitatiSup.value =SporActivitatiSup ;");
		eval("Form1." +ctrlID+"_txtEmergencyService.value =EmergencyService ;");
		eval("Form1." +ctrlID+"_txtPrimeSpeciale.value =PrimeSpeciale ;");
		eval("Form1." +ctrlID+"_txtAlteDrepturi.value =AlteDrepturi ;");
		eval("Form1." +ctrlID+"_txtAlteDrepturiNet.value =AlteDrepturiNet ;");
		eval("Form1." +ctrlID+"_txtAjutorDeces.value =AjutorDeces ;");
		
		eval("Form1." +ctrlID+"_txtAvans.value =Avans ;");
		eval("Form1." +ctrlID+"_txtRetineri1.value =Retinere1 ;");
		eval("Form1." +ctrlID+"_txtRetineri2.value =Retinere2 ;");
		eval("Form1." +ctrlID+"_txtRetineri3.value =Retinere3 ;");
		eval("Form1." +ctrlID+"_txtRetineri4.value =Retinere4 ;");
		eval("Form1." +ctrlID+"_txtRetineri5.value =Retinere5 ;");
		eval("Form1." +ctrlID+"_txtRetineri6.value =Retinere6 ;");
		eval("Form1." +ctrlID+"_txtRetineri7.value =Retinere7 ;");
		eval("Form1." +ctrlID+"_txtRegularizare.value =Regularizare ;");
		eval("Form1." +ctrlID+"_txtPrimaProiect.value =PrimaProiect ;");
		eval("Form1." +ctrlID+"_txtRetinereSanatate.value =RetinereSanatate ;");
		
		eval("Form1." +ctrlID+"_txtNrOreLucrateDelegatieInterna.value = NrOreLucrateDelegatieInterna ;");
		eval("Form1." +ctrlID+"_txtNrOreLucrateDelegatieExterna.value = NrOreLucrateDelegatieExterna ;");
		eval("Form1." +ctrlID+"_txtDiurnaImpozabila.value = DiurnaImpozabila ;");
		eval("Form1." +ctrlID+"_txtNrTichete.value = NrTichete ;");
		eval("Form1." +ctrlID+"_txtCorectiiTichete.value = CorectiiTichete ;");
		
		eval("Form1." +ctrlID+"_txtDrepturiInNatura.value = DrepturiInNatura ;");
		
		eval("Form1." +ctrlID+"_txtMedieZilnicaCO.value = medieZilnicaCO;");
		
		document.getElementById("trLichidareSeparator").style.display = '';
		document.getElementById("trLichidare").style.display = '';
		document.getElementById("trCOneefSeparator").style.display = '';
		document.getElementById("trCOneef").style.display = '';
		document.getElementById("trCOefectAvansSeparator").style.display = '';
		document.getElementById("trCOefectAvans").style.display = '';
		document.getElementById("trMedieZilnicaSeparator").style.display = '';
		document.getElementById("trMedieZilnica").style.display = '';
	}
	
	/*
		Functie apelatata in cazul angajatul nu este lichidat.
	*/
	function completeFields(NrZileLuna,
							NrOreLucrate,
							NrOreSup50Proc,
							NrOreSup100Proc,
							NrOreEvenimDeoseb,
							NrOreInvoire,
							NrOreConcediuOdihna,
							NrOreConcediuBoala,
							NrOreObligatiiCetatenesti,
							NrOreAbsenteNemotivate,
							NrOreConcediuFaraPlata,
							NrOreLucrateDelegatieInterna,
							NrOreLucrateDelegatieExterna,
							DiurnaImpozabila,
							NrTichete,
							CorectiiTichete,
							SporActivitatiSup,
							EmergencyService,
							PrimeSpeciale,
							AlteDrepturi,
							AlteDrepturiNet,
							AjutorDeces,
							Avans,
							Retinere1,
							Retinere2,
							Retinere3,
							Retinere4,
							Retinere5,
							Retinere6,
							Retinere7,
							Regularizare,
							PrimaProiect,
							RetinereSanatate,
							DrepturiInNatura
							)
	{
		eval("Form1."+ctrlID+"_txtNrZileLuna.value = NrZileLuna;");		
		eval("Form1."+ctrlID+"_txtNrOreLucrate.value = NrOreLucrate;");		
		eval("Form1."+ctrlID+"_txtNrOreSup50Proc.value = NrOreSup50Proc;");
		eval("Form1." +ctrlID+"_txtNrOreSup100Proc.value =NrOreSup100Proc ;");
		eval("Form1." +ctrlID+"_txtNrOreEvenimDeoseb.value =NrOreEvenimDeoseb ;");
		eval("Form1." +ctrlID+"_txtNrOreInvoire.value =NrOreInvoire ;");
		eval("Form1." +ctrlID+"_txtNrOreConcediuOdihna.value =NrOreConcediuOdihna ;");
		eval("Form1." +ctrlID+"_txtNrOreConcediuBoala.value =NrOreConcediuBoala ;");
		
		eval("Form1." +ctrlID+"_txtNrOreObligatiiCetatenesti.value = NrOreObligatiiCetatenesti;");
		eval("Form1." +ctrlID+"_txtNrOreAbsenteNemotivate.value = NrOreAbsenteNemotivate;");
		eval("Form1." +ctrlID+"_txtNrOreConcediuFaraPlata.value = NrOreConcediuFaraPlata;");
		
		eval("Form1." +ctrlID+"_txtSporActivitatiSup.value =SporActivitatiSup ;");
		eval("Form1." +ctrlID+"_txtEmergencyService.value =EmergencyService ;");
		eval("Form1." +ctrlID+"_txtPrimeSpeciale.value =PrimeSpeciale ;");
		eval("Form1." +ctrlID+"_txtAlteDrepturi.value =AlteDrepturi ;");
		eval("Form1." +ctrlID+"_txtAlteDrepturiNet.value =AlteDrepturiNet ;");
		eval("Form1." +ctrlID+"_txtAjutorDeces.value =AjutorDeces ;");
		
		eval("Form1." +ctrlID+"_txtAvans.value =Avans ;");
		eval("Form1." +ctrlID+"_txtRetineri1.value =Retinere1 ;");
		eval("Form1." +ctrlID+"_txtRetineri2.value =Retinere2 ;");
		eval("Form1." +ctrlID+"_txtRetineri3.value =Retinere3 ;");
		eval("Form1." +ctrlID+"_txtRetineri4.value =Retinere4 ;");
		eval("Form1." +ctrlID+"_txtRetineri5.value =Retinere5 ;");
		eval("Form1." +ctrlID+"_txtRetineri6.value =Retinere6 ;");
		eval("Form1." +ctrlID+"_txtRetineri7.value =Retinere7 ;");
		eval("Form1." +ctrlID+"_txtRegularizare.value =Regularizare ;");
		eval("Form1." +ctrlID+"_txtPrimaProiect.value =PrimaProiect ;");
		eval("Form1." +ctrlID+"_txtRetinereSanatate.value =RetinereSanatate ;");
		
		eval("Form1." +ctrlID+"_txtNrOreLucrateDelegatieInterna.value = NrOreLucrateDelegatieInterna ;");
		eval("Form1." +ctrlID+"_txtNrOreLucrateDelegatieExterna.value = NrOreLucrateDelegatieExterna ;");
		eval("Form1." +ctrlID+"_txtDiurnaImpozabila.value = DiurnaImpozabila ;");
		eval("Form1." +ctrlID+"_txtNrTichete.value = NrTichete ;");
		eval("Form1." +ctrlID+"_txtCorectiiTichete.value = CorectiiTichete ;");
		
		eval("Form1." +ctrlID+"_txtDrepturiInNatura.value = DrepturiInNatura ;");
		
		document.getElementById("trLichidareSeparator").style.display = "none";
		document.getElementById("trLichidare").style.display = "none";
		document.getElementById("trCOneefSeparator").style.display = "none";
		document.getElementById("trCOneef").style.display = "none";
		document.getElementById("trCOefectAvansSeparator").style.display = "none";
		document.getElementById("trCOefectAvans").style.display = "none";
		document.getElementById("trMedieZilnicaSeparator").style.display = "none";
		document.getElementById("trMedieZilnica").style.display = "none";
	}
		
	/*
		Functia este apelata cand angajatul nu este lichidat.
	*/
	function SelectSituatie(/*SituatieID,
							NrZileLuna,
							NrZileLucrateLuna,
							NrOreLucrate,
							NrOreSup50Proc,
							NrOreSup100Proc,
							NrOreEvenimDeoseb,
							NrOreInvoire,
							NrOreConcediuOdihna,
							NrOreConcediuBoala,
							NrOreCOncediuBoalaFirma,
							NrOreCOncediuBoalaBASS,
							NrOreObligatiiCetatenesti,
							NrOreAbsenteNemotivate,
							NrOreConcediuFaraPlata,
							NrOreTotalDelegatieInterna,
							NrOreLucrateDelegatieInterna,
							NrOreTotalDelegatieExterna,
							NrOreLucrateDelegatieExterna,
							NrOreEmergencyService,
							SporActivitatiSup,
							EmergencyService,
							PrimeSpeciale,
							AlteDrepturi,
							AlteDrepturiNet,
							AjutorDeces,
							Avans,
							Retinere1,
							Retinere2,
							Retinere3,
							Retinere4,
							Retinere5,
							Retinere6,
							Retinere7,
							Regularizare,
							PrimaProiect,
							ProgramLucru,
							SalariuBaza,
							IndemnizatieConducere,
							Invaliditate,
							CategorieID)*/
							
								SituatieID,
								NrOreLucrate,
								NrOreSup50Proc,
								NrOreSup100Proc,
								NrZileLuna,
								NrZileLucrateLuna,
								NrOreAbsenteNemotivate,
								NrOreConcediuBoala,
								NrOreConcediuBoalaBASS,
								NrOreConcediuBoalaFirma,
								NrOreConcediuFaraPlata,
								NrOreConcediuOdihna,
								NrOreEmergencyService,
								NrOreEvenimDeoseb,
								NrOreLucrateDelegatieExterna,
								NrOreTotalDelegatieExterna,
								NrOreLucrateDelegatieInterna,
								NrOreTotalDelegatieInterna,
								DiurnaImpozabila,
								NrOreInvoire,
								NrOreObligatiiCetatenesti,
								NrTichete,
								CorectiiTichete,
								NrTotalTichete,
								AlteDrepturi,	
								AlteDrepturiNet,
								AjutorDeces,
								Avans,
								EmergencyService,
								DrepturiInNatura,
								IndemnizatieConducere,
								PrimaProiect,
								PrimeSpeciale,
								Regularizare,
								SalariuBaza,
								SporActivitatiSup,
								RetinereSanatate,
								Retinere1, Retinere2, Retinere3, Retinere4, Retinere5, Retinere6, Retinere7,
								ProgramLucru,
								Nume,
								Denumire)
	{
		//Verficam daca este posibil sa se treaca in modul de editare
		if ( IsCurrentMonthActive == 1)
		{			
			eval("Form1."+ctrlID+"_txtSituatieID.value= SituatieID;");	
			tableListSit.style.display = "none";
			editButtonsLine.style.display = "";
			addButtonsLine.style.display = "none";
			tableAdaugaSit.style.display = "";
			completeFields(		NrZileLuna,
								NrOreLucrate,
								NrOreSup50Proc,
								NrOreSup100Proc,
								NrOreEvenimDeoseb,
								NrOreInvoire,
								NrOreConcediuOdihna,
								NrOreConcediuBoala,
								NrOreObligatiiCetatenesti,
								NrOreAbsenteNemotivate,
								NrOreConcediuFaraPlata,
								NrOreLucrateDelegatieInterna,
								NrOreLucrateDelegatieExterna,
								DiurnaImpozabila,
								NrTichete,
								CorectiiTichete,
								SporActivitatiSup,
								EmergencyService,
								PrimeSpeciale,
								AlteDrepturi,
								AlteDrepturiNet,
								AjutorDeces,
								Avans,
								Retinere1,
								Retinere2,
								Retinere3,
								Retinere4,
								Retinere5,
								Retinere6,
								Retinere7,
								Regularizare,
								PrimaProiect,
								RetinereSanatate,
								DrepturiInNatura);
					
			tdTextLine.innerText = "Editeaza situatia";		
		}
		else
		{
			alert("Luna este inchisa. Nu aveti dreptul de a modifica date!");
			
		}
	}
	
	/*
		Functie apelata in cazul in care angajatul este lichidat.
	*/
	function SelectSituatieLichidat(/*SituatieID,
							NrZileLuna,
							NrZileLucrateLuna,
							NrOreLucrate,
							NrOreSup50Proc,
							NrOreSup100Proc,
							NrOreEvenimDeoseb,
							NrOreInvoire,
							NrOreConcediuOdihna,
							NrZileConcediuOdihnaNeefectuat,
							NrZileConcediuOdihnaEfectuatInAvans,
							NrOreConcediuBoala,
							NrOreCOncediuBoalaFirma,
							NrOreCOncediuBoalaBASS,
							NrOreObligatiiCetatenesti,
							NrOreAbsenteNemotivate,
							NrOreConcediuFaraPlata,
							NrOreTotalDelegatieInterna,
							NrOreLucrateDelegatieInterna,
							NrOreTotalDelegatieExterna,
							NrOreLucrateDelegatieExterna,
							NrOreEmergencyService,
							SporActivitatiSup,
							EmergencyService,
							PrimeSpeciale,
							AlteDrepturi,
							AlteDrepturiNet,
							AjutorDeces,
							Avans,
							Retinere1,
							Retinere2,
							Retinere3,
							Retinere4,
							Retinere5,
							Retinere6,
							Retinere7,
							Regularizare,
							PrimaProiect,
							ProgramLucru,
							SalariuBaza,
							IndemnizatieConducere,
							Invaliditate,
							CategorieID)*/
								
							SituatieID,
							NrOreLucrate, 
							NrOreSup50Proc,
							NrOreSup100Proc,
							NrZileLuna,
							NrZileLucrateLuna,
							NrOreAbsenteNemotivate,
							NrOreConcediuBoala,
							NrOreConcediuBoalaBASS,
							NrOreConcediuBoalaFirma,
							NrOreConcediuFaraPlata,
							NrOreConcediuOdihna,
							NrZileConcediuOdihnaNeefectuat,
							NrZileConcediuOdihnaEfectuatInAvans,					
							NrOreEmergencyService,
							NrOreEvenimDeoseb,
							NrOreLucrateDelegatieExterna,
							NrOreTotalDelegatieExterna,
							NrOreLucrateDelegatieInterna,
							NrOreTotalDelegatieInterna,
							DiurnaImpozabila,
							NrOreInvoire,
							NrOreObligatiiCetatenesti,
							NrTichete,
							CorectiiTichete,
							NrTotalTichete,
							AlteDrepturi, 
							AlteDrepturiNet,
							AjutorDeces,
							Avans,
							EmergencyService,
							DrepturiInNatura,
							IndemnizatieConducere,
							PrimaProiect,
							PrimeSpeciale,
							Regularizare,
							SalariuBaza,
							SporActivitatiSup,
							RetinereSanatate, 
							Retinere1, Retinere2, Retinere3, Retinere4, Retinere5, Retinere6, Retinere7, 
							ProgramLucru,
							Nume,
							Denumire)
	{
		//Verficam daca este posibil sa se treaca in modul de editare
		if ( IsCurrentMonthActive == 1)
		{			
			eval("Form1."+ctrlID+"_txtSituatieID.value= SituatieID;");	
			tableListSit.style.display = "none";
			editButtonsLine.style.display = "";
			addButtonsLine.style.display = "none";
			tableAdaugaSit.style.display = "";

			completeFieldsLichidare
						(		NrZileLuna,
								NrOreLucrate,
								NrOreSup50Proc,
								NrOreSup100Proc,
								NrOreEvenimDeoseb,
								NrOreInvoire,
								NrOreConcediuOdihna,
								NrZileConcediuOdihnaNeefectuat,
								NrZileConcediuOdihnaEfectuatInAvans,
								NrOreConcediuBoala,
								NrOreObligatiiCetatenesti,
								NrOreAbsenteNemotivate,
								NrOreConcediuFaraPlata,
								NrOreLucrateDelegatieInterna,
								NrOreLucrateDelegatieExterna,
								DiurnaImpozabila,
								NrTichete,
								CorectiiTichete,
								SporActivitatiSup,
								EmergencyService,
								PrimeSpeciale,
								AlteDrepturi,
								AlteDrepturiNet,
								AjutorDeces,
								Avans,
								Retinere1,
								Retinere2,
								Retinere3,
								Retinere4,
								Retinere5,
								Retinere6,
								Retinere7,
								Regularizare,
								PrimaProiect,
								RetinereSanatate,
								DrepturiInNatura);
					
			tdTextLine.innerText = "Editeaza situatia";		
		}
		else
		{
			alert("Luna este inchisa. Nu aveti dreptul de a modifica date!");
			
		}
	}
	
	//Adaugat:		Oprescu Claudia
	//Descriere:	Daca se va da ENTER pe unul din controale trebuie sa se salveze situatia lunara a angajatului
	function keyPress(object, e)
	{
		var key = window.event ? e.keyCode : e.which;
		//daca s-a apasat ENTER se salveaza situatia lunara a angajatului 
		if (key == 13)
		{
			//se apeleaza metoda pentru modificarea situatiei lunare a angajatului
			ModificaSituatie();
		}
	}
	
</script>
<table border="0" cellSpacing="0" cellPadding="0" width="600" align="center">
	<tr>
		<td colSpan="3"><asp:literal id="litError" runat="server"></asp:literal></td>
	</tr>
	<tr>
		<td colSpan="2"><IMG src="../images/1x1.gif" height="10"></td>
	</tr>
	<tr>
		<td colSpan="2"><asp:table id="tableTabs" runat="server"></asp:table></td>
	</tr>
	<tr>
		<td id="tableListSit" height="100%" vAlign="top" colSpan="2" align="center"><asp:table id="listTable" runat="server"></asp:table>
			<P><INPUT id="modifica" class="ButtonStyle" value="Modifica" type="button" runat="server" NAME="modifica"></P>
		</td>
		<td id="tableAdaugaSit" colSpan="2" align="center">
			<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%" align="center" height="200">
				<tr>
					<td class="tabBackground">
						<TABLE border="0" cellSpacing="1" cellPadding="0" width="100%" align="center" height="100%">
							<tr>
								<td id="tdTextLine" class="HeaderGreenBold" colSpan="2" align="center">Adauga 
									situatie lunara</td>
							</tr>
							<TR>
								<TD style="HEIGHT: 18px" id="LunaContainer" class="NormalGreenBold" colSpan="2" runat="server"></TD>
								<TD style="HEIGHT: 18px" class="NormalGreenBold"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 18px" class="NormalGreenBold">Categorie Angajat</TD>
								<TD class="NormalGreenBold"><asp:label id="txtCategorie" runat="server" CssClass="NormalGreenBold">Label</asp:label></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr Ore Lucrate</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreLucrate" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="CompareValidator1" runat="server" CssClass="AlertRedBold" Display="Dynamic"
											Type="Double" Operator="DataTypeCheck" ControlToValidate="txtNrOreLucrate" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr Ore Sup 100 proc</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreSup50Proc" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator2" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtNrOreSup50Proc" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<tr id="trActiv" runat="server">
								<TD class="NormalGreenBold">Nr Ore Sup 200 proc</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreSup100Proc" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator3" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtNrOreSup100Proc" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</tr>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr Zile Luna</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrZileLuna" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><SPAN class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator11" runat="server" CssClass="AlertRedBold" Display="Dynamic"
											Type="Double" Operator="DataTypeCheck" ControlToValidate="txtNrZileLuna" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr Zile Absente Nemotivate</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreAbsenteNemotivate" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator13" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtNrOreAbsenteNemotivate" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr Zile Concediu Boala</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreConcediuBoala" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator6" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtNrOreConcediuBoala" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr Zile Concediu Fara Plata</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreConcediuFaraPlata" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator14" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtNrOreConcediuFaraPlata" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr Zile Concediu Odihna</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreConcediuOdihna" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator18" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtNrOreConcediuOdihna" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr id="trCOneefSeparator">
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR id="trCOneef">
								<TD class="NormalGreenBold">Nr Zile&nbsp;Concediu Odihna 
									Neefectuat&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrZileCOneefectuat" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:rangevalidator id="vldNrZileCOneefectuat" runat="server" CssClass="AlertRedBold" Type="Integer"
											ControlToValidate="txtNrZileCOneefectuat" ErrorMessage="Trebuie sa introduceti o corect numarul de zile de concediu de odihna neefectuat!"
											MaximumValue="40" MinimumValue="0"><</asp:rangevalidator></span></TD>
							</TR>
							<tr id="trCOefectAvansSeparator">
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR id="trCOefectAvans">
								<TD class="NormalGreenBold">Nr Zile Concediu Odihna Necuvenit</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrZileCOefectInAvans" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:rangevalidator id="vldNrZileCOefectInAvans" runat="server" CssClass="AlertRedBold" Type="Integer"
											ControlToValidate="txtNrZileCOefectInAvans" ErrorMessage="Trebuie sa completati corect numarul de zile de concediu de odihna necuvenit!"
											MaximumValue="40" MinimumValue="0"><</asp:rangevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr Zile Evenim Deosebite</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreEvenimDeoseb" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator4" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtNrOreEvenimDeoseb" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr Zile Lucrate Delegatie Interna</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreLucrateDelegatieInterna" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><SPAN class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator29" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtNrOreLucrateDelegatieInterna" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr Zile Lucrate Delegatie Externa</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreLucrateDelegatieExterna" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><SPAN class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator32" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtNrOreLucrateDelegatieExterna" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Diurna Impozabila</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtDiurnaImpozabila" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><SPAN class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator34" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtDiurnaImpozabila" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr Zile Invoire</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreInvoire" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator5" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtNrOreInvoire" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr Zile Obligatii 
									Cetatenesti&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrOreObligatiiCetatenesti" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator12" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtNrOreObligatiiCetatenesti" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Nr tichete</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtNrTichete" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator30" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtNrTichete" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Corectii tichete</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtCorectiiTichete" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator31" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtCorectiiTichete" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Alte Drepturi Brut</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtAlteDrepturi" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator10" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtAlteDrepturi" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Alte Drepturi Net</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtAlteDrepturiNet" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator19" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtAlteDrepturiNet" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator><asp:rangevalidator id="vldProc" runat="server" CssClass="AlertRedBold" Type="Double" ControlToValidate="txtAlteDrepturiNet"
											ErrorMessage="Suma pentru alte drepturi net trebuie sa fie o valoare pozitiva!" MaximumValue="2000000" MinimumValue="0"><</asp:rangevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Ajutor De Deces</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtAjutorDeces" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><SPAN class="CommentRedBold">*
										<asp:comparevalidator id="CompareValidator20" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtAjutorDeces" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Avans</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtAvans" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator15" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtAvans" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Emergency Service</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtEmergencyService" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator8" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtEmergencyService" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Drepturi in natura</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtDrepturiInNatura" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><SPAN class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator33" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtDrepturiInNatura" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Prima Proiect</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtPrimaProiect" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator17" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtPrimaProiect" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Prime Speciale</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtPrimeSpeciale" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator9" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtPrimeSpeciale" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Regularizare</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtRegularizare" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><SPAN class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator21" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtRegularizare" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></SPAN></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Spor Activitati 
									Suplimentare&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtSporActivitatiSup" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator7" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtSporActivitatiSup" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR>
								<TD class="NormalGreenBold">Retinere 
									Sanatate&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtRetinereSanatate" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator28" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtRetinereSanatate" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr>
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR style="DISPLAY: none" id="trRetineri1" runat="server">
								<TD class="NormalGreenBold"><asp:label id="lblRetineri1" runat="server" CssClass="NormalGreenBold"></asp:label></TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtRetineri1" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator16" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtRetineri1" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr style="DISPLAY: none" id="trSeparator1" runat="server">
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR style="DISPLAY: none" id="trRetineri2" runat="server">
								<TD class="NormalGreenBold"><asp:label id="lblRetineri2" runat="server" CssClass="NormalGreenBold"></asp:label></TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtRetineri2" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator22" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtRetineri2" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr style="DISPLAY: none" id="trSeparator2" runat="server">
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR style="DISPLAY: none" id="trRetineri3" runat="server">
								<TD class="NormalGreenBold"><asp:label id="lblRetineri3" runat="server" CssClass="NormalGreenBold"></asp:label></TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtRetineri3" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator23" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtRetineri3" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr style="DISPLAY: none" id="trSeparator3" runat="server">
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR style="DISPLAY: none" id="trRetineri4" runat="server">
								<TD class="NormalGreenBold"><asp:label id="lblRetineri4" runat="server" CssClass="NormalGreenBold"></asp:label></TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtRetineri4" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator24" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtRetineri4" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr style="DISPLAY: none" id="trSeparator4" runat="server">
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR style="DISPLAY: none" id="trRetineri5" runat="server">
								<TD class="NormalGreenBold"><asp:label id="lblRetineri5" runat="server" CssClass="NormalGreenBold"></asp:label></TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtRetineri5" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator25" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtRetineri5" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr style="DISPLAY: none" id="trSeparator5" runat="server">
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR style="DISPLAY: none" id="trRetineri6" runat="server">
								<TD class="NormalGreenBold"><asp:label id="lblRetineri6" runat="server" CssClass="NormalGreenBold"></asp:label></TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtRetineri6" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator26" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtRetineri6" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr style="DISPLAY: none" id="trSeparator6" runat="server">
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR style="DISPLAY: none" id="trRetineri7" runat="server">
								<TD class="NormalGreenBold"><asp:label id="lblRetineri7" runat="server" CssClass="NormalGreenBold"></asp:label></TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtRetineri7" onkeypress="keyPress(this, event)" runat="server" CssClass="NumericEditBoxuri">0</asp:textbox><span class="CommentRedBold">*
										<asp:comparevalidator id="Comparevalidator27" runat="server" CssClass="AlertRedBold" Type="Double" Operator="DataTypeCheck"
											ControlToValidate="txtRetineri7" ErrorMessage="Introduceti o valoare reala!"><</asp:comparevalidator></span></TD>
							</TR>
							<tr style="DISPLAY: none" id="trSeparator7" runat="server">
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR id="trMedieZilnica">
								<TD class="NormalGreenBold">Medie Zilnica&nbsp;CO</TD>
								<TD class="NormalGreenBold"><asp:textbox id="txtMedieZilnicaCO" runat="server" CssClass="NumericEditBoxuri" Enabled="False"></asp:textbox><span class="CommentRedBold"></span></TD>
							</TR>
							<tr id="trMedieZilnicaSeparator">
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
							<TR id="trLichidare">
								<TD class="NormalGreenBold">Lichidare</TD>
								<TD class="NormalGreenBold">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
							</TR>
							<tr id="trLichidareSeparator">
								<td class="GreenSeparator" colSpan="2"><IMG src="../images/1x1.gif" height="1"></td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<tr id="addButtonsLine">
					<td height="100%" align="center"><input id="buttonAdaugaSituatie" class="ButtonStyle" onmouseover="MouseOverButton(this)"
							onmouseout="MouseOutButton(this)" onclick="AdaugaSituatie()" value="  Salveaza situatia " type="button" runat="server" NAME="buttonAdaugaSituatie">
						<INPUT id="txtSituatieID" value="0" type="hidden" name="txtCoefID" runat="server">
					</td>
				<tr id="editButtonsLine">
					<td style="HEIGHT: 24px" align="center" height="24"><input class="ButtonStyle" id="buttonModificaSituatia" onmouseover="MouseOverButton(this)"
							onclick="ModificaSituatie()" onmouseout="MouseOutButton(this)" type="button" value="  Modifica situatia" runat="server" NAME="buttonModificaSituatia">&nbsp;&nbsp;&nbsp;
						<input class="ButtonStyle" id="btnInapoi" onmouseover="MouseOverButton(this)" onclick="tableAdaugaSit.style.display='none';tableListSit.style.display=''"
							onmouseout="MouseOutButton(this)" type="button" value="  Inapoi  ">
					</td>
				</tr>
				<tr>
					<td align="center"><asp:validationsummary id="ValidationSummary1" runat="server"></asp:validationsummary><input class="ButtonStyle" id="buttonStergeSituatia" onmouseover="MouseOverButton(this)"
							style="VISIBILITY: hidden" onclick="StergeSituatie" type="button" value="  Sterge situatia" runat="server" donmouseout="MouseOutButton(this)" NAME="buttonStergeSituatia"></td>
				</tr>
			</TABLE>
		</td>
	</tr>
</table>
<script>
	
	eval(ctrlID+"_tab1.click()");
</script>
