using System;
using System.Linq;
using System.Web.Mvc;
using Omu.AwesomeMvc;
using iOps.Core.Model;
using iOps.Core.Repository;

namespace iOps.Website.Controllers
{
    public class SecurityRolesMultiLookupController : BaseController
    {
        private readonly IRepo<SecurityRole> repo;

        public SecurityRolesMultiLookupController(IRepo<SecurityRole> repo)
        {
            this.repo = repo;
        }

        public ActionResult SearchForm()
        {
            return Content("");
        }

        [HttpPost]
        public ActionResult Search(Guid[] selected)
        {
            var r = repo.GetAll();
            if (selected != null) r = r.Where(o => !selected.Contains(o.ID));

            return Json(new AjaxListResult { Items = r.ToArray().Select(o => new KeyContent(o.ID, o.Name)) });
        }

        public ActionResult Selected(Guid[] selected)
        {
            selected = selected ?? new Guid[] {};
            var r = repo.GetAll().Where(o => selected.Contains(o.ID)).ToArray();

            return Json(new AjaxListResult { Items = r.Select(o => new KeyContent(o.ID, o.Name)) });
        }

        public ActionResult GetItems(Guid[] v)
        {
            return Json(repo.GetAll()
                .Where(o => v.Contains(o.ID))
                .ToArray()
                .Select(o => new KeyContent(o.ID, o.Name)));
        }
    }
}