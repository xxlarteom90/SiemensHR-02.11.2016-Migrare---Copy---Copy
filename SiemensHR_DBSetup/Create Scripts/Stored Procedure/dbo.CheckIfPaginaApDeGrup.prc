SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CheckIfPaginaApDeGrup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CheckIfPaginaApDeGrup]
GO

--Autor:     Muntean Raluca Cristina
--Data:      26.07.2005
--Descriere: Verifica daca un anumit grup are dreptul sa acceseze o anumita pagina

CREATE PROCEDURE CheckIfPaginaApDeGrup
(
		--numele grupului de utilizatori
		@NumeGrup nvarchar(50),
		--numele paginii din cadrul aplicatiei
		@NumePagina nvarchar(50),
		--variabila care este true daca grupul are dreptul sa acceseze pagina, false altfel
		@Apartine bit OUTPUT
)
AS
	declare @NrAparitii int
	
	set @NrAparitii = (SELECT Count(*)
						FROM Autentificare
						WHERE NumePagina = @NumePagina AND NumeGrup = @NumeGrup
						)
	if @NrAparitii > 0
		set @Apartine = 1
	else
		set @Apartine = 0
		
RETURN @Apartine 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

