using iOps.Website.App_Code;
using System.Web.Mvc;
using System.Web.UI;
using iOps.Data;
using System.Linq;
using iOps.Website.Controllers;
using System.Configuration;

namespace iOps.Website.Areas.Zones.Controllers
{
    //[CustomAuthorize(Roles = "admin")]
    [CustomAuthorize]
    public class ZonesController : BaseController
    {       
        // Zone/ShowJFKZone
        
         public PartialViewResult ShowJFKZone(string zoneNum)
        {
            var clientName = ConfigurationManager.AppSettings["ClientShortName"].ToString();
            TempData["CIDMaxScreens"] = 7;
            TempData["ClientAbbr"] = clientName;
            return PartialView("_ShowJFKZone"+zoneNum);            
        }
          
    }
}