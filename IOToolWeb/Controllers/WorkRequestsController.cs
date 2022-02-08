using IOToolDataLibrary.Data;
using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.CustomTables;
using IOToolDataLibrary.Models.EmailModels;
using IOToolWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static IOToolWeb.Models.RequestEditProcessorModel;

namespace IOToolWeb.Controllers
{
    [Authorize(Roles = "Level2, Level5")]
    public class WorkRequestsController : Controller
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
        private readonly ITransportersData _transporterData;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WorkRequestsController(ICountriesData countriesData, ICitiesData citiesData, IRequestTypesData requestTypesData,
                                  ISuppliersData suppliersData, IRequestsData requestsData, IUsersData userData,
                                  IRequestInfoData requestInfoData, IEmailsToSendData emailToSendData,
                                  IEmailGroupsData emailgroupData, ISmtpData smtpData, IPricesData priceData,
                                  ITransportersData transporterData, IHttpContextAccessor httpContextAccessor)
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
            _transporterData = transporterData;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<IActionResult> Index()
        {
            var notClosedRequests = await _requestsData.GetNotClosedRequests();
            return View(notClosedRequests);
        }

        public async Task<IActionResult> Dashboard()
        {
            var requests = await _requestsData.GetDashboard();

            return View(requests);
        }

        public async Task<IActionResult> Edit(int id)
        {
            //ViewModel mymodel = new ViewModel();
            //mymodel.RequestDetails = await _requestsData.GetRequestByIdToEditProcessor(id);
            //mymodel.Transporters = await _transporterData.GetAllTransporters();
            //mymodel.TransportTypes = await _transporterData.GetAllTransportTypes();
            //mymodel.Materials = await _transporterData.GetAllMaterials();
            //return View(mymodel);
            StringBuilder sb = new StringBuilder();
            try
            {
                var request = await _requestsData.GetRequestByIdToEditProcessor(id);
                if (request.AWB == "empty")
                {
                    request.AWB = "";
                }
                if (request.BillNr == "empty")
                {
                    request.BillNr = "";
                }
                if (request.CommentProcessor == "empty")
                {
                    request.CommentProcessor = "";
                }
                return View(request);
            }
            catch (Exception exp)
            {
                sb.Append(exp.ToString()  + DateTime.Now.ToString());
                System.IO.File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\logs.txt", sb.ToString() + Environment.NewLine);
                sb.Clear();
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(NewRequestEditModel request)
        //{
        //    //Thread.Sleep(5000);
        //    OS os = new OS();
        //    bool IsServer = os.IsWindowsServer();
        //    string WindowsAccount = "";
        //    int status = 1;
        //    if (IsServer == false)
        //    {
        //        WindowsAccount = System.Environment.UserName;
        //    }
        //    else if (IsServer == true)
        //    {
        //        string userName = HttpContext.User.Identity.Name.ToString();
        //        string[] WindowsAccountArray = userName.Split(@"\");
        //        WindowsAccount = WindowsAccountArray[1];
        //    }

        //    if (request.AWB == null)
        //    {
        //        request.AWB = "empty";
        //    }
        //    if (request.BillNr == null)
        //    {
        //        request.BillNr = "empty";
        //    }
        //    if (request.CommentProcessor == null)
        //    {
        //        request.CommentProcessor = "empty";
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        if (request.Status == "Open")
        //        {

        //        }
        //        if (request.AWB != "empty")
        //        {
        //            status = 2;
        //        }
        //        if (request.CommentProcessor == "empty")
        //        {
        //            status = 2;
        //        }
        //        if (request.BillNr == "empty")
        //        {
        //            status = 3;
        //        }

        //        //await _transporterData.UpdateTransporter(transporter);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        //return View(request.RequestDetails.Id);// View(request);
        //        return View(request);
        //    }
        // }

        public async Task<IActionResult> Delete(int id)
        {
            var request = await _requestsData.GetRequestByIdToDelete(id);

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(NewWorkRequestDeleteModel request)
        {
            if (ModelState.IsValid)
            {
                await _requestsData.DeleteRequestByProcessor(request.Id, request.Comment);

                SmtpModel smtp = await _smtpData.GetSmtp();
                EmailGroupsModel emailGroup = await _emailgroupData.GetEmailGroup();
                EmailDeleteModel requestDeleteModel = await _emailToSendData.GetRequestToSendDeleteEmailProcessor(request.Id);

                Email email = new Email();

                email.DeleteProcessorEmail(smtp, emailGroup, requestDeleteModel);
            }
            else
            {
                return View(request);
            }

            return RedirectToAction("Index");
        }

        public async Task<JsonResult> Calculate(string requestType, string from, string to, string etd, string eta, string nrPallets, string weight)
        {
            int id_requestType = 0, id_from = 0, id_to = 0, numberPallets = 0, weightKg = 0;
            Int32.TryParse(requestType, out id_requestType);
            Int32.TryParse(from, out id_from);
            Int32.TryParse(to, out id_to);
            Int32.TryParse(nrPallets, out numberPallets);
            Int32.TryParse(weight, out weightKg);
            bool isPF = false;

            string Message = "No price was registered for this route. You will receive an estimated price after logistic team will process your request.";

            SuppliersModel sm1 = await _suppliersData.GetSupplierByIdWithIds(id_from);
            SuppliersModel sm2 = await _suppliersData.GetSupplierByIdWithIds(id_to);

            PricesModel price = await _priceData.GetPriceByIdStandardModel(sm1.Id_City, sm2.Id_City);

            if (price != null)
            {
                if (numberPallets <= 64)
                {
                    var pricePallet = CalculatePricePerPallet(numberPallets, price);
                    decimal pricePerPallet = Convert.ToDecimal(pricePallet.Result);
                    double transitTime = ((double)price.TransitTimeGroupage / (double)24);
                    // transitTime = transitTime.toFixed(2);

                    decimal priceCalculated = pricePerPallet * numberPallets;
                    DateTime dt_etd = DateTime.Parse(etd, System.Globalization.CultureInfo.InvariantCulture);
                    DateTime dt_eta = DateTime.Parse(eta, System.Globalization.CultureInfo.InvariantCulture);
                    // TimeSpan ts = dt_eta.Subtract(dt_etd);
                    var span = dt_eta.Subtract(dt_etd);
                    double daysSelected = span.Days;

                    if (daysSelected > 0)
                    {
                        if (transitTime >= daysSelected)
                        {
                            Message = $"For this route, your transit time is NOT standard and price can't be calculated. " +
                                $"This request will be mark as PREMIUM FREIGHT !";
                            isPF = true;
                        }
                        else if (transitTime < daysSelected)
                        {
                            Message = $"For this route, the standard time for transport is {transitTime.ToString("0.00")} days and ~ price = {priceCalculated.ToString("0.00")} (€)";
                        }
                    }
                    else
                    {
                        Message = $"";
                    }


                }
            }
            var result = new { Message = Message, isPF = isPF };
            return Json(result);
        }

        public async Task<decimal> CalculatePricePerPallet(int nrPallets, PricesModel price)
        {
            decimal pricePallet = 0;

            if (nrPallets >= 1 && nrPallets <= 4)
            {
                pricePallet = price.From1To4Pallets;
            }
            else if (nrPallets >= 5 && nrPallets <= 8)
            {
                pricePallet = price.From5To8Pallets;
            }
            else if (nrPallets >= 9 && nrPallets <= 12)
            {
                pricePallet = price.From9To12Pallets;
            }
            else if (nrPallets >= 13 && nrPallets <= 16)
            {
                pricePallet = price.From13To16Pallets;
            }
            else if (nrPallets >= 17 && nrPallets <= 20)
            {
                pricePallet = price.From17To20Pallets;
            }
            else if (nrPallets >= 21 && nrPallets <= 24)
            {
                pricePallet = price.From21To24Pallets;
            }
            else if (nrPallets >= 25 && nrPallets <= 28)
            {
                pricePallet = price.From25To28Pallets;
            }
            else if (nrPallets >= 29 && nrPallets <= 32)
            {
                pricePallet = price.From29To32Pallets;
            }
            else if (nrPallets >= 33 && nrPallets <= 36)
            {
                pricePallet = price.From33To36Pallets;
            }
            else if (nrPallets >= 37 && nrPallets <= 40)
            {
                pricePallet = price.From37To40Pallets;
            }
            else if (nrPallets >= 41 && nrPallets <= 44)
            {
                pricePallet = price.From41To44Pallets;
            }
            else if (nrPallets >= 45 && nrPallets <= 48)
            {
                pricePallet = price.From45To48Pallets;
            }
            else if (nrPallets >= 49 && nrPallets <= 52)
            {
                pricePallet = price.From49To52Pallets;
            }
            else if (nrPallets >= 53 && nrPallets <= 56)
            {
                pricePallet = price.From53To56Pallets;
            }
            else if (nrPallets >= 57 && nrPallets <= 60)
            {
                pricePallet = price.From57To60Pallets;
            }
            else if (nrPallets >= 61 && nrPallets <= 64)
            {
                pricePallet = price.From61To64Pallets;
            }

            return pricePallet;
        }

        public async Task<JsonResult> SubmitUpdate(NewRequestEditModel request)
        {
            string WindowsAccount = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.WindowsAccountName).Value.ToString();

            string message = "";
            string actionName = "";
            string controllerName = "";
            
            if (request.AWB == null)
            {
                request.AWB = "empty";
            }
            if (request.BillNr == null)
            {
                request.BillNr = "empty";
            }
            if (request.CommentProcessor == null)
            {
                request.CommentProcessor = "empty";
            }

            //if (ModelState.IsValid)
            //{
            if (request.Id_RequestStatus == 1)
            {
                request.Id_RequestStatus = 2;
            }
            if (request.AWB != "empty")
            {
                request.Id_RequestStatus = 3;

            }
            if (request.BillNr != "empty")
            {
                request.Id_RequestStatus = 4;
            }

            UsersModel userModel = await _userData.GetUserByWA(WindowsAccount);

            request.Id_Processor = userModel.Id;

            await _requestsData.UpdateRequestByProcessor(request);

            SmtpModel smtp = await _smtpData.GetSmtp();
            EmailGroupsModel emailGroup = await _emailgroupData.GetEmailGroup();
            EmailUpdateModel requestUpdateModel = await _emailToSendData.GetRequestToSendUpdateEmail(request.Id);

            Email email = new Email();

            email.UpdateProcessorEmail(smtp, emailGroup, requestUpdateModel);

            actionName = "Index";
            controllerName = "WorkRequests";
            // return RedirectToAction("Index");
            //}
            //else
            //{
            //    message = "Something went wrong...";
            //    //return View(request.RequestDetails.Id);// View(request);
            //   // return View(request);
            //}
            var result = new { message = message, actionName = actionName, controllerName = controllerName };
            return Json(result);
        }

    }
}
