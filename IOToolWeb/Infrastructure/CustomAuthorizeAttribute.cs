using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOToolWeb.Infrastructure
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContext httpContext)
        {
            bool authorize = false;
            var userAccount = Convert.ToString(httpContext.Session["Account"]);
            if (!string.IsNullOrEmpty(userAccount))
                //using (var context = new DBConnectionDataContext())
                //{
                //    var userRole = (from ui in context.Users_Informations
                //                    join ur in context.Users_Rights on ui.ID_TypeAccount equals ur.ID
                //                    join ul in context.Users_Logins on ui.ID_UserLogin equals ul.ID
                //                    where ul.Account == userAccount
                //                    select new
                //                    {
                //                        ur.Type
                //                    }).FirstOrDefault();
                //    foreach (var role in allowedroles)
                //    {
                //        if (role == userRole.Type) return true;
                //    }
                //}

            return authorize;
        }

        protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Home" },
                    { "action", "xxxx" }
               });
        }
    }
}
