using IOToolDataLibrary.Db;
using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.CustomTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public class SuppliersData : ISuppliersData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public SuppliersData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }



        public Task<List<NewSupplierModel>> GetAllSuppliers()
        {
            return _dataAccess.LoadData<NewSupplierModel, dynamic>("dbo.spSuppliers_All",
                                                             new { },
                                                             _connectionString.SqlConnectionName);
        }

        public Task<List<NewSupplierModel>> GetSuppliersWithoutHome()
        {
            return _dataAccess.LoadData<NewSupplierModel, dynamic>("dbo.spSuppliers_AllWithoutHome",
                                                             new { },
                                                             _connectionString.SqlConnectionName);
        }

        public Task<List<NewSupplierModel>> GetJustHomeSupplier()
        {
            return _dataAccess.LoadData<NewSupplierModel, dynamic>("dbo.spSuppliers_JustHome",
                                                             new { },
                                                             _connectionString.SqlConnectionName);
        }

        public async Task<NewSupplierModel> GetSupplierById(int Id_Supplier)
        {
            var recs = await _dataAccess.LoadData<NewSupplierModel, dynamic>("dbo.spSuppliers_GetById",
                                                                       new
                                                                       {
                                                                           Id = Id_Supplier
                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }

        public async Task<SuppliersModel> GetSupplierByIdWithIds(int Id_Supplier)
        {
            var recs = await _dataAccess.LoadData<SuppliersModel, dynamic>("dbo.spSuppliers_GetByIdWithIds",
                                                                       new
                                                                       {
                                                                           Id = Id_Supplier
                                                                       },
                                                                       _connectionString.SqlConnectionName);
            return recs.FirstOrDefault();
        }



        public Task<int> InsertSupplier(SuppliersModel supplier)
        {
            return _dataAccess.SaveData("dbo.spSuppliers_Insert",
                                        new
                                        {
                                            Name = supplier.Name,
                                            Id_Country = supplier.Id_Country,
                                            Id_City = supplier.Id_City,
                                            Address = supplier.Address,
                                            Zip = supplier.Zip,
                                            Active = supplier.Active,
                                            Home = supplier.Home
                                        },
                                        _connectionString.SqlConnectionName);
        }


        public Task<int> UpdateSupplier(SuppliersModel supplier)
        {
            return _dataAccess.SaveData("dbo.spSuppliers_Update",
                                        supplier,
                                        _connectionString.SqlConnectionName);
        }


        public Task<int> DeleteSupplier(int supplierId)
        {
            return _dataAccess.SaveData("dbo.spSuppliers_Delete",
                                        new
                                        {
                                            Id = supplierId
                                        },
                                        _connectionString.SqlConnectionName);
        }


    }
}
