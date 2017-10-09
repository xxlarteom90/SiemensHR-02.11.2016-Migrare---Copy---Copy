
/********************************************************************
	created:	23.08.2005
	filename: 	MSSQL:://bavc02cd/SiemensHR_Test/dbo/Stored Procedure/dbo/DataMajorareAngajat
	file path:	MSSQL:://bavc02cd/SiemensHR_Test/dbo/Stored Procedure/dbo
	file ext:	DataMajorareAngajat
	author:		Voicu Manuel MATEI
	purpose:	Extrage angajatii carora li se va majora salariul in 
				perioada cuprinsa intre doua date calendaristice predefinite
*********************************************************************/


CREATE PROCEDURE dbo.DataMajorareAngajat

	(
		@dataStart datetime ,
		@dataStop datetime,
		@numeDepartament nvarchar(255) 
	)

AS
	/* SET NOCOUNT ON */
	SELECT     AngajatFull.Nume, AngajatFull.Prenume, AngajatFull.Marca, Angajatori.Denumire AS Angajator, AngajatFull.DataMajorare, 
                      AngajatFull.DepartamentDenumire AS Departament
FROM         AngajatFull INNER JOIN
                      Angajatori ON AngajatFull.AngajatorID = Angajatori.AngajatorID
WHERE     (AngajatFull.DataMajorare BETWEEN @dataStart AND @dataStop) AND AngajatFull.DepartamentDenumire = @numeDepartament
	RETURN 
 