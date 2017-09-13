using System.Linq;
using System.Configuration;
using System.Web.Mvc;
using iOps.Core.Model;
using iOps.Core.Security;
using iOps.Core.Service;
using iOps.Website.Dto;
using iOps.Data;

namespace iOps.Website.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IFormsAuthentication formsAuth;
        private readonly IUserService us;
        private iopsWeatherEntities db = new iopsWeatherEntities();

        public AccountController(IFormsAuthentication formsAuth, IUserService us)
        {
            this.formsAuth = formsAuth;
            this.us = us;
        }

        public ActionResult SignIn()
        {
            return View(new SignInInput{
                Username = ConfigurationManager.AppSettings["DebugUserName"] != null?ConfigurationManager.AppSettings["DebugUserName"]:null, 
                Password = ConfigurationManager.AppSettings["DebugPassword"] != null?ConfigurationManager.AppSettings["DebugPassword"]:null});
        }

        [HttpPost]
        public ActionResult SignIn(SignInInput input)
        { 
            if (!ModelState.IsValid)
            {
                input.Password = null;
                input.Username = null;
                input.Remember = false;
                return View(input);
            }

            string _clientName = "SLL";

            User user = us.Get(_clientName ,input.Username, input.Password);
            
            ////ACHTUNG: remove this line in a real app
            //if (user == null && input.Username == "crane" && input.Password == "i0ps2@14") user = new User { Username = "crane", SecurityRoles = new[] { new SecurityRole { Name = "Admin" } } };

            if (user == null)
            {
                ModelState.AddModelError("", "Try Username: crane and Password: i0ps2@14");
                return View();
            }

            //formsAuth.SignIn(user.Login, input.Remember, user.Roles.Select(o => o.Name));
			formsAuth.SignIn(user, input.Remember);

            return RedirectToAction("ShowAirport", "Airport", new { area = "Airport", clientName = _clientName, numberOfScreens = user.UsersXrefScreens.Count() });
            //return RedirectToAction("Index", "Home");
            //return RedirectToAction("Index", "_GatesJBT");
            //return RedirectToAction("Index", "RDUGates");
            //return View("~/Views/RDU/Gates/Index.cshtml");
            //return View("~/Views/RDUGates/Index.cshtml");
            //return View("~/Views/RDU/GPU/Index.cshtml");
            //return View("~/Views/RDU/PCA/Index.cshtml");
            //@Html.Partial("~/Views/Header/_Header.cshtml")
            //return RedirectToAction("Index", "Screens");
        }

        public ActionResult SignOff()
        {
            formsAuth.SignOut();
            return RedirectToAction("SignIn", "Account");
        }
    }
}