var mouseOverLineColor = "#20b2aa"; //"#f3f6f9";
var mouseOutLineColor = "";
var selectBtnColor = "#20b2aa";
var normalBtnColor = "#7b8fc2";
var lastDateFieldSelected;
var mouseOverTaskColor = "#20b2aa";
var mouseOutTaskColor = "#f3f6f9";

var lightColor="#20b2aa";
var normalColor="#ffffff";
var tmpColor;

function Light(d)
{
	element = d;
	tmpColor = element.style.backgroundColor;
	change(d,lightColor);
}

function Delight(d)
{
	change(d,tmpColor);
}

function change(d,color)
{
	element = d;
	if (element!=null)
	element.style.backgroundColor=color;
}

//functie pentru validarea CNP-ului
function CheckCNP( source, arg)
{
	//VERIFICAM CNP ul
	ver=0;
	str = arg.Value;
	if(str.length==13)
	{
		suma=0;
		key=[2,7,9,1,4,6,3,5,8,2,7,9]
		for (i=0;i<12;i++)
		{
			nr=Number(str.substring(i,i+1));
			suma=suma+nr*Number(key[i])
		}
		rest=suma-Math.floor(suma/11)*11;
		lastkey=str.substring(12,13);
		if(rest==10)rest=1
		if(lastkey!=String(rest))
			arg.IsValid = false;
		else
			arg.IsValid = true;
	}
	else
		arg.IsValid = false;
}

// ptr. linie din listari tabele..
function MouseOverTableLine (obj)
{
	obj.style.cursor = "hand";
	obj.style.backgroundColor = mouseOverLineColor;
	for(i=0; i<obj.childNodes.length; i++)
	{

        //Artiom Modificat 03.04.2017
	    //obj.childNodes(i).style.color = "#ffffff";
	    var x = obj.childNodes[i];
	    if (x.style !== undefined)
	    {
	        x.style.color = "#ffffff";
	    }
	}	
}

function MouseOutTableLine (obj)
{
	obj.style.cursor = "default";
	obj.style.backgroundColor = mouseOutLineColor;
	for(i=0; i<obj.childNodes.length; i++)
	{
        // Artiom Modificat 03.04.2017
	    //obj.childNodes(i).style.color = "#000000";
	    var x = obj.childNodes[i];
	    if (x.style !== undefined)
	    {
	        x.style.color = "#000000";
	    }
	}
}

// ptr. numere de pagina din partea de jos a tabelelor
function MouseOverPageNumber (obj)
{
	obj.style.cursor = "hand";
	obj.style.textDecoration = "underline";
}

function MouseOutPageNumber (obj)
{
	obj.style.cursor = "default";
	obj.style.textDecoration = "none";
}

// ptr. header de sortare tabele..
function MouseOverSortHeader (obj)
{
	obj.style.cursor = "hand";
	obj.style.textDecoration = "underline";
}

function MouseOutSortHeader (obj)
{
	obj.style.cursor = "default";
	obj.style.textDecoration = "none";
}

// ptr. tabs view
function MouseOverTabs (obj)
{
	if (obj.className!='tabActive')
		obj.style.backgroundColor = selectBtnColor;
}
function MouseOutTabs (obj)
{
	if (obj.className!='tabActive')
		obj.style.backgroundColor = normalBtnColor;
}

function GetXWindowPosition( widthWindow )
{
	return (Math.round(screen.Width/2) - Math.round(widthWindow/2));
}
 
function GetYWindowPosition( heightWindow )
{
	return (Math.round(screen.Height/2) - Math.round(heightWindow/2));
}

function MouseOverButton (obj)
{
	obj.style.backgroundColor = selectBtnColor;
}

function MouseOutButton (obj)
{
	obj.style.backgroundColor = normalBtnColor;
}

function MouseOverOption (obj)
{
	obj.style.backgroundColor = selectBtnColor;
}

function MouseOutOption (obj)
{
	obj.style.backgroundColor = normalBtnColor;
}


// ptr. buton de sterge
function CheckDelete( text )
{
	if (confirm(text))
		return true;
	else
		return false;
}