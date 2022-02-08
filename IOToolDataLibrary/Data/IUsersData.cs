using IOToolDataLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Data
{
    public interface IUsersData
    {
        Task<List<UsersModel>> GetAllUserByWA(string windowsAccount);
        Task<List<UsersModel>> GetAllUsers();
        Task<UsersModel> GetUserByWA(string WindowsAccount);
    }
}