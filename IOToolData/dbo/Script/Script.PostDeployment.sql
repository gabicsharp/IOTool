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
    values ('IOTool_Level1', 'IOTool_Level1', '.com', '.com', 'Level1', 1),
           ('IOTool_Level2', 'IOTool_Level2', '.com', '.com', 'Level2', 1),
           ('IOTool_Level3', 'IOTool_Level3', '.com', '.com', 'Level3', 1),
           ('IOTool_Level4', 'IOTool_Level4', '.com', '.com', 'Level4', 1),
           ('IOTool_Level5', 'IOTool_Level5', '.com', '.com', 'Level5', 1)
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


if not exists (select * from dbo.TransportTypes)
begin
    insert into dbo.TransportTypes([Type], [Active] )
    values ('Land', 1),
           ('Parcel', 1),
           ('Sea', 1),
           ('Air', 1)
end

if not exists (select * from dbo.Suppliers)
begin
    insert into dbo.Suppliers([Name], [Id_Country], [Id_City], [Address], [Zip], [Active], [Home])
    values ('Test1', 171, 13099, 'Str. Hermann Oberth 23', '050505', 1, 1)
end

if not exists (select * from dbo.Transporters)
begin
    insert into dbo.Transporters([Name], [Email], [PhoneNumber], [Id_Country], [Id_City], [Address], [Zip], [Alias], [Active])
    values ('Fartud', 'office@fartud.ro', '0712345678', 171, 13099, 'Str. Hermann Oberth 23', '050505', 'Fartud', 1)
end

if not exists (select * from dbo.EmailGroups)
begin
    insert into dbo.EmailGroups([Email], [Description], [Alias], [Active] )
    values ('test@.com', 'Logistic Team', 'Logistic Team', 1)
end

if not exists (select * from dbo.CostCenters)
begin
    insert into dbo.CostCenters([CC], [Active] )
    values ('00-00', 1)
end