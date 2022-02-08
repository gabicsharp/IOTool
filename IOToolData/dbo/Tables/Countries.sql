CREATE TABLE [dbo].[Countries]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Code] NVARCHAR(10) NOT NULL, 
    [Active] INT NOT NULL
)
