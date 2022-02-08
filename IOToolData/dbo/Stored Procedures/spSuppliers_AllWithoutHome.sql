CREATE PROCEDURE [dbo].[spSuppliers_AllWithoutHome]
AS
begin

	set nocount on;

	select Suppliers.[Id] as Id, Suppliers.[Name] as Name, Countries.[Name] as Country, Cities.[Name] as City, Suppliers.[Address] as Address, Suppliers.[Zip] as Zip
	from Suppliers
	join Countries on Suppliers.[Id_Country] = Countries.[Id]
	join Cities on Suppliers.[Id_City] = Cities.[Id]
	where Suppliers.[Active] = 1 and Suppliers.[Home] = 0;

end