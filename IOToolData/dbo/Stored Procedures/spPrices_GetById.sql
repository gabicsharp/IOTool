CREATE PROCEDURE [dbo].[spPrices_GetById]
	@Id int
AS
begin

	set nocount on;

		select [Prices].[Id] as Id, [Transporters].[Name] as TransporterName, [Prices].[LaneName] as LaneName,
		   [OriginCountry].[Name] as OriginCountry, [OriginCity].[Name] as OriginCity,
		   [DestinationCountry].[Name] as DestinationCountry, [DestinationCity].[Name] as DestinationCity,
		   [RequestType].[Type] as RequestType
	from dbo.[Prices]
	join dbo.[Transporters] on [Prices].[Id_Transporter] = [Transporters].[Id]
	join dbo.[Countries] as OriginCountry on [Prices].[Id_OriginCountry] = [OriginCountry].[Id]
	join dbo.[Cities] as OriginCity on [Prices].[Id_OriginCity] = [OriginCity].[Id]
	join dbo.[Countries] as DestinationCountry on [Prices].[Id_DestinationCountry] = [DestinationCountry].[Id]
	join dbo.[Cities] as DestinationCity on [Prices].[Id_DestinationCity] = [DestinationCity].[Id]
	join dbo.[RequestTypes] as RequestType on [Prices].[Id_RequestType] = [RequestType].[Id]
	where [Prices].[Id] = @Id

end