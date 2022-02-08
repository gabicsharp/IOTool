CREATE PROCEDURE [dbo].[spCities_GetById]
	@Id1 int,
	@Id2 int
AS
begin

	set nocount on;

	select [Cities].[Name]
	from dbo.[Cities]
	where [Cities].[Id] = @Id1 or [Cities].[Id] = @Id2

end