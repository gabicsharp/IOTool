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
PRINT N'Creating Table [dbo].[EmailsToSend]...';


GO
CREATE TABLE [dbo].[EmailsToSend] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [From] NVARCHAR (500) NOT NULL,
    [To]   NVARCHAR (500) NOT NULL,
    [Body] NVARCHAR (MAX) NOT NULL,
    [Flag] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Procedure [dbo].[spRequestTypes_GetById]...';


GO
CREATE PROCEDURE [dbo].[spRequestTypes_GetById]
	@Id int
AS
begin

	set nocount on;

	select [RequestTypes].[Type]
	from dbo.[RequestTypes]
	where [RequestTypes].[Id] = @Id

end
GO
PRINT N'Update complete.';


GO
