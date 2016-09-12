using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.Models
{
    public class ProfileViewModel
    {
        public ApplicationUser User { get; set; }

        public IEnumerable<IComment> Comments { get; set; }

        public IEnumerable<IPost> Posts { get; set; }
    }
}