using System.Web.Mvc;
using System.Linq;
using System;
using System.Configuration;
using iOps.Website.App_Code;
using iOps.Website.Controllers;
using iOps.Core.Model;
using iOps.Data;
using iOps.Service.Security;

namespace iOps.Website.Areas.Gate.Controllers
{
    public class GateController : BaseController
    {
        private iopsContext db_iops = new iopsContext();
        private iopsWeatherEntities db = new iopsWeatherEntities();

        //[CustomAuthorize(Roles = "admin")]

        private string GateLabel(int gateNum)
        {
            string lr = (gateNum % 2 == 0) ? "R" : "L";
            int gn = ((int)System.Math.Floor(((double)gateNum + 1.0) / 2)) + 10;
            return gn.ToString() + lr;
        }

        private void setGateTemps(string gateNum,string zoneNum) {
            int screenNumber = 8;
            //int screenNumber = (from us in db_iops.Users
            //                    where us.Username.Contains(User.UserName)
            //                    select us.UsersXrefScreens).Count();

            //int screenNumber =  (from s in db.Screens
            //                           where s.Name.Contains("CID") && !s.Name.Contains("Term")
            //                           select s).Count();

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

            TempData["CIDMaxScreens"] = screenNumber;
            TempData["GateNumber"] = gateNum;
            TempData["GateLabel"] = dbData.DisplayName;
            TempData["ZoneNumber"] = zoneNum;
            TempData["ZoneScreeenNumber"] = dbData.DefaultDisplayOrder.ToString();
            TempData["ClientAbbr"] = client;

            TempData["AuthLevel"] = authLevel;
        }

        //[CustomAuthorize]
        public PartialViewResult ShowGates(string gateNum,string zoneNum)
        {
            //int zoneNumb =0;
           // int gateNumb= 0;
            //if (zoneNum == "A1")
               // zoneNumb = 1;
             //else if (zoneNum == "B1")
             //   zoneNumb = 2;
            //else if (zoneNum == "B2")
            //    zoneNumb = 3;
            //else if (zoneNum == "B3")
            //    zoneNumb = 4;

            //if (gateNum == "A5")
             //   gateNumb = 1;
             //else if (gateNum == "B25L1")
             //  gateNumb = 2;
            //else if (gateNum == "B27")
              //  gateNumb = 3;
   
            setGateTemps(gateNum,zoneNum);
            return PartialView("_ShowGates");            
        }



        public PartialViewResult ShowServiceCounters(int gateNum)
        {
            //setGateTemps(gateNum,1);
            return PartialView("_ShowServiceCounters");
        }
    }
}