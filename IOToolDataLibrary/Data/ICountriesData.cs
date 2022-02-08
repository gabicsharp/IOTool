using IOToolDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public interface ICountriesData
    {
        Task<int> DeleteCountry(int supplierId);
        Task<List<CountriesModel>> GetAllCountries();
        Task<CountriesModel> GetCountryById(int Id_Supplier);
    }
}