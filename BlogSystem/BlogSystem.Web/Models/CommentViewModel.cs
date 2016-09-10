using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.Models
{
    public class CommentViewModel
    {
        public int PostId { get; set; }

        [Required]
        [StringLength(5000,MinimumLength =1)]
        public string Text { get; set; }
    }
}