CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Function] NVARCHAR(100) NOT NULL, 
    [Department] NVARCHAR(100) NOT NULL, 
    [Location] NVARCHAR(100) NOT NULL, 
    [CostCenter] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(150) NOT NULL, 
    [WindowsAccount] NVARCHAR(50) NOT NULL, 
    [AccountRights] NVARCHAR(50) NOT NULL, 
    [Active] INT NOT NULL
)
