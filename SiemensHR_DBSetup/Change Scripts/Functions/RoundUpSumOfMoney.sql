
/*
	Author:			Ionel Popa
	Description:	Rotunjeste o suma
	Params:			suma: suma de rotunjit
				factor: rotunjirea se va face la 10^(factor)
*/

ALTER FUNCTION dbo.RoundUpSumOfMoney
( 
	@sumaIntrare as money,
	@factor as int
)  
RETURNS bigint AS  
BEGIN

declare @suma as bigint
declare @strSuma as nvarchar(32)
declare @firstPart as bigint
declare @strFirstPart as nvarchar(32)
declare @lastPart as bigint
declare @strLastPart as nvarchar(32)
declare @retSuma as bigint
declare @sumaRotunjire as bigint
declare @contor as int
declare @parteZecimalaSuma float

set @suma = @sumaIntrare
--added: Muntean Raluca Cristina 26.08.2005
--se obtine partea zecimala a sumei
set @parteZecimalaSuma = @sumaIntrare - @suma

set @strSuma = cast( @suma as nvarchar(32))

--verificam daca suma este pozitiva
if @strSuma < 0
begin
	return @suma
end

set @contor = @factor
set @sumaRotunjire = 1
while @contor <> 0
begin
	set @sumaRotunjire = @sumaRotunjire * 10
	set @contor = @contor - 1
end


if len(@strSuma) >= @factor and @factor <> 0
	begin
		set @strLastPart = substring( @strSuma, len(@strSuma) - @factor + 1, @factor)
		set @lastPart = cast( @strLastPart as bigint)
		if len(@strSuma) > @factor
			begin
				set @strFirstPart = substring( @strSuma, 0, len(@strSuma) - @factor + 1)
				set @firstPart = cast( @strFirstPart as bigint)
			end
		else
			begin
				set @firstPart = 0
			end
		--added: Muntean Raluca Cristina 26.08.2005
		--deoarece nu se facea rotunjirea daca @sumaIntrare = 40.12 de exemplu, se verifica si daca exista parte zecimala
		if @lastPart > 0 OR @parteZecimalaSuma > 0
			begin
				set @firstPart = @firstPart + 1
			end		
			
		set @retSuma = @firstPart * @sumaRotunjire
	end
else
	begin
		set @retSuma = @suma
	end

return @retSuma


END




 