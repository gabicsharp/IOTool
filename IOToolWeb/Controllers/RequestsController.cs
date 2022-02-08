using IOToolDataLibrary.Data;
using IOToolDataLibrary.Models.CustomTables;
using IOToolDataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using IOToolWeb.Models;
using IOToolDataLibrary.Models.EmailModels;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace IOToolWeb.Controllers
{
    [Authorize(Roles = "Level1, Level2, Level3, Level4, Level5")]
    public class RequestsController : Controller
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
        private readonly IPricesData _priceData;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RequestsController(ICountriesData countriesData, ICitiesData citiesData, IRequestTypesData requestTypesData,
                                  ISuppliersData suppliersData, IRequestsData requestsData, IUsersData userData,
                                  IRequestInfoData requestInfoData, IEmailsToSendData emailToSendData,
                                  IEmailGroupsData emailgroupData, ISmtpData smtpData, IPricesData priceData,
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
            _priceData = priceData;
            _httpContextAccessor = httpContextAccessor;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(NewRequestModel request)
        {
            StringBuilder sb = new StringBuilder();
            string WindowsAccount = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.WindowsAccountName).Value.ToString();

            try
            {
                if (request.Price == 0)
                {
                    request.Price = 1;
                }

                if (request.PricePallet == 0)
                {
                    request.PricePallet = 1;
                }
                if (ModelState.IsValid)
                {
                    string month = DateTime.Now.ToString("MMMM").Substring(0, 3);
                    string year = DateTime.Now.Year.ToString();
                    int weekNr = GetWeeksInYear();

                    RequestsModel rm = new RequestsModel
                    {
                        Month = $"{month}-{year}",
                        Id_RequestType = request.RequestTypeId,
                        Id_TransportType = 1,
                        Week = weekNr,
                        ETD = request.ETD,
                        ETA = request.ETA,
                        Id_SupplierFrom = request.FromId,
                        Id_SupplierTo = request.ToId,
                        Id_Material = 1,
                        Id_Transporter = 1,
                        AWB = "empty",
                        Price = request.Price,
                        Id_CostCenter = 1,
                        BillNr = "empty",
                        PalletNr = request.NrPallets,
                        PricePallet = request.PricePallet,
                        Weight = request.Weight
                    };
                    int Id_Request = await _requestsData.InsertRequest(rm);

                    var userList = await _userData.GetAllUserByWA(WindowsAccount);

                    int Id_user = 0;
                    foreach (var item in userList)
                    {
                        Id_user = item.Id;
                        break;
                    }

                    RequestsInfoModel rim = new RequestsInfoModel
                    {
                        Id_Request = Id_Request,
                        Id_Requester = Id_user,
                        Id_Processor = 0,
                        IntervalHoursToPickUp = "empty",
                        CommentRequester = request.CommentRequester,
                        CommentProcessor = "empty",
                        CommentRequesterForClose = "empty",
                        CommentProcessorForClose = "empty",
                        Id_RequestStatus = 1,
                        PremiumFreight = request.PremiumFreight
                    };
                    int Id_RequestInfo = await _requestInfoData.InsertRequestInfo(rim);
                    request.Id = Id_Request;

                    SmtpModel smtp = await _smtpData.GetSmtp();
                    EmailGroupsModel emailGroup = await _emailgroupData.GetEmailGroup();
                    EmailCreateModel requestCreateModel = await _emailToSendData.GetRequestToSendCreateEmail(Id_Request);

                    Email email = new Email();

                    email.CreateEmail(smtp, emailGroup, requestCreateModel);

                    return RedirectToAction("Created", "Requests", request);
                }
                else
                {
                    sb.Append("" + " " + WindowsAccount + " " + DateTime.Now.ToString());
                    System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\logs.txt", sb.ToString() + Environment.NewLine);
                    sb.Clear();
                    return View(request);
                  
                }
            }
            catch (Exception exp)
            {
                sb.Append(exp.ToString() + " " + WindowsAccount + " " + DateTime.Now.ToString());
                System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\logs.txt", sb.ToString() + Environment.NewLine);
                sb.Clear();
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        public IActionResult Created(NewRequestModel request)
        {
            return View(request);
        }
     
        public int GetWeeksInYear()
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = DateTime.Now;
            Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(date1, dfi.CalendarWeekRule,
                                                dfi.FirstDayOfWeek);
        }

    }
}
