CREATE PROCEDURE [dbo].[spRequests_DeleteByProcessor]
	@Id int,
	@CommentProcessorForClose nvarchar(200)
AS
begin

	set nocount on;

	Update dbo.[RequestInfo]
	set [RequestInfo].[Id_RequestStatus] = 5,
	    [RequestInfo].[CommentProcessorForClose] = @CommentProcessorForClose
	where [RequestInfo].[Id_Request] = @Id

end