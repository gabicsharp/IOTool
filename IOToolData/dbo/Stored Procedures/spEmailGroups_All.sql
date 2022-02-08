CREATE PROCEDURE [dbo].[spEmailGroups_Get]
AS
begin

	set nocount on;

	select [Id], [Email], [Description], [Alias], [Active]
	from dbo.[EmailGroups]
	where [EmailGroups].[Active] = 1;

end