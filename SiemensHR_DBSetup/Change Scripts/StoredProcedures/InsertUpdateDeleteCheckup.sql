
/*
* Autor:			Rares Gosman,  PSE RO BS TH
* Nume:				InsertUpdateDeleteCheckup
* Descriere:		Adauga, modifica, sterge o inregistrare in tabelul Checkupuri
* Change History:	Ionel Popa ... 19.08.2005
*						- campul DataEfectuarii poate avea si null
*					Ionel Popa ... 26.08.2005
*						- parametrul ResponsabilID poate fi null
*/
ALTER PROCEDURE InsertUpdateDeleteCheckup
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@CheckupID int,
	@NecesarInstruire nvarchar(255),
	@DataUrmatorului datetime,
	@ResponsabilID int = null,
	@AngajatID int,
	@DataEfectuarii datetime = null,
	@CheckupFile nvarchar(255) = null



)

as

declare @rc int
set @rc = 0

begin tran IUDCheckup

if(@tip_actiune = 0)
begin	--Insert Checkup
	insert into Checkupuri with(xlock) 

		(
		 	NecesarInstruire,
			DataUrmatorului,
			ResponsabilID,
			AngajatID,
			DataEfectuarii,
			CheckupFile
		)		 
	
		values 

		(
		 	@NecesarInstruire,
			@DataUrmatorului,
			@ResponsabilID,
			@AngajatID,
			@DataEfectuarii,
			@CheckupFile
		)		 


	if(@@ERROR <> 0)
	begin
		rollback tran IUDCheckup
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDCheckup
		set @rc = 0
		select @@identity as NewID
	end
end
else if(@tip_actiune = 1)
begin	--UpdateCheckup
	

	declare @old_file nvarchar(255)

	set @old_file = (select CheckupFile from Checkupuri where	CheckupID = @CheckupID )

	if( @CheckupFile=null ) set @CheckupFile = @old_file

	update  Checkupuri with(xlock) set 
		
	NecesarInstruire = @NecesarInstruire, 
	DataUrmatorului = @DataUrmatorului,
	ResponsabilID = @ResponsabilID,
	DataEfectuarii = @DataEfectuarii,
	CheckupFile = @CheckupFile

	where CheckupID = @CheckupID 
	

	if(@@ERROR <> 0)
	begin
		rollback tran IUDCheckup
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDCheckup
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete Checkup
	delete from Checkupuri with(xlock) where CheckupID = @CheckupID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDCheckup
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDCheckup
		set @rc = 0
	end
end
else
	rollback tran IUDCheckup

return @rc
