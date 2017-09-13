using System.Web.Mvc;

namespace iOps.Website.Areas.NetworkMonitor
{
    public class NetworkMonitorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NetworkMonitor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NetworkMonitor_default",
                "NetworkMonitor/{controller}/{action}/{id}",
                new { action = "ShowNetworkMonitor", id = UrlParameter.Optional }
            );
        }
    }
}