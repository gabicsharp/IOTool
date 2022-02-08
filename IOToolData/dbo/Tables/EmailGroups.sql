CREATE TABLE [dbo].[EmailGroups]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] NVARCHAR(100) NOT NULL, 
    [Description] NVARCHAR(100) NOT NULL, 
    [Alias] NVARCHAR(50) NOT NULL, 
    [Active] INT NOT NULL
)
