using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IOToolWeb.Infrastructure
{
    public class BasicChallengeActionResult : ActionResult
    {
        #region Properties

        public ActionResult CurrrentResult
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        public override void ExecuteResult(ControllerContext context)
        {
            CurrrentResult.ExecuteResult(context);

            var response = context.HttpContext.Response;

            if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
                response.AddHeader("WWW-Authenticate", "Basic");
        }

        #endregion Methods
    }
}
