CREATE PROCEDURE [dbo].[spRequestTypes_All]
AS
begin

	set nocount on;

	select [Id], [Type]
	from dbo.[RequestTypes]
	where RequestTypes.Active = 1
	order by [Type] asc;

end