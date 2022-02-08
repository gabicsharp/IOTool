CREATE PROCEDURE [dbo].[spUsers_All]
AS
begin

	set nocount on;

	select [Id], [Name], [Function], [Department], [Location], [CostCenter], [Email], [WindowsAccount], [AccountRights], [Active]
	from dbo.[Users]
	where Users.Active = 1;

end