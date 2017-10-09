var mouseOverMenuColor = "#20b2aa";
var mouseOutMenuColor = "#000000";
var arLinks = new Array('TimeStamp.aspx','TMAngajat.aspx','TMAngajat.aspx','TMAngajat.aspx','logout.aspx','Administrare.aspx');

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
    alert("Ce faci Bratan");
	var tmpPath ="";
	var locStr = document.location.href;
	var ary = locStr.split("/");
	
	//pt HRDemo
	//if (ary.length>4) tmpPath = "../";
	if (ary.length>5) tmpPath = "../";
	document.location = tmpPath + arLinks[index];
}