CREATE PROCEDURE [dbo].[spMaterials_All]
AS
begin

	set nocount on;

	select [Id], [Material]
	from dbo.[Materials]
	where [Materials].[Active] = 1

end