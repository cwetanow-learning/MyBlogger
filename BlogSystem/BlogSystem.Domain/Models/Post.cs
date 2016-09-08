using BlogSystem.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using BlogSystem.Domain.Contracts;
using BlogSystem.Domain.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Domain.Models
{
    public class Post : DeletableEntity, IPost
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        public ApplicationUser Author
        {
            get; set;
        }

        public virtual IEnumerable<Comment> Comments
        {
            get;
        }

        public DateTime Date
        {
            get; set;
        }

        [Key]
        public int PostId
        {
            get; set;
        }

        public int Rating
        {
            get; set;
        }

        public string Subtitle
        {
            get; set;
        }

        public string Text
        {
            get; set;
        }

        public string Title
        {
            get; set;
        }
    }
}
