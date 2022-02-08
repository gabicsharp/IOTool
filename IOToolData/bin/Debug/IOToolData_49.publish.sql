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
PRINT N'Creating Procedure [dbo].[spCostCenters_All]...';


GO
CREATE PROCEDURE [dbo].[spCostCenters_All]
AS
begin

	set nocount on;

	select [Id], [CC], [Active]
	from dbo.[CostCenters]
	where [CostCenters].[Active] = 1

end
GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/



if not exists (select * from dbo.AdGroups)
begin
    insert into dbo.AdGroups([Name], [Location], [FullDomain], [ShortDomain], [RightsName], [Active])
    values ('bra1_2515_IOTool_Level1', 'vt1.vitesco.com/lda/ro/bra1/Administration/DSOfficeGroups/bra1_2515_IOTool_Level1', 'vt1.vitesco.com', 'vt1', 'Level1', 1),
           ('bra1_2515_IOTool_Level2', 'vt1.vitesco.com/lda/ro/bra1/Administration/DSOfficeGroups/bra1_2515_IOTool_Level2', 'vt1.vitesco.com', 'vt1', 'Level2', 1),
           ('bra1_2515_IOTool_Level3', 'vt1.vitesco.com/lda/ro/bra1/Administration/DSOfficeGroups/bra1_2515_IOTool_Level3', 'vt1.vitesco.com', 'vt1', 'Level3', 1),
           ('bra1_2515_IOTool_Level4', 'vt1.vitesco.com/lda/ro/bra1/Administration/DSOfficeGroups/bra1_2515_IOTool_Level4', 'vt1.vitesco.com', 'vt1', 'Level4', 1),
           ('bra1_2515_IOTool_Level5', 'vt1.vitesco.com/lda/ro/bra1/Administration/DSOfficeGroups/bra1_2515_IOTool_Level5', 'vt1.vitesco.com', 'vt1', 'Level5', 1)
end

if not exists (select * from dbo.Materials)
begin
    insert into dbo.Materials([Material], [Active])
    values('Materials', 1),
          ('Packaging', 1)
end

if not exists (select * from dbo.RequestStatus)
begin
    insert into dbo.RequestStatus([Status], [Active])
    values ('Open', 1),
           ('InProgress', 1),
           ('Resolved', 1),
           ('Closed', 1),
           ('Deleted', 1)
end

if not exists (select * from dbo.RequestTypes)
begin
    insert into dbo.RequestTypes([Type], [Active])
    values ('Inbound', 1),
           ('Outbound', 1)
end

if not exists (select * from dbo.Smtp)
begin
    insert into dbo.Smtp([Server], [Port], [EmailSender], [Active])
    values ('smtp.vitesco-technologies.net', 25, 'IOTool <VT_GX_SM_System_Notification_Service@vitesco-technologies.net>', 1)
end

if not exists (select * from dbo.TransportTypes)
begin
    insert into dbo.TransportTypes([Type], [Active] )
    values ('Land', 1),
           ('Parcel', 1),
           ('Sea', 1),
           ('Air', 1)
end
GO

GO
PRINT N'Update complete.';


GO
