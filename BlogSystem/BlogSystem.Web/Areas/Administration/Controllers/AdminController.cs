using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Models;
using BlogSystem.Domain.Utils;
using BlogSystem.Web.Controllers.Abstract;
using Microsoft.AspNet.Identity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlogSystem.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    [RouteArea]
    public class AdminController : BaseController
    {
        private IPostRepository postRepository;
        private ICommentRepository commentRepository;

        public AdminController(IPostRepository postRepo, ICommentRepository commentRepo)
        {
            this.postRepository = postRepo;
            this.commentRepository = commentRepo;
        }

        public ActionResult Index()
        {
            var currentDate = DateHelper.GetCurrentTime();

            var users = this.UserManager.Users
                .ToList();
            users = users
                .Where(u => !this.UserManager.IsLockedOut(u.Id))
                .ToList();

            return View(users);
        }

        public ActionResult Delete(string id)
        {
            var user = this.UserManager.FindById(id);
            user.LockoutEndDateUtc = DateHelper.GetCurrentTime().AddYears(200);

            this.UserManager.Update(user);

            return this.RedirectToAction("Index");
        }
    }
}