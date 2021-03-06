﻿using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Web.Controllers.Abstract;
using BlogSystem.Web.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class ProfileController : BaseController
    {
        private IPostRepository postRepository;
        private ICommentRepository commentRepository;

        public ProfileController(IPostRepository postRepo, ICommentRepository commentRepo)
        {
            this.postRepository = postRepo;
            this.commentRepository = commentRepo;
        }

        public ActionResult Index(string username)
        {
            var user = this.UserManager.FindByName(username);
            var comments = this.commentRepository.GetUserComments(user.Id);
            var posts = this.postRepository.GetUserPosts(user.Id);

            var model = new ProfileViewModel { User = user, Comments = comments, Posts = posts };

            return View(model);
        }
    }
}