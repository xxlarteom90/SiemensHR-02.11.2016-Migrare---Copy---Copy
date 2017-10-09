
/********************************************************************
	created:	23.08.2005
	filename: 	MSSQL:://bavc02cd/SiemensHR_Test/dbo/Stored Procedure/dbo/ContractMuncaAngajat
	file path:	MSSQL:://bavc02cd/SiemensHR_Test/dbo/Stored Procedure/dbo
	file ext:	ContractMuncaAngajat
	author:		Voicu Manuel MATEI	
	purpose:	Extrage angajatii dintr-un anu mit departament, carora le expira 
				contractul de munca intre doua date calendaristice predefinite
*********************************************************************/


CREATE PROCEDURE dbo.ContractMuncaAngajat

	(
		@dataStart datetime ,
		@dataStop datetime,
		@numeDepartament nvarchar(255) 
	)

AS
	/* SET NOCOUNT ON */
	
	SELECT     AngajatFull.Nume, AngajatFull.Prenume, AngajatFull.Marca, Angajatori.Denumire AS Angajator, AngajatFull.PermMuncaDataExpirare, 
                      AngajatFull.DepartamentDenumire AS Departament
FROM         AngajatFull INNER JOIN
                      Angajatori ON AngajatFull.AngajatorID = Angajatori.AngajatorID
WHERE     (AngajatFull.PermMuncaDataExpirare BETWEEN @dataStart AND @dataStop) AND AngajatFull.DepartamentDenumire = @numeDepartament
	

	
	
	RETURN 
 