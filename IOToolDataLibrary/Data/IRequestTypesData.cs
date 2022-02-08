using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.CustomTables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public interface IRequestTypesData
    {
        Task<List<RequestTypesModel>> GetAllRequestTypes();
        Task<RequestTypesModel> GetRequestTypeById(int requestTypesId);
    }
}