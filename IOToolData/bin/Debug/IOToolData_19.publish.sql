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
/*
The type for column Id_RequestStatus in table [dbo].[RequestInfo] is currently  NVARCHAR (50) NOT NULL but is being changed to  INT NOT NULL. Data loss could occur and deployment may fail if the column contains data that is incompatible with type  INT NOT NULL.
*/

IF EXISTS (select top 1 1 from [dbo].[RequestInfo])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'The following operation was generated from a refactoring log file c9d0dd3c-d5ae-4704-bed2-18069a3ba35c';

PRINT N'Rename [dbo].[RequestInfo].[Status] to Id_RequestStatus';


GO
EXECUTE sp_rename @objname = N'[dbo].[RequestInfo].[Status]', @newname = N'Id_RequestStatus', @objtype = N'COLUMN';


GO
PRINT N'Altering Table [dbo].[RequestInfo]...';


GO
ALTER TABLE [dbo].[RequestInfo] ALTER COLUMN [Id_RequestStatus] INT NOT NULL;


GO
PRINT N'Altering Procedure [dbo].[spRequestInfo_Insert]...';


GO
ALTER PROCEDURE [dbo].[spRequestInfo_Insert]
	@Id_Request int,
	@Id_Requester int,
	@Id_Processor int,
	@IntervalHoursToPickUp nvarchar(50),
	@CommentRequester nvarchar(200),
	@CommentProcessor nvarchar(200),
	@CommentRequesterForClose nvarchar(200),
	@CommentProcessorForClose nvarchar(200),
	@Status nvarchar(50),
	@PremiumFreight int,
	@Id int output
AS
begin

	set nocount on;

	insert into dbo.[RequestInfo](Id_Request, Id_Requester, Id_Processor, IntervalHoursToPickUp, CommentRequester, CommentProcessor,
								  CommentRequesterForClose, CommentProcessorForClose, Id_RequestStatus, PremiumFreight)
	values(@Id_Request, @Id_Requester, @Id_Processor, @IntervalHoursToPickUp, @CommentRequester, @CommentProcessor,
		   @CommentRequesterForClose, @CommentProcessorForClose, @Status, @PremiumFreight)
	
	set @Id = SCOPE_IDENTITY();
end
GO
PRINT N'Altering Procedure [dbo].[spRequests_GetByUser]...';


GO
ALTER PROCEDURE [dbo].[spRequests_GetByUser]
	@WindowsAccount nvarchar(50)
AS
begin

	set nocount on;

	select [Requests].[Id] as Id, [Requests].[Month] as MonthYear, [SupplierFrom].[Name] as SupplierFromName, 
		   [SupplierTo].[Name] as SupplierToName, [RequestInfo].[Id_RequestStatus] as StatusRequest
	from dbo.[Requests]
	join dbo.[RequestInfo] on [Requests].[Id] = [RequestInfo].[Id_Request]
	join dbo.[Users] on [RequestInfo].[Id_Request] = [Users].[Id]
	join dbo.[Suppliers] as SupplierFrom on [Requests].[Id_SupplierFrom] = [SupplierFrom].[Id]
	join dbo.[Suppliers] as SupplierTo on [Requests].[Id_SupplierTo] = [SupplierTo].[Id]
	where [Users].[WindowsAccount] = @WindowsAccount

end
GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'c9d0dd3c-d5ae-4704-bed2-18069a3ba35c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('c9d0dd3c-d5ae-4704-bed2-18069a3ba35c')

GO

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
