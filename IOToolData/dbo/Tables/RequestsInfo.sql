CREATE TABLE [dbo].[RequestInfo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Id_Request] INT NOT NULL, 
    [Id_Requester] INT NOT NULL, 
    [Id_Processor] INT NOT NULL, 
    [IntervalHoursToPickUp] NVARCHAR(50) NOT NULL, 
    [CommentRequester] NVARCHAR(200) NOT NULL, 
    [CommentProcessor] NVARCHAR(200) NOT NULL, 
    [CommentRequesterForClose] NVARCHAR(200) NOT NULL, 
    [CommentProcessorForClose] NVARCHAR(200) NOT NULL, 
    [Id_RequestStatus] INT NOT NULL, 
    [PremiumFreight] INT NOT NULL, 
)
