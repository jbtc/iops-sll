using System.Web.Mvc;

namespace iOps.Website.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController() 
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult ReportIndex()
        //{
        //    return View();
        //}

        public ActionResult About()
        {
            return View();
        }
        public ActionResult ViewCharts()
        {
            return View();
        }
         public ActionResult ViewChartsGraph()
        {
            return View();
        }
        public ActionResult Reporting()
        {
            return View();
        }

    }
}