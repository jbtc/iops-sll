using iOps.Service.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using iOps.Core.Model;

namespace iOps.Website.Controllers
{
    public class BaseController : Controller
    {
        protected virtual new User User
        {
            get 
            { 
                var db = new iOps.Core.Model.iopsContext();
                JsonSerializer serializer = new JsonSerializer();

                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if(authCookie == null)
                {
                    RedirectToAction("SignOff", "Account");
                }
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                
                string name = authTicket.Name;

                User[] users = db.Users.Where(o => o.Username == name && o.IsDeleted == false).ToArray<User>();
                foreach (User user in users)
                {
                    if (user.Organizations.Where(o => o.Designator.Equals("SLL")).Count() > 0) return user;
                }
                return null;
            }
        }
    }
}