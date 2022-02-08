CREATE PROCEDURE [dbo].[spRequests_UpdateByProcessor]
	@Id int,
	@Id_Transporter int,
	@Id_TransportType int,
	@Id_Material int,
	@AWB nvarchar(50),
	@BillNr nvarchar(50),
	@Price money,
	@PremiumFreight int,
	@Id_CostCenter int,
	@CommentProcessor nvarchar(200),
	@Id_RequestStatus int,
	@Id_Processor int
AS
begin

	set nocount on;

	update dbo.[Requests]
    set [Requests].[Id_Transporter] = @Id_Transporter,
		[Requests].[Id_TransportType] = @Id_TransportType,
		[Requests].[Id_Material] = @Id_Material,
		[Requests].[AWB] = @AWB,
		[Requests].[Price] = @Price,
		[Requests].[Id_CostCenter] = @Id_CostCenter
	where [Requests].[Id] = @Id

	update dbo.[RequestInfo]
	set [RequestInfo].[PremiumFreight] = @PremiumFreight,
		[RequestInfo].[CommentProcessor] = @CommentProcessor,
		[RequestInfo].[Id_RequestStatus] = @Id_RequestStatus,
		[RequestInfo].[Id_Processor] = @Id_Processor
	where [RequestInfo].[Id_Request] = @Id

end