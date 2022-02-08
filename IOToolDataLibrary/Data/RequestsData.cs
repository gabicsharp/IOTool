using Dapper;
using IOToolDataLibrary.Db;
using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.CustomTables;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public class RequestsData : IRequestsData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public RequestsData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<NewMyRequestSummaryModel>> GetMyRequests(string WindowsAccount)
        {
            return _dataAccess.LoadData<NewMyRequestSummaryModel, dynamic>("dbo.spRequests_GetByUser", new { WindowsAccount = WindowsAccount },
                                                                    _connectionString.SqlConnectionName);
        }

        public Task<List<NewWorkRequestModel>> GetNotClosedRequests()
        {
            return _dataAccess.LoadData<NewWorkRequestModel, dynamic>("dbo.spRequests_StatusWork", new { },
                                                                    _connectionString.SqlConnectionName);
        }

        public Task<List<NewRequestClosedModel>> GetDashboard()
        {
            return _dataAccess.LoadData<NewRequestClosedModel, dynamic>("dbo.spRequests_GetDashboard", new { },
                                                                    _connectionString.SqlConnectionName);
        }

        public Task<List<NewWorkRequestModel>> GetRequestById(int Id)
        {
            return _dataAccess.LoadData<NewWorkRequestModel, dynamic>("dbo.spRequests_GetById", new { Id = Id },
                                                                    _connectionString.SqlConnectionName);
        }

        public async Task<NewRequestEditModel> GetRequestByIdToEditProcessor(int Id)
        {
            var recs = await _dataAccess.LoadData<NewRequestEditModel, dynamic>("dbo.spRequests_GetByIdToEdit", new { Id = Id },
                                                                   _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }

        public async Task<NewRequestEditCalculationModel> GetRequestByIdToEditProcessorForCalculation(int Id)
        {
            var recs = await _dataAccess.LoadData<NewRequestEditCalculationModel, dynamic>("dbo.spRequests_GetByIdToEditCalculation", new { Id = Id },
                                                                   _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }

        public async Task<NewMyRequestSummaryModel> GetRequestByIdToSpecificUser(int Id, string WindowsAccount)
        {
            var recs = await _dataAccess.LoadData<NewMyRequestSummaryModel, dynamic>("dbo.spRequests_GetByIdToSpecificUser", new { Id = Id, WindowsAccount = WindowsAccount },
                                                                    _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }

        public async Task<NewWorkRequestDeleteModel> GetRequestByIdToDelete(int Id)
        {
            var recs = await _dataAccess.LoadData<NewWorkRequestDeleteModel, dynamic>("dbo.spRequests_GetByIdToDelete", new { Id = Id },
                                                                    _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }
        public async Task<int> InsertRequest(RequestsModel request)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("Month", request.Month);
            p.Add("Id_RequestType", request.Id_RequestType);
            p.Add("Id_TransportType", request.Id_TransportType);
            p.Add("Week", request.Week);
            p.Add("ETD", request.ETD);
            p.Add("ETA", request.ETA);
            p.Add("Id_SupplierFrom", request.Id_SupplierFrom);
            p.Add("Id_SupplierTo", request.Id_SupplierTo);
            p.Add("Id_Material", request.Id_Material);
            p.Add("Id_Transporter", request.Id_Transporter);
            p.Add("AWB", request.AWB);
            p.Add("Price", request.Price);
            p.Add("Id_CostCenter", request.Id_CostCenter);
            p.Add("BillNr", request.BillNr);
            p.Add("PalletNr", request.PalletNr);
            p.Add("PricePallet", request.PricePallet);
            p.Add("Weight", request.Weight);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spRequests_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }
        public Task<int> UpdateRequestByUser(NewMyRequestSummaryModel request)
        {
            return _dataAccess.SaveData("dbo.spRequests_UpdateByUser",
                                        new
                                        {
                                           Id = request.Id,
                                           ETD = request.ETD,
                                           ETA = request.ETA,
                                           PalletNr = request.PalletNr,
                                           Weight = request.Weight,
                                           CommentRequester = request.CommentRequester
                                        },
                                        _connectionString.SqlConnectionName);
        }
        public Task<int> UpdateRequestByProcessor(NewRequestEditModel request)
        {
            return _dataAccess.SaveData("dbo.spRequests_UpdateByProcessor",
                                        new
                                        {
                                            Id = request.Id,
                                            Id_Transporter = request.Id_Transporter,
                                            Id_TransportType = request.Id_TransportType,
                                            Id_Material = request.Id_Material,
                                            AWB = request.AWB,
                                            BillNr = request.BillNr,
                                            Price = request.Price,
                                            PremiumFreight = request.PremiumFreight,
                                            Id_CostCenter = request.Id_CostCenter,
                                            CommentProcessor = request.CommentProcessor,
                                            Id_RequestStatus = request.Id_RequestStatus,
                                            Id_Processor = request.Id_Processor
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public Task<int> DeleteRequestByRequester(int Id, string CommentRequesterForClose)
        {
            return _dataAccess.SaveData("dbo.spRequests_DeleteByRequester",
                                        new
                                        {
                                            Id = Id,
                                            CommentRequesterForClose = CommentRequesterForClose
                                        },
                                        _connectionString.SqlConnectionName);
        }
        public Task<int> DeleteRequestByProcessor(int Id, string CommentProcessorForClose)
        {
            return _dataAccess.SaveData("dbo.spRequests_DeleteByProcessor",
                                        new
                                        {
                                            Id = Id,
                                            CommentProcessorForClose = CommentProcessorForClose
                                        },
                                        _connectionString.SqlConnectionName);
        }


    }
}