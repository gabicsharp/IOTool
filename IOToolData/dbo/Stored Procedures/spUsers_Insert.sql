CREATE PROCEDURE [dbo].[spUsers_Insert]
	@Name nvarchar(100),
	@Function nvarchar(100),
	@Department nvarchar(100),
	@Location nvarchar(100),
	@CostCenter nvarchar(50),
	@Email nvarchar(150),
	@WindowsAccount nvarchar(50),
	@AccountRights nvarchar(50),
	@Active int
AS
begin

	set nocount on;

	insert into dbo.[Users]([Name], [Function], [Department], [Location], [CostCenter], [Email], [WindowsAccount], [AccountRights], [Active])
    values(@Name, @Function, @Department, @Location, @CostCenter, @Email, @WindowsAccount, @AccountRights, @Active);

end