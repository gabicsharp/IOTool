CREATE PROCEDURE [dbo].[spPrices_CountryAndCityHome]
AS
begin

	set nocount on;

	select [Countries].[Id] as IdCountry, [Countries].[Name] as Country, [Cities].[Id] as IdCity,  [Cities].[Name] as City
	from [dbo].[Suppliers]
	join Countries on Suppliers.[Id_Country] = Countries.[Id]
	join Cities on Suppliers.[Id_City] = Cities.[Id]
	where [Suppliers].[Active] = 1 and [Suppliers].[Home] = 1

end
