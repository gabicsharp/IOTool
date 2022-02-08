using IOToolDataLibrary.Db;
using IOToolDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public class AdGroupsData : IAdGroupsData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public AdGroupsData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<AdGroupsModel>> GetAllGroups()
        {
            return _dataAccess.LoadData<AdGroupsModel, dynamic>("dbo.spAdGroups_All",
                                                             new { },
                                                             _connectionString.SqlConnectionName);
        }
    }
}
