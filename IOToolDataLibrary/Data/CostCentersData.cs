using IOToolDataLibrary.Db;
using IOToolDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public class CostCentersData : ICostCentersData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public CostCentersData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<CostCentersModel>> GetAllCostCenters()
        {
            return _dataAccess.LoadData<CostCentersModel, dynamic>("dbo.spCostCenters_All",
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }
    }
}
