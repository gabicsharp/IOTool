using IOToolDataLibrary.Data;
using IOToolDataLibrary.Models;
using IOToolDataLibrary.Models.EmailModels;
using IOToolEmailNotification.EmailTemplates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOToolEmailNotification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
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

        public EmailsController(ICountriesData countriesData, ICitiesData citiesData, IRequestTypesData requestTypesData,
                                  ISuppliersData suppliersData, IRequestsData requestsData, IUsersData userData,
                                  IRequestInfoData requestInfoData, IEmailsToSendData emailToSendData,
                                   IEmailGroupsData emailgroupData, ISmtpData smtpData, IPricesData priceData)
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
        }

        [HttpGet]
        public ActionResult SendEmail(EmailApiModel email)
        {
            Create create = new Create();
            SmtpModel smtp = new SmtpModel();
            EmailGroupsModel emailGroup = new EmailGroupsModel();
            EmailCreateModel emailCreate = new EmailCreateModel();
            if (email.Action == "Create")
            {
                create.CreateEmail(smtp, emailGroup, emailCreate);
            }
            else if (email.Action == "UpdateByRequester")
            {

            }
            else if (email.Action == "DeleteByRequester")
            {

            }
            else if (email.Action == "UpdateByProcessor")
            {

            }
            else if (email.Action == "DeleteByProcessor")
            {

            }

            return Ok();
        }
    }
}
