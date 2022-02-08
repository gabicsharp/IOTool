using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.CustomTables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public interface ISuppliersData
    {
        Task<int> DeleteSupplier(int supplierId);
        Task<List<NewSupplierModel>> GetAllSuppliers();
        Task<List<NewSupplierModel>> GetJustHomeSupplier();
        Task<NewSupplierModel> GetSupplierById(int Id_Supplier);
        Task<SuppliersModel> GetSupplierByIdWithIds(int Id_Supplier);
        Task<List<NewSupplierModel>> GetSuppliersWithoutHome();
        Task<int> InsertSupplier(SuppliersModel supplier);
        Task<int> UpdateSupplier(SuppliersModel supplier);
    }
}