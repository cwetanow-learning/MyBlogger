using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Utils;
using BlogSystem.Web.Controllers.Abstract;
using Microsoft.AspNet.Identity;
using PagedList;
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

        public ActionResult Index(int page = 1)
        {
            var currentDate = DateHelper.GetCurrentTime();

            var users = this.UserManager.Users
                .ToList()
                .Where(u => !this.UserManager.IsLockedOut(u.Id))
                .ToPagedList(page, GlobalConstants.AdminPageUserListCount);

            return this.View(users);
        }

        public ActionResult Delete(string id)
        {
            var user = this.UserManager.FindById(id);
            user.LockoutEndDateUtc = DateHelper.BanUser();

            this.UserManager.Update(user);

            return this.RedirectToAction("Index");
        }

        public ActionResult Adminise(string id)
        {
            var user = this.UserManager.FindById(id);

            this.UserManager.AddToRole(id, GlobalConstants.AdministratorRole);

            return this.RedirectToAction("Index");
        }

        public ActionResult Unadmin(string id)
        {
            var user = this.UserManager.FindById(id);

            this.UserManager.RemoveFromRole(id, GlobalConstants.AdministratorRole);

            return this.RedirectToAction("Index");
        }

        public ViewResult Restore(int page = 1)
        {
            var users = this.UserManager.Users
                .ToList()
                .Where(u => this.UserManager.IsLockedOut(u.Id))
                .ToPagedList(page, GlobalConstants.AdminPageUserListCount);

            return this.View(users);
        }

        [HttpPost]
        public ActionResult Restore(string userId)
        {
            var user = this.UserManager.FindById(userId);

            user.LockoutEndDateUtc = null;
            this.UserManager.Update(user);

            return this.RedirectToAction("Index");
        }

    }
}