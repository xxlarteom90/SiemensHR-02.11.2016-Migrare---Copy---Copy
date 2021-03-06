IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'SiemensHR_Test')
	DROP DATABASE [SiemensHR_Test]
GO

CREATE DATABASE [SiemensHR_Test]  
 COLLATE SQL_Latin1_General_CP1_CI_AS
GO

exec sp_dboption N'SiemensHR_Test', N'autoclose', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'bulkcopy', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'trunc. log', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'torn page detection', N'true'
GO

exec sp_dboption N'SiemensHR_Test', N'read only', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'dbo use', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'single', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'autoshrink', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'ANSI null default', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'recursive triggers', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'ANSI nulls', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'concat null yields null', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'cursor close on commit', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'default to local cursor', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'quoted identifier', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'ANSI warnings', N'false'
GO

exec sp_dboption N'SiemensHR_Test', N'auto create statistics', N'true'
GO

exec sp_dboption N'SiemensHR_Test', N'auto update statistics', N'true'
GO

use [SiemensHR_Test]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricActivitati_Activitati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricActivitati] DROP CONSTRAINT FK_IstoricActivitati_Activitati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Conturi_Banci]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Conturi] DROP CONSTRAINT FK_Conturi_Banci
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ConturiAngajati_Banci]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ConturiAngajati] DROP CONSTRAINT FK_ConturiAngajati_Banci
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tm_IntervaleAbsenta_Boli]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tm_IntervaleAbsenta] DROP CONSTRAINT FK_tm_IntervaleAbsenta_Boli
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tm_IntervaleAbsentaContinuare_Boli]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tm_IntervaleAbsentaContinuare] DROP CONSTRAINT FK_tm_IntervaleAbsentaContinuare_Boli
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricCategoriiAngajati_Categorii]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricCategoriiAngajati] DROP CONSTRAINT FK_IstoricCategoriiAngajati_Categorii
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricCentreCost_CentreCost]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricCentreCost] DROP CONSTRAINT FK_IstoricCentreCost_CentreCost
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_AngajatiClauze_ClauzeSpeciale]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[AngajatiClauze] DROP CONSTRAINT FK_AngajatiClauze_ClauzeSpeciale
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricFunctii_Functii]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricFunctii] DROP CONSTRAINT FK_IstoricFunctii_Functii
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricGrupeMunca_GrupeMunca]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricGrupeMunca] DROP CONSTRAINT FK_IstoricGrupeMunca_GrupeMunca
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Salarii_DateSuplimentareLunare_GrupeMunca]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Salarii_DateSuplimentareLunare] DROP CONSTRAINT FK_Salarii_DateSuplimentareLunare_GrupeMunca
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricAngajatiInvaliditati_Invaliditati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricAngajatiInvaliditati] DROP CONSTRAINT FK_IstoricAngajatiInvaliditati_Invaliditati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Salarii_DateSuplimentareLunare_Invaliditati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Salarii_DateSuplimentareLunare] DROP CONSTRAINT FK_Salarii_DateSuplimentareLunare_Invaliditati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Angajatori_Judete]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Angajatori] DROP CONSTRAINT FK_Angajatori_Judete
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricLocMunca_LocuriMunca]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricLocMunca] DROP CONSTRAINT FK_IstoricLocMunca_LocuriMunca
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_DurateAngajare_ModalitatiLichidare]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[DurateAngajare] DROP CONSTRAINT FK_DurateAngajare_ModalitatiLichidare
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricReduceriImpozit_ReduceriImpozit]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricReduceriImpozit] DROP CONSTRAINT FK_IstoricReduceriImpozit_ReduceriImpozit
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_sal_BazeCalculLuna_Sal_Luni]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[sal_BazeCalculLuna] DROP CONSTRAINT FK_sal_BazeCalculLuna_Sal_Luni
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_sal_ContributiiIndivLuna_Sal_Luni]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[sal_ContributiiIndivLuna] DROP CONSTRAINT FK_sal_ContributiiIndivLuna_Sal_Luni
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Sal_Salarii_sal_luni]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Sal_Salarii] DROP CONSTRAINT FK_Sal_Salarii_sal_luni
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Sal_SituatieLunaraAngajati_sal_luni]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Sal_SituatieLunaraAngajati] DROP CONSTRAINT FK_Sal_SituatieLunaraAngajati_sal_luni
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_sal_StatDePlata_Sal_Luni]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[sal_StatDePlata] DROP CONSTRAINT FK_sal_StatDePlata_Sal_Luni
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_sal_VariabileGlobale_sal_luni1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[sal_VariabileGlobale] DROP CONSTRAINT FK_sal_VariabileGlobale_sal_luni1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_sal_VariabileGlobaleValori_Sal_Luni]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[sal_VariabileGlobaleValori] DROP CONSTRAINT FK_sal_VariabileGlobaleValori_Sal_Luni
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Salarii_CategoriiAngajati_sal_luni]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Salarii_CategoriiAngajati] DROP CONSTRAINT FK_Salarii_CategoriiAngajati_sal_luni
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricSalariiIncadrareAngajati_SalariiIncadrare]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricSalariiIncadrareAngajati] DROP CONSTRAINT FK_IstoricSalariiIncadrareAngajati_SalariiIncadrare
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Salarii_impozite_Salarii_AplicareSumeImpozit]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Salarii_impozite] DROP CONSTRAINT FK_Salarii_impozite_Salarii_AplicareSumeImpozit
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Salarii_SporuriLunare_Sporuri]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Salarii_SporuriLunare] DROP CONSTRAINT FK_Salarii_SporuriLunare_Sporuri
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_EvaluariPsihologice_TipuriRapoarte]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[EvaluariPsihologice] DROP CONSTRAINT FK_EvaluariPsihologice_TipuriRapoarte
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricTraininguri_Traininguri]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricTraining] DROP CONSTRAINT FK_IstoricTraininguri_Traininguri
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_sal_BazeCalculLuna_sal_BazeCalculTipuri]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[sal_BazeCalculLuna] DROP CONSTRAINT FK_sal_BazeCalculLuna_sal_BazeCalculTipuri
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_sal_ContributiiIndivLuna_sal_ContributiiIndivTipuri]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[sal_ContributiiIndivLuna] DROP CONSTRAINT FK_sal_ContributiiIndivLuna_sal_ContributiiIndivTipuri
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_sal_VariabileGlobaleValori_sal_VariabileGlobaleTipuri]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[sal_VariabileGlobaleValori] DROP CONSTRAINT FK_sal_VariabileGlobaleValori_sal_VariabileGlobaleTipuri
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tm_IntervaleAbsenta_tm_TipAbsente]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tm_IntervaleAbsenta] DROP CONSTRAINT FK_tm_IntervaleAbsenta_tm_TipAbsente
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Angajati_Angajatori]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Angajati] DROP CONSTRAINT FK_Angajati_Angajatori
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Conturi_Angajatori]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Conturi] DROP CONSTRAINT FK_Conturi_Angajatori
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Directori_Angajatori]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Directori] DROP CONSTRAINT FK_Directori_Angajatori
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricContracteAngajati_Angajatori]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricContracteAngajati] DROP CONSTRAINT FK_IstoricContracteAngajati_Angajatori
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_sal_BazeCalculLuna_Angajatori]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[sal_BazeCalculLuna] DROP CONSTRAINT FK_sal_BazeCalculLuna_Angajatori
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_sal_ContributiiIndivLuna_Angajatori]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[sal_ContributiiIndivLuna] DROP CONSTRAINT FK_sal_ContributiiIndivLuna_Angajatori
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricDurateAngajari_DurateAngajare]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricDurateAngajari] DROP CONSTRAINT FK_IstoricDurateAngajari_DurateAngajare
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Angajati_Salarii_CategoriiAngajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Angajati] DROP CONSTRAINT FK_Angajati_Salarii_CategoriiAngajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricContracteAngajati_Salarii_CategoriiAngajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricContracteAngajati] DROP CONSTRAINT FK_IstoricContracteAngajati_Salarii_CategoriiAngajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_sal_Impozitar_Salarii_CategoriiAngajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[sal_Impozitar] DROP CONSTRAINT FK_sal_Impozitar_Salarii_CategoriiAngajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Sal_SituatieLunaraAngajati_Salarii_CategoriiAngajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Sal_SituatieLunaraAngajati] DROP CONSTRAINT FK_Sal_SituatieLunaraAngajati_Salarii_CategoriiAngajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Salarii_DateSuplimentareLunare_Salarii_CategoriiAngajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Salarii_DateSuplimentareLunare] DROP CONSTRAINT FK_Salarii_DateSuplimentareLunare_Salarii_CategoriiAngajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Salarii_impozitar_Salarii_CategoriAngajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Salarii_impozitar] DROP CONSTRAINT FK_Salarii_impozitar_Salarii_CategoriAngajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Salarii_AsignareImpozite_Salarii_impozite]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Salarii_AsignareImpozite] DROP CONSTRAINT FK_Salarii_AsignareImpozite_Salarii_impozite
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Alerte_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Alerte] DROP CONSTRAINT FK_Alerte_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_AngajatiClauze_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[AngajatiClauze] DROP CONSTRAINT FK_AngajatiClauze_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_AngajatiIntreruperi_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[AngajatiIntreruperi] DROP CONSTRAINT FK_AngajatiIntreruperi_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_AngajatiRetineri_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[AngajatiRetineri] DROP CONSTRAINT FK_AngajatiRetineri_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_AngajatPersoaneInIntretinere_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[AngajatPersoaneInIntretinere] DROP CONSTRAINT FK_AngajatPersoaneInIntretinere_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CarneteMunca_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CarneteMunca] DROP CONSTRAINT FK_CarneteMunca_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Checkupuri_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Checkupuri] DROP CONSTRAINT FK_Checkupuri_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Checkupuri_Angajati1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Checkupuri] DROP CONSTRAINT FK_Checkupuri_Angajati1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_ConturiAngajati_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[ConturiAngajati] DROP CONSTRAINT FK_ConturiAngajati_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Departamente_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Departamente] DROP CONSTRAINT FK_Departamente_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Departamente_Angajati1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Departamente] DROP CONSTRAINT FK_Departamente_Angajati1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Directori_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Directori] DROP CONSTRAINT FK_Directori_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_EvaluariPsihologice_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[EvaluariPsihologice] DROP CONSTRAINT FK_EvaluariPsihologice_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricActivitati_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricActivitati] DROP CONSTRAINT FK_IstoricActivitati_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricAngajatDepartament_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricAngajatDepartament] DROP CONSTRAINT FK_IstoricAngajatDepartament_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricAngajatiInvaliditati_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricAngajatiInvaliditati] DROP CONSTRAINT FK_IstoricAngajatiInvaliditati_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricCategoriiAngajati_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricCategoriiAngajati] DROP CONSTRAINT FK_IstoricCategoriiAngajati_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricCentreCost_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricCentreCost] DROP CONSTRAINT FK_IstoricCentreCost_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricContracteAngajati_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricContracteAngajati] DROP CONSTRAINT FK_IstoricContracteAngajati_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricDurateAngajari_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricDurateAngajari] DROP CONSTRAINT FK_IstoricDurateAngajari_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricFunctii_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricFunctii] DROP CONSTRAINT FK_IstoricFunctii_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricGrupeMunca_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricGrupeMunca] DROP CONSTRAINT FK_IstoricGrupeMunca_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricLocMunca_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricLocMunca] DROP CONSTRAINT FK_IstoricLocMunca_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricReduceriImpozit_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricReduceriImpozit] DROP CONSTRAINT FK_IstoricReduceriImpozit_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricSalariiIncadrareAngajati_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricSalariiIncadrareAngajati] DROP CONSTRAINT FK_IstoricSalariiIncadrareAngajati_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricTraininguri_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricTraining] DROP CONSTRAINT FK_IstoricTraininguri_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Lichidare_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Lichidare] DROP CONSTRAINT FK_Lichidare_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Pasapoarte_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Pasapoarte] DROP CONSTRAINT FK_Pasapoarte_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Referinte_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Referinte] DROP CONSTRAINT FK_Referinte_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_sal_BazeCalculLuna_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[sal_BazeCalculLuna] DROP CONSTRAINT FK_sal_BazeCalculLuna_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_sal_ContributiiIndivLuna_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[sal_ContributiiIndivLuna] DROP CONSTRAINT FK_sal_ContributiiIndivLuna_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Sal_Salarii_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Sal_Salarii] DROP CONSTRAINT FK_Sal_Salarii_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Salarii_SituatieLunaraAngajati_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Sal_SituatieLunaraAngajati] DROP CONSTRAINT FK_Salarii_SituatieLunaraAngajati_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_sal_StatDePlata_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[sal_StatDePlata] DROP CONSTRAINT FK_sal_StatDePlata_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Salarii_DateSuplimentareLunare_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Salarii_DateSuplimentareLunare] DROP CONSTRAINT FK_Salarii_DateSuplimentareLunare_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Salarii_RetineriLunare_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Salarii_RetineriLunare] DROP CONSTRAINT FK_Salarii_RetineriLunare_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_AngajatiSporuri_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Salarii_SporuriLunare] DROP CONSTRAINT FK_AngajatiSporuri_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_SituatieMilitara_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[SituatieMilitara] DROP CONSTRAINT FK_SituatieMilitara_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tm_IntervaleAbsenta_Angajati]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tm_IntervaleAbsenta] DROP CONSTRAINT FK_tm_IntervaleAbsenta_Angajati
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_IstoricAngajatDepartament_Departamente]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[IstoricAngajatDepartament] DROP CONSTRAINT FK_IstoricAngajatDepartament_Departamente
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_tm_IntervaleAbsentaContinuare_tm_IntervaleAbsenta]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[tm_IntervaleAbsentaContinuare] DROP CONSTRAINT FK_tm_IntervaleAbsentaContinuare_tm_IntervaleAbsenta
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[doesTheEmployeWorkInLastMonths]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[doesTheEmployeWorkInLastMonths]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DiferenceBetweenTwoPeriods]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[DiferenceBetweenTwoPeriods]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[calculateAnualImpozit]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[calculateAnualImpozit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FormatData]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[FormatData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FormatDataFromString]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[FormatDataFromString]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IsDigit]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[IsDigit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RoundDownSumOfMoney]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[RoundDownSumOfMoney]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[RoundUpSumOfMoney]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[RoundUpSumOfMoney]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_ApartinePerioada]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[tm_ApartinePerioada]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_OreInterval]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[tm_OreInterval]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ComunicarePrima]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ComunicarePrima]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetA11]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetA11]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetA12]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetA12]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetA12_NRM]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetA12_NRM]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllAngajati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllAngajati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCap1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCap1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCap2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCap2]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetConducere]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetConducere]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDED_aaaa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDED_aaaa]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetFF1_aaaa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetFF1_aaaa]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetFF2_aaaa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetFF2_aaaa]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetAllAngForSal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetAllAngForSal]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetAllAngForVeniturDeduceri]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetAllAngForVeniturDeduceri]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetAllAngImpozitAnual]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetAllAngImpozitAnual]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmp_1111]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tmp_1111]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculAlteDrepturiBrut]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculAlteDrepturiBrut]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmp_InsertUpdateAngajat_010205]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tmp_InsertUpdateAngajat_010205]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetIstoricDepartamenteAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetIstoricDepartamenteAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteIstoricDepartament]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteIstoricDepartament]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[conturi_UpdateConturi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[conturi_UpdateConturi]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculBazaContributieIndivSomaj]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculBazaContributieIndivSomaj]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculCompletRestDePlata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculCompletRestDePlata]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculDateSalariuAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculDateSalariuAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGetStatDePlata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGetStatDePlata]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntervaleAbsentaMedicalaContinuare]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntervaleAbsentaMedicalaContinuare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_InsertUpdateDeleteIntervalAbsentaMedicalaContinuare]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_InsertUpdateDeleteIntervalAbsentaMedicalaContinuare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClearSalarii]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ClearSalarii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountConturiPerBanca]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountConturiPerBanca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatConturiBanca]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatConturiBanca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatFunctii]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatFunctii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatPersoaneInIntretinere]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatPersoaneInIntretinere]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAniSal_Salarii]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAniSal_Salarii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCheckupuriAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCheckupuriAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDepartamente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDepartamente]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetEvaluariPsihologiceAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetEvaluariPsihologiceAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetIntervalAngajatIntrerupereByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetIntervalAngajatIntrerupereByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetIntervaleAngajatIntreruperi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetIntervaleAngajatIntreruperi]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetIntervaleAngajatIntreruperiLuna]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetIntervaleAngajatIntreruperiLuna]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetIstoricCategoriiAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetIstoricCategoriiAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetIstoricCentreCostAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetIstoricCentreCostAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetIstoricFunctiiAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetIstoricFunctiiAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetIstoricTrainingAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetIstoricTrainingAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLuni_An]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLuni_An]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPasapoarteAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPasapoarteAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetReferinteAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetReferinteAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Get_imp100T_sums]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Get_imp100T_sums]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateCarnetMunca]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateCarnetMunca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteAngajatIntreruperi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteAngajatIntreruperi]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteCheckup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteCheckup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteContAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteContAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteDepartament]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteDepartament]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteEvaluarePsihologica]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteEvaluarePsihologica]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteIstoricCategorie]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteIstoricCategorie]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteIstoricCentruCost]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteIstoricCentruCost]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteIstoricFunctie]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteIstoricFunctie]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteIstoricTraining]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteIstoricTraining]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteLichidareAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteLichidareAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeletePasaport]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeletePasaport]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteReferinta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteReferinta]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdatePasaport]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdatePasaport]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateSituatieMilitara]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateSituatieMilitara]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PersoanaInIntretinereById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[PersoanaInIntretinereById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateContAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateContAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[conturi_SetCurrentContID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[conturi_SetCurrentContID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[insertAlerte]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[insertAlerte]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_DeletePersoanaInIntretinere]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_DeletePersoanaInIntretinere]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_DeleteSalariu]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_DeleteSalariu]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetAllAngLuniPeTrim]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetAllAngLuniPeTrim]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetAllSituatiiLunare]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetAllSituatiiLunare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetLuniLucrPeTrim]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetLuniLucrPeTrim]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetSalariuID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetSalariuID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_InsertPersoanaInIntretinere]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_InsertPersoanaInIntretinere]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_InsertSalarii]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_InsertSalarii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_InsertUpdateDeleteSituatieLunaraAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_InsertUpdateDeleteSituatieLunaraAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_UpdatePersoanaInIntretinere]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_UpdatePersoanaInIntretinere]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculBazaCalculFondSolidaritateUnitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculBazaCalculFondSolidaritateUnitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculCompletVenitBrut]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculCompletVenitBrut]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculRetineriAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculRetineriAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculTarifOrarAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculTarifOrarAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculVenitBrutAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculVenitBrutAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalcullNumarZileBoalaInUltimeleLuni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalcullNumarZileBoalaInUltimeleLuni]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDeleteSalariuLunaAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spDeleteSalariuLunaAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGetAllAngajatiIDs]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGetAllAngajatiIDs]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spGetStatDePlataInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spGetStatDePlataInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spInsertStatDePlata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spInsertStatDePlata]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spUpdateStatDePlata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spUpdateStatDePlata]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_DeleteIntervaleAngajatPerioada]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_DeleteIntervaleAngajatPerioada]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_DeleteIntervaleAngajatPerioadaTemporar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_DeleteIntervaleAngajatPerioadaTemporar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetAngajatNrZileAbsentePerioada]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetAngajatNrZileAbsentePerioada]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntervalAbsentaByDataEnd]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntervalAbsentaByDataEnd]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntervalAbsentaByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntervalAbsentaByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntervalAbsentaContinuari]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntervalAbsentaContinuari]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntervaleAbsenta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntervaleAbsenta]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntervaleAbsentaCM]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntervaleAbsentaCM]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntervaleAbsentaLuna]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntervaleAbsentaLuna]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntervaleAbsentaMedicalaContinuareLuna]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntervaleAbsentaMedicalaContinuareLuna]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntervaleAbsentaSiEmergencyLuna]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntervaleAbsentaSiEmergencyLuna]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntervaleAbsentaTip]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntervaleAbsentaTip]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntervaleAbsentaZi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntervaleAbsentaZi]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntreruperiLuna]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntreruperiLuna]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_InsertUpdateDeleteIntervalAbsenta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_InsertUpdateDeleteIntervalAbsenta]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CheckDateAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CheckDateAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CheckDateAngajatForUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CheckDateAngajatForUpdate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountAngajatiPerAngajator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountAngajatiPerAngajator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatVechimeInMunca]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatVechimeInMunca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatiCuFctDeBaza]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatiCuFctDeBaza]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatiFaraFctDeBaza]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatiFaraFctDeBaza]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetImpoziteCategorie]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetImpoziteCategorie]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteCategorieSalarii]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteCategorieSalarii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteCont]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteCont]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteImpozitar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteImpozitar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteIstoricContracteAngajati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteIstoricContracteAngajati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ScrieNumeIntreg]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ScrieNumeIntreg]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SeteazaInactivAngajatiExpiraContractLunaCurenta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SeteazaInactivAngajatiExpiraContractLunaCurenta]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdateAngajatDateSchimbate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdateAngajatDateSchimbate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[UpdatePozaAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[UpdatePozaAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_CopySetariSalarii_LunaActiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_CopySetariSalarii_LunaActiva]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_CopySetariSalarii_LunaActiva2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_CopySetariSalarii_LunaActiva2]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_DeleteImpozitar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_DeleteImpozitar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetAllImpozitar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetAllImpozitar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetAngajati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetAngajati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetImpozitar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetImpozitar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetImpozitarById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetImpozitarById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_InsertImpozitar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_InsertImpozitar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_UpdateImpozitar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_UpdateImpozitar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_UpdateIndexare]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_UpdateIndexare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_UpdateMajorari]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_UpdateMajorari]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculAsigurariSocialeUnitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculAsigurariSocialeUnitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculBazaCalculDirectiaDeMuncaUnitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculBazaCalculDirectiaDeMuncaUnitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculBazaCalculFondRiscUnitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculBazaCalculFondRiscUnitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculBazaCalculSanatateUnitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculBazaCalculSanatateUnitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculDeduceriPersonale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculDeduceriPersonale]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculImpozit]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculImpozit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_UpdatePerioadaZileCategorieIDAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_UpdatePerioadaZileCategorieIDAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_UpdatePerioadaZileIndeminzatieConducereAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_UpdatePerioadaZileIndeminzatieConducereAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_UpdatePerioadaZileInvaliditateAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_UpdatePerioadaZileInvaliditateAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_UpdatePerioadaZileNormaLucruAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_UpdatePerioadaZileNormaLucruAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_UpdatePerioadaZileSalariuBazaActualAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_UpdatePerioadaZileSalariuBazaActualAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmp_proc1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tmp_proc1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatorInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatorInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDomDeActivitateAngajator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDomDeActivitateAngajator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetInfoSalariiImpozite]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetInfoSalariiImpozite]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetIstoricSchimbariAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetIstoricSchimbariAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetIstoricSchimbariLunaAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetIstoricSchimbariLunaAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetREP_aaaa]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetREP_aaaa]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertAngajatorWithIDReturn]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertAngajatorWithIDReturn]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateConcediuMedicZilePlatite]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateConcediuMedicZilePlatite]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteAngajator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteAngajator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteImpozit]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteImpozit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetAllImpozitarAnual]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetAllImpozitarAnual]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_InsertUpdateDeleteCategorieAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_InsertUpdateDeleteCategorieAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_InsertUpdateDeleteVariabileGlobale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_InsertUpdateDeleteVariabileGlobale]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[salarii_GetAngajatiCategoriiLunaActiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[salarii_GetAngajatiCategoriiLunaActiva]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[salarii_GetCategorie]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[salarii_GetCategorie]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculBazaCalcAsigSocialeAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculBazaCalcAsigSocialeAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculContributieIndivAsigSanatate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculContributieIndivAsigSanatate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculContributieIndivAsigSociale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculContributieIndivAsigSociale]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculContributieIndivSomaj]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculContributieIndivSomaj]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CheckIfDomDeActCanBeDeleted]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CheckIfDomDeActCanBeDeleted]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CheckIfToateFunctiileAuCodSiemens]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CheckIfToateFunctiileAuCodSiemens]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CheckInsertConcediiMedic]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CheckInsertConcediiMedic]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CoeficientDeduceri]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CoeficientDeduceri]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllDomeniiDeActivitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllDomeniiDeActivitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllInvaliditati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllInvaliditati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAllLuni_An]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAllLuni_An]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCategorii]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCategorii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetConcediiMedicale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetConcediiMedicale]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDomDeActDisponibilePtAngajator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDomDeActDisponibilePtAngajator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDomDeActivitateAngajatorInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDomDeActivitateAngajatorInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetDomeniuDeActivitateInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetDomeniuDeActivitateInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLegitimatiiSedereAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLegitimatiiSedereAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLunaDetaliiByData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLunaDetaliiByData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLunaPrecedenta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLunaPrecedenta]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetLuniSalarii]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetLuniSalarii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetNIFuriAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetNIFuriAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetNrZileConcediuBoalaLunaFirma]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetNrZileConcediuBoalaLunaFirma]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetNrZileLucratoare]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetNrZileLucratoare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetNrZilePlatiteConcediuMedical]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetNrZilePlatiteConcediuMedical]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPermiseMuncaAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPermiseMuncaAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetTaraDeBaza]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetTaraDeBaza]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetUltimileSaseLuni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetUltimileSaseLuni]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateActivitati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateActivitati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateBazaDateCAS]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateBazaDateCAS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteBanca]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteBanca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteBoala]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteBoala]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteCategorie]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteCategorie]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteCentruCost]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteCentruCost]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteDomDeActivitateAngajator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteDomDeActivitateAngajator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteDomeniuDeActivitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteDomeniuDeActivitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteFunctie]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteFunctie]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteGrupaMunca]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteGrupaMunca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteInvaliditate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteInvaliditate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteJudet]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteJudet]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteLegitimatieSedere]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteLegitimatieSedere]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteLocMunca]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteLocMunca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteNIF]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteNIF]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeletePermisMunca]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeletePermisMunca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteStudiu]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteStudiu]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteTara]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteTara]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteTipRaport]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteTipRaport]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteTraining]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteTraining]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDomiciliu]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDomiciliu]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateSarbatoriLegale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateSarbatoriLegale]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Reports_GetAllReportFields]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Reports_GetAllReportFields]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Reports_GetAllReportFieldsNames]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Reports_GetAllReportFieldsNames]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Reports_GetAllReportNames]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Reports_GetAllReportNames]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Reports_GetDetailReportFields]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Reports_GetDetailReportFields]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Reports_GetDetailReports]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Reports_GetDetailReports]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Reports_UpdateReportFields]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[Reports_UpdateReportFields]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SetActivAllLegitimatiiSedereAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SetActivAllLegitimatiiSedereAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SetActivAllNIFAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SetActivAllNIFAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SetActivAllPermiseMuncaAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SetActivAllPermiseMuncaAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_DeleteCoef]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_DeleteCoef]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_DeleteImpozitarAnual]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_DeleteImpozitarAnual]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetAllCoeficienti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetAllCoeficienti]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetCoeficienti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetCoeficienti]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetCoeficientiID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetCoeficientiID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetImpozitarAnual]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetImpozitarAnual]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetImpozitarAnualById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetImpozitarAnualById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetLunaActiva]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetLunaActiva]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetLunaInflById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetLunaInflById]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetLuni]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetLuni]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetProcInflTrim]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetProcInflTrim]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_InsertCheltuileiDeduceri]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_InsertCheltuileiDeduceri]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_InsertCoef]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_InsertCoef]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_InsertContributiiAngajator]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_InsertContributiiAngajator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_InsertImpozitarAnual]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_InsertImpozitarAnual]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_InsertUpdateDeleteLuna]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_InsertUpdateDeleteLuna]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_UpdateCoef]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_UpdateCoef]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_UpdateImpozitarAnual]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_UpdateImpozitarAnual]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[salarii_GetInflatii]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[salarii_GetInflatii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[salarii_GetInvaliditati]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[salarii_GetInvaliditati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[salarii_InsertInflatii]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[salarii_InsertInflatii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[salarii_updateInflatii]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[salarii_updateInflatii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculIndemnizatieConcediuMedicalAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculIndemnizatieConcediuMedicalAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_DeleteDefinitivIntervaleAngajatPerioadaTemporar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_DeleteDefinitivIntervaleAngajatPerioadaTemporar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_DeleteIntervaleTipAngajatPerioada]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_DeleteIntervaleTipAngajatPerioada]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_DeleteIntervaleVizibileAngajatPerioada]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_DeleteIntervaleVizibileAngajatPerioada]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_DeleteSchimbareAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_DeleteSchimbareAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetAngajatNrOreTipLucrate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetAngajatNrOreTipLucrate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetAngajatZileOreTipLucratePerioada]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetAngajatZileOreTipLucratePerioada]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetCapatIntervalAngajatZi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetCapatIntervalAngajatZi]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetCodBoala]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetCodBoala]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntervaleLucratePerioada]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntervaleLucratePerioada]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntervaleTipZi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntervaleTipZi]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetIntervaleZi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetIntervaleZi]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetLuna]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetLuna]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetNrOreTipPerioada]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetNrOreTipPerioada]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetNrOreTipPerioadaFaraInterval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetNrOreTipPerioadaFaraInterval]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetSetareInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetSetareInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetTipInterval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetTipInterval]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetTipIntervalAbsenta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetTipIntervalAbsenta]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetTipuriAbsente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetTipuriAbsente]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetTipuriIntervale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetTipuriIntervale]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetTipuriIntervaleSuplimentare]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetTipuriIntervaleSuplimentare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetZiAngajatInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetZiAngajatInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetZiDetaliu]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetZiDetaliu]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetZiIntervalApartenentaInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetZiIntervalApartenentaInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetZileLucratoareLuna]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetZileLucratoareLuna]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetZileLucratoarePerioada]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetZileLucratoarePerioada]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetZileLuna]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetZileLuna]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetZileLunaAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetZileLunaAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetZileLunaImposibile]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetZileLunaImposibile]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetZileLunaIntrerupereContract]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetZileLunaIntrerupereContract]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetZileLunaPosibile]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetZileLunaPosibile]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetZileSarbatoareInterval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetZileSarbatoareInterval]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetZileWeekendPosibileLunaAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetZileWeekendPosibileLunaAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_InsertUpdateDeleteCapatIntervalAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_InsertUpdateDeleteCapatIntervalAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_InsertUpdateDeleteIntervalAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_InsertUpdateDeleteIntervalAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_InsertUpdateDeleteSetare]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_InsertUpdateDeleteSetare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_InsertUpdateDeleteTipAbsenta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_InsertUpdateDeleteTipAbsenta]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_InsertUpdateDeleteTipInterval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_InsertUpdateDeleteTipInterval]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_InsertUpdateDeleteZi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_InsertUpdateDeleteZi]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_RestoreIntervaleAngajatPerioadaSterseTemporar]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_RestoreIntervaleAngajatPerioadaSterseTemporar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_SetZiTipSarbatoare]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_SetZiTipSarbatoare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CautareAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CautareAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CountSalIncome]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CountSalIncome]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CreateBackup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CreateBackup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAlertaInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAlertaInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatAlerte]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatAlerte]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatiAlerteSpeciale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatiAlerteSpeciale]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatiExpiraContractLunaCurenta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatiExpiraContractLunaCurenta]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatiExpiraDataMajorare]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatiExpiraDataMajorare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatiExpiraPasaport]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatiExpiraPasaport]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatiExpiraPermisMunca]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatiExpiraPermisMunca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetAngajatiExpiraPermisSedere]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetAngajatiExpiraPermisSedere]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetCartiIdentitateAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetCartiIdentitateAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPersoaneCareAuTrecutLaAltaNorma]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPersoaneCareAuTrecutLaAltaNorma]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPersoaneCareIesDinActivitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPersoaneCareIesDinActivitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetPersoaneCareIntraInActivitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetPersoaneCareIntraInActivitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetSarbatoriLegale]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[GetSarbatoriLegale]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateCarteIdentitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateCarteIdentitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteAlerte]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteAlerte]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteCarteIdentitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteCarteIdentitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertUpdateDeleteTitluAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertUpdateDeleteTitluAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IsDaySarbatoare]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[IsDaySarbatoare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SetActivAllCartiIdentitateAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SetActivAllCartiIdentitateAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[StoredProcedure1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[StoredProcedure1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[describe]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[describe]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetSituatieLunaraAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetSituatieLunaraAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_GetSituatieLunaraAngajatByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_GetSituatieLunaraAngajatByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_InsertLuniInfl]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_InsertLuniInfl]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_UpdatePrimaSpeciala]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sal_UpdatePrimaSpeciala]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculBazaCalcAsigDeSanatateAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculBazaCalcAsigDeSanatateAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculBazaCalcAsigSocialeUnitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculBazaCalcAsigSocialeUnitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculContributieAsigSocialeUnitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculContributieAsigSocialeUnitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculContributieFondSolidaritateUnitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculContributieFondSolidaritateUnitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculContributieSanatateConcediiBoalaUnitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculContributieSanatateConcediiBoalaUnitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculContributieSanatateUnitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculContributieSanatateUnitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculContributieSomajUnitate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculContributieSomajUnitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculRestPlata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculRestPlata]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculSalariuNet]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculSalariuNet]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculVenitImpozabil]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculVenitImpozabil]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spCalculVenitNet]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spCalculVenitNet]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[spDeleteStatDePlata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[spDeleteStatDePlata]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_EsteZiSarbatoare]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_EsteZiSarbatoare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetOreLuna]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetOreLuna]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetOreLunaTipInterval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetOreLunaTipInterval]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetOreZi]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetOreZi]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetOreZiTipInterval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetOreZiTipInterval]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetZileLunaAbsenta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetZileLunaAbsenta]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_GetZileLunaTipAbsenta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tm_GetZileLunaTipAbsenta]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tmp_CautareAngajat]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[tmp_CautareAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AngajatFull]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[AngajatFull]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricCuDepartamente]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[IstoricCuDepartamente]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AngajatiFaraCardBancar]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[AngajatiFaraCardBancar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricCuCentreCost]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[IstoricCuCentreCost]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricCuFunctii]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[IstoricCuFunctii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[v_StatDePlata]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[v_StatDePlata]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GetFullAngajatoriInfo]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[GetFullAngajatoriInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricAngajatDepartament]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IstoricAngajatDepartament]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_IntervaleAbsentaContinuare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tm_IntervaleAbsentaContinuare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Alerte]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Alerte]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AngajatPersoaneInIntretinere]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AngajatPersoaneInIntretinere]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AngajatiClauze]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AngajatiClauze]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AngajatiIntreruperi]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AngajatiIntreruperi]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AngajatiRetineri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[AngajatiRetineri]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CarneteMunca]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CarneteMunca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Checkupuri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Checkupuri]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ConturiAngajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ConturiAngajati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Departamente]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Departamente]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Directori]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Directori]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EvaluariPsihologice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[EvaluariPsihologice]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricActivitati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IstoricActivitati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricAngajatiInvaliditati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IstoricAngajatiInvaliditati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricCategoriiAngajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IstoricCategoriiAngajati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricCentreCost]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IstoricCentreCost]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricContracteAngajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IstoricContracteAngajati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricDurateAngajari]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IstoricDurateAngajari]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricFunctii]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IstoricFunctii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricGrupeMunca]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IstoricGrupeMunca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricLocMunca]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IstoricLocMunca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricReduceriImpozit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IstoricReduceriImpozit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricSalariiIncadrareAngajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IstoricSalariiIncadrareAngajati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricTraining]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[IstoricTraining]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Lichidare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Lichidare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Pasapoarte]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Pasapoarte]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Referinte]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Referinte]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sal_Salarii]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Sal_Salarii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sal_SituatieLunaraAngajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Sal_SituatieLunaraAngajati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_DateSuplimentareLunare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Salarii_DateSuplimentareLunare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_RetineriLunare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Salarii_RetineriLunare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_SporuriLunare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Salarii_SporuriLunare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SituatieMilitara]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SituatieMilitara]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_BazeCalculLuna]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sal_BazeCalculLuna]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_ContributiiIndivLuna]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sal_ContributiiIndivLuna]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_StatDePlata]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sal_StatDePlata]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_IntervaleAbsenta]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tm_IntervaleAbsenta]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Angajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Angajati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Conturi]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Conturi]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_AsignareImpozite]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Salarii_AsignareImpozite]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_impozitar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Salarii_impozitar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_Impozitar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sal_Impozitar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Angajatori]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Angajatori]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DurateAngajare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DurateAngajare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_CategoriiAngajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Salarii_CategoriiAngajati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_impozite]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Salarii_impozite]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_VariabileGlobale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sal_VariabileGlobale]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_VariabileGlobaleValori]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sal_VariabileGlobaleValori]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Activitati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Activitati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Banci]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Banci]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BazaDateCAS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[BazaDateCAS]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Boli]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Boli]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Calendar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Calendar]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CartiIdentitate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CartiIdentitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Categorii]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Categorii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CentreCost]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CentreCost]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClauzeSpeciale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ClauzeSpeciale]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Coeficienti]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Coeficienti]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ConcediuMedicZilePlatite]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ConcediuMedicZilePlatite]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DomDeActivitateAngajator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DomDeActivitateAngajator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DomeniiDeActivitate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[DomeniiDeActivitate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Domicilii]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Domicilii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Functii]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Functii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GrupeMunca]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[GrupeMunca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ImpozitAnual]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ImpozitAnual]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Intreruperi]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Intreruperi]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Invaliditati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Invaliditati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Judete]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Judete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LegitimatiiSedere]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[LegitimatiiSedere]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LocuriMunca]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[LocuriMunca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Luni_Text]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Luni_Text]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ModalitatiLichidare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ModalitatiLichidare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[NIF]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[NIF]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ObligatiiDecl100]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ObligatiiDecl100]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ParametriImpozitAnual]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ParametriImpozitAnual]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PermiseMunca]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[PermiseMunca]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ReduceriImpozit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ReduceriImpozit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ReportFields]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ReportFields]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Reports]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Reports]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sal_Luni]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Sal_Luni]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Salarii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SalariiIncadrare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SalariiIncadrare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_AplicareSumeImpozit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Salarii_AplicareSumeImpozit]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_VariabileGlobale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Salarii_VariabileGlobale]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SarbatoriLegale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SarbatoriLegale]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sporuri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Sporuri]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Studii]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Studii]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Tari]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Tari]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TipuriPersoaneInIntretinere]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TipuriPersoaneInIntretinere]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TipuriRapoarte]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TipuriRapoarte]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TitluriAngajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[TitluriAngajati]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Traininguri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Traininguri]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_Angajator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sal_Angajator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_BazeCalculTipuri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sal_BazeCalculTipuri]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_ContributiiIndivTipuri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sal_ContributiiIndivTipuri]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_VariabileGlobaleTipuri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sal_VariabileGlobaleTipuri]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_impozitar_anual]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[sal_impozitar_anual]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[temp_CountSall]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[temp_CountSall]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_IntervaleAngajat]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tm_IntervaleAngajat]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_Setari]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tm_Setari]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_TipAbsente]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tm_TipAbsente]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_TipIntervale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tm_TipIntervale]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_zile]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[tm_zile]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xxx]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xxx]
GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Activitati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Activitati] (
	[ActivitateID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Nume] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Banci]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Banci] (
	[BancaID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[CodBanca] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Nume] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Filiala] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[BazaDateCAS]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[BazaDateCAS] (
	[ID_Angajat] [bigint] NOT NULL ,
	[ID_Luna] [int] NOT NULL ,
	[ValCAS] [float] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Boli]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Boli] (
	[BoalaID] [int] IDENTITY (1, 1) NOT NULL ,
	[Cod] [nvarchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Categorie] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Procent] [real] NULL ,
	[Stagiu] [varchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Calendar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Calendar] (
	[DataID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Data] [datetime] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CartiIdentitate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[CartiIdentitate] (
	[CarteIdentitateID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[CNP] [bigint] NULL ,
	[CNPAnterior] [bigint] NULL ,
	[Serie] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Numar] [varchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[EliberatDe] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DataEliberarii] [datetime] NULL ,
	[ValabilPanaLa] [datetime] NULL ,
	[Activ] [bit] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Categorii]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Categorii] (
	[CategorieID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Nume] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CentreCost]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[CentreCost] (
	[CentruCostID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Cod] [numeric](6, 0) NOT NULL ,
	[Nume] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClauzeSpeciale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[ClauzeSpeciale] (
	[ClauzaSpecialaID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Descriere] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Coeficienti]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Coeficienti] (
	[SetID] [int] IDENTITY (1, 1) NOT NULL ,
	[DeLa] [datetime] NOT NULL ,
	[Deducere] [money] NOT NULL ,
	[CoefInvalidGrd1] [decimal](18, 2) NOT NULL ,
	[CoefInvalidGrd2] [decimal](18, 2) NOT NULL ,
	[CoefCopil12] [decimal](18, 2) NOT NULL ,
	[CoefCopil3] [decimal](18, 2) NOT NULL ,
	[CoefUrmCopil] [decimal](18, 2) NOT NULL ,
	[CoefSot] [decimal](18, 2) NOT NULL ,
	[CoefTotal] [decimal](18, 2) NOT NULL ,
	[CoefSanatate] [decimal](18, 2) NOT NULL ,
	[CoefPensie] [decimal](18, 2) NOT NULL ,
	[CoefSomaj] [decimal](18, 2) NOT NULL ,
	[CoefCheltProf] [decimal](18, 2) NOT NULL ,
	[CASAngajator] [decimal](18, 2) NOT NULL ,
	[SanatateAngajator] [decimal](18, 2) NOT NULL ,
	[SomajAngajator] [decimal](18, 2) NOT NULL ,
	[FondRiscAngajator] [decimal](18, 2) NOT NULL ,
	[CartiCameraMunca] [bit] NOT NULL ,
	[CartiCamera] [decimal](18, 2) NOT NULL ,
	[CartiAngajator] [decimal](18, 2) NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ConcediuMedicZilePlatite]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[ConcediuMedicZilePlatite] (
	[id_Criteriu] [int] NOT NULL ,
	[ValMinimAngajati] [int] NOT NULL ,
	[ValMaximAngajati] [int] NOT NULL ,
	[NrZilePlatite] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DomDeActivitateAngajator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[DomDeActivitateAngajator] (
	[DomeniuAngajatorID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatorID] [int] NOT NULL ,
	[DomDeActivitateID] [int] NOT NULL ,
	[Principal] [bit] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DomeniiDeActivitate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[DomeniiDeActivitate] (
	[DomDeActivitateID] [int] IDENTITY (1, 1) NOT NULL ,
	[CodCAEN] [int] NOT NULL ,
	[Denumire] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Domicilii]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Domicilii] (
	[AngajatID] [int] NOT NULL ,
	[TaraID] [int] NOT NULL ,
	[Localitate] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[JudetSectorID] [int] NOT NULL ,
	[Strada] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Numar] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CodPostal] [numeric](18, 0) NULL ,
	[Bloc] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Scara] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Etaj] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Apartament] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Tip] [varchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Functii]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Functii] (
	[FunctieID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Cod] [numeric](6, 0) NOT NULL ,
	[CodSiemens] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Nume] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[NormaLucru] [tinyint] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[GrupeMunca]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[GrupeMunca] (
	[GrupaMuncaID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Nume] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ImpozitAnual]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[ImpozitAnual] (
	[AngajatID] [int] NOT NULL ,
	[ImpozitAnual] [money] NOT NULL ,
	[SumaRecuperat] [money] NOT NULL ,
	[SumaRestituit] [money] NOT NULL ,
	[ImpozitLunarCumulat] [money] NOT NULL ,
	[An] [numeric](18, 0) NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Intreruperi]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Intreruperi] (
	[IntrerupereID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[DataStop] [datetime] NOT NULL ,
	[Descriere] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Invaliditati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Invaliditati] (
	[InvaliditateID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Nume] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Coeficient] [numeric](5, 2) NOT NULL ,
	[Cod] [smallint] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Judete]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Judete] (
	[JudetID] [int] IDENTITY (1, 1) NOT NULL ,
	[Simbol] [char] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Nume] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[TaraID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LegitimatiiSedere]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[LegitimatiiSedere] (
	[LegitimatieSedereID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[NrLegitimatieSedere] [bigint] NOT NULL ,
	[SerieLegitimatieSedere] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[LegitimatieSedereDataEliberare] [datetime] NOT NULL ,
	[LegitimatieSedereDataExpirare] [datetime] NOT NULL ,
	[Activ] [bit] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LocuriMunca]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[LocuriMunca] (
	[LocMuncaID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Nume] [nvarchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Luni_Text]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Luni_Text] (
	[LunaTextID] [int] IDENTITY (1, 1) NOT NULL ,
	[Denumire] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ModalitatiLichidare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[ModalitatiLichidare] (
	[ModLichidareID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Nume] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[NIF]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[NIF] (
	[NIFID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[NIF] [bigint] NOT NULL ,
	[Activ] [bit] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ObligatiiDecl100]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[ObligatiiDecl100] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Nr] [int] NOT NULL ,
	[Cod] [nvarchar] (30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Denumire] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Model] [tinyint] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ParametriImpozitAnual]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[ParametriImpozitAnual] (
	[CheltuieliProfesionale] [float] NOT NULL ,
	[Deduceri] [money] NOT NULL ,
	[An] [numeric](18, 0) NOT NULL ,
	[ParametriID] [int] IDENTITY (1, 1) NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PermiseMunca]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[PermiseMunca] (
	[PermisMuncaID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[NrPermisMunca] [bigint] NOT NULL ,
	[SeriePermisMunca] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[PermMuncaDataEliberare] [datetime] NOT NULL ,
	[PermMuncaDataExpirare] [datetime] NOT NULL ,
	[Activ] [bit] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ReduceriImpozit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[ReduceriImpozit] (
	[ReducereImpozitID] [int] NOT NULL ,
	[Procent] [tinyint] NOT NULL ,
	[Descriere] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ReportFields]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[ReportFields] (
	[ID] [bigint] IDENTITY (1, 1) NOT NULL ,
	[ReportID] [int] NOT NULL ,
	[Label] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Data] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Data2] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[IsVisible] [bit] NOT NULL ,
	[MapToRptField] [int] NOT NULL ,
	[StartFromIdx] [int] NULL ,
	[ColumnWidth] [numeric](18, 2) NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Reports]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Reports] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Description] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TemplateFileName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[OutputFileName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sal_Luni]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Sal_Luni] (
	[Data] [datetime] NOT NULL ,
	[Activ] [bit] NOT NULL ,
	[ProcentInflatie] [float] NOT NULL ,
	[LunaID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatorID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Salarii] (
	[data_salariu] [datetime] NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[salariu_platit] [money] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SalariiIncadrare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[SalariiIncadrare] (
	[SalariuIncadrareID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[SalariuIncadrare] [money] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_AplicareSumeImpozit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Salarii_AplicareSumeImpozit] (
	[AplicatLaID] [int] IDENTITY (1, 1) NOT NULL ,
	[DenumireSuma] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_VariabileGlobale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Salarii_VariabileGlobale] (
	[SumaNeimpozabila] [decimal](18, 3) NOT NULL ,
	[DeducerePersonalaBaza] [decimal](18, 3) NOT NULL ,
	[CheltuieliProfesionale] [decimal](6, 3) NOT NULL ,
	[SalariulMediu] [decimal](18, 3) NOT NULL ,
	[CategorieID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SarbatoriLegale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[SarbatoriLegale] (
	[Denumirea] [char] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descrierea] [char] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Data] [datetime] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sporuri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Sporuri] (
	[SporID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Nume] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Procent] [int] NULL ,
	[Valoare] [money] NULL ,
	[EProcent] [bit] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Studii]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Studii] (
	[StudiuID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Nume] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Tari]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Tari] (
	[TaraID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[NumeTara] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Simbol] [nvarchar] (4) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Nationalitate] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TaraDeBaza] [bit] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TipuriPersoaneInIntretinere]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[TipuriPersoaneInIntretinere] (
	[TipPersoanaID] [smallint] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Descriere] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Coeficient] [numeric](4, 2) NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TipuriRapoarte]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[TipuriRapoarte] (
	[TipRaportID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Denumire] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[TitluriAngajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[TitluriAngajati] (
	[TitluID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Denumire] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Simbol] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Traininguri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Traininguri] (
	[TrainingID] [int] IDENTITY (1, 1) NOT NULL ,
	[Nume] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Diploma] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Intern] [bit] NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_Angajator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[sal_Angajator] (
	[ID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[LunaID] [int] NOT NULL ,
	[AngajatorID] [int] NOT NULL ,
	[CentruCostID] [int] NOT NULL ,
	[CASAngajator] [money] NOT NULL ,
	[SanatateAngajator] [money] NOT NULL ,
	[SomajAngajator] [money] NOT NULL ,
	[FondRiscAngajator] [money] NOT NULL ,
	[CameraMuncaAngajator] [money] NOT NULL ,
	[SolidaritHandicap] [money] NOT NULL ,
	[BenefAjutorSomaj] [tinyint] NOT NULL ,
	[CASTot] [money] NOT NULL ,
	[BASS] [money] NOT NULL ,
	[NRCAZB] [tinyint] NOT NULL ,
	[NRCAZA] [tinyint] NOT NULL ,
	[NRCAZP] [tinyint] NOT NULL ,
	[NRCAZL] [tinyint] NOT NULL ,
	[NRCAZI] [tinyint] NOT NULL ,
	[NRCAZC] [tinyint] NOT NULL ,
	[NRCAZD] [tinyint] NOT NULL ,
	[NRCAZR] [tinyint] NOT NULL ,
	[NRPPB] [tinyint] NOT NULL ,
	[NRPPA] [tinyint] NOT NULL ,
	[NRPPP] [tinyint] NOT NULL ,
	[NRPPL] [tinyint] NOT NULL ,
	[NRPPI] [tinyint] NOT NULL ,
	[NRPPC] [tinyint] NOT NULL ,
	[NRPPR] [tinyint] NOT NULL ,
	[SUMAB] [money] NOT NULL ,
	[SUMAA] [money] NOT NULL ,
	[SUMAP] [money] NOT NULL ,
	[SUMAL] [money] NOT NULL ,
	[SUMAI] [money] NOT NULL ,
	[SUMAC] [money] NOT NULL ,
	[SUMAD] [money] NOT NULL ,
	[SUMAR] [money] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_BazeCalculTipuri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[sal_BazeCalculTipuri] (
	[BazaCalculID] [int] IDENTITY (1, 1) NOT NULL ,
	[Denumire] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [nvarchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Cod] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_ContributiiIndivTipuri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[sal_ContributiiIndivTipuri] (
	[ContributieIndivID] [int] IDENTITY (1, 1) NOT NULL ,
	[Denumire] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [nvarchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Cod] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_VariabileGlobaleTipuri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[sal_VariabileGlobaleTipuri] (
	[VariabilaGlobalaID] [int] IDENTITY (1, 1) NOT NULL ,
	[Denumire] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [nvarchar] (512) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Cod] [nvarchar] (32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_impozitar_anual]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[sal_impozitar_anual] (
	[ImpozitarID] [int] NOT NULL ,
	[ValMin] [money] NOT NULL ,
	[ValMax] [money] NOT NULL ,
	[Suma] [money] NOT NULL ,
	[Procent] [decimal](18, 0) NOT NULL ,
	[Data] [datetime] NOT NULL ,
	[CategorieID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[temp_CountSall]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[temp_CountSall] (
	[AngajatID] [int] NULL ,
	[sumVenitBrut] [money] NULL ,
	[sumSomajAngajat] [money] NULL ,
	[sumCASAngajat] [money] NULL ,
	[sumContribSanPers] [money] NULL ,
	[sumImpozit] [money] NULL ,
	[sumCASAngajator] [money] NULL ,
	[sumSomajAngajator] [money] NULL ,
	[sumSantateAngajator] [money] NULL ,
	[sumFondRisc] [money] NULL ,
	[sumCamMuncaAngajator] [money] NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_IntervaleAngajat]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tm_IntervaleAngajat] (
	[IntervalAngajatID] [int] IDENTITY (1, 1) NOT NULL ,
	[Data] [datetime] NOT NULL ,
	[TipIntervalID] [int] NOT NULL ,
	[OraStart] [datetime] NOT NULL ,
	[OraEnd] [datetime] NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[ProgramLucru] [int] NULL ,
	[SalariuBaza] [money] NULL ,
	[IndemnizatieConducere] [money] NULL ,
	[Invaliditate] [smallint] NULL ,
	[CategorieID] [int] NULL ,
	[CapatInterval] [bit] NOT NULL ,
	[Deleted] [bit] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_Setari]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tm_Setari] (
	[Cheie] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Valoare] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_TipAbsente]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tm_TipAbsente] (
	[TipAbsentaID] [int] IDENTITY (1, 1) NOT NULL ,
	[Denumire] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Procent] [float] NOT NULL ,
	[Descriere] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Medical] [bit] NOT NULL ,
	[CodAbsenta] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Modificare] [bit] NOT NULL ,
	[Folosire] [bit] NOT NULL ,
	[Lucratoare] [bit] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_TipIntervale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tm_TipIntervale] (
	[TipIntervalID] [int] IDENTITY (1, 1) NOT NULL ,
	[Denumire] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Procent] [float] NOT NULL ,
	[Descriere] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[NrMaximOreSapt] [float] NOT NULL ,
	[Standard] [bit] NOT NULL ,
	[Modificare] [bit] NOT NULL ,
	[Folosire] [bit] NOT NULL ,
	[BonuriMasa] [bit] NOT NULL ,
	[AplicWeekendNoapte] [bit] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_zile]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tm_zile] (
	[Data] [datetime] NOT NULL ,
	[Sarbatoare] [bit] NOT NULL ,
	[Denumire] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Descriere] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SetataAdmin] [bit] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xxx]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[xxx] (
	[marca] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[nume] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[pren] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[sex] [nvarchar] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[nume_ant] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[tata] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[mama] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[adr1] [nvarchar] (90) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[adr2] [nvarchar] (90) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[loc] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[jud] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[str] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[nr] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[cod_postal] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[bl] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[sc] [nvarchar] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[et] [nvarchar] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ap] [nvarchar] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[sector] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[tel] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[nat] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[data_nast] [datetime] NULL ,
	[loc_nast] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[sta] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[nr_copii] [int] NULL ,
	[data_ang] [datetime] NULL ,
	[data_lic] [datetime] NULL ,
	[cod_cal] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[cod_act] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[sa01] [float] NULL ,
	[bi_nr] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[cm_nr] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[cm_emit] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[cm_data] [datetime] NULL ,
	[red_imp] [int] NULL ,
	[cod_stu] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[cod_cat] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ore_zi] [int] NULL ,
	[cnp] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[bi_data] [datetime] NULL ,
	[bi_elib] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[cod_fuc] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[bi_valabil] [datetime] NULL ,
	[card] [int] NULL ,
	[an_absolv] [int] NULL ,
	[nr_absolv] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[forma_inv] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[nrficm] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[indexabil] [int] NULL ,
	[norma] [int] NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Angajatori]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Angajatori] (
	[AngajatorID] [int] IDENTITY (1, 1) NOT NULL ,
	[Denumire] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[TipPersoana] [bit] NOT NULL ,
	[CUI_CNP] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[NrInregORC] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Telefon] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Fax] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[PaginaWeb] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Email] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TaraID] [int] NOT NULL ,
	[JudetSectorID] [int] NOT NULL ,
	[Localitate] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Strada] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Numar] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CodPostal] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Bloc] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Scara] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Etaj] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Apartament] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ZiLichidareSalar] [nvarchar] (2) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[DurateAngajare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[DurateAngajare] (
	[DurataAngajariID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[ENedeterminata] [bit] NOT NULL ,
	[DataStop] [datetime] NULL ,
	[ModLichidareID] [int] NULL ,
	[NumarContractMunca] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DataInregContractMunca] [datetime] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_CategoriiAngajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Salarii_CategoriiAngajati] (
	[CategorieID] [int] IDENTITY (1, 1) NOT NULL ,
	[LunaID] [int] NOT NULL ,
	[Descriere] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Denumire] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DPB] [money] NOT NULL ,
	[ScutireImpozit] [bit] NOT NULL ,
	[ScutireCASAngajat] [bit] NOT NULL ,
	[ScutireCASAngajator] [bit] NOT NULL ,
	[ScutireSomajAngajat] [bit] NOT NULL ,
	[ScutireSomajAngajator] [bit] NOT NULL ,
	[ScutireAsigSanAngajat] [bit] NOT NULL ,
	[ScutireAsigSanAngajator] [bit] NOT NULL ,
	[PrimesteDPB] [bit] NOT NULL ,
	[CoeficientDeducereSpeciala] [float] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_impozite]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Salarii_impozite] (
	[ImpozitID] [int] IDENTITY (1, 1) NOT NULL ,
	[Denumire] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Procent] [numeric](6, 3) NOT NULL ,
	[LunaID] [int] NOT NULL ,
	[Tip] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[AplicatLaID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_VariabileGlobale]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[sal_VariabileGlobale] (
	[VariabilaID] [int] IDENTITY (1, 1) NOT NULL ,
	[SalariuMinim] [money] NOT NULL ,
	[LunaID] [int] NOT NULL ,
	[SalariuMediu] [money] NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_VariabileGlobaleValori]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[sal_VariabileGlobaleValori] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[VariabilaGlobalaID] [int] NOT NULL ,
	[LunaID] [int] NOT NULL ,
	[Valoare] [float] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Angajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Angajati] (
	[AngajatID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[AngajatorID] [int] NOT NULL ,
	[Marca] [nvarchar] (8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[NumeIntreg] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Nume] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Prenume] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[NumeAnterior] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[TitluID] [int] NULL ,
	[Poza] [image] NULL ,
	[PrenumeMama] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[PrenumeTata] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[StudiuID] [int] NOT NULL ,
	[AnAbsolvire] [smallint] NOT NULL ,
	[NrDiploma] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Descriere] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[ModIncadrare] [bit] NOT NULL ,
	[ProgramLucru] [tinyint] NOT NULL ,
	[Telefon] [nvarchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DataNasterii] [datetime] NOT NULL ,
	[TaraNastereID] [int] NOT NULL ,
	[JudetNastereID] [int] NOT NULL ,
	[LocalitateNastere] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[StareCivila] [tinyint] NOT NULL ,
	[NrCopii] [tinyint] NOT NULL ,
	[Sex] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Nationalitate] [int] NULL ,
	[TipFisaFiscala] [bit] NOT NULL ,
	[AniVechimeMunca] [tinyint] NOT NULL ,
	[LuniVechimeMunca] [tinyint] NULL ,
	[ZileVechimeMunca] [tinyint] NOT NULL ,
	[AreCardBancar] [bit] NOT NULL ,
	[SefID] [int] NULL ,
	[Activ] [bit] NULL ,
	[SalariuBazaActual] [money] NULL ,
	[IndemnizatieConducereActual] [money] NULL ,
	[Sporuri] [money] NULL ,
	[AlteAdaosuri] [money] NULL ,
	[NrZileCOAn] [int] NOT NULL ,
	[NrZileCOSupl] [int] NULL ,
	[PerioadaDeterminata] [bit] NULL ,
	[DataPanaLa] [datetime] NULL ,
	[DataDeLa] [datetime] NULL ,
	[NrContractMunca] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[DataInregContractMunca] [datetime] NULL ,
	[EchIndProtectie] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[EchIndLucru] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[MatIgiSan] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[AlimProtectie] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[AlteDrSiObl] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[AlteClauzeCIM] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[PerProba] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[Invaliditate] [smallint] NULL ,
	[CategorieID] [int] NOT NULL ,
	[Email] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[TelMunca] [varchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Deleted] [bit] NOT NULL ,
	[Pensionar] [bit] NOT NULL ,
	[AreAlteVenituri] [bit] NULL ,
	[SolicitaDeduceri] [bit] NULL ,
	[SumaMajorare] [money] NULL ,
	[DataMajorare] [datetime] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Conturi]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Conturi] (
	[ContID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[TitularID] [int] NOT NULL ,
	[BancaID] [int] NOT NULL ,
	[NumarCont] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Moneda] [varchar] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_AsignareImpozite]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Salarii_AsignareImpozite] (
	[ImpozitID] [int] NOT NULL ,
	[CategorieID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_impozitar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Salarii_impozitar] (
	[ImpozitarID] [int] IDENTITY (1, 1) NOT NULL ,
	[ValMin] [numeric](19, 3) NOT NULL ,
	[ValMax] [numeric](19, 3) NOT NULL ,
	[SumaBaza] [numeric](19, 3) NOT NULL ,
	[Procent] [numeric](6, 3) NOT NULL ,
	[CategorieID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_Impozitar]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[sal_Impozitar] (
	[ImpozitarID] [int] IDENTITY (1, 1) NOT NULL ,
	[ValMin] [money] NOT NULL ,
	[ValMax] [money] NOT NULL ,
	[Suma] [money] NOT NULL ,
	[Procent] [decimal](6, 2) NOT NULL ,
	[Data] [datetime] NOT NULL ,
	[CategorieID] [int] NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Alerte]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Alerte] (
	[AlertaID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[DataExpirare] [datetime] NOT NULL ,
	[PerioadaCritica] [int] NOT NULL ,
	[Descriere] [nvarchar] (200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Activ] [bit] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AngajatPersoaneInIntretinere]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[AngajatPersoaneInIntretinere] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[Nume] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Prenume] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Calitate] [smallint] NULL ,
	[CNP] [bigint] NOT NULL ,
	[Invaliditate] [smallint] NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AngajatiClauze]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[AngajatiClauze] (
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[ClauzaSpecialaID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AngajatiIntreruperi]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[AngajatiIntreruperi] (
	[AngajatIntrerupereID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[DataEnd] [datetime] NOT NULL ,
	[Descriere] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AngajatiRetineri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[AngajatiRetineri] (
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[RetinereID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CarneteMunca]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[CarneteMunca] (
	[AngajatID] [int] NOT NULL ,
	[Serie] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Numar] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Emitent] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DataEmiterii] [datetime] NULL ,
	[NrInregITM] [nvarchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Checkupuri]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Checkupuri] (
	[CheckupID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[NecesarInstruire] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DataUrmatorului] [datetime] NOT NULL ,
	[ResponsabilID] [int] NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[DataEfectuarii] [datetime] NOT NULL ,
	[CheckupFile] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ConturiAngajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[ConturiAngajati] (
	[ContID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[BancaID] [int] NOT NULL ,
	[NumarCont] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Moneda] [varchar] (3) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Activ] [bit] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Departamente]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Departamente] (
	[DepartamentID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Cod] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Denumire] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[SefID] [int] NULL ,
	[InlocSefID] [int] NULL ,
	[DeptParinte] [int] NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Directori]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Directori] (
	[AngajatorID] [int] NOT NULL ,
	[AngajatID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[EvaluariPsihologice]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[EvaluariPsihologice] (
	[EvalPsihologicaID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[Data] [datetime] NOT NULL ,
	[TipRaportID] [int] NOT NULL ,
	[Raport] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricActivitati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[IstoricActivitati] (
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[ActivitateID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricAngajatiInvaliditati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[IstoricAngajatiInvaliditati] (
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[InvaliditateID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricCategoriiAngajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[IstoricCategoriiAngajati] (
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[CategorieID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricCentreCost]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[IstoricCentreCost] (
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[CentruCostID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricContracteAngajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[IstoricContracteAngajati] (
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[DataEnd] [datetime] NOT NULL ,
	[AngajatorID] [int] NOT NULL ,
	[ProgramLucru] [int] NOT NULL ,
	[ModIncadrare] [bit] NOT NULL ,
	[TipFisaFiscala] [bit] NOT NULL ,
	[AnVechimeMunca] [tinyint] NOT NULL ,
	[LuniVechimeMunca] [tinyint] NOT NULL ,
	[ZileVechimeMunca] [tinyint] NOT NULL ,
	[SalariuBazaActual] [money] NOT NULL ,
	[IndemnizatieConducere] [money] NOT NULL ,
	[PerioadaDeterminata] [bit] NOT NULL ,
	[DataPanaLa] [datetime] NOT NULL ,
	[NrContractMunca] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DataInregContract] [datetime] NOT NULL ,
	[Invaliditate] [smallint] NOT NULL ,
	[CategorieID] [int] NOT NULL ,
	[Pensionar] [bit] NOT NULL ,
	[AreAlteVenituri] [bit] NOT NULL ,
	[SolicitaDeduceri] [bit] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricDurateAngajari]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[IstoricDurateAngajari] (
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[DurataAngajariID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricFunctii]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[IstoricFunctii] (
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[FunctieID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricGrupeMunca]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[IstoricGrupeMunca] (
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[GrupaMuncaID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricLocMunca]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[IstoricLocMunca] (
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[LocMuncaID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricReduceriImpozit]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[IstoricReduceriImpozit] (
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[ReducereImpozitID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricSalariiIncadrareAngajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[IstoricSalariiIncadrareAngajati] (
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[SalariuIncadrareID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricTraining]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[IstoricTraining] (
	[IstoricTrainingID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[TrainingID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[DataEnd] [datetime] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Lichidare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Lichidare] (
	[LichidareID] [int] IDENTITY (1, 1) NOT NULL ,
	[NrInregistrare] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DataLichidare] [datetime] NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[AvansuriDecontare] [money] NOT NULL ,
	[Abonamente] [money] NOT NULL ,
	[TicheteMasa] [money] NOT NULL ,
	[EchipamentLucru] [money] NOT NULL ,
	[Laptop] [money] NOT NULL ,
	[TelServiciu] [money] NOT NULL ,
	[ObiecteInventar] [money] NOT NULL ,
	[Carti] [money] NOT NULL ,
	[CD] [money] NOT NULL ,
	[DataInregistrare] [datetime] NULL ,
	[NrArticol] [nvarchar] (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LunaRetinere] [datetime] NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Pasapoarte]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Pasapoarte] (
	[PasaportID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[Serie] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Numar] [bigint] NOT NULL ,
	[EliberatDe] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DataEliberarii] [datetime] NULL ,
	[ValabilPanaLa] [datetime] NULL ,
	[Activ] [bit] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Referinte]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Referinte] (
	[ReferintaID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[Descriere] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[AngajatID] [int] NOT NULL ,
	[Titlu] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Data] [datetime] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sal_Salarii]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Sal_Salarii] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[DataPlatii] [datetime] NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[SalariuIncadrare] [money] NOT NULL ,
	[ProgramLucru] [int] NOT NULL ,
	[NrZileLuna] [float] NOT NULL ,
	[NrOreLucrate] [float] NOT NULL ,
	[SumaOreLucrate] [money] NOT NULL ,
	[NrOreLucrateCondDeoseb] [float] NOT NULL ,
	[SumaOreLucrateCondDeoseb] [money] NOT NULL ,
	[NrOreLucrateCondSpeciale] [float] NOT NULL ,
	[SumaOreLucrateCondSpeciale] [money] NOT NULL ,
	[NrOreSup50%] [float] NOT NULL ,
	[SumaOreSup50%] [money] NOT NULL ,
	[NrOreSup100%] [float] NOT NULL ,
	[SumaOreSup100%] [money] NOT NULL ,
	[NrOreEvenimDeosebit] [float] NOT NULL ,
	[SumaEvenimDeosebit] [money] NOT NULL ,
	[NrOreInvoire] [float] NOT NULL ,
	[SumaOreInvoire] [money] NOT NULL ,
	[NrOreConcediuOdihna] [float] NOT NULL ,
	[SumaConcediuOdihna] [money] NOT NULL ,
	[NrOreConcediuBoala] [float] NOT NULL ,
	[SumaConcediuBoala] [money] NOT NULL ,
	[SporActivSupl] [money] NOT NULL ,
	[EmergencyService] [money] NOT NULL ,
	[IndemnizCoducere] [money] NOT NULL ,
	[PrimeSpeciale] [money] NOT NULL ,
	[AlteDrepturi] [money] NOT NULL ,
	[VenitBrut] [money] NOT NULL ,
	[AjutorSomaj] [money] NOT NULL ,
	[CASAngajat] [money] NOT NULL ,
	[ContribSanPers] [money] NOT NULL ,
	[CheltProfesionale] [money] NOT NULL ,
	[DeducerePersonala] [money] NOT NULL ,
	[DeducereSuplimentara] [money] NOT NULL ,
	[BCImpozit] [money] NOT NULL ,
	[Impozit] [money] NOT NULL ,
	[VenitNet] [money] NOT NULL ,
	[Avans] [money] NOT NULL ,
	[AlteRetineri] [money] NOT NULL ,
	[TotalRetineri] [money] NOT NULL ,
	[RestPlata] [money] NOT NULL ,
	[CASAngajator] [money] NOT NULL ,
	[SanatateAngajator] [money] NOT NULL ,
	[SomajAngajator] [money] NOT NULL ,
	[FondRiscAngajator] [money] NOT NULL ,
	[CameraMuncaAngajator] [money] NOT NULL ,
	[LunaID] [int] NOT NULL ,
	[BenefAjutorSomaj] [tinyint] NOT NULL ,
	[CASTot] [money] NOT NULL ,
	[BASS] [money] NOT NULL ,
	[NRCAZB] [tinyint] NOT NULL ,
	[NRCAZA] [tinyint] NOT NULL ,
	[NRCAZP] [tinyint] NOT NULL ,
	[NRCAZL] [tinyint] NOT NULL ,
	[NRCAZI] [tinyint] NOT NULL ,
	[NRCAZC] [tinyint] NOT NULL ,
	[NRCAZD] [tinyint] NOT NULL ,
	[NRCAZR] [tinyint] NOT NULL ,
	[NRPPB] [tinyint] NOT NULL ,
	[NRPPA] [tinyint] NOT NULL ,
	[NRPPP] [tinyint] NOT NULL ,
	[NRPPL] [tinyint] NOT NULL ,
	[NRPPI] [tinyint] NOT NULL ,
	[NRPPC] [tinyint] NOT NULL ,
	[NRPPR] [tinyint] NOT NULL ,
	[SUMAB] [money] NOT NULL ,
	[SUMAA] [money] NOT NULL ,
	[SUMAP] [money] NOT NULL ,
	[SUMAL] [money] NOT NULL ,
	[SUMAI] [money] NOT NULL ,
	[SUMAC] [money] NOT NULL ,
	[SUMAD] [money] NOT NULL ,
	[SUMAR] [money] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Sal_SituatieLunaraAngajati]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Sal_SituatieLunaraAngajati] (
	[SituatieID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[NrZileLuna] [float] NOT NULL ,
	[NrZileLucrateLuna] [float] NOT NULL ,
	[NrOreLucrate] [float] NOT NULL ,
	[NrOreSup50Proc] [float] NOT NULL ,
	[NrOreSup100Proc] [float] NOT NULL ,
	[NrOreEvenimDeoseb] [float] NOT NULL ,
	[NrOreInvoire] [float] NOT NULL ,
	[NrOreConcediuOdihna] [float] NOT NULL ,
	[NrOreConcediuBoala] [float] NOT NULL ,
	[NrOreConcediuBoalaFirma] [float] NOT NULL ,
	[NrOreConcediuBoalaBASS] [float] NOT NULL ,
	[NrOreObligatiiCetatenesti] [float] NOT NULL ,
	[NrOreAbsenteNemotivate] [float] NOT NULL ,
	[NrOreConcediuFaraPlata] [float] NOT NULL ,
	[NrOreLucrateDelegatieInterna] [float] NOT NULL ,
	[NrOreLucrateDelegatieExterna] [float] NOT NULL ,
	[NrOreTotalDelegatieInterna] [float] NOT NULL ,
	[NrOreTotalDelegatieExterna] [float] NOT NULL ,
	[SporActivitatiSup] [money] NOT NULL ,
	[EmergencyService] [money] NOT NULL ,
	[PrimeSpeciale] [money] NOT NULL ,
	[PrimeProiect] [money] NOT NULL ,
	[AlteDrepturi] [money] NOT NULL ,
	[AlteDrepturiNet] [money] NOT NULL ,
	[LunaID] [int] NOT NULL ,
	[CategorieID] [int] NOT NULL ,
	[ProgramLucru] [tinyint] NOT NULL ,
	[SalariuBaza] [money] NOT NULL ,
	[IndemnizatieConducere] [money] NOT NULL ,
	[Invaliditate] [smallint] NOT NULL ,
	[NrOreEmergencyService] [float] NOT NULL ,
	[Avans] [money] NOT NULL ,
	[Retineri] [money] NOT NULL ,
	[PrimaProiect] [money] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_DateSuplimentareLunare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Salarii_DateSuplimentareLunare] (
	[AngajatID] [int] NOT NULL ,
	[LunaID] [int] NOT NULL ,
	[CategorieID] [int] NOT NULL ,
	[GrupaMuncaID] [int] NOT NULL ,
	[InvaliditateID] [int] NOT NULL ,
	[OreLucrate] [int] NOT NULL ,
	[NrZile] [int] NOT NULL ,
	[Avans] [decimal](18, 3) NOT NULL ,
	[SalariuNet] [decimal](18, 3) NOT NULL ,
	[SalariuBrut] [decimal](18, 3) NOT NULL ,
	[SalariuRealizat] [decimal](18, 3) NOT NULL ,
	[SalariuIncadrare] [decimal](18, 3) NOT NULL ,
	[OreSuplimentare50] [int] NOT NULL ,
	[OreSuplimentare100] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_RetineriLunare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Salarii_RetineriLunare] (
	[AngajatID] [int] NOT NULL ,
	[LunaID] [int] NOT NULL ,
	[Descriere] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Valoare] [decimal](18, 3) NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Salarii_SporuriLunare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[Salarii_SporuriLunare] (
	[AngajatID] [int] NOT NULL ,
	[LunaID] [int] NOT NULL ,
	[SporID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SituatieMilitara]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[SituatieMilitara] (
	[AngajatID] [int] NOT NULL ,
	[EvidentaCMJ] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[DataIntrareEvidenta] [datetime] NOT NULL ,
	[Gradul] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SerieLivret] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[NumarLivret] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[SpecialitatiMilitare] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_BazeCalculLuna]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[sal_BazeCalculLuna] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NULL ,
	[AngajatorID] [int] NULL ,
	[BazaCalculID] [int] NOT NULL ,
	[LunaID] [int] NOT NULL ,
	[Valoare] [money] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_ContributiiIndivLuna]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[sal_ContributiiIndivLuna] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NULL ,
	[AngajatorID] [int] NULL ,
	[ContributieIndivID] [int] NOT NULL ,
	[LunaID] [int] NOT NULL ,
	[Valoare] [money] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sal_StatDePlata]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[sal_StatDePlata] (
	[ID] [int] IDENTITY (1, 1) NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[LunaID] [int] NOT NULL ,
	[Prime] [money] NULL ,
	[AlteDrepturi] [money] NULL ,
	[IndemnizatieConcediuMedical] [money] NULL ,
	[VenitBrut] [money] NULL ,
	[VenitNet] [money] NULL ,
	[DeduceriPersonale] [money] NULL ,
	[BazaImpozitare] [money] NULL ,
	[Impozit] [money] NULL ,
	[SalariuNet] [money] NULL ,
	[Avans] [money] NULL ,
	[Retineri] [money] NULL ,
	[TotalRetineri] [money] NULL ,
	[RestDePlata] [money] NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_IntervaleAbsenta]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tm_IntervaleAbsenta] (
	[IntervalAbsentaID] [int] IDENTITY (1, 1) NOT FOR REPLICATION  NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[DataEnd] [datetime] NOT NULL ,
	[Observatii] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[TipAbsentaID] [int] NOT NULL ,
	[AngajatID] [int] NOT NULL ,
	[BoalaID] [int] NULL ,
	[ContinuareAbsenta] [bit] NOT NULL ,
	[MedieZilnica] [real] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[IstoricAngajatDepartament]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[IstoricAngajatDepartament] (
	[AngajatID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[DepartamentID] [int] NOT NULL 
) ON [PRIMARY]
END

GO

if not exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[tm_IntervaleAbsentaContinuare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
 BEGIN
CREATE TABLE [dbo].[tm_IntervaleAbsentaContinuare] (
	[AbsentaContinuareID] [int] IDENTITY (1, 1) NOT NULL ,
	[AbsentaID] [int] NOT NULL ,
	[DataStart] [datetime] NOT NULL ,
	[DataEnd] [datetime] NOT NULL ,
	[BoalaID] [int] NOT NULL ,
	[Observatii] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

GO

ALTER TABLE [dbo].[Activitati] WITH NOCHECK ADD 
	CONSTRAINT [PK_Activitati] PRIMARY KEY  CLUSTERED 
	(
		[ActivitateID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Banci] WITH NOCHECK ADD 
	CONSTRAINT [PK_Banci] PRIMARY KEY  CLUSTERED 
	(
		[BancaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Boli] WITH NOCHECK ADD 
	CONSTRAINT [PK_NomenclatorBoli] PRIMARY KEY  CLUSTERED 
	(
		[BoalaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Calendar] WITH NOCHECK ADD 
	CONSTRAINT [PK_Calendar] PRIMARY KEY  CLUSTERED 
	(
		[DataID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CartiIdentitate] WITH NOCHECK ADD 
	CONSTRAINT [PK_CartiIdentitate] PRIMARY KEY  CLUSTERED 
	(
		[CarteIdentitateID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Categorii] WITH NOCHECK ADD 
	CONSTRAINT [PK_Categorii] PRIMARY KEY  CLUSTERED 
	(
		[CategorieID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CentreCost] WITH NOCHECK ADD 
	CONSTRAINT [PK_CentreCost] PRIMARY KEY  CLUSTERED 
	(
		[CentruCostID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ClauzeSpeciale] WITH NOCHECK ADD 
	CONSTRAINT [PK_ClauzeSpeciale] PRIMARY KEY  CLUSTERED 
	(
		[ClauzaSpecialaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Coeficienti] WITH NOCHECK ADD 
	CONSTRAINT [PK_Coeficienti] PRIMARY KEY  CLUSTERED 
	(
		[SetID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ConcediuMedicZilePlatite] WITH NOCHECK ADD 
	CONSTRAINT [PK_ConcediuMedicZilePlatite] PRIMARY KEY  CLUSTERED 
	(
		[id_Criteriu]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Domicilii] WITH NOCHECK ADD 
	CONSTRAINT [PK_Domicilii] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[Tip]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Functii] WITH NOCHECK ADD 
	CONSTRAINT [PK_Functii] PRIMARY KEY  CLUSTERED 
	(
		[FunctieID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[GrupeMunca] WITH NOCHECK ADD 
	CONSTRAINT [PK_GrupeMunca] PRIMARY KEY  CLUSTERED 
	(
		[GrupaMuncaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Intreruperi] WITH NOCHECK ADD 
	CONSTRAINT [PK_Intreruperi] PRIMARY KEY  CLUSTERED 
	(
		[IntrerupereID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Invaliditati] WITH NOCHECK ADD 
	CONSTRAINT [PK_Invaliditati] PRIMARY KEY  CLUSTERED 
	(
		[InvaliditateID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Judete] WITH NOCHECK ADD 
	CONSTRAINT [PK_Judete] PRIMARY KEY  CLUSTERED 
	(
		[JudetID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[LegitimatiiSedere] WITH NOCHECK ADD 
	CONSTRAINT [PK_LegitimatiiSedere] PRIMARY KEY  CLUSTERED 
	(
		[LegitimatieSedereID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[LocuriMunca] WITH NOCHECK ADD 
	CONSTRAINT [PK_LocuriMunca] PRIMARY KEY  CLUSTERED 
	(
		[LocMuncaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Luni_Text] WITH NOCHECK ADD 
	CONSTRAINT [PK_Luni_Text] PRIMARY KEY  CLUSTERED 
	(
		[LunaTextID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ModalitatiLichidare] WITH NOCHECK ADD 
	CONSTRAINT [PK_ModalitatiLichidare] PRIMARY KEY  CLUSTERED 
	(
		[ModLichidareID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[NIF] WITH NOCHECK ADD 
	CONSTRAINT [PK_NIF] PRIMARY KEY  CLUSTERED 
	(
		[NIFID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ObligatiiDecl100] WITH NOCHECK ADD 
	CONSTRAINT [PK_ObligatiiDecl100] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ParametriImpozitAnual] WITH NOCHECK ADD 
	CONSTRAINT [PK_ParametriImpozitAnual] PRIMARY KEY  CLUSTERED 
	(
		[An],
		[ParametriID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[PermiseMunca] WITH NOCHECK ADD 
	CONSTRAINT [PK_PermiseMunca] PRIMARY KEY  CLUSTERED 
	(
		[PermisMuncaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ReduceriImpozit] WITH NOCHECK ADD 
	CONSTRAINT [PK_ReduceriImpozit] PRIMARY KEY  CLUSTERED 
	(
		[ReducereImpozitID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ReportFields] WITH NOCHECK ADD 
	CONSTRAINT [PK_ReportFields] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Reports] WITH NOCHECK ADD 
	CONSTRAINT [PK_Reports] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Sal_Luni] WITH NOCHECK ADD 
	CONSTRAINT [PK_Sal_Luni] PRIMARY KEY  CLUSTERED 
	(
		[LunaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Salarii] WITH NOCHECK ADD 
	CONSTRAINT [PK_Salarii] PRIMARY KEY  CLUSTERED 
	(
		[data_salariu],
		[AngajatID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[SalariiIncadrare] WITH NOCHECK ADD 
	CONSTRAINT [PK_SalariiIncadrare] PRIMARY KEY  CLUSTERED 
	(
		[SalariuIncadrareID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Salarii_AplicareSumeImpozit] WITH NOCHECK ADD 
	CONSTRAINT [PK_Salarii_AplicareSumeImpozit] PRIMARY KEY  CLUSTERED 
	(
		[AplicatLaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[SarbatoriLegale] WITH NOCHECK ADD 
	CONSTRAINT [PK_SarbatoriLegale] PRIMARY KEY  CLUSTERED 
	(
		[Data]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Sporuri] WITH NOCHECK ADD 
	CONSTRAINT [PK_Sporuri] PRIMARY KEY  CLUSTERED 
	(
		[SporID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Studii] WITH NOCHECK ADD 
	CONSTRAINT [PK_Studii] PRIMARY KEY  CLUSTERED 
	(
		[StudiuID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Tari] WITH NOCHECK ADD 
	CONSTRAINT [PK_Tari] PRIMARY KEY  CLUSTERED 
	(
		[TaraID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[TipuriPersoaneInIntretinere] WITH NOCHECK ADD 
	CONSTRAINT [PK_TipuriPersoaneInIntretinere] PRIMARY KEY  CLUSTERED 
	(
		[TipPersoanaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[TipuriRapoarte] WITH NOCHECK ADD 
	CONSTRAINT [PK_TipuriRapoarte] PRIMARY KEY  CLUSTERED 
	(
		[TipRaportID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[TitluriAngajati] WITH NOCHECK ADD 
	CONSTRAINT [PK_Titluri_angajati] PRIMARY KEY  CLUSTERED 
	(
		[TitluID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Traininguri] WITH NOCHECK ADD 
	CONSTRAINT [PK_Traininguri] PRIMARY KEY  CLUSTERED 
	(
		[TrainingID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[sal_Angajator] WITH NOCHECK ADD 
	CONSTRAINT [PK_sal_Angajator] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[sal_BazeCalculTipuri] WITH NOCHECK ADD 
	CONSTRAINT [PK_sal_BazeCalculTipuri] PRIMARY KEY  CLUSTERED 
	(
		[BazaCalculID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[sal_ContributiiIndivTipuri] WITH NOCHECK ADD 
	CONSTRAINT [PK_sal_ContributiiIndivTipuri] PRIMARY KEY  CLUSTERED 
	(
		[ContributieIndivID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[sal_VariabileGlobaleTipuri] WITH NOCHECK ADD 
	CONSTRAINT [PK_sal_VariabileGlobaleTipuri] PRIMARY KEY  CLUSTERED 
	(
		[VariabilaGlobalaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[sal_impozitar_anual] WITH NOCHECK ADD 
	CONSTRAINT [PK_sal_impozitar_anul] PRIMARY KEY  CLUSTERED 
	(
		[ImpozitarID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tm_IntervaleAngajat] WITH NOCHECK ADD 
	CONSTRAINT [PK_tm_IntervaleAngajat] PRIMARY KEY  CLUSTERED 
	(
		[IntervalAngajatID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tm_Setari] WITH NOCHECK ADD 
	CONSTRAINT [PK_tm_Setari] PRIMARY KEY  CLUSTERED 
	(
		[Cheie]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tm_TipAbsente] WITH NOCHECK ADD 
	CONSTRAINT [PK_tm_TipAbsente] PRIMARY KEY  CLUSTERED 
	(
		[TipAbsentaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tm_TipIntervale] WITH NOCHECK ADD 
	CONSTRAINT [PK_tm_TipIntervale] PRIMARY KEY  CLUSTERED 
	(
		[TipIntervalID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tm_zile] WITH NOCHECK ADD 
	CONSTRAINT [PK_tm_zile] PRIMARY KEY  CLUSTERED 
	(
		[Data]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Angajatori] WITH NOCHECK ADD 
	CONSTRAINT [PK_Angajatori] PRIMARY KEY  CLUSTERED 
	(
		[AngajatorID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[DurateAngajare] WITH NOCHECK ADD 
	CONSTRAINT [PK_DurateAngajare] PRIMARY KEY  CLUSTERED 
	(
		[DurataAngajariID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Salarii_CategoriiAngajati] WITH NOCHECK ADD 
	CONSTRAINT [PK_Salarii_CategoriAngajati] PRIMARY KEY  CLUSTERED 
	(
		[CategorieID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Salarii_impozite] WITH NOCHECK ADD 
	CONSTRAINT [PK_Salarii_impozite] PRIMARY KEY  CLUSTERED 
	(
		[ImpozitID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[sal_VariabileGlobale] WITH NOCHECK ADD 
	CONSTRAINT [PK_sal_VariabileGlobale] PRIMARY KEY  CLUSTERED 
	(
		[VariabilaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[sal_VariabileGlobaleValori] WITH NOCHECK ADD 
	CONSTRAINT [PK_sal_VariabileGlobaleValori] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Angajati] WITH NOCHECK ADD 
	CONSTRAINT [PK_Angajati] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Conturi] WITH NOCHECK ADD 
	CONSTRAINT [PK_Conturi] PRIMARY KEY  CLUSTERED 
	(
		[ContID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Salarii_impozitar] WITH NOCHECK ADD 
	CONSTRAINT [PK_Salarii_impozitar] PRIMARY KEY  CLUSTERED 
	(
		[ImpozitarID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[sal_Impozitar] WITH NOCHECK ADD 
	CONSTRAINT [PK_sal_Impozitar] PRIMARY KEY  CLUSTERED 
	(
		[ImpozitarID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Alerte] WITH NOCHECK ADD 
	CONSTRAINT [PK_Alerte] PRIMARY KEY  CLUSTERED 
	(
		[AlertaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[AngajatPersoaneInIntretinere] WITH NOCHECK ADD 
	CONSTRAINT [PK_AngajatPersoaneInIntretinere] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[AngajatiClauze] WITH NOCHECK ADD 
	CONSTRAINT [PK_AngajatiClauze] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[DataStart]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[AngajatiIntreruperi] WITH NOCHECK ADD 
	CONSTRAINT [PK_AngajatiIntreruperi] PRIMARY KEY  CLUSTERED 
	(
		[AngajatIntrerupereID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[AngajatiRetineri] WITH NOCHECK ADD 
	CONSTRAINT [PK_AngajatiRetineri] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[DataStart]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CarneteMunca] WITH NOCHECK ADD 
	CONSTRAINT [PK_CarneteMunca] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Checkupuri] WITH NOCHECK ADD 
	CONSTRAINT [PK_Checkupuri] PRIMARY KEY  CLUSTERED 
	(
		[CheckupID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[ConturiAngajati] WITH NOCHECK ADD 
	CONSTRAINT [PK_ConturiAngajati] PRIMARY KEY  CLUSTERED 
	(
		[ContID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Departamente] WITH NOCHECK ADD 
	CONSTRAINT [PK_Departamente] PRIMARY KEY  CLUSTERED 
	(
		[DepartamentID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Directori] WITH NOCHECK ADD 
	CONSTRAINT [PK_Directori] PRIMARY KEY  CLUSTERED 
	(
		[AngajatorID],
		[AngajatID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[EvaluariPsihologice] WITH NOCHECK ADD 
	CONSTRAINT [PK_EvaluariPsihologice] PRIMARY KEY  CLUSTERED 
	(
		[EvalPsihologicaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[IstoricActivitati] WITH NOCHECK ADD 
	CONSTRAINT [PK_IstoricActivitati] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[DataStart]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[IstoricAngajatiInvaliditati] WITH NOCHECK ADD 
	CONSTRAINT [PK_IstoricAngajatiInvaliditati] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[DataStart]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[IstoricCategoriiAngajati] WITH NOCHECK ADD 
	CONSTRAINT [PK_IstoricCategoriiAngajati] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[DataStart]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[IstoricCentreCost] WITH NOCHECK ADD 
	CONSTRAINT [PK_IstoricCentreCost] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[DataStart]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[IstoricContracteAngajati] WITH NOCHECK ADD 
	CONSTRAINT [PK_IstoricContracteAngajati] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[DataStart]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[IstoricDurateAngajari] WITH NOCHECK ADD 
	CONSTRAINT [PK_IstoricDurateAngajari] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[DataStart]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[IstoricFunctii] WITH NOCHECK ADD 
	CONSTRAINT [PK_IstoricFunctii] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[DataStart]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[IstoricGrupeMunca] WITH NOCHECK ADD 
	CONSTRAINT [PK_IstoricGrupeMunca] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[DataStart]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[IstoricLocMunca] WITH NOCHECK ADD 
	CONSTRAINT [PK_IstoricLocMunca] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[DataStart]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[IstoricReduceriImpozit] WITH NOCHECK ADD 
	CONSTRAINT [PK_IstoricReduceriImpozit] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[DataStart]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[IstoricSalariiIncadrareAngajati] WITH NOCHECK ADD 
	CONSTRAINT [PK_IstoricSalariiIncadrareAngajati] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[DataStart]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[IstoricTraining] WITH NOCHECK ADD 
	CONSTRAINT [PK_IstoricTraining] PRIMARY KEY  CLUSTERED 
	(
		[IstoricTrainingID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Lichidare] WITH NOCHECK ADD 
	CONSTRAINT [PK_Lichidare] PRIMARY KEY  CLUSTERED 
	(
		[LichidareID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Pasapoarte] WITH NOCHECK ADD 
	CONSTRAINT [PK_Pasapoarte] PRIMARY KEY  CLUSTERED 
	(
		[PasaportID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Referinte] WITH NOCHECK ADD 
	CONSTRAINT [PK_Referinte] PRIMARY KEY  CLUSTERED 
	(
		[ReferintaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Sal_Salarii] WITH NOCHECK ADD 
	CONSTRAINT [PK_Sal_Salarii] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Sal_SituatieLunaraAngajati] WITH NOCHECK ADD 
	CONSTRAINT [PK_Salarii_SituatieLunaraAngajati] PRIMARY KEY  CLUSTERED 
	(
		[SituatieID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Salarii_DateSuplimentareLunare] WITH NOCHECK ADD 
	CONSTRAINT [PK_Salarii_DateSuplimentareLunare] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[LunaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Salarii_RetineriLunare] WITH NOCHECK ADD 
	CONSTRAINT [PK_Salarii_RetineriLunare] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[LunaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Salarii_SporuriLunare] WITH NOCHECK ADD 
	CONSTRAINT [PK_Salarii_SporuriLunare] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[LunaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[SituatieMilitara] WITH NOCHECK ADD 
	CONSTRAINT [PK_SituatieMilitara] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[sal_BazeCalculLuna] WITH NOCHECK ADD 
	CONSTRAINT [PK_sal_BazeCalculLuna] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[sal_ContributiiIndivLuna] WITH NOCHECK ADD 
	CONSTRAINT [PK_sal_ContributiiIndivLuna] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[sal_StatDePlata] WITH NOCHECK ADD 
	CONSTRAINT [PK_sal_StatDePlata] PRIMARY KEY  CLUSTERED 
	(
		[ID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tm_IntervaleAbsenta] WITH NOCHECK ADD 
	CONSTRAINT [PK_tm_IntervaleAbsenta] PRIMARY KEY  CLUSTERED 
	(
		[IntervalAbsentaID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[IstoricAngajatDepartament] WITH NOCHECK ADD 
	CONSTRAINT [PK_IstoricAngajatDepartament] PRIMARY KEY  CLUSTERED 
	(
		[AngajatID],
		[DataStart]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[tm_IntervaleAbsentaContinuare] WITH NOCHECK ADD 
	CONSTRAINT [PK_tm_IntervaleAbsentaContinuare] PRIMARY KEY  CLUSTERED 
	(
		[AbsentaContinuareID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CartiIdentitate] WITH NOCHECK ADD 
	CONSTRAINT [DF_CartiIdentitate_Activ] DEFAULT (1) FOR [Activ]
GO

ALTER TABLE [dbo].[CentreCost] WITH NOCHECK ADD 
	CONSTRAINT [UK_CentreCost_Cod] UNIQUE  NONCLUSTERED 
	(
		[Cod]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Coeficienti] WITH NOCHECK ADD 
	CONSTRAINT [DF_Coeficienti_Deducere] DEFAULT (0) FOR [Deducere],
	CONSTRAINT [DF_Coeficienti_CoefInvalidGrd1] DEFAULT (0) FOR [CoefInvalidGrd1],
	CONSTRAINT [DF_Coeficienti_CoefInvalidGrd2] DEFAULT (0) FOR [CoefInvalidGrd2],
	CONSTRAINT [DF_Coeficienti_CoefCopil12] DEFAULT (0) FOR [CoefCopil12],
	CONSTRAINT [DF_Coeficienti_CoefCopil3] DEFAULT (0) FOR [CoefCopil3],
	CONSTRAINT [DF_Coeficienti_CoefUrmCopil] DEFAULT (0) FOR [CoefUrmCopil],
	CONSTRAINT [DF_Coeficienti_CoefSot] DEFAULT (0) FOR [CoefSot],
	CONSTRAINT [DF_Coeficienti_CoefTotal] DEFAULT (0) FOR [CoefTotal],
	CONSTRAINT [DF_Coeficienti_CoefSanatate] DEFAULT (0) FOR [CoefSanatate],
	CONSTRAINT [DF_Coeficienti_CoefPensie] DEFAULT (0) FOR [CoefPensie],
	CONSTRAINT [DF_Coeficienti_CoefCheltProf] DEFAULT (0) FOR [CoefCheltProf]
GO

ALTER TABLE [dbo].[DomDeActivitateAngajator] WITH NOCHECK ADD 
	CONSTRAINT [DF_DomDeActivitateAngajator_Principal] DEFAULT (0) FOR [Principal]
GO

ALTER TABLE [dbo].[Domicilii] WITH NOCHECK ADD 
	CONSTRAINT [DF_Domicilii_Tip] DEFAULT ('d') FOR [Tip]
GO

ALTER TABLE [dbo].[Functii] WITH NOCHECK ADD 
	CONSTRAINT [DF_Functii_CodSiemens] DEFAULT ('') FOR [CodSiemens],
	CONSTRAINT [UK_Functii_Cod] UNIQUE  NONCLUSTERED 
	(
		[Cod]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Invaliditati] WITH NOCHECK ADD 
	CONSTRAINT [DF_Invaliditati_Cod] DEFAULT (0) FOR [Cod]
GO

ALTER TABLE [dbo].[Judete] WITH NOCHECK ADD 
	CONSTRAINT [DF_Judete_TaraID] DEFAULT (1) FOR [TaraID]
GO

ALTER TABLE [dbo].[LegitimatiiSedere] WITH NOCHECK ADD 
	CONSTRAINT [DF_LegitimatiiSedere_Activ] DEFAULT (1) FOR [Activ]
GO

ALTER TABLE [dbo].[NIF] WITH NOCHECK ADD 
	CONSTRAINT [DF_NIF_Activ] DEFAULT (1) FOR [Activ]
GO

ALTER TABLE [dbo].[PermiseMunca] WITH NOCHECK ADD 
	CONSTRAINT [DF_PermiseMunca_Activ] DEFAULT (1) FOR [Activ]
GO

ALTER TABLE [dbo].[ReportFields] WITH NOCHECK ADD 
	CONSTRAINT [DF_ReportFields_IsVisible] DEFAULT (1) FOR [IsVisible],
	CONSTRAINT [DF_ReportFields_StartFromIdx] DEFAULT (1) FOR [StartFromIdx]
GO

ALTER TABLE [dbo].[Sal_Luni] WITH NOCHECK ADD 
	CONSTRAINT [DF_Salarii_luni_ProcentInflatie] DEFAULT (0) FOR [ProcentInflatie],
	CONSTRAINT [DF_Sal_Luni_AngajatorID] DEFAULT (5) FOR [AngajatorID]
GO

ALTER TABLE [dbo].[Tari] WITH NOCHECK ADD 
	CONSTRAINT [DF_Tari_TaraDeBaza] DEFAULT (0) FOR [TaraDeBaza]
GO

ALTER TABLE [dbo].[Traininguri] WITH NOCHECK ADD 
	CONSTRAINT [DF_Traininguri_Intern] DEFAULT (1) FOR [Intern]
GO

ALTER TABLE [dbo].[sal_BazeCalculTipuri] WITH NOCHECK ADD 
	CONSTRAINT [DF_sal_BazeCalculTipuri_Descriere] DEFAULT ('') FOR [Descriere]
GO

ALTER TABLE [dbo].[tm_IntervaleAngajat] WITH NOCHECK ADD 
	CONSTRAINT [DF_tm_IntervaleAngajat_CapatInterval] DEFAULT (0) FOR [CapatInterval],
	CONSTRAINT [DF_tm_IntervaleAngajat_Deleted] DEFAULT (0) FOR [Deleted]
GO

ALTER TABLE [dbo].[tm_TipAbsente] WITH NOCHECK ADD 
	CONSTRAINT [DF_tm_TipAbsente_Procent] DEFAULT (0) FOR [Procent],
	CONSTRAINT [DF_tm_TipAbsente_Medical] DEFAULT (0) FOR [Medical],
	CONSTRAINT [DF_tm_TipAbsente_Modificabil] DEFAULT (0) FOR [Modificare],
	CONSTRAINT [DF_tm_TipAbsente_Folosire] DEFAULT (1) FOR [Folosire],
	CONSTRAINT [DF_tm_TipAbsente_Lucratoare] DEFAULT (0) FOR [Lucratoare]
GO

ALTER TABLE [dbo].[tm_TipIntervale] WITH NOCHECK ADD 
	CONSTRAINT [DF_tm_TipIntervale_Procent] DEFAULT (0) FOR [Procent],
	CONSTRAINT [DF_tm_TipIntervale_NrMaximOreSapt] DEFAULT (48) FOR [NrMaximOreSapt],
	CONSTRAINT [DF_tm_TipIntervale_Standard] DEFAULT (0) FOR [Standard],
	CONSTRAINT [DF_tm_TipIntervale_Modificare] DEFAULT (0) FOR [Modificare],
	CONSTRAINT [DF_tm_TipIntervale_Folosire] DEFAULT (1) FOR [Folosire],
	CONSTRAINT [DF_tm_TipIntervale_BonuriMasa] DEFAULT (1) FOR [BonuriMasa],
	CONSTRAINT [DF_tm_TipIntervale_AplicWeekendNoapte] DEFAULT (0) FOR [AplicWeekendNoapte]
GO

ALTER TABLE [dbo].[tm_zile] WITH NOCHECK ADD 
	CONSTRAINT [DF_tm_zile_SetataAdmin] DEFAULT (0) FOR [SetataAdmin]
GO

ALTER TABLE [dbo].[Angajatori] WITH NOCHECK ADD 
	CONSTRAINT [DF_Angajatori_TaraID] DEFAULT (0) FOR [TaraID],
	CONSTRAINT [DF_Angajatori_JudetSector] DEFAULT (0) FOR [JudetSectorID],
	CONSTRAINT [DF_Angajatori_Localitate] DEFAULT ('') FOR [Localitate],
	CONSTRAINT [DF_Angajatori_Strada] DEFAULT ('') FOR [Strada],
	CONSTRAINT [DF_Angajatori_Numar] DEFAULT ('') FOR [Numar],
	CONSTRAINT [DF_Angajatori_CodPostal] DEFAULT ('') FOR [CodPostal],
	CONSTRAINT [DF_Angajatori_ZiLichidareSalar] DEFAULT (6) FOR [ZiLichidareSalar]
GO

ALTER TABLE [dbo].[Salarii_CategoriiAngajati] WITH NOCHECK ADD 
	CONSTRAINT [DF_Salarii_CategoriiAngajati_DPB] DEFAULT (0) FOR [DPB],
	CONSTRAINT [DF_Salarii_CategoriiAngajati_ScutireImpozit] DEFAULT (0) FOR [ScutireImpozit],
	CONSTRAINT [DF_Salarii_CategoriiAngajati_ScutireCASAngajat] DEFAULT (0) FOR [ScutireCASAngajat],
	CONSTRAINT [DF_Salarii_CategoriiAngajati_ScutireCASAngajator] DEFAULT (0) FOR [ScutireCASAngajator],
	CONSTRAINT [DF_Salarii_CategoriiAngajati_ScutireSomajAngajat] DEFAULT (0) FOR [ScutireSomajAngajat],
	CONSTRAINT [DF_Salarii_CategoriiAngajati_ScutireSomajAngajator] DEFAULT (0) FOR [ScutireSomajAngajator],
	CONSTRAINT [DF_Salarii_CategoriiAngajati_ScutireAsigSanAngajat] DEFAULT (0) FOR [ScutireAsigSanAngajat],
	CONSTRAINT [DF_Salarii_CategoriiAngajati_ScutireAsigSanAngajator] DEFAULT (0) FOR [ScutireAsigSanAngajator],
	CONSTRAINT [DF_Salarii_CategoriiAngajati_PrimesteDPB] DEFAULT (0) FOR [PrimesteDPB],
	CONSTRAINT [DF_Salarii_CategoriiAngajati_CoeficientDeducereSuplimentara] DEFAULT (1) FOR [CoeficientDeducereSpeciala]
GO

ALTER TABLE [dbo].[Salarii_impozite] WITH NOCHECK ADD 
	CONSTRAINT [DF_Salarii_impozite_Tip] DEFAULT (N'angajat') FOR [Tip]
GO

ALTER TABLE [dbo].[Angajati] WITH NOCHECK ADD 
	CONSTRAINT [DF_Angajati_NumeAnterior] DEFAULT ('') FOR [NumeAnterior],
	CONSTRAINT [DF_Angajati_Activ] DEFAULT (0) FOR [Activ],
	CONSTRAINT [DF_Angajati_Sporuri] DEFAULT (0) FOR [Sporuri],
	CONSTRAINT [DF_Angajati_AlteAdaosuri] DEFAULT (0) FOR [AlteAdaosuri],
	CONSTRAINT [DF_Angajati_NrZileCOAn] DEFAULT (0) FOR [NrZileCOAn],
	CONSTRAINT [DF_Angajati_NrZileCOSupl] DEFAULT (0) FOR [NrZileCOSupl],
	CONSTRAINT [DF_Angajati_PerioadaDeterminata] DEFAULT (0) FOR [PerioadaDeterminata],
	CONSTRAINT [DF_Angajati_Email] DEFAULT ('') FOR [Email],
	CONSTRAINT [DF_Angajati_TelMunca] DEFAULT ('+40 (268) 407 000') FOR [TelMunca],
	CONSTRAINT [DF_Angajati_Deleted] DEFAULT (0) FOR [Deleted],
	CONSTRAINT [DF_Angajati_Pensionar] DEFAULT (0) FOR [Pensionar],
	CONSTRAINT [DF_Angajati_AreAlteVenituri] DEFAULT (0) FOR [AreAlteVenituri],
	CONSTRAINT [DF_Angajati_SolicitaDeduceri] DEFAULT (0) FOR [SolicitaDeduceri],
	CONSTRAINT [DF_Angajati_SumaMajorare] DEFAULT (0) FOR [SumaMajorare]
GO

ALTER TABLE [dbo].[Alerte] WITH NOCHECK ADD 
	CONSTRAINT [DF_Alerte_PerioadaCritica] DEFAULT (0) FOR [PerioadaCritica],
	CONSTRAINT [DF_Alerte_Descriere] DEFAULT ('') FOR [Descriere],
	CONSTRAINT [DF_Alerte_Activ] DEFAULT (1) FOR [Activ]
GO

ALTER TABLE [dbo].[ConturiAngajati] WITH NOCHECK ADD 
	CONSTRAINT [DF_ConturiAngajati_Activ] DEFAULT (0) FOR [Activ]
GO

ALTER TABLE [dbo].[Lichidare] WITH NOCHECK ADD 
	CONSTRAINT [DF_Lichidare_AvansuriDecontare] DEFAULT (0) FOR [AvansuriDecontare],
	CONSTRAINT [DF_Lichidare_Abonamente] DEFAULT (0) FOR [Abonamente],
	CONSTRAINT [DF_Lichidare_TicheteMasa] DEFAULT (0) FOR [TicheteMasa],
	CONSTRAINT [DF_Lichidare_EchipamentLucru] DEFAULT (0) FOR [EchipamentLucru],
	CONSTRAINT [DF_Lichidare_Laptop] DEFAULT (0) FOR [Laptop],
	CONSTRAINT [DF_Lichidare_TelServiciu] DEFAULT (0) FOR [TelServiciu],
	CONSTRAINT [DF_Lichidare_ObiecteInventar] DEFAULT (0) FOR [ObiecteInventar],
	CONSTRAINT [DF_Lichidare_Carti] DEFAULT (0) FOR [Carti],
	CONSTRAINT [DF_Lichidare_CD] DEFAULT (0) FOR [CD]
GO

ALTER TABLE [dbo].[Pasapoarte] WITH NOCHECK ADD 
	CONSTRAINT [DF_Pasapoarte_Activ] DEFAULT (1) FOR [Activ]
GO

ALTER TABLE [dbo].[Sal_Salarii] WITH NOCHECK ADD 
	CONSTRAINT [DF_Sal_Salarii_SalariuIncadrare] DEFAULT (0) FOR [SalariuIncadrare],
	CONSTRAINT [DF_Sal_Salarii_ProgramLucru] DEFAULT (8) FOR [ProgramLucru],
	CONSTRAINT [DF_Sal_Salarii_NrOreLucrate] DEFAULT (0) FOR [NrOreLucrate],
	CONSTRAINT [DF_Sal_Salarii_SumaOreLucrate] DEFAULT (0) FOR [SumaOreLucrate],
	CONSTRAINT [DF_Sal_Salarii_NrOreLucrateCondDeoseb] DEFAULT (0) FOR [NrOreLucrateCondDeoseb],
	CONSTRAINT [DF_Sal_Salarii_SumaOreLucrateCondDeoseb] DEFAULT (0) FOR [SumaOreLucrateCondDeoseb],
	CONSTRAINT [DF_Sal_Salarii_NrOreLucrateCondSpeciale] DEFAULT (0) FOR [NrOreLucrateCondSpeciale],
	CONSTRAINT [DF_Sal_Salarii_SumaOreLucrateCondSpeciale] DEFAULT (0) FOR [SumaOreLucrateCondSpeciale],
	CONSTRAINT [DF_Sal_Salarii_NrOreSup50%] DEFAULT (0) FOR [NrOreSup50%],
	CONSTRAINT [DF_Sal_Salarii_SumaOreSup50%] DEFAULT (0) FOR [SumaOreSup50%],
	CONSTRAINT [DF_Sal_Salarii_NrOreSup100%] DEFAULT (0) FOR [NrOreSup100%],
	CONSTRAINT [DF_Sal_Salarii_SumaOreSup100%] DEFAULT (0) FOR [SumaOreSup100%],
	CONSTRAINT [DF_Sal_Salarii_NrOreEvenimDeosebit] DEFAULT (0) FOR [NrOreEvenimDeosebit],
	CONSTRAINT [DF_Sal_Salarii_SumaEvenimDeosebit] DEFAULT (0) FOR [SumaEvenimDeosebit],
	CONSTRAINT [DF_Sal_Salarii_NrOreInvoire] DEFAULT (0) FOR [NrOreInvoire],
	CONSTRAINT [DF_Sal_Salarii_SumaOreInvoire] DEFAULT (0) FOR [SumaOreInvoire],
	CONSTRAINT [DF_Sal_Salarii_NrOreConcediuOdihna] DEFAULT (0) FOR [NrOreConcediuOdihna],
	CONSTRAINT [DF_Sal_Salarii_SumaConcediuOdihna] DEFAULT (0) FOR [SumaConcediuOdihna],
	CONSTRAINT [DF_Sal_Salarii_NrOreConcediuBoala] DEFAULT (0) FOR [NrOreConcediuBoala],
	CONSTRAINT [DF_Sal_Salarii_SporActivSupl] DEFAULT (0) FOR [SporActivSupl],
	CONSTRAINT [DF_Sal_Salarii_EmergencyService] DEFAULT (0) FOR [EmergencyService],
	CONSTRAINT [DF_Sal_Salarii_IndemnizCoducere] DEFAULT (0) FOR [IndemnizCoducere],
	CONSTRAINT [DF_Sal_Salarii_PrimeSpeciale] DEFAULT (0) FOR [PrimeSpeciale],
	CONSTRAINT [DF_Sal_Salarii_CASAngajat] DEFAULT (0) FOR [CASAngajat],
	CONSTRAINT [DF_Sal_Salarii_ContribSanPers] DEFAULT (0) FOR [ContribSanPers],
	CONSTRAINT [DF_Sal_Salarii_CheltProfesionale] DEFAULT (0) FOR [CheltProfesionale],
	CONSTRAINT [DF_Sal_Salarii_DeducerePersonala] DEFAULT (0) FOR [DeducerePersonala],
	CONSTRAINT [DF_Sal_Salarii_DeducereSuplimentara] DEFAULT (0) FOR [DeducereSuplimentara],
	CONSTRAINT [DF_Sal_Salarii_BCImpozit] DEFAULT (0) FOR [BCImpozit],
	CONSTRAINT [DF_Sal_Salarii_Impozit] DEFAULT (0) FOR [Impozit],
	CONSTRAINT [DF_Sal_Salarii_VenitNet] DEFAULT (0) FOR [VenitNet],
	CONSTRAINT [DF_Sal_Salarii_Avans] DEFAULT (0) FOR [Avans],
	CONSTRAINT [DF_Sal_Salarii_AlteRetineri] DEFAULT (0) FOR [AlteRetineri],
	CONSTRAINT [DF_Sal_Salarii_TotalRetineri] DEFAULT (0) FOR [TotalRetineri],
	CONSTRAINT [DF_Sal_Salarii_RestPlata] DEFAULT (0) FOR [RestPlata],
	CONSTRAINT [DF_Sal_Salarii_CASAngajator] DEFAULT (0) FOR [CASAngajator],
	CONSTRAINT [DF_Sal_Salarii_SanatateAngajator] DEFAULT (0) FOR [SanatateAngajator],
	CONSTRAINT [DF_Sal_Salarii_FondRiscAngajator] DEFAULT (0) FOR [FondRiscAngajator],
	CONSTRAINT [DF_Sal_Salarii_CameraMuncaAngajator] DEFAULT (0) FOR [CameraMuncaAngajator],
	CONSTRAINT [DF_Sal_Salarii_BenefAjutorSomaj] DEFAULT (0) FOR [BenefAjutorSomaj],
	CONSTRAINT [DF_Sal_Salarii_CASTot] DEFAULT (0) FOR [CASTot],
	CONSTRAINT [DF_Sal_Salarii_BASS] DEFAULT (0) FOR [BASS],
	CONSTRAINT [DF_Sal_Salarii_NRCAZB] DEFAULT (0) FOR [NRCAZB],
	CONSTRAINT [DF_Sal_Salarii_NRCAZA] DEFAULT (0) FOR [NRCAZA],
	CONSTRAINT [DF_Sal_Salarii_NRCAZP] DEFAULT (0) FOR [NRCAZP],
	CONSTRAINT [DF_Sal_Salarii_NRCAZL] DEFAULT (0) FOR [NRCAZL],
	CONSTRAINT [DF_Sal_Salarii_NRCAZI] DEFAULT (0) FOR [NRCAZI],
	CONSTRAINT [DF_Sal_Salarii_NRCAZC] DEFAULT (0) FOR [NRCAZC],
	CONSTRAINT [DF_Sal_Salarii_NRCAZD] DEFAULT (0) FOR [NRCAZD],
	CONSTRAINT [DF_Sal_Salarii_NRCAZR] DEFAULT (0) FOR [NRCAZR],
	CONSTRAINT [DF_Sal_Salarii_NRPPB] DEFAULT (0) FOR [NRPPB],
	CONSTRAINT [DF_Sal_Salarii_NRPPA] DEFAULT (0) FOR [NRPPA],
	CONSTRAINT [DF_Sal_Salarii_NRPPP] DEFAULT (0) FOR [NRPPP],
	CONSTRAINT [DF_Sal_Salarii_NRPPL] DEFAULT (0) FOR [NRPPL],
	CONSTRAINT [DF_Sal_Salarii_NRPPI] DEFAULT (0) FOR [NRPPI],
	CONSTRAINT [DF_Sal_Salarii_NRPPC] DEFAULT (0) FOR [NRPPC],
	CONSTRAINT [DF_Sal_Salarii_NRPPR] DEFAULT (0) FOR [NRPPR],
	CONSTRAINT [DF_Sal_Salarii_SUMAB] DEFAULT (0) FOR [SUMAB],
	CONSTRAINT [DF_Sal_Salarii_SUMAA] DEFAULT (0) FOR [SUMAA],
	CONSTRAINT [DF_Sal_Salarii_SUMAP] DEFAULT (0) FOR [SUMAP],
	CONSTRAINT [DF_Sal_Salarii_SUMAL] DEFAULT (0) FOR [SUMAL],
	CONSTRAINT [DF_Sal_Salarii_SUMAI] DEFAULT (0) FOR [SUMAI],
	CONSTRAINT [DF_Sal_Salarii_SUMAC] DEFAULT (0) FOR [SUMAC],
	CONSTRAINT [DF_Sal_Salarii_SUMAD] DEFAULT (0) FOR [SUMAD],
	CONSTRAINT [DF_Sal_Salarii_SUMAR] DEFAULT (0) FOR [SUMAR]
GO

ALTER TABLE [dbo].[Sal_SituatieLunaraAngajati] WITH NOCHECK ADD 
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_NrZileLucrateLuna] DEFAULT (0) FOR [NrZileLucrateLuna],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_NrOreConcediuBoalaFirma] DEFAULT (0) FOR [NrOreConcediuBoalaFirma],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_NrOreConcediuBoalaBASS] DEFAULT (0) FOR [NrOreConcediuBoalaBASS],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_NrOreObligatiiCetatenesti] DEFAULT (0) FOR [NrOreObligatiiCetatenesti],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_NrOreAbsenteNemotivate] DEFAULT (0) FOR [NrOreAbsenteNemotivate],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_NrOreConcediuFaraPlata] DEFAULT (0) FOR [NrOreConcediuFaraPlata],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_NrOreLucrateDelegatieInterna] DEFAULT (0) FOR [NrOreLucrateDelegatieInterna],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_NrOreLucrateDelegatieExterna] DEFAULT (0) FOR [NrOreLucrateDelegatieExterna],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_NroreTotalDelegatieInterna] DEFAULT (0) FOR [NrOreTotalDelegatieInterna],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_NrOreTotalDelegatieExterna] DEFAULT (0) FOR [NrOreTotalDelegatieExterna],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_PrimeProiect] DEFAULT (0) FOR [PrimeProiect],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_AlteDrepturiNet] DEFAULT (0) FOR [AlteDrepturiNet],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_ProgramLucru] DEFAULT (8) FOR [ProgramLucru],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_SalariuBaza] DEFAULT (0) FOR [SalariuBaza],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_IndemnizatieConducere] DEFAULT (0) FOR [IndemnizatieConducere],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_Invaliditate] DEFAULT (4) FOR [Invaliditate],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_NrOreEmergencyService] DEFAULT (0) FOR [NrOreEmergencyService],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_Avans] DEFAULT (0) FOR [Avans],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_Retineri] DEFAULT (0) FOR [Retineri],
	CONSTRAINT [DF_Sal_SituatieLunaraAngajati_PrimaProiect] DEFAULT (0) FOR [PrimaProiect]
GO

ALTER TABLE [dbo].[sal_StatDePlata] WITH NOCHECK ADD 
	CONSTRAINT [DF_sal_StatDePlata_Prime] DEFAULT (0) FOR [Prime],
	CONSTRAINT [DF_sal_StatDePlata_AlteDrepturi] DEFAULT (0) FOR [AlteDrepturi],
	CONSTRAINT [DF_sal_StatDePlata_IndemnizatieConcediuMedical] DEFAULT (0) FOR [IndemnizatieConcediuMedical],
	CONSTRAINT [DF_sal_StatDePlata_VenitBrut] DEFAULT (0) FOR [VenitBrut],
	CONSTRAINT [DF_sal_StatDePlata_VenitNet] DEFAULT (0) FOR [VenitNet],
	CONSTRAINT [DF_sal_StatDePlata_DeduceriPersonale] DEFAULT (0) FOR [DeduceriPersonale],
	CONSTRAINT [DF_sal_StatDePlata_BazaImpozitare] DEFAULT (0) FOR [BazaImpozitare],
	CONSTRAINT [DF_sal_StatDePlata_Impozit] DEFAULT (0) FOR [Impozit],
	CONSTRAINT [DF_sal_StatDePlata_SalariuNet] DEFAULT (0) FOR [SalariuNet],
	CONSTRAINT [DF_sal_StatDePlata_RestDePlata] DEFAULT (0) FOR [RestDePlata]
GO

ALTER TABLE [dbo].[tm_IntervaleAbsenta] WITH NOCHECK ADD 
	CONSTRAINT [DF_tm_IntervaleAbsenta_ContinuareAbsenta] DEFAULT (0) FOR [ContinuareAbsenta],
	CONSTRAINT [DF_tm_IntervaleAbsenta_MedieZilnica] DEFAULT (0) FOR [MedieZilnica]
GO

 CREATE  INDEX [IX_ConcediuMedicZilePlatite] ON [dbo].[ConcediuMedicZilePlatite]([id_Criteriu]) ON [PRIMARY]
GO

 CREATE  INDEX [IX_IstoricTraininguri] ON [dbo].[IstoricTraining]([AngajatID]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Angajatori] ADD 
	CONSTRAINT [FK_Angajatori_Judete] FOREIGN KEY 
	(
		[JudetSectorID]
	) REFERENCES [dbo].[Judete] (
		[JudetID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[DurateAngajare] ADD 
	CONSTRAINT [FK_DurateAngajare_ModalitatiLichidare] FOREIGN KEY 
	(
		[ModLichidareID]
	) REFERENCES [dbo].[ModalitatiLichidare] (
		[ModLichidareID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[Salarii_CategoriiAngajati] ADD 
	CONSTRAINT [FK_Salarii_CategoriiAngajati_sal_luni] FOREIGN KEY 
	(
		[LunaID]
	) REFERENCES [dbo].[Sal_Luni] (
		[LunaID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[Salarii_impozite] ADD 
	CONSTRAINT [FK_Salarii_impozite_Salarii_AplicareSumeImpozit] FOREIGN KEY 
	(
		[AplicatLaID]
	) REFERENCES [dbo].[Salarii_AplicareSumeImpozit] (
		[AplicatLaID]
	)
GO

ALTER TABLE [dbo].[sal_VariabileGlobale] ADD 
	CONSTRAINT [FK_sal_VariabileGlobale_sal_luni1] FOREIGN KEY 
	(
		[LunaID]
	) REFERENCES [dbo].[Sal_Luni] (
		[LunaID]
	)
GO

ALTER TABLE [dbo].[sal_VariabileGlobaleValori] ADD 
	CONSTRAINT [FK_sal_VariabileGlobaleValori_Sal_Luni] FOREIGN KEY 
	(
		[LunaID]
	) REFERENCES [dbo].[Sal_Luni] (
		[LunaID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_sal_VariabileGlobaleValori_sal_VariabileGlobaleTipuri] FOREIGN KEY 
	(
		[VariabilaGlobalaID]
	) REFERENCES [dbo].[sal_VariabileGlobaleTipuri] (
		[VariabilaGlobalaID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[Angajati] ADD 
	CONSTRAINT [FK_Angajati_Angajatori] FOREIGN KEY 
	(
		[AngajatorID]
	) REFERENCES [dbo].[Angajatori] (
		[AngajatorID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_Angajati_Salarii_CategoriiAngajati] FOREIGN KEY 
	(
		[CategorieID]
	) REFERENCES [dbo].[Salarii_CategoriiAngajati] (
		[CategorieID]
	)
GO

ALTER TABLE [dbo].[Conturi] ADD 
	CONSTRAINT [FK_Conturi_Angajatori] FOREIGN KEY 
	(
		[TitularID]
	) REFERENCES [dbo].[Angajatori] (
		[AngajatorID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_Conturi_Banci] FOREIGN KEY 
	(
		[BancaID]
	) REFERENCES [dbo].[Banci] (
		[BancaID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[Salarii_AsignareImpozite] ADD 
	CONSTRAINT [FK_Salarii_AsignareImpozite_Salarii_impozite] FOREIGN KEY 
	(
		[ImpozitID]
	) REFERENCES [dbo].[Salarii_impozite] (
		[ImpozitID]
	)
GO

ALTER TABLE [dbo].[Salarii_impozitar] ADD 
	CONSTRAINT [FK_Salarii_impozitar_Salarii_CategoriAngajati] FOREIGN KEY 
	(
		[CategorieID]
	) REFERENCES [dbo].[Salarii_CategoriiAngajati] (
		[CategorieID]
	) ON DELETE CASCADE 
GO

ALTER TABLE [dbo].[sal_Impozitar] ADD 
	CONSTRAINT [FK_sal_Impozitar_Salarii_CategoriiAngajati] FOREIGN KEY 
	(
		[CategorieID]
	) REFERENCES [dbo].[Salarii_CategoriiAngajati] (
		[CategorieID]
	)
GO

ALTER TABLE [dbo].[Alerte] ADD 
	CONSTRAINT [FK_Alerte_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE  NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[AngajatPersoaneInIntretinere] ADD 
	CONSTRAINT [FK_AngajatPersoaneInIntretinere_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[AngajatiClauze] ADD 
	CONSTRAINT [FK_AngajatiClauze_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_AngajatiClauze_ClauzeSpeciale] FOREIGN KEY 
	(
		[ClauzaSpecialaID]
	) REFERENCES [dbo].[ClauzeSpeciale] (
		[ClauzaSpecialaID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[AngajatiIntreruperi] ADD 
	CONSTRAINT [FK_AngajatiIntreruperi_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	)
GO

ALTER TABLE [dbo].[AngajatiRetineri] ADD 
	CONSTRAINT [FK_AngajatiRetineri_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[CarneteMunca] ADD 
	CONSTRAINT [FK_CarneteMunca_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[Checkupuri] ADD 
	CONSTRAINT [FK_Checkupuri_Angajati] FOREIGN KEY 
	(
		[ResponsabilID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	),
	CONSTRAINT [FK_Checkupuri_Angajati1] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	)
GO

ALTER TABLE [dbo].[ConturiAngajati] ADD 
	CONSTRAINT [FK_ConturiAngajati_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	),
	CONSTRAINT [FK_ConturiAngajati_Banci] FOREIGN KEY 
	(
		[BancaID]
	) REFERENCES [dbo].[Banci] (
		[BancaID]
	)
GO

ALTER TABLE [dbo].[Departamente] ADD 
	CONSTRAINT [FK_Departamente_Angajati] FOREIGN KEY 
	(
		[SefID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	),
	CONSTRAINT [FK_Departamente_Angajati1] FOREIGN KEY 
	(
		[InlocSefID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	)
GO

ALTER TABLE [dbo].[Directori] ADD 
	CONSTRAINT [FK_Directori_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	),
	CONSTRAINT [FK_Directori_Angajatori] FOREIGN KEY 
	(
		[AngajatorID]
	) REFERENCES [dbo].[Angajatori] (
		[AngajatorID]
	)
GO

ALTER TABLE [dbo].[EvaluariPsihologice] ADD 
	CONSTRAINT [FK_EvaluariPsihologice_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_EvaluariPsihologice_TipuriRapoarte] FOREIGN KEY 
	(
		[TipRaportID]
	) REFERENCES [dbo].[TipuriRapoarte] (
		[TipRaportID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[IstoricActivitati] ADD 
	CONSTRAINT [FK_IstoricActivitati_Activitati] FOREIGN KEY 
	(
		[ActivitateID]
	) REFERENCES [dbo].[Activitati] (
		[ActivitateID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_IstoricActivitati_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[IstoricAngajatiInvaliditati] ADD 
	CONSTRAINT [FK_IstoricAngajatiInvaliditati_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_IstoricAngajatiInvaliditati_Invaliditati] FOREIGN KEY 
	(
		[InvaliditateID]
	) REFERENCES [dbo].[Invaliditati] (
		[InvaliditateID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[IstoricCategoriiAngajati] ADD 
	CONSTRAINT [FK_IstoricCategoriiAngajati_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_IstoricCategoriiAngajati_Categorii] FOREIGN KEY 
	(
		[CategorieID]
	) REFERENCES [dbo].[Categorii] (
		[CategorieID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[IstoricCentreCost] ADD 
	CONSTRAINT [FK_IstoricCentreCost_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_IstoricCentreCost_CentreCost] FOREIGN KEY 
	(
		[CentruCostID]
	) REFERENCES [dbo].[CentreCost] (
		[CentruCostID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[IstoricContracteAngajati] ADD 
	CONSTRAINT [FK_IstoricContracteAngajati_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	),
	CONSTRAINT [FK_IstoricContracteAngajati_Angajatori] FOREIGN KEY 
	(
		[AngajatorID]
	) REFERENCES [dbo].[Angajatori] (
		[AngajatorID]
	),
	CONSTRAINT [FK_IstoricContracteAngajati_Salarii_CategoriiAngajati] FOREIGN KEY 
	(
		[CategorieID]
	) REFERENCES [dbo].[Salarii_CategoriiAngajati] (
		[CategorieID]
	)
GO

ALTER TABLE [dbo].[IstoricDurateAngajari] ADD 
	CONSTRAINT [FK_IstoricDurateAngajari_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_IstoricDurateAngajari_DurateAngajare] FOREIGN KEY 
	(
		[DurataAngajariID]
	) REFERENCES [dbo].[DurateAngajare] (
		[DurataAngajariID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[IstoricFunctii] ADD 
	CONSTRAINT [FK_IstoricFunctii_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_IstoricFunctii_Functii] FOREIGN KEY 
	(
		[FunctieID]
	) REFERENCES [dbo].[Functii] (
		[FunctieID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[IstoricGrupeMunca] ADD 
	CONSTRAINT [FK_IstoricGrupeMunca_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_IstoricGrupeMunca_GrupeMunca] FOREIGN KEY 
	(
		[GrupaMuncaID]
	) REFERENCES [dbo].[GrupeMunca] (
		[GrupaMuncaID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[IstoricLocMunca] ADD 
	CONSTRAINT [FK_IstoricLocMunca_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_IstoricLocMunca_LocuriMunca] FOREIGN KEY 
	(
		[LocMuncaID]
	) REFERENCES [dbo].[LocuriMunca] (
		[LocMuncaID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[IstoricReduceriImpozit] ADD 
	CONSTRAINT [FK_IstoricReduceriImpozit_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_IstoricReduceriImpozit_ReduceriImpozit] FOREIGN KEY 
	(
		[ReducereImpozitID]
	) REFERENCES [dbo].[ReduceriImpozit] (
		[ReducereImpozitID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[IstoricSalariiIncadrareAngajati] ADD 
	CONSTRAINT [FK_IstoricSalariiIncadrareAngajati_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_IstoricSalariiIncadrareAngajati_SalariiIncadrare] FOREIGN KEY 
	(
		[SalariuIncadrareID]
	) REFERENCES [dbo].[SalariiIncadrare] (
		[SalariuIncadrareID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[IstoricTraining] ADD 
	CONSTRAINT [FK_IstoricTraininguri_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_IstoricTraininguri_Traininguri] FOREIGN KEY 
	(
		[TrainingID]
	) REFERENCES [dbo].[Traininguri] (
		[TrainingID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[Lichidare] ADD 
	CONSTRAINT [FK_Lichidare_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	)
GO

ALTER TABLE [dbo].[Pasapoarte] ADD 
	CONSTRAINT [FK_Pasapoarte_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[Referinte] ADD 
	CONSTRAINT [FK_Referinte_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[Sal_Salarii] ADD 
	CONSTRAINT [FK_Sal_Salarii_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	),
	CONSTRAINT [FK_Sal_Salarii_sal_luni] FOREIGN KEY 
	(
		[LunaID]
	) REFERENCES [dbo].[Sal_Luni] (
		[LunaID]
	)
GO

ALTER TABLE [dbo].[Sal_SituatieLunaraAngajati] ADD 
	CONSTRAINT [FK_Sal_SituatieLunaraAngajati_sal_luni] FOREIGN KEY 
	(
		[LunaID]
	) REFERENCES [dbo].[Sal_Luni] (
		[LunaID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_Sal_SituatieLunaraAngajati_Salarii_CategoriiAngajati] FOREIGN KEY 
	(
		[CategorieID]
	) REFERENCES [dbo].[Salarii_CategoriiAngajati] (
		[CategorieID]
	),
	CONSTRAINT [FK_Salarii_SituatieLunaraAngajati_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	)
GO

ALTER TABLE [dbo].[Salarii_DateSuplimentareLunare] ADD 
	CONSTRAINT [FK_Salarii_DateSuplimentareLunare_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	),
	CONSTRAINT [FK_Salarii_DateSuplimentareLunare_GrupeMunca] FOREIGN KEY 
	(
		[GrupaMuncaID]
	) REFERENCES [dbo].[GrupeMunca] (
		[GrupaMuncaID]
	),
	CONSTRAINT [FK_Salarii_DateSuplimentareLunare_Invaliditati] FOREIGN KEY 
	(
		[InvaliditateID]
	) REFERENCES [dbo].[Invaliditati] (
		[InvaliditateID]
	),
	CONSTRAINT [FK_Salarii_DateSuplimentareLunare_Salarii_CategoriiAngajati] FOREIGN KEY 
	(
		[CategorieID]
	) REFERENCES [dbo].[Salarii_CategoriiAngajati] (
		[CategorieID]
	)
GO

ALTER TABLE [dbo].[Salarii_RetineriLunare] ADD 
	CONSTRAINT [FK_Salarii_RetineriLunare_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	)
GO

ALTER TABLE [dbo].[Salarii_SporuriLunare] ADD 
	CONSTRAINT [FK_AngajatiSporuri_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_Salarii_SporuriLunare_Sporuri] FOREIGN KEY 
	(
		[SporID]
	) REFERENCES [dbo].[Sporuri] (
		[SporID]
	)
GO

ALTER TABLE [dbo].[SituatieMilitara] ADD 
	CONSTRAINT [FK_SituatieMilitara_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[sal_BazeCalculLuna] ADD 
	CONSTRAINT [FK_sal_BazeCalculLuna_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	),
	CONSTRAINT [FK_sal_BazeCalculLuna_Angajatori] FOREIGN KEY 
	(
		[AngajatorID]
	) REFERENCES [dbo].[Angajatori] (
		[AngajatorID]
	),
	CONSTRAINT [FK_sal_BazeCalculLuna_sal_BazeCalculTipuri] FOREIGN KEY 
	(
		[BazaCalculID]
	) REFERENCES [dbo].[sal_BazeCalculTipuri] (
		[BazaCalculID]
	),
	CONSTRAINT [FK_sal_BazeCalculLuna_Sal_Luni] FOREIGN KEY 
	(
		[LunaID]
	) REFERENCES [dbo].[Sal_Luni] (
		[LunaID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[sal_ContributiiIndivLuna] ADD 
	CONSTRAINT [FK_sal_ContributiiIndivLuna_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	),
	CONSTRAINT [FK_sal_ContributiiIndivLuna_Angajatori] FOREIGN KEY 
	(
		[AngajatorID]
	) REFERENCES [dbo].[Angajatori] (
		[AngajatorID]
	),
	CONSTRAINT [FK_sal_ContributiiIndivLuna_sal_ContributiiIndivTipuri] FOREIGN KEY 
	(
		[ContributieIndivID]
	) REFERENCES [dbo].[sal_ContributiiIndivTipuri] (
		[ContributieIndivID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_sal_ContributiiIndivLuna_Sal_Luni] FOREIGN KEY 
	(
		[LunaID]
	) REFERENCES [dbo].[Sal_Luni] (
		[LunaID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[sal_StatDePlata] ADD 
	CONSTRAINT [FK_sal_StatDePlata_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	),
	CONSTRAINT [FK_sal_StatDePlata_Sal_Luni] FOREIGN KEY 
	(
		[LunaID]
	) REFERENCES [dbo].[Sal_Luni] (
		[LunaID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[tm_IntervaleAbsenta] ADD 
	CONSTRAINT [FK_tm_IntervaleAbsenta_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	),
	CONSTRAINT [FK_tm_IntervaleAbsenta_Boli] FOREIGN KEY 
	(
		[BoalaID]
	) REFERENCES [dbo].[Boli] (
		[BoalaID]
	),
	CONSTRAINT [FK_tm_IntervaleAbsenta_tm_TipAbsente] FOREIGN KEY 
	(
		[TipAbsentaID]
	) REFERENCES [dbo].[tm_TipAbsente] (
		[TipAbsentaID]
	)
GO

ALTER TABLE [dbo].[IstoricAngajatDepartament] ADD 
	CONSTRAINT [FK_IstoricAngajatDepartament_Angajati] FOREIGN KEY 
	(
		[AngajatID]
	) REFERENCES [dbo].[Angajati] (
		[AngajatID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_IstoricAngajatDepartament_Departamente] FOREIGN KEY 
	(
		[DepartamentID]
	) REFERENCES [dbo].[Departamente] (
		[DepartamentID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO

ALTER TABLE [dbo].[tm_IntervaleAbsentaContinuare] ADD 
	CONSTRAINT [FK_tm_IntervaleAbsentaContinuare_Boli] FOREIGN KEY 
	(
		[BoalaID]
	) REFERENCES [dbo].[Boli] (
		[BoalaID]
	),
	CONSTRAINT [FK_tm_IntervaleAbsentaContinuare_tm_IntervaleAbsenta] FOREIGN KEY 
	(
		[AbsentaID]
	) REFERENCES [dbo].[tm_IntervaleAbsenta] (
		[IntervalAbsentaID]
	) ON DELETE CASCADE 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE VIEW dbo.GetFullAngajatoriInfo
AS
SELECT     dbo.Angajatori.*, dbo.Banci.Nume AS NumeBanca, dbo.Conturi.NumarCont AS NumarCont, dbo.Judete.Nume AS Judet
FROM         dbo.Angajatori INNER JOIN
                      dbo.Conturi ON dbo.Angajatori.AngajatorID = dbo.Conturi.TitularID INNER JOIN
                      dbo.Banci ON dbo.Conturi.BancaID = dbo.Banci.BancaID INNER JOIN
                      dbo.Judete ON dbo.Angajatori.JudetSectorID = dbo.Judete.JudetID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE VIEW dbo.AngajatiFaraCardBancar
AS
SELECT     TOP 100 PERCENT dbo.Angajati.Marca, dbo.Angajati.Nume, dbo.Angajati.Prenume, dbo.IstoricSalariiIncadrareAngajati.DataStart, 
                      dbo.SalariiIncadrare.SalariuIncadrare
FROM         dbo.Angajati LEFT OUTER JOIN
                      dbo.IstoricSalariiIncadrareAngajati ON dbo.Angajati.AngajatID = dbo.IstoricSalariiIncadrareAngajati.AngajatID LEFT OUTER JOIN
                      dbo.SalariiIncadrare ON dbo.IstoricSalariiIncadrareAngajati.SalariuIncadrareID = dbo.SalariiIncadrare.SalariuIncadrareID
WHERE     (dbo.Angajati.AreCardBancar = 0)
ORDER BY dbo.Angajati.Nume


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


CREATE VIEW IstoricCuCentreCost
AS
SELECT
	icc.AngajatID, icc.DataStart, icc.CentruCostID, 
	cec.Cod, cec.Nume, cec.Descriere
FROM IstoricCentreCost icc
	LEFT OUTER JOIN CentreCost cec ON icc.CentruCostID = cec.CentruCostID




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


CREATE VIEW IstoricCuFunctii
AS
SELECT
	ifc.AngajatID, ifc.DataStart, ifc.FunctieID, 
	fct.Cod, fct.Nume, fct.Descriere, fct.NormaLucru
FROM IstoricFunctii ifc 
	LEFT OUTER JOIN dbo.Functii fct ON fct.FunctieID = ifc.FunctieID





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.v_StatDePlata
AS
SELECT     dbo.Angajati.Marca, dbo.Angajati.NumeIntreg, dbo.sal_StatDePlata.*, dbo.Sal_Luni.Data, dbo.Sal_SituatieLunaraAngajati.SalariuBaza, 
                      dbo.Sal_SituatieLunaraAngajati.IndemnizatieConducere,
                          (SELECT     dbo.sal_BazeCalculLuna.Valoare
                            FROM          dbo.sal_BazeCalculLuna INNER JOIN
                                                   dbo.sal_BazeCalculTipuri ON dbo.sal_BazeCalculLuna.BazaCalculID = dbo.sal_BazeCalculTipuri.BazaCalculID
                            WHERE      sal_BazeCalculLuna.LunaID = sal_StatDePlata.LunaID AND sal_BazeCalculLuna.AngajatID = sal_StatDePlata.AngajatID AND 
                                                   sal_BazeCalculTipuri.Cod = 'BCICAS') AS BCContribIndivAsigSoc,
                          (SELECT     dbo.sal_BazeCalculLuna.Valoare
                            FROM          dbo.sal_BazeCalculLuna INNER JOIN
                                                   dbo.sal_BazeCalculTipuri ON dbo.sal_BazeCalculLuna.BazaCalculID = dbo.sal_BazeCalculTipuri.BazaCalculID
                            WHERE      sal_BazeCalculLuna.LunaID = sal_StatDePlata.LunaID AND sal_BazeCalculLuna.AngajatID = sal_StatDePlata.AngajatID AND 
                                                   sal_BazeCalculTipuri.Cod = 'BCISAN') AS BCContribIndivSanatate,
                          (SELECT     dbo.sal_BazeCalculLuna.Valoare
                            FROM          dbo.sal_BazeCalculLuna INNER JOIN
                                                   dbo.sal_BazeCalculTipuri ON dbo.sal_BazeCalculLuna.BazaCalculID = dbo.sal_BazeCalculTipuri.BazaCalculID
                            WHERE      sal_BazeCalculLuna.LunaID = sal_StatDePlata.LunaID AND sal_BazeCalculLuna.AngajatID = sal_StatDePlata.AngajatID AND 
                                                   sal_BazeCalculTipuri.Cod = 'BCISOM') AS BCContribIndivAsigSomaj,
                          (SELECT     dbo.sal_ContributiiIndivLuna.Valoare
                            FROM          dbo.sal_ContributiiIndivLuna INNER JOIN
                                                   dbo.sal_ContributiiIndivTipuri ON 
                                                   dbo.sal_ContributiiIndivLuna.ContributieIndivID = dbo.sal_ContributiiIndivTipuri.ContributieIndivID
                            WHERE      (dbo.sal_ContributiiIndivLuna.LunaID = sal_StatDePlata.LunaID) AND 
                                                   (dbo.sal_ContributiiIndivLuna.AngajatID = sal_StatDePlata.AngajatID) AND (sal_ContributiiIndivTipuri.Cod = 'CICAS')) 
                      AS ContributieIndivAsigurariSociale,
                          (SELECT     dbo.sal_ContributiiIndivLuna.Valoare
                            FROM          dbo.sal_ContributiiIndivLuna INNER JOIN
                                                   dbo.sal_ContributiiIndivTipuri ON 
                                                   dbo.sal_ContributiiIndivLuna.ContributieIndivID = dbo.sal_ContributiiIndivTipuri.ContributieIndivID
                            WHERE      (dbo.sal_ContributiiIndivLuna.LunaID = sal_StatDePlata.LunaID) AND 
                                                   (dbo.sal_ContributiiIndivLuna.AngajatID = sal_StatDePlata.AngajatID) AND (sal_ContributiiIndivTipuri.Cod = 'CISAN')) 
                      AS ContributieIndivSanatate,
                          (SELECT     dbo.sal_ContributiiIndivLuna.Valoare
                            FROM          dbo.sal_ContributiiIndivLuna INNER JOIN
                                                   dbo.sal_ContributiiIndivTipuri ON 
                                                   dbo.sal_ContributiiIndivLuna.ContributieIndivID = dbo.sal_ContributiiIndivTipuri.ContributieIndivID
                            WHERE      (dbo.sal_ContributiiIndivLuna.LunaID = sal_StatDePlata.LunaID) AND 
                                                   (dbo.sal_ContributiiIndivLuna.AngajatID = sal_StatDePlata.AngajatID) AND (sal_ContributiiIndivTipuri.Cod = 'CISOM')) 
                      AS ContributieIndivSomaj, dbo.Angajati.AngajatorID
FROM         dbo.Angajati INNER JOIN
                      dbo.Sal_SituatieLunaraAngajati ON dbo.Angajati.AngajatID = dbo.Sal_SituatieLunaraAngajati.AngajatID INNER JOIN
                      dbo.Sal_Luni ON dbo.Sal_SituatieLunaraAngajati.LunaID = dbo.Sal_Luni.LunaID INNER JOIN
                      dbo.sal_StatDePlata ON dbo.Angajati.AngajatID = dbo.sal_StatDePlata.AngajatID AND dbo.Sal_Luni.LunaID = dbo.sal_StatDePlata.LunaID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


CREATE VIEW IstoricCuDepartamente
AS
SELECT
	iad.AngajatID, iad.DataStart, iad.DepartamentID, 
	dep.Cod, dep.Denumire, dep.SefID, dep.InlocSefID, dep.DeptParinte
FROM IstoricAngajatDepartament iad 
	LEFT OUTER JOIN dbo.Departamente dep ON dep.DepartamentID = iad.DepartamentID






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE VIEW dbo.AngajatFull
AS
SELECT     dom.TaraID AS DTaraID, dom.Localitate AS DLocalitate, dom.JudetSectorID AS DJudetSectorID, dom.Strada AS DStrada, dom.Numar AS DNumar, 
                      dom.CodPostal AS DCodPostal, dom.Bloc AS DBloc, dom.Scara AS DScara, dom.Etaj AS DEtaj, dom.Apartament AS DApartament, 
                      res.TaraID AS RTaraID, res.Localitate AS RLocalitate, res.JudetSectorID AS RJudetSectorID, res.Strada AS RStrada, res.Numar AS RNumar, 
                      res.CodPostal AS RCodPostal, res.Bloc AS RBloc, res.Scara AS RScara, res.Etaj AS REtaj, res.Apartament AS RApartament, cai.CNP as CNP, cai.CNPAnterior as CNPAnterior, cai.Serie AS CISerie, 
                      cai.Numar AS CINumar, cai.EliberatDe AS CIEliberatDe, cai.DataEliberarii AS CIDataEliberarii, cai.ValabilPanaLa AS CIValabilPanaLa, 
                      pas.Serie AS PASSerie, pas.Numar AS PASNumar, pas.EliberatDe AS PASEliberatDe, pas.DataEliberarii AS PASDataEliberarii, 
                      pas.ValabilPanaLa AS PASValabilPanaLa, cam.Serie AS CMSerie, cam.Numar AS CMNumar, cam.Emitent AS CMEmitent, 
                      cam.DataEmiterii AS CMDataEmiterii, cam.NrInregITM AS CMNrInregITM, tia.Denumire AS TitluDenumire, tia.Simbol AS TitluSimbol, 
                      dep.Cod AS DepartamentCod, dep.Denumire AS DepartamentDenumire, fct.Cod AS FunctieCod, fct.Nume AS FunctieNume, icc.Cod AS CentruCostCod, 
                      icc.Nume AS CentruCostNume, dbo.Angajatori.Denumire AS NumeAngajator, ISNULL(ang.AreAlteVenituri, 0) AS AreVenituri, 
                      ISNULL(ang.SolicitaDeduceri, 0) AS AreDeduceri, fct.FunctieID, icc.CentruCostID, dep.DepartamentID, pem.PermisMuncaID, pem.NrPermisMunca, 
                      pem.SeriePermisMunca, pem.PermMuncaDataEliberare, pem.PermMuncaDataExpirare, les.LegitimatieSedereID, les.NrLegitimatieSedere, 
                      les.SerieLegitimatieSedere, les.LegitimatieSedereDataEliberare, les.LegitimatieSedereDataExpirare, nif.NIFID, nif.NIF, ang.*
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
	         dbo.CartiIdentitate cai ON ang.AngajatID = cai.AngajatID and cai.Activ=1 LEFT OUTER JOIN
                      dbo.Pasapoarte pas ON ang.AngajatID = pas.AngajatID and pas.Activ=1 LEFT OUTER JOIN
                      dbo.PermiseMunca pem ON ang.AngajatID = pem.AngajatID AND pem.Activ = 1 LEFT OUTER JOIN
                      dbo.LegitimatiiSedere les ON ang.AngajatID = les.AngajatID AND les.Activ = 1 LEFT OUTER JOIN
                      dbo.NIF nif ON ang.AngajatID = nif.AngajatID AND nif.Activ = 1
WHERE     (ang.Activ = 0)



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		Mircea Albutiu, PSE RO BS TH
* Nume:			CautareAngajat
* Descriere:	Cauta un gangajat in baza de date
*/
/*
* Modificare 20.01.2005
*Author:		 Vlad Dovlecel
*Descriere:	Adaugare campuri pt cautare avansata
*/
CREATE PROCEDURE CautareAngajat
(
	@in_Nume nvarchar(50) = -1,
	@in_Prenume nvarchar(50) = -1,

	@in_Nationalitate nvarchar(50) = -1,
	--@in_TaraOrigineID int = -1,--tara de origine
	@in_StareCivila int = -1,
	--@in_Copii int = -1,--copii
	@in_Sex nvarchar(2) = -1,
	@in_TitluID int = -1,
	@in_StudiuID int = -1,
	@in_Marca nvarchar(8) = -1,
	@in_DepartamentID int = -1,
	--@in_CentruCostID int = -1,--centru de cost
	--@in_FunctieID int = -1,--functie
	@in_ModIncadrare int = -1
	--@in_IndemnizatieConducere int = -1,--indemnizatie de conducere

	--Categorie angajat
	--@in_ScutitImpozit int = -1,--Scutit impozit
	--@in_CategorieID int = -1,--Categorie

	--deducere
	--@in_Deducere int = -1,--deducere
	--@in_DeducereCopii int = -1,--deducere copii

	--conturi bancare
	--@in_ContBancarExistenta int = -1,--existenta conturi bancare
	--@in_BancaID int = -1,--banca

	--data angajarii
	--@in_TipDataAngajare int = -1,--tipul de data dupa care se face cautarea
	--@in_DataFixa datetime = null,--data specifica cautarii dupa o data fixa
	--@in_LunaData int = -1,--luna dupa care se face cautarea pt contractele dintr-o anumita luna
	--@in_AnData int = -1,--anul dupa care se face cautarea pt contractele dintr-o anumita luna
	--@in_IntervalDataStart datetime = null,--pt cautare dupa data de start a contractelor dintr-un interval
	--@in_IntervalDataEnd datetime = null,--pt cautare dupa data de start a contractelor dintr-un interval
	--@in_DataMinValue datetime,--data minima care o trimite . net-ul

	--@in_PerioadaDeterminata int = -1--contract pe perioada determinata
)
as

/*create table #date_cautare (AngajatID int, Marca nvarchar(8), Nume nvarchar(50), Prenume nvarchar(50), TitluID int, 
							StudiuID int, ModIncadrare bit, StareCivila tinyint, Nationalitate nvarchar(50), 
							Sex nvarchar(2), Telefon nvarchar(25), DepartamentID int, DepartamentCod nvarchar(10), 
							FunctieNume nvarchar(25))
								
insert into #date_cautare select AngajatID, Marca, Nume, Prenume, TitluID, StudiuID, ModIncadrare, StareCivila, 
							Nationalitate, Sex, Telefon, DepartamentID, DepartamentCod, FunctieNume 
							from AngajatFull*/

create table #date_cautare (AngajatID int, Marca nvarchar(8), Nume nvarchar(50), Prenume nvarchar(50), TitluID int, 
							StudiuID int, ModIncadrare bit, StareCivila tinyint, Nationalitate nvarchar(50), 
							Sex nvarchar(2), Telefon nvarchar(25), DepartamentID int, DepartamentCod nvarchar(10), 
							FunctieNume nvarchar(25))
								
insert into #date_cautare select AngajatID, Marca, Nume, Prenume, TitluID, StudiuID, ModIncadrare, StareCivila, 
							Nationalitate, Sex, Telefon, DepartamentID, DepartamentCod, FunctieNume 
							from AngajatFull

if(@in_Nume <> '-1')
	delete from #date_cautare where Nume not like '%' + @in_Nume + '%'

if(@in_Prenume <> '-1')
	delete from #date_cautare where Prenume not like '%' + @in_Prenume + '%'
	

if(@in_Nationalitate <> '-1')
	delete from #date_cautare where Nationalitate not like '%' + @in_Nationalitate + '%'

-- tara de origine

if(@in_StareCivila <> -1)
	delete from #date_cautare where StareCivila <> @in_StareCivila

--copii

if(@in_Sex <> '-1')
	delete from #date_cautare where Sex not like '%' + @in_Sex + '%'

if(@in_TitluID <> -1)
	delete from #date_cautare where TitluID <> @in_TitluID

if(@in_StudiuID <> -1)
	delete from #date_cautare where StudiuID <> @in_StudiuID

if(@in_Marca <> '-1')
	delete from #date_cautare where Marca not like '%' + @in_Marca + '%'

if(@in_DepartamentID <> -1)
	delete from #date_cautare where DepartamentID <> @in_DepartamentID or DepartamentID is null 

-- centru de cost
--functie

if(@in_ModIncadrare <> -1)
	delete from #date_cautare where ModIncadrare <> @in_ModIncadrare

--indemnizatie de conducere
--Categorie angajat
--deducere
--conturi bancare
--data angajarii
--perioada determinata


select AngajatID, Marca, Nume, Prenume, Telefon, DepartamentCod, FunctieNume from #date_cautare order by Nume

drop table #date_cautare

return 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Vlad Dovlecel, PSE RO BS TH
* Nume:			CountSalIncome
* Descriere:	Calculeaza, diferitele tipuri de impozite si dari catre stat, pe centre de cost.
*/

CREATE PROCEDURE CountSalIncome 
	(@centruCostID int,
--	 @data 		datetime
--	 @luna		int,
--	 @an		int
	 @data		int
	)
AS

create table #emp_CountSall
	(AngajatID int, sumVenitBrut money, sumAjutorSomaj money, sumCASAngajat money, sumContribSanPers money, sumImpozit money, sumCASAngajator money, sumSomajAngajator money, sumSanatateAngajator money,
	sumFondRiscAngajator money, sumCameraMuncaAngajator money, sumAvans money)


if( @centruCostID > -1 )
begin
	insert into #emp_CountSall
		Select sal.AngajatID, Sum( sal.VenitBrut ) as sumVenitBrut, Sum( sal.AjutorSomaj ) as sumSomajAngajat, Sum( sal.CASAngajat ) as sumCASAngajat, Sum( sal.ContribSanPers ) as sumContribSanPers,
			Sum( sal.Impozit ) as sumImpozit, Sum( sal.CASAngajator ) as sumCASAngajator, Sum( sal.SomajAngajator ) as sumSomajAngajator, Sum( sal.SanatateAngajator ) as sumSanatateAngajator,
			Sum( sal.FondRiscAngajator ) as sumFondRisc, Sum( sal.CameraMuncaAngajator ) as sumCamMuncaAngajator, Sum( sal.Avans ) as sumAvans
		From Sal_Salarii sal Inner Join AngajatFull angf On sal.AngajatID = angf.AngajatID
		--Where( angf.CentruCostID = @centruCostID ) and (( month( @data ) = month( sal.DataPlatii )) and (year( @data) = year( sal.DataPlatii )))
		--Where( angf.CentruCostID = @centruCostID ) and (( @luna = month( sal.DataPlatii )) and ( @an = year( sal.DataPlatii )))
		Where( angf.CentruCostID = @centruCostID ) and (sal.LunaID = @data )
		Group By sal.AngajatID
	Select count( AngajatID ) as noangajati, Sum( sumVenitBrut ) as sumVenitBrutAfis, Sum( sumAjutorSomaj ) as sumSomajAngajatAfis, Sum( sumCASAngajat ) as sumCASAngajatAfis, Sum( sumContribSanPers ) as sumContribSanPersAfis,
			Sum( sumImpozit ) as sumImpozitAfis, Sum( sumCASAngajator ) as sumCASAngajatorAfis, Sum( sumSomajAngajator ) as sumSomajAngajatorAfis, Sum( sumSanatateAngajator ) as sumSanatateAngajatorAfis,
			Sum( sumFondRiscAngajator ) as sumFondRiscAfis, Sum( sumCameraMuncaAngajator ) as sumCamMuncaAngajatorAfis, Sum( sumAvans ) as sumAvansAfis
	From #emp_CountSall
end
if( @centruCostID = -1 )
begin
	insert into #emp_CountSall
		Select sal.AngajatID, Sum( sal.VenitBrut ) as sumVenitBrut, Sum( sal.AjutorSomaj ) as sumSomajAngajat, Sum( sal.CASAngajat ) as sumCASAngajat, Sum( sal.ContribSanPers ) as sumContribSanPers,
			Sum( sal.Impozit ) as sumImpozit, Sum( sal.CASAngajator ) as sumCASAngajator, Sum( sal.SomajAngajator ) as sumSomajAngajator, Sum( sal.SanatateAngajator ) as sumSanatateAngajator,
			Sum( sal.FondRiscAngajator ) as sumFondRisc, Sum( sal.CameraMuncaAngajator ) as sumCamMuncaAngajator, Sum( sal.Avans ) as sumAvans
		From Sal_Salarii sal Inner Join AngajatFull angf On sal.AngajatID = angf.AngajatID
		--Where( month( @data ) = month( sal.DataPlatii )) and (year( @data) = year( sal.DataPlatii )))
		--Where (angf.CentruCostID is not null ) and ( @luna = month( sal.DataPlatii )) and ( @an = year( sal.DataPlatii ))
		Where( angf.CentruCostID is not null ) and (sal.LunaID = @data )
		Group By sal.AngajatID
	Select count( AngajatID ) as noangajati, Sum( sumVenitBrut ) as sumVenitBrutAfis, Sum( sumAjutorSomaj ) as sumSomajAngajatAfis, Sum( sumCASAngajat ) as sumCASAngajatAfis, Sum( sumContribSanPers ) as sumContribSanPersAfis,
			Sum( sumImpozit ) as sumImpozitAfis, Sum( sumCASAngajator ) as sumCASAngajatorAfis, Sum( sumSomajAngajator ) as sumSomajAngajatorAfis, Sum( sumSanatateAngajator ) as sumSanatateAngajatorAfis,
			Sum( sumFondRiscAngajator ) as sumFondRiscAfis, Sum( sumCameraMuncaAngajator ) as sumCamMuncaAngajatorAfis, Sum( sumAvans ) as sumAvansAfis
	From #emp_CountSall

end

--Select sal.AngajatID, Sum( sal.VenitBrut ) as sumVenitBrut, Sum( sal.AjutorSomaj ) as sumSomajAngajat, Sum( sal.CASAngajat ) as sumCASAngajat, Sum( sal.ContribSanPers ) as sumContribSanPers,
--			Sum( sal.Impozit ) as sumImpozit, Sum( sal.CASAngajator ) as sumCASAngajator, Sum( sal.SomajAngajator ) as sumSomajAngajator, Sum( sal.SanatateAngajator ) as sumSantateAngajator,
--			Sum( sal.FondRiscAngajator ) as sumFondRisc, Sum( sal.CameraMuncaAngajator ) as sumCamMuncaAngajator
--		From Sal_Salarii sal Inner Join AngajatFull angf On sal.AngajatID = angf.AngajatID
--		--Where( angf.CentruCostID = @centruCostID ) and (( month( @data ) = month( sal.DataPlatii )) and (year( @data) = year( sal.DataPlatii )))
--		Where( angf.CentruCostID = @centruCostID ) and (( @luna = month( sal.DataPlatii )) and ( @an = year( sal.DataPlatii )))
--		Group By sal.AngajatID
drop table #emp_CountSall

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
	Author: Popa Ionel
	Description: Creaza un backup al bazei de date
	Params: calea unde se salveaza backup-ul
*/

CREATE PROCEDURE CreateBackup
(
	@path nvarchar(512)
)
AS


declare @backupName nvarchar(255)
declare @backupPath nvarchar(512)

set @backupName = 'SiemensHR_Test_' + cast(day(getdate()) as varchar(2)) + cast(month(getdate()) as varchar(2)) + cast(year(getdate()) as varchar(4)) + '.bak'
set @backupPath = @path + @backupName

EXEC sp_dropdevice 'MyNwind_1'
EXEC sp_addumpdevice 'disk', 'MyNwind_1', @backupPath

-- Back up the full SiemensHR_Test database.
BACKUP DATABASE SiemensHR_Test TO MyNwind_1
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Autor: Cristina Raluca Muntean
--Nume: GetAlertaInfo
--Descriere: Returneaza toate detaliile legate de o alerta

CREATE PROCEDURE GetAlertaInfo
(
		@AlertaID int
)

AS
select *

from Alerte

where Alerte.AlertaID = @AlertaID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Autor: Cristina Raluca Muntean
--Nume: GetAngajatAlerte
--Descriere: Returneaza toate alertele speciale pentru un angajat

CREATE PROCEDURE GetAngajatAlerte
(
		@AngajatID int
)

AS
select *

from Alerte

where Alerte.AngajatID = @AngajatID

order by Alerte.DataExpirare

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



/*
*	Author: Popa Ionel
*	Description: extrage alertele speciale pentru angajati
*	Params: -
*
*	Changes History:
*		- 24.11.04 - Popa Ionel: reimplementarea procedurii
*/

CREATE  PROCEDURE GetAngajatiAlerteSpeciale  AS


--select AngajatID, Marca, NumeIntreg, (select dbo.FormatData(PASValabilPanaLa)) as PASValabilPanaLa   from angajatfull
--where activ =0 and datediff( month, getdate(), PASValabilPanaLa ) <= 8

select angajati.angajatid, angajati.marca, angajati.nume as numeintreg, alerte.descriere,  (select dbo.FormatData(alerte.dataexpirare))  as data
from angajati, alerte
where angajati.angajatid = alerte.angajatid and datediff(day, getdate(), alerte.dataexpirare) <= alerte.PerioadaCritica

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



/*
*	Author: unknown
*	Description: obtine angajatii carora le expira contractul in luna curenta
*	Params: -
*
*	Change History:
*		- 23.11.2004 . Popa Ionel: reimplementarea procedurii
*/
CREATE  PROCEDURE GetAngajatiExpiraContractLunaCurenta AS
select AngajatID, Marca, NumeIntreg, (select dbo.FormatData(dataPanaLa)) as dataPanaLa
from angajatfull 
where activ =0 and  PerioadaDeterminata=1 and  datediff(month, dataPanaLa, getdate())  >= 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



/*
*	Author: Vlad Dovlecel
*	Description: extrage angajatii care au mai putin de o luna pana la data stabilita de renegociere a majorarii
*	Params: -
*/
CREATE  PROCEDURE GetAngajatiExpiraDataMajorare AS


select AngajatID, Marca, NumeIntreg, (select dbo.FormatData(DataMajorare)) as DataMajorare 
from angajatfull
where activ =0 and datediff( month, getdate(), DataMajorare ) <= 1

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



/*
*	Author: Dima
*	Description: extrage angajatii carora le expira pasaportul in mai putin de 8 luni
*	Params: -
*
*	Changes History:
*		- 24.11.04 - Popa Ionel: reimplementarea procedurii
*/
CREATE  PROCEDURE GetAngajatiExpiraPasaport AS


select AngajatID, Marca, NumeIntreg, (select dbo.FormatData(PASValabilPanaLa)) as PASValabilPanaLa   from angajatfull
where activ =0 and datediff( month, getdate(), PASValabilPanaLa ) <= 8

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



/*
*	Author: Dima
*	Description: extrage angajatii carora le expira permisul de munca in mai putin de 60 zile
*	Params: -
*
*	Changes History:
*		- 24.11.04 - Popa Ionel: reimplementarea procedurii
		- 29.01.05 - Vlad Dovlecel:
*/

CREATE  PROCEDURE GetAngajatiExpiraPermisMunca AS
/*select AngajatID, Marca, NumeIntreg, (select dbo.FormatData(PermMuncaExpira)) as PermMuncaExpira
from angajatfull 
where activ = 0 and datediff( day, getdate(), PermMuncaExpira ) <= 60*/

select AngajatID, Marca, NumeIntreg, (select dbo.FormatData(PermMuncaDataExpirare)) as PermMuncaDataExpirare
from angajatfull 
where activ = 0 and datediff( day, getdate(), PermMuncaDataExpirare ) <= 60

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO



/*
*	Author: Dima
*	Description: extrage angajatii carora le expira permisul de sedere in mai putin de 60 zile
*	Params: -
*
*	Changes History:
*		- 24.11.04 - Popa Ionel: reimplementarea procedurii
		- 29.01.05 - Vlad Dovlecel
*/

CREATE  PROCEDURE GetAngajatiExpiraPermisSedere
 AS

/*select  AngajatID, Marca, NumeIntreg, (select dbo.FormatData(PermSedereExpira)) as PermSedereExpira
from angajatfull 
where activ = 0 and datediff( day, getdate(), PermSedereExpira ) <= 60*/
select  AngajatID, Marca, NumeIntreg, (select dbo.FormatData(LegitimatieSedereDataExpirare)) as LegitimatieSedereDataExpirare
from angajatfull 
where activ = 0 and datediff( day, getdate(), LegitimatieSedereDataExpirare ) <= 60

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetCartiIdentitateAngajat
(
	@AngajatID bigint
)
AS

select *
from CartiIdentitate
where AngajatID=@AngajatID
order by ValabilPanaLa desc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.GetPersoaneCareAuTrecutLaAltaNorma
(
	@norma1 int,
	@norma2 int
)
AS
	RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.GetPersoaneCareIesDinActivitate AS

	RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.GetPersoaneCareIntraInActivitate
AS
	RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE GetSarbatoriLegale
AS

select * from SarbatoriLegale order by Data




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		Mircea Albutiu, PSE RO BS TH
* Nume:			InsertUpdateCarteIdentitate
* Descriere:	Adauga sa modifica o carte de identitate
*
*	Changes History:
*		- 01.02.05 - Vlad Dovlecel: modificarea procedurii pt noul tip de tabela
*/
CREATE PROCEDURE InsertUpdateCarteIdentitate
(
	/*@AngajatID int,
	@Serie char(2),
	@Numar bigint,
	@EliberatDe nvarchar(50),
	@DataEliberarii datetime,
	@ValabilPanaLa datetime*/
	@tip_actiune int,
	@CarteIdentitateID int,
	@AngajatID int,
	@CNP bigint,
	@Serie char(2),
	@Numar bigint,
	@EliberatDe nvarchar(50),
	@DataEliberarii datetime,
	@ValabilPanaLa datetime,
	@Activ bit = 1
)
as

/*declare @rc int
set @rc = 0

begin tran InsertCarteIdentitate

select @rc = count(AngajatID) from CarneteMunca where AngajatID = @AngajatID

if(@rc = 0)
begin	--Insert carte de identitate
	insert into CartiIdentitate with (xlock) (AngajatID, Serie, Numar, EliberatDe, DataEliberarii, ValabilPanaLa)
		values (@AngajatID, @Serie, @Numar, @EliberatDe, @DataEliberarii, @ValabilPanaLa)
	if(@@ERROR <> 0)
	begin
		rollback tran InsertCarteIdentitate
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertCarteIdentitate
		set @rc = 0
	end
end
else
begin	--Update carte de identitate
	update CartiIdentitate with (xlock) set Serie = @Serie, Numar = @Numar, EliberatDe = @EliberatDe, 
		DataEliberarii = @DataEliberarii, ValabilPanaLa = @ValabilPanaLa
		where AngajatID = @AngajatID
	if(@@ERROR <> 0)
	begin
		rollback tran InsertCarteIdentitate
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertCarteIdentitate
		set @rc = 0
	end	
end

return @rc*/


declare @rc int
set @rc = 0

begin tran InsertCarteIdentitate

--select @rc = count(AngajatID) from CarneteMunca where AngajatID = @AngajatID

if(@tip_actiune = 0)
begin	--Insert carte de identitate
	insert into CartiIdentitate with (xlock) (AngajatID, CNP, Serie, Numar, EliberatDe, DataEliberarii, ValabilPanaLa, Activ)
		values (@AngajatID, @CNP, @Serie, @Numar, @EliberatDe, @DataEliberarii, @ValabilPanaLa, @Activ)
	if(@@ERROR <> 0)
	begin
		rollback tran InsertCarteIdentitate
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertCarteIdentitate
		set @rc = 0
	end
end
else if( @tip_actiune = 1 )
begin	--Update carte de identitate
	update CartiIdentitate with (xlock) set AngajatID = @AngajatID, CNP = @CNP, Serie = @Serie, Numar = @Numar, EliberatDe = @EliberatDe, 
		DataEliberarii = @DataEliberarii, ValabilPanaLa = @ValabilPanaLa, Activ = @Activ
		where CarteIdentitateID = @CarteIdentitateID
	if(@@ERROR <> 0)
	begin
		rollback tran InsertCarteIdentitate
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertCarteIdentitate
		set @rc = 0
	end	
end
else if( @tip_actiune = 2 )
begin	--Delete carte de identitate
	delete from CartiIdentitate where CarteIdentitateID=@CarteIdentitateID

end
else
	rollback tran InsertCarteIdentitate
	
return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		Cristina Raluca Muntean
* Nume:			InsertUpdateDeleteAlerte
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Alerte
*/
CREATE PROCEDURE InsertUpdateDeleteAlerte
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@AlertaID int,
	@AngajatID int,
	@DataExpirare datetime,
	@PerioadaCritica int,
	@Descriere nvarchar(200),
	@Activ bit
)

as

declare @rc int
set @rc = 0

begin tran IUDAlerta

if(@tip_actiune = 0)
begin	--Insert alerta
	insert into Alerte with(xlock) (AngajatID , DataExpirare, PerioadaCritica, Descriere, Activ) 
		values (@AngajatID , @DataExpirare, @PerioadaCritica, @Descriere, @Activ)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDAlerta
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDAlerta
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--UpdateAlerta
	update  Alerte with(xlock) set AngajatID = @AngajatID, DataExpirare = @DataExpirare, PerioadaCritica = @PerioadaCritica,
	Descriere = @Descriere, Activ = @Activ
		where AlertaID = @AlertaID 
	if(@@ERROR <> 0)
	begin
		rollback tran IUDAlerta
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDAlerta
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete Alerta
	delete from Alerte with(xlock) where AlertaID = @AlertaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDAlerta
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDAlerta
		set @rc = 0
	end
end
else
	rollback tran IUDAlerta

return @rc 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		VLad Dovlecel, PSE RO BS TH
* Nume:			InsertUpdateCarteIdentitate
* Descriere:	Adauga, modifica sau sterge o carte de identitate
*/
CREATE PROCEDURE InsertUpdateDeleteCarteIdentitate
(
	@tip_actiune int,
	@CarteIdentitateID int,
	@AngajatID int,
	@CNP bigint,
	@CNPAnterior bigint = null,
	@Serie char(2),
	@Numar bigint,
	@EliberatDe nvarchar(50),
	@DataEliberarii datetime,
	@ValabilPanaLa datetime,
	@Activ bit = 1
)
as


declare @rc int
set @rc = 0

begin tran InsertCarteIdentitate

--select @rc = count(AngajatID) from CarneteMunca where AngajatID = @AngajatID

if(@tip_actiune = 0)
begin	--Insert carte de identitate
	insert into CartiIdentitate with (xlock) (AngajatID, CNP, CNPAnterior, Serie, Numar, EliberatDe, DataEliberarii, ValabilPanaLa, Activ)
		values (@AngajatID, @CNP, @CNPAnterior, @Serie, @Numar, @EliberatDe, @DataEliberarii, @ValabilPanaLa, @Activ)
	if(@@ERROR <> 0)
	begin
		rollback tran InsertCarteIdentitate
		set @rc = @@ERROR
	end
	else
	begin
		set @CarteIdentitateID = @@IDENTITY
		commit tran InsertCarteIdentitate
		set @rc = 0
	end
end
else if( @tip_actiune = 1 )
begin	--Update carte de identitate
	update CartiIdentitate with (xlock) set AngajatID = @AngajatID, CNP = @CNP, CNPAnterior = @CNPAnterior, Serie = @Serie, Numar = @Numar, EliberatDe = @EliberatDe, 
		DataEliberarii = @DataEliberarii, ValabilPanaLa = @ValabilPanaLa, Activ = @Activ
		where CarteIdentitateID = @CarteIdentitateID
	if(@@ERROR <> 0)
	begin
		rollback tran InsertCarteIdentitate
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertCarteIdentitate
		set @rc = 0
	end	
end
else if( @tip_actiune = 2 )
begin	--Delete carte de identitate
	delete from CartiIdentitate where CarteIdentitateID=@CarteIdentitateID
	if(@@ERROR <> 0)
	begin
		rollback tran InsertCarteIdentitate
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertCarteIdentitate
		set @rc = 0
	end	
end
else
	rollback tran InsertCarteIdentitate	

if(@tip_actiune>=0 and @tip_actiune<=2)
	if(@tip_actiune<>2 and @Activ=1)
		update CartiIdentitate with(xlock) set Activ=0 where AngajatID=@AngajatID and CarteIdentitateID<>@CarteIdentitateID
	
return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Denumire:	InsertUpdateDeleteTitluAngajat
* Simbol:	Adauga, modifica, sterge o inregistrare in tabelul TitluriAngajati
*/
CREATE PROCEDURE InsertUpdateDeleteTitluAngajat
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@TitluID int,
	@Denumire nvarchar(100), 
	@Simbol nvarchar(255)
)

as

declare @rc int
set @rc = 0

begin tran IUDTitluAngajat

if(@tip_actiune = 0)
begin	--Insert TitluAngajat
	insert into TitluriAngajati with(xlock) (Denumire, Simbol) 
		values (@Denumire, @Simbol)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTitluAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTitluAngajat
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update TitluAngajat
	update TitluriAngajati with(xlock) set Denumire = @Denumire, Simbol = @Simbol
		where TitluID=@TitluID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTitluAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTitluAngajat
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete TitluAngajat
	delete from TitluriAngajati with(xlock) where TitluID = @TitluID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTitluAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTitluAngajat
		set @rc = 0
	end
end
else
	rollback tran IUDTitluAngajat

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.IsDaySarbatoare
(@data datetime)
/*
	(
		@parameter1 datatype = default value,
		@parameter2 datatype OUTPUT
	)
*/
AS
declare @x int
set @x=0
SELECT @x=COUNT (*)
FROM SarbatoriLegale
WHERE Data=@data; 


RETURN @x


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Dovlecel Vlad
* Nume:			SetActivAllCartiIdentitateID
* Descriere:	seteaza campul activ din tabelul CartiIdentitate pt toate inregistrarile unui angajat
*/

CREATE PROCEDURE SetActivAllCartiIdentitateAngajat
(
	@AngajatID int,
	@Activ bit = 0
)

as

declare @rc int
set @rc = 0

begin tran IUDCartiIdentitate

update CartiIdentitate with(xlock) 
set Activ=@Activ
where AngajatID=@AngajatID

if(@@ERROR <> 0)
begin
	rollback tran IUDCartiIdentitate
	set @rc = @@ERROR
end
else
begin
	commit tran IUDCartiIdentitate
	set @rc = 0
end

if( @rc <> 0 )
	rollback tran IUDCartiIdentitate

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.StoredProcedure1
/*
	(
		@parameter1 datatype = default value,
		@parameter2 datatype OUTPUT
	)
*/
AS
	/* SET NOCOUNT ON */
	RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		Mircea Albutiu, PSE RO BS TH
* Nume:			describe
* Descriere:	Intoarce caracteristicile unu tabel
*/
CREATE PROCEDURE describe
@sir_in varchar(4000)--, @like_in varchar(4000) 
AS
select syscolumns.name coloana, systypes.name data, syscolumns.length lungime, syscolumns.isnullable nul
from systypes, sysobjects, syscolumns 
where	
	syscolumns.id = sysobjects.id and 
	systypes.xtype=syscolumns.xtype and 
	systypes.name <> 'sysname' and
--	syscolumns.name like '%' + @like_in + '%' and 
	sysobjects.name = @sir_in
order by syscolumns.colorder
--order by syscolumns.name
return

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.sal_GetSituatieLunaraAngajat

(
@AngajatID int,
@LunaID int
)
	
AS

	SELECT  * from sal_SituatieLunaraAngajati
	where AngajatID = @AngajatID and LunaID=@LunaID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.sal_GetSituatieLunaraAngajatByID

(
@SituatieID int
)
	
AS

	SELECT  * from sal_SituatieLunaraAngajati
	where SituatieID=@SituatieID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE sal_InsertLuniInfl

	(
 		@Data datetime, 
		@Activ bit,
		@ProcentInflatie float(8),
		@SetID int OUTPUT	
	)

AS
	INSERT INTO Luni (Data, Activ, ProcentInflatie)
	VALUES     (@Data, @Activ, @ProcentInflatie)
    SET @SetID = @@IDENTITY

	IF @@ERROR > 0
		BEGIN
		RAISERROR ('Insert Impozite lunare', 16, 1)
		RETURN 99
		END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Autor:Muntean Raluca Cristina
--Descriere: insereaza in tabela Sal_Salarii, pe luna @LunaID, prima trimisa ca parametru pentru angajatul cu id-ul @angajatID 
CREATE PROCEDURE dbo.sal_UpdatePrimaSpeciala
(
		@LunaID INT,
		@AngajatID INT,
		@PrimeSpeciale MONEY
)
AS
	
	BEGIN TRANSACTION UpdatePrimaSpeciala

	UPDATE Sal_SituatieLunaraAngajati  WITH(xlock) SET 
	PrimeSpeciale=@PrimeSpeciale
	WHERE  LunaID = @LunaID AND AngajatID=@AngajatID 
	IF(@@ERROR <> 0)
		ROLLBACK TRANSACTION UpdatePrimaSpeciala
	ELSE
		COMMIT TRANSACTION UpdatePrimaSpeciala

RETURN 0


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
  Autor: Cristina Muntean
  Data: 21.02.2005
  Nume: spBazaCalcAsigDeSanatateAngajat
  Descriere: baza de calcul a contributiei individuale de asigurari de sanatate
  Date intrare: venituri brute, date personal
  Date iesire: baza de calcul a contributiei individuale de asigurari de sanatate
  Formula de calcul:
  bazaDeCalculAContributieideAsigurariDeSanatate = venitBrut - indemnizatieConcediuMedical
*/
CREATE PROCEDURE spCalculBazaCalcAsigDeSanatateAngajat
(
	--parametrii de intrare
	@AngajatID int, --id-ul angajatului
	@LunaID int, --id-ul lunii
	@IndemnizatieConcediuMedical money, --indemnizatie concediu medical 
	@VenitBrut money, --venitul brut al angajatului
	
	--parametrul de iesire
	@BCContribIndivDeAsigDeSanatate money OUTPUT --baza de calcul a contributiei individuale de asigurari de sanatate
)
AS
	--este calculata baza de calcul a contributiei individuale de asigurari de sanatate dupa formula:
	--bazaDeCalculAContributieideAsigurariDeSanatate = venitBrut - indemnizatieConcediuMedical
	SET @BCContribIndivDeAsigDeSanatate = @VenitBrut - @IndemnizatieConcediuMedical
	
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:             Cristina Muntean
	Data:              7.03.2005
	Nume:              spCalculBazaCalcAsigSocialeUnitate
	Parametrii:
					   --parametrii de intrare
					   @cuas money, --
					   @BCcasAngajatorPlafonata money, --baza de calcul al CAS angajator plafonata 
	
					   --parametru de iesire
					   @BCAsigSocialeUnitate money OUTPUT --baza de calcul a contributiei unitatii la asigurarile sociale
	Descriere:         calculeaza baza de calcul a contributiei unitatii la asiguraile sociale
	Formula de calcul: BazaCalculAsigurariSocialeUnitate = min (cuas;BazaCalculCASAngajatorPlafonata )
*/
CREATE PROCEDURE spCalculBazaCalcAsigSocialeUnitate
(
	--parametrii de intrare
	@cuas money, --
	@BCcasAngajatorPlafonata money, --baza de calcul al CAS angajator plafonata 
	
	--parametru de iesire
	@BCAsigSocialeUnitate money OUTPUT --baza de calcul a contributiei unitatii la asigurarile sociale
)
AS
	-- este calculata baza de calcul a contributiei unitatii la asiguraile sociale
	--Formula de calcul: BazaCalculAsigurariSocialeUnitate = min (cuas;BazaCalculCASAngajatorPlafonata )
	if(@cuas < @BCcasAngajatorPlafonata)
		SET @BCAsigSocialeUnitate = @cuas
	else
		SET @BCAsigSocialeUnitate = @BCcasAngajatorPlafonata
		
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor: Cristina Muntean
	Data: 7.12.3004
	Nume: spCalculContributieAsigSocialeUnitate
	Parametrii:
			--parametrii de intrare
			@LunaID int, --id-ul lunii
			@BCAsigSocialeAngajator money, --baza de calcul al contributiei unitatii la asiguraile sociale
	
			--parametru de iesire
			@ContributieAsigSocialeAngajator money OUTPUT --contributia la CAS a angajatorului
	Descriere:calculeaza contributia la CAS a angajatorului
	Formula de calcul:ContributieAsigurariSocialeAngajator = ProcentAsigurariSocialeAngajator*BazaCalculContributieAsigurariSocialeAngajator
*/
CREATE PROCEDURE spCalculContributieAsigSocialeUnitate
(
	--parametrii de intrare
	@LunaID int, --id-ul lunii
	@BCAsigSocialeAngajator money, --baza de calcul a contributiei 
	
	--parametru de iesire
	@ContributieAsigSocialeAngajator money OUTPUT --contributia la asigurari sociale a angajatorului
)

AS
	DECLARE  @ProcentAsigSocialeAngajator money --procentul de asigurari sociale pentru angajator
	
	--setare procentul de asigurari sociale al angajatorului
	SET @ProcentAsigSocialeAngajator = (SELECT (Valoare/100) AS Procent
								  FROM sal_VariabileGlobaleTipuri INNER JOIN sal_VariabiileGlobaleValori
								  ON sal_VariabileGlobaleTipuri.VariabilaGlobalaID = sal_VariabileGlobaleValori.VariabilaGlobalaID 
								  WHERE sal_VariabileGlobaleValori.LunaID=@LunaID AND sal_VariabileGlobaleTipuri.Cod='PBCCUAS')
	
	--calculeaza contributia la CAS a angajatorului
	--Formula de calcul:ContributieAsigurariSocialeAngajator = ProcentAsigurariSocialeAngajator*BazaCalculContributieAsigurariSocialeAngajator
	SET @ContributieAsigSocialeAngajator = @BCAsigSocialeAngajator * @ProcentAsigSocialeAngajator

	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor: Cristina Muntean
	Data: 7.12.3004
	Nume: spCalculContributieFondSolidaritateUnitate
	Parametrii:
			--parametrii de intrare
			@LunaID int, --id-ul lunii
			@BCFondSolidaritateAngajator money, --baza de calcul al contributiei unitatii la fondul de solidaritate cu persoanele cu dizabilitati
	
			--parametru de iesire
			@ContributieFondSolidaritateAngajator money OUTPUT --contributia unitatii la fondul de solidaritate cu persoanele cu dizabilitati
	Descriere:calculeaza contributia unitatii la fondul de solidaritate cu persoanele cu dizabilitati
	Formula de calcul:ContributieFondSolidaritateAngajator = ProcentFondSolidaritateAngajator*BazaCalculContributieFondSolidaritateAngajator
*/
CREATE PROCEDURE spCalculContributieFondSolidaritateUnitate
(
	--parametrii de intrare
	@LunaID int, --id-ul lunii
	@BCFondSolidaritateAngajator money, --baza de calcul al contributiei unitatii la fondul de solidaritate cu persoanele cu dizabilitati
	
	--parametru de iesire
	@ContributieFondSolidaritateAngajator money OUTPUT --contributia unitatii la fondul de solidaritate cu persoanele cu dizabilitati
)

AS
	--procentul de fond de solidaritate angajator
	DECLARE  @ProcentFondSolidaritateAngajator money 
	
	--setare procent de fond de solidaritate angajatorului
	SET @ProcentFondSolidaritateAngajator = (SELECT (Valoare/100) AS Procent
								  FROM sal_VariabileGlobaleTipuri INNER JOIN sal_VariabiileGlobaleValori
								  ON sal_VariabileGlobaleTipuri.VariabilaGlobalaID = sal_VariabileGlobaleValori.VariabilaGlobalaID 
								  WHERE sal_VariabileGlobaleValori.LunaID=@LunaID AND sal_VariabileGlobaleTipuri.Cod='PBCUSOL')
	
	--calculeaza contributia unitatii la fondul de solidaritate cu persoanele cu dizabilitati
	--Formula de calcul:ContributieFondSolidaritateAngajator = ProcentFondSolidaritateAngajator*BazaCalculContributieFondSolidaritateAngajator
	SET @ContributieFondSolidaritateAngajator = @BCFondSolidaritateAngajator * @ProcentFondSolidaritateAngajator

	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor: Cristina Muntean
	Data: 7.12.3004
	Nume: spCalculContributieSanatateConcediiBoalaUnitate
	Parametrii:
			--parametrii de intrare
			@LunaID int, --id-ul lunii
			@BCSanatateDinCASAngajator money, --baza de calcul al contributiei angajatorului la fondul de sanatate aferent concediilor medicale de orice tip
	
			--parametru de iesire
			@ContributieSanatateCBAngajator money OUTPUT --contributia de sanatate a angajatorului aferenta concediilor de boala
	Descriere:calculeaza contributia de sanatate aferenta concediilor de boala
	Formula de calcul:ContributieSanatateCBAngajator = ProcentSanatateCBAngajator*BazaCalculContributieSanatateDinCASAngajator
*/
CREATE PROCEDURE spCalculContributieSanatateConcediiBoalaUnitate
(
	--parametrii de intrare
	@LunaID int, --id-ul lunii
	@BCSanatateDinCASAngajator money, --baza de calcul a contributiei de sanatate a angajatorului
	
	--parametru de iesire
	@ContributieSanatateCBAngajator money OUTPUT --contributia de sanatate aferenta concediilor de boala a angajatorului
)

AS
	--procentul de sanatate aferenta concediilor de boala pentru angajator
	DECLARE  @ProcentSanatateCBAngajator money 
	
	--setare procent de sanatate aferent concediilor de boala al angajatorului
	SET @ProcentSanatateCBAngajator = (SELECT (Valoare/100) AS Procent
								  FROM sal_VariabileGlobaleTipuri INNER JOIN sal_VariabiileGlobaleValori
								  ON sal_VariabileGlobaleTipuri.VariabilaGlobalaID = sal_VariabileGlobaleValori.VariabilaGlobalaID 
								  WHERE sal_VariabileGlobaleValori.LunaID=@LunaID AND sal_VariabileGlobaleTipuri.Cod='PBCSANDINCAS')
	
	--calculeaza contributia de sanatate aferenta concediilor de boala
	--Formula de calcul:ContributieSanatateCBAngajator = ProcentSanatateCBAngajator*BazaCalculContributieSanatateDinCASAngajator
	SET @ContributieSanatateCBAngajator = @BCSanatateDinCASAngajator * @ProcentSanatateCBAngajator

	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor: Cristina Muntean
	Data: 7.12.3004
	Nume: spCalculContributieSanatateUnitate
	Parametrii:
			--parametrii de intrare
			@LunaID int, --id-ul lunii
			@BCSanatateAngajator money, --baza de calcul al contributiei unitatii la sanatate
	
			--parametru de iesire
			@ContributieSanatateAngajator money OUTPUT --contributia de sanatate a angajatorului
	Descriere:calculeaza contributia de sanatate a angajatorului
	Formula de calcul:ContributieSanatateAngajator = ProcentSanatateAngajator*BazaCalculContributieSanatateAngajator
*/
CREATE PROCEDURE spCalculContributieSanatateUnitate
(
	--parametrii de intrare
	@LunaID int, --id-ul lunii
	@BCSanatateAngajator money, --baza de calcul a contributiei de sanatate a angajatorului
	
	--parametru de iesire
	@ContributieSanatateAngajator money OUTPUT --contributia de sanatate a angajatorului
)

AS
	DECLARE  @ProcentSanatateAngajator money --procentul de sanatate pentru angajator
	
	--setare procent de sanatate al angajatorului
	SET @ProcentSanatateAngajator = (SELECT (Valoare/100) AS Procent
								  FROM sal_VariabileGlobaleTipuri INNER JOIN sal_VariabiileGlobaleValori
								  ON sal_VariabileGlobaleTipuri.VariabilaGlobalaID = sal_VariabileGlobaleValori.VariabilaGlobalaID 
								  WHERE sal_VariabileGlobaleValori.LunaID=@LunaID AND sal_VariabileGlobaleTipuri.Cod='PBCUSAN')
	
	--calculeaza contributia de sanatate a angajatorului
	--Formula de calcul:ContributieAsigurariSocialeAngajator = ProcentAsigurariSocialeAngajator*BazaCalculContributieAsigurariSocialeAngajator
	SET @ContributieSanatateAngajator = @BCSanatateAngajator * @ProcentSanatateAngajator

	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor: Cristina Muntean
	Data: 7.12.3004
	Nume: spCalculContributieSomajUnitate
	Parametrii:
			--parametrii de intrare
			@LunaID int, --id-ul lunii
			@BCSomajAngajator money, --baza de calcul a contributiei 
	
			--parametru de iesire
			@ContributieSomajAngajator money OUTPUT --contributia de somaj a angajatorului
	Descriere:calculeaza contributia de somaj a angajatorului
	Formula de calcul:ContributieSomajAngajator = ProcentSomajAngajator*BazaCalculContributieSomajAngajator
*/
CREATE PROCEDURE spCalculContributieSomajUnitate
(
	--parametrii de intrare
	@LunaID int, --id-ul lunii
	@BCSomajAngajator money, --baza de calcul a contributiei 
	
	--parametru de iesire
	@ContributieSomajAngajator money OUTPUT --contributia de somaj a angajatorului
)

AS
	DECLARE  @ProcentSomajAngajator money --procentul de somaj pentru angajator
	
	--setare procentul de somaj al angajatorului
	SET @ProcentSomajAngajator = (SELECT (Valoare/100) AS Procent
								  FROM sal_VariabileGlobaleTipuri INNER JOIN sal_VariabiileGlobaleValori
								  ON sal_VariabileGlobaleTipuri.VariabilaGlobalaID = sal_VariabileGlobaleValori.VariabilaGlobalaID 
								  WHERE sal_VariabileGlobaleValori.LunaID=@LunaID AND sal_VariabileGlobaleTipuri.Cod='PBCUSOM')
	
	--calculeaza contributia de somaj a angajatorului
	--Formula de calcul:ContributieSomajAngajator = ProcentSomajAngajator*BazaCalculContributieSomajAngajator
	SET @ContributieSomajAngajator = @BCSomajAngajator * @ProcentSomajAngajator

	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Author: 		Ionel Popa
	Description: 	Calculeaza restul de plata ... rp
					rp = SalariuNet - Retineri
	Params:			@LunaID in ... id-ul lunii active
					@AngajatID in ... id-ul angajatului pentru care se calculeaza baza de calcul
					@SalariuNet in ... salariul net al angajatului
					@Retineri in ... retinerile angajatului
					@RestPlata out ... restul de plata pentru angajat
*/
CREATE PROCEDURE spCalculRestPlata
(
	@LunaID int,
	@AngajatID int,
	@SalariulNet money,
	@Retineri money,
	@RestPlata money OUTPUT
)
AS

--este calculat restul de plata ca diferenta intre salariul net si retineri, 
--MODIFIED: Cristina Muntean ... retinerile sunt primite ca parametru si nu calculate in interiorul procedurii stocate
set @RestPlata = @SalariulNet - @Retineri

RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Author: 		Ionel Popa
	Description: 	Calculeaza salariul net ... sn
					sn = VenitNet - Impozit
	Params:			@LunaID in ... id-ul lunii active
					@AngajatID in ... id-ul angajatului pentru care se calculeaza baza de calcul
					@VenitNet in ... venitul net al angajatului
					@Impozit in ... impozitul platit de angajat
					@SalariulNet OUTPUT ... salariul net al angajatului
*/
CREATE PROCEDURE spCalculSalariuNet
(
	@LunaId int,
	@AngajatID int,
	@VenitNet money,
	@Impozit money,
	@SalariulNet money OUTPUT
)
AS

set @SalariulNet = @VenitNet - @Impozit
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Author: 		Ionel Popa
	Description: 	Calculeaza venitul impozabil ... vi
					vi = ROUNDDOWN((VenitNet - @DeduceriPersonale),3)
	Params:			@LunaID in ... id-ul lunii active
					@AngajatID in ... id-ul angajatului pentru care se calculeaza baza de calcul
					@VenitNet in ... venitul net al angajatului
					@DeduceriPersonale in ... deducerile personale ale angajatului
					@VenitImpozabil out ... venitul impozabil pentru angajatul respectiv
*/
CREATE PROCEDURE spCalculVenitImpozabil
(
	@LunaID int,
	@AngajatID int,
	@VenitNet  money,
	@DeduceriPersonale money,
	@VenitImpozabil money OUTPUT
)
AS

if @VenitNet - @DeduceriPersonale > 0
begin
	set @VenitImpozabil = [SiemensHR_Test].[dbo].[RoundDownSumOfMoney] ( @VenitNet - @DeduceriPersonale, 3)
end
else
begin
	set @VenitImpozabil = 0
end

RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Author: 		Ionel Popa
	Description: 	Calculeaza venitul net al unul angajat ... vn
					vn = VenitBrut - ContributieIndivSomaj - ContributieIndivAsigSanatate - COntributieIndivAsigSociale
	Params:			@LunaID in ... id-ul lunii active
					@AngajatID in ... id-ul angajatului pentru care se calculeaza baza de calcul
					@VenitBrut in ... venitul brut
					@ContributieIndivSomaj in ... contributia individuala la fondul de somaj
					@ContributieIndivAsigSanatate in ... contributia individuala la asigurarile de sanatate
					@ContributieIndivAsigSociale in ... contributia individuala la asigurarile sociale
					@VenitNet OUTPUT ... venitul net
*/
CREATE PROCEDURE spCalculVenitNet
(
	@LunaID int,
	@AngajatID int,
	@VenitBrut money,
	@ContributieIndivSomaj money,
	@ContributieIndivAsigSanatate money,
	@ContributieIndivAsigSociale money,
	@VenitNet money OUTPUT
)
AS

set @VenitNet = @VenitBrut - @ContributieIndivSomaj - @ContributieIndivAsigSanatate - @ContributieIndivAsigSociale
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:      Cristina Muntean
	Data:       16.03.2004
	Nume:       spDeleteStatDePlata
	Parametrii: --parametru de intrare
				@ID int
	Descriere:  sterge o inregistrare din tabela sal_StatDePlata 
*/
CREATE PROCEDURE spDeleteStatDePlata
(
		--parametru de intrare
		@ID int
)

AS
	declare @rc int
	set @rc = 0


	--delete sal_StatDePlata
	begin tran DStatDePlata
		delete from sal_StatDePlata with(xlock) 
		where ID=@ID
						
		if(@@ERROR <> 0)
		begin
			rollback tran DStatDePlata
			set @rc = @@ERROR
		end
		else
		begin
			commit tran DStatDePlata
			set @rc = 0
		end

	RETURN @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_EsteZiSarbatoare
(
	@Data datetime
)

 AS

select * 

from SarbatoriLegale

where Data=@Data

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.tm_GetOreLuna
(
@AngajatID int,
@TipIntervalID int,
@Luna int,
@An int
)

AS

declare @total float

set @total = (select SUM(dbo.tm_OreInterval(tm_IntervaleAngajat.OraStart,tm_IntervaleAngajat.OraEnd)) from tm_IntervaleAngajat
inner join tm_Zile on tm_IntervaleAngajat.Data = tm_Zile.Data 
--where dbo.tm_ApartinePerioada(tm_Zile.Data,@An,@Luna) =1 and tm_IntervaleAngajat.AngajatID=@AngajatID and tm_IntervaleAngajat.CapatInterval=0 )
where dbo.tm_ApartinePerioada(tm_Zile.Data,@An,@Luna) =1 and tm_IntervaleAngajat.AngajatID=@AngajatID and tm_IntervaleAngajat.CapatInterval=0 and Deleted=0 )

if @total=null select 0 else select @total

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.tm_GetOreLunaTipInterval  
(
@AngajatID int,
@TipIntervalID int,
@Luna int,
@An int
)

AS

declare @total float

set @total = 
(select SUM(dbo.tm_OreInterval(tm_IntervaleAngajat.OraStart,tm_IntervaleAngajat.OraEnd)) from tm_IntervaleAngajat
inner join tm_Zile on tm_IntervaleAngajat.Data = tm_Zile.Data 
--where dbo.tm_ApartinePerioada(tm_Zile.Data,@An,@Luna) =1 and tm_IntervaleAngajat.AngajatID=@AngajatID and tm_IntervaleAngajat.TipIntervalID = @TipIntervalID and tm_IntervaleAngajat.CapatInterval=0 )
where dbo.tm_ApartinePerioada(tm_Zile.Data,@An,@Luna) =1 and tm_IntervaleAngajat.AngajatID=@AngajatID and tm_IntervaleAngajat.TipIntervalID = @TipIntervalID and tm_IntervaleAngajat.CapatInterval=0 and Deleted=0 )

if @total = null select 0 else select @total

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.tm_GetOreZi
(
@AngajatID int,
@Data Datetime
)

AS

declare @total float

set @total = (select SUM(dbo.tm_OreInterval(tm_IntervaleAngajat.OraStart,tm_IntervaleAngajat.OraEnd)) from tm_IntervaleAngajat
inner join tm_Zile on tm_IntervaleAngajat.Data = tm_Zile.Data 
--where tm_Zile.Data=@Data  and tm_IntervaleAngajat.AngajatID=@AngajatID and tm_IntervaleAngajat.CapatInterval=0)
where tm_Zile.Data=@Data  and tm_IntervaleAngajat.AngajatID=@AngajatID and tm_IntervaleAngajat.CapatInterval=0 and Deleted=0)

if @total is null select 0 else select @total

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.tm_GetOreZiTipInterval  
(
@AngajatID int,
@TipIntervalID int,
@Data Datetime
)

AS

declare @total float

set @total = (select SUM(dbo.tm_OreInterval(tm_IntervaleAngajat.OraStart,tm_IntervaleAngajat.OraEnd)) from tm_IntervaleAngajat
inner join tm_Zile on tm_IntervaleAngajat.Data = tm_Zile.Data 
--where tm_Zile.Data=@Data  and tm_IntervaleAngajat.AngajatID=@AngajatID and tm_IntervaleAngajat.TipIntervalID = @TipIntervalID and tm_IntervaleAngajat.CapatInterval=0)
where tm_Zile.Data=@Data  and tm_IntervaleAngajat.AngajatID=@AngajatID and tm_IntervaleAngajat.TipIntervalID = @TipIntervalID and tm_IntervaleAngajat.CapatInterval=0 and Deleted=0)

if @total = null select 0 else select @total

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


--intoarce  orice tip de absenta

CREATE PROCEDURE dbo.tm_GetZileLunaAbsenta
(
@AngajatID int,
@Luna int,
@An int
)

AS


select 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



-- intoarce doar absente de un anumit tip

CREATE PROCEDURE dbo.tm_GetZileLunaTipAbsenta
(
@AngajatID int,
@TipAbsentaID int,
@Luna int,
@An int
)

AS

select 0


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Mircea Albutiu, PSE RO BS TH
* Nume:			CautareAngajat
* Descriere:	Cauta un gangajat in baza de date
*/
/*
* Modificare 20.01.2005
*Author:		 Vlad Dovlecel
*Descriere:	Adaugare campuri pt cautare avansata
*/
/*
* Modificare 14.02.2005
*Author:		 Ionel Popal
*Descriere:	Adaugare departament denumire
*/

CREATE PROCEDURE tmp_CautareAngajat
(
	@in_TipCautare nvarchar(50) = 'cautare rapida',

	@in_Nume nvarchar(50) = -1,
	@in_Prenume nvarchar(50) = -1,

	--@in_Nationalitate nvarchar(50) = -1,
	@in_Nationalitate int = -1,
	@in_TaraOrigineID int = -1,--tara de origine
	@in_StareCivila int = -1,
	@in_Copii int = -1,--copii
	@in_Sex nvarchar(2) = -1,
	@in_TitluID int = -1,
	@in_StudiuID int = -1,
	@in_Marca nvarchar(8) = -1,
	@in_DepartamentID int = -1,
	@in_CentruCostID int = -1,--centru de cost
	@in_FunctieID int = -1,--functie
	@in_ModIncadrare int = -1,
	@in_IndemnizatieConducere int = -1,--indemnizatie de conducere

	--Categorie angajat
	@in_ScutitImpozit int = -1,--Scutit impozit
	@in_CategorieID int = -1,--Categorie

	--deducere
	@in_Deducere int = -1,--deducere
	@in_DeducereCopii int = -1,--deducere copii

	--conturi bancare
	@in_ContBancarExistenta int = -1,--existenta conturi bancare
	@in_BancaID int = -1,--banca

	--data angajarii
	@in_TipDataAngajare int = -1,--tipul de data dupa care se face cautarea
	@in_DataFixa datetime = null,--data specifica cautarii dupa o data fixa
	@in_LunaData int = -1,--luna dupa care se face cautarea pt contractele dintr-o anumita luna
	@in_AnData int = -1,--anul dupa care se face cautarea pt contractele dintr-o anumita luna
	@in_IntervalDataStart datetime = null,--pt cautare dupa data de start a contractelor dintr-un interval
	@in_IntervalDataEnd datetime = null,--pt cautare dupa data de start a contractelor dintr-un interval
	@in_DataMinValue datetime,--data minima care o trimite . net-ul

	@in_PerioadaDeterminata int = -1--contract pe perioada determinata
)
as

/*create table #date_cautare (AngajatID int, Marca nvarchar(8), Nume nvarchar(50), Prenume nvarchar(50), TitluID int, 
							StudiuID int, ModIncadrare bit, StareCivila tinyint, Nationalitate nvarchar(50), 
							Sex nvarchar(2), Telefon nvarchar(25), DepartamentID int, DepartamentCod nvarchar(10), 
							FunctieNume nvarchar(25))
								
insert into #date_cautare select AngajatID, Marca, Nume, Prenume, TitluID, StudiuID, ModIncadrare, StareCivila, 
							Nationalitate, Sex, Telefon, DepartamentID, DepartamentCod, FunctieNume 
							from AngajatFull*/


create table #date_cautare (AngajatID int, Nume nvarchar(50), Prenume nvarchar(50), Nationalitate int, TaraNastereID int, StareCivila tinyint, NrCopii int, Sex nvarchar(2),
							TitluID int, StudiuID int, Marca nvarchar(8), DepartamentID int, DepartamentCod nvarchar(10), DepartamentDenumire nvarchar(255), CentruCostID int,
							FunctieID int, FunctieNume nvarchar(50), ModIncadrare bit, IndemnizatieConducere money, CategorieID int,
							Deducere bit, DataDeLa datetime, PerioadaDeterminata bit,
							Telefon nvarchar(25), 
							)
								
insert into #date_cautare select AngajatID, Nume, Prenume, Nationalitate, TaraNastereID, StareCivila, NrCopii, Sex, TitluID, StudiuID, Marca, DepartamentID, DepartamentCod, isnull(DepartamentDenumire, ''), CentruCostID,
							FunctieID, FunctieNume, ModIncadrare, IndemnizatieConducereActual, CategorieID, SolicitaDeduceri, DataDeLa, PerioadaDeterminata,
							Telefon 
							from AngajatFull


if(@in_Nume <> '-1')
	delete from #date_cautare where Nume not like '%' + @in_Nume + '%'

if(@in_Prenume <> '-1')
	delete from #date_cautare where Prenume not like '%' + @in_Prenume + '%'

if( @in_TipCautare = "cautare avansata" )
begin	

	/*if(@in_Nationalitate <> '-1')
		delete from #date_cautare where Nationalitate not like '%' + @in_Nationalitate + '%'*/
	if(@in_Nationalitate <> -1)
		delete from #date_cautare where Nationalitate<>@in_Nationalitate
	
	-- tara de origine
	if( @in_TaraOrigineID <> -1 )
		delete from #date_cautare where TaraNastereID <> @in_TaraOrigineID
	
	if(@in_StareCivila <> -1)
		delete from #date_cautare where StareCivila <> @in_StareCivila
	
	--copii
	if( @in_Copii = 0 )
		delete from #date_cautare where NrCopii > 0
	else if( @in_Copii = 1 )
		delete from #date_cautare where NrCopii = 0
	
	if(@in_Sex <> '-1')
		delete from #date_cautare where Sex not like '%' + @in_Sex + '%'
	
	if(@in_TitluID <> -1)
		delete from #date_cautare where TitluID <> @in_TitluID
	
	if(@in_StudiuID <> -1)
		delete from #date_cautare where StudiuID <> @in_StudiuID
	
	if(@in_Marca <> '-1')
		delete from #date_cautare where Marca not like '%' + @in_Marca + '%'
	
	if(@in_DepartamentID <> -1)
		delete from #date_cautare where DepartamentID <> @in_DepartamentID or DepartamentID is null 
	
	-- centru de cost*
	if( @in_CentruCostID <> -1 )
		delete from #date_cautare where CentruCostID <> @in_CentruCostID or CentruCostID is null
	
	--functie
	if( @in_FunctieID <> -1 )
		delete from #date_cautare where FunctieID <> @in_FunctieID
	
	if(@in_ModIncadrare <> -1)
		delete from #date_cautare where ModIncadrare <> @in_ModIncadrare
	
	--indemnizatie de conducere
	if( @in_IndemnizatieConducere = 0 )
		delete from #date_cautare where IndemnizatieConducere > 0 and IndemnizatieConducere != null
	else if( @in_IndemnizatieConducere = 1 )
		delete from #date_cautare where IndemnizatieConducere = 0 or IndemnizatieConducere = null
	
	
	--Categorie angajat
	if( @in_CategorieID <> -1 )
		delete from #date_cautare where CategorieID <> @in_CategorieID
	else if( @in_ScutitImpozit <> -1 ) begin
		if( @in_ScutitImpozit = 0 )
			delete from #date_cautare where CategorieID in (Select CategorieID from Salarii_CategoriiAngajati where ScutireImpozit=1)
		if( @in_ScutitImpozit = 1 )
			delete from #date_cautare where CategorieID in (Select CategorieID from Salarii_CategoriiAngajati where ScutireImpozit=0)
	end
	
	--deducere
	if( @in_Deducere = 0 )
		delete from #date_cautare where Deducere = 1
	else if( @in_Deducere = 1 )
		if( @in_DeducereCopii = 0 )
			delete from #date_cautare where( Deducere = 0 or Deducere = null )or( Deducere = 1 and NrCopii > 0 )
		else if( @in_DeducereCopii = 1 )
			delete from #date_cautare where( Deducere = 0 or Deducere = null )or( Deducere = 1 and NrCopii = 0 )
		else
			delete from #date_cautare where Deducere = 0 or Deducere = null
	
	--conturi bancare*
	if( @in_ContBancarExistenta = 0 )
		delete from #date_cautare where AngajatID in (select AngajatID from ConturiAngajati Group By AngajatID)
	else if( @in_ContBancarExistenta = 1 )
	begin
		delete from #date_cautare where AngajatID not in (select AngajatID from ConturiAngajati Group By AngajatID)
		if( @in_BancaID <> -1 )
			delete from #date_cautare where AngajatID not in (select AngajatID from ConturiAngajati where BancaID = @in_BancaID Group By AngajatID)
		--else
			--delete from #date_cautare where AngajatID not in (select AngajatID from ConturiAngajati Group By AngajatID)
	end
	
	
	--data angajarii
	--contracte dintr-o data fixa
	if( @in_TipDataAngajare = 0 )
		if( @in_DataFixa <> @in_DataMinValue )
			delete from #date_cautare where DataDeLa <> @in_DataFixa
	--contracte dintr-o anumita luna
	else if( @in_TipDataAngajare = 1 )
		if( @in_LunaData <> @in_DataMinValue and @in_AnData <> @in_DataMinValue )
			delete from #date_cautare where DatePart( mm, DataDeLa ) <> @in_LunaData or DatePart( yy, DataDeLa ) <> @in_AnData
	--contracte dintr-un interval
	else if( @in_TipDataAngajare = 2 )
		if( @in_IntervalDataStart <> @in_DataMinValue and @in_IntervalDataEnd <> @in_DataMinValue )
			delete from #date_cautare where DataDeLa < @in_IntervalDataStart or @in_IntervalDataEnd < DataDeLa
	
	--perioada determinata
	if( @in_PerioadaDeterminata = 0 )
		delete from #date_cautare where PerioadaDeterminata = 1
	else if( @in_PerioadaDeterminata = 1 )
		delete from #date_cautare where PerioadaDeterminata = 0 or PerioadaDeterminata = null
	
end

select AngajatID, Marca, Nume, Prenume, Telefon, DepartamentCod, DepartamentDenumire, FunctieNume from #date_cautare order by Nume

drop table #date_cautare 

return 0
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:Cristina Muntean
	Nume: CheckIfDomDeActCanBeDeleted
	Descriere: Numara de cate ori apare id-ul domeniului de activitate trimis ca parametru in tabela DomDeActivitateAngajator,
	daca apare cel putin o data inseamna ca domeniul este asociat cel putin unui angajator, deci nu poate fi sters, in
	caz contrar, daca apare de 0 ori, domeniul poate fi sters
*/
CREATE PROCEDURE CheckIfDomDeActCanBeDeleted
(
	@DomDeActivitateID int --id-ul domeniului de activitate
)
AS
	--numara de cate ori apare id-ul domeniului de activitate trimis ca parametru in tabela DomDeActivitateAngajator
	--este returnat numarul de aparitii ale domeniului
	select count(DomDeActivitateID) as norec 
	from DomDeActivitateAngajator 
	where DomDeActivitateID=@DomDeActivitateID
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor: Cristina Muntean
	Nume: CheckIfToateFunctiileAuCodSiemens
	Descriere: Returneaza numarul fuctiilor care nu au cod Siemens.
*/
CREATE PROCEDURE CheckIfToateFunctiileAuCodSiemens

AS

select count(CodSiemens) as norec from Functii where CodSiemens=''
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE CheckInsertConcediiMedic
(
@ValMin int,
@ValMax int

)
/*
	(
		@parameter1 datatype = default value,
		@parameter2 datatype OUTPUT
	)
*/
AS
declare @x int
select @x=count(*) from ConcediuMedicZilePlatite where (@ValMin>=ValMinimAngajati and @ValMax<=ValMaximAngajati)or (@ValMax>=ValMinimAngajati and @ValMax<=ValMaximAngajati)or (@ValMin>=ValMinimAngajati and @ValMin<=ValMaximAngajati)
	RETURN @x


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE Procedure dbo.CoeficientDeduceri
(
@inParam decimal(18,2),
@RetVal  decimal(18,2) output
)  as

	set @RetVal=0
             
	if (@inParam=1)
		set @RetVal =(SELECT TOP 1 CoefInvalidGrd1 FROM Coeficienti order by DeLa DESC)
	else 
	 if (@inParam=2)
		set @RetVal =(SELECT TOP 1 CoefInvalidGrd2 FROM Coeficienti order by DeLa DESC)
	else
	if  (@inParam=3)
		set @RetVal =(SELECT TOP 1 CoefSot FROM Coeficienti order by DeLa DESC)
	else
	if  (@inParam=4)
		set @RetVal =(SELECT TOP 1 CoefCopil12 FROM Coeficienti order by DeLa DESC)
	else
	if  (@inParam=5)
		set @RetVal =(SELECT TOP 1 CoefCopil3 FROM Coeficienti order by DeLa DESC)
	else
	if  (@inParam=6)
		set @RetVal =(SELECT TOP 1 CoefUrmCopil FROM Coeficienti order by DeLa DESC)

	return @RetVal

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor: Cristina Muntean
	Nume: GetAllDomeniiDeActivitate
	Descriere: returneaza toate domeniile de activitate din baza de date
*/
CREATE PROCEDURE GetAllDomeniiDeActivitate

AS
	SELECT *
	FROM DomeniiDeActivitate
		
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetAllInvaliditati

AS

select *

from Invaliditati

order by Coeficient

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Autor: Muntean Raluca Cristina
--returneaza toate lunile din an pentru angajatorul trimis ca parametru
CREATE PROCEDURE dbo.GetAllLuni_An
(
	--parametrii
	@An int,
	@AngajatorID int
)
AS
SELECT     MONTH(Sal_Luni.Data) AS Luna,
		   CASE MONTH(Sal_Luni.Data)
				WHEN 1 THEN 'Ianuarie'
				WHEN 2 THEN 'Februarie'
				WHEN 3 THEN 'Martie'
				WHEN 4 THEN 'Aprilie'
				WHEN 5 THEN 'Mai'
				WHEN 6 THEN 'Iunie'
				WHEN 7 THEN 'Iulie'
				WHEN 8 THEN 'August'
				WHEN 9 THEN 'Septembrie'
				WHEN 10 THEN 'Octombrie'
				WHEN 11 THEN 'Noiembrie'
				WHEN 12 THEN 'Decembrie'
			END AS Denumire,Sal_Luni.LunaID, Sal_Luni.ProcentInflatie
FROM      Sal_Luni
WHERE     (YEAR(Sal_Luni.Data) = @An) AND (Sal_Luni.AngajatorID=@AngajatorID)
GROUP BY MONTH(Sal_Luni.Data),Sal_Luni.LunaID,Sal_Luni.ProcentInflatie
ORDER BY MONTH(Sal_Luni.Data)
RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetCategorii AS
select * from categorii

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE GetConcediiMedicale
/*
	(
		@parameter1 datatype = default value,
		@parameter2 datatype OUTPUT
	)
*/
AS
	select * from ConcediuMedicZilePlatite
	


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:Cristina Muntean
	Data: 09.02.2005
	Nume:GetDomDeActDisponibilePtAngajator
	Descriere:Returneaza toate domeniile de activitate care nu apartin angajatorului trimis ca parametru
*/
CREATE PROCEDURE GetDomDeActDisponibilePtAngajator
(
	@AngajatorID int --id-ul angajatorului
)
AS

SELECT     DomeniiDeActivitate.*
FROM       DomeniiDeActivitate 
WHERE     (DomeniiDeActivitate.DomDeActivitateID NOT IN
                          (SELECT     DomDeActivitateID
                            FROM          DomDeActivitateAngajator
                            WHERE      AngajatorID = @AngajatorID))

	
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor: Cristina Muntean
	Nume: GetDomDeActivitateAngajatorInfo
	Descriere: returneaza detaliile legate de inregistrarea cu ID-ul @DomeniuAngajatorID din 
	--tabela DomDeActivitateAngajator
*/
CREATE PROCEDURE GetDomDeActivitateAngajatorInfo
(
	@DomeniuAngajatorID int 
)

AS
	SELECT *
	FROM DomDeActivitateAngajator
	WHERE DomeniuAngajatorID=@DomeniuAngajatorID
		
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
 * Autor: Cristina Muntean
 * Nume: GetDomeniuDeActivitateInfo
 * Descriere: Returneaza toate detaliile despre domeniul de activitate 
  cu id-ul trimis ca parametru(DomDeActivitateID)
*/
CREATE PROCEDURE GetDomeniuDeActivitateInfo
(
	@DomDeActivitateID int --ID-ul domeniului de activitate
)
AS
SELECT     *
FROM       DomeniiDeActivitate  
WHERE     DomDeActivitateID = @DomDeActivitateID

RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetLegitimatiiSedereAngajat
(
	@AngajatID bigint
)
AS

select *
from LegitimatiiSedere
where AngajatID=@AngajatID
order by LegitimatieSedereDataExpirare desc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetLunaDetaliiByData 
(
	@DataCurenta datetime,
	@AngajatorID int
)
AS
select * from sal_Luni 
where DatePart(mm, Data)=DatePart(mm, @DataCurenta) and DatePart(yy, Data)=DatePart(yy, @DataCurenta) and
	AngajatorID=@AngajatorID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetLunaPrecedenta
(
	@LunaID int,
	@AngajatorID int,
	@ReturnValue int =-1 out
)
AS

declare @data datetime
set @data = '1/1/1'

select @data=Data

from sal_Luni

where LunaID=@LunaID



select @ReturnValue=LunaID--, (select Data from sal_Luni where LunaID=@LunaID) as DataCurenta

from sal_Luni

where DateAdd( mm, -1, @data )=Data

return @ReturnValue

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetLuniSalarii AS

	select Sal_luni.LunaID, Activ, (Luni_Text.denumire + ' ' + CAST(Year(Sal_luni.Data) as nvarchar)) as Denumire from Sal_luni
		 left join Luni_Text on Luni_text.LunaTextID=Month(Sal_luni.Data)
		order by data desc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetNIFuriAngajat
(
	@AngajatID bigint
)
AS

select *
from NIF
where AngajatID=@AngajatID
order by Activ desc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetNrZileConcediuBoalaLunaFirma
(
	@NrMediuAngajati float,
	@ReturnValue int=-1 out
)
AS

select @ReturnValue=NrZilePlatite

from ConcediuMedicZilePlatite

where ValMinimAngajati<=@NrMediuAngajati and
	@NrMediuAngajati<=ValMaximAngajati

return @ReturnValue

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE GetNrZileLucratoare
(
@dataStart datetime,
@dataStop datetime
)
/*
Se iau in calcul si zilele de dataStart si dataStop
*/
as

declare @tmpStart datetime
declare @xRows int
declare @nrZileLucratoare int
set @tmpStart=@dataStart
set @nrZileLucratoare=0
set @xRows=0
while(0<=(datediff(day,@tmpStart,@dataStop))and(0<=datediff(month,@tmpStart,@dataStop))and(0<=datediff(year,@tmpStart,@dataStop)))
	begin
		exec @xRows = IsDaySarbatoare @tmpStart
		if((datename(dw,@tmpStart)<>'Sunday')and(datename(dw,@tmpStart)<>'Saturday')and (@xRows=0))
		set @nrZileLucratoare=@nrZileLucratoare+1;
		set @tmpStart=dateadd(day,1,@tmpStart);
	end
return @nrZileLucratoare

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE GetNrZilePlatiteConcediuMedical
(
@ValMinim int,
@ValMaxim int
)
/*
	(
		@parameter1 datatype = default value,
		@parameter2 datatype OUTPUT
	)
*/
AS
declare @nrZilePlatite int
set @nrZilePlatite=0
select @nrZilePlatite=NrZilePlatite from ConcediuMedicZilePlatite where @ValMinim>ValMinimAngajati and @ValMaxim<ValMaximAngajati
	RETURN @nrZilePlatite


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetPermiseMuncaAngajat
(
	@AngajatID bigint
)
AS

select *
from PermiseMunca
where AngajatID=@AngajatID
order by PermMuncaDataExpirare desc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


--Autor: Vlad Dovlecel
--returneaza tara de baza, daca ea exista
CREATE PROCEDURE GetTaraDeBaza
AS

select * 
from Tari
where TaraDeBaza=1

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE GetUltimileSaseLuni
(

@data datetime,
@id int
)
/*
	(
		@parameter1 datatype = default value,
		@parameter2 datatype OUTPUT
	)
*/
AS
/*Se cauta ultimile sase luni de la luna activa*/
if(@id=-2)
begin
select @data=Data from Sal_Luni where Activ=1
select Data,LunaID from Sal_Luni where
(month(dateadd(month,-1,@data))=month(Data)and (year(dateadd(month,-1,@data))=year(Data)))
or
(month(dateadd(month,-2,@data))=month(Data)and (year(dateadd(month,-2,@data))=year(Data)))
or
(month(dateadd(month,-3,@data))=month(Data)and (year(dateadd(month,-3,@data))=year(Data)))
or
(month(dateadd(month,-4,@data))=month(Data)and (year(dateadd(month,-4,@data))=year(Data)))
or
(month(dateadd(month,-5,@data))=month(Data)and (year(dateadd(month,-5,@data))=year(Data)))
or
(month(dateadd(month,-6,@data))=month(Data)and (year(dateadd(month,-6,@data))=year(Data)))
end
else
/*Se cauta ultimele sase luni de la data transmisa*/ 
if (@id=0)
begin
select Data,LunaID from Sal_Luni where
(month(dateadd(month,-1,@data))=month(Data)and (year(dateadd(month,-1,@data))=year(Data)))
or
(month(dateadd(month,-2,@data))=month(Data)and (year(dateadd(month,-2,@data))=year(Data)))
or
(month(dateadd(month,-3,@data))=month(Data)and (year(dateadd(month,-3,@data))=year(Data)))
or
(month(dateadd(month,-4,@data))=month(Data)and (year(dateadd(month,-4,@data))=year(Data)))
or
(month(dateadd(month,-5,@data))=month(Data)and (year(dateadd(month,-5,@data))=year(Data)))
or
(month(dateadd(month,-6,@data))=month(Data)and (year(dateadd(month,-6,@data))=year(Data)))
end
else
/*se cauta ultimele sase luni de Id-ul luniii transmise*/
begin
select @data=Data from Sal_Luni where @id=LunaID
select Data,LunaID from Sal_Luni where
(month(dateadd(month,0,@data))=month(Data)and (year(dateadd(month,0,@data))=year(Data)))
or
(month(dateadd(month,1,@data))=month(Data)and (year(dateadd(month,1,@data))=year(Data)))
or
(month(dateadd(month,2,@data))=month(Data)and (year(dateadd(month,2,@data))=year(Data)))
or
(month(dateadd(month,3,@data))=month(Data)and (year(dateadd(month,3,@data))=year(Data)))
or
(month(dateadd(month,4,@data))=month(Data)and (year(dateadd(month,4,@data))=year(Data)))
or
(month(dateadd(month,5,@data))=month(Data)and (year(dateadd(month,5,@data))=year(Data)))
end



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		Mircea Albutiu, PSE RO BS TH
* Nume:			InsertUpdateActivitati
* Descriere:	Adauga sa modifica o activitate
*/
CREATE PROCEDURE InsertUpdateActivitati
(
	@in_ActivitateID int = 0,
	@in_Nume nvarchar(50),
	@in_Descriere nvarchar(255) = NULL,
	@new_id int = 0 output
)
as

declare @rc int
set @rc = 0

begin tran InsertUpdateActivitati

if(@in_ActivitateID = 0)
begin	--Insert Activitate
	insert into Activitati with (xlock) (Nume, Descriere)
		values (@in_Nume, @in_Descriere)

	if(@@ERROR <> 0)
	begin
		rollback tran InsertUpdateActivitati
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertUpdateActivitati
		set @new_id = @@IDENTITY
	end
end
else
begin	--Update Activitate
	update Activitati with(xlock) set Nume = @in_Nume, Descriere = @in_Descriere
		where ActivitateID = @in_ActivitateID

	if(@@ERROR <> 0)
	begin
		rollback tran InsertUpdateActivitati
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertUpdateActivitati
		set @new_id = @in_ActivitateID
	end
end

return @rc 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE InsertUpdateBazaDateCAS
(
@tip_actiune int,
@ID_Angajat bigint,
@ID_Luna int,
@ValCAS float
)
/*
	(
		@parameter1 datatype = default value,
		@parameter2 datatype OUTPUT
	)
*/
AS
	
declare @rc int
set @rc = 0
begin tran UIInsertUpdateBazaDateCAS
if(@tip_actiune = 0)
begin
insert into BazaDateCAS with(xlock) (ID_Angajat, ID_Luna,ValCAS) 
		values (@ID_Angajat,@ID_Luna,@ValCAS)
		if(@@ERROR <> 0)
		begin
			rollback tran UIInsertUpdateBazaDateCAS
			set @rc = @@ERROR
		end
		else
		begin
			commit tran UIInsertUpdateBazaDateCAS
			set @rc = 0
		end		
end
else
if(@tip_actiune = 1)
begin
update BazaDateCAS with(xlock) set ID_Angajat=@ID_Angajat,ID_Luna= @ID_Luna,ValCAS=@ValCAS
		where ID_Angajat=@ID_Angajat and ID_Luna=@ID_Luna
		if(@@ERROR <> 0)
		begin
			rollback tran UIInsertUpdateBazaDateCAS
			set @rc = @@ERROR
		end
		else
		begin
			commit tran UIInsertUpdateBazaDateCAS
			set @rc = 0
		end
	
end
else
if(@tip_actiune = 2)
begin
delete from  BazaDateCAS with(xlock) where ID_Angajat=@ID_Angajat and ID_Luna=@ID_Luna
	if(@@ERROR <> 0)
		begin
		rollback tran UIInsertUpdateBazaDateCAS
		set @rc = @@ERROR
		end
	else
	begin
		commit tran UIInsertUpdateBazaDateCAS
		set @rc = 0
	end
end
else
rollback tran UIInsertUpdateBazaDateCAS

return @rc


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteBanca
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Banci
*/
CREATE PROCEDURE InsertUpdateDeleteBanca
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@BancaID int,
	@CodBanca nvarchar(50),
	@NumeBanca nvarchar(100), 
	@FilialaBanca nvarchar(100)
)

as

declare @rc int
set @rc = 0

begin tran IUDBanci

if(@tip_actiune = 0)
begin	--Insert banca
	insert into Banci with(xlock) (CodBanca, Nume, Filiala) 
		values (@CodBanca, @NumeBanca, @FilialaBanca)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDBanci
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDBanci
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update banca
	update Banci with(xlock) set CodBanca = @CodBanca, Nume = @NumeBanca, Filiala = @FilialaBanca
		where BancaId=@BancaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDBanci
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDBanci
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete banca
	delete from Banci with(xlock) where BancaID = @BancaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDBanci
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDBanci
		set @rc = 0
	end
end
else
	rollback tran IUDBanci

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Dovlecel Vlad
* Nume:			InsertUpdateDeleteBoala
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Boli
*/
CREATE PROCEDURE InsertUpdateDeleteBoala
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@BoalaID int,
	@CodBoala nvarchar(5),
	@CategorieBoala nvarchar(150), 
	@Procent float = 0,
	@Stagiu nvarchar(2)
)

as

declare @rc int
set @rc = 0

/*declare @StagiuString nvarchar(2)
if( @Stagiu = 0 )
	set @StagiuString = 'nu'
else
	set @StagiuString = 'da'*/
begin tran IUDBoli

if(@tip_actiune = 0)
begin	--Insert boala
	insert into Boli with(xlock) (Cod, Categorie, Procent, Stagiu) 
		values (@CodBoala, @CategorieBoala, @Procent, @Stagiu)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDBoli
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDBoli
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update boala
	update Boli with(xlock) set Cod = @CodBoala, Categorie = @CategorieBoala, Procent = @Procent, Stagiu = @Stagiu
		where BoalaId=@BoalaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDBoli
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDBoli
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete boala
	delete from Boli with(xlock) where BoalaID = @BoalaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDBoli
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDBoli
		set @rc = 0
	end
end
else
	rollback tran IUDBoli

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteCategorie
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Categorii
*/
CREATE PROCEDURE InsertUpdateDeleteCategorie
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@CategorieID int,
	@Nume nvarchar(100), 
	@Descriere nvarchar(255)
)

as

declare @rc int
set @rc = 0

begin tran IUDCategorie

if(@tip_actiune = 0)
begin	--Insert categorie
	insert into Categorii with(xlock) (Nume, Descriere) 
		values (@Nume, @Descriere)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDCategorie
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDCategorie
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update categorie
	update Categorii with(xlock) set Nume = @Nume, Descriere = @Descriere
		where CategorieID=@CategorieID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDCategorie
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDCategorie
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete categorie
	delete from Categorii with(xlock) where CategorieID = @CategorieID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDCategorie
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDCategorie
		set @rc = 0
	end
end
else
	rollback tran IUDCategorie

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteCentruCost
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul CentreCost
*/
CREATE PROCEDURE InsertUpdateDeleteCentruCost
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@CentruCostID int,
	@Cod bigint,
	@Nume nvarchar(50), 
	@Descriere nvarchar(255)
)

as

declare @rc int
set @rc = 0

begin tran IUDCentreCost

if(@tip_actiune = 0)
begin	--Insert centru cost
	insert into CentreCost with(xlock) (Cod, Nume, Descriere) 
		values (@Cod, @Nume, @Descriere)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDCentreCost
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDCentreCost
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update centru cost
	update CentreCost with(xlock) set Cod = @Cod, Nume = @Nume, Descriere = @Descriere
		where CentruCostId=@CentruCostID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDCentreCost
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDCentreCost
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete centru cost
	delete from CentreCost with(xlock) where CentruCostID = @CentruCostID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDCentreCost
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDCentreCost
		set @rc = 0
	end
end
else
	rollback tran IUDCentreCost

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
* Autor:		Cristina Muntean
* Nume:			InsertUpdateDeleteDomDeActivitateAngajator
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul DomDeActivitateAngajator
*/
CREATE PROCEDURE InsertUpdateDeleteDomDeActivitateAngajator
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete, 3 sterge toate domeniile asociate unui angajator
	@DomeniuAngajatorID int, --ID-ul inregistrarii
	@AngajatorID int, --ID-ul angajatorului
	@DomDeActivitateID int, --ID-ul domeniului de activitate
	@Principal bit = 0 --1-domeniu de activitate principal,0-domeniu de activitate secundar
	--un angajator are un singur domeniu de activitate principal, restul sunt secundare
)

as

declare @rc int
set @rc = 0

begin tran IUDDomeniuAngajator

if(@tip_actiune = 0)
begin	--Insert domeniu de activitate pentru un angajator
	insert into DomDeActivitateAngajator with(xlock) (AngajatorID, DomDeActivitateID, Principal) 
	values (@AngajatorID, @DomDeActivitateID, @Principal)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDDomeniuAngajator
		set @rc = @@ERROR
	end
	else
	begin
		set @DomeniuAngajatorID = @@IDENTITY
		commit tran IUDDomeniuAngajator
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update domeniu de activitate pentru un angajator
	update DomDeActivitateAngajator with(xlock) set AngajatorID = @AngajatorID, DomDeActivitateID = @DomDeActivitateID, 
													Principal=@Principal
	where DomeniuAngajatorID=@DomeniuAngajatorID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDDomeniuAngajator
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDDomeniuAngajator
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete domeniu de activitate al unui angajator
	delete from DomDeActivitateAngajator with(xlock) where DomDeActivitateID = @DomDeActivitateID AND AngajatorID=@AngajatorID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDDomeniuAngajator
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDDomeniuAngajator
		set @rc = 0
	end
end
else if(@tip_actiune = 3)
begin	--Delete toate domeniile de activitate ale unui angajator
	delete from DomDeActivitateAngajator with(xlock) where AngajatorID=@AngajatorID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDDomeniuAngajator
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDDomeniuAngajator
		set @rc = 0
	end
end

else
	rollback tran IUDDomeniuAngajator
--daca tipul actiunii este insert,update sau delete
if(@tip_actiune>=0 and @tip_actiune<=3)
	--daca actiunea este insert sau update si un domeniu este setat ca fiind principal
	if(@tip_actiune<>2 and @tip_actiune<>3 and @Principal=1)
		--restul domeniilor devin secundare
		update DomDeActivitateAngajator with(xlock) set Principal=0 where AngajatorID=@AngajatorID and DomeniuAngajatorID<>@DomeniuAngajatorID
		
return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
* Autor:		Cristina Muntean
* Nume:			InsertUpdateDeleteDomeniuDeActivitate
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul DomeniiDeActivitate
*/
CREATE PROCEDURE InsertUpdateDeleteDomeniuDeActivitate
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@DomDeActivitateID int, --ID-ul domeniului de activitate
	@CodCAEN int, --codul CAEN corespunzator domeniului de activitate
	@Denumire nvarchar(100), -- denumirea domeniului de activitate
	@Descriere nvarchar(200) --descrierea domeniului de activitate
)

as

declare @rc int
set @rc = 0

begin tran IUDDomeniu

if(@tip_actiune = 0)
begin	--Insert domeniu de activitate
	insert into DomeniiDeActivitate with(xlock) (CodCAEN, Denumire, Descriere) 
	values (@CodCAEN, @Denumire, @Descriere)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDDomeniu
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDDomeniu
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update domeniu de activitate
	update DomeniiDeActivitate with(xlock) set CodCAEN = @CodCAEN, Denumire = @Denumire, Descriere = @Descriere
	where DomDeActivitateID=@DomDeActivitateID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDDomeniu
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDDomeniu
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete domeniu de activitate
	delete from DomeniiDeActivitate with(xlock) where DomDeActivitateID = @DomDeActivitateID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDDomeniu
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDDomeniu
		set @rc = 0
	end
end
else
	rollback tran IUDDomeniu

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteFunctie
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Functii
* Modificat:    Cristina Muntean
*/
CREATE PROCEDURE InsertUpdateDeleteFunctie
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@FunctieID int, --id-ul functiei
	@Cod bigint, --codul COR al functiei
	@CodSiemens nvarchar(20),  --codul Siemens atasat functiei
	@Nume nvarchar(50), --numele functiei
	@Descriere nvarchar(255), --descrierea functiei
	@NormaLucru int --norma pentru functie
	--Cristina Muntean
	--@FunctieDeExecutie nvarchar(50),
	--@ScopulPostului nvarchar(200),
	--@PregDeSpecialitate nvarchar(200),
	--@Perfectionari nvarchar(200),
	--@LimbiStraine nvarchar(100),
	--@CerinteSpecifice nvarchar(250),
	--@CompetentaManageriala nvarchar(150),
	--@ResponsabilitatilePostului nvarchar(400),
	--@AutoritateaPostului nvarchar(400),
	--@Atributii nvarchar(400),
	--@SubordonatFataDe nvarchar(50),
	--@SuperiorPentru nvarchar(50),
	--@RelFunctionale nvarchar(100),
	--@RelDeControl nvarchar(100),
	--@RelDeReprezentare nvarchar(100),
	--@RelCuInstPublice nvarchar(100),
	--@RelCuOrgInternat nvarchar(100),
	--@RelCuPersJuridice nvarchar(100)	
)

as

declare @rc int
set @rc = 0

begin tran IUDFunctie

if(@tip_actiune = 0)
begin	--Insert functie
	insert into Functii with(xlock) (Cod, CodSiemens, Nume, Descriere, NormaLucru 
	--, FunctieDeExecutie ,	ScopulPostului ,
	--PregDeSpecialitate ,Perfectionari ,	LimbiStraine ,	CerinteSpecifice ,	CompetentaManageriala ,	
	--ResponsabilitatilePostului,AutoritateaPostului,	Atributii ,	SubordonatFataDe ,	SuperiorPentru ,	RelFunctionale ,	RelDeControl ,
	--RelDeReprezentare ,	RelCuInstPublice ,	RelCuOrgInternat ,	RelCuPersJuridice 
	) 
	values (@Cod, @CodSiemens, @Nume, @Descriere, @NormaLucru
	--, @FunctieDeExecutie ,	@ScopulPostului ,
	--@PregDeSpecialitate ,@Perfectionari ,	@LimbiStraine ,	@CerinteSpecifice ,	@CompetentaManageriala ,	
	--@ResponsabilitatilePostului , @AutoritateaPostului,@Atributii ,@SubordonatFataDe ,	@SuperiorPentru ,	@RelFunctionale ,	@RelDeControl ,
	--@RelDeReprezentare ,@RelCuInstPublice ,	@RelCuOrgInternat ,	@RelCuPersJuridice
	)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDFunctie
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDFunctie
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update functie
	update Functii with(xlock) set Cod = @Cod, CodSiemens=@CodSiemens, Nume = @Nume, Descriere = @Descriere, NormaLucru=@NormaLucru
	--,FunctieDeExecutie=@FunctieDeExecutie ,	ScopulPostului=@ScopulPostului ,PregDeSpecialitate=@PregDeSpecialitate ,
	--Perfectionari=@Perfectionari ,	LimbiStraine=@LimbiStraine ,CerinteSpecifice=@CerinteSpecifice ,
	--CompetentaManageriala=@CompetentaManageriala ,ResponsabilitatilePostului=@ResponsabilitatilePostului ,	
	--AutoritateaPostului=@AutoritateaPostului, Atributii=@Atributii ,SubordonatFataDe=@SubordonatFataDe ,
	--SuperiorPentru=@SuperiorPentru ,RelFunctionale=@RelFunctionale ,RelDeControl=@RelDeControl ,
	--RelDeReprezentare=@RelDeReprezentare ,RelCuInstPublice=@RelCuInstPublice ,	RelCuOrgInternat=@RelCuOrgInternat ,
	--RelCuPersJuridice=@RelCuPersJuridice
	where FunctieID=@FunctieID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDFunctie
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDFunctie
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete functie
	delete from Functii with(xlock) where FunctieID = @FunctieID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDFunctie
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDFunctie
		set @rc = 0
	end
end
else
	rollback tran IUDFunctie

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteGrupaMunca
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul GrupeMunca
*/
CREATE PROCEDURE InsertUpdateDeleteGrupaMunca
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@GrupaMuncaID int,
	@Nume nvarchar(100), 
	@Descriere nvarchar(255)
)

as

declare @rc int
set @rc = 0

begin tran IUDGrupaMunca

if(@tip_actiune = 0)
begin	--Insert GrupaMunca
	insert into GrupeMunca with(xlock) (Nume, Descriere) 
		values (@Nume, @Descriere)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDGrupaMunca
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDGrupaMunca
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update GrupaMunca
	update GrupeMunca with(xlock) set Nume = @Nume, Descriere = @Descriere
		where GrupaMuncaID=@GrupaMuncaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDGrupaMunca
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDGrupaMunca
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete GrupaMunca
	delete from GrupeMunca with(xlock) where GrupaMuncaID = @GrupaMuncaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDGrupaMunca
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDGrupaMunca
		set @rc = 0
	end
end
else
	rollback tran IUDGrupaMunca

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Dovlecel Vlad
* Nume:			InsertUpdateDeleteInvaliditate
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Invaliditati
*/
CREATE PROCEDURE InsertUpdateDeleteInvaliditate
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@InvaliditateID int,
	@Nume nvarchar(100),
	@Coeficient float,
	@Descriere nvarchar(255)
)

as

declare @rc int
set @rc = 0

begin tran IUDInvaliditate

if(@tip_actiune = 0)
begin	--Insert categorie
	insert into Invaliditati with(xlock) (Nume, Coeficient, Descriere) 
		values (@Nume, @Coeficient, @Descriere)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDInvaliditate
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDInvaliditate
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update categorie
	update Invaliditati with(xlock) set Nume = @Nume, Coeficient=@Coeficient, Descriere = @Descriere
		where InvaliditateID=@InvaliditateID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDInvaliditate
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDInvaliditate
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete categorie
	delete from Invaliditati with(xlock) where InvaliditateID=@InvaliditateID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDInvaliditate
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDInvaliditate
		set @rc = 0
	end
end
else
	rollback tran IUDInvaliditate

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:	InsertUpdateDeleteJudet
* Simbol:	Adauga, modifica, sterge o inregistrare in tabelul Judete
*/
CREATE PROCEDURE InsertUpdateDeleteJudet
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@JudetID int,
	@Nume nvarchar(100), 
	@Simbol nvarchar(4),
	@TaraID int
)

as

declare @rc int
set @rc = 0

begin tran IUDTitluAngajat

if(@tip_actiune = 0)
begin	--Insert Judet
	insert into Judete with(xlock) (Nume, Simbol, TaraID) 
		values (@Nume, @Simbol, @TaraID)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTitluAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTitluAngajat
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update Judet
	update Judete with(xlock) set Nume = @Nume, Simbol = @Simbol, TaraID = @TaraID
		where JudetID=@JudetID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTitluAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTitluAngajat
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete Judet
	delete from Judete with(xlock) where JudetID = @JudetID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTitluAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTitluAngajat
		set @rc = 0
	end
end
else
	rollback tran IUDTitluAngajat

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Dovlecel Vlad
* Nume:			InsertUpdateDeleteLegitimatiiSedere
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul LegitimatiiSedere
*/
CREATE PROCEDURE InsertUpdateDeleteLegitimatieSedere
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@LegitimatieSedereID int,
	@AngajatID int,
	@SerieLegitimatieSedere nvarchar(10),
	@NrLegitimatieSedere bigint,
	@LegitimatieSedereDataEliberare datetime, 
	@LegitimatieSedereDataExpirare datetime,
	@Activ bit = 1
)

as

declare @rc int
set @rc = 0

begin tran IUDLegitimatieSedere

if(@tip_actiune = 0)
begin	--Insert legitimatie de sedere
	insert into LegitimatiiSedere with(xlock) (AngajatID, NrLegitimatieSedere, SerieLegitimatieSedere, LegitimatieSedereDataEliberare, LegitimatieSedereDataExpirare, Activ) 
		values ( @AngajatID, @NrLegitimatieSedere, @SerieLegitimatieSedere, @LegitimatieSedereDataEliberare, @LegitimatieSedereDataExpirare, @Activ )
	if(@@ERROR <> 0)
	begin
		rollback tran IUDLegitimatieSedere
		set @rc = @@ERROR
	end
	else
	begin
		set @LegitimatieSedereID = @@IDENTITY
		commit tran IUDLegitimatieSedere
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update LegitimatieSedere
	update LegitimatiiSedere with(xlock) set AngajatID=@AngajatID, NrLegitimatieSedere=@NrLegitimatieSedere, SerieLegitimatieSedere=@SerieLegitimatieSedere, 
				LegitimatieSedereDataEliberare=@LegitimatieSedereDataEliberare, LegitimatieSedereDataExpirare=@LegitimatieSedereDataExpirare,
				Activ=@Activ
		where LegitimatieSedereID=@LegitimatieSedereID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDLegitimatieSedere
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDLegitimatieSedere
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete legitimatie de sedere
	delete from LegitimatiiSedere with(xlock) where LegitimatieSedereID=@LegitimatieSedereID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDLegitimatieSedere
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDLegitimatieSedere
		set @rc = 0
	end
end
else
	rollback tran IUDLegitimatieSedere

if(@tip_actiune>=0 and @tip_actiune<=2)
	if(@tip_actiune<>2 and @Activ=1)
		update LegitimatiiSedere with(xlock) set Activ=0 where AngajatID=@AngajatID and LegitimatieSedereID<>@LegitimatieSedereID

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteLocMunca
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul LocuriMunca
*/
CREATE PROCEDURE InsertUpdateDeleteLocMunca
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@LocMuncaID int,
	@Nume nvarchar(100), 
	@Descriere nvarchar(255)
)

as

declare @rc int
set @rc = 0

begin tran IUDLocMunca

if(@tip_actiune = 0)
begin	--Insert LocMunca
	insert into LocuriMunca with(xlock) (Nume, Descriere) 
		values (@Nume, @Descriere)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDLocMunca
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDLocMunca
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update LocMunca
	update LocuriMunca with(xlock) set Nume = @Nume, Descriere = @Descriere
		where LocMuncaID=@LocMuncaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDLocMunca
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDLocMunca
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete LocMunca
	delete from LocuriMunca with(xlock) where LocMuncaID = @LocMuncaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDLocMunca
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDLocMunca
		set @rc = 0
	end
end
else
	rollback tran IUDLocMunca

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Dovlecel Vlad
* Nume:			InsertUpdateDeleteNIF
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul NIF - Numarul de Inregistrare Fiscala
*/
CREATE PROCEDURE InsertUpdateDeleteNIF
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@NIFID int,
	@AngajatID int,
	@NIF numeric,
	@Activ bit = 1
)

as

declare @rc int
set @rc = 0

begin tran IUDNIF

if(@tip_actiune = 0)
begin	--Insert NIF
	insert into NIF with(xlock) (AngajatID, NIF, Activ) 
		values ( @AngajatID, @NIF, @Activ)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDNIF
		set @rc = @@ERROR
	end
	else
	begin
		set @NIFID = @@IDENTITY
		commit tran IUDNIF
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update NIF
	update NIF with(xlock) set AngajatID=@AngajatID, NIF=@NIF,  Activ=@Activ
		where NIFID=@NIFID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDNIF
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDNIF
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete NIF
	delete from NIF with(xlock) where NIFID=@NIFID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDNIF
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDNIF
		set @rc = 0
	end
end
else
	rollback tran IUDNIF

if(@tip_actiune>=0 and @tip_actiune<=2)
	if(@tip_actiune<>2 and @Activ=1)
		update NIF with(xlock) set Activ=0 where AngajatID=@AngajatID and NIFID<>@NIFID

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Dovlecel Vlad
* Nume:			InsertUpdateDeletePermisMunca
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul PermiseMunca
*/
CREATE PROCEDURE InsertUpdateDeletePermisMunca
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@PermisMuncaID int,
	@AngajatID int,
	@NrPermisMunca bigint,
	@SeriePermisMunca nvarchar(10),
	@PermMuncaDataEliberare datetime, 
	@PermMuncaDataExpirare datetime,
	@Activ bit = 1
)

as

declare @rc int
set @rc = 0

begin tran IUDPermiseMunca

if(@tip_actiune = 0)
begin	--Insert permis munca
	insert into PermiseMunca with(xlock) (AngajatID, NrPermisMunca, SeriePermisMunca, PermMuncaDataEliberare, PermMuncaDataExpirare, Activ) 
		values ( @AngajatID, @NrPermisMunca, @SeriePermisMunca, @PermMuncaDataEliberare, @PermMuncaDataExpirare, @Activ)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDPermiseMunca
		set @rc = @@ERROR
	end
	else
	begin
		set @PermisMuncaID = @@IDENTITY
		commit tran IUDPermiseMunca
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update permis munca
	update PermiseMunca with(xlock) set AngajatID=@AngajatID, NrPermisMunca=@NrPermisMunca, SeriePermisMunca=@SeriePermisMunca, PermMuncaDataEliberare=@PermMuncaDataEliberare,
						PermMuncaDataExpirare=@PermMuncaDataExpirare, Activ=@Activ
		where PermisMuncaID=@PermisMuncaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDPermiseMunca
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDPermiseMunca
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete permis munca
	delete from PermiseMunca with(xlock) where PermisMuncaID=@PermisMuncaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDPermiseMunca
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDPermiseMunca
		set @rc = 0
	end
end
else
	rollback tran IUDPermiseMunca

if(@tip_actiune>=0 and @tip_actiune<=2)
	if(@tip_actiune<>2 and @Activ=1)
		update PermiseMunca with(xlock) set Activ=0 where AngajatID=@AngajatID and PermisMuncaID<>@PermisMuncaID

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteStudiu
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Studiii
*/
CREATE PROCEDURE InsertUpdateDeleteStudiu
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@StudiuID int,
	@Nume nvarchar(100)
)

as

declare @rc int
set @rc = 0

begin tran IUDStudiu

if(@tip_actiune = 0)
begin	--Insert studiu
	insert into Studii with(xlock) (Nume) values (@Nume)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDStudiu
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDStudiu
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update studiu
	update Studii with(xlock) set Nume = @Nume
		where StudiuID=@StudiuID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDStudiu
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDStudiu
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete studiu
	delete from Studii with(xlock) where StudiuID = @StudiuID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDStudiu
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDStudiu
		set @rc = 0
	end
end
else
	rollback tran IUDStudiu

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* NumeTara:	InsertUpdateDeleteTara
* Simbol:	Adauga, modifica, sterge o inregistrare in tabelul Tari
*/
CREATE PROCEDURE InsertUpdateDeleteTara
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@TaraID int,
	@NumeTara nvarchar(100), 
	@Simbol nvarchar(4),
	@Nationalitate nvarchar(50),
	@TaraDeBaza bit
)

as

declare @rc int
set @rc = 0

begin tran IUDTara

if(@tip_actiune = 0)
begin	--Insert Tara
	insert into Tari with(xlock) (NumeTara, Simbol, Nationalitate, TaraDeBaza) 
		values (@NumeTara, @Simbol, @Nationalitate, @TaraDeBaza )
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTara
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTara
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update Tara
	update Tari with(xlock) set NumeTara = @NumeTara, Simbol = @Simbol, Nationalitate = @Nationalitate, TaraDeBaza = @TaraDeBaza
		where TaraID=@TaraID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTara
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTara
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete Tara
	delete from Tari with(xlock) where TaraID = @TaraID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTara
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTara
		set @rc = 0
	end
end
else
	rollback tran IUDTara

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Denumire:			InsertUpdateDeleteTipRaport
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul TipuriRapoarte
*/
CREATE PROCEDURE InsertUpdateDeleteTipRaport
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@TipRaportID int,
	@Denumire nvarchar(100), 
	@Descriere nvarchar(255)
)

as

declare @rc int
set @rc = 0

begin tran IUDTipRaport

if(@tip_actiune = 0)
begin	--Insert categorie
	insert into TipuriRapoarte with(xlock) (Denumire, Descriere) 
		values (@Denumire, @Descriere)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTipRaport
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTipRaport
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update categorie
	update TipuriRapoarte with(xlock) set Denumire = @Denumire, Descriere = @Descriere
		where TipRaportID=@TipRaportID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTipRaport
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTipRaport
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete categorie
	delete from TipuriRapoarte with(xlock) where TipRaportID = @TipRaportID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTipRaport
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTipRaport
		set @rc = 0
	end
end
else
	rollback tran IUDTipRaport

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Rares Gosman,  PSE RO BS TH
* Nume:			InsertUpdateDeleteTraining
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Traininguri
*/
CREATE PROCEDURE InsertUpdateDeleteTraining
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@TrainingID int,
	@Nume nvarchar(255),
	@Descriere nvarchar(255) = null,
	@Diploma nvarchar(255) = null,
              @Intern bit

)

as

declare @rc int
set @rc = 0

begin tran IUDTraining

if(@tip_actiune = 0)
begin	--Insert Training
	insert into Traininguri with(xlock) (Nume, Descriere,Diploma,Intern) 
		values (@Nume, @Descriere,@Diploma,@Intern)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTraining
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTraining
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--UpdateTraining
	update  Traininguri with(xlock) set Nume = @Nume, Descriere = @Descriere,Diploma=@Diploma,Intern=@Intern
		where TrainingID = @TrainingID 
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTraining
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTraining
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete Training
	delete from Traininguri with(xlock) where TrainingID = @TrainingID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTraining
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTraining
		set @rc = 0
	end
end
else
	rollback tran IUDTraining

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		Mircea Albutiu, PSE RO BS TH
* Nume:			InsertUpdateDomiciliu
* Descriere:	Adauga sa modifica un domiciliu sau resedinta
*/
CREATE PROCEDURE InsertUpdateDomiciliu
(
	@AngajatID int,
	@TaraID int,
	@Localitate nvarchar(50),
	@JudetSectorID int,
	@Strada nvarchar(50),
	@Numar nvarchar(10),
	@CodPostal nvarchar(20),
	@Bloc nvarchar(5) = NULL,
	@Scara nvarchar(5) = NULL,
	@Etaj nvarchar(5) = NULL,
	@Apartament nvarchar(5) = NULL,
	@Tip varchar(5)		--D - domicliu, R -resedinta
)
as

declare @rc int
set @rc = 0

if(@Tip <> 'd' and @Tip <> 'r')
	return -1

begin tran InsertUpdateDomiciliu

if(@Tip = 'd')
begin
	select @rc = count(AngajatID) from Domicilii where AngajatID = @AngajatID and Tip = @Tip
	
	if(@rc = 0)
	begin	--Insert Domiciliu
		insert into Domicilii with (xlock) (AngajatID, TaraID, Localitate, JudetSectorID, Strada, Numar, CodPostal, Bloc, 
			Scara, Etaj, Apartament, Tip)
			values (@AngajatID, @TaraID, @Localitate, @JudetSectorID, @Strada, @Numar, @CodPostal, @Bloc, 
			@Scara, @Etaj, @Apartament, @Tip)
		if (@@ERROR <> 0)
		begin
			rollback tran InsertUpdateDomiciliu
			set @rc = @@ERROR
		end
		else
		begin
			commit tran InsertUpdateDomiciliu
			set @rc = 0
		end
	end
	else
	begin	--Update Domiciliu
		update Domicilii with (xlock) set TaraID = @TaraID, Localitate = @Localitate, JudetSectorID = @JudetSectorID, 
			Strada = @Strada, Numar = @Numar, CodPostal = @CodPostal, Bloc = @Bloc, Scara = @Scara, Etaj = @Etaj, 
			Apartament = @Apartament
			where AngajatID = @AngajatID and Tip = @Tip
		if (@@ERROR <> 0)
		begin
			rollback tran InsertUpdateDomiciliu
			set @rc = @@ERROR
		end
		else
		begin
			commit tran InsertUpdateDomiciliu
			set @rc = 0
		end
	end
end
else
begin
select @rc = count(AngajatID) from Domicilii where AngajatID = @AngajatID and Tip = @Tip
	if(@rc = 0)
	begin	--Insert Resedinta
		insert into Domicilii with (xlock) (AngajatID, TaraID, Localitate, JudetSectorID, Strada, Numar, CodPostal, Bloc, 
			Scara, Etaj, Apartament, Tip)
			values (@AngajatID, @TaraID, @Localitate, @JudetSectorID, @Strada, @Numar, @CodPostal, @Bloc, 
			@Scara, @Etaj, @Apartament, @Tip)
		if (@@ERROR <> 0)
		begin
			rollback tran InsertUpdateDomiciliu
			set @rc = @@ERROR
		end
		else
		begin
			commit tran InsertUpdateDomiciliu
			set @rc = 0
		end
	end
	else
	begin	--Update Resedinta
		update Domicilii with (xlock) set TaraID = @TaraID, Localitate = @Localitate, JudetSectorID = @JudetSectorID, 
			Strada = @Strada, Numar = @Numar, CodPostal = @CodPostal, Bloc = @Bloc, Scara = @Scara, Etaj = @Etaj, 
			Apartament = @Apartament
			where AngajatID = @AngajatID and Tip = @Tip
		if (@@ERROR <> 0)
		begin
			rollback tran InsertUpdateDomiciliu
			set @rc = @@ERROR
		end
		else
		begin
			commit tran InsertUpdateDomiciliu
			set @rc = 0
		end
	end
end

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.InsertUpdateSarbatoriLegale 
(
	@tip_actiune int,
	@Denumirea nvarchar(50),
	@Descrierea nvarchar(500), 
	@Data datetime,
	@Old_Data datetime
)
/*
	(
		0-insert
		1-update
		2-delete
	)
*/
AS

declare @rc int
set @rc = 0
begin tran UISarbatoriLegale
if(@tip_actiune = 0)
begin
insert into SarbatoriLegale with(xlock) (Denumirea, Descrierea,Data) 
		values (@Denumirea, @Descrierea,@Data)
		if(@@ERROR <> 0)
		begin
			rollback tran UISarbatoriLegale
			set @rc = @@ERROR
		end
		else
		begin
			commit tran UISarbatoriLegale
			set @rc = 0
		end		
end
else
if(@tip_actiune = 1)
begin
update SarbatoriLegale with(xlock) set Denumirea=@Denumirea,Descrierea = @Descrierea,Data=@Data
		--where Data=@Data
		where Data=@Old_Data
		if(@@ERROR <> 0)
		begin
			rollback tran UISarbatoriLegale
			set @rc = @@ERROR
		end
		else
		begin
			commit tran UISarbatoriLegale
			set @rc = 0
		end
	
end
else
if(@tip_actiune = 2)
begin
delete from  SarbatoriLegale with(xlock) where Data=@Data
	if(@@ERROR <> 0)
		begin
		rollback tran UISarbatoriLegale
		set @rc = @@ERROR
		end
	else
	begin
		commit tran UISarbatoriLegale
		set @rc = 0
	end
end
else
rollback tran UISarbatoriLegale

return @rc
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE  procedure Reports_GetAllReportFields
	@ReportID int
as

select * 
from ReportFields
where ReportID = @ReportID
order by MapToRptField, StartFromIdx



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE  procedure Reports_GetAllReportFieldsNames
	@ReportID int,
	@Visible bit
as

select ID, Label 
from ReportFields
where [ReportID] = @ReportID and IsVisible = @Visible 
order by MapToRptField, StartFromIdx




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




create   procedure Reports_GetAllReportNames

as

select ID, Name 
from Reports
order by ID




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


create procedure Reports_GetDetailReportFields
	@ID int
as

select * from ReportFields
where [ID] = @ID


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




create   procedure Reports_GetDetailReports
	@ID int
as

select * 
from Reports
where ID = @ID




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE procedure Reports_UpdateReportFields
	@ID bigint,
	@Visible bit,
	@Result int out
as

update ReportFields
set IsVisible =@Visible
where ID = @ID

select @Result=0
return @Result



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Dovlecel Vlad
* Nume:			SetActivAllLegitimatiiSedereAngajat
* Descriere:	seteaza campul activ din tabelul LegitimatiiSedere pt toate inregistrarile unui angajat
*/
CREATE PROCEDURE SetActivAllLegitimatiiSedereAngajat
(
	@AngajatID int,
	@Activ bit = 0
)

as

declare @rc int
set @rc = 0

begin tran IUDLegitimatiiSedere

update LegitimatiiSedere with(xlock) 
set Activ=@Activ
where AngajatID=@AngajatID

if(@@ERROR <> 0)
begin
	rollback tran IUDLegitimatiiSedere
	set @rc = @@ERROR
end
else
begin
	commit tran IUDLegitimatiiSedere
	set @rc = 0
end

if( @rc <> 0 )
	rollback tran IUDLegitimatiiSedere

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Dovlecel Vlad
* Nume:			SetActivAllNIFAngajat
* Descriere:	seteaza campul activ din tabelul NIF pt toate inregistrarile unui angajat
*/
CREATE PROCEDURE SetActivAllNIFAngajat
(
	@AngajatID int,
	@Activ bit = 0
)

as

declare @rc int
set @rc = 0

begin tran IUDNIF

update NIF with(xlock) 
set Activ=@Activ
where AngajatID=@AngajatID

if(@@ERROR <> 0)
begin
	rollback tran IUDNIF
	set @rc = @@ERROR
end
else
begin
	commit tran IUDNIF
	set @rc = 0
end

if( @rc <> 0 )
	rollback tran IUDNIF

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Dovlecel Vlad
* Nume:			SetActivAllPermiseMunca
* Descriere:	seteaza campul activ din tabelul PermiseMunca pt toate inregistrarile unui angajat
*/

CREATE PROCEDURE SetActivAllPermiseMuncaAngajat
(
	@AngajatID int,
	@Activ bit = 0
)

as

declare @rc int
set @rc = 0

begin tran IUDPermiseMunca

update PermiseMunca with(xlock) 
set Activ=@Activ
where AngajatID=@AngajatID

if(@@ERROR <> 0)
begin
	rollback tran IUDPermiseMunca
	set @rc = @@ERROR
end
else
begin
	commit tran IUDPermiseMunca
	set @rc = 0
end

if( @rc <> 0 )
	rollback tran IUDPermiseMunca

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.sal_DeleteCoef

	(
		@SetID int
	)

AS
DELETE FROM Coeficienti
WHERE     (SetID = @SetID)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.sal_DeleteImpozitarAnual
(
	@ImpozitarID int
)
AS
DELETE FROM sal_Impozitar_anual
WHERE     (ImpozitarID = @ImpozitarID)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.sal_GetAllCoeficienti
	
AS

	SELECT   SetID, DeLa, Deducere, CoefInvalidGrd1, CoefInvalidGrd2, CoefCopil12, CoefCopil3, CoefUrmCopil, CoefSot, CoefTotal, CoefSanatate, 
	                      CoefPensie, CoefSomaj, CoefCheltProf, CASAngajator, SanatateAngajator, SomajAngajator, FondRiscAngajator, CartiCameraMunca, CartiCamera, 
	                      CartiAngajator
	FROM         Coeficienti
	ORDER BY DeLa DESC

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.sal_GetCoeficienti
	(
		@Data datetime
	)

AS

	SELECT     TOP 1 SetID, DeLa, Deducere, CoefInvalidGrd1, CoefInvalidGrd2, CoefCopil12, CoefCopil3, CoefUrmCopil, CoefSot, CoefTotal, CoefSanatate, 
	                      CoefPensie, CoefSomaj, CoefCheltProf, CASAngajator, SanatateAngajator, SomajAngajator, FondRiscAngajator, CartiCameraMunca, CartiCamera, 
	                      CartiAngajator
	FROM         Coeficienti
	WHERE     (DeLa <= @Data)
	ORDER BY DeLa DESC
	


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE sal_GetCoeficientiID

	(
		@SetID int
		
	)

AS
	SELECT     SetID, DeLa, Deducere, CoefInvalidGrd1, CoefInvalidGrd2, CoefCopil12, CoefCopil3, CoefUrmCopil, CoefSot, CoefTotal, CoefSanatate, CoefPensie, 
	                      CoefSomaj, CoefCheltProf, CASAngajator, SanatateAngajator, SomajAngajator, FondRiscAngajator, CartiCameraMunca, CartiCamera, 
	                      CartiAngajator
	FROM         Coeficienti
	WHERE     (SetID = @SetID)


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE sal_GetImpozitarAnual
(
 @Suma money,
 @Data datetime,
 @CategorieID int
)
AS
select top 1 * 
from sal_Impozitar_anual
where @Suma between valmin and valmax
and   (data <= @Data) and (CategorieID=@CategorieID)
ORDER BY Data DESC

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE sal_GetImpozitarAnualById
(
 @ImpozitarID int
)
AS
select *
from sal_Impozitar_anual
where ImpozitarID=@ImpozitarID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE sal_GetLunaActiva
(
@AngajatorID int
)
AS
	SELECT     * from Sal_luni where Activ=1 and AngajatorID = @AngajatorID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE sal_GetLunaInflById 
(@LunaId int)
AS
select * from sal_Luni where LunaID=@LunaId

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE sal_GetLuni
(
@AngajatorID int
)
AS

select Sal_Luni.*, (Luni_Text.denumire + ' ' + CAST(Year(Sal_luni.Data) as nvarchar)) as Denumire from Sal_luni
		 left join Luni_Text on Luni_text.LunaTextID=Month(Sal_luni.Data)
		  where AngajatorID = @AngajatorID order by Data Desc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Autor:Muntean Raluca Cristina
--returneaza procentele de inflatie pe trimestrul anterior
--aceasta procedura este apelata numai dupa verificarea faptului ca in luna activa
--se incheie un trimestru, adica este una din lunile:1,4,7 sau 10 
CREATE PROCEDURE dbo.sal_GetProcInflTrim

AS
SELECT TOP 3 ProcentInflatie
FROM Sal_Luni
WHERE Activ=0
ORDER BY Data desc

RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
*	Author: Ionel Popa
*	Description: Insereaza procentul de cheltuieli personale si deducerile personale in tabela ParametriImpozitAnual
*	Params: cheltuielile profesionale, deducerile personale si anul
*/

CREATE PROCEDURE dbo.sal_InsertCheltuileiDeduceri
(
	@CheltuieliProfesionale nvarchar(15),
	@DeduceriPersonale int,
	@An int
)
AS
	-- stergem ultimele valori
	delete from ParametriImpozitAnual where An = @An

	-- inseram pe cele noi
	insert into ParametriImpozitAnual ( CheltuieliProfesionale, Deduceri, An)
	values ( cast( @CheltuieliProfesionale as float), @DeduceriPersonale , @An)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE sal_InsertCoef

	(
		@DeLa datetime,
		@Deducere money,
		@CoefInvalidGrd1 decimal(18,2),
		@CoefInvalidGrd2 decimal(18,2),
		@CoefCopil12 decimal(18,2),
		@CoefCopil3 decimal(18,2),
		@CoefUrmCopil decimal(18,2),
		@CoefSot decimal(18,2),
		@CoefTotal decimal(18,2),
		@CoefSanatate decimal(18,2),
		@CoefPensie decimal(18,2),
		@CoefSomaj decimal(18,2),
		@CoefCheltProf decimal(18,2),
		@CASAngajator decimal(18,2),
		@SanatateAngajator decimal(18,2),
		@SomajAngajator decimal(18,2),
		@FondRiscAngajator decimal(18,2),
		@CartiCameraMunca bit,
		@CartiCamera decimal(18,2),
		@CartiAngajator decimal(18,2),
		@SetID int OUTPUT	
	)

AS
	INSERT INTO Coeficienti
	                      (DeLa, Deducere, CoefInvalidGrd1, CoefInvalidGrd2, CoefCopil12, CoefCopil3, CoefUrmCopil, CoefSot, CoefTotal, CoefSanatate, CoefPensie, CoefSomaj, 
	                      CoefCheltProf, CASAngajator, SanatateAngajator, SomajAngajator, FondRiscAngajator, CartiCameraMunca, CartiCamera, CartiAngajator)
	VALUES     (@DeLa, @Deducere, @CoefInvalidGrd1, @CoefInvalidGrd2, @CoefCopil12, @CoefCopil3, @CoefUrmCopil, @CoefSot, @CoefTotal, @CoefSanatate, 
	                      @CoefPensie, @CoefSomaj, @CoefCheltProf, @CASAngajator, @SanatateAngajator, @SomajAngajator, @FondRiscAngajator, @CartiCameraMunca, 
	                      @CartiCamera, @CartiAngajator)
    SET @SetID = @@IDENTITY

	IF @@ERROR > 0
		BEGIN
		RAISERROR ('Insert Coeficienti esuat', 16, 1)
		RETURN 99
		END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.sal_InsertContributiiAngajator

	(
		@LunaID int,
		@AngajatorID int,
		@CentruCostID int,
		@CASAngajator money,
		@SanatateAngajator money,
		@SomajAngajator money,
		@FondRiscAngajator money,
		@CameraMuncaAngajator money,
		@SolidaritHandicap money,
		@ID int OUTPUT
	)

AS
delete from sal_Angajator
where (AngajatorID = @AngajatorID) AND (LunaID = @LunaID)

	INSERT INTO sal_Angajator
	                      (LunaID, AngajatorID, CentruCostID, CASAngajator, SanatateAngajator, SomajAngajator, FondRiscAngajator, CameraMuncaAngajator, SolidaritHandicap)
	VALUES     (@LunaID, @AngajatorID, @CentruCostID, @CASAngajator, @SanatateAngajator, @SomajAngajator, @FondRiscAngajator, @CameraMuncaAngajator, 
	                      @SolidaritHandicap)
	SET @ID = @@IDENTITY
	

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE sal_InsertImpozitarAnual

	(
		@ValMin money,
		@ValMax money,
		@Suma money,
		@Procent decimal(18,2),
		@Data datetime,
		@CategorieID int,
		@SetID int OUTPUT	
	)

AS
	INSERT INTO sal_Impozitar_anual
		     (ValMin,ValMax,Suma,Procent,Data,CategorieID)
	VALUES    (@ValMin,@ValMax,@Suma,@Procent,@Data,@CategorieID)
    SET @SetID = @@IDENTITY

	IF @@ERROR > 0
		BEGIN
		RAISERROR ('Insert esuat', 16, 1)
		RETURN 99
		END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO




CREATE PROCEDURE sal_InsertUpdateDeleteLuna
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@LunaID int,
	@Data datetime,
	@Activ bit,
	@AngajatorID int,
	@ProcentInflatie float,
	@rc int out

	

	
)

as
set @rc = 0




begin tran IUDLuna

if(@tip_actiune = 0)
begin	--Insert 
	

	insert into sal_Luni with(xlock) 

	(

	Data,
	Activ,
	AngajatorID,
	ProcentInflatie	

	) 
	values  
	(
	@Data,
	@Activ,
	@AngajatorID,
	@ProcentInflatie	

	) 
	if(@@ERROR <> 0)
	begin
		rollback tran IUDLuna
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDLuna
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	
	DECLARE @ProcInfl nvarchar(6)
	SET @ProcInfl=CAST(@ProcentInflatie AS nvarchar(6))
	update sal_Luni  with(xlock) set 

	Data=@Data,
	Activ = @Activ,
	ProcentInflatie=CAST(@ProcInfl AS float)

		
	where  (LunaID = @LunaID and AngajatorID=@AngajatorID)
		
	if(@@ERROR <> 0)
	begin
		rollback tran IUDLuna
		set @rc = @@ERROR
	end
	else
	begin
		commit tran  IUDLuna
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	
	delete from sal_Luni with(xlock) where LunaID = @LunaID
	if(@@ERROR <> 0)
	begin
		rollback tran  IUDLuna
		set @rc = @@ERROR
	end
	else
	begin
		commit tran  IUDLuna
		set @rc = 0
	end
end
else
	rollback tran IUDLuna

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE sal_UpdateCoef
	(
		@SetID int,
		@DeLa datetime,
		@Deducere money,
		@CoefInvalidGrd1 decimal(18,2),
		@CoefInvalidGrd2 decimal(18,2),
		@CoefCopil12 decimal(18,2),
		@CoefCopil3 decimal(18,2),
		@CoefUrmCopil decimal(18,2),
		@CoefSot decimal(18,2),
		@CoefTotal decimal(18,2),
		@CoefSanatate decimal(18,2),
		@CoefPensie decimal(18,2),
		@CoefSomaj decimal(18,2),
		@CoefCheltProf decimal(18,2),
		@CASAngajator decimal(18,2),
		@SanatateAngajator decimal(18,2),
		@SomajAngajator decimal(18,2),
		@FondRiscAngajator decimal(18,2),
		@CartiCameraMunca bit,
		@CartiCamera decimal(18,2),
		@CartiAngajator decimal(18,2)	
	)

AS
	UPDATE    Coeficienti
	SET              DeLa = @DeLa, Deducere = @Deducere, CoefInvalidGrd1 = @CoefInvalidGrd1, CoefInvalidGrd2 = @CoefInvalidGrd2, CoefCopil12 = @CoefCopil12, 
	                      CoefCopil3 = @CoefCopil3, CoefUrmCopil = @CoefUrmCopil, CoefSot = @CoefSot, CoefTotal = @CoefTotal, CoefSanatate = @CoefSanatate, 
	                      CoefPensie = @CoefPensie, CoefSomaj = @CoefSomaj, CoefCheltProf = @CoefCheltProf, CASAngajator = @CASAngajator, 
	                      SanatateAngajator = @SanatateAngajator, SomajAngajator = @SomajAngajator, FondRiscAngajator = @FondRiscAngajator, 
	                      CartiCameraMunca = @CartiCameraMunca, CartiCamera = @CartiCamera, CartiAngajator = @CartiAngajator
	                      WHERE SetID=@SetID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE sal_UpdateImpozitarAnual
(
	@ImpozitarID int,
	@ValMin money,
	@ValMax money,
	@Suma money,
	@Procent decimal(18,2),
	@Data datetime,
	@CategorieID int
)

AS
	UPDATE    sal_Impozitar_anual
	SET      ValMin=@ValMin,
		ValMax=@ValMax,        
		Suma=@Suma,
		Procent=@Procent,
		Data=@Data,
		CategorieID=@CategorieID
           WHERE ImpozitarID=@ImpozitarID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.salarii_GetInflatii

AS

SELECT     LunaID, Data, ProcentInflatie
FROM         Sal_luni

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.salarii_GetInvaliditati

	(
		@InvaliditateID int
		
	)

AS
	SELECT     InvaliditateID, Nume, Descriere, Coeficient
	FROM         Invaliditati
	WHERE     (InvaliditateID = @InvaliditateID) 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.salarii_InsertInflatii

	(
		@data datetime,
		@procent numeric
	)

AS
	INSERT INTO sal_luni
	                      (Data, ProcentInflatie, Activ)
	VALUES     (@data, @procent, 1)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.salarii_updateInflatii

	(
		@luna int,
		@procent numeric
	)

AS
UPDATE    Sal_luni
SET              ProcentInflatie = @procent
WHERE     (LunaID = @luna)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
   Autor: Cristina Muntean
   Data: 23.02.2005
   Nume: spCalculIndemnizatieConcediuMedicalAngajat
   Descriere: Calculeaza indemnizatia de concediu medical a angajatului cu id-ul @AngajatID
   Date de intrare: date concediu medical
   Date iesire:indemnizatie concediu medical pentru angajat
   Formula de calcul:
   indemnizatieConcediuMedical = mediaZilnica * zileLucratoareDeConcediuDeBoala * %boala
*/
CREATE PROCEDURE spCalculIndemnizatieConcediuMedicalAngajat
(
	--parametrii de intrare
	@AngajatID int, --id-ul angajatului
	@LunaID int, --id-ul lunii
	@CodAbsenta nvarchar(5), --codul absentei(in acest caz trebuie sa fie concediu medical)
		
	--parametru de iesire
	@IndemnizatieConcediuMedical money OUTPUT 
)

AS
 DECLARE @DataCurenta datetime
 --este setata data curenta in functie de id-ul lunii primit ca parametru --> @LunaID
 --data curenta a lunii este alcatuita din  lunaCurenta/primaZiALunii/anulCurent
 SET @DataCurenta = (SELECT Data
                     FROM Sal_Luni
                     WHERE LunaID=@LunaID)

--data de sfarsit a lunii
DECLARE @DataEndLuna datetime
--este setata ultima zi a lunii curente
SET @DataEndLuna = DATEADD(dd, - DAY(DATEADD(mm, 1, @DataCurenta)), DATEADD(mm, 1, @DataCurenta))


-- se creeaza o tabela temporara in care vom retine numarul de zile lucratoare dintr-un anumit interval de absenta si
--media zilnica pentru angajat(=baza de calcul a indemnizatiei de incapacitate temporara de munca)
CREATE TABLE #NrZileLucratoare
(
	Contor int IDENTITY (1, 1) NOT NULL,
	IntervalAbsentaID int,
	NrZileLucratoare int,
	MedieZilnica money
)

--sunt inserate in tabela id-ul intervalului si numarul de zile lucratoare din interval
  INSERT INTO #NrZileLucratoare (IntervalAbsentaID,NrZileLucratoare,MedieZilnica)
  SELECT tm_IntervaleAbsenta.IntervalAbsentaID,tm_IntervaleAbsenta.MedieZilnica, 
		(SELECT COUNT(*) AS NrZile
           FROM   tm_zile
           WHERE  (tm_Zile.Sarbatoare=0)  AND
                  (@DataCurenta <= tm_zile.Data) AND 
			    (tm_zile.Data <=@DataEndLuna)AND
			      (tm_IntervaleAbsenta.DataStart <= tm_zile.Data) AND 
			      (tm_zile.Data <= tm_IntervaleAbsenta.DataEnd) AND
			     (
				 ( 
				  DATEPART(mm, tm_IntervaleAbsenta.DataStart) = MONTH(@DataCurenta) AND 
				  DATEPART(yy, tm_IntervaleAbsenta.DataStart) = YEAR(@DataCurenta) 
				 ) 
				 OR
				 (
			  	  DATEPART(mm, tm_IntervaleAbsenta.DataEnd) = MONTH(@DataCurenta) AND 
				  DATEPART(yy, tm_IntervaleAbsenta.DataEnd) = YEAR(@DataCurenta)
				 )
				)
		 )AS NrZile
FROM   tm_IntervaleAbsenta INNER JOIN
                      tm_TipAbsente ON tm_IntervaleAbsenta.TipAbsentaID = tm_TipAbsente.TipAbsentaID
WHERE tm_IntervaleAbsenta.AngajatID=@AngajatID AND tm_TipAbsente.CodAbsenta=@CodAbsenta AND
		(
		(DATEPART(mm, tm_IntervaleAbsenta.DataStart) = MONTH(@DataCurenta) AND 
		DATEPART(yy, tm_IntervaleAbsenta.DataStart) = YEAR(@DataCurenta)
		) 
		OR
		(
		DATEPART(mm, tm_IntervaleAbsenta.DataEnd) = MONTH(@DataCurenta) AND 
		DATEPART(yy, tm_IntervaleAbsenta.DataEnd) = YEAR(@DataCurenta)
		)
		)
  ORDER BY tm_IntervaleAbsenta.IntervalAbsentaID
 
 
--numarul de randuri ale tabelei temporare
DECLARE @NrRanduri int
--se calculeaza numarul de randuri ale tabelei
SET @NrRanduri = (SELECT COUNT(*) AS Nr
				 FROM #NrZileLucratoare)

--daca angajatul a avut cel putin un concediu medical atunci se calculeaza indemnatia de concediu medical 
if (@NrRanduri>0)  
	--este calculata indemnizatia de concediu medical dupa formula: 
	--indemnizatieConcediuMedical = mediaZilnica * zileLucratoareDeConcediuDeBoala * %boala                    
	SET @IndemnizatieConcediuMedical = (SELECT SUM(#NrZileLucratoare.MedieZilnica * #NrZileLucratoare.NrZileLucratoare * (Boli.Procent / 100)) AS IndemnizatieConcediuMed
										FROM tm_IntervaleAbsenta INNER JOIN
											Boli ON tm_IntervaleAbsenta.BoalaID = Boli.BoalaID INNER JOIN
											tm_TipAbsente ON tm_IntervaleAbsenta.TipAbsentaID = tm_TipAbsente.TipAbsentaID INNER JOIN
											#NrZileLucratoare ON tm_IntervaleAbsenta.IntervalAbsentaID=#NrZileLucratoare.IntervalAbsentaID
										WHERE tm_IntervaleAbsenta.AngajatID = @AngajatID AND 
											tm_TipAbsente.CodAbsenta=@CodAbsenta AND
											(
											(DATEPART(mm, tm_IntervaleAbsenta.DataStart) = MONTH(@DataCurenta) AND 
											DATEPART(yy, tm_IntervaleAbsenta.DataStart) = YEAR(@DataCurenta)
											) 
											OR
											(
											DATEPART(mm, tm_IntervaleAbsenta.DataEnd) = MONTH(@DataCurenta) AND 
											DATEPART(yy, tm_IntervaleAbsenta.DataEnd) = YEAR(@DataCurenta)
											)
											) )
--daca angajatul nu a avut nici un concediu medical atunci este setata valoarea indemnizatiei de concediu medical la 0											
else
	SET @IndemnizatieConcediuMedical = 0

 RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:	Dovlecel Vlad
* Nume:			InsertUpdateDeleteIntervalAngajat
* Data:	Adauga, modifica, sterge o inregistrare in tabelul tm_IntervaleAngajat
*/
CREATE PROCEDURE tm_DeleteDefinitivIntervaleAngajatPerioadaTemporar

as

declare @rc int
set @rc = 0

begin tran IUDIntervalAngajat

delete from tm_IntervaleAngajat with(xlock) 
	where Deleted=1


if(@@ERROR <> 0)
begin
	rollback tran IUDIntervalAngajat
	set @rc = @@ERROR
end
else
begin
	commit tran IUDIntervalAngajat
	set @rc = 0
end

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:	Dovlecel Vlad
* Nume:			tm_DeleteIntervaleTipAngajatPerioada
* Data:	sterge toate inregistrarile din tabelul tm_IntervaleAngajat, specifice unui angajat, de un anumit tip si care se incadreaza intr-un interval
*/
CREATE PROCEDURE tm_DeleteIntervaleTipAngajatPerioada
(
	@DataStart DateTime,
	@DataEnd DateTime,
	@AngajatID int,
	@TipIntervalID int
)

as

declare @rc int
set @rc = 0

begin tran IUDIntervalAngajat

delete from tm_IntervaleAngajat with(xlock) 
where AngajatID=@AngajatID and
	@DataStart<=Data and
	Data<=@DataEnd and
	CapatInterval=0 and 
	TipIntervalID=@TipIntervalID

if(@@ERROR <> 0)
begin
	rollback tran IUDIntervalAngajat
	set @rc = @@ERROR
end
else
begin
	commit tran IUDIntervalAngajat
	set @rc = 0
end

return @rc
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:	Dovlecel Vlad
* Nume:			InsertUpdateDeleteIntervalAngajat
* Data:	Adauga, modifica, sterge o inregistrare in tabelul tm_IntervaleAngajat
*/
CREATE PROCEDURE tm_DeleteIntervaleVizibileAngajatPerioada
(
	@DataStart DateTime,
	@DataEnd DateTime,
	@AngajatID int
)

as

delete from tm_IntervaleAngajat with(xlock) 
where AngajatID=@AngajatID and
	@DataStart<=Data and
	Data<=@DataEnd and
	CapatInterval=0 and 
	Deleted=0
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


--Author: Dovlecel Vlad
CREATE PROCEDURE tm_DeleteSchimbareAngajat
(
	@AngajatID int,
	@DataStart datetime,
	@DataEnd datetime,
	
	@ProgramLucru int,
	@SalariuBaza money,
	@IndemnizatieConducere money,
	@Invaliditate smallint,
	@CategorieID int
)

 AS

update tm_IntervaleAngajat 

set ProgramLucru=@ProgramLucru, SalariuBaza=@SalariuBaza, IndemnizatieConducere=@IndemnizatieConducere, Invaliditate=@Invaliditate, CategorieID=@CategorieID

where @DataStart<=Data and Data<=@DataEnd and AngajatID=@AngajatID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetAngajatNrOreTipLucrate
(
@AngajatID int,
@DescriereInterval nvarchar (255) = '', 
@DataStart datetime,
@DataEnd datetime
)

AS

select * 

from tm_IntervaleAngajat tm_ia inner join tm_TipIntervale tm_ta on tm_ia.TipIntervalID = tm_ta.TipIntervalID

--where AngajatID = @AngajatID and patindex( Denumire, @DescriereInterval ) != 0 and @DataStart <= Data and Data <= @DataEnd
--where AngajatID = @AngajatID and Denumire = @DescriereInterval and @DataStart <= Data and Data <= @DataEnd and CapatInterval=0
where AngajatID = @AngajatID and Denumire = @DescriereInterval and @DataStart <= Data and Data <= @DataEnd and CapatInterval=0 and Deleted=0

order by OraStart

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetAngajatZileOreTipLucratePerioada
(
@AngajatID int,
@DataStart datetime,
@DataEnd datetime,
@TipIntervalID int
)

AS

select Data 
from tm_IntervaleAngajat
where AngajatID = @AngajatID and @DataStart <= Data and Data <= @DataEnd and TipIntervalID=@TipIntervalID and CapatInterval=0 and Deleted=0
group by  Data
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


--Author: Dovlecel Vlad
CREATE PROCEDURE tm_GetCapatIntervalAngajatZi
(
	@AngajatID int,
	@Data datetime	
)
AS

select * 

from tm_IntervaleAngajat

where AngajatID=@AngajatID and Data=@Data and CapatInterval=1

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.tm_GetCodBoala
(
	@BoalaID int
)

AS

Select * From Boli Where BoalaID=@BoalaID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.tm_GetIntervaleLucratePerioada
(
	@AngajatID int,
	@DataStart DateTime,
	@DataEnd Datetime
)

AS

select *
from tm_IntervaleAngajat
--where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd and CapatInterval=0
where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd and CapatInterval=0 and Deleted=0
Order by Data, OraStart
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetIntervaleTipZi

(
@AngajatID int,
@TipIntervalID int, 
@Data datetime

)

AS

	select * from tm_IntervaleAngajat where Data=@Data and AngajatID = @AngajatID and TipIntervalID = @TipIntervalID and CapatInterval=0  and Deleted=0
	order by OraStart

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetIntervaleZi

(
@AngajatID int,
@Data datetime
)

AS

	select * from tm_IntervaleAngajat where Data=@Data and AngajatID = @AngajatID and CapatInterval=0 and Deleted=0
	order by OraStart

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetLuna 

(
	@LunaID int
)

AS

select * from sal_Luni 

where LunaID = @LunaID

order by Data asc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetNrOreTipPerioada
(
	@AngajatID int,
	@DataStart datetime,
	@DataEnd datetime,
	@TipOre int-- -1 - toate tipurile de ore, altfel ID-ul tipului de ore
)

AS

/*if( @TipOre = -1 )
	select Sum( DatePart( hh, OraEnd )-DatePart( hh, OraStart )) as NrOre
	from tm_IntervaleAngajat
	where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd
else
	select Sum( DatePart( hh, OraEnd )-DatePart( hh, OraStart )) as NrOre
	from tm_IntervaleAngajat
	where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd and TipIntervalID=@TipOre
*/

if( @TipOre = -1 )
	select Sum( DateDiff( mi, OraStart, OraEnd )) as NrMinute
	from tm_IntervaleAngajat
	where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd
else
	select Sum( DateDiff( mi, OraStart, OraEnd )) as NrMinute
	from tm_IntervaleAngajat
	where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd and TipIntervalID=@TipOre

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetNrOreTipPerioadaFaraInterval
(
	@AngajatID int,
	@DataStart datetime,
	@DataEnd datetime,
	@TipOre int,-- -1 - toate tipurile de ore, altfel ID-ul tipului de ore
	@IntervalID int
)

AS

/*if( @TipOre = -1 )
	select Sum( DatePart( hh, OraEnd )-DatePart( hh, OraStart )) as NrOre
	from tm_IntervaleAngajat
	where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd
else
	select Sum( DatePart( hh, OraEnd )-DatePart( hh, OraStart )) as NrOre
	from tm_IntervaleAngajat
	where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd and TipIntervalID=@TipOre
*/

if( @TipOre = -1 )
	select Sum( DateDiff( mi, OraStart, OraEnd )) as NrMinute
	from tm_IntervaleAngajat
	where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd and IntervalAngajatID<>@IntervalID
else
	select Sum( DateDiff( mi, OraStart, OraEnd )) as NrMinute
	from tm_IntervaleAngajat
	where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd and TipIntervalID=@TipOre and IntervalAngajatID<>@IntervalID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetSetareInfo

(
@Cheie nvarchar(255)

)

AS

	select * from tm_Setari  where Cheie = @Cheie

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.tm_GetTipInterval
(
	@TipIntervalID int
)

AS

select *

from tm_TipIntervale

where TipIntervalID = @TipIntervalID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.tm_GetTipIntervalAbsenta
(
@TipAbsentaID int
)

AS

select *

from tm_TipAbsente

where TipAbsentaID = @TipAbsentaID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetTipuriAbsente


AS

	select * from tm_TipAbsente

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetTipuriIntervale


AS

select * 

from tm_TipIntervale

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetTipuriIntervaleSuplimentare


AS

select * 
from tm_TipIntervale
where Standard=0 and Folosire=1
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetZiAngajatInfo
(
	@Data datetime,
	@AngajatID int
)

AS

select * 

from tm_IntervaleAngajat

--where Data=@Data and AngajatID=@AngajatID  and CapatInterval=0
where Data=@Data and AngajatID=@AngajatID  and CapatInterval=0 and Deleted=0

order by OraStart

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetZiDetaliu
(
	@Data datetime
)

AS

select *

from tm_zile

where Data=@Data

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetZiIntervalApartenentaInfo
(
	@Data datetime,
	@AngajatID int
)

AS

select * 

from tm_IntervaleAngajat

--where Data<=@Data and AngajatID=@AngajatID --and CapatInterval=0
where Data<=@Data and AngajatID=@AngajatID and Deleted=0

order by Data desc, OraStart desc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE PROCEDURE dbo.tm_GetZileLucratoareLuna
(
@Luna int,
@An int
)

AS


select * from tm_zile where datepart(mm,Data)=@Luna and datepart(yy,Data)=@An and Sarbatoare = 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE PROCEDURE tm_GetZileLucratoarePerioada
(
@DataStart datetime,
@DataEnd datetime
)

AS


select * 

from tm_zile 

where @DataStart<=Data and Data<=@DataEnd and 
	Sarbatoare = 0

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE PROCEDURE dbo.tm_GetZileLuna
(
@Luna int,
@An int--,
--@DataInceput datetime
)

AS


select * from tm_zile where datepart(mm,Data)=@Luna and datepart(yy,Data)=@An
/*select * 

from tm_zile 

where datepart(mm,Data)=@Luna and datepart(yy,Data)=@An and
	Data>=@DataInceput*/

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE PROCEDURE dbo.tm_GetZileLunaAngajat
(
@Luna int,
@An int,
@DataInceput datetime
)

AS

select * 

from tm_zile 

where datepart(mm,Data)=@Luna and datepart(yy,Data)=@An and
	Data>=@DataInceput
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.tm_GetZileLunaImposibile
(
@Luna int,
@An int,
@DataExpirare datetime --expirare contract munca
)

AS

select * 

from tm_zile 

where datepart(mm,Data)=@Luna and
	datepart(yy,Data)=@An and
	Data>@DataExpirare

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE tm_GetZileLunaIntrerupereContract
(
@DataStart datetime,
@DataEnd datetime
)

AS

select * 

from tm_zile 

where @DataStart<=Data and Data<=@DataEnd

order by Data

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE PROCEDURE dbo.tm_GetZileLunaPosibile
(
@Luna int,
@An int,
@DataExpirare datetime, --expirare contract munca
@DataInceput datetime
)

AS

/*select * 

from tm_zile 

where datepart(mm,Data)=@Luna and
	datepart(yy,Data)=@An and
	Data<@DataExpirare*/

select * 

from tm_zile 

where datepart(mm,Data)=@Luna and
	datepart(yy,Data)=@An and
	Data<@DataExpirare and
	Data>=@DataInceput

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE PROCEDURE dbo.tm_GetZileSarbatoareInterval
(
@DataStart datetime,
@DataEnd datetime
)

AS

select * 

from tm_zile 

where @DataStart <= Data and Data <= @DataEnd and Sarbatoare = 1

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




CREATE PROCEDURE tm_GetZileWeekendPosibileLunaAngajat
(
@Luna int,
@An int,
@DataInceput datetime,
@DataSfarsit datetime
)

AS

select * 

from tm_zile z

where datepart(mm,Data)=@Luna and datepart(yy,Data)=@An and
	@DataInceput<=Data and Data<=@DataSfarsit and Sarbatoare=1
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteIntervalAngajat
* Data:	Adauga, modifica, sterge o inregistrare in tabelul tm_IntervaleAngajat
*/
CREATE PROCEDURE tm_InsertUpdateDeleteCapatIntervalAngajat
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@IntervalAngajatID int,
	@Data datetime,
	@TipIntervalID int,
	@OraStart DateTime,
	@OraEnd DateTime,
	@AngajatID int,
	@ProgramLucru int,
	@SalariuBaza money = 0,
	@IndemnizatieConducere money = 0,
	@Invaliditate smallint,
	@CategorieID int
)

as

declare @rc int
set @rc = 0

begin tran IUDIntervalAngajat

if(@tip_actiune = 0)
begin	--Insert IntervalAngajat
	insert into tm_IntervaleAngajat with(xlock) (Data,TipIntervalID,OraStart,OraEnd,AngajatID,ProgramLucru,SalariuBaza,IndemnizatieConducere,Invaliditate,CategorieID,CapatInterval) 
		values  (@Data,@TipIntervalID,@OraStart,@OraEnd,@AngajatID,@ProgramLucru,@SalariuBaza,@IndemnizatieConducere,@Invaliditate,@CategorieID,1) 
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIntervalAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIntervalAngajat
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update Zi
	update tm_IntervaleAngajat  with(xlock) set TipIntervalID = @TipIntervalID,OraStart=@OraStart,OraEnd=@OraEnd,ProgramLucru=@ProgramLucru,SalariuBaza=@SalariuBaza,IndemnizatieConducere=@IndemnizatieConducere,Invaliditate=@Invaliditate,CategorieID=@CategorieID
		where  IntervalAngajatID = @IntervalAngajatID
		
	if(@@ERROR <> 0)
	begin
		rollback tran IUDZi
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDZi
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete IntervalAngajat
	delete from tm_IntervaleAngajat with(xlock) where IntervalAngajatID = @IntervalAngajatID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIntervalAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIntervalAngajat
		set @rc = 0
	end
end
else
	rollback tran IUDIntervalAngajat

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteIntervalAngajat
* Data:	Adauga, modifica, sterge o inregistrare in tabelul tm_IntervaleAngajat
*/
CREATE PROCEDURE tm_InsertUpdateDeleteIntervalAngajat
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@IntervalAngajatID int,
	@Data datetime,
	@TipIntervalID int,
	@OraStart DateTime,
	@OraEnd DateTime,
	@AngajatID int,
	@ProgramLucru int,
	@SalariuBaza money = 0,
	@IndemnizatieConducere money = 0,
	@Invaliditate smallint,
	@CategorieID int
)

as

declare @rc int
set @rc = 0

begin tran IUDIntervalAngajat

if(@tip_actiune = 0)
begin	--Insert IntervalAngajat
	insert into tm_IntervaleAngajat with(xlock) (Data,TipIntervalID,OraStart,OraEnd,AngajatID,ProgramLucru,SalariuBaza,IndemnizatieConducere,Invaliditate,CategorieID) 
		values  (@Data,@TipIntervalID,@OraStart,@OraEnd,@AngajatID,@ProgramLucru,@SalariuBaza,@IndemnizatieConducere,@Invaliditate,@CategorieID) 
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIntervalAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIntervalAngajat
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update Zi
	update tm_IntervaleAngajat  with(xlock) set TipIntervalID = @TipIntervalID,OraStart=@OraStart,OraEnd=@OraEnd,ProgramLucru=@ProgramLucru,SalariuBaza=@SalariuBaza,IndemnizatieConducere=@IndemnizatieConducere,Invaliditate=@Invaliditate,CategorieID=@CategorieID
		where  IntervalAngajatID = @IntervalAngajatID
		
	if(@@ERROR <> 0)
	begin
		rollback tran IUDZi
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDZi
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete IntervalAngajat
	delete from tm_IntervaleAngajat with(xlock) where IntervalAngajatID = @IntervalAngajatID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIntervalAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIntervalAngajat
		set @rc = 0
	end
end
else
	rollback tran IUDIntervalAngajat

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteZi
* Data:	Adauga, modifica, sterge o inregistrare in tabelul tm_Zile
*/
CREATE PROCEDURE tm_InsertUpdateDeleteSetare
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@Cheie nvarchar(255) ,
	@Valoare nvarchar(255) 
)

as

declare @rc int
set @rc = 0

begin tran IUDSetare

if(@tip_actiune = 0)
begin	--Insert Setare
	insert into tm_Setari with(xlock) (Cheie,Valoare) 
		values (@Cheie,@Valoare)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDSetare
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDSetare
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update Setare
	update tm_Setari with(xlock) set Valoare=@Valoare where Cheie=@Cheie
		
	if(@@ERROR <> 0)
	begin
		rollback tran IUDSetare
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDSetare
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete Setare
	delete from tm_Setari with(xlock) where Cheie = @Cheie
	if(@@ERROR <> 0)
	begin
		rollback tran IUDSetare
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDSetare
		set @rc = 0
	end
end
else
	rollback tran IUDSetare

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteTipAbsenta
* TipAbsentaID:	Adauga, modifica, sterge o inregistrare in tabelul tm_TipAbsente
*/
CREATE PROCEDURE tm_InsertUpdateDeleteTipAbsenta
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@TipAbsentaID int,
	@Procent float,
	@Denumire nvarchar(255), 
	@Descriere ntext = null,
	@CodAbsenta nvarchar(5),
--	@BoalaID int,
	@Medical bit = 0,
	@Modificare bit = 0,
	@Folosire bit = 1,
	@Lucratoare bit = 0
)

as

declare @rc int
set @rc = 0

begin tran IUDTipAbsenta

if(@tip_actiune = 0)
begin	--Insert TipAbsenta
/*	insert into tm_TipAbsente with(xlock) (Procent,Denumire,Descriere,Medical,CodAbsenta,BoalaID) 
		values (@Procent,@Denumire,@Descriere,@Medical,@CodAbsenta,@BoalaID)*/
	insert into tm_TipAbsente with(xlock) (Procent,Denumire,Descriere,Medical,CodAbsenta,Modificare,Folosire,Lucratoare) 
		values (@Procent,@Denumire,@Descriere,@Medical,@CodAbsenta,@Modificare,@Folosire,@Lucratoare)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTipAbsenta
		set @rc = @@ERROR
	end
	else begin
		commit tran IUDTipAbsenta
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update TipAbsenta
	/*update tm_TipAbsente with(xlock) set Procent=@Procent,Denumire=@Denumire,Descriere=@Descriere, Medical=@Medical, CodAbsenta=@CodAbsenta,BoalaID=@BoalaID 
		where TipAbsentaID=@TipAbsentaID*/
	update tm_TipAbsente with(xlock) set Procent=@Procent,Denumire=@Denumire,Descriere=@Descriere, Medical=@Medical, CodAbsenta=@CodAbsenta, Modificare=@Modificare, Folosire=@Folosire, Lucratoare=@Lucratoare
		where TipAbsentaID=@TipAbsentaID
		
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTipAbsenta
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTipAbsenta
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete TipAbsenta
	delete from tm_TipAbsente with(xlock) where TipAbsentaID = @TipAbsentaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTipAbsenta
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTipAbsenta
		set @rc = 0
	end
end
else
	rollback tran IUDTipAbsenta

return @rc
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteTipInterval
* TipIntervalID:	Adauga, modifica, sterge o inregistrare in tabelul tm_TipIntervale
*/
CREATE PROCEDURE tm_InsertUpdateDeleteTipInterval
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@TipIntervalID int,
	@Procent float,
	@Denumire nvarchar(255), 
	@Descriere ntext = null,
	@Standard bit = 0,
	@Modificare bit = 0,
	@Folosire bit = 1,
	@BonuriMasa bit = 0,
	@NrMaximOreSapt float = 0,
	@AplicWeekendNoapte bit = null
)

as

declare @rc int
set @rc = 0

begin tran IUDTipInterval

if(@tip_actiune = 0)
begin	--Insert TipInterval
	insert into tm_TipIntervale with(xlock) (Procent,Denumire,Descriere,Standard,Modificare,Folosire,BonuriMasa,NrMaximOreSapt, AplicWeekendNoapte) 
		values (@Procent,@Denumire,@Descriere,@Standard,@Modificare,@Folosire,@BonuriMasa,@NrMaximOreSapt, @AplicWeekendNoapte)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTipInterval
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTipInterval
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update TipInterval
	update tm_TipIntervale with(xlock) set Procent=@Procent,Denumire=@Denumire,Descriere=@Descriere, Standard=@Standard, Modificare=@Modificare, Folosire=@Folosire, BonuriMasa=@BonuriMasa, 
		NrMaximOreSapt=@NrMaximOreSapt, AplicWeekendNoapte=@AplicWeekendNoapte
		where TipIntervalID=@TipIntervalID
		
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTipInterval
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTipInterval
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete TipInterval
	delete from tm_TipIntervale with(xlock) where TipIntervalID = @TipIntervalID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDTipInterval
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDTipInterval
		set @rc = 0
	end
end
else
	rollback tran IUDTipInterval

return @rc
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteZi
* Data:	Adauga, modifica, sterge o inregistrare in tabelul tm_Zile
*/
CREATE PROCEDURE tm_InsertUpdateDeleteZi
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@Data datetime,
	@Sarbatoare bit,
	@Denumire nvarchar(255) = null,
	@Descriere ntext = null,
	@SetataAdmin bit
)

as

declare @rc int
set @rc = 0

begin tran IUDZi

if(@tip_actiune = 0)
begin	--Insert Zi
	insert into tm_Zile with(xlock) (Data,Sarbatoare,Denumire,Descriere,SetataAdmin) 
		values (@Data,@Sarbatoare,@Denumire,@Descriere,@SetataAdmin)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDZi
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDZi
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update Zi
	update tm_zile with(xlock) set SetataAdmin=@SetataAdmin,Sarbatoare=@Sarbatoare,Denumire=@Denumire,Descriere=@Descriere where Data=@Data
		
	if(@@ERROR <> 0)
	begin
		rollback tran IUDZi
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDZi
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete Zi
	delete from tm_zile with(xlock) where Data = @Data
	if(@@ERROR <> 0)
	begin
		rollback tran IUDZi
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDZi
		set @rc = 0
	end
end
else
	rollback tran IUDZi

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:	Dovlecel Vlad
* Nume:			tm_RestoreIntervaleAngajatPerioadaSterseTemporar
* Data:	Seteaza inapoi ca fiind folosibile, intervalele orare dintr-o anumita perioada
*/
CREATE PROCEDURE tm_RestoreIntervaleAngajatPerioadaSterseTemporar
(
	@DataStart DateTime,
	@DataEnd DateTime,
	@AngajatID int
)

as

declare @rc int
set @rc = 0

begin tran IUDIntervalAngajat


update tm_IntervaleAngajat with(xlock) set Deleted=0
	where AngajatID=@AngajatID and
		@DataStart<=Data and
		Data<=@DataEnd and
		CapatInterval=0

if(@@ERROR <> 0)
begin
	rollback tran IUDIntervalAngajat
	set @rc = @@ERROR
end
else
begin
	commit tran IUDIntervalAngajat
	set @rc = 0
end

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteZi
* Data:	Adauga, modifica, sterge o inregistrare in tabelul tm_Zile
*/
CREATE PROCEDURE tm_SetZiTipSarbatoare
(
	@Data datetime,
	@Sarbatoare bit
)

as

update tm_zile with(xlock) set Sarbatoare=@Sarbatoare where Data=@Data
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetAngajatorInfo 
	@AngajatorID int
 AS

	select Angajatori.* from Angajatori

	where Angajatori.AngajatorID = @AngajatorID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
 * Autor: Cristina Muntean
 * Nume: GetDomDeActivitateAngajator
 * Descriere: Returneaza toate detaliile despre domeniile de activitate ale angajatorului
  cu id-ul trimis ca parametru(AngajatorID)
*/
CREATE PROCEDURE GetDomDeActivitateAngajator
(
	@AngajatorID int
)
AS
SELECT     DomeniiDeActivitate.*,DomDeActivitateAngajator.Principal
FROM         Angajatori INNER JOIN
                      DomDeActivitateAngajator ON Angajatori.AngajatorID = DomDeActivitateAngajator.AngajatorID INNER JOIN
                      DomeniiDeActivitate ON DomDeActivitateAngajator.DomDeActivitateID = DomeniiDeActivitate.DomDeActivitateID
WHERE     (Angajatori.AngajatorID = @AngajatorID)

RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetInfoSalariiImpozite 
	
	@LunaID int
AS

	select Salarii_Impozite.*, Salarii_AplicareSumeImpozit.DenumireSuma from Salarii_Impozite
		left join Salarii_AplicareSumeImpozit on Salarii_AplicareSumeImpozit.AplicatLaID = Salarii_Impozite.AplicatLaID
	where Salarii_Impozite.LunaID=@LunaID
	order by Denumire

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


-- Author: Dovlecel Vlad
-- De modificat in viitor: cand se va modifica peste tot ca invaliditatile sa nu fie asociate implicit cu 0, 1, sau 2 (0-fara inv, 1-inv gr I, 2-inv gr II) se va modifica si linia:
--				inner join Invaliditati i on ia.Invaliditate=i.Cod 
-- cu 				inner join Invaliditati i on ia.Invaliditate=i.InvaliditateID
CREATE PROCEDURE GetIstoricSchimbariAngajat
(
	@AngajatID int
)

 AS

select *

from ( tm_IntervaleAngajat ia inner join Salarii_CategoriiAngajati ca on ia.CategorieID=ca.CategorieID ) 
	inner join Invaliditati i on ia.Invaliditate=i.InvaliditateID

where AngajatID=@AngajatID and 
	ProgramLucru<>null and
	SalariuBaza<>null and
	IndemnizatieConducere<>null and
	Invaliditate<>null and
	ia.CategorieID<>null

order by Data

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


-- Author: Dovlecel Vlad
-- De modificat in viitor: cand se va modifica peste tot ca invaliditatile sa nu fie asociate implicit cu 0, 1, sau 2 (0-fara inv, 1-inv gr I, 2-inv gr II) se va modifica si linia:
--				inner join Invaliditati i on ia.Invaliditate=i.Cod 
-- cu 				inner join Invaliditati i on ia.Invaliditate=i.InvaliditateID
CREATE PROCEDURE GetIstoricSchimbariLunaAngajat
(
	@AngajatID int,
	@DataStart datetime,
	@DataEnd datetime
)

 AS

select *

from ( tm_IntervaleAngajat ia inner join Salarii_CategoriiAngajati ca on ia.CategorieID=ca.CategorieID ) 
	inner join Invaliditati i on ia.Invaliditate=i.InvaliditateID

where AngajatID=@AngajatID and 
	@DataStart<=Data and Data<=@DataEnd and
	ProgramLucru<>null and
	SalariuBaza<>null and
	IndemnizatieConducere<>null and
	Invaliditate<>null and
	ia.CategorieID<>null

order by Data

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Muntean Raluca Cristina
--returneaza datele de identificare ale angajatorului 
CREATE PROCEDURE dbo.GetREP_aaaa
(
	@AngajatorID int
)
AS
SELECT     SUBSTRING(Angajatori.CUI_CNP, 2, 8) AS Cod_ang, Angajatori.Denumire, Judete.Nume AS Judet, Angajatori.Localitate, Angajatori.Strada, 
                      Angajatori.Numar AS Nr, Angajatori.Bloc, Angajatori.Scara, Angajatori.Apartament AS Ap, Angajatori.CodPostal AS Cod_postal, 
                      SUBSTRING(Angajatori.Telefon, 2, 10) AS Telefon, SUBSTRING(Angajatori.Fax, 2, 10) AS Fax, Angajatori.Email
FROM         Angajatori INNER JOIN
                      Judete ON Angajatori.JudetSectorID = Judete.JudetID
WHERE     (Angajatori.AngajatorID = @AngajatorID)
RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

--insereaza un angajator si returneaza id-ul angajatorului inserat
CREATE PROCEDURE InsertAngajatorWithIDReturn
(
	@Denumire nvarchar(100),
	@TipPersoana bit,
	@CUI_CNP nvarchar(25),
	@NrInregORC varchar(25)=NULL,
	@Telefon varchar(25),
	@Fax varchar(25),
	@PaginaWeb varchar(100)=NULL,
	@Email varchar(100)=NULL,
	@TaraID int,
	@JudetSectorID int,
	@Localitate nvarchar(50),
	@Strada nvarchar(50),	
	@Numar nvarchar(10),	
	@CodPostal nvarchar(20),	
	@Bloc nvarchar(5)=NULL,	
	@Scara nvarchar(5)=NULL,	
	@Etaj nvarchar(5)=NULL,	
	@Apartament nvarchar(5)=NULL,
	@ZiLichidareSalar nvarchar(2),
	@AngajatorID int=-1 OUTPUT	
)
AS
declare @rc int
set @rc = 0


--insert angajator
begin tran IUDAngajatori
	insert into Angajatori with(xlock) (Denumire, TipPersoana, CUI_CNP, NrInregORC, Telefon, Fax, PaginaWeb, Email, TaraID, JudetSectorID,
		 Localitate, Strada, Numar, CodPostal, Bloc, Scara, Etaj, Apartament, ZiLichidareSalar) 
		values (@Denumire, @TipPersoana, @CUI_CNP, @NrInregORC, @Telefon, @Fax, @PaginaWeb, @Email, @TaraID, @JudetSectorID,
		 @Localitate, @Strada, @Numar, @CodPostal, @Bloc, @Scara, @Etaj, @Apartament, @ZiLichidareSalar)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDAngajatori
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDAngajatori
		set @AngajatorID = @@IDENTITY 
		set @rc = 0
	end

RETURN @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE InsertUpdateConcediuMedicZilePlatite
(
	@tip_actiune int,
	@id_Criteriu int,
	@ValMinimAngajati int,
	@ValMaximAngajati int, 
	@NrZilePlatite int
)
/*
	(
		0-insert
		1-update
		2-delete
	)
*/
AS

declare @rc int
declare @id int
declare @verif int
set @rc = 0
set @id=@ValMaximAngajati
set @verif=0
exec @verif=CheckInsertConcediiMedic @ValMinimAngajati,@ValMinimAngajati
begin tran UIConcediuMedicZilePlatite
if(@tip_actiune = 0)
begin
if(@verif=0)
	begin
		insert into ConcediuMedicZilePlatite with(xlock) (id_Criteriu, ValMinimAngajati ,ValMaximAngajati,NrZilePlatite) 
			values (@id, @ValMinimAngajati ,@ValMaximAngajati,@NrZilePlatite) 
			if(@@ERROR <> 0)
			begin
				rollback tran UIConcediuMedicZilePlatite
				set @rc = @@ERROR
			end
			else
			begin
				commit tran UIConcediuMedicZilePlatite
				set @rc = 0
			end		
	end
end
else
if(@tip_actiune = 1)
begin
	if(@verif=1)
	begin
	update ConcediuMedicZilePlatite with(xlock) set ValMinimAngajati=@ValMinimAngajati,ValMaximAngajati = @ValMaximAngajati,NrZilePlatite=@NrZilePlatite
			where id_Criteriu=@id_Criteriu
			if(@@ERROR <> 0)
			begin
				rollback tran UIConcediuMedicZilePlatite
				set @rc = @@ERROR
			end
			else
			begin
				commit tran UIConcediuMedicZilePlatite
			set @rc = 0
			end	
	end
end
else
if(@tip_actiune = 2)
begin
delete from ConcediuMedicZilePlatite with(xlock) where id_Criteriu=@id_Criteriu
	if(@@ERROR <> 0)
		begin
		rollback tran UIConcediuMedicZilePlatite
		set @rc = @@ERROR
		end
	else
	begin
		commit tran UIConcediuMedicZilePlatite
		set @rc = 0
	end
end
else
rollback tran UIConcediuMedicZilePlatite

return @rc


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteAngajator
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Angajatori
*/
CREATE PROCEDURE InsertUpdateDeleteAngajator
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@AngajatorID int,
	@Denumire nvarchar(100),
	@TipPersoana bit,
	@CUI_CNP nvarchar(25),
	@NrInregORC varchar(25)=NULL,
	@Telefon varchar(25),
	@Fax varchar(25),
	@PaginaWeb varchar(100)=NULL,
	@Email varchar(100)=NULL,
	@TaraID int,
	@JudetSectorID int,
	@Localitate nvarchar(50),
	@Strada nvarchar(50),	
	@Numar nvarchar(10),	
	@CodPostal nvarchar(20),	
	@Bloc nvarchar(5)=NULL,	
	@Scara nvarchar(5)=NULL,	
	@Etaj nvarchar(5)=NULL,	
	@Apartament nvarchar(5)=NULL,
	@ZiLichidareSalar nvarchar(2)	
)

as

declare @rc int
set @rc = 0

begin tran IUDAngajatori

if(@tip_actiune = 0)
begin	--Insert angajator
	insert into Angajatori with(xlock) (Denumire, TipPersoana, CUI_CNP, NrInregORC, Telefon, Fax, PaginaWeb, Email, TaraID, JudetSectorID,
		 Localitate, Strada, Numar, CodPostal, Bloc, Scara, Etaj, Apartament, ZiLichidareSalar) 
		values (@Denumire, @TipPersoana, @CUI_CNP, @NrInregORC, @Telefon, @Fax, @PaginaWeb, @Email, @TaraID, @JudetSectorID,
		 @Localitate, @Strada, @Numar, @CodPostal, @Bloc, @Scara, @Etaj, @Apartament, @ZiLichidareSalar)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDAngajatori
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDAngajatori
		set @AngajatorID = @@IDENTITY 
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update angajator
	update Angajatori with(xlock) set Denumire=@Denumire, TipPersoana=@TipPersoana, CUI_CNP=@CUI_CNP, NrInregORC=@NrInregORC
		, Telefon=@Telefon, Fax=@Fax, PaginaWeb=@PaginaWeb, Email=@Email, TaraID=@TaraID, JudetSectorID=@JudetSectorID, Localitate=@Localitate,
		 Strada=@Strada, Numar=@Numar, CodPostal=@CodPostal, Bloc=@Bloc, Scara=@Scara, Etaj=@Etaj, Apartament=@Apartament,
		 ZiLichidareSalar=@ZiLichidareSalar
		where AngajatorID=@AngajatorID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDAngajatori
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDAngajatori
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete angajator
	delete from Angajatori with(xlock) where AngajatorID = @AngajatorID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDAngajatori
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDAngajatori
		set @rc = 0
	end
end
else
	rollback tran IUDAngajatori

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteImpozit
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Salarii_impozite
*/
CREATE PROCEDURE InsertUpdateDeleteImpozit
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@ImpozitID int,
	@Denumire nvarchar(50),
	@Procent numeric(6,3), 
	@LunaID int,
	@Tip nvarchar(10),
	@AplicatLaID int
)

as

declare @rc int
set @rc = 0

begin tran IUDImpozit

if(@tip_actiune = 0)
begin	--Insert impozit
	insert into Salarii_impozite with(xlock) (Denumire, Procent, LunaID, Tip, AplicatLaID) 
		values (@Denumire, @Procent, @LunaID, @Tip, @AplicatLaID)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDImpozit
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDImpozit
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update impozit
	update Salarii_impozite with(xlock) set Denumire = @Denumire, Procent = @Procent , LunaID = @LunaID, Tip=@Tip, AplicatLaID=@AplicatLaID
		where ImpozitID=@ImpozitID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDImpozit
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDImpozit
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete impozit
	delete from Salarii_impozite with(xlock) where ImpozitID = @ImpozitID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDImpozit
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDImpozit
		set @rc = 0
	end
end
else
	rollback tran IUDImpozit

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE procedure sal_GetAllImpozitarAnual

(

@LunaID int

)

as
select sal_Impozitar_anual.*,salarii_CategoriiAngajati.Denumire
from sal_Impozitar_anual
 inner join salarii_CategoriiAngajati on
 sal_Impozitar_anual.CategorieID=salarii_CategoriiAngajati.CategorieID
where LunaID = @LunaID

order by salarii_CategoriiAngajati.Denumire

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





CREATE PROCEDURE sal_InsertUpdateDeleteCategorieAngajat
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	
	@CategorieID int,
	@LunaID int,
	@Denumire nvarchar(255),
	@Descriere ntext,
	
	@DPB money,
	
	@ScutireImpozit bit,
	@ScutireCASAngajat bit,
	@ScutireCASAngajator bit,
	@ScutireSomajAngajat bit,
	@ScutireSomajAngajator bit,
	@ScutireAsigSanAngajat bit,
	@ScutireAsigSanAngajator bit,

	@PrimesteDPB bit,
	
	@rc int out


	

	
)

as
set @rc = 0




begin tran IUDCategorieAngajat

if(@tip_actiune = 0)
begin	--Insert 
	

	

	insert into Salarii_CategoriiAngajati with(xlock) 

	(

	LunaID, 
	Denumire, 
	Descriere, 
	
	DPB, 
	
	ScutireImpozit, 
	ScutireCASAngajat,
	ScutireCASAngajator,
	ScutireSomajAngajat, 
	ScutireSomajAngajator, 	
	ScutireAsigSanAngajat,
	ScutireAsigSanAngajator,
	PrimesteDPB
	)
	 
	values  
	(
	
	@LunaID, 
	@Denumire, 
	@Descriere, 
	
	@DPB, 
	
	@ScutireImpozit, 
	@ScutireCASAngajat,
	@ScutireCASAngajator,
	@ScutireSomajAngajat, 
	@ScutireSomajAngajator, 	
	@ScutireAsigSanAngajat,
	@ScutireAsigSanAngajator,
	@PrimesteDPB
	
	
	) 
	if(@@ERROR <> 0)
	begin
		rollback tran IUDCategorieAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDCategorieAngajat
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update Zi
	update Salarii_CategoriiAngajati  with(xlock) set 


	LunaID = @LunaID, 
	Denumire = @Denumire, 
	Descriere = @Descriere, 
	
	DPB = @DPB, 
	
	ScutireImpozit = @ScutireImpozit, 
	ScutireCASAngajat = @ScutireCASAngajat,
	ScutireCASAngajator= @ScutireCASAngajator,
	ScutireSomajAngajat = @ScutireSomajAngajat, 
	ScutireSomajAngajator = @ScutireSomajAngajator, 	
	ScutireAsigSanAngajat = @ScutireAsigSanAngajat,
	ScutireAsigSanAngajator=@ScutireAsigSanAngajator,
	PrimesteDPB = @PrimesteDPB		
	
	where  CategorieID = @CategorieID
		
	if(@@ERROR <> 0)
	begin
		rollback tran IUDCategorieAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran  IUDCategorieAngajat
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete IntervalAbsentaAngajat
	delete from Salarii_CategoriiAngajati with(xlock) where CategorieID = @CategorieID
	if(@@ERROR <> 0)
	begin
		rollback tran  IUDCategorieAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran  IUDCategorieAngajat
		set @rc = 0
	end
end
else
	rollback tran IUDCategorieAngajat

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:	InsertUpdateDeleteVariabileGlobale
* Simbol:	Adauga, modifica, sterge o inregistrare in tabelul Sal_VariabileGlobale
*/
/*
* Autor:		
* Nume:	InsertUpdateDeleteVariabileGlobale
* Simbol:	Adauga, modifica, sterge o inregistrare in tabelul Sal_VariabileGlobale
*/
CREATE PROCEDURE sal_InsertUpdateDeleteVariabileGlobale
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@VariabilaID int,
	@SalariuMinim money,
	@SalariuMediu money, 
	@LunaID int
)

as

declare @rc int
set @rc = 0

begin tran IUDVariabileGlobale

if(@tip_actiune = 0)
begin	--Insert Variabile Globale
	insert into Sal_VariabileGlobale with(xlock) 
					(
						SalariuMediu,
						SalariuMinim,
						LunaID
					) 
					values 
					(
						@SalariuMediu,
						@SalariuMinim,
						@LunaID
					)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDVariabileGlobale
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDVariabileGlobale
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update Variabile Globale
	update Sal_VariabileGlobale with(xlock) set 
						
						
						 SalariuMediu= @SalariuMediu ,
						 SalariuMinim = @SalariuMinim,
						 LunaID = @LunaID
		where VariabilaID= @VariabilaID

	if(@@ERROR <> 0)
	begin
		rollback tran IUDVariabileGlobale
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDVariabileGlobale
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete Variabile Globale
	delete from Sal_VariabileGlobale with(xlock) where  VariabilaID= @VariabilaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDVariabileGlobale
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDVariabileGlobale
		set @rc = 0
	end
end
else
	rollback tran IUDVariabileGlobale

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


--Author: Dovlecel Vlad
CREATE PROCEDURE salarii_GetAngajatiCategoriiLunaActiva
(
	@AngajatorID int
)
AS

select *

from salarii_CategoriiAngajati sca inner join sal_Luni sl on sca.LunaID=sl.LunaID

where Activ=1 and AngajatorID=@AngajatorID
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


--Author: Dovlecel Vlad
CREATE PROCEDURE salarii_GetCategorie
(
	@CategorieID int
)
AS

select *

from salarii_CategoriiAngajati

where CategorieID=@CategorieID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
  Autor: Cristina Muntean
  Data: 21.02.2005
  Nume: spBazaCalcAsigSocialeAngajat
  Descriere: calculeaza baza de calcul a contributiei individuale de asigurari sociale
  Date intrare: venituri brute, date personal
  Date iesire: baza de calcul a contributiei individuale de asigurari sociale
  Formula de calcul:
  bazaDeCalculAContributieiIndividualeDeAsigurariSociale = min(venitBrut-indemnizatieConcediuMedical;5*salariulMediuBrutPeEconomie)
*/
CREATE PROCEDURE spCalculBazaCalcAsigSocialeAngajat
(
	--parametrii de intrare
	@LunaID int, --id-ul lunii
	@AngajatID int, --id-ul angajatului
	@IndemnizatieConcediuMedical money, --indemnizatie concediu medical
	@VenitBrut money, --venitul brut al angajatului 
	
	--parametrul de iesire
	@BCContribIndivDeAsigSoc money OUTPUT --baza de calcul a contributiei individuale de asigurari sociale
)
AS
	--salariul mediu brut pe economie
	DECLARE @SalariulMediuBrutPeEc money
	
	--salariul mediu brut pe economie
	SET @SalariulMediuBrutPeEc = (SELECT     sal_VariabileGlobaleValori.Valoare
								 FROM       sal_VariabileGlobaleValori INNER JOIN
								 sal_VariabileGlobaleTipuri ON sal_VariabileGlobaleValori.VariabilaGlobalaID = sal_VariabileGlobaleTipuri.VariabilaGlobalaID
								 WHERE sal_VariabileGlobaleTipuri.Cod = 'SMBE' AND sal_VariabileGlobaleValori.LunaID=@LunaID)
	
	--este calculata baza de calcul a contributiei individuale de asigurari sociale dupa formula:
	--bazaDeCalculAContributieiIndividualeDeAsigurariSociale = min(venitBrut-indemnizatieConcediuMedical;5*salariulMediuBrutPeEconomie)
	if((@VenitBrut - @IndemnizatieConcediuMedical) < 5*@SalariulMediuBrutPeEc)
		SET @BCContribIndivDeAsigSoc = @VenitBrut - @IndemnizatieConcediuMedical
	else
		SET @BCContribIndivDeAsigSoc = 5*@SalariulMediuBrutPeEc
		
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Author: 		Ionel Popa
	Mdified:        Cristina Muntean
	Description: 	Calculeaza contributie individuala la asigurari de sanatate ... cisan
					cisan = ProcentDinBazaCalculContributieIndivAsigSanatate * BazaCalculContributieIndivAsigSanatate
	Params:			@LunaID in ... id-ul lunii active
					@AngajatID in ... id-ul angajatului pentru care se calculeaza baza de calcul
					@BazaCalculContributieIndivAsigSanatate in ... baza de calcul a contributiei individuale de asigurari sociale
					@ContributieIndivAsigSanatate out ...contributia individuala de asigurari sociale
*/

CREATE PROCEDURE spCalculContributieIndivAsigSanatate
(
	@LunaID int,
	@AngajatID int,
	@BazaCalculContributieIndivAsigSanatate money,
	@ContributieIndivAsigSanatate money OUTPUT
)
AS
--procent din baza calcul a contributiei individuale de asigurari de sanatate
DECLARE @ProcentDinBazaCalculContributieIndivAsigSanatate float

--este setat procentul 
SET @ProcentDinBazaCalculContributieIndivAsigSanatate = (SELECT (sal_VariabileGlobaleValori.Valoare/100) AS Procent
												 FROM sal_VariabileGlobaleTipuri INNER JOIN
												 sal_VariabileGlobaleValori ON sal_VariabileGlobaleTipuri.VariabilaGlobalaID = sal_VariabileGlobaleValori.VariabilaGlobalaID 
												 WHERE sal_VariabileGlobaleTipuri.Cod='PBCISAN' AND sal_VariabileGlobaleValori.LunaID=@LunaID)
												 
set @ContributieIndivAsigSanatate = @ProcentDinBazaCalculContributieIndivAsigSanatate * @BazaCalculContributieIndivAsigSanatate
RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Author: 		Ionel Popa
	Modified:       Cristina Muntean
	Description: 	Calculeaza contributie individuala la asigurari sociale ... cicas
					cicas = ProcentDinBazaCalculContributieIndivAsigSociale * BazaCalculContributieIndivAsigSociale
	Params:			@LunaID in ... id-ul lunii active
					@AngajatID in ... id-ul angajatului pentru care se calculeaza baza de calcul
					@BazaCalculContributieIndivAsigSociale in ... baza de calcul a contributiei individuale de asigurari sociale
					@ContributieIndivAsigSociale out ...contributia individuala de asigurari sociale
*/

CREATE PROCEDURE spCalculContributieIndivAsigSociale
(
	@LunaID int,
	@AngajatID int,
	@BazaCalculContributieIndivAsigSociale money,
	@ContributieIndivAsigSociale money OUTPUT
)
AS
--procent din baza calcul a contributiei individuale de asigurari sociale
DECLARE @ProcentDinBazaCalculContributieIndivAsigSociale float

--este setat procentul 
SET @ProcentDinBazaCalculContributieIndivAsigSociale = (SELECT (sal_VariabileGlobaleValori.Valoare/100) AS Procent
												 FROM sal_VariabileGlobaleTipuri INNER JOIN
												 sal_VariabileGlobaleValori ON sal_VariabileGlobaleTipuri.VariabilaGlobalaID = sal_VariabileGlobaleValori.VariabilaGlobalaID 
												 WHERE sal_VariabileGlobaleTipuri.Cod='PBCICAS' AND sal_VariabileGlobaleValori.LunaID=@LunaID)

set @ContributieIndivAsigSociale = @ProcentDinBazaCalculContributieIndivAsigSociale * @BazaCalculContributieIndivAsigSociale

RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Author: 		Ionel Popa
	Modified:       Cristina Muntean
	Description: 	Calculeaza contributie individuala la fondul somaj ... cisom
					cisom =  ProcentDinBazaCalculContributieIndivSomaj * BazaCalculContributieIndivSomaj
	Params:			@LunaID in ... id-ul lunii active
					@AngajatID in ... id-ul angajatului pentru care se calculeaza baza de calcul
					@BazaCalculContributieIndivSomaj in ... baza de calcul a contributiei individuale de somaj
					@ContributieIndivSomaj out ...contributia individuala Somaj
*/

CREATE PROCEDURE spCalculContributieIndivSomaj
(
	@LunaID int,
	@AngajatID int,
	@BazaCalculContributieIndivSomaj money,
	@ContributieIndivSomaj money OUTPUT
)
AS
--procentul din baza de calcul a contributiei individuale de somaj
DECLARE @ProcentDinBazaCalculContributieIndivSomaj float

--este setat procentul 
SET @ProcentDinBazaCalculContributieIndivSomaj = (SELECT (sal_VariabileGlobaleValori.Valoare/100) AS Procent
												 FROM sal_VariabileGlobaleTipuri INNER JOIN
												 sal_VariabileGlobaleValori ON sal_VariabileGlobaleTipuri.VariabilaGlobalaID = sal_VariabileGlobaleValori.VariabilaGlobalaID 
												 WHERE sal_VariabileGlobaleTipuri.Cod='PBCISOM' AND sal_VariabileGlobaleValori.LunaID=@LunaID)

--este calculata contributia individuala de somaj
set @ContributieIndivSomaj = (@ProcentDinBazaCalculContributieIndivSomaj) * @BazaCalculContributieIndivSomaj
return

RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:      Cristina Muntean
	Descriere:  verifica daca datele introduse sunt valide(de exp: daca mai este introdus inca un angajat cu marca primita ca si parametru)
	Nume:       CheckDateAngajat
	Parametrii: 
				--parametrii de intrare
				@AngajatorID...id-ul angajatorlui
				@Marca....marca angajatului
				--parametru de iesire
				@Exista...true daca nu mai exista aceasta marca, false altfel
*/
CREATE PROCEDURE CheckDateAngajat
(
		--parametrii de intrare
		@AngajatorID int, --id-ul angajatorlui
		@Marca nvarchar(8), --marca angajatului
		
		--prametru de iesire
		@NuExistaMarca bit OUTPUT--true daca mai exista aceasta marca, false altfel
)
AS
	--retine de cate ori apare marca trimisa ca parametru in cadrul datelor despre angajatii angajatorului cu id-ul trimis ca parametru
	DECLARE @NrMarca int
	
	--se numara de cate ori apare marca trimisa ca parametru in cadrul datelor despre angajatii angajatorului cu id-ul trimis ca parametru
	SET @NrMarca=(SELECT COUNT(*) as nr
				FROM Angajati
				WHERE Marca=@Marca AND AngajatorID=@AngajatorID)
	
	--@ExistaMarca este true daca nu mai exista un angajat cu aceasta marca si false altfel
	if(@NrMarca=0)
		SET @NuExistaMarca=1
	else
		SET @NuExistaMarca=0
	
	RETURN @NuExistaMarca
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:      Cristina Muntean
	Descriere:  verifica daca datele introduse sunt valide(de exp: daca mai este introdus inca un angajat cu marca primita ca si parametru)
	Nume:       CheckDateAngajatForUpdate
	Parametrii: 
				--parametrii de intrare
				@AngajatorID...id-ul angajatorlui
				@AngajatID...id-ul angajatului
				@Marca....marca angajatului
				--parametru de iesire
				@Exista...true daca nu mai exista aceasta marca, false altfel
*/
CREATE PROCEDURE CheckDateAngajatForUpdate
(
		--parametrii de intrare
		@AngajatorID int, --id-ul angajatorlui
		@AngajatID int, --id-ul angajatului
		@Marca nvarchar(8), --marca angajatului
		
		--prametru de iesire
		@NuExistaMarca bit OUTPUT--true daca mai exista aceasta marca, false altfel
)
AS
	--retine de cate ori apare marca trimisa ca parametru in cadrul datelor despre angajatii angajatorului cu id-ul trimis ca parametru
	DECLARE @NrMarca int
	
	--se numara de cate ori apare marca trimisa ca parametru in cadrul datelor despre angajatii angajatorului cu id-ul trimis ca parametru
	SET @NrMarca=(SELECT COUNT(*) as nr
				FROM Angajati
				WHERE Marca=@Marca AND AngajatorID=@AngajatorID AND AngajatID<>@AngajatID)
	
	--@ExistaMarca este true daca nu mai exista un angajat cu aceasta marca in afara de cel pentru care se face update si false altfel
	if(@NrMarca=0)
		SET @NuExistaMarca=1
	else
		SET @NuExistaMarca=0
	
	RETURN @NuExistaMarca
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE CountAngajatiPerAngajator  AS

select AngajatorID, count(AngajatID) as noangajati  from Angajati
group by Angajati.AngajatorID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetAngajat
(
	@AngajatID int
)

AS

SELECT     *

FROM         Angajati

WHERE      AngajatID = @AngajatID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE GetAngajatVechimeInMunca
(
	@AngajatID int,
	@Curr bit
)
as 
declare @luni int
declare @ani int
declare @zile int

--anul angajarii
set @ani=(select year(getdate())-year(DataDeLa) from angajati where angajatid=@AngajatID)

--luna angajarii
set @luni=(select month(getdate())-month(DataDeLa) from angajati where angajatid=@AngajatID)

--ziua angajarii
set @zile=(select day(getdate())-day(DataDeLa) from angajati where angajatid=@AngajatID)

if (@luni<0)
begin
 set @ani=@ani-1
 set @luni=12+@luni
end

declare @l int
declare @m int
declare @y int

set @l=(select day(DataDeLa) from angajati where angajatid=@AngajatID)

set @m=month(getdate())-1

if( @m=0 )
begin
	set @m=12
	set @y=year(getdate())-1
end
else begin
	set @m=month(getdate())-1
	set @y=year(getdate())
end

--numarul maxim de zile in luna @m
declare @nrZileMaxLuna int

--daca luna @m e februarie
if(@m=2)
	--daca anul @y este bisect 
	if(((@y % 4 = 0)and (@y % 100 <> 0)) or(@y % 400 = 0))
		set @nrZileMaxLuna = 29
	else
		set @nrZileMaxLuna = 28
--altfel
else
	--daca luna nu este februarie
	set @nrZileMaxLuna = (select (case @m
							when 1 then 31
							when 3 then 31
							when 4 then 30
							when 5 then 31
							when 6 then 30
							when 7 then 31
							when 8 then 31
							when 9 then 30
							when 10 then 31
							when 11 then 30
							when 12 then 31
						 end )as nrMaxZile
						 from anjajati
						 where angajatID=@AngajatID)
print 'nr max zile '+cast(@nrZileMaxLuna as nvarchar(32))

if(@l > @nrZileMaxLuna)
	set @l = @nrZileMaxLuna

--este construita data
declare @data varchar(10)
set @data=(SELECT CONVERT(varchar(2),@m) + '/' + CONVERT(varchar(2), @l)+ '/' + CONVERT(varchar(4), @y))

--este facuta conversia
declare @z datetime
set @z=convert(datetime,@data)

if (@zile<0)
begin
 set @luni=@luni-1
 set @zile=datediff(d,@z,getdate())
end

if (@Curr=1)
	select @ani as Ani,@luni as Luni,@zile as Zile
else
	select (@ani+AniVechimeMunca ) as Ani,(@luni+LuniVechimeMunca)  as Luni,(@zile+ZileVechimeMunca) as Zile
              from  Angajati
	 where angajatid=@AngajatID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Autor: Muntean Raluca Cristina
--Descriere: returneaza toti angajatii care au functia de baza la 
--angajatorul dat ca parametru
CREATE PROCEDURE dbo.GetAngajatiCuFctDeBaza
(
		@AngajatorID int
)

AS
SELECT     AngajatID, NumeIntreg
FROM         Angajati
WHERE     (TipFisaFiscala = 0) AND (AngajatorID = @AngajatorID)
ORDER BY NumeIntreg
RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Autor: Muntean Raluca Cristina
--Descriere: returneaza toti angajatii care nu au functia de baza la angajatorul 
--dat ca parametru
CREATE PROCEDURE dbo.GetAngajatiFaraFctDeBaza
(
	@AngajatorID int
)
AS
SELECT     AngajatID, NumeIntreg
FROM         Angajati
WHERE     (TipFisaFiscala = 1) AND (AngajatorID = @AngajatorID)
ORDER BY NumeIntreg

RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetImpoziteCategorie
	@CategorieID int
 AS


	select Salarii_impozite.* from Salarii_impozite
	left join Salarii_AsignareImpozite on Salarii_AsignareImpozite.ImpozitID = Salarii_impozite.ImpozitID
	where Salarii_AsignareImpozite.CategorieID = @CategorieID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteCategorieSalarii
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Salarii_CategoriiAngajati
*/
CREATE PROCEDURE InsertUpdateDeleteCategorieSalarii
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@CategorieID int,
	@Denumire nvarchar(50),
	@LunaID int,
	@ListaImpozite nvarchar(100)

	--@SumaNeimpozabila decimal,
	--@DeducerePersonalaBaza decimal,
	--@CheltuieliProfesionale decimal, 
	--@SalariulMediu decimal
)

as

declare @rc int
DECLARE @ImpozitID varchar(10), @Pos int
set @rc = 0

begin tran IUDCategorieSalariit

if(@tip_actiune = 0)
begin	--Insert categorie
	insert into Salarii_CategoriiAngajati with(xlock) (Denumire, LunaID) 
		values (@Denumire, @LunaID)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDCategorieSalariit
		set @rc = @@ERROR
	end
	else
	begin


		set @CategorieID = @@IDENTITY
		--		insert into Salarii_VariabileGlobale  (SumaNeimpozabila, DeducerePersonalaBaza, CheltuieliProfesionale, SalariulMediu, CategorieID ) 
		--values (@SumaNeimpozabila, @DeducerePersonalaBaza, @CheltuieliProfesionale, @SalariulMediu, @CategorieID)

	
		SET @ListaImpozite = LTRIM(RTRIM(@ListaImpozite))+ ','
		SET @Pos = CHARINDEX(',', @ListaImpozite, 1)
		IF REPLACE(@ListaImpozite, ',', '') <> ''
		BEGIN
			WHILE @Pos > 0
			BEGIN
				SET @ImpozitID = LTRIM(RTRIM(LEFT(@ListaImpozite, @Pos - 1)))
				IF @ImpozitID <> ''
				BEGIN
					insert into Salarii_AsignareImpozite (ImpozitID, CategorieID) values (@ImpozitID, @CategorieID)
				END
				SET @ListaImpozite = RIGHT(@ListaImpozite, LEN(@ListaImpozite) - @Pos)
				SET @Pos = CHARINDEX(',', @ListaImpozite, 1)
	
			END
		END
		
		if(@@ERROR <> 0)
		begin
			rollback tran IUDCategorieSalariit
			set @rc = @@ERROR
		end
		else
		begin
			commit tran IUDCategorieSalariit
			set @rc = 0
		end
	end
end
else if(@tip_actiune = 1)
begin	--Update categorie
	update Salarii_CategoriiAngajati with(xlock) set Denumire = @Denumire where CategorieID=@CategorieID
	
	--update Salarii_VariabileGlobale with(xlock) set SumaNeimpozabila = @SumaNeimpozabila,  DeducerePersonalaBaza= @DeducerePersonalaBaza , CheltuieliProfesionale= @CheltuieliProfesionale , SalariulMediu= @SalariulMediu 
		--where CategorieID= @CategorieID

	delete  from Salarii_AsignareImpozite where CategorieId=@CategorieID

	SET @ListaImpozite = LTRIM(RTRIM(@ListaImpozite))+ ','
	SET @Pos = CHARINDEX(',', @ListaImpozite, 1)
	IF REPLACE(@ListaImpozite, ',', '') <> ''
	BEGIN
		WHILE @Pos > 0
		BEGIN
			SET @ImpozitID = LTRIM(RTRIM(LEFT(@ListaImpozite, @Pos - 1)))
			IF @ImpozitID <> ''
			BEGIN
				insert into Salarii_AsignareImpozite (ImpozitID, CategorieID) values (@ImpozitID, @CategorieID)
			END
			SET @ListaImpozite = RIGHT(@ListaImpozite, LEN(@ListaImpozite) - @Pos)
			SET @Pos = CHARINDEX(',', @ListaImpozite, 1)

		END
	END	

	if(@@ERROR <> 0)
	begin
		rollback tran IUDCategorieSalariit
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDCategorieSalariit
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete categorie
	--delete from Salarii_VariabileGlobale with(xlock) where CategorieID = @CategorieID
	delete from Salarii_CategoriiAngajati with(xlock) where CategorieID = @CategorieID
	
	if(@@ERROR <> 0)
	begin
		rollback tran IUDCategorieSalariit
		set @rc = @@ERROR
	end
	else
	begin
			commit tran IUDCategorieSalariit
			set @rc = 0
	
	end
end
else
	rollback tran IUDCategorieSalariit

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteCont
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Conturi
*/
CREATE PROCEDURE InsertUpdateDeleteCont
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@ContID int,
	@BancaID int,
	@AngajatID int,
	@NumarCont nvarchar(50),
	@Moneda varchar(3)
)

as

declare @rc int
set @rc = 0

begin tran IUDConturi

if(@tip_actiune = 0)
begin	--Insert banca
	insert into Conturi with(xlock) (TitularID, BancaID, NumarCont, Moneda) 
		values (@AngajatID, @BancaID, @NumarCont, @Moneda)
	if(@@ERROR <> 0)
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
else if(@tip_actiune = 1)
begin	--Update banca
	update Conturi with(xlock) set BancaID = @BancaID, NumarCont = @NumarCont, Moneda = @Moneda
		where ContId=@ContID
	if(@@ERROR <> 0)
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
else if(@tip_actiune = 2)
begin	--Delete banca
	delete from Conturi with(xlock) where ContID = @ContID
	if(@@ERROR <> 0)
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

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteImpozitar
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Salarii_impozitar
*/
CREATE PROCEDURE InsertUpdateDeleteImpozitar
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@ImpozitarID int,
	@CategorieID int,
	@ValMin numeric(19,3),
	@ValMax numeric(19,3),
	@SumaBaza numeric(19,3),
	@Procent numeric(6,3)
)

as

declare @rc int
set @rc = 0

begin tran IUDImpozitar

if(@tip_actiune = 0)
begin	--Insert impozitar
	insert into Salarii_impozitar with(xlock) (ValMin, ValMax, Procent, SumaBaza, CategorieID) 
		values (@ValMin, @ValMax, @Procent, @SumaBaza, @CategorieID)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDImpozitar
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDImpozitar
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update impozitar
	update Salarii_impozitar with(xlock) set ValMin = @ValMin, ValMax = @ValMax , SumaBaza = @SumaBaza, Procent=@Procent
		where ImpozitarID=@ImpozitarID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDImpozitar
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDImpozitar
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete impozitar
	delete from Salarii_impozitar with(xlock) where ImpozitarID = @ImpozitarID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDImpozitar
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDImpozitar
		set @rc = 0
	end
end
else
	rollback tran IUDImpozitar

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Mircea Albutiu, PSE RO BS TH
* Nume:			InsertAngajat
* Descriere:	Insereaza un angajat 
*/
CREATE PROCEDURE InsertUpdateDeleteIstoricContracteAngajati
(
--Angajat
		@AngajatID int,
		@DataStart datetime,
		@DataEnd datetime,
		@AngajatorID int,
		@ModIncadrare bit,
		@ProgramLucru tinyint,
		@TipFisaFiscala bit,
		@AniVechimeMunca tinyint,
		@LuniVechimeMunca tinyint,
		@ZileVechimeMunca tinyint,
--pt categoria de incadrare
		@CategorieID int,
--pt perioada determinata
		@PerioadaDeterminata bit,
		@DataPanaLa datetime=NULL,
--pt contract munca
                           @NrContractMunca varchar(50),
		@DataInregContractMunca datetime,
-- pt invaliditate
		@Invaliditate smallint,
--pt salariu si indemnizatia de conducere
                           @SalariuBaza money,
		@IndemnizatieConducere money,  

----------------------------------------------------------------------------------------------
--CarteIdentitate
--Pasaport
--Domiciliul
--Resedinta
--Carnet Munca
--Mail & Telefon
--Output
		@new_id int = 0 output
)
as

declare	@rc int
set @rc = 0

declare @old_AngajatorID int,
	@old_ModIncadrare bit,
	@old_ProgramLucru tinyint,
	@old_TipFisaFiscala bit,
	@old_AniVechimeMunca tinyint,
	@old_LuniVechimeMunca tinyint,
	@old_ZileVechimeMunca tinyint,
	--pt categoria de incadrare
	@old_CategorieID int,
	--pt perioada determinata
	@old_PerioadaDeterminata bit,
	@old_DataPanaLa datetime,
	--pt contract munca
             @old_NrContractMunca varchar(50),
	@old_DataInregContractMunca datetime,
	-- pt invaliditate
	@old_Invaliditate smallint,
	--pt salariu si indemnizatia de conducere
             @old_SalariuBaza money,
	@old_IndemnizatieConducere money

begin transaction ContracteAngajati

select @rc = count(AngajatID), @old_AngajatorID = AngajatorID,
	@old_ModIncadrare = ModIncadrare,
	@old_ProgramLucru = ProgramLucru,
	@old_TipFisaFiscala = TipFisaFiscala,
	@old_AniVechimeMunca = AniVechimeMunca,
	@old_LuniVechimeMunca = LuniVechimeMunca,
	@old_ZileVechimeMunca = ZileVechimeMunca,
	--pt categoria de incadrare
	@old_CategorieID = CategorieID,
	--pt perioada determinata
	@old_PerioadaDeterminata = PerioadaDeterminata,
	@old_DataPanaLa = DataPanaLa,
	--pt contract munca
             @old_NrContractMunca = NrCOntractMunca,
	@old_DataInregContractMunca = DataInregContractMunca,
	-- pt invaliditate
	@old_Invaliditate = Invaliditate,
	--pt salariu si indemnizatia de conducere
             @old_SalariuBaza = SalariuBazaActual,
	@old_IndemnizatieConducere = IndemnizatieConducereActual

from Angajati 

where AngajatID = @AngajatID

group by AngajatorID,
	ModIncadrare,
	ProgramLucru,
	TipFisaFiscala,
	AniVechimeMunca,
	LuniVechimeMunca,
	ZileVechimeMunca,
	--pt categoria de incadrare
	CategorieID,
	--pt perioada determinata
	PerioadaDeterminata,
	DataPanaLa,
	--pt contract munca
             NrCOntractMunca,
	DataInregContractMunca,
	-- pt invaliditate
	Invaliditate,
	--pt salariu si indemnizatia de conducere
             SalariuBazaActual,
	IndemnizatieConducereActual


/*
if(@rc = 0)
begin	--Insert Angajat
	insert into Angajati with (xlock)
		(AngajatorID, Marca, NumeIntreg, Nume, Prenume, NumeAnterior, TitluID, Poza, PrenumeMama, PrenumeTata, StudiuID, AnAbsolvire, NrDiploma, 
		Descriere, ModIncadrare, ProgramLucru, Telefon, DataNasterii, TaraNastereID, JudetNastereID, LocalitateNastere, 
		StareCivila, NrCopii, Sex, Nationalitate, CNP, CNPAnterior, TipFisaFiscala, AniVechimeMunca, LuniVechimeMunca, 
		ZileVechimeMunca, AreCardBancar, PerioadaDeterminata,DataPanaLa,SefID,NrContractMunca,DataInregContractMunca,Invaliditate,
		SalariuBazaActual,IndemnizatieConducereActual,CategorieID,Email,TelMunca,PermMuncaEliberat,PermMuncaExpira,
		PermSedereEliberat,PermSedereExpira,NrPermisMunca  )
		values
		(@AngajatorID, @Marca, @Nume+' '+@Prenume, @Nume, @Prenume, @NumeAnterior, @TitluID, @Poza, @PrenumeMama, @PrenumeTata, @StudiuID, @AnAbsolvire, 
		@NrDiploma, @Descriere, @ModIncadrare, @ProgramLucru, @Telefon, @DataNasterii, @TaraNastereID, @JudetNastereID, 
		@LocalitateNastere, @StareCivila, @NrCopii, @Sex, @Nationalitate, @CNP, @CNPAnterior, @TipFisaFiscala, @AniVechimeMunca, 
		@LuniVechimeMunca, @ZileVechimeMunca, @AreCardBancar,@PerioadaDeterminata,@DataPanaLa, @SefID,
		@NrContractMunca,@DataInregContractMunca,@Invaliditate,@SalariuBaza,@IndemnizatieConducere,@CategorieID,@Email,@TelMunca,@PermMuncaEliberat,@PermMuncaExpira,
		@PermSedereEliberat,@PermSedereExpira,@NrPermisMunca  )
	if(@@ERROR <> 0)
		set @rc = @@ERROR
	else
	begin
		set @AngajatID = @@IDENTITY
		set @new_id = @AngajatID
		set @rc = 0
	end
end
else
begin	--Update Angajat
	update Angajati with (xlock) set AngajatorID = @AngajatorID, Marca = @Marca, NumeIntreg = @Nume+' ' + @Prenume,Nume = @Nume, Prenume = @Prenume, NumeAnterior=@NumeAnterior,
		TitluID = @TitluID, Poza = @Poza, PrenumeMama = @PrenumeMama, PrenumeTata = @PrenumeTata, StudiuID = @StudiuID, 
		AnAbsolvire = @AnAbsolvire, NrDiploma = @NrDiploma, Descriere = @Descriere, ModIncadrare = @ModIncadrare, 
		ProgramLucru = @ProgramLucru, Telefon = @Telefon, DataNasterii = @DataNasterii, TaraNastereID = @TaraNastereID, 
		JudetNastereID = @JudetNastereID, LocalitateNastere = @LocalitateNastere, StareCivila = @StareCivila, 
		NrCopii = @NrCopii, Sex = @Sex, Nationalitate = @Nationalitate, CNP = @CNP, CNPAnterior=@CNPAnterior, TipFisaFiscala = @TipFisaFiscala, 
		AniVechimeMunca = @AniVechimeMunca, LuniVechimeMunca = @LuniVechimeMunca, ZileVechimeMunca = @ZileVechimeMunca, 
		AreCardBancar = @AreCardBancar, PerioadaDeterminata=@PerioadaDeterminata,DataPanaLa=@DataPanaLa, SefID = @SefID,
		NrContractMunca=@NrContractMunca, DataInregContractMunca=@DataInregContractMunca,Invaliditate=@Invaliditate,
		SalariuBazaActual=@SalariuBaza,IndemnizatieConducereActual=@IndemnizatieConducere,CategorieID=@CategorieID,Email=@Email,TelMunca=@TelMunca,
		PermMuncaEliberat=@PermMuncaEliberat,PermMuncaExpira=@PermMuncaExpira,PermSedereEliberat=@PermSedereEliberat,PermSedereExpira=@PermSedereExpira,NrPermisMunca=@NrPermisMunca
		where AngajatID = @AngajatID
	if(@@ERROR <> 0)
		set @rc = @@ERROR
	else
	begin
		set @new_id = @AngajatID
		set @rc = 0
	end
end*/


/*declare	@rc int
set @rc = 0

begin transaction InsertUpdateAngajat

select @rc = count(AngajatID) from Angajati where AngajatID = @AngajatID

if(@rc = 0)
begin	--Insert Angajat
	insert into Angajati with (xlock)
		(AngajatorID, Marca, NumeIntreg, Nume, Prenume, NumeAnterior, TitluID, Poza, PrenumeMama, PrenumeTata, StudiuID, AnAbsolvire, NrDiploma, 
		Descriere, ModIncadrare, ProgramLucru, Telefon, DataNasterii, TaraNastereID, JudetNastereID, LocalitateNastere, 
		StareCivila, NrCopii, Sex, Nationalitate, CNP, CNPAnterior, TipFisaFiscala, AniVechimeMunca, LuniVechimeMunca, 
		ZileVechimeMunca, AreCardBancar, PerioadaDeterminata,DataPanaLa,SefID,NrContractMunca,DataInregContractMunca,Invaliditate,
		SalariuBazaActual,IndemnizatieConducereActual,CategorieID,Email,TelMunca,PermMuncaEliberat,PermMuncaExpira,
		PermSedereEliberat,PermSedereExpira,NrPermisMunca  )
		values
		(@AngajatorID, @Marca, @Nume+' '+@Prenume, @Nume, @Prenume, @NumeAnterior, @TitluID, @Poza, @PrenumeMama, @PrenumeTata, @StudiuID, @AnAbsolvire, 
		@NrDiploma, @Descriere, @ModIncadrare, @ProgramLucru, @Telefon, @DataNasterii, @TaraNastereID, @JudetNastereID, 
		@LocalitateNastere, @StareCivila, @NrCopii, @Sex, @Nationalitate, @CNP, @CNPAnterior, @TipFisaFiscala, @AniVechimeMunca, 
		@LuniVechimeMunca, @ZileVechimeMunca, @AreCardBancar,@PerioadaDeterminata,@DataPanaLa, @SefID,
		@NrContractMunca,@DataInregContractMunca,@Invaliditate,@SalariuBaza,@IndemnizatieConducere,@CategorieID,@Email,@TelMunca,@PermMuncaEliberat,@PermMuncaExpira,
		@PermSedereEliberat,@PermSedereExpira,@NrPermisMunca  )
	if(@@ERROR <> 0)
		set @rc = @@ERROR
	else
	begin
		set @AngajatID = @@IDENTITY
		set @new_id = @AngajatID
		set @rc = 0
	end
end
else
begin	--Update Angajat
	update Angajati with (xlock) set AngajatorID = @AngajatorID, Marca = @Marca, NumeIntreg = @Nume+' ' + @Prenume,Nume = @Nume, Prenume = @Prenume, NumeAnterior=@NumeAnterior,
		TitluID = @TitluID, Poza = @Poza, PrenumeMama = @PrenumeMama, PrenumeTata = @PrenumeTata, StudiuID = @StudiuID, 
		AnAbsolvire = @AnAbsolvire, NrDiploma = @NrDiploma, Descriere = @Descriere, ModIncadrare = @ModIncadrare, 
		ProgramLucru = @ProgramLucru, Telefon = @Telefon, DataNasterii = @DataNasterii, TaraNastereID = @TaraNastereID, 
		JudetNastereID = @JudetNastereID, LocalitateNastere = @LocalitateNastere, StareCivila = @StareCivila, 
		NrCopii = @NrCopii, Sex = @Sex, Nationalitate = @Nationalitate, CNP = @CNP, CNPAnterior=@CNPAnterior, TipFisaFiscala = @TipFisaFiscala, 
		AniVechimeMunca = @AniVechimeMunca, LuniVechimeMunca = @LuniVechimeMunca, ZileVechimeMunca = @ZileVechimeMunca, 
		AreCardBancar = @AreCardBancar, PerioadaDeterminata=@PerioadaDeterminata,DataPanaLa=@DataPanaLa, SefID = @SefID,
		NrContractMunca=@NrContractMunca, DataInregContractMunca=@DataInregContractMunca,Invaliditate=@Invaliditate,
		SalariuBazaActual=@SalariuBaza,IndemnizatieConducereActual=@IndemnizatieConducere,CategorieID=@CategorieID,Email=@Email,TelMunca=@TelMunca,
		PermMuncaEliberat=@PermMuncaEliberat,PermMuncaExpira=@PermMuncaExpira,PermSedereEliberat=@PermSedereEliberat,PermSedereExpira=@PermSedereExpira,NrPermisMunca=@NrPermisMunca
		where AngajatID = @AngajatID
	if(@@ERROR <> 0)
		set @rc = @@ERROR
	else
	begin
		set @new_id = @AngajatID
		set @rc = 0
	end
end

if(@rc = 0)		--Insert sau update carte de identitate
	exec @rc = InsertUpdateCarteIdentitate @AngajatID, @SerieCI, @NumarCI, @EliberatDeCI, @DataEliberariiCI, @ValabilPanaLaCI

if(@rc = 0)		--Insert sau update pasaport
	exec @rc = InsertUpdatePasaport @AngajatID, @SeriePas, @NumarPas, @EliberatDePas, @DataEliberariiPas, @ValabilPanaLaPas

if(@rc = 0)		--Insert sau update domiciliu
	exec @rc = InsertUpdateDomiciliu @AngajatID, @TaraID, @Localitate, @JudetSectorID, @Strada, 
				@NumarStr, @CodPostal, @Bloc, @Scara, @Etaj, @Apartament, 'd'

if(@rc = 0)		--Insert sau update resedinta
	exec @rc = InsertUpdateDomiciliu @AngajatID, @TaraIDRes, @LocalitateRes, @JudetSectorIDRes, @StradaRes, 
				@NumarStrRes, @CodPostalRes, @BlocRes, @ScaraRes, @EtajRes, @ApartamentRes, 'r'

if(@rc = 0)		--Insert sau update carte de munca
	exec @rc = InsertUpdateCarnetMunca @AngajatID, @Serie, @Numar, @Emitent, @DataEmiterii, @NrInregITM

if(@rc <> 0)
	rollback tran InsertUpdateAngajat
else
	commit tran InsertUpdateAngajat

return @rc*/

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE ScrieNumeIntreg


AS
declare @nume nvarchar(50), @prenume nvarchar(50), @numeintreg nvarchar(100)

declare angajat_cursor scroll cursor for
select nume, prenume
from Angajati

open angajat_cursor

fetch next from angajat_cursor into
	@nume, @prenume
while @@fetch_status = 0
begin
	set @numeintreg = @nume + ' ' + @prenume
	update Angajati set NumeIntreg=@numeintreg where current of angajat_cursor
	fetch next from angajat_cursor into
	@nume, @prenume
end

close angajat_cursor
deallocate angajat_cursor

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE SeteazaInactivAngajatiExpiraContractLunaCurenta
(
	@Data datetime,
	@AngajatorID int
)
AS

update Angajati

set activ=1

where activ=0 and 
	PerioadaDeterminata=1 and 
	datediff(month, dataPanaLa, @Data)>=0 and
	AngajatorID=@AngajatorID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


--Author: Dovlecel Vlad
CREATE PROCEDURE UpdateAngajatDateSchimbate
(
	@AngajatID int,
	
	@ProgramLucru int,
	@SalariuBaza money,
	@IndemnizatieConducere money,
	@Invaliditate smallint,
	@CategorieID int
)

 AS

update Angajati 

set ProgramLucru=@ProgramLucru, SalariuBazaActual=@SalariuBaza, IndemnizatieConducereActual=@IndemnizatieConducere, Invaliditate=@Invaliditate, CategorieID=@CategorieID

where AngajatID=@AngajatID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE UpdatePozaAngajat

	(
		@AngajatID bigint,
		@Poza Image
	)

AS
	
	update angajati set Poza=@Poza where AngajatID=@AngajatID
	
	
	RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.sal_CopySetariSalarii_LunaActiva

(
@LunaOld int,
@LunaNew  int
)
	
AS




declare @ImpozitID int
declare @Impozit_Denumire nvarchar(255)
declare @Impozit_Procent float
declare @Impozit_Tip nvarchar(255)
declare @Impozit_AplicatLaID int







declare impozite_cursor scroll cursor for
select 

ImpozitID,
Denumire,
Procent,
Tip,
AplicatLaID

from salarii_impozite
where LunaID = @LunaOld





open impozite_cursor

fetch next from impozite_cursor into

	@ImpozitID,
	@Impozit_Denumire,
	@Impozit_Procent,
	@Impozit_Tip,
	@Impozit_AplicatLaID


	

	while @@fetch_status = 0
	
	begin
	print 'Impozit : '
	print @Impozit_denumire

	declare @new_ImpozitID int

		
	insert into salarii_impozite

			(
			
			Denumire,
			Procent,
			Tip,
			AplicatLaID,
			LunaID
			
			)

			values

			(
			@Impozit_Denumire,
			@Impozit_Procent,
			@Impozit_Tip,
			@Impozit_AplicatLaID,
			@LunaNew			

			)
	
	set @new_ImpozitID = @@identity	


	print ' Propagare impozit   - new id : '
	print @new_ImpozitID

	declare @CategorieID int
	declare @Categorie_Denumire nvarchar(255)
	declare @Categorie_Descriere nvarchar(4000)

	

	declare categorii_cursor scroll cursor for
	select  
	
	Salarii_CategoriiAngajati.CategorieID,
	Denumire,
	Descriere
	

	from Salarii_CategoriiAngajati
	inner join salarii_AsignareImpozite on 
	Salarii_CategoriiAngajati.CategorieID = Salarii_AsignareImpozite.CategorieID and ImpozitID = @ImpozitID

		


	open categorii_cursor

	fetch next from categorii_cursor into

	@CategorieID,
	@Categorie_Denumire,
	@Categorie_Descriere

	while @@fetch_status = 0
	
	begin
	print ' Categorie : '
	print @Categorie_Denumire

	
	declare @CategorieExists int

	
	Select * from Salarii_CategoriiAngajati where LunaID = @LunaNew and Denumire = @Categorie_Denumire
	set @CategorieExists =@@rowcount
	print 'Categorie exista : '
	print @CategorieExists

	declare @new_CategorieID int


	if (@CategorieExists=1) begin
				
				Select @new_CategorieID=CategorieID  from salarii_CategoriiAngajati where LunaID = @LunaNew and Denumire = @Categorie_Denumire
				print 'Categorie gasita : '
				
				end

				else 

				begin
				
				/*Noua Cat adaugata ca matching pt cea veche de pe luna precedenta - copiere de info*/				

				insert into Salarii_CategoriiAngajati
				
				(
					LunaID,
					Denumire,
					Descriere
				)

				values

				(
					@LunaNew,
					@Categorie_Denumire,
					@Categorie_Descriere
				
				)
				print 'Categorie inserata : '
				set @new_CategorieID = @@identity
			
				/* Update Angajati - modificarea CategorieID a i sa se utilizeze cat. nou creata pentru luna activa*/

				update Angajati set CategorieID = @new_CategorieID where CategorieID = @CategorieID
				print 'Categorii update angajati : '
				print @@rowcount

				/* Update Angajati - modificarea CategorieID a i sa se utilizeze cat. nou creata pentru luna activa*/
	
				/*Noua Cat adaugata ca matching pt cea veche de pe luna precedenta - copiere de info*/							
				
				 end		
				
				print 'new Cat Id:'
				print @new_CategorieID
				
								
				/* Inserare date in Asignare Impozite  - New Impozit - New Categorie */
				declare @AsignareExists int
				select * from  Salarii_AsignareImpozite where ImpozitID = @new_ImpozitID and CategorieID = @new_CategorieID

				set @AsignareExists = @@rowcount				
			
				print 'Exista asignarea :'
				print @Categorie_Denumire 
				print '-'
				print @Impozit_denumire
				print ':'
				print @AsignareExists			

				if (@AsignareExists=0)
				
				insert into Salarii_AsignareImpozite 

				(
					ImpozitID,
					CategorieID
				)
				values
				(
					@new_ImpozitID,
					@new_CategorieID				

				)
				/* Inserare date in Asignare Impozite  - New Impozit - New Categorie */			


	/*     Propagare impozitar pentru categoria nou creata */

	declare @Impozitar_ValMin money
	declare @Impozitar_ValMax money
	declare @Impozitar_Suma money
	declare @Impozitar_Procent decimal
	declare @Impozitar_Data datetime
	
	declare impozitar_cursor scroll cursor for
	select  
	
	ValMin,
	ValMax,
	Suma,
	Procent,
	Data
	

	from Sal_Impozitar
	where Sal_Impozitar.CategorieID = @CategorieID

	open impozitar_cursor

	fetch next from impozitar_cursor into

	@Impozitar_ValMin,
	@Impozitar_ValMax,
	@Impozitar_Suma,
	@Impozitar_Procent,
	@Impozitar_Data

	while @@fetch_status = 0
	
	begin

	
	/* Inserare impozitar nou legat de noua categorie adaugata*/

	
	declare @ExistsImpozitar int


	set @ExistsImpozitar = (Select count(ImpozitarID) from Sal_Impozitar where ValMin = @Impozitar_ValMin and ValMax = @Impozitar_ValMax and Suma = @Impozitar_Suma and Procent = @Impozitar_Procent and CategorieID = @new_CategorieID)

	if @ExistsImpozitar=0
	insert into Sal_Impozitar

	(

	ValMin,
	ValMax,
	Suma,
	Procent,
	Data,
	CategorieID

	)
	values
	(

	@Impozitar_ValMin,
	@Impozitar_ValMax,
	@Impozitar_Suma,
	@Impozitar_Procent,
	@Impozitar_Data,
	@new_CategorieID

	)


	/* Inserare impozitar nou legat de noua categorie adaugata*/

	fetch next from impozitar_cursor into

	@Impozitar_ValMin,
	@Impozitar_ValMax,
	@Impozitar_Suma,
	@Impozitar_Procent,
	@Impozitar_Data

	end

	close impozitar_cursor

	deallocate impozitar_cursor


	/*     Propagare impozitar pentru categoria nou creata */

	fetch next from categorii_cursor into

	@CategorieID,
	@Categorie_Denumire,
	@Categorie_Descriere


	
	end
	close categorii_cursor
	deallocate categorii_cursor

	
	fetch next from impozite_cursor into

	@ImpozitID,
	@Impozit_Denumire,
	@Impozit_Procent,
	@Impozit_Tip,
	@Impozit_AplicatLaID



	end

close impozite_cursor


deallocate impozite_cursor

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO






CREATE PROCEDURE dbo.sal_CopySetariSalarii_LunaActiva2
(
@LunaOld int,
@LunaNew  int
)
	
AS




	declare @CategorieID int
	declare @Categorie_Denumire nvarchar(255)
	declare @Categorie_Descriere nvarchar(4000)

	declare @Categorie_DPB money

	declare	 @Categorie_ScutireImpozit bit
	declare	 @Categorie_ScutireCASAngajat bit
	declare	 @Categorie_ScutireCASAngajator bit
	declare	 @Categorie_ScutireSomajAngajat bit
	declare	 @Categorie_ScutireSomajAngajator bit
	declare	 @Categorie_ScutireAsigSanAngajat bit
	declare	 @Categorie_ScutireAsigSanAngajator bit
	declare	 @Categorie_PrimesteDPB bit
	declare  @Categorie_CoeficientDeducereSpeciala bit
	

	declare categorii_cursor scroll cursor for
	select  
	
	Salarii_CategoriiAngajati.CategorieID,
	Denumire,
	Descriere,
	DPB,
	ScutireImpozit,
	ScutireCASAngajat,
	ScutireCASAngajator,
	ScutireSomajAngajat,
	ScutireSomajAngajator,
	ScutireAsigSanAngajat,
	ScutireAsigSanAngajator,
	PrimesteDPB,
	CoeficientDeducereSpeciala

	

	from Salarii_CategoriiAngajati
	where LunaID = @LunaOld
	order by Denumire


	open categorii_cursor

	fetch next from categorii_cursor into

	@CategorieID,
	@Categorie_Denumire,
	@Categorie_Descriere,
	@Categorie_DPB,
	@Categorie_ScutireImpozit,
	@Categorie_ScutireCASAngajat,
	@Categorie_ScutireCASAngajator,
	@Categorie_ScutireSomajAngajat,
	@Categorie_ScutireSomajAngajator,
	@Categorie_ScutireAsigSanAngajat,
	@Categorie_ScutireAsigSanAngajator,
	@Categorie_PrimesteDPB,
	@Categorie_CoeficientDeducereSpeciala

	while @@fetch_status = 0
	
	begin
	print ' Categorie : '
	print @Categorie_Denumire

	
	declare @CategorieExists int

	
	Select * from Salarii_CategoriiAngajati where LunaID = @LunaNew and Denumire = @Categorie_Denumire
	set @CategorieExists =@@rowcount
	print 'Categorie exista : '
	print @CategorieExists

	declare @new_CategorieID int


	if (@CategorieExists=1) begin
				
				Select @new_CategorieID=CategorieID  from salarii_CategoriiAngajati where LunaID = @LunaNew and Denumire = @Categorie_Denumire
				print 'Categorie gasita : '
				
				end

				else 

				begin
				
				/*Noua Cat adaugata ca matching pt cea veche de pe luna precedenta - copiere de info*/				

				insert into Salarii_CategoriiAngajati
				
				(
					LunaID,
					Denumire,
					Descriere,
					DPB,
					ScutireImpozit,
					ScutireCASAngajat,
					ScutireCASAngajator,
					ScutireSomajAngajat,
					ScutireSomajAngajator,
					ScutireAsigSanAngajat,
					ScutireAsigSanAngajator,
					PrimesteDPB,
					CoeficientDeducereSpeciala

				)

				values

				(
					@LunaNew,
					@Categorie_Denumire,
					@Categorie_Descriere,
					@Categorie_DPB,
					@Categorie_ScutireImpozit,
					@Categorie_ScutireCASAngajat,
					@Categorie_ScutireCASAngajator,
					@Categorie_ScutireSomajAngajat,
					@Categorie_ScutireSomajAngajator,
					@Categorie_ScutireAsigSanAngajat,
					@Categorie_ScutireAsigSanAngajator,
					@Categorie_PrimesteDPB,
					@Categorie_CoeficientDeducereSpeciala

				
				)
				print 'Categorie inserata : '
				set @new_CategorieID = @@identity
			
				/* Update Angajati - modificarea CategorieID a i sa se utilizeze cat. nou creata pentru luna activa*/

				update Angajati set CategorieID = @new_CategorieID where CategorieID = @CategorieID
				print 'Categorii update angajati : '
				print @@rowcount

				/* Update Angajati - modificarea CategorieID a i sa se utilizeze cat. nou creata pentru luna activa*/
	
				/*Noua Cat adaugata ca matching pt cea veche de pe luna precedenta - copiere de info*/							
				
				 end		
				
				print 'new Cat Id:'
				print @new_CategorieID
				
								
	/*     Propagare impozitar pentru categoria nou creata */

	declare @Impozitar_ValMin money
	declare @Impozitar_ValMax money
	declare @Impozitar_Suma money
	declare @Impozitar_Procent decimal
	declare @Impozitar_Data datetime
	
	declare impozitar_cursor scroll cursor for
	select  
	
	ValMin,
	ValMax,
	Suma,
	Procent,
	Data
	

	from Sal_Impozitar
	where Sal_Impozitar.CategorieID = @CategorieID

	open impozitar_cursor

	fetch next from impozitar_cursor into

	@Impozitar_ValMin,
	@Impozitar_ValMax,
	@Impozitar_Suma,
	@Impozitar_Procent,
	@Impozitar_Data

	while @@fetch_status = 0
	
	begin

	
	/* Inserare impozitar nou legat de noua categorie adaugata*/

	
	declare @ExistsImpozitar int


	set @ExistsImpozitar = (Select count(ImpozitarID) from Sal_Impozitar where ValMin = @Impozitar_ValMin and ValMax = @Impozitar_ValMax and Suma = @Impozitar_Suma and Procent = @Impozitar_Procent and CategorieID = @new_CategorieID)

	if @ExistsImpozitar=0
	insert into Sal_Impozitar

	(

	ValMin,
	ValMax,
	Suma,
	Procent,
	Data,
	CategorieID

	)
	values
	(

	@Impozitar_ValMin,
	@Impozitar_ValMax,
	@Impozitar_Suma,
	@Impozitar_Procent,
	@Impozitar_Data,
	@new_CategorieID

	)


	/* Inserare impozitar nou legat de noua categorie adaugata*/

	fetch next from impozitar_cursor into

	@Impozitar_ValMin,
	@Impozitar_ValMax,
	@Impozitar_Suma,
	@Impozitar_Procent,
	@Impozitar_Data

	end

	close impozitar_cursor

	deallocate impozitar_cursor


	/*     Propagare impozitar pentru categoria nou creata */

	fetch next from categorii_cursor into

	@CategorieID,
	@Categorie_Denumire,
	@Categorie_Descriere,
	@Categorie_DPB,
	@Categorie_ScutireImpozit,
	@Categorie_ScutireCASAngajat,
	@Categorie_ScutireCASAngajator,
	@Categorie_ScutireSomajAngajat,
	@Categorie_ScutireSomajAngajator,
	@Categorie_ScutireAsigSanAngajat,
	@Categorie_ScutireAsigSanAngajator,
	@Categorie_PrimesteDPB


	
	end
	close categorii_cursor

	deallocate categorii_cursor


	declare @Variabila_SalariuMinim money
	declare @Variabila_SalariuMediu money


	Select @Variabila_SalariuMinim=SalariuMinim,@Variabila_SalariuMediu = SalariuMediu  from Sal_VariabileGlobale where LunaID = @LunaOld
	
	insert into Sal_VariabileGlobale (SalariuMinim,SalariuMediu,LunaID) values (@Variabila_SalariuMinim,@Variabila_SalariuMediu,@LunaNew)

	-- Var globale valori 

	declare variabile_globale_valori_cursor scroll cursor for
	select  
	
		VariabilaGlobalaID,
		LunaID,
		Valoare

	from Sal_VariabileGlobaleValori

	where LunaID = @LunaOld

	declare @vgv_VariabilaGlobalaID int
	declare @vgv_LunaID int
	declare @vgv_Valoare float
	


	open variabile_globale_valori_cursor

	fetch next from variabile_globale_valori_cursor into
	
	@vgv_VariabilaGlobalaID,
	@vgv_LunaID,
	@vgv_Valoare
	
	while @@fetch_status = 0
	
	begin


	insert into sal_VariabileGlobaleValori
	(
		VariabilaGlobalaID,
		LunaID,
		Valoare
	) values
	(
	
		@vgv_VariabilaGlobalaID,
		@LunaNew,
		@vgv_Valoare
	)
	

	fetch next from variabile_globale_valori_cursor into
	
	@vgv_VariabilaGlobalaID,
	@vgv_LunaID,
	@vgv_Valoare

	end

	close variabile_globale_valori_cursor
	deallocate variabile_globale_valori_cursor
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.sal_DeleteImpozitar
(
	@ImpozitarID int
)
AS
DELETE FROM sal_Impozitar
WHERE     (ImpozitarID = @ImpozitarID)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE procedure sal_GetAllImpozitar

(

@LunaID int

)

as
select sal_Impozitar.*,salarii_CategoriiAngajati.Denumire
from sal_Impozitar
 inner join salarii_CategoriiAngajati on
 sal_Impozitar.CategorieID=salarii_CategoriiAngajati.CategorieID
where LunaID = @LunaID

order by salarii_CategoriiAngajati.Denumire

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE sal_GetAngajati

AS
	SELECT     AngajatID, NrCopii, SalariuBazaActual, IndemnizatieConducereActual
	FROM         Angajati

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE sal_GetImpozitar 
(
 @Suma money,
 @Data datetime,
 @CategorieID int
)
AS
select top 1 * 
from sal_Impozitar
where @Suma between valmin and valmax
and   (data <= @Data) and (CategorieID=@CategorieID)
ORDER BY Data DESC

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE sal_GetImpozitarById
(
 @ImpozitarID int
)
AS
select *
from sal_Impozitar
where ImpozitarID=@ImpozitarID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE sal_InsertImpozitar

	(
		@ValMin money,
		@ValMax money,
		@Suma money,
		@Procent decimal(18,2),
		@Data datetime,
		@CategorieID int,
		@SetID int OUTPUT	
	)

AS
	INSERT INTO sal_Impozitar
		     (ValMin,ValMax,Suma,Procent,Data,CategorieID)
	VALUES    (@ValMin,@ValMax,@Suma,@Procent,@Data,@CategorieID)
    SET @SetID = @@IDENTITY

	IF @@ERROR > 0
		BEGIN
		RAISERROR ('Insert esuat', 16, 1)
		RETURN 99
		END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE sal_UpdateImpozitar
(
	@ImpozitarID int,
	@ValMin money,
	@ValMax money,
	@Suma money,
	@Procent decimal(18,2),
	@Data datetime,
	@CategorieID int
)

AS
	UPDATE    sal_Impozitar
	SET      ValMin=@ValMin,
		ValMax=@ValMax,        
		Suma=@Suma,
		Procent=@Procent,
		Data=@Data,
		CategorieID=@CategorieID
           WHERE ImpozitarID=@ImpozitarID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Autor: Muntean Raluca Cristina
--Descriere: este realizata indexarea trimestriala referitoare la procentul inflatiei
--in conformitate cu Contractul colectiv de muncă şi cu datele oferite de către 
--Institutul Naţional de Statistică prin Direcţia Judeţeană de Statistică Braşov 
--pentru trimestrul anterior al anului curent
CREATE PROCEDURE dbo.sal_UpdateIndexare
(
		@AngajatID int,
		@ProcentInflatie float
)
AS
	
	BEGIN TRANSACTION UpdateProcentInflatie

	--indexarea se face astfel:
	--de exp daca pe ult trei luni avem urm procente :ian - 3%, feb 5%, mar 4%,
	--se aduna suplimentar 1% si se calculeaza astfel:
	--SalariuNou = SalariuVechi x (1,03 x  1,05 x 1,04 + 0,01) pt angajatii din ian sau mai vechi
	--SalariuNou = SalariuVechi x (1,05 x 1,04 + 0,0067) pt angajatii care au inceput in feb
	--SalariuNou = SalariuVechi x (1,04 + 0,0033) pentru angajatii care au inceput in martie
	--in @ProcentInflatie primit ca parametru este inclus si coeficientul, respectiv 0,01, 
	--0,0067, 0,0033 in functie de caz
	--La fel pentru IndemnizatieConducere
	UPDATE Angajati  WITH(xlock) SET 
	SalariuBazaActual = SalariuBazaActual+SalariuBazaActual*@ProcentInflatie,
	IndemnizatieConducereActual = IndemnizatieConducereActual+IndemnizatieConducereActual*@ProcentInflatie
	WHERE  AngajatID=@AngajatID 
	IF(@@ERROR <> 0)
		ROLLBACK TRANSACTION UpdateProcentInflatie
	ELSE
		COMMIT TRANSACTION UpdateProcentInflatie

RETURN 0


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Autor: Muntean Raluca Cristina
--Data: 17.11.2004
--Descriere: face update salariului de baza si indemnizatiei de conducere in urma 
--majorarilor stabilite pentru un anumit angajat
CREATE PROCEDURE dbo.sal_UpdateMajorari
(
	@AngajatID int,
	@MajSalariuBaza money,
	@MajIndemnizatieConducere money
)

AS
BEGIN TRANSACTION UpdateMajorari

	UPDATE Angajati  WITH(xlock) SET 
	SalariuBazaActual = SalariuBazaActual+@MajSalariuBaza,
	IndemnizatieConducereActual = IndemnizatieConducereActual+@MajIndemnizatieConducere
	WHERE  AngajatID=@AngajatID 
	IF(@@ERROR <> 0)
		ROLLBACK TRANSACTION UpdateMajorari
	ELSE
		COMMIT TRANSACTION UpdateMajorari

RETURN 0



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:             Cristina Muntean
	Nume:              spCalculAsigurariSocialeUnitate
	Parametrii:        
					   --parametrii de intrare
					   @AngajatorID int, --id-ul angajatorului
					   @LunaID int, --id-ul lunii
	
					   --parametru de iesire
					   @cuas money OUTPUT
	Descriere:         calculeaza cuas unitate
	Formula de calcul: cuas calculat= TotalVenitBrut - IndemnizatiaDeConcediuMedical	
*/
CREATE PROCEDURE spCalculAsigurariSocialeUnitate
(
	--parametrii de intrare
	@AngajatorID int, --id-ul angajatorului
	@LunaID int, --id-ul lunii
	
	--parametru de iesire
	@cuas money OUTPUT
	
	
)
AS
	--total venit brut pe luna trimisa ca parametru
	DECLARE @TotalVenitBrut money
	--total indemnizatie de concediu medical
	DECLARE @IndemnizatieConcediuMedical money
	
	--calcul total venit brut
	SET @TotalVenitBrut = (SELECT SUM(VenitBrut)as totalVB
						  FROM sal_StatDePlata INNER JOIN Angajati
						  ON sal_StatDePlata.AngajatID=Angajati.AngajatID
						  WHERE sal_StatDePlata.LunaID=@LunaID AND Angajati.AngajatorID=@AngajatorID)
	
	--calcul indemnizatie concediu medical 
	/*
	SET @IndemnizatieConcediuMedical = (SELECT SUM(IndemnizatieConcediuMedical)as totalICM
						  FROM sal_StatDePlata INNER JOIN Angajati
						  ON sal_StatDePlata.AngajatID=Angajati.AngajatID
						  WHERE sal_StatDePlata.LunaID=@LunaID AND Angajati.AngajatorID=@AngajatorID)
	*/
	SET @IndemnizatieConcediuMedical = 0
	
	--calculeaza cuas unitate
	--Formula de calcul: cuas calculat= TotalVenitBrut - IndemnizatiaDeConcediuMedical	
	SET @cuas = @TotalVenitBrut - @IndemnizatieConcediuMedical
	
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor: Cristina Muntean
	Data: 7.03.2005
	Nume: spCalculBazaCalculDirectiadeMuncaUnitate
	Descriere: calculeaza baza de calcul a contributiei unitatii la directia de munca si protectie sociala
	Formula de calcul: BazaCalculDirectieaDeMuncaAngajatorbcudmps = @TotalVenitBrutPtAngajatiCuFctDeBaza
	Parametrii: @LunaID...id-ul lunii
			    @AngajatorID...id-ul angajatorului
			    @BCDirectiaDeMuncaAngajator...suma rezultata in urma calculului-parametru de iesire
	
*/
CREATE PROCEDURE spCalculBazaCalculDirectiaDeMuncaUnitate
(
	--parametrii de intrare
	@LunaID int, --id-ul lunii
	@AngajatorID int, --id-ul angajatorului
	
	--parametru de iesire
	@BCDirectiaDeMuncaAngajator money --baza de calcul a contributiei unitatii la directia de munca si protectie sociala
)

AS
	--calculeaza baza de calcul a contributiei unitatii la directia de munca si protectie sociala
	--Formula de calcul: BazaCalculDirectieaDeMuncaAngajatorbcudmps = @TotalVenitBrutPtAngajatiCuFctDeBaza
	SET @BCDirectiaDeMuncaAngajator = (SELECT SUM(VenitBrut)as totalVB
						  FROM sal_StatDePlata INNER JOIN Angajati
						  ON sal_StatDePlata.AngajatID=Angajati.AngajatID
						  WHERE sal_StatDePlata.LunaID=@LunaID AND Angajati.AngajatorID=@AngajatorID AND Angajati.ModIncadrare=0)
	
	RETURN 



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor: Cristina Muntean
	Data: 7.03.2005
	Nume: spCalculBazaCalculFondRiscUnitate
	Descriere: calculeaza baza de calcul a contributiei angajatorului la fondul de accidente de munca si boli profesionale
	Formula de calcul: BazaCalculFondRiscAngajator= TotalVenitBrut - IndemnizatieConcediuMedical
	Parametrii: @LunaID...id-ul lunii
			    @AngajatorID...id-ul angajatorului
			    @BCFondRiscAngajator...suma rezultata in urma calculului-parametru de iesire
	
*/
CREATE PROCEDURE spCalculBazaCalculFondRiscUnitate
(
	--parametrii de intrare
	@LunaID int, --id-ul lunii
	@AngajatorID int, --id-ul angajatorului
	
	--parametru de iesire
	@BCFondRiscAngajator money --baza de calcul al contributiei angajatorului la fondul de accidente de munca si boli profesionale
)

AS
	--total venit brut pe luna trimisa ca parametru
	DECLARE @TotalVenitBrut money
	--total indemnizatie de concediu medical
	DECLARE @IndemnizatieConcediuMedical money
	
	--calcul total venit brut
	SET @TotalVenitBrut = (SELECT SUM(VenitBrut)as totalVB
						  FROM sal_StatDePlata INNER JOIN Angajati
						  ON sal_StatDePlata.AngajatID=Angajati.AngajatID
						  WHERE sal_StatDePlata.LunaID=@LunaID AND Angajati.AngajatorID=@AngajatorID)
	
	--calcul indemnizatie concediu medical 
	SET @IndemnizatieConcediuMedical = (SELECT SUM(IndemnizatieConcediuMedical)as totalICM
						  FROM sal_StatDePlata INNER JOIN Angajati
						  ON sal_StatDePlata.AngajatID=Angajati.AngajatID
						  WHERE sal_StatDePlata.LunaID=@LunaID AND Angajati.AngajatorID=@AngajatorID)
	
		--calculeaza baza de calcul a contributiei angajatorului la fondul de accidente de munca si boli profesionale
	--Formula de calcul: BazaCalculFondRiscAngajator= TotalVenitBrut - IndemnizatieConcediuMedical
	SET @BCFondRiscAngajator = @TotalVenitBrut - @IndemnizatieConcediuMedical
	RETURN 



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor: Cristina Muntean
	Data: 7.03.2005
	Nume: spCalculBazaCalculSanatateUnitate
	Descriere: calculeaza baza de calcul a contributiei de sanatate a angajatorului
	Formula de calcul: BazaCalculSanatateAngajator= TotalVenitBrut - IndemnizatieConcediuMedical
	Parametrii: @LunaID...id-ul lunii
			    @AngajatorID...id-ul angajatorului
			    @BCSanatateAngajator...suma rezultata in urma calculului-parametru de iesire
	
*/
CREATE PROCEDURE spCalculBazaCalculSanatateUnitate
(
	--parametrii de intrare
	@LunaID int, --id-ul lunii
	@AngajatorID int, --id-ul angajatorului
	
	--parametru de iesire
	@BCSanatateAngajator money --baza de calcul a contributiei de sanatate a angajatorului
)

AS
	--total venit brut pe luna trimisa ca parametru
	DECLARE @TotalVenitBrut money
	--total indemnizatie de concediu medical
	DECLARE @IndemnizatieConcediuMedical money
	
	--calcul total venit brut
	SET @TotalVenitBrut = (SELECT SUM(VenitBrut)as totalVB
						  FROM sal_StatDePlata INNER JOIN Angajati
						  ON sal_StatDePlata.AngajatID=Angajati.AngajatID
						  WHERE sal_StatDePlata.LunaID=@LunaID AND Angajati.AngajatorID=@AngajatorID)
	
	--calcul indemnizatie concediu medical 
	SET @IndemnizatieConcediuMedical = (SELECT SUM(IndemnizatieConcediuMedical)as totalICM
						  FROM sal_StatDePlata INNER JOIN Angajati
						  ON sal_StatDePlata.AngajatID=Angajati.AngajatID
						  WHERE sal_StatDePlata.LunaID=@LunaID AND Angajati.AngajatorID=@AngajatorID)
	
	--calculeaza baza de calcul a contributiei de sanatate a angajatorului
	--Formula de calcul: BazaCalculSanatateAngajator= TotalVenitBrut - IndemnizatieConcediuMedical
	SET @BCSanatateAngajator = @TotalVenitBrut - @IndemnizatieConcediuMedical
	RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Author: 		Ionel Popa
	Description: 	Calculeaza deducerile personale ... dedp
					dedp = dedp=ROUNDUP(IF(VenitBrut<=10000000;2500000+PersoaneIntretinere*1000000;IF(VenitBrut>=30000000;0;(2500000+PersoaneIntretinere*1000000)*(1-(VenitBrut-10000000)/20000000)));-FactorRotunjire)
	Params:			@LunaID in ... id-ul lunii active
					@AngajatID in ... id-ul angajatului pentru care se calculeaza baza de calcul
					@VenitBrut in ... venitul brut al angajatului
					@FactorRotunjire in ... suma se va rotunji la 10^FactorRotunjire
					@DeduceriPersonale out ... deducerile personale pentru angajat
	Change history:
				Ionel Popa: 03 mar 2005
					S-a modificat formula de calcul a deducerilor personale astfel: Atunci cand angajatul are cumul de functii (adica e cu functia de baza la alta societate) deducerile personale sunt egale cu 0.
					In restul cazurilor ramane valabila  formula de mai sus.
*/
CREATE PROCEDURE spCalculDeduceriPersonale
(
	@LunaID int,
	@AngajatID int,
	@VenitBrut money,
	@FactorRotunjire int,
	@DeduceriPersonale money OUTPUT
)
AS

declare @PersoaneIntretinere int
declare @FunctiaDeBazaInAltaSocietate int

--extragem numarul de persoane in intretinere pentru angajatul respectiv
select @PersoaneIntretinere = NrCopii from angajati where AngajatID = @AngajatID

--extragem informatii despre modul de incadrare al angajatului ... daca este sau nu cu functia de incadrare in cadrul societatii
select @FunctiaDeBazaInAltaSocietate = ModIncadrare from angajati where AngajatID = @AngajatID

if @FunctiaDeBazaInAltaSocietate = 1
begin
	set @DeduceriPersonale = 0
	return
end

--calculam deducerile personale
if @VenitBrut <= 10000000
	begin
		set @DeduceriPersonale = 2500000 + 1000000 * @PersoaneIntretinere
	end
else
	begin
		if @VenitBrut >= 30000000
			begin
				set @DeduceriPersonale = 0
			end
		else
			begin
				set @DeduceriPersonale = ( 2500000 + 1000000 * @PersoaneIntretinere) * ( 1 - ((@VenitBrut - 10000000) / 20000000 ))
			end
	end

set @DeduceriPersonale = [SiemensHR_Test].[dbo].[RoundUpSumOfMoney](@DeduceriPersonale, 5)

RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Author: 		Ionel Popa
	Modified:       Cristina Muntean
	Description: 	Calculeaza impozitul platit de un angajat ... i
					i = VenitulImpozabil * ProcentImpozit * DeducereSpeciala, 
					0<= DeducereSpeciala <=1				
	Params:			@LunaID in ... id-ul lunii active
					@AngajatID in ... id-ul angajatului pentru care se calculeaza baza de calcul
					@VenitImpozabil in ... venitul impozabil pentru angajatul respectiv
					@Impozit OUTPUT ... impozitul platit de angajat
*/
CREATE PROCEDURE spCalculImpozit
(
	@LunaID int,
	@AngajatID int,
	@VenitImpozabil money,
	@Impozit money OUTPUT
)
AS


--coeficientul de deducere speciala
declare @DeducereSpeciala float
--procentul de impozitare
declare @ProcentImpozit float
 
--setare procent impozit
SET @ProcentImpozit = (SELECT (sal_VariabileGlobaleValori.Valoare/100) AS Procent
					  FROM sal_VariabileGlobaleValori INNER JOIN sal_VariabileGlobaleTipuri 
					  ON sal_VariabileGlobaleValori.VariabilaGlobalaID = sal_VariabileGlobaleTipuri.VariabilaGlobalaID
					  WHERE sal_VariabileGlobaleTipuri.Denumire = 'Impozit' AND sal_VariabileGlobaleValori.LunaID=@LunaID)

 				  
--setare coeficient de deducere speciala corespunzator categoriei de incadrare a angajatului
SET @DeducereSpeciala = (SELECT     Salarii_CategoriiAngajati.CoeficientDeducereSpeciala
						FROM       Salarii_CategoriiAngajati INNER JOIN
						Angajati ON Salarii_CategoriiAngajati.CategorieID = Angajati.CategorieID
						WHERE     (Angajati.AngajatID = @AngajatID) AND (Salarii_CategoriiAngajati.LunaID=@LunaID))

--calculare impozit
set @Impozit = @VenitImpozabil * @ProcentImpozit * @DeducereSpeciala


RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:	Dovlecel Vlad
* Nume:		UpdatePerioadaZileCategorieIDAngajat
* Data:	Modifica coloana CategorieID din tabelul tm_IntervaleAngajat, pt anumite inregistrari
*/
CREATE PROCEDURE tm_UpdatePerioadaZileCategorieIDAngajat
(
	@AngajatID int,
	@DataStart datetime,
	@DataEnd datetime,
	@CategorieID int
)

as

declare @rc int
set @rc = 0

begin tran IUDZi

update tm_IntervaleAngajat with(xlock) set CategorieID=@CategorieID where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd

update Angajati with(xlock) set CategorieID=@CategorieID where AngajatID=@AngajatID
		
if(@@ERROR <> 0)
begin
	rollback tran IUDZi
	set @rc = @@ERROR
end
else
begin
	commit tran IUDZi
	set @rc = 0
end

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:	Dovlecel Vlad
* Nume:		UpdatePerioadaZileSalariuBazaActualAngajat
* Data:	Modifica o inregistrare in tabelul tm_IntervaleAngajat
*/
CREATE PROCEDURE tm_UpdatePerioadaZileIndeminzatieConducereAngajat
(
	@AngajatID int,
	@DataStart datetime,
	@DataEnd datetime,
	@IndemnizatieConducere money
)

as

declare @rc int
set @rc = 0

begin tran IUDZi

update tm_IntervaleAngajat with(xlock) set IndemnizatieConducere=@IndemnizatieConducere where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd

update Angajati with(xlock) set IndemnizatieConducereActual=@IndemnizatieConducere where AngajatID=@AngajatID
		
if(@@ERROR <> 0)
begin
	rollback tran IUDZi
	set @rc = @@ERROR
end
else
begin
	commit tran IUDZi
	set @rc = 0
end

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:	Dovlecel Vlad
* Nume:		UpdatePerioadaZileInvaliditateAngajat
* Data:	Modifica coloana de Invaliditate din tabelul tm_IntervaleAngajat, pt anumite inregistrari
*/
CREATE PROCEDURE tm_UpdatePerioadaZileInvaliditateAngajat
(
	@AngajatID int,
	@DataStart datetime,
	@DataEnd datetime,
	@Invaliditate smallint
)

as

declare @rc int
set @rc = 0

begin tran IUDZi

update tm_IntervaleAngajat with(xlock) set Invaliditate=@Invaliditate where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd

update Angajati with(xlock) set Invaliditate=@Invaliditate where AngajatID=@AngajatID
		
if(@@ERROR <> 0)
begin
	rollback tran IUDZi
	set @rc = @@ERROR
end
else
begin
	commit tran IUDZi
	set @rc = 0
end

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:	Dovlecel Vlad
* Nume:		UpdatePerioadaZileNormaLucruAngajat
* Data:	Modifica o inregistrare in tabelul tm_IntervaleAngajat
*/
CREATE PROCEDURE tm_UpdatePerioadaZileNormaLucruAngajat
(
	@AngajatID int,
	@DataStart datetime,
	@DataEnd datetime,
	@ProgramLucru int
)

as

declare @rc int
set @rc = 0

declare @capat int
set @capat = 0

begin tran IUDZi

update tm_IntervaleAngajat with(xlock) set ProgramLucru=@ProgramLucru where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd

update Angajati with(xlock) set ProgramLucru=@ProgramLucru where AngajatID=@AngajatID
		
if(@@ERROR <> 0)
begin
	rollback tran IUDZi
	set @rc = @@ERROR
end
else
begin
	commit tran IUDZi
	set @rc = 0
end

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:	Dovlecel Vlad
* Nume:		UpdatePerioadaZileSalariuBazaActualAngajat
* Data:	Modifica o inregistrare in tabelul tm_IntervaleAngajat
*/
CREATE PROCEDURE tm_UpdatePerioadaZileSalariuBazaActualAngajat
(
	@AngajatID int,
	@DataStart datetime,
	@DataEnd datetime,
	@SalariuBaza money
)

as

declare @rc int
set @rc = 0

begin tran IUDZi

update tm_IntervaleAngajat with(xlock) set SalariuBaza=@SalariuBaza where AngajatID=@AngajatID and @DataStart<=Data and Data<=@DataEnd

update Angajati with(xlock) set SalariuBazaActual=@SalariuBaza where AngajatID=@AngajatID
		
if(@@ERROR <> 0)
begin
	rollback tran IUDZi
	set @rc = @@ERROR
end
else
begin
	commit tran IUDZi
	set @rc = 0
end

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tmp_proc1
(
	@AngajatID int,
	@Curr bit
)

as 

declare @luni int
declare @ani int
declare @zile int

set @ani=(select year(getdate())-year(DataDeLa) from angajati where angajatid=@AngajatID)
set @luni=(select month(getdate())-month(DataDeLa) from angajati where angajatid=@AngajatID)
set @zile=(select day(getdate())-day(DataDeLa) from angajati where angajatid=@AngajatID)

if (@luni<0)
begin
 set @ani=@ani-1
 set @luni=12+@luni
end

declare @l int
set @l=(select day(DataDeLa) from angajati where angajatid=@AngajatID)

declare @m int
set @m=month(getdate())-1

declare @y int
set @y=year(getdate())

declare @data varchar(10)
set @data=(SELECT CONVERT(varchar(2),@m) + '/' + CONVERT(varchar(2), @l)+ '/' + CONVERT(varchar(4), @y))

select @data as dd


/*declare @z datetime
set @z=convert(datetime,@data)

if (@zile<0)
begin
 set @luni=@luni-1
 set @zile=datediff(d,@z,getdate())
end

if (@Curr=1)
	select @ani as Ani,@luni as Luni,@zile as Zile
else
	select (@ani+AniVechimeMunca ) as Ani,(@luni+LuniVechimeMunca)  as Luni,(@zile+ZileVechimeMunca) as Zile
              from  Angajati
	 where angajatid=@AngajatID
*/

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.ClearSalarii

	(
		@LunaID int
		
	)

AS
	delete  from dbo.sal_VariabileGlobale where LunaID=@LunaID
	delete  from dbo.sal_Salarii where LunaID=@LunaID
	delete  from dbo.sal_SituatieLunaraAngajati where LunaID=@LunaID 



	declare @CategorieID int
	declare @Categorie_Denumire nvarchar(255)
	declare @Categorie_Descriere nvarchar(4000)

	declare @Categorie_DPB money

	declare	 @Categorie_ScutireImpozit bit
	declare	 @Categorie_ScutireCASAngajat bit
	declare	 @Categorie_ScutireCASAngajator bit
	declare	 @Categorie_ScutireSomajAngajat bit
	declare	 @Categorie_ScutireSomajAngajator bit
	declare	 @Categorie_ScutireAsigSanAngajat bit
	declare	 @Categorie_ScutireAsigSanAngajator bit
	declare	 @Categorie_PrimesteDPB bit


	declare categorii_cursor scroll cursor for
	select  
	
	Salarii_CategoriiAngajati.CategorieID,
	Denumire,
	Descriere,
	DPB,
	ScutireImpozit,
	ScutireCASAngajat,
	ScutireCASAngajator,
	ScutireSomajAngajat,
	ScutireSomajAngajator,
	ScutireAsigSanAngajat,
	ScutireAsigSanAngajator,
	PrimesteDPB

	

	from Salarii_CategoriiAngajati
	where LunaID = @LunaID
	order by Denumire


	open categorii_cursor

	fetch next from categorii_cursor into

	@CategorieID,
	@Categorie_Denumire,
	@Categorie_Descriere,
	@Categorie_DPB,
	@Categorie_ScutireImpozit,
	@Categorie_ScutireCASAngajat,
	@Categorie_ScutireCASAngajator,
	@Categorie_ScutireSomajAngajat,
	@Categorie_ScutireSomajAngajator,
	@Categorie_ScutireAsigSanAngajat,
	@Categorie_ScutireAsigSanAngajator,
	@Categorie_PrimesteDPB

	while @@fetch_status = 0
	
	begin
	
	delete from sal_Impozitar where CategorieID = @CategorieID
	
	fetch next from categorii_cursor into

	@CategorieID,
	@Categorie_Denumire,
	@Categorie_Descriere,
	@Categorie_DPB,
	@Categorie_ScutireImpozit,
	@Categorie_ScutireCASAngajat,
	@Categorie_ScutireCASAngajator,
	@Categorie_ScutireSomajAngajat,
	@Categorie_ScutireSomajAngajator,
	@Categorie_ScutireAsigSanAngajat,
	@Categorie_ScutireAsigSanAngajator,
	@Categorie_PrimesteDPB


	
	end
	close categorii_cursor

	deallocate categorii_cursor
	
	delete from Salarii_CategoriiAngajati where LunaID=@LunaID
	delete from sal_Luni where LunaID = @LunaID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE CountConturiPerBanca  AS

select Banci.BancaID, count(conturiangajati.ContID) as nocontangajati,  count(conturi.ContID) as nocontangajator from banci
left join conturiangajati on conturiangajati.BancaID=Banci.BancaID
left join conturi on conturi.BancaID = Banci.BancaID
group by Banci.BancaID



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE GetAngajatConturiBanca

	(
		@AngajatID int
	)

AS

	select ConturiAngajati.*, (Banci.CodBanca + ' - ' + Banci.Nume) as NumeBanca, Banci.Filiala from ConturiAngajati
		left join Banci on Banci.BancaID = ConturiAngajati.BancaID 
		where AngajatID=@AngajatID

	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


--Autor: Dovlecel Vlad
--Descriere: Returneaza un angajat impreuna cu norma sa

CREATE PROCEDURE dbo.GetAngajatFunctii
(
		@AngajatID int
)

AS
select *

from ( Functii fct inner join IstoricFunctii ifct on fct.FunctieID = ifct.FunctieID ) inner join  Angajati ang on ifct.AngajatID = ang.AngajatID

where ang.AngajatID = @AngajatID

order by ifct.DataStart

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetAngajatPersoaneInIntretinere 
(
	@AngajatID int
)
as 
select ID,Nume,Prenume,CNP, Calitate,Invaliditate
from AngajatPersoaneInIntretinere
where AngajatID=@AngajatID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Autor: Muntean Raluca Cristina
--Descriere: returneaza toti anii pentru care sunt calculate salariile:
--(camp necesar pentru fisele fiscale)
CREATE PROCEDURE dbo.GetAniSal_Salarii
AS
SELECT     YEAR(Sal_Luni.Data) AS An
FROM         Sal_Luni INNER JOIN
                      sal_StatDePlata ON Sal_Luni.LunaID = sal_StatDePlata.LunaID
GROUP BY YEAR(Sal_Luni.Data)
ORDER BY YEAR(Sal_Luni.Data) desc

RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


-- Autor : Gosman Rares
 -- Denumire : GetCheckupuriAngajat
 -- Descriere : Intoarce o lista cu checkupuri angajat


CREATE PROCEDURE GetCheckupuriAngajat
(
	@AngajatID int
	
)
as

select * from Checkupuri 
left join Angajati on Checkupuri.ResponsabilID = Angajati.AngajatID
where Checkupuri.AngajatID=@AngajatID order by DataEfectuarii desc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


-- Autor : Gosman Rares
 -- Denumire : GetIDepartamente
 -- Descriere : Intoarce o lista cu departemente


CREATE PROCEDURE GetDepartamente
(
	@DeptParinte int = null
	
)
as

select * from Departamente where DeptParinte = @DeptParinte order by Cod asc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


-- Autor : Gosman Rares
 -- Denumire : GetCheckupuriAngajat
 -- Descriere : Intoarce o lista cu eval. psihologice angajat


CREATE PROCEDURE dbo.GetEvaluariPsihologiceAngajat
(
	@AngajatID int
	
)
as

select EvaluariPsihologice.* ,  TipuriRapoarte.Denumire as DenumireTipRaport
from EvaluariPsihologice
left join TipuriRapoarte on EvaluariPsihologice.TipRaportID = TipuriRapoarte.TipRaportID 
where EvaluariPsihologice.AngajatID=@AngajatID 
order by Data desc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


-- Autor: Dovlecel Vlad
-- Functionalitate: intoarce intreruperea corespunzatoare id-ului si angajatului date ca parametrii
--
CREATE PROCEDURE GetIntervalAngajatIntrerupereByID
(
	@AngajatID int,
	@IntrerupereID int
)

AS

select *

from AngajatiIntreruperi

where AngajatID= @AngajatID and AngajatIntrerupereID=@IntrerupereID
Order by DataStart

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


--intoarce  orice tip de absenta

CREATE PROCEDURE GetIntervaleAngajatIntreruperi
(
	@AngajatID int,
	@IntervalID int
)

AS

select *

from AngajatiIntreruperi

where AngajatID=@AngajatID and @IntervalID!=AngajatIntrerupereID

Order by DataStart

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


-- Autor: Dovlecel Vlad
-- Functionalitate: intoarce toate intervalele de absente specifice unui angajat, 
--		 care contin zile din luna si anul corespunzatoare datei curente
--
CREATE PROCEDURE GetIntervaleAngajatIntreruperiLuna
(
@AngajatID int,
--@Luna int,
--@An int
@DataCurenta datetime
)

AS

select *

from AngajatiIntreruperi

--where AngajatID= @AngajatID and (( datepart( mm,DataStart )=@Luna and datepart( yy,DataStart ) = @An ) or ( datepart( mm,DataEnd )=@Luna and datepart( yy,DataEnd ) = @An ))
where AngajatID= @AngajatID and 
	(( datepart( mm,DataStart ) = month( @DataCurenta ) and 
		datepart( yy,DataStart ) = year( @DataCurenta )) or
	 ( datepart( mm,DataEnd ) = month( @DataCurenta ) and 
		datepart( yy,DataEnd ) = year( @DataCurenta )) or
	( DataStart <= @DataCurenta and
		@DataCurenta <= DataEnd ))

Order by DataStart

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetIstoricCategoriiAngajat
(
	@AngajatID int
)
as

select Categorii.*,  IstoricCategoriiAngajati.DataStart from IstoricCategoriiAngajati
	left join Categorii on Categorii.CategorieID = IstoricCategoriiAngajati.CategorieID
where IstoricCategoriiAngajati.AngajatID = @AngajatID 
order by DataStart desc

return

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetIstoricCentreCostAngajat
(
	@AngajatID int
)
as

select CentreCost.*, (CAST(CentreCost.Cod as varchar(10)) + ' - ' + CentreCost.Nume) as NumeFull, IstoricCentreCost.DataStart 
from IstoricCentreCost
	left join CentreCost on CentreCost.CentruCostID = IstoricCentreCost.CentruCostID
where IstoricCentreCost.AngajatID = @AngajatID 
order by DataStart desc

return

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE GetIstoricFunctiiAngajat
(
	@AngajatID int
)
as

select Functii.*, (Cast(Cod as nvarchar(6)) + ' - ' + Nume ) as NumeFull , IstoricFunctii.DataStart 
from IstoricFunctii
	left join Functii on Functii.FunctieID = IstoricFunctii.FunctieID
where IstoricFunctii.AngajatID = @AngajatID 
order by DataStart desc

return

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


-- Autor : Gosman Rares
 -- Denumire : GetIstoricTrainingAngajat
 -- Descriere : Intoarce o lista cu Istoricul Trainingului efectuat de angajat


CREATE PROCEDURE GetIstoricTrainingAngajat
(
	@AngajatID int,
	@Tip int
)
as

select * from IstoricTraining 
left join Traininguri on IstoricTraining.TrainingID = Traininguri.TrainingID
where IstoricTraining.AngajatID=@AngajatID and Intern=@Tip order by DataEnd desc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Autor: Muntean Raluca Cristina
--returneaza lunile din an pentru care sunt calculate salariile in baza de date
CREATE PROCEDURE dbo.GetLuni_An
(
	--parametru
	@An int
)
AS
SELECT     MONTH(Sal_Luni.Data) AS Luna,
		   CASE MONTH(Sal_Luni.Data)
				WHEN 1 THEN 'Ianuarie'
				WHEN 2 THEN 'Februarie'
				WHEN 3 THEN 'Martie'
				WHEN 4 THEN 'Aprilie'
				WHEN 5 THEN 'Mai'
				WHEN 6 THEN 'Iunie'
				WHEN 7 THEN 'Iulie'
				WHEN 8 THEN 'August'
				WHEN 9 THEN 'Septembrie'
				WHEN 10 THEN 'Octombrie'
				WHEN 11 THEN 'Noiembrie'
				WHEN 12 THEN 'Decembrie'
			END AS Denumire,Sal_Luni.LunaID, Sal_Luni.ProcentInflatie
FROM         Sal_Salarii INNER JOIN
                      Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID
WHERE     (YEAR(Sal_Luni.Data) = @An)
GROUP BY MONTH(Sal_Luni.Data),Sal_Luni.LunaID,Sal_Luni.ProcentInflatie
ORDER BY MONTH(Sal_Luni.Data)
RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE GetPasapoarteAngajat
(
	@AngajatID bigint
)
AS

select *
from Pasapoarte
where AngajatID=@AngajatID
order by ValabilPanaLa desc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


-- Autor : Gosman Rares
 -- Denumire : GetReferinteAngajat
 -- Descriere : Intoarce o lista cu referintele angajatului


CREATE PROCEDURE GetReferinteAngajat
(
	@AngajatID int
	
)
as

select * from Referinte
where AngajatID=@AngajatID order by Data desc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



/*
*Author: Popa Ionel
*Description: Calculeza sumele pt un anumit cod din imp100T.txt necesara
*			la declaratia100
*/
CREATE  PROCEDURE dbo.Get_imp100T_sums
	(
		@input_code int,
		@input_month int,
		@output_suma_datorata int output,
		@output_suma_deductibila int output,
		@output_suma_plata int output,
		@output_suma_restituit int output
	)
AS
	set @output_suma_datorata = (
		select isnull (
			case @input_code 
				when 18 then cast(sum(impozit) as bigint) 
				when 33 then cast(sum(CASAngajat) as bigint)
				when 34 then cast(sum(AjutorSomaj) as bigint)
				when 35 then cast(sum(SanatateAngajator) as bigint)
				when 36 then cast(sum(SUMAA) as bigint)
				when 38 then cast(sum(CASAngajator) as bigint)
				when 39 then cast(sum(SomajAngajator) as bigint)
				when 40 then cast(sum(SanatateAngajator) as bigint)
				when 43 then cast(sum(SanatateAngajator) as bigint)
				when 46 then cast(sum(SanatateAngajator) as bigint)
			end
			,0 )as total
		from sal_salarii
		where LunaID =(SELECT LunaID FROM Sal_Luni WHERE (MONTH(Data) = @input_month))
		)
	
	set @output_suma_deductibila = 0
	set @output_suma_plata = @output_suma_datorata
	set @output_suma_restituit = 0
	
	RETURN 



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		Mircea Albutiu, PSE RO BS TH
* Nume:			InsertUpdateCarnetMunca
* Descriere:	Adauga sa modifica un carnet de munca
*/
CREATE PROCEDURE InsertUpdateCarnetMunca
(
	@AngajatID int,
	@Serie nvarchar(5),
	@Numar nvarchar(10),
	@Emitent nvarchar(50),
	@DataEmiterii datetime,
	@NrInregITM nvarchar(25)
)
as
declare @rc int
set @rc = 0

begin tran InsertUpdateCarnetMunca

select @rc = count(AngajatID) from CarneteMunca where AngajatID = @AngajatID

if(@rc = 0)
begin	--Insert carnet de munca
	insert into CarneteMunca with (xlock) (AngajatID, Serie, Numar, Emitent, DataEmiterii, NrInregITM)
		values (@AngajatID, @Serie, @Numar, @Emitent, @DataEmiterii, @NrInregITM)
	if(@@ERROR <> 0)
	begin
		rollback tran InsertUpdateCarnetMunca
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertUpdateCarnetMunca
		set @rc = 0
	end
end
else
begin	--Update carnet de munca
	update CarneteMunca with (xlock) set Serie = @Serie, Numar = @Numar, Emitent = @Emitent, 
		DataEmiterii = @DataEmiterii, NrInregITM = @NrInregITM
		where AngajatID = @AngajatID
	if(@@ERROR <> 0)
	begin
		rollback tran InsertUpdateCarnetMunca
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertUpdateCarnetMunca
		set @rc = 0
	end
end

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteIstoricFunctie
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul IstoricFunctii
*/
CREATE PROCEDURE InsertUpdateDeleteAngajatIntreruperi
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@AngajatIntrerupereID int,
	@AngajatID int,
	@DataStart datetime, 
	@DataEnd datetime,
	@Descriere ntext
	--@old_DataStart datetime
)

as

declare @rc int
set @rc = 0

begin tran IUDIstoricIntreruperi

if(@tip_actiune = 0)
begin	--Insert istoric intreruperi angajat
	insert into AngajatiIntreruperi with(xlock) ( AngajatID, DataStart, DataEnd, Descriere) 
		values ( @AngajatID, @DataStart, @DataEnd, @Descriere)
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
	update AngajatiIntreruperi with(xlock) set AngajatID = @AngajatID, DataStart = @DataStart, DataEnd = @DataEnd, Descriere = @Descriere 
		--where AngajatID = @AngajatID and DataStart = @old_DataStart
		where AngajatIntrerupereID = @AngajatIntrerupereID
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
	delete from AngajatiIntreruperi with(xlock) 
		--where AngajatID = @AngajatID and DataStart = @DataStart
		where AngajatIntrerupereID = @AngajatIntrerupereID
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

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Rares Gosman,  PSE RO BS TH
* Nume:			InsertUpdateDeleteCheckup
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Checkupuri
*/
CREATE PROCEDURE InsertUpdateDeleteCheckup
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@CheckupID int,
	@NecesarInstruire nvarchar(255),
	@DataUrmatorului datetime,
	@ResponsabilID int,
	@AngajatID int,
	@DataEfectuarii datetime,
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

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteCont
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Conturi
*/
CREATE PROCEDURE InsertUpdateDeleteContAngajat
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@ContID int,
	@BancaID int,
	@AngajatID int,
	@NumarCont nvarchar(50),
	@Moneda varchar(3),
	@Activ bit
)

as

declare @rc int
set @rc = 0

begin tran IUDConturiAngajati

if(@tip_actiune = 0)
begin	--Insert banca
             if exists(select * from ConturiAngajati where ConturiAngajati.Activ=1 and AngajatID=@AngajatID ) 
             begin
               if (@Activ=1) 
                 begin
                    save tran InactCont
                    update ConturiAngajati with(xlock) set Activ=0
  	       where  ConturiAngajati. Activ=1  and AngajatID=@AngajatID
                 end
             end

	insert into ConturiAngajati with(xlock) (AngajatID, BancaID, NumarCont, Moneda,Activ) 
		values (@AngajatID, @BancaID, @NumarCont, @Moneda,@Activ)
	if(@@ERROR <> 0)
	begin
                          rollback tran InactCont
		rollback tran IUDConturiAngajati
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDConturiAngajati
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update banca
           if exists(select * from ConturiAngajati where ConturiAngajati.Activ=1 and AngajatID=@AngajatID ) 
           begin
               if (@Activ=1) 
                 begin
                    save tran InactCont
                    update ConturiAngajati set Activ=0
  	       where  ConturiAngajati. Activ=1  and AngajatID=@AngajatID
                 end
             end

	update ConturiAngajati with(xlock) set BancaID = @BancaID, NumarCont = @NumarCont, Moneda = @Moneda,Activ=@Activ
	where ContId=@ContID
	if(@@ERROR <> 0)
	begin
		rollback tran InactCont
		rollback tran IUDConturiAngajati
		set @rc = @@ERROR
	end
	else
	begin                 
		commit tran IUDConturiAngajati
		set @rc = 0
	end

end
else if(@tip_actiune = 2)
begin	--Delete banca
	delete from ConturiAngajati with(xlock) where ContID = @ContID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDConturiAngajati
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDConturiAngajati
		set @rc = 0
	end
end
else
	rollback tran IUDConturiAngajati

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Rares Gosman,  PSE RO BS TH
* Nume:			InsertUpdateDeleteDepartament
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Departamente
*/
CREATE PROCEDURE InsertUpdateDeleteDepartament
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@DepartamentID int,
	@Denumire nvarchar(255),
	@Cod nvarchar(10), 
	@SefID int = null,
	@InlocSefID int = null,
	@DeptParinte int


)

as

declare @rc int
set @rc = 0

begin tran IUDDepartament

if( @SefID = -1 )
	set @SefID = null

if( @InlocSefID = -1 )
	set @InlocSefID = null

if(@tip_actiune = 0)
begin	--Insert Departament
	insert into Departamente with(xlock) (Denumire, Cod ,SefID,InlocSefID,DeptParinte) 
		values (@Denumire, @Cod,@SefID,@InlocSefID, @DeptParinte)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDDepartament
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDDepartament
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--UpdateDepartament
	update  Departamente with(xlock) set Denumire = @Denumire, Cod = @Cod,SefID = @SefID, InlocSefID = @InlocSefID, DeptParinte = @DeptParinte
		where DepartamentID = @DepartamentID 
	if(@@ERROR <> 0)
	begin
		rollback tran IUDDepartament
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDDepartament
		set @rc = 0
	end
/*	if( @rc=0 )
		update Angajati set ang.SefID=@SefID 
		where AngajatID in (select AngajatID from IstoricAngajatDepartament d inner join Angajati ang on d.AngajatID=ang.AngajatID and d.DataStart=(SELECT MAX(dep.DataStart)
															                            FROM          IstoricAngajatDepartament dep
															                            WHERE      ang.AngajatID = dep.AngajatID)*/

end
else if(@tip_actiune = 2)
begin	--Delete Departament
	delete from Departamente with(xlock) where DepartamentID = @DepartamentID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDDepartament
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDDepartament
		set @rc = 0
	end
end
else
	rollback tran IUDDepartament

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Rares Gosman,  PSE RO BS TH
* Nume:			InsertUpdateDeleteEvaluarePsihologica
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul EvaluariPsihologice
*/
CREATE PROCEDURE InsertUpdateDeleteEvaluarePsihologica
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@EvalPsihologicaID int,
	@Data datetime,
	@TipRaportID int,
	@AngajatID int,
	@Raport nvarchar(255) = null



)

as

declare @rc int
set @rc = 0

begin tran IUDEvaluarePsihologica

if(@tip_actiune = 0)
begin	--Insert EvaluarePsihologica
	insert into EvaluariPsihologice with(xlock) 

		(
			Data,
			TipRaportID,
			AngajatID,
			Raport
		)		 
	
		values 

		(

			@Data,
			@TipRaportID,
			@AngajatID,
			@Raport
		)		 


	if(@@ERROR <> 0)
	begin
		rollback tran IUDEvaluarePsihologica
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDEvaluarePsihologica
		set @rc = 0
		select @@identity as NewID
	end
end
else if(@tip_actiune = 1)
begin	--UpdateEvaluarePsihologica
	

	declare @old_file nvarchar(255)

	set @old_file = (select Raport from EvaluariPsihologice where	EvalPsihologicaID = @EvalPsihologicaID )

	if( @Raport=null ) set @Raport = @old_file

	update  EvaluariPsihologice with(xlock) set 
		
	Data = @Data,
	TipRaportID = @TipRaportID,
	Raport = @Raport

	where EvalPsihologicaID = @EvalPsihologicaID 
	

	if(@@ERROR <> 0)
	begin
		rollback tran IUDEvaluarePsihologica
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDEvaluarePsihologica
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete EvaluarePsihologica
	delete from EvaluariPsihologice with(xlock) where EvalPsihologicaID = @EvalPsihologicaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDEvaluarePsihologica
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDEvaluarePsihologica
		set @rc = 0
	end
end
else
	rollback tran IUDEvaluarePsihologica

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteIstoricCategorie
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul IstoricCategoriiAngajati
*/
CREATE PROCEDURE InsertUpdateDeleteIstoricCategorie
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@AngajatID int,
	@CategorieID int,
	@DataStart datetime, 
	@old_DataStart datetime = '19000101'
)

as

declare @rc int
set @rc = 0

begin tran IUDIstoricCategorie

if(@tip_actiune = 0)
begin	--Insert istoric
	insert into IstoricCategoriiAngajati with(xlock) (AngajatID, DataStart, CategorieID) 
		values (@AngajatID, @DataStart, @CategorieID)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricCategorie
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricCategorie
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--UpdateIstoric
	update IstoricCategoriiAngajati with(xlock) set DataStart = @DataStart, CategorieID = @CategorieID 
		where AngajatID = @AngajatID and DataStart = @old_DataStart
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricCategorie
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricCategorie
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete istoric
	delete from IstoricCategoriiAngajati with(xlock) where AngajatID = @AngajatID and DataStart = @DataStart
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricCategorie
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricCategorie
		set @rc = 0
	end
end
else
	rollback tran IUDIstoricCategorie

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteIstoricCentruCost
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul IstoricAngajatDepartament
*/
CREATE PROCEDURE InsertUpdateDeleteIstoricCentruCost
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@AngajatID int,
	@CentruCostID int,
	@DataStart datetime, 
	@old_DataStart datetime = '19000101'
)

as

declare @rc int
set @rc = 0

begin tran IUDIstoricCentruCost

if(@tip_actiune = 0)
begin	--Insert istoric
	insert into IstoricCentreCost with(xlock) (AngajatID, DataStart, CentruCostID) 
		values (@AngajatID, @DataStart, @CentruCostID)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricCentruCost
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricCentruCost
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--UpdateIstoric
	update IstoricCentreCost with(xlock) set DataStart = @DataStart, CentruCostID = @CentruCostID 
		where AngajatID = @AngajatID and DataStart = @old_DataStart
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricCentruCost
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricCentruCost
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete istoric
	delete from IstoricCentreCost with(xlock) where AngajatID = @AngajatID and DataStart = @DataStart
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricCentruCost
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricCentruCost
		set @rc = 0
	end
end
else
	rollback tran IUDIstoricCentruCost

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteIstoricFunctie
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul IstoricFunctii
*/
CREATE PROCEDURE InsertUpdateDeleteIstoricFunctie
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@AngajatID int,
	@FunctieID int,
	@DataStart datetime, 
	@old_DataStart datetime = '19000101'
)

as

declare @rc int
set @rc = 0

begin tran IUDIstoricFunctie

if(@tip_actiune = 0)
begin	--Insert istoric
	insert into IstoricFunctii with(xlock) (AngajatID, DataStart, FunctieID) 
		values (@AngajatID, @DataStart, @FunctieID)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricFunctie
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricFunctie
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--UpdateIstoric
	update IstoricFunctii with(xlock) set DataStart = @DataStart, FunctieID = @FunctieID 
		where AngajatID = @AngajatID and DataStart = @old_DataStart
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricFunctie
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricFunctie
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete istoric
	delete from IstoricFunctii with(xlock) where AngajatID = @AngajatID and DataStart = @DataStart
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricFunctie
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricFunctie
		set @rc = 0
	end
end
else
	rollback tran IUDIstoricFunctie

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteIstoricTraining
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul IstoricTraining
*/
CREATE PROCEDURE InsertUpdateDeleteIstoricTraining
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@IstoricTrainingID int,
	@AngajatID int,
	@TrainingID int,
	@DataStart datetime, 
	@DataEnd datetime
	
)

as

declare @rc int
set @rc = 0

begin tran IUDIstoricTraining

if(@tip_actiune = 0)
begin	--Insert istoric
	insert into IstoricTraining with(xlock) (AngajatID, TrainingID,DataStart, DataEnd) 
		values (@AngajatID,@TrainingID, @DataStart, @DataEnd)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricTraining
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricTraining
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--UpdateIstoric
	update IstoricTraining with(xlock) set DataStart = @DataStart, DataEnd=@DataEnd,TrainingID = @TrainingID 
		where IstoricTrainingID = @IstoricTrainingID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricTraining
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricTraining
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete istoric
	delete from IstoricTraining with(xlock) where IstoricTrainingID=@IstoricTrainingID 
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricTraining
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricTraining
		set @rc = 0
	end
end
else
	rollback tran IUDIstoricTraining

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


--Author Dovlecel Vlad
--modificat: 11.01.2005 : adaugat la tabela DataInregistrare, NrArticol, LunaRetinere

CREATE PROCEDURE InsertUpdateDeleteLichidareAngajat
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

	Update Angajati set PerioadaDeterminata=1, DataPanaLa=DateAdd( dd, -1,@DataLichidare )
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
		Carti=@Carti, CD=@CD, DataLichidare=@DataInregistrare, NrArticol=@NrArticol, LunaRetinere=@LunaRetinere
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

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Alexandru Mihai, PSE RO BS TH
* Nume:			InsertUpdateActivitati
* Descriere:	Adauga sa modifica o activitate
* Istorie:		Mircea Albutiu, PSE RO BS TH
*					 - adaugare update
*/
CREATE PROCEDURE InsertUpdateDeletePasaport
(
	@tip_actiune int = 0,
	@PasaportID int,
	@AngajatID int,
	@Serie nvarchar(10),
	@Numar bigint,
	@EliberatDe nvarchar(50),
	@DataEliberarii datetime,
	@ValabilPanaLa datetime,
	@Activ bit = 1
)
as

declare @rc int
set @rc = 0

begin tran InsertUpdatePasaport

--select @rc = count(AngajatID) from Pasapoarte where AngajatID = @AngajatID

if(@tip_actiune = 0)
begin	--Insert Pasaport
	insert into Pasapoarte with (xlock) (AngajatID, Serie, Numar, EliberatDe, DataEliberarii, ValabilPanaLa, Activ)
		values (@AngajatID, @Serie, @Numar, @EliberatDe, @DataEliberarii, @ValabilPanaLa, @Activ)
	if (@@ERROR <> 0)
	begin
		rollback tran InsertUpdatePasaport
		set @rc = @@ERROR
	end
	else
	begin
		set @PasaportID=@@IDENTITY
		commit tran InsertUpdatePasaport
		set @rc = 0
	end
end
else if( @tip_actiune=1 )
begin	--Update Pasaport
	update Pasapoarte with (xlock) set AngajatID = @AngajatID, Serie = @Serie, Numar = @Numar, EliberatDe = @EliberatDe, 
		DataEliberarii = @DataEliberarii, ValabilPanaLa = @ValabilPanaLa, Activ = @Activ
		where PasaportID = @PasaportID
	if (@@ERROR <> 0)
	begin
		rollback tran InsertUpdatePasaport
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertUpdatePasaport
		set @rc = 0
	end
end
else if( @tip_actiune=2 )
begin
	delete from Pasapoarte where PasaportID = @PasaportID
	if (@@ERROR <> 0)
	begin
		rollback tran InsertUpdatePasaport
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertUpdatePasaport
		set @rc = 0
	end
end
else 
	rollback tran InsertUpdatePasaport

if(@tip_actiune>=0 and @tip_actiune<=2)
	if(@tip_actiune<>2 and @Activ=1)
		update Pasapoarte with(xlock) set Activ=0 where AngajatID=@AngajatID and PasaportID<>@PasaportID

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateDeleteReferinta
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul Referinta
*/
CREATE PROCEDURE InsertUpdateDeleteReferinta
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@ReferintaID int,
	@AngajatID int,
	@Titlu nvarchar(255),
	@Descriere ntext = null,
	@Data datetime
)

as

declare @rc int
set @rc = 0

begin tran IUDReferinta

if(@tip_actiune = 0)
begin	--Insert istoric
	insert into Referinte with(xlock) (AngajatID,Titlu,Descriere,Data) 
		values (@AngajatID,@Titlu, @Descriere, @Data)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDReferinta
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDReferinta
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--UpdateIstoric
	update Referinte with(xlock) set Titlu = @Titlu, Data=@Data,Descriere=@Descriere 
		where ReferintaID = @ReferintaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDReferinta
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDReferinta
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete istoric
	delete from Referinte with(xlock) where ReferintaID=@ReferintaID 
	if(@@ERROR <> 0)
	begin
		rollback tran IUDReferinta
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDReferinta
		set @rc = 0
	end
end
else
	rollback tran IUDReferinta

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		Alexandru Mihai, PSE RO BS TH
* Nume:			InsertUpdateActivitati
* Descriere:	Adauga sa modifica o activitate
* Istorie:		Mircea Albutiu, PSE RO BS TH
*					 - adaugare update
*/
CREATE PROCEDURE InsertUpdatePasaport
(
	@AngajatID int,
	@Serie nvarchar(10),
	@Numar bigint,
	@EliberatDe nvarchar(50),
	@DataEliberarii datetime,
	@ValabilPanaLa datetime
)
as

declare @rc int
set @rc = 0

begin tran InsertUpdatePasaport

select @rc = count(AngajatID) from Pasapoarte where AngajatID = @AngajatID

if(@rc = 0)
begin	--Insert Pasaport
	insert into Pasapoarte with (xlock) (AngajatID, Serie, Numar, EliberatDe, DataEliberarii, ValabilPanaLa)
		values (@AngajatID, @Serie, @Numar, @EliberatDe, @DataEliberarii, @ValabilPanaLa)
	if (@@ERROR <> 0)
	begin
		rollback tran InsertUpdatePasaport
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertUpdatePasaport
		set @rc = 0
	end
end
else
begin	--Update Pasaport
	update Pasapoarte with (xlock) set Serie = @Serie, Numar = @Numar, EliberatDe = @EliberatDe, 
		DataEliberarii = @DataEliberarii, ValabilPanaLa = @ValabilPanaLa
		where AngajatID = @AngajatID	
	if (@@ERROR <> 0)
	begin
		rollback tran InsertUpdatePasaport
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertUpdatePasaport
		set @rc = 0
	end
end

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		
* Nume:			InsertUpdateSituatieMilitara
* Descriere:	Adauga sa modifica situatia militara
*/
CREATE PROCEDURE InsertUpdateSituatieMilitara
(
	@AngajatID int,
	@SerieLivret nvarchar(5),
	@NumarLivret nvarchar(10),
	@EvidentaCMJ nvarchar(100),
	@DataIntrareEvidenta datetime,
	@Gradul nvarchar(50),
	@SpecialitatiMilitare nvarchar(100)
)
as
declare @rc int
set @rc = 0

begin tran InsertUpdateSituatieMilitara

select @rc = count(AngajatID) from SituatieMilitara where AngajatID = @AngajatID

if(@rc = 0)
begin	--Insert situatie militara
	insert into SituatieMilitara with (xlock) (AngajatID, SerieLivret, NumarLivret, EvidentaCMJ, DataIntrareEvidenta, Gradul, SpecialitatiMilitare)
		values (@AngajatID, @SerieLivret, @NumarLivret, @EvidentaCMJ, @DataIntrareEvidenta, @Gradul, @SpecialitatiMilitare)
	if(@@ERROR <> 0)
	begin
		rollback tran InsertUpdateSituatieMilitara
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertUpdateSituatieMilitara
		set @rc = 0
	end
end
else
begin	--Update situatie militara
	update SituatieMilitara with (xlock) set SerieLivret = @SerieLivret, NumarLivret = @NumarLivret, EvidentaCMJ = @EvidentaCMJ, 
		DataIntrareEvidenta = @DataIntrareEvidenta, Gradul = @Gradul, SpecialitatiMilitare=@SpecialitatiMilitare
		where AngajatID = @AngajatID
	if(@@ERROR <> 0)
	begin
		rollback tran InsertUpdateSituatieMilitara
		set @rc = @@ERROR
	end
	else
	begin
		commit tran InsertUpdateSituatieMilitara
		set @rc = 0
	end
end

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE PersoanaInIntretinereById 
(
	@PersID int
)
as 
select AngajatID,Nume,Prenume,CNP, 
Calitate,
Invaliditate
from AngajatPersoaneInIntretinere  
where [AngajatPersoaneInIntretinere].[ID]=  @PersID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE UpdateContAngajat
(	
	@ContID int,
	@BancaID int,
	@AngajatID int,
	@NumarCont nvarchar(50),
	@Moneda varchar(3),
	@Activ bit
)

as

declare @rc int
set @rc = 0

begin tran IUDConturiAngajati
               if (@Activ=1) 
                 begin
                    save tran InactCont
                    update ConturiAngajati set Activ=0
  	       where  ConturiAngajati. Activ=1  and AngajatID=@AngajatID
                 end

	update ConturiAngajati with(xlock)
                       set BancaID = @BancaID, 
                             NumarCont = @NumarCont,
                              Moneda = @Moneda,
		    Activ=@Activ
	where ContId=@ContID
	if(@@ERROR <> 0)
	begin
		rollback tran InactCont
		rollback tran IUDConturiAngajati
		set @rc = @@ERROR
	end
	else
	begin                 
		commit tran IUDConturiAngajati
		set @rc = 0
	end

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.conturi_SetCurrentContID

	(
		@AngajatID int,
		@ContID int
	)

AS
-- setez activ = 0 pentru toate conturile
	UPDATE    ConturiAngajati
	SET              Activ = 0
	WHERE     AngajatID = @AngajatID
	
-- setez contul curent ca activ
UPDATE ConturiAngajati
SET Activ = 1
WHERE AngajatID = @AngajatID AND ContID = @ContID
		
	RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
	Author: Popa Ionel
	Description: Inserare de alerte sepcifice unui angajat
	Params: id-ul angajatului si un sir de caractere ce contine datele despre alerte (descriere1, data1, perioadaCritica1,activ1, descriere2, data2, perioadaCritica2, activ2 ......)
*/

CREATE PROCEDURE insertAlerte
(
	@AngajatID int,
	@alerte nvarchar(2056)
)
AS

declare @leftText nvarchar(2056)
declare @piece nvarchar(256)
declare @pos int
--datele unei alerte
declare @descriere nvarchar(256)
declare @dataexpirare datetime
declare @perioadacritica int
declare @activa int
declare @firstTime int

set @firstTime = 1
set @leftText = @alerte
while  patindex('%,%', @leftText)  <> 0  
begin
	if @firstTime = 1 --verifica daca este prima iteratie
	begin
		set @leftText = @alerte + ','
		set @firstTime = 0
	end

	set @pos = patindex('%,%', @leftText)
	set @piece = substring( @leftText, 0, @pos )
	set @descriere = @piece	

	set @leftText = substring( @leftText, @pos + 1, len(@leftText) - @pos)
	set @pos = patindex('%,%', @leftText)
	set @piece = substring( @leftText, 0, @pos )
	set @dataexpirare =(select dbo.FormatDataFromString( @piece, '.'))

	set @leftText = substring( @leftText, @pos + 1, len(@leftText) - @pos)
	set @pos = patindex('%,%', @leftText)
	set @piece = substring( @leftText, 0, @pos )
	set @perioadacritica = cast(@piece as int)	

	set @leftText = substring( @leftText, @pos + 1, len(@leftText) - @pos)
	set @pos = patindex('%,%', @leftText)
	set @piece = substring( @leftText, 0, @pos )
	if @piece = 'activa'
	begin
		set @activa = 1
	end
	else
	begin
		set @activa = 0
	end

	--Inseram in baza de date
	insert into alerte (angajatid, dataexpirare, perioadacritica, descriere, activ)
	values (@AngajatID,@dataexpirare, @perioadacritica,@descriere, @activa)


	set @leftText = substring( @leftText, @pos + 1, len(@leftText) - @pos)
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.sal_DeletePersoanaInIntretinere

	(
		@ID int
	)

AS
delete from AngajatPersoaneInIntretinere with(xlock) where  [AngajatPersoaneInIntretinere].[ID]= @ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE sal_DeleteSalariu
	(
		@ID int
		
	)

AS
	
	DELETE FROM Sal_Salarii WHERE (ID=@ID)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


---Autor: Muntean Raluca Cristina
--returneaza cate luni a lucrat in firma angajatul cu id-ul trimis ca parametru in trimestrul
--anterior(trimestrul trimis ca parametru)
CREATE PROCEDURE dbo.sal_GetAllAngLuniPeTrim
(
		@Trim int,
		@AngajatorID int
)
AS

--data in care a inceput trimestrul  si data activa
DECLARE @dataIncTrim nvarchar(10), @dataActiva datetime

--setare data activa
SET @dataActiva=(SELECT Data
                FROM Sal_Luni
                WHERE Activ=1)
          
--setare data inceperii trimestrului trimis ca parametru
SET @dataIncTrim = (CASE @Trim
					WHEN 1 THEN  '1/1/'+CAST(YEAR(@dataActiva) AS NVARCHAR(4)) 
					WHEN 2 THEN  '4/1/'+CAST(YEAR(@dataActiva) AS NVARCHAR(4)) 
					WHEN 3 THEN  '7/1/'+CAST(YEAR(@dataActiva) AS NVARCHAR(4)) 
					WHEN 4 THEN  '10/1/'+CAST((YEAR(@dataActiva)-1) AS NVARCHAR(4)) 
				  END)
--returneaza cate luni au lucrat angajatii in trimestru trimis ca parametru
SELECT COUNT(Sal_Salarii.AngajatID) AS NrLuni, Sal_Salarii.AngajatID, Angajati.NumeIntreg
FROM   Sal_Luni INNER JOIN
       Sal_Salarii ON Sal_Luni.LunaID = Sal_Salarii.LunaID INNER JOIN
       Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
WHERE Sal_Luni.Data>=CAST(@dataIncTrim AS datetime(8)) AND Angajati.AngajatorID=@AngajatorID AND Sal_Luni.Data<>@dataActiva AND Angajati.Activ=0
GROUP BY Sal_Salarii.AngajatID, Angajati.NumeIntreg 
ORDER BY Angajati.NumeIntreg
	
RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


--Modificat: Dovlecel Vlad, 06/12/2004
/*
	Author: unknown
	Description: selecteaza situatia lunara a unui angajat dintr-o anumita luna
*/
CREATE PROCEDURE dbo.sal_GetAllSituatiiLunare

(
@AngajatID int,
@LunaID int
)
	
AS

	/*SELECT  sal_SituatieLunaraAngajati.*,sal_Luni.Data as Luna
	FROM         sal_SituatieLunaraAngajati  inner join sal_Luni on sal_SituatieLunaraAngajati.LunaID = sal_Luni.LunaID
	where AngajatID = @AngajatID
	ORDER BY Data DESC*/
   --Modificat: Cristina Muntean ... returneaza doar situatiile de pe luna activa
	SELECT  sla.*,sal_Luni.Data as Luna, ca.Denumire, inv.Nume
	FROM (( sal_SituatieLunaraAngajati sla  inner join sal_Luni on sla.LunaID = sal_Luni.LunaID ) 
		inner join Salarii_CategoriiAngajati ca on sla.CategorieID=ca.CategorieID )
		inner join Invaliditati inv on sla.Invaliditate=inv.InvaliditateID
	where AngajatID = @AngajatID and sal_Luni.LunaID = @LunaID
	ORDER BY Data DESC
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


---Autor: Muntean Raluca Cristina
--returneaza cate luni a lucrat, in tipul semestrului anterior, in 
--firma angajatul cu id-ul trimis ca parametru
CREATE PROCEDURE dbo.sal_GetLuniLucrPeTrim
(
		@AngajatID int,
		@Trim int,
		@NrLuni int=-1 OUTPUT
)
AS

--data in care a inceput trimestrul  si data activa
DECLARE @dataIncTrim nvarchar(10), @dataActiva datetime

--setare data activa
SET @dataActiva=(SELECT Data
                FROM Sal_Luni
                WHERE Activ=1)
          
--setare data inceperii trimestrului trimis ca parametru
SET @dataIncTrim = (CASE @Trim
					WHEN 1 THEN  '1/1/'+CAST(YEAR(@dataActiva) AS NVARCHAR(4)) 
					WHEN 2 THEN  '4/1/'+CAST(YEAR(@dataActiva) AS NVARCHAR(4)) 
					WHEN 3 THEN  '7/1/'+CAST(YEAR(@dataActiva) AS NVARCHAR(4)) 
					WHEN 4 THEN  '10/1/'+CAST((YEAR(@dataActiva)-1) AS NVARCHAR(4)) 
				  END)
--returneaza cate luni a lucrat angajatul in trimestru trimis ca parametru
SELECT @NrLuni=COUNT(AngajatID)
FROM   Sal_Luni INNER JOIN
       Sal_Salarii ON Sal_Luni.LunaID = Sal_Salarii.LunaID
WHERE AngajatID=@AngajatID AND Sal_Luni.Data>=CAST(@dataIncTrim AS datetime(8)) AND Sal_Luni.Data<>@dataActiva
	
RETURN @NrLuni

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.sal_GetSalariuID

	(
		@ID int
	)

AS
	SELECT     ID, DataPlatii, AngajatID, NrZileLuna, ProgramLucru, SalariuIncadrare, NrOreLucrate, SumaOreLucrate, [NrOreSup50%], [SumaOreSup50%], [NrOreSup100%], 
	                      NrOreEvenimDeosebit, [SumaOreSup100%], SumaEvenimDeosebit, NrOreInvoire, SumaOreInvoire, NrOreConcediuOdihna, SumaConcediuOdihna, 
	                      NrOreConcediuBoala, SumaConcediuBoala, SporActivSupl, EmergencyService, IndemnizCoducere, PrimeSpeciale, AlteDrepturi, VenitBrut, AjutorSomaj, 
	                      CASAngajat, ContribSanPers, CheltProfesionale, DeducerePersonala, DeducereSuplimentara, BCImpozit, Impozit, VenitNet, Avans, AlteRetineri, TotalRetineri, 
	                      RestPlata, CASAngajator, SanatateAngajator, SomajAngajator, FondRiscAngajator, CameraMuncaAngajator, LunaID
	FROM         Sal_Salarii
	WHERE     (ID = @ID)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE sal_InsertPersoanaInIntretinere

	(
	@AngajatID int,
	@Nume nvarchar(50), 
	@Prenume nvarchar(50),
	@Calitate smallint,
	@CNP bigint,
	@Invaliditate smallint,
	@SetID int OUTPUT	
	)

AS	
	insert into AngajatPersoaneInIntretinere with(xlock) (AngajatID,Nume,Prenume,Calitate,CNP,Invaliditate) 
	values (@AngajatID,@Nume,@Prenume,@Calitate,@CNP,@Invaliditate)
    SET @SetID = @@IDENTITY

	IF @@ERROR > 0
		BEGIN
		RAISERROR ('Insert Coeficienti esuat', 16, 1)
		RETURN 99
		END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.sal_InsertSalarii
	(
		@DataPlatii datetime,
		@AngajatID int,
		@SalariuIncadrare money,
		@ProgramLucru int,
		@NrZileLuna float,
		@NrOreLucrate float,
		@NrOreSup50Proc float,
		@NrOreSup100Proc float,
		@NrOreEvenimDeosebit float,
		@NrOreInvoire float,
		@NrOreConcediuOdihna float,
		@NrOreConcediuBoala float,
		@SporActivSupl money,
		@EmergencyService money,
		@IndemnizConducere money,
		@PrimeSpeciale money,
		@AlteDrepturi money,
		@SumaOreLucrate money,
		@SumaOreSup50Proc money,
		@SumaOreSup100Proc money,
		@SumaEvenimDeosebit money,
		@SumaOreInvoire money,
		@SumaConcediuOdihna money,
		@SumaConcediuBoala money,
		@VenitBrut money,
		@AjutorSomaj money,
		@CASAngajat money,
		@ContribSanPers  money,
		@CheltProfesionale money,
		@DeducerePersonala money,
		@DeducereSuplimentara money,
		@BCImpozit money,
		@Impozit money,
		@VenitNet money,
		@Avans money,
		@AlteRetineri money,
		@TotalRetineri money,
		@RestPlata money,
		@CASAngajator money,
		@SanatateAngajator money,
		@SomajAngajator money,
		@FondRiscAngajator money,
		@CameraMuncaAngajator money,
		@LunaID int,
		@ID int OUTPUT
	)

AS
DELETE FROM Sal_Salarii
WHERE     (AngajatID = @AngajatID) AND (LunaID = @LunaID)


INSERT INTO Sal_Salarii
                      (DataPlatii, AngajatID, SalariuIncadrare, ProgramLucru,NrZileLuna, NrOreLucrate, SumaOreLucrate, [NrOreSup50%], [NrOreSup100%], [SumaOreSup50%], 
                      [SumaOreSup100%], NrOreEvenimDeosebit, SumaEvenimDeosebit, NrOreInvoire, SumaOreInvoire, NrOreConcediuOdihna, SumaConcediuOdihna, 
                      NrOreConcediuBoala, SumaConcediuBoala, SporActivSupl, EmergencyService, IndemnizCoducere, PrimeSpeciale, AlteDrepturi, VenitBrut, AjutorSomaj, 
                      CASAngajat, ContribSanPers, CheltProfesionale, DeducerePersonala, DeducereSuplimentara, BCImpozit, Impozit, VenitNet, Avans, AlteRetineri, TotalRetineri, 
                      RestPlata, CASAngajator, SanatateAngajator, SomajAngajator, FondRiscAngajator, CameraMuncaAngajator, LunaID)
VALUES     (@DataPlatii, @AngajatID, @SalariuIncadrare, @ProgramLucru,@NrZileLuna, @NrOreLucrate, @SumaOreLucrate, @NrOreSup50Proc, @NrOreSup100Proc, 
                      @SumaOreSup50Proc, @SumaOreSup100Proc, @NrOreEvenimDeosebit, @SumaEvenimDeosebit, @NrOreInvoire, @SumaOreInvoire, 
                      @NrOreConcediuOdihna, @SumaConcediuOdihna, @NrOreConcediuBoala, @SumaConcediuBoala, @SporActivSupl, @EmergencyService, 
                      @IndemnizConducere, @PrimeSpeciale, @AlteDrepturi, @VenitBrut, @AjutorSomaj, @CASAngajat, @ContribSanPers, @CheltProfesionale, 
                      @DeducerePersonala, @DeducereSuplimentara, @BCImpozit, @Impozit, @VenitNet, @Avans, @AlteRetineri, @TotalRetineri, @RestPlata, @CASAngajator, 
                      @SanatateAngajator, @SomajAngajator, @FondRiscAngajator, @CameraMuncaAngajator, @LunaID)
	SET @ID = @@IDENTITY
	
	IF @@ERROR>0
		BEGIN
		RAISERROR ('Insert Salariu esuat' , 16, 1)
		RETURN 99
		END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Modif: Dovlecel Vlad

CREATE PROCEDURE sal_InsertUpdateDeleteSituatieLunaraAngajat
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@SituatieID int,
	@LunaID int,
	@AngajatID int,
	@NrZileLuna float,
	@NrZileLucrateLuna float,
	@NrOreLucrate float,
	@NrOreSup50Proc float,
	@NrOreSup100Proc float,
	@NrOreEvenimDeoseb float,
	@NrOreInvoire float,
	@NrOreConcediuOdihna float,
	@NrOreConcediuBoala float,
	@NrOreConcediuBoalaFirma float,
	@NrOreConcediuBoalaBASS float,

	@NrOreObligatiiCetatenesti float,
	@NrOreAbsenteNemotivate float,
	@NrOreConcediuFaraPlata float,

	@NrOreTotalDelegatieInterna float,
	@NrOreTotalDelegatieExterna float,
	@NrOreLucrateDelegatieInterna float,
	@NrOreLucrateDelegatieExterna float,

	@NrOreEmergencyService float,

	@SporActivitatiSup money,
	@EmergencyService money,
	@PrimeSpeciale money,
	@AlteDrepturi money,
	@AlteDrepturiNet money,

	@Avans money,
	@Retineri money,
	@PrimaProiect money,

	@CategorieID int,
	@ProgramLucru int,
	@SalariuBaza money,
	@IndemnizatieConducere money,
	@Invaliditate smallint,
	@rc int out,
	@ValideazaStergere bit = 1
)

as
set @rc = 0








begin tran IUDSituatieLunaraAngajat

if(@tip_actiune = 0)
begin	--Insert 
	
	if( @ValideazaStergere = 1 )
	begin
		delete from sal_SituatieLunaraAngajati where AngajatID=@AngajatID and LunaID=@LunaID
	end

	insert into sal_SituatieLunaraAngajati with(xlock) 

	(

	LunaID,
	AngajatID,
	NrZileLuna,
	NrZileLucrateLuna,
	NrOreLucrate,
	NrOreSup50Proc,
	NrOreSup100Proc, 
	NrOreEvenimDeoseb,
	NrOreInvoire, 
	NrOreConcediuOdihna,
	NrOreConcediuBoala,
	NrOreConcediuBoalaFirma,
	NrOreConcediuBoalaBASS,
	NrOreObligatiiCetatenesti,
	NrOreAbsenteNemotivate,
	NrOreConcediuFaraPlata,
	NrOreTotalDelegatieInterna ,
	NrOreTotalDelegatieExterna,
	NrOreLucrateDelegatieInterna ,
	NrOreLucrateDelegatieExterna,
	NrOreEmergencyService,
	SporActivitatiSup,
	EmergencyService,
	PrimeSpeciale,
	AlteDrepturi,
	AlteDrepturiNet,
	Avans,
	Retineri,
--	PrimaProiect,
	PrimeProiect,
	CategorieID,
	ProgramLucru,
	SalariuBaza,
	IndemnizatieConducere,
	Invaliditate
	) 
	values  
	(
	@LunaID,
	@AngajatID,
	@NrZileLuna,
	@NrZileLucrateLuna,
	@NrOreLucrate,
	@NrOreSup50Proc,
	@NrOreSup100Proc, 
	@NrOreEvenimDeoseb,
	@NrOreInvoire, 
	@NrOreConcediuOdihna,
	@NrOreConcediuBoala,
	@NrOreConcediuBoalaFirma,
	@NrOreConcediuBoalaBASS,
	@NrOreObligatiiCetatenesti,
	@NrOreAbsenteNemotivate,
	@NrOreConcediuFaraPlata,
	@NrOreTotalDelegatieInterna ,
	@NrOreTotalDelegatieExterna,
	@NrOreLucrateDelegatieInterna ,
	@NrOreLucrateDelegatieExterna,
	@NrOreEmergencyService,
	@SporActivitatiSup,
	@EmergencyService,
	@PrimeSpeciale,
	@AlteDrepturi,
	@AlteDrepturiNet,
	@Avans,
	@Retineri,
	@PrimaProiect,
	@CategorieID,
	@ProgramLucru,
	@SalariuBaza,
	@IndemnizatieConducere,
	@Invaliditate
	) 
	if(@@ERROR <> 0)
	begin
		rollback tran IUDSituatieLunaraAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDSituatieLunaraAngajat
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update Zi
	update sal_SituatieLunaraAngajati  with(xlock) set 


	NrZileLuna=@NrZileLuna,
	NrZileLucrateLuna=@NrZileLucrateLuna,
	NrOreLucrate=@NrOreLucrate,
	NrOreSup50Proc=@NrOreSup50Proc,
	NrOreSup100Proc=@NrOreSup100Proc, 
	NrOreEvenimDeoseb=@NrOreEvenimDeoseb,
	NrOreInvoire=@NrOreInvoire, 
	NrOreConcediuOdihna=@NrOreConcediuOdihna,
	NrOreConcediuBoala=@NrOreConcediuBoala,
	NrOreConcediuBoalaFirma=@NrOreConcediuBoalaFirma,
	NrOreConcediuBoalaBASS=@NrOreConcediuBoalaBASS,
	NrOreObligatiiCetatenesti = @NrOreObligatiiCetatenesti,
	NrOreAbsenteNemotivate = @NrOreAbsenteNemotivate,
	NrOreConcediuFaraPlata = @NrOreConcediuFaraPlata,
	NrOreTotalDelegatieInterna = @NrOreTotalDelegatieInterna,
	NrOreTotalDelegatieExterna = @NrOreTotalDelegatieExterna,
	NrOreLucrateDelegatieInterna = @NrOreLucrateDelegatieInterna,
	NrOreLucrateDelegatieExterna = @NrOreLucrateDelegatieExterna,
	NrOreEmergencyService = @NrOreEmergencyService,
	SporActivitatiSup=@SporActivitatiSup,
	EmergencyService=@EmergencyService,
	PrimeSpeciale=@PrimeSpeciale,
	AlteDrepturi=@AlteDrepturi,
	AlteDrepturiNet=@AlteDrepturiNet,
	Avans=@Avans,
	Retineri=@Retineri,
	--PrimaProiect=@PrimaProiect,
	PrimeProiect=@PrimaProiect,
	CategorieID = @CategorieID,
	ProgramLucru = @ProgramLucru,
	SalariuBaza = @SalariuBaza,
	IndemnizatieConducere = @IndemnizatieConducere,
	Invaliditate = @Invaliditate

		
	where  SituatieID = @SituatieID
		
	if(@@ERROR <> 0)
	begin
		rollback tran IUDSituatieLunaraAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran  IUDSituatieLunaraAngajat
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete IntervalAbsentaAngajat
	delete from sal_SituatieLunaraAngajati with(xlock) where SituatieID = @SituatieID
	if(@@ERROR <> 0)
	begin
		rollback tran  IUDSituatieLunaraAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran  IUDSituatieLunaraAngajat
		set @rc = 0
	end
end
else
	rollback tran IUDIntervalAbsentaAngajat
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE sal_UpdatePersoanaInIntretinere
	(
		@ID int,
		@Nume nvarchar(50), 
		@Prenume nvarchar(50),
		@Calitate smallint,
		@CNP bigint,
		@Invaliditate smallint
	)

AS
	update AngajatPersoaneInIntretinere with(xlock) 
             set Nume = @Nume,
	     Prenume = @Prenume,
	     Calitate = @Calitate,             
  	     CNP=@CNP,	    
                  Invaliditate=@Invaliditate
	where [AngajatPersoaneInIntretinere].[ID]=@ID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor: Cristina Muntean
	Nume: sp_CalculBazaCalculFondSolidaritateUnitate
	Parametrii: 
			--parametrii de intrare
			@AngajatorID int, --id-ul angajatorului
			@LunaID int, --id-ul lunii
	
			--parametru de iesire
			@BCunitateFondSolidaritate money
	Descriere: calculeaza baza de calcul pentru contributia unitatii la fondul de solidaritate cu persoanele cu dizabilitati
	Formula de calcul:BazaCalculUnitateFondSolidaritate=NrTotalAngajati*SalariulMinimPeEconomie
	
*/
CREATE PROCEDURE spCalculBazaCalculFondSolidaritateUnitate
(
	--parametrii de intrare
	@AngajatorID int, --id-ul angajatorului
	@LunaID int, --id-ul lunii
	
	--parametru de iesire
	@BCunitateFondSolidaritate money OUTPUT
)

AS
	--numarul total de angajati
	DECLARE @NrTotalAngajati int
	--salariul minim pe economie
	DECLARE @SalariulMinimPeEconomie money
	
	--calcul numar total de angajati
	SET @NrTotalAngajati = (SELECT COUNT(*) AS NrAngajati
							FROM Angajati INNER JOIN Sal_SituatieLunaraAngajati
							ON Angajati.AngajatID=Sal_SituatieLunaraAngajati.AngajatID
							WHERE Angajati.AngajatorID=@AngajatorID AND Sal_SituatieLunaraAngajati.LunaID=@LunaID)
			
	--salariul minim pe economie
	SET @SalariulMinimPeEconomie = (SELECT Valoare
								   FROM sal_VariabileGlobaleValori INNER JOIN
								   sal_variabileGlobaleTipuri ON sal_VariabileGlobaleValori.VariabilaGlobalaID=sal_VariabileGlobaleTipuri.VariabilaGlobalaID
								   WHERE sal_VariabileGlobaleValori.LunaID = @LunaID AND sal_VariabileGlobaleTipuri.Cod = 'SMINEC')
		
	--este calculata baza de calcul pentru contributia unitatii la fondul de solidaritate cu persoanele cu dizabilitati
	--Formula de calcul:BCunitateFondSolidaritate=NrTotalAngajati*SalariulMinimPeEconomie
	SET @BCunitateFondSolidaritate = @BCunitateFondSolidaritate * @SalariulMinimPeEconomie
	
	
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:      Cristina Muntean
	Data:       1.03.2005
	Nume:       spCalculCompletVenitBrut
	Parametrii: --parametrii de intrare
				@LunaID int, --id-ul lunii
				@AngajatID int, --id-ul angajatului
						
				--parametru de iesire
				@VenitBrut money OUTPUT--restul de plata al angajatului
	Descriere:  Calculeaza venitul brut pentru angajatul cu id-ul trimis ca parametru in luna cu id-ul trimis
			ca parametru, in acest calcul nu se iau in considerare alte drepturi in valoare neta
*/
CREATE PROCEDURE spCalculCompletVenitBrut
(
	--parametrii de intrare
	@LunaID int, --id-ul lunii
	@AngajatID int, --id-ul angajatului
			
	--parametru de iesire
	@VenitBrut money OUTPUT--restul de plata al angajatului
)

AS
--tariful orar
declare @TarifOrar money
--indemnizatie concediu medical
declare @IndemnizatieConcediuMedical money
--alte drepturi in valoare bruta
declare @AlteDrepturi money

--calculam tariful orar
exec spCalculTarifOrarAngajat @AngajatID, @LunaID, @TarifOrar  OUTPUT
--print 'to '+convert(nvarchar(32),@TarifOrar)

--calculam indemnizatia pentru concediu de boala
exec spCalculIndemnizatieConcediuMedicalAngajat @AngajatID, @LunaID, 'CM', @IndemnizatieConcediuMedical OUTPUT
--print 'scb '+convert(nvarchar(32),@IndemnizatieConcediuMedical)

--calculam alte drepturi dupa formula: AlteDrepturi = AlteDrepturiBrut + valoareBruta(AlteDrepturiNet)
SET @AlteDrepturi = (SELECT  AlteDrepturi
					FROM Sal_SituatieLunaraAngajati INNER JOIN
					Angajati ON Sal_SituatieLunaraAngajati.AngajatID=Angajati.AngajatID
					WHERE Sal_SituatieLunaraAngajati.AngajatID=@AngajatID AND Sal_SituatieLunaraAngajati.LunaID=@LunaID)
					
--caclculam venitul brut
exec spCalculVenitBrutAngajat @AngajatID, @LunaID, @TarifOrar, @IndemnizatieConcediuMedical, @AlteDrepturi, @VenitBrut OUTPUT
--print 'vb '+convert(nvarchar(32),@VenitBrut)

RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:       Cristina Muntean
	Data:        15.03.2005
	Nume:        spCalculRetineriAngajat
	Parametrii:  
				--parametrii de intrare
			     @LunaID...id-ul lunii 
			     @AngajatID...id-ul angajatului
				 				 
				--parametru de iesire
				 @Retineri...retinerile pentru angajatul cu id-ul trimis ca parametru pe luna cu id-ul trimis ca parametru 
	Descriere:   calculeaza retinerile pentru angajatul cu id-ul trimis ca parametru pe luna cu id-ul trimis ca parametru
	Formula de calcul: Retineri = Avans + AlteRetineri
*/
CREATE PROCEDURE spCalculRetineriAngajat
(
	--parametrii de intrare
	@LunaID int, --id-ul lunii
	@AngajatID int, --id-ul angajatului
	
	--parametru de iesire
	@TotalRetineri money OUTPUT--retinerile pentru angajatul cu id-ul trimis ca parametru pe luna cu id-ul trimis ca parametru
	
)
AS

	--avansul angajatului
	DECLARE @Avans  money
	--alte retinri ale angajatului
	DECLARE @AlteRetineri  money
	
	SET @Avans = (SELECT Avans
					 FROM sal_SituatieLunaraAngajati
					 WHERE AngajatID=@AngajatID AND LunaID=@LunaID)
					 
	SET @AlteRetineri = (SELECT Retineri
					 FROM sal_SituatieLunaraAngajati
					 WHERE AngajatID=@AngajatID AND LunaID=@LunaID)
					 
	--calculeaza retinerile pentru angajatul cu id-ul trimis ca parametru pe luna cu id-ul trimis ca parametru
	--Formula de calcul: Retineri = Avans + AlteRetineri
	SET @TotalRetineri = @Avans + @AlteRetineri
					 
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
  Autor: Cristina Muntean
  Data: 21.02.2005
  Nume: spCalculTarifOrarAngajat
  Descriere: Calculeaza tariful orar pentru angajat-ul cu id-ul @AngajatID pe luna cu id-ul @LunaID.
  date de intrare: date personal pentru angajat-ul cu id-ul  @AngajatID
  date iesire: tarif orar
  formula de calcul: 
  tarifOrar = (salariuDeIncadrare+sporuri+indemnizatieDeConducere)/(zileLucratoareInLunaCurenta*normaZilnica)
  Changes history:
		 Ionel Popa 28 feb 2005 - extragerea datelor NU din tabela Angajati si din tabela sal_SituatieLunaraAngajat
		 
*/
CREATE PROCEDURE spCalculTarifOrarAngajat
(
	--parametrii de intrare
	@AngajatID int, --id-ul angajatului pentru care se calculeaza tariful orar
	@LunaID int, --id-ul lunii pentru care se calculeaza tariful orar

	--parametrul de iesire
	@TarifOrar money OUTPUT --tariful orar al angajatului	
)
AS

--numarul de zile lucratoare dintr-o luna
DECLARE @NrZileLucratoareLuna int
--prima zi a lunii
DECLARE @DataStart datetime
--ultima zi a lunii
DECLARE @DataEnd datetime
--norma angajatului
DECLARE @Norma int

--setare prima zi a lunii 
SET @DataStart = (SELECT Data
				 FROM sal_Luni
				 WHERE LunaID=@LunaID)

--setare ultima zi a lunii
SET @DataEnd = DATEADD(dd, - DAY(DATEADD(mm, 1, @DataStart)), DATEADD(mm, 1, @DataStart))

--este calculat numarul de zile lucratoare ale lunii
SET @NrZileLucratoareLuna = (SELECT COUNT(*)
								 FROM tm_Zile
								 WHERE @DataStart<=Data AND Data<=@DataEnd AND Sarbatoare = 0)

--este setata norma angajatului pe luna cu id-ul @LunaID
SET @Norma = (SELECT ProgramLucru
			 FROM Sal_SituatieLunaraAngajati
			 WHERE AngajatID=@AngajatID AND LunaID=@LunaID)
			 
if ((@NrZileLucratoareLuna>0)AND(@Norma>0))
	--formula de calcul a tarifului orar: 
	--tarifOrar = (salariuDeIncadrare+sporuri+indemnizatieDeConducere)/(zileLucratoareInLunaCurenta*normaZilnica)
	--MODIFIED: Ionel Popa ... am extras SalariuBaza si IndemnizatieConducere din sal_SituatieLunaraAngajati si NU din tabela Angajati
	SET @TarifOrar=(SELECT CONVERT(money,(Sal_SituatieLunaraAngajati.SalariuBaza + Angajati.Sporuri + Sal_SituatieLunaraAngajati.IndemnizatieConducere) /
		                  (@NrZileLucratoareLuna*Sal_SituatieLunaraAngajati.ProgramLucru))AS TarifOrarAngajat
					FROM	Angajati INNER JOIN
				          Sal_SituatieLunaraAngajati ON Angajati.AngajatID = Sal_SituatieLunaraAngajati.AngajatID
					WHERE (Angajati.AngajatID = @AngajatID) AND (Sal_SituatieLunaraAngajati.LunaID = @LunaID))
else
	SET @TarifOrar = 0

RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
   Autor:     Cristina Muntean
   Data:      24.02.2005
   Nume:      spCalculVenitBrutAngajat
   Descriere: Calculeaza venitul brut al unui anggajat
   Formula de calcul:
   venitBrut = ((salariulIncadrare+sporuri)/zileLucratoareInLunaCurenta)*zileLucrate + 
			+ indemnizatieDeConducere*zileLucrate/zileLucratoareInLunaCurenta + 
			+ ((salariuIncadrare+sporuri)/zileLucratoareInLunaCurenta)*zileConcediuDeOdihna +
			+ ((salariuIncadrare+sporuri)/zileLucratoareInLunaCurenta)*zileConcediuEvenimentDeosebit +
			+ tarifOrar * oreSuplimentare100% +
			+ 2 * tarifOrar * oreSuplimentare200% +
			+ indemnizatieConcediuMedical +
			+ primeDeProiect + 
			+ primeSpeciale + 
			+ alteDrepturi + 
			+ SumaFixaPtStandByInServDeEmergency*ZileServEmergency  
*/
CREATE PROCEDURE spCalculVenitBrutAngajat
(
	--parametrii de intrare
	@AngajatID int, --id-ul angajatului
	@LunaID int, --id-ul  lunii pentru care se calculeaza venitul brut al angajatului
	@TarifOrar money, --tariful orar al angajatului
	@IndemnizatieConcediuMedical money, --indemnizatia de concediu medical a angajatului
	@AlteDrepturi money, --AlteDrepturi = AlteDrepturiBrut +valoareBruta(AlteDrepturiNet)
	
	--parametrul de iesire
	@VenitBrut money OUTPUT --venitul brut al angajatului
)

AS
 --numarul de zile lucratoare dintr-o luna
DECLARE @NrZileLucratoareLuna int
--prima zi a lunii
DECLARE @DataStart datetime
--ultima zi a lunii
DECLARE @DataEnd datetime

print 'indemnizatie = ' + cast(@indemnizatieConcediuMedical as nvarchar(32))

--setare prima zi a lunii 
SET @DataStart = (SELECT Data
				 FROM sal_Luni
				 WHERE LunaID=@LunaID)

--setare ultima zi a lunii
SET @DataEnd = DATEADD(dd, - DAY(DATEADD(mm, 1, @DataStart)), DATEADD(mm, 1, @DataStart))

--este calculat numarul de zile lucratoare ale lunii
SET @NrZileLucratoareLuna = (SELECT COUNT(*)
								 FROM tm_Zile
								 WHERE @DataStart<=Data AND Data<=@DataEnd AND Sarbatoare = 0)
								  
 /*este calculat venitul brut al angajatului dupa formula:
   venitBrut = ((salariulIncadrare+sporuri)/zileLucratoareInLunaCurenta)*zileLucrate + 
			+ indemnizatieDeConducere*zileLucrate/zileLucratoareInLunaCurenta + 
			+ ((salariuIncadrare+sporuri)/zileLucratoareInLunaCurenta)*zileConcediuDeOdihna +
			+ ((salariuIncadrare+sporuri)/zileLucratoareInLunaCurenta)*zileConcediuEvenimentDeosebit +
			+ tarifOrar * oreSuplimentare100% +
			+ 2 * tarifOrar * oreSuplimentare200% +
			+ indemnizatieConcediuMedical +
			+ primeDeProiect + 
			+ primeSpeciale + 
			+ alteDrepturi + 
			+ SumaFixaPtStandByInServDeEmergency*ZileServEmergency  
 OBS: in baza de date:
	NrOreConcediuOdihna = numarul de zile de concediu de odihna
	NrOreEvenimDeoseb = numarul de zile de evenimente deosebite
*/

SET @VenitBrut = (SELECT  CONVERT(money,
					((Sal_SituatieLunaraAngajati.SalariuBaza+Angajati.Sporuri)/@NrZileLucratoareLuna)*
					(Sal_SituatieLunaraAngajati.NrZileLucrateLuna + 
					(Sal_SituatieLunaraAngajati.NrOreConcediuOdihna)+
					(Sal_SituatieLunaraAngajati.NrOreEvenimDeoseb))+
					(Sal_SituatieLunaraAngajati.IndemnizatieConducere*Sal_SituatieLunaraAngajati.NrZileLucrateLuna)/@NrZileLucratoareLuna+
					@TarifOrar*(Sal_SituatieLunaraAngajati.NrOreSup50Proc + 2*Sal_SituatieLunaraAngajati.NrOreSup100Proc)+
					@IndemnizatieConcediuMedical+
					Sal_SituatieLunaraAngajati.PrimeSpeciale +
					Sal_SituatieLunaraAngajati.PrimeProiect +
					@AlteDrepturi +
					Sal_SituatieLunaraAngajati.EmergencyService) AS VenitBrut
					FROM Sal_SituatieLunaraAngajati INNER JOIN
					Angajati ON Sal_SituatieLunaraAngajati.AngajatID=Angajati.AngajatID
					WHERE Sal_SituatieLunaraAngajati.AngajatID=@AngajatID AND Sal_SituatieLunaraAngajati.LunaID=@LunaID)

	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO






/*
	Author:		Ionel Popa
	Description:	Calculeaza numarul de zile de boala care depasesc NumarZileAdmise din luna cu id-ul LunaID
	Params:		LunaID ... id-ul lunii
			AngajatID ... id-ul
			NumarZileAdmise ... numarul de zile dupa care nu se mai plateste contributia pentru somaj
			NumarLuni ... numarul de luni pentru care se calculeaza zilele de concediu medical
			NumarZile ... numarul de zile  de concediu de medical din ultimele luni
			NumarZileLucratoare ... numarul de zile lucratoare de concediu medical cu care se depasesc NumarZileAdmise de concediu medical
			DataStart31Zile ... data de start a intervalului din care incep sa se depaseasca cele NumarZileAdmise de zile
*/
CREATE      PROCEDURE spCalcullNumarZileBoalaInUltimeleLuni
	@LunaID int,
	@AngajatID int,
	@NumarZileAdmise int,
	@NumarLuni int,
	@NumarZile int out,
	@NumarZileLucratoare int out,
	@DataStart31Zile datetime out
AS

-- cursor cu intervalele de absenta din ultimele trei luni
declare @ultimeleLuni CURSOR
-- data de sfarsit de luna pentru luna cu id-ul LunaID
declare @DataEndLuna datetime
-- data de incput a lunii
declare @DataStartLuna datetime
-- variabile folosite la iterarea prin cursorul care retine intervalele de absente
declare @DataStartTemp datetime
declare @DataEndTemp datetime
declare @LastDataEnd datetime
--semnaleaza daca s-a depasit sau nu @NumarZileAdmise de zile de concediu medical
declare @gasit int
--data de start a ultimului concediu medical
declare @DataStartCM datetime
--Contor temporar
declare @Contor int


--Extragem data de start a lunii cu id-ul LunaID
select @DataStartLuna = data from sal_luni where LunaID = @LunaID

--Extragem data de sfarsit a lunii cu id-ul LunaID
select @DataEndLuna =  max(data) from tm_zile
where month(@DataStartLuna) = month(Data)

--punem in cursor toate concediile medicale si concediile medicale cu continuare ale acestora
--precum si concediile medicale din luna activa
set @ultimeleLuni =  CURSOR SCROLL DYNAMIC
FOR
select distinct tmia1.DataStart, tmia1.DataEnd
from tm_IntervaleAbsenta tmia1, tm_IntervaleAbsenta tmia2
where 
	tmia1.AngajatID = tmia2.AngajatID and tmia1.AngajatID = @AngajatID
	and
	(
		-- PRIMA SITUATIE: data de start a primului interval este imediat dupa data de sfarsit a celui de-al doilea interval
		(
			( datediff( day, tmia2.DataEnd , tmia1.DataStart) = 1 )
			and
			(
				( tmia2.tipabsentaid in (select tipabsentaid from tm_tipabsente where codabsenta='cm') and tmia1.tipabsentaid in (select tipabsentaid from tm_tipabsente where codabsenta='ccm'))
				or
				( tmia2.tipabsentaid in (select tipabsentaid from tm_tipabsente where codabsenta='ccm') and tmia1.tipabsentaid in (select tipabsentaid from tm_tipabsente where codabsenta='ccm'))
			)
		) 
		-- A DOUA SITUATIE: data de inceput a celui de-al doilea interval este egala cu data de sfarsit a primului interval
		or
		(
			( dateadd( day, 1, tmia1.DataEnd ) = tmia2.DataStart )
			and
			(
				( tmia1.tipabsentaid in (select tipabsentaid from tm_tipabsente where codabsenta='cm') and tmia2.tipabsentaid in (select tipabsentaid from tm_tipabsente where codabsenta='ccm'))
				or
				( tmia1.tipabsentaid in (select tipabsentaid from tm_tipabsente where codabsenta='ccm') and tmia2.tipabsentaid in (select tipabsentaid from tm_tipabsente where codabsenta='ccm'))
			)
		)
	)
	-- data de inceput a primului interval tre sa fie inclusa in numarul de luni specificate de catre parametrul @NumarLuni
	and
	( datediff( month, tmia1.DataStart, @DataStartLuna) >= 0 and datediff( month, tmia1.DataStart, @DataStartLuna ) <= @NumarLuni )
union
select distinct tmia.DataStart, tmia.DataEnd
from tm_intervaleabsenta tmia
where 
	tmia.AngajatID = @AngajatID
	and
	--data de inceput a intervalului trebuie sa fie in luna activa
	( datediff( day, @DataStartLuna, tmia.DataStart) >= 0 and datediff( day, tmia.DataStart, @DataEndLuna) > 0 )
	and
	--doar concediile de boala si cele cu continuare
	tmia.tipabsentaid in (select tipabsentaid from tm_tipabsente where codabsenta='cm')

order by tmia1.DataStart


open @ultimeleLuni
--calculam numarul de zile de concediu de boala din ultimele luni
fetch next from @ultimeleLuni 
into @DataStartTemp, @DataEndTemp

--setam variabilele necesare pentru algoritm
set @gasit = 0
set @DataStartCM = @DataStartTemp
set @LastDataEnd = @DataEndTemp
set @NumarZile = datediff(day, @DataStartTemp, @DataEndTemp) + 1
set @NumarZileLucratoare = 0
while @@fetch_status = 0
begin
	if @gasit = 1
	begin
		--daca data de sfarsit a concediului este dupa data din care incep sa depaseasca cele @NumarZileAdmise de zile
		if datediff( day, @DataStart31Zile , @DataEndTemp) > 0
		begin
			--verificam daca intervalul de concediu are capatul de sfarsit in luna curenta
			if datediff( day, @DataStartLuna, @DataEndTemp) > 0 and datediff( day, @DataEndTemp, @DataEndLuna) >= 0
			begin
				--daca @DataStart31Zile = @DataStartLuna si @DataStartTemp este precedenta @DataStartLuna
				if datediff( day, @DataStart31Zile, @DataStartLuna) = 0
				begin
					set @NumarZile = @NumarZile + datediff( day, @DataStartLuna , @DataEndTemp) + 1
				end
				else
				begin
					--daca sfarsitul de concediu medical nu depaseste sfarsitul de luna atunci calculul se face normal
					set @NumarZile = @NumarZile + datediff( day, @DataStartTemp , @DataEndTemp) + 1
				end
			end
			else
			begin
				/*
				daca sfarsitul de concediu medical depaseste sfarsitul de luna atunci calculul se face ca si cum sfarsitul 
				de concediu medical ar fi sfarsitul de luna 
				*/
				set @NumarZile = @NumarZile + datediff( day, @DataStartTemp, @DataEndLuna) + 1
			end
			
		end
	end
	else
	begin
		if dateadd(day, 1, @LastDataEnd) <> @DataStartTemp
		begin
			/*
			verificam daca capatul de sfarsit al intervalului este in luna urmatoare lunii active
			daca NU atunci numarul de zile se calculeaza in mod normal
			*/
			if datediff( day, @DataEndTemp , @DataEndLuna) >= 0
			begin
				set @NumarZile = datediff(day, @DataStartTemp, @DataEndTemp) + 1
				set @LastDataEnd = @DataEndTemp
				--se seteaza un nou capat de interval
				set @DataStartCM = @DataStartTemp
			end
			/*
			daca sfarsitul de interval este in luna urmatoare lunii active
			atunci se pp ca si cum sfarsitul intervalului este sfarsitul lunii active
			*/
			else
			begin
				set @NumarZile = datediff( day, @DataStartTemp, @DataEndLuna ) + 1
			end
			
			set @gasit = 0
		end
		else
		begin
			set @NumarZile = @NumarZile + datediff(day, @DataStartTemp, @DataEndTemp) + 1
			set @LastDataEnd = @DataEndTemp		
		end
	end

	--in cazul in care nu s-au atins cele NumarZileAdmise se face calculul urmator
	if @NumarZile > @NumarZileAdmise and @gasit = 0
	begin
		--daca sfarsitul de interval este inclus in luna curenta
		if datediff( day, @DataStartLuna, @DataEndTemp) > 0 and datediff( day, @DataEndTemp, @DataEndLuna) > 0
		begin
			--calculam capatul de interval in care incep sa se depaseasca cele @NumarZileAdmise de zile
			set @DataStart31Zile = dateadd( day, @NumarZileAdmise - 1, @DataStartCM)
			--daca ziua in care incepe sa depaseasca cele @NumarZileAdmise de zile este in luna curenta
			if datediff( day, @DataStartLuna, @DataStart31Zile) >= 0 and datediff( day, @DataStart31Zile, @DataEndLuna) > 0
			begin
				--incepe sa depaseasca cele @NumarZileAdmise de zile in luna curenta
				set @NumarZile = datediff( day, @DataStart31Zile, @DataEndTemp)
			end
			else
			begin
				/*
				cele @NumarZileAdmise de zile se aduna inainte de a intra in luna curenta
				in acest caz setam data la care incepe sa depaseasca cele @NumarZileAdmise de zile cu inceputul lunii ... 
				din punct de vedere al calculului nu este asa, dar asta este din cauza ca nu ne intereseaza decat zilele de concediu din luna curenta 
				*/
				set @DataStart31Zile = @DataStartLuna
				set @NumarZile = 0
			end
		end
		else
		begin
			/*
			verificam daca sfarsitul de interval este inainte de data de start a lunii
			daca sfarsitul de interval cu care se depasesc cele 31 de zile nu este in luna curenta atunci se seteaza data la care incepe sa depaseasca cele 31 de zile cu inceputul lunii
			la fel ca in cazul de mai sus ... 
			*/
			if datediff( day, @DataEndTemp, @DataStartLuna) > 0
			begin
				set @DataStart31Zile = @DataStartLuna
				set @NumarZile = 0
			end

			--verificam daca sfarsitul de interval este dupa data de sfarsit a lunii
			if datediff( day, @DataEndLuna, @DataEndTemp) > 0
			begin
				set @DataStart31Zile = dateadd( day, @NumarZileAdmise, @DataStartCM)
				set @NumarZile = datediff( day, @DataStart31Zile, @DataEndLuna) + 1
			end
		end
		
		--s-au depasit cele 31 de zile
		set @gasit = 1
		
	end

	fetch next from @ultimeleLuni
	into @DataStartTemp, @DataEndTemp
end


--daca nu s-a gasit nici un concediu care sa depaseasca @NumarZileAdmise atunci se seteaza @NumarZile la zero
if @gasit = 0
begin
	set @NumarZile = 0
	set @NumarZileLucratoare = 0
end
else
begin
	/*
	Cunoscand data din care incep sa se depaseasca nr-ul de zile admise de concediu medical cu sau fara continuare, calculam zilele lucratoare
	cu care se depasesc numarul de zile admise
	*/
	select @Contor = count(*), @NumarZileLucratoare = sum ( [SiemensHR_Test].[dbo].[DiferenceBetweenTwoPeriods](DataStart, DataEnd, @DataStart31Zile, @DataEndLuna) )
	from tm_IntervaleAbsenta
	where 
		AngajatID = @AngajatID
		and
		(
			( datediff( day, @DataStartLuna, DataEnd ) > 0 and datediff( day, DataEnd, @DataEndLuna) >= 0 )
			or
			(datediff( day, @DataStartLuna, DataStart ) > 0 and datediff( day, DataStart, @DataEndLuna) >= 0)
		)
		and tipabsentaid in (select tipabsentaid from tm_tipabsente where codabsenta='cm' or codabsenta='ccm' )

	if @Contor = 0
	begin
		set @NumarZileLucratoare = 0
	end
end

--daca sunt zile care depasesc numarul de zile admise atunci calculam numarul de zile lucratoare incepand din 

close @ultimeleLuni
deallocate @ultimeleLuni


return





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:		Cristina Muntean
	Nume:		spDeleteSalariuLunaAngajat
	Parametrii:	@LunaID int, --id-ul lunii
				@AngajatorID int --id-ul angajatului
	Descriere:  sunt sterse salariile angajatorului pe o anumita luna 
*/
CREATE PROCEDURE spDeleteSalariuLunaAngajat
(
	@LunaID int, --id-ul lunii
	@AngajatID int --id-ul angajatului
)
AS
	--sunt sterse inregistrarile din sal_StatDePlata
	begin tran DeleteStatDePlata
		delete from  sal_StatDePlata  with(xlock) where LunaID=@LunaID and AngajatID=@AngajatID
		if(@@ERROR <> 0)
			begin
				rollback tran DeleteStatDePlata
			end
		else
			begin
				commit tran DeleteStatDePlata
			end

	--sunt sterse inregistrarile din sal_ContributiiIndivLuna
	begin tran DeleteContribIndiv
		delete from  sal_ContributiiIndivLuna  with(xlock) where LunaID=@LunaID and AngajatID=@AngajatID
		if(@@ERROR <> 0)
			begin
				rollback tran DeleteContribIndiv
			end
		else
			begin
				commit tran DeleteContribIndiv
			end
	
	--sunt sterse inregistrarile din sal_BazaCalculLuna
	begin tran DeleteBazaCalculLuna
		delete from  sal_BazeCalculLuna with(xlock) where LunaID=@LunaID and AngajatID=@AngajatID
		if(@@ERROR <> 0)
			begin
				rollback tran DeleteBazaCalculLuna
			end
		else
			begin
				commit tran DeleteBazaCalculLuna
			end
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:      Cristina Muntean
	Nume:		spGetAllAngajatiIDs
	Parametrii: 
				@AngajatorID int, --id-ul angajatorului
				@LunaID int --id-ul lunii
	Descriere:  se returneaza toate id-urile angajatilor pentru care trebuie calculate salariile intr-o anumita luna
*/
CREATE PROCEDURE spGetAllAngajatiIDs
(
	@AngajatorID int, --id-ul angajatorului
	@LunaID int --id-ul lunii
)
AS
	--se returneaza toate id-urile angajatilor pentru care trebuie calculate salariile intr-o anumita luna
	SELECT sal_SituatieLunaraAngajati.AngajatID 
	FROM sal_SituatieLunaraAngajati INNER JOIN
		Angajati ON sal_SituatieLunaraAngajati.AngajatID = Angajati.AngajatID
	WHERE Angajati.AngajatorID=@AngajatorID AND sal_SituatieLunaraAngajati.LunaID=@LunaID
	ORDER BY Angajati.Nume, Angajati.Prenume
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:      Cristina Muntean
	Data:       15.03.2005
	Nume:       spGetStatDePlataInfo
	Parametrii: @ID...id-ul inregistrarii din tabela sal_StatDePlata
	Descriere:  returneaza detaliile din statul de plata pentru inregistrarea cu id-ul trimis ca parametru
*/
CREATE PROCEDURE spGetStatDePlataInfo
(
	@ID int --id-ul inregistrarii
)
AS
	--selecteaza toate datele din sal_StatDePlata pentru inregistrarea cu id-ul trimis ca parametru
	SELECT  sal_SituatieLunaraAngajati.SalariuBaza, sal_SituatieLunaraAngajati.IndemnizatieConducere, sal_StatDePlata.*
	FROM   dbo.Sal_SituatieLunaraAngajati  INNER JOIN
           dbo.sal_StatDePlata ON sal_SituatieLunaraAngajati.AngajatID = dbo.sal_StatDePlata.AngajatID
	WHERE ID=@ID AND sal_StatDePlata.LunaID = sal_SituatieLunaraAngajati.LunaID
	
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:      Cristina Muntean
	Data:       16.03.2004
	Nume:       spInsertStatDePlata
	Parametrii: --parametrii de intrare
				@AngajatID int,
				@LunaID int, 
				@Prime money,
				@AlteDrepturi money,
				@IndemnizatieConcediuMedical money,
				@VenitBrut money,
				@VenitNet money,
				@DeduceriPersonale money,
				@BazaImpozitare money,
				@Impozit money,
				@SalariuNet money,
				@Avans money,
				@Retineri money,
				@TotalRetineri money,
				@RestPlata money,
		
				--parametru de iesire
				@ID int OUTPUT
	Descriere:  insereaza o inregistrare in tabela sal_StatDePlata si returneaza id-ul inregistrarii
*/
CREATE PROCEDURE spInsertStatDePlata
(
		--parametrii de intrare
		@AngajatID int,
		@LunaID int, 
		@Prime money,
		@AlteDrepturi money,
		@IndemnizatieConcediuMedical money,
		@VenitBrut money,
		@VenitNet money,
		@DeduceriPersonale money,
		@BazaImpozitare money,
		@Impozit money,
		@SalariuNet money,
		@Avans money,
		@Retineri money,
		@TotalRetineri money,
		@RestDEPlata money,
		
		--parametru de iesire
		@ID int OUTPUT
)

AS
	declare @rc int
	set @rc = 0


	--insert in sal_StatDePlata
	begin tran IStatDePlata
		insert into sal_StatDePlata with(xlock) 
					   (AngajatID ,
						LunaID , 
						Prime ,
						AlteDrepturi ,
						IndemnizatieConcediuMedical ,
						VenitBrut ,
						VenitNet ,
						DeduceriPersonale ,
						BazaImpozitare ,
						Impozit ,
						SalariuNet ,
						Avans ,
						Retineri,
						TotalRetineri,
						RestDePlata 
						)		 
						values 
						(@AngajatID ,
						 @LunaID , 
						 @Prime ,
						 @AlteDrepturi ,
						 @IndemnizatieConcediuMedical ,
						 @VenitBrut ,
						 @VenitNet ,
						 @DeduceriPersonale ,
						 @BazaImpozitare ,
						 @Impozit ,
						 @SalariuNet ,
						 @Avans ,
						 @Retineri,
						 @TotalRetineri,
						 @RestDePlata 
						)
		if(@@ERROR <> 0)
		begin
			rollback tran IStatDePlata
			set @rc = @@ERROR
		end
		else
		begin
			commit tran IStatDePlata
			set @ID = @@IDENTITY 
			set @rc = 0
		end

	RETURN @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:      Cristina Muntean
	Data:       16.03.2004
	Nume:       spUpdateStatDePlata
	Parametrii: --parametrii de intrare
				@ID int,
				@AngajatID int,
				@LunaID int, 
				@Prime money,
				@AlteDrepturi money,
				@IndemnizatieConcediuMedical money,
				@VenitBrut money,
				@VenitNet money,
				@DeduceriPersonale money,
				@BazaImpozitare money,
				@Impozit money,
				@SalariuNet money,
				@Avans money,
				@Retineri money,
				@TotalRetineri money,
				@RestPlata money
	Descriere:  face update unei inregistrari din tabela sal_StatDePlata 
*/
CREATE PROCEDURE spUpdateStatDePlata
(
		--parametrii de intrare
		@ID int,
		@AngajatID int,
		@LunaID int, 
		@Prime money,
		@AlteDrepturi money,
		@IndemnizatieConcediuMedical money,
		@VenitBrut money,
		@VenitNet money,
		@DeduceriPersonale money,
		@BazaImpozitare money,
		@Impozit money,
		@SalariuNet money,
		@Avans money,
		@Retineri money,
		@TotalRetineri money,
		@RestDEPlata money
)

AS
	declare @rc int
	set @rc = 0


	--update sal_StatDePlata
	begin tran UStatDePlata
		update sal_StatDePlata with(xlock) 
					   set AngajatID = @AngajatID ,
						LunaID = @LunaID, 
						Prime = @Prime ,
						AlteDrepturi = @AlteDrepturi ,
						IndemnizatieConcediuMedical = @IndemnizatieConcediuMedical ,
						VenitBrut = @VenitBrut ,
						VenitNet = @VenitNet ,
						DeduceriPersonale = @DeduceriPersonale ,
						BazaImpozitare = @BazaImpozitare ,
						Impozit = @Impozit ,
						SalariuNet = @SalariuNet ,
						Avans = @Avans,
						Retineri = @Retineri ,
						TotalRetineri = @TotalRetineri ,
						RestDePlata = @RestDePlata 
		where ID=@ID
						
		if(@@ERROR <> 0)
		begin
			rollback tran UStatDePlata
			set @rc = @@ERROR
		end
		else
		begin
			commit tran UStatDePlata
			set @rc = 0
		end

	RETURN @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:	Dovlecel Vlad
* Nume:			InsertUpdateDeleteIntervalAngajat
* Data:	Adauga, modifica, sterge o inregistrare in tabelul tm_IntervaleAngajat
*/
CREATE PROCEDURE tm_DeleteIntervaleAngajatPerioada
(
	@DataStart DateTime,
	@DataEnd DateTime,
	@AngajatID int,
	@TipuriInterv bit
)

as

declare @rc int
set @rc = 0

begin tran IUDIntervalAngajat

if( @TipuriInterv=0 )
begin

	delete from tm_IntervaleAngajat with(xlock) 
	where AngajatID=@AngajatID and
		@DataStart<=Data and
		Data<=@DataEnd and
		CapatInterval=0
end
else begin
	--cand se face o lichidare
	delete from tm_IntervaleAngajat with(xlock) 
	where AngajatID=@AngajatID and
		@DataStart<=Data and
		Data<=@DataEnd

	--sterge intreruperile de dupa lichidare
	delete from AngajatiIntreruperi with(xlock)
	where AngajatID=@AngajatID and
		DataStart>=@DataStart

	--sterge toate absentele ce incep dupa lichidare
	delete from tm_IntervaleAbsenta with(xlock)
	where AngajatID=@AngajatID and
		DataStart>=@DataStart

	--sterge toate lichidarile ulterioare celei care se va introduce
	delete from Lichidare with(xlock)
	where AngajatID=@AngajatID and
		DataLichidare>=@DataStart

	--update la intreruperile care incep inainte de lichidare si se termina dupa
	update AngajatiIntreruperi set DataEnd=DateAdd( dd, -1, @DataStart )
	where AngajatID=@AngajatID and
		 DataStart<@DataStart and @DataStart<=DataEnd

	--update la absentele care incep inainte de lichidare si se termina dupa
	update tm_IntervaleAbsenta set DataEnd=DateAdd( dd, -1, @DataStart )
	where AngajatID=@AngajatID and
		 DataStart<@DataStart and @DataStart<=DataEnd
end

if(@@ERROR <> 0)
begin
	rollback tran IUDIntervalAngajat
	set @rc = @@ERROR
end
else
begin
	commit tran IUDIntervalAngajat
	set @rc = 0
end

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:	Dovlecel Vlad
* Nume:			InsertUpdateDeleteIntervalAngajat
* Data:	Adauga, modifica, sterge o inregistrare in tabelul tm_IntervaleAngajat
*/
CREATE PROCEDURE tm_DeleteIntervaleAngajatPerioadaTemporar
(
	@DataStart DateTime,
	@DataEnd DateTime,
	@AngajatID int,
	@TipuriInterv bit
)

as

declare @rc int
set @rc = 0

begin tran IUDIntervalAngajat

if( @TipuriInterv=0 )
begin

	/*delete from tm_IntervaleAngajat with(xlock) 
	where AngajatID=@AngajatID and
		@DataStart<=Data and
		Data<=@DataEnd and
		CapatInterval=0*/

	update tm_IntervaleAngajat with(xlock) set Deleted=1
	where AngajatID=@AngajatID and
		@DataStart<=Data and
		Data<=@DataEnd and
		CapatInterval=0
end
else begin
	--cand se face o lichidare
	delete from tm_IntervaleAngajat with(xlock) 
	where AngajatID=@AngajatID and
		@DataStart<=Data and
		Data<=@DataEnd

	--sterge intreruperile de dupa lichidare
	delete from AngajatiIntreruperi with(xlock)
	where AngajatID=@AngajatID and
		DataStart>=@DataStart

	--sterge toate absentele ce incep dupa lichidare
	delete from tm_IntervaleAbsenta with(xlock)
	where AngajatID=@AngajatID and
		DataStart>=@DataStart

	--sterge toate lichidarile ulterioare celei care se va introduce
	delete from Lichidare with(xlock)
	where AngajatID=@AngajatID and
		DataLichidare>=@DataStart

	--update la intreruperile care incep inainte de lichidare si se termina dupa
	update AngajatiIntreruperi set DataEnd=DateAdd( dd, -1, @DataStart )
	where AngajatID=@AngajatID and
		 DataStart<@DataStart and @DataStart<=DataEnd

	--update la absentele care incep inainte de lichidare si se termina dupa
	update tm_IntervaleAbsenta set DataEnd=DateAdd( dd, -1, @DataStart )
	where AngajatID=@AngajatID and
		 DataStart<@DataStart and @DataStart<=DataEnd
end

if(@@ERROR <> 0)
begin
	rollback tran IUDIntervalAngajat
	set @rc = @@ERROR
end
else
begin
	commit tran IUDIntervalAngajat
	set @rc = 0
end

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetAngajatNrZileAbsentePerioada
(
@AngajatID int,
@CodAbsenta nvarchar(5) = '', 
@DataStart datetime,
@DataEnd datetime
)

AS

/*if( @CodAbsenta != '' )
begin
	select * 
	
	from tm_IntervaleAbsenta tm_ia inner join tm_TipAbsente tm_ta on tm_ia.TipAbsentaID = tm_ta.TipAbsentaID
	
	where AngajatID = @AngajatID and CodAbsenta = @CodAbsenta and 
		(( @DataStart <= DataStart and DataStart <= @DataEnd ) or
		 ( @DataStart <= DataEnd and DataEnd <= @DataEnd ) or
		 ( DataStart <= @DataStart and @DataEnd <= DataEnd ))
	
	order by DataStart
end
else begin
	select * 
	
	from tm_IntervaleAbsenta
	
	where AngajatID = @AngajatID and 
		(( @DataStart <= DataStart and DataStart <= @DataEnd ) or
		 ( @DataStart <= DataEnd and DataEnd <= @DataEnd ) or
		 ( DataStart <= @DataStart and @DataEnd <= DataEnd ))
	
	order by DataStart
end*/

if( @CodAbsenta != '' )
begin
	select * 
	
	from tm_IntervaleAbsenta tm_ia inner join tm_TipAbsente tm_ta on tm_ia.TipAbsentaID = tm_ta.TipAbsentaID
	
	where AngajatID = @AngajatID and CodAbsenta = @CodAbsenta and 
		(( @DataStart <= DataStart and DataStart <= @DataEnd ) or
		 ( @DataStart <= DataEnd and DataEnd <= @DataEnd ) or
		 ( DataStart <= @DataStart and @DataEnd <= DataEnd ))
	
	order by DataStart
end
else begin
	select * 
	
	from tm_IntervaleAbsenta tm_ia inner join tm_TipAbsente tm_ta on tm_ia.TipAbsentaID = tm_ta.TipAbsentaID
	
	where AngajatID = @AngajatID and 
		(( @DataStart <= DataStart and DataStart <= @DataEnd ) or
		 ( @DataStart <= DataEnd and DataEnd <= @DataEnd ) or
		 ( DataStart <= @DataStart and @DataEnd <= DataEnd )) and
		Lucratoare=0
	
	order by DataStart
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetIntervalAbsentaByDataEnd

(
	@AngajatID int,
	@DataEnd datetime
)

AS

select * from tm_IntervaleAbsenta tm_ia inner join tm_TipAbsente tm_ta on tm_ia.TipAbsentaID = tm_ta.TipAbsentaID

--where DataEnd = @DataEnd and AngajatID = @AngajatID 
where DataEnd = @DataEnd and AngajatID = @AngajatID and Lucratoare=0

order by DataStart
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tm_GetIntervalAbsentaByID

(
	@AngajatID int,
	@AbsentaID int
)

AS

select * from tm_IntervaleAbsenta tm_ia inner join tm_TipAbsente tm_ta on tm_ia.TipAbsentaID = tm_ta.TipAbsentaID

--where IntervalAbsentaID=@AbsentaID and AngajatID = @AngajatID 
where IntervalAbsentaID=@AbsentaID and AngajatID = @AngajatID and Lucratoare=0

order by DataStart
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.tm_GetIntervalAbsentaContinuari
(
	@AngajatID int,
	--@Luna int,
	--@An int
	@AbsentaID int
	--@DataCurenta datetime
)

AS

declare @DataEndAbsenta  datetime

select @DataEndAbsenta = DataEnd

--from tm_IntervaleAbsenta inner join tm_TipAbsente on tm_IntervaleAbsenta.TipAbsentaID = tm_TipAbsente.TipAbsentaID
from tm_IntervaleAbsenta

where AngajatID= @AngajatID and IntervalAbsentaID = @AbsentaID
/*	(( datepart( mm,DataStart ) = month( @DataCurenta ) and 
		datepart( yy,DataStart ) = year( @DataCurenta )) or
	 ( datepart( mm,DataEnd ) = month( @DataCurenta ) and 
		datepart( yy,DataEnd ) = year( @DataCurenta )) or
	( DataStart < @DataCurenta and
		@DataCurenta < DataEnd ))*/
Order by DataStart;


select *

from tm_IntervaleAbsenta

where AngajatID = @AngajatID and DataStart > @DataEndAbsenta

order by DataStart

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


--intoarce  orice tip de absenta si absente lucrate

CREATE PROCEDURE dbo.tm_GetIntervaleAbsenta
(
	@AngajatID int,
	@IntervalID int
)

AS

select *
from tm_IntervaleAbsenta inner join tm_TipAbsente on tm_IntervaleAbsenta.TipAbsentaID = tm_TipAbsente.TipAbsentaID
--where AngajatID=@AngajatID and @IntervalID!=IntervalAbsentaID
where AngajatID=@AngajatID and @IntervalID!=IntervalAbsentaID-- and Lucratoare=0
Order by DataStart
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


--Author: Dovlecel Vlad
--intoarce  toate absentele de tip concediu medical sau continuare ale unui angajat, 

CREATE PROCEDURE tm_GetIntervaleAbsentaCM
(
	@AngajatID int,
	@CodAbsenta nvarchar (5),
	@CodAbsentaContinuare nvarchar(5)
)

AS

select *
from tm_IntervaleAbsenta inner join tm_TipAbsente on tm_IntervaleAbsenta.TipAbsentaID = tm_TipAbsente.TipAbsentaID
where AngajatID=@AngajatID and ( CodAbsenta=@CodAbsenta or CodAbsenta=@CodAbsentaContinuare )
Order by DataStart

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


-- Autor: Dovlecel Vlad
-- Functionalitate: intoarce toate intervalele de absente specifice unui angajat, 
--		 care contin zile din luna si anul corespunzatoare datei curente
--
CREATE PROCEDURE dbo.tm_GetIntervaleAbsentaLuna
(
@AngajatID int,
--@Luna int,
--@An int
@DataCurenta datetime
)

AS

select *

from tm_IntervaleAbsenta inner join tm_TipAbsente on tm_IntervaleAbsenta.TipAbsentaID = tm_TipAbsente.TipAbsentaID

/*where AngajatID= @AngajatID and 
	(( datepart( mm,DataStart ) = month( @DataCurenta ) and 
		datepart( yy,DataStart ) = year( @DataCurenta )) or
	 ( datepart( mm,DataEnd ) = month( @DataCurenta ) and 
		datepart( yy,DataEnd ) = year( @DataCurenta )) or
	( DataStart <= @DataCurenta and
		@DataCurenta <= DataEnd ))*/

where AngajatID= @AngajatID and 
	(( datepart( mm,DataStart ) = month( @DataCurenta ) and 
		datepart( yy,DataStart ) = year( @DataCurenta )) or
	 ( datepart( mm,DataEnd ) = month( @DataCurenta ) and 
		datepart( yy,DataEnd ) = year( @DataCurenta )) or
	( DataStart <= @DataCurenta and
		@DataCurenta <= DataEnd )) and
	Lucratoare=0

Order by DataStart
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.tm_GetIntervaleAbsentaMedicalaContinuareLuna
(
@AngajatID int,
--@Luna int,
--@An int
@DataCurenta datetime
)

AS

/*select tm_iac.*

from tm_IntervaleAbsenta tm_ia inner join tm_IntervaleAbsentaContinuare tm_iac on tm_ia.IntervalAbsentaID = tm_iac.AbsentaID

where AngajatID= @AngajatID and 
	(( datepart( mm, tm_iac.DataStart ) = month( @DataCurenta ) and 
		datepart( yy, tm_iac.DataStart ) = year( @DataCurenta )) or
	 ( datepart( mm,tm_iac.DataEnd ) = month( @DataCurenta ) and 
		datepart( yy, tm_iac.DataEnd ) = year( @DataCurenta )) or
	( tm_iac.DataStart < @DataCurenta and
		@DataCurenta < tm_iac.DataEnd ))

Order by tm_iac.DataStart*/

select tm_ia.*, tm_ta.*

from tm_IntervaleAbsenta tm_ia inner join tm_TipAbsente tm_ta on tm_ia.TipAbsentaID = tm_ta.TipAbsentaID

where AngajatID= @AngajatID and 
	ContinuareAbsenta = 1 and
	(( datepart( mm, tm_ia.DataStart ) = month( @DataCurenta ) and 
		datepart( yy, tm_ia.DataStart ) = year( @DataCurenta )) or
	 ( datepart( mm,tm_ia.DataEnd ) = month( @DataCurenta ) and 
		datepart( yy, tm_ia.DataEnd ) = year( @DataCurenta )) or
	( tm_ia.DataStart < @DataCurenta and
		@DataCurenta < tm_ia.DataEnd ))

Order by tm_ia.DataStart

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


-- Autor: Dovlecel Vlad
-- Functionalitate: intoarce toate intervalele de absente specifice unui angajat, 
--		 care contin zile din luna si anul corespunzatoare datei curente
--
CREATE PROCEDURE dbo.tm_GetIntervaleAbsentaSiEmergencyLuna
(
@AngajatID int,
--@Luna int,
--@An int
@DataCurenta datetime
)

AS

select *

from tm_IntervaleAbsenta inner join tm_TipAbsente on tm_IntervaleAbsenta.TipAbsentaID = tm_TipAbsente.TipAbsentaID

where AngajatID= @AngajatID and 
	(( datepart( mm,DataStart ) = month( @DataCurenta ) and 
		datepart( yy,DataStart ) = year( @DataCurenta )) or
	 ( datepart( mm,DataEnd ) = month( @DataCurenta ) and 
		datepart( yy,DataEnd ) = year( @DataCurenta )) or
	( DataStart <= @DataCurenta and
		@DataCurenta <= DataEnd ))

Order by DataStart
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


--Author: Dovlecel Vlad
--intoarce  toate absentele unui angajat, de un anumit tip

CREATE PROCEDURE tm_GetIntervaleAbsentaTip
(
	@AngajatID int,
	@CodAbsenta nvarchar (5)
)

AS

select *
from tm_IntervaleAbsenta inner join tm_TipAbsente on tm_IntervaleAbsenta.TipAbsentaID = tm_TipAbsente.TipAbsentaID
where AngajatID=@AngajatID and CodAbsenta=@CodAbsenta
Order by DataStart

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


-- Autor: Dovlecel Vlad
-- Functionalitate: intoarce toate intervalele de absente specifice unui angajat, 
--		 care contin zile din luna si anul corespunzatoare datei curente
--
CREATE PROCEDURE dbo.tm_GetIntervaleAbsentaZi
(
	@AngajatID int,
	@DataCurenta datetime
)

AS

select *

from tm_IntervaleAbsenta inner join tm_TipAbsente on tm_IntervaleAbsenta.TipAbsentaID = tm_TipAbsente.TipAbsentaID

/*where AngajatID= @AngajatID and 
	DataStart <= @DataCurenta and
	@DataCurenta <= DataEnd*/
where AngajatID= @AngajatID and 
	DataStart <= @DataCurenta and
	@DataCurenta <= DataEnd and
	Lucratoare=0


Order by DataStart
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE PROCEDURE dbo.tm_GetIntreruperiLuna
(
@DataCurenta datetime,
@AngajatID int --expirare contract munca
)

AS

select ang.*, angi.*, intr.*

from (Angajati ang inner join AngajatiIntreruperi angi on ang.AngajatID=angi.AngajatID)
	inner join Intreruperi intr on angi.AngajatIntrerupereID=intr.IntrerupereID

where angi.AngajatID=@AngajatID and
	(( datepart( yy, angi.DataStart )=year( @DataCurenta ) and datepart( mm,angi.DataStart )=month( @DataCurenta )) or
	( datepart(yy, intr.DataStop )=year( @DataCurenta ) and datepart( mm, intr.DataStop )=month( @DataCurenta )) or
	( angi.DataStart<=@DataCurenta and @DataCurenta<=intr.DataStop ))

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:			Dovlecel Vlad
* Nume:			InsertUpdateDeleteIntervalAbsentaAngajat
* Data:	Adauga, modifica, sterge o inregistrare in tabelul tm_IntervaleAbsenta
*/

CREATE PROCEDURE tm_InsertUpdateDeleteIntervalAbsenta
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@IntervalAbsentaID int,
	@DataStart datetime,
	@DataEnd datetime,
	@TipAbsentaID int,
	@AngajatID int,
	@Observatii ntext = null,
	@BoalaID int = null,
	@ContinuareAbsenta bit = 0,
	@MedieZilnica real = 0
)

as

declare @rc int
set @rc = 0

begin tran IUDIntervalAbsentaAngajat

if(@tip_actiune = 0)
begin	--Insert IntervalAbsenta
	if( @BoalaID != -1 )
	begin
		insert into tm_IntervaleAbsenta with(xlock) 
	
				(
				DataStart,
				DataEnd,
				TipAbsentaID,
				AngajatID,
				Observatii,
				BoalaID,
				ContinuareAbsenta,
				MedieZilnica
				) 
	
	
			values  (
	
				@DataStart,
				@DataEnd,
				@TipAbsentaID,
				@AngajatID,
				@Observatii,
				@BoalaID,
				@ContinuareAbsenta,	
				@MedieZilnica
				) 
		if(@@ERROR <> 0)
		begin
			rollback tran IUDIntervalAbsentaAngajat
			set @rc = @@ERROR
		end
		else
		begin
			commit tran IUDIntervalAbsentaAngajat
			set @rc = 0
		end
	end
	else
	begin
		insert into tm_IntervaleAbsenta with(xlock) 
	
				(
				DataStart,
				DataEnd,
				TipAbsentaID,
				AngajatID,
				Observatii
				) 
	
	
			values  (
	
				@DataStart,
				@DataEnd,
				@TipAbsentaID,
				@AngajatID,
				@Observatii
				) 
		if(@@ERROR <> 0)
		begin
			rollback tran IUDIntervalAbsentaAngajat
			set @rc = @@ERROR
		end
		else
		begin
			commit tran IUDIntervalAbsentaAngajat
			set @rc = 0
		end
	end
end
else if(@tip_actiune = 1)
begin	--Update Absente
	if( @BoalaID != -1 )
	begin
		update tm_IntervaleAbsenta  with(xlock) set 


			TipAbsentaID = @TipAbsentaID,
			DataStart=@DataStart,
			DataEnd=@DataEnd, 
			Observatii = @Observatii,
			BoalaID = @BoalaID,
			ContinuareAbsenta = @ContinuareAbsenta,
			MedieZilnica=@MedieZilnica
		
			where  IntervalAbsentaID = @IntervalAbsentaID
		
		if(@@ERROR <> 0)
		begin
			rollback tran IUDIntervalAbsentaAngajat
			set @rc = @@ERROR
		end
		else
		begin
			commit tran IUDIntervalAbsentaAngajat
			set @rc = 0
		end
	end
	else begin
		update tm_IntervaleAbsenta  with(xlock) set 


			TipAbsentaID = @TipAbsentaID,
			DataStart=@DataStart,
			DataEnd=@DataEnd, 
			Observatii = @Observatii,
			BoalaID = null,
			ContinuareAbsenta = @ContinuareAbsenta,
			MedieZilnica = 0
		
			where  IntervalAbsentaID = @IntervalAbsentaID
		
		if(@@ERROR <> 0)
		begin
			rollback tran IUDIntervalAbsentaAngajat
			set @rc = @@ERROR
		end
		else
		begin
			commit tran IUDIntervalAbsentaAngajat
			set @rc = 0
		end

	end
end
else if(@tip_actiune = 2)
begin	--Delete IntervalAbsentaAngajat
	delete from tm_IntervaleAbsenta with(xlock) where IntervalAbsentaID = @IntervalAbsentaID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIntervalAbsentaAngajat
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIntervalAbsentaAngajat
		set @rc = 0
	end
end
else
	rollback tran IUDIntervalAbsentaAngajat

return @rc
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE GetIstoricDepartamenteAngajat
(
	@AngajatID int
)
as

select Departamente.*, (Departamente.Cod + ' - ' + Departamente.denumire) as DenumireCompleta, IstoricAngajatDepartament.DataStart 
from IstoricAngajatDepartament
	left join Departamente on Departamente.DepartamentID = IstoricAngajatDepartament.DepartamentID
where IstoricAngajatDepartament.AngajatID = @AngajatID 
order by DataStart desc

return


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		Mircea Albutiu, PSE RO BS TH
* Nume:			InsertUpdateDeleteIstoricDepartament
* Descriere:	Adauga, modifica, sterge o inregistrare in tabelul IstoricAngajatDepartament
*/
CREATE PROCEDURE InsertUpdateDeleteIstoricDepartament
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@AngajatID int,
	@DepartamentID int,
	@DataStart datetime, 
	@old_DataStart datetime = '19000101'
)

as

declare @rc int
set @rc = 0

begin tran IUDIstoricDepartament

if(@tip_actiune = 0)
begin	--Insert istoric
	insert into IstoricAngajatDepartament with(xlock) (AngajatID, DataStart, DepartamentID) 
		values (@AngajatID, @DataStart, @DepartamentID)
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricDepartament
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricDepartament
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--UpdateIstoric
	update IstoricAngajatDepartament with(xlock) set DataStart = @DataStart, DepartamentID = @DepartamentID 
		where AngajatID = @AngajatID and DataStart = @old_DataStart
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricDepartament
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricDepartament
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete istoric
	delete from IstoricAngajatDepartament with(xlock) where AngajatID = @AngajatID and DataStart = @DataStart
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIstoricDepartament
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIstoricDepartament
		set @rc = 0
	end
end
else
	rollback tran IUDIstoricDepartament

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.conturi_UpdateConturi
(	
	@ContID int,
	@BancaID int,
	@AngajatID int,
	@NumarCont nvarchar(50),
	@Moneda varchar(3),
	@Activ bit
)

AS
	begin transaction UpdateConturi
	
	update ConturiAngajati
	set BancaID = @BancaID, AngajatID = @AngajatID, NumarCont = @NumarCont, Moneda = @Moneda
	where ContID = @ContID
	
	if @Activ = 1
		EXEC conturi_SetCurrentContID @AngajatID,@ContID
		
	if @@ERROR > 0
		BEGIN
		RAISERROR ('Update cont failed', 16, 1)
		rollback transaction UpdateConturi
		RETURN 99
		end
	commit transaction UpdateConturi

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



/*
	Author: 		Ionel Popa
	Description: 	Calculeaza baza de calcul a contributiei individuale de somaj ... bcisom
					bcisom = if (angajat = pensionar;0; TarifOrar * NormaZilnica * ( ZileLucrate + ZileConcediuOdihna + ZileConcediuEvenimenteDeosebite))
	Params:			@LunaID in ... id-ul lunii active
					@AngajatID in ... id-ul angajatului pentru care se calculeaza baza de calcul
					@TarifOrar in ... tariful orar pentru angajatul cu id-ul AngajatID
					@BazaCalcul out ...baza de calcul
	Change history:		Ionel Popa ... 03 mar 2005
				S-a modificat formula de calcul al bcisom astfel:
				 bcisom = if (angajat = pensionar;0; TarifOrar * NormaZilnica * ( ZileLucrate + ZileConcediuOdihna + ZileConcediuEvenimenteDeosebite + ZileConcediuMedicalPlatitAngajator))
				si ZileConcediuMedicalPlatitAngajator nu se aduna pentru concediul de sarcina/leuzie, nici pentru concediul de îngrijire a copilului sub 2 ani, nici începând cu a 31-a zi de concediu medical de orice tip
*/
CREATE   PROCEDURE spCalculBazaContributieIndivSomaj 
	@LunaID int,
	@AngajatID int,
	@TarifOrar money,
	@BazaCalcul money output
AS

-- Norma zilnica pentru angajat
declare @NormaZilnica int
-- Nr-ul de zile lucrate de angajat in luna activa
declare @ZileLucrate int
-- Nr-ul de zile de concediu de odihna din luna activa
declare @ZileConcediuOdihna int
-- Nr-ul de zile de concediu de evenimente deosebite din luna activva
declare @ZileConcediuEvenimenteDeosebite int
--Nr-ul de zile de concediu medical platite de angajator
declare @ZileConcediuMedicalPlatiteAngajator int
--Data de inceput a lunii cu id-ul LunaID
declare @DataStartLuna datetime
--Data de sfarsit a lunii cu id-ul LunaID
declare @DataEndLuna datetime
--Numarul de zile lucratoare din concediile de sarcina/leuzie ...
declare @NrZileLucratoareCMSpecial int
--Numarul de zile de concediu care intervin in calculul bazei
declare @NrZileConcediuCareIntervinLaCalcul int
--Numarul de zile calendaristice de concediul medical care depasesc un numar de zile admise
declare @NrZile int
--Numarul de zile lucratoare de concediu medical care depasesc un numar de zile admise
declare @NrZileLucratoare int
--Data din care incep sa se depaseasca cele "numar zile admise" de concediu medical\continuare
declare @DataStart31Zile datetime
--Numarul de zile lucratoare de concediu medical din luna cu id-ul @LunaID
declare @NrTotalZileLucratoareConcediu int
--Numarul de concedii medicale de leuzie / ingrijire copil din luna activa
declare @NrConcediiSpeciale int

--Setam variabilele locale
set @NrZile = 0
set @NrZileLucratoare = 0
set @NrTotalZileLucratoareConcediu = 0
set @NrZileLucratoareCMSpecial = 0
set @NrZileConcediuCareIntervinLaCalcul = 0


--Extragem data de start a lunii cu id-ul LunaID
select @DataStartLuna = data from sal_luni where LunaID = @LunaID

--Extragem data de sfarsit a lunii cu id-ul LunaID
select @DataEndLuna =  max(data) from tm_zile
where month(@DataStartLuna) = month(Data)

--Verificam daca este intr-unul din cazurile:  concediul de sarcina/leuzie, concediul de îngrijire a copilului sub 2 ani sau are numarul de zile de concediu medical mai mare decat 31 (treizeci si unu)
select @NrConcediiSpeciale = count(*), @NrZileLucratoareCMSpecial = sum ([SiemensHR_Test].[dbo].[DiferenceBetweenTwoPeriods](DataStart, DataEnd, @DataStartLuna, @DataEndLuna)) 
from tm_intervaleabsenta
where tipabsentaid in (select tipabsentaid from tm_tipabsente where codabsenta='cm' or codabsenta='ccm')
	and boalaid in (select boalaid from boli where cod = '08' or cod = '16')
	and AngajatID = @AngajatID

--Daca nu e nici un concediu in luna activa
if @NrConcediiSpeciale = 0
begin
	set @NrZileLucratoareCMSpecial = 0
end

--Calculam nr-ul de zile calendaristice si cele lucratoare care depasesc un numar de zile admise
exec spCalcullNumarZileBoalaInUltimeleLuni @LunaID, @AngajatID, 31, 4, @NrZile OUTPUT, @NrZileLucratoare OUTPUT , @DataStart31Zile OUTPUT 


--Calculam nr-ul zile lucratoare de concediu din luna cu id-ul @LunaID
select @NrConcediiSpeciale = count(*), @NrTotalZileLucratoareConcediu = sum ( [SiemensHR_Test].[dbo].[DiferenceBetweenTwoPeriods](DataStart, DataEnd, @DataStartLuna, @DataEndLuna) )
from tm_IntervaleAbsenta
where 
	AngajatID = @AngajatID
	and
	(
		( datediff( day, @DataStartLuna, DataEnd ) > 0 and datediff( day, DataEnd, @DataEndLuna) >= 0 )
		or
		(datediff( day, @DataStartLuna, DataStart ) > 0 and datediff( day, DataStart, @DataEndLuna) >= 0)
	)
	and tipabsentaid in (select tipabsentaid from tm_tipabsente where codabsenta='cm' or codabsenta='ccm' )

--Daca nu e nici un concediu in luna activa
if @NrConcediiSpeciale = 0
begin
	set @NrTotalZileLucratoareConcediu = 0
end


--Calculam numarul de zile de concediu medical care intervin in calculul baze de calcul a contributiei individuale pentru somaj
set @NrZileConcediuCareIntervinLaCalcul = @NrTotalZileLucratoareConcediu - @NrZileLucratoareCMSpecial - @NrZileLucratoare


-- Extragem norma zilnica pentru angajatul specificat
--MODIFIED: Cristina Muntea ... am extras ProgramLucru din Sal_SituatieLunaraAngajati si NU din tabela Angajati
select @NormaZilnica = ProgramLucru from Sal_SituatieLunaraAngajati where AngajatID = @AngajatID

-- Extragem nr-ul de zile lucrate, nr-ul de zile de concediu de odihna si nr-ul de zile de concediu de evenimente deosebite din luna cu id-ul LunaID
--OBS: NrOreConcediuOdihna = numarul de zile de concediu de odihna;NrOreEvenimDeoseb = numarul de zile de eveniment deosebit
select @ZileLucrate = NrZileLucrateLuna, @ZileConcediuOdihna = NrOreConcediuOdihna , @ZileConcediuEvenimenteDeosebite = NrOreEvenimDeoseb 
from Sal_SituatieLunaraAngajati
where AngajatID = @AngajatID and LunaID = @LunaID

--Calculam baza de calcul
select @BazaCalcul = 
	case Pensionar 
		when 1 then 0
		when 0 then @TarifOrar * @NormaZilnica * ( @ZileLucrate + @ZileConcediuOdihna + @ZileConcediuEvenimenteDeosebite + @NrZileConcediuCareIntervinLaCalcul )
	end
from Angajati where AngajatID = @AngajatID

return


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:      Cristina Muntean
	Data:       1.03.2005
	Nume:       spCalculCompletRestDePlata
	Parametrii: --parametrii de intrare
				@LunaID int, --id-ul lunii
				@AngajatID int, --id-ul angajatului
				@VenitBrut money, --venitul brut al angajatului
				
				--parametru de iesire
				@RestPlata money --restul de plata al angajatului
	Descriere:  Calculeaza restul de plata pentru angajatul cu id-ul trimis ca parametru in luna cu id-ul trimis
			ca parametru
*/
CREATE PROCEDURE spCalculCompletRestDePlata
(
	--parametrii de intrare
	@LunaID int, --id-ul lunii
	@AngajatID int, --id-ul angajatului
	@VenitBrut money, --venitul brut al angajatului
	
	--parametru de iesire
	@RestPlata money OUTPUT--restul de plata al angajatului
)
AS
--tariful orar
declare @TarifOrar money
--indemnizatie concediu medical
declare @IndemnizatieConcediuMedical money
--baza de calcul pentru contributia individuala de somaj
declare @BazaCalculContribIndivSomaj money
--baza de calcul pentru contributia individuala de asigurari sociale
declare @BazaCalculContribIndivAsigSociale money
--baza de calcul pentru contributia individuala de asigurari de sanatate
declare @BazaCalculContribIndivAsigSanatate money
--contributia individuala de somaj
declare @ContribIndivSomaj money
--contributia individuala de asigurari sociale
declare @ContribIndivAsigSociale money
--contributia individuala de asigurari de sanatate
declare @ContribIndivAsigSanatate money
--venit net
declare @VenitNet money
--deduceri personale
declare @DeduceriPersonale money
--venitul impozabil
declare @VenitImpozabil money
--impozit
declare @Impozit money
--retineri
declare @Retineri money
--salariul net
declare @SalariulNet money


--calculam tariful orar
exec spCalculTarifOrarAngajat @AngajatID, @LunaID, @TarifOrar  OUTPUT
--print 'Tariful orar = ' + cast(@tarifOrar as nvarchar(32))

--calculam indemnizatia pentru concediu de boala
exec spCalculIndemnizatieConcediuMedicalAngajat @AngajatID, @LunaID, 'CM', @IndemnizatieConcediuMedical OUTPUT
--print 'Indemnizatie concediu medical = ' + cast(@IndemnizatieConcediuMedical as nvarchar(32))

-- calculam baza calcul a contributiei individuale la somaj
exec spCalculBazaContributieIndivSomaj @LunaID, @AngajatID, @TarifOrar,  @BazaCalculContribIndivSomaj OUTPUT
--print 'Baza calcul contributie indiv somaj = ' + cast(@bazaCalculContribIndivSomaj as nvarchar(32))

--calculam baza calcul a contributiei individuale la asigurarile sociale
exec spCalculBazaCalcAsigSocialeAngajat @LunaID, @AngajatID, @IndemnizatieConcediuMedical, @VenitBrut,  @BazaCalculContribIndivAsigSociale OUTPUT
--print 'baza asigurari sociale = ' + cast(@bazaCalculContribIndivAsigSociale as nvarchar(32))

--calculam baza de calcul a  contributiei individuale la asigurarile de sanatate
exec spCalculBazaCalcAsigDeSanatateAngajat @AngajatID, @LunaID, @IndemnizatieConcediuMedical, @VenitBrut,  @BazaCalculContribIndivAsigSanatate OUTPUT
--print 'Baza calcul asig sanatate = ' + cast(@bazaCalculContribIndivAsigSanatate as nvarchar(32))

--calculam contributia individuala la fondul de somaj
exec spCalculContributieIndivSomaj @LunaID, @AngajatID,  @BazaCalculContribIndivSomaj,  @ContribIndivSomaj OUTPUT
--print 'Contributie indiv somaj = ' + cast(@contribIndivSomaj as nvarchar(32))

--calculam  contributia individuala la asigurarile sociale
exec spCalculContributieIndivAsigSociale @LunaID, @AngajatID,  @BazaCalculContribIndivAsigSociale,  @ContribIndivAsigSociale OUTPUT
--print 'Contributie Indiv Asig Sociale = ' + cast(@contribIndivAsigSociale as nvarchar(32))

--calculam contributia individuala la asigurarile de sanatate
exec spCalculContributieIndivAsigSanatate @LunaID, @AngajatID, @BazaCalculContribIndivAsigSanatate, @ContribIndivAsigSanatate OUTPUT
--print 'Contributie Indiv Asig Sanatate = ' + cast(@contribIndivAsigSanatate as nvarchar(32))

--calculam venitul net
exec spCalculVenitNet @LunaID, @AngajatID, @VenitBrut, @ContribIndivSomaj, @ContribIndivAsigSanatate,  @ContribIndivAsigSociale,  @VenitNet OUTPUT
--print 'Venit net = ' + cast(@venitNet as nvarchar(32))

--calculam deducerile personale pentru angajat
exec spCalculDeduceriPersonale @LunaID, @AngajatID, @VenitBrut, 5, @DeduceriPersonale OUTPUT
--print 'Deduceri personale = ' + cast(@deduceriPersonale as nvarchar(32))

--calculam venitul impozabil pentru angajat
exec spCalculVenitImpozabil @LunaID, @AngajatID, @VenitNet, @DeduceriPersonale,  @VenitImpozabil OUTPUT
--print 'Venit impozabil = ' + cast(@venitImpozabil as nvarchar(32))

--calculam impozitul platit de angajat
exec spCalculImpozit @LunaID, @AngajatID, @VenitImpozabil, @Impozit OUTPUT
--print 'Impozit = ' + cast(@impozit as nvarchar(32))

--calculam salariul net al angajatului
exec spCalculSalariuNet @LunaID, @AngajatID, @VenitNet, @Impozit, @SalariulNet OUTPUT
--print 'Salariul Net = ' + cast(@salariulNet as nvarchar(32))

--calculam total retineri angajat
exec spCalculRetineriAngajat @LunaID, @AngajatID, @Retineri OUTPUT
--print 'Retineri = ' + cast(@Retineri as nvarchar(32))

--calculam restul de plata al angajatului
exec spCalculRestPlata @LunaID, @AngajatID, @SalariulNet, @Retineri, @RestPlata OUTPUT
--print 'Rest plata = ' + cast(@restPlata as nvarchar(32))

RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Author: 		Ionel Popa
	Description: 	Calculeaza venitul brut, bazele de calcul, contributiile, retul de plata pentru un angajat
	Params:			@LunaID in ... id-ul lunii active
				    @AngajatID in ... id-ul angajatului pentru care se calculeaza baza de calcul
*/
CREATE PROCEDURE spCalculDateSalariuAngajat
(
	@LunaID int, --id-ul lunii
	@AngajatID int --id-ul angajatului
)
AS


--id-urile tipurilor de baze de calcul din tabela sal_BazaCalculTipuri
declare @bcContribIndivSomajID as int
declare @bcContribIndivAsigSocialeID as int
declare @bcContribIndivAsigSanatateID as int
--id-urile tipurilor de contributii individuale din tabela sal_ContributiiIndivTipuri
declare @contribIndivSomajID as int
declare @contribIndivAsigSocialeID as int
declare @contribIndivAsigSanatateID as int
--datele referitoare la salariul angajatului
declare @tarifOrar as money
declare @prime as money
declare @avans as money
declare @alteRetineri as money
declare @indemnizatieConcediuMedical as money
declare @venitBrut as money
declare @bazaCalculContribIndivSomaj as money
declare @bazaCalculContribIndivAsigSociale as money
declare @bazaCalculContribIndivAsigSanatate as money
declare @contribIndivSomaj as money
declare @contribIndivAsigSociale as money
declare @contribIndivAsigSanatate as money
declare @venitNet as money
declare @deduceriPersonale as money
declare @venitImpozabil as money
declare @impozit as money
declare @alteDrepturi as money
declare @alteDrepturiNet as money
declare @alteDrepturiBrut as money
declare @salariulNet as money
declare @retineri as money
declare @totalRetineri as money
declare @restPlata as money
declare @nrConcediiMedicale int

--este afisat id-ul angajatului
print 'AngajatID = ' + cast(@angajatID as nvarchar(32))

--calculam tariful orar
exec spCalculTarifOrarAngajat @AngajatID, @LunaID, @tarifOrar  OUTPUT
print 'Tarif orar = ' + cast(@tarifOrar as nvarchar(32))

--calculam indemnizatia pentru concediu de boala
exec spCalculIndemnizatieConcediuMedicalAngajat @AngajatID, @LunaID, 'CM', @indemnizatieConcediuMedical OUTPUT
print 'Indemnizatie concediu medical = ' + cast(@indemnizatieConcediuMedical as nvarchar(32))
	
--MODIFIED:Cristina Muntean ... calcul @alteDrepturi
--calculam alte drepturi in valoare bruta
set @alteDrepturiBrut = (SELECT  AlteDrepturi
					FROM Sal_SituatieLunaraAngajati INNER JOIN
					Angajati ON Sal_SituatieLunaraAngajati.AngajatID=Angajati.AngajatID
					WHERE Sal_SituatieLunaraAngajati.AngajatID=@AngajatID AND Sal_SituatieLunaraAngajati.LunaID=@LunaID)

set @alteDrepturiNet =(SELECT  AlteDrepturiNet
					FROM Sal_SituatieLunaraAngajati INNER JOIN
					Angajati ON Sal_SituatieLunaraAngajati.AngajatID=Angajati.AngajatID
					WHERE Sal_SituatieLunaraAngajati.AngajatID=@AngajatID AND Sal_SituatieLunaraAngajati.LunaID=@LunaID)

if(@alteDrepturiNet<>0)					
	--calculam valoarea bruta pentru alte drepturi in valoare neta
	exec spCalculAlteDrepturiBrut @AngajatID, @LunaID, @alteDrepturiNet OUTPUT

--calculam total alte drepturi in valoare bruta
set @alteDrepturi = @alteDrepturiNet + @alteDrepturiBrut
print 'alte drepturi = ' + cast(@alteDrepturi as nvarchar(32))

--calculam venitul brut
exec spCalculVenitBrutAngajat @AngajatID, @LunaID, @tarifOrar, @indemnizatieConcediuMedical, @alteDrepturi, @venitBrut OUTPUT
print 'venit brut = ' + cast(@venitBrut as nvarchar(32))

-- calculam baza calcul a contributiei individuale la somaj
exec spCalculBazaContributieIndivSomaj @LunaID, @AngajatID, @tarifOrar,  @bazaCalculContribIndivSomaj OUTPUT
print 'baza somaj = ' + cast(@bazaCalculContribIndivSomaj as nvarchar(32))

--calculam baza calcul a contributiei individuale la asigurarile sociale
exec spCalculBazaCalcAsigSocialeAngajat @LunaID, @AngajatID, @indemnizatieConcediuMedical, @venitBrut,  @bazaCalculContribIndivAsigSociale OUTPUT
print 'baza asigurari sociale = ' + cast(@bazaCalculContribIndivAsigSociale as nvarchar(32))

--calculam baza de calcul a  contributiei individuale la asigurarile de sanatate
exec spCalculBazaCalcAsigDeSanatateAngajat @AngajatID, @LunaID, @indemnizatieConcediuMedical, @venitBrut,  @bazaCalculContribIndivAsigSanatate OUTPUT
print 'baza sanatate = ' + cast(@bazaCalculContribIndivAsigSanatate as nvarchar(32))

--calculam contributia individuala la fondul de somaj
exec spCalculContributieIndivSomaj @LunaID, @AngajatID,  @bazaCalculContribIndivSomaj,  @contribIndivSomaj OUTPUT
print 'contributie somaj = ' + cast(@contribIndivSomaj as nvarchar(32))

--calculam  contributia individuala la asigurarile sociale
exec spCalculContributieIndivAsigSociale @LunaID, @AngajatID,  @bazaCalculContribIndivAsigSociale,  @contribIndivAsigSociale OUTPUT
print 'contributie asigurari sociale = ' + cast(@contribIndivAsigSociale as nvarchar(32))

--calculam contributia individuala la asigurarile de sanatate
exec spCalculContributieIndivAsigSanatate @LunaID, @AngajatID, @bazaCalculContribIndivAsigSanatate, @contribIndivAsigSanatate OUTPUT
print 'contributie sanatate = ' + cast(@contribIndivAsigSanatate as nvarchar(32))

--calculam venitul net
exec spCalculVenitNet @LunaID, @AngajatID, @venitBrut, @contribIndivSomaj, @contribIndivAsigSanatate,  @contribIndivAsigSociale,  @venitNet OUTPUT
print 'venit net = ' + cast(@venitNet as nvarchar(32))

--calculam deducerile personale pentru angajat
exec spCalculDeduceriPersonale @LunaID, @AngajatID, @venitBrut, 5, @deduceriPersonale OUTPUT
print 'deduceri personale = ' + cast(@deduceriPersonale as nvarchar(32))

--calculam venitul impozabil pentru angajat
exec spCalculVenitImpozabil @LunaID, @AngajatID, @venitNet, @deduceriPersonale,  @venitImpozabil OUTPUT
print 'venit impozabil = ' + cast(@venitImpozabil as nvarchar(32))

--calculam impozitul platit de angajat
exec spCalculImpozit @LunaID, @AngajatID, @venitImpozabil, @impozit OUTPUT
print 'impozit = ' + cast(@impozit as nvarchar(32))

--calculam salariul net al angajatului
exec spCalculSalariuNet @LunaID, @AngajatID, @venitNet, @impozit, @salariulNet OUTPUT
print 'salariu net = ' + cast(@salariulNet as nvarchar(32))

--MODIFIED: Cristina Muntean ... calcul total retineri
--calculam total retineri angajat
exec spCalculRetineriAngajat @LunaID, @AngajatID, @retineri OUTPUT
print 'retineri = ' + cast(@retineri as nvarchar(32))

--calculam restul de plata al angajatului
exec spCalculRestPlata @LunaID, @AngajatID, @salariulNet, @retineri, @restPlata OUTPUT
print 'Rest plata = ' + cast(@restPlata as nvarchar(32))

--MODIFIED: Cristina Muntean ... sunt inserate datele in tabele

--suma primelor
set @prime = (SELECT (PrimeProiect+PrimeSpeciale)as prime
              FROM sal_SituatieLunaraAngajati
              WHERE AngajatID=@AngajatID AND LunaID=@LunaID) 

--avans
set @avans = (SELECT Avans
              FROM sal_SituatieLunaraAngajati
              WHERE AngajatID=@AngajatID AND LunaID=@LunaID) 
       
--alte retineri       
set @alteRetineri = (SELECT Retineri
              FROM sal_SituatieLunaraAngajati
              WHERE AngajatID=@AngajatID AND LunaID=@LunaID) 

--se calculeaza totalul retinerilor dupa formula:
--totalRetineri = avans + alteRetineri + contributieIndividualaSomaj + contributieIndividualaAsigurariSociale + contributieIndividualaAsigurariSanatate + impozit      
set @totalRetineri = @retineri + @contribIndivSomaj + @contribIndivAsigSociale + @contribIndivAsigSanatate + @impozit

--este inserata o inregistrare in tabela sal_StatDePlata
begin tran IStatDePlata
	insert into sal_StatDePlata with(xlock) (AngajatID, LunaID, Prime, AlteDrepturi, IndemnizatieConcediuMedical,
	VenitBrut, VenitNet, DeduceriPersonale, BazaImpozitare, Impozit, SalariuNet, Avans, Retineri, TotalRetineri,
	RestDePlata) 
	values (@AngajatID, @LunaID, @prime, @alteDrepturi, @indemnizatieConcediuMedical,
	@venitBrut, @venitNet, @deduceriPersonale, @venitImpozabil, @impozit, @salariulNet, @avans, @alteRetineri, @totalRetineri,
	@restPlata) 
	if(@@ERROR <> 0)
	begin
		rollback tran IStatDePlata
	end
	else
	begin
		commit tran IStatDePlata
	end

--este obtinut id-ul pentru fiecare baza de calcul
set @bcContribIndivSomajID = (SELECT BazaCalculID
							  FROM sal_BazeCalculTipuri
							  WHERE Cod = 'BCISOM')
--print 'bcContribIndivSomajID = ' + cast(@bcContribIndivSomajID as nvarchar(32))
							  
set @bcContribIndivAsigSocialeID = (SELECT BazaCalculID
							  FROM sal_BazeCalculTipuri
							  WHERE Cod = 'BCICAS')
--print 'bcContribIndivAsigSocialeID = ' + cast(@bcContribIndivAsigSocialeID as nvarchar(32))

set @bcContribIndivAsigSanatateID = (SELECT BazaCalculID
							  FROM sal_BazeCalculTipuri
							  WHERE Cod = 'BCISAN')	
--print 'bcContribIndivAsigSanatateID = ' + cast(@bcContribIndivAsigSanatateID as nvarchar(32))
							  
--sunt inserate bazele de calcul in tabela sal_BazaCalculLuna
--baza de calcul al contributiei individuale la somaj
begin tran IBazaCalculIndivSomaj
	insert into sal_BazeCalculLuna with(xlock) (AngajatID, BazaCalculID, LunaID, Valoare) 
	values (@AngajatID, @bcContribIndivSomajID, @LunaID, @bazaCalculContribIndivSomaj) 
	if(@@ERROR <> 0)
	begin
		rollback tran IBazaCalculIndivSomaj
	end
	else
	begin
		commit tran IBazaCalculIndivSomaj
	end

--baza de calcul al contributiei individuale de asigurari sociale	
begin tran IBContribIndivAsigSociale
	insert into sal_BazeCalculLuna with(xlock) (AngajatID, BazaCalculID, LunaID, Valoare) 
	values (@AngajatID, @bcContribIndivAsigSocialeID, @LunaID, @bazaCalculContribIndivAsigSociale) 
	if(@@ERROR <> 0)
	begin
		rollback tran IBCContribIndivAsigSociale
	end
	else
	begin
		commit tran IBCContribIndivAsigSociale
	end
	
--baza de calcul al contributiei individuale de asigurari de sanatate	
begin tran IBCContribIndivAsigSanatate
	insert into sal_BazeCalculLuna with(xlock) (AngajatID, BazaCalculID, LunaID, Valoare) 
	values (@AngajatID, @bcContribIndivAsigSanatateID, @LunaID, @bazaCalculContribIndivAsigSanatate) 
	if(@@ERROR <> 0)
	begin
		rollback tran IBCContribIndivAsigSanatate
	end
	else
	begin
		commit tran IBCContribIndivAsigSanatate
	end

	
--este obtinut id-ul pentru fiecare contributie
set @contribIndivSomajID = (SELECT ContributieIndivID
							  FROM sal_ContributiiIndivTipuri
							  WHERE Cod = 'CISOM')
--print 'contribIndivSomajID = ' + cast(@contribIndivSomajID as nvarchar(32))
							  
set @contribIndivAsigSocialeID = (SELECT ContributieIndivID
							  FROM sal_ContributiiIndivTipuri
							  WHERE Cod = 'CICAS')
--print 'contribIndivAsigSocialeID = ' + cast(@contribIndivAsigSocialeID as nvarchar(32))

set @contribIndivAsigSanatateID = (SELECT ContributieIndivID
							  FROM sal_ContributiiIndivTipuri
							  WHERE Cod = 'CISAN')	
--print 'contribIndivAsigSanatateID = ' + cast(@contribIndivAsigSanatateID as nvarchar(32))

--sunt inserate contributiile individuale in tabela sal_ContributiiIndivLuna
--contributia individuale la somaj
begin tran IContribIndivSomaj
	insert into sal_ContributiiIndivLuna with(xlock) (AngajatID, ContributieIndivID, LunaID, Valoare) 
	values (@AngajatID, @contribIndivSomajID, @LunaID, @contribIndivSomaj) 
	if(@@ERROR <> 0)
	begin
		rollback tran IContribIndivSomaj
	end
	else
	begin
		commit tran IContribIndivSomaj
	end

--baza de calcul al contributiei individuale de asigurari sociale	
begin tran ICalculContribIndivAsigSociale
	insert into sal_ContributiiIndivLuna with(xlock) (AngajatID, ContributieIndivID, LunaID, Valoare) 
	values (@AngajatID, @contribIndivAsigSocialeID, @LunaID, @contribIndivAsigSociale) 
	if(@@ERROR <> 0)
	begin
		rollback tran IContribIndivAsigSociale
	end
	else
	begin
		commit tran IContribIndivAsigSociale
	end
	
--baza de calcul al contributiei individuale de asigurari de sanatate	
begin tran IContribIndivAsigSanatate
	insert into sal_ContributiiIndivLuna with(xlock) (AngajatID, ContributieIndivID, LunaID, Valoare) 
	values (@AngajatID, @contribIndivAsigSanatateID, @LunaID, @contribIndivAsigSanatate) 
	if(@@ERROR <> 0)
	begin
		rollback tran IContribIndivAsigSanatate
	end
	else
	begin
		commit tran IContribIndivAsigSanatate
	end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor: Cristina Muntean
	Data: 15.03.2005
	Nume: spGetStatDePlata
	Parametrii: @AngajatorID...id-ul angajatorului
				@LunaID...id-ul lunii
	Descriere: returneaza statul de plata pentru angajatorul trimis ca parametru pe luna cu id-ul trimis ca parametru
*/
CREATE PROCEDURE spGetStatDePlata
(
	@AngajatorID int, --id-ul angajatorului
	@LunaID int --id-ul lunii
)
AS
	--selecteaza toate datele din sal_StatDePlata, iar din sal_SituatieLunaraAngajati, salariul de incadrare si indemnizatia de conducere pentru toti angajatii 
	--care apartin de angajatorul cu id-ul trimis ca parametru, pe luna cu id-ul trimis ca parametru
	SELECT  *
	FROM   v_StatDePlata
	WHERE AngajatorID=@AngajatorID AND LunaID=@LunaID 
	ORDER BY NumeIntreg
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE dbo.tm_GetIntervaleAbsentaMedicalaContinuare
(
@AbsentaID int
)

AS

select *

from tm_IntervaleAbsentaContinuare

where AbsentaID= @AbsentaID

Order by DataStart

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:			Dovlecel Vlad
* Nume:			InsertUpdateDeleteIntervalAbsentaAngajat
* Data:	Adauga, modifica, sterge o inregistrare in tabelul tm_IntervaleAbsentaContinuare
*/

CREATE PROCEDURE tm_InsertUpdateDeleteIntervalAbsentaMedicalaContinuare
(
	@tip_actiune int = 0,	--0 insert, 1 update, 2 delete
	@AbsentaContinuareID int,
	@AbsentaID int,
	@DataStart datetime,
	@DataEnd datetime,
	@AngajatID int,
	@Observatii ntext = null,
	@BoalaID int
)

as

declare @rc int
set @rc = 0

begin tran IUDIntervalAbsentaContinuare

if(@tip_actiune = 0)
begin	--Insert IntervalAbsenta
	insert into tm_IntervaleAbsentaContinuare with(xlock) 
			(
			AbsentaID,
			DataStart,
			DataEnd,
			BoalaID,
			Observatii
			) 
		
		values  (
			@AbsentaID,
			@DataStart,
			@DataEnd,
			@BoalaID,
			@Observatii
			) 
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIntervalAbsentaContinuare
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIntervalAbsentaContinuare
		set @rc = 0
	end
end
else if(@tip_actiune = 1)
begin	--Update Continuare absenta medicala
	update tm_IntervaleAbsentaContinuare  with(xlock) set 

		AbsentaID=@AbsentaID,
		DataStart=@DataStart,
		DataEnd=@DataEnd, 
		BoalaID = @BoalaID,
		Observatii = @Observatii
	
		where  AbsentaContinuareID = @AbsentaContinuareID
		
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIntervalAbsentaContinuare
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIntervalAbsentaContinuare
		set @rc = 0
	end
end
else if(@tip_actiune = 2)
begin	--Delete IntervalAbsentaMedicalaContinuare
	delete from tm_IntervaleAbsentaContinuare with(xlock) where AbsentaContinuareID = @AbsentaContinuareID
	if(@@ERROR <> 0)
	begin
		rollback tran IUDIntervalAbsentaContinuare
		set @rc = @@ERROR
	end
	else
	begin
		commit tran IUDIntervalAbsentaContinuare
		set @rc = 0
	end
end
else
	rollback tran IUDIntervalAbsentaContinuare

return @rc

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/*
	Autor:      Cristina Muntean
	Data:       1.03.2005
	Nume:       spCalculAlteDrepturiBrut
	Parametrii: --parametrii de intrare
				@AngajatID int, --id-ul angajatului
				@LunaID int, --id-ul lunii
					
				--parametru de iesire
				@AlteDrepturiBrut money OUTPUT
	Descriere:  Calculeaza alte drepturi in valoare bruta data fiind valoarea neta a acestora
*/
CREATE PROCEDURE spCalculAlteDrepturiBrut
(
	--parametrii de intrare
	@AngajatID int, --id-ul angajatului
	@LunaID int, --id-ul lunii
		
	--parametru de iesire
	--alte drepturi in valoare bruta
	@AlteDrepturiBrut money OUTPUT
)

AS
	--alte drepturi in valoare neta ale angajatului
	DECLARE @AlteDrepturiNet money
	--venitul brut initial al angajatului
	DECLARE @VenitBrutI money
	--venitul brut final al angajatului
	DECLARE @VenitBrutF money
	--restul de plata initial
	DECLARE @RestPlataI money
	--restul de plata final al angajatului
	DECLARE @RestPlataF money
	--@RestPlataI-@ValoareEroareCalcul<=@RestPlataF<=@RestPlataI+@ValoareEroareCalcul
	--start interval pentru restul de plata final
	DECLARE @StartIntervalRestPlataF money
	--end interval pentru restul de plata final
	DECLARE @EndIntervalRestPlataF money
	--venit brut
	DECLARE @VenitBrut money
	--numarul de cifre
	DECLARE @NrCifreVB int
	--suma pe care o folosim pentru modificare
	DECLARE @SumaModificare money
	--este declarat coeficientul de inmultire 
	DECLARE @CoefInmultire int
	--este declarata o variabila de tip bit 
	DECLARE @ok bit
	--valoarea permisa pentru eroarea de calcul
	--@RestPlataI-@ValoareEroareCalcul<=@RestPlataF<=@RestPlataI+@ValoareEroareCalcul
	declare @ValoareEroareCalcul money 
	
	--setare valoare permisa pentru eroarea de calcul
	set @ValoareEroareCalcul = (SELECT Valoare
								FROM sal_VariabileGlobaleValori INNER JOIN
								sal_VariabileGlobaleTipuri ON sal_VariabileGlobaleValori.VariabilaGlobalaID = sal_VariabileGlobaleTipuri.VariabilaGlobalaID 
								WHERE sal_VariabileGlobaleValori.LunaID=@LunaID AND sal_VariabileGlobaleTipuri.Cod='VALERR')						
			
	--alte drepturi in valoare neta
	SET @AlteDrepturiNet = (SELECT  AlteDrepturiNet
					FROM Sal_SituatieLunaraAngajati INNER JOIN
					Angajati ON Sal_SituatieLunaraAngajati.AngajatID=Angajati.AngajatID
					WHERE Sal_SituatieLunaraAngajati.AngajatID=@AngajatID AND Sal_SituatieLunaraAngajati.LunaID=@LunaID)
					
	--este calculat venitul brut initial
	exec spCalculCompletVenitBrut @LunaID, @AngajatID, @VenitBrutI OUTPUT
	--este calculat restul de plata initial
	exec spCalculCompletRestDePlata @LunaID, @AngajatID, @VenitBrutI, @RestPlataI OUTPUT

	--sunt tiparite valorile
	print 'venit brut initial '+CONVERT(nvarchar(32),@VenitBrutI)
	print 'rest plata initial '+CONVERT(nvarchar(32),@RestPlataI)
	print 'valoare eroare calcul ='+CONVERT(nvarchar(32),@ValoareEroareCalcul)
	
	--este setata valoare restului de plata final
	SET @RestPlataF = @RestPlataI + @AlteDrepturiNet
	print 'rest plata final ='+CONVERT(nvarchar(32),@RestPlataF)
	
	--este calculata prima valoare a intervalului caruia trebuie sa ii apartina restul de plata final
	SET @StartIntervalRestPlataF = @RestPlataF - @ValoareEroareCalcul
	print 'start interval rest de plata final ='+CONVERT(nvarchar(32),@StartIntervalRestPlataF)
	
	--este calculata ultima valoare a intervalului caruia trebuie sa ii apartina restul de plata final
	SET @EndIntervalRestPlataF = @RestPlataF + @ValoareEroareCalcul
	print 'end interval rest de plata final ='+CONVERT(nvarchar(32),@EndIntervalRestPlataF)
	
	--initial numarul de cifre e 0
	SET @NrCifreVB = 0	
	--@VenitBrut primeste valoarea venitului brut initial
	SET @VenitBrut = @VenitBrutI
	--suma de modificare este initializata cu 1
	SET @SumaModificare=1
	--este setat coeficientul de inmultire 
	SET @CoefInmultire = 1
	--este setata varialbila de tip bit pe 0
	SET @ok=0
	
	--este calculat numarul de cifre si este calculata suma initiala de modificare
	WHILE(@VenitBrut>=1)
	begin 
		SET @SumaModificare = @SumaModificare*10
		SET @NrCifreVB = @NrCifreVB + 1
		SET @VenitBrut=@VenitBrut/10
	end
	--deoarece se face o inmultire in plus se ajusteaza suma de modificare prin impartire la 10
	SET @SumaModificare = @SumaModificare/10
	
	--sunt tiparite rezultatele
	print 'numar cifre venit brut ='+CONVERT(nvarchar(32),@NrCifreVB)
	print 'suma modificare ='+CONVERT(nvarchar(32),@SumaModificare)
	
	
	--daca restul de plata initial e cuprins in interval atunci venitul brut final primeste valoarea venitului brut initial
	if((@StartIntervalRestPlataF<= @RestPlataI) AND (@RestPlataI<=@EndIntervalRestPlataF))
		SET @VenitBrutF = @VenitBrutI
	else
		begin
			SET @VenitBrutF = @VenitBrutI + @SumaModificare
			print 'venit brut final ='+CONVERT(nvarchar(32),@VenitBrutF)
			
			WHILE((@ok = 0)AND(@SumaModificare > 1)) 
			begin
				--este calculat restul de plata initial
				exec spCalculCompletRestDePlata @LunaID, @AngajatID, @VenitBrutF, @RestPlataF OUTPUT
				print 'rest plata final ='+CONVERT(nvarchar(32),@RestPlataF)
				
				--daca restul de plata este in intervalul stabilit in functie de suma admisa de eroare a calculului
				if((@StartIntervalRestPlataF<= @RestPlataF)AND(@RestPlataF<=@EndIntervalRestPlataF))
					--se iese din while
					SET @ok = 1
				else
					begin
						--daca valoarea restului de plata este mai mica decat valoare de start a intervalului
						if (@StartIntervalRestPlataF > @RestPlataF)
							begin
								--este incrementat coeficientul de inmultire
								SET @CoefInmultire = @CoefInmultire + 1
					
								--daca coeficientul de imnultire a depasit valoare 9
								if(@CoefInmultire > 9)
								begin
									--este crescuta suma de modificare
									SET @SumaModificare = @SumaModificare*10
						
									--coeficientul de inmultire este setat la valoarea lui minima
									SET @CoefInmultire = 1
								end --if(@CoefInmultire > 9)	
							end --if (@StartIntervalRestPlataF > @RestPlataF)
					
						--daca valoarea restului de plata este mai mica decat valoare de sfarsit a intervalului	
						if(@EndIntervalRestPlataF < @RestPlataF)
							begin
								--se revine la ultima valoare a venitului brut aproximat
								SET @VenitBrutF = @VenitBrutF - @SumaModificare
								print 'Venit brut final dupa scadere= '+CONVERT(nvarchar(32),@VenitBrutF)	
					
								--coeficientul de inmultire devine 1
								SET @CoefInmultire = 1	
								--suma de modificare este impartita la 10
								SET @SumaModificare = @SumaModificare/10
							end --else pt if (@StartIntervalRestPlataF > @RestPlataF)

						--este adunata la venitul brut suma de modificare						
						SET @VenitBrutF = @VenitBrutF + @SumaModificare 
					end --else
					
					--sunt tiparite valorile rezultate
					print 'coef inmultire = '+CONVERT(nvarchar(32),@CoefInmultire)
					print 'suma modificare = '+CONVERT(nvarchar(32),@SumaModificare)
					print 'venit brut final = '+CONVERT(nvarchar(32),@VenitBrutF)	
					
			end --while
		end --else
	 
	--alte drepturi in valoare bruta = diferenta dintre venitul brut initial si venitul brut final
	SET @AlteDrepturiBrut = @VenitBrutF - @VenitBrutI

RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
* Autor:		Mircea Albutiu, PSE RO BS TH
* Nume:			InsertAngajat
* Descriere:	Insereaza un angajat 
* Modificat:    Cristina Raluca Muntean, am adaugat: Sporuri, AlteAdaosuri, NrZileCOSupl, EchIndProtectie,
				EchIndLucru, MatIgiSan, AlimProtectie, AlteDrSiObl, AlteClauzeCIM, PerProba
	         Ionel Popa - 07.02.2005: am adaugat un camp nou: AlerteSpeciale precum si adaugarea unui apel de procedura stocata InsertAlerte
*/
CREATE PROCEDURE tmp_InsertUpdateAngajat_010205
(
--Angajat
		@AngajatID int,
		@AngajatorID int,
		@Marca nvarchar(8),
		@Nume nvarchar(50),
		@Prenume nvarchar(50),
		@NumeAnterior nvarchar(50),
		@TitluID int = NULL,
		@Poza image = NULL,
		@StudiuID int,
		@AnAbsolvire smallint,
		@NrDiploma varchar(50),
		@Descriere nvarchar(100) = NULL,
		@ModIncadrare bit,
		@ProgramLucru tinyint,
		@Telefon nvarchar(25) = NULL,
		@StareCivila tinyint,
		@NrCopii tinyint,
		@Sex char(1),
		@TipFisaFiscala bit,
		@AniVechimeMunca tinyint,
		@LuniVechimeMunca tinyint,
		@ZileVechimeMunca tinyint,
		@AreCardBancar bit,
--pt categoria de incadrare
		@CategorieID int,
--pt perioada determinata
		@PerioadaDeterminata bit,
		@DataPanaLa datetime=NULL,
		@DataDeLa datetime,
--pt contract munca
       		@NrContractMunca varchar(50),
		@DataInregContractMunca datetime,
		@EchIndProtectie nvarchar(100),
		@EchIndLucru nvarchar(100),
		@MatIgiSan nvarchar(100),
		@AlimProtectie nvarchar(100),
		@AlteDrSiObl nvarchar(100),
		@AlteClauzeCIM nvarchar(100),
		@PerProba nvarchar(50),
-- pt invaliditate
		@Invaliditate smallint,
--pt salariu si indemnizatia de conducere
		@FunctieID int,
		@CentruCostID int,
		@DepartamentID int,
	             @SalariuBaza money,
		@IndemnizatieConducere money,
		@Sporuri money,
		@AlteAdaosuri money,
		@SumaMajorare money = null,
		@DataMajorare datetime = null,
		@NrZileCOAn int,  
		@NrZileCOSupl int,
----------------------------------------------------------------------------------------------
		@SefID int,
--Nationalitate
		--@Nationalitate nvarchar(50),
		@Nationalitate int,
		@DataNasterii datetime,
		@TaraNastereID int,
		@JudetNastereID int,
		@LocalitateNastere nvarchar(50),
		@PrenumeMama nvarchar(50),
		@PrenumeTata nvarchar(50),
--CarteIdentitate
		@CNP numeric,
		@CNPAnterior numeric,
		@SerieCI char(2)='',
		@NumarCI bigint=0,
		@EliberatDeCI nvarchar(50)='',
		@DataEliberariiCI datetime,
		@ValabilPanaLaCI datetime,
--Pasaport
		@SeriePas nvarchar(10)='',
		@NumarPas bigint=0,
		@EliberatDePas nvarchar(50)='',
		@DataEliberariiPas datetime,
		@ValabilPanaLaPas datetime,
		/*@PermMuncaEliberat datetime,
		@PermMuncaExpira datetime,
		@PermSedereEliberat datetime,
		@PermSedereExpira datetime,
		@NrPermisMunca bigint=0,*/

--Permis Munca
		@SeriePermisMunca nvarchar(10) = '',
		@NrPermisMunca bigint,
		@DataEliberarePermisMunca datetime,
		@DataExpirarePermisMunca datetime,
--Legitimatie sedere
		@SerieLegitimatieSedere nvarchar(10) = '',
		@NrLegitimatieSedere bigint,
		@DataEliberareLegitimatieSedere datetime,
		@DataExpirareLegitimatieSedere datetime,
--NIF
		@NIF numeric,
		--0 - cetatean cu domiciliul in tara de baza (Romania) si nationalitatea tarii de baza (romana)
		--1 - cetatea cu domiciliul in alta tara decat cea de baza (nu Romania) si nationalitate tarii de baza (romana)
		--2 - cetatea cu domiciliul in alta tara decat cea de baza (nu Romania) si nationalitate diferita de a tarii de baza (nu romana)

		@TipNationalitateDomiciliu smallint = 0,
--Domiciliul
		@TaraID int,
		@Localitate nvarchar(50),
		@JudetSectorID int,
		@Strada nvarchar(50),
		@NumarStr nvarchar(10),
		@CodPostal nvarchar(20) = NULL,
		@Bloc nvarchar(5) = NULL,
		@Scara nvarchar(5) = NULL,
		@Etaj nvarchar(5) = NULL,
		@Apartament nvarchar(5) = NULL,
--Resedinta
		@TaraIDRes int,
		@LocalitateRes nvarchar(50),
		@JudetSectorIDRes int,
		@StradaRes nvarchar(50),
		@NumarStrRes nvarchar(10),
		@CodPostalRes nvarchar(20) = NULL,
		@BlocRes nvarchar(5) = NULL,
		@ScaraRes nvarchar(5) = NULL,
		@EtajRes nvarchar(5) = NULL,
		@ApartamentRes nvarchar(5) = NULL,
--Carnet Munca
		@Serie nvarchar(5)='',
		@Numar nvarchar(10)='',
		@Emitent nvarchar(50)='',
		@DataEmiterii datetime,
		@NrInregITM nvarchar(25)='',

--Mail & Telefon
		@Email nvarchar(255) ,
		@TelMunca nvarchar(255),

--Alerte Speciale
		@AlerteSpeciale nvarchar(2056)='',

--Output
		@new_id int = 0 output
)
as

declare	@rc int
set @rc = 0

declare @tip_actiune int --0-insert, 1-update
set @tip_actiune = 0

/*declare @dateID int
set @dateID = -1*/


begin transaction InsertUpdateAngajat

select @rc = count(AngajatID) from Angajati where AngajatID = @AngajatID

if(@rc = 0)
begin	--Insert Angajat
	insert into Angajati with (xlock)
		(AngajatorID, Marca, NumeIntreg, Nume, Prenume, NumeAnterior, TitluID, Poza, PrenumeMama, PrenumeTata, StudiuID, AnAbsolvire, NrDiploma, 
		Descriere, ModIncadrare, ProgramLucru, Telefon, DataNasterii, TaraNastereID, JudetNastereID, LocalitateNastere, 
		StareCivila, NrCopii, Sex, Nationalitate/*, CNP, CNPAnterior*/, TipFisaFiscala, AniVechimeMunca, LuniVechimeMunca, 
		ZileVechimeMunca, AreCardBancar, PerioadaDeterminata,DataPanaLa,DataDeLa,SefID,NrContractMunca,DataInregContractMunca,EchIndProtectie, EchIndLucru, MatIgiSan, AlimProtectie,
		AlteDrSiObl, AlteClauzeCIM,PerProba,Invaliditate,SalariuBazaActual,IndemnizatieConducereActual,Sporuri,AlteAdaosuri,SumaMajorare,DataMajorare,NrZileCOAn,NrZileCOSupl,
		CategorieID,Email,TelMunca/*,PermMuncaEliberat,PermMuncaExpira,PermSedereEliberat,PermSedereExpira,NrPermisMunca */ )
		values
		(@AngajatorID, @Marca, @Nume+' '+@Prenume, @Nume, @Prenume, @NumeAnterior, @TitluID, @Poza, @PrenumeMama, @PrenumeTata, @StudiuID, @AnAbsolvire, 
		@NrDiploma, @Descriere, @ModIncadrare, @ProgramLucru, @Telefon, @DataNasterii, @TaraNastereID, @JudetNastereID, 
		@LocalitateNastere, @StareCivila, @NrCopii, @Sex, @Nationalitate/*, @CNP, @CNPAnterior*/, @TipFisaFiscala, @AniVechimeMunca, 
		@LuniVechimeMunca, @ZileVechimeMunca, @AreCardBancar,@PerioadaDeterminata,@DataPanaLa, @DataDeLa, @SefID,
		@NrContractMunca,@DataInregContractMunca,@EchIndProtectie,@EchIndLucru,@MatIgiSan, @AlimProtectie, @AlteDrSiObl, @AlteClauzeCIM, @PerProba,@Invaliditate,
		@SalariuBaza,@IndemnizatieConducere,@Sporuri, @AlteAdaosuri, @SumaMajorare,@DataMajorare,@NrZileCOAn, @NrZileCOSupl,@CategorieID,@Email,@TelMunca/*,
		@PermMuncaEliberat,@PermMuncaExpira,@PermSedereEliberat,@PermSedereExpira,@NrPermisMunca */ )
	if(@@ERROR <> 0)
		set @rc = @@ERROR
	else
	begin
		set @AngajatID = @@IDENTITY

		--inseram alertele
		exec @rc = insertAlerte  @AngajatID, @AlerteSpeciale
		set @new_id = @AngajatID

		set @rc = 0
	end
	
	set @tip_actiune = 0

	if(@rc = 0)		--Insert functie : Dovle
		exec @rc = InsertUpdateDeleteIstoricFunctie 0, @AngajatID, @FunctieID, @DataDeLa

end
else
begin	--Update Angajat
	update Angajati with (xlock) set AngajatorID = @AngajatorID, Marca = @Marca, NumeIntreg = @Nume+' ' + @Prenume,Nume = @Nume, Prenume = @Prenume, NumeAnterior=@NumeAnterior,
		TitluID = @TitluID, Poza = @Poza, PrenumeMama = @PrenumeMama, PrenumeTata = @PrenumeTata, StudiuID = @StudiuID, 
		AnAbsolvire = @AnAbsolvire, NrDiploma = @NrDiploma, Descriere = @Descriere, ModIncadrare = @ModIncadrare, 
		ProgramLucru = @ProgramLucru, Telefon = @Telefon, DataNasterii = @DataNasterii, TaraNastereID = @TaraNastereID, 
		JudetNastereID = @JudetNastereID, LocalitateNastere = @LocalitateNastere, StareCivila = @StareCivila, 
		NrCopii = @NrCopii, Sex = @Sex, Nationalitate = @Nationalitate/*, CNP = @CNP, CNPAnterior=@CNPAnterior*/, TipFisaFiscala = @TipFisaFiscala, 
		AniVechimeMunca = @AniVechimeMunca, LuniVechimeMunca = @LuniVechimeMunca, ZileVechimeMunca = @ZileVechimeMunca, 
		AreCardBancar = @AreCardBancar, PerioadaDeterminata=@PerioadaDeterminata,DataPanaLa=@DataPanaLa, DataDeLa=@DataDeLa, SefID = @SefID,
		NrContractMunca=@NrContractMunca, DataInregContractMunca=@DataInregContractMunca, EchIndProtectie=@EchIndProtectie,
		EchIndLucru=@EchIndLucru, MatIgiSan=@MatIgiSan, AlimProtectie=@AlimProtectie, AlteDrSiObl=@AlteDrSiObl, AlteClauzeCIM=@AlteClauzeCIM,
		PerProba=@PerProba,Invaliditate=@Invaliditate,SalariuBazaActual=@SalariuBaza,IndemnizatieConducereActual=@IndemnizatieConducere,Sporuri=@Sporuri, AlteAdaosuri=@AlteAdaosuri,
		SumaMajorare=@SumaMajorare,DataMajorare=@DataMajorare,NrZileCOAn=@NrZileCOAn, NrZileCOSupl=@NrZileCOSupl,CategorieID=@CategorieID,Email=@Email,TelMunca=@TelMunca/*,
		PermMuncaEliberat=@PermMuncaEliberat,PermMuncaExpira=@PermMuncaExpira,PermSedereEliberat=@PermSedereEliberat,PermSedereExpira=@PermSedereExpira,NrPermisMunca=@NrPermisMunca*/
		where AngajatID = @AngajatID
	if(@@ERROR <> 0)
		set @rc = @@ERROR
	else
	begin
		set @new_id = @AngajatID
		set @rc = 0
	end

	set @tip_actiune = 1
end

if( @tip_actiune = 0 )
begin
	--nationalitatea tarii de baza (romana) si domiciliu in tara de baza (Romania)
	if( @TipNationalitateDomiciliu=0 ) begin
		--Insert sau update carte de identitate
		if(@rc = 0 and @CNP != 0 and @SerieCI != '' and @NumarCI is not null and @NumarCI>0 and @EliberatDeCI!='' and @DataEliberariiCI is not null and @ValabilPanaLaCI is not null )
			exec @rc = InsertUpdateDeleteCarteIdentitate @tip_actiune, -1, @AngajatID, @CNP, @CNPAnterior, @SerieCI, @NumarCI, @EliberatDeCI, @DataEliberariiCI, @ValabilPanaLaCI
		--Insert sau update pasaport
		if(@rc = 0 and @SeriePas!='' and @NumarPas is not null and @NumarPas>0 and @EliberatDePas!='' and @DataEliberariiPas is not null and @ValabilPanaLaPas is not null)
			exec @rc = InsertUpdateDeletePasaport @tip_actiune, -1, @AngajatID, @SeriePas, @NumarPas, @EliberatDePas, @DataEliberariiPas, @ValabilPanaLaPas
		/*if( @tip_actiune = 1 ) begin
			exec @rc = SetActivAllPermiseMuncaAngajat @AngajatID, 0
			exec @rc = SetActivAllLegitimatiiSedereAngajat @AngajatID, 0
			exec @rc = SetActivAllNIFAngajat @AngajatID, 0
		end*/
	end
	
	--nationalitatea tarii de baza (romana) si domiciliu in alt tara decat tara de baza (nu Romania)
	if( @TipNationalitateDomiciliu=1 ) begin
		--Insert sau update carte de identitate
		if(@rc = 0 and @CNP != 0 and @SerieCI != '' and @NumarCI is not null and @NumarCI>0 and @EliberatDeCI!='' and @DataEliberariiCI is not null and @ValabilPanaLaCI is not null )
			exec @rc = InsertUpdateDeleteCarteIdentitate @tip_actiune, -1, @AngajatID, @CNP, @CNPAnterior, @SerieCI, @NumarCI, @EliberatDeCI, @DataEliberariiCI, @ValabilPanaLaCI
		--Insert sau update pasaport
		if(@rc = 0 and @SeriePas!='' and @NumarPas is not null and @NumarPas>0 and @EliberatDePas!='' and @DataEliberariiPas is not null and @ValabilPanaLaPas is not null)
			exec @rc = InsertUpdateDeletePasaport @tip_actiune, -1, @AngajatID, @SeriePas, @NumarPas, @EliberatDePas, @DataEliberariiPas, @ValabilPanaLaPas
		--Insert sau update legitimatie sedere
		if( @rc = 0 and @SerieLegitimatieSedere<>'' and @NrLegitimatieSedere is not null and @NrLegitimatieSedere>0 and @DataEliberareLegitimatieSedere is not null and @DataExpirareLegitimatieSedere is not null ) begin		
			/*if( @tip_actiune = 1 )
				Select @dateID = LegitimatieSedereID From LegitimatiiSedere Where AngajatID=@AngajatID and Activ=1
			exec @rc = InsertUpdateDeleteLegitimatieSedere @tip_actiune, @dateID, @AngajatID, @SerieLegitimatieSedere, @NrLegitimatieSedere, @DataEliberareLegitimatieSedere, @DataExpirareLegitimatieSedere*/
			exec @rc = InsertUpdateDeleteLegitimatieSedere @tip_actiune, -1, @AngajatID, @SerieLegitimatieSedere, @NrLegitimatieSedere, @DataEliberareLegitimatieSedere, @DataExpirareLegitimatieSedere
		end
	
		--Insert sau Update NIF
		if( @rc = 0 and @NIF is not null and @NIF>0) begin		--Insert sau update NIF
			/*if( @tip_actiune = 1 )
				Select @dateID = NIFID From NIF Where AngajatID=@AngajatID and Activ=1
			exec @rc = InsertUpdateDeleteNIF @tip_actiune, @dateID, @AngajatID, @NIF*/
			exec @rc = InsertUpdateDeleteNIF @tip_actiune, -1, @AngajatID, @NIF
		end
	
		/*if( @tip_actiune = 1 ) begin
			exec @rc = SetActivAllPermiseMuncaAngajat @AngajatID, 0
		end*/
	end
	
	--nationalitatea alta decat a tarii de baza (nu romana) si domiciliu in alta tara decat tara de baza (nu Romania)
	if( @TipNationalitateDomiciliu=2 ) begin
		--Insert sau update pasaport
		if(@rc = 0 and @SeriePas!='' and @NumarPas is not null and @NumarPas>0 and @EliberatDePas!='' and @DataEliberariiPas is not null and @ValabilPanaLaPas is not null)
			exec @rc = InsertUpdateDeletePasaport @tip_actiune, -1, @AngajatID, @SeriePas, @NumarPas, @EliberatDePas, @DataEliberariiPas, @ValabilPanaLaPas
		--Insert sau update permis munca
		if(@rc = 0 and @SeriePermisMunca !='' and @NrPermisMunca is not null and @NrPermisMunca>0 and @DataEliberarePermisMunca is not null and @DataExpirarePermisMunca is not null ) begin		
			/*if( @tip_actiune = 1 )
				Select @dateID = PermisMuncaID From PermiseMunca Where AngajatID=@AngajatID and Activ=1
			exec @rc = InsertUpdateDeletePermisMunca @tip_actiune, @dateID, @AngajatID, @NrPermisMunca, @SeriePermisMunca, @DataEliberarePermisMunca, @DataExpirarePermisMunca*/
			exec @rc = InsertUpdateDeletePermisMunca @tip_actiune, -1, @AngajatID, @NrPermisMunca, @SeriePermisMunca, @DataEliberarePermisMunca, @DataExpirarePermisMunca
		end
		--Insert sau update legitimatie sedere
		if( @rc = 0 and @SerieLegitimatieSedere<>'' and @NrLegitimatieSedere is not null and @NrLegitimatieSedere>0 and @DataEliberareLegitimatieSedere is not null and @DataExpirareLegitimatieSedere is not null ) begin		
			/*if( @tip_actiune = 1 )
				Select @dateID = LegitimatieSedereID From LegitimatiiSedere Where AngajatID=@AngajatID and Activ=1
			exec @rc = InsertUpdateDeleteLegitimatieSedere @tip_actiune, @dateID, @AngajatID, @SerieLegitimatieSedere, @NrLegitimatieSedere, @DataEliberareLegitimatieSedere, @DataExpirareLegitimatieSedere*/
			exec @rc = InsertUpdateDeleteLegitimatieSedere @tip_actiune, -1, @AngajatID, @SerieLegitimatieSedere, @NrLegitimatieSedere, @DataEliberareLegitimatieSedere, @DataExpirareLegitimatieSedere
		end
	
		--Insert sau Update NIF
		if( @rc = 0 and @NIF is not null and @NIF>0) begin		--Insert sau update NIF
			/*if( @tip_actiune = 1 )
				Select @dateID = NIFID From NIF Where AngajatID=@AngajatID and Activ=1
			exec @rc = InsertUpdateDeleteNIF @tip_actiune, @dateID, @AngajatID, @NIF*/
			exec @rc = InsertUpdateDeleteNIF @tip_actiune, -1, @AngajatID, @NIF
		end
	end
end
else begin
	if( @TipNationalitateDomiciliu=0 ) begin
		exec @rc = SetActivAllPermiseMuncaAngajat @AngajatID, 0
		exec @rc = SetActivAllLegitimatiiSedereAngajat @AngajatID, 0
		exec @rc = SetActivAllNIFAngajat @AngajatID, 0
	end
	else if( @TipNationalitateDomiciliu=1 ) begin
		exec @rc = SetActivAllPermiseMuncaAngajat @AngajatID, 0
	end
	else if( @TipNationalitateDomiciliu=2 ) begin
		exec @rc = SetActivAllCartiIdentitateAngajat @AngajatID, 0
	end
end
/*
--Insert sau update carte de identitate
if(@rc = 0 and @SerieCI != '' and @NumarCI is not null and @NumarCI>0 and @EliberatDeCI!='' and @DataEliberariiCI is not null and @ValabilPanaLaCI is not null )
	exec @rc = InsertUpdateCarteIdentitate @AngajatID, @SerieCI, @NumarCI, @EliberatDeCI, @DataEliberariiCI, @ValabilPanaLaCI

--Insert sau update pasaport
if(@rc = 0 and @SeriePas!='' and @NumarPas is not null and @NumarPas>0 and @EliberatDePas!='' and @DataEliberariiPas is not null and @ValabilPanaLaPas is not null)
	exec @rc = InsertUpdatePasaport @AngajatID, @SeriePas, @NumarPas, @EliberatDePas, @DataEliberariiPas, @ValabilPanaLaPas

--Insert sau update permis munca
if(@rc = 0 and @SeriePermisMunca !='' and @NrPermisMunca is not null and @NrPermisMunca>0 and @DataEliberarePermisMunca is not null and @DataExpirarePermisMunca is not null ) begin		
	if( @tip_actiune = 1 )
		Select @dateID = PermisMuncaID From PermiseMunca Where AngajatID=@AngajatID and Activ=1
	exec @rc = InsertUpdateDeletePermisMunca @tip_actiune, @dateID, @AngajatID, @NrPermisMunca, @SeriePermisMunca, @DataEliberarePermisMunca, @DataExpirarePermisMunca
end

--Insert sau update legitimatie sedere
if( @rc = 0 and @SerieLegitimatieSedere<>'' and @NrLegitimatieSedere is not null and @NrLegitimatieSedere>0 and @DataEliberareLegitimatieSedere is not null and @DataExpirareLegitimatieSedere is not null ) begin		
	if( @tip_actiune = 1 )
		Select @dateID = LegitimatieSedereID From LegitimatiiSedere Where AngajatID=@AngajatID and Activ=1
	exec @rc = InsertUpdateDeleteLegitimatieSedere @tip_actiune, @dateID, @AngajatID, @SerieLegitimatieSedere, @NrLegitimatieSedere, @DataEliberareLegitimatieSedere, @DataExpirareLegitimatieSedere
end

--Insert sau Update NIF
if( @rc = 0 and @NIF is not null and @NIF>0) begin		--Insert sau update NIF
	if( @tip_actiune = 1 )
		Select @dateID = NIFID From NIF Where AngajatID=@AngajatID and Activ=1
	exec @rc = InsertUpdateDeleteNIF @tip_actiune, @dateID, @AngajatID, @NIF
end
*/


if(@rc = 0)		--Insert sau update domiciliu
	exec @rc = InsertUpdateDomiciliu @AngajatID, @TaraID, @Localitate, @JudetSectorID, @Strada, 
				@NumarStr, @CodPostal, @Bloc, @Scara, @Etaj, @Apartament, 'd'

if(@rc = 0)		--Insert sau update resedinta
	exec @rc = InsertUpdateDomiciliu @AngajatID, @TaraIDRes, @LocalitateRes, @JudetSectorIDRes, @StradaRes, 
				@NumarStrRes, @CodPostalRes, @BlocRes, @ScaraRes, @EtajRes, @ApartamentRes, 'r'

if(@rc = 0)		--Insert sau update carte de munca
	exec @rc = InsertUpdateCarnetMunca @AngajatID, @Serie, @Numar, @Emitent, @DataEmiterii, @NrInregITM

if(@rc = 0)		--Insert sau update IstoricCentruCost
	exec @rc = InsertUpdateDeleteIstoricCentruCost @tip_actiune, @AngajatID, @CentruCostID, @DataDeLa

if(@rc = 0)		--Insert sau update IstoricDepartament
	exec @rc = InsertUpdateDeleteIstoricDepartament @tip_actiune, @AngajatID, @DepartamentID, @DataDeLa


if(@rc <> 0)
	rollback tran InsertUpdateAngajat
else
	commit tran InsertUpdateAngajat

return @rc
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.ComunicarePrima
AS
SELECT     AngajatFull.Marca, AngajatFull.Nume, AngajatFull.Prenume, AngajatFull.StareCivila, AngajatFull.Sex, AngajatFull.DepartamentDenumire, 
                      Angajatori.Denumire AS DenumireAngajator
FROM         AngajatFull INNER JOIN
                      Angajatori ON AngajatFull.AngajatorID = Angajatori.AngajatorID 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Muntean Raluca Cristina
--returneaza toate datele pentru A11("Declaratia initiala privind evidenta nominala a asiguratilor si a obligatiilor de plata catre bugetul asigurarilor sociale de stat ANEXA 1.1")
CREATE PROCEDURE dbo.GetA11
(       --parametrii
		@LunaID int,
		@AngajatorID int
)
AS

--declarare variabile
DECLARE @cnpa DECIMAL

--setare variabile
SET @cnpa=0

--returneaza toate datele pentru A11("Declaratia initiala privind evidenta nominala a asiguratilor si a obligatiilor de plata catre bugetul asigurarilor sociale de stat ANEXA 1.1")
--campurile tid(tip declaratie:initiala sau rectificativa) si tipr(tip rectificare) trebuie date de utilizator

--cm= Angajati.ProgramLucru = 8 - > 1
--	  else 0

--cv= Angajati.ProgramLucru = 2 - > 2
--	  Angajati.ProgramLucru = 3 - > 3
--	  Angajati.ProgramLucru = 4 - > 4
--	  Angajati.ProgramLucru = 5 - > 5
--	  Angajati.ProgramLucru = 6 - > 6
--	  Angajati.ProgramLucru = 7 - > 7
--	  Angajati.ProgramLucru = 8 - > 0

--pe=Angajati.Pensionar = 1 and Angajati.ProgramLucru = 2 - > 2
--	 Angajati.Pensionar = 1 and Angajati.ProgramLucru = 3 - > 3
--	 Angajati.Pensionar = 1 and Angajati.ProgramLucru = 4 - > 4
--	 Angajati.Pensionar = 1 and Angajati.ProgramLucru = 5 - > 5
--	 Angajati.Pensionar = 1 and Angajati.ProgramLucru = 6 - > 6
--	 Angajati.Pensionar = 1 and Angajati.ProgramLucru = 7 - > 7
--	 Angajati.Pensionar = 1 and Angajati.ProgramLucru = 8 - > 8

SELECT     CAST(YEAR(CONVERT(varchar, Sal_Luni.Data, 10))AS DECIMAL) AS an,CAST(MONTH(CONVERT(varchar, Sal_Luni.Data, 10))AS DECIMAL) AS ln,CAST(SUBSTRING(Angajatori.CUI_CNP,2,8)AS DECIMAL) AS cf,
           SUBSTRING(Angajatori.NrInregORC, 1, 3) AS rj, CAST(SUBSTRING(Angajatori.NrInregORC, 5, 3)AS DECIMAL) AS rn,CAST(SUBSTRING(Angajatori.NrInregORC, 9, 4)AS DECIMAL)AS ra, 
           AngajatFull.NumeIntreg AS nume, CAST(AngajatFull.CNP AS DECIMAL) as cnp,
           CAST(CASE (AngajatFull.ProgramLucru)
				WHEN 8 THEN 1
				ELSE 0
		   END AS DECIMAL) as cm,
		   CAST(CASE (AngajatFull.ProgramLucru)
				WHEN 8 THEN 0
				ELSE AngajatFull.ProgramLucru
		   END AS DECIMAL) as cv,
		   CAST(CASE AngajatFull.Pensionar
				WHEN 1 THEN AngajatFull.ProgramLucru
				WHEN 0 THEN 0
		   END AS DECIMAL) as pe,
           CAST(Sal_Salarii.BenefAjutorSomaj AS DECIMAL)  AS som, CAST(Sal_Salarii.NrOreLucrate / Sal_Salarii.ProgramLucru + Sal_Salarii.NrOreConcediuBoala / Sal_Salarii.ProgramLucru + Sal_Salarii.NrOreConcediuOdihna
           / Sal_Salarii.ProgramLucru AS DECIMAL) AS tt, CAST(Sal_Salarii.NrOreLucrate / Sal_Salarii.ProgramLucru AS DECIMAL) AS nn, CAST(Sal_Salarii.NrOreLucrateCondDeoseb / Sal_Salarii.ProgramLucru AS DECIMAL) AS dd,
           CAST(Sal_Salarii.NrOreLucrateCondSpeciale / AngajatFull.ProgramLucru AS DECIMAL)AS ss,CAST((Sal_Salarii.Nrppb+Sal_Salarii.Nrppa+Sal_Salarii.Nrppp+Sal_Salarii.Nrppl+Sal_Salarii.Nrppi+Sal_Salarii.Nrppc+Sal_Salarii.Nrppr)AS DECIMAL) as pp,
           CAST(Sal_Salarii.VenitBrut AS DECIMAL) AS tv, CAST(Sal_Salarii.SumaOreLucrate AS DECIMAL) AS tvn, CAST(Sal_Salarii.SumaOreLucrateCondDeoseb AS DECIMAL) AS tvd,CAST(Sal_Salarii.SumaOreLucrateCondSpeciale AS DECIMAL) AS tvs,
           CAST(Sal_Salarii.CASAngajat as DECIMAL) AS casat,CAST(Sal_Salarii.CASTot AS DECIMAL) AS castot, CAST(Sal_Salarii.SUMAB+Sal_Salarii.SUMAA+Sal_Salarii.SUMAP+Sal_Salarii.SUMAL+Sal_Salarii.SUMAI+Sal_Salarii.SUMAC+Sal_Salarii.SUMAR AS DECIMAL) AS bass,
           @cnpa as cnpa, CAST(Sal_Salarii.ProgramLucru AS DECIMAL) AS norma, AngajatFull.NumeAnterior AS numeant,CAST(AngajatFull.CNPAnterior AS DECIMAL) AS cnpant
FROM     Sal_Luni INNER JOIN
           Sal_Salarii ON Sal_Luni.LunaID = Sal_Salarii.LunaID INNER JOIN
   Angajatori ON Sal_Luni.AngajatorID = Angajatori.AngajatorID INNER JOIN
           AngajatFull ON Sal_Salarii.AngajatID = AngajatFull.AngajatID
WHERE     (Sal_Luni.LunaID = @LunaID) AND (AngajatFull.AngajatorID = @AngajatorID)


RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Muntean Raluca Cristina
--procedura stocata returneaza aproape toate datele pentru a12
--(Declaratie initiala privind evidenta nominala a asiguratilor si a obligatiilor
--de plata catre bugetul asigurarilor sociale de stat)
--datele pe care nu le returneaza: tipd(tip declaratie-initiala sau rectificativa)
-- si nrf(numar file a11)
CREATE PROCEDURE dbo.GetA12
(
		--parametrii
		@LunaID int,
		@AngajatorID int
)
AS
	
--declarare variable
DECLARE @a_jud nvarchar(3) --judet angajator
DECLARE @cnpa int --CNP angajator

--!!!trebuie calculate
DECLARE @casan bigint --CAS angajator
DECLARE @bass bigint
DECLARE @cass145 bigint --CASS conform art.54 din OUG nr 150/2002
DECLARE @casvir bigint --total CAS angajator de virat = casan-cass145-bass(pt 2004)
DECLARE @caambp bigint -- contributie asigurari pentru accidente de munca si boli profesionale(art. 140 Legea 346/2002)

--setare variabile
--081=codul Brasovului
SET @a_jud='081'
SET @cnpa=0


--!!!trebuie calculate
SET @cass145=0
SET @casvir=0
SET @caambp=0;


SELECT     Angajatori.AngajatorID, YEAR(CONVERT(varchar, Sal_Luni.Data, 10)) AS an, MONTH(CONVERT(varchar, Sal_Luni.Data, 10)) AS ln, 
                      Angajatori.ZiLichidareSalar AS dczz, Angajatori.Denumire AS den, MONTH(CONVERT(varchar, Sal_Luni.Data, 104)) AS dcll, YEAR(CONVERT(varchar, 
                      Sal_Luni.Data, 104)) AS dcaa, SUBSTRING(Angajatori.CUI_CNP, 2, 8) AS cf, SUBSTRING(Angajatori.NrInregORC, 1, 3) AS rj, 
                      SUBSTRING(Angajatori.NrInregORC, 5, 3) AS rn, SUBSTRING(Angajatori.NrInregORC, 9, 4) AS ra, CAST(SUM(Sal_Salarii.VenitBrut) AS bigint) AS fs, 
                      CAST(SUM(Sal_Salarii.SumaOreLucrate) AS bigint) AS fsn, CAST(SUM(Sal_Salarii.SumaOreLucrateCondDeoseb) AS bigint) AS fsd, 
                      CAST(SUM(Sal_Salarii.SumaOreLucrateCondSpeciale) AS bigint) AS fss, CAST(SUM(Sal_Salarii.CASAngajat) AS bigint) AS cass, 
                      CAST(SUM(Sal_Salarii.CASAngajator) AS bigint) AS casan, CAST(SUM(Sal_Salarii.SUMAB+Sal_Salarii.SUMAA+Sal_Salarii.SUMAP+
                      Sal_Salarii.SUMAL+Sal_Salarii.SUMAI+Sal_Salarii.SUMAC+Sal_Salarii.SUMAD+Sal_Salarii.SUMAR) AS bigint) AS bass,@cass145 as cass145, @casvir as casvir, @cnpa AS cnpa,@caambp as caambp,
                      Angajatori.Localitate AS a_loca,Angajatori.Strada AS a_str, Angajatori.Numar AS a_nr, Angajatori.Bloc AS a_bl, Angajatori.Scara AS a_sc,
                      Angajatori.Etaj AS a_et, Angajatori.Apartament AS a_ap, SUBSTRING(Angajatori.Telefon,2,10) as telefon, @a_jud AS a_jud, 
                      CASE (Angajatori.Localitate) 
							WHEN 'Bucuresti' THEN CAST(SUBSTRING(Judete.Nume,2,1)as int) 
							ELSE 0
					  END AS a_sect, 
					  Angajatori.Email AS e_mail, SUM(Sal_Salarii.NRCAZB) AS nrcazb, SUM(Sal_Salarii.NRCAZA) AS nrcaza, SUM(Sal_Salarii.NRCAZP) AS nrcazp, SUM(Sal_Salarii.NRCAZL) AS nrcazl, 
					  SUM(Sal_Salarii.NRCAZI) AS nrcazi, SUM(Sal_Salarii.NRCAZC) AS nrcazc, SUM(Sal_Salarii.NRCAZD) AS nrcazd, SUM(Sal_Salarii.NRCAZR) AS nrcazr, SUM(Sal_Salarii.NRPPB) 
                      AS nrppb, SUM(Sal_Salarii.NRPPA) AS nrppa, SUM(Sal_Salarii.NRPPP) AS nrppp, SUM(Sal_Salarii.NRPPL) AS nrppl, SUM(Sal_Salarii.NRPPI) AS nrppi, 
                      SUM(Sal_Salarii.NRPPC) AS nrppc, SUM(Sal_Salarii.NRPPR) AS nrppr, CAST(SUM(Sal_Salarii.SUMAB) AS bigint) AS sumab, 
                      CAST(SUM(Sal_Salarii.SUMAP) AS bigint) AS sumap, CAST(SUM(Sal_Salarii.SUMAA) AS bigint) AS sumaa, CAST(SUM(Sal_Salarii.SUMAL) AS bigint) 
                      AS sumal, CAST(SUM(Sal_Salarii.SUMAI) AS bigint) AS sumai, CAST(SUM(Sal_Salarii.SUMAC) AS bigint) AS sumac, CAST(SUM(Sal_Salarii.SUMAR) 
                      AS bigint) AS sumar, CAST(SUM(Sal_Salarii.SUMAD) AS bigint) AS sumad
FROM         Sal_Luni INNER JOIN
                      Angajatori ON Sal_Luni.AngajatorID = Angajatori.AngajatorID INNER JOIN
                      Sal_Salarii ON Sal_Luni.LunaID = Sal_Salarii.LunaID INNER JOIN
                      AngajatFull ON Angajatori.AngajatorID = AngajatFull.AngajatorID AND Sal_Salarii.AngajatID = AngajatFull.AngajatID AND 
                      Angajatori.AngajatorID = AngajatFull.AngajatorID INNER JOIN
                      Judete ON Angajatori.JudetSectorID = Judete.JudetID
WHERE     (Sal_Salarii.LunaID = @LunaID) AND (Angajatori.AngajatorID = @AngajatorID)
GROUP BY Angajatori.AngajatorID, Sal_Luni.Data, Angajatori.Denumire, Angajatori.CUI_CNP, Angajatori.NrInregORC, Angajatori.ZiLichidareSalar, 
         Angajatori.Localitate, Angajatori.Strada, Angajatori.Numar, Angajatori.Bloc, Angajatori.Scara, Angajatori.Etaj, Angajatori.Apartament, Angajatori.Telefon, 
         Angajatori.Email,Judete.Nume

RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Muntean Raluca Cristina
--procedura returneaza nrm=numar mediu de angajati pentru a12(=declaratia
--initiala privind evienta nominala a asiguratilor si a pbligatiilor de plata 
--catre bugetul asigurarilor sociale anexa 1.2)
CREATE PROCEDURE dbo.GetA12_NRM
(
	--parametrii
	@LunaID int,
	@AngajatorID int
)
AS
--suma=Norma*NrZileLucrate=
--    =Sal_Salarii.ProgramLucru * Sal_Salarii.NrOreLucrate/Sal_Salarii.ProgramLucru=
--    =Sal_Salarii.NrOreLucrate
--Sum(Norma*NrZileLucrate)=NrAsigurati*Norma*NrZileLucrate
SELECT     COUNT(Sal_Salarii.AngajatID) AS NrAngajati, Sal_Salarii.NrOreLucrate / Sal_Salarii.ProgramLucru AS ZileLucrate, Sal_Salarii.ProgramLucru, 
           SUM(Sal_Salarii.NrOreLucrate) AS suma,Sal_Salarii.NrZileLuna
FROM         Sal_Salarii INNER JOIN
                      AngajatFull ON Sal_Salarii.AngajatID = AngajatFull.AngajatID
WHERE     (Sal_Salarii.LunaID = @LunaID) AND (AngajatFull.AngajatorID = @AngajatorID) 
GROUP BY  Sal_Salarii.ProgramLucru, Sal_Salarii.NrOreLucrate / Sal_Salarii.ProgramLucru, Sal_Salarii.NrZileLuna
	

RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


--Autor: Dovlecel Vlad
--Descriere: returneaza toti angajatii

CREATE PROCEDURE dbo.GetAllAngajati
(
	@CategorieID int
)
AS

/*if( @CategorieID > 0 )
begin
	select *

	from Angajati

	where CategorieID = @CategorieID

	order by NumeIntreg
end
else begin
	select *

	from Angajati

	order by NumeIntreg
end*/
if( @CategorieID > 0 )
begin
	select *

	from AngajatFull

	where CategorieID = @CategorieID

	order by NumeIntreg
end
else begin
	select *

	from AngajatFull

	order by NumeIntreg
end

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		Mircea Albutiu, PSE RO BS TH
* Nume:			GetAngajatInfo
* Descriere:	Intoarce toate datele unui angajat
* Modificat:	Alexandru Mihai, adaugat NumeAngajator :)
  Modificat:    Cristina Raluca Muntean, adaugat Sporuri, AlteAdaosuri, NrZileCOSupl, EchIndProtectie, EchIndLucru,
                MatIgiSan, AlimProtectie, AlteDrSiObl, AlteClauzeCIM, PerProba
*/
CREATE PROCEDURE GetAngajatInfo 
(
	@AngajatID int
)
as 

SELECT     AngajatFull.AngajatID, AngajatorID, Marca, NumeIntreg, Nume, Prenume, NumeAnterior,TitluID, Poza, PrenumeMama, PrenumeTata, 
                      StudiuID, AnAbsolvire, NrDiploma, Descriere, ModIncadrare, ProgramLucru, Telefon, DataNasterii, TaraNastereID, JudetNastereID, LocalitateNastere, 
                      StareCivila, NrCopii, Sex, Nationalitate, CNP, CNPAnterior, TipFisaFiscala, AniVechimeMunca, LuniVechimeMunca, ZileVechimeMunca, 
                      AreCardBancar, PerioadaDeterminata, DataPanaLa, DataDeLa, SefID, NrContractMunca, DataInregContractMunca, DTaraID, DLocalitate, DJudetSectorID, DStrada, 
                      DNumar, DCodPostal, DBloc, DScara, DEtaj, DApartament, RTaraID, RLocalitate, RJudetSectorID, RStrada, RNumar, RCodPostal, RBloc, RScara, REtaj, 
                      RApartament, CNP, CNPAnterior, CISerie, CINumar, CIEliberatDe, CIDataEliberarii, CIValabilPanaLa, PASSerie, PASNumar, PASEliberatDe, PASDataEliberarii, 
                      PASValabilPanaLa, CMSerie, CMNumar, CMEmitent, CMDataEmiterii, CMNrInregITM, TitluDenumire, TitluSimbol, DepartamentID, DepartamentCod, 
                      DepartamentDenumire, FunctieID, FunctieCod, FunctieNume, CentruCostID, CentruCostCod, CentruCostNume, NumeAngajator, 
                      SituatieMilitara.EvidentaCMJ, SituatieMilitara.DataIntrareEvidenta, SituatieMilitara.SerieLivret, SituatieMilitara.NumarLivret, SituatieMilitara.Gradul, 
                      SituatieMilitara.SpecialitatiMilitare, Invaliditate, SalariuBazaActual, IndemnizatieConducereActual, CategorieID, Email, TelMunca,
	         NrZileCOAn, SumaMajorare, DataMajorare, EchIndProtectie, EchIndLucru, MatIgiSan, AlimProtectie, AlteDrSiObl, AlteClauzeCIM,PerProba, Sporuri, AlteAdaosuri,NrZileCOSupl,
		--vlad: PermiseMunca
		PermisMuncaID, NrPermisMunca, SeriePermisMunca, PermMuncaDataEliberare, PermMuncaDataExpirare, 
                      LegitimatieSedereID, NrLegitimatieSedere, SerieLegitimatieSedere, LegitimatieSedereDataEliberare, LegitimatieSedereDataExpirare, NIFID, NIF
FROM         AngajatFull LEFT JOIN
                      SituatieMilitara ON SituatieMilitara.AngajatID = AngajatFull.AngajatID
WHERE     AngajatFull.AngajatID = @AngajatID

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Muntean Raluca Cristina
--returneaza datele necesare completarii declaratiei privind evidenta
--nominala a asiguratilor si a obligatiilor de plata la bugetul asigurarilor
--pentru somaj - Capitolul 1
CREATE PROCEDURE dbo.GetCap1
(
	--parametrii
	@LunaID int,
	@AngajatorID int
)

AS
--declarare variabile
DECLARE @cnpa int --cnp angajator(implicit 0)

--setare variabile
SET @cnpa=0

SELECT     MONTH(CONVERT(varchar, Sal_Luni.Data, 10)) AS ld, YEAR(CONVERT(varchar, Sal_Luni.Data, 10)) AS ad, SUBSTRING(Angajatori.CUI_CNP, 2, 8) 
           AS cf, @cnpa as cnpa,AngajatFull.NumeIntreg AS nume, AngajatFull.CNP AS cnp,
           CASE(AngajatFull.ProgramLucru)
				WHEN 8 THEN 'Tn'
				ELSE 'Tp'
		   END as tc,		 
		   AngajatFull.ProgramLucru AS non, 
           CAST(Sal_Salarii.NrOreLucrate / AngajatFull.ProgramLucru as int)AS nzn, CAST(Sal_Salarii.VenitBrut as bigint) AS bc, CAST(Sal_Salarii.AjutorSomaj as bigint) AS cid, 
           CAST(Sal_Salarii.AjutorSomaj as bigint)AS civ
FROM       Angajatori INNER JOIN
           AngajatFull ON Angajatori.AngajatorID = AngajatFull.AngajatorID INNER JOIN
           Sal_Salarii ON AngajatFull.AngajatID = Sal_Salarii.AngajatID INNER JOIN
           Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID AND Sal_Salarii.LunaID = Sal_Luni.LunaID
WHERE     (Angajatori.AngajatorID = @AngajatorID) AND (Sal_Salarii.LunaID = @LunaID)	
RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Muntean Raluca Cristina
--procedura stocata returneaza toate datele necesare completarii declaratiei
--privind evidenta nominala a asiguratilor si a obligatiilor de plata la bugetul 
--asigurarilor pentru somaj- Capitolul 2:DATE DESPRE ANGAJATOR;DEDUCERI SI REDUCERI
CREATE PROCEDURE dbo.GetCap2
(
	@LunaID int,
	@AngajatorID int
)
AS

SELECT     MONTH(CONVERT(varchar, Sal_Luni.Data, 104)) AS ld, YEAR(CONVERT(varchar, Sal_Luni.Data, 104)) AS ad, Angajatori.Denumire AS den, 
           SUBSTRING(Angajatori.CUI_CNP, 2, 8) AS cf, 0 as cnpa,Angajatori.Localitate AS loc, Angajatori.Strada AS str, Angajatori.Numar AS nra, Angajatori.Bloc AS bl, 
           Angajatori.Scara AS sc, Angajatori.Etaj AS et, Angajatori.Apartament AS ap, 
           CASE (Angajatori.Localitate) 
				WHEN 'Bucuresti' THEN CAST(SUBSTRING(Judete.Nume,2,1)as int) 
				ELSE 0 
		   END AS sect,
		   Judete.Nume as jud, SUBSTRING(Angajatori.Telefon,3,9) AS tel, SUBSTRING(Angajatori.Fax,3,9) AS fax, Angajatori.Email AS mail, 
           CAST(SUM(Sal_Salarii.VenitBrut) AS bigint) AS fs,0 as ded80rec, 0 as ded80res,0 as ded85rec, 0 as ded85res, 0 as ded116rec,
           0 as ded116res, 0 as red9394rec, 0 as red9394res, 
           (SELECT     Nume
           FROM          AngajatFull
           WHERE      FunctieID = 4) AS numea,
           (SELECT     Prenume
           FROM          AngajatFull
           WHERE      FunctieID = 4) AS prea,
           (SELECT     FunctieNume
           FROM          AngajatFull
           WHERE      FunctieID = 4) AS funct
FROM       AngajatFull INNER JOIN
           Angajatori ON AngajatFull.AngajatorID = Angajatori.AngajatorID INNER JOIN
           Sal_Luni INNER JOIN
           Sal_Salarii ON Sal_Luni.LunaID = Sal_Salarii.LunaID ON AngajatFull.AngajatID = Sal_Salarii.AngajatID INNER JOIN
           Judete ON Angajatori.JudetSectorID = Judete.JudetID
WHERE     (Angajatori.AngajatorID = @AngajatorID) AND (Sal_Salarii.LunaID = @LunaID)
GROUP BY Sal_Luni.Data, Angajatori.Denumire, Angajatori.CUI_CNP, Angajatori.Localitate, Angajatori.Strada, Angajatori.Numar, Angajatori.Bloc, Angajatori.Scara,
         Angajatori.Etaj, Angajatori.Apartament, Judete.Nume, Angajatori.Telefon, Angajatori.Fax, Angajatori.Email

RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE dbo.GetConducere

	(
		@Functie int 
	)

AS
SELECT    TOP 1 TitluSimbol, NumeIntreg, FunctieNume, AngajatID
FROM         AngajatFull
WHERE     (FunctieCod = @Functie)
	


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Muntean Raluca Cristina
--returneaza datele necesare completarii unei parti din fisa fiscala 1: date referitoare
--la persoanele aflate in intretinere pentru care se solicita deducerea
CREATE PROCEDURE dbo.GetDED_aaaa
(
	@AngajatID int
)
AS
--declarare variabile
DECLARE @Coef_01 int,@Coef_02 int,@Coef_03 int,@Coef_04 int,@Coef_05 int,@Coef_06 int
DECLARE @Coef_07 int,@Coef_08 int,@Coef_09 int,@Coef_10 int,@Coef_11 int,@Coef_12 int

--setare variabile
SET @Coef_01=1.0 SET @Coef_02=1.0 SET @Coef_03=1.0 SET @Coef_04=1.0 SET @Coef_05=1.0 SET @Coef_06=1.0
SET @Coef_07=1.0 SET @Coef_08=1.0 SET @Coef_09=1.0 SET @Coef_10=1.0 SET @Coef_11=1.0 SET @Coef_12=1.0

--coeficientii trebie calculati din baza de date
SELECT     AngajatFull.CNP AS cnp_ang, AngajatPersoaneInIntretinere.CNP AS Cnp_pers, AngajatFull.Nume, AngajatFull.Prenume, 
	       CASE(AngajatPersoaneInIntretinere.Calitate)
				WHEN 3 THEN 'X'
				ELSE ''
		   END as Sot,
		   CASE(AngajatPersoaneInIntretinere.Calitate)
				WHEN 4 THEN 'X' 
				WHEN 5 THEN 'X' 
				WHEN 6 THEN 'X' 
				ELSE ''
		   END as Copil,
		   CASE(AngajatPersoaneInIntretinere.Calitate)
				WHEN 3 THEN ''
				WHEN 4 THEN ''
				WHEN 5 THEN ''
				WHEN 6 THEN ''
				ELSE 'X'
		   END as Alta,
           CASE(AngajatPersoaneInIntretinere.Invaliditate)
				WHEN 1 THEN 'X'
				ELSE ''		
		   END as Invalid_I,
		   CASE(AngajatPersoaneInIntretinere.Invaliditate)
				WHEN 2 THEN 'X'
				ELSE ''
		   END as Invalid_II,@Coef_01 as Coef_01,@Coef_02 as Coef_02,@Coef_03 as Coef_03, @Coef_04 as Coef_04,
		   @Coef_05 as Coef_05,@Coef_06 as Coef_06,@Coef_07 as Coef_07,@Coef_08 as Coef_08,@Coef_09 as Coef_09,
		   @Coef_10 as Coef_10,@Coef_11 as Coef_11,@Coef_12 as Coef_12
FROM       AngajatFull INNER JOIN
           AngajatPersoaneInIntretinere ON AngajatFull.AngajatID = AngajatPersoaneInIntretinere.AngajatID
WHERE     (AngajatFull.AngajatID = @AngajatID)	
RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Muntean Raluca Cristina
--procedura returneaza toate datele necesare completarii fisei fiscale 1
CREATE PROCEDURE dbo.GetFF1_aaaa
(
	--parametrii
	@AngajatID int,
	@An int,
	@LunaStart int,
	@LunaStop int
)
AS

--declarare variabile
DECLARE @Impozit_01 bigint, @Impozit_02 bigint, @Impozit_03 bigint, @Impozit_04 bigint, @Impozit_05 bigint
DECLARE @Impozit_06 bigint, @Impozit_07 bigint, @Impozit_08 bigint, @Impozit_09 bigint, @Impozit_10 bigint
DECLARE @Impozit_11 bigint, @Impozit_12 bigint, @Impozit_13 bigint
DECLARE @Venit_01 bigint, @Venit_02 bigint, @Venit_03 bigint, @Venit_04 bigint, @Venit_05 bigint
DECLARE @Venit_06 bigint, @Venit_07 bigint, @Venit_08 bigint, @Venit_09 bigint, @Venit_10 bigint
DECLARE @Venit_11 bigint, @Venit_12 bigint,@Venit_13 bigint
--nu poate fi efectuata plata/restituirea catre
DECLARE @Nu_plata nvarchar(1)
--persoana trimisa in misiune permanenta
DECLARE @Pers_mis nvarchar(1)
--persoana decedata
DECLARE @Pers_deced nvarchar(1)

--setare variabile

--campurile de mai jos(urm 3) trebuie introduse si ulterior completate din baza de date
--se compl cu X daca persoana este decedata
SET @Pers_deced=''

--se completeaza cu X , daca nu poate fi efectuata plata/restituirea de catre angajator
--a diferentelor de impozit, inscris la rd. 10 si 11 Cap IV, catre angajat
SET @Nu_plata=''
--se completeaza cu 'X' pentru personalul trimis in misiune permanenta in strainatate 
SET @Pers_mis=''


SET @Impozit_01=CASE 
					WHEN(1 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '01')AND (Angajati.ModIncadrare=0))
					ELSE 0
				END
SET @Impozit_02=CASE 
					WHEN(2 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '02')AND (Angajati.ModIncadrare=0))
					ELSE 0
				END
SET @Impozit_03=CASE 
					WHEN(3 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '03')AND (Angajati.ModIncadrare=0))
					ELSE 0
				END
SET @Impozit_04=CASE 
					WHEN(4 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '04')AND (Angajati.ModIncadrare=0))
					ELSE 0
				END
SET @Impozit_05=CASE 
					WHEN(5 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '05')AND (Angajati.ModIncadrare=0))
					ELSE 0
				END
SET @Impozit_06=CASE 
					WHEN(6 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '06')AND (Angajati.ModIncadrare=0))
					ELSE 0
				END
SET @Impozit_07=CASE 
					WHEN(7 BETWEEN @LunaStart and @LunaStop) THEN (SELECT CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '07')AND (Angajati.ModIncadrare=0))
					ELSE 0
				END
SET @Impozit_08=CASE 
					WHEN(8 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '08')AND (Angajati.ModIncadrare=0))
					ELSE 0
				END
SET @Impozit_09=CASE 
					WHEN(9 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '09')AND (Angajati.ModIncadrare=0))
					ELSE 0
				END
SET @Impozit_10=CASE 
					WHEN(10 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '10')AND (Angajati.ModIncadrare=0))
					ELSE 0
				END
SET @Impozit_11=CASE 
					WHEN(11 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '11')AND (Angajati.ModIncadrare=0))
					ELSE 0
				END												
SET @Impozit_12=CASE 
					WHEN(12 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '12')AND (Angajati.ModIncadrare=0))
					ELSE 0
			  END
SET @Venit_01=CASE 
				WHEN(1 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.VenitNet as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '1')AND (Angajati.ModIncadrare=0))
				ELSE 0
			  END
SET @Venit_02=CASE 
				WHEN(2 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.VenitNet as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '2')AND (Angajati.ModIncadrare=0))
				ELSE 0
			  END
SET @Venit_03=CASE 
				WHEN(3 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.VenitNet as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '3')AND (Angajati.ModIncadrare=0))
				ELSE 0
			  END
SET @Venit_04=CASE 
				WHEN(4 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.VenitNet as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '4')AND (Angajati.ModIncadrare=0))
				ELSE 0
			  END
SET @Venit_05=CASE 
				WHEN(5 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.VenitNet as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '5')AND (Angajati.ModIncadrare=0))
				ELSE 0
			  END
SET @Venit_06=CASE 
				WHEN(6 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.VenitNet as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '6')AND (Angajati.ModIncadrare=0))
				ELSE 0
			  END
SET @Venit_07=CASE 
				WHEN(7 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.VenitNet as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '7')AND (Angajati.ModIncadrare=0))
				ELSE 0
			  END
SET @Venit_08=CASE 
				WHEN(8 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.VenitNet as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '8')AND (Angajati.ModIncadrare=0))
				ELSE 0
			  END
SET @Venit_09=CASE 
				WHEN(9 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.VenitNet as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															 WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '9')AND (Angajati.ModIncadrare=0))
				ELSE 0
			  END
SET @Venit_10=CASE 
				WHEN(10 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.VenitNet as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '10')AND (Angajati.ModIncadrare=0))
				ELSE 0
			  END
SET @Venit_11=CASE 
				WHEN(11 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.VenitNet as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '11')AND (Angajati.ModIncadrare=0))
				ELSE 0
			  END
SET @Venit_12=CASE 
				WHEN(12 BETWEEN @LunaStart and @LunaStop) THEN (SELECT CAST(Sal_Salarii.VenitNet as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '12')AND (Angajati.ModIncadrare=0) )
				ELSE 0
			  END
				
				

--total impozit retinut
SET @Impozit_13=@Impozit_01+@Impozit_02+@Impozit_03+@Impozit_04+@Impozit_05+@Impozit_06+@Impozit_07+@Impozit_08+@Impozit_09+@Impozit_10+@Impozit_11+@Impozit_12

--total venit net
SET @Venit_13=@Venit_01+@Venit_02+@Venit_03+@Venit_04+@Venit_05+@Venit_06+@Venit_07+@Venit_08+@Venit_09+@Venit_10+@Venit_11+@Venit_12

SELECT     AngajatFull.CNP AS Cnp_ang, AngajatFull.Nume, AngajatFull.Prenume, Judete.Nume AS Judet, AngajatFull.DLocalitate AS Localitate, 
           AngajatFull.DStrada AS Strada, AngajatFull.DNumar AS Nr, AngajatFull.DBloc AS Bloc, AngajatFull.DScara AS Scara, AngajatFull.DApartament AS Ap, 
		   AngajatFull.DCodPostal AS Cod_postal,@Nu_plata as Nu_plata,@Pers_mis as Pers_mis,@Pers_deced as Pers_deced,@Impozit_01 as Impozit_01, @Impozit_02 as Impozit_02,
		   @Impozit_03 as Impozit_03,@Impozit_04 as Impozit_04, @Impozit_05 as Impozit_05, @Impozit_06 as Impozit_06, @Impozit_07 as Impozit_07,@Impozit_08 as Impozit_08,
		   @Impozit_09 as Impozit_09,@Impozit_10 as Impozit_10,@Impozit_11 as Impozit_11,@Impozit_12 as Impozit_12,@Impozit_13 as Impozit_13,@Venit_01 as Venit_01,
		   @Venit_02 as Venit_02,@Venit_03 as Venit_03,@Venit_04 as Venit_04,@Venit_05 as Venit_05,@Venit_06 as Venit_06,@Venit_07 as Venit_07,@Venit_08 as Venit_08,
		   @Venit_09 as Venit_09,@Venit_10 as Venit_10,@Venit_11 as Venit_11, @Venit_12 as Venit_12,@Venit_13 as Venit_13,(@LunaStop-@LunaStart+1) as Nr_luni
FROM      AngajatFull INNER JOIN
          Judete ON AngajatFull.DJudetSectorID = Judete.JudetID

WHERE     (AngajatFull.AngajatID = @AngajatID)and (AngajatFull.ModIncadrare=0) 
RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


--Muntean Raluca Cristina
--procedura returneaza toate datele necesare completarii fisei fiscale 2
CREATE PROCEDURE dbo.GetFF2_aaaa
(
	--parametrii
	@AngajatID int,
	@An int,
	@LunaStart int,
	@LunaStop int
)
AS

--declarare variabile
DECLARE @Rectific nvarchar(1)
DECLARE @Impozit_01 bigint, @Impozit_02 bigint, @Impozit_03 bigint, @Impozit_04 bigint, @Impozit_05 bigint
DECLARE @Impozit_06 bigint, @Impozit_07 bigint, @Impozit_08 bigint, @Impozit_09 bigint, @Impozit_10 bigint
DECLARE @Impozit_11 bigint, @Impozit_12 bigint, @Impozit_13 bigint
DECLARE @Venit_01 bigint, @Venit_02 bigint, @Venit_03 bigint, @Venit_04 bigint, @Venit_05 bigint
DECLARE @Venit_06 bigint, @Venit_07 bigint, @Venit_08 bigint, @Venit_09 bigint, @Venit_10 bigint
DECLARE @Venit_11 bigint, @Venit_12 bigint,@Venit_13 bigint
DECLARE @AS1 nvarchar(1),@AS2 nvarchar(1),@AS3 nvarchar(1),@AS4 nvarchar(1),@AS5 nvarchar(1),@AS6 nvarchar(1),@AS7 nvarchar(1)
DECLARE @Venit_fin bigint,@Impozit_fin bigint

--setare variabile
SET @Rectific=''

SET @Impozit_01=CASE 
					WHEN(1 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '1')AND (Angajati.ModIncadrare=1))
					ELSE 0
				END
SET @Impozit_02=CASE 
					WHEN(2 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '2')AND (Angajati.ModIncadrare=1))
					ELSE 0
				END
SET @Impozit_03=CASE 
					WHEN(3 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '3')AND (Angajati.ModIncadrare=1))
					ELSE 01
				END
SET @Impozit_04=CASE 
					WHEN(4 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '4')AND (Angajati.ModIncadrare=1))
					ELSE 0
				END
SET @Impozit_05=CASE 
					WHEN(5 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '5')AND (Angajati.ModIncadrare=1))
					ELSE 0
				END
SET @Impozit_06=CASE 
					WHEN(6 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '6')AND (Angajati.ModIncadrare=1))
					ELSE 0
				END
SET @Impozit_07=CASE 
					WHEN(7 BETWEEN @LunaStart and @LunaStop) THEN (SELECT CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '7')AND (Angajati.ModIncadrare=1))
					ELSE 0
				END
SET @Impozit_08=CASE 
					WHEN(8 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '8')AND (Angajati.ModIncadrare=1))
					ELSE 0
				END
SET @Impozit_09=CASE 
					WHEN(9 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '9')AND (Angajati.ModIncadrare=1))
					ELSE 0
				END
SET @Impozit_10=CASE 
					WHEN(10 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '10')AND (Angajati.ModIncadrare=1))
					ELSE 0
				END
SET @Impozit_11=CASE 
					WHEN(11 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '11')AND (Angajati.ModIncadrare=1))
					ELSE 0
				END												
SET @Impozit_12=CASE 
					WHEN(12 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.Impozit as bigint) 
																	FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
																	WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '12')AND (Angajati.ModIncadrare=1))
					ELSE 0
			  END
SET @Venit_01=CASE 
				WHEN(1 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.BCImpozit as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '01')AND (Angajati.ModIncadrare=1))
				ELSE 0
			  END
SET @Venit_02=CASE 
				WHEN(2 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.BCImpozit as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '02')AND (Angajati.ModIncadrare=1))
				ELSE 0
			  END
SET @Venit_03=CASE 
				WHEN(3 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.BCImpozit as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '03')AND (Angajati.ModIncadrare=1))
				ELSE 0
			  END
SET @Venit_04=CASE 
				WHEN(4 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.BCImpozit as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '4')AND (Angajati.ModIncadrare=1))
				ELSE 0
			  END
SET @Venit_05=CASE 
				WHEN(5 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.BCImpozit as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '05')AND (Angajati.ModIncadrare=1))
				ELSE 0
			  END
SET @Venit_06=CASE 
				WHEN(6 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.BCImpozit as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '06')AND (Angajati.ModIncadrare=1))
				ELSE 0
			  END
SET @Venit_07=CASE 
				WHEN(7 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.BCImpozit as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '07')AND (Angajati.ModIncadrare=1))
				ELSE 0
			  END
SET @Venit_08=CASE 
				WHEN(8 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.BCImpozit as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '08')AND (Angajati.ModIncadrare=1))
				ELSE 0
			  END
SET @Venit_09=CASE 
				WHEN(9 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.BCImpozit as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '09')AND (Angajati.ModIncadrare=1))
				ELSE 0
			  END
SET @Venit_10=CASE 
				WHEN(10 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.BCImpozit as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '10')AND (Angajati.ModIncadrare=1))
				ELSE 0
			  END
SET @Venit_11=CASE 
				WHEN(11 BETWEEN @LunaStart and @LunaStop) THEN (SELECT   CAST(Sal_Salarii.BCImpozit as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '11')AND (Angajati.ModIncadrare=1))
				ELSE 0
			  END
SET @Venit_12=CASE 
				WHEN(12 BETWEEN @LunaStart and @LunaStop) THEN (SELECT CAST(Sal_Salarii.BCImpozit as bigint) 
															   FROM    Sal_Salarii INNER JOIN
																	   Sal_Luni ON Sal_Salarii.LunaID = Sal_Luni.LunaID INNER JOIN
																	   Angajati ON Sal_Salarii.AngajatID = Angajati.AngajatID
															   WHERE   (YEAR(Sal_Luni.Data) = @An) AND (Sal_Salarii.AngajatID = @AngajatID) AND (MONTH(Sal_Luni.Data) = '12')AND (Angajati.ModIncadrare=1) )
				ELSE 0
			  END
				
				

--total impozit retinut
SET @Impozit_13=@Impozit_01+@Impozit_02+@Impozit_03+@Impozit_04+@Impozit_05+@Impozit_06+@Impozit_07+@Impozit_08+@Impozit_09+@Impozit_10+@Impozit_11+@Impozit_12

--total venit net
SET @Venit_13=@Venit_01+@Venit_02+@Venit_03+@Venit_04+@Venit_05+@Venit_06+@Venit_07+@Venit_08+@Venit_09+@Venit_10+@Venit_11+@Venit_12

--trebuie luate din baza de date
SET @AS1='X' 
SET @AS2=''
SET @AS3=''
SET @AS4=''
SET @AS5=''
SET @AS6=''
SET @AS7=''

--Venit din salarii cu impunere finala,Impozit din salarii cu impunere finala
--Venituri salariale stabilite prin decizii judecatoresti
SET @Venit_fin=0
SET @Impozit_fin=0

SELECT     AngajatFull.CNP AS Cnp_ang, AngajatFull.Nume, AngajatFull.Prenume, Judete.Nume AS Judet, AngajatFull.DLocalitate AS Localitate, 
           AngajatFull.DStrada AS Strada, AngajatFull.DNumar AS Nr, AngajatFull.DBloc AS Bloc, AngajatFull.DScara AS Scara,AngajatFull.DApartament AS Ap, 
		   AngajatFull.DCodPostal AS Cod_postal,@Rectific as Rectific,@AS1 as AS1,@AS2 as AS2,@AS3 as AS3,@AS4 as AS4,@AS5 as AS5,@AS6 as AS6,@AS7 as AS7,
		   @Impozit_01 as Impozit_01, @Impozit_02 as Impozit_02,@Impozit_03 as Impozit_03,@Impozit_04 as Impozit_04, @Impozit_05 as Impozit_05, 
		   @Impozit_06 as Impozit_06, @Impozit_07 as Impozit_07,@Impozit_08 as Impozit_08, @Impozit_09 as Impozit_09,@Impozit_10 as Impozit_10,
		   @Impozit_11 as Impozit_11,@Impozit_12 as Impozit_12,@Impozit_13 as Impozit_13,@Venit_01 as Venit_01,@Venit_02 as Venit_02,@Venit_03 as Venit_03,
		   @Venit_04 as Venit_04,@Venit_05 as Venit_05,@Venit_06 as Venit_06,@Venit_07 as Venit_07,@Venit_08 as Venit_08,@Venit_09 as Venit_09,
		   @Venit_10 as Venit_10,@Venit_11 as Venit_11,@Venit_12 as Venit_12,@Venit_13 as Venit_13,(@LunaStop-@LunaStart+1) as Nr_luni,@Venit_fin as Venit_fin,
		   @Impozit_fin as Imp_fin
FROM      AngajatFull INNER JOIN
          Judete ON AngajatFull.DJudetSectorID = Judete.JudetID

WHERE     (AngajatFull.AngajatID = @AngajatID)and (AngajatFull.ModIncadrare=1) 
RETURN 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE sal_GetAllAngForSal
(
	@AngajatorID int
)

AS

/*	SELECT     AngajatID, Marca, AngajatorID, NumeIntreg, Marca, SalariuBazaActual, IndemnizatieConducereActual, TitluDenumire, FunctieNume, CentruCostNume, 
	                      NumeAngajator, CategorieID, ProgramLucru, AreVenituri, AreDeduceri
	FROM         AngajatFull
	WHERE     (AngajatorID = @AngajatorID)
	order by NumeIntreg
*/


	SELECT     AngajatID, Marca, AngajatorID, NumeIntreg, Marca, SalariuBazaActual, IndemnizatieConducereActual, TitluDenumire, FunctieNume, CentruCostNume, 
	                      NumeAngajator, CategorieID, ProgramLucru, AreVenituri, AreDeduceri, Sporuri, AlteAdaosuri
	FROM         AngajatFull
	WHERE     (AngajatorID = @AngajatorID)
	order by NumeIntreg
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE sal_GetAllAngForVeniturDeduceri
(
	@AngajatorID int
)

AS
	SELECT     AngajatID, Marca,  NumeIntreg,  AreVenituri,  AreDeduceri
	FROM         AngajatFull
	WHERE     (AngajatorID = @AngajatorID)
	order by NumeIntreg

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO





/*
*Author: Ionel Popa
*Description: Calculeaza impozitul anual, suma recuperata si suma de restituit pt fiecare angajat roman
*				 care a muncit ultimele 12 luni in cadrul firmei, nu are alte venituri si nu solicita deduceri
*Params: id-ul angajatorului
*/
CREATE     PROCEDURE dbo.sal_GetAllAngImpozitAnual
	(
		@AngajatorID int,
		@Year numeric
	)

AS
	declare @angajatID int
	declare @impozit_total money
	declare @VenitBrutAnualCumulat money
	declare @CASAnualCumulat money
	declare @CASSAnualCumulat money
	declare @SomajAnualCumulat money
	declare @ImpozitLunarCumulat money
	declare @ImpozitAnualRaportat money
	declare @RoundedImpozitAnualRaportat bigint
	declare @SumaDeImpozitat money
	declare @SumaDeRecuperat money
	declare @RoundedSumaDeRecuperat bigint
	declare @SumaDeRestituit money
	declare @RoundedSumaDeRestituit bigint
	declare @CheltuieliProfesionale float
	declare @DeduceriPersonale int
	declare @LunaCurenta int

	-- se calculeaza sumele necesare pt calculul impozitului anual
	declare impozit_anual_cursor scroll cursor for
	SELECT	AngajatID, 
		SUM(VenitBrut) AS VenitBrutAnualCumulat, 
		SUM(CASAngajat) AS CASAnualCumulat, 
		SUM(ContribSanPers) AS CASSAnualCumulat, 
		SUM(AjutorSomaj) AS SomajAnualCumulat, 
		SUM(impozit) as ImpozitLunarCumulat
	FROM         Sal_Salarii s1
	WHERE     (
			LunaID IN
			(
				select distinct lunaid
				from sal_luni
				where year(data) = @Year
			)
		) 
	AND 
	
		(
			(select dbo.doesTheEmployeWorkInLastMonths( s1.AngajatID, @year)) = 1
		)
	GROUP BY s1.AngajatID

	-- extragem cheltuielile personale si deducerile diin ParametriImpozitAnul
	set @CheltuieliProfesionale = (select cheltuieliprofesionale from parametriimpozitanual where year(getdate()) = an)
	set @DeduceriPersonale =  (select deduceri from parametriimpozitanual where year(getdate()) = an)

	-- stergem vechile valori din tabelul ImpozitAnual pt anul curent
	delete from ImpozitAnual where An= year(getdate())

	-- aflam lunaID pentru luna curenta
	select @LunaCurenta = LunaID 
	from sal_luni
	where month( data) = month(getdate()) and year(data) = year(getdate())

	open impozit_anual_cursor

	fetch next from impozit_anual_cursor
	into @angajatID, @VenitBrutAnualCumulat, @CASAnualCumulat, @CASSAnualCumulat, @SomajAnualCumulat, @ImpozitLunarCumulat
	while @@fetch_status = 0
	begin
		set @SumaDeImpozitat = @VenitBrutAnualCumulat - @CASAnualCumulat - @CASSAnualCumulat - @SomajAnualCumulat - @DeduceriPersonale - (( @CheltuieliProfesionale * 0.01) * @DeduceriPersonale)
		-- prima valoare IA
		set @ImpozitAnualRaportat = (select dbo.calculateAnualImpozit( @angajatID, @SumaDeImpozitat) as ImpozitAnualRaportat)
		-- a doua valoare IL = @ImpozitLunarCumulat
		set @SumaDeRecuperat = 0
		set @SumaDeRestituit = 0
		if ( @ImpozitAnualRaportat > @ImpozitLunarCumulat)
			set @SumaDeRecuperat = @ImpozitAnualRaportat - @ImpozitLunarCumulat
		else
			set @SumaDeRestituit = @ImpozitLunarCumulat - @ImpozitAnualRaportat

		set @RoundedImpozitAnualRaportat = (select dbo.RoundSum(@ImpozitAnualRaportat))
		set @RoundedSumaDeRecuperat = (select dbo.RoundSum(@SumaDeRecuperat))
		set @RoundedSumaDeRestituit = (select dbo.RoundSum(@SumaDeRestituit))

		-- actualizam in tabela sal_SituatieLunaraAngajati in campul AlteDrepturi, valoarea din SumaDeRecuperat
		update sal_situatielunaraangajati
		set altedrepturi = @RoundedSumaDeRecuperat
		where angajatid = @angajatid and lunaid = @LunaCurenta

		-- inseram in ImpozitAnual o linie cu informatii despre Impozitul Anual pentru angajatul respectiv
		insert into ImpozitAnual ( AngajatID, ImpozitAnual, SumaRecuperat, SumaRestituit, ImpozitLunarCumulat, An)
		values (@angajatID, @RoundedImpozitAnualRaportat, @RoundedSumaDeRecuperat, @RoundedSumaDeRestituit, @ImpozitLunarCumulat,  year(getdate()))
		fetch next from impozit_anual_cursor
		into @angajatID, @VenitBrutAnualCumulat, @CASAnualCumulat, @CASSAnualCumulat, @SomajAnualCumulat, @ImpozitLunarCumulat
	end

	close impozit_anual_cursor
	DEALLOCATE impozit_anual_cursor

	select af.AngajatID, af.NumeIntreg, af.Marca,cast( ia.ImpozitAnual as bigint) as ImpozitAnual, cast( ia.SumaRecuperat as bigint) as SumaRecuperat, cast( ia.SumaRestituit as bigint) as SumaRestituit
	from ImpozitAnual as ia, angajatFull as af
	where ia.AngajatID = af.AngajatID
	order by af.NumeIntreg

	RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


CREATE PROCEDURE tmp_1111 
(
	@AngajatID int,
	@DataStart datetime,
	@DataEnd datetime,
	@TipIntervalID int
)
AS

--Select AngajatID, Nume, Prenume from AngajatFull where AngajatID not in (select AngajatID from ConturiAngajati Group By AngajatID)
--select  AngajatID, Nume, Prenume from AngajatFull where AngajatID in (select AngajatID from ConturiAngajati where BancaID <> @in_BancaID Group By AngajatID)
--select AngajatID from ConturiAngajati where BancaID <> @in_BancaID Group By AngajatID
--Select AngajatID, Nume, Prenume, CategorieID from AngajatFull where CategorieID in (Select CategorieID from Salarii_CategoriiAngajati where ScutireImpozit=0)
--Update Angajati set Nationalitate=1
--Update CartiIdentitate set Activ=1
/*select * 
from tm_IntervaleAngajat
where AngajatID=@AngajatID and
	@DataStart<=Data and
	Data<=@DataEnd and
	CapatInterval=0 and 
	TipIntervalID=@TipIntervalID*/

Select Count( AngajatID )
from AngajatFull
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO




/*
*	Author: Ionel Popa
*	Description: formateaza o data de tip calendaristic
*	Params: data calendaristica
*/

CREATE          FUNCTION FormatData (@data datetime)  
RETURNS varchar(10) AS  
BEGIN 

declare @ret varchar(10)

set @ret =cast( day(@data) as varchar(2)) + '.' + cast( month(@data) as varchar(2)) + '.' + cast(year(@data) as varchar(4))

return @ret
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
*	Author: Ionel Popa
*	Description: formateaza un sir de tipul 'dd.mm.yyyy' la o data calendaristica 
*	Params: sirul cu data si separatorul
*/

CREATE           FUNCTION FormatDataFromString (@data nvarchar(128), @separator char)  
RETURNS varchar(10) AS  
BEGIN 

declare @ret varchar(10)
declare @sirCautare nvarchar(4)
declare @leftText nvarchar(128)
declare @pos int
declare @day nchar(2)
declare @month nchar(2)
declare @year nchar(4)

set @sirCautare = '%' + @separator + '%'

set @leftText = @data + @separator
set @pos = patindex(@sirCautare, @leftText)
set @day = substring( @leftText, 0, @pos ) 

set @leftText = substring( @leftText, @pos + 1, len(@leftText) - @pos)
set @pos = patindex(@sirCautare, @leftText)
set @month = substring( @leftText, 0, @pos )

set @leftText = substring( @leftText, @pos + 1, len(@leftText) - @pos)
set @pos = patindex(@sirCautare, @leftText)
set @year = substring( @leftText, 0, @pos )

set @ret = @month + '.' + @day + '.' + @year

return @ret
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
* Autor:		Mircea Albutiu, PSE RO BS TH
* Nume:			IsDigit
* Descriere:	Verifica daca parametrul de intrare este cifra sau nu.
*				Intoarce 0 daca este cifra si 1 altfel
*/
CREATE FUNCTION dbo.IsDigit (@in_char char(1))  
RETURNS bit AS  
BEGIN 
	declare @RetVal bit
	set @RetVal =
	case
		when @in_char = '0' then 0
		when @in_char = '1' then 0
		when @in_char = '2' then 0
		when @in_char = '3' then 0
		when @in_char = '4' then 0
		when @in_char = '5' then 0
		when @in_char = '6' then 0
		when @in_char = '7' then 0
		when @in_char = '8' then 0
		when @in_char = '9' then 0
		else 1
	end
	return @RetVal
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO


/*
	Author:		Ionel Popa
	Description:	Rotunjeste o suma inferior
	Params:		suma: suma de rotunjit
			factor: rotunjirea se va face la 10^factor
*/

CREATE  FUNCTION dbo.RoundDownSumOfMoney
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

set @suma = @sumaIntrare
set @strSuma = cast( @suma as nvarchar(32))

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
		if len(@strSuma) > @factor
			begin
				set @strFirstPart = substring( @strSuma, 0, len(@strSuma) - @factor + 1)
				set @firstPart = cast( @strFirstPart as bigint)
			end
		else
			begin
				set @firstPart = 0
			end
				
		set @retSuma = @firstPart * @sumaRotunjire
	end
else
	begin
		set @retSuma = @suma
	end

return @retSuma

END






GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


/*
	Author:			Ionel Popa
	Description:	Rotunjeste o suma
	Params:			suma: suma de rotunjit
				factor: rotunjirea se va face la 10^factor
*/

CREATE  FUNCTION dbo.RoundUpSumOfMoney
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

set @suma = @sumaIntrare
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
	
		if @lastPart > 0
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





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE FUNCTION [dbo].[tm_ApartinePerioada] (@Data datetime, @An int, @Luna int)  
RETURNS bit  AS  
BEGIN 

declare @tmp bit

if (datepart(yy,@Data)=@An and datepart(mm,@Data)=@Luna) set @tmp = 1 else set @tmp=0;

return @tmp

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO



CREATE   FUNCTION dbo.tm_OreInterval (@DataStart datetime, @DataEnd datetime)  
RETURNS float AS  
BEGIN 

declare @minute float
declare @ore float
set @ore = DateDiff(hh,@DataStart,@DataEnd)
set @minute = DateDiff(mi,@DataStart,@DataEnd)

declare @rezultat float
set @rezultat = @ore + (@minute-@ore*60) / 60

return @rezultat


END




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/*
	Author:		Ionel Popa
	Description:	Calculeaza numarul de zile lucrate din intersectia dintre 2 intervale
	Params:		DataStart1: data de start a primului interval
			DataEnd1: data de sfarsit a primului interval
			DataStart2: data de start a celui de-al doilea interval
			DataEnd2: data de sfarsit a celui de-al doilea interval
			Return value: numarul de zile lucratoare din intersectia celor 2 intervale
*/
CREATE FUNCTION DiferenceBetweenTwoPeriods
(
	@DataStart1 as datetime,
	@DataEnd1 as datetime,
	@DataStart2 as datetime,
	@DataEnd2 as datetime
)  
RETURNS int AS  
BEGIN 

declare @NumberOfDays as int
declare @ret as int
declare @DataStartIntersectie as datetime
declare @DataEndIntersectie as datetime

--Cazul I ... DataStart1 >= DataStart2 and DataEnd1 >= DataEnd2
if datediff( day, @DataStart2,  @DataStart1 )  >= 0 and datediff( day,  @DataEnd2, @DataEnd1 ) >= 0
begin
	set @NumberOfDays = datediff(day, @DataStart1, @DataEnd2)
	set @DataStartIntersectie = @DataStart1
	set @DataEndIntersectie = @DataEnd2
end 

--Cazul II ... DataStart1 <= DataStart2 and DataEnd1 <= DataEnd2
if datediff( day,  @DataStart1, @DataStart2) >= 0 and datediff( day,  @DataEnd1, @DataEnd2 ) >= 0
begin
	set @NumberOfDays =  datediff(day, @DataStart2, @DataEnd1)
	set @DataStartIntersectie = @DataStart2
	set @DataEndIntersectie = @DataEnd1
end

--Cazul III ... DataStart1 >= DataStart2 and DataEnd1 <= DataEnd2
if datediff( day,  @DataStart2, @DataStart1) >= 0 and datediff( day, @DataEnd1, @DataEnd2) >= 0
begin
	set @NumberOfDays = datediff(day, @DataStart1, @DataEnd1)
	set @DataStartIntersectie = @DataStart1
	set @DataEndIntersectie = @DataEnd1
end

--Cazul IV ... DataStart1 <= DataStart2 and DataEnd1 >= DataEnd2
if datediff( day, @DataStart1, @DataStart2) >= 0 and datediff( day, @DataEnd2, @DataEnd1) >= 0
begin
	set @NumberOfDays =  datediff(day, @DataStart2, @DataEnd2)
	set @DataStartIntersectie = @DataStart2
	set @DataEndIntersectie = @DataEnd2
end


select @ret = count(*) from tm_zile
where datediff( day, @DataStartIntersectie,Data) >= 0 and datediff( day, Data, @DataEndIntersectie) >= 0 and Sarbatoare = 0

return @ret

END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


/*
*	Author: Ionel Popa
*	Description: Raporteaza sumaVenituriBrute la grila de impozitare anuala din care va rezulta o suma.
*			Aceasta suma este Impozitul Anual platit de angajat
*	Params: Id-ul angajatului si suma veniturilor brute
*/

CREATE   FUNCTION calculateAnualImpozit ( @angajatID int, @sumaVenituriBrute money)  
RETURNS money AS  
BEGIN 

declare @impozitarAnual CURSOR
declare @impozitarId int
declare @valMin money
declare @valMax money
declare @suma money
declare @procent int
declare @data datetime
declare @categorieID int
declare @retVal money
declare @procentVal money

set @retVal = 0

set @impozitarAnual =  CURSOR SCROLL DYNAMIC
FOR
select * from sal_impozitar_anual

open @impozitarAnual

fetch next from @impozitarAnual
into @impozitarId, @valMin, @valMax, @suma, @procent, @data, @categorieID
set @retVal = @sumaVenituriBrute
while @@fetch_status = 0
begin
	if ( @valMin < @sumaVenituriBrute and @sumaVenituriBrute <= @valMax)
	begin
		set @retVal = @retVal - @suma
		set @procentVal = @retVal - @valMin
		set @procentVal = @procentVal * @procent * 0.01
		set @retVal = @retVal - @procentVal
	end
	fetch next from @impozitarAnual
	into @impozitarId, @valMin, @valMax, @suma, @procent, @data, @categorieID
end

close @impozitarAnual
DEALLOCATE @impozitarAnual

return @retVal
END





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO





/*
*	Author: Ionel Popa
*	Description: verifica daca muncitorul cu id-ul dat ca paramaetru a muncit ultimele luni in cadrul firmei
*	Params: Id-ul angajatului si numarul de luni
*/

CREATE         FUNCTION doesTheEmployeWorkInLastMonths (@angajatID int, @year numeric)  
RETURNS bit AS  
BEGIN 

declare @ret bit
declare @noOfEmployes int
declare @retCursor CURSOR
declare @temp int

set @ret = 1
set @noOfEmployes = 0

SELECT    @ret = count(af.angajatid)
			FROM	AngajatFull af
			WHERE
		      	nationalitate = 'româna' 
			and
			af.angajatid = @angajatid
			AND
			       (SELECT     COUNT(DISTINCT lunaid)
			         FROM          sal_salarii s1
			         WHERE      af.angajatid = s1.angajatID AND LunaID IN
			                                    (SELECT     lunaid
			                                      FROM      sal_luni
								where year(data) = @year
			                                      )
				) > 2
			and arealtevenituri = 0
			and solicitadeduceri = 0
			group by af.angajatid

return @ret
END



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

