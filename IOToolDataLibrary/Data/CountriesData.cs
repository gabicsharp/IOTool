using IOToolDataLibrary.Db;
using IOToolDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public class CountriesData : ICountriesData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public CountriesData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<CountriesModel>> GetAllCountries()
        {
            return _dataAccess.LoadData<CountriesModel, dynamic>("dbo.spCountries_All", new { },
                                                                    _connectionString.SqlConnectionName);
        }

        public async Task<CountriesModel> GetCountryById(int Id_Supplier)
        {
            var recs = await _dataAccess.LoadData<CountriesModel, dynamic>("dbo.spCountries_GetById",
                                                                       new
                                                                       {
                                                                           Id = Id_Supplier
                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }


        public Task<int> DeleteCountry(int supplierId)
        {
            return _dataAccess.SaveData("dbo.spCountries_Delete",
                                        new
                                        {
                                            Id = supplierId
                                        },
                                        _connectionString.SqlConnectionName);
        }
    }
}
