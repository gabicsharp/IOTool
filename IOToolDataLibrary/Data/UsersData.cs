using IOToolDataLibrary.Db;
using IOToolDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public class UsersData : IUsersData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public UsersData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<UsersModel>> GetAllUsers()
        {
            return _dataAccess.LoadData<UsersModel, dynamic>("dbo.spUsers_All",
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }

        public Task<List<UsersModel>> GetAllUserByWA(string windowsAccount)
        {
            return _dataAccess.LoadData<UsersModel, dynamic>("dbo.spUsers_GetByWA",
                                                             new
                                                             {
                                                                 WindowsAccount = windowsAccount
                                                             },
                                                             _connectionString.SqlConnectionName);
        }

        public async Task<UsersModel> GetUserByWA(string WindowsAccount)
        {
            var recs = await _dataAccess.LoadData<UsersModel, dynamic>("dbo.spUsers_GetByWA", new { WindowsAccount = WindowsAccount },
                                                                   _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }
    }
}
