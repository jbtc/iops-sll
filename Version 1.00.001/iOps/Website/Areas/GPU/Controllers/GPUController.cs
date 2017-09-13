using iOps.Website.App_Code;
using System.Web.Mvc;
using iOps.Website.Controllers;
using System.Configuration;

namespace iOps.Website.Areas.GPU.Controllers
{
    public class GPUController : BaseController
    {
        // GET: GPU/ShowGPU
        //[CustomAuthorize(Roles = "admin")]
        [CustomAuthorize]
        public PartialViewResult ShowGPU(string gateNum,string zoneNum)
        {
            TempData["GateNumber"] = gateNum;
            TempData["ZoneNumber"] = zoneNum;
            TempData["ClientAbbr"] = ConfigurationManager.AppSettings["ClientShortName"].ToString();
            return PartialView("_ShowGPU");
        }
    }
}