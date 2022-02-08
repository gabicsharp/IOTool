CREATE PROCEDURE [dbo].[spTransportTypes_All]
AS
begin

	set nocount on;

	select [Id], [Type]
	from dbo.[TransportTypes]
	where [TransportTypes].[Active] = 1

end