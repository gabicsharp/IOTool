CREATE TABLE [dbo].[Smtp]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Server] NVARCHAR(100) NOT NULL, 
    [Port] INT NOT NULL, 
    [EmailSender] NVARCHAR(100) NOT NULL, 
    [Active] INT NOT NULL
)
