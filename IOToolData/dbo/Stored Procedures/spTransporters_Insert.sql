CREATE PROCEDURE [dbo].[spTransporters_Insert]
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

	insert into dbo.[Transporters]([Name], Email, PhoneNumber, Id_Country, Id_City, [Address], Zip, Alias, Active)
	values (@Name, @Email, @PhoneNumber, @Id_Country, @Id_City, @Address, @Zip, @Alias, @Active);

end