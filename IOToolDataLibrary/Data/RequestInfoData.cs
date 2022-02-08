using Dapper;
using IOToolDataLibrary.Db;
using IOToolDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public class RequestInfoData : IRequestInfoData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public RequestInfoData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<int> InsertRequestInfo(RequestsInfoModel request)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("Id_Request", request.Id_Request);
            p.Add("Id_Requester", request.Id_Requester);
            p.Add("Id_Processor", request.Id_Processor);
            p.Add("IntervalHoursToPickUp", request.IntervalHoursToPickUp);
            p.Add("CommentRequester", request.CommentRequester);
            p.Add("CommentProcessor", request.CommentProcessor);
            p.Add("CommentRequesterForClose", request.CommentRequesterForClose);
            p.Add("CommentProcessorForClose", request.CommentProcessorForClose);
            p.Add("Id_RequestStatus", request.Id_RequestStatus);
            p.Add("PremiumFreight", request.PremiumFreight);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spRequestInfo_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }
    }
}
