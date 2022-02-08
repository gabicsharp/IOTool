CREATE PROCEDURE [dbo].[spSuppliers_GetByIdWithIds]
	@Id int
AS
begin

	set nocount on;

	select [Id], [Name], [Id_Country], [Id_City], [Address], [Zip], [Active], [Home]
	from dbo.[Suppliers]
	where Id = @Id;

end