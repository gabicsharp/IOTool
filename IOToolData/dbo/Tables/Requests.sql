CREATE TABLE [dbo].[Requests]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Month] NVARCHAR(50) NOT NULL, 
    [Id_RequestType] INT NOT NULL, 
    [Id_TransportType] INT NOT NULL, 
    [Week] INT NOT NULL, 
    [ETD] DATETIME2 NOT NULL, 
    [ETA] DATETIME2 NOT NULL, 
    [Id_SupplierFrom] INT NOT NULL, 
    [Id_SupplierTo] INT NOT NULL, 
    [Id_Material] INT NOT NULL, 
    [Id_Transporter] INT NOT NULL, 
    [AWB] NVARCHAR(50) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [Id_CostCenter] INT NOT NULL, 
    [BillNr] NVARCHAR(50) NOT NULL, 
    [PalletNr] INT NOT NULL, 
    [PricePallet] MONEY NOT NULL, 
    [Weight] INT NOT NULL
)
