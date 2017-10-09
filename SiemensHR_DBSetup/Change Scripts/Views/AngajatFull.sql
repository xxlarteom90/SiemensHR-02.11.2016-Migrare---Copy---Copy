/*
	Author: Ionel Popa
	Description: select-ul pentru view-ul AngajatFull
	Change history: Ionel Popa ... 31.08.2005 ... am adaugat si tabela Lichidare
*/

SELECT     dom.TaraID AS DTaraID, dom.Localitate AS DLocalitate, dom.JudetSectorID AS DJudetSectorID, dom.Strada AS DStrada, dom.Numar AS DNumar, 
                      dom.CodPostal AS DCodPostal, dom.Bloc AS DBloc, dom.Scara AS DScara, dom.Etaj AS DEtaj, dom.Apartament AS DApartament, 
                      res.TaraID AS RTaraID, res.Localitate AS RLocalitate, res.JudetSectorID AS RJudetSectorID, res.Strada AS RStrada, res.Numar AS RNumar, 
                      res.CodPostal AS RCodPostal, res.Bloc AS RBloc, res.Scara AS RScara, res.Etaj AS REtaj, res.Apartament AS RApartament, cai.CNP, cai.CNPAnterior, 
                      cai.Serie AS CISerie, cai.Numar AS CINumar, cai.EliberatDe AS CIEliberatDe, cai.DataEliberarii AS CIDataEliberarii, 
                      cai.ValabilPanaLa AS CIValabilPanaLa, pas.Serie AS PASSerie, pas.Numar AS PASNumar, pas.EliberatDe AS PASEliberatDe, 
                      pas.DataEliberarii AS PASDataEliberarii, pas.ValabilPanaLa AS PASValabilPanaLa, cam.Serie AS CMSerie, cam.Numar AS CMNumar, 
                      cam.Emitent AS CMEmitent, cam.DataEmiterii AS CMDataEmiterii, cam.NrInregITM AS CMNrInregITM, tia.Denumire AS TitluDenumire, 
                      tia.Simbol AS TitluSimbol, dep.Cod AS DepartamentCod, dep.Denumire AS DepartamentDenumire, fct.Cod AS FunctieCod, fct.Nume AS FunctieNume, 
                      icc.Cod AS CentruCostCod, icc.Nume AS CentruCostNume, dbo.Angajatori.Denumire AS NumeAngajator, ISNULL(ang.AreAlteVenituri, 0) AS AreVenituri, 
                      ISNULL(ang.SolicitaDeduceri, 0) AS AreDeduceri, fct.FunctieID, icc.CentruCostID, dep.DepartamentID, pem.PermisMuncaID, pem.NrPermisMunca, 
                      pem.SeriePermisMunca, pem.PermMuncaDataEliberare, pem.PermMuncaDataExpirare, les.LegitimatieSedereID, les.NrLegitimatieSedere, 
                      les.SerieLegitimatieSedere, les.LegitimatieSedereDataEliberare, les.LegitimatieSedereDataExpirare, nif.NIFID, nif.NIF, ang.*, Lich.LichidareID, 
                      Lich.NrInregistrare, Lich.DataLichidare, Lich.AvansuriDecontare, Lich.Abonamente, Lich.TicheteMasa, Lich.EchipamentLucru, Lich.Laptop, 
                      Lich.ObiecteInventar, Lich.TelServiciu, Lich.Carti, Lich.CD, Lich.DataInregistrare, Lich.NrArticol, Lich.LunaRetinere
FROM         dbo.Angajati ang INNER JOIN
                      dbo.Angajatori ON ang.AngajatorID = dbo.Angajatori.AngajatorID LEFT OUTER JOIN
                      dbo.Domicilii res ON ang.AngajatID = res.AngajatID AND res.Tip = 'r' LEFT OUTER JOIN
                      dbo.Domicilii dom ON ang.AngajatID = dom.AngajatID AND dom.Tip = 'd' LEFT OUTER JOIN
                      dbo.CarneteMunca cam ON ang.AngajatID = cam.AngajatID LEFT OUTER JOIN
                      dbo.TitluriAngajati tia ON tia.TitluID = ang.TitluID LEFT OUTER JOIN
                      dbo.IstoricCuDepartamente dep ON ang.AngajatID = dep.AngajatID AND dep.DataStart =
                          (SELECT     MAX(dep.DataStart)
                            FROM          IstoricCuDepartamente dep
                            WHERE      ang.AngajatID = dep.AngajatID) LEFT OUTER JOIN
                      dbo.IstoricCuFunctii fct ON ang.AngajatID = fct.AngajatID AND fct.DataStart =
                          (SELECT     MAX(fct.DataStart)
                            FROM          IstoricCuFunctii fct
                            WHERE      ang.AngajatID = fct.AngajatID) LEFT OUTER JOIN
                      dbo.IstoricCuCentreCost icc ON ang.AngajatID = icc.AngajatID AND icc.DataStart =
                          (SELECT     MAX(icc.DataStart)
                            FROM          IstoricCuCentreCost icc
                            WHERE      ang.AngajatID = icc.AngajatID) LEFT OUTER JOIN
                      dbo.CartiIdentitate cai ON ang.AngajatID = cai.AngajatID AND cai.Activ = 1 LEFT OUTER JOIN
                      dbo.Pasapoarte pas ON ang.AngajatID = pas.AngajatID AND pas.Activ = 1 LEFT OUTER JOIN
                      dbo.PermiseMunca pem ON ang.AngajatID = pem.AngajatID AND pem.Activ = 1 LEFT OUTER JOIN
                      dbo.LegitimatiiSedere les ON ang.AngajatID = les.AngajatID AND les.Activ = 1 LEFT OUTER JOIN
                      dbo.NIF nif ON ang.AngajatID = nif.AngajatID AND nif.Activ = 1 LEFT OUTER JOIN
                      dbo.Lichidare Lich ON ang.AngajatID = Lich.AngajatID
WHERE     (ang.Activ = 0) 