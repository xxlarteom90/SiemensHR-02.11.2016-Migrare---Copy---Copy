
/********************************************************************
	created:	01/09/2005
	filename: 	MSSQL:://bavc02cd/SiemensHR_Test/dbo/Stored Procedure/dbo/Test_Hidden_Fields
	file path:	MSSQL:://bavc02cd/SiemensHR_Test/dbo/Stored Procedure/dbo
	file ext:	Test_Hidden_Fields
	author:		Voicu Manuel MATEI
	purpose:	Procedura pentru ascunderea campurilor din raportul StatDePlataDetaliat
*********************************************************************/

CREATE PROCEDURE dbo.Test_Hidden_Fields

	(
		@LunaID numeric ,
		@AngajatorID numeric,
		@FieldMask nvarchar(128) 
	)

AS
	/* SET NOCOUNT ON */
	
	SELECT    *
FROM         StatPlataDetaliat
WHERE     (LunaID = @LunaID) AND (AngajatorID = @AngajatorID)
ORDER BY Nume,Prenume


RETURN 