using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.CustomTables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public interface IPricesData
    {

        Task<List<NewPriceModel>> GetAllPricesSummary();
        Task<List<NewCountryCityHomeModel>> GetCountryAndCityHome();
        Task<NewPriceModel> GetPriceById(int priceId);
        Task<NewPriceModel> GetPriceByIdToEdit(int Id);
        Task<PricesModel> GetPriceByIdStandardModel(int Id_OriginCity, int Id_DestinationCity);
        Task<int> InsertPrice(PricesModel price);
        Task<int> UpdatePrice(NewPriceModel price);
        Task<int> DeletePrice(int priceId);
    }
}