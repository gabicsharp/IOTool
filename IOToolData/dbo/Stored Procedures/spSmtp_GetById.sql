CREATE PROCEDURE [dbo].[spSmtp_Get]
AS
begin

	set nocount on;

	select [Id], [Server], [Port], [EmailSender], [Active]
	from dbo.[Smtp]
	where [Smtp].[Active] = 1

end