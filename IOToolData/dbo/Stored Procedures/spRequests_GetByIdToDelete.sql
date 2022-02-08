CREATE PROCEDURE [dbo].[spRequests_GetByIdToDelete]
	@Id int
AS
begin

	set nocount on;

	select [Requests].[Id] as Id, [SupplierFrom].[Name] as [From], [SupplierTo].[Name] as [To], [RequestStatus].[Status] as [StatusRequest],
		   [RequestStatus].[Id] as [Id_StatusRequest], [RequestInfo].[CommentProcessorForClose] as [Comment]
	from dbo.[Requests]
	join dbo.[RequestInfo] on [Requests].[Id] = [RequestInfo].[Id_Request]
	join dbo.[Suppliers] as [SupplierFrom] on [Requests].[Id_SupplierFrom] = [SupplierFrom].[Id]
	join dbo.[Suppliers] as [SupplierTo] on [Requests].[Id_SupplierTo] = [SupplierTo].[Id]
	join dbo.[RequestStatus] on [RequestInfo].[Id_RequestStatus] = [RequestStatus].[Id]
	where [Requests].[Id] = @Id

end