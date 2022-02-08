CREATE PROCEDURE [dbo].[spRequests_GetByIdToSpecificUser]
	@Id int,
	@WindowsAccount nvarchar(50)
AS
begin

	set nocount on;

	 select [Requests].[Id] as [Id], [RequestTypes].[Type] as [RequestType], [SupplierFrom].[Name] as [From], 
			[SupplierTo].[Name] as [To], [Requests].[ETD] as [ETD], [Requests].[ETA] as [ETA], 
			[Requests].[PalletNr] as [PalletNr], [Requests].[Weight] as [Weight], 
			[RequestInfo].[CommentRequester] as [CommentRequester], [RequestStatus].[Status] as [Status]
	from dbo.[Requests]
	join dbo.[RequestInfo] on [Requests].[Id] = [RequestInfo].[Id_Request]
	join dbo.[RequestTypes] on [Requests].[Id_RequestType] = [RequestTypes].[Id]
	join dbo.[RequestStatus] on [RequestInfo].[Id_RequestStatus] = [RequestStatus].[Id]
 	join dbo.[Users] on [RequestInfo].[Id_Requester] = [Users].[Id]
	join dbo.[Suppliers] as SupplierFrom on [Requests].[Id_SupplierFrom] = [SupplierFrom].[Id]
	join dbo.[Suppliers] as SupplierTo on [Requests].[Id_SupplierTo] = [SupplierTo].[Id]
	where [Requests].[Id] = @Id and [Users].[WindowsAccount] = @WindowsAccount

end