using BlogSystem.Domain.Contracts;
using BlogSystem.Web.Controllers.Abstract;
using BlogSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class SearchController : BaseController
    {
        private IPostRepository repository;

        public SearchController(IPostRepository repo)
        {
            this.repository = repo;
        }

        public ActionResult Index()
        {
            var model = new SearchViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult SearchPosts(SearchViewModel model)
        {
            var pattern = model.Pattern;

            if (string.IsNullOrEmpty(pattern) || string.IsNullOrWhiteSpace(pattern))
            {
                return null;
            }

            var result = this.repository.Posts
                .Where(p => !p.IsDeleted)
                .Where(p => p.Title.Contains(pattern) || p.Subtitle.Contains(pattern) || p.Text.Contains(pattern));

            TempData["posts"] = result;

            return this.RedirectToAction("AllPosts", "Post");
        }
    }
}