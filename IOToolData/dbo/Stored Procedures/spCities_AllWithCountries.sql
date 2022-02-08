CREATE PROCEDURE [dbo].[spCities_AllWithCountries]
AS
begin

	set nocount on;

	select TOP(100) [Cities].[Id] as Id, [Cities].[Name] as City, [Countries].[Name] as Country
	from dbo.[Cities]
	join dbo.[Countries] on [Cities].[Id_Country] = [Countries].[Id]
	where [Cities].[Active] = 1
	order by [Cities].[Name] asc;

end