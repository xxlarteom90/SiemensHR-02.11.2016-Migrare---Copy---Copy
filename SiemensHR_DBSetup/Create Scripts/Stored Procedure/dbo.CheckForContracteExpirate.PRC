SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CheckForContracteExpirate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CheckForContracteExpirate]
GO

/*
Autor:			Popa Ionel
Data:			11.08.2005
Nume:			CheckForContracteExpirate
Descriere:		Verifica daca exista contracte ce expira in urmatoarele @NoOfDays
			Daca exista contracte care expira se trimite un mail la responsabilii cu acest lucru
Params:			@NoOfDays ... numarul de zile in care expira contractele
*/
CREATE PROCEDURE CheckForContracteExpirate ( @NoOfDays int)
AS
	declare @AngajatID int
	declare @Marca 	nvarchar(32)
	declare @NumeIntreg nvarchar(256)
	declare @DataPanaLa datetime
	--va contine lista cu angajatii carora le expira contractele
	declare @MailBody varchar(8000)
	--variabile ce contin lungimile coloanelor din tabel
	declare @MarcaColLength int
	declare @NumeIntregColLength int
	declare @DataPanaLaColLength int
	
	--setam variabilele ce contin lungimile coloanelor din tabel
	set @MarcaColLength = 12
	set @NumeIntregColLength = 48
	set @DataPanaLaColLength = 15

	--setam MailBody cu header-ul tabelului
	set @MailBody = [SiemensHR_Test].[dbo].[CreateFixedLengthString]('Marca', @MarcaColLength) + [SiemensHR_Test].[dbo].[CreateFixedLengthString]('Nume Intreg', @NumeIntregColLength)  + [SiemensHR_Test].[dbo].[CreateFixedLengthString]('Data Expirarii', @DataPanaLaColLength)
	insert into sqlmailbody (mailbody) values(@MailBody)
	
	declare ContracteExpirate_cursor scroll cursor for
		select AngajatID, Marca, NumeIntreg, dataPanaLa
		from angajatfull 
		where activ =0 and  PerioadaDeterminata=1 and  datediff(day, getdate(), dataPanaLa)  <= @NoOfDays

	open ContracteExpirate_cursor

	fetch next from ContracteExpirate_cursor into
	@AngajatID,
	@Marca,
	@NumeIntreg,
	@DataPanaLa
	while @@fetch_status = 0
	begin
		set @MailBody =  char(13) + [SiemensHR_Test].[dbo].[CreateFixedLengthString](@Marca , @MarcaColLength) + [SiemensHR_Test].[dbo].[CreateFixedLengthString](@NumeIntreg , @NumeIntregColLength) + [SiemensHR_Test].[dbo].[CreateFixedLengthString]( (select dbo.FormatData(@DataPanaLa)), @DataPanaLaColLength)	
		insert into sqlmailbody (mailbody) values(@MailBody)

		fetch next from ContracteExpirate_cursor into
		@AngajatID,
		@Marca,
		@NumeIntreg,
		@DataPanaLa
	
	end

	close ContracteExpirate_cursor
	deallocate ContracteExpirate_cursor
	
	
	EXEC master.dbo.xp_sendmail @recipients = 'ionel.popa@pse.siemens.ro',
		@message = 'Acest mail este generat de SQL Server!',
		@query = 'select MailBody from SiemensHR_Test.dbo.sqlmailbody',
		@subject = 'Mail de la SQL Server'
	
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

