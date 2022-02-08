CREATE TABLE [dbo].[Transporters]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Email] NVARCHAR(100) NOT NULL, 
    [PhoneNumber] NVARCHAR(50) NOT NULL, 
    [Id_Country] INT NOT NULL, 
    [Id_City] INT NOT NULL, 
    [Address] NVARCHAR(100) NOT NULL, 
    [Zip] NVARCHAR(50) NOT NULL, 
    [Alias] NVARCHAR(100) NOT NULL, 
    [Active] INT NOT NULL
)
