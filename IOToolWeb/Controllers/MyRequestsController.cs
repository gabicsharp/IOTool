using IOToolDataLibrary.Data;
using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.CustomTables;
using IOToolDataLibrary.Models.EmailModels;
using IOToolWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IOToolWeb.Controllers
{
    [Authorize(Roles = "Level1, Level2, Level3, Level4, Level5")]
    public class MyRequestsController : Controller
    {
        private readonly ICountriesData _countriesData;
        private readonly ICitiesData _citiesData;
        private readonly IRequestTypesData _requestTypesData;
        private readonly ISuppliersData _suppliersData;
        private readonly IRequestsData _requestsData;
        private readonly IRequestInfoData _requestInfoData;
        private readonly IUsersData _userData;
        private readonly IEmailsToSendData _emailToSendData;
        private readonly IEmailGroupsData _emailgroupData;
        private readonly ISmtpData _smtpData;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MyRequestsController(ICountriesData countriesData, ICitiesData citiesData, IRequestTypesData requestTypesData,
                                  ISuppliersData suppliersData, IRequestsData requestsData, IUsersData userData,
                                  IRequestInfoData requestInfoData, IEmailsToSendData emailToSendData,
                                   IEmailGroupsData emailgroupData, ISmtpData smtpData,
                                   IHttpContextAccessor httpContextAccessor)
        {
            _countriesData = countriesData;
            _citiesData = citiesData;
            _requestTypesData = requestTypesData;
            _suppliersData = suppliersData;
            _requestsData = requestsData;
            _requestInfoData = requestInfoData;
            _userData = userData;
            _emailToSendData = emailToSendData;
            _emailgroupData = emailgroupData;
            _smtpData = smtpData;
            _httpContextAccessor = httpContextAccessor;
        }

       
        public async Task<IActionResult> Index()
        {
            string WindowsAccount = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.WindowsAccountName).Value.ToString();

            var myRequests = await _requestsData.GetMyRequests(WindowsAccount);
            return View(myRequests);
        }

        public async Task<IActionResult> Edit(int id)
        {
            string WindowsAccount = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.WindowsAccountName).Value.ToString();

            var request = await _requestsData.GetRequestByIdToSpecificUser(id, WindowsAccount);
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewMyRequestSummaryModel request)
        {
            if (ModelState.IsValid)
            {
                await _requestsData.UpdateRequestByUser(request);

                SmtpModel smtp = await _smtpData.GetSmtp();
                EmailGroupsModel emailGroup = await _emailgroupData.GetEmailGroup();
                EmailCreateModel requestCreateModel = await _emailToSendData.GetRequestToSendCreateEmail(request.Id);

                Email email = new Email();

                email.UpdateRequesterEmail(smtp, emailGroup, requestCreateModel);

                return RedirectToAction("Index");
            }
            else
            {
                return View(request);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            string WindowsAccount = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.WindowsAccountName).Value.ToString();

            var request = await _requestsData.GetRequestByIdToSpecificUser(id, WindowsAccount);
            request.CommentRequester = "";
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(NewMyRequestSummaryModel request)
        {
            if (ModelState.IsValid)
            {
                await _requestsData.DeleteRequestByRequester(request.Id, request.CommentRequester);

                SmtpModel smtp = await _smtpData.GetSmtp();
                EmailGroupsModel emailGroup = await _emailgroupData.GetEmailGroup();
                EmailDeleteModel requestDeleteModel = await _emailToSendData.GetRequestToSendDeleteEmailRequester(request.Id);
                Email email = new Email();

                email.DeleteRequesterEmail(smtp, emailGroup, requestDeleteModel);

                return RedirectToAction("Index");
            }
            else
            {
                return View(request);
            }
        }
    }
}
