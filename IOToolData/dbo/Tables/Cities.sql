CREATE TABLE [dbo].[Cities]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Id_Country] INT NOT NULL, 
    [Active] INT NOT NULL
)
