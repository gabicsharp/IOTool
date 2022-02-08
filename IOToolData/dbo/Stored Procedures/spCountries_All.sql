CREATE PROCEDURE [dbo].[spCountries_All]
AS
begin

	set nocount on;

	select [Id], [Name], [Code], [Active]
	from dbo.[Countries]
	where Active = 1
	order by [Name] asc;

end