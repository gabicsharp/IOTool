CREATE PROCEDURE [dbo].[spTransporters_Delete]
	@Id int
AS
begin

	set nocount on;

	Update dbo.[Transporters]
	set Active = 0
	where Id = @Id

end