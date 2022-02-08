using IOToolDataLibrary.Db;
using IOToolDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public class SmtpData : ISmtpData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public SmtpData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<SmtpModel> GetSmtp()
        {
            var recs = await _dataAccess.LoadData<SmtpModel, dynamic>("dbo.spSmtp_Get",
                                                                       new
                                                                       {
                                                                    
                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }
    }
}
