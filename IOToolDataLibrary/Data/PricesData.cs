using IOToolDataLibrary.Db;
using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.CustomTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public class PricesData : IPricesData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public PricesData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<NewPriceModel>> GetAllPricesSummary()
        {
            return _dataAccess.LoadData<NewPriceModel, dynamic>("dbo.spPrices_AllSummary",
                                                             new { },
                                                             _connectionString.SqlConnectionName);
        }

        public async Task<NewPriceModel> GetPriceById(int priceId)
        {
            var recs = await _dataAccess.LoadData<NewPriceModel, dynamic>("dbo.spPrices_GetById",
                                                                       new
                                                                       {
                                                                           Id = priceId
                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }
        public async Task<NewPriceModel> GetPriceByIdToEdit(int Id)
        {
            var recs = await _dataAccess.LoadData<NewPriceModel, dynamic>("dbo.spPrices_GetByIdToEdit",
                                                                       new
                                                                       {
                                                                           Id = Id
                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }

        public async Task<PricesModel> GetPriceByIdStandardModel(int Id_OriginCity, int Id_DestinationCity)
        {
            var recs = await _dataAccess.LoadData<PricesModel, dynamic>("dbo.spPrices_GetByIdStandardModel",
                                                                       new
                                                                       {
                                                                           Id_OriginCity = Id_OriginCity,
                                                                           Id_DestinationCity = Id_DestinationCity

                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }

        public Task<List<NewCountryCityHomeModel>> GetCountryAndCityHome()
        {
            return _dataAccess.LoadData<NewCountryCityHomeModel, dynamic>("dbo.spPrices_CountryAndCityHome",
                                                                       new { },
                                                                       _connectionString.SqlConnectionName);
        }

        public Task<int> InsertPrice(PricesModel price)
        {
            return _dataAccess.SaveData("dbo.spPrices_Insert",
                                        new
                                        {
                                            Id_Transporter = price.Id_Transporter,
                                            LaneName = price.LaneName,
                                            Id_OriginCountry = price.Id_OriginCountry,
                                            Id_OriginCity = price.Id_OriginCity,
                                            Id_OriginZip = price.Id_OriginZip,
                                            Id_DestinationCountry = price.Id_DestinationCountry,
                                            Id_DestinationCity = price.Id_DestinationCity,
                                            Id_DestinationZip = price.Id_DestinationZip,
                                            Id_RequestType = price.Id_RequestType,
                                            Id_PartnerLocation = price.Id_PartnerLocation,
                                            Minimum = price.Minimum,
                                            From1To4Pallets = price.From1To4Pallets,
                                            From5To8Pallets = price.From5To8Pallets,
                                            From9To12Pallets = price.From9To12Pallets,
                                            From13To16Pallets = price.From13To16Pallets,
                                            From17To20Pallets = price.From17To20Pallets,
                                            From21To24Pallets = price.From21To24Pallets,
                                            From25To28Pallets = price.From25To28Pallets,
                                            From29To32Pallets = price.From29To32Pallets,
                                            From33To36Pallets = price.From33To36Pallets,
                                            From37To40Pallets = price.From37To40Pallets,
                                            From41To44Pallets = price.From41To44Pallets,
                                            From45To48Pallets = price.From45To48Pallets,
                                            From49To52Pallets = price.From49To52Pallets,
                                            From53To56Pallets = price.From53To56Pallets,
                                            From57To60Pallets = price.From57To60Pallets,
                                            From61To64Pallets = price.From61To64Pallets,
                                            Maximum = price.Maximum,
                                            ShipmentFrequencyLTL = price.ShipmentFrequencyLTL,
                                            TransitTimeGroupage = price.TransitTimeGroupage,
                                            TransitTimeLTL = price.TransitTimeLTL,
                                            CommentsLTL = price.CommentsLTL,
                                            Tons3_5 = price.Tons3_5,
                                            TransitTime3_5Tons = price.TransitTime3_5Tons,
                                            ShipmentFrequency3_5Tons = price.ShipmentFrequency3_5Tons,
                                            Tons7_5 = price.Tons7_5,
                                            ShipmentFrequency7_5Tons = price.ShipmentFrequency7_5Tons,
                                            Tons24 = price.Tons24,
                                            ShipmentFrequency24Tons = price.ShipmentFrequency24Tons,
                                            TransitTimeFTL = price.TransitTimeFTL,
                                            CommentsFTL = price.CommentsFTL,
                                            Active = price.Active
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public Task<int> UpdatePrice(NewPriceModel price)
        {
            return _dataAccess.SaveData("dbo.spPrices_Update",
                                        new {
                                            Id = price.Id,
                                            Minimum = price.Minimum,
                                            From1To4Pallets = price.From1To4Pallets,
                                            From5To8Pallets = price.From5To8Pallets,
                                            From9To12Pallets = price.From9To12Pallets,
                                            From13To16Pallets = price.From13To16Pallets,
                                            From17To20Pallets = price.From17To20Pallets,
                                            From21To24Pallets = price.From21To24Pallets,
                                            From25To28Pallets = price.From25To28Pallets,
                                            From29To32Pallets = price.From29To32Pallets,
                                            From33To36Pallets = price.From33To36Pallets,
                                            From37To40Pallets = price.From37To40Pallets,
                                            From41To44Pallets = price.From41To44Pallets,
                                            From45To48Pallets = price.From45To48Pallets,
                                            From49To52Pallets = price.From49To52Pallets,
                                            From53To56Pallets = price.From53To56Pallets,
                                            From57To60Pallets = price.From57To60Pallets,
                                            From61To64Pallets = price.From61To64Pallets,
                                            Maximum = price.Maximum,
                                            ShipmentFrequencyLTL = price.ShipmentFrequencyLTL,
                                            TransitTimeGroupage = price.TransitTimeGroupage,
                                            TransitTimeLTL = price.TransitTimeLTL,
                                            CommentsLTL = price.CommentsLTL,
                                            Tons3_5 = price.Tons3_5,
                                            TransitTime3_5Tons = price.TransitTime3_5Tons,
                                            ShipmentFrequency3_5Tons = price.ShipmentFrequency3_5Tons,
                                            Tons7_5 = price.Tons7_5,
                                            ShipmentFrequency7_5Tons = price.ShipmentFrequency7_5Tons,
                                            Tons24 = price.Tons24,
                                            ShipmentFrequency24Tons = price.ShipmentFrequency24Tons,
                                            TransitTimeFTL = price.TransitTimeFTL,
                                            CommentsFTL = price.CommentsFTL,
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public Task<int> DeletePrice(int priceId)
        {
            return _dataAccess.SaveData("dbo.spPrices_Delete",
                                        new
                                        {
                                            Id = priceId
                                        },
                                        _connectionString.SqlConnectionName);
        }
    }
}
