/*

   3 martie 2006 13:34:57

   User: sa

   Server: ro1cv0gc

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
ALTER TABLE dbo.Conturi
	DROP CONSTRAINT FK_Conturi_Banci
GO
COMMIT
BEGIN TRANSACTION
ALTER TABLE dbo.Conturi
	DROP CONSTRAINT FK_Conturi_Angajatori
GO
COMMIT
BEGIN TRANSACTION
CREATE TABLE dbo.Tmp_Conturi
	(
	ContID int NOT NULL IDENTITY (1, 1) NOT FOR REPLICATION,
	AngajatorID int NOT NULL,
	BancaID int NOT NULL,
	NumarContVechi nvarchar(30) NOT NULL,
	Moneda nvarchar(4) NOT NULL,
	Activ bit NOT NULL,
	NumarContIBAN nvarchar(24) NOT NULL
	)  ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'ID-ul contului.'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'user', N'dbo', N'table', N'Tmp_Conturi', N'column', N'ContID'
GO
DECLARE @v sql_variant 
SET @v = N'ID-ul angajatorului de care apartine contul.'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'user', N'dbo', N'table', N'Tmp_Conturi', N'column', N'AngajatorID'
GO
DECLARE @v sql_variant 
SET @v = N'ID-ul bancii la de care apartine contul.'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'user', N'dbo', N'table', N'Tmp_Conturi', N'column', N'BancaID'
GO
DECLARE @v sql_variant 
SET @v = N'Numarul contului in forma veche(nu IBAN).'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'user', N'dbo', N'table', N'Tmp_Conturi', N'column', N'NumarContVechi'
GO
DECLARE @v sql_variant 
SET @v = N'RON sau EURO'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'user', N'dbo', N'table', N'Tmp_Conturi', N'column', N'Moneda'
GO
DECLARE @v sql_variant 
SET @v = N'0 - contul nu este activ, 1 - contul este activ. Pot fi active in acelasi timp un singur cont in EURO si unul in RON.'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'user', N'dbo', N'table', N'Tmp_Conturi', N'column', N'Activ'
GO
DECLARE @v sql_variant 
SET @v = N'contul IBAN al angajatorului'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'user', N'dbo', N'table', N'Tmp_Conturi', N'column', N'NumarContIBAN'
GO
SET IDENTITY_INSERT dbo.Tmp_Conturi ON
GO
IF EXISTS(SELECT * FROM dbo.Conturi)
	 EXEC('INSERT INTO dbo.Tmp_Conturi (ContID, AngajatorID, BancaID, NumarContVechi, Moneda)
		SELECT ContID, TitularID, BancaID, CONVERT(nvarchar(30), NumarCont), Moneda FROM dbo.Conturi (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Conturi OFF
GO
DROP TABLE dbo.Conturi
GO
EXECUTE sp_rename N'dbo.Tmp_Conturi', N'Conturi', 'OBJECT'
GO
ALTER TABLE dbo.Conturi ADD CONSTRAINT
	PK_Conturi PRIMARY KEY CLUSTERED 
	(
	ContID
	) ON [PRIMARY]

GO
ALTER TABLE dbo.Conturi WITH NOCHECK ADD CONSTRAINT
	FK_Conturi_Angajatori FOREIGN KEY
	(
	AngajatorID
	) REFERENCES dbo.Angajatori
	(
	AngajatorID
	) ON UPDATE CASCADE
	 ON DELETE CASCADE
	
GO
ALTER TABLE dbo.Conturi WITH NOCHECK ADD CONSTRAINT
	FK_Conturi_Banci FOREIGN KEY
	(
	BancaID
	) REFERENCES dbo.Banci
	(
	BancaID
	) ON UPDATE CASCADE
	 ON DELETE CASCADE
	
GO
COMMIT
