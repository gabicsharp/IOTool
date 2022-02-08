using IOToolDataLibrary.Models;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public interface IRequestInfoData
    {
        Task<int> InsertRequestInfo(RequestsInfoModel request);
    }
}