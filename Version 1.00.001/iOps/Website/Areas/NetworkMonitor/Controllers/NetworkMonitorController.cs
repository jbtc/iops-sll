using iOps.Website.App_Code;
using System.Web.Mvc;
using iOps.Core.Model;
using iOps.Data;
using System.Linq;
using iOps.Website.Controllers;
using System;

namespace iOps.Website.Areas.NetworkMonitor.Controllers
{
    public class NetworkMonitorController : BaseController
    {
        private iopsContext db_iops = new iopsContext();
        private iopsWeatherEntities db = new iopsWeatherEntities();

        //[CustomAuthorize(Roles = "admin")]

        private string NetworkMonitorLabel(string gateNum)
        {
            return String.Format("{0} ({1})",gateNum[1] + (gateNum.Contains("L") ? "A" : "B") ,gateNum); 
        }

        private void setNetworkMonitorTemps(string gateNum) {
            int screenNumber = 8;
            //int screenNumber = (from us in db_iops.Users
            //                    where us.Username.Contains(User.UserName)
            //                    select us.UsersXrefScreens).Count();

            //int screenNumber =  (from s in db.Screens
            //                           where s.Name.Contains("CID") && !s.Name.Contains("Term")
            //                           select s).Count();

            
            TempData["CIDMaxScreens"] = screenNumber;
            TempData["GateNumber"] = gateNum;
            //TempData["GateLabel"] = NetworkMonitorLabel(gateNum);
        }

        [CustomAuthorize]
        public PartialViewResult ShowNetworkMonitor(string gateNum)
        {
            setNetworkMonitorTemps(gateNum);
            return PartialView("_ShowNetworkMonitor");
        }
    }
}