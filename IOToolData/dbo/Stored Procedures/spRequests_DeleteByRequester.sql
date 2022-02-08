CREATE PROCEDURE [dbo].[spRequests_DeleteByRequester]
	@Id int,
	@CommentRequesterForClose nvarchar(200)
AS
begin

	set nocount on;

	Update dbo.[RequestInfo]
	set [RequestInfo].[Id_RequestStatus] = 5,
	    [RequestInfo].[CommentRequesterForClose] = @CommentRequesterForClose
	where [RequestInfo].[Id_Request] = @Id

end