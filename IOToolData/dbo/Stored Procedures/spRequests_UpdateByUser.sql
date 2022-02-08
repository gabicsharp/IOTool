CREATE PROCEDURE [dbo].[spRequests_UpdateByUser]
	@Id int,
	@ETD datetime2(7),
	@ETA datetime2(7),
	@PalletNr int,
	@Weight int,
	@CommentRequester nvarchar(200)
AS
begin

	set nocount on;

	update dbo.[Requests]
    set [Requests].[ETD] = @ETD,
		[Requests].[ETA] = @ETA,
		[Requests].[PalletNr] = @PalletNr,
		[Requests].[Weight] = @Weight
	where [Requests].[Id] = @Id

	update dbo.[RequestInfo]
	set [RequestInfo].[CommentRequester] = @CommentRequester
	where [RequestInfo].[Id_Request] = @Id

end