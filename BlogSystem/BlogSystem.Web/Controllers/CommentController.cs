using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Models;
using BlogSystem.Domain.Utils;
using BlogSystem.Web.Controllers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class CommentController : BaseController
    {
        private ICommentRepository repository;

        public CommentController(ICommentRepository repo)
        {
            this.repository = repo;
        }

        [HttpPost]
        public PartialViewResult CommentPost(string commentText, Post post)
        {
            var comment = new Comment
            {
                CommentText = commentText,
                Author = this.CurrentUser,
                Post = post,
                Date = DateHelper.GetCurrentTime()
            };

            this.repository.WriteComment(comment);

            return this.PartialView(comment);
        }
    }
}