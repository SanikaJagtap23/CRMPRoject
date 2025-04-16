using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Webb.custauth
{
    public class Clompanyuserauth : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        { 
            
                if (context.HttpContext.Session.GetString("CompanyUserID") == null)
                {
                    context.Result = new RedirectToActionResult("SignIn", "CompanyUser", new { area = "" });
                }
            
        }
    }
}
