using IOToolDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public interface ITransportersData
    {
        Task<int> DeleteTransporter(int transporterId);
        Task<List<TransportersModel>> GetAllTransporters();
        Task<List<TransportTypesModel>> GetAllTransportTypes();
        Task<List<MaterialsModel>> GetAllMaterials();
        Task<TransportersModel> GetTransporterById(int transporterId);
        Task<int> InsertTransporter(TransportersModel transporter);
        Task<int> UpdateTransporter(TransportersModel transporter);
    }
}