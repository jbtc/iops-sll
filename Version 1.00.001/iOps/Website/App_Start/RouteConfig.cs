using System.Web.Mvc;
using System.Web.Routing;

namespace iOps.Website
{
    /// <summary>
    /// RouteConfig: Class for managing the Routing Collection
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// RegisterRoutes: Register items to the Routes Collection
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("elmah.axd");
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("robots.txt");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(
            //    "Default", // Route name
            //    "{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Account", action = "SignIn", id = UrlParameter.Optional });

        }
    }
}