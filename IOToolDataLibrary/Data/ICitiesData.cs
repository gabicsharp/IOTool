using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.CustomTables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public interface ICitiesData
    {
        Task<List<CitiesModel>> GetAllCities();
        Task<List<CitiesModel>> GetAllCitiesOfACountry(int Id_Country);
        Task<List<NewCityModel>> GetAllCitiesWithCountries();
        Task<List<CitiesModel>> GetCityById(int Id1, int Id2);
    }
}