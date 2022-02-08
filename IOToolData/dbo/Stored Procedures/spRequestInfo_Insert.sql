CREATE PROCEDURE [dbo].[spRequestInfo_Insert]
	@Id_Request int,
	@Id_Requester int,
	@Id_Processor int,
	@IntervalHoursToPickUp nvarchar(50),
	@CommentRequester nvarchar(200),
	@CommentProcessor nvarchar(200),
	@CommentRequesterForClose nvarchar(200),
	@CommentProcessorForClose nvarchar(200),
	@Id_RequestStatus int,
	@PremiumFreight int,
	@Id int output
AS
begin

	set nocount on;

	insert into dbo.[RequestInfo](Id_Request, Id_Requester, Id_Processor, IntervalHoursToPickUp, CommentRequester, CommentProcessor,
								  CommentRequesterForClose, CommentProcessorForClose, Id_RequestStatus, PremiumFreight)
	values(@Id_Request, @Id_Requester, @Id_Processor, @IntervalHoursToPickUp, @CommentRequester, @CommentProcessor,
		   @CommentRequesterForClose, @CommentProcessorForClose, @Id_RequestStatus, @PremiumFreight)
	
	set @Id = SCOPE_IDENTITY();
end