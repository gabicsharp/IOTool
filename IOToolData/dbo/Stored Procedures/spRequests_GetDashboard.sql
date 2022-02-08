CREATE PROCEDURE [dbo].[spRequests_GetDashboard]
AS
begin

	set nocount on;

	select [Requests].[Id] as [Id], [Requests].[Month] as [Month], [RequestTypes].[Type] as [RequestType],
		   [TransportTypes].[Type] as [TransportType], [Requests].[Week] as [Week], [Requests].[ETD] as [ETD],
		   [Requests].[ETA] as [ETA], [SupplierFrom].[Name] as [From], [CityFrom].[Name] as [FromLocation],
		   [SupplierTo].[Name] as [To], [CityTo].[Name] as [ToLocation], [Materials].[Material] as [Materials],
		   [Transporters].[Name] as [Transporter], [Requests].[AWB] as [AWB], [Requests].[Price] as [Price],
		   [CostCenters].[CC] as [CostCenter], [Requests].[BillNr] as [BillNr], [Requests].[PalletNr] as [PalletNr],
		   [Requests].[PricePallet] as [PricePallet]
	from dbo.[Requests]
	join dbo.[RequestTypes] on [Requests].[Id_RequestType] = [RequestTypes].[Id]
	join dbo.[TransportTypes] on [Requests].[Id_TransportType] = [TransportTypes].[Id]
	join dbo.[Suppliers] as [SupplierFrom] on [Requests].[Id_SupplierFrom] = [SupplierFrom].[Id]
	join dbo.[Cities] as [CityFrom] on [SupplierFrom].[Id_City] = [CityFrom].[Id]
	join dbo.[Suppliers] as [SupplierTo] on [Requests].[Id_SupplierTo] = [SupplierTo].[Id]
	join dbo.[Cities] as [CityTo] on [SupplierTo].[Id_City] = [CityTo].[Id]
	join dbo.[Materials] on [Requests].[Id_Material] = [Materials].[Id]
	join dbo.[Transporters] on [Requests].[Id_Transporter] = [Transporters].[Id]
	join dbo.[CostCenters] on [Requests].[Id_CostCenter] = [CostCenters].[Id]
	join dbo.[RequestInfo] on [Requests].[Id] =[RequestInfo].[Id_Request]
	where [RequestInfo].[Id_RequestStatus] = 4
	order by [Requests].[Id] desc

end