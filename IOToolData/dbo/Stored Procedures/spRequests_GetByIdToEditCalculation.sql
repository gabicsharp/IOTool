CREATE PROCEDURE [dbo].[spRequests_GetByIdToEditCalculation]
	@Id int
AS
begin

	set nocount on;

	select [Requests].[Id] as Id, [Requests].[Id_SupplierFrom] as [IdFrom], [Requests].[Id_SupplierTo] as [IdTo], 
		   [Requests].[PalletNr] as [PalletNr], [Requests].[ETD] as [ETD], [Requests].[ETA] as [ETA]
	from dbo.[Requests]
	where [Requests].[Id] = @Id

end