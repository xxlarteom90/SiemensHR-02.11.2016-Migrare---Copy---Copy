var mouseOverMenuColor = "#20b2aa";
var mouseOutMenuColor = "#000000";
var arLinks = new Array('SearchAngajati.aspx','Salarii/Salarii.aspx','Rapoarte/Rapoarte.aspx','Administrare/Administrare.aspx','index.aspx','InterfataSalarii/Salarii.aspx','Home.aspx');

function MouseSelect(obj)
{
	obj.style.textDecoration = "bold";
}

function MouseOverMenu (obj)
{
	obj.style.color = mouseOverMenuColor;
}

function MouseOutMenu (obj)
{
	obj.style.color = mouseOutMenuColor;
}

function SelectMenuOption(index)
{
    //Artiom modificat in data de 04.08.2017
    //var ary = locStr.split("/");	
    //if (ary.length>5) tmpPath = "../";
    //alert("ce facasds!!!sdsad!!!!!!!!!");
	var tmpPath ="";
	var locStr = document.location.href;
	var ary = locStr.split("/");	
	
	//pt HRDemo
    //if (ary.length>4) tmpPath = "../";	


    if (ary.length>5) tmpPath = "../";	
	document.location = tmpPath + arLinks[index];
}

//Adaugat:		Oprescu Claudia
//Data:			20.12.2006
//Descriere:	S-a adaugat functia pentru generarea meniului principal pentru categoria de utilizatori din grupul Recrutori
//				Meniul contine numai optiunea pentru Cautare angajat.
function SelectMenuOption_Recrutori(index)
{
	arLinks = new Array('Recrutori/Recrutori.aspx');
	SelectMenuOption(index);
}