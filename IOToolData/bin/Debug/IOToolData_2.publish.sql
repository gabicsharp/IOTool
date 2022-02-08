﻿/*
Deployment script for IOToolData

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "IOToolData"
:setvar DefaultFilePrefix "IOToolData"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Altering Procedure [dbo].[spCities_AllWithCountries]...';


GO
ALTER PROCEDURE [dbo].[spCities_AllWithCountries]
AS
begin

	set nocount on;

	select TOP(100) [Cities].[Id] as Id, [Cities].[Name] as City, [Countries].[Name] as Country
	from dbo.[Cities]
	join dbo.[Countries] on [Cities].[Id_Country] = [Countries].[Id]
	where [Cities].[Active] = 1
	order by [Cities].[Name] asc;

end
GO
PRINT N'Creating Procedure [dbo].[spCities_GetById]...';


GO
CREATE PROCEDURE [dbo].[spCities_GetById]
	@Id int
AS
begin

	set nocount on;

	select [Id], [Name], [Id_Country], [Active]
	from dbo.[Cities]
	where [Cities].[Id] = @Id

end
GO
PRINT N'Update complete.';


GO
