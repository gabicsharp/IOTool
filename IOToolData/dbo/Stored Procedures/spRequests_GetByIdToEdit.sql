CREATE PROCEDURE [dbo].[spRequests_GetByIdToEdit]
	@Id int
AS
begin

	set nocount on;

	select [Requests].[Id] as [Id], [RequestStatus].[Status] as [Status], [RequestTypes].[Type] as [RequestType],
		   concat([SupplierFrom].[Name], ' - ', [CityFrom].[Name], ' - ', [CountryFrom].[Name]) as [From],
		   concat([SupplierTo].[Name], ' - ', [CityTo].[Name], ' - ', [CountryTo].[Name]) as [To],
		   [Requests].[ETD] as [ETD], [Requests].[ETA] as [ETA], [Requests].[PalletNr] as [PalletNr],
		   [Requests].[Weight] as [Weight], [RequestInfo].[CommentRequester] as [CommentRequester],
		   [Transporters].[Id] as [Id_Transporter], [TransportTypes].[Id] as [Id_TransportType],
		   [Materials].[Id] as [Id_Material], [Requests].[AWB] as [AWB], [Requests].[BillNr] as [BillNr],
		   [Requests].[Price] as [Price], [RequestInfo].[PremiumFreight] as [PremiumFreight],
		   [CostCenters].[Id] as [Id_CostCenter], [RequestInfo].[CommentProcessor] as [CommentProcessor],
		   [RequestStatus].[Id] as [Id_RequestStatus]
	from dbo.[Requests]
	join [RequestInfo] on [Requests].[Id] = [RequestInfo].[Id_Request]
	join [RequestStatus] on [RequestInfo].[Id_RequestStatus] = [RequestStatus].[Id]
	join [RequestTypes] on [Requests].[Id_RequestType] = [RequestTypes].[Id]
	join [Suppliers] as [SupplierFrom] on [Requests].[Id_SupplierFrom] = [SupplierFrom].[Id]
	join [Countries] as [CountryFrom] on [SupplierFrom].[Id_Country] = [CountryFrom].[Id]
	join [Cities] as [CityFrom] on [SupplierFrom].[Id_City] = [CityFrom].[Id]
	join [Suppliers] as [SupplierTo] on [Requests].[Id_SupplierTo] = [SupplierTo].[Id]
	join [Countries] as [CountryTo] on [SupplierTo].[Id_Country] = [CountryTo].[Id]
	join [Cities] as [CityTo] on [SupplierTo].[Id_City] = [CityTo].[Id]
	join [Transporters] on [Requests].[Id_Transporter] = [Transporters].[Id]
	join [TransportTypes] on [Requests].[Id_TransportType] = [TransportTypes].[Id]
	join [Materials] on [Requests].[Id_Material] = [Materials].[Id]
	join [CostCenters] on [Requests].[Id_CostCenter] = [CostCenters].[Id]
	where [Requests].[Id] = @Id

end