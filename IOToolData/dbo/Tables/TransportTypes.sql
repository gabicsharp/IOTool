CREATE TABLE [dbo].[TransportTypes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Type] NVARCHAR(50) NOT NULL, 
    [Active] INT NOT NULL
)
