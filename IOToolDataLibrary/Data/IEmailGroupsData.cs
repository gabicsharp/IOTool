using IOToolDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public interface IEmailGroupsData
    {
        Task<EmailGroupsModel> GetEmailGroup();
    }
}