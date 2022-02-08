CREATE PROCEDURE [dbo].[spSuppliers_GetById]
	@Id int
AS
begin

	set nocount on;

	select Suppliers.[Id] as Id, Suppliers.[Name] as Name, Countries.[Name] as Country, Cities.[Name] as City, Suppliers.[Address] as Address, Suppliers.[Zip] as Zip, Suppliers.[Active] as Active, Suppliers.[Home] as Home
	from dbo.[Suppliers]
	join Countries on Suppliers.[Id_Country] = Countries.[Id]
	join Cities on Suppliers.[Id_City] = Cities.[Id]
	where Suppliers.[Id] = @Id

end