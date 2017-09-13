using iOps.Website.App_Code;
using System.Web.Mvc;
using System.Web.UI;
using iOps.Data;
using System.Linq;
using iOps.Website.Controllers;
using iOps.Service.Security;

namespace iOps.Website.Areas.Airport.Controllers
{
    //[CustomAuthorize(Roles = "admin")]
    //[CustomAuthorize]
    public class AirportController : BaseController
    {
        // GET: Airport/ShowAirport
        //[OutputCache(Duration=int.MaxValue, VaryByParam="none",Location=OutputCacheLocation.Server)]
        public PartialViewResult ShowAirport(string clientName, int numberOfScreens)
        {
            int authLevel = 0;
            if(base.User.SecurityRoles.Where(r => r.Name.Contains("Admin")).Count() > 0)
                authLevel = 4;
            else if(base.User.SecurityRoles.Where(r => r.Name.Contains("Maintenance2")).Count() > 0)
                authLevel = 3;
            else if(base.User.SecurityRoles.Where(r => r.Name.Contains("Maintenance1")).Count() > 0)
                authLevel = 2;
            else if(base.User.SecurityRoles.Where(r => r.Name.Contains("User")).Count() > 0)
                authLevel = 1;
            TempData["AuthLevel"] = authLevel;
            TempData["ClientAbbr"] = clientName;

            switch (clientName)
            {
                case "CID":
                    TempData["CIDMaxScreens"] = 7;
                    return PartialView("_ShowCIDAirport");
                case "SLL":
                    TempData["CIDMaxScreens"] = 10;
                    return PartialView("_ShowSLLAirport");
                
                case "JFK":
                    TempData["CIDMaxScreens"] = 8;
                    return PartialView("_ShowJFKAirport");
                default:
                    return PartialView();
            }
        }
    }
}