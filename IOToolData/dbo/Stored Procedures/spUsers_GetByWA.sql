CREATE PROCEDURE [dbo].[spUsers_GetByWA]
	@WindowsAccount nvarchar(50)
AS
begin

	set nocount on;

	select [Id], [Name], [Function], [Department], [Location], [CostCenter], [Email], [WindowsAccount], [AccountRights], [Active]
	from dbo.[Users]
	where [Users].[WindowsAccount] = @WindowsAccount;

end