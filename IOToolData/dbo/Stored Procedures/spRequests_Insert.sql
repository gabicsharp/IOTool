CREATE PROCEDURE [dbo].[spRequests_Insert]
	@Month nvarchar(50),
	@Id_RequestType int,
	@Id_TransportType int,
	@Week int,
	@ETD datetime2(7),
	@ETA datetime2(7),
	@Id_SupplierFrom int,
	@Id_SupplierTo int,
	@Id_Material int,
	@Id_Transporter int,
	@AWB nvarchar(50),
	@Price money,
	@Id_CostCenter int,
	@BillNr nvarchar(50),
	@PalletNr int,
	@PricePallet money,
	@Weight int,
	@Id int output
AS
begin

	set nocount on;

	insert into dbo.[Requests]([Month], Id_RequestType, Id_TransportType, [Week], ETD, ETA, Id_SupplierFrom, Id_SupplierTo, Id_Material,
							   Id_Transporter, AWB, Price, Id_CostCenter, BillNr, PalletNr, PricePallet, [Weight])
	values(@Month, @Id_RequestType, @Id_TransportType, @Week, @ETD, @ETA, @Id_SupplierFrom, @Id_SupplierTo, @Id_Material,
		   @Id_Transporter, @AWB, @Price, @Id_CostCenter, @BillNr, @PalletNr, @PricePallet, @Weight);
	
	set @Id = SCOPE_IDENTITY();
end