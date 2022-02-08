using IOToolDataLibrary.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IOToolWeb.Controllers
{
    [Authorize(Roles = "Level5")]
    public class UsersController : Controller
    {
        private readonly IUsersData _userData;

        public UsersController(IUsersData usersData)
        {
            _userData = usersData;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userData.GetAllUsers();
            return View(users);
        }
    }
}
