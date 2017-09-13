using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using System.Security.Principal;
using iOps.Core.Model;
using iOps.Core.Security;
using iOps.Service.Security;
using Newtonsoft.Json;

namespace iOps.Website.Controllers
{
    public class FormAuthService : IFormsAuthentication
    {
        public void SignIn(User user, bool createPersistentCookie)
        {

            var roles = user.SecurityRoles.Select(r => r.Name).ToArray();
            var groups = user.SecurityGroups.Select(g => g.Name).ToArray();
            var tasks = user.SecurityTasks.Select(t => t.Name).ToArray();

            CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
            serializeModel.ID = user.ID;
            serializeModel.UserName = user.Username;
            serializeModel.FirstName = user.FirstName;
            serializeModel.LastName = user.LastName;
            serializeModel.SecurityRoles = roles;
            serializeModel.SecurityGroups = groups;
            serializeModel.SecurityTasks = tasks;

            string userData = JsonConvert.SerializeObject(serializeModel);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                1,
                user.Username,  //user id
                DateTime.Now,
                DateTime.Now.AddDays(30),  // expiry
                createPersistentCookie,
                userData,
                "/");

            //string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
           
            if (authTicket.IsPersistent)
            {
                cookie.Expires = authTicket.Expiration;
            }

            HttpContext.Current.Response.Cookies.Add(cookie);
            HttpContext.Current.Request.Cookies.Set(cookie);
            FormsAuthentication.SetAuthCookie(user.Username, createPersistentCookie, "/");
            HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(user.Username), user.SecurityRoles.Select(r => r.Name).ToArray());
            var test = HttpContext.Current.User.IsInRole("Admin");
            //HttpContext.Current.Response.Redirect(FormsAuthentication.GetRedirectUrl(user.Username, createPersistentCookie));
            
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}