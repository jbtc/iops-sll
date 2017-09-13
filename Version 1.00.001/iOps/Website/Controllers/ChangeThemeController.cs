using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iOps.Website.Controllers
{
    public class ChangeThemeController : BaseController
    {
        private const string DefaultTheme = "iOps Ver 1.0.0";

        private const string CookieName = "iOps2014theme";

        //theme, jqueryUiTheme
        readonly IDictionary<string, string> themes = new Dictionary<string, string>
        {
            { "iOps Ver 1.0.0", "smoothness" },
            { "bui", "smoothness" },
            { "met", "smoothness" },
            { "gui", "smoothness" },
            { "gui2", "smoothness" },
            { "gui3", "start" },
            { "compact", "smoothness" },
            { "start", "start" },
            { "black-tie", "black-tie" },
        };

        public ActionResult Index()
        {
            var currentTheme = DefaultTheme;

            if (Request.Cookies[CookieName] != null)
                currentTheme = Request.Cookies[CookieName].Value;

            return View(themes.Select(theme => new SelectListItem
            {
                Text = theme.Key,
                Value = theme.Key + "|" + theme.Value,
                Selected = theme.Key == currentTheme
            }));
        }

        [HttpPost]
        public ActionResult Change(string s)
        {
            Response.Cookies.Add(new HttpCookie(CookieName, s) { Expires = DateTime.Now.AddDays(30) });
            return new EmptyResult();
        }

        public string GetTheme()
        {
            var s = DefaultTheme;
            if (Request.Cookies[CookieName] != null && themes.ContainsKey(Request.Cookies[CookieName].Value))
            {
                s = Request.Cookies[CookieName].Value;
            }

            return s;
        }

        public string GetJqTheme()
        {
            var s = DefaultTheme;
            if (Request.Cookies[CookieName] != null && themes.ContainsKey(Request.Cookies[CookieName].Value))
            {
                s = Request.Cookies[CookieName].Value;
            }

            return themes[s];
        }
    }
}