CREATE PROCEDURE [dbo].[spCountries_GetById]
	@Id int
AS
begin

	set nocount on;

	select [Id], [Name], [Code], [Active]
	from dbo.[Countries]
	where [Countries].[Id] = @Id

end