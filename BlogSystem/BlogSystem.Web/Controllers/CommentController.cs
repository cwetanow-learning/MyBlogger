using BlogSystem.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class CommentController : Controller
    {
        private ICommentRepository repository;

        public CommentController(ICommentRepository repo)
        {
            this.repository = repo;
        }

        public PartialViewResult CommentOnPost(string commentText)
        {


            return this.PartialView();
        }
    }
}