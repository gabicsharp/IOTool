CREATE PROCEDURE [dbo].[spRequestTypes_GetById]
	@Id int
AS
begin

	set nocount on;

	select [Id], [Type], [Active]
	from dbo.[RequestTypes]
	where [RequestTypes].[Id] = @Id

end