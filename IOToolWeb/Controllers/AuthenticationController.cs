using IOToolDataLibrary.Data;
using IOToolDataLibrary.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium.Edge;
using System;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UAParser;

namespace IOToolWeb.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUsersData _userData;

        public AuthenticationController(IUsersData usersData)
        {
            _userData = usersData;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            //OS os = new OS();
            //bool IsServer = os.IsWindowsServer();

            StringBuilder sb = new StringBuilder();
            var userAgent = HttpContext.Request.Headers["User-Agent"];
            var uaParser = Parser.GetDefault();
            ClientInfo c = uaParser.Parse(userAgent);
            
            string BrowserName = c.UA.ToString();
            string WindowsAccount = "";
            if (BrowserName.Contains("Edge")  || BrowserName.Contains("Opera"))
            {
                try
                {
                    //develop
                    //WindowsAccount = System.Environment.UserName;
                    //production
                    string userName = HttpContext.User.Identity.Name.ToString();
                    string[] WindowsAccountArray = userName.Split(@"\");
                    WindowsAccount = WindowsAccountArray[1];



                    var users = await _userData.GetAllUserByWA(WindowsAccount); 
                    if (users.Count > 0)
                    {
                        UsersModel user = new UsersModel();
                        foreach (var item in users)
                        {
                            user = item;
                            break;
                        }

                        ClaimsIdentity identity = null;
                        bool isAuthenticate = false;

                        if (user != null)
                        {
                            identity = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Name, user.Name),
                            new Claim(ClaimTypes.WindowsAccountName, user.WindowsAccount),
                            new Claim(ClaimTypes.Role, user.AccountRights),
                            new Claim(ClaimTypes.Actor, user.Function)
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
                            isAuthenticate = true;
                        }

                        if (isAuthenticate)
                        {
                            var principal = new ClaimsPrincipal(identity);
                            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        }
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View("~/Views/Shared/ErrorUser.cshtml");
                    }
                }
                catch (Exception exp)
                {
                    sb.Append(exp.ToString() + " " + WindowsAccount);
                    System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\logs.txt", sb.ToString() + Environment.NewLine);
                    sb.Clear();
                    return View("~/Views/Shared/Error.cshtml");
                }
            }
            else
            {
                return View("~/Views/Shared/ErrorBrowser.cshtml");
            }
        }
    }
    class OS
    {
        public bool IsWindowsServer()
        {
            return OS.IsOS(OS.OS_ANYSERVER);
        }

        const int OS_ANYSERVER = 29;

        [DllImport("shlwapi.dll", SetLastError = true, EntryPoint = "#437")]
        private static extern bool IsOS(int os);
    }
}
