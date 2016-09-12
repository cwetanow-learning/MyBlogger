using BlogSystem.Web.Controllers.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace BlogSystem.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    [RouteArea]
    public class AdminController : BaseController
    {
        public ActionResult Index()
        {
            var users = this.UserManager.Users.ToList();

            return View(users);
        }
    }
}