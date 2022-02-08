CREATE PROCEDURE [dbo].[spTransporters_All]
AS
begin

	set nocount on;

	select [Id], [Name], [Email], [PhoneNumber], [Id_Country], [Id_City], [Address], [Zip], [Alias], [Active]
	from dbo.[Transporters]
	where Active = 1;

end