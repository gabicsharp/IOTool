CREATE PROCEDURE [dbo].[spCities_All]
AS
begin

	set nocount on;

	select [Cities].[Id] as Id, [Cities].[Name] as City, [Countries].[Name] as Country
	from dbo.[Cities]
	join dbo.[Countries] on [Cities].[Id_Country] = [Countries].[Id]
	where [Cities].[Active] = 1
	order by [Countries].[Name] asc;

end