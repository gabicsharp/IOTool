CREATE TABLE [dbo].[RequestStatus]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Status] NVARCHAR(50) NOT NULL, 
    [Active] INT NOT NULL
)
