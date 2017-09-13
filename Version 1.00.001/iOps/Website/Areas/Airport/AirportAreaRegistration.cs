using System.Web.Mvc;

namespace iOps.Website.Areas.Airport
{
    public class AirportAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Airport";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Airport_default",
                "Airport/{controller}/{action}/{id}",
                new { action = "ShowAirport", id = UrlParameter.Optional }
            );
        }
    }
}