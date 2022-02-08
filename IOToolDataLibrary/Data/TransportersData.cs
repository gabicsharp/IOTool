using Dapper;
using IOToolDataLibrary.Db;
using IOToolDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public class TransportersData : ITransportersData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public TransportersData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<TransportersModel>> GetAllTransporters()
        {
            return _dataAccess.LoadData<TransportersModel, dynamic>("dbo.spTransporters_All", new { },
                                                                    _connectionString.SqlConnectionName);
        }
        public Task<List<TransportTypesModel>> GetAllTransportTypes()
        {
            return _dataAccess.LoadData<TransportTypesModel, dynamic>("dbo.spTransportTypes_All", new { },
                                                                    _connectionString.SqlConnectionName);
        }

        public Task<List<MaterialsModel>> GetAllMaterials()
        {
            return _dataAccess.LoadData<MaterialsModel, dynamic>("dbo.spMaterials_All", new { },
                                                                    _connectionString.SqlConnectionName);
        }
        public async Task<TransportersModel> GetTransporterById(int transporterId)
        {
            var recs = await _dataAccess.LoadData<TransportersModel, dynamic>("dbo.spTransporters_GetById",
                                                                       new
                                                                       {
                                                                           Id = transporterId
                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }

        public Task<int> InsertTransporter(TransportersModel transporter)
        {
            return _dataAccess.SaveData("dbo.spTransporters_Insert",
                                        new
                                        {
                                            Name = transporter.Name,
                                            Email = transporter.Email,
                                            PhoneNumber = transporter.PhoneNumber,
                                            Id_Country = transporter.Id_Country,
                                            Id_City = transporter.Id_City,
                                            Address = transporter.Address,
                                            Zip = transporter.Zip,
                                            Alias = transporter.Alias,
                                            Active = transporter.Active
                                        },
                                        _connectionString.SqlConnectionName);
        }

        public Task<int> UpdateTransporter(TransportersModel transporter)
        {
            return _dataAccess.SaveData("dbo.spTransporters_Update",
                                        transporter,
                                        _connectionString.SqlConnectionName);
        }

        public Task<int> DeleteTransporter(int transporterId)
        {
            return _dataAccess.SaveData("dbo.spTransporters_Delete",
                                        new
                                        {
                                            Id = transporterId
                                        },
                                        _connectionString.SqlConnectionName);
        }

    }
}
