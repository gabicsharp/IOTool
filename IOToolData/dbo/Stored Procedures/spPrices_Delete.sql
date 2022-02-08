CREATE PROCEDURE [dbo].[spPrices_Delete]
	@Id int
AS
begin

	set nocount on;

	Update dbo.[Prices]
	set [Prices].[Active] = 0
	where [Prices].[Id] = @Id

end