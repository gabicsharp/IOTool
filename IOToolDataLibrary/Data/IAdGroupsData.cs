using IOToolDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public interface IAdGroupsData
    {
        Task<List<AdGroupsModel>> GetAllGroups();
    }
}