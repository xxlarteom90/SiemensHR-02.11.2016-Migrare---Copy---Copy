
/*
Author Dovlecel Vlad
modificat: 11.01.2005 : adaugat la tabela DataInregistrare, NrArticol, LunaRetinere
modificat: 17.08.2005 ... Ionel Popa
	- am setat in angajati campul Lichidat pe 1
*/
ALTER PROCEDURE InsertUpdateDeleteLichidareAngajat
(
	@tip_actiune int = 0,
	@NrInregistrare nvarchar (15),
	@DataLichidare datetime,
	@AngajatID int,
	@LichidareID int,

	@AvansuriDecontare money,
	@Abonamente money,
	@TicheteMasa money,
	@EchipamentLucru money,
	@Laptop money,
	@TelServiciu money,
	@ObiecteInventar money,
	@Carti money,
	@CD money,

	@DataInregistrare datetime,
	@NrArticol nvarchar(15),
	@LunaRetinere datetime
)
 AS

declare @rc int
set @rc = 0

begin tran IUDIstoricIntreruperi

if(@tip_actiune = 0)
begin	--Insert istoric intreruperi angajat
	Insert into Lichidare( NrInregistrare, DataLichidare, AngajatID, AvansuriDecontare, Abonamente, TicheteMasa, EchipamentLucru, Laptop, TelServiciu, ObiecteInventar, Carti, CD, DataInregistrare, NrArticol, LunaRetinere )
		values( @NrInregistrare, @DataLichidare, @AngajatID, @AvansuriDecontare, @Abonamente, @TicheteMasa, @EchipamentLucru, @Laptop, @TelServiciu, @ObiecteInventar,
			@Carti, @CD, @DataInregistrare, @NrArticol, @LunaRetinere )

	Update Angajati set PerioadaDeterminata=1, Lichidat = 1, DataPanaLa=DateAdd( dd, -1,@DataLichidare )
		where AngajatID=@AngajatID

	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricIntreruperi
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricIntreruperi
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--UpdateIstoric intreruperi angajat
	Update Lichidare set NrInregistrare=@NrInregistrare, DataLichidare=@DataLichidare, AngajatID=@AngajatID, AvansuriDecontare=@AvansuriDecontare,
		Abonamente=@Abonamente, TicheteMasa=@TicheteMasa, EchipamentLucru=@EchipamentLucru, Laptop=@Laptop, TelServiciu=@TelServiciu, ObiecteInventar=@ObiecteInventar,
		Carti=@Carti, CD=@CD, DataInregistrare=@DataInregistrare, NrArticol=@NrArticol, LunaRetinere=@LunaRetinere
		where LichidareID=@LichidareID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricIntreruperi
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricIntreruperi
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete istoric intreruperi angajat
	Delete from Lichidare
		where LichidareID=@LichidareID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricIntreruperi
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricIntreruperi
		set @rc = 0
	end
end
else
	rollback tran IUDIstoricIntreruperi

return @rc