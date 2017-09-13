using System.Web.Mvc;

namespace iOps.Website.Areas.Gate
{
    public class GateAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Gate";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Gate_default",
                "Gate/{controller}/{action}/{id}",
                new { action = "ShowGate", id = UrlParameter.Optional }
            );
        }
    }
}