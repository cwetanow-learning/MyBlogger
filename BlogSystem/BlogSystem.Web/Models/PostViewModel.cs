using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.Models
{
    public class PostViewModel
    {
        public IPost Post { get; set; }

        public string CommentText { get; set; }
    }
}