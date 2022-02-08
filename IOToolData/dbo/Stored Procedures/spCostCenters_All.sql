CREATE PROCEDURE [dbo].[spCostCenters_All]
AS
begin

	set nocount on;

	select [Id], [CC], [Active]
	from dbo.[CostCenters]
	where [CostCenters].[Active] = 1

end