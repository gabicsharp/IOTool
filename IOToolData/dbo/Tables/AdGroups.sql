CREATE TABLE [dbo].[AdGroups]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Location] NVARCHAR(100) NOT NULL, 
    [FullDomain] NVARCHAR(50) NOT NULL, 
    [ShortDomain] NVARCHAR(50) NOT NULL, 
    [RightsName] NVARCHAR(50) NOT NULL, 
    [Active] INT NOT NULL
)
