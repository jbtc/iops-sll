using System.Web.Mvc;

namespace iOps.Website.Areas.ServiceCounters
{
    public class ServiceCountersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ServiceCounters";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ServiceCounters_default",
                "ServiceCounters/{controller}/{action}/{id}",
                new { action = "ShowServiceCounters", id = UrlParameter.Optional }
            );
        }
    }
}