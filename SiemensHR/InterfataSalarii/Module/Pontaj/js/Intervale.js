var FormClientID = 'Form1';
var IntervaleID=[];
var IntervaleIndex=[];

var IntervaleAbsenteID = [];
var IntervaleAbsenteIndex = [];

function RegisterInterval(Interval)
{
//document.write( "^^^^^^:"+Interval.value );
IntervaleID[Interval.IntervalID]=Interval;
IntervaleIndex[IntervaleIndex.length]=Interval.IntervalID;
}

function getInterval(IntervalID)
{
//document.write( "%%%%%%:"+IntervaleID[IntervalID].value );
return IntervaleID[IntervalID];
}

function getObj(ID)
{
return document.getElementById(ID);
}

function CreateIntervalElement(IntervalID,OraStartID,OraEndID,TipIntervalID,hidden_IntervalID,CheckID)
{
//document.write( "@@@@@ intervale : "+IntervalID.value+"!!!!" );
this.CheckID = CheckID;
this.IntervalID = IntervalID;
this.hidden_IntervalID = hidden_IntervalID;
this.OraStartID = OraStartID;
this.OraEndID = OraEndID;
this.TipIntervalID = TipIntervalID;
this.OraStartChanged=OraStartChanged;
this.OraEndChanged=OraEndChanged;
this.OraStartKeyPressed = OraStartKeyPressed;
this.OraEndKeyPressed = OraEndKeyPressed;
this.getOraStart = getOraStart;
this.getOraEnd = getOraEnd;
this.getHiddenID = getHiddenID;
this.getTipInterval=getTipInterval;
this.getChecked=getChecked;
RegisterInterval(this);
}

var allowed="0123456789:";

var allowedAbsente = "0123456789.";

function getOraStart()
{
var OraStart = getObj(this.OraStartID).value;
//document.write( "^^^"+OraStart);

//document.getElementById( ClientOraStart ).value = OraStart;
document.getElementById( ClientOraStart ).value = document.getElementById( OraSt ).value;

return OraStart;
}
function getOraEnd()
{
var OraEnd = getObj(this.OraEndID).value;

//document.write( document.getElementById( OraSf ).value );
//document.getElementById( ClientOraEnd ).value = OraEnd;
document.getElementById( ClientOraEnd ).value = document.getElementById( OraSf ).value;

return OraEnd;
}
function getHiddenID()
{
var hiddenID = getObj(this.hidden_IntervalID).value;

document.getElementById( ClientIntervalID ).value = document.getElementById( IntervID ).value;
//document.getElementById( ClientIntervalID ).value = hiddenID;

return hiddenID;
}
function getTipInterval()
{
var tip = getObj(this.TipIntervalID).value;

//document.getElementById( ClientTipInterval ).value = tip;
document.getElementById( ClientTipInterval ).value = document.getElementById( TipInterv ).value;

return tip;
}

function getChecked()
{
var checked = getObj(this.CheckID).checked;

return checked;
}

function hasSeparator(ora)
{
return ora.indexOf(":")>=0;
}
function nrSeparator(ora)
{
var nr=0;
for (var i=0;i<ora.length;i++)
{
if (ora.charAt(i)==":") nr++;
}

return nr;
}


function getOra(ora)
{

if (ora.indexOf(":")==-1) return ora; else return ora.substr(0,ora.indexOf(":"));
}
function getMinute(ora)
{

if (ora.indexOf(":")==-1) return ""; else return ora.substr(ora.indexOf(":")+1,ora.length);
}


function HandleOraChanged(obj)
{

var ok = false;

var value = obj.value;




if (value.length>0)
{

	ok=true;
	for(var i=0;i<value.length;i++)
	{

	var pos = allowed.indexOf(value.charAt(i));
	
	ok = ok && (pos>=0);
	}

}


if (!ok) ErrorMsg(obj); else
{
	
	if (value.length==1)
	{
	obj.value="0"+value+":00";
	} else
	if (value.length==2)
	{
	obj.value+=":00";
	}
	else
	if (value.length==3)
	{
	obj.value+="00";
	} else
	if (value.length>3)
	{
	
	var minutes = value.substr(3,5);
	if (minutes>59) minutes=59;
	if (minutes.length<2) minutes="0"+minutes;
	obj.value=value.substr(0,3)+minutes;

	}
	
	
	if (!hasSeparator(value)&& value.length<=2) obj.value+=":00"; else
	if (value.indexOf(":")<2) obj.value="0"+value;
	
	if (value.indexOf(":")>0 && value.lastIndexOf(":") > value.indexOf(":")) obj.value="00:00";
	
	if (getOra(value).length==0) obj.value="00"+value;
	if (nrSeparator(value)>1) obj.value="00:00";
	if (getOra(value)>24) obj.value="24"+value.substr(2,value.length);
	if (!hasSeparator(value)) obj.value =value.substr(0,2)+":"+value.substr(3,5);
}

}

function HandleOraPressed(obj)
{
	var value=obj.value;


	if (value.length==1)
	{
		if (value.charAt(value.length-1)==":") 
			obj.value="";
	}
	else if (value.length==2)
	{
		if ( value.charAt(value.length-1) == ":") 
			obj.value="0"+value.charAt(0)+":";
		if (value>=24) 
		{
			obj.value = value%24+":";
			HandleOraPressed( obj );
		}
	}
	else if (value.length==3)
	{
		if (value.indexOf(":")==-1)
			obj.value = value.substr(0,value.length-1)+":"+value.charAt( 2 );
	}
	else if (value.length>3)
	{
		if (value.charAt(value.length-1) == ":") 
			obj.value = value.substr(0,value.length-1);

	}

	if (value.charAt(value.length-1)==":" && value.indexOf(":")<value.length-1) 
		obj.value=value.substr(0,value.length-1);


	//if (value.length==2) obj.value+=":";


	var ora = getOra(value);
	var minute = getMinute(value);
}

function ErrorMsg(obj)
{

var MsgEmpty="Campul ora nu poate fi gol ! Va rugam completati acest camp.";
var MsgSyntax="Campul ora poate contine doar cifre (0-9) si delimitatorul : !";

if (obj.value.length==0) alert(MsgEmpty); else alert(MsgSyntax);
obj.value="";

}
function OraStartChanged()
{
//document.write( "$$$$$"+this.OraStartID+"%%%%" );
//document.write( "$$$$$"+document.getElementById( this.OraStartID ).value+"%%%%" );
var objOraStart = getObj(this.OraStartID);
var okOraStart = HandleOraChanged(objOraStart);

}
function OraEndChanged()
{
var objOraEnd = getObj(this.OraEndID);
var okOraEnd = HandleOraChanged(objOraEnd);

}

function OraStartKeyPressed()
{

var objOraStart = getObj(this.OraStartID);
HandleOraPressed(objOraStart);

}
function OraEndKeyPressed()
{

var objOraEnd = getObj(this.OraEndID);
HandleOraPressed(objOraEnd);

}


function containsElement(a,e)
{
for (var i=0;i<a.length;i++)
{
if (a[i]==e) return true;
}
return false;
}



function Compare(Ora1,Ora2)
{

//0 - Ora1 == Ora2,  1 - Ora1>Ora2 , 2 Ora1 <Ora 2

var ora1 = getOra(Ora1);
var minute1 = getMinute(Ora1);
var ora2 = getOra(Ora2);
var minute2 = getMinute(Ora2);

if (Ora1==Ora2) return 0; 

else
	
	{	

	if (ora1>ora2) return 1; 
	
	else

		if (ora1==ora2)
		{
			
			if (minute1>minute2) return 1 ; else return 2;
		} 
		
		else return 2;
	}
}

function Ge(Ora1,Ora2)
{
	return (Compare(Ora1,Ora2)==1) || (Compare(Ora1,Ora2)==0);
}

function Gt(Ora1,Ora2)
{
	return (Compare(Ora1,Ora2)==1);
}


function Le(Ora1,Ora2)
{
	return (Compare(Ora1,Ora2)==2) || (Compare(Ora1,Ora2)==0);
}

function Eq(Ora1,Ora2)
{
	return (Compare(Ora1,Ora2)==0);
}

function canSwitch(o1,o1_id,o2,o2_id)
{

var objInterval1 = getInterval(o1_id);
var objInterval2 = getInterval(o2_id);


var ok1 = objInterval1.getOraEnd()==o1;
var ok2 = objInterval2.getOraStart()==o2;


return !(ok1&&ok2);
}

function okSyntaxOra(value)
{
var ok = false;

if (value.length>0)
{
	ok=true;

	for(var i=0;i<value.length;i++)
	{

	var pos = allowed.indexOf(value.charAt(i));
	
	ok = ok && (pos>=0);
	}
}

return ok;
}


function handleInterval(objInterval)
{


var OraStart = objInterval.getOraStart();
var OraEnd = objInterval.getOraEnd();

if (OraStart>=OraEnd)
{
getObj(objInterval.OraEndID).value="";
}
var okInterval = okSyntaxOra(OraStart) && okSyntaxOra(OraEnd);

return okInterval;

}


function checkIntervale(IndexOfIntervale)
{

var OkIntervale = true;
var ErrMsg = "";

for (var i=0;i<IndexOfIntervale-1;i++)
{
var objInterval = IntervaleID[IntervaleIndex[i]];
OkIntervale = OkIntervale && handleInterval(objInterval);
}

if (! OkIntervale) ErrMsg = 'Exista intervale necompletate sau cu format necorespunzator (HH:mm).'; else

{

var tmpStart=[];
var tmpEnd=[];

var OkStart = true;
var OkEnd = true;

var tmpOre=[];
var tmpOreID=[];



for (var i=0;i<IndexOfIntervale-1;i++)
{

var objInterval = IntervaleID[IntervaleIndex[i]];

var OraStart = getObj(objInterval.OraStartID).value;
var OraEnd = getObj(objInterval.OraEndID).value;


tmpOre[tmpOre.length]=OraStart;
tmpOre[tmpOre.length]=OraEnd;



tmpOreID[tmpOreID.length]=objInterval.IntervalID;
tmpOreID[tmpOreID.length]=objInterval.IntervalID;


OkStart = OkStart && !containsElement(tmpStart,OraStart);
OkEnd = OkEnd && !containsElement(tmpEnd,OraEnd);

tmpStart[tmpStart.length]=OraStart;
tmpEnd[tmpEnd.length]=OraEnd;
}

OkIntervale = OkStart && OkEnd;

if  (!OkIntervale)	ErrMsg = ' Exista intervale de timp ale caror ore de start / sfarsit  coincid !'; else

{

var Flag = true;
while (Flag)
{
	Flag = false;

	for (var i=0;i<tmpOre.length-1;i++)
	{

		var e1 = tmpOre[i];
		var e2 = tmpOre[i+1];

		var e1_id = tmpOreID[i];
		var e2_id = tmpOreID[i+1];

		
		if ( Gt(e1,e2) || (Eq(e1,e2) && canSwitch(e1,e1_id,e2,e2_id)))
		{

		var aux = e2;
		e2 = e1;
		e1 = aux;
		tmpOre[i]=e1;
		tmpOre[i+1]=e2;
		
		var aux = e2_id;
		e2_id = e1_id;
		e1_id = aux;
		tmpOreID[i]=e1_id;
		tmpOreID[i+1]=e2_id;
		
		
		
		Flag = true;
		}
	} // for

}// while


	var s ="";
	var s_id="";
	
	var okDisjuncte = true;
	
	var k =0;
	for (var i=0;i<tmpOre.length/2;i++)
	{
	k=k+2;
	okDisjuncte = okDisjuncte && (tmpOreID[k]==tmpOreID[k+1]);
	}

	if (!okDisjuncte) ErrMsg = 'Intervalele de timp specificate nu sunt disjuncte !';


	OkIntervale = OkIntervale && okDisjuncte;

} //******************** verificare intervale disjuncte

}


if (!OkIntervale) alert(ErrMsg);
return OkIntervale;

}


function CheckIntervaleToSave()
{
return checkIntervale(IntervaleIndex.length);
}

function CheckIntervaleToAdd()
{
return checkIntervale(IntervaleIndex.length+1);
}

/*
*	Adaugat:	Oprescu Claudia
*	Data:		22.02.2007
*	Descriere:	Metoda determina numarul de zile lucratoare ale intervalelor de CO din luna activa
*/
function NrZileCOPeLunaActiva()
{
	nrZileConcediuNou = 0;
	//se parcurg toate intervalele de pe interfata, inclusiv cel nou care se adauga (in caz de adaugare)
	for( var i=0; i<IntervaleAbsenteIndex.length; i++ )
	{
		//se obtine un interval
		var objInterval = IntervaleAbsenteID[ IntervaleAbsenteIndex[ i ]];
		//se obtine tipul intervalului de absenta
		var tipIntervalAbsente = objInterval.getTipIntervalAbsente();
		//se determina ziua de inceput a intervalului
		var ziStart = objInterval.getDataStart().split('.')[0];
		//se determina ziua de sfarsit a intervalului
		var ziEnd = objInterval.getDataEnd().split('.')[0];		
		
		//tipul absentei trebuie sa fie concediu de odihna 
		if (tipIntervalAbsente == concediuOdihnaID)
		{
			//pentru fiecare zi a lunii din intervalul anterior
			for (j=ziStart; j<=ziEnd; j++)
			{
				//se presupune ca nu e sarbatoare
				var nuESarbatoare = false;
				//se parcurge sirul cu sarbatori pe luna respectiva, inclusiv sambata si duminica
				for (l=0; l<zileSarbatoare.length; l++)
				{
					//daca ziua este o zi de sarbatoare
					if (zileSarbatoare[l] == j)
					{
						nuESarbatoare = true;
						break;
					}
				}
				//daca nu este sarbatoare
				if (nuESarbatoare)
				{
					//se aduna la zilele lucratoare existente
					nrZileConcediuNou++;
				}
			}
		}
	}
	//se returneaza numarul de zile lucratoare ale intervalelor existente in luna activa
	return nrZileConcediuNou;
}

/*
*	Modificat:		Oprescu Claudia
*	Data:			22.02.2007
*	Descriere:		Daca se depaseste numarul de zile de CO permise unui angajat, se mai pot adauga alte zile de CO numai 
*					dupa confirmarea utilizatorului.
*/
function SubmitAdd()
{
	if( document.getElementById( ClientTipPontajHidden ).value == "lucru" )
	{
		SubmitAddInterval();
	}
	else 
	{
		//daca s-au specficicat absente
		if( document.getElementById( ClientTipPontajHidden ).value == "absente" )
		{	
			//se obtine noul interval
			var objInterval = IntervaleAbsenteID[ IntervaleAbsenteIndex[ IntervaleAbsenteIndex.length - 1 ]];
			//se obtine tipul intervalului de absenta
			var tipIntervalAbsente = objInterval.getTipIntervalAbsente();
			
			//tipul absentei trebuie sa fie concediu de odihna 
			if (tipIntervalAbsente == concediuOdihnaID)
			{
				//se determina numarul de zile lucratoare de CO luate in luna activa
				nrZileConcediuNou = NrZileCOPeLunaActiva();						
				//	nr de zile disponibile pentru angajat + nr de zile suplimentare de CO >= 
				//	nr de zile luate pe anul curent pana la luna activa + nr de zile de CO luate in luna activa
				if (nrZileDisponibile + nrZileCOSupl < nrZileLuateAn + nrZileConcediuNou)
				{ 
					//daca a fost depasit numarul de zile de CO permise angajatului
					//se vor putea introduce alte intervale numai in urma confirmarii utilizatorului
					if (confirm('Concediul de odihna introdus duce la depasirea numarului de zile de concediu de odihna alocate pe an!!! Sunteti sigur ca doriti sa efectuati introducerea acestuia?')) 
					{ 
						SubmitAddAbsente();
					}
				}
				else
				{
					SubmitAddAbsente();
				}
			}
			else
			{
				SubmitAddAbsente();
			}
		}
		else 
		{
			if( document.getElementById( ClientTipPontajHidden ).value == "intreruperi" )
			{
				SubmitAddIntreruperi();
			}
		}
	}
}

function SubmitAddInterval()
{
	if (CheckIntervaleToAdd())
	{
		document.getElementById(ActionIntervaleID).value="addInterval";
		document.getElementById(FormClientID).submit();
	}
}

/*
*	Modificat:		Oprescu Claudia
*	Data:			22.02.2007
*	Descriere:		Daca se depaseste numarul de zile de CO permise unui angajat, se mai pot adauga alte zile de CO numai 
*					dupa confirmarea utilizatorului.
*/
function SubmitSave()
{
	if( document.getElementById( ClientTipPontajHidden ).value == "lucru" )
	{
		SubmitSaveInterval();
	}
	else 
	{
		//daca s-au specficicat absente
		if( document.getElementById( ClientTipPontajHidden ).value == "absente" )
		{		
			//se determina numarul de zile lucratoare de CO luate in luna activa
			nrZileConcediuNou = NrZileCOPeLunaActiva();	
			//	nr de zile disponibile pentru angajat + nr de zile suplimentare de CO >= 
			//	nr de zile luate pe anul curent pana la luna activa + nr de zile de CO luate in luna activa		
			if (nrZileDisponibile + nrZileCOSupl < nrZileLuateAn + nrZileConcediuNou)
			{ 
				//daca a fost depasit numarul de zile de CO permise angajatului
				//se vor putea introduce alte intervale numai in urma confirmarii utilizatorului
				if (confirm('Concediul de odihna introdus duce la depasirea numarului de zile de concediu de odihna alocate pe an!!! Sunteti sigur ca doriti sa efectuati introducerea acestuia?')) 
				{ 
					SubmitSaveAbsente();
				}
			}
			else
			{
				SubmitSaveAbsente();
			}
		}
		else
		{ 
			if( document.getElementById( ClientTipPontajHidden ).value == "intreruperi" )
			{
				SubmitSaveIntreruperi();
			}
		}
	}
	 
	//alert(document.getElementById( ClientTipPontajHidden ).value);
	/*if( document.getElementById( ClientTipPontajHidden ).value == "lucru" )
		SubmitSaveInterval();
	else if( document.getElementById( ClientTipPontajHidden ).value == "absente" )
		SubmitSaveAbsente();
	else if( document.getElementById( ClientTipPontajHidden ).value == "intreruperi" )
		SubmitSaveIntreruperi();*/
}

function SubmitSaveInterval()
{
	//pt cerintele noi
	//alert( "###"+document.getElementById(IntervaleSaveInfoID).value+"###" );
	document.getElementById(ActionIntervaleID).value="saveIntervale";
	document.getElementById(FormClientID).submit();
}

function NrOreSuplimentare_Changed( tipIntervalID, txtNrOreSuplimentare )
{
	var intervaleOreSup = "";
	for( var i=0; i<dateOreSuplimentare[ 0 ].length; i++ )
	{
		if( dateOreSuplimentare[ 0 ][ i ] == tipIntervalID )
		{
			dateOreSuplimentare[ 2 ][ i ] = txtNrOreSuplimentare.value;
		}
		intervaleOreSup += dateOreSuplimentare[ 0 ][ i ]+"|"+dateOreSuplimentare[ 2 ][ i ]+"|"+dateOreSuplimentare[ 1 ][ i ];
		if( i<dateOreSuplimentare[ 0 ].length-1 )
		{
			intervaleOreSup += ";";
		}
	}
	document.getElementById(IntervaleSaveInfoID).value = "";
	document.getElementById(IntervaleSaveInfoID).value = intervaleOreSup;
	
}

function SubmitDeleteSelected()
{
	if( document.getElementById( ClientTipPontajHidden ).value == "lucru" )
		SubmitDeleteSelectedInterval();
	else if( document.getElementById( ClientTipPontajHidden ).value == "absente" )
		SubmitDeleteSelectedAbsente();
	else if( document.getElementById( ClientTipPontajHidden ).value == "intreruperi" )
		SubmitDeleteSelectedIntreruperi();
}

function SubmitDeleteSelectedInterval()
{
	//document.write( "#####"+IntervaleIndex.length );

	document.getElementById(IntervaleSaveInfoID).value="";
	
	for (var i=0;i<IntervaleIndex.length-1;i++)
	{
		var objInterval = IntervaleID[IntervaleIndex[i]];
	
		if (objInterval.getChecked())
		{
		var aux = objInterval.getHiddenID()+";";
		document.getElementById(IntervaleSaveInfoID).value+=aux;
		}
	}
	
	if (document.getElementById(IntervaleSaveInfoID).value!="")
	{
	
	document.getElementById(ActionIntervaleID).value="deleteIntervaleSelectate";
	if (confirm('Confirmati stergerea intervalelor.')) document.getElementById(FormClientID).submit();
	}
}
//*************************** Day Selection

function SelectZiLuna(zi)
{
document.getElementById(ClientSelectedDateID).value=zi;
document.getElementById(FormClientID).submit();

}


//*****************************************************************************
//*                                 Dovlecel Vlad                             *
//*                                  - ABSENTE -                              *
//*****************************************************************************
function SubmitTipPontaj()
{
	document.getElementById(ActionIntervaleID).value="";
	document.getElementById( ClientTipPontajHidden ).value = document.getElementById( ClientTipPontaj ).value;
	document.getElementById( FormClientID ).submit();
}


function RegisterIntervalAbsente( Interval )
{
	//document.write( "@@@@@@:"+Interval.value );
	IntervaleAbsenteID[ Interval.IntervalAbsenteID ] = Interval;
	IntervaleAbsenteIndex[ IntervaleAbsenteIndex.length ] = Interval.IntervalAbsenteID;
}

function getIntervalAbsente( IntervalID )
{
	//document.write( "#####:"+IntervalID+"!!!!!" );
	//document.write( "$$$$$$:"+IntervaleAbsenteID[ IntervalID ] );
	return IntervaleAbsenteID[ IntervalID ];
}

//Oprescu Claudia
//Descriere: S-au adaugat campuri si pentru serie si numar
function CreateIntervalAbsenteElement( IntervalAbsenteID, DataStartID, DataEndID, TipIntervalAbsenteID, TipBoalaAbsenteID, hidden_IntervalAbsenteID, CheckAbsenteID, ObservatiiID, MedieZilnica, Serie, Numar, CertificatInitial, SerieCertificat, NumarCertificat, DataAcordarii,  CnpCopil, LocPrescriere, CodUrgenta, NrAvizMedic)
{
	//debugger;
	//document.write( "##### absente : "+document.getElementById( IntervalAbsenteID ).value+"!!!!!" );
	//document.write( "####1:"+IntervalAbsenteID+"####2:"+DataStartID+"####3:"+DataEndID+"####4:"+TipIntervalAbsenteID+"####5:"+TipBoalaAbsenteID+"####6:"+hidden_IntervalAbsenteID+"####7:"+CheckAbsenteID+"@@@" );
	this.CheckAbsenteID = CheckAbsenteID;
	this.IntervalAbsenteID = IntervalAbsenteID;
	this.hidden_IntervalAbsenteID = hidden_IntervalAbsenteID;
	this.DataStartID = DataStartID;
	this.DataEndID = DataEndID;
	this.TipIntervalAbsenteID = TipIntervalAbsenteID;
	this.TipBoalaAbsenteID = TipBoalaAbsenteID;
	this.ObservatiiID = ObservatiiID;
	this.MedieZilnica = MedieZilnica;
	this.Serie = Serie;
	this.Numar = Numar;
	//----------------Daniela Chiperescu 22.02.2011--------
	this.CertificatInitial = CertificatInitial;
	this.SerieCertificat = SerieCertificat;
	this.NumarCertificat = NumarCertificat;
	this.DataAcordarii = DataAcordarii;
	this.CnpCopil = CnpCopil;
	this.LocPrescriere = LocPrescriere;
	this.CodUrgenta= CodUrgenta;
	this.NrAvizMedic = NrAvizMedic;
	//----------------Daniela Chiperescu 22.02.2011--------
	
	
	this.DataStartChanged = DataStartChanged;
	this.DataEndChanged = DataEndChanged;
	this.DataEndIntrerupereChanged = DataEndIntrerupereChanged;
	this.DataStartKeyPressed = DataStartKeyPressed;
	this.DataEndKeyPressed = DataEndKeyPressed;
	this.ObservatiiChanged = ObservatiiChanged;
	this.MedieZilnicaChanged = MedieZilnicaChanged;
	this.SerieChanged = SerieChanged;
	this.NumarChanged = NumarChanged;
	//----------------Daniela Chiperescu 22.02.2011--------
	this.DataAcordariiKeyPressed = DataAcordariiKeyPressed;
	this.CertificatInitialChanged = CertificatInitialChanged;
	this.SerieCertificatChanged = SerieCertificatChanged;
	this.NumarCertificatChanged = NumarCertificatChanged;
	this.DataAcordariiChanged = DataAcordariiChanged;
	this.CnpCopilChanged = CnpCopilChanged;
	this.LocPrescriereChanged = LocPrescriereChanged;
	this.CodUrgentaChanged = CodUrgentaChanged;
	this.NrAvizMedicChanged = NrAvizMedicChanged;
	//----------------Daniela Chiperescu 22.02.2011--------
	
	this.getNumeIntervalAbsenta = getNumeIntervalAbsenta;
	this.getDataStart = getDataStart;
	this.getDataEnd = getDataEnd;
	this.getObservatii = getObservatii;
	this.getMedieZilnica = getMedieZilnica;
	this.getSerie = getSerie;
	this.getNumar = getNumar;
	//----------------Daniela Chiperescu 22.02.2011--------
	this.getCertificatInitial = getCertificatInitial;
	this.getNumarCertificat = getNumarCertificat;
	this.getSerieCertificat = getSerieCertificat;
	this.getDataAcordarii = getDataAcordarii;
	this.getCnpCopil = getCnpCopil;
	this.getLocPrescriere = getLocPrescriere;
	this.getCodUrgenta = getCodUrgenta;
	this.getNrAvizMedic= getNrAvizMedic;
	//----------------Daniela Chiperescu 22.02.2011--------
	this.getHiddenAbsenteID = getHiddenAbsenteID;
	this.getTipIntervalAbsente = getTipIntervalAbsente;
	this.getTipBoalaAbsente = getTipBoalaAbsente;
	this.getCheckedAbsente = getCheckedAbsente;
	
	RegisterIntervalAbsente(this);
}

//var allowed="0123456789:";

function getDataStart()
{
	var DataStart = getObj(this.DataStartID).value;
	//document.write( "^^^"+OraStart);

	//document.getElementById( ClientOraStart ).value = OraStart;
	document.getElementById( ClientDataStart ).value = document.getElementById( DataSt ).value;

	return DataStart;
}

function getDataEnd()
{
	var DataEnd = getObj(this.DataEndID).value;

	//document.write( document.getElementById( OraSf ).value );
	//document.getElementById( ClientOraEnd ).value = OraEnd;
	document.getElementById( ClientDataEnd ).value = document.getElementById( DataSf ).value;

	return DataEnd;
}

function getObservatii()
{
	var obs = getObj( this.ObservatiiID ).value;
	//document.write( "^^^"+OraStart);

	//document.getElementById( ClientOraStart ).value = OraStart;
	document.getElementById( ClientObservatiiID ).value = document.getElementById( ObservatiiID1 ).value;

	return obs;
}

function getMedieZilnica()
{
	var obs = getObj( this.MedieZilnica ).value;
	//document.write( "^^^"+OraStart);
	
	//document.getElementById( ClientOraStart ).value = OraStart;
	document.getElementById( ClientMedieZilnica ).value = document.getElementById( MedieZilnica1 ).value;
	
	return obs;
}

//Oprescu Claudia
//se retine in campul ascuns valoarea campului serie introdusa pe interfata
function getSerie()
{
	var obs = getObj( this.Serie ).value;
	document.getElementById( txtSerieHidden ).value = document.getElementById( txtSerie ).value;
	return obs;
}

//Oprescu Claudia
//se retine in campul ascuns valoarea campului numar introdusa pe interfata
function getNumar()
{
	var obs = getObj( this.Numar ).value;
	document.getElementById( txtNumarHidden ).value = document.getElementById( txtNumar ).value;
	return obs;
}
//-----------Daniela Chiperescu 22.02.2011---------------
function getNumarCertificat()
{
	var obs = getObj( this.NumarCertificat ).value;
	document.getElementById( txtNumarCertificatHidden ).value = document.getElementById( txtNumarCertificat ).value;
	return obs;
}
function NumarCertificatChanged()
{
	var obs = getObj( this.NumarCertificat ).value;
	document.getElementById( txtNumarCertificatHidden ).value = document.getElementById( txtNumarCertificat ).value;
}

function getSerieCertificat()
{
	var obs = getObj( this.SerieCertificat ).value;
	document.getElementById( txtSerieCertificatHidden ).value = document.getElementById( txtSerieCertificat ).value;
	return obs;
}
function SerieCertificatChanged()
{
	var obs = getObj( this.SerieCertificat ).value;
	document.getElementById( txtSerieCertificatHidden ).value = document.getElementById( txtSerieCertificat ).value;
}

function getCertificatInitial()
{
	var obs = getObj( this.CertificatInitial ).value;
	document.getElementById( txtCertificatInitialHidden ).value = document.getElementById( txtCertificatInitial ).value;
	return obs;
}
function CertificatInitialChanged()
{
	var obs = getObj( this.CertificatInitial ).value;
	document.getElementById( txtCertificatInitialHidden ).value = document.getElementById( txtCertificatInitial).value;
}
function getDataAcordarii()
{
	var obs = getObj( this.DataAcordarii ).value;
	document.getElementById( txtDataAcordariiCertificatHidden ).value = document.getElementById( txtDataAcordariiCertificat ).value;
	return obs;
}
function DataAcordariiChanged()
{
	var obs = getObj( this.DataAcordarii );
	document.getElementById( txtDataAcordariiCertificatHidden ).value = document.getElementById( txtDataAcordariiCertificat ).value;
	var okData = HandleDataChanged( obs );
}
function getLocPrescriere()
{
	var obs = getObj( this.LocPrescriere ).value;
	document.getElementById( txtLocPrescriereCertificatHidden ).value = document.getElementById( txtLocPrescriereCertificat ).value;
	return obs;
}
function LocPrescriereChanged()
{
	var obs = getObj( this.LocPrescriere ).value;
	document.getElementById( txtLocPrescriereCertificatHidden ).value = document.getElementById( txtLocPrescriereCertificat ).value;
}
function getCodUrgenta()
{
	var obs = getObj( this.CodUrgenta ).value;
	document.getElementById( txtCodUrgentaHidden ).value = document.getElementById( txtCodUrgenta ).value;
	return obs;
}
function CodUrgentaChanged()
{
	var obs = getObj( this.CodUrgenta ).value;
	document.getElementById( txtCodUrgentaHidden ).value = document.getElementById( txtCodUrgenta ).value;
}
function getNrAvizMedic()
{
	var obs = getObj( this.NrAvizMedic ).value;
	document.getElementById( txtNrAvizMedicExpertHidden ).value = document.getElementById( txtNrAvizMedicExpert ).value;
	return obs;
}
function NrAvizMedicChanged()
{
	var obs = getObj( this.NrAvizMedic ).value;
	document.getElementById( txtNrAvizMedicExpertHidden ).value = document.getElementById( txtNrAvizMedicExpert ).value;
}
function getCnpCopil()
{
	var obs = getObj( this.CnpCopil ).value;
	document.getElementById( txtCnpCopilHidden ).value = document.getElementById( txtCnpCopil ).value;
	return obs;
}
function CnpCopilChanged()
{
	var obs = getObj( this.CnpCopil ).value;
	document.getElementById( txtCnpCopilHidden ).value = document.getElementById( txtCnpCopil ).value;
}
//-----------Daniela Chiperescu 22.02.2011---------------
function getHiddenAbsenteID()
{
	var hiddenID = getObj(this.hidden_IntervalAbsenteID).value;

	document.getElementById( ClientIntervalAbsenteID ).value = document.getElementById( IntervAbsenteID ).value;
	//document.getElementById( ClientIntervalID ).value = hiddenID;

	return hiddenID;
}

function getTipIntervalAbsente()
{
	//document.write( this.TipIntervalAbsentaID );
	var tip = getObj(this.TipIntervalAbsenteID).value;

	//document.getElementById( ClientTipInterval ).value = tip;
	//VerificaVizibilitateBoala();	
	document.getElementById( ClientTipIntervalAbsente ).value = document.getElementById( TipIntervAbsente ).value;

	return tip;
}
function getNumeIntervalAbsenta()
{
var obj = getObj(this.TipIntervalAbsenteID);

return obj.options[obj.selectedIndex].text;
}

function getTipBoalaAbsente()
{
	var tip = getObj(this.TipBoalaAbsenteID).value;

	//document.getElementById( ClientTipInterval ).value = tip;
	//VerificaVizibilitateBoala();	
	document.getElementById( ClientTipBoalaAbsente ).value = document.getElementById( TipIntervBoala ).value;
	return tip;
}

function VerificaVizibilitateBoala()
{
	//document.write( TipAbsenteMedical.length );
	document.getElementById( ClientNomenclatorBoliVisible ).value = "0";
	
	for( var i=0; i<TipAbsenteMedical.length; i++ )
	{
		if( TipAbsenteMedical[ i ] == document.getElementById( TipIntervAbsente ).value )
		{
			document.getElementById( ClientNomenclatorBoliVisible ).value = "1";
			document.getElementById( FormClientID ).submit();
			return;
		}
	}
}

function getCheckedAbsente()
{
	var checked = getObj(this.CheckAbsenteID).checked;

	return checked;
}

//!! Aceste variabile trebuie setate de pe server pentru validarea intervalelor de tip absenta

var AngajareDataStart;
var LunaActivaDataStart;
var DataLichidare;
var zileInLuna = new Array();

var zileInLuna;

/*
 Autor:    Cristina Raluca Muntean
 Data:     12.06.2006
 Descriere:Returneaza numarul de zile al lunii februarie pentru anul trimis ca parametru. 
*/
function NrZileInFebruarie(an)
{
	// Luna februarie poate sa aiba 28 sau 29 de zile in functie de tipul anului.
	// In cazul in care anul este bisect, ferbruarie va avea 29 de zile, altfel 28.
    return (((an % 4 == 0) && ( (!(an % 100 == 0)) || (an % 400 == 0))) ? 29 : 28 );
}

/*
 Autor:    Cristina Raluca Muntean
 Data:     12.06.2006
 Descriere:Se completeaza un sir cu numarul de zile corespunzator fiecarei luni. 
*/
function NrZilePeLuna() 
{
	for (var i = 1; i <= 12; i++) 
	{
		if (i==4 || i==6 || i==9 || i==11) 
		{
			zileInLuna[i] = 30;
		}
		else
		{
			if (i==2)
 			{
				zileInLuna[i] = 29;
			}
			else
			{
				zileInLuna[i] = 31;
			}
		}
   	}
}

function HandleDataChanged( obj )
{
	var ok = false;
	var value = obj.value;
	
	if(zileInLuna.length == 0)
	{
		NrZilePeLuna();
	}

	if( value.length>0 )
	{
		ok = true;
		for( var i=0; i<value.length; i++ )
		{
			var pos = allowedAbsente.indexOf( value.charAt( i ));
			ok = ok && ( pos>=0 );
		}
		if (ok)
		{
			nr=0;
			for( var i=0; i<value.length; i++ )
			{
				if (value.charAt( i ) ==".") nr++;
			}
			ok = (nr==2);
		}
		if (ok)
		{
			var zi = getZiAbsenta(value);
			var luna = getLunaAbsenta(value);
			var an = parseInt(getAnAbsenta(value));
			
			if ( zi<1 || (luna==2 && zi>NrZileInFebruarie(an)) || zi > zileInLuna[luna])
			{
				ok = false;
			}
			else
			{
				ok = true;
			}
		}	
	}
	
	// Modified: Cristina Raluca Muntean
	// Daca formatul datei este corect se verifica daca si valoarea acesteia este mai mica decat data 
	// lichidarii angajatului.
	var okDataLichidare = true;
	
	if(ok)
	{
		//data lichidare
		var day1  = DataLichidare.substring(0,2);
		var month1= DataLichidare.substring(3,5);
		var year1 = DataLichidare.substring(6,10);
		var lichidareDate=new Date(year1,month1,day1);
		
		//data introdusa de utilizator
		var day2  = obj.value.substring(0,2);
		var month2= obj.value.substring(3,5);
		var year2 = obj.value.substring(6,10);
		var objDate=new Date(year2,month2,day2);
	
		//daca data lichidarii este mai mica decat data introdusa de utilizator atunci trebuie afisat un mesaj de eroare
		if (lichidareDate <= objDate) 
		{
			okDataLichidare = false;
			ok = false;
		}
	}
	
	if( !ok ) ErrorMsgAbsente( obj, okDataLichidare );
	
	return ok;
}



function ErrorMsgIntervalAbsente(obj,okAngajare,okLunaActiva)
{
	var MsgAngajare = "Inceputul intervalului nu poate precede data angajarii !";
	var MsgLunaActiva = "Inceputul intervalului trebuie sa apartina lunii active !";
	
	var aux = "";
	
	if (!okAngajare) aux=MsgAngajare;
	if (!okLunaActiva) aux+="\n"+MsgLunaActiva; 
	
	alert(aux);
	
	obj.value = "";
}

/*
 Autor:     Cristina Raluca Muntean
 Data:      12.06.2006
 Descriere: In cazul in care data de sfarsit a intervalului nu este in luna curenta, afiseaza un mesaj de eroare.
*/
function ErrorMsgIntervalAbsenteDataEnd(obj,okLunaActiva)
{
	var msgLunaActiva = "In cazul concediului de odihna data de sfarsit a intervalului trebuie sa apartina lunii active!";
	
	alert(msgLunaActiva);
	
	obj.value = "";
}

/*
*	Autor:		Oprescu Claudia
*	Data:		22.02.2007
*	Descriere:	Daca data de sfarsit a intervalului nu apartine lunii active, apare un mesaj de eroare.
*/
function ErrorMsgIntervalDataEnd(obj,okLunaActiva)
{
	var msgLunaActiva = "Data de sfarsit a intervalului trebuie sa apartina lunii active!";
	
	alert(msgLunaActiva);
	
	obj.value = "";
}

function HandleDataPressed( obj )
{
	var value=obj.value;

	if( value.length==1 )
	{
		if( value.charAt(value.length-1)=="." ) obj.value = "";
	}
	else if( value.length==2 )
	{
		if( value.charAt( value.length-1 )=="." )
			 obj.value = "0"+value.charAt( 0 )+".";
	}
	else if( value.length==3 )
	{
		if( value.indexOf( "." )==-1 )
			obj.value = value.substr( 0, value.length-1 )+"."+value.charAt( 2 );
	}
	else if( value.length==5 )
	{
		if( value.charAt( value.length-1 )=="." )
			obj.value = value.charAt( 0 )+value.charAt( 1 )+value.charAt( 2 )+"0"+value.charAt( 3 )+".";
	}
	else if( value.length==6 )
	{
		if( value.charAt( value.length-1 )!=".")
			//obj.value = value.substr( 0, value.length-2 )+"."+value.charAt( 6 );
			obj.value = value.substr( 0, value.length-1 )+"."+value.charAt( 5 );

	}
	var data = value;
}

function ErrorMsgAbsente(obj, okDataLichidare)
{

	var MsgEmpty = "Campul data nu poate fi gol ! Va rugam completati acest camp.";
	var MsgSyntax = "Campul data poate contine doar cifre (0-9) si delimitatorul '.' !\nCampul trebuie sa fie de forma zz.ll.aaaa, acceptandu-se doar valori corecte!";
	var MsgDataLichidare = "Nu se pot introduce intervale in pontaj dupa data la care angajatul a fost lichidat!";
   
    //Modified: Muntean Raluca Cristina
    //In cazul in care se doreste introducerea unei absente cand angajatul este lichidat se afiseaza un mesaj de eroare.
    if(!okDataLichidare)
		alert(MsgDataLichidare);
	else
		if( obj.value.length==0 )
			alert( MsgEmpty );
		else alert( MsgSyntax );
	
	
		
	obj.value = "";

}


function DataStartChanged()
{
	var objDataStart = getObj( this.DataStartID );
	var okDataStart = HandleDataChanged( objDataStart );
	
	if (okDataStart)
	{
		var okAngajare = (CompareAbsente(objDataStart.value,AngajareDataStart)<2);
		var okLunaActiva = (CompareLunaAn(objDataStart.value,LunaActivaDataStart)==0);
		
		if (!okAngajare || !okLunaActiva ) 
		{
			ErrorMsgIntervalAbsente(objDataStart,okAngajare,okLunaActiva);
		}
	}
}
	
function DataEndChanged()
{
	var objDataEnd = getObj( this.DataEndID );
	var okDataEnd = HandleDataChanged( objDataEnd );
	var okLunaActiva = (CompareLunaAn(objDataEnd.value,LunaActivaDataStart)==0);
	
	if(okDataEnd)
	{
		if ((!okLunaActiva ) /*&& 
		((document.getElementById( TipIntervAbsente ).options[ document.getElementById( TipIntervAbsente ).selectedIndex ].text == 'Concediu Odihna') ||
		(document.getElementById( TipIntervAbsente ).options[ document.getElementById( TipIntervAbsente ).selectedIndex ].text == 'Concediu Odihna Anul Precedent'))*/)
		{
			ErrorMsgIntervalDataEnd(objDataEnd,okLunaActiva);
		}
	}
}
//Lungu Andreea - 12.11.2008
function DataEndIntrerupereChanged()
{
	var objDataEnd = getObj( this.DataEndID );
	var okDataEnd = HandleDataChanged( objDataEnd );
	var comp = CompareLunaAn(objDataEnd.value,LunaActivaDataStart);
	var okLunaActiva = ((comp==0) || (comp==1));
	if(okDataEnd)
	{
		//if ((!okLunaActiva ) /*&& 
		//((document.getElementById( TipIntervAbsente ).options[ document.getElementById( TipIntervAbsente ).selectedIndex ].text == 'Concediu Odihna') ||
		//(document.getElementById( TipIntervAbsente ).options[ document.getElementById( TipIntervAbsente ).selectedIndex ].text == 'Concediu Odihna Anul Precedent'))*/)
		//{
			//ErrorMsgIntervalDataEnd(objDataEnd,okLunaActiva);
		//	alert("Data de sfarsit trebuie sa apartina lunii activa sau unei luni ulterioare celei active!");
		//	objDataEnd.value = "";
		//}		
	}
}

function DataAcordariiKeyPressed()
{
	var objDataAcordarii = getObj( this.DataAcordarii );
	HandleDataPressed( objDataAcordarii );
}

function DataStartKeyPressed()
{
	//document.write( "########"+this.DataStartID );
	var objDataStart = getObj( this.DataStartID );
	HandleDataPressed( objDataStart );

}

function DataEndKeyPressed()
{
	var objDataEnd = getObj( this.DataEndID );
	HandleDataPressed( objDataEnd );
}

function ObservatiiChanged()
{
	var objObservatii = getObj( this.ObservatiiID );

	document.getElementById( ClientObservatiiID ).value = document.getElementById( ObservatiiID1 ).value;	
}

function MedieZilnicaChanged()
{
	var objMedieZilnica = getObj( this.MedieZilnica );

	document.getElementById( ClientMedieZilnica ).value = document.getElementById( MedieZilnica1 ).value;
}

//Oprescu Claudia
//La orice modificari pe valoarea din interfata este actualizat campul ascuns
function SerieChanged()
{
	var objSerie = getObj( this.Serie );
	document.getElementById( txtSerieHidden ).value = document.getElementById( txtSerie ).value;
}

//Oprescu Claudia
//La orice modificari pe valoarea din interfata este actualizat campul ascuns
function NumarChanged()
{
	var objNumar = getObj( this.Numar );
	document.getElementById( txtNumarHidden ).value = document.getElementById( txtNumar ).value;
}

function containsElementAbsente( a, e )
{
	for( var i=0; i<a.length; i++ )
	{
		if( a[ i ]==e ) return true;
	}
	return false;
}

function getZiAbsenta( Data )
{
	var zi = Data.substr( 0, Data.indexOf( "." ));
	return zi;
}

function getLunaAbsenta( Data )
{
	var luna = Data.substr( Data.indexOf( "." )+1, Data.length-1 );
	luna = luna.substr( 0, luna.indexOf( "." ));
	return luna;
}

function getAnAbsenta( Data )
{
	var an = Data.substr( Data.indexOf( "." )+1, Data.length-1 );
	an = an.substr( an.indexOf( "." )+1, an.length-1 );
	return an;
}



function CompareLunaAn( Data1,Data2)
{

	//0 - Data1 == Data2,  1 - Dara1 > Data2 , 2 - Data1 < Data2

	var zi1 = parseInt(getZiAbsenta( Data1 ),10);
	var luna1 = parseInt(getLunaAbsenta( Data1 ),10);
	var an1 = parseInt(getAnAbsenta( Data1 ),10);
	
	var zi2 = parseInt(getZiAbsenta( Data2 ),10);
	var luna2 = parseInt(getLunaAbsenta( Data2 ),10);
	var an2 = parseInt(getAnAbsenta( Data2 ),10);
	
	if( Data1 == Data2 ) 
	{
		return 0;
	}
	else 
	{
		if( an1 > an2 ) 
		{
			return 1;
		}
		else
		{
			if( an1 < an2 )
			{
				return 2;
			}
			else
			//an1 == an2
			{
				if( luna1 > luna2 )
				{
					return 1;
				}
				else
				{
					if( luna1 < luna2 )
					{
						return 2;
					}
					else return 0;
				
				}
			}
		}
	}

}


function CompareAbsente( Data1, Data2 )
{

	//0 - Data1 == Data2,  1 - Dara1 > Data2 , 2 - Data1 < Data2
	var zi1 = parseInt(getZiAbsenta( Data1 ),10);
	var luna1 = parseInt(getLunaAbsenta( Data1 ),10);
	var an1 = parseInt(getAnAbsenta( Data1 ),10);

	var zi2 = parseInt(getZiAbsenta( Data2 ),10);
	var luna2 = parseInt(getLunaAbsenta( Data2 ),10);
	var an2 = parseInt(getAnAbsenta( Data2 ),10);

	if( Data1 == Data2 ) 
	{
		return 0;
	}
	else 
	{
		if( an1 > an2 ) 
		{
			return 1;
		}
		else
		{
			if( an1 < an2 )
			{
				return 2;
			}
			else
			//an1 == an2
			{
				if( luna1 > luna2 )
				{
					return 1;
				}
				else
				{
					if( luna1 < luna2 )
					{
						return 2;
					}
					//luna1 == luna2
					else
					{
						if( zi1 > zi2 )
						{
							return 1;
						}
						else
						{
							return 2;
						}
					}
				}
			}
		}
	}
}


function GeAbsente( Data1, Data2 )
{
	return ( CompareAbsente( Data1, Data2 ) == 1 ) || ( CompareAbsente( Data1, Data2 ) == 0 );
}

function GtAbsente( Data1, Data2 )
{
	return (CompareAbsente( Data1, Data2 ) == 1 );
}

function LeAbsente( Data1, Data2 )
{
	return ( CompareAbsente( Data1, Data2 ) == 2 ) || ( CompareAbsente( Data1, Data2 ) == 0 );
}

function EqAbsente( Data1, Data2)
{
	return ( CompareAbsente( Data1, Data2 ) == 0 );
}


function canSwitchAbsente( o1, o1_id, o2, o2_id )
{
	var objInterval1 = getIntervalAbsente( o1_id );
	var objInterval2 = getIntervalAbsente( o2_id );

	var ok1 = objInterval1.getDataEnd() == o1;
	var ok2 = objInterval2.getDataStart() == o2;

	return !( ok1 && ok2 );
}



function okSyntaxData( value )
{
	var ok = false;

	if (value.length>0)
	{
		ok=true;

		for(var i=0;i<value.length;i++)
		{

			var pos = allowedAbsente.indexOf( value.charAt( i ));
		
			ok = ok && ( pos >= 0 );
		}

	}

	return ok;
}


function handleIntervalAbsente( objInterval )
{
	var DataStart = objInterval.getDataStart();
	var DataEnd = objInterval.getDataEnd();
	
	if( GtAbsente( DataStart, DataEnd ))
	{
		getObj( objInterval.DataEndID).value="";
		DataEnd = "";
	}
	
	var okInterval = okSyntaxData( DataStart ) && okSyntaxData( DataEnd );

	return okInterval;
}


function checkIntervaleAbsente( IndexOfIntervale )
{
	var OkIntervale = true;
	var ErrMsg = "";

	for( var i=0; i<IndexOfIntervale-1; i++ )
	{
		var objInterval = IntervaleAbsenteID[ IntervaleAbsenteIndex[ i ]];
		OkIntervale = OkIntervale && handleIntervalAbsente( objInterval );
	}
	
	if( !OkIntervale ) ErrMsg = 'Exista intervale necompletate sau cu format necorespunzator (dd.mm.yyyy).';
	else
	{
		var tmpStart= [];
		var tmpEnd= [];

		var OkStart = true;
		var OkEnd = true;

		var tmpData = [];
		var tmpDataID= [];

		for( var i=0; i<IndexOfIntervale-1; i++ )
		{

			var objInterval = IntervaleAbsenteID[ IntervaleAbsenteIndex[ i ]];

			var DataStart = getObj( objInterval.DataStartID ).value;
			var DataEnd = getObj( objInterval.DataEndID ).value;

			tmpData[ tmpData.length ] = DataStart;
			tmpData[ tmpData.length ] = DataEnd;

			tmpDataID[ tmpDataID.length ] = objInterval.IntervalAbsenteID;
			tmpDataID[ tmpDataID.length] = objInterval.IntervalAbsenteID;

			OkStart = OkStart && !containsElementAbsente( tmpStart, DataStart);
			OkEnd = OkEnd && !containsElementAbsente( tmpEnd, DataEnd);

			tmpStart[ tmpStart.length ] = DataStart;
			tmpEnd[ tmpEnd.length ] = DataEnd;
		}


		OkIntervale = OkStart && OkEnd;

		if( !OkIntervale )  ErrMsg = ' Exista intervale ale caror date de start / sfarsit  coincid !';
		else
		//******************** verificare intervale disjuncte
		{

			var Flag = true;
			while( Flag )
			{
				Flag = false;

				for( var i=0; i<tmpData.length-1; i++ )
				{
					var e1 = tmpData[ i ];
					var e2 = tmpData[ i+1 ];

					var e1_id = tmpDataID[ i ];
					var e2_id = tmpDataID[ i+1 ];

					if ( GtAbsente( e1, e2 ) || ( EqAbsente( e1, e2 ) && canSwitchAbsente( e1, e1_id, e2, e2_id )))
					{

						var aux = e2;
						e2 = e1;
						e1 = aux;
						tmpData[ i ] = e1;
						tmpData[ i+1 ] = e2;
						
						var aux = e2_id;
						e2_id = e1_id;
						e1_id = aux;
						tmpDataID[ i ] = e1_id;
						tmpDataID[ i+1 ] = e2_id;
						
						Flag = true;
					}
				} // for
			}// while

			var s = "";
			var s_id = "";
		
			var okDisjuncte = true;
		
			var k = 0;
			for( var i=0; i<tmpData.length/2; i++ )
			{
				okDisjuncte = okDisjuncte && ( tmpDataID[ k ] == tmpDataID[ k+1 ] );
				k = k+2;
			}
			
			if( !okDisjuncte ) ErrMsg = 'Intervalele de timp specificate nu sunt disjuncte !';

			OkIntervale = OkIntervale && okDisjuncte;

		} //******************** verificare intervale disjuncte

	}

	if( !OkIntervale ) alert( ErrMsg );
	return OkIntervale;

}


function CheckIntervaleAbsenteToSave()
{
	return checkIntervaleAbsente( IntervaleAbsenteIndex.length );
}

function CheckIntervaleAbsenteToAdd()
{
	return checkIntervaleAbsente( IntervaleAbsenteIndex.length+1 );
}

function SubmitAddAbsente()
{
	if( CheckIntervaleAbsenteToAdd())
	{
		document.getElementById( ActionIntervaleID ).value = "addIntervalAbsente";
		document.getElementById( FormClientID ).submit();
	}
}

function SubmitSaveAbsente()
{
	if( CheckIntervaleAbsenteToSave())
	{
		document.getElementById( IntervaleAbsenteSaveInfoID ).value = "";
		for( var i=0; i<IntervaleAbsenteIndex.length-1; i++ )
		{
			var objInterval = IntervaleAbsenteID[ IntervaleAbsenteIndex[ i ]];

			var aux = objInterval.getHiddenAbsenteID()+"#"+objInterval.getDataStart()+"#"+objInterval.getDataEnd()+"#"+objInterval.getTipIntervalAbsente()+"#"+objInterval.getObservatii()+"#"+objInterval.getTipBoalaAbsente()+"#"+objInterval.getMedieZilnica()+"#"+objInterval.getSerie()+"#"+objInterval.getNumar()+"#"+objInterval.getNumeIntervalAbsenta()+"#"+objInterval.getCertificatInitial()+"#"+objInterval.getSerieCertificat()+"#"+objInterval.getNumarCertificat()+"#"+objInterval.getDataAcordarii()+"#"+objInterval.getCnpCopil()+"#"+objInterval.getLocPrescriere()+"#"+objInterval.getCodUrgenta()+"#"+objInterval.getNrAvizMedic()  ;
			if( i<IntervaleAbsenteIndex.length-2 ) 
				aux += "^";
			document.getElementById( IntervaleAbsenteSaveInfoID ).value += aux;
		}

		if( document.getElementById( IntervaleAbsenteSaveInfoID ).value!="" )
		{
			document.getElementById( ActionIntervaleID ).value = "saveIntervaleAbsente";
			document.getElementById( FormClientID ).submit();
		}
	}
}

function SubmitDeleteSelectedAbsente()
{
	document.getElementById( IntervaleAbsenteSaveInfoID ).value = "";
	
	for( var i=0; i<IntervaleAbsenteIndex.length-1; i++)
	{
		var objInterval = IntervaleAbsenteID[ IntervaleAbsenteIndex[ i ]];
	
		if( objInterval.getCheckedAbsente())
		{
			var aux = objInterval.getHiddenAbsenteID()+"^";
			document.getElementById( IntervaleAbsenteSaveInfoID ).value += aux;
		}
	}
	
	if( document.getElementById( IntervaleAbsenteSaveInfoID ).value!="" )
	{
		document.getElementById( ActionIntervaleID ).value = "deleteIntervaleAbsenteSelectate";
		if( confirm( 'Confirmati stergerea intervalelor.' ))
			document.getElementById( FormClientID ).submit();
	}
}


//*****************************************************************************
//*                                 Dovlecel Vlad                             *
//*                           - INTRERUPERI CONTRACTE -                       *
//*****************************************************************************
var IntervaleIntreruperiID = [];
var IntervaleIntreruperiIndex = [];

function RegisterIntervalIntreruperi( Interval )
{
	IntervaleIntreruperiID[ Interval.IntervalIntreruperiID ] = Interval;
	IntervaleIntreruperiIndex [ IntervaleIntreruperiIndex.length ] = Interval.IntervalIntreruperiID;
}

function getIntervalIntreruperi( IntervalID )
{
	//document.write( "#####:"+IntervalID+"!!!!!" );
	//document.write( "$$$$$$:"+IntervaleAbsenteID[ IntervalID ] );
	return IntervaleIntreruperiID[ IntervalID ];
}

/*function getObj(ID)
{
return document.getElementById(ID);
}*/

//Adaugat:		Oprescu	Claudia
//Descriere:	Metoda este apelata la modificarea datei de sfarsit a intrvalului de intrerupere a contractului
function DataEndChangedIntrerupere()
{
	var objDataEnd = getObj( this.DataEndID );
	var okDataEnd = HandleDataChanged( objDataEnd );
	var okLunaActiva = (CompareLunaAn(objDataEnd.value,LunaActivaDataStart)==0);
	
	if(okDataEnd)
	{
		if (!okLunaActiva )
		{
			alert("Data de sfarsit a intervalului trebuie sa fie in luna activa!");
		}
	}
}

function CreateIntervalIntreruperiElement( IntervalIntreruperiID, DataStartID, DataEndID, hidden_IntervalIntreruperiID, CheckIntreruperiID, ObservatiiID )
{
	//document.write( "##### absente : "+document.getElementById( IntervalAbsenteID ).value+"!!!!!" );
	//document.write( "####1:"+IntervalAbsenteID+"####2:"+DataStartID+"####3:"+DataEndID+"####4:"+TipIntervalAbsenteID+"####5:"+TipBoalaAbsenteID+"####6:"+hidden_IntervalAbsenteID+"####7:"+CheckAbsenteID+"@@@" );
	this.CheckIntreruperiID = CheckIntreruperiID;
	this.IntervalIntreruperiID = IntervalIntreruperiID;
	this.hidden_IntervalIntreruperiID = hidden_IntervalIntreruperiID;
	this.DataStartID = DataStartID;
	this.DataEndID = DataEndID;
	this.ObservatiiID = ObservatiiID;
	this.DataStartChanged = DataStartChanged;
	this.DataEndChanged = DataEndChanged;
	this.DataEndIntrerupereChanged = DataEndIntrerupereChanged;
	this.DataStartKeyPressed = DataStartKeyPressed;
	this.DataEndKeyPressed = DataEndKeyPressed;
	this.getDataStartIntreruperi = getDataStartIntreruperi;
	this.getDataEndIntreruperi = getDataEndIntreruperi;
	this.getObservatiiIntreruperi = getObservatiiIntreruperi;
	this.getHiddenIntreruperiID = getHiddenIntreruperiID;
	this.getCheckedIntreruperi = getCheckedIntreruperi;
	this.ObservatiiIntreruperiChanged = ObservatiiIntreruperiChanged;
	RegisterIntervalIntreruperi(this);
}

//var allowed="0123456789:";



function getDataStartIntreruperi()
{
	var DataStart = getObj(this.DataStartID).value;
	//document.write( "^^^"+OraStart);

	//document.getElementById( ClientOraStart ).value = OraStart;
	document.getElementById( ClientDataStart ).value = document.getElementById( DataStartIntrerupere ).value;

	return DataStart;
}

function getDataEndIntreruperi()
{
	var DataEnd = getObj(this.DataEndID).value;

	//document.write( document.getElementById( OraSf ).value );
	//document.getElementById( ClientOraEnd ).value = OraEnd;
	document.getElementById( ClientDataEnd ).value = document.getElementById( DataEndIntrerupere ).value;

	return DataEnd;
}

function getObservatiiIntreruperi()
{
	var obs = getObj( this.ObservatiiID ).value;
	//document.write( "^^^"+OraStart);

	//document.getElementById( ClientOraStart ).value = OraStart;
	document.getElementById( ClientObservatiiID ).value = document.getElementById( ObservatiiIDIntrerupere ).value;

	return obs;
}

function getHiddenIntreruperiID()
{
	var hiddenID = getObj(this.hidden_IntervalIntreruperiID).value;

	document.getElementById( ClientIntervalAbsenteID ).value = document.getElementById( IntervIntreruperiID ).value;
	//document.getElementById( ClientIntervalID ).value = hiddenID;

	return hiddenID;
}

function getCheckedIntreruperi()
{
	var checked = getObj(this.CheckIntreruperiID).checked;

	return checked;
}

function ObservatiiIntreruperiChanged()
{
	var objObservatii = getObj( this.ObservatiiID );

	document.getElementById( ClientObservatiiID ).value = document.getElementById( ObservatiiIDIntrerupere ).value;	
}


function canSwitchIntreruperi( o1, o1_id, o2, o2_id )
{
	var objInterval1 = getIntervalIntreruperi( o1_id );
	var objInterval2 = getIntervalIntreruperi( o2_id );

	var ok1 = objInterval1.getDataEndIntreruperi() == o1;
	var ok2 = objInterval2.getDataStartIntreruperi() == o2;

	return !( ok1 && ok2 );
}

function handleIntervalIntreruperi( objInterval )
{
	var DataStart = objInterval.getDataStartIntreruperi();
	var DataEnd = objInterval.getDataEndIntreruperi();
	
	if( GtAbsente( DataStart, DataEnd ))
	{
		getObj( objInterval.DataEndID).value="";
		DataEnd = "";
	}
	
	var okInterval = okSyntaxData( DataStart ) && okSyntaxData( DataEnd );

	return okInterval;
}


function checkIntervaleIntreruperi( IndexOfIntervale )
{
	var OkIntervale = true;
	var ErrMsg = "";

	for( var i=0; i<IndexOfIntervale-1; i++ )
	{
		var objInterval = IntervaleIntreruperiID[ IntervaleIntreruperiIndex[ i ]];
		OkIntervale = OkIntervale && handleIntervalIntreruperi( objInterval );
	}
	
	if( !OkIntervale ) ErrMsg = 'Exista intervale necompletate sau cu format necorespunzator (dd.mm.yyyy).';
	else
	{
		var tmpStart= [];
		var tmpEnd= [];

		var OkStart = true;
		var OkEnd = true;

		var tmpData = [];
		var tmpDataID= [];

		for( var i=0; i<IndexOfIntervale-1; i++ )
		{

			var objInterval = IntervaleIntreruperiID[ IntervaleIntreruperiIndex[ i ]];

			var DataStart = getObj( objInterval.DataStartID ).value;
			var DataEnd = getObj( objInterval.DataEndID ).value;

			tmpData[ tmpData.length ] = DataStart;
			tmpData[ tmpData.length ] = DataEnd;

			tmpDataID[ tmpDataID.length ] = objInterval.IntervalIntreruperiID;
			tmpDataID[ tmpDataID.length] = objInterval.IntervalIntreruperiID;

			OkStart = OkStart && !containsElementAbsente( tmpStart, DataStart);
			OkEnd = OkEnd && !containsElementAbsente( tmpEnd, DataEnd);

			tmpStart[ tmpStart.length ] = DataStart;
			tmpEnd[ tmpEnd.length ] = DataEnd;
		}


		OkIntervale = OkStart && OkEnd;

		if( !OkIntervale )  ErrMsg = ' Exista intervale ale caror date de start / sfarsit  coincid !';
		else
		//******************** verificare intervale disjuncte
		{

			var Flag = true;
			while( Flag )
			{
				Flag = false;

				for( var i=0; i<tmpData.length-1; i++ )
				{
					var e1 = tmpData[ i ];
					var e2 = tmpData[ i+1 ];

					var e1_id = tmpDataID[ i ];
					var e2_id = tmpDataID[ i+1 ];

					if ( GtAbsente( e1, e2 ) || ( EqAbsente( e1, e2 ) && canSwitchIntreruperi( e1, e1_id, e2, e2_id )))
					{

						var aux = e2;
						e2 = e1;
						e1 = aux;
						tmpData[ i ] = e1;
						tmpData[ i+1 ] = e2;
						
						var aux = e2_id;
						e2_id = e1_id;
						e1_id = aux;
						tmpDataID[ i ] = e1_id;
						tmpDataID[ i+1 ] = e2_id;
						
						Flag = true;
					}
				} // for
			}// while

			var s = "";
			var s_id = "";
		
			var okDisjuncte = true;
		
			var k = 0;
			for( var i=0; i<tmpData.length/2; i++ )
			{
				okDisjuncte = okDisjuncte && ( tmpDataID[ k ] == tmpDataID[ k+1 ] );
				k = k+2;
			}
			
			if( !okDisjuncte ) ErrMsg = 'Intervalele de intrerupere  specificate nu sunt disjuncte !';

			OkIntervale = OkIntervale && okDisjuncte;

		} //******************** verificare intervale disjuncte

	}

	if( !OkIntervale ) alert( ErrMsg );
	return OkIntervale;

}


function CheckIntervaleIntreruperiToSave()
{
	return checkIntervaleIntreruperi( IntervaleIntreruperiIndex.length );
}

function CheckIntervaleIntreruperiToAdd()
{
	return checkIntervaleIntreruperi( IntervaleIntreruperiIndex.length+1 );
}

function SubmitAddIntreruperi()
{
	if( CheckIntervaleIntreruperiToAdd())
	{
		document.getElementById( ActionIntervaleID ).value = "addIntervalIntreruperi";
		document.getElementById( FormClientID ).submit();
	}
}

function SubmitSaveIntreruperi()
{
	if( CheckIntervaleAbsenteToSave())
	{
		document.getElementById( IntervaleAbsenteSaveInfoID ).value = "";
		for( var i=0; i<IntervaleIntreruperiIndex.length-1; i++ )
		{
			var objInterval = IntervaleIntreruperiID[ IntervaleIntreruperiIndex[ i ]];
			
			var aux = objInterval.getHiddenIntreruperiID()+"#"+objInterval.getDataStartIntreruperi()+"#"+objInterval.getDataEndIntreruperi()+"#"+objInterval.getObservatiiIntreruperi();
			
			if( i<IntervaleIntreruperiIndex.length-2 ) 
				aux += "^";
			document.getElementById( IntervaleAbsenteSaveInfoID ).value += aux;
		}

		if( document.getElementById( IntervaleAbsenteSaveInfoID ).value!="" )
		{
			document.getElementById( ActionIntervaleID ).value = "saveIntervaleIntreruperi";
			document.getElementById( FormClientID ).submit();
		}
	}
}

function SubmitDeleteSelectedIntreruperi()
{
	document.getElementById( IntervaleAbsenteSaveInfoID ).value = "";

	for( var i=0; i<IntervaleIntreruperiIndex.length-1; i++)
	{
		var objInterval = IntervaleIntreruperiID[ IntervaleIntreruperiIndex[ i ]];
	
		if( objInterval.getCheckedIntreruperi())
		{
			var aux = objInterval.getHiddenIntreruperiID()+"^";
			document.getElementById( IntervaleAbsenteSaveInfoID ).value += aux;
		}
	}
	
	if( document.getElementById( IntervaleAbsenteSaveInfoID ).value!="" )
	{
		document.getElementById( ActionIntervaleID ).value = "deleteIntervaleIntreruperiSelectate";
		if( confirm( 'Daca sunt intervale care pornesc dintr-o luna anterioara, se vor sterge doar intreruperile de contract din luna activa. Confirmati stergerea intreruperilor.' ))
			document.getElementById( FormClientID ).submit();
	}
}


//***************************************************
// - Functiile pt initializarea lunilor -
//***************************************************

function AfiseazaContinuariAbsenta()
{
	document.getElementById( ActionIntervaleID ).value = "showIntervaleAbsenteMedicaleContinuari";
	document.getElementById( FormClientID ).submit();
}

function CompleteazaIntervaleLuna()
{
	document.getElementById( ActionIntervaleID ).value = "completeazaIntervaleLuna";
	document.getElementById( FormClientID ).submit();
}

function InitializareLunaClick()
{
	TransferaDateDinClientInMain();
	//document.getElementById( ListaCategoriiVal ).value = document.getElementById( ListaCategoriiDDL ).value;
	document.getElementById( ActionInitializareValue ).value = "initializareLuna";
	document.getElementById( FormClientID ).submit();
}

//Lungu Andreea - 05.11.2009
function ImportSituatieClick()
{
	//TransferaDateDinClientInMain();
	//document.getElementById( ListaCategoriiVal ).value = document.getElementById( ListaCategoriiDDL ).value;
	document.getElementById( ActionImportValue ).value = "importSituatie";
	document.getElementById( FormClientID ).submit();
}

//Lungu Andreea - 06.11.2009
function ImportPontajClick()
{
	//TransferaDateDinClientInMain();
	//document.getElementById( ListaCategoriiVal ).value = document.getElementById( ListaCategoriiDDL ).value;
	document.getElementById( ActionImportValue ).value = "importPontaj";
	document.getElementById( FormClientID ).submit();
}

//Lungu Andreea - 24.08.2010
function ImportDelegatiiClick()
{
	//TransferaDateDinClientInMain();
	//document.getElementById( ListaCategoriiVal ).value = document.getElementById( ListaCategoriiDDL ).value;
	document.getElementById( ActionImportDelegatiiValue ).value = "importDelegatii";
	document.getElementById( FormClientID ).submit();
}

//Lungu Andreea - 05.11.2009
function TrimiteMailFluturasiClick()
{
	//TransferaDateDinClientInMain();
	//document.getElementById( ListaCategoriiVal ).value = document.getElementById( ListaCategoriiDDL ).value;
	document.getElementById( ActionTrimiteMailFluturasiValue ).value = "trimiteMailFluturasi";
	document.getElementById( FormClientID ).submit();
}

//Lungu Andreea - 20.09.2010
function SincronizareClick()
{
	//TransferaDateDinClientInMain();
	//document.getElementById( ListaCategoriiVal ).value = document.getElementById( ListaCategoriiDDL ).value;
	document.getElementById( ActionSincronizareValue ).value = "sincronizareDateAngajati";
	document.getElementById( FormClientID ).submit();
}

function TransferaDateDinClientInMain()
{
	document.getElementById( ListaCategoriiVal ).value = document.getElementById( ListaCategoriiDDL ).value;
	document.getElementById( TxtNrZileLunaMain ).value = document.getElementById( TxtNrZileLunaClient ).value;
	document.getElementById( TxtAlteDrepturiMain ).value = document.getElementById( TxtAlteDrepturiClient ).value;
	document.getElementById( TxtAlteDrepturiNetMain ).value = document.getElementById( TxtAlteDrepturiNetClient).value;
	//document.getElementById( TxtAjutorDecesMain ).value = document.getElementById( TxtAjutorDecesClient).value;
	
	document.getElementById( TxtNrOreConcediuBoalaMain ).value = document.getElementById( TxtNrOreConcediuBoalaClient ).value;
	document.getElementById( TxtNrOreConcediuOdihnaMain ).value = document.getElementById( TxtNrOreConcediuOdihnaClient ).value;
	
	document.getElementById( TxtNrOreEvenimDeosebMain ).value = document.getElementById( TxtNrOreEvenimDeosebClient ).value;
	document.getElementById( TxtNrOreInvoireMain ).value = document.getElementById( TxtNrOreInvoireClient ).value;
	
	document.getElementById( TxtNrOreObligatiiCetatenestiMain ).value = document.getElementById( TxtNrOreObligatiiCetatenestiClient ).value;
	document.getElementById( TxtNrOreAbsenteNemotivateMain ).value = document.getElementById( TxtNrOreAbsenteNemotivateClient ).value;
	document.getElementById( TxtNrOreConcediuFaraPlataMain ).value = document.getElementById( TxtNrOreConcediuFaraPlataClient ).value;
	
	document.getElementById( TxtNrOreLucrateMain ).value = document.getElementById( TxtNrOreLucrateClient ).value;
	document.getElementById( TxtNrOreSup100ProcMain ).value = document.getElementById( TxtNrOreSup100ProcClient ).value;
	document.getElementById( TxtNrOreSup50ProcMain ).value = document.getElementById( TxtNrOreSup50ProcClient ).value;
	document.getElementById( TxtPrimeSpecialeMain ).value = document.getElementById( TxtPrimeSpecialeClient ).value;
	document.getElementById( TxtSporActivitatiSupMain ).value = document.getElementById( TxtSporActivitatiSupClient ).value;
	document.getElementById( TxtEmergencyServiceMain ).value = document.getElementById( TxtEmergencyServiceClient ).value;
	
	document.getElementById( TxtAvansMain ).value = document.getElementById( TxtAvansClient ).value;
	//document.getElementById( TxtRegularizareMain ).value = document.getElementById( TxtRegularizareClient ).value;
	document.getElementById( TxtPrimaProiectMain ).value = document.getElementById( TxtPrimaProiectClient ).value;
	
	//Added: Ionel Popa
	/*if(document.getElementById( TxtIndexareSalariiClient ).checked)
		document.getElementById( TxtIndexareSalariiMain ).value = "true";
	else
		document.getElementById( TxtIndexareSalariiMain ).value = "false";*/
		
	if(!document.getElementById( TxtIndexareSalariiClient ).disabled && document.getElementById( indexareCheckBoxClient ).checked)
		document.getElementById( TxtIndexareSalariiMain ).value = "true";
	else
		document.getElementById( TxtIndexareSalariiMain ).value = "false";
}

function GenerareSituatieLunaraAngajat()
{
	document.getElementById( ActionGenerareSituatieLunaraMain ).value = "generareSituatieLunaraAngajat";
	document.getElementById( FormClientID ).submit();
}

function GenerareSituatieLunaraTotiAngajatii()
{
	document.getElementById( ActionGenerareSituatieLunaraMain ).value = "generareSituatieLunaraTotiAngajatii";
	document.getElementById( FormClientID ).submit();
}

//***********************************************
//  -  Functii js pt SituatieLunaraAngajat.ascx
//***********************************************
function AdaugaSituatie()
{
	TransferaDateDinClientInMainSituatieLunaraAngajat();
	document.getElementById( ActionSituatieLunaraAngajatMain ).value = "adaugaSituatieLunaraAngajat";
	document.getElementById( FormClientID ).submit();
}

function ModificaSituatie()
{
	TransferaDateDinClientInMainSituatieLunaraAngajat();
	//document.write( document.getElementById( ActionSituatieLunaraAngajatMain ));
	document.getElementById( ActionSituatieLunaraAngajatMain ).value = "modificaSituatieLunaraAngajat";
	document.getElementById( FormClientID ).submit();
}

function StergeSituatie()
{
	//TransferaDateDinClientInMainSituatieLunaraAngajat();
	document.getElementById( ActionSituatieLunaraAngajatMain ).value = "stergeSituatieLunaraAngajat";
	document.getElementById( FormClientID ).submit();
}

function TransferaDateDinClientInMainSituatieLunaraAngajat()
{
	//document.getElementById( ListaCategoriiVal ).value = document.getElementById( ListaCategoriiDDL ).value;
	document.getElementById( TxtSituatieIDMain ).value = document.getElementById( TxtSituatieIDClient ).value;
	
	document.getElementById( TxtNrZileLunaMain ).value = document.getElementById( TxtNrZileLunaClient ).value;
	document.getElementById( TxtAlteDrepturiMain ).value = document.getElementById( TxtAlteDrepturiClient ).value;
	document.getElementById( TxtAlteDrepturiNetMain ).value = document.getElementById( TxtAlteDrepturiNetClient ).value;
	document.getElementById( TxtAjutorDecesMain ).value = document.getElementById( TxtAjutorDecesClient ).value;
	document.getElementById( TxtNrOreConcediuBoalaMain ).value = document.getElementById( TxtNrOreConcediuBoalaClient ).value;
	document.getElementById( TxtNrOreConcediuOdihnaMain ).value = document.getElementById( TxtNrOreConcediuOdihnaClient ).value;
	
	document.getElementById( TxtNrZileCOefectInAvansMain ).value = document.getElementById( TxtNrZileCOefectInAvansClient ).value;
	document.getElementById( TxtNrZileCONeefectuatMain ).value = document.getElementById( TxtNrZileCONeefectuatClient ).value;
	
	
	document.getElementById( TxtNrOreEvenimDeosebMain ).value = document.getElementById( TxtNrOreEvenimDeosebClient ).value;
	document.getElementById( TxtNrOreInvoireMain ).value = document.getElementById( TxtNrOreInvoireClient ).value;
		
	document.getElementById( TxtNrOreObligatiiCetatenestiMain ).value = document.getElementById( TxtNrOreObligatiiCetatenestiClient ).value;
	document.getElementById( TxtNrOreAbsenteNemotivateMain ).value = document.getElementById( TxtNrOreAbsenteNemotivateClient ).value;
	document.getElementById( TxtNrOreConcediuFaraPlataMain ).value = document.getElementById( TxtNrOreConcediuFaraPlataClient ).value;
	
	document.getElementById( TxtNrOreLucrateMain ).value = document.getElementById( TxtNrOreLucrateClient ).value;
	document.getElementById( TxtNrOreSup100ProcMain ).value = document.getElementById( TxtNrOreSup100ProcClient ).value;
	document.getElementById( TxtNrOreSup50ProcMain ).value = document.getElementById( TxtNrOreSup50ProcClient ).value;
	document.getElementById( TxtPrimeSpecialeMain ).value = document.getElementById( TxtPrimeSpecialeClient ).value;
	document.getElementById( TxtSporActivitatiSupMain ).value = document.getElementById( TxtSporActivitatiSupClient ).value;
	document.getElementById( TxtEmergencyServiceMain ).value = document.getElementById( TxtEmergencyServiceClient ).value;
	
	document.getElementById( TxtAvansMain ).value = document.getElementById( TxtAvansClient ).value;
	document.getElementById( TxtRetineriMain1 ).value = document.getElementById( TxtRetineriClient1 ).value;
	document.getElementById( TxtRetineriMain2 ).value = document.getElementById( TxtRetineriClient2 ).value;
	document.getElementById( TxtRetineriMain3 ).value = document.getElementById( TxtRetineriClient3 ).value;
	document.getElementById( TxtRetineriMain4 ).value = document.getElementById( TxtRetineriClient4 ).value;
	document.getElementById( TxtRetineriMain5 ).value = document.getElementById( TxtRetineriClient5 ).value;
	document.getElementById( TxtRetineriMain6 ).value = document.getElementById( TxtRetineriClient6 ).value;
	document.getElementById( TxtRetineriMain7 ).value = document.getElementById( TxtRetineriClient7 ).value;
	document.getElementById( TxtRegularizareMain ).value = document.getElementById( TxtRegularizareClient ).value;
	document.getElementById( TxtPrimaProiectMain ).value = document.getElementById( TxtPrimaProiectClient ).value;
	document.getElementById( TxtRetinereSanatateMain ).value = document.getElementById( TxtRetinereSanatateClient ).value;
	document.getElementById( TxtNrTicheteMain ).value = document.getElementById( TxtNrTicheteClient ).value;
	document.getElementById( TxtCorectiiTicheteMain ).value = document.getElementById( TxtCorectiiTicheteClient ).value;
	document.getElementById( TxtNrOreLucrateDelegatieInternaMain ).value = document.getElementById( TxtNrOreLucrateDelegatieInternaClient ).value;
	document.getElementById( TxtNrOreLucrateDelegatieExternaMain ).value = document.getElementById( TxtNrOreLucrateDelegatieExternaClient ).value;
	document.getElementById( TxtDiurnaImpozabilaMain ).value = document.getElementById( TxtDiurnaImpozabilaClient ).value;
	document.getElementById( TxtDrepturiInNaturaMain ).value = document.getElementById( TxtDrepturiInNaturaClient ).value;
		
}

	// Se verifica tipul absentei si in functie de acesta este facut vizibil controlul 
	// aferent mediei zilnice.
	// Autor: Cristina Raluca Muntean
	// Data: 14.03.2006
	// Descriere: In cazul in care este selectat concediul de odihna, se afiseaza valoarea 
	// mediei zilnice aferente.
	//Modificat: Oprescu Claudia
	//Descriere: Tipul bolii, seria si numarul sunt retinute intru-un tabel care devine vizibil in functie de concediu selectat
	function TipAbsentaDDL_Changed( TipAbsentaDDLClient, tableCMClient, MedieZilnicaClient, MedieZilnicaTextBox )
	{
		var medieZilnicaTR = document.getElementById( MedieZilnicaClient );
		var medieZilnicaInput = document.getElementById( MedieZilnicaTextBox );		
		
		medieZilnicaInput.value = '0';
		txtSerie.value = '';
		txtNumar.value = '';
		txtSerieHidden.value = '';
		txtNumarHidden.value = '';
		txtCertificatInitialHidden.value='';
		txtCertificatInitial.value='';
		txtSerieCertificatHidden.value='';
		txtSerieCertificat.value='';
		txtNumarCertificatHidden.value='';
		txtNumarCertificat.value='';
		txtCnpCopilHidden.value='';
		txtCnpCopil.value='';
		txtDataAcordariiCertificatHidden.value='';
		txtDataAcordariiCertificat.value='';
		txtLocPrescriereCertificatHidden.value='';
		txtLocPrescriereCertificat.value='';
		txtCodUrgentaHidden.value='';
		txtCodUrgenta.value='';
		txtNrAvizMedicExpertHidden.value='';
		txtNrAvizMedicExpert.value='';
		
		var objDataEnd = document.getElementById(DataSf);
		var okLunaActiva = (CompareLunaAn(objDataEnd.value,LunaActivaDataStart)==0);
		// Se verifica validitatea datei de sfarsit a intervalului.
		if((!okLunaActiva) && (objDataEnd.value != ""))
		{
			ErrorMsgIntervalAbsenteDataEnd(objDataEnd,okLunaActiva);
		}
		
		// In cazul in care tipul absentei este concediu medical sau continuare concediu medical, 
		// atunci este facut vizibil controlul pentru introducerea mediei zilnice.
		if ( document.getElementById( TipAbsentaDDLClient ).options[ document.getElementById( TipAbsentaDDLClient ).selectedIndex ].text == 'Concediu Medical' || 
			document.getElementById( TipAbsentaDDLClient ).options[ document.getElementById( TipAbsentaDDLClient ).selectedIndex ].text == 'Continuare Concediu Medical' )
		{
			//Lungu Andreea - 12.09.2008 - avem medii zilnice diferite in cele doua cazuri
			if ( document.getElementById( TipAbsentaDDLClient ).options[ document.getElementById( TipAbsentaDDLClient ).selectedIndex ].text == 'Concediu Medical' ) 
			{
				//document.getElementById( TipBoalaDDLClient ).style.display = '';
				document.getElementById( tableCMClient ).style.display = '';
				medieZilnicaInput.value = medieZilnicaCB;
				MedieZilnicaChanged();
				medieZilnicaTR.style.display = '';
			}
			else
			{
				//document.getElementById( TipBoalaDDLClient ).style.display = '';
				document.getElementById( tableCMClient ).style.display = '';
				medieZilnicaInput.value = medieZilnicaCCB;
				MedieZilnicaChanged();
				medieZilnicaTR.style.display = '';
			}
		}
		else
		{
			// In cazul in care tipul absentei este concediu de odihna,
			// atunci se completeaza valoarea controlului cu valoarea mediei
			// zilnice aferente concediului de odihna pentru angajatul selectat.
			//document.getElementById( tableCMClient ).style.display = 'none';
			document.getElementById( tableCMClient ).style.display = 'none';
			
			if ((document.getElementById( TipAbsentaDDLClient ).options[ document.getElementById( TipAbsentaDDLClient ).selectedIndex ].text == 'Concediu Odihna')||
			(document.getElementById( TipAbsentaDDLClient ).options[ document.getElementById( TipAbsentaDDLClient ).selectedIndex ].text == 'Concediu Odihna Anul Precedent'))
			{
				medieZilnicaTR.style.display = '';
				medieZilnicaInput.value = medieZilnicaCO;
				MedieZilnicaChanged();
			}
			else
			{
				medieZilnicaTR.style.display = 'none';
			}
		}
	}
	
	function CertificatInitial_Changed(tabelCertificat, certificatInitialClient)	
	{
		if ( document.getElementById( certificatInitialClient ).options[ document.getElementById( certificatInitialClient ).selectedIndex ].text != 'Nu') 
		{
				document.getElementById( tabelCertificat ).style.display = 'none';
		}
		else
		{
				document.getElementById( tabelCertificat ).style.display = '';
		}
	}
	
	function CertificatInitial_Load(tabelCertificat)	
	{
		document.getElementById( tabelCertificat ).style.display = 'none';
	}
	
	function TipBoalaDDL_Changed(TipBoalaDDLClient, cnpCopilTrClient, codUrgentaClient)
	{
		if ( document.getElementById( TipBoalaDDLClient ).options[ document.getElementById( TipBoalaDDLClient ).selectedIndex ].text == '05 Boala infectocontagioasa din grupa A' ) 
		{
				document.getElementById( codUrgentaClient ).style.display = '';
		}
		else
		{
			if ( document.getElementById( TipBoalaDDLClient ).options[ document.getElementById( TipBoalaDDLClient ).selectedIndex ].text == '06 Urgenta medico-chirurgicala' ) 
			{
				document.getElementById( codUrgentaClient ).style.display = '';
			}
			else
			{
				document.getElementById( codUrgentaClient ).style.display = 'none';
			}
		}
		if ( document.getElementById( TipBoalaDDLClient ).options[ document.getElementById( TipBoalaDDLClient ).selectedIndex ].text == '09 Ingrijire copil bolnav in varsta de pana la 7 ani sau copil cu handicap, pentru afectiuni intercurente, pana la implinirea varstei de 18 ani' ) 
		{
			document.getElementById( cnpCopilTrClient ).style.display = '';
		}
		else
		{
				document.getElementById( cnpCopilTrClient ).style.display = 'none';
		}
	}