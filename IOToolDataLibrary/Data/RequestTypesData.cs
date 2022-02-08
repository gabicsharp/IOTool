using IOToolDataLibrary.Db;
using IOToolDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public class RequestTypesData : IRequestTypesData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public RequestTypesData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<RequestTypesModel>> GetAllRequestTypes()
        {
            return _dataAccess.LoadData<RequestTypesModel, dynamic>("dbo.spRequestTypes_All", new { },
                                                                    _connectionString.SqlConnectionName);
        }

        public async Task<RequestTypesModel> GetRequestTypeById(int requestTypesId)
        {
            var recs = await _dataAccess.LoadData<RequestTypesModel, dynamic>("dbo.spRequestTypes_GetById",
                                                                       new
                                                                       {
                                                                           Id = requestTypesId
                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }
    }
}
