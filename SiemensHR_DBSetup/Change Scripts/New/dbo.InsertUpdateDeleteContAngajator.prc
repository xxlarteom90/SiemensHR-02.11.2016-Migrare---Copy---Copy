SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteContAngajator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteContAngajator]
GO

/*	Autor: Cristina Raluca Muntean
	Data:  3.03.2006
	Nume:  InsertUpdateDeleteContAngajator
	Descriere: Realizeaza operatiile de inserare, modificare si stergere
	a unui cont al angajatorului in functie de valoarea parametrului @tip_actiune, astfel
	0 - adaugare, 1 - modificare, 2 - stergere cont.	 
	Parametrii:
		@tip_actiune     - 0-adaugare, 1-modificare, 2-stergere
		@ContID          - id-ul contului
		@AngajatorID int - ID-ul angajatorului
		@BancaID int     - ID-ul bancii de care apartine contul
		@NumarContVechi  - numarul contului in vechiul format
		@NumarContIBAN   - numarul contului in forma IBAN
		@Moneda          - moneda: RON sau EURO
		@Activ           - 0-nu este activ, 1-este activ. Pot fi active 
						 - in acelasi timp un singur cont in euro si unul in lei.
*/
CREATE PROCEDURE InsertUpdateDeleteContAngajator
(
		@tip_actiune int -- 0-adaugare, 1-modificare, 2-stergere
		, @ContID int -- id-ul contului
		, @AngajatorID int --ID-ul angajatorului
		, @BancaID int -- ID-ul bancii de care apartine contul
		, @NumarContVechi nvarchar(30) -- numarul contului in vechiul format
		, @NumarContIBAN nvarchar(24)-- numarul contului in forma IBAN
		, @Moneda nvarchar(4) -- moneda: RON sau EURO
		, @Activ bit -- 0-nu este activ, 1-este activ. Pot fi active in acelasi timp
					 -- un singur cont in euro si unul in lei.
)

AS

declare @rc int
-- Numarul conturilor active.
declare @nrConturiActive int

set @rc = 0
-- Se obtine numarul conturilor active.
set @nrConturiActive = (select COUNT(*) 
						from Conturi
						where Activ=1 and AngajatorID=@AngajatorID)
	
begin tran IUDConturi

-- adaugare cont
if (@tip_actiune = 0)
begin	
	
	-- Daca exista conturi active, acestea trebuie inactivate.
	if ( (@nrConturiActive > 0) AND (@Activ = 1) )
	begin
		 save tran InactivareCont
		 update Conturi with(xlock) 
			set Activ = 0
  			where  Activ = 1  and AngajatorID = @AngajatorID AND Moneda = @Moneda
    end
    
	insert into Conturi with(xlock) 
		(AngajatorID
		, BancaID
		, NumarContVechi
		, NumarContIBAN
		, Moneda
		, Activ ) 
		values (
			@AngajatorID
			, @BancaID
			, @NumarContVechi
			, @NumarContIBAN
			, @Moneda
			, @Activ )
	
	if (@@ERROR <> 0)
	begin
		rollback tran InactivareCont
		rollback tran IUDConturi
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDConturi
		set @rc = 0
	end
end

--Modificare date cont
else if(@tip_actiune = 1)
begin	
	-- Daca sunt conturi active, acestea trebuie inactivate.
	if ( (@nrConturiActive > 0) AND (@Activ=1) )
	begin
		save tran InactivareCont
		
		update Conturi with(xlock) 
			set Activ = 0
  			where Activ = 1  and AngajatorID = @AngajatorID AND Moneda = @Moneda
	end
	
	-- Se face update-ul.
	update Conturi with(xlock) 
		set AngajatorID = @AngajatorID
		, BancaID = @BancaID
		, NumarContVechi = @NumarContVechi
		, NumarContIBAN = @NumarContIBAN
		, Moneda = @Moneda
		where ContId = @ContID
	
	if (@@ERROR <> 0)
	begin
		rollback tran InactivareCont
		rollback tran IUDConturi
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDConturi
		set @rc = 0
	end
end

-- Stergere cont.
else if(@tip_actiune = 2)
begin	
	delete from Conturi with(xlock) where ContID = @ContID

	if (@@ERROR <> 0)
	begin
		rollback tran IUDConturi
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDConturi
		set @rc = 0
	end
end
else
	rollback tran IUDConturi

return @rc


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

