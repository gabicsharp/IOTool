CREATE PROCEDURE [dbo].[spSuppliers_Update]
	@Id int,
	@Name nvarchar(100),
	@Id_Country int,
	@Id_City int,
	@Address nvarchar(100),
	@Zip nvarchar(50),
	@Active int,
	@Home int
AS
begin

	set nocount on;

	update dbo.[Suppliers]
	set Name = @Name,
		Id_Country = @Id_Country,
		Id_City = @Id_City,
		Address = @Address,
		Zip = @Zip,
		Active = @Active,
		Home = @Home
	where Id = @Id

end