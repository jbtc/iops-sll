using iOps.Website.App_Code;
using System.Web.Mvc;
using iOps.Core.Model;
using iOps.Data;
using System.Linq;
using iOps.Website.Controllers;
using System.Configuration;

namespace iOps.Website.Areas.ServiceCounters.Controllers
{
    public class ServiceCountersController : BaseController
    {
        [CustomAuthorize]
        //[CustomAuthorize(Roles = "admin")]
        public PartialViewResult ShowServiceCounters(string gateNum)
        {
            var client = ConfigurationManager.AppSettings["ClientShortName"].ToString();
            var db = new iOps.Core.Model.iopsContext();
            var dbData = db.Screens.FirstOrDefault(s => s.Name.StartsWith(client) && s.Name.Contains(gateNum) && !s.IsDeleted);
            
            int authLevel = 0;
            if(base.User.SecurityRoles.Where(r => r.Name.Contains("Admin")).Count() > 0)
                authLevel = 4;
            else if(base.User.SecurityRoles.Where(r => r.Name.Contains("Maintenance2")).Count() > 0)
                authLevel = 3;
            else if(base.User.SecurityRoles.Where(r => r.Name.Contains("Maintenance1")).Count() > 0)
                authLevel = 2;
            else if(base.User.SecurityRoles.Where(r => r.Name.Contains("User")).Count() > 0)
                authLevel = 1;

            TempData["GateNumber"] = gateNum;
            TempData["GateLabel"] = dbData.DisplayName;
            TempData["ClientAbbr"] = client;
            TempData["AuthLevel"] = authLevel;

            return PartialView("_ShowServiceCounters");
        }
    }
}