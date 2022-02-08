using Dapper;
using IOToolDataLibrary.Db;
using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.EmailModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public class EmailsToSendData : IEmailsToSendData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public EmailsToSendData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<int> InsertEmail(EmailsToSendModel email)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("From", email.From);
            p.Add("To", email.To);
            p.Add("Body", email.Body);
            p.Add("Flag", email.Flag);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spRequests_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public async Task<EmailCreateModel> GetRequestToSendCreateEmail(int Id)
        {
            var recs = await _dataAccess.LoadData<EmailCreateModel, dynamic>("dbo.spEmailNotification_CreateEmail", new { Id = Id },
                                                                   _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }
        public async Task<EmailUpdateModel> GetRequestToSendUpdateEmail(int Id)
        {
            var recs = await _dataAccess.LoadData<EmailUpdateModel, dynamic>("dbo.spEmailNotification_UpdateEmail", new { Id = Id },
                                                                   _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }
        public async Task<EmailDeleteModel> GetRequestToSendDeleteEmailRequester(int Id)
        {
            var recs = await _dataAccess.LoadData<EmailDeleteModel, dynamic>("dbo.spEmailNotification_DeleteEmailRequester", new { Id = Id },
                                                                   _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }

        public async Task<EmailDeleteModel> GetRequestToSendDeleteEmailProcessor(int Id)
        {
            var recs = await _dataAccess.LoadData<EmailDeleteModel, dynamic>("dbo.spEmailNotification_DeleteEmailProcessor", new { Id = Id },
                                                                   _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }
    }
}
