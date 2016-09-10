using BlogSystem.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers.Abstract
{
    public class BaseController : Controller
    {
        protected ApplicationUser currentUser;
        protected ApplicationUserManager userManager;

        public ApplicationUser CurrentUser
        {
            get
            {
                return this.currentUser ?? this.UserManager.FindById(this.GetCurrentUserId());
            }
            private set
            {
                this.currentUser = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                this.userManager = value;
            }
        }

        protected string GetCurrentUserId()
        {
            return System.Threading.Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}