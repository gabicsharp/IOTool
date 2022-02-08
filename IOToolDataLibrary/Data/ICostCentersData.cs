using IOToolDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public interface ICostCentersData
    {
        Task<List<CostCentersModel>> GetAllCostCenters();
    }
}