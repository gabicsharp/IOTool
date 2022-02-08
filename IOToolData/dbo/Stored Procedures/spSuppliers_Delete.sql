CREATE PROCEDURE [dbo].[spSuppliers_Delete]
	@Id int
AS
begin

	set nocount on;

	Update dbo.[Suppliers]
	set Active = 0
	where Id = @Id

end