using iOps.Website.Controllers;
using System;
using System.Globalization;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using iOps.Service.Security;
using System.Web.Http;
using Telerik.Reporting.Services.WebApi;


namespace iOps.Website
{

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ReportsControllerConfiguration.RegisterRoutes(GlobalConfiguration.Configuration);
            Bootstrapper.Bootstrap();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User == null)
                return;
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                return;
            if (!(HttpContext.Current.User.Identity is FormsIdentity))
                return;

            var id = HttpContext.Current.User.Identity as FormsIdentity;
            //var ticket = id.Ticket;
            //var userData = ticket.UserData;
            //var roles = userData.Split(new[] { ',' });

            //HttpContext.Current.User = new GenericPrincipal(id, roles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var c = Request.Cookies["lang"];
            if (c == null || c.Value == "auto")
                return;

            var l = c.Value;

            // Uses WebForms code to apply "auto" culture to current thread and deal with
            // invalid culture requests automatically. Defaults to en-US when not specified.
            using (var fakePage = new Page())
            {
                var ignored = fakePage.Server; // Work around a WebForms quirk
                fakePage.Culture = l; // Apply local formatting to this thread
                fakePage.UICulture = l; // Apply local language to this thread
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(l);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(l);
                HttpContext.Current.Items.Add("lang", l);
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var httpException = exception as HttpException;

            //var exception = Server.GetLastError();
            //// Log the exception.
            //Response.Clear();

            //var httpException = exception as HttpException;

            //var routeData = new RouteData();
            //routeData.Values.Add("controller", "Error");

            //if (httpException == null)
            //{
            //    routeData.Values.Add("action", "Index");
            //}
            //else //It's an Http Exception, Let's handle it.
            //{
            //    switch (httpException.GetHttpCode())
            //    {
            //        case 404:
            //            // Page not found.
            //            routeData.Values.Add("action", "HttpError404");
            //            break;
            //        case 505:
            //            // Server error.
            //            routeData.Values.Add("action", "HttpError505");
            //            break;
            //            // Here you can handle Views to other error codes.
            //            // I choose a General error template  
            //        default:
            //            routeData.Values.Add("action", "Index");
            //            break;
            //    }
            //}

            //// Pass exception details to the target error View.
            //routeData.Values.Add("error", exception);

            //// Clear the error on server.
            //Server.ClearError();

            //// Call target Controller and pass the routeData.
            //IController errorController = new ErrorController();
            //errorController.Execute(new RequestContext(
            //    new HttpContextWrapper(Context), routeData));
        }
    }

    public static class StringExtensions
    {
        public static string AppendBackSlash(this String s)
        {
            if (s.EndsWith(@"\"))
                return s;

            return s + @"\";
        }
        public static string AppendForwardSlash(this String s)
        {
            if (s.EndsWith(@"/"))
                return s;

            return s + @"/";
        }
        public static string MakeBackSlashes(this String s)
        {
            return s.Replace("/", @"\");
        }
        public static string MakeForwardSlashes(this String s)
        {
            return s.Replace(@"\", "/");
        }
    }
}