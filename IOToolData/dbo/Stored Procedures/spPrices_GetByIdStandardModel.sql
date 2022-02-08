CREATE PROCEDURE [dbo].[spPrices_GetByIdStandardModel]
	@Id_OriginCity int,
	@Id_DestinationCity int
AS
begin

	set nocount on;

	select *
	from dbo.[Prices]
	where [Prices].[Id_OriginCity] =  @Id_OriginCity and [Prices].[Id_DestinationCity] = @Id_DestinationCity

end