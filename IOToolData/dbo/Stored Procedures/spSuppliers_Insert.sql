CREATE PROCEDURE [dbo].[spSuppliers_Insert]
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

	insert into dbo.[Suppliers]([Name], Id_Country, Id_City, [Address], Zip, Active, Home)
	values (@Name, @Id_Country, @Id_City, @Address, @Zip, @Active, @Home);

end