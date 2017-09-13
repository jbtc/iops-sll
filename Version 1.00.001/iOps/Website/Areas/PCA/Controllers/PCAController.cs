using iOps.Website.App_Code;
using System.Web.Mvc;
using iOps.Website.Controllers;
using System.Configuration;

namespace iOps.Website.Areas.PCA.Controllers
{
    public class PCAController : BaseController
    {
        // GET: PCA/ShowPCA
        //[CustomAuthorize(Roles="admin")]
        [CustomAuthorize]
        public PartialViewResult ShowPCA(string gateNum,string zoneNum)
        {
            TempData["GateNumber"] = gateNum;
            TempData["ZoneNumber"] = zoneNum;
            TempData["ClientAbbr"] = ConfigurationManager.AppSettings["ClientShortName"].ToString();
            return PartialView("_ShowPCA");
        }
    }
}