using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Domain.Contracts;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Domain.Models
{
    public class Comment : DeletableEntity, IComment
    {
        public IApplicationUser Author
        {
            get; set;
        }

        [Key]
        public int CommentId
        {
            get; set;
        }

        public string CommentText
        {
            get; set;
        }

        public DateTime Date
        {
            get; set;
        }

        public IPost Post
        {
            get; set;
        }
    }
}
