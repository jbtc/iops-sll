//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using PagedList;
//using PagedList.Mvc;
//using System.Data.Entity;
//using iOps.DataEF;

//namespace iOps.Website.Controllers
//{

//    public class ScreensController : Controller
//    {
       
//        iopsContext db = new iopsContext();

//        // GET: Screens
//        public ActionResult Index()
//        {
//            return View(db.Screens.ToList());
//        }

//        //private ActionResult GetScreens(string sort = "")
//        //{
//        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
//        //    ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
//        //    var screens = from s in db.Screens select s;

//        //    iopsContext dbSorted = SortScreens(db, sort);
      
//        //    return PartialView("ListItems\Screens.cshtml", dbSorted.Screens.ToList();
//        //}
         
//        //private iopsContext SortScreens(iopsContext screens, string sort)
//        //{
//        //    switch (sort.ToLower())
//        //    {
//        //        default:
//        //            screens = screens.OrderBy(s => s.DisplayOrder);
//        //            break;
//        //        case "namedesc":
//        //            screens = screens.OrderByDescending(u => u.FirstName).ThenByDescending(u => u.LastName);
//        //            break;
//        //        case "emailasc":
//        //            screens = screens.OrderBy(u => u.Email);
//        //            break;
//        //        case "emaildesc":
//        //            screens = screens.OrderByDescending(u => u.Email);
//        //            break;
//        //        case "typeasc":
//        //            screens = screens.OrderBy(u => u.UsertypeSortingOrder);
//        //            break;
//        //        case "typedesc":
//        //            screens = screens.OrderByDescending(u => u.UsertypeSortingOrder);
//        //            break;
//        //    }
//        //    return screens;
//        //}
//    }
//}