CREATE PROCEDURE [dbo].[spCities_AllForACountry]
	@Id_Country int
AS
begin

	set nocount on;

	select [Id], [Name], [Id_Country], [Active]
	from dbo.[Cities]
	where Active = 1 and Id_Country = @Id_Country
	order by [Name] asc;

end