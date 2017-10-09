
/********************************************************************
	created:	22.08.2005
	filename: 	MSSQL:://bavc02cd/SiemensHR_Test/dbo/Stored Procedure/dbo/UpdateTemplate
	file path:	MSSQL:://bavc02cd/SiemensHR_Test/dbo/Stored Procedure/dbo
	file ext:	UpdateTemplate
	author:		Voicu Manuel MATEI
	purpose:	Salveaza sirul de caractere folosit pentru ascunderea campurilor in statDePlataDetaliat
*********************************************************************/

CREATE PROCEDURE dbo.UpdateTemplate

	(
		@newTemplate nvarchar(100)  
		
	)

AS
	/* SET NOCOUNT ON */
	update dbo.CodareStatDePlataDetaliat
	set Codare = @newTemplate
	where NumeColoana = 'Template'
	RETURN 
 