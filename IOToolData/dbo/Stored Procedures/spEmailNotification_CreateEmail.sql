CREATE PROCEDURE [dbo].[spEmailNotification_CreateEmail]
	@Id int
AS
begin

	set nocount on;

	select [Requests].[Id] as [Id], [Users].[Name] as [RequesterName], [Users].[Email] as [RequesterEmail],
	       [RequestTypes].[Type] as [RequestType],
		   concat([SupplierFrom].[Name], ' - ', [CityFrom].[Name], ' - ', [CountryFrom].[Name]) as [From],
		   concat([SupplierTo].[Name], ' - ', [CityTo].[Name], ' - ', [CountryTo].[Name]) as [To],
		   [Requests].[ETD] as [ETD], [Requests].[ETA] as [ETA], [Requests].[PalletNr] as [PalletNr],
		   [Requests].[Weight] as [Weight], [RequestInfo].[CommentRequester] as [CommentRequester]
	from dbo.[Requests]
	join dbo.[RequestInfo] on [Requests].[Id] = [RequestInfo].[Id_Request]
	join dbo.[Users] on [RequestInfo].[Id_Requester] = [Users].[Id]
	join dbo.[RequestTypes] on [Requests].[Id_RequestType] = [RequestTypes].[Id]
	join [Suppliers] as [SupplierFrom] on [Requests].[Id_SupplierFrom] = [SupplierFrom].[Id]
	join [Countries] as [CountryFrom] on [SupplierFrom].[Id_Country] = [CountryFrom].[Id]
	join [Cities] as [CityFrom] on [SupplierFrom].[Id_City] = [CityFrom].[Id]
	join [Suppliers] as [SupplierTo] on [Requests].[Id_SupplierTo] = [SupplierTo].[Id]
	join [Countries] as [CountryTo] on [SupplierTo].[Id_Country] = [CountryTo].[Id]
	join [Cities] as [CityTo] on [SupplierTo].[Id_City] = [CityTo].[Id]
	where [Requests].[Id]  = @Id
end