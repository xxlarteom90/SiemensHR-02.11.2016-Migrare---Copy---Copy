var m_mouseOverMenuColor = "#20b2aa";
var m_mouseOutMenuColor = "#000000";
var m_Selected = -1;
var Salaries_arLinks = new Array('InterfataSalarii/Salarii.aspx?Tab=Administrare','InterfataSalarii/Salarii.aspx?Tab=Pontaj','InterfataSalarii/Salarii.aspx?Tab=CalculSalarii','InterfataSalarii/Salarii.aspx?Tab=Rapoarte','InterfataSalarii/Salarii.aspx?Tab=Comunicari');

function Salaries_MouseOverMenu (obj)
{
	obj.style.color = m_mouseOverMenuColor;
}

function Salaries_MouseOutMenu (obj,Option)
{
	if (Option!=m_Selected)
	{
		obj.style.color = m_mouseOutMenuColor;
	}
}

function Salaries_SelectMenuOption(index)
{
	var tmpPath ="";
	var locStr = document.location.href;
	var ary = locStr.split("/");
	
	//pt HRDemo
	//if (ary.length>4) tmpPath = "../";
	if (ary.length>5) tmpPath = "../";
	document.location = tmpPath + Salaries_arLinks[index];
}