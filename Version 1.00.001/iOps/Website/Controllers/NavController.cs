using System.Web.Mvc;

namespace iOps.Website.Controllers
{
    public class NavController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}