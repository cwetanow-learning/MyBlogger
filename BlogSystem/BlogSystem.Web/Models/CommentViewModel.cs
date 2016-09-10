using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.Models
{
    public class CommentViewModel
    {
        public int PostId { get; set; }

        public string Text { get; set; }
    }
}