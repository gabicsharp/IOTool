CREATE PROCEDURE [dbo].[spCountries_Delete]
	@Id int
AS
begin

	set nocount on;

	Update dbo.[Countries]
	set Active = 0
	where Id = @Id

end