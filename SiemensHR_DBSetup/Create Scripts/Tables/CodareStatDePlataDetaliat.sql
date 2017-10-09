/*

   Wednesday, September 21, 2005 4:53:15 PM

   User: cata

   Server: bavc02cd

   Database: SiemensHR_Test

   Application: 

*/



BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
CREATE TABLE dbo.Tmp_CodareStatDePlataDetaliat
	(
	NumeColoana nvarchar(100) NOT NULL,
	Codare nvarchar(101) NOT NULL
	)  ON [PRIMARY]
GO
IF EXISTS(SELECT * FROM dbo.CodareStatDePlataDetaliat)
	 EXEC('INSERT INTO dbo.Tmp_CodareStatDePlataDetaliat (NumeColoana, Codare)
		SELECT NumeColoana, Codare FROM dbo.CodareStatDePlataDetaliat (HOLDLOCK TABLOCKX)')
GO
DROP TABLE dbo.CodareStatDePlataDetaliat
GO
EXECUTE sp_rename N'dbo.Tmp_CodareStatDePlataDetaliat', N'CodareStatDePlataDetaliat', 'OBJECT'
GO
COMMIT
