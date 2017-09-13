using System;
using System.Linq;
using System.Web.Mvc;
using Omu.AwesomeMvc;
using iOps.Core.Model;
using iOps.Core.Repository;

namespace iOps.Website.Controllers
{
    public class CountryIdLookupController : BaseController
    {
        private readonly IRepo<Country> repo;

        public CountryIdLookupController(IRepo<Country> repo)
        {
            this.repo = repo;
        }

        public ActionResult SearchForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string search, int page)
        {
            //var list = repo.Where(o => o.Name.StartsWith(search), User.IsInRole("Admin"))
            //    .OrderByDescending(o => o.ID);

            //return Json(new AjaxListResult
            //{
            //    Content = this.RenderView("ListItems/Country", list.Page(page, 10).ToList()),
            //    More = list.Count() > page * 10
            //});
            return null;
        }

        public ActionResult GetItem(Guid v)
        {
            var c = repo.Get(v) ?? new Country();
            return Json(new KeyContent(c.ID, c.Name));
        }
    }
}