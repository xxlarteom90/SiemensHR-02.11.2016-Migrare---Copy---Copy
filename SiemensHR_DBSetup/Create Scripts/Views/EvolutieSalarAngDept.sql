SELECT     TOP 100 PERCENT CASE MONTH(dbo.Sal_Luni.Data) 
                      WHEN 1 THEN 'Ian.' WHEN 2 THEN 'Feb.' WHEN 3 THEN 'Mar.' WHEN 4 THEN 'Apr.' WHEN 5 THEN 'Mai.' WHEN 6 THEN 'Iun.' WHEN 7 THEN 'Iul.' WHEN
                       8 THEN 'Aug.' WHEN 9 THEN 'Sep.' WHEN 10 THEN 'Oct.' WHEN 11 THEN 'Noi.' WHEN 12 THEN 'Dec.' END + ' ' + CAST(YEAR(dbo.Sal_Luni.Data) 
                      AS varchar(4)) AS Data, dbo.AngajatFull.NumeIntreg AS Nume, dbo.AngajatFull.DepartamentDenumire AS Departament, dbo.sal_StatDePlata.VenitBrut, 
                      dbo.sal_StatDePlata.VenitNet, dbo.Sal_Luni.Data AS Data1
FROM         dbo.sal_StatDePlata INNER JOIN
                      dbo.AngajatFull ON dbo.sal_StatDePlata.AngajatID = dbo.AngajatFull.AngajatID RIGHT OUTER JOIN
                      dbo.Sal_Luni ON dbo.sal_StatDePlata.LunaID = dbo.Sal_Luni.LunaID
ORDER BY dbo.Sal_Luni.LunaID 