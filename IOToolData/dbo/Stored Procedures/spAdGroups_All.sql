CREATE PROCEDURE [dbo].[spAdGroups_All]
AS
begin

	set nocount on;

	select [Id], [Name], [Location], [FullDomain], [ShortDomain], [RightsName], [Active]
	from dbo.[AdGroups]
	where [AdGroups].[Active] = 1;

end