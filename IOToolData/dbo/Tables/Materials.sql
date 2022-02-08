CREATE TABLE [dbo].[Materials]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Material] NVARCHAR(50) NOT NULL, 
    [Active] INT NOT NULL
)
