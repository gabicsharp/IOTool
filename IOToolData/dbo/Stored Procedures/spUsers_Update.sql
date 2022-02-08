CREATE PROCEDURE [dbo].[spUsers_Update]
	@Id int,
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

	update dbo.[Users]
	set [Name] = @Name,
		[Function] = @Function,
		[Department] = @Department,
		[Location] = @Location,
		[CostCenter] = @CostCenter,
		[Email] = @Email,
		[WindowsAccount] = @WindowsAccount,
		[AccountRights] = @AccountRights,
		[Active] = @Active
	where [Id] = @Id

end