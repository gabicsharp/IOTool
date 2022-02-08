CREATE PROCEDURE [dbo].[spTransporters_Update]
	@Id int,
	@Name nvarchar(100),
	@Email nvarchar(100),
	@PhoneNumber nvarchar(50),
	@Id_Country int,
	@Id_City int,
	@Address nvarchar(100),
	@Zip nvarchar(50),
	@Alias nvarchar(100),
	@Active int
AS
begin

	set nocount on;

	update dbo.[Transporters]
	set Name = @Name,
		Email = @Email,
		PhoneNumber = @PhoneNumber,
		Id_Country = @Id_Country,
		Id_City = @Id_City,
		Address = @Address,
		Zip = @Zip,
		Alias = @Alias
	where Id = @Id

end