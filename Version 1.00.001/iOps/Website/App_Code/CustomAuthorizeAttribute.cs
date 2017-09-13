using System.Web.Mvc;

namespace iOps.Website.App_Code
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {  
       public override void OnAuthorization(AuthorizationContext filterContext)
       {
           base.OnAuthorization(filterContext);
           if (filterContext.Result == null || (filterContext.Result.GetType() != typeof(HttpUnauthorizedResult)
               || !filterContext.HttpContext.Request.IsAjaxRequest()))
               return;
 
           //var redirectToUrl = "Account/SignIn" + filterContext.HttpContext.Request.UrlReferrer.PathAndQuery;
           //var redirectToUrl = "Account/SignIn";
           filterContext.Result =  new JavaScriptResult() { Script="window.location.reload()"};   
       }
   }   
}