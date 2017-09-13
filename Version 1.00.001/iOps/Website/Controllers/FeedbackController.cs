using System.Web.Mvc;
using iOps.Core.Model;
using iOps.Core.Repository;
using iOps.Website.Dto;
using Omu.ValueInjecter;
using System;

namespace iOps.Website.Controllers
{
    public class FeedbackController : BaseController
    {
        private readonly IRepo<Feedback> repo;

        public FeedbackController(IRepo<Feedback> repo)
        {
            this.repo = repo;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new FeedbackInput());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FeedbackInput input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            input.Comments = HtmlUtil.SanitizeHtml(input.Comments);
            
            var feedback = new Feedback { Comments = input.Comments };
            feedback = repo.Insert(feedback);
            repo.Save();

            Session["lastFeedback"] = feedback.ID;
            return Json(new { });
        }

        public ActionResult Edit(Guid id)
        {
            return View("Create", new FeedbackInput().InjectFrom(repo.Get(id)));
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(FeedbackInput input)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", input);
            }

            var feedback = repo.Get(input.ID);
            feedback.Comments = HtmlUtil.SanitizeHtml(input.Comments);
            repo.Save();

            return Json(new { });
        }
    }
}