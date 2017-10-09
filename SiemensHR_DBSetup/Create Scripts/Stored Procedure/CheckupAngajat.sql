 
 /********************************************************************
 	created:	23.08.2005
  	filename: 	MSSQL:://bavc02cd/SiemensHR_Test/dbo/Stored Procedure/dbo/CheckupAngajat
 	file path:	MSSQL:://bavc02cd/SiemensHR_Test/dbo/Stored Procedure/dbo
 	file ext:	CheckupAngajat
 	author:		Voicu Manuel MATEI
 	purpose:	Extrage datele de checkup cuprinse intre doua date predefinite, pentru angajatii dintr-un anumit departament. 
 *********************************************************************/
 
 
CREATE PROCEDURE dbo.CheckupAngajat
	
	(
		@dataStart datetime ,
		@dataStop datetime,
		@numeDepartament nvarchar(255) 
	)

AS
	/* SET NOCOUNT ON */
	
	SELECT     ang.Nume AS Nume, ang.Marca AS Marca, ang.DepartamentDenumire AS Departament, resp.NumeIntreg AS [Nume responsabil], 
                      cup.DataEfectuarii AS [Data efectuarii], cup.NecesarInstruire AS [Necesar instruire], cup.DataUrmatorului AS [Data urmatorului], 
                      Angajatori.Denumire AS Angajator, ang.Prenume AS Prenume
FROM         Checkupuri cup INNER JOIN
                      AngajatFull ang ON cup.AngajatID = ang.AngajatID INNER JOIN
                      AngajatFull resp ON cup.ResponsabilID = resp.AngajatID INNER JOIN
                      Angajatori ON ang.AngajatorID = Angajatori.AngajatorID
WHERE     (ang.Activ = 0) AND (cup.DataUrmatorului BETWEEN @dataStart AND @dataStop) AND ang.DepartamentDenumire = @numeDepartament
	
	
	RETURN 
 