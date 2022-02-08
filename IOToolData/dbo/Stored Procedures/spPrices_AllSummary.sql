CREATE PROCEDURE [dbo].[spPrices_AllSummary]
AS
begin

	set nocount on;

	select [Prices].[Id] as Id, [Transporters].[Name] as TransporterName, [Prices].[LaneName] as LaneName,
		   [OriginCountry].[Name] as OriginCountry, [OriginCity].[Name] as OriginCity,
		   [DestinationCountry].[Name] as DestinationCountry, [DestinationCity].[Name] as DestinationCity,
		   [RequestType].[Type] as RequestType, [Prices].[Minimum] as Minimum, [Prices].[From1To4Pallets] as From1To4Pallets,
		   [Prices].[From5To8Pallets] as From5To8Pallets, [Prices].[From9To12Pallets] as From9To12Pallets,
		   [Prices].[From13To16Pallets] as From13To16Pallets, [Prices].[From17To20Pallets] as From17To20Pallets,
		   [Prices].[From21To24Pallets] as From21To24Pallets, [Prices].[From25To28Pallets] as From25To28Pallets,
		   [Prices].[From29To32Pallets] as From29To32Pallets, [Prices].[From33To36Pallets] as From33To36Pallets,
		   [Prices].[From37To40Pallets] as From37To40Pallets, [Prices].[From41To44Pallets] as From41To44Pallets,
		   [Prices].[From45To48Pallets] as From45To48Pallets, [Prices].[From49To52Pallets] as From49To52Pallets,
		   [Prices].[From53To56Pallets] as From53To56Pallets, [Prices].[From57To60Pallets] as From57To60Pallets,
		   [Prices].[From61To64Pallets] as From61To64Pallets, [Prices].[Maximum] as Maximum,
		   [Prices].[ShipmentFrequencyLTL] as ShipmentFrequencyLTL, [Prices].[TransitTimeGroupage] as TransitTimeGroupage,
		   [Prices].[TransitTimeLTL] as TransitTimeLTL, [Prices].[CommentsLTL] as CommentsLTL,
		   [Prices].[Tons3_5] as Tons3_5, [Prices].[TransitTime3_5Tons] as TransitTime3_5Tons,
		   [Prices].[ShipmentFrequency3_5Tons] as ShipmentFrequency3_5Tons, [Prices].[Tons7_5] as Tons7_5,
		   [Prices].[ShipmentFrequency7_5Tons] as ShipmentFrequency7_5Tons, [Prices].[Tons24] as Tons24,
		   [Prices].[ShipmentFrequency24Tons] as ShipmentFrequency24Tons, [Prices].[TransitTimeFTL] as TransitTimeFTL,
		   [Prices].[CommentsFTL] as CommentsFTL
	from dbo.[Prices]
	join dbo.[Transporters] on [Prices].[Id_Transporter] = [Transporters].[Id]
	join dbo.[Countries] as OriginCountry on [Prices].[Id_OriginCountry] = [OriginCountry].[Id]
	join dbo.[Cities] as OriginCity on [Prices].[Id_OriginCity] = [OriginCity].[Id]
	join dbo.[Countries] as DestinationCountry on [Prices].[Id_DestinationCountry] = [DestinationCountry].[Id]
	join dbo.[Cities] as DestinationCity on [Prices].[Id_DestinationCity] = [DestinationCity].[Id]
	join dbo.[RequestTypes] as RequestType on [Prices].[Id_RequestType] = [RequestType].[Id]
	where [Prices].[Active] = 1

end