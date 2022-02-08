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
    public class CitiesData : ICitiesData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public CitiesData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<CitiesModel>> GetAllCities()
        {
            return _dataAccess.LoadData<CitiesModel, dynamic>("dbo.spCities_All",
                                                              new { },
                                                              _connectionString.SqlConnectionName);
        }

        public Task<List<NewCityModel>> GetAllCitiesWithCountries()
        {
            return _dataAccess.LoadData<NewCityModel, dynamic>("dbo.spCities_AllWithCountries",
                                                              new { },
                                                              _connectionString.SqlConnectionName);
        }

        public Task<List<CitiesModel>> GetAllCitiesOfACountry(int Id_Country)
        {
            return _dataAccess.LoadData<CitiesModel, dynamic>("dbo.spCities_AllForACountry",
                                                              new
                                                              {
                                                                  Id_Country = Id_Country
                                                              },
                                                              _connectionString.SqlConnectionName);
        }

        public Task<List<CitiesModel>> GetCityById(int Id1, int Id2)
        {
            return _dataAccess.LoadData<CitiesModel, dynamic>("dbo.spCities_GetById",
                                                              new
                                                              {
                                                                  Id1 = Id1,
                                                                  Id2 = Id2

                                                              },
                                                              _connectionString.SqlConnectionName);
        }
    }
}
