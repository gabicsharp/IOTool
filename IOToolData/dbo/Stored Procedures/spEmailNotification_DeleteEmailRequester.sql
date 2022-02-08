CREATE PROCEDURE [dbo].[spEmailNotification_DeleteEmailRequester]
	@Id int
AS
begin

	set nocount on;

	select [Requests].[Id] as [Id], [RequestTypes].[Type] as [RequestType],
		   concat([SupplierFrom].[Name], ' - ', [CityFrom].[Name], ' - ', [CountryFrom].[Name]) as [From],
		   concat([SupplierTo].[Name], ' - ', [CityTo].[Name], ' - ', [CountryTo].[Name]) as [To],
		   [Requester].[Name] as [RequesterName], [Requester].[Email] as [RequesterEmail],
		   [RequestInfo].[CommentRequesterForClose] as [RequesterCommentForClose]
	from dbo.[Requests]
	join dbo.[RequestInfo] on [Requests].[Id] = [RequestInfo].[Id_Request]
	join dbo.[Users] as [Requester] on [RequestInfo].[Id_Requester] = [Requester].[Id]
	join dbo.[RequestTypes] on [Requests].[Id_RequestType] = [RequestTypes].[Id]
	join [Suppliers] as [SupplierFrom] on [Requests].[Id_SupplierFrom] = [SupplierFrom].[Id]
	join [Countries] as [CountryFrom] on [SupplierFrom].[Id_Country] = [CountryFrom].[Id]
	join [Cities] as [CityFrom] on [SupplierFrom].[Id_City] = [CityFrom].[Id]
	join [Suppliers] as [SupplierTo] on [Requests].[Id_SupplierTo] = [SupplierTo].[Id]
	join [Countries] as [CountryTo] on [SupplierTo].[Id_Country] = [CountryTo].[Id]
	join [Cities] as [CityTo] on [SupplierTo].[Id_City] = [CityTo].[Id]
	where [Requests].[Id]  = @Id
end