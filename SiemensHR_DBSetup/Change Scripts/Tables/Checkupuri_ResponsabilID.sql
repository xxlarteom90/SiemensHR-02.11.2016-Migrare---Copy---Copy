/*

   Friday, August 26, 2005 1:06:29 PM

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
ALTER TABLE dbo.Checkupuri
	DROP CONSTRAINT FK_Checkupuri_Angajati
GO
ALTER TABLE dbo.Checkupuri
	DROP CONSTRAINT FK_Checkupuri_Angajati1
GO
COMMIT
BEGIN TRANSACTION
CREATE TABLE dbo.Tmp_Checkupuri
	(
	CheckupID int NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION,
	NecesarInstruire nvarchar(255) NOT NULL,
	DataUrmatorului datetime NOT NULL,
	ResponsabilID int NULL,
	AngajatID int NOT NULL,
	DataEfectuarii datetime NULL,
	CheckupFile nvarchar(255) NULL
	)  ON [PRIMARY]
GO
SET IDENTITY_INSERT dbo.Tmp_Checkupuri ON
GO
IF EXISTS(SELECT * FROM dbo.Checkupuri)
	 EXEC('INSERT INTO dbo.Tmp_Checkupuri (CheckupID, NecesarInstruire, DataUrmatorului, ResponsabilID, AngajatID, DataEfectuarii, CheckupFile)
		SELECT CheckupID, NecesarInstruire, DataUrmatorului, ResponsabilID, AngajatID, DataEfectuarii, CheckupFile FROM dbo.Checkupuri (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Checkupuri OFF
GO
DROP TABLE dbo.Checkupuri
GO
EXECUTE sp_rename N'dbo.Tmp_Checkupuri', N'Checkupuri', 'OBJECT'
GO
ALTER TABLE dbo.Checkupuri ADD CONSTRAINT
	PK_Checkupuri PRIMARY KEY CLUSTERED 
	(
	CheckupID
	) ON [PRIMARY]

GO
ALTER TABLE dbo.Checkupuri WITH NOCHECK ADD CONSTRAINT
	FK_Checkupuri_Angajati FOREIGN KEY
	(
	ResponsabilID
	) REFERENCES dbo.Angajati
	(
	AngajatID
	)
GO
ALTER TABLE dbo.Checkupuri WITH NOCHECK ADD CONSTRAINT
	FK_Checkupuri_Angajati1 FOREIGN KEY
	(
	AngajatID
	) REFERENCES dbo.Angajati
	(
	AngajatID
	)
GO
COMMIT
