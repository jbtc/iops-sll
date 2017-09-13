using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Omu.AwesomeMvc;
using iOps.Core.Model;
using iOps.Core.Repository;
using iOps.Resources;

namespace iOps.Website.Controllers
{
    public class CountryIdAjaxDropdownController : BaseController
    {
        private readonly IRepo<Country> repo;

        public CountryIdAjaxDropdownController(IRepo<Country> repo)
        {
            this.repo = repo;
        }

        public ActionResult GetItems(Guid? v)
        {
            var list = new List<SelectableItem> { new SelectableItem { Text = Mui.not_selected, Value = "" } };

            list.AddRange(repo.GetAll().ToArray().Select(o => new SelectableItem
			{
				Text = o.Name,
				Value = o.ID.ToString(),
				Selected = o.ID == v
			}));
            return Json(list);
        }
    }
}